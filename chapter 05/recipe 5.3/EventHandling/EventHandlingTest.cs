using System;

using Interop.DniComEventsVB;	//the vb6 COM component
using DniComEventsLib;			//the C++ ATL COM component

namespace EventHandling
{
	class EventHandlingTest
	{
		static void Main(string[] args)
		{
			//create the VB6 COM object
			DniComEventsVBObj comObj = new DniComEventsVBObj();

			//subscribe to the event
			comObj.OnDescChanged += new __DniComEventsVBObj_OnDescChangedEventHandler(
					OnDescChangedHandler);
			//call the COM method that fires the event
			comObj.ChangeDesc("first");
			//call it again
			comObj.ChangeDesc("second");


			//create the VB6 COM object
			DniComEventsVBObj comObjAnn = new DniComEventsVBObj();

			//subscribe to the event using a C# 2.0 anon delegate 
			comObjAnn.OnDescChanged 
				+= delegate(string newDesc, string oldDesc)
			{
				Console.WriteLine(
					"Anonymous delegate for OnDescChanged: Old:{0}, New:{1}",
					oldDesc, newDesc);					
			};
			//call the COM method that fires the event
			comObjAnn.ChangeDesc("first");
			//call it again
			comObjAnn.ChangeDesc("second");

			//create the ATL COM component
			DniComEventsObj atlComObj = new DniComEventsObj();

			//subscribe to the event
			atlComObj.OnDescChanged += new _IDniComEventsObjEvents_OnDescChangedEventHandler(
				OnDescChangedHandler);

			//call the COM method that fires the event
			atlComObj.ChangeDesc("ATLfirst");
			//call it again
			atlComObj.ChangeDesc("ATLsecond");

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read(); 	    
		}

		/// <summary>
		/// Event handler for OnDescChanged COM event
		/// </summary>
		/// <param name="newDesc"></param>
		/// <param name="oldDesc"></param>
		static void OnDescChangedHandler(string newDesc, string oldDesc)
		{
			Console.WriteLine("Received OnDescChanged event: Old:{0}, New:{1}",
				oldDesc, newDesc);					
		}
	}
}
