using System;
using System.Runtime.InteropServices;   //needed for DllImport attribute

namespace ManagedClient
{
	/// <summary>
	/// sample c# client calling an unmanaged api
	/// </summary>
	class CSharpClient
	{
	    //declare the unmanaged api
        [DllImport("FlatAPILib.DLL")]
        public static extern int AddSomeNumbers(int myNumA, int myNumB);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //make the unmanaged call
       	    int result = AddSomeNumbers(1, 2);
       	    
       	    //show the result
       	    Console.WriteLine("Result from AddSomeNumbers = " + result.ToString());
       	    
       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
