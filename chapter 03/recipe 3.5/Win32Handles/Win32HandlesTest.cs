using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Win32HandlesTest
{
    /// <summary>
    /// A wrapper for the CreateFile Win32 API
    /// </summary>
    class CreateFileHelper
    {
        [DllImport("kernel32.DLL", SetLastError=true)]
        private static extern SafeFileHandle CreateFile(
            string fileName,
            uint desiredAccess,
            uint shareMode,
            IntPtr securityAttributes,
            uint creationDisposition,
            uint flags,
            IntPtr templateHandle);

        /// <summary>
        /// Open a file for reading using the Win32
        /// CreateFile function
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static SafeFileHandle OpenFileForReading(
			string fileName)
        {
            const uint FILE_SHARE_READ = 0x00000001;
            const uint OPEN_EXISTING   = 3;
            
            //call the Win32 API
            SafeFileHandle fileHandle = CreateFile(
                fileName, 0, FILE_SHARE_READ, IntPtr.Zero, 
                OPEN_EXISTING, 0, IntPtr.Zero);
            if (fileHandle.IsInvalid)
            {
                int lastErrorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(lastErrorCode);
            }
            else
            {
                return fileHandle;
            }
        }
    }

	/// <summary>
	/// Demonstrate declaration and use of Win32 constants
	/// </summary>
	class Win32HandlesTest
	{
        [DllImport("kernel32.DLL", SetLastError=true)]
        private static extern int GetFileSize(
			SafeFileHandle fileHandle,
            IntPtr fileSizeHigh);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //create a test file in managed code so we
		    //can open and use it in unmanaged.
            using (StreamWriter writer = new StreamWriter("testfile.txt"))
            {
                writer.WriteLine("this is a test line");
            }

            //
            //open a file using the unmanaged CreateFile function
            //and then use the handle to call GetFileSize.
            //when the using block loses scope, the SafeFileHandle
            //is closed. this will free the handle to the
            //unmanaged resource (file).
            //
            using (SafeFileHandle fileHandle
                = CreateFileHelper.OpenFileForReading("testfile.txt"))
            {
                //use the file handle to call the GetFileSize function
                Console.WriteLine("GetFileSize: {0}",
                    GetFileSize(fileHandle, IntPtr.Zero));
            }

			//
			//open the file using managed code, then pass the
			//SafeFileHandle from the FileStream to the 
			//unmanaged GetFileSize API 
			//
            using (FileStream fileStream = new FileStream(
                "testfile.txt", FileMode.Open))
            {
                Console.WriteLine("GetFileSize: {0}",
                    GetFileSize(fileStream.SafeFileHandle, IntPtr.Zero));
            }

            //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
