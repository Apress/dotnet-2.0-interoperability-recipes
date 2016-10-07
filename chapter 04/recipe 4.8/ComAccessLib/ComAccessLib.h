// ComAccessLib.h

#pragma once

//create a _com_ptr_t smart pointer for the com component
#import "DniComFromCpp.tlb" no_namespace

using namespace System;
using namespace System::Runtime::InteropServices;

namespace ComAccessLib
{
	//implement a managed wrapper for the com component
	public ref class CppComWrapper
	{
	public:
		String^ ProcessString(String^ value)
		{
			String^ result	= String::Empty;
			//create an instance of the COM object
			IDniComFromCppObjPtr comObj(
				__uuidof(DniComFromCppObj));
			if (!comObj)
			{
				return L"Unable to create COM instance";
			}

			//marshal the System::String to a BSTR
			IntPtr pBSTR = Marshal::StringToBSTR(value);
			BSTR inBSTR 
				= static_cast<BSTR>(pBSTR.ToPointer());
			//make the COM method call
			_bstr_t pResultBSTR 
				= comObj->ModifyString(inBSTR);
			//cleanup
			Marshal::FreeBSTR(pBSTR);
			result 
				= gcnew System::String((wchar_t*)pResultBSTR);
			return result;
		}
	};
}
