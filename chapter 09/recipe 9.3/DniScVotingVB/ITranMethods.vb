Public Enum RequestedResult
    Success
    VoteToAbort
    ThrowException
End Enum

Public Interface ITranMethods
    Sub PerformWork(ByVal request As RequestedResult)
End Interface
