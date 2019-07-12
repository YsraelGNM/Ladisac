Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlConteoDetalleRepositorio
        Function GetById(ByVal DCC_Id As Integer) As ControlConteoDetalle
        Sub Maintenance(ByVal ControlConteoDetalle As ControlConteoDetalle)
        Function ListaControlConteoDetalle() As String
    End Interface

End Namespace

