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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Mensj_Sistema = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_EstadoCon = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Tmr_LeeCamara = New System.Windows.Forms.Timer(Me.components)
        Me.Tmr_timeoutConn = New System.Windows.Forms.Timer(Me.components)
        Me.btt_Con_Indicador = New System.Windows.Forms.Button()
        Me.btnEIngredientes = New System.Windows.Forms.Button()
        Me.btnEOperadores = New System.Windows.Forms.Button()
        Me.btnEProductos = New System.Windows.Forms.Button()
        Me.btnformulas = New System.Windows.Forms.Button()
        Me.btnobtener = New System.Windows.Forms.Button()
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Txt_EstadoCon)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(133, 625)
        Me.Panel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btt_Con_Indicador)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnEIngredientes)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnEOperadores)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnEProductos)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnformulas)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnobtener)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnReportes)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnsalir)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Txt_Mensj_Sistema)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(131, 623)
        Me.FlowLayoutPanel1.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 360)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Datos Comunicación:"
        Me.Label2.Visible = False
        '
        'Txt_Mensj_Sistema
        '
        Me.Txt_Mensj_Sistema.Location = New System.Drawing.Point(3, 376)
        Me.Txt_Mensj_Sistema.Multiline = True
        Me.Txt_Mensj_Sistema.Name = "Txt_Mensj_Sistema"
        Me.Txt_Mensj_Sistema.Size = New System.Drawing.Size(116, 31)
        Me.Txt_Mensj_Sistema.TabIndex = 0
        Me.Txt_Mensj_Sistema.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 493)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Mensajes Sistema:"
        Me.Label3.Visible = False
        '
        'Txt_EstadoCon
        '
        Me.Txt_EstadoCon.Location = New System.Drawing.Point(11, 509)
        Me.Txt_EstadoCon.Multiline = True
        Me.Txt_EstadoCon.Name = "Txt_EstadoCon"
        Me.Txt_EstadoCon.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Txt_EstadoCon.Size = New System.Drawing.Size(116, 64)
        Me.Txt_EstadoCon.TabIndex = 12
        Me.Txt_EstadoCon.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(133, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(615, 625)
        Me.Panel2.TabIndex = 3
        '
        'Tmr_LeeCamara
        '
        '
        'Tmr_timeoutConn
        '
        '
        'btt_Con_Indicador
        '
        Me.btt_Con_Indicador.Image = Global.HORMIGONERA.My.Resources.Resources.cog_edit
        Me.btt_Con_Indicador.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btt_Con_Indicador.Location = New System.Drawing.Point(3, 3)
        Me.btt_Con_Indicador.Name = "btt_Con_Indicador"
        Me.btt_Con_Indicador.Size = New System.Drawing.Size(111, 39)
        Me.btt_Con_Indicador.TabIndex = 0
        Me.btt_Con_Indicador.Text = "Configuración"
        Me.btt_Con_Indicador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btt_Con_Indicador.UseVisualStyleBackColor = True
        '
        'btnEIngredientes
        '
        Me.btnEIngredientes.Image = Global.HORMIGONERA.My.Resources.Resources.application_view_columns
        Me.btnEIngredientes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEIngredientes.Location = New System.Drawing.Point(3, 48)
        Me.btnEIngredientes.Name = "btnEIngredientes"
        Me.btnEIngredientes.Size = New System.Drawing.Size(111, 39)
        Me.btnEIngredientes.TabIndex = 2
        Me.btnEIngredientes.Text = "Ingredientes"
        Me.btnEIngredientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEIngredientes.UseVisualStyleBackColor = True
        '
        'btnEOperadores
        '
        Me.btnEOperadores.Image = Global.HORMIGONERA.My.Resources.Resources.group
        Me.btnEOperadores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEOperadores.Location = New System.Drawing.Point(3, 93)
        Me.btnEOperadores.Name = "btnEOperadores"
        Me.btnEOperadores.Size = New System.Drawing.Size(111, 39)
        Me.btnEOperadores.TabIndex = 3
        Me.btnEOperadores.Text = "Operadores"
        Me.btnEOperadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEOperadores.UseVisualStyleBackColor = True
        '
        'btnEProductos
        '
        Me.btnEProductos.Image = Global.HORMIGONERA.My.Resources.Resources.box_closed
        Me.btnEProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEProductos.Location = New System.Drawing.Point(3, 138)
        Me.btnEProductos.Name = "btnEProductos"
        Me.btnEProductos.Size = New System.Drawing.Size(111, 39)
        Me.btnEProductos.TabIndex = 4
        Me.btnEProductos.Text = "Productos"
        Me.btnEProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEProductos.UseVisualStyleBackColor = True
        '
        'btnformulas
        '
        Me.btnformulas.Image = Global.HORMIGONERA.My.Resources.Resources.form
        Me.btnformulas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnformulas.Location = New System.Drawing.Point(3, 183)
        Me.btnformulas.Name = "btnformulas"
        Me.btnformulas.Size = New System.Drawing.Size(111, 39)
        Me.btnformulas.TabIndex = 8
        Me.btnformulas.Text = "Formulas"
        Me.btnformulas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnformulas.UseVisualStyleBackColor = True
        '
        'btnobtener
        '
        Me.btnobtener.Image = Global.HORMIGONERA.My.Resources.Resources.application_form_magnify
        Me.btnobtener.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnobtener.Location = New System.Drawing.Point(3, 228)
        Me.btnobtener.Name = "btnobtener"
        Me.btnobtener.Size = New System.Drawing.Size(111, 39)
        Me.btnobtener.TabIndex = 9
        Me.btnobtener.Text = "Proceso"
        Me.btnobtener.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnobtener.UseVisualStyleBackColor = True
        '
        'btnReportes
        '
        Me.btnReportes.Image = Global.HORMIGONERA.My.Resources.Resources.chart_curve
        Me.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReportes.Location = New System.Drawing.Point(3, 273)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(111, 39)
        Me.btnReportes.TabIndex = 10
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.HORMIGONERA.My.Resources.Resources.cancel
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsalir.Location = New System.Drawing.Point(3, 318)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(111, 39)
        Me.btnsalir.TabIndex = 1
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 625)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.IsMdiContainer = True
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CM CONSTRUCCIONES.- PLANTA DE HORMIGON"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
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
End Class
