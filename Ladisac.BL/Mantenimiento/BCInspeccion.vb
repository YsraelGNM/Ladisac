Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCInspeccion
        Implements IBCInspeccion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function InspeccionGetById(ByVal INS_ID As Integer) As BE.Inspeccion Implements IBCInspeccion.InspeccionGetById
            Dim result As Inspeccion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInspeccionRepositorio)()
                result = rep.GetById(INS_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaInspeccion() As String Implements IBCInspeccion.ListaInspeccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInspeccionRepositorio)()
                result = rep.ListaInspeccion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoInspeccion(ByVal mInspeccion As BE.Inspeccion) Implements IBCInspeccion.MantenimientoInspeccion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInspeccionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mInspeccion.ChangeTracker.State = ObjectState.Added) Then
                        mInspeccion.INS_ID = bcherramientas.Get_Id("Inspeccion")
                    ElseIf (mInspeccion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mInspeccion)

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
