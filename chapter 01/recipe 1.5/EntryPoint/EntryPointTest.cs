using System;
using System.Runtime.InteropServices;   //needed for DllImport attribute

namespace EntryPointTest
{
	/// <summary>
	/// sample c# client calling an unmanaged api
	/// </summary>
	class EntryPointTest
	{
	    //declare the unmanaged api
        [DllImport("FlatAPILib.DLL", EntryPoint="FunctionToRename")]
        public static extern int RenamedFunction(int anInt);

        //first declaration of a function that accepts any type
        [DllImport("FlatAPILib.DLL", EntryPoint="PolymorphicFunction")]
        public static extern int FunctionWithInteger(ref int anInt, int type);

        //second declaration of a function that accepts any type
        [DllImport("FlatAPILib.DLL", EntryPoint="PolymorphicFunction")]
        public static extern int FunctionWithChar(ref char aChar, int type);

        //first declaration of a function that accepts any type
        [DllImport("FlatAPILib.DLL", EntryPoint="PolymorphicFunction")]
        public static extern int OverloadedFunction(ref int anInt, int type);

        //second declaration of a function that accepts any type
        [DllImport("FlatAPILib.DLL", EntryPoint="PolymorphicFunction")]
        public static extern int OverloadedFunction(ref char aChar, int type);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
       	    int result = RenamedFunction(123);
       	    Console.WriteLine("Result from RenamedFunction = " + result.ToString());

            int myIntValue = 123;
            result = FunctionWithInteger(ref myIntValue, 1);
            Console.WriteLine("Result from FunctionWithInteger = " + result.ToString());

            char myCharValue = 'A';
            result = FunctionWithChar(ref myCharValue, 2);
            Console.WriteLine("Result from FunctionWithChar = " + result.ToString());

            myCharValue = 'Z';
            result = OverloadedFunction(ref myCharValue, 2);
            Console.WriteLine("Result from OverloadedFunction = " + result.ToString());

            myIntValue = 456;
            result = OverloadedFunction(ref myIntValue, 1);
            Console.WriteLine("Result from OverloadedFunction = " + result.ToString());
       	    
       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
