Option Explicit On
'Option Strict On 'disallows late-binding

Module ComLateBindingVBTest

    Sub Main()
        'Retrieve the Type for the COM object
        Dim comType As Type
        comType = Type.GetTypeFromProgID( _
            "DniComRefactorVB.DniComRefactorVBObj")

        'comType = Type.GetTypeFromCLSID( _
        '   New Guid("{6E6F51E4-7387-4C07-970D-AD452DC6971D}"))

        'create an instance of the COM object
        Dim comObj As Object    'dim for late-binding
        comObj = Activator.CreateInstance(comType)

        Dim acctId As Integer
        Dim pastDueAmt As Decimal
        'execute the first COM method
        acctId = comObj.SearchForAccount("accountKey")
        If acctId > 0 Then
            'the second COM method
            pastDueAmt = comObj.GetPastDueBalance(acctId)
            If pastDueAmt > 100 Then
                'the third COM method
                comObj.SetAccountDelinquent(acctId)
            End If
        End If
        Console.WriteLine("Acct Id:{0}, PastDueAmt:{1}", _
            acctId, pastDueAmt)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
