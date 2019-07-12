Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCDespachos
        Function Mantenimiento(ByVal Item As Despachos) As Short

        Function spInsertarProgramacion(ByVal TDO_ID_CRO As String,
                                       ByVal DTD_ID_CRO As String,
                                       ByVal DES_SERIE_CRO As String,
                                       ByVal DES_NUMERO_CRO As String,
                                       ByVal TDO_ID_DES As String, _
                                       ByVal DTD_ID_DES As String,
                                       ByVal DES_SERIE_DES As String,
                                       ByVal DES_NUMERO_DES As String,
                                       ByVal USU_ID As String,
                                       ByVal PRO_ESTADO As Int16) As Short

        Function spActualizarDespachosDES_ESTADO(ByVal TDO_ID As String, _
                                         ByVal DTD_ID As String,
                                         ByVal DES_SERIE As String,
                                         ByVal DES_NUMERO As String,
                                         ByVal DES_ESTADO As Int16) As Short
        Function spActualizarDespachosDES_ESTADOEnDistribuidora(ByVal TDO_ID As String, _
                                         ByVal DTD_ID As String,
                                         ByVal DES_SERIE As String,
                                         ByVal DES_NUMERO As String,
                                         ByVal DES_ESTADO As Int16) As Short

        Function spActualizarDespachosDES_FEC_SAL_PLA(ByVal Orm As Despachos) As Short
        Function spEnviarCorreoDespacho(ByVal Orm As Despachos) As Short
        Function spActualizarDespachosDES_FEC_CAR_DES(ByVal Orm As Despachos) As Short

        Function DeleteRegistro(ByVal item As Despachos, ByVal cTDO_ID As String, ByVal cDTD_ID As String, ByVal cDES_SERIE As String, ByVal cDES_NUMERO As String) As Short

        Function spActualizarDocuMovimiento(ByVal Orm As Despachos) As Short

        Function spActualizarRegistro(ByVal Orm As Despachos) As Short
        Function spInsertarRegistro(ByVal Orm As Despachos) As Short
        Function spEliminarRegistro(ByVal Orm As Despachos) As Short

        Function spActualizarRegistroNullALM_ID_LLEGADA(ByVal Orm As Despachos) As Short
        Function spInsertarRegistroNullALM_ID_LLEGADA(ByVal Orm As Despachos) As Short

        Function ReporteGuiasProduccionXLS(ByVal FechaInicial As Date, ByVal FechaFinal As Date, ByVal PVE_ID As String) As Object

        Function spReporteCronogramaDespachoXML(ByVal DES_ESTADO As Int16, ByVal PER_ID_VEN As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date)
        Function spReporteCronogramaDespachoGuias(ByVal PER_ID_VEN As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date)
        Function ListaGuiasSinDocumento() As String
        Function ListaDocumentoGuiaCliente(ByVal PER_ID As String, ByVal FecIni As Date, ByVal FecFin As Date, ByVal EsFechaDocumento As Boolean) As String
        Function ListaGuiasEnTransitoPendientes(ByVal ALM_ID As Integer) As String
        Function ListaAlmacenXPuntoventa(ByVal USU_ID As String) As String
        Sub PasarTransito_AlmacenUsu(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String, ByVal ALM_ID_LLEGADA As Integer, ByVal USU_ID As String, ByVal DMO_FECHA As Date)
        Function ListaGuiasPorSalir(ByVal Fecha As Date) As String
        Function ListaTransferenciaLadrillo(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Alma_Id As Integer) As String
        Function ListaGuiaSaleTarde(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Filtro As Integer, ByVal Numero As String) As String
        Function ReporteOrdenDespacho(ByVal FecIni As Date, ByVal FecFin As Date, ByVal Flag As Integer) As String
        Function spReporteDocumentoGuiasXLS(ByVal FecIni As Date, ByVal FecFin As Date) As String
        Function spListaProcesoTerminadoXLS(ByVal FecFin As Date) As String
        Function spListaSaldoXAlmacenesLadrilloXLS(ByVal ART_ID As String, ByVal ALM_ID As Nullable(Of Integer), ByVal Fecha As Date) As String
        Function spListaDocumentoGuiaCliente_1XLS(ByVal PER_ID As String, ByVal FecIni As Date, ByVal FecFin As Date, ByVal EsFechaDocumento As Boolean) As String
        Function spKardexDocumentoDespachoNuevo3XLS(ByVal TIP_ID As String, ByVal DTD_ID_DOC As String, ByVal CCT_ID_DOC As String, ByVal PER_ID_CLI As String, ByVal DOCUMENTO As String, ByVal FILTRO As String, ByVal SOLOCONSALDO As String) As String

        Function DespachosGetById(ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DES_SERIE As String, ByVal DES_NUMERO As String) As Despachos
    End Interface
End Namespace
