Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ICaracteristicaRepositorio
        Function GetById(ByVal CTT_Id As Integer) As Caracteristica
        Sub Maintenance(ByVal Caracteristica As Caracteristica)
        Function ListaCaracteristica() As String
    End Interface

End Namespace

