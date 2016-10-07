Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Threading

Module Win32ConstantsTestVB

    Class CreateFileHelperVB
        'declare emums
        <Flags()> _
        Public Enum FileShareMode As UInteger
            FILE_SHARE_READ = &H1
            FILE_SHARE_WRITE = &H2
            FILE_SHARE_DELETE = &H4
        End Enum

        <Flags()> _
        Public Enum FileAttribute As UInteger
            FILE_ATTRIBUTE_READONLY = &H1
            FILE_ATTRIBUTE_HIDDEN = &H2
            FILE_ATTRIBUTE_SYSTEM = &H4
            FILE_ATTRIBUTE_DIRECTORY = &H10
            FILE_ATTRIBUTE_ARCHIVE = &H20
            FILE_ATTRIBUTE_DEVICE = &H40
            FILE_ATTRIBUTE_NORMAL = &H80
            FILE_ATTRIBUTE_TEMPORARY = &H100
            FILE_ATTRIBUTE_SPARSE_FILE = &H200
            FILE_ATTRIBUTE_REPARSE_POINT = &H400
            FILE_ATTRIBUTE_COMPRESSED = &H800
            FILE_ATTRIBUTE_OFFLINE = &H1000
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = &H2000
            FILE_ATTRIBUTE_ENCRYPTED = &H4000
        End Enum

        Public Enum CreationDisposition As UInteger
            CREATE_NEW = 1
            CREATE_ALWAYS = 2
            OPEN_EXISTING = 3
            OPEN_ALWAYS = 4
            TRUNCATE_EXISTING = 5
        End Enum

        Const INVALID_HANDLE_VALUE As Integer = -1

        'declare CreateFile API function
        <DllImport("kernel32.DLL", SetLastError:=True)> _
        Shared Function CreateFile( _
            ByVal fileName As String, _
            ByVal desiredAccess As Integer, _
            ByVal shareMode As FileShareMode, _
            ByVal securityAttributes As IntPtr, _
            ByVal creationDisposition As CreationDisposition, _
            ByVal flags As FileAttribute, _
            ByVal templateHandle As IntPtr) As IntPtr
        End Function

        <DllImport("kernel32.DLL", SetLastError:=True)> _
        Shared Sub CloseHandle(ByVal handle As IntPtr)
        End Sub

        'Call the CreateFile API function
        Public Shared Function CreateFile(ByVal fileName As String, _
                ByVal shareMode As FileShareMode, _
                ByVal attributes As FileAttribute, _
                ByVal disposition As CreationDisposition) _
                As Boolean

            'validate FileShareMode
            Dim sumFileShare As UInteger = 0
            For Each value As UInteger _
                In System.Enum.GetValues(GetType(FileShareMode))
                sumFileShare += value
            Next value
            If Not (shareMode And sumFileShare) = shareMode Then
                Throw New ArgumentException("Invalid FileShareMode")
            End If

            'validate CreationDisposition
            If Not System.Enum.IsDefined( _
                GetType(CreationDisposition), disposition) Then
                Throw New ArgumentException( _
                    "Invalid CreationDisposition")
            End If

            'validate FileAttribute
            Dim sumFileAttribute As UInteger = 0
            For Each value As UInteger _
                In System.Enum.GetValues(GetType(FileAttribute))
                sumFileAttribute += value
            Next value
            If Not (attributes And sumFileAttribute) = attributes Then
                Throw New ArgumentException("Invalid FileAttribute")
            End If

            Dim fileHandle As IntPtr
            'make the call
            fileHandle = CreateFile( _
                fileName, 0, shareMode, IntPtr.Zero, _
                disposition, attributes, IntPtr.Zero)

            'check the result
            If (fileHandle.ToInt32() = INVALID_HANDLE_VALUE) Then
                Dim lastErrorCode As Integer _
                    = Marshal.GetLastWin32Error()
                Throw New Win32Exception(lastErrorCode)
            Else
                CloseHandle(fileHandle)
            End If

        End Function

    End Class

    Sub Main()
        'make the call
        CreateFileHelperVB.CreateFile( _
            "TestCreateFileAPI.txt", _
            (CreateFileHelperVB.FileShareMode.FILE_SHARE_READ Or _
                CreateFileHelperVB.FileShareMode.FILE_SHARE_WRITE), _
            (CreateFileHelperVB.FileAttribute.FILE_ATTRIBUTE_ENCRYPTED Or _
                CreateFileHelperVB.FileAttribute.FILE_ATTRIBUTE_READONLY), _
            CreateFileHelperVB.CreationDisposition.OPEN_ALWAYS)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
