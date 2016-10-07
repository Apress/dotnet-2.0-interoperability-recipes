using System;
using System.Transactions;

namespace DniScResource
{
	public class FileResourceManager : IEnlistmentNotification
	{
		private CommittableFile m_File;

		public FileResourceManager(CommittableFile file)
		{
			//save the file passed to us
			m_File = file;
		}

		public void Commit(Enlistment enlistment)
		{
			//commit our committable file object
			m_File.Commit();
			//indicate that everything committed ok
			enlistment.Done();
		}

		public void InDoubt(Enlistment enlistment)
		{
			//the tran is in doubt because one or more
			//resource manager cannot be contacted
			Rollback(enlistment);				
		}

		public void Prepare(PreparingEnlistment preparingEnlistment)
		{
			//called when we are about to commit. 
			//indicate that everything is ok to commit.
			preparingEnlistment.Prepared();
		}

		public void Rollback(Enlistment enlistment)
		{
			//the transaction is rolling back. we need
			//to rollback our committable file object
			m_File.Rollback();
			enlistment.Done();
		}
	}
}
