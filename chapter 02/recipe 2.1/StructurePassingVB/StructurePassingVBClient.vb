Imports System.Runtime.InteropServices  'needed for DllImport
Module StructurePassingVBClient

    Public Structure ManagedStruct1
        Public maCount As Integer
        Public maUnused As Byte
        Public maDelta As Integer
        Public maPercent As Double
    End Structure

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Sub ProcessStruct1(ByRef aStruct As ManagedStruct1)
    End Sub

    Sub Main()
        'allocate the structure
        Dim struct1 As ManagedStruct1 = New ManagedStruct1
        struct1.maCount = 12345
        struct1.maDelta = 45678
        struct1.maPercent = 5.4321
        'call the unmanaged function that fills the struct
        ProcessStruct1(struct1)
        'show the results
        Console.WriteLine("ProcessStruct1 results: {0}, {1}, {2}", _
            struct1.maCount, struct1.maDelta, struct1.maPercent)
        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
