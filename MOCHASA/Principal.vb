Imports SocketTools.InternetServer

Public Class Principal
    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.EnableVisualStyles()
        Control.CheckForIllegalCrossThreadCalls = False


        '700%sMAEST%e             P700.    DBNam MAEST
        '701%s80.5%e              P701.80  Col01 nomoperador
        '702%s80.1%e              P702.80  Col02 Hora
        '703%s80.3%e              P703.80  Col03 Fecha
        '704%s80.15%e             P704.80  Col04 batch
        '705%s80.8%e              P705.80  Col05 coproducto
        '706%s80.9%e              P706.80  Col06 nomproducto
        '707%s80.6%e              P707.80  Col07 codingrediente
        '708%s80.7%e              P708.80  Col08 nomingrediente
        '709%s80.11%e             P709.80  Col09 cantseteada
        '710%s80.4%e              P710.80  Col10 Peso real
        '711%s80.60%e             P711.80  Col11 Factor de multiplicacion

    End Sub
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Application.Exit()
    End Sub

    Private Sub btnEIngredientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEIngredientes.Click
        ' frmIngredientes.Show()
        If Funciones.IsFormOpen("frmFormulas") Then
            MessageBox.Show("Otro formulario está abierto, por favor cierre para iniciar otra ventana.")
            Exit Sub
        End If
        If Funciones.IsFormOpen("frmObtenerDatos") Then
            MessageBox.Show("Otro formulario está abierto, por favor cierre para iniciar otra ventana.")
            Exit Sub
        End If
        If Funciones.IsFormOpen("frmOperadores") Then
            MessageBox.Show("Otro formulario está abierto, por favor cierre para iniciar otra ventana.")
            Exit Sub
        End If
        If Funciones.IsFormOpen("frmProductos") Then
            MessageBox.Show("Otro formulario está abierto, por favor cierre para iniciar otra ventana.")
            Exit Sub
        End If
        frmIngredientes.TopLevel = False
        Panel2.Controls.Add(frmIngredientes)
        frmIngredientes.Show()
    End Sub

    Private Sub btnEOperadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEOperadores.Click
        If tipoOperador.Equals("Administrador") Then
            frmOperadores.TopLevel = False
            Panel2.Controls.Add(frmOperadores)
            frmOperadores.Show()
        Else
            MessageBox.Show("No tiene autorización para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btnEProductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEProductos.Click
        frmProductos.TopLevel = False
        Panel2.Controls.Add(frmProductos)
        frmProductos.Show()
    End Sub

    Private Sub btnformulas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnformulas.Click
        Try

            frmFormulas.TopLevel = False
            Panel2.Controls.Add(frmFormulas)
            frmFormulas.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Application.Exit()
    End Sub



    Private Sub btnReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportes.Click
        frmReportes.TopLevel = False
        Panel2.Controls.Add(frmReportes)
        frmReportes.Show()
    End Sub

    Private Sub btnobtener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnobtener.Click
        Proceso.TopLevel = False
        Panel2.Controls.Add(Proceso)
        Proceso.Show()
        'frmObtenerDatos.TopLevel = False
        'Panel2.Controls.Add(frmObtenerDatos)
        'frmObtenerDatos.Show()
    End Sub

    Private Sub btt_Con_Indicador_Click(sender As Object, e As EventArgs) Handles btt_Con_Indicador.Click
        frmConfiguracion.TopLevel = False
        Panel2.Controls.Add(frmConfiguracion)
        frmConfiguracion.Show()
    End Sub

    Private Sub Tmr_LeeCamara_Tick(sender As Object, e As EventArgs) Handles Tmr_LeeCamara.Tick
        'LeeCamara(clientSocketCamara, Txt_EstadoCon, Txt_Mensj_Sistema)
    End Sub

    Private Sub Tmr_timeoutConn_Tick(sender As Object, e As EventArgs) Handles Tmr_timeoutConn.Tick
        Tmr_timeoutConn.Enabled = False
        clientSocketCamara.Disconnect()
        MsgBox("No se puede establecer conexión con el servidor", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Clientes.TopLevel = False
        Panel2.Controls.Add(Clientes)
        Clientes.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Choferes.TopLevel = False
        Panel2.Controls.Add(Choferes)
        Choferes.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Mixers.TopLevel = False
        Panel2.Controls.Add(Mixers)
        Mixers.Show()
    End Sub
End Class
