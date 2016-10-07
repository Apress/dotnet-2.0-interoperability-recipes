using System;
using System.Runtime.InteropServices;

namespace ArraysStringTest
{
	/// <summary>
	/// Passing of string arrays between managed and unmanaged code
	/// </summary>
	class ArraysStringTest
	{
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern void StringArrayToUpper( [In,Out] string[] strings, int size);
        
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern void FillStringArray(IntPtr[] buffers, int size, int maxStringSize);
        
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern int AllocateAndReturnStringArray(ref IntPtr array);
        
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //pass an array of strings to unmanaged code
            string[] strings        = new string[3];
            strings[0]              = "sTringOne";
            strings[1]              = "stringTWO";
            strings[2]              = "STRINGthree";              
            //call the unmanaged function to update the strings
            StringArrayToUpper(strings, strings.Length);
            Console.WriteLine(
                "StringArrayToUpper results: {0},{1},{2}", 
                strings[0], strings[1], strings[2]);

            //allocate buffers for use by the function
            IntPtr[] buffers        = new IntPtr[3];
            const int maxSize       = 255;
            for(int i = 0; i < buffers.Length; i++)
            {
                buffers[i]          = Marshal.AllocCoTaskMem(maxSize);
            }
            //call the function to fill the buffers
            FillStringArray(buffers, buffers.Length, maxSize);
            //marshal the IntPtrs to strings 
			strings = new String[buffers.Length];
            for(int i = 0; i < buffers.Length; i++)
            {
                strings[i] = Marshal.PtrToStringAnsi(buffers[i]);
                //free the memory we allocated
                Marshal.FreeCoTaskMem(buffers[i]);
            }
            //show the results
            Console.WriteLine(
                "FillStringArray results: {0},{1},{2}", 
                strings[0], strings[1], strings[2]);

            //return an array allocated within the unmanaged function
            IntPtr arrayPtr = IntPtr.Zero;
            //call the function that allocates and fills the array.
            //we don't know the size of the array until the
            //function returns.
            int returnCount = AllocateAndReturnStringArray(ref arrayPtr);
            //using the returned ptr to get pointers to each element
            IntPtr[] arrayPtrs = new IntPtr[returnCount];
            Marshal.Copy(arrayPtr, arrayPtrs, 0, returnCount);
            
            //marshal each element pointer to a string
            strings = new string[returnCount];
            for(int i = 0; i < returnCount; i++)
            {
                strings[i] = Marshal.PtrToStringAnsi(arrayPtrs[i]);
                //free memory for the array element
                Marshal.FreeCoTaskMem(arrayPtrs[i]);
            }
            //free the entire array
            Marshal.FreeCoTaskMem(arrayPtr);
            
            //show the results
            Console.WriteLine(
                "AllocateAndReturnStringArray: {0}, {1},{2}", 
                returnCount, strings[0], strings[returnCount-1]);

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
