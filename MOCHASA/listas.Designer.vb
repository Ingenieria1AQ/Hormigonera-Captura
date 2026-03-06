<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class listas
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.Salir = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(2, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(530, 396)
        Me.DataGridView1.TabIndex = 0
        '
        'OFD
        '
        Me.OFD.FileName = "OFD"
        Me.OFD.Filter = """Text files (*.txt)|*.txt|All files (*.*)|*.*"""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(677, 431)
        Me.TabControl1.TabIndex = 140
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Button4)
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Controls.Add(Me.btnSeleccionar)
        Me.TabPage1.Controls.Add(Me.Salir)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(669, 405)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Información"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Location = New System.Drawing.Point(9, 64)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(487, 244)
        Me.Panel1.TabIndex = 140
        Me.Panel1.Visible = False
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Image = Global.HORMIGONERA.My.Resources.Resources._131844___funnel
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(315, 138)
        Me.Button5.Name = "Button5"
        Me.Button5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button5.Size = New System.Drawing.Size(125, 40)
        Me.Button5.TabIndex = 140
        Me.Button5.Text = "Filtrar"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(51, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Texto:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Controls.Add(Me.RadioButton6)
        Me.GroupBox2.Controls.Add(Me.RadioButton4)
        Me.GroupBox2.Location = New System.Drawing.Point(50, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(390, 67)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar producto que contenga el texto en:"
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(255, 31)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(68, 20)
        Me.RadioButton1.TabIndex = 27
        Me.RadioButton1.Text = "RUC"
        Me.RadioButton1.Visible = False
        '
        'RadioButton6
        '
        Me.RadioButton6.Checked = True
        Me.RadioButton6.Location = New System.Drawing.Point(157, 31)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(68, 20)
        Me.RadioButton6.TabIndex = 26
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "Nombre"
        '
        'RadioButton4
        '
        Me.RadioButton4.Location = New System.Drawing.Point(56, 31)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(68, 20)
        Me.RadioButton4.TabIndex = 24
        Me.RadioButton4.Text = "Codigo"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(110, 149)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(181, 20)
        Me.TextBox1.TabIndex = 27
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Image = Global.HORMIGONERA.My.Resources.Resources._131844___funnel
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(538, 65)
        Me.Button4.Name = "Button4"
        Me.Button4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button4.Size = New System.Drawing.Size(125, 40)
        Me.Button4.TabIndex = 139
        Me.Button4.Text = "Filtrar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSeleccionar.Image = Global.HORMIGONERA.My.Resources.Resources._131823___arrow_forward_next_right
        Me.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSeleccionar.Location = New System.Drawing.Point(538, 6)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSeleccionar.Size = New System.Drawing.Size(125, 40)
        Me.btnSeleccionar.TabIndex = 1
        Me.btnSeleccionar.Text = "Seleccionar"
        Me.btnSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'Salir
        '
        Me.Salir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Salir.Image = Global.HORMIGONERA.My.Resources.Resources._131885___close_door_exit_log_out_logout_user_logout
        Me.Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Salir.Location = New System.Drawing.Point(538, 288)
        Me.Salir.Name = "Salir"
        Me.Salir.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Salir.Size = New System.Drawing.Size(125, 40)
        Me.Salir.TabIndex = 6
        Me.Salir.Text = "Salir"
        Me.Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Salir.UseVisualStyleBackColor = True
        '
        'listas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 446)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "listas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione una opción"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Salir As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
   Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents Button4 As System.Windows.Forms.Button
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
   Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As RadioButton
End Class
