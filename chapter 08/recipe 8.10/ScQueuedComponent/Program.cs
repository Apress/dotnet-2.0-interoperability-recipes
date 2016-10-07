using System;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

using DniScQueuedComponent;

namespace ScQueuedComponent
{
	class Program
	{
		static void Main(string[] args)
		{
			LogTheMessage("message one");
			LogTheMessage("message two");

			TestVB.Test();

			Console.WriteLine("Press any key to continue");
			Console.Read();
		}

		static void LogTheMessage(string message)
		{
			IQueuedComponent obj
				= Marshal.BindToMoniker(
				"queue:/new:DniScQueuedComponent.DniScQCObj")
//				"queue:MaxTimeToReceive=15/new:DniScQueuedComponent.DniScQCObj")				
				as IQueuedComponent;
			
			if (obj != null)
			{
				obj.LogMessage(message);
			}
		}
	}
}
