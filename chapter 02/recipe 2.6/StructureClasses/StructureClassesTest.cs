using System;
using System.Runtime.InteropServices;

namespace StructureClassesTest
{
    [StructLayout(LayoutKind.Sequential)]
    public class ManagedItem
    {
        private int    m_ItemId;
        private string m_ItemDesc;
        private long   m_CategoryCode;
        private double m_UnitPrice;
        private int    m_TaxCategoryId;

        public ManagedItem()
        {
            m_ItemDesc = String.Empty;
        }

        public int ItemId
        {
            get{return m_ItemId;}
            set{m_ItemId = value;}
        }
        public string ItemDesc
        {
            get{return m_ItemDesc;}
            set{m_ItemDesc = value;}
        }
        public long CategoryCode
        {
            get{return m_CategoryCode;}
            set{m_CategoryCode = value;}
        }
        public double UnitPrice
        {
            get{return m_UnitPrice;}
            set{m_UnitPrice = value;}
        }
        public int TaxCategoryId
        {
            get{return m_TaxCategoryId;}
            set{m_TaxCategoryId = value;}
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class ManagedItemBlit
    {
        private int    m_ItemId;
        private int    m_TaxCategoryId;
        private double m_UnitPrice;        
        private long   m_CategoryCode;

        public ManagedItemBlit()
        {
        }

        public int ItemId
        {
            get{return m_ItemId;}
            set{m_ItemId = value;}
        }
        public long CategoryCode
        {
            get{return m_CategoryCode;}
            set{m_CategoryCode = value;}
        }
        public double UnitPrice
        {
            get{return m_UnitPrice;}
            set{m_UnitPrice = value;}
        }
        public int TaxCategoryId
        {
            get{return m_TaxCategoryId;}
            set{m_TaxCategoryId = value;}
        }
    }
    
	/// <summary>
	/// Passing of structures between managed and unmanaged code
	/// </summary>
	class StructureClassesTest
	{
        [DllImport("FlatAPIStructLib.DLL")]
        public static extern bool LookupItemDetail( [In, Out] ManagedItem item);

        [DllImport("FlatAPIStructLib.DLL")]
        public static extern bool LookupItemDetailByRef( ref ManagedItem item);

        [DllImport("FlatAPIStructLib.DLL")]
        public static extern bool LookupItemDetailCPPRef( [In, Out] ManagedItem item);

        [DllImport("FlatAPIStructLib.DLL")]
        public static extern bool LookupItemDetailBlit(ManagedItemBlit item);

        [DllImport("FlatAPIStructLib.DLL")]
        public static extern bool LookupItemDetailClass( [In, Out] ManagedItem item);
	
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
		    //pass a class object as an [In,Out]
		    ManagedItem item = new ManagedItem();
		    item.ItemId         = 111;
		    
		    //call the unmanaged function using [In,Out]
		    bool result = LookupItemDetail(item);
            
            //show the results
            Console.WriteLine(
                "LookupItemDetail results: {0},{1},{2},{3},{4}",
                item.ItemId, item.ItemDesc, item.TaxCategoryId, 
                item.CategoryCode, item.UnitPrice);

            //pass a class by ref
            item = new ManagedItem();
            item.ItemId         = 111;
		    
            //call the unmanaged function passing the class by ref
            result = LookupItemDetailByRef(ref item);
            
            //show the results
            Console.WriteLine(
                "LookupItemDetailByRef results: {0},{1},{2},{3},{4}",
                item.ItemId, item.ItemDesc, item.TaxCategoryId, 
                item.CategoryCode, item.UnitPrice);

            //pass a class to unmanaged function that expects a c++ Ref
            item = new ManagedItem();
            item.ItemId         = 111;
		    
            //call the unmanaged function passing the class by ref
            result = LookupItemDetailCPPRef(item);
            
            //show the results
            Console.WriteLine(
                "LookupItemDetailCRef results: {0},{1},{2},{3},{4}",
                item.ItemId, item.ItemDesc, item.TaxCategoryId, 
                item.CategoryCode, item.UnitPrice);

            //pass a blittable class to unmanaged function. because
            //the class contains only blittable fields, it is updatable
            //by the unmanaged function even if we omit the [In,Out]
            ManagedItemBlit itemBlit = new ManagedItemBlit();
            itemBlit.ItemId         = 111;
		    
            //call the unmanaged function
            result = LookupItemDetailBlit(itemBlit);
            
            //show the results
            Console.WriteLine(
                "LookupItemDetailBlit results: {0},{1},{2},{3}",
                itemBlit.ItemId, itemBlit.TaxCategoryId, 
                itemBlit.CategoryCode, itemBlit.UnitPrice);

            //pass a class object as an [In,Out]. the unmanaged
            //function expects a class rather than a struct
            item = new ManagedItem();
            item.ItemId         = 111;
		    
            //call the unmanaged function 
            result = LookupItemDetailClass(item);
            
            //show the results
            Console.WriteLine(
                "LookupItemDetailClass results: {0},{1},{2},{3},{4}",
                item.ItemId, item.ItemDesc, item.TaxCategoryId, 
                item.CategoryCode, item.UnitPrice);


            		    
       	    //wait for input
            Console.WriteLine("Press any key to exit");      
            Console.Read(); 	    
		}
	}
}
