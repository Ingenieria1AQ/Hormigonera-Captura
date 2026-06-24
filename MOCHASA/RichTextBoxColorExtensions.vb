Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Drawing

Public Module RichTextBoxColorExtensions

    <Extension()>
    Public Sub AppendColoredText(rtb As RichTextBox, text As String, textColor As Color, textFont As Font, Optional isNewLine As Boolean = False)
        Const MAX_LINEAS As Integer = 500

        rtb.SuspendLayout()

        Dim timeStamp As String = $"[{DateTime.Now:HH:mm:ss}] "

        '--- Insertar al inicio ---
        rtb.SelectionStart = 0
        rtb.SelectionLength = 0

        ' 1) Escribir timestamp (SIEMPRE azul)
        rtb.SelectionColor = Color.Blue
        rtb.SelectionFont = textFont
        rtb.SelectedText = timeStamp

        ' 2) Escribir texto con el color recibido
        rtb.SelectionColor = textColor
        rtb.SelectionFont = textFont
        rtb.SelectedText = text

        ' 3) Agregar salto si aplica
        If isNewLine Then
            rtb.SelectedText = Environment.NewLine
        End If

        'Limitar la cantidad de lineas 

        If rtb.Lines.Length > MAX_LINEAS Then
            Dim primeraLineaEliminar As Integer = MAX_LINEAS
            Dim pos As Integer = rtb.GetFirstCharIndexFromLine(primeraLineaEliminar)
            If pos >= 0 Then
                rtb.Select(pos, rtb.TextLength - pos)
                rtb.SelectedText = ""
            End If
        End If

        ' Restaurar
        rtb.SelectionColor = rtb.ForeColor
        'rtb.ScrollToCaret()
        rtb.ResumeLayout()
    End Sub

End Module
