using System;
using System.Runtime.InteropServices;

using DniDataTypesLib;
using Interop.DniDataTypesVB;

namespace ComSafeArrays
{
	class ComSafeArraysTest
	{
		static void Main(string[] args)
		{
			//create an instance of the COM object				
			DniDataTypesObj comObj = new DniDataTypesObj();
			string desc = string.Empty;

			//pass an array in as a safearray				
			string[] testSafeArray = new string[3] { "one", "two", "three" };
			Console.WriteLine("Input Array Before: {0}, {1}, {2}",
				testSafeArray[0], testSafeArray[1],
				testSafeArray[2]);

			//make the com call passing the managed array
			desc = comObj.UseArray(testSafeArray);
			Console.WriteLine("UseArray results: {0}",	desc);

			//update an array of strings within the COM component
			string[] testUpdateSafeArray = new string[3] { "one", "two", "three" };
			Console.WriteLine("Array Before: {0}, {1}, {2}",
				testUpdateSafeArray[0], testUpdateSafeArray[1],
				testUpdateSafeArray[2]);

			//make the com call
			comObj.UpdateArray(testUpdateSafeArray);
			Console.WriteLine("Array After: {0}, {1}, {2}",
				testUpdateSafeArray[0], testUpdateSafeArray[1],
				testUpdateSafeArray[2]);

			//call a COM method that uses a c-style array instead
			//of a safearray
			int[] intArray = new int[3];
			intArray[0] = 111;
			intArray[1] = 222;
			intArray[2] = 333;
			string outParam = string.Empty;
			//allocate unmanaged memory to pass the array
			int memSize = Marshal.SizeOf(typeof(Int32)) * intArray.Length;
			IntPtr arrayPtr = Marshal.AllocCoTaskMem(memSize);
			//copy the array into the unmanaged memory
			Marshal.Copy(intArray, 0, arrayPtr, intArray.Length);
			//make the COM method call
			comObj.UseCStyleArray(arrayPtr, intArray.Length, ref outParam);
			//free the memory that we allocated
			Marshal.FreeCoTaskMem(arrayPtr);
			Console.WriteLine("C-Style Array: {0},{1},{2},{3}",
				intArray[0],intArray[1],intArray[2],outParam);

			//test vb com object with arrays
			DniDataTypesVBObj vbObj = new DniDataTypesVBObjClass();
			//create the test array of strings
			string[] vbArray = new string[3];
			vbArray[0] = "one";
			vbArray[1] = "two";
			vbArray[2] = "three";
			//make the call to the VB COM component
			string vbResult = vbObj.UseArray(ref vbArray);
			Console.WriteLine("VB Array: {0},{1},{2},{3}",
				vbArray[0], vbArray[1], vbArray[2], vbResult);

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read(); 	    
		}
	}
}
