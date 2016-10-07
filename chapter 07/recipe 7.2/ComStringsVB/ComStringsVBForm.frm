VERSION 5.00
Begin VB.Form ComStringsVBForm 
   Caption         =   "Form1"
   ClientHeight    =   4770
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6090
   LinkTopic       =   "Form1"
   ScaleHeight     =   4770
   ScaleWidth      =   6090
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   3975
      Left            =   240
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   360
      Width           =   5415
   End
End
Attribute VB_Name = "ComStringsVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Dim comObj As _
        New DniNetStrings.DniNetStringsObj

    Dim resultString As String
    
    'returning a BSTR
    resultString = comObj.ReturnBSTR("one", "two")
    Text1.Text = Text1.Text + _
        "ReturnBSTR: " + resultString + vbCrLf
    
    'update an in/out BSTR
    resultString = "unchanged"
    Call comObj.InOutBSTR("one", "two", resultString)
    Text1.Text = Text1.Text + _
        "InOutBSTR: " + resultString + vbCrLf
    
    'receive an out BSTR
    resultString = "unchanged"
    Call comObj.OutBSTR("one", "two", resultString)
    Text1.Text = Text1.Text + _
        "OutBSTR: " + resultString + vbCrLf
    
    'marshaled as a StringBuilder.
    'the resultString must have an initial size that is
    'large enough to hold the new string
    resultString = "unchanged"
    Call comObj.InOutBuilder("one", "two", resultString)
    Text1.Text = Text1.Text + _
        "InOutBuilder: " + resultString + vbCrLf

    'free the COM reference
    Set comObj = Nothing
End Sub




