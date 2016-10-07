using System;
using System.Runtime.InteropServices;   //needed for DllImport attribute
using System.Text;

namespace CharacterSetTest
{
    class CharacterSetWrapper
    {
        //declare the unmanaged api
        [DllImport("FlatAPILib.DLL")]
        public static extern void CombineStrings(
			string stringA, string stringB, StringBuilder result);
        
        [DllImport("FlatAPILib.DLL")]
        public static extern void CombineAnsiStrings(
			string stringA, string stringB, StringBuilder result);
        
        [DllImport("FlatAPILib.DLL", CharSet=CharSet.Unicode)]
        public static extern void CombineUnicodeStrings(
			string stringA, string stringB, StringBuilder result);
    }
    
    class CharacterSetAnsiWrapper
    {
        //declare the unmanaged api
        [DllImport("FlatAPILib.DLL", CharSet=CharSet.Ansi,
		   CallingConvention = CallingConvention.Cdecl)]
        public static extern void CombineStrings(string stringA, string stringB, StringBuilder result);
    }

    class CharacterSetUnicodeWrapper
    {
        //declare the unmanaged api
        [DllImport("FlatAPILib.DLL", CharSet=CharSet.Unicode,
		   CallingConvention = CallingConvention.Cdecl)]
        public static extern void CombineStrings(string stringA, string stringB, StringBuilder result);
    }

	/// <summary>
	/// sample c# client changing characterset for string marshaling
	/// </summary>
	class CharacterSetTest
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    StringBuilder result           = new StringBuilder(300);
		    
            CharacterSetWrapper.CombineStrings("part1", "part2", result);
            Console.WriteLine("Result from CombineStrings function Default = " + result.ToString());
		    
       	    CharacterSetAnsiWrapper.CombineStrings("part1", "part2", result);
       	    Console.WriteLine("Result from CombineStrings function ANSI = " + result.ToString());

            CharacterSetUnicodeWrapper.CombineStrings("part1", "part2", result);
            Console.WriteLine("Result from CombineStrings function Unicode = " + result.ToString());

            CharacterSetWrapper.CombineAnsiStrings("part1", "part2", result);
            Console.WriteLine("Result from CombineAnsiStrings function = " + result.ToString());
       	    
            CharacterSetWrapper.CombineUnicodeStrings("part1", "part2", result);
            Console.WriteLine("Result from CombineUnicodeStrings function = " + result.ToString());

       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
