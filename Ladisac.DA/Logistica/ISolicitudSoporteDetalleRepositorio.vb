Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISolicitudSoporteDetalleRepositorio
        Function GetById(ByVal SSD_ID As Integer) As SolicitudSoporteDetalle
        Sub Maintenance(ByVal SolicitudSoporteDetalle As SolicitudSoporteDetalle)
        Function ListaSolicitudSoporteDetalle() As String
    End Interface

End Namespace

