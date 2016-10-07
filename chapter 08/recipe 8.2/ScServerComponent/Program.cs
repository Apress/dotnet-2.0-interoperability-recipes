using System;
using DniScServerComponent;

namespace ScServerComponent
{
	class Program
	{
		static void Main(string[] args)
		{
			IAddNumbers obj
				= new DniScServerComponentObj();
			int result = obj.AddSomeNumbers(1, 2);
			Console.WriteLine(
				"AddSomeNumbers using COM+ Server App: {0}",
				result);

			TestVB.Test();

			Console.Read();
		}
	}
}

