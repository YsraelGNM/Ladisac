Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCModeloArticulo
        Implements IBCModeloArticulo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaModeloArticulo() As String Implements IBCModeloArticulo.ListaModeloArticulo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IModeloArticuloRepositorio)()
                result = rep.ListaModelo()
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoModeloArticulo(ByVal mModeloArticulo As BE.ModeloArticulos) Implements IBCModeloArticulo.MantenimientoModeloArticulo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IModeloArticuloRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Using Scope As New System.Transactions.TransactionScope()

                    If (mModeloArticulo.ChangeTracker.State = ObjectState.Added) Then
                        mModeloArticulo.MOD_ID = bcherramientas.Get_IdTx("ModeloArticulos")
                    ElseIf (mModeloArticulo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mModeloArticulo)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ModeloArticuloGetById(ByVal MOD_ID As String) As BE.ModeloArticulos Implements IBCModeloArticulo.ModeloArticuloGetById
            Dim result As ModeloArticulos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IModeloArticuloRepositorio)()
                result = rep.GetById(MOD_ID)
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
