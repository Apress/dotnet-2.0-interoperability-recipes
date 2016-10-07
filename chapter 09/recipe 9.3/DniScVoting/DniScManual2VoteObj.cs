using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

using TransactionLogging;

namespace DniScVoting
{
	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScManual2VoteObj
		: ServicedComponent, ITranMethods
	{
		public void PerformWork(RequestedResult request)
		{
			//log the transaction
			TransactionLogger log
				= new TransactionLogger(this);

			//indicate that the object is done when
			//this method returns 
			ContextUtil.DeactivateOnReturn = true;

			//set a default vote to abort
			ContextUtil.MyTransactionVote
				= TransactionVote.Abort;

			//determine what kind of result was requested
			switch (request)
			{
				case RequestedResult.Success:
					ContextUtil.MyTransactionVote
						= TransactionVote.Commit;
					break;
				case RequestedResult.ThrowException:
					throw new ApplicationException(
						"Transaction should be aborted");
				default:
					break;
			}
		}
	}
}
