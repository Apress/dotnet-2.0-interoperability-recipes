using System;
using System.Runtime.InteropServices; //needed for attribute
	
namespace DniNetSimpleNumbersDual
{
	/// <summary>
	/// Managed class exposed to COM clients
	/// via dual interface
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class DniNetSimpleNumbersDual
	{
		public int AddSomeNumbers(int numA, int numB)
		{
			return numA + numB;
		}
	}
}
