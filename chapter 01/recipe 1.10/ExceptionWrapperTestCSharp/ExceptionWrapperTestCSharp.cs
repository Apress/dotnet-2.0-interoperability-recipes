using System;
using CppInteropWrappers;

namespace ExceptionWrapperTestCSharp
{
	/// <summary>
    /// Use the CppExceptionTestWrapper object from C#
	/// </summary>
	class ExceptionWrapperTestCSharp
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    string resultString         = String.Empty;
		    
		    //create an instance of the wrapper object
            CppExceptionTestWrapper testObj 
                = new CppExceptionTestWrapper();

            //test a simple integer exception
            resultString = testObj.RunExceptionTest(1);
            Console.WriteLine(
                "Result from RunExceptionTest 1 = {0}", 
                resultString);

            //test a custom C++ exception
            resultString = testObj.RunExceptionTest(2);
            Console.WriteLine(
                "Result from RunExceptionTest 2 = {0}", 
                resultString);

            //test a standard C++ exception
            resultString = testObj.RunExceptionTest(3);
            Console.WriteLine(
                "Result from RunExceptionTest 3 = {0}", 
                resultString);

            //test string name for an enum
            resultString = testObj.RunExceptionTest(4);
            Console.WriteLine(
                "Result from RunExceptionTest 4 = {0}", 
                resultString);

            //test throwing of a new managed exception from
            //within the managed C++ wrapper

            //create an instance of the wrapper object
            CppExceptionTestWrapper2 testObj2 
                = new CppExceptionTestWrapper2();

            try
            {
                //test a simple integer exception
                testObj2.RunExceptionTest(1);
            }
            catch(CppException e)
            {
                Console.WriteLine(
                    "Exception thrown by RunExceptionTest 1 = {0}:{1} ", 
                    e.Message, e.ErrorCode);
            }

            try
            {
                //test a custom C++ exception
                testObj2.RunExceptionTest(2);
            }
            catch(CppException e)
            {
                Console.WriteLine(
                    "Exception thrown by RunExceptionTest 2 = {0}:{1} ", 
                    e.Message, e.ErrorCode);
            }

            try
            {
                //test a standard C++ exception
                testObj2.RunExceptionTest(3);
            }
            catch(CppException e)
            {
                Console.WriteLine(
                    "Exception thrown by RunExceptionTest 3 = {0}:{1} ", 
                    e.Message, e.ErrorCode);
            }
            
            try
            {
                //test string name for an enum
                resultString = testObj2.RunExceptionTest(4);
                Console.WriteLine(
                    "Result from RunExceptionTest 4 = {0}", resultString);
            }
            catch (CppException e)
            {
                Console.WriteLine(
                    "Exception thrown by RunExceptionTest 4 = {0}:{1} ", 
                    e.Message, e.ErrorCode);
            }

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
