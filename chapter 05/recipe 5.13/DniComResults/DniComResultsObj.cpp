// DniComResultsObj.cpp : Implementation of CDniComResultsObj

#include "stdafx.h"
#include "DniComResultsObj.h"

#include "corError.h"	//defines COM HRESULTS that are mapped to .NET exceptions

// CDniComResultsObj

STDMETHODIMP CDniComResultsObj::ProvideDifferentResults(long request)
{
	HRESULT result	= S_OK;
	switch(request)
	{
		case 1:
			result	= E_INVALIDARG;
			break;
		case 2:
			result	= E_NOTIMPL;
			break;
		case 3:
			result	= E_OUTOFMEMORY;
			break;
		case 4:
			result	= COR_E_NOTSUPPORTED;
			break;
		case 5:
			result	= 0x80040301L;	//user defined error
			break;

		default:
			break;
	}

	return result;
}

STDMETHODIMP CDniComResultsObj::GetTheResult(long request)
{
	HRESULT result	= S_OK;
	switch(request)
	{
		case 1:
			result	= S_FALSE;
			break;
		case 2:
			result	= 0x00040301L;	//user defined code
			break;
		case 3:
			result	= E_INVALIDARG;
			break;

		default:
			break;
	}

	return result;
}

STDMETHODIMP CDniComResultsObj::GetTheResultRefactored(
		long request, HRESULT* hResult)
{
	HRESULT result	= S_OK;
	switch(request)
	{
		case 1:
			result	= S_FALSE;
			break;
		case 2:
			result	= 0x00040301L;	//user defined code
			break;
		case 3:
			result	= E_INVALIDARG;
			break;

		default:
			break;
	}
	
	//set the out parameter with the HRESULT
	*hResult	= result;

	return result;
}
