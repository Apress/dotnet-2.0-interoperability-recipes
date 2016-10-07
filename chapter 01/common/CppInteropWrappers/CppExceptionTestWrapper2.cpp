#include "StdAfx.h"

#include ".\cppexceptiontestwrapper2.h"
#include "..\..\common\FlatAPILib\FlatAPILib.h"
#include <exception>

namespace CppInteropWrappers
{

//catch exceptions thrown by unmanaged code
String^ CppExceptionTestWrapper2::RunExceptionTest(int exceptionType)
{
	String^ result = String::Empty;
	int resultCode = 0;
	try
	{
	    //call the unmanaged function using C++ Interop
		resultCode = ThrowUnmanagedExceptions(exceptionType);
		//no exceptions thrown so turn the result code into an enum
		ResultDescEnum resultEnum	
			= (ResultDescEnum)resultCode;
		//get the description for the enum
		result = Enum::Format(
			ResultDescEnum::typeid, resultEnum, "G");
	}
	catch(int e)
	{
	    throw gcnew CppException(e.ToString(), e);
	}
	catch(UnmanagedException& e)
	{
	    throw gcnew CppException(
			gcnew String(e.Message), e.ErrorCode);
	}
	catch(std::exception& e)
	{
        throw gcnew CppException(gcnew String(e.what()), 0);
	}
	return result;
}

}