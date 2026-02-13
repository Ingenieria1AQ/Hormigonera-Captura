Imports System.Data
Imports System.Data.OleDb
Public Class Mixers
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
        txtPlaca.Text = ""
        txtNombreMixer.Text = ""

        'If ClienteProveedor = "Cliente" Then
        '    codigo = leerconsecutivo("Cliente")
        'Else
        '    codigo = leerconsecutivo("Proveedor")
        'End If
        If codigo <> 0 Then
            txtcodigo.Text = CStr(codigo) '.PadLeft(3, "0")
        End If
    End Sub
    Private Sub cargargrid()
        Dim con As New OleDbConnection(sConnString)
        Dim da As New OleDbDataAdapter("SELECT * FROM Mixers", con)
        Dim ds As New DataSet
        da.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        'DataGridView1.Columns(2).Visible = False
        'DataGridView1.Columns(3).Visible = False
        DataGridView1.AutoResizeColumns()
    End Sub


    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        If txtPlaca.Text <> "" And txtNombreMixer.Text <> "" Then
            Dim con As New OleDbConnection(sConnString)
            Dim cmd As New OleDbCommand
            Dim resp As Integer
            resp = 1
            Try
                cmd.Connection = con
                con.Open()
                If opcion = 1 Then

                    cmd.CommandText = "insert into Mixers (Placa,NombreMixer) values('" & txtPlaca.Text & "','" & txtNombreMixer.Text & "')"

                ElseIf opcion = 2 Then

                    cmd.CommandText = "update Mixers set Placa = '" & txtPlaca.Text & "', NombreMixer = '" &
                                   txtNombreMixer.Text & "'" &
                                   " Where id = '" & txtcodigo.Text & "'"

                End If
                If resp = 1 Then
                    cmd.ExecuteNonQuery()
                    'If mostrarmensajes = True Then
                    MessageBox.Show("Los datos se han ingresado correctamente")
                    'End If
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
        If IsDBNull(DataGridView1.Rows(cod).Cells(1).Value) = False Then txtPlaca.Text = DataGridView1.Rows(cod).Cells(1).Value
        If IsDBNull(DataGridView1.Rows(cod).Cells(2).Value) = False Then txtNombreMixer.Text = DataGridView1.Rows(cod).Cells(2).Value

    End Sub

    Private Sub tab1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tab1.Enter
        TabControl1.TabPages(1).Enabled = False
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReporte.Click

        'ClientesFRM.Show()

    End Sub
End Class