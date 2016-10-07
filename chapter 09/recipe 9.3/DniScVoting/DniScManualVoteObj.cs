using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

using TransactionLogging;

namespace DniScVoting
{
	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScManualVoteObj
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

			//determine what kind of result was requested
			switch (request)
			{
				case RequestedResult.Success:
					ContextUtil.MyTransactionVote
						= TransactionVote.Commit;
					break;
				case RequestedResult.VoteToAbort:
					ContextUtil.MyTransactionVote
						= TransactionVote.Abort;
					break;
				case RequestedResult.ThrowException:
					//must still vote even though we
					//throw an exception
					ContextUtil.MyTransactionVote
						= TransactionVote.Abort;
					throw new ApplicationException(
						"Transaction should be aborted");
				default:
					break;
			}
		}
	}
}
