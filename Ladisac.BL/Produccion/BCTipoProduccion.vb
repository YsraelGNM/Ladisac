Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCTipoProduccion
        Implements IBCTipoProduccion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaTipoProduccion() As String Implements IBCTipoProduccion.ListaTipoProduccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoProduccionRepositorio)()
                result = rep.ListaTipoProduccion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoTipoProduccion(ByVal mTipoProduccion As BE.TipoProduccion) Implements IBCTipoProduccion.MantenimientoTipoProduccion
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoProduccionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mTipoProduccion.ChangeTracker.State = ObjectState.Added) Then
                        mTipoProduccion.TPR_ID = bcherramientas.Get_Id("TipoProduccion")
                    ElseIf (mTipoProduccion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mTipoProduccion)

                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TipoProduccionGetById(ByVal TPR_ID As Integer) As BE.TipoProduccion Implements IBCTipoProduccion.TipoProduccionGetById
            Dim result As TipoProduccion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoProduccionRepositorio)()
                result = rep.GetById(TPR_ID)
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
