using System;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

namespace DniScJIT
{
	[ClassInterface(ClassInterfaceType.None)]
	public class DniScNotJITObj 
		: ServicedComponent, IJITMethods
	{
		private int m_Number;

		public void AddNumber(int number)
		{
			m_Number += number;
		}

		public int GetTotal()
		{
			return m_Number;
		}

		public int AddSomeNumbers(int numA, int numB)
		{
			return numA + numB;
		}
	}
}
