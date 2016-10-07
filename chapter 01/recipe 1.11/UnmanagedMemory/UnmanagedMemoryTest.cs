using System;
using System.Runtime.InteropServices;   //needed for DllImport attribute

namespace UnmanagedMemoryTest
{
	/// <summary>
	/// Tests use of memory allocated by unmanaged code
	/// </summary>
	class UnmanagedMemoryTest
	{
        [DllImport("FlatAPILib.DLL", CharSet=CharSet.Unicode)]
        public static extern IntPtr ReturnUnmanagedString(string leftString, string rightString);
	
        [DllImport("FlatAPILib.DLL")]
        public static extern void FreeUnmanagedString(IntPtr stringPtr);

        [DllImport("FlatAPILib.DLL", CharSet=CharSet.Unicode, EntryPoint="ReturnUnmanagedString")]
        public static extern string ReturnUnmanagedStringAsString(string leftString, string rightString);

        [DllImport("FlatAPILib.DLL", CharSet=CharSet.Unicode)]
        public static extern IntPtr ReturnComAllocatedString(string leftString, string rightString);

        [DllImport("FlatAPILib.DLL", CharSet=CharSet.Unicode, EntryPoint="ReturnComAllocatedString")]
        public static extern string ReturnComAllocatedStringAsString(string leftString, string rightString);
	
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    string resultString         = String.Empty;
		    IntPtr stringPtr;

/*
//this will thrown an unhandled exception in NTDLL.DLL. The stack
//trace shows the marshaler attempting a call to CoTaskMemFree    
            try
            {
                //handle an unmanaged string allocated by the C runtime as a string
                resultString = UnmanagedMemoryTest.ReturnUnmanagedStringAsString("left", "right");
                Console.WriteLine("Result from ReturnUnmanagedStringAsString = {0}", resultString);
		    }
		    catch(Exception e)
		    {
		        Console.WriteLine("Exception thrown from ReturnUnmanagedStringAsString = {0}", e.Message);
		    }
*/		    
		    
		    //handle an unmanaged string allocated by the C runtime
		    stringPtr = UnmanagedMemoryTest.ReturnUnmanagedString("left", "right");
		    resultString = Marshal.PtrToStringUni(stringPtr);
		    FreeUnmanagedString(stringPtr);
		    Console.WriteLine("Result from ReturnUnmanagedString = {0}", resultString);
		
		    //handle an unmanaged string allocated by CoTaskMemAlloc
            stringPtr = UnmanagedMemoryTest.ReturnComAllocatedString("left", "right");
            resultString = Marshal.PtrToStringUni(stringPtr);
            Marshal.FreeCoTaskMem(stringPtr);
            Console.WriteLine("Result from ReturnComAllocatedString = {0}", resultString);

            //handle an unmanaged string allocated by CoTaskMemAlloc
            //this time marshaled as a string
            resultString = UnmanagedMemoryTest.ReturnComAllocatedStringAsString("left", "right");
            Console.WriteLine("Result from ReturnComAllocatedStringAsString = {0}", resultString);
		
       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
