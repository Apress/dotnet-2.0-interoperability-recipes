Option Explicit On

Imports System.Runtime.InteropServices

''' <summary>
''' An interface for classes that do addition
''' </summary>
''' <remarks></remarks>
Public Interface IAddNumbers
    Function AddSomeNumbers( _
        ByVal numA As Integer, ByVal numB As Integer) _
            As Integer
End Interface

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetSimpleNumbersIFaceVB
    Implements IAddNumbers

    Public Function AddSomeNumbers( _
        ByVal numA As Integer, ByVal numB As Integer) _
            As Integer Implements IAddNumbers.AddSomeNumbers

        Return numA + numB

    End Function

End Class
