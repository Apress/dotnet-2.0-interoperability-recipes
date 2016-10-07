using System;
using System.Runtime.InteropServices;

namespace DniNetInOut
{
	public interface IDirectionTester
	{
		void IntInOnly(int paramA, int paramB);
		void IntInAndOut(int paramA, [In,Out] int paramB);
		void IntByRef(int paramA, ref int paramB);
		void IntByRefInOnly(int paramA, [In] ref int paramB);
		void IntOut(int paramA, out int paramB);
		void StringsInOnly(string paramA, string paramB);
		void StringsInAndOut(string paramA, [In,Out] string paramB);
		void StringsByRef(string paramA, ref string paramB);
		void StringsByRefInOnly(string paramA, [In] ref string paramB);
		void StringsOut(string paramA, out string paramB);
		void DateTimeInOnly(DateTime paramA, DateTime paramB);
		void DateTimeInAndOut(DateTime paramA, [In,Out] DateTime paramB);
		void DateTimeByRef(DateTime paramA, ref DateTime paramB);
		void DateTimeByRefInOnly(DateTime paramA, [In] ref DateTime paramB);
		void DateTimeOut(DateTime paramA, out DateTime paramB);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetInOutObj : IDirectionTester 
	{
		//blittable type - by value
		public void IntInOnly(int paramA, int paramB)
		{
			paramB = paramA;
		}
		//blittable type - by value, with out attribute
		public void IntInAndOut(int paramA, int paramB)
		{
			paramB = paramA;
		}
		//blittable type - by ref
		public void IntByRef(int paramA, ref int paramB)
		{
			paramB = paramA;
		}
		//blittable type - by ref, with in attribute
		public void IntByRefInOnly(int paramA, ref int paramB)
		{
			paramB = paramA;
		}
		//blittable type - out
		public void IntOut(int paramA, out int paramB)
		{
			paramB = paramA;
		}

		//reference type - by value
		public void StringsInOnly(string paramA, string paramB)
		{
			paramB = paramA;
		}
		//reference type - by value, with out attribute
		public void StringsInAndOut(string paramA, string paramB)
		{
			paramB = paramA;
		}
		//reference type - by ref
		public void StringsByRef(string paramA, ref string paramB)
		{
			paramB = paramA;
		}
		//reference type - by ref, with in attribute
		public void StringsByRefInOnly(
			string paramA, ref string paramB)
		{
			paramB = paramA;
		}
		//reference type - out
		public void StringsOut(string paramA, out string paramB)
		{
			paramB = paramA;
		}

		//value type - by value
		public void DateTimeInOnly(
			DateTime paramA, DateTime paramB)
		{
			paramB = paramA;
		}
		//value type - by value, with out attribute
		public void DateTimeInAndOut(
			DateTime paramA, DateTime paramB)
		{
			paramB = paramA;
		}
		//value type - by ref
		public void DateTimeByRef(
			DateTime paramA, ref DateTime paramB)
		{
			paramB = paramA;
		}
		//value type - by ref, with in attribute
		public void DateTimeByRefInOnly(
			DateTime paramA, ref DateTime paramB)
		{
			paramB = paramA;
		}
		//value type - out
		public void DateTimeOut(
			DateTime paramA, out DateTime paramB)
		{
			paramB = paramA;
		}

	}
}
