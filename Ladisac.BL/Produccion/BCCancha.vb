Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCCancha
        Implements IBCCancha

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function CanchaGetById(ByVal CAN_ID As Integer) As BE.Cancha Implements IBCCancha.CanchaGetById
            Dim result As Cancha = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICanchaRepositorio)()
                result = rep.GetById(CAN_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCancha() As String Implements IBCCancha.ListaCancha
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICanchaRepositorio)()
                result = rep.ListaCancha
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoCancha(ByVal mCancha As BE.Cancha) Implements IBCCancha.MantenimientoCancha
            Try
                Dim rep = ContainerService.Resolve(Of DA.ICanchaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mCancha.ChangeTracker.State = ObjectState.Added) Then
                        mCancha.CAN_ID = bcherramientas.Get_Id("Cancha")
                    ElseIf (mCancha.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mCancha)

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
