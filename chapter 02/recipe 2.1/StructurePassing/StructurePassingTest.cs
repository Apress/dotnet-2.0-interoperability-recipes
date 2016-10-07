using System;
using System.Runtime.InteropServices;

namespace StructurePassingTest
{
    //struct is properly aligned with unmanaged struct
    public struct ManagedStruct1
    {
        public int      maCount;
        byte            maUnused;
        public int      maDelta;
        public double   maPercent;
    }

    //struct is aligned on 1 byte packing boundary
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ManagedStruct2
    {
        public int      maCount;
        byte            maUnused;
        public int      maDelta;
        public double   maPercent;
    }

	/// <summary>
	/// Passing of structures between managed and unmanaged code
	/// </summary>
	class StructurePassingTest
	{
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern void ProcessStruct1(ref ManagedStruct1 aStruct);
        
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern void ProcessStruct2(ref ManagedStruct2 aStruct);
	
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //uses a properly defined default structure alignment
		    //create an instance of the struct 
            ManagedStruct1 struct1  = new ManagedStruct1();
            struct1.maCount         = 12345;
            struct1.maDelta         = 45678;
            struct1.maPercent       = 5.4321;
            //call the unmanaged function
		    ProcessStruct1(ref struct1);
		    //show the results
		    Console.WriteLine("ProcessStruct1 results: {0}, {1}, {2}",
		        struct1.maCount, struct1.maDelta, struct1.maPercent);

            //uses a struct aligned on a 1 byte packing boundary
            ManagedStruct2 struct2  = new ManagedStruct2();
            struct2.maCount         = 12345;
            struct2.maDelta         = 45678;
            struct2.maPercent       = 5.4321;
            //call the unmanaged function
            ProcessStruct2(ref struct2);
            //show the results
            Console.WriteLine("ProcessStruct2 results: {0}, {1}, {2}",
                struct2.maCount, struct2.maDelta, struct2.maPercent);

            		    
       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
