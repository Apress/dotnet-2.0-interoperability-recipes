VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DniComRefactorVBObj"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'search for the account
Public Function SearchForAccount( _
        ByVal searchArg As String) As Long
    If searchArg = "accountKey" Then
        SearchForAccount = 1001
    Else
        SearchForAccount = 0
    End If
End Function

'retrieve the past due amount
Public Function GetPastDueBalance( _
        ByVal acctId As Long) As Currency
    If acctId = 1001 Then
        GetPastDueBalance = 123.45
    Else
        GetPastDueBalance = 0
    End If
End Function

'mark the account as delinquent
Public Function SetAccountDelinquent(ByVal acctId As Long)
    'add code to mark the account as delinquent
End Function

'refactored method combining multiple methods
Public Function CheckAccountDelinquency( _
        ByVal searchArg As String, _
        ByVal limitAmt As Currency) As Boolean
    
    'set default result
    CheckAccountDelinquency = False
    
    'call the other methods locally rather
    'than across the COM boundary
    
    Dim acctId As Long
    Dim pastDueBal As Currency
    
    acctId = SearchForAccount(searchArg)
    If acctId > 0 Then
        pastDueBal = GetPastDueBalance(acctId)
        If pastDueBal > limitAmt Then
            SetAccountDelinquent (acctId)
            CheckAccountDelinquency = True
        End If
    End If
End Function
    
