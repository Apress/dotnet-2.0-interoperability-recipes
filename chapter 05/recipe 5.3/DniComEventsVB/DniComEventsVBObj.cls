VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DniComEventsVBObj"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
'define an event that can be handled
Event OnDescChanged(ByVal newDesc As String, ByVal oldDesc As String)

Private m_Desc As String

'com method that fires the event
Public Function ChangeDesc(ByVal newDesc As String)

    'fire the event to any subscribers
    RaiseEvent OnDescChanged(newDesc, m_Desc)
    'save the new value
    m_Desc = newDesc

End Function

