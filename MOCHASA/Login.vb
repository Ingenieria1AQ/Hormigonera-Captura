Imports System.Data.OleDb
Imports System.IO
Public Class Login
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim path_Imagen As String = String.Concat(Application.StartupPath, "\logoEmpresa.txt")

            Me.CenterToScreen()
            'Aplicar cierre de aplicación - Eliminar para quitar validacion
            Dim fechaLimite As New DateTime(2026, 9, 20)
            Funciones.AplicacionVigente(fechaLimite)

            'Control de licencia al iniciar el programa
            Funciones.verifica_mac()

            'Leer conversion de fechas
            If Not File.Exists(Application.StartupPath & "\ConvertirFechas.txt") = True Then
                convertirFecha = False
                'formato_fecha --> "dd/MM/yyyy HH:mm:ss"
            Else
                convertirFecha = True
                'formato_fecha --> "MM/dd/yyyy HH:mm:ss"
            End If

            'Leer la cadena de conexión
            If Not File.Exists(Application.StartupPath & "\ConexionBD.txt") = True Then
                Dim sw As StreamWriter = File.CreateText(Application.StartupPath & "\Conexion.txt")
                sw.Close()
            End If
            Dim sr As StreamReader = New StreamReader(Application.StartupPath & "\ConexionBD.txt")
            Dim line As String
            line = sr.ReadLine()
            If Not line Is Nothing Then 'Verificar que la linea contiene datos
                sConnString = line.Trim
                Variables.tipoBD = Funciones.ObtenerTipoBaseDatos(sConnString)
            Else
                MessageBox.Show("Defina la cadena de conexión" & vbCr & "Consulte al administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sr.Close()
                Me.Close()
                'Threading.Thread.Sleep(200)
                Application.Exit()
            End If
            sr.Close()

            'Cargar_imagen()
        Catch ex As Exception
            MessageBox.Show("Excepción", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End Try

    End Sub
    Private Sub Cargar_imagen()
        Try
            Dim con As New OleDbConnection(sConnString)
            Dim adaptador As New OleDbDataAdapter("Select * From Configuracion", con)
            Dim tabla As New DataTable
            Dim imageBytes() As Byte
            Dim ms As MemoryStream
            adaptador.Fill(tabla)
            If tabla.Rows.Count > 0 Then
                If Not IsDBNull(tabla.Rows(0).Item("LogoEmpresa")) Then
                    imageBytes = CType(tabla.Rows(0).Item("LogoEmpresa"), Byte())
                    ms = New MemoryStream(imageBytes)
                    Pcb_Login.Image = Image.FromStream(ms)
                End If
            Else
                Pcb_Login.Image = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Btt_Acceder_Click(sender As Object, e As EventArgs) Handles Btt_Acceder.Click
        Dim tabla As New DataTable

        If Txt_Usuario.Text = String.Empty Or Txt_Clave.Text = String.Empty Then
            MessageBox.Show("Ingrese Usuario y Clave", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Consulta de parametros de login--> Usuario y Clave
        'Dim cmdtxt As String
        'Comando SQL Server
        'cmdtxt = "DECLARE @Usuario varchar(50), @Clave varchar(50)
        'SET @Usuario = '" & Txt_Usuario.Text & "'
        'SET @Clave= '" & Txt_Clave.Text & "'
        'IF EXISTS (SELECT * FROM Operadores WHERE codOperador= @Usuario AND claveOperador=@Clave and estadoOperador=1)
        ' BEGIN
        '  SELECT 'OK' as Respuesta,codOperador,nomOperador,tipoOperador FROM Operadores WHERE codOperador= @Usuario AND claveOperador=@Clave and estadoOperador=1
        ' END
        'ELSE
        ' BEGIN
        '  SELECT 'NO EXISTE' AS Respuesta
        ' END"
        'Comando SQL ACCESS
        'cmdtxt = "SELECT * FROM Operadores
        '          WHERE StrComp(codOperador,'" & Txt_Usuario.Text & "',0)=0 AND StrComp(claveOperador,'" & Txt_Clave.Text & "',0)=0 AND estadoOperador= true"
        Dim comandText As String = ""
        Try
            Select Case Variables.tipoBD
                Case "ACCESS"
                    comandText = "SELECT * FROM Operadores
                            WHERE StrComp(codOperador,?,0)=0 AND 
                            StrComp(claveOperador,?,0)=0 AND
                            estadoOperador= true"
                Case "SQLSERVER"
                    comandText = "SELECT * FROM Operadores
                            WHERE codOperador = ?
                            AND claveOperador = ?
                            AND estadoOperador = 1"
            End Select

            Using conection As New OleDbConnection(sConnString)
                Using cmdd As New OleDbCommand
                    cmdd.Connection = conection
                    cmdd.CommandText = comandText

                    cmdd.Parameters.AddWithValue("?", Txt_Usuario.Text)
                    cmdd.Parameters.AddWithValue("?", Txt_Clave.Text)
                    Using da As New OleDbDataAdapter(cmdd)
                        da.Fill(tabla)
                    End Using
                End Using
            End Using

            If tabla.Rows.Count > 0 Then
                'Principal.Panel1.Width = 199
                intentosLogin = 0

                'Extraer informacion del operador
                Variables.nomOperador = tabla.Rows(0).Item("nomOperador")
                Variables.codOperador = tabla.Rows(0).Item("codOperador")
                Variables.tipoOperador = tabla.Rows(0).Item("tipoOperador")
                Variables.idOperador = tabla.Rows(0).Item("idOperador")
                Principal.Show()
                Me.Close()

            Else
                intentosLogin += 1
                If intentosLogin < 3 Then
                    MessageBox.Show(String.Format("Acceso denegado: Intentos {0} de {1}", intentosLogin, 3), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show("Límite de intentos alcanzado, no puede avanzar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                    Application.Exit()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Acceder: " & vbCrLf & ex.ToString, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
    End Sub

    Private Sub Btt_Salir_Click(sender As Object, e As EventArgs) Handles Btt_Salir.Click
        Me.Close()
        Application.Exit()
    End Sub
End Class