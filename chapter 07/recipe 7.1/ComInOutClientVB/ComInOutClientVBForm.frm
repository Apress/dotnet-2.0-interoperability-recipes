VERSION 5.00
Begin VB.Form ComInOutClientVBForm 
   Caption         =   "Form1"
   ClientHeight    =   6900
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   6900
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   6495
      Left            =   240
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   240
      Width           =   4215
   End
End
Attribute VB_Name = "ComInOutClientVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Dim comObj As _
        New DniNetInOut.DniNetInOutObj

    Dim resultLong As Long
    Dim resultString As String
    Dim resultDate As Date
    
    'blittable type: long
    resultLong = 0
    Call comObj.IntInOnly(123, resultLong)
    Text1.Text = Text1.Text + _
        "IntInOnly: " + CStr(resultLong) + vbCrLf
    
    resultLong = 0
    Call comObj.IntInAndOut(123, resultLong)
    Text1.Text = Text1.Text + _
        "IntInAndOut: " + CStr(resultLong) + vbCrLf
    
    resultLong = 0
    Call comObj.IntByRef(123, resultLong)
    Text1.Text = Text1.Text + _
        "IntByRef: " + CStr(resultLong) + vbCrLf
    
    resultLong = 0
    Call comObj.IntByRefInOnly(123, resultLong)
    Text1.Text = Text1.Text + _
        "IntByRefInOnly: " + CStr(resultLong) + vbCrLf
    
    resultLong = 0
    Call comObj.IntOut(123, resultLong)
    Text1.Text = Text1.Text + _
        "IntOut: " + CStr(resultLong) + vbCrLf
    
    'reference type: string
    resultString = "unchanged"
    Call comObj.StringsInOnly("changed", resultString)
    Text1.Text = Text1.Text + _
        "StringsInOnly: " + resultString + vbCrLf
    
    resultString = "unchanged"
    Call comObj.StringsInAndOut("changed", resultString)
    Text1.Text = Text1.Text + _
        "StringsInAndOut: " + resultString + vbCrLf
    
    resultString = "unchanged"
    Call comObj.StringsByRef("changed", resultString)
    Text1.Text = Text1.Text + _
        "StringsByRef: " + resultString + vbCrLf
    
    resultString = "unchanged"
    Call comObj.StringsByRefInOnly("changed", resultString)
    Text1.Text = Text1.Text + _
        "StringsByRefInOnly: " + resultString + vbCrLf
   
    resultString = "unchanged"
    Call comObj.StringsOut("changed", resultString)
    Text1.Text = Text1.Text + _
        "StringsOut: " + resultString + vbCrLf
   
    'value type: date
    resultDate = "2005/01/01"
    Call comObj.DateTimeInOnly("1969/07/20", resultDate)
    Text1.Text = Text1.Text + _
        "DateTimeInOnly: " + CStr(resultDate) + vbCrLf
    
    resultDate = "2005/01/01"
    Call comObj.DateTimeInAndOut("1969/07/20", resultDate)
    Text1.Text = Text1.Text + _
        "DateTimeInAndOut: " + CStr(resultDate) + vbCrLf
    
    resultDate = "2005/01/01"
    Call comObj.DateTimeByRef("1969/07/20", resultDate)
    Text1.Text = Text1.Text + _
        "DateTimeByRef: " + CStr(resultDate) + vbCrLf
    
    resultDate = "2005/01/01"
    Call comObj.DateTimeByRefInOnly("1969/07/20", resultDate)
    Text1.Text = Text1.Text + _
        "DateTimeByRefInOnly: " + CStr(resultDate) + vbCrLf
    
    resultDate = "2005/01/01"
    Call comObj.DateTimeOut("1969/07/20", resultDate)
    Text1.Text = Text1.Text + _
        "DateTimeOut: " + CStr(resultDate) + vbCrLf
   
    'free the COM reference
    Set comObj = Nothing
    
    'test the VB.NET version now
    Call TestVBNET
    
End Sub


'used to test VB.NET version of the COM class
Private Sub TestVBNET()
    Text1.Text = Text1.Text + vbCrLf + _
        "Now testing VB.NET Version" + vbCrLf
    
    Dim comObj As _
        New DniNetInOutVB.DniNetInOutObj

    Dim resultLong As Long
    Dim resultString As String
    Dim resultDate As Date
    
    'blittable type: long
    resultLong = 0
    Call comObj.IntInOnly(123, resultLong)
    Text1.Text = Text1.Text + _
        "IntInOnly: " + CStr(resultLong) + vbCrLf
    
    resultLong = 0
    Call comObj.IntInAndOut(123, resultLong)
    Text1.Text = Text1.Text + _
        "IntInAndOut: " + CStr(resultLong) + vbCrLf
    
    resultLong = 0
    Call comObj.IntByRef(123, resultLong)
    Text1.Text = Text1.Text + _
        "IntByRef: " + CStr(resultLong) + vbCrLf
    
    resultLong = 0
    Call comObj.IntByRefInOnly(123, resultLong)
    Text1.Text = Text1.Text + _
        "IntByRefInOnly: " + CStr(resultLong) + vbCrLf
    
    'reference type: string
    resultString = "unchanged"
    Call comObj.StringsInOnly("changed", resultString)
    Text1.Text = Text1.Text + _
        "StringsInOnly: " + resultString + vbCrLf
    
    resultString = "unchanged"
    Call comObj.StringsInAndOut("changed", resultString)
    Text1.Text = Text1.Text + _
        "StringsInAndOut: " + resultString + vbCrLf
    
    resultString = "unchanged"
    Call comObj.StringsByRef("changed", resultString)
    Text1.Text = Text1.Text + _
        "StringsByRef: " + resultString + vbCrLf
    
    resultString = "unchanged"
    Call comObj.StringsByRefInOnly("changed", resultString)
    Text1.Text = Text1.Text + _
        "StringsByRefInOnly: " + resultString + vbCrLf
   
    'value type: date
    resultDate = "2005/01/01"
    Call comObj.DateTimeInOnly("1969/07/20", resultDate)
    Text1.Text = Text1.Text + _
        "DateTimeInOnly: " + CStr(resultDate) + vbCrLf
    
    resultDate = "2005/01/01"
    Call comObj.DateTimeInAndOut("1969/07/20", resultDate)
    Text1.Text = Text1.Text + _
        "DateTimeInAndOut: " + CStr(resultDate) + vbCrLf
    
    resultDate = "2005/01/01"
    Call comObj.DateTimeByRef("1969/07/20", resultDate)
    Text1.Text = Text1.Text + _
        "DateTimeByRef: " + CStr(resultDate) + vbCrLf
    
    resultDate = "2005/01/01"
    Call comObj.DateTimeByRefInOnly("1969/07/20", resultDate)
    Text1.Text = Text1.Text + _
        "DateTimeByRefInOnly: " + CStr(resultDate) + vbCrLf
    
    'free the COM reference
    Set comObj = Nothing

End Sub
