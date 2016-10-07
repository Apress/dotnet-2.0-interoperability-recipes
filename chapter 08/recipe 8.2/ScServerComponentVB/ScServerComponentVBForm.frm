VERSION 5.00
Begin VB.Form ScServerComponentVBForm 
   Caption         =   "Form1"
   ClientHeight    =   4095
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   5820
   LinkTopic       =   "Form1"
   ScaleHeight     =   4095
   ScaleWidth      =   5820
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   3375
      Left            =   480
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   240
      Width           =   4815
   End
End
Attribute VB_Name = "ScServerComponentVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Dim comObj As DniScServerComponent.IAddNumbers
    Set comObj = CreateObject( _
        "DniScServerComponent.DniScServerComponentObj")
    
    Dim result As Integer
    result = comObj.AddSomeNumbers(1, 2)
    Text1.Text = Text1.Text + _
        "AddSomeNumbers using COM+ Server App: " _
        + CStr(result) _
        + vbCrLf
    
    'free the COM reference
    Set comObj = Nothing
End Sub


