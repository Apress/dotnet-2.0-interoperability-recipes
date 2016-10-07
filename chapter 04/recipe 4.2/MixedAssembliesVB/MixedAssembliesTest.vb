Option Explicit On

Module MixedAssembliesTest

    Sub Main()

        Dim obj As MixedSharedLib.MixedNumber
        obj = New MixedSharedLib.MixedNumber()
        Dim result As Integer _
            = obj.AddTheNumbers(111, 222)
        Console.WriteLine("MixedNumber result: {0}", _
            result)

        Dim helperObj As MixedSharedLib.MixedWithHelper
        helperObj = New MixedSharedLib.MixedWithHelper()
        Dim length As Integer _
            = helperObj.GetLongestStringLength("aaa", "BBBB", "cc")
        Console.WriteLine("Longest String Length {0}", _
            length)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
