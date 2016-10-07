// SimpleNumberClientIFace.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <objbase.h>
#import "mscorlib.tlb"
#import "DniNetSimpleNumbersIFace.tlb" no_namespace 

int _tmain2(int argc, _TCHAR* argv[])
{
	CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

	//create an instance of the .NET object via COM
	//using the original interface
	IAddNumbersPtr 
		comObj(__uuidof(DniNetSimpleNumbersIFace2));
	if (comObj)
	{
		//call the method and show the results
		int result = comObj->AddSomeNumbers(1, 2);
		_cprintf(
			"AddSomeNumbers using IAddNumbersPtr: %i \r\n", 
			result);
	}

	//create a smart pointer for the new interface using
	//the COM object we already create
	IAddSubtractNumbersPtr subObj(comObj);
	if (subObj)
	{
		//call the new method and show the results
		int result = subObj->SubtractSomeNumbers(10, 6);
		_cprintf(
			"SubtractSomeNumbers using IAddSubtractNumbers: %i \r\n", 
			result);
		subObj.Release();
	}

	if (comObj)
	{
		comObj.Release();
	}

	CoUninitialize();
	return 0;
}


