Imports System
Imports System.Runtime.InteropServices

Module ArraysStringTest
    <DllImport("FlatAPIStructLib.DLL")> _
    Public Sub StringArrayToUpper( _
        <[In](), Out()> ByVal strings() As String, _
        ByVal size As Integer)
    End Sub

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Sub FillStringArray( _
        ByVal buffers() As IntPtr, _
        ByVal size As Integer, ByVal maxStringSize As Integer)
    End Sub

    Sub Main()

        'pass an array of strings to unmanaged code
        Dim strings(2) As String
        strings(0) = "sTringOne"
        strings(1) = "stringTWO"
        strings(2) = "STRINGthree"
        'call the unmanaged function to update the strings
        StringArrayToUpper(strings, strings.Length)
        Console.WriteLine( _
            "StringArrayToUpper results: {0},{1},{2}", _
            strings(0), strings(1), strings(2))


        'allocate buffers for use by the function
        Dim buffers(2) As IntPtr
        Const maxSize As Integer = 255
        Dim i As Integer
        For i = 0 To buffers.Length - 1
            buffers(i) = Marshal.AllocCoTaskMem(maxSize)
        Next

        'call the function to fill the buffers
        FillStringArray(buffers, buffers.Length, maxSize)
        'marshal the IntPtrs to strings 
        Dim resultStrings(2) As String
        For i = 0 To buffers.Length - 1
            resultStrings(i) = Marshal.PtrToStringAnsi(buffers(i))
            'free the memory we allocated
            Marshal.FreeCoTaskMem(buffers(i))
        Next

        'show the results
        Console.WriteLine( _
            "FillStringArray results: {0},{1},{2}", _
            resultStrings(0), resultStrings(1), resultStrings(2))

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
