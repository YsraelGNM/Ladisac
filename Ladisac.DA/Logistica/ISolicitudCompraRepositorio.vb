Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ISolicitudCompraRepositorio
        Function GetById(ByVal SOC_ID As Integer) As SolicitudCompra
        Sub Maintenance(ByVal SolicitudCompra As SolicitudCompra)
        Function ListaSolicitudCompra() As String
    End Interface

End Namespace

