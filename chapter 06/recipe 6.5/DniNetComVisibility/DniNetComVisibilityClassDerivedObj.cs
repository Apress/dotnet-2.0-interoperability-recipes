using System;
using System.Runtime.InteropServices;

namespace DniNetComVisibility
{
	[ComVisible(false)]
	public class DniNetComVisibilityClassBaseObj
	{
		[ComVisible(false)]
		public void Method1()
		{
		}
	}

	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class DniNetComVisibilityClassDerivedObj
		: DniNetComVisibilityClassBaseObj
	{
		public void Method2()
		{
		}
	}
}
