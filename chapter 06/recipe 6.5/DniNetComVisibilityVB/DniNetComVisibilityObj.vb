Imports System.Runtime.InteropServices

Public Interface IComVisibility
    <ComVisible(False)> _
    Sub Method1()
    Sub Method2()
    <ComVisible(False)> _
    Property Property1() As Integer
    Property Property2() As Integer
End Interface

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetComVisibilityObj
    Implements IComVisibility

    Public Sub Method1() Implements IComVisibility.Method1

    End Sub

    Public Sub Method2() Implements IComVisibility.Method2

    End Sub

    Public Property Property1() As Integer _
            Implements IComVisibility.Property1
        Get
            Return 0
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Public Property Property2() As Integer _
            Implements IComVisibility.Property2
        Get
            Return 0
        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Protected Sub ProtectedMethod1()

    End Sub

    Private Sub PrivateMethod()

    End Sub
End Class
