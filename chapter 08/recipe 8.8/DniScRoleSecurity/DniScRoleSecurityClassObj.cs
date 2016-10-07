using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace DniScRoleSecurity
{
	public interface IRoleClassSecurity
	{
		int SecuredMethod(string paramA);
	}

	[ComponentAccessControl(true)]
	[SecureMethod]
	[SecurityRole("AppManager")]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScRoleClassSecurityObj
		: ServicedComponent, IRoleClassSecurity
	{
		public int SecuredMethod(string paramA)
		{
			return paramA.Length;
		}
	}
}
