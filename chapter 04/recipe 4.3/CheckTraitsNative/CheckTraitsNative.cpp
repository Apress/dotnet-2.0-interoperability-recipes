// CheckTraitsNative.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include "SharedUtility.h"

using namespace MixedSharedLib;

int _tmain(int argc, _TCHAR* argv[])
{
	//call the non-clr version of the string length method
	int result = CSharedUtility::GetStringLength(L"abc");

	//show the results
	_cprintf("String length from Native call: %i \r\n",
		result);

	//wait for a key press	
	_getch();

	return 0;
}

