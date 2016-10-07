Imports System.Runtime.InteropServices
Imports System.ComponentModel

''' <summary>
''' Return the error code from a Win32 API call
''' </summary>
''' <remarks></remarks>
Module Win32ErrorTest

    'save the last error, and use the wide version
    <DllImport("kernel32.DLL", CharSet:=CharSet.Unicode, _
        SetLastError:=True)> _
    Public Function DeleteFile( _
        <MarshalAs(UnmanagedType.LPWStr)> _
        ByVal fileName As String) _
        As Boolean
    End Function

    'do not save the last error
    <DllImport("kernel32.DLL", EntryPoint:="DeleteFile", _
        CharSet:=CharSet.Unicode)> _
    Public Function DeleteFileNoError( _
        ByVal fileName As String) _
        As Boolean
    End Function

    Sub Main()

        Try
            'attempt to delete a file that doesn't exist
            DeleteFile("TestFileNotThere")
            'returns system error code 2: ERROR_FILE_NOT_FOUND
            '"The system cannot find the file specified"
            Dim lastError As Integer _
                = Marshal.GetLastWin32Error()
            Console.WriteLine( _
                "DeleteFile last error code: {0}", lastError)

            'turn the win32 error into an exception
            Throw New Win32Exception(lastError)

        Catch ex As Exception
            Console.WriteLine( _
                "DeleteFile last error message: {0}", ex.Message)
        End Try

        'execute the same test, 
        'without the SetLastError property
        DeleteFileNoError("TestFileNotThere")
        Console.WriteLine( _
            "DeleteFileNoError last error code: {0}", _
            Marshal.GetLastWin32Error())

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
