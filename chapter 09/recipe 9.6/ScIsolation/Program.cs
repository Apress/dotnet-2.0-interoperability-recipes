using System;
using System.Runtime.InteropServices;

using DniScIsolation;

namespace ScIsolation
{
	class Program
	{
		static void Main(string[] args)
		{
			IIsolationMethods obj
				= new DniScIsolationRRObj();
			IsolationTest(obj);

			Console.WriteLine("Press enter to continue");
			Console.Read();
		}

		private static void IsolationTest(IIsolationMethods obj)
		{
			try
			{
				obj.PerformUpdate();
				Console.WriteLine(
					"PerformUpdate completed");

				//this keeps the log files tidy
				System.Threading.Thread.Sleep(200);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"PerformUpdate Exception: {0}: {1}",
						e.GetType().Name, e.Message);
			}
		}
	}
}