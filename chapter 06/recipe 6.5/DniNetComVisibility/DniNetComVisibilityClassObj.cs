using System;
using System.Runtime.InteropServices;

namespace DniNetComVisibility
{
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class DniNetComVisibilityClassObj
	{
		public void Method1()
		{
		}

		[ComVisible(false)]
		public void Method2()
		{
		}

		public int Property1
		{
			get{return 0;}
			set{}
		}

		[ComVisible(false)]
		public int Property2
		{
			get{return 0;}
			set{}
		}

		protected void ProtectedMethod1()
		{
		}

		private void PrivateMethod1()
		{
		}

	}
}
