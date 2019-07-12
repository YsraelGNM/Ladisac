Imports Microsoft.Practices.Unity
Imports System.Windows.Forms
Imports Ladisac.Foundation

Namespace Ladisac.Produccion
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
            CabMenu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K") Select mPU).Count
            If CabMenu > 0 Then RegistrarMenus()
        End Sub

        Public Sub RegistrarMenus()
            Dim mProduccion As New ToolStripMenuItem("Produccion")
            mProduccion.Name = "Produccion"
            AddHandler mProduccion.Click, AddressOf OnProduccionClick
            ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(mProduccion)
            'Me.MenuService.RegistrarMenu(Constants.MenuNames.Produccion, menuItem)
            'Me.MenuService.RegistrarMenu(Constants.MenuNames.Produccion, menuItem2)
        End Sub

        Private Sub OnProduccionClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            Dim mToolStrip(53) As ToolStripItem '43

            Dim menuItem As New ToolStripButton("Paradas")
            AddHandler menuItem.Click, AddressOf OnParadasClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K01") Select mPU).Count
            If Menu > 0 Then mToolStrip(0) = menuItem

            Dim menuItem2 As New ToolStripButton("Tipo Parada")
            AddHandler menuItem2.Click, AddressOf OnTipoParadaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K02") Select mPU).Count
            If Menu > 0 Then mToolStrip(1) = menuItem2

            Dim menuItem3 As New ToolStripButton("Secaderos")
            AddHandler menuItem3.Click, AddressOf OnSecaderoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K03") Select mPU).Count
            If Menu > 0 Then mToolStrip(2) = menuItem3

            Dim menuItem4 As New ToolStripButton("Cortadoras")
            AddHandler menuItem4.Click, AddressOf OnCortadoraClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K04") Select mPU).Count
            If Menu > 0 Then mToolStrip(3) = menuItem4

            Dim menuItem5 As New ToolStripButton("Canchas")
            AddHandler menuItem5.Click, AddressOf OnCanchaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K05") Select mPU).Count
            If Menu > 0 Then mToolStrip(4) = menuItem5

            Dim menuItem6 As New ToolStripButton("Tipo Produccion")
            AddHandler menuItem6.Click, AddressOf OnTipoProduccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K06") Select mPU).Count
            If Menu > 0 Then mToolStrip(5) = menuItem6

            Dim menuItem7 As New ToolStripButton("Planta")
            AddHandler menuItem7.Click, AddressOf OnPlantaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K07") Select mPU).Count
            If Menu > 0 Then mToolStrip(6) = menuItem7

            Dim menuItem8 As New ToolStripButton("Produccion")
            AddHandler menuItem8.Click, AddressOf OnProduccion1Click
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K08") Select mPU).Count
            If Menu > 0 Then mToolStrip(7) = menuItem8

            Dim menuItem9 As New ToolStripButton("Control Conteo")
            AddHandler menuItem9.Click, AddressOf OnControlConteoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K09") Select mPU).Count
            If Menu > 0 Then mToolStrip(8) = menuItem9

            Dim menuItem10 As New ToolStripButton("Control Parada")
            AddHandler menuItem10.Click, AddressOf OnControlParadaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K10") Select mPU).Count
            If Menu > 0 Then mToolStrip(9) = menuItem10

            Dim menuItem11 As New ToolStripButton("Control Canchero")
            AddHandler menuItem11.Click, AddressOf OnControlCancheroClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K11") Select mPU).Count
            If Menu > 0 Then mToolStrip(10) = menuItem11

            Dim menuItem12 As New ToolStripButton("Control Peso")
            AddHandler menuItem12.Click, AddressOf OnControlPesoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K12") Select mPU).Count
            If Menu > 0 Then mToolStrip(11) = menuItem12

            Dim menuItem13 As New ToolStripButton("Control Extrusora")
            AddHandler menuItem13.Click, AddressOf OnControlExtrusoraClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K13") Select mPU).Count
            If Menu > 0 Then mToolStrip(12) = menuItem13

            Dim menuItem14 As New ToolStripButton("Salida Secadero")
            AddHandler menuItem14.Click, AddressOf OnSalidaSecaderoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K14") Select mPU).Count
            If Menu > 0 Then mToolStrip(13) = menuItem14

            Dim menuItem15 As New ToolStripButton("Control Mezcla")
            AddHandler menuItem15.Click, AddressOf OnControlMezclaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K15") Select mPU).Count
            If Menu > 0 Then mToolStrip(14) = menuItem15

            Dim menuItem16 As New ToolStripButton("Control Inspeccion")
            AddHandler menuItem16.Click, AddressOf OnControlInspeccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K16") Select mPU).Count
            If Menu > 0 Then mToolStrip(15) = menuItem16

            Dim menuItem17 As New ToolStripButton("Horno")
            AddHandler menuItem17.Click, AddressOf OnHornoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K17") Select mPU).Count
            If Menu > 0 Then mToolStrip(16) = menuItem17

            Dim menuItem18 As New ToolStripButton("Puerta Horno")
            AddHandler menuItem18.Click, AddressOf OnPuertaHornoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K18") Select mPU).Count
            If Menu > 0 Then mToolStrip(17) = menuItem18

            Dim menuItem19 As New ToolStripButton("Malecon Puerta")
            AddHandler menuItem19.Click, AddressOf OnMaleconPuertaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K19") Select mPU).Count
            If Menu > 0 Then mToolStrip(18) = menuItem19

            Dim menuItem20 As New ToolStripButton("Ladrillo Malecon")
            AddHandler menuItem20.Click, AddressOf OnLadrilloMaleconClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K20") Select mPU).Count
            If Menu > 0 Then mToolStrip(19) = menuItem20

            Dim menuItem21 As New ToolStripButton("Carga, Quema y Descarga Horno")
            AddHandler menuItem21.Click, AddressOf OnCaCoDeClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K21") Select mPU).Count
            If Menu > 0 Then mToolStrip(20) = menuItem21

            Dim menuItem22 As New ToolStripButton("Consumo Combustible")
            AddHandler menuItem22.Click, AddressOf OnConsumoCombustibleClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K22") Select mPU).Count
            If Menu > 0 Then mToolStrip(21) = menuItem22

            Dim menuItem23 As New ToolStripButton("Reporte Paradas por Dia")
            AddHandler menuItem23.Click, AddressOf OnControlParadasPorDiaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K23") Select mPU).Count
            If Menu > 0 Then mToolStrip(22) = menuItem23

            Dim menuItem24 As New ToolStripButton("Reporte Quema Ladrillo")
            AddHandler menuItem24.Click, AddressOf OnQuemaLadrilloClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K24") Select mPU).Count
            If Menu > 0 Then mToolStrip(23) = menuItem24

            Dim menuItem25 As New ToolStripButton("Control Descarga a Ruma")
            AddHandler menuItem25.Click, AddressOf OnControlDescargaRumaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K25") Select mPU).Count
            If Menu > 0 Then mToolStrip(24) = menuItem25

            Dim menuItem26 As New ToolStripButton("Reporte Descarga a Ruma")
            AddHandler menuItem26.Click, AddressOf OnDesHorXPuertaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K26") Select mPU).Count
            If Menu > 0 Then mToolStrip(25) = menuItem26

            Dim menuItem27 As New ToolStripButton("Ladrillo")
            AddHandler menuItem27.Click, AddressOf OnLadrilloClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K27") Select mPU).Count
            If Menu > 0 Then mToolStrip(26) = menuItem27

            Dim menuItem28 As New ToolStripButton("Extrusora")
            AddHandler menuItem28.Click, AddressOf OnExtrusoraClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K28") Select mPU).Count
            If Menu > 0 Then mToolStrip(27) = menuItem28

            Dim menuItem29 As New ToolStripButton("Reporte Consumo Combustible")
            AddHandler menuItem29.Click, AddressOf OnRptConsumoCombustibleClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K29") Select mPU).Count
            If Menu > 0 Then mToolStrip(28) = menuItem29

            Dim menuItem30 As New ToolStripButton("Reporte Proceso Terminado")
            AddHandler menuItem30.Click, AddressOf OnRptProcesoTerminadoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K30") Select mPU).Count
            If Menu > 0 Then mToolStrip(29) = menuItem30

            Dim menuItem31 As New ToolStripButton("Reporte Salida de Secadero")
            AddHandler menuItem31.Click, AddressOf OnRptSalidaSecaderoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K31") Select mPU).Count
            If Menu > 0 Then mToolStrip(30) = menuItem31

            Dim menuItem32 As New ToolStripButton("Reporte Peso para la Quema")
            AddHandler menuItem32.Click, AddressOf OnRptPesoQuemaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K32") Select mPU).Count
            If Menu > 0 Then mToolStrip(31) = menuItem32

            Dim menuItem33 As New ToolStripButton("Reporte Inspecciones")
            AddHandler menuItem33.Click, AddressOf OnRptInspeccionesClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K33") Select mPU).Count
            If Menu > 0 Then mToolStrip(32) = menuItem33

            Dim menuItem34 As New ToolStripButton("Reporte Pesos y Humedades Diarias")
            AddHandler menuItem34.Click, AddressOf OnRptPesosYHumedadesPorDiaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K34") Select mPU).Count
            If Menu > 0 Then mToolStrip(33) = menuItem34

            Dim menuItem35 As New ToolStripButton("Reporte Final Produccion")
            AddHandler menuItem35.Click, AddressOf OnRptReporteFinalProduccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K35") Select mPU).Count
            If Menu > 0 Then mToolStrip(34) = menuItem35

            Dim menuItem36 As New ToolStripButton("Reporte Factores Produccion")
            AddHandler menuItem36.Click, AddressOf OnRptFactoresProduccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K36") Select mPU).Count
            If Menu > 0 Then mToolStrip(35) = menuItem36

            Dim menuItem37 As New ToolStripButton("Reporte Consumo Combustible por Responsable")
            AddHandler menuItem37.Click, AddressOf OnRptConsumoCombustibleXResponsableClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K37") Select mPU).Count
            If Menu > 0 Then mToolStrip(36) = menuItem37

            Dim menuItem38 As New ToolStripButton("Control Energia")
            AddHandler menuItem38.Click, AddressOf OnControlEnergiaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K38") Select mPU).Count
            If Menu > 0 Then mToolStrip(37) = menuItem38

            Dim menuItem39 As New ToolStripButton("Regularizar Ladrillo")
            AddHandler menuItem39.Click, AddressOf OnRegularizarLadrilloClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K39") Select mPU).Count
            If Menu > 0 Then mToolStrip(38) = menuItem39

            Dim menuItem40 As New ToolStripButton("Reporte Reciclaje Venta Ladrillo")
            AddHandler menuItem40.Click, AddressOf OnRptListaReciclajeVentaLadrilloClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K40") Select mPU).Count
            If Menu > 0 Then mToolStrip(39) = menuItem40

            Dim menuItem41 As New ToolStripButton("Reporte Resumen Paradas")
            AddHandler menuItem41.Click, AddressOf OnResumenParadaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K41") Select mPU).Count
            If Menu > 0 Then mToolStrip(40) = menuItem41

            Dim menuItem42 As New ToolStripButton("Reporte Reciclaje Venta Ladrillo Despacho")
            AddHandler menuItem42.Click, AddressOf OnRptListaReciclajeVentaLadrilloDespachoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K42") Select mPU).Count
            If Menu > 0 Then mToolStrip(41) = menuItem42

            Dim menuItem43 As New ToolStripButton("Reporte Toneladas")
            AddHandler menuItem43.Click, AddressOf OnRptListaTnQuemadasClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K43") Select mPU).Count
            If Menu > 0 Then mToolStrip(42) = menuItem43

            Dim menuItem44 As New ToolStripButton("Reporte Cotejo Descarga Horno vs Despacho")
            AddHandler menuItem44.Click, AddressOf OnRptListaSalidaHornoVsDespachoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K44") Select mPU).Count
            If Menu > 0 Then mToolStrip(43) = menuItem44

            Dim menuItem45 As New ToolStripButton("Reporte de Distribucion de Combustible")
            AddHandler menuItem45.Click, AddressOf OnRptDistribucionCombustibleProduccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K45") Select mPU).Count
            If Menu > 0 Then mToolStrip(44) = menuItem45

            Dim menuItem46 As New ToolStripButton("Reporte Reciclaje Ladrillo por Mes por Año")
            AddHandler menuItem46.Click, AddressOf OnRptReciclajeVentaLadrillox12MesClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K46") Select mPU).Count
            If Menu > 0 Then mToolStrip(45) = menuItem46

            Dim menuItem47 As New ToolStripButton("Reporte de Distribucion de Energia")
            AddHandler menuItem47.Click, AddressOf OnRptDistribucionEnergiaProduccionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K47") Select mPU).Count
            If Menu > 0 Then mToolStrip(46) = menuItem47

            Dim menuItem48 As New ToolStripButton("Reporte Materia Prima")
            AddHandler menuItem48.Click, AddressOf OnReporteBrutoNetoMateriaPrimaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K48") Select mPU).Count
            If Menu > 0 Then mToolStrip(47) = menuItem48

            Dim menuItem49 As New ToolStripButton("Control Planta")
            AddHandler menuItem49.Click, AddressOf OnControlPlantaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K49") Select mPU).Count
            If Menu > 0 Then mToolStrip(48) = menuItem49

            Dim menuItem50 As New ToolStripButton("Reporte Reciclaje Despacho Ladrillo")
            AddHandler menuItem50.Click, AddressOf OnRptListaReciclajeDespachoLadrilloClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K50") Select mPU).Count
            If Menu > 0 Then mToolStrip(49) = menuItem50

            Dim menuItem51 As New ToolStripButton("Reporte Contabilidad")
            AddHandler menuItem51.Click, AddressOf OnRptContabilidadClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K51") Select mPU).Count
            If Menu > 0 Then mToolStrip(50) = menuItem51

            Dim menuItem52 As New ToolStripButton("Reporte Salida Horno por Año")
            AddHandler menuItem52.Click, AddressOf OnRptReporteSalidaHornoXAnioClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K52") Select mPU).Count
            If Menu > 0 Then mToolStrip(51) = menuItem52

            Dim menuItem53 As New ToolStripButton("Planificacion")
            AddHandler menuItem53.Click, AddressOf OnPlanCargaDescargaHornoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K53") Select mPU).Count
            If Menu > 0 Then mToolStrip(52) = menuItem53

            Dim menuItem54 As New ToolStripButton("Control Paqueteo")
            AddHandler menuItem54.Click, AddressOf OnControlPaqueteoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("K54") Select mPU).Count
            If Menu > 0 Then mToolStrip(53) = menuItem54

            'ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(New ToolStripItem() {menuItem, menuItem2, menuItem3, menuItem4, menuItem5, menuItem6, menuItem7, menuItem8, menuItem9, menuItem10, menuItem11, menuItem12, menuItem13, menuItem14, menuItem15, menuItem16, menuItem17, menuItem18, menuItem19, menuItem20, menuItem21, menuItem22, menuItem23, menuItem24, menuItem25, menuItem26, menuItem27, menuItem28, menuItem29, menuItem30, menuItem31, menuItem32, menuItem33, menuItem34, menuItem35, menuItem36, menuItem37})
            Dim mToolStrip2(CabMenu - 1) As ToolStripItem '38
            Dim mCont2 As Integer = 0
            For mCont As Integer = 0 To mToolStrip.Count - 1
                If mToolStrip(mCont) IsNot Nothing Then
                    mToolStrip2(mCont2) = mToolStrip(mCont)
                    mCont2 += 1
                End If
            Next
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
        End Sub

        Private Sub OnParadasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmParadas)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnTipoParadaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmTipoParada)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnSecaderoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmSecadero)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnCortadoraClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmCortadora)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnCanchaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmCancha)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnTipoProduccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmTipoProduccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnPlantaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmPlanta)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnProduccion1Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmProduccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlConteoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmControlConteo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlParadaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmControlParada)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlCancheroClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmControlCanchero)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlPesoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmControlPeso)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlExtrusoraClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmControlExtrusora)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnSalidaSecaderoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmSalidaSecadero)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlMezclaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmControlMezcla)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlInspeccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmControlInspeccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnHornoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmHorno)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnPuertaHornoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmPuertaHorno)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnMaleconPuertaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmMaleconPuerta)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnLadrilloMaleconClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmLadrilloMalecon)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnCaCoDeClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmCaCoDe)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnConsumoCombustibleClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmConsumoCombustible)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlParadasPorDiaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptControlParadasPorDia)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnQuemaLadrilloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptQuemaLadrillo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlDescargaRumaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmControlDescargaRuma)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnDesHorXPuertaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptDesHorXPuerta)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnLadrilloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmLadrillo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnExtrusoraClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmExtrusora)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptConsumoCombustibleClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptConsumoCombustible)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptProcesoTerminadoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptProcesoTerminado)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptSalidaSecaderoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptSalidaSecadero)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptPesoQuemaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptPesoQuema)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptInspeccionesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptInspecciones)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptPesosYHumedadesPorDiaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaPesosYHumedadesPorDia)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptReporteFinalProduccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptReporteFinalProduccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptFactoresProduccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptFactoresProduccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptConsumoCombustibleXResponsableClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptConsumoCombustibleXResponsable)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlEnergiaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmControlEnergia)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRegularizarLadrilloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRegularizarLadrillo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListaReciclajeVentaLadrilloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaReciclajeVentaLadrillo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnResumenParadaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmResumenParada)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListaReciclajeVentaLadrilloDespachoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaReciclajeVentaLadrilloDespacho)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListaTnQuemadasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListatnQuemadas)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListaSalidaHornoVsDespachoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaSalidaHornoVsDespacho)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptDistribucionCombustibleProduccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptDistribucionCombustibleProduccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptReciclajeVentaLadrillox12MesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptReciclajeVentaLadrillox12Mes)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptDistribucionEnergiaProduccionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptDistribucionEnergiaProduccion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnReporteBrutoNetoMateriaPrimaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmReporteBrutoNetoMateriaPrima)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlPlantaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmControlPlanta)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListaReciclajeDespachoLadrilloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptReciclajeDespachoLadrillo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptContabilidadClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptContabilidad)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptReporteSalidaHornoXAnioClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptReporteSalidaHornoXAnio)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnPlanCargaDescargaHornoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmPlanCargaDescargaHorno)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnControlPaqueteoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmControlPaqueteo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
    End Class
End Namespace
