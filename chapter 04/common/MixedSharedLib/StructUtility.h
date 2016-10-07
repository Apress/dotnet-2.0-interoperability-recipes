#pragma once

#pragma unmanaged
namespace MixedSharedLib
{
	//unmanaged struct
	struct IntSummary
	{
		int*  intArray;		//pointer to int array
		int   arrayCount;
		long* sum;			//pointer to long
	};

	class CStructUtility
	{
	public:
		//use the unmanaged struct
		static void SumInts(IntSummary value)
		{
			long sum = 0;
			for(int i = 0; i < value.arrayCount; i++)
			{
				sum += value.intArray[i];
			}
			*(value.sum) = sum;
		}

		static void SumInts(IntSummary* value)
		{
			long sum = 0;
			for(int i = 0; i < value->arrayCount; i++)
			{
				sum += value->intArray[i];
			}
			*(value->sum) = sum;
		}

	};
}
#pragma managed

