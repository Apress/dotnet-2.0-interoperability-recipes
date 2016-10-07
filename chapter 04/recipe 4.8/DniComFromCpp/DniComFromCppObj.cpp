// DniComFromCppObj.cpp : Implementation of CDniComFromCppObj

#include "stdafx.h"
#include "DniComFromCppObj.h"
#include <comutil.h> 

STDMETHODIMP CDniComFromCppObj::ModifyString(
	BSTR inParam, BSTR* outParam)
{
	_bstr_t workBSTR 
		= _bstr_t(inParam) + _bstr_t(L"AddedThis");
	*outParam = workBSTR;
	return S_OK;
}
