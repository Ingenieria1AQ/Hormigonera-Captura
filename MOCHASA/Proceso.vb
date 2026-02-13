Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports System.Text

Public Class Proceso
    'Llamar a la clase de indicador Serial
    Private IndicadorTolv1 As Indicador_Serial
    Private IndicadorTolv2 As Indicador_Serial
    Private IndicadorCemento As Indicador_Serial

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
    Private NumBatchPlanificacion, batchActual, batchPendientes, consecutivoBatch As Integer
    Private corteT1, corteT2, corteCemento, corteAgua As Double
    Private LimiteT1, LimiteT2, LimiteCemento, LimiteAgua As Double
    Private CantidadM3 As Integer = 1
    Private FactorHumedad_Arena As Double = 1
    Private FactorHumedad_Ripio As Double = 1

    Private Var_Carga_CEM_Tornillo As Boolean = False
    Private Var_CArga_CEM_Compuerta As Boolean = False

    Private Estado_WD As Boolean = False
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
    Private flagFinParcialAgua As Boolean = False
    Private flagSoltarProducto As Boolean = False

    Public SerTol1_ok, SerTol2_ok, SerCemento_ok As Boolean

    Private textoImprimir As String = ""
    Private nombreImpresora As String = ""
    Private flagUsaImpresora As Boolean = False
    Private DirPLC As String
    Private PuertoPLC As Integer
    Private FactorAgua As Double = 1.0
    'Factor para la carga parcial
    Private FactorParcialTolv1 As Integer = 50
    Private FactorParcialTolv2 As Integer = 50
    Private FactorParcialCement As Integer = 50
    Private FactorParcialAgua As Integer = 50

    '***VARIABLES IMPORTANTES****
    'Variables que se captura el peso actual con el que inicia la dosificacion 
    Private ValorInicialT1 As Double = 0
    Private ValorInicialT2 As Double = 0
    Private ValorInicialCemento As Double = 0


    Private CabeceraImpr As String = "EUFRATES "


    '*-*-*-*-**-*-*-*-*-*-*-*
    Private Sub Proceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obtener variables de la tabla de configuracion

        Principal.Panel1.Visible = False
        Lbl_Info.Text = String.Empty
        nombreImpresora = Funciones.Obtener_Valor_Configuracion("Nombre_Impresora")
        flagUsaImpresora = Convert.ToBoolean(Funciones.Obtener_Valor_Configuracion("UsaImpresora") = "1")
        DirPLC = Funciones.Obtener_Valor_Configuracion("PLC_IP")
        PuertoPLC = Convert.ToInt32(Funciones.Obtener_Valor_Configuracion("PLC_Puerto"))
        FactorAgua = Convert.ToDouble(Funciones.Obtener_Valor_Configuracion("FactorAgua"))
        'consecutivoBatch = Convert.ToInt32(Funciones.Obtener_Valor_Configuracion("ConsecutivoBatch"))

        'Muestra IP del PLC
        Lbl_IpAdd.Text = DirPLC
        Lbl_Puerto.Text = PuertoPLC.ToString

        CargaProductos()
        flagConfigPLC = Configura_Inicializa_PLC()
        Pil_PLC.DiscreteValue1 = flagConfigPLC
        LimpiarLabelsFormula()
        'Configuracion serial y Extrae Puntos de corte de las tolvas
        Cargar_y_Configurar_Tolvas()

        If flagConfigPLC Then
            Tim_ReadHR.Enabled = True
        Else
            'habilitar reconexion del PLC
        End If
    End Sub

    Private Sub PesoT1_Recibido(peso As Decimal)
        BeginInvoke(Sub()
                        Lbl_Peso_T1.Text = peso.ToString("N2") 'Peso con 2 decimales
                    End Sub)
    End Sub
    Private Sub PesoT2_Recibido(peso As Decimal)
        BeginInvoke(Sub()
                        Lbl_Peso_T2.Text = peso.ToString("N2") 'Peso con 2 decimales
                    End Sub)
    End Sub
    Private Sub pesoCem_Recibido(peso As Decimal)
        BeginInvoke(Sub()
                        Lbl_Peso_Cem.Text = peso.ToString("N2") 'Peso con 2 decimales
                    End Sub)
    End Sub
    Private Sub EstadoT1(conectado As Boolean, mensaje As String)
        Try
            BeginInvoke(Sub()
                            Lbl_Est_T1.Text = mensaje
                            If conectado Then
                                Lbl_Est_T1.ForeColor = Color.DarkGreen
                            Else
                                Lbl_Est_T1.ForeColor = Color.DarkRed
                            End If
                            SerTol1_ok = conectado
                            Pil_Tolv1.DiscreteValue1 = conectado
                        End Sub)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub EstadoT2(conectado As Boolean, mensaje As String)
        Try
            BeginInvoke(Sub()
                            Lbl_Est_T2.Text = mensaje
                            If conectado Then
                                Lbl_Est_T2.ForeColor = Color.DarkGreen
                            Else
                                Lbl_Est_T2.ForeColor = Color.DarkRed
                            End If
                            SerTol2_ok = conectado
                            Pil_Tolv2.DiscreteValue1 = conectado
                        End Sub)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub EstadoCemento(conectado As Boolean, mensaje As String)
        Try
            BeginInvoke(Sub()
                            Lbl_Est_Cem.Text = mensaje
                            If conectado Then
                                Lbl_Est_Cem.ForeColor = Color.DarkGreen
                            Else
                                Lbl_Est_Cem.ForeColor = Color.DarkRed
                            End If
                            SerCemento_ok = conectado
                            Pil_TolvCemento.DiscreteValue1 = conectado
                        End Sub)
        Catch ex As Exception

        End Try

    End Sub
    Private Function Configura_Inicializa_PLC() As Boolean
        Dim rpta As Boolean = False
        Try
            PLC_LOGO = New EasyModbus.ModbusClient
            If PLC_LOGO.Connected Then
                PLC_LOGO.Disconnect()
            End If
            PLC_LOGO.IPAddress = DirPLC
            PLC_LOGO.Port = PuertoPLC
            PLC_LOGO.SerialPort = Nothing
            PLC_LOGO.Connect()
            If PLC_LOGO.Connected Then
                Lbl_Est_Conn.Text = "Conectado"
                Lbl_Est_Conn.ForeColor = Color.Green
                rpta = True
            Else
                Lbl_Est_Conn.Text = "Desconectado"
                Lbl_Est_Conn.ForeColor = Color.Red
            End If
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText(
                "Excepcion Configura PLC: " & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
            rpta = False
            Lbl_Est_Conn.Text = "Desconectado"
            Lbl_Est_Conn.ForeColor = Color.Red
        End Try
        Pil_PLC.DiscreteValue1 = rpta
        Return rpta
    End Function
    Private Sub Reconecta_PLC()
        Try
            If PLC_LOGO.Connected = False Then
                Configura_Inicializa_PLC()
            End If

        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText(
                "Excepcion Reconexion PLC: " & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try
    End Sub

    Private Sub Cargar_y_Configurar_Tolvas()
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
            End If

            corteT1 = Convert.ToDouble(tbTolvas.Rows(0).Item("Corte"))
            corteT2 = Convert.ToDouble(tbTolvas.Rows(1).Item("Corte"))
            corteCemento = Convert.ToDouble(tbTolvas.Rows(2).Item("Corte"))
            corteAgua = Convert.ToDouble(tbTolvas.Rows(3).Item("Corte"))

            IndicadorTolv1 = New Indicador_Serial(tbTolvas.Rows(0).Item("PuertoCOM"), Convert.ToInt32(tbTolvas.Rows(0).Item("BaudRate")), tbTolvas.Rows(0).Item("TipoIndicador"))
            IndicadorTolv2 = New Indicador_Serial(tbTolvas.Rows(1).Item("PuertoCOM"), Convert.ToInt32(tbTolvas.Rows(1).Item("BaudRate")), tbTolvas.Rows(1).Item("TipoIndicador"))
            IndicadorCemento = New Indicador_Serial(tbTolvas.Rows(2).Item("PuertoCOM"), Convert.ToInt32(tbTolvas.Rows(2).Item("BaudRate")), tbTolvas.Rows(2).Item("TipoIndicador"))

            AddHandler IndicadorTolv1.PesoRecibido, AddressOf PesoT1_Recibido
            AddHandler IndicadorTolv2.PesoRecibido, AddressOf PesoT2_Recibido
            AddHandler IndicadorCemento.PesoRecibido, AddressOf pesoCem_Recibido

            AddHandler IndicadorTolv1.EstadoCambiado, AddressOf EstadoT1
            AddHandler IndicadorTolv2.EstadoCambiado, AddressOf EstadoT2
            AddHandler IndicadorCemento.EstadoCambiado, AddressOf EstadoCemento

            IndicadorTolv1.Conectar()
            IndicadorTolv2.Conectar()
            IndicadorCemento.Conectar()
            'Dim errores As New List(Of String)
            'If Not SerTol1_ok Then errores.Add("Tolva 1 - " & SerialTolva1.PortName)
            'If Not SerTol2_ok Then errores.Add("Tolva 2 - " & SerialTolva2.PortName)
            'If Not SerCemento_ok Then errores.Add("Tolva Cemento - " & SerialCemento.PortName)
            'Dim msg As String = "Error en la configuración del puerto serie:" & vbCrLf &
            '    "- " & String.Join(vbCrLf & "- ", errores)
            'Rtx_Mensajes.AppendColoredText(msg & Environment.NewLine,
            '        Drawing.Color.Red,
            '        font_Rtxt)
        Catch ex As Exception
            MessageBox.Show(
            ex.Message,
            "Excepción: Carga y Configuración de Tolvas",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub ReadHoldingRegister()
        Try
            Block_lectura_HR = PLC_LOGO.ReadHoldingRegisters(0, 3)
            Lbl_Agua.Text = Block_lectura_HR(Variables.dir_ContadorFlujometro) * FactorAgua
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Tim_ReadHR_Tick(sender As Object, e As EventArgs) Handles Tim_ReadHR.Tick
        ReadHoldingRegister()
    End Sub

    Private Sub Tim_Carga_Agua_Tick(sender As Object, e As EventArgs) Handles Tim_Carga_Agua.Tick
        Try
            Dim ValActual As Double = Convert.ToDouble(Lbl_Agua.Text)
            If ValActual <= Pb_Tol4.Maximum Then
                Pb_Tol4.Value = ValActual
            Else
                Pb_Tol4.Value = Pb_Tol4.Maximum
            End If
            Lbl_Dosif_Agua.Text = ValActual.ToString("N2")
            If flagFinParcialAgua = False Then
                'Carga Parcial
                Dim Compara As Double = (LimiteAgua + corteAgua) * FactorParcialAgua / 100
                If ValActual >= Compara Then
                    Tim_Carga_Agua.Enabled = False
                    FinalizaParcialAgua()
                End If
            Else
                'Carga Total
                If flagFinAgua = False Then
                    Dim compara As Double = LimiteAgua
                    If ValActual >= compara Then
                        Tim_Carga_Agua.Enabled = False
                        FinalizaTotalAgua()
                    End If
                End If
            End If
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText(
                "Excepcion: Tim_Carga_Agua " & vbCrLf & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try
    End Sub

    Private Sub Tim_Carga_Cem_Tick(sender As Object, e As EventArgs) Handles Tim_Carga_Cem.Tick
        Try
            Dim valActual As Double = Convert.ToDouble(Lbl_Peso_Cem.Text)
            If valActual <= Pb_Tol3.Maximum Then
                Pb_Tol3.Value = valActual
            Else
                Pb_Tol3.Value = Pb_Tol3.Maximum
            End If

            Lbl_Dosif_Cemento.Text = valActual.ToString("N2")
            Dim Compara As Double = LimiteCemento
            If valActual >= Compara Then
                Tim_Carga_Cem.Enabled = False
                FinalizarCargaCemento()
            End If
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText(
                "Excepcion: Tim_Carga_Cemento " & vbCrLf & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try
    End Sub
    Private Sub Tim_Desc_Cemento_Tick(sender As Object, e As EventArgs) Handles Tim_Desc_Cemento.Tick
        Try
            Dim valActual As Double = Convert.ToDouble(Lbl_Peso_Cem.Text)
            If valActual <= Pb_Tol3.Maximum Then
                Pb_Tol3.Value = valActual
            Else
                Pb_Tol3.Value = Pb_Tol3.Maximum
            End If

            Dim Compara As Double = 10
            If valActual <= Compara Then
                Tim_Desc_Cemento.Enabled = False
                FinalizarDescargaCemento()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Tim_DescargaT1_Tick(sender As Object, e As EventArgs) Handles Tim_DescargaT1.Tick
        Try
            Dim ValProceso As Double = ValorInicialT1 - Convert.ToDouble(Lbl_Peso_T1.Text)
            Lbl_Dosif_T1.Text = ValProceso.ToString("N2")
            If ValProceso <= Pb_Tol1.Maximum Then
                Pb_Tol1.Value = ValProceso
            Else
                Pb_Tol1.Value = Pb_Tol1.Maximum
            End If

            If flagFinParcialTolv1 = False Then
                Dim Compara As Double = LimiteT1 * FactorParcialTolv1 / 100
                If ValProceso >= Compara Then
                    Tim_DescargaT1.Enabled = False
                    FinDescargaParcialT1()
                End If
            Else
                If flagFinTolv1 = False Then
                    Dim Compara As Double = LimiteT1
                    If ValProceso >= Compara Then
                        Tim_DescargaT1.Enabled = False
                        FinDescargaTotalT1()
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Tim_DescargaT2_Tick(sender As Object, e As EventArgs) Handles Tim_DescargaT2.Tick
        Try
            Dim ValProceso As Double = ValorInicialT2 - Convert.ToDouble(Lbl_Peso_T2.Text)
            Lbl_Dosif_T2.Text = ValProceso.ToString("N2")
            If ValProceso <= Pb_Tol2.Maximum Then
                Pb_Tol2.Value = ValProceso
            Else
                Pb_Tol2.Value = Pb_Tol2.Maximum
            End If

            If flagFinParcialTolv2 = False Then
                Dim Compara As Double = LimiteT2 * FactorParcialTolv2 / 100
                If ValProceso >= Compara Then
                    Tim_DescargaT2.Enabled = False
                    FinDescargaParcialT2()
                End If
            Else
                If flagFinTolv2 = False Then
                    Dim Compara As Double = LimiteT2
                    If ValProceso >= Compara Then
                        Tim_DescargaT2.Enabled = False
                        FinDescargaTotalT2()
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Btt_Salir_Click(sender As Object, e As EventArgs) Handles Btt_Salir.Click
        Try
            IndicadorTolv1.Desconectar()
            IndicadorTolv2.Desconectar()
            IndicadorCemento.Desconectar()
            If PLC_LOGO.Connected Then
                PLC_LOGO.Disconnect()
            End If
            Principal.Panel1.Visible = True
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btt_ReconectaPLC_Click(sender As Object, e As EventArgs) Handles Btt_ReconectaPLC.Click
        Reconecta_PLC()
        If PLC_LOGO.Connected Then
            Tim_ReadHR.Enabled = True
            Btt_ReconectaPLC.Enabled = False
        Else
            Btt_ReconectaPLC.Enabled = True
        End If
    End Sub

    Private Async Sub Btt_Iniciar_Click(sender As Object, e As EventArgs) Handles Btt_Iniciar.Click
        Try
            If running Then
                Rtx_Mensajes.AppendColoredText("Dosificacion en proceso" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
                Exit Sub
            End If
            'HABILITAR ESTA OPCION para controlar número de batch
            'NumBatchPlanificacion = Num_BatchPlanificacion.Value
            NumBatchPlanificacion = 1   'EUFRATES SOLAMENTE HACE UN BATCH
            Dim Preparado As Boolean = False

            ValorInicialT1 = Convert.ToDouble(Lbl_Peso_T1.Text)
            ValorInicialT2 = Convert.ToDouble(Lbl_Peso_T2.Text)
            ValorInicialCemento = Convert.ToDouble(Lbl_Peso_Cem.Text)
            'ACTIVAR
            If ValorInicialT1 < pesoSet1 Then
                MessageBox.Show("El peso en la Tolva 1 es menor al necesario, agregue más peso", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Rtx_Mensajes.AppendColoredText("Peso de Tolva 1 inferior al necesario" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
                Exit Sub
            End If
            If ValorInicialT2 < pesoSet2 Then
                MessageBox.Show("El peso en la Tolva 2 es menor al necesario, agregue más peso", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Rtx_Mensajes.AppendColoredText("Peso de Tolva 2 inferior al necesario" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
                Exit Sub
            End If
            If ValorInicialCemento < 0 Then
                MessageBox.Show("El peso en la Tolva Cemento es menor a 0, encere la balanza", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Rtx_Mensajes.AppendColoredText("Peso de Tolva Cemento negativo" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
                Exit Sub
            End If
            If ValorInicialCemento > 20 Then
                MessageBox.Show("Debe encerar la balanza de Cemento", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Rtx_Mensajes.AppendColoredText("Se quiere encerar la balanza de cemento" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
                Exit Sub
            End If
            If flagConfigPLC And flagConfigSetpoints And SerTol1_ok And SerTol2_ok And SerCemento_ok Then
                Preparado = True
            End If
            'Borrar- Solo para pruebas
            'Preparado = True
            If Preparado Then
                GBx_Preparacion.Enabled = False
                Gbx_ConfigCarg_Cemento.Enabled = False
                'Extrae el numero de batch de la base
                consecutivoBatch = Convert.ToInt32(Funciones.Obtener_Valor_Configuracion("ConsecutivoBatch"))
                For i As Integer = 1 To registros
                    CambiaEstado_Label(i, "PREPARADO", Color.Black)
                Next

                Panel2.BackColor = Color.DarkSeaGreen
                running = True
                'Aumenta el numero consecutivo del batch
                consecutivoBatch += 1
                'Guardamos el valor del Batch Actual
                Funciones.Actualizar_Valor_Configuracion("ConsecutivoBatch", consecutivoBatch)
                'Configura valores limites
                LimiteT1 = pesoSet1 - corteT1
                LimiteT2 = pesoSet2 - corteT2
                LimiteCemento = pesoSet3 - corteCemento
                LimiteAgua = pesoSet4 - corteAgua

                batchActual += 1
                batchPendientes = NumBatchPlanificacion - batchActual
                'Reset todas las señales
                ResetTodasSignals()
                'Inicia timer de WD 
                Tim_Wd_PLC.Enabled = True
                'DAR SEÑAL de ARRANQUE
                PLC_LOGO.WriteSingleCoil(Variables.coil_Paro, False)
                PLC_LOGO.WriteSingleCoil(Variables.coil_Arranque, True)
                Pil_Dosifica.DiscreteValue1 = True 'Revisar para enlazarse con los coils del PLC
                'Ingresar aqui Rutina WD
                Lbl_Info.Text = $"Iniciando Dosificación Batch {batchActual} de {NumBatchPlanificacion}"
                Rtx_Mensajes.AppendColoredText($"Iniciando Dosificación Batch {batchActual} de {NumBatchPlanificacion}" & Environment.NewLine,
                    Drawing.Color.DarkGreen,
                    font_Rtxt)

                'Iniciar carga del parcial del agua
                IniciarCargaParcialAgua()
                'Iniciar carga de cemento
                IniciarCargaCemento()
                'Encender banda transportadora
                Iniciar_Apagar_Banda(True)
                'Dar retardo  --Ver otras opciones de retardo
                Await DelayMs(4000) ' 4 segundos sin bloquear
                'Iniciar descarga de piedra
                IniciarDescargaParcialT1()
                'Deshabilita boton incio
                Btt_Iniciar.Enabled = False
                Btt_Detener.Enabled = True
                Btt_Salir.Enabled = False
            Else
                MessageBox.Show("Sistema no cumple con los requisitos para iniciar, revise el estado de las señales", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Dim errores As New List(Of String)
                If Not SerTol1_ok Then errores.Add("Tolva 1 - " & SerialTolva1.PortName)
                If Not SerTol2_ok Then errores.Add("Tolva 2 - " & SerialTolva2.PortName)
                If Not SerCemento_ok Then errores.Add("Tolva Cemento - " & SerialCemento.PortName)
                If Not flagConfigSetpoints Then errores.Add("No se ha seleccionado Ninguna Fórmula")
                Dim msg As String = "Error en el arranque de la Dosificación:" & vbCrLf &
                "- " & String.Join(vbCrLf & "- ", errores)
                Rtx_Mensajes.AppendColoredText(msg & Environment.NewLine,
                    Drawing.Color.Red,
                    font_Rtxt)
            End If
        Catch ex As Exception
            running = False
            MessageBox.Show(ex.Message, "Excepcion Inicio Batch", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Pil_Dosifica.DiscreteValue1 = False
        End Try

    End Sub
    Private Sub CambiaEstado_Label(index As Integer, Valor As String, Color As Color)
        Try
            Dim lblEstado As Label = BuscarLabel("Lbl_Estado" & index)
            lblEstado.Text = Valor
            lblEstado.ForeColor = Color
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CambiaProceso_Labels(index As Integer, PesoFinal As String, Diferencia As String)
        Try
            Dim lblCant_Real As Label = BuscarLabel("Lbl_CanRea" & index)
            Dim lblCant_Dif As Label = BuscarLabel("Lbl_Dif" & index)
            lblCant_Real.Text = PesoFinal
            lblCant_Dif.Text = Diferencia
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ResetTodasSignals()
        If PLC_LOGO.Connected Then
            Dim coils() As Boolean = {False, True, False, False, False, False, False, False, False, False, False, False, False, False}
            '-------------------------8.0     8.1   8.2    8.3    8.4    8.5    8.6    8.7    9.0    9.1    9.2    9.3    9.4    9.5
            PLC_LOGO.WriteMultipleCoils(64, coils)
        Else
            Rtx_Mensajes.AppendColoredText("PLC no conectado, no es posible resetar todas las señales" & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End If
    End Sub
    Private Async Sub IniciarCargaParcialAgua()
        'Iniciar carga del parcial del agua
        CambiaEstado_Label(Variables.reg_Lbl_Agua, "CARGANDO PARCIAL...", Color.Orange)
        Rtx_Mensajes.AppendColoredText("Iniciando carga parcial de agua" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        PLC_LOGO.WriteSingleCoil(Variables.coil_ResetContador, True) 'Reset Contador

        'System.Threading.Thread.Sleep(2000)
        Await DelayMs(4000) ' 4 segundos sin bloquear
        PLC_LOGO.WriteSingleCoil(Variables.coil_ResetContador, False) 'Reset Contador
        'Validar que no arranque si la formula marca cero
        If pesoSet4 > 0 Then
            PLC_LOGO.WriteSingleCoil(Variables.coil_BombaAgua, True)
            Pil_Bomba.DiscreteValue1 = True
            Sym_Bomba.DiscreteValue1 = True
            Sym_Bomba_G1.DiscreteValue1 = True
            Sym_Bomba_G2.DiscreteValue1 = True
            Sym_Bomba_G3.DiscreteValue1 = True
            Sym_Bomba_G4.DiscreteValue1 = True
            Sym_Bomba_G5.DiscreteValue1 = True
            Sym_Bomba_G6.DiscreteValue1 = True
            Sym_Bomba_G7.DiscreteValue1 = True
        End If

        'Activa timer
        Tim_Carga_Agua.Enabled = True
        Pb_Tol4.Maximum = Convert.ToInt32(pesoSet4)
    End Sub
    Private Sub IniciarCargaTotalAgua()
        'Iniciar carga del parcial del agua
        CambiaEstado_Label(Variables.reg_Lbl_Agua, "CARGANDO TOTAL...", Color.DarkGreen)
        Rtx_Mensajes.AppendColoredText("Iniciando carga total de agua" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        'Validar que no arranque si la formula marca cero
        If pesoSet4 >= 0 Then
            PLC_LOGO.WriteSingleCoil(Variables.coil_BombaAgua, True)
            Pil_Bomba.DiscreteValue1 = True
            Sym_Bomba.DiscreteValue1 = True
            Sym_Bomba_G1.DiscreteValue1 = True
            Sym_Bomba_G2.DiscreteValue1 = True
            Sym_Bomba_G3.DiscreteValue1 = True
            Sym_Bomba_G4.DiscreteValue1 = True
            Sym_Bomba_G5.DiscreteValue1 = True
            Sym_Bomba_G6.DiscreteValue1 = True
            Sym_Bomba_G7.DiscreteValue1 = True
        End If
        Tim_Carga_Agua.Enabled = True
    End Sub

    Private Sub FinalizaParcialAgua()

        flagFinParcialAgua = True
        PLC_LOGO.WriteSingleCoil(Variables.coil_BombaAgua, False)
        Pil_Bomba.DiscreteValue1 = False
        Pil_Bomba.DiscreteValue1 = False
        Sym_Bomba.DiscreteValue1 = False
        Sym_Bomba_G1.DiscreteValue1 = False
        Sym_Bomba_G2.DiscreteValue1 = False
        Sym_Bomba_G3.DiscreteValue1 = False
        Sym_Bomba_G4.DiscreteValue1 = False
        Sym_Bomba_G5.DiscreteValue1 = False
        Sym_Bomba_G6.DiscreteValue1 = False
        Sym_Bomba_G7.DiscreteValue1 = False
        CambiaEstado_Label(Variables.reg_Lbl_Agua, "FIN PARCIAL", Color.DarkRed)
        Rtx_Mensajes.AppendColoredText("Carga parcial de agua finalizada" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        'Revisar si se debe detener el timer
        'Tim_Carga_Agua.Enabled = False
        If flagFinParcialAgua And flagFinParcialTolv2 Then
            Btt_Continuar.Visible = True
            Panel2.BackColor = Color.Moccasin
            Lbl_Info.Text = "Presione 'Continuar' para terminar la dosificacion"
        End If
    End Sub
    Private Async Sub FinalizaTotalAgua()
        Try
            flagFinAgua = True
            PLC_LOGO.WriteSingleCoil(Variables.coil_BombaAgua, False)
            Pil_Bomba.DiscreteValue1 = False
            Pil_Bomba.DiscreteValue1 = False
            Sym_Bomba.DiscreteValue1 = False
            Sym_Bomba_G1.DiscreteValue1 = False
            Sym_Bomba_G2.DiscreteValue1 = False
            Sym_Bomba_G3.DiscreteValue1 = False
            Sym_Bomba_G4.DiscreteValue1 = False
            Sym_Bomba_G5.DiscreteValue1 = False
            Sym_Bomba_G6.DiscreteValue1 = False
            Sym_Bomba_G7.DiscreteValue1 = False
            Tim_Carga_Agua.Enabled = False

            Rtx_Mensajes.AppendColoredText("Carga Total de agua finalizada" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)

            'Procesar guardar peso
            Await DelayMs(4000) '---Espera estabilidad del peso
            pesoReal4 = Convert.ToDouble(Lbl_Agua.Text)
            Dim Diferencia As Double = pesoSet4 - pesoReal4
            'Guardar registro de pesada
            Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, Variables.CodigProducto, Variables.NombreProducto, Variables.CodigIngrediente_T4, Variables.NombreIngrediente_T4,
                                    pesoSet4, pesoReal4, Variables.Factor)
            Pb_Tol4.Maximum = pesoReal4
            Pb_Tol4.Value = pesoReal4
            Lbl_Dosif_Agua.Text = pesoReal4.ToString("N2")
            CambiaProceso_Labels(Variables.reg_Lbl_Agua, pesoReal4.ToString("N2"), Diferencia.ToString("N2"))
            CambiaEstado_Label(Variables.reg_Lbl_Agua, "FINALIZADO", Color.Red)
            'Verificar si es el ultimo ing
            If flagFinTolv2 And flagFinAgua And flagFinCargaCemento Then
                FinalizaBatch()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub IniciarCargaCemento()
        'Iniciar carga de cemento
        'Validar que no se active si la formula indica cero
        If pesoSet3 > 0 Then
            If Var_Carga_CEM_Tornillo = True Then
                PLC_LOGO.WriteSingleCoil(Variables.coil_CargaCem2_Tornillo, True)
                Pil_CargaCemTor.DiscreteValue1 = True
                Pil_Carga_Cem_Compuerta.DiscreteValue1 = False
                Sym_Torn_Cem_Carga.DiscreteValue1 = True
                Sym_CargaCem.DiscreteValue1 = False
            Else
                PLC_LOGO.WriteSingleCoil(Variables.coil_CargaCem1_Comp_Gravedad, True)
                Pil_CargaCemTor.DiscreteValue1 = False
                Pil_Carga_Cem_Compuerta.DiscreteValue1 = False
                Sym_Torn_Cem_Carga.DiscreteValue1 = False
                Sym_CargaCem.DiscreteValue1 = True
            End If
            Pil_CargaCemento.DiscreteValue1 = True
            Sym_Cemento.Visible = True
            Sym_Cemento.DiscreteValue1 = True
        End If

        CambiaEstado_Label(Variables.reg_Lbl_Cem, "CARGANDO...", Color.Green)

        Pb_Tol3.Maximum = Convert.ToInt32(pesoSet3)

        Rtx_Mensajes.AppendColoredText("Iniciando carga de cemento" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        Tim_Carga_Cem.Enabled = True
    End Sub
    Private Async Sub FinalizarCargaCemento()
        Try
            'Tim_Carga_Cem.Enabled = False
            flagFinCargaCemento = True
            If Var_Carga_CEM_Tornillo = True Then
                PLC_LOGO.WriteSingleCoil(Variables.coil_CargaCem2_Tornillo, False)
                Pil_CargaCemTor.DiscreteValue1 = False
                Sym_Torn_Cem_Carga.DiscreteValue1 = False
            Else
                PLC_LOGO.WriteSingleCoil(Variables.coil_CargaCem1_Comp_Gravedad, False)
                Pil_Carga_Cem_Compuerta.DiscreteValue1 = False
                Sym_CargaCem.DiscreteValue1 = False
            End If

            Pil_CargaCemento.DiscreteValue1 = False
            Sym_Cemento.Visible = False
            Sym_Cemento.DiscreteValue1 = False

            'Procesar guardar peso
            Await DelayMs(4000) '---Espera estabilidad del peso
            pesoReal3 = Convert.ToDouble(Lbl_Peso_Cem.Text)
            Dim Diferencia As Double = pesoSet3 - pesoReal3

            'Guardar registro de pesada
            Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, Variables.CodigProducto, Variables.NombreProducto, Variables.CodigIngrediente_T3, Variables.NombreIngrediente_T3,
                                        pesoSet3, pesoReal3, Variables.Factor)
            Pb_Tol3.Maximum = CInt(pesoReal3)
            Pb_Tol3.Value = CInt(pesoReal3)
            Lbl_Dosif_Cemento.Text = pesoReal3.ToString("N2")
            CambiaProceso_Labels(Variables.reg_Lbl_Cem, pesoReal3.ToString("N2"), Diferencia.ToString("N2"))
            CambiaEstado_Label(Variables.reg_Lbl_Cem, "FIN CARGA", Color.DarkGreen)
            Rtx_Mensajes.AppendColoredText("Carga de cemento finalizada" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
            Await DelayMs(4000) '---Espera para iniciar la descarga
            IniciarDescargaCemento()
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText("Excepción: Finalizar carga de cemento" & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try

    End Sub

    Private Sub IniciarDescargaCemento()
        'Iniciar descarga de cemento
        If pesoSet3 > 0 Then
            PLC_LOGO.WriteSingleCoil(Variables.coil_Desc2_Compuerta_Cemento, True)
            Pil_Desc_Cem_Compuerta.DiscreteValue1 = True
            PLC_LOGO.WriteSingleCoil(Variables.coil_Desc2_Transpor_Cemento, True)
            Pil_Desc_Cem_Tornillo.DiscreteValue1 = True
            Pil_DesCemento.DiscreteValue1 = True
            Sym_DescargaCem.DiscreteValue1 = True
            Sym_Torn_Cem_Desc.DiscreteValue1 = True
        End If

        CambiaEstado_Label(Variables.reg_Lbl_Cem, "DESCARGANDO...", Color.Orange)
        Rtx_Mensajes.AppendColoredText("Iniciando descarga de cemento" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        Tim_Desc_Cemento.Enabled = True
    End Sub
    Private Sub FinalizarDescargaCemento()
        'Finalizar carga de cemento
        flagFinDesCargaCemento = True
        'Tim_Desc_Cemento.Enabled = False

        PLC_LOGO.WriteSingleCoil(Variables.coil_Desc2_Compuerta_Cemento, False)
        Pil_Desc_Cem_Compuerta.DiscreteValue1 = False
        PLC_LOGO.WriteSingleCoil(Variables.coil_Desc2_Transpor_Cemento, False)
        Pil_Desc_Cem_Tornillo.DiscreteValue1 = False

        Pil_DesCemento.DiscreteValue1 = False

        Sym_DescargaCem.DiscreteValue1 = False
        Sym_Torn_Cem_Desc.DiscreteValue1 = False

        CambiaEstado_Label(Variables.reg_Lbl_Cem, "FINALIZADO", Color.Red)
        Rtx_Mensajes.AppendColoredText("Descarga de cemento finalizada" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        If flagFinTolv2 And flagFinAgua And flagFinDesCargaCemento Then
            FinalizaBatch()
        End If
    End Sub
    Private Sub Iniciar_Apagar_Banda(estado As Boolean)
        'Controla encendido y apagado de banda transportadora
        PLC_LOGO.WriteSingleCoil(Variables.coil_BandaTransport, estado)
        Pil_Banda.DiscreteValue1 = estado
        Sym_Banda.DiscreteValue1 = estado
        Sym_MotorBanda.DiscreteValue1 = estado
        If estado = True Then
            Rtx_Mensajes.AppendColoredText("Elevadora encendida" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        Else
            Rtx_Mensajes.AppendColoredText("Elevadora apagada" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        End If
    End Sub

    Private Sub Btt_Detener_Click(sender As Object, e As EventArgs) Handles Btt_Detener.Click
        If running Then
            If MessageBox.Show("Desea finalizar el proceso", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                DetenerProceso()
                LimpiarLabelsFormula()
                Gbx_ConfigCarg_Cemento.Enabled = True
                GBx_Preparacion.Enabled = True
            End If
        End If

    End Sub
    Private Sub DetenerProceso()
        Try
            If running Then  'Deshabilita timers
                Tim_DescargaT1.Enabled = False
                Tim_DescargaT2.Enabled = False
                Tim_Carga_Cem.Enabled = False
                Tim_Desc_Cemento.Enabled = False
                Tim_Carga_Agua.Enabled = False
                'Envia señal de parada al PLC
                ResetTodasSignals()
                PLC_LOGO.WriteSingleCoil(Variables.coil_Paro, True)
                'Detiene el timer de WD 
                Tim_Wd_PLC.Enabled = False
                running = False
                'RESET DE VARIABLES DE PROCESO------
                flagConfigSetpoints = False
                flagFinAgua = False
                flagFinParcialAgua = False
                flagFinCargaCemento = False
                flagFinDesCargaCemento = False
                flagFinParcialTolv1 = False
                flagFinParcialTolv2 = False
                flagFinTolv1 = False
                flagFinTolv2 = False
                '---------------------------------
                Panel2.BackColor = SystemColors.Control
                'Reset todos los controles (Pilotos)
                Pil_Dosifica.DiscreteValue1 = False
                Pil_Setpoints.DiscreteValue1 = False
                Pil_DescargaT1.DiscreteValue1 = False
                Pil_ActivaT1.DiscreteValue1 = False
                Pil_ApagaT1.DiscreteValue1 = False
                Pil_DescargaT2.DiscreteValue1 = False
                Pil_ActivaT2.DiscreteValue1 = False
                Pil_ApagaT2.DiscreteValue1 = False
                Pil_Bomba.DiscreteValue1 = False
                Pil_Banda.DiscreteValue1 = False
                Pil_CargaCemento.DiscreteValue1 = False
                Pil_CargaCemTor.DiscreteValue1 = False
                Pil_Carga_Cem_Compuerta.DiscreteValue1 = False
                Pil_DesCemento.DiscreteValue1 = False
                Pil_Desc_Cem_Tornillo.DiscreteValue1 = False
                Pil_Desc_Cem_Compuerta.DiscreteValue1 = False

                'Resetar controles (Visualizacion) 
                Sym_DescT1.DiscreteValue1 = False
                Sym_Piedra.DiscreteValue1 = False
                Sym_Piedra.Visible = False
                Sym_DescT2.DiscreteValue1 = False
                Sym_Arena.DiscreteValue1 = False
                Sym_Arena.Visible = False
                Sym_Bomba.DiscreteValue1 = False
                Sym_Bomba_G1.DiscreteValue1 = False
                Sym_Bomba_G2.DiscreteValue1 = False
                Sym_Bomba_G3.DiscreteValue1 = False
                Sym_Bomba_G4.DiscreteValue1 = False
                Sym_Bomba_G5.DiscreteValue1 = False
                Sym_Bomba_G6.DiscreteValue1 = False
                Sym_Bomba_G7.DiscreteValue1 = False
                Sym_Banda.DiscreteValue1 = False
                Sym_MotorBanda.DiscreteValue1 = False

                Sym_CargaCem.DiscreteValue1 = False
                Sym_Cemento.DiscreteValue1 = False
                Sym_Cemento.Visible = False
                Sym_Torn_Cem_Carga.DiscreteValue1 = False
                Sym_DescargaCem.DiscreteValue1 = False
                Sym_Torn_Cem_Desc.DiscreteValue1 = False
                'Resetea valores de controles 
                'Lbl_Dosif_T1.Text = "0.00"
                'Lbl_Dosif_T2.Text = "0.00"
                'Lbl_Dosif_Cemento.Text = "0.00"
                'Lbl_Dosif_Agua.Text = "0.00"
                'Resetea valores de Controles de Formula
                '*****************************************************
                'LimpiarLabelsFormula()
                '*****************************************************
                'Control de botoner
                running = False
                Btt_Iniciar.Enabled = True
                Btt_Continuar.Visible = False
                Btt_Detener.Enabled = False
                Btt_Salir.Enabled = True

            End If
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText("Excepcion: Detener" & ex.Message & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        End Try
    End Sub

    Private Sub Btt_Continuar_Click(sender As Object, e As EventArgs) Handles Btt_Continuar.Click
        Try
            'Iniciar dosificacion total de agua
            IniciarCargaTotalAgua()
            'Iniciar descarga de piedra
            IniciarDescargaTotalT1()
            'Deshabilita boton incio
            Btt_Continuar.Visible = False
            Btt_Iniciar.Enabled = False
            Btt_Detener.Enabled = True
            Btt_Salir.Enabled = False
            Panel2.BackColor = Color.DarkSeaGreen
            Lbl_Info.Text = $"Dosificando Batch {batchActual} de {NumBatchPlanificacion}"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepcion Continuar Batch", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Async Sub IniciarDescargaParcialT1()
        If pesoSet1 > 0 Then
            PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol1, False)
            Pil_ApagaT1.DiscreteValue1 = False
            PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol1, True)
            Pil_ActivaT1.DiscreteValue1 = True
            Pil_DescargaT1.DiscreteValue1 = True 'Activa piloto de descarga de T1
            Await DelayMs(2000)
            PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol1, False)
            Pil_ActivaT1.DiscreteValue1 = False

            Sym_DescT1.DiscreteValue1 = True
            Sym_Piedra.Visible = True
            Sym_Piedra.DiscreteValue1 = True
        End If
        Pb_Tol1.Maximum = Convert.ToInt32(pesoSet1)
        Tim_DescargaT1.Enabled = True
        'Inicia descarga de Piedra -- Tolva 1
        CambiaEstado_Label(Variables.reg_Lbl_Tolv1, "DESCARGANDO PARCIAL...", Color.DarkGreen)
        Rtx_Mensajes.AppendColoredText("Iniciando descarga parcial de Tolva 1" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
    End Sub
    Private Async Sub IniciarDescargaTotalT1()
        If pesoSet1 > 0 Then
            PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol1, False)
            Pil_ApagaT1.DiscreteValue1 = False
            PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol1, True)
            Pil_ActivaT1.DiscreteValue1 = True
            Pil_DescargaT1.DiscreteValue1 = True 'Activa piloto de descarga de T1
            Await DelayMs(2000)
            PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol1, False)
            Pil_ActivaT1.DiscreteValue1 = False

            Sym_DescT1.DiscreteValue1 = True
            Sym_Piedra.Visible = True
            Sym_Piedra.DiscreteValue1 = True
        End If

        Tim_DescargaT1.Enabled = True
        'Inicia descarga de Piedra -- Tolva 1
        CambiaEstado_Label(Variables.reg_Lbl_Tolv1, "DESCARGANDO TOTAL...", Color.DarkGreen)
        Rtx_Mensajes.AppendColoredText("Iniciando descarga Total de Tolva 1" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
    End Sub
    Private Async Sub FinDescargaParcialT1()
        PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol1, False)
        Pil_ActivaT1.DiscreteValue1 = False
        PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol1, True)
        Pil_ApagaT1.DiscreteValue1 = True
        Pil_DescargaT1.DiscreteValue1 = False
        Await DelayMs(2000)
        PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol1, False)
        Pil_ApagaT1.DiscreteValue1 = False
        flagFinParcialTolv1 = True

        Sym_DescT1.DiscreteValue1 = False
        Sym_Piedra.Visible = False
        Sym_Piedra.DiscreteValue1 = False
        'Tim_DescargaT1.Enabled = False
        CambiaEstado_Label(Variables.reg_Lbl_Tolv1, "FIN DESCARGA PARCIAL", Color.DarkRed)

        Rtx_Mensajes.AppendColoredText("Descarga parcial de Tolva 1 Finalizada" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
        'Espera 4 segundos para activar la dosificacion parcial de T2
        Await DelayMs(4000)
        IniciarDescargaParcialT2()
    End Sub

    Private Async Sub FinDescargaTotalT1()
        Try

            PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol1, False)
            Pil_ActivaT1.DiscreteValue1 = False
            PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol1, True)
            Pil_ApagaT1.DiscreteValue1 = True
            Pil_DescargaT1.DiscreteValue1 = False
            Await DelayMs(2000)
            PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol1, False)
            Pil_ApagaT1.DiscreteValue1 = False

            Sym_DescT1.DiscreteValue1 = False
            Sym_Piedra.Visible = False
            Sym_Piedra.DiscreteValue1 = False
            'Tim_DescargaT1.Enabled = False

            CambiaEstado_Label(Variables.reg_Lbl_Tolv1, "FINALIZADO", Color.Red)
            flagFinTolv1 = True
            Rtx_Mensajes.AppendColoredText("Descarga Total de Tolva 1 Finalizada" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
            'Procesar guardar peso
            Await DelayMs(4000) '---Espera estabilidad del peso
            pesoReal1 = ValorInicialT1 - Convert.ToDouble(Lbl_Peso_T1.Text)
            Dim Diferencia As Double = pesoSet1 - pesoReal1
            Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, Variables.CodigProducto, Variables.NombreProducto, Variables.CodigIngrediente_T1, Variables.NombreIngrediente_T1,
                                    pesoSet1, pesoReal1, Variables.Factor)
            Rtx_Mensajes.AppendColoredText("Peso T1 Registrado" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
            Lbl_Dosif_T1.Text = pesoReal1.ToString("N2")
            CambiaProceso_Labels(Variables.reg_Lbl_Tolv1, pesoReal1.ToString("N2"), Diferencia.ToString("N2"))
            'Espera 4 segundos para activar la dosificacion parcial de T2
            Await DelayMs(4000)
            IniciarDescargaParcialT2()
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText("Excepción: Fin Desc. Total T1" & ex.Message & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            'DatosDespacho.TopLevel = False
            'Panel2.Controls.Add(DatosDespacho)
            DatosDespacho.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        idDespacho = txtNumDespacho.Text
        Despacho_frm.Show()
    End Sub

    Private Sub Tim_Wd_PLC_Tick(sender As Object, e As EventArgs) Handles Tim_Wd_PLC.Tick
        Estado_WD = Not Estado_WD
        If PLC_LOGO.Connected Then
            PLC_LOGO.WriteSingleCoil(Variables.coil_WDConection, Estado_WD)
        End If
    End Sub

    Private Sub NumericM3_ValueChanged(sender As Object, e As EventArgs) Handles NumericM3.ValueChanged
        If cmbproductos.SelectedIndex > -1 AndAlso cmbproductos.SelectedValue IsNot Nothing AndAlso
            Not TypeOf cmbproductos.SelectedValue Is DataRowView Then
            ObtieneFormulaxProducto(cmbproductos.SelectedValue.ToString)
        End If
    End Sub

    Private Sub Num_Hum_Arena_ValueChanged(sender As Object, e As EventArgs) Handles Num_Hum_Arena.ValueChanged
        If cmbproductos.SelectedIndex > -1 AndAlso cmbproductos.SelectedValue IsNot Nothing AndAlso
            Not TypeOf cmbproductos.SelectedValue Is DataRowView Then
            ObtieneFormulaxProducto(cmbproductos.SelectedValue.ToString)
        End If
    End Sub

    Private Sub Num_Hum_Ripio_ValueChanged(sender As Object, e As EventArgs) Handles Num_Hum_Ripio.ValueChanged
        If cmbproductos.SelectedIndex > -1 AndAlso cmbproductos.SelectedValue IsNot Nothing AndAlso
            Not TypeOf cmbproductos.SelectedValue Is DataRowView Then
            ObtieneFormulaxProducto(cmbproductos.SelectedValue.ToString)
        End If
    End Sub

    Private Sub RBtt_CargCemTornillo_CheckedChanged(sender As Object, e As EventArgs) Handles RBtt_CargCemTornillo.CheckedChanged
        Var_Carga_CEM_Tornillo = RBtt_CargCemTornillo.Checked
    End Sub
    Private Async Sub IniciarDescargaParcialT2()
        'Inicia descarga de Piedra -- Tolva 2
        'Verifica que no se active si la formula corresponde a cero
        If pesoSet2 > 0 Then
            PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol2, False)
            Pil_ApagaT2.DiscreteValue1 = False
            PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol2, True)
            Pil_ActivaT2.DiscreteValue1 = True
            Pil_DescargaT2.DiscreteValue1 = True
            Await DelayMs(2000)
            PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol2, False)
            Pil_ActivaT2.DiscreteValue1 = False

            Sym_DescT2.DiscreteValue1 = True
            Sym_Arena.Visible = True
            Sym_Arena.DiscreteValue1 = True
        End If
        Pb_Tol2.Maximum = Convert.ToInt32(pesoSet2)
        CambiaEstado_Label(Variables.reg_Lbl_Tolv2, "DESCARGANDO PARCIAL...", Color.Orange)
        Rtx_Mensajes.AppendColoredText("Iniciando descarga parcial de Tolva 2" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        Tim_DescargaT2.Enabled = True
    End Sub

    Private Async Sub IniciarDescargaTotalT2()
        'Inicia descarga de Piedra -- Tolva 2
        'Verifica que no se active si la formula corresponde a cero
        If pesoSet2 > 0 Then
            PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol2, False)
            Pil_ApagaT2.DiscreteValue1 = False
            PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol2, True)
            Pil_ActivaT2.DiscreteValue1 = True
            Pil_DescargaT2.DiscreteValue1 = True
            Await DelayMs(2000)
            PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol2, False)
            Pil_ActivaT2.DiscreteValue1 = False

            Sym_DescT2.DiscreteValue1 = True
            Sym_Arena.Visible = True
            Sym_Arena.DiscreteValue1 = True
        End If
        CambiaEstado_Label(Variables.reg_Lbl_Tolv2, "DESCARGANDO TOTAL...", Color.DarkGreen)
        Rtx_Mensajes.AppendColoredText("Iniciando descarga Total de Tolva 2" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        Tim_DescargaT2.Enabled = True
    End Sub
    Private Async Sub FinDescargaParcialT2()
        flagFinParcialTolv2 = True
        PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol2, False)
        Pil_ActivaT2.DiscreteValue1 = False
        PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol2, True)
        Pil_ApagaT2.DiscreteValue1 = True
        Pil_DescargaT2.DiscreteValue1 = False
        Await DelayMs(2000)
        PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol2, False)
        Pil_ApagaT2.DiscreteValue1 = False

        Sym_DescT2.DiscreteValue1 = False
        Sym_Arena.Visible = False
        Sym_Arena.DiscreteValue1 = False
        'Tim_DescargaT2.Enabled = False
        CambiaEstado_Label(Variables.reg_Lbl_Tolv2, "FIN DESCARGA PARCIAL", Color.DarkRed)
        Rtx_Mensajes.AppendColoredText("Descarga parcial de Tolva 2 Finalizada" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        'Verifica si es el ultimo ingrediente dosificado parcial
        If flagFinParcialAgua And flagFinParcialTolv2 Then
            Btt_Continuar.Visible = True
            Panel2.BackColor = Color.Moccasin
            Lbl_Info.Text = "Presione 'Continuar' para terminar la dosificacion"
        End If
    End Sub
    Private Async Sub FinDescargaTotalT2()

        PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol2, False)
        Pil_ActivaT2.DiscreteValue1 = False
        PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol2, True)
        Pil_ApagaT2.DiscreteValue1 = True
        Pil_DescargaT2.DiscreteValue1 = False

        Await DelayMs(2000)
        PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol2, False)
        Pil_ApagaT2.DiscreteValue1 = False

        Sym_DescT2.DiscreteValue1 = False
        Sym_Arena.Visible = False
        Sym_Arena.DiscreteValue1 = False
        'Tim_DescargaT2.Enabled = False

        'Procesar guardar peso
        Await DelayMs(4000) '---Espera estabilidad del peso
        pesoReal2 = ValorInicialT2 - Convert.ToDouble(Lbl_Peso_T2.Text)
        Dim Diferencia As Double = pesoSet2 - pesoReal2
        'Guardar registro de pesada
        Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, Variables.CodigProducto, Variables.NombreProducto, Variables.CodigIngrediente_T2, Variables.NombreIngrediente_T2,
                                    pesoSet2, pesoReal2, Variables.Factor)
        Lbl_Dosif_T2.Text = pesoReal2.ToString("N2")
        CambiaProceso_Labels(Variables.reg_Lbl_Tolv2, pesoReal2.ToString("N2"), Diferencia.ToString("N2"))
        CambiaEstado_Label(Variables.reg_Lbl_Tolv2, "FINALIZADO", Color.Red)
        flagFinTolv2 = True
        Rtx_Mensajes.AppendColoredText("Descarga Total de Tolva 2 Finalizada" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)

        'Detener banda
        Await DelayMs(6000) ' 6 segundos sin bloquear
        Iniciar_Apagar_Banda(False)
        'Verifica si es el ultimo ingrediente dosificado parcial
        If flagFinTolv2 And flagFinAgua And flagFinCargaCemento Then
            FinalizaBatch()
        End If
    End Sub
    Private Sub LimpiaControlesFormula()

    End Sub
    Private Sub FinalizaBatch()
        If batchPendientes = 0 Then
            DetenerProceso()
            Lbl_Info.Text = "Batchs Completos"
            GBx_Preparacion.Enabled = True
            Gbx_ConfigCarg_Cemento.Enabled = True
            MessageBox.Show("Fin de Dosificacion", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            DetenerProceso()
            flagConfigSetpoints = True
            Pil_Setpoints.DiscreteValue1 = True
            ObtieneFormulaxProducto(cmbproductos.SelectedValue.ToString)
            Gbx_ConfigCarg_Cemento.Enabled = True
            Lbl_Info.Text = $"Batch {batchActual} de {NumBatchPlanificacion} Finalizado" & vbCrLf & "Presione Iniciar para continuar con el siguiente batch"
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
                Dim lblEstado As Label = BuscarLabel("Lbl_Estado" & i)
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
                If lblEstado IsNot Nothing Then
                    lblEstado.Text = ""
                    lblEstado.Visible = True
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
            flagConfigSetpoints = False
            Pil_Setpoints.DiscreteValue1 = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtieneFormulaxProducto(idProducto As String)
        Dim dt As New DataTable
        Try
            'Obtener la cantidad de m3 para el ajuste de la formula
            CantidadM3 = NumericM3.Value
            'Obtener el factor de humedad de arena y ripio
            FactorHumedad_Arena = Num_Hum_Arena.Value
            FactorHumedad_Ripio = Num_Hum_Ripio.Value

            Using conection As New OleDbConnection(sConnString)
                Using cmdd As New OleDbCommand
                    cmdd.Connection = conection
                    cmdd.CommandText = "SELECT 
                                        DF.Num_Tolva AS [Num Tolva], 
                                        NT.descripcion AS [Tolva],
                                        DF.Id_ingrediente AS [Cod Ingrediente], 
                                        ING.Descripcion AS [Ingrediente],
                                        DF.Cantidad, 
                                        DF.Id_formula AS [Cod Producto],
                                        PR.Descripcion AS [Nombre Producto]

                                    FROM 
                                        ((DetalleFormulas AS DF 
                                        INNER JOIN NumeroTolvasTanques AS NT 
                                            ON DF.Num_Tolva = NT.id)
                                        INNER JOIN Ingredientes AS ING 
                                            ON DF.Id_ingrediente = ING.Id_ingrediente)
                                        INNER JOIN Productos AS PR
                                            ON DF.Id_formula = PR.Id_Producto
                                    WHERE 
                                        DF.Id_formula = ?
                                    ORDER BY 
                                        DF.Num_Tolva ASC;"
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
                pesoSet1 = Convert.ToDouble(dt.Rows(0).Item("Cantidad")) * CantidadM3 '--Tolva 1 : Arena
                'Ingresar ajuste de humedad de arena
                pesoSet2 = Convert.ToDouble(dt.Rows(1).Item("Cantidad")) * CantidadM3 '--Tolva 2 : Ripio
                'Ingresar ajuste de humedad de ripio
                pesoSet3 = Convert.ToDouble(dt.Rows(2).Item("Cantidad")) * CantidadM3 '--Tolva Cemento
                pesoSet4 = Convert.ToDouble(dt.Rows(3).Item("Cantidad")) * CantidadM3 '--Agua

                'Llenar variables globales de dosificacion----------------------
                Variables.NombreProducto = dt.Rows(0).Item("Nombre Producto")       '--Nombre Producto
                Variables.CodigProducto = dt.Rows(0).Item("Cod Producto")           '--Codigo Producto
                Variables.NombreIngrediente_T1 = dt.Rows(0).Item("Ingrediente")     '--Nombre Ingrediente 1
                Variables.NombreIngrediente_T2 = dt.Rows(1).Item("Ingrediente")     '--Nombre Ingrediente 2
                Variables.NombreIngrediente_T3 = dt.Rows(2).Item("Ingrediente")     '--Nombre Ingrediente 3
                Variables.NombreIngrediente_T4 = dt.Rows(3).Item("Ingrediente")     '--Nombre Ingrediente 4
                Variables.CodigIngrediente_T1 = dt.Rows(0).Item("Cod Ingrediente")  '--Codigo Ingrediente 1
                Variables.CodigIngrediente_T2 = dt.Rows(1).Item("Cod Ingrediente")  '--Codigo Ingrediente 1
                Variables.CodigIngrediente_T3 = dt.Rows(2).Item("Cod Ingrediente")  '--Codigo Ingrediente 1
                Variables.CodigIngrediente_T4 = dt.Rows(3).Item("Cod Ingrediente")  '--Codigo Ingrediente 1

                '---------------------------------------------------------------
                flagConfigSetpoints = True
                Pil_Setpoints.DiscreteValue1 = True
            Else
                flagConfigSetpoints = False
                Pil_Setpoints.DiscreteValue1 = False
            End If

            'Llenar los Labels
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim idx As Integer = i + 1
                Dim lblTolva As Label = BuscarLabel("Lbl_Tolv" & idx)
                Dim lblIng As Label = BuscarLabel("Lbl_Ing" & idx)
                Dim lblCanTeo As Label = BuscarLabel("Lbl_CanTeo" & idx)
                Dim lblCanReal As Label = BuscarLabel("Lbl_CanRea" & idx)
                Dim lblEstado As Label = BuscarLabel("Lbl_Estado" & idx)
                Dim lblDifer As Label = BuscarLabel("Lbl_Dif" & idx)
                Dim PgBar As ProgressBar = BuscarPgBar("Pb_Tol" & idx)

                If lblTolva Is Nothing Then Continue For

                lblTolva.Text = dt.Rows(i).Item("Tolva").ToString()
                lblIng.Text = dt.Rows(i).Item("Ingrediente").ToString()
                lblCanTeo.Text = (dt.Rows(i).Item("Cantidad") * CantidadM3).ToString()
                lblCanReal.Text = "0"
                lblEstado.Text = ""
                lblDifer.Text = "0"
                PgBar.Visible = True
                PgBar.Value = 0
            Next


        Catch ex As Exception
            flagConfigSetpoints = False
            Pil_Setpoints.DiscreteValue1 = False
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


    Private Sub Btt_ReCon_T1_Click(sender As Object, e As EventArgs) Handles Btt_ReCon_T1.Click

    End Sub

    Private Sub Btt_ReCon_T2_Click(sender As Object, e As EventArgs) Handles Btt_ReCon_T2.Click

    End Sub

    Private Sub Btt_ReCon_Cemento_Click(sender As Object, e As EventArgs) Handles Btt_ReCon_Cemento.Click

    End Sub
End Class
