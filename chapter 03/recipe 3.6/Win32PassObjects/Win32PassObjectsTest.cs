using System;
using System.IO;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Win32PassObjects
{
	/// <summary>
	/// Class used for GCHandle demonstration
	/// </summary>
	class GCHandleTestClass
	{
		public int field1;
		public int field2;
		public string field3;
	}

    /// <summary>
    /// GCHandle test
    /// </summary>
	class GCHandleTest
	{
		[DllImport("kernel32.DLL")]
		private static extern uint TlsAlloc();

		[DllImport("kernel32.DLL")]
		private static extern bool TlsFree(uint index);

		[DllImport("kernel32.DLL")]
		private static extern bool TlsSetValue(
			uint index, GCHandle gcObject);

		[DllImport("kernel32.DLL")]
		private static extern GCHandle TlsGetValue(uint index);

		public void TestGCHandle()
		{
			//allocate a thread local storage slot
			uint tlsIndex = TlsAlloc();

			//create our managed test object
			GCHandleTestClass testObj = new GCHandleTestClass();
			testObj.field1 = 1;
			testObj.field2 = 2;
			testObj.field3 = "string3";

			//put the test object into a GCHandle. this prevents
			//the object from being garbage collected even 
			//when no managed code holds a reference to the object
			GCHandle gch = GCHandle.Alloc(testObj);
			//remove our reference to this object
			testObj = null;
			//request garbage-collection now
			GC.Collect();

			//put the GCHandle into the thread local storage slot
			TlsSetValue(tlsIndex, gch);

			//assume some unmanaged processing occurs here

			//now retrieve the GCHandle from thread local storage
			//and show the values
			GCHandle gchRetrieved = TlsGetValue(tlsIndex);
			GCHandleTestClass retrievedObj
				= gchRetrieved.Target as GCHandleTestClass;
			if (retrievedObj != null)
			{
				Console.WriteLine("Retrieved Test Obj: {0},{1},{2}",
					retrievedObj.field1, retrievedObj.field2,
					retrievedObj.field3);
			}

			//free the thread local storage
			TlsFree(tlsIndex);

			//release the GC handle
			gch.Free();
		}

		public void TestPinnedGCHandle()
		{
			//allocate a thread local storage slot
			uint tlsIndex = TlsAlloc();

			//create our managed array that will go into the GCHandle
			int[] blitArray = new int[3];
			blitArray[0] = 123;
			blitArray[1] = 456;
			blitArray[2] = 789;

			//pin the blittable array using a GCHandle            
			GCHandle gch = GCHandle.Alloc(blitArray, 
				GCHandleType.Pinned);
			//remove our reference to this object
			blitArray = null;
			//request garbage-collection now
			GC.Collect();

			//put the GCHandle into the thread local storage slot
			TlsSetValue(tlsIndex, gch);

			//assume some unmanaged processing occurs here

			//now retrieve the GCHandle from thread local storage
			//and show the values
			GCHandle gchRetrieved = TlsGetValue(tlsIndex);

			int[] retrievedArray = (int[])gchRetrieved.Target;
			if (retrievedArray != null)
			{
				Console.WriteLine(
					"Retrieved Pinned Array: {0},{1},{2}",
					retrievedArray[0], retrievedArray[1], 
					retrievedArray[2]);
			}

			//free the thread local storage
			TlsFree(tlsIndex);

			//release the GC handle otherwise it will be pinned forever
			gch.Free();
		}
	}

	class Win32PassObjectsTest
	{
		[STAThread]
		static void Main(string[] args)
		{
			//Use GCHandle to pass an object to unmanaged code.
			//the GCHandle will prevent the object from being
			//garbage collected even if no managed code holds
			//a reference to the object.
			GCHandleTest gcHandleTest = new GCHandleTest();
			gcHandleTest.TestGCHandle();

			//use a pinned GCHandle
			gcHandleTest.TestPinnedGCHandle();

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read(); 	    
		}
	}
}
