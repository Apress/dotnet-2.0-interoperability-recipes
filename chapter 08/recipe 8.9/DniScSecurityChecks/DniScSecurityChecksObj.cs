using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

[assembly: ApplicationActivation(ActivationOption.Server)]
[assembly: ApplicationAccessControl(true)]
[assembly: ApplicationName("DniRoleSecurityApplication")]
[assembly: Description(".NET Interop Server Application")]
//setup the roles within the COM+ application
[assembly: SecurityRole("AppAdministrator")]
[assembly: SecurityRole("AppManager")]
[assembly: SecurityRole("AppUser", true)]

namespace DniScSecurityChecks
{
	public interface ISecuredMethods
	{
		bool IsSecurityEnabled();
		bool IsSecurityEnabledAlt();
		bool ManualSecurityCheck();
		bool ManualSecurityCheckAlt();
		string GetCaller();
	}

	[ComponentAccessControl(true)]
	[SecureMethod]
	[SecurityRole("AppUser", true)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScSecurityChecksObj
		: ServicedComponent, ISecuredMethods
	{
		public bool IsSecurityEnabled()
		{
			SecurityCallContext context
				= SecurityCallContext.CurrentCall;
			return context.IsSecurityEnabled;
		}

		public bool IsSecurityEnabledAlt()
		{
			return ContextUtil.IsSecurityEnabled;
		}
		
		public bool ManualSecurityCheck()
		{
			SecurityCallContext context
			    = SecurityCallContext.CurrentCall;
			return context.IsCallerInRole("AppManager");
		}

		public bool ManualSecurityCheckAlt()
		{
			return ContextUtil.IsCallerInRole("AppManager");
		}

		public string GetCaller()
		{
			SecurityCallContext context
				= SecurityCallContext.CurrentCall;
			SecurityIdentity identity = context.DirectCaller;
			return identity.AccountName;
		}
	}
}
