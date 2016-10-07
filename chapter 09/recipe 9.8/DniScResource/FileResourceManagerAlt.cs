using System;
using System.IO;
using System.Transactions;

namespace DniScResourceAlternate
{
	public class FileResourceManagerAlt : IEnlistmentNotification
	{
		private CommittableFileAlt m_File;
		private string m_FilePath;
		private string m_TempFilePath;

		public FileResourceManagerAlt(CommittableFileAlt file)
		{
			//save the file object passed to us
			m_File = file;
			
			//save the original file path
			m_FilePath = m_File.FilePath;
			//create a temporary file path
			string path = Path.GetPathRoot(m_FilePath);
			string tempFileOnly
				= Path.GetFileName(Path.GetTempFileName());
			m_TempFilePath = Path.Combine(path, tempFileOnly);
			//tell the file object to use the temporary
			//file instead of the original file
			m_File.FilePath = m_TempFilePath;
		}

		public void Commit(Enlistment enlistment)
		{
			//close the temporary file
			m_File.Close();
			//copy the temp file to the real file name
			File.Copy(m_TempFilePath, m_FilePath, true);
			//delete the temporary file
			File.Delete(m_TempFilePath);
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
			//to cleanup any temporary and perm files
			m_File.Close();
			//delete the temporary file if it exists
			if (File.Exists(m_TempFilePath))
			{
				File.Delete(m_TempFilePath);
			}
			enlistment.Done();
		}
	}
}
