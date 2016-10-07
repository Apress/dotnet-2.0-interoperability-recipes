#include "StdAfx.h"
#include ".\CppInteropTest.h"
#include "..\..\common\FlatAPILib\FlatAPILib.h"

namespace CppInteropWrappers
{

// execute AddSomeNumbers via PInvoke
int CppInteropTest::PInvokeAddNumbersTest(void)
{
    //call the unmanaged function using PInvoke
    return PInvokeAddSomeNumbers(100, 200);
}

// execute AddSomeNumbers via C++ Interop
int CppInteropTest::CppInteropAddNumbersTest(void)
{
    //call the unmanaged function using C++ Interop
    return AddSomeNumbers(100, 200);
}

//string test using standard PInvoke
String^ CppInteropTest::PInvokeStringsTest()
{
    //create a StringBuilder as an in/out buffer
    StringBuilder^ buf  = gcnew StringBuilder(500);
    //call the function using PInvoke
    PInvokeCombineStrings(
		L"StringOne", L"StringTwo", buf);
    return buf->ToString();
}

//string test using C++ Interop
String^ CppInteropTest::CppInteropStringsTest()
{
    //allocate an unmanaged buffer
    wchar_t* buf = new wchar_t[500];
    //call the unmanaged function using C++ Interop
    CombineStringsW(L"StringOne", L"StringTwo", buf);
    //turn the result into a managed System::String
    String^ result = gcnew String(buf);
    //free the unmanaged buffer
    delete [] buf;
    return result;
}

}
