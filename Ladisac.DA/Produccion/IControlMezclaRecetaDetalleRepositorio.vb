Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlMezclaRecetaDetalleRepositorio
        Function GetById(ByVal DMR_Id As Integer) As ControlMezclaRecetaDetalle
        Sub Maintenance(ByVal ControlMezclaRecetaDetalle As ControlMezclaRecetaDetalle)
        Function ListaControlMezclaRecetaDetalle() As String
    End Interface

End Namespace

