Imports System.Transactions
Imports DniScTranScopeVB.TransactionLogging

Public Interface ILocalScope
    Sub UseLocalScope(ByVal succeed As Boolean)
End Interface

Public Class DniScTranScopeObj
    Implements ILocalScope

    Public Sub UseLocalScope(ByVal succeed As Boolean) _
            Implements ILocalScope.UseLocalScope

        'start the transaction scope
        Using scope As TransactionScope _
            = New TransactionScope()

            'log the transaction
            Dim log As TransactionLogger _
                = New TransactionLogger(Me)

            '
            'update a database or other 
            'resource manager here
            '

            If succeed Then
                scope.Complete()
            End If
        End Using

    End Sub
End Class
