Imports Ladisac.BL
Namespace Ladisac.BL

    Public Interface IBCConsultasReportesContabilidad
#Region "Exportar Excel"
        Function FormatoMayorAuxiliarDetalladoXLS(ByVal cIdAnoMes As String, ByVal cIdCuentaInicial As String, ByVal cIdCuentaFinal As String, ByVal cIdCentroCosto As String, ByVal cIdLibro As String, ByVal cMesAcumulado As String, ByVal lSoloReparables As Integer, ByVal idUsuario As String)
#End Region

#Region "Consultas"
        ' comentario
        Function HojaTrabajoXMLQuery(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String)
        Function HojaTrabajoReporteQuery(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String)
        Function HojaTrabajoReporteNuevoQuery(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String)
        Function ConsultaCABAsientosContables(ByVal periodo As String, ByVal libro As String)
        Function ConsultaCABAsientosContablesNuevo(ByVal periodo As String, ByVal libro As String, ByVal Voucher As String, ByVal Nombre As String, ByVal Serie As String, ByVal Numero As String)
        Function ConsultaDETAsientosContables(ByVal periodo As String, ByVal libro As String, ByVal voucher As String)
        Function spSaldosKardex(ByVal sfiltro As String)

        Function SPExportarComprasSunatPLEXML(ByVal periodo As String)
        Function SPExportarComprasNoDomiciliadosSunatPLEXML(ByVal periodo As String)
        Function SPExportarVentasSunatPLEXML(ByVal periodo As String)
        Function SPExportarAsientosSunatPLE51XML(ByVal periodo As String)
        Function SPExportarMayorSunatPLE(ByVal periodo As String)

        Function SPExportarDetracciones(ByVal CCC_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal Numero As String, ByVal Serie As String, Optional ByVal rucEmpresa As String = "20120877055", Optional ByVal nombreEmpresa As String = "LADRILLERA EL DIAMANTE SAC")

        Function spExportarSunatPDT697(ByVal periodo As String)
        Function spExportarSunatPDT697Comprobantes(ByVal periodo As String)
        Function spExportarSunatPDT626(ByVal periodo As String)
        Function spExportarSunatPDT321(ByVal periodo As String)
        Function spResumenComprobanteRetencion(ByVal fecha As String)


#End Region

#Region "Reportes"

        Function RPTFormatoVenta14(ByVal periodo As String) As DataTable
        Function RPTFormatoCompra81(ByVal periodo As String) As DataTable
        Function RPTFormatoCuenta(ByVal periodo As String, ByVal libro As String, ByVal cuenta As String) As DataTable
        Function RPTFormatoDigitos(ByVal periodo As String, ByVal libro As String, ByVal digitos As Integer) As DataTable
        Function RPTFormatoMayorGeneral61(ByVal periodo As String, ByVal nivel As Integer) As DataTable
        Function RPTFormatoInventarioYBalance32(ByVal Periodo As String, ByVal formato As String) As DataTable
        Function RPTFormatoSaldoClientes33(ByVal Periodo As String, ByVal formato As String) As DataTable
        Function RPTFormatosTributos310(ByVal periodo As String, ByVal formato As String) As DataTable
        Function RPTFormatoCuentaContable(ByVal nivel As String) As DataTable
        Function RPTReportAsientosConProblemas(ByVal periodo As String, ByVal libro As String) As DataTable

        Function RPTReportComprobantes(ByVal dateDesde As Date, ByVal dateHasta As Date, ByVal tdo_Id As String, ByVal dtd_Id As String, Optional ByVal serie As String = Nothing, Optional ByVal numero As String = Nothing, Optional ByVal PER_ID As String = Nothing) As DataTable

        Function SPSelectReportRegistroComprasCentroCosto(ByVal periodoInicial As String, ByVal periodoFinal As String, ByVal persona As String, ByVal centroCosto As String)

        Function SPSelectReportMayorAuxiliarMeses(ByVal periodo As String, ByVal cuenta As String)

        Function SPSelectReportDestinoCompras(ByVal periodo As String)

        Function SPSelectReportCuentasProveedor(ByVal xmlCuentas As String, ByVal todasLasCuentas As Single, ByVal xmlProveedores As String, ByVal TodosLosProveedores As Single, ByVal desdeFecha As Date, ByVal hastaFecha As Date)

        Function SPLibroDiarioGeneral(ByVal periodo As String, ByVal libro As String)

        '-------------------------------
        Function spVentasDiamanteComercializadora(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cliente As String, ByVal vendedor As String, ByVal puntoVenta As String, ByVal articulo As String)
        Function spEstadoDeDocumentosFechasVentas(ByVal PuntoVenta As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal vendedor As String)
        Function spVentasDiamanteComercializadoraaAcumuladoVendedor(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cliente As String, ByVal vendedor As String, ByVal puntoVenta As String, ByVal articulo As String)
        Function spVentasDiamanteComercializadoraaAcumuladoArticulo(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal cliente As String, ByVal vendedor As String, ByVal puntoVenta As String, ByVal articulo As String)

        Function SPSelectReportDAOTComprasResumen(ByVal año As Integer)
        Function SPSelectReportDAOTComprasDetalle(ByVal año As Integer, ByVal persona As String)
        Function SPSelectReportDAOTVentasDetalle(ByVal año As Integer, ByVal persona As String)
        Function SPSelectReportDAOTVentasResumen(ByVal año As Integer)
        Function spAnalisisCuentasCorrientes(ByVal PeriodoIni As String, ByVal PeriodoFin As String, ByVal CuentaIni As String, ByVal CuentaFin As String, ByVal Per_Id As String, ByVal Tip_Per As Nullable(Of Integer), ByVal Libro As String) As DataTable
        Function spBalance(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String) As DataTable
        Function spGananciasPerdidas(ByVal periodo As String, ByVal nivelInicio As Integer, ByVal nivelFin As Integer, ByVal acumuladoMensual As String, ByVal libro As String) As DataTable
#End Region

    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCCtaCte

'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As CtaCte)
'#End Region

'#Region "Consulta"
'        Function CtaCteQuery(ByVal CCT_ID As String, ByVal CCT_DESCRIPCION As String)
'        Function CtaCteSeek(ByVal id As String) As BE.CtaCte
'#End Region

'    End Interface

'End Namespace