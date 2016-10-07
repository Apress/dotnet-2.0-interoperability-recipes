Imports System.Runtime.InteropServices
Imports System.Text
Imports System.ComponentModel
Imports System.IO

''' <summary>
''' Uses the Unicode version of GetComputerName
''' </summary>
''' <remarks></remarks>
Public Class GetComputerNameUnicode
    <DllImport("kernel32.DLL", _
        CharSet:=CharSet.Unicode, ExactSpelling:=False)> _
    Public Shared Function GetComputerName( _
        ByVal computerName As StringBuilder, _
        ByRef size As Integer) As Boolean
    End Function

    Public Shared Sub Test()
        Dim buf As StringBuilder = New StringBuilder(255)
        Dim size As Integer = buf.Capacity
        GetComputerName(buf, size)
        Console.WriteLine("GetComputerNameUnicode: {0}, {1}", _
            buf.ToString(), size)
    End Sub
End Class

''' <summary>
''' Uses the Unicode version of CreateDirectory
''' </summary>
''' <remarks></remarks>
Public Class CreateDirectoryUnicode
    <DllImport("kernel32.DLL", _
        CharSet:=CharSet.Unicode, ExactSpelling:=False)> _
    Public Shared Function CreateDirectory( _
        ByVal dirName As String, ByVal securityAttrs As IntPtr) _
        As Boolean
    End Function

    Public Shared Sub Test()
        Dim result As Boolean _
            = CreateDirectory("C:\MyTestDirectory", IntPtr.Zero)
        Console.WriteLine("CreateDirectoryUnicode: {0}", result)
        Cleanup()

    End Sub

    Private Shared Sub Cleanup()
        Dim dir As DirectoryInfo _
            = New DirectoryInfo("C:\MyTestDirectory")
        If dir.Exists Then
            Console.WriteLine("Directory {0} exists", dir.FullName)
            dir.Delete()
        End If

    End Sub

End Class

Module Win32CharacterSetTest

    Sub Main()

        GetComputerNameUnicode.Test()
        CreateDirectoryUnicode.Test()

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()

    End Sub

End Module
