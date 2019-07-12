Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCSolicitudCompra

#Region "Mantenimientos"
        Sub MantenimientoSolicitudCompra(ByVal mSolicitudCompra As SolicitudCompra)
        Sub MantenimientoSolicitudCompraDetalle(ByVal mSolicitudCompraDetalle As SolicitudCompraDetalle)
#End Region

#Region "Querys"
        Function SolicitudCompraGetById(ByVal SOC_ID As Integer) As SolicitudCompra
        Function SolicitudCompraDetalleGetById(ByVal SCD_ID As Integer) As SolicitudCompraDetalle
        Function ListaSolicitudCompra() As String
        Function ImpresionSolicitudDeCompra(ByVal SOC_ID As Integer) As String
#End Region

    End Interface

End Namespace
