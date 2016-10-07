using System;
using System.IO;
using System.EnterpriseServices;
using System.Transactions;

namespace TransactionLogging
{
	class TransactionLogger
	{
		private string m_TargetName = string.Empty;

		/// <summary>
		/// Constructor 
		/// </summary>
		/// <param name="target"></param>
		public TransactionLogger(object target)
		{
			m_TargetName = target.GetType().Name;
			Log("------Starting method call------");
			if (Transaction.Current != null)
			{
				Transaction.Current.TransactionCompleted
					+= new TransactionCompletedEventHandler(
						tran_TransactionCompleted);
			}

			LogTranDetails(Transaction.Current, 
				"*Transaction at start of method:");
		}

		/// <summary>
		/// Log details about a transaction
		/// </summary>
		/// <param name="tran"></param>
		/// <param name="msg"></param>
		public void LogTranDetails(Transaction tran, String msg)
		{
			Log(msg);
			if (tran != null)
			{
				Log(" IsInTransaction: {0}",
					ContextUtil.IsInTransaction.ToString());
				if (ContextUtil.IsInTransaction)
				{
					Log(" MyTransactionVote: {0}",
						ContextUtil.MyTransactionVote.ToString());
				}
				Log(" IsolationLevel: {0}",	
					tran.IsolationLevel.ToString());
	
				TransactionInformation info
					= tran.TransactionInformation;
				Log(" Tran start time: {0}",
					info.CreationTime.ToString("HH:mm:ss.ffff"));
				if (info.DistributedIdentifier != null)
				{
					Log(" DistId: {0}",
						info.DistributedIdentifier);
				}
				Log(" TranId: {0}", info.LocalIdentifier);
				Log(" Tran Status: {0}", info.Status);
			}
			else
			{
				Log("***No current transaction***");
			}
		}

		/// <summary>
		/// Handler for the TransactionCompleted event 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tran_TransactionCompleted(object sender, 
			TransactionEventArgs e)
		{
			if (e.Transaction != null)
			{
				LogTranDetails(e.Transaction,
					"*Transaction at TransactionCompleted:");
			}
		}

		/// <summary>
		/// Log a message
		/// </summary>
		/// <param name="msg"></param>
		public void Log(string msg)
		{
			StreamWriter writer = new StreamWriter(
				string.Format(@"c:\{0}.txt", m_TargetName),
				true);

			writer.WriteLine("{0} {1} {2}",
				DateTime.Now.ToString("HH:mm:ss.ffff"),
				m_TargetName, msg);

			writer.Flush();
			writer.Close();
		}

		/// <summary>
		/// Log a formatted message
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="args"></param>
		public void Log(String msg, params Object[] args)
		{
			Log(String.Format(msg, args));
		}
	}
}
