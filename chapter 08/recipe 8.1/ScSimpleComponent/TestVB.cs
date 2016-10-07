using System;
using DniScSimpleComponentVB;

//tests the vb version of the simple com+ component

namespace ScSimpleComponent
{
	class TestVB
	{
		public static void Test()
		{
			IAddNumbers obj
				= new DniScSimpleComponentObj();
			int result = obj.AddSomeNumbers(1, 2);
			Console.WriteLine(
				"AddSomeNumbers using COM+ Library: {0}",
				result);

			Console.Read();
		}
	}
}
