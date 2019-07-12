Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlPlantaDetalleRepositorio
        Function GetById(ByVal DPL_Id As Integer) As ControlPlantaDetalle
        Sub Maintenance(ByVal ControlPlantaDetalle As ControlPlantaDetalle)
        Function ListaControlPlantaDetalle() As String
    End Interface

End Namespace

