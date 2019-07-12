Imports Microsoft.Practices.Unity
Imports System.Windows.Forms

Namespace Ladisac.Foundation
    Public Class ModuleController

        <Dependency()> _
        Public Property EventAggregator As Microsoft.Practices.Prism.Events.IEventAggregator
        <Dependency()> _
        Public Property ContainerService As Microsoft.Practices.Unity.IUnityContainer
        <Dependency()> _
        Public Property MenuService As Ladisac.Foundation.Services.IMenuService
        <Dependency()> _
        Public Property SessionServer As Foundation.Services.ISessionService

        Public Tempo As New System.Windows.Forms.Timer()
        Dim CabMenu As Integer = 0
        Dim Menu As Integer = 0


        Public Sub run()
            RegistrarEventos()
            RegistrarMenus()

            Dim frm = Me.ContainerService.Resolve(Of frmLogin)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Public Sub RegistrarMenus()

            Dim menu As New ToolStripMenuItem("Soporte")
            AddHandler menu.Click, AddressOf OnSolicitudSoporteClick
            'Me.MenuService.RegistrarMenu(Constants.MenuNames.Mantenimiento, menu)
            Me.ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(menu)

            Dim menuCD As New ToolStripMenuItem("Control Documentario")
            AddHandler menuCD.Click, AddressOf OnControlDocumentarioClick
            'Me.MenuService.RegistrarMenu(Constants.MenuNames.Mantenimiento, menu)
            Me.ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(menuCD)

        End Sub

        Public Sub RegistrarEventos()
            Dim evento = EventAggregator.GetEvent(Of Ladisac.Foundation.GlobalEvents.LoginEvent)()
            evento.Subscribe(AddressOf Onlogin)
        End Sub

        Public Sub OnMonedasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Views.frmMonedas)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Public Sub OnSolicitudSoporteClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmSolicitudSoporte)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Public Sub Onlogin(ByVal param As String)
            RegistrarNotification()
        End Sub

        Public Sub RegistrarNotification()
            Tempo.Interval = 600000
            AddHandler Tempo.Tick, AddressOf OnNotification
            'Tempo.Start()
        End Sub

        Public Sub OnNotification()
            Me.ContainerService.Resolve(Of MainWindow).tssMensajeGeneral.Text = DateTime.Now.ToLongTimeString()
            'Dim frm = Me.ContainerService.Resolve(Of Views.frmMonedas)()
            'frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            'frm.Show()
        End Sub


        Private Sub OnControlDocumentarioClick(ByVal sender As Object, ByVal e As EventArgs)
            CabMenu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("P") Select mPU).Count

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            Dim mToolStrip(4) As ToolStripItem '36

            Dim menuItem As New ToolStripButton("Plantilla Documento ISO")
            AddHandler menuItem.Click, AddressOf OnPlantillaDocuIsoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("P1") Select mPU).Count
            If Menu > 0 Then mToolStrip(0) = menuItem

            Dim menuItem2 As New ToolStripButton("Documento ISO")
            AddHandler menuItem2.Click, AddressOf OnDocuIsoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("P2") Select mPU).Count
            If Menu > 0 Then mToolStrip(1) = menuItem2

            Dim menuItem3 As New ToolStripButton("Firma ISO")
            AddHandler menuItem3.Click, AddressOf OnFotoPersonaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("P3") Select mPU).Count
            If Menu > 0 Then mToolStrip(2) = menuItem3

            Dim menuItem4 As New ToolStripButton("Listado Documentos ISO")
            AddHandler menuItem4.Click, AddressOf OnVisualizarISOClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("P4") Select mPU).Count
            If Menu > 0 Then mToolStrip(3) = menuItem4


            'ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New ToolStripItem() {menuItem, menuItem2, menuItem3, menuItem4, menuItem5, menuItem6, menuItem7, menuItem8, menuItem9, menuItem10, menuItem12, menuItem13, menuItem14, menuItem15, menuItem16, menuItem17, menuItem18, menuItem19, menuItem20, menuItem21, menuItem22, menuItem23, menuItem24, menuItem25, menuItem26, menuItem27, menuItem28, menuItem29, menuItem30, menuItem31, menuItem32, menuItem33, menuItem34})
            Dim mToolStrip2(CabMenu - 1) As ToolStripItem '35
            Dim mCont2 As Integer = 0
            For mCont As Integer = 0 To mToolStrip.Count - 1
                If mToolStrip(mCont) IsNot Nothing Then
                    mToolStrip2(mCont2) = mToolStrip(mCont)
                    mCont2 += 1
                End If
            Next
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
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

    End Class
End Namespace

