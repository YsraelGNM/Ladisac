Imports Microsoft.Practices.Prism.UnityExtensions
Imports Microsoft.Practices.Unity

Namespace Ladisac.Shell
    Public Class Bootstrapper
        Inherits Microsoft.Practices.Prism.UnityExtensions.UnityBootstrapper

        Public MainForm As Ladisac.Foundation.MainWindow

        Protected Overrides Function CreateContainer() As Microsoft.Practices.Unity.IUnityContainer
            Dim ContainerService = New UnityContainer
            Return ContainerService
        End Function

        Protected Overrides Sub ConfigureContainer()
            Container.RegisterType(Of Microsoft.Practices.ServiceLocation.IServiceLocator, Microsoft.Practices.Prism.UnityExtensions.UnityServiceLocatorAdapter)(New ContainerControlledLifetimeManager) 'singleton
            Container.RegisterType(Of Microsoft.Practices.Prism.Modularity.IModuleManager, Microsoft.Practices.Prism.Modularity.ModuleManager)(New ContainerControlledLifetimeManager)
            Container.RegisterType(Of Microsoft.Practices.Prism.Modularity.IModuleInitializer, Microsoft.Practices.Prism.Modularity.ModuleInitializer)(New ContainerControlledLifetimeManager)
            Container.RegisterType(Of Microsoft.Practices.Prism.Regions.RegionAdapterMappings, Microsoft.Practices.Prism.Regions.RegionAdapterMappings)(New ContainerControlledLifetimeManager)
            Container.RegisterType(Of Microsoft.Practices.Prism.Regions.IRegionManager, Microsoft.Practices.Prism.Regions.RegionManager)(New ContainerControlledLifetimeManager)
            Container.RegisterType(Of Microsoft.Practices.Prism.Events.IEventAggregator, Microsoft.Practices.Prism.Events.EventAggregator)(New Microsoft.Practices.Unity.ContainerControlledLifetimeManager)
            Container.RegisterType(Of Microsoft.Practices.Prism.Regions.IRegionViewRegistry, Microsoft.Practices.Prism.Regions.RegionViewRegistry)(New ContainerControlledLifetimeManager)
            Container.RegisterType(Of Microsoft.Practices.Prism.Regions.IRegionBehaviorFactory, Microsoft.Practices.Prism.Regions.RegionBehaviorFactory)(New ContainerControlledLifetimeManager)
            Container.RegisterType(Of Microsoft.Practices.Prism.Logging.ILoggerFacade, Microsoft.Practices.Prism.Logging.EmptyLogger)(New ContainerControlledLifetimeManager)
            Container.RegisterType(Of Microsoft.Practices.Prism.Modularity.IModuleCatalog, Microsoft.Practices.Prism.Modularity.ConfigurationModuleCatalog)(New ContainerControlledLifetimeManager)

            'menu

            Me.Container.RegisterType(Of Ladisac.Foundation.MainWindow)(New ContainerControlledLifetimeManager)
            Container.RegisterType(Of Ladisac.Foundation.Services.IMenuService, Ladisac.Foundation.Services.MenuService)(New ContainerControlledLifetimeManager)

        End Sub

        Protected Overrides Function CreateLogger() As Microsoft.Practices.Prism.Logging.ILoggerFacade
            Return New Microsoft.Practices.Prism.Logging.EmptyLogger()
        End Function

        Protected Overrides Sub InitializeShell()
            Me.Container.Resolve(Of Ladisac.Foundation.Services.IMenuService).RegistrarMenuPrincipal(Me.MainForm.menuPrincipal)
        End Sub
        Protected Overrides Function CreateShell() As System.Windows.DependencyObject
            Me.MainForm = Me.Container.Resolve(Of Ladisac.Foundation.MainWindow)()
            Return New PresentacionWPF
        End Function

        Protected Overrides Function CreateModuleCatalog() As Microsoft.Practices.Prism.Modularity.IModuleCatalog
            Dim catalog = New Microsoft.Practices.Prism.Modularity.ConfigurationModuleCatalog()
            Return catalog
        End Function
        Public Overrides Sub Run(ByVal runWithDefaultConfiguration As Boolean)
            MyBase.Run(runWithDefaultConfiguration)
        End Sub
        Protected Overrides Sub InitializeModules()
            MyBase.InitializeModules()
        End Sub
        


    End Class
End Namespace

