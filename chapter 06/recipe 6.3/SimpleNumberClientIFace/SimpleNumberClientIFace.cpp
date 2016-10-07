// SimpleNumberClientIFace.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <objbase.h>
#import "mscorlib.tlb"
#import "DniNetSimpleNumbersIFace.tlb" no_namespace 

int _tmain(int argc, _TCHAR* argv[])
{
	CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

	//create an instance of the .NET object via COM
	IAddNumbersPtr 
		comObj(__uuidof(DniNetSimpleNumbersIFace));
	if (comObj)
	{
		//call the method and show the results
		int result = comObj->AddSomeNumbers(1, 2);
		_cprintf(
			"Result using interface via COM: %i \r\n", 
			result);
		comObj.Release();
	}
	
	CoUninitialize();
	
	//execute the test of the VB.NET object now
	_tmainVB(argc, argv);

	//execute the testing using a derived interface
	_tmain2(argc, argv);

	//wait for a key press
	_getch();
	return 0;
}


