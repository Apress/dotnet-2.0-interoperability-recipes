VERSION 5.00
Begin VB.Form SimpleNumberClientDualVb6Main 
   Caption         =   "Form1"
   ClientHeight    =   3090
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3090
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   2655
      Left            =   120
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   120
      Width           =   4215
   End
End
Attribute VB_Name = "SimpleNumberClientDualVb6Main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    'create an instance of the managed object via COM
    'using early binding.
    Dim comObj As _
        New DniNetSimpleNumbersDual.DniNetSimpleNumbersDual
    
    'call the method and show the results
    Dim result As Integer
    result = comObj.AddSomeNumbers(1, 2)
    Text1.Text = "Result via early binding is " + CStr(result)
   
    'free the COM reference
    Set comObj = Nothing
End Sub
