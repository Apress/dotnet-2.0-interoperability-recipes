VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DniErrorInfoVBObj"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public Function GenerateError(ByVal inParam As Long)

    Err.Clear
    
    If inParam = 1 Then
        Err.Raise 449   'argument
    ElseIf inParam = 2 Then
        Err.Raise 449, _
        "DniErrorInfoVB.DniErrorInfoVBObj", _
        "Value is x but should be y"
    ElseIf inParam = 3 Then
        Err.Raise &H80040301    'user-defined error
    ElseIf inParam = 4 Then
        Err.Raise &H80040301, _
        "DniErrorInfoVB.DniErrorInfoVBObj", _
        "My Error Message"
    End If

End Function
