using System;
using System.Threading;

using DniThreadingLib;

namespace ComThreading
{
	class ComThreadingTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
//		[STAThread]
		[MTAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("Original ApartmentState: {0}",
				Thread.CurrentThread.GetApartmentState());

			int result = 0;
			DniThreadingStaObj staObj 
				= new DniThreadingStaObjClass();
			result = staObj.AddNumbers(1, 2);
			Console.WriteLine("STA Obj result: {0}, Threading: {1}",
				result, Thread.CurrentThread.GetApartmentState());

			//attempt a change to the apartment model
			//with SetApartmentState
			try
			{
				Thread.CurrentThread.SetApartmentState(
					ApartmentState.MTA);
				Console.WriteLine(
					"No Exception calling SetApartmentState");
			}
			catch (InvalidOperationException e)
			{
				Console.WriteLine(
					"Exception calling SetApartmentState: {0}",
					e.Message);
			}

			//attempt a change to the apartment model
			//with TrySetApartmentState
			try
			{
				bool changeStatus = 
					Thread.CurrentThread.TrySetApartmentState(
						ApartmentState.MTA);
				Console.WriteLine(
					"TrySetApartmentState result {0}",
						changeStatus);
			}
			catch (InvalidOperationException e)
			{
				Console.WriteLine(
					"Exception calling TrySetApartmentState: {0}",
					e.Message);
			}

			DniThreadingMtaObj mtaObj 
				= new DniThreadingMtaObjClass();
			result = mtaObj.AddNumbers(1, 2);
			Console.WriteLine("MTA Obj result: {0}, Threading: {1}",
				result, Thread.CurrentThread.GetApartmentState());

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read();
		}
	}
}
