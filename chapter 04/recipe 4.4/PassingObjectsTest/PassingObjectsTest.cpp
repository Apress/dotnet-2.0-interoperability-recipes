// PassingObjectsTest.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include "ManagedAccount.h"
#include "NativeBalanceProcessor.h"

using namespace System;
using namespace MixedSharedLib; 

//#include "TestHeader.h"

int _tmain(int argc, _TCHAR* argv[])
{

	//mymain();

	//verify the traits for each class
	_cprintf("CNativeBalanceProcessor is unmanaged: %i \r\n", 
		__is_class(CNativeBalanceProcessor));
	_cprintf("ManagedAccount is unmanaged: %i \r\n", 
		__is_class(ManagedAccount));
	_cprintf("CManagedAccountWrapper is unmanaged: %i \r\n", 
		__is_class(CManagedAccountWrapper));
	_cprintf("CManagedAccountWrapper is ref class: %i \r\n", 
		__is_ref_class(CManagedAccountWrapper));
	_cprintf("CManagedAccountWrapper is value class: %i \r\n", 
		__is_value_class(CManagedAccountWrapper));

	//create the unmanaged processor class
	CNativeBalanceProcessor processor;
	processor.SetLateFee(1.95);

	//create a managed account object
	ManagedAccount^ account 
		= gcnew ManagedAccount(1001, 501.99, "Account One");
	//pass the managed obj to the unmanaged method
	processor.CalcNewBalance(CManagedAccountWrapper(account));
	_cprintf("Results for %i, %s is: %5.2f PastDue: %i \r\n", 
		account->AcctNumber, account->Name,
		account->Balance, account->PastDue);

	//try a second account object
	account 
		= gcnew ManagedAccount(2002, 499.95, "Another Acct");
	processor.CalcNewBalance(CManagedAccountWrapper(account));
	_cprintf("Results for %i, %s is: %5.2f PastDue: %i \r\n", 
		account->AcctNumber, account->Name,
		account->Balance, account->PastDue);

	//wait for a key press	
	_getch();

	return 0;
}

