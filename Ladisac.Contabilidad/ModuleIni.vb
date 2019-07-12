Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Unity
Namespace Ladisac.Contabilidad
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

            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmClaseCuenta)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmCuentasContables)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmLibrosContables)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmTiposBienesServicios)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmCtaCte)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmOperacionDetraciones)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmCuentasArticulo)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmPeriodos)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmCuentasVarias)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmAsientosManuales)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmBuscarPeriodoNumero)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmCuentasPlanillas)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmProvisionCompras)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmAsientoAutomatico)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmHojaDeTrabajo)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmConsultaAsientoContable)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmBuscarDocumentosCompra)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmVisorReportes)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()

            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmConfiguracionFormatos)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmComprobantes)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmBuscarDocumentosPendientes)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmReportesXPersona)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmLeasing)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmCuentasComprobantesLogistica)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmBuscarDosParametros)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmReportePagosProveedores)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmExportarSunatPDT697)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmExportarSunatPDT626)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmReportesCentroCosto)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmReporteMayorAuxiliarMes)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmReporteCuentasProveedor)()
            ContainerService.RegisterType(Of Ladisac.Contabilidad.Views.frmReportesDAOT)()



        End Sub

        Public Sub RegistrarDA()

            ContainerService.RegisterType(Of DA.IClaseCuentaRepositorio, DA.ClaseCuentaRepositorio)()
            ContainerService.RegisterType(Of DA.ICuentasContablesRepositorio, DA.CuentasContablesRepositorio)()
            ContainerService.RegisterType(Of DA.ILibrosContablesRepositorio, DA.LibrosContablesRepositorio)()
            ContainerService.RegisterType(Of DA.ITiposBienesServiciosRepositorio, DA.TiposBienesServiciosRepositorio)()
            ContainerService.RegisterType(Of DA.ICtaCteRepositorio, DA.CtaCteRepositorio)()
            ContainerService.RegisterType(Of DA.IOperacionDetracionesRepositorio, DA.OperacionDetracionesRepositorio)()
            ContainerService.RegisterType(Of DA.ICuentasArticuloRepositorio, DA.CuentasArticuloRepositorio)()
            ContainerService.RegisterType(Of DA.ILineaFamiliaRepositorio, DA.LineaFamiliaRepositorio)()
            ContainerService.RegisterType(Of DA.IConceptosPlanillaRepositorio, DA.ConceptosPlanillaRepositorio)()
            ContainerService.RegisterType(Of DA.IPeriodoRepositorio, DA.PeriodoRepositorio)()
            ContainerService.RegisterType(Of DA.ICuentasVariasRepositorio, DA.CuentasVariasRepositorio)()
            ContainerService.RegisterType(Of DA.IAsientosManualesRepositorio, DA.AsientosManualesRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleAsientosManualesRepositorio, DA.DetalleAsientosManualesRepositorio)()
            ContainerService.RegisterType(Of DA.IProvisionComprasRepositorio, DA.ProvisionComprasRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleProvisionComprasRepositorio, DA.DetalleProvisionComprasRepositorio)()
            ContainerService.RegisterType(Of DA.IReferenciaProvisionComprasRepositorio, DA.ReferenciaProvisionComprasRepositorio)()
            ContainerService.RegisterType(Of DA.IConsultasReportesContabilidadRepositorio, DA.ConsultasReportesContabilidadRepositorio)()
            ContainerService.RegisterType(Of DA.IConfiguracionFormatosRepositorio, DA.ConfiguracionFormatosRepositorio)()

            ContainerService.RegisterType(Of DA.IComprobantesRepositorio, DA.ComprobantesRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleComprobantesRepositorio, DA.DetalleComprobantesRepositorio)()
            ContainerService.RegisterType(Of DA.ILeasingRepositorio, DA.LeasingRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleLeasingActivosFijosRepositorio, DA.DetalleLeasingActivosFijosRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleLeasingRepositorio, DA.DetalleLeasingRepositorio)()
            ContainerService.RegisterType(Of DA.ICuentasComprobantesLogisticaRepositorio, DA.CuentasComprobantesLogisticaRepositorio)()
            ContainerService.RegisterType(Of DA.IDocumentoGuiasRepositorio, DA.DocumentoGuiasRepositorio)()

            
        End Sub

        Public Sub RegistrarBL()

            ContainerService.RegisterType(Of Ladisac.BL.IBCClaseCuenta, Ladisac.BL.BCClaseCuenta)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCCuentasContables, Ladisac.BL.BCCuentasContables)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCLibrosContables, Ladisac.BL.BCLibrosContables)()
            ContainerService.RegisterType(Of BL.IBCTiposBienesServicios, BL.BCTiposBienesServicios)()
            ContainerService.RegisterType(Of BL.IBCCtaCte, BL.BCCtaCte)()
            ContainerService.RegisterType(Of BL.IBCOperacionDetraciones, BL.BCOperacionDetraciones)()
            ContainerService.RegisterType(Of BL.IBCCuentasArticulo, BL.BCCuentasArticulo)()
            ContainerService.RegisterType(Of BL.IBCLineaFamilia, BL.BCLineaFamilia)()
            ContainerService.RegisterType(Of BL.IBCConceptosPlanilla, BL.BCConceptosPlanilla)()
            ContainerService.RegisterType(Of BL.IBCPeriodos, BL.BCPeriodos)()
            ContainerService.RegisterType(Of BL.IBCCuentasVarias, BL.BCCuentasVarias)()
            ContainerService.RegisterType(Of BL.IBCAsientosManuales, BL.BCAsientosManuales)()
            ContainerService.RegisterType(Of BL.IBCDetalleAsientosManuales, BL.BCDetalleAsientosManuales)()
            ContainerService.RegisterType(Of BL.IBCProvisionCompras, BL.BCProvisionCompras)()
            ContainerService.RegisterType(Of BL.IBCDetalleProvisionCompras, BL.BCDetalleProvisionCompras)()
            ContainerService.RegisterType(Of BL.IBCAsientoAutomatico, BL.BCAsientoAutomatico)()
            ContainerService.RegisterType(Of BL.IBCConsultasReportesContabilidad, BL.BCConsultasReportesContabilidad)()
            ContainerService.RegisterType(Of BL.IBCReferenciaProvisionCompras, BL.BCReferenciaProvisionCompras)()
            ContainerService.RegisterType(Of BL.IBCConfiguracionFormatos, BL.BCConfiguracionFormatos)()



            ContainerService.RegisterType(Of BL.IBCComprobantes, BL.BCComprobantes)()
            ContainerService.RegisterType(Of BL.IBCDetalleComprobantes, BL.BCDetalleComprobantes)()
            ContainerService.RegisterType(Of BL.IBCLeasing, BL.BCLeasing)()
            ContainerService.RegisterType(Of BL.IBCDetalleLeasing, BL.BCDetalleLeasing)()
            ContainerService.RegisterType(Of BL.IBCDetalleLeasingActivosFijos, BL.BCDetalleLeasingActivosFijos)()
            ContainerService.RegisterType(Of BL.IBCCuentasComprobantesLogistica, BL.BCCuentasComprobantesLogistica)()
            ContainerService.RegisterType(Of BL.IBCDocumentoGuias, BL.BCDocumentoGuias)()

            ContainerService.RegisterType(Of BL.IBCReparables, BL.BCReparables)()

        End Sub

        Private Sub RegistrarComponentes()

            ContainerService.RegisterType(Of Ladisac.Contabilidad.ModuleController) _
                (New Microsoft.Practices.Unity.ContainerControlledLifetimeManager)
            Dim controller = ContainerService.Resolve(Of Ladisac.Contabilidad.ModuleController)()
            controller.rum()

        End Sub


    End Class

End Namespace
