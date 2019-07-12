Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISolicitudCompraDetalleRepositorio
        Function GetById(ByVal SCD_ID As Integer) As SolicitudCompraDetalle
        Sub Maintenance(ByVal SolicitudCompraDetalle As SolicitudCompraDetalle)
        Function ListaSolicitudCompraDetalle() As String
    End Interface

End Namespace

