Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITipoParadasRepositorio
        Function GetById(ByVal TPA_Id As Integer) As TipoParada
        Sub Maintenance(ByVal TipoParada As TipoParada)
        Function ListaTipoParada(ByVal TPA_ID As Integer) As String
    End Interface

End Namespace
