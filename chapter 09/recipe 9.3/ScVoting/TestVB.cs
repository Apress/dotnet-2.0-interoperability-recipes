using System;
using System.Runtime.InteropServices;

using DniScVotingVB;

//perform tests of vb.net components

namespace ScVoting
{
	public class TestVB
	{
		public static void Test()
		{
			Console.WriteLine("starting VB.NET tests");

			AutoVotingTest(RequestedResult.Success);
			AutoVotingTest(RequestedResult.ThrowException);
			AutoVotingTest(RequestedResult.VoteToAbort);

			SetManualVotingTest(RequestedResult.Success);
			SetManualVotingTest(RequestedResult.ThrowException);
			SetManualVotingTest(RequestedResult.VoteToAbort);
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
