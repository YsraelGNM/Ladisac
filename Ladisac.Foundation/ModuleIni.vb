Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Unity
Namespace Ladisac.Foundation
    Public Class ModuleIni
        Implements IModule

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub Initialize() Implements Microsoft.Practices.Prism.Modularity.IModule.Initialize
            RegistrarDA()
            RegistrarBL()
            RegistrarServices()
            RegistrarComponentes()
        End Sub
        Public Sub RegistrarServices()
            Me.ContainerService.RegisterType(Of Services.ISessionService, Services.SessionService)(New ContainerControlledLifetimeManager)

        End Sub
        Public Sub RegistrarDA()
            ContainerService.RegisterType(Of DA.IReportesRepositorio, DA.ReportesRepositorio)()
            ContainerService.RegisterType(Of DA.ITiposConceptosRepositorio, DA.TiposConceptosRepositorio)()

            ContainerService.RegisterType(Of DA.IMaestroRepositorio, DA.MaestroRepositorio)(New ContainerControlledLifetimeManager)
            ContainerService.RegisterType(Of DA.IPermisoUsuarioRepositorio, DA.PermisoUsuarioRepositorio)()
        End Sub
        Public Sub RegistrarBL()
            ContainerService.RegisterType(Of BL.IBCSolicitudSoporte, BL.BCSolicitudSoporte)()
            'ContainerService.RegisterType(Of BL.IBCMonedaQueries, BL.BCMoneda)()

            ContainerService.RegisterType(Of BL.IBCMaestro, BL.BCMaestro)()
            ContainerService.RegisterType(Of BL.IBCBusqueda, BL.BCBusqueda)()

            ContainerService.RegisterType(Of BL.IBCTiposConceptosQueries, BL.BCTiposConceptos)()
            ContainerService.RegisterType(Of BL.IBCTiposConceptos, BL.BCTiposConceptos)()

            'ContainerService.RegisterType(Of Ladisac.BL.IBCMaestro, Ladisac.BL.BCMaestro)()
            ContainerService.RegisterType(Of Ladisac.BL.IBCPermisoUsuario, Ladisac.BL.BCPermisoUsuario)()
        End Sub

        Private Sub RegistrarComponentes()
            ContainerService.RegisterType(Of Ladisac.Foundation.ModuleController) _
                (New Microsoft.Practices.Unity.ContainerControlledLifetimeManager)
            Dim controlller = ContainerService.Resolve(Of Ladisac.Foundation.ModuleController)()
            controlller.run()
            '''''
        End Sub
    End Class
End Namespace
