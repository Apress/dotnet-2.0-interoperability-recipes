using System;
using System.Runtime.InteropServices;

namespace StructureExactLayoutTest
{
    //partial structure definition
	[StructLayout(LayoutKind.Explicit)]
	public struct AccountBalanceStruct
    {
        [FieldOffset(0)]    public int      AccountId;
        [FieldOffset(16)]   public double   CurrentBalance;
        [FieldOffset(24)]   public double   PastDueBalance;
        [FieldOffset(60)]   public double   LastPurchaseAmt;
    }

	//partial structure definition
	[StructLayout(LayoutKind.Explicit)]
	public struct AccountBalanceStructShort
	{
		[FieldOffset(0)]	public int		AccountId;
		[FieldOffset(16)]	public double	CurrentBalance;
		[FieldOffset(24)]	public double	PastDueBalance;

		//LastPurchaseAmt field is omitted
	}

	//partial structure definition
	[StructLayout(LayoutKind.Explicit, Size = 68)]
	public struct AccountBalanceStructSize
	{
		[FieldOffset(0)]	public int		AccountId;
		[FieldOffset(16)]	public double	CurrentBalance;
		[FieldOffset(24)]	public double	PastDueBalance;

		//LastPurchaseAmt field is omitted
	}

	/// <summary>
	/// Passing of structures between managed and unmanaged code
	/// </summary>
	class StructureExactLayoutTest
	{
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern void RetrieveAccountBalances(
            int accountId, ref AccountBalanceStruct account);

		[DllImport("FlatAPIStructLib.DLL")]
		public static extern double RevisePurchaseAmt(
			ref AccountBalanceStructShort account,
			double purchaseAmt);

		[DllImport("FlatAPIStructLib.DLL",
			EntryPoint = "RevisePurchaseAmt")]
		public static extern double RevisePurchaseAmtFull(
			ref AccountBalanceStructSize account,
			double purchaseAmt);

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //uses a partially defined managed structure
		    AccountBalanceStruct account = new AccountBalanceStruct();
		    //make the unmanaged function call
			RetrieveAccountBalances(1001, ref account);
		    //show the results
			Console.WriteLine("RetrieveAccountBalances results: {0}, {1}, {2}, {3}",
				account.AccountId, account.CurrentBalance,
				account.PastDueBalance, account.LastPurchaseAmt);

			//uses a managed structure that is shorter than the required
			//length
			AccountBalanceStructShort accountShort
				= new AccountBalanceStructShort();
			double lastPurchaseAmt
				= RevisePurchaseAmt(ref accountShort, 249.95);
			Console.WriteLine(
				"RevisePurchaseAmt results: {0}",
				lastPurchaseAmt);

			AccountBalanceStructSize accountWithSize
				= new AccountBalanceStructSize();
			lastPurchaseAmt
				= RevisePurchaseAmtFull(ref accountWithSize, 249.95);
			Console.WriteLine(
				"RevisePurchaseAmtFull results: {0}",
				lastPurchaseAmt);

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
