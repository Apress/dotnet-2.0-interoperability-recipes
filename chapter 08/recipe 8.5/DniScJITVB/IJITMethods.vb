Public Interface IJITMethods
    'stateful methods
    Sub AddNumber(ByVal number As Integer)
    Function GetTotal() As Integer

    'stateless metehods
    Function AddSomeNumbers(ByVal numA As Integer, _
        ByVal numB As Integer) As Integer
End Interface

