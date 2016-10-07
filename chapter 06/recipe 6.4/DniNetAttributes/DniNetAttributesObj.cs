using System;
using System.Runtime.InteropServices;

namespace DniNetAttributes
{
//	[Guid("406DD97B-8C4F-4fd6-A6D4-6F71103184A3")]
	public interface IComAttributes
	{
		void Foo();
	}

//	[Guid("E4B81256-1727-4a1e-99CF-2ECED97B43B4")]
//	[ProgId("DniNetAttributes.DniNetAttributesModified")]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetAttributesObj : IComAttributes
	{
		public void Foo()
		{
		}
	}
}
