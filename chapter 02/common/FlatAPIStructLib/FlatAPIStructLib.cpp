#include "stdafx.h"
#include "FlatAPIStructLib.h"
#include "objbase.h"    //CoTaskMemAlloc
#include <stdio.h>      //sprintf

//
//struct and class testing
//

//function for structure passing
void ProcessStruct1(UnmanagedStruct1* aStruct)
{
	if (aStruct != NULL)
	{
		aStruct->UmCount    = 1;
		aStruct->UmDelta    = 2;
		aStruct->UmPercent  = 1.4567;   
	}
}

//uses struct aligned on 1 byte packing boundary
void ProcessStruct2(UnmanagedStruct2* aStruct)
{
	if (aStruct != NULL)
	{
		aStruct->UmCount    = 1;
		aStruct->UmDelta    = 2;
		aStruct->UmPercent  = 1.4567;   
	}
}

//returns a struct rather than receiving one
ReturnedUnmanagedStruct* ReturnAStruct(void)
{
    //allocate the struct using C++ new keyword
    ReturnedUnmanagedStruct* pResult = new ReturnedUnmanagedStruct();
    pResult->Hours          = 1;
    pResult->Minutes        = 59;
    pResult->Seconds        = 11;
	return pResult;
}

void FreeAStruct(ReturnedUnmanagedStruct* pStruct)
{
    if (pStruct != NULL)
    {
        delete pStruct;
    }
}

//uses CoTaskMemAlloc to allocate memory rather than new
ReturnedUnmanagedStruct* ReturnCoMemStruct(void)
{
    //allocate the struct using CoTaskMemAlloc
    ReturnedUnmanagedStruct* pResult 
        = (ReturnedUnmanagedStruct*)CoTaskMemAlloc(sizeof(ReturnedUnmanagedStruct));
    pResult->Hours          = 1;
    pResult->Minutes        = 59;
    pResult->Seconds        = 11;
	return pResult;
}

//testing of a partial structure from managed code
void RetrieveAccountBalances(int accountId, UnmanagedAccountStruct* pAccount)
{
    //return selected account fields
	if (pAccount != NULL)
	{
	    pAccount->AccountId         = accountId;
	    pAccount->AccountType       = sizeof(char*);
	    pAccount->CurrentBalance    = 500.00;
	    pAccount->PastDueBalance    = 350.00;
	    pAccount->LastPurchaseAmt   = 10.95;
	}
}

//testing of a partial structure from managed code 
//that uses the Size field
double RevisePurchaseAmt(UnmanagedAccountStruct* pAccount, 
	double purchaseAmt)
{
	double lastPurchaseAmt;
    //revise the LastPurchaseAmt
	if (pAccount != NULL)
	{
		//save the LastPurchaseAmt
		lastPurchaseAmt = pAccount->LastPurchaseAmt;
		//update with the new amount
		pAccount->LastPurchaseAmt = purchaseAmt;
	}
	return lastPurchaseAmt;
}

//tests marshalas attribute on passed struct
int UseAmbiguousStruct(UnmanagedAmbiguousStruct aStruct)
{
    int result = 0;
    result += (int)strlen(aStruct.AnsiString);
    result += (int)wcslen(aStruct.WideString);
    if (aStruct.CStyleBoolean)
    {
        result++;
    }
    if (aStruct.Win32Boolean)
    {
        result++;
    }
    result += aStruct.ShortInteger;
    
    return result;
}

//unmanaged strings in struct
//tests allocation of strings within unmanaged code
void RetrieveAccountProfile(int accountId, UnmanagedAccountStruct* pAccount)
{
    //return selected account fields
	if (pAccount != NULL)
	{
		//allocate memory needed for strings
		pAccount->AccountName		= (char*)CoTaskMemAlloc(255);
		pAccount->Address1			= (char*)CoTaskMemAlloc(255);
		pAccount->Address2			= (char*)CoTaskMemAlloc(255);
		pAccount->City				= (char*)CoTaskMemAlloc(255);
		pAccount->State				= (char*)CoTaskMemAlloc(255);

		//populate fields with data
		pAccount->AccountId         = accountId;
		strcpy_s(pAccount->AccountName, 255, "Account Name");
		strcpy_s(pAccount->Address1, 255, "Address line 1");
		strcpy_s(pAccount->Address2, 255, "Address line 2");
		strcpy_s(pAccount->City, 255, "City name");
		strcpy_s(pAccount->State, 255, "Full state name");
		pAccount->PostalCode		= 12345;
	}
}

//class passing examples
bool LookupItemDetail(UnmanagedItemStruct* itemStruct)
{
    if (itemStruct == NULL)
    {
        return false;
    }
    
    //lookup item and fill the struct
    itemStruct->CategoryCode    = 10012002;
    itemStruct->TaxCategoryId   = 9988;
    itemStruct->UnitPrice       = 5.49;
    itemStruct->ItemDesc        = (char*)CoTaskMemAlloc(255);
    strcpy_s(itemStruct->ItemDesc, 255, "item description");
    return true;
}

//class passing by ref
bool LookupItemDetailByRef(UnmanagedItemStruct** ppItemStruct)
{
    if (ppItemStruct == NULL)
    {
        return false;
    }
    
    //lookup item and fill the struct
    (*ppItemStruct)->CategoryCode    = 10012002;
    (*ppItemStruct)->TaxCategoryId   = 9988;
    (*ppItemStruct)->UnitPrice       = 5.49;
    (*ppItemStruct)->ItemDesc        = (char*)CoTaskMemAlloc(255);
    strcpy_s((*ppItemStruct)->ItemDesc, 255, "item description");
    return true;
}

//class passing examples
bool LookupItemDetailCPPRef(UnmanagedItemStruct& itemStruct)
{
    //lookup item and fill the struct
    itemStruct.CategoryCode    = 10012002;
    itemStruct.TaxCategoryId   = 9988;
    itemStruct.UnitPrice       = 5.49;
    itemStruct.ItemDesc        = (char*)CoTaskMemAlloc(255);
    strcpy_s(itemStruct.ItemDesc, 255, "item description");
    return true;
}

bool LookupItemDetailBlit(UnmanagedItemStructBlit* itemStruct)
{
    if (itemStruct == NULL)
    {
        return false;
    }
    
    //lookup item and fill the struct
    itemStruct->CategoryCode    = 10012002;
    itemStruct->TaxCategoryId   = 9988;
    itemStruct->UnitPrice       = 5.49;
    return true;
}

//uses an unmanaged class rather than a struct
bool LookupItemDetailClass(UnmanagedItemClass* item)
{
    if (item == NULL)
    {
        return false;
    }
    
    //lookup item and fill the struct
    item->CategoryCode    = 10012002;
    item->TaxCategoryId   = 9988;
    item->UnitPrice       = 5.49;
    item->ItemDesc        = (char*)CoTaskMemAlloc(255);
    strcpy_s(item->ItemDesc, 255, "item description");
    return true;
}

//array testing
//read-only function - blittable type
int SumOfArrayElements(int pArray[], int arraySize)
{
	int result = 0;
	for(int i = 0; i < arraySize; i++)
	{
		result += pArray[i];
	}
	return result;
}

//update function - blittable type
int UpdateIntArrayElements(int pArray[], int arraySize)
{
	int result = 0;
	for(int i = 0; i < arraySize; i++)
	{
	    //modify the original element
	    pArray[i] += pArray[i];
		result += pArray[i];
	}
	return result;
}

//read-only function - non-blittable type
int CountLowerCaseChars(char charArray[], int arraySize)
{
	int result = 0;
	for(int i = 0; i < arraySize; i++)
	{
	    if (islower(charArray[i]))
	    {
		    result++;
		}
	}
	return result;
}

//update function - non-blittable type
int ChangeLowerCaseChars(char charArray[], int arraySize)
{
	int result = 0;
	for(int i = 0; i < arraySize; i++)
	{
	    if (islower(charArray[i]))
	    {
	        //change the char to upper case
	        charArray[i] = toupper(charArray[i]);
		    result++;
		}
	}
	return result;
}

//string arrays - update array elements in place
void StringArrayToUpper(char* strings[], int size)
{
    //change all string elements to all upper-case
	for(int i = 0; i < size; i++)
	{
        //convert the string to uppercase
        int stringLen = (int)strlen(strings[i]);
		//save the pointer to the original string
        char* oldString = strings[i];

        //allocate new memory for the string
        strings[i] = (char*)CoTaskMemAlloc(stringLen + 1);

		//convert to upper case while we copy into
		//the new string
        for(int j = 0; j < stringLen; j++)
        {
            strings[i][j] = toupper(oldString[j]);
        }    
        strings[i][stringLen] = '\0';
        
        //free the original string memory
        CoTaskMemFree(oldString);
	}
}

//string arrays - fill array of buffers passed in
void FillStringArray(char* strings[], int size, int maxStringSize)
{
    //update array elements with strings.
    //no need to allocate new memory since we
    //have been passed allocated buffers

    char* resultStrings[] = {"One","Two","Three","Four"};

	for(int i = 0; i < size; i++)
	{
	    if ((int)strlen(resultStrings[i]) < maxStringSize)
	    {
	        strcpy_s(strings[i], maxStringSize, 
				resultStrings[i]);
	    }
	}
}

//allocate an array entirely in unmanaged code and return it
int AllocateAndReturnStringArray(void** strArray)
{
	int const elementCount = 7;
	int bytesToAllocate   = sizeof(char*) * elementCount;

	//allocate memory for the array		
	char** pTempArray = (char**)CoTaskMemAlloc(bytesToAllocate);
    //fill each element of the new array
	for(int i = 0; i < elementCount; i++)
	{
		//allocate memory for the array element
		pTempArray[i] = (char*)CoTaskMemAlloc(255);
		//populate the element
		sprintf_s(pTempArray[i], 255, "element value %i", i);
	}
    //pass the new array back as the result
	*strArray = pTempArray;
    
	return elementCount;
}

void RetrieveAccountSummaries(UnmanagedAcctSummary summaries[], int size)
{
	for(int i = 0; i < size; i++)
	{
	    //populate fields in the summary structure
	    int acctId = summaries[i].AccountId;
	    int stringSize = 255 * sizeof(wchar_t);
	    summaries[i].FirstName = (wchar_t*)CoTaskMemAlloc(stringSize);
	    summaries[i].LastName  = (wchar_t*)CoTaskMemAlloc(stringSize);
        swprintf_s(summaries[i].FirstName, 255, 
			L"First%i", acctId);
        swprintf_s(summaries[i].LastName, 255, 
			L"Last%i", acctId);
        summaries[i].CurrentBalance = acctId * 3.14;
	}
}

