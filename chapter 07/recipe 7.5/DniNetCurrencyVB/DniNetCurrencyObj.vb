Imports System.Runtime.InteropServices

Public Interface ICurrency
    Function UseNativeVariant(ByVal inParam As Object, _
        ByRef outParam As Object) As String
    Function UseVariantCurrency(ByVal inParam As Object, _
        ByRef outParam As Object) As String
    Function UseDecimalCurrency( _
        <MarshalAs(UnmanagedType.Currency)> _
        ByVal inParam As Decimal, _
        <MarshalAs(UnmanagedType.Currency)> _
        ByRef outParam As Decimal) As String
End Interface

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetCurrencyObj
    Implements ICurrency

    Public Function UseNativeVariant(ByVal inParam As Object, _
        ByRef outParam As Object) As String _
            Implements ICurrency.UseNativeVariant
        outParam = inParam
        Return inParam.GetType().Name
    End Function

    Public Function UseVariantCurrency(ByVal inParam As Object, _
        ByRef outParam As Object) As String _
            Implements ICurrency.UseVariantCurrency
        outParam = New CurrencyWrapper(inParam)
        Return inParam.GetType().Name
    End Function

    Public Function UseDecimalCurrency(ByVal inParam As Decimal, _
        ByRef outParam As Decimal) As String _
            Implements ICurrency.UseDecimalCurrency
        outParam = inParam
        Return inParam.GetType().Name
    End Function

End Class
