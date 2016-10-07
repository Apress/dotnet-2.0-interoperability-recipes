
#include "stdafx.h"

using namespace System::Runtime::InteropServices;

//managed class that is used for unmanaged callbacks

//managed delegate
[UnmanagedFunctionPointer(CallingConvention::Cdecl)]
public delegate void CallbackDelegate(
	long value, wchar_t* msg, int length);

public ref class CallbackManaged
{
public:
	void DoCallTest(void);
private:
	//the target of the callbacks
	void ReturnTheAnswer(long value, wchar_t* msg, int length);
};
