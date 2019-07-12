Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ITiposCargosRepositorio

        Function GetById(ByVal id As String) As TiposCargos
        Sub Maintenance(ByVal item As TiposCargos)

    End Interface
End Namespace

