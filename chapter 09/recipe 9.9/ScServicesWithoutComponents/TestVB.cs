using System;
using DniScServicesVB;

namespace ScServicesWithoutComponents
{
	public class TestVB
	{
		public static void Test()
		{
			IServicesWithoutComponents obj
				= new DniScServicesObj();

			//execute a test that completes the tran
			obj.UseComPlusServices(true);

			//give the tran logs time to clean up
			System.Threading.Thread.Sleep(200);

			//execute another test that aborts the tran
			obj.UseComPlusServices(false);
		}
	}
}
