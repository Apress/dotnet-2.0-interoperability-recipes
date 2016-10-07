using System;
using System.Runtime.InteropServices;   //needed for DllImport attribute

namespace ErrorAndExceptionTest
{
	/// <summary>
	/// sample c# client catching exceptions
	/// </summary>
	class ErrorAndExceptionTest
	{
	    //declare a non-existent dll
        [DllImport("TheMissingLibrary.DLL")]
        public static extern int MissingDllFunction(int anInt);

        //declare a bad entry point
        [DllImport("FlatAPILib.DLL")]
        public static extern int MissingFunction(int anInt);

        //incorrect type of parameters
        [DllImport("FlatAPILib.DLL", CharSet=CharSet.Unicode)]
        public static extern int AddSomeNumbers(char charOne, int numTwo);

        //incorrect number of parameters
        [DllImport("FlatAPILib.DLL")]
        public static extern int AddSomeNumbers(int numOne);
    
        //error generated within unmanaged code
        [DllImport("FlatAPILib.DLL")]
        public static extern int DivideSomeNumbers(int numOne, int numTwo);
        
        //some type of unmanaged io that fails
        [DllImport("FlatAPILib.DLL")]
        public static extern int DoFailingIO(string fileName);
        
        //unmanaged function that does something really wrong
        [DllImport("FlatAPILib.DLL")]
        public static extern int UnmanagedRuntimeError();

        //unmanaged function that throws an exception
        [DllImport("FlatAPILib.DLL", EntryPoint="?UnmanagedRuntimeException@@YGHXZ")]
//        [DllImport("FlatAPILib.DLL", EntryPoint="?UnmanagedRuntimeException@UnmanagedRuntimeClass@@SGHXZ")]
        public static extern int UnmanagedRuntimeException();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //missing dll
		    try
		    {
       	        int result = ErrorAndExceptionTest.MissingDllFunction(1001);
       	        Console.WriteLine("Result from MissingDllFunction = {0}", result);
       	    }
       	    catch(DllNotFoundException e)
       	    {
       	        Console.WriteLine("DllNotFoundException from MissingDllFunction: {0}", e.Message);
       	    }

            //missing function entry point
            try
            {
                int result = ErrorAndExceptionTest.MissingFunction(1001);
                Console.WriteLine("Result from MissingFunction = {0}", result);
            }
            catch(DllNotFoundException e)
            {
                Console.WriteLine("DllNotFoundException from MissingFunction: {0}", e.Message);
            }
            catch(EntryPointNotFoundException e)
            {
                Console.WriteLine("EntryPointNotFoundException from MissingFunction: {0}", e.Message);
            }
            
            //incorrect parameters
            try
            {
                //this doesn't throw an exception. Instead it uses the 
                //Unicode value of an 'A' (65) as an integer.
                int result = ErrorAndExceptionTest.AddSomeNumbers('A', 100);
                Console.WriteLine("Result from AddSomeNumbers = {0}", result);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception from AddSomeNumbers: {0}", e.Message);
            }

            //missing parameters
            try
            {
                //this generates an entry point exception since the 
                //function signature doesn't match the one in the actual
                //unmanaged dll
                int result = ErrorAndExceptionTest.AddSomeNumbers(100);
                Console.WriteLine("Result from AddSomeNumbers = {0}", result);
            }
            catch(EntryPointNotFoundException e)
            {
                Console.WriteLine("EntryPointNotFoundException from AddSomeNumbers: {0}", e.Message);
            }

            //runtime error generated within unmanaged function
            try
            {
                int result = ErrorAndExceptionTest.DivideSomeNumbers(1, 0);
                Console.WriteLine("Result from DivideSomeNumbers = {0}", result);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("DivideByZeroException from DivideSomeNumbers: {0}", e.Message);
            }

            //file not found from within unmanaged function
            try
            {
                //does not throw an exception since underlying win32 api
                //simply returns a bad result code if the io fails
                int result = ErrorAndExceptionTest.DoFailingIO("missingfile.txt");
                Console.WriteLine("Result from DoFailingIO = {0}", result);
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception from DoFailingIO: {0}", e.Message);
            }

            //badly written unmanagged function
            try
            {
                int result = ErrorAndExceptionTest.UnmanagedRuntimeError();
                Console.WriteLine("Result from UnmanagedRuntimeError = {0}", result);
            }
            catch(AccessViolationException e)
            {
				Console.WriteLine("Exception from UnmanagedRuntimeError: {0}", e.Message);
            }

            //unmanaged code with try/catch block that throws an exception
            try
            {
                //will always return a result code of x80004005 which is E_FAIL.
                //The same error code is returned for a structured exception thrown
                //via a call to RaiseException, or for a simple C++ style throw statement.
                int result = ErrorAndExceptionTest.UnmanagedRuntimeException();
                Console.WriteLine("Result from UnmanagedRuntimeException = {0}", result);
            }
            catch(SEHException e)
            {
                Console.WriteLine("SEHException from UnmanagedRuntimeException: {0}: {1}", 
                    e.Message, e.ErrorCode);
            }

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
