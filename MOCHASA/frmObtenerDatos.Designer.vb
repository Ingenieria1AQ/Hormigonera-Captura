<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmObtenerDatos
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
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.btnobtener = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.leerproductos = New System.Windows.Forms.Button()
        Me.leeroperadores = New System.Windows.Forms.Button()
        Me.leeringredientes = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Btt_BorrarTransacc = New System.Windows.Forms.Button()
        Me.Btt_LeerOperadores = New System.Windows.Forms.Button()
        Me.Btt_LeerProductos = New System.Windows.Forms.Button()
        Me.Btt_LeerTransacc = New System.Windows.Forms.Button()
        Me.Btt_LeerFormulas = New System.Windows.Forms.Button()
        Me.Btt_LeerIngredientes = New System.Windows.Forms.Button()
        Me.Salir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.DiscardNull = True
        Me.SerialPort1.ReadBufferSize = 32000
        '
        'btnobtener
        '
        Me.btnobtener.Location = New System.Drawing.Point(252, 153)
        Me.btnobtener.Name = "btnobtener"
        Me.btnobtener.Size = New System.Drawing.Size(100, 37)
        Me.btnobtener.TabIndex = 0
        Me.btnobtener.Text = "Leer transacciones"
        Me.btnobtener.UseVisualStyleBackColor = True
        Me.btnobtener.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(620, 277)
        Me.TextBox1.TabIndex = 15
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(252, 217)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(100, 37)
        Me.Button11.TabIndex = 117
        Me.Button11.Text = "Borrar transacciones"
        Me.Button11.UseVisualStyleBackColor = True
        Me.Button11.Visible = False
        '
        'leerproductos
        '
        Me.leerproductos.Location = New System.Drawing.Point(132, 153)
        Me.leerproductos.Name = "leerproductos"
        Me.leerproductos.Size = New System.Drawing.Size(100, 37)
        Me.leerproductos.TabIndex = 118
        Me.leerproductos.Text = "Leer Productos"
        Me.leerproductos.UseVisualStyleBackColor = True
        Me.leerproductos.Visible = False
        '
        'leeroperadores
        '
        Me.leeroperadores.Location = New System.Drawing.Point(132, 217)
        Me.leeroperadores.Name = "leeroperadores"
        Me.leeroperadores.Size = New System.Drawing.Size(100, 37)
        Me.leeroperadores.TabIndex = 120
        Me.leeroperadores.Text = "Leer Operadores"
        Me.leeroperadores.UseVisualStyleBackColor = True
        Me.leeroperadores.Visible = False
        '
        'leeringredientes
        '
        Me.leeringredientes.Location = New System.Drawing.Point(23, 153)
        Me.leeringredientes.Name = "leeringredientes"
        Me.leeringredientes.Size = New System.Drawing.Size(100, 37)
        Me.leeringredientes.TabIndex = 119
        Me.leeringredientes.Text = "Leer ingredientes"
        Me.leeringredientes.UseVisualStyleBackColor = True
        Me.leeringredientes.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(23, 217)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 37)
        Me.Button1.TabIndex = 121
        Me.Button1.Text = "Leer fórmulas"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(447, 295)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(79, 37)
        Me.Button2.TabIndex = 122
        Me.Button2.Text = "Imprime"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Btt_BorrarTransacc
        '
        Me.Btt_BorrarTransacc.Image = Global.HORMIGONERA.My.Resources.Resources.report_delete
        Me.Btt_BorrarTransacc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_BorrarTransacc.Location = New System.Drawing.Point(287, 338)
        Me.Btt_BorrarTransacc.Name = "Btt_BorrarTransacc"
        Me.Btt_BorrarTransacc.Size = New System.Drawing.Size(144, 37)
        Me.Btt_BorrarTransacc.TabIndex = 126
        Me.Btt_BorrarTransacc.Text = "Borrar transacciones"
        Me.Btt_BorrarTransacc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_BorrarTransacc.UseVisualStyleBackColor = True
        '
        'Btt_LeerOperadores
        '
        Me.Btt_LeerOperadores.Image = Global.HORMIGONERA.My.Resources.Resources.group
        Me.Btt_LeerOperadores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_LeerOperadores.Location = New System.Drawing.Point(148, 338)
        Me.Btt_LeerOperadores.Name = "Btt_LeerOperadores"
        Me.Btt_LeerOperadores.Size = New System.Drawing.Size(121, 37)
        Me.Btt_LeerOperadores.TabIndex = 128
        Me.Btt_LeerOperadores.Text = "Leer Operadores"
        Me.Btt_LeerOperadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_LeerOperadores.UseVisualStyleBackColor = True
        '
        'Btt_LeerProductos
        '
        Me.Btt_LeerProductos.Image = Global.HORMIGONERA.My.Resources.Resources.box_closed
        Me.Btt_LeerProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_LeerProductos.Location = New System.Drawing.Point(148, 295)
        Me.Btt_LeerProductos.Name = "Btt_LeerProductos"
        Me.Btt_LeerProductos.Size = New System.Drawing.Size(121, 37)
        Me.Btt_LeerProductos.TabIndex = 127
        Me.Btt_LeerProductos.Text = "Leer Productos"
        Me.Btt_LeerProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_LeerProductos.UseVisualStyleBackColor = True
        '
        'Btt_LeerTransacc
        '
        Me.Btt_LeerTransacc.Image = Global.HORMIGONERA.My.Resources.Resources.report_magnify
        Me.Btt_LeerTransacc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_LeerTransacc.Location = New System.Drawing.Point(287, 295)
        Me.Btt_LeerTransacc.Name = "Btt_LeerTransacc"
        Me.Btt_LeerTransacc.Size = New System.Drawing.Size(144, 37)
        Me.Btt_LeerTransacc.TabIndex = 125
        Me.Btt_LeerTransacc.Text = "Leer transacciones"
        Me.Btt_LeerTransacc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_LeerTransacc.UseVisualStyleBackColor = True
        '
        'Btt_LeerFormulas
        '
        Me.Btt_LeerFormulas.Image = Global.HORMIGONERA.My.Resources.Resources.form
        Me.Btt_LeerFormulas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_LeerFormulas.Location = New System.Drawing.Point(12, 338)
        Me.Btt_LeerFormulas.Name = "Btt_LeerFormulas"
        Me.Btt_LeerFormulas.Size = New System.Drawing.Size(127, 37)
        Me.Btt_LeerFormulas.TabIndex = 124
        Me.Btt_LeerFormulas.Text = "Leer fórmulas"
        Me.Btt_LeerFormulas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_LeerFormulas.UseVisualStyleBackColor = True
        '
        'Btt_LeerIngredientes
        '
        Me.Btt_LeerIngredientes.Image = Global.HORMIGONERA.My.Resources.Resources.application_view_columns
        Me.Btt_LeerIngredientes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btt_LeerIngredientes.Location = New System.Drawing.Point(12, 295)
        Me.Btt_LeerIngredientes.Name = "Btt_LeerIngredientes"
        Me.Btt_LeerIngredientes.Size = New System.Drawing.Size(127, 37)
        Me.Btt_LeerIngredientes.TabIndex = 123
        Me.Btt_LeerIngredientes.Text = "Leer ingredientes"
        Me.Btt_LeerIngredientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btt_LeerIngredientes.UseVisualStyleBackColor = True
        '
        'Salir
        '
        Me.Salir.Image = Global.HORMIGONERA.My.Resources.Resources.cancel
        Me.Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Salir.Location = New System.Drawing.Point(535, 295)
        Me.Salir.Name = "Salir"
        Me.Salir.Size = New System.Drawing.Size(92, 43)
        Me.Salir.TabIndex = 14
        Me.Salir.Text = "Salir"
        Me.Salir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Salir.UseVisualStyleBackColor = True
        '
        'frmObtenerDatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 390)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnobtener)
        Me.Controls.Add(Me.Btt_LeerOperadores)
        Me.Controls.Add(Me.Btt_LeerProductos)
        Me.Controls.Add(Me.Btt_BorrarTransacc)
        Me.Controls.Add(Me.Btt_LeerTransacc)
        Me.Controls.Add(Me.Btt_LeerFormulas)
        Me.Controls.Add(Me.Btt_LeerIngredientes)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.leeroperadores)
        Me.Controls.Add(Me.leeringredientes)
        Me.Controls.Add(Me.leerproductos)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Salir)
        Me.Name = "frmObtenerDatos"
        Me.Text = "Obtener Datos de GSE"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents btnobtener As System.Windows.Forms.Button
    Friend WithEvents Salir As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents leerproductos As System.Windows.Forms.Button
    Friend WithEvents leeroperadores As System.Windows.Forms.Button
    Friend WithEvents leeringredientes As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Btt_LeerIngredientes As Button
    Friend WithEvents Btt_LeerFormulas As Button
    Friend WithEvents Btt_LeerOperadores As Button
    Friend WithEvents Btt_LeerProductos As Button
    Friend WithEvents Btt_BorrarTransacc As Button
    Friend WithEvents Btt_LeerTransacc As Button
End Class
