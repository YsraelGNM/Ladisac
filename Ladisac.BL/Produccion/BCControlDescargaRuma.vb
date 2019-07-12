Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlDescargaRuma
        Implements IBCControlDescargaRuma

        <Dependency()> _
        Public Property ContainerService As IUnityContainer


        Public Function ControlDescargaRumaGetById(ByVal DRU_ID As Integer) As BE.ControlDescargaRuma Implements IBCControlDescargaRuma.ControlDescargaRumaGetById
            Dim result As ControlDescargaRuma = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlDescargaRumaRepositorio)()
                result = rep.GetById(DRU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlDescargaRuma() As String Implements IBCControlDescargaRuma.ListaControlDescargaRuma
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlDescargaRumaRepositorio)()
                result = rep.ListaControlDescargaRuma
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlDescargaRuma(ByVal mControlDescargaRuma As BE.ControlDescargaRuma) Implements IBCControlDescargaRuma.MantenimientoControlDescargaRuma
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlDescargaRumaRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IControlDescargaRumaDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Dim repDocu = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                Dim repDetaDocu = ContainerService.Resolve(Of DA.IDocuMovimientoDetalleRepositorio)()

                Dim repDetalleTipoDocumento = ContainerService.Resolve(Of DA.IDetalleTipoDocumentoRepositorio)()
                Dim repParametro = ContainerService.Resolve(Of DA.IParametroRepositorio)()

                Dim kardex = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                Dim KardexLote = ContainerService.Resolve(Of DA.IKardexLoteRepositorio)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlDescargaRuma.ChangeTracker.State = ObjectState.Added) Then
                        mControlDescargaRuma.DRU_ID = bcherramientas.Get_Id("ControlDescargaRuma")
                    ElseIf (mControlDescargaRuma.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mLista As New List(Of ControlDescargaRumaDetalle)
                    For Each mObj In mControlDescargaRuma.ControlDescargaRumaDetalle
                        Dim mDet As New ControlDescargaRumaDetalle
                        mDet = mObj.Clone
                        mLista.Add(mDet)
                    Next
                    mControlDescargaRuma.ChangeTracker.ChangeTrackingEnabled = False
                    mControlDescargaRuma.ControlDescargaRumaDetalle = Nothing
                    mControlDescargaRuma.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mControlDescargaRuma)

                    Dim mLista1 As New List(Of ControlDescargaRumaDetalle)
                    For Each mItem In mLista
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DRD_ID = bcherramientas.Get_Id("ControlDescargaRumaDetalle")
                            mItem.DRU_ID = mControlDescargaRuma.DRU_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If

                        Dim mDet1 As New ControlDescargaRumaDetalle
                        mDet1 = mItem.Clone
                        mLista1.Add(mDet1)

                        mItem.ChangeTracker.ChangeTrackingEnabled = False
                        mItem.ControlCarga = Nothing
                        mItem.ChangeTracker.ChangeTrackingEnabled = True
                        mItem.CAR_ID = mDet1.CAR_ID
                        repDeta.Maintenance(mItem)
                    Next


                    ' ''''''''''''''''' INGRESO ALMACEN
                    'Dim mListDet As New List(Of DocuMovimientoDetalle)
                    'Dim mDocu As New DocuMovimiento

                    'mDocu = repDocu.GetByIdDRU(mControlDescargaRuma.DRU_ID) 'Para que borre el documento antes de guardarlo
                    'If mDocu IsNot Nothing Then
                    '    For Each mitem In mDocu.DocuMovimientoDetalle
                    '        If mitem.Kardex.Count > 0 Then mitem.Kardex(0).MarkAsDeleted()
                    '        mitem.MarkAsDeleted()
                    '    Next
                    '    mDocu.MarkAsDeleted()
                    '    repDocu.Maintenance(mDocu)
                    'End If

                    'mDocu = New DocuMovimiento

                    'mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    'mDocu.DMO_FECHA = mControlDescargaRuma.DRU_FECHA
                    'mDocu.DTD_ID = "015"
                    'mDocu.TDO_ID = "006" 'Nota de Ingreso
                    'mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")
                    'mDocu.DMO_SERIE = "40"
                    'mDocu.DMO_NRO = mControlDescargaRuma.DRU_ID
                    'mDocu.DMO_FECHA_DOCUMENTO = mControlDescargaRuma.DRU_FECHA
                    'mDocu.DRU_ID = mControlDescargaRuma.DRU_ID
                    'mDocu.MON_ID = "001" 'Soles
                    'mDocu.DOCU_AFECTA_KARDEX = True
                    'mDocu.DMO_ESTADO = True
                    'mDocu.DMO_FEC_GRAB = Now
                    'mDocu.USU_ID = mControlDescargaRuma.USU_ID
                    'mDocu.MarkAsAdded()

                    'repDocu.Maintenance(mDocu)

                    'Dim ResumenPrimera = From Lis In mLista1 Group By Lis.ControlCarga.Produccion.Ladrillo.ART_ID_LADRILLO Into Total = Sum(Lis.DRD_CANT_NETA / 1000) Select ART_ID_LADRILLO, Total

                    'For Each mItem In ResumenPrimera.ToList
                    '    Dim nDMD As New DocuMovimientoDetalle
                    '    With nDMD
                    '        .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    '        .DMO_ID = mDocu.DMO_ID
                    '        .ALM_ID = repParametro.GetById("AlmLadrillo").PAR_VALOR1 'Almacen Producto Terminado
                    '        .ART_ID = mItem.ART_ID_LADRILLO
                    '        .DMD_CANTIDAD = mItem.Total
                    '        .DMD_PRECIO_UNITARIO = 1
                    '        .DMD_IGV = 0
                    '        .DMD_CONTRAVALOR = mItem.Total * 1
                    '        .DMD_GLOSA = "Ingreso Primera"
                    '        .MarkAsAdded()
                    '    End With
                    '    repDetaDocu.Maintenance(nDMD)
                    '    mListDet.Add(nDMD)
                    'Next


                    'Dim ResumenSegunda = From Lis In mLista1 Group By Lis.ControlCarga.Produccion.Ladrillo.ART_ID_LADRILLO Into Total = Sum((Lis.DRD_RAJADOS + Lis.DRD_BLANCOS) / 1000) Select ART_ID_LADRILLO, Total

                    'For Each mItem In ResumenSegunda.ToList
                    '    Dim nDMD As New DocuMovimientoDetalle
                    '    With nDMD
                    '        .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    '        .DMO_ID = mDocu.DMO_ID
                    '        .ALM_ID = repParametro.GetById("AlmLadrillo").PAR_VALOR1 'Almacen Producto Terminado
                    '        .ART_ID = bcherramientas.Get_CodSegundaLadrillo(mItem.ART_ID_LADRILLO)
                    '        .DMD_CANTIDAD = mItem.Total
                    '        .DMD_PRECIO_UNITARIO = 1
                    '        .DMD_IGV = 0
                    '        .DMD_CONTRAVALOR = mItem.Total * 1
                    '        .DMD_GLOSA = "Ingreso Segunda"
                    '        .MarkAsAdded()
                    '    End With
                    '    repDetaDocu.Maintenance(nDMD)
                    '    mListDet.Add(nDMD)
                    'Next

                    'For Each mItem In mListDet
                    '    If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    '        'Movimientos de kardex
                    '        Dim mKar As New Kardex
                    '        mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    '        mKar.ART_ID = mItem.ART_ID
                    '        mKar.ALM_ID = mItem.ALM_ID
                    '        mKar.DMD_ID = mItem.DMD_ID
                    '        mKar.KAR_FECHA = mDocu.DMO_FECHA
                    '        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    '            mKar.KAR_INGRESO = mItem.DMD_CANTIDAD
                    '            mKar.KAR_SALIDA = 0
                    '            'mKar.KAR_SALDO =
                    '            mKar.KAR_INGRESO_VAL = mItem.DMD_CONTRAVALOR
                    '            mKar.KAR_SALIDA_VAL = 0
                    '            'mKar.KAR_SALDO_VAL =
                    '            'mKar.KAR_COSTO_PROMEDIO=
                    '        ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    '            mKar.KAR_INGRESO = 0
                    '            mKar.KAR_SALIDA = mItem.DMD_CANTIDAD
                    '            'mKar.KAR_SALDO =
                    '            mKar.KAR_INGRESO_VAL = 0
                    '            mKar.KAR_SALIDA_VAL = mItem.DMD_CONTRAVALOR
                    '            'mKar.KAR_SALDO_VAL =
                    '            'mKar.KAR_COSTO_PROMEDIO=
                    '        End If
                    '        kardex.Maintenance(mKar)
                    '    End If
                    '    If mDocu.DMO_FECHA > "15/03/2014" Then kardex.RehacerKardex(mItem.ART_ID, mItem.ALM_ID, mDocu.DMO_FECHA) 'Momentaneo mientras se ajusta el ladrillo
                    'Next


                    Dim colKardexLotes As List(Of KardexLote)
                    colKardexLotes = KardexLote.GetByIdDRU_ID(mControlDescargaRuma.DRU_ID)
                    For Each mKL In colKardexLotes
                        mKL.MarkAsDeleted()
                        KardexLote.Maintenance(mKL)
                    Next

                    Dim ResumenPrimera = From Lis In mLista1 Group By Lis.ControlCarga.Produccion.Ladrillo.ART_ID_LADRILLO, Lis.ControlCarga.Produccion.PRO_ID Into Total = Sum(Lis.DRD_CANT_NETA / 1000) Select ART_ID_LADRILLO, PRO_ID, Total
                    For Each mItem In ResumenPrimera.ToList
                        'Movimientos de KardexLote
                        Dim mKal As New KardexLote
                        mKal.KAL_ID = bcherramientas.Get_Id("KardexLote")
                        mKal.ART_ID = mItem.ART_ID_LADRILLO
                        mKal.ALM_ID = repParametro.GetById("AlmLadrillo").PAR_VALOR1 'Almacen Producto Terminado
                        'mKal.DMD_ID = mItem.DMD_ID
                        mKal.DRU_ID = mControlDescargaRuma.DRU_ID
                        'mKal.TDO_ID
                        'mKal.DTD_ID
                        'mKal.DES_SERIE
                        'mKal.DES_NUMERO
                        mKal.PRO_ID = mItem.PRO_ID
                        mKal.KAL_FECHA = mControlDescargaRuma.DRU_FECHA
                        mKal.KAL_INGRESO = mItem.Total
                        mKal.KAL_SALIDA = 0
                        mKal.KAL_SALDO = mItem.Total
                        mKal.KAL_INGRESO_VAL = mItem.Total * 1000
                        mKal.KAL_SALIDA_VAL = 0
                        mKal.KAL_SALDO_VAL = mItem.Total * 1000
                        mKal.KAL_COSTO_PROMEDIO = 1
                        mKal.MarkAsAdded()
                        KardexLote.Maintenance(mKal)
                    Next
                    Dim ResumenSegunda = From Lis In mLista1 Where (Lis.DRD_RAJADOS + Lis.DRD_BLANCOS) > 0 Group By Lis.ControlCarga.Produccion.Ladrillo.ART_ID_LADRILLO, Lis.ControlCarga.Produccion.PRO_ID Into Total = Sum((Lis.DRD_RAJADOS + Lis.DRD_BLANCOS) / 1000) Select ART_ID_LADRILLO, PRO_ID, Total
                    For Each mItem In ResumenSegunda.ToList
                        'Movimientos de KardexLote
                        Dim mKal As New KardexLote
                        mKal.KAL_ID = bcherramientas.Get_Id("KardexLote")
                        mKal.ART_ID = bcherramientas.Get_CodSegundaLadrillo(mItem.ART_ID_LADRILLO)
                        mKal.ALM_ID = repParametro.GetById("AlmLadrillo").PAR_VALOR1 'Almacen Producto Terminado
                        'mKal.DMD_ID = mItem.DMD_ID
                        mKal.DRU_ID = mControlDescargaRuma.DRU_ID
                        'mKal.TDO_ID
                        'mKal.DTD_ID
                        'mKal.DES_SERIE
                        'mKal.DES_NUMERO
                        mKal.PRO_ID = mItem.PRO_ID
                        mKal.KAL_FECHA = mControlDescargaRuma.DRU_FECHA
                        mKal.KAL_INGRESO = mItem.Total
                        mKal.KAL_SALIDA = 0
                        mKal.KAL_SALDO = mItem.Total
                        mKal.KAL_INGRESO_VAL = mItem.Total * 1000
                        mKal.KAL_SALIDA_VAL = 0
                        mKal.KAL_SALDO_VAL = mItem.Total * 1000
                        mKal.KAL_COSTO_PROMEDIO = 1
                        mKal.MarkAsAdded()
                        KardexLote.Maintenance(mKal)
                    Next

                    ' ''''''''''''''''''''''Pasar a Spring
                    'If spInterfase_DescargaHorno(mControlDescargaRuma.DRU_ID) = "0" Then
                    '    Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                    'End If
                    ' ''''''''''''''''''''''''''''''''''''

                    Scope.Complete()

                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaDesHorProcesar() As String Implements IBCControlDescargaRuma.ListaDesHorProcesar
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDesHorProcesar")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaReciclajeVentaLadrillo(ByVal Fecha As Date) As String Implements IBCControlDescargaRuma.ListaReciclajeVentaLadrillo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaReciclajeVentaLadrillo", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaReciclajeVentaLadrilloDespacho(ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCControlDescargaRuma.ListaReciclajeVentaLadrilloDespacho
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaReciclajeVentaLadrilloDespacho", FecIni, FecFin)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaReciclajeDespachoLadrillo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alm_Id As Integer?) As String Implements IBCControlDescargaRuma.ListaReciclajeDespachoLadrillo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaReciclajeDespachoLadrillo", FecIni, FecFin, Alm_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spInterfase_DescargaHorno(ByVal DRU_ID As Integer) As String Implements IBCControlDescargaRuma.spInterfase_DescargaHorno
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spInterfase_DescargaHorno", DRU_ID)
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
