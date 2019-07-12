Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCAsientosManuales
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.AsientosManuales)
        Function MaintenanceDelete(ByVal item As BE.AsientosManuales)

#End Region
#Region "Consulta"
        Function AsientosManualesQuery(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String)
        Function AsientosManualesSeek(ByVal lib_Id As String, ByVal prd_Periodo_id As String, ByVal asm_NumeroVoucher As String)

#End Region
    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCGrupoTrabajo

'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.GrupoTrabajo)
'#End Region

'#Region "Consultas"
'        Function GrupoTrabajoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal usuario As String = Nothing)
'        Function GrupoTrabajoSeek(ByVal numero As String, ByVal periodo As String)

'#End Region
'    End Interface

'End Namespace
