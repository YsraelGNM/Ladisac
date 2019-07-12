Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCInspeccionPreOrdenTrabajo
        Implements IBCInspeccionPreOrdenTrabajo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function InspeccionPreOrdenTrabajoGetById(ByVal IOT_ID As Integer) As BE.InspeccionPreOrdenTrabajo Implements IBCInspeccionPreOrdenTrabajo.InspeccionPreOrdenTrabajoGetById
            Dim result As InspeccionPreOrdenTrabajo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInspeccionPreOrdenTrabajoRepositorio)()
                result = rep.GetById(IOT_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaInspeccionPreOrdenTrabajo() As String Implements IBCInspeccionPreOrdenTrabajo.ListaInspeccionPreOrdenTrabajo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInspeccionPreOrdenTrabajoRepositorio)()
                result = rep.ListaInspeccionPreOrdenTrabajo
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoInspeccionPreOrdenTrabajo(ByVal mInspeccionPreOrdenTrabajo As BE.InspeccionPreOrdenTrabajo) Implements IBCInspeccionPreOrdenTrabajo.MantenimientoInspeccionPreOrdenTrabajo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInspeccionPreOrdenTrabajoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mInspeccionPreOrdenTrabajo.ChangeTracker.State = ObjectState.Added) Then
                        mInspeccionPreOrdenTrabajo.IOT_ID = bcherramientas.Get_Id("InspeccionPreOrdenTrabajo")
                    ElseIf (mInspeccionPreOrdenTrabajo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mInspeccionPreOrdenTrabajo)

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
