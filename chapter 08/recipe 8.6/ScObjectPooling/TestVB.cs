using System;

//tests the vb.net version of these classes

namespace ScObjectPooling
{
	public class TestVB
	{
		public static void Test()
		{
			const int NumberOfThreads = 10;

			//create multiple test objects, each with
			//its own thread that calls the test method
			ObjectPoolingTestVB[] testObjs
				= new ObjectPoolingTestVB[NumberOfThreads];
			for (int i = 0; i < NumberOfThreads; i++)
			{
				testObjs[i] = new ObjectPoolingTestVB();
			}

			//start all tests
			for (int i = 0; i < NumberOfThreads; i++)
			{
				testObjs[i].Test();
			}

			Console.Read();
			Console.Read();
		}
	}
}
