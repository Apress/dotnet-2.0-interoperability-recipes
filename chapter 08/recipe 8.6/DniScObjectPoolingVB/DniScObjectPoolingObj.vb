Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.EnterpriseServices

<ObjectPooling(30, 100)> _
<JustInTimeActivation()> _
<EventTrackingEnabled()> _
<ClassInterface(ClassInterfaceType.None)> _
Public Class DniScObjectPoolingObj
    Inherits ServicedComponent
    Implements IObjectPoolingMethods

    Private m_KeyCodes As Hashtable

    Public Sub New()
        'simulate the cost of object construction.
        'this might represent the time needed to 
        'retrieve and locally cache selected
        'values from a database or other source.
        System.Threading.Thread.Sleep(100)

        'build an in-memory cache of frequently
        'used data. in a live application, this
        'might be populated from a database query.
        m_KeyCodes = New Hashtable()
        m_KeyCodes.Add("AAA", 11111)
        m_KeyCodes.Add("BBB", 22222)
        m_KeyCodes.Add("CCC", 33333)
        m_KeyCodes.Add("DDD", 44444)
        m_KeyCodes.Add("EEE", 55555)
    End Sub

    <AutoComplete()> _
    Public Function LookupKeyCode(ByVal key As String) _
        As Integer _
        Implements IObjectPoolingMethods.LookupKeyCode

        Dim result As Integer = 0
        If m_KeyCodes.Contains(key) Then
            result = m_KeyCodes.Item(key)
        Else
            'not in the local cache, so we need to
            'retrieve it from the database
        End If
    End Function

    Protected Overrides Function CanBePooled() As Boolean
        'override the base method in order to allow
        'pooling of this object
        Return True
    End Function
End Class
