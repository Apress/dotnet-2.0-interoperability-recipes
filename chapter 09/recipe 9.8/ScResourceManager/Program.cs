using System;
using System.IO;
using System.Transactions;

using DniScResource;
using DniScResourceAlternate;

namespace ScResourceManager
{
	class Program
	{
		static void Main(string[] args)
		{
			NoTranFileTest();
			FileTestCommit();
			FileTestRollback();
			TwoFileRollback();

			AlternateNoTranFileTest();
			AlternateFileTestCommit();
			AlternateFileTestRollback();

			Console.WriteLine("Press enter to continue");
			Console.Read();
		}

		static void NoTranFileTest()
		{
			//use the file class without a transaction

			CommittableFile file
				= new CommittableFile(@"c:\DniTestFile0.txt");
			file.WriteString("write this text");
			file.Commit();

			Console.WriteLine(
				"NoTranFileTest file exists: {0}",
					File.Exists(@"c:\DniTestFile0.txt"));
		}

		static void FileTestCommit()
		{
			//use the file class within a transaction 
			//and successfully commit it

			TransactionScope scope = new TransactionScope();
			using (scope)
			{
				CommittableFile file
					= new CommittableFile(@"c:\DniTestFile1.txt");
				file.WriteString("write this text");
				scope.Complete();
			}

			Console.WriteLine(
				"FileTestCommit file exists: {0}",
					File.Exists(@"c:\DniTestFile1.txt"));
		}

		static void FileTestRollback()
		{
			//use the file class within a transaction
			//but cause it to be rolled back

			TransactionScope scope = new TransactionScope();
			using (scope)
			{
				CommittableFile file
					= new CommittableFile(@"c:\DniTestFile2.txt");
				file.WriteString("write this text");

				//do not call scope.complete for this test
			}

			Console.WriteLine(
				"FileTestRollback file exists: {0}",
					File.Exists(@"c:\DniTestFile2.txt"));
		}

		static void TwoFileRollback()
		{
			//use two files within the same transaction.
			//both should be rolled back

			TransactionScope scope = new TransactionScope();
			using (scope)
			{
				CommittableFile file3
					= new CommittableFile(@"c:\DniTestFile3.txt");
				file3.WriteString("write this text");

				CommittableFile file4
					= new CommittableFile(@"c:\DniTestFile4.txt");
				file4.WriteString("write this text");

				//do not call scope.complete for this test
			}

			Console.WriteLine(
				"TwoFileRollback files exist: {0}, {1}",
					File.Exists(@"c:\DniTestFile3.txt"),
					File.Exists(@"c:\DniTestFile4.txt"));
		}

		//
		//methods for the alternate version follow
		//

		static void AlternateNoTranFileTest()
		{
			//use the file class without a transaction

			CommittableFileAlt file
				= new CommittableFileAlt(@"c:\DniAltTestFile0.txt");
			file.WriteString("write this text");
			file.Close();

			Console.WriteLine(
				"AlternateNoTranFileTest file exists: {0}",
					File.Exists(@"c:\DniAltTestFile0.txt"));
		}

		static void AlternateFileTestCommit()
		{
			//use the file class within a transaction 
			//and successfully commit it

			TransactionScope scope = new TransactionScope();
			using (scope)
			{
				CommittableFileAlt file
					= new CommittableFileAlt(@"c:\DniAltTestFile1.txt");
				file.WriteString("write this text");
				scope.Complete();
			}

			Console.WriteLine(
				"AlternateFileTestCommit file exists: {0}",
					File.Exists(@"c:\DniAltTestFile1.txt"));
		}

		static void AlternateFileTestRollback()
		{
			//use the file class within a transaction 
			//and successfully commit it

			TransactionScope scope = new TransactionScope();
			using (scope)
			{
				CommittableFileAlt file
					= new CommittableFileAlt(@"c:\DniAltTestFile2.txt");
				file.WriteString("write this text");
				//do not call scope.complete for this test
			}

			Console.WriteLine(
				"AlternateFileTestRollback file exists: {0}",
					File.Exists(@"c:\DniAltTestFile2.txt"));
		}

	}
}
