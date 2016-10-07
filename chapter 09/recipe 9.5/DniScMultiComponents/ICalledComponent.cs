using System;

namespace DniScMultiComponents
{
	public interface ICalledComponent
	{
		bool PerformUpdate(bool succeed);
	}
}
