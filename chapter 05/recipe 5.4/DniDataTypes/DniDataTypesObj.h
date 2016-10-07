// DniDataTypesObj.h : Declaration of the CDniDataTypesObj

#pragma once
#include "resource.h"       // main symbols

#include "DniDataTypes.h"


#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Single-threaded COM objects are not properly supported on Windows CE platform, such as the Windows Mobile platforms that do not include full DCOM support. Define _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA to force ATL to support creating single-thread COM object's and allow use of it's single-threaded COM object implementations. The threading model in your rgs file was set to 'Free' as that is the only threading model supported in non DCOM Windows CE platforms."
#endif



// CDniDataTypesObj

class ATL_NO_VTABLE CDniDataTypesObj :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CDniDataTypesObj, &CLSID_DniDataTypesObj>,
	public IDispatchImpl<IDniDataTypesObj, &IID_IDniDataTypesObj, &LIBID_DniDataTypesLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	CDniDataTypesObj()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_DNIDATATYPESOBJ)


BEGIN_COM_MAP(CDniDataTypesObj)
	COM_INTERFACE_ENTRY(IDniDataTypesObj)
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

	STDMETHOD(UseBool)(boolean inParam, boolean* outParam);
	STDMETHOD(UseVariantBool)(VARIANT_BOOL inParam, VARIANT_BOOL* outParam);
	STDMETHOD(UseLong)(long inParam, long* outParam);
	STDMETHOD(UseDouble)(double inParam, double* outParam);
	STDMETHOD(UseBSTR)(BSTR inParam, BSTR* outParam);
	STDMETHOD(UseDecimal)(DECIMAL inParam, DECIMAL* outParam);
	STDMETHOD(UseDate)(DATE inParam, DATE* outParam);
	STDMETHOD(UseCurrency)(CURRENCY inParam, CURRENCY* outParam);
	STDMETHOD(UseChar)(unsigned char inParam, unsigned char* outParam);
	STDMETHOD(UseLPSTR)(LPSTR inParam, LPSTR* outParam);
	STDMETHOD(UseComCHAR)(CHAR inParam, CHAR* outParam);
	STDMETHOD(UseVariant)(VARIANT inParam, VARIANT* outParam, BSTR* variantDesc);
	STDMETHOD(UseArray)(SAFEARRAY * inParam, BSTR* outParam);
	STDMETHOD(UpdateArray)(SAFEARRAY* inParam);
	STDMETHOD(UseCStyleArray)(long inParam[], long arraySize, BSTR* outParam);
};

OBJECT_ENTRY_AUTO(__uuidof(DniDataTypesObj), CDniDataTypesObj)
