using System;
using System.Runtime.InteropServices;

namespace DniNetVariants
{
	public interface IVariants
	{
		string UseVariant(Object inParam, ref Object outParam);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetVariantsObj : IVariants
	{
		public string UseVariant(object inParam, ref object outParam)
		{
			//copy the input param to the output
			outParam = inParam;

			//return the type description
			return inParam.GetType().Name;
		}
	}
}
