#pragma once

using namespace System;

namespace CppInteropWrappers
{

//managed exception thrown by the C++ wrapper
public ref class CppException 
	: public ApplicationException
{
public:
    CppException(String^ message, int errorCode) 
        : ApplicationException(message)
    {
        ErrorCode = errorCode;
    };
    int ErrorCode; 
};

//define a C++ wrapper for exception handling
public ref class CppExceptionTestWrapper2
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