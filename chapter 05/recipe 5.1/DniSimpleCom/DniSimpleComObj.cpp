// DniSimpleComObj.cpp : Implementation of CDniSimpleComObj

#include "stdafx.h"
#include "DniSimpleComObj.h"



STDMETHODIMP CDniSimpleComObj::AddSomeNumbers(int numA, int numB, int* result)
{
	*result = numA + numB;
	return S_OK;
}
