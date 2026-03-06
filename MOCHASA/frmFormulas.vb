Imports System.Data
Imports System.Data.OleDb
Imports SocketTools.SocketWrench.ErrorCode
Imports System.Globalization

Public Class frmFormulas
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Private bindingSource1 As New BindingSource()
    Private AdaptadorDeDatos As New OleDb.OleDbDataAdapter
    Private registros As Integer
    Private numsol1, numsol2, numliq As Integer
    Private tbTolvas As New DataTable


    Private Sub frmFormulas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'verificamos cuantas filas de liquidos y cuantas de solidos se debe seleccionar
      Dim da1 As New OleDbDataAdapter("select * from NumeroTolvasTanques order by ID", sConnString)
        Dim ds1 As New DataSet

        Dim i As Integer
        da1.Fill(ds1)
        'Se llena la tabla del número de tolvas
        da1.Fill(tbTolvas)
        registros = ds1.Tables(0).Rows.Count
        'numsol1 = ds1.Tables(0).Rows(0).Item(2)
        'numsol2 = ds1.Tables(0).Rows(1).Item(2)
        'numliq = ds1.Tables(0).Rows(2).Item(2)
        'registros = numsol1

        'registros = numliq + numsol1 + numsol2
        'End If

        'cargamos datos de productos
        Dim objda As New OleDbDataAdapter("select * from Productos order by Id_Producto", sConnString)
      Dim objds_p As New DataSet()

      'Pasamos las columnas que deseamos al dataset
      objda.Fill(objds_p, "Id_Producto")
      objda.Fill(objds_p, "Descripcion")
      If objds_p.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No existen datos de productos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If
      For i = 0 To objds_p.Tables(0).Rows.Count - 1
         objds_p.Tables(0).Rows(i).Item(1) = objds_p.Tables(0).Rows(i).Item(0) & ", " & objds_p.Tables(0).Rows(i).Item(1)
         'Me.DataGridView1.Rows(i).Cells(2).Value = ds2.Tables(0).Rows(i).Item(2)            
      Next

        'Finalmente pasamos al comboBox, hasta aqui nada del otro mundo
        Me.cmbproductos.DataSource = objds_p.Tables(0).DefaultView
      Me.cmbproductos.DisplayMember = "Descripcion"
        Me.cmbproductos.ValueMember = "Id_Producto"


        ' Al iniciar el formulario abrimos la conexion y pasamos 
        ' la =consulta al primer combobox
        da = New OleDbDataAdapter("select * from Ingredientes order by Id_Ingrediente", sConnString)
      Dim objds As New DataSet()

      'Pasamos las columnas que deseamos al dataset
      da.Fill(objds, "Id_Ingrediente")
      da.Fill(objds, "Descripcion")

      If objds.Tables(0).Rows.Count = 0 Then
         MessageBox.Show("No existen datos de Ingredientes")
         Me.Close()
      End If
      Try
         Dim da31 As New OleDbDataAdapter("select id_ingrediente from ingredientes where id_ingrediente='0'", sConnString)
         Dim ds31 As New DataSet
         da31.Fill(ds31)

         If ds31.Tables(0).Rows.Count > 0 Then
         Else
            MessageBox.Show("El sistema debe tener un ingrediente de código 0 y nombre NINGUNO")
            Me.Close()

         End If
      Catch ex As Exception

      End Try


      For i = 0 To objds.Tables(0).Rows.Count - 1
         objds.Tables(0).Rows(i).Item(1) = objds.Tables(0).Rows(i).Item(0) & ", " & objds.Tables(0).Rows(i).Item(1)
         'Me.DataGridView1.Rows(i).Cells(2).Value = ds2.Tables(0).Rows(i).Item(2)            
      Next
      'Dim fila_ing As DataRow

      'objds.Tables(0).Rows.Add(fila_ing)
      Dim TxtTipoColumn As New DataGridViewTextBoxColumn
        TxtTipoColumn.Name = "Nombre Tolva"
        Me.DataGridView1.Columns.Add(TxtTipoColumn)

      'Este es una columna de ComboBoxes
      Dim CboIngredientesColumn As New DataGridViewComboBoxColumn
      'fp
      CboIngredientesColumn.DataSource = objds.Tables(0).DefaultView
      CboIngredientesColumn.Name = "Ingredientes"

      CboIngredientesColumn.DisplayMember = "Descripcion"
      CboIngredientesColumn.ValueMember = "Id_Ingrediente"
      CboIngredientesColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
      Me.DataGridView1.Columns.Add(CboIngredientesColumn)

      Dim TxtCantidadColumn As New DataGridViewTextBoxColumn
        TxtCantidadColumn.Name = "Cantidad kg/m3"
        Me.DataGridView1.Columns.Add(TxtCantidadColumn)

        'AQ-Agregar columna para el Coeficiente de Absorcion
        Dim TxtCAbsorcion As New DataGridViewTextBoxColumn
        TxtCAbsorcion.Name = "CA"
        TxtCAbsorcion.HeaderText = "Coeficiente Absorción (C.A)"
        TxtCAbsorcion.ValueType = GetType(Double)
        TxtCAbsorcion.DefaultCellStyle.Format = "N2" 'Dos decimales
        Me.DataGridView1.Columns.Add(TxtCAbsorcion)


        Me.DataGridView1.Rows.Add(registros)
        Try
            Me.cmbproductos.SelectedIndex = 0
        Catch ex As Exception

        End Try
        '*-*-AQ--
        'Funcion para actualizar las formulas guardadas
        Actualizar_Formula_DG()
    End Sub

    Private Sub Actualizar_Formula_DG()
        Dim i As Integer
        DataGridView1.Rows.Clear()
        da = New OleDbDataAdapter("SELECT * FROM Ingredientes ORDER BY Id_ingrediente", sConnString)
        Dim objds As New DataSet

        'Pasamos las columnas que deseamos en el dataset
        da.Fill(objds, "Id_ingrediente")
        da.Fill(objds, "Descripcion")

        'Lleno los datos de la formula
        If objds.Tables(0).Rows.Count > 0 Then
            Try
                Dim cmdTxt As String = $"SELECT * FROM DetalleFormulas WHERE id_formula='{cmbproductos.SelectedValue.ToString}'"
                Dim da2 As New OleDbDataAdapter(cmdTxt, sConnString)
                Dim ds2 As New DataSet
                da2.Fill(ds2)
                If ds2.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds2.Tables(0).Rows.Count - 1
                        Try
                            cmdTxt = $"SELECT Id_ingrediente FROM ingredientes WHERE Id_ingrediente = '{ds2.Tables(0).Rows(i).Item(2)}'"
                            Dim da3 As New OleDbDataAdapter(cmdTxt, sConnString)
                            Dim ds3 As New DataSet
                            da3.Fill(ds3)

                            If ds3.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Rows.Add(1)
                                Me.DataGridView1.Rows(i).Cells(0).Value = tbTolvas.Rows(i).Item(1)
                                Me.DataGridView1.Rows(i).Cells(1).Value = ds2.Tables(0).Rows(i).Item(2)
                                Me.DataGridView1.Rows(i).Cells(2).Value = ds2.Tables(0).Rows(i).Item(3)
                                Me.DataGridView1.Rows(i).Cells(3).Value = ds2.Tables(0).Rows(i).Item(5)
                            End If
                        Catch ex As ArgumentException

                        End Try
                    Next
                Else
                    For i = 0 To registros - 1
                        Try
                            Me.DataGridView1.Rows.Add(1)
                            Me.DataGridView1.Rows(i).Cells(2).Value = 0
                            Me.DataGridView1.Rows(i).Cells(0).Value = tbTolvas.Rows(i).Item(1)
                        Catch ex As ArgumentException

                        End Try
                    Next
                End If
            Catch ex As Exception
                'MsgBox(ex.Message, "Error Actualizar Formula")
            End Try
        End If
        DataGridView1.AutoResizeColumns()


    End Sub
    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
    'MsgBox(Me.DataGridView1.CurrentRow.Cells(1).Value)

    'End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim oOleDbConnection As OleDb.OleDbConnection
        Dim i As Integer
        Try
            oOleDbConnection = New OleDb.OleDbConnection(sConnString)
            oOleDbConnection.Open()

        Catch ex As Exception
            MsgBox(ex.Message, "::Error en conexión::")
            Exit Sub
        End Try

        Dim cmd As New OleDbCommand("Delete * from AdminTolvasTanques", oOleDbConnection)
        cmd.ExecuteNonQuery()
        For i = 0 To registros - 1
            If CStr(DataGridView1.Rows(i).Cells(2).Value) = "" Then
                DataGridView1.Rows(i).Cells(2).Value = 0
            End If
            cmd.CommandText = "Insert into AdminTolvasTanques values('" & DataGridView1.Rows(i).Cells(0).Value &
            "','" & DataGridView1.Rows(i).Cells(1).Value &
            "'," & DataGridView1.Rows(i).Cells(2).Value &
            ",'" & cmbproductos.SelectedValue & "')"
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub btnenviar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnenviar1.Click
        Dim i, j As Integer
        Dim linea As String
        Me.SerialPort1.Open()
        Me.SerialPort1.Write("16,5;1%y" + vbCrLf)
        For j = 1 To retardo * 2
        Next
        For i = 0 To registros - 1
            linea = cmbproductos.SelectedValue & "," & DataGridView1.Rows(i).Cells(1).Value & "," & DataGridView1.Rows(i).Cells(2).Value & vbCrLf
            Me.SerialPort1.Write(linea)
            For j = 1 To retardo
            Next
            ''MsgBox linea
        Next
        Me.SerialPort1.Write("ENDofDB" + vbCrLf + vbCrLf)
      Me.SerialPort1.Close()
      MessageBox.Show("Proceso Finalizado")
    End Sub

    Private Sub btnenviar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnenviar2.Click
        Dim i, ii As Integer
        Dim linea As String
        Me.SerialPort1.Open()
        Me.SerialPort1.Write("10,5%y" + vbCrLf)
        For ii = 1 To retardo * 2
        Next
        Me.SerialPort1.Write("16,5;1%y" + vbCrLf)
        For i = 0 To registros - 1
            linea = cmbproductos.SelectedValue & "," & DataGridView1.Rows(i).Cells(1).Value & "," & DataGridView1.Rows(i).Cells(2).Value & vbCrLf
            Me.SerialPort1.Write(linea)
            For ii = 1 To retardo
            Next
            ''MsgBox linea
        Next
        Me.SerialPort1.Write("ENDofDB" + vbCrLf + vbCrLf)
        Me.SerialPort1.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(cmbproductos.SelectedValue.ToString)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SerialPort1.Write(Chr(3))
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim i As Integer
            Dim totalMasa As Double = 0
            Dim densidadProducto As Double
            Dim masa As Double
            Dim volumenAcumulado As Double = 0
            Dim volumen As Double
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                masa = Me.DataGridView1.Rows(i).Cells(2).Value
                totalMasa += masa
                densidadProducto = Obtiene_Densidad_Ingrediente(Me.DataGridView1.Rows(i).Cells(1).Value)
                volumen = masa / densidadProducto
                volumenAcumulado += volumen
            Next
            txttotal.Text = totalMasa
            txttotalM3.Text = volumenAcumulado.ToString("N3")
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        End Try

    End Sub
    Private Function Obtiene_Densidad_Ingrediente(idIngrediente As String) As Double
        Try
            Dim densidad As Double = 1000.0
            Dim dt As New DataTable
            Using connection As New OleDbConnection(sConnString)
                Using cmd As New OleDbCommand
                    cmd.Connection = connection
                    cmd.CommandText = "SELECT Densidad From Ingredientes
                                        WHERE Id_ingrediente= ? "
                    cmd.Parameters.AddWithValue("?", idIngrediente)
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    If dt.Rows.Count > 0 Then
                        densidad = Convert.ToDouble(dt.Rows(0).Item("Densidad"))
                    End If
                End Using
            End Using
            Return densidad
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message, "Excepción: Obtener Densidad de Ingrediente", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 1000.0
        End Try
    End Function
    Private Sub Btt_Env_AgregFormulas_Click(sender As Object, e As EventArgs) Handles Btt_Env_AgregFormulas.Click
        Btt_Env_AgregFormulas.Enabled = False
        Btt_Env_ReempFormulas.Enabled = False
        'Enviar Caracter que el controlador responda con un OK
        Funciones.enviaDatosSocket("g" & vbCrLf, Txt_Estado)
        Dim mensaje_enviar As String = ""
        Dim msj_aux As String = ""
        Dim tipoTabla As String = "w"
        Dim strBuffer As String = ""
        Dim cchBuffer As Integer = 0

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            mensaje_enviar = cmbproductos.SelectedValue & "," & DataGridView1.Rows(i).Cells(1).Value & "," & DataGridView1.Rows(i).Cells(2).Value & vbCrLf
            For x As Integer = 0 To 80
                System.Threading.Thread.Sleep(50)
                Do
                    strBuffer = ""
                    cchBuffer = clientSocketCamara.Read(strBuffer, 4096)
                    If cchBuffer > 0 Then
                        msj_aux = mensaje_enviar.Replace(vbCrLf, "")
                        Txt_Estado.Text = msj_aux & vbCrLf & Txt_Estado.Text
                        Funciones.ProcesaDato(strBuffer, Txt_Estado)
                        'Funciones.LeeCamara(Txt_Estado)
                        Exit For
                    ElseIf cchBuffer = 0 Then
                        Exit Do
                    Else
                        Select Case clientSocketCamara.LastError
                            Case errorOperationCanceled
                            Case errorNotConnected
                                Exit Do
                            Case errorOperationWouldBlock
                                Exit Do
                            Case Else
                                MsgBox("Error inesperado: (Error " & clientSocketCamara.LastError & ")")
                        End Select
                    End If
                Loop
                'If clientSocketCamara.Available > 0 Then
                '    msj_aux = mensaje_enviar.Replace(vbCrLf, "")
                '    Txt_Estado.Text = msj_aux & vbCrLf & Txt_Estado.Text
                '    Funciones.LeeCamara(clientSocketCamara, Txt_Estado, Principal.Txt_Mensj_Sistema)
                '    Exit For
                'End If
                If x >= 79 Then
                    Txt_Estado.Text = "No hay respuesta del Controlador" & vbCrLf & Txt_Estado.Text
                    Btt_Env_AgregFormulas.Enabled = True
                    Btt_Env_ReempFormulas.Enabled = True
                    Exit Sub
                End If
            Next
            Application.DoEvents()
            Funciones.enviaDatosSocket(tipoTabla & mensaje_enviar, Txt_Estado)
        Next
        'Funciones.enviaDatosSocket("ENDofDB" & vbCrLf, Txt_Estado)
        Btt_Env_AgregFormulas.Enabled = True
        Btt_Env_ReempFormulas.Enabled = True
    End Sub

    Private Sub Btt_Env_ReempFormulas_Click(sender As Object, e As EventArgs) Handles Btt_Env_ReempFormulas.Click
        Btt_Env_ReempFormulas.Enabled = False
        Btt_Env_AgregFormulas.Enabled = False
        'Enviar Caracter para borrar la tabla de formulas en el Controlador
        Funciones.enviaDatosSocket("f" & vbCrLf, Txt_Estado)
        Dim mensaje_enviar As String = ""
        Dim msj_aux As String = ""
        Dim tipoTabla As String = "w"
        Dim strBuffer As String = ""
        Dim cchBuffer As Integer = 0

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            mensaje_enviar = cmbproductos.SelectedValue & "," & DataGridView1.Rows(i).Cells(1).Value & "," & DataGridView1.Rows(i).Cells(2).Value & vbCrLf
            For x As Integer = 0 To 80
                System.Threading.Thread.Sleep(50)
                Do
                    strBuffer = ""
                    cchBuffer = clientSocketCamara.Read(strBuffer, 4096)
                    If cchBuffer > 0 Then
                        msj_aux = mensaje_enviar.Replace(vbCrLf, "")
                        Txt_Estado.Text = msj_aux & vbCrLf & Txt_Estado.Text
                        Funciones.ProcesaDato(strBuffer, Txt_Estado)
                        'Funciones.LeeCamara(Txt_Estado)
                        Exit For
                    ElseIf cchBuffer = 0 Then
                        Exit Do
                    Else
                        Select Case clientSocketCamara.LastError
                            Case errorOperationCanceled
                            Case errorNotConnected
                                Exit Do
                            Case errorOperationWouldBlock
                                Exit Do
                            Case Else
                                MsgBox("Error inesperado: (Error " & clientSocketCamara.LastError & ")")
                        End Select
                    End If
                Loop

                'If clientSocketCamara.Available > 0 Then
                '    msj_aux = mensaje_enviar.Replace(vbCrLf, "")
                '    Txt_Estado.Text = msj_aux & vbCrLf & Txt_Estado.Text
                '    Funciones.LeeCamara(clientSocketCamara, Txt_Estado, Principal.Txt_Mensj_Sistema)
                '    Exit For
                'End If
                If x >= 79 Then
                    Txt_Estado.Text = "No hay respuesta del Controlador" & vbCrLf & Txt_Estado.Text
                    Btt_Env_ReempFormulas.Enabled = True
                    Btt_Env_AgregFormulas.Enabled = True
                    Exit Sub
                End If
            Next
            Application.DoEvents()
            Funciones.enviaDatosSocket(tipoTabla & mensaje_enviar, Txt_Estado)
        Next
        'Funciones.enviaDatosSocket("ENDofDB" & vbCrLf, Txt_Estado)
        Btt_Env_ReempFormulas.Enabled = True
        Btt_Env_AgregFormulas.Enabled = True
    End Sub

    Private Sub Btt_GuardarFormula_Click(sender As Object, e As EventArgs) Handles Btt_GuardarFormula.Click
        'Validad que se ingresen los coeficientes de absorcion para Piedra y Arena
        If Not ValidarIngresoCoeficientes() Then
            MessageBox.Show("Debe ingresar coeficientes de absorción para Piedra y Arena", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            Using conection As New OleDbConnection(sConnString)
                Using cmd As New OleDbCommand
                    cmd.Connection = conection
                    cmd.CommandText = "DELETE * FROM DetalleFormulas where id_formula=?"
                    cmd.Parameters.AddWithValue("?", cmbproductos.SelectedValue.ToString)
                    conection.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, "::Error Eliminar Detalle Fórmula::")
            Exit Sub
        End Try
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If CStr(DataGridView1.Rows(i).Cells(1).Value) = "" Then
                    DataGridView1.Rows(i).Cells(1).Value = 0
                End If
                If CStr(DataGridView1.Rows(i).Cells(3).Value) = "" Then
                    DataGridView1.Rows(i).Cells(3).Value = 0.0
                End If
                Using conection As New OleDbConnection(sConnString)
                    Using cmd As New OleDbCommand
                        cmd.Connection = conection
                        cmd.CommandText = "INSERT INTO DetalleFormulas (id_formula, id_ingrediente, cantidad, Num_Tolva,CoeficienteAbsorcion) VALUES (?,?,?,?,?)"
                        cmd.Parameters.AddWithValue("?", cmbproductos.SelectedValue.ToString)
                        cmd.Parameters.AddWithValue("?", DataGridView1.Rows(i).Cells(1).Value.ToString)
                        cmd.Parameters.AddWithValue("?", CInt(DataGridView1.Rows(i).Cells(2).Value))
                        cmd.Parameters.AddWithValue("?", CInt(tbTolvas.Rows(i).Item(0)))
                        Dim coeficienteA As Decimal
                        Decimal.TryParse(DataGridView1.Rows(i).Cells(3).Value.ToString(), coeficienteA)
                        Math.Round(coeficienteA, 2)
                        cmd.Parameters.AddWithValue("?", coeficienteA)
                        conection.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Next
            MessageBox.Show("Proceso Finalizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MsgBox(ex.Message, "::Error Registrar Fórmula::")
            Exit Sub
        End Try
    End Sub

    Private Sub cmbproductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbproductos.SelectedIndexChanged
        Actualizar_Formula_DG()
        txttotal.Text = ""
        txttotalM3.Text = ""
    End Sub

    Private Function ValidarIngresoCoeficientes() As Boolean
        For Each fila As DataGridViewRow In DataGridView1.Rows
            ' Evitar fila nueva vacía
            If fila.IsNewRow Then Continue For
            Dim idProducto As Integer = 0
            Dim coeficiente As String = ""

            If fila.Cells("Ingredientes").Value IsNot Nothing Then
                idProducto = Convert.ToInt32(fila.Cells("Ingredientes").Value)
            End If

            If fila.Cells("CA").Value IsNot Nothing Then
                coeficiente = fila.Cells("CA").Value.ToString.Trim
            End If

            If (idProducto = 1 Or idProducto = 2) AndAlso String.IsNullOrEmpty(coeficiente) Then
                Return False
            End If
        Next
        Return True
    End Function
End Class