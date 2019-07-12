Imports Ladisac.BE
Namespace Ladisac.BL
    Public Class BCDespachos
        Implements IBCDespachos

        <Dependency()> _
        Public Property ContainerService As IUnityContainer
        Dim bcutil As New Ladisac.BL.BCUtil


        Public Function Mantenimiento(ByVal Item As BE.Despachos) As Short Implements IBCDespachos.Mantenimiento
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
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
        Public Function DeleteRegistro(ByVal item As BE.Despachos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDES_SERIE As String, ByVal cDES_NUMERO As String) As Short Implements IBCDespachos.DeleteRegistro
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    DeleteRegistro = rep.DeleteRegistro(item, cTDO_ID, cDTD_ID, cDES_SERIE, cDES_NUMERO)
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

        Public Function spActualizarRegistro(ByVal Orm As Despachos) As Short Implements IBCDespachos.spActualizarRegistro
            'Using Scope As New System.Transactions.TransactionScope()
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                rep.spActualizarRegistro(Orm)
                'Scope.Complete()
                spActualizarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If
                'Scope.Dispose()
                spActualizarRegistro = 0
            End Try
            'End Using
        End Function

        Public Function spEliminarRegistro(ByVal Orm As Despachos) As Short Implements IBCDespachos.spEliminarRegistro
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                    rep.spEliminarRegistro(Orm)
                    Scope.Complete()
                    spEliminarRegistro = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    If ex.InnerException Is Nothing Then
                        Orm.vMensajeError = ex.Message
                    Else
                        Orm.vMensajeError = ex.InnerException.Message
                    End If
                    Scope.Dispose()
                    spEliminarRegistro = 0
                End Try
            End Using
        End Function

        Public Function spInsertarRegistro(ByVal Orm As Despachos) As Short Implements IBCDespachos.spInsertarRegistro
            'Using Scope As New System.Transactions.TransactionScope()
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                rep.spInsertarRegistro(Orm)
                'Scope.Complete()
                spInsertarRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If
                'Scope.Dispose()
                spInsertarRegistro = 0
            End Try
            'End Using
        End Function

        Public Function spActualizarDespachosDES_ESTADO(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String, ByVal DES_ESTADO As Short) As Short Implements IBCDespachos.spActualizarDespachosDES_ESTADO
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                    rep.spActualizarDespachosDES_ESTADO(TDO_ID, DTD_ID, DES_SERIE, DES_NUMERO, DES_ESTADO)
                    Scope.Complete()
                    spActualizarDespachosDES_ESTADO = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spActualizarDespachosDES_ESTADO = 0
                End Try
            End Using
        End Function

        Public Function spActualizarDocuMovimiento(ByVal Orm As Despachos) As Short Implements IBCDespachos.spActualizarDocuMovimiento
            'Using Scope As New System.Transactions.TransactionScope()
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                rep.spActualizarDocuMovimiento(Orm)
                'Scope.Complete()
                spActualizarDocuMovimiento = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If
                'Scope.Dispose()
                spActualizarDocuMovimiento = 0
            End Try
            'End Using
        End Function

        Public Function spActualizarRegistroNullALM_ID_LLEGADA(ByVal Orm As Despachos) As Short Implements IBCDespachos.spActualizarRegistroNullALM_ID_LLEGADA
            'Using Scope As New System.Transactions.TransactionScope()
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                rep.spActualizarRegistroNullALM_ID_LLEGADA(Orm)
                'Scope.Complete()
                spActualizarRegistroNullALM_ID_LLEGADA = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If
                'Scope.Dispose()
                spActualizarRegistroNullALM_ID_LLEGADA = 0
            End Try
            'End Using
        End Function

        Public Function spInsertarRegistroNullALM_ID_LLEGADA(ByVal Orm As Despachos) As Short Implements IBCDespachos.spInsertarRegistroNullALM_ID_LLEGADA
            'Using Scope As New System.Transactions.TransactionScope()
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                rep.spInsertarRegistroNullALM_ID_LLEGADA(Orm)
                'Scope.Complete()
                spInsertarRegistroNullALM_ID_LLEGADA = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If
                'Scope.Dispose()
                spInsertarRegistroNullALM_ID_LLEGADA = 0
            End Try
            'End Using
        End Function

        Public Function spActualizarDespachosDES_FEC_SAL_PLA(ByVal Orm As BE.Despachos) As Short Implements IBCDespachos.spActualizarDespachosDES_FEC_SAL_PLA
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    spActualizarDespachosDES_FEC_SAL_PLA = rep.spActualizarDespachosDES_FEC_SAL_PLA(Orm)
                    spActualizarDespachosDES_FEC_SAL_PLA = rep.spActualizarDocuMovimiento(Orm)
                    spActualizarDespachosDES_FEC_SAL_PLA = rep.spValidarSalidaVigilancia(Orm)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If
                spActualizarDespachosDES_FEC_SAL_PLA = 0
            End Try
        End Function

        Public Function spActualizarDespachosDES_FEC_CAR_DES(ByVal Orm As BE.Despachos) As Short Implements IBCDespachos.spActualizarDespachosDES_FEC_CAR_DES
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    spActualizarDespachosDES_FEC_CAR_DES = rep.spActualizarDespachosDES_FEC_CAR_DES(Orm)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If
                spActualizarDespachosDES_FEC_CAR_DES = 0
            End Try
        End Function

        Public Function spActualizarDespachosDES_ESTADOEnDistribuidora(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String, ByVal DES_ESTADO As Short) As Short Implements IBCDespachos.spActualizarDespachosDES_ESTADOEnDistribuidora
            Using Scope As New System.Transactions.TransactionScope()
                Try
                    Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                    rep.spActualizarDespachosDES_ESTADOEnDistribuidora(TDO_ID, DTD_ID, DES_SERIE, DES_NUMERO, DES_ESTADO)
                    Scope.Complete()
                    spActualizarDespachosDES_ESTADOEnDistribuidora = 1
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                    'If (rethrow) Then
                    'Throw
                    'End If
                    'Item.vMensajeError = ex.InnerException.Message
                    Scope.Dispose()
                    spActualizarDespachosDES_ESTADOEnDistribuidora = 0
                End Try
            End Using
        End Function

        Public Function ReporteGuiasProduccionXLS(ByVal FechaInicial As Date, ByVal FechaFinal As Date, ByVal PVE_ID As String) As Object Implements IBCDespachos.ReporteGuiasProduccionXLS
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spReporteGuiasProduccion, FechaInicial, FechaFinal, PVE_ID)
                bcutil.excelExportar(result)
                Return True
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function spInsertarProgramacion(ByVal TDO_ID_CRO As String, ByVal DTD_ID_CRO As String, ByVal DES_SERIE_CRO As String, ByVal DES_NUMERO_CRO As String, ByVal TDO_ID_DES As String, ByVal DTD_ID_DES As String, ByVal DES_SERIE_DES As String, ByVal DES_NUMERO_DES As String, ByVal USU_ID As String, ByVal PRO_ESTADO As Short) As Short Implements IBCDespachos.spInsertarProgramacion
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    spInsertarProgramacion = rep.spInsertarProgramacion(TDO_ID_CRO, DTD_ID_CRO, DES_SERIE_CRO, DES_NUMERO_CRO, TDO_ID_DES, DTD_ID_DES, DES_SERIE_DES, DES_NUMERO_DES, USU_ID, PRO_ESTADO)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                'If ex.InnerException Is Nothing Then
                '    Orm.vMensajeError = ex.Message
                'Else
                '    Orm.vMensajeError = ex.InnerException.Message
                'End If
                spInsertarProgramacion = 0
            End Try
        End Function

        Public Function spReporteCronogramaDespachoXML(ByVal DES_ESTADO As Short, ByVal PER_ID_VEN As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCDespachos.spReporteCronogramaDespachoXML
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spReporteCronogramaDespachoXML, DES_ESTADO, PER_ID_VEN, fechaDesde, fechaHasta)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function spReporteCronogramaDespachoGuias(ByVal PER_ID_VEN As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date) As Object Implements IBCDespachos.spReporteCronogramaDespachoGuias
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte(DA.SPNames.spReporteCronogramaDespachoGuias, PER_ID_VEN, fechaDesde, fechaHasta)

            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return result
        End Function

        Public Function spEnviarCorreoDespacho(ByVal Orm As BE.Despachos) As Short Implements IBCDespachos.spEnviarCorreoDespacho
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    spEnviarCorreoDespacho = rep.spEnviarCorreoDespacho(Orm)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Orm.vMensajeError = ex.Message
                Else
                    Orm.vMensajeError = ex.InnerException.Message
                End If
                spEnviarCorreoDespacho = 0
            End Try
        End Function

        Public Function ListaGuiasSinDocumento() As String Implements IBCDespachos.ListaGuiasSinDocumento
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaGuiasSinDocumento")
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaDocumentoGuiaCliente(ByVal PER_ID As String, ByVal FecIni As Date, ByVal FecFin As Date, ByVal EsFechaDocumento As Boolean) As String Implements IBCDespachos.ListaDocumentoGuiaCliente
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaDocumentoGuiaCliente", PER_ID, FecIni, FecFin, EsFechaDocumento)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaAlmacenXPuntoventa(ByVal USU_ID As String) As String Implements IBCDespachos.ListaAlmacenXPuntoventa
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaAlmacenXPuntoventa", USU_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaGuiasEnTransitoPendientes(ByVal ALM_ID As Integer) As String Implements IBCDespachos.ListaGuiasEnTransitoPendientes
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaGuiasEnTransitoPendientes", ALM_ID)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Sub PasarTransito_AlmacenUsu(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String, ByVal ALM_ID_LLEGADA As Integer, ByVal USU_ID As String, ByVal DMO_FECHA As Date) Implements IBCDespachos.PasarTransito_AlmacenUsu
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spPasarTransito_AlmacenUsu", TDO_ID, DTD_ID, DES_SERIE, DES_NUMERO, ALM_ID_LLEGADA, USU_ID, DMO_FECHA)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub

        Public Function ListaGuiasPorSalir(ByVal Fecha As Date) As String Implements IBCDespachos.ListaGuiasPorSalir
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaGuiasPorSalir", Fecha)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ListaTransferenciaLadrillo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alma_Id As Integer) As String Implements IBCDespachos.ListaTransferenciaLadrillo
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaTransferenciaLadrillo", FecIni, FecFin, Alma_Id)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function ReporteOrdenDespacho(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Flag As Integer) As String Implements IBCDespachos.ReporteOrdenDespacho
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spReporteOrdenDespacho", FecIni, FecFin, Flag)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function spReporteDocumentoGuiasXLS(ByVal FecIni As Date, ByVal FecFin As Date) As String Implements IBCDespachos.spReporteDocumentoGuiasXLS
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte("spReporteDocumentoGuias", FecIni, FecFin)
                bcutil.excelExportar(result)
                Return True
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function spListaProcesoTerminadoXLS(ByVal FecFin As Date) As String Implements IBCDespachos.spListaProcesoTerminadoXLS
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte("spListaProcesoTerminado", FecFin)
                bcutil.excelExportar(result)
                Return True
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function spListaSaldoXAlmacenesLadrilloXLS(ByVal ART_ID As String, ByVal ALM_ID As Integer?, ByVal Fecha As Date) As String Implements IBCDespachos.spListaSaldoXAlmacenesLadrilloXLS
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte("spListaSaldoXAlmacenesLadrillo", ART_ID, ALM_ID, Fecha)
                bcutil.excelExportar(result)
                Return True
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function spListaDocumentoGuiaCliente_1XLS(ByVal PER_ID As String, ByVal FecIni As Date, ByVal FecFin As Date, ByVal EsFechaDocumento As Boolean) As String Implements IBCDespachos.spListaDocumentoGuiaCliente_1XLS
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte("spListaDocumentoGuiaCliente_1", PER_ID, FecIni, FecFin, EsFechaDocumento)
                bcutil.excelExportar(result)
                Return True
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function spKardexDocumentoDespachoNuevo3XLS(ByVal TIP_ID As String, ByVal DTD_ID_DOC As String, ByVal CCT_ID_DOC As String, ByVal PER_ID_CLI As String, ByVal DOCUMENTO As String, ByVal FILTRO As String, ByVal SOLOCONSALDO As String) As String Implements IBCDespachos.spKardexDocumentoDespachoNuevo3XLS
            Dim result As DataTable = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.EjecutarReporte("spKardexDocumentoDespachoNuevo3", TIP_ID, DTD_ID_DOC, CCT_ID_DOC, PER_ID_CLI, DOCUMENTO, FILTRO, SOLOCONSALDO)
                bcutil.excelExportar(result)
                Return True
            Catch ex As Exception

                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If

            End Try
            Return False
        End Function

        Public Function ListaGuiaSaleTarde(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Filtro As Integer, ByVal Numero As String) As String Implements IBCDespachos.ListaGuiaSaleTarde
            Dim result As String = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IReportesRepositorio)()
                result = rep.EjecutarReporte("spListaGuiaSaleTarde", FecIni, FecFin, Filtro, Numero)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
            End Try
            Return result
        End Function

        Public Function DespachosGetById(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String) As BE.Despachos Implements IBCDespachos.DespachosGetById
            Dim result As Despachos = Nothing
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDespachosRepositorio)()
                result = rep.GetById(TDO_ID, DTD_ID, DES_SERIE, DES_NUMERO)
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
