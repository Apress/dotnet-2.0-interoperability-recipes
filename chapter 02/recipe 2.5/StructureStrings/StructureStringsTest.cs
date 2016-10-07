using System;
using System.Runtime.InteropServices;

namespace StructureStringsTest
{
    //partial structure definition
    [StructLayout(LayoutKind.Explicit)]
    public struct AccountBalanceStruct
    {
        [FieldOffset(0)]     public int      AccountId;
        [FieldOffset(36)]    public string   AccountName;
        [FieldOffset(40)]    public string   Address1;
        [FieldOffset(44)]    public string   Address2;
        [FieldOffset(48)]    public string   City;
        [FieldOffset(52)]    public string   State;
        [FieldOffset(56)]    public int      PostalCode;
    }

    //partial structure definition
    [StructLayout(LayoutKind.Explicit)]
    public struct AccountBalanceStructRaw
    {
        [FieldOffset(0)]     public int      AccountId;
        [FieldOffset(36)]    public IntPtr   AccountName;
        [FieldOffset(40)]    public IntPtr   Address1;
        [FieldOffset(44)]    public IntPtr   Address2;
        [FieldOffset(48)]    public IntPtr   City;
        [FieldOffset(52)]    public IntPtr   State;
        [FieldOffset(56)]    public int      PostalCode;
    }

	/// <summary>
	/// Passing of structures between managed and unmanaged code
	/// </summary>
	class StructureStringsTest
	{
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern void RetrieveAccountProfile(
            int accountId, ref AccountBalanceStruct account);

        [DllImport("FlatAPIStructLib.DLL", EntryPoint="RetrieveAccountProfile")]
        public static extern void RetrieveAccountProfileRaw(
            int accountId, ref AccountBalanceStructRaw account);
	
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //create the struct
            AccountBalanceStruct account = new AccountBalanceStruct();
            //make the unmanaged function call, marshaling
            //the strings as System.String
            RetrieveAccountProfile(1001, ref account);
            
            //show the results
            Console.WriteLine(
                "RetrieveAccountProfile results: {0},{1},{2},{3},{4},{5}",
                account.AccountId, account.AccountName, account.Address1, 
                account.Address2, account.State, account.PostalCode);
                
            //raw version where we do the marshaling and freeing. 
            //Should provide the same results as above where 
            //we let pinvoke do the work                
            AccountBalanceStructRaw accountRaw = new AccountBalanceStructRaw();
            //make the unmanaged function call
            RetrieveAccountProfileRaw(1001, ref accountRaw);
            //marshal the pointers to strings
            String accountName = Marshal.PtrToStringAnsi(accountRaw.AccountName);
            String address1 = Marshal.PtrToStringAnsi(accountRaw.Address1);
            String address2 = Marshal.PtrToStringAnsi(accountRaw.Address2);
            String city = Marshal.PtrToStringAnsi(accountRaw.City);
            String state = Marshal.PtrToStringAnsi(accountRaw.State);
            
            //free the memory
            Marshal.FreeCoTaskMem(accountRaw.AccountName);
            Marshal.FreeCoTaskMem(accountRaw.Address1);
            Marshal.FreeCoTaskMem(accountRaw.Address2);
            Marshal.FreeCoTaskMem(accountRaw.City);
            Marshal.FreeCoTaskMem(accountRaw.State);

            //show the results
            Console.WriteLine(
                "RetrieveAccountProfileRaw results: {0},{1},{2},{3},{4},{5}",
                accountRaw.AccountId, accountName, address1,
                address2, state, accountRaw.PostalCode);

            //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
