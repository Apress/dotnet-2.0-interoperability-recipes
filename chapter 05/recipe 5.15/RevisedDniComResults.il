
//  Microsoft (R) .NET Framework IL Disassembler.  Version 2.0.50215.44
//  Copyright (C) Microsoft Corporation. All rights reserved.



// Metadata version: v2.0.50215
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly Interop.DniComResults
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ImportedFromTypeLibAttribute::.ctor(string) = ( 01 00 10 44 6E 69 43 6F 6D 52 65 73 75 6C 74 73   // ...DniComResults
                                                                                                                 4C 69 62 00 00 )                                  // Lib..
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 38 33 64 38 64 39 32 36 2D 62 33 64 64   // ..$83d8d926-b3dd
                                                                                                  2D 34 62 38 65 2D 38 39 36 34 2D 30 63 34 30 31   // -4b8e-8964-0c401
                                                                                                  35 39 32 37 61 30 37 00 00 )                      // 5927a07..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibVersionAttribute::.ctor(int32,
                                                                                                int32) = ( 01 00 01 00 00 00 00 00 00 00 00 00 ) 
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module DniComResultsLib.dll
// MVID: {8FF90D16-1169-4DEF-BB47-C5A0FEDAEF8E}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x02EB0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi import Interop.DniComResults.DniComResultsObjClass
       extends [mscorlib]System.Object
       implements Interop.DniComResults.IDniComResultsObj,
                  Interop.DniComResults.DniComResultsObj
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(int16) = ( 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 45 45 42 31 36 42 34 44 2D 33 33 38 36   // ..$EEB16B4D-3386
                                                                                                  2D 34 37 42 41 2D 42 35 38 35 2D 44 32 45 30 34   // -47BA-B585-D2E04
                                                                                                  46 33 45 35 30 39 32 00 00 )                      // F3E5092..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(int16) = ( 01 00 02 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor() runtime managed internalcall
  {
  } // end of method DniComResultsObjClass::.ctor

  .method public hidebysig newslot virtual 
          instance void  ProvideDifferentResults([in] int32 'request') runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 01 00 00 00 00 00 ) 
    .override Interop.DniComResults.IDniComResultsObj::ProvideDifferentResults
  } // end of method DniComResultsObjClass::ProvideDifferentResults

  .method public hidebysig newslot virtual 
          instance int32 GetTheResult([in] int32 'request') runtime managed internalcall preservesig
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 02 00 00 00 00 00 ) 
    .override Interop.DniComResults.IDniComResultsObj::GetTheResult
  } // end of method DniComResultsObjClass::GetTheResult

  .method public hidebysig newslot virtual 
          instance void  GetTheResultRefactored([in] int32 'request',
                                                [out] int32&  marshal( error) hResult) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 03 00 00 00 00 00 ) 
    .override Interop.DniComResults.IDniComResultsObj::GetTheResultRefactored
  } // end of method DniComResultsObjClass::GetTheResultRefactored

} // end of class Interop.DniComResults.DniComResultsObjClass

.class interface public abstract auto ansi import Interop.DniComResults.DniComResultsObj
       implements Interop.DniComResults.IDniComResultsObj
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 33 35 38 35 46 37 34 36 2D 30 46 31 30   // ..$3585F746-0F10
                                                                                                  2D 34 34 41 44 2D 42 39 32 33 2D 42 45 41 34 41   // -44AD-B923-BEA4A
                                                                                                  45 37 36 30 39 38 38 00 00 )                      // E760988..
  .custom instance void [mscorlib]System.Runtime.InteropServices.CoClassAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 2B 49 6E 74 65 72 6F 70 2E 44 6E 69 43 6F   // ..+Interop.DniCo
                                                                                                                          6D 52 65 73 75 6C 74 73 2E 44 6E 69 43 6F 6D 52   // mResults.DniComR
                                                                                                                          65 73 75 6C 74 73 4F 62 6A 43 6C 61 73 73 00 00 ) // esultsObjClass..
} // end of class Interop.DniComResults.DniComResultsObj

.class interface public abstract auto ansi import Interop.DniComResults.IDniComResultsObj
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 33 35 38 35 46 37 34 36 2D 30 46 31 30   // ..$3585F746-0F10
                                                                                                  2D 34 34 41 44 2D 42 39 32 33 2D 42 45 41 34 41   // -44AD-B923-BEA4A
                                                                                                  45 37 36 30 39 38 38 00 00 )                      // E760988..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(int16) = ( 01 00 C0 10 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  ProvideDifferentResults([in] int32 'request') runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 01 00 00 00 00 00 ) 
  } // end of method IDniComResultsObj::ProvideDifferentResults

  .method public hidebysig newslot abstract virtual 
          instance int32 GetTheResult([in] int32 'request') runtime managed internalcall preservesig
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 02 00 00 00 00 00 ) 
  } // end of method IDniComResultsObj::GetTheResult

  .method public hidebysig newslot abstract virtual 
          instance void  GetTheResultRefactored([in] int32 'request',
                                                [out] int32&  marshal( error) hResult) runtime managed internalcall
  {
    .custom instance void [mscorlib]System.Runtime.InteropServices.DispIdAttribute::.ctor(int32) = ( 01 00 03 00 00 00 00 00 ) 
  } // end of method IDniComResultsObj::GetTheResultRefactored

} // end of class Interop.DniComResults.IDniComResultsObj


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file DniComResults.res
