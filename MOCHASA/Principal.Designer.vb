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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Lbl_Puerto = New System.Windows.Forms.Label()
        Me.Lbl_Est_Conn = New System.Windows.Forms.Label()
        Me.Lbl_IpAdd = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_EstadoCon = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Mensj_Sistema = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Tmr_LeeCamara = New System.Windows.Forms.Timer(Me.components)
        Me.Tmr_timeoutConn = New System.Windows.Forms.Timer(Me.components)
        Me.btt_Con_Indicador = New System.Windows.Forms.Button()
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.btnobtener = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btnformulas = New System.Windows.Forms.Button()
        Me.btnEProductos = New System.Windows.Forms.Button()
        Me.btnEOperadores = New System.Windows.Forms.Button()
        Me.btnEIngredientes = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Txt_EstadoCon)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Txt_Mensj_Sistema)
        Me.Panel1.Controls.Add(Me.btt_Con_Indicador)
        Me.Panel1.Controls.Add(Me.btnReportes)
        Me.Panel1.Controls.Add(Me.btnobtener)
        Me.Panel1.Controls.Add(Me.btnsalir)
        Me.Panel1.Controls.Add(Me.btnformulas)
        Me.Panel1.Controls.Add(Me.btnEProductos)
        Me.Panel1.Controls.Add(Me.btnEOperadores)
        Me.Panel1.Controls.Add(Me.btnEIngredientes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(145, 625)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Lbl_Puerto)
        Me.GroupBox1.Controls.Add(Me.Lbl_Est_Conn)
        Me.GroupBox1.Controls.Add(Me.Lbl_IpAdd)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(128, 78)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información:"
        '
        'Lbl_Puerto
        '
        Me.Lbl_Puerto.AutoSize = True
        Me.Lbl_Puerto.BackColor = System.Drawing.Color.White
        Me.Lbl_Puerto.Location = New System.Drawing.Point(48, 36)
        Me.Lbl_Puerto.Name = "Lbl_Puerto"
        Me.Lbl_Puerto.Size = New System.Drawing.Size(37, 13)
        Me.Lbl_Puerto.TabIndex = 17
        Me.Lbl_Puerto.Text = "10101"
        '
        'Lbl_Est_Conn
        '
        Me.Lbl_Est_Conn.AutoSize = True
        Me.Lbl_Est_Conn.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Est_Conn.Location = New System.Drawing.Point(48, 57)
        Me.Lbl_Est_Conn.Name = "Lbl_Est_Conn"
        Me.Lbl_Est_Conn.Size = New System.Drawing.Size(77, 13)
        Me.Lbl_Est_Conn.TabIndex = 0
        Me.Lbl_Est_Conn.Text = "Desconectado"
        '
        'Lbl_IpAdd
        '
        Me.Lbl_IpAdd.AutoSize = True
        Me.Lbl_IpAdd.BackColor = System.Drawing.Color.White
        Me.Lbl_IpAdd.Location = New System.Drawing.Point(48, 15)
        Me.Lbl_IpAdd.Name = "Lbl_IpAdd"
        Me.Lbl_IpAdd.Size = New System.Drawing.Size(70, 13)
        Me.Lbl_IpAdd.TabIndex = 16
        Me.Lbl_IpAdd.Text = "192.168.1.62"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Estado: "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Puerto: "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Dir: "
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 440)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Datos Comunicación:"
        Me.Label2.Visible = False
        '
        'Txt_Mensj_Sistema
        '
        Me.Txt_Mensj_Sistema.Location = New System.Drawing.Point(10, 457)
        Me.Txt_Mensj_Sistema.Multiline = True
        Me.Txt_Mensj_Sistema.Name = "Txt_Mensj_Sistema"
        Me.Txt_Mensj_Sistema.Size = New System.Drawing.Size(116, 31)
        Me.Txt_Mensj_Sistema.TabIndex = 0
        Me.Txt_Mensj_Sistema.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(145, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(603, 625)
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
        Me.btt_Con_Indicador.Image = Global.CM_Construcciones.My.Resources.Resources.disconnect
        Me.btt_Con_Indicador.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btt_Con_Indicador.Location = New System.Drawing.Point(10, 87)
        Me.btt_Con_Indicador.Name = "btt_Con_Indicador"
        Me.btt_Con_Indicador.Size = New System.Drawing.Size(111, 36)
        Me.btt_Con_Indicador.TabIndex = 0
        Me.btt_Con_Indicador.Text = "Conectar Controlador"
        Me.btt_Con_Indicador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btt_Con_Indicador.UseVisualStyleBackColor = True
        '
        'btnReportes
        '
        Me.btnReportes.Image = Global.CM_Construcciones.My.Resources.Resources.chart_curve
        Me.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReportes.Location = New System.Drawing.Point(11, 347)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(111, 39)
        Me.btnReportes.TabIndex = 10
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'btnobtener
        '
        Me.btnobtener.Image = Global.CM_Construcciones.My.Resources.Resources.application_form_magnify
        Me.btnobtener.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnobtener.Location = New System.Drawing.Point(11, 302)
        Me.btnobtener.Name = "btnobtener"
        Me.btnobtener.Size = New System.Drawing.Size(111, 39)
        Me.btnobtener.TabIndex = 9
        Me.btnobtener.Text = "Proceso"
        Me.btnobtener.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnobtener.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.CM_Construcciones.My.Resources.Resources.cancel
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsalir.Location = New System.Drawing.Point(11, 389)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(111, 39)
        Me.btnsalir.TabIndex = 1
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btnformulas
        '
        Me.btnformulas.Image = Global.CM_Construcciones.My.Resources.Resources.form
        Me.btnformulas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnformulas.Location = New System.Drawing.Point(11, 257)
        Me.btnformulas.Name = "btnformulas"
        Me.btnformulas.Size = New System.Drawing.Size(111, 39)
        Me.btnformulas.TabIndex = 8
        Me.btnformulas.Text = "Formulas"
        Me.btnformulas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnformulas.UseVisualStyleBackColor = True
        '
        'btnEProductos
        '
        Me.btnEProductos.Image = Global.CM_Construcciones.My.Resources.Resources.box_closed
        Me.btnEProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEProductos.Location = New System.Drawing.Point(11, 213)
        Me.btnEProductos.Name = "btnEProductos"
        Me.btnEProductos.Size = New System.Drawing.Size(111, 39)
        Me.btnEProductos.TabIndex = 4
        Me.btnEProductos.Text = "Productos"
        Me.btnEProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEProductos.UseVisualStyleBackColor = True
        '
        'btnEOperadores
        '
        Me.btnEOperadores.Image = Global.CM_Construcciones.My.Resources.Resources.group
        Me.btnEOperadores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEOperadores.Location = New System.Drawing.Point(11, 170)
        Me.btnEOperadores.Name = "btnEOperadores"
        Me.btnEOperadores.Size = New System.Drawing.Size(111, 39)
        Me.btnEOperadores.TabIndex = 3
        Me.btnEOperadores.Text = "Operadores"
        Me.btnEOperadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEOperadores.UseVisualStyleBackColor = True
        '
        'btnEIngredientes
        '
        Me.btnEIngredientes.Image = Global.CM_Construcciones.My.Resources.Resources.application_view_columns
        Me.btnEIngredientes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEIngredientes.Location = New System.Drawing.Point(11, 127)
        Me.btnEIngredientes.Name = "btnEIngredientes"
        Me.btnEIngredientes.Size = New System.Drawing.Size(111, 39)
        Me.btnEIngredientes.TabIndex = 2
        Me.btnEIngredientes.Text = "Ingredientes"
        Me.btnEIngredientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEIngredientes.UseVisualStyleBackColor = True
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Lbl_Est_Conn As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btt_Con_Indicador As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Mensj_Sistema As TextBox
    Friend WithEvents Tmr_LeeCamara As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_EstadoCon As TextBox
    Friend WithEvents Tmr_timeoutConn As Timer
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Lbl_Puerto As Label
    Friend WithEvents Lbl_IpAdd As Label
    Friend WithEvents Label5 As Label
End Class
