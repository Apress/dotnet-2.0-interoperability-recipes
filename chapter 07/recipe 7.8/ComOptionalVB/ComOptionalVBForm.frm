VERSION 5.00
Begin VB.Form ComOptionalVBForm 
   Caption         =   "Form1"
   ClientHeight    =   4500
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5160
   LinkTopic       =   "Form1"
   ScaleHeight     =   4500
   ScaleWidth      =   5160
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   3735
      Left            =   120
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   240
      Width           =   4455
   End
End
Attribute VB_Name = "ComOptionalVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Call TestVBOptional
    Call TestCSharpOptional
End Sub

Private Sub TestVBOptional()
    'use the VB.NET COM object
    Dim comObj As DniNetOptionalVB.IOptional
    Set comObj = New DniNetOptionalVB.DniNetOptionalVBOb
    
    'try the method with and without optional parameters
    Dim result As Integer
    result = comObj.AddOptionalNumbers(100)
    Text1.Text = Text1.Text + _
        "One param: " + CStr(result) + vbCrLf
    
    result = comObj.AddOptionalNumbers(100, 1000)
    Text1.Text = Text1.Text + _
        "Two params: " + CStr(result) + vbCrLf
    
    result = comObj.AddOptionalNumbers(100, 1000, 5000)
    Text1.Text = Text1.Text + _
        "Three params: " + CStr(result) + vbCrLf
        
    Set comObj = Nothing
End Sub

Private Sub TestCSharpOptional()
    'use the C# COM object
    Dim comObj As DniNetOptional.IOptional
    Set comObj = New DniNetOptional.DniNetOptionalObj
        
    'try the method with and without optional parameters
    Dim result As Integer
    result = comObj.AddOptionalNumbers(100)
    Text1.Text = Text1.Text + _
        "One param: " + CStr(result) + vbCrLf
    
    result = comObj.AddOptionalNumbers(100, 1000)
    Text1.Text = Text1.Text + _
        "Two params: " + CStr(result) + vbCrLf
    
    result = comObj.AddOptionalNumbers(100, 1000, 5000)
    Text1.Text = Text1.Text + _
        "Three params: " + CStr(result) + vbCrLf

    Set comObj = Nothing
End Sub
