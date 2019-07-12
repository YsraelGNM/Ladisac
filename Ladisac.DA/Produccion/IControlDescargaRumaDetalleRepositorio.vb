Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlDescargaRumaDetalleRepositorio
        Function GetById(ByVal DRD_Id As Integer) As ControlDescargaRumaDetalle
        Sub Maintenance(ByVal ControlDescargaRumaDetalle As ControlDescargaRumaDetalle)
        Function ListaControlDescargaRumaDetalle() As String
    End Interface

End Namespace

