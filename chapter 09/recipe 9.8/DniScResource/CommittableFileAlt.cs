using System;
using System.IO;
using System.Transactions;

namespace DniScResourceAlternate
{
	/// <summary>
	/// Writes a file that can be under the control
	/// of a transaction
	/// </summary>
	public class CommittableFileAlt 
	{
		private string			m_FilePath;
		private StreamWriter	m_Writer;
		private bool			m_WriterOpen;

		public CommittableFileAlt(string filepath)
		{
			//save the file path
			m_FilePath = filepath;

			if (Transaction.Current != null)
			{
				//create our resource manager and enlist 
				//it in the current transaction
				FileResourceManagerAlt resourceMgr
					= new FileResourceManagerAlt(this);
				Transaction.Current.EnlistVolatile(
					resourceMgr, EnlistmentOptions.None);
			}

			//open the output streamwriter
			m_Writer = new StreamWriter(m_FilePath);
			m_WriterOpen = true;
		}

		public string FilePath
		{
			get { return m_FilePath; }
			set { m_FilePath = value; }
		}

		public void WriteString(string data)
		{
			m_Writer.Write(data);
			m_Writer.Flush();
		}

		public void Close()
		{
			if (m_WriterOpen)
			{
				m_Writer.Close();
				m_WriterOpen = false;
			}
		}
	}
}
