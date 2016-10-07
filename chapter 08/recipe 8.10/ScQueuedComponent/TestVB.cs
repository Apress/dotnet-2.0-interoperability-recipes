using System;
using System.Runtime.InteropServices;

using DniScQueuedComponentVB;

//test the VB.NET version of the QC components

namespace ScQueuedComponent
{
	public class TestVB
	{
		public static void Test()
		{
			LogTheMessage("message one VB");
			LogTheMessage("message two VB");

			Console.WriteLine("Press any key to continue");
			Console.Read();
		}

		private static void LogTheMessage(string message)
		{
			IQueuedComponent obj
				= Marshal.BindToMoniker(
				"queue:/new:DniScQueuedComponentVB.DniScQCObj")
				as IQueuedComponent;

			if (obj != null)
			{
				obj.LogMessage(message);
			}
		}
	}
}
