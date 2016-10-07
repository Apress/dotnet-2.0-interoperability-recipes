Imports System.IO
Imports System.Runtime.InteropServices
Imports System.EnterpriseServices

<InterfaceQueuing()> _
Public Interface IQueuedComponent
    Sub LogMessage(ByVal message As String)
End Interface

<ExceptionClass("DniScQueuedComponentVB.DniScQCErrorObj")> _
<ClassInterface(ClassInterfaceType.None)> _
Public Class DniScQCObj
    Inherits ServicedComponent
    Implements IQueuedComponent

    Public Sub LogMessage(ByVal message As String) _
        Implements IQueuedComponent.LogMessage

        Dim writer As StreamWriter _
            = New StreamWriter("c:\QCLog.txt", True)
        writer.WriteLine(message)
        writer.Flush()
        writer.Close()
    End Sub
End Class
