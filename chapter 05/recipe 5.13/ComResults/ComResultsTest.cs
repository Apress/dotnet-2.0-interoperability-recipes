using System;
using System.Runtime.InteropServices;

using Interop.DniComResultsVB;
using DniComResultsLib;

namespace ComResults
{
	class ComResultsTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			TestHResults();
			TestHResultsVB();

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read();
		}

		private static void TestHResults()
		{
			//create an instance of the COM object				
			DniComResultsObj comObj = new DniComResultsObjClass();

			//call the object with different requests				
			MakeTheCall(comObj, 0);
			MakeTheCall(comObj, 1);
			MakeTheCall(comObj, 2);
			MakeTheCall(comObj, 3);
			MakeTheCall(comObj, 4);
			MakeTheCall(comObj, 5);
		}

		/// <summary>
		/// Call the ATL COM object
		/// </summary>
		/// <param name="comObj"></param>
		/// <param name="request"></param>
		private static void MakeTheCall(DniComResultsObj comObj, 
				int request)
		{
			try
			{
				comObj.ProvideDifferentResults(request);
				Console.WriteLine(
					"No Exception for request: {0}", request);
			}
			catch (Exception e)
			{
				int hResult = Marshal.GetHRForException(e);
				Console.WriteLine(
					"Exception: request: {0}, type: {1}, HRESULT: {2:X}",
					request, e.GetType().Name, hResult);
			}
		}

		private static void TestHResultsVB()
		{
			//create an instance of the VB COM object
			DniComResultsVBObj comObj 
				= new DniComResultsVBObjClass();

			MakeTheCallVB(comObj, 1);
			MakeTheCallVB(comObj, 2);
		}

		/// <summary>
		/// Call the VB COM object
		/// </summary>
		/// <param name="comObj"></param>
		/// <param name="request"></param>
		private static void MakeTheCallVB(
				DniComResultsVBObj comObj, int request)
		{
			try
			{
				//make the call					
				comObj.ProvideDifferentResults(request);
				Console.WriteLine(
					"No Exception for request: {0}", request);
			}
			catch (Exception e)
			{
				//catch and display the exception
				int hResult = Marshal.GetHRForException(e);
				Console.WriteLine(
					"Exception: request: {0}, type: {1}, HRESULT: {2:X}",
					request, e.GetType().Name, hResult);
			}
		}

	}
}
