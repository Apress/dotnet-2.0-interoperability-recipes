VERSION 5.00
Begin VB.Form ComEventsClilentVBForm 
   Caption         =   "Form1"
   ClientHeight    =   3885
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   5145
   LinkTopic       =   "Form1"
   ScaleHeight     =   3885
   ScaleWidth      =   5145
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   3615
      Left            =   120
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   120
      Width           =   4815
   End
End
Attribute VB_Name = "ComEventsClilentVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'declare a variable for the com object withevents
'Public WithEvents comObj As DniNetComEvents.DniNetComEventsObj
Public WithEvents comObj As DniNetComEventsVB.DniNetComEventsVBObj
Attribute comObj.VB_VarHelpID = -1

'event handler for the com object
Private Sub comObj_DescChanged( _
        ByVal newDesc As String, ByVal oldDesc As String)
    'display the event arguments
    Text1.Text = Text1.Text + "Old: " + oldDesc _
        + "  New: " + newDesc + vbCrLf
End Sub

Private Sub Form_Load()
    'create an instance of the com object
'    Set comObj = New DniNetComEvents.DniNetComEventsObj
    Set comObj = New DniNetComEventsVB.DniNetComEventsVBObj
    'call the change description method that should
    'fire the event
    comObj.ChangeDesc ("one")
    comObj.ChangeDesc ("two")
    comObj.ChangeDesc ("three")
    
    'free the COM reference
    Set comObj = Nothing
End Sub
