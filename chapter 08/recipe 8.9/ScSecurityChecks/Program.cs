using System;
using System.Runtime.InteropServices;
using DniScSecurityChecks;

namespace ScSecurityChecks
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ISecuredMethods obj
					= new DniScSecurityChecksObj();

				bool isSecurityEnabled = obj.IsSecurityEnabled();
				Console.WriteLine(
					"IsSecurityEnabled: {0}", isSecurityEnabled);
				isSecurityEnabled = obj.IsSecurityEnabledAlt();
				Console.WriteLine(
					"IsSecurityEnabledAlt: {0}", isSecurityEnabled);

				bool isInRole = obj.ManualSecurityCheck();
				Console.WriteLine(
					"ManualSecurityCheck: {0}", isInRole);
				isInRole = obj.ManualSecurityCheckAlt();
				Console.WriteLine(
					"ManualSecurityCheckAlt: {0}", isInRole);

				string caller = obj.GetCaller();
				Console.WriteLine(
					"GetCaller: {0}", caller);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"Exception: {0}",
					e.Message);
			}

			Console.Read();
		}
	}
}
