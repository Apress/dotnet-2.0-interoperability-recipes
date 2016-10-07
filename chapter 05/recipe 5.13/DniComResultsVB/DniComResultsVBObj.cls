VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DniComResultsVBObj"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public Function ProvideDifferentResults( _
        ByVal resultType As Long)
    If resultType = 1 Then
        'pass back user-defined HRESULT
        Err.Raise vbObjectError + 514
    Else
        'use a standard Overflow HRESULT
        Err.Raise 6
    End If
End Function

