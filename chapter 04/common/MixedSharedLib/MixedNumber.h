#pragma once

//demonstrates a managed class within a mixed assembly

#include "StdAfx.h"

using namespace System;

namespace MixedSharedLib
{
	public ref class MixedNumber
	{
	public:
		MixedNumber(void)  {}
		~MixedNumber(void) {}
		int AddTheNumbers(int numA, int numB)
		{
			return numA + numB;
		}

	};
}	