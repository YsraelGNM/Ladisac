Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCLineaFamilia
        Implements IBCLineaFamilia

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function LineaFamiliaGetById(ByVal LIN_ID As String) As BE.LineasFamilia Implements IBCLineaFamilia.LineaFamiliaGetById
            Dim result As LineasFamilia = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILineaFamiliaRepositorio)()
                result = rep.GetById(LIN_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaLineaFamilia() As String Implements IBCLineaFamilia.ListaLineaFamilia
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILineaFamiliaRepositorio)()
                result = rep.ListaLineaFamilia
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoLineaFamilia(ByVal mLineaFamilia As BE.LineasFamilia) Implements IBCLineaFamilia.MantenimientoLineaFamilia
            Try
                Dim rep = ContainerService.Resolve(Of DA.ILineaFamiliaRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Using Scope As New System.Transactions.TransactionScope()

                    If (mLineaFamilia.ChangeTracker.State = ObjectState.Added) Then
                        mLineaFamilia.LIN_ID = bcherramientas.Get_IdTx("LineaFamilia")
                    ElseIf (mLineaFamilia.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mLineaFamilia)

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
