// DniDataTypesObj.cpp : Implementation of CDniDataTypesObj

#include "stdafx.h"
#include "DniDataTypesObj.h"
#include "comutil.h"

// CDniDataTypesObj


//
//basic data type methods
//

STDMETHODIMP CDniDataTypesObj::UseBool(boolean inParam, boolean* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseVariantBool(VARIANT_BOOL inParam, VARIANT_BOOL* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseLong(long inParam, long* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseDouble(double inParam, double* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseBSTR(BSTR inParam, BSTR* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseDecimal(DECIMAL inParam, DECIMAL* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseDate(DATE inParam, DATE* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseCurrency(CURRENCY inParam, CURRENCY* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseChar(unsigned char inParam, unsigned char* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseLPSTR(LPSTR inParam, LPSTR* outParam)
{
	*outParam = inParam;
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UseComCHAR(CHAR inParam, CHAR* outParam)
{
	*outParam = inParam;
	return S_OK;
}

//
//variant methods
//

STDMETHODIMP CDniDataTypesObj::UseVariant(VARIANT inParam, VARIANT* outParam, BSTR* variantDesc)
{
	//return the input VARIANT in the outParam
	*outParam = inParam;

	//determine the type of variant passed-in and
	//return a description for the type
	switch(inParam.vt)
	{
		case VT_BOOL:
			*variantDesc = (CComBSTR)"VT_BOOL";
			break;
		case VT_I4:
			*variantDesc = (CComBSTR)"VT_I4";
			break;
		case VT_I8:
			*variantDesc = (CComBSTR)"VT_I8";
			break;
		case VT_R8:
			*variantDesc = (CComBSTR)"VT_R8";
			break;
		case VT_BSTR:
			*variantDesc = (CComBSTR)"VT_BSTR";
			break;
		case VT_EMPTY:
			*variantDesc = (CComBSTR)"VT_EMPTY";
			break;
		case VT_NULL:
			*variantDesc = (CComBSTR)"VT_NULL";
			break;
		case VT_UNKNOWN:
			*variantDesc = (CComBSTR)"VT_UNKNOWN";
			break;
		case VT_RECORD:
			*variantDesc = (CComBSTR)"VT_RECORD";
			break;
		case VT_DECIMAL:
			*variantDesc = (CComBSTR)"VT_DECIMAL";
			break;
		case VT_DATE:
			*variantDesc = (CComBSTR)"VT_DATE";
			break;
		case VT_CY:
			*variantDesc = (CComBSTR)"VT_CY";
			break;
		case VT_ERROR:
			*variantDesc = (CComBSTR)"VT_ERROR";
			break;
		case VT_VOID:
			*variantDesc = (CComBSTR)"VT_VOID";
			break;
		case VT_INT:
			*variantDesc = (CComBSTR)"VT_INT";
			break;
		case VT_UINT:
			*variantDesc = (CComBSTR)"VT_UINT";
			break;
		case VT_UI4:
			*variantDesc = (CComBSTR)"VT_UI4";
			break;
		case VT_VARIANT:
			*variantDesc = (CComBSTR)"VT_VARIANT";
			break;
		case VT_PTR:
			*variantDesc = (CComBSTR)"VT_PTR";
			break;
		case VT_USERDEFINED:
			*variantDesc = (CComBSTR)"VT_USERDEFINED";
			break;
		case VT_ARRAY:
			*variantDesc = (CComBSTR)"VT_ARRAY";
			break;
		default:
			*variantDesc = (CComBSTR)"unknown type";
	}

	return S_OK;
}

//
//safearray methods
//

STDMETHODIMP CDniDataTypesObj::UseArray(SAFEARRAY* inParam, BSTR* outParam)
{
	//process the elements of the safearray
	BSTR* pBstr;
	unsigned long i = 0;
	SafeArrayAccessData(inParam, (void**)&pBstr);
	_bstr_t buffer;

	//retrieve all elements of the array		
	for (i = 0; i < inParam->rgsabound[0].cElements; i++)
	{
		buffer += _bstr_t(pBstr[i]);
			
	}
	//return the result string
	*outParam = buffer;
	SafeArrayUnaccessData(inParam);
	return S_OK;
}

STDMETHODIMP CDniDataTypesObj::UpdateArray(SAFEARRAY* inParam)
{
	//updates the elements of the safearray
	BSTR* pBstr;
	unsigned long i = 0;
	SafeArrayAccessData(inParam, (void**)&pBstr);

	//change all elements of the array		
	for (i = 0; i < inParam->rgsabound[0].cElements; i++)
	{
		_bstr_t buffer;
		buffer.Attach(pBstr[i]);
		buffer += "CHANGED";
		pBstr[i] = buffer.Detach();
	}
	SafeArrayUnaccessData(inParam);
	return S_OK;
}


STDMETHODIMP CDniDataTypesObj::UseCStyleArray(long inParam[], long arraySize, BSTR* outParam)
{
	//use a c-style array. copy the input 
	//values in the array into a BSTR and return it
	_bstr_t buffer;
	for(int i = 0; i < arraySize; i++)
	{
		buffer += _bstr_t(inParam[i]);
	}
	*outParam = buffer;

	return S_OK;
}
