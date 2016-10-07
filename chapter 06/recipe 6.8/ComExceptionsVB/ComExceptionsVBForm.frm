VERSION 5.00
Begin VB.Form ComExceptionsVBForm 
   Caption         =   "Form1"
   ClientHeight    =   4605
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5640
   LinkTopic       =   "Form1"
   ScaleHeight     =   4605
   ScaleWidth      =   5640
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   3975
      Left            =   120
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   240
      Width           =   5055
   End
End
Attribute VB_Name = "ComExceptionsVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit


Private Sub Form_Load()
    Dim comObj As _
        New DniNetExceptions.DniNetExceptionsObj
            
    On Error Resume Next
        
    Call comObj.ThrowStandardException
    Call ShowError
    
    Call comObj.ThrowCustomException
    Call ShowError

    Call comObj.ThrowCustomExceptionWithHResult
    Call ShowError
    
    'execute tests of the VB.NET version
    Call VBNetTest
End Sub

Private Sub ShowError()
    If Err.Number <> 0 Then
        Text1.Text = Text1.Text + _
            Hex(Err.Number) + " " + _
            Err.Description + _
            vbCrLf
    End If
    Err.Clear
End Sub

'execute the same tests using the VB.NET version of the
'component
Private Sub VBNetTest()
    Dim comObj As _
        New DniNetExceptionsVB.DniNetExceptionsObj
            
    On Error Resume Next
        
    Call comObj.ThrowStandardException
    Call ShowError
    
    Call comObj.ThrowCustomException
    Call ShowError

    Call comObj.ThrowCustomExceptionWithHResult
    Call ShowError

End Sub
