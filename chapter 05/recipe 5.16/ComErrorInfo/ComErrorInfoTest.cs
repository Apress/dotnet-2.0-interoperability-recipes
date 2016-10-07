using System;

using DniErrorInfoLib;
using Interop.DniErrorInfoVB;

namespace ComErrorInfo
{
	class ComErrorInfoTest
	{
		static void Main(string[] args)
		{
			DniErrorInfoObj comObj
				= new DniErrorInfoObjClass();

			CallTheMethod(comObj, 1);
			CallTheMethod(comObj, 2);
			CallTheMethod(comObj, 3);
			CallTheMethod(comObj, 4);

			DniErrorInfoVBObj vbComObj
				= new DniErrorInfoVBObjClass();

			CallTheMethod(vbComObj, 1);
			CallTheMethod(vbComObj, 2);
			CallTheMethod(vbComObj, 3);
			CallTheMethod(vbComObj, 4);

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read();
		}

		static private void CallTheMethod(
			DniErrorInfoObj comObj, int request)
		{
			try
			{
				comObj.GenerateError(request);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: {0}, {1}, {2}",
					e.GetType().Name,
					e.Message,
					e.Source);
			}
		}

		static private void CallTheMethod(
			DniErrorInfoVBObj comObj, int request)
		{
			try
			{
				comObj.GenerateError(request);
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: {0}, {1}, {2}",
					e.GetType().Name,
					e.Message,
					e.Source);
			}
		}



	}
}
