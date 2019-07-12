Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IGrupoRepositorio
        Function GetById(ByVal GRU_Id As Integer) As Grupo
        Sub Maintenance(ByVal Grupo As Grupo)
        Function ListaGrupo() As String
    End Interface

End Namespace

