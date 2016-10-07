VERSION 5.00
Begin VB.Form ComCurrencyVBForm 
   Caption         =   "Form1"
   ClientHeight    =   3045
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   7635
   LinkTopic       =   "Form1"
   ScaleHeight     =   3045
   ScaleWidth      =   7635
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text1 
      Height          =   2175
      Left            =   360
      MultiLine       =   -1  'True
      TabIndex        =   0
      Top             =   240
      Width           =   6735
   End
End
Attribute VB_Name = "ComCurrencyVBForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private comObj As _
        New DniNetCurrency.DniNetCurrencyObj

Private Sub Form_Load()
    
    Call CallUseVariant(CCur(123.45), "variant")
    Call CallUseVariantCurrency(CCur(123.45), "currency wrapper")
    Call CallUseDecimalCurrency(CCur(123.45), "decimal currency")
    
    'free the COM reference
    Set comObj = Nothing
    
    'test the VB.NET version of the COM class
    Call Test
    
End Sub

Private Sub CallUseVariant(testValue As Variant, _
        testDesc As String)
    Dim outParam As Variant
    Dim desc As String
    'call the managed method via com
    desc = comObj.UseNativeVariant(testValue, outParam)
    Text1.Text = Text1.Text + _
        "Test: " + testDesc + _
        ", Managed Type: " + desc + _
        ", Var Type: " + TypeName(outParam) _
        + vbCrLf
End Sub

Private Sub CallUseVariantCurrency(testValue As Variant, _
        testDesc As String)
    Dim outParam As Variant
    Dim desc As String
    'call the managed method that uses a CurrencyWrapper
    desc = comObj.UseVariantCurrency(testValue, outParam)
    Text1.Text = Text1.Text + _
        "Test: " + testDesc + _
        ", Managed Type: " + desc + _
        ", Var Type: " + TypeName(outParam) _
        + vbCrLf
End Sub

Private Sub CallUseDecimalCurrency(testValue As Variant, _
        testDesc As String)
    Dim outParam As Currency
    Dim desc As String
    'call the managed method that uses the decimal type
    'instead of a variant for currency
    desc = comObj.UseDecimalCurrency(testValue, outParam)
    Text1.Text = Text1.Text + _
        "Test: " + testDesc + _
        ", Managed Type: " + desc + _
        ", Var Type: " + TypeName(outParam) _
        + vbCrLf
End Sub

