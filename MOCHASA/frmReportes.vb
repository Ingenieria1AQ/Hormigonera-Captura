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
        filtrofechasr = "Todas"
        filtrooperadorr = "Todos"
        filtroproductor = "Todos"
        filtroingredienter = "Todos"
        NomIngrediente1 = ""
        NomProducto1 = ""
        Dim antes As Integer
        Dim cadena1 As String = "SELECT distinct * from Transacciones"
        Dim cadena2 As String
        If cbfechas.Checked = True Then
            ' filtrofecha = "((Fecha) Between #" & dtpfedesde.Value.Date & "# And #" & dtpfehasta.Value.Date & "#)"
            filtrofecha = "((Fecha) Between #" & dtpfedesde.Value.Date.Month & "/" & dtpfedesde.Value.Date.Day & "/" & dtpfedesde.Value.Date.Year & "# And #" & dtpfehasta.Value.Date.Month & "/" & dtpfehasta.Value.Date.Day & "/" & dtpfehasta.Value.Date.Year & "#)"
            filtrofechasr = " desde " & dtpfedesde.Value.Date & " hasta " & dtpfehasta.Value.Date
        End If
        If cboperador.Checked = True Then
            filtrooperador = "((Nom_Operador)='" & txtoperador.Text & "')"
            filtrooperadorr = txtoperador.Text
        End If
        If cbingrediente.Checked = True Then
            filtroingrediente = "((Cod_Ingrediente)='" & txtingrediente.Text & "')"
            filtroingredienter = txtingrediente.Text
            NomIngrediente1 = txtNomIngrediente.Text
        End If
        If cbproducto.Checked = True Then
            filtroproducto = "((Cod_Producto)='" & txtproducto.Text & "')"
            filtroproductor = txtproducto.Text
            NomProducto1 = txtNomProducto.Text
        End If
        cadena2 = cadena1
        If filtrofecha <> "" Or filtrooperador <> "" Or filtroingrediente <> "" Or filtroproducto <> "" Then
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

    Private Sub frmReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class