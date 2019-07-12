Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCUnidadMedida

#Region "Mantenimientos"
        Sub MantenimientoUnidadMedida(ByVal mUnidadMedida As UnidadMedidaArticulos)
#End Region

#Region "Querys"
        Function UnidadMedidaGetById(ByVal UM_ID As String) As UnidadMedidaArticulos
        Function ListaUnidadMedida() As String
#End Region

    End Interface

End Namespace
