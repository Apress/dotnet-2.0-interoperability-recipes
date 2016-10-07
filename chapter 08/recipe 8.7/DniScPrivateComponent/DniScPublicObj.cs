using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace DniScPrivateComponent
{
	public interface IPublicAccountServices
	{
		int UpdateAccountStatus(string searchArg);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniScPublicObj 
		: ServicedComponent, IPublicAccountServices
	{
		public int UpdateAccountStatus(string searchArg)
		{
			int acctId = 0;
			DniScPrivateComponent.IAccountServices privateObj
				= new DniScPrivateComponent.DniScPrivateObj();

			acctId = privateObj.FindAccount(searchArg);
			if (acctId > 0)
			{
				privateObj.ChangeActiveStatus(acctId, false);
			}
			return acctId;
		}
	}
}
