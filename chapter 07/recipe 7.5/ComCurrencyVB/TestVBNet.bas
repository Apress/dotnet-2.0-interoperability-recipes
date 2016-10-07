Attribute VB_Name = "TestVBNet"
Option Explicit

Private comObj As _
    New DniNetCurrencyVB.DniNetCurrencyObj

Public Sub Test()
    ComCurrencyVBForm.Text1.Text _
        = ComCurrencyVBForm.Text1.Text + vbCrLf
    
    Call CallUseVariant(CCur(123.45), "variant")
    Call CallUseVariantCurrency(CCur(123.45), "currency wrapper")
    Call CallUseDecimalCurrency(CCur(123.45), "decimal currency")
    
    'free the COM reference
    Set comObj = Nothing

End Sub

Private Sub CallUseVariant(testValue As Variant, _
        testDesc As String)
    Dim outParam As Variant
    Dim desc As String
    'call the managed method via com
    desc = comObj.UseNativeVariant(testValue, outParam)
    ComCurrencyVBForm.Text1.Text = ComCurrencyVBForm.Text1.Text + _
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
    ComCurrencyVBForm.Text1.Text = ComCurrencyVBForm.Text1.Text + _
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
    ComCurrencyVBForm.Text1.Text = ComCurrencyVBForm.Text1.Text + _
        "Test: " + testDesc + _
        ", Managed Type: " + desc + _
        ", Var Type: " + TypeName(outParam) _
        + vbCrLf
End Sub



