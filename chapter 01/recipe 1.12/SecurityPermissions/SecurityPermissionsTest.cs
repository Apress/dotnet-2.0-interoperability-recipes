using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace SecurityPermissionsTest
{
    [SecurityPermission(SecurityAction.Deny, Flags=SecurityPermissionFlag.UnmanagedCode)]	
    class UnmanagedCallsNotAllowed
    {
        [DllImport("FlatAPILib.DLL")]
        private static extern int GetStringLength(string aString);    
        
        /// <summary>
        /// Call the unmanaged function
        /// </summary>
        /// <param name="aString"></param>
        /// <returns></returns>
        public static int CallGetStringLength(string aString)
        {
            return GetStringLength(aString);
        }
    }

    [SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.UnmanagedCode)]	
    class UnmanagedCallsAllowed
    {
        [DllImport("FlatAPILib.DLL")]
        private static extern int GetStringLength(string aString);    
        
        /// <summary>
        /// Call the unmanaged function
        /// </summary>
        /// <param name="aString"></param>
        /// <returns></returns>
        public static int CallGetStringLength(string aString)
        {
            return GetStringLength(aString);
        }
    }

    [SecurityPermission(SecurityAction.Assert, Flags=SecurityPermissionFlag.UnmanagedCode)]	
    class UnmanagedCallsAsserted
    {
        [DllImport("FlatAPILib.DLL")]
        private static extern int GetStringLength(string aString);    
        
        /// <summary>
        /// Call the unmanaged function
        /// </summary>
        /// <param name="aString"></param>
        /// <returns></returns>
        public static int CallGetStringLength(string aString)
        {
            return GetStringLength(aString);
        }
    }

	/// <summary>
	/// Test Security Permissions for access to unmanaged code
	/// </summary>
	class SecurityPermissionsTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    int result;

            //call the wrapper that is allowed access to unmanaged code		    
            try
            {		    
                result = UnmanagedCallsAllowed.CallGetStringLength("abcde");
                Console.WriteLine("Result from CallGetStringLength Allowed = {0}", result);
            }
            catch(SecurityException e)
            {
                Console.WriteLine("Exception from CallGetStringLength Allowed = {0}", e.Message);
            }

            //call the wrapper that has been denied access to unmanaged code		    
            try
            {		    
		        result = UnmanagedCallsNotAllowed.CallGetStringLength("abcde");
                Console.WriteLine("Result from CallGetStringLength Not Allowed = {0}", result);
            }
            catch(SecurityException e)
            {
                Console.WriteLine("Exception from CallGetStringLength Not Allowed = {0}", e.Message);
            }

            //remove the unmanaged code permission 
            SecurityPermission permission = new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
            permission.Deny();

            //call the wrapper that is allowed access to unmanaged code		    
            try
            {		    
                result = UnmanagedCallsAllowed.CallGetStringLength("abcde");
                Console.WriteLine("Result from CallGetStringLength Allowed = {0}", result);
            }
            catch(SecurityException e)
            {
                Console.WriteLine("Exception from CallGetStringLength Allowed = {0}", e.Message);
            }

            //call the wrapper that asserts that it is allowd to access unmanaged code		    
            try
            {		    
                result = UnmanagedCallsAsserted.CallGetStringLength("abcde");
                Console.WriteLine("Result from CallGetStringLength Asserted = {0}", result);
            }
            catch(SecurityException e)
            {
                Console.WriteLine("Exception from CallGetStringLength Asserted = {0}", e.Message);
            }
            
       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
