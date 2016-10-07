using System;
using System.IO;
using System.Transactions;

namespace DniScResource
{
	/// <summary>
	/// Writes a file that can be under the control
	/// of a transaction
	/// </summary>
	public class CommittableFile : IDisposable
	{
		private string			m_FilePath;
		private string			m_TempFilePath;
		private StreamWriter	m_Writer;
		private bool			m_Completed;
		private bool			m_WriterOpen;

		public CommittableFile(string filepath)
		{
			//save the real file path
			m_FilePath = filepath;
			//create a temporary file path
			string path = Path.GetPathRoot(filepath);
			string tempFileOnly 
				= Path.GetFileName(Path.GetTempFileName());
			m_TempFilePath = Path.Combine(path, tempFileOnly);
			//initially write to a temporary file 
			m_Writer = new StreamWriter(m_TempFilePath);
			m_WriterOpen = true;

			if (Transaction.Current != null)
			{
				//create our resource manager and enlist 
				//it in the current transaction
				FileResourceManager resourceMgr
					= new FileResourceManager(this);
				Transaction.Current.EnlistVolatile(
					resourceMgr, EnlistmentOptions.None);
			}
		}

		public void WriteString(string data)
		{
			m_Writer.Write(data);
			m_Writer.Flush();
		}

		public void Commit()
		{
			//close the temporary file
			CloseTempFile();
			//copy the temp file to the real file name
			File.Copy(m_TempFilePath, m_FilePath, true);
			//delete the temporary file
			File.Delete(m_TempFilePath);
			m_Completed = true;
		}

		public void Rollback()
		{
			//cleanup any temporary and perm files
			CloseTempFile();
			if (!m_Completed)
			{
				//delete the temporary file if it exists
				if (File.Exists(m_TempFilePath))
				{
					File.Delete(m_TempFilePath);
				}
			}
		}

		public void Dispose()
		{
			CloseTempFile();

			//if commit was never called, we do a rollback
			if (!m_Completed)
			{
				Rollback();
			}
		}

		private void CloseTempFile()
		{
			if (m_WriterOpen)
			{
				m_Writer.Close();
				m_WriterOpen = false;
			}
		}
	}
}
