Imports Ladisac.BE

Namespace Ladisac.DA

    Public Interface IConsumoCombustibleRepositorio
        Function GetById(ByVal CCO_Id As Integer) As ConsumoCombustible
        Sub Maintenance(ByVal ConsumoCombustible As ConsumoCombustible)
        Function ListaConsumoCombustible() As String
    End Interface

End Namespace

