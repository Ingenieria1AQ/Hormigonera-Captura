<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ConfigEmpresa
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txt_RUC = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Btt_Salir = New System.Windows.Forms.Button()
        Me.Btt_Guardar = New System.Windows.Forms.Button()
        Me.Btt_Examinar = New System.Windows.Forms.Button()
        Me.Txt_NombreEmpresa = New System.Windows.Forms.TextBox()
        Me.Txt_Ruta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PBox_LogoInicio = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PBox_LogoInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Txt_RUC)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PBox_LogoInicio)
        Me.GroupBox1.Controls.Add(Me.Btt_Salir)
        Me.GroupBox1.Controls.Add(Me.Btt_Guardar)
        Me.GroupBox1.Controls.Add(Me.Btt_Examinar)
        Me.GroupBox1.Controls.Add(Me.Txt_NombreEmpresa)
        Me.GroupBox1.Controls.Add(Me.Txt_Ruta)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(524, 490)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Txt_RUC
        '
        Me.Txt_RUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_RUC.Location = New System.Drawing.Point(64, 400)
        Me.Txt_RUC.Name = "Txt_RUC"
        Me.Txt_RUC.Size = New System.Drawing.Size(320, 22)
        Me.Txt_RUC.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 403)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "R.U.C:"
        '
        'Btt_Salir
        '
        Me.Btt_Salir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_Salir.Image = Global.HORMIGONERA.My.Resources.Resources._131885___close_door_exit_log_out_logout_user_logout
        Me.Btt_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Salir.Location = New System.Drawing.Point(396, 381)
        Me.Btt_Salir.Name = "Btt_Salir"
        Me.Btt_Salir.Size = New System.Drawing.Size(122, 41)
        Me.Btt_Salir.TabIndex = 7
        Me.Btt_Salir.Text = "Salir"
        Me.Btt_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Salir.UseVisualStyleBackColor = True
        '
        'Btt_Guardar
        '
        Me.Btt_Guardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_Guardar.Image = Global.HORMIGONERA.My.Resources.Resources._131694___save
        Me.Btt_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Guardar.Location = New System.Drawing.Point(396, 334)
        Me.Btt_Guardar.Name = "Btt_Guardar"
        Me.Btt_Guardar.Size = New System.Drawing.Size(122, 41)
        Me.Btt_Guardar.TabIndex = 6
        Me.Btt_Guardar.Text = "Guardar"
        Me.Btt_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Guardar.UseVisualStyleBackColor = True
        '
        'Btt_Examinar
        '
        Me.Btt_Examinar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btt_Examinar.Image = Global.HORMIGONERA.My.Resources.Resources.application_form_magnify
        Me.Btt_Examinar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Examinar.Location = New System.Drawing.Point(396, 226)
        Me.Btt_Examinar.Name = "Btt_Examinar"
        Me.Btt_Examinar.Size = New System.Drawing.Size(122, 41)
        Me.Btt_Examinar.TabIndex = 5
        Me.Btt_Examinar.Text = "Examinar"
        Me.Btt_Examinar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Examinar.UseVisualStyleBackColor = True
        '
        'Txt_NombreEmpresa
        '
        Me.Txt_NombreEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_NombreEmpresa.Location = New System.Drawing.Point(64, 333)
        Me.Txt_NombreEmpresa.Multiline = True
        Me.Txt_NombreEmpresa.Name = "Txt_NombreEmpresa"
        Me.Txt_NombreEmpresa.Size = New System.Drawing.Size(320, 56)
        Me.Txt_NombreEmpresa.TabIndex = 4
        '
        'Txt_Ruta
        '
        Me.Txt_Ruta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Ruta.Location = New System.Drawing.Point(64, 226)
        Me.Txt_Ruta.Multiline = True
        Me.Txt_Ruta.Name = "Txt_Ruta"
        Me.Txt_Ruta.ReadOnly = True
        Me.Txt_Ruta.Size = New System.Drawing.Size(320, 67)
        Me.Txt_Ruta.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 314)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre de la empresa:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 232)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ruta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(204, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Logotipo"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PBox_LogoInicio
        '
        Me.PBox_LogoInicio.Image = Global.HORMIGONERA.My.Resources.Resources.Logo_Concretera1
        Me.PBox_LogoInicio.Location = New System.Drawing.Point(117, 37)
        Me.PBox_LogoInicio.Name = "PBox_LogoInicio"
        Me.PBox_LogoInicio.Size = New System.Drawing.Size(243, 180)
        Me.PBox_LogoInicio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBox_LogoInicio.TabIndex = 8
        Me.PBox_LogoInicio.TabStop = False
        '
        'ConfigEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 514)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ConfigEmpresa"
        Me.Text = ".:. Datos Empresa .:."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PBox_LogoInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PBox_LogoInicio As PictureBox
    Friend WithEvents Btt_Salir As Button
    Friend WithEvents Btt_Guardar As Button
    Friend WithEvents Btt_Examinar As Button
    Friend WithEvents Txt_NombreEmpresa As TextBox
    Friend WithEvents Txt_Ruta As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Txt_RUC As TextBox
    Friend WithEvents Label4 As Label
End Class
