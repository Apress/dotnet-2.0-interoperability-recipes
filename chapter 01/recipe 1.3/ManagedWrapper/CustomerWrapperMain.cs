using System;
using CustomerWrapperTest;

namespace CustomerWrapperTestMain
{
	/// <summary>
	/// tests a managed wrapper
	/// </summary>
	class CustomerWrapperMain
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    CustomerWrapper wrapper = new CustomerWrapper();
		    //call the wrapper and show the result
		    CustomerStatus status = wrapper.GetCustomerStatus(
				CustomerType.Corporate, "aaaaa");
            Console.WriteLine(
				"Result status is " + status.ToString());
            //call the wrapper and show the result
            status = wrapper.GetCustomerStatus(
				CustomerType.Individual, "bbbbbb");
            Console.WriteLine(
				"Result status is " + status.ToString());
            
			//do vb.net version test
			TestVB.Test();

            //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
        }
	}
}
