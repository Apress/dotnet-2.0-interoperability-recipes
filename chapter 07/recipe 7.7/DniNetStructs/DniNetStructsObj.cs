using System;
using System.Runtime.InteropServices;

namespace DniNetStructs
{
	//Implement an account struct
	public struct AccountStruct
	{
		public int			AccountId;
		[MarshalAs(UnmanagedType.BStr)]
		public string		AccountName;
		[MarshalAs(UnmanagedType.Currency)]
		public decimal		Balance;
	}

	//define an interface for account services
	public interface IAccountStructLookup
	{
		AccountStruct RetrieveAccount(int acctId);
		void UpdateBalance(ref AccountStruct account);
	}

	//implement a class to provide account services
	//using an AccountStruct
	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetStructsObj : IAccountStructLookup
	{
		public AccountStruct RetrieveAccount(int acctId)
		{
			AccountStruct result = new AccountStruct();
			if (acctId == 123)
			{
				result.AccountId = acctId;
				result.AccountName = "myAccount";
				result.Balance = 1009.95M;
			}
			return result;
		}

		public void UpdateBalance(ref AccountStruct account)
		{
			//update the balance
			account.Balance += 500.00M;
		}
	}
}
