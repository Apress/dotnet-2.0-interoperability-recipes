using System;
using DniScSimpleComponent;

namespace ScSimpleComponent
{
	class Program
	{
		static void Main(string[] args)
		{
			IAddNumbers obj
				= new DniScSimpleComponentObj();
			int result = obj.AddSomeNumbers(1, 2);
			Console.WriteLine(
				"AddSomeNumbers using COM+ Library: {0}",
				result);

			TestVB.Test();

			Console.Read();
		}
	}
}
