Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Despachos.Views
    Public Class frmKardexDocumento
        ''' <summary>
        ''' 
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
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

                If txt.Name = "txtPER_ID_CLI" Then
                    EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
                    EtxtPER_ID_CLI.pComportamiento = 9
                    EtxtPER_ID_CLI.pOrdenBusqueda = 1

                    If pComportamientoFormulario = 400 Then
                        If rbGuias.Checked Then
                            lblPER_ID.Text = "Vendedor"
                            EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and CODIGO in (select PER_ID from vwRolPersonaTipoPersona where PER_TRABAJADOR='SI' and TPE_TRABAJADOR='SI')"
                        Else
                            lblPER_ID.Text = "Cliente"
                            EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and CODIGO in (select PER_ID from vwRolPersonaTipoPersona where PER_CLIENTE='SI' and TPE_CLIENTE='SI')"
                        End If
                    Else
                        EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and CODIGO in (select PER_ID from vwRolPersonaTipoPersona where PER_CLIENTE='SI' and TPE_CLIENTE='SI')"
                    End If
                End If
                If pComportamientoFormulario = 100 Then
                    If txt.Name = "txtPER_ID" Then
                        EtxtPER_ID.pOOrm = New Ladisac.BE.DocumentosKardexDocumento
                        EtxtPER_ID.pComportamiento = 10
                        EtxtPER_ID.pOrdenBusqueda = 2
                        EtxtPER_ID.pOOrm.CadenaFiltrado = " and DTD_ID in (select DTD_ID from vwDetalleTipoDocumentos where TDO_TABLA='DOCUMENTOS' and DTD_MOVIMIENTO='VENTA POR DESPACHAR' and DTD_CARGO_ABONO<>'NINGUNO' and DTD_ESTADO='ACTIVO')"
                    End If
                End If

                MetodoBusquedaDato("", False, EtxtTemporal)

                If txt.Name = "txtPER_ID_CLI" Then
                    EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.Personas
                    EtxtPER_ID_CLI.pComportamiento = 5
                    EtxtPER_ID_CLI.pOrdenBusqueda = 4
                    EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_CLIENTE='SI' and TPE_CLIENTE='SI')"
                End If
                If pComportamientoFormulario = 100 Then
                    If txt.Name = "txtPER_ID" Then
                        EtxtPER_ID.pOOrm = New Ladisac.BE.Documentos
                        EtxtPER_ID.pOOrm.pBuscarRegistros = True
                        EtxtPER_ID.pComportamiento = 4
                        EtxtPER_ID.pOrdenBusqueda = 0
                        EtxtPER_ID.pOOrm.CadenaFiltrado = " and DTD_ID in (select DTD_ID from vwDetalleTipoDocumentos where TDO_TABLA='DOCUMENTOS' and DTD_MOVIMIENTO='VENTA POR DESPACHAR' and DTD_CARGO_ABONO<>'NINGUNO' and DTD_ESTADO='ACTIVO')"
                    End If
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

        Private EtxtTIP_ID As New txt
        Private EtxtTIP_DESCRIPCION As New txt
        Private EtxtDTD_ID As New txt
        Private EtxtDTD_DESCRIPCION As New txt
        Private EtxtCCT_ID As New txt
        Private EtxtCCT_DESCRIPCION As New txt
        Private EtxtPER_ID As New txt   'Documento
        Private EtxtPER_ID_CLI As New txt ' Cliente
        Private EtxtPER_DESCRIPCION As New txt ' Documento
        Private EtxtPER_DESCRIPCION_CLI As New txt ' Cliente
        Private EtxtALM_ID As New txt ' Almacen salida
        Private EtxtALM_ID_LLEGADA As New txt ' Almacen llegada
        Private EtxtPVE_ID As New txt ' Punto venta

        Public Property pComportameintoFormulario As Int16

        <Dependency()> _
        Public Property IBCDespachos As Ladisac.BL.IBCDespachos

        Dim oReporte1 As New KardexDocumento
        Dim oReporte2 As New EntregaDespacho
        Dim oReporte3 As New Ladisac.Facturacion.Reportes.ToneladasMillaresVentas
        Dim oReporte4 As New TrasladoEntreAlmacenes
        Dim oReporte5 As New KardexDocumentoDirecciones
        Dim oReporte6 As New KardexDocumentoValorizado
        Dim oReporte7 As New Ladisac.Facturacion.Reportes.DetalleVentaPorArticulo
        Dim oReporte8 As New ReporteGuias
        Dim oReporte9 As New ReporteGuiasArticulo
        Dim oReporte10 As New Ladisac.Facturacion.Reportes.ToneladasMillaresVentasClientes
        Dim oReporte11 As New PendientesEntregaGeneral
        Dim oReporte12 As New Ladisac.Facturacion.Reportes.RecordVentaClienteArticulo
        Dim oReporte13 As New Ladisac.Facturacion.Reportes.RecordVentaArticuloCliente
        Dim oReporte14 As New PendientesEntregaGeneralPorArticulo
        Dim oReporte As Object

#Region "Clases"
        Private Reporte As New Ladisac.BE.TipoArticulos

        Private cMisProcedimientos As New Ladisac.MisProcedimientos
        Private cUtil As New Ladisac.BL.BCUtil
#End Region
#End Region
#Region "Secundaria"
#Region "Procedimientos asociados a los procedimientos asociados a la barra de herramientas del formulario, deben de existir"
        Private Sub LimpiarDatos()
            InicializarValores(txtTIP_ID, ErrorProvider1)
            InicializarValores(txtTIP_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtDTD_ID, ErrorProvider1)
            InicializarValores(txtDTD_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtCCT_ID, ErrorProvider1)
            InicializarValores(txtCCT_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtPER_ID, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtPER_ID_CLI, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_CLI, ErrorProvider1)
            InicializarValores(txtSerie, ErrorProvider1)
            InicializarValores(txtNumero, ErrorProvider1)
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
            Dim vDTD_ID As String = ""
            Dim vCCT_ID As String = ""

            vDTD_ID = RetornarDatoBusqueda(txtDTD_ID.Text.Trim)
            vCCT_ID = RetornarDatoBusqueda(txtCCT_ID.Text.Trim)

            Select Case vComportamiento
                Case 1 ' TipoArticulo
                Case 2 ' DetalleTipoDocumentos
                Case 3 ' CtaCte
                Case 6 ' Almacen salida
                    EtxtALM_ID_LLEGADA.pOOrm.CadenaFiltrado = " and ALM_ID not in ('" & txtALM_ID.Text.Trim & "')"
                Case 7 ' Almacen llegada
                    EtxtALM_ID.pOOrm.CadenaFiltrado = " and ALM_ID not in ('" & txtALM_ID_LLEGADA.Text.Trim & "')"
                Case 8 ' Punto venta
            End Select
            EtxtPER_ID.pOOrm.CadenaFiltrado = " and DTD_ID Like '" & vDTD_ID & "' and CCT_ID Like '" & vCCT_ID & "' and DTD_ID in (select DTD_ID from vwDetalleTipoDocumentos where TDO_TABLA='DOCUMENTOS' and DTD_MOVIMIENTO='VENTA POR DESPACHAR' and DTD_CARGO_ABONO<>'NINGUNO' and DTD_ESTADO='ACTIVO')"
        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtTIP_ID" Then EtxtTIP_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI" Then EtxtPER_ID_CLI.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtALM_ID" Then EtxtALM_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtALM_ID_LLEGADA" Then EtxtALM_ID_LLEGADA.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtTIP_ID" Then EtxtTIP_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI" Then EtxtPER_ID_CLI.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtALM_ID" Then EtxtALM_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtALM_ID_LLEGADA" Then EtxtALM_ID_LLEGADA.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
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
                MetodoBusquedaDato(BCVariablesNames.TipoArticulo.ProductoTerminado, True, EtxtTIP_ID)
                MetodoBusquedaDato(BCVariablesNames.CCT_ID.CxCComerciales, True, EtxtCCT_ID)
                ConfigurarReadOnly(txtPER_ID, EtxtPER_ID)
                chkFormato.Visible = False
                Select Case pComportamientoFormulario
                    Case 100 ' frmKardexDocumento
                        rbPendientesAtencionCliente.Checked = CheckState.Unchecked
                        'chkPendientesAtencionCliente.CheckState = CheckState.Unchecked
                        rbPendientesAtencion.Enabled = False
                        rbPendientesAtencion.Visible = False
                        rbPendientesAtencionCliente.Enabled = False
                        rbPendientesAtencionCliente.Visible = False
                        rbPendientesAtencionVendedor.Enabled = False
                        rbPendientesAtencionVendedor.Visible = False
                        chkFiltrarXFechas.CheckState = CheckState.Unchecked
                        chkResumenDetalle.Visible = False
                        chkMostrarDirecciones.Visible = True
                        chkMostrarDirecciones.Enabled = True

                        chkMostrarDirecciones.CheckState = CheckState.Checked

                        oReporte = oReporte1

                        lblALM_ID.Visible = False
                        txtALM_ID.Visible = False
                        txtALM_DESCRIPCION.Visible = False

                        lblPVE_ID.Visible = False
                        txtPVE_ID.Visible = False
                        txtPVE_DESCRIPCION.Visible = False

                        lblALM_ID_LLEGADA.Visible = False
                        txtALM_ID_LLEGADA.Visible = False
                        txtALM_DESCRIPCION_LLEGADA.Visible = False

                        EtxtPER_ID.pOOrm = New Ladisac.BE.DocumentosKardexDocumento
                        EtxtPER_ID.pComportamiento = 10
                        EtxtPER_ID.pOrdenBusqueda = 2
                        EtxtPER_ID.pOOrm.CadenaFiltrado = " and DTD_ID in (select DTD_ID from vwDetalleTipoDocumentos where TDO_TABLA='DOCUMENTOS' and DTD_MOVIMIENTO='VENTA POR DESPACHAR' and DTD_CARGO_ABONO<>'NINGUNO' and DTD_ESTADO='ACTIVO')"

                        MetodoBusquedaDato("", False, EtxtPER_ID)

                        EtxtPER_ID.pOOrm = New Ladisac.BE.Documentos
                        EtxtPER_ID.pOOrm.pBuscarRegistros = True
                        EtxtPER_ID.pComportamiento = 4
                        EtxtPER_ID.pOrdenBusqueda = 0
                        EtxtPER_ID.pOOrm.CadenaFiltrado = " and DTD_ID in (select DTD_ID from vwDetalleTipoDocumentos where TDO_TABLA='DOCUMENTOS' and DTD_MOVIMIENTO='VENTA POR DESPACHAR' and DTD_CARGO_ABONO<>'NINGUNO' and DTD_ESTADO='ACTIVO')"

                    Case 200 ' frmPendientesAtencion
                        btnImprimirValorizado.Enabled = True
                        btnImprimirValorizado.Visible = True
                        btnImprimirValorizadoSinComercializadora.Enabled = True
                        btnImprimirValorizadoSinComercializadora.Visible = True
                        lblALM_ID.Visible = False
                        txtALM_ID.Visible = False
                        txtALM_DESCRIPCION.Visible = False

                        lblPVE_ID.Visible = True
                        txtPVE_ID.Visible = True
                        txtPVE_DESCRIPCION.Visible = True

                        lblALM_ID_LLEGADA.Visible = False
                        txtALM_ID_LLEGADA.Visible = False
                        txtALM_DESCRIPCION_LLEGADA.Visible = False

                        'rbPendientesAtencion.Enabled = False
                        'rbPendientesAtencion.Visible = False

                        rbPendientesAtencion.Enabled = True
                        rbPendientesAtencion.Visible = True


                        rbPendientesAtencionCliente.Checked = CheckState.Checked
                        chkFiltrarXFechas.CheckState = CheckState.Unchecked

                        lblDOCUMENTO.Visible = True
                        lblDOCUMENTO.Text = "Pendientes"

                        chkResumenDetalle.Visible = True
                        'chkResumenDetalle.Enabled = False

                        lblFechaInicial.Visible = True
                        lblFechaInicial.Text = "Fecha de proceso"
                        dtpFechaInicial.Visible = True
                        dtpFechaInicial.Enabled = True
                        dtpFechaInicial.Value = IBCMaestro.EjecutarVista("spFechaServidor")

                        chkMostrarDirecciones.Visible = False

                        lblDTD_ID.Visible = False
                        txtDTD_ID.Visible = False
                        txtDTD_DESCRIPCION.Visible = False

                        chkMostrarValorizado.Visible = False ' True

                        rbPendientesAtencionVendedorXArtículo.Visible = True
                        oReporte = oReporte1

                        If IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTEPENDIENTESATENCION", "PVE_ID") Then
                        Else
                            rbPendientesAtencionVendedor.Checked = True
                            txtPER_ID_CLI.Text = IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spCodigoPersonaPermisoUsuario, _
                                                    SessionService.UserId)
                            MetodoBusquedaDato(txtPER_ID_CLI.Text, True, EtxtPER_ID_CLI)
                            ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True)
                            'rbPendientesAtencionCliente.Enabled = False
                            'rbPendientesAtencionCliente.Visible = False
                        End If
                    Case 300 ' frmEntregaDespachos
                        lblALM_ID.Visible = False
                        txtALM_ID.Visible = False
                        txtALM_DESCRIPCION.Visible = False

                        lblALM_ID_LLEGADA.Visible = False
                        txtALM_ID_LLEGADA.Visible = False
                        txtALM_DESCRIPCION_LLEGADA.Visible = False

                        lblPVE_ID.Visible = True
                        txtPVE_ID.Visible = True
                        txtPVE_DESCRIPCION.Visible = True
                        chkFormato.Visible = True

                        rbPendientesAtencionVendedor.Checked = CheckState.Checked

                        rbPendientesAtencion.Enabled = False
                        rbPendientesAtencion.Visible = False
                        rbPendientesAtencionCliente.Enabled = False
                        rbPendientesAtencionCliente.Visible = False
                        rbPendientesAtencionVendedor.Enabled = False
                        rbPendientesAtencionVendedor.Visible = False

                        chkFiltrarXFechas.CheckState = CheckState.Checked

                        lblDOCUMENTO.Visible = True
                        lblDOCUMENTO.Text = "Despacho"
                        chkResumenDetalle.Visible = True
                        chkResumenDetalle.Enabled = True

                        chkMostrarDirecciones.Visible = False

                        lblFechaInicial.Visible = True
                        dtpFechaInicial.Enabled = True
                        dtpFechaInicial.Visible = True
                        lblFechaFinal.Visible = True
                        dtpFechaFinal.Enabled = True
                        dtpFechaFinal.Visible = True

                        lblDTD_ID.Visible = False
                        txtDTD_ID.Visible = False
                        txtDTD_DESCRIPCION.Visible = False

                        oReporte = oReporte2
                    Case 400 ' frmToneladasMillaresVentas
                        lblPVE_ID.Visible = False
                        txtPVE_ID.Visible = False
                        txtPVE_DESCRIPCION.Visible = False

                        lblCCT_ID.Location = New System.Drawing.Point(5, 43)
                        txtCCT_ID.Location = New System.Drawing.Point(94, 43)
                        txtCCT_DESCRIPCION.Location = New System.Drawing.Point(147, 43)

                        lblALM_ID.Visible = False
                        txtALM_ID.Visible = False
                        txtALM_DESCRIPCION.Visible = False

                        lblALM_ID_LLEGADA.Visible = False
                        txtALM_ID_LLEGADA.Visible = False
                        txtALM_DESCRIPCION_LLEGADA.Visible = False

                        lblPER_ID.Location = New System.Drawing.Point(5, 69)
                        txtPER_ID.Location = New System.Drawing.Point(94, 69)
                        txtPER_DESCRIPCION.Location = New System.Drawing.Point(168, 69)

                        lblPER_ID.Location = New System.Drawing.Point(5, 69)
                        txtPER_ID_CLI.Location = New System.Drawing.Point(94, 69)
                        txtPER_DESCRIPCION_CLI.Location = New System.Drawing.Point(168, 69)

                        lblFechaInicial.Visible = True
                        dtpFechaInicial.Enabled = True
                        dtpFechaInicial.Visible = True
                        lblFechaFinal.Visible = True
                        dtpFechaFinal.Enabled = True
                        dtpFechaFinal.Visible = True
                        lblFechaInicial.Location = New System.Drawing.Point(5, 96)
                        dtpFechaInicial.Location = New System.Drawing.Point(94, 96)
                        lblFechaFinal.Location = New System.Drawing.Point(257, 96)
                        dtpFechaFinal.Location = New System.Drawing.Point(322, 96)

                        lblDOCUMENTO.Location = New System.Drawing.Point(5, 123)

                        pnTipoReporteGuias.Enabled = True
                        pnTipoReporteGuias.Visible = True
                        pnTipoReporteGuias.Location = New System.Drawing.Point(94, 123)

                        rbGuias.Text = "Por vendedor"
                        rbGuiasPorArticulo.Text = "Por cliente"

                        pnTipoResumenReporte.Enabled = True
                        pnTipoResumenReporte.Visible = True
                        pnTipoResumenReporte.Location = New System.Drawing.Point(257, 123)

                        rbPendientesAtencionVendedor.Checked = CheckState.Checked

                        rbPendientesAtencion.Enabled = False
                        rbPendientesAtencion.Visible = False

                        rbPendientesAtencionCliente.Enabled = False
                        rbPendientesAtencionCliente.Visible = False

                        rbPendientesAtencionVendedor.Enabled = False
                        rbPendientesAtencionVendedor.Visible = False

                        chkTodosDocumentos.CheckState = CheckState.Checked
                        chkFiltrarXFechas.CheckState = CheckState.Checked

                        chkTodosDocumentos.Visible = False
                        chkMostrarDirecciones.Visible = False
                        chkFiltrarXFechas.Visible = False

                        chkMostrarValorizado.Location = New System.Drawing.Point(94, 172)
                        chkMostrarValorizado.Visible = False

                        lblDOCUMENTO.Visible = True
                        lblDOCUMENTO.Text = "Tipo reporte"

                        btnImprimir.Location = New System.Drawing.Point(94, 190)

                        Me.ClientSize = New System.Drawing.Size(703, 300)
                        oReporte = oReporte3


                        If Not IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTETONELADASMILLARESVENDIDOS", "PER_ID_VEN") Then
                            txtPER_ID_CLI.Text = IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spCodigoPersonaPermisoUsuario, _
                                                                                SessionService.UserId)
                            MetodoBusquedaDato(txtPER_ID_CLI.Text, True, EtxtPER_ID_CLI)
                            ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True)
                        End If
                    Case 500 ' frmTrasladoEntreAlmacenes
                        rbPendientesAtencionVendedor.Checked = CheckState.Checked
                        rbPendientesAtencion.Enabled = False
                        rbPendientesAtencion.Visible = False
                        rbPendientesAtencionCliente.Enabled = False
                        rbPendientesAtencionCliente.Visible = False
                        rbPendientesAtencionVendedor.Enabled = False
                        rbPendientesAtencionVendedor.Visible = False
                        chkFiltrarXFechas.CheckState = CheckState.Checked
                        chkTodosDocumentos.CheckState = CheckState.Checked
                        chkTodosDocumentos.Visible = False
                        chkResumenDetalle.Visible = True
                        chkMostrarDirecciones.Visible = False
                        lblFechaInicial.Visible = True
                        dtpFechaInicial.Enabled = True
                        dtpFechaInicial.Visible = True
                        lblFechaFinal.Visible = True
                        dtpFechaFinal.Enabled = True
                        dtpFechaFinal.Visible = True

                        lblALM_ID.Visible = True
                        txtALM_ID.Visible = True
                        txtALM_DESCRIPCION.Visible = True

                        lblPVE_ID.Visible = False
                        txtPVE_ID.Visible = False
                        txtPVE_DESCRIPCION.Visible = False

                        lblALM_ID_LLEGADA.Visible = True
                        txtALM_ID_LLEGADA.Visible = True
                        txtALM_DESCRIPCION_LLEGADA.Visible = True

                        oReporte = oReporte4
                    Case 600 ' frmDetalleVentaPorArticulo
                        lblTIP_ID.Visible = False
                        txtTIP_ID.Visible = False
                        txtTIP_DESCRIPCION.Visible = False

                        lblDTD_ID.Visible = False
                        txtDTD_ID.Visible = False
                        txtDTD_DESCRIPCION.Visible = False

                        lblALM_ID.Visible = False
                        txtALM_ID.Visible = False
                        txtALM_DESCRIPCION.Visible = False

                        lblPVE_ID.Visible = True
                        txtPVE_ID.Visible = True
                        txtPVE_DESCRIPCION.Visible = True

                        lblPVE_ID.Location = New System.Drawing.Point(5, 17)
                        txtPVE_ID.Location = New System.Drawing.Point(94, 17)
                        txtPVE_DESCRIPCION.Location = New System.Drawing.Point(147, 17)

                        lblCCT_ID.Location = New System.Drawing.Point(5, 43)
                        txtCCT_ID.Location = New System.Drawing.Point(94, 43)
                        txtCCT_DESCRIPCION.Location = New System.Drawing.Point(147, 43)

                        lblALM_ID_LLEGADA.Visible = False
                        txtALM_ID_LLEGADA.Visible = False
                        txtALM_DESCRIPCION_LLEGADA.Visible = False

                        lblPER_ID.Visible = False
                        txtPER_ID.Visible = False
                        txtPER_DESCRIPCION.Visible = False

                        lblPER_ID.Visible = False
                        txtPER_ID_CLI.Visible = False
                        txtPER_DESCRIPCION_CLI.Visible = False

                        chkResumenDetalle.Visible = False

                        lblDOCUMENTO.Visible = True
                        lblDOCUMENTO.Text = "Tipo reporte"

                        pnTipoResumenReporte.Enabled = True
                        pnTipoResumenReporte.Visible = True

                        pnFormato.Enabled = True
                        pnFormato.Visible = True

                        lblDOCUMENTO.Location = New System.Drawing.Point(5, 69)
                        pnTipoResumenReporte.Location = New System.Drawing.Point(94, 69)
                        pnFormato.Location = New System.Drawing.Point(257, 69)

                        txtSerie.Visible = False
                        txtNumero.Visible = False

                        chkFormato.Visible = False
                        chkTodosDocumentos.Visible = False

                        lblFechaInicial.Visible = True
                        dtpFechaInicial.Enabled = True
                        dtpFechaInicial.Visible = True

                        lblFechaInicial.Location = New System.Drawing.Point(5, 123)
                        dtpFechaInicial.Location = New System.Drawing.Point(94, 123)

                        lblFechaFinal.Visible = True
                        dtpFechaFinal.Enabled = True
                        dtpFechaFinal.Visible = True

                        lblFechaFinal.Location = New System.Drawing.Point(257, 123)
                        dtpFechaFinal.Location = New System.Drawing.Point(322, 123)


                        chkMostrarDirecciones.Visible = False

                        rbPendientesAtencion.Visible = False
                        rbPendientesAtencionCliente.Visible = False
                        rbPendientesAtencionVendedor.Visible = False

                        chkMostrarValorizado.Visible = False

                        btnImprimir.Location = New System.Drawing.Point(94, 150)
                        Me.ClientSize = New System.Drawing.Size(703, 250)

                        oReporte = oReporte1
                    Case 700 ' frmReporteGuias 
                        lblTIP_ID.Visible = False
                        txtTIP_ID.Visible = False
                        txtTIP_DESCRIPCION.Visible = False

                        lblDTD_ID.Visible = False
                        txtDTD_ID.Visible = False
                        txtDTD_DESCRIPCION.Visible = False

                        lblALM_ID.Visible = False
                        txtALM_ID.Visible = False
                        txtALM_DESCRIPCION.Visible = False

                        lblPVE_ID.Visible = True
                        txtPVE_ID.Visible = True
                        txtPVE_DESCRIPCION.Visible = True

                        lblPVE_ID.Location = New System.Drawing.Point(5, 17)
                        txtPVE_ID.Location = New System.Drawing.Point(94, 17)
                        txtPVE_DESCRIPCION.Location = New System.Drawing.Point(177, 17)

                        lblCCT_ID.Visible = False
                        txtCCT_ID.Visible = False
                        txtCCT_DESCRIPCION.Visible = False

                        lblALM_ID_LLEGADA.Visible = False
                        txtALM_ID_LLEGADA.Visible = False
                        txtALM_DESCRIPCION_LLEGADA.Visible = False

                        lblPER_ID.Visible = False
                        txtPER_ID.Visible = False
                        txtPER_DESCRIPCION.Visible = False

                        lblPER_ID.Visible = False
                        txtPER_ID_CLI.Visible = False
                        txtPER_DESCRIPCION_CLI.Visible = False

                        lblDOCUMENTO.Visible = True
                        lblDOCUMENTO.Text = "Tipo reporte"
                        chkResumenDetalle.Visible = True
                        chkAnuladas.Visible = True

                        lblDOCUMENTO.Location = New System.Drawing.Point(5, 43)
                        chkResumenDetalle.Location = New System.Drawing.Point(94, 43)
                        chkAnuladas.Location = New System.Drawing.Point(140, 43)

                        txtSerie.Visible = False
                        txtNumero.Visible = False

                        chkFormato.Visible = False
                        chkTodosDocumentos.Visible = False

                        lblFechaInicial.Visible = True
                        dtpFechaInicial.Enabled = True
                        dtpFechaInicial.Visible = True

                        lblFechaInicial.Location = New System.Drawing.Point(5, 69)
                        dtpFechaInicial.Location = New System.Drawing.Point(94, 69)

                        lblFechaFinal.Visible = True
                        dtpFechaFinal.Enabled = True
                        dtpFechaFinal.Visible = True

                        lblFechaFinal.Location = New System.Drawing.Point(257, 69)
                        dtpFechaFinal.Location = New System.Drawing.Point(322, 69)


                        chkMostrarDirecciones.Visible = False

                        rbPendientesAtencion.Visible = False
                        rbPendientesAtencionCliente.Visible = False
                        rbPendientesAtencionVendedor.Visible = False

                        chkMostrarValorizado.Visible = False

                        pnTipoReporteGuias.Enabled = True
                        pnTipoReporteGuias.Visible = True

                        pnTipoReporteGuias.Location = New System.Drawing.Point(94, 96)

                        btnImprimir.Location = New System.Drawing.Point(94, 146) '116
                        Me.ClientSize = New System.Drawing.Size(703, 270) '220
                        '----
                        oReporte = oReporte7
                    Case 800 ' frmReporteGuiasProduccion
                        lblTIP_ID.Visible = False
                        txtTIP_ID.Visible = False
                        txtTIP_DESCRIPCION.Visible = False

                        lblDTD_ID.Visible = False
                        txtDTD_ID.Visible = False
                        txtDTD_DESCRIPCION.Visible = False

                        lblALM_ID.Visible = False
                        txtALM_ID.Visible = False
                        txtALM_DESCRIPCION.Visible = False

                        lblPVE_ID.Visible = True
                        txtPVE_ID.Visible = True
                        txtPVE_DESCRIPCION.Visible = True

                        lblPVE_ID.Location = New System.Drawing.Point(5, 17)
                        txtPVE_ID.Location = New System.Drawing.Point(94, 17)
                        txtPVE_DESCRIPCION.Location = New System.Drawing.Point(147, 17)

                        lblCCT_ID.Visible = False
                        txtCCT_ID.Visible = False
                        txtCCT_DESCRIPCION.Visible = False

                        lblALM_ID_LLEGADA.Visible = False
                        txtALM_ID_LLEGADA.Visible = False
                        txtALM_DESCRIPCION_LLEGADA.Visible = False

                        lblPER_ID.Visible = False
                        txtPER_ID.Visible = False
                        txtPER_DESCRIPCION.Visible = False

                        lblPER_ID.Visible = False
                        txtPER_ID_CLI.Visible = False
                        txtPER_DESCRIPCION_CLI.Visible = False

                        lblDOCUMENTO.Visible = True
                        lblDOCUMENTO.Text = "Tipo reporte"
                        chkResumenDetalle.Visible = True

                        lblDOCUMENTO.Location = New System.Drawing.Point(5, 43)
                        chkResumenDetalle.Location = New System.Drawing.Point(94, 43)

                        txtSerie.Visible = False
                        txtNumero.Visible = False

                        chkFormato.Visible = False
                        chkTodosDocumentos.Visible = False

                        lblFechaInicial.Visible = True
                        dtpFechaInicial.Enabled = True
                        dtpFechaInicial.Visible = True

                        lblFechaInicial.Location = New System.Drawing.Point(5, 69)
                        dtpFechaInicial.Location = New System.Drawing.Point(94, 69)

                        lblFechaFinal.Visible = True
                        dtpFechaFinal.Enabled = True
                        dtpFechaFinal.Visible = True

                        lblFechaFinal.Location = New System.Drawing.Point(257, 69)
                        dtpFechaFinal.Location = New System.Drawing.Point(322, 69)


                        chkMostrarDirecciones.Visible = False

                        rbPendientesAtencion.Visible = False
                        rbPendientesAtencionCliente.Visible = False
                        rbPendientesAtencionVendedor.Visible = False

                        chkMostrarValorizado.Visible = False

                        btnImprimir.Location = New System.Drawing.Point(94, 96)
                        Me.ClientSize = New System.Drawing.Size(703, 220)

                        oReporte = oReporte7
                    Case Else
                        lblALM_ID.Visible = False
                        txtALM_ID.Visible = False
                        txtALM_DESCRIPCION.Visible = False

                        lblPVE_ID.Visible = False
                        txtPVE_ID.Visible = False
                        txtPVE_DESCRIPCION.Visible = False

                        lblALM_ID_LLEGADA.Visible = False
                        txtALM_ID_LLEGADA.Visible = False
                        txtALM_DESCRIPCION_LLEGADA.Visible = False

                        rbPendientesAtencion.Enabled = False
                        rbPendientesAtencion.Visible = False

                        chkMostrarDirecciones.Visible = False
                End Select
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- Load")
            End Try
        End Sub
        Private Sub AdicionarElementoCombosEdicion()

        End Sub
        Private Sub NombresFormulariosControles()
            EtxtTIP_ID.pOOrm = New Ladisac.BE.TipoArticulos
            EtxtTIP_ID.pComportamiento = 1
            EtxtTIP_ID.pOrdenBusqueda = 0

            EtxtDTD_ID.pOOrm = New Ladisac.BE.DetalleTipoDocumentos
            EtxtDTD_ID.pComportamiento = 2
            EtxtDTD_ID.pOrdenBusqueda = 2
            EtxtDTD_ID.pOOrm.CadenaFiltrado = " and TDO_TABLA='DOCUMENTOS' and DTD_MOVIMIENTO='VENTA POR DESPACHAR' and DTD_CARGO_ABONO<>'NINGUNO' and DTD_ESTADO='ACTIVO'"

            EtxtCCT_ID.pOOrm = New Ladisac.BE.CtaCte
            EtxtCCT_ID.pComportamiento = 3
            EtxtCCT_ID.pOrdenBusqueda = 0

            EtxtPER_ID.pOOrm = New Ladisac.BE.Documentos
            EtxtPER_ID.pComportamiento = 4
            EtxtPER_ID.pOrdenBusqueda = 0
            EtxtPER_ID.pOOrm.CadenaFiltrado = " and DTD_ID in (select DTD_ID from vwDetalleTipoDocumentos where TDO_TABLA='DOCUMENTOS' and DTD_MOVIMIENTO='VENTA POR DESPACHAR' and DTD_CARGO_ABONO<>'NINGUNO' and DTD_ESTADO='ACTIVO')"

            EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_CLI.pComportamiento = 5
            EtxtPER_ID_CLI.pOrdenBusqueda = 4
            EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_CLIENTE='SI' and TPE_CLIENTE='SI')"

            EtxtALM_ID.pOOrm = New Ladisac.BE.Almacen
            EtxtALM_ID.pComportamiento = 6
            EtxtALM_ID.pOrdenBusqueda = 0
            EtxtALM_ID.pOOrm.CadenaFiltrado = " and ALM_ID not in ('" & txtALM_ID_LLEGADA.Text.Trim & "')"

            EtxtALM_ID_LLEGADA.pOOrm = New Ladisac.BE.Almacen
            EtxtALM_ID_LLEGADA.pComportamiento = 7
            EtxtALM_ID_LLEGADA.pOrdenBusqueda = 0
            EtxtALM_ID_LLEGADA.pOOrm.CadenaFiltrado = " and ALM_ID not in ('" & txtALM_ID.Text.Trim & "')"

            EtxtPVE_ID.pOOrm = New Ladisac.BE.PuntoVenta
            EtxtPVE_ID.pComportamiento = 8
            EtxtPVE_ID.pOrdenBusqueda = 1
            If pComportamientoFormulario = 200 Or _
               pComportamientoFormulario = 600 Then
                EtxtPVE_ID.pOOrm.CadenaFiltrado = " AND PVE_ID LIKE '%%' And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
            End If
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

            EtxtTIP_ID = EtxtTemporal
            EtxtTIP_DESCRIPCION = EtxtTemporal

            EtxtDTD_ID = EtxtTemporal
            EtxtDTD_DESCRIPCION = EtxtTemporal

            EtxtCCT_ID = EtxtTemporal
            EtxtCCT_DESCRIPCION = EtxtTemporal

            EtxtPER_ID = EtxtTemporal
            EtxtPER_DESCRIPCION = EtxtTemporal

            EtxtPER_ID_CLI = EtxtTemporal
            EtxtPER_DESCRIPCION_CLI = EtxtTemporal

            EtxtALM_ID = EtxtTemporal
            EtxtALM_ID_LLEGADA = EtxtTemporal
            EtxtPVE_ID = EtxtTemporal

            EtxtTIP_ID.pBusqueda = True
            EtxtTIP_ID.pFormularioConsulta = True

            EtxtDTD_ID.pBusqueda = True
            EtxtDTD_ID.pFormularioConsulta = True

            EtxtCCT_ID.pBusqueda = True
            EtxtCCT_ID.pFormularioConsulta = True

            EtxtPER_ID.pBusqueda = True
            EtxtPER_ID.pFormularioConsulta = True

            EtxtPER_ID_CLI.pBusqueda = True
            EtxtPER_ID_CLI.pFormularioConsulta = True

            EtxtALM_ID.pBusqueda = True
            EtxtALM_ID.pFormularioConsulta = True

            EtxtALM_ID_LLEGADA.pBusqueda = True
            EtxtALM_ID_LLEGADA.pFormularioConsulta = True

            EtxtPVE_ID.pBusqueda = True
            EtxtPVE_ID.pFormularioConsulta = True
        End Sub
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtTIP_ID.KeyDown, _
                txtDTD_ID.KeyDown, _
                txtCCT_ID.KeyDown, _
                txtPER_ID.KeyDown, _
                txtPER_ID_CLI.KeyDown, _
                txtALM_ID.KeyDown, _
                txtALM_ID_LLEGADA.KeyDown, _
                txtPVE_ID.KeyDown
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtTIP_ID"
                            TeclaF1(EtxtTIP_ID, txtTIP_ID)
                        Case "txtDTD_ID"
                            TeclaF1(EtxtDTD_ID, txtDTD_ID)
                        Case "txtCCT_ID"
                            TeclaF1(EtxtCCT_ID, txtCCT_ID)
                        Case "txtPER_ID"
                            TeclaF1(EtxtPER_ID, txtPER_ID)
                        Case "txtPER_ID_CLI"
                            TeclaF1(EtxtPER_ID_CLI, txtPER_ID_CLI)
                        Case "txtALM_ID"
                            TeclaF1(EtxtALM_ID, txtALM_ID)
                        Case "txtALM_ID_LLEGADA"
                            TeclaF1(EtxtALM_ID_LLEGADA, txtALM_ID_LLEGADA)
                        Case "txtPVE_ID"
                            TeclaF1(EtxtPVE_ID, txtPVE_ID)
                    End Select
            End Select
        End Sub
#End Region
#End Region
#Region "Secundaria1"
        Private Sub FormatearCampos()
            FormatearCampos(txtTIP_ID, "TIP_ID", EtxtTIP_ID, False)
            FormatearCampos(txtTIP_DESCRIPCION, "TIP_DESCRIPCION", EtxtTIP_ID, False)
            FormatearCampos(txtDTD_ID, "DTD_ID", EtxtDTD_ID)
            FormatearCampos(txtDTD_DESCRIPCION, "DTD_DESCRIPCION", EtxtDTD_ID, False)
            FormatearCampos(txtCCT_ID, "CCT_ID", EtxtCCT_ID, False)
            FormatearCampos(txtCCT_DESCRIPCION, "CCT_DESCRIPCION", EtxtCCT_ID, False)
            FormatearCampos(txtPER_ID, "PER_ID", EtxtPER_ID)
            FormatearCampos(txtPER_DESCRIPCION, "PER_DESCRIPCION", EtxtPER_ID, False)

            FormatearCampos(txtPER_ID_CLI, "PER_ID", EtxtPER_ID_CLI)
            FormatearCampos(txtPER_DESCRIPCION_CLI, "PER_DESCRIPCION", EtxtPER_ID_CLI, False)

            FormatearCampos(txtSerie, "DOC_SERIE", EtxtPER_ID)
            FormatearCampos(txtNumero, "DOC_NUMERO", EtxtPER_ID)

            FormatearCampos(txtALM_ID, "ALM_ID", EtxtALM_ID, False)
            FormatearCampos(txtALM_DESCRIPCION, "ALM_DESCRIPCION", EtxtALM_ID, False)

            FormatearCampos(txtALM_ID_LLEGADA, "ALM_ID", EtxtALM_ID_LLEGADA, False)
            FormatearCampos(txtALM_DESCRIPCION_LLEGADA, "ALM_DESCRIPCION", EtxtALM_ID_LLEGADA, False)

            FormatearCampos(txtPVE_ID, "PVE_ID", EtxtPVE_ID, False)
            FormatearCampos(txtPVE_DESCRIPCION, "PVE_DESCRIPCION", EtxtPVE_ID, False)
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object, _
                                   ByVal NombreCampo As String, _
                                   ByRef sender As txt,
                                   Optional ByVal e As System.Boolean = True)
            FormatearCampos(oObjeto, NombreCampo, _
                            sender.pOOrm.vArrayDatosComboBox, _
                            sender.pOOrm.vElementosDatosComboBox - 1, sender, e)
            'FormatearCampos(oObjeto, NombreCampo, Reporte.vArrayDatosComboBox, Reporte.vElementosDatosComboBox - 1, sender, e)
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
        Handles txtTIP_ID.GotFocus, _
                txtDTD_ID.GotFocus, _
                txtCCT_ID.GotFocus, _
                txtPER_ID.GotFocus, _
                txtPER_ID_CLI.GotFocus, _
                txtALM_ID.GotFocus, _
                txtALM_ID_LLEGADA.GotFocus, _
                txtPVE_ID.GotFocus
            Select Case sender.name.ToString
                Case "txtTIP_ID"
                    EtxtTIP_ID.pTexto1 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto1 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto1 = sender.text
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto1 = sender.text
                Case "txtPER_ID_CLI"
                    EtxtPER_ID_CLI.pTexto1 = sender.text
                Case "txtALM_ID"
                    EtxtALM_ID.pTexto1 = sender.text
                Case "txtALM_ID_LLEGADA"
                    EtxtALM_ID_LLEGADA.pTexto1 = sender.text
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtTIP_ID.LostFocus, _
                txtDTD_ID.LostFocus, _
                txtCCT_ID.LostFocus, _
                txtPER_ID.LostFocus, _
                txtPER_ID_CLI.LostFocus, _
                txtALM_ID.LostFocus, _
                txtALM_ID_LLEGADA.LostFocus, _
                txtPVE_ID.LostFocus
            Select Case sender.name.ToString
                Case "txtTIP_ID"
                    EtxtTIP_ID.pTexto2 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto2 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto2 = sender.text
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto2 = sender.text
                Case "txtPER_ID_CLI"
                    EtxtPER_ID_CLI.pTexto2 = sender.text
                Case "txtALM_ID"
                    EtxtALM_ID.pTexto2 = sender.text
                Case "txtALM_ID_LLEGADA"
                    EtxtALM_ID_LLEGADA.pTexto2 = sender.text
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtTIP_ID.Validated, _
                txtDTD_ID.Validated, _
                txtCCT_ID.Validated, _
                txtPER_ID.Validated, _
                txtPER_ID_CLI.Validated, _
                txtSerie.Validated, _
                txtNumero.Validated, _
                txtALM_ID.Validated, _
                txtALM_ID_LLEGADA.Validated, _
                txtPVE_ID.Validated

            Select Case sender.name.ToString
                Case "txtTIP_ID"
                    ValidarDatos(EtxtTIP_ID, txtTIP_ID)
                Case "txtDTD_ID"
                    ValidarDatos(EtxtDTD_ID, txtDTD_ID)
                Case "txtCCT_ID"
                    ValidarDatos(EtxtCCT_ID, txtCCT_ID)
                Case "txtPER_ID"
                    ValidarDatos(EtxtPER_ID, txtPER_ID)
                Case "txtPER_ID_CLI"
                    txtPER_ID_CLI.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_CLI.Text, txtPER_ID_CLI.MaxLength)
                    ValidarDatos(EtxtPER_ID_CLI, txtPER_ID_CLI)
                Case "txtSerie"
                    txtSerie.Text = CompletarCadena(txtSerie.MaxLength - Len(txtSerie.Text.Trim), "0") & txtSerie.Text
                Case "txtNumero"
                    txtNumero.Text = CompletarCadena(txtNumero.MaxLength - Len(txtNumero.Text.Trim), "0") & txtNumero.Text
                Case "txtALM_ID"
                    ValidarDatos(EtxtALM_ID, txtALM_ID)
                Case "txtALM_ID_LLEGADA"
                    ValidarDatos(EtxtALM_ID_LLEGADA, txtALM_ID_LLEGADA)
                Case "txtPVE_ID"
                    txtPVE_ID.Text = cMisProcedimientos.VerificarLongitud(txtPVE_ID.Text, txtPVE_ID.MaxLength)
                    ValidarDatos(EtxtPVE_ID, txtPVE_ID)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtTIP_ID.KeyPress, _
                txtDTD_ID.KeyPress, _
                txtCCT_ID.KeyPress, _
                txtPER_ID.KeyPress, _
                txtPER_ID_CLI.KeyPress, _
                txtALM_ID.KeyPress, _
                txtALM_ID_LLEGADA.KeyPress, _
                txtPVE_ID.KeyPress

            Select Case sender.name.ToString
                Case "txtTIP_ID"
                    oKeyPress(EtxtTIP_ID, e)
                Case "txtDTD_ID"
                    oKeyPress(EtxtDTD_ID, e)
                Case "txtCCT_ID"
                    oKeyPress(EtxtCCT_ID, e)
                Case "txtPER_ID"
                    oKeyPress(EtxtPER_ID, e)
                Case "txtPER_ID_CLI"
                    oKeyPress(EtxtPER_ID_CLI, e)
                Case "txtALM_ID"
                    oKeyPress(EtxtALM_ID, e)
                Case "txtALM_ID_LLEGADA"
                    oKeyPress(EtxtALM_ID_LLEGADA, e)
                Case "txtPVE_ID"
                    oKeyPress(EtxtPVE_ID, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtTIP_ID.DoubleClick, _
                txtDTD_ID.DoubleClick, _
                txtCCT_ID.DoubleClick, _
                txtPER_ID.DoubleClick, _
                txtPER_ID_CLI.DoubleClick, _
                txtALM_ID.DoubleClick, _
                txtALM_ID_LLEGADA.DoubleClick, _
                txtPVE_ID.DoubleClick
            Select Case sender.name.ToString
                Case "txtTIP_ID"
                    'oDoubleClick(EtxtCCT_ID, txtCCT_ID, "frmCtaCte")
                Case "txtDTD_ID"
                    'oDoubleClick(EtxtCCT_ID, txtCCT_ID, "frmCtaCte")
                Case "txtCCT_ID"
                    oDoubleClick(EtxtCCT_ID, txtCCT_ID, "frmCtaCte")
                Case "txtPER_ID"
                    txtPER_ID.Text = ""
                    txtPER_DESCRIPCION.Text = ""
                    txtSerie.Text = ""
                    txtNumero.Text = ""
                    'oDoubleClick(EtxtPER_ID, txtPER_ID, "frmPersonas")
                Case "txtPER_ID_CLI"
                    txtPER_ID_CLI.Text = ""
                    txtPER_DESCRIPCION_CLI.Text = ""
                    'oDoubleClick(EtxtPER_ID_CLI, txtPER_ID_CLI, "frmPersonas")
                Case "txtALM_ID"
                    'oDoubleClick(EtxtCCT_ID, txtCCT_ID, "frmCtaCte")
                Case "txtALM_ID_LLEGADA"
                    'oDoubleClick(EtxtCCT_ID, txtCCT_ID, "frmCtaCte")
                Case "txtPVE_ID"
                    'oDoubleClick(EtxtPVE_ID, txtPVE_ID, "frmPuntoVenta")
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
                    Case "frmTipoArticulo"
                        'frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                    Case "frmCtaCte"
                        'frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                    Case "frmCtaCte"
                        'frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                    Case "frmPersonas"
                        'frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                    Case Else
                        Exit Sub
                End Select
                Exit Sub
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
            '''
            '''
            If txtTIP_ID.Text.Trim = "" Then
                MsgBox("Debe ingresar un tipo de artículo", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            Select Case pComportamientoFormulario
                Case 200 ' frmPendientesAtencion
                    If IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTEPENDIENTESATENCION", "PVE_ID") Then
                    Else
                        If Trim(txtPER_ID_CLI.Text) = "" Then
                            If txtPVE_ID.Text.Trim = "" Then
                                MsgBox("¡Debe ingresar un punto de venta!", MsgBoxStyle.Information, Me.Text)
                                Exit Sub
                            End If
                        End If
                    End If
                    If rbPendientesAtencion.Checked Then
                        If Trim(txtPER_ID_CLI.Text) <> "" Then
                            'MsgBox("No debe ingresar un código de persona", MsgBoxStyle.Information, Me.Text)
                            'Exit Sub
                        End If
                    End If
                    If rbPendientesAtencionCliente.Checked Then
                        If Trim(txtPER_ID_CLI.Text) = "" Then
                            'MsgBox("Debe ingresar un código de cliente", MsgBoxStyle.Information, Me.Text)
                            'Exit Sub
                        End If
                    End If
                    If rbPendientesAtencionVendedor.Checked Then
                        If Trim(txtPER_ID_CLI.Text) = "" Then
                            'MsgBox("Debe ingresar un código de vendedor", MsgBoxStyle.Information, Me.Text)
                            'Exit Sub
                        End If
                    End If
                    If rbPendientesAtencionVendedorXArtículo.Checked Then
                        If Trim(txtPER_ID_CLI.Text) = "" Then
                            'MsgBox("Debe ingresar un código de vendedor", MsgBoxStyle.Information, Me.Text)
                            'Exit Sub
                        End If
                    End If
                Case 600 ' frmDetalleVentaPorArticulo
                    If IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTEDETALLEVENTAPORARTICULOS", "PVE_ID") Then
                    Else
                        If txtPVE_ID.Text.Trim = "" Then
                            MsgBox("¡Debe ingresar un punto de venta!", MsgBoxStyle.Information, Me.Text)
                            Exit Sub
                        End If
                    End If
            End Select
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

            Dim NombreProcedimiento As String = Ladisac.DA.SPNames.spKardexDocumentoDespachoNuevo1XML

            Dim vTIP_ID As Object = Nothing
            Dim vDTD_ID As Object = Nothing
            Dim vCCT_ID As Object = Nothing
            Dim vPER_ID As Object = Nothing
            Dim vDOCUMENTO As Object = Nothing

            Dim vALM_ID As Object = Nothing
            Dim vALM_ID_LLEGADA As Object = Nothing
            Dim vPVE_ID As Object = Nothing

            Dim vFiltroProcedimiento As String = ""

            vTitulo1 = ""
            vTitulo2 = ""
            vTitulo3 = ""

            vTIP_ID = RetornarDatoBusqueda(txtTIP_ID.Text.Trim, False)
            vDTD_ID = RetornarDatoBusqueda(txtDTD_ID.Text.Trim, False)
            vCCT_ID = RetornarDatoBusqueda(txtCCT_ID.Text.Trim, False)

            vALM_ID = RetornarDatoBusqueda(txtALM_ID.Text.Trim, False)
            vALM_ID_LLEGADA = RetornarDatoBusqueda(txtALM_ID_LLEGADA.Text.Trim, False)
            vPVE_ID = RetornarDatoBusqueda(txtPVE_ID.Text.Trim, False)

            vTitulo2 &= "TIPO ARTÍCULO : " & txtTIP_DESCRIPCION.Text

            Select Case pComportamientoFormulario
                Case 400
                    vTitulo2 &= "   -   FECHA DEL : " & dtpFechaInicial.Text & " AL : " & dtpFechaFinal.Text
                Case Else
                    If txtDTD_ID.Text.Trim = "" Then
                        vTitulo2 &= "   -   DOCUMENTO : TODOS"
                    Else
                        vTitulo2 &= "   -   DOCUMENTO : " & txtDTD_DESCRIPCION.Text
                    End If
            End Select

            If txtCCT_ID.Text.Trim = "" Then
                vTitulo3 &= "CTA.CTE. : TODAS"
            Else
                vTitulo3 &= "CTA.CTE. :" & txtCCT_DESCRIPCION.Text
            End If

            Select Case pComportamientoFormulario
                Case 800 ' frmReporteGuiasProduccion
                    NombreProcedimiento = Ladisac.DA.SPNames.spReporteGuiasProduccion
                Case 700 ' frmReporteGuias
                    If chkAnuladas.Checked Then
                        NombreProcedimiento = Ladisac.DA.SPNames.spReporteGuiasAnuladasXML
                    Else
                        NombreProcedimiento = Ladisac.DA.SPNames.spReporteGuiasXML
                    End If

                    If rbGuias.Checked Then
                        oReporte = oReporte8
                    Else
                        oReporte = oReporte9
                    End If

                    If chkResumenDetalle.Checked Then
                        oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                        vTitulo1 = "Resumen de reporte de guías al : " & dtpFechaInicial.Text & " - " & dtpFechaFinal.Text
                    Else
                        oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "false"
                        vTitulo1 = "Detalle de reporte de guías Al : " & dtpFechaInicial.Text & " - " & dtpFechaFinal.Text
                    End If
                Case 600 ' frmDetalleVentaPorArticulo
                    'If pComportamientoFormulario = 200 Then
                    If txtPVE_ID.Text.Trim = "" Then
                        vTitulo3 &= "   -   " & lblPVE_ID.Text & " : TODAS"
                    Else
                        vTitulo3 &= "   -   " & lblPVE_ID.Text & " : " & txtPVE_DESCRIPCION.Text
                        vFiltroProcedimiento += " AND PVE_ID='" & txtPVE_ID.Text & "'"
                    End If
                    'End If
                    NombreProcedimiento = Ladisac.DA.SPNames.spKardexDocumentoPesosTodosXML
                    If rbFormato1.Checked Then
                        oReporte = oReporte12
                        vTitulo1 += "Record de venta por cliente/artículo "
                    ElseIf rbFormato2.Checked Then
                        oReporte = oReporte13
                        vTitulo1 += "Record de venta por artículo/cliente "
                    Else
                        oReporte = oReporte7
                        vTitulo1 += "Venta por artículo "
                    End If

                    If rbResumen.Checked Then
                        oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                        vTitulo1 = "Resumen - " & vTitulo1 & " Al : " & dtpFechaInicial.Text & " - " & dtpFechaFinal.Text
                    Else
                        oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "false"
                        vTitulo1 = "Detalle - " & vTitulo1 & " Al : " & dtpFechaInicial.Text & " - " & dtpFechaFinal.Text
                    End If
                    vFiltroProcedimiento += " and FECHA>='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Value) & "' and FECHA<='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaFinal.Value) & "'"
                Case 500 ' frmTrasladoEntreAlmacenes
                    NombreProcedimiento = Ladisac.DA.SPNames.spTrasladoEntreAlmacenesXML
                    vTitulo1 += "Reporte de Traslado Entre Almacenes"
                    oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"
                    vDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                    If txtALM_ID.Text.Trim = "" Then
                        vTitulo3 &= "   -   " & lblALM_ID.Text & " : TODAS"
                    Else
                        vTitulo3 &= "   -   " & lblALM_ID.Text & " : " & txtALM_DESCRIPCION.Text
                    End If
                    If txtALM_ID_LLEGADA.Text.Trim = "" Then
                        vTitulo3 &= "   -   " & lblALM_ID_LLEGADA.Text & " : TODAS"
                    Else
                        vTitulo3 &= "   -   " & lblALM_ID_LLEGADA.Text & " : " & txtALM_DESCRIPCION_LLEGADA.Text
                    End If

                    vFiltroProcedimiento += " and DES_FEC_EMI >= '" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Value) & "' and DES_FEC_EMI <= '" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaFinal.Value) & "'"
                    If chkResumenDetalle.CheckState Then
                        oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                        vTitulo1 += " - Resumen"
                    Else
                        oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "False"
                        vTitulo1 += " - Detalle"
                    End If
                Case 400 ' frmToneladasMillaresVentas
                    'NombreProcedimiento = Ladisac.DA.SPNames.spKardexDocumentoPesosNuevoXML
                    NombreProcedimiento = Ladisac.DA.SPNames.spKardexDocumentoPesosNuevo1XML
                    vTitulo1 += "Reporte de Toneladas/Millares " & lblPER_ID.Text
                    oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"
                    vPER_ID = DBNull.Value

                    If txtPER_ID_CLI.Text.Trim = "" Then
                        vTitulo3 &= "   -   " & lblPER_ID.Text & " : TODAS"
                    Else
                        vTitulo3 &= "   -   " & lblPER_ID.Text & " : " & txtPER_DESCRIPCION_CLI.Text
                        If rbGuias.Checked Then
                            oReporte = oReporte3
                            vFiltroProcedimiento += " AND PER_ID_VEN='" & txtPER_ID_CLI.Text & "'"
                        Else
                            oReporte = oReporte10
                            vFiltroProcedimiento += " AND PER_ID_CLI='" & txtPER_ID_CLI.Text & "'"
                        End If
                    End If

                    vFiltroProcedimiento += " and FECHA>='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Value) & "' and FECHA<='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaFinal.Value) & "'"
                    If rbResumen.Checked Then
                        oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                        vTitulo1 += " - Resumen"
                    Else
                        oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "False"
                        vTitulo1 += " - Detalle"
                    End If
                Case 300 ' frmEntregaDespachos
                    If chkFormato.CheckState = CheckState.Checked Then
                        NombreProcedimiento = Ladisac.DA.SPNames.spKardexDocumentoDespachoPuntoVentaXML
                        oReporte.DataDefinition.FormulaFields("OcultarVendedor").Text = "True"
                        If chkResumenDetalle.Checked Then
                            vTitulo1 = "Guías/Nota Crédito/Nota Debito, Emitidas de Facturas/Boletas por Punto Venta " & txtPVE_DESCRIPCION.Text & " - Resumen"
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                        Else
                            vTitulo1 = "Guías/Nota Crédito/Nota Debito, Emitidas de Facturas/Boletas por Punto Venta " & txtPVE_DESCRIPCION.Text & " - Detalle"
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "False"
                        End If
                    Else
                        If chkResumenDetalle.Checked Then
                            vTitulo1 = "Guías/Nota Crédito/Nota Debito, Emitidas de Facturas/Boletas por Vendedor - Resumen"
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                        Else
                            vTitulo1 = "Guías/Nota Crédito/Nota Debito, Emitidas de Facturas/Boletas por Vendedor - Detalle"
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "False"
                        End If
                    End If

                    vFiltroProcedimiento += " AND DDO_CANTIDAD_MOVIDA_DESPACHO<>0 "
                    oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"
                    oReporte.DataDefinition.FormulaFields("TipoPersona").Text = "'Vendedor'"
                    vPER_ID = DBNull.Value
                    If txtPER_ID_CLI.Text.Trim = "" Then
                        vTitulo3 &= "   -   " & lblPER_ID.Text & " : TODAS"
                    Else
                        vTitulo3 &= "   -   " & lblPER_ID.Text & " : " & txtPER_DESCRIPCION_CLI.Text
                        vFiltroProcedimiento += " AND PER_ID_VEN='" & txtPER_ID_CLI.Text & "'"
                    End If

                    Select Case chkFiltrarXFechas.CheckState
                        Case CheckState.Checked
                            vTitulo3 &= " Fechas : " & dtpFechaInicial.Text & "  Al  " & dtpFechaFinal.Text
                            vFiltroProcedimiento += " and FECHA>='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Value) & "' and FECHA<='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaFinal.Value) & "'"
                        Case CheckState.Unchecked
                            vTitulo3 &= " Fechas : Todas"
                    End Select
                Case Else ' 100,200 ' frmKardexDocumento,frmPendientesAtencion
                    If chkMostrarDirecciones.Checked Then
                        oReporte = oReporte5
                    Else
                        If chkMostrarValorizado.Checked Then
                            oReporte = oReporte6
                        Else
                            If pComportamientoFormulario = 200 Then
                                If chkResumenDetalle.Checked Then
                                    NombreProcedimiento = Ladisac.DA.SPNames.spKardexDocumentoDespachoNuevo3XML
                                    If rbPendientesAtencionVendedorXArtículo.Checked Then
                                        oReporte = oReporte14
                                    Else
                                        oReporte = oReporte11
                                    End If
                                Else
                                    oReporte = oReporte1
                                End If
                            Else
                                oReporte = oReporte1
                            End If
                        End If
                    End If
                    If pComportamientoFormulario = 200 Then
                        oReporte.DataDefinition.FormulaFields("OcultarParaPendienteAtencion").Text = "True"
                    End If
                    If rbPendientesAtencion.Checked Then
                        oReporte.DataDefinition.FormulaFields("OcultarGrupoLinea").Text = "False"
                        If chkResumenDetalle.Checked Then
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                            If pComportamientoFormulario = 200 Then
                                vTitulo1 = "Resumen de Documentos de Venta Pendiente de Atención Al : " & dtpFechaInicial.Value
                            Else
                                vTitulo1 = "Resumen de Documentos de Venta Pendiente de Atención Al : " & IBCMaestro.EjecutarVista("spFechaServidor")
                            End If
                        Else
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "false"
                            If pComportamientoFormulario = 200 Then
                                vTitulo1 = "Detalle de Documentos de Venta Pendiente de Atención Al : " & dtpFechaInicial.Value
                            Else
                                vTitulo1 = "Detalle de Documentos de Venta Pendiente de Atención Al : " & IBCMaestro.EjecutarVista("spFechaServidor")
                            End If
                        End If
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"
                        oReporte.DataDefinition.FormulaFields("TipoPersona").Text = "''"
                        vPER_ID = RetornarDatoBusqueda(txtPER_ID_CLI.Text.Trim, False)
                        If txtPER_ID_CLI.Text.Trim = "" Then
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : TODAS"
                        Else
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : " & txtPER_DESCRIPCION_CLI.Text
                        End If

                        If pComportamientoFormulario = 200 Then
                            If txtPVE_ID.Text.Trim = "" Then
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : TODAS"
                            Else
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : " & txtPVE_DESCRIPCION.Text
                                vFiltroProcedimiento += " AND PVE_ID_DES='" & txtPVE_ID.Text & "'"
                            End If
                            Select Case Me.SessionService.NombreEmpresa
                                Case "Ladrillera El Diamante SAC"
                                    vFiltroProcedimiento += " AND PER_ID_CLI<>'041603'"
                                    vTitulo2 += " - No se considera al cliente 041603 "
                            End Select
                        End If
                    ElseIf rbPendientesAtencionCliente.Checked Then
                        oReporte.DataDefinition.FormulaFields("OcultarGrupoLinea").Text = "True"
                        If chkResumenDetalle.Checked Then
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                            If pComportamientoFormulario = 200 Then
                                vTitulo1 = "Resumen de Documentos de Venta Pendiente de Atención por Cliente Al : " & dtpFechaInicial.Value
                            Else
                                vTitulo1 = "Resumen de Documentos de Venta Pendiente de Atención por Cliente Al : " & IBCMaestro.EjecutarVista("spFechaServidor")
                            End If
                        Else
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "false"
                            If pComportamientoFormulario = 200 Then
                                vTitulo1 = "Detalle de Documentos de Venta Pendiente de Atención por Cliente Al : " & dtpFechaInicial.Value
                            Else
                                vTitulo1 = "Detalle de Documentos de Venta Pendiente de Atención por Cliente Al : " & IBCMaestro.EjecutarVista("spFechaServidor")
                            End If
                        End If
                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"
                        oReporte.DataDefinition.FormulaFields("TipoPersona").Text = "'Cliente'"
                        vPER_ID = RetornarDatoBusqueda(txtPER_ID_CLI.Text.Trim, False)
                        If txtPER_ID_CLI.Text.Trim = "" Then
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : TODAS"
                        Else
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : " & txtPER_DESCRIPCION_CLI.Text
                        End If

                        If pComportamientoFormulario = 200 Then
                            If txtPVE_ID.Text.Trim = "" Then
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : TODAS"
                            Else
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : " & txtPVE_DESCRIPCION.Text
                                vFiltroProcedimiento += " AND PVE_ID_DES='" & txtPVE_ID.Text & "'"
                            End If
                            Select Case Me.SessionService.NombreEmpresa
                                Case "Ladrillera El Diamante SAC"
                                    vFiltroProcedimiento += " AND PER_ID_CLI<>'041603'"
                                    vTitulo2 += " - No se considera al cliente 041603 "
                            End Select
                        End If
                    ElseIf rbPendientesAtencionVendedor.Checked Then
                        oReporte.DataDefinition.FormulaFields("OcultarGrupoLinea").Text = "True"
                        If chkResumenDetalle.Checked Then
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                            vTitulo1 = "Resumen - "
                        Else
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "false"
                            vTitulo1 = "Detalle - "
                        End If

                        If pComportamientoFormulario = 200 Then
                            vTitulo1 &= "Documentos de Venta Pendiente de Atención por Vendedor Al : " & dtpFechaInicial.Value
                        Else
                            vTitulo1 &= "Documentos de Venta Pendiente de Atención por Vendedor Al : " & IBCMaestro.EjecutarVista("spFechaServidor")
                        End If

                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"

                        oReporte.DataDefinition.FormulaFields("TipoPersona").Text = "'Vendedor'"
                        vPER_ID = DBNull.Value
                        If txtPER_ID_CLI.Text.Trim = "" Then
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : TODAS"
                        Else
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : " & txtPER_DESCRIPCION_CLI.Text
                            vFiltroProcedimiento += " AND PER_ID_VEN='" & txtPER_ID_CLI.Text & "'"
                        End If
                        If pComportamientoFormulario = 200 Then
                            If txtPVE_ID.Text.Trim = "" Then
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : TODAS"
                            Else
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : " & txtPVE_DESCRIPCION.Text
                                vFiltroProcedimiento += " AND PVE_ID_DES='" & txtPVE_ID.Text & "'"
                            End If
                            Select Case Me.SessionService.NombreEmpresa
                                Case "Ladrillera El Diamante SAC"
                                    vFiltroProcedimiento += " AND PER_ID_VEN<>'048253' AND PER_ID_CLI<>'041603' "
                                    vTitulo2 += " - No se considera al cliente 041603 "
                                    vTitulo3 += " - No se considera al vendedor 048253 "
                            End Select
                        End If
                    ElseIf rbPendientesAtencionVendedorXArtículo.Checked Then
                        If chkResumenDetalle.Checked Then
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "True"
                            vTitulo1 = "Resumen - "
                        Else
                            oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "false"
                            vTitulo1 = "Detalle - "
                        End If

                        If pComportamientoFormulario = 200 Then
                            vTitulo1 &= "Documentos de Venta Pendiente de Atención por Vendedor Al : " & dtpFechaInicial.Value
                        Else
                            vTitulo1 &= "Documentos de Venta Pendiente de Atención por Vendedor Al : " & IBCMaestro.EjecutarVista("spFechaServidor")
                        End If

                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"

                        oReporte.DataDefinition.FormulaFields("TipoPersona").Text = "'Vendedor'"
                        vPER_ID = DBNull.Value
                        If txtPER_ID_CLI.Text.Trim = "" Then
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : TODAS"
                        Else
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : " & txtPER_DESCRIPCION_CLI.Text
                            vFiltroProcedimiento += " AND PER_ID_VEN='" & txtPER_ID_CLI.Text & "'"
                        End If
                        If pComportamientoFormulario = 200 Then
                            If txtPVE_ID.Text.Trim = "" Then
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : TODAS"
                            Else
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : " & txtPVE_DESCRIPCION.Text
                                vFiltroProcedimiento += " AND PVE_ID_DES='" & txtPVE_ID.Text & "'"
                            End If
                            Select Case Me.SessionService.NombreEmpresa
                                Case "Ladrillera El Diamante SAC"
                                    vFiltroProcedimiento += " AND PER_ID_VEN<>'048253' AND PER_ID_CLI<>'041603' "
                                    vTitulo2 += " - No se considera al cliente 041603 "
                                    vTitulo3 += " - No se considera al vendedor 048253 "
                            End Select
                        End If
                    Else
                        If chkMostrarDirecciones.Checked Then
                            vTitulo1 = "Reporte de Kardex de Documento con Direcciones"
                        Else
                            vTitulo1 = "Reporte de Kardex de Documento"
                        End If
                        oReporte.DataDefinition.FormulaFields("OcultarDetalle").Text = "False"
                        oReporte.DataDefinition.FormulaFields("TipoPersona").Text = "'Cliente'"
                        If chkMostrarSaldoCero.Checked Then
                            oReporte.DataDefinition.FormulaFields("OcultarSaldosCero").Text = "True"
                            vTitulo1 += "- Solo Documentos con Saldos"
                        Else
                            oReporte.DataDefinition.FormulaFields("OcultarSaldosCero").Text = "False"
                        End If

                        oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"

                        vPER_ID = RetornarDatoBusqueda(txtPER_ID.Text.Trim, False)
                        If txtPER_ID.Text.Trim = "" Then
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : TODAS"
                        Else
                            vTitulo3 &= "   -   " & lblPER_ID.Text & " : " & txtPER_DESCRIPCION.Text
                        End If
                        If pComportamientoFormulario = 200 Then
                            If txtPVE_ID.Text.Trim = "" Then
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : TODAS"
                            Else
                                vTitulo3 &= "   -   " & lblPVE_ID.Text & " : " & txtPVE_DESCRIPCION.Text
                                vFiltroProcedimiento += " AND PVE_ID_DES='" & txtPVE_ID.Text & "'"
                            End If
                        End If
                        If chkTodosDocumentos.CheckState = CheckState.Checked Then
                            vDTD_ID = "%" ' DBNull.Value
                            vDOCUMENTO = "%" ' DBNull.Value
                            vFiltroProcedimiento = " and (1=1)  "
                            vTitulo2 &= "TIPO ARTÍCULO : " & txtTIP_DESCRIPCION.Text
                            vTitulo2 &= "   -   DOCUMENTO : TODOS"
                        Else
                            vDOCUMENTO = RetornarDatoBusqueda(txtTDO_ID.Text.Trim) & _
                                         RetornarDatoBusqueda(txtDTD_ID.Text.Trim) & _
                                         RetornarDatoBusqueda(txtSerie.Text.Trim) & _
                                         RetornarDatoBusqueda(txtNumero.Text.Trim)
                        End If
                    End If
                    If pComportamientoFormulario = 200 Then
                        vFiltroProcedimiento += " AND FECHA<='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Value) & " '"
                    End If
            End Select

            oReporte.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & Me.SessionService.NombreEmpresa & "'"
            oReporte.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & Me.SessionService.RUCEmpresa & "'"

            Dim sr As Object
            Select Case pComportamientoFormulario
                Case 800 ' frmReporteGuiasProduccion
                    IBCDespachos.ReporteGuiasProduccionXLS(dtpFechaInicial.Value, dtpFechaFinal.Value, vPVE_ID)
                    Exit Sub
                Case 700 ' frmReporteGuias
                    sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, dtpFechaInicial.Value, dtpFechaFinal.Value, vPVE_ID))
                Case 600 ' frmDetalleVentaPorArticulo
                    sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vTIP_ID, vDTD_ID, vCCT_ID, vPER_ID, vDOCUMENTO, vFiltroProcedimiento))
                Case 500 ' frmTrasladoEntreAlmacenes
                    sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vDTD_ID, vALM_ID, vALM_ID_LLEGADA, vFiltroProcedimiento))
                Case 400 ' frmToneladasMillaresVentas
                    sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vTIP_ID, vDTD_ID, vCCT_ID, vPER_ID, vDOCUMENTO, vFiltroProcedimiento))
                Case 300 ' frmEntregaDespachos
                    If chkFormato.CheckState = CheckState.Checked Then
                        sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vTIP_ID, vDTD_ID, vCCT_ID, vPER_ID, vDOCUMENTO, vFiltroProcedimiento, DBNull.Value, txtPVE_ID.Text))
                    Else
                        sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vTIP_ID, vDTD_ID, vCCT_ID, vPER_ID, vDOCUMENTO, vFiltroProcedimiento, DBNull.Value))
                    End If
                Case 200 ' frmPendientesAtencion
                    sr = New StringReader(IBCMaestro.EjecutarPendienteAtencion(NombreProcedimiento, vTIP_ID, vDTD_ID, vCCT_ID, vPER_ID, vDOCUMENTO, vFiltroProcedimiento, "TRUE"))
                Case 100 ' frmKardexDocumento
                    sr = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vTIP_ID, vDTD_ID, vCCT_ID, vPER_ID, vDOCUMENTO, vFiltroProcedimiento, DBNull.Value))
            End Select

            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                dgvDatos.DataSource = ds.Tables(0)
                Dim tableImprimir As New DataTable("Imprimir")

                Select Case pComportamientoFormulario
                    Case 500 ' frmTrasladoEntreAlmacenes
                        tableImprimir.Columns.Add("TDO_ID", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("TDO_DESCRIPCION", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DTD_ID", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DTD_DESCRIPCION", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("CCT_ID", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("CCT_DESCRIPCION", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DTD_CARGO_ABONO", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DTD_SIGNO", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DTD_SIGNO_D", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DES_FEC_EMI", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DES_FEC_TRA", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("PVE_ID", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("PVE_DESCRIPCION", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("PVE_DIRECCION", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("ALM_ID", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("ALM_DESCRIPCION", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("ALM_DIRECCION", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("ALM_ID_LLEGADA", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("ALM_DESCRIPCION_LLEGADA", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("ALM_DIRECCION_LLEGADA", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DES_SERIE", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DES_NUMERO", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DDE_ITEM", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("ART_ID_KAR", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("ART_DESCRIPCION_KAR", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DDE_CANTIDAD", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DDE_ESTADO", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DES_ESTADO", Type.GetType("System.String"))
                        For filas = 0 To dgvDatos.Rows.Count - 1
                            tableImprimir.Rows.Add(
                            dgvDatos.Rows(filas).Cells("TDO_ID").Value,
                            dgvDatos.Rows(filas).Cells("TDO_DESCRIPCION").Value,
                            dgvDatos.Rows(filas).Cells("DTD_ID").Value,
                            dgvDatos.Rows(filas).Cells("DTD_DESCRIPCION").Value,
                            dgvDatos.Rows(filas).Cells("CCT_ID").Value,
                            dgvDatos.Rows(filas).Cells("CCT_DESCRIPCION").Value,
                            dgvDatos.Rows(filas).Cells("DTD_CARGO_ABONO").Value,
                            dgvDatos.Rows(filas).Cells("DTD_SIGNO").Value,
                            dgvDatos.Rows(filas).Cells("DTD_SIGNO_D").Value,
                            dgvDatos.Rows(filas).Cells("DES_FEC_EMI").Value,
                            dgvDatos.Rows(filas).Cells("DES_FEC_TRA").Value,
                            dgvDatos.Rows(filas).Cells("PVE_ID").Value,
                            dgvDatos.Rows(filas).Cells("PVE_DESCRIPCION").Value,
                            dgvDatos.Rows(filas).Cells("PVE_DIRECCION").Value,
                            dgvDatos.Rows(filas).Cells("ALM_ID").Value,
                            dgvDatos.Rows(filas).Cells("ALM_DESCRIPCION").Value,
                            dgvDatos.Rows(filas).Cells("ALM_DIRECCION").Value,
                            dgvDatos.Rows(filas).Cells("ALM_ID_LLEGADA").Value,
                            dgvDatos.Rows(filas).Cells("ALM_DESCRIPCION_LLEGADA").Value,
                            dgvDatos.Rows(filas).Cells("ALM_DIRECCION_LLEGADA").Value,
                            dgvDatos.Rows(filas).Cells("DES_SERIE").Value,
                            dgvDatos.Rows(filas).Cells("DES_NUMERO").Value,
                            dgvDatos.Rows(filas).Cells("DDE_ITEM").Value,
                            dgvDatos.Rows(filas).Cells("ART_ID_KAR").Value,
                            dgvDatos.Rows(filas).Cells("ART_DESCRIPCION_KAR").Value,
                            dgvDatos.Rows(filas).Cells("DDE_CANTIDAD").Value,
                            dgvDatos.Rows(filas).Cells("DDE_ESTADO").Value,
                            dgvDatos.Rows(filas).Cells("DES_ESTADO").Value
                                                )
                        Next
                    Case 400 ' frmToneladasMillaresVentas
                        tableImprimir.Columns.Add("Documento", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("TDO_ID_DOC", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("TDO_DESCRIPCION_DOC", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DTD_ID_DOC", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Dtd_Descripcion_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Cct_Id_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Cct_Descripcion_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Doc_Serie_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Doc_Numero_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Pve_Id_Des", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Pve_Descripcion_Des", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Per_Id_Cli", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Per_Descripcion_Cli", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Fecha", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Fecha_Traslado", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Tdo_Id", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Tdo_Descripcion", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Dtd_Id", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Dtd_Descripcion", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Serie", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Numero", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Ddo_Item", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Art_Id_Kar", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Art_Descripcion_Kar", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Ddo_Cantidad_Vendida", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("DDO_CANTIDAD_MOVIDA_DESPACHO", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("DDO_CANTIDAD_MOVIDA_DEVOLUCION", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("ImporteConTransporte", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("ImporteSinTransporte", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("Subvencion", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("Per_Id_Ven", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Per_Descripcion_Ven", Type.GetType("System.String"))
                        For filas = 0 To dgvDatos.Rows.Count - 1
                            tableImprimir.Rows.Add(
                                dgvDatos.Rows(filas).Cells("Documento").Value, _
                                dgvDatos.Rows(filas).Cells("TDO_ID_DOC").Value, _
                                dgvDatos.Rows(filas).Cells("TDO_DESCRIPCION_DOC").Value, _
                                dgvDatos.Rows(filas).Cells("DTD_ID_DOC").Value, _
                                dgvDatos.Rows(filas).Cells("Dtd_Descripcion_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Cct_Id_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Cct_Descripcion_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Doc_Serie_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Doc_Numero_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Pve_Id_Des").Value, _
                                dgvDatos.Rows(filas).Cells("Pve_Descripcion_Des").Value, _
                                dgvDatos.Rows(filas).Cells("Per_Id_Cli").Value, _
                                dgvDatos.Rows(filas).Cells("Per_Descripcion_Cli").Value, _
                                CDate(dgvDatos.Rows(filas).Cells("Fecha").Value), _
                                CDate(dgvDatos.Rows(filas).Cells("Fecha_Traslado").Value), _
                                dgvDatos.Rows(filas).Cells("Tdo_Id").Value, _
                                dgvDatos.Rows(filas).Cells("Tdo_Descripcion").Value, _
                                dgvDatos.Rows(filas).Cells("Dtd_Id").Value, _
                                dgvDatos.Rows(filas).Cells("Dtd_Descripcion").Value, _
                                dgvDatos.Rows(filas).Cells("Serie").Value, _
                                dgvDatos.Rows(filas).Cells("Numero").Value, _
                                dgvDatos.Rows(filas).Cells("Ddo_Item").Value, _
                                dgvDatos.Rows(filas).Cells("Art_Id_Kar").Value, _
                                dgvDatos.Rows(filas).Cells("Art_Descripcion_Kar").Value, _
                                CDec(dgvDatos.Rows(filas).Cells("Ddo_Cantidad_Vendida").Value), _
                                CDec(dgvDatos.Rows(filas).Cells("DDO_CANTIDAD_MOVIDA_DESPACHO").Value), _
                                CDec(dgvDatos.Rows(filas).Cells("DDO_CANTIDAD_MOVIDA_DEVOLUCION").Value), _
                                CDec(dgvDatos.Rows(filas).Cells("ImporteConTransporte").Value), _
                                CDec(dgvDatos.Rows(filas).Cells("ImporteSinTransporte").Value), _
                                CDec(dgvDatos.Rows(filas).Cells("Subvencion").Value), _
                                dgvDatos.Rows(filas).Cells("Per_Id_Ven").Value, _
                                dgvDatos.Rows(filas).Cells("Per_Descripcion_Ven").Value
                                                )
                        Next
                    Case 300, 200, 100 ' frmEntregaDespachos, frmPendientesAtencion, frmKardexDocumento
                        tableImprimir.Columns.Add("Documento", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("TDO_ID_DOC", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("TDO_DESCRIPCION_DOC", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DTD_ID_DOC", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Dtd_Descripcion_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Cct_Id_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Cct_Descripcion_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Doc_Serie_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Doc_Numero_Doc", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Pve_Id_Des", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Pve_Descripcion_Des", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Per_Id_Cli", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Per_Descripcion_Cli", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Fecha", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Fecha_Traslado", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Tdo_Id", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Tdo_Descripcion", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Dtd_Id", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Dtd_Descripcion", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Serie", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Numero", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Ddo_Item", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Art_Id_Kar", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Art_Descripcion_Kar", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Ddo_Cantidad_Vendida", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("DDO_CANTIDAD_MOVIDA_DESPACHO", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("DDO_CANTIDAD_MOVIDA_DEVOLUCION", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("ImporteConIgv", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("ImporteSinIgv", Type.GetType("System.Decimal"))
                        tableImprimir.Columns.Add("Per_Id_Ven", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Per_Descripcion_Ven", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("DireccionEntrega", Type.GetType("System.String"))
                        tableImprimir.Columns.Add("Transportista", Type.GetType("System.String"))
                        For filas = 0 To dgvDatos.Rows.Count - 1
                            tableImprimir.Rows.Add(
                                dgvDatos.Rows(filas).Cells("Documento").Value, _
                                dgvDatos.Rows(filas).Cells("TDO_ID_DOC").Value, _
                                dgvDatos.Rows(filas).Cells("TDO_DESCRIPCION_DOC").Value, _
                                dgvDatos.Rows(filas).Cells("DTD_ID_DOC").Value, _
                                dgvDatos.Rows(filas).Cells("Dtd_Descripcion_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Cct_Id_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Cct_Descripcion_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Doc_Serie_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Doc_Numero_Doc").Value, _
                                dgvDatos.Rows(filas).Cells("Pve_Id_Des").Value, _
                                dgvDatos.Rows(filas).Cells("Pve_Descripcion_Des").Value, _
                                dgvDatos.Rows(filas).Cells("Per_Id_Cli").Value, _
                                dgvDatos.Rows(filas).Cells("Per_Descripcion_Cli").Value, _
                                CDate(dgvDatos.Rows(filas).Cells("Fecha").Value), _
                                CDate(dgvDatos.Rows(filas).Cells("Fecha_Traslado").Value), _
                                dgvDatos.Rows(filas).Cells("Tdo_Id").Value, _
                                dgvDatos.Rows(filas).Cells("Tdo_Descripcion").Value, _
                                dgvDatos.Rows(filas).Cells("Dtd_Id").Value, _
                                dgvDatos.Rows(filas).Cells("Dtd_Descripcion").Value, _
                                dgvDatos.Rows(filas).Cells("Serie").Value, _
                                dgvDatos.Rows(filas).Cells("Numero").Value, _
                                dgvDatos.Rows(filas).Cells("Ddo_Item").Value, _
                                dgvDatos.Rows(filas).Cells("Art_Id_Kar").Value, _
                                dgvDatos.Rows(filas).Cells("Art_Descripcion_Kar").Value, _
                                CDec(dgvDatos.Rows(filas).Cells("Ddo_Cantidad_Vendida").Value), _
                                CDec(dgvDatos.Rows(filas).Cells("DDO_CANTIDAD_MOVIDA_DESPACHO").Value), _
                                CDec(dgvDatos.Rows(filas).Cells("DDO_CANTIDAD_MOVIDA_DEVOLUCION").Value), _
                                CDec(dgvDatos.Rows(filas).Cells("ImporteConIgv").Value), _
                                CDec(dgvDatos.Rows(filas).Cells("ImporteSinIgv").Value), _
                                dgvDatos.Rows(filas).Cells("Per_Id_Ven").Value, _
                                dgvDatos.Rows(filas).Cells("Per_Descripcion_Ven").Value, _
                                dgvDatos.Rows(filas).Cells("DireccionEntrega").Value, _
                                dgvDatos.Rows(filas).Cells("Transportista").Value
                                                )
                        Next
                End Select
                'DataGridView1.DataSource = tableImprimir
                oReporte.Database.Tables(0).SetDataSource(ds.Tables(0))
                oReporte.DataDefinition.FormulaFields("Titulo1").Text = "'" & vTitulo1 & "'"
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

        'Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean

        '    'Creamos las variables

        '    Dim exApp As New Microsoft.Office.Interop.Excel.Application

        '    Dim exLibro As Microsoft.Office.Interop.Excel.Workbook

        '    Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        '    Try

        '        'Añadimos el Libro al programa, y la hoja al libro

        '        exLibro = exApp.Workbooks.Add

        '        exHoja = exLibro.Worksheets.Add()

        '        ' ¿Cuantas columnas y cuantas filas?

        '        Dim NCol As Integer = ElGrid.ColumnCount

        '        Dim NRow As Integer = ElGrid.RowCount

        '        'Aqui recorremos todas las filas, y por cada fila todas las columnas

        '        'y vamos escribiendo.

        '        For i As Integer = 1 To NCol

        '  exHoja.Cells.Item(1, i) = ElGrid.Columns(i – 1).Name.ToString

        '        Next

        ' For Fila As Integer = 0 To NRow – 1

        '      For Col As Integer = 0 To NCol – 1

        '           exHoja.Cells.Item(Fila + 2, Col + 1) = _

        '                ElGrid.Rows(Fila).Cells(Col).Value()

        '            Next

        '        Next

        '        'Titulo en negrita, Alineado al centro y que el tamaño de la columna

        '        'se ajuste al texto

        '        exHoja.Rows.Item(1).Font.Bold = 1

        '        exHoja.Rows.Item(1).HorizontalAlignment = 3

        '        exHoja.Columns.AutoFit()

        '        'Aplicación visible

        '        exApp.Application.Visible = True

        '        exHoja = Nothing

        '        exLibro = Nothing

        '        exApp = Nothing

        '    Catch ex As Exception

        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")

        '        Return False

        '    End Try

        '    Return True

        'End Function

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

        Private Sub chkFiltrarXFechas_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltrarXFechas.CheckStateChanged
            Select Case chkFiltrarXFechas.CheckState
                Case CheckState.Checked
                    chkFiltrarXFechas.Text = "Filtrar por fechas"
                    dtpFechaInicial.Enabled = True
                    dtpFechaFinal.Enabled = True
                Case CheckState.Unchecked
                    chkFiltrarXFechas.Text = "No filtrar por fechas"
                    dtpFechaInicial.Enabled = False
                    dtpFechaFinal.Enabled = False
                Case Else
            End Select
        End Sub

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

        'Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        '    Handles chkPendientesAtencion.CheckedChanged, _
        '            chkPendientesAtencionCliente.CheckedChanged, _
        '            chkPendientesAtencionVendedor.CheckedChanged
        '    Dim vVisibleCliente As Boolean
        '    Dim vVisiblePersona As Boolean
        '    Dim vVisibleTipoDocumento As Boolean

        '    Select Case pComportamientoFormulario
        '        Case 500 ' frmTrasladoEntreAlmacenes
        '            vVisibleCliente = False
        '            vVisiblePersona = False
        '        Case 400 ' frmToneladasMillaresVentas
        '            vVisibleCliente = True
        '            vVisiblePersona = False
        '            vVisibleTipoDocumento = False
        '        Case 200 ' frmPendientesAtencion
        '            vVisibleCliente = True
        '            vVisiblePersona = False
        '            vVisibleTipoDocumento = False
        '        Case Else '300,100  frmEntregaDespachos,frmKardexDocumento
        '            vVisibleCliente = True
        '            vVisiblePersona = False
        '            vVisibleTipoDocumento = True
        '    End Select

        '    Select Case sender.name
        '        Case "chkPendientesAtencion"
        '            If sender.CheckState = CheckState.Checked Then

        '            Else
        '                'chkPendientesAtencionVendedor.CheckState = CheckState.Unc
        '                'chkPendientesAtencionCliente.CheckState = CheckState.Checked
        '            End If
        '            lblPER_ID.Text = ""

        '            txtPER_ID_CLI.Visible = False
        '            txtPER_DESCRIPCION_CLI.Visible = False

        '            txtPER_ID.Visible = False
        '            txtPER_DESCRIPCION.Visible = False

        '            lblDTD_ID.Visible = vVisibleTipoDocumento
        '            txtDTD_ID.Visible = vVisibleTipoDocumento
        '            txtDTD_DESCRIPCION.Visible = vVisibleTipoDocumento

        '            txtSerie.Visible = False
        '            txtNumero.Visible = False

        '            chkTodosDocumentos.Visible = False

        '            chkTodosDocumentos.CheckState = CheckState.Unchecked
        '            chkPendientesAtencionVendedor.CheckState = CheckState.Unchecked

        '            EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " "
        '        Case "chkPendientesAtencionCliente"
        '            If sender.CheckState = CheckState.Checked Then
        '                lblPER_ID.Text = "Cliente"

        '                txtPER_ID_CLI.Visible = True
        '                txtPER_DESCRIPCION_CLI.Visible = True

        '                txtPER_ID.Visible = False
        '                txtPER_DESCRIPCION.Visible = False

        '                lblDTD_ID.Visible = vVisibleTipoDocumento
        '                txtDTD_ID.Visible = vVisibleTipoDocumento
        '                txtDTD_DESCRIPCION.Visible = vVisibleTipoDocumento

        '                txtSerie.Visible = False
        '                txtNumero.Visible = False

        '                chkTodosDocumentos.Visible = False

        '                chkTodosDocumentos.CheckState = CheckState.Checked
        '                chkPendientesAtencionVendedor.CheckState = CheckState.Unchecked

        '                EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_CLIENTE='SI' and TPE_CLIENTE='SI')"
        '            Else
        '                chkPendientesAtencionVendedor.CheckState = CheckState.Checked
        '            End If
        '        Case "chkPendientesAtencionVendedor"
        '            If sender.CheckState = CheckState.Checked Then
        '                lblPER_ID.Text = "Vendedor"
        '                lblPER_ID.Visible = vVisibleCliente

        '                txtPER_ID_CLI.Visible = vVisibleCliente
        '                txtPER_DESCRIPCION_CLI.Visible = vVisibleCliente

        '                txtPER_ID.Visible = vVisiblePersona
        '                txtPER_DESCRIPCION.Visible = vVisiblePersona

        '                lblDTD_ID.Visible = vVisibleTipoDocumento
        '                txtDTD_ID.Visible = vVisibleTipoDocumento
        '                txtDTD_DESCRIPCION.Visible = vVisibleTipoDocumento

        '                txtSerie.Visible = False
        '                txtNumero.Visible = False

        '                chkTodosDocumentos.Visible = False

        '                chkTodosDocumentos.CheckState = CheckState.Checked
        '                chkPendientesAtencionCliente.CheckState = CheckState.Unchecked
        '                EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_TRABAJADOR='SI' and TPE_TRABAJADOR='SI')"
        '            Else
        '                chkPendientesAtencionCliente.CheckState = CheckState.Checked
        '            End If
        '    End Select
        'End Sub

        Private Sub chkTodosDocumentos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles chkTodosDocumentos.CheckedChanged
            If sender.CheckState = CheckState.Checked Then
                'lblDTD_ID.Visible = False
                txtDTD_ID.Enabled = False
                txtDTD_DESCRIPCION.Enabled = False
                txtDTD_ID.ForeColor = System.Drawing.SystemColors.Control
                txtDTD_DESCRIPCION.ForeColor = System.Drawing.SystemColors.Control
                lblDOCUMENTO.Visible = False
                txtSerie.Visible = False
                txtNumero.Visible = False
                Select Case pComportamientoFormulario
                    Case 100 ' frmKardexDocumento
                        chkMostrarSaldoCero.CheckState = CheckState.Unchecked
                        chkMostrarSaldoCero.Visible = True
                        chkMostrarSaldoCero.Enabled = True
                        chkMostrarSaldoCero.Location = New System.Drawing.Point(95, 124)
                End Select
            Else
                'lblDTD_ID.Visible = True
                txtDTD_ID.Enabled = True
                txtDTD_DESCRIPCION.Enabled = True
                txtDTD_ID.ForeColor = System.Drawing.SystemColors.WindowText
                txtDTD_DESCRIPCION.ForeColor = System.Drawing.SystemColors.WindowText
                lblDOCUMENTO.Visible = True
                txtSerie.Visible = True
                txtNumero.Visible = True
                Select Case pComportamientoFormulario
                    Case 100 ' frmKardexDocumento
                        chkMostrarSaldoCero.CheckState = CheckState.Unchecked
                        chkMostrarSaldoCero.Visible = False
                        chkMostrarSaldoCero.Enabled = False
                        chkMostrarSaldoCero.Location = New System.Drawing.Point(95, 211)
                End Select
            End If
        End Sub

        Private Sub chkResumenDetalle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkResumenDetalle.CheckedChanged
            If sender.CheckState = CheckState.Checked Then
                chkResumenDetalle.Text = "Resumen"
            Else
                chkResumenDetalle.Text = "Detalle"
            End If
        End Sub


        Private Sub rb_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles rbPendientesAtencion.CheckedChanged, _
                    rbPendientesAtencionCliente.CheckedChanged, _
                    rbPendientesAtencionVendedor.CheckedChanged, _
                    rbPendientesAtencionVendedorXArtículo.CheckedChanged, _
                    rbGuias.CheckedChanged, _
                    rbGuiasPorArticulo.CheckedChanged
            Dim vVisibleCliente As Boolean
            Dim vVisiblePersona As Boolean
            Dim vVisibleTipoDocumento As Boolean

            Select Case pComportamientoFormulario
                Case 500 ' frmTrasladoEntreAlmacenes
                    vVisibleCliente = False
                    vVisiblePersona = False
                Case 400 ' frmToneladasMillaresVentas
                    lblDTD_ID.Visible = False
                    txtDTD_ID.Visible = False
                    txtDTD_DESCRIPCION.Visible = False

                    lblPER_ID.Visible = True
                    txtPER_ID.Visible = False
                    txtPER_DESCRIPCION.Visible = False
                    txtPER_ID_CLI.Visible = True
                    txtPER_DESCRIPCION_CLI.Visible = True

                    If rbGuias.Checked Then
                        lblPER_ID.Text = "Vendedor"
                        EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_TRABAJADOR='SI' and TPE_TRABAJADOR='SI')"
                    Else
                        lblPER_ID.Text = "Cliente"
                        EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_CLIENTE='SI' and TPE_CLIENTE='SI')"
                    End If
                    Exit Sub
                Case 200 ' frmPendientesAtencion
                    vVisibleCliente = True
                    vVisiblePersona = False
                    vVisibleTipoDocumento = False
                Case Else '300,100  frmEntregaDespachos,frmKardexDocumento
                    vVisibleCliente = True
                    vVisiblePersona = False
                    vVisibleTipoDocumento = True
            End Select

            Select Case sender.name
                Case "rbPendientesAtencion"
                    If sender.Checked Then
                        lblPER_ID.Text = ""

                        txtPER_ID_CLI.Text = ""
                        txtPER_DESCRIPCION_CLI.Text = ""

                        txtPER_ID.Text = ""
                        txtPER_DESCRIPCION.Text = ""

                        txtPER_ID_CLI.Visible = False
                        txtPER_DESCRIPCION_CLI.Visible = False

                        txtPER_ID.Visible = False
                        txtPER_DESCRIPCION.Visible = False

                        lblDTD_ID.Visible = vVisibleTipoDocumento
                        txtDTD_ID.Visible = vVisibleTipoDocumento
                        txtDTD_DESCRIPCION.Visible = vVisibleTipoDocumento

                        txtSerie.Visible = False
                        txtNumero.Visible = False

                        chkTodosDocumentos.Visible = False
                        chkTodosDocumentos.CheckState = CheckState.Checked
                        EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " "




                    End If
                Case "rbPendientesAtencionCliente"
                    If sender.Checked Then
                        lblPER_ID.Text = "Cliente"

                        txtPER_ID_CLI.Visible = True
                        txtPER_DESCRIPCION_CLI.Visible = True

                        txtPER_ID.Visible = False
                        txtPER_DESCRIPCION.Visible = False

                        lblDTD_ID.Visible = vVisibleTipoDocumento
                        txtDTD_ID.Visible = vVisibleTipoDocumento
                        txtDTD_DESCRIPCION.Visible = vVisibleTipoDocumento

                        txtSerie.Visible = False
                        txtNumero.Visible = False

                        chkTodosDocumentos.Visible = False
                        chkTodosDocumentos.CheckState = CheckState.Checked
                        EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_CLIENTE='SI' and TPE_CLIENTE='SI')"

                        ''
                        Select Case pComportamientoFormulario
                            Case 200 ' Pendientes de atención
                                'If IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTEPENDIENTESATENCION", "PVE_ID") Then
                                'Else
                                'rbPendientesAtencionVendedor.Checked = True
                                'txtPER_ID_CLI.Text = IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spCodigoPersonaPermisoUsuario, _
                                '                        SessionService.UserId)
                                'MetodoBusquedaDato(txtPER_ID_CLI.Text, True, EtxtPER_ID_CLI)
                                'ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True)
                                txtPER_ID_CLI.Enabled = True
                                txtPER_ID_CLI.ReadOnly = False
                                EtxtPER_ID_CLI.pBusqueda = True
                                'End If
                        End Select
                        ''
                    End If
                Case "rbPendientesAtencionVendedor"
                    If sender.Checked Then
                        lblPER_ID.Text = "Vendedor"
                        lblPER_ID.Visible = vVisibleCliente

                        txtPER_ID_CLI.Visible = vVisibleCliente
                        txtPER_DESCRIPCION_CLI.Visible = vVisibleCliente

                        txtPER_ID.Visible = vVisiblePersona
                        txtPER_DESCRIPCION.Visible = vVisiblePersona

                        lblDTD_ID.Visible = vVisibleTipoDocumento
                        txtDTD_ID.Visible = vVisibleTipoDocumento
                        txtDTD_DESCRIPCION.Visible = vVisibleTipoDocumento

                        txtSerie.Visible = False
                        txtNumero.Visible = False

                        chkTodosDocumentos.Visible = False
                        chkTodosDocumentos.CheckState = CheckState.Checked
                        EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_TRABAJADOR='SI' and TPE_TRABAJADOR='SI')"

                        '''
                        Select Case pComportamientoFormulario
                            Case 200 ' Pendientes de atención
                                If IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTEPENDIENTESATENCION", "PVE_ID") Then
                                Else
                                    'rbPendientesAtencionVendedor.Checked = True
                                    txtPER_ID_CLI.Text = IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spCodigoPersonaPermisoUsuario, _
                                                            SessionService.UserId)
                                    MetodoBusquedaDato(txtPER_ID_CLI.Text, True, EtxtPER_ID_CLI)
                                    ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True)
                                    'rbPendientesAtencionCliente.Enabled = False
                                    'rbPendientesAtencionCliente.Visible = False
                                End If
                        End Select
                        '''
                    End If
                Case "rbPendientesAtencionVendedorXArtículo"
                    If sender.Checked Then
                        lblPER_ID.Text = "Vendedor"
                        lblPER_ID.Visible = vVisibleCliente

                        txtPER_ID_CLI.Visible = vVisibleCliente
                        txtPER_DESCRIPCION_CLI.Visible = vVisibleCliente

                        txtPER_ID.Visible = vVisiblePersona
                        txtPER_DESCRIPCION.Visible = vVisiblePersona

                        lblDTD_ID.Visible = vVisibleTipoDocumento
                        txtDTD_ID.Visible = vVisibleTipoDocumento
                        txtDTD_DESCRIPCION.Visible = vVisibleTipoDocumento

                        txtSerie.Visible = False
                        txtNumero.Visible = False

                        chkTodosDocumentos.Visible = False
                        chkTodosDocumentos.CheckState = CheckState.Checked
                        EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " and PER_ID in (select PER_ID from vwRolPersonaTipoPersona where PER_TRABAJADOR='SI' and TPE_TRABAJADOR='SI')"
                        '''
                        Select Case pComportamientoFormulario
                            Case 200 ' Pendientes de atención
                                If IBCBusqueda.EditarCampo(SessionService.UserId, "REPORTEPENDIENTESATENCION", "PVE_ID") Then
                                Else
                                    'rbPendientesAtencionVendedor.Checked = True
                                    txtPER_ID_CLI.Text = IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spCodigoPersonaPermisoUsuario, _
                                                            SessionService.UserId)
                                    MetodoBusquedaDato(txtPER_ID_CLI.Text, True, EtxtPER_ID_CLI)
                                    ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True)
                                    'rbPendientesAtencionCliente.Enabled = False
                                    'rbPendientesAtencionCliente.Visible = False
                                End If
                        End Select
                        '''
                    End If
            End Select
        End Sub

        Private cuenta As Integer = 100
        Delegate Sub AddNumeroDelegate(ByVal number As Integer)

        Private Sub AddNumero(ByVal number As Integer)
            If txtprogreso.InvokeRequired Then
                txtprogreso.Invoke(New AddNumeroDelegate(AddressOf AddNumero), number)
            Else
                txtprogreso.AppendText("Elemento " & (number + 1).ToString() & " procesandose.." + Environment.NewLine)
            End If
        End Sub
        Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
            Try
                Dim i As Integer

                While i < cuenta
                    BackgroundWorker1.ReportProgress(100 * i / cuenta, "Procesando (" & i & "/" & cuenta & ") elementos...")
                    AddNumero(i)
                    Threading.Thread.Sleep(100)
                    i += 1
                End While
                BackgroundWorker1.ReportProgress(100, "Completado!")
                e.Result = True
            Catch ex As Exception
                e.Result = False
            End Try
        End Sub
        Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
            Try
                Me.btnIniciar.Enabled = True
            Catch ex As Exception
                Me.btnIniciar.Enabled = True
                MessageBox.Show("Excepción controlada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
            Try
                ProgressBar1.Value = e.ProgressPercentage
                lblEstado.Text = e.UserState
            Catch ex As Exception
                MessageBox.Show("Excepción controlada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnIniciar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIniciar.Click
            Try
                Me.btnIniciar.Enabled = False
                cuenta = Me.NumericUpDown1.Value
                Me.BackgroundWorker1.RunWorkerAsync()
            Catch ex As Exception
                MessageBox.Show("Excepción controlada: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 5, 8 'Personas - Cliente, PuntoVenta
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function

        Private Sub chkFormato_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFormato.CheckedChanged
            If chkFormato.CheckState = CheckState.Checked Then
                chkFormato.Text = "Por punto de venta"
            ElseIf chkFormato.CheckState = CheckState.Unchecked Then
                chkFormato.Text = "Por vendedor"
            End If
        End Sub

        Private Sub ConfigurarReadOnlyNoBusqueda(ByRef vObjeto As Object, _
                                         ByRef vStructure As Object, _
                                         ByVal vBoolean As Boolean)
            If vObjeto.GetType <> GetType(ComboBox) And _
                vObjeto.GetType <> GetType(DateTimePicker) Then
                vObjeto.ReadOnly = vBoolean 'True
            Else
                If Not IsNothing(vStructure) Then vStructure.pEnabled = Not vBoolean ' False
            End If
            vObjeto.Enabled = True
            If Not IsNothing(vStructure) Then vStructure.pBusqueda = Not vBoolean ' False
        End Sub

        Private Sub btnImprimirValorizado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirValorizado.Click
            'Me.Cursor = Cursors.WaitCursor
            Dim sr As Object
            Dim ds As New DataSet

            Dim vTIP_ID As Object = Nothing
            Dim vDTD_ID As Object = Nothing
            Dim vCCT_ID As Object = Nothing
            Dim vPER_ID As Object = Nothing
            Dim vDOCUMENTO As Object = Nothing
            Dim vFiltroProcedimiento As String
            vFiltroProcedimiento = " and FECHA<='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Value) & "' "

            sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spKardexDocumentoDespachoValorizadoXML",
                                                           "001", Nothing, "001", Nothing, Nothing, vFiltroProcedimiento, "TRUE"))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                dgvDatos.DataSource = ds.Tables(0)
                Dim Her As New Herramientas
                Her.excelExportar(Her.ToTable(dgvDatos, dtpFechaInicial.Value), dtpFechaInicial.Value)
            End If
            Me.Cursor = Cursors.Default
        End Sub

        Private Sub btnImprimirValorizadoSinComercializadora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirValorizadoSinComercializadora.Click
            ''

            'Me.Cursor = Cursors.WaitCursor
            Dim sr As Object
            Dim ds As New DataSet

            Dim vTIP_ID As Object = Nothing
            Dim vDTD_ID As Object = Nothing
            Dim vCCT_ID As Object = Nothing
            Dim vPER_ID As Object = Nothing
            Dim vDOCUMENTO As Object = Nothing
            Dim vFiltroProcedimiento As String
            vFiltroProcedimiento = " and FECHA<='" & cMisProcedimientos.FormatoFechaGenerico(dtpFechaInicial.Value) & "' "

            sr = New StringReader(IBCMaestro.EjecutarVista("dbo.spKardexDocumentoDespachoValorizado1XML",
                                                           "001", Nothing, "001", Nothing, Nothing, vFiltroProcedimiento, "TRUE"))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                dgvDatos.DataSource = ds.Tables(0)
                Dim Her As New Herramientas
                Her.excelExportar(Her.ToTable(dgvDatos, dtpFechaInicial.Value), dtpFechaInicial.Value)
            End If
            Me.Cursor = Cursors.Default

        End Sub
    End Class
End Namespace