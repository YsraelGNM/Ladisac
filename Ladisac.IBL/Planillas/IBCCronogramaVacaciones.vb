Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCCronogramaVacaciones
#Region "Mantenimiento"
        Function Maintenance(ByVal items As List(Of CronogramaVacaciones))

#End Region
#Region "Consultas"
        Function CronogramaVacacionesQuery(ByVal per_Id As String, ByVal crv_ItemCroVaca As String)
        Function CronogramaVacacionesSeek(ByVal per_Id As String, ByVal crv_ItemCroVaca As String) As BE.CronogramaVacaciones
        Function spPlanillaCronogramaVacacionesBuscarSelectXML(ByVal per_id As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date, ByVal tip_TipoPlan_Id As String)

#End Region
    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCNivelEducacion

'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As NivelEducacion)
'#End Region

'#Region "Consulta"
'        Function NivelEducacionQuery(ByVal nie_NiveEduc_Id As String, ByVal nie_Descipcion As String)
'        Function NivelEducacionSeek(ByVal id As String) As BE.NivelEducacion

'#End Region

'    End Interface

'End Namespace
