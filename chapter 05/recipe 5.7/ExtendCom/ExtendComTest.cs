using System;
using System.Text.RegularExpressions;

using Interop.DniExtendComVB;

namespace ExtendCom
{
	/// <summary>
	/// Define search types
	/// </summary>
	public enum SearchType
	{
		Unknown = 0,
		Name = 1,
		TaxId = 2,
		Address = 3
	}

	/// <summary>
	/// Extend a COM RCW
	/// </summary>
	public class ExtendedComClass : DniExtendComVBObjClass //the RCW
	{
		public decimal AccountBalance(string searchArg, 
			SearchType searchType)
		{
			decimal result = 0;

			//validate the requested search type
			SearchType validSearchType
				= ValidateSearchType(searchType);

			//validate the search argument based on the search type
			ValidateSearchArgument(validSearchType, searchArg);

			try
			{
				//everything passes our tests, so make the COM call
				int acctId = base.AccountLookup(searchArg, 
					(int)validSearchType);
				//check the result
				if (acctId == 0)
				{
					throw new ApplicationException(
						String.Format("Account not found for {0} {1}",
						searchType, searchArg));
				}

				//retrieve the current balance for the account
				result = base.GetCurrentBalance(acctId);
			}
			catch (Exception e)
			{
				throw new ApplicationException(
					"Exception thrown calling COM method", e);
			}

			return result;
		}

		/// <summary>
		/// Validate the search type
		/// </summary>
		/// <param name="searchType"></param>
		/// <returns></returns>
		private SearchType ValidateSearchType(SearchType searchType)
		{
			SearchType validSearchType = SearchType.Unknown;
			if (Enum.IsDefined(typeof(SearchType), searchType))
			{
				validSearchType = searchType;
			}
			else
			{
				throw new ApplicationException(String.Format(
					"Search type of {0} is invalid", searchType));
			}
			return validSearchType;
		}

		/// <summary>
		/// Validate the search argument based on the search type.
		/// Throws an exception if the search argument is invalid.
		/// </summary>
		/// <param name="searchtype"></param>
		/// <param name="searchArg"></param>
		private void ValidateSearchArgument(SearchType searchType,
			string searchArg)
		{
			//define regex strings used for validation
			const string TaxIdRegex
				= @"^(?!000)([0-6]\d{2}|7([0-6]\d|7[012]))"
				 + @"([ -]?)(?!00)\d\d\3(?!0000)\d{4}$";
			const string NameRegex
				= @"^([a-zA-z\s]{4,50})$";
			const string AddressRegex
				= @"^[a-zA-Z\d]+(([\'\,\.\- #][a-zA-Z\d ])"
				 + @"?[a-zA-Z\d]*[\.]*)*$";

			//validate the search argument based on the search type
			switch (searchType)
			{
				case SearchType.Name:
					if (!Regex.IsMatch(searchArg, NameRegex))
					{
						throw new ApplicationException(String.Format(
							"Search argument of {0} is not a valid {1}",
								searchArg, searchType));
					}
					break;
				case SearchType.TaxId:
					if (!Regex.IsMatch(searchArg, TaxIdRegex))
					{
						throw new ApplicationException(String.Format(
							"Search argument of {0} is not a valid {1}",
							searchArg, searchType));
					}
					break;
				case SearchType.Address:
					if (!Regex.IsMatch(searchArg, AddressRegex))
					{
						throw new ApplicationException(String.Format(
							"Search argument of {0} is not a valid {1}",
							searchArg, searchType));
					}
					break;

				default:
					break;
			}
		}
	}

	/// <summary>
	/// Test of an extended COM RCS class
	/// </summary>
	class ExtendComTest
	{
		static void Main(string[] args)
		{
			//create an instance of the extended RCW
			ExtendedComClass comObj = new ExtendedComClass();

			decimal acctBal = 0m;
			acctBal = comObj.AccountBalance(
				"first last", SearchType.Name);
			Console.WriteLine("Balance by Name: {0}", acctBal);
			acctBal = comObj.AccountBalance(
				"123-45-6789", SearchType.TaxId);
			Console.WriteLine("Balance by Tax Id: {0}", acctBal);
			acctBal = comObj.AccountBalance(
				"1 main street", SearchType.Address);
			Console.WriteLine("Balance by Address: {0}", acctBal);

			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read(); 	    
		}
	}
}
