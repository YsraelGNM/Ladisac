Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCKardexCtaCte
        Implements IBCKardexCtaCte



        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Public Function Mantenimiento(ByVal Item As BE.KardexCtaCte) As Short Implements IBCKardexCtaCte.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    If Item.ChangeTracker.State <> ObjectState.Deleted Then
                        If Item.ProcesarVerificarDatos() = 0 Then
                            Mantenimiento = 0
                            Exit Function
                        End If
                    End If
                    Mantenimiento = rep.Maintenance(Item)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Item.vMensajeError = ex.Message
                Else
                    Item.vMensajeError = ex.InnerException.Message
                End If
                Mantenimiento = 0
            End Try
        End Function

        Public Function SaldoDocumentoXML(ByVal Filtro As String) As String Implements IBCKardexCtaCte.SaldoDocumentoXML
            Dim result As Decimal = 0
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spSaldoDocumentoMontoNoCeroXML, Filtro))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarDecimalXML(sr, "SALDO")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ItemKardexCtaCte(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDoc_Serie As String, ByVal cDoc_Numero As String) As Integer Implements IBCKardexCtaCte.ItemKardexCtaCte
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spItemKardexCtaCteXML, cTdo_Id, cDtd_Id, cDoc_Serie, cDoc_Numero))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEnteroXML(sr, "item")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ItemKardexCtaCteExtorno(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDoc_Serie As String, ByVal cDoc_Numero As String) As Integer Implements IBCKardexCtaCte.ItemKardexCtaCteExtorno
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spItemKardexCtaCteExtornoXML, cTdo_Id, cDtd_Id, cDoc_Serie, cDoc_Numero))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEnteroXML(sr, "item")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ItemKardexCtaCteDudosa(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDoc_Serie As String, ByVal cDoc_Numero As String, ByVal cPER_ID_CLI As String) As Integer Implements IBCKardexCtaCte.ItemKardexCtaCteDudosa
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spItemKardexCtaCteDudosaXML, cTdo_Id, cDtd_Id, cDoc_Serie, cDoc_Numero, cPER_ID_CLI))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEnteroXML(sr, "item")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ItemKardexCtaCteLegal(ByVal cTdo_Id As String, ByVal cDtd_Id As String, ByVal cDoc_Serie As String, ByVal cDoc_Numero As String, ByVal cPER_ID_CLI As String) As Integer Implements IBCKardexCtaCte.ItemKardexCtaCteLegal
            Dim result As String = ""
            Try
                Dim sr As New IO.StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spItemKardexCtaCteLegalXML, cTdo_Id, cDtd_Id, cDoc_Serie, cDoc_Numero, cPER_ID_CLI))
                Dim rep = ContainerService.Resolve(Of DA.IBusquedaRepositorio)()
                result = rep.SolicitarEnteroXML(sr, "item")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DeleteRegistro(ByVal item As BE.KardexCtaCte, ByVal cDOCUMENTO As String, ByVal cITEM As Short) As Short Implements IBCKardexCtaCte.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cDOCUMENTO, cITEM)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    item.vMensajeError = ex.Message
                Else
                    item.vMensajeError = ex.InnerException.Message
                End If
                DeleteRegistro = 0
            End Try
        End Function

        Public Function spActualizarRegistro(ByVal cDOC_FECHA_EMI_REF As Date, ByVal cDOC_FECHA_VEN_REF As Date, ByVal cCUC_ID_REF As String, ByVal cCCO_ID_REF As String, ByVal cCCC_ID_REF As String, ByVal cCCT_ID_REF As String, ByVal cTDO_ID_REF As String, ByVal cDTD_ID_REF As String, ByVal cDOC_SERIE_REF As String, ByVal cDOC_NUMERO_REF As String, ByVal cITEM_REF As Short, ByVal cMON_ID_CCC As String, ByVal cCCC_ID As String, ByVal cCCT_ID As String, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDOC_SERIE As String, ByVal cDOC_NUMERO As String, ByVal cITEM As Short, ByVal cMON_ID As String, ByVal cPER_ID_CLI As String, ByVal cCARGO As Double, ByVal cABONO As Double, ByVal cDTE_CONTRAVALOR_DOC As Double, ByVal cMPT_MEDIO_PAGO As Short, ByVal cMPT_NUMERO_MEDIO As String, ByVal cPER_ID_BAN As String, ByVal cDOCUMENTO As String) As Short Implements IBCKardexCtaCte.spActualizarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                    rep.spActualizarRegistro(cDOC_FECHA_EMI_REF, cDOC_FECHA_VEN_REF, cCUC_ID_REF, cCCO_ID_REF, cCCC_ID_REF, cCCT_ID_REF, cTDO_ID_REF, cDTD_ID_REF, cDOC_SERIE_REF, cDOC_NUMERO_REF, cITEM_REF, cMON_ID_CCC, cCCC_ID, cCCT_ID, cTDO_ID, cDTD_ID, cDOC_SERIE, cDOC_NUMERO, cITEM, cMON_ID, cPER_ID_CLI, cCARGO, cABONO, cDTE_CONTRAVALOR_DOC, cMPT_MEDIO_PAGO, cMPT_NUMERO_MEDIO, cPER_ID_BAN, cDOCUMENTO)
                    Scope.Complete()
                    spActualizarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spActualizarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistro(ByVal cITEM As Short, ByVal cDOCUMENTO As String) As Short Implements IBCKardexCtaCte.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                    rep.spEliminarRegistro(cITEM, cDOCUMENTO)
                    Scope.Complete()
                    spEliminarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistroExtorno(ByVal cITEM As Short, ByVal cDOCUMENTO As String) As Short Implements IBCKardexCtaCte.spEliminarRegistroExtorno
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                    rep.spEliminarRegistroExtorno(cITEM, cDOCUMENTO)
                    Scope.Complete()
                    spEliminarRegistroExtorno = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistroExtorno = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistroCobranza(ByVal cITEM As Short, ByVal cDOCUMENTO As String, ByVal cPER_ID_CLI As String) As Short Implements IBCKardexCtaCte.spEliminarRegistroCobranza
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                    rep.spEliminarRegistroCobranza(cITEM, cDOCUMENTO, cPER_ID_CLI)
                    Scope.Complete()
                    spEliminarRegistroCobranza = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistroCobranza = 0
                End Try
            End Using
        End Function

        Public Function spEliminarRegistroLegal(ByVal cITEM As Short, ByVal cDOCUMENTO As String, ByVal cPER_ID_CLI As String) As Short Implements IBCKardexCtaCte.spEliminarRegistroLegal
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                    rep.spEliminarRegistroLegal(cITEM, cDOCUMENTO, cPER_ID_CLI)
                    Scope.Complete()
                    spEliminarRegistroLegal = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistroLegal = 0
                End Try
            End Using
        End Function

        Public Function spInsertarRegistro(ByVal cDOC_FECHA_EMI_REF As Date, ByVal cDOC_FECHA_VEN_REF As Date, ByVal cCUC_ID_REF As String, ByVal cCCO_ID_REF As String, ByVal cCCC_ID_REF As String, ByVal cCCT_ID_REF As String, ByVal cTDO_ID_REF As String, ByVal cDTD_ID_REF As String, ByVal cDOC_SERIE_REF As String, ByVal cDOC_NUMERO_REF As String, ByVal cITEM_REF As Short, ByVal cMON_ID_CCC As String, ByVal cCCC_ID As String, ByVal cCCT_ID As String, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDOC_SERIE As String, ByVal cDOC_NUMERO As String, ByVal cITEM As Short, ByVal cMON_ID As String, ByVal cPER_ID_CLI As String, ByVal cCARGO As Double, ByVal cABONO As Double, ByVal cDTE_CONTRAVALOR_DOC As Double, ByVal cMPT_MEDIO_PAGO As Short, ByVal cMPT_NUMERO_MEDIO As String, ByVal cPER_ID_BAN As String, ByVal cDOCUMENTO As String) As Short Implements IBCKardexCtaCte.spInsertarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                    rep.spInsertarRegistro(cDOC_FECHA_EMI_REF, cDOC_FECHA_VEN_REF, cCUC_ID_REF, cCCO_ID_REF, cCCC_ID_REF, cCCT_ID_REF, cTDO_ID_REF, cDTD_ID_REF, cDOC_SERIE_REF, cDOC_NUMERO_REF, cITEM_REF, cMON_ID_CCC, cCCC_ID, cCCT_ID, cTDO_ID, cDTD_ID, cDOC_SERIE, cDOC_NUMERO, cITEM, cMON_ID, cPER_ID_CLI, cCARGO, cABONO, cDTE_CONTRAVALOR_DOC, cMPT_MEDIO_PAGO, cMPT_NUMERO_MEDIO, cPER_ID_BAN, cDOCUMENTO)
                    Scope.Complete()
                    spInsertarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spInsertarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spSaldosTipoCliente(ByVal idTipoCliente As String, ByVal fechaHasta As Date) As Object Implements IBCKardexCtaCte.spSaldosTipoCliente
            Dim result As DataTable = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spSaldosTipoCliente, idTipoCliente, fechaHasta)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function spDepositoTerceros(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal responsable As String, ByVal Banco As String, ByVal Cliente As String, ByVal DepositoTerceroNcargo As String) As Object Implements IBCKardexCtaCte.spDepositoTerceros
            Dim result As DataTable = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spDepositoTerceros, fechaInicio, fechaFin, responsable, Banco, Cliente, DepositoTerceroNcargo)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function spEliminarRegistroVoucher(ByVal cITEM As Short, ByVal cCCC_ID As String, ByVal cDOCUMENTO As String) As Short Implements IBCKardexCtaCte.spEliminarRegistroVoucher
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IKardexCtaCteRepositorio)()
                    rep.spEliminarRegistroVoucher(cITEM, cCCC_ID, cDOCUMENTO)
                    Scope.Complete()
                    spEliminarRegistroVoucher = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spEliminarRegistroVoucher = 0
                End Try
            End Using
        End Function


        Public Function SpMovimientoCajaPorOrigen(ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCKardexCtaCte.SpMovimientoCajaPorOrigen
            ''movimiento caja por origen 
            ''movimiento para finanzas 
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SpMovimientoCajaPorOrigen, fechaDesde, fechaHasta)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function SpMovimientoCajaPorOrigenDetalle(ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCKardexCtaCte.SpMovimientoCajaPorOrigenDetalle
            ''movimiento caja por origen 
            ''movimiento para finanzas 
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.SpMovimientoCajaPorOrigenDetalle, fechaDesde, fechaHasta)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spContraEntregaPendienteCancelar(ByVal desde As Date, ByVal hasta As Date, ByVal persona As String) As Object Implements IBCKardexCtaCte.spContraEntregaPendienteCancelar
            'reporte 
            Dim result As DataTable = Nothing

            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spContraEntregaPendienteCancelar, desde, hasta, persona)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result

        End Function


        Public Function spVentaDiariaFinanzas(ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCKardexCtaCte.spVentaDiariaFinanzas
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spVentaDiariaFinanzas, fechaDesde, fechaHasta)
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
