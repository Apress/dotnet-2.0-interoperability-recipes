#pragma once

#include "MixedNumber.h"
#include "MixedNativeNumber.h"
#include "SharedUtility.h"

namespace MixedSharedLib
{
	public ref class TraitChecker
	{
	public:

		//determine if the type is a native c++ class
		static bool IsClass(int request)
		{
			bool result = false;
			switch(request)
			{
				case 1:
					result = __is_class(MixedNumber);
					break;
				case 2:
					result = __is_class(CMixedNativeNumber);
					break;
			}
			return result;
		}

		//determine if the type is a ref managed class
		static bool IsRefClass(int request)
		{
			bool result = false;
			switch(request)
			{
				case 1:
					result = __is_ref_class(MixedNumber);
					break;
				case 2:
					result = __is_ref_class(CMixedNativeNumber);
					break;
			}
			return result;
		}

		//has the /clr option been set?
		static String^ IsClrOptionSet(void)
		{
			#ifdef _MANAGED
				return "Clr option set";
			#else
				return "Native code only";
			#endif
		}

		//call the /clr version of the string length method
		static int GetStringLength(String^ str)
		{
			return CSharedUtility::GetStringLength(str);
		}
	};
}
