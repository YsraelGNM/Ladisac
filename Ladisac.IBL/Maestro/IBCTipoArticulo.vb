Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCTipoArticulo

#Region "Mantenimientos"
        Sub MantenimientoTipoArticulo(ByVal mTipoArticulo As TipoArticulos)
#End Region

#Region "Querys"
        Function TipoArticuloGetById(ByVal TIP_ID As String) As TipoArticulos
        Function ListaTipoArticulo() As String
#End Region

    End Interface

End Namespace
