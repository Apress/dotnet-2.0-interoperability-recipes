using System;
using System.Transactions;

using TransactionLogging;

namespace DniScTranScope
{
	public interface ILocalScope
	{
		void UseLocalScope(bool succeed);
	}

	public class DniScTranScopeObj : ILocalScope
	{
		public void UseLocalScope(bool succeed)
		{
			TransactionScope scope = new TransactionScope();
			using (scope)
			{
				//log the state of the transaction
				TransactionLogger log
					= new TransactionLogger(this);

				//
				//update a database or other 
				//resource manager here
				//

				if (succeed)
				{
					//signal that the transaction 
					//should be committed
					scope.Complete();
				}
			}
		}
	}
}
