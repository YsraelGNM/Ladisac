Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISolicitudAjustePrecioDetalleRepositorio
        Function GetById(ByVal APD_ID As Integer) As SolicitudAjustePrecioDetalle
        Sub Maintenance(ByVal SolicitudAjustePrecioDetalle As SolicitudAjustePrecioDetalle)
        Function ListaSolicitudAjustePrecioDetalle() As String
    End Interface

End Namespace

