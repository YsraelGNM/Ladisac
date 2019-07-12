Imports Ladisac.BE
Imports System.IO

Namespace Ladisac.BL

    Public Class BCSalidaCombustible
        Implements IBCSalidaCombustible

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub MantenimientoSalidaCombustible(ByVal mSalidaCombustible As BE.SalidaCombustible) Implements IBCSalidaCombustible.MantenimientoSalidaCombustible
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISalidaCombustibleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Dim repDocu = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                Dim repDetaDocu = ContainerService.Resolve(Of DA.IDocuMovimientoDetalleRepositorio)()

                Dim repKardexCtaCte = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                Dim mKCC As New KardexCtaCte

                Dim mCorre = ContainerService.Resolve(Of DA.ICorrelativoTipoDocumentoRepositorio)()
                Dim Compuesto2 As New CorrelativoTipoDocumento

                Dim kardex = ContainerService.Resolve(Of DA.IKardexRepositorio)()

                Dim controlgrifo = ContainerService.Resolve(Of DA.IControlGrifoRepositorio)()
                Dim ord = ContainerService.Resolve(Of DA.IOrdenRequerimientoDetalleRepositorio)()
                Dim Flag As Boolean

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mSalidaCombustible.ChangeTracker.State = ObjectState.Added) Then
                        mSalidaCombustible.SCO_ID = bcherramientas.Get_Id("SalidaCombustible")
                        Flag = True
                    ElseIf (mSalidaCombustible.ChangeTracker.State = ObjectState.Modified) Then
                        Flag = False
                    End If

                    rep.Maintenance(mSalidaCombustible)

                    If mSalidaCombustible.MessageId.Length > 0 Then
                        Dim CGrifo As New ControlGrifo
                        CGrifo = controlgrifo.GetById(mSalidaCombustible.MessageId)
                        CGrifo.Estado = 2
                        CGrifo.MarkAsModified()
                        controlgrifo.Maintenance(CGrifo)
                    End If

                    Dim mDocu As New DocuMovimiento

                    mDocu = repDocu.GetByIdSCO(mSalidaCombustible.SCO_ID)
                    If mDocu IsNot Nothing Then
                        For Each mitem In mDocu.DocuMovimientoDetalle
                            If mitem.Kardex.Count > 0 Then mitem.Kardex(0).MarkAsDeleted()
                            mitem.MarkAsDeleted()
                        Next
                        mDocu.MarkAsDeleted()
                        repDocu.Maintenance(mDocu)
                    End If

                    mDocu = New DocuMovimiento

                    mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    mDocu.DMO_FECHA = mSalidaCombustible.SCO_FECHA
                    mDocu.DTD_ID = mSalidaCombustible.DTD_ID
                    mDocu.TDO_ID = mSalidaCombustible.TDO_ID
                    mDocu.CCT_ID = mSalidaCombustible.CCT_ID
                    mDocu.DetalleTipoDocumentos = mSalidaCombustible.DetalleTipoDocumentos
                    mDocu.DMO_SERIE = mSalidaCombustible.SCO_SERIE
                    mDocu.DMO_NRO = mSalidaCombustible.SCO_NUMERO
                    mDocu.DMO_FECHA_DOCUMENTO = mSalidaCombustible.SCO_FECHA
                    mDocu.SCO_ID = mSalidaCombustible.SCO_ID
                    mDocu.MON_ID = "001" 'Soles
                    mDocu.DOCU_AFECTA_KARDEX = True
                    mDocu.DMO_ESTADO = True
                    mDocu.DMO_FEC_GRAB = Now
                    mDocu.USU_ID = mSalidaCombustible.USU_ID
                    mDocu.MarkAsAdded()

                    repDocu.Maintenance(mDocu)

                    Dim nDMD As New DocuMovimientoDetalle
                    With nDMD
                        .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                        .DMO_ID = mDocu.DMO_ID
                        .ALM_ID = mSalidaCombustible.ALM_ID
                        .ART_ID = mSalidaCombustible.ART_ID
                        .DMD_CANTIDAD = mSalidaCombustible.SCO_CANTIDAD
                        .DMD_PRECIO_UNITARIO = (mSalidaCombustible.SCO_PRECIO_UNITARIO / ((mSalidaCombustible.IGV / 100) + 1))
                        .DMD_IGV = mSalidaCombustible.IGV
                        .DMD_CONTRAVALOR = mSalidaCombustible.SCO_CANTIDAD * (mSalidaCombustible.SCO_PRECIO_UNITARIO / ((mSalidaCombustible.IGV / 100) + 1))
                        .DMD_GLOSA = mSalidaCombustible.SCO_OBSERVACION
                        .ORD_ID = mSalidaCombustible.ORD_ID
                        .MarkAsAdded()
                    End With
                    repDetaDocu.Maintenance(nDMD)

                    Dim mOrd As New OrdenRequerimientoDetalle
                    mOrd = ord.GetById(mSalidaCombustible.ORD_ID)
                    mOrd.ORD_CANTIDAD_ATENDIDA = mOrd.ORD_CANTIDAD_ATENDIDA + mSalidaCombustible.SCO_CANTIDAD
                    mOrd.ORD_ESTADO_COMPRA = Nothing
                    mOrd.ORD_OBS_COMPRA = Nothing
                    mOrd.ORD_CANTIDAD_COMPRA = Nothing
                    mOrd.MarkAsModified()
                    ord.Maintenance(mOrd)

                    If mDocu.DOCU_AFECTA_KARDEX And Not nDMD.ART_ID Is Nothing Then
                        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA <> 0 Then '1 = + ; 2 = -
                            'Movimientos de kardex
                            Dim mKar As New Kardex
                            mKar.KAR_ID = bcherramientas.Get_Id("Kardex")
                            mKar.ART_ID = nDMD.ART_ID
                            mKar.ALM_ID = nDMD.ALM_ID
                            mKar.DMD_ID = nDMD.DMD_ID
                            mKar.KAR_FECHA = mDocu.DMO_FECHA
                            If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                                mKar.KAR_INGRESO = nDMD.DMD_CANTIDAD
                                mKar.KAR_SALIDA = 0
                                'mKar.KAR_SALDO =
                                mKar.KAR_INGRESO_VAL = nDMD.DMD_CONTRAVALOR
                                mKar.KAR_SALIDA_VAL = 0
                                'mKar.KAR_SALDO_VAL =
                                'mKar.KAR_COSTO_PROMEDIO=
                            ElseIf mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                                mKar.KAR_INGRESO = 0
                                mKar.KAR_SALIDA = nDMD.DMD_CANTIDAD
                                'mKar.KAR_SALDO =
                                mKar.KAR_INGRESO_VAL = 0
                                mKar.KAR_SALIDA_VAL = nDMD.DMD_CONTRAVALOR
                                'mKar.KAR_SALDO_VAL =
                                'mKar.KAR_COSTO_PROMEDIO=
                            End If
                            kardex.Maintenance(mKar)
                        End If
                        kardex.RehacerKardex(nDMD.ART_ID, nDMD.ALM_ID, mDocu.DMO_FECHA)
                    End If

                    If Not mDocu.DTD_ID = "056" Then 'Orden Requerimiento
                        'Grabar en KardexCtacte
                        With mKCC
                            .DOC_FECHA_EMI_REF = mDocu.DMO_FECHA_DOCUMENTO
                            .DOC_FECHA_VEN_REF = mDocu.DMO_FECHA_DOCUMENTO.Value.AddDays(7)
                            .CCT_ID_REF = mDocu.CCT_ID
                            .TDO_ID_REF = mDocu.TDO_ID
                            .DTD_ID_REF = mDocu.DTD_ID
                            .DOC_SERIE_REF = mDocu.DMO_SERIE
                            .DOC_NUMERO_REF = mDocu.DMO_NRO
                            .ITEM_REF = 1 'Numero Fila
                            .MON_ID_CCC = mDocu.MON_ID
                            .CCT_ID = mDocu.CCT_ID
                            .TDO_ID = mDocu.TDO_ID
                            .DTD_ID = mDocu.DTD_ID
                            .DOC_SERIE = mDocu.DMO_SERIE
                            .DOC_NUMERO = mDocu.DMO_NRO
                            .ITEM = 1 'Numero Fila
                            .MON_ID = mDocu.MON_ID
                            .PER_ID_CLI = mSalidaCombustible.PER_ID_EMPRESA
                            .CARGO = mSalidaCombustible.SCO_PRECIO_UNITARIO * mSalidaCombustible.SCO_CANTIDAD
                            .ABONO = 0
                            .DTE_CONTRAVALOR_DOC = 0
                            .MPT_MEDIO_PAGO = 0
                            .MPT_NUMERO_MEDIO = ""
                            .DOCUMENTO = mDocu.TDO_ID & mDocu.DTD_ID & mDocu.DMO_SERIE & mDocu.DMO_NRO
                            .TIPO = "N"
                        End With
                        If Not Flag Then repKardexCtaCte.DeleteRegistro(mKCC, mDocu.TDO_ID & mDocu.DTD_ID & mDocu.DMO_SERIE & mDocu.DMO_NRO, 1)
                        mKCC.MarkAsAdded()
                        repKardexCtaCte.Maintenance(mKCC)

                        '''''''''''''''''''''Actualizar correlativo
                        If Flag Then
                            ' Correlativo de serie
                            Compuesto2.TDO_ID = mKCC.TDO_ID
                            Compuesto2.PVE_ID = "002"
                            Compuesto2.CTD_COR_SERIE = mKCC.DOC_SERIE
                            Compuesto2.CTD_COR_NUMERO = Val(mKCC.DOC_NUMERO) + 1
                            Compuesto2.CTD_USAR_COR = True
                            Compuesto2.USU_ID = mSalidaCombustible.USU_ID
                            Compuesto2.CTD_FEC_GRAB = Now
                            Compuesto2.CTD_ESTADO = True
                            Compuesto2.MarkAsModified()
                            mCorre.Maintenance(Compuesto2)
                            '''''''''''''''''''''''
                        End If
                    End If

                    ' ''''''''''''''''''''''Pasar a Spring
                    'If Interfase_SalidaGrifo(mSalidaCombustible.SCO_ID) = "0" Then
                    '    Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                    'End If
                    ' ''''''''''''''''''''''''''''''''''''
                    Scope.Complete()
                End Using

                ActualizarIdGrifo(mSalidaCombustible.Id_Grifo)



                ''''''''''''''''''''''Pasar a Spring
                mSalidaCombustible = SalidaCombustibleGetById(mSalidaCombustible.SCO_ID)
                If Interfase_SalidaGrifo(mSalidaCombustible.SCO_ID) = "0" Then
                    Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                End If
                If Interfase_PasarSpring(mSalidaCombustible.SCO_FECHA, "NS", mSalidaCombustible.Articulos.Item) = "0" Then
                    Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                End If
                ''''''''''''''''''''''''''''''''''''

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function SalidaCombustibleGetById(ByVal SCO_ID As Integer) As BE.SalidaCombustible Implements IBCSalidaCombustible.SalidaCombustibleGetById
            Dim result As SalidaCombustible = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISalidaCombustibleRepositorio)()
                result = rep.GetById(SCO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaSalidaCombustible() As String Implements IBCSalidaCombustible.ListaSalidaCombustible
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.ISalidaCombustibleRepositorio)()
                result = rep.ListaSalidaCombustible
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ObtenerDatoGrifo() As String Implements IBCSalidaCombustible.ObtenerDatoGrifo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spObtenerDatoGrifo")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ActualizarIdGrifo(ByVal mId_Grifo As Integer) As String Implements IBCSalidaCombustible.ActualizarIdGrifo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spActualizarDatoGrifo", mId_Grifo)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_SalidaGrifo(ByVal SCO_ID As Integer) As String Implements IBCSalidaCombustible.Interfase_SalidaGrifo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spInterfase_SalidaGrifo", SCO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_PasarSpring(Fecha As Date, TipoTransaccion As String, Item As String) As String Implements IBCSalidaCombustible.Interfase_PasarSpring
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
