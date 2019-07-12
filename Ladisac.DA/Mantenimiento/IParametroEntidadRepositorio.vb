Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IParametroEntidadRepositorio
        Function GetById(ByVal PAE_Id As Integer) As ParametroEntidad
        Sub Maintenance(ByVal ParametroEntidad As ParametroEntidad)
        Function ListaParametroEntidad() As String
    End Interface

End Namespace

