Imports System.Runtime.InteropServices

Public Interface ICheckSyntax
    Sub UseAnArray(ByRef elements() As Integer)
    Sub UseAnArrayX(<[In]()> ByRef elements() As Integer)
    Sub UseAnArrayByValue(ByVal elements() As Integer)
    Sub UseAnArrayByValueX(<[In](), Out()> ByVal elements() As Integer)
    Function ReturnAnArray() As Integer()
End Interface

