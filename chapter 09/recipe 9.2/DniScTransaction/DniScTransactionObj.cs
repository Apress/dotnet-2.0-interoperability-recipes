using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

using TransactionLogging;

namespace DniScTransaction
{
	public interface ITranMethods
	{
		string GetTranStatus();
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniScTransactionNoneObj
		: ServicedComponent, ITranMethods
	{
		public string GetTranStatus()
		{
			//log details about the transaction
			TransactionLogger log = new TransactionLogger(this);
			return ContextUtil.IsInTransaction.ToString();
		}
	}

	[Transaction]	//defaults to TransactionOption.Required
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScTransactionDefaultObj 
		: ServicedComponent, ITranMethods
	{
		public string GetTranStatus()
		{
			//log details about the transaction
			TransactionLogger log = new TransactionLogger(this);
			return ContextUtil.IsInTransaction.ToString();
		}
	}

	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScTransactionRequiredObj
		: ServicedComponent, ITranMethods
	{
		public string GetTranStatus()
		{
			//log details about the transaction
			TransactionLogger log = new TransactionLogger(this);
			return ContextUtil.IsInTransaction.ToString();
		}
	}

	[Transaction(TransactionOption.RequiresNew)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScTransactionRequiresNewObj
		: ServicedComponent, ITranMethods
	{
		public string GetTranStatus()
		{
			//log details about the transaction
			TransactionLogger log = new TransactionLogger(this);
			return ContextUtil.IsInTransaction.ToString();
		}
	}

	[Transaction(TransactionOption.Disabled)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScTransactionDisabledObj
		: ServicedComponent, ITranMethods
	{
		public string GetTranStatus()
		{
			//log details about the transaction
			TransactionLogger log = new TransactionLogger(this);
			return ContextUtil.IsInTransaction.ToString();
		}
	}

	[Transaction(TransactionOption.NotSupported)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScTransactionNotSupportedObj
		: ServicedComponent, ITranMethods
	{
		public string GetTranStatus()
		{
			//log details about the transaction
			TransactionLogger log = new TransactionLogger(this);
			return ContextUtil.IsInTransaction.ToString();
		}
	}

	[Transaction(TransactionOption.Supported)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScTransactionSupportedObj
		: ServicedComponent, ITranMethods
	{
		public string GetTranStatus()
		{
			//log details about the transaction
			TransactionLogger log = new TransactionLogger(this);
			return ContextUtil.IsInTransaction.ToString();
		}
	}

	/// <summary>
	/// Pass-thru to the Supports class. When called
	/// from this class that requires a transaction,
	/// the Supports class is able to use the tran.
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScTransactionUsesSupportsObj
		: ServicedComponent, ITranMethods
	{
		public string GetTranStatus()
		{
			//log details about the transaction
			TransactionLogger log = new TransactionLogger(this);

			//call the object that supports but does
			//not require a transaction
			DniScTransactionSupportedObj obj
				= new DniScTransactionSupportedObj();
			obj.GetTranStatus();

			return ContextUtil.IsInTransaction.ToString();
		}
	}

	/// <summary>
	/// Pass-thru to the RequiresNew class. When called
	/// from this class that requires a transaction,
	/// the RequiresNew class should start a new transaction
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScTransactionUsesRequiresNewObj
		: ServicedComponent, ITranMethods
	{
		public string GetTranStatus()
		{
			//log details about the transaction
			TransactionLogger log = new TransactionLogger(this);

			//call the object that requires a new tran
			DniScTransactionRequiresNewObj obj
				= new DniScTransactionRequiresNewObj();
			obj.GetTranStatus();

			return ContextUtil.IsInTransaction.ToString();
		}
	}
}
