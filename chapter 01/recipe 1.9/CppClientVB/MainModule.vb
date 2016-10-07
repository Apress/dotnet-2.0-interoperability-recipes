Imports CppInteropWrappers

Module MainModule

    'use the C++ wrapper from VB.NET
    Sub Main()
        Dim result As Integer = 0
        Dim resultString As String

        'create the C++ wrapper object
        Dim testObj As CppInteropTest = New CppInteropTest

        'test numbers function using PInvoke
        result = testObj.PInvokeAddNumbersTest()
        Console.WriteLine(String.Format( _
            "Result from PInvokeAddNumbersTest is {0}", _
            result))

        'test numbers function using C++ Interop
        result = testObj.CppInteropAddNumbersTest()
        Console.WriteLine(String.Format( _
            "Result from CppInteropAddNumbersTest is {0}", _
            result))

        'test string function using PInvoke
        resultString = testObj.PInvokeStringsTest()
        Console.WriteLine(String.Format( _
            "Result from PInvokeStringsTest is {0}", _
            resultString))

        'test string function using C++ Interop
        resultString = testObj.CppInteropStringsTest()
        Console.WriteLine(String.Format( _
            "Result from CppInteropStringsTest is {0}", _
            resultString))

        'wait for input
        Console.Read()
    End Sub

End Module

