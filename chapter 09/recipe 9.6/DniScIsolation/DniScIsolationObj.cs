using System;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

using TransactionLogging;

namespace DniScIsolation
{
	public interface IIsolationMethods
	{
		void PerformUpdate();
	}

	[Transaction(TransactionOption.Required,
		Isolation = TransactionIsolationLevel.RepeatableRead)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScIsolationRRObj
		: ServicedComponent, IIsolationMethods
	{
		[AutoComplete]
		public void PerformUpdate()
		{
			//log the transaction state
			TransactionLogger log
				= new TransactionLogger(this);
		}

	}
}
