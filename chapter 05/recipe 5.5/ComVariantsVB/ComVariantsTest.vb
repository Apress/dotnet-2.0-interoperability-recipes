Imports DniDataTypesLib
Imports System.Runtime.InteropServices

Module ComVariantsTest

    Sub Main()

        'create an instance of the COM object				
        Dim comObj As DniDataTypesObj = New DniDataTypesObj()
        Dim desc As String = String.Empty

        'a variable used to return any VARIANT value
        Dim result As Object = Nothing

        Dim testVariantBool As Boolean = True
        desc = comObj.UseVariant(testVariantBool, result)
        Console.WriteLine("Test Variant Bool: {0}, {1}, {2}", _
            testVariantBool.GetType().Name, _
            result.GetType().Name, desc)

        Dim testVariantInt As Integer = 123
        desc = comObj.UseVariant(testVariantInt, result)
        Console.WriteLine("Test Variant Int: {0}, {1}, {2}", _
            testVariantInt.GetType().Name, _
            result.GetType().Name, desc)

        Dim testVariantLong As Long = 123
        desc = comObj.UseVariant(testVariantLong, result)
        Console.WriteLine("Test Variant Long: {0}, {1}, {2}", _
            testVariantLong.GetType().Name, _
            result.GetType().Name, desc)

        Dim testVariantString As String = "test string"
        desc = comObj.UseVariant(testVariantString, result)
        Console.WriteLine("Test Variant String: {0}, {1}, {2}", _
            testVariantString.GetType().Name, _
            result.GetType().Name, desc)

        Dim testVariantObject As Object = New Object()
        desc = comObj.UseVariant(testVariantObject, result)
        Console.WriteLine("Test Variant Object: {0}, {1}, {2}", _
            testVariantObject.GetType().Name, _
            result.GetType().Name, desc)

        Dim testVariantNull As Object = Nothing
        desc = comObj.UseVariant(testVariantNull, result)
        Dim returnType As String
        If result = Nothing Then
            returnType = "null"
        Else
            returnType = result.GetType().Name
        End If
        Console.WriteLine("Test Variant Null: {0}, {1}, {2}", _
            "null", returnType, desc)

        Dim testVariantDouble As Double = 123.45
        desc = comObj.UseVariant(testVariantDouble, result)
        Console.WriteLine("Test Variant Double: {0}, {1}, {2}", _
            testVariantDouble.GetType().Name, _
            result.GetType().Name, desc)

        Dim testVariantDecimal As Decimal = 123.45D
        desc = comObj.UseVariant(testVariantDecimal, result)
        Console.WriteLine("Test Variant Decimal: {0}, {1}, {2}", _
            testVariantDecimal.GetType().Name, _
            result.GetType().Name, desc)

        Dim testVariantDate As DateTime = New DateTime(2005, 12, 31)
        desc = comObj.UseVariant(testVariantDate, result)
        Console.WriteLine("Test Variant Date: {0}, {1}, {2}", _
            testVariantDate.GetType().Name, _
            result.GetType().Name, desc)

        Dim testVariantCurrency As CurrencyWrapper _
            = New CurrencyWrapper(123.45D)
        desc = comObj.UseVariant(testVariantCurrency, result)
        Console.WriteLine("Test Variant Currency: {0}, {1}, {2}", _
            testVariantCurrency.GetType().Name, _
            result.GetType().Name, desc)

        Dim testVariantIntPtr As IntPtr = IntPtr.Zero
        desc = comObj.UseVariant(testVariantIntPtr, result)
        Console.WriteLine("Test Variant IntPtr: {0}, {1}, {2}", _
            testVariantIntPtr.GetType().Name, _
            result.GetType().Name, desc)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
