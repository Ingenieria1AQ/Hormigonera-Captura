<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperadores
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
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Importar = New System.Windows.Forms.Button()
        Me.Enviar = New System.Windows.Forms.Button()
        Me.Salir = New System.Windows.Forms.Button()
        Me.Eliminar = New System.Windows.Forms.Button()
        Me.Guardar = New System.Windows.Forms.Button()
        Me.seleccionar = New System.Windows.Forms.Button()
        Me.Eliminart = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Estado = New System.Windows.Forms.TextBox()
        Me.Btt_EnviarZM = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OFD
        '
        Me.OFD.FileName = "OFD"
        Me.OFD.Filter = """Text files (*.txt)|*.txt|All files (*.*)|*.*"""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(530, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 18)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Operadores"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(17, 51)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(610, 243)
        Me.DataGridView1.TabIndex = 17
        '
        'Importar
        '
        Me.Importar.Image = Global.CM_Construcciones.My.Resources.Resources.table_add
        Me.Importar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Importar.Location = New System.Drawing.Point(224, 309)
        Me.Importar.Name = "Importar"
        Me.Importar.Size = New System.Drawing.Size(87, 36)
        Me.Importar.TabIndex = 23
        Me.Importar.Text = "Importar"
        Me.Importar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Importar.UseVisualStyleBackColor = True
        '
        'Enviar
        '
        Me.Enviar.Image = Global.CM_Construcciones.My.Resources.Resources.table_go
        Me.Enviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Enviar.Location = New System.Drawing.Point(325, 243)
        Me.Enviar.Name = "Enviar"
        Me.Enviar.Size = New System.Drawing.Size(91, 35)
        Me.Enviar.TabIndex = 21
        Me.Enviar.Text = "Enviar a GSE"
        Me.Enviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Enviar.UseVisualStyleBackColor = True
        Me.Enviar.Visible = False
        '
        'Salir
        '
        Me.Salir.Image = Global.CM_Construcciones.My.Resources.Resources.cerrar_chiquito
        Me.Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Salir.Location = New System.Drawing.Point(543, 309)
        Me.Salir.Name = "Salir"
        Me.Salir.Size = New System.Drawing.Size(84, 36)
        Me.Salir.TabIndex = 20
        Me.Salir.Text = "Salir"
        Me.Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Salir.UseVisualStyleBackColor = True
        '
        'Eliminar
        '
        Me.Eliminar.Image = Global.CM_Construcciones.My.Resources.Resources.table_delete
        Me.Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Eliminar.Location = New System.Drawing.Point(17, 309)
        Me.Eliminar.Name = "Eliminar"
        Me.Eliminar.Size = New System.Drawing.Size(96, 36)
        Me.Eliminar.TabIndex = 19
        Me.Eliminar.Text = "Eliminar"
        Me.Eliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Eliminar.UseVisualStyleBackColor = True
        '
        'Guardar
        '
        Me.Guardar.Image = Global.CM_Construcciones.My.Resources.Resources.table_save
        Me.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Guardar.Location = New System.Drawing.Point(422, 309)
        Me.Guardar.Name = "Guardar"
        Me.Guardar.Size = New System.Drawing.Size(113, 36)
        Me.Guardar.TabIndex = 18
        Me.Guardar.Text = "Guardar Cambios"
        Me.Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Guardar.UseVisualStyleBackColor = True
        '
        'seleccionar
        '
        Me.seleccionar.Image = Global.CM_Construcciones.My.Resources.Resources.arrow_left
        Me.seleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.seleccionar.Location = New System.Drawing.Point(17, 310)
        Me.seleccionar.Name = "seleccionar"
        Me.seleccionar.Size = New System.Drawing.Size(96, 36)
        Me.seleccionar.TabIndex = 22
        Me.seleccionar.Text = "Seleccionar"
        Me.seleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.seleccionar.UseVisualStyleBackColor = True
        '
        'Eliminart
        '
        Me.Eliminart.Image = Global.CM_Construcciones.My.Resources.Resources.table_delete
        Me.Eliminart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Eliminart.Location = New System.Drawing.Point(116, 309)
        Me.Eliminart.Name = "Eliminart"
        Me.Eliminart.Size = New System.Drawing.Size(102, 36)
        Me.Eliminart.TabIndex = 26
        Me.Eliminart.Text = "   Eliminar Todos"
        Me.Eliminart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Eliminart.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 355)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Mensajes del Sistema:"
        '
        'Txt_Estado
        '
        Me.Txt_Estado.Location = New System.Drawing.Point(17, 371)
        Me.Txt_Estado.Multiline = True
        Me.Txt_Estado.Name = "Txt_Estado"
        Me.Txt_Estado.Size = New System.Drawing.Size(610, 118)
        Me.Txt_Estado.TabIndex = 31
        '
        'Btt_EnviarZM
        '
        Me.Btt_EnviarZM.Image = Global.CM_Construcciones.My.Resources.Resources.table_go
        Me.Btt_EnviarZM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_EnviarZM.Location = New System.Drawing.Point(317, 309)
        Me.Btt_EnviarZM.Name = "Btt_EnviarZM"
        Me.Btt_EnviarZM.Size = New System.Drawing.Size(99, 35)
        Me.Btt_EnviarZM.TabIndex = 35
        Me.Btt_EnviarZM.Text = "Enviar a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Controlador"
        Me.Btt_EnviarZM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_EnviarZM.UseVisualStyleBackColor = True
        '
        'frmOperadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 502)
        Me.ControlBox = False
        Me.Controls.Add(Me.Btt_EnviarZM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Estado)
        Me.Controls.Add(Me.Eliminart)
        Me.Controls.Add(Me.Importar)
        Me.Controls.Add(Me.Enviar)
        Me.Controls.Add(Me.Salir)
        Me.Controls.Add(Me.Eliminar)
        Me.Controls.Add(Me.Guardar)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.seleccionar)
        Me.Name = "frmOperadores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operadores"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Enviar As System.Windows.Forms.Button
    Friend WithEvents Salir As System.Windows.Forms.Button
    Friend WithEvents Eliminar As System.Windows.Forms.Button
    Friend WithEvents Guardar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents seleccionar As System.Windows.Forms.Button
    Friend WithEvents Importar As System.Windows.Forms.Button
    Friend WithEvents Eliminart As System.Windows.Forms.Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Estado As TextBox
    Friend WithEvents Btt_EnviarZM As Button
End Class
