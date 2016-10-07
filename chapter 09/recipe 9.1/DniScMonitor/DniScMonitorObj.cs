using System;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

using TransactionLogging;

namespace DniScMonitor
{
	public interface ITranMonitor
	{
		void LogTransactionDetails();
	}

	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScMonitorObj
		: ServicedComponent, ITranMonitor
	{
		public void LogTransactionDetails()
		{
			//create logging object that will record
			//the transaction state
			TransactionLogger logger
				= new TransactionLogger(this);
		}
	}
}
