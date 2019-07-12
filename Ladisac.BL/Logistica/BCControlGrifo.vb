Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlgrifo
        Implements IBCControlGrifo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function ControlGrifoGetById(ByVal MessageID As String) As BE.ControlGrifo Implements IBCControlGrifo.ControlGrifoGetById
            Dim result As ControlGrifo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlGrifoRepositorio)()
                result = rep.GetById(MessageID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlGrifo() As String Implements IBCControlGrifo.ListaControlGrifo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlGrifoRepositorio)()
                result = rep.ListaControlGrifo
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlGrifo(ByVal mControlGrifo As BE.ControlGrifo) Implements IBCControlGrifo.MantenimientoControlGrifo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlGrifoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlGrifo.ChangeTracker.State = ObjectState.Added) Then

                    ElseIf (mControlGrifo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mControlGrifo)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

    End Class

End Namespace
