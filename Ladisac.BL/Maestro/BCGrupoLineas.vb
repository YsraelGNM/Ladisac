Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCGrupoLineas
        Implements IBCGrupoLineas


        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function GrupoLineasGetById(ByVal GLI_ID As String) As BE.GrupoLineas Implements IBCGrupoLineas.GrupoLineasGetById
            Dim result As GrupoLineas = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGrupoLineasRepositorio)()
                result = rep.GetById(GLI_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaGrupoLineas() As String Implements IBCGrupoLineas.ListaGrupoLineas
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGrupoLineasRepositorio)()
                result = rep.ListaGrupoLinea()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoGrupoLineas(ByVal mGrupoLineas As BE.GrupoLineas) Implements IBCGrupoLineas.MantenimientoGrupoLineas
            Try
                Dim rep = ContainerService.Resolve(Of DA.IGrupoLineasRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Using Scope As New System.Transactions.TransactionScope()

                    If (mGrupoLineas.ChangeTracker.State = ObjectState.Added) Then
                        mGrupoLineas.GLI_ID = bcherramientas.Get_IdTx("GrupoLinea")
                    ElseIf (mGrupoLineas.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mGrupoLineas)

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
