
Imports Microsoft.Practices.Unity
Imports System.Windows.Forms
Imports Ladisac.Foundation
Imports System.Data
Imports System.IO

Namespace Ladisac.Contabilidad
    Public Class ModuleController
        <Dependency()> _
        Public Property EventAggregator As Microsoft.Practices.Prism.Events.IEventAggregator
        <Dependency()> _
        Public Property ContainerService As Microsoft.Practices.Unity.IUnityContainer
        <Dependency()> _
        Public Property MenuServer As Foundation.Services.IMenuService
        <Dependency()> _
        Public Property SessionServer As Foundation.Services.ISessionService

        Dim CabMenu As Integer = 0
        Dim Menu As Integer = 0
        Sub rum()
            RegistrarEventos()
        End Sub

        Public Sub RegistrarEventos()
            Dim login = Me.EventAggregator.GetEvent(Of GlobalEvents.LoginEvent)()
            login.Subscribe(AddressOf onlogin)
        End Sub
        Private Sub onlogin(ByVal user As String)

            CabMenu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("I") Select mPU).Count
            If CabMenu > 0 Then RegistrarMenus()

        End Sub

        Public Sub RegistrarMenus()
            Dim mContabilidad As New ToolStripMenuItem("Contabilidad")
            mContabilidad.Name = "Contabilidad"
            AddHandler mContabilidad.Click, AddressOf onContabilidadGruposClick
            ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(mContabilidad)

        End Sub
        Public Function BuildBoton(ByVal id As String, ByVal text As String, ByVal Imagen As System.Drawing.Image) As ToolStripButton
            Dim tsb As New ToolStripButton
            tsb.AutoSize = False
            tsb.BackColor = System.Drawing.Color.Transparent
            tsb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            tsb.Font = New System.Drawing.Font("Tahoma", 6.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tsb.ImageTransparentColor = System.Drawing.Color.Transparent
            tsb.Margin = New System.Windows.Forms.Padding(0)
            tsb.Size = New System.Drawing.Size(73, 57)
            tsb.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            tsb.Name = id
            tsb.Text = text
            tsb.ToolTipText = " Datos de : " & text
            tsb.Image = Imagen
            Return tsb
        End Function

        Public Sub onContabilidadGruposClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            Dim onMenuConfiguracion = BuildBoton("", "Configuracion ", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuConfiguracion.Click, AddressOf onMenuConfiguracionClick
            onMenuConfiguracion.ImageAlign = ContentAlignment.TopCenter


            Dim onMenuTransacciones = BuildBoton("", "Transacciones", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuTransacciones.Click, AddressOf onMenuTransaccionesClick
            onMenuTransacciones.ImageAlign = ContentAlignment.TopCenter

            Dim onMenuProcesos = BuildBoton("", "Procesos ", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuProcesos.Click, AddressOf onMenuProcesosClick
            onMenuProcesos.ImageAlign = ContentAlignment.TopCenter

            Dim onMenuConsultas = BuildBoton("", "Consultas ", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuConsultas.Click, AddressOf onMenuConsultasClick
            onMenuConsultas.ImageAlign = ContentAlignment.TopCenter

            Dim onMenuReportes = BuildBoton("", "Reportes", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuReportes.Click, AddressOf onMenuReportesClick
            onMenuReportes.ImageAlign = ContentAlignment.TopCenter


            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I001") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = onMenuConfiguracion
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                  Where mPU.DPU_CADENA0.Contains("I002") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = onMenuTransacciones
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                              Where mPU.DPU_CADENA0.Contains("I003") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = onMenuProcesos
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                              Where mPU.DPU_CADENA0.Contains("I004") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = onMenuConsultas
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                              Where mPU.DPU_CADENA0.Contains("I005") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = onMenuReportes
                cuenta += 1
            End If
          

            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If


        End Sub

        Private Sub onMenuConfiguracionClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            Dim menuClaseCuenta As New ToolStripButton(Constants.MenuNames.ClaseCuenta)
            AddHandler menuClaseCuenta.Click, AddressOf onClaseCuentaClick

            Dim menuCuentasContables As New ToolStripButton(Constants.MenuNames.CuentasContabels)
            AddHandler menuCuentasContables.Click, AddressOf onCuentasContablesClick

            Dim menuLibrosContables As New ToolStripButton(Constants.MenuNames.LibrosContables)
            AddHandler menuLibrosContables.Click, AddressOf onLibrosContablesClick

            Dim menuTiposBienesServicios As New ToolStripButton(Constants.MenuNames.TiposBienesServicios)
            AddHandler menuTiposBienesServicios.Click, AddressOf onTiposBienesServiciosClick

            Dim menuCtaCte As New ToolStripButton(Constants.MenuNames.CtaCte)
            AddHandler menuCtaCte.Click, AddressOf onCtaCteClick

            Dim menuOperacionDetraciones As New ToolStripButton(Constants.MenuNames.OperacionDetraciones)
            AddHandler menuOperacionDetraciones.Click, AddressOf onOperacionDetracionesClick

            Dim menuCuentasArticulo As New ToolStripButton(Constants.MenuNames.CuentasArticulo)
            AddHandler menuCuentasArticulo.Click, AddressOf onCuentasArticuloClick

            Dim menuCuentasPlanillas As New ToolStripButton(Constants.MenuNames.CuentasPlanillas)
            AddHandler menuCuentasPlanillas.Click, AddressOf onCuentasPlanillasClick

            Dim menuPeriodo As New ToolStripButton(Constants.MenuNames.Periodo)
            AddHandler menuPeriodo.Click, AddressOf onPeriodoClick

            Dim nenuCuentasVarias As New ToolStripButton(Constants.MenuNames.CuentasVarias)
            AddHandler nenuCuentasVarias.Click, AddressOf onCuentasVariasClick

            'onConfiguracionFormatosClick
            Dim menuConfiguracionFormatos As New ToolStripButton(Constants.MenuNames.ConfiguracionFormatos)
            AddHandler menuConfiguracionFormatos.Click, AddressOf onConfiguracionFormatosClick

            'onCuentasComprobantesLogisticaClick

            Dim menuCuentasComprobantesLogistica As New ToolStripButton(Constants.MenuNames.CuentasComprobantesLogistica)
            AddHandler menuCuentasComprobantesLogistica.Click, AddressOf onCuentasComprobantesLogisticaClick


            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                  Where mPU.DPU_CADENA0.Contains("I006") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuClaseCuenta
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
               Where mPU.DPU_CADENA0.Contains("I007") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuCuentasContables
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                           Where mPU.DPU_CADENA0.Contains("I008") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuLibrosContables
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                           Where mPU.DPU_CADENA0.Contains("I009") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuTiposBienesServicios
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                           Where mPU.DPU_CADENA0.Contains("I010") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuCtaCte
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                           Where mPU.DPU_CADENA0.Contains("I011") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = menuOperacionDetraciones
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                           Where mPU.DPU_CADENA0.Contains("I012") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(7) = menuCuentasArticulo
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                           Where mPU.DPU_CADENA0.Contains("I013") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(8) = menuCuentasPlanillas
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                           Where mPU.DPU_CADENA0.Contains("I014") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(9) = menuPeriodo
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                           Where mPU.DPU_CADENA0.Contains("I015") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(10) = nenuCuentasVarias
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                          Where mPU.DPU_CADENA0.Contains("I016") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(11) = menuConfiguracionFormatos
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                          Where mPU.DPU_CADENA0.Contains("I017") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(12) = menuCuentasComprobantesLogistica
                cuenta += 1
            End If


            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If

        End Sub

        Private Sub onMenuTransaccionesClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            Dim nenuAsientosManuales As New ToolStripButton(Constants.MenuNames.AsientosManuales)
            AddHandler nenuAsientosManuales.Click, AddressOf onAsientosManualesClick

            'onProvicionComprasClick
            Dim nenuProvisionCompras As New ToolStripButton(Constants.MenuNames.ProvisionCompras)
            AddHandler nenuProvisionCompras.Click, AddressOf onProvisionComprasClick


            'onComprobantesClick
            Dim menuComprobantes As New ToolStripButton(Constants.MenuNames.Comprobantes)
            AddHandler menuComprobantes.Click, AddressOf onComprobantesClick

            'onComprobantesClick
            Dim menuComprobantes43 As New ToolStripButton(Constants.MenuNames.Comprobantes43)
            AddHandler menuComprobantes43.Click, AddressOf onComprobantes43Click

            'ComprobantesRenta4ta
            Dim menuComprobantesRenta4ta As New ToolStripButton(Constants.MenuNames.ComprobantesRenta4ta)
            AddHandler menuComprobantesRenta4ta.Click, AddressOf onComprobantesRenta4taClick

            'onLeasingClick
            Dim menuLeasing As New ToolStripButton(Constants.MenuNames.Leasing)
            AddHandler menuLeasing.Click, AddressOf onLeasingClick

            'onComprobantesRentaIGVClieneteClick
            Dim menuComprobantesRentaIGVCliente As New ToolStripButton(Constants.MenuNames.ComprobantesRetencionCliente)
            AddHandler menuComprobantesRentaIGVCliente.Click, AddressOf onComprobantesRentaIGVClienteClick

            'onComprobantesPercepcionIGVClienteClick
            Dim menuComprobantesPercepcionIGVCliente As New ToolStripButton(Constants.MenuNames.ComprobantesPercepcionIGVCliente)
            AddHandler menuComprobantesPercepcionIGVCliente.Click, AddressOf onComprobantesPercepcionIGVClienteClick

            'onComprobantesRetencionIndependHonorariosClick
            Dim menuComprobantesRetencionIndependHonorarios As New ToolStripButton(Constants.MenuNames.ComprobantesRetencionIndependHonorarios)
            AddHandler menuComprobantesRetencionIndependHonorarios.Click, AddressOf onComprobantesRetencionIndependHonorariosClick

            'onDocumentosGuiasClick
            Dim menuDocumentoGuias As New ToolStripButton("Documento de Guias")
            AddHandler menuDocumentoGuias.Click, AddressOf onDocumentoGuiasClick

            'onProvicionComprasServiciosClick
            Dim menuProvisionComprasServicios As New ToolStripButton(Constants.MenuNames.ProvisionComprasServicios)
            AddHandler menuProvisionComprasServicios.Click, AddressOf onProvisionComprasServiciosClick


            'onProvicionComprasServiciosClick
            Dim menuProvisionPlanillasMovilidad As New ToolStripButton(Constants.MenuNames.ProvisionPlanillasMovilidad)
            AddHandler menuProvisionPlanillasMovilidad.Click, AddressOf onProvisionPlanillasMovilidadClick

            'onProvicionComprasServiciosClick
            Dim menuProvisionRendicionEntregas As New ToolStripButton(Constants.MenuNames.ProvisionRendicionEntregas)
            AddHandler menuProvisionRendicionEntregas.Click, AddressOf onProvisionRendicionEntregasClick

            'onProvicionDividendosClick
            Dim menuProvisionDividendos As New ToolStripButton(Constants.MenuNames.ProvisionDividendos)
            AddHandler menuProvisionDividendos.Click, AddressOf onProvisionDividendosClick

            Dim mToolStrip(35) As ToolStripItem
            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I018") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = nenuAsientosManuales
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I019") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = nenuProvisionCompras
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I020") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuComprobantes
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I071") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(12) = menuComprobantes43
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I021") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuComprobantesRenta4ta
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I022") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuLeasing
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I023") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = menuComprobantesRentaIGVCliente
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                  Where mPU.DPU_CADENA0.Contains("I047") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(7) = menuComprobantesPercepcionIGVCliente
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                 Where mPU.DPU_CADENA0.Contains("I053") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(8) = menuComprobantesRetencionIndependHonorarios
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                Where mPU.DPU_CADENA0.Contains("I054") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(9) = menuDocumentoGuias
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                Where mPU.DPU_CADENA0.Contains("I067") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(10) = menuProvisionComprasServicios
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                Where mPU.DPU_CADENA0.Contains("I069") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(11) = menuProvisionDividendos
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                Where mPU.DPU_CADENA0.Contains("I072") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(13) = menuProvisionPlanillasMovilidad
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                Where mPU.DPU_CADENA0.Contains("I073") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(14) = menuProvisionRendicionEntregas
                cuenta += 1
            End If

            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next

                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If




        End Sub
        Private Sub onMenuProcesosClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            'onAsientoAutomaticoClick
            Dim nenuAsientoAutomatico As New ToolStripButton(Constants.MenuNames.AsientoAutomatico)
            AddHandler nenuAsientoAutomatico.Click, AddressOf onAsientoAutomaticoClick


            'onExportarSunatPLEClick
            Dim menuExportarSunatPLE As New ToolStripButton(Constants.MenuNames.ExportarSunatPLE)
            AddHandler menuExportarSunatPLE.Click, AddressOf onExportarSunatPLEClick

            'onExportarSunatPDT697Click
            Dim menuExportarSunatPDT697 As New ToolStripButton(Constants.MenuNames.ExportarSunatPDT697)
            AddHandler menuExportarSunatPDT697.Click, AddressOf onExportarSunatPDT697Click

            'onExportarSunatPDT626Click
            Dim menuExportarSunatPDT626 As New ToolStripButton(Constants.MenuNames.ExportarSunatPDT626)
            AddHandler menuExportarSunatPDT626.Click, AddressOf onExportarSunatPDT626Click


            'onResumenComprobantesRetencionClick
            Dim menuResumenComprobantesRetencion As New ToolStripButton(Constants.MenuNames.ResumenComprobantesRetencion)
            AddHandler menuResumenComprobantesRetencion.Click, AddressOf onResumenComprobantesRetencionClick


            Dim menuLibroInventarioBalance As New ToolStripButton(Constants.MenuNames.LibroInventarioBalance)
            AddHandler menuLibroInventarioBalance.Click, AddressOf onLibroInventarioBalanceClick

            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0


            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I024") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = nenuAsientoAutomatico
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I025") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuExportarSunatPLE
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                  Where mPU.DPU_CADENA0.Contains("I046") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuExportarSunatPDT697
                cuenta += 1
            End If

            'menuExportarSunatPDT626
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                 Where mPU.DPU_CADENA0.Contains("I048") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuExportarSunatPDT626
                cuenta += 1
            End If

            'menuResumenComprobantesRetencion
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                 Where mPU.DPU_CADENA0.Contains("I068") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuResumenComprobantesRetencion
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                Where mPU.DPU_CADENA0.Contains("I070") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = menuLibroInventarioBalance
                cuenta += 1
            End If

            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next
                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If

        End Sub

        Private Sub onMenuConsultasClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            'onHojaDeTrabajoClick
            Dim nenuHojaDeTrabajo As New ToolStripButton(Constants.MenuNames.HojaDeTrabajo)
            AddHandler nenuHojaDeTrabajo.Click, AddressOf onHojaDeTrabajoClick

            'onConsultaAsientoContableClick
            Dim nenuConsultaAsientoContable As New ToolStripButton(Constants.MenuNames.ConsultaAsientoContable)
            AddHandler nenuConsultaAsientoContable.Click, AddressOf onConsultaAsientoContableClick



            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0


            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I026") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = nenuHojaDeTrabajo
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I027") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = nenuConsultaAsientoContable
                cuenta += 1
            End If

            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If



        End Sub

        Private Sub onMenuReportesClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            ' onMenuReportesRegistrosClick()
            Dim onMenuReportesRegistros = BuildBoton("", "Registro" + Chr(13) + "Vent. Comp.", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuReportesRegistros.Click, AddressOf onMenuReportesRegistrosClick
            onMenuReportesRegistros.ImageAlign = ContentAlignment.TopCenter

            'onMenuReportesFormatosClick()
            Dim onMenuReportesFormatos = BuildBoton("", "Formatos " + Chr(13) + " Libros", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuReportesFormatos.Click, AddressOf onMenuReportesFormatosClick
            onMenuReportesFormatos.ImageAlign = ContentAlignment.TopCenter

            'onMenuReportesComprobantesClick()
            Dim onMenuReportesComprobantes = BuildBoton("", "Comprobantes " + Chr(13) + "Contables", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuReportesComprobantes.Click, AddressOf onMenuReportesComprobantesClick
            onMenuReportesComprobantes.ImageAlign = ContentAlignment.TopCenter

            'onMenuReportesAnalisisProbelmasClick()
            Dim onMenuReportesAnalisisProblemas = BuildBoton("", "Analisis de" + Chr(13) + "Problemas", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuReportesAnalisisProblemas.Click, AddressOf onMenuReportesAnalisisProblemasClick
            onMenuReportesAnalisisProblemas.ImageAlign = ContentAlignment.TopCenter


            'onMenuReportesConsultaProveedoresClick()
            Dim onMenuReportesConsultaProveedores = BuildBoton("", "Consultas" + Chr(13) + "Proveedores", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuReportesConsultaProveedores.Click, AddressOf onMenuReportesConsultaProveedoresClick
            onMenuReportesConsultaProveedores.ImageAlign = ContentAlignment.TopCenter




            ' onMenuReportesLibrosContablesClick()
            Dim onMenuReportesLibrosContables = BuildBoton("", "Libros " + Chr(13) + "Contables", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuReportesLibrosContables.Click, AddressOf onMenuReportesLibrosContablesClick
            onMenuReportesLibrosContables.ImageAlign = ContentAlignment.TopCenter



            ' onMenuReportesLibrosContablesClick()
            Dim onMenuReportesAsientosContables = BuildBoton("", "Asientos " + Chr(13) + "Contables", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler onMenuReportesAsientosContables.Click, AddressOf onMenuReportesAsientosContablesClick
            onMenuReportesAsientosContables.ImageAlign = ContentAlignment.TopCenter


            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0


           
            mToolStrip(1) = onMenuReportesRegistros
            cuenta += 1
            mToolStrip(2) = onMenuReportesAnalisisProblemas
            cuenta += 1
            mToolStrip(3) = onMenuReportesComprobantes
            cuenta += 1
            mToolStrip(4) = onMenuReportesConsultaProveedores
            cuenta += 1
            mToolStrip(5) = onMenuReportesFormatos
            cuenta += 1
            mToolStrip(6) = onMenuReportesLibrosContables
            cuenta += 1
            mToolStrip(7) = onMenuReportesAsientosContables
            cuenta += 1



             If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If



        End Sub
        Private Sub onMenuReportesRegistrosClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            'onFormatoVenta14Click
            Dim menuRegistroVentas As New ToolStripButton(Constants.MenuNames.RegistroVentas)
            AddHandler menuRegistroVentas.Click, AddressOf onFormatoVenta14Click

            'onFormatoCompra81Click
            Dim menuRegistroCompra As New ToolStripButton(Constants.MenuNames.RegistroCompras)
            AddHandler menuRegistroCompra.Click, AddressOf onFormatoCompra81Click

            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                      Where mPU.DPU_CADENA0.Contains("I028") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuRegistroVentas
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I029") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuRegistroCompra
                cuenta += 1
            End If




            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If





        End Sub

        Private Sub onMenuReportesLibrosContablesClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True



            'frmReporteMayorAuxiliarMes         
            Dim menuReporteMayorAuxiliarMes As New ToolStripButton(Constants.MenuNames.ReporteMayorAuxiliarMes)
            AddHandler menuReporteMayorAuxiliarMes.Click, AddressOf onReporteMayorAuxiliarMesClick



            'LibroDiarioGeneral
            'onReportLibroDiarioGeneralClick

            Dim menuLibroDiarioGeneral As New ToolStripButton(Constants.MenuNames.LibroDiarioGeneral)
            AddHandler menuLibroDiarioGeneral.Click, AddressOf onReportLibroDiarioGeneralClick


            'Analisis Ctas Ctes
            Dim menuAnalisisCtasCtes As New ToolStripButton("Analisis Ctas Ctes.")
            AddHandler menuAnalisisCtasCtes.Click, AddressOf onRptAnalisisCtasCtesClick


            'Balance General
            Dim menuBalance As New ToolStripButton("Reporte Balance General")
            AddHandler menuBalance.Click, AddressOf onRptBalanceClick


            Dim mToolStrip(34) As ToolStripItem
            Dim cuenta As Integer = 0

            'menuReporteMayorAuxiliarMes
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                Where mPU.DPU_CADENA0.Contains("I051") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(21) = menuReporteMayorAuxiliarMes
                cuenta += 1
            End If


            'menuLibroDiarioGeneral
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
              Where mPU.DPU_CADENA0.Contains("I062") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(23) = menuLibroDiarioGeneral
                cuenta += 1
            End If

            'analisis ctas ctes
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
              Where mPU.DPU_CADENA0.Contains("I064") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(24) = menuAnalisisCtasCtes
                cuenta += 1
            End If

            'analisis ctas ctes
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
              Where mPU.DPU_CADENA0.Contains("I065") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(25) = menuBalance
                cuenta += 1
            End If

            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If




        End Sub

        Private Sub onMenuReportesAsientosContablesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosAsientosContables)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosAsientosContables
            frm.Text = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosAsientosContables
            frm.Show()
        End Sub

        Private Sub onMenuReportesConsultaProveedoresClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            Dim menuReportePagosProveedores As New ToolStripButton(Constants.MenuNames.PagosProveedores)
            AddHandler menuReportePagosProveedores.Click, AddressOf onReportePagosProveedoresClick


            'rtesCentroCostoClick
            Dim menuReportesCentroCosto As New ToolStripButton(Constants.MenuNames.ReportesCentroCosto)
            AddHandler menuReportesCentroCosto.Click, AddressOf onReportesCentroCostoClick

            'onReportDestinoComprasClick
            Dim menuReportDestinoCompras As New ToolStripButton(Constants.MenuNames.ReportDestinoCompras)
            AddHandler menuReportDestinoCompras.Click, AddressOf onReportDestinoComprasClick

            'onReporteCuentasProveedorClick
            Dim menuReporteCuentasProveedor As New ToolStripButton(Constants.MenuNames.SPSelectReportCuentasProveedor)
            AddHandler menuReporteCuentasProveedor.Click, AddressOf onReporteCuentasProveedorClick

            'onReportesDAOTClick
            Dim menuReportesDAOT As New ToolStripButton(Constants.MenuNames.ReportesDAOT)
            AddHandler menuReportesDAOT.Click, AddressOf onReportesDAOTClick


            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0


            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                     Where mPU.DPU_CADENA0.Contains("I045") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuReportePagosProveedores
                cuenta += 1
            End If

            'menuReportesCentroCosto
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                  Where mPU.DPU_CADENA0.Contains("I050") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuReportesCentroCosto
                cuenta += 1
            End If



           'menuReportDestinoCompras
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                Where mPU.DPU_CADENA0.Contains("I052") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuReportDestinoCompras
                cuenta += 1
            End If


            'menuReporteCuentasProveedor
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
              Where mPU.DPU_CADENA0.Contains("I062") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuReporteCuentasProveedor
                cuenta += 1
            End If

            'menuReportesDAOT  reporte 

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
            Where mPU.DPU_CADENA0.Contains("I063") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuReportesDAOT
                cuenta += 1
            End If


            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If



        End Sub

        Private Sub onMenuReportesAnalisisProblemasClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            'onAsientosConProblemasClick
            Dim menuAsientosConProblemas As New ToolStripButton(Constants.MenuNames.AsientosConProblemas)
            AddHandler menuAsientosConProblemas.Click, AddressOf onAsientosConProblemasClick

            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0


            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                     Where mPU.DPU_CADENA0.Contains("I030") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuAsientosConProblemas
                cuenta += 1
            End If

            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If

        End Sub

        Private Sub onMenuReportesComprobantesClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            'onComprobantesRenta4taReportesClick
            Dim menuComprobantesRenta4taReportes As New ToolStripButton(Constants.MenuNames.ComprobantesRenta4ta)
            AddHandler menuComprobantesRenta4taReportes.Click, AddressOf onComprobantesRenta4taReportesClick

            'onComprobantesReportesClick
            Dim menuComprobantesReportes As New ToolStripButton(Constants.MenuNames.Comprobantes)
            AddHandler menuComprobantesReportes.Click, AddressOf onComprobantesReportesClick

            'onComprobantesPercepcionReportesClick()
            Dim menuComprobantesPercepcionReportes As New ToolStripButton(Constants.MenuNames.ComprobantesPercepcionReportes)
            AddHandler menuComprobantesPercepcionReportes.Click, AddressOf onComprobantesPercepcionReportesClick

            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0




            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I031") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuComprobantesRenta4taReportes
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I032") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuComprobantesReportes
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                  Where mPU.DPU_CADENA0.Contains("I049") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(19) = menuComprobantesPercepcionReportes
                cuenta += 1
            End If


            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If


        End Sub

        Private Sub onMenuReportesFormatosClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            'onFormatoMayorGeneral61Click
            Dim menuFormatoMayorGeneral61 As New ToolStripButton(Constants.MenuNames.RegistroLibroMayor)
            AddHandler menuFormatoMayorGeneral61.Click, AddressOf onFormatoMayorGeneral61Click


            ' onFormatosTributos310Click()
            Dim menuFormatosTributos310 As New ToolStripButton(Constants.MenuNames.FormatosTributos310)
            AddHandler menuFormatosTributos310.Click, AddressOf onFormatosTributos310Click

            'onFormatoInventarioYBalance32Click
            Dim menuFormatoInventarioYBalance32 As New ToolStripButton(Constants.MenuNames.FormatoInventarioYBalance32)
            AddHandler menuFormatoInventarioYBalance32.Click, AddressOf onFormatoInventarioYBalance32Click

            'onFormatoSaldoClientes33Click
            Dim menuFormatoSaldoClientes33 As New ToolStripButton(Constants.MenuNames.FormatoSaldoClientes33)
            AddHandler menuFormatoSaldoClientes33.Click, AddressOf onFormatoSaldoClientes33Click

            'onFormatoCuentasXCobrarAccionistas34Click
            Dim menuFormatoCuentasXCobrarAccionistas34 As New ToolStripButton(Constants.MenuNames.FormatoCuentasXCobrar34)
            AddHandler menuFormatoCuentasXCobrarAccionistas34.Click, AddressOf onFormatoCuentasXCobrarAccionistas34Click

            'onFormatoCuentasXCobrarDiversas35Click
            Dim menuFormatoCuentasXCobrarDiversas35 As New ToolStripButton(Constants.MenuNames.FormatoCuentasXCobrarDiversas35)
            AddHandler menuFormatoCuentasXCobrarDiversas35.Click, AddressOf onFormatoCuentasXCobrarDiversas35Click

            'onFormatoCobranzaDudosa36Click
            Dim menuFormatoCobranzaDudosa36 As New ToolStripButton(Constants.MenuNames.FormatoCobranzaDudosa36)
            AddHandler menuFormatoCobranzaDudosa36.Click, AddressOf onFormatoCobranzaDudosa36Click


            'onFormatosRenumeracionXPagar311Click
            Dim menuFormatosRenumeracionXPagar311 As New ToolStripButton(Constants.MenuNames.FormatosRenumeracionXPagar311)
            AddHandler menuFormatosRenumeracionXPagar311.Click, AddressOf onFormatosRenumeracionXPagar311Click


            'onFormatosProveedores312Click
            Dim menuFormatosProveedores312 As New ToolStripButton(Constants.MenuNames.FormatosProveedores312)
            AddHandler menuFormatosProveedores312.Click, AddressOf onFormatosProveedores312Click


            'onFormatosCuentasXPagarDiversas313Click
            Dim menuFormatosCuentasXPagarDiversas313 As New ToolStripButton(Constants.MenuNames.FormatosCuentasXPagarDiversas313)
            AddHandler menuFormatosCuentasXPagarDiversas313.Click, AddressOf onFormatosCuentasXPagarDiversas313Click

            'onFormatosBalandeComprobacion317Click
            Dim menuFormatosBalandeComprobacion317 As New ToolStripButton(Constants.MenuNames.FormatosBalandeComprobacion317)
            AddHandler menuFormatosBalandeComprobacion317.Click, AddressOf onFormatosBalandeComprobacion317Click

            'onFormatoCuentaContableClick
            Dim menuFormatoCuentaContable As New ToolStripButton(Constants.MenuNames.FormatoCuentaContable)
            AddHandler menuFormatoCuentaContable.Click, AddressOf onFormatoCuentaContableClick




            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                  Where mPU.DPU_CADENA0.Contains("I033") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = menuFormatoMayorGeneral61
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I039") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(12) = menuFormatosTributos310
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                     Where mPU.DPU_CADENA0.Contains("I034") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(7) = menuFormatoInventarioYBalance32
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I035") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(8) = menuFormatoSaldoClientes33
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I036") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(9) = menuFormatoCuentasXCobrarAccionistas34
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I037") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(10) = menuFormatoCuentasXCobrarDiversas35
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I038") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(11) = menuFormatoCobranzaDudosa36
                cuenta += 1
            End If


            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("I040") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(13) = menuFormatosRenumeracionXPagar311
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I041") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(14) = menuFormatosProveedores312
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I042") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(15) = menuFormatosCuentasXPagarDiversas313
                cuenta += 1
            End If
            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                       Where mPU.DPU_CADENA0.Contains("I043") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(16) = menuFormatosBalandeComprobacion317
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                      Where mPU.DPU_CADENA0.Contains("I044") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(17) = menuFormatoCuentaContable
                cuenta += 1
            End If

            If (cuenta <> 0) Then
                Dim mToolStrip2(cuenta - 1) As ToolStripItem
                Dim mCont2 As Integer = 0
                For mCont As Integer = 0 To mToolStrip.Count - 1
                    If mToolStrip(mCont) IsNot Nothing Then
                        mToolStrip2(mCont2) = mToolStrip(mCont)
                        mCont2 += 1
                    End If
                Next


                ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.AddRange(mToolStrip2)
            End If



        End Sub

        Private Sub onClaseCuentaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmClaseCuenta)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ClaseCuenta
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ClaseCuenta
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
        Private Sub onCuentasContablesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmCuentasContables)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasContabels
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasContabels
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
        Private Sub onLibrosContablesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmLibrosContables)()

            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.LibrosContables
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.LibrosContables
            frm.Show()
        End Sub
        Private Sub onTiposBienesServiciosClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmTiposBienesServicios)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.TiposBienesServicios
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.TiposBienesServicios
            frm.Show()
        End Sub
        Private Sub onCtaCteClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmCtaCte)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.CtaCte
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.CtaCte
            frm.Show()
        End Sub

        Private Sub onOperacionDetracionesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmOperacionDetraciones)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.OperacionDetraciones
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.OperacionDetraciones
            frm.Show()
        End Sub

        Private Sub onCuentasArticuloClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmCuentasArticulo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasArticulo
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasArticulo
            frm.Show()
        End Sub

        Private Sub onCuentasPlanillasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmCuentasPlanillas)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasPlanillas
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasPlanillas
            frm.Show()
        End Sub
        Private Sub onPeriodoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmPeriodos)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.Periodo
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.Periodo
            frm.Show()
        End Sub

        Private Sub onCuentasVariasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmCuentasVarias)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasVarias
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasVarias
            frm.Show()
        End Sub

        Private Sub onAsientosManualesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmAsientosManuales)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.AsientosManuales
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.AsientosManuales
            frm.Show()
        End Sub

        Private Sub onProvisionComprasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmProvisionCompras)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionCompras
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionCompras
            frm.Show()
        End Sub

        Private Sub onProvisionComprasServiciosClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmProvisionCompras)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionComprasServicios
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionComprasServicios
            frm.Show()
        End Sub

        Private Sub onProvisionPlanillasMovilidadClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmProvisionCompras)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionPlanillasMovilidad
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionPlanillasMovilidad
            frm.Show()
        End Sub

        Private Sub onProvisionRendicionEntregasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmProvisionCompras)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionRendicionEntregas
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionRendicionEntregas
            frm.Show()
        End Sub

        Private Sub onProvisionDividendosClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmProvisionCompras)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ProvisionDividendos
            frm.Show()
        End Sub


        Private Sub onAsientoAutomaticoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmAsientoAutomatico)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.AsientoAutomatico
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.AsientoAutomatico

            frm.Show()
        End Sub


        Private Sub onHojaDeTrabajoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmHojaDeTrabajo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.HojaDeTrabajo
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.HojaDeTrabajo
            frm.Show()
        End Sub


        Private Sub onConsultaAsientoContableClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmConsultaAsientoContable)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ConsultaAsientoContable
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ConsultaAsientoContable
            frm.Show()
        End Sub

        Private Sub onFormatoVenta14Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Formatos41)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.BuscadoresNames.Formatos41
            frm.Text = Ladisac.Contabilidad.Constants.BuscadoresNames.Formatos41
            frm.Show()
        End Sub
        Private Sub onFormatoCompra81Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCompra81)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCompra81
            frm.Text = Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCompra81
            frm.Show()
        End Sub

        Private Sub onFormatoMayorGeneral61Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoMayorGeneral61)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.RegistroLibroMayor
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.RegistroLibroMayor
            frm.Show()
        End Sub

        Private Sub onConfiguracionFormatosClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmConfiguracionFormatos)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ConfiguracionFormatos
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ConfiguracionFormatos
            frm.Show()
        End Sub

        Private Sub onFormatoInventarioYBalance32Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoInventarioYBalance32)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoInventarioYBalance32
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoInventarioYBalance32
            frm.Show()
        End Sub

        Private Sub onFormatoSaldoClientes33Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoSaldoClientes33)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoSaldoClientes33
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoSaldoClientes33
            frm.Show()
        End Sub


        Private Sub onFormatoCuentasXCobrarAccionistas34Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCuentasXCobrarAccionistas34)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoCuentasXCobrar34
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoCuentasXCobrar34
            frm.Show()
        End Sub

        Private Sub onFormatoCuentasXCobrarDiversas35Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCuentasXCobrarDiversas35)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoCuentasXCobrarDiversas35
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoCuentasXCobrarDiversas35
            frm.Show()
        End Sub

        Private Sub onFormatoCobranzaDudosa36Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCobranzaDudosa36)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoCobranzaDudosa36
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoCobranzaDudosa36
            frm.Show()
        End Sub

        Private Sub onFormatosTributos310Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosTributos310)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosTributos310
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosTributos310
            frm.Show()
        End Sub


        Private Sub onFormatosRenumeracionXPagar311Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosRenumeracionXPagar311)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosRenumeracionXPagar311
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosRenumeracionXPagar311
            frm.Show()
        End Sub

        Private Sub onFormatosProveedores312Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosProveedores312)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosProveedores312
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosProveedores312
            frm.Show()
        End Sub
        'FormatosCuentasXPagarDiversas313
        Private Sub onFormatosCuentasXPagarDiversas313Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosCuentasXPagarDiversas313)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosCuentasXPagarDiversas313
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosCuentasXPagarDiversas313
            frm.Show()
        End Sub
        'FormatosBalandeComprobacion317
        Private Sub onFormatosBalandeComprobacion317Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatosBalandeComprobacion317)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosBalandeComprobacion317
            frm.Text = frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatosBalandeComprobacion317
            frm.Show()
        End Sub
        ' FormatoCuentaContable
        Private Sub onFormatoCuentaContableClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.FormatoCuentaContable)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoCuentaContable
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.FormatoCuentaContable
            frm.Show()
        End Sub

        ' Comprobantes proveedor
        Private Sub onComprobantesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmComprobantes)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.Comprobantes
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.Comprobantes
            'retenciones

            frm.scuentaCorriente = "012"
            frm.sTipoDocumento = "025"
            frm.sDetalleTipoDocumento = "049"

            frm.sTipoDocumentoB = "013"
            frm.sDetalleTipoDocumentoB = "038"

            frm.sCampoImprimirPie = "PROVEEDOR"
            frm.Show()


        End Sub

        ' Comprobantes proveedor 43
        Private Sub onComprobantes43Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmComprobantes)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.Comprobantes43
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.Comprobantes
            'retenciones

            frm.scuentaCorriente = "012"
            frm.sTipoDocumento = "025"
            frm.sDetalleTipoDocumento = "253"

            frm.sTipoDocumentoB = "013"
            frm.sDetalleTipoDocumentoB = "216"


            frm.sCampoImprimirPie = "PROVEEDOR"
            frm.Show()


        End Sub
        ' Renta de cuarta
        Private Sub onComprobantesRenta4taClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmComprobantes)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRenta4ta
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRenta4ta
            'retenciones

            frm.scuentaCorriente = "012"
            frm.sTipoDocumento = "031"
            frm.sDetalleTipoDocumento = "048"

            frm.sTipoDocumentoB = "031"
            frm.sDetalleTipoDocumentoB = "048"

            frm.sCampoImprimirPie = "PROVEEDOR"
            frm.Show()


        End Sub

        'Comprobantes Retencion Independientes Honorarios Proveedores  ComprobantesRetencionIndependHonorarios
        Private Sub onComprobantesRetencionIndependHonorariosClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmComprobantes)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRetencionIndependHonorarios
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRetencionIndependHonorarios
            'retenciones

            frm.scuentaCorriente = "012"
            frm.sTipoDocumento = "100"
            frm.sDetalleTipoDocumento = "214"
            frm.sCampoImprimirPie = "PROVEEDOR"
            frm.Show()


        End Sub

        ' renta a clinetes igv

        Private Sub onComprobantesRentaIGVClienteClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmComprobantes)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRetencionCliente
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRetencionCliente
            'retenciones
            frm.scuentaCorriente = "001"
            frm.sTipoDocumento = "025"
            frm.sDetalleTipoDocumento = "045"
            frm.sCampoImprimirPie = "CLIENTE"
            frm.Show()


        End Sub

        Private Sub onComprobantesPercepcionIGVClienteClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmComprobantes)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesPercepcionIGVCliente
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesPercepcionIGVCliente
            'retenciones
            frm.scuentaCorriente = "001"
            frm.sTipoDocumento = "025"
            frm.sDetalleTipoDocumento = "185"
            frm.sCampoImprimirPie = "CLIENTE"
            frm.Show()


        End Sub

        ' Comprobantes reportes PROVEEDORES 
        Private Sub onComprobantesReportesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPersona)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Comprobantes)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.Comprobantes
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.Comprobantes
            'retenciones

            frm.campo1 = "025"
            frm.campo2 = "049"

            frm.Show()


        End Sub
        ' Comprobantes reportes percepcion clientes 
        Private Sub onComprobantesPercepcionReportesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPersona)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.ComprobantesPercepcionReportes)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesPercepcionReportes
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesPercepcionReportes
            'retenciones

            frm.campo1 = "025"
            frm.campo2 = "185"

            frm.Show()


        End Sub

        ' Renta 4ta reportes
        Private Sub onComprobantesRenta4taReportesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPersona)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.ComprobantesRenta4ta)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRenta4ta
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRenta4ta
            'retenciones


            frm.campo1 = "031"
            frm.campo2 = "048"


            frm.Show()


        End Sub



        Private Sub onAsientosConProblemasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.AsientosConProblemas)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.AsientosConProblemas
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.AsientosConProblemas
            frm.Show()
        End Sub

        Private Sub onLeasingClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmLeasing)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.Leasing
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.Leasing

            frm.scuentaCorriente = "018"
            frm.sTipoDocumento = "048"
            frm.sDetalleTipoDocumento = "114"

            frm.Show()

        End Sub
        'frmExportarSunatPLE
        Private Sub onExportarSunatPLEClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmExportarSunatPLE)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ExportarSunatPLE
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ExportarSunatPLE
            frm.Show()
        End Sub
        'frmCuentasComprobantesLogistica
        Private Sub onCuentasComprobantesLogisticaClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmCuentasComprobantesLogistica)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasComprobantesLogistica
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.CuentasComprobantesLogistica
            frm.Show()
        End Sub

        'frmReportePagosProveedores
        Private Sub onReportePagosProveedoresClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportePagosProveedores)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.PagosProveedores
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.PagosProveedores
            frm.Show()
        End Sub

        'frmExportarSunatPDT697
        Private Sub onExportarSunatPDT697Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmExportarSunatPDT697)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ExportarSunatPDT697
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ExportarSunatPDT697
            frm.Show()
        End Sub

        'frmExportarSunatPDT626
        Private Sub onExportarSunatPDT626Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmExportarSunatPDT626)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ExportarSunatPDT626
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ExportarSunatPDT626
            frm.Show()
        End Sub

        'frmExportarSunatPDT626
        Private Sub onResumenComprobantesRetencionClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmResumenComprobantesRetencion)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ResumenComprobantesRetencion
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ResumenComprobantesRetencion
            frm.Show()
        End Sub

        Private Sub onLibroInventarioBalanceClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmLibroInventarioBalance)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.LibroInventarioBalance
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.LibroInventarioBalance
            frm.Show()
        End Sub



        'frmReportesCentroCosto
        Private Sub onReportesCentroCostoClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesCentroCosto)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ReportesCentroCosto
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ReportesCentroCosto
            frm.Show()
        End Sub
        'frmReporteMayorAuxiliarMes
        Private Sub onReporteMayorAuxiliarMesClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReporteMayorAuxiliarMes)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ReporteMayorAuxiliarMes
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ReporteMayorAuxiliarMes
            frm.Show()


        End Sub

        'frmReportesXPeriodo
        Private Sub onReportDestinoComprasClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.ReportDestinoCompras)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ReportDestinoCompras
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.ReportDestinoCompras
            frm.Show()

        End Sub
        Private Sub onReportLibroDiarioGeneralClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodoNuevo)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibroDiarioGeneral)
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.LibroDiarioGeneral
            frm.Text = Ladisac.Contabilidad.Constants.MenuNames.LibroDiarioGeneral
            frm.Show()
            'Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesXPeriodo)()
            'frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            'frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.LibroDiarioGeneral)
            'frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.LibroDiarioGeneral
            'frm.Text = Ladisac.Contabilidad.Constants.MenuNames.LibroDiarioGeneral
            'frm.Show()
        End Sub
        Private Sub onRptAnalisisCtasCtesClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of frmRptAnalisisCuentasCorrientes)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
        Private Sub onRptBalanceClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of frmReporteBalance)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub onDocumentoGuiasClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of frmDocumentoGuias)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        'frmReporteCuentasProveedor
        Private Sub onReporteCuentasProveedorClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReporteCuentasProveedor)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmReportesDAOT
        Private Sub onReportesDAOTClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmReportesDAOT)()
            frm.lblTitle.Text = Ladisac.Contabilidad.Constants.MenuNames.ReportesDAOT
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub


    End Class

End Namespace

