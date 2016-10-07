Imports System.IO
Imports System.EnterpriseServices
Imports System.Transactions

Namespace TransactionLogging

    Public Class TransactionLogger
        Private m_TargetName As String = String.Empty

        ''' <summary>
        ''' Constructor
        ''' </summary>
        ''' <param name="target"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal target As Object)
            m_TargetName = target.GetType().Name
            Log("------Starting method call------")
            If Transaction.Current <> Nothing Then
                AddHandler Transaction.Current.TransactionCompleted, _
                    AddressOf tran_TransactionCompleted
            End If
            LogTranDetails(Transaction.Current, _
                "*Transaction at start of method:")

        End Sub

        ''' <summary>
        ''' Log details about a transaction
        ''' </summary>
        ''' <param name="tran"></param>
        ''' <param name="msg"></param>
        ''' <remarks></remarks>
        Public Sub LogTranDetails(ByVal tran As Transaction, _
            ByVal msg As String)
            Log(msg)
            If (tran <> Nothing) Then
                Log(" IsInTransaction: {0}", _
                    ContextUtil.IsInTransaction.ToString())
                If ContextUtil.IsInTransaction Then
                    Log(" MyTransactionVote: {0}", _
                        ContextUtil.MyTransactionVote.ToString())
                End If
                Log(" IsolationLevel: {0}", _
                    tran.IsolationLevel.ToString())

                Dim info As TransactionInformation _
                    = tran.TransactionInformation
                Log(" Tran start time: {0}", _
                    info.CreationTime.ToString("HH:mm:ss.ffff"))
                If info.DistributedIdentifier <> Nothing Then
                    Log(" DistId: {0}", _
                        info.DistributedIdentifier)
                End If
                Log(" TranId: {0}", info.LocalIdentifier)
                Log(" Tran Status: {0}", info.Status)
            Else
                Log("***No current transaction***")
            End If

        End Sub

        ''' <summary>
        ''' Handler for the TransactionCompleted event 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub tran_TransactionCompleted(ByVal sender As Object, _
                ByVal e As TransactionEventArgs)
            If e.Transaction <> Nothing Then
                LogTranDetails(e.Transaction, _
                    "*Transaction at TransactionCompleted:")
            End If
        End Sub

        ''' <summary>
        ''' Log a message
        ''' </summary>
        ''' <param name="msg"></param>
        ''' <remarks></remarks>
        Private Sub Log(ByVal msg As String)
            Dim writer As StreamWriter _
                = New StreamWriter( _
                String.Format("c:\{0}.vblog.txt", m_TargetName), _
                    True)
            writer.WriteLine("{0} {1} {2}", _
                DateTime.Now.ToString("HH:mm:ss.ffff"), _
                m_TargetName, msg)

            writer.Flush()
            writer.Close()
        End Sub

        ''' <summary>
        ''' Log a formatted message
        ''' </summary>
        ''' <param name="msg"></param>
        ''' <param name="arg"></param>
        ''' <remarks></remarks>
        Public Sub Log(ByVal msg As String, ByVal arg As Object)
            Log(String.Format(msg, arg))
        End Sub

    End Class

End Namespace
