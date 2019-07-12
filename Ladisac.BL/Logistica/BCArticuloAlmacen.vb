Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCArticuloAlmacen
        Implements IBCArticuloAlmacen

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub MantenimientoArticuloAlmacen(ByVal mArticuloAlmacen As BE.ArticuloAlmacen) Implements IBCArticuloAlmacen.MantenimientoArticuloAlmacen
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloAlmacenRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mArticuloAlmacen.ChangeTracker.State = ObjectState.Added) Then
                        mArticuloAlmacen.ARA_ID = bcherramientas.Get_Id("ArticuloAlmacen")
                    ElseIf (mArticuloAlmacen.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mArticuloAlmacen)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaArticuloAlmacen(ByVal Art_Id As String, ByVal ALM_Id As Integer?) As Object Implements IBCArticuloAlmacen.ListaArticuloAlmacen
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloAlmacenRepositorio)()
                result = rep.ListaArticuloAlmacen(Art_Id, ALM_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ArticuloAlmacenGetById(ByVal ARA_ID As Integer) As BE.ArticuloAlmacen Implements IBCArticuloAlmacen.ArticuloAlmacenGetById
            Dim result As ArticuloAlmacen = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloAlmacenRepositorio)()
                result = rep.GetById(ARA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ArticuloAlmacenGetById(ByVal Art_Id As String, ByVal ALM_Id As Integer) As BE.ArticuloAlmacen Implements IBCArticuloAlmacen.ArticuloAlmacenGetById
            Dim result As ArticuloAlmacen = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloAlmacenRepositorio)()
                result = rep.GetById(Art_Id, ALM_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaArticuloAlmacenPermitido(ByVal Art_Id As String, ByVal ALM_Id As Integer?) As Object Implements IBCArticuloAlmacen.ListaArticuloAlmacenPermitido
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloAlmacenRepositorio)()
                result = rep.ListaArticuloAlmacenPermitido(Art_Id, ALM_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TotalStock(ByVal Art_Id As String) As Decimal Implements IBCArticuloAlmacen.TotalStock
            Dim result As Decimal
            Try
                Dim rep = ContainerService.Resolve(Of DA.IArticuloAlmacenRepositorio)()
                result = rep.TotalStock(Art_Id)
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
