VERSION 5.00
Begin VB.Form ScSimpleComponentVBForm 
   Caption         =   "Form1"
   ClientHeight    =   3735
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6360
   LinkTopic       =   "Form1"
   ScaleHeight     =   3735
   ScaleWidth      =   6360
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   3495
      Left            =   240
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   120
      Width           =   5895
   End
End
Attribute VB_Name = "ScSimpleComponentVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Dim comObj As DniScSimpleComponent.IAddNumbers
    Set comObj = CreateObject( _
        "DniScSimpleComponent.DniScSimpleComponentObj")
    
    Dim result As Integer
    result = comObj.AddSomeNumbers(1, 2)
    Text1.Text = Text1.Text + _
        "AddSomeNumbers using COM+ Library: " _
        + CStr(result) _
        + vbCrLf
    
    'free the COM reference
    Set comObj = Nothing
End Sub
