Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCProcesoCompra
        Implements IBCProcesoCompra

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaProcesoCompraAConsolidar(ByVal USU_ID As String) As String Implements IBCProcesoCompra.ListaProcesoCompraAConsolidar
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProcesoCompraRepositorio)()
                result = rep.ListaProcesoCompra(USU_ID)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Sub MantenimientoProcesoCompra(ByVal mProcesoCompra As BE.ProcesoCompra) Implements IBCProcesoCompra.MantenimientoProcesoCompra
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProcesoCompraRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IProcesoCompraDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mProcesoCompra.ChangeTracker.State = ObjectState.Added) Then
                        mProcesoCompra.PRC_ID = bcherramientas.Get_Id("ProcesoCompra")

                    ElseIf (mProcesoCompra.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaProcesoCompraDetalle As New List(Of ProcesoCompraDetalle)
                    For Each mObj In mProcesoCompra.ProcesoCompraDetalle
                        Dim mProcesoCompraDetalle As New ProcesoCompraDetalle
                        mProcesoCompraDetalle = mObj.Clone() 'copiar
                        mListaProcesoCompraDetalle.Add(mProcesoCompraDetalle)
                    Next


                    mProcesoCompra.ChangeTracker.ChangeTrackingEnabled = False
                    mProcesoCompra.ProcesoCompraDetalle = Nothing
                    mProcesoCompra.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mProcesoCompra)

                    For Each mItem In mListaProcesoCompraDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.PCD_ID = bcherramientas.Get_Id("ProcesoCompraDetalle")
                            mItem.PRC_ID = mProcesoCompra.PRC_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)
                    Next

                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ProcesoCompraGetById(ByVal PRC_ID As Integer) As BE.ProcesoCompra Implements IBCProcesoCompra.ProcesoCompraGetById
            Dim result As ProcesoCompra = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProcesoCompraRepositorio)()
                result = rep.GetById(PRC_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoProcesoCompra(ByVal mProcesoCompra As BE.ProcesoCompra, ByVal dt As System.Data.DataTable) Implements IBCProcesoCompra.MantenimientoProcesoCompra
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProcesoCompraRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IProcesoCompraDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim repDetalleConsolidado = ContainerService.Resolve(Of DA.IDetalleConsolidadoRepositorio)()
                Dim repORD = ContainerService.Resolve(Of DA.IOrdenRequerimientoDetalleRepositorio)()
                Dim repSCD = ContainerService.Resolve(Of DA.ISolicitudCompraDetalleRepositorio)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mProcesoCompra.ChangeTracker.State = ObjectState.Added) Then
                        mProcesoCompra.PRC_ID = bcherramientas.Get_Id("ProcesoCompra")

                    ElseIf (mProcesoCompra.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mListaProcesoCompraDetalle As New List(Of ProcesoCompraDetalle)
                    For Each mObj In mProcesoCompra.ProcesoCompraDetalle
                        Dim mProcesoCompraDetalle As New ProcesoCompraDetalle
                        mProcesoCompraDetalle = mObj.Clone() 'copiar
                        mListaProcesoCompraDetalle.Add(mProcesoCompraDetalle)
                    Next


                    mProcesoCompra.ChangeTracker.ChangeTrackingEnabled = False
                    mProcesoCompra.ProcesoCompraDetalle = Nothing
                    mProcesoCompra.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mProcesoCompra)

                    For Each mItem In mListaProcesoCompraDetalle
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.PCD_ID = bcherramientas.Get_Id("ProcesoCompraDetalle")
                            mItem.PRC_ID = mProcesoCompra.PRC_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)


                        'para grabar en detalleconsolidado
                        For Each mFila In dt.Rows
                            If mFila("ART_ID") = mItem.ART_ID Then
                                Dim mDC As New DetalleConsolidado
                                mDC.MarkAsAdded()
                                mDC.PCD_ID = mItem.PCD_ID
                                mDC.PRC_ID = mItem.PRC_ID
                                If mFila("ORD_ID").ToString <> "" Then
                                    mDC.ORD_ID = CInt(mFila("ORD_ID"))
                                    'Para actualizar el requerimiento
                                    Dim mORD As OrdenRequerimientoDetalle
                                    mORD = repORD.GetById(mDC.ORD_ID)
                                    mORD.ORD_ESTADO_COMPRA = "CS"
                                    mORD.MarkAsModified()
                                    repORD.Maintenance(mORD)
                                Else
                                    mDC.SCD_ID = CInt(mFila("SCD_ID"))
                                    'Para actualizar la solicitud de compra
                                    Dim mSCD As SolicitudCompraDetalle
                                    mSCD = repSCD.GetById(mDC.SCD_ID)
                                    mSCD.SCD_ESTADO_COMPRA = "CS"
                                    mSCD.MarkAsModified()
                                    repSCD.Maintenance(mSCD)
                                End If
                                repDetalleConsolidado.Maintenance(mDC)
                            End If
                        Next
                    Next
                    Scope.Complete()
                End Using

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaProcesoCompraCotizacion(ByVal USU_ID As String) As String Implements IBCProcesoCompra.ListaProcesoCompraCotizacion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaProcesoCompraCotizacion", USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoProcesoCompraDetalle(ByVal mProcesoCompraDetalle As BE.ProcesoCompraDetalle) Implements IBCProcesoCompra.MantenimientoProcesoCompraDetalle
            Try
                Dim repDeta = ContainerService.Resolve(Of DA.IProcesoCompraDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)
                    Dim Cod As Integer = bcherramientas.Get_Id("PCDCotizacionDetalle")
                    For Each mPcdCoti In mProcesoCompraDetalle.PCDCotizacionDetalle
                        If (mPcdCoti.ChangeTracker.State = ObjectState.Added) Then
                            mPcdCoti.CCD_ID = Cod
                            Cod += 1
                        End If
                    Next
                    repDeta.Maintenance(mProcesoCompraDetalle)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ProcesoCompraDetalleGetById(ByVal PCD_ID As Integer) As BE.ProcesoCompraDetalle Implements IBCProcesoCompra.ProcesoCompraDetalleGetById
            Dim result As ProcesoCompraDetalle = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProcesoCompraDetalleRepositorio)()
                result = rep.GetById(PCD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaProcesoCompraResumen() As String Implements IBCProcesoCompra.ListaProcesoCompraResumen
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spImpresionProcesoCompraResumen")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaProcesoCompraSinCotizacion(ByVal USU_ID As String, ByVal Fecha As Date) As String Implements IBCProcesoCompra.ListaProcesoCompraSinCotizacion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaProcesoCompraSinCotizacion", USU_ID, Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ProcesoCompraDetalleGetById2(ByVal OCD_ID As Integer) As BE.ProcesoCompraDetalle Implements IBCProcesoCompra.ProcesoCompraDetalleGetById2
            Dim result As ProcesoCompraDetalle = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProcesoCompraDetalleRepositorio)()
                result = rep.GetById2(OCD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaAutorizar(ByVal USU_ID As String) As System.Data.DataTable Implements IBCProcesoCompra.ListaAutorizar
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spListaAutorizar", USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSeguimientoAutorizacion(ByVal USU_ID As String, ByVal FecIni As Date, ByVal FecFin As Date) As System.Data.DataTable Implements IBCProcesoCompra.ListaSeguimientoAutorizacion
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spListaSeguimientoAutorizacion", USU_ID, FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaProcesoCompraSinCotizacionImpresion(ByVal Fecha As Date) As String Implements IBCProcesoCompra.ListaProcesoCompraSinCotizacionImpresion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaProcesoCompraSinCotizacionImpresion", Fecha)
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
