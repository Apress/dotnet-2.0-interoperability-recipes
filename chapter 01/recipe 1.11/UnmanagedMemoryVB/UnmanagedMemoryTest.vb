Imports System.Runtime.InteropServices

Module UnmanagedMemoryTest

    <DllImport("FlatAPILib.DLL", CharSet:=CharSet.Unicode)> _
    Public Function ReturnUnmanagedString( _
        ByVal leftString As String, ByVal rightString As String) _
            As IntPtr
    End Function

    <DllImport("FlatAPILib.DLL")> _
    Public Sub FreeUnmanagedString(ByVal stringPtr As IntPtr)
    End Sub

    <DllImport("FlatAPILib.DLL", CharSet:=CharSet.Unicode, _
        EntryPoint:="ReturnUnmanagedString")> _
    Public Function ReturnUnmanagedStringAsString( _
        ByVal leftString As String, ByVal rightString As String) _
            As String
    End Function

    <DllImport("FlatAPILib.DLL", CharSet:=CharSet.Unicode)> _
    Public Function ReturnComAllocatedString( _
        ByVal leftString As String, ByVal rightString As String) _
            As IntPtr
    End Function

    <DllImport("FlatAPILib.DLL", CharSet:=CharSet.Unicode, _
        entryPoint:="ReturnComAllocatedString")> _
    Public Function ReturnComAllocatedStringAsString( _
        ByVal leftString As String, ByVal rightString As String) _
            As String
    End Function

    Sub Main()

        Dim resultString As String = String.Empty
        Dim stringPtr As IntPtr = IntPtr.Zero

        'handle an unmanaged string allocated by the C runtime
        stringPtr = UnmanagedMemoryTest.ReturnUnmanagedString( _
            "left", "right")
        resultString = Marshal.PtrToStringUni(stringPtr)
        FreeUnmanagedString(stringPtr)
        Console.WriteLine( _
            "Result from ReturnUnmanagedString = {0}", _
            resultString)

        'handle an unmanaged string allocated by CoTaskMemAlloc
        stringPtr = UnmanagedMemoryTest.ReturnComAllocatedString( _
            "left", "right")
        resultString = Marshal.PtrToStringUni(stringPtr)
        Marshal.FreeCoTaskMem(stringPtr)
        Console.WriteLine( _
            "Result from ReturnComAllocatedString = {0}", _
            resultString)

        'handle an unmanaged string allocated by CoTaskMemAlloc
        'this time marshaled as a string
        resultString = _
            UnmanagedMemoryTest.ReturnComAllocatedStringAsString( _
            "left", "right")
        Console.WriteLine( _
            "Result from ReturnComAllocatedStringAsString = {0}", _
            resultString)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
