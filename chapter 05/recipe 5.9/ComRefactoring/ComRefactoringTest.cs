using System;

using Interop.DniComRefactorVB;

namespace ComRefactoring
{
	/// <summary>
	/// Tests a COM component using refactored methods
	/// </summary>
	class ComRefactoringTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			const int numberOfCalls = 100000;
			DateTime startingTime;
			DateTime endingTime;
			TimeSpan timeDiff;

			DniComRefactorVBObj comObj;

			//call individual com methods from managed code
			comObj = new DniComRefactorVBObjClass();
			startingTime = DateTime.Now;
			for (int i = 0; i < numberOfCalls; i++)
			{
				int acctId = comObj.SearchForAccount("accountKey");
				if (acctId > 0)
				{
					Decimal pastDueAmt = comObj.GetPastDueBalance(acctId);
					if (pastDueAmt > 100.00m)
					{
						comObj.SetAccountDelinquent(acctId);
					}
				}
			}
			endingTime = DateTime.Now;
			timeDiff = endingTime - startingTime;
			Console.WriteLine("{0} Individual COM calls: {1} milliseconds",
				numberOfCalls, timeDiff.TotalMilliseconds);

			//call a single refactored com method from managed code
			comObj = new DniComRefactorVBObjClass();
			startingTime = DateTime.Now;
			for (int i = 0; i < numberOfCalls; i++)
			{
				comObj.CheckAccountDelinquency("accountKey", 100.00m);
			}
			endingTime = DateTime.Now;
			timeDiff = endingTime - startingTime;
			Console.WriteLine("{0} Refactored COM calls: {1} milliseconds",
				numberOfCalls, timeDiff.TotalMilliseconds);

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read();
		}
	}
}
