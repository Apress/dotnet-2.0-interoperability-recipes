// hold_object_reference.cpp
// compile with: /clr
#include "gcroot.h"
using namespace System;

#pragma managed 
class StringWrapper {

private:
   gcroot<String ^ > x;

public:
   StringWrapper() {
      String ^ str = gcnew String("ManagedString");
      x = str;
   }

   void PrintString() {
      String ^ targetStr = x;
      Console::WriteLine("StringWrapper::x == {0}", targetStr);
   }

   double getX(int y)
   {
	   return 1;
   }
	
   System::Boolean getB()
   {
	   return true;
   }

   DateTime getD()
   {
	   return DateTime::Now;
   }

};
#pragma unmanaged
int mymain() {
   StringWrapper s;
   s.PrintString();
   double x = s.getX(2);
   bool b = s.getB();
   //s.getD();
   return 0;
}

#pragma managed