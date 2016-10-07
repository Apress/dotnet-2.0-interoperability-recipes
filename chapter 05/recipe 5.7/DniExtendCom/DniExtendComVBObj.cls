VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DniExtendComVBObj"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'lookup an account id based on a search type
Public Function AccountLookup(ByVal searchArg As String, _
        ByVal searchType As Long) As Long
        
    Dim acctId As Long
    'lookup an account based on the search type
    acctId = 0
    If searchType = 1 Then
        'add name search code here
        acctId = 1001
    ElseIf searchType = 2 Then
        'add taxId search code here
        acctId = 2002
    ElseIf searchType = 3 Then
        'add address search code here
        acctId = 3003
    End If

    AccountLookup = acctId
End Function

'retrieve the current balance for an account
Public Function GetCurrentBalance( _
        ByVal acctId As Long) As Currency
        
    'add code to retrieve a balance here
    If acctId = 1001 Then
        GetCurrentBalance = 5432.11
    ElseIf acctId = 2002 Then
        GetCurrentBalance = 1.01
    ElseIf acctId = 3003 Then
        GetCurrentBalance = 5.95
    End If
End Function

