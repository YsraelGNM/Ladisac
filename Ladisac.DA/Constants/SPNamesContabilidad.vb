Namespace Ladisac.DA 'Namespace Ladisac.DA
    Partial Public Class SPNames
        'cuntas Contables
        Public Shared ReadOnly SPCuentasContablesSelectXML As String = "con.SPCuentasContablesSelectXML"
        Public Shared ReadOnly SPCuentasContablesDetalleSelectXML As String = "Con.SPCuentasContablesDetalleSelectXML"

        ' almacenes 
        Public Shared ReadOnly spAlmacenSelect As String = "con.spAlmacenSelect"

        Public Shared ReadOnly SPArticulosLadrillo As String = "fac.SPArticulosLadrillo"

        'Clase de cuenta
        Public Shared ReadOnly SPClaseCuentaSelectXML As String = "Con.SPClaseCuentaSelectXML"

        'libros contables
        Public Shared ReadOnly SPLibrosContablesSelectXML As String = "Con.SPLibrosContablesSelectXML"


        'libros contables
        Public Shared ReadOnly SPLibrosContablesDividendosSelectXML As String = "Con.SPLibrosContablesDividendosSelectXML"

        'tipos de bienes y servicios 
        Public Shared ReadOnly SPTiposBienesServiciosSelectXML As String = "con.SPTiposBienesServiciosSelectXML"

        Public Shared ReadOnly SPCtaCteSelectXML As String = "con.SPCtaCteSelectXML"

        Public Shared ReadOnly SPOperacionDetracionesSelectXML As String = "con.SPOperacionDetracionesSelectXML"

        Public Shared ReadOnly SPCuentasArticuloSelectXML As String = "con.SPCuentasArticuloSelectXML"

        Public Shared ReadOnly SPCuentasVariasSelectXML As String = "con.SPCuentasVariasSelectXML"
        Public Shared ReadOnly SPCuentasVariasUpdate As String = "con.SPCuentasVariasUpdate"

        Public Shared ReadOnly SPRolOpeCtaCteSelectXML As String = "con.SPRolOpeCtaCteSelectXML"

        '--asientos manuales
        Public Shared ReadOnly SPAsientosManualesSelectXML As String = "con.SPAsientosManualesSelectXML"
        Public Shared ReadOnly SPDetalleAsientosManualesSelectXML As String = "con.SPDetalleAsientosManualesSelectXML"
        Public Shared ReadOnly SPDetalleAsientosManualesDelete As String = "con.SPDetalleAsientosManualesDelete"
        Public Shared ReadOnly SPAsientosManualesDelete As String = "con.SPAsientosManualesDelete"

        'cuentas logistica
        Public Shared ReadOnly SPCuentasComprobantesLogistica As String = "con.SPCuentasComprobantesLogistica"
        Public Shared ReadOnly spCuentasComprobantesLogisticaSelect As String = "con.spCuentasComprobantesLogisticaSelect"
        Public Shared ReadOnly spCuentasComprobantesLogisticaValidar As String = "con.spCuentasComprobantesLogisticaValidar"
        'compras 
        Public Shared ReadOnly SPProvisionComprasSelectXML As String = "con.SPProvisionComprasSelectXML"
        Public Shared ReadOnly SPProvisionDividendosSelectXML As String = "con.SPProvisionDividendosSelectXML"
        Public Shared ReadOnly SPTiposComprobantesSelectXML As String = "con.SPTiposComprobantesSelectXML"
        Public Shared ReadOnly SPTiposComprobantesDividendosSelectXML As String = "con.SPTiposComprobantesDividendosSelectXML"
        Public Shared ReadOnly SPPuntoVentaSelectXML As String = "Con.SPPuntoVentaSelectXML"
        Public Shared ReadOnly SPTipoVentaSelectXML As String = "con.SPTipoVentaSelectXML"

        'Public Shared ReadOnly SPDocuMovimientoXML As String = "Con.SPDocuMovimientoXML"
        'Public Shared ReadOnly SPDocuMovimientoXML As String = "Con.SPDocuMovimientoNuevoXML"
        'Public Shared ReadOnly SPDocuMovimientoXML As String = "Con.SPDocuMovimientoNuevo2017XML"
        Public Shared ReadOnly SPDocuMovimientoXML As String = "Con.SPDocuMovimientoNuevo2017_1XML"
        'Public Shared ReadOnly SPDocuMovimientoServicioXML As String = "mae.SPDocuMovimientoNuevoOCXML"
        Public Shared ReadOnly SPDocuMovimientoServicioXML As String = "mae.SPDocuMovimientoNuevoOC2017XML"
        Public Shared ReadOnly SPDocuMovimientoPlanillaXML As String = "mae.SPDocuMovimientoNuevoPL2017XML"
        Public Shared ReadOnly SPDocuMovimientoRendicionEntregasXML As String = "mae.SPDocuMovimientoNuevoRE2017XML"

        Public Shared ReadOnly SPDocuMovimientoDetalleXML As String = "con.SPDocuMovimientoDetalleXML"
        Public Shared ReadOnly SPDocuMovimientoDetalleServicioXML As String = "mae.SPDocuMovimientoDetalleOCXML"
        Public Shared ReadOnly SPDocuMovimientoDetallePlanillaXML As String = "mae.SPDocuMovimientoDetallePLXML"
        Public Shared ReadOnly SPDocuMovimientoDetalleRendicionXML As String = "mae.SPDocuMovimientoDetalleCRXML"

        Public Shared ReadOnly SPDocuMovimientoLogisticaXML As String = "Con.SPDocuMovimientoLogisticaXML"
        Public Shared ReadOnly SPProvisionComprasXRefSelectXML As String = "Con.SPProvisionComprasXRefSelectXML"
        Public Shared ReadOnly SPProvisionComprasDelete As String = "Con.SPProvisionComprasDelete"
        Public Shared ReadOnly SPExportarDetraccionesas As String = "con.SPExportarDetracciones"
        Public Shared ReadOnly SPDetalleComprobantes As String = "con.SPDetalleComprobantes"
        Public Shared ReadOnly spProvisionComprasImprime As String = "con.spProvisionComprasImprime"
        Public Shared ReadOnly spDetalleProvisionCompras As String = "con.spDetalleProvisionCompras"

        '--


        '--asientos automaticos
        Public Shared ReadOnly SPAsientoAutomaticoCompra As String = "con.SPAsientoAutomaticoCompra"
        Public Shared ReadOnly SPAsientoAutomaticoDividendo As String = "con.SPAsientoAutomaticoDividendo"
        Public Shared ReadOnly SPAsientoAutomaticoTesoreria As String = "con.SPAsientoAutomaticoTesoreria"
        Public Shared ReadOnly SPAsientoAutomaticoVentas As String = "con.SPAsientoAutomaticoVentas"
        Public Shared ReadOnly SPAsientoAutomaticoPlanillas As String = "con.SPAsientoAutomaticoPlanillas"
        Public Shared ReadOnly spRecarculoKardex As String = "con.spRecarculoKardex"

        '---------------------------------


        '---consultas , reportes   y exportaciones de archivos

        Public Shared ReadOnly spSaldosKardex As String = "con.spSaldosKardex"


        Public Shared ReadOnly SPHojaTrabajo As String = "con.SPHojaTrabajoXML"
        Public Shared ReadOnly SPHojaTrabajoReporte As String = "Con.SPHojaTrabajoReporte"

        Public Shared ReadOnly SPConsultaCABAsientosContables As String = "con.SPConsultaCABAsientosContables"
        Public Shared ReadOnly SPConsultaCABAsientosContablesNuevo As String = "mae.SPConsultaCABAsientosContablesNuevo"
        Public Shared ReadOnly SPConsultaDETAsientosContables As String = "con.SPConsultaDETAsientosContables"

        Public Shared ReadOnly spFormatoVenta14 As String = "con.spFormatoVenta14"
        Public Shared ReadOnly spFormatoCompra81 As String = "con.spFormatoCompra81"
        Public Shared ReadOnly spFormatoCuenta As String = "con.spFormatoCuenta"
        Public Shared ReadOnly spFormatoDigitos As String = "con.spFormatoDigitos"
        Public Shared ReadOnly SPFormaroMayorGeneral61 As String = "con.SPFormaroMayorGeneral61"

        Public Shared ReadOnly spFormato3_2 As String = "Con.spFormato3_2"

        Public Shared ReadOnly SPFormatoSaldoClientes33 As String = "Con.SPFormatoSaldoClientes33"
        Public Shared ReadOnly SPFormatosTributos310 As String = "Con.SPFormatosTributos310"
        Public Shared ReadOnly spFormatoCuentaContable As String = "Con.spFormatoCuentaContable"

        Public Shared ReadOnly SPSelectReportComprobantes As String = "Con.SPSelectReportComprobantes"

        Public Shared ReadOnly spFormatoMayorAuxiliarDetallado As String = "con.spFormatoMayorAuxiliarDetallado"

        'Public Shared ReadOnly SPLibroDiarioGeneral As String = "con.SPLibroDiarioGeneral"
        'Public Shared ReadOnly SPLibroDiarioGeneral As String = "dbo.SPLibroDiario"
        Public Shared ReadOnly SPLibroDiarioGeneral As String = "dbo.SPLibroDiarioNuevo"

        Public Shared ReadOnly SPExportarVentasSunatPLE As String = "con.SPExportarVentasSunatPLE"
        Public Shared ReadOnly SPExportarComprasSunatPLE As String = "con.SPExportarComprasSunatPLE"
        Public Shared ReadOnly SPExportarComprasNoDomiciliadosSunatPLE As String = "con.SPExportarComprasNoDomiciliadosSunatPLE"
        Public Shared ReadOnly SPExportarAsientosSunatPLE51 As String = "con.SPExportarAsientosSunatPLE51"
        Public Shared ReadOnly SPExportarMayorSunatPLE As String = "con.SPExportarMayorSunatPLE"

        Public Shared ReadOnly SPExportarDetracciones As String = "con.SPExportarDetracciones"
        Public Shared ReadOnly spExportarSunatPDT697 As String = "con.spExportarSunatPDT697"
        Public Shared ReadOnly spExportarSunatPDT697Comprobantes As String = "con.spExportarSunatPDT697Comprobantes"
        Public Shared ReadOnly spExportarSunatPDT626 As String = "con.spExportarSunatPDT626"
        Public Shared ReadOnly spExportarSunatPDT321 As String = "con.spExportarSunatPDT321"
        Public Shared ReadOnly spResumenComprobanteRetencion As String = "con.spResumenComprobanteRetencion"

        Public Shared ReadOnly SPSelectReportRegistroComprasCentroCosto As String = "con.SPSelectReportRegistroComprasCentroCosto"
        'Public Shared ReadOnly SPSelectReportMayorAuxiliarMeses As String = "con.SPSelectReportMayorAuxiliarMeses"
        Public Shared ReadOnly SPSelectReportMayorAuxiliarMeses As String = "con.SPSelectReportMayorAuxiliarMesesNuevo"
        Public Shared ReadOnly SPSelectReportDestinoCompras As String = "con.SPSelectReportDestinoCompras"

        Public Shared ReadOnly SPSelectReportCuentasProveedor As String = "con.SPSelectReportCuentasProveedor"


        '----- configuracion de formatos(libros contables)

        Public Shared ReadOnly SPConfiguracionFormatosSelectXML As String = "Con.SPConfiguracionFormatosSelectXML"
        Public Shared ReadOnly SPConfiguracionFormatosUpdate As String = "Con.SPConfiguracionFormatosUpdate"

        '------------------------------------------------------------------------------------

        Public Shared ReadOnly spVentasDiamanteComercializadora As String = "fac.spVentasDiamanteComercializadora"
        Public Shared ReadOnly spEstadoDeDocumentosFechasVentas As String = "fac.spEstadoDeDocumentosFechasVentas"
        Public Shared ReadOnly spVentasDiamanteComercializadoraaAcumuladoVendedor As String = "fac.spVentasDiamanteComercializadoraaAcumuladoVendedor"
        Public Shared ReadOnly spVentasDiamanteComercializadoraaAcumuladoArticulo As String = "fac.spVentasDiamanteComercializadoraaAcumuladoArticulo"
        '-------------------------------------------------------------------------------------

        ' comprobantes

        Public Shared ReadOnly SPDetalleComprobantesListaXML As String = "Con.SPDetalleComprobantesListaXML"
        Public Shared ReadOnly spComprobantesSelectXML As String = "con.spComprobantesSelectXML"
        Public Shared ReadOnly spComprobantesDelete As String = "con.spComprobantesDelete"


        Public Shared ReadOnly SPSelectReportAsientosConProblemas As String = "con.SPSelectReportAsientosConProblemas"

        '-----------------------------------------
        'leasing
        Public Shared ReadOnly SPLeasingDelete As String = "con.SPLeasingDelete"
        Public Shared ReadOnly SPLeasingSelectXML As String = "con.SPLeasingSelectXML"
        Public Shared ReadOnly SPLeasingListaSelectXML As String = "con.SPLeasingListaSelectXML"

        '-----------------------------------------
        'DAOT
        Public Shared ReadOnly SPSelectReportDAOTComprasResumen As String = "con.SPSelectReportDAOTComprasResumen"
        Public Shared ReadOnly SPSelectReportDAOTComprasDetalle As String = "con.SPSelectReportDAOTComprasDetalle"
        Public Shared ReadOnly SPSelectReportDAOTVentasDetalle As String = "con.SPSelectReportDAOTVentasDetalle"
        Public Shared ReadOnly SPSelectReportDAOTVentasResumen As String = "con.SPSelectReportDAOTVentasResumen"

        'reparables
        Public Shared ReadOnly spTiposReparablesSelectXML As String = "con.spTiposReparablesSelectXML"
        ''''


    End Class
End Namespace