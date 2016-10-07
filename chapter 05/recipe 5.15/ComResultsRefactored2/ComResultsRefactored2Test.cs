using System;
using System.Runtime.InteropServices;

using Interop.DniComResults;

namespace ComResultsRefactored2
{
	class ComResultsRefactored2Test
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

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read();
		}

		private static void MakeTheCall(DniComResultsObj comObj,
				int request)
		{
			try
			{
				int hr = comObj.GetTheResult(request);
				Console.WriteLine(
					"No Exception: request {0}, HRESULT {1:X}", 
					request, hr);
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
