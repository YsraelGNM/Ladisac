Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCDocuMovimiento
        Implements IBCDocuMovimiento

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ListaDocuMovimiento(ByVal Filtro As String) As DataSet Implements IBCDocuMovimiento.ListaDocuMovimiento
            Dim result As DataSet = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                result = rep.ListaDocuMovimiento(Filtro)
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try

            Return result

        End Function

        Public Function MantenimientoDocuMovimiento(ByVal mDocuMovimiento As BE.DocuMovimiento) As Integer Implements IBCDocuMovimiento.MantenimientoDocuMovimiento
            Dim CM As Boolean
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IDocuMovimientoDetalleRepositorio)()
                Dim kardex = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()
                Dim bctipodocumento = ContainerService.Resolve(Of BL.IBCTipoDocumento)()
                Dim ord = ContainerService.Resolve(Of DA.IOrdenRequerimientoDetalleRepositorio)()
                Dim ocd = ContainerService.Resolve(Of DA.IOrdenCompraDetalleRepositorio)()
                Dim trd = ContainerService.Resolve(Of DA.ITransformacionDetalleRepositorio)()
                Dim rcd = ContainerService.Resolve(Of DA.IRendicionCuentaDetalleRepositorio)()
                Dim pcd = ContainerService.Resolve(Of DA.IProcesoCompraDetalleRepositorio)()
                Dim mListaDocuMovimientoDetalle As List(Of DocuMovimientoDetalle)
                Dim mListaDocuMovimientoDetalleRemove As List(Of DocuMovimientoDetalle)
                Dim Parametro = ContainerService.Resolve(Of DA.IParametroRepositorio)()
                Dim CierreMes = ContainerService.Resolve(Of DA.ICierreAlmacenRepositorio)()

                Dim mNuevo As Boolean


                Dim ts1 As New TimeSpan(0, 20, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    Dim mCont As Integer = 1
                    If mDocuMovimiento.DTD_ID = "061" Or mDocuMovimiento.DTD_ID = "062" Then
                        If (mDocuMovimiento.ChangeTracker.State = ObjectState.Added) Then
                            mCont = 2
                        End If
                    End If


                    For mDoc As Integer = 1 To mCont

                        Dim mDDMM As New DocuMovimiento

                        If mDoc = 2 Then
                            mDocuMovimiento.MarkAsAdded()
                            If mDocuMovimiento.DTD_ID = "061" Then
                                mDocuMovimiento.DTD_ID = "062"
                                mDocuMovimiento.DMO_ID_REF = mDocuMovimiento.DMO_ID 'Colocamos el DMO_ID del primer documento
                                mDocuMovimiento.DetalleTipoDocumentos = bctipodocumento.TipoDocumentoGetById("062")
                            ElseIf mDocuMovimiento.DTD_ID = "062" Then
                                mDocuMovimiento.DTD_ID = "061"
                                mDocuMovimiento.DMO_ID_REF = mDocuMovimiento.DMO_ID 'Colocamos el DMO_ID del primer documento
                                mDocuMovimiento.DetalleTipoDocumentos = bctipodocumento.TipoDocumentoGetById("061")
                            End If
                        End If

                        mListaDocuMovimientoDetalleRemove = New List(Of DocuMovimientoDetalle)
                        If (mDocuMovimiento.ChangeTracker.State = ObjectState.Added) Then
                            mDocuMovimiento.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                            mDocuMovimiento.FecOri = mDocuMovimiento.DMO_FECHA
                            mNuevo = True
                        ElseIf (mDocuMovimiento.ChangeTracker.State = ObjectState.Modified) Then
                            mNuevo = False
                            'mListaDocuMovimientoDetalleRemove = New List(Of DocuMovimientoDetalle)
                            For Each mRemov In mDocuMovimiento.DocuMovimientoDetalle
                                If mRemov.ChangeTracker.State = ObjectState.Deleted Then
                                    Dim mDMD_Remove As New DocuMovimientoDetalle
                                    mDMD_Remove = mRemov.Clone
                                    mListaDocuMovimientoDetalleRemove.Add(mDMD_Remove)
                                End If
                            Next

                        ElseIf (mDocuMovimiento.ChangeTracker.State = ObjectState.Deleted) Then
                            'mListaDocuMovimientoDetalleRemove = New List(Of DocuMovimientoDetalle)
                            For Each mRemov In mDocuMovimiento.ChangeTracker.ObjectsRemovedFromCollectionProperties
                                For Each mRem In mRemov.Value
                                    Dim mDMD_Remove As New DocuMovimientoDetalle
                                    mDMD_Remove = CType(mRem, DocuMovimientoDetalle).Clone
                                    mListaDocuMovimientoDetalleRemove.Add(mDMD_Remove)
                                Next
                            Next
                        End If

                        If mDoc = 1 Then
                            mListaDocuMovimientoDetalle = New List(Of DocuMovimientoDetalle)
                            For Each mObj In mDocuMovimiento.DocuMovimientoDetalle
                                Dim mDocuMovimientoDetalle As New DocuMovimientoDetalle
                                mDocuMovimientoDetalle = mObj.Clone
                                mListaDocuMovimientoDetalle.Add(mDocuMovimientoDetalle)
                            Next
                            mDocuMovimiento.ChangeTracker.ChangeTrackingEnabled = False
                            mDDMM = mDocuMovimiento.Clone
                            mDocuMovimiento.DocuMovimientoDetalle = Nothing
                            mDocuMovimiento.Personas = Nothing
                            mDocuMovimiento.DetalleTipoDocumentos = Nothing
                            mDocuMovimiento.Moneda = Nothing
                            mDocuMovimiento.ChangeTracker.ChangeTrackingEnabled = True
                        Else
                            mDocuMovimiento.ChangeTracker.ChangeTrackingEnabled = False
                            mDDMM = mDocuMovimiento.Clone
                            mDocuMovimiento.DocuMovimientoDetalle = Nothing
                            mDocuMovimiento.Personas = Nothing
                            mDocuMovimiento.DetalleTipoDocumentos = Nothing
                            mDocuMovimiento.Moneda = Nothing
                            mDocuMovimiento.ChangeTracker.ChangeTrackingEnabled = True
                            For Each mItem In mListaDocuMovimientoDetalle
                                mItem.ALM_ID = mItem.ALM_ID_TRANSFERENCIA
                                mItem.DMD_ID_REF = mItem.DMD_ID  'Colocamos el DMD_ID del primer articulo
                                mItem.ORD_ID = Nothing
                                mItem.MarkAsAdded()
                            Next
                        End If

                        mDocuMovimiento.PER_ID_PROVEEDOR = mDDMM.PER_ID_PROVEEDOR
                        mDocuMovimiento.DTD_ID = mDDMM.DTD_ID
                        mDocuMovimiento.TDO_ID = mDDMM.TDO_ID
                        mDocuMovimiento.CCT_ID = mDDMM.CCT_ID
                        mDocuMovimiento.MON_ID = mDDMM.MON_ID
                        mDocuMovimiento.ORR_ID = mDDMM.ORR_ID

                        rep.Maintenance(mDocuMovimiento)

                        mDocuMovimiento.DetalleTipoDocumentos = mDDMM.DetalleTipoDocumentos

                        For Each mItem In mListaDocuMovimientoDetalle
                            If mItem.Kardex.Count > 0 Then
                                mItem.Kardex(0).MarkAsDeleted()
                                kardex.Maintenance(mItem.Kardex(0))
                            End If
                        Next

                        For Each mItem In mListaDocuMovimientoDetalle
                            'verificar cierre mes
                            If CierreMes.GetByCierre(mDocuMovimiento.DMO_FECHA.Value.Year, mDocuMovimiento.DMO_FECHA.Value.Month, mItem.Alm_Ori) Then
                                CM = True
                                Err.Raise(&HFFFFFF01, "Error Provocado", "Almacen Cerrado.")
                            End If
                            '''''''''''''''''''''''''''''''
                            If (mItem.ChangeTracker.State = ObjectState.Added) Then
                                mItem.DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                                mItem.DMO_ID = mDocuMovimiento.DMO_ID
                                'verificar cierre mes
                                If CierreMes.GetByCierre(mDocuMovimiento.DMO_FECHA.Value.Year, mDocuMovimiento.DMO_FECHA.Value.Month, mItem.ALM_ID) Then
                                    CM = True
                                    Err.Raise(&HFFFFFF01, "Error Provocado", "Almacen Cerrado.")
                                End If
                                '''''''''''''''''''''''''''''''
                            ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then
                                'mListaDocuMovimientoDetalleRemove = New List(Of DocuMovimientoDetalle)
                                Dim mDMD_Remove As New DocuMovimientoDetalle
                                If mItem.ALM_ID <> mItem.Alm_Ori Or mItem.ART_ID <> mItem.Art_Ori Then
                                    'verificar cierre mes ALM original
                                    If CierreMes.GetByCierre(mDocuMovimiento.DMO_FECHA.Value.Year, mDocuMovimiento.DMO_FECHA.Value.Month, mItem.Alm_Ori) Then
                                        CM = True
                                        Err.Raise(&HFFFFFF01, "Error Provocado", "Almacen Cerrado.")
                                    End If
                                    'verificar cierre mes ALM nuevo
                                    If CierreMes.GetByCierre(mDocuMovimiento.DMO_FECHA.Value.Year, mDocuMovimiento.DMO_FECHA.Value.Month, mItem.ALM_ID) Then
                                        CM = True
                                        Err.Raise(&HFFFFFF01, "Error Provocado", "Almacen Cerrado.")
                                    End If
                                    mDMD_Remove = mItem.Clone
                                    mListaDocuMovimientoDetalleRemove.Add(mDMD_Remove)
                                End If
                                'If mItem.ChangeTracker.OriginalValues.Count > 0 Then
                                '    mDMD_Remove = mItem.Clone
                                '    For Each mRemov In mItem.ChangeTracker.OriginalValues
                                '        If mRemov.Key = "ALM_ID" Then
                                '            mDMD_Remove.ALM_ID = mRemov.Value
                                '            mDMD_Remove.Alm_Ori = mRemov.Value
                                '            'verificar cierre mes ALM original
                                '            If CierreMes.GetByCierre(mDocuMovimiento.DMO_FECHA.Value.Year, mDocuMovimiento.DMO_FECHA.Value.Month, mItem.Alm_Ori) Then
                                '                CM = True
                                '                Err.Raise(&HFFFFFF01, "Error Provocado", "Almacen Cerrado.")
                                '            End If
                                '            '''''''''''''''''''''''''''''''
                                '        End If
                                '        If mRemov.Key = "ART_ID" Then
                                '            mDMD_Remove.ART_ID = mRemov.Value
                                '            mDMD_Remove.Art_Ori = mRemov.Value
                                '        End If
                                '    Next
                                '    If Not mDMD_Remove.Alm_Ori > 0 Then
                                '        mDMD_Remove.Alm_Ori = mDMD_Remove.ALM_ID
                                '    End If
                                '    If mDMD_Remove.Art_Ori Is Nothing Then
                                '        mDMD_Remove.Art_Ori = mDMD_Remove.ART_ID
                                '    End If
                                '    'verificar cierre mes
                                '    If CierreMes.GetByCierre(mDocuMovimiento.DMO_FECHA.Value.Year, mDocuMovimiento.DMO_FECHA.Value.Month, mItem.ALM_ID) Then
                                '        CM = True
                                '        Err.Raise(&HFFFFFF01, "Error Provocado", "Almacen Cerrado.")
                                '    End If
                                '    '''''''''''''''''''''''''''''''
                                '    mListaDocuMovimientoDetalleRemove.Add(mDMD_Remove)
                                'End If
                            ElseIf (mItem.ChangeTracker.State = ObjectState.Deleted) Then
                                'mListaDocuMovimientoDetalleRemove = New List(Of DocuMovimientoDetalle)
                                'For Each mRemov In mItem.ChangeTracker.OriginalValues
                                '    If mRemov.Key = "ART_ID" Then
                                '        Dim mDMD_Remove As New DocuMovimientoDetalle
                                '        mDMD_Remove = mItem.Clone
                                '        mListaDocuMovimientoDetalleRemove.Add(mDMD_Remove)
                                '    End If
                                'Next
                                'verificar cierre mes
                                If CierreMes.GetByCierre(mDocuMovimiento.DMO_FECHA.Value.Year, mDocuMovimiento.DMO_FECHA.Value.Month, mItem.Alm_Ori) Then
                                    CM = True
                                    Err.Raise(&HFFFFFF01, "Error Provocado", "Almacen Cerrado.")
                                End If
                                '''''''''''''''''''''''''''''''
                            End If


                            mItem.ChangeTracker.ChangeTrackingEnabled = False
                            mItem.Kardex = Nothing
                            mItem.ChangeTracker.ChangeTrackingEnabled = True

                            repDeta.Maintenance(mItem)

                            If mNuevo Then
                                If mItem.ORD_ID > 0 And Parametro.GetById("UpDateORCant").PAR_VALOR2.Contains("/" & mDocuMovimiento.DTD_ID & "/") And mItem.EsDevolucion = False Then
                                    Dim mOrd As New OrdenRequerimientoDetalle
                                    mOrd = ord.GetById(mItem.ORD_ID)
                                    mOrd.ORD_CANTIDAD_ATENDIDA = mOrd.ORD_CANTIDAD_ATENDIDA + mItem.DMD_CANTIDAD
                                    mOrd.ORD_ESTADO_COMPRA = Nothing
                                    mOrd.ORD_OBS_COMPRA = Nothing
                                    mOrd.ORD_CANTIDAD_COMPRA = Nothing
                                    mOrd.MarkAsModified()
                                    ord.Maintenance(mOrd)
                                End If
                                If mItem.OCD_ID > 0 Then
                                    Dim mOcd As New OrdenCompraDetalle
                                    mOcd = ocd.GetById(mItem.OCD_ID)
                                    mOcd.OCD_CANTIDAD_INGRESADA = mOcd.OCD_CANTIDAD_INGRESADA + mItem.DMD_CANTIDAD
                                    If mOcd.PCD_ID IsNot Nothing Then
                                        Dim mPcd As New ProcesoCompraDetalle
                                        mPcd = pcd.GetById(mOcd.PCD_ID)
                                        mPcd.PCD_CANT_COMPRADA = mPcd.PCD_CANT_COMPRADA + mOcd.OCD_CANTIDAD
                                        mPcd.MarkAsModified()
                                        pcd.Maintenance(mPcd)
                                    End If
                                    mOcd.MarkAsModified()
                                    ocd.Maintenance(mOcd)

                                    If mItem.ORD_ID IsNot Nothing Then
                                        Dim mOrd As New OrdenRequerimientoDetalle
                                        mOrd = ord.GetById(mItem.ORD_ID)
                                        mOrd.ORD_ESTADO_COMPRA = Nothing
                                        mOrd.ORD_OBS_COMPRA = Nothing
                                        mOrd.ORD_CANTIDAD_COMPRA = Nothing
                                        mOrd.MarkAsModified()
                                        ord.Maintenance(mOrd)
                                    End If

                                End If
                                If mItem.TRD_ID > 0 Then
                                    Dim mTrd As New TransformacionDetalle
                                    mTrd = trd.GetById(mItem.TRD_ID)
                                    mTrd.TRD_CANTIDAD_ATENDIDA = mTrd.TRD_CANTIDAD_ATENDIDA + mItem.DMD_CANTIDAD
                                    mTrd.MarkAsModified()
                                    trd.Maintenance(mTrd)
                                End If
                                If mItem.RCD_ID > 0 Then
                                    Dim mRcd As New RendicionCuentaDetalle
                                    mRcd = rcd.GetById(mItem.RCD_ID)
                                    mRcd.DMD_ID = mItem.DMD_ID
                                    Dim mPcd As New ProcesoCompraDetalle
                                    mPcd = pcd.GetById(mRcd.PCD_ID)
                                    mPcd.PCD_CANT_COMPRADA = mPcd.PCD_CANT_COMPRADA + mRcd.RCD_CANTIDAD
                                    mPcd.MarkAsModified()
                                    mRcd.MarkAsModified()
                                    rcd.Maintenance(mRcd)
                                    pcd.Maintenance(mPcd)
                                End If
                            End If

                            If mDocuMovimiento.DOCU_AFECTA_KARDEX And Not mItem.ART_ID Is Nothing Then
                                If mDocuMovimiento.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                                    'Movimientos de kardex
                                    Dim mKar As New Kardex
                                    mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                                    mKar.ART_ID = mItem.ART_ID
                                    mKar.ALM_ID = mItem.ALM_ID
                                    mKar.DMD_ID = mItem.DMD_ID
                                    mKar.KAR_FECHA = mDocuMovimiento.DMO_FECHA
                                    If mDocuMovimiento.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                                        mKar.KAR_INGRESO = mItem.DMD_CANTIDAD
                                        mKar.KAR_SALIDA = 0
                                        'mKar.KAR_SALDO =
                                        mKar.KAR_INGRESO_VAL = mItem.DMD_CONTRAVALOR
                                        mKar.KAR_SALIDA_VAL = 0
                                        'mKar.KAR_SALDO_VAL =
                                        'mKar.KAR_COSTO_PROMEDIO=
                                    ElseIf mDocuMovimiento.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                                        mKar.KAR_INGRESO = 0
                                        mKar.KAR_SALIDA = mItem.DMD_CANTIDAD
                                        'mKar.KAR_SALDO =
                                        mKar.KAR_INGRESO_VAL = 0
                                        mKar.KAR_SALIDA_VAL = mItem.DMD_CONTRAVALOR
                                        'mKar.KAR_SALDO_VAL =
                                        'mKar.KAR_COSTO_PROMEDIO=
                                    End If
                                    kardex.Maintenance(mKar)
                                End If

                            End If
                            Dim mFec As Date
                            If mDocuMovimiento.DMO_FECHA > mDocuMovimiento.FecOri Then mFec = mDocuMovimiento.FecOri Else mFec = mDocuMovimiento.DMO_FECHA
                            If mItem.ART_ID IsNot Nothing Then
                                kardex.RehacerKardex(mItem.ART_ID, mItem.ALM_ID, mFec)
                            Else
                                kardex.RehacerKardex(mItem.Art_Ori, mItem.Alm_Ori, mFec)
                            End If
                        Next
                    Next

                    If mDocuMovimiento.TFO_ID > 0 Then
                        ActualizarIngresoTransformacion(mDocuMovimiento.TFO_ID)
                    End If
                    If mListaDocuMovimientoDetalleRemove IsNot Nothing Then
                        If mListaDocuMovimientoDetalleRemove.Count > 0 Then
                            For Each mItem In mListaDocuMovimientoDetalleRemove.ToList
                                Dim mFec As Date
                                If mDocuMovimiento.DMO_FECHA > mDocuMovimiento.FecOri Then mFec = mDocuMovimiento.FecOri Else mFec = mDocuMovimiento.DMO_FECHA
                                kardex.RehacerKardex(mItem.Art_Ori, mItem.Alm_Ori, mFec)
                            Next
                        End If
                    End If

                    Scope.Complete()
                    Return 1
                End Using
            Catch ex As Exception
                mDocuMovimiento = Nothing
                Dim msm As String
                msm = ex.Message.ToString
                If ex.InnerException IsNot Nothing Then msm = msm & " /// " & ex.InnerException.Message
                'verificar cierre mes
                If CM Then
                    MsgBox("El Mes y/o Almacen estan cerrado.")
                Else
                    MsgBox(msm, , "Error")
                End If
                '''''''''''''''''''''''''''''''

                'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                '    Throw
                'End If
                Return 0
            End Try
        End Function

        Public Function DocuMovimientoGetById(ByVal DMO_ID As Integer) As BE.DocuMovimiento Implements IBCDocuMovimiento.DocuMovimientoGetById
            Dim result As DocuMovimiento = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                result = rep.GetById(DMO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function TCCompraDia(ByVal MON_ID As String, ByVal Fecha As Date) As Decimal Implements IBCDocuMovimiento.TCCompraDia
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spTCCompraDia", MON_ID, Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSalidaXReq() As String Implements IBCDocuMovimiento.ListaSalidaXReq
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaSalidaXReq", "056")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListadoIngresoxProveedor(ByVal PER_ID_PROVEEDOR As String, ByVal ART_ID As String, ByVal FAM_ID As String, ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As String Implements IBCDocuMovimiento.ListadoIngresoxProveedor
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListadoIngresoxProveedor", PER_ID_PROVEEDOR, ART_ID, FAM_ID, FECHA_INI, FECHA_FIN)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaGuiasFacturadas(ByVal ALM_ID As String, ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As String Implements IBCDocuMovimiento.ListaGuiasFacturadas
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaGuiasFacturadas", ALM_ID, FECHA_INI, FECHA_FIN)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DocuMovimientoDetalleGetById(ByVal DMD_ID As Integer) As BE.DocuMovimientoDetalle Implements IBCDocuMovimiento.DocuMovimientoDetalleGetById
            Dim result As DocuMovimientoDetalle = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuMovimientoDetalleRepositorio)()
                result = rep.GetById(DMD_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSalidaXReqXDocu(ByVal DMO_ID As Integer?) As System.Data.DataSet Implements IBCDocuMovimiento.ListaSalidaXReqXDocu
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                result = rep.ListaSalidaXReqXDocu(DMO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaLiquidacionMateriaPrima(ByVal FECHA_INI As Date, ByVal FECHA_FIN As Date) As String Implements IBCDocuMovimiento.ListaLiquidacionMateriaPrima
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaLiquidacionMateriaPrima", FECHA_INI, FECHA_FIN)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub ActualizarIngresoTransformacion(ByVal TFO_ID As Integer?) Implements IBCDocuMovimiento.ActualizarIngresoTransformacion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                rep.ActualizarIngresoTransformacion(TFO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaIngresoXFacXDocu(ByVal DMO_ID As Integer?, ByVal ART_ID As String) As System.Data.DataSet Implements IBCDocuMovimiento.ListaIngresoXFacXDocu
            Dim result As New DataSet
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                result = rep.ListaIngresoXFacXDocu(DMO_ID, ART_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_IngresoAlmacenProductoTerminado(ByVal DMO_ID As Integer) As String Implements IBCDocuMovimiento.Interfase_IngresoAlmacenProductoTerminado
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spInterfase_IngresoAlmacenProductoTerminado", DMO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_PasarSpring(ByVal Fecha As Date, ByVal TipoTransaccion As String, ByVal Item As String) As String Implements IBCDocuMovimiento.Interfase_PasarSpring
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spInterfase_PasarSpring", Fecha, TipoTransaccion, Item)
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
