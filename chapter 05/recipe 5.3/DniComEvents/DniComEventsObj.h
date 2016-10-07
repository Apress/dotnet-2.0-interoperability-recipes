// DniComEventsObj.h : Declaration of the CDniComEventsObj

#pragma once
#include "resource.h"       // main symbols

#include "DniComEvents.h"
#include "_IDniComEventsObjEvents_CP.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif



// CDniComEventsObj

class ATL_NO_VTABLE CDniComEventsObj :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CDniComEventsObj, &CLSID_DniComEventsObj>,
	public IConnectionPointContainerImpl<CDniComEventsObj>,
	public CProxy_IDniComEventsObjEvents<CDniComEventsObj>,
	public IDispatchImpl<IDniComEventsObj, &IID_IDniComEventsObj, &LIBID_DniComEventsLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CDniComEventsObj()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_DNICOMEVENTSOBJ)


BEGIN_COM_MAP(CDniComEventsObj)
	COM_INTERFACE_ENTRY(IDniComEventsObj)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(CDniComEventsObj)
	CONNECTION_POINT_ENTRY(__uuidof(_IDniComEventsObjEvents))
END_CONNECTION_POINT_MAP()


	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:

	STDMETHOD(ChangeDesc)(BSTR newDesc);

private:
	CComBSTR m_LastDesc;
};

OBJECT_ENTRY_AUTO(__uuidof(DniComEventsObj), CDniComEventsObj)
