Imports System.Runtime.InteropServices  'needed for DllImport
Module VBClient

    'declare the unmanaged function
    <DllImport("FlatAPILib.dll")> _
    Public Function AddSomeNumbers(ByVal numA As Integer, ByVal numB As Integer) _
        As Integer
    End Function

    Sub Main()
        Dim result As Integer = 0
        'call the unmanaged function
        result = AddSomeNumbers(1, 2)
        'show the results
        Console.WriteLine(String.Format("Result from function is {0}", result))
        Console.Read()
    End Sub

End Module
