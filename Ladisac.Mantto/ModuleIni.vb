Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Unity

Namespace Ladisac.Mantto
    Public Class ModuleIni
        Implements IModule

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub Initialize() Implements Microsoft.Practices.Prism.Modularity.IModule.Initialize
            RegistrarDA()
            RegistrarBL()
            RegistrarComponentes()

        End Sub


        Public Sub RegistrarDA()
            ContainerService.RegisterType(Of DA.ITipoEntidadRepositorio, DA.TipoEntidadRepositorio)()
            ContainerService.RegisterType(Of DA.IEntidadRepositorio, DA.EntidadRepositorio)()
            ContainerService.RegisterType(Of DA.ICaracteristicaRepositorio, DA.CaracteristicaRepositorio)()
            ContainerService.RegisterType(Of DA.IGrupoRepositorio, DA.GrupoRepositorio)()
            ContainerService.RegisterType(Of DA.ITipoFallaRepositorio, DA.TipoFallaRepositorio)()
            ContainerService.RegisterType(Of DA.IHerramientasRepositorio, DA.HerramientasRepositorio)()
            ContainerService.RegisterType(Of DA.ITipoClaseManttoRepositorio, DA.TipoClaseManttoRepositorio)()
            ContainerService.RegisterType(Of DA.IManttoRepositorio, DA.ManttoRepositorio)()
            ContainerService.RegisterType(Of DA.IInspeccionRepositorio, DA.InspeccionRepositorio)()
            ContainerService.RegisterType(Of DA.IEspecificacionRepositorio, DA.EspecificacionRepositorio)()
            ContainerService.RegisterType(Of DA.IImagenRepositorio, DA.ImagenRepositorio)()
            ContainerService.RegisterType(Of DA.IEntidadInspeccionRepositorio, DA.EntidadInspeccionRepositorio)()
            ContainerService.RegisterType(Of DA.IComponenteInspeccionRepositorio, DA.ComponenteInspeccionRepositorio)()
            ContainerService.RegisterType(Of DA.IParametroEntidadRepositorio, DA.ParametroEntidadRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenTrabajoRepositorio, DA.OrdenTrabajoRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenTrabajoPersonalRepositorio, DA.OrdenTrabajoPersonalRepositorio)()
            ContainerService.RegisterType(Of DA.IPlanMantenimientoRepositorio, DA.PlanMantenimientoRepositorio)()
            ContainerService.RegisterType(Of DA.ITipoManttoRepositorio, DA.TipoManttoRepositorio)()
            ContainerService.RegisterType(Of DA.IInspeccionPreOrdenTrabajoRepositorio, DA.InspeccionPreOrdenTrabajoRepositorio)()
            ContainerService.RegisterType(Of DA.ISuministroPlanManttoRepositorio, DA.SuministroPlanManttoRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenTrabajoEntidadRepositorio, DA.OrdenTrabajoEntidadRepositorio)()
            ContainerService.RegisterType(Of DA.IRegistroMaquinaRepositorio, DA.RegistroMaquinaRepositorio)()
            ContainerService.RegisterType(Of DA.IRegistroEquipoRepositorio, DA.RegistroEquipoRepositorio)()
            ContainerService.RegisterType(Of DA.IPlantillaDocuIsoRepositorio, DA.PlantillaDocuIsoRepositorio)()
            ContainerService.RegisterType(Of DA.IDocuIsoRepositorio, DA.DocuIsoRepositorio)()
            ContainerService.RegisterType(Of DA.IAreaRepositorio, DA.AreaRepositorio)()
            ContainerService.RegisterType(Of DA.IFotoPersonaRepositorio, DA.FotoPersonaRepositorio)()
            ContainerService.RegisterType(Of DA.IFichaInspeccionRepositorio, DA.FichaInspeccionRepositorio)()
            ContainerService.RegisterType(Of DA.IFichaInspeccionDetalleRepositorio, DA.FichaInspeccionDetalleRepositorio)()
        End Sub

        Public Sub RegistrarBL()
            ContainerService.RegisterType(Of BL.IBCTipoEntidad, BL.BCTipoEntidad)()
            ContainerService.RegisterType(Of BL.IBCEntidad, BL.BCEntidad)()
            ContainerService.RegisterType(Of BL.IBCCaracteristica, BL.BCCaracteristica)()
            ContainerService.RegisterType(Of BL.IBCGrupo, BL.BCGrupo)()
            ContainerService.RegisterType(Of BL.IBCTipoFalla, BL.BCTipoFalla)()
            ContainerService.RegisterType(Of BL.IBCHerramientas, Ladisac.BL.BCHerramientas)()
            ContainerService.RegisterType(Of BL.IBCTipoClaseMantto, Ladisac.BL.BCTipoClaseMantto)()
            ContainerService.RegisterType(Of BL.IBCMantto, Ladisac.BL.BCMantto)()
            ContainerService.RegisterType(Of BL.IBCTipoMantto, Ladisac.BL.BCTipoMantto)()
            ContainerService.RegisterType(Of BL.IBCInspeccion, Ladisac.BL.BCInspeccion)()
            ContainerService.RegisterType(Of BL.IBCEspecificacion, Ladisac.BL.BCEspecificacion)()
            ContainerService.RegisterType(Of BL.IBCImagen, Ladisac.BL.BCImagen)()
            ContainerService.RegisterType(Of BL.IBCEntidadInspeccion, Ladisac.BL.BCEntidadInspeccion)()
            ContainerService.RegisterType(Of BL.IBCComponenteInspeccion, Ladisac.BL.BCComponenteInspeccion)()
            ContainerService.RegisterType(Of BL.IBCParametroEntidad, Ladisac.BL.BCParametroEntidad)()
            ContainerService.RegisterType(Of BL.IBCOrdenTrabajo, Ladisac.BL.BCOrdenTrabajo)()
            ContainerService.RegisterType(Of BL.IBCPlanMantenimiento, Ladisac.BL.BCPlanMantenimiento)()
            ContainerService.RegisterType(Of BL.IBCTipoMantto, Ladisac.BL.BCTipoMantto)()
            ContainerService.RegisterType(Of BL.IBCInspeccionPreOrdenTrabajo, Ladisac.BL.BCInspeccionPreOrdenTrabajo)()
            ContainerService.RegisterType(Of BL.IBCRegistroMaquina, Ladisac.BL.BCRegistroMaquina)()
            ContainerService.RegisterType(Of BL.IBCRegistroEquipo, Ladisac.BL.BCRegistroEquipo)()
            ContainerService.RegisterType(Of BL.IBCPlantillaDocuIso, Ladisac.BL.BCPlantillaDocuIso)()
            ContainerService.RegisterType(Of BL.IBCDocuIso, Ladisac.BL.BCDocuIso)()
            ContainerService.RegisterType(Of BL.IBCArea, Ladisac.BL.BCArea)()
            ContainerService.RegisterType(Of BL.IBCFotoPersona, Ladisac.BL.BCFotoPersona)()
            ContainerService.RegisterType(Of BL.IBCFichaInspeccion, Ladisac.BL.BCFichaInspeccion)()
        End Sub

        Private Sub RegistrarComponentes()
            ContainerService.RegisterType(Of Ladisac.Mantto.ModuleController) _
                (New Microsoft.Practices.Unity.ContainerControlledLifetimeManager)

            Dim controlller = ContainerService.Resolve(Of Ladisac.Mantto.ModuleController)()
            controlller.run()

        End Sub
    End Class
End Namespace


