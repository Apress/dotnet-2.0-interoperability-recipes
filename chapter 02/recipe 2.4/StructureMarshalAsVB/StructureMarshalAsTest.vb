Imports System
Imports System.Runtime.InteropServices

Module StructureMarshalAsTest

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure ManagedAmbiguousStruct
        <MarshalAs(UnmanagedType.LPStr)> _
        Public AnsiString As String
        <MarshalAs(UnmanagedType.LPWStr)> _
        Public WideString As String
        <MarshalAs(UnmanagedType.Bool)> _
        Public Win32Boolean As Boolean
        <MarshalAs(UnmanagedType.I1)> _
        Public CStyleBoolean As Boolean
        Public ShortInteger As UShort
    End Structure

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Function UseAmbiguousStruct( _
        ByVal aStruct As ManagedAmbiguousStruct) _
        As Integer
    End Function

    Sub Main()
        Dim mStruct As ManagedAmbiguousStruct _
            = New ManagedAmbiguousStruct()
        mStruct.AnsiString = "ansistring"
        mStruct.WideString = "widestring"
        mStruct.CStyleBoolean = True
        mStruct.Win32Boolean = True
        mStruct.ShortInteger = 5

        Dim result As Integer = UseAmbiguousStruct(mStruct)

        'show the results
        Console.WriteLine( _
            "UseAmbiguousStruct results: {0}", result)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
