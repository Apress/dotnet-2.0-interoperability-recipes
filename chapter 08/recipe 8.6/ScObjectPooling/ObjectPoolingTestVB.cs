using System;
using System.Threading;
using DniScObjectPoolingVB;
using System.Diagnostics;

//tests the vb.net version of these classes

namespace ScObjectPooling
{
	public class ObjectPoolingTestVB
	{
		private Thread thread;

		public ObjectPoolingTestVB()
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
					= new DniScObjectPoolingObj();
				int keyCode = obj.LookupKeyCode("BBB");
			}
			sw.Stop();
			Console.WriteLine(
				"Elapsed time for thread: {0}ms",
				sw.ElapsedMilliseconds);
		}
	}
}
