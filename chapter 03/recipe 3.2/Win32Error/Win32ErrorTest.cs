using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Win32ErrorTest
{
	/// <summary>
	/// Return the error code from a Win32 API call
	/// </summary>
	class Win32ErrorTest
	{
        //save the last error, and use the wide version
        [DllImport("kernel32.DLL", CharSet = CharSet.Unicode, 
			SetLastError = true)]
        public static extern 
            bool DeleteFile(string fileName);

		//do not save the last error
        [DllImport("kernel32.DLL", EntryPoint="DeleteFile", 
			CharSet=CharSet.Unicode)]
        public static extern 
            bool DeleteFileNoError(string fileName);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    try
		    {
                //attempt to delete a file that doesn't exist
                DeleteFile("TestFileNotThere");
                //returns system error code 2: ERROR_FILE_NOT_FOUND
                //"The system cannot find the file specified"
                int lastError = Marshal.GetLastWin32Error();
                Console.WriteLine("DeleteFile last error code: {0}", lastError);
                    
                //turn the win32 error into an exception
                throw new Win32Exception(lastError);
            }
            catch(Win32Exception e)
            {
                Console.WriteLine("DeleteFile last error message: {0}", e.Message);
            }
                
            //execute the same test, without the SetLastError property
			DeleteFileNoError("TestFileNotThere");
            Console.WriteLine("DeleteFileNoError last error code: {0}",
                Marshal.GetLastWin32Error());

            //test using the default constructor for Win32Exception.
            //if you don't pass an error code, it will make the call
            //to GetLastWin32Error for you.
            try
            {
                //attempt to delete a file that doesn't exist
                if (!DeleteFile("TestFileNotThere"))
                {
                    //turn the win32 error into an exception
                    throw new Win32Exception();
                }
            }
            catch (Win32Exception e)
            {
                Console.WriteLine("DeleteFile last error message: {0}", e.Message);
            }

            //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
