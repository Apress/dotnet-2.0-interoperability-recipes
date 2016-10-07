#pragma once

using namespace System;

namespace CppInteropWrappers
{

//define a C++ wrapper for exception handling
public ref class CppExceptionTestWrapper
{
public:
    //an enum used to translate result integers
	enum struct ResultDescEnum
	{
		ValueOne = 1,
		ValueTwo = 2,
		ValueThree = 3,
		ValueFour = 4
	};
    String^ RunExceptionTest(int exceptionType);
};

}