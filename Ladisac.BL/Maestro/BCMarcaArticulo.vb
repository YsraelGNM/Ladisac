Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCMarcaArticulo
        Implements IBCMarcaArticulo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaMarcaArticulo() As String Implements IBCMarcaArticulo.ListaMarcaArticulo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMarcaArticuloRepositorio)()
                result = rep.ListaMarca
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoMarcaArticulo(ByVal mMarcaArticulo As BE.MarcaArticulos) Implements IBCMarcaArticulo.MantenimientoMarcaArticulo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMarcaArticuloRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Using Scope As New System.Transactions.TransactionScope()

                    If (mMarcaArticulo.ChangeTracker.State = ObjectState.Added) Then
                        mMarcaArticulo.MAR_ID = bcherramientas.Get_IdTx("MarcaArticulos")
                    ElseIf (mMarcaArticulo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mMarcaArticulo)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function MarcaArticuloGetById(ByVal MAR_ID As String) As BE.MarcaArticulos Implements IBCMarcaArticulo.MarcaArticuloGetById
            Dim result As MarcaArticulos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IMarcaArticuloRepositorio)()
                result = rep.GetById(MAR_ID)
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
