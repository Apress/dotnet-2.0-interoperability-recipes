Imports System.EnterpriseServices
Imports System.Transactions
Imports System.Runtime.InteropServices

Public Interface ITranMonitor
    Sub LogTransactionDetails()
End Interface

<Transaction(TransactionOption.Required)> _
<ClassInterface(ClassInterfaceType.None)> _
Public Class DniScMonitorObj
    Inherits ServicedComponent
    Implements ITranMonitor

    Public Sub LogTransactionDetails() _
        Implements ITranMonitor.LogTransactionDetails

        'create the logging class
        Dim logger As TransactionLogging.TransactionLogger _
           = New TransactionLogging.TransactionLogger(Me)

    End Sub
End Class
