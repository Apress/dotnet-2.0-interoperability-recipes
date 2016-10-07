Imports System
Imports System.Runtime.InteropServices

'define enum for status
Public Enum CustomerStatus
    Unknown = 0
    Current = 1
    Inactive = 2
    PastDue = 3
    InCollections = 4
End Enum

'define enum for cust type
Public Enum CustomerType
    Individual = 1001
    Corporate = 2122
    Government = 35
    NonProfit = 501
End Enum

Friend Class NativeMethods
    'declare the unmanaged api
    <DllImport("FlatAPILib.DLL")> _
    Public Shared Function GetCustomerStatus( _
        ByVal customerId As String, _
        ByVal customerType As Integer) As Integer
    End Function
End Class

Public Class CustomerWrapperVB
    'wrapper method
    Public Function GetCustomerStatus( _
        ByVal custType As CustomerType, _
        ByVal custId As String) As CustomerStatus

        Dim customerTypeInt As Integer = 0

        'validate the enum value passed in
        If (System.Enum.IsDefined( _
            GetType(CustomerType), custType)) Then
            customerTypeInt = custType
        Else
            Throw New ArgumentOutOfRangeException( _
                String.Format( _
                "Invalid CustomerType {0}", custType))
        End If

        'make the function call
        Dim result As Integer
        result = NativeMethods.GetCustomerStatus( _
            custId, customerTypeInt)
        'convert the result
        If (System.Enum.IsDefined( _
            GetType(CustomerStatus), result)) Then
            Return result
        Else
            Return CustomerStatus.Unknown
        End If
    End Function
End Class

