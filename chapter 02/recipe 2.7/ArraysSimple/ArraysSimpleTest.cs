using System;
using System.Runtime.InteropServices;

namespace ArraysSimpleTest
{
	/// <summary>
	/// Passing of arrays between managed and unmanaged code
	/// </summary>
	class ArraysSimpleTest
	{
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern int SumOfArrayElements(int[] array, int arraySize);

        [DllImport("FlatAPIStructLib.DLL")]
        public static extern int UpdateIntArrayElements([In] int[] array, int arraySize);

        [DllImport("FlatAPIStructLib.DLL")]
        public static extern int CountLowerCaseChars(char[] chars, int arraySize);
        
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern int ChangeLowerCaseChars( [In, Out] char[] chars, int arraySize);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //pass an array to a read-only function - blittable type
            int[] intArray      = new int[10];
            for(int i = 0; i < intArray.Length; i++)
            {
                intArray[i]     = i;
            }
            int intArrayCount = SumOfArrayElements(intArray, intArray.Length);
            Console.WriteLine(
                "SumOfArrayElements results: {0}", intArrayCount);

            //call function that updates the array - blittable type
            intArray      = new int[10];
            for(int i = 0; i < intArray.Length; i++)
            {
                intArray[i]     = i;
            }
            //this will update the array 
            //since it contains a blittable type
            intArrayCount = UpdateIntArrayElements(intArray, intArray.Length);
            Console.WriteLine(
                "UpdateIntArrayElements results: {0},{1},{2},{3},{4}", 
                intArray[0],intArray[1],intArray[2],intArray[3],intArray[4]);

            //read only func for non-blittable
            char[] chars = new char[5];
            chars[0]    = 'A';
            chars[1]    = 'b';
            chars[2]    = 'c';
            chars[3]    = 'D';
            chars[4]    = 'e';
            int lcCharCount = CountLowerCaseChars(chars, chars.Length);
            Console.WriteLine(
                "CountLowerCaseChars results: {0}", lcCharCount);

            //update func for non-blittable types
            chars = new char[5];
            chars[0]    = 'A';
            chars[1]    = 'b';
            chars[2]    = 'c';
            chars[3]    = 'D';
            chars[4]    = 'e';
            lcCharCount = ChangeLowerCaseChars(chars, chars.Length);
            Console.WriteLine(
                "ChangeLowerCaseChars results: {0},{1},{2},{3},{4}", 
                chars[0],chars[1],chars[2],chars[3],chars[4]);
            
       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
