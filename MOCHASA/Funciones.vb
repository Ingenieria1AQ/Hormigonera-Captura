Imports System.Windows.Forms
Imports System.Net.Sockets
Imports System.IO
Imports System.Threading
Imports System.Data.OleDb
Imports SocketTools.SocketWrench.ErrorCode
Module Funciones

    Private Conn As New OleDbConnection()
    Private CmdTxt As New OleDbCommand()
    Public Const CSWSOCK10_LICENSE_KEY As String = "AnFJpHIoGSoBVlGQlEWtMOhFJsBIzP"
    Public WithEvents clientSocketCamara As New SocketTools.SocketWrench



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
        With Principal.Lbl_Est_Conn
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
            With Principal.Lbl_Est_Conn
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

    Public Function IsFormOpen(_form As String) As Boolean

        For Each f As Form In Application.OpenForms
            'MessageBox.Show(f.Name)
            If f.Name = _form Then
                Return True
            End If
        Next
        Return False
    End Function

End Module
