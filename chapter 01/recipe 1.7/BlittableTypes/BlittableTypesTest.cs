using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BlittableTypesTest
{
	/// <summary>
	/// Test blittable types
	/// </summary>
	class BlittableTypesTest
	{
        //declare the unmanaged api
        [DllImport("FlatAPILib.DLL")]
        public static extern bool NonblittableFunction(char valueToTest);
        
        [DllImport("FlatAPILib.DLL")]
        public static extern int BlittableFunction(byte valueToTest);
        
        [DllImport("FlatAPILib.DLL")]
        public static extern void BlittableUnmanagedTest();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //make the unmanaged call
            bool result = BlittableTypesTest.NonblittableFunction('c');
            Console.WriteLine("Result from NonblittableFunction = " + result.ToString());
            result = BlittableTypesTest.NonblittableFunction('C');
            Console.WriteLine("Result from NonblittableFunction = " + result.ToString());

            result = (BlittableTypesTest.BlittableFunction((byte)'c') != 0);
            Console.WriteLine("Result from BlittableFunction = " + result.ToString());
            result = (BlittableTypesTest.BlittableFunction((byte)'C') != 0);
            Console.WriteLine("Result from BlittableFunction = " + result.ToString());

            //do time test to see if blittable types make any difference
            const int numberOfCalls         = 100000;
            
			//create the StopWatch used for timings
			Stopwatch stopWatch = new Stopwatch();

            //non-blittable
			stopWatch.Start();
            for(int i = 0; i < numberOfCalls; i++)
            {
                result = BlittableTypesTest.NonblittableFunction('a');
            }
			stopWatch.Stop();
            Console.WriteLine(
				"{0} Nonblittable function calls: {1} milliseconds",
                numberOfCalls, stopWatch.ElapsedMilliseconds); 
                
            //blittable
			stopWatch.Reset();
			stopWatch.Start();
            for(int i = 0; i < numberOfCalls; i++)
            {
                result = (BlittableTypesTest.BlittableFunction((byte)'a') != 0);
            }
			stopWatch.Stop();
            Console.WriteLine(
				"{0} Blittable function calls:    {1} milliseconds",
                numberOfCalls, stopWatch.ElapsedMilliseconds); 

            //perform the same test, done entirely in unmanaged code
			stopWatch.Reset();
			stopWatch.Start();
			BlittableTypesTest.BlittableUnmanagedTest();
			stopWatch.Stop();
			Console.WriteLine(
				"{0} Unmanaged only test:         {1} milliseconds",
                numberOfCalls, stopWatch.ElapsedMilliseconds); 

            //test isLower done entirely in managed code
			stopWatch.Reset();
			stopWatch.Start();
			for (int i = 0; i < numberOfCalls; i++)
            {
                result = Char.IsLower('a');
            }
			stopWatch.Stop();
            Console.WriteLine(
				"{0} Managed only test:           {1} milliseconds",
                numberOfCalls, stopWatch.ElapsedMilliseconds); 
            
            //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
        }
    }
}
    