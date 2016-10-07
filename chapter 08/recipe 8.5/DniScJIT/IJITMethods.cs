using System;

namespace DniScJIT
{
	public interface IJITMethods
	{
		//stateful methods
		void AddNumber(int number);
		int GetTotal();

		//stateless methods
		int AddSomeNumbers(int numA, int numB);
	}
}
