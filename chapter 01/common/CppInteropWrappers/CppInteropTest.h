#pragma once

using namespace System;
using namespace System::Text;
using namespace System::Runtime::InteropServices;

namespace CppInteropWrappers
{
//declare unmanaged functions for PInvoke usage
[DllImport("FlatAPILib.DLL", 
	CharSet=CharSet::Unicode, EntryPoint="CombineStringsW")]
extern void PInvokeCombineStrings(
	String^ stringA, String^ stringB, StringBuilder^ result);

[DllImport("FlatAPILib.DLL", EntryPoint="AddSomeNumbers")]
extern int PInvokeAddSomeNumbers(int numberA, int numberB);

//C++ wrapper for unmanaged function tests
public ref class CppInteropTest
{
public:
    int PInvokeAddNumbersTest(void);
    int CppInteropAddNumbersTest(void);
    String^ PInvokeStringsTest(void);
    String^ CppInteropStringsTest(void);
};

}
