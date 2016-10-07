Imports System.Runtime.InteropServices
Imports System.Text

Module CharacterSetTest

    Public Class CharacterSetWrapper
        <DllImport("FlatAPILib.DLL", _
            ExactSpelling:=False)> _
        Public Shared Sub CombineStrings( _
            ByVal stringA As String, _
            ByVal stringB As String, _
            ByVal result As StringBuilder)
        End Sub

        <DllImport("FlatAPILib.DLL")> _
        Public Shared Sub CombineAnsiStrings( _
            ByVal stringA As String, _
            ByVal stringB As String, _
            ByVal result As StringBuilder)
        End Sub

        <DllImport("FlatAPILib.DLL", CharSet:=CharSet.Unicode, _
            ExactSpelling:=False)> _
        Public Shared Sub CombineUnicodeStrings( _
            ByVal stringA As String, _
            ByVal stringB As String, _
            ByVal result As StringBuilder)
        End Sub
    End Class

    Public Class CharacterSetAnsiWrapper
        <DllImport("FlatAPILib.DLL", CharSet:=CharSet.Ansi, _
            CallingConvention:=CallingConvention.Cdecl, _
            ExactSpelling:=False)> _
        Public Shared Sub CombineStrings( _
            ByVal stringA As String, _
            ByVal stringB As String, _
            ByVal result As StringBuilder)
        End Sub
    End Class

    Public Class CharacterSetUnicodeWrapper
        <DllImport("FlatAPILib.DLL", CharSet:=CharSet.Unicode, _
            CallingConvention:=CallingConvention.Cdecl, _
            ExactSpelling:=False)> _
        Public Shared Sub CombineStrings( _
            ByVal stringA As String, _
            ByVal stringB As String, _
            ByVal result As StringBuilder)
        End Sub
    End Class

    Sub Main()

        Dim result As StringBuilder _
            = New StringBuilder(300)

        CharacterSetWrapper.CombineStrings( _
            "part1", "part2", result)
        Console.WriteLine( _
            "Result from CombineStrings function Default = " _
            + result.ToString())

        CharacterSetAnsiWrapper.CombineStrings( _
            "part1", "part2", result)
        Console.WriteLine( _
            "Result from CombineStrings function ANSI = " _
            + result.ToString())

        CharacterSetUnicodeWrapper.CombineStrings( _
            "part1", "part2", result)
        Console.WriteLine( _
            "Result from CombineStrings function Unicode = " _
            + result.ToString())

        CharacterSetWrapper.CombineAnsiStrings( _
            "part1", "part2", result)
        Console.WriteLine( _
            "Result from CombineAnsiStrings function = " _
            + result.ToString())

        CharacterSetWrapper.CombineUnicodeStrings( _
            "part1", "part2", result)
        Console.WriteLine( _
            "Result from CombineUnicodeStrings function = " _
            + result.ToString())

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
