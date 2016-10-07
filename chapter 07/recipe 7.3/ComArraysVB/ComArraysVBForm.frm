VERSION 5.00
Begin VB.Form ComArraysVBForm 
   Caption         =   "Form1"
   ClientHeight    =   8220
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   5490
   LinkTopic       =   "Form1"
   ScaleHeight     =   8220
   ScaleWidth      =   5490
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   7335
      Left            =   240
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   240
      Width           =   4815
   End
End
Attribute VB_Name = "ComArraysVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub Form_Load()
    Dim comObj As _
        New DniNetArrays.DniNetArraysObj

    Dim arrayObj As Variant
    'return an integer array
    arrayObj = comObj.ReturnIntArray
    Text1.Text = Text1.Text + _
        "ReturnIntArray results: " + vbCrLf
    DisplayArray (arrayObj)
    
    'pass an integer array
    Dim longArray(4) As Long
    longArray(0) = 0
    longArray(1) = 1
    longArray(2) = 2
    longArray(3) = 3
    longArray(4) = 4
    Dim result As Integer
    result = comObj.SumIntArray(longArray)
    Text1.Text = Text1.Text + _
        "SumIntArray results: " + CStr(result) + vbCrLf

    'attempts an update to integer array
    result = comObj.UpdateIntArrayInOnly(longArray)
    Text1.Text = Text1.Text + _
        "UpdateIntArrayInOnly results: " _
        + CStr(result) + vbCrLf
    DisplayArray (longArray)

    'update an integer array
    result = comObj.UpdateIntArray(longArray)
    Text1.Text = Text1.Text + _
        "UpdateIntArray results: " _
        + CStr(result) + vbCrLf
    DisplayArray (longArray)

    'pass a string array
    Dim stringArray(2) As String
    stringArray(0) = "one"
    stringArray(1) = "two"
    stringArray(2) = "three"
    result = comObj.SumStringArray(stringArray)
    Text1.Text = Text1.Text + _
        "SumStringArray results: " + CStr(result) + vbCrLf
    
    'attempt to update a string array. even though
    'we are passing the array byref, we shouldn't see
    'any changes since the method has the [In] attribute
    result = comObj.UpdateStringArrayInOnly(stringArray)
    Text1.Text = Text1.Text + _
        "UpdateStringArrayInOnly results: " _
        + CStr(result) + vbCrLf
    DisplayArray (stringArray)
    
    'update a string array
    result = comObj.UpdateStringArray(stringArray)
    Text1.Text = Text1.Text + _
        "UpdateStringArray results: " + CStr(result) + vbCrLf
    DisplayArray (stringArray)
    
    'free the COM reference
    Set comObj = Nothing
End Sub

Private Sub DisplayArray(arrayObj As Variant)
    Dim i As Integer
    For i = LBound(arrayObj) To UBound(arrayObj)
        Text1.Text = Text1.Text + _
            "Array Element: " + CStr(arrayObj(i)) + vbCrLf
    Next i
End Sub




