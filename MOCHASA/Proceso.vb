Imports System.Data
Imports System.Data.OleDb
Imports System.IO.Ports

Public Class Proceso
    Private da As OleDbDataAdapter
    Private ds As New DataSet
    Private registros As Integer = 5
    Private tbTolvas As New DataTable
    Private font_Rtxt As System.Drawing.Font = New System.Drawing.Font("MicrosoftSansSerif", 8)


    '*-*-Variables para manejo del proceso-*-*-*-*-
    Private running As Boolean = False
    Private preparado As Boolean = False
    Private peso As Double = 0.0
    Private codIng As String
    Private nomIng As String
    Private codProd As String
    Private nomProd As String
    Private valor As Double
    Private pesoSet As Double
    Private pesoReal As Double
    Private diferencia As Double
    Private pesoSet1, pesoSet2, pesoSet3, pesoSet4, pesoSet5 As Double
    Private pesoReal1, pesoReal2, pesoReal3, pesoReal4, pesoReal5 As Double
    Private batchPlanificacion, batchActual, batchPendientes As Integer
    Private corteT1, corteT2, corteCemento, corteAgua As Double

    Private flagFinCemento As Boolean = False
    Private flagFinAridos As Boolean = False
    Private flagFinAgua As Boolean = False
    Private flagFinParcial As Boolean = False
    Private flagSoltarProducto As Boolean = False

    Private flagEnviadoParcialCemento As Boolean = False
    Private flagEnviadoParcialAgua As Boolean = False

    Private SerTol1_ok, SerTol2_ok, SerCemento_ok As Boolean


    '*-*-*-*-**-*-*-*-*-*-*-*
    Private Sub Proceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarInfoTolvas()
        CargaProductos()
        LimpiarLabelsFormula()
        Config_Serial_Tolvas()
    End Sub


    Private Sub CargarInfoTolvas()
        Try
            'Se extrae la configuracion de Tolvas 
            Dim cmdTxt As String = "SELECT * FROM NumeroTolvasTanques ORDER BY ID"
            Dim da1 As New OleDbDataAdapter(cmdTxt, sConnString)
            Dim ds1 As New DataSet

            da1.Fill(ds1)
            'Se llena la tabla del número de tolvas
            da1.Fill(tbTolvas)
            If tbTolvas IsNot Nothing And tbTolvas.Rows.Count = 4 Then
            Else
                MessageBox.Show("Configuracion de Tolvas no es correcta " & vbCrLf & "Consulte a su administrador", "Excepcion Carga Info Tolvas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepcion Carga Info Tolvas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CargaProductos()
        Try

            Dim CmdTxt As String
            'Cargamos datos de productos
            CmdTxt = "SELECT * FROM Productos ORDER BY Id_Producto"
            Dim objda As New OleDbDataAdapter(CmdTxt, sConnString)
            Dim objds_p As New DataSet()
            'Pasamos las columnas que deseamos al dataset
            objda.Fill(objds_p, "Id_Producto")
            objda.Fill(objds_p, "Descripcion")
            If objds_p.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("No existen datos de Productos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
            For i As Integer = 0 To objds_p.Tables(0).Rows.Count - 1
                objds_p.Tables(0).Rows(i).Item(1) = objds_p.Tables(0).Rows(i).Item(0) & ", " & objds_p.Tables(0).Rows(i).Item(1)
            Next

            'Finalmente pasmos al comboBox, hasta aqui nada del otro mundo
            Me.cmbproductos.DataSource = objds_p.Tables(0).DefaultView
            Me.cmbproductos.DisplayMember = "Descripcion"
            Me.cmbproductos.ValueMember = "Id_Producto"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepcion Carga Inicial", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LimpiarLabelsFormula()
        Try
            For i As Integer = 1 To registros
                Dim lblTolva As Label = BuscarLabel("Lbl_Tolv" & i)
                Dim lblIng As Label = BuscarLabel("Lbl_Ing" & i)
                Dim lblCanTeo As Label = BuscarLabel("Lbl_CanTeo" & i)
                Dim lblCanRea As Label = BuscarLabel("Lbl_CanRea" & i)
                Dim lblDifer As Label = BuscarLabel("Lbl_Dif" & i)
                Dim PgBar As ProgressBar = BuscarPgBar("Pb_Tol" & i)

                If lblTolva IsNot Nothing Then
                    lblTolva.Text = ""
                    lblTolva.visible = True
                End If
                If lblIng IsNot Nothing Then
                    lblIng.Text = ""
                    lblIng.visible = True
                End If
                If lblCanTeo IsNot Nothing Then
                    lblCanTeo.Text = ""
                    lblCanTeo.visible = True
                End If
                If lblCanRea IsNot Nothing Then
                    lblCanRea.Text = ""
                    lblCanRea.visible = True
                End If
                If lblDifer IsNot Nothing Then
                    lblDifer.Text = ""
                    lblDifer.visible = True
                End If
                If PgBar IsNot Nothing Then
                    PgBar.Visible = False
                    PgBar.Value = 0
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ObtieneFormulaxProducto(idProducto As String)
        Dim dt As New DataTable
        Try

            Using conection As New OleDbConnection(sConnString)
                Using cmdd As New OleDbCommand
                    cmdd.Connection = conection
                    cmdd.CommandText = "SELECT 
                                          DF.Num_Tolva AS [Num Tolva], 
                                          NT.descripcion AS [Tolva],
                                          DF.Id_ingrediente AS [Id Ingrediente], 
                                          ING.Descripcion AS [Ingrediente],
                                          DF.Cantidad, 
                                          DF.Id_formula
                                        FROM (DetalleFormulas AS DF 
                                        INNER JOIN NumeroTolvasTanques AS NT 
                                             ON  DF.Num_Tolva= NT.id) 
                                        INNER JOIN Ingredientes AS ING 
                                             ON   DF.Id_ingrediente= ING.Id_ingrediente
                                        WHERE Id_formula = ?
                                        ORDER BY DF.Num_Tolva ASC"
                    cmdd.Parameters.AddWithValue("?", idProducto)
                    Using da As New OleDbDataAdapter(cmdd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using

            'Limpiar todos los Labels
            LimpiarLabelsFormula()

            'Llenar los Labels
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim idx As Integer = i + 1
                Dim lblTolva As Label = BuscarLabel("Lbl_Tolv" & idx)
                Dim lblIng As Label = BuscarLabel("Lbl_Ing" & idx)
                Dim lblCanTeo As Label = BuscarLabel("Lbl_CanTeo" & idx)
                Dim lblCanReal As Label = BuscarLabel("Lbl_CanRea" & idx)
                Dim lblDifer As Label = BuscarLabel("Lbl_Dif" & idx)
                Dim PgBar As ProgressBar = BuscarPgBar("Pb_Tol" & idx)

                If lblTolva Is Nothing Then Continue For

                lblTolva.Text = dt.Rows(i).Item("Tolva").ToString()
                lblIng.Text = dt.Rows(i).Item("Ingrediente").ToString()
                lblCanTeo.Text = dt.Rows(i).Item("Cantidad").ToString()
                lblCanReal.Text = "0"
                lblDifer.Text = "0"
                PgBar.Visible = True
                PgBar.Value = 0
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function BuscarLabel(nombre As String) As Label

        Return BuscarLabelEnControles(Me.Controls, nombre)

    End Function
    Private Function BuscarLabelEnControles(controles As Control.ControlCollection, nombre As String) As Label

        For Each ctrl As Control In controles
            If TypeOf ctrl Is Label AndAlso ctrl.Name = nombre Then
                Return CType(ctrl, Label)
            End If

            If ctrl.HasChildren Then
                Dim encontrado = BuscarLabelEnControles(ctrl.Controls, nombre)
                If encontrado IsNot Nothing Then Return encontrado
            End If
        Next

        Return Nothing

    End Function

    Private Function BuscarPgBar(nombre As String) As ProgressBar
        Return BuscarPgBarEnControles(Me.Controls, nombre)
    End Function
    Private Function BuscarPgBarEnControles(controles As Control.ControlCollection, nombre As String) As ProgressBar

        For Each ctrl As Control In controles
            If TypeOf ctrl Is ProgressBar AndAlso ctrl.Name = nombre Then
                Return CType(ctrl, ProgressBar)
            End If

            If ctrl.HasChildren Then
                Dim encontrado = BuscarPgBarEnControles(ctrl.Controls, nombre)
                If encontrado IsNot Nothing Then Return encontrado
            End If
        Next
        Return Nothing
    End Function


    Private Sub cmbproductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbproductos.SelectedIndexChanged
        If cmbproductos.SelectedIndex > -1 Then
            ObtieneFormulaxProducto(cmbproductos.SelectedValue.ToString)
        End If
    End Sub

    Private Sub Config_Serial_Tolvas()
        Try
            SerTol1_ok = Funciones.AbrirPuertoSerial(SerialTolva1, tbTolvas.Rows(0))
            SerTol2_ok = Funciones.AbrirPuertoSerial(SerialTolva2, tbTolvas.Rows(1))
            SerCemento_ok = Funciones.AbrirPuertoSerial(SerialCemento, tbTolvas.Rows(2))

            If SerTol1_ok AndAlso SerTol2_ok AndAlso SerCemento_ok Then
                Rtx_Mensajes.AppendColoredText(
                    "Configuración serial de tolvas correcta" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
            Else
                MessageBox.Show(
                    "Configuración Serial de Tolvas no es correcta" & vbCrLf &
                    "Consulte a su administrador",
                    "Excepción Config Serial Tolvas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(
                ex.Message,
                "Excepción: Configuración Serial Tolvas",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End Try

    End Sub
End Class