Imports Microsoft.Practices.Unity
Imports System.Windows.Forms
Imports Ladisac.Foundation

Namespace Ladisac.Mantto
    Public Class ModuleController
        <Dependency()> _
        Public Property EventAggregator As Microsoft.Practices.Prism.Events.IEventAggregator
        <Dependency()> _
        Public Property ContainerService As Microsoft.Practices.Unity.IUnityContainer
        <Dependency()> _
        Public Property MenuService As Foundation.Services.IMenuService
        <Dependency()> _
        Public Property SessionServer As Foundation.Services.ISessionService

        Dim CabMenu As Integer = 0
        Dim Menu As Integer = 0

        Sub run()
            RegistrarEventos()
        End Sub

        Public Sub RegistrarEventos()
            Dim login = Me.EventAggregator.GetEvent(Of GlobalEvents.LoginEvent)()
            login.Subscribe(AddressOf onlogin)
        End Sub

        Private Sub onlogin(ByVal user As String)
            CabMenu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A") Select mPU).Count
            If CabMenu > 0 Then RegistrarMenus()
        End Sub

        Public Sub RegistrarMenus()
            Dim mMantto As New ToolStripMenuItem("Mantenimiento")
            mMantto.Name = "Mantenimiento"
            AddHandler mMantto.Click, AddressOf OnManttoClick
            ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(mMantto)
        End Sub

        Private Sub OnManttoClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            Dim mToolStrip(31) As ToolStripItem '24

            Dim menuItem As New ToolStripButton("Tipo de Entidad")
            AddHandler menuItem.Click, AddressOf OnTipoEntidadClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A01") Select mPU).Count
            If Menu > 0 Then mToolStrip(0) = menuItem

            Dim menuItem2 As New ToolStripButton("Entidad")
            AddHandler menuItem2.Click, AddressOf OnEntidadClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A02") Select mPU).Count
            If Menu > 0 Then mToolStrip(1) = menuItem2

            Dim menuItem3 As New ToolStripButton("Caracteristica")
            AddHandler menuItem3.Click, AddressOf OnCaracteristicaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A03") Select mPU).Count
            If Menu > 0 Then mToolStrip(2) = menuItem3

            Dim menuItem4 As New ToolStripButton("Grupo")
            AddHandler menuItem4.Click, AddressOf OnGrupoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A04") Select mPU).Count
            If Menu > 0 Then mToolStrip(3) = menuItem4

            Dim menuItem5 As New ToolStripButton("Tipo de Falla")
            AddHandler menuItem5.Click, AddressOf OnTipoFallaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A05") Select mPU).Count
            If Menu > 0 Then mToolStrip(4) = menuItem5

            Dim menuItem6 As New ToolStripButton("Tipo Clase Mantenimiento")
            AddHandler menuItem6.Click, AddressOf OnTipoClaseManttoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A06") Select mPU).Count
            If Menu > 0 Then mToolStrip(5) = menuItem6

            Dim menuItem7 As New ToolStripButton("Mantenimientos")
            AddHandler menuItem7.Click, AddressOf OnMantenimientoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A07") Select mPU).Count
            If Menu > 0 Then mToolStrip(6) = menuItem7

            Dim menuItem8 As New ToolStripButton("Tipo Mantenimientos")
            AddHandler menuItem8.Click, AddressOf OnTipoMantenimientoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A08") Select mPU).Count
            If Menu > 0 Then mToolStrip(7) = menuItem8

            Dim menuItem9 As New ToolStripButton("Inspeccion")
            AddHandler menuItem9.Click, AddressOf OnInspeccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A09") Select mPU).Count
            If Menu > 0 Then mToolStrip(8) = menuItem9

            Dim menuItem10 As New ToolStripButton("Especificacion")
            AddHandler menuItem10.Click, AddressOf OnEspecificacionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A10") Select mPU).Count
            If Menu > 0 Then mToolStrip(9) = menuItem10

            Dim menuItem11 As New ToolStripButton("Imagen")
            AddHandler menuItem11.Click, AddressOf OnImagenClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A11") Select mPU).Count
            If Menu > 0 Then mToolStrip(10) = menuItem11

            Dim menuItem12 As New ToolStripButton("Inspeccion por Entidad")
            AddHandler menuItem12.Click, AddressOf OnEntidadInspeccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A12") Select mPU).Count
            If Menu > 0 Then mToolStrip(11) = menuItem12

            Dim menuItem13 As New ToolStripButton("Componente por Inspeccion")
            AddHandler menuItem13.Click, AddressOf OnComponenteInspeccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A13") Select mPU).Count
            If Menu > 0 Then mToolStrip(12) = menuItem13

            Dim menuItem14 As New ToolStripButton("Parametro por Entidad")
            AddHandler menuItem14.Click, AddressOf OnParametroEntidadClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A14") Select mPU).Count
            If Menu > 0 Then mToolStrip(13) = menuItem14

            Dim menuItem15 As New ToolStripButton("Orden Trabajo")
            AddHandler menuItem15.Click, AddressOf OnOrdenTrabajoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A15") Select mPU).Count
            If Menu > 0 Then mToolStrip(14) = menuItem15

            Dim menuItem16 As New ToolStripButton("Plan Mantenimiento")
            AddHandler menuItem16.Click, AddressOf OnPlanMantenimientoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A16") Select mPU).Count
            If Menu > 0 Then mToolStrip(15) = menuItem16

            Dim menuItem17 As New ToolStripButton("Reporte Historico Orden de Trabajo")
            AddHandler menuItem17.Click, AddressOf OnRptHistoricoOrdenTrabajoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A17") Select mPU).Count
            If Menu > 0 Then mToolStrip(16) = menuItem17

            Dim menuItem18 As New ToolStripButton("Reporte Alerta de Cambios")
            AddHandler menuItem18.Click, AddressOf OnRptAlertaCambiosClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A18") Select mPU).Count
            If Menu > 0 Then mToolStrip(17) = menuItem18

            Dim menuItem19 As New ToolStripButton("Reporte Estadistica Trabajos Mantenimiento")
            AddHandler menuItem19.Click, AddressOf OnRptEstadisticaTrabajoManttoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A19") Select mPU).Count
            If Menu > 0 Then mToolStrip(18) = menuItem19

            Dim menuItem20 As New ToolStripButton("Inspeccion Pre Orden Trabajo Mantenimiento")
            AddHandler menuItem20.Click, AddressOf OnInspeccionPreOrdenTrabajoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A20") Select mPU).Count
            If Menu > 0 Then mToolStrip(19) = menuItem20

            Dim menuItem21 As New ToolStripButton("Reporte Estadistica Trabajos O.T.")
            AddHandler menuItem21.Click, AddressOf OnRptOTXMesXSemanaXAnioClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A21") Select mPU).Count
            If Menu > 0 Then mToolStrip(20) = menuItem21

            Dim menuItem22 As New ToolStripButton("Registro de Maquinaria")
            AddHandler menuItem22.Click, AddressOf OnRegistroMaquinaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A22") Select mPU).Count
            If Menu > 0 Then mToolStrip(21) = menuItem22

            Dim menuItem23 As New ToolStripButton("Arbol Entidad")
            AddHandler menuItem23.Click, AddressOf OnArbolEntidadClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A23") Select mPU).Count
            If Menu > 0 Then mToolStrip(22) = menuItem23

            Dim menuItem24 As New ToolStripButton("Vision Link")
            AddHandler menuItem24.Click, AddressOf OnVisionLinkClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A24") Select mPU).Count
            If Menu > 0 Then mToolStrip(23) = menuItem24

            Dim menuItem25 As New ToolStripButton("Registro Equipo")
            AddHandler menuItem25.Click, AddressOf OnRegistroEquipoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A25") Select mPU).Count
            If Menu > 0 Then mToolStrip(24) = menuItem25

            Dim menuItem26 As New ToolStripButton("Reporte Registro Equipo")
            AddHandler menuItem26.Click, AddressOf OnReporteRegistroEquipoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A26") Select mPU).Count
            If Menu > 0 Then mToolStrip(25) = menuItem26

            Dim menuItem27 As New ToolStripButton("Plantilla Documento ISO")
            AddHandler menuItem27.Click, AddressOf OnPlantillaDocuIsoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A27") Select mPU).Count
            If Menu > 0 Then mToolStrip(26) = menuItem27

            Dim menuItem28 As New ToolStripButton("Documento ISO")
            AddHandler menuItem28.Click, AddressOf OnDocuIsoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A28") Select mPU).Count
            If Menu > 0 Then mToolStrip(27) = menuItem28

            Dim menuItem29 As New ToolStripButton("Firma ISO")
            AddHandler menuItem29.Click, AddressOf OnFotoPersonaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A29") Select mPU).Count
            If Menu > 0 Then mToolStrip(28) = menuItem29

            Dim menuItem30 As New ToolStripButton("Listado Documentos ISO")
            AddHandler menuItem30.Click, AddressOf OnVisualizarISOClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A30") Select mPU).Count
            If Menu > 0 Then mToolStrip(29) = menuItem30

            Dim menuItem31 As New ToolStripButton("Ficha Inspeccion")
            AddHandler menuItem31.Click, AddressOf OnFichaInspeccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A31") Select mPU).Count
            If Menu > 0 Then mToolStrip(30) = menuItem31

            Dim menuItem32 As New ToolStripButton("Reporte Ficha Inspeccion")
            AddHandler menuItem32.Click, AddressOf OnReporteFichaInspeccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("A32") Select mPU).Count
            If Menu > 0 Then mToolStrip(31) = menuItem32

            'ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New ToolStripItem() {menuItem, menuItem2, menuItem3, menuItem4, menuItem5, menuItem6, menuItem7, menuItem8, menuItem9, menuItem10, menuItem11, menuItem12, menuItem13, menuItem14, menuItem15, menuItem16, menuItem17, menuItem18, menuItem19, menuItem20, menuItem21})
            Dim mToolStrip2(CabMenu - 1) As ToolStripItem '22
            Dim mCont2 As Integer = 0
            For mCont As Integer = 0 To mToolStrip.Count - 1
                If mToolStrip(mCont) IsNot Nothing Then
                    mToolStrip2(mCont2) = mToolStrip(mCont)
                    mCont2 += 1
                End If
            Next

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
        End Sub


        Private Sub OnTipoEntidadClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmTipoEntidad)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnEntidadClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmEntidad)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnCaracteristicaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmCaracteristica)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnGrupoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmGrupo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnTipoFallaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmTipoFalla)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnTipoClaseManttoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmTipoClaseMantto)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnMantenimientoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmMantenimiento)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnTipoMantenimientoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmTipoMantenimiento)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnInspeccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmInspeccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnEspecificacionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmEspecificacion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnImagenClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmImagen)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnEntidadInspeccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmEntidadInspeccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnComponenteInspeccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmComponenteInspeccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnParametroEntidadClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmParametroEntidad)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnOrdenTrabajoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmOrdenTrabajo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnPlanMantenimientoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmPlanMantenimiento)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptHistoricoOrdenTrabajoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptHistoricoOrdenTrabajo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptAlertaCambiosClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptAlertaCambios)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptEstadisticaTrabajoManttoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptTrabajoMantto)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnInspeccionPreOrdenTrabajoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmInspeccionPreOrdenTrabajo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptOTXMesXSemanaXAnioClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaOTXMesXSemanaXAnio)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRegistroMaquinaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRegistroMaquina)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnArbolEntidadClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmArbolEntidad)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnVisionLinkClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmVisionLink)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRegistroEquipoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRegistroEquipo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnReporteRegistroEquipoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptRegistroEquipo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnPlantillaDocuIsoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmPlantillaDocuIso)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnDocuIsoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmDocuIso)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnFotoPersonaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmFotoPersona)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnVisualizarISOClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmVisualizarISO)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnFichaInspeccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmFichaInspeccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnReporteFichaInspeccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptFichaInspeccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
    End Class
End Namespace

