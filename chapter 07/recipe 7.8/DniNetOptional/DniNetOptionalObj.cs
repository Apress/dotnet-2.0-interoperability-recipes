using System;
using System.Runtime.InteropServices;

namespace DniNetOptional
{
	public interface IOptional
	{
		int AddOptionalNumbers(int numA,
			[Optional, DefaultParameterValue(1)]
			int numB,
			[Optional, DefaultParameterValue(2)]
			int numC);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetOptionalObj : IOptional
	{
		public int AddOptionalNumbers(int numA,
			int numB, int numC)
		{
			return numA + numB + numC;
		}
	}
}
