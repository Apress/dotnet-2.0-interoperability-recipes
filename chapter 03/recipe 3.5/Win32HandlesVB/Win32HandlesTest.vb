Imports System
Imports System.IO
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports Microsoft.Win32.SafeHandles

Module Win32HandlesTest

    ''' <summary>
    ''' A wrapper for the CreateFile Win32 API
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CreateFileHelper

        <DllImport("kernel32.DLL", SetLastError:=True)> _
        Private Shared Function CreateFile( _
            ByVal fileName As String, _
            ByVal desiredAccess As UInteger, _
            ByVal sharedMode As UInteger, _
            ByVal securityAttributes As IntPtr, _
            ByVal creationDisposition As UInteger, _
            ByVal flags As UInteger, _
            ByVal templateHandle As IntPtr) _
                As SafeFileHandle
        End Function

        ''' <summary>
        ''' Open a file for reading using the Win32
        ''' </summary>
        ''' <param name="fileName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function OpenFileForReading( _
            ByVal fileName As String) _
                As SafeFileHandle
            Const FILE_SHARE_READ As UInteger = &H1
            Const OPEN_EXISTING As UInteger = 3

            'call the Win32 API
            'Dim fileHandle As IntPtr = CreateFile( _
            Dim fileHandle As SafeFileHandle = CreateFile( _
                fileName, 0, FILE_SHARE_READ, IntPtr.Zero, _
                OPEN_EXISTING, 0, IntPtr.Zero)
            If fileHandle.IsInvalid() Then
                Dim lastErrorCode As Integer _
                    = Marshal.GetLastWin32Error()
                Throw New Win32Exception(lastErrorCode)
            Else
                Return fileHandle
            End If
        End Function

    End Class

    <DllImport("kernel32.DLL", SetLastError:=True)> _
    Public Function GetFileSize( _
        ByVal fileHandle As SafeFileHandle, _
        ByVal fileSizeHigh As IntPtr) As Integer
    End Function

    Sub Main()

        'create a test file in managed code so we
        'can open and use it in unmanaged.
        Using writer As StreamWriter _
            = New StreamWriter("testfile.txt")
            writer.WriteLine("this is a test line")
        End Using

        '
        'open a file using the unmanaged CreateFile function
        'and then use the handle to call GetFileSize		
        '
        Dim helper As CreateFileHelper _
            = New CreateFileHelper()
        Using fileHandle As SafeFileHandle _
            = helper.OpenFileForReading("testfile.txt")
            'use the file handle to call the GetFileSize function
            Console.WriteLine("GetFileSize: {0}", _
                GetFileSize(fileHandle, IntPtr.Zero))
        End Using

        '
        'open the file using managed code, then pass the
        'SafeFileHandle from the FileStream to the 
        'unmanaged GetFileSize API 
        '
        Using fileStream As FileStream _
            = New FileStream("testfile.txt", FileMode.Open)
            Console.WriteLine("GetFileSize: {0}", _
                GetFileSize( _
                    fileStream.SafeFileHandle, IntPtr.Zero))
            fileStream.Close()
        End Using

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
