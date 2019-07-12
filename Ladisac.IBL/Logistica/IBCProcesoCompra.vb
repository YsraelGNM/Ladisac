Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCProcesoCompra

#Region "Mantenimientos"
        Sub MantenimientoProcesoCompra(ByVal mProcesoCompra As ProcesoCompra)
        Sub MantenimientoProcesoCompra(ByVal mProcesoCompra As ProcesoCompra, ByVal dt As DataTable)
        Sub MantenimientoProcesoCompraDetalle(ByVal mProcesoCompraDetalle As ProcesoCompraDetalle)
#End Region

#Region "Querys"
        Function ProcesoCompraGetById(ByVal PRC_ID As Integer) As ProcesoCompra
        Function ListaProcesoCompraAConsolidar(ByVal USU_ID As String) As String
        Function ListaProcesoCompraCotizacion(ByVal USU_ID As String) As String
        Function ListaProcesoCompraSinCotizacion(ByVal USU_ID As String, ByVal Fecha As Date) As String
        Function ListaProcesoCompraSinCotizacionImpresion(ByVal Fecha As Date) As String
        Function ListaProcesoCompraResumen() As String
        Function ProcesoCompraDetalleGetById(ByVal PCD_ID As Integer) As ProcesoCompraDetalle
        Function ProcesoCompraDetalleGetById2(ByVal OCD_ID As Integer) As ProcesoCompraDetalle
        Function ListaAutorizar(ByVal USU_ID As String) As DataTable
        Function ListaSeguimientoAutorizacion(ByVal USU_ID As String, ByVal FecIni As Date, ByVal FecFin As Date) As DataTable
#End Region

    End Interface

End Namespace
