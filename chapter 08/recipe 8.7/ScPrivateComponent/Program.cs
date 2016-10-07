using System;
using DniScPrivateComponent;

namespace ScPrivateComponent
{
	class Program
	{
		static void Main(string[] args)
		{
			//try the private object

			try
			{
				IAccountServices obj
					= new DniScPrivateObj();
				int acctId = obj.FindAccount("MyAccountName");
				Console.WriteLine(
					"FindAccount results: {0}", acctId);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"Exception accessing DniScPrivateObj: {0}",
					e.Message);
			}

			//try the public object
			IPublicAccountServices publicObj
				= new DniScPublicObj();
			int updateAcctId 
				= publicObj.UpdateAccountStatus("MyAccountName");
			Console.WriteLine(
				"UpdateAccountStatus results: {0}",	updateAcctId);

			Console.Read();
		}
	}
}

