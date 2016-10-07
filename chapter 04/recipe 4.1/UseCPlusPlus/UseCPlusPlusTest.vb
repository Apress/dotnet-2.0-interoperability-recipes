Module UseCPlusPlusTest

    Sub Main()
        'create the managed wrapper
        Using obj As New MClassLib.Managed()
            'call the managed method
            Dim result As Integer
            result = obj.AddTheNumbers(1, 2)
            Console.WriteLine( _
                "AddTheNumbers result: {0}", result)
        End Using

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
