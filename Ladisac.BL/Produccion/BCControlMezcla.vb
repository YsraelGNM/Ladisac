Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCControlMezcla
        Implements IBCControlMezcla

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlMezclaGetById(ByVal CME_ID As Integer) As BE.ControlMezcla Implements IBCControlMezcla.ControlMezclaGetById
            Dim result As ControlMezcla = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlMezclaRepositorio)()
                result = rep.GetById(CME_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlMezcla() As String Implements IBCControlMezcla.ListaControlMezcla
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlMezclaRepositorio)()
                result = rep.ListaControlMezcla
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlMezcla(ByVal mControlMezcla As BE.ControlMezcla) Implements IBCControlMezcla.MantenimientoControlMezcla
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlMezclaRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IControlMezclaRecetaDetalleRepositorio)()
                Dim repDeta2 = ContainerService.Resolve(Of DA.IControlMezclaMezclaDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Dim repProd = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                Dim repDocu = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                Dim repDetaDocu = ContainerService.Resolve(Of DA.IDocuMovimientoDetalleRepositorio)()
                Dim repDetalleTipoDocumento = ContainerService.Resolve(Of DA.IDetalleTipoDocumentoRepositorio)()
                Dim kardex = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                Dim Parametro = ContainerService.Resolve(Of DA.IParametroRepositorio)()


                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlMezcla.ChangeTracker.State = ObjectState.Added) Then
                        mControlMezcla.CME_ID = bcherramientas.Get_Id("ControlMezcla")
                    ElseIf (mControlMezcla.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mLista As New List(Of ControlMezclaRecetaDetalle)
                    For Each mObj In mControlMezcla.ControlMezclaRecetaDetalle
                        Dim mDet As New ControlMezclaRecetaDetalle
                        mDet = mObj.Clone
                        mLista.Add(mDet)
                    Next
                    Dim mListaMezcla As New List(Of ControlMezclaMezclaDetalle)
                    For Each mObj In mControlMezcla.ControlMezclaMezclaDetalle
                        Dim mDet As New ControlMezclaMezclaDetalle
                        mDet = mObj.Clone
                        mListaMezcla.Add(mDet)
                    Next

                    mControlMezcla.ChangeTracker.ChangeTrackingEnabled = False
                    mControlMezcla.ControlMezclaRecetaDetalle = Nothing
                    mControlMezcla.ControlMezclaMezclaDetalle = Nothing
                    mControlMezcla.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mControlMezcla)

                    For Each mItem In mListaMezcla 'Guarda la Mezcla
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DMM_ID = bcherramientas.Get_Id("ControlMezclaMezclaDetalle")
                            mItem.CME_ID = mControlMezcla.CME_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta2.Maintenance(mItem)
                    Next

                    For Each mItem In mLista 'Guarda la Receta
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DMR_ID = bcherramientas.Get_Id("ControlMezclaRecetaDetalle")
                            mItem.CME_ID = mControlMezcla.CME_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        Dim mCopiaItem As New ControlMezclaRecetaDetalle
                        mCopiaItem = mItem.Clone
                        mItem.ChangeTracker.ChangeTrackingEnabled = False
                        mItem.Articulos = Nothing
                        mItem.ART_ID_MP = mCopiaItem.ART_ID_MP
                        mItem.ChangeTracker.ChangeTrackingEnabled = True
                        repDeta.Maintenance(mItem)
                    Next



                    ''''''''''''''''''BORRAR LO ANTERIOR SI SE MODIFICA
                    Dim mDocu As New DocuMovimiento
                    Dim mDMO_ID_REF As Integer
                    ''''''Dim mCount As Integer = -1

                    Dim colDMO As List(Of DocuMovimiento)
                    colDMO = repDocu.GetColByIdCME(mControlMezcla.CME_ID)
                    For Each DMO In colDMO.ToList 'Para que borre el documento antes de guardarlo
                        ''''''mCount += 1
                        ''''''If mCount = 0 Then Continue For
                        If DMO IsNot Nothing Then
                            For Each mItem In DMO.DocuMovimientoDetalle
                                If mItem.Kardex IsNot Nothing Then If mItem.Kardex.Count > 0 Then mItem.Kardex(0).MarkAsDeleted()
                                mItem.MarkAsDeleted()
                            Next
                            DMO.MarkAsDeleted()
                            repDocu.Maintenance(DMO)
                        End If
                    Next


                    '''''''''''''''''PRODUCCION
                    Dim mProd As New Produccion
                    mProd = repProd.GetById(mControlMezcla.PRO_ID)

                    '''''''''''''''''SALIDA ALMACEN MATERIA PRIMA
                    mDocu = New DocuMovimiento
                    ''''''mDocu = colDMO.ToList.Item(0) '''''''''''''''''''''''''Borrar despues de utilizar EN EL INICIO

                    Dim mListDet_S01 As New List(Of DocuMovimientoDetalle)
                    mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    mDocu.DMO_FECHA = mProd.PRO_FECHA
                    mDocu.DTD_ID = "016"
                    mDocu.TDO_ID = "007" 'Nota de Salida
                    mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("016")
                    mDocu.DMO_SERIE = "AMP0"
                    mDocu.DMO_NRO = mControlMezcla.CME_ID
                    mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    mDocu.CME_ID = mControlMezcla.CME_ID
                    mDocu.PRO_ID = mControlMezcla.PRO_ID
                    mDocu.MON_ID = "001" 'Soles
                    mDocu.DOCU_AFECTA_KARDEX = True
                    mDocu.DMO_ESTADO = True
                    mDocu.DMO_FEC_GRAB = Now
                    mDocu.USU_ID = mControlMezcla.USU_ID
                    mDocu.MarkAsAdded()

                    repDocu.Maintenance(mDocu)

                    For Each mItem In mLista
                        ''''''For Each mItem In mDocu.DocuMovimientoDetalle
                        If mItem.DMR_M3 > 0 Then
                            Dim nDMD As New DocuMovimientoDetalle
                            With nDMD
                                .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                                .DMO_ID = mDocu.DMO_ID
                                .ALM_ID = Parametro.GetById("AlmMP").PAR_VALOR1  'Almacen Materia Prima
                                .ART_ID = mItem.ART_ID_MP
                                .DMD_CANTIDAD = mItem.DMR_M3
                                .DMD_PRECIO_UNITARIO = kardex.StockCostoPromedio(.ART_ID, .ALM_ID, mDocu.DMO_FECHA, 2)
                                .DMD_IGV = 0
                                .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                                .DMD_GLOSA = "Salida de Almacen Materia Prima.   /" & mControlMezcla.PRO_ID.ToString & "/"
                                .MarkAsAdded()
                            End With
                            repDetaDocu.Maintenance(nDMD)
                            mListDet_S01.Add(nDMD)
                            ''''''mListDet_S01.Add(mItem)
                        End If
                    Next

                    For Each mItem In mListDet_S01
                        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                            'Movimientos de kardex
                            Dim mKar As New Kardex
                            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                            mKar.ART_ID = mItem.ART_ID
                            mKar.ALM_ID = Parametro.GetById("AlmMP").PAR_VALOR1  'Almacen Materia Prima
                            mKar.DMD_ID = mItem.DMD_ID
                            mKar.KAR_FECHA = mDocu.DMO_FECHA
                            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                                mKar.KAR_INGRESO = mItem.DMD_CANTIDAD
                                mKar.KAR_SALIDA = 0
                                'mKar.KAR_SALDO =
                                mKar.KAR_INGRESO_VAL = mItem.DMD_CONTRAVALOR
                                mKar.KAR_SALIDA_VAL = 0
                                'mKar.KAR_SALDO_VAL =
                                'mKar.KAR_COSTO_PROMEDIO=
                            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
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
                        'kardex.RehacerKardex(mItem.ART_ID, mItem.ALM_ID, mDocu.DMO_FECHA)
                    Next

                    mDMO_ID_REF = mDocu.DMO_ID

                    '''''''''''''''''INGRESO ALMACEN MEZCLA
                    mDocu = New DocuMovimiento
                    Dim mListDet_I02 = New List(Of DocuMovimientoDetalle)
                    mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    mDocu.DMO_FECHA = mProd.PRO_FECHA
                    mDocu.DTD_ID = "015"
                    mDocu.TDO_ID = "006" 'Nota de Ingreso
                    mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")
                    mDocu.DMO_SERIE = "AME0"
                    mDocu.DMO_NRO = mControlMezcla.CME_ID
                    mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    mDocu.CME_ID = mControlMezcla.CME_ID
                    mDocu.PRO_ID = mControlMezcla.PRO_ID
                    mDocu.MON_ID = "001" 'Soles
                    mDocu.DOCU_AFECTA_KARDEX = True
                    mDocu.DMO_ID_REF = mDMO_ID_REF 'Hace referencia a la salida anterior
                    mDocu.DMO_ESTADO = True
                    mDocu.DMO_FEC_GRAB = Now
                    mDocu.USU_ID = mControlMezcla.USU_ID
                    mDocu.MarkAsAdded()

                    repDocu.Maintenance(mDocu)

                    For Each mItem In mListDet_S01
                        Dim nDMD As New DocuMovimientoDetalle
                        With nDMD
                            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                            .DMO_ID = mDocu.DMO_ID
                            .ALM_ID = Parametro.GetById("AlmMZC").PAR_VALOR1  'Almacen Mezcla
                            .ART_ID = mItem.ART_ID
                            .DMD_CANTIDAD = mItem.DMD_CANTIDAD
                            .DMD_PRECIO_UNITARIO = mItem.DMD_PRECIO_UNITARIO
                            .DMD_IGV = 0
                            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                            .DMD_GLOSA = "Ingreso a Almacen Mezcla desde Almacen MP."
                            .MarkAsAdded()
                        End With
                        repDetaDocu.Maintenance(nDMD)
                        mListDet_I02.Add(nDMD)
                    Next

                    For Each mItem In mListDet_I02
                        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                            'Movimientos de kardex
                            Dim mKar As New Kardex
                            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                            mKar.ART_ID = mItem.ART_ID
                            mKar.ALM_ID = Parametro.GetById("AlmMZC").PAR_VALOR1  'Almacen Mezcla
                            mKar.DMD_ID = mItem.DMD_ID
                            mKar.KAR_FECHA = mDocu.DMO_FECHA
                            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                                mKar.KAR_INGRESO = mItem.DMD_CANTIDAD
                                mKar.KAR_SALIDA = 0
                                'mKar.KAR_SALDO =
                                mKar.KAR_INGRESO_VAL = mItem.DMD_CONTRAVALOR
                                mKar.KAR_SALIDA_VAL = 0
                                'mKar.KAR_SALDO_VAL =
                                'mKar.KAR_COSTO_PROMEDIO=
                            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
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
                        'kardex.RehacerKardex(mItem.ART_ID, mItem.ALM_ID, mDocu.DMO_FECHA)
                    Next


                    '''''''''''''''''SALIDA ALMACEN MEZCLA
                    mDocu = New DocuMovimiento
                    Dim mListDet_S03 = New List(Of DocuMovimientoDetalle)
                    mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    mDocu.DMO_FECHA = mProd.PRO_FECHA
                    mDocu.DTD_ID = "016"
                    mDocu.TDO_ID = "007" 'Nota de Salida
                    mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("016")
                    mDocu.DMO_SERIE = "AME0"
                    mDocu.DMO_NRO = mControlMezcla.CME_ID
                    mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    mDocu.CME_ID = mControlMezcla.CME_ID
                    mDocu.PRO_ID = mControlMezcla.PRO_ID
                    mDocu.MON_ID = "001" 'Soles
                    mDocu.DOCU_AFECTA_KARDEX = True
                    mDocu.DMO_ESTADO = True
                    mDocu.DMO_FEC_GRAB = Now
                    mDocu.USU_ID = mControlMezcla.USU_ID
                    mDocu.MarkAsAdded()

                    repDocu.Maintenance(mDocu)

                    For Each mItem In mListDet_I02
                        Dim nDMD As New DocuMovimientoDetalle
                        With nDMD
                            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                            .DMO_ID = mDocu.DMO_ID
                            .ALM_ID = Parametro.GetById("AlmMZC").PAR_VALOR1  'Almacen Mezcla
                            .ART_ID = mItem.ART_ID
                            .DMD_CANTIDAD = mItem.DMD_CANTIDAD
                            .DMD_PRECIO_UNITARIO = mItem.DMD_PRECIO_UNITARIO
                            .DMD_IGV = 0
                            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                            .DMD_GLOSA = "Salida Almacen Mezcla a Almacen Planta."
                            .MarkAsAdded()
                        End With
                        repDetaDocu.Maintenance(nDMD)
                        mListDet_S03.Add(nDMD)
                    Next

                    For Each mItem In mListDet_S03
                        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                            'Movimientos de kardex
                            Dim mKar As New Kardex
                            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                            mKar.ART_ID = mItem.ART_ID
                            mKar.ALM_ID = Parametro.GetById("AlmMZC").PAR_VALOR1  'Almacen Mezcla
                            mKar.DMD_ID = mItem.DMD_ID
                            mKar.KAR_FECHA = mDocu.DMO_FECHA
                            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                                mKar.KAR_INGRESO = mItem.DMD_CANTIDAD
                                mKar.KAR_SALIDA = 0
                                'mKar.KAR_SALDO =
                                mKar.KAR_INGRESO_VAL = mItem.DMD_CONTRAVALOR
                                mKar.KAR_SALIDA_VAL = 0
                                'mKar.KAR_SALDO_VAL =
                                'mKar.KAR_COSTO_PROMEDIO=
                            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
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
                        'kardex.RehacerKardex(mItem.ART_ID, mItem.ALM_ID, mDocu.DMO_FECHA)
                    Next

                    mDMO_ID_REF = mDocu.DMO_ID


                    '''''''''''''''''INGRESO ALMACEN DE PLANTA
                    mDocu = New DocuMovimiento
                    Dim mListDet_I04 = New List(Of DocuMovimientoDetalle)
                    mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    mDocu.DMO_FECHA = mProd.PRO_FECHA
                    mDocu.DTD_ID = "015"
                    mDocu.TDO_ID = "006" 'Nota de Ingreso
                    mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")
                    If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                        mDocu.DMO_SERIE = "AP01"
                    Else
                        mDocu.DMO_SERIE = "AP02"
                    End If
                    mDocu.DMO_NRO = mControlMezcla.CME_ID
                    mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    mDocu.CME_ID = mControlMezcla.CME_ID
                    mDocu.PRO_ID = mControlMezcla.PRO_ID
                    mDocu.MON_ID = "001" 'Soles
                    mDocu.DOCU_AFECTA_KARDEX = True
                    mDocu.DMO_ID_REF = mDMO_ID_REF 'Hace referencia a la salida anterior
                    mDocu.DMO_ESTADO = True
                    mDocu.DMO_FEC_GRAB = Now
                    mDocu.USU_ID = mControlMezcla.USU_ID
                    mDocu.MarkAsAdded()

                    repDocu.Maintenance(mDocu)

                    For Each mItem In mListDet_S03
                        Dim nDMD As New DocuMovimientoDetalle
                        With nDMD
                            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                            .DMO_ID = mDocu.DMO_ID

                            If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                                .ALM_ID = Parametro.GetById("AlmPLAN01").PAR_VALOR1  'Almacen Planta 1
                            Else
                                .ALM_ID = Parametro.GetById("AlmPLAN02").PAR_VALOR1  'Almacen Planta 2
                            End If

                            .ART_ID = mItem.ART_ID
                            .DMD_CANTIDAD = mItem.DMD_CANTIDAD
                            .DMD_PRECIO_UNITARIO = mItem.DMD_PRECIO_UNITARIO
                            .DMD_IGV = 0
                            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                            .DMD_GLOSA = "Ingreso Almacen Planta desde Almacen Mezcla."
                            .MarkAsAdded()
                        End With
                        repDetaDocu.Maintenance(nDMD)
                        mListDet_I04.Add(nDMD)
                    Next

                    For Each mItem In mListDet_I04
                        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                            'Movimientos de kardex
                            Dim mKar As New Kardex
                            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                            mKar.ART_ID = mItem.ART_ID

                            If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                                mKar.ALM_ID = Parametro.GetById("AlmPLAN01").PAR_VALOR1  'Almacen Planta 1
                            Else
                                mKar.ALM_ID = Parametro.GetById("AlmPLAN02").PAR_VALOR1  'Almacen Planta 2
                            End If

                            mKar.DMD_ID = mItem.DMD_ID
                            mKar.KAR_FECHA = mDocu.DMO_FECHA
                            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                                mKar.KAR_INGRESO = mItem.DMD_CANTIDAD
                                mKar.KAR_SALIDA = 0
                                'mKar.KAR_SALDO =
                                mKar.KAR_INGRESO_VAL = mItem.DMD_CONTRAVALOR
                                mKar.KAR_SALIDA_VAL = 0
                                'mKar.KAR_SALDO_VAL =
                                'mKar.KAR_COSTO_PROMEDIO=
                            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
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
                        'kardex.RehacerKardex(mItem.ART_ID, mItem.ALM_ID, mDocu.DMO_FECHA)
                    Next


                    '' ''====================== CONTEO  ==============================================================
                    ' ''Dim repConteo = ContainerService.Resolve(Of BL.IBCControlConteo)()
                    ' ''Dim mControlConteo As ControlConteo
                    ' ''Dim ValTotalMP As Decimal = 0
                    ' ''mControlConteo = repConteo.ControlConteoGetByIdPRO(mControlMezcla.PRO_ID)

                    ' '' '''''''''''''''''BORRAR LO ANTERIOR SI SE MODIFICA
                    ' ''mDocu = New DocuMovimiento
                    ' ''mDMO_ID_REF = 0
                    ' ''Dim colmCME As List(Of ControlMezcla)

                    ' ''colDMO = New List(Of DocuMovimiento)()
                    ' ''colDMO = repDocu.GetColByIdCCO_CONTEO(mControlConteo.CCO_ID)
                    ' ''For Each DMO In colDMO.ToList 'Para que borre el documento antes de guardarlo
                    ' ''    If DMO IsNot Nothing Then
                    ' ''        If DMO.DocuMovimientoDetalle IsNot Nothing Then
                    ' ''            For Each mItem In DMO.DocuMovimientoDetalle
                    ' ''                If mItem.Kardex IsNot Nothing Then mItem.Kardex(0).MarkAsDeleted() : kardex.Maintenance(mItem.Kardex(0))
                    ' ''                mItem.MarkAsDeleted()
                    ' ''                repDetaDocu.Maintenance(mItem)
                    ' ''            Next
                    ' ''        End If
                    ' ''        DMO.MarkAsDeleted()
                    ' ''        repDocu.Maintenance(DMO)
                    ' ''    End If
                    ' ''Next

                    ' '' '''''''''''''''''PRODUCCION
                    ' ''mProd = New Produccion
                    ' ''mProd = repProd.GetById(mControlConteo.PRO_ID)

                    ' '' '''''''''''''''''SALIDA ALMACEN PLANTA
                    ' ''mDocu = New DocuMovimiento
                    ' ''Dim mListDet As New List(Of DocuMovimientoDetalle)
                    ' ''mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    ' ''mDocu.DMO_FECHA = mProd.PRO_FECHA
                    ' ''mDocu.DTD_ID = "016"
                    ' ''mDocu.TDO_ID = "007" 'Nota de Salida
                    ' ''mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("016")
                    ' ''If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    ' ''    mDocu.DMO_SERIE = "AP01"
                    ' ''Else
                    ' ''    mDocu.DMO_SERIE = "AP02"
                    ' ''End If

                    ' ''mDocu.DMO_NRO = mControlConteo.CCO_ID
                    ' ''mDocu.DMO_FECHA_DOCUMENTO = mControlConteo.CCO_FECHA
                    ' ''mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    ' ''mDocu.PRO_ID = mControlConteo.PRO_ID
                    ' ''mDocu.MON_ID = "001" 'Soles
                    ' ''mDocu.DOCU_AFECTA_KARDEX = True
                    ' ''mDocu.DMO_ESTADO = True
                    ' ''mDocu.DMO_FEC_GRAB = Now
                    ' ''mDocu.USU_ID = mControlConteo.USU_ID
                    ' ''mDocu.MarkAsAdded()

                    ' ''repDocu.Maintenance(mDocu)

                    '' ''Sacamos los M3 de la receta y reciclaje x produccion
                    ' ''Dim mDt As DataTable = repConteo.Interfase_Pre_Conteo(mProd.PRO_ID)
                    ' ''For Each mRow As DataRow In mDt.Rows
                    ' ''    If mRow("DMD_CANTIDAD") > 0 Then


                    ' ''        Dim nDMD As New DocuMovimientoDetalle
                    ' ''        With nDMD
                    ' ''            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    ' ''            .DMO_ID = mDocu.DMO_ID
                    ' ''            If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    ' ''                .ALM_ID = Parametro.GetById("AlmPLAN01").PAR_VALOR1  'Almacen Planta 1
                    ' ''            Else
                    ' ''                .ALM_ID = Parametro.GetById("AlmPLAN02").PAR_VALOR1  'Almacen Planta 2
                    ' ''            End If
                    ' ''            .ART_ID = mRow("Art_Id")
                    ' ''            .DMD_CANTIDAD = mRow("DMD_CANTIDAD")
                    ' ''            '.DMD_PRECIO_UNITARIO = kardex.StockCostoPromedio(.ART_ID, .ALM_ID, mDocu.DMO_FECHA, 2)
                    ' ''            .DMD_PRECIO_UNITARIO = mRow("DMD_PRECIO_UNITARIO")
                    ' ''            .DMD_IGV = 0
                    ' ''            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    ' ''            .DMD_GLOSA = "Salida de Almacen Planta por Conteo a Cancha/Secadero"
                    ' ''            .MarkAsAdded()
                    ' ''        End With
                    ' ''        repDetaDocu.Maintenance(nDMD)
                    ' ''        ValTotalMP = ValTotalMP + nDMD.DMD_CONTRAVALOR

                    ' ''        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    ' ''            'Movimientos de kardex
                    ' ''            Dim mKar As New Kardex
                    ' ''            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    ' ''            mKar.ART_ID = nDMD.ART_ID
                    ' ''            mKar.ALM_ID = nDMD.ALM_ID
                    ' ''            mKar.DMD_ID = nDMD.DMD_ID
                    ' ''            mKar.KAR_FECHA = mDocu.DMO_FECHA
                    ' ''            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    ' ''                mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                    ' ''                mKar.KAR_SALIDA = 0
                    ' ''                'mKar.KAR_SALDO =
                    ' ''                mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                    ' ''                mKar.KAR_SALIDA_VAL = 0
                    ' ''                'mKar.KAR_SALDO_VAL =
                    ' ''                'mKar.KAR_COSTO_PROMEDIO=
                    ' ''            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    ' ''                mKar.KAR_INGRESO = 0
                    ' ''                mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                    ' ''                'mKar.KAR_SALDO =
                    ' ''                mKar.KAR_INGRESO_VAL = 0
                    ' ''                mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                    ' ''                'mKar.KAR_SALDO_VAL =
                    ' ''                'mKar.KAR_COSTO_PROMEDIO=
                    ' ''            End If
                    ' ''            kardex.Maintenance(mKar)
                    ' ''        End If
                    ' ''        ''kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)
                    ' ''    End If
                    ' ''Next


                    ' ''mDMO_ID_REF = mDocu.DMO_ID


                    ' '' '''''''''''''''''INGRESO ALMACEN RECICLADO DE PLANTA
                    ' ''mDocu = New DocuMovimiento
                    ' ''mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    ' ''mDocu.DMO_FECHA = mProd.PRO_FECHA
                    ' ''mDocu.DTD_ID = "015"
                    ' ''mDocu.TDO_ID = "006" 'Nota de Ingreso
                    ' ''mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")
                    ' ''If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    ' ''    mDocu.DMO_SERIE = "RP01"
                    ' ''Else
                    ' ''    mDocu.DMO_SERIE = "RP02"
                    ' ''End If
                    ' ''mDocu.DMO_NRO = mControlConteo.CCO_ID
                    ' ''mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    ' ''mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    ' ''mDocu.PRO_ID = mControlConteo.PRO_ID
                    ' ''mDocu.MON_ID = "001" 'Soles
                    ' ''mDocu.DOCU_AFECTA_KARDEX = True
                    ' ''mDocu.DMO_ID_REF = mDMO_ID_REF 'Hace referencia a la salida anterior
                    ' ''mDocu.DMO_ESTADO = True
                    ' ''mDocu.DMO_FEC_GRAB = Now
                    ' ''mDocu.USU_ID = mControlConteo.USU_ID
                    ' ''mDocu.MarkAsAdded()

                    ' ''repDocu.Maintenance(mDocu)

                    ' ''For Each mRow As DataRow In mDt.Rows
                    ' ''    If mRow("Cant_MP_M3_Rec") > 0 Then


                    ' ''        Dim nDMD As New DocuMovimientoDetalle
                    ' ''        With nDMD
                    ' ''            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    ' ''            .DMO_ID = mDocu.DMO_ID
                    ' ''            If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    ' ''                .ALM_ID = Parametro.GetById("AlmRPLAN01").PAR_VALOR1  'Almacen Reciclaje Planta 1
                    ' ''            Else
                    ' ''                .ALM_ID = Parametro.GetById("AlmRPLAN02").PAR_VALOR1  'Almacen Reciclaje Planta 2
                    ' ''            End If
                    ' ''            .ART_ID = mRow("Art_Id")
                    ' ''            .DMD_CANTIDAD = mRow("Cant_MP_M3_Rec")
                    ' ''            .DMD_PRECIO_UNITARIO = mRow("DMD_PRECIO_UNITARIO")
                    ' ''            .DMD_IGV = 0
                    ' ''            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    ' ''            .DMD_GLOSA = "Ingreso Almacen Reciclado desde Almacen Planta"
                    ' ''            .MarkAsAdded()
                    ' ''        End With
                    ' ''        repDetaDocu.Maintenance(nDMD)
                    ' ''        ValTotalMP = ValTotalMP - nDMD.DMD_CONTRAVALOR



                    ' ''        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    ' ''            'Movimientos de kardex
                    ' ''            Dim mKar As New Kardex
                    ' ''            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    ' ''            mKar.ART_ID = nDMD.ART_ID
                    ' ''            mKar.ALM_ID = nDMD.ALM_ID
                    ' ''            mKar.DMD_ID = nDMD.DMD_ID
                    ' ''            mKar.KAR_FECHA = mDocu.DMO_FECHA
                    ' ''            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    ' ''                mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                    ' ''                mKar.KAR_SALIDA = 0
                    ' ''                'mKar.KAR_SALDO =
                    ' ''                mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                    ' ''                mKar.KAR_SALIDA_VAL = 0
                    ' ''                'mKar.KAR_SALDO_VAL =
                    ' ''                'mKar.KAR_COSTO_PROMEDIO=
                    ' ''            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    ' ''                mKar.KAR_INGRESO = 0
                    ' ''                mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                    ' ''                'mKar.KAR_SALDO =
                    ' ''                mKar.KAR_INGRESO_VAL = 0
                    ' ''                mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                    ' ''                'mKar.KAR_SALDO_VAL =
                    ' ''                'mKar.KAR_COSTO_PROMEDIO=
                    ' ''            End If
                    ' ''            kardex.Maintenance(mKar)
                    ' ''        End If
                    ' ''        ''kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)
                    ' ''    End If
                    ' ''Next



                    ' '' '''''''''''''''''SALIDA ALMACEN reciclaje PLANTA
                    ' ''mDocu = New DocuMovimiento
                    ' ''mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    ' ''mDocu.DMO_FECHA = mProd.PRO_FECHA
                    ' ''mDocu.DTD_ID = "016"
                    ' ''mDocu.TDO_ID = "007" 'Nota de Salida
                    ' ''mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("016")
                    ' ''If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    ' ''    mDocu.DMO_SERIE = "RP01"
                    ' ''Else
                    ' ''    mDocu.DMO_SERIE = "RP02"
                    ' ''End If
                    ' ''mDocu.DMO_NRO = mControlConteo.CCO_ID
                    ' ''mDocu.DMO_FECHA_DOCUMENTO = mControlConteo.CCO_FECHA
                    ' ''mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    ' ''mDocu.PRO_ID = mControlConteo.PRO_ID
                    ' ''mDocu.MON_ID = "001" 'Soles
                    ' ''mDocu.DOCU_AFECTA_KARDEX = True
                    ' ''mDocu.DMO_ESTADO = True
                    ' ''mDocu.DMO_FEC_GRAB = Now
                    ' ''mDocu.USU_ID = mControlConteo.USU_ID
                    ' ''mDocu.MarkAsAdded()

                    ' ''repDocu.Maintenance(mDocu)

                    ' ''For Each mRow As DataRow In mDt.Rows
                    ' ''    If mRow("Cant_MP_M3_Rec") > 0 Then


                    ' ''        Dim nDMD As New DocuMovimientoDetalle
                    ' ''        With nDMD
                    ' ''            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    ' ''            .DMO_ID = mDocu.DMO_ID
                    ' ''            If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    ' ''                .ALM_ID = Parametro.GetById("AlmRPLAN01").PAR_VALOR1  'Almacen Reciclaje Planta 1
                    ' ''            Else
                    ' ''                .ALM_ID = Parametro.GetById("AlmRPLAN02").PAR_VALOR1  'Almacen Reciclaje Planta 2
                    ' ''            End If
                    ' ''            .ART_ID = mRow("Art_Id")
                    ' ''            .DMD_CANTIDAD = mRow("Cant_MP_M3_Rec")
                    ' ''            .DMD_PRECIO_UNITARIO = mRow("DMD_PRECIO_UNITARIO")
                    ' ''            .DMD_IGV = 0
                    ' ''            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    ' ''            .DMD_GLOSA = "Salida Almacen Reciclado Planta hacia Almacen Materia Prima"
                    ' ''            .MarkAsAdded()
                    ' ''        End With
                    ' ''        repDetaDocu.Maintenance(nDMD)


                    ' ''        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    ' ''            'Movimientos de kardex
                    ' ''            Dim mKar As New Kardex
                    ' ''            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    ' ''            mKar.ART_ID = nDMD.ART_ID
                    ' ''            mKar.ALM_ID = nDMD.ALM_ID
                    ' ''            mKar.DMD_ID = nDMD.DMD_ID
                    ' ''            mKar.KAR_FECHA = mDocu.DMO_FECHA
                    ' ''            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    ' ''                mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                    ' ''                mKar.KAR_SALIDA = 0
                    ' ''                'mKar.KAR_SALDO =
                    ' ''                mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                    ' ''                mKar.KAR_SALIDA_VAL = 0
                    ' ''                'mKar.KAR_SALDO_VAL =
                    ' ''                'mKar.KAR_COSTO_PROMEDIO=
                    ' ''            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    ' ''                mKar.KAR_INGRESO = 0
                    ' ''                mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                    ' ''                'mKar.KAR_SALDO =
                    ' ''                mKar.KAR_INGRESO_VAL = 0
                    ' ''                mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                    ' ''                'mKar.KAR_SALDO_VAL =
                    ' ''                'mKar.KAR_COSTO_PROMEDIO=
                    ' ''            End If
                    ' ''            kardex.Maintenance(mKar)
                    ' ''        End If
                    ' ''        ''kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)
                    ' ''    End If
                    ' ''Next


                    ' ''mDMO_ID_REF = mDocu.DMO_ID


                    ' '' '''''''''''''''''INGRESO ALMACEN MATERIA PRIMA - SOLO RECICLADO CRUDO
                    ' ''mDocu = New DocuMovimiento
                    ' ''mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    ' ''mDocu.DMO_FECHA = mProd.PRO_FECHA
                    ' ''mDocu.DTD_ID = "015"
                    ' ''mDocu.TDO_ID = "006" 'Nota de Ingreso
                    ' ''mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")
                    ' ''mDocu.DMO_SERIE = "AMP0"
                    ' ''mDocu.DMO_NRO = mControlConteo.CCO_ID
                    ' ''mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    ' ''mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    ' ''mDocu.PRO_ID = mControlConteo.PRO_ID
                    ' ''mDocu.MON_ID = "001" 'Soles
                    ' ''mDocu.DOCU_AFECTA_KARDEX = True
                    ' ''mDocu.DMO_ID_REF = mDMO_ID_REF 'Hace referencia a la salida anterior
                    ' ''mDocu.DMO_ESTADO = True
                    ' ''mDocu.DMO_FEC_GRAB = Now
                    ' ''mDocu.USU_ID = mControlConteo.USU_ID
                    ' ''mDocu.MarkAsAdded()

                    ' ''repDocu.Maintenance(mDocu)

                    ' ''For Each mRow As DataRow In mDt.Rows
                    ' ''    If mRow("Cant_MP_M3_Rec") > 0 Then


                    ' ''        Dim nDMD As New DocuMovimientoDetalle
                    ' ''        With nDMD
                    ' ''            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    ' ''            .DMO_ID = mDocu.DMO_ID
                    ' ''            .ALM_ID = Parametro.GetById("Almmp").PAR_VALOR1  'Almacen materia prima
                    ' ''            .ART_ID = "021413"
                    ' ''            .DMD_CANTIDAD = mRow("Cant_MP_M3_Rec")
                    ' ''            .DMD_PRECIO_UNITARIO = mRow("DMD_PRECIO_UNITARIO")
                    ' ''            .DMD_IGV = 0
                    ' ''            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    ' ''            .DMD_GLOSA = "Ingreso Almacen Materia Prima Reciclado desde Almacen Reciclado Planta"
                    ' ''            .MarkAsAdded()
                    ' ''        End With
                    ' ''        repDetaDocu.Maintenance(nDMD)


                    ' ''        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    ' ''            'Movimientos de kardex
                    ' ''            Dim mKar As New Kardex
                    ' ''            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    ' ''            mKar.ART_ID = nDMD.ART_ID
                    ' ''            mKar.ALM_ID = nDMD.ALM_ID
                    ' ''            mKar.DMD_ID = nDMD.DMD_ID
                    ' ''            mKar.KAR_FECHA = mDocu.DMO_FECHA
                    ' ''            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    ' ''                mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                    ' ''                mKar.KAR_SALIDA = 0
                    ' ''                'mKar.KAR_SALDO =
                    ' ''                mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                    ' ''                mKar.KAR_SALIDA_VAL = 0
                    ' ''                'mKar.KAR_SALDO_VAL =
                    ' ''                'mKar.KAR_COSTO_PROMEDIO=
                    ' ''            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    ' ''                mKar.KAR_INGRESO = 0
                    ' ''                mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                    ' ''                'mKar.KAR_SALDO =
                    ' ''                mKar.KAR_INGRESO_VAL = 0
                    ' ''                mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                    ' ''                'mKar.KAR_SALDO_VAL =
                    ' ''                'mKar.KAR_COSTO_PROMEDIO=
                    ' ''            End If
                    ' ''            kardex.Maintenance(mKar)
                    ' ''        End If
                    ' ''        ''kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)
                    ' ''    End If
                    ' ''Next




                    ' '' '''''''''''''''''INGRESO ALMACEN SECADO (CANCHA/SECADERO)
                    ' ''mDocu = New DocuMovimiento
                    ' ''mListDet = New List(Of DocuMovimientoDetalle)
                    ' ''mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    ' ''mDocu.DMO_FECHA = mProd.PRO_FECHA
                    ' ''mDocu.DTD_ID = "015"
                    ' ''mDocu.TDO_ID = "006" 'Nota de Ingreso
                    ' ''mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")

                    ' ''mDocu.DMO_SERIE = "ACS0"

                    ' ''mDocu.DMO_NRO = mControlConteo.CCO_ID
                    ' ''mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    ' ''mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    ' ''mDocu.PRO_ID = mControlConteo.PRO_ID
                    ' ''mDocu.MON_ID = "001" 'Soles
                    ' ''mDocu.DOCU_AFECTA_KARDEX = True
                    ' ''mDocu.DMO_ID_REF = mDMO_ID_REF 'Hace referencia a la salida anterior
                    ' ''mDocu.DMO_ESTADO = True
                    ' ''mDocu.DMO_FEC_GRAB = Now
                    ' ''mDocu.USU_ID = mControlConteo.USU_ID
                    ' ''mDocu.MarkAsAdded()

                    ' ''repDocu.Maintenance(mDocu)

                    ' ''For Each mItem In mControlConteo.ControlConteoDetalle

                    ' ''    Dim nDMD As New DocuMovimientoDetalle
                    ' ''    With nDMD
                    ' ''        .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    ' ''        .DMO_ID = mDocu.DMO_ID
                    ' ''        .ALM_ID = mItem.Cancha.ALM_ID 'Almacen de Cancha o Secadero
                    ' ''        .ART_ID = mProd.LAD_ID
                    ' ''        .DMD_CANTIDAD = mItem.DCC_CANTIDAD
                    ' ''        .DMD_PRECIO_UNITARIO = ValTotalMP / mItem.DCC_CANTIDAD
                    ' ''        .DMD_IGV = 0
                    ' ''        .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    ' ''        .DMD_GLOSA = "Ingreso de Ladrillos desde Almacen Planta"
                    ' ''        .MarkAsAdded()
                    ' ''    End With
                    ' ''    repDetaDocu.Maintenance(nDMD)
                    ' ''    mListDet.Add(nDMD)
                    ' ''Next

                    ' ''For Each mItem In mListDet
                    ' ''    If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    ' ''        'Movimientos de kardex
                    ' ''        Dim mKar As New Kardex
                    ' ''        mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    ' ''        mKar.ART_ID = mItem.ART_ID
                    ' ''        mKar.ALM_ID = mItem.ALM_ID
                    ' ''        mKar.DMD_ID = mItem.DMD_ID
                    ' ''        mKar.KAR_FECHA = mDocu.DMO_FECHA
                    ' ''        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    ' ''            mKar.KAR_INGRESO = mItem.DMD_CANTIDAD
                    ' ''            mKar.KAR_SALIDA = 0
                    ' ''            'mKar.KAR_SALDO =
                    ' ''            mKar.KAR_INGRESO_VAL = mItem.DMD_CONTRAVALOR
                    ' ''            mKar.KAR_SALIDA_VAL = 0
                    ' ''            'mKar.KAR_SALDO_VAL =
                    ' ''            'mKar.KAR_COSTO_PROMEDIO=
                    ' ''        ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    ' ''            mKar.KAR_INGRESO = 0
                    ' ''            mKar.KAR_SALIDA = mItem.DMD_CANTIDAD
                    ' ''            'mKar.KAR_SALDO =
                    ' ''            mKar.KAR_INGRESO_VAL = 0
                    ' ''            mKar.KAR_SALIDA_VAL = mItem.DMD_CONTRAVALOR
                    ' ''            'mKar.KAR_SALDO_VAL =
                    ' ''            'mKar.KAR_COSTO_PROMEDIO=
                    ' ''        End If
                    ' ''        kardex.Maintenance(mKar)
                    ' ''    End If
                    ' ''    ''kardex.RehacerKardex(mItem.ART_ID, mItem.ALM_ID, mDocu.DMO_FECHA)
                    ' ''Next

                    Scope.Complete()


                    ' ''''''''''''''''''''''Pasar a Spring
                    'If Interfase_MateriaPrima(mControlMezcla.CME_ID) = "0" Then
                    '    Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                    'End If
                    ' ''''''''''''''''''''''''''''''''''''


                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ControlMezclaGetByIdPRO(ByVal PRO_Id As Integer) As System.Collections.Generic.List(Of BE.ControlMezcla) Implements IBCControlMezcla.ControlMezclaGetByIdPRO
            Dim result As List(Of ControlMezcla) = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlMezclaRepositorio)()
                result = rep.GetByIdPRO(PRO_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function MezclaxFecha() As System.Data.DataTable Implements IBCControlMezcla.MezclaxFecha
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spMezclaxFecha")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_MateriaPrima(ByVal CME_ID As Integer) As String Implements IBCControlMezcla.Interfase_MateriaPrima
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spInterfase_MateriaPrima", CME_ID)
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
