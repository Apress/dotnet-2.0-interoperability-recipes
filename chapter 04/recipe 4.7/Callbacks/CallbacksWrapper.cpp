
#include "stdafx.h"
#include <gcroot.h>
#include "CallbackUtility.h"	
#include "CallbacksWrapper.h"

using namespace System;
using namespace MixedSharedLib;

//
//methods used for wrapper testing
//

//method to execute during a callback
void CallbackManagedClass::ReturnTheAnswer(
	long value, wchar_t* msg, int length)
{
	Console::WriteLine(
		"Callback via Wrapper: {0}, {1}, {2}",
		value, gcnew String(msg), length);
}

//static instance of managed object
gcroot<CallbackManagedClass^> CallbackWrapper::s_ManagedObj;

void CallbackWrapper::CallUnmanagedCode(
	gcroot<CallbackManagedClass^> obj)
{
	//save the managed object
	s_ManagedObj = obj;
	//get the address of the unmanaged callback handler
	CallbackFunc cbFunc 
		= static_cast<CallbackFunc>(CallbackHandler);
	//create the unmanaged obj and run the test
	CCallbackUtility umObj;
	umObj.DoTheCallbacks(cbFunc);
}

//the target of the callbacks 
// - pass-thru to the managed object
void CallbackWrapper::CallbackHandler(
	long value, wchar_t* msg, int length)
{
	//call the method in the managed object
	s_ManagedObj->ReturnTheAnswer(value, msg, length);
}

