Imports Interop.DniSimpleComVB

Module UsingInteropAssemblyTest

    Sub Main()
        'use a VB6 COM component
        Dim vbComObj As DniSimpleComVBObj = New DniSimpleComVBObj()
        Dim result As Integer = vbComObj.AddSomeNumbers(1, 2)
        Console.WriteLine("Call VB6 Com Object: {0}", result)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
