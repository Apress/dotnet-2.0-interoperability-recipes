Imports System
Imports System.Runtime.InteropServices

Module StructureStringsTest

    'partial structure definition
    <StructLayout(LayoutKind.Explicit)> _
    Public Structure AccountBalanceStruct
        <FieldOffset(0)> Public AccountId As Integer
        <FieldOffset(36)> Public AccountName As String
        <FieldOffset(40)> Public Address1 As String
        <FieldOffset(44)> Public Address2 As String
        <FieldOffset(48)> Public City As String
        <FieldOffset(52)> Public State As String
        <FieldOffset(56)> Public PostalCode As Integer
    End Structure

    'partial structure definition
    <StructLayout(LayoutKind.Explicit)> _
    Public Structure AccountBalanceStructRaw
        <FieldOffset(0)> Public AccountId As Integer
        <FieldOffset(36)> Public AccountName As IntPtr
        <FieldOffset(40)> Public Address1 As IntPtr
        <FieldOffset(44)> Public Address2 As IntPtr
        <FieldOffset(48)> Public City As IntPtr
        <FieldOffset(52)> Public State As IntPtr
        <FieldOffset(56)> Public PostalCode As Integer
    End Structure

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Sub RetrieveAccountProfile( _
        ByVal accountId As Integer, _
        ByRef account As AccountBalanceStruct)
    End Sub

    <DllImport("FlatAPIStructLib.DLL", _
        EntryPoint:="RetrieveAccountProfile")> _
    Public Sub RetrieveAccountProfileRaw( _
        ByVal accountId As Integer, _
        ByRef account As AccountBalanceStructRaw)
    End Sub

    Sub Main()
        'create the struct
        Dim account As AccountBalanceStruct _
            = New AccountBalanceStruct()
        'make the unmanaged function call, marshaling
        'the strings as System.String
        RetrieveAccountProfile(1001, account)

        'show the results
        Console.WriteLine( _
            "RetrieveAccountProfile results: " _
            + "{0},{1},{2},{3},{4},{5}", _
            account.AccountId, account.AccountName, _
            account.Address1, account.Address2, _
            account.State, account.PostalCode)


        'raw version where we do the marshaling and freeing. 
        'Should provide the same results as above where 
        'we let pinvoke do the work                
        Dim accountRaw As AccountBalanceStructRaw _
            = New AccountBalanceStructRaw()
        'make the unmanaged function call
        RetrieveAccountProfileRaw(1001, accountRaw)
        'marshal the pointers to strings
        Dim accountName As String _
            = Marshal.PtrToStringAnsi(accountRaw.AccountName)
        Dim address1 As String _
            = Marshal.PtrToStringAnsi(accountRaw.Address1)
        Dim address2 As String _
            = Marshal.PtrToStringAnsi(accountRaw.Address2)
        Dim city As String _
            = Marshal.PtrToStringAnsi(accountRaw.City)
        Dim state As String _
        = Marshal.PtrToStringAnsi(accountRaw.State)
        'free the memory
        Marshal.FreeCoTaskMem(accountRaw.AccountName)
        Marshal.FreeCoTaskMem(accountRaw.Address1)
        Marshal.FreeCoTaskMem(accountRaw.Address2)
        Marshal.FreeCoTaskMem(accountRaw.City)
        Marshal.FreeCoTaskMem(accountRaw.State)

        'show the results
        Console.WriteLine( _
            "RetrieveAccountProfileRaw results: " _
            + "{0},{1},{2},{3},{4},{5}", _
            account.AccountId, accountName, _
            address1, address2, _
            state, account.PostalCode)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
