Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlMezclaMezclaDetalleRepositorio
        Function GetById(ByVal DMM_Id As Integer) As ControlMezclaMezclaDetalle
        Sub Maintenance(ByVal ControlMezclaMezclaDetalle As ControlMezclaMezclaDetalle)
        Function ListaControlMezclaMezclaDetalle() As String
    End Interface

End Namespace

