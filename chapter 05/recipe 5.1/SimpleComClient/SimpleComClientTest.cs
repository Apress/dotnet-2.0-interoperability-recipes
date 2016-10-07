using System;

using DniSimpleComLib;  //reference the interop assembly
using System.Runtime.InteropServices; //needed only for the Marshal class example

namespace SimpleComClientTest
{
	/// <summary>
	/// Reference and use a simple COM object
	/// </summary>
	class SimpleComClientTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//define the component using the interface and
			//create an instance
			IDniSimpleComObj comObjInterface = new DniSimpleComObj();
			int result = comObjInterface.AddSomeNumbers(1, 2);
			Console.WriteLine("Call Com Object, interface: {0}", result);

			//define using the object instead of the interface
			DniSimpleComObj comObj = new DniSimpleComObj();
			result = comObj.AddSomeNumbers(1, 2);
			Console.WriteLine("Call Com Object, class: {0}", result);

			//create an instance of the Com object
			IDniSimpleComObj comObjManualRelease = new DniSimpleComObj();
			result = comObjManualRelease.AddSomeNumbers(1, 2);
			Console.WriteLine("Call Com Object, manual release: {0}", result);
			//manually release the Com object reference
			Marshal.ReleaseComObject(comObjManualRelease);

            //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
