<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfiguracion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfiguracion))
        Me.Txt_IpAdd = New System.Windows.Forms.TextBox()
        Me.Txt_Puerto = New System.Windows.Forms.TextBox()
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
        Me.cboFlowControl2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboStopBits2 = New System.Windows.Forms.ComboBox()
        Me.cboParity2 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Txt_DataBits2 = New System.Windows.Forms.TextBox()
        Me.Txt_Baud2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboSerialPort2 = New System.Windows.Forms.ComboBox()
        Me.Btt_ActPuerto2 = New System.Windows.Forms.Button()
        Me.TP_Cemento = New System.Windows.Forms.TabPage()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboTipoInd3 = New System.Windows.Forms.ComboBox()
        Me.cboFlowControl3 = New System.Windows.Forms.ComboBox()
        Me.label10 = New System.Windows.Forms.Label()
        Me.cboStopBits3 = New System.Windows.Forms.ComboBox()
        Me.cboParity3 = New System.Windows.Forms.ComboBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.Txt_DataBits3 = New System.Windows.Forms.TextBox()
        Me.Txt_Baud3 = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.cboSerialPort3 = New System.Windows.Forms.ComboBox()
        Me.Btt_ActPuerto3 = New System.Windows.Forms.Button()
        Me.TP_PLC = New System.Windows.Forms.TabPage()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.TP_Parametros = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Num_FactAgua = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chBox_Hab_Imp = New System.Windows.Forms.CheckBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cbx_impresora = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Num_CAgua = New System.Windows.Forms.NumericUpDown()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Num_CCemento = New System.Windows.Forms.NumericUpDown()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Num_CArena = New System.Windows.Forms.NumericUpDown()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Num_CPiedra = New System.Windows.Forms.NumericUpDown()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Btt_Cancelar = New System.Windows.Forms.Button()
        Me.Btt_Conectar = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TP_Tolv1.SuspendLayout()
        Me.TP_Tolv2.SuspendLayout()
        Me.TP_Cemento.SuspendLayout()
        Me.TP_PLC.SuspendLayout()
        Me.TP_Parametros.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_FactAgua, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Num_CAgua, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_CCemento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_CArena, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Num_CPiedra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TP_Tolv1)
        Me.TabControl1.Controls.Add(Me.TP_Tolv2)
        Me.TabControl1.Controls.Add(Me.TP_Cemento)
        Me.TabControl1.Controls.Add(Me.TP_PLC)
        Me.TabControl1.Controls.Add(Me.TP_Parametros)
        Me.TabControl1.Location = New System.Drawing.Point(2, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(454, 351)
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
        Me.TP_Tolv1.Size = New System.Drawing.Size(446, 325)
        Me.TP_Tolv1.TabIndex = 3
        Me.TP_Tolv1.Text = "1- PIEDRA"
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
        Me.cboTipoInd1.Items.AddRange(New Object() {"Estandar", "EDS"})
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
        Me.TP_Tolv2.Controls.Add(Me.cboFlowControl2)
        Me.TP_Tolv2.Controls.Add(Me.Label4)
        Me.TP_Tolv2.Controls.Add(Me.cboStopBits2)
        Me.TP_Tolv2.Controls.Add(Me.cboParity2)
        Me.TP_Tolv2.Controls.Add(Me.Label13)
        Me.TP_Tolv2.Controls.Add(Me.Txt_DataBits2)
        Me.TP_Tolv2.Controls.Add(Me.Txt_Baud2)
        Me.TP_Tolv2.Controls.Add(Me.Label14)
        Me.TP_Tolv2.Controls.Add(Me.cboSerialPort2)
        Me.TP_Tolv2.Controls.Add(Me.Btt_ActPuerto2)
        Me.TP_Tolv2.Location = New System.Drawing.Point(4, 22)
        Me.TP_Tolv2.Name = "TP_Tolv2"
        Me.TP_Tolv2.Padding = New System.Windows.Forms.Padding(3)
        Me.TP_Tolv2.Size = New System.Drawing.Size(446, 325)
        Me.TP_Tolv2.TabIndex = 5
        Me.TP_Tolv2.Text = "2- ARENA"
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
        Me.cboTipoInd2.Items.AddRange(New Object() {"Estandar", "EDS"})
        Me.cboTipoInd2.Location = New System.Drawing.Point(105, 20)
        Me.cboTipoInd2.Name = "cboTipoInd2"
        Me.cboTipoInd2.Size = New System.Drawing.Size(231, 21)
        Me.cboTipoInd2.TabIndex = 25
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
        'TP_Cemento
        '
        Me.TP_Cemento.Controls.Add(Me.Label21)
        Me.TP_Cemento.Controls.Add(Me.Label22)
        Me.TP_Cemento.Controls.Add(Me.Label23)
        Me.TP_Cemento.Controls.Add(Me.Label9)
        Me.TP_Cemento.Controls.Add(Me.cboTipoInd3)
        Me.TP_Cemento.Controls.Add(Me.cboFlowControl3)
        Me.TP_Cemento.Controls.Add(Me.label10)
        Me.TP_Cemento.Controls.Add(Me.cboStopBits3)
        Me.TP_Cemento.Controls.Add(Me.cboParity3)
        Me.TP_Cemento.Controls.Add(Me.label8)
        Me.TP_Cemento.Controls.Add(Me.Txt_DataBits3)
        Me.TP_Cemento.Controls.Add(Me.Txt_Baud3)
        Me.TP_Cemento.Controls.Add(Me.label6)
        Me.TP_Cemento.Controls.Add(Me.cboSerialPort3)
        Me.TP_Cemento.Controls.Add(Me.Btt_ActPuerto3)
        Me.TP_Cemento.Location = New System.Drawing.Point(4, 22)
        Me.TP_Cemento.Name = "TP_Cemento"
        Me.TP_Cemento.Size = New System.Drawing.Size(446, 325)
        Me.TP_Cemento.TabIndex = 2
        Me.TP_Cemento.Text = "3- CEMENTO"
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
        Me.cboTipoInd3.Items.AddRange(New Object() {"Estandar", "EDS"})
        Me.cboTipoInd3.Location = New System.Drawing.Point(105, 20)
        Me.cboTipoInd3.Name = "cboTipoInd3"
        Me.cboTipoInd3.Size = New System.Drawing.Size(231, 21)
        Me.cboTipoInd3.TabIndex = 25
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
        'TP_PLC
        '
        Me.TP_PLC.Controls.Add(Me.label11)
        Me.TP_PLC.Controls.Add(Me.Txt_Puerto)
        Me.TP_PLC.Controls.Add(Me.label12)
        Me.TP_PLC.Controls.Add(Me.Txt_IpAdd)
        Me.TP_PLC.Location = New System.Drawing.Point(4, 22)
        Me.TP_PLC.Name = "TP_PLC"
        Me.TP_PLC.Size = New System.Drawing.Size(446, 325)
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
        'TP_Parametros
        '
        Me.TP_Parametros.Controls.Add(Me.GroupBox3)
        Me.TP_Parametros.Controls.Add(Me.GroupBox2)
        Me.TP_Parametros.Controls.Add(Me.GroupBox1)
        Me.TP_Parametros.Location = New System.Drawing.Point(4, 22)
        Me.TP_Parametros.Name = "TP_Parametros"
        Me.TP_Parametros.Size = New System.Drawing.Size(446, 325)
        Me.TP_Parametros.TabIndex = 6
        Me.TP_Parametros.Text = "PARÁMETROS"
        Me.TP_Parametros.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.Label32)
        Me.GroupBox3.Controls.Add(Me.Num_FactAgua)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 156)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(426, 76)
        Me.GroupBox3.TabIndex = 39
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Factor de Agua"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HORMIGONERA.My.Resources.Resources.Formula_Pres
        Me.PictureBox1.Location = New System.Drawing.Point(307, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(111, 59)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 42
        Me.PictureBox1.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.SystemColors.Info
        Me.Label33.Location = New System.Drawing.Point(54, 49)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(249, 13)
        Me.Label33.TabIndex = 39
        Me.Label33.Text = "Valor de prescala para transformar de pulsos a litros"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.SystemColors.Info
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(6, 49)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(42, 13)
        Me.Label31.TabIndex = 41
        Me.Label31.Text = "* PrEs"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(65, 21)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(37, 13)
        Me.Label32.TabIndex = 39
        Me.Label32.Text = "PrEs:"
        '
        'Num_FactAgua
        '
        Me.Num_FactAgua.DecimalPlaces = 4
        Me.Num_FactAgua.Location = New System.Drawing.Point(108, 19)
        Me.Num_FactAgua.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.Num_FactAgua.Name = "Num_FactAgua"
        Me.Num_FactAgua.Size = New System.Drawing.Size(120, 20)
        Me.Num_FactAgua.TabIndex = 40
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chBox_Hab_Imp)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.cbx_impresora)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 238)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(426, 84)
        Me.GroupBox2.TabIndex = 38
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Impresora"
        '
        'chBox_Hab_Imp
        '
        Me.chBox_Hab_Imp.AutoSize = True
        Me.chBox_Hab_Imp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chBox_Hab_Imp.Location = New System.Drawing.Point(35, 42)
        Me.chBox_Hab_Imp.Name = "chBox_Hab_Imp"
        Me.chBox_Hab_Imp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chBox_Hab_Imp.Size = New System.Drawing.Size(111, 17)
        Me.chBox_Hab_Imp.TabIndex = 28
        Me.chBox_Hab_Imp.Text = "Usar Impresora"
        Me.chBox_Hab_Imp.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(32, 23)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(66, 13)
        Me.Label24.TabIndex = 26
        Me.Label24.Text = "Impresora:"
        '
        'cbx_impresora
        '
        Me.cbx_impresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbx_impresora.FormattingEnabled = True
        Me.cbx_impresora.Items.AddRange(New Object() {"ZM301", "ZM201", "QW", "GW", "EDS"})
        Me.cbx_impresora.Location = New System.Drawing.Point(118, 15)
        Me.cbx_impresora.Name = "cbx_impresora"
        Me.cbx_impresora.Size = New System.Drawing.Size(231, 21)
        Me.cbx_impresora.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Num_CAgua)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Num_CCemento)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.Num_CArena)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Num_CPiedra)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 138)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Valores de Corte"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.SystemColors.Info
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(243, 23)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(101, 13)
        Me.Label30.TabIndex = 38
        Me.Label30.Text = "* Punto de Corte"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.SystemColors.Info
        Me.Label29.Location = New System.Drawing.Point(243, 36)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(168, 78)
        Me.Label29.TabIndex = 37
        Me.Label29.Text = "Es el valor previo al peso objetivo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "en el que el sistema detiene " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "o reduce la " &
    "dosificación para " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "evitar sobrepeso considerando " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "la inercia y el material que" &
    " aún " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "cae después del cierre."
        '
        'Num_CAgua
        '
        Me.Num_CAgua.DecimalPlaces = 1
        Me.Num_CAgua.Location = New System.Drawing.Point(108, 110)
        Me.Num_CAgua.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Num_CAgua.Name = "Num_CAgua"
        Me.Num_CAgua.Size = New System.Drawing.Size(120, 20)
        Me.Num_CAgua.TabIndex = 36
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(26, 112)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(74, 13)
        Me.Label28.TabIndex = 35
        Me.Label28.Text = "Corte Agua:"
        '
        'Num_CCemento
        '
        Me.Num_CCemento.DecimalPlaces = 1
        Me.Num_CCemento.Location = New System.Drawing.Point(108, 82)
        Me.Num_CCemento.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Num_CCemento.Name = "Num_CCemento"
        Me.Num_CCemento.Size = New System.Drawing.Size(120, 20)
        Me.Num_CCemento.TabIndex = 34
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 84)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(94, 13)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "Corte Cemento:"
        '
        'Num_CArena
        '
        Me.Num_CArena.DecimalPlaces = 1
        Me.Num_CArena.Location = New System.Drawing.Point(108, 51)
        Me.Num_CArena.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Num_CArena.Name = "Num_CArena"
        Me.Num_CArena.Size = New System.Drawing.Size(120, 20)
        Me.Num_CArena.TabIndex = 32
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(22, 53)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(78, 13)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "Corte Arena:"
        '
        'Num_CPiedra
        '
        Me.Num_CPiedra.DecimalPlaces = 1
        Me.Num_CPiedra.Location = New System.Drawing.Point(108, 25)
        Me.Num_CPiedra.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Num_CPiedra.Name = "Num_CPiedra"
        Me.Num_CPiedra.Size = New System.Drawing.Size(120, 20)
        Me.Num_CPiedra.TabIndex = 30
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(19, 27)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(81, 13)
        Me.Label25.TabIndex = 29
        Me.Label25.Text = "Corte Piedra:"
        '
        'Btt_Cancelar
        '
        Me.Btt_Cancelar.BackColor = System.Drawing.SystemColors.Control
        Me.Btt_Cancelar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Btt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btt_Cancelar.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_Cancelar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btt_Cancelar.Image = Global.HORMIGONERA.My.Resources.Resources.cancel
        Me.Btt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Cancelar.Location = New System.Drawing.Point(462, 112)
        Me.Btt_Cancelar.Name = "Btt_Cancelar"
        Me.Btt_Cancelar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Btt_Cancelar.Size = New System.Drawing.Size(94, 41)
        Me.Btt_Cancelar.TabIndex = 15
        Me.Btt_Cancelar.Text = "Cancelar"
        Me.Btt_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Cancelar.UseVisualStyleBackColor = False
        '
        'Btt_Conectar
        '
        Me.Btt_Conectar.BackColor = System.Drawing.SystemColors.Control
        Me.Btt_Conectar.Cursor = System.Windows.Forms.Cursors.Default
        Me.Btt_Conectar.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_Conectar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btt_Conectar.Image = Global.HORMIGONERA.My.Resources.Resources._131694___save
        Me.Btt_Conectar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Conectar.Location = New System.Drawing.Point(462, 54)
        Me.Btt_Conectar.Name = "Btt_Conectar"
        Me.Btt_Conectar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Btt_Conectar.Size = New System.Drawing.Size(94, 41)
        Me.Btt_Conectar.TabIndex = 14
        Me.Btt_Conectar.Text = "Guardar"
        Me.Btt_Conectar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Conectar.UseVisualStyleBackColor = False
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 412)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Btt_Cancelar)
        Me.Controls.Add(Me.Btt_Conectar)
        Me.Name = "frmConfiguracion"
        Me.Text = "Configuración"
        Me.TabControl1.ResumeLayout(False)
        Me.TP_Tolv1.ResumeLayout(False)
        Me.TP_Tolv1.PerformLayout()
        Me.TP_Tolv2.ResumeLayout(False)
        Me.TP_Tolv2.PerformLayout()
        Me.TP_Cemento.ResumeLayout(False)
        Me.TP_Cemento.PerformLayout()
        Me.TP_PLC.ResumeLayout(False)
        Me.TP_PLC.PerformLayout()
        Me.TP_Parametros.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_FactAgua, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Num_CAgua, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_CCemento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_CArena, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Num_CPiedra, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TP_Parametros As TabPage
    Friend WithEvents Label24 As Label
    Friend WithEvents cbx_impresora As ComboBox
    Friend WithEvents chBox_Hab_Imp As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Num_CAgua As NumericUpDown
    Friend WithEvents Label28 As Label
    Friend WithEvents Num_CCemento As NumericUpDown
    Friend WithEvents Label27 As Label
    Friend WithEvents Num_CArena As NumericUpDown
    Friend WithEvents Label26 As Label
    Friend WithEvents Num_CPiedra As NumericUpDown
    Friend WithEvents Label25 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Num_FactAgua As NumericUpDown
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label33 As Label
End Class
