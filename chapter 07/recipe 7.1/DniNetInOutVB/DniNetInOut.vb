Imports System.Runtime.InteropServices

Public Interface IDirectionTester
    Sub IntInOnly(ByVal paramA As Integer, _
        ByVal paramB As Integer)
    Sub IntInAndOut(ByVal paramA As Integer, _
        <[In](), Out()> ByVal paramB As Integer)
    Sub IntByRef(ByVal paramA As Integer, _
        ByRef paramB As Integer)
    Sub IntByRefInOnly(ByVal paramA As Integer, _
        <[In]()> ByRef paramB As Integer)
    'sub IntOut(int paramA, out int paramB);
    Sub StringsInOnly(ByVal paramA As String, _
        ByVal paramB As String)
    Sub StringsInAndOut(ByVal paramA As String, _
        <[In](), Out()> ByVal paramB As String)
    Sub StringsByRef(ByVal paramA As String, _
        ByRef paramB As String)
    Sub StringsByRefInOnly(ByVal paramA As String, _
        <[In]()> ByRef paramB As String)
    'sub StringsOut(string paramA, out string paramB);
    Sub DateTimeInOnly(ByVal paramA As DateTime, _
        ByVal paramB As DateTime)
    Sub DateTimeInAndOut(ByVal paramA As DateTime, _
        <[In](), Out()> ByVal paramB As DateTime)
    Sub DateTimeByRef(ByVal paramA As DateTime, _
        ByRef paramB As DateTime)
    Sub DateTimeByRefInOnly(ByVal paramA As DateTime, _
        <[In]()> ByRef paramB As DateTime)
    'sub DateTimeOut(DateTime paramA, out DateTime paramB);
End Interface

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetInOutObj
    Implements IDirectionTester

    Public Sub DateTimeByRef(ByVal paramA As Date, _
        ByRef paramB As Date) _
        Implements IDirectionTester.DateTimeByRef
        paramB = paramA
    End Sub

    Public Sub DateTimeByRefInOnly(ByVal paramA As Date, _
        ByRef paramB As Date) _
        Implements IDirectionTester.DateTimeByRefInOnly
        paramB = paramA
    End Sub

    Public Sub DateTimeInAndOut(ByVal paramA As Date, _
        ByVal paramB As Date) _
        Implements IDirectionTester.DateTimeInAndOut
        paramB = paramA
    End Sub

    Public Sub DateTimeInOnly(ByVal paramA As Date, _
        ByVal paramB As Date) _
        Implements IDirectionTester.DateTimeInOnly
        paramB = paramA
    End Sub

    Public Sub IntByRef(ByVal paramA As Integer, _
        ByRef paramB As Integer) _
        Implements IDirectionTester.IntByRef
        paramB = paramA
    End Sub

    Public Sub IntByRefInOnly(ByVal paramA As Integer, _
        ByRef paramB As Integer) _
        Implements IDirectionTester.IntByRefInOnly
        paramB = paramA
    End Sub

    Public Sub IntInAndOut(ByVal paramA As Integer, _
        ByVal paramB As Integer) _
        Implements IDirectionTester.IntInAndOut
        paramB = paramA
    End Sub

    Public Sub IntInOnly(ByVal paramA As Integer, _
        ByVal paramB As Integer) _
        Implements IDirectionTester.IntInOnly
        paramB = paramA
    End Sub

    Public Sub StringsByRef(ByVal paramA As String, _
        ByRef paramB As String) _
        Implements IDirectionTester.StringsByRef
        paramB = paramA
    End Sub

    Public Sub StringsByRefInOnly(ByVal paramA As String, _
        ByRef paramB As String) _
        Implements IDirectionTester.StringsByRefInOnly
        paramB = paramA
    End Sub

    Public Sub StringsInAndOut(ByVal paramA As String, _
        ByVal paramB As String) _
        Implements IDirectionTester.StringsInAndOut
        paramB = paramA
    End Sub

    Public Sub StringsInOnly(ByVal paramA As String, _
        ByVal paramB As String) _
        Implements IDirectionTester.StringsInOnly
        paramB = paramA
    End Sub
End Class
