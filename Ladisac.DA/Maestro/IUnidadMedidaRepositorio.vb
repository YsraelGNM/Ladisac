Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IUnidadMedidaRepositorio
        Function GetById(ByVal UM_Id As String) As UnidadMedidaArticulos
        Sub Maintenance(ByVal UnidadMedida As UnidadMedidaArticulos)
        Function ListaUnidadMedida() As String
    End Interface

End Namespace

