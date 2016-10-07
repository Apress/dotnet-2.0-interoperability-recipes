Imports System.Runtime.InteropServices
Imports System.EnterpriseServices

<Description("Interface used to add numbers")> _
Public Interface IAddNumbers
    Function AddSomeNumbers(ByVal numA As Integer, _
        ByVal numB As Integer) As Integer
End Interface

<ClassInterface(ClassInterfaceType.None)> _
<Description("Add numbers server component")> _
Public Class DniScServerComponentObj
    Inherits ServicedComponent
    Implements IAddNumbers

    Public Function AddSomeNumbers(ByVal numA As Integer, _
        ByVal numB As Integer) As Integer _
            Implements IAddNumbers.AddSomeNumbers

        Return numA + numB

    End Function
End Class
