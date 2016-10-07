// PassStrings.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <conio.h>
#include "StringUtility.h"
#include <vcclr.h>

using namespace System::Runtime::InteropServices;	//for the marshal class

using namespace System;
using namespace MixedSharedLib;

public ref class ManagedStrings
{
public:
	void ChangeTheString()
	{
		//get internal pointer to managed string
		pin_ptr<const wchar_t> pStr 
			= PtrToStringChars(m_Target);
		//pass the pointer to the unmanaged method
		wchar_t* pNewStr 
			= CStringUtility::ProcessString(pStr);
		//update the managed string with the result
		m_Target = gcnew String(pNewStr);
		//free the pointer to the new string
		delete [] pNewStr;
	}

	void ChangeTheStringAnsi()
	{
		//marshal the managed string to unmanaged Ansi 
		IntPtr pStrPtr 
			= Marshal::StringToHGlobalAnsi(m_Target);
		const char* pStr 
			= static_cast<char*>(pStrPtr.ToPointer());
		//pass the pointer to the unmanaged method
		char* pNewStr 
			= CStringUtility::ProcessString(pStr);
		//update the managed string with the result
		m_Target = gcnew String(pNewStr);
		//free the pointer to the new string
		delete [] pNewStr;
		//free our original marshaled string
		Marshal::FreeHGlobal(pStrPtr);
	}

	property String^ Target
	{
		String^ get() {return m_Target;}
		void set(String^ value) {m_Target = value;}
	}

private:
	String^ m_Target;	
};


int _tmain(int argc, _TCHAR* argv[])
{
	ManagedStrings^ obj = gcnew ManagedStrings();
	obj->Target = "abcdef";
	Console::WriteLine("String prior to call: {0}",
		obj->Target);

	obj->ChangeTheString();

	Console::WriteLine("String after call: {0}",
		obj->Target);

	//test an ansi string

	obj = gcnew ManagedStrings();
	obj->Target = "abcdef";
	Console::WriteLine("String prior to call: {0}",
		obj->Target);

	obj->ChangeTheStringAnsi();

	Console::WriteLine("String after Ansi call: {0}",
		obj->Target);


	_getch();

	return 0;
}

