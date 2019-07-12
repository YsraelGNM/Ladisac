Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCProduccion
        Implements IBCProduccion

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaProduccion() As String Implements IBCProduccion.ListaProduccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ListaProduccion
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoProduccion(ByVal mProduccion As BE.Produccion) Implements IBCProduccion.MantenimientoProduccion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim ts1 As New TimeSpan(0, 3, 0)

                Dim repDetalleTipoDocumento = ContainerService.Resolve(Of DA.IDetalleTipoDocumentoRepositorio)()
                Dim repDocu = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                Dim repDetaDocu = ContainerService.Resolve(Of DA.IDocuMovimientoDetalleRepositorio)()
                Dim kardex = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                Dim Parametro = ContainerService.Resolve(Of DA.IParametroRepositorio)()
                Dim BCControlPeso = ContainerService.Resolve(Of DA.IControlPesoRepositorio)()
                Dim BCControlConteo = ContainerService.Resolve(Of BL.IBCControlConteo)()

                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mProduccion.ChangeTracker.State = ObjectState.Added) Then
                        mProduccion.PRO_ID = bcherramientas.Get_Id("Produccion")
                    ElseIf (mProduccion.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mProduccion)

                    Dim mPesoSeco As Decimal = BCControlPeso.GetPromPesoByIdPRO(mProduccion.PRO_ID)
                    If mProduccion.PRO_FINALIZADA = True And mPesoSeco > 0 Then

                        ' '''''''''''''''''BORRAR LO ANTERIOR SI SE MODIFICA
                        'Dim colDMO As List(Of DocuMovimiento)
                        'colDMO = repDocu.GetColRecicladoCrudoByIdPRO_ID(mProduccion.PRO_ID)
                        'For Each DMO In colDMO.ToList 'Para que borre el documento antes de guardarlo
                        '    If DMO IsNot Nothing Then
                        '        For Each mItem In DMO.DocuMovimientoDetalle
                        '            If mItem.Kardex IsNot Nothing Then mItem.Kardex(0).MarkAsDeleted() : kardex.Maintenance(mItem.Kardex(0))
                        '            mItem.MarkAsDeleted()
                        '            repDetaDocu.Maintenance(mItem)
                        '        Next
                        '        DMO.MarkAsDeleted()
                        '        repDocu.Maintenance(DMO)
                        '    End If
                        'Next

                        'Dim mDt As DataTable = Interfase_PrecioLadrilloCrudo(mProduccion.PRO_ID)
                        'If Not mDt.Rows(0)(0) > 0 Then Exit Sub

                        'Dim mDtRec As DataTable = Interfase_RecCrudoFinalProduccion(mProduccion.PRO_ID, mProduccion.PRO_CONTEO_FINALIZADA - mProduccion.PRO_CARGA_FINALIZADA)
                        'If Not mDtRec.Rows(0)(0) > 0 Then Exit Sub

                        ' '''''''''''''''''INGRESO ALMACEN MATERIA PRIMA - SOLO RECICLADO CRUDO
                        'Dim mDocu = New DocuMovimiento
                        'mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                        'mDocu.DMO_FECHA = mProduccion.PRO_FECHA.Value.AddDays(IIf(mProduccion.PRO_OBSERVACION.ToString.ToUpper.Contains("SECADERO"), 4, 15))
                        'mDocu.DTD_ID = "015"
                        'mDocu.TDO_ID = "006" 'Nota de Ingreso
                        'mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")
                        'mDocu.DMO_SERIE = "AMPR"
                        'mDocu.DMO_NRO = mProduccion.PRO_ID
                        'mDocu.DMO_FECHA_DOCUMENTO = mProduccion.PRO_FECHA_FINALIZADA
                        'mDocu.MON_ID = "001" 'Soles
                        'mDocu.DOCU_AFECTA_KARDEX = True
                        'mDocu.PRO_ID = mProduccion.PRO_ID
                        'mDocu.DMO_ESTADO = True
                        'mDocu.DMO_FEC_GRAB = Now
                        'mDocu.USU_ID = mProduccion.USU_ID
                        'mDocu.MarkAsAdded()

                        'repDocu.Maintenance(mDocu)

                        'Dim nDMD As New DocuMovimientoDetalle
                        'With nDMD
                        '    .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                        '    .DMO_ID = mDocu.DMO_ID
                        '    .ALM_ID = Parametro.GetById("Almmp").PAR_VALOR1  'Almacen materia prima
                        '    .ART_ID = "021413"
                        '    .DMD_CONTRAVALOR = mDt.Rows(0)(0) * (mProduccion.PRO_CONTEO_FINALIZADA - mProduccion.PRO_CARGA_FINALIZADA)
                        '    '.DMD_CANTIDAD = (((mProduccion.PRO_CONTEO_FINALIZADA - mProduccion.PRO_CARGA_FINALIZADA) * mPesoSeco) / 1000) / 1.1
                        '    .DMD_CANTIDAD = mDtRec.Rows(0)(0)
                        '    .DMD_PRECIO_UNITARIO = .DMD_CONTRAVALOR / .DMD_CANTIDAD
                        '    .DMD_IGV = 0
                        '    .DMD_GLOSA = "Ingreso Materia Prima Reciclado desde Secado o Cancha /" & mProduccion.PRO_ID.ToString & "/"
                        '    .MarkAsAdded()
                        'End With
                        'repDetaDocu.Maintenance(nDMD)

                        'If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                        '    'Movimientos de kardex
                        '    Dim mKar As New Kardex
                        '    mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                        '    mKar.ART_ID = nDMD.ART_ID
                        '    mKar.ALM_ID = nDMD.ALM_ID
                        '    mKar.DMD_ID = nDMD.DMD_ID
                        '    mKar.KAR_FECHA = mDocu.DMO_FECHA
                        '    If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                        '        mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                        '        mKar.KAR_SALIDA = 0
                        '        'mKar.KAR_SALDO =
                        '        mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                        '        mKar.KAR_SALIDA_VAL = 0
                        '        'mKar.KAR_SALDO_VAL =
                        '        'mKar.KAR_COSTO_PROMEDIO=
                        '    ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                        '        mKar.KAR_INGRESO = 0
                        '        mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                        '        'mKar.KAR_SALDO =
                        '        mKar.KAR_INGRESO_VAL = 0
                        '        mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                        '        'mKar.KAR_SALDO_VAL =
                        '        'mKar.KAR_COSTO_PROMEDIO=
                        '    End If
                        '    kardex.Maintenance(mKar)
                        'End If
                        ''kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)


                        '' ''''''''''''''''''''''Pasar a Spring Reciclado de MP
                        ''If BCControlConteo.Interfase_IngresoMP(mDocu.DMO_ID) = "0" Then
                        ''    Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                        ''End If
                        '' ''''''''''''''''''''''''''''''''''''

                    ElseIf mProduccion.PRO_FINALIZADA = True And mPesoSeco <= 0 Then

                        Err.Raise(&HFFFFFF01, "Error Provocado", "Falta Peso Seco en la Produccion Finalizada. " & mProduccion.PRO_ID.ToString)
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''

                    Scope.Complete()

                End Using
            Catch ex As Exception
                MsgBox(ex.Message)
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then

                End If
            End Try
        End Sub

        Public Function ProduccionGetById(ByVal PRO_ID As Integer) As BE.Produccion Implements IBCProduccion.ProduccionGetById
            Dim result As Produccion = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.GetById(PRO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ProduccionGrupoTrabajoQuery(ByVal PRO_ID As Integer, ByVal PRO_NRO_PRODUCCION As String, ByVal ART_ID_LADRILLO As String, ByVal ART_DESCRIPCION As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCProduccion.ProduccionGrupoTrabajoQuery

            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPProduccionSelectXML, PRO_ID, PRO_NRO_PRODUCCION, ART_ID_LADRILLO, ART_DESCRIPCION, fechaDesde, fechaHasta)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function ListaControlParadasPorDia(ByVal Fecha As Date) As String Implements IBCProduccion.ListaControlParadasPorDia
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaControlParadasPorDia", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaQuemaLadrillo(ByVal HOR_Id As Integer, ByVal Fecha As Date) As String Implements IBCProduccion.ListaQuemaLadrillo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaQuemaLadrillo", HOR_Id, Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDesHorXPuerta(ByVal Fecha As Date, ByVal HOR_Id As Integer) As String Implements IBCProduccion.ListaDesHorXPuerta
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDesHorXPuerta", Fecha, HOR_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ProduccionCargaConteoSelectXML(ByVal PRO_ID As Integer, ByVal PRO_NRO_PRODUCCION As String, ByVal ART_ID_LADRILLO As String, ByVal ART_DESCRIPCION As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal fechaConteoCarga As Date) As Object Implements IBCProduccion.ProduccionCargaConteoSelectXML
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPProduccionCargaConteoSelectXML, PRO_ID, PRO_NRO_PRODUCCION, ART_ID_LADRILLO, ART_DESCRIPCION, fechaDesde, fechaHasta, fechaConteoCarga)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ConsumoR500PorDia(ByVal Fecha As Date) As String Implements IBCProduccion.ConsumoR500PorDia
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spConsumoR500PorDia", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCombustibleHorno(ByVal HOR_Id As Integer, ByVal Mes As Integer, ByVal Anio As Integer) As String Implements IBCProduccion.ListaCombustibleHorno
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ListaCombustibleHorno(HOR_Id, Mes, Anio)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCombustibleXQuemador(ByVal HOR_Id As Integer, ByVal Mes As Integer, ByVal Anio As Integer) As String Implements IBCProduccion.ListaCombustibleXQuemador
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaCombustibleXQuemador", HOR_Id, Mes, Anio)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ProcesoTerminado(ByVal Fecha As Date) As String Implements IBCProduccion.ProcesoTerminado
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spProcesoTerminado", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function PesoQuema(ByVal Fecha As Date) As String Implements IBCProduccion.PesoQuema
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spPesoQuema", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaPesosYHumedadesPorDia(ByVal Fecha As Date) As String Implements IBCProduccion.ListaPesosYHumedadesPorDia
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaPesosYHumedadesPorDia", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteSalidaSecadero(ByVal FecIni As Date, ByVal FecFin As Date, ByVal SEC_ID As Integer) As String Implements IBCProduccion.ReporteSalidaSecadero
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ReporteSalidaSecadero(FecIni, FecFin, SEC_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteInspecciones(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PER_ID As String, ByVal LAD_ID As String, ByVal PRO_ID As Integer) As String Implements IBCProduccion.ReporteInspecciones
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spReporteInspecciones", FecIni, FecFin, PER_ID, LAD_ID, PRO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ConteoYCargaXProduccion(ByVal PRO_ID As Integer) As String Implements IBCProduccion.ConteoYCargaXProduccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spConteoCargaXPro", PRO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function FactoresProduccion(ByVal Fecha As Date) As String Implements IBCProduccion.FactoresProduccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spFactoresProduccion", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteFinalProduccion(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Nullable(Of Boolean)) As String Implements IBCProduccion.ReporteFinalProduccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ReporteFinalProduccion(FecIni, FecFin, PLA_ID, TPR_ID, EXT_ID, Finalizada)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaConsumoCombustibleXResponsable(ByVal FecIni As Date, ByVal FecFin As Date, ByVal HOR_Id As Nullable(Of Integer)) As Object Implements IBCProduccion.ListaConsumoCombustibleXResponsable
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaConsumoCombustibleXResponsable", FecIni, FecFin, HOR_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaProduccionParaSecadero() As String Implements IBCProduccion.ListaProduccionParaSecadero
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaProduccionParaSecadero")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaResumenControlParadasPorDia(ByVal Fecha As Date) As String Implements IBCProduccion.ListaResumenControlParadasPorDia
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaResumenControlParadasPorDia", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaVueltasHornoXAnio(ByVal HOR_Id As Integer, ByVal Anio As Integer) As String Implements IBCProduccion.ListaVueltasHornoXAnio
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaVueltasHornoXAnio", HOR_Id, Anio)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function FactoresProduccionSecadero(ByVal Fecha As Date) As String Implements IBCProduccion.FactoresProduccionSecadero
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spFactoresProduccionSecadero", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function FactoresProduccionResumen(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Nullable(Of Integer)) As String Implements IBCProduccion.FactoresProduccionResumen
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spFactoresProduccionResumen", FecIni, FecFin, PLA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SalidaVagonXDia(ByVal FechaIni As Date, ByVal FechaFin As Date) As String Implements IBCProduccion.SalidaVagonXDia
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spSalidaVagonXDia", FechaIni, FechaFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteFinalProduccionFinalizada(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Boolean) As String Implements IBCProduccion.ReporteFinalProduccionFinalizada
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ReporteFinalProduccionFinalizada(FecIni, FecFin, PLA_ID, TPR_ID, EXT_ID, Finalizada)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ProduccionGrupoTrabajoSinFechaQuery(ByVal PRO_ID As Integer, ByVal PRO_NRO_PRODUCCION As String, ByVal ART_ID_LADRILLO As String, ByVal ART_DESCRIPCION As String, ByVal fechaHasta As Date, ByVal seBuscaPorFecha As Boolean) As Object Implements IBCProduccion.ProduccionGrupoTrabajoSinFechaQuery
            Dim result As String = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SPProduccionSinFechaSelectXML, PRO_ID, PRO_NRO_PRODUCCION, ART_ID_LADRILLO, ART_DESCRIPCION, fechaHasta, seBuscaPorFecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result

        End Function

        Public Function ListaResumenParadas(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Pla_Id As Integer, ByVal Lad_Id As String, ByVal SinPrueba As Integer, ByVal Ext_Id As Integer) As String Implements IBCProduccion.ListaResumenParadas
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ListaResumenParadas(FecIni, FecFin, Pla_Id, Lad_Id, SinPrueba, Ext_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlParadasPorDiaForma1(ByVal Fecha As Date) As String Implements IBCProduccion.ListaControlParadasPorDiaForma1
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaControlParadasPorDiaForma1", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteFinalProduccionComparativo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?) As String Implements IBCProduccion.ReporteFinalProduccionComparativo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ReporteFinalProduccionComparativo(FecIni, FecFin, PLA_ID, TPR_ID, EXT_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteFinalProduccionDiario(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Nullable(Of Boolean), ByVal LAD_ID As String) As String Implements IBCProduccion.ReporteFinalProduccionDiario
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ReporteFinalProduccionDiario(FecIni, FecFin, PLA_ID, TPR_ID, EXT_ID, Finalizada, LAD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaResumenParadasForma1(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Pla_Id As Integer, ByVal Lad_Id As String, ByVal SinPrueba As Integer, ByVal Ext_Id As Integer) As String Implements IBCProduccion.ListaResumenParadasForma1
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ListaResumenParadasForma1(FecIni, FecFin, Pla_Id, Lad_Id, SinPrueba, Ext_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTnQuemadas(ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCProduccion.ListaTnQuemadas
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaTnQuemadas", FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTnProducidas(ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCProduccion.ListaTnProducidas
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaTnProducidas", FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSalidaHornoVsDespacho(ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCProduccion.ListaSalidaHornoVsDespacho
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaSalidaHornoVsDespacho", FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDistribucionCombustibleProduccion(ByVal FecIni As Date, ByVal FecFin As Date, ByVal EsFechaQuema As Boolean) As String Implements IBCProduccion.ListaDistribucionCombustibleProduccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDistribucionCombustibleProduccion", FecIni, FecFin, EsFechaQuema)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaReciclajeVentaLadrillox12Mes(ByVal Anio As Integer, ByVal Mes As Integer) As String Implements IBCProduccion.ListaReciclajeVentaLadrillox12Mes
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaReciclajeVentaLadrillox12Mes", Anio, Mes)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDistribucionEnergiaProduccion(ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCProduccion.ListaDistribucionEnergiaProduccion
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDistribucionEnergiaProduccion", FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteBrutoNetoMateriaPrima(ByVal FecIni As Date, ByVal FecFin As Date, ByVal PLA_ID As Integer?, ByVal TPR_ID As Integer?, ByVal EXT_ID As Integer?, ByVal Finalizada As Boolean?, ByVal LAD_ID As String) As String Implements IBCProduccion.ReporteBrutoNetoMateriaPrima
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spReporteBrutoNetoMateriaPrima", FecIni, FecFin, PLA_ID, TPR_ID, EXT_ID, Finalizada, LAD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaProduccionFecha(ByVal Fecha As Date, ByVal PLA_ID As Integer) As System.Collections.Generic.List(Of BE.Produccion) Implements IBCProduccion.ListaProduccionFecha
            Dim result As List(Of Produccion) = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.ListaProduccionFecha(Fecha, PLA_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaCantidadQuemadaXAnio(ByVal Anio As Integer) As System.Data.DataTable Implements IBCProduccion.ListaCantidadQuemadaXAnio
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spListaCantidadQuemadaXAnio", Anio)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaReciclajeVentaLadrilloXAnioSeparado(ByVal Anio As Integer) As System.Data.DataTable Implements IBCProduccion.ListaReciclajeVentaLadrilloXAnioSeparado
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spListaReciclajeVentaLadrilloXAnioSeparado", Anio)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTNQuemadaXAnio(ByVal Anio As Integer) As System.Data.DataTable Implements IBCProduccion.ListaTNQuemadaXAnio
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spListaTNQuemadaXAnio", Anio)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteSalidaHornoXAnio(ByVal Anio As Integer) As System.Data.DataTable Implements IBCProduccion.ReporteSalidaHornoXAnio
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spReporteSalidaHornoXAnio", Anio)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ProduccionxFecha() As System.Data.DataTable Implements IBCProduccion.ProduccionxFecha
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spProduccionxFecha")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_PrecioLadrilloCrudo(ByVal PRO_ID As Object) As System.Data.DataTable Implements IBCProduccion.Interfase_PrecioLadrilloCrudo
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spInterfase_PrecioLadrilloCrudo", PRO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_RecCrudoFinalProduccion(ByVal PRO_ID As Integer, ByVal UndRec As Integer) As System.Data.DataTable Implements IBCProduccion.Interfase_RecCrudoFinalProduccion
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spInterfase_RecCrudoFinalProduccion", PRO_ID, UndRec)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaProduccionVagones(ByVal Pro_Id As Integer?) As String Implements IBCProduccion.ListaProduccionVagones
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaProduccionVagones", Pro_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function VwProduccionByPro_Id(ByVal PRO_ID As Integer) As BE.vwReporteFinalProduccion2 Implements IBCProduccion.VwProduccionByPro_Id
            Dim result As vwReporteFinalProduccion2 = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                result = rep.VwProduccionByPro_Id(PRO_ID)
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
