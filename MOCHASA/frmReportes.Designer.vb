<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportes
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Btt_PrintOD = New System.Windows.Forms.Button()
        Me.btnOrdenDespacho = New System.Windows.Forms.Button()
        Me.txtOrdenDespacho = New System.Windows.Forms.TextBox()
        Me.cbOrdenDespacho = New System.Windows.Forms.CheckBox()
        Me.txtNomIngrediente = New System.Windows.Forms.TextBox()
        Me.txtNomProducto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.rbproducto = New System.Windows.Forms.RadioButton()
        Me.rbingrediente = New System.Windows.Forms.RadioButton()
        Me.rboperador = New System.Windows.Forms.RadioButton()
        Me.btnproducto = New System.Windows.Forms.Button()
        Me.btningrediente = New System.Windows.Forms.Button()
        Me.btnoperador = New System.Windows.Forms.Button()
        Me.txtproducto = New System.Windows.Forms.TextBox()
        Me.txtingrediente = New System.Windows.Forms.TextBox()
        Me.txtoperador = New System.Windows.Forms.TextBox()
        Me.cbproducto = New System.Windows.Forms.CheckBox()
        Me.cbingrediente = New System.Windows.Forms.CheckBox()
        Me.cboperador = New System.Windows.Forms.CheckBox()
        Me.cbfechas = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpfedesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpfehasta = New System.Windows.Forms.DateTimePicker()
        Me.Salir = New System.Windows.Forms.Button()
        Me.Reporte = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Btt_PrintOD)
        Me.Panel1.Controls.Add(Me.btnOrdenDespacho)
        Me.Panel1.Controls.Add(Me.txtOrdenDespacho)
        Me.Panel1.Controls.Add(Me.cbOrdenDespacho)
        Me.Panel1.Controls.Add(Me.txtNomIngrediente)
        Me.Panel1.Controls.Add(Me.txtNomProducto)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.btnproducto)
        Me.Panel1.Controls.Add(Me.btningrediente)
        Me.Panel1.Controls.Add(Me.btnoperador)
        Me.Panel1.Controls.Add(Me.txtproducto)
        Me.Panel1.Controls.Add(Me.txtingrediente)
        Me.Panel1.Controls.Add(Me.txtoperador)
        Me.Panel1.Controls.Add(Me.cbproducto)
        Me.Panel1.Controls.Add(Me.cbingrediente)
        Me.Panel1.Controls.Add(Me.cboperador)
        Me.Panel1.Controls.Add(Me.cbfechas)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(364, 344)
        Me.Panel1.TabIndex = 11
        '
        'Btt_PrintOD
        '
        Me.Btt_PrintOD.Enabled = False
        Me.Btt_PrintOD.Image = Global.HORMIGONERA.My.Resources.Resources.printer
        Me.Btt_PrintOD.Location = New System.Drawing.Point(254, 28)
        Me.Btt_PrintOD.Name = "Btt_PrintOD"
        Me.Btt_PrintOD.Size = New System.Drawing.Size(36, 33)
        Me.Btt_PrintOD.TabIndex = 33
        Me.Btt_PrintOD.Text = "..."
        Me.Btt_PrintOD.UseVisualStyleBackColor = True
        Me.Btt_PrintOD.Visible = False
        '
        'btnOrdenDespacho
        '
        Me.btnOrdenDespacho.Enabled = False
        Me.btnOrdenDespacho.Location = New System.Drawing.Point(223, 33)
        Me.btnOrdenDespacho.Name = "btnOrdenDespacho"
        Me.btnOrdenDespacho.Size = New System.Drawing.Size(25, 23)
        Me.btnOrdenDespacho.TabIndex = 32
        Me.btnOrdenDespacho.Text = "..."
        Me.btnOrdenDespacho.UseVisualStyleBackColor = True
        '
        'txtOrdenDespacho
        '
        Me.txtOrdenDespacho.Enabled = False
        Me.txtOrdenDespacho.Location = New System.Drawing.Point(116, 35)
        Me.txtOrdenDespacho.Name = "txtOrdenDespacho"
        Me.txtOrdenDespacho.Size = New System.Drawing.Size(100, 20)
        Me.txtOrdenDespacho.TabIndex = 31
        '
        'cbOrdenDespacho
        '
        Me.cbOrdenDespacho.AutoSize = True
        Me.cbOrdenDespacho.Location = New System.Drawing.Point(18, 12)
        Me.cbOrdenDespacho.Name = "cbOrdenDespacho"
        Me.cbOrdenDespacho.Size = New System.Drawing.Size(141, 17)
        Me.cbOrdenDespacho.TabIndex = 30
        Me.cbOrdenDespacho.Text = "Por Orden de Despacho"
        Me.cbOrdenDespacho.UseVisualStyleBackColor = True
        '
        'txtNomIngrediente
        '
        Me.txtNomIngrediente.Enabled = False
        Me.txtNomIngrediente.Location = New System.Drawing.Point(116, 244)
        Me.txtNomIngrediente.Name = "txtNomIngrediente"
        Me.txtNomIngrediente.Size = New System.Drawing.Size(229, 20)
        Me.txtNomIngrediente.TabIndex = 29
        '
        'txtNomProducto
        '
        Me.txtNomProducto.Enabled = False
        Me.txtNomProducto.Location = New System.Drawing.Point(117, 191)
        Me.txtNomProducto.Name = "txtNomProducto"
        Me.txtNomProducto.Size = New System.Drawing.Size(228, 20)
        Me.txtNomProducto.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 267)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Ordenado Por:"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rbproducto)
        Me.Panel3.Controls.Add(Me.rbingrediente)
        Me.Panel3.Controls.Add(Me.rboperador)
        Me.Panel3.Location = New System.Drawing.Point(18, 283)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(327, 46)
        Me.Panel3.TabIndex = 27
        '
        'rbproducto
        '
        Me.rbproducto.AutoSize = True
        Me.rbproducto.Location = New System.Drawing.Point(223, 15)
        Me.rbproducto.Name = "rbproducto"
        Me.rbproducto.Size = New System.Drawing.Size(68, 17)
        Me.rbproducto.TabIndex = 4
        Me.rbproducto.Text = "Producto"
        Me.rbproducto.UseVisualStyleBackColor = True
        '
        'rbingrediente
        '
        Me.rbingrediente.AutoSize = True
        Me.rbingrediente.Location = New System.Drawing.Point(115, 15)
        Me.rbingrediente.Name = "rbingrediente"
        Me.rbingrediente.Size = New System.Drawing.Size(78, 17)
        Me.rbingrediente.TabIndex = 3
        Me.rbingrediente.Text = "Ingrediente"
        Me.rbingrediente.UseVisualStyleBackColor = True
        '
        'rboperador
        '
        Me.rboperador.AutoSize = True
        Me.rboperador.Checked = True
        Me.rboperador.Location = New System.Drawing.Point(9, 15)
        Me.rboperador.Name = "rboperador"
        Me.rboperador.Size = New System.Drawing.Size(69, 17)
        Me.rboperador.TabIndex = 1
        Me.rboperador.TabStop = True
        Me.rboperador.Text = "Operador"
        Me.rboperador.UseVisualStyleBackColor = True
        '
        'btnproducto
        '
        Me.btnproducto.Enabled = False
        Me.btnproducto.Location = New System.Drawing.Point(223, 164)
        Me.btnproducto.Name = "btnproducto"
        Me.btnproducto.Size = New System.Drawing.Size(25, 23)
        Me.btnproducto.TabIndex = 25
        Me.btnproducto.Text = "..."
        Me.btnproducto.UseVisualStyleBackColor = True
        '
        'btningrediente
        '
        Me.btningrediente.Enabled = False
        Me.btningrediente.Location = New System.Drawing.Point(223, 217)
        Me.btningrediente.Name = "btningrediente"
        Me.btningrediente.Size = New System.Drawing.Size(25, 23)
        Me.btningrediente.TabIndex = 24
        Me.btningrediente.Text = "..."
        Me.btningrediente.UseVisualStyleBackColor = True
        '
        'btnoperador
        '
        Me.btnoperador.Enabled = False
        Me.btnoperador.Location = New System.Drawing.Point(223, 127)
        Me.btnoperador.Name = "btnoperador"
        Me.btnoperador.Size = New System.Drawing.Size(25, 23)
        Me.btnoperador.TabIndex = 23
        Me.btnoperador.Text = "..."
        Me.btnoperador.UseVisualStyleBackColor = True
        '
        'txtproducto
        '
        Me.txtproducto.Enabled = False
        Me.txtproducto.Location = New System.Drawing.Point(117, 166)
        Me.txtproducto.Name = "txtproducto"
        Me.txtproducto.Size = New System.Drawing.Size(100, 20)
        Me.txtproducto.TabIndex = 20
        '
        'txtingrediente
        '
        Me.txtingrediente.Enabled = False
        Me.txtingrediente.Location = New System.Drawing.Point(117, 219)
        Me.txtingrediente.Name = "txtingrediente"
        Me.txtingrediente.Size = New System.Drawing.Size(100, 20)
        Me.txtingrediente.TabIndex = 19
        '
        'txtoperador
        '
        Me.txtoperador.Enabled = False
        Me.txtoperador.Location = New System.Drawing.Point(117, 131)
        Me.txtoperador.Name = "txtoperador"
        Me.txtoperador.Size = New System.Drawing.Size(100, 20)
        Me.txtoperador.TabIndex = 18
        '
        'cbproducto
        '
        Me.cbproducto.AutoSize = True
        Me.cbproducto.Location = New System.Drawing.Point(18, 168)
        Me.cbproducto.Name = "cbproducto"
        Me.cbproducto.Size = New System.Drawing.Size(88, 17)
        Me.cbproducto.TabIndex = 15
        Me.cbproducto.Text = "Por Producto"
        Me.cbproducto.UseVisualStyleBackColor = True
        '
        'cbingrediente
        '
        Me.cbingrediente.AutoSize = True
        Me.cbingrediente.Location = New System.Drawing.Point(18, 221)
        Me.cbingrediente.Name = "cbingrediente"
        Me.cbingrediente.Size = New System.Drawing.Size(98, 17)
        Me.cbingrediente.TabIndex = 14
        Me.cbingrediente.Text = "Por Ingrediente"
        Me.cbingrediente.UseVisualStyleBackColor = True
        '
        'cboperador
        '
        Me.cboperador.AutoSize = True
        Me.cboperador.Location = New System.Drawing.Point(18, 131)
        Me.cboperador.Name = "cboperador"
        Me.cboperador.Size = New System.Drawing.Size(89, 17)
        Me.cboperador.TabIndex = 13
        Me.cboperador.Text = "Por Operador"
        Me.cboperador.UseVisualStyleBackColor = True
        '
        'cbfechas
        '
        Me.cbfechas.AutoSize = True
        Me.cbfechas.Location = New System.Drawing.Point(18, 61)
        Me.cbfechas.Name = "cbfechas"
        Me.cbfechas.Size = New System.Drawing.Size(80, 17)
        Me.cbfechas.TabIndex = 11
        Me.cbfechas.Text = "Por Fechas"
        Me.cbfechas.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.dtpfedesde)
        Me.Panel2.Controls.Add(Me.dtpfehasta)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(18, 84)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(327, 31)
        Me.Panel2.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(179, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Hasta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Desde"
        '
        'dtpfedesde
        '
        Me.dtpfedesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfedesde.Location = New System.Drawing.Point(51, 3)
        Me.dtpfedesde.Name = "dtpfedesde"
        Me.dtpfedesde.Size = New System.Drawing.Size(87, 20)
        Me.dtpfedesde.TabIndex = 0
        '
        'dtpfehasta
        '
        Me.dtpfehasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfehasta.Location = New System.Drawing.Point(220, 3)
        Me.dtpfehasta.Name = "dtpfehasta"
        Me.dtpfehasta.Size = New System.Drawing.Size(87, 20)
        Me.dtpfehasta.TabIndex = 2
        '
        'Salir
        '
        Me.Salir.Image = Global.HORMIGONERA.My.Resources.Resources.cerrar_chiquito
        Me.Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Salir.Location = New System.Drawing.Point(284, 362)
        Me.Salir.Name = "Salir"
        Me.Salir.Size = New System.Drawing.Size(92, 37)
        Me.Salir.TabIndex = 13
        Me.Salir.Text = "Salir"
        Me.Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Salir.UseVisualStyleBackColor = True
        '
        'Reporte
        '
        Me.Reporte.Image = Global.HORMIGONERA.My.Resources.Resources.book_go
        Me.Reporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Reporte.Location = New System.Drawing.Point(169, 362)
        Me.Reporte.Name = "Reporte"
        Me.Reporte.Size = New System.Drawing.Size(92, 37)
        Me.Reporte.TabIndex = 12
        Me.Reporte.Text = "Reporte"
        Me.Reporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Reporte.UseVisualStyleBackColor = True
        '
        'frmReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 410)
        Me.Controls.Add(Me.Salir)
        Me.Controls.Add(Me.Reporte)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReportes"
        Me.Text = "Reportes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Salir As System.Windows.Forms.Button
    Friend WithEvents Reporte As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rbproducto As System.Windows.Forms.RadioButton
    Friend WithEvents rbingrediente As System.Windows.Forms.RadioButton
    Friend WithEvents rboperador As System.Windows.Forms.RadioButton
    Friend WithEvents btnproducto As System.Windows.Forms.Button
    Friend WithEvents btningrediente As System.Windows.Forms.Button
    Friend WithEvents btnoperador As System.Windows.Forms.Button
    Friend WithEvents txtproducto As System.Windows.Forms.TextBox
    Friend WithEvents txtingrediente As System.Windows.Forms.TextBox
    Friend WithEvents txtoperador As System.Windows.Forms.TextBox
    Friend WithEvents cbproducto As System.Windows.Forms.CheckBox
    Friend WithEvents cbingrediente As System.Windows.Forms.CheckBox
    Friend WithEvents cboperador As System.Windows.Forms.CheckBox
    Friend WithEvents cbfechas As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpfedesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpfehasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNomIngrediente As System.Windows.Forms.TextBox
    Friend WithEvents txtNomProducto As System.Windows.Forms.TextBox
    Friend WithEvents btnOrdenDespacho As Button
    Friend WithEvents txtOrdenDespacho As TextBox
    Friend WithEvents cbOrdenDespacho As CheckBox
    Friend WithEvents Btt_PrintOD As Button
End Class
