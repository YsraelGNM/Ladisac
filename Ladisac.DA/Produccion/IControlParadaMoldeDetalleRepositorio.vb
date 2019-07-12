Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlParadaMoldeDetalleRepositorio
        Function GetById(ByVal DPM_Id As Integer) As ControlParadaMoldeDetalle
        Sub Maintenance(ByVal ControlParadaMoldeDetalle As ControlParadaMoldeDetalle)
        Function ListaControlParadaMoldeDetalle() As String
    End Interface

End Namespace

