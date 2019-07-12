﻿Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.CuentasCorrientes.Views
    Public Class frmReporteCuentas
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
            Public Property pEnabled As Boolean
            Public Property pCadenaFiltrado As String

            Public Property pMostrarDatosGrid As Boolean
            Public Property pDevolverDatosUnicoRegistro As Boolean
            Public Property pDatosBuscados As String

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

                If txt.Name = "txtPER_ID" Then
                    EtxtPER_ID.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
                    EtxtPER_ID.pComportamiento = 3
                    EtxtPER_ID.pOrdenBusqueda = 1
                End If
                MetodoBusquedaDato("", False, EtxtTemporal)

                If txt.Name = "txtPER_ID" Then
                    EtxtPER_ID.pOOrm = New Ladisac.BE.Personas
                    EtxtPER_ID.pComportamiento = 1
                    EtxtPER_ID.pOrdenBusqueda = 4
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

        Private EtxtPER_ID As New txt
        Private EtxtPER_DESCRIPCION As New txt
        Private EtxtCCT_ID As New txt
        Private EtxtCCT_DESCRIPCION As New txt
        Private EtxtDTD_ID As New txt
        Private EtxtDTD_DESCRIPCION As New txt

        Dim oReporte As New Object
        Dim oReporte1 As New Percepciones


#Region "Clases"
        Private Reporte As New Ladisac.BE.Personas
        Private Reporte1 As New Ladisac.BE.CtaCte

        Private cMisProcedimientos As New Ladisac.MisProcedimientos
#End Region
#End Region
#Region "Secundaria"
#Region "Procedimientos asociados a los procedimientos asociados a la barra de herramientas del formulario, deben de existir"
        Private Sub LimpiarDatos()
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
        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function

        Private Sub frmReporteKardex_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
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

                EtxtPER_ID.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
                EtxtPER_ID.pComportamiento = 3
                EtxtPER_ID.pOrdenBusqueda = 1
                EtxtPER_ID.pOOrm = New Ladisac.BE.Personas
                EtxtPER_ID.pComportamiento = 1
                EtxtPER_ID.pOrdenBusqueda = 4
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- Load")
            End Try
        End Sub
        Private Sub AdicionarElementoCombosEdicion()

        End Sub
        Private Sub NombresFormulariosControles()
            EtxtPER_ID.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID.pComportamiento = 1
            EtxtPER_ID.pOrdenBusqueda = 4

            EtxtCCT_ID.pOOrm = New Ladisac.BE.CtaCte
            EtxtCCT_ID.pComportamiento = 2
            EtxtCCT_ID.pOrdenBusqueda = 1
            EtxtCCT_ID.pOOrm.CadenaFiltrado = " And CCT_ID  In (select CCT_ID from vwdetallepermisocuentacorriente where USU_ID='" & SessionService.UserId & "')"
            EtxtCCT_ID.pMostrarDatosGrid = True
            EtxtCCT_ID.pDevolverDatosUnicoRegistro = True
            EtxtCCT_ID.pDatosBuscados = "Agencia"

            EtxtDTD_ID.pOOrm = New Ladisac.BE.RolOpeCtaCte
            EtxtDTD_ID.pComportamiento = 4
            EtxtDTD_ID.pOrdenBusqueda = 2
            EtxtDTD_ID.pMostrarDatosGrid = True
            EtxtDTD_ID.pOOrm.CadenaFiltrado = " "
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

            'EchkCAF_ESTADO = EchkTemporal
            'EchkCAF_ESTADO.pNombreCampo = "CAF_ESTADO"
            'ConfigurarCheck_Refrescar(EchkCAF_ESTADO)
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkCAF_ESTADO"
                    'Simple.CampoId = EchkCAF_ESTADO.pNombreCampo
                    'Simple.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Reporte.DevolverTiposCampos()
        End Function
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkCAF_ESTADO"
                    'vObjetoChk.pValorDefault = EchkCAF_ESTADO.pValorDefault
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
        'Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        'Handles chkCAF_ESTADO.CheckedChanged
        '    Select Case sender.name.ToString
        '        'Case "chkCAF_ESTADO"
        '        '    If EchkCAF_ESTADO.pFormatearTexto Then
        '        '        InicializarTextoCheck(EchkCAF_ESTADO)
        '        '    End If
        '    End Select
        'End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "CAF_ESTADO"
                    'With chkCAF_ESTADO
                    '    If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                    '    If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                    '    If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    'End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            'InicializarTextoCheck(EchkCAF_ESTADO)
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

            EtxtPER_ID = EtxtTemporal
            EtxtPER_DESCRIPCION = EtxtTemporal

            EtxtCCT_ID = EtxtTemporal
            EtxtCCT_DESCRIPCION = EtxtTemporal

            EtxtDTD_ID = EtxtTemporal
            EtxtDTD_DESCRIPCION = EtxtTemporal

            EtxtPER_ID.pBusqueda = True
            EtxtPER_ID.pFormularioConsulta = True

            EtxtCCT_ID.pBusqueda = True
            EtxtCCT_ID.pFormularioConsulta = True

            EtxtDTD_ID.pBusqueda = True
            EtxtDTD_ID.pFormularioConsulta = True
        End Sub
#End Region
#End Region
#Region "Secundaria1"
        Private Sub FormatearCampos()
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object,
                                   ByVal NombreCampo As String,
                                   ByRef sender As txt,
                                   Optional ByVal e As System.Boolean = True)

            'FormatearCampos(oObjeto, NombreCampo, Reporte.vArrayDatosComboBox, Reporte.vElementosDatosComboBox - 1, sender, e)
            FormatearCampos(oObjeto, NombreCampo, sender.pOOrm.vArrayDatosComboBox, sender.pOOrm.vElementosDatosComboBox - 1, sender, e)
        End Sub
        Private Sub FormatearCampos(ByRef oObjeto As Object,
                                    ByVal NombreCampo As String, _
                                    ByVal vArrayDatosComboBox As Object,
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
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

            Select Case sender.name.ToString
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto1 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto1 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)

            Select Case sender.name.ToString
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto2 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto2 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto2 = sender.text
            End Select
        End Sub

        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

            Select Case sender.name.ToString
                Case "txtPER_ID"
                    oKeyPress(EtxtPER_ID, e)
                Case "txtCCT_ID"
                    oKeyPress(EtxtCCT_ID, e)
                Case "txtDTD_ID"
                    oKeyPress(EtxtDTD_ID, e)
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
                    Case "frmPersonas"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                    Case "frmCtaCte"
                        'frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
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
            Imprimir()
        End Sub
        Private Sub Imprimir()
            Try

                'Me.Cursor = Cursors.WaitCursor
                Dim ds As New DataSet
                Dim vFiltroProcedimiento As String = ""

                vTitulo1 = "Registro De Percepciones - Clientes"
                vTitulo2 = "Periodo : " & dtpFechaInicial.Text & " - " & dtpFechaFinal.Text
                Dim sr As Object
                sr = New StringReader(IBCMaestro.EjecutarVista("spKardexCtaCteNuevo1XML", " and cast(tes.DOC_FECHA_EMI_REF as DATE) between cast('" & dtpFechaInicial.Text & "' as DATE) and cast('" & dtpFechaFinal.Text & "' as DATE)"))
                oReporte = oReporte1
                Dim vcontrol As Int16 = sr.Peek
                If vcontrol <> -1 Then
                    ds.ReadXml(sr)
                    oReporte.Database.Tables(0).SetDataSource(ds.Tables(0))
                    oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"
                    oReporte.DataDefinition.FormulaFields("Titulo2").Text = "'" & vTitulo2 & "'"
                    'oReporte.DataDefinition.FormulaFields("OcultarEncabezado").Text = "False"
                    'oReporte.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & Me.SessionService.NombreEmpresa & "'"
                    'oReporte.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & Me.SessionService.RUCEmpresa & "'"

                    Dim frm = Me.ContainerService.Resolve(Of Ladisac.Reporteador)()
                    frm.Reporte(oReporte)
                    frm.Show()
                    frm.BringToFront()
                Else
                    MsgBox("No se genero datos, reporte vacio", MsgBoxStyle.Information, Me.Text & " - Imprimir")
                End If

                Me.Cursor = Cursors.Default
            Catch ex As Exception
                If Err.Number = 5 Then
                    MsgBox("¡El servidor esta demorando demasiado en devolver los datos!" & Chr(13) & "Intente de nuevo, en unos minutos", MsgBoxStyle.Critical, Me.Text & " - Imprimir")
                Else
                    MsgBox(Err.Number & " - " & ex.Message())
                End If
                Me.Cursor = Cursors.Default
            End Try
        End Sub



        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 1 ' Personas
                    OrdenBusquedaDirecta = 0
                Case 2 ' CtaCte
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function

    End Class
End Namespace