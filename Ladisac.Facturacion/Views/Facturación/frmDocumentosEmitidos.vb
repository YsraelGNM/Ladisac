Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Facturacion.Views
    Public Class frmDocumentosEmitidos
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
            Public Property pMostrarDatosGrid As Boolean

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
                Dim vOrdenBusqueda As Int16
                vOrdenBusqueda = vtxt.pOrdenBusqueda
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                If vBusquedaDirecta Then
                    frm.TipoEdicion = 2
                    If pComportamiento = -1 Then
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = vDatoBusqueda
                    End If
                    frm.DatoBusqueda = vDatoBusqueda
                    vOrdenBusqueda = OrdenBusquedaDirecta(vtxt.pComportamiento, vtxt.pOrdenBusqueda)
                Else
                    frm.TipoEdicion = 1
                    frm.DatoBusqueda = ""
                End If
                frm.oOrm = vtxt.pOOrm
                frm.Comportamiento = vtxt.pComportamiento
                frm.NombreFormulario = Me
                frm.OrdenBusqueda = vOrdenBusqueda
                frm.MostrarDatosGrid = vtxt.pMostrarDatosGrid
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
                MetodoBusquedaDato("", False, EtxtTemporal)
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
        Public Property BL As Ladisac.BE.DetalleDocumentos

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        Dim vTitulo2 As String
        Dim vTitulo3 As String

        Private EtxtMON_ID As New txt
        Private EtxtMON_DESCRIPCION As New txt

        Private EtxtPVE_ID As New txt
        Private EtxtPVE_DESCRIPCION As New txt

        Private EtxtTDO_ID As New txt
        Private EtxtTDO_DESCRIPCION As New txt

        Private EtxtTIV_ID As New txt
        Private EtxtTIV_DESCRIPCION As New txt

        Private EtxtCTD_COR_SERIE As New txt

        Private EtxtPER_ID_CLI As New txt
        Private EtxtPER_DESCRIPCION_CLI As New txt

        Public Property pComportamientoFormulario As Int16

        Dim oReporte As Object
        Dim oReporte1 As New Ladisac.Facturacion.Reportes.DocumentosEmitidos
        Dim oReporte2 As New Ladisac.Facturacion.Reportes.DocumentosBVFTConSoloPromotor
        Dim oReporte3 As New Ladisac.Facturacion.Reportes.DocumentosEmitidos1
        Dim oReporte4 As New Ladisac.Facturacion.Reportes.DocumentosEmitidos2
        Dim oReporte5 As New Ladisac.Facturacion.Reportes.DocumentosEmitidos3

#Region "Clases"
        Private cMisProcedimientos As New Ladisac.MisProcedimientos
#End Region
#End Region
#Region "Secundaria"
#Region "Procedimientos asociados a los procedimientos asociados a la barra de herramientas del formulario, deben de existir"
        Private Sub LimpiarDatos()
            InicializarValores(txtMON_ID, ErrorProvider1)
            InicializarValores(txtMON_SIMBOLO, ErrorProvider1)
            InicializarValores(txtMON_DESCRIPCION, ErrorProvider1)

            InicializarValores(txtPVE_ID, ErrorProvider1)
            InicializarValores(txtPVE_DESCRIPCION, ErrorProvider1)

            InicializarValores(txtTDO_ID, ErrorProvider1)
            InicializarValores(txtTDO_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtDTD_ID, ErrorProvider1)
            InicializarValores(txtDTD_DESCRIPCION, ErrorProvider1)

            InicializarValores(txtTIV_ID, ErrorProvider1)
            InicializarValores(txtTIV_DESCRIPCION, ErrorProvider1)

            InicializarValores(txtCTD_COR_SERIE, ErrorProvider1)

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
            Dim vPVE_ID As String
            Dim vTDO_ID As String

            If Trim(txtPVE_ID.Text) = "" Then
                vPVE_ID = "%"
            Else
                vPVE_ID = txtPVE_ID.Text
            End If

            If Trim(txtTDO_ID.Text) = "" Then
                vTDO_ID = "%"
            Else
                vTDO_ID = txtTDO_ID.Text
            End If

            EtxtCTD_COR_SERIE.pOOrm.CadenaFiltrado = " And PVE_ID Like('" & vPVE_ID & _
                                                   "') And TDO_ID Like('" & vTDO_ID & "')"

        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDO_ID" Then EtxtTDO_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTIV_ID" Then EtxtTIV_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCTD_COR_SERIE" Then EtxtCTD_COR_SERIE.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI" Then EtxtPER_ID_CLI.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDO_ID" Then EtxtTDO_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTIV_ID" Then EtxtTIV_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCTD_COR_SERIE" Then EtxtCTD_COR_SERIE.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI" Then EtxtPER_ID_CLI.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function

        Private Sub frmMovimientoCajaBancos_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles Me.Load
            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                ConfigurarCheck()
                ConfigurarComboBox()
                ConfigurarText()
                AdicionarElementoCombosEdicion()
                ComportamientoFormulario()
                FormatearCampos()
                BotonesEdicion("")
                MetodoBusquedaDato(BCVariablesNames.MonedaSistema, True, EtxtMON_ID)
                Select Case pComportamientoFormulario
                    Case 100 ' Documentos emitidos
                        rbtProcesado.Enabled = False
                        rbtProcesado.Visible = False
                        grbEstadoDoc.Controls.Remove(Me.rbtProcesado)
                        grbEstadoDoc.ClientSize = New System.Drawing.Size(271, 35)
                    Case 300 ' Pedidos emitidos
                        rbtActivo.Text = "Por procesar"
                        EtxtTDO_ID.pOOrm.CadenaFiltrado = " And TDO_TABLA='DOCUMENTOS' And TDO_ID  In ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & "'," & _
                                                                              "'" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "')"

                    Case 200 ' Ventas por promotor
                        lblMON_ID.Enabled = False
                        lblMON_ID.Visible = False
                        txtMON_ID.Enabled = False
                        txtMON_ID.Visible = False
                        txtMON_SIMBOLO.Enabled = False
                        txtMON_SIMBOLO.Visible = False
                        txtMON_DESCRIPCION.Enabled = False
                        txtMON_DESCRIPCION.Visible = False

                        lblTDO_ID.Enabled = False
                        lblTDO_ID.Visible = False
                        txtTDO_ID.Enabled = False
                        txtTDO_ID.Visible = False
                        txtTDO_DESCRIPCION.Enabled = False
                        txtTDO_DESCRIPCION.Visible = False

                        chkProcesar.Enabled = False
                        chkProcesar.Visible = False
                        txtDTD_ID.Enabled = False
                        txtDTD_ID.Visible = False
                        txtDTD_DESCRIPCION.Enabled = False
                        txtDTD_DESCRIPCION.Visible = False

                        lblCTD_COR_SERIE.Enabled = False
                        lblCTD_COR_SERIE.Visible = False
                        txtCTD_COR_SERIE.Enabled = False
                        txtCTD_COR_SERIE.Visible = False

                        lblTIV_ID.Enabled = False
                        lblTIV_ID.Visible = False
                        txtTIV_ID.Enabled = False
                        txtTIV_ID.Visible = False
                        txtTIV_DESCRIPCION.Enabled = False
                        txtTIV_DESCRIPCION.Visible = False

                        lblDatos.Enabled = False
                        lblDatos.Visible = False
                        grbDatos.Enabled = False
                        grbDatos.Visible = False

                        lblEstadoDoc.Enabled = False
                        lblEstadoDoc.Visible = False
                        grbEstadoDoc.Enabled = False
                        grbEstadoDoc.Visible = False

                        lblFormato.Enabled = False
                        lblFormato.Visible = False
                        grbFormato.Enabled = False
                        grbFormato.Visible = False

                        lblDPR_TIPO_PROMOCION.Enabled = True
                        lblDPR_TIPO_PROMOCION.Visible = True

                        cboDPR_TIPO_PROMOCION.Enabled = True
                        cboDPR_TIPO_PROMOCION.Visible = True
                        cboDPR_TIPO_PROMOCION.Text = "MAESTRO CONSTRUCTOR"

                        lblFiltroPuntos.Enabled = True
                        lblFiltroPuntos.Visible = True

                        txtFiltroPuntos.Enabled = True
                        txtFiltroPuntos.Visible = True

                        lblPVE_ID.Location = New System.Drawing.Point(4, 10)
                        txtPVE_ID.Location = New System.Drawing.Point(91, 10)
                        txtPVE_DESCRIPCION.Location = New System.Drawing.Point(133, 10)

                        lblPER_ID_CLI.Text = "Promotor"
                        lblPER_ID_CLI.Location = New System.Drawing.Point(4, 34)
                        txtPER_ID_CLI.Location = New System.Drawing.Point(91, 34)
                        txtPER_DESCRIPCION_CLI.Location = New System.Drawing.Point(172, 34)

                        lblFechaInicial.Location = New System.Drawing.Point(4, 60)
                        dtpFechaInicial.Location = New System.Drawing.Point(91, 60)
                        lblFechaFinal.Location = New System.Drawing.Point(268, 60)
                        dtpFechaFinal.Location = New System.Drawing.Point(333, 60)

                        lblDPR_TIPO_PROMOCION.Location = New System.Drawing.Point(4, 86)
                        cboDPR_TIPO_PROMOCION.Location = New System.Drawing.Point(91, 86)

                        lblFiltroPuntos.Location = New System.Drawing.Point(4, 112)
                        txtFiltroPuntos.Location = New System.Drawing.Point(91, 112)


                        btnImprimir.Location = New System.Drawing.Point(91, 137) ''111

                        Me.ClientSize = New System.Drawing.Size(700, 231) '180 205
                End Select
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- Load")
            End Try
        End Sub
        Private Sub AdicionarElementoCombosEdicion()

        End Sub
        Private Sub NombresFormulariosControles()
            EtxtMON_ID.pOOrm = New Ladisac.BE.Moneda
            EtxtMON_ID.pComportamiento = 1
            EtxtMON_ID.pOrdenBusqueda = 1
            EtxtMON_ID.pMostrarDatosGrid = True

            EtxtPVE_ID.pOOrm = New Ladisac.BE.PuntoVenta
            EtxtPVE_ID.pComportamiento = 2
            EtxtPVE_ID.pOrdenBusqueda = 1
            EtxtPVE_ID.pMostrarDatosGrid = True

            If pComportamientoFormulario = 100 Or _
               pComportamientoFormulario = 200 Then
                EtxtPVE_ID.pOOrm.CadenaFiltrado = " AND PVE_ID LIKE '%%' And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
            End If


            EtxtTDO_ID.pOOrm = New Ladisac.BE.DetalleTipoDocumentos
            EtxtTDO_ID.pComportamiento = 3
            EtxtTDO_ID.pOrdenBusqueda = 3
            EtxtTDO_ID.pMostrarDatosGrid = True
            EtxtTDO_ID.pOOrm.CadenaFiltrado = " And TDO_TABLA='DOCUMENTOS' And TDO_ID  In ('" & BCVariablesNames.ProcesosFacturación.VentaBoleta & "'," & _
                                                                                          "'" & BCVariablesNames.ProcesosFacturación.VentaFactura & "'," & _
                                                                                          "'" & BCVariablesNames.ProcesosFacturación.NotaCredito & "'," & _
                                                                                          "'" & BCVariablesNames.ProcesosFacturación.NotaDebito & "')"

            EtxtTIV_ID.pOOrm = New Ladisac.BE.TipoVenta
            EtxtTIV_ID.pComportamiento = 4
            EtxtTIV_ID.pOrdenBusqueda = 1
            EtxtTIV_ID.pMostrarDatosGrid = True

            EtxtCTD_COR_SERIE.pOOrm = New Ladisac.BE.CorrelativoTipoDocumento
            EtxtCTD_COR_SERIE.pComportamiento = 5
            EtxtCTD_COR_SERIE.pOrdenBusqueda = 3
            EtxtCTD_COR_SERIE.pMostrarDatosGrid = True
            EtxtCTD_COR_SERIE.pOOrm.CadenaFiltrado = " And PVE_ID='" & txtPVE_ID.Text & _
                                                    "' And TDO_ID='" & txtTDO_ID.Text & _
                                                    "' And DTD_ID='" & txtDTD_ID.Text & "'"

            'EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.Personas
            'EtxtPER_ID_CLI.pComportamiento = 6
            'EtxtPER_ID_CLI.pOrdenBusqueda = 4
            'EtxtPER_ID_CLI.pMostrarDatosGrid = True

            EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
            EtxtPER_ID_CLI.pComportamiento = 6
            EtxtPER_ID_CLI.pOrdenBusqueda = 1
            EtxtPER_ID_CLI.pMostrarDatosGrid = True


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

            EtxtMON_ID = EtxtTemporal
            EtxtMON_DESCRIPCION = EtxtTemporal

            EtxtPVE_ID = EtxtTemporal
            EtxtPVE_DESCRIPCION = EtxtTemporal

            EtxtTDO_ID = EtxtTemporal
            EtxtTDO_DESCRIPCION = EtxtTemporal

            EtxtTIV_ID = EtxtTemporal
            EtxtTIV_DESCRIPCION = EtxtTemporal

            EtxtCTD_COR_SERIE = EtxtTemporal

            EtxtPER_ID_CLI = EtxtTemporal
            EtxtPER_DESCRIPCION_CLI = EtxtTemporal

            EtxtMON_ID.pBusqueda = True
            EtxtMON_ID.pFormularioConsulta = True

            EtxtPVE_ID.pBusqueda = True
            EtxtPVE_ID.pFormularioConsulta = True

            EtxtTDO_ID.pBusqueda = True
            EtxtTDO_ID.pFormularioConsulta = True

            EtxtTIV_ID.pBusqueda = True
            EtxtTIV_ID.pFormularioConsulta = True

            EtxtCTD_COR_SERIE.pBusqueda = True
            EtxtCTD_COR_SERIE.pFormularioConsulta = True

            EtxtPER_ID_CLI.pBusqueda = True
            EtxtPER_ID_CLI.pFormularioConsulta = True

        End Sub
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtMON_ID.KeyDown, _
                txtPVE_ID.KeyDown, _
                txtTDO_ID.KeyDown, _
                txtTIV_ID.KeyDown, _
                txtCTD_COR_SERIE.KeyDown, _
                txtPER_ID_CLI.KeyDown
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtMON_ID"
                            TeclaF1(EtxtMON_ID, txtMON_ID)
                        Case "txtPVE_ID"
                            TeclaF1(EtxtPVE_ID, txtPVE_ID)
                        Case "txtTDO_ID"
                            TeclaF1(EtxtTDO_ID, txtTDO_ID)
                        Case "txtTIV_ID"
                            TeclaF1(EtxtTIV_ID, txtTIV_ID)
                        Case "txtCTD_COR_SERIE"
                            TeclaF1(EtxtCTD_COR_SERIE, txtCTD_COR_SERIE)
                        Case "txtPER_ID_CLI"
                            TeclaF1(EtxtPER_ID_CLI, txtPER_ID_CLI)
                    End Select
            End Select
        End Sub
#End Region
#End Region
#Region "Secundaria1"
        Private Sub FormatearCampos()
            FormatearCampos(txtMON_ID, "MON_ID", EtxtMON_ID)
            FormatearCampos(txtPVE_ID, "PVE_ID", EtxtPVE_ID)
            FormatearCampos(txtTDO_ID, "TDO_ID", EtxtTDO_ID)
            FormatearCampos(txtTDO_ID, "DTD_ID", EtxtTDO_ID)
            FormatearCampos(txtTIV_ID, "TIV_ID", EtxtTIV_ID)
            FormatearCampos(txtCTD_COR_SERIE, "CTD_COR_SERIE", EtxtCTD_COR_SERIE)
            FormatearCampos(txtPER_ID_CLI, "PER_ID", EtxtPER_ID_CLI)
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
            'EtxtPVE_ID.pOOrm.CadenaFiltrado = ""
            'EtxtPVE_ID.pOOrm.CadenaFiltrado = ""
        End Sub
#Region "TextBox"
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtMON_ID.GotFocus, _
                txtPVE_ID.GotFocus, _
                txtTDO_ID.GotFocus, _
                txtTIV_ID.GotFocus, _
                txtCTD_COR_SERIE.GotFocus, _
                txtPER_ID_CLI.GotFocus

            Select Case sender.name.ToString
                Case "txtMON_ID"
                    EtxtMON_ID.pTexto1 = sender.text
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto1 = sender.text
                Case "txtTDO_ID"
                    EtxtTDO_ID.pTexto1 = sender.text
                Case "txtTIV_ID"
                    EtxtTIV_ID.pTexto1 = sender.text
                Case "txtCTD_COR_SERIE"
                    EtxtCTD_COR_SERIE.pTexto1 = sender.text
                Case "txtPER_ID_CLI"
                    EtxtPER_ID_CLI.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtMON_ID.LostFocus, _
                txtPVE_ID.LostFocus, _
                txtTDO_ID.LostFocus, _
                txtTIV_ID.LostFocus, _
                txtCTD_COR_SERIE.LostFocus, _
                txtPER_ID_CLI.LostFocus

            Select Case sender.name.ToString
                Case "txtMON_ID"
                    EtxtMON_ID.pTexto2 = sender.text
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto2 = sender.text
                Case "txtTDO_ID"
                    EtxtTDO_ID.pTexto2 = sender.text
                Case "txtTIV_ID"
                    EtxtTIV_ID.pTexto2 = sender.text
                Case "txtCTD_COR_SERIE"
                    EtxtCTD_COR_SERIE.pTexto2 = sender.text
                Case "txtPER_ID_CLI"
                    EtxtPER_ID_CLI.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtMON_ID.Validated, _
                txtPVE_ID.Validated, _
                txtTDO_ID.Validated, _
                txtTIV_ID.Validated, _
                txtCTD_COR_SERIE.Validated, _
                txtPER_ID_CLI.Validated

            Select Case sender.name.ToString
                Case "txtMON_ID"
                    ValidarDatos(EtxtMON_ID, txtMON_ID)
                Case "txtPVE_ID"
                    ValidarDatos(EtxtPVE_ID, txtPVE_ID)
                Case "txtTDO_ID"
                    ValidarDatos(EtxtTDO_ID, txtTDO_ID)
                Case "txtTIV_ID"
                    ValidarDatos(EtxtTIV_ID, txtTIV_ID)
                Case "txtCTD_COR_SERIE"
                    ValidarDatos(EtxtCTD_COR_SERIE, txtCTD_COR_SERIE)
                Case "txtPER_ID_CLI"
                    txtPER_ID_CLI.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_CLI.Text, 6)
                    ValidarDatos(EtxtPER_ID_CLI, txtPER_ID_CLI)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtMON_ID.KeyPress, _
                txtPVE_ID.KeyPress, _
                txtTDO_ID.KeyPress, _
                txtTIV_ID.KeyPress, _
                txtCTD_COR_SERIE.KeyPress, _
                txtPER_ID_CLI.KeyPress

            Select Case sender.name.ToString
                Case "txtMON_ID"
                    oKeyPress(EtxtMON_ID, e)
                Case "txtPVE_ID"
                    oKeyPress(EtxtPVE_ID, e)
                Case "txtTDO_ID"
                    oKeyPress(EtxtTDO_ID, e)
                Case "txtTIV_ID"
                    oKeyPress(EtxtTIV_ID, e)
                Case "txtCTD_COR_SERIE"
                    oKeyPress(EtxtCTD_COR_SERIE, e)
                Case "txtPER_ID_CLI"
                    oKeyPress(EtxtPER_ID_CLI, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtMON_ID.DoubleClick, _
                txtPVE_ID.DoubleClick, _
                txtTDO_ID.DoubleClick, _
                txtTIV_ID.DoubleClick, _
                txtCTD_COR_SERIE.DoubleClick, _
                txtPER_ID_CLI.DoubleClick

            Select Case sender.name.ToString
                Case "txtMON_ID"
                    oDoubleClick(EtxtMON_ID, txtMON_ID, "frmMoneda")
                Case "txtPVE_ID"
                    oDoubleClick(EtxtPVE_ID, txtPVE_ID, "frmPuntoVenta")
                Case "txtTDO_ID"
                    oDoubleClick(EtxtTDO_ID, txtTDO_ID, "frmTipoDocumentos")
                Case "txtTIV_ID"
                    oDoubleClick(EtxtTIV_ID, txtTIV_ID, "frmTipoVenta")
                Case "txtCTD_COR_SERIE"
                    oDoubleClick(EtxtCTD_COR_SERIE, txtCTD_COR_SERIE, "frmCorrelativoTipoDocumento")
                Case "txtPER_ID_CLI"
                    oDoubleClick(EtxtPER_ID_CLI, txtPER_ID_CLI, "frmPersonas")
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
                    Case "frmMoneda"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                    Case "frmPuntoVenta"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPuntoVenta)()
                    Case "frmTipoDocumentos"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmTipoDocumentos)()
                    Case "frmTipoVenta"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.CuentasCorrientes.Views.frmTipoVenta)()
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
            Select Case pComportamientoFormulario
                Case 100
                    If IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTEDOCUMENTOVENTASEMITIDOS", "PVE_ID") Then
                    Else
                        If txtPVE_ID.Text.Trim = "" Then
                            MsgBox("¡Debe ingresar un punto de venta!", MsgBoxStyle.Information, Me.Text)
                            Exit Sub
                        End If
                    End If
                Case 200
                    If IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTEDOCUMENTOVENTASEMITIDOSPORPROMOTOR", "PVE_ID") Then
                    Else
                        If txtPVE_ID.Text.Trim = "" Then
                            MsgBox("¡Debe ingresar un punto de venta!", MsgBoxStyle.Information, Me.Text)
                            Exit Sub
                        End If
                    End If
            End Select
            Imprimir()
        End Sub
        Private Sub Imprimir()
            'Me.Cursor = Cursors.WaitCursor
            Dim ds As New DataSet

            Dim NombreProcedimiento As String
            Select Case pComportamientoFormulario
                Case 100, 300 ' Documentos emitidos, Pedidos emitidos
                    NombreProcedimiento = Ladisac.DA.SPNames.spDocumentosEmitidosNuevoXML
                    If rbtFormato1.Checked Then
                        oReporte = oReporte1
                    ElseIf rbtFormato2.Checked Then
                        oReporte = oReporte3
                    ElseIf rbtFormato3.Checked Then
                        oReporte = oReporte4
                    Else
                        oReporte = oReporte5
                    End If

                Case 200 ' Ventas por promotor
                    NombreProcedimiento = Ladisac.DA.SPNames.spDocumentosBVFTConPromotorDiamanteDistribuidoraXML 'Ladisac.DA.SPNames.spDocumentosBVFTConPromotorXML
                    oReporte = oReporte2
                    oReporte.DataDefinition.FormulaFields("MontoPuntosLimite").Text = "'" & txtFiltroPuntos.Text & "'"
            End Select

            Dim vMON_ID As Object = Nothing
            Dim vPVE_ID As Object = Nothing
            Dim vTDO_ID As Object = Nothing
            Dim vDTD_ID As Object = Nothing
            Dim vCTD_COR_SERIE As Object = Nothing
            Dim vTIV_ID As Object = Nothing
            Dim vPER_ID_CLI As Object = Nothing

            Dim vFiltroProcedimiento As String = " "

            vTitulo2 = ""
            vTitulo3 = ""

            If txtMON_ID.Text.Trim = "" Then
                vMON_ID = DBNull.Value
                vTitulo2 &= "Moneda: Todas"
            Else
                vMON_ID = txtMON_ID.Text
                vTitulo2 &= "Moneda: " & txtMON_SIMBOLO.Text
            End If

            If txtPVE_ID.Text.Trim = "" Then
                vPVE_ID = DBNull.Value
                vTitulo2 &= "  -  Punto de venta: Todas"
            Else
                vPVE_ID = txtPVE_ID.Text
                vTitulo2 &= "  -  Punto de venta: " & txtPVE_DESCRIPCION.Text
            End If

            If txtTDO_ID.Text.Trim = "" Then
                vTDO_ID = DBNull.Value
                vTitulo3 &= "Tipo documento: Todas"
            Else
                vTDO_ID = txtTDO_ID.Text
                vTitulo3 &= "Tipo documento: " & txtTDO_DESCRIPCION.Text
            End If

            If txtDTD_ID.Text.Trim = "" Then
                vDTD_ID = DBNull.Value
                vTitulo3 &= " (Todas) "
            Else
                If chkProcesar.CheckState Then
                    vDTD_ID = txtDTD_ID.Text
                    vTitulo3 &= " (" & txtDTD_DESCRIPCION.Text & ") "
                Else
                    vDTD_ID = DBNull.Value
                    vTitulo3 &= " (Todas) "
                End If
            End If

            If txtTIV_ID.Text.Trim = "" Then
                vTIV_ID = DBNull.Value
                vTitulo3 &= "  -  Tipo de venta: Todas"
            Else
                vTIV_ID = txtTIV_ID.Text
                vTitulo3 &= "  -  Tipo de venta: " & txtTIV_DESCRIPCION.Text
            End If

            vTitulo3 &= "  -  Fechas: " & dtpFechaInicial.Text & "  Al  " & dtpFechaFinal.Text
            vFiltroProcedimiento = " WHERE (CAST(DOC_FECHA_EMI AS DATE) >= '" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Value) & "' and CAST(DOC_FECHA_EMI AS DATE) <='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaFinal.Value) & "')"

            If txtCTD_COR_SERIE.Text.Trim = "" Then
                vCTD_COR_SERIE = DBNull.Value
                vTitulo3 &= "  -  Serie: Todas"
            Else
                vCTD_COR_SERIE = txtCTD_COR_SERIE.Text
                vTitulo3 &= "  -  Serie: " & txtCTD_COR_SERIE.Text
                vFiltroProcedimiento &= " AND DOC_SERIE = '" & vCTD_COR_SERIE & "'"
            End If

            Select Case pComportamientoFormulario
                Case 200
                    vTitulo2 &= " - Promocion: " & cboDPR_TIPO_PROMOCION.Text
                    If txtPER_ID_CLI.Text.Trim = "" Then
                        vPER_ID_CLI = DBNull.Value
                        vTitulo2 &= "  -  Promotor: Todos"
                    Else
                        vPER_ID_CLI = txtPER_ID_CLI.Text
                        vTitulo2 &= "  -  Promotor: " & txtPER_DESCRIPCION_CLI.Text
                        vFiltroProcedimiento &= " AND PER_ID_PRO = '" & vPER_ID_CLI & "'"
                    End If
                Case Else
                    If txtPER_ID_CLI.Text.Trim = "" Then
                        vPER_ID_CLI = DBNull.Value
                        vTitulo2 &= "  -  " & lblPER_ID_CLI.Text & ": Todos"
                    Else
                        vPER_ID_CLI = txtPER_ID_CLI.Text
                        vTitulo2 &= "  -  " & lblPER_ID_CLI.Text & ": " & txtPER_DESCRIPCION_CLI.Text
                        If rbtCliente.Checked Then
                            vFiltroProcedimiento &= " AND PER_ID_CLI = '" & vPER_ID_CLI & "'"
                        ElseIf rbtVendedor.Checked Then
                            vFiltroProcedimiento &= " AND PER_ID_VEN = '" & vPER_ID_CLI & "'"
                        Else
                            vFiltroProcedimiento &= " AND (PER_ID_CLI = '" & vPER_ID_CLI & "' OR PER_ID_GRU = '" & vPER_ID_CLI & "')"
                        End If

                    End If
            End Select


            Dim sr As Object
            Select Case pComportamientoFormulario
                Case 100 ' Documentos emitidos
                    If rbtTodos.Checked Then
                        vTitulo2 &= "  -  Estado Doc.: " & rbtTodos.Text
                        vFiltroProcedimiento &= " And TDO_ID  In ('" & BCVariablesNames.ProcesosFacturación.VentaBoleta & "'," & _
                                         "'" & BCVariablesNames.ProcesosFacturación.VentaFactura & "'," & _
                                         "'" & BCVariablesNames.ProcesosFacturación.NotaCredito & "'," & _
                                         "'" & BCVariablesNames.ProcesosFacturación.NotaDebito & "')"
                    ElseIf rbtActivo.Checked Then
                        vTitulo2 &= "  -  Estado Doc.: " & rbtActivo.Text
                        vFiltroProcedimiento &= " And TDO_ID  In ('" & BCVariablesNames.ProcesosFacturación.VentaBoleta & "'," & _
                                                                 "'" & BCVariablesNames.ProcesosFacturación.VentaFactura & "'," & _
                                                                 "'" & BCVariablesNames.ProcesosFacturación.NotaCredito & "'," & _
                                                                 "'" & BCVariablesNames.ProcesosFacturación.NotaDebito & "') " & _
                                                " AND DOC_ESTADO='ACTIVO'"
                    Else
                        vTitulo2 &= "  -  Estado Doc.: " & rbtNoActivo.Text
                        vFiltroProcedimiento &= " And TDO_ID  In ('" & BCVariablesNames.ProcesosFacturación.VentaBoleta & "'," & _
                                                                 "'" & BCVariablesNames.ProcesosFacturación.VentaFactura & "'," & _
                                                                 "'" & BCVariablesNames.ProcesosFacturación.NotaCredito & "'," & _
                                                                 "'" & BCVariablesNames.ProcesosFacturación.NotaDebito & "') " & _
                                                " AND DOC_ESTADO='NO ACTIVO'"
                    End If
                    sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vMON_ID, vPVE_ID, vTDO_ID, vDTD_ID, vTIV_ID, vFiltroProcedimiento))
                Case 200 ' Ventas por promotor
                    vFiltroProcedimiento &= " And DTD_ID  In ('" & BCVariablesNames.ProcesosFacturación.Boleta & "'," & _
                                                             "'" & BCVariablesNames.ProcesosFacturación.Factura & "') "

                    ''vFiltroProcedimiento &= " And TDO_ID+DTD_ID+DOC_SERIE+DOC_NUMERO not in (Select TDO_ID_DOC + DTD_ID_DOC + DDP_SERIE_DOC + DDP_NUMERO_DOC FROM vwDetalleDocumentosPromocion where dpr_estado='ACTIVO' and ddp_estado='ACTIVO') "

                    If cboDPR_TIPO_PROMOCION.Text = "MAESTRO PROMOTOR" Then
                    ElseIf cboDPR_TIPO_PROMOCION.Text = "PROMOCION ECO DIAMANTE" Then
                        vFiltroProcedimiento &= " and ART_ID_IMP in ('020276') and PER_ID_PRO in (SELECT PER_ID FROM MAE.PersonasPromocion where tipo_promocion=1 and pep_estado=1)"
                    End If

                    sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vPER_ID_CLI, vPVE_ID, cboDPR_TIPO_PROMOCION.Text, vFiltroProcedimiento))
                Case 300 ' Pedidos emitidos
                    If rbtTodos.Checked Then
                        vTitulo2 &= "  -  Estado Doc.: " & rbtTodos.Text
                        vFiltroProcedimiento &= " And TDO_ID  In ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & "'," & _
                                         "'" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "')"
                    ElseIf rbtActivo.Checked Then
                        vTitulo2 &= "  -  Estado Doc.: " & rbtActivo.Text
                        vFiltroProcedimiento &= " And TDO_ID  In ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & "'," & _
                                                                 "'" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "') " & _
                                                " AND DOC_ESTADO='POR PROCESAR'"
                    ElseIf rbtNoActivo.Checked Then
                        vTitulo2 &= "  -  Estado Doc.: " & rbtNoActivo.Text
                        vFiltroProcedimiento &= " And TDO_ID  In ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & "'," & _
                                                                 "'" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "') " & _
                                                " AND DOC_ESTADO='NO ACTIVO'"
                    Else
                        vTitulo2 &= "  -  Estado Doc.: " & rbtProcesado.Text
                        vFiltroProcedimiento &= " And TDO_ID  In ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & "'," & _
                                                                 "'" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "') " & _
                                                " AND DOC_ESTADO='PROCESADO'"
                    End If
                    sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vMON_ID, vPVE_ID, vTDO_ID, vDTD_ID, vTIV_ID, vFiltroProcedimiento))
            End Select

            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                If rbtResumen.Checked Then
                    oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                    oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'Documentos Emitidos  -  Resumen'"
                Else
                    oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "False"
                    oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'Documentos Emitidos  -  Detalle'"
                End If

                If rbtCliente.Checked Then
                    oReporte.DataDefinition.FormulaFields("TipoPersona").Text = "'CLIENTE'"
                ElseIf rbtVendedor.Checked Then
                    oReporte.DataDefinition.FormulaFields("TipoPersona").Text = "'VENDEDOR'"
                Else
                    oReporte.DataDefinition.FormulaFields("TipoPersona").Text = "'GRUPO'"
                End If

                Select Case pComportamientoFormulario
                    Case 200
                        vTitulo2 &= " - Puntos >= " & txtFiltroPuntos.Text
                End Select

                oReporte.Database.Tables(0).SetDataSource(ds.Tables(0))
                oReporte.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & SessionService.NombreEmpresa & "'"
                oReporte.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & SessionService.RUCEmpresa & "'"
                oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'" & vTitulo2 & "'"
                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'" & vTitulo3 & "'"

                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Reporteador)()
                frm.Reporte(oReporte)
                frm.Show()
                frm.BringToFront()
            Else
                MsgBox("No se genero datos, reporte vacio", MsgBoxStyle.Information, Me.Text & " - Generar")
            End If
            Me.Cursor = Cursors.Default
        End Sub

        Private Sub chkProcesar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProcesar.CheckedChanged
            If chkProcesar.CheckState Then
                chkProcesar.Text = "Procesar"
            Else
                chkProcesar.Text = "No procesar"
            End If
        End Sub

        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 1, 2, 3, 4, 5, 6
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function

        Private Sub rbtCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtCliente.Click
            lblPER_ID_CLI.Text = "Cliente"
        End Sub

        Private Sub rbtVendedor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtVendedor.Click
            lblPER_ID_CLI.Text = "Vendedor"
        End Sub

        Private Sub rbtGrupo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtGrupo.Click
            lblPER_ID_CLI.Text = "Grupo"
        End Sub

        Private Sub txtFiltroPuntos_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFiltroPuntos.Validating
            If Not IsNumeric(sender.text) Then
                sender.text = 0
            Else
                If sender.text < 0 Then
                    sender.text = 0
                End If
            End If
        End Sub
    End Class
End Namespace