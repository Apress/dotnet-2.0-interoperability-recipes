// DniThreadingStaObj.cpp : Implementation of CDniThreadingStaObj

#include "stdafx.h"
#include "DniThreadingStaObj.h"


// CDniThreadingStaObj
STDMETHODIMP CDniThreadingStaObj::AddNumbers(long numA, long numB, long* result)
{
	*result = numA + numB;
	return S_OK;
}


