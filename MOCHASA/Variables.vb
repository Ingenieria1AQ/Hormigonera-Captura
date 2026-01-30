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
End Module
