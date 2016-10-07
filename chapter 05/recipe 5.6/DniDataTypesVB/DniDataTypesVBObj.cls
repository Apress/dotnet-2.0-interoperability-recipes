VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DniDataTypesVBObj"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
'use a VB string array
Public Function UseArray(ByRef elements() As String) As String
    Dim result As String
    result = ""
    'add the array elements to the output string
    For i = 0 To UBound(elements)
        result = result + elements(i)
    Next i
    'return the new string
    UseArray = result
End Function




