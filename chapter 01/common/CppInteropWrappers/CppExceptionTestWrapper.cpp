#include "StdAfx.h"
#include ".\cppexceptiontestwrapper.h"

#include "..\..\common\FlatAPILib\FlatAPILib.h"
#include <exception>

namespace CppInteropWrappers
{

//catch exceptions thrown by unmanaged code
String^ CppExceptionTestWrapper::RunExceptionTest(
	int exceptionType)
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
	    //catch the integer exception
		result = e.ToString();
	}
	catch(UnmanagedException& e)
	{
	    //catch the custom unmanaged exception
		result = String::Format(
			"{0}: {1}", gcnew String(e.Message), e.ErrorCode);
	}
	catch(std::exception& e)
	{
	    //catch a standard C++ exception
		result = gcnew String(e.what());
	}
	return result;
}

}