using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Win32ConstantsTest
{
    class DriveInfo
    {
        //Get Drive Type
        [DllImport("kernel32.DLL")]
        private static extern uint GetDriveType(string rootPath);
            
        /* definitions from WinBase.h
                DRIVE_UNKNOWN     0
                DRIVE_NO_ROOT_DIR 1
                DRIVE_REMOVABLE   2
                DRIVE_FIXED       3
                DRIVE_REMOTE      4
                DRIVE_CDROM       5
                DRIVE_RAMDISK     6
        */
        
        private const uint DRIVE_UNKNOWN     = 0;
        private const uint DRIVE_NO_ROOT_DIR = 1;
        private const uint DRIVE_REMOVABLE   = 2;
        private const uint DRIVE_FIXED       = 3;
        private const uint DRIVE_REMOTE      = 4;
        private const uint DRIVE_CDROM       = 5;
        private const uint DRIVE_RAMDISK     = 6;

        public static string GetDriveTypeDescription(string rootPath)
        {
            string result           = "unknown";
            //call the Win32 api to get the type code
            uint driveType          = GetDriveType(rootPath);
            //turn the type code into a description
            switch(driveType)
            {
                case DRIVE_UNKNOWN:
                    result          = "Unknown";
                    break;
                case DRIVE_NO_ROOT_DIR:
                    result          = "No root dir";
                    break;
                case DRIVE_REMOVABLE:
                    result          = "Removable";
                    break;
                case DRIVE_FIXED:
                    result          = "Fixed";
                    break;
                case DRIVE_REMOTE:
                    result          = "Remote";
                    break;
                case DRIVE_CDROM:
                    result          = "CDRom";
                    break;
                case DRIVE_RAMDISK:
                    result          = "RamDisk";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
    
    class DriveInfoEnum
    {
        //Get Drive Type
        [DllImport("kernel32.DLL")]
        private static extern uint GetDriveType(string rootPath);
            
        /* definitions from WinBase.h
                DRIVE_UNKNOWN     0
                DRIVE_NO_ROOT_DIR 1
                DRIVE_REMOVABLE   2
                DRIVE_FIXED       3
                DRIVE_REMOTE      4
                DRIVE_CDROM       5
                DRIVE_RAMDISK     6
        */
        
        private enum DriveType : uint
        {
            Unknown             = 0,
            NoRootDir           = 1,
            Removable           = 2,
            Fixed               = 3,
            Remote              = 4,
            CDRom               = 5,
            RamDisk             = 6
        }

        public static string GetDriveTypeDescription(string rootPath)
        {
            string result           = "unknown";
            //call the Win32 api to get the type code
            uint driveType          = GetDriveType(rootPath);
            //turn the type code into a description
            if (Enum.IsDefined(typeof(DriveType), driveType))
            {
                result  = ((DriveType)driveType).ToString();
            }
            return result;
        }
    }
    
    /// <summary>
    /// A wrapper for the CreateFile Win32 API
    /// </summary>
    class CreateFileHelper
    {
        /* from WinNT.h    
        #define FILE_SHARE_READ                     0x00000001  
        #define FILE_SHARE_WRITE                    0x00000002  
        #define FILE_SHARE_DELETE                   0x00000004  
        */
        [Flags]
        public enum FileShareMode : uint
        {
            FILE_SHARE_READ                    = 0x00000001,  
            FILE_SHARE_WRITE                   = 0x00000002,  
            FILE_SHARE_DELETE                  = 0x00000004  
        }
        
        /* from WinNT.h    
        #define FILE_ATTRIBUTE_READONLY             0x00000001  
        #define FILE_ATTRIBUTE_HIDDEN               0x00000002  
        #define FILE_ATTRIBUTE_SYSTEM               0x00000004  
        #define FILE_ATTRIBUTE_DIRECTORY            0x00000010  
        #define FILE_ATTRIBUTE_ARCHIVE              0x00000020  
        #define FILE_ATTRIBUTE_DEVICE               0x00000040  
        #define FILE_ATTRIBUTE_NORMAL               0x00000080  
        #define FILE_ATTRIBUTE_TEMPORARY            0x00000100  
        #define FILE_ATTRIBUTE_SPARSE_FILE          0x00000200  
        #define FILE_ATTRIBUTE_REPARSE_POINT        0x00000400  
        #define FILE_ATTRIBUTE_COMPRESSED           0x00000800  
        #define FILE_ATTRIBUTE_OFFLINE              0x00001000  
        #define FILE_ATTRIBUTE_NOT_CONTENT_INDEXED  0x00002000  
        #define FILE_ATTRIBUTE_ENCRYPTED            0x00004000  
        */
        [Flags]
        public enum FileAttribute : uint
        {
            FILE_ATTRIBUTE_READONLY             = 0x00000001,  
            FILE_ATTRIBUTE_HIDDEN               = 0x00000002, 
            FILE_ATTRIBUTE_SYSTEM               = 0x00000004,
            FILE_ATTRIBUTE_DIRECTORY            = 0x00000010, 
            FILE_ATTRIBUTE_ARCHIVE              = 0x00000020,
            FILE_ATTRIBUTE_DEVICE               = 0x00000040, 
            FILE_ATTRIBUTE_NORMAL               = 0x00000080, 
            FILE_ATTRIBUTE_TEMPORARY            = 0x00000100, 
            FILE_ATTRIBUTE_SPARSE_FILE          = 0x00000200, 
            FILE_ATTRIBUTE_REPARSE_POINT        = 0x00000400, 
            FILE_ATTRIBUTE_COMPRESSED           = 0x00000800, 
            FILE_ATTRIBUTE_OFFLINE              = 0x00001000, 
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED  = 0x00002000, 
            FILE_ATTRIBUTE_ENCRYPTED            = 0x00004000  
        }

        /* from WinBase.h
        #define CREATE_NEW          1
        #define CREATE_ALWAYS       2
        #define OPEN_EXISTING       3
        #define OPEN_ALWAYS         4
        #define TRUNCATE_EXISTING   5
        */
        public enum CreationDisposition : uint
        {
            CREATE_NEW          = 1,
            CREATE_ALWAYS       = 2,
            OPEN_EXISTING       = 3,
            OPEN_ALWAYS         = 4,
            TRUNCATE_EXISTING   = 5
        }

        private const int INVALID_HANDLE_VALUE = -1;

        [DllImport("kernel32.DLL", SetLastError=true)]
            private static extern IntPtr CreateFile(
            string fileName,
            uint desiredAccess,
			FileShareMode shareMode,
            IntPtr securityAttributes,
			CreationDisposition creationDisposition,
			FileAttribute flags,
            IntPtr templateHandle);

		[DllImport("kernel32.DLL", SetLastError = true)]
        private static extern void CloseHandle(IntPtr handle);

        public static bool CreateFile(
			string fileName, FileShareMode shareMode,
            FileAttribute attributes, CreationDisposition disposition)
        {
            //validate FileShareMode
            uint sumFileShare = 0;
            foreach(uint value in 
                Enum.GetValues(typeof(FileShareMode)))
            {
                sumFileShare += value;
            }
            if (((uint)shareMode & sumFileShare) != (uint)shareMode)
            {
                throw new ArgumentException("Invalid FileShareMode");
            }

            //validate CreationDisposition
            if (!Enum.IsDefined(typeof(CreationDisposition),
                disposition))
            {
                throw new ArgumentException(
                    "Invalid CreationDisposition");
            }

            //validate FileAttribute
            uint sumFileAttribute = 0;
            foreach (uint value in 
                Enum.GetValues(typeof(FileAttribute)))
            {
                sumFileAttribute += value;
            }
            if (((uint)attributes & sumFileAttribute) 
                != (uint)attributes)
            {
                throw new ArgumentException("Invalid FileAttribute");
            }
            
            IntPtr fileHandle = CreateFile(
                fileName, 0, shareMode, IntPtr.Zero, 
                disposition, attributes, IntPtr.Zero);
            if (fileHandle.ToInt32() == INVALID_HANDLE_VALUE)
            {
                int lastErrorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(lastErrorCode);
            }
            else
            {
                CloseHandle(fileHandle);            
                return true;
            }
        }

    }

	/// <summary>
	/// Demonstrate declaration and use of Win32 constants
	/// </summary>
	class Win32ConstantsTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            string driveTypeDesc = DriveInfo.GetDriveTypeDescription(@"c:\");
            Console.WriteLine(@"GetDriveType for C: {0}", driveTypeDesc);
            driveTypeDesc = DriveInfo.GetDriveTypeDescription(@"D:\");
            Console.WriteLine(@"GetDriveType for D: {0}", driveTypeDesc);

            driveTypeDesc = DriveInfoEnum.GetDriveTypeDescription(@"c:\");
            Console.WriteLine(@"GetDriveType Enum for C: {0}", driveTypeDesc);
            driveTypeDesc = DriveInfoEnum.GetDriveTypeDescription(@"D:\");
            Console.WriteLine(@"GetDriveType Enum for D: {0}", driveTypeDesc);

            CreateFileHelper.CreateFile(
                @"TestCreateFileAPI.txt", 
                (CreateFileHelper.FileShareMode.FILE_SHARE_READ |
                    CreateFileHelper.FileShareMode.FILE_SHARE_WRITE),
                (CreateFileHelper.FileAttribute.FILE_ATTRIBUTE_ENCRYPTED |  
                    CreateFileHelper.FileAttribute.FILE_ATTRIBUTE_READONLY),
                CreateFileHelper.CreationDisposition.OPEN_ALWAYS);
		
     	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
