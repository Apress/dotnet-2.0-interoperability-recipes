using System;
using DniScTranScopeVB;

//test the VB.NET version of the class

namespace ScTranScope
{
	public class TestVB
	{
		public static void Test()
		{
			ILocalScope obj
				= new DniScTranScopeObj();
			obj.UseLocalScope(true);
			obj.UseLocalScope(false);
		}
	}
}
