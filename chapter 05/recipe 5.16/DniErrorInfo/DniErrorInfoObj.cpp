// DniErrorInfoObj.cpp : Implementation of CDniErrorInfoObj

#include "stdafx.h"
#include "DniErrorInfoObj.h"

#include "corerror.h"


// CDniErrorInfoObj

STDMETHODIMP CDniErrorInfoObj::InterfaceSupportsErrorInfo(REFIID riid)
{
	static const IID* arr[] = 
	{
		&IID_IDniErrorInfoObj
	};

	for (int i=0; i < sizeof(arr) / sizeof(arr[0]); i++)
	{
		if (InlineIsEqualGUID(*arr[i],riid))
			return S_OK;
	}
	return S_FALSE;
}

STDMETHODIMP CDniErrorInfoObj::GenerateError(long inParam)
{
	HRESULT result	= S_OK;
	//set the HRESULT based on the request
	switch(inParam)
	{
		case 1:
			result	= E_INVALIDARG;
			break;
		case 2:
			result	= E_INVALIDARG;
			GenerateErrorInfo(_uuidof(IDniErrorInfoObj),
				"CDniErrorInfoObj::GenerateError", 
				"Value is x but should be y");
			break;
		case 3:
			result	= 0x80040301L;	//user defined error
			break;
		case 4:
			result	= 0x80040301L;	//user defined error
			GenerateErrorInfo(_uuidof(IDniErrorInfoObj),
				"CDniErrorInfoObj::GenerateError", 
				"My Error Message");
			break;

		default:
			break;
	}

	return result;
}

void CDniErrorInfoObj::GenerateErrorInfo(REFGUID rGUID, 
		_bstr_t source, _bstr_t message)
{
    ICreateErrorInfo* pCreateInfo		= NULL;
	IErrorInfo* pErrorInfo				= NULL;
	//create a generic error object
    CreateErrorInfo(&pCreateInfo);

	//set properties of the object
	pCreateInfo->SetGUID(rGUID);
	pCreateInfo->SetSource(source);
	pCreateInfo->SetDescription(message);

	//get the IErrorInfo interface for the error info object
	pCreateInfo->QueryInterface(IID_IErrorInfo, (void**)&pErrorInfo);

	//set the error object for the local thread
	SetErrorInfo(0,pErrorInfo);

	//release our COM objects
	pErrorInfo->Release();
	pCreateInfo->Release();
}

