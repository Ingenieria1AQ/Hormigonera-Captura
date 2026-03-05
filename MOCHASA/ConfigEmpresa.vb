Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Public Class ConfigEmpresa


    Private Sub ConfigEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar_Config()
    End Sub
    Private Sub Cargar_Config()
        Try
            Using connection As New OleDbConnection(sConnString)
                Using cmd As New OleDbCommand
                    cmd.Connection = connection
                    cmd.CommandText = "SELECT * FROM Empresa"

                    Dim tabla As New DataTable
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(tabla)
                    End Using
                    If tabla.Rows.Count > 0 Then
                        Dim fila As DataRow = tabla.Rows(0)
                        ' Logo
                        If Not IsDBNull(fila("LogoEmpresa")) Then
                            Dim imageBytes As Byte() = CType(fila("LogoEmpresa"), Byte())
                            Using ms As New MemoryStream(imageBytes)
                                PBox_LogoInicio.Image = Image.FromStream(ms)
                            End Using
                        Else
                            PBox_LogoInicio.Image = Nothing
                        End If
                        'Datos empresa
                        Txt_NombreEmpresa.Text = If(IsDBNull(fila("NombreEmpresa")), "", fila("NombreEmpresa"))
                        Txt_RUC.Text = If(IsDBNull(fila("RUC")), "", fila("RUC"))

                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción: Cargar Configuracion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Btt_Salir_Click(sender As Object, e As EventArgs) Handles Btt_Salir.Click
        Me.Close()
    End Sub

    Private Sub Btt_Examinar_Click(sender As Object, e As EventArgs) Handles Btt_Examinar.Click
        Try
            OpenFileDialog1.Filter = "Logotipo|*.jpg;*.png;*.jpeg"
            OpenFileDialog1.Title = "Seleccione un logotipo"
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                PBox_LogoInicio.Image = Image.FromFile(OpenFileDialog1.FileName)
                Txt_Ruta.Text = OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btt_Guardar_Click(sender As Object, e As EventArgs) Handles Btt_Guardar.Click
        Try
            Dim con As New OleDbConnection(sConnString)
            Dim cmd As New OleDbCommand
            cmd.Connection = con
            con.Open()
            Dim ms As New MemoryStream()
            PBox_LogoInicio.Image.Save(ms, PBox_LogoInicio.Image.RawFormat)
            Dim imageBytes() As Byte = ms.ToArray()
            cmd.CommandText = "UPDATE Empresa SET logoEmpresa= ?, NombreEmpresa = ?, RUC =? WHERE Id =1"
            cmd.Parameters.AddWithValue("?", imageBytes)
            cmd.Parameters.AddWithValue("?", Txt_NombreEmpresa.Text)
            cmd.Parameters.AddWithValue("?", Txt_RUC.Text)

            If cmd.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Registro correcto", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class