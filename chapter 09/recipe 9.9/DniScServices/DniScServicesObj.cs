using System;
using System.EnterpriseServices;

using TransactionLogging;

namespace DniScServices
{
	public interface IServicesWithoutComponents
	{
		void UseComPlusServices(Boolean succeed);
	}

	public class DniScServicesObj : IServicesWithoutComponents
	{
		public void UseComPlusServices(Boolean succeed)
		{
			ServiceConfig config = new ServiceConfig();
			config.Transaction	 = TransactionOption.Required;
			config.TrackingAppName = "ServicesWithoutComponents";
			config.TrackingComponentName = "DniScServicesObj";
			config.TrackingEnabled = true;

			try
			{
				//enter a COM+ context
				ServiceDomain.Enter(config);
			
				//log the transaction 
				TransactionLogger log 
					= new TransactionLogger(this);

				//do work here involving one or more
				//resources such as a database or queue

				//complete or abort the transaction
				if (succeed)
				{
					ContextUtil.SetComplete();
				}
				else
				{
					ContextUtil.SetAbort();
				}
			}
			finally
			{
				//leave the COM+ context
				ServiceDomain.Leave();
			}
		}
	}
}
