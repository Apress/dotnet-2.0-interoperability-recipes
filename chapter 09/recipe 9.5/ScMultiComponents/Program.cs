using System;
using System.Runtime.InteropServices;

using DniScMultiComponents;

namespace ScMultiComponents
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				//run all tests
				PerformTest(1);
				PerformTest(2);
				PerformTest(3);
				PerformTest(4);
			}
			else
			{
				//run a single test
				try
				{
					int testNumber = Int32.Parse(args[0]);
					PerformTest(testNumber);
				}
				catch
				{
					Console.WriteLine("Unable to parse argument");
				}
			}

			Console.WriteLine("Press enter to continue");
			Console.Read();
		}

		private static void PerformTest(int testNumber)
		{
			try
			{
				IRootComponent obj = new DniScRootObj();
				obj.PerformUpdate(testNumber);

				Console.WriteLine(
					"DniScRootObj testNumber {0} completed",
						testNumber);

				//this keeps the log files tidy
				System.Threading.Thread.Sleep(200);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"DniScRootObj test:{0} Exception: {1}: {2}",
						testNumber, e.GetType().Name, e.Message);
			}
		}
	}
}