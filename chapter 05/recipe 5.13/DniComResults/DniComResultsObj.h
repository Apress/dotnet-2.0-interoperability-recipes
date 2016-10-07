// DniComResultsObj.h : Declaration of the CDniComResultsObj

#pragma once
#include "resource.h"       // main symbols

#include "DniComResults.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif



// CDniComResultsObj

class ATL_NO_VTABLE CDniComResultsObj :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CDniComResultsObj, &CLSID_DniComResultsObj>,
	public IDispatchImpl<IDniComResultsObj, &IID_IDniComResultsObj, &LIBID_DniComResultsLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CDniComResultsObj()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_DNICOMRESULTSOBJ)

DECLARE_NOT_AGGREGATABLE(CDniComResultsObj)

BEGIN_COM_MAP(CDniComResultsObj)
	COM_INTERFACE_ENTRY(IDniComResultsObj)
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

	STDMETHOD(ProvideDifferentResults)(long request);
	STDMETHOD(GetTheResult)(long request);
	STDMETHOD(GetTheResultRefactored)(long request, HRESULT* hResult);
};

OBJECT_ENTRY_AUTO(__uuidof(DniComResultsObj), CDniComResultsObj)
