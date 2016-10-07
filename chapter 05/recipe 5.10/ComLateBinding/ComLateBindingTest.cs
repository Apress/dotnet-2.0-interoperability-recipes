using System;
using System.Reflection;

namespace ComLateBinding
{
	/// <summary>
	/// Use COM late-binding 
	/// </summary>
	class ComLateBindingTest
	{
		/// <summary>
		/// Use late-binding to reference COM objects
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			UseLateBoundInMethods();
			UseLateBoundInOutMethods();
			//wait for input
			Console.WriteLine("Press any key to exit");
			Console.Read();
		}

		private static void UseLateBoundInMethods()
		{
			//Retrieve the Type for the COM object
			Type comType = Type.GetTypeFromProgID(
				"DniComRefactorVB.DniComRefactorVBObj");

			//create an instance of the COM object
			Object comObj = Activator.CreateInstance(comType);

			//execute the first COM method				
			Int32 acctId = (Int32)comType.InvokeMember(
				"SearchForAccount", BindingFlags.InvokeMethod, null,
				comObj, new Object[] { "accountKey" });
			Decimal pastDueAmt = 0;
			if (acctId > 0)
			{
				//execute the second COM method
				pastDueAmt = (Decimal)comType.InvokeMember(
					"GetPastDueBalance", BindingFlags.InvokeMethod, 
					null, comObj, new Object[] { acctId });
				if (pastDueAmt > 100m)
				{
					//execute the third
					comType.InvokeMember(
						"SetAccountDelinquent", 
						BindingFlags.InvokeMethod, null,
						comObj, new Object[] { acctId });
				}
			}
			Console.WriteLine("Acct Id:{0}, PastDueAmt:{1}",
				acctId, pastDueAmt);
		}

		private static void UseLateBoundInOutMethods()
		{
			//Retrieve the Type for the COM object
			Type comType = Type.GetTypeFromProgID(
				"DniDataTypes.DniDataTypesObj");

			//create an instance of the COM object
			Object comObj = Activator.CreateInstance(comType);

			//tell the marshaler that the 2nd parameter is by ref
			ParameterModifier paramMod = new ParameterModifier(2);
			paramMod[0] = false;
			paramMod[1] = true;	//in/out ref param

			//set our array of parameters
			Object[] args = { 123, 0 };

			//show the arguments prior to the call
			Console.WriteLine(
				"Arguments prior to COM call - In:{0}, Out:{1}",
				args[0], args[1]);

			//execute the COM method
			Object result = comType.InvokeMember(
				"UseLong", BindingFlags.InvokeMethod, null,
				comObj, args,
				new ParameterModifier[] { paramMod },
				null, null);

			//remember that the in/out param is in the array!
			Console.WriteLine(
				"Late-bound in/out method - In:{0}, Out:{1}", 
				args[0], args[1]);
		}
	}
}
