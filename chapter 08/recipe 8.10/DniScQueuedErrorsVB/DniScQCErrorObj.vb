Imports System.IO
Imports System.Runtime.InteropServices
Imports System.EnterpriseServices

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniScQCErrorObj
    Inherits ServicedComponent
    Implements IQueuedComponent
    Implements IPlaybackControl

    Public Sub LogMessage(ByVal message As String) _
        Implements IQueuedComponent.LogMessage

        'called if the message cannot be delivered
        'to the original component

        Dim writer As StreamWriter _
            = New StreamWriter("c:\QCErrorLog.txt", True)
        writer.WriteLine(message)
        writer.Flush()
        writer.Close()
    End Sub

    Public Sub FinalClientRetry() _
        Implements IPlaybackControl.FinalClientRetry

    End Sub

    Public Sub FinalServerRetry() _
        Implements IPlaybackControl.FinalServerRetry

    End Sub
End Class
