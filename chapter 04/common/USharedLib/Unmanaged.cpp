#include "StdAfx.h"
#include "Unmanaged.h"

namespace USharedLib
{
	CUnmanaged::CUnmanaged(void)
	{
		m_Total		= 0;
	}

	//add to the internal integer
	void CUnmanaged::AddNumber(int number)
	{
		m_Total += number;
	}

	//retrieve the current total
	int CUnmanaged::GetTheResult()
	{
		return m_Total;
	}
}