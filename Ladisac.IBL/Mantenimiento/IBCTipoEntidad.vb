Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCTipoEntidad

#Region "Mantenimientos"
        Sub MantenimientoTipoEntidad(ByVal mTipoEntidad As TipoEntidad)
#End Region

#Region "Querys"
        Function TipoEntidadGetById(ByVal TEN_ID As Integer) As TipoEntidad
        Function ListaTipoEntidad() As String
#End Region

    End Interface

End Namespace
