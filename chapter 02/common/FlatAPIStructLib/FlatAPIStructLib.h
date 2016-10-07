//referencing and using an unmanaged function

// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the FLATAPILIB_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// FLATAPILIB_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
//#ifdef FLATAPILIB_EXPORTS
//#define FLATAPILIB_API extern "C" __declspec(dllexport)
//#else
//#define FLATAPILIB_API extern "C" __declspec(dllimport)
//#endif

//
//Struct testing 
//
//struct aligned on default 8 byte boundary
struct UnmanagedStruct1
{
	int    UmCount;
	char   UmTypeIndicator;
	int    UmDelta;
	double UmPercent;
};

#pragma pack(1)
//struct aligned on 1 byte boundary
struct UnmanagedStruct2
{
	int    UmCount;
	char   UmTypeIndicator;
	int    UmDelta;
	double UmPercent;
};
#pragma pack() //reset pack size to default

struct ReturnedUnmanagedStruct
{
	int    Hours;
	int    Minutes;
	int    Seconds;
};

#pragma pack(1)
//structure for account info retrieve
struct UnmanagedAccountStruct
{
    int    AccountId;           //4 bytes
    int    AccountStatus;       //4 bytes
    short  AccountAgingMethod;  //2 bytes
    short  AccountType;         //2 bytes
    int    RegionId;            //4 bytes
    double CurrentBalance;      //8 bytes
    double PastDueBalance;      //8 bytes
    int    SalesRepId;          //4 bytes
    char*  AccountName;         //4 bytes
    char*  Address1;            //4 bytes
    char*  Address2;            //4 bytes
    char*  City;                //4 bytes
    char*  State;               //4 bytes
    int    PostalCode;          //4 bytes
    double LastPurchaseAmt;     //8 bytes
};
#pragma pack() //reset pack size to default

//struct with multiple string types
struct UnmanagedAmbiguousStruct
{
    char*    AnsiString;
    wchar_t* WideString;
	BOOL     Win32Boolean;      //4 bytes      
	bool     CStyleBoolean;     //1 byte
	unsigned short ShortInteger;
};

//class testing
struct UnmanagedItemStruct
{
    int    ItemId;
    char*  ItemDesc;
    long   CategoryCode;
    double UnitPrice;
    int    TaxCategoryId;
};

//blittable struct for class passing
struct UnmanagedItemStructBlit
{
    int    ItemId;
    int    TaxCategoryId;
    double UnitPrice;    
    long   CategoryCode;
};

class UnmanagedItemClass
{
public:
    UnmanagedItemClass(void);
    ~UnmanagedItemClass(void);
    int    ItemId;
    char*  ItemDesc;
    long   CategoryCode;
    double UnitPrice;
    int    TaxCategoryId;
};

//struct used for array of struct testing
struct UnmanagedAcctSummary
{
    int      AccountId;
    wchar_t* FirstName;
    wchar_t* LastName;
    double   CurrentBalance;
};

extern "C" __declspec(dllexport) void ProcessStruct1(UnmanagedStruct1* aStruct);
extern "C" __declspec(dllexport) void ProcessStruct2(UnmanagedStruct2* aStruct);
extern "C" __declspec(dllexport) ReturnedUnmanagedStruct* ReturnAStruct(void);
extern "C" __declspec(dllexport) void FreeAStruct(ReturnedUnmanagedStruct* pStruct);
extern "C" __declspec(dllexport) ReturnedUnmanagedStruct* ReturnCoMemStruct(void);
extern "C" __declspec(dllexport) void RetrieveAccountBalances(int accountId, UnmanagedAccountStruct* pAccount);
extern "C" __declspec(dllexport) double RevisePurchaseAmt(UnmanagedAccountStruct* pAccount, double purchaseAmt);
extern "C" __declspec(dllexport) int  UseAmbiguousStruct(UnmanagedAmbiguousStruct aStruct);
extern "C" __declspec(dllexport) void RetrieveAccountProfile(int accountId, UnmanagedAccountStruct* pAccount);
extern "C" __declspec(dllexport) bool LookupItemDetail(UnmanagedItemStruct* itemStruct);
extern "C" __declspec(dllexport) bool LookupItemDetailByRef(UnmanagedItemStruct** ppItemStruct);
extern "C" __declspec(dllexport) bool LookupItemDetailCPPRef(UnmanagedItemStruct& itemStruct);
extern "C" __declspec(dllexport) bool LookupItemDetailBlit(UnmanagedItemStructBlit* itemStruct);
extern "C" __declspec(dllexport) bool LookupItemDetailClass(UnmanagedItemClass* item);
extern "C" __declspec(dllexport) int SumOfArrayElements(int pArray[], int arraySize);
extern "C" __declspec(dllexport) int UpdateIntArrayElements(int pArray[], int arraySize);
extern "C" __declspec(dllexport) int CountLowerCaseChars(char charArray[], int arraySize);
extern "C" __declspec(dllexport) int ChangeLowerCaseChars(char charArray[], int arraySize);
extern "C" __declspec(dllexport) void StringArrayToUpper(char* strings[], int size);
extern "C" __declspec(dllexport) void FillStringArray(char* strings[], int size, int maxStringSize);
extern "C" __declspec(dllexport) int AllocateAndReturnStringArray(void** array);
extern "C" __declspec(dllexport) void RetrieveAccountSummaries(UnmanagedAcctSummary summaries[], int size);
