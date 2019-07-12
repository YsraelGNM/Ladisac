Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCOrdenServicio
        Implements IBCOrdenServicio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaOrdenServicio() As String Implements IBCOrdenServicio.ListaOrdenServicio
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenServicioRepositorio)()
                result = rep.ListaOrdenServicio
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result

        End Function

        Public Function MantenimientoOrdenServicio(ByVal mOrdenServicio As BE.OrdenServicio) As Integer Implements IBCOrdenServicio.MantenimientoOrdenServicio
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenServicioRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IOrdenServicioDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim PCompraDetalle = ContainerService.Resolve(Of DA.IProcesoCompraDetalleRepositorio)()
                Dim Parametro = ContainerService.Resolve(Of DA.IParametroRepositorio)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.Suppress, ts1)

                    If (mOrdenServicio.ChangeTracker.State = ObjectState.Added) Then
                        mOrdenServicio.OSE_ID = bcherramientas.Get_Id("OrdenServicio")
                    ElseIf (mOrdenServicio.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim Cod As Integer = bcherramientas.Get_Id("OrdenServicioDetalle")
                    For Each mItem In mOrdenServicio.OrdenServicioDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.OSD_ID = Cod
                            Cod += 1
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If

                    Next

                    rep.Maintenance(mOrdenServicio)

                    Scope.Complete()
                    Return 1
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Return 0
            End Try
        End Function

        Public Function OrdenServicioGetById(ByVal OSE_ID As Integer) As BE.OrdenServicio Implements IBCOrdenServicio.OrdenServicioGetById
            Dim result As OrdenServicio = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenServicioRepositorio)()
                result = rep.GetById(OSE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ImpresionOrdenServicio(ByVal OSE_ID As Object) As String Implements IBCOrdenServicio.ImpresionOrdenServicio
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spImpresionOrdenServicio", OSE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenServicioID(ByVal OSE_ID As Integer?) As System.Data.DataSet Implements IBCOrdenServicio.ListaOrdenServicioID
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenServicioRepositorio)()
                result = rep.ListaOrdenServicioID(OSE_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function OrdenServicioDetalleGetById(ByVal OSD_ID As Integer) As BE.OrdenServicioDetalle Implements IBCOrdenServicio.OrdenServicioDetalleGetById
            Dim result As OrdenServicioDetalle = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenServicioDetalleRepositorio)()
                result = rep.GetById(OSD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoOrdenServicioDetalle(ByVal mOrdenServicioDetalle As BE.OrdenServicioDetalle) Implements IBCOrdenServicio.MantenimientoOrdenServicioDetalle
            Try
                Dim repDeta = ContainerService.Resolve(Of DA.IOrdenServicioDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mOrdenServicioDetalle.ChangeTracker.State = ObjectState.Added) Then

                    ElseIf (mOrdenServicioDetalle.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    repDeta.Maintenance(mOrdenServicioDetalle)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaProgramacionPagoProveedor(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Per_Id_Proveedor As String) As String Implements IBCOrdenServicio.ListaProgramacionPagoProveedor
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaProgramacionPagoProveedor", FecIni, FecFin, Per_Id_Proveedor)
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
