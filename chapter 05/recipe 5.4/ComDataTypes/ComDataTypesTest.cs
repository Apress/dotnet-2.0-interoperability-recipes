using System;

using DniDataTypesLib;	//the RCW for the COM component

namespace ComDataTypes
{
	class ComDataTypesTest
	{
		static void Main(string[] args)
		{
			//create an instance of the COM object				
			DniDataTypesObj comObj = new DniDataTypesObj();
			
			sbyte outUseBool	= 0;
			comObj.UseBool(1, ref outUseBool);
			Console.WriteLine("UseBoolean: {0}, {1}",
				outUseBool.GetType().Name, outUseBool);

			bool outUseVariantBool = false;
			comObj.UseVariantBool(true, ref outUseVariantBool);
			Console.WriteLine("UseVariantBool: {0}, {1}",
				outUseVariantBool.GetType().Name, outUseVariantBool);

			int outUseLong = 0;
			comObj.UseLong(123, ref outUseLong);
			Console.WriteLine("UseLong: {0}, {1}",
				outUseLong.GetType().Name, outUseLong);

			double outUseDouble = 0.0;
			comObj.UseDouble(45.67, ref outUseDouble);
			Console.WriteLine("UseDouble: {0}, {1}",
				outUseDouble.GetType().Name, outUseDouble);

			string outUseBSTR = "orig string out";
			comObj.UseBSTR("input string", ref outUseBSTR);
			Console.WriteLine("UseBSTR: {0}, {1}",
				outUseBSTR.GetType().Name, outUseBSTR);

			string outUseLPSTR = String.Empty;
			comObj.UseLPSTR("input string", ref outUseLPSTR);
			Console.WriteLine("UseLPSTR: {0}, {1}",
				outUseLPSTR.GetType().Name, outUseLPSTR);

			decimal outUseDecimal = 0;
			comObj.UseDecimal(9876.54m, ref outUseDecimal);
			Console.WriteLine("UseDecimal: {0}, {1}",
				outUseDecimal.GetType().Name, outUseDecimal);

			decimal outUseCurrency = 0;
			comObj.UseCurrency(9876.54m, ref outUseCurrency);
			Console.WriteLine("UseCurrency: {0}, {1}",
				outUseCurrency.GetType().Name, outUseCurrency);

			DateTime outUseDate = new DateTime();
			comObj.UseDate(new DateTime(2005,12,31), ref outUseDate);
			Console.WriteLine("UseDate: {0}, {1}",
				outUseDate.GetType().Name, outUseDate);

			byte outUseChar = (byte)0;
			comObj.UseChar((byte)'z', ref outUseChar);
			Console.WriteLine("UseChar: {0}, {1}",
				outUseChar.GetType().Name, outUseChar);

			sbyte outUseComChar = (sbyte)0;
			comObj.UseComCHAR((sbyte)'a', ref outUseComChar);
			Console.WriteLine("UseComChar: {0}, {1}",
				outUseComChar.GetType().Name, outUseComChar);

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read(); 	    
		}
	}
}
