Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITipoAreaRepositorio
        Function GetById(ByVal TAR_Id As Integer) As TipoArea
        Sub Maintenance(ByVal TipoArea As TipoArea)
        Function ListaTipoArea() As String
    End Interface

End Namespace

