Imports DniSimpleComLib 'reference the interop assembly

Module SimpleComClientVBTest
    Sub Main()

        'create an instance of the COM object
        Dim comObj As IDniSimpleComObj = New DniSimpleComObj
        Dim result As Integer = comObj.AddSomeNumbers(1, 2)
        Console.WriteLine("VB Call Com Object: {0}", result)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
