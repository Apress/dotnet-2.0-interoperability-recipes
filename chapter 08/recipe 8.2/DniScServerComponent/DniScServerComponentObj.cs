using System;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace DniScServerComponent
{
	[Description("Interface used to add numbers")]
	public interface IAddNumbers
	{
		int AddSomeNumbers(int numA, int numB);
	}

	[ClassInterface(ClassInterfaceType.None)]
	[Description("Add numbers server component")]
	public class DniScServerComponentObj
		: ServicedComponent, IAddNumbers
	{
		public int AddSomeNumbers(int numA, int numB)
		{
			return numA + numB;
		}
	}
}
