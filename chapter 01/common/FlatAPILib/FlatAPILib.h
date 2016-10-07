//referencing and using an unmanaged function

#include <string.h>

// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the FLATAPILIB_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// FLATAPILIB_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
//#ifdef FLATAPILIB_EXPORTS
//#define FLATAPILIB_API extern "C" __declspec(dllexport)
//#else
//#define FLATAPILIB_API extern "C" __declspec(dllimport)
//#endif

//FLATAPILIB_API int __stdcall AddSomeNumbers(int numOne, int numTwo);
extern "C" __declspec(dllexport) int __stdcall AddSomeNumbers(int numOne, int numTwo);

//#if defined FLATAPI_EXPORTS
//extern "C" __declspec(dllexport) int AddSomeNumbers(int numOne, int numTwo);
//#else
//extern "C" __declspec(dllimport) int __stdcall AddSomeNumbers(int numOne, int numTwo);
//#endif 

//unmanaged function wrapper
extern "C" __declspec(dllexport) int GetCustomerStatus(char* customerId, int customerType);

//calling convention
extern "C" __declspec(dllexport) int __cdecl AddSomeNumbersCdecl(int numOne, int numTwo);
extern "C" __declspec(dllexport) int __stdcall AddSomeNumbersStdCall(int numOne, int numTwo);

//entry point
extern "C" __declspec(dllexport) int FunctionToRename(int valueOne);
extern "C" __declspec(dllexport) int PolymorphicFunction(void* anyValue, int dataType);

//character set
extern "C" __declspec(dllexport) void __cdecl CombineStringsW(wchar_t* stringA, wchar_t* stringB, wchar_t* result);
extern "C" __declspec(dllexport) void __cdecl CombineStringsA(char* stringA, char* stringB, char* result);
extern "C" __declspec(dllexport) void CombineAnsiStrings(char* stringA, char* stringB, char* result);
extern "C" __declspec(dllexport) void CombineUnicodeStrings(wchar_t* stringA, wchar_t* stringB, wchar_t* result);

//blittable types
extern "C" __declspec(dllexport) bool NonblittableFunction(char valueToTest);
extern "C" __declspec(dllexport) int BlittableFunction(__int8 valueToTest);
extern "C" __declspec(dllexport) void BlittableUnmanagedTest();

//errors and exceptions
extern "C" __declspec(dllexport) int DivideSomeNumbers(int numOne, int numTwo);
extern "C" __declspec(dllexport) int DoFailingIO(char* fileName);
extern "C" __declspec(dllexport) int UnmanagedRuntimeError();
__declspec(dllexport) int UnmanagedRuntimeException();

//a custom unmanaged exception
class UnmanagedException
{
public:
	UnmanagedException(void) {}
	~UnmanagedException(void)
	{
	    delete [] Message;
	}
	UnmanagedException(char* msg, int errorCode)
	{
	    ErrorCode = errorCode;
		size_t bufLength = strlen(msg) + 1;
		Message   = new char[bufLength];
		strcpy_s(Message, bufLength, msg);
	}
	char* Message;
	int   ErrorCode;
};
//function for testing of custom unmanaged exceptions
extern "C" __declspec(dllexport) int  ThrowUnmanagedExceptions(int type);

//functions that allocates unmanaged memory
extern "C" __declspec(dllexport) wchar_t* ReturnUnmanagedString(const wchar_t* leftString, const wchar_t* rightString);
extern "C" __declspec(dllexport) void FreeUnmanagedString(void* p);
extern "C" __declspec(dllexport) wchar_t* ReturnComAllocatedString(const wchar_t* leftString, const wchar_t* rightString);

//functions for security permission
extern "C" __declspec(dllexport) int GetStringLength(char* aString);

//function used for security wrapper testing
extern "C" __declspec(dllexport) char* ProcessTestFile(const char* fullFilePath);

//dynamically load a dll and access a function
extern "C" __declspec(dllexport) 
int __cdecl DynamicallyAddSomeNumbers(
	int numOne, int numTwo);
