using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DniNetStrings
{
	public interface IStrings
	{
		string ReturnBSTR(string paramA, string paramB);

		void InOutBSTR(string paramA, string paramB, 
			ref string result);

		void OutBSTR(string paramA, string paramB,
			out string result);

		void InOutBuilder(string paramA, string paramB,
			StringBuilder result);

		//VB6 doesn't support the data types that follow.
		//but we can still access these methods from unmanaged C++ 
	
		[return: MarshalAs(UnmanagedType.LPWStr)]
		string ReturnLPWSTR(string paramA, string paramB);

		[return: MarshalAs(UnmanagedType.LPStr)]
		string ReturnLPSTR(string paramA, string paramB);

		[return: MarshalAs(UnmanagedType.LPWStr)]
		string PassAndReturnLPWSTR(
			[MarshalAs(UnmanagedType.LPWStr)] string paramA,
			[MarshalAs(UnmanagedType.LPWStr)] string paramB);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetStringsObj : IStrings
	{
		public string ReturnBSTR(string paramA, string paramB)
		{
			return paramA + paramB;
		}

		public void InOutBSTR(string paramA, string paramB, 
			ref string result)
		{
			result = paramA + paramB;
		}

		public void OutBSTR(string paramA, string paramB,
			out string result)
		{
			result = paramA + paramB;
		}

		public void InOutBuilder(string paramA, string paramB,
			StringBuilder result)
		{
			//since the StringBuilder is passed to us with a
			//fixed buffer size, we need to make sure we
			//have sufficient capacity to hold the new string
			int newStringSize = paramA.Length + paramB.Length;
			//this throws an exception if insufficient capacity
			result.EnsureCapacity(newStringSize);

			//first remove the current string if any
			result.Remove(0, result.Length);
			//append the new strings
			result.Append(paramA);
			result.Append(paramB);
		}

		public string ReturnLPWSTR(string paramA, string paramB)
		{
			return paramA + paramB;
		}

		public string ReturnLPSTR(string paramA, string paramB)
		{
			return paramA + paramB;
		}

		public string PassAndReturnLPWSTR(string paramA,string paramB)
		{
			return paramA + paramB;
		}
	}
}
