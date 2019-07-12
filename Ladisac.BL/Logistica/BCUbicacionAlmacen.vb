Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCUbicacionAlmacen
        Implements IBCUbicacionAlmacen

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaUbicacionAlmacen() As String Implements IBCUbicacionAlmacen.ListaUbicacionAlmacen
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IUbicacionAlmacenRepositorio)()
                result = rep.ListaUbicacionAlmacen
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoUbicacionAlmacen(ByVal mUbicacionAlmacen As BE.UbicacionAlmacen) Implements IBCUbicacionAlmacen.MantenimientoUbicacionAlmacen
            Try
                Dim rep = ContainerService.Resolve(Of DA.IUbicacionAlmacenRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mUbicacionAlmacen.ChangeTracker.State = ObjectState.Added) Then
                        mUbicacionAlmacen.UBI_ID = bcherramientas.Get_Id("UbicacionAlmacen")
                    ElseIf (mUbicacionAlmacen.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mUbicacionAlmacen)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function UbicacionAlmacenGetById(ByVal UBI_ID As Integer) As BE.UbicacionAlmacen Implements IBCUbicacionAlmacen.UbicacionAlmacenGetById
            Dim result As UbicacionAlmacen = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IUbicacionAlmacenRepositorio)()
                result = rep.GetById(UBI_ID)
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
