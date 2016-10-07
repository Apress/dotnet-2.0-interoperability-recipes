// DniComEventsObj.cpp : Implementation of CDniComEventsObj

#include "stdafx.h"
#include "DniComEventsObj.h"


// CDniComEventsObj


STDMETHODIMP CDniComEventsObj::ChangeDesc(BSTR newDesc)
{
	//fire the event that notifies any subscribers of
	//the description change
	Fire_OnDescChanged(newDesc, m_LastDesc);

	//save the updated description
	m_LastDesc = newDesc;

	return S_OK;
}
