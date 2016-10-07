#pragma once

//a native class that demonstrates receiving 
//and using an instance of a managed class

#include "ManagedAccount.h"
#include <gcroot.h>

#pragma unmanaged
namespace MixedSharedLib
{
	//unmanaged processing class
	class CNativeBalanceProcessor
	{
	public:
		void SetLateFee(double lateFee)
		{
			m_LateFee = lateFee;
		}

		//use and modify properties of the managed object
		void CalcNewBalance(CManagedAccountWrapper acctObj)
		{
			//uses the wrapper to access the underlying
			//managed object
			if (acctObj.getBalance() > 500.00)
			{
				acctObj.setBalance(acctObj.getBalance() + m_LateFee);
				acctObj.setPastDue(true);
			}
		}
		void CalcNewBalance(gcroot<ManagedAccount^> acctObj)
		{
			/* this will compile and work
			CManagedAccountWrapper wrapper = 
				CManagedAccountWrapper(acctObj);
			if (wrapper.getBalance() > 500.00)
			{
				wrapper.setBalance(wrapper.getBalance() + m_LateFee);
				wrapper.setPastDue(true);
			}
			*/

			/* this will not compile due to error C3642				
			if (acctObj->Balance > 500.00)
			{
				acctObj->Balance += m_LateFee;
				acctObj->PastDue  = true;
			}
			*/
		}

	private:
		double	m_LateFee;
	};
}

#pragma managed