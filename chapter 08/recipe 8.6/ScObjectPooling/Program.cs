using System;
using DniScObjectPooling;

namespace ScObjectPooling
{
	class Program
	{
		static void Main(string[] args)
		{
			const int NumberOfThreads = 10;

			//create multiple test objects, each with
			//its own thread that calls the test method
			ObjectPoolingTest[] testObjs
				= new ObjectPoolingTest[NumberOfThreads];
			for (int i = 0; i < NumberOfThreads; i++)
			{
				testObjs[i] = new ObjectPoolingTest();
			}

			//start all tests
			for (int i = 0; i < NumberOfThreads; i++)
			{
				testObjs[i].Test();
			}

			//Console.WriteLine("Press enter to run VB.NET tests");
			Console.Read();

			TestVB.Test();
		}
	}
}

