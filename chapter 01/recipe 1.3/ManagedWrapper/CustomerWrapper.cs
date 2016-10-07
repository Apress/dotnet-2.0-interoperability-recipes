using System;
using System.Runtime.InteropServices;

namespace CustomerWrapperTest
{
    /// <summary>
    /// Defines customer status values returned
    /// returned from the unmanaged function
    /// </summary>
    enum CustomerStatus
    {
        Unknown         = 0,
        Current         = 1,
        Inactive        = 2,
        PastDue         = 3,
        InCollections   = 4
    }

    /// <summary>
    /// Defines the type of customer and is used
    /// by the unmanaged function to determine
    /// the database to search
    /// </summary>
    enum CustomerType
    {
        Individual      = 1001,
        Corporate       = 2122,
        Government      = 35,
        NonProfit       = 501
    }

	/// <summary>
	/// Internal class containing any unmanaged
	/// method declarations
	/// </summary>
	internal sealed class NativeMethods
	{
		//declare the unmanaged api
		[DllImport("FlatAPILib.DLL")]
		public static extern int GetCustomerStatus(
			String customerId, int customerType);
	}

	/// <summary>
	/// A managed wrapper for unmanaged customer functions
	/// </summary>
	class CustomerWrapper
	{
	    /// <summary>
	    /// Returns customer status
	    /// </summary>
	    /// <param name="custType"></param>
	    /// <param name="custId"></param>
	    /// <returns></returns>
	    public CustomerStatus GetCustomerStatus(
			CustomerType custType, String custId)
	    {
	        //convert enum values to those expected
	        //by the unmanaged function. This eliminates
	        //the need to pass magic numbers from 
	        //managed code. we can validate the enum 
	        //prior to calling the function.
	        int customerTypeInt     = 0;
	        if (Enum.IsDefined(typeof(CustomerType), custType))
	        {
	            customerTypeInt = (int)custType;
	        }
	        else
	        {
	            throw new ArgumentOutOfRangeException(
	                String.Format("Invalid CustomerType {0}", custType));
	        }
	        
	        //make the function call
	        int result = NativeMethods.GetCustomerStatus(
				custId, customerTypeInt);
	        
	        //we convert the integer result to our enum
	        //to make the result clearer to other managed code
	        if (Enum.IsDefined(typeof(CustomerStatus), result))
	        {
	            return (CustomerStatus)result;
	        }
	        else
	        {
	            return CustomerStatus.Unknown;
	        }
	    }
	}
}
