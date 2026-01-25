Imports System.Data
Imports System.Data.OleDb
Imports SocketTools.SocketWrench.ErrorCode

Public Class frmFormulas
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Private bindingSource1 As New BindingSource()
    Private AdaptadorDeDatos As New OleDb.OleDbDataAdapter
    Dim registros As Integer

    Private Sub frmFormulas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'verificamos cuantas filas de liquidos y cuantas de solidos se debe seleccionar
      Dim da1 As New OleDbDataAdapter("select * from NumeroTolvasTanques order by ID", sConnString)
        Dim ds1 As New DataSet
        Dim numliq As Integer
      Dim numsol1 As Integer
      Dim numsol2 As Integer

        Dim i As Integer
        da1.Fill(ds1)
        registros = ds1.Tables(0).Rows.Count
      'If registros <> 3 Then
      'Exit Sub
      'Else
      numsol1 = ds1.Tables(0).Rows(0).Item(2)
        numsol2 = ds1.Tables(0).Rows(1).Item(2)
        numliq = ds1.Tables(0).Rows(2).Item(2)
        'registros = numsol1

        registros = numliq + numsol1 + numsol2
        'End If

        'cargamos datos de productos
        Dim objda As New OleDbDataAdapter("select * from Productos order by Id_Producto", sConnString)
      Dim objds_p As New DataSet()

      'Pasamos las columnas que deseamos al dataset
      objda.Fill(objds_p, "Id_Producto")
      objda.Fill(objds_p, "Descripcion")
      If objds_p.Tables(0).Rows.Count = 0 Then
         MessageBox.Show("No existen datos de productos")
         Me.Close()
      End If
      For i = 0 To objds_p.Tables(0).Rows.Count - 1
         objds_p.Tables(0).Rows(i).Item(1) = objds_p.Tables(0).Rows(i).Item(0) & ", " & objds_p.Tables(0).Rows(i).Item(1)
         'Me.DataGridView1.Rows(i).Cells(2).Value = ds2.Tables(0).Rows(i).Item(2)            
      Next

      'Finalmente pasmos al comboBox, hasta aqui nada del otro mundo
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
      TxtTipoColumn.Name = "Tipo de Ingrediente"
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
      TxtCantidadColumn.Name = "Cantidad"
      Me.DataGridView1.Columns.Add(TxtCantidadColumn)


      Me.DataGridView1.Rows.Add(registros)
      Dim j As Integer = 1
      For i = 0 To numsol1 - 1
         Me.DataGridView1.Rows(i).Cells(0).Value = "Arido " & j
         j = j + 1
      Next
      j = 1
      For i = numsol1 To numsol1 + numsol2 - 1
         Me.DataGridView1.Rows(i).Cells(0).Value = "Cemento " & j
         j = j + 1
      Next
      j = 1
      For i = numsol1 + numsol2 To numsol1 + numsol2 + numliq - 1
         Me.DataGridView1.Rows(i).Cells(0).Value = "Liquido " & j
         j = j + 1
      Next

      'lleno los datos de la formula
      If objds.Tables(0).Rows.Count > 0 Then

         Try
            Dim da2 As New OleDbDataAdapter("select * from AdminTolvasTanques", sConnString)
            Dim ds2 As New DataSet
            da2.Fill(ds2)
            For i = 0 To ds2.Tables(0).Rows.Count - 1
               Try
                  Dim da3 As New OleDbDataAdapter("select id_ingrediente from ingredientes where id_ingrediente='" & ds2.Tables(0).Rows(i).Item(1) & "'", sConnString)
                  Dim ds3 As New DataSet
                  da3.Fill(ds3)

                  If ds3.Tables(0).Rows.Count > 0 Then
                     Me.DataGridView1.Rows(i).Cells(1).Value = ds2.Tables(0).Rows(i).Item(1)
                     'Me.DataGridView1.Rows(i).Cells(2).Value = ds2.Tables(0).Rows(i).Item(2)
                  Else
                     Me.DataGridView1.Rows(i).Cells(1).Value = "0"
                  End If
                  Me.DataGridView1.Rows(i).Cells(2).Value = 0
                  Me.cmbproductos.SelectedValue = ds2.Tables(0).Rows(i).Item(3)

               Catch ex As ArgumentException

               End Try
            Next
         Catch ex As Exception
            MessageBox.Show("No existe un ingrediente de tolva en el listado de ingredientes")
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
            cmd.CommandText = "Insert into AdminTolvasTanques values('" & DataGridView1.Rows(i).Cells(0).Value & _
            "','" & DataGridView1.Rows(i).Cells(1).Value & _
            "'," & DataGridView1.Rows(i).Cells(2).Value & _
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
            Dim total As Double = 0
            For i = 0 To Me.DataGridView1.Rows.Count - 1
                total = total + Me.DataGridView1.Rows(i).Cells(2).Value

            Next
            txttotal.Text = total
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        End Try

    End Sub

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

End Class