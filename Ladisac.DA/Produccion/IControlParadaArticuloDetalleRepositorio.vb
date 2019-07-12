Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlParadaArticuloDetalleRepositorio
        Function GetById(ByVal DPA_Id As Integer) As ControlParadaArticuloDetalle
        Sub Maintenance(ByVal ControlParadaArticuloDetalle As ControlParadaArticuloDetalle)
        Function ListaControlParadaArticuloDetalle() As String
    End Interface

End Namespace

