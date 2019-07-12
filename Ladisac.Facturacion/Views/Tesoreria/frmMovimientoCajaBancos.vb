Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.CuentasCorrientes.Views
    Public Class frmMovimientoCajaBancos
#Region "Primaria"
#Region "Declaraciones"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        <Dependency()>
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Private pLoaded As Boolean = True
        Private pColeccionDatos As Collection = Nothing
        Private pComportamiento As Int32 = 0
        Private pOrdenBusqueda As Int32 = 0
        Private pDatoBusquedaConsulta As String = ""

        Private pAgregar As Boolean = True
        Private pQuitar As Boolean = True
        Private pSalida As Boolean = True
#End Region
#Region "Propiedades"
        Public ReadOnly Property Loaded() As Boolean
            Get
                Return pLoaded
            End Get
        End Property
        Public Property ColeccionDatos() As Collection
            Get
                Return pColeccionDatos
            End Get
            Set(ByVal value As Collection)
                pColeccionDatos = value
            End Set
        End Property
        Public Property Comportamiento() As Int32
            Get
                Return pComportamiento
            End Get
            Set(ByVal value As Int32)
                pComportamiento = value
            End Set
        End Property
        Public Property OrdenBusqueda() As Int32
            Get
                Return pOrdenBusqueda
            End Get
            Set(ByVal value As Int32)
                pOrdenBusqueda = value
            End Set
        End Property
        Public Property DatoBusquedaConsulta() As String
            Get
                Return pDatoBusquedaConsulta
            End Get
            Set(ByVal value As String)
                pDatoBusquedaConsulta = value
            End Set
        End Property

        Public Property Agregar() As Boolean
            Set(ByVal value As Boolean)
                pAgregar = value
            End Set
            Get
                Return pAgregar
            End Get
        End Property
        Public Property Quitar() As Boolean
            Set(ByVal value As Boolean)
                pQuitar = value
            End Set
            Get
                Return pQuitar
            End Get
        End Property
        Public Property Salida() As Boolean
            Set(ByVal value As Boolean)
                pSalida = value
            End Set
            Get
                Return pSalida
            End Get
        End Property
#End Region
#Region "CheckBox"
        Public Structure chk
            Public Property pFormatearTexto As Boolean
            Public Property pNombreCampo As String
            Public Property vEstado0 As String
            Public Property vEstado1 As String
            Public Property vEstadoX As String
            Public Property pSimple As Object
            Public Property pValorDefault As System.Windows.Forms.CheckState
        End Structure
        Private Sub ConfigurarCheck_Refrescar(ByRef vObjeto As chk)
            If vObjeto.pFormatearTexto Then
                vObjeto.pSimple.vista = "TipoCampoEspecifico"
                vObjeto.pSimple.CampoId = vObjeto.pNombreCampo

                vObjeto.pSimple.Dato = 0
                vObjeto.vEstado0 = vObjeto.pSimple.TipoCampoEspecifico()

                vObjeto.pSimple.Dato = 1
                vObjeto.vEstado1 = vObjeto.pSimple.TipoCampoEspecifico()

                vObjeto.pSimple.Dato = Nothing
                vObjeto.vEstadoX = vObjeto.pSimple.TipoCampoEspecifico()

                InicializarTextoCheck(vObjeto)
            End If
        End Sub
#End Region
#Region "ComboBox"
        Public Structure cbo
            Public Property pNombreCampo As String
        End Structure
#End Region
#Region "TextBox"
        Public Structure txt
            Public Property pTexto1 As String
            Public Property pTexto2 As String
            Public Property pSoloNumerosDecimales As Boolean
            Public Property pSoloNumeros As Boolean
            Public Property pNegativos As Boolean
            Public Property pParteEntera As Int16
            Public Property pParteDecimal As Int16
            Public Property pMinusculaMayuscula As Boolean
            Public Property pBusqueda As Boolean
            Public Property pCadenaFiltrado As String

            Public Property pOOrm As Object
            Public Property pFormularioConsulta As Boolean

            Public Property pComportamiento As Int16
            Public Property pOrdenBusqueda As Int16
        End Structure
        Private Sub ValidarDatos(ByRef otxt As txt, ByRef texto As TextBox)
            With otxt
                If .pTexto1 <> .pTexto2 Then
                    .pTexto2 = texto.Text
                    If .pBusqueda Then
                        MetodoBusquedaDato(texto.Text, True, otxt)
                    End If
                End If
                SubValidarDatos(otxt, texto)
            End With
        End Sub
        Private Sub MetodoBusquedaDato(ByVal vDatoBusqueda As String, _
                       ByVal vBusquedaDirecta As Boolean, _
                       ByVal vtxt As txt)
            Try
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                If vBusquedaDirecta Then
                    frm.TipoEdicion = 2
                    If pComportamiento = -1 Then
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = vDatoBusqueda
                    End If
                    frm.DatoBusqueda = vDatoBusqueda
                Else
                    frm.TipoEdicion = 1
                    frm.DatoBusqueda = ""
                End If
                frm.oOrm = vtxt.pOOrm
                frm.Comportamiento = vtxt.pComportamiento
                frm.NombreFormulario = Me
                frm.OrdenBusqueda = vtxt.pOrdenBusqueda
                frm.ShowDialog()
                frm.Dispose()
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - MetodoBusquedaDato")
            End Try
        End Sub
        Private Sub TeclaF1(ByRef EtxtTemporal As txt, ByRef txt As TextBox)
            If EtxtTemporal.pBusqueda Then
                EtxtTemporal.pTexto2 = txt.Text
                ValidarDatos(EtxtTemporal, txt)

                If txt.Name = "txtPER_ID" Then
                    EtxtPER_ID.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
                    EtxtPER_ID.pComportamiento = 6
                    EtxtPER_ID.pOrdenBusqueda = 1
                    EtxtPER_ID.pOOrm.CadenaFiltrado = " AND CODIGO IN (select PER_ID from dbo.vwRolPersonaTipoPersona where PER_TRABAJADOR='SI' AND TPE_ID='" & BCVariablesNames.TipoPersonas.Cobrador & "') "
                End If

                MetodoBusquedaDato("", False, EtxtTemporal)

                If txt.Name = "txtPER_ID" Then
                    EtxtPER_ID.pOOrm = New Ladisac.BE.RolPersonaTipoPersona
                    EtxtPER_ID.pComportamiento = 3
                    EtxtPER_ID.pOrdenBusqueda = 0
                    EtxtPER_ID.pOOrm.CadenaFiltrado = " AND PER_TRABAJADOR='SI' AND TPE_ID='" & BCVariablesNames.TipoPersonas.Cobrador & "'"
                End If

                EtxtTemporal.pTexto1 = txt.Text
                EtxtTemporal.pTexto2 = txt.Text
            End If
        End Sub
#End Region
#Region "Procedures"
        Public Overrides Sub LlamarMetodo(ByVal NombreMetodo As String)
            Select Case NombreMetodo
                Case "AgregarFilaGrid"
                    AgregarFilaGrid()
                Case "QuitarFilaGrid"
                    QuitarFilaGrid()
                Case "Salir"
                    Salir()
            End Select
        End Sub
        Public Sub AgregarFilaGrid()
            AdicionarFilasGrid()
        End Sub
        Public Sub QuitarFilaGrid()
            EliminarFilasGrid()
        End Sub
        Public Sub Salir()
            Me.Close()
        End Sub
        Public Overrides Sub PosicionBarra(ByVal Metodo As String)
            Select Case Metodo
                Case "^"
                    tsBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
                    tsBarra.Dock = System.Windows.Forms.DockStyle.Top
                    lblTitle.Dock = DockStyle.None
                Case "V"
                    tsBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
                    tsBarra.Dock = System.Windows.Forms.DockStyle.Bottom
                Case "<"
                    tsBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
                    tsBarra.Dock = System.Windows.Forms.DockStyle.Left
                Case ">"
                    tsBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
                    tsBarra.Dock = System.Windows.Forms.DockStyle.Right
            End Select
        End Sub

        Private Sub BotonesEdicion(ByVal vProceso As String)
            Select Case vProceso
                Case Else
                    Agregar = True
                    Quitar = True
                    Salida = False
                    pnCuerpo.Enabled = True
            End Select
            FormatearBotonesEdicion()
        End Sub
        Private Sub FormatearBotonesEdicion()
            tsbNuevo.Enabled = False
            tsbEditar.Enabled = False
            tsbCancelarEditar.Enabled = False
            tsbGrabar.Enabled = False
            TsbGrabarNuevo.Enabled = False
            tsbEliminar.Enabled = False
            tsbDeshacer.Enabled = False
            tsbAgregar.Enabled = Agregar
            tsbQuitar.Enabled = Quitar
            tsbBuscar.Enabled = False
            tsbInicio.Enabled = False
            tsbAnterior.Enabled = False
            tsbSiguiente.Enabled = False
            tsbFinal.Enabled = False
            tsbReportes.Enabled = False
            tsbSalir.Enabled = Salida
        End Sub
        Public Sub InicializarValores(ByRef sender As System.Object, _
                                     ByRef senderError As System.Windows.Forms.ErrorProvider, _
                                     Optional ByVal e As System.Boolean = False, _
                                     Optional ByVal e1 As System.Boolean = False, _
                                     Optional ByVal e2 As System.Windows.Forms.CheckState = CheckState.Indeterminate)

            Select Case sender.GetType
                Case GetType(System.Windows.Forms.TextBox)
                    If e Or e1 Then
                        sender.text = "0"
                    Else
                        sender.text = ""
                    End If
                Case (GetType(System.Windows.Forms.ComboBox))
                    sender.text = ""
                Case GetType(System.Windows.Forms.DateTimePicker)
                    sender.value = Today
                Case GetType(System.Windows.Forms.DataGridView)
                    sender.Rows.Clear()
                Case GetType(System.Windows.Forms.PictureBox)
                    sender.image = Nothing
                Case GetType(System.Windows.Forms.CheckBox)
                    sender.Checked = Nothing
                    sender.CheckState = e2
                Case GetType(System.String)
                    Dim vCadenaArray(0) As String
                    sender = vCadenaArray
                Case Else
                    Select Case sender.GetType.BaseType
                        Case GetType(System.Array)
                            ' No implementado
                    End Select
            End Select
            If senderError Is Nothing Then
            Else
                senderError.SetError(sender, Nothing)
            End If
        End Sub

        Private Function DevolverTiposCampos(ByVal oNombreCampo As String, ByVal oTexto As String, ByVal oOrm As Object) As String
            oOrm.CampoId = oNombreCampo
            oOrm.Dato = oTexto
            DevolverTiposCampos = oOrm.DevolverTiposCampos()
        End Function

        Private Sub NavegarGrid(ByVal Metodo As String)
            cMisProcedimientos.PosicionGrid(Metodo, ActiveControl, Me.Text)
        End Sub

        Public Sub ComportamientoFormulario()
            If pComportamiento <> -1 Then
                NombresFormulariosControles()
                FiltrarOrm()
            End If
            pLoaded = False
        End Sub
        Private Sub BuscarFormatos(ByRef vObjeto As cbo, _
                ByVal oSimple As Object, _
                ByRef oComboBox As ComboBox, _
                ByVal vOrdenBusqueda As Int16)
            oSimple.CampoId = vObjeto.pNombreCampo
            cMisProcedimientos.AdicionarElementoCombosEdicion(oComboBox, oSimple.BuscarFormatos(), vOrdenBusqueda)
        End Sub

        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            TeclasAccesoRapido(keyData)
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function

        Private Sub TeclasAccesoRapido(ByVal vkeyData As System.Windows.Forms.Keys)
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.Add Then
                If tsbAgregar.Enabled = True Then LlamarMetodo("AgregarFilaGrid")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.Subtract Then
                If tsbQuitar.Enabled = True Then LlamarMetodo("QuitarFilaGrid")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.S Then
                If tsbSalir.Enabled = True Then LlamarMetodo("Salir")
            End If
        End Sub

        Private Sub frm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
            Handles MyBase.FormClosing
            If pnCuerpo.Enabled = True Then
                MyBase.OnClosing(e)
            End If
        End Sub

        Private Sub Reporte_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles MyBase.Activated
            If pComportamiento <> -1 Then
                Activado()  ' Comportamiento del formulario cuando esta activado
            End If
        End Sub
        Private Sub Activado()
            ActivarBarra()
        End Sub
        Private Sub ActivarBarra()
            If tsBarra.Enabled = False Then
                tsBarra.Enabled = True
            End If
        End Sub

        Private Sub Reporte_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) _
            Handles MyBase.FormClosed
            If pComportamiento <> -1 Then
                Cerrado()
            End If
        End Sub
        Private Sub Cerrado()
        End Sub
#End Region
#End Region
        ''
#Region "Primaria1"
#Region "TextBox"
        Private Sub SubValidarDatos(ByRef otxt As txt, ByRef texto As TextBox)
            With otxt
                If .pSoloNumeros Then
                    If texto.Text = "" Or Not IsNumeric(texto.Text) Then texto.Text = "0"
                End If
                If .pSoloNumerosDecimales Then
                    Dim vSoloNumerosDecimales As String
                    If .pParteEntera > 0 And .pParteDecimal > 0 Then
                        If .pParteDecimal = 0 Then
                            vSoloNumerosDecimales = Strings.StrDup(.pParteEntera, "#")
                        Else
                            vSoloNumerosDecimales = Strings.StrDup(.pParteEntera, "#") & "." & Strings.StrDup(.pParteDecimal - 1, "#") & "0"
                        End If
                        If texto.Text = "" Then texto.Text = "0"
                        Try
                            texto.Text = Format(CDbl(texto.Text), vSoloNumerosDecimales)
                            If Len(texto.Text) > (.pParteEntera + .pParteDecimal + 1) Then
                                texto.Text = "0"
                                texto.Text = Format(CDbl(texto.Text), vSoloNumerosDecimales)
                            End If
                        Catch ex As Exception
                            texto.Text = "0"
                            texto.Text = Format(CDbl(texto.Text), vSoloNumerosDecimales)
                        End Try
                    Else
                        If texto.Text = "" Then texto.Text = "0"
                    End If
                End If
            End With
        End Sub
        Private Sub oKeyPress(ByVal EtxtTemporal As txt, ByRef e As System.Windows.Forms.KeyPressEventArgs)
            If EtxtTemporal.pMinusculaMayuscula Then
                e.KeyChar = UCase(e.KeyChar)
            End If
            If EtxtTemporal.pSoloNumerosDecimales Then
                If Not IsNumeric(e.KeyChar) Then
                    If Asc(e.KeyChar) <> 46 Then
                        If Asc(e.KeyChar) <> 8 Then
                            If Asc(e.KeyChar) = 45 And Not EtxtTemporal.pNegativos Then
                                e.KeyChar = ""
                            ElseIf Asc(e.KeyChar) <> 45 Then
                                e.KeyChar = ""
                            End If
                        End If
                    Else
                        If EtxtTemporal.pParteDecimal = 0 Then
                            e.KeyChar = ""
                        End If
                    End If
                End If
            End If
            If EtxtTemporal.pSoloNumeros Then
                If Not IsNumeric(e.KeyChar) Then
                    If Asc(e.KeyChar) <> 8 Then
                        If Asc(e.KeyChar) = 45 And Not EtxtTemporal.pNegativos Then
                            e.KeyChar = ""
                        ElseIf Asc(e.KeyChar) <> 45 Then
                            e.KeyChar = ""
                        End If
                    End If
                End If
            End If
        End Sub
#End Region
#End Region

#Region "Declaraciones"
        <Dependency()> _
        Public Property BL As Ladisac.BE.DetalleTesoreria

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        Dim vTitulo1 As String
        Dim vTitulo2 As String
        Dim vTitulo3 As String

        Private EtxtCCC_ID As New txt
        Private EtxtCCC_DESCRIPCION As New txt
        Private EtxtMON_ID As New txt
        Private EtxtMON_DESCRIPCION As New txt
        Private EtxtCCT_ID As New txt
        Private EtxtCCT_DESCRIPCION As New txt
        Private EtxtDTD_ID As New txt
        Private EtxtDTD_DESCRIPCION As New txt
        Private EtxtPER_ID As New txt
        Private EtxtPER_DESCRIPCION As New txt

        Dim oReporte1 As New MovimientoCajaBancoSubInforme
        'Dim oReporte2 As New Ladisac.Tesoreria.Reportes.MovimientoCajaBancoResumenSubInforme
        Dim oReporte2 As New MovimientoCajaBancoResumenSubInformeNuevo

        Dim oReporte3 As New Ladisac.Tesoreria.Reportes.MovimientoCajaBancoTotalizados
        Dim oReporte4 As New MovimientoCajaBancoVertical

        'Dim oReporte5 As New Ladisac.Tesoreria.Reportes.MovimientoCajaBancoResumenVertical
        Dim oReporte5 As New MovimientoCajaBancoVerticalNuevo


        Dim oReporte6 As New MovimientoCajaBanco
        Dim oReporte7 As New MovimientoCajaBancoResumen

        Dim oReporte8 As New Ladisac.Tesoreria.Reportes.MovimientoCajaBancoHoraGrabacion
        Dim oReporte9 As New Ladisac.Tesoreria.Reportes.MovimientoCajaBancoSubInformeHoraGrabacion

        Dim oReporte11 As New MovimientoCajaBancoEgresos
        Dim oReporte10 As New MovimientoCajaBancoResumenEgresos

        Dim oReporte As Object
#Region "Clases"
        'Private Reporte As New Ladisac.BE.Personas
        'Private Reporte1 As New Ladisac.BE.CtaCte

        Private cMisProcedimientos As New Ladisac.MisProcedimientos
#End Region
#End Region
#Region "Secundaria"
#Region "Procedimientos asociados a los procedimientos asociados a la barra de herramientas del formulario, deben de existir"
        Private Sub LimpiarDatos()
            InicializarValores(txtCCC_ID, ErrorProvider1)
            InicializarValores(txtCCC_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtCCC_CUENTA_BANCARIA, ErrorProvider1)
            InicializarValores(txtMON_ID, ErrorProvider1)
            InicializarValores(txtMON_SIMBOLO, ErrorProvider1)
            InicializarValores(txtMON_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtCCT_ID, ErrorProvider1)
            InicializarValores(txtCCT_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtDTD_ID, ErrorProvider1)
            InicializarValores(txtDTD_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtPER_ID, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION, ErrorProvider1)
            InicializarValores(dtpFechaInicial, ErrorProvider1)
            InicializarValores(dtpFechaFinal, ErrorProvider1)
        End Sub

        Public Overridable Sub ColocarValoresDefault(ByVal vOBjeto As Object)
            Select Case vOBjeto.ValorDefault
                Case CheckState.Checked
                    vOBjeto.Checked = True
                    vOBjeto.CheckState = CheckState.Checked
                Case CheckState.Unchecked
                    vOBjeto.Checked = False
                    vOBjeto.CheckState = CheckState.Unchecked
                Case CheckState.Indeterminate
                    vOBjeto.Checked = Nothing
                    vOBjeto.CheckState = CheckState.Indeterminate
            End Select
        End Sub

        Private Sub AdicionarFilasGrid()
        End Sub
        Private Sub EliminarFilasGrid()
        End Sub
        Private Function Validar(ByVal vModelos As String) As Boolean
        End Function

        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtCCC_ID" Then EtxtCCC_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtCCC_ID" Then EtxtCCC_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function

        Private Sub frmMovimientoCajaBancos_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles Me.Load

            'If SessionService.NombreEmpresa = "Ladrillera El Diamante SAC" Then
            '    Me.BackColor = Me.ContainerService.Resolve(Of Foundation.MainWindow)().BackColor 'System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            'Else
            '    Me.BackColor = System.Drawing.Color.CadetBlue
            'End If

            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                chkFechaHora.Enabled = False
                chkFechaHora.Visible = False
                chkFechaHora.CheckState = CheckState.Unchecked

                ConfigurarCheck()
                ConfigurarComboBox()
                ConfigurarText()
                AdicionarElementoCombosEdicion()
                ComportamientoFormulario()
                FormatearCampos()
                BotonesEdicion("")
                Select Case Me.Name
                    Case "frmSaldoCajaBanco"
                        lblCCC_TIPO.Enabled = True
                        lblCCC_TIPO.Visible = True

                        cboCCC_TIPO.Enabled = True
                        cboCCC_TIPO.Visible = True

                        lblCCC_ID.Enabled = False
                        lblCCC_ID.Visible = False
                        txtCCC_ID.Enabled = False
                        txtCCC_ID.Visible = False
                        txtCCC_DESCRIPCION.Enabled = False
                        txtCCC_DESCRIPCION.Visible = False

                        txtPER_DESCRIPCION_BAN.Enabled = False
                        txtPER_DESCRIPCION_BAN.Visible = False
                        txtCCC_CUENTA_BANCARIA.Enabled = False
                        txtCCC_CUENTA_BANCARIA.Visible = False
                        txtCCC_TIPO.Enabled = False
                        txtCCC_TIPO.Visible = False

                        lblMON_ID.Enabled = False
                        lblMON_ID.Visible = False
                        txtMON_ID.Enabled = False
                        txtMON_ID.Visible = False
                        txtMON_SIMBOLO.Enabled = False
                        txtMON_SIMBOLO.Visible = False
                        txtMON_DESCRIPCION.Enabled = False
                        txtMON_DESCRIPCION.Visible = False

                        lblCCT_ID.Enabled = False
                        lblCCT_ID.Visible = False
                        txtCCT_ID.Enabled = False
                        txtCCT_ID.Visible = False
                        txtCCT_DESCRIPCION.Enabled = False
                        txtCCT_DESCRIPCION.Visible = False

                        lblDTD_ID.Enabled = False
                        lblDTD_ID.Visible = False
                        txtDTD_ID.Enabled = False
                        txtDTD_ID.Visible = False
                        txtDTD_DESCRIPCION.Enabled = False
                        txtDTD_DESCRIPCION.Visible = False

                        lblPER_ID.Enabled = False
                        lblPER_ID.Visible = False
                        txtPER_ID.Enabled = False
                        txtPER_ID.Visible = False
                        txtPER_DESCRIPCION.Enabled = False
                        txtPER_DESCRIPCION.Visible = False

                        lblFechaInicial.Text = "Saldos al"

                        lblFechaFinal.Enabled = False
                        lblFechaFinal.Visible = False
                        dtpFechaFinal.Enabled = False
                        dtpFechaFinal.Visible = False

                        chkFiltrarXFechas.Enabled = False
                        chkFiltrarXFechas.Visible = False

                        pnTipoReporte.Enabled = False
                        pnTipoReporte.Visible = False

                        pnMovimientos.Enabled = False
                        pnMovimientos.Visible = False

                        pnTipoReporte.Enabled = False
                        pnTipoReporte.Visible = False

                        lblFechaInicial.Location = New System.Drawing.Point(7, 12)
                        dtpFechaInicial.Location = New System.Drawing.Point(80, 12)

                        cboCCC_TIPO.Location = New System.Drawing.Point(80, 38)
                        cboCCC_TIPO.Text = "CUENTA DE BANCO"

                        btnImprimir.Location = New System.Drawing.Point(80, 64) '91,89

                        Me.ClientSize = New System.Drawing.Size(680, 180)
                    Case Else
                        lblCCC_TIPO.Enabled = False
                        lblCCC_TIPO.Visible = False

                        cboCCC_TIPO.Enabled = False
                        cboCCC_TIPO.Visible = False

                        If IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTEMOVIMIENTOCAJABANCO", "CHECKFECHAHORA") Then
                            chkFechaHora.Enabled = True
                            chkFechaHora.Visible = True
                            chkFechaHora.CheckState = CheckState.Checked
                        Else
                            chkFechaHora.Enabled = False
                            chkFechaHora.Visible = False
                            chkFechaHora.CheckState = CheckState.Unchecked
                        End If

                End Select
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- Load")
            End Try
        End Sub
        Private Sub AdicionarElementoCombosEdicion()

        End Sub
        Private Sub NombresFormulariosControles()
            EtxtCCC_ID.pOOrm = New Ladisac.BE.CajaCtaCte
            EtxtCCC_ID.pComportamiento = 1
            EtxtCCC_ID.pOrdenBusqueda = 0

            EtxtCCT_ID.pOOrm = New Ladisac.BE.CtaCte
            EtxtCCT_ID.pComportamiento = 2
            EtxtCCT_ID.pOrdenBusqueda = 0

            EtxtPER_ID.pOOrm = New Ladisac.BE.RolPersonaTipoPersona
            EtxtPER_ID.pComportamiento = 3
            EtxtPER_ID.pOrdenBusqueda = 0
            EtxtPER_ID.pOOrm.CadenaFiltrado = " AND PER_TRABAJADOR='SI' AND TPE_ID='" & BCVariablesNames.TipoPersonas.Cobrador & "'"

            EtxtMON_ID.pOOrm = New Ladisac.BE.Moneda
            EtxtMON_ID.pComportamiento = 4
            EtxtMON_ID.pOrdenBusqueda = 0

            EtxtDTD_ID.pOOrm = New Ladisac.BE.DetalleTipoDocumentos
            EtxtDTD_ID.pComportamiento = 5
            EtxtDTD_ID.pOrdenBusqueda = 3
            EtxtDTD_ID.pOOrm.CadenaFiltrado = " AND DTD_ESTADO='ACTIVO' "

        End Sub

        Public Sub InicializarDatos()
            'OrmBusquedaDatos("InicializarDatos")
            'pRegistroNuevo = False
        End Sub
#End Region
#Region "CheckBox"
        Private Sub ConfigurarCheck()
            Dim EchkTemporal As New chk

            EchkTemporal.pFormatearTexto = True
            EchkTemporal.vEstado0 = ""
            EchkTemporal.vEstado1 = ""
            EchkTemporal.vEstadoX = ""
            EchkTemporal.pSimple = BL
            EchkTemporal.pValorDefault = CheckState.Checked
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case ""
            End Select
            DevolverTiposCampos = BL.DevolverTiposCampos()
        End Function
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case ""
            End Select
            Select Case vObjetoChk.pValorDefault
                Case CheckState.Checked
                    vObjeto.Checked = True
                    vObjeto.CheckState = CheckState.Checked
                Case CheckState.Unchecked
                    vObjeto.Checked = False
                    vObjeto.CheckState = CheckState.Unchecked
                Case CheckState.Indeterminate
                    vObjeto.Checked = Nothing
                    vObjeto.CheckState = CheckState.Indeterminate
            End Select
        End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case ""
            End Select
        End Sub
        Public Sub Check_Refrescar()
        End Sub
#End Region
#Region "ComboBox"
        Private Sub ConfigurarComboBox()
        End Sub
#End Region
#Region "TextBox"
        Private Sub ConfigurarText()
            Dim EtxtTemporal As New txt
            EtxtTemporal.pTexto1 = ""
            EtxtTemporal.pTexto2 = ""
            EtxtTemporal.pSoloNumerosDecimales = False
            EtxtTemporal.pSoloNumeros = False
            EtxtTemporal.pNegativos = False
            EtxtTemporal.pParteEntera = 0
            EtxtTemporal.pParteDecimal = 0
            EtxtTemporal.pMinusculaMayuscula = True
            EtxtTemporal.pBusqueda = False
            EtxtTemporal.pCadenaFiltrado = ""
            EtxtTemporal.pOOrm = Nothing
            EtxtTemporal.pFormularioConsulta = False
            EtxtTemporal.pComportamiento = Nothing
            EtxtTemporal.pOrdenBusqueda = 0

            EtxtCCC_ID = EtxtTemporal
            EtxtCCC_DESCRIPCION = EtxtTemporal

            EtxtMON_ID = EtxtTemporal
            EtxtMON_DESCRIPCION = EtxtTemporal

            EtxtCCT_ID = EtxtTemporal
            EtxtCCT_DESCRIPCION = EtxtTemporal

            EtxtDTD_ID = EtxtTemporal
            EtxtDTD_DESCRIPCION = EtxtTemporal

            EtxtPER_ID = EtxtTemporal
            EtxtPER_DESCRIPCION = EtxtTemporal

            EtxtCCC_ID.pBusqueda = True
            EtxtCCC_ID.pFormularioConsulta = True

            EtxtMON_ID.pBusqueda = True
            EtxtMON_ID.pFormularioConsulta = True

            EtxtCCT_ID.pBusqueda = True
            EtxtCCT_ID.pFormularioConsulta = True

            EtxtDTD_ID.pBusqueda = True
            EtxtDTD_ID.pFormularioConsulta = True

            EtxtPER_ID.pBusqueda = True
            EtxtPER_ID.pFormularioConsulta = True
        End Sub
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtCCC_ID.KeyDown, _
                txtMON_ID.KeyDown, _
                txtCCT_ID.KeyDown, _
                txtDTD_ID.KeyDown, _
                txtPER_ID.KeyDown

            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtCCC_ID"
                            TeclaF1(EtxtCCC_ID, txtCCC_ID)
                        Case "txtMON_ID"
                            TeclaF1(EtxtMON_ID, txtMON_ID)
                        Case "txtCCT_ID"
                            TeclaF1(EtxtCCT_ID, txtCCT_ID)
                        Case "txtDTD_ID"
                            TeclaF1(EtxtDTD_ID, txtDTD_ID)
                        Case "txtPER_ID"
                            TeclaF1(EtxtPER_ID, txtPER_ID)
                    End Select
            End Select
        End Sub
#End Region
#End Region
#Region "Secundaria1"
        Private Sub FormatearCampos()
            FormatearCampos(txtCCC_ID, "CCC_ID", EtxtCCC_ID)
            'FormatearCampos(txtCCC_DESCRIPCION, "CCC_DESCRIPCION", EtxtCCT_DESCRIPCION, False)
            FormatearCampos(txtMON_ID, "MON_ID", EtxtMON_ID)
            'FormatearCampos(txtMON_DESCRIPCION, "MON_DESCRIPCION", EtxtMON_DESCRIPCION, False)
            FormatearCampos(txtCCT_ID, "CCT_ID", EtxtCCT_ID)
            'FormatearCampos(txtCCT_DESCRIPCION, "CCT_DESCRIPCION", EtxtCCT_DESCRIPCION, False)
            FormatearCampos(txtDTD_ID, "DTD_ID", EtxtDTD_ID)
            'FormatearCampos(txtDTD_DESCRIPCION, "DTD_DESCRIPCION", EtxtDTD_DESCRIPCION, False)
            FormatearCampos(txtPER_ID, "PER_ID_CAJ", EtxtPER_ID)
            'FormatearCampos(txtPER_DESCRIPCION, "PER_DESCRIPCION_CAJ", EtxtPER_DESCRIPCION, False)
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object, _
                                   ByVal NombreCampo As String, _
                                   ByRef sender As txt, _
                                   Optional ByVal e As System.Boolean = True)
            FormatearCampos(oObjeto, NombreCampo, BL.vArrayDatosComboBox, BL.vElementosDatosComboBox - 1, sender, e)
        End Sub
        Private Sub FormatearCampos(ByRef oObjeto As Object, _
                                    ByVal NombreCampo As String, _
                                    ByVal vArrayDatosComboBox As Object, _
                                    ByVal vElementos As Int16, _
        ByRef sender As txt, _
        ByVal e As System.Boolean)
            For Fila = 0 To vElementos
                If vArrayDatosComboBox(Fila).NombreCampo.ToString = NombreCampo Then
                    If vArrayDatosComboBox(Fila).Tipo.ToString = "char" Or _
                    vArrayDatosComboBox(Fila).Tipo.ToString = "varchar" Then
                        If oObjeto.GetType = GetType(Windows.Forms.TextBox) Then
                            sender.pSoloNumerosDecimales = False
                            sender.pSoloNumeros = False
                            sender.pMinusculaMayuscula = True
                        End If
                        oObjeto.MaxLength = vArrayDatosComboBox(Fila).Longitud
                        If e Then oObjeto.Width = vArrayDatosComboBox(Fila).Ancho
                    End If
                    If vArrayDatosComboBox(Fila).Tipo.ToString = "int" Then
                        If oObjeto.GetType = GetType(Windows.Forms.TextBox) Then
                            sender.pSoloNumerosDecimales = False
                            sender.pSoloNumeros = True
                            sender.pMinusculaMayuscula = False
                        End If
                        oObjeto.MaxLength = vArrayDatosComboBox(Fila).Longitud
                        If e Then oObjeto.Width = vArrayDatosComboBox(Fila).Ancho
                    End If
                    If vArrayDatosComboBox(Fila).Tipo.ToString = "numeric" Then
                        If oObjeto.GetType = GetType(Windows.Forms.TextBox) Then
                            sender.pSoloNumerosDecimales = True
                            sender.pSoloNumeros = False
                            sender.pMinusculaMayuscula = False
                            sender.pParteEntera = vArrayDatosComboBox(Fila).ParteEntera
                            sender.pParteDecimal = vArrayDatosComboBox(Fila).ParteDecimal
                        End If
                        oObjeto.MaxLength = vArrayDatosComboBox(Fila).Longitud
                        If e Then oObjeto.Width = vArrayDatosComboBox(Fila).Ancho
                    End If
                    Exit For
                End If
            Next
        End Sub
        Private Sub FiltrarOrm()
            'EtxtPER_ID.pOOrm.CadenaFiltrado = ""
            'EtxtCCT_ID.pOOrm.CadenaFiltrado = ""
        End Sub
#Region "TextBox"
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtCCC_ID.GotFocus, _
                txtMON_ID.GotFocus, _
                txtCCT_ID.GotFocus, _
                txtDTD_ID.GotFocus, _
                txtPER_ID.GotFocus

            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    EtxtCCC_ID.pTexto1 = sender.text
                Case "txtMON_ID"
                    EtxtMON_ID.pTexto1 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto1 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto1 = sender.text
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtCCC_ID.LostFocus, _
                txtMON_ID.LostFocus, _
                txtCCT_ID.LostFocus, _
                txtDTD_ID.LostFocus, _
                txtPER_ID.LostFocus

            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    EtxtCCC_ID.pTexto2 = sender.text
                Case "txtMON_ID"
                    EtxtMON_ID.pTexto2 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto2 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto2 = sender.text
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtCCC_ID.Validated, _
                txtMON_ID.Validated, _
                txtCCT_ID.Validated, _
                txtDTD_ID.Validated, _
                txtPER_ID.Validated

            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    ValidarDatos(EtxtCCC_ID, txtCCC_ID)
                Case "txtMON_ID"
                    ValidarDatos(EtxtMON_ID, txtMON_ID)
                Case "txtCCT_ID"
                    ValidarDatos(EtxtCCT_ID, txtCCT_ID)
                Case "txtDTD_ID"
                    ValidarDatos(EtxtDTD_ID, txtDTD_ID)
                Case "txtPER_ID"
                    Dim vTexto As New TextBox
                    txtPER_ID.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID.Text, txtPER_ID.MaxLength)
                    vTexto.Text = txtPER_ID.Text & BCVariablesNames.TipoPersonas.Cobrador
                    ValidarDatos(EtxtPER_ID, vTexto)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtCCC_ID.KeyPress, _
                txtMON_ID.KeyPress, _
                txtCCT_ID.KeyPress, _
                txtDTD_ID.KeyPress, _
                txtPER_ID.KeyPress

            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    oKeyPress(EtxtCCC_ID, e)
                Case "txtMON_ID"
                    oKeyPress(EtxtMON_ID, e)
                Case "txtCCT_ID"
                    oKeyPress(EtxtCCT_ID, e)
                Case "txtDTD_ID"
                    oKeyPress(EtxtDTD_ID, e)
                Case "txtPER_ID"
                    oKeyPress(EtxtPER_ID, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtCCC_ID.DoubleClick, _
                txtMON_ID.DoubleClick, _
                txtCCT_ID.DoubleClick, _
                txtDTD_ID.DoubleClick, _
                txtPER_ID.DoubleClick

            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    oDoubleClick(EtxtCCC_ID, txtCCC_ID, "frmCajaCtaCte")
                Case "txtMON_ID"
                    oDoubleClick(EtxtMON_ID, txtMON_ID, "frmMoneda")
                Case "txtCCT_ID"
                    oDoubleClick(EtxtCCT_ID, txtCCT_ID, "frmCtaCte")
                Case "txtDTD_ID"
                    oDoubleClick(EtxtDTD_ID, txtDTD_ID, "frmRolOpeCtaCte")
                Case "txtPER_ID"
                    oDoubleClick(EtxtPER_ID, txtPER_ID, "frmRolPersonaTipoPersona")
            End Select
        End Sub
        Private Sub oDoubleClick(ByVal EtxtTemporal As txt, ByRef txt As TextBox, ByVal e As System.String)
            EtxtTemporal.pTexto2 = txt.Text
            ValidarDatos(EtxtTemporal, txt)
            If Trim(txt.Text) = "" Then
                Exit Sub
            End If
            Dim frmconsulta As Object = Nothing
            If EtxtTemporal.pFormularioConsulta Then
                Select Case e
                    Case "frmCajaCtaCte"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Tesoreria.Views.frmCajaCtaCte)()
                    Case "frmMoneda"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                    Case "frmCtaCte"
                        'frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                    Case "frmPersonas"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                    Case Else
                        Exit Sub
                End Select
                frmconsulta.DatoBusquedaConsulta = txt.Text
                frmconsulta.MaximizeBox = False
                frmconsulta.MinimizeBox = False
                frmconsulta.Comportamiento = -1
                frmconsulta.ShowDialog()
            End If
        End Sub
#End Region
#End Region
        Private Sub btnImprimir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
            If rbResumen.Checked Then chkFechaHora.CheckState = CheckState.Unchecked
            If rbSoloIngresos.Checked Then chkFechaHora.CheckState = CheckState.Unchecked
            If rbSoloEgresos.Checked Then chkFechaHora.CheckState = CheckState.Unchecked
            Imprimir()
        End Sub
        Private Sub Imprimir()
            ''''
            ''''

            'Me.Cursor = Cursors.WaitCursor

            Dim VFlagSubInforme As Boolean = False
            Dim VFlagcCajaCtaCte As Boolean = True
            Dim ds As New DataSet
            Dim ds1 As New DataSet

            Dim sr As New Object
            Dim sr1 As New Object

            Dim NombreProcedimiento As String
            Dim vCCC_ID As Object = Nothing
            Dim vMON_ID As Object = Nothing
            Dim vCCT_ID As Object = Nothing
            Dim vDTD_ID As Object = Nothing
            Dim vPER_ID As Object = Nothing
            Dim vFiltroProcedimiento As String = ""
            Dim vFlagFiltro As Boolean = False

            vTitulo1 = ""
            vTitulo2 = ""
            vTitulo3 = ""


            Select Case Me.Name
                Case "frmSaldoCajaBanco"
                    NombreProcedimiento = Ladisac.DA.SPNames.spMovimientoCajaBancoTotalizadosXML
                    vTitulo1 = "Saldos Caja/Banco"
                    vTitulo2 = "Tipo Caja Cta. Cte.: " & cboCCC_TIPO.Text & " - Fecha al : " & dtpFechaInicial.Text
                    'vTitulo3 = "Fecha al : " & dtpFechaInicial.Text
                    sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Text), cboCCC_TIPO.Text, vFiltroProcedimiento))
                Case Else
                    If rbSoloIngresos.Checked Then
                        vTitulo1 = "Solo ingresos Caja/Bancos"
                        NombreProcedimiento = Ladisac.DA.SPNames.spMovimientoCajaBancoSoloIngresosXML
                        NombreProcedimiento = "spMovimientoCajaBancoSoloIngresosModificadoXML"
                    ElseIf rbSoloEgresos.Checked Then
                        vTitulo1 = "Solo egresos Caja/Bancos"
                        NombreProcedimiento = Ladisac.DA.SPNames.spMovimientoCajaBancoSoloIngresosXML
                        NombreProcedimiento = "spMovimientoCajaBancoSoloEgresosModificadoXML"
                    Else
                        vTitulo1 = "Todos los movimiento Caja/Bancos"
                        If chkFechaHora.CheckState Then
                            NombreProcedimiento = Ladisac.DA.SPNames.spMovimientoCajaBancoHoraGrabacionXML
                        Else
                            If rbResumen.Checked Then
                                NombreProcedimiento = Ladisac.DA.SPNames.spMovimientoCajaBancoNuevoXML
                                NombreProcedimiento = "spMovimientoCajaBancoNuevoResumenModificado2XML"
                            Else
                                NombreProcedimiento = Ladisac.DA.SPNames.spMovimientoCajaBancoNuevoXML
                                NombreProcedimiento = "spMovimientoCajaBancoNuevoModificadoXML"
                            End If
                        End If
                    End If

                    If txtCCC_ID.Text.Trim = "" Then
                        vCCC_ID = DBNull.Value
                        vTitulo2 &= "Caja Cta. Cte.: Todas"
                    Else
                        vCCC_ID = txtCCC_ID.Text
                        vTitulo2 &= "Caja Cta. Cte.: " & txtCCT_DESCRIPCION.Text
                    End If

                    If txtMON_ID.Text.Trim = "" Then
                        vMON_ID = DBNull.Value
                        vTitulo2 &= " - Moneda: Todas"
                    Else
                        vMON_ID = txtMON_ID.Text
                        vTitulo2 &= " - Moneda: " & txtMON_SIMBOLO.Text
                        vFiltroProcedimiento = " WHERE MON_ID_CCC >= '" & vMON_ID & "' "
                        vFlagFiltro = True
                    End If

                    If txtCCT_ID.Text.Trim = "" Then
                        vCCT_ID = DBNull.Value
                        vTitulo2 &= " - Cuenta corriente: Todas"
                    Else
                        vCCT_ID = txtCCT_ID.Text
                        vTitulo2 &= " - Cuenta corriente: " & txtCCT_DESCRIPCION.Text
                    End If

                    If txtDTD_ID.Text.Trim = "" Then
                        vDTD_ID = DBNull.Value
                        vTitulo2 &= " - Tipo documento: Todos"
                    Else
                        vDTD_ID = txtDTD_ID.Text
                        vTitulo2 &= " - Tipo documento: " & txtDTD_DESCRIPCION.Text
                        If vFlagFiltro Then
                            vFiltroProcedimiento = " AND DTD_ID = '" & vDTD_ID & "' "
                        Else
                            vFiltroProcedimiento = " WHERE DTD_ID = '" & vDTD_ID & "' "
                        End If
                    End If

                    If txtPER_ID.Text.Trim = "" Then
                        vPER_ID = DBNull.Value
                        'vTitulo3 &= "Cobrador: Todos"
                        vTitulo2 &= "Cobrador: Todos"
                    Else
                        vPER_ID = txtPER_ID.Text
                        'vTitulo3 &= "Cobrador: " & txtPER_DESCRIPCION.Text
                        vTitulo2 &= "Cobrador: " & txtPER_DESCRIPCION.Text
                    End If

                    'vTitulo3 &= " - Fechas: " & dtpFechaInicial.Text & "  Al  " & dtpFechaFinal.Text
                    vTitulo2 &= " - Fechas: " & dtpFechaInicial.Text & "  Al  " & dtpFechaFinal.Text

                    If rbSoloIngresos.Checked Then
                        sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vCCC_ID, vPER_ID, dtpFechaInicial.Value, dtpFechaFinal.Value, vFiltroProcedimiento))
                    ElseIf rbSoloEgresos.Checked Then
                        sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vCCC_ID, vPER_ID, dtpFechaInicial.Value, dtpFechaFinal.Value, vFiltroProcedimiento))
                    Else
                        sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vCCC_ID, vPER_ID, dtpFechaInicial.Value, dtpFechaFinal.Value, vDTD_ID, vFiltroProcedimiento))
                    End If
            End Select

            Dim vcontrol1 As Int16

            Select Case Me.SessionService.NombreEmpresa
                Case "Ladrillera El Diamante SAC"
                    If txtCCC_ID.Text = "024" Then VFlagcCajaCtaCte = False
                Case "Comercializadora Diamante G.E. SAC"
                    If txtCCC_ID.Text = "005" Then VFlagcCajaCtaCte = False
            End Select

            If SessionService.UserId <> "ANGEL" Then
                If VFlagcCajaCtaCte Then
                    If Trim(txtCCC_TIPO.Text) <> "CUENTA DE BANCO" Then
                        sr1 = New StringReader(IBCMaestro.EjecutarVista("spVentasContadoSinPagoXML", txtPVE_ID.Text, cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Value), cMisProcedimientos.FormatoFechaGenerico(dtpFechaFinal.Value)))
                        vcontrol1 = sr1.Peek
                        If vcontrol1 <> -1 Then
                            ds1.ReadXml(sr1)
                        End If
                    End If
                End If
            End If

            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Select Case Me.Name
                    Case "frmSaldoCajaBanco"
                        oReporte = oReporte3
                        VFlagSubInforme = False
                    Case Else
                        If rbDetallado.Checked Then
                            If SessionService.UserId <> "ANGEL" Then
                                If Trim(txtCCC_TIPO.Text) <> "CUENTA DE BANCO" Then
                                    If vcontrol1 <> -1 Then
                                        If VFlagcCajaCtaCte Then
                                            If chkFechaHora.CheckState Then
                                                oReporte = oReporte9
                                            Else
                                                '' Miker
                                                If rbSoloEgresos.Checked Then
                                                    oReporte = oReporte11
                                                Else
                                                    oReporte = oReporte1
                                                End If
                                            End If
                                            '' Miker
                                            If rbSoloEgresos.Checked Then
                                                VFlagSubInforme = False
                                            Else
                                                VFlagSubInforme = True
                                            End If
                                        Else
                                            If chkFechaHora.CheckState Then
                                                oReporte = oReporte8
                                            Else
                                                oReporte = oReporte6
                                            End If
                                            VFlagSubInforme = False
                                        End If
                                    Else
                                        If chkFechaHora.CheckState Then
                                            oReporte = oReporte8
                                        Else
                                            '' Miker
                                            If rbSoloEgresos.Checked Then
                                                oReporte = oReporte10
                                            Else
                                                oReporte = oReporte6
                                            End If
                                        End If
                                        VFlagSubInforme = False
                                    End If
                                Else
                                    oReporte = oReporte4
                                    VFlagSubInforme = False
                                End If
                            Else
                                oReporte = oReporte4
                                VFlagSubInforme = False
                            End If
                            vTitulo1 += " - Detallado"
                        Else
                            If SessionService.UserId <> "ANGEL" Then
                                If Trim(txtCCC_TIPO.Text) <> "CUENTA DE BANCO" Then
                                    If vcontrol1 <> -1 Then
                                        If VFlagcCajaCtaCte Then
                                            '' Miker
                                            If rbSoloEgresos.Checked Then
                                                oReporte = oReporte10
                                                VFlagSubInforme = False
                                            Else
                                                oReporte = oReporte2
                                                VFlagSubInforme = True
                                            End If
                                        Else
                                            oReporte = oReporte7
                                            VFlagSubInforme = False
                                        End If
                                    Else
                                        '' Miker
                                        If rbSoloEgresos.Checked Then
                                            oReporte = oReporte11
                                        Else
                                            oReporte = oReporte7
                                        End If
                                        VFlagSubInforme = False
                                    End If
                                Else
                                    oReporte = oReporte5
                                    VFlagSubInforme = False
                                End If
                            Else
                                oReporte = oReporte5
                                VFlagSubInforme = False
                            End If
                            ''oReporte.DataDefinition.FormulaFields("GenerarResumen").Text = "TRUE"
                            vTitulo1 += " - Resumen"
                        End If
                End Select

                If VFlagSubInforme Then
                    oReporte.Database.Tables(0).SetDataSource(ds.Tables(0))
                    oReporte.Database.Tables(1).SetDataSource(ds1.Tables(0))
                Else
                    oReporte.Database.Tables(0).SetDataSource(ds.Tables(0))
                End If

                oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"
                oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'" & vTitulo2 & "'"
                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'" & vTitulo3 & "'"
                oReporte.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & SessionService.NombreEmpresa & "'"
                oReporte.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & SessionService.RUCEmpresa & "'"

                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Reporteador)()
                frm.Reporte(oReporte)
                frm.Show()
                frm.BringToFront()
            Else
                MsgBox("No se genero datos, reporte vacio", MsgBoxStyle.Information, Me.Text & " - Generar")
            End If

            Me.Cursor = Cursors.Default
        End Sub

        Private Sub chkFiltrarXFechas_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltrarXFechas.CheckStateChanged
            Select Case chkFiltrarXFechas.CheckState
                Case CheckState.Checked
                    'chkFiltrarXFechas.Text = "Filtrar por fechas"
                    'dtpFechaInicial.Enabled = True
                    'dtpFechaFinal.Enabled = True
                Case CheckState.Unchecked
                    'chkFiltrarXFechas.Text = "No filtrar por fechas"
                    'dtpFechaInicial.Enabled = False
                    'dtpFechaFinal.Enabled = False
                Case Else
            End Select
        End Sub
    End Class
End Namespace