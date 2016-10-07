// PassStructs.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include "StructUtility.h"	

using namespace System::Runtime::InteropServices;	//for the marshal class

using namespace System;
using namespace MixedSharedLib;

//managed struct
public value struct ManagedIntSummary
{
	int*  intArray;		//pointer to int array
	int   arrayCount;
	long* sum;			//pointer to long
};


int _tmain(int argc, _TCHAR* argv[])
{
	//
	//pass a struct allocated on the stack
	//

	//initialize the unmanaged struct
	IntSummary intSum;
	intSum.arrayCount	= 5;
	intSum.intArray		= new int[intSum.arrayCount];
	intSum.sum			= new long;
	*intSum.sum			= 0;
	for(int i = 0; i < intSum.arrayCount; i++)
	{
		intSum.intArray[i]	= i;
	}

	//call the unmanaged method, passing the struct
	CStructUtility::SumInts(intSum);
	Console::WriteLine("Unmanaged sum of ints (stack) {0}", 
		*(intSum.sum));
	//free any memory that we allocated
	delete [] intSum.intArray;
	delete intSum.sum;

	//
	//pass a struct allocated on the unmanaged heap
	//

	//initialize the unmanaged struct
	IntSummary* pIntSum	= new IntSummary();
	pIntSum->arrayCount	= 5;
	pIntSum->intArray		= new int[pIntSum->arrayCount];
	pIntSum->sum			= new long;
	*(pIntSum->sum)			= 0;
	for(int i = 0; i < pIntSum->arrayCount; i++)
	{
		pIntSum->intArray[i]	= i;
	}

	//call the unmanaged method, passing the struct
	CStructUtility::SumInts(pIntSum);
	Console::WriteLine("Unmanaged sum of ints (heap)  {0}", 
		*(pIntSum->sum));
	//free any memory that we allocated
	delete [] pIntSum->intArray;
	delete pIntSum->sum;
	delete pIntSum;

	//
	//pass a managed struct to the unmanaged method
	//

	//initialize the managed struct
	ManagedIntSummary^ pManIntSum	
		= gcnew ManagedIntSummary();
	pManIntSum->arrayCount	= 5;
	pManIntSum->intArray	= new int[pManIntSum->arrayCount];
	pManIntSum->sum			= new long;
	*(pManIntSum->sum)		= 0;
	for(int i = 0; i < pManIntSum->arrayCount; i++)
	{
		pManIntSum->intArray[i]	= i;
	}

	//get a pointer for the managed struct
	IntPtr pManPtr	
		= Marshal::AllocHGlobal(sizeof(ManagedIntSummary));
	Marshal::StructureToPtr(pManIntSum, pManPtr, true);
	//cast to the unmanaged struct type
	IntSummary* pUnmanagedPtr
		= static_cast<IntSummary*>(pManPtr.ToPointer());

	//call the unmanaged method, passing the 
	//pointer to the managed struct
	CStructUtility::SumInts(pUnmanagedPtr);
	Console::WriteLine("Unmanaged sum of ints (managed) {0}", 
		*(pManIntSum->sum));
	//free any memory that we allocated
	delete [] pManIntSum->intArray;
	delete pManIntSum->sum;
	Marshal::FreeHGlobal(pManPtr);

	_getch();

	return 0;
}

