#pragma once
#include "StdAfx.h"

namespace USharedLib
{
	class __declspec(dllexport) CUnmanaged
	{
	public:
		CUnmanaged(void);
		void AddNumber(int number);
		int GetTheResult();
	private:
		int		m_Total;
	};


}


class CMyUnmanagedClass
{
public:
	CMyUnmanagedClass(void)  {};
	~CMyUnmanagedClass(void) {};
	int foo(void)
	{
		return 1;
	}
};

