using System;
using CppInteropWrappers;

namespace CppInteropClientCSharp
{
	/// <summary>
	/// Use the CppInteropWrapper object from C#
	/// </summary>
	class CppInteropClient
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    int result                  = 0;
		    string resultString         = String.Empty;
		    
		    //create an instance of the wrapper object
            CppInteropTest testObj = new CppInteropTest();
		
		    //test numbers function using PInvoke
		    result = testObj.PInvokeAddNumbersTest();
            Console.WriteLine(
				"Result from PInvokeAddNumbersTest = {0}", 
				result);

            //test numbers function using C++ Interop
            result = testObj.CppInteropAddNumbersTest();
            Console.WriteLine(
				"Result from CppInteropAddNumbersTest = {0}", 
				result);

            //test string function using PInvoke
            resultString = testObj.PInvokeStringsTest();
            Console.WriteLine(
				"Result from PInvokeStringsTest = {0}", 
				resultString);

			//test string function using C++ Interop
            resultString = testObj.CppInteropStringsTest();
            Console.WriteLine(
				"Result from CppInteropStringsTest = {0}", 
				resultString);

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
