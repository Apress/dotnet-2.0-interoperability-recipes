Attribute VB_Name = "TestVBNet"
Option Explicit

Private comObj As _
    New DniNetVariantsVB.DniNetVariantsObj

Public Sub Test()

    ComVariantsVBForm.Text1.Text _
        = ComVariantsVBForm.Text1.Text + _
        vbCrLf + vbCrLf

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
End Sub

Private Sub CallUseVariant(testValue As Variant, _
        testDesc As String)
    Dim outParam As Variant
    Dim desc As String
    'call the managed method via com
    desc = comObj.UseVariant(testValue, outParam)
    ComVariantsVBForm.Text1.Text _
        = ComVariantsVBForm.Text1.Text + _
        "Test: " + testDesc + _
        ", Managed Type: " + desc + _
        ", Var Type: " + TypeName(outParam) _
        + vbCrLf
End Sub


