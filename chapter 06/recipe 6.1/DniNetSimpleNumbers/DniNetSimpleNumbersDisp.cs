using System;
	
namespace DniNetSimpleNumbers
{
	/// <summary>
	/// Managed class exposed to COM clients using
	/// the default Class Interface
	/// </summary>
	public class DniNetSimpleNumbersDisp
	{
		public int AddSomeNumbers(int numA, int numB)
		{
			return numA + numB;
		}
		public void foo() {}
	}
}
