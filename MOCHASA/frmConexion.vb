Imports System.IO
Imports System.Data
Imports System.Data.OleDb

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

        Try
            If dtConfigTol Is Nothing OrElse dtConfigTol.Rows.Count = 0 Then
                Exit Sub
            End If

            CargarConfig(0, cboSerialPort1, Txt_Baud1, Txt_DataBits1, cboParity1, cboStopBits1, cboFlowControl1, cboTipoInd1)
            CargarConfig(1, cboSerialPort2, Txt_Baud2, Txt_DataBits2, cboParity2, cboStopBits2, cboFlowControl2, cboTipoInd2)
            CargarConfig(2, cboSerialPort3, Txt_Baud3, Txt_DataBits3, cboParity3, cboStopBits3, cboFlowControl3, cboTipoInd3)
            'If dtConfigTol.Rows.Count >= 2 Then
            '    cboSerialPort1.SelectedIndex = cboSerialPort1.FindString(dtConfigTol.Rows(0).Item("PuertoCOM"))
            '    Txt_Baud1.Text = dtConfigTol.Rows(0).Item("BaudRate")
            '    Txt_DataBits1.Text = dtConfigTol.Rows(0).Item("Bits")
            '    cboParity1.SelectedIndex = cboParity1.FindString(dtConfigTol.Rows(0).Item("Paridad"))
            '    cboStopBits1.SelectedIndex = cboStopBits1.FindString(dtConfigTol.Rows(0).Item("Parada"))
            '    cboFlowControl1.SelectedIndex = cboFlowControl1.FindString(dtConfigTol.Rows(0).Item("ControlFlujo"))
            '    cboTipoInd1.SelectedIndex = cboTipoInd1.FindString(dtConfigTol.Rows(0).Item("TipoIndicador"))

            '    cboSerialPort2.SelectedIndex = cboSerialPort2.FindString(dtConfigTol.Rows(1).Item("PuertoCOM"))
            '    Txt_Baud2.Text = dtConfigTol.Rows(1).Item("BaudRate")
            '    Txt_DataBits2.Text = dtConfigTol.Rows(1).Item("Bits")
            '    cboParity2.SelectedIndex = cboParity2.FindString(dtConfigTol.Rows(1).Item("Paridad"))
            '    cboStopBits2.SelectedIndex = cboStopBits2.FindString(dtConfigTol.Rows(1).Item("Parada"))
            '    cboFlowControl2.SelectedIndex = cboFlowControl2.FindString(dtConfigTol.Rows(1).Item("ControlFlujo"))
            '    cboTipoInd2.SelectedIndex = cboTipoInd2.FindString(dtConfigTol.Rows(1).Item("TipoIndicador"))

            '    cboSerialPort3.SelectedIndex = cboSerialPort3.FindString(dtConfigTol.Rows(2).Item("PuertoCOM"))
            '    Txt_Baud3.Text = dtConfigTol.Rows(2).Item("BaudRate")
            '    Txt_DataBits3.Text = dtConfigTol.Rows(2).Item("Bits")
            '    cboParity3.SelectedIndex = cboParity3.FindString(dtConfigTol.Rows(2).Item("Paridad"))
            '    cboStopBits3.SelectedIndex = cboStopBits3.FindString(dtConfigTol.Rows(2).Item("Parada"))
            '    cboFlowControl3.SelectedIndex = cboFlowControl3.FindString(dtConfigTol.Rows(2).Item("ControlFlujo"))
            '    cboTipoInd3.SelectedIndex = cboTipoInd3.FindString(dtConfigTol.Rows(2).Item("TipoIndicador"))
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Excepcion: Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            Dim NombreIndicador As String = ""
            Dim tipo As String = "Serie"
            Dim idTolva As String = "0"

            Select Case TabControl1.SelectedIndex
                Case 0
                    NombreCom = cboSerialPort1.SelectedValue
                    Baud = Txt_Baud1.Text
                    bitsDatos = Txt_DataBits1.Text
                    paridad = cboParity1.SelectedValue
                    controlFlujo = cboFlowControl1.SelectedValue
                    NombreIndicador = cboTipoInd1.Text
                    idTolva = CInt(dtConfigTol.Rows(0).Item("id"))
                Case 1
                    NombreCom = cboSerialPort2.SelectedValue
                    Baud = Txt_Baud2.Text
                    bitsDatos = Txt_DataBits2.Text
                    paridad = cboParity2.SelectedValue
                    controlFlujo = cboFlowControl2.SelectedValue
                    NombreIndicador = cboTipoInd2.Text
                    idTolva = CInt(dtConfigTol.Rows(1).Item("id"))

                Case 2
                    NombreCom = cboSerialPort3.SelectedValue
                    Baud = Txt_Baud3.Text
                    bitsDatos = Txt_DataBits3.Text
                    paridad = cboParity3.SelectedValue
                    controlFlujo = cboFlowControl3.SelectedValue
                    NombreIndicador = cboTipoInd3.Text
                    idTolva = CInt(dtConfigTol.Rows(2).Item("id"))

                Case 3
                    tipo = "PLC"

            End Select
            ActualizarConfiguracion(idTolva, NombreCom, Baud, bitsDatos, paridad, controlFlujo, NombreIndicador, tipo)

        Catch ex As Exception
            MsgBox("Exepción Actualizar: " & ex.Message)
        End Try
    End Sub

    Private Sub Btt_Cancelar_Click(sender As Object, e As EventArgs) Handles Btt_Cancelar.Click
        Me.Close()
    End Sub
    Private Sub ActualizarConfiguracion(idTolva As Integer, PuertoSerie As String, Baudrate As Integer, BitsDatos As String, BitsParada As String, ControlFlujo As String, nombreIndicador As String, tipo As String)
        Try
            Select Case tipo
                Case "PLC"
                    MessageBox.Show("Registro PLC", "Mensaje")

                Case "Serie"
                    Using conection As New OleDbConnection(sConnString)
                        Using cmd As New OleDbCommand
                            cmd.Connection = conection
                            cmd.CommandText = "UPDATE NumeroTolvasTanques SET PuertoCOM = ?, BaudRate = ?, Bits = ?, Parada = ? ,ControlFlujo = ?, TipoIndicador = ? WHERE id = ? "
                            cmd.Parameters.AddWithValue("?", PuertoSerie)
                            cmd.Parameters.AddWithValue("?", Baudrate)
                            cmd.Parameters.AddWithValue("?", BitsDatos)
                            cmd.Parameters.AddWithValue("?", BitsParada)
                            cmd.Parameters.AddWithValue("?", ControlFlujo)
                            cmd.Parameters.AddWithValue("?", nombreIndicador)
                            cmd.Parameters.AddWithValue("?", idTolva)
                            conection.Open()
                            Dim filasAfectadas As Integer = cmd.ExecuteNonQuery
                            If filasAfectadas > 0 Then
                                MessageBox.Show("Registro actualizado correctamente", "Mensaje",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("No se actualizó ningún registro", "Mensaje",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        End Using
                    End Using
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