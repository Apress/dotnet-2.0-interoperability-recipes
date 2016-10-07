Imports System.Runtime.InteropServices

Module EntryPointTest

    'declare the unmanaged api
    <DllImport("FlatAPILib.DLL", _
        EntryPoint:="FunctionToRename")> _
    Public Function RenamedFunction( _
        ByVal anInt As Integer) As Integer
    End Function

    'first declaration of a function that accepts any type
    <DllImport("FlatAPILib.DLL", _
        EntryPoint:="PolymorphicFunction")> _
    Public Function FunctionWithInteger( _
        ByRef anInt As Integer, _
        ByVal type As Integer) As Integer
    End Function

    'second declaration of a function that accepts any type
    <DllImport("FlatAPILib.DLL", _
        EntryPoint:="PolymorphicFunction")> _
    Public Function FunctionWithChar( _
        ByRef aChar As Char, _
        ByVal type As Integer) As Integer
    End Function

    'first declaration of a function that accepts any type
    <DllImport("FlatAPILib.DLL", _
        EntryPoint:="PolymorphicFunction")> _
    Public Function OverloadedFunction( _
        ByRef anInt As Integer, _
        ByVal type As Integer) As Integer
    End Function

    'second declaration of a function that accepts any type
    <DllImport("FlatAPILib.DLL", _
        EntryPoint:="PolymorphicFunction")> _
    Public Function OverloadedFunction( _
        ByRef aChar As Char, _
        ByVal type As Integer) As Integer
    End Function

    Sub Main()

        Dim result As Integer _
            = EntryPointTest.RenamedFunction(123)
        Console.WriteLine("Result from RenamedFunction = " _
            + result.ToString())

        Dim myIntValue As Integer = 123
        result = EntryPointTest.FunctionWithInteger( _
            myIntValue, 1)
        Console.WriteLine("Result from FunctionWithInteger = " _
            + result.ToString())

        Dim myCharValue As Char = "A"
        result = EntryPointTest.FunctionWithChar( _
            myCharValue, 2)
        Console.WriteLine("Result from FunctionWithChar = " _
            + result.ToString())

        myCharValue = "Z"
        result = EntryPointTest.OverloadedFunction( _
            myCharValue, 2)
        Console.WriteLine("Result from OverloadedFunction = " _
            + result.ToString())

        myIntValue = 456
        result = EntryPointTest.OverloadedFunction( _
            myIntValue, 1)
        Console.WriteLine("Result from OverloadedFunction = " _
            + result.ToString())

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
