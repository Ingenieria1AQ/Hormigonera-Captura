Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class frmConexion
    Private dtConfigTol As New DataTable
    Private Sub Init()
        'Load Serial Comm settings...
        Me.cboSerialPort1.DataSource = System.IO.Ports.SerialPort.GetPortNames()
        Me.cboSerialPort2.DataSource = System.IO.Ports.SerialPort.GetPortNames()
        Me.cboSerialPort3.DataSource = System.IO.Ports.SerialPort.GetPortNames()
        Me.cboParity1.DataSource = System.Enum.GetNames(GetType(System.IO.Ports.Parity))
        Me.cboParity2.DataSource = System.Enum.GetNames(GetType(System.IO.Ports.Parity))
        Me.cboParity3.DataSource = System.Enum.GetNames(GetType(System.IO.Ports.Parity))
        Me.cboStopBits1.DataSource = System.Enum.GetNames(GetType(System.IO.Ports.StopBits))
        Me.cboStopBits2.DataSource = System.Enum.GetNames(GetType(System.IO.Ports.StopBits))
        Me.cboStopBits3.DataSource = System.Enum.GetNames(GetType(System.IO.Ports.StopBits))
        Me.cboFlowControl1.DataSource = System.Enum.GetNames(GetType(System.IO.Ports.Handshake))
        Me.cboFlowControl2.DataSource = System.Enum.GetNames(GetType(System.IO.Ports.Handshake))
        Me.cboFlowControl3.DataSource = System.Enum.GetNames(GetType(System.IO.Ports.Handshake))
    End Sub
    Private Sub frmConexion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Init()
        dtConfigTol = ObtenerConfiguracion()
        CargarImpresorasDisponibles()
        Try
            If dtConfigTol Is Nothing OrElse dtConfigTol.Rows.Count = 0 Then
                Exit Sub
            End If

            CargarConfig(0, cboSerialPort1, Txt_Baud1, Txt_DataBits1, cboParity1, cboStopBits1, cboFlowControl1, cboTipoInd1)
            CargarConfig(1, cboSerialPort2, Txt_Baud2, Txt_DataBits2, cboParity2, cboStopBits2, cboFlowControl2, cboTipoInd2)
            CargarConfig(2, cboSerialPort3, Txt_Baud3, Txt_DataBits3, cboParity3, cboStopBits3, cboFlowControl3, cboTipoInd3)

            Txt_IpAdd.Text = Funciones.Obtener_Valor_Configuracion("PLC_IP")
            Txt_Puerto.Text = Funciones.Obtener_Valor_Configuracion("PLC_Puerto")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepcion: Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarImpresorasDisponibles()
        Dim lista As New List(Of String)

        For Each nombre As String In PrinterSettings.InstalledPrinters
            lista.Add(nombre)
        Next

        cbx_impresora.DataSource = lista
    End Sub

    Private Sub CargarConfig(index As Integer,
        cboPort As ComboBox,
        txtBaud As TextBox,
        txtBits As TextBox,
        cboParity As ComboBox,
        cboStop As ComboBox,
        cboFlow As ComboBox,
        cboTipo As ComboBox)

        If dtConfigTol.Rows.Count <= index Then Exit Sub

        Dim row = dtConfigTol.Rows(index)

        AsignarCombo(cboPort, row, "PuertoCOM")
        AsignarTexto(txtBaud, row, "BaudRate")
        AsignarTexto(txtBits, row, "Bits")
        AsignarCombo(cboParity, row, "Paridad")
        AsignarCombo(cboStop, row, "Parada")
        AsignarCombo(cboFlow, row, "ControlFlujo")
        AsignarCombo(cboTipo, row, "TipoIndicador")

    End Sub
    Private Sub AsignarTexto(txt As TextBox, row As DataRow, campo As String)
        If Not IsDBNull(row(campo)) Then
            txt.Text = row(campo).ToString()
        Else
            txt.Clear()
        End If
    End Sub

    Private Sub AsignarCombo(cbo As ComboBox, row As DataRow, campo As String)
        If Not IsDBNull(row(campo)) Then
            Dim idx = cbo.FindString(row(campo).ToString())
            If idx >= 0 Then cbo.SelectedIndex = idx
        End If
    End Sub
    Private Sub Btt_Conectar_Click(sender As Object, e As EventArgs) Handles Btt_Conectar.Click
        Try
            Dim NombreCom As String = ""
            Dim Baud As Integer = 9600
            Dim bitsDatos As String = ""
            Dim paridad As String = ""
            Dim controlFlujo As String = ""
            Dim bitsParada As String = ""
            Dim NombreIndicador As String = ""
            Dim tipo As String = "Serie"
            Dim idTolva As String = "0"
            Dim IP_PLC As String = ""
            Dim Puerto_PLC As String = "0"
            Dim nombreImpresora As String = ""
            Select Case TabControl1.SelectedIndex
                Case 0
                    NombreCom = cboSerialPort1.SelectedValue
                    Baud = Txt_Baud1.Text
                    bitsDatos = Txt_DataBits1.Text
                    paridad = cboParity1.SelectedValue
                    controlFlujo = cboFlowControl1.SelectedValue
                    bitsParada = cboStopBits1.SelectedValue
                    NombreIndicador = cboTipoInd1.Text
                    idTolva = CInt(dtConfigTol.Rows(0).Item("id"))
                Case 1
                    NombreCom = cboSerialPort2.SelectedValue
                    Baud = Txt_Baud2.Text
                    bitsDatos = Txt_DataBits2.Text
                    paridad = cboParity2.SelectedValue
                    controlFlujo = cboFlowControl2.SelectedValue
                    bitsParada = cboStopBits2.SelectedValue
                    NombreIndicador = cboTipoInd2.Text
                    idTolva = CInt(dtConfigTol.Rows(1).Item("id"))

                Case 2
                    NombreCom = cboSerialPort3.SelectedValue
                    Baud = Txt_Baud3.Text
                    bitsDatos = Txt_DataBits3.Text
                    paridad = cboParity3.SelectedValue
                    controlFlujo = cboFlowControl3.SelectedValue
                    bitsParada = cboStopBits3.SelectedValue
                    NombreIndicador = cboTipoInd3.Text
                    idTolva = CInt(dtConfigTol.Rows(2).Item("id"))

                Case 3
                    tipo = "PLC"
                    IP_PLC = Txt_IpAdd.Text
                    Puerto_PLC = Txt_Puerto.Text
                Case 4
                    tipo = "Impresora"
                    nombreImpresora = cbx_impresora.Text

            End Select
            ActualizarConfiguracion(idTolva, NombreCom, Baud, bitsDatos, paridad, bitsParada, controlFlujo, NombreIndicador, tipo, IP_PLC, Puerto_PLC, nombreImpresora)

        Catch ex As Exception
            MsgBox("Exepción Actualizar: " & ex.Message)
        End Try
    End Sub

    Private Sub Btt_Cancelar_Click(sender As Object, e As EventArgs) Handles Btt_Cancelar.Click
        Me.Close()
    End Sub

    Private Sub ActualizarConfiguracion(idTolva As Integer, PuertoSerie As String, Baudrate As Integer, BitsDatos As String, Paridad As String,
                                        BitsParada As String, ControlFlujo As String, nombreIndicador As String, tipo As String, IP As String, Puerto As String, nombreImpresora As String)
        Try
            Select Case tipo
                Case "PLC"
                    If Funciones.Actualizar_Valor_Configuracion("PLC_IP", IP) And Funciones.Actualizar_Valor_Configuracion("PLC_Puerto", Puerto) Then
                        MessageBox.Show("Registro de PLC actualizado correctamente", "Mensaje",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else

                        MessageBox.Show("No se actualizó ningún registro del PLC", "Mensaje",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                Case "Serie"
                    Using conection As New OleDbConnection(sConnString)
                        Using cmd As New OleDbCommand
                            cmd.Connection = conection
                            cmd.CommandText = "UPDATE NumeroTolvasTanques SET PuertoCOM = ?, BaudRate = ?, Bits = ?, Paridad = ?, Parada = ? ,ControlFlujo = ?, TipoIndicador = ? WHERE id = ? "
                            cmd.Parameters.AddWithValue("?", PuertoSerie)
                            cmd.Parameters.AddWithValue("?", Baudrate)
                            cmd.Parameters.AddWithValue("?", BitsDatos)
                            cmd.Parameters.AddWithValue("?", Paridad)
                            cmd.Parameters.AddWithValue("?", BitsParada)
                            cmd.Parameters.AddWithValue("?", ControlFlujo)
                            cmd.Parameters.AddWithValue("?", nombreIndicador)
                            cmd.Parameters.AddWithValue("?", idTolva)
                            conection.Open()
                            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery
                            If filasAfectadas > 0 Then
                                MessageBox.Show($"Registro de **{dtConfigTol.Rows(idTolva - 1).Item("descripcion")}** actualizado correctamente", "Mensaje",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show($"No se actualizó ningún registro en **{dtConfigTol.Rows(idTolva - 1).Item("descripcion")}**", "Mensaje",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End Using
                    End Using
                Case "Impresora"
                    If Funciones.Actualizar_Valor_Configuracion("Nombre_Impresora", nombreImpresora) Then
                        MessageBox.Show("Registro de Impresora actualizado correctamente", "Mensaje",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else

                        MessageBox.Show("No se actualizó ningún registro de la Impresora", "Mensaje",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function ObtenerConfiguracion() As DataTable
        Dim dt As New DataTable
        Try
            Using conection As New OleDbConnection(sConnString)
                Using cmd As New OleDbCommand
                    cmd.Connection = conection
                    cmd.CommandText = "SELECT * FROM NumeroTolvasTanques WHERE usaSerial=true"
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

    Private Sub Btt_ActPuerto1_Click(sender As Object, e As EventArgs) Handles Btt_ActPuerto1.Click
        Try
            Me.cboSerialPort1.DataSource = System.IO.Ports.SerialPort.GetPortNames()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btt_ActPuerto2_Click(sender As Object, e As EventArgs) Handles Btt_ActPuerto2.Click
        Try
            Me.cboSerialPort2.DataSource = System.IO.Ports.SerialPort.GetPortNames()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btt_ActPuerto3_Click(sender As Object, e As EventArgs) Handles Btt_ActPuerto3.Click
        Try
            Me.cboSerialPort3.DataSource = System.IO.Ports.SerialPort.GetPortNames()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepcion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class