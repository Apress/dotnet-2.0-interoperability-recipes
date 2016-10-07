Imports System.Runtime.InteropServices
Imports System.EnterpriseServices
Imports DniScVotingVB.TransactionLogging

<Transaction(TransactionOption.Required)> _
<ClassInterface(ClassInterfaceType.None)> _
Public Class DniScSetManualVoteObj
    Inherits ServicedComponent
    Implements ITranMethods

    Public Sub PerformWork(ByVal request As RequestedResult) _
            Implements ITranMethods.PerformWork
        'log the transaction
        Dim log As TransactionLogger _
            = New TransactionLogger(Me)

        'set the default vote prior to performing any work
        ContextUtil.SetComplete()

        Try
            'determine what kind of result was requested
            Select Case request
                Case RequestedResult.VoteToAbort, _
                     RequestedResult.ThrowException
                    Throw New ApplicationException( _
                        "Transaction should be aborted")
            End Select

            'if we get this far, 
            'the SetComplete vote will stand

        Catch ex As Exception
            ContextUtil.SetAbort()
            Throw ex
        End Try

    End Sub
End Class
