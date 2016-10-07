using System;
using System.Runtime.InteropServices;

using DniComResultsLib;

namespace ComResultsRefactored
{
	class ComResultsRefactoredTest
	{
		static void Main(string[] args)
		{
			//create an instance of the COM object				
			DniComResultsObj comObj = new DniComResultsObjClass();

			//call the original method 
			MakeTheCall(comObj, 0);
			MakeTheCall(comObj, 1);
			MakeTheCall(comObj, 2);
			MakeTheCall(comObj, 3);

			//call the refactored method 
			MakeTheRefactoredCall(comObj, 0);
			MakeTheRefactoredCall(comObj, 1);
			MakeTheRefactoredCall(comObj, 2);
			MakeTheRefactoredCall(comObj, 3);

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read();
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
				comObj.GetTheResult(request);
				Console.WriteLine(
					"No Exception: request {0}", request);
			}
			catch (Exception e)
			{
				int hResult = Marshal.GetHRForException(e);
				Console.WriteLine(
					"Exception: request: {0}, type: {1}, HRESULT: {2:X}",
					request, e.GetType().Name, hResult);
			}
		}

		/// <summary>
		/// Call the ATL COM object
		/// </summary>
		/// <param name="comObj"></param>
		/// <param name="request"></param>
		private static void MakeTheRefactoredCall(DniComResultsObj comObj,
				int request)
		{
			try
			{
				int hResult
					= comObj.GetTheResultRefactored(request);
				Console.WriteLine(
					"No Exception: request {0}, HRESULT: {1:X}", 
						request, hResult);
			}
			catch (Exception e)
			{
				int hResult = Marshal.GetHRForException(e);
				Console.WriteLine(
					"Exception: request: {0}, type: {1}, HRESULT: {2:X}",
					request, e.GetType().Name, hResult);
			}
		}


	}
}
