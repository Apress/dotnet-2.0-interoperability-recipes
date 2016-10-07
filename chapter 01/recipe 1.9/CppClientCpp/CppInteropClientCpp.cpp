//
//use the C++ wrapper object from C++
//
#include "stdafx.h"
using namespace System;
using namespace CppInteropWrappers;

int _tmain()
{
    int result              = 0;
    String^ resultString    = String::Empty;

    //create the C++ wrapper object
	CppInteropTest^ testObj 
		= gcnew CppInteropTest();

    //test numbers function using PInvoke        
    result = testObj->PInvokeAddNumbersTest();
    Console::WriteLine(
		"Result from PInvokeAddNumbersTest = {0}",result);

	//test numbers function using C++ Interop
    result = testObj->CppInteropAddNumbersTest();
    Console::WriteLine(
		"Result from CppInteropAddNumbersTest = {0}", result);

    //test string function using PInvoke
    resultString = testObj->PInvokeStringsTest();
    Console::WriteLine(
		"Result from PInvokeStringsTest = {0}", 
		resultString);
    
    //test string function using C++ Interop
    resultString = testObj->CppInteropStringsTest();
    Console::WriteLine(
		"Result from CppInteropStringsTest = {0}", 
		resultString);

    //wait for input
    Console::WriteLine("Press any key to exit");      
    Console::Read(); 	    
    
	return 0;
}

