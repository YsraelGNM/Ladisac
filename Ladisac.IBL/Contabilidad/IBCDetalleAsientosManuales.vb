Imports Ladisac.BL
Namespace Ladisac.BL

    Public Interface IBCDetalleAsientosManuales

#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.DetalleAsientosManuales)
#End Region
#Region "Consulta"

        Function DetalleAsientosManualesQuery(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String, ByVal dam_Item As String)
        Function DetalleAsientosManualesSeek(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String, ByVal dam_Item As String)
        Function RolOpeCtaCteQuery(ByVal CCT_ID As String, ByVal TDO_ID As String, ByVal DTD_ID As String, ByVal DTD_DESCRIPCION As String)

#End Region

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCDetalleGrupoTrabajo

'#Region "Mantenance"
'        Function Maintenance(ByVal item As BE.DetalleGrupoTrabajo)

'#End Region
'#Region "Consulta"
'        Function DetalleGrupoTrabajoQuery(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String, ByVal dgt_Item As String)
'        Function DetalleGrupoTrabajoSeek(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String, ByVal dgt_Item As String)
'#End Region
'    End Interface

'End Namespace
