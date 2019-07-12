Namespace Ladisac.DA 'Namespace Ladisac.DA
    Partial Public Class SPNames
        'Corretivo
        Public Shared ReadOnly SPCorrelativo As String = "pla.SPCorrelativo"


        'TiposConceptos
        Public Shared ReadOnly SPTiposConceptosUpdate As String = "pla.SPTiposConceptosUpdate"
        Public Shared ReadOnly SPTiposConceptosSelectXML As String = "pla.SPTiposConceptosSelectXML"
        Public Shared ReadOnly SPTiposConceptosInsert As String = "pla.SPTiposConceptosInsert"

        'Conceptos
        Public Shared ReadOnly SPConceptosInsert As String = "pla.SPConceptosInsert"
        Public Shared ReadOnly SPConceptosSelectXML As String = "pla.SPConceptosSelectXML"
        Public Shared ReadOnly SPConceptosUpdate As String = "pla.SPConceptosUpdate"
        Public Shared ReadOnly spCrearFunctionAcumuladoConcepton As String = "pla.spCrearFunctionAcumuladoConcepto"
       
        ' tipos contratos
        Public Shared ReadOnly SPTiposContratosSelectXML As String = "pla.SPTiposContratosSelectXML"
        Public Shared ReadOnly SPTiposContratosUpdate As String = "pla.SPTiposContratosUpdate"

        'periodo laboral
        Public Shared ReadOnly SPPeriodisidadSelectXML As String = "pla.SPPeriodisidadSelectXML"
        Public Shared ReadOnly SPPeriodisidadUpdate As String = "SPPeriodisidadUpdate"

        'tipos cargos
        Public Shared ReadOnly SPTiposCargosSelectXML As String = "pla.SPTiposCargosSelectXML"
        Public Shared ReadOnly SPTiposCargosUpdate As String = "pla.SPTiposCargosUpdate"

        'Nivelde  educacion
        Public Shared ReadOnly SPNivelEducacionSelectXML As String = "pla.SPNivelEducacionSelectXML"

        'Convenio doble tributacion
        Public Shared ReadOnly SPConvenioDobleTributacionSelectXML As String = "pla.SPConvenioDobleTributacionSelectXML"

        'Tipos trabajador
        Public Shared ReadOnly SPTiposTrabajadorSelectXML As String = "pla.SPTiposTrabajadorSelectXML"

        'Regimen laboral
        Public Shared ReadOnly SPRegimenLaboralSelectXML As String = "pla.SPRegimenLaboralSelectXML"

        'Regimen pensionario
        Public Shared ReadOnly SPRegimenPensionarioXML As String = "pla.SPRegimenPensionarioXML"

        'Situacion Especial Trabajador 
        Public Shared ReadOnly SPSituacionEspecialTrabajadorSelectXML As String = "pla.SPSituacionEspecialTrabajadorSelectXML"

        ' Situacion Trabajador 
        Public Shared ReadOnly SPSituacionTrabajadorSelectXML As String = "pla.SPSituacionTrabajadorSelectXML"
        ' tipos de planillas
        Public Shared ReadOnly SPTiposPlanillasSelectXML As String = "pla.SPTiposPlanillasSelectXML"

        ' conceptos por tipod eplanilla
        Public Shared ReadOnly SPConceptosPlanillaSelectXML As String = "pla.SPConceptosPlanillaSelectXML"
        Public Shared ReadOnly SPConceptosPlanillaDetalleSelectXML As String = "pla.SPConceptosPlanillaDetalleSelectXML"

        ' tipos de tareo
        Public Shared ReadOnly SPTiposTareosSelectXML As String = "pla.SPTiposTareosSelectXML"
        Public Shared ReadOnly SPTareaTrabajoExportarSelect As String = "pla.SPTareaTrabajoExportarSelect"


        'datos personales
        '******************************************************
        'return tabla datosPersonales    
        Public Shared ReadOnly SPDatosLaboralesSelectXML As String = "pla.SPDatosLaboralesSelectXML"
        'retorna ID_persona ,codigoTrabajador ,nombre
        Public Shared ReadOnly SPDatosLaboralesListaSelectXML As String = "pla.SPDatosLaboralesListaSelectXML"
        '        busa personas para crear datos laborales/bancos entre otros
        Public Shared ReadOnly SPPersonasEntidadSelectXML As String = "pla.SPPersonasEntidadSelectXML"
        'return tabla datosPersonales  y sus referencias   
        Public Shared ReadOnly SPDatosLaboralesDetalleSelectXML As String = "pla.SPDatosLaboralesDetalleSelectXML"

        Public Shared ReadOnly SPEstadoCivilXML As String = "pla.SPEstadoCivilXML"

        Public Shared ReadOnly SPTrabajadorCumpleaños As String = "pla.SPTrabajadorCumpleaños"

        Public Shared ReadOnly SPCronogramaVacacionesSelectXML As String = "pla.SPCronogramaVacacionesSelectXML"

        ' buscar planillas para el cronograma de vacaciones
        Public Shared ReadOnly spPlanillaCronogramaVacacionesBuscarSelectXML As String = "pla.spPlanillaCronogramaVacacionesBuscarSelectXML"
        ' horarios de trabajo
        Public Shared ReadOnly SPDatosLaboralesHorarioSelectXML As String = "pla.SPDatosLaboralesHorarioSelectXML"
        Public Shared ReadOnly spDetalleGrupoEmpleadoMaintenanceSelect As String = "pla.spDetalleGrupoEmpleadoMaintenanceSelect"

        '*********************************************************

        ' detalle de planillas  conceptos 
        Public Shared ReadOnly SPCentroRiesgoSelectXML As String = "pla.SPCentroRiesgoSelectXML"

        Public Shared ReadOnly SPAreaTrabajosSelectXML As String = "pla.SPAreaTrabajosSelectXML"
        Public Shared ReadOnly SPConceptosXTipoPlanillaSelectXML As String = "pla.SPConceptosXTipoPlanillaSelectXML"

        Public Shared ReadOnly SPDetalleConceptosPensionariosSelectXML As String = "pla.SPDetalleConceptosPensionariosSelectXML"
        Public Shared ReadOnly SPDetalleConceptosPensionariosDetalleSelectXML As String = "pla.SPDetalleConceptosPensionariosDetalleSelectXML"

        Public Shared ReadOnly SPConceptosTrabajadorSelectXML As String = "pla.SPConceptosTrabajadorSelectXML"

        '----------------------------
        ' solo return la table  de DetalleConceptosPlanillas
        Public Shared ReadOnly SPDetalleConceptosPlanillasSelectXML As String = "pla.SPDetalleConceptosPlanillasSelectXML"
        'return  el DetalleConceptosPlanillas y sus referencias
        Public Shared ReadOnly SPDetalleConceptosPlanillasDetalleSelectXML As String = "pla.SPDetalleConceptosPlanillasDetalleSelectXML"
        Public Shared ReadOnly SPDetalleConceptosPlanillasListaSelectXML As String = "pla.SPDetalleConceptosPlanillasListaSelectXML"
        '----------------------------

        Public Shared ReadOnly SPTiposTareaTrabajoSelectXML As String = "pla.SPTiposTareaTrabajoSelectXML"

        Public Shared ReadOnly SPDatosTrabajadorJudicialSelectXML As String = "pla.SPDatosTrabajadorJudicialSelectXML"
        Public Shared ReadOnly SPDetalleTrabajadorJudicialSelectXML As String = "pla.SPDetalleTrabajadorJudicialSelectXML"

        Public Shared ReadOnly SPPrestamosTrabajadorSelectXML As String = "pla.SPPrestamosTrabajadorSelectXML"
        Public Shared ReadOnly SPDetallePrestamosTrabajadorSelectXML As String = "pla.SPDetallePrestamosTrabajadorSelectXML"

        Public Shared ReadOnly SPTareaTrabajoSelectXML As String = "pla.SPTareaTrabajoSelectXML"

        '---grupo de trbajo por hora y por tarea
        Public Shared ReadOnly SPGrupoTrabajoSelectXML As String = "pla.SPGrupoTrabajoSelectXML"

        Public Shared ReadOnly SPDetalleGrupoTrabajoSelectXML As String = "pla.SPDetalleGrupoTrabajoSelectXML"
        Public Shared ReadOnly SPGrupoTrabajoDelete As String = "pla.SPGrupoTrabajoDelete"
        Public Shared ReadOnly SPPvwGrupoTrabajoHorasSelectXML As String = "pla.SPPvwGrupoTrabajoHorasSelectXML"
        Public Shared ReadOnly SPProduccionCargaConteoSelectXML As String = "pla.SPProduccionCargaConteoSelectXML"
        Public Shared ReadOnly SPDetalleGrupoTrabajoMaintenanceSelect As String = "pla.SPDetalleGrupoTrabajoMaintenanceSelect"
        Public Shared ReadOnly spGrupoTrabajoQuemaSecaderoSelectXML As String = "pla.spGrupoTrabajoQuemaSecaderoSelectXML"
        Public Shared ReadOnly spGrupoTrabajoQuemaSecaderoAgrupagoSelectXML As String = "pla.spGrupoTrabajoQuemaSecaderoAgrupagoSelectXML"
        Public Shared ReadOnly SPReporteTrabajoHoraDetalle As String = "pla.SPReporteTrabajoHoraDetalle"
        Public Shared ReadOnly spGrupoTrabajoSecaderoAgrupagoModificarSelectXML As String = "pla.spGrupoTrabajoSecaderoAgrupagoModificarSelectXML"

        '---- grupo de trabajo horas dobles, se guarda y se consulta por semana

        Public Shared ReadOnly SPGrupoTrabajoDiasDescansoRepositorio As String = "pla.SPGrupoTrabajoDiasDescansoRepositorio"
        Public Shared ReadOnly spGrupoTrabajoDiasDescansoSelect As String = "pla.spGrupoTrabajoDiasDescansoSelect"
        Public Shared ReadOnly spGrupoTrabajoDiasDescansoReporte As String = "pla.spGrupoTrabajoDiasDescansoReporte"
        '----------- grupo trabajo Mantenimiento
        Public Shared ReadOnly SPGrupoMantenimientoSelectXML As String = "pla.SPGrupoMantenimientoSelectXML"
        Public Shared ReadOnly SPGrupoMantenimientoDelete As String = "pla.SPGrupoMantenimientoDelete"
        Public Shared ReadOnly SPGrupoMantenimientoOrdenTrabajoSelectXML As String = "pla.SPGrupoMantenimientoOrdenTrabajoSelectXML"
        Public Shared ReadOnly SPPvwGrupoMantenimientoHorasSelectXML As String = "pla.SPPvwGrupoMantenimientoHorasSelectXML"
        Public Shared ReadOnly SPDetalleHorasXTrabajadorMantenimiento As String = "pla.SPDetalleHorasXTrabajadorMantenimiento"

        '----------- grupo empleado
        Public Shared ReadOnly SPGrupoEmpleadoSelectXML As String = "pla.SPGrupoEmpleadoSelectXML"
        Public Shared ReadOnly SPGrupoEmpleadoDelete As String = "pla.SPGrupoEmpleadoDelete"
        Public Shared ReadOnly SPGrupoEmpleadoHorasSelect As String = "pla.SPGrupoEmpleadoHorasSelect"
        Public Shared ReadOnly SPPvwGrupoEmpleadoHorasSelectXML As String = "pla.SPPvwGrupoEmpleadoHorasSelectXML"
        Public Shared ReadOnly SPDetalleHorasXTrabajadorEmpleado As String = "pla.SPDetalleHorasXTrabajadorEmpleado"

        Public Shared ReadOnly SPPeriodoLaboralUpdate As String = "pla.SPPeriodoLaboralUpdate"

        '--- permisos para trabajadores
        Public Shared ReadOnly SPPermisosTrabajadorSelectXML As String = "pla.SPPermisosTrabajadorSelectXML"
        Public Shared ReadOnly spReportePermisosTrabajador As String = "pla.spReportePermisosTrabajador"
        Public Shared ReadOnly SPDetallePermisosTrabajadorSelectXML As String = "pla.SPDetallePermisosTrabajadorSelectXML"


        '--- trabajador horas 

        Public Shared ReadOnly SPTrabajadorHorasSelectXML As String = "pla.SPTrabajadorHorasSelectXML"
        Public Shared ReadOnly SPDetalleTrabajadorHorasMaintenanceSelect As String = "pla.SPDetalleTrabajadorHorasMaintenanceSelect"
        Public Shared ReadOnly SPDetalleHorasXTrabajador As String = "pla.SPDetalleHorasXTrabajador"

        '----------------------------


        Public Shared ReadOnly SPCalendarioDiasSelectXML As String = "pla.SPCalendarioDiasSelectXML"

        ' reparo de horas
        Public Shared ReadOnly SPReparoTrabajadorSelectXML As String = "pla.SPReparoTrabajadorSelectXML"
        Public Shared ReadOnly SPDetalleReparoTrabajadorSelect As String = "pla.SPDetalleReparoTrabajadorSelect"

        ' comedor
        '----------------------------
        Public Shared ReadOnly SPComedorPLLSelectXML As String = "pla.SPComedorPLLSelectXML"
        Public Shared ReadOnly SPComedorPLLDelete As String = "pla.SPComedorPLLDelete"
        Public Shared ReadOnly spDetalleComedorMaintenanceSelect As String = "pla.spDetalleComedorMaintenanceSelect"
        Public Shared ReadOnly spDetallePrestamoSelect As String = "pla.spDetallePrestamoSelect"

        ' marcaciones de asistencia 
        '----------------------------------------------
        Public Shared ReadOnly SPDetalleMarcacionSelect As String = "pla.SPDetalleMarcacionSelect"
        Public Shared ReadOnly SPMarcacionSelectXML As String = "pla.SPMarcacionSelectXML"
        Public Shared ReadOnly spMarcacionesInsert As String = "pla.spMarcacionesInsert"
        Public Shared ReadOnly SPMarcacionColtronSelectXML As String = "pla.SPMarcacionColtronSelectXML"
        'planillas
        '---------------------

        Public Shared ReadOnly SPTrabajadorParaPlanillasSelectXML As String = "pla.SPTrabajadorParaPlanillasSelectXML"

        Public Shared ReadOnly spListaDescuentoJudicialXPlanilla As String = "pla.spListaDescuentoJudicialXPlanilla"
        Public Shared ReadOnly spTrabajadorCalculoPlanillas As String = "pla.spTrabajadorCalculoPlanillas"
        Public Shared ReadOnly spTrabajadorPagosParaPlanillasXML As String = "pla.spTrabajadorPagosParaPlanillasXML"
        Public Shared ReadOnly spTrabajadorPagosXDocPlanillas As String = "pla.spTrabajadorPagosXDocPlanillas"
        Public Shared ReadOnly spDetallePrestamoParaPlanilla As String = "pla.spDetallePrestamoParaPlanilla"

        Public Shared ReadOnly spPlanillaPersonaTotalesSelectXML As String = "pla.spPlanillaPersonaTotalesSelectXML"


        Public Shared ReadOnly spPlanillaBuscarSelectXML As String = "pla.spPlanillaBuscarSelectXML"
        Public Shared ReadOnly spPlanillaPersonaSelectXML As String = "pla.spPlanillaPersonaSelectXML"
        Public Shared ReadOnly spPlanillaPersonaDetalleSelectXML As String = "pla.spPlanillaPersonaDetalleSelectXML"
        Public Shared ReadOnly SPPlanillaDelete As String = "pla.SPPlanillaDelete"
        Public Shared ReadOnly SPDetallePlanillasUpdate As String = "pla.SPDetallePlanillasUpdate"
        Public Shared ReadOnly SPPlanillaImprimirLista As String = "pla.SPPlanillaImprimirLista"
        Public Shared ReadOnly SPPlanillaUpdate As String = "pla.SPPlanillaUpdate"
        Public Shared ReadOnly spDatosLaboralesPanelSelect As String = "pla.spDatosLaboralesPanelSelect"
        Public Shared ReadOnly spDatosLaboralesPanelHorasSelect As String = "pla.spDatosLaboralesPanelHorasSelect"
        Public Shared ReadOnly spDatosLaboralesXPlanillaTrabajador As String = "pla.spDatosLaboralesXPlanillaTrabajador"
        Public Shared ReadOnly SPPlanillasDetatalleKardexCtaCteRegenerar As String = "pla.SPPlanillasDetatalleKardexCtaCteRegenerar"

        '----- exportacion Plame y T-Registro
        Public Shared ReadOnly spPlanillaBuscarPlameSelectXML As String = "pla.spPlanillaBuscarPlameSelectXML"
        Public Shared ReadOnly SPPlanillaExportarPlameIngreEgresAportaciones As String = "pla.SPPlanillaExportarPlameIngreEgresAportaciones"

        '---Reportes y Consultas 
        Public Shared ReadOnly SPSelectReportPLLXAcumuladosXListaTrabajador As String = "pla.SPSelectReportPLLXAcumuladosXListaTrabajador"
        Public Shared ReadOnly SPSelectReportPLLXAcumuladosXTrabajador As String = "pla.SPSelectReportPLLXAcumuladosXTrabajador"
        Public Shared ReadOnly SPPlanillaImprimir As String = "pla.SPPlanillaImprimir"
        Public Shared ReadOnly SPPlanillaInsert As String = "pla.SPPlanillaInsert"
        Public Shared ReadOnly SPReporteDatosTrabajadorJudicial As String = "pla.SPReporteDatosTrabajadorJudicial"
        Public Shared ReadOnly SPReporteFichaTrabajador As String = "pla.SPReporteFichaTrabajador"
        Public Shared ReadOnly SPReportePeriodoLaboral As String = "pla.SPReportePeriodoLaboral"
        Public Shared ReadOnly SPReportePeriodoVacaciones As String = "pla.SPReportePeriodoVacaciones"
        Public Shared ReadOnly SPReporteComedor As String = "pla.SPReporteComedor"
        Public Shared ReadOnly SPReporteGrupoTrabajoHoras As String = "pla.SPReporteGrupoTrabajoHoras"

        Public Shared ReadOnly SPReporteGrupoMantenimientoAgrupado As String = "pla.SPReporteGrupoMantenimientoAgrupado"
        Public Shared ReadOnly SPReporteGrupoMantenimientoDetalle As String = "pla.SPReporteGrupoMantenimientoDetalle"
        Public Shared ReadOnly spReporteHorasPlanillasproduccion As String = "pla.spReporteHorasPlanillasproduccion"
        Public Shared ReadOnly spReportePlanillaConsolidado As String = "pla.spReportePlanillaConsolidado"

        Public Shared ReadOnly spReporteReparotrabajador As String = "pla.spReporteReparotrabajador"


    End Class

End Namespace

