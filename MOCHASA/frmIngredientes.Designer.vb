<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngredientes
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Eliminart = New System.Windows.Forms.Button()
        Me.Importar = New System.Windows.Forms.Button()
        Me.Enviar = New System.Windows.Forms.Button()
        Me.Salir = New System.Windows.Forms.Button()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.seleccionar = New System.Windows.Forms.Button()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.Btt_EnviarZM = New System.Windows.Forms.Button()
        Me.Txt_Estado = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(523, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Ingredientes"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 60)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(606, 243)
        Me.DataGridView1.TabIndex = 7
        '
        'Eliminart
        '
        Me.Eliminart.Image = Global.CM_Construcciones.My.Resources.Resources.table_delete
        Me.Eliminart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Eliminart.Location = New System.Drawing.Point(120, 320)
        Me.Eliminart.Name = "Eliminart"
        Me.Eliminart.Size = New System.Drawing.Size(102, 36)
        Me.Eliminart.TabIndex = 25
        Me.Eliminart.Text = "Eliminar Todos"
        Me.Eliminart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Eliminart.UseVisualStyleBackColor = True
        '
        'Importar
        '
        Me.Importar.Image = Global.CM_Construcciones.My.Resources.Resources.table_add
        Me.Importar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Importar.Location = New System.Drawing.Point(228, 320)
        Me.Importar.Name = "Importar"
        Me.Importar.Size = New System.Drawing.Size(79, 36)
        Me.Importar.TabIndex = 24
        Me.Importar.Text = "Importar"
        Me.Importar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Importar.UseVisualStyleBackColor = True
        '
        'Enviar
        '
        Me.Enviar.Image = Global.CM_Construcciones.My.Resources.Resources.table_go
        Me.Enviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Enviar.Location = New System.Drawing.Point(315, 258)
        Me.Enviar.Name = "Enviar"
        Me.Enviar.Size = New System.Drawing.Size(99, 35)
        Me.Enviar.TabIndex = 13
        Me.Enviar.Text = "Enviar a GSE"
        Me.Enviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Enviar.UseVisualStyleBackColor = True
        Me.Enviar.Visible = False
        '
        'Salir
        '
        Me.Salir.Image = Global.CM_Construcciones.My.Resources.Resources.cerrar_chiquito
        Me.Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Salir.Location = New System.Drawing.Point(538, 321)
        Me.Salir.Name = "Salir"
        Me.Salir.Size = New System.Drawing.Size(84, 36)
        Me.Salir.TabIndex = 12
        Me.Salir.Text = "Salir"
        Me.Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Salir.UseVisualStyleBackColor = True
        '
        'Eliminar
        '
        Me.Eliminar.Image = Global.CM_Construcciones.My.Resources.Resources.table_delete
        Me.Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Eliminar.Location = New System.Drawing.Point(16, 320)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(98, 36)
        Me.Eliminar.TabIndex = 9
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'Guardar
        '
        Me.Guardar.Image = Global.CM_Construcciones.My.Resources.Resources.table_save
        Me.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Guardar.Location = New System.Drawing.Point(419, 321)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(113, 36)
        Me.Guardar.TabIndex = 8
        Me.Guardar.Text = "Guardar Cambios"
        Me.Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'seleccionar
        '
        Me.seleccionar.Image = Global.CM_Construcciones.My.Resources.Resources.arrow_left
        Me.seleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.seleccionar.Location = New System.Drawing.Point(16, 320)
        Me.seleccionar.Name = "seleccionar"
        Me.seleccionar.Size = New System.Drawing.Size(98, 36)
        Me.seleccionar.TabIndex = 23
        Me.seleccionar.Text = "Seleccionar"
        Me.seleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.seleccionar.UseVisualStyleBackColor = True
        '
        'OFD
        '
        Me.OFD.FileName = "OFD"
        Me.OFD.Filter = """Text files (*.txt)|*.txt|All files (*.*)|*.*"""
        '
        'Btt_EnviarZM
        '
        Me.Btt_EnviarZM.Image = Global.CM_Construcciones.My.Resources.Resources.table_go
        Me.Btt_EnviarZM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_EnviarZM.Location = New System.Drawing.Point(313, 321)
        Me.Btt_EnviarZM.Name = "Btt_EnviarZM"
        Me.Btt_EnviarZM.Size = New System.Drawing.Size(99, 35)
        Me.Btt_EnviarZM.TabIndex = 26
        Me.Btt_EnviarZM.Text = "Enviar a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Controlador"
        Me.Btt_EnviarZM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_EnviarZM.UseVisualStyleBackColor = True
        Me.Btt_EnviarZM.Visible = False
        '
        'Txt_Estado
        '
        Me.Txt_Estado.Location = New System.Drawing.Point(12, 388)
        Me.Txt_Estado.Multiline = True
        Me.Txt_Estado.Name = "Txt_Estado"
        Me.Txt_Estado.Size = New System.Drawing.Size(610, 118)
        Me.Txt_Estado.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Mensajes del Sistema:"
        '
        'frmIngredientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 519)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Estado)
        Me.Controls.Add(Me.Btt_EnviarZM)
        Me.Controls.Add(Me.Eliminart)
        Me.Controls.Add(Me.Importar)
        Me.Controls.Add(Me.Enviar)
        Me.Controls.Add(Me.Salir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Eliminar)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.seleccionar)
        Me.Name = "frmIngredientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingredientes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Salir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Eliminar As System.Windows.Forms.Button
    Friend WithEvents Guardar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Enviar As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents seleccionar As System.Windows.Forms.Button
    Friend WithEvents Importar As System.Windows.Forms.Button
    Friend WithEvents Eliminart As System.Windows.Forms.Button
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Btt_EnviarZM As Button
    Friend WithEvents Txt_Estado As TextBox
    Friend WithEvents Label2 As Label
End Class
