Imports System.Net.Sockets
Imports SocketTools.SocketWrench

Module Variables

    Public sConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\BDDMolinos.mdb;Persist Security Info=False"
    Public cadenaseleccion As String
    Public filtrofechasr As String
    Public filtrooperadorr As String
    Public filtroproductor As String
    Public filtroingredienter As String
    Public NomProducto1 As String
    Public NomIngrediente1 As String
    Public datos() As String
    Public dato As String
    Public retardo As Integer = 100000000
    Public leer_tabla As String
    Public estado_Conexion As Boolean

    Public nomOperador As String
    Public tipoOperador As String
    Public idOperador As String
    Public nombre_PC As String
    Public intentosLogin As Integer
    Public codOperador As String
    Public convertirFecha As Boolean

    'Direccionamiento de registros PLC LOGO
    '--DIGITAL INPUTS
    Public Const dir_Arranque As Integer = 1
    Public Const dir_Paro As Integer = 2
    Public Const dir_BombaAgua As Integer = 4
    Public Const dir_DescargaTol1 As Integer = 5
    Public Const dir_DescargaTol2 As Integer = 6
    Public Const dir_CargaCemento As Integer = 7
    Public Const dir_DescargaCemento As Integer = 8
    Public Const dir_BandaTransport As Integer = 9
    Public Const dir_WDConection As Integer = 10
    Public Const dir_ResetContador As Integer = 3
    '--Coils
    Public Const dir_coil_Arranque As Integer = 1
    Public Const dir_coil_Bomba As Integer = 4
    Public Const dir_coil_DescT1 As Integer = 5
    Public Const dir_coil_DescT2 As Integer = 6
    Public Const dir_coil_CargaCem As Integer = 7
    Public Const dir_coil_DescCem As Integer = 8
    Public Const dir_coil_Banda As Integer = 9

    '--Holding Registers
    Public Const dir_ContadorFlujometro As Integer = 0
    Public Const dir_LitrosFlujometro As Integer = 2
    '--Input Register
    Public Const dir_TiempoFalla As Integer = 1

End Module
