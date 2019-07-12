Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCTipoProduccion

#Region "Mantenimientos"
        Sub MantenimientoTipoProduccion(ByVal mTipoProduccion As TipoProduccion)
#End Region

#Region "Querys"
        Function TipoProduccionGetById(ByVal TPR_ID As Integer) As TipoProduccion
        Function ListaTipoProduccion() As String
#End Region

    End Interface

End Namespace
