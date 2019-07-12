Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCTipoParada

#Region "Mantenimientos"
        Sub MantenimientoTipoParada(ByVal mTipoParada As TipoParada)
#End Region

#Region "Querys"
        Function TipoParadaGetById(ByVal TPA_ID As Integer) As TipoParada
        Function ListaTipoParada(ByVal TPA_ID As Integer) As String
#End Region

    End Interface

End Namespace
