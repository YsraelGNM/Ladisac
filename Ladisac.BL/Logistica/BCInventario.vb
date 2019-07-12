Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCInventario
        Implements IBCInventario

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function InventarioGetById(ByVal INV_ID As Integer) As BE.Inventario Implements IBCInventario.InventarioGetById
            Dim result As Inventario = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInventarioRepositorio)()
                result = rep.GetById(INV_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaInventario() As String Implements IBCInventario.ListaInventario
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInventarioRepositorio)()
                result = rep.ListaInventario
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoInventario(ByVal mInventario As BE.Inventario) Implements IBCInventario.MantenimientoInventario
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInventarioRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mInventario.ChangeTracker.State = ObjectState.Added) Then
                        mInventario.INV_ID = bcherramientas.Get_Id("Inventario")
                    ElseIf (mInventario.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mInventario)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaAInventariar(ByVal Fecha As Date, ByVal ALM_ID As Integer, ByVal UBI_ID As Integer) As String Implements IBCInventario.ListaAInventariar
            Dim result As String = Nothing
            Try
                ''Dim ts1 As New TimeSpan(0, 10, 0)
                ''Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)
                'Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                'result = rep.EjecutarReporte("spListaAInventariar", Fecha, ALM_ID, UBI_ID)
                ''    Scope.Complete()
                ''End Using
                Dim rep = ContainerService.Resolve(Of DA.IInventarioRepositorio)()
                result = rep.ListaAInventariar(Fecha, ALM_ID, UBI_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function InventarioGetById_Fecha(ByVal Fecha As Date) As System.Linq.IQueryable(Of Inventario) Implements IBCInventario.InventarioGetById_Fecha
            Dim result As Object = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInventarioRepositorio)()
                result = rep.GetById_Fecha(Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoInventarioMassive(ByVal colInventario As System.Collections.Generic.List(Of BE.Inventario)) Implements IBCInventario.MantenimientoInventarioMassive
            Try
                Dim rep = ContainerService.Resolve(Of DA.IInventarioRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    Dim Cod As Integer = bcherramientas.Get_Id("Inventario")
                    For Each mInventario In colInventario.ToList
                        If (mInventario.ChangeTracker.State = ObjectState.Added) Then
                            mInventario.INV_ID = Cod
                            Cod += 1
                        ElseIf (mInventario.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                    Next

                    rep.MaintenanceMassive(colInventario)

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
