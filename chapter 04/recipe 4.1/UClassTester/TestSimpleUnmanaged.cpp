#include "StdAfx.h"
#include "TestSimpleUnmanaged.h"
#include "Unmanaged.h"			//from the unmanaged dll
#include "MixedNativeNumber.h"	//from the mixed dll
#include <conio.h>

using namespace USharedLib;

CTestSimpleUnmanaged::CTestSimpleUnmanaged(void)
{
}

CTestSimpleUnmanaged::~CTestSimpleUnmanaged(void)
{
}

void CTestSimpleUnmanaged::Test()
{
	//test the simple unmanaged class
	CUnmanaged obj;
	obj.AddNumber(1);
	obj.AddNumber(2);
	int result = obj.GetTheResult();

	//show the results
	_cprintf("Add Numbers result: %i \r\n",
		result);
}

void CTestSimpleUnmanaged::TestMixed()
{
	//test the mixed unmanaged/managed class
	MixedSharedLib::CMixedNativeNumber obj;
	int result = obj.AddTheNumbers(55, 66);

	//show the results
	_cprintf("Mixed assembly result: %i \r\n",
		result);
}

