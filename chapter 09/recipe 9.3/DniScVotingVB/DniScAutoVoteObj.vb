Imports System.Runtime.InteropServices
Imports System.EnterpriseServices

<Transaction(TransactionOption.Required)> _
<ClassInterface(ClassInterfaceType.None)> _
Public Class DniScAutoVoteObj
    Inherits ServicedComponent
    Implements ITranMethods

    <AutoComplete()> _
    Public Sub PerformWork(ByVal request As RequestedResult) _
            Implements ITranMethods.PerformWork
        'log the transaction
        Dim log As TransactionLogging.TransactionLogger _
            = New TransactionLogging.TransactionLogger(Me)

        'determine what kind of result was requested
        Select Case request
            Case RequestedResult.VoteToAbort
                ContextUtil.MyTransactionVote _
                    = TransactionVote.Abort
            Case RequestedResult.ThrowException
                Throw New ApplicationException( _
                    "Transaction should be aborted")
        End Select
    End Sub
End Class
