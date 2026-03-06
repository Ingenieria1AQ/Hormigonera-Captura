<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mixers
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tab1 = New System.Windows.Forms.TabPage()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.btnmodificar = New System.Windows.Forms.Button()
        Me.btnagregar = New System.Windows.Forms.Button()
        Me.tab2 = New System.Windows.Forms.TabPage()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.txtNombreMixer = New System.Windows.Forms.TextBox()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tab1.SuspendLayout()
        Me.tab2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 62
        Me.DataGridView1.Size = New System.Drawing.Size(567, 499)
        Me.DataGridView1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tab1)
        Me.TabControl1.Controls.Add(Me.tab2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(760, 537)
        Me.TabControl1.TabIndex = 1
        '
        'tab1
        '
        Me.tab1.Controls.Add(Me.btnReporte)
        Me.tab1.Controls.Add(Me.btnsalir)
        Me.tab1.Controls.Add(Me.btnmodificar)
        Me.tab1.Controls.Add(Me.btnagregar)
        Me.tab1.Controls.Add(Me.DataGridView1)
        Me.tab1.Location = New System.Drawing.Point(4, 22)
        Me.tab1.Name = "tab1"
        Me.tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.tab1.Size = New System.Drawing.Size(752, 511)
        Me.tab1.TabIndex = 0
        Me.tab1.Text = "Lista"
        Me.tab1.UseVisualStyleBackColor = True
        '
        'btnReporte
        '
        Me.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReporte.Location = New System.Drawing.Point(607, 144)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(125, 40)
        Me.btnReporte.TabIndex = 6
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReporte.UseVisualStyleBackColor = True
        Me.btnReporte.Visible = False
        '
        'btnsalir
        '
        Me.btnsalir.Image = Global.HORMIGONERA.My.Resources.Resources._131885___close_door_exit_log_out_logout_user_logout
        Me.btnsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnsalir.Location = New System.Drawing.Point(607, 341)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(125, 40)
        Me.btnsalir.TabIndex = 3
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Image = Global.HORMIGONERA.My.Resources.Resources._131907___edit_files_page_pen_pencil_text_write
        Me.btnmodificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnmodificar.Location = New System.Drawing.Point(607, 89)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(125, 40)
        Me.btnmodificar.TabIndex = 2
        Me.btnmodificar.Text = "Modificar"
        Me.btnmodificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnagregar
        '
        Me.btnagregar.Image = Global.HORMIGONERA.My.Resources.Resources._131897___file_new
        Me.btnagregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnagregar.Location = New System.Drawing.Point(607, 34)
        Me.btnagregar.Name = "btnagregar"
        Me.btnagregar.Size = New System.Drawing.Size(125, 40)
        Me.btnagregar.TabIndex = 1
        Me.btnagregar.Text = "Crear Nuevo"
        Me.btnagregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnagregar.UseVisualStyleBackColor = True
        '
        'tab2
        '
        Me.tab2.Controls.Add(Me.btnguardar)
        Me.tab2.Controls.Add(Me.txtNombreMixer)
        Me.tab2.Controls.Add(Me.txtPlaca)
        Me.tab2.Controls.Add(Me.txtcodigo)
        Me.tab2.Controls.Add(Me.Label3)
        Me.tab2.Controls.Add(Me.Label2)
        Me.tab2.Controls.Add(Me.Label1)
        Me.tab2.Location = New System.Drawing.Point(4, 22)
        Me.tab2.Name = "tab2"
        Me.tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.tab2.Size = New System.Drawing.Size(752, 511)
        Me.tab2.TabIndex = 1
        Me.tab2.Text = "Detalles"
        Me.tab2.UseVisualStyleBackColor = True
        '
        'btnguardar
        '
        Me.btnguardar.Image = Global.HORMIGONERA.My.Resources.Resources._131694___save
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnguardar.Location = New System.Drawing.Point(583, 80)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(125, 40)
        Me.btnguardar.TabIndex = 8
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'txtNombreMixer
        '
        Me.txtNombreMixer.Location = New System.Drawing.Point(154, 152)
        Me.txtNombreMixer.Name = "txtNombreMixer"
        Me.txtNombreMixer.Size = New System.Drawing.Size(372, 20)
        Me.txtNombreMixer.TabIndex = 5
        '
        'txtPlaca
        '
        Me.txtPlaca.Location = New System.Drawing.Point(154, 115)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(244, 20)
        Me.txtPlaca.TabIndex = 4
        '
        'txtcodigo
        '
        Me.txtcodigo.Enabled = False
        Me.txtcodigo.Location = New System.Drawing.Point(154, 80)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtcodigo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(77, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nombre Mixer:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(77, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Placa:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(77, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Código:"
        '
        'Mixers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(784, 487)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Mixers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tab1.ResumeLayout(False)
        Me.tab2.ResumeLayout(False)
        Me.tab2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tab1 As System.Windows.Forms.TabPage
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnagregar As System.Windows.Forms.Button
    Friend WithEvents tab2 As System.Windows.Forms.TabPage
    Friend WithEvents txtNombreMixer As System.Windows.Forms.TextBox
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
    Friend WithEvents txtcodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnguardar As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btnReporte As System.Windows.Forms.Button
End Class
