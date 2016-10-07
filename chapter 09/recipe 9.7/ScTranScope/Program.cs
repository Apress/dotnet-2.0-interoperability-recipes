using System;
using DniScTranScope;

namespace ScTranScope
{
	class Program
	{
		static void Main(string[] args)
		{
			ILocalScope obj
				= new DniScTranScopeObj();
			obj.UseLocalScope(true);
			obj.UseLocalScope(false);

			TestVB.Test();

			Console.WriteLine("Press enter to continue");
			Console.Read();
		}
	}
}
