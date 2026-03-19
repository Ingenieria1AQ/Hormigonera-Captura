Imports System.IO.Ports
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Globalization

Public Class Indicador_Serial

    Public Event PesoRecibido(peso As Decimal)
    Public Event EstadoCambiado(conectado As Boolean, mensaje As String)

    Private ReadOnly _sp As SerialPort
    Private ReadOnly _buffer As New StringBuilder()
    Private ReadOnly _regexPeso As Regex
    Private ReadOnly _delimitador As String

    Private _ultimoDato As DateTime = DateTime.MinValue
    Private _watchdog As Timer
    Private _reconectando As Boolean = False
    Private _disposed As Boolean = False

    ' 🔒 Lock global
    Private ReadOnly _lock As New Object()

    Private ReadOnly _timeoutDatosMs As Integer = 3000
    Private ReadOnly _reintentoMs As Integer = 2000

    Public Sub New(portName As String, baudRate As Integer, tipoIndicador As String)

        _delimitador = If(tipoIndicador = "EDS", "=", vbCrLf)

        _regexPeso = New Regex("[-+]?\d+(\.\d+)?", RegexOptions.Compiled)

        _sp = New SerialPort(portName, baudRate) With {
            .Parity = Parity.None,
            .DataBits = 8,
            .StopBits = StopBits.One,
            .Handshake = Handshake.None,
            .ReadTimeout = 1000,
            .WriteTimeout = 1000
        }

        AddHandler _sp.DataReceived, AddressOf Serial_DataReceived

        _watchdog = New Timer(AddressOf VerificarConexion, Nothing, 1000, 1000)
    End Sub

    ' =========================
    ' CONEXIÓN
    ' =========================
    Public Sub Conectar()
        SyncLock _lock
            If _disposed Then Exit Sub

            Try
                If Not _sp.IsOpen Then
                    _sp.Open()
                    _ultimoDato = DateTime.Now
                    RaiseEvent EstadoCambiado(True, "Conectado")
                End If
            Catch ex As Exception
                RaiseEvent EstadoCambiado(False, "No se pudo abrir el puerto")
            End Try
        End SyncLock
    End Sub

    Public Sub Desconectar()
        SyncLock _lock
            Try
                _disposed = True

                RemoveHandler _sp.DataReceived, AddressOf Serial_DataReceived

                If _sp.IsOpen Then
                    _sp.Close()
                End If

                _sp.Dispose()
                _watchdog?.Dispose()

                RaiseEvent EstadoCambiado(False, "Desconectado")

            Catch
            End Try
        End SyncLock
    End Sub

    ' =========================
    ' RECEPCIÓN
    ' =========================
    Private Sub Serial_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)

        Try
            If _disposed Then Exit Sub

            Dim data As String = ""

            SyncLock _lock
                If _sp Is Nothing OrElse Not _sp.IsOpen Then Exit Sub
                data = _sp.ReadExisting()
            End SyncLock

            _ultimoDato = DateTime.Now

            SyncLock _buffer
                _buffer.Append(data)
                ProcesarBuffer()
            End SyncLock

        Catch ex As ObjectDisposedException
            ' ✔ Ignorar (normal en cierre)
        Catch
            IniciarReconexión("Error de lectura")
        End Try
    End Sub

    ' =========================
    ' BUFFER
    ' =========================
    Private Sub ProcesarBuffer()

        Dim texto As String = _buffer.ToString()
        Dim idx As Integer

        While True
            idx = texto.IndexOf(_delimitador)
            If idx < 0 Then Exit While

            Dim trama As String = texto.Substring(0, idx).Trim()
            texto = texto.Substring(idx + _delimitador.Length)

            ProcesarTrama(trama)
        End While

        _buffer.Clear()
        _buffer.Append(texto)
    End Sub

    Private Sub ProcesarTrama(trama As String)

        Dim match As Match = _regexPeso.Match(trama)
        If Not match.Success Then Exit Sub

        Dim peso As Decimal
        If Decimal.TryParse(match.Value, NumberStyles.Any, CultureInfo.InvariantCulture, peso) Then
            RaiseEvent PesoRecibido(peso)
        End If
    End Sub

    ' =========================
    ' WATCHDOG
    ' =========================
    Private Sub VerificarConexion(state As Object)

        If _disposed Then Exit Sub
        If _reconectando Then Exit Sub

        SyncLock _lock
            If Not _sp.IsOpen Then
                IniciarReconexión("Puerto cerrado")
                Exit Sub
            End If
        End SyncLock

        If DateTime.Now.Subtract(_ultimoDato).TotalMilliseconds > _timeoutDatosMs Then
            IniciarReconexión("Sin datos del indicador")
        End If
    End Sub

    ' =========================
    ' RECONEXIÓN
    ' =========================
    Private Sub IniciarReconexión(motivo As String)

        If _reconectando OrElse _disposed Then Exit Sub
        _reconectando = True

        RaiseEvent EstadoCambiado(False, motivo)

        Task.Run(Sub()
                     Try
                         SyncLock _lock
                             If _sp.IsOpen Then _sp.Close()
                         End SyncLock

                         Thread.Sleep(_reintentoMs)

                         SyncLock _lock
                             If Not _disposed Then
                                 _sp.Open()
                                 _ultimoDato = DateTime.Now
                             End If
                         End SyncLock

                         RaiseEvent EstadoCambiado(True, "Reconectado")

                     Catch
                         RaiseEvent EstadoCambiado(False, "Error al reconectar")
                     Finally
                         _reconectando = False
                     End Try
                 End Sub)
    End Sub

End Class