using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

using TransactionLogging;

namespace DniScVoting
{
	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScSetManualVoteObj
		: ServicedComponent, ITranMethods
	{
		public void PerformWork(RequestedResult request)
		{
			//log the transaction
			TransactionLogger log
				= new TransactionLogger(this);

			ContextUtil.SetComplete();

			try
			{
				//determine what kind of result was requested
				switch (request)
				{
					case RequestedResult.VoteToAbort:
					case RequestedResult.ThrowException:
						throw new ApplicationException(
							"Transaction should be aborted");
					default:
						break;
				}

				//if we get this far, 
				//the SetComplete vote will stand
			}
			catch (Exception e)
			{
				ContextUtil.SetAbort();
				throw e;
			}
		}
	}
}
