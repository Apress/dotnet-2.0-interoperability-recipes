using System;
using System.Runtime.InteropServices;

namespace DniNetArrays
{
	public interface IArrays
	{
		int[] ReturnIntArray();
		int SumIntArray(ref int[] elements);
		int UpdateIntArray(ref int[] elements);
		int UpdateIntArrayInOnly([In]ref int[] elements);
		int SumStringArray(ref string[] elements);
		int UpdateStringArray(ref string[] elements);
		int UpdateStringArrayInOnly([In]ref string[] elements);

		//the following methods pass an array by value
		//instead of by reference. Passing arrays by value
		//is not supported by VB6. However, these methods
		//can be used by other languages such as C++.
		int UpdateIntArrayByValue(int[] elements); 
		int UpdateIntArrayByValueInOut([In, Out]int[] elements);
		int SumStringArrayByValue(string[] elements);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetArraysObj : IArrays
	{
		public int[] ReturnIntArray()
		{
			int[] result = new int[5];
			result[0] = 0;
			result[1] = 1;
			result[2] = 22;
			result[3] = 333;
			result[4] = 4444;
			return result;
		}

		public int SumIntArray(ref int[] elements)
		{
			int result = 0;
			foreach(int element in elements)
			{
				result += element;
			}
			return result;
		}

		public int UpdateIntArray(ref int[] elements)
		{
			int result = 0;
			for (int i = 0; i < elements.Length; i++)
			{
				//update each element by adding 1000 
				elements[i] = elements[i] + 1000;
				result += elements[i];
			}
			return result;
		}

		public int UpdateIntArrayInOnly(ref int[] elements)
		{
			return UpdateIntArray(ref elements);
		}

		public int UpdateIntArrayByValue(int[] elements)
		{
			return UpdateIntArray(ref elements);
		}

		public int UpdateIntArrayByValueInOut(int[] elements)
		{
			return UpdateIntArray(ref elements);
		}

		public int SumStringArray(ref string[] elements)
		{
			int result = 0;
			foreach(string element in elements)
			{
				result += element.Length;
			}
			return result;
		}

		public int UpdateStringArray(ref string[] elements)
		{
			int result = 0;
			for (int i = 0; i < elements.Length; i++)
			{
				//append a literal to each string element
				elements[i] += "extra";
				result += elements[i].Length;
			}
			return result;
		}

		public int UpdateStringArrayInOnly(ref string[] elements)
		{
			return UpdateStringArray(ref elements);
		}

		public int SumStringArrayByValue(string[] elements)
		{
			int result = 0;
			foreach (string element in elements)
			{
				result += element.Length;
			}
			return result;
		}
	}
}
