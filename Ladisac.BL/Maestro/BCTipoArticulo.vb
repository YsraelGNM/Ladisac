Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCTipoArticulo
        Implements IBCTipoArticulo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaTipoArticulo() As String Implements IBCTipoArticulo.ListaTipoArticulo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoArticuloRepositorio)()
                result = rep.ListaTipoArticulo
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoTipoArticulo(ByVal mTipoArticulo As BE.TipoArticulos) Implements IBCTipoArticulo.MantenimientoTipoArticulo
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoArticuloRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Using Scope As New System.Transactions.TransactionScope()

                    If (mTipoArticulo.ChangeTracker.State = ObjectState.Added) Then
                        mTipoArticulo.TIP_ID = bcherramientas.Get_IdTx("TipoArticulo")
                    ElseIf (mTipoArticulo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mTipoArticulo)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TipoArticuloGetById(ByVal TIP_ID As String) As BE.TipoArticulos Implements IBCTipoArticulo.TipoArticuloGetById
            Dim result As TipoArticulos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoArticuloRepositorio)()
                result = rep.GetById(TIP_ID)
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
