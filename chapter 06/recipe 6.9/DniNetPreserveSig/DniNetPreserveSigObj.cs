using System;
using System.Runtime.InteropServices;

namespace DniNetPreserveSig
{
	public interface IPreserveSig
	{
		void CopyString(string inParam, ref string outParam);

		[PreserveSig]
		[return: MarshalAs(UnmanagedType.Error)]
		int CopyStringPreserve(string inParam, ref string outParam);
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class DniNetPreserveSigObj : IPreserveSig
	{
		public void CopyString(string inParam, ref string outParam)
		{
			outParam = inParam;
			if (inParam.Length == 0)
			{
				//try to throw an S_FALSE HRESULT
				Marshal.ThrowExceptionForHR(1);
			}
		}

		public int CopyStringPreserve(
			string inParam, ref string outParam)
		{
			outParam = inParam;
			if (inParam.Length == 0)
			{
				return 1;	//S_FALSE;
			}
			return 0;	//S_OK;
		}
	}
}
