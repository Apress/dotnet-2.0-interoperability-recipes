Option Explicit On

Imports System.Runtime.InteropServices

Public Interface IOptional
    Function AddOptionalNumbers( _
            ByVal numA As Integer, _
            Optional ByVal numB As Integer = 1, _
            Optional ByVal numC As Integer = 2) _
            As Integer
End Interface

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetOptionalVBOb
    Implements IOptional

    Public Function AddOptionalNumbers( _
        ByVal numA As Integer, _
        Optional ByVal numB As Integer = 1, _
        Optional ByVal numC As Integer = 2) _
        As Integer Implements IOptional.AddOptionalNumbers

        Return numA + numB + numC
    End Function

End Class

