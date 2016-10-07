Imports System.Runtime.InteropServices
Imports System.Text

Public Interface IStringsVB
    Function ReturnBSTR(ByVal paramA As String, _
        ByVal paramB As String) As String

    Sub InOutBSTR(ByVal paramA As String, _
        ByVal paramB As String, ByRef result As String)

    'sub OutBSTR(string paramA, string paramB,
    '		out string result);

    Sub InOutBuilder(ByVal paramA As String, _
        ByVal paramB As String, ByVal result As StringBuilder)

    'VB6 doesn't support the data types that follow.
    'but we can still access these methods from unmanaged C++ 

    Function ReturnLPWSTR(ByVal paramA As String, _
        ByVal paramB As String) _
            As <MarshalAs(UnmanagedType.LPWStr)> String

    Function ReturnLPSTR(ByVal paramA As String, _
        ByVal paramB As String) _
           As <MarshalAs(UnmanagedType.LPStr)> String

    Function PassAndReturnLPWSTR( _
        <MarshalAs(UnmanagedType.LPWStr)> ByVal paramA As String, _
        <MarshalAs(UnmanagedType.LPWStr)> ByVal paramB As String) _
            As <MarshalAs(UnmanagedType.LPWStr)> String
End Interface

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetStringsObjVB
    Implements IStringsVB

    Public Function ReturnBSTR(ByVal paramA As String, _
        ByVal paramB As String) As String _
            Implements IStringsVB.ReturnBSTR
        Return paramA + paramB
    End Function

    Public Sub InOutBSTR(ByVal paramA As String, _
        ByVal paramB As String, ByRef result As String) _
            Implements IStringsVB.InOutBSTR
        result = paramA + paramB
    End Sub

    Public Sub InOutBuilder(ByVal paramA As String, _
        ByVal paramB As String, _
        ByVal result As System.Text.StringBuilder) _
            Implements IStringsVB.InOutBuilder

        'since the StringBuilder is passed to us with a
        'fixed buffer size, we need to make sure we
        'have sufficient capacity to hold the new string
        Dim newStringSize As Integer _
            = paramA.Length + paramB.Length
        'this throws an exception if insufficient capacity
        result.EnsureCapacity(newStringSize)

        'first remove the current string if any
        result.Remove(0, result.Length)
        'append the new strings
        result.Append(paramA)
        result.Append(paramB)
    End Sub

    Public Function ReturnLPWSTR(ByVal paramA As String, _
        ByVal paramB As String) As String _
            Implements IStringsVB.ReturnLPWSTR
        Return paramA + paramB
    End Function

    Public Function ReturnLPSTR(ByVal paramA As String, _
        ByVal paramB As String) As String _
            Implements IStringsVB.ReturnLPSTR
        Return paramA + paramB
    End Function

    Public Function PassAndReturnLPWSTR(ByVal paramA As String, _
        ByVal paramB As String) As String _
            Implements IStringsVB.PassAndReturnLPWSTR
        Return paramA + paramB
    End Function

End Class
