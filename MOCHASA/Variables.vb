Imports System.Net.Sockets
Imports SocketTools.SocketWrench

Module Variables

    Public sConnString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\BDDMolinos.mdb;Persist Security Info=False"
    Public cadenaseleccion As String
    'AQ
    Public tipoBD As String = "ACCESS" 'puede ser ACCESS o SQLSERVER 

    Public filtroOrdenDespachor As String
    Public filtrofechasr As String
    Public filtrooperadorr As String
    Public filtroproductor As String
    Public filtroingredienter As String
    Public NomProducto1 As String
    Public NomIngrediente1 As String
    'AQ
    Public IdOrdenDespacho As String
    Public nombreEmpresa As String
    Public RUCEmpresa As String
    Public imagenEmpresa As Byte()

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

    Public tipoLista As String
    Public destinoLista As String
    Public idDespacho As String


    Public NombreProducto As String
    Public CodigProducto As String
    Public NombreIngrediente_T1 As String
    Public CodigIngrediente_T1 As String
    Public NombreIngrediente_T2 As String
    Public CodigIngrediente_T2 As String
    Public NombreIngrediente_T3 As String
    Public CodigIngrediente_T3 As String
    Public NombreIngrediente_T4 As String
    Public CodigIngrediente_T4 As String
    Public Factor As Double = 1.0

    'Andina de hormigones
    Public TipoOD As String = "" 'Puede ser Nuevo o Editar

    ''Variables de label de estado 
    Public Const reg_Lbl_Tolv1 As Integer = 1
    Public Const reg_Lbl_Tolv2 As Integer = 2
    Public Const reg_Lbl_Cem As Integer = 3
    Public Const reg_Lbl_Agua As Integer = 4

    'Direccionamiento de registros PLC LOGO
    '--DIGITAL INPUTS
    Public Const coil_Arranque As Integer = 64                   'Registro 8.0
    Public Const coil_Paro As Integer = 65                       'Registro 8.1
    Public Const coil_WDConection As Integer = 66                'Registro 8.2
    Public Const coil_ResetContador As Integer = 67              'Registro 8.3

    Public Const coil_BandaTransport As Integer = 68             'Registro 8.4
    Public Const coil_Desactiva_DescargaTol1 As Integer = 69     'Registro 8.5
    Public Const coil_Activa_DescargaTol1 As Integer = 70        'Registro 8.6
    Public Const coil_Desactiva_DescargaTol2 As Integer = 71     'Registro 8.7
    Public Const coil_Activa_DescargaTol2 As Integer = 72        'Registro 9.0
    Public Const coil_CargaCem1_Comp_Gravedad As Integer = 73    'Registro 9.1
    Public Const coil_Desc2_Transpor_Cemento As Integer = 74     'Registro 9.2
    Public Const coil_Desc2_Compuerta_Cemento As Integer = 75    'Registro 9.3
    Public Const coil_BombaAgua As Integer = 76                  'Registro 9.4
    Public Const coil_CargaCem2_Tornillo As Integer = 77         'Registro 9.5

    '--DIGITAL OUTPUTS
    Public Const dir_coil_Banda As Integer = 1
    Public Const dir_coil_CierraPiedra As Integer = 2
    Public Const dir_coil_AbrePiedra As Integer = 3
    Public Const dir_coil_CierraArena As Integer = 4
    Public Const dir_coil_AbreArena As Integer = 9
    Public Const dir_coil_CargaCem_Com As Integer = 10
    Public Const dir_coil_DescCem_Tor As Integer = 11
    Public Const dir_coil_DescCem_Com As Integer = 12
    Public Const dir_coil_Bomba As Integer = 5
    Public Const dir_coil_CargaCem_Tor As Integer = 6

    '--Holding Registers
    Public Const dir_ContadorFlujometro As Integer = 0

    '--Input Register
    Public Const dir_TiempoFalla As Integer = 1



End Module
