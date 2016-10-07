using System;
using System.Runtime.InteropServices;

namespace StructureReturningTest
{
    public struct ReturnedManagedStruct
    {
        public int      Hours;
        public int      Minutes;
        public int      Seconds;
    }

	/// <summary>
	/// Returning of structures from unmanaged code
	/// </summary>
	class StructureReturningTest
	{
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern IntPtr ReturnAStruct();

        [DllImport("FlatAPIStructLib.DLL")]
        public static extern void FreeAStruct(IntPtr structPtr);

        [DllImport("FlatAPIStructLib.DLL")]
        public static extern IntPtr ReturnCoMemStruct();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //call the unmanaged function returning a struct
		    IntPtr structPtr = ReturnAStruct();
		    //marshal the returned pointer to a struct
		    ReturnedManagedStruct aStruct 
		        = (ReturnedManagedStruct)Marshal.PtrToStructure(
		            structPtr, typeof(ReturnedManagedStruct));
            //free the memory for the unmanaged struct
            FreeAStruct(structPtr);                
		    //show the results
		    Console.WriteLine("ReturnAStruct results: {0}, {1}, {2}",
		        aStruct.Hours, aStruct.Minutes, aStruct.Seconds);

            //call the unmanaged function returning a CoTaskMemAlloc struct
            structPtr = ReturnCoMemStruct();
            //marshal the returned pointer to a struct
            ReturnedManagedStruct bStruct 
                = (ReturnedManagedStruct)Marshal.PtrToStructure(
                    structPtr, typeof(ReturnedManagedStruct));
            //free the CoTaskMemAlloc memory
            Marshal.FreeCoTaskMem(structPtr);
            //show the results
            Console.WriteLine("ReturnCoMemStruct results: {0}, {1}, {2}",
                bStruct.Hours, bStruct.Minutes, bStruct.Seconds);

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
