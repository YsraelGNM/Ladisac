Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCTipoMantto
        Implements IBCTipoMantto

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaTipoMantto() As String Implements IBCTipoMantto.ListaTipoMantto
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoManttoRepositorio)()
                result = rep.ListaTipoMantto
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoTipoMantto(ByVal mTipoMantto As BE.TipoMantto) Implements IBCTipoMantto.MantenimientoTipoMantto
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoManttoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mTipoMantto.ChangeTracker.State = ObjectState.Added) Then
                        mTipoMantto.TMO_ID = bcherramientas.Get_Id("TipoMantto")
                    ElseIf (mTipoMantto.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mTipoMantto)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TipoManttoGetById(ByVal TMO_ID As Integer) As BE.TipoMantto Implements IBCTipoMantto.TipoManttoGetById
            Dim result As TipoMantto = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoManttoRepositorio)()
                result = rep.GetById(TMO_ID)
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
