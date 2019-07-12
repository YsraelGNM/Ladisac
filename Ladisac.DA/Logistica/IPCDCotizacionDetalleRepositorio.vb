Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IPCDCotizacionDetalleRepositorio
        Function GetById(ByVal CCD_ID As Integer) As PCDCotizacionDetalle
        Sub Maintenance(ByVal PCDCotizacionDetalle As PCDCotizacionDetalle)
        Function ListaPCDCotizacionDetalle() As String
    End Interface

End Namespace

