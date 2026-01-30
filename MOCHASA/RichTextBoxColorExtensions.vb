Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.Drawing

Public Module RichTextBoxColorExtensions

    <Extension()>
    Public Sub AppendColoredText(rtb As RichTextBox, text As String, textColor As Color, textFont As Font, Optional isNewLine As Boolean = False)
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

        ' Restaurar
        rtb.SelectionColor = rtb.ForeColor
        rtb.ScrollToCaret()
        rtb.ResumeLayout()
    End Sub

End Module
