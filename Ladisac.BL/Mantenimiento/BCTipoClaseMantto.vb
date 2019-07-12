Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCTipoClaseMantto
        Implements IBCTipoClaseMantto

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaTipoClaseMantto() As String Implements IBCTipoClaseMantto.ListaTipoClaseMantto
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoClaseManttoRepositorio)()
                result = rep.ListaTipoClaseMantto
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoTipoClaseMantto(ByVal mTipoClaseMantto As BE.TipoClaseMantto) Implements IBCTipoClaseMantto.MantenimientoTipoClaseMantto
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoClaseManttoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mTipoClaseMantto.ChangeTracker.State = ObjectState.Added) Then
                        mTipoClaseMantto.TCM_ID = bcherramientas.Get_Id("TipoClaseMantto")
                    ElseIf (mTipoClaseMantto.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mTipoClaseMantto)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TipoClaseManttoGetById(ByVal TCM_ID As Integer) As BE.TipoClaseMantto Implements IBCTipoClaseMantto.TipoClaseManttoGetById
            Dim result As TipoClaseMantto = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoClaseManttoRepositorio)()
                result = rep.GetById(TCM_ID)
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
