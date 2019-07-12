Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCDetalleTrabajadorJudicial
#Region "Mantenance"
        Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial)

#End Region
#Region "Consulta"
        Function DetalleTrabajadorJudicialQuery(ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String, Optional ByVal tip_TipoPlan_Id As String = Nothing)
        Function DetalleTrabajadorJudicialSeek(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String)
#End Region

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCDatosTrabajadorJudicia
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.DatosTrabajadorJudicial)

'#End Region
'#Region "consulta"
'        Function DatosTrabajadorJudicialQuery(ByVal codigo As String, ByVal nombre As String)
'        Function DatosTrabajadorJudicialSeek(ByVal codigo As String, ByVal nombre As String)

'#End Region

'    End Interface

'End Namespace