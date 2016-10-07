using System;
using System.Threading;
using DniScObjectPooling;
using System.Diagnostics;

namespace ScObjectPooling
{
	public class ObjectPoolingTest
	{
		private Thread thread;

		public ObjectPoolingTest()
		{
			thread = new Thread(new ThreadStart(ThreadProc));
		}

		public void Test()
		{
			thread.Start();
		}

		public static void ThreadProc()
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			for (int i = 0; i < 100; i++)
			{
				IObjectPoolingMethods obj
					= new DniScObjectPooling.DniScObjectPoolingObj();
				int keyCode = obj.LookupKeyCode("BBB");
			}
			sw.Stop();
			Console.WriteLine(
				"Elapsed time for thread: {0}ms",
				sw.ElapsedMilliseconds);
		}
	}
}
