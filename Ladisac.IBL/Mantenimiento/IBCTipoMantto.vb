Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCTipoMantto

#Region "Mantenimientos"
        Sub MantenimientoTipoMantto(ByVal mTipoMantto As TipoMantto)
#End Region

#Region "Querys"
        Function TipoManttoGetById(ByVal TMO_ID As Integer) As TipoMantto
        Function ListaTipoMantto() As String
#End Region

    End Interface

End Namespace
