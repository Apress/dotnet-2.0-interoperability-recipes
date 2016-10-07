VERSION 5.00
Begin VB.Form SimpleNumberClientVb6Main 
   Caption         =   "Form1"
   ClientHeight    =   4230
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   4230
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnTestVBObject 
      Caption         =   "Test VB .NET object"
      Height          =   375
      Left            =   600
      TabIndex        =   1
      Top             =   3120
      Width           =   1815
   End
   Begin VB.TextBox Text1 
      Height          =   2655
      Left            =   120
      MultiLine       =   -1  'True
      TabIndex        =   0
      Text            =   "SimpleNumberClientVb6Main.frx":0000
      Top             =   120
      Width           =   4215
   End
End
Attribute VB_Name = "SimpleNumberClientVb6Main"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()

    'create the .NET object using COM IDispatch
    Dim dispObj As Object
    Set dispObj = CreateObject( _
        "DniNetSimpleNumbers.DniNetSimpleNumbersDisp")
    'call the method and show the results
    Dim result As Integer
    result = dispObj.AddSomeNumbers(1, 2)
    Text1.Text = _
        "AddSomeNumbers result via COM IDispatch: " _
            + CStr(result)
   
    'free the COM reference
    Set dispObj = Nothing
    
End Sub


Private Sub btnTestVBObject_Click()
    'create the .NET object using COM IDispatch
    Dim dispObj As Object
    Set dispObj = CreateObject( _
        "DniNetSimpleNumbersVB.DniNetSimpleNumbersVB")
    'call the method and show the results
    Dim result As Integer
    result = dispObj.AddSomeNumbers(4, 5)
    Text1.Text = _
        "AddSomeNumbers result via VB COM IDispatch: " _
            + CStr(result)
   
    'free the COM reference
    Set dispObj = Nothing

End Sub


