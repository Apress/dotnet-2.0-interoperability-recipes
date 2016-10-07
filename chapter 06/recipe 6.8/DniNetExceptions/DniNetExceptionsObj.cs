using System;
using System.Runtime.InteropServices;

namespace DniNetExceptions
{
	public class CustomException : ApplicationException
	{
		public CustomException(string msg)
			: base(msg)
		{
		}
	}

	public class CustomExceptionWithHResult : ApplicationException
	{
		public CustomExceptionWithHResult(string msg)
			: base(msg)
		{
			this.HResult = unchecked((int)0x80040301);
		}
	}

	public interface IExceptions
	{
		void ThrowStandardException();
		void ThrowCustomException();
		void ThrowCustomExceptionWithHResult();
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetExceptionsObj : IExceptions
	{
		public void ThrowStandardException()
		{
			throw new ApplicationException(
				"This is an ApplicationException");
		}

		public void ThrowCustomException()
		{
			throw new CustomException("My custom exception message");
		}

		public void ThrowCustomExceptionWithHResult()
		{
			throw new CustomExceptionWithHResult(
				"My custom exception message with HResult");
		}
	}
}
