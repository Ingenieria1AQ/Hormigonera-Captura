Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Public Class DatosDespacho
    Dim codigo As Long
    Dim pesoManual As Boolean = False

    Dim conn As New OleDb.OleDbConnection(sConnString)
    Dim tipotrans As String = "Entra"
    Dim egresoingreso As String = "INGRESO"
    DIM IdIngresoEntra As String
    Dim IdEgresoEntra As String
    Dim IdIngresoSale As String

    Private Sub VentaEntrada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim con As New OleDbConnection(sConnString)
        Dim cmd As OleDbCommand


        'Try   'Carga imagen logo en pantalla
        '    cmd = New OleDb.OleDbCommand
        '    con.Open()
        '    cmd.Connection = con
        '    cmd.CommandText = "select LogoEmpresa from Configuracion"
        '    If IsDBNull(cmd.ExecuteScalar) = False Then
        '        Me.pcbLogo.Image = LoadImage1(DirectCast(cmd.ExecuteScalar, Byte()))
        '    End If
        '    con.Close()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally
        '    con.Close()
        'End Try
        ' ****************************************************************
        ' **** Para el combobox1
        '*****************************************************************
        ' esto tambien funciona pero no en este caso

        ' Try
        'Dim sql As String = "SELECT CodCliente,Nombre FROM Clientes ORDER BY Nombre"
        ' Dim da As New OleDbDataAdapter(sql, con)
        'Dim dt As DataTable = New DataTable("Clientes")
        'da.Fill(dt)
        'With ComboBox1
        '.DataSource = dt
        '.DisplayMember = "Nombre"
        '.ValueMember = "CodCliente"
        ' .Text = " "

        'End With
        'Catch ex As Exception
        'MessageBox.Show(ex.Message)
        'End Try
        ' *********************************************************************
        'Dim tabla3 As New DataTable
        'Dim adaptadordedatos3 As OleDb.OleDbDataAdapter
        'Dim cmdtxt2 As String = "SELECT * FROM Clientes ORDER BY Nombre"
        '' Crear un nuevo adaptador de datos basado en el 'query' especificado
        'adaptadordedatos3 = New OleDb.OleDbDataAdapter(cmdtxt2, stringcon)
        'adaptadordedatos3.Fill(tabla3)
        'Dim i As Integer
        'For i = 0 To tabla3.Rows.Count - 1
        '    ComboBox1.Items.Add(tabla3.Rows(i).Item("Nombre"))
        'Next
        'Try
        '    ComboBox1.SelectedIndex = 0
        'Catch ex As Exception

        'End Try
        ' ***********************************************************************


        'Try
        '    Dim sql As String = "SELECT CodCliente,Nombre + ' , ' + CodCliente as Nombres FROM Clientes"
        '    Dim da As New OleDbDataAdapter(sql, con)
        '    Dim dt As DataTable = New DataTable("Clientes")
        '    da.Fill(dt)
        '    With cmbcliente
        '        .DataSource = dt
        '        .DisplayMember = "Nombres"
        '        .ValueMember = "CodCliente"
        '    End With
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
        'Try
        '    Dim sql As String = "SELECT CodProducto,Nombre + ' , ' + CodProducto as Nombres,Densidad FROM Productos"
        '    Dim da As New OleDbDataAdapter(sql, con)
        '    Dim dt As DataTable = New DataTable("Productos")
        '    da.Fill(dt)
        '    With cmbproducto
        '        .DataSource = dt
        '        .DisplayMember = "Nombres"
        '        .ValueMember = "CodProducto"
        '    End With

        '    ' Enlazamos el control de texto con el objeto DataSet
        '    '
        '    txtdensidad.DataBindings.Add("Text", dt, "Densidad")
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

        'Try
        '    Dim sql As String = "SELECT CodChofer,Nombre + ' , ' + CodChofer + ' , ' + Cedula as Nombres FROM Choferes"
        '    Dim da As New OleDbDataAdapter(sql, con)
        '    Dim dt As DataTable = New DataTable("Choferes")
        '    da.Fill(dt)
        '    With cmbchofer
        '        .DataSource = dt
        '        .DisplayMember = "Nombres"
        '        .ValueMember = "CodChofer"
        '    End With
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try


        'datos por defecto
        lbltipo.Text = egresoingreso
        lbloperador.Text = nomoperador
        codCliente.Text = ""
        nomCliente.Text = ""
        codProducto.Text = ""
        nomProducto.Text = ""
        codChofer.Text = ""
        nomChofer.Text = ""
        codCliente.Enabled = False
        codProducto.Enabled = False
        codChofer.Enabled = False
        nomCliente.Enabled = False
        nomProducto.Enabled = False
        nomChofer.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        txtfecha.Text = Date.Today
        txthora.Text = CStr(Date.Now.Hour).PadLeft(2, "0") & ":" & CStr(Date.Now.Minute).PadLeft(2, "0") & ":" & CStr(Date.Now.Second).PadLeft(2, "0")
        'txtdensidad.Enabled = cambiardensidad
        If tipotrans = "Entra" Then
            codigo = leerconsecutivo("Despacho")
            lblcomprobante.Text = CStr(codigo) '.PadLeft(8, "0")
            'codigo = 3100
            'If codigo > 3050 Then
            ''Me.Close()
            'Application.Exit()
            'End If
            'Label12.Visible = False
            'txtclave.Visible = False
            btnokclave.Visible = False


        ElseIf tipotrans = "Sale" Then
            'btncargartara.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = False
            'If CargaTaras Then
            '    btncargartara.Visible = True
            'Else
            '    btncargartara.Visible = False
            'End If
        End If
        If egresoingreso = "INGRESO" Then
            Label2.Text = "Proveedor:"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub



    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Dim con As New OleDbConnection(sConnString)
        Dim cmd As OleDbCommand
        Dim complete As Integer
        If lblcomprobante.Text = "--" Or lblcomprobante.Text = "" Then 'Para que no se grabe el comprobante como "--"
            MessageBox.Show("La transacción no puede grabarse porque el sistema no pudo leer el número consecutivo del comprobante. Por favor cierre esta pantalla de ingreso de datos y vuelva a intentarlo. Si el error persiste, porfavor contáctese con su proveedor.")
            Exit Sub
        End If


        If tipotrans = "Entra" Then
            If Me.codChofer.Text <> "" And Me.codCliente.Text <> "" And Me.codProducto.Text <> "" And Me.txtidMixer.Text <> "" Then
                Try
                    'complete = guardartransaccion(lblcomprobante.Text, lbltipo.Text, codOperador, txtfecha.Text, txthora.Text, codCliente.Text, codProducto.Text, txtdocumento.Text, txtPlaca.Text, codChofer.Text, txtobservaciones.Text, txtm3.Text, "", "", "", "", txtidMixer.Text, False)
                    complete = guardartransaccion(lblcomprobante.Text, "DESPACHO", codOperador, txtfecha.Text, txthora.Text, codCliente.Text, codProducto.Text, txtdocumento.Text, txtPlaca.Text, codChofer.Text, txtobservaciones.Text, txtm3.Text, "", "", "", "", txtidMixer.Text, False)
                    If complete = 1 Then
                        Dim csave As Integer
                        csave = guardarconsecutivo("Despacho", codigo)
                        'If tipotrans = "Entra" And egresoingreso = "EGRESO" Then
                        '    If txtplaca.Text <> "" Then Call guardartara(txtplaca.Text, txtpesoentra.Text)
                        'End If

                        IdIngresoEntra = lblcomprobante.Text
                        IdEgresoEntra = lblcomprobante.Text
                        txtfecha.Text = Date.Today
                        txthora.Text = CStr(Date.Now.Hour).PadLeft(2, "0") & ":" & CStr(Date.Now.Minute).PadLeft(2, "0") & ":" & CStr(Date.Now.Second).PadLeft(2, "0")
                        'codigo = leerconsecutivo("Despacho")
                        'lblcomprobante.Text = CStr(codigo)    '.PadLeft(8, "0")
                        codCliente.Text = ""
                        nomCliente.Text = ""
                        codProducto.Text = ""
                        nomProducto.Text = ""
                        codChofer.Text = ""
                        nomChofer.Text = ""
                        txtdocumento.Text = ""
                        txtPlaca.Text = ""
                        txtobservaciones.Text = ""
                        txtidMixer.Text = ""
                        txtNomMixer.Text = ""
                        idDespacho = lblcomprobante.Text
                        Proceso.Txt_CodOrdenDespacho.Text = lblcomprobante.Text
                        codCliente.Enabled = False
                        codProducto.Enabled = False
                        codChofer.Enabled = False
                        nomCliente.Enabled = False
                        nomProducto.Enabled = False
                        nomChofer.Enabled = False

                        Button1.Enabled = True
                        Button2.Enabled = True
                        Button3.Enabled = True


                        MessageBox.Show("La información se ha almacenado con exito", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'If lbltipo.Text = "INGRESO" Then
                        '    IngresoEntraFRM.Show()
                        'Else
                        '    EgresoEntraFRM.Show()
                        'End If

                    Else
                        MessageBox.Show("No se pudo almacenar la transaccion compruebe los datos", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    con.Close()
                    Me.Close()
                End Try
            Else
                MessageBox.Show("No se puede almacenar la transaccion, revise los datos")
            End If
        ElseIf tipotrans = "Sale" Then
            If lblcomprobante.Text <> "--" Then
                complete = actualizartransaccion(lblcomprobante.Text, codCliente.Text, codProducto.Text, txtdocumento.Text, txtPlaca.Text, codChofer.Text, txtobservaciones.Text, txtm3.Text, "", "", "", "", txtidMixer.Text)
                If complete = 1 Then
                    Dim swy As StreamWriter = File.AppendText(Application.StartupPath & "\ingresos.txt")
                    swy.WriteLine(lblcomprobante.Text.Trim & "," & codProducto.Text.Trim & "," & codCliente.Text.Trim & "," & codChofer.Text.Trim & "," & Date.Now.ToShortDateString & " " & Date.Now.ToLongTimeString)
                    swy.Close()

                    'If tipotrans = "Sale" And egresoingreso = "INGRESO" Then
                    '    If txtplaca.Text <> "" Then Call guardartara(txtplaca.Text, txtpesosale.Text)
                    'End If

                    MessageBox.Show("La transaccion se ha almacenado con exito")
                    codCliente.Text = ""
                    nomCliente.Text = ""
                    codProducto.Text = ""
                    nomProducto.Text = ""
                    codChofer.Text = ""
                    nomChofer.Text = ""
                    txtdocumento.Text = ""
                    txtPlaca.Text = ""

                    txtobservaciones.Text = ""
                    IdIngresoSale = lblcomprobante.Text
                    lblcomprobante.Text = "--"

                    'Button1.Enabled = True
                    'Button2.Enabled = True
                    'Button3.Enabled = True

                    'IngresoSaleFRM.Show()
                End If
            End If
        End If
    End Sub

    Private Sub btnokclave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnokclave.Click
        'If txtclave.Text <> "" Then
        '    Dim con As New OleDbConnection(sConnString)
        '    Dim cmd As OleDbCommand
        '    Try
        '        cmd = New OleDb.OleDbCommand
        '        cmd.Connection = con
        '        cmd.CommandText = "select * from transacciones where clave = '" & txtclave.Text & "' and tipo = 'INGRESO'"
        '        Dim da As New OleDbDataAdapter(cmd)
        '        Dim ds As New DataSet
        '        da.Fill(ds)
        '        If ds.Tables(0).Rows.Count <> 0 Then
        '            With ds.Tables(0)
        '                lbltipo.Text = .Rows(0).Item(1)
        '                txtdocumento.Text = .Rows(0).Item(8)
        '                txtplaca.Text = .Rows(0).Item(9)
        '                txtpesoentra.Text = .Rows(0).Item(11)
        '                txtobservaciones.Text = .Rows(0).Item(14)
        '                txtdensidad.Text = .Rows(0).Item(17)
        '                lblcomprobante.Text = .Rows(0).Item(0)
        '                codCliente.Text = .Rows(0).Item(6)
        '                codProducto.Text = .Rows(0).Item(7)
        '                codChofer.Text = .Rows(0).Item(10)

        '                ' seleccionando el nombre del cliente
        '                cmd.CommandText = "Select * from clientes where codcliente = '" & codCliente.Text & "'"
        '                Dim da1 As New OleDbDataAdapter(cmd)
        '                Dim ds1 As New DataSet
        '                da.Fill(ds1)
        '                If ds1.Tables(0).Rows.Count <> 0 Then
        '                    With ds1.Tables(0)
        '                        nomCliente.Text = .Rows(0).Item(1)
        '                    End With
        '                End If

        '                ' seleccionando el nombre del producto
        '                cmd.CommandText = "Select * from productos where codproducto = '" & codProducto.Text & "'"
        '                Dim da2 As New OleDbDataAdapter(cmd)
        '                Dim ds2 As New DataSet
        '                da.Fill(ds2)
        '                If ds2.Tables(0).Rows.Count <> 0 Then
        '                    With ds2.Tables(0)
        '                        nomProducto.Text = .Rows(0).Item(1)
        '                    End With
        '                End If

        '                ' seleccionando el nombre del chofer
        '                cmd.CommandText = "Select * from choferes where codchofer = '" & codChofer.Text & "'"
        '                Dim da3 As New OleDbDataAdapter(cmd)
        '                Dim ds3 As New DataSet
        '                da.Fill(ds3)
        '                If ds3.Tables(0).Rows.Count <> 0 Then
        '                    With ds3.Tables(0)
        '                        nomChofer.Text = .Rows(0).Item(1)
        '                    End With
        '                End If


        '            End With
        '        Else
        '            MessageBox.Show("No existe esa clave o es una VENTA - EGRESO... ")
        '        End If
        '        con.Close()
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    Finally
        '        con.Close()
        '    End Try
        'End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        tipoLista = "CHOFERES"
        destinoLista = "TransaccionesVarias"
        'listas.MdiParent = Principal
        listas.Show()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        tipoLista = "PRODUCTOS"
        destinoLista = "TransaccionesVariasP"
        ' listas.MdiParent = Principal
        listas.Show()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tipoLista = "CLIENTES"
        destinoLista = "TransaccionesVariasC"
        ' listas.MdiParent = Principal
        listas.Show()

    End Sub
    ' salto entre textbox ( sin cambiar las propiedades) txtdocumento
    Private Sub txtdocumento_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdocumento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If

    End Sub
    ' salto entre textbox ( sin cambiar las propiedades) txtplaca
    Private Sub txtplaca_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlaca.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If

    End Sub
    ' salto entre textbox ( sin cambiar las propiedades) txtobservaciones
    Private Sub txtobservaciones_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtobservaciones.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If

    End Sub
    ' salto entre textbox ( sin cambiar las propiedades) txtpesoentra
    Private Sub txtpesoentra_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{tab}")
        End If
        If tipotrans = "Entra" Then
            pesoManual = True
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tipoLista = "TRANSACCIONES"
        destinoLista = "TransaccionesVariasT"
        listas.MdiParent = Principal
        listas.Show()
    End Sub


    'Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim tabla3 As New DataTable
    '    Dim adaptadordedatos3 As OleDb.OleDbDataAdapter
    '    Dim cmdtxt2 As String = "SELECT * FROM Clientes WHERE Nombre = '" & ComboBox1.Text & "'"
    '    ' Crear un nuevo adaptador de datos basado en el 'query' especificado
    '    adaptadordedatos3 = New OleDb.OleDbDataAdapter(cmdtxt2, stringcon)
    '    adaptadordedatos3.Fill(tabla3)

    '    codCliente.Text = tabla3.Rows(0).Item(0)
    '    nomCliente.Text = tabla3.Rows(0).Item(1)

    'End Sub

    ' salto entre textbox ( sin cambiar las propiedades) codCliente
    Private Sub codCliente_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles codCliente.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

            Dim tabla3 As New DataTable
            Dim adaptadordedatos3 As OleDb.OleDbDataAdapter
            Dim cmdtxt2 As String = "SELECT * FROM Clientes WHERE CodCliente = '" & codCliente.Text & "'"
            ' Crear un nuevo adaptador de datos basado en el 'query' especificado
            adaptadordedatos3 = New OleDb.OleDbDataAdapter(cmdtxt2, sConnString)
            adaptadordedatos3.Fill(tabla3)
            Dim ds As New DataSet
            adaptadordedatos3.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                e.Handled = True
                SendKeys.Send("{tab}")
                nomCliente.Text = tabla3.Rows(0).Item(1)
            Else
                MessageBox.Show("Eso Codigo no existe.... Intente otra vez...")
            End If
        End If
    End Sub

    Private Sub txtpesoentra_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtpesosale_KeyPress(sender As Object, e As KeyPressEventArgs)
        If tipotrans = "Sale" Then
            pesoManual = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        txtfecha.Text = Date.Today
        txthora.Text = CStr(Date.Now.Hour).PadLeft(2, "0") & ":" & CStr(Date.Now.Minute).PadLeft(2, "0") & ":" & CStr(Date.Now.Second).PadLeft(2, "0")
    End Sub

    Public Function guardartransaccion(ByVal IdTran As String, ByVal Tipo As String, ByVal CodOperador As String, ByVal Fecha As String, ByVal Hora As String, ByVal CodCliente As String, ByVal CodProducto As String, ByVal Documento As String, ByVal Placa As String, ByVal CodChofer As String, ByVal Observaciones As String, ByVal NetoM3 As String, ByVal MotTraslado As String, ByVal PtoPartida As String, ByVal PtoLlegada As String, ByVal Obra As String, ByVal idMixer As String, ByVal eliminado As Boolean) As Integer
        '                                 INSERT INTO CabeceraTransacciones ( Id, Tipo, CodOperador, Fecha, Hora, CodCliente, CodProducto, Documento, Placa, CodChofer, Observaciones, NetoM3, MotTraslado, PtoPartida, PtoLlegada, Obra, idMixer, Eliminado )
        Dim con As New OleDb.OleDbConnection(sConnString)
        Dim cmd As OleDb.OleDbCommand
        Try
            cmd = New OleDb.OleDbCommand
            con.Open()
            cmd.Connection = con

            cmd.CommandText = "INSERT INTO CabeceraTransacciones ( Id, Tipo, CodOperador, Fecha, Hora, CodCliente, CodProducto, Documento, CodChofer, Observaciones, NetoM3, MotTraslado, PtoPartida, PtoLlegada, Obra, idMixer, Eliminado )
values ('" & IdTran & "','" & Tipo & "','" & CodOperador & "','" & (Fecha) & "','" & Fecha & " " & Hora & "','" & CodCliente & "','" &
         CodProducto & " ','" & Documento & "','" & CodChofer & "','" & Observaciones & "'," & NetoM3.Trim & ",'" & MotTraslado &
         "','" & PtoPartida & "','" & PtoLlegada & "','" & Obra & "'," & idMixer & "," & IIf(eliminado, 1, 0) & ")"
            'La fecha no tiene conversion en MYSQL, entra YYYY-MM-DD HH:MM:SS

            'MessageBox.Show(cmd.CommandText)
            cmd.ExecuteNonQuery()
            con.Close()
            guardartransaccion = 1
        Catch ex As Exception
            MessageBox.Show("Error al guardar Transacción:" & ex.Message)
            guardartransaccion = 0
        Finally
            con.Close()
        End Try
    End Function


    Public Function actualizartransaccion(ByVal IdTran As String, ByVal CodCliente As String, ByVal CodProducto As String, ByVal Documento As String, ByVal Placa As String, ByVal CodChofer As String, ByVal Observaciones As String, ByVal NetoM3 As String, ByVal MotTraslado As String, ByVal PtoPartida As String, ByVal PtoLlegada As String, ByVal Obra As String, ByVal idMixer As String) As Integer
        '                                 
        Dim con As New OleDb.OleDbConnection(sConnString)
        Dim cmd As OleDb.OleDbCommand
        Try
            cmd = New OleDb.OleDbCommand
            con.Open()
            cmd.Connection = con

            cmd.CommandText = "Update CabeceraTransacciones set CodCliente='" & CodCliente & "',CodProducto='" & CodProducto & "',Documento='" & Documento & "',Placa='" & Placa & "',CodChofer='" & CodChofer & "', Observaciones = '" & Observaciones & "', Netom3 = " &
         NetoM3 & "', MotTraslado = '" & MotTraslado & "', PtoPartida = '" & PtoPartida & "', PtoLlegada = '" & PtoLlegada & "',Obra = '" & Obra & "',idMixer Where Id = '" & IdTran & "'"
            'MYSQL no requiere conversion de fecha
            cmd.ExecuteNonQuery()
            con.Close()
            actualizartransaccion = 1
        Catch ex As Exception
            MessageBox.Show("Error al actualizar Transacción: " & ex.Message)
            actualizartransaccion = 0
        Finally
            con.Close()
        End Try
    End Function

    Public Function leerconsecutivo(ByVal descripcion As String) As Long
        Dim con As New OleDbConnection(sConnString)
        Dim cmd As OleDbCommand
        Try
            cmd = New OleDb.OleDbCommand
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select consecutivo from Consecutivos where Descripcion = '" & descripcion & "'"
            If IsDBNull(cmd.ExecuteScalar) = False Then
                leerconsecutivo = cmd.ExecuteScalar
            Else
                leerconsecutivo = 0
            End If
            con.Close()
        Catch ex As Exception
            leerconsecutivo = 0
        Finally
            con.Close()
        End Try
    End Function

    Public Function guardarconsecutivo(ByVal descripcion As String, ByVal valor As Long) As Integer
        Dim con As New OleDbConnection(sConnString)
        Dim cmd As OleDbCommand
        Try
            cmd = New OleDb.OleDbCommand
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "update Consecutivos set consecutivo = " & valor + 1 & " where Descripcion = '" & descripcion & "'"
            cmd.ExecuteNonQuery()
            con.Close()
            guardarconsecutivo = 1
        Catch ex As Exception
            guardarconsecutivo = 0
        Finally
            con.Close()
        End Try
    End Function

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        tipoLista = "MIXERS"
        destinoLista = "DatosDespacho1"
        'listas.MdiParent = Principal
        listas.Show()
    End Sub
End Class