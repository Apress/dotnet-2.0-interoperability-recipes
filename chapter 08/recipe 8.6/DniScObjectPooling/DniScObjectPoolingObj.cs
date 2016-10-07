using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace DniScObjectPooling
{
	[ObjectPooling(30,100)]
	[JustInTimeActivation]
	[EventTrackingEnabled]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScObjectPoolingObj
		: ServicedComponent, IObjectPoolingMethods
	{
		private Hashtable m_KeyCodes;

		public DniScObjectPoolingObj()
		{
			//simulate the cost of object construction.
			//this might represent the time needed to 
			//retrieve and locally cache selected
			//values from a database or other source.
			System.Threading.Thread.Sleep(100);

			//build an in-memory cache of frequently
			//used data. in a live application, this
			//might be populated from a database query.
			m_KeyCodes = new Hashtable();
			m_KeyCodes.Add("AAA", 11111);
			m_KeyCodes.Add("BBB", 22222);
			m_KeyCodes.Add("CCC", 33333);
			m_KeyCodes.Add("DDD", 44444);
			m_KeyCodes.Add("EEE", 55555);
		}

		[AutoComplete]
		public int LookupKeyCode(string key)
		{
			int result = 0;
			if (m_KeyCodes.Contains(key))
			{
				result = (int)m_KeyCodes[key];
			}
			else
			{
				//not in the local cache, so we need to
				//retrieve it from the database
			}
			return result;
		}

		protected override bool CanBePooled()
		{
			//override the base method in order to allow
			//pooling of this object
			return true;
		}
	}
}
