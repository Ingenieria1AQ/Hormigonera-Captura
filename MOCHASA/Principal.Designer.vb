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
        Me.Txt_EstadoCon = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnobtener = New System.Windows.Forms.Button()
        Me.btnEOperadores = New System.Windows.Forms.Button()
        Me.btnEProductos = New System.Windows.Forms.Button()
        Me.btnEIngredientes = New System.Windows.Forms.Button()
        Me.btnformulas = New System.Windows.Forms.Button()
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Mensj_Sistema = New System.Windows.Forms.TextBox()
        Me.btt_Con_Indicador = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Tmr_LeeCamara = New System.Windows.Forms.Timer(Me.components)
        Me.Tmr_timeoutConn = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Btt_OP = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        'Txt_EstadoCon
        '
        Me.Txt_EstadoCon.Location = New System.Drawing.Point(3, 626)
        Me.Txt_EstadoCon.Multiline = True
        Me.Txt_EstadoCon.Name = "Txt_EstadoCon"
        Me.Txt_EstadoCon.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Txt_EstadoCon.Size = New System.Drawing.Size(116, 64)
        Me.Txt_EstadoCon.TabIndex = 12
        Me.Txt_EstadoCon.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.btnobtener)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnReportes)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnsalir)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Txt_Mensj_Sistema)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Txt_EstadoCon)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(130, 540)
        Me.FlowLayoutPanel1.TabIndex = 14
        '
        'btnobtener
        '
        Me.btnobtener.Image = Global.HORMIGONERA.My.Resources.Resources.application_form_magnify
        Me.btnobtener.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnobtener.Location = New System.Drawing.Point(3, 3)
        Me.btnobtener.Name = "btnobtener"
        Me.btnobtener.Size = New System.Drawing.Size(111, 36)
        Me.btnobtener.TabIndex = 9
        Me.btnobtener.Text = "Proceso"
        Me.btnobtener.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnobtener.UseVisualStyleBackColor = True
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
        'btnReportes
        '
        Me.btnReportes.Image = Global.HORMIGONERA.My.Resources.Resources.chart_curve
        Me.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReportes.Location = New System.Drawing.Point(3, 479)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(111, 36)
        Me.btnReportes.TabIndex = 10
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 560)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Datos Comunicación:"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 610)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Mensajes Sistema:"
        Me.Label3.Visible = False
        '
        'Txt_Mensj_Sistema
        '
        Me.Txt_Mensj_Sistema.Location = New System.Drawing.Point(3, 576)
        Me.Txt_Mensj_Sistema.Multiline = True
        Me.Txt_Mensj_Sistema.Name = "Txt_Mensj_Sistema"
        Me.Txt_Mensj_Sistema.Size = New System.Drawing.Size(116, 31)
        Me.Txt_Mensj_Sistema.TabIndex = 0
        Me.Txt_Mensj_Sistema.Visible = False
        '
        'btt_Con_Indicador
        '
        Me.btt_Con_Indicador.Image = Global.HORMIGONERA.My.Resources.Resources.cog_edit
        Me.btt_Con_Indicador.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btt_Con_Indicador.Location = New System.Drawing.Point(0, 187)
        Me.btt_Con_Indicador.Name = "btt_Con_Indicador"
        Me.btt_Con_Indicador.Size = New System.Drawing.Size(111, 36)
        Me.btt_Con_Indicador.TabIndex = 0
        Me.btt_Con_Indicador.Text = "Configuración"
        Me.btt_Con_Indicador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btt_Con_Indicador.UseVisualStyleBackColor = True
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
        'btnsalir
        '
        Me.btnsalir.Image = Global.HORMIGONERA.My.Resources.Resources.cancel
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsalir.Location = New System.Drawing.Point(3, 521)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(111, 36)
        Me.btnsalir.TabIndex = 1
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonShadow
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEOperadores)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btt_Con_Indicador)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(117, 231)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Btt_OP)
        Me.GroupBox2.Controls.Add(Me.btnEProductos)
        Me.GroupBox2.Controls.Add(Me.btnEIngredientes)
        Me.GroupBox2.Controls.Add(Me.btnformulas)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 282)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(117, 191)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Formulación"
        '
        'Btt_OP
        '
        Me.Btt_OP.Image = Global.HORMIGONERA.My.Resources.Resources.column_double
        Me.Btt_OP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_OP.Location = New System.Drawing.Point(0, 145)
        Me.Btt_OP.Name = "Btt_OP"
        Me.Btt_OP.Size = New System.Drawing.Size(111, 39)
        Me.Btt_OP.TabIndex = 9
        Me.Btt_OP.Text = "Orden de" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Despacho"
        Me.Btt_OP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_OP.UseVisualStyleBackColor = True
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEProductos As System.Windows.Forms.Button
    Friend WithEvents btnEOperadores As System.Windows.Forms.Button
    Friend WithEvents btnEIngredientes As System.Windows.Forms.Button
    Friend WithEvents btnformulas As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnobtener As System.Windows.Forms.Button
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
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Btt_OP As Button
End Class
