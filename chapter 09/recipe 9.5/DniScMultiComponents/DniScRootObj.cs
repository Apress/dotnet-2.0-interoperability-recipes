using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

using TransactionLogging;

namespace DniScMultiComponents
{
	public interface IRootComponent
	{
		bool PerformUpdate(int testNumber);
	}

	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScRootObj
		: ServicedComponent, IRootComponent
	{
		public bool PerformUpdate(int testNumber)
		{
			//log the transaction
			TransactionLogger log
				= new TransactionLogger(this);
			
			//set the default vote
			ContextUtil.SetComplete();
			
			ICalledComponent calledObj;
			try
			{
				switch (testNumber)
				{
					//everything succeeds
					case (1):
						calledObj = new DniScCalledObj();
						calledObj.PerformUpdate(true);
						break;

					//called component throws exception
					case (2):
						calledObj = new DniScCalledObj();
						calledObj.PerformUpdate(false);
						break;

					//called obj RequiresNew - everything succeeds
					case (3):
						calledObj = new DniScCalledNewObj();
						calledObj.PerformUpdate(true);
						break;

					//called obj RequiresNew - throws exception
					case (4):
						calledObj = new DniScCalledNewObj();
						calledObj.PerformUpdate(false);
						break;

					default:
						break;
				}
			}
			catch (Exception)
			{
				//we ignore any exceptions from the called object
				return false;
			}

			return true;
		}
	}
}
