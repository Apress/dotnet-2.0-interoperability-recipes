using System;
using System.Transactions;

using TransactionLogging;

//the code in this class is only used to verify that it compiles

namespace DniScTranScope
{
	public class DniScTranScopeSamples
	{
		public void UseRequiresNew()
		{
			using (TransactionScope scope = new TransactionScope(
				TransactionScopeOption.RequiresNew))
			{
				//perform resource updates

				scope.Complete();
			}
		}

		public void UseTranScopeOptions()
		{
			TransactionOptions options = new TransactionOptions();
			options.IsolationLevel = IsolationLevel.RepeatableRead;
			options.Timeout = new TimeSpan(0, 0, 30); 	
			using (TransactionScope scope = new TransactionScope(
				TransactionScopeOption.Required, options))
			{
				//perform resource updates

				scope.Complete();
			}
		}

	}
}
