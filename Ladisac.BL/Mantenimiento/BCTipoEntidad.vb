Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCTipoEntidad
        Implements IBCTipoEntidad

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaTipoEntidad() As String Implements IBCTipoEntidad.ListaTipoEntidad
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoEntidadRepositorio)()
                result = rep.ListaTipoEntidad
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoTipoEntidad(ByVal mTipoEntidad As BE.TipoEntidad) Implements IBCTipoEntidad.MantenimientoTipoEntidad
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoEntidadRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mTipoEntidad.ChangeTracker.State = ObjectState.Added) Then
                        mTipoEntidad.TEN_ID = bcherramientas.Get_Id("TipoEntidad")
                    ElseIf (mTipoEntidad.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mTipoEntidad)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TipoEntidadGetById(ByVal TEN_ID As Integer) As BE.TipoEntidad Implements IBCTipoEntidad.TipoEntidadGetById
            Dim result As TipoEntidad = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoEntidadRepositorio)()
                result = rep.GetById(TEN_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function
    End Class

End Namespace
