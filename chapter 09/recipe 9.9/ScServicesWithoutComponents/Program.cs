using System;
using DniScServices;

namespace ScServicesWithoutComponents
{
	class Program
	{
		static void Main(string[] args)
		{
			IServicesWithoutComponents obj
				= new DniScServicesObj();

			//execute a test that completes the tran
			obj.UseComPlusServices(true);

			//give the tran logs time to clean up
			System.Threading.Thread.Sleep(200);

			//execute another test that aborts the tran
			obj.UseComPlusServices(false);

			TestVB.Test();

			Console.WriteLine("Press enter to continue");
			Console.Read();
		}
	}
}
