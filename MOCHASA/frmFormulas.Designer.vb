<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFormulas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnenviar1 = New System.Windows.Forms.Button()
        Me.btnenviar2 = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbproductos = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_Estado = New System.Windows.Forms.TextBox()
        Me.Btt_Env_ReempFormulas = New System.Windows.Forms.Button()
        Me.Btt_Env_AgregFormulas = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Btt_GuardarFormula = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txttotalM3 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(548, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 18)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Formulas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(190, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 15
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 71)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(611, 223)
        Me.DataGridView1.TabIndex = 20
        '
        'btnenviar1
        '
        Me.btnenviar1.Location = New System.Drawing.Point(26, 218)
        Me.btnenviar1.Name = "btnenviar1"
        Me.btnenviar1.Size = New System.Drawing.Size(137, 44)
        Me.btnenviar1.TabIndex = 24
        Me.btnenviar1.Text = "Añadir fórmulas (Anteriores se mantienen)"
        Me.btnenviar1.UseVisualStyleBackColor = True
        Me.btnenviar1.Visible = False
        '
        'btnenviar2
        '
        Me.btnenviar2.Location = New System.Drawing.Point(169, 218)
        Me.btnenviar2.Name = "btnenviar2"
        Me.btnenviar2.Size = New System.Drawing.Size(129, 44)
        Me.btnenviar2.TabIndex = 25
        Me.btnenviar2.Text = "Reemplazar Formulas (Borra las Anteriores)"
        Me.btnenviar2.UseVisualStyleBackColor = True
        Me.btnenviar2.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Producto"
        '
        'cmbproductos
        '
        Me.cmbproductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbproductos.FormattingEnabled = True
        Me.cmbproductos.Location = New System.Drawing.Point(91, 44)
        Me.cmbproductos.Name = "cmbproductos"
        Me.cmbproductos.Size = New System.Drawing.Size(390, 21)
        Me.cmbproductos.TabIndex = 27
        '
        'Button1
        '
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(521, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 44)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Fin Comunicación"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(538, 300)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(77, 23)
        Me.Button2.TabIndex = 29
        Me.Button2.Text = "Sumar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(347, 302)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Total:"
        '
        'txttotal
        '
        Me.txttotal.Location = New System.Drawing.Point(405, 300)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.Size = New System.Drawing.Size(95, 20)
        Me.txttotal.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 393)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Mensajes del Sistema:"
        '
        'Txt_Estado
        '
        Me.Txt_Estado.Location = New System.Drawing.Point(18, 409)
        Me.Txt_Estado.Multiline = True
        Me.Txt_Estado.Name = "Txt_Estado"
        Me.Txt_Estado.ReadOnly = True
        Me.Txt_Estado.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.Txt_Estado.Size = New System.Drawing.Size(610, 118)
        Me.Txt_Estado.TabIndex = 34
        '
        'Btt_Env_ReempFormulas
        '
        Me.Btt_Env_ReempFormulas.Image = Global.HORMIGONERA.My.Resources.Resources.application_form_delete
        Me.Btt_Env_ReempFormulas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Env_ReempFormulas.Location = New System.Drawing.Point(201, 168)
        Me.Btt_Env_ReempFormulas.Name = "Btt_Env_ReempFormulas"
        Me.Btt_Env_ReempFormulas.Size = New System.Drawing.Size(169, 44)
        Me.Btt_Env_ReempFormulas.TabIndex = 33
        Me.Btt_Env_ReempFormulas.Text = "Reemplazar Formulas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Borra las Anteriores)"
        Me.Btt_Env_ReempFormulas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Env_ReempFormulas.UseVisualStyleBackColor = True
        Me.Btt_Env_ReempFormulas.Visible = False
        '
        'Btt_Env_AgregFormulas
        '
        Me.Btt_Env_AgregFormulas.Image = Global.HORMIGONERA.My.Resources.Resources.application_form_add
        Me.Btt_Env_AgregFormulas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Env_AgregFormulas.Location = New System.Drawing.Point(26, 168)
        Me.Btt_Env_AgregFormulas.Name = "Btt_Env_AgregFormulas"
        Me.Btt_Env_AgregFormulas.Size = New System.Drawing.Size(169, 44)
        Me.Btt_Env_AgregFormulas.TabIndex = 32
        Me.Btt_Env_AgregFormulas.Text = "Añadir fórmulas " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Anteriores se mantienen)"
        Me.Btt_Env_AgregFormulas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Env_AgregFormulas.UseVisualStyleBackColor = True
        Me.Btt_Env_AgregFormulas.Visible = False
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.HORMIGONERA.My.Resources.Resources.cancel
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsalir.Location = New System.Drawing.Point(548, 342)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(79, 44)
        Me.btnsalir.TabIndex = 23
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.HORMIGONERA.My.Resources.Resources.application_put
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.Location = New System.Drawing.Point(180, 342)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(144, 44)
        Me.btnGuardar.TabIndex = 22
        Me.btnGuardar.Text = "Guardar Ingredientes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "en tolvas "
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.UseVisualStyleBackColor = True
        Me.btnGuardar.Visible = False
        '
        'Btt_GuardarFormula
        '
        Me.Btt_GuardarFormula.Image = Global.HORMIGONERA.My.Resources.Resources.application_put
        Me.Btt_GuardarFormula.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_GuardarFormula.Location = New System.Drawing.Point(16, 342)
        Me.Btt_GuardarFormula.Name = "Btt_GuardarFormula"
        Me.Btt_GuardarFormula.Size = New System.Drawing.Size(144, 44)
        Me.Btt_GuardarFormula.TabIndex = 36
        Me.Btt_GuardarFormula.Text = "Guardar Fórmula"
        Me.Btt_GuardarFormula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_GuardarFormula.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(506, 303)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "kg"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(506, 329)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "m3"
        '
        'txttotalM3
        '
        Me.txttotalM3.Location = New System.Drawing.Point(405, 326)
        Me.txttotalM3.Name = "txttotalM3"
        Me.txttotalM3.Size = New System.Drawing.Size(95, 20)
        Me.txttotalM3.TabIndex = 38
        '
        'frmFormulas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 539)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txttotalM3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Btt_GuardarFormula)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txt_Estado)
        Me.Controls.Add(Me.Btt_Env_ReempFormulas)
        Me.Controls.Add(Me.Btt_Env_AgregFormulas)
        Me.Controls.Add(Me.txttotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmbproductos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnenviar2)
        Me.Controls.Add(Me.btnenviar1)
        Me.Controls.Add(Me.btnsalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmFormulas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formulas"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnenviar1 As System.Windows.Forms.Button
    Friend WithEvents btnenviar2 As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbproductos As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Btt_Env_AgregFormulas As Button
    Friend WithEvents Btt_Env_ReempFormulas As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Txt_Estado As TextBox
    Friend WithEvents Btt_GuardarFormula As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txttotalM3 As TextBox
End Class
