VERSION 5.00
Begin VB.Form ComPreserveSigVBForm 
   Caption         =   "Form1"
   ClientHeight    =   4365
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6060
   LinkTopic       =   "Form1"
   ScaleHeight     =   4365
   ScaleWidth      =   6060
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   3615
      Left            =   360
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   360
      Width           =   5175
   End
End
Attribute VB_Name = "ComPreserveSigVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit


Private Sub Form_Load()
    Dim comObj As _
        DniNetPreserveSig.IPreserveSig
    Set comObj = New DniNetPreserveSig.DniNetPreserveSigObj

    On Error Resume Next
    Err.Clear
    
    Dim resultString As String
    
    Call comObj.CopyString("", resultString)
    Text1.Text = Text1.Text + _
        "CopyString with empty string: " + _
        Hex(Err.Number) + Err.Description + vbCrLf
    
    Err.Clear
    Call comObj.CopyString("test", resultString)
    Text1.Text = Text1.Text + _
        "CopyString with string: " + _
        Hex(Err.Number) + Err.Description + vbCrLf
    
'    Dim HResult As Integer

    Err.Clear
    Call comObj.CopyStringPreserve("", resultString)
    Text1.Text = Text1.Text + _
        "CopyStringPreserve with empty string: " + _
        Hex(Err.Number) + Err.Description + vbCrLf

    Err.Clear
    Call comObj.CopyStringPreserve("test", resultString)
    Text1.Text = Text1.Text + _
        "CopyStringPreserve with string: " + _
        Hex(Err.Number) + Err.Description + vbCrLf

End Sub
