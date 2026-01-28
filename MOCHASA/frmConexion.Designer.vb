<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConexion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConexion))
        Me.Btt_Cancelar = New System.Windows.Forms.Button()
        Me.Txt_IpAdd = New System.Windows.Forms.TextBox()
        Me.Txt_Puerto = New System.Windows.Forms.TextBox()
        Me.Btt_Conectar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TP_Tolv1 = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Btt_ActPuerto1 = New System.Windows.Forms.Button()
        Me.cboTipoInd1 = New System.Windows.Forms.ComboBox()
        Me.cboFlowControl1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboStopBits1 = New System.Windows.Forms.ComboBox()
        Me.cboParity1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_DataBits1 = New System.Windows.Forms.TextBox()
        Me.Txt_Baud1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSerialPort1 = New System.Windows.Forms.ComboBox()
        Me.TP_Tolv2 = New System.Windows.Forms.TabPage()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTipoInd2 = New System.Windows.Forms.ComboBox()
        Me.Btt_ActPuerto2 = New System.Windows.Forms.Button()
        Me.cboFlowControl2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboStopBits2 = New System.Windows.Forms.ComboBox()
        Me.cboParity2 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txt_DataBits2 = New System.Windows.Forms.TextBox()
        Me.Txt_Baud2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboSerialPort2 = New System.Windows.Forms.ComboBox()
        Me.TP_Cemento = New System.Windows.Forms.TabPage()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboTipoInd3 = New System.Windows.Forms.ComboBox()
        Me.Btt_ActPuerto3 = New System.Windows.Forms.Button()
        Me.cboFlowControl3 = New System.Windows.Forms.ComboBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.cboStopBits3 = New System.Windows.Forms.ComboBox()
        Me.cboParity3 = New System.Windows.Forms.ComboBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.Txt_DataBits3 = New System.Windows.Forms.TextBox()
        Me.Txt_Baud3 = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.cboSerialPort3 = New System.Windows.Forms.ComboBox()
        Me.TP_PLC = New System.Windows.Forms.TabPage()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TP_Tolv1.SuspendLayout()
        Me.TP_Tolv2.SuspendLayout()
        Me.TP_Cemento.SuspendLayout()
        Me.TP_PLC.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btt_Cancelar
        '
        Me.Btt_Cancelar.BackColor = System.Drawing.SystemColors.Control
        Me.Btt_Cancelar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Btt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btt_Cancelar.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_Cancelar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btt_Cancelar.Image = Global.CM_Construcciones.My.Resources.Resources.cancel
        Me.Btt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Cancelar.Location = New System.Drawing.Point(374, 112)
        Me.Btt_Cancelar.Name = "Btt_Cancelar"
        Me.Btt_Cancelar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Btt_Cancelar.Size = New System.Drawing.Size(94, 41)
        Me.Btt_Cancelar.TabIndex = 15
        Me.Btt_Cancelar.Text = "Cancelar"
        Me.Btt_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Cancelar.UseVisualStyleBackColor = False
        '
        'Txt_IpAdd
        '
        Me.Txt_IpAdd.Location = New System.Drawing.Point(138, 30)
        Me.Txt_IpAdd.Name = "Txt_IpAdd"
        Me.Txt_IpAdd.Size = New System.Drawing.Size(145, 20)
        Me.Txt_IpAdd.TabIndex = 16
        '
        'Txt_Puerto
        '
        Me.Txt_Puerto.Location = New System.Drawing.Point(138, 75)
        Me.Txt_Puerto.Name = "Txt_Puerto"
        Me.Txt_Puerto.Size = New System.Drawing.Size(145, 20)
        Me.Txt_Puerto.TabIndex = 17
        '
        'Btt_Conectar
        '
        Me.Btt_Conectar.BackColor = System.Drawing.SystemColors.Control
        Me.Btt_Conectar.Cursor = System.Windows.Forms.Cursors.Default
        Me.Btt_Conectar.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_Conectar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btt_Conectar.Image = Global.CM_Construcciones.My.Resources.Resources.connect
        Me.Btt_Conectar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Conectar.Location = New System.Drawing.Point(374, 54)
        Me.Btt_Conectar.Name = "Btt_Conectar"
        Me.Btt_Conectar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Btt_Conectar.Size = New System.Drawing.Size(94, 41)
        Me.Btt_Conectar.TabIndex = 14
        Me.Btt_Conectar.Text = "Guardar"
        Me.Btt_Conectar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Conectar.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TP_Tolv1)
        Me.TabControl1.Controls.Add(Me.TP_Tolv2)
        Me.TabControl1.Controls.Add(Me.TP_Cemento)
        Me.TabControl1.Controls.Add(Me.TP_PLC)
        Me.TabControl1.Location = New System.Drawing.Point(2, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(366, 252)
        Me.TabControl1.TabIndex = 19
        '
        'TP_Tolv1
        '
        Me.TP_Tolv1.Controls.Add(Me.Label15)
        Me.TP_Tolv1.Controls.Add(Me.Label16)
        Me.TP_Tolv1.Controls.Add(Me.Label17)
        Me.TP_Tolv1.Controls.Add(Me.Label5)
        Me.TP_Tolv1.Controls.Add(Me.Btt_ActPuerto1)
        Me.TP_Tolv1.Controls.Add(Me.cboTipoInd1)
        Me.TP_Tolv1.Controls.Add(Me.cboFlowControl1)
        Me.TP_Tolv1.Controls.Add(Me.Label1)
        Me.TP_Tolv1.Controls.Add(Me.cboStopBits1)
        Me.TP_Tolv1.Controls.Add(Me.cboParity1)
        Me.TP_Tolv1.Controls.Add(Me.Label2)
        Me.TP_Tolv1.Controls.Add(Me.Txt_DataBits1)
        Me.TP_Tolv1.Controls.Add(Me.Txt_Baud1)
        Me.TP_Tolv1.Controls.Add(Me.Label3)
        Me.TP_Tolv1.Controls.Add(Me.cboSerialPort1)
        Me.TP_Tolv1.Location = New System.Drawing.Point(4, 22)
        Me.TP_Tolv1.Name = "TP_Tolv1"
        Me.TP_Tolv1.Size = New System.Drawing.Size(358, 226)
        Me.TP_Tolv1.TabIndex = 3
        Me.TP_Tolv1.Text = "Tolva 1"
        Me.TP_Tolv1.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(20, 138)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 13)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Bits de parada"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(20, 96)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Bits de datos"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(20, 52)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 13)
        Me.Label17.TabIndex = 25
        Me.Label17.Text = "Puerto serie"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(35, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Indicador:"
        '
        'Btt_ActPuerto1
        '
        Me.Btt_ActPuerto1.BackgroundImage = CType(resources.GetObject("Btt_ActPuerto1.BackgroundImage"), System.Drawing.Image)
        Me.Btt_ActPuerto1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btt_ActPuerto1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_ActPuerto1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_ActPuerto1.Location = New System.Drawing.Point(150, 64)
        Me.Btt_ActPuerto1.Name = "Btt_ActPuerto1"
        Me.Btt_ActPuerto1.Size = New System.Drawing.Size(30, 27)
        Me.Btt_ActPuerto1.TabIndex = 24
        Me.Btt_ActPuerto1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_ActPuerto1.UseVisualStyleBackColor = True
        '
        'cboTipoInd1
        '
        Me.cboTipoInd1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoInd1.FormattingEnabled = True
        Me.cboTipoInd1.Items.AddRange(New Object() {"ZM301", "ZM201", "QW", "GW", "EDS"})
        Me.cboTipoInd1.Location = New System.Drawing.Point(105, 20)
        Me.cboTipoInd1.Name = "cboTipoInd1"
        Me.cboTipoInd1.Size = New System.Drawing.Size(231, 21)
        Me.cboTipoInd1.TabIndex = 23
        '
        'cboFlowControl1
        '
        Me.cboFlowControl1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlowControl1.FormattingEnabled = True
        Me.cboFlowControl1.Location = New System.Drawing.Point(204, 154)
        Me.cboFlowControl1.Name = "cboFlowControl1"
        Me.cboFlowControl1.Size = New System.Drawing.Size(132, 21)
        Me.cboFlowControl1.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(201, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Control de Flujo"
        '
        'cboStopBits1
        '
        Me.cboStopBits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStopBits1.FormattingEnabled = True
        Me.cboStopBits1.Location = New System.Drawing.Point(23, 154)
        Me.cboStopBits1.Name = "cboStopBits1"
        Me.cboStopBits1.Size = New System.Drawing.Size(100, 21)
        Me.cboStopBits1.TabIndex = 21
        '
        'cboParity1
        '
        Me.cboParity1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParity1.FormattingEnabled = True
        Me.cboParity1.Location = New System.Drawing.Point(204, 112)
        Me.cboParity1.Name = "cboParity1"
        Me.cboParity1.Size = New System.Drawing.Size(132, 21)
        Me.cboParity1.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Paridad"
        '
        'Txt_DataBits1
        '
        Me.Txt_DataBits1.Location = New System.Drawing.Point(23, 112)
        Me.Txt_DataBits1.Name = "Txt_DataBits1"
        Me.Txt_DataBits1.Size = New System.Drawing.Size(100, 20)
        Me.Txt_DataBits1.TabIndex = 18
        '
        'Txt_Baud1
        '
        Me.Txt_Baud1.Location = New System.Drawing.Point(204, 68)
        Me.Txt_Baud1.Name = "Txt_Baud1"
        Me.Txt_Baud1.Size = New System.Drawing.Size(132, 20)
        Me.Txt_Baud1.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(201, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Baud rate"
        '
        'cboSerialPort1
        '
        Me.cboSerialPort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSerialPort1.FormattingEnabled = True
        Me.cboSerialPort1.Location = New System.Drawing.Point(23, 68)
        Me.cboSerialPort1.Name = "cboSerialPort1"
        Me.cboSerialPort1.Size = New System.Drawing.Size(121, 21)
        Me.cboSerialPort1.TabIndex = 15
        '
        'TP_Tolv2
        '
        Me.TP_Tolv2.Controls.Add(Me.Label18)
        Me.TP_Tolv2.Controls.Add(Me.Label19)
        Me.TP_Tolv2.Controls.Add(Me.Label20)
        Me.TP_Tolv2.Controls.Add(Me.Label7)
        Me.TP_Tolv2.Controls.Add(Me.cboTipoInd2)
        Me.TP_Tolv2.Controls.Add(Me.Btt_ActPuerto2)
        Me.TP_Tolv2.Controls.Add(Me.cboFlowControl2)
        Me.TP_Tolv2.Controls.Add(Me.Label4)
        Me.TP_Tolv2.Controls.Add(Me.cboStopBits2)
        Me.TP_Tolv2.Controls.Add(Me.cboParity2)
        Me.TP_Tolv2.Controls.Add(Me.Label13)
        Me.TP_Tolv2.Controls.Add(Me.Txt_DataBits2)
        Me.TP_Tolv2.Controls.Add(Me.Txt_Baud2)
        Me.TP_Tolv2.Controls.Add(Me.Label14)
        Me.TP_Tolv2.Controls.Add(Me.cboSerialPort2)
        Me.TP_Tolv2.Location = New System.Drawing.Point(4, 22)
        Me.TP_Tolv2.Name = "TP_Tolv2"
        Me.TP_Tolv2.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_Tolv2.Size = New System.Drawing.Size(358, 226)
        Me.TP_Tolv2.TabIndex = 5
        Me.TP_Tolv2.Text = "Tolva 2"
        Me.TP_Tolv2.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(20, 137)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 13)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "Bits de parada"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(20, 95)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 13)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Bits de datos"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(20, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(63, 13)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "Puerto serie"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(35, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Indicador:"
        '
        'cboTipoInd2
        '
        Me.cboTipoInd2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoInd2.FormattingEnabled = True
        Me.cboTipoInd2.Items.AddRange(New Object() {"ZM301", "ZM201", "QW", "GW", "EDS"})
        Me.cboTipoInd2.Location = New System.Drawing.Point(105, 20)
        Me.cboTipoInd2.Name = "cboTipoInd2"
        Me.cboTipoInd2.Size = New System.Drawing.Size(231, 21)
        Me.cboTipoInd2.TabIndex = 25
        '
        'Btt_ActPuerto2
        '
        Me.Btt_ActPuerto2.BackgroundImage = CType(resources.GetObject("Btt_ActPuerto2.BackgroundImage"), System.Drawing.Image)
        Me.Btt_ActPuerto2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btt_ActPuerto2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_ActPuerto2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_ActPuerto2.Location = New System.Drawing.Point(150, 64)
        Me.Btt_ActPuerto2.Name = "Btt_ActPuerto2"
        Me.Btt_ActPuerto2.Size = New System.Drawing.Size(30, 27)
        Me.Btt_ActPuerto2.TabIndex = 24
        Me.Btt_ActPuerto2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_ActPuerto2.UseVisualStyleBackColor = True
        '
        'cboFlowControl2
        '
        Me.cboFlowControl2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlowControl2.FormattingEnabled = True
        Me.cboFlowControl2.Location = New System.Drawing.Point(204, 154)
        Me.cboFlowControl2.Name = "cboFlowControl2"
        Me.cboFlowControl2.Size = New System.Drawing.Size(132, 21)
        Me.cboFlowControl2.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(201, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Control de flujo"
        '
        'cboStopBits2
        '
        Me.cboStopBits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStopBits2.FormattingEnabled = True
        Me.cboStopBits2.Location = New System.Drawing.Point(23, 154)
        Me.cboStopBits2.Name = "cboStopBits2"
        Me.cboStopBits2.Size = New System.Drawing.Size(100, 21)
        Me.cboStopBits2.TabIndex = 21
        '
        'cboParity2
        '
        Me.cboParity2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParity2.FormattingEnabled = True
        Me.cboParity2.Location = New System.Drawing.Point(204, 112)
        Me.cboParity2.Name = "cboParity2"
        Me.cboParity2.Size = New System.Drawing.Size(132, 21)
        Me.cboParity2.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(201, 95)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Paridad"
        '
        'Txt_DataBits2
        '
        Me.Txt_DataBits2.Location = New System.Drawing.Point(23, 112)
        Me.Txt_DataBits2.Name = "Txt_DataBits2"
        Me.Txt_DataBits2.Size = New System.Drawing.Size(100, 20)
        Me.Txt_DataBits2.TabIndex = 18
        '
        'Txt_Baud2
        '
        Me.Txt_Baud2.Location = New System.Drawing.Point(204, 68)
        Me.Txt_Baud2.Name = "Txt_Baud2"
        Me.Txt_Baud2.Size = New System.Drawing.Size(132, 20)
        Me.Txt_Baud2.TabIndex = 17
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(201, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Baud Rate"
        '
        'cboSerialPort2
        '
        Me.cboSerialPort2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSerialPort2.FormattingEnabled = True
        Me.cboSerialPort2.Location = New System.Drawing.Point(23, 68)
        Me.cboSerialPort2.Name = "cboSerialPort2"
        Me.cboSerialPort2.Size = New System.Drawing.Size(121, 21)
        Me.cboSerialPort2.TabIndex = 15
        '
        'TP_Cemento
        '
        Me.TP_Cemento.Controls.Add(Me.Label21)
        Me.TP_Cemento.Controls.Add(Me.Label22)
        Me.TP_Cemento.Controls.Add(Me.Label23)
        Me.TP_Cemento.Controls.Add(Me.Label9)
        Me.TP_Cemento.Controls.Add(Me.cboTipoInd3)
        Me.TP_Cemento.Controls.Add(Me.Btt_ActPuerto3)
        Me.TP_Cemento.Controls.Add(Me.cboFlowControl3)
        Me.TP_Cemento.Controls.Add(Me.label10)
        Me.TP_Cemento.Controls.Add(Me.cboStopBits3)
        Me.TP_Cemento.Controls.Add(Me.cboParity3)
        Me.TP_Cemento.Controls.Add(Me.label8)
        Me.TP_Cemento.Controls.Add(Me.Txt_DataBits3)
        Me.TP_Cemento.Controls.Add(Me.Txt_Baud3)
        Me.TP_Cemento.Controls.Add(Me.label6)
        Me.TP_Cemento.Controls.Add(Me.cboSerialPort3)
        Me.TP_Cemento.Location = New System.Drawing.Point(4, 22)
        Me.TP_Cemento.Name = "TP_Cemento"
        Me.TP_Cemento.Size = New System.Drawing.Size(358, 226)
        Me.TP_Cemento.TabIndex = 2
        Me.TP_Cemento.Text = "Cemento"
        Me.TP_Cemento.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(20, 137)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(75, 13)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "Bits de parada"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(20, 95)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Bits de datos"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(20, 51)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(63, 13)
        Me.Label23.TabIndex = 31
        Me.Label23.Text = "Puerto serie"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(35, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Indicador:"
        '
        'cboTipoInd3
        '
        Me.cboTipoInd3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoInd3.FormattingEnabled = True
        Me.cboTipoInd3.Items.AddRange(New Object() {"ZM301", "ZM201", "QW", "GW", "EDS"})
        Me.cboTipoInd3.Location = New System.Drawing.Point(105, 20)
        Me.cboTipoInd3.Name = "cboTipoInd3"
        Me.cboTipoInd3.Size = New System.Drawing.Size(231, 21)
        Me.cboTipoInd3.TabIndex = 25
        '
        'Btt_ActPuerto3
        '
        Me.Btt_ActPuerto3.BackgroundImage = CType(resources.GetObject("Btt_ActPuerto3.BackgroundImage"), System.Drawing.Image)
        Me.Btt_ActPuerto3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Btt_ActPuerto3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_ActPuerto3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_ActPuerto3.Location = New System.Drawing.Point(150, 64)
        Me.Btt_ActPuerto3.Name = "Btt_ActPuerto3"
        Me.Btt_ActPuerto3.Size = New System.Drawing.Size(30, 27)
        Me.Btt_ActPuerto3.TabIndex = 24
        Me.Btt_ActPuerto3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_ActPuerto3.UseVisualStyleBackColor = True
        '
        'cboFlowControl3
        '
        Me.cboFlowControl3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlowControl3.FormattingEnabled = True
        Me.cboFlowControl3.Location = New System.Drawing.Point(204, 154)
        Me.cboFlowControl3.Name = "cboFlowControl3"
        Me.cboFlowControl3.Size = New System.Drawing.Size(132, 21)
        Me.cboFlowControl3.TabIndex = 23
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(201, 137)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(80, 13)
        Me.label10.TabIndex = 22
        Me.label10.Text = "Control de Flujo"
        '
        'cboStopBits3
        '
        Me.cboStopBits3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStopBits3.FormattingEnabled = True
        Me.cboStopBits3.Location = New System.Drawing.Point(23, 154)
        Me.cboStopBits3.Name = "cboStopBits3"
        Me.cboStopBits3.Size = New System.Drawing.Size(100, 21)
        Me.cboStopBits3.TabIndex = 21
        '
        'cboParity3
        '
        Me.cboParity3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParity3.FormattingEnabled = True
        Me.cboParity3.Location = New System.Drawing.Point(204, 112)
        Me.cboParity3.Name = "cboParity3"
        Me.cboParity3.Size = New System.Drawing.Size(132, 21)
        Me.cboParity3.TabIndex = 20
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(201, 95)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(43, 13)
        Me.label8.TabIndex = 19
        Me.label8.Text = "Paridad"
        '
        'Txt_DataBits3
        '
        Me.Txt_DataBits3.Location = New System.Drawing.Point(23, 112)
        Me.Txt_DataBits3.Name = "Txt_DataBits3"
        Me.Txt_DataBits3.Size = New System.Drawing.Size(100, 20)
        Me.Txt_DataBits3.TabIndex = 18
        '
        'Txt_Baud3
        '
        Me.Txt_Baud3.Location = New System.Drawing.Point(204, 68)
        Me.Txt_Baud3.Name = "Txt_Baud3"
        Me.Txt_Baud3.Size = New System.Drawing.Size(132, 20)
        Me.Txt_Baud3.TabIndex = 17
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(201, 51)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(53, 13)
        Me.label6.TabIndex = 16
        Me.label6.Text = "Baud rate"
        '
        'cboSerialPort3
        '
        Me.cboSerialPort3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSerialPort3.FormattingEnabled = True
        Me.cboSerialPort3.Location = New System.Drawing.Point(23, 68)
        Me.cboSerialPort3.Name = "cboSerialPort3"
        Me.cboSerialPort3.Size = New System.Drawing.Size(121, 21)
        Me.cboSerialPort3.TabIndex = 15
        '
        'TP_PLC
        '
        Me.TP_PLC.Controls.Add(Me.label11)
        Me.TP_PLC.Controls.Add(Me.Txt_Puerto)
        Me.TP_PLC.Controls.Add(Me.label12)
        Me.TP_PLC.Controls.Add(Me.Txt_IpAdd)
        Me.TP_PLC.Location = New System.Drawing.Point(4, 22)
        Me.TP_PLC.Name = "TP_PLC"
        Me.TP_PLC.Size = New System.Drawing.Size(358, 226)
        Me.TP_PLC.TabIndex = 4
        Me.TP_PLC.Text = "PLC"
        Me.TP_PLC.UseVisualStyleBackColor = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(33, 78)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(96, 13)
        Me.label11.TabIndex = 14
        Me.label11.Text = "Puerto de servidor:"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(22, 33)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(110, 13)
        Me.label12.TabIndex = 12
        Me.label12.Text = "Direccion IP-Servidor:"
        '
        'frmConexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 276)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Btt_Cancelar)
        Me.Controls.Add(Me.Btt_Conectar)
        Me.Name = "frmConexion"
        Me.Text = "Conexión"
        Me.TabControl1.ResumeLayout(False)
        Me.TP_Tolv1.ResumeLayout(False)
        Me.TP_Tolv1.PerformLayout()
        Me.TP_Tolv2.ResumeLayout(False)
        Me.TP_Tolv2.PerformLayout()
        Me.TP_Cemento.ResumeLayout(False)
        Me.TP_Cemento.PerformLayout()
        Me.TP_PLC.ResumeLayout(False)
        Me.TP_PLC.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Btt_Cancelar As Button
    Public WithEvents Btt_Conectar As Button
    Friend WithEvents Txt_IpAdd As TextBox
    Friend WithEvents Txt_Puerto As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TP_Tolv1 As TabPage
    Friend WithEvents Label5 As Label
    Private WithEvents Btt_ActPuerto1 As Button
    Friend WithEvents cboTipoInd1 As ComboBox
    Friend WithEvents cboFlowControl1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboStopBits1 As ComboBox
    Friend WithEvents cboParity1 As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_DataBits1 As TextBox
    Friend WithEvents Txt_Baud1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboSerialPort1 As ComboBox
    Friend WithEvents TP_Tolv2 As TabPage
    Friend WithEvents Label7 As Label
    Friend WithEvents cboTipoInd2 As ComboBox
    Private WithEvents Btt_ActPuerto2 As Button
    Friend WithEvents cboFlowControl2 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboStopBits2 As ComboBox
    Friend WithEvents cboParity2 As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Txt_DataBits2 As TextBox
    Friend WithEvents Txt_Baud2 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cboSerialPort2 As ComboBox
    Friend WithEvents TP_Cemento As TabPage
    Friend WithEvents Label9 As Label
    Friend WithEvents cboTipoInd3 As ComboBox
    Private WithEvents Btt_ActPuerto3 As Button
    Friend WithEvents cboFlowControl3 As ComboBox
    Friend WithEvents label10 As Label
    Friend WithEvents cboStopBits3 As ComboBox
    Friend WithEvents cboParity3 As ComboBox
    Friend WithEvents label8 As Label
    Friend WithEvents Txt_DataBits3 As TextBox
    Friend WithEvents Txt_Baud3 As TextBox
    Friend WithEvents label6 As Label
    Friend WithEvents cboSerialPort3 As ComboBox
    Private WithEvents TP_PLC As TabPage
    Friend WithEvents label11 As Label
    Friend WithEvents label12 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
End Class
