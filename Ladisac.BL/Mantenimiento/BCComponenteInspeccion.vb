Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCComponenteInspeccion
        Implements IBCComponenteInspeccion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ComponenteInspeccionGetById(ByVal COM_ID As Integer) As BE.ComponenteInspeccion Implements IBCComponenteInspeccion.ComponenteInspeccionGetById
            Dim result As ComponenteInspeccion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IComponenteInspeccionRepositorio)()
                result = rep.GetById(COM_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaComponenteInspeccion() As String Implements IBCComponenteInspeccion.ListaComponenteInspeccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IComponenteInspeccionRepositorio)()
                result = rep.ListaComponenteInspeccion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoComponenteInspeccion(ByVal mComponenteInspeccion As BE.ComponenteInspeccion) Implements IBCComponenteInspeccion.MantenimientoComponenteInspeccion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IComponenteInspeccionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mComponenteInspeccion.ChangeTracker.State = ObjectState.Added) Then
                        mComponenteInspeccion.COM_ID = bcherramientas.Get_Id("ComponenteInspeccion")
                    ElseIf (mComponenteInspeccion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mComponenteInspeccion)

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
