#pragma once

#include <stdlib.h>
#include <string.h>
//demonstrates passing a string from managed to unmanaged code

#pragma unmanaged
namespace MixedSharedLib
{
	//unmanaged utility class
	public class CStringUtility
	{
	public:
		//modify the string
		static wchar_t* ProcessString(
			const wchar_t* stringIn)
		{
			size_t bufSize = wcslen(stringIn) + 50;
			wchar_t* pResult = new wchar_t[bufSize];
			wcscpy_s(pResult, bufSize, stringIn);
			wcscat_s(pResult, bufSize, L"AddedString");
			return pResult;
		}

		//the ansi version
		static char* ProcessString(
			const char* stringIn)
		{
			size_t bufSize = strlen(stringIn) + 50;
			char* pResult = new char[bufSize];
			strcpy_s(pResult, bufSize, stringIn);
			strcat_s(pResult, bufSize, "AddedANSIString");
			return pResult;
		}

	};
}
#pragma managed