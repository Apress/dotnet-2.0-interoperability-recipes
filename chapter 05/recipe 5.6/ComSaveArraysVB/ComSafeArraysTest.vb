Imports Interop.DniDataTypesVB
Imports DniDataTypesLib

Module ComSafeArraysTest

    Sub Main()

        'test vb com object with arrays
        Dim vbObj As DniDataTypesVBObj = New DniDataTypesVBObjClass()
        'create the test array of strings
        Dim vbArray(2) As String
        vbArray(0) = "one"
        vbArray(1) = "two"
        vbArray(2) = "three"
        'make the call to the VB COM component
        Dim vbResult As String = vbObj.UseArray(vbArray)
        Console.WriteLine("VB Array: {0},{1},{2},{3}", _
         vbArray(0), vbArray(1), vbArray(2), vbResult)


        'test C++ object with arrays
        'create an instance of the COM object				
        Dim comObj As DniDataTypesObj = New DniDataTypesObj()
        Dim desc As String = String.Empty

        'pass an array in as a safearray				
        Dim testSafeArray() As String = {"one", "two", "three"}
        Console.WriteLine("Input Array Before: {0}, {1}, {2}", _
            testSafeArray(0), testSafeArray(1), _
            testSafeArray(2))

        'make the com call passing the managed array
        desc = comObj.UseArray(testSafeArray)
        Console.WriteLine("UseArray results: {0}", desc)

        'update an array of strings within the COM component
        Dim testUpdateSafeArray() As String = {"one", "two", "three"}
        Console.WriteLine("Array Before: {0}, {1}, {2}", _
            testUpdateSafeArray(0), testUpdateSafeArray(1), _
            testUpdateSafeArray(2))

        'make the com call
        comObj.UpdateArray(testUpdateSafeArray)
        Console.WriteLine("Array After: {0}, {1}, {2}", _
            testUpdateSafeArray(0), testUpdateSafeArray(1), _
            testUpdateSafeArray(2))

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
