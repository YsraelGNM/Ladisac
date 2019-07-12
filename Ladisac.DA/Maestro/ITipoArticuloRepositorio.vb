Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITipoArticuloRepositorio
        Function GetById(ByVal TIP_Id As String) As TipoArticulos
        Sub Maintenance(ByVal TipoArticulo As TipoArticulos)
        Function ListaTipoArticulo() As String
    End Interface

End Namespace

