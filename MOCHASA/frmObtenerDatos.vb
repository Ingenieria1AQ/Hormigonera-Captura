Imports System.Data
Imports System.Data.OleDb

Public Class frmObtenerDatos

    Private Sub frmObtenerDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        leer_tabla = ""
        'Try
        '    SerialPort1.Open()
        'Catch ex As Exception
        '    MessageBox.Show("Error al abrir el puerto 1")
        'End Try
    End Sub

    Private Sub btnobtener_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnobtener.Click
        Try
            leer_tabla = "DATOS"
            'dato = ""
            'Me.Cursor = Cursors.WaitCursor
            Dim i As Int32
            'Open "temporal.txt" For Output As #5
            'SerialPort1.Write(Chr(3) & Chr(2) & Chr(21))
            For i = 1 To retardo
            Next
            ReDim datos(0)
            datos(0) = ""
            'datos(1) = ""
            TextBox1.Text = ""
            SerialPort1.Write("13,1;1.1.1%y%q")

        Catch ex As Exception
            MsgBox("Error: " & Err.Description)
        End Try
    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim cad1 As String
        Dim uno() As String
        'On Error GoTo final
        'Dim a As Char = ""
        Dim a As String
        'a = Convert.ToChar(Chr(SerialPort1.ReadChar))
        'a = e.ToString ' Convert.ToChar(Chr(SerialPort1.ReadChar))
        a = SerialPort1.ReadLine.ToString
        a = a.Replace(Chr(34), "")
        dato = a
        a = Chr(13)
        If a = Nothing Then
            Exit Sub
        End If
        'TextBox1.Text = TextBox1.Text + a + vbCrLf

        ''Text1.Text = Text1.Text + a
        If a = Chr(34) Then a = "" 'Elimino comillas
        'If a = "." Then a = ","
        If a = Chr(13) And dato <> "" Then
            dato = dato.Trim
            'Print #5, Trim(dato)
            'If Trim(dato) = "ENDofDB" Then
            'Close #5
            'MsgBox "Datos Recibidos", , "Confirmación"
            'Label5.Caption = "Datos Recibidos......"
         If dato.Length < 3 Then Exit Sub
         '***1
         If dato.Substring(0, 3) <> "16," Then
            If dato <> "ENDofDB" Then
               If leer_tabla = "DATOS" Then
                  ReDim Preserve datos(datos.Length)
                  datos(datos.Length - 1) = dato
               End If
               TextBox1.Text = TextBox1.Text & dato & vbCrLf
               dato = ""
            Else
               If leer_tabla = "DATOS" Then
                  Dim k As Integer
                  Dim cmd As OleDbCommand
                  Dim oOleDbConnection As New OleDbConnection(sConnString)
                  oOleDbConnection.Open()
                  For k = 0 To datos.Length - 1

                     If datos(k) <> "" Then
                        cad1 = datos(k)
                        uno = cad1.Split(",")
                        If uno.Length = 11 Then
                           cmd = New OleDbCommand("insert into Transacciones values('" & uno(0) & "','" & uno(1) & "','" & uno(2) & "','" & uno(3) & "','" & uno(4) & "','" & uno(5) & "','" & uno(6) & "','" & uno(7) & "','" & uno(8) & "','" & uno(9) & "','" & uno(10) & "')", oOleDbConnection)
                           cmd.ExecuteNonQuery()
                        Else
                           'mostrar y reprocesar esta línea
                        End If
                     End If
                  Next k
                  oOleDbConnection.Close()
                  MessageBox.Show("Proceso Finalizado")
               End If
            End If
         End If
      Else
         If a <> Chr(10) Then
            dato = dato & a
         End If
      End If
   End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

        Dim i As Int32
        'SerialPort1.Write(Chr(3) + Chr(2) + Chr(21))
        If MessageBox.Show("Borrar los datos de transacciones?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            For i = 1 To retardo
            Next
            SerialPort1.Write("10,1%y")
        Else
            MessageBox.Show("Acción cancelada", "Información")
        End If
    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click
        leer_tabla = ""
        Me.Close()
        Try
            SerialPort1.Close()
        Catch ex As Exception

        End Try
    End Sub

    
    Private Sub leerproductos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leerproductos.Click
        Try
            leer_tabla = ""
           
            Dim i As Int32
          
            For i = 1 To retardo
            Next
          
            TextBox1.Text = ""
            SerialPort1.Write("13,4;1.1.1%y%q")

        Catch ex As Exception
            MsgBox("Error: " & Err.Description)
        End Try
    End Sub

    Private Sub leeringredientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leeringredientes.Click
        Try
            leer_tabla = ""
           
            Dim i As Int32
            
            For i = 1 To retardo
            Next
          
            TextBox1.Text = ""
            SerialPort1.Write("13,3;1.1.1%y%q")

        Catch ex As Exception
            MsgBox("Error: " & Err.Description)
        End Try
    End Sub

    Private Sub leeroperadores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leeroperadores.Click
        Try
            leer_tabla = ""
           
            Dim i As Int32
            
            For i = 1 To retardo
            Next
           
            TextBox1.Text = ""
            SerialPort1.Write("13,2;1.1.1%y%q")

        Catch ex As Exception
            MsgBox("Error: " & Err.Description)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            leer_tabla = ""
           
            Dim i As Int32
           
            For i = 1 To retardo
            Next
            
            TextBox1.Text = ""
            SerialPort1.Write("13,5;1.1.1%y%q")

        Catch ex As Exception
            MsgBox("Error: " & Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        MessageBox.Show("Aún no disponible")


    End Sub

    Private Sub Btt_LeerIngredientes_Click(sender As Object, e As EventArgs) Handles Btt_LeerIngredientes.Click
        'Enviar caracter "I" para solicitar al indicador la tabla de Ingredientes
        Funciones.enviaDatosSocket("I" & vbCrLf, Principal.Txt_EstadoCon)
        TextBox1.Clear()
    End Sub

    Private Sub Btt_LeerOperadores_Click(sender As Object, e As EventArgs) Handles Btt_LeerOperadores.Click
        'Enviar caracter "O" para solicitar al indicador la tabla de Operadores
        Funciones.enviaDatosSocket("O" & vbCrLf, Principal.Txt_EstadoCon)
        TextBox1.Clear()
    End Sub

    Private Sub Btt_LeerProductos_Click(sender As Object, e As EventArgs) Handles Btt_LeerProductos.Click
        'Enviar caracter "P" para solicitar al indicador la tabla de Productos
        Funciones.enviaDatosSocket("P" & vbCrLf, Principal.Txt_EstadoCon)
        TextBox1.Clear()
    End Sub

    Private Sub Btt_LeerFormulas_Click(sender As Object, e As EventArgs) Handles Btt_LeerFormulas.Click
        'Enviar caracter "F" para solicitar al indicador la tabla de Formulas
        Funciones.enviaDatosSocket("F" & vbCrLf, Principal.Txt_EstadoCon)
        TextBox1.Clear()
    End Sub

    Private Sub Btt_LeerTransacc_Click(sender As Object, e As EventArgs) Handles Btt_LeerTransacc.Click
        'Enviar caracter "D" para solicitar al indicador la tabla de Datos
        Funciones.enviaDatosSocket("D" & vbCrLf, Principal.Txt_EstadoCon)
        TextBox1.Clear()
    End Sub

    Private Sub Btt_BorrarTransacc_Click(sender As Object, e As EventArgs) Handles Btt_BorrarTransacc.Click
        'Enviar caracter "d" para borrar la tabla de Datos
        Funciones.enviaDatosSocket("d" & vbCrLf, Principal.Txt_EstadoCon)
        TextBox1.Clear()
    End Sub
End Class