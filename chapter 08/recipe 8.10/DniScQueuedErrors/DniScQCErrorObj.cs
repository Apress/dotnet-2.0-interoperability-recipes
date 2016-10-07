using System;
using System.IO;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace DniScQueuedComponent
{
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScQCErrorObj : ServicedComponent, 
		  IPlaybackControl, IQueuedComponent
	{
		public void LogMessage(string message)
		{
			//called if the message cannot be delivered
			//to the original component

			using (StreamWriter writer
				= new StreamWriter(@"c:\QCErrorLog.txt", true))
			{
				writer.WriteLine(message);
				writer.Flush();
			}
		}

		public void FinalClientRetry()
		{
			//notification of a delivery failure
			//on the client side. 
		}

		public void FinalServerRetry()
		{
			//notification of a playback failure
			//on the server
		}
	}
}
