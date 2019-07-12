Imports Ladisac.BE
Namespace Ladisac.BL

    Public Interface IBCDetallePrestamosTrabajador
#Region "Mantenimiento"
        Function Maintenance(ByVal item As DetallePrestamosTrabajador)

#End Region

#Region "consulta"
        Function DetallePrestamosTrabajadorQuery(ByVal serie As String, ByVal numero As String, ByVal item As String)
        Function DetallePrestamosTrabajadorSeek(ByVal serie As String, ByVal numero As String, ByVal item As String)

#End Region

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.BL

'    Public Interface IBCDetalleTrabajadorJudicial
'#Region "Mantenance"
'        Function Maintenance(ByVal item As BE.DetalleTrabajadorJudicial)

'#End Region
'#Region "Consulta"
'        Function DetalleTrabajadorJudicialQuery(ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String, Optional ByVal tip_TipoPlan_Id As String = Nothing)
'        Function DetalleTrabajadorJudicialSeek(ByVal tip_TipoPlan_Id As String, ByVal dtj_SerieJudi As String, ByVal dtj_NumeroJudi As String)
'#End Region

'    End Interface

'End Namespace
