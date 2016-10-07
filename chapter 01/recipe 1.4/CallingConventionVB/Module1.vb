Imports System.Runtime.InteropServices

'used for syntax checking only - no actual tests

Module Module1
    <DllImport("FlatAPILib.DLL", _
        CallingConvention:=CallingConvention.Cdecl)> _
    Public Function AddSomeNumbers( _
        ByVal myNumA As Integer, ByVal myNumB As Integer) _
            As Integer
    End Function

    Sub Main()

        Try
            ' managed or unmanaged calls go here
        Catch ex As Exception
            ' handle the exception by logging the problem, retrying
            ' the operation, etc.
        Finally
            ' do any final cleanup and freeing of resources
        End Try

    End Sub

End Module
