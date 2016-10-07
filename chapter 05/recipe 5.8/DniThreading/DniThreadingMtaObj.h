// DniThreadingMtaObj.h : Declaration of the CDniThreadingMtaObj

#pragma once
#include "resource.h"       // main symbols

#include "DniThreading.h"




// CDniThreadingMtaObj

class ATL_NO_VTABLE CDniThreadingMtaObj :
	public CComObjectRootEx<CComMultiThreadModel>,
	public CComCoClass<CDniThreadingMtaObj, &CLSID_DniThreadingMtaObj>,
	public IDispatchImpl<IDniThreadingMtaObj, &IID_IDniThreadingMtaObj, &LIBID_DniThreadingLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CDniThreadingMtaObj()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_DNITHREADINGMTAOBJ)

DECLARE_NOT_AGGREGATABLE(CDniThreadingMtaObj)

BEGIN_COM_MAP(CDniThreadingMtaObj)
	COM_INTERFACE_ENTRY(IDniThreadingMtaObj)
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

OBJECT_ENTRY_AUTO(__uuidof(DniThreadingMtaObj), CDniThreadingMtaObj)
