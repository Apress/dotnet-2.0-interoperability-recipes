using System;
using System.Runtime.InteropServices;

namespace ArraysStructureTest
{
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    public struct ManagedAcctSummary
    {
        public int      AccountId;
        public string   FirstName;
        public string   LastName;
        public double   CurrentBalance;
    };

	/// <summary>
	/// Passing of string arrays between managed and unmanaged code
	/// </summary>
	class ArraysStructureTest
	{
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern void RetrieveAccountSummaries(
            [In, Out] ManagedAcctSummary[] summaries, int size);
        
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //allocate and populate an array of structs
            ManagedAcctSummary[] summaries = new ManagedAcctSummary[5];
            for(int i = 0; i < summaries.Length; i++)
            {
                summaries[i].AccountId = i + 1001;
            }
            
            //call the unmanaged function to fill the array
            RetrieveAccountSummaries(summaries, summaries.Length);
            
            //show the results
            for(int i = 0; i < summaries.Length; i++)
            {
                Console.WriteLine(
                    "RetrieveAccountSummaries: {0},{1},{2},{3}", 
                    summaries[i].AccountId, summaries[i].CurrentBalance,
                    summaries[i].FirstName, summaries[i].LastName);
            }

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
