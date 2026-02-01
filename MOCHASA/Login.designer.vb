<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Usuario = New System.Windows.Forms.TextBox()
        Me.Txt_Clave = New System.Windows.Forms.TextBox()
        Me.Btt_Salir = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Pcb_Login = New System.Windows.Forms.PictureBox()
        Me.Btt_Acceder = New System.Windows.Forms.Button()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pcb_Login, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Contraseña:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Txt_Usuario
        '
        Me.Txt_Usuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Usuario.Location = New System.Drawing.Point(173, 154)
        Me.Txt_Usuario.Name = "Txt_Usuario"
        Me.Txt_Usuario.Size = New System.Drawing.Size(118, 24)
        Me.Txt_Usuario.TabIndex = 2
        '
        'Txt_Clave
        '
        Me.Txt_Clave.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Clave.Location = New System.Drawing.Point(173, 193)
        Me.Txt_Clave.Name = "Txt_Clave"
        Me.Txt_Clave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Clave.Size = New System.Drawing.Size(118, 24)
        Me.Txt_Clave.TabIndex = 3
        '
        'Btt_Salir
        '
        Me.Btt_Salir.Image = Global.HORMIGONERA.My.Resources.Resources._131885___close_door_exit_log_out_logout_user_logout
        Me.Btt_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Salir.Location = New System.Drawing.Point(206, 243)
        Me.Btt_Salir.Name = "Btt_Salir"
        Me.Btt_Salir.Size = New System.Drawing.Size(99, 42)
        Me.Btt_Salir.TabIndex = 5
        Me.Btt_Salir.Text = "Salir"
        Me.Btt_Salir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Salir.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(38, 189)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 8
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(38, 150)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Pcb_Login
        '
        Me.Pcb_Login.Image = Global.HORMIGONERA.My.Resources.Resources.Logo_Concretera
        Me.Pcb_Login.Location = New System.Drawing.Point(99, 8)
        Me.Pcb_Login.Name = "Pcb_Login"
        Me.Pcb_Login.Size = New System.Drawing.Size(174, 140)
        Me.Pcb_Login.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pcb_Login.TabIndex = 6
        Me.Pcb_Login.TabStop = False
        '
        'Btt_Acceder
        '
        Me.Btt_Acceder.Image = Global.HORMIGONERA.My.Resources.Resources._131823___arrow_forward_next_right
        Me.Btt_Acceder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_Acceder.Location = New System.Drawing.Point(81, 243)
        Me.Btt_Acceder.Name = "Btt_Acceder"
        Me.Btt_Acceder.Size = New System.Drawing.Size(92, 42)
        Me.Btt_Acceder.TabIndex = 4
        Me.Btt_Acceder.Text = "Acceder"
        Me.Btt_Acceder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_Acceder.UseVisualStyleBackColor = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(376, 307)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Pcb_Login)
        Me.Controls.Add(Me.Btt_Salir)
        Me.Controls.Add(Me.Btt_Acceder)
        Me.Controls.Add(Me.Txt_Clave)
        Me.Controls.Add(Me.Txt_Usuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximumSize = New System.Drawing.Size(392, 346)
        Me.MinimumSize = New System.Drawing.Size(392, 346)
        Me.Name = "Login"
        Me.Text = ".:. Login .:."
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pcb_Login, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Usuario As TextBox
    Friend WithEvents Txt_Clave As TextBox
    Friend WithEvents Btt_Acceder As Button
    Friend WithEvents Btt_Salir As Button
    Friend WithEvents Pcb_Login As PictureBox
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
