<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConexion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Btt_Cancelar = New System.Windows.Forms.Button()
        Me.staticRemotePort = New System.Windows.Forms.Label()
        Me.staticHostName = New System.Windows.Forms.Label()
        Me.Txt_IpAdd = New System.Windows.Forms.TextBox()
        Me.Txt_Puerto = New System.Windows.Forms.TextBox()
        Me.Btt_Conectar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Btt_Cancelar
        '
        Me.Btt_Cancelar.BackColor = System.Drawing.SystemColors.Control
        Me.Btt_Cancelar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Btt_Cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btt_Cancelar.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_Cancelar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btt_Cancelar.Image = Global.CM_Construcciones.My.Resources.Resources.cancel
        Me.Btt_Cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Cancelar.Location = New System.Drawing.Point(149, 84)
        Me.Btt_Cancelar.Name = "Btt_Cancelar"
        Me.Btt_Cancelar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Btt_Cancelar.Size = New System.Drawing.Size(101, 44)
        Me.Btt_Cancelar.TabIndex = 15
        Me.Btt_Cancelar.Text = "Cancelar"
        Me.Btt_Cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Cancelar.UseVisualStyleBackColor = False
        '
        'staticRemotePort
        '
        Me.staticRemotePort.AutoSize = True
        Me.staticRemotePort.BackColor = System.Drawing.Color.Transparent
        Me.staticRemotePort.Cursor = System.Windows.Forms.Cursors.Default
        Me.staticRemotePort.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.staticRemotePort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.staticRemotePort.Location = New System.Drawing.Point(36, 61)
        Me.staticRemotePort.Name = "staticRemotePort"
        Me.staticRemotePort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.staticRemotePort.Size = New System.Drawing.Size(41, 14)
        Me.staticRemotePort.TabIndex = 12
        Me.staticRemotePort.Text = "&Puerto:"
        '
        'staticHostName
        '
        Me.staticHostName.AutoSize = True
        Me.staticHostName.BackColor = System.Drawing.Color.Transparent
        Me.staticHostName.Cursor = System.Windows.Forms.Cursors.Default
        Me.staticHostName.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.staticHostName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.staticHostName.Location = New System.Drawing.Point(11, 18)
        Me.staticHostName.Name = "staticHostName"
        Me.staticHostName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.staticHostName.Size = New System.Drawing.Size(67, 28)
        Me.staticHostName.TabIndex = 10
        Me.staticHostName.Text = "&Dirección    :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Controlador"
        '
        'Txt_IpAdd
        '
        Me.Txt_IpAdd.Location = New System.Drawing.Point(93, 18)
        Me.Txt_IpAdd.Name = "Txt_IpAdd"
        Me.Txt_IpAdd.Size = New System.Drawing.Size(145, 20)
        Me.Txt_IpAdd.TabIndex = 16
        '
        'Txt_Puerto
        '
        Me.Txt_Puerto.Location = New System.Drawing.Point(93, 55)
        Me.Txt_Puerto.Name = "Txt_Puerto"
        Me.Txt_Puerto.Size = New System.Drawing.Size(145, 20)
        Me.Txt_Puerto.TabIndex = 17
        '
        'Btt_Conectar
        '
        Me.Btt_Conectar.BackColor = System.Drawing.SystemColors.Control
        Me.Btt_Conectar.Cursor = System.Windows.Forms.Cursors.Default
        Me.Btt_Conectar.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_Conectar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Btt_Conectar.Image = Global.CM_Construcciones.My.Resources.Resources.connect
        Me.Btt_Conectar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Conectar.Location = New System.Drawing.Point(26, 87)
        Me.Btt_Conectar.Name = "Btt_Conectar"
        Me.Btt_Conectar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Btt_Conectar.Size = New System.Drawing.Size(94, 41)
        Me.Btt_Conectar.TabIndex = 14
        Me.Btt_Conectar.Text = "Connectar"
        Me.Btt_Conectar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Conectar.UseVisualStyleBackColor = False
        '
        'frmConexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 137)
        Me.ControlBox = False
        Me.Controls.Add(Me.Txt_Puerto)
        Me.Controls.Add(Me.Txt_IpAdd)
        Me.Controls.Add(Me.Btt_Cancelar)
        Me.Controls.Add(Me.Btt_Conectar)
        Me.Controls.Add(Me.staticRemotePort)
        Me.Controls.Add(Me.staticHostName)
        Me.Name = "frmConexion"
        Me.Text = "Conexión"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Btt_Cancelar As Button
    Public WithEvents Btt_Conectar As Button
    Public WithEvents staticRemotePort As Label
    Public WithEvents staticHostName As Label
    Friend WithEvents Txt_IpAdd As TextBox
    Friend WithEvents Txt_Puerto As TextBox
End Class
