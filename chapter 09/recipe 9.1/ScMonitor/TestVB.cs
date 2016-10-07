using System;

using DniScMonitorVB;

//tests VB.NET version of the code

namespace ScMonitor
{
	public class TestVB
	{
		public static void Test()
		{
			ITranMonitor obj
				= new DniScMonitorObj();
			obj.LogTransactionDetails();
		}
	}
}
