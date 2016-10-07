using System;

namespace DniScVoting
{
	public enum RequestedResult
	{
		Success,
		VoteToAbort,
		ThrowException
	}

	public interface ITranMethods
	{
		void PerformWork(RequestedResult request);
	}
}
