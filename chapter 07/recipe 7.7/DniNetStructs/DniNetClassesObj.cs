using System;
using System.Runtime.InteropServices;

namespace DniNetStructs
{
	//Implement an account class
	[ComVisible(false)]
	public class Account : IAccount
	{
		private int			m_AccountId;
		private string		m_AccountName;
		private decimal		m_Balance;

		public int AccountId
		{
			get { return m_AccountId;}
			set { m_AccountId = value; }
		}

		public string AccountName
		{
			get { return m_AccountName; }
			set { m_AccountName = value; }
		}

		public decimal Balance
		{
			get { return m_Balance; }
			set { m_Balance = value; }
		}
	}

	//define an interface to expose class properties
	//to COM clients
	public interface IAccount
	{
		int AccountId		{get;}
		string AccountName	{get;}
		decimal Balance 
		{
			//marshal the balance to com as CURRENCY
			[return: MarshalAs(UnmanagedType.Currency)] get;
			//prohibit setting of balance property via com
			[ComVisible(false)]
			set;
		}
	}

	//define an interface for account services
	public interface IAccountLookup
	{
		IAccount RetrieveAccount(int acctId);
		void UpdateBalance(IAccount account);
	}

	//implement a class to provide account services
	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetClassesObj : IAccountLookup
	{
		public IAccount RetrieveAccount(int acctId)
		{
			Account result = null;
			if (acctId == 123)
			{
				result = new Account();
				result.AccountId = acctId;
				result.AccountName = "myAccount";
				result.Balance = 1009.95M;
			}
			return result;
		}

		public void UpdateBalance(IAccount account)
		{
			//update the balance
			if (account != null)
			{
				account.Balance += 500.00M;
			}
		}
	}
}
