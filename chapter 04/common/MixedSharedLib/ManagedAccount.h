#pragma once

#ifndef ManagedAccountHeaderFile
#define ManagedAccountHeaderFile

//a managed class that is passed-to and held
//by an unmanaged class

#include <gcroot.h>
using namespace System;

namespace MixedSharedLib
{
	//managed account class
	public ref class ManagedAccount
	{
	public:
		ManagedAccount(int acctNbr, double balance,
			String^ name)
		{
			m_AcctNumber = acctNbr;
			m_Balance	 = balance;
			m_Name		 = name;
		}

		property int AcctNumber
		{
			int get(){return m_AcctNumber;}
		}

		property String^ Name
		{
			String^ get(){return m_Name;}
			void set(String^ value)
			{
				m_Name = value;
			}
		}
	
		property double Balance
		{
			double get(){return m_Balance;}
			void set(double value)
			{
				m_Balance = value;
			}
		}

		property Boolean PastDue
		{
			Boolean get(){return m_PastDue;}
			void set(Boolean value)
			{
				m_PastDue = value;
			}
		}

	private:
		int		m_AcctNumber;
		String^ m_Name; 
		double  m_Balance;
		Boolean m_PastDue;
	};

	//unmanaged wrapper for managed class
	public class CManagedAccountWrapper
	{
	public:
		CManagedAccountWrapper(gcroot<ManagedAccount^> obj)
		{
			m_Account = obj;
		}
		//property accessor methods
		double getBalance() 
		{
			return m_Account->Balance;
		}
		void setBalance(double value) 
		{
			m_Account->Balance = value;
		}
		void setPastDue(bool value)
		{
			m_Account->PastDue = value;
		}

	private:
		gcroot<ManagedAccount^> m_Account;
	};

}

#endif