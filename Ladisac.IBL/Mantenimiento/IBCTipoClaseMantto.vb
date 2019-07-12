Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCTipoClaseMantto

#Region "Mantenimientos"
        Sub MantenimientoTipoClaseMantto(ByVal mTipoClaseMantto As TipoClaseMantto)
#End Region

#Region "Querys"
        Function TipoClaseManttoGetById(ByVal TCM_ID As Integer) As TipoClaseMantto
        Function ListaTipoClaseMantto() As String
#End Region

    End Interface

End Namespace
