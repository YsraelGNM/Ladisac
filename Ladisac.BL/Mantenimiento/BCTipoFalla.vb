Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCTipoFalla
        Implements IBCTipoFalla

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaTipoFalla() As String Implements IBCTipoFalla.ListaTipoFalla
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoFallaRepositorio)()
                result = rep.ListaTipoFalla
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoTipoFalla(ByVal mTipoFalla As BE.TipoFalla) Implements IBCTipoFalla.MantenimientoTipoFalla
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoFallaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mTipoFalla.ChangeTracker.State = ObjectState.Added) Then
                        mTipoFalla.TFA_ID = bcherramientas.Get_Id("TipoFalla")
                    ElseIf (mTipoFalla.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mTipoFalla)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function TipoFallaGetById(ByVal TFA_ID As Integer) As BE.TipoFalla Implements IBCTipoFalla.TipoFallaGetById
            Dim result As TipoFalla = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ITipoFallaRepositorio)()
                result = rep.GetById(TFA_ID)
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
