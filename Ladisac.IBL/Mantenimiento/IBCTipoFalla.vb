Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCTipoFalla

#Region "Mantenimientos"
        Sub MantenimientoTipoFalla(ByVal mTipoFalla As TipoFalla)
#End Region

#Region "Querys"
        Function TipoFallaGetById(ByVal TFA_ID As Integer) As TipoFalla
        Function ListaTipoFalla() As String
#End Region

    End Interface

End Namespace
