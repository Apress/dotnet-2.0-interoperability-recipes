using System;
using System.Runtime.InteropServices;

namespace DniNetComVisibility
{
	public interface IComVisibility
	{
		[ComVisible(false)]
		void Method1();
		void Method2();
		[ComVisible(false)]
		int Property1 { get;set;}
		int Property2 { get;set;}
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetComVisibilityObj : IComVisibility	
	{
		public void Method1()
		{
		}

		public void Method2()
		{
		}

		public int Property1
		{
			get{return 0;}
			set{}
		}

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
