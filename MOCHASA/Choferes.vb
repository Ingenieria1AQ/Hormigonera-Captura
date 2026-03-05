Imports System.Data
Imports System.Data.OleDb
Public Class Choferes
    Dim codigo As Long
    Dim opcion As Integer
    Private Sub Clientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call cargargrid()
        TabControl1.TabPages(1).Enabled = False
    End Sub

    Private Sub btnagregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnagregar.Click
        opcion = 1
        TabControl1.SelectedTab = tab2
        TabControl1.TabPages(1).Enabled = True
        txtcodigo.Text = ""
        txtnombre.Text = ""
        txtcedula.Text = ""
        'codigo = leerconsecutivo("Chofer")
        'If codigo <> 0 Then
        ' txtcodigo.Text = CStr(codigo) '.PadLeft(3, "0")
        ' End If
    End Sub
    Private Sub cargargrid()
        Dim con As New OleDbConnection(sConnString)
        Dim da As New OleDbDataAdapter("SELECT * FROM Choferes", con)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(2).Visible = False
        DataGridView1.AutoResizeColumns()
    End Sub

    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        If txtnombre.Text <> "" And txtcedula.Text <> "" Then
            Dim con As New OleDbConnection(sConnString)
            Dim cmd As New OleDbCommand
            Dim resp As Integer
            resp = 1
            Try
                cmd.Connection = con
                con.Open()
                If opcion = 1 Then
                    'resp = guardarconsecutivo("Chofer", codigo)
                    Select Case Variables.tipoBD
                        Case "ACCESS"
                            cmd.CommandText = "insert into Choferes (Nombre, Cedula, ChoferEmpresa, Habilitado) values('" & txtnombre.Text & "','" & txtcedula.Text & "'," & cbChoferEmpresa.Checked & "," & cbHabilitado.Checked & ")"
                        Case "SQLSERVER"
                            cmd.CommandText = "insert into Choferes values('" & txtnombre.Text & "','" & txtcedula.Text & "'," & IIf(cbChoferEmpresa.Checked, 1, 0) & "," & IIf(cbHabilitado.Checked, 1, 0) & ")"
                    End Select
                ElseIf opcion = 2 Then
                    Select Case Variables.tipoBD
                        Case "ACCESS"
                            cmd.CommandText = "update Choferes set Nombre = '" & txtnombre.Text & "', Cedula = '" & txtcedula.Text & "', ChoferEmpresa =" & cbChoferEmpresa.Checked & ", Habilitado =" & cbHabilitado.Checked & "" &
                                       " Where CodChofer = '" & txtcodigo.Text & "'"
                        Case "SQLSERVER"
                            cmd.CommandText = "update Choferes set Nombre = '" & txtnombre.Text & "', Cedula = '" & txtcedula.Text & "', ChoferEmpresa =" & IIf(cbChoferEmpresa.Checked, 1, 0) & ", Habilitado =" & IIf(cbHabilitado.Checked, 1, 0) & "" &
                                  " Where CodChofer = '" & txtcodigo.Text & "'"
                    End Select

                End If
                If resp = 1 Then
                    cmd.ExecuteNonQuery()
                    'If mostrarmensajes = True Then
                    MessageBox.Show("Los datos se han ingresado correctamente")
                Else
                    MessageBox.Show("No se grabó por problemas al guardar el consecutivo")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                con.Close()
            End Try
            TabControl1.SelectedTab = tab1
            TabControl1.TabPages(1).Enabled = False
        Else
            MessageBox.Show("Ingrese los datos correctamente")
        End If
        Call Me.cargargrid()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        opcion = 2
        TabControl1.SelectedTab = tab2
        TabControl1.TabPages(1).Enabled = True
        Dim cod As String
        cod = DataGridView1.SelectedCells(0).RowIndex
        If IsDBNull(DataGridView1.Rows(cod).Cells(0).Value) = False Then txtcodigo.Text = DataGridView1.Rows(cod).Cells(0).Value
        If IsDBNull(DataGridView1.Rows(cod).Cells(1).Value) = False Then txtnombre.Text = DataGridView1.Rows(cod).Cells(1).Value
        If IsDBNull(DataGridView1.Rows(cod).Cells(2).Value) = False Then txtcedula.Text = DataGridView1.Rows(cod).Cells(2).Value
        If IsDBNull(DataGridView1.Rows(cod).Cells(3).Value) = False Then cbChoferEmpresa.Checked = DataGridView1.Rows(cod).Cells(3).Value
        If IsDBNull(DataGridView1.Rows(cod).Cells(4).Value) = False Then cbHabilitado.Checked = DataGridView1.Rows(cod).Cells(4).Value
    End Sub

    Private Sub tab1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab1.Enter
        TabControl1.TabPages(1).Enabled = False
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click
        'ChoferesFRM.Show()
    End Sub
End Class