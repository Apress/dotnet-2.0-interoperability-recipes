// DniComFromCppObj.h : Declaration of the CDniComFromCppObj

#pragma once
#include "resource.h"       // main symbols

#include "DniComFromCpp.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif



// CDniComFromCppObj

class ATL_NO_VTABLE CDniComFromCppObj :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CDniComFromCppObj, &CLSID_DniComFromCppObj>,
	public IDispatchImpl<IDniComFromCppObj, &IID_IDniComFromCppObj, &LIBID_DniComFromCppLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CDniComFromCppObj()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_DNICOMFROMCPPOBJ)

DECLARE_NOT_AGGREGATABLE(CDniComFromCppObj)

BEGIN_COM_MAP(CDniComFromCppObj)
	COM_INTERFACE_ENTRY(IDniComFromCppObj)
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

	STDMETHOD(ModifyString)(BSTR inParam, BSTR* outParam);
};

OBJECT_ENTRY_AUTO(__uuidof(DniComFromCppObj), CDniComFromCppObj)
