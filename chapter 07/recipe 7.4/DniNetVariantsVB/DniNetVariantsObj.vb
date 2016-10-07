Imports System.Runtime.InteropServices

Public Interface IVariants
    Function UseVariant(ByVal inParam As Object, _
        ByRef outParam As Object) As String
End Interface

<ClassInterface(ClassInterfaceType.None)> _
Public Class DniNetVariantsObj
    Implements IVariants

    Public Function UseVariant(ByVal inParam As Object, _
        ByRef outParam As Object) As String _
            Implements IVariants.UseVariant
        'copy the input param to the output
        outParam = inParam

        'return the type description
        Return inParam.GetType().Name
    End Function
End Class

Public Interface ITestSyntax
    Function MyObjectMethod(ByVal param As Object) As Object
End Interface