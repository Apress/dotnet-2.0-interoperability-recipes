Imports System
Imports System.Runtime.InteropServices

Module StructureReturningTest

    Public Structure ReturnedManagedStruct
        Public Hours As Integer
        Public Minutes As Integer
        Public Seconds As Integer
    End Structure

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Function ReturnAStruct() As IntPtr
    End Function

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Sub FreeAStruct(ByVal structPtr As IntPtr)
    End Sub

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Function ReturnCoMemStruct() As IntPtr
    End Function

    Sub Main()
        'call the unmanaged function returning a struct
        Dim structPtr As IntPtr = ReturnAStruct()
        'marshal the returned pointer to a struct
        Dim aStruct As ReturnedManagedStruct _
            = Marshal.PtrToStructure( _
                structPtr, GetType(ReturnedManagedStruct))
        'free the memory for the unmanaged struct
        FreeAStruct(structPtr)
        'show the results
        Console.WriteLine( _
            "ReturnAStruct results: {0}, {1}, {2}", _
            aStruct.Hours, aStruct.Minutes, aStruct.Seconds)


        'call the unmanaged function 
        'returning a CoTaskMemAlloc struct
        structPtr = ReturnCoMemStruct()
        'marshal the returned pointer to a struct
        Dim bStruct As ReturnedManagedStruct _
            = Marshal.PtrToStructure( _
                structPtr, GetType(ReturnedManagedStruct))
        'free the CoTaskMemAlloc memory
        Marshal.FreeCoTaskMem(structPtr)
        'show the results
        Console.WriteLine( _
            "ReturnCoMemStruct results: {0}, {1}, {2}", _
            bStruct.Hours, bStruct.Minutes, bStruct.Seconds)


        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()


    End Sub

End Module
