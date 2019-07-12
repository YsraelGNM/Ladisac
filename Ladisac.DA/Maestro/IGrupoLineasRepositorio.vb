Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IGrupoLineasRepositorio
        Function GetById(ByVal GLI_Id As String) As GrupoLineas
        Sub Maintenance(ByVal GrupoLinea As GrupoLineas)
        Function ListaGrupoLinea() As String
    End Interface

End Namespace

