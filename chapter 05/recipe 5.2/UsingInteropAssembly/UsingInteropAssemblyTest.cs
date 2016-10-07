using System;
using Interop.DniSimpleComVB;

namespace UsingInteropAssemblyTest
{
	/// <summary>
	/// Reference an interop assembly built using tlbimp.exe
	/// </summary>
	class UsingInteropAssemblyTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			DniSimpleComLib.IDniSimpleComObj comIObj 
				= new DniSimpleComLib.DniSimpleComObj();
			int result = comIObj.AddSomeNumbers(1, 2);
			Console.WriteLine("Call Com Object: {0}: {1}", 
				comIObj.GetType(), result);

			DniSimpleCom.Interop.IDniSimpleComObj comIObjNs
				= new DniSimpleCom.Interop.DniSimpleComObj();
			result = comIObjNs.AddSomeNumbers(1, 2);
			Console.WriteLine("Call Com Object: {0}: {1}", 
				comIObjNs.GetType(), result);

			//use a VB6 COM component
			DniSimpleComVBObj vbComObj = new DniSimpleComVBObj();
			result = vbComObj.AddSomeNumbers(1, 2);
			Console.WriteLine("Call VB6 Com Object: {0}", result);

     	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
