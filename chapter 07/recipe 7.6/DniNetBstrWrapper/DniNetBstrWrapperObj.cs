using System;
using System.Runtime.InteropServices;

namespace DniNetBstrWrapper
{
	public interface IStringHelper
	{
		Object GetString();
		Object GetNullString();
		Object GetNullStringWithWrapper();
		Object GetStringWithWrapper();
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetBstrWrapperObj : IStringHelper
	{
		public object GetString()
		{
			return "MyString";
		}

		public object GetNullString()
		{
			return null;
		}

		public object GetNullStringWithWrapper()
		{
			return new BStrWrapper(null);
		}

		public object GetStringWithWrapper()
		{
			return new BStrWrapper("MyString");
		}
	}
}
