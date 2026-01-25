Public Class frmConexion
    Private Sub Btt_Conectar_Click(sender As Object, e As EventArgs) Handles Btt_Conectar.Click
        Try
            Dim ipAddress As String
            Dim puerto As Integer
            ipAddress = Txt_IpAdd.Text
            puerto = Convert.ToInt32(Txt_Puerto.Text)

            If ipAddress <> String.Empty And (puerto > 0 And puerto < 65535) Then
                Funciones.Conectar_Indicador(ipAddress, puerto)
                Principal.Lbl_IpAdd.Text = Txt_IpAdd.Text
                Principal.Lbl_Puerto.Text = Txt_Puerto.Text
            Else
                MsgBox("Parámetros de conexión incorrectos", MsgBoxStyle.Critical)
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox("Exepción: " & ex.Message)
        End Try
    End Sub

    Private Sub Btt_Cancelar_Click(sender As Object, e As EventArgs) Handles Btt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub frmConexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Txt_IpAdd.Text = Principal.Lbl_IpAdd.Text
        Txt_Puerto.Text = Principal.Lbl_Puerto.Text
    End Sub
End Class