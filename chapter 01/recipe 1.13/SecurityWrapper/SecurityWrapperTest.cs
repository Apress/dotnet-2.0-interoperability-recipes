using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace SecurityWrapperTest
{
    /// <summary>
    /// Custom exception thrown by the FileProcessWrapper
    /// </summary>
    public class FileProcessException : ApplicationException
    {
        public FileProcessException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }
    }

    /// <summary>
    /// Managed wrapper for the ProcessTestFile unmanaged function
    /// </summary>
    internal class FileProcessWrapper
    {
        [DllImport("FlatAPILib.DLL", CharSet=CharSet.Ansi)]
        private static extern IntPtr ProcessTestFile(string fullFilePath);    

        [DllImport("FlatAPILib.DLL")]
        private static extern void FreeUnmanagedString(IntPtr p);    
        
        /// <summary>
        /// Invoke the unmanaged function
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ProcessFile(string filePath)
        {
            //setup permissions that we need
            PermissionSet pSet = new PermissionSet(PermissionState.None);
            //restrict IO to only a single known directory
            pSet.AddPermission(new FileIOPermission(
                FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery,
                @"c:\InteropTest"));
            //add permission to execute unmanaged code
            pSet.AddPermission(new SecurityPermission(
                SecurityPermissionFlag.UnmanagedCode));
            //make these permissions exclusive, denying access to other directories
            pSet.PermitOnly();            

            String result           = String.Empty;
            IntPtr stringPtr        = IntPtr.Zero;

			//file path validation
			if (filePath == null)
			{
				throw new NullReferenceException("filePath is required");
			}
			if (filePath.Length == 0)
			{
				throw new FileProcessException(
					"filePath length must be greater than 0", null);
			}

			//get the directory name
			string dirName = Path.GetDirectoryName(filePath);
			//validate the directory
			if (dirName.Length > 0)
			{
				if (!Directory.Exists(dirName))
				{
					throw new FileProcessException(
						String.Format("Directory {0} does not exist", dirName), null);
				}
			}

			//validate the file
			if (!File.Exists(filePath))
			{
				throw new FileProcessException(
					String.Format("File {0} does not exist", filePath), null);
			}
            
            try
            {       
                //call the unmanaged function
                stringPtr = ProcessTestFile(filePath);
                if (stringPtr != IntPtr.Zero)
                {
                    //marshal the returned pointer to a string
                    result = Marshal.PtrToStringAnsi(stringPtr);
                }
            }
            finally
            {
                if (stringPtr != IntPtr.Zero)
                {
                    //free the memory from unmanaged code
                    FreeUnmanagedString(stringPtr);
                }
            }
            
            return result;            
        }
    }

	/// <summary>
	/// Test a Security Wrapper for Unmanaged Code
	/// </summary>
	class SecurityWrapperTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //save the test file to be read later
		    DirectoryInfo dirInfo   = new DirectoryInfo(@"c:\InteropTest");
		    if (!dirInfo.Exists)
		    {
		        dirInfo.Create();
		    }
		    StreamWriter writer     = new StreamWriter(
		        @"c:\InteropTest\SecurityWrapperTestFile.txt");
            writer.WriteLine("The Contents of SecurityWrapperTestFile.txt");
            writer.Flush();
            writer.Close();
		
		    string result;
		    
            //call the wrapper 
            try
            {		    
                result = FileProcessWrapper.ProcessFile(
                    @"c:\InteropTest\SecurityWrapperTestFile.txt");
                Console.WriteLine("Result from ProcessFile = {0}", result);
            }
			catch (FileProcessException e)
            {
                Console.WriteLine("Exception from ProcessFile = {0}", e.Message);
            }

            //cleanup the test file when we are done
            FileInfo fileInfo       = new FileInfo(
                @"c:\InteropTest\SecurityWrapperTestFile.txt");
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            if (dirInfo.Exists)
            {
                dirInfo.Delete();
            }

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
