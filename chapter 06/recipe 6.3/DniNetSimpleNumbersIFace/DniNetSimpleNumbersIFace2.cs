using System;
using System.Runtime.InteropServices; //needed for attributes

namespace DniNetSimpleNumbersIFace
{
	/// <summary>
	/// An interface for classes that do addition
	/// and subtraction
	/// </summary>
//	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IAddSubtractNumbers : IAddNumbers
	{
		int SubtractSomeNumbers(int numA, int numB);
	}

	[ClassInterface(ClassInterfaceType.None)]
//	[ComDefaultInterface(typeof(IAddNumbers))]
	public class DniNetSimpleNumbersIFace2 : IAddSubtractNumbers
	{
		public int AddSomeNumbers(int numA, int numB)
		{
			return numA + numB;
		}
		public int SubtractSomeNumbers(int numA, int numB)
		{
			return numA - numB;
		}

	}
}
