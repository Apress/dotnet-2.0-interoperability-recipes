Option Explicit On

Imports System.Runtime.InteropServices

<ComVisible(False)> _
Public Delegate Sub DescChangedHandler( _
    ByVal newDesc As String, ByVal oldDesc As String)

'an interface defining our event source
<InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)> _
Public Interface IDescriptionNotifier
    <DispId(21)> _
    Sub DescChanged(ByVal newDesc As String, _
        ByVal oldDesc As String)
End Interface

'an interface defining the members we want to expose
'to com clients
<InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)> _
Public Interface IDescriptionManager
    Sub ChangeDesc(ByVal newDesc As String)
End Interface

<ClassInterface(ClassInterfaceType.None)> _
<ComSourceInterfaces(GetType(IDescriptionNotifier))> _
Public Class DniNetComEventsVBObj
    Implements IDescriptionManager

    'declare the event
    Public Event DescChanged As DescChangedHandler

    Public Sub ChangeDesc(ByVal newDesc As String) _
        Implements IDescriptionManager.ChangeDesc

        'raise the managed event
        RaiseEvent DescChanged(newDesc, m_Desc)
        m_Desc = newDesc

    End Sub

    Private m_Desc As String = "empty"

End Class
