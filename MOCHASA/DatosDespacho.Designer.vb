<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DatosDespacho
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DatosDespacho))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltipo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblcomprobante = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtfecha = New System.Windows.Forms.TextBox()
        Me.txthora = New System.Windows.Forms.TextBox()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.txtdocumento = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtobservaciones = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.NumericM3 = New System.Windows.Forms.NumericUpDown()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtNomMixer = New System.Windows.Forms.TextBox()
        Me.txtidMixer = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtm3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.nomProducto = New System.Windows.Forms.TextBox()
        Me.codProducto = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.nomCliente = New System.Windows.Forms.TextBox()
        Me.codCliente = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.nomChofer = New System.Windows.Forms.TextBox()
        Me.codChofer = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lbloperador = New System.Windows.Forms.Label()
        Me.btnokclave = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnagregar = New System.Windows.Forms.Button()
        Me.tab1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericM3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tab2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(664, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo:"
        Me.Label1.Visible = False
        '
        'lbltipo
        '
        Me.lbltipo.AutoSize = True
        Me.lbltipo.BackColor = System.Drawing.Color.White
        Me.lbltipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipo.Location = New System.Drawing.Point(723, 49)
        Me.lbltipo.Name = "lbltipo"
        Me.lbltipo.Size = New System.Drawing.Size(19, 20)
        Me.lbltipo.TabIndex = 1
        Me.lbltipo.Text = "--"
        Me.lbltipo.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(233, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(183, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Comprobante Despacho:"
        '
        'lblcomprobante
        '
        Me.lblcomprobante.AutoSize = True
        Me.lblcomprobante.BackColor = System.Drawing.Color.White
        Me.lblcomprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcomprobante.Location = New System.Drawing.Point(451, 62)
        Me.lblcomprobante.Name = "lblcomprobante"
        Me.lblcomprobante.Size = New System.Drawing.Size(19, 20)
        Me.lblcomprobante.TabIndex = 3
        Me.lblcomprobante.Text = "--"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cliente:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Producto:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Chofer:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(521, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Hora:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(520, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Fecha:"
        '
        'txtfecha
        '
        Me.txtfecha.BackColor = System.Drawing.Color.White
        Me.txtfecha.Enabled = False
        Me.txtfecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecha.Location = New System.Drawing.Point(606, 18)
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.Size = New System.Drawing.Size(128, 20)
        Me.txtfecha.TabIndex = 7
        '
        'txthora
        '
        Me.txthora.BackColor = System.Drawing.Color.White
        Me.txthora.Enabled = False
        Me.txthora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthora.Location = New System.Drawing.Point(606, 44)
        Me.txthora.Name = "txthora"
        Me.txthora.Size = New System.Drawing.Size(128, 20)
        Me.txthora.TabIndex = 8
        '
        'txtPlaca
        '
        Me.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlaca.Location = New System.Drawing.Point(606, 100)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(128, 20)
        Me.txtPlaca.TabIndex = 10
        '
        'txtdocumento
        '
        Me.txtdocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdocumento.Location = New System.Drawing.Point(606, 72)
        Me.txtdocumento.Name = "txtdocumento"
        Me.txtdocumento.Size = New System.Drawing.Size(128, 20)
        Me.txtdocumento.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(521, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Placa:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(520, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Documento:"
        '
        'txtobservaciones
        '
        Me.txtobservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtobservaciones.Location = New System.Drawing.Point(132, 162)
        Me.txtobservaciones.Name = "txtobservaciones"
        Me.txtobservaciones.Size = New System.Drawing.Size(602, 20)
        Me.txtobservaciones.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(19, 161)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Observaciones:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.NumericM3)
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.txtNomMixer)
        Me.GroupBox2.Controls.Add(Me.txtidMixer)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtm3)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.nomProducto)
        Me.GroupBox2.Controls.Add(Me.codProducto)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.nomCliente)
        Me.GroupBox2.Controls.Add(Me.codCliente)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.nomChofer)
        Me.GroupBox2.Controls.Add(Me.codChofer)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtdocumento)
        Me.GroupBox2.Controls.Add(Me.txthora)
        Me.GroupBox2.Controls.Add(Me.txtobservaciones)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtPlaca)
        Me.GroupBox2.Controls.Add(Me.txtfecha)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 115)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(754, 197)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'NumericM3
        '
        Me.NumericM3.DecimalPlaces = 1
        Me.NumericM3.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.NumericM3.Location = New System.Drawing.Point(606, 126)
        Me.NumericM3.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericM3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericM3.Name = "NumericM3"
        Me.NumericM3.Size = New System.Drawing.Size(71, 20)
        Me.NumericM3.TabIndex = 218
        Me.NumericM3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(443, 104)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(27, 21)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtNomMixer
        '
        Me.txtNomMixer.BackColor = System.Drawing.Color.White
        Me.txtNomMixer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomMixer.Location = New System.Drawing.Point(188, 103)
        Me.txtNomMixer.Name = "txtNomMixer"
        Me.txtNomMixer.Size = New System.Drawing.Size(238, 20)
        Me.txtNomMixer.TabIndex = 22
        '
        'txtidMixer
        '
        Me.txtidMixer.BackColor = System.Drawing.Color.White
        Me.txtidMixer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtidMixer.Location = New System.Drawing.Point(111, 103)
        Me.txtidMixer.Name = "txtidMixer"
        Me.txtidMixer.Size = New System.Drawing.Size(70, 20)
        Me.txtidMixer.TabIndex = 21
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(19, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Mixer:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(683, 130)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "m3"
        '
        'txtm3
        '
        Me.txtm3.BackColor = System.Drawing.Color.White
        Me.txtm3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtm3.Location = New System.Drawing.Point(429, 136)
        Me.txtm3.Name = "txtm3"
        Me.txtm3.Size = New System.Drawing.Size(70, 20)
        Me.txtm3.TabIndex = 18
        Me.txtm3.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(521, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Cantidad:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(443, 43)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(27, 21)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "..."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'nomProducto
        '
        Me.nomProducto.BackColor = System.Drawing.Color.White
        Me.nomProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomProducto.Location = New System.Drawing.Point(188, 42)
        Me.nomProducto.Name = "nomProducto"
        Me.nomProducto.Size = New System.Drawing.Size(238, 20)
        Me.nomProducto.TabIndex = 3
        '
        'codProducto
        '
        Me.codProducto.BackColor = System.Drawing.Color.White
        Me.codProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codProducto.Location = New System.Drawing.Point(111, 42)
        Me.codProducto.Name = "codProducto"
        Me.codProducto.Size = New System.Drawing.Size(70, 20)
        Me.codProducto.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(443, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(27, 21)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'nomCliente
        '
        Me.nomCliente.BackColor = System.Drawing.Color.White
        Me.nomCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomCliente.Location = New System.Drawing.Point(188, 13)
        Me.nomCliente.Name = "nomCliente"
        Me.nomCliente.Size = New System.Drawing.Size(238, 20)
        Me.nomCliente.TabIndex = 1
        '
        'codCliente
        '
        Me.codCliente.BackColor = System.Drawing.Color.White
        Me.codCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codCliente.Location = New System.Drawing.Point(111, 13)
        Me.codCliente.Name = "codCliente"
        Me.codCliente.Size = New System.Drawing.Size(70, 20)
        Me.codCliente.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(443, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 21)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'nomChofer
        '
        Me.nomChofer.BackColor = System.Drawing.Color.White
        Me.nomChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nomChofer.Location = New System.Drawing.Point(188, 74)
        Me.nomChofer.Name = "nomChofer"
        Me.nomChofer.Size = New System.Drawing.Size(238, 20)
        Me.nomChofer.TabIndex = 6
        '
        'codChofer
        '
        Me.codChofer.BackColor = System.Drawing.Color.White
        Me.codChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codChofer.Location = New System.Drawing.Point(111, 74)
        Me.codChofer.Name = "codChofer"
        Me.codChofer.Size = New System.Drawing.Size(70, 20)
        Me.codChofer.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(13, 330)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 16)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Operador:"
        '
        'lbloperador
        '
        Me.lbloperador.AutoSize = True
        Me.lbloperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbloperador.Location = New System.Drawing.Point(84, 330)
        Me.lbloperador.Name = "lbloperador"
        Me.lbloperador.Size = New System.Drawing.Size(16, 16)
        Me.lbloperador.TabIndex = 41
        Me.lbloperador.Text = "--"
        '
        'btnokclave
        '
        Me.btnokclave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnokclave.Location = New System.Drawing.Point(632, 5)
        Me.btnokclave.Name = "btnokclave"
        Me.btnokclave.Size = New System.Drawing.Size(125, 40)
        Me.btnokclave.TabIndex = 1
        Me.btnokclave.Text = "Seleccionar"
        Me.btnokclave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnokclave.UseVisualStyleBackColor = True
        Me.btnokclave.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 20000
        '
        'btnguardar
        '
        Me.btnguardar.Image = Global.HORMIGONERA.My.Resources.Resources.application_form_add
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnguardar.Location = New System.Drawing.Point(487, 318)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(125, 40)
        Me.btnguardar.TabIndex = 5
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(607, 144)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(125, 40)
        Me.btnReporte.TabIndex = 6
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = True
        Me.btnReporte.Visible = False
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.HORMIGONERA.My.Resources.Resources._131885___close_door_exit_log_out_logout_user_logout
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsalir.Location = New System.Drawing.Point(607, 341)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(125, 40)
        Me.btnsalir.TabIndex = 3
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.HORMIGONERA.My.Resources.Resources._131907___edit_files_page_pen_pencil_text_write
        Me.btnmodificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnmodificar.Location = New System.Drawing.Point(607, 89)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(125, 40)
        Me.btnmodificar.TabIndex = 2
        Me.btnmodificar.Text = "Modificar"
        Me.btnmodificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnagregar
        '
        Me.btnagregar.Image = Global.HORMIGONERA.My.Resources.Resources._131897___file_new
        Me.btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnagregar.Location = New System.Drawing.Point(607, 34)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(125, 40)
        Me.btnagregar.TabIndex = 1
        Me.btnagregar.Text = "Crear Nuevo"
        Me.btnagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'tab1
        '
        Me.tab1.Controls.Add(Me.btnReporte)
        Me.tab1.Controls.Add(Me.btnsalir)
        Me.tab1.Controls.Add(Me.btnmodificar)
        Me.tab1.Controls.Add(Me.btnagregar)
        Me.tab1.Controls.Add(Me.DataGridView1)
        Me.tab1.Location = New System.Drawing.Point(4, 22)
        Me.tab1.Name = "tab1"
        Me.tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.tab1.Size = New System.Drawing.Size(831, 506)
        Me.tab1.TabIndex = 0
        Me.tab1.Text = "Lista"
        Me.tab1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(567, 499)
        Me.DataGridView1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab1)
        Me.TabControl1.Controls.Add(Me.tab2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(839, 532)
        Me.TabControl1.TabIndex = 42
        '
        'tab2
        '
        Me.tab2.Controls.Add(Me.lbloperador)
        Me.tab2.Controls.Add(Me.Label3)
        Me.tab2.Controls.Add(Me.Label16)
        Me.tab2.Controls.Add(Me.Label1)
        Me.tab2.Controls.Add(Me.btnokclave)
        Me.tab2.Controls.Add(Me.lbltipo)
        Me.tab2.Controls.Add(Me.lblcomprobante)
        Me.tab2.Controls.Add(Me.btnguardar)
        Me.tab2.Controls.Add(Me.GroupBox2)
        Me.tab2.Location = New System.Drawing.Point(4, 22)
        Me.tab2.Name = "tab2"
        Me.tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2.Size = New System.Drawing.Size(831, 506)
        Me.tab2.TabIndex = 1
        Me.tab2.Text = "Detalles"
        Me.tab2.UseVisualStyleBackColor = True
        '
        'DatosDespacho
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(882, 615)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DatosDespacho"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de Despacho - Ingreso datos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericM3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tab2.ResumeLayout(False)
        Me.tab2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbltipo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblcomprobante As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtfecha As System.Windows.Forms.TextBox
    Friend WithEvents txthora As System.Windows.Forms.TextBox
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents txtdocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtobservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnokclave As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lbloperador As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents nomProducto As System.Windows.Forms.TextBox
    Friend WithEvents codProducto As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents nomCliente As System.Windows.Forms.TextBox
    Friend WithEvents codCliente As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents nomChofer As System.Windows.Forms.TextBox
    Friend WithEvents codChofer As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtm3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button4 As Button
    Friend WithEvents txtNomMixer As TextBox
    Friend WithEvents txtidMixer As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents NumericM3 As NumericUpDown
    Friend WithEvents btnReporte As Button
    Friend WithEvents btnsalir As Button
    Friend WithEvents btnmodificar As Button
    Friend WithEvents btnagregar As Button
    Friend WithEvents tab1 As TabPage
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tab2 As TabPage
End Class
