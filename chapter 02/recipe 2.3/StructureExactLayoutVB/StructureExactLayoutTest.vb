Imports System
Imports System.Runtime.InteropServices

''' <summary>
''' Passing of structures between managed and unmanaged code
''' </summary>
''' <remarks></remarks>
Module StructureExactLayoutTest

    'partial structure definition
    <StructLayout(LayoutKind.Explicit)> _
    Public Structure AccountBalanceStruct
        <FieldOffset(0)> Public AccountId As Integer
        <FieldOffset(16)> Public CurrentBalance As Double
        <FieldOffset(24)> Public PastDueBalance As Double
        <FieldOffset(60)> Public LastPurchaseAmt As Double
    End Structure

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Sub RetrieveAccountBalances( _
        ByVal accountId As Integer, _
        ByRef account As AccountBalanceStruct)
    End Sub

    Sub Main()
        'uses a partially defined managed structure
        Dim account As AccountBalanceStruct _
            = New AccountBalanceStruct()
        'make the unmanaged function call
        RetrieveAccountBalances(1001, account)
        'show the results
        Console.WriteLine( _
            "RetrieveAccountBalances results: {0}, {1}, {2}, {3}", _
            account.AccountId, account.CurrentBalance, _
            account.PastDueBalance, account.LastPurchaseAmt)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
