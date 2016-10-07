using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

using TransactionLogging;

namespace DniScMultiComponents
{
	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScCalledObj
		: ServicedComponent, ICalledComponent
	{
		public bool PerformUpdate(bool succeed)
		{
			//log the transaction
			TransactionLogger log
				= new TransactionLogger(this);

			//set the default vote
			ContextUtil.SetComplete();

			if (!succeed)
			{
				ContextUtil.SetAbort();
				throw new ApplicationException(
					"Exception was requested");
			}
			return succeed;
		}
	}
}
