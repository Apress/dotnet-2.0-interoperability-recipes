using System;
using System.Runtime.InteropServices;

namespace DniNetComEvents
{
	//the delegate for the event
	[ComVisible(false)]
	public delegate void DescChangedHandler(
		string newDesc, string oldDesc);

	//an interface defining our event source
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IDescriptionNotifier
	{
		//the method name here must match that event name
		//in our managed class and interface. The DispId
		//attribute is needed to prevent errors in VB6
		//when no event handler is assigned.
		[DispId(21)]
		void DescChanged(string newDesc, string oldDesc);
	}

	//an interface defining the members we want to expose
	//to com clients
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface IDescriptionManager
	{
		void ChangeDesc(string newDesc);
	}

	[ClassInterface(ClassInterfaceType.None)]
	[ComSourceInterfaces(typeof(IDescriptionNotifier))]
	public class DniNetComEventsObj : IDescriptionManager
	{
		//event that com clients can subscribe to
		public event DescChangedHandler DescChanged;

		//causes the event to be fired
		public void ChangeDesc(string newDesc)
		{
			if (DescChanged != null)
			{
				//fire the event if there are any subscribers
				DescChanged(newDesc, m_Desc);
			}
			m_Desc = newDesc;
		}

		private string m_Desc = "empty"; 
	}
}
