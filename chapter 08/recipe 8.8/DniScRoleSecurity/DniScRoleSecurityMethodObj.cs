using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace DniScRoleSecurity
{
	public interface IRoleMethodSecurity
	{
		int SecuredMethod(string paramA);
		int UnsecuredMethod(string paramA);
	}

	[ComponentAccessControl(true)]
	[SecureMethod]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScRoleMethodSecurityObj
		: ServicedComponent, IRoleMethodSecurity
	{
		[SecurityRole("AppManager")]
		public int SecuredMethod(string paramA)
		{
			return paramA.Length;
		}

		[SecurityRole("AppUser", true)]
		public int UnsecuredMethod(string paramA)
		{
			return paramA.Length;
		}
	}
}
