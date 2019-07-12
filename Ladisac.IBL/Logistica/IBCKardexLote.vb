Imports Ladisac.BE

Namespace Ladisac.BL

    Public Interface IBCKardexLote

#Region "Mantenimientos"
        Sub MantenimientoKardexLote(ByVal mKardexLote As KardexLote)
#End Region

#Region "Querys"
        Function KardexLoteGetById(ByVal KAL_ID As Integer) As KardexLote
#End Region

    End Interface

End Namespace
