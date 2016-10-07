using System;
using System.IO;
using System.Runtime.InteropServices;

namespace DynamicLoading
{
	class DynamicLoadingTest
	{
		[DllImport("kernel32.dll")]
		private static extern IntPtr LoadLibrary(string dllName);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetProcAddress(
			IntPtr hModule, string procName);

		//managed delegate for the function call
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int AddSomeNumbers(
			int myNumA, int myNumB);

		static void Main(string[] args)
		{
			try
			{
				//dynamically load the dll
				IntPtr dll = LoadLibrary("FlatAPILib.DLL");
				if (dll == IntPtr.Zero)
				{
					throw new FileNotFoundException(
						"Unable to load FlatAPILib.DLL");
				}

				//get the address of the function we need
				IntPtr funcAddr = GetProcAddress(
					dll, "DynamicallyAddSomeNumbers");
				if (funcAddr == IntPtr.Zero)
				{
					throw new ApplicationException(
						"Unable to get address to function");
				}

				//marshal the function pointer to a delegate
				AddSomeNumbers asn = (AddSomeNumbers)
					Marshal.GetDelegateForFunctionPointer(
						funcAddr,
						typeof(AddSomeNumbers));
				//make the unmanaged call using the delegate
				int result = asn(1, 2);

				//show the result
				Console.WriteLine(
					"Result from DynamicallyAddSomeNumbers = " 
					+ result.ToString());
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"Exception dynamically calling function: {0}",
					e.Message);
			}

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read(); 	    
		}
	}
}
