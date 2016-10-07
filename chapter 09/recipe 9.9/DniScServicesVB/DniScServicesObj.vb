Imports System.EnterpriseServices
Imports DniScServicesVB.TransactionLogging

Public Interface IServicesWithoutComponents
    Sub UseComPlusServices(ByVal succeed As Boolean)
End Interface

Public Class DniScServicesObj
    Implements IServicesWithoutComponents

    Public Sub UseComPlusServices(ByVal succeed As Boolean) _
        Implements IServicesWithoutComponents.UseComPlusServices

        'configure the COM+ services
        Dim config As ServiceConfig _
            = New ServiceConfig()
        config.Transaction = TransactionOption.Required
        config.TrackingAppName = "ServicesWithoutComponents"
        config.TrackingComponentName = "DniScServicesObj"
        config.TrackingEnabled = True

        Try
            'enter a COM+ context
            ServiceDomain.Enter(config)

            'log the transaction
            Dim log As TransactionLogger _
                = New TransactionLogger(Me)

            'do work here involving one or more
            'resources such as a database or queue

            'complete or abort the transaction
            If succeed Then
                ContextUtil.SetComplete()
            Else
                ContextUtil.SetAbort()
            End If
        Finally
            'leave the COM+ context
            ServiceDomain.Leave()
        End Try

    End Sub
End Class
