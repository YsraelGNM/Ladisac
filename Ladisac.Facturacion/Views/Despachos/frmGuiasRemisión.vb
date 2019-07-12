Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Despachos.Views
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class frmGuiasRemision
#Region "Primaria"
#Region "Declaraciones"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        <Dependency()>
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        Private pLoaded As Boolean = True
        Private pColeccionDatos As Collection = Nothing
        Private pComportamiento As Int32 = 0
        Private pOrdenBusqueda As Int32 = 0
        Private pDatoBusquedaConsulta As String = ""

        Public Property pComportamientoFormulario As Int16

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
            Get
                Return pAgregar
            End Get
            Set(ByVal value As Boolean)
                pAgregar = value
            End Set
        End Property
        Public Property Quitar() As Boolean
            Get
                Return pQuitar
            End Get
            Set(ByVal value As Boolean)
                pQuitar = value
            End Set
        End Property
        Public Property Salida() As Boolean
            Get
                Return pSalida
            End Get
            Set(ByVal value As Boolean)
                pSalida = value
            End Set
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

        Private Sub frm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
            If pnCuerpo.Enabled = True Then
                MyBase.OnClosing(e)
            End If
        End Sub

        Private Sub Reporte_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
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

        Private Sub Reporte_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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
        Dim vTitulo1 As String
        Dim vTitulo2 As String
        Dim vTitulo3 As String

        Private EtxtDTD_ID As New txt
        Private EtxtDTD_DESCRIPCION As New txt
        Private EtxtPER_ID_TRA As New txt
        Private EtxtPER_DESCRIPCION_TRA As New txt

        Public Property pComportameintoFormulario As Int16

        Dim oReporte1 As New GuiasRemisionParaTransportista
        Dim oReporte2 As New GuiasRemisionParaTransportistaGrafica
        Dim oReporte3 As New GuiasRemisionParaTransportistaGraficaEstadistica
        Dim oReporte As Object

#Region "Clases"
        Private Reporte As New Ladisac.BE.DetalleTipoDocumentos
        Private Reporte1 As New Ladisac.BE.Personas

        Private cMisProcedimientos As New Ladisac.MisProcedimientos
#End Region
#End Region
#Region "Secundaria"
#Region "Procedimientos asociados a los procedimientos asociados a la barra de herramientas del formulario, deben de existir"
        Private Sub LimpiarDatos()
            InicializarValores(txtPER_ID_TRA, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_TRA, ErrorProvider1)
            InicializarValores(dtpFechaInicial, ErrorProvider1)
            InicializarValores(dtpFechaFinal, ErrorProvider1)
            InicializarValores(txtDTD_ID, ErrorProvider1)
            InicializarValores(txtDTD_DESCRIPCION, ErrorProvider1)
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
            'Dim resp As New RespuestaValidar
            'vrM = True
            'vrO = True
            'Select Case vModelos
            '    Case "Cabecera"
            '        resp.rM = Simple.ColocarErrores(txtCAF_ID, Simple.VerificarDatos("CAF_ID"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(cboCAF_TIPO_DOC, Simple.VerificarDatos("CAF_TIPO_DOC"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(dtpCAF_FECHA_EMI, Simple.VerificarDatos("CAF_FECHA_EMI"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(dtpCAF_FECHA_VEN, Simple.VerificarDatos("CAF_FECHA_VEN"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(txtCAF_DIAS_VEN, Simple.VerificarDatos("CAF_DIAS_VEN"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(txtCAF_NUMERO, Simple.VerificarDatos("CAF_NUMERO"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(txtMON_ID, Simple.VerificarDatos("MON_ID"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(txtCAF_MONTO, Simple.VerificarDatos("CAF_MONTO"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(txtPER_ID, Simple.VerificarDatos("PER_ID"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(txtCAF_IX_NUMERO_PRO, Simple.VerificarDatos("CAF_IX_NUMERO_PRO"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(txtCAF_IX_ORDEN_COM, Simple.VerificarDatos("CAF_IX_ORDEN_COM"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(cboCAF_ESTADO_DOC, Simple.VerificarDatos("CAF_ESTADO_DOC"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(txtCAF_OBSERVACIONES, Simple.VerificarDatos("CAF_OBSERVACIONES"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(pnCuerpo, Simple.VerificarDatos("USU_ID"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(btnImagen, Simple.VerificarDatos("CAF_FEC_GRAB"), ErrorProvider1)
            '        resp.rM = Simple.ColocarErrores(chkCAF_ESTADO, Simple.VerificarDatos("CAF_ESTADO"), ErrorProvider1)
            'End Select
            'Return vrO
        End Function

        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            Select Case vComportamiento
                Case 1 ' Personas - Transportista
                Case 2 ' DetalleTipoDocumentos
            End Select
        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_TRA" Then EtxtPER_ID_TRA.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_TRA" Then EtxtPER_ID_TRA.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function

        Private Sub frmReporteKardex_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                oReporte = oReporte2
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- Load")
            End Try
        End Sub
        Private Sub AdicionarElementoCombosEdicion()

        End Sub
        Private Sub NombresFormulariosControles()
            EtxtPER_ID_TRA.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_TRA.pComportamiento = 1
            EtxtPER_ID_TRA.pOrdenBusqueda = 4
            EtxtPER_ID_TRA.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_TRANSPORTISTA='SI' and TPE_TRANSPORTISTA='SI')"

            EtxtDTD_ID.pOOrm = New Ladisac.BE.DetalleTipoDocumentos
            EtxtDTD_ID.pComportamiento = 2
            EtxtDTD_ID.pOrdenBusqueda = 2
            EtxtDTD_ID.pOOrm.CadenaFiltrado = " and TDO_ID='" & BCVariablesNames.ProcesosDespacho.Guia & "' and DTD_ESTADO='ACTIVO'"
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
            EchkTemporal.pSimple = Reporte
            EchkTemporal.pValorDefault = CheckState.Checked
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case ""
            End Select
            DevolverTiposCampos = Reporte.DevolverTiposCampos()
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

            EtxtDTD_ID = EtxtTemporal
            EtxtPER_ID_TRA = EtxtTemporal

            EtxtDTD_ID.pBusqueda = True
            EtxtDTD_ID.pFormularioConsulta = True

            EtxtPER_ID_TRA.pBusqueda = True
            EtxtPER_ID_TRA.pFormularioConsulta = True
        End Sub
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtPER_ID_TRA.KeyDown, _
                txtDTD_ID.KeyDown
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtDTD_ID"
                            TeclaF1(EtxtDTD_ID, txtDTD_ID)
                        Case "txtPER_ID_TRA"
                            TeclaF1(EtxtPER_ID_TRA, txtPER_ID_TRA)
                    End Select
            End Select
        End Sub
#End Region
#End Region
#Region "Secundaria1"
        Private Sub FormatearCampos()
            FormatearCampos(txtDTD_ID, "DTD_ID", EtxtDTD_ID)
            FormatearCampos(txtDTD_DESCRIPCION, "DTD_DESCRIPCION", EtxtDTD_ID, False)
            FormatearCampos(txtPER_ID_TRA, "PER_ID", EtxtPER_ID_TRA)
            FormatearCampos(txtPER_DESCRIPCION_TRA, "PER_DESCRIPCION", EtxtPER_ID_TRA, False)
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object, _
                                   ByVal NombreCampo As String, _
                                   ByRef sender As txt,
                                   Optional ByVal e As System.Boolean = True)
            FormatearCampos(oObjeto, NombreCampo, _
                            sender.pOOrm.vArrayDatosComboBox, _
                            sender.pOOrm.vElementosDatosComboBox - 1, sender, e)
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
        End Sub
#Region "TextBox"
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID_TRA.GotFocus, _
                txtDTD_ID.GotFocus

            Select Case sender.name.ToString
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto1 = sender.text
                Case "txtPER_ID_TRA"
                    EtxtPER_ID_TRA.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID_TRA.LostFocus, _
                txtDTD_ID.LostFocus

            Select Case sender.name.ToString
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto2 = sender.text
                Case "txtPER_ID_TRA"
                    EtxtPER_ID_TRA.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID_TRA.Validated, _
                txtDTD_ID.Validated

            Select Case sender.name.ToString
                Case "txtDTD_ID"
                    ValidarDatos(EtxtDTD_ID, txtDTD_ID)
                Case "txtPER_ID_TRA"
                    txtPER_ID_TRA.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_TRA.Text, txtPER_ID_TRA.MaxLength)
                    ValidarDatos(EtxtPER_ID_TRA, txtPER_ID_TRA)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtPER_ID_TRA.KeyPress, _
                txtDTD_ID.KeyPress

            Select Case sender.name.ToString
                Case "txtDTD_ID"
                    oKeyPress(EtxtDTD_ID, e)
                Case "txtPER_ID_TRA"
                    oKeyPress(EtxtPER_ID_TRA, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID_TRA.DoubleClick, _
                txtDTD_ID.DoubleClick
            Select Case sender.name.ToString
                Case "txtDTD_ID"
                    oDoubleClick(EtxtDTD_ID, txtDTD_ID, "frmTipoDocumentos")
                Case "txtPER_ID_TRA"
                    oDoubleClick(EtxtPER_ID_TRA, txtPER_ID_TRA, "frmPersonas")
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
                    Case "frmTipoDocumentos"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmTipoDocumentos)()
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
            'If Trim(txtPER_ID_TRA.Text) <> "" Then
            'MsgBox("No debe ingresar un código de transportista", MsgBoxStyle.Information, Me.Text)
            'Exit Sub
            'End If
            Imprimir()
        End Sub
        Private Function RetornarDatoBusqueda(ByVal vCadena As String, Optional ByVal vFlagValorLogico As Boolean = True)
            RetornarDatoBusqueda = ""
            If vCadena.Trim = "" Then
                If vFlagValorLogico Then
                    RetornarDatoBusqueda = "%"
                Else
                    RetornarDatoBusqueda = DBNull.Value
                End If
            Else
                RetornarDatoBusqueda = vCadena
            End If
        End Function
        Private Sub Imprimir()
            'Me.Cursor = Cursors.WaitCursor
            Dim ds As New DataSet

            Dim NombreProcedimiento As String = Ladisac.DA.SPNames.spVistaDespachosParaTransportistaXML
            Dim vDTD_ID As Object = Nothing
            'Dim vPER_ID_TRA As Object = Nothing

            Dim vFiltroProcedimiento As String = ""

            vTitulo1 = ""
            vTitulo2 = ""
            vTitulo3 = ""

            vDTD_ID = RetornarDatoBusqueda(txtDTD_ID.Text.Trim, False)

            If txtDTD_ID.Text.Trim = "" Then
                vTitulo1 &= "   -   DOCUMENTO : TODOS"
            Else
                vTitulo1 &= "   -   DOCUMENTO : " & txtDTD_DESCRIPCION.Text
            End If

            vTitulo2 &= " Fechas : " & dtpFechaInicial.Text & "  Al  " & dtpFechaFinal.Text

            If txtPER_ID_TRA.Text.Trim = "" Then
                vTitulo3 &= "   -   " & lblPER_ID_TRA.Text & " : TODAS"
            Else
                vTitulo3 &= "   -   " & lblPER_ID_TRA.Text & " : " & txtPER_DESCRIPCION_TRA.Text & " - RUC : " & txtPER_RUC_TRA.Text
            End If

            If rbListado.Checked Then
                oReporte = oReporte1
            ElseIf rbGrafico.Checked Then
                oReporte = oReporte2
            Else
                NombreProcedimiento = "dbo.spVistaDespachosParaTransportista1XML" ''Ladisac.DA.SPNames.spVistaDespachosParaTransportistaXML
                oReporte = oReporte3
            End If

            If Trim(txtPER_ID_TRA.Text) = "" Then
                If chkPropios.Checked Then
                    vFiltroProcedimiento = " AND PER_ID_TRA1 In('" & BCVariablesNames.TransportistasPropios.ComercialAceHome & "','" & BCVariablesNames.TransportistasPropios.Exodo & "','" & "','" & BCVariablesNames.TransportistasPropios.Extrames & "','" & BCVariablesNames.TransportistasPropios.TransportesKala & "','" & BCVariablesNames.TransportistasPropios.TransportesGeminis & "') "
                Else
                    vFiltroProcedimiento = " AND PER_ID_TRA1 NOT In('" & BCVariablesNames.TransportistasPropios.ComercialAceHome & "','" & BCVariablesNames.TransportistasPropios.Exodo & "','" & "','" & BCVariablesNames.TransportistasPropios.Extrames & "','" & BCVariablesNames.TransportistasPropios.TransportesKala & "','" & BCVariablesNames.TransportistasPropios.TransportesGeminis & "') "
                End If
            End If

            oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"
            oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'" & vTitulo2 & "'"
            oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'" & vTitulo3 & "'"


            Dim sr As Object
            sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, dtpFechaInicial.Value, dtpFechaFinal.Value, txtPER_ID_TRA.Text, vDTD_ID, vFiltroProcedimiento))

            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                dgvDatos.DataSource = ds.Tables(0)
                oReporte.Database.Tables(0).SetDataSource(ds.Tables(0))
                oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'" & vTitulo2 & "'"
                oReporte.DataDefinition.FormulaFields("Titulo3").Text = "'" & vTitulo3 & "'"
                oReporte.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & Me.SessionService.NombreEmpresa & "'"
                oReporte.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & Me.SessionService.RUCEmpresa & "'"
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Reporteador)()
                frm.Text = Me.Text
                frm.lblTitle.Text = Me.Text
                frm.Reporte(oReporte)
                frm.Show()
                frm.BringToFront()
            Else
                MsgBox("No se genero datos, reporte vacio", MsgBoxStyle.Information, Me.Text & " - Generar")
            End If
            Me.Cursor = Cursors.Default
        End Sub

        Function Formatos(ByVal vCadena As String, ByVal vValor As Object)
            Select Case vCadena
                Case "System.String"
                    Return vValor.ToString
                Case "System.DateTime"
                    Return CDate(vValor)
                Case "System.Int32"
                    Return Val(vValor)
                Case "System.Double"
                    Return CDbl(vValor)
                Case Else
                    Return vValor
            End Select
        End Function

        Private Sub ConfigurarReadOnly(ByRef vObjeto As Object, _
                               Optional ByRef vStructure As Object = Nothing)
            If vObjeto.GetType <> GetType(ComboBox) And _
                vObjeto.GetType <> GetType(DateTimePicker) Then
                vObjeto.ReadOnly = True
            Else
                If Not IsNothing(vStructure) Then vStructure.pEnabled = False
            End If
            vObjeto.Enabled = True
        End Sub

        Private Function CompletarCadena(ByVal Longitud As Int16, ByVal Cadena As Char) As String
            Dim vCadena As String = ""
            CompletarCadena = vCadena.PadLeft(Longitud, Cadena)
            Return CompletarCadena
        End Function

        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 1, 2 'DetalleTipoDocumentos,Personas - Transportista
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function

    End Class
End Namespace