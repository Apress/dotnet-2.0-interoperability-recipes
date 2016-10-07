Imports Interop.DniComEventsVB

Module EventHandlingVBTest

    Sub Main()
        'create the VB6 COM object
        Dim comObj As DniComEventsVBObj = New DniComEventsVBObj()

        'create a delegate for the event handler
        Dim comDelegate As __DniComEventsVBObj_OnDescChangedEventHandler _
            = New __DniComEventsVBObj_OnDescChangedEventHandler( _
                AddressOf OnDescChangedEventHandler)
        'subscribe to the event
        AddHandler comObj.OnDescChanged, comDelegate

        'call the COM method that fires the event
        comObj.ChangeDesc("VBfirst")
        'call it again
        comObj.ChangeDesc("VBsecond")

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

    Public Sub OnDescChangedEventHandler(ByVal newDesc As String, _
                ByVal oldDesc As String)
        Console.WriteLine( _
            "Received VB OnDescChanged event: Old:{0}, New:{1}", _
            oldDesc, newDesc)
    End Sub

End Module
