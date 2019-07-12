Imports Microsoft.Practices.Unity
Imports System.Windows.Forms
Imports Ladisac.Foundation

Namespace Ladisac.Logistica

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
            CabMenu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H") Select mPU).Count
            If CabMenu > 0 Then RegistrarMenus()
        End Sub

        Public Sub RegistrarMenus()
            Dim mLogistica As New ToolStripMenuItem("Logistica")
            mLogistica.Name = "Logistica"
            AddHandler mLogistica.Click, AddressOf OnLogisticaClick
            ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(mLogistica)
        End Sub

        Private Sub OnLogisticaClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            Dim mToolStrip(51) As ToolStripItem '36

            Dim menuItem As New ToolStripButton("Almacen")
            AddHandler menuItem.Click, AddressOf OnAlmacenClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H01") Select mPU).Count
            If Menu > 0 Then mToolStrip(0) = menuItem

            Dim menuItem2 As New ToolStripButton("Articulo")
            AddHandler menuItem2.Click, AddressOf OnArticuloClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H02") Select mPU).Count
            If Menu > 0 Then mToolStrip(1) = menuItem2

            Dim menuItem3 As New ToolStripButton("Orden de Requerimiento")
            AddHandler menuItem3.Click, AddressOf OnOrdenRequerimientoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H03") Select mPU).Count
            If Menu > 0 Then mToolStrip(2) = menuItem3

            Dim menuItem4 As New ToolStripButton("Orden de Compra")
            AddHandler menuItem4.Click, AddressOf OnOrdenCompraClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H04") Select mPU).Count
            If Menu > 0 Then mToolStrip(3) = menuItem4

            Dim menuItem5 As New ToolStripButton("Salida de Combustible")
            AddHandler menuItem5.Click, AddressOf OnSalidaCombustibleClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H05") Select mPU).Count
            If Menu > 0 Then mToolStrip(4) = menuItem5

            Dim menuItem6 As New ToolStripButton("Documentacion")
            AddHandler menuItem6.Click, AddressOf OnDocuMovimientoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H06") Select mPU).Count
            If Menu > 0 Then mToolStrip(5) = menuItem6

            Dim menuItem7 As New ToolStripButton("Articulo Almacen")
            AddHandler menuItem7.Click, AddressOf OnArticuloAlmacenClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H07") Select mPU).Count
            If Menu > 0 Then mToolStrip(6) = menuItem7

            Dim menuItem8 As New ToolStripButton("Marca Articulo")
            AddHandler menuItem8.Click, AddressOf OnMarcaArticuloClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H08") Select mPU).Count
            If Menu > 0 Then mToolStrip(7) = menuItem8

            Dim menuItem9 As New ToolStripButton("Modelo Articulo")
            AddHandler menuItem9.Click, AddressOf OnModeloArticuloClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H09") Select mPU).Count
            If Menu > 0 Then mToolStrip(8) = menuItem9

            Dim menuItem10 As New ToolStripButton("Unidades de Medida")
            AddHandler menuItem10.Click, AddressOf OnUnidadMedidaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H10") Select mPU).Count
            If Menu > 0 Then mToolStrip(9) = menuItem10

            'Dim menuItem11 As New ToolStripButton("Tipo Articulo")
            'AddHandler menuItem11.Click, AddressOf OnTipoArticuloClick

            Dim menuItem12 As New ToolStripButton("Familia Articulo")
            AddHandler menuItem12.Click, AddressOf OnFamiliaArticuloClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H12") Select mPU).Count
            If Menu > 0 Then mToolStrip(10) = menuItem12

            Dim menuItem13 As New ToolStripButton("Linea de Familia")
            AddHandler menuItem13.Click, AddressOf OnLineaFamiliaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H13") Select mPU).Count
            If Menu > 0 Then mToolStrip(11) = menuItem13

            Dim menuItem14 As New ToolStripButton("Grupo Linea")
            AddHandler menuItem14.Click, AddressOf OnGrupoLineasClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H14") Select mPU).Count
            If Menu > 0 Then mToolStrip(12) = menuItem14

            Dim menuItem15 As New ToolStripButton("Orden Salida")
            AddHandler menuItem15.Click, AddressOf OnOrdenSalidaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H15") Select mPU).Count
            If Menu > 0 Then mToolStrip(13) = menuItem15

            Dim menuItem16 As New ToolStripButton("Dotacion")
            AddHandler menuItem16.Click, AddressOf OnDotacionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H16") Select mPU).Count
            If Menu > 0 Then mToolStrip(14) = menuItem16

            Dim menuItem17 As New ToolStripButton("Reporte Kardex")
            AddHandler menuItem17.Click, AddressOf OnRptKardexClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H17") Select mPU).Count
            If Menu > 0 Then mToolStrip(15) = menuItem17

            Dim menuItem18 As New ToolStripButton("Reporte Consumo por Entidad")
            AddHandler menuItem18.Click, AddressOf OnRptConsumoEntidadClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H18") Select mPU).Count
            If Menu > 0 Then mToolStrip(16) = menuItem18

            Dim menuItem19 As New ToolStripButton("Reporte Consumo Combustible")
            AddHandler menuItem19.Click, AddressOf OnRptConsumoCombustibleClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H19") Select mPU).Count
            If Menu > 0 Then mToolStrip(17) = menuItem19

            Dim menuItem20 As New ToolStripButton("Reporte Stock Minimos")
            AddHandler menuItem20.Click, AddressOf OnRptStockMinimoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H20") Select mPU).Count
            If Menu > 0 Then mToolStrip(18) = menuItem20

            Dim menuItem21 As New ToolStripButton("Reporte Documentos por Operacion")
            AddHandler menuItem21.Click, AddressOf OnRptDocOperacionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H21") Select mPU).Count
            If Menu > 0 Then mToolStrip(19) = menuItem21

            Dim menuItem22 As New ToolStripButton("Reporte Listado Orden Requerimiento")
            AddHandler menuItem22.Click, AddressOf OnRptListadoOrdenRequerimientoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H22") Select mPU).Count
            If Menu > 0 Then mToolStrip(20) = menuItem22

            Dim menuItem23 As New ToolStripButton("Reporte Lista Saldo por Almacen")
            AddHandler menuItem23.Click, AddressOf OnRptListaSaldoXAlmacenClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H23") Select mPU).Count
            If Menu > 0 Then mToolStrip(21) = menuItem23

            Dim menuItem24 As New ToolStripButton("Ubicaciones para Almacen")
            AddHandler menuItem24.Click, AddressOf OnUbicacionAlmacenClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H24") Select mPU).Count
            If Menu > 0 Then mToolStrip(22) = menuItem24

            Dim menuItem25 As New ToolStripButton("Guia Remision")
            AddHandler menuItem25.Click, AddressOf OnGuiaRemisionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H25") Select mPU).Count
            If Menu > 0 Then mToolStrip(23) = menuItem25

            Dim menuItem26 As New ToolStripButton("Proceso Compra")
            AddHandler menuItem26.Click, AddressOf OnProcesoCompraClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H26") Select mPU).Count
            If Menu > 0 Then mToolStrip(24) = menuItem26

            Dim menuItem27 As New ToolStripButton("Solicitud Compra")
            AddHandler menuItem27.Click, AddressOf OnSolicitudCompraClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H27") Select mPU).Count
            If Menu > 0 Then mToolStrip(25) = menuItem27

            Dim menuItem28 As New ToolStripButton("Transformacion")
            AddHandler menuItem28.Click, AddressOf OnTransformacionClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H28") Select mPU).Count
            If Menu > 0 Then mToolStrip(26) = menuItem28

            Dim menuItem29 As New ToolStripButton("Rendicion de Compras")
            AddHandler menuItem29.Click, AddressOf OnRendicionCuentaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H29") Select mPU).Count
            If Menu > 0 Then mToolStrip(27) = menuItem29

            Dim menuItem30 As New ToolStripButton("Reporte Ingreso por Proveedor")
            AddHandler menuItem30.Click, AddressOf OnListadoIngresoXProveedorClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H30") Select mPU).Count
            If Menu > 0 Then mToolStrip(28) = menuItem30

            Dim menuItem31 As New ToolStripButton("Reporte Guias Facturadas")
            AddHandler menuItem31.Click, AddressOf OnListasGuiasFacturadasClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H31") Select mPU).Count
            If Menu > 0 Then mToolStrip(29) = menuItem31

            Dim menuItem32 As New ToolStripButton("Reporte Kardex Consolidado")
            AddHandler menuItem32.Click, AddressOf OnKardexConsolidadoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H32") Select mPU).Count
            If Menu > 0 Then mToolStrip(30) = menuItem32

            Dim menuItem33 As New ToolStripButton("Reporte Kardex Contable")
            AddHandler menuItem33.Click, AddressOf OnKardexContabilidadClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H33") Select mPU).Count
            If Menu > 0 Then mToolStrip(31) = menuItem33

            Dim menuItem34 As New ToolStripButton("Reporte Liquidacion Materia Prima")
            AddHandler menuItem34.Click, AddressOf OnLiquidacionMateriaPrimaClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H34") Select mPU).Count
            If Menu > 0 Then mToolStrip(32) = menuItem34

            Dim menuItem35 As New ToolStripButton("Reporte de Tickets")
            AddHandler menuItem35.Click, AddressOf OnReporteTicketsClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H35") Select mPU).Count
            If Menu > 0 Then mToolStrip(33) = menuItem35

            Dim menuItem36 As New ToolStripButton("Inventario")
            AddHandler menuItem36.Click, AddressOf OnInventarioClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H36") Select mPU).Count
            If Menu > 0 Then mToolStrip(34) = menuItem36

            'OnSaldoAlmaReparableSuministroClick
            Dim menuItem37 As New ToolStripButton("Saldo Reparable y Suministro")
            AddHandler menuItem37.Click, AddressOf OnSaldoAlmaReparableSuministroClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H37") Select mPU).Count
            If Menu > 0 Then mToolStrip(35) = menuItem37

            Dim menuItem38 As New ToolStripButton("Proveedores")
            AddHandler menuItem38.Click, AddressOf OnProveedoresClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H38") Select mPU).Count
            If Menu > 0 Then mToolStrip(36) = menuItem38

            Dim menuItem39 As New ToolStripButton("Cuadro Comparativo")
            AddHandler menuItem39.Click, AddressOf OnCuadroComparativoClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H39") Select mPU).Count
            If Menu > 0 Then mToolStrip(37) = menuItem39

            Dim menuItem40 As New ToolStripButton("Reporte Kardex por Lote")
            AddHandler menuItem40.Click, AddressOf OnRptKardexLoteClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H40") Select mPU).Count
            If Menu > 0 Then mToolStrip(38) = menuItem40

            Dim menuItem41 As New ToolStripButton("Reporte Kardex Ladrillo")
            AddHandler menuItem41.Click, AddressOf OnRptKardexLadrillo
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H41") Select mPU).Count
            If Menu > 0 Then mToolStrip(39) = menuItem41

            Dim menuItem42 As New ToolStripButton("Reporte Ultimo Ingreso Ultima Salida")
            AddHandler menuItem42.Click, AddressOf OnRptReporteAnticuamiento
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H42") Select mPU).Count
            If Menu > 0 Then mToolStrip(40) = menuItem42

            Dim menuItem43 As New ToolStripButton("Reporte Tiempo Atencion Orden Requerimiento")
            AddHandler menuItem43.Click, AddressOf OnRptListaTiempoAtencionOR
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H43") Select mPU).Count
            If Menu > 0 Then mToolStrip(41) = menuItem43

            Dim menuItem44 As New ToolStripButton("Reporte Programacion Pago Proveedor")
            AddHandler menuItem44.Click, AddressOf OnRptListaProgramacionPagoProveedor
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H44") Select mPU).Count
            If Menu > 0 Then mToolStrip(42) = menuItem44

            Dim menuItem45 As New ToolStripButton("Autorizar OR, OC y OS")
            AddHandler menuItem45.Click, AddressOf OnAutorizaciones
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H45") Select mPU).Count
            If Menu > 0 Then mToolStrip(43) = menuItem45

            Dim menuItem46 As New ToolStripButton("Orden de Servicio")
            AddHandler menuItem46.Click, AddressOf OnOrdenServicioClick
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H46") Select mPU).Count
            If Menu > 0 Then mToolStrip(44) = menuItem46

            Dim menuItem47 As New ToolStripButton("Reporte Seguimiento Autorizaciones")
            AddHandler menuItem47.Click, AddressOf OnRptListaSeguimientoAutorizacion
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H47") Select mPU).Count
            If Menu > 0 Then mToolStrip(45) = menuItem47

            Dim menuItem48 As New ToolStripButton("Reporte Orden Salida")
            AddHandler menuItem48.Click, AddressOf OnRptReporteOrdenSalida
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H48") Select mPU).Count
            If Menu > 0 Then mToolStrip(46) = menuItem48

            Dim menuItem49 As New ToolStripButton("Cierre Almacen")
            AddHandler menuItem49.Click, AddressOf OnCierreAlmacen
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H49") Select mPU).Count
            If Menu > 0 Then mToolStrip(47) = menuItem49

            Dim menuItem50 As New ToolStripButton("Recepcion Documento")
            AddHandler menuItem50.Click, AddressOf OnRecepcionDocumento
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H50") Select mPU).Count
            If Menu > 0 Then mToolStrip(48) = menuItem50

            Dim menuItem51 As New ToolStripButton("Orden Compra Aux")
            AddHandler menuItem51.Click, AddressOf OnOrdenCompraAux
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H51") Select mPU).Count
            If Menu > 0 Then mToolStrip(49) = menuItem51

            Dim menuItem52 As New ToolStripButton("Planilla Movilidad")
            AddHandler menuItem52.Click, AddressOf OnRendicionGastos
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H52") Select mPU).Count
            If Menu > 0 Then mToolStrip(50) = menuItem52

            Dim menuItem53 As New ToolStripButton("Cuentas a Rendir")
            AddHandler menuItem53.Click, AddressOf OnCuentaRendir
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("H53") Select mPU).Count
            If Menu > 0 Then mToolStrip(51) = menuItem53

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

        Private Sub OnAlmacenClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmAlmacen)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnArticuloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmArticulo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnOrdenRequerimientoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenRequerimiento)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnOrdenCompraClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenCompra)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnSalidaCombustibleClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmSalidaCombustible)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnDocuMovimientoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmDocuMovimiento)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnArticuloAlmacenClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmArticuloAlmacen)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnMarcaArticuloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmMarcaArticulo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnModeloArticuloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmModeloArticulo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnUnidadMedidaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmUnidadMedida)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnTipoArticuloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmTipoArticulo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnFamiliaArticuloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmFamiliaArticulo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnLineaFamiliaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmLineaFamilia)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnGrupoLineasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmGrupoLineas)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnOrdenSalidaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmOrdenSalida)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnDotacionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmDotacion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptKardexClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmRptKardex)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptConsumoEntidadClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptConsumoEntidad)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptConsumoCombustibleClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptConsumoCombustible)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptStockMinimoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptStockMinimo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptDocOperacionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptDocOperacion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListadoOrdenRequerimientoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListadoOrdenRequerimiento)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListaSaldoXAlmacenClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmRptListaSaldoXAlmacen)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnUbicacionAlmacenClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmUbicacionAlmacen)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnGuiaRemisionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmGuiaRemision)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnProcesoCompraClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmProcesoCompra)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnSolicitudCompraClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmSolicitudCompra)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnTransformacionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmTransformacion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRendicionCuentaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRendicionCuenta)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnListadoIngresoXProveedorClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListadoIngresoxProveedor)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnListasGuiasFacturadasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListasGuiasFacturadas)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnKardexConsolidadoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptKardexConsolidado)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnKardexContabilidadClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptKardexContabilidad)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnLiquidacionMateriaPrimaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaLiquidacionMateriaPrima)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnReporteTicketsClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptReporteTickets)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnInventarioClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmInventario)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnSaldoAlmaReparableSuministroClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptSaldoAlmaReparableSuministro)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnProveedoresClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmProveedores)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnCuadroComparativoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmCuadroComparativo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptKardexLoteClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptKardexLote)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptKardexLadrillo(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaKardexLadrillo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptReporteAnticuamiento(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptReporteAnticuamiento)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListaTiempoAtencionOR(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaTiempoAtencionOR)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListaProgramacionPagoProveedor(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaProgramacionPagoProveedor)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnAutorizaciones(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmAutorizaciones)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnOrdenServicioClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenServicio)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptListaSeguimientoAutorizacion(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptListaSeguimientoAutorizacion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRptReporteOrdenSalida(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRptReporteOrdenSalida)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnCierreAlmacen(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmCierreAlmacen)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRecepcionDocumento(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRecepcionDocumento)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnOrdenCompraAux(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmOrdenCompraAux)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnRendicionGastos(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmRendicionGastos)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub OnCuentaRendir(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of frmCuentaRendir)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
    End Class
End Namespace

