// DniSimpleComObj.h : Declaration of the CDniSimpleComObj

#pragma once
#include "resource.h"       // main symbols

#include "DniSimpleCom.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif



// CDniSimpleComObj

class ATL_NO_VTABLE CDniSimpleComObj :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CDniSimpleComObj, &CLSID_DniSimpleComObj>,
	public IDispatchImpl<IDniSimpleComObj, &IID_IDniSimpleComObj, &LIBID_DniSimpleComLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CDniSimpleComObj()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_DNISIMPLECOMOBJ)


BEGIN_COM_MAP(CDniSimpleComObj)
	COM_INTERFACE_ENTRY(IDniSimpleComObj)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:

	STDMETHOD(AddSomeNumbers)(int numA, int numB, int* result);
};

OBJECT_ENTRY_AUTO(__uuidof(DniSimpleComObj), CDniSimpleComObj)
