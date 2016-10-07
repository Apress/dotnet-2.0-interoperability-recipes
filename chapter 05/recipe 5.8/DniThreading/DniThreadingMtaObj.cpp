// DniThreadingMtaObj.cpp : Implementation of CDniThreadingMtaObj

#include "stdafx.h"
#include "DniThreadingMtaObj.h"


// CDniThreadingMtaObj
STDMETHODIMP CDniThreadingMtaObj::AddNumbers(long numA, long numB, long* result)
{
	*result = numA + numB;
	return S_OK;
}

