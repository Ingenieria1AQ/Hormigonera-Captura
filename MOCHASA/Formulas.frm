VERSION 5.00
Begin VB.Form Form2 
   Caption         =   "Ingreso de Formulas"
   ClientHeight    =   8355
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11970
   LinkTopic       =   "Form2"
   ScaleHeight     =   8355
   ScaleWidth      =   11970
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton Command16 
      BackColor       =   &H0080FF80&
      Caption         =   "FIN COMUNICACION"
      Height          =   735
      Left            =   7560
      Style           =   1  'Graphical
      TabIndex        =   36
      Top             =   4080
      Width           =   1815
   End
   Begin VB.TextBox Text8 
      Height          =   285
      Left            =   5640
      TabIndex        =   35
      Top             =   4200
      Width           =   1455
   End
   Begin VB.CommandButton Command7 
      Caption         =   "Calcular Total"
      Height          =   495
      Left            =   3960
      TabIndex        =   34
      Top             =   4200
      Width           =   1335
   End
   Begin VB.CommandButton Command6 
      BackColor       =   &H008080FF&
      Caption         =   "Añadir fórmulas (Anteriores se mantienen)"
      Height          =   615
      Left            =   8040
      Style           =   1  'Graphical
      TabIndex        =   33
      Top             =   4920
      Width           =   2775
   End
   Begin VB.CommandButton Command5 
      Caption         =   "Guardar Ingredientes de Tolvas"
      Height          =   855
      Left            =   8040
      TabIndex        =   32
      Top             =   2880
      Width           =   2655
   End
   Begin VB.CommandButton Command15 
      Caption         =   "Regresar"
      Height          =   615
      Left            =   8040
      TabIndex        =   31
      Top             =   6360
      Width           =   2775
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Borrar"
      Height          =   975
      Left            =   1080
      TabIndex        =   30
      Top             =   7080
      Width           =   2415
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Actualizar Listas"
      Height          =   855
      Left            =   8040
      TabIndex        =   29
      Top             =   1560
      Width           =   2655
   End
   Begin VB.ComboBox Combo8 
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   405
      Left            =   2040
      TabIndex        =   27
      Top             =   720
      Width           =   6615
   End
   Begin VB.CommandButton Command4 
      Caption         =   "Salir"
      Height          =   855
      Left            =   8040
      TabIndex        =   26
      Top             =   7200
      Width           =   2775
   End
   Begin VB.CommandButton Command8 
      BackColor       =   &H008080FF&
      Caption         =   "Reemplazar Formulas (Borra las Anteriores)"
      Height          =   615
      Left            =   8040
      Style           =   1  'Graphical
      TabIndex        =   25
      Top             =   5640
      Width           =   2775
   End
   Begin VB.ListBox List1 
      Height          =   3180
      Left            =   3720
      TabIndex        =   24
      Top             =   4920
      Width           =   3375
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Aumentar"
      Height          =   855
      Left            =   1080
      TabIndex        =   23
      Top             =   4920
      Width           =   2415
   End
   Begin VB.TextBox Text7 
      Height          =   285
      Left            =   5640
      TabIndex        =   22
      Top             =   3720
      Width           =   1455
   End
   Begin VB.ComboBox Combo7 
      Height          =   315
      Left            =   2040
      TabIndex        =   21
      Top             =   3720
      Width           =   3255
   End
   Begin VB.TextBox Text6 
      Height          =   285
      Left            =   5640
      TabIndex        =   20
      Top             =   3360
      Width           =   1455
   End
   Begin VB.ComboBox Combo6 
      Height          =   315
      Left            =   2040
      TabIndex        =   19
      Top             =   3360
      Width           =   3255
   End
   Begin VB.TextBox Text5 
      Height          =   285
      Left            =   5640
      TabIndex        =   16
      Top             =   3000
      Width           =   1455
   End
   Begin VB.ComboBox Combo5 
      Height          =   315
      Left            =   2040
      TabIndex        =   14
      Top             =   3000
      Width           =   3255
   End
   Begin VB.TextBox Text4 
      Height          =   285
      Left            =   5640
      TabIndex        =   13
      Top             =   2640
      Width           =   1455
   End
   Begin VB.ComboBox Combo4 
      Height          =   315
      Left            =   2040
      TabIndex        =   11
      Top             =   2640
      Width           =   3255
   End
   Begin VB.TextBox Text3 
      Height          =   285
      Left            =   5640
      TabIndex        =   10
      Top             =   2280
      Width           =   1455
   End
   Begin VB.ComboBox Combo3 
      Height          =   315
      Left            =   2040
      TabIndex        =   8
      Top             =   2280
      Width           =   3255
   End
   Begin VB.TextBox Text2 
      Height          =   285
      Left            =   5640
      TabIndex        =   7
      Top             =   1920
      Width           =   1455
   End
   Begin VB.ComboBox Combo2 
      Height          =   315
      Left            =   2040
      TabIndex        =   5
      Top             =   1920
      Width           =   3255
   End
   Begin VB.TextBox Text1 
      Height          =   285
      Left            =   5640
      TabIndex        =   4
      Top             =   1560
      Width           =   1455
   End
   Begin VB.ComboBox Combo1 
      Height          =   315
      Left            =   2040
      TabIndex        =   1
      Top             =   1560
      Width           =   3255
   End
   Begin VB.Label Label11 
      BackColor       =   &H0080FFFF&
      Caption         =   "Presionar cuando ya se vaya a empezar la Dosificación"
      Height          =   495
      Left            =   9480
      TabIndex        =   37
      Top             =   4200
      Width           =   2295
   End
   Begin VB.Line Line1 
      X1              =   7320
      X2              =   5400
      Y1              =   4080
      Y2              =   4080
   End
   Begin VB.Label Label10 
      Caption         =   "PRODUCTO:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   240
      TabIndex        =   28
      Top             =   720
      Width           =   1575
   End
   Begin VB.Label Label9 
      Caption         =   "Liquido 2:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   720
      TabIndex        =   18
      Top             =   3720
      Width           =   1095
   End
   Begin VB.Label Label8 
      Caption         =   "Liquido 1:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   720
      TabIndex        =   17
      Top             =   3360
      Width           =   1095
   End
   Begin VB.Label Label7 
      Caption         =   "Tolva 5:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   960
      TabIndex        =   15
      Top             =   3000
      Width           =   855
   End
   Begin VB.Label Label6 
      Caption         =   "Tolva 4:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   960
      TabIndex        =   12
      Top             =   2640
      Width           =   855
   End
   Begin VB.Label Label5 
      Caption         =   "Tolva 3:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   960
      TabIndex        =   9
      Top             =   2280
      Width           =   855
   End
   Begin VB.Label Label4 
      Caption         =   "Tolva 2:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   960
      TabIndex        =   6
      Top             =   1920
      Width           =   855
   End
   Begin VB.Label Label2 
      Caption         =   "Cantidad:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   5760
      TabIndex        =   3
      Top             =   1200
      Width           =   975
   End
   Begin VB.Label Label1 
      Caption         =   "Tolva 1:"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9.75
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   960
      TabIndex        =   2
      Top             =   1560
      Width           =   855
   End
   Begin VB.Label Label3 
      Alignment       =   2  'Center
      Caption         =   "FORMULAS PARA DOSIFICACION"
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   20.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   1560
      TabIndex        =   0
      Top             =   0
      Width           =   8415
   End
End
Attribute VB_Name = "Form2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
pos = InStr(1, Combo8.Text, ",")
pos1 = InStr(1, Combo1.Text, ",")
linea = Left(Combo8.Text, pos - 1) + "," + Left(Combo1.Text, pos1 - 1) + "," + Text1.Text
List1.AddItem linea
pos1 = InStr(1, Combo2.Text, ",")
linea = Left(Combo8.Text, pos - 1) + "," + Left(Combo2.Text, pos1 - 1) + "," + Text2.Text
List1.AddItem linea
pos1 = InStr(1, Combo3.Text, ",")
linea = Left(Combo8.Text, pos - 1) + "," + Left(Combo3.Text, pos1 - 1) + "," + Text3.Text
List1.AddItem linea
pos1 = InStr(1, Combo4.Text, ",")
linea = Left(Combo8.Text, pos - 1) + "," + Left(Combo4.Text, pos1 - 1) + "," + Text4.Text
List1.AddItem linea
pos1 = InStr(1, Combo5.Text, ",")
linea = Left(Combo8.Text, pos - 1) + "," + Left(Combo5.Text, pos1 - 1) + "," + Text5.Text
List1.AddItem linea
pos1 = InStr(1, Combo6.Text, ",")
linea = Left(Combo8.Text, pos - 1) + "," + Left(Combo6.Text, pos1 - 1) + "," + Text6.Text
List1.AddItem linea
pos1 = InStr(1, Combo7.Text, ",")
linea = Left(Combo8.Text, pos - 1) + "," + Left(Combo7.Text, pos1 - 1) + "," + Text7.Text
List1.AddItem linea
End Sub

Private Sub Command15_Click()
Form2.Visible = False
Form1.Visible = True
End Sub

Private Sub Command16_Click()
Form1.MSComm1.Output = Chr(3)

End Sub

Private Sub Command2_Click()
On Error GoTo final2
Combo1.Clear
Combo2.Clear
Combo3.Clear
Combo4.Clear
Combo5.Clear
Combo6.Clear
Combo7.Clear
Combo8.Clear
ARCHIVO = "PRODUCTOS.TXT"
Open ARCHIVO For Input As #1
  While Not EOF(1)
    Line Input #1, linea
    Combo8.AddItem linea
  Wend
Close #1
ARCHIVO = "ingredientes.TXT"
Open ARCHIVO For Input As #1
  While Not EOF(1)
    Line Input #1, linea
    Combo1.AddItem linea
    Combo2.AddItem linea
    Combo3.AddItem linea
    Combo4.AddItem linea
    Combo5.AddItem linea
    Combo6.AddItem linea
    Combo7.AddItem linea
  Wend
Close #1

ARCHIVO = "ingtolvas.TXT"
Open ARCHIVO For Input As #1
    Line Input #1, linea
    Combo1.Text = linea
    Line Input #1, linea
    Combo2.Text = linea
    Line Input #1, linea
    Combo3.Text = linea
    Line Input #1, linea
    Combo4.Text = linea
    Line Input #1, linea
    Combo5.Text = linea
    Line Input #1, linea
    Combo6.Text = linea
    Line Input #1, linea
    Combo7.Text = linea
Close #1
Exit Sub
final2:

End Sub

Private Sub Command3_Click()
List1.Clear
End Sub

Private Sub Command4_Click()
End
End Sub

Private Sub Command5_Click()
On Error GoTo final5
ARCHIVO = "ingtolvas.TXT"
Open ARCHIVO For Output As #1
    Print #1, Combo1.Text
    Print #1, Combo2.Text
    Print #1, Combo3.Text
    Print #1, Combo4.Text
    Print #1, Combo5.Text
    Print #1, Combo6.Text
    Print #1, Combo7.Text
Close #1
Exit Sub
final5:

End Sub

Private Sub Command6_Click()
Form1.MSComm1.Output = Chr(3) + Chr(2) + Chr(21)
For ii = 1 To 4000000
Next
Form1.MSComm1.Output = "16,5;1%y" + vbCrLf
For i = 0 To List1.ListCount - 1
  linea = List1.List(i) + vbCrLf
  Form1.MSComm1.Output = linea
For ii = 1 To 1000000
Next
  ''MsgBox linea
Next
Form1.MSComm1.Output = "ENDofDB" + vbCrLf + vbCrLf


End Sub

Private Sub Command7_Click()
Text8.Text = Val(Text1.Text) + Val(Text2.Text) + Val(Text3.Text) + Val(Text4.Text) + Val(Text5.Text) + Val(Text6.Text) + Val(Text7.Text)
End Sub

Private Sub Command8_Click()
Form1.MSComm1.Output = Chr(3) + Chr(2) + Chr(21)
For i = 1 To 2000000
Next
Form1.MSComm1.Output = "10,5%y" + vbCrLf
For ii = 1 To 4000000
Next
Form1.MSComm1.Output = "16,5;1%y" + vbCrLf
For i = 0 To List1.ListCount - 1
  linea = List1.List(i) + vbCrLf
  Form1.MSComm1.Output = linea
For ii = 1 To 1000000
Next
  ''MsgBox linea
Next
Form1.MSComm1.Output = "ENDofDB" + vbCrLf + vbCrLf

End Sub

Private Sub Form_Load()
On Error GoTo finalload
ARCHIVO = "ingtolvas.TXT"
Open ARCHIVO For Input As #1
    Line Input #1, linea
    Combo1.Text = linea
    Line Input #1, linea
    Combo2.Text = linea
    Line Input #1, linea
    Combo3.Text = linea
    Line Input #1, linea
    Combo4.Text = linea
    Line Input #1, linea
    Combo5.Text = linea
    Line Input #1, linea
    Combo6.Text = linea
    Line Input #1, linea
    Combo7.Text = linea
Close #1
ARCHIVO = "PRODUCTOS.TXT"
Open ARCHIVO For Input As #1
  While Not EOF(1)
    Line Input #1, linea
    Combo8.AddItem linea
  Wend
Close #1
ARCHIVO = "ingredientes.TXT"
Open ARCHIVO For Input As #1
  While Not EOF(1)
    Line Input #1, linea
    
    Combo1.AddItem linea
    Combo2.AddItem linea
    Combo3.AddItem linea
    Combo4.AddItem linea
    Combo5.AddItem linea
    Combo6.AddItem linea
    Combo7.AddItem linea
  Wend
Close #1

Exit Sub
finalload:
End Sub
