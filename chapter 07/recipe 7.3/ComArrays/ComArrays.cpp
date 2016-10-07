// ComArrays.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <objbase.h>
#include <atlbase.h>
#import "mscorlib.tlb"
#import "DniNetArrays.tlb" no_namespace

int _tmain(int argc, _TCHAR* argv[])
{
	::CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

	//create an instance of the .NET object via COM
	IArraysPtr comObj(__uuidof(DniNetArraysObj));
	if (comObj)
	{
		UseStringArray(comObj);
		UseIntArray(comObj);

		comObj.Release();
	}

	//cleanup
	::CoUninitialize();

	//wait for a key press
	_getch();
	return 0;
}

void UseStringArray(IArraysPtr comObj)
{
	//create a safearray
	SAFEARRAY* pSafeArray;
	SAFEARRAYBOUND saBound[1];
	saBound[0].lLbound = 0;
	saBound[0].cElements = 3;
	pSafeArray = SafeArrayCreate(VT_BSTR, 1, saBound);

	//populate the elements in the array
	BSTR *pBSTR;
	SafeArrayAccessData(pSafeArray, (void HUGEP**)&pBSTR);
	pBSTR[0] = CComBSTR(L"one").Detach();
	pBSTR[1] = CComBSTR(L"two").Detach();
	pBSTR[2] = CComBSTR(L"three").Detach();
	SafeArrayUnaccessData(pSafeArray);

	//attempt to update the string array. we should not
	//see changes made to the array since the COM method
	//is marked with the [In] attribute
	int result = comObj->UpdateStringArrayInOnly(&pSafeArray);
	_cprintf("UpdateStringArrayInOnly: %i \r\n", result);
	DisplayStringArray(pSafeArray);

	//this should update the string array successfully
	result = comObj->UpdateStringArray(&pSafeArray);
	_cprintf("UpdateStringArray: %i \r\n", result);
	DisplayStringArray(pSafeArray);

	//pass the safearray by value instead of by reference
	result = comObj->SumStringArrayByValue(pSafeArray);
	_cprintf("SumStringArrayByValue: %i \r\n", result);

	//cleanup the safe array
	SafeArrayDestroy(pSafeArray);
}

void DisplayStringArray(SAFEARRAY* pSafeArray)
{
	BSTR *pBSTR;
	SafeArrayAccessData(pSafeArray, (void **)&pBSTR);
	for(int i = 0; i < 3; i++)
	{
		_cprintf("BSTR element: %S \r\n", pBSTR[i]);
	}
	SafeArrayUnaccessData(pSafeArray);
}

void UseIntArray(IArraysPtr comObj)
{
	//create a safearray
	SAFEARRAY* pSafeArray;
	SAFEARRAYBOUND saBound[1];
	saBound[0].lLbound = 0;
	saBound[0].cElements = 3;
	pSafeArray = SafeArrayCreate(VT_I4, 1, saBound);

	//populate the elements in the array
	int *pInt;
	SafeArrayAccessData(pSafeArray, (void HUGEP**)&pInt);
	pInt[0] = 111;
	pInt[1] = 222;
	pInt[2] = 333;
	SafeArrayUnaccessData(pSafeArray);

	//attempt to update the integer array. we should not
	//see changes made to the array since the COM method
	//is marked with the [In] attribute
	int result = comObj->UpdateIntArrayInOnly(&pSafeArray);
	_cprintf("UpdateIntArrayInOnly: %i \r\n", result);
	DisplayIntArray(pSafeArray);
 
	//this should successfully update the array
	result = comObj->UpdateIntArray(&pSafeArray);
	_cprintf("UpdateIntArray: %i \r\n", result);
	DisplayIntArray(pSafeArray);

	//attempt to update the integer array passed by value.
	result = comObj->UpdateIntArrayByValue(pSafeArray);
	_cprintf("UpdateIntArrayByValue: %i \r\n", result);
	DisplayIntArray(pSafeArray);

	//attempt to update the integer array passed by value
	//but this time the method has the [In,Out] attributes added.
	result = comObj->UpdateIntArrayByValueInOut(pSafeArray);
	_cprintf("UpdateIntArrayByValueInOut: %i \r\n", result);
	DisplayIntArray(pSafeArray);

	//cleanup the safe array
	SafeArrayDestroy(pSafeArray);
}

void DisplayIntArray(SAFEARRAY* pSafeArray)
{
	int* pInt;
	SafeArrayAccessData(pSafeArray, (void **)&pInt);
	for(int i = 0; i < 3; i++)
	{
		_cprintf("Int element: %i \r\n", pInt[i]);
	}
	SafeArrayUnaccessData(pSafeArray);
}

