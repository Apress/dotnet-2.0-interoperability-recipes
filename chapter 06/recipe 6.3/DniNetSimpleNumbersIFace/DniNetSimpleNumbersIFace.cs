using System;
using System.Runtime.InteropServices; //needed for attributes

namespace DniNetSimpleNumbersIFace
{
	/// <summary>
	/// An interface for classes that do addition
	/// </summary>
	public interface IAddNumbers
	{
		int AddSomeNumbers(int numA, int numB);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetSimpleNumbersIFace : IAddNumbers
	{
		public int AddSomeNumbers(int numA, int numB)
		{
			return numA + numB;
		}
	}
}
