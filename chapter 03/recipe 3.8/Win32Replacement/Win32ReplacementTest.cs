using System;
using System.Runtime.InteropServices;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace Win32ReplacementTest
{
    #region Win32IOExample

    /// <summary>
    /// Execute file IO routines using Win32 functions
    /// </summary>
    public class Win32IOExample
    {
        //
        //Win32 function declarations
        //
        [DllImport("kernel32.DLL", SetLastError=true, 
            CharSet=CharSet.Unicode)]
        private static extern int GetCurrentDirectory(
            int bufferLen, StringBuilder buffer);
        
        [DllImport("kernel32.DLL", SetLastError=true, 
            CharSet=CharSet.Unicode)]
        private static extern bool CreateDirectory(
            string dirName, IntPtr securityAttrs);

        [DllImport("kernel32.DLL", SetLastError=true, 
            CharSet=CharSet.Unicode)]
		private static extern bool RemoveDirectory(
            string dirName);
            
        [DllImport("kernel32.DLL", SetLastError=true, 
             CharSet=CharSet.Unicode)]
		private static extern bool DeleteFile(
            string fileName);

        [DllImport("kernel32.DLL", SetLastError=true,
            CharSet=CharSet.Unicode)]
        private static extern IntPtr CreateFile(
            string fileName,
            uint desiredAccess,
            uint shareMode,
            IntPtr securityAttributes,
            uint creationDisposition,
            uint flags,
            IntPtr templateHandle);

        [DllImport("kernel32.DLL", SetLastError=true, 
             CharSet=CharSet.Unicode)]
		private static extern bool WriteFile(
            IntPtr handle,
            byte[] buffer,
            uint bytesToWrite,
            ref uint bytesWritten,
            IntPtr pOverlapped);

        [DllImport("kernel32.DLL", SetLastError=true)]
        private static extern int GetFileSize(IntPtr fileHandle,
            IntPtr fileSizeHigh);

        [DllImport("kernel32.DLL", SetLastError=true, 
             CharSet=CharSet.Unicode)]
		private static extern bool CopyFile(
            string existingFile, string newFile, bool exists);

		[DllImport("kernel32.DLL", SetLastError = true)]
		private static extern void CloseHandle(IntPtr handle);
            
        public void ProcessFile()
        {
            //define constants needed by the Win32 functions
            const int  INVALID_HANDLE_VALUE = -1;
            const uint FILE_SHARE_READ  = 0x00000001;
            const uint FILE_SHARE_WRITE = 0x00000002;
            const uint CREATE_ALWAYS   = 2;
            const uint OPEN_EXISTING   = 3;
            const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
            const uint GENERIC_WRITE   = 0x40000000;

            //get the current directory
            StringBuilder currDir   = new StringBuilder(255);
            int charsWritten 
                = GetCurrentDirectory(currDir.Capacity, currDir);
            if (charsWritten == 0)
            {
                CheckLastResult();
            }
        
            //create a new subdirectory under the current one
            String newDir = 
				Path.Combine(currDir.ToString(), "MyTestDir");
            if (!CreateDirectory(newDir, IntPtr.Zero))
            {
                CheckLastResult();
            }
            
            //declare file handles that we will use
			IntPtr fileHandle = IntPtr.Zero;
			IntPtr copiedFileHandle = IntPtr.Zero;

			//open a file for writing
			try
			{
				String fileName
					= Path.Combine(newDir, "MyTestFile.txt");
				fileHandle = CreateFile(
					fileName, GENERIC_WRITE,
					FILE_SHARE_READ | FILE_SHARE_WRITE,
					IntPtr.Zero, CREATE_ALWAYS,
					FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
				//check for invalid handle to see if this worked
				if (fileHandle.ToInt32() == INVALID_HANDLE_VALUE)
				{
					CheckLastResult();
				}

				//write data to the file
				//Note:  Unicode files can be distinguished by the presence 
				//of the byte order mark (U+FEFF), which is represented 
				//as hexadecimal 0xFF 0xFE on little-endian platforms.
				//we need to manually add these first two bytes to the
				//file since Win32 doesn't do it for us.
				String testData   = "this is the file test data";
				int bytesNeeded   
					= Encoding.Unicode.GetByteCount(testData) + 2;
				byte[] testBytes  = new byte[bytesNeeded];
				Encoding.Unicode.GetBytes(
					testData, 0, testData.Length, testBytes, 2);
				//add the byte order mark as the first two bytes
				testBytes[0]      = 0xFF;
				testBytes[1]      = 0xFE;
				//now write the byte array
				uint bytesWritten = 0;
				if (!WriteFile(fileHandle, testBytes, 
					(uint)(testBytes.Length), 
					ref bytesWritten, IntPtr.Zero))
				{
					CheckLastResult();
				}
				Console.WriteLine(
					"Win32 Bytes written: {0}", bytesWritten);
	            
				//get the total file size
				int fileSize = GetFileSize(fileHandle, IntPtr.Zero);
				if (fileSize == 0)
				{
					CheckLastResult();
				}
				Console.WriteLine("Win32 File size: {0}", fileSize);
	            
				//close the file handle
				CloseHandle(fileHandle);
				fileHandle = IntPtr.Zero;

				//copy the file
				String copiedFileName 
					= Path.Combine(newDir,"MyCopiedFile.txt");
				if (!CopyFile(fileName, copiedFileName, false))
				{
					CheckLastResult();
				}

				//check the file size of the newly copied file
				copiedFileHandle = CreateFile(
					fileName, 0, FILE_SHARE_READ, 
					IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
				if (copiedFileHandle.ToInt32() == INVALID_HANDLE_VALUE)
				{
					CheckLastResult();
				}
				//use the new file handle to get the file size
				int copiedFileSize = GetFileSize(
					copiedFileHandle, IntPtr.Zero);
				if (copiedFileSize == 0)
				{
					CheckLastResult();
				}
				Console.WriteLine(
					"Win32 Copied File size: {0}", copiedFileSize);
	            
				//close the copied file handle
				CloseHandle(copiedFileHandle);
				copiedFileHandle = IntPtr.Zero;
	            
				//delete the original file
				if (!DeleteFile(fileName))
				{
					CheckLastResult();
				}
	            
				//delete the copied file
				if (!DeleteFile(copiedFileName))
				{
					CheckLastResult();
				}

				//delete the directory
				if (!RemoveDirectory(newDir))
				{
					CheckLastResult();
				}
			}
			finally
			{
				//make sure all handles that we might have
				//opened are now closed
				if (fileHandle != IntPtr.Zero)
				{
					CloseHandle(fileHandle);
				}
				if (copiedFileHandle != IntPtr.Zero)
				{
					CloseHandle(copiedFileHandle);
				}
			}
        }
        
        /// <summary>
        /// Check the last Win32 error
        /// </summary>
        private void CheckLastResult()
        {
            int  lastResult = Marshal.GetLastWin32Error();
            //if we have a problem, throw an exception
            if (lastResult != 0)
            {
                throw new Win32Exception(lastResult);
            }
        }
    }

    #endregion

    #region .NetExample

    /// <summary>
    /// Execute file IO routines using .NET only
    /// </summary>
    public class DotNetIOExample
    {
        public void ProcessFile()
        {
            //get the current directory
            String currDir          = Environment.CurrentDirectory;
            
            //create a new subdirectory under the current one
            DirectoryInfo currDirInfo 
                = new DirectoryInfo(currDir);
            currDirInfo.CreateSubdirectory("MyTestDir");
            String newDir = Path.Combine(currDir, "MyTestDir"); 
            
            //open a file for writing
            //write data to the file
            String fileName     
				= Path.Combine(newDir, "MyTestFile.txt"); 
            //create a StreamWriter that uses full Unicode encoding
            using (StreamWriter writer
                = new StreamWriter(fileName, false, Encoding.Unicode))
            {
                writer.NewLine = String.Empty;
                writer.Write("this is the file test data");
                writer.Flush(); //force a write immediately
                long bytesWritten = writer.BaseStream.Length;
                Console.WriteLine(".NET Bytes written: {0}", bytesWritten);
            }
            
            //get the total file size
            FileInfo fileInfo   = new FileInfo(fileName);
            long fileSize        = fileInfo.Length;
            Console.WriteLine(".NET File size: {0}", fileSize);

            //copy the file
            String copiedFileName 
				= Path.Combine(newDir, "MyCopiedFile.txt");
            fileInfo.CopyTo(copiedFileName, true);

            //check the file size of the newly copied file
            fileInfo            = new FileInfo(copiedFileName);
            long copiedFileSize  = fileInfo.Length;
            Console.WriteLine(
                ".NET Copied File size: {0}", copiedFileSize);

            //delete the original file
            File.Delete(fileName);
            
            //delete the copied file
            File.Delete(copiedFileName);

            //delete the directory
            Directory.Delete(newDir);
        }
    }

    #endregion

	/// <summary>
	/// Control the Win32 API version used during a call, either A 
	/// for Ansi or W for (wide) Unicode
	/// </summary>
	class Win32ReplacementTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            Win32IOExample win32 = new Win32IOExample();
            win32.ProcessFile();

            DotNetIOExample dotNet = new DotNetIOExample ();
            dotNet.ProcessFile();
    		
     	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
