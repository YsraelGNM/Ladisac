Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IEspecificacionRepositorio
        Function GetById(ByVal ESP_Id As Integer) As Especificacion
        Sub Maintenance(ByVal Especificacion As Especificacion)
        Function ListaEspecificacion() As String
    End Interface

End Namespace

