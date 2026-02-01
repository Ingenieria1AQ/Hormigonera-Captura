Imports System.Data
Imports System.Data.OleDb
Imports System.Net.Sockets
Imports SocketTools.SocketWrench.ErrorCode

Public Class frmIngredientes
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Private bindingSource1 As New BindingSource()
    Private AdaptadorDeDatos As New OleDb.OleDbDataAdapter

    Private Sub frmIngredientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call cargaringredientes()
        DataGridView1.AutoResizeColumns()
    End Sub

    Private Sub Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eliminar.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                Me.DataGridView1.Rows.Remove(Me.DataGridView1.CurrentRow)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cargaringredientes()
        'Dim oOleDbConnection As OleDb.OleDbConnection

        'oOleDbConnection = New OleDb.OleDbConnection(sConnString)
        'oOleDbConnection.Open()
        'da = New OleDbDataAdapter("SELECT * FROM Operadores", oOleDbConnection)
        'da.Fill(ds)
        'DataGridView1.DataSource = ds.Tables(0)
        Try
            ' Especificar un 'connection string' valido
            ' En este caso origen de la carpeta de la aplicacion BD1.mdb
            Dim cmdtxt As String = "SELECT * FROM Ingredientes order by id_ingrediente"
            ' Crear un nuevo adaptador de datos vasado en el 'query' especificado
            Me.AdaptadorDeDatos = New OleDb.OleDbDataAdapter(cmdtxt, sConnString)
            Me.DataGridView1.DataSource = Me.bindingSource1
            ' Crear un 'commandbuilder' que genere el SQL Update/Insert/Delete
            ' segun el 'selectcommand', usado para actualizar la BD
            Dim commandbuilder As New OleDb.OleDbCommandBuilder(Me.AdaptadorDeDatos)

            ' Llenar la tabla con los datos y enlazarza con el 'bindingsource'
            Dim tabla As New DataTable()
            Me.AdaptadorDeDatos.Fill(tabla)
            Me.bindingSource1.DataSource = tabla
            'Cambiar titulo de columnas
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns(0).HeaderText = "Código Ingrediente"
                DataGridView1.Columns(1).HeaderText = "Descripción"
            End If
            ' Dimensionar las columnas del DataGrid para ajustalarlas al contenido cargado
            'Me.DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)
        Catch ex As Exception
            MessageBox.Show("Excepcion al leer los datos:" & ex.Message)
        End Try
    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click
        Call actualizardatos()
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        Dim respuesta As Integer
        respuesta = MsgBox("Desea guardar los cambios antes de salir?", MsgBoxStyle.YesNo)
        If respuesta = 6 Then
            Call actualizardatos()
        End If
        Me.Close()
    End Sub

    Private Sub actualizardatos()
        Try
            Me.AdaptadorDeDatos.Update(CType(Me.bindingSource1.DataSource, DataTable))
        Catch ex As Exception
            MsgBox("Error al actualizar " & ex.Message)
        End Try
    End Sub

    Private Sub Enviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Enviar.Click
        Dim i, j As Integer
        SerialPort1.Open()
        SerialPort1.Write("10,3%y")
        SerialPort1.Write("16,3;1%y")
        For j = 1 To retardo * 2
        Next
        For i = 0 To DataGridView1.Rows.Count - 2
            Dim a As String = DataGridView1.Rows(i).Cells(0).Value & "," & DataGridView1.Rows(i).Cells(1).Value & vbCrLf
            SerialPort1.Write(a)
            For j = 1 To retardo
            Next
        Next
        SerialPort1.Write("ENDofDB" + vbCrLf + vbCrLf)
      SerialPort1.Close()
      MessageBox.Show("Proceso Finalizado")
    End Sub

    Private Sub seleccionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles seleccionar.Click
        frmReportes.txtingrediente.Text = DataGridView1.CurrentRow.Cells(0).Value
        frmReportes.txtNomIngrediente.Text = DataGridView1.CurrentRow.Cells(1).Value
        Me.Close()
    End Sub

    Private Sub Importar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Importar.Click
        Dim oOleDbConnection As OleDb.OleDbConnection
        Dim sFileReader As IO.StreamReader
        Dim filename As String
        Dim linea As String
        Dim cmd As OleDbCommand
        Dim numlinea As Integer
        Dim respuesta As Integer
        respuesta = MsgBox("desea actualizar los datos antes de importar?", MsgBoxStyle.YesNo)
        If respuesta = 6 Then
            Call actualizardatos()
        End If
        OFD.Multiselect = False
        ' OFD.ShowDialog()
        If OFD.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        Else
            filename = OFD.FileName
        End If
        Me.Cursor = Cursors.WaitCursor
        Try
            sFileReader = IO.File.OpenText(filename)
            If sFileReader.Peek = -1 Then
                sFileReader.Close()
                MsgBox("No hay datos validos", MsgBoxStyle.Exclamation, "::CM CONSTRUCCIONES::")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error al leer el Archivo :" & ex.Message, MsgBoxStyle.Exclamation, "::CM CONSTRUCCIONES::")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        Try
            oOleDbConnection = New OleDb.OleDbConnection(sConnString)
            oOleDbConnection.Open()

        Catch ex As Exception
            MsgBox(ex.Message, "::CM CONSTRUCCIONES::")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try
        numlinea = 0
        Do While Not sFileReader.Peek = -1
            numlinea = numlinea + 1
            linea = sFileReader.ReadLine
            Dim a As Integer
            a = sFileReader.Peek
            Try
                Dim datos() As String
                linea = Replace(linea, Chr(34), "")
                datos = linea.Split(",")
                'datos = Replace(datos, Chr(34), "")

                If datos.Length >= 2 Then
                    If datos(0).Length <> 0 And datos(1).Length <> 0 Then
                        cmd = New OleDbCommand("insert into Ingredientes values('" & datos(0) & "','" & datos(1) & "')", oOleDbConnection)
                        cmd.ExecuteNonQuery()
                    Else
                        MsgBox("Error en datos, en la linea : " & numlinea & " del archivo " & filename)
                    End If
                Else
                    MsgBox("Error en datos, en la linea : " & numlinea & " del archivo " & filename)
                End If

            Catch ex As Exception
                MsgBox(ex.Message & " en la linea: " & numlinea & " del archivo " & filename)
            End Try
        Loop
        System.Threading.Thread.Sleep(100)
        sFileReader.Close()
        Me.Cursor = Cursors.Default
        Call cargaringredientes()
        oOleDbConnection.Close()
    End Sub

    Private Sub Eliminart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eliminart.Click
        Dim i As Integer
        For i = 0 To DataGridView1.Rows.Count - 2
            Me.DataGridView1.Rows.Remove(DataGridView1.Rows(0))
        Next
    End Sub

    Private Sub Btt_EnviarZM_Click(sender As Object, e As EventArgs) Handles Btt_EnviarZM.Click
        Txt_Estado.Text = vbCrLf & Txt_Estado.Text
        'Enviar Caracter para borrar la tabla de ingredientes en el Controlador
        Funciones.enviaDatosSocket("i" & vbCrLf, Txt_Estado)
        Dim strBuffer As String = ""
        Dim cchBuffer As Integer = 0
        For x As Integer = 0 To 80
            System.Threading.Thread.Sleep(50)
            Do
                strBuffer = ""
                cchBuffer = clientSocketCamara.Read(strBuffer, 4096)
                If cchBuffer > 0 Then
                    Funciones.ProcesaDato(strBuffer, Txt_Estado)
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
            If x >= 79 Then
                Txt_Estado.Text = "No hay respuesta del Controlador" & vbCrLf & Txt_Estado.Text
                Exit Sub
            End If
        Next
        Application.DoEvents()
        Funciones.enviarArchivo("Ingredientes", Btt_EnviarZM, Txt_Estado)
    End Sub
End Class