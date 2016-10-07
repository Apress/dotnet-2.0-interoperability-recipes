#pragma once

#include "Unmanaged.h"

using namespace System;

namespace MClassLib
{
	//a managed wrapper for an unmanaged C++ class
	public ref class Managed
	{
	public:
		Managed(void);
		~Managed(void);
		int AddTheNumbers(int numA, int numB);
	private:
		//pointer to the unmanaged object
		USharedLib::CUnmanaged*	m_pUnmanagedObj;
	};
}

//simple wrapper included here only to make sure it compiles :)

public ref class MyWrapper
{
public:
	MyWrapper (void)  
	{
		pObj = new CMyUnmanagedClass();
	}
	~MyWrapper (void)
	{
		delete pObj;
	}
	int foo(void)
	{
		return pObj->foo();
	}
	
private:
	CMyUnmanagedClass* pObj;

};


