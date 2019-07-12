Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCFamiliaArticulo
        Implements IBCFamiliaArticulo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function FamiliaArticuloGetById(ByVal FAM_ID As String) As BE.FamiliaArticulos Implements IBCFamiliaArticulo.FamiliaArticuloGetById
            Dim result As FamiliaArticulos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFamiliaArticuloRepositorio)()
                result = rep.GetById(FAM_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaFamiliaArticulo() As String Implements IBCFamiliaArticulo.ListaFamiliaArticulo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFamiliaArticuloRepositorio)()
                result = rep.ListaFamiliaArticulo
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoFamiliaArticulo(ByVal mFamiliaArticulo As BE.FamiliaArticulos) Implements IBCFamiliaArticulo.MantenimientoFamiliaArticulo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IFamiliaArticuloRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Using Scope As New System.Transactions.TransactionScope()

                    If (mFamiliaArticulo.ChangeTracker.State = ObjectState.Added) Then
                        mFamiliaArticulo.FAM_ID = bcherramientas.Get_IdTx("FamiliaArticulo")
                    ElseIf (mFamiliaArticulo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mFamiliaArticulo)

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
