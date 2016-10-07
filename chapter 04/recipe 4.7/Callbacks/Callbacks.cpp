// Callbacks.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include "Callbacks.h"
#include "CallbacksWrapper.h"
#include "CallbacksManaged.h"

using namespace System;

int _tmain(int argc, _TCHAR* argv[])
{
	//tests using managed class directly 
	CallbackManaged^ cbStdCall = gcnew CallbackManaged();
	cbStdCall->DoCallTest();

	//tests using an unmanaged wrapper
	CallbackManagedClass^ cbTest 
		= gcnew CallbackManagedClass();
	CallbackWrapper::CallUnmanagedCode(cbTest);

	_getch();

	return 0;
}

