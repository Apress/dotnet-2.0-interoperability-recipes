// ComStrings.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <objbase.h>
#include <atlbase.h>
#import "mscorlib.tlb"
#import "DniNetStrings.tlb" no_namespace

int _tmain(int argc, _TCHAR* argv[])
{
	::CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

	//create an instance of the .NET object via COM
	IStringsPtr comObj(__uuidof(DniNetStringsObj));
	if (comObj)
	{
		//return a BSTR
		_bstr_t bstrResult 
			= comObj->ReturnBSTR(L"one", L"two");
		_cprintf("ReturnBSTR: %S \r\n", (wchar_t*)bstrResult);

		//return a BSTR as an in/out
		CComBSTR cBstrResult = "unchanged";
		comObj->InOutBSTR(L"one", L"two", (BSTR*)&cBstrResult);
		_cprintf("InOutBSTR: %S \r\n", (wchar_t*)bstrResult);

		//return a BSTR as an out
		cBstrResult = "unchanged";
		comObj->OutBSTR(L"one", L"two", (BSTR*)&cBstrResult);
		_cprintf("OutBSTR: %S \r\n", (wchar_t*)bstrResult);

		//return a BSTR as an in/out StringBuilder
		wchar_t* pWideBuilder = new wchar_t[10];
		wcscpy_s(pWideBuilder,10,L"unchanged");
		comObj->InOutBuilder(L"one", L"two", pWideBuilder);
		_cprintf("InOutBuilder: %S \r\n", pWideBuilder);
		delete [] pWideBuilder;			

		//return the string as a LPWSTR
		wchar_t* pWideResult 
			= comObj->ReturnLPWSTR(L"one", L"two"); 
		_cprintf("ReturnLPWSTR: %S \r\n", pWideResult);
		//free the memory that was returned
		::CoTaskMemFree(pWideResult);

		//return the string as an ANSI string (LPSTR)
		char* pAnsiResult 
			= comObj->ReturnLPSTR(L"one", L"two"); 
		_cprintf("ReturnLPSTR: %s \r\n", pAnsiResult);
		//free the memory that was returned
		::CoTaskMemFree(pAnsiResult);
		
		//pass and return strings as a LPWSTR
		pWideResult 
			= comObj->PassAndReturnLPWSTR(L"one", L"two"); 
		_cprintf("PassAndReturnLPWSTR: %S \r\n", pWideResult);
		//free the memory that was returned
		::CoTaskMemFree(pWideResult);

		comObj.Release();
	}

	//test VB.NET version of the string class
	TestVBNET();

	//cleanup
	::CoUninitialize();

	//wait for a key press
	_getch();
	return 0;
}

