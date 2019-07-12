Imports Ladisac.BE
Imports System.IO

Namespace Ladisac.BL

    Public Class BCControlConteo
        Implements IBCControlConteo

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ControlConteoGetById(ByVal CCO_ID As Integer) As BE.ControlConteo Implements IBCControlConteo.ControlConteoGetById
            Dim result As ControlConteo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlConteoRepositorio)()
                result = rep.GetById(CCO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaControlConteo() As String Implements IBCControlConteo.ListaControlConteo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlConteoRepositorio)()
                result = rep.ListaControlConteo
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoControlConteo(ByVal mControlConteo As BE.ControlConteo) Implements IBCControlConteo.MantenimientoControlConteo
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlConteoRepositorio)()
                Dim repDeta = ContainerService.Resolve(Of DA.IControlConteoDetalleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Dim repProd = ContainerService.Resolve(Of DA.IProduccionRepositorio)()
                Dim repDocu = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                Dim repDetaDocu = ContainerService.Resolve(Of DA.IDocuMovimientoDetalleRepositorio)()
                Dim repDetalleTipoDocumento = ContainerService.Resolve(Of DA.IDetalleTipoDocumentoRepositorio)()
                Dim repCME = ContainerService.Resolve(Of DA.IControlMezclaRepositorio)()
                Dim Parametro = ContainerService.Resolve(Of DA.IParametroRepositorio)()
                Dim kardex = ContainerService.Resolve(Of DA.IKardexRepositorio)()
                Dim ValTotalMP As Decimal = 0


                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mControlConteo.ChangeTracker.State = ObjectState.Added) Then
                        mControlConteo.CCO_ID = bcherramientas.Get_Id("ControlConteo")
                    ElseIf (mControlConteo.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    Dim mLista As New List(Of ControlConteoDetalle)
                    For Each mObj In mControlConteo.ControlConteoDetalle
                        Dim mDet As New ControlConteoDetalle
                        mDet = mObj.Clone
                        mLista.Add(mDet)
                    Next
                    mControlConteo.ChangeTracker.ChangeTrackingEnabled = False
                    mControlConteo.ControlConteoDetalle = Nothing
                    mControlConteo.ChangeTracker.ChangeTrackingEnabled = True

                    rep.Maintenance(mControlConteo)

                    For Each mItem In mLista
                        If (mItem.ChangeTracker.State = ObjectState.Added) Then
                            mItem.DCC_ID = bcherramientas.Get_Id("ControlConteoDetalle")
                            mItem.CCO_ID = mControlConteo.CCO_ID
                        ElseIf (mItem.ChangeTracker.State = ObjectState.Modified) Then

                        End If
                        repDeta.Maintenance(mItem)
                    Next





                    ' '''''''''''''''''BORRAR LO ANTERIOR SI SE MODIFICA
                    'Dim mDocu As New DocuMovimiento
                    'Dim mDMO_ID_REF As Integer
                    'Dim colmCME As List(Of ControlMezcla)

                    'Dim colDMO As List(Of DocuMovimiento)
                    'colDMO = repDocu.GetColByIdCCO_CONTEO(mControlConteo.CCO_ID)
                    'For Each DMO In colDMO.ToList 'Para que borre el documento antes de guardarlo
                    '    If DMO IsNot Nothing Then
                    '        If DMO.DocuMovimientoDetalle IsNot Nothing Then
                    '            For Each mItem In DMO.DocuMovimientoDetalle
                    '                If mItem.Kardex IsNot Nothing Then mItem.Kardex(0).MarkAsDeleted() : kardex.Maintenance(mItem.Kardex(0))
                    '                mItem.MarkAsDeleted()
                    '                repDetaDocu.Maintenance(mItem)
                    '            Next
                    '        End If
                    '        DMO.MarkAsDeleted()
                    '        repDocu.Maintenance(DMO)
                    '    End If
                    'Next

                    ' '''''''''''''''''PRODUCCION
                    'Dim mProd As New Produccion
                    'mProd = repProd.GetById(mControlConteo.PRO_ID)

                    ' '''''''''''''''''SALIDA ALMACEN PLANTA
                    'mDocu = New DocuMovimiento
                    'Dim mListDet As New List(Of DocuMovimientoDetalle)
                    'mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    'mDocu.DMO_FECHA = mProd.PRO_FECHA
                    'mDocu.DTD_ID = "016"
                    'mDocu.TDO_ID = "007" 'Nota de Salida
                    'mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("016")
                    'If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    '    mDocu.DMO_SERIE = "AP01"
                    'Else
                    '    mDocu.DMO_SERIE = "AP02"
                    'End If

                    'mDocu.DMO_NRO = mControlConteo.CCO_ID
                    'mDocu.DMO_FECHA_DOCUMENTO = mControlConteo.CCO_FECHA
                    'mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    'mDocu.PRO_ID = mControlConteo.PRO_ID
                    'mDocu.MON_ID = "001" 'Soles
                    'mDocu.DOCU_AFECTA_KARDEX = True
                    'mDocu.DMO_ESTADO = True
                    'mDocu.DMO_FEC_GRAB = Now
                    'mDocu.USU_ID = mControlConteo.USU_ID
                    'mDocu.MarkAsAdded()

                    'repDocu.Maintenance(mDocu)

                    ''Sacamos los M3 de la receta y reciclaje x produccion
                    'Dim mDt As DataTable = Interfase_Pre_Conteo(mProd.PRO_ID)
                    'For Each mRow As DataRow In mDt.Rows
                    '    If mRow("DMD_CANTIDAD") > 0 Then


                    '        Dim nDMD As New DocuMovimientoDetalle
                    '        With nDMD
                    '            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    '            .DMO_ID = mDocu.DMO_ID
                    '            If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    '                .ALM_ID = Parametro.GetById("AlmPLAN01").PAR_VALOR1  'Almacen Planta 1
                    '            Else
                    '                .ALM_ID = Parametro.GetById("AlmPLAN02").PAR_VALOR1  'Almacen Planta 2
                    '            End If
                    '            .ART_ID = mRow("Art_Id")
                    '            .DMD_CANTIDAD = mRow("DMD_CANTIDAD")
                    '            '.DMD_PRECIO_UNITARIO = kardex.StockCostoPromedio(.ART_ID, .ALM_ID, mDocu.DMO_FECHA, 2)
                    '            .DMD_PRECIO_UNITARIO = mRow("DMD_PRECIO_UNITARIO")
                    '            .DMD_IGV = 0
                    '            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    '            .DMD_GLOSA = "Salida de Almacen Planta por Conteo a Cancha o Secadero /" & mControlConteo.PRO_ID.ToString & "/"
                    '            .MarkAsAdded()
                    '        End With
                    '        repDetaDocu.Maintenance(nDMD)
                    '        ValTotalMP = ValTotalMP + nDMD.DMD_CONTRAVALOR

                    '        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    '            'Movimientos de kardex
                    '            Dim mKar As New Kardex
                    '            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    '            mKar.ART_ID = nDMD.ART_ID
                    '            mKar.ALM_ID = nDMD.ALM_ID
                    '            mKar.DMD_ID = nDMD.DMD_ID
                    '            mKar.KAR_FECHA = mDocu.DMO_FECHA
                    '            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    '                mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                    '                mKar.KAR_SALIDA = 0
                    '                'mKar.KAR_SALDO =
                    '                mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                    '                mKar.KAR_SALIDA_VAL = 0
                    '                'mKar.KAR_SALDO_VAL =
                    '                'mKar.KAR_COSTO_PROMEDIO=
                    '            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    '                mKar.KAR_INGRESO = 0
                    '                mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                    '                'mKar.KAR_SALDO =
                    '                mKar.KAR_INGRESO_VAL = 0
                    '                mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                    '                'mKar.KAR_SALDO_VAL =
                    '                'mKar.KAR_COSTO_PROMEDIO=
                    '            End If
                    '            kardex.Maintenance(mKar)
                    '        End If
                    '        'kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)
                    '    End If
                    'Next


                    'mDMO_ID_REF = mDocu.DMO_ID


                    ' '''''''''''''''''INGRESO ALMACEN RECICLADO DE PLANTA
                    'mDocu = New DocuMovimiento
                    'mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    'mDocu.DMO_FECHA = mProd.PRO_FECHA
                    'mDocu.DTD_ID = "015"
                    'mDocu.TDO_ID = "006" 'Nota de Ingreso
                    'mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")
                    'If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    '    mDocu.DMO_SERIE = "RP01"
                    'Else
                    '    mDocu.DMO_SERIE = "RP02"
                    'End If
                    'mDocu.DMO_NRO = mControlConteo.CCO_ID
                    'mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    'mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    'mDocu.PRO_ID = mControlConteo.PRO_ID
                    'mDocu.MON_ID = "001" 'Soles
                    'mDocu.DOCU_AFECTA_KARDEX = True
                    'mDocu.DMO_ID_REF = mDMO_ID_REF 'Hace referencia a la salida anterior
                    'mDocu.DMO_ESTADO = True
                    'mDocu.DMO_FEC_GRAB = Now
                    'mDocu.USU_ID = mControlConteo.USU_ID
                    'mDocu.MarkAsAdded()

                    'repDocu.Maintenance(mDocu)

                    'For Each mRow As DataRow In mDt.Rows
                    '    If mRow("Cant_MP_M3_Rec") > 0 Then


                    '        Dim nDMD As New DocuMovimientoDetalle
                    '        With nDMD
                    '            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    '            .DMO_ID = mDocu.DMO_ID
                    '            If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    '                .ALM_ID = Parametro.GetById("AlmRPLAN01").PAR_VALOR1  'Almacen Reciclaje Planta 1
                    '            Else
                    '                .ALM_ID = Parametro.GetById("AlmRPLAN02").PAR_VALOR1  'Almacen Reciclaje Planta 2
                    '            End If
                    '            .ART_ID = mRow("Art_Id")
                    '            .DMD_CANTIDAD = mRow("Cant_MP_M3_Rec")
                    '            .DMD_PRECIO_UNITARIO = mRow("DMD_PRECIO_UNITARIO")
                    '            .DMD_IGV = 0
                    '            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    '            .DMD_GLOSA = "Ingreso Almacen Reciclado desde Almacen Planta /" & mControlConteo.PRO_ID.ToString & "/"
                    '            .MarkAsAdded()
                    '        End With
                    '        repDetaDocu.Maintenance(nDMD)
                    '        ValTotalMP = ValTotalMP - nDMD.DMD_CONTRAVALOR



                    '        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    '            'Movimientos de kardex
                    '            Dim mKar As New Kardex
                    '            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    '            mKar.ART_ID = nDMD.ART_ID
                    '            mKar.ALM_ID = nDMD.ALM_ID
                    '            mKar.DMD_ID = nDMD.DMD_ID
                    '            mKar.KAR_FECHA = mDocu.DMO_FECHA
                    '            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    '                mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                    '                mKar.KAR_SALIDA = 0
                    '                'mKar.KAR_SALDO =
                    '                mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                    '                mKar.KAR_SALIDA_VAL = 0
                    '                'mKar.KAR_SALDO_VAL =
                    '                'mKar.KAR_COSTO_PROMEDIO=
                    '            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    '                mKar.KAR_INGRESO = 0
                    '                mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                    '                'mKar.KAR_SALDO =
                    '                mKar.KAR_INGRESO_VAL = 0
                    '                mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                    '                'mKar.KAR_SALDO_VAL =
                    '                'mKar.KAR_COSTO_PROMEDIO=
                    '            End If
                    '            kardex.Maintenance(mKar)
                    '        End If
                    '        'kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)
                    '    End If
                    'Next



                    ' '''''''''''''''''SALIDA ALMACEN reciclaje PLANTA
                    'mDocu = New DocuMovimiento
                    'mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    'mDocu.DMO_FECHA = mProd.PRO_FECHA
                    'mDocu.DTD_ID = "016"
                    'mDocu.TDO_ID = "007" 'Nota de Salida
                    'mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("016")
                    'If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    '    mDocu.DMO_SERIE = "RP01"
                    'Else
                    '    mDocu.DMO_SERIE = "RP02"
                    'End If
                    'mDocu.DMO_NRO = mControlConteo.CCO_ID
                    'mDocu.DMO_FECHA_DOCUMENTO = mControlConteo.CCO_FECHA
                    'mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    'mDocu.PRO_ID = mControlConteo.PRO_ID
                    'mDocu.MON_ID = "001" 'Soles
                    'mDocu.DOCU_AFECTA_KARDEX = True
                    'mDocu.DMO_ESTADO = True
                    'mDocu.DMO_FEC_GRAB = Now
                    'mDocu.USU_ID = mControlConteo.USU_ID
                    'mDocu.MarkAsAdded()

                    'repDocu.Maintenance(mDocu)

                    'For Each mRow As DataRow In mDt.Rows
                    '    If mRow("Cant_MP_M3_Rec") > 0 Then


                    '        Dim nDMD As New DocuMovimientoDetalle
                    '        With nDMD
                    '            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    '            .DMO_ID = mDocu.DMO_ID
                    '            If mProd.PLA_ID = 17 Then 'Eno_Id Planta 1
                    '                .ALM_ID = Parametro.GetById("AlmRPLAN01").PAR_VALOR1  'Almacen Reciclaje Planta 1
                    '            Else
                    '                .ALM_ID = Parametro.GetById("AlmRPLAN02").PAR_VALOR1  'Almacen Reciclaje Planta 2
                    '            End If
                    '            .ART_ID = mRow("Art_Id")
                    '            .DMD_CANTIDAD = mRow("Cant_MP_M3_Rec")
                    '            .DMD_PRECIO_UNITARIO = mRow("DMD_PRECIO_UNITARIO")
                    '            .DMD_IGV = 0
                    '            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    '            .DMD_GLOSA = "Salida Almacen Reciclado Planta hacia Almacen Materia Prima /" & mControlConteo.PRO_ID.ToString & "/"
                    '            .MarkAsAdded()
                    '        End With
                    '        repDetaDocu.Maintenance(nDMD)


                    '        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    '            'Movimientos de kardex
                    '            Dim mKar As New Kardex
                    '            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    '            mKar.ART_ID = nDMD.ART_ID
                    '            mKar.ALM_ID = nDMD.ALM_ID
                    '            mKar.DMD_ID = nDMD.DMD_ID
                    '            mKar.KAR_FECHA = mDocu.DMO_FECHA
                    '            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    '                mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                    '                mKar.KAR_SALIDA = 0
                    '                'mKar.KAR_SALDO =
                    '                mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                    '                mKar.KAR_SALIDA_VAL = 0
                    '                'mKar.KAR_SALDO_VAL =
                    '                'mKar.KAR_COSTO_PROMEDIO=
                    '            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    '                mKar.KAR_INGRESO = 0
                    '                mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                    '                'mKar.KAR_SALDO =
                    '                mKar.KAR_INGRESO_VAL = 0
                    '                mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                    '                'mKar.KAR_SALDO_VAL =
                    '                'mKar.KAR_COSTO_PROMEDIO=
                    '            End If
                    '            kardex.Maintenance(mKar)
                    '        End If
                    '        'kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)
                    '    End If
                    'Next


                    'mDMO_ID_REF = mDocu.DMO_ID


                    ' '''''''''''''''''INGRESO ALMACEN MATERIA PRIMA - SOLO RECICLADO CRUDO
                    'mDocu = New DocuMovimiento
                    'mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    'mDocu.DMO_FECHA = mProd.PRO_FECHA.Value.AddDays(1)
                    'mDocu.DTD_ID = "015"
                    'mDocu.TDO_ID = "006" 'Nota de Ingreso
                    'mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")
                    'mDocu.DMO_SERIE = "AMP0"
                    'mDocu.DMO_NRO = mControlConteo.CCO_ID
                    'mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    'mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    'mDocu.PRO_ID = mControlConteo.PRO_ID
                    'mDocu.MON_ID = "001" 'Soles
                    'mDocu.DOCU_AFECTA_KARDEX = True
                    'mDocu.DMO_ID_REF = mDMO_ID_REF 'Hace referencia a la salida anterior
                    'mDocu.DMO_ESTADO = True
                    'mDocu.DMO_FEC_GRAB = Now
                    'mDocu.USU_ID = mControlConteo.USU_ID
                    'mDocu.MarkAsAdded()

                    'repDocu.Maintenance(mDocu)

                    'For Each mRow As DataRow In mDt.Rows
                    '    If mRow("Cant_MP_M3_Rec") > 0 Then


                    '        Dim nDMD As New DocuMovimientoDetalle
                    '        With nDMD
                    '            .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    '            .DMO_ID = mDocu.DMO_ID
                    '            .ALM_ID = Parametro.GetById("Almmp").PAR_VALOR1  'Almacen materia prima
                    '            .ART_ID = "021413"
                    '            .DMD_CANTIDAD = mRow("Cant_MP_M3_Rec")
                    '            .DMD_PRECIO_UNITARIO = mRow("DMD_PRECIO_UNITARIO")
                    '            .DMD_IGV = 0
                    '            .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    '            .DMD_GLOSA = "Ingreso→ Almacen Materia Prima Reciclado desde Almacen Reciclado Planta /" & mControlConteo.PRO_ID.ToString & "/"
                    '            .MarkAsAdded()
                    '        End With
                    '        repDetaDocu.Maintenance(nDMD)


                    '        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                    '            'Movimientos de kardex
                    '            Dim mKar As New Kardex
                    '            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                    '            mKar.ART_ID = nDMD.ART_ID
                    '            mKar.ALM_ID = nDMD.ALM_ID
                    '            mKar.DMD_ID = nDMD.DMD_ID
                    '            mKar.KAR_FECHA = mDocu.DMO_FECHA
                    '            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    '                mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                    '                mKar.KAR_SALIDA = 0
                    '                'mKar.KAR_SALDO =
                    '                mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                    '                mKar.KAR_SALIDA_VAL = 0
                    '                'mKar.KAR_SALDO_VAL =
                    '                'mKar.KAR_COSTO_PROMEDIO=
                    '            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    '                mKar.KAR_INGRESO = 0
                    '                mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                    '                'mKar.KAR_SALDO =
                    '                mKar.KAR_INGRESO_VAL = 0
                    '                mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                    '                'mKar.KAR_SALDO_VAL =
                    '                'mKar.KAR_COSTO_PROMEDIO=
                    '            End If
                    '            kardex.Maintenance(mKar)
                    '        End If
                    '        'kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)
                    '    End If
                    'Next
                    '' ''''''''''''''''''''''Pasar a Spring Reciclado de MP
                    ''If Interfase_IngresoMP(mDocu.DMO_ID) = "0" Then
                    ''    Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                    ''End If
                    '' ''''''''''''''''''''''''''''''''''''



                    ' '''''''''''''''''INGRESO ALMACEN SECADO (CANCHA/SECADERO)
                    'mDocu = New DocuMovimiento
                    'mListDet = New List(Of DocuMovimientoDetalle)
                    'mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    'mDocu.DMO_FECHA = mProd.PRO_FECHA
                    'mDocu.DTD_ID = "015"
                    'mDocu.TDO_ID = "006" 'Nota de Ingreso
                    'mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("015")

                    'mDocu.DMO_SERIE = "ACS0"

                    'mDocu.DMO_NRO = mControlConteo.CCO_ID
                    'mDocu.DMO_FECHA_DOCUMENTO = mProd.PRO_FECHA
                    'mDocu.CCO_ID_CONTEO = mControlConteo.CCO_ID
                    'mDocu.PRO_ID = mControlConteo.PRO_ID
                    'mDocu.MON_ID = "001" 'Soles
                    'mDocu.DOCU_AFECTA_KARDEX = True
                    'mDocu.DMO_ID_REF = mDMO_ID_REF 'Hace referencia a la salida anterior
                    'mDocu.DMO_ESTADO = True
                    'mDocu.DMO_FEC_GRAB = Now
                    'mDocu.USU_ID = mControlConteo.USU_ID
                    'mDocu.MarkAsAdded()

                    'repDocu.Maintenance(mDocu)

                    'For Each mItem In mLista

                    '    Dim nDMD As New DocuMovimientoDetalle
                    '    With nDMD
                    '        .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                    '        .DMO_ID = mDocu.DMO_ID
                    '        .ALM_ID = mItem.Cancha.ALM_ID 'Almacen de Cancha o Secadero
                    '        .ART_ID = mProd.LAD_ID
                    '        .DMD_CANTIDAD = mItem.DCC_CANTIDAD
                    '        .DMD_PRECIO_UNITARIO = ValTotalMP / mItem.DCC_CANTIDAD
                    '        .DMD_IGV = 0
                    '        .DMD_CONTRAVALOR = .DMD_CANTIDAD * .DMD_PRECIO_UNITARIO
                    '        .DMD_GLOSA = "Ingreso de Ladrillos desde Almacen Planta /" & mControlConteo.PRO_ID.ToString & "/"
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
                    '    'kardex.RehacerKardex(mItem.ART_ID, mItem.ALM_ID, mDocu.DMO_FECHA)
                    'Next



                    '' ''''''''''''''''''''''Pasar a Spring
                    ''If Interfase_Conteo(mControlConteo.CCO_ID) = "0" Then
                    ''    Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                    ''End If
                    '' ''''''''''''''''''''''''''''''''''''


                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ValidarConteo(ByVal CPA_ID As Integer) As String Implements IBCControlConteo.ValidarConteo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spValidarConteo", CPA_ID)
                Dim ds As New DataSet
                Dim rea As New StringReader(result)
                ds.ReadXml(rea)
                result = ds.Tables(0).Rows(0).Item(0)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ControlConteoGetByIdPRO(ByVal PRO_ID As Integer) As BE.ControlConteo Implements IBCControlConteo.ControlConteoGetByIdPRO
            Dim result As ControlConteo = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IControlConteoRepositorio)()
                result = rep.GetByIdPRO(PRO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_Pre_Conteo(ByVal PRO_ID As Object) As System.Data.DataTable Implements IBCControlConteo.Interfase_Pre_Conteo
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spInterfase_Pre_Conteo", PRO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ConteoxFecha() As System.Data.DataTable Implements IBCControlConteo.ConteoxFecha
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporteTable("spConteoxFecha")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_Conteo(ByVal CCO_ID As Integer) As String Implements IBCControlConteo.Interfase_Conteo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spInterfase_Conteo", CCO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_IngresoMP(ByVal DMO_ID As Integer) As String Implements IBCControlConteo.Interfase_IngresoMP
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spInterfase_IngresoMP", DMO_ID)
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
