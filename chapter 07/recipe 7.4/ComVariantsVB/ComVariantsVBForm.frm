VERSION 5.00
Begin VB.Form ComVariantsVBForm 
   Caption         =   "Form1"
   ClientHeight    =   7695
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   8805
   LinkTopic       =   "Form1"
   ScaleHeight     =   7695
   ScaleWidth      =   8805
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   7215
      Left            =   240
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   120
      Width           =   8175
   End
End
Attribute VB_Name = "ComVariantsVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private comObj As _
        New DniNetVariants.DniNetVariantsObj

Private Sub Form_Load()

    Call CallUseVariant("a string", "string")
    Call CallUseVariant(123, "short")
    Call CallUseVariant(CLng(123), "long")
    Call CallUseVariant(123.45, "double")
    Call CallUseVariant(CSng(123.45), "single")
    Call CallUseVariant(CDec(123.45), "decimal")
    Call CallUseVariant(True, "boolean")
    Call CallUseVariant(CByte(11), "byte")
    Call CallUseVariant(CDate("1969-07-20"), "date")
    
    Dim stringArray(5) As String
    Call CallUseVariant(stringArray, "string array")
    
    Dim intArray(5) As Integer
    Call CallUseVariant(intArray, "integer array")
    
    Dim dateArray(5) As Date
    Call CallUseVariant(dateArray, "date array")
    
    'free the COM reference
    Set comObj = Nothing
    
    'perform the tests using the VB.NET class
    Call Test
    
End Sub

Private Sub CallUseVariant(testValue As Variant, _
        testDesc As String)
    Dim outParam As Variant
    Dim desc As String
    'call the managed method via com
    desc = comObj.UseVariant(testValue, outParam)
    Text1.Text = Text1.Text + _
        "Test: " + testDesc + _
        ", Managed Type: " + desc + _
        ", Var Type: " + TypeName(outParam) _
        + vbCrLf
End Sub

