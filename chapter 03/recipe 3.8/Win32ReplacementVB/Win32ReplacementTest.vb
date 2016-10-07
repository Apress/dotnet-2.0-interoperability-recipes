Imports System
Imports System.Text
Imports System.IO

Module Win32ReplacementTest

    ''' <summary>
    ''' Execute file IO routines using .NET only
    ''' </summary>
    ''' <remarks></remarks>
    Private Class DotNetIOExample
        Public Sub ProcessFile()
            'get the current directory
            Dim currDir As String _
                = Environment.CurrentDirectory
            'create a new subdirectory under the current one
            Dim currDirInfo As DirectoryInfo _
                = New DirectoryInfo(currDir)
            currDirInfo.CreateSubdirectory("MyTestDir")
            Dim newDir As String _
                = Path.Combine(currDir, "MyTestDir")

            'open a file for writing
            'write data to the file
            Dim fileName As String _
                = Path.Combine(newDir, "MyTestFile.txt")
            'create a StreamWriter that uses full Unicode encoding
            Using writer As StreamWriter = New StreamWriter( _
                fileName, False, Encoding.Unicode)
                writer.NewLine = String.Empty
                writer.Write("this is the file test data")
                writer.Flush() 'force everything to be written
                Dim bytesWritten As Long = writer.BaseStream.Length
                writer.Close()
                Console.WriteLine( _
                    ".NET Bytes written: {0}", bytesWritten)
            End Using

            'get the total file size
            Dim fileInfo As FileInfo = New FileInfo(fileName)
            Dim fileSize As Long = fileInfo.Length
            Console.WriteLine(".NET File size: {0}", fileSize)

            'copy the file
            Dim copiedFileName As String _
                = Path.Combine(newDir, "MyCopiedFile.txt")
            fileInfo.CopyTo(copiedFileName, True)

            'check the file size of the newly copied file
            fileInfo = New FileInfo(copiedFileName)
            Dim copiedFileSize As Long = fileInfo.Length
            Console.WriteLine( _
                ".NET Copied File size: {0}", copiedFileSize)

            'delete the original file
            File.Delete(fileName)

            'delete the copied file
            File.Delete(copiedFileName)

            'delete the directory
            Directory.Delete(newDir)

        End Sub
    End Class

    Sub Main()
        Dim dotNet As DotNetIOExample = New DotNetIOExample()
        dotNet.ProcessFile()

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
