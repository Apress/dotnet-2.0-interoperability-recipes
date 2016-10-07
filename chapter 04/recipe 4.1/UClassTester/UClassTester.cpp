// UClassTester.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "TestSimpleUnmanaged.h"
#include <conio.h>

int _tmain(int argc, _TCHAR* argv[])
{	
	CTestSimpleUnmanaged::Test();
	CTestSimpleUnmanaged::TestMixed();

	//wait for a key press	
	_getch();

	return 0;
}

