Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IParadasRepositorio
        Function GetById(ByVal PAR_Id As Integer) As Parada
        Sub Maintenance(ByVal Parada As Parada)
        Function ListaParada(ByVal PAR_ID As Integer) As String
    End Interface

End Namespace

