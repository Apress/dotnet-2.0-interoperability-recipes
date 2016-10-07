#include "stdafx.h"
#include "FlatAPILib.h"

#include <exception>
#include "objbase.h"    //CoTaskMemAlloc

#include <windows.h>
#include <stdio.h>

#include <strsafe.h>

//
// A trivial unmanaged function that we want to call
// from managed code
int __stdcall AddSomeNumbers(int numOne, int numTwo)
{
    return numOne + numTwo;
}

// function used to demonstrate a managed wrapper
int GetCustomerStatus(char* customerId, int customerType)
{
    //lookup customer status based on the customerId
    //and customerType
    
    if (customerType == 2122)
    {
        return 1; //current
    }
    else if (strcmp(customerId, "bbbbbb") == 0)
    {
        return 3; //past due
    }
    return 0;
}

// An unmanaged function that uses a different calling convention
int __cdecl AddSomeNumbersCdecl(int numOne, int numTwo)
{
    return numOne + numTwo;
}

// An unmanaged function that uses a different calling convention
int __stdcall AddSomeNumbersStdCall(int numOne, int numTwo)
{
    return numOne + numTwo;
}

// function that demonstrates specifying an entry point
int FunctionToRename(int valueOne)
{
    return 111;
}

// function that demonstrates specifying an entry point
int PolymorphicFunction(void* anyValue, int dataType)
{
    int anInt = 0;
    if (dataType == 1) //integer
    {
        int* pInt = (int*)anyValue;

        if (pInt > 0)
        {
            anInt = *pInt;
        }
    }
    if (anInt > 0)
    {   
        return anInt;
    }
    else
    {
        return 900;
    }
}

// function for character set testing
void __cdecl CombineStringsW(wchar_t* stringA, wchar_t* stringB, wchar_t* result)
{
    int bufLength = (int)wcslen(stringA) + (int)wcslen(stringB) + 100;
    wchar_t* tempResult = new wchar_t[bufLength];
    wcscpy_s(tempResult, bufLength, stringA);
    wcscat_s(tempResult, bufLength, stringB);
    wcscat_s(tempResult, bufLength, 
		L" Another Unicode String ");
    wcscat_s(tempResult, bufLength, L"Unicode");    
    wcscpy_s(result, bufLength, tempResult);
    delete [] tempResult;    
}
// function for character set testing
void __cdecl CombineStringsA(char* stringA, char* stringB, char* result)
{
    int bufLength = (int)strlen(stringA) + (int)strlen(stringB) + 100;
    char* tempResult = new char[bufLength];
    strcpy_s(tempResult, bufLength, stringA);
    strcat_s(tempResult, bufLength, stringB);
    strcat_s(tempResult, bufLength, "ANSI");
    strcpy_s(result, bufLength, tempResult);
    delete [] tempResult;
}
// function for character set testing
// this one tests conversion of managed unicode strings to ansi
// when we don't have separate managled functions for unicode and ansi.
void CombineAnsiStrings(char* stringA, char* stringB, char* result)
{
    int bufLength = (int)strlen(stringA) + (int)strlen(stringB) + 100;
    char* tempResult = new char[bufLength];
    strcpy_s(tempResult, bufLength, stringA);
    strcat_s(tempResult, bufLength, stringB);
    strcat_s(tempResult, bufLength, "ANSI");
    strcpy_s(result, bufLength, tempResult);
    delete [] tempResult;
}
// function for character set testing
void CombineUnicodeStrings(wchar_t* stringA, wchar_t* stringB, wchar_t* result)
{
    int bufLength = (int)wcslen(stringA) + (int)wcslen(stringB) + 100;
    wchar_t* tempResult = new wchar_t[bufLength];
    wcscpy_s(tempResult, bufLength, stringA);
    wcscat_s(tempResult, bufLength, stringB);
    wcscat_s(tempResult, bufLength, L"Unicode");    
    wcscpy_s(result, bufLength, tempResult);
    delete [] tempResult;    
}

// function for blittable type testing 
bool NonblittableFunction(char valueToTest)
{
    return (islower(valueToTest) != 0);
}
// function for blittable type testing
int BlittableFunction(__int8 valueToTest)
{
    return islower(valueToTest);
}
// function for blittable type testing
// used to execute test entirely in unmanaged code
void BlittableUnmanagedTest()
{
    const int numberOfCalls = 100000;
    bool result             = false;
    for(int i = 0; i < numberOfCalls; i++)
    {
        result = ::NonblittableFunction('a');
    }
}

#pragma runtime_checks("", off)
#pragma warning(disable: 4700)
// function generates an error within managed code.
// used to execute exception and error handling test
int DivideSomeNumbers(int numOne, int numTwo)
{
    return numOne / numTwo;
}
// perform win32 io to generate an error within unmanged code
int DoFailingIO(char* fileName)
{
    return DeleteFile(fileName);
}
// do something bad with memory
int UnmanagedRuntimeError()
{
    //do something that causes problems
    char* unAllocatedPointer	= NULL;
    char* sourcePointer         = NULL;
    strcpy(unAllocatedPointer, sourcePointer);
    
    return 0;
}

// throw an exception from unmanaged code
int UnmanagedRuntimeException()
{
//    throw std::exception("My new exception");
//    RaiseException(111, 0, 0, 0); //structured exception
    throw 55555;    //c++ style exception
    return 0;
}

#pragma runtime_checks("", restore)
#pragma warning(default: 4700)

#pragma warning(disable: 4297)
//function for testing of custom unmanaged exceptions
int ThrowUnmanagedExceptions(int type)
{
    //depending on the value passed in, we
    //throw a different type of exception
	if (type == 1)
	{
	    //throw a simple error number
		throw 1234;
	}
	else if (type == 2)
	{
	    //throw a custom exception
		throw UnmanagedException("My exception Message", 2001);			
	}
	else if (type == 3)
	{
	    //throw a standard C++ exception
		throw std::exception("My Std Exception Message");
	}
	//no exception to throw so we just return our
	//input parameter
    return type;
}
#pragma warning(default: 4297)

//function that allocates unmanaged memory using CRT
wchar_t* ReturnUnmanagedString(
	const wchar_t* leftString, const wchar_t* rightString)
{
    size_t charCount = wcslen(leftString) 
        + wcslen(rightString) + 1;
    wchar_t* result     = new wchar_t[charCount];
	StringCbCopyW(result, charCount * 2, leftString);
	StringCbCatW(result, charCount * 2, rightString);
    return result;
}

//free unmanaged memory that was previously allocated
void FreeUnmanagedString(void* p)
{
    delete [] p;
}

//function that allocates unmanaged memory using CoTaskMemAlloc
wchar_t* ReturnComAllocatedString(
	const wchar_t* leftString, const wchar_t* rightString)
{
	size_t byteCount
		= (wcslen(leftString) + 
		   wcslen(rightString) + 1) * 2;
    wchar_t* result     
		= (wchar_t*)CoTaskMemAlloc(byteCount);
	StringCbCopyW(result, byteCount, leftString);
	StringCbCatW(result, byteCount, rightString);
    return result;
}

//function for testing of security permissions
int GetStringLength(char* aString)
{
    //function doesn't really do anything
    return (int)strlen(aString);
}

//function used for security wrapper testing
char* ProcessTestFile(const char* fullFilePath)
{
    HANDLE hFile; 
    //open the file for reading 
    hFile = CreateFile(fullFilePath,       // file to open
                    GENERIC_READ,          // open for reading
                    FILE_SHARE_READ,       // share for reading
                    NULL,                  // default security
                    OPEN_EXISTING,         // existing file only
                    FILE_ATTRIBUTE_NORMAL, // normal file
                    NULL);                 // no attr. template
 
    if (hFile == INVALID_HANDLE_VALUE) 
    { 
        printf("Could not open file (error %d)\n", GetLastError());
        return 0;
    }

    BOOL bResult        = false;
    char* buffer        = new char[2049];
    DWORD nBytesToRead  = 2048;
    DWORD nBytesRead    = 0;
    
    //read from the file -- we expect that it will fit within
    //a single buffer
    bResult = ReadFile(hFile, (void*)buffer, nBytesToRead, &nBytesRead, NULL) ;         
    
    buffer[nBytesRead] = '\0';
    //save the file contents as a string
    char* result        = new char[nBytesRead + 1];
    strcpy_s(result, nBytesRead +1, (char*)buffer);
    //free the original buffer
    delete [] buffer;

    //close the file
    CloseHandle(hFile);
    
    return result;
}

//dynamically load a dll and access a function
int __cdecl DynamicallyAddSomeNumbers(int numOne, int numTwo)
{
    return numOne + numTwo;
}
