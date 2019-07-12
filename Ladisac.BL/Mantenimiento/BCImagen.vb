Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCImagen
        Implements IBCImagen

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ImagenGetById(ByVal IMA_ID As Integer) As BE.Imagen Implements IBCImagen.ImagenGetById
            Dim result As Imagen = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IImagenRepositorio)()
                result = rep.GetById(IMA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaImagen() As String Implements IBCImagen.ListaImagen
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IImagenRepositorio)()
                result = rep.ListaImagen
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoImagen(ByVal mImagen As BE.Imagen) Implements IBCImagen.MantenimientoImagen
            Try
                Dim rep = ContainerService.Resolve(Of DA.IImagenRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mImagen.ChangeTracker.State = ObjectState.Added) Then
                        mImagen.IMA_ID = bcherramientas.Get_Id("Imagen")
                    ElseIf (mImagen.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mImagen)

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
