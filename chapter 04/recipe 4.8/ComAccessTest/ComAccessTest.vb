
Imports ComAccessLib

Module ComAccessTest
    Sub Main()
        Dim obj As CppComWrapper _
            = New CppComWrapper()
        Dim result As String _
            = obj.ProcessString("abc123")
        Console.WriteLine( _
            "Result from COM call: {0}", result)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub
End Module
