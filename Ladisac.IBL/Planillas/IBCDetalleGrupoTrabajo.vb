Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCDetalleGrupoTrabajo

#Region "Mantenance"
        Function Maintenance(ByVal item As BE.DetalleGrupoTrabajo)

#End Region
#Region "Consulta"
        Function DetalleGrupoTrabajoQuery(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String, ByVal dgt_Item As String)
        Function DetalleGrupoTrabajoSeek(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String, ByVal dgt_Item As String)

#End Region
    End Interface

End Namespace
