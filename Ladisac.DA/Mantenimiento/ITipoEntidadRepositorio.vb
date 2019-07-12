Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITipoEntidadRepositorio
        Function GetById(ByVal TEN_Id As Integer) As TipoEntidad
        Sub Maintenance(ByVal TipoEntidad As TipoEntidad)
        Function ListaTipoEntidad() As String
    End Interface

End Namespace

