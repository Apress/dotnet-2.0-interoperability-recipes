using System;
using DniScRoleSecurity;

namespace ScRoleSecurity
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				IRoleClassSecurity classObj
					= new DniScRoleClassSecurityObj();
				CallClassSecurityObj(classObj);

				IRoleMethodSecurity obj
					= new DniScRoleMethodSecurityObj();
				CallUnsecuredMethod(obj);
				CallSecuredMethod(obj);

			}
			catch (Exception e)
			{
				Console.WriteLine(
					"Exception during creation: {0}",
					e.Message);
			}

			Console.Read();
		}

		static void CallClassSecurityObj(IRoleClassSecurity obj)
		{
			try
			{
				int result = obj.SecuredMethod("abcdefg");
				Console.WriteLine(
					"Class security method result: {0}", result);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"Exception using secured class: {0}",
					e.Message);
			}
		}

		static void CallSecuredMethod(IRoleMethodSecurity obj)
		{
			try
			{
				int result = obj.SecuredMethod("abcdefg");
				Console.WriteLine(
					"SecuredMethod result: {0}", result);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"Exception calling SecuredMethod: {0}",
					e.Message);
			}
		}

		static void CallUnsecuredMethod(IRoleMethodSecurity obj)
		{
			try
			{
				int result = obj.UnsecuredMethod("abcdefg");
				Console.WriteLine(
					"UnsecuredMethod result: {0}", result);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"Exception calling UnsecuredMethod: {0}",
					e.Message);
			}
		}
	}
}

