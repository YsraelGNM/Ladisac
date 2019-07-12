
Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCTareaTrabajo
#Region "Mantenimiento"
        Function Maintenance(ByVal item As BE.TareaTrabajo)
#End Region
#Region "Consultas"

        Function TareaTrabajoQuery(ByVal tit_TipTarea_Id As String, ByVal ttr_Tarea As String, ByVal produccion_ID As String)
        Function TareaTrabajoSeek(ByVal tit_TipTarea_Id As String, ByVal ttr_TareaTrab_Id As String)
        Function ArticulosQuery(ByVal codigoFabrica As String, ByVal descripcion As String)
        Function SPTareaTrabajoExportarSelect(ByVal tit_TipTarea_Id As String)


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

