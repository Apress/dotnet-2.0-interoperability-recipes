using System;
using System.IO;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace DniScQueuedComponent
{
	[InterfaceQueuing]
	public interface IQueuedComponent
	{
		void LogMessage(string message);
	}

	[ExceptionClass("DniScQueuedComponent.DniScQCErrorObj")]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScQCObj	
		: ServicedComponent, IQueuedComponent
	{
		public void LogMessage(string message)
		{
			//append the message to a file
			using (StreamWriter writer
				= new StreamWriter(@"c:\QCLog.txt", true))
			{
				writer.WriteLine(message);
				writer.Flush();
			}
		}
	}
}
