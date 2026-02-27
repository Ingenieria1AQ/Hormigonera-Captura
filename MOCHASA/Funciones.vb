Imports System.Windows.Forms
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Data.OleDb
Imports SocketTools.SocketWrench.ErrorCode
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Imports System.Net.NetworkInformation
Imports System.Threading.Thread

Module Funciones

    Private Conn As New OleDbConnection()
    Private CmdTxt As New OleDbCommand()
    Public Const CSWSOCK10_LICENSE_KEY As String = "AnFJpHIoGSoBVlGQlEWtMOhFJsBIzP"
    Public WithEvents clientSocketCamara As New SocketTools.SocketWrench

    Public IntentosSerialT1 As Integer = 0
    Public IntentosSerialT2 As Integer = 0
    Public IntentosSerialCemento As Integer = 0
    Public IntentosSerialMax As Integer = 3
    Private Const TIMEOUT_SERIAL_MS As Integer = 3000

    Public Sub Conectar_Indicador(IpAddress As String, Port As Integer)
        If Not clientSocketCamara.Initialize(CSWSOCK10_LICENSE_KEY) Then
            MsgBox("No se puede iniciar componente SocketWrencht server", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        clientSocketCamara.Reset()
        clientSocketCamara.Blocking = False
        clientSocketCamara.Secure = False

        If Not clientSocketCamara.Connect(IpAddress, Port) Then
            MsgBox(clientSocketCamara.LastErrorString, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not clientSocketCamara.Blocking Then
            Principal.Tmr_timeoutConn.Interval = 5000
            Principal.Tmr_timeoutConn.Enabled = True
        End If

    End Sub

    Public Sub sockClient_OnConnect(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clientSocketCamara.OnConnect
        Principal.Tmr_timeoutConn.Enabled = False
        With Proceso.Lbl_Est_Conn
            .Text = "Conectado"
            .ForeColor = Color.Green
        End With
        With Principal.btt_Con_Indicador
            .Text = "Desconectar Controlador"
        End With
    End Sub

    Public Sub sockClient_OnDisconnect(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clientSocketCamara.OnDisconnect
        '
        ' This event is called when the remote host closes
        ' the connection. Note that we must still explicitly
        ' close our socket.
        '
        If clientSocketCamara.IsConnected Then
            clientSocketCamara.Disconnect()
            With Proceso.Lbl_Est_Conn
                .Text = "Desconectado"
                .ForeColor = Color.Red
            End With
            With Principal.btt_Con_Indicador
                .Text = "Conectar Controlador"
            End With
        End If
    End Sub
    Public Sub sockClient_OnRead(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clientSocketCamara.OnRead
        '
        ' This event is fired when data is written by the server to
        ' the client. This event is only fired when the control is
        ' in non-blocking mode (when the Blocking property is set
        ' to False); the code for the blocking read is in the Click
        ' event for the btnSend control
        '
        Dim strBuffer As String
        Dim cchBuffer As Integer

        Do
            strBuffer = ""
            cchBuffer = clientSocketCamara.Read(strBuffer, 4096)
            If cchBuffer > 0 Then
                ProcesaDato(strBuffer, Principal.Txt_Mensj_Sistema)
            ElseIf cchBuffer = 0 Then
                Exit Do
            Else
                Select Case clientSocketCamara.LastError
                    Case errorOperationCanceled
                    Case errorNotConnected
                        Exit Do
                    Case errorOperationWouldBlock
                        Exit Do
                    Case Else
                        MsgBox("Error inesperado: (Error " & clientSocketCamara.LastError & ")")
                End Select
            End If
        Loop
    End Sub

    Public Sub enviaDatosSocket(cadena As String, txt_estado As TextBox)
        ' Public Sub enviaDatosSocket(cadena As String, clientTCP As TcpClient, txt_estado As TextBox)
        Dim strBuffer As String
        Dim cchBuffer As Integer
        Dim nBytesRead As Integer = 0
        Dim nBytesWritten As Integer = 0

        strBuffer = cadena
        cchBuffer = Len(cadena)
        nBytesWritten = clientSocketCamara.Write(strBuffer, cchBuffer)

        If nBytesWritten = -1 Then
            MsgBox(clientSocketCamara.LastErrorString, MsgBoxStyle.Exclamation)
        End If

        If clientSocketCamara.Blocking = False Then
            Exit Sub
        End If
    End Sub
    Public Function Actualizar_Valor_Configuracion(Nombre As String, Valor As String) As Boolean
        Dim rpta As Boolean = False
        Using conection As New OleDbConnection(sConnString)
            Using cmd As New OleDbCommand
                cmd.Connection = conection
                cmd.CommandText = "UPDATE Configuracion SET Valor = ? WHERE Nombre = ?  "
                cmd.Parameters.AddWithValue("?", Valor)
                cmd.Parameters.AddWithValue("?", Nombre)

                conection.Open()
                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery
                If filasAfectadas > 0 Then
                    rpta = True
                Else
                    rpta = False
                End If
            End Using
        End Using
        Return rpta
    End Function
    Public Function Obtener_Valor_Configuracion(Nombre As String) As String
        Dim tbDatos As New DataTable
        Dim rpta As String
        Using conection As New OleDbConnection(sConnString)
            Using cmd As New OleDbCommand
                cmd.Connection = conection
                cmd.CommandText = "SELECT Valor FROM Configuracion WHERE Nombre = ?  "
                cmd.Parameters.AddWithValue("?", Nombre)

                conection.Open()
                Using da As New OleDbDataAdapter(cmd)
                    da.Fill(tbDatos)
                End Using
            End Using
            If tbDatos IsNot Nothing OrElse tbDatos.Rows.Count = 0 Then
                rpta = tbDatos.Rows(0).Item("Valor")
            Else
                rpta = ""
            End If
        End Using
        Return rpta
    End Function

    Public Sub enviarArchivo(nomArchivo As String, btt_Envio As Button, txt_estado As TextBox)
        'Public Sub enviarArchivo(nomArchivo As String)
        Try
            'Dim clientTCP_Stream As NetworkStream = clientTCP.GetStream()
            btt_Envio.Enabled = False
            Dim tipoTabla As String = ""
            Dim cmdtxt As String = ""
            Dim mensaje_enviar As String = ""
            Dim strBuffer As String = ""
            Dim cchBuffer As Integer = 0

            Select Case nomArchivo
                Case "Productos"
                    tipoTabla = "x"
                    cmdtxt = "SELECT * FROM Productos order by Id_Producto"
                Case "Ingredientes"
                    tipoTabla = "y"
                    cmdtxt = "SELECT * FROM Ingredientes order by Id_ingrediente"
                Case "Operadores"
                    tipoTabla = "z"
                    cmdtxt = "SELECT * FROM Operadores order by Id_operador"
                Case "Formulas"
                    tipoTabla = "w"
                    cmdtxt = "SELECT * FROM DetalleFormulas order by Codigo"
            End Select


            Dim Adaptador As OleDbDataAdapter = New OleDbDataAdapter(cmdtxt, sConnString)
            Dim Tabla As New DataTable
            Adaptador.Fill(Tabla)

            'Recorres filas de la tabla
            For i As Integer = 0 To Tabla.Rows.Count - 1
                mensaje_enviar = ""
                'Recorrer columnas de la tabla
                For j As Integer = 0 To Tabla.Columns.Count - 1
                    'Condicion para agregar caracter separador ","
                    If j = Tabla.Columns.Count - 1 Then
                        mensaje_enviar = mensaje_enviar & Tabla.Rows(i).Item(j)
                    Else
                        mensaje_enviar = mensaje_enviar & Tabla.Rows(i).Item(j) & ","
                    End If
                Next
                'MessageBox.Show(mensaje_enviar)
                enviaDatosSocket(tipoTabla & mensaje_enviar & vbCr, txt_estado)
                For x As Integer = 0 To 80
                    Thread.Sleep(50)
                    Do
                        strBuffer = ""
                        cchBuffer = clientSocketCamara.Read(strBuffer, 4096)
                        If cchBuffer > 0 Then
                            txt_estado.Text = mensaje_enviar & vbCrLf & txt_estado.Text
                            ProcesaDato(strBuffer, txt_estado)
                            'Funciones.LeeCamara(txt_estado)
                            Exit For
                        ElseIf cchBuffer = 0 Then
                            Exit Do
                        Else
                            Select Case clientSocketCamara.LastError
                                Case errorOperationCanceled
                                Case errorNotConnected
                                    Exit Do
                                Case errorOperationWouldBlock
                                    Exit Do
                                Case Else
                                    MsgBox("Error inesperado: (Error " & clientSocketCamara.LastError & ")")
                            End Select
                        End If
                    Loop
                    If x >= 79 Then
                        txt_estado.Text = "No hay respuesta del Controlador" & vbCrLf & txt_estado.Text
                        btt_Envio.Enabled = True
                        Exit Sub
                    End If
                Next
                Application.DoEvents()
            Next
            btt_Envio.Enabled = True
        Catch ex As Exception
            btt_Envio.Enabled = True
            txt_estado.Text = "Error al enviar " & nomArchivo & ":" & ex.Message & vbCrLf & txt_estado.Text
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Public Sub LeeCamara(txt_estado As TextBox)
        Dim strBuffer As String = ""
        Dim cchBuffer As Integer = 0
        Try
            Do
                strBuffer = ""
                cchBuffer = clientSocketCamara.Read(strBuffer, 4096)
                If cchBuffer > 0 Then
                    ProcesaDato(strBuffer, txt_estado)
                ElseIf cchBuffer = 0 Then
                    Exit Do
                Else
                    Select Case clientSocketCamara.LastError
                        Case errorOperationCanceled
                        Case errorNotConnected
                            Exit Do
                        Case errorOperationWouldBlock
                            Exit Do
                        Case Else
                            MsgBox("Error inesperado: (Error " & clientSocketCamara.LastError & ")")
                    End Select
                End If
            Loop
        Catch ex As Exception
            txt_estado.Text = ex.Message & vbCrLf & txt_estado.Text
        End Try

    End Sub

    Public Sub ProcesaDato(a As String, txt_estado As TextBox)
        Dim uno() As String
        Dim datos() As String
        Dim nomOperador, batch, codProducto, nomProducto, codIngrediente, nomIngrediente As String
        Dim cant_seteada, peso_real, fact_multi As Double
        Dim hora, fecha As String
        Try
            If a <> "" Then
                uno = a.Split(",")
                If uno.Length > 0 Then
                    Select Case uno(0)
                        'Case "DATIn" 'Controlador envia datos de Tabla Ingredientes
                        '    frmObtenerDatos.TextBox1.Text = String.Format("Ingrediente grabado:  {0}", a.Replace("DATIn,", "")) & vbCrLf & frmObtenerDatos.TextBox1.Text
                        'Case "DATOp" 'Controlador envia datos de Tabla Operadores
                        '    frmObtenerDatos.TextBox1.Text = String.Format("Operador grabado:  {0}", a.Replace("DATOp,", "")) & vbCrLf & frmObtenerDatos.TextBox1.Text
                        'Case "DATPr" 'Controlador envia datos de Tabla Productos
                        '    frmObtenerDatos.TextBox1.Text = String.Format("Producto grabado:  {0}", a.Replace("DATPr,", "")) & vbCrLf & frmObtenerDatos.TextBox1.Text
                        'Case "DATFr" 'Controlador envia datos de Tabla Formulas
                        '    frmObtenerDatos.TextBox1.Text = String.Format("Fórmula grabada:  {0}", a.Replace("DATFr,", "")) & vbCrLf & frmObtenerDatos.TextBox1.Text
                        Case "DAT" 'Controlador envia datos de Tabla Transacciones
                            Try
                                'Capturar todos los datos recibidos
                                datos = a.Replace("DAT,", "").Split(",")
                                frmObtenerDatos.TextBox1.Text = String.Format("Información recibida:  {0}", a) & vbCrLf & frmObtenerDatos.TextBox1.Text
                                If datos.Length = 11 Then
                                    nomOperador = datos(0)
                                    hora = datos(1)
                                    fecha = datos(2)
                                    batch = datos(3)
                                    codProducto = datos(4)
                                    nomProducto = datos(5)
                                    codIngrediente = datos(6)
                                    nomIngrediente = datos(7)
                                    cant_seteada = Convert.ToDouble(datos(8).Replace(".", ","))
                                    peso_real = Convert.ToDouble(datos(9).Replace(".", ","))
                                    fact_multi = Convert.ToDouble(datos(10).Replace(".", ","))

                                    'MessageBox.Show(String.Format("Nombre Operador: {0}" & vbCrLf & "Hora: {1}" & vbCrLf & "Fecha: {2}" & vbCrLf &
                                    '                              "Batch: {3}" & vbCrLf & "Cod Producto: {4}" & vbCrLf & "Nom Producto: {5}" & vbCrLf &
                                    '                              "Cod Ingrediente: {6}" & vbCrLf & "Nom Ingrediente: {7}" & vbCrLf &
                                    '                              "Cant Seteada: {8}" & vbCrLf & "Cant Real: {9}" & vbCrLf &
                                    '                              "Factor: {10}", nomOperador, hora, fecha, batch, codProducto, nomProducto, codIngrediente, nomIngrediente, cant_seteada, peso_real, fact_multi))

                                    Conn = New OleDbConnection(sConnString)
                                    CmdTxt = New OleDbCommand
                                    Conn.Open()
                                    CmdTxt.Connection = Conn
                                    CmdTxt.CommandText = "INSERT INTO Transacciones (Nom_Operador , Hora , Fecha , batch , Cod_Producto , Nom_Producto , Cod_Ingrediente , Nom_Ingrediente , Cant_Seteada , Peso_Real , Fact_Multi)
                                                  VALUES ('" & nomOperador & "','" & hora & "','" & fecha & "','" & batch & "','" & codProducto & "','" & nomProducto & "','" & codIngrediente & "','" & nomIngrediente &
                                                          "'," & cant_seteada.ToString.Replace(",", ".") & "," & peso_real.ToString.Replace(",", ".") & "," & fact_multi.ToString.Replace(",", ".") & ")"

                                    If CmdTxt.ExecuteNonQuery() > 0 Then
                                        frmObtenerDatos.TextBox1.Text = String.Format("Transacción grabada:  {0}", a.Replace("DATTr,", "")) & vbCrLf & frmObtenerDatos.TextBox1.Text
                                    Else
                                        frmObtenerDatos.TextBox1.Text = String.Format("Error al guardar:  {0}", a.Replace("DATTr,", "")) & vbCrLf & frmObtenerDatos.TextBox1.Text
                                    End If
                                Else
                                    frmObtenerDatos.TextBox1.Text = String.Format("Cantidad de datos incorrecta :  {0}", "Tabla Transacciones") & vbCrLf & frmObtenerDatos.TextBox1.Text
                                End If
                            Catch ex As Exception
                                frmObtenerDatos.TextBox1.Text = String.Format("Excepción:  {0}", ex.ToString) & vbCrLf & frmObtenerDatos.TextBox1.Text
                            End Try

                        Case "Fin" 'Controlador envia datos de Tabla Transacciones
                            frmObtenerDatos.TextBox1.Text = String.Format("Recepción de datos completa: {0}", vbCrLf) & frmObtenerDatos.TextBox1.Text
                        Case "R"
                            If uno.Length = 2 Then
                                If uno(1) = "0" Then
                                    txt_estado.Text = "OK......" & txt_estado.Text
                                Else
                                    txt_estado.Text = "Error..." & txt_estado.Text
                                End If
                            End If
                        Case Else
                            frmObtenerDatos.TextBox1.Text = String.Format("Información recibida:  {0}", a) & vbCrLf & frmObtenerDatos.TextBox1.Text
                    End Select
                End If
            End If
        Catch ex As Exception
            txt_estado.Text = "Error línea: " & txt_estado.Text & ": " + ex.Message + vbCrLf + txt_estado.Text
        End Try
    End Sub

    Public Function GuardarPesada(NomOperador As String, batch As Integer, CodProducto As String, NomProducto As String,
                                  CodIngrediente As String, NomIngrediente As String, Cant_Seteada As Double, Cant_Real As Double, Factor As Double, idCabecera As String) As Boolean
        Dim Hora As TimeSpan = TimeSpan.Parse(DateTime.Now.ToString("HH:mm:ss"))
        Dim Fecha As Date = Date.Today
        Dim rpta As Boolean = False
        Try
            Using connection As New OleDbConnection(sConnString)
                Using cmd As New OleDbCommand
                    cmd.Connection = connection
                    cmd.CommandText = "INSERT INTO Transacciones (Nom_Operador,Hora,Fecha,batch,Cod_Producto, Nom_Producto,Cod_Ingrediente,Nom_Ingrediente,
                                   Cant_Seteada, Peso_Real,Fact_Multi,Id_Cabecera) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)"
                    cmd.Parameters.AddWithValue("?", NomOperador)
                    cmd.Parameters.AddWithValue("?", Hora)
                    cmd.Parameters.AddWithValue("?", Fecha)
                    cmd.Parameters.AddWithValue("?", batch)
                    cmd.Parameters.AddWithValue("?", CodProducto)
                    cmd.Parameters.AddWithValue("?", NomProducto)
                    cmd.Parameters.AddWithValue("?", CodIngrediente)
                    cmd.Parameters.AddWithValue("?", NomIngrediente)
                    cmd.Parameters.AddWithValue("?", Cant_Seteada)
                    cmd.Parameters.AddWithValue("?", Cant_Real)
                    cmd.Parameters.AddWithValue("?", Factor)
                    cmd.Parameters.AddWithValue("?", idCabecera)
                    connection.Open()
                    rpta = (cmd.ExecuteNonQuery() > 0)
                End Using
            End Using
            Return rpta
        Catch ex As Exception
            MessageBox.Show("Error al guardar el registro de peso" & vbCrLf & ex.ToString, "Excepción: Guardar Pesada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function IsFormOpen(_form As String) As Boolean

        For Each f As Form In Application.OpenForms
            'MessageBox.Show(f.Name)
            If f.Name = _form Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function AbrirPuertoSerial(sp As IO.Ports.SerialPort, row As DataRow, Tipo As Integer) As Boolean
        Try
            If row Is Nothing Then Return False

            ' Cerrar puerto si ya está abierto
            If sp.IsOpen Then sp.Close()

            With sp
                .PortName = row.Field(Of String)("PuertoCOM")
                .BaudRate = row.Field(Of Integer)("BaudRate")
                .DataBits = row.Field(Of Integer)("Bits")

                .Parity = ParseEnum(Of Parity)(row("Paridad"))
                .StopBits = ParseEnum(Of StopBits)(row("Parada"))
                .Handshake = ParseEnum(Of Handshake)(row("ControlFlujo"))

                .DtrEnable = False
                .RtsEnable = False
                .ReadTimeout = TIMEOUT_SERIAL_MS
                .WriteTimeout = -1
            End With

            sp.Open()
            Select Case Tipo
                Case 1
                    IntentosSerialT1 = 0
                    Proceso.Pil_Tolv1.DiscreteValue1 = True
                Case 2
                    IntentosSerialT2 = 0
                    Proceso.Pil_Tolv2.DiscreteValue1 = True
                Case 3
                    IntentosSerialCemento = 0
                    Proceso.Pil_TolvCemento.DiscreteValue1 = True
            End Select

            Return sp.IsOpen

        Catch ex As Exception
            ' Manejo centralizado (log / mensaje)
            MessageBox.Show(
            "Error al abrir puerto serie (" & sp.PortName & "): " & ex.Message,
            "Excepción Puerto Serie",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Return False
        End Try

    End Function
    Private Function ParseEnum(Of T)(value As Object) As T
        If value Is Nothing OrElse IsDBNull(value) Then
            Return CType([Enum].GetValues(GetType(T))(0), T)
        End If

        Return CType([Enum].Parse(GetType(T), value.ToString(), True), T)
    End Function


    Public Function spOpen(PuertoSerie As SerialPort, Com As String, BaudRate As Integer, DataBits As Integer, Pariedad As Parity, StopBits As StopBits, flowControl As Handshake) As Boolean
        Dim rpta As Boolean = False
        Try
            If PuertoSerie.IsOpen Then
                PuertoSerie.Close()
            End If
            With PuertoSerie
                .PortName = Com
                .BaudRate = BaudRate
                .DataBits = DataBits
                .Parity = Pariedad
                .StopBits = StopBits
                .Handshake = flowControl
                .DtrEnable = False
                .RtsEnable = False
                '.NewLine = vbCr
                .ReadTimeout = 3000
                .WriteTimeout = -1
            End With
            PuertoSerie.Open()
            If PuertoSerie.IsOpen Then
                rpta = True
            End If
            IntentosSerialT1 = 0
            IntentosSerialT2 = 0
            IntentosSerialCemento = 0
        Catch ex As Exception
            MessageBox.Show("Error al Abrir Puerto Serie: " & ex.Message, "Exepción SP Open", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            rpta = False
        End Try
        Return rpta
    End Function
    Public Sub spClose(PuertoSerie As SerialPort)
        Try
            If PuertoSerie.IsOpen Then
                PuertoSerie.Close()
                PuertoSerie.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al Cerrar Puerto Serie: " & ex.Message, "Exepción ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub verifica_mac()
        Dim direccion As String = ""
        Dim permitidos(40) As String
        permitidos(0) = "B86B23DD5373" 'PC AQ Ingematic
        permitidos(1) = "0068EB67CC95" 'PC AQ
        permitidos(2) = "10A51D6C949B"   ' FP HP Z
        permitidos(3) = "320302445467"  'PC EUFRATES
        permitidos(4) = "F4B5201C4C77"  'PC EUFRATES 2
        permitidos(5) = ""
        permitidos(6) = ""
        permitidos(7) = ""
        permitidos(8) = ""
        permitidos(9) = ""
        permitidos(10) = ""
        permitidos(11) = ""
        permitidos(12) = ""
        permitidos(13) = ""
        permitidos(14) = ""
        permitidos(15) = ""
        permitidos(16) = ""
        permitidos(17) = ""
        permitidos(18) = ""
        permitidos(19) = ""
        permitidos(20) = ""
        permitidos(21) = ""
        permitidos(22) = ""
        permitidos(23) = ""
        permitidos(24) = ""
        permitidos(25) = ""
        permitidos(26) = ""
        permitidos(27) = ""
        permitidos(28) = ""
        permitidos(29) = ""
        permitidos(30) = ""
        permitidos(31) = ""
        permitidos(32) = ""
        permitidos(33) = ""
        permitidos(34) = ""
        permitidos(35) = ""
        permitidos(36) = ""
        permitidos(37) = ""
        permitidos(38) = ""
        permitidos(39) = ""
        permitidos(40) = ""
        Dim computerProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Variables.nombre_PC = computerProperties.HostName
        Dim tiene_licencia As Int16 = 0
        Dim adapter As NetworkInterface

        For Each adapter In nics
            Dim dir As String = adapter.GetPhysicalAddress().ToString()
            If dir <> "" Then
                direccion = dir
                'If direccion <> "" Then
                Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
                Dim i As Int16
                For i = 0 To permitidos.Length - 1
                    If permitidos(i) = direccion Then
                        tiene_licencia = 1
                        Exit For
                    End If
                Next
            End If
        Next adapter
        '++++++OJOOOOO no tiene control Licencias, quitar esta linea
        'tiene_licencia = 1

        If tiene_licencia = 0 Then
            If direccion = "" Then
                MsgBox("No se encontró una tarjeta de red en este computador(" & nombre_PC & "). El sistema no puede continuar", MsgBoxStyle.Critical, ".:Pesos Noperti:.")
            Else
                MsgBox("Este computador (" & nombre_PC & ") " & vbCrLf & "NO tiene licencia para el uso de este software" & vbCrLf & "Consulte a su proveedor", MsgBoxStyle.Critical, ".:Pesos Noperti:.")

            End If
            Application.Exit()
        End If
    End Sub

    Public Sub LeerSerie(SP As SerialPort, Btt_ReCon As Button, Lb_Estado As Label, Lb_Peso As Label, Temporizador As System.Windows.Forms.Timer, Indicador As String, tipo As Integer)
        Try
            Dim spLectura As String
            Dim spPeso As Decimal
            Dim pattern As String
            Dim intentos As Integer
            pattern = ""

            'Procesa intentos de cual tolva se comunica
            Select Case tipo
                Case 1
                    intentos = IntentosSerialT1
                Case 2
                    intentos = IntentosSerialT2
                Case 3
                    intentos = IntentosSerialCemento
            End Select

            Select Case Indicador
                Case "Estándar"
                    pattern = "-?\d+(\.\d+)?"
                Case Else
                    pattern = "-?\d+(\.\d+)?"
            End Select

            Dim regex As New Regex(pattern)
            Dim encontrado As Match
            If SP.IsOpen And intentos < IntentosSerialMax Then
                Btt_ReCon.Visible = False
                Lb_Estado.Text = "Conectado"
                Lb_Estado.ForeColor = System.Drawing.Color.DarkGreen
                SP.ReceivedBytesThreshold = 1000000
                spLectura = SP.ReadExisting().ToString
                Sleep(300)
                encontrado = regex.Match(spLectura)
                'Verificar si se encontró alguna coincidencia
                If encontrado.Success Then
                    'spPeso = Decimal.Parse(encontrado.Value)
                    Lb_Peso.Text = encontrado.Value.ToString
                    'Lb_Peso.Text = (String.Format("{0:N3}", spPeso))
                    intentos = 0
                Else
                    intentos += 1
                    'Exit Sub
                End If
            Else
                If SP.IsOpen Then
                    SP.Close()
                End If
                'Procesa intentos de cual tolva se comunica
                Select Case tipo
                    Case 1
                        Proceso.SerTol1_ok = False
                        Proceso.Pil_Tolv1.DiscreteValue1 = False
                    Case 2
                        Proceso.SerTol2_ok = False
                        Proceso.Pil_Tolv2.DiscreteValue1 = False
                    Case 3
                        Proceso.SerCemento_ok = False
                        Proceso.Pil_TolvCemento.DiscreteValue1 = False
                End Select
                Lb_Estado.Text = "Desconectado"
                Lb_Estado.ForeColor = System.Drawing.Color.DarkRed
                Btt_ReCon.Visible = True
            End If
            'Procesa intentos de cual tolva se comunica
            Select Case tipo
                Case 1
                    IntentosSerialT1 = intentos
                Case 2
                    IntentosSerialT2 = intentos
                Case 3
                    IntentosSerialCemento = intentos
            End Select
        Catch ex As System.TimeoutException
            Temporizador.Enabled = False
            'Procesa intentos de cual tolva se comunica
            Select Case tipo
                Case 1
                    Proceso.SerTol1_ok = False
                    Proceso.Pil_Tolv1.DiscreteValue1 = False
                Case 2
                    Proceso.SerTol2_ok = False
                    Proceso.Pil_Tolv2.DiscreteValue1 = False
                Case 3
                    Proceso.SerCemento_ok = False
                    Proceso.Pil_TolvCemento.DiscreteValue1 = False
            End Select
            Lb_Estado.Text = "Desconectado"
            Lb_Estado.ForeColor = System.Drawing.Color.DarkRed
            Btt_ReCon.Visible = True
        End Try
    End Sub
End Module
Public Class SerialState
    Public Buffer As String = String.Empty
    Public UltimaLecturaOk As DateTime = DateTime.MinValue
    Public Intentos As Integer = 0
End Class