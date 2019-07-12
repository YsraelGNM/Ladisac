Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCUnidadMedida
        Implements IBCUnidadMedida

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaUnidadMedida() As String Implements IBCUnidadMedida.ListaUnidadMedida
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IUnidadMedidaRepositorio)()
                result = rep.ListaUnidadMedida
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoUnidadMedida(ByVal mUnidadMedida As BE.UnidadMedidaArticulos) Implements IBCUnidadMedida.MantenimientoUnidadMedida
            Try
                Dim rep = ContainerService.Resolve(Of DA.IUnidadMedidaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Using Scope As New System.Transactions.TransactionScope()

                    If (mUnidadMedida.ChangeTracker.State = ObjectState.Added) Then
                        mUnidadMedida.UM_ID = bcherramientas.Get_IdTx("UnidadMedida")
                    ElseIf (mUnidadMedida.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mUnidadMedida)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function UnidadMedidaGetById(ByVal UM_ID As String) As BE.UnidadMedidaArticulos Implements IBCUnidadMedida.UnidadMedidaGetById
            Dim result As UnidadMedidaArticulos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IUnidadMedidaRepositorio)()
                result = rep.GetById(UM_ID)
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
