Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Unity
Namespace Ladisac.Planillas
    Public Class ModuleIni
        Implements IModule
        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub Initialize() Implements Microsoft.Practices.Prism.Modularity.IModule.Initialize

            RegistrarDA()
            RegistrarBL()
            RegistrarVistas()
            RegistrarComponentes()

        End Sub
        Public Sub RegistrarVistas()

            ' -----------formularios -----------------------

            'para una sola vista de un tipo
            ContainerService.RegisterType(Of frmTiposConceptos)()
            'Form1
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmConceptos)()
            'ContainerService.RegisterType(Of frmTiposConceptos)(New ContainerControlledLifetimeManager)
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmTiposContratos)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmPeriodisidad)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmTiposCargos)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmNivelEducacion)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmConvenioDobleTributacion)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmTiposTrabajador)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmRegimenLaboral)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmRegimenPensionario)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmSituacionEspecialTrabajador)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmSituacionTrabajador)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmTiposPlanillas)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmConceptosPlanilla)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmDatosLaborales)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmAreaTrabajos)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmDetalleConceptoPensionario)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmConceptosTrabajador)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmDetalleConceptosPlanillas)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmTiposTareaTrabajo)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmDatosTrabajadorJudicial)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmPrestamosTrabajador)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmTareaTrabajo)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmGrupoTrabajoHora)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmGrupoTrabajoTarea)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmPermisosTrabajador)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmTrabajadorHoras)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmCalendarioDias)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReparoTrabajador)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmComedorPLL)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmCentroRiesgo)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmPlanilla)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmBuscarDocumentos)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmPlanillaMantenimiento)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmExportarPlameTRegistro)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmGrupoMantenimiento)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmMarcacion)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmGrupoTrabajoHoraClonar)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmGrupoTrabajoDiasDescanso)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmPlanillasPanelAdministracionDetalle)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmDatosLaboralesPanel)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmGrupoEmpleado)()

            '--------------- reportes ----------------------

            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReportesTrabajadorCumpleaños)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReportesXAcumuladosXTrabajador)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReportesBoletas)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReportePersona)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReportePersonaTipoFichas)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReporteComedor)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReporteGrupoTrabajoHora)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReporteGrupoTrabajoDiasDescanso)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmGrupoMantenimiento)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReporteFechaPersona)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReportesPermisosTrabajador)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReporteHorasPlanillasProduccion)()
            ContainerService.RegisterType(Of Ladisac.Planillas.Views.frmReportesTareaTrabajoExportar)()


        End Sub

        Public Sub RegistrarDA()

            ContainerService.RegisterType(Of DA.IConceptosRepositorio, Ladisac.DA.ConceptosRepositorio)()
            ContainerService.RegisterType(Of DA.ITiposConceptosRepositorio, Ladisac.DA.TiposConceptosRepositorio)()
            ContainerService.RegisterType(Of DA.ITiposContratosRepositorio, Ladisac.DA.TiposContratosRepositorio)()
            ContainerService.RegisterType(Of DA.IUtilRepositorio, Ladisac.DA.UtilRepositorio)()
            ContainerService.RegisterType(Of DA.IPeriodisidadRepositorio, Ladisac.DA.PeriodisidadRepositorio)()
            ContainerService.RegisterType(Of DA.ITiposCargosRepositorio, Ladisac.DA.TiposCargosRepositorio)()
            ContainerService.RegisterType(Of DA.INivelEducacionRepositorio, Ladisac.DA.NivelEducacionRepositorio)()
            ContainerService.RegisterType(Of DA.IConvenioDobleTributacionRepositorio, Ladisac.DA.ConvenioDobleTributacionRepositorio)()
            ContainerService.RegisterType(Of DA.ITiposTrabajadorRepositorio, Ladisac.DA.TiposTrabajadorRepositorio)()
            ContainerService.RegisterType(Of DA.IRegimenLaboralRepositorio, Ladisac.DA.RegimenLaboralRepositorio)()
            ContainerService.RegisterType(Of DA.IRegimenPensionarioRepositorio, Ladisac.DA.RegimenPensionarioRepositorio)()
            ContainerService.RegisterType(Of DA.ISituacionEspecialTrabajadorRepositorio, Ladisac.DA.SituacionEspecialTrabajadorRepositorio)()
            ContainerService.RegisterType(Of DA.ISituacionTrabajadorRepositorio, DA.SituacionTrabajadorRepositorio)()
            ContainerService.RegisterType(Of DA.ITiposPlanillasRepositorio, DA.TiposPlanillasRepositorio)()
            ContainerService.RegisterType(Of DA.IConceptosPlanillaRepositorio, DA.ConceptosPlanillaRepositorio)()
            ContainerService.RegisterType(Of DA.ITiposTareosRepositorio, DA.TiposTareosRepositorio)()
            ContainerService.RegisterType(Of DA.IDatosLaboralesRepositorio, DA.DatosLaboralesRepositorio)()
            ContainerService.RegisterType(Of DA.IDatosLaboralesRepositorio, DA.DatosLaboralesRepositorio)()
            ContainerService.RegisterType(Of DA.IAreaTrabajosRepositorio, DA.AreaTrabajosRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleConceptoPensionarioRepositorio, DA.DetalleConceptoPensionarioRepositorio)()
            ContainerService.RegisterType(Of DA.IConceptosTrabajadorRepositorio, DA.ConceptosTrabajadorRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleConceptosPlanillasRepositorio, DA.DetalleConceptosPlanillasRepositorio)()
            ContainerService.RegisterType(Of DA.ITiposTareaTrabajoRepositorio, DA.TiposTareaTrabajoRepositorio)()
            ContainerService.RegisterType(Of DA.IDatosTrabajadorJudicialRepositorio, DA.DatosTrabajadorJudicialRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleTrabajadorJudicialRepositorio, DA.DetalleTrabajadorJudicialRepositorio)()
            ContainerService.RegisterType(Of DA.IPrestamosTrabajadorRepositorio, DA.PrestamosTrabajadorRepositorio)()
            ContainerService.RegisterType(Of DA.IDetallePrestamosTrabajadorRepositorio, DA.DetallePrestamosTrabajadorRepositorio)()
            ContainerService.RegisterType(Of DA.ITareaTrabajoRepositorio, DA.TareaTrabajoRepositorio)()
            ContainerService.RegisterType(Of DA.IGrupoTrabajoRepositorio, DA.GrupoTrabajoRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleGrupoTrabajoRepositorio, DA.DetalleGrupoTrabajoRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleGrupoEmpleadoRepositorio, DA.DetalleGrupoEmpleadoRepositorio)()

            ContainerService.RegisterType(Of DA.IGrupoEmpleadoRepositorio, DA.GrupoEmpleadoRepositorio)()

            ContainerService.RegisterType(Of DA.ICronogramaVacacionesRepositorio, DA.CronogramaVacacionesRepositorio)()
            ContainerService.RegisterType(Of DA.IPermisosTrabajadorRepositorio, DA.PermisosTrabajadorRepositorio)()
            ContainerService.RegisterType(Of DA.IDetallePermisosTrabajadorRepositorio, DA.DetallePermisosTrabajadorRepositorio)()
            ContainerService.RegisterType(Of DA.ITrabajadorHorasRepositorio, DA.TrabajadorHorasRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleTrabajadorHorasRepositorio, DA.DetalleTrabajadorHorasRepositorio)()
            ContainerService.RegisterType(Of DA.ICalendarioDiasRespositorio, DA.CalendarioDiasRespositorio)()
            ContainerService.RegisterType(Of DA.IReparoTrabajadorRepositorio, DA.ReparoTrabajadorRepositorio)()
            ContainerService.RegisterType(Of DA.IComedorRepositorio, DA.ComedorRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleComedorRepositorio, DA.DetalleComedorRepositorio)()
            ContainerService.RegisterType(Of DA.IPlanillaRepositorio, DA.PlanillaRepositorio)()
            ContainerService.RegisterType(Of DA.IDetallePlanillaRepositorio, DA.DetallePlanillaRepositorio)()
            ContainerService.RegisterType(Of DA.ICentroRiesgoRepositorio, DA.CentroRiesgoRepositorio)()
            ContainerService.RegisterType(Of DA.IPlanillasComedorHorasRepositorio, DA.PlanillasComedorHorasRepositorio)()
            ContainerService.RegisterType(Of DA.IPeriodoLaboralRepositorio, DA.PeriodoLaboralRepositorio)()
            ContainerService.RegisterType(Of DA.IGrupoMantenimientoRepositorio, DA.GrupoMantenimientoRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleGrupoMantenimientoRepositorio, DA.DetalleGrupoMantenimientoRepositorio)()
            ContainerService.RegisterType(Of DA.IMarcacionRepositorio, DA.MarcacionRepositorio)()
            ContainerService.RegisterType(Of DA.IGrupoEmpleadoRepositorio, DA.GrupoEmpleadoRepositorio)()
            ContainerService.RegisterType(Of DA.IPlanillaTrabajadorRepositorio, DA.PlanillaTrabajadorRepositorio)()
        End Sub
        Public Sub RegistrarBL()
            ContainerService.RegisterType(Of Ladisac.BL.IBCConceptos, Ladisac.BL.BCConceptos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTiposConceptos, Ladisac.BL.BCTiposConceptos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTiposContratos, Ladisac.BL.BCTiposContratos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCUtil, Ladisac.BL.BCUtil)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCPeriodisidad, Ladisac.BL.BCPeriodisidad)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTiposCargos, Ladisac.BL.BCTiposCargos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCNivelEducacion, Ladisac.BL.BCNivelEducacion)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCConvenioDobleTributacion, Ladisac.BL.BCConvenioDobleTributacion)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTiposTrabajador, Ladisac.BL.BCTiposTrabajador)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCRegimenLaboral, Ladisac.BL.BCRegimenLaboral)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCRegimenPensionario, Ladisac.BL.BCRegimenPensionario)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCSituacionEspecialTrabajador, Ladisac.BL.BCSituacionEspecialTrabajador)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCSituacionTrabajador, Ladisac.BL.BCSituacionTrabajador)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTiposPlanillas, Ladisac.BL.BCTiposPlanillas)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCConceptosPlanilla, Ladisac.BL.BCConceptosPlanilla)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCTiposTareos, Ladisac.BL.BCTiposTareos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDatosLaborales, Ladisac.BL.BCDatosLaborales)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDatosLaborales, Ladisac.BL.BCDatosLaborales)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCCentroCosto, Ladisac.BL.BCCentroCosto)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCAreaTrabajos, BL.BCAreaTrabajos)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleConceptoPensionario, BL.BCDetalleConceptoPensionario)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCConceptosTrabajador, BL.BCConceptosTrabajador)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCDetalleConceptosPlanillas, BL.BCDetalleConceptosPlanillas)()
            ContainerService.RegisterType(Of BL.IBCTiposTareaTrabajo, BL.BCTiposTareaTrabajo)()
            ContainerService.RegisterType(Of BL.IBCDatosTrabajadorJudicial, BL.BCDatosTrabajadorJudicial)()
            ContainerService.RegisterType(Of BL.IBCDetalleTrabajadorJudicial, BL.BCDetalleTrabajadorJudicial)()
            ContainerService.RegisterType(Of BL.IBCPrestamosTrabajador, BL.BCPrestamosTrabajador)()
            ContainerService.RegisterType(Of BL.IBCDetallePrestamosTrabajador, BL.BCDetallePrestamosTrabajador)()
            ContainerService.RegisterType(Of BL.IBCTareaTrabajo, BL.BCTareaTrabajo)()
            ContainerService.RegisterType(Of BL.IBCGrupoTrabajo, BL.BCGrupoTrabajo)()
            ContainerService.RegisterType(Of BL.IBCDetalleGrupoTrabajo, BL.BCDetalleGrupoTrabajo)()
            ContainerService.RegisterType(Of BL.IBCProduccion, BL.BCProduccion)()
            ContainerService.RegisterType(Of BL.IBCPlanta, BL.BCPlanta)()
            ContainerService.RegisterType(Of BL.IBCCronogramaVacaciones, BL.BCCronogramaVacaciones)()
            ContainerService.RegisterType(Of BL.IBCPermisosTrabajador, BL.BCPermisosTrabajador)()
            ContainerService.RegisterType(Of BL.IBCDetallePermisosTrabajador, BL.BCDetallePermisosTrabajador)()
            ContainerService.RegisterType(Of BL.IBCTrabajadorHoras, BL.BCTrabajadorHoras)()
            ContainerService.RegisterType(Of BL.IBCDetalleTrabajadorHoras, BL.BCDetalleTrabajadorHoras)()
            ContainerService.RegisterType(Of BL.IBCCalendarioDias, BL.BCCalendarioDias)()
            ContainerService.RegisterType(Of BL.IBCReparoTrabajador, BL.BCReparoTrabajador)()
            ContainerService.RegisterType(Of BL.IBCComedor, BL.BCComedor)()
            ContainerService.RegisterType(Of BL.IBCDetalleComedor, BL.BCDetalleComedor)()
            ContainerService.RegisterType(Of BL.IBCPlanilla, BL.BCPlanilla)()
            ContainerService.RegisterType(Of BL.IBCDetallePlanilla, BL.BCDetallePlanilla)()
            ContainerService.RegisterType(Of BL.IBCCentroRiesgo, BL.BCCentroRiesgo)()
            ContainerService.RegisterType(Of BL.IBCConsultasReportesPlanillas, BL.BCConsultasReportesPlanillas)()
            ContainerService.RegisterType(Of BL.IBCPlanillasComedorHoras, BL.IBCPlanillasComedorHoras)()
            ContainerService.RegisterType(Of BL.IBCPeriodoLaboral, BL.BCPeriodoLaboral)()
            ContainerService.RegisterType(Of BL.IBCGrupoMantenimiento, BL.BCGrupoMantenimiento)()
            ContainerService.RegisterType(Of BL.IBCDetalleGrupoMantenimiento, BL.BCDetalleGrupoMantenimiento)()
            ContainerService.RegisterType(Of BL.IBCMarcacion, BL.BCMarcacion)()
            ContainerService.RegisterType(Of BL.IBCGrupoTrabajoDiasDescanso, BL.BCGrupoTrabajoDiasDescanso)()
            ContainerService.RegisterType(Of BL.IBCPlanillaTrabajador, BL.BCPlanillaTrabajador)()

            ContainerService.RegisterType(Of BL.IBCGrupoEmpleado, BL.BCGrupoEmpleado)()
            ContainerService.RegisterType(Of BL.IBCDetalleGrupoEmpleado, BL.BCDetalleGrupoEmpleado)()
        End Sub




        Private Sub RegistrarComponentes()
            ContainerService.RegisterType(Of Ladisac.Planillas.ModuleController) _
                (New Microsoft.Practices.Unity.ContainerControlledLifetimeManager)

            Dim controlller = ContainerService.Resolve(Of Ladisac.Planillas.ModuleController)()

            controlller.rum()
        End Sub


    End Class
End Namespace

'Imports Microsoft.Practices.Prism.Modularity
'Imports Microsoft.Practices.Unity
'Namespace Ladisac.Produccion
'    Public Class ModuleIni
'        Implements IModule
'        <Dependency()> _
'        Public Property ContainerService As IUnityContainer

'        Public Sub Initialize() Implements Microsoft.Practices.Prism.Modularity.IModule.Initialize
'            RegistrarDA()
'            RegistrarBL()
'            RegistrarComponentes()

'        End Sub

'        Public Sub RegistrarDA()
'            ContainerService.RegisterType(Of DA.IParadasRepositorio, DA.ParadasRepositorio)()
'            ContainerService.RegisterType(Of DA.ITipoParadasRepositorio, DA.TipoParadasRepositorio)()
'            ContainerService.RegisterType(Of DA.IHerramientasRepositorio, DA.HerramientasRepositorio)()


'        End Sub
'        Public Sub RegistrarBL()
'            ContainerService.RegisterType(Of BL.IBCParada, BL.BCParada)()
'            ContainerService.RegisterType(Of BL.IBCTipoParada, BL.BCTipoParada)()
'            ContainerService.RegisterType(Of BL.IBCHerramientas, Ladisac.BL.BCHerramientas)()
'        End Sub

'        Private Sub RegistrarComponentes()
'            ContainerService.RegisterType(Of Ladisac.Produccion.ModuleController) _
'                (New Microsoft.Practices.Unity.ContainerControlledLifetimeManager)


'            Dim controlller = ContainerService.Resolve(Of Ladisac.Produccion.ModuleController)()
'            controlller.run()
'        End Sub
'    End Class
'End Namespace

