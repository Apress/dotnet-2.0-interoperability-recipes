using System;
using System.Runtime.InteropServices;

namespace DniNetCurrency
{
	public interface ICurrency
	{
		string UseNativeVariant(Object inParam, ref Object outParam);

		string UseVariantCurrency(Object inParam, ref Object outParam);

		string UseDecimalCurrency(
			[MarshalAs(UnmanagedType.Currency)]
			Decimal inParam, 
			[MarshalAs(UnmanagedType.Currency)]
			ref Decimal outParam);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetCurrencyObj : ICurrency
	{
		public string UseNativeVariant(
			Object inParam, ref Object outParam)
		{
			outParam = inParam;
			return inParam.GetType().Name;
		}

		public string UseVariantCurrency(
			Object inParam, ref Object outParam)
		{
			outParam = new CurrencyWrapper(inParam);
			return inParam.GetType().Name;
		}

		public string UseDecimalCurrency(
			Decimal inParam, ref Decimal outParam)
		{
			outParam = inParam;
			return inParam.GetType().Name;
		}
	}
}
