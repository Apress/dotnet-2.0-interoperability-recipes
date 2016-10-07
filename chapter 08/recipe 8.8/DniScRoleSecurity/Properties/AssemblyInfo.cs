using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.EnterpriseServices;

[assembly: ApplicationActivation(ActivationOption.Server)]
[assembly: ApplicationAccessControl(true)]
//[assembly: ApplicationAccessControl(true,
//	AccessChecksLevel = AccessChecksLevelOption.ApplicationComponent)]

[assembly: ApplicationName("DniRoleSecurityApplication")]
[assembly: Description(".NET Interop Server Application")]
//setup the roles within the COM+ application
[assembly: SecurityRole("AppAdministrator")]
[assembly: SecurityRole("AppManager")]
[assembly: SecurityRole("AppUser", true)]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("DniScRoleSecurity")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Bruce Bukovics")]
[assembly: AssemblyProduct("DniScRoleSecurity")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM componenets.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("03dea115-6332-47aa-960a-2520d40de08f")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
