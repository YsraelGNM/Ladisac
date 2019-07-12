Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCTipoParada
        Implements IBCTipoParada

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Sub MantenimientoTipoParada(ByVal mTipoParada As BE.TipoParada) Implements IBCTipoParada.MantenimientoTipoParada
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoParadasRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)
                    If (mTipoParada.ChangeTracker.State = ObjectState.Added) Then
                        mTipoParada.TPA_ID = bcherramientas.Get_Id("TipoParada")
                    ElseIf (mTipoParada.ChangeTracker.State = ObjectState.Modified) Then
                    End If
                    rep.Maintenance(mTipoParada)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TipoParadaGetById(ByVal TPA_ID As Integer) As BE.TipoParada Implements IBCTipoParada.TipoParadaGetById
            Dim result As TipoParada = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoParadasRepositorio)()
                result = rep.GetById(TPA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTipoParada(ByVal TPA_ID As Integer) As String Implements IBCTipoParada.ListaTipoParada
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoParadasRepositorio)()
                result = rep.ListaTipoParada(TPA_ID)
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
