// DniThreadingStaObj.h : Declaration of the CDniThreadingStaObj

#pragma once
#include "resource.h"       // main symbols

#include "DniThreading.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif



// CDniThreadingStaObj

class ATL_NO_VTABLE CDniThreadingStaObj :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CDniThreadingStaObj, &CLSID_DniThreadingStaObj>,
	public IDispatchImpl<IDniThreadingStaObj, &IID_IDniThreadingStaObj, &LIBID_DniThreadingLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CDniThreadingStaObj()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_DNITHREADINGSTAOBJ)

DECLARE_NOT_AGGREGATABLE(CDniThreadingStaObj)

BEGIN_COM_MAP(CDniThreadingStaObj)
	COM_INTERFACE_ENTRY(IDniThreadingStaObj)
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
	STDMETHOD(AddNumbers)(long numA, long numB, long* result);


};

OBJECT_ENTRY_AUTO(__uuidof(DniThreadingStaObj), CDniThreadingStaObj)
