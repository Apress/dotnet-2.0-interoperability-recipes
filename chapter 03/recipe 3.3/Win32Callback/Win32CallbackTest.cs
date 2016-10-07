using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace Win32CallbackTest
{
    /// <summary>
    /// Wrapper class that demonstrates a mismatched characterset for unicode
    /// </summary>
    class UnicodeCallbackWrapperIncorrect
    {
        //constants used for date formats
        private const int DATE_SHORTDATE    = 0x00000001;  // use short date picture
        private const int DATE_LONGDATE     = 0x00000002;  // use long date picture
        private const int DATE_YEARMONTH    = 0x00000008;  // use year month picture
    
        //define the delegate for the callback using Unicode.
        //This delegate is incorrect for unicode since the default
        //marshaling for the string field will be ansi
        public delegate bool EnumDateFormatsProcEx(string dateFormat, int calId);
        
		[DllImport("kernel32.DLL", CharSet=CharSet.Unicode,
			SetLastError = true)]
        public static extern bool EnumDateFormatsEx(
            EnumDateFormatsProcEx callBackProc, int LCID, ulong flags);

        public static void Test()
        {
            Console.WriteLine("Test Mismatched character-sets for unicode");
        
            //call the Unicode version of the function 
            EnumDateFormatsEx(
                EnumDateFormatsCallback,
                Thread.CurrentThread.CurrentCulture.LCID,
                DATE_LONGDATE);
        }

        //callback method
        static public bool EnumDateFormatsCallback(string dateFormat, int calId)
        {
            Console.WriteLine("CalId: {0}, Date Format: {1}", calId, dateFormat);
            return true;
        }
    }

    /// <summary>
    /// Wrapper class that demonstrates a correct characterset for unicode
    /// </summary>
    class UnicodeCallbackWrapper
    {
        //constants used for date formats
        private const int DATE_SHORTDATE    = 0x00000001;  // use short date picture
        private const int DATE_LONGDATE     = 0x00000002;  // use long date picture
        private const int DATE_YEARMONTH    = 0x00000008;  // use year month picture
    
        //define the delegate for the callback using Unicode.
        //This delegate is correct for the Unicode
        //version of EnumDateFormatsEx.
        public delegate bool EnumDateFormatsProcEx(
            [MarshalAs(UnmanagedType.LPWStr)]string dateFormat, int calId);
        [DllImport("kernel32.DLL", CharSet=CharSet.Unicode,
			SetLastError = true)]
        public static extern bool EnumDateFormatsEx(
            EnumDateFormatsProcEx callBackProc, int LCID, ulong flags);

        public static void Test()
        {
            Console.WriteLine("Test Correct character-sets for unicode");
        
            //call the Unicode version of the function 
            EnumDateFormatsEx(
                EnumDateFormatsCallback,
                Thread.CurrentThread.CurrentCulture.LCID,
                DATE_LONGDATE);
        }

        //callback method
        static public bool EnumDateFormatsCallback(string dateFormat, int calId)
        {
            Console.WriteLine("CalId: {0}, Date Format: {1}", calId, dateFormat);
            return true;
        }
    }

    /// <summary>
    /// Wrapper class that demonstrates a correct characterset for unicode
    /// </summary>
    class UnicodeCallbackWrapperWithAttribute
    {
        //constants used for date formats
        private const int DATE_SHORTDATE = 0x00000001;  // use short date picture
        private const int DATE_LONGDATE = 0x00000002;  // use long date picture
        private const int DATE_YEARMONTH = 0x00000008;  // use year month picture

        //define the delegate for the callback using Unicode.
        //This delegate is correct for the Unicode
        //version of EnumDateFormatsEx.
        [UnmanagedFunctionPointer(CallingConvention.Winapi,
            CharSet=CharSet.Unicode)]
        public delegate bool EnumDateFormatsProcEx(
            string dateFormat, int calId);
        [DllImport("kernel32.DLL", CharSet = CharSet.Unicode,
            SetLastError = true)]
        public static extern bool EnumDateFormatsEx(
            EnumDateFormatsProcEx callBackProc, int LCID, ulong flags);

        public static void Test()
        {
            Console.WriteLine("Test Correct character-sets for unicode");

            //call the Unicode version of the function 
            EnumDateFormatsEx(
                EnumDateFormatsCallback,
                Thread.CurrentThread.CurrentCulture.LCID,
                DATE_LONGDATE);
        }

        //callback method
        static public bool EnumDateFormatsCallback(string dateFormat, int calId)
        {
            Console.WriteLine("CalId: {0}, Date Format: {1}", calId, dateFormat);
            return true;
        }
    }

	/// <summary>
	/// Handle a callback from a Win32 API call
	/// </summary>
	class Win32CallbackTest
	{
	    //constants used for date formats
        private const int DATE_SHORTDATE    = 0x00000001;  // use short date picture
        private const int DATE_LONGDATE     = 0x00000002;  // use long date picture
        private const int DATE_YEARMONTH    = 0x00000008;  // use year month picture
        
	    public delegate bool EnumDateFormatsProcEx(
            string dateFormat, int calId);
        [DllImport("kernel32.DLL", SetLastError = true)]
        public static extern bool EnumDateFormatsEx(
            EnumDateFormatsProcEx callBackProc, int LCID, ulong flags);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //call the function, passing a delegate for the callback
            EnumDateFormatsEx(
                EnumDateFormatsCallback,
                Thread.CurrentThread.CurrentCulture.LCID,
                DATE_LONGDATE);
        
            //run test that uses mismatched Character-sets
            UnicodeCallbackWrapperIncorrect.Test();

            //run test that uses correct character-set for unicode
            UnicodeCallbackWrapper.Test();

            //run test that uses correct the UnmanagedFunctionPointer
            //attribute to specify characterset
            UnicodeCallbackWrapperWithAttribute.Test();
            
            //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
		
		//callback method
		static public bool EnumDateFormatsCallback(string dateFormat, int calId)
		{
            Console.WriteLine("CalId: {0}, Date Format: {1}", calId, dateFormat);
            return true;
		}
	}
}
