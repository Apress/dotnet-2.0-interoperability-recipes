using System;
using System.Runtime.InteropServices;

namespace StructureMarshalAsTest
{
	[StructLayout(LayoutKind.Sequential)]
	struct ManagedAmbiguousStruct
	{
		[MarshalAs(UnmanagedType.LPStr)]
		public string AnsiString;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string WideString;
		[MarshalAs(UnmanagedType.Bool)]
		public bool Win32Boolean;
		[MarshalAs(UnmanagedType.I1)]
		public bool CStyleBoolean;
		public ushort ShortInteger;
	};

	/// <summary>
	/// Passing of structures between managed and unmanaged code
	/// </summary>
	class StructureMarshalAsTest
	{
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern int UseAmbiguousStruct(ManagedAmbiguousStruct aStruct);
	
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    ManagedAmbiguousStruct mStruct = new ManagedAmbiguousStruct();
		    mStruct.AnsiString          = "ansistring";
		    mStruct.WideString          = "widestring";
		    mStruct.CStyleBoolean       = true;
		    mStruct.Win32Boolean        = true;
		    mStruct.ShortInteger        = 5;
		
		    int result = UseAmbiguousStruct(mStruct);
		
		    //show the results
		    Console.WriteLine("UseAmbiguousStruct results: {0}",
		        result);

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
