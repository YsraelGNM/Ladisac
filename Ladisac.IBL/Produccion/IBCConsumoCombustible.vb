Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCConsumoCombustible

#Region "Mantenimientos"
        Sub MantenimientoConsumoCombustible(ByVal mConsumoCombustible As ConsumoCombustible)
#End Region

#Region "Querys"
        Function ConsumoCombustibleGetById(ByVal CCO_ID As Integer) As ConsumoCombustible
        Function ListaConsumoCombustible() As String
        Function Interfase_ConsumoCombustibleHornoSecadero(ByVal CCO_ID As Integer) As String
        Function Interfase_PasarSpring(ByVal Fecha As Date, ByVal TipoTransaccion As String, Item As String) As String
#End Region

    End Interface

End Namespace
