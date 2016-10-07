#pragma once

#include <stdlib.h>
//demonstrates a shared class between managed and unmanaged
//code that uses _MANAGED macro to determine implementation

namespace MixedSharedLib
{
	class CSharedUtility
	{
	public:

		//conditionally compiled code based on the presence
		//or absence of the /clr compiler option
		#ifdef _MANAGED
		static int GetStringLength(String^ stringToCheck)
		{
			return stringToCheck->Length;
		}
		#else	
		static int GetStringLength(wchar_t* stringToCheck)
		{
			return (int)wcslen(stringToCheck);
		}
		#endif	
	};
}