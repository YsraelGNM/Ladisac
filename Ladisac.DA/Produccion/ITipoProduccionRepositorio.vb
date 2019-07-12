Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface ITipoProduccionRepositorio
        Function GetById(ByVal TPR_Id As Integer) As TipoProduccion
        Sub Maintenance(ByVal TipoProduccion As TipoProduccion)
        Function ListaTipoProduccion() As String
    End Interface

End Namespace

