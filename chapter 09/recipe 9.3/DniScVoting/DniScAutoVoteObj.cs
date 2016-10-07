using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

using TransactionLogging;

namespace DniScVoting
{
	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScAutoVoteObj
		: ServicedComponent, ITranMethods
	{
		[AutoComplete]
		public void PerformWork(RequestedResult request)
		{
			//log the transaction
			TransactionLogger log
				= new TransactionLogger(this);

			//determine what kind of result was requested
			switch (request)
			{
				case RequestedResult.VoteToAbort:
					ContextUtil.MyTransactionVote
						= TransactionVote.Abort;
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
