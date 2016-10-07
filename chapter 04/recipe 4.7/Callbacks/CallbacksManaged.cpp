// Callbacks.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "CallbackUtility.h"	
#include "CallbacksManaged.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace MixedSharedLib;

void CallbackManaged::DoCallTest(void)
{
	//create a managed delegate pointing to a method
	CallbackDelegate^ cbDelegate = gcnew CallbackDelegate(
		this, &CallbackManaged::ReturnTheAnswer);
	//prevent garbage collection of the delegate
	GCHandle gchDelegate = GCHandle::Alloc(cbDelegate);
	//marshal the delegate to a pointer
	IntPtr pFunc 
		= Marshal::GetFunctionPointerForDelegate(cbDelegate);
	//cast the pointer to what the unmanaged method expects
	CallbackFunc cbFunc 
		= static_cast<CallbackFunc>(pFunc.ToPointer());
	//create an instance of the unmanaged class
	CCallbackUtility umObj;
	//execute the unmanaged test method
	umObj.DoTheCallbacks(cbFunc);
	//allow garbage collection of the delegate
	gchDelegate.Free();
}

//the managed target of the callbacks
void CallbackManaged::ReturnTheAnswer(
	long value, wchar_t* msg, int length)
{
	Console::WriteLine(
		"Callback via Delegate: {0}, {1}, {2}",
		value, gcnew String(msg), length);
}
