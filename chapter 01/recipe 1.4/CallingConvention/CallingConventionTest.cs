using System;
using System.Runtime.InteropServices;

namespace CallingConventionTest
{
	/// <summary>
	/// Test changes to calling convention 
	/// </summary>
	class CallingConventionTest
	{
        //declare the unmanaged api
        [DllImport("FlatAPILib.DLL", CallingConvention=CallingConvention.Cdecl)]
        public static extern int AddSomeNumbersCdecl(int myNumA, int myNumB);

        [DllImport("FlatAPILib.DLL", CallingConvention=CallingConvention.StdCall)]
        public static extern int AddSomeNumbersStdCall(int myNumA, int myNumB);

        //you can define ThisCall but you just can't actually use it
        [DllImport("FlatAPILib.DLL", CallingConvention=CallingConvention.ThisCall)]
        public static extern int AddSomeNumbersThisCall(int myNumA, int myNumB);

        //map this function to the one defined as stdcall
        [DllImport("FlatAPILib.DLL", CallingConvention=CallingConvention.Winapi,
                     EntryPoint="AddSomeNumbers")]
        public static extern int AddSomeNumbersWinapi(int myNumA, int myNumB);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //make the unmanaged call
            int result = CallingConventionTest.AddSomeNumbersCdecl(1, 2);
            Console.WriteLine("Result from AddSomeNumbersCDecl = " + result.ToString());

            result = CallingConventionTest.AddSomeNumbersStdCall(1, 2);
            Console.WriteLine("Result from AddSomeNumbersStdCall = " + result.ToString());
       	    
            result = CallingConventionTest.AddSomeNumbersWinapi(1, 2);
            Console.WriteLine("Result from AddSomeNumbersWinapi = " + result.ToString());

            //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
        }
    }
}
