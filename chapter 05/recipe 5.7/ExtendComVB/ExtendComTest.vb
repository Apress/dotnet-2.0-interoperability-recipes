Imports System
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Imports Interop.DniExtendComVB

''' <summary>
''' Define search types
'''</summary>
Public Enum SearchType
    Unknown = 0
    Name = 1
    TaxId = 2
    Address = 3
End Enum

''' <summary>
''' Extend a COM RCW
''' </summary>
Public Class ExtendedComClass
    Inherits DniExtendComVBObjClass 'the RCW

    Public Function AccountBalance(ByVal searchArg As String, _
    ByVal searchType As SearchType) As Decimal

        Dim result As Decimal = 0

        'validate the requested search type
        Dim validSearchType As SearchType _
            = ValidateSearchType(searchType)

        'validate the search argument based on the search type
        ValidateSearchArgument(validSearchType, searchArg)

        Try
            'everything passes our tests, so make the COM call
            Dim acctId As Integer _
                = MyBase.AccountLookup(searchArg, validSearchType)
            'check the result
            If acctId = 0 Then
                Throw New ApplicationException( _
                    String.Format("Account not found for {0} {1}", _
                    searchType, searchArg))
            End If
            'retrieve the current balance for the account
            result = MyBase.GetCurrentBalance(acctId)

        Catch ex As Exception
            Throw New ApplicationException( _
                "Exception thrown calling COM method", ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' Validate the search type
    ''' </summary>
    ''' <param name="searchType"></param>
    ''' <returns></returns>
    Private Function ValidateSearchType(ByVal searchType As SearchType) _
        As SearchType
        Dim validSearchType As SearchType _
            = ExtendComVB.SearchType.Unknown
        If [Enum].IsDefined(GetType(SearchType), searchType) Then
            validSearchType = searchType
        Else
            Throw New ApplicationException(String.Format( _
                "Search type of {0} is invalid", searchType))
        End If
        Return validSearchType
    End Function

    ''' <summary>
    ''' Validate the search argument based on the search type.
    ''' Throws an exception if the search argument is invalid.
    ''' </summary>
    ''' <param name="searchtype"></param>
    ''' <param name="searchArg"></param>
    Private Sub ValidateSearchArgument(ByVal searchType As SearchType, _
            ByVal searchArg As String)
        'define regex strings used for validation
        Const TaxIdRegex As String _
            = "^(?!000)([0-6]\d{2}|7([0-6]\d|7[012]))" _
            + "([ -]?)(?!00)\d\d\3(?!0000)\d{4}$"
        Const NameRegex As String _
            = "^([a-zA-z\s]{4,50})$"
        Const AddressRegex As String _
            = "^[a-zA-Z\d]+(([\'\,\.\- #][a-zA-Z\d ])" _
            + "?[a-zA-Z\d]*[\.]*)*$"

        'validate the search argument based on the search type
        Select Case searchType
            Case ExtendComVB.SearchType.Name
                If Not Regex.IsMatch(searchArg, NameRegex) Then
                    Throw New ApplicationException(String.Format( _
                        "Search argument of {0} is not a valid {1}", _
                        searchArg, searchType))
                End If
            Case ExtendComVB.SearchType.TaxId
                If Not Regex.IsMatch(searchArg, TaxIdRegex) Then
                    Throw New ApplicationException(String.Format( _
                        "Search argument of {0} is not a valid {1}", _
                        searchArg, searchType))
                End If
            Case ExtendComVB.SearchType.Address
                If Not Regex.IsMatch(searchArg, AddressRegex) Then
                    Throw New ApplicationException(String.Format( _
                        "Search argument of {0} is not a valid {1}", _
                        searchArg, searchType))
                End If
        End Select
    End Sub

End Class

Module ExtendComTest

    Sub Main()
        'create an instance of the extended RCW
        Dim comObj As ExtendedComClass = New ExtendedComClass()

        Dim acctBal As Decimal = 0D
        acctBal = comObj.AccountBalance( _
            "first last", SearchType.Name)
        Console.WriteLine("Balance by Name: {0}", acctBal)
        acctBal = comObj.AccountBalance( _
            "123-45-6789", SearchType.TaxId)
        Console.WriteLine("Balance by Tax Id: {0}", acctBal)
        acctBal = comObj.AccountBalance( _
            "1 main street", SearchType.Address)
        Console.WriteLine("Balance by Address: {0}", acctBal)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
