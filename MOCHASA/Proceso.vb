Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports System.IO.Ports

Public Class Proceso
    Private da As OleDbDataAdapter
    Private ds As New DataSet
    Private numTolvas_Serial As Integer = 3
    Private registros As Integer = 4  'Numero total de registros de la tabla NumeroTolvasTanques
    Private tbTolvas As New DataTable
    Private font_Rtxt As System.Drawing.Font = New System.Drawing.Font("MicrosoftSansSerif", 8)

    '*-*-*- Variables manejo de PLC - *-* -* -**
    Private PLC_LOGO As EasyModbus.ModbusClient
    Private Block_lectura_HR() As Integer
    Private Block_lectura_Coils() As Boolean

    '*-*-Variables para manejo del proceso-*-*-*-*-
    Private running As Boolean = False
    Private preparado As Boolean = False
    Private peso As Double = 0.0
    Private codIng As String
    Private nomIng As String
    Private codProd As String
    Private nomProd As String
    Private pesoSet As Double
    Private pesoReal As Double
    Private diferencia As Double
    Private pesoSet1, pesoSet2, pesoSet3, pesoSet4, pesoSet5 As Double
    Private pesoReal1, pesoReal2, pesoReal3, pesoReal4, pesoReal5 As Double
    Private NumBatchPlanificacion, batchActual, batchPendientes As Integer
    Private corteT1, corteT2, corteCemento, corteAgua As Double
    Private LimiteT1, LimiteT2, LimiteCemento, LimiteAgua As Double

    Private flagConfigTolvas As Boolean = False
    Private flagConfigPLC As Boolean = False
    Private flagConfigSetpoints As Boolean = False

    Private flagFinCargaCemento As Boolean = False
    Private flagFinDesCargaCemento As Boolean = False

    Private flagFinParcialTolv1 As Boolean = False
    Private flagFinTolv1 As Boolean = False
    Private flagFinParcialTolv2 As Boolean = False
    Private flagFinTolv2 As Boolean = False
    Private flagFinAgua As Boolean = False
    Private flagFinParcial As Boolean = False
    Private flagSoltarProducto As Boolean = False

    Private flagEnviadoParcialCemento As Boolean = False
    Private flagEnviadoParcialAgua As Boolean = False

    Public SerTol1_ok, SerTol2_ok, SerCemento_ok As Boolean

    Private textoImprimir As String = ""
    Private nombreImpresora As String = ""
    Private flagUsaImpresora As Boolean = False

    'Factor para la carga parcial
    Private FactorParcialTolv1 As Integer = 50
    Private FactorParcialTolv2 As Integer = 50
    Private FactorParcialCement As Integer = 50
    Private FactorParcialAgua As Integer = 50


    Private CabeceraImpr As String = "EUFRATES "

    '*-*-*-*-**-*-*-*-*-*-*-*
    Private Sub Proceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        flagConfigTolvas = Cargar_y_Configurar_Tolvas()
        Sig_ConfigSerial.DiscreteValue1 = flagConfigTolvas
        CargaProductos()
        flagConfigPLC = Configura_Inicializa_PLC()
        Sig_PLC.DiscreteValue1 = flagConfigPLC
        LimpiarLabelsFormula()
        nombreImpresora = Funciones.Obtener_Valor_Configuracion("Nombre_Impresora")
        flagUsaImpresora = Convert.ToBoolean(Funciones.Obtener_Valor_Configuracion("UsaImpresora") = "1")
        'Lectura de cortes
        corteT1 = 50
        corteT2 = 50
        corteCemento = 50
        corteAgua = 5
        'Inicializar Timers para lectura del peso
        Timer_Tolva1.Enabled = True
        Timer_Tolva2.Enabled = True
        TimerTolvCemento.Enabled = True
        If flagConfigPLC Then
            Tim_ReadHR.Enabled = True
        End If

    End Sub
    Private Function Configura_Inicializa_PLC() As Boolean
        Dim rpta As Boolean = False
        Try
            PLC_LOGO = New EasyModbus.ModbusClient
            If PLC_LOGO.Connected Then
                PLC_LOGO.Disconnect()
            End If
            PLC_LOGO.IPAddress = "192.168.1.25"
            PLC_LOGO.Port = 502
            PLC_LOGO.SerialPort = Nothing
            PLC_LOGO.Connect()
            Lbl_Est_Conn.Text = "Conectado"
            Lbl_Est_Conn.ForeColor = Color.Green
            rpta = True
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText(
                "Excepcion Configura PLC: " & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
            rpta = False
            Lbl_Est_Conn.Text = "Desconectado"
            Lbl_Est_Conn.ForeColor = Color.Red
        End Try
        Sig_PLC.DiscreteValue1 = rpta
        Return rpta
    End Function
    Private Sub Reconecta_PLC()
        Try
            If Not flagConfigPLC And Lbl_Est_Conn.Text = "Desconectado" Then
                Configura_Inicializa_PLC()
            End If
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText(
                "Excepcion Reconexion PLC: " & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try
    End Sub
    Private Sub HoldinRegistersChanged(register As Integer, numberOfRegisters As Integer)
        'If preventInvokeHoldingRegisters Then Return
        'Try
        '    If Me.tabControl1.InvokeRequired Then
        '        If Not registersChanegesLocked Then
        '            SyncLock Me
        '                registersChanegesLocked = True
        '                Dim d As New registersChangedCallback(AddressOf HoldinRegistersChanged)
        '                Me.Invoke(d, register, numberOfRegisters)
        '            End SyncLock
        '        End If
        '    Else
        '        Dgv_HR.Rows.Clear()
        '        For i As Integer = 1 To 4

        '            Dim hrField = GetType(EasyModbus.ModbusServer).GetField(
        '            "holdingRegisters",
        '            Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)

        '            Dim hr() As Integer = CType(hrField.GetValue(PLC_LOGO), Integer())

        '            Dgv_HR.Rows.Add(i, hr(i))
        '            'Guardar Informacion en el bloque de lectura
        '            Block_lectura_HR(i) = hr(i)
        '        Next
        '        '--Rutina de lectura y procesmiento de informacion
        '        Lbl_Est_Conn.Text = "Conectado"
        '        Lbl_Est_Conn.ForeColor = Color.Green
        '        LecturaRegistros()
        '    End If
        'Catch ex As Exception
        'Finally
        '    registersChanegesLocked = False
        'End Try
    End Sub
    Private Sub LecturaRegistros()
        Try

            'Asignar valores de los registros a las variables de control
        Catch ex As Exception

        End Try
    End Sub
    Private Sub NumberOfConnectionsChanged()
        'If Lbl_Est_Conn.InvokeRequired AndAlso Not LockNumberOfConnectionsChanged Then

        '    SyncLock Me
        '        LockNumberOfConnectionsChanged = True
        '        Dim d As New numberOfConnectionsCallback(AddressOf NumberOfConnectionsChanged)

        '        Try
        '            Me.Invoke(d)
        '        Catch ex As Exception
        '            ' Ignorar excepción de invoke
        '        Finally
        '            LockNumberOfConnectionsChanged = False
        '        End Try
        '    End SyncLock

        'Else
        '    Try
        '        ' Ejemplo de uso real:
        '        ' Lbl_numConectados.Text = PLC_Logo.NumberOfConnections.ToString()

        '    Catch ex As Exception
        '        ' Lbl_numConectados.Text = "0"
        '    End Try
        'End If
    End Sub
    Private Sub CoilsChanged(coil As Integer, numberOfCoil As Integer)

        'If preventInvokeCoils Then Return

        'Try
        '    If tabControl1.InvokeRequired Then

        '        Dim d As New coilsChangedCallback(AddressOf CoilsChanged)
        '        Me.Invoke(d, coil, numberOfCoil)

        '    Else
        '        Dgv_Coils.Rows.Clear()

        '        For i As Integer = 1 To 3

        '            Dim hrField = GetType(EasyModbus.ModbusServer).GetField("coils", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        '            Dim Coils() As Boolean = CType(hrField.GetValue(PLC_LOGO), Boolean())

        '            Dgv_Coils.Rows.Add(i, Coils(i))

        '            ' Guardar la información en el bloque de lectura
        '            Block_lectura_Coils(i) = Coils(i)

        '            ' Colorear según estado
        '            If Coils(i) Then
        '                Dgv_Coils(1, i - 1).Style.BackColor = Color.Green
        '            Else
        '                Dgv_Coils(1, i - 1).Style.BackColor = Color.Red
        '            End If

        '        Next

        '        ProcesarCoils()
        '    End If

        'Catch ex As Exception
        '    '    MuestraNotificacion(
        '    '500,
        '    '"Error",
        '    '"Excepción: Coils Changed",
        '    'ex.Message
        '    ')
        'End Try

    End Sub
    'Private Sub ProcesarCoils()
    '    Try

    '        'Asignar valores de las coils leidas del PLC
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Function Cargar_y_Configurar_Tolvas() As Boolean
        Try
            '1: Cargar configuracion de tolvas
            Dim cmdTxt As String = "SELECT * FROM NumeroTolvasTanques ORDER BY id"
            Using da As New OleDbDataAdapter(cmdTxt, sConnString)
                tbTolvas.Clear()
                da.Fill(tbTolvas)
            End Using
            'Validacion de datos
            If tbTolvas Is Nothing OrElse tbTolvas.Rows.Count < numTolvas_Serial Then
                Rtx_Mensajes.AppendColoredText(
                "Error en la configuración de Tolvas. Consulte con el administrador del sistema" & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
                Return False
            End If

            '2: Configurar Puertos seriales
            SerTol1_ok = Funciones.AbrirPuertoSerial(SerialTolva1, tbTolvas.Rows(0), 1)
            SerTol2_ok = Funciones.AbrirPuertoSerial(SerialTolva2, tbTolvas.Rows(1), 2)
            SerCemento_ok = Funciones.AbrirPuertoSerial(SerialCemento, tbTolvas.Rows(2), 3)

            Sig_Tolv1.DiscreteValue1 = SerTol1_ok
            Sig_Tolv2.DiscreteValue1 = SerTol2_ok
            Sig_TolvCemento.DiscreteValue1 = SerCemento_ok

            If SerTol1_ok AndAlso SerTol2_ok AndAlso SerCemento_ok Then
                Rtx_Mensajes.AppendColoredText(
                    "Configuración serial de tolvas correcta" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
                Return True
            Else
                Dim errores As New List(Of String)
                If Not SerTol1_ok Then errores.Add("Tolva 1 - " & SerialTolva1.PortName)
                If Not SerTol2_ok Then errores.Add("Tolva 2 - " & SerialTolva2.PortName)
                If Not SerCemento_ok Then errores.Add("Tolva Cemento - " & SerialCemento.PortName)
                Dim msg As String = "Error en la configuración del puerto serie:" & vbCrLf &
                "- " & String.Join(vbCrLf & "- ", errores)
                Rtx_Mensajes.AppendColoredText(msg & Environment.NewLine,
                    Drawing.Color.Red,
                    font_Rtxt)
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show(
            ex.Message,
            "Excepción: Carga y Configuración de Tolvas",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub Tim_DescargaT1_Tick(sender As Object, e As EventArgs) Handles Tim_DescargaT1.Tick
        Try
            If flagFinParcialTolv1 Then

            End If
            If Convert.ToDouble(Lbl_Peso_T1.Text) > (LimiteT1 * FactorParcialTolv1 / 100) Then
                'Enviar activacion de señal de PLC
                PLC_LOGO.WriteSingleCoil(Variables.dir_DescargaTol1, True)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReadHoldingRegister()
        Try
            Block_lectura_HR = PLC_LOGO.ReadHoldingRegisters(0, 3)
            Lbl_Agua.Text = Block_lectura_HR(Variables.dir_ContadorFlujometro)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Tim_ReadHR_Tick(sender As Object, e As EventArgs) Handles Tim_ReadHR.Tick
        ReadHoldingRegister()
    End Sub

    Private Sub Tim_Carga_Agua_Tick(sender As Object, e As EventArgs) Handles Tim_Carga_Agua.Tick
        Try
            Dim Compara As Double = LimiteAgua * FactorParcialAgua / 100
            If Convert.ToDouble(Lbl_Agua.Text) <= Compara Then
                'Enviar activacion de señal de PLC
                PLC_LOGO.WriteSingleCoil(3, True)
            Else
                PLC_LOGO.WriteSingleCoil(3, False)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btt_Salir_Click(sender As Object, e As EventArgs) Handles Btt_Salir.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Reconecta_PLC()
    End Sub

    Private Sub Btt_Iniciar_Click(sender As Object, e As EventArgs) Handles Btt_Iniciar.Click
        NumBatchPlanificacion = NumericBatchs.Value
        If running Then
            Rtx_Mensajes.AppendColoredText("Dosificacion en proceso" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
            Exit Sub
        End If

        Dim valActualT1 As Double = 0
        Dim valActualT2 As Double = 0
        Dim valActualCemento As Double = 0
        Dim Preparado As Boolean = False

        valActualT1 = Convert.ToDouble(Lbl_Peso_T1.Text)
        valActualT2 = Convert.ToDouble(Lbl_Peso_T2.Text)
        valActualCemento = Convert.ToDouble(Lbl_Peso_Cem.Text)
        'ACTIVAR
        'If valActualT1 < pesoSet1 Then
        '    MessageBox.Show("El peso en la Tolva 1 es menor al necesario, agregue más peso", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Rtx_Mensajes.AppendColoredText("Peso de Tolva 1 inferior al necesario" & Environment.NewLine,
        '        Drawing.Color.Black,
        '        font_Rtxt)
        '    Exit Sub
        'End If
        'If valActualT2 < pesoSet2 Then
        '    MessageBox.Show("El peso en la Tolva 2 es menor al necesario, agregue más peso", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Rtx_Mensajes.AppendColoredText("Peso de Tolva 2 inferior al necesario" & Environment.NewLine,
        '        Drawing.Color.Black,
        '        font_Rtxt)
        '    Exit Sub
        'End If
        If flagConfigPLC And flagConfigSetpoints And SerTol1_ok And SerTol2_ok And SerCemento_ok Then
            Preparado = True
        End If
        'Borrar- Solo para pruebas
        Preparado = True
        If Preparado Then
            running = True
            LimiteT1 = valActualT1 + corteT1 - pesoSet1
            LimiteT2 = valActualT2 + corteT2 - pesoSet2
            LimiteCemento = pesoSet3 - corteCemento
            LimiteAgua = pesoSet4 - corteAgua
            'Tim_Carga_Cem.Enabled = True
            'Tim_DescargaT1.Enabled = True
            Tim_Carga_Agua.Enabled = True
        Else
            MessageBox.Show("Sistema no cumple con los requisitos para iniciar, revise el estado de las señales", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Rtx_Mensajes.AppendColoredText("Sistema no cumple con los requisitos para iniciar" & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End If
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
                    lblTolva.Visible = True
                End If
                If lblIng IsNot Nothing Then
                    lblIng.Text = ""
                    lblIng.Visible = True
                End If
                If lblCanTeo IsNot Nothing Then
                    lblCanTeo.Text = ""
                    lblCanTeo.Visible = True
                End If
                If lblCanRea IsNot Nothing Then
                    lblCanRea.Text = ""
                    lblCanRea.Visible = True
                End If
                If lblDifer IsNot Nothing Then
                    lblDifer.Text = ""
                    lblDifer.Visible = True
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

            'Asignar valores de setpoints  
            If dt.Rows.Count >= registros Then
                pesoSet1 = Convert.ToDouble(dt.Rows(0).Item("Cantidad")) '--Tolva 1
                pesoSet2 = Convert.ToDouble(dt.Rows(1).Item("Cantidad")) '--Tolva 2
                pesoSet3 = Convert.ToDouble(dt.Rows(2).Item("Cantidad")) '--Tolva Cemento
                pesoSet4 = Convert.ToDouble(dt.Rows(3).Item("Cantidad")) '--Agua
                flagConfigSetpoints = True
                Sig_Setpoints.DiscreteValue1 = True
            Else
                flagConfigSetpoints = False
                Sig_Setpoints.DiscreteValue1 = False
            End If
            'Rtx_Mensajes.AppendColoredText("PesoSet1 = " & pesoSet1.ToString & Environment.NewLine, Drawing.Color.Black, font_Rtxt)
            'Rtx_Mensajes.AppendColoredText("PesoSet2 = " & pesoSet2.ToString & Environment.NewLine, Drawing.Color.Black, font_Rtxt)
            'Rtx_Mensajes.AppendColoredText("PesoSet3 = " & pesoSet3.ToString & Environment.NewLine, Drawing.Color.Black, font_Rtxt)
            'Rtx_Mensajes.AppendColoredText("PesoSet4 = " & pesoSet4.ToString & Environment.NewLine, Drawing.Color.Black, font_Rtxt)
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
            flagConfigSetpoints = False
            Sig_Setpoints.DiscreteValue1 = False
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
        If cmbproductos.SelectedIndex > -1 AndAlso cmbproductos.SelectedValue IsNot Nothing AndAlso
            Not TypeOf cmbproductos.SelectedValue Is DataRowView Then
            ObtieneFormulaxProducto(cmbproductos.SelectedValue.ToString)
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim fuente As New Font("Courier New", 10)
        e.Graphics.DrawString(textoImprimir, fuente, Brushes.Black, 0, 0)

        e.HasMorePages = False
    End Sub
    Private Sub Timer_Tolva1_Tick(sender As Object, e As EventArgs) Handles Timer_Tolva1.Tick
        Funciones.LeerSerie(SerialTolva1, Btt_ReCon_T1, Lbl_Est_T1, Lbl_Peso_T1, Timer_Tolva1, "Estandar", 1)
    End Sub

    Private Sub Timer_Tolva2_Tick(sender As Object, e As EventArgs) Handles Timer_Tolva2.Tick
        Funciones.LeerSerie(SerialTolva2, Btt_ReCon_T2, Lbl_Est_T2, Lbl_Peso_T2, Timer_Tolva2, "Estandar", 2)
    End Sub

    Private Sub TimerTolvCemento_Tick(sender As Object, e As EventArgs) Handles TimerTolvCemento.Tick
        Funciones.LeerSerie(SerialCemento, Btt_ReCon_Cemento, Lbl_Est_Cem, Lbl_Peso_Cem, TimerTolvCemento, "Estandar", 3)
    End Sub

    Private Sub Btt_ReCon_T1_Click(sender As Object, e As EventArgs) Handles Btt_ReCon_T1.Click
        SerTol1_ok = Funciones.AbrirPuertoSerial(SerialTolva1, tbTolvas.Rows(0), 1)
        If Not SerialTolva1.IsOpen Then
            'MessageBox.Show(String.Format("No se pudo abrir el puerto {0} " & "Verifique conexiones", SerialTolva1.PortName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Rtx_Mensajes.AppendColoredText(
                String.Format("No se pudo abrir el puerto {0} " & "Verifique conexiones", SerialTolva1.PortName) & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
            Exit Sub
        Else
            Timer_Tolva1.Enabled = True
        End If
    End Sub

    Private Sub Btt_ReCon_T2_Click(sender As Object, e As EventArgs) Handles Btt_ReCon_T2.Click
        SerTol2_ok = Funciones.AbrirPuertoSerial(SerialTolva2, tbTolvas.Rows(1), 2)
        If Not SerialTolva2.IsOpen Then
            'MessageBox.Show(String.Format("No se pudo abrir el puerto {0} " & "Verifique conexiones", SerialTolva1.PortName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Rtx_Mensajes.AppendColoredText(
                String.Format("No se pudo abrir el puerto {0} " & "Verifique conexiones", SerialTolva2.PortName) & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
            Exit Sub
        Else
            Timer_Tolva2.Enabled = True
        End If
    End Sub

    Private Sub Btt_ReCon_Cemento_Click(sender As Object, e As EventArgs) Handles Btt_ReCon_Cemento.Click
        SerCemento_ok = Funciones.AbrirPuertoSerial(SerialCemento, tbTolvas.Rows(2), 3)
        If Not SerialCemento.IsOpen Then
            'MessageBox.Show(String.Format("No se pudo abrir el puerto {0} " & "Verifique conexiones", SerialTolva1.PortName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Rtx_Mensajes.AppendColoredText(
                String.Format("No se pudo abrir el puerto {0} " & "Verifique conexiones", SerialCemento.PortName) & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
            Exit Sub
        Else
            Timer_Tolva2.Enabled = True
        End If
    End Sub
End Class
