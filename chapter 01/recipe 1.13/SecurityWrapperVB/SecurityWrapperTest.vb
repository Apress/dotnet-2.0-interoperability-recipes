Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions

Module SecurityWrapperTest

    ''' <summary>
    ''' Custom exception thrown by the FileProcessWrapper
    ''' </summary>
    ''' <remarks></remarks>
    Public Class FileProcessException
        Inherits ApplicationException
        Public Sub New(ByVal msg As String, _
            ByVal innerException As Exception)
            MyBase.New(msg, innerException)
        End Sub
    End Class

    ''' <summary>
    ''' Managed wrapper for the ProcessTestFile unmanaged function
    ''' </summary>
    ''' <remarks></remarks>
    Friend Class FileProcessWrapper
        <DllImport("FlatAPILib.DLL", CharSet:=CharSet.Ansi)> _
        Private Shared Function ProcessTestFile( _
            ByVal fullFilePath As String) _
                As IntPtr
        End Function

        <DllImport("FlatAPILib.DLL")> _
        Private Shared Sub FreeUnmanagedString(ByVal p As IntPtr)
        End Sub

        ''' <summary>
        ''' Invoke the unmanaged function
        ''' </summary>
        ''' <param name="filePath"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ProcessFile( _
            ByVal filePath As String) _
                As String

            'setup permissions that we need
            Dim pSet As PermissionSet _
                = New PermissionSet(PermissionState.None)
            'restrict IO to only a single known directory
            pSet.AddPermission(New FileIOPermission( _
                FileIOPermissionAccess.Read _
                Or FileIOPermissionAccess.PathDiscovery, _
                "c:\InteropTest"))
            'add permission to execute unmanaged code
            pSet.AddPermission(New SecurityPermission( _
                SecurityPermissionFlag.UnmanagedCode))
            'make these permissions exclusive, 
            'denying access to other directories
            pSet.PermitOnly()

            Dim result As String = String.Empty
            Dim stringPtr As IntPtr = IntPtr.Zero

            'file path validation
            If filePath = Nothing Then
                Throw New NullReferenceException( _
                "filePath is required")
            End If
            If filePath.Length = 0 Then
                Throw New FileProcessException( _
                "filePath length must be greater than 0", _
                Nothing)
            End If

            'get the directory name
            Dim dirName As String _
                = Path.GetDirectoryName(filePath)
            'validate the directory
            If dirName.Length > 0 Then
                If Not Directory.Exists(dirName) Then
                    Throw New FileProcessException( _
                        String.Format( _
                        "Directory {0} does not exist", _
                        dirName), Nothing)
                End If
            End If

            'validate the file
            If Not File.Exists(filePath) Then
                Throw New FileProcessException( _
                    String.Format( _
                    "File {0} does not exist", filePath), _
                    Nothing)
            End If

            Try
                'call the unmanaged function
                stringPtr = ProcessTestFile(filePath)
                If Not stringPtr = IntPtr.Zero Then
                    'marshal the returned pointer to a string
                    result = Marshal.PtrToStringAnsi(stringPtr)
                End If
            Finally
                If Not stringPtr = IntPtr.Zero Then
                    'free the memory from unmanaged code
                    FreeUnmanagedString(stringPtr)
                End If
            End Try

            Return result
        End Function
    End Class

    Sub Main()
        'save the test file to be read later
        Dim dirInfo As DirectoryInfo _
            = New DirectoryInfo("c:\InteropTest")
        If Not dirInfo.Exists Then
            dirInfo.Create()
        End If

        Dim writer As StreamWriter = New StreamWriter( _
            "c:\InteropTest\SecurityWrapperTestFile.txt")
        writer.WriteLine( _
            "The Contents of SecurityWrapperTestFile.txt")
        writer.Flush()
        writer.Close()

        Dim result As String

        'call the wrapper 
        Try
            result = FileProcessWrapper.ProcessFile( _
                "c:\InteropTest\SecurityWrapperTestFile.txt")
            Console.WriteLine( _
                "Result from ProcessFile = {0}", result)
        Catch ex As FileProcessException
            Console.WriteLine( _
                "Exception from ProcessFile = {0}", ex.Message)
        End Try

        'cleanup the test file when we are done
        Dim fileInfo As FileInfo = New FileInfo( _
            "c:\InteropTest\SecurityWrapperTestFile.txt")
        If fileInfo.Exists Then
            fileInfo.Delete()
        End If
        If dirInfo.Exists Then
            dirInfo.Delete()
        End If

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
