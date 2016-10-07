// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#define WIN32_LEAN_AND_MEAN		// Exclude rarely-used stuff from Windows headers
#include <stdio.h>
#include <tchar.h>

#include <objbase.h>
#include <atlbase.h>

#import "mscorlib.tlb"
#import "DniNetArrays.tlb" no_namespace

// TODO: reference additional headers your program requires here
void DisplayStringArray(SAFEARRAY* pSafeArray);
void DisplayIntArray(SAFEARRAY* pSafeArray);
void UseStringArray(IArraysPtr comObj);
void UseIntArray(IArraysPtr comObj);