using System;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace DniScJIT
{
	[ClassInterface(ClassInterfaceType.None)]
	[JustInTimeActivation]
	public class DniScJITObj 
		: ServicedComponent, IJITMethods
	{
		private int m_Number;

        [AutoComplete]
		public void AddNumber(int number)
		{
			m_Number += number;
		}

		[AutoComplete]
		public int GetTotal()
		{
			return m_Number;
		}

		[AutoComplete]
		public int AddSomeNumbers(int numA, int numB)
		{
			return numA + numB;
		}
	}
}
