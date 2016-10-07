Imports System.Runtime.InteropServices

'defines the public API for an account object
Public Interface IAccount
    Property AccountId() As Integer

    Property AccountName() As String

    Function GetBalance() As _
        <MarshalAs(UnmanagedType.Currency)> Decimal

    <ComVisible(False)> _
    Sub SetBalance(<MarshalAs(UnmanagedType.Currency)> _
        ByVal value As Decimal)
End Interface

'defines an account class
<ComVisible(False)> _
Public Class Account
    Implements IAccount

    Private m_AccountId As Integer
    Private m_AccountName As String
    Private m_Balance As Decimal

    Public Property AccountId() As Integer _
        Implements IAccount.AccountId
        Get
            Return m_AccountId
        End Get
        Set(ByVal value As Integer)
            m_AccountId = value
        End Set
    End Property

    Public Property AccountName() As String _
        Implements IAccount.AccountName
        Get
            Return m_AccountName
        End Get
        Set(ByVal value As String)
            m_AccountName = value
        End Set
    End Property

    Public Function GetBalance() As Decimal _
        Implements IAccount.GetBalance
        Return m_Balance
    End Function

    Public Sub SetBalance(ByVal value As Decimal) _
        Implements IAccount.SetBalance
        m_Balance = value
    End Sub

End Class

'define an interface for account services
Public Interface IAccountLookup
    Function RetrieveAccount(ByVal acctId As Integer) _
        As IAccount
    Sub UpdateBalance(ByRef account As IAccount)
End Interface

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetClassesObj
    Implements IAccountLookup

    Public Function RetrieveAccount(ByVal acctId As Integer) _
        As IAccount Implements IAccountLookup.RetrieveAccount
        Dim result As Account = Nothing
        If acctId = 123 Then
            result = New Account()
            result.AccountId = acctId
            result.AccountName = "myAccount"
            result.SetBalance(1009.95D)
        End If
        Return result
    End Function

    Public Sub UpdateBalance(ByRef account As IAccount) _
        Implements IAccountLookup.UpdateBalance
        If Not account Is Nothing Then
            account.SetBalance(account.GetBalance() + 500D)
        End If
    End Sub
End Class

