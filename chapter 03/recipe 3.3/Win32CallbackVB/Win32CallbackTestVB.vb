Imports System.Runtime.InteropServices
Imports System.Threading

Module Win32CallbackTestVB

    'constants used for date formats
    Private Const DATE_SHORTDATE As Integer = &H1 ' use short date picture
    Private Const DATE_LONGDATE As Integer = &H2  ' use long date picture
    Private Const DATE_YEARMONTH As Integer = &H8 ' use year month picture

    'define the delegate for the callback 
    Public Delegate Function EnumDateFormatsProcEx( _
        ByVal dateFormat As String, ByVal calId As Integer) As Boolean

    <DllImport("kernel32.DLL", SetLastError:=True)> _
    Public Function EnumDateFormatsEx( _
        ByVal callBackProc As EnumDateFormatsProcEx, _
            ByVal LCID As Integer, ByVal flags As Long) As Boolean
    End Function

    Sub Main()
        'call the function, passing a delegate for the callback
        EnumDateFormatsEx( _
            AddressOf EnumDateFormatsCallback, _
            Thread.CurrentThread.CurrentCulture.LCID, _
            DATE_SHORTDATE)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

    'callback function
    Function EnumDateFormatsCallback(ByVal dateFormat As String, _
            ByVal calId As Integer) As Boolean
        Console.WriteLine("CalId: {0}, Date Format: {1}", calId, dateFormat)
        Return True
    End Function

End Module
