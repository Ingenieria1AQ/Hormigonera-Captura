Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports System.Text

Public Class Proceso_Andina
    'Llamar a la clase de indicador Serial
    Private IndicadorTolv1 As Indicador_Serial
    Private IndicadorTolv2 As Indicador_Serial 'CLIENTE USA UN INDICADOR PARA ARIDOS
    Private IndicadorCemento As Indicador_Serial

    'Variables de Formulacion
    Private ID_OrdenDespacho As String
    Private ID_ProductoFormula As String

    Private da As OleDbDataAdapter
    Private ds As New DataSet
    Private numTolvas_Serial As Integer = 2
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
    Private CantidadM3 As Double = 1.0
    Private FactorHumedad_Arena As Double = 1
    Private FactorHumedad_Piedra As Double = 1
    Private FactorAbsorcion_Arena As Double = 1
    Private FactorAbsorcion_Piedra As Double = 1

    Private Var_Carga_CEM_Tornillo As Boolean = False
    Private Var_CArga_CEM_Compuerta As Boolean = False

    Private Estado_WD As Boolean = False
    Private flagConfigTolvas As Boolean = False
    Private flagConfigPLC As Boolean = False
    Private flagConfigSetpoints As Boolean = False
    Private flagVersiones As Boolean = False

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

    Private VersionInicial As Integer
    Private VersionFinal As Integer
    Private CabeceraImpr As String = "EUFRATES "

    '**VARIABLES: CAMBIOS PARA ANDINA DE HORMIGONES
    Dim tipoTrans As String = "Entra"
    Dim codigoOD As Long
    Private flagTolva1Ser_Iniciada As Boolean = False
    Private flagTolva2Ser_Iniciada As Boolean = False
    Private flagTolvaCementoSer_Iniciada As Boolean = False

    '*-*-*-*-**-*-*-*-*-*-*-*
    Private Sub Proceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Obtener variables de la tabla de configuracion
        Me.WindowState = WindowState.Maximized
        'Principal.Panel1.Visible = False
        Lbl_Info.Text = String.Empty
        Lbl_NombreFormula.Text = String.Empty
        Lbl_Operador.Text = Variables.nomOperador

        'Leer tabla de configuracion
        nombreImpresora = Funciones.Obtener_Valor_Configuracion("Nombre_Impresora")
        flagUsaImpresora = Convert.ToBoolean(Funciones.Obtener_Valor_Configuracion("UsaImpresora") = "1")
        DirPLC = Funciones.Obtener_Valor_Configuracion("PLC_IP")
        PuertoPLC = Convert.ToInt32(Funciones.Obtener_Valor_Configuracion("PLC_Puerto"))
        FactorAgua = Convert.ToDouble(Funciones.Obtener_Valor_Configuracion("FactorAgua"))


        Variables.CodigIngrediente_T1 = Funciones.Obtener_Valor_Configuracion("ID_Ingrediente_T1")  '--Codigo Ingrediente 1
        Variables.CodigIngrediente_T2 = Funciones.Obtener_Valor_Configuracion("ID_Ingrediente_T2")  '--Codigo Ingrediente 2
        Variables.CodigIngrediente_T3 = Funciones.Obtener_Valor_Configuracion("ID_Ingrediente_Cem")  '--Codigo Ingrediente 3
        Variables.CodigIngrediente_T4 = Funciones.Obtener_Valor_Configuracion("ID_Ingrediente_Agua")  '--Codigo Ingrediente 4

        'Lee nombres de ingredientes en tolvas
        Variables.NombreIngrediente_T1 = Funciones.Obtener_NomIngrediente_x_ID(CodigIngrediente_T1)     '--Nombre Ingrediente 1
        Variables.NombreIngrediente_T2 = Funciones.Obtener_NomIngrediente_x_ID(CodigIngrediente_T2)     '--Nombre Ingrediente 2
        Variables.NombreIngrediente_T3 = Funciones.Obtener_NomIngrediente_x_ID(CodigIngrediente_T3)     '--Nombre Ingrediente 3
        Variables.NombreIngrediente_T4 = Funciones.Obtener_NomIngrediente_x_ID(CodigIngrediente_T4)     '--Nombre Ingrediente 4
        'Asigna nombres a Controles
        Lbl_IngInfT1.Text = NombreIngrediente_T1
        Lbl_IngNomT1.Text = NombreIngrediente_T1

        Lbl_IngNomT2.Text = NombreIngrediente_T2
        NombreIngrediente_T2 = NombreIngrediente_T2

        Lbl_IngNomT3.Text = NombreIngrediente_T3
        NombreIngrediente_T3 = NombreIngrediente_T3

        Lbl_IngNomT4.Text = NombreIngrediente_T4
        NombreIngrediente_T4 = NombreIngrediente_T4


        'consecutivoBatch = Convert.ToInt32(Funciones.Obtener_Valor_Configuracion("ConsecutivoBatch"))

        'Muestra IP del PLC
        Lbl_IpAdd.Text = DirPLC
        Lbl_Puerto.Text = PuertoPLC.ToString

        'CargaProductos() --No se usa para A.Hormigones
        flagConfigPLC = Configura_Inicializa_PLC()
        Pil_PLC.DiscreteValue1 = flagConfigPLC
        'LimpiarLabelsFormula() --No se usa para A.Hormigones
        'Configuracion serial y Extrae Puntos de corte de las tolvas
        If Cargar_y_Configurar_Tolvas() = True Then
            flagTolva1Ser_Iniciada = True
            'flagTolva2Ser_Iniciada = True
            flagTolvaCementoSer_Iniciada = True
        Else
            MessageBox.Show("Error en la configuración de puerto serial de las tolvas consulte con el administrador", "Error de Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flagTolva1Ser_Iniciada = False
            'flagTolva2Ser_Iniciada = False
            flagTolvaCementoSer_Iniciada = False
        End If

        If flagConfigPLC Then
            Tim_ReadHR.Enabled = True
        Else
            'habilitar reconexion del PLC
        End If
    End Sub

    Private Sub PesoT1_Recibido(peso As Decimal)
        BeginInvoke(Sub()
                        Lbl_Peso_T1.Text = peso.ToString("N0") 'Peso con 2 decimales
                    End Sub)
    End Sub
    Private Sub PesoT2_Recibido(peso As Decimal)
        BeginInvoke(Sub()
                        Lbl_Peso_T2.Text = peso.ToString("N0") 'Peso con 2 decimales
                    End Sub)
    End Sub
    Private Sub pesoCem_Recibido(peso As Decimal)
        BeginInvoke(Sub()
                        Lbl_Peso_Cem.Text = peso.ToString("N0") 'Peso con 2 decimales
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
            'PLC_LOGO.SerialPort = Nothing

            PLC_LOGO.ConnectionTimeout = 1000
            'Registrar evento de cambio de conexion
            PLC_LOGO.Connect()
            If PLC_LOGO.Connected Then
                Lbl_Est_Conn.Text = "Conectado"
                Lbl_Est_Conn.ForeColor = Color.Green
                Btt_ReconectaPLC.Enabled = False
                flagConfigPLC = True
                Pil_PLC.DiscreteValue1 = True
                rpta = True
            Else
                Lbl_Est_Conn.Text = "Desconectado"
                Lbl_Est_Conn.ForeColor = Color.Red
                Btt_ReconectaPLC.Enabled = True
                flagConfigPLC = False
                Pil_PLC.DiscreteValue1 = False
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

    Private Function Cargar_y_Configurar_Tolvas() As Boolean
        Try
            '1: Cargar configuracion de tolvas
            Dim cmdTxt As String = ""
            Select Case Variables.tipoBD
                Case "ACCESS"
                    cmdTxt = "SELECT * FROM NumeroTolvasTanques WHERE UsaSerial=True  ORDER BY id"
                Case "SQLSERVER"
                    cmdTxt = "SELECT * FROM NumeroTolvasTanques WHERE UsaSerial=1  ORDER BY id"
            End Select
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

            'Validar puertos COM configurados
            For Each fila As DataRow In tbTolvas.Rows
                If Convert.ToInt32(fila.Item("id")) <> 2 Then
                    If IsDBNull(fila.Item("PuertoCOM")) Or fila.Item("PuertoCOM") = String.Empty Then
                        Rtx_Mensajes.AppendColoredText(
                        $"Error de configuración serial en la Tolva {fila.Item("descripcion")}" & Environment.NewLine,
                        Drawing.Color.Red,
                        font_Rtxt)
                        Return False
                    End If
                End If
            Next


            'Habilitar si se requiere obtener los valores de corte
            'corteT1 = Double.Parse(Funciones.Obtener_Valor_Configuracion("CortePiedra"))
            'corteT2 = Double.Parse(Funciones.Obtener_Valor_Configuracion("CorteArena"))
            'corteCemento = Double.Parse(Funciones.Obtener_Valor_Configuracion("CorteCemento"))
            'corteAgua = Double.Parse(Funciones.Obtener_Valor_Configuracion("CorteAgua"))

            'Andina de hormigones no controla Cortes
            corteT1 = 0.0
            corteT2 = 0.0
            corteCemento = 0.0
            corteAgua = 0.0

            IndicadorTolv1 = New Indicador_Serial(tbTolvas.Rows(0).Item("PuertoCOM"), Convert.ToInt32(tbTolvas.Rows(0).Item("BaudRate")), tbTolvas.Rows(0).Item("TipoIndicador"))
            'No usa A. Hormigones
            'IndicadorTolv2 = New Indicador_Serial(tbTolvas.Rows(1).Item("PuertoCOM"), Convert.ToInt32(tbTolvas.Rows(1).Item("BaudRate")), tbTolvas.Rows(1).Item("TipoIndicador"))
            IndicadorCemento = New Indicador_Serial(tbTolvas.Rows(2).Item("PuertoCOM"), Convert.ToInt32(tbTolvas.Rows(2).Item("BaudRate")), tbTolvas.Rows(2).Item("TipoIndicador"))

            AddHandler IndicadorTolv1.PesoRecibido, AddressOf PesoT1_Recibido
            'AddHandler IndicadorTolv2.PesoRecibido, AddressOf PesoT2_Recibido --'No usa A. Hormigones
            AddHandler IndicadorCemento.PesoRecibido, AddressOf pesoCem_Recibido

            AddHandler IndicadorTolv1.EstadoCambiado, AddressOf EstadoT1
            'AddHandler IndicadorTolv2.EstadoCambiado, AddressOf EstadoT2 'No usa A. Hormigones
            AddHandler IndicadorCemento.EstadoCambiado, AddressOf EstadoCemento

            IndicadorTolv1.Conectar()
            'IndicadorTolv2.Conectar() -- 'No usa A. Hormigones
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
            Return True
        Catch ex As Exception
            MessageBox.Show(
            ex.Message,
            "Excepción: Carga y Configuración de Tolvas",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
            Return False
        End Try
    End Function



    Private Sub ReadHoldingRegister()
        Try
            Block_lectura_HR = PLC_LOGO.ReadHoldingRegisters(0, 3)
            Dim litros As Decimal
            litros = Block_lectura_HR(Variables.dir_ContadorFlujometro) * FactorAgua
            Lbl_Agua.Text = litros.ToString("N0") 'Litros con 2 decimales
        Catch ex As Exception
            If PLC_LOGO.Connected Then
                PLC_LOGO.Disconnect()
            End If
            Lbl_Est_Conn.Text = "Desconectado"
            Lbl_Est_Conn.ForeColor = Color.Red
            Btt_ReconectaPLC.Enabled = True
            Tim_ReadHR.Enabled = False
            flagConfigPLC = False
            Pil_PLC.DiscreteValue1 = False
        End Try
    End Sub
    Private Sub ReadCoils()
        Try
            If PLC_LOGO.Connected Then
                Block_lectura_Coils = PLC_LOGO.ReadCoils(0, 12)
                ProcesaCoils()
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ProcesaCoils()
        Dim banda, cierraPiedra, abrePiedra, cierraArena, abreArena, cargaCem_Compuerta, cargaCem_Tornillo,
        descargaCem_Comp, bomba, descargaCem_Tornillo As Boolean
        'Lectura de estado de las salidas del PLC
        banda = Block_lectura_Coils(Variables.dir_coil_Banda)
        cierraPiedra = Block_lectura_Coils(Variables.dir_coil_CierraPiedra)
        abrePiedra = Block_lectura_Coils(Variables.dir_coil_AbrePiedra)
        cierraArena = Block_lectura_Coils(Variables.dir_coil_CierraArena)
        abreArena = Block_lectura_Coils(Variables.dir_coil_AbreArena)
        cargaCem_Compuerta = Block_lectura_Coils(Variables.dir_coil_CargaCem_Com)
        cargaCem_Tornillo = Block_lectura_Coils(Variables.dir_coil_CargaCem_Tor)
        descargaCem_Comp = Block_lectura_Coils(Variables.dir_coil_DescCem_Com)
        bomba = Block_lectura_Coils(Variables.dir_coil_Bomba)
        descargaCem_Tornillo = Block_lectura_Coils(Variables.dir_coil_DescCem_Tor)

        'Representación grafica en los estados de la interfaz
        Pil_ActivaT1.DiscreteValue1 = abrePiedra
        Pil_ApagaT1.DiscreteValue1 = cierraPiedra
        Pil_ActivaT2.DiscreteValue1 = abreArena
        Pil_ApagaT2.DiscreteValue1 = cierraArena
        Pil_Banda.DiscreteValue1 = banda
        Pil_Carga_Cem_Compuerta.DiscreteValue1 = cargaCem_Compuerta
        Pil_CargaCemTor.DiscreteValue1 = cargaCem_Tornillo
        Pil_Desc_Cem_Compuerta.DiscreteValue1 = descargaCem_Comp
        Pil_Desc_Cem_Tornillo.DiscreteValue1 = descargaCem_Tornillo

        'Representación de agua
        Pil_Bomba.DiscreteValue1 = bomba
        Sym_Bomba.DiscreteValue1 = bomba
        Sym_Bomba_G1.DiscreteValue1 = bomba
        Sym_Bomba_G2.DiscreteValue1 = bomba
        Sym_Bomba_G3.DiscreteValue1 = bomba
        Sym_Bomba_G4.DiscreteValue1 = bomba
        Sym_Bomba_G5.DiscreteValue1 = bomba
        Sym_Bomba_G6.DiscreteValue1 = bomba
        Sym_Bomba_G7.DiscreteValue1 = bomba
    End Sub

    Private Sub Tim_ReadHR_Tick(sender As Object, e As EventArgs) Handles Tim_ReadHR.Tick
        ReadHoldingRegister()
    End Sub

    Private Sub Tim_Carga_Agua_Tick(sender As Object, e As EventArgs) Handles Tim_Carga_Agua.Tick
        Try
            Dim ValActual As Double = Convert.ToDouble(Lbl_Agua.Text)
            If ValActual <= Pb_Tol4.Maximum And ValActual >= Pb_Tol4.Minimum Then
                Pb_Tol4.Value = ValActual
            ElseIf ValActual < Pb_Tol4.Minimum Then
                Pb_Tol4.Value = Pb_Tol4.Minimum
            Else
                Pb_Tol4.Value = Pb_Tol4.Maximum
            End If

            'If ValActual <= Pb_Tol4.Maximum Then
            '    Pb_Tol4.Value = ValActual
            'Else
            '    Pb_Tol4.Value = Pb_Tol4.Maximum
            'End If
            Lbl_Dosif_Agua.Text = ValActual.ToString("N0")
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
                "Excepcion: Carga Agua " & vbCrLf & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try
    End Sub

    Private Sub Tim_Carga_Cem_Tick(sender As Object, e As EventArgs) Handles Tim_Carga_Cem.Tick
        Try
            Dim valActual As Double = Convert.ToDouble(Lbl_Peso_Cem.Text)
            'Validacion de ProgressBar
            If valActual <= Pb_Tol3.Maximum And valActual >= Pb_Tol3.Minimum Then
                Pb_Tol3.Value = valActual
            ElseIf valActual < Pb_Tol3.Minimum Then
                Pb_Tol3.Value = Pb_Tol3.Minimum
            Else
                Pb_Tol3.Value = Pb_Tol3.Maximum
            End If

            'If valActual <= Pb_Tol3.Maximum Then
            '    Pb_Tol3.Value = valActual
            'Else
            '    Pb_Tol3.Value = Pb_Tol3.Maximum
            'End If

            Lbl_Dosif_Cemento.Text = valActual.ToString("N0")
            Dim Compara As Double = LimiteCemento
            If valActual >= Compara Then
                Tim_Carga_Cem.Enabled = False
                FinalizarCargaCemento()
            End If
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText(
                "Excepcion: Carga Cemento" & vbCrLf & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try
    End Sub
    Private Sub Tim_Desc_Cemento_Tick(sender As Object, e As EventArgs) Handles Tim_Desc_Cemento.Tick
        Try
            Dim valActual As Double = Convert.ToDouble(Lbl_Peso_Cem.Text)
            If valActual <= Pb_Tol3.Maximum And valActual >= Pb_Tol3.Minimum Then
                Pb_Tol3.Value = valActual
            ElseIf valActual < Pb_Tol3.Minimum Then
                Pb_Tol3.Value = Pb_Tol3.Minimum
            Else
                Pb_Tol3.Value = Pb_Tol3.Maximum
            End If

            'If valActual <= Pb_Tol3.Maximum Then
            '    Pb_Tol3.Value = valActual
            'Else
            '    Pb_Tol3.Value = Pb_Tol3.Maximum
            'End If

            Dim Compara As Double = 10
            If valActual <= Compara Then
                Tim_Desc_Cemento.Enabled = False
                FinalizarDescargaCemento()
            End If
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText(
                "Excepcion: Descarga Cemento" & vbCrLf & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try
    End Sub
    Private Sub Tim_DescargaT1_Tick(sender As Object, e As EventArgs) Handles Tim_DescargaT1.Tick
        Try
            Dim ValProceso As Double = ValorInicialT1 - Convert.ToDouble(Lbl_Peso_T1.Text)
            Lbl_Dosif_T1.Text = ValProceso.ToString("N0")
            'Validacion de ProgressBar
            If ValProceso <= Pb_Tol1.Maximum And ValProceso >= Pb_Tol1.Minimum Then
                Pb_Tol1.Value = ValProceso
            ElseIf ValProceso < Pb_Tol1.Minimum Then
                Pb_Tol1.Value = Pb_Tol1.Minimum
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
            Rtx_Mensajes.AppendColoredText(
                "Excepcion: Descarga Piedra" & vbCrLf & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try
    End Sub
    'Private Async Sub DetenerTolva1()
    '    If PLC_LOGO.Connected Then
    '        PLC_LOGO.WriteSingleCoil(Variables.coil_Activa_DescargaTol1, False)
    '        'Pil_ActivaT1.DiscreteValue1 = False
    '        PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol1, True)
    '        Pil_ApagaT1.DiscreteValue1 = True
    '        Await DelayMs(2000)
    '        PLC_LOGO.WriteSingleCoil(Variables.coil_Desactiva_DescargaTol1, False)
    '        Pil_ApagaT1.DiscreteValue1 = False
    '    End If
    'End Sub

    Private Sub Tim_DescargaT2_Tick(sender As Object, e As EventArgs) Handles Tim_DescargaT2.Tick
        Try
            Dim ValProceso As Double = ValorInicialT2 - Convert.ToDouble(Lbl_Peso_T2.Text)
            Lbl_Dosif_T2.Text = ValProceso.ToString("N0")
            'Validacion de ProgressBar
            If ValProceso <= Pb_Tol2.Maximum And ValProceso >= Pb_Tol2.Minimum Then
                Pb_Tol2.Value = ValProceso
            ElseIf ValProceso < Pb_Tol2.Minimum Then
                Pb_Tol2.Value = Pb_Tol2.Minimum
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
            Rtx_Mensajes.AppendColoredText(
                "Excepcion: Descarga Arena" & vbCrLf & ex.Message & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
        End Try
    End Sub
    Private Sub Btt_Salir_Click(sender As Object, e As EventArgs) Handles Btt_Salir.Click
        Try
            Me.Panel1.Visible = True
            If flagTolva1Ser_Iniciada Then
                IndicadorTolv1.Desconectar()
            End If
            'If flagTolva2Ser_Iniciada Then
            '    IndicadorTolv2.Desconectar()
            'End If
            If flagTolvaCementoSer_Iniciada Then
                IndicadorCemento.Desconectar()
            End If

            If PLC_LOGO.Connected Then
                PLC_LOGO.Disconnect()
            End If
            System.Threading.Thread.Sleep(1000)
            If PLC_LOGO.Connected = False Then
                Principal.Panel1.Visible = True
                Me.Close()
            End If

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

            End If
            If MessageBox.Show("¿Desea continuar con la dosificación?" & vbCrLf & "Verifique que las balanzas se encuentren enceradas",
                               "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                'Usuario Cancela la dosificacion
                Exit Sub
            End If
            'Captura Id de la Orden de Despacho
            If lblcomprobante.Text = "--" Or String.IsNullOrWhiteSpace(lblcomprobante.Text) Then
                Rtx_Mensajes.AppendColoredText("Cree o seleccione una orden de despacho" & Environment.NewLine,
                    Drawing.Color.Red,
                    font_Rtxt)
                MessageBox.Show("Cree o seleccione una orden de despacho", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            Else
                codigoOD = lblcomprobante.Text
            End If


            'HABILITAR ESTA OPCION para controlar número de batch
            'NumBatchPlanificacion = Num_BatchPlanificacion.Value
            NumBatchPlanificacion = 1   'EUFRATES SOLAMENTE HACE UN BATCH
            Dim Preparado As Boolean = False

            ValorInicialT1 = Convert.ToDouble(Lbl_Peso_T1.Text)
            'ValorInicialT2 = Convert.ToDouble(Lbl_Peso_T2.Text) -- No se usa para A. Hormigones
            ValorInicialCemento = Convert.ToDouble(Lbl_Peso_Cem.Text)
            'Acivar si la dosificación es por descarga
            'If ValorInicialT1 < pesoSet1 Then
            '    MessageBox.Show("El peso en la Tolva 1 es menor al necesario, agregue más peso", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Rtx_Mensajes.AppendColoredText("Peso de Tolva 1 inferior al necesario" & Environment.NewLine,
            '        Drawing.Color.Black,
            '        font_Rtxt)
            '    Exit Sub
            'End If
            'If ValorInicialT2 < pesoSet2 Then
            '    MessageBox.Show("El peso en la Tolva 2 es menor al necesario, agregue más peso", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Rtx_Mensajes.AppendColoredText("Peso de Tolva 2 inferior al necesario" & Environment.NewLine,
            '        Drawing.Color.Black,
            '        font_Rtxt)
            '    Exit Sub
            'End If
            'If ValorInicialCemento < 0 Then
            '    MessageBox.Show("El peso en la Tolva Cemento es menor a 0, encere la balanza", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Rtx_Mensajes.AppendColoredText("Peso de Tolva Cemento negativo" & Environment.NewLine,
            '        Drawing.Color.Black,
            '        font_Rtxt)
            '    Exit Sub
            'End If
            'If ValorInicialCemento > 20 Then
            '    MessageBox.Show("Debe encerar la balanza de Cemento", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Rtx_Mensajes.AppendColoredText("Se quiere encerar la balanza de cemento" & Environment.NewLine,
            '        Drawing.Color.Black,
            '        font_Rtxt)
            '    Exit Sub
            'End If
            'Validacion de version final -- No se usa para A. Hormigones
            'VersionFinal = ObtieneVersionActual(ID_OrdenDespacho) 
            'If VersionInicial <> VersionFinal Then
            '    MessageBox.Show("La Orden fue modificada desde oficina, vuelva a ingresar la OP para aplicar los cambios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Txt_CodOrdenDespacho.Text = String.Empty
            '    flagVersiones = False
            '    DetenerProceso()
            '    LimpiarLabelsFormula()
            'Else
            '    flagVersiones = True
            'End If
            'If flagConfigPLC And flagConfigSetpoints And SerTol1_ok And SerTol2_ok And SerCemento_ok And flagVersiones Then
            '    Preparado = True
            'End If
            'Registrar encabezado de Orden de despacho

            If flagConfigPLC And SerTol1_ok And SerCemento_ok Then
                Preparado = True
            End If

            Select Case Variables.TipoOD
                Case "Nuevo"
                    Dim complete As Integer
                    complete = guardarEncabezadoOD(lblcomprobante.Text, "DESPACHO", Variables.codOperador, Date.Today, Date.Now, 0, codProducto.Text,
                                                   "", txtPlaca.Text, 0, txtobservaciones.Text, 0, "", "", "", "", Convert.ToInt32(txtidMixer.Text), False)
                    If complete = 1 Then
                        Dim csave As Integer
                        csave = guardarconsecutivo("Despacho", codigoOD)
                        Rtx_Mensajes.AppendColoredText("La información se ha almacenado con éxito" & Environment.NewLine,
                           Drawing.Color.Black,
                           font_Rtxt)
                        Gb_OrdenDespacho.Enabled = False
                    Else
                        Rtx_Mensajes.AppendColoredText("No se pudo almacenar la transaccion compruebe los datos" & Environment.NewLine,
                          Drawing.Color.Red,
                          font_Rtxt)
                        Exit Sub
                    End If
                Case "Editar"
                    Dim complete As Integer
                    complete = actualizaEncabezadoOD(lblcomprobante.Text, "DESPACHO", "0", Convert.ToInt32(codProducto.Text), "", 0, txtobservaciones.Text, 0.0, "", "", "", "", Convert.ToInt32(txtidMixer.Text))
                    If complete = 1 Then
                        Rtx_Mensajes.AppendColoredText("La información se ha actualizado con éxito" & Environment.NewLine,
                           Drawing.Color.Black,
                           font_Rtxt)
                        Gb_OrdenDespacho.Enabled = False
                    Else
                        Rtx_Mensajes.AppendColoredText("No se pudo almacenar la transaccion compruebe los datos" & Environment.NewLine,
                          Drawing.Color.Red,
                          font_Rtxt)
                        Exit Sub
                    End If
                Case Else
            End Select


            'Nuevo para A. Hormigones
            'Verifica que existan datos teóricos para la dosificación
            'If Not verificaDatosTeoricos Then
            '    Rtx_Mensajes.AppendColoredText("Ingrese todos los valores de dosificación teórica" & Environment.NewLine,
            '      Drawing.Color.Red,
            '      font_Rtxt)
            '    Exit Sub
            'End If



            'Borrar- Solo para pruebas .- IMPORTANTE
            'Preparado = True
            If Preparado Then
                'Habilitar controles para el registro de datos
                Btt_RegPiedra.Enabled = True
                Btt_RegArena.Enabled = True
                Btt_RegCemento.Enabled = True
                Btt_RegAgua.Enabled = True
                'Deshabilita boton para crear un nuevo registro de OD
                btnagregar.Enabled = False
                Btt_Sel_OD.Enabled = False

                'Limpiar controles de dosificacion
                Lbl_Dosif_T1.Text = "0.00"
                Lbl_Dosif_T2.Text = "0.00"
                Lbl_Dosif_Agua.Text = "0.00"
                Lbl_Dosif_Cemento.Text = "0.00"
                Lbl_Cap_Piedra.Text = "0.00"
                Lbl_Cap_Arena.Text = "0.00"
                Lbl_Cap_Cemento.Text = "0.00"
                Num_RealAgua.Value = 0.00

                'No se usa para A. Hormigones
                GBx_Preparacion.Enabled = False
                Gbx_ConfigCarg_Cemento.Enabled = False

                'Extrae el numero de batch de la base
                consecutivoBatch = Convert.ToInt32(Funciones.Obtener_Valor_Configuracion("ConsecutivoBatch"))
                'No se usa para A. Hormigones
                'For i As Integer = 1 To registros
                '    CambiaEstado_Label(i, "PREPARADO", Color.Black)
                'Next

                'Cambiar estado de la Orden Para que no pueda ser modificada desde oficina -- No se usa para A. Hormigones
                'CambiaEstadodeOD(ID_OrdenDespacho)

                'Configura valores limites -- No se usa para A. Hormigones
                'LimiteT1 = pesoSet1 - corteT1
                'LimiteT2 = pesoSet2 - corteT2
                'LimiteCemento = pesoSet3 - corteCemento
                'LimiteAgua = pesoSet4 - corteAgua

                batchActual += 1
                batchPendientes = NumBatchPlanificacion - batchActual
                'Reset todas las señales -- No se usa para A. Hormigones
                'ResetTodasSignals()
                'Inicia timer de WD 

                'DAR SEÑAL de ARRANQUE 
                If Not EscribeCoil_Controlada(Variables.coil_Paro, False) Or Not EscribeCoil_Controlada(Variables.coil_Arranque, True) Then
                    'Habilitar controles para el registro de datos
                    Btt_RegPiedra.Enabled = False
                    Btt_RegArena.Enabled = False
                    Btt_RegCemento.Enabled = False
                    Btt_RegAgua.Enabled = False
                    'Deshabilita boton para crear un nuevo registro de OD
                    btnagregar.Enabled = True
                    Exit Sub
                End If

                'Aumenta el numero consecutivo del batch
                consecutivoBatch += 1
                'Guardamos el valor del Batch Actual
                Funciones.Actualizar_Valor_Configuracion("ConsecutivoBatch", consecutivoBatch)
                Tim_Wd_PLC.Enabled = True


                'Pil_Dosifica.DiscreteValue1 = True 'Revisar para enlazarse con los coils del PLC
                'Ingresar aqui Rutina WD
                Lbl_Info.Text = $"Iniciando Dosificación Orden # {codigoOD} Batch {batchActual} de {NumBatchPlanificacion}"
                Rtx_Mensajes.AppendColoredText($"Iniciando Dosificación Batch {batchActual} de {NumBatchPlanificacion}" & Environment.NewLine,
                    Drawing.Color.DarkGreen,
                    font_Rtxt)

                'Iniciar carga del parcial del agua
                'IniciarCargaParcialAgua()
                'Iniciar carga de cemento
                'IniciarCargaCemento()
                'Encender banda transportadora 
                'Iniciar_Apagar_Banda(True)
                '-- No se usa para A. Hormigones
                'Dar retardo  --Ver otras opciones de retardo 
                'Await DelayMs(4000) ' 4 segundos sin bloquear
                'Iniciar descarga de piedra
                'IniciarDescargaParcialT1()
                'Deshabilita boton incio
                Btt_Iniciar.Enabled = False
                Btt_Detener.Enabled = True
                Btt_Salir.Enabled = False

                'NUEVO PARA ANDINA
                'Visualiza animacion de controles
                Sym_Piedra.Visible = True
                Sym_Piedra.DiscreteValue1 = True
                SymTolva1.DiscreteValue1 = True
                SymTolva2.DiscreteValue1 = True
                SymTolvaCem.DiscreteValue1 = True
                Sym_Arena.Visible = True
                Sym_Arena.DiscreteValue1 = True
                ValvulaDescarga.DiscreteValue1 = True
                Sym_DescargaCem.DiscreteValue1 = True

                Panel2.BackColor = Color.DarkSeaGreen
                running = True


            Else
                MessageBox.Show("Sistema no cumple con los requisitos para iniciar, revise el estado de las señales", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Dim errores As New List(Of String)
                If Not SerTol1_ok Then errores.Add("Tolva 1 - " & SerialTolva1.PortName)
                'If Not SerTol2_ok Then errores.Add("Tolva 2 - " & SerialTolva2.PortName) -- No se usa para A. Hormigones
                If Not SerCemento_ok Then errores.Add("Tolva Cemento - " & SerialCemento.PortName)
                'If Not flagConfigSetpoints Then errores.Add("No se ha seleccionado Ninguna Fórmula") -- No se usa para A. Hormigones
                'If Not flagVersiones Then errores.Add("Orden Modificada desde oficina") -- No se usa para A. Hormigones
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
    Public Function guardarEncabezadoOD(
    ByVal IdTran As String,
    ByVal Tipo As String,
    ByVal CodOperador As String,
    ByVal Fecha As Date,
    ByVal Hora As Date,
    ByVal CodCliente As Integer,
    ByVal CodProducto As String,
    ByVal Documento As String,
    ByVal Placa As String,
    ByVal CodChofer As Integer,
    ByVal Observaciones As String,
    ByVal NetoM3 As Double,
    ByVal MotTraslado As String,
    ByVal PtoPartida As String,
    ByVal PtoLlegada As String,
    ByVal Obra As String,
    ByVal idMixer As Integer,
    ByVal eliminado As Boolean) As Integer

        Try
            'Variables fijas
            Dim estado As Boolean = True
            Dim version As Integer = 1
            Using con As New OleDb.OleDbConnection(sConnString)
                Using cmd As New OleDb.OleDbCommand()

                    cmd.Connection = con
                    cmd.CommandText = "INSERT INTO CabeceraTransacciones 
                                        (Id, Tipo, CodOperador, Fecha, Hora, CodCliente, CodProducto, Documento, CodChofer, Observaciones, NetoM3, MotTraslado, PtoPartida, PtoLlegada, Obra, idMixer, Eliminado, Estado, Version)
                                        VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?)"

                    ' Parámetros en orden 
                    cmd.Parameters.AddWithValue("?", IdTran)                                'ID
                    cmd.Parameters.AddWithValue("?", Tipo)                                  'Tipo
                    cmd.Parameters.AddWithValue("?", CodOperador)                           'CodOperador
                    cmd.Parameters.Add("?", OleDb.OleDbType.Date).Value = Fecha             'Fecha
                    cmd.Parameters.Add("?", OleDb.OleDbType.Date).Value = Hora              'Hora
                    cmd.Parameters.AddWithValue("?", CodCliente)                            'CodCliente
                    cmd.Parameters.AddWithValue("?", CodProducto)                           'CodProducto
                    cmd.Parameters.AddWithValue("?", Documento)                             'Documento
                    cmd.Parameters.AddWithValue("?", CodChofer)                             'CodChofer
                    cmd.Parameters.AddWithValue("?", Observaciones)                         'Observaciones
                    cmd.Parameters.AddWithValue("?", NetoM3)                                'NetoM3    
                    cmd.Parameters.AddWithValue("?", MotTraslado)                           'MotTraslado
                    cmd.Parameters.AddWithValue("?", PtoPartida)                            'PtoPartida
                    cmd.Parameters.AddWithValue("?", PtoLlegada)                            'PtoLlegada
                    cmd.Parameters.AddWithValue("?", Obra)                                  'Obra
                    cmd.Parameters.AddWithValue("?", idMixer)                               'idMixer
                    If Variables.tipoBD = "ACCESS" Then
                        cmd.Parameters.AddWithValue("?", eliminado)                         'Eliminado
                        cmd.Parameters.AddWithValue("?", estado)                            'Estado se crea con valor true o 1
                    Else
                        cmd.Parameters.AddWithValue("?", If(eliminado, 1, 0))               'Eliminado
                        cmd.Parameters.AddWithValue("?", If(estado, 1, 0))                  'Estado se crea con valor true o 1
                    End If
                    cmd.Parameters.AddWithValue("?", version)                               'version se crea con valor 1
                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return 1

        Catch ex As Exception
            MessageBox.Show("Error al guardar Transacción: " & ex.Message)
            Return 0

        End Try

    End Function

    Public Function actualizaEncabezadoOD(
     ByVal IdTran As String,
     ByVal Tipo As String,
     ByVal CodCliente As String,
     ByVal CodProducto As Integer,
     ByVal Documento As String,
     ByVal CodChofer As Integer,
     ByVal Observaciones As String,
     ByVal NetoM3 As Decimal,
     ByVal MotTraslado As String,
     ByVal PtoPartida As String,
     ByVal PtoLlegada As String,
     ByVal Obra As String,
     ByVal idMixer As Integer) As Integer

        Try
            Using con As New OleDbConnection(sConnString)
                con.Open()
                'Actualizar registro
                Using cmd As New OleDb.OleDbCommand()

                    cmd.Connection = con

                    cmd.CommandText =
                    "UPDATE CabeceraTransacciones SET " &
                    "Tipo = ?, " &
                    "CodCliente = ?, " &
                    "CodProducto = ?, " &
                    "Documento = ?, " &
                    "CodChofer = ?, " &
                    "Observaciones = ?, " &
                    "NetoM3 = ?, " &
                    "MotTraslado = ?, " &
                    "PtoPartida = ?, " &
                    "PtoLlegada = ?, " &
                    "Obra = ?, " &
                    "idMixer = ? " &
                    "WHERE Id = ?"

                    cmd.Parameters.AddWithValue("?", Tipo)
                    cmd.Parameters.AddWithValue("?", CodCliente)
                    cmd.Parameters.AddWithValue("?", CodProducto)
                    cmd.Parameters.AddWithValue("?", Documento)
                    cmd.Parameters.AddWithValue("?", CodChofer)
                    cmd.Parameters.AddWithValue("?", Observaciones)
                    cmd.Parameters.AddWithValue("?", NetoM3)
                    cmd.Parameters.AddWithValue("?", MotTraslado)
                    cmd.Parameters.AddWithValue("?", PtoPartida)
                    cmd.Parameters.AddWithValue("?", PtoLlegada)
                    cmd.Parameters.AddWithValue("?", Obra)
                    cmd.Parameters.AddWithValue("?", idMixer)
                    cmd.Parameters.AddWithValue("?", IdTran)
                    If cmd.ExecuteNonQuery() > 0 Then
                        Return 1
                    Else
                        Return 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al guardar Transacción: " & ex.Message)
            Return 0
        End Try
    End Function
    Public Function guardarconsecutivo(ByVal descripcion As String, ByVal valor As Long) As Integer
        Dim con As New OleDbConnection(sConnString)
        Dim cmd As OleDbCommand
        Try
            cmd = New OleDb.OleDbCommand
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "update Consecutivos set consecutivo = " & valor + 1 & " where Descripcion = '" & descripcion & "'"
            cmd.ExecuteNonQuery()
            con.Close()
            guardarconsecutivo = 1
        Catch ex As Exception
            guardarconsecutivo = 0
        Finally
            con.Close()
        End Try
    End Function
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
    Private Function EscribeCoil_Controlada(Direccion As Integer, Valor As Boolean) As Boolean
        If PLC_LOGO.Connected Then

            PLC_LOGO.WriteSingleCoil(Direccion, Valor)
            Return True
        Else
            Rtx_Mensajes.AppendColoredText($"PLC no conectado, no es posible configurar coil={Direccion} con valor={Valor} " & Environment.NewLine,
                Drawing.Color.Red,
                font_Rtxt)
            Return False
        End If
    End Function
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
                                    pesoSet4, pesoReal4, Variables.Factor, ID_OrdenDespacho)
            Pb_Tol4.Maximum = pesoReal4
            Pb_Tol4.Value = pesoReal4
            Lbl_Dosif_Agua.Text = pesoReal4.ToString("N0")
            CambiaProceso_Labels(Variables.reg_Lbl_Agua, pesoReal4.ToString("N0"), Diferencia.ToString("N0"))
            CambiaEstado_Label(Variables.reg_Lbl_Agua, "FINALIZADO", Color.Red)
            'Verificar si es el ultimo ing
            If flagFinTolv2 And flagFinAgua And flagFinDesCargaCemento Then
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
                                        pesoSet3, pesoReal3, Variables.Factor, ID_OrdenDespacho)
            Pb_Tol3.Maximum = CInt(pesoReal3)
            Pb_Tol3.Value = CInt(pesoReal3)
            Lbl_Dosif_Cemento.Text = pesoReal3.ToString("N0")
            CambiaProceso_Labels(Variables.reg_Lbl_Cem, pesoReal3.ToString("N0"), Diferencia.ToString("N0"))
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
    Private Async Sub FinalizarDescargaCemento()
        'Finalizar carga de cemento
        flagFinDesCargaCemento = True

        'Tim_Desc_Cemento.Enabled = False

        PLC_LOGO.WriteSingleCoil(Variables.coil_Desc2_Compuerta_Cemento, False)
        Pil_Desc_Cem_Compuerta.DiscreteValue1 = False
        Sym_DescargaCem.DiscreteValue1 = False
        'Espera 60 segundos para apagar el tornillo
        Await DelayMs(60000)
        PLC_LOGO.WriteSingleCoil(Variables.coil_Desc2_Transpor_Cemento, False)
        Pil_Desc_Cem_Tornillo.DiscreteValue1 = False

        Pil_DesCemento.DiscreteValue1 = False


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
                'LimpiarLabelsFormula() -- No se usa para A. Hormigones
                LimpiarControlesOD()
                btnagregar.Enabled = True
                Btt_Sel_OD.Enabled = True
                Gbx_ConfigCarg_Cemento.Enabled = True
                GBx_Preparacion.Enabled = True
                'Deshabilitar controles para el registro de datos
                Btt_RegPiedra.Enabled = False
                Btt_RegArena.Enabled = False
                Btt_RegCemento.Enabled = False
                Btt_RegAgua.Enabled = False
                Variables.TipoOD = String.Empty
                Lbl_Info.Text = "Dosificación Finalizada"
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
                EscribeCoil_Controlada(Variables.coil_Paro, True)
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

                SymTolva1.DiscreteValue1 = False
                SymTolva2.DiscreteValue1 = False
                SymTolvaCem.DiscreteValue1 = False
                ValvulaDescarga.DiscreteValue1 = False

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
                'Configuracion para Eufrates 1 solo batch
                batchPendientes = 0
                batchActual = 0

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
                                    pesoSet1, pesoReal1, Variables.Factor, ID_OrdenDespacho)
            Rtx_Mensajes.AppendColoredText("Peso T1 Registrado" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
            Lbl_Dosif_T1.Text = pesoReal1.ToString("N0")
            CambiaProceso_Labels(Variables.reg_Lbl_Tolv1, pesoReal1.ToString("N0"), Diferencia.ToString("N0"))
            'Espera 4 segundos para activar la dosificacion parcial de T2
            Await DelayMs(4000)
            IniciarDescargaParcialT2()
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText("Excepción: Fin Desc. Total T1" & ex.Message & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            'DatosDespacho.TopLevel = False
            'Panel2.Controls.Add(DatosDespacho)
            DatosDespacho.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btt_ImprimirGuia_Click(sender As Object, e As EventArgs) Handles Btt_ImprimirGuia.Click
        'If Txt_CodOrdenDespacho.Text IsNot String.Empty And running = False Then
        '    idDespacho = Txt_CodOrdenDespacho.Text
        '    Despacho_frm.Show()
        'End If
    End Sub

    Private Sub Tim_Wd_PLC_Tick(sender As Object, e As EventArgs) Handles Tim_Wd_PLC.Tick
        Estado_WD = Not Estado_WD
        If PLC_LOGO.Connected Then
            PLC_LOGO.WriteSingleCoil(Variables.coil_WDConection, Estado_WD)
        End If
    End Sub

    Private Sub NumericM3_ValueChanged(sender As Object, e As EventArgs) Handles NumericM3.ValueChanged
        'If cmbproductos.SelectedIndex > -1 AndAlso cmbproductos.SelectedValue IsNot Nothing AndAlso
        '    Not TypeOf cmbproductos.SelectedValue Is DataRowView Then
        '    ObtieneFormulaxProducto(cmbproductos.SelectedValue.ToString)
        'End If
        'If Txt_CodOrdenDespacho.Text IsNot String.Empty Then
        '    ObtieneFormulaxProducto(ID_ProductoFormula)
        'End If

    End Sub

    Private Sub Num_Hum_Arena_ValueChanged(sender As Object, e As EventArgs) Handles Num_Hum_Arena.ValueChanged
        'If cmbproductos.SelectedIndex > -1 AndAlso cmbproductos.SelectedValue IsNot Nothing AndAlso
        '    Not TypeOf cmbproductos.SelectedValue Is DataRowView Then
        '    ObtieneFormulaxProducto(cmbproductos.SelectedValue.ToString)
        'End If
        'If Txt_CodOrdenDespacho.Text IsNot String.Empty Then
        '    ObtieneFormulaxProducto(ID_ProductoFormula)
        'End If
    End Sub

    Private Sub Num_Hum_Ripio_ValueChanged(sender As Object, e As EventArgs) Handles Num_Hum_Ripio.ValueChanged
        'If cmbproductos.SelectedIndex > -1 AndAlso cmbproductos.SelectedValue IsNot Nothing AndAlso
        '    Not TypeOf cmbproductos.SelectedValue Is DataRowView Then
        '    ObtieneFormulaxProducto(cmbproductos.SelectedValue.ToString)
        'End If
        'If Txt_CodOrdenDespacho.Text IsNot String.Empty Then
        '    ObtieneFormulaxProducto(ID_ProductoFormula)
        'End If
    End Sub

    Private Sub Btt_BuscarOrdDespacho_Click(sender As Object, e As EventArgs) Handles Btt_BuscarOrdDespacho.Click
        Try
            'ID_OrdenDespacho = Txt_CodOrdenDespacho.Text
            If ID_OrdenDespacho = String.Empty Then
                Rtx_Mensajes.AppendColoredText("Ingrese el número de la órden de despacho " & Environment.NewLine,
                    Drawing.Color.Red,
                    font_Rtxt)
                Exit Sub
            End If
            'Obtiene la version actual de la Transaccion
            VersionInicial = ObtieneVersionActual(ID_OrdenDespacho)
            '----------------------------------------------------------
            ID_ProductoFormula = Obtiene_idProductoxIdOrdenDespacho(ID_OrdenDespacho)
            CantidadM3 = Obtiene_CantM3xIdOrdenDespacho(ID_OrdenDespacho)
            Dim Verifica_OD_en_Trans As Boolean = Verifica_OrdenDespacho(ID_OrdenDespacho)


            Txt_NumM3.Text = CantidadM3.ToString

            If CantidadM3 < 1.0 Then
                Rtx_Mensajes.AppendColoredText("Cantidad de m3 errónea:" & Environment.NewLine,
                    Drawing.Color.Red,
                    font_Rtxt)
                Exit Sub
            End If
            If ID_ProductoFormula Is String.Empty Then
                Rtx_Mensajes.AppendColoredText($"No se encuentra la órden de despacho: {ID_OrdenDespacho} " & Environment.NewLine,
                    Drawing.Color.Red,
                    font_Rtxt)
                Exit Sub
            End If
            If Not Verifica_OD_en_Trans Then
                'Existen datos de la Orden de despacho en la tabla Transacciones
                MessageBox.Show($"Orden de despacho: {ID_OrdenDespacho} ya fue procesada, seleccione otra Orden de Despacho", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Rtx_Mensajes.AppendColoredText($"Orden de despacho: {ID_OrdenDespacho} ya fue procesada, seleccione otra Orden de Despacho" & Environment.NewLine,
                    Drawing.Color.Red,
                    font_Rtxt)
                Exit Sub
            End If

            ObtieneFormulaxProducto(ID_ProductoFormula)
        Catch ex As Exception
            Rtx_Mensajes.AppendColoredText("Exepción: Buscar Orden Despacho " & vbCrLf & ex.Message & Environment.NewLine,
                    Drawing.Color.Red,
                    font_Rtxt)
            Exit Sub
            MessageBox.Show(ex.Message, "Excepción: Buscar Orden Despacho", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub Proceso_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Valida que no se cierre la venta si la dosificacion esta activa
        'If running = True Then
        '    e.Cancel = False
        'End If
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
                                    pesoSet2, pesoReal2, Variables.Factor, ID_OrdenDespacho)
        Lbl_Dosif_T2.Text = pesoReal2.ToString("N0")
        CambiaProceso_Labels(Variables.reg_Lbl_Tolv2, pesoReal2.ToString("N0"), Diferencia.ToString("N0"))
        CambiaEstado_Label(Variables.reg_Lbl_Tolv2, "FINALIZADO", Color.Red)
        flagFinTolv2 = True
        Rtx_Mensajes.AppendColoredText("Descarga Total de Tolva 2 Finalizada" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)

        'Detener banda
        Await DelayMs(6000) ' 6 segundos sin bloquear
        Iniciar_Apagar_Banda(False)
        'Verifica si es el ultimo ingrediente dosificado parcial
        If flagFinTolv2 And flagFinAgua And flagFinDesCargaCemento Then
            FinalizaBatch()
        End If
    End Sub

    Private Sub btnagregar_Click(sender As Object, e As EventArgs) Handles btnagregar.Click
        LimpiarControlesOD()
        Gb_OrdenDespacho.Enabled = True
        tipoTrans = "Entra"
        lblcomprobante.Text = leerconsecutivo("Despacho")
        Variables.TipoOD = "Nuevo"
    End Sub

    Private Sub LimpiarControlesOD()
        lblcomprobante.Text = "-"
        codProducto.Text = ""
        nomProducto.Text = ""
        txtidMixer.Text = ""
        txtNomMixer.Text = ""
        txtPlaca.Text = ""
    End Sub

    Private Sub Btt_Sel_Producto_Click(sender As Object, e As EventArgs) Handles Btt_Sel_Producto.Click
        tipoLista = "PRODUCTOS"
        destinoLista = "Proceso_Pr"
        listas.Show()
    End Sub

    Private Sub Btt_Sel_Mixer_Click(sender As Object, e As EventArgs) Handles Btt_Sel_Mixer.Click
        tipoLista = "MIXERS"
        destinoLista = "Proceso_Mx"
        listas.Show()
    End Sub

    Private Sub Btt_RegPiedra_Click(sender As Object, e As EventArgs) Handles Btt_RegPiedra.Click
        flagFinTolv1 = True
        'Procesar guardar peso -- Se guarda registro por descarga
        'pesoReal1 = ValorInicialT1 - Convert.ToDouble(Lbl_Peso_T1.Text)
        Sym_Piedra.Visible = False
        Sym_Piedra.DiscreteValue1 = False
        SymTolva1.DiscreteValue1 = False

        pesoReal1 = Convert.ToDouble(Lbl_Peso_T1.Text) * -1
        pesoSet1 = Num_TeoPiedra.Value
        'Dim Diferencia As Double = pesoSet1 - pesoReal1
        Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, codProducto.Text, nomProducto.Text, Variables.CodigIngrediente_T1, Variables.NombreIngrediente_T1,
                                pesoSet1, pesoReal1, Variables.Factor, codigoOD)
        'Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, Variables.CodigProducto, Variables.NombreProducto, Variables.CodigIngrediente_T1, "PIEDRA",
        '                        pesoSet1, pesoReal1, Variables.Factor, codigoOD)
        Rtx_Mensajes.AppendColoredText($"Registrado Orden # {codigoOD} --> Valor { Variables.NombreIngrediente_T1} = {pesoReal1.ToString("N0")}" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        Console.Beep()
        Lbl_Cap_Piedra.Text = pesoReal1.ToString("N0")
        Lbl_Dosif_T1.Text = pesoReal1.ToString("N0")

    End Sub

    Private Sub Btt_RegArena_Click(sender As Object, e As EventArgs) Handles Btt_RegArena.Click
        flagFinTolv2 = True
        'Procesar guardar peso -- Se guarda registro por descarga
        'pesoReal2 = ValorInicialT2 - Convert.ToDouble(Lbl_Peso_T1.Text)
        Sym_Arena.Visible = False
        Sym_Arena.DiscreteValue1 = False
        SymTolva2.DiscreteValue1 = False

        pesoReal2 = Convert.ToDouble(Lbl_Peso_T1.Text) * -1
        pesoSet2 = Num_TeoArena.Value
        'Dim Diferencia As Double = pesoSet1 - pesoReal1
        Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, codProducto.Text, nomProducto.Text, Variables.CodigIngrediente_T2, Variables.NombreIngrediente_T2,
                                pesoSet2, pesoReal2, Variables.Factor, codigoOD)
        'Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, Variables.CodigProducto, Variables.NombreProducto, Variables.CodigIngrediente_T1, "PIEDRA",
        '                        pesoSet1, pesoReal1, Variables.Factor, codigoOD)
        Rtx_Mensajes.AppendColoredText($"Registrado Orden # {codigoOD} --> Valor { Variables.NombreIngrediente_T2} = {pesoReal2.ToString("N0")}" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        Console.Beep()
        Lbl_Cap_Arena.Text = pesoReal2.ToString("N0")
        Lbl_Dosif_T2.Text = pesoReal2.ToString("N0")
    End Sub

    Private Async Sub Btt_RegCemento_Click(sender As Object, e As EventArgs) Handles Btt_RegCemento.Click
        If flagFinDesCargaCemento = False Then
            If MessageBox.Show("¿Desea registrar la cantidad de cemento?" & vbCrLf & "Esta acción deshabilitará la descarga de cemento hasta la creación de una nueva orden",
                               "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                'Usuario Cancela la dosificacion
                Exit Sub
            End If
            flagFinDesCargaCemento = True
            'Procesar guardar peso -- Se guarda registro por descarga
            'pesoReal3 = ValorInicialCemento - Convert.ToDouble(Lbl_Peso_Cem.Text)
            Sym_DescargaCem.DiscreteValue1 = False
            SymTolvaCem.DiscreteValue1 = False

            'Deshabilitar descarga de cemento
            ResetTodasSignals()
            EscribeCoil_Controlada(Variables.coil_Paro, True)
            Await DelayMs(4000) '---Espera estabilidad del peso
            pesoReal3 = Convert.ToDouble(Lbl_Peso_Cem.Text) * -1
            pesoSet3 = Num_TeoCemento.Value
            'Dim Diferencia As Double = pesoSet1 - pesoReal1
            Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, codProducto.Text, nomProducto.Text, Variables.CodigIngrediente_T3, Variables.NombreIngrediente_T3,
                                    pesoSet3, pesoReal3, Variables.Factor, codigoOD)
            'Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, Variables.CodigProducto, Variables.NombreProducto, Variables.CodigIngrediente_T1, "PIEDRA",
            '                        pesoSet1, pesoReal1, Variables.Factor, codigoOD)
            Rtx_Mensajes.AppendColoredText($"Registrado Orden # {codigoOD} --> Valor { Variables.NombreIngrediente_T3} = {pesoReal3.ToString("N0")}" & Environment.NewLine,
                    Drawing.Color.Black,
                    font_Rtxt)
            Console.Beep()
            Lbl_Cap_Cemento.Text = pesoReal3.ToString("N0")
            Lbl_Dosif_Cemento.Text = pesoReal3.ToString("N0")

        Else
            MessageBox.Show("El ingrediente ya tiene un registro de Cemento",
                              "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub Btt_RegAgua_Click(sender As Object, e As EventArgs) Handles Btt_RegAgua.Click
        flagFinAgua = True
        'Procesar guardar peso -- Se guarda registro por descarga
        ValvulaDescarga.DiscreteValue1 = False

        pesoReal4 = Num_RealAgua.Value
        pesoSet4 = Num_TeoAgua.Value
        'Dim Diferencia As Double = pesoSet1 - pesoReal1
        Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, codProducto.Text, nomProducto.Text, Variables.CodigIngrediente_T4, Variables.NombreIngrediente_T4,
                                pesoSet4, pesoReal4, Variables.Factor, codigoOD)
        'Funciones.GuardarPesada(Variables.nomOperador, consecutivoBatch, Variables.CodigProducto, Variables.NombreProducto, Variables.CodigIngrediente_T1, "PIEDRA",
        '                        pesoSet1, pesoReal1, Variables.Factor, codigoOD)
        Rtx_Mensajes.AppendColoredText($"Registrado Orden # {codigoOD} --> Valor { Variables.NombreIngrediente_T4} = {pesoReal4.ToString("N0")}" & Environment.NewLine,
                Drawing.Color.Black,
                font_Rtxt)
        Console.Beep()
        Lbl_Dosif_Agua.Text = pesoReal4.ToString("N0")
    End Sub

    Private Sub Btt_Sel_OD_Click(sender As Object, e As EventArgs) Handles Btt_Sel_OD.Click
        tipoLista = "OD_PROCESO"
        destinoLista = "Proceso_Od"
        listas.Show()
    End Sub

    Public Function leerconsecutivo(ByVal descripcion As String) As Long
        Dim con As New OleDbConnection(sConnString)
        Dim cmd As OleDbCommand
        Try
            cmd = New OleDb.OleDbCommand
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select consecutivo from Consecutivos where Descripcion = '" & descripcion & "'"
            If IsDBNull(cmd.ExecuteScalar) = False Then
                leerconsecutivo = cmd.ExecuteScalar
            Else
                leerconsecutivo = 0
            End If
            con.Close()
        Catch ex As Exception
            leerconsecutivo = 0
        Finally
            con.Close()
        End Try
    End Function

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
    Private Function ObtieneVersionActual(ByVal IdTran As String) As String
        Try
            Using con As New OleDbConnection(sConnString)
                con.Open()
                Dim estadoActual As Integer = 0
                Using cmdValida As New OleDbCommand("SELECT Version FROM CabeceraTransacciones WHERE Id = ?", con)
                    cmdValida.Parameters.AddWithValue("?", IdTran)
                    Dim resultado = cmdValida.ExecuteScalar()
                    If resultado Is Nothing OrElse IsDBNull(resultado) Then
                        MessageBox.Show("No se encontró la transacción seleccionada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return ""
                    End If
                    Return resultado
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción: Obtener Version idTrans", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function
    Private Function CambiaEstadodeOD(ByVal IdTran As String) As Boolean
        Try
            Using con As New OleDbConnection(sConnString)
                con.Open()
                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = con
                    cmd.CommandText = "UPDATE CabeceraTransacciones SET Estado=0 WHERE Id=?"
                    cmd.Parameters.AddWithValue("?", IdTran)
                    If cmd.ExecuteNonQuery() > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Excepción: Actualizar estado Orden Despacho", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function Verifica_OrdenDespacho(numOrden As String) As Boolean
        'Consulta si en la tabla de transacciones ya existen registros de esa OP
        'Si **NO** hay datos retorna --> true y viceversa
        Dim rpta As Boolean = False
        Dim dt As New DataTable
        Try
            Using connection As New OleDbConnection(sConnString)
                Using cmd As New OleDbCommand
                    cmd.Connection = connection
                    cmd.CommandText = "SELECT COUNT (*) AS Numero
                                       FROM Transacciones
                                       WHERE Id_Cabecera = ? "
                    cmd.Parameters.AddWithValue("?", numOrden)
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    If CInt(dt.Rows(0).Item("Numero")) = 0 Then
                        rpta = True
                    Else
                        rpta = False
                    End If
                End Using
            End Using
            Return rpta
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepcion Obtener Datos de la Orden de Despacho", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function Obtiene_idProductoxIdOrdenDespacho(NumOrden As String) As String
        Dim rpta As String = ""
        Dim dt As New DataTable
        Try
            Using conection As New OleDbConnection(sConnString)
                Using cmdd As New OleDbCommand
                    cmdd.Connection = conection
                    cmdd.CommandText = "SELECT CodProducto FROM CabeceraTransacciones WHERE Id = ?"
                    cmdd.Parameters.AddWithValue("?", NumOrden)
                    Using da As New OleDbDataAdapter(cmdd)
                        da.Fill(dt)
                    End Using
                    If (dt.Rows.Count > 0) Then
                        rpta = dt.Rows(0).Item("CodProducto")
                    Else
                        rpta = ""
                    End If

                End Using
            End Using
            Return rpta
        Catch ex As Exception
            Return ""
            MessageBox.Show(ex.Message, "Excepcion Obtener Datos de la Orden de Despacho", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function Obtiene_CantM3xIdOrdenDespacho(NumOrden As String) As Double
        Dim rpta As Double = 1.0
        Dim dt As New DataTable
        Try
            Using conection As New OleDbConnection(sConnString)
                Using cmdd As New OleDbCommand
                    cmdd.Connection = conection
                    cmdd.CommandText = "SELECT NetoM3 FROM CabeceraTransacciones WHERE Id = ?"
                    cmdd.Parameters.AddWithValue("?", NumOrden)
                    Using da As New OleDbDataAdapter(cmdd)
                        da.Fill(dt)
                    End Using
                    If (dt.Rows.Count > 0) Then
                        If Not Double.TryParse(dt.Rows(0).Item("NetoM3"), rpta) Then
                            rpta = 1.0
                        End If
                    End If
                End Using
            End Using
            Return rpta
        Catch ex As Exception

            MessageBox.Show(ex.Message, "Excepcion Obtener Numero m3 de la Orden de Despacho", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 1.0
        End Try

    End Function
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
            Lbl_NombreFormula.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ObtieneFormulaxProducto(idProducto As String)
        Dim dt As New DataTable
        Try
            'Obtener la cantidad de m3 para el ajuste de la formula
            'CantidadM3 = NumericM3.Value
            'Obtener el factor de humedad de arena y ripio
            FactorHumedad_Arena = Num_Hum_Arena.Value
            FactorHumedad_Piedra = Num_Hum_Ripio.Value

            Dim CantAuxPiedra As Double
            Dim CantAuxArena As Double
            Dim CantAuxCemento As Double
            Dim CantAuxAgua As Double
            Dim CorreccionPiedra As Double
            Dim CorreccionArena As Double
            Dim AjusteAguaPiedra As Double
            Dim AjusteAguaArena As Double

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
                                        PR.Descripcion AS [Nombre Producto],
                                        DF.CoeficienteAbsorcion AS [Coeficiente Absorcion]
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
                Lbl_NombreFormula.Text = dt.Rows(0).Item("Nombre Producto")
                'Obtener valores de formula original
                CantAuxPiedra = Convert.ToDouble(dt.Rows(0).Item("Cantidad"))
                FactorAbsorcion_Piedra = Convert.ToDouble(dt.Rows(0).Item("Coeficiente Absorcion"))
                CantAuxArena = Convert.ToDouble(dt.Rows(1).Item("Cantidad"))
                FactorAbsorcion_Arena = Convert.ToDouble(dt.Rows(1).Item("Coeficiente Absorcion"))
                CantAuxCemento = Convert.ToDouble(dt.Rows(2).Item("Cantidad"))
                CantAuxAgua = Convert.ToDouble(dt.Rows(3).Item("Cantidad"))

                'Formulas de Correccion por Humedad y Absorcion del material
                CorreccionPiedra = CantAuxPiedra * (1 + (FactorHumedad_Piedra / 100.0))
                CorreccionArena = CantAuxArena * (1 + (FactorHumedad_Arena / 100.0))

                AjusteAguaPiedra = CantAuxPiedra * (FactorHumedad_Piedra - FactorAbsorcion_Piedra) / 100.0
                AjusteAguaArena = CantAuxArena * (FactorHumedad_Arena - FactorAbsorcion_Arena) / 100.0

                pesoSet1 = CorreccionPiedra * CantidadM3  '--Tolva 1 : Piedra
                'Ingresar ajuste de humedad de arena
                pesoSet2 = CorreccionArena * CantidadM3    '--Tolva 2 : Arena
                'Ingresar ajuste de humedad de ripio
                pesoSet3 = CantAuxCemento * CantidadM3                      '--Tolva Cemento
                pesoSet4 = (CantAuxAgua - AjusteAguaPiedra - AjusteAguaArena) * CantidadM3 '--Agua

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
                Select Case i
                    Case 0
                        lblCanTeo.Text = pesoSet1
                    Case 1
                        lblCanTeo.Text = pesoSet2
                    Case 2
                        lblCanTeo.Text = pesoSet3
                    Case 3
                        lblCanTeo.Text = pesoSet4

                End Select

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
