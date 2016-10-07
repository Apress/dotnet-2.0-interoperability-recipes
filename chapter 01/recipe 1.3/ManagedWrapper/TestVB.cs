using System;
using CustomerWrapperTestVB;

namespace CustomerWrapperTestMain
{
	public class TestVB
	{
		public static void Test()
		{
			//do some tests with the vb version of the wrapper
			CustomerWrapperVB wrapperVB = new CustomerWrapperVB();
			CustomerStatus statusVB	= wrapperVB.GetCustomerStatus(
				CustomerType.Corporate, "aaaaa");
			Console.WriteLine(
				"VB Result status is " + statusVB.ToString());
			//another test
			statusVB = wrapperVB.GetCustomerStatus(
				CustomerType.Individual, "bbbbbb");
			Console.WriteLine(
				"VB Result status is " + statusVB.ToString());
		}
	}
}
