// SimpleNumberClient.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <objbase.h>
#import "mscorlib.tlb"
#import "DniNetSimpleNumbersDual.tlb" no_namespace 

int _tmain(int argc, _TCHAR* argv[])
{
	CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

	//create an instance of the .NET object via COM
	_DniNetSimpleNumbersDualPtr 
		comObj(__uuidof(DniNetSimpleNumbersDual));
	if (comObj)
	{
		//call the method and show the results
		int result = comObj->AddSomeNumbers(1, 2);
		_cprintf(
			"Result from C++ client code: %i \r\n", 
			result);
		comObj.Release();
	}
	
	CoUninitialize();

	//wait for a key press
	_getch();
	return 0;
}

