Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCOrdenCompra
        Implements IBCOrdenCompra

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaOrdencompra() As String Implements IBCOrdenCompra.ListaOrdenCompra
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenCompraRepositorio)()
                result = rep.ListaOrdenCompra
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result

        End Function

        Public Function MantenimientoOrdenCompra(ByVal mOrdenCompra As BE.OrdenCompra) As Integer Implements IBCOrdenCompra.MantenimientoOrdenCompra
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenCompraRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IOrdenCompraDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim PCompraDetalle = ContainerService.Resolve(Of DA.IProcesoCompraDetalleRepositorio)()
                Dim Parametro = ContainerService.Resolve(Of DA.IParametroRepositorio)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mOrdenCompra.ChangeTracker.State = ObjectState.Added) Then
                        mOrdenCompra.OCO_ID = bcherramientas.Get_Id("OrdenCompra")
                    ElseIf (mOrdenCompra.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaOrdenCompraDetalle As New List(Of OrdenCompraDetalle)
                    For Each mObj In mOrdenCompra.OrdenCompraDetalle
                        Dim mOrdenCompraDetalle As New OrdenCompraDetalle
                        mOrdenCompraDetalle = mObj.Clone
                        mListaOrdenCompraDetalle.Add(mOrdenCompraDetalle)
                    Next

                    mOrdenCompra.ChangeTracker.ChangeTrackingEnabled = False
                    mOrdenCompra.OrdenCompraDetalle = Nothing
                    mOrdenCompra.ChangeTracker.ChangeTrackingEnabled = True

                    For Each mItem In mOrdenCompra.ChangeTracker.ObjectsRemovedFromCollectionProperties
                        For Each mDet In mItem.Value
                            If CType(mDet, OrdenCompraDetalle).ProcesoCompraDetalle IsNot Nothing Then
                                CType(mDet, OrdenCompraDetalle).ProcesoCompraDetalle.OCD_ID = Nothing
                                CType(mDet, OrdenCompraDetalle).ProcesoCompraDetalle.MarkAsModified()
                                PCompraDetalle.Maintenance(CType(mDet, OrdenCompraDetalle).ProcesoCompraDetalle)
                            End If
                        Next

                    Next

                    rep.Maintenance(mOrdenCompra)

                    For Each mItem In mListaOrdenCompraDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.OCD_ID = bcherramientas.Get_Id("OrdenCompraDetalle")
                            mItem.OCO_ID = mOrdenCompra.OCO_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If

                        repDeta.Maintenance(mItem)

                        'Para actualizar el PCD
                        If mItem.PCD_ID > 0 Then
                            mItem.ProcesoCompraDetalle = PCompraDetalle.GetById(mItem.PCD_ID)
                        End If
                        If mItem.ProcesoCompraDetalle IsNot Nothing Then
                            If Not Parametro.GetById("NoActualizaPC").PAR_VALOR2.Contains("/" & mItem.ART_ID & "/") Then
                                mItem.ProcesoCompraDetalle.OCD_ID = mItem.OCD_ID
                                mItem.ProcesoCompraDetalle.MarkAsModified()
                                PCompraDetalle.Maintenance(mItem.ProcesoCompraDetalle)
                            End If
                        End If
                    Next

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

        Public Function OrdenCompraGetById(ByVal OCO_ID As Integer) As BE.OrdenCompra Implements IBCOrdenCompra.OrdenCompraGetById
            Dim result As OrdenCompra = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenCompraRepositorio)()
                result = rep.GetById(OCO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ImpresionOrdenCompra(ByVal OCO_ID As Object) As String Implements IBCOrdenCompra.ImpresionOrdenCompra
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spImpresionOrdenCompra", OCO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaOrdenCompraID(ByVal OCO_ID As Integer?) As System.Data.DataSet Implements IBCOrdenCompra.ListaOrdenCompraID
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenCompraRepositorio)()
                result = rep.ListaOrdenCompraID(OCO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function OrdenCompraDetalleGetById(ByVal OCD_ID As Integer) As BE.OrdenCompraDetalle Implements IBCOrdenCompra.OrdenCompraDetalleGetById
            Dim result As OrdenCompraDetalle = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IOrdenCompraDetalleRepositorio)()
                result = rep.GetById(OCD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoOrdenCompraDetalle(ByVal mOrdenCompraDetalle As BE.OrdenCompraDetalle) Implements IBCOrdenCompra.MantenimientoOrdenCompraDetalle
            Try
                Dim repDeta = ContainerService.Resolve(Of DA.IOrdenCompraDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mOrdenCompraDetalle.ChangeTracker.State = ObjectState.Added) Then

                    ElseIf (mOrdenCompraDetalle.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    repDeta.Maintenance(mOrdenCompraDetalle)

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub


        Public Function ListaProgramacionPagoProveedor(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Per_Id_Proveedor As String) As String Implements IBCOrdenCompra.ListaProgramacionPagoProveedor
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
