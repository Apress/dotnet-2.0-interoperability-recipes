using System;
using System.Runtime.InteropServices;

using DniDataTypesLib;

namespace ComVariants
{
	class ComVariantsTest
	{
		static void Main(string[] args)
		{
			//create an instance of the COM object				
			DniDataTypesObj comObj = new DniDataTypesObj();
			string desc = string.Empty;

			//a variable used to return any VARIANT value
			Object result = null;

			Boolean testVariantBool	= true;				
			desc = comObj.UseVariant(testVariantBool, out result);
			Console.WriteLine("Test Variant Bool: {0}, {1}, {2}",
				testVariantBool.GetType().Name, 
				result.GetType().Name, desc);

			int testVariantInt = 123;
			desc = comObj.UseVariant(testVariantInt, out result);
			Console.WriteLine("Test Variant Int: {0}, {1}, {2}",
				testVariantInt.GetType().Name,
				result.GetType().Name, desc);

			long testVariantLong = 123;
			desc = comObj.UseVariant(testVariantLong, out result);
			Console.WriteLine("Test Variant Long: {0}, {1}, {2}",
				testVariantLong.GetType().Name,
				result.GetType().Name, desc);

			string testVariantString = "test string";
			desc = comObj.UseVariant(testVariantString, out result);
			Console.WriteLine("Test Variant String: {0}, {1}, {2}",
				testVariantString.GetType().Name,
				result.GetType().Name, desc);

			object testVariantObject = new object();
			desc = comObj.UseVariant(testVariantObject, out result);
			Console.WriteLine("Test Variant Object: {0}, {1}, {2}",
				testVariantObject.GetType().Name,
				result.GetType().Name, desc);

			object testVariantNull = null;
			desc = comObj.UseVariant(testVariantNull, out result);
			string returnType;
			if (result == null)
			{
				returnType = "null";
			}
			else
			{
				returnType = result.GetType().Name;
			}
			Console.WriteLine("Test Variant Null: {0}, {1}, {2}",
				"null", returnType, desc); 

			double testVariantDouble = 123.45;
			desc = comObj.UseVariant(testVariantDouble, out result);
			Console.WriteLine("Test Variant Double: {0}, {1}, {2}",
				testVariantDouble.GetType().Name,
				result.GetType().Name, desc);

			decimal testVariantDecimal = 123.45m;
			desc = comObj.UseVariant(testVariantDecimal, out result);
			Console.WriteLine("Test Variant Decimal: {0}, {1}, {2}",
				testVariantDecimal.GetType().Name,
				result.GetType().Name, desc);

			DateTime testVariantDate = new DateTime(2005, 12, 31);
			desc = comObj.UseVariant(testVariantDate, out result);
			Console.WriteLine("Test Variant Date: {0}, {1}, {2}",
				testVariantDate.GetType().Name,
				result.GetType().Name, desc);

			CurrencyWrapper testVariantCurrency = new CurrencyWrapper(123.45m);
			desc = comObj.UseVariant(testVariantCurrency, out result);
			Console.WriteLine("Test Variant Currency: {0}, {1}, {2}",
				testVariantCurrency.GetType().Name,
				result.GetType().Name, desc);

			IntPtr testVariantIntPtr = IntPtr.Zero;
			desc = comObj.UseVariant(testVariantIntPtr, out result);
			Console.WriteLine("Test Variant IntPtr: {0}, {1}, {2}",
				testVariantIntPtr.GetType().Name,
				result.GetType().Name, desc);

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read(); 	    

		}
	}
}
