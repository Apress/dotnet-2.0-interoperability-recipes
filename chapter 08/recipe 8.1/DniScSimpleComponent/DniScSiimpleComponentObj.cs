using System;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace DniScSimpleComponent
{
	public interface IAddNumbers
	{
		int AddSomeNumbers(int numA, int numB);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniScSimpleComponentObj 
		: ServicedComponent, IAddNumbers
	{
		public int AddSomeNumbers(int numA, int numB)
		{
			return numA + numB;
		}
	}
}
