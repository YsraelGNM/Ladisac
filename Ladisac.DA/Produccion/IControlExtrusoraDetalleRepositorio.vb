Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlExtrusoraDetalleRepositorio
        Function GetById(ByVal DEX_Id As Integer) As ControlExtrusoraDetalle
        Sub Maintenance(ByVal ControlExtrusoraDetalle As ControlExtrusoraDetalle)
        Function ListaControlExtrusoraDetalle() As String
    End Interface

End Namespace

