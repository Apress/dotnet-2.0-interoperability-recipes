#include "StdAfx.h"
#include "Managed.h"

namespace MClassLib
{
	Managed::Managed(void)
	{
		//create an instance of the unmanaged class
		m_pUnmanagedObj 
			= new USharedLib::CUnmanaged();
	}

	Managed::~Managed(void)
	{
		//delete the unmanaged memory we allocated
		delete m_pUnmanagedObj;
		m_pUnmanagedObj		= NULL;
	}

	int Managed::AddTheNumbers(int numA, int numB)
	{
		//call the methods of the unmanaged object
		m_pUnmanagedObj->AddNumber(numA);
		m_pUnmanagedObj->AddNumber(numB);
		return m_pUnmanagedObj->GetTheResult();
	}
}