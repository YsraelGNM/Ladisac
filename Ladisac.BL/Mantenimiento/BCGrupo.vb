Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCGrupo
        Implements IBCGrupo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GrupoGetById(ByVal GRU_ID As Integer) As BE.Grupo Implements IBCGrupo.GrupoGetById
            Dim result As Grupo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGrupoRepositorio)()
                result = rep.GetById(GRU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaGrupo() As String Implements IBCGrupo.ListaGrupo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGrupoRepositorio)()
                result = rep.ListaGrupo
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoGrupo(ByVal mGrupo As BE.Grupo) Implements IBCGrupo.MantenimientoGrupo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGrupoRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mGrupo.ChangeTracker.State = ObjectState.Added) Then
                        mGrupo.GRU_ID = bcherramientas.Get_Id("Grupo")
                    ElseIf (mGrupo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mGrupo)

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
