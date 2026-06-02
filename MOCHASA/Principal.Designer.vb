<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lbl_Operador = New System.Windows.Forms.Label()
        Me.Btt_Proceso = New System.Windows.Forms.Button()
        Me.Gbx_Datos = New System.Windows.Forms.GroupBox()
        Me.btnEOperadores = New System.Windows.Forms.Button()
        Me.Btt_OP = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Gb_Formulacion = New System.Windows.Forms.GroupBox()
        Me.btnEProductos = New System.Windows.Forms.Button()
        Me.btnEIngredientes = New System.Windows.Forms.Button()
        Me.btnformulas = New System.Windows.Forms.Button()
        Me.Gbx_Config = New System.Windows.Forms.GroupBox()
        Me.btt_Con_Indicador = New System.Windows.Forms.Button()
        Me.Btt_Empresa = New System.Windows.Forms.Button()
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_EstadoCon = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Mensj_Sistema = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Tmr_LeeCamara = New System.Windows.Forms.Timer(Me.components)
        Me.Tmr_timeoutConn = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Gbx_Datos.SuspendLayout()
        Me.Gb_Formulacion.SuspendLayout()
        Me.Gbx_Config.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(132, 542)
        Me.Panel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Lbl_Operador)
        Me.FlowLayoutPanel1.Controls.Add(Me.Btt_Proceso)
        Me.FlowLayoutPanel1.Controls.Add(Me.Gbx_Datos)
        Me.FlowLayoutPanel1.Controls.Add(Me.Gb_Formulacion)
        Me.FlowLayoutPanel1.Controls.Add(Me.Gbx_Config)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnReportes)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnsalir)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(130, 540)
        Me.FlowLayoutPanel1.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Operador:"
        '
        'Lbl_Operador
        '
        Me.Lbl_Operador.AutoSize = True
        Me.Lbl_Operador.Location = New System.Drawing.Point(63, 0)
        Me.Lbl_Operador.Name = "Lbl_Operador"
        Me.Lbl_Operador.Size = New System.Drawing.Size(13, 13)
        Me.Lbl_Operador.TabIndex = 17
        Me.Lbl_Operador.Text = "--"
        '
        'Btt_Proceso
        '
        Me.Btt_Proceso.Image = Global.HORMIGONERA.My.Resources.Resources.application_form_magnify
        Me.Btt_Proceso.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Proceso.Location = New System.Drawing.Point(3, 16)
        Me.Btt_Proceso.Name = "Btt_Proceso"
        Me.Btt_Proceso.Size = New System.Drawing.Size(111, 36)
        Me.Btt_Proceso.TabIndex = 9
        Me.Btt_Proceso.Text = "Proceso"
        Me.Btt_Proceso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Proceso.UseVisualStyleBackColor = True
        '
        'Gbx_Datos
        '
        Me.Gbx_Datos.Controls.Add(Me.btnEOperadores)
        Me.Gbx_Datos.Controls.Add(Me.Btt_OP)
        Me.Gbx_Datos.Controls.Add(Me.Button1)
        Me.Gbx_Datos.Controls.Add(Me.Button2)
        Me.Gbx_Datos.Controls.Add(Me.Button3)
        Me.Gbx_Datos.Location = New System.Drawing.Point(3, 58)
        Me.Gbx_Datos.Name = "Gbx_Datos"
        Me.Gbx_Datos.Size = New System.Drawing.Size(117, 230)
        Me.Gbx_Datos.TabIndex = 15
        Me.Gbx_Datos.TabStop = False
        Me.Gbx_Datos.Text = "Datos"
        '
        'btnEOperadores
        '
        Me.btnEOperadores.Image = Global.HORMIGONERA.My.Resources.Resources.group
        Me.btnEOperadores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEOperadores.Location = New System.Drawing.Point(0, 19)
        Me.btnEOperadores.Name = "btnEOperadores"
        Me.btnEOperadores.Size = New System.Drawing.Size(111, 36)
        Me.btnEOperadores.TabIndex = 3
        Me.btnEOperadores.Text = "Operadores"
        Me.btnEOperadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEOperadores.UseVisualStyleBackColor = True
        '
        'Btt_OP
        '
        Me.Btt_OP.Image = Global.HORMIGONERA.My.Resources.Resources.column_double
        Me.Btt_OP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_OP.Location = New System.Drawing.Point(0, 185)
        Me.Btt_OP.Name = "Btt_OP"
        Me.Btt_OP.Size = New System.Drawing.Size(111, 39)
        Me.Btt_OP.TabIndex = 9
        Me.Btt_OP.Text = "Orden de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Despacho"
        Me.Btt_OP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_OP.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.HORMIGONERA.My.Resources.Resources.group
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(0, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 36)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Clientes"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.HORMIGONERA.My.Resources.Resources.group
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.Location = New System.Drawing.Point(0, 103)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 36)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Choferes"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = Global.HORMIGONERA.My.Resources.Resources.application_view_columns
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.Location = New System.Drawing.Point(0, 145)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(111, 36)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Mixers"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Gb_Formulacion
        '
        Me.Gb_Formulacion.Controls.Add(Me.btnEProductos)
        Me.Gb_Formulacion.Controls.Add(Me.btnEIngredientes)
        Me.Gb_Formulacion.Controls.Add(Me.btnformulas)
        Me.Gb_Formulacion.Location = New System.Drawing.Point(3, 294)
        Me.Gb_Formulacion.Name = "Gb_Formulacion"
        Me.Gb_Formulacion.Size = New System.Drawing.Size(117, 150)
        Me.Gb_Formulacion.TabIndex = 14
        Me.Gb_Formulacion.TabStop = False
        Me.Gb_Formulacion.Text = "Formulación"
        '
        'btnEProductos
        '
        Me.btnEProductos.Image = Global.HORMIGONERA.My.Resources.Resources.box_closed
        Me.btnEProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEProductos.Location = New System.Drawing.Point(0, 19)
        Me.btnEProductos.Name = "btnEProductos"
        Me.btnEProductos.Size = New System.Drawing.Size(111, 36)
        Me.btnEProductos.TabIndex = 4
        Me.btnEProductos.Text = "Productos"
        Me.btnEProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEProductos.UseVisualStyleBackColor = True
        '
        'btnEIngredientes
        '
        Me.btnEIngredientes.Image = Global.HORMIGONERA.My.Resources.Resources.application_view_columns
        Me.btnEIngredientes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEIngredientes.Location = New System.Drawing.Point(0, 61)
        Me.btnEIngredientes.Name = "btnEIngredientes"
        Me.btnEIngredientes.Size = New System.Drawing.Size(111, 36)
        Me.btnEIngredientes.TabIndex = 2
        Me.btnEIngredientes.Text = "Ingredientes"
        Me.btnEIngredientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEIngredientes.UseVisualStyleBackColor = True
        '
        'btnformulas
        '
        Me.btnformulas.Image = Global.HORMIGONERA.My.Resources.Resources.form
        Me.btnformulas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnformulas.Location = New System.Drawing.Point(0, 103)
        Me.btnformulas.Name = "btnformulas"
        Me.btnformulas.Size = New System.Drawing.Size(111, 36)
        Me.btnformulas.TabIndex = 8
        Me.btnformulas.Text = "Formulas"
        Me.btnformulas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnformulas.UseVisualStyleBackColor = True
        '
        'Gbx_Config
        '
        Me.Gbx_Config.Controls.Add(Me.btt_Con_Indicador)
        Me.Gbx_Config.Controls.Add(Me.Btt_Empresa)
        Me.Gbx_Config.Location = New System.Drawing.Point(3, 450)
        Me.Gbx_Config.Name = "Gbx_Config"
        Me.Gbx_Config.Size = New System.Drawing.Size(121, 107)
        Me.Gbx_Config.TabIndex = 16
        Me.Gbx_Config.TabStop = False
        Me.Gbx_Config.Text = "Configuración"
        '
        'btt_Con_Indicador
        '
        Me.btt_Con_Indicador.Image = Global.HORMIGONERA.My.Resources.Resources.cog_edit
        Me.btt_Con_Indicador.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btt_Con_Indicador.Location = New System.Drawing.Point(0, 16)
        Me.btt_Con_Indicador.Name = "btt_Con_Indicador"
        Me.btt_Con_Indicador.Size = New System.Drawing.Size(111, 36)
        Me.btt_Con_Indicador.TabIndex = 0
        Me.btt_Con_Indicador.Text = "Configuración"
        Me.btt_Con_Indicador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btt_Con_Indicador.UseVisualStyleBackColor = True
        '
        'Btt_Empresa
        '
        Me.Btt_Empresa.Image = Global.HORMIGONERA.My.Resources.Resources.setting_tools
        Me.Btt_Empresa.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Empresa.Location = New System.Drawing.Point(0, 59)
        Me.Btt_Empresa.Name = "Btt_Empresa"
        Me.Btt_Empresa.Size = New System.Drawing.Size(111, 42)
        Me.Btt_Empresa.TabIndex = 15
        Me.Btt_Empresa.Text = "Datos" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Empresa"
        Me.Btt_Empresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Empresa.UseVisualStyleBackColor = True
        '
        'btnReportes
        '
        Me.btnReportes.Image = Global.HORMIGONERA.My.Resources.Resources.chart_curve
        Me.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReportes.Location = New System.Drawing.Point(3, 563)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(111, 36)
        Me.btnReportes.TabIndex = 10
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.HORMIGONERA.My.Resources.Resources.cancel
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsalir.Location = New System.Drawing.Point(3, 605)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(111, 36)
        Me.btnsalir.TabIndex = 1
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Mensajes Sistema:"
        Me.Label3.Visible = False
        '
        'Txt_EstadoCon
        '
        Me.Txt_EstadoCon.Location = New System.Drawing.Point(21, 41)
        Me.Txt_EstadoCon.Multiline = True
        Me.Txt_EstadoCon.Name = "Txt_EstadoCon"
        Me.Txt_EstadoCon.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Txt_EstadoCon.Size = New System.Drawing.Size(116, 64)
        Me.Txt_EstadoCon.TabIndex = 12
        Me.Txt_EstadoCon.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Datos Comunicación:"
        Me.Label2.Visible = False
        '
        'Txt_Mensj_Sistema
        '
        Me.Txt_Mensj_Sistema.Location = New System.Drawing.Point(21, 123)
        Me.Txt_Mensj_Sistema.Multiline = True
        Me.Txt_Mensj_Sistema.Name = "Txt_Mensj_Sistema"
        Me.Txt_Mensj_Sistema.Size = New System.Drawing.Size(116, 31)
        Me.Txt_Mensj_Sistema.TabIndex = 0
        Me.Txt_Mensj_Sistema.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel2.Controls.Add(Me.Txt_Mensj_Sistema)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Txt_EstadoCon)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(132, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(616, 542)
        Me.Panel2.TabIndex = 3
        '
        'Tmr_LeeCamara
        '
        '
        'Tmr_timeoutConn
        '
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.IsMdiContainer = True
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EUFRATES CONSTRUCTORA.- PLANTA DE HORMIGON"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Gbx_Datos.ResumeLayout(False)
        Me.Gb_Formulacion.ResumeLayout(False)
        Me.Gbx_Config.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEProductos As System.Windows.Forms.Button
    Friend WithEvents btnEOperadores As System.Windows.Forms.Button
    Friend WithEvents btnEIngredientes As System.Windows.Forms.Button
    Friend WithEvents btnformulas As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btt_Proceso As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnReportes As System.Windows.Forms.Button
    Friend WithEvents btt_Con_Indicador As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Mensj_Sistema As TextBox
    Friend WithEvents Tmr_LeeCamara As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_EstadoCon As TextBox
    Friend WithEvents Tmr_timeoutConn As Timer
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Gbx_Datos As GroupBox
    Friend WithEvents Gb_Formulacion As GroupBox
    Friend WithEvents Btt_OP As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Lbl_Operador As Label
    Friend WithEvents Btt_Empresa As Button
    Friend WithEvents Gbx_Config As GroupBox
End Class
