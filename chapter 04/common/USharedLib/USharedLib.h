// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the USHAREDLIB_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// USHAREDLIB_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
//#ifdef USHAREDLIB_EXPORTS
//#define USHAREDLIB_API __declspec(dllexport)
//#else
//#define USHAREDLIB_API __declspec(dllimport)
//#endif

// This class is exported from the USharedLib.dll
class USHAREDLIB_API CUSharedLib {
public:
	CUSharedLib(void);
	// TODO: add your methods here.
};

extern USHAREDLIB_API int nUSharedLib;

USHAREDLIB_API int fnUSharedLib(void);
