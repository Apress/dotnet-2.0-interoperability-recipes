Module CheckTraitsVBTest

    Sub Main()
        'check the traits of each class
        Console.WriteLine( _
            "IsClass MixedNumber: {0}", _
            MixedSharedLib.TraitChecker.IsClass(1))
        Console.WriteLine( _
            "IsClass CMixedNativeNumber: {0}", _
            MixedSharedLib.TraitChecker.IsClass(2))
        Console.WriteLine( _
            "IsRefClass MixedNumber: {0}", _
            MixedSharedLib.TraitChecker.IsRefClass(1))
        Console.WriteLine( _
            "IsRefClass CMixedNativeNumber: {0}", _
            MixedSharedLib.TraitChecker.IsRefClass(2))

        'determine if the /clr option has been set
        Console.WriteLine( _
            "IsClrOptionSet: {0}", _
            MixedSharedLib.TraitChecker.IsClrOptionSet())

        'call the /clr version of the string length method
        Console.WriteLine("GetStringLength {0}", _
            MixedSharedLib.TraitChecker.GetStringLength("abcdefg"))

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
