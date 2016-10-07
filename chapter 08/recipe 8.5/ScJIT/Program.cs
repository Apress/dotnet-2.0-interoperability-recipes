using System;
using DniScJIT;

namespace ScJIT
{
	class Program
	{
		static void Main(string[] args)
		{
			IJITMethods obj	= new DniScNotJITObj();
			ExecuteMethods(obj, "Non-JIT component");

			obj	= new DniScJITObj();
			ExecuteMethods(obj, "JIT component");

			TestVB.Test();

			Console.Read();
		}

		static void ExecuteMethods(IJITMethods obj, string desc)
		{
			//add numbers the stateful way
			obj.AddNumber(1);
			obj.AddNumber(2);
			int result = obj.GetTotal();
			Console.WriteLine(
				"GetTotal result from {0}: {1}",
				desc, result);

			//add numbers statelessly
			result = obj.AddSomeNumbers(1, 2);
			Console.WriteLine(
				"AddSomeNumbers result from {0}: {1}",
				desc, result);
		}
	}
}

