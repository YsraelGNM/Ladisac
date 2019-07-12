Imports Ladisac.BE
Namespace Ladisac.BL
    Public Interface IBCGrupoTrabajo

#Region "Mantenimiento"

        Function Maintenance(ByVal item As BE.GrupoTrabajo)
        Function MaintenanceTarea(ByVal item As BE.GrupoTrabajo)

#End Region

#Region "Consultas"
        Function GrupoTrabajoQuery(ByVal desde As Date, ByVal hasta As Date, Optional ByVal observaciones As String = Nothing)
        Function GrupoTrabajoSeek(ByVal numero As String, ByVal periodo As String)
        Function GrupoTrabajoHorasSeek(ByVal desdeFecha As Date, ByVal hastaFecha As Date, Optional ByVal idPersona As String = "")
        Function DetalleHorasXTrabajador(ByVal desdeFecha As Date, ByVal hastaFecha As Date, ByVal idPersona As String)
        Function SPGrupoTrabajoDelete(ByVal item As BE.GrupoTrabajo)
        Function SPDetalleGrupoTrabajoMaintenanceSelect(ByVal prd_Periodo_id As String, ByVal grt_NumeroProd As String)

        Function spGrupoTrabajoQuemaSecaderoSelectXML(ByVal Tipo As String, ByVal fecha As Date, ByVal codigoOP As String, ByVal codigoPersona As String, ByVal nombePersona As String)
        Function spGrupoTrabajoQuemaSecaderoAgrupagoSelectXML(ByVal fecha As Date, ByVal codigo As String, ByVal tipo As String)

        Function SPReporteTrabajoHoraDetalle(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal sPersona As String)

        Function spGrupoTrabajoSecaderoAgrupagoModificarSelectXML(ByVal Fecha As Date, ByVal periodo As String, ByVal numero As String)


#End Region
    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCDatosTrabajadorJudicial
'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As BE.DatosTrabajadorJudicial)

'#End Region
'#Region "consulta"
'        Function DatosTrabajadorJudicialQuery(ByVal codigo As String, ByVal nombre As String)
'        Function DatosTrabajadorJudicialSeek(ByVal serie As String, ByVal numero As String)

'#End Region

'    End Interface

'End Namespace