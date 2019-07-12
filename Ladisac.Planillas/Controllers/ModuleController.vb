Imports Microsoft.Practices.Unity
Imports System.Windows.Forms
Imports Ladisac.Foundation
Imports System.Data
Imports System.IO
Namespace Ladisac.Planillas

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
        Sub rum()
            RegistrarEventos()
        End Sub

        Public Sub RegistrarEventos()
            Dim evento = EventAggregator.GetEvent(Of Ladisac.Foundation.GlobalEvents.LoginEvent)()
            evento.Subscribe(AddressOf onlogin)
        End Sub
        Private Sub onlogin(ByVal user As String)

            CabMenu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario Where mPU.DPU_CADENA0.Contains("J") Select mPU).Count
            If CabMenu > 0 Then RegistrarMenus()
        End Sub
        Private Sub RegistrarMenus()
            Dim menuItem As New ToolStripMenuItem(Constants.MenuNames.Planillas)
            menuItem.Name = Constants.MenuNames.Planillas
            AddHandler menuItem.Click, AddressOf onPlanillasGruposClick 'onPlanillasClick
            ContainerService.Resolve(Of MainWindow).menuPrincipal.Items.Add(menuItem)
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

        Public Sub onPlanillasGruposClick(ByVal sender As Object, ByVal e As EventArgs)

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            Dim menuMaestroConfigurarPLanillas = BuildBoton("", "Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Planillas ", Global.My.Resources.Resource1.Background_GGG)
            AddHandler menuMaestroConfigurarPLanillas.Click, AddressOf menuMaestroConfigurarPLanillasOnClick
            menuMaestroConfigurarPLanillas.ImageAlign = ContentAlignment.TopCenter

            Dim menuMaestroConfigurarDatosLaborales = BuildBoton("", "Maestro Laborales", Global.My.Resources.Resource1.Background_GGG) ' As New ToolStripButton("Maestro Datos Laborales")
            AddHandler menuMaestroConfigurarDatosLaborales.Click, AddressOf menuMaestroConfigurarDatosLaboralesOnClick


            Dim menuDatosLaborales = BuildBoton("", "Datos Laborales", Global.My.Resources.Resource1.Background_GGG) 'As New ToolStripButton("Datos Laborales")
            AddHandler menuDatosLaborales.Click, AddressOf menuMaestroDatosLaboralesOnClick

            Dim menuTrasacciones = BuildBoton("", "Trasacciones-PLL", Global.My.Resources.Resource1.Background_GGG) 'As New ToolStripButton("Trasacciones- PLanillas ")
            AddHandler menuTrasacciones.Click, AddressOf menuMaestroTrasaccionesOnClick

            Dim menuProduccion = BuildBoton("", "Produccion-Horas", Global.My.Resources.Resource1.Background_GGG) 'As New ToolStripButton("Produccion-Horas ")
            AddHandler menuProduccion.Click, AddressOf menuMaestroProduccionOnClick

            Dim menuPLanillas = BuildBoton("", "Planillas", Global.My.Resources.Resource1.Background_GGG) 'As New ToolStripButton("Planillas")
            AddHandler menuPLanillas.Click, AddressOf menuMaestroPlanillasOnClick

            Dim menuReportes = BuildBoton("", "Reportes-PLanillas", Global.My.Resources.Resource1.Background_GGG) 'As New ToolStripButton("Reportes - PLanillas ")
            AddHandler menuReportes.Click, AddressOf menuMaestroReportesPlanillasOnClick

            Dim menuReportesProduccion = BuildBoton("", "Reportes-Produccion", Global.My.Resources.Resource1.Background_GGG) 'As New ToolStripButton("Reportes - PLanillas ")
            AddHandler menuReportesProduccion.Click, AddressOf menuMaestroReportesProduccionOnClick

            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("J001") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(0) = menuMaestroConfigurarPLanillas
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("J002") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuMaestroConfigurarDatosLaborales
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("J003") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuDatosLaborales
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("J004") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuTrasacciones
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("J005") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuProduccion
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("J006") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuPLanillas
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("J007") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = menuReportes
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                    Where mPU.DPU_CADENA0.Contains("J008") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(7) = menuReportesProduccion
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



        Private Sub menuMaestroConfigurarPLanillasOnClick(ByVal sender As Object, ByVal e As EventArgs)

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            Dim menuConceptos As New ToolStripButton(Constants.MenuNames.Conceptos)
            AddHandler menuConceptos.Click, AddressOf menuConceptosOnClick

            Dim memuConceptosPlanilla As New ToolStripButton(Constants.MenuNames.ConceptosPlanilla)
            AddHandler memuConceptosPlanilla.Click, AddressOf menuConceptosPlanillaOnClick

            'menuTiposPlanillasOnClick
            Dim memuTiposPlanillas As New ToolStripButton(Constants.MenuNames.TiposPlanillas)
            AddHandler memuTiposPlanillas.Click, AddressOf menuTiposPlanillasOnClick

            'menuDetalleConceptosPlanillasOnClick
            Dim memuDetalleConceptosPlanillas As New ToolStripButton(Constants.MenuNames.DetalleConceptosPlanillas)
            AddHandler memuDetalleConceptosPlanillas.Click, AddressOf menuDetalleConceptosPlanillasOnClick

            'menuCalendarioDiasOnClick
            Dim menuCalendarioDias As New ToolStripButton(Constants.MenuNames.CalendarioDias)
            AddHandler menuCalendarioDias.Click, AddressOf menuCalendarioDiasOnClick

            'menuCentroRiesgoOnClick
            Dim menuCentroRiesgo As New ToolStripButton(Constants.MenuNames.CentroRiesgo)
            AddHandler menuCentroRiesgo.Click, AddressOf menuCentroRiesgoOnClick

            Dim mToolStrip(33) As ToolStripItem

            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                  Where mPU.DPU_CADENA0.Contains("J009") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuConceptos
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                 Where mPU.DPU_CADENA0.Contains("J010") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = memuConceptosPlanilla
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                 Where mPU.DPU_CADENA0.Contains("J011") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = memuTiposPlanillas
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                  Where mPU.DPU_CADENA0.Contains("J012") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = memuDetalleConceptosPlanillas
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                 Where mPU.DPU_CADENA0.Contains("J013") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuCalendarioDias
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
                 Where mPU.DPU_CADENA0.Contains("J014") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = menuCentroRiesgo
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

        Private Sub menuMaestroConfigurarDatosLaboralesOnClick(ByVal sender As Object, ByVal e As EventArgs)

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            Dim menuTiposContratos As New ToolStripButton(Constants.MenuNames.TiposContratos)
            AddHandler menuTiposContratos.Click, AddressOf menuTiposContratosOnClick

            Dim menuPeriodisidad As New ToolStripButton(Constants.MenuNames.Periodisidad)
            AddHandler menuPeriodisidad.Click, AddressOf menuPeriodisidadOnClick

            Dim menuTiposCargos As New ToolStripButton(Constants.MenuNames.TiposCargos)
            AddHandler menuTiposCargos.Click, AddressOf menuTiposCargosOnClick

            Dim menuNivelEducacion As New ToolStripButton(Constants.MenuNames.NivelEducacion)
            AddHandler menuNivelEducacion.Click, AddressOf menuNivelEducacionOnClick

            Dim menuConvenioDobleTributacion As New ToolStripButton(Constants.MenuNames.ConvenioDobleTributacion)
            AddHandler menuConvenioDobleTributacion.Click, AddressOf menuConvenioDobleTributacionOnClick

            Dim menuTiposTrabajador As New ToolStripButton(Constants.MenuNames.TiposTrabajador)
            AddHandler menuTiposTrabajador.Click, AddressOf menuTiposTrabajadorOnClick


            Dim menuRegimenLaboral As New ToolStripButton(Constants.MenuNames.RegimenLaboral)
            AddHandler menuRegimenLaboral.Click, AddressOf menuRegimenLaboralOnClick

            Dim menuRegimenPensionario As New ToolStripButton(Constants.MenuNames.RegimenPensionario)
            AddHandler menuRegimenPensionario.Click, AddressOf menuRegimenPensionarioOnClick

            Dim memuDetalleConceptoPensionario As New ToolStripButton(Constants.MenuNames.DetalleConceptoPensionario)
            AddHandler memuDetalleConceptoPensionario.Click, AddressOf menuDetalleConceptoPensionarioOnClick

            Dim menuSituacionEspecialTrabajador As New ToolStripButton(Constants.MenuNames.SituacionEspecialTrabajador)
            AddHandler menuSituacionEspecialTrabajador.Click, AddressOf menuSituacionEspecialTrabajadorOnClick

            Dim memuSituacionTrabajador As New ToolStripButton(Constants.MenuNames.SituacionTrabajador)
            AddHandler memuSituacionTrabajador.Click, AddressOf menuSituacionTrabajadorOnClick


            Dim memuAreaTrabajos As New ToolStripButton(Constants.MenuNames.AreaTrabajos)
            AddHandler memuAreaTrabajos.Click, AddressOf menuAreaTrabajosOnClick



            Dim mToolStrip(33) As ToolStripItem

            Dim cuenta As Integer = 0


            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J015") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuTiposContratos
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J016") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuTiposCargos
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
    Where mPU.DPU_CADENA0.Contains("J017") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuNivelEducacion
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J018") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuConvenioDobleTributacion
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J019") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuTiposTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J020") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = menuRegimenLaboral
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J021") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(7) = menuRegimenPensionario
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
    Where mPU.DPU_CADENA0.Contains("J022") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(8) = memuDetalleConceptoPensionario
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J023") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(9) = menuSituacionEspecialTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
    Where mPU.DPU_CADENA0.Contains("J024") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(10) = memuSituacionTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J025") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(11) = memuAreaTrabajos
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
        Private Sub menuMaestroDatosLaboralesOnClick(ByVal sender As Object, ByVal e As EventArgs)

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            'DatosLaboralesPanelCLick
            Dim menuDatosLaboralesPanel As New ToolStripButton(Constants.MenuNames.DatosLaboralesPanel)
            AddHandler menuDatosLaboralesPanel.Click, AddressOf DatosLaboralesPanelCLick

            'DatosLaboralesPanelHorasCLick
            Dim menuDatosLaboralesPanelHoras As New ToolStripButton(Constants.MenuNames.DatosLaboralesPanelHoras)
            AddHandler menuDatosLaboralesPanelHoras.Click, AddressOf DatosLaboralesPanelHorasCLick

            'Datos Laborales
            Dim memuDatosLaborales As New ToolStripButton(Constants.MenuNames.DatosLaborales)
            AddHandler memuDatosLaborales.Click, AddressOf menuDatosLaboralesOnClick


            Dim memuConceptosTrabajador As New ToolStripButton(Constants.MenuNames.ConceptosTrabajador)
            AddHandler memuConceptosTrabajador.Click, AddressOf menuConceptosTrabajadorOnClick


            Dim mToolStrip(33) As ToolStripItem



            Dim cuenta As Integer = 0


            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J026") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuDatosLaboralesPanel
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
      Where mPU.DPU_CADENA0.Contains("J027") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuDatosLaboralesPanelHoras
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J028") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = memuDatosLaborales
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
       Where mPU.DPU_CADENA0.Contains("J029") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = memuConceptosTrabajador
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

        Private Sub menuMaestroTrasaccionesOnClick(ByVal sender As Object, ByVal e As EventArgs)

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            Dim memuDatosTrabajadorJudicial As New ToolStripButton(Constants.MenuNames.DatosTrabajadorJudicial)
            AddHandler memuDatosTrabajadorJudicial.Click, AddressOf menuDatosTrabajadorJudicialOnClick

            'menuPrestamosTrabajadorOnClick
            Dim memuPrestamosTrabajador As New ToolStripButton(Constants.MenuNames.PrestamosTrabajador)
            AddHandler memuPrestamosTrabajador.Click, AddressOf menuPrestamosTrabajadorOnClick


            'menuPermisosTrabajadorOnClick
            Dim menuPermisosTrabajador As New ToolStripButton(Constants.MenuNames.PermisosTrabajador)
            AddHandler menuPermisosTrabajador.Click, AddressOf menuPermisosTrabajadorOnClick

            'menuReparoTrabajadorOnClick
            Dim menuReparoTrabajador As New ToolStripButton(Constants.MenuNames.ReparoTrabajador)
            AddHandler menuReparoTrabajador.Click, AddressOf menuReparoTrabajadorOnClick
            'menuComedorOnClick
            Dim menuComedor As New ToolStripButton(Constants.MenuNames.Comedor)
            AddHandler menuComedor.Click, AddressOf menuComedorOnClick

            'MarcacionCLick
            Dim menuMarcacion As New ToolStripButton(Constants.MenuNames.Marcacion)
            AddHandler menuMarcacion.Click, AddressOf MarcacionCLick

            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J030") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = memuDatosTrabajadorJudicial
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J031") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = memuPrestamosTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J032") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuPermisosTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
      Where mPU.DPU_CADENA0.Contains("J033") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuReparoTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J034") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuComedor
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J035") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = menuMarcacion
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

        Private Sub menuMaestroPlanillasOnClick(ByVal sender As Object, ByVal e As EventArgs)
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True


            'menuPlanillaOnClick
            Dim menuPlanilla As New ToolStripButton(Constants.MenuNames.Planilla)
            AddHandler menuPlanilla.Click, AddressOf menuPlanillaOnClick


            'menuPlanillaMantenimientoOnClick
            Dim menuPlanillaMantenimiento As New ToolStripButton(Constants.MenuNames.PlanillaMantenimiento)
            AddHandler menuPlanillaMantenimiento.Click, AddressOf menuPlanillaMantenimientoOnClick

            'PlanillasPanelAdministracionCLick
            Dim menuPlanillasPanelAdministracion As New ToolStripButton(Constants.MenuNames.PlanillasPanelAdministracion)
            AddHandler menuPlanillasPanelAdministracion.Click, AddressOf PlanillasPanelAdministracionCLick

            'menuTrabajadorHorasOnClick
            Dim menuTrabajadorHoras As New ToolStripButton(Constants.MenuNames.TrabajadorHoras)
            AddHandler menuTrabajadorHoras.Click, AddressOf menuTrabajadorHorasOnClick

            'GrupoEmpleadoCLick
            Dim menuGrupoEmplead As New ToolStripButton(Constants.MenuNames.GrupoEmpleado)
            AddHandler menuGrupoEmplead.Click, AddressOf GrupoEmpleadoCLick

            'ExportarPlameTRegistroCLick
            Dim menuExportarPlameTRegistro As New ToolStripButton(Constants.MenuNames.ExportarPlameTRegistor)
            AddHandler menuExportarPlameTRegistro.Click, AddressOf ExportarPlameTRegistroCLick



            Dim mToolStrip(33) As ToolStripItem


            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J036") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuPlanilla
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J037") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuPlanillaMantenimiento
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J038") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuPlanillasPanelAdministracion
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
 Where mPU.DPU_CADENA0.Contains("J039") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuTrabajadorHoras
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J040") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuGrupoEmplead
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J063") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(7) = menuExportarPlameTRegistro
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


        Private Sub menuMaestroReportesProduccionOnClick(ByVal sender As Object, ByVal e As EventArgs)

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            'ReporteGrupoTrabajoHoraCLick
            Dim menuReporteGrupoTrabajoHora As New ToolStripButton(Constants.MenuNames.ReporteGrupoTrabajoHora)
            AddHandler menuReporteGrupoTrabajoHora.Click, AddressOf ReporteGrupoTrabajoHoraCLick

            'ReporteTrabajadorHorasDetalleCLick
            Dim menuReporteTrabajadorHorasDetalle As New ToolStripButton(Constants.MenuNames.ReporteTrabajadorHorasDetalle)
            AddHandler menuReporteTrabajadorHorasDetalle.Click, AddressOf ReporteTrabajadorHorasDetalleCLick

            'ReporteGrupoTrabajoDiasDescansoCLick
            Dim menuReporteGrupoTrabajoDiasDescanso As New ToolStripButton(Constants.MenuNames.ReporteGrupoTrabajoDiasDescanso)
            AddHandler menuReporteGrupoTrabajoDiasDescanso.Click, AddressOf ReporteGrupoTrabajoDiasDescansoCLick

            'ReporteGrupoMantenimientoCLick
            Dim menuReporteGrupoMantenimiento As New ToolStripButton(Constants.MenuNames.ReporteGrupoMantenimiento)
            AddHandler menuReporteGrupoMantenimiento.Click, AddressOf ReporteGrupoMantenimientoCLick

            'ReportesTareaTrabajoExportarCLick
            Dim menuReportesTareaTrabajoExportar As New ToolStripButton(Constants.MenuNames.ReportesTareaTrabajoExportar)
            AddHandler menuReportesTareaTrabajoExportar.Click, AddressOf ReportesTareaTrabajoExportarCLick


            Dim mToolStrip(33) As ToolStripItem

            Dim cuenta As Integer = 0

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
            Where mPU.DPU_CADENA0.Contains("J041") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuReporteGrupoTrabajoHora
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
            Where mPU.DPU_CADENA0.Contains("J042") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuReporteTrabajadorHorasDetalle
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
            Where mPU.DPU_CADENA0.Contains("J043") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuReporteGrupoTrabajoDiasDescanso
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
            Where mPU.DPU_CADENA0.Contains("J044") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuReporteGrupoMantenimiento
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
            Where mPU.DPU_CADENA0.Contains("J062") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuReportesTareaTrabajoExportar
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
        Private Sub menuMaestroReportesPlanillasOnClick(ByVal sender As Object, ByVal e As EventArgs)

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            'menuReportesXAcumiladosXTrabajadorOnClick
            Dim menuReportesXAcumiladosXTrabajador As New ToolStripButton(Constants.MenuNames.ReportesXAcumiladosXTrabajador)
            AddHandler menuReportesXAcumiladosXTrabajador.Click, AddressOf menuReportesXAcumiladosXTrabajadorOnClick


            Dim menuReportesImprimirBoleta As New ToolStripButton(Constants.MenuNames.ReporteBoletas)
            AddHandler menuReportesImprimirBoleta.Click, AddressOf menuReportesImprimirBoletaOnClick

            'menuReportesCumpleañosOnClick
            Dim menuReportesCumpleaños As New ToolStripButton(Constants.MenuNames.ReporteCumpleaños)
            AddHandler menuReportesCumpleaños.Click, AddressOf menuReportesCumpleañosOnClick

            'ReporteDatosTrabajadorJudicialCLick
            Dim menuReporteDatosTrabajadorJudicial As New ToolStripButton(Constants.MenuNames.ReporteDatosTrabajadorJudicial)
            AddHandler menuReporteDatosTrabajadorJudicial.Click, AddressOf ReporteDatosTrabajadorJudicialCLick

            'ReporteFichaTrabajadorCLick
            Dim ReporteFichaTrabajador As New ToolStripButton(Constants.MenuNames.ReportePersonaTipoFichas)
            AddHandler ReporteFichaTrabajador.Click, AddressOf ReporteFichaTrabajadorCLick

            'ReportePeriodoLaboralCLick
            Dim menuReportePeriodoLaboral As New ToolStripButton(Constants.MenuNames.ReportePeriodoLaboral)
            AddHandler menuReportePeriodoLaboral.Click, AddressOf ReportePeriodoLaboralCLick

            'ReportePeriodoVacacionesCLick
            Dim menuReportePeriodoVacaciones As New ToolStripButton(Constants.MenuNames.ReportePeriodoVacaciones)
            AddHandler menuReportePeriodoVacaciones.Click, AddressOf ReportePeriodoVacacionesCLick


            'ReporteReporteComedorCLick
            Dim menuReporteReporteComedor As New ToolStripButton(Constants.MenuNames.ReporteComedor)
            AddHandler menuReporteReporteComedor.Click, AddressOf ReporteReporteComedorCLick


            'ReportesPermisosTrabajadorCLick
            Dim menuReportesPermisosTrabajador As New ToolStripButton(Constants.MenuNames.ReportesPermisosTrabajador)
            AddHandler menuReportesPermisosTrabajador.Click, AddressOf ReportesPermisosTrabajadorCLick



            'ReporteHorasPlanillasProduccionCLick
            Dim menuReporteHorasPlanillasProduccion As New ToolStripButton(Constants.MenuNames.ReporteHorasPlanillasProduccion)
            AddHandler menuReporteHorasPlanillasProduccion.Click, AddressOf ReporteHorasPlanillasProduccionCLick

            'ReportesReparoTrabajadorCLick()
            Dim menuReportesReparoTrabajador As New ToolStripButton(Constants.MenuNames.ReportesReparoTrabajador)
            AddHandler menuReportesReparoTrabajador.Click, AddressOf ReportesReparoTrabajadorCLick


            'ReportesReparoTrabajadorCLick()
            Dim menuReporteTardanza As New ToolStripButton(Constants.MenuNames.ReporteTardanzas)
            AddHandler menuReporteTardanza.Click, AddressOf ReporteTardanzasCLick

            Dim mToolStrip(34) As ToolStripItem

            Dim cuenta As Integer = 0




            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J045") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuReportesPermisosTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J046") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuReportesXAcumiladosXTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J047") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuReportesImprimirBoleta
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J048") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuReportesCumpleaños
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J049") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuReporteDatosTrabajadorJudicial
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J050") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = ReporteFichaTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J051") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(7) = menuReportePeriodoLaboral
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J052") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(8) = menuReportePeriodoVacaciones
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J053") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(9) = menuReporteReporteComedor
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J054") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(10) = menuReportesReparoTrabajador
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J055") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(11) = menuReporteHorasPlanillasProduccion
                cuenta += 1
            End If


            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J064") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(12) = menuReporteTardanza
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

        Public Sub menuMaestroProduccionOnClick(ByVal sender As Object, ByVal e As EventArgs)

            ContainerService.Resolve(Of MainWindow).tsSubMenu.Items.Clear()
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Visible = True
            ContainerService.Resolve(Of MainWindow).tsSubMenu.Enabled = True

            'TiposTareaTrabajo
            Dim menuTiposTareaTrabajo As New ToolStripButton(Constants.MenuNames.TiposTareaTrabajo)
            AddHandler menuTiposTareaTrabajo.Click, AddressOf menuTiposTareaTrabajoOnClick

            'menuTareaTrabajoOnClick
            Dim menuTareaTrabajo As New ToolStripButton(Constants.MenuNames.TareaTrabajo)
            AddHandler menuTareaTrabajo.Click, AddressOf menuTareaTrabajoOnClick
            'menuGrupoTrabajoHoraOnClick
            Dim menuGrupoTrabajoHora As New ToolStripButton(Constants.MenuNames.GrupoTrabajoHoras)
            AddHandler menuGrupoTrabajoHora.Click, AddressOf menuGrupoTrabajoHoraOnClick

            'menuGrupoTrabajoTareaOnClick
            Dim menuGrupoTrabajoTarea As New ToolStripButton(Constants.MenuNames.GrupoTrabajoTarea)
            AddHandler menuGrupoTrabajoTarea.Click, AddressOf menuGrupoTrabajoTareaOnClick



            'GrupoMantenimientoCLick
            Dim menuGrupoMantenimiento As New ToolStripButton(Constants.MenuNames.GrupoMantenimiento)
            AddHandler menuGrupoMantenimiento.Click, AddressOf GrupoMantenimientoCLick

            'GrupoTrabajoDiasDescansoCLick
            Dim menuGrupoTrabajoDiasDescanso As New ToolStripButton(Constants.MenuNames.GrupoTrabajoDiasDescanso)
            AddHandler menuGrupoTrabajoDiasDescanso.Click, AddressOf GrupoTrabajoDiasDescansoCLick

            Dim mToolStrip(33) As ToolStripItem
            Dim cuenta As Integer = 0



            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
Where mPU.DPU_CADENA0.Contains("J056") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(1) = menuTiposTareaTrabajo
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
  Where mPU.DPU_CADENA0.Contains("J057") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(2) = menuTareaTrabajo
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
   Where mPU.DPU_CADENA0.Contains("J058") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(3) = menuGrupoTrabajoHora
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J059") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(4) = menuGrupoTrabajoTarea
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
  Where mPU.DPU_CADENA0.Contains("J060") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(5) = menuGrupoMantenimiento
                cuenta += 1
            End If

            Menu = (From mPU In SessionServer.Usuario.PermisoUsuario(0).DetallePermisoUsuario _
     Where mPU.DPU_CADENA0.Contains("J061") Select mPU).Count
            If Menu > 0 Then
                mToolStrip(6) = menuGrupoTrabajoDiasDescanso
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



        'Private Sub menuTiposConceptosOnClick(ByVal sender As Object, ByVal e As EventArgs)
        '    Dim frm = Me.ContainerService.Resolve(Of frmTiposConceptos)()
        '    frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
        '    frm.Show()
        'End Sub

        Private Sub menuConceptosOnClick(ByVal sender As Object, ByVal e As EventArgs)


            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmConceptos)()
            frm.lblTitle.Text = Constants.MenuNames.Conceptos
            frm.Text = Constants.MenuNames.Conceptos

            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
        Private Sub menuTiposContratosOnClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmTiposContratos)()
            frm.lblTitle.Text = Constants.MenuNames.TiposContratos
            frm.Text = Constants.MenuNames.TiposContratos
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
        Private Sub menuPeriodisidadOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmPeriodisidad)()
            frm.lblTitle.Text = Constants.MenuNames.Periodisidad
            frm.Text = Constants.MenuNames.Periodisidad
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
        Private Sub menuTiposCargosOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmTiposCargos)()
            frm.lblTitle.Text = Constants.MenuNames.TiposCargos
            frm.Text = Constants.MenuNames.TiposCargos
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub menuNivelEducacionOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmNivelEducacion)()
            frm.lblTitle.Text = Constants.MenuNames.NivelEducacion
            frm.Text = Constants.MenuNames.NivelEducacion
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub
        Private Sub menuConvenioDobleTributacionOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmConvenioDobleTributacion)()
            frm.lblTitle.Text = Constants.MenuNames.ConvenioDobleTributacion
            frm.Text = Constants.MenuNames.ConvenioDobleTributacion
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub menuTiposTrabajadorOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmTiposTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.TiposTrabajador
            frm.Text = Constants.MenuNames.TiposTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub menuRegimenLaboralOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmRegimenLaboral)()
            frm.lblTitle.Text = Constants.MenuNames.RegimenLaboral
            frm.Text = Constants.MenuNames.RegimenLaboral
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        Private Sub menuRegimenPensionarioOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmRegimenPensionario)()
            frm.lblTitle.Text = Constants.MenuNames.RegimenPensionario
            frm.Text = Constants.MenuNames.RegimenPensionario
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
            'menuSituacionEspecialTrabajadorOnClick
        End Sub

        Private Sub menuSituacionEspecialTrabajadorOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmSituacionEspecialTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.SituacionEspecialTrabajador
            frm.Text = Constants.MenuNames.SituacionEspecialTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuSituacionTrabajadorOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmSituacionTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.SituacionTrabajador
            frm.Text = Constants.MenuNames.SituacionTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub


        Private Sub menuTiposPlanillasOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmTiposPlanillas)()
            frm.lblTitle.Text = Constants.MenuNames.TiposPlanillas
            frm.Text = Constants.MenuNames.TiposPlanillas
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        Private Sub menuConceptosPlanillaOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmConceptosPlanilla)()
            frm.lblTitle.Text = Constants.MenuNames.ConceptosPlanilla
            frm.Text = Constants.MenuNames.ConceptosPlanilla
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        Private Sub menuDatosLaboralesOnClick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmDatosLaborales)()
            frm.lblTitle.Text = Constants.MenuNames.DatosLaborales
            frm.Text = Constants.MenuNames.DatosLaborales
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuAreaTrabajosOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmAreaTrabajos)()
            frm.lblTitle.Text = Constants.MenuNames.AreaTrabajos
            frm.Text = Constants.MenuNames.AreaTrabajos
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        Private Sub menuDetalleConceptoPensionarioOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmDetalleConceptoPensionario)()
            frm.lblTitle.Text = Constants.MenuNames.DetalleConceptoPensionario
            frm.Text = Constants.MenuNames.DetalleConceptoPensionario
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuConceptosTrabajadorOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmConceptosTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.ConceptosTrabajador
            frm.Text = Constants.MenuNames.ConceptosTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub


        Private Sub menuDetalleConceptosPlanillasOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmDetalleConceptosPlanillas)()
            frm.lblTitle.Text = Constants.MenuNames.DetalleConceptosPlanillas
            frm.Text = Constants.MenuNames.DetalleConceptosPlanillas
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuDatosTrabajadorJudicialOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmDatosTrabajadorJudicial)()
            frm.lblTitle.Text = Constants.MenuNames.DatosTrabajadorJudicial
            frm.Text = Constants.MenuNames.DatosTrabajadorJudicial
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        '
        Private Sub menuPrestamosTrabajadorOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmPrestamosTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.PrestamosTrabajador
            frm.Text = Constants.MenuNames.PrestamosTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        '
        Private Sub menuTareaTrabajoOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmTareaTrabajo)()
            frm.lblTitle.Text = Constants.MenuNames.TareaTrabajo
            frm.Text = Constants.MenuNames.TareaTrabajo
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'TiposTareaTrabajo
        Private Sub menuTiposTareaTrabajoOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmTiposTareaTrabajo)()
            frm.lblTitle.Text = Constants.MenuNames.TiposTareaTrabajo
            frm.Text = Constants.MenuNames.TiposTareaTrabajo
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'GrupoTrabajoHora
        Private Sub menuGrupoTrabajoHoraOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmGrupoTrabajoHora)()
            frm.lblTitle.Text = Constants.MenuNames.GrupoTrabajoHoras
            frm.Text = Constants.MenuNames.GrupoTrabajoHoras
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'GrupoTrabajoTarea
        Private Sub menuGrupoTrabajoTareaOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmGrupoTrabajoTarea)()
            frm.lblTitle.Text = Constants.MenuNames.GrupoTrabajoTarea
            frm.Text = Constants.MenuNames.GrupoTrabajoTarea
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'PermisosTrabajador
        Private Sub menuPermisosTrabajadorOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmPermisosTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.PermisosTrabajador
            frm.Text = Constants.MenuNames.PermisosTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuTrabajadorHorasOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmTrabajadorHoras)()
            frm.lblTitle.Text = Constants.MenuNames.TrabajadorHoras
            frm.Text = Constants.MenuNames.TrabajadorHoras
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuCalendarioDiasOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmCalendarioDias)()
            frm.lblTitle.Text = Constants.MenuNames.CalendarioDias
            frm.Text = Constants.MenuNames.CalendarioDias
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        Private Sub menuReparoTrabajadorOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReparoTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.ReparoTrabajador
            frm.Text = Constants.MenuNames.ReparoTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuComedorOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmComedorPLL)()
            frm.lblTitle.Text = Constants.MenuNames.Comedor
            frm.Text = Constants.MenuNames.Comedor
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuPlanillaOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmPlanilla)()
            frm.lblTitle.Text = Constants.MenuNames.Planilla
            frm.Text = Constants.MenuNames.Planilla
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuCentroRiesgoOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmCentroRiesgo)()
            frm.lblTitle.Text = Constants.MenuNames.CentroRiesgo
            frm.Text = Constants.MenuNames.CentroRiesgo
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmReportesXAcumiladosXTrabajador
        Private Sub menuReportesXAcumiladosXTrabajadorOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportesXAcumuladosXTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.ReportesXAcumiladosXTrabajador
            frm.Text = Constants.MenuNames.ReportesXAcumiladosXTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub


        'menuReportesImprimirBoletaOnClick
        Private Sub menuReportesImprimirBoletaOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportesBoletas)()
            frm.lblTitle.Text = Constants.MenuNames.ReporteBoletas
            frm.Text = Constants.MenuNames.ReporteBoletas
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuReportesCumpleañosOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportesTrabajadorCumpleaños)()
            frm.lblTitle.Text = Constants.MenuNames.ReporteBoletas
            frm.Text = Constants.MenuNames.ReporteCumpleaños
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        Private Sub menuPlanillaMantenimientoOnClick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmPlanillaMantenimiento)()
            frm.lblTitle.Text = Constants.MenuNames.PlanillaMantenimiento
            frm.Text = Constants.MenuNames.PlanillaMantenimiento
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        Private Sub ReporteDatosTrabajadorJudicialCLick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportePersona)()
            frm.lblTitle.Text = Constants.MenuNames.ReporteDatosTrabajadorJudicial
            frm.Text = Constants.MenuNames.ReporteDatosTrabajadorJudicial
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        Private Sub ReporteFichaTrabajadorCLick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportePersonaTipoFichas)()

            frm.lblTitle.Text = Constants.MenuNames.ReportePersonaTipoFichas
            frm.Text = Constants.MenuNames.ReportePersonaTipoFichas
            frm.inicio(Ladisac.Planillas.Constants.BuscadoresNames.ReportePersonaTipoFichas)
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

            frm.Show()

        End Sub


        'reporte 
        Private Sub ReportePeriodoLaboralCLick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportePersonaTipoFichas)()

            frm.lblTitle.Text = Constants.MenuNames.ReportePeriodoLaboral
            frm.Text = Constants.MenuNames.ReportePeriodoLaboral
            frm.inicio(Ladisac.Planillas.Constants.BuscadoresNames.ReportePeriodoLaboral)
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

            frm.Show()

        End Sub

        'ReportePeriodoVacaciones
        Private Sub ReportePeriodoVacacionesCLick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportePersonaTipoFichas)()

            frm.lblTitle.Text = Constants.MenuNames.ReportePeriodoVacaciones
            frm.Text = Constants.MenuNames.ReportePeriodoVacaciones
            frm.inicio(Ladisac.Planillas.Constants.BuscadoresNames.ReportePeriodoVacaciones)
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()

            frm.Show()

        End Sub

        Private Sub ReporteReporteComedorCLick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReporteComedor)()
            frm.lblTitle.Text = Constants.MenuNames.ReporteComedor
            frm.Text = Constants.MenuNames.ReporteComedor
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmReporteGrupoTrabajoHora
        Private Sub ReporteGrupoTrabajoHoraCLick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReporteGrupoTrabajoHora)()
            frm.lblTitle.Text = Constants.MenuNames.ReporteGrupoTrabajoHora
            frm.Text = Constants.MenuNames.ReporteGrupoTrabajoHora
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmExportarPlameTRegistro
        Private Sub ExportarPlameTRegistroCLick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmExportarPlameTRegistro)()
            frm.lblTitle.Text = Constants.MenuNames.ExportarPlameTRegistor
            frm.Text = Constants.MenuNames.ExportarPlameTRegistor
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'GrupoMantenimiento
        Private Sub GrupoMantenimientoCLick(ByVal sender As Object, ByVal e As EventArgs)
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmGrupoMantenimiento)()
            frm.lblTitle.Text = Constants.MenuNames.GrupoMantenimiento
            frm.Text = Constants.MenuNames.GrupoMantenimiento
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmMarcacion
        Private Sub MarcacionCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmMarcacion)()
            frm.lblTitle.Text = Constants.MenuNames.Marcacion
            frm.Text = Constants.MenuNames.Marcacion
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        'frmReporteGrupoMantenimiento
        Private Sub ReporteGrupoMantenimientoCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReporteGrupoMantenimiento)()
            frm.lblTitle.Text = Constants.MenuNames.ReporteGrupoMantenimiento
            frm.Text = Constants.MenuNames.ReporteGrupoMantenimiento
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub


        'frmReporteFechaPersona
        Private Sub ReporteTrabajadorHorasDetalleCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReporteFechaPersona)()
            frm.lblTitle.Text = Constants.MenuNames.ReporteTrabajadorHorasDetalle
            frm.Text = Constants.MenuNames.ReporteTrabajadorHorasDetalle
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmGrupoTrabajoDiasDescanso
        Private Sub GrupoTrabajoDiasDescansoCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmGrupoTrabajoDiasDescanso)()
            frm.lblTitle.Text = Constants.MenuNames.GrupoTrabajoDiasDescanso
            frm.Text = Constants.MenuNames.GrupoTrabajoDiasDescanso
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmReporteGrupoTrabajoDiasDescanso
        Private Sub ReporteGrupoTrabajoDiasDescansoCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReporteGrupoTrabajoDiasDescanso)()
            frm.lblTitle.Text = Constants.MenuNames.GrupoTrabajoDiasDescanso
            frm.Text = Constants.MenuNames.GrupoTrabajoDiasDescanso
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        'frmPlanillasPanelAdministracion
        Private Sub PlanillasPanelAdministracionCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmPlanillasPanelAdministracion)()
            frm.lblTitle.Text = Constants.MenuNames.PlanillasPanelAdministracion
            frm.Text = Constants.MenuNames.PlanillasPanelAdministracion
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        ' frmDatosLaboralesPanel
        Private Sub DatosLaboralesPanelCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmDatosLaboralesPanel)()
            frm.lblTitle.Text = Constants.MenuNames.DatosLaboralesPanel
            frm.Text = Constants.MenuNames.DatosLaboralesPanel
            frm.sBuscar = Constants.MenuNames.DatosLaboralesPanel
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'DatosLaboralesPanelHoras
        Private Sub DatosLaboralesPanelHorasCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmDatosLaboralesPanel)()
            frm.lblTitle.Text = Constants.MenuNames.DatosLaboralesPanelHoras
            frm.Text = Constants.MenuNames.DatosLaboralesPanelHoras
            frm.sBuscar = Constants.MenuNames.DatosLaboralesPanelHoras
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        'frmReportesPermisosTrabajador
        Private Sub ReportesPermisosTrabajadorCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportesPermisosTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.ReportesPermisosTrabajador
            frm.sBuscar = Constants.MenuNames.ReportesPermisosTrabajador

            frm.Text = Constants.MenuNames.ReportesPermisosTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub

        'ReportesReparoTrabajador
        Private Sub ReportesReparoTrabajadorCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportesPermisosTrabajador)()
            frm.lblTitle.Text = Constants.MenuNames.ReportesReparoTrabajador
            frm.sBuscar = Constants.MenuNames.ReportesReparoTrabajador

            frm.Text = Constants.MenuNames.ReportesReparoTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmReporteHorasPlanillasProduccion
        Private Sub ReporteHorasPlanillasProduccionCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReporteHorasPlanillasProduccion)()
            frm.lblTitle.Text = Constants.MenuNames.ReportesPermisosTrabajador
            frm.Text = Constants.MenuNames.ReportesPermisosTrabajador
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmGrupoEmpleado
        Private Sub GrupoEmpleadoCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmGrupoEmpleado)()
            frm.lblTitle.Text = Constants.MenuNames.ReporteGrupoMantenimiento
            frm.Text = Constants.MenuNames.ReporteGrupoMantenimiento
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
        'frmReportesTareaTrabajoExportar
        Private Sub ReportesTareaTrabajoExportarCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmReportesTareaTrabajoExportar)()
            frm.lblTitle.Text = Constants.MenuNames.ReportesTareaTrabajoExportar
            frm.Text = Constants.MenuNames.ReportesTareaTrabajoExportar
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()
        End Sub

        'frmReporteTardanzaXMes
        Private Sub ReporteTardanzasCLick(ByVal sender As Object, ByVal e As EventArgs)

            Dim frm = Me.ContainerService.Resolve(Of frmReporteTardanzas)()
            frm.MdiParent = Me.ContainerService.Resolve(Of MainWindow)()
            frm.Show()

        End Sub
    End Class
End Namespace
