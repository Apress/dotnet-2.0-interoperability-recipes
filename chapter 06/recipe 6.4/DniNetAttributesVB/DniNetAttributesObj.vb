Imports System.Runtime.InteropServices

<Guid("299E5465-6ADC-4336-BB54-1F9BEBB311A2")> _
Public Interface IComAttributes
    Sub Foo()
End Interface

<Guid("7F28D289-E549-4e4d-8822-ADD7B8EFD5FF")> _
<ProgId("DniNetAttributesVB.DniNetAttributesModified")> _
<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetAttributesObj
    Implements IComAttributes

    Public Sub Foo() Implements IComAttributes.Foo
        'not implemented
    End Sub
End Class
