using System;
using System.Runtime.InteropServices;
using System.EnterpriseServices;
using DniScTransaction;

namespace ScTransaction
{
	class Program
	{
		static void Main(string[] args)
		{
			ITranMethods obj;

			obj = new DniScTransactionNoneObj();
			ExecuteTranMethod(obj);

			obj = new DniScTransactionDefaultObj();
			ExecuteTranMethod(obj);

			obj = new DniScTransactionRequiredObj();
			ExecuteTranMethod(obj);

			obj = new DniScTransactionRequiresNewObj();
			ExecuteTranMethod(obj);

			obj = new DniScTransactionDisabledObj();
			ExecuteTranMethod(obj);

			obj = new DniScTransactionNotSupportedObj();
			ExecuteTranMethod(obj);

			obj = new DniScTransactionSupportedObj();
			ExecuteTranMethod(obj);

			obj = new DniScTransactionUsesSupportsObj();
			ExecuteTranMethod(obj);

			obj = new DniScTransactionUsesRequiresNewObj();
			ExecuteTranMethod(obj);

			Console.Read();
		}

		static void ExecuteTranMethod(ITranMethods obj)
		{
			string msg = obj.GetTranStatus();
			Console.WriteLine("{0}.GetTranStatus: {1}", 
				obj.GetType().Name, msg);
		}
	}
}
