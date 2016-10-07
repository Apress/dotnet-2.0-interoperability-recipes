Imports System
Imports System.Runtime.InteropServices
Imports DniComResultsLib

Module ComResultsTest

    Sub Main()
        'create an instance of the COM object				
        Dim comObj As DniComResultsObj _
            = New DniComResultsObjClass()

        'call the object with different requests				
        MakeTheCall(comObj, 0)
        MakeTheCall(comObj, 1)
        MakeTheCall(comObj, 2)
        MakeTheCall(comObj, 3)
        MakeTheCall(comObj, 4)
        MakeTheCall(comObj, 5)

        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

    Private Sub MakeTheCall(ByVal comObj As DniComResultsObj, _
        ByVal request As Integer)

        Try
            comObj.ProvideDifferentResults(request)
            Console.WriteLine( _
                "No Exception for request: {0}", request)
        Catch ex As Exception
            Dim hResult As Integer = Marshal.GetHRForException(ex)
            Console.WriteLine( _
             "Exception: request: {0}, type: {1}, HRESULT: {2:X}", _
                request, ex.GetType().Name, hResult)
        End Try
    End Sub

End Module
