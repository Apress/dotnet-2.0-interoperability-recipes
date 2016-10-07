//#pragma once

//demonstrates use of a managed class that uses inline 
//unmanaged functions.  Uses the managed and unmanaged #pragma

using namespace System;

namespace MixedSharedLib
{
	#pragma unmanaged

	//unmanaged helper function
	int ReturnHighest(int numA, int numB)
	{
		//return the higher number
		return (numA > numB ? numA : numB);
	}

	#pragma managed

	//managed class
	public ref class MixedWithHelper
	{
	public:
		MixedWithHelper(void) {}

		//find the length of the longest string
		int GetLongestStringLength(String^ paramA, 
			String^ paramB, String^ paramC)
		{
			//use the unmanaged helper function
			int highest = ReturnHighest(
				paramA->Length, paramB->Length);
			highest = ReturnHighest(
				highest, paramC->Length);

			return highest;
		}
	};
}