Imports System.Runtime.InteropServices
Imports System.EnterpriseServices

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniScNotJITObj
    Inherits ServicedComponent
    Implements IJITMethods

    Private m_Number As Integer

    Public Sub AddNumber(ByVal number As Integer) _
        Implements IJITMethods.AddNumber

        m_Number += number

    End Sub

    Public Function GetTotal() As Integer _
        Implements IJITMethods.GetTotal

        Return m_Number

    End Function

    Public Function AddSomeNumbers(ByVal numA As Integer, _
        ByVal numB As Integer) As Integer _
        Implements IJITMethods.AddSomeNumbers

        Return numA + numB

    End Function

End Class
