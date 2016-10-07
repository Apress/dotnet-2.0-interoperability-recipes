#pragma once

//demonstrates an unmanaged class within a mixed assembly

namespace MixedSharedLib
{
	class __declspec(dllexport) CMixedNativeNumber
	{
	public:
		CMixedNativeNumber(void)  {}
		~CMixedNativeNumber(void) {}
		int AddTheNumbers(int numA, int numB);
	};

}