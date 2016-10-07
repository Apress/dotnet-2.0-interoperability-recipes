
#include "stdafx.h"
#include <gcroot.h>

//managed class that will handle the callback
public ref class CallbackManagedClass
{
public:
	//method to execute during a callback
	void ReturnTheAnswer(long value, wchar_t* msg, int length);
};

//unmanaged wrapper used to direct 
//callbacks to CallbackManagedClass
public class CallbackWrapper
{
public:
	static void CallUnmanagedCode(
		gcroot<CallbackManagedClass^> obj);
	static void CallbackHandler(
		long value, wchar_t* msg, int length);
private:
	static gcroot<CallbackManagedClass^> s_ManagedObj;
};

