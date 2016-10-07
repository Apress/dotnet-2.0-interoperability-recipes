Imports DniDataTypesLib

Module ComDataTypesTest

    Sub Main()
        'create an instance of the COM object				
        Dim comObj As DniDataTypesObj _
            = New DniDataTypesObj()

        Dim outUseBool As SByte = 0
        comObj.UseBool(1, outUseBool)
        Console.WriteLine("UseBoolean: {0}, {1}", _
            outUseBool.GetType().Name, outUseBool)

        Dim outUseVariantBool As Boolean = False
        comObj.UseVariantBool(True, outUseVariantBool)
        Console.WriteLine("UseVariantBool: {0}, {1}", _
            outUseVariantBool.GetType().Name, _
            outUseVariantBool)

        Dim outUseLong As Integer = 0
        comObj.UseLong(123, outUseLong)
        Console.WriteLine("UseLong: {0}, {1}", _
            outUseLong.GetType().Name, outUseLong)

        Dim outUseDouble As Double = 0.0
        comObj.UseDouble(45.67, outUseDouble)
        Console.WriteLine("UseDouble: {0}, {1}", _
            outUseDouble.GetType().Name, outUseDouble)

        Dim outUseBSTR As String = "orig string out"
        comObj.UseBSTR("input string", outUseBSTR)
        Console.WriteLine("UseBSTR: {0}, {1}", _
            outUseBSTR.GetType().Name, outUseBSTR)

        Dim outUseLPSTR As String = String.Empty
        comObj.UseLPSTR("input string", outUseLPSTR)
        Console.WriteLine("UseLPSTR: {0}, {1}", _
            outUseLPSTR.GetType().Name, outUseLPSTR)

        Dim outUseDecimal As Decimal = 0
        comObj.UseDecimal(9876.54D, outUseDecimal)
        Console.WriteLine("UseDecimal: {0}, {1}", _
            outUseDecimal.GetType().Name, outUseDecimal)

        Dim outUseCurrency As Decimal = 0
        comObj.UseCurrency(9876.54D, outUseCurrency)
        Console.WriteLine("UseCurrency: {0}, {1}", _
            outUseCurrency.GetType().Name, outUseCurrency)

        Dim outUseDate As DateTime = New DateTime()
        comObj.UseDate(New DateTime(2005, 12, 31), outUseDate)
        Console.WriteLine("UseDate: {0}, {1}", _
            outUseDate.GetType().Name, outUseDate)

        Dim outUseChar As Byte = 0
        comObj.UseChar(CByte(122), outUseChar)
        Console.WriteLine("UseChar: {0}, {1}", _
            outUseChar.GetType().Name, outUseChar)

        Dim outUseComChar As SByte = 0
        comObj.UseComCHAR(CSByte(97), outUseComChar)
        Console.WriteLine("UseComChar: {0}, {1}", _
            outUseComChar.GetType().Name, outUseComChar)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
