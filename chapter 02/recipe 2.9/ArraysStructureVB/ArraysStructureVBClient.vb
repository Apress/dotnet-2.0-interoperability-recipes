Imports System.Runtime.InteropServices  'needed for DllImport
Module ArraysStructureVBClient

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Public Structure ManagedAcctSummary
        Public AccountId As Integer
        Public FirstName As String
        Public LastName As String
        Public CurrentBalance As Double
    End Structure

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Sub RetrieveAccountSummaries( _
        <[In](), Out()> ByVal summaries As ManagedAcctSummary(), ByVal size As Integer)
    End Sub

    Sub Main()
        'allocate and populate the array of structs
        Dim summaries(4) As ManagedAcctSummary
        Dim i As Integer
        For i = 0 To (summaries.Length - 1)
            summaries(i).AccountId = i + 1001
        Next

        'call the unmanaged function to fill the array
        RetrieveAccountSummaries(summaries, summaries.Length)

        'show the results
        For i = 0 To (summaries.Length - 1)
            Console.WriteLine( _
                "RetrieveAccountSummaries: {0},{1},{2},{3}", _
                summaries(i).AccountId, summaries(i).CurrentBalance, _
                summaries(i).FirstName, summaries(i).LastName)
        Next

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
