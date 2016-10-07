// ComPreserveSig.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include <objbase.h>
#include <atlbase.h>
#import "mscorlib.tlb"
#import "DniNetPreserveSig.tlb" no_namespace 

int _tmain(int argc, _TCHAR* argv[])
{
	CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

	//create an instance of the .NET object via COM
	IPreserveSigPtr
		comObj(__uuidof(DniNetPreserveSigObj));
	if (comObj)
	{
		HRESULT hr;
		CComBSTR result;

		hr = comObj->CopyString(L"test", &result);
		_cprintf(
			"CopyString with string: 0x%8.8x \r\n", hr);

		hr = comObj->CopyString(L"", &result);
		_cprintf(
			"CopyString with empty string: 0x%8.8x \r\n", hr);

		hr = comObj->CopyStringPreserve(L"test", &result);
		_cprintf(
			"CopyStringPreserve with string: 0x%8.8x \r\n", hr);

		hr = comObj->CopyStringPreserve(L"", &result);
		_cprintf(
			"CopyStringPreserve with empty string: 0x%8.8x \r\n", hr);

		comObj.Release();
	}
	
	CoUninitialize();

	//wait for a key press
	_getch();
	return 0;
}
