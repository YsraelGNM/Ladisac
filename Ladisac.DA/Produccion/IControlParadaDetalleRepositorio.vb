Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlParadaDetalleRepositorio
        Function GetById(ByVal DCP_Id As Integer) As ControlParadaDetalle
        Sub Maintenance(ByVal ControlParadaDetalle As ControlParadaDetalle)
        Function ListaControlParadaDetalle() As String
    End Interface

End Namespace

