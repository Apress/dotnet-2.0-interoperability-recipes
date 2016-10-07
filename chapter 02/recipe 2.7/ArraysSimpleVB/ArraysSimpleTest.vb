Imports System
Imports System.Runtime.InteropServices

Module ArraysSimpleTest

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Function CountLowerCaseChars( _
        ByVal chars() As Char, _
        ByVal arraySize As Integer) _
        As Integer
    End Function

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Function ChangeLowerCaseChars( _
        <[In](), Out()> ByVal chars() As Char, _
        ByVal arraySize As Integer) _
        As Integer
    End Function

    Sub Main()

        'create and populate an array of characters
        Dim chars(4) As Char
        chars(0) = "A"
        chars(1) = "b"
        chars(2) = "c"
        chars(3) = "D"
        chars(4) = "e"
        Dim lcCharCount As Integer _
            = CountLowerCaseChars(chars, chars.Length)
        Console.WriteLine( _
            "CountLowerCaseChars results: {0}", lcCharCount)

        'update an array of characters
        chars(0) = "A"
        chars(1) = "b"
        chars(2) = "c"
        chars(3) = "D"
        chars(4) = "e"
        lcCharCount = ChangeLowerCaseChars(chars, chars.Length)
        Console.WriteLine( _
            "ChangeLowerCaseChars results: {0},{1},{2},{3},{4}", _
            chars(0), chars(1), chars(2), chars(3), chars(4))

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()


    End Sub

End Module
