using System;
using System.Runtime.InteropServices;

using DniScVoting;

namespace ScVoting
{
	class Program
	{
		static void Main(string[] args)
		{
			AutoVotingTest(RequestedResult.Success);
			AutoVotingTest(RequestedResult.ThrowException);
			AutoVotingTest(RequestedResult.VoteToAbort);

			SetManualVotingTest(RequestedResult.Success);
			SetManualVotingTest(RequestedResult.ThrowException);
			SetManualVotingTest(RequestedResult.VoteToAbort);

			ManualVotingTest(RequestedResult.Success);
			ManualVotingTest(RequestedResult.ThrowException);
			ManualVotingTest(RequestedResult.VoteToAbort);

			Manual2VotingTest(RequestedResult.Success);
			Manual2VotingTest(RequestedResult.ThrowException);
			Manual2VotingTest(RequestedResult.VoteToAbort);

			TestVB.Test();

			Console.WriteLine("Press any key when ready");
			Console.Read();
		}

		private static void AutoVotingTest(RequestedResult request)
		{
			try
			{
				ITranMethods obj
					= new DniScAutoVoteObj();

				obj.PerformWork(request);
				Console.WriteLine(
					"DniScAutoVoteObj with {0} completed",
					request);

				//this keeps the log files tidy
				System.Threading.Thread.Sleep(200);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"DniScAutoVoteObj with {0} Exception: {1}",
						request, e.Message);
			}
		}

		private static void ManualVotingTest(RequestedResult request)
		{
			try
			{
				ITranMethods obj
					= new DniScManualVoteObj();

				obj.PerformWork(request);
				Console.WriteLine(
					"DniScManualVoteObj with {0} completed",
					request);

				//this keeps the log files tidy
				System.Threading.Thread.Sleep(200);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"DniScManualVoteObj with {0} Exception: {1}",
						request, e.Message);
			}
		}

		private static void Manual2VotingTest(RequestedResult request)
		{
			try
			{
				ITranMethods obj
					= new DniScManual2VoteObj();

				obj.PerformWork(request);
				Console.WriteLine(
					"DniScManual2VoteObj with {0} completed",
					request);

				//this keeps the log files tidy
				System.Threading.Thread.Sleep(200);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"DniScManual2VoteObj with {0} Exception: {1}",
						request, e.Message);
			}
		}

		private static void SetManualVotingTest(RequestedResult request)
		{
			try
			{
				ITranMethods obj
					= new DniScSetManualVoteObj();

				obj.PerformWork(request);
				Console.WriteLine(
					"DniScSetManualVoteObj with {0} completed",
					request);

				//this keeps the log files tidy
				System.Threading.Thread.Sleep(200);
			}
			catch (Exception e)
			{
				Console.WriteLine(
					"DniScSetManualVoteObj with {0} Exception: {1}",
						request, e.Message);
			}
		}
	}
}
