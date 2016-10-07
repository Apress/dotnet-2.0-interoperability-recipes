// SimpleNumberClientIFace.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <objbase.h>
#import "mscorlib.tlb"
#import "DniNetSimpleNumbersIFaceVB.tlb" no_namespace 

int _tmainVB(int argc, _TCHAR* argv[])
{
	CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

	//create an instance of the .NET object via COM
	IAddNumbersPtr 
		comObj(__uuidof(DniNetSimpleNumbersIFaceVB));
	if (comObj)
	{
		//call the method and show the results
		int result = comObj->AddSomeNumbers(1, 2);
		_cprintf(
			"Result using VB.NET interface via COM: %i \r\n", 
			result);
		comObj.Release();
	}
	
	CoUninitialize();

	return 0;
}


