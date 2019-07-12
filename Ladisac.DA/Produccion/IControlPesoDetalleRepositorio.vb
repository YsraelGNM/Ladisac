Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlPesoDetalleRepositorio
        Function GetById(ByVal DPE_Id As Integer) As ControlPesoDetalle
        Sub Maintenance(ByVal ControlPesoDetalle As ControlPesoDetalle)
        Function ListaControlPesoDetalle() As String
    End Interface

End Namespace

