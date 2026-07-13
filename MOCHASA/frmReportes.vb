Public Class frmReportes

    Private Sub cbfechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbfechas.CheckedChanged
        If cbfechas.Checked = True Then
            Panel2.Enabled = True
        Else
            Panel2.Enabled = False
        End If
    End Sub

    Private Sub cboperador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboperador.CheckedChanged
        If cboperador.Checked = True Then
            txtoperador.Enabled = True
            btnoperador.Enabled = True
        Else
            txtoperador.Enabled = False
            txtoperador.Text = ""
            btnoperador.Enabled = False
        End If
    End Sub

    Private Sub cbproducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbproducto.CheckedChanged
        If cbproducto.Checked = True Then
            txtproducto.Enabled = True
            btnproducto.Enabled = True
            txtNomProducto.Enabled = True
        Else
            txtproducto.Enabled = False
            txtproducto.Text = ""
            txtNomProducto.Text = ""
            btnproducto.Enabled = False
            txtNomProducto.Enabled = False
        End If
    End Sub

    Private Sub cbingrediente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbingrediente.CheckedChanged
        If cbingrediente.Checked = True Then
            txtingrediente.Enabled = True
            btningrediente.Enabled = True
            txtNomIngrediente.Enabled = True
        Else
            txtingrediente.Enabled = False
            txtingrediente.Text = ""
            txtNomIngrediente.Text = ""
            txtNomIngrediente.Enabled = False
            btningrediente.Enabled = False
        End If
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        Me.Close()
    End Sub

    Private Sub Reporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Reporte.Click
        Dim filtrofecha As String = ""
        Dim filtrooperador As String = ""
        Dim filtroingrediente As String = ""
        Dim filtroproducto As String = ""
        'AQ
        Dim filtroOrdenDespacho As String = ""
        Dim filtroMixer As String = ""

        filtrofechasr = "Todas"
        filtrooperadorr = "Todos"
        filtroproductor = "Todos"
        filtroingredienter = "Todos"
        filtroOrdenDespachor = "Todos"
        filtroMixersr = "Todos"
        Variables.NomMixer1 = "Todos"

        NomIngrediente1 = ""
        NomProducto1 = ""
        Dim antes As Integer
        'Dim cadena1 As String = "SELECT distinct * from Transacciones"
        Dim cadena1 As String = "SELECT DISTINCT
                                Tr.Nom_Operador,
                                Tr.Hora,
                                Tr.Fecha,
                                Tr.batch,
                                Tr.Cod_Producto,
                                Tr.Nom_Producto,
                                Tr.Cod_Ingrediente,
                                Tr.Nom_Ingrediente,
                                Tr.Cant_Seteada,
                                Tr.Peso_Real,
                                Tr.Fact_Multi,
                                Tr.Id_Cabecera,
                                CT.idMixer,
                                Mx.NombreMixer
                            FROM
                                (
                                    CabeceraTransacciones AS CT
                                    INNER JOIN Transacciones AS Tr ON CT.id = Tr.Id_Cabecera
                                )
                                INNER JOIN Mixers Mx ON CT.idMixer = Mx.id"

        Dim cadena2 As String


        If cbfechas.Checked Then
            Select Case tipoBD
                Case "ACCESS"
                    filtrofecha = "((Tr.Fecha) Between #" & dtpfedesde.Value.Date & "# And #" & dtpfehasta.Value.Date & "#)"
                    filtrofecha = "((Tr.Fecha) Between # " & dtpfedesde.Value.Date.Month & "/" & dtpfedesde.Value.Date.Day & "/" & dtpfedesde.Value.Date.Year & "# And #" & dtpfehasta.Value.Date.Month & "/" & dtpfehasta.Value.Date.Day & "/" & dtpfehasta.Value.Date.Year & "#)"
                    filtrofechasr = " desde " & dtpfedesde.Value.Date & " hasta " & dtpfehasta.Value.Date
                Case Else
                    'SQLSERVER
                    filtrofecha = String.Format("(Tr.Fecha >= '{0:yyyy-MM-dd}' AND Tr.Fecha < '{1:yyyy-MM-dd}')", dtpfedesde.Value.Date, dtpfehasta.Value.Date.AddDays(1))
                    filtrofechasr = " desde " & dtpfedesde.Value.ToShortDateString() & " hasta " & dtpfehasta.Value.ToShortDateString()
            End Select
        End If
        If cboperador.Checked = True Then
            If Not String.IsNullOrWhiteSpace(txtoperador.Text) Then
                filtrooperador = "((Nom_Operador)='" & txtoperador.Text & "')"
                filtrooperadorr = txtoperador.Text
            End If
        End If
        If cbingrediente.Checked = True Then
            If Not String.IsNullOrWhiteSpace(txtingrediente.Text) Then
                filtroingrediente = "((Cod_Ingrediente)='" & txtingrediente.Text & "')"
                filtroingredienter = txtingrediente.Text
                NomIngrediente1 = txtNomIngrediente.Text
            End If
        End If
        If cbproducto.Checked = True Then
            If Not String.IsNullOrWhiteSpace(txtproducto.Text) Then
                filtroproducto = "((Cod_Producto)='" & txtproducto.Text & "')"
                filtroproductor = txtproducto.Text
                NomProducto1 = txtNomProducto.Text
            End If
        End If
        If cbOrdenDespacho.Checked = True Then
            If Not String.IsNullOrWhiteSpace(txtOrdenDespacho.Text) Then
                filtroOrdenDespacho = "((Id_Cabecera)='" & txtOrdenDespacho.Text & "')"
                filtroOrdenDespachor = txtOrdenDespacho.Text
                'Variables.IdOrdenDespacho = txtOrdenDespacho.Text
            End If
        End If
        If Chbx_Mixer.Checked = True Then
            If Not String.IsNullOrWhiteSpace(txtMixer.Text) Then
                filtroMixer = "((CT.idMixer)=" & Convert.ToInt32(txtMixer.Text) & ")"
                filtroMixersr = txtMixer.Text
                NomMixer1 = Txt_NomMixer.Text
            End If
        End If
        cadena2 = cadena1
        If filtrofecha <> "" Or filtrooperador <> "" Or filtroingrediente <> "" Or filtroproducto <> "" Or filtroOrdenDespacho <> "" Or filtroMixer <> "" Then
            cadena2 = cadena2 & " WHERE "
        End If
        antes = 0
        If filtrofecha <> "" Then
            cadena2 = cadena2 & filtrofecha
            antes = 1
        Else
            antes = 0
        End If
        If filtrooperador <> "" Then
            If antes = 1 Then
                cadena2 = cadena2 & " AND " & filtrooperador
            Else
                cadena2 = cadena2 & filtrooperador
            End If
            antes = 1
        End If
        If filtroingrediente <> "" Then
            If antes = 1 Then
                cadena2 = cadena2 & " AND " & filtroingrediente
            Else
                cadena2 = cadena2 & filtroingrediente
            End If
            antes = 1
        End If
        If filtroproducto <> "" Then
            If antes = 1 Then
                cadena2 = cadena2 & " AND " & filtroproducto
            Else
                cadena2 = cadena2 & filtroproducto
            End If
            antes = 1
        End If
        'AQ
        If filtroOrdenDespacho <> "" Then
            If antes = 1 Then
                cadena2 = cadena2 & " AND " & filtroOrdenDespacho
            Else
                cadena2 = cadena2 & filtroOrdenDespacho
            End If
            antes = 1
        End If
        If filtroMixer <> "" Then
            If antes = 1 Then
                cadena2 = cadena2 & " AND " & filtroMixer
            Else
                cadena2 = cadena2 & filtroMixer
            End If
            antes = 1
        End If

        cadenaseleccion = cadena2
        If rboperador.Checked = True Then
            frmPorOperador.Show()
        ElseIf rbingrediente.Checked = True Then
            frmPoringrediente.Show()
        ElseIf rbproducto.Checked = True Then
            frmPorproducto.Show()
        End If
    End Sub

    Private Sub btnoperador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnoperador.Click
        frmOperadores.Eliminar.Visible = False
        frmOperadores.Guardar.Visible = False
        frmOperadores.Enviar.Visible = False
        frmOperadores.Eliminart.Visible = False
        frmOperadores.Importar.Visible = False
        frmOperadores.Show()
    End Sub

    Private Sub btnproducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnproducto.Click
        frmProductos.Eliminar.Visible = False
        frmProductos.Guardar.Visible = False
        frmProductos.Enviar.Visible = False
        frmProductos.Eliminart.Visible = False
        frmProductos.Importar.Visible = False
        frmProductos.Show()
    End Sub

    Private Sub btningrediente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btningrediente.Click
        frmIngredientes.Eliminar.Visible = False
        frmIngredientes.Guardar.Visible = False
        frmIngredientes.Enviar.Visible = False
        frmIngredientes.Eliminart.Visible = False
        frmIngredientes.Importar.Visible = False
        frmIngredientes.Show()
    End Sub


    Private Sub cbOrdenDespacho_CheckedChanged(sender As Object, e As EventArgs) Handles cbOrdenDespacho.CheckedChanged
        If cbOrdenDespacho.Checked = True Then
            txtOrdenDespacho.Enabled = True
            btnOrdenDespacho.Enabled = True
            Btt_PrintOD.Enabled = True
        Else
            txtOrdenDespacho.Enabled = False
            txtOrdenDespacho.Text = ""
            btnOrdenDespacho.Enabled = False
            Btt_PrintOD.Enabled = False
        End If
    End Sub

    Private Sub btnOrdenDespacho_Click(sender As Object, e As EventArgs) Handles btnOrdenDespacho.Click
        tipoLista = "ORDEN_DESPACHO"
        destinoLista = "FReportesOrdenDespacho"
        'listas.MdiParent = Principal
        listas.Show()
    End Sub

    Private Sub Btt_PrintOD_Click(sender As Object, e As EventArgs) Handles Btt_PrintOD.Click
        If txtOrdenDespacho.Text IsNot String.Empty Then
            idDespacho = txtOrdenDespacho.Text
            Despacho_frm.Show()
        End If
    End Sub

    Private Sub Btt_Mixer_Click(sender As Object, e As EventArgs) Handles Btt_Mixer.Click
        tipoLista = "MIXERS"
        destinoLista = "FReportesMixers"

        'listas.MdiParent = Principal
        listas.Show()
    End Sub

    Private Sub Chbx_Mixer_CheckedChanged(sender As Object, e As EventArgs) Handles Chbx_Mixer.CheckedChanged
        If Chbx_Mixer.Checked = True Then
            txtMixer.Enabled = True
            Txt_NomMixer.Enabled = True
            Btt_Mixer.Enabled = True
        Else
            txtMixer.Enabled = False
            txtMixer.Text = ""
            Txt_NomMixer.Enabled = False
            Txt_NomMixer.Text = ""
            Btt_Mixer.Enabled = False
        End If
    End Sub
End Class