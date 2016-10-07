Imports System.Runtime.InteropServices

Public Class CustomException
    Inherits ApplicationException

    Public Sub New(ByVal msg As String)
        MyBase.New(msg)
    End Sub
End Class

Public Class CustomExceptionWithHResult
    Inherits ApplicationException

    Public Sub New(ByVal msg As String)
        MyBase.New(msg)
        Me.HResult = &H80040301
    End Sub
End Class

Public Interface IExceptions
    Sub ThrowStandardException()
    Sub ThrowCustomException()
    Sub ThrowCustomExceptionWithHResult()
End Interface

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetExceptionsObj
    Implements IExceptions

    Public Sub ThrowStandardException() _
            Implements IExceptions.ThrowStandardException
        Throw New ApplicationException( _
            "This is an ApplicationException")
    End Sub

    Public Sub ThrowCustomException() _
            Implements IExceptions.ThrowCustomException
        Throw New CustomException( _
            "My custom exception message")
    End Sub

    Public Sub ThrowCustomExceptionWithHResult() _
            Implements IExceptions.ThrowCustomExceptionWithHResult
        Throw New CustomExceptionWithHResult( _
            "My custom exception message with HResult")
    End Sub

End Class
