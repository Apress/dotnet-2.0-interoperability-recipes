// SimpleNumberClient.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <objbase.h>
//#import "mscorlib.tlb"

int _tmain(int argc, _TCHAR* argv[])
{
	CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

	//create an instance of the .NET object via COM
	//using dispinterface

	//get the CLSID from the progID
	CLSID clsid;
	CLSIDFromProgID(
		L"DniNetSimpleNumbers.DniNetSimpleNumbersDisp",
		&clsid);

	//create an instance of the object		
	IDispatch* pIDispatch = NULL;
	CoCreateInstance(clsid, NULL, CLSCTX_INPROC_SERVER,
		IID_IDispatch, (void**)&pIDispatch);

	//get the dispId of the method we want to call
	DISPID dispId;
	OLECHAR* methodName = L"AddSomeNumbers";
	pIDispatch->GetIDsOfNames(IID_NULL, &methodName, 1,
		GetUserDefaultLCID(), &dispId);

	//setup calling params - must be variantarg
	VARIANTARG nums[2];
	VariantInit(&nums[0]);
	nums[0].vt = VT_I4;
	nums[0].lVal = 111;	//first number
	VariantInit(&nums[1]);
	nums[1].vt = VT_I4;
	nums[1].lVal = 222;	//second number

	//setup DISPPARAMS structure with arguments
	DISPPARAMS param;	
	param.cArgs = 2;
	param.rgvarg = (VARIANTARG*)&nums;
	param.cNamedArgs = 0;
	param.rgdispidNamedArgs = NULL;

	//the result goes here
	VARIANT result;
	VariantInit(&result);
	
	//finally, we make the method call
	HRESULT hr = pIDispatch->Invoke(dispId, IID_NULL,
		GetUserDefaultLCID(), DISPATCH_METHOD, &param,
		&result, NULL, NULL);
	//show the results
	_cprintf(
		"AddSomeNumbers result via COM IDispatch: %i \r\n", 
		result.intVal);

	//cleanup
	pIDispatch->Release();
	CoUninitialize();

	//wait for a key press
	_getch();
	return 0;
}

