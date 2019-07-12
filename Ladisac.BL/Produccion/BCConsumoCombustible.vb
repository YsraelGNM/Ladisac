Imports Ladisac.BE

Namespace Ladisac.BL

    Public Class BCConsumoCombustible
        Implements IBCConsumoCombustible

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function ConsumoCombustibleGetById(ByVal CCO_ID As Integer) As BE.ConsumoCombustible Implements IBCConsumoCombustible.ConsumoCombustibleGetById
            Dim result As ConsumoCombustible = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConsumoCombustibleRepositorio)()
                result = rep.GetById(CCO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaConsumoCombustible() As String Implements IBCConsumoCombustible.ListaConsumoCombustible
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConsumoCombustibleRepositorio)()
                result = rep.ListaConsumoCombustible
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub MantenimientoConsumoCombustible(ByVal mConsumoCombustible As BE.ConsumoCombustible) Implements IBCConsumoCombustible.MantenimientoConsumoCombustible
            Try
                Dim rep = ContainerService.Resolve(Of DA.IConsumoCombustibleRepositorio)()
                Dim bcherramientas = ContainerService.Resolve(Of BL.IBCHerramientas)()

                Dim repDocu = ContainerService.Resolve(Of DA.IDocuMovimientoRepositorio)()
                Dim repDetaDocu = ContainerService.Resolve(Of DA.IDocuMovimientoDetalleRepositorio)()
                Dim repDetalleTipoDocumento = ContainerService.Resolve(Of DA.IDetalleTipoDocumentoRepositorio)()
                Dim kardex = ContainerService.Resolve(Of DA.IKardexRepositorio)()

                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)

                    If (mConsumoCombustible.ChangeTracker.State = ObjectState.Added) Then
                        mConsumoCombustible.CCO_ID = bcherramientas.Get_Id("ConsumoCombustible")
                    ElseIf (mConsumoCombustible.ChangeTracker.State = ObjectState.Modified) Then

                    End If

                    rep.Maintenance(mConsumoCombustible)



                    ''''''''''''''''' INGRESO ALMACEN
                    Dim mDocu As New DocuMovimiento

                    mDocu = repDocu.GetByIdCCO(mConsumoCombustible.CCO_ID) 'Para que borre el documento antes de guardarlo
                    If mDocu IsNot Nothing Then
                        For Each mitem In mDocu.DocuMovimientoDetalle
                            mitem.Kardex(0).MarkAsDeleted()
                            mitem.MarkAsDeleted()
                        Next
                        mDocu.MarkAsDeleted()
                        repDocu.Maintenance(mDocu)
                    End If

                    mDocu = New DocuMovimiento

                    mDocu.DMO_ID = bcherramientas.Get_Id("DocuMovimiento")
                    mDocu.DMO_FECHA = mConsumoCombustible.CCO_FECHA
                    mDocu.DTD_ID = "016"
                    mDocu.TDO_ID = "007" 'Nota de Egreso
                    mDocu.DetalleTipoDocumentos = repDetalleTipoDocumento.GetById("016")
                    mDocu.DMO_SERIE = "050"
                    mDocu.DMO_NRO = mConsumoCombustible.CCO_ID
                    mDocu.DMO_FECHA_DOCUMENTO = mConsumoCombustible.CCO_FECHA
                    mDocu.CCO_ID = mConsumoCombustible.CCO_ID
                    mDocu.MON_ID = "001" 'Soles
                    mDocu.DOCU_AFECTA_KARDEX = True
                    mDocu.DMO_ESTADO = True
                    mDocu.DMO_FEC_GRAB = Now
                    mDocu.USU_ID = mConsumoCombustible.USU_ID
                    mDocu.MarkAsAdded()

                    repDocu.Maintenance(mDocu)


                    Dim nDMD As New DocuMovimientoDetalle
                    With nDMD
                        .DMD_ID = bcherramientas.Get_Id("DocuMovimientoDetalle")
                        .DMO_ID = mDocu.DMO_ID
                        .ALM_ID = mConsumoCombustible.ALM_ID
                        .ART_ID = mConsumoCombustible.ART_ID
                        .DMD_CANTIDAD = mConsumoCombustible.CCO_CANTIDAD
                        .DMD_PRECIO_UNITARIO = kardex.StockCostoPromedio(.ART_ID, .ALM_ID, mDocu.DMO_FECHA, 2)
                        .DMD_IGV = 0
                        .DMD_CONTRAVALOR = mConsumoCombustible.CCO_CANTIDAD * .DMD_PRECIO_UNITARIO
                        .DMD_GLOSA = "Salida por consumo en produccion."
                        .MarkAsAdded()
                    End With
                    repDetaDocu.Maintenance(nDMD)


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

                    Scope.Complete()
                End Using



                ''''''''''''''''''''''Pasar a Spring
                mConsumoCombustible = ConsumoCombustibleGetById(mConsumoCombustible.CCO_ID)
                If Interfase_ConsumoCombustibleHornoSecadero(mConsumoCombustible.CCO_ID) = "0" Then
                    Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                End If
                If Interfase_PasarSpring(mConsumoCombustible.CCO_FECHA, "NS", mConsumoCombustible.ArticuloAlmacen.Articulos.Item) = "0" Then
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

        Public Function Interfase_ConsumoCombustibleHornoSecadero(ByVal CCO_ID As Integer) As String Implements IBCConsumoCombustible.Interfase_ConsumoCombustibleHornoSecadero
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spInterfase_ConsumoCombustibleHornoSecadero", CCO_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function Interfase_PasarSpring(Fecha As Date, TipoTransaccion As String, Item As String) As String Implements IBCConsumoCombustible.Interfase_PasarSpring
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
