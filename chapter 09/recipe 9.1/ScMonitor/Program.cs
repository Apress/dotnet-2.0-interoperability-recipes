using System;
using System.Runtime.InteropServices;

using DniScMonitor;

namespace ScMonitor
{
	class Program
	{
		static void Main(string[] args)
		{
			ITranMonitor obj
				= new DniScMonitorObj();
			obj.LogTransactionDetails();

			TestVB.Test();

			Console.WriteLine("Press enter to continue...");
			Console.Read();
		}
	}
}
