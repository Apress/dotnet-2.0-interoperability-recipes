using System;
using DniScServerComponentVB;

//tests the vb.net version of this component

namespace ScServerComponent
{
	public class TestVB
	{
		public static void Test()
		{
			IAddNumbers obj
				= new DniScServerComponentObj();
			int result = obj.AddSomeNumbers(1, 2);
			Console.WriteLine(
				"AddSomeNumbers using COM+ Server App: {0}",
				result);

			Console.Read();
		}
	}
}
