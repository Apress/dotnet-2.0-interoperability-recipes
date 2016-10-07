#pragma once

#include <wchar.h>

#pragma unmanaged
namespace MixedSharedLib
{
	//define the callback function using the project
	//default of __cdecl
	typedef void (*CallbackFunc)
		(long value, wchar_t* msg, int length);

	class CCallbackUtility
	{
	public:
		//method that does a callback
		void DoTheCallbacks(CallbackFunc pFunc)
		{
			if (pFunc)
			{
				for(int i = 0; i < 5; i++)
				{
					wchar_t* pMsg = new wchar_t[20];
					_swprintf_p(pMsg, 20, L"Msg #%i", i); 
					//do the callback to managed code
					(*pFunc)(i, pMsg, (int)wcslen(pMsg));
					delete [] pMsg;
				}
			}
		}
	};
}
#pragma managed

