Imports Ladisac.BE
Namespace Ladisac.BL

    Public Class BCProvisionCompras
        Implements IBCProvisionCompras

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property BCUtil As Ladisac.BL.IBCUtil


        Public Function Maintenance(ByVal item As BE.ProvisionCompras) As Object Implements IBCProvisionCompras.Maintenance
            Dim x As Integer = 0
            Dim y As Integer = 0
            Try
                Dim repCAB = ContainerService.Resolve(Of DA.IProvisionComprasRepositorio)()
                Dim repDET = ContainerService.Resolve(Of DA.IDetalleProvisionComprasRepositorio)()
                Dim repDETREF = ContainerService.Resolve(Of DA.IReferenciaProvisionComprasRepositorio)()

                Dim sCorrelativo As String = Nothing

                If (item.ChangeTracker.State = ObjectState.Added) Then
                    If (item.prc_Voucher.Trim = "") Then
                        sCorrelativo = BCUtil.GetId("Con.ProvisionCompras", "prc_Voucher", 6, " where lib_Id='" & item.lib_Id & "' and prd_Periodo_id='" & item.prd_Periodo_id & "' ")
                        item.prc_Voucher = sCorrelativo
                    Else
                        item.prc_Voucher = Right("0000000000" & Trim(item.prc_Voucher.ToString), 6)
                    End If

                End If

                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 10, 0))

                    ' -------------- detalle de prosivion compras
                    Dim listaDET As New List(Of DetalleProvisionCompras)
                    For Each RowDET In item.DetalleProvisionCompras
                        Dim NewDET As New BE.DetalleProvisionCompras

                        NewDET = RowDET.Clone

                        NewDET.prc_Voucher = item.prc_Voucher

                        If (NewDET.ChangeTracker.State = ObjectState.Modified) Then
                            If (Val(NewDET.prd_Item) > x) Then
                                x = Val(NewDET.prd_Item) ' determinamos el ultimo elemeto ingresado anteriormente--
                            End If

                        End If
                        listaDET.Add(NewDET)

                    Next

                    Dim listaDETRef As New List(Of ReferenciaProvisionCompras)

                    For Each RowDETRef In item.ReferenciaProvisionCompras
                        Dim NewDETRef As New BE.ReferenciaProvisionCompras
                        NewDETRef = RowDETRef.Clone
                        NewDETRef.prc_Voucher = item.prc_Voucher
                        If (NewDETRef.ChangeTracker.State = ObjectState.Modified) Then
                            If (Val(NewDETRef.rep_Item) > y) Then
                                y = Val(NewDETRef.rep_Item) ' determinamos el ultimo elemeto ingresado anteriormente--madro
                            End If

                        End If
                        listaDETRef.Add(NewDETRef)
                    Next

                    item.ChangeTracker.ChangeTrackingEnabled = False
                    item.DetalleProvisionCompras = Nothing
                    item.ReferenciaProvisionCompras = Nothing
                    item.ChangeTracker.ChangeTrackingEnabled = True
                    repCAB.maintenance(item)
                    'Dim i As Integer = 0
                    For Each mItemIngreso As BE.DetalleProvisionCompras In listaDET

                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = False
                        'mItemIngreso.ProvisionCompras = Nothing
                        mItemIngreso.ChangeTracker.ChangeTrackingEnabled = True

                        x += 1
                        If (mItemIngreso.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngreso.prd_Item = Right("0000" & x.ToString(), 3)
                        End If

                        mItemIngreso.prc_Voucher = item.prc_Voucher
                        repDET.Maintenance(mItemIngreso)

                    Next
                    '---------------fin detalle de prosivion compras 
                    ''--------------referencia provision compras

                    For Each mItemIngresoREF As BE.ReferenciaProvisionCompras In listaDETRef

                        mItemIngresoREF.ChangeTracker.ChangeTrackingEnabled = False
                        '¡  mItemIngresoREF.ProvisionCompras = Nothing
                        mItemIngresoREF.ChangeTracker.ChangeTrackingEnabled = True

                        y += 1
                        If (mItemIngresoREF.ChangeTracker.State = ObjectState.Added) Then
                            mItemIngresoREF.rep_Item = Right("0000" & y.ToString(), 3)
                        End If

                        mItemIngresoREF.prc_Voucher = item.prc_Voucher
                        repDETREF.Maintenance(mItemIngresoREF)

                    Next

                    ''--------------fin referencia provision compras
                    Scope.Complete()
                End Using

                Return True
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try

            Return False
        End Function

        Public Function ProvisionComprasQuery(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String, ByVal nombre As String, ByVal tdo_Id As String, ByVal prc_Serie As String, ByVal prc_Numero As String) As Object Implements IBCProvisionCompras.ProvisionComprasQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPProvisionComprasSelectXML, prd_Periodo_id, prc_Voucher, lib_Id, nombre, tdo_Id, prc_Serie, prc_Numero)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function ProvisionDividendosQuery(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String, ByVal nombre As String, ByVal tdo_Id As String, ByVal prc_Serie As String, ByVal prc_Numero As String) As Object Implements IBCProvisionCompras.ProvisionDividendosQuery
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPProvisionDividendosSelectXML, prd_Periodo_id, prc_Voucher, lib_Id, nombre, tdo_Id, prc_Serie, prc_Numero)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function ProvisionComprasSeek(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal lib_Id As String) As Object Implements IBCProvisionCompras.ProvisionComprasSeek
            Dim result As BE.ProvisionCompras = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProvisionComprasRepositorio)()
                result = rep.GetById(prd_Periodo_id, prc_Voucher, lib_Id)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ProvisionComprasTipoComprobantes(ByVal DTD_DESCRIPCION As String) As String Implements IBCProvisionCompras.ProvisionComprasTipoComprobantes
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTiposComprobantesSelectXML, DTD_DESCRIPCION)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ProvisionComprasTipoComprobantesDividendos(ByVal DTD_DESCRIPCION As String) As String Implements IBCProvisionCompras.ProvisionComprasTipoComprobantesDividendos
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTiposComprobantesDividendosSelectXML, DTD_DESCRIPCION)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PuntoVenta(ByVal descripcion As String) As String Implements IBCProvisionCompras.PuntoVenta
            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPPuntoVentaSelectXML, descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function TipoVenta(ByVal descripcion As String) As String Implements IBCProvisionCompras.TipoVenta
            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPTipoVentaSelectXML, descripcion)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function


        Public Function comprasQuery(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String, ByVal DMO_ID As Integer, ByVal OCO_ID As Integer) As String Implements IBCProvisionCompras.comprasQuery
            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDocuMovimientoXML, DetalleTipoDocumento, serie, numero, fechaInicio, fechaFin, nombre, DMO_ID, OCO_ID)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function comprasservicioQuery(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String, ByVal DMO_ID As Integer, ByVal OCO_ID As Integer) As String Implements IBCProvisionCompras.comprasservicioQuery
            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDocuMovimientoServicioXML, DetalleTipoDocumento, serie, numero, fechaInicio, fechaFin, nombre, DMO_ID, OCO_ID)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function comprasplanillaQuery(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String, ByVal DMO_ID As Integer, ByVal OCO_ID As Integer) As String Implements IBCProvisionCompras.comprasplanillaQuery
            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDocuMovimientoPlanillaXML, DetalleTipoDocumento, serie, numero, fechaInicio, fechaFin, nombre, DMO_ID, OCO_ID)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function comprasrendicionQuery(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String, ByVal DMO_ID As Integer, ByVal OCO_ID As Integer) As String Implements IBCProvisionCompras.comprasrendicionQuery
            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDocuMovimientoRendicionEntregasXML, DetalleTipoDocumento, serie, numero, fechaInicio, fechaFin, nombre, DMO_ID, OCO_ID)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function comprasXRefQuery(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal dtd_Id As String, ByVal per_Id As String, Optional ByVal Serie As String = Nothing, Optional ByVal numero As String = Nothing) As Object Implements IBCProvisionCompras.comprasXRefQuery
            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPProvisionComprasXRefSelectXML, fechaInicio, fechaFin, dtd_Id, per_Id, Serie, numero)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function DocuMovimientoLogistica(ByVal DetalleTipoDocumento As String, ByVal serie As String, ByVal numero As String, ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal nombre As String) As String Implements IBCProvisionCompras.DocuMovimientoLogistica
            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDocuMovimientoLogisticaXML, DetalleTipoDocumento, serie, numero, fechaInicio, fechaFin, nombre)

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function SaldosKardexDocumentosXML(ByVal CCT_ID As String, ByVal CCC_ID As String, ByVal PER_ID_CLI As String, ByVal CCT_ID_REF As String, ByVal TDO_ID_REF As String, ByVal DTD_ID_REF As String, ByVal DOC_SERIE_REF As String, ByVal DOC_NUMERO_REF As String, ByVal Documento As String, Optional ByVal ProcesarAnticipoPorCobrar As Short = 1) As Object Implements IBCProvisionCompras.SaldosKardexDocumentosXML

            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spSaldoskardexDocumentosXML, CCT_ID, CCC_ID, PER_ID_CLI, CCT_ID_REF, TDO_ID_REF, DTD_ID_REF, DOC_SERIE_REF, DOC_NUMERO_REF, Documento, ProcesarAnticipoPorCobrar)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If

            End Try
            Return result
        End Function

        Public Function MaintenanceDelete(ByVal item As BE.ProvisionCompras) As Object Implements IBCProvisionCompras.MaintenanceDelete
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProvisionComprasRepositorio)()
                Return rep.MaintenanceDelete(item)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function SPDocuMovimientoDetalleXML(ByVal DMO_ID As String) As Object Implements IBCProvisionCompras.SPDocuMovimientoDetalleXML

            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDocuMovimientoDetalleXML, DMO_ID)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If

            End Try
            Return result
        End Function

        Public Function SPDocuMovimientoDetalleServicioXML(ByVal DMO_ID As String) As Object Implements IBCProvisionCompras.SPDocuMovimientoDetalleServicioXML

            Dim result As String = Nothing
            Try

                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDocuMovimientoDetalleServicioXML, DMO_ID)

            Catch ex As Exception
                MsgBox(ex.Message)
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If

            End Try
            Return result
        End Function

        Public Function SPDocuMovimientoDetallePlanillaXML(ByVal DMO_ID As String) As Object Implements IBCProvisionCompras.SPDocuMovimientoDetallePlanillaXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDocuMovimientoDetallePlanillaXML, DMO_ID)
            Catch ex As Exception
                MsgBox(ex.Message)
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
            End Try
            Return result
        End Function

        Public Function SPDocuMovimientoDetalleRendicionXML(ByVal DMO_ID As String) As Object Implements IBCProvisionCompras.SPDocuMovimientoDetalleRendicionXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPDocuMovimientoDetalleRendicionXML, DMO_ID)
            Catch ex As Exception
                MsgBox(ex.Message)
                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
            End Try
            Return result
        End Function


        Public Function spProvisionComprasImprime(ByVal prc_Voucher As String, ByVal lib_Id As String, ByVal prd_Periodo_id As String) As Object Implements IBCProvisionCompras.spProvisionComprasImprime

            Dim result As DataTable = Nothing
            Try
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, New TimeSpan(0, 50, 0))

                    Dim rep = ContainerService.Resolve(Of DA.IConsultasReportesContabilidadRepositorio)()
                    result = rep.EjecutarReporte(DA.SPNames.spProvisionComprasImprime, prc_Voucher, lib_Id, prd_Periodo_id)
                    Scope.Complete()

                End Using


            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result
        End Function

        Public Function spDetalleProvisionCompras(ByVal prd_Periodo_id As String, ByVal prc_Voucher As String, ByVal cuc_IdOld As String, ByVal cuc_Idnew As String) As Object Implements IBCProvisionCompras.spDetalleProvisionCompras

            Dim result As Boolean
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProvisionComprasRepositorio)()
                result = rep.spDetalleProvisionCompras(prd_Periodo_id, prc_Voucher, cuc_IdOld, cuc_Idnew)

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