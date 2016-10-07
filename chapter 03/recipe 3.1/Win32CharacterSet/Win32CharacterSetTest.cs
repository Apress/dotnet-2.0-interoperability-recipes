using System;
using System.Runtime.InteropServices;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace Win32CharacterSetTest
{
	/// <summary>
	/// Control the Win32 API version used during a call, either A 
	/// for Ansi or W for (wide) Unicode
	/// </summary>
	class Win32CharacterSetTest
	{
        #region GetComputerName

        public class GetComputerNameDefault
        {
            [DllImport("kernel32.DLL")]
            public static extern bool GetComputerName(
                StringBuilder computerName, ref int size);

            public static void Test()
            {
                StringBuilder buf   = new StringBuilder(255);
                int size            = buf.Capacity;
                GetComputerName(buf, ref size);		
                Console.WriteLine("GetComputerNameDefault: {0}, {1}",
                    buf.ToString(), size);
            }
        }

        public class GetComputerNameUnicode
        {
            [DllImport("kernel32.DLL", CharSet=CharSet.Unicode)]
            public static extern bool GetComputerName(
                StringBuilder computerName, ref int size);

            public static void Test()
            {
                StringBuilder buf   = new StringBuilder(255);
                int size            = buf.Capacity;
                GetComputerName(buf, ref size);		
                Console.WriteLine("GetComputerNameUnicode: {0}, {1}",
                    buf.ToString(), size);
            }
        }
        
        public class GetComputerNameAnsi
        {
            [DllImport("kernel32.DLL", CharSet=CharSet.Ansi)]
            public static extern bool GetComputerName(
                StringBuilder computerName, ref int size);

            public static void Test()
            {
                StringBuilder buf   = new StringBuilder(255);
                int size            = buf.Capacity;
                GetComputerName(buf, ref size);		
                Console.WriteLine("GetComputerNameAnsi: {0}, {1}",
                    buf.ToString(), size);
            }
        }

        public class GetComputerNameMismatch
        {
            //this is an incorrect function declaration since
            //we specify the unicode version yet marshal
            //the strings as Ansi
            [DllImport("kernel32.DLL", 
                EntryPoint="GetComputerNameW", CharSet=CharSet.Ansi)]
            public static extern bool GetComputerName(
                StringBuilder computerName, ref int size);

            public static void Test()
            {
                StringBuilder buf   = new StringBuilder(255);
                int size            = buf.Capacity;
                GetComputerName(buf, ref size);		
                Console.WriteLine("GetComputerNameMismatch: {0}, {1}",
                    buf.ToString(), size);
            }
        }

        public class GetComputerNameUnicodeByEntryPoint
        {
            [DllImport("kernel32.DLL", 
                EntryPoint="GetComputerNameW", CharSet=CharSet.Unicode)]
            public static extern bool GetComputerName(
                StringBuilder computerName, ref int size);

            public static void Test()
            {
                StringBuilder buf   = new StringBuilder(255);
                int size            = buf.Capacity;
                GetComputerName(buf, ref size);		
                Console.WriteLine("GetComputerNameUnicodeByEntryPoint: {0}, {1}",
                    buf.ToString(), size);
            }
        }

        public class GetComputerNameAuto
        {
            //defaults to Unicode for NT, XP, 2000 and 2003, 
            //ANSI for 95 and ME
            [DllImport("kernel32.DLL", 
                 CharSet=CharSet.Auto)]
            public static extern bool GetComputerName(
                StringBuilder computerName, ref int size);

            public static void Test()
            {
                StringBuilder buf   = new StringBuilder(255);
                int size            = buf.Capacity;
                GetComputerName(buf, ref size);		
                Console.WriteLine("GetComputerNameAuto: {0}, {1}",
                    buf.ToString(), size);
            }
        }

        #endregion

        #region CreateDirectory

        public class BaseCreateDirectory
        {
            public static void Cleanup()
            {
                DirectoryInfo dir = new DirectoryInfo(@"C:\MyTestDirectory");
                if (dir.Exists)
                {
                    Console.WriteLine("Directory {0} exists", dir.FullName);
                    dir.Delete();
                }
            }
        }

        public class CreateDirectoryDefault : BaseCreateDirectory
        {
            [DllImport("kernel32.DLL")]
            public static extern bool CreateDirectory(
                string dirName, IntPtr securityAttrs);

            public static void Test()
            {
                //create a directory
                bool result = CreateDirectory(@"C:\MyTestDirectory", IntPtr.Zero);
                Console.WriteLine("CreateDirectoryDefault: {0}", result);
                //delete the directory now that we're done 
                Cleanup();
            }
        }

        public class CreateDirectoryUnicode : BaseCreateDirectory
        {
            [DllImport("kernel32.DLL", CharSet=CharSet.Unicode)]
            public static extern bool CreateDirectory(
                string dirName, IntPtr securityAttrs);

            public static void Test()
            {
                bool result = CreateDirectory(@"C:\MyTestDirectory", IntPtr.Zero);
                Console.WriteLine("CreateDirectoryUnicode: {0}", result);
                Cleanup();
            }
        }
        
        #endregion
        
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            GetComputerNameDefault.Test();
            GetComputerNameUnicode.Test();
            GetComputerNameAnsi.Test();
            GetComputerNameMismatch.Test();
            GetComputerNameUnicodeByEntryPoint.Test();
            GetComputerNameAuto.Test();
            
            CreateDirectoryDefault.Test();
            CreateDirectoryUnicode.Test();
		
     	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
