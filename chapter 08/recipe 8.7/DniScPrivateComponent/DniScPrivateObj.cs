using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace DniScPrivateComponent
{
	public interface IAccountServices
	{
		int FindAccount(string searchArg);
		void ChangeActiveStatus(int acctId, bool activeFlag);
	}

	[ClassInterface(ClassInterfaceType.None)]
	[PrivateComponent]
	public class DniScPrivateObj 
		: ServicedComponent, IAccountServices
	{
		public int FindAccount(string searchArg)
		{
			//return the account Id based on search arguments
			return 2001;
		}

		public void ChangeActiveStatus(int acctId, bool activeFlag)
		{
			//nothing implemented
		}
	}
}
