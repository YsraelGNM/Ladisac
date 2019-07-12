
Imports Ladisac.BL
Namespace Ladisac.BL

    Public Interface IBCConsultasReportesPlanillas

#Region "Ajustes Planilla"
        Function AjusteMinimoEsSalud(ByVal Periodo As String)
#End Region

#Region "Consultas"
        'hh

        Function spPlanillaBuscarPlameSelectXML(ByVal sPeriodo As String)
        Function SPPlanillaExportarPlameIngreEgresAportaciones(ByVal slistadoXML As String, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String)
        Function SPPlanillaExportarPlameJornadaLaboral(ByVal slistadoXML As String)

#End Region

#Region "Reportes"

        Function SPSelectReportPLLXAcumuladosXTrabajador(ByVal conceptosXML As String, ByVal ListaPlanillas As String, ByVal idpersona As String)
        Function SPSelectReportPLLXAcumuladosXListaTrabajador(ByVal conceptosXML As String, ByVal ListaPlanillas As String)

        Function SPPlanillaImprimir(ByVal serie As String, _
                                ByVal numero As String, _
                                ByVal persona As String)

        Function SPTrabajadorCumpleaños(ByVal tit_TipoTrab_Id As String, _
                                        ByVal sit_SituaTrab_Id As String, ByVal FechaDesde As Date, ByVal FechaHasta As Date)

        Function SPReporteDatosTrabajadorJudicial(ByVal activo As Int16, ByVal persona_id As String)

        Function SPReporteFichaTrabajador(ByVal persona_id As String, ByVal tipoTrabajador_id As String, ByVal art_AreaTrab_Id As String)

        Function SPReportePeriodoLaboral(ByVal sTipo As String, ByVal sArea As String, ByVal persona_id As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date)
        Function SPReportePeriodoVacaciones(ByVal sTipo As String, ByVal sArea As String, ByVal persona_id As String, ByVal fechaDesde As Date, ByVal fechaHasta As Date)

        Function SPReporteComedor(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal tic_TipoConcep_Id As String, ByVal con_Conceptos_Id As String, ByVal per_IdComedor As String, ByVal per_idTrabajador As String)

        Function SPReporteGrupoTrabajoHoras(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal persona_id As String, ByVal tipo As Boolean, Optional ByVal filtro As Int16 = 0)

        Function SPReporteGrupoMantenimientoAgrupado(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal sPersonas As String)
        Function SPReporteGrupoMantenimientoDetalle(ByVal fechaDesde As Date, ByVal fechaHasta As Date, ByVal sPersonas As String)

        Function SPPlanillaImprimirLista(ByVal xml As String)
        Function spReportePermisosTrabajador(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal trabajador As String, ByVal autoriza As String)

        Function spReporteHorasPlanillasproduccion(ByVal xml As String)
        Function spReportePlanillaConsolidado(ByVal sxml As String)
        Function spReporteReparotrabajador(ByVal fechaInicio As Date, ByVal fechaFin As Date, ByVal sAutoriza As String, ByVal sTrabajador As String)
        Function spReportePlanillaConsolidadoSuma(ByVal sxml As String)

#End Region

    End Interface

End Namespace

'Imports Ladisac.BE
'Namespace Ladisac.BL
'    Public Interface IBCCtaCte

'#Region "Mantenimiento"
'        Function Maintenance(ByVal item As CtaCte)
'#End Region

'#Region "Consulta"
'        Function CtaCteQuery(ByVal CCT_ID As String, ByVal CCT_DESCRIPCION As String)
'        Function CtaCteSeek(ByVal id As String) As BE.CtaCte
'#End Region

'    End Interface

'End Namespace