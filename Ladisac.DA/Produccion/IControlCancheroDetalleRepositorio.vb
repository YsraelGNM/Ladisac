Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IControlCancheroDetalleRepositorio
        Function GetById(ByVal DCA_Id As Integer) As ControlCancheroDetalle
        Sub Maintenance(ByVal ControlCancheroDetalle As ControlCancheroDetalle)
        Function ListaControlCancheroDetalle() As String
    End Interface

End Namespace

