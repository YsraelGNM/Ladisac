Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCAsientoAutomatico
        Implements IBCAsientoAutomatico


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function AsientoAutomaticoCompras(ByVal periodo As String) As Object Implements IBCAsientoAutomatico.AsientoAutomaticoCompras
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.ReportesRepositorio)()
                    rep.EjecutarReporte(DA.SPNames.SPAsientoAutomaticoCompra, periodo)

                    Scope.Complete()

                End Using

                Return True
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function AsientoAutomaticoDividendos(ByVal periodo As String) As Object Implements IBCAsientoAutomatico.AsientoAutomaticoDividendos
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.ReportesRepositorio)()
                    rep.EjecutarReporte(DA.SPNames.SPAsientoAutomaticoDividendo, periodo)

                    Scope.Complete()

                End Using

                Return True
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function AsientoAutomaticoPersonal(ByVal periodo As String) As Object Implements IBCAsientoAutomatico.AsientoAutomaticoPersonal
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.ReportesRepositorio)()
                    rep.EjecutarReporte(DA.SPNames.SPAsientoAutomaticoPlanillas, periodo)

                    Scope.Complete()

                End Using

                Return True
            Catch ex As Exception
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
                MsgBox(ex.Message, vbObjectError)

            End Try
            Return False
        End Function

        Public Function AsientoAutomaticoTesoreria(ByVal periodo As String) As Object Implements IBCAsientoAutomatico.AsientoAutomaticoTesoreria
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.ReportesRepositorio)()
                    rep.EjecutarReporte(DA.SPNames.SPAsientoAutomaticoTesoreria, periodo)

                    Scope.Complete()

                End Using

                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Return False
        End Function

        Public Function AsientoAutomaticoVentas(ByVal periodo As String) As Object Implements IBCAsientoAutomatico.AsientoAutomaticoVentas
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))


                    Dim rep = ContainerService.Resolve(Of DA.ReportesRepositorio)()
                    rep.EjecutarReporte(DA.SPNames.SPAsientoAutomaticoVentas, periodo)

                    Scope.Complete()

                End Using

                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function RecarculoKardex(ByVal periodo As String) As Object Implements IBCAsientoAutomatico.RecarculoKardex
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))


                    Dim rep = ContainerService.Resolve(Of DA.ReportesRepositorio)()
                    rep.EjecutarReporte(DA.SPNames.spRecarculoKardex, periodo)

                    Scope.Complete()

                End Using

                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False

        End Function
    End Class

End Namespace

