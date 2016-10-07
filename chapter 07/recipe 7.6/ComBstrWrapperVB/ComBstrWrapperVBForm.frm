VERSION 5.00
Begin VB.Form ComBstrWrapperVBForm 
   Caption         =   "Form1"
   ClientHeight    =   4920
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6015
   LinkTopic       =   "Form1"
   ScaleHeight     =   4920
   ScaleWidth      =   6015
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   4335
      Left            =   240
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   360
      Width           =   5415
   End
End
Attribute VB_Name = "ComBstrWrapperVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    
    Dim comObj As _
        New DniNetBstrWrapper.DniNetBstrWrapperObj
    
    Dim result As Variant
    
    result = comObj.GetString()
    Text1.Text = Text1.Text + _
        " GetString Type Returned: " + TypeName(result) _
        + " ,Value: " + result + _
        vbCrLf
    
    result = comObj.GetNullString()
    Text1.Text = Text1.Text + _
        " GetNullString Type Returned: " + TypeName(result) _
        + " ,Value: " + result + _
        vbCrLf
    
    result = comObj.GetNullStringWithWrapper()
    Text1.Text = Text1.Text + _
        " GetNullStringWithWrapper Type Returned: " _
        + TypeName(result) _
        + " ,Value: " + result + _
        vbCrLf
    
    result = comObj.GetStringWithWrapper()
    Text1.Text = Text1.Text + _
        " GetStringWithWrapper Type Returned: " _
        + TypeName(result) _
        + " ,Value: " + result + _
        vbCrLf
    
    'free the COM reference
    Set comObj = Nothing
End Sub



