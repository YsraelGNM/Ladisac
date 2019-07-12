Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
''
''
Namespace Ladisac.Facturacion.Views
    Public Class frmDocumentos
#Region "Primaria"


#Region "Declaraciones"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property IBCBusquedaDetalle As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Public vControlarFechaHoraEntrega As Boolean = True

        Private eConfigurarDataGridObjeto As New MisProcedimientos.ConfigurarDataGrid
        Private eRegistrosEliminar(1) As ElementosEliminar
        Private vBuscarDetalle As Boolean = True
        Private vMensajeErrorOrm As String = ""

        Private pLoaded As Boolean = True
        Private pRegistroNuevo As Boolean = False
        Private pRespuestaExtraerDetalle As Int16 = 0
        Private pColeccionDatos As Collection = Nothing
        Private pComportamiento As Int32 = 0
        Private pOrdenBusqueda As Int32 = 0
        Private pDatoBusquedaConsulta As String = ""
        Private pFlagNuevo As Boolean = False

        Private Shared vrO As Boolean = True
        Private Shared vrM As Boolean = True
        Private pLongitudId As Integer = 0
        Private pCaracterId As String = Nothing
        Private pCodigoId As String = ""

        Private pNuevo As Boolean = True
        Private pEditar As Boolean = True
        Private pCancelarEditar As Boolean = True
        Private pGrabar As Boolean = True
        Private pGrabarNuevo As Boolean = True
        Private pEliminar As Boolean = True
        Private pDeshacer As Boolean = True
        Private pAgregar As Boolean = True
        Private pQuitar As Boolean = True
        Private pBuscar As Boolean = True
        Private pInicio As Boolean = True
        Private pAnterior As Boolean = True
        Private pSiguiente As Boolean = True
        Private pFinal As Boolean = True
        Private pReportes As Boolean = True
        Private pSalida As Boolean = True

        Private vItemKardexCtaCte As Integer
        Private vItemKardexCtaCtePercepcion As Integer
        Private vItemDetalleDespachos As Integer
        Private vItemDetalleAfectaMonto As Integer
        Private vItemDetalleAfectaProducto As Integer

        Private vFlagVentaContadoBalanzaServicioEstibaje As Boolean = False

        Dim oReporte As New ReversoFTBV
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
#Region "DatagridView"
        Public Sub ConfigurarGrid(ByRef vMiDataGridView As DataGridView, _
                          ByVal ConfigurarDataGrid As MisProcedimientos.ConfigurarDataGrid)
            Select Case ConfigurarDataGrid.Metodo
                Case "SoloAlgunasColumnas"
                    ConfigurarAnchoColumnaGrid(vMiDataGridView, ConfigurarDataGrid.Array)
                Case "ElementoItem"
                    Dim vFilGrid As Int16 = 0
                    EdgvDetalle.Elementos = 0
                    While (vMiDataGridView.Rows.Count() > vFilGrid)
                        With vMiDataGridView.Rows(vFilGrid)
                            If .Cells(ConfigurarDataGrid.Columna).Value > EdgvDetalle.Elementos Then
                                EdgvDetalle.Elementos = .Cells(ConfigurarDataGrid.Columna).Value  ' Búscamos el item mayor para el correlativo
                            End If
                        End With
                        vFilGrid += 1
                    End While
            End Select
        End Sub
        Public Sub ConfigurarAnchoColumnaGrid(ByRef vMiDataGridView As DataGridView, ByVal vArray() As Integer)
            If vMiDataGridView.Name.ToString = "dgvDetalle" Then
                ReDim EdgvDetalle.Columnas(vArray.Length - 1)
                For elemento As Integer = 0 To vArray.Length - 1
                    EdgvDetalle.Columnas(elemento) = vArray(elemento).ToString
                Next elemento
            End If
        End Sub
        Private Sub KeysTab(Optional ByVal Saltos As Integer = 1)
            For vSaltos = 1 To Saltos
                SendKeys.Send(Chr(Keys.Tab))
            Next
        End Sub
#End Region
        '' ojito
#Region "ComboBox"
        Public Structure cbo
            Public Property pNombreCampo As String
            Public Property pEnabled As Boolean
            Public Property pBusqueda As Boolean
            Public Property pStyle As System.Windows.Forms.ComboBoxStyle
        End Structure
#End Region
#Region "DataTimePicker"
        Public Structure dtp
            Public Property pNombreCampo As String
            Public Property pEnabled As Boolean
            Public Property pBusqueda As Boolean
            Public Property pFormat As System.Windows.Forms.DateTimePickerFormat
        End Structure
#End Region
        '' ojito
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

            Public Property pOOrm As Object
            Public Property pFormularioConsulta As Boolean

            Public Property pComportamiento As Int16
            Public Property pOrdenBusqueda As Int16
        End Structure

        Private Sub ValidarDatos(ByRef otxt As txt, ByRef txt As TextBox, Optional ByVal Texto As String = "")
            With otxt
                If .pTexto1 <> .pTexto2 Then
                    .pTexto2 = txt.Text
                    If .pBusqueda Then
                        If Texto <> "" Then
                            MetodoBusquedaDato(Texto, True, otxt)
                        Else
                            MetodoBusquedaDato(txt.Text, True, otxt)
                        End If
                        TeclaF1SubLlamadas(txt.Name)
                    End If
                End If
                SubValidarDatos(otxt, txt)
            End With
        End Sub
        Private Sub MetodoBusquedaDato(ByVal vDatoBusqueda As String, _
                                       ByVal vBusquedaDirecta As Boolean, _
                                       ByVal vtxt As txt)

            If BloquearBusquedaCampos(vtxt) Then
                If vBusquedaDirecta Then
                    vDatoBusqueda = ""
                Else
                    Exit Sub
                End If
            End If

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

            frm.pDevolverDatosUnicoRegistro = pDevolverDatosUnicoRegistro
            frm.oOrm = vtxt.pOOrm
            frm.Comportamiento = vtxt.pComportamiento
            frm.NombreFormulario = Me
            frm.OrdenBusqueda = vOrdenBusqueda
            frm.MostrarDatosGrid = vtxt.pMostrarDatosGrid
            frm.ShowDialog()
            frm.Dispose()
        End Sub
        Private Sub TeclaF1(ByRef otxt As txt, ByRef txt As TextBox)
            If otxt.pBusqueda Then
                otxt.pTexto2 = txt.Text
                ValidarDatos(otxt, txt)
                MetodoBusquedaDato("", False, otxt)
                otxt.pTexto1 = txt.Text
                otxt.pTexto2 = txt.Text
                TeclaF1SubLlamadas(txt.Name)
            End If
        End Sub
#End Region

        Public ReadOnly Property Loaded() As Boolean
            Get
                Return pLoaded
            End Get
        End Property
        Public Property RegistroNuevo() As Boolean
            Get
                Return pRegistroNuevo
            End Get
            Set(ByVal value As Boolean)
                pRegistroNuevo = value
            End Set
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
        Public Property FlagNuevo() As Boolean
            Get
                Return pFlagNuevo
            End Get
            Set(ByVal value As Boolean)
                pFlagNuevo = value
            End Set
        End Property

        Private Structure RespuestaValidar
            Public Property rM As Boolean
                Set(ByVal value As Boolean)
                    vrM = value
                    If value = True Then vrO = rO
                    If value = False Then vrO = False
                End Set
                Get
                    Return vrM
                End Get
            End Property
            Public Property rO As Boolean
                Set(ByVal value As Boolean)
                    vrO = value
                End Set
                Get
                    Return vrO
                End Get
            End Property
        End Structure
        Public Property LongitudId() As Integer
            Get
                Return pLongitudId
            End Get
            Set(ByVal value As Integer)
                pLongitudId = value
            End Set
        End Property
        Public Property CaracterId() As String
            Get
                Return pCaracterId
            End Get
            Set(ByVal value As String)
                pCaracterId = value
            End Set
        End Property
        Public Property CodigoId() As String
            Get
                Return pCodigoId
            End Get
            Set(ByVal value As String)
                pCodigoId = value
            End Set
        End Property

        Public Property Nuevo() As Boolean
            Set(ByVal value As Boolean)
                pNuevo = value
            End Set
            Get
                Return pNuevo
            End Get
        End Property
        Public Property Editar() As Boolean
            Set(ByVal value As Boolean)
                pEditar = value
            End Set
            Get
                Return pEditar
            End Get
        End Property
        Public Property CancelarEditar() As Boolean
            Set(ByVal value As Boolean)
                pCancelarEditar = value
            End Set
            Get
                Return pCancelarEditar
            End Get
        End Property
        Public Property Grabar() As Boolean
            Set(ByVal value As Boolean)
                pGrabar = value
            End Set
            Get
                Return pGrabar
            End Get
        End Property
        Public Property GrabarNuevo() As Boolean
            Set(ByVal value As Boolean)
                pGrabarNuevo = value
            End Set
            Get
                Return pGrabarNuevo
            End Get
        End Property
        Public Property Eliminar() As Boolean
            Set(ByVal value As Boolean)
                pEliminar = value
            End Set
            Get
                Return pEliminar
            End Get
        End Property
        Public Property Deshacer() As Boolean
            Set(ByVal value As Boolean)
                pDeshacer = value
            End Set
            Get
                Return pDeshacer
            End Get
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
        Public Property Buscar() As Boolean
            Set(ByVal value As Boolean)
                pBuscar = value
            End Set
            Get
                Return pBuscar
            End Get
        End Property
        Public Property Inicio() As Boolean
            Set(ByVal value As Boolean)
                pInicio = value
            End Set
            Get
                Return pInicio
            End Get
        End Property
        Public Property Anterior() As Boolean
            Set(ByVal value As Boolean)
                pAnterior = value
            End Set
            Get
                Return pAnterior
            End Get
        End Property
        Public Property Siguiente() As Boolean
            Set(ByVal value As Boolean)
                pSiguiente = value
            End Set
            Get
                Return pSiguiente
            End Get
        End Property
        Public Property Final() As Boolean
            Set(ByVal value As Boolean)
                pFinal = value
            End Set
            Get
                Return pFinal
            End Get
        End Property
        Public Property Reportes() As Boolean
            Set(ByVal value As Boolean)
                pReportes = value
            End Set
            Get
                Return pReportes
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

        Public Overrides Sub LlamarMetodo(ByVal NombreMetodo As String)
            SendKeys.Send(Chr(Keys.Tab))
            Select Case NombreMetodo
                Case "NuevoRegistro"
                    NuevoRegistro()
                Case "EditarRegistro"
                    EditarRegistro()
                Case "CancelarEdicion"
                    CancelarEdicion(False)
                Case "PrepararGuardar"
                    PrepararGuardar(False)
                Case "PrepararGuardarNuevo"
                    PrepararGuardar(True)
                Case "PrepararEliminar"
                    PrepararEliminar()
                Case "DeshacerCambios"
                    Deshacercambios()
                Case "AgregarFilaGrid"
                    AgregarFilaGrid()
                Case "QuitarFilaGrid"
                    QuitarFilaGrid()
                Case "BuscarUnRegistro"
                    BuscarUnRegistro()
                Case "PrimerRegistro"
                    'PosicionGrid(NombreMetodo)
                Case "RegistroAnterior"
                    'PosicionGrid(NombreMetodo)
                Case "RegistroSiguiente"
                    'PosicionGrid(NombreMetodo)
                Case "UltimoRegistro"
                    'PosicionGrid(NombreMetodo)
                Case "Salir"
                    Salir()
            End Select
        End Sub

        Public Sub NuevoRegistro()
            If pDocumentoProcesandose = 1000 Or pDocumentoProcesandose = 2000 Or pDocumentoProcesandose = 3000 Then Exit Sub
            pRegistroNuevo = True
            LimpiarDatos()
            HabilitarNuevo()
            ValoresDefaultNuevo()
            BotonesEdicion("Crear registro")
            If Not FlagNuevo Then
                CrearCodigoId()
            Else
                HabilitarEscrituraNuevo()
            End If
            ConfigurarGrid("ElementoItem")
            ConfigurarFormulario(2)
            vTextChangedDOC_TIPO_LISTA = True
            ValidarCboDOC_TIPO_LISTA()

            Select Case pDTD_ID
                Case "001"
                    txtPER_ID_CLI.Text = ""
                    txtPER_ID_CLI.Enabled = False
                    txtPER_ID_CLI.ReadOnly = True
                    EtxtPER_ID_CLI.pBusqueda = False

                    txtTDP_ID_CLI.Enabled = False
                    txtTDP_ID_CLI.ReadOnly = True
                    EtxtTDP_ID_CLI.pBusqueda = False
                Case "004"
                    txtPER_ID_CLI.Text = ""
                    txtPER_ID_CLI.Enabled = False
                    txtPER_ID_CLI.ReadOnly = True
                    EtxtPER_ID_CLI.pBusqueda = False

                    txtTDP_ID_CLI.Enabled = False
                    txtTDP_ID_CLI.ReadOnly = True
                    EtxtTDP_ID_CLI.pBusqueda = False
                Case Else
                    txtPER_ID_CLI.Enabled = True
                    txtPER_ID_CLI.ReadOnly = False
                    EtxtPER_ID_CLI.pBusqueda = True

                    txtTDP_ID_CLI.Enabled = True
                    txtTDP_ID_CLI.ReadOnly = False
                    EtxtTDP_ID_CLI.pBusqueda = True

            End Select

            'FiltrarSeleccionarValidarElementosDOC_TIPO_LISTA(1, False)
        End Sub
        Public Sub MostrarControlesNCND()
            pnCuerpo.Controls.Remove(tcoDirecciones)
            Me.Controls.Add(tcoDirecciones)
            tcoDirecciones.BringToFront()
            tcoDirecciones.Location = New System.Drawing.Point(109, 108) '78, 78
            tcoDirecciones.Enabled = True


            pnCuerpo.Controls.Remove(tcoDatos)
            Me.Controls.Add(tcoDatos)
            tcoDatos.BringToFront()
            tcoDatos.Location = New System.Drawing.Point(42, 247) '11-217
            tcoDatos.Enabled = True
        End Sub
        Public Sub MostrarControlesConsultaPedido()
            pnCuerpo.Controls.Remove(btnImpresion)
            Me.Controls.Add(btnImpresion)
            btnImpresion.BringToFront()
            btnImpresion.Location = New System.Drawing.Point(160, 494) '129-464
            btnImpresion.Enabled = True
            btnImpresion.Focus()
        End Sub
        Public Sub MostrarControlesDarPase()
            txtTIV_ID.Text = BCVariablesNames.TipoVentaContraEntrega
            txtTIV_DESCRIPCION.Text = "CONTRA ENTREGA"

            pnCuerpo.Controls.Remove(txtTIV_ID)
            pnCuerpo.Controls.Remove(txtDOC_OBSERVACIONES)

            Me.Controls.Add(txtTIV_ID)
            Me.Controls.Add(txtDOC_OBSERVACIONES)

            EtxtTIV_ID.pOOrm.CadenaFiltrado = " AND (TIV_COMPORTAMIENTO='VENTAS' OR TIV_COMPORTAMIENTO='COMPRAS Y VENTAS')"

            txtTIV_ID.BringToFront()
            txtTIV_ID.ReadOnly = False
            txtTIV_ID.Enabled = True
            txtTIV_ID.Location = New System.Drawing.Point(396, 61)
            EtxtTIV_ID.pBusqueda = True

            txtDOC_OBSERVACIONES.BringToFront()
            txtDOC_OBSERVACIONES.ReadOnly = False
            txtDOC_OBSERVACIONES.Enabled = True
            txtDOC_OBSERVACIONES.Location = New System.Drawing.Point(305, 340) ' 315 - 340

            btnImpresion.Enabled = False

            btnImpresion.Focus()
        End Sub
        Public Sub OcultarControlesDarPase()
            Me.cboDOC_ESTADO.Enabled = False
            Me.cboDOC_ESTADO.Visible = False

            Me.Controls.Remove(txtTIV_ID)
            Me.Controls.Remove(txtDOC_OBSERVACIONES)

            Me.pnCuerpo.Controls.Add(txtTIV_ID)
            Me.pnCuerpo.Controls.Add(txtDOC_OBSERVACIONES)

            txtTIV_ID.BringToFront()
            txtTIV_ID.ReadOnly = False
            txtTIV_ID.Enabled = True
            txtTIV_ID.Location = New System.Drawing.Point(365, 31)

            txtDOC_OBSERVACIONES.BringToFront()
            txtDOC_OBSERVACIONES.ReadOnly = False
            txtDOC_OBSERVACIONES.Enabled = True
            txtDOC_OBSERVACIONES.Location = New System.Drawing.Point(270, 308) ' 273 - 308
        End Sub
        Public Sub EditarRegistro()
            If pDocumentoProcesandose = 2000 Or pDocumentoProcesandose = 3000 Then
                MostrarControlesConsultaPedido()
                If pDocumentoProcesandose = 3000 Then
                    MostrarControlesNCND()
                End If
                Exit Sub
            End If

            If pDocumentoProcesandose = 1000 Then
                If Not pFlagNuevo Then
                    If Trim(pCodigoId) = "" Then
                        btnImagen.Focus()
                        Exit Sub
                    End If
                End If
                MostrarControlesDarPase()
                tsbGrabar.Enabled = True
                btnImagen.Focus()
                Exit Sub
            End If
            If Not pFlagNuevo Then If Trim(pCodigoId) = "" Then Return
            BotonesEdicion("Editar registro")
            DeshabilitarModificar()
            PermisoCodigoVendedor()
        End Sub
        Public Sub CancelarEdicion(ByVal vDeshacerCambios As Boolean)
            Dim vRegistroNuevo As Boolean = False
            vRegistroNuevo = pRegistroNuevo

            If Not vDeshacerCambios Then
                If Not vRegistroNuevo Then
                    If RevisarDatos(False) Then Return
                End If
            End If
            LimpiarDatos()
            If vRegistroNuevo Then
                pnCuerpo.Enabled = False
                btnImagen.Focus()
                'NavegarFormulario("PrimerRegistro")
                LlamarMetodo("PrimerRegistro")
            Else
                BusquedaDatos("CancelarEdicion")
            End If

            If vDeshacerCambios Then
                If vRegistroNuevo Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    BotonesEdicion("Editar registro")
                End If
            Else
                BotonesEdicion("Seleccionar registro")
            End If
        End Sub

        Public Sub PrepararGuardar(ByVal vNuevo As Boolean)
            If SessionService.UserId <> "ADMIN" And _
               SessionService.UserId <> "GLOPEZ" And _
               SessionService.UserId <> "EYLENR" And _
               SessionService.UserId <> "RFERNANDEZ" And _
               SessionService.UserId <> "IRMAG" Then
                If Strings.Len(Me.Name.ToString) > 10 Then
                    If Strings.Left(Me.Name.ToString, 10) = "frmBoletas" Or _
                       Strings.Left(Me.Name.ToString, 11) = "frmFacturas" Then
                        If dtpDOC_FECHA_EMI.Value <> IBCMaestro.EjecutarVista("spFechaServidor") Then
                            MsgBox("¡No se puede procesar documento, fecha de emisión no corresponde al día de trabajo!", MsgBoxStyle.Exclamation, Me.Text)
                            Exit Sub
                        End If
                    End If
                End If
            End If
            Dim vProcederImpresion As Boolean = False
            btnImagen.Focus()
            Dim oMsgBoxResult As New MsgBoxResult()
            If pDocumentoProcesandose = 2000 Or pDocumentoProcesandose = 3000 Then Exit Sub
            If pDocumentoProcesandose = 1000 Then
                oMsgBoxResult = MsgBox("Desea grabar el siguiente documento: " & txtDOC_SERIE.Text & "-" & txtDOC_NUMERO.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text)
                If (oMsgBoxResult = MsgBoxResult.No) Then
                    Exit Sub
                End If
                If ModificarTIV_ID() Then tsbGrabar.Enabled = False
                Exit Sub
            End If

            CalcularMontoDocumento(1)
            Dim bRes As Boolean = False
            If Not pRegistroNuevo Then
                If Not RevisarDatos(True) Then
                    If vNuevo Then
                        NuevoRegistro()
                    End If
                    Return
                End If
            End If

            vItemKardexCtaCte = Me.IBCKardexCtaCte.ItemKardexCtaCte(txtTDO_ID.Text, txtDTD_ID.Text, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)
            vItemKardexCtaCtePercepcion = Me.IBCKardexCtaCte.ItemKardexCtaCte(txtTDO_ID.Text, BCVariablesNames.ProcesosFacturación.BoletaPercepcion, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)
            vItemDetalleDespachos = Me.IBCDetalleDespachos.ItemDetalleDespachos(BCVariablesNames.ProcesosDespacho.Guia, BCVariablesNames.ProcesosDespacho.GuiaPorNotaCredito, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)
            vItemDetalleAfectaMonto = Me.IBCDetalleAfectaDocumentos.ItemDetalleAfectaDocumentos(txtTDO_ID.Text, txtDTD_ID.Text, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)
            vItemDetalleAfectaProducto = Me.IBCDetalleAfectaProductoDocumentos.ItemDetalleAfectaProductoDocumentos(txtTDO_ID.Text, txtDTD_ID.Text, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)

            If pRegistroNuevo Then ActualizarCorrelativo()

            oMsgBoxResult = MsgBox("Desea grabar el siguiente documento: " & txtDOC_SERIE.Text & "-" & txtDOC_NUMERO.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text)
            If (oMsgBoxResult = MsgBoxResult.No) Then
                Exit Sub
            End If

            If pRegistroNuevo Then
                bRes = Ingresar()
                vProcederImpresion = True
            Else
                bRes = Modificar()
            End If

            If bRes Then InicializarDatos()

            If (bRes) Then
                BotonesEdicion("Seleccionar registro")
                If vNuevo Then
                    NuevoRegistro()
                End If
                Dim vSystemObject As New System.Object
                Dim vEventArgs As New System.EventArgs

                Select Case txtDTD_ID.Text
                    Case BCVariablesNames.ProcesosFacturación.PBBoleta, _
                         BCVariablesNames.ProcesosFacturación.PFFactura
                    Case Else
                        If vProcederImpresion Then Call btnImpresion_Click(vSystemObject, vEventArgs)
                End Select
            End If
        End Sub
        Public Sub PrepararEliminar()
            If pDocumentoProcesandose = 1000 Or pDocumentoProcesandose = 2000 Or pDocumentoProcesandose = 3000 Then Exit Sub
            Dim bRes As Boolean = False
            Dim oMsgBoxResult As New MsgBoxResult()
            Try
                oMsgBoxResult = MsgBox("Esta seguro de eliminar el registro: " & txtDOC_SERIE.Text & "-" & txtDOC_NUMERO.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text)
                If (oMsgBoxResult = MsgBoxResult.Yes) Then
                    bRes = EliminarRegistro()
                End If
                If (bRes) Then
                    LimpiarDatos()
                    BusquedaDatos("PrepararEliminar")
                    BotonesEdicion("Seleccionar registro")
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - PrepararEliminar")
            End Try
        End Sub
        Public Sub Deshacercambios()
            CancelarEdicion(True)
        End Sub
        Public Sub AgregarFilaGrid()
            If pDocumentoProcesandose = 1000 Or pDocumentoProcesandose = 2000 Or pDocumentoProcesandose = 3000 Then Exit Sub
            AdicionarFilasGrid()
        End Sub
        Public Sub QuitarFilaGrid()
            If pDocumentoProcesandose = 1000 Or pDocumentoProcesandose = 2000 Or pDocumentoProcesandose = 3000 Then Exit Sub
            EliminarFilasGrid()
        End Sub
        Public Sub BuscarUnRegistro()
            BusquedaDatos("BuscarUnRegistro")
        End Sub
        Public Sub PosicionGrid(ByVal Metodo As String)
            If pCodigoId Is Nothing Or Trim(pCodigoId) = "" Then
                NavegarFormulario("PrimerRegistro")
                Exit Sub
            End If
            If Me.ActiveControl.GetType <> GetType(DataGridView) Then
                NavegarFormulario(Metodo)
            Else
                NavegarGrid(Metodo)
            End If
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

        ' NuevoRegistro
        Private Sub BotonesEdicion(ByVal vProceso As String)
            Select Case vProceso
                Case "Crear registro"
                    Nuevo = False
                    tsbNuevo.Enabled = False
                    Editar = False
                    CancelarEditar = True
                    Grabar = True
                    GrabarNuevo = True
                    Eliminar = False
                    Deshacer = True
                    Agregar = True
                    Quitar = True
                    Buscar = False
                    Inicio = False
                    Anterior = False
                    Siguiente = False
                    Final = False
                    Reportes = False
                    Salida = False
                    pnCuerpo.Enabled = True
                Case "Editar registro"
                    Nuevo = False
                    Editar = False
                    CancelarEditar = True
                    Grabar = True
                    GrabarNuevo = True
                    Eliminar = True
                    Deshacer = True
                    Agregar = True
                    Quitar = True
                    Buscar = False
                    Inicio = True
                    Anterior = True
                    Siguiente = True
                    Final = True
                    Reportes = False
                    Salida = False
                    pnCuerpo.Enabled = True
                Case "Seleccionar registro"
                    Nuevo = True
                    Editar = True
                    CancelarEditar = False
                    Grabar = False
                    GrabarNuevo = False
                    Eliminar = False
                    Deshacer = False
                    Agregar = False
                    Quitar = False
                    Buscar = True
                    Inicio = True
                    Anterior = True
                    Siguiente = True
                    Final = True
                    Reportes = True
                    Salida = True
                    pnCuerpo.Enabled = False
                Case ("Aceptar registro")
                    Nuevo = False
                    Editar = True
                    CancelarEditar = True
                    Grabar = False
                    GrabarNuevo = False
                    Eliminar = False
                    Deshacer = False
                    Agregar = False
                    Quitar = False
                    Buscar = False
                    Inicio = True
                    Anterior = True
                    Siguiente = True
                    Final = True
                    Reportes = False
                    Salida = True
            End Select
            FormatearBotonesEdicion()
        End Sub
        Private Sub FormatearBotonesEdicion()
            tsbNuevo.Enabled = Nuevo
            tsbEditar.Enabled = Editar
            tsbCancelarEditar.Enabled = CancelarEditar
            tsbGrabar.Enabled = Grabar
            TsbGrabarNuevo.Enabled = GrabarNuevo
            tsbEliminar.Enabled = Eliminar
            tsbDeshacer.Enabled = Deshacer
            tsbAgregar.Enabled = Agregar
            tsbQuitar.Enabled = Quitar
            tsbBuscar.Enabled = Buscar
            tsbInicio.Enabled = Inicio
            tsbAnterior.Enabled = Anterior
            tsbSiguiente.Enabled = Siguiente
            tsbFinal.Enabled = Final
            tsbReportes.Enabled = Reportes
            tsbSalir.Enabled = Salida
        End Sub
        Private Sub ProcesoCrearCodigoId(ByVal vVista As String, ByRef oTexto As TextBox)
            Select Case vVista
                Case "CrearCodigoSimple"
                    Dim resp = Me.IBCBusqueda.CrearCodigoSimple(Compuesto.CampoPrincipal, _
                                                                Compuesto.cTabla.NombreLargo)
                    oTexto.Text = resp
                    For a = 1 To (LongitudId - Len(oTexto.Text.Trim()))
                        oTexto.Text = CaracterId & oTexto.Text
                    Next
                    oTexto.ReadOnly = True
            End Select
        End Sub
        Private Sub ProcesoCrearCodigoIdDetalle(ByVal vVista As String, _
                                                ByRef oTexto As TextBox, _
                                                ByVal pLongitudId As Int16, _
                                                ByVal pCaracterId As String)
            Select Case vVista
                Case "CrearCodigoSimple"
                    Dim resp = Me.IBCBusqueda.CrearCodigoSimple(Compuesto1.CampoPrincipal, _
                                                                Compuesto1.cTabla.NombreLargo)
                    oTexto.Text = resp
                    For a = 1 To (LongitudId - Len(oTexto.Text.Trim()))
                        oTexto.Text = CaracterId & oTexto.Text
                    Next
                    oTexto.ReadOnly = True
            End Select
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
                    Dim dtpTemporal As New DateTimePicker
                    sender.MaxDate = dtpTemporal.MaxDate
                    sender.MinDate = dtpTemporal.MinDate
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

        ' CancelarEdicion
        Private Function RevisarDatos(ByVal vBoolean As Boolean, Optional ByVal vDesdeImpresion As Boolean = False) As Boolean
            Return RevisarDatos(pColeccionDatos, vBoolean, vDesdeImpresion)
        End Function
        Private Function RevisarDatos(ByVal vColeccionDatos As Collection, _
                                      ByVal vRespuestaGrabar As Boolean, _
                                      Optional ByVal vDesdeImpresion As Boolean = False) As Boolean
            If RevisarDatosForm(vColeccionDatos, True) Then
                If vRespuestaGrabar Then
                    RevisarDatos = True
                Else
                    Dim oMsgBoxResult As New MsgBoxResult()
                    If vDesdeImpresion Then
                        oMsgBoxResult = MsgBox("Registro modificado... ¡Sin Grabar!." & Chr(13) & Chr(13), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text & " - Grabe para poder imprimir.")
                        RevisarDatos = True
                    Else
                        oMsgBoxResult = MsgBox("Registro modificado... ¡Sin Grabar!." & Chr(13) & Chr(13) & "¿Desea continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, Me.Text & " - Se perderan los datos.")
                        If (oMsgBoxResult = MsgBoxResult.Cancel) Then
                            RevisarDatos = True
                        Else
                            RevisarDatos = False
                        End If
                    End If
                End If
            Else
                RevisarDatos = False
            End If
            Return RevisarDatos
        End Function
        '' ojito
        Private Function RevisarDatosForm(ByVal vColeccion As Collection, _
                                          ByVal vProceso As Boolean) As Object
            Dim vControl As System.Windows.Forms.Control
            Dim vDatosControl As New Collection
            If vColeccion Is Nothing Then
                If vProceso Then
                    Return True
                End If
            End If
            For Each vControl In pnCuerpo.Controls
                If TypeOf vControl Is System.Windows.Forms.TextBox Or _
                   TypeOf vControl Is System.Windows.Forms.ComboBox Or _
                   TypeOf vControl Is System.Windows.Forms.DateTimePicker Or _
                   TypeOf vControl Is System.Windows.Forms.CheckBox Then
                    If TypeOf vControl Is System.Windows.Forms.CheckBox Then
                        If vControl.Name = "chkTransferenciaGratuita" Or _
                           vControl.Name = "chkCanastaNavideña" Then
                        Else
                            Dim vObjeto As Object
                            vObjeto = vControl
                            If vProceso Then
                                If vObjeto.checked.ToString <> vColeccion(vControl.Name.ToString).ToString Then
                                    Return True
                                End If
                            Else
                                vDatosControl.Add(vObjeto.checked.ToString, vControl.Name)
                            End If
                        End If
                    Else
                        If vProceso Then
                            If vControl.Text <> vColeccion(vControl.Name.ToString).ToString Then
                                Return True
                            End If
                        Else
                            vDatosControl.Add(vControl.Text, vControl.Name)
                        End If
                    End If
                End If
                If vControl.GetType = GetType(System.Windows.Forms.PictureBox) Then
                    Dim vObjeto As Object
                    If vProceso Then
                        vObjeto = vControl
                        If vObjeto.tamanio <> vColeccion(vControl.Name.ToString).ToString Then
                            Return True
                        End If
                    Else
                        vObjeto = vControl
                        vDatosControl.Add(vObjeto.tamanio, vObjeto.Name)
                    End If
                End If
                If vControl.GetType = GetType(System.Windows.Forms.DataGridView) Then
                    If vProceso Then
                        Dim vObjetoOriginal As Object
                        Dim vObjetoCopia As Object
                        vObjetoOriginal = vControl
                        vObjetoCopia = vColeccion(vControl.Name.ToString)
                        If vObjetoOriginal.RowCount <> vObjetoCopia.RowCount Then Return True
                        With vObjetoOriginal
                            For fila As Integer = 0 To .RowCount - 1
                                For col As Integer = 0 To .Columns.Count - 1
                                    If .item(col, fila).value <> vObjetoCopia.item(col, fila).value Then
                                        Return True
                                    End If
                                Next
                            Next
                        End With
                    Else
                        Dim vDataGridCopia As New System.Windows.Forms.DataGridView
                        Dim vDataGridOriginal As New System.Windows.Forms.DataGridView
                        vDataGridOriginal = vControl
                        If vDataGridOriginal.RowCount > 0 Then
                            vDataGridCopia.ColumnCount = vDataGridOriginal.ColumnCount
                            vDataGridCopia.RowCount = vDataGridOriginal.RowCount
                            With vDataGridOriginal
                                For fila As Integer = 0 To .RowCount - 1
                                    For col As Integer = 0 To .Columns.Count - 1
                                        vDataGridCopia.Item(col, fila).Value = vDataGridOriginal.Item(col, fila).Value
                                    Next
                                Next
                            End With
                            vDatosControl.Add(vDataGridCopia, vControl.Name)
                        Else
                            vDataGridCopia.Rows.Clear()
                            vDatosControl.Add(vDataGridCopia, vControl.Name)
                        End If
                    End If
                End If
            Next
            If vProceso Then
                Return False
            Else
                Return vDatosControl
            End If
        End Function
        Public Sub BusquedaDatos(ByVal vProceso As String)
            Try
                OrmBusquedaDatos(vProceso)
                Select Case vProceso
                    Case "CancelarEdicion"
                        DatoBusquedaConsulta = CodigoId
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 2
                        If pComportamiento = -1 Then
                            frm.TipoEdicion = 1
                            frm.DatoBusqueda = DatoBusquedaConsulta
                        End If
                        frm.DatoBusqueda = DatoBusquedaConsulta
                        frm.oOrm = Compuesto
                        frm.Comportamiento = pComportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = pOrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "PrepararEliminar"
                        Compuesto.CampoPrincipalValor = CodigoId
                        Dim resp = Me.IBCBusqueda.RegistroAnterior("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar)", _
                                                                   Compuesto.CampoPrincipalValor, _
                                                                   Compuesto.cTabla.NombreVista, Compuesto.CadenaFiltrado)
                        DatoBusquedaConsulta = resp
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 2
                        If pComportamiento = -1 Then
                            frm.TipoEdicion = 1
                            frm.DatoBusqueda = DatoBusquedaConsulta
                        End If
                        frm.DatoBusqueda = DatoBusquedaConsulta
                        frm.oOrm = Compuesto
                        frm.Comportamiento = pComportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = pOrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "BuscarUnRegistro"
                        DatoBusquedaConsulta = ""
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = ""
                        frm.oOrm = Compuesto
                        frm.Comportamiento = pComportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = 10 ' pOrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "Load"
                        If Comportamiento = -1 Then
                            Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                            If True Then
                                frm.TipoEdicion = 2
                                If pComportamiento = -1 Then
                                    frm.TipoEdicion = 1
                                    frm.DatoBusqueda = DatoBusquedaConsulta
                                End If
                                frm.DatoBusqueda = DatoBusquedaConsulta
                            Else
                                frm.TipoEdicion = 1
                                frm.DatoBusqueda = ""
                            End If

                            frm.oOrm = Compuesto
                            frm.Comportamiento = pComportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = pOrdenBusqueda
                            frm.ShowDialog()
                            frm.Dispose()
                        Else
                            OrmBusquedaDatos(vProceso)
                            Dim resp = Me.IBCBusqueda.PrimerRegistro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                                     "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                                     "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                     "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar)", _
                                                                     Compuesto.cTabla.NombreVista, Compuesto.CadenaFiltrado)

                            DatoBusquedaConsulta = resp
                            Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                            If True Then
                                frm.TipoEdicion = 2
                                If pComportamiento = -1 Then
                                    frm.TipoEdicion = 1
                                    frm.DatoBusqueda = DatoBusquedaConsulta
                                End If
                                frm.DatoBusqueda = DatoBusquedaConsulta
                            Else
                                frm.TipoEdicion = 1
                                frm.DatoBusqueda = ""
                            End If
                            frm.oOrm = Compuesto
                            frm.Comportamiento = pComportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = pOrdenBusqueda
                            frm.ShowDialog()
                            frm.Dispose()
                        End If
                End Select
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - BusquedaDatos")
            End Try
        End Sub

        ' PrepararGuardar
        ' ojito
        ''
        ''
        Private Function Ingresar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 1
            pRespuestaExtraerDetalle = 0
            Ingresar = False
            DatosCabecera()

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito
                    ProcesarKardexCtaCteNotaCredito()
                    ProcesarCtaCteEnDespacho()
                Case Else
                    ProcesarKardexCtaCte()
            End Select

            If (Validar("Cabecera")) Then
                Using Scope As New System.Transactions.TransactionScope()
                    If (InsertarDatos()) Then
                        Scope.Complete()
                        Ingresar = True
                        ConfigurarDatosGrabados()
                        vMensajeMostrar = 0
                    Else
                        If pRespuestaExtraerDetalle = -1 Then
                            Scope.Dispose()
                            vMensajeMostrar = 1
                        Else
                            Scope.Dispose()
                            vMensajeMostrar = 2
                        End If
                    End If
                End Using
            End If

            If vCodigoProformaTDO_ID <> "" And
               vCodigoProformaDTD_ID <> "" And
               vCodigoProformaDOC_SERIE <> "" And
               vCodigoProformaDOC_NUMERO <> "" And
               vMensajeMostrar <> 1 Then
                Me.IBCProforma.spActualizarDocumentosDOC_ESTADO(vCodigoProformaTDO_ID, vCodigoProformaDTD_ID, vCodigoProformaDOC_SERIE, vCodigoProformaDOC_NUMERO, DevolverTiposCampos("DOC_ESTADO", BCVariablesNames.EstadoRegistro.Procesado, Compuesto))
            End If

            Me.Cursor = Windows.Forms.Cursors.Default
            If MensajeOperaciones(vMensajeMostrar, "ingresado") = 1 Then Return Ingresar
            InicializarOrm()
            Return Ingresar
        End Function
        Private Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            Dim vRespuestaLocal1 As Short = 0
            Dim vRespuestaLocal2 As Short = 0

            vRespuestaLocal = IBC.spInsertarRegistro(Compuesto)
            If vRespuestaLocal = 0 Then
                InsertarDatos = False
                Return InsertarDatos
            End If

            vRespuestaLocal1 = IBCCorrelativoTipoDocumento.spActualizarRegistro(Compuesto2)
            If vRespuestaLocal1 = 0 Then
                InsertarDatos = False
                Return InsertarDatos
            End If

            If Not vClienteLineaCreditoEstado Then
                vRespuestaLocal2 = IBCPersona.spActualizarPersonasPER_LINEA_CREDITO(Compuesto.PER_ID_CLI, Compuesto.USU_ID)
                If vRespuestaLocal2 = 0 Then
                    InsertarDatos = False
                    Return InsertarDatos
                End If
            End If

            pRespuestaExtraerDetalle = ExtraerDetalle()
            InsertarDatos = (vRespuestaLocal > 0 And vRespuestaLocal1 > 0 And pRespuestaExtraerDetalle = 1)
        End Function
        Private Sub ConfigurarDatosGrabados()
            ReDim eRegistrosEliminar(1)
            Dim vFilGrid As Int16 = 0
            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    .Cells("cEstadoRegistro").Value = True
                End With
                vFilGrid += 1
            End While
        End Sub
        Private Function ExtraerDetalle() As Int16
            ExtraerDetalle = EliminarRegistroDetalle()
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = EliminarKardexCtaCte(vItemKardexCtaCte)
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = EliminarKardexCtaCtePercepcion(vItemKardexCtaCtePercepcion)
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = EliminarDetalleDespachos(vItemDetalleDespachos)
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = EliminarDetalleAfectaMonto(vItemDetalleAfectaMonto)
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = EliminarDetalleAfectaProducto(vItemDetalleAfectaProducto)
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = ProcesarDatosDetalle()
            Return ExtraerDetalle
        End Function
        Private Function FormatearNumeros(ByVal vDato As String, _
                                          ByVal vCampo As String, _
                                          ByVal oOrm As Object, _
                                          Optional ByVal vLogical As Boolean = False)
            Dim vEntero As Integer = 0
            Dim vDecimal As Integer = 0
            Dim vFlag As Boolean = False
            For elemento As Integer = 0 To oOrm.vArrayDatosComboBox.GetUpperBound(0)
                'MsgBox(vCampo & " - " & oOrm.vArrayDatosComboBox(elemento).NombreCampo)
                If oOrm.vArrayDatosComboBox(elemento).NombreCampo = vCampo Then
                    vEntero = oOrm.vArrayDatosComboBox(elemento).ParteEntera
                    vDecimal = oOrm.vArrayDatosComboBox(elemento).ParteDecimal
                    Exit For
                End If
            Next elemento

            If CDbl(vDato) < 0 Then
                vDato = Strings.Right(vDato, Len(vDato) - 1)
                vFlag = True
            End If

            FormatearNumeros = cMisProcedimientos.FormatoNumero(vEntero, vDecimal, vDato)
            Dim vCadenaError As String = ""
            If FormatearNumeros = 0 Then vCadenaError = "Desborde de la parte entera y decimal"
            If FormatearNumeros = -1 Then vCadenaError = "Desborde de la parte entera"
            If FormatearNumeros = -2 Then vCadenaError = "Desbordo de la parte entera despues de redondearlo"
            If FormatearNumeros = -3 Then vCadenaError = "Dato no númerico"
            If FormatearNumeros = -4 Then vCadenaError = "Error de desbordamiento general"
            If FormatearNumeros <= 0 Then
                If IsNumeric(vDato) Then
                    If Val(vDato) <> 0 Then
                        vMensajeErrorOrm = "Campo: " & vCampo & ", error en el formato de datos númericos, valor: " & vDato & ", " & vCadenaError
                    End If
                Else
                    vMensajeErrorOrm = "Campo: " & vCampo & ", error en el formato de datos númericos, valor: " & vDato & ", " & vCadenaError
                End If
                If vLogical Then
                    FormatearNumeros = 0
                    vMensajeErrorOrm = ""
                End If
            End If
            If vFlag Then
                FormatearNumeros = FormatearNumeros * -1
            End If
            Return FormatearNumeros
        End Function

        Private Function ModificarTIV_ID() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 0
            pRespuestaExtraerDetalle = 0
            ModificarTIV_ID = False

            DatosCabecera()
            'Compuesto.DOC_OBSERVACIONES = Strings.LSet(Compuesto.DOC_OBSERVACIONES & " - Pase desde finanzas", 255)

            If (Compuesto.ColocarErrores(txtTIV_ID, Compuesto.VerificarDatos("TIV_ID"), ErrorProvider1)) Then
                Using Scope As New System.Transactions.TransactionScope()
                    If (Me.IBC.spActualizarDocumentosTIV_ID(Compuesto)) Then
                        Scope.Complete()
                        ModificarTIV_ID = True
                        vMensajeMostrar = 0
                    Else
                        If pRespuestaExtraerDetalle = -1 Then
                            Scope.Dispose()
                            vMensajeMostrar = 1
                        Else
                            Scope.Dispose()
                            vMensajeMostrar = 2
                        End If
                    End If
                End Using
            End If
            If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return ModificarTIV_ID
            InicializarOrm()
            Me.Cursor = Windows.Forms.Cursors.Default
            Return ModificarTIV_ID
        End Function
        Private Function Modificar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 0
            pRespuestaExtraerDetalle = 0
            Modificar = False
            DatosCabecera()


            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito
                    ProcesarKardexCtaCteNotaCredito()
                    ProcesarCtaCteEnDespacho()
                Case Else
                    ProcesarKardexCtaCte()
            End Select

            If (Validar("Cabecera")) Then
                Using Scope As New System.Transactions.TransactionScope()
                    If (ActualizarDatos()) Then
                        Scope.Complete()
                        Modificar = True
                        ConfigurarDatosGrabados()
                        vMensajeMostrar = 0
                    Else
                        If pRespuestaExtraerDetalle = -1 Then
                            Scope.Dispose()
                            vMensajeMostrar = 1
                        Else
                            Scope.Dispose()
                            vMensajeMostrar = 2
                        End If
                    End If
                End Using
            End If
            If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar
            InicializarOrm()
            Me.Cursor = Windows.Forms.Cursors.Default
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean
            Dim vRespuestaLocal2 As Short = 0
            If Not vClienteLineaCreditoEstado Then
                vRespuestaLocal2 = IBCPersona.spActualizarPersonasPER_LINEA_CREDITO(Compuesto.PER_ID_CLI, Compuesto.USU_ID)
                If vRespuestaLocal2 = 0 Then
                    ActualizarDatos = False
                    Return ActualizarDatos
                End If
            End If

            pRespuestaExtraerDetalle = ExtraerDetalle()

            If pRespuestaExtraerDetalle = 0 Then
                ActualizarDatos = False
                Return ActualizarDatos
            End If
            ActualizarDatos = (Me.IBC.spActualizarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.CCT_ID, Compuesto.DOC_SERIE, Compuesto.DOC_NUMERO, Compuesto.DOC_ORDEN_COMPRA, Compuesto.DOC_TIPO_ORDEN_COMPRA, Compuesto.PER_ID_REC, Compuesto.TDP_ID_REC, Compuesto.DIR_ID_ENT_REC, Compuesto.PVE_ID, Compuesto.PVE_ID_DES, Compuesto.MON_ID, Compuesto.TIV_ID, Compuesto.PER_ID_CLI, Compuesto.TDP_ID_CLI, Compuesto.PER_ID_CON, Compuesto.DOC_FECHA_EMI, Compuesto.DOC_FECHA_ENT, Compuesto.DOC_FECHA_EXP, Compuesto.DIR_ID_FIS, Compuesto.DIR_ID_DOM, Compuesto.DIR_ID_ENT, Compuesto.DIR_ID_COB, Compuesto.PER_ID_VEN, Compuesto.PER_ID_COB, Compuesto.PER_ID_PRO, Compuesto.PER_ID_GRU, Compuesto.DOC_TIPO_LISTA, Compuesto.DOC_MONTO_TOTAL, Compuesto.DOC_CONTRAVALOR, Compuesto.DOC_IGV_POR, Compuesto.DOC_ASIENTO, Compuesto.DOC_CIERRE, Compuesto.FLE_ID, Compuesto.DOC_MONTO_FLE, Compuesto.DOC_REQUIERE_GUIA, Compuesto.TDO_ID_AFE, Compuesto.DTD_ID_AFE, Compuesto.CCT_ID_AFE, Compuesto.DOC_SERIE_AFE, Compuesto.DOC_NUMERO_AFE, Compuesto.DOC_MOT_EMI, Compuesto.DOC_NOMBRE_RECEP, Compuesto.DOC_DNI_RECEP, Compuesto.DOC_FEC_RECEP, Compuesto.DOC_ENTREGADO, Compuesto.CAF_IX_NUMERO_PRO, Compuesto.CAF_IX_ORDEN_COM, Compuesto.LPR_ID, Compuesto.USU_ID, Compuesto.DOC_FEC_GRAB, Compuesto.DOC_ESTADO, Compuesto.DOC_MONTO_PERCEPCION, Compuesto.TDO_ID_GEN, Compuesto.DTD_ID_GEN, Compuesto.CCT_ID_GEN, Compuesto.DOC_SERIE_GEN, Compuesto.DOC_NUMERO_GEN, Compuesto.DOC_OBSERVACIONES, Compuesto.DOC_ATENCION, Compuesto.DOC_HORA_INICIO, Compuesto.DOC_HORA_FIN) > 0 And pRespuestaExtraerDetalle = 1)
        End Function
        Public Sub InicializarDatos()
            OrmBusquedaDatos("InicializarDatos")
            pRegistroNuevo = False
            pColeccionDatos = RevisarDatosForm(Nothing, False)
            ConfigurarGrid("ElementoItem")
        End Sub
        Private Function DevolverTiposCampos(ByVal oNombreCampo As String, ByVal oTexto As String, ByVal oOrm As Object) As String
            oOrm.CampoId = oNombreCampo
            oOrm.Dato = oTexto
            DevolverTiposCampos = oOrm.DevolverTiposCampos()
        End Function

        ' PrepararEliminar
        Private Function EliminarRegistro() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            Dim vMensajeMostrar As Int16 = 0
            Dim vDocumentoPercepcion As String = ""

            vItemKardexCtaCte = Me.IBCKardexCtaCte.ItemKardexCtaCte(txtTDO_ID.Text, txtDTD_ID.Text, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)
            vItemKardexCtaCtePercepcion = Me.IBCKardexCtaCte.ItemKardexCtaCte(txtTDO_ID.Text, BCVariablesNames.ProcesosFacturación.BoletaPercepcion, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)
            vItemDetalleDespachos = Me.IBCDetalleDespachos.ItemDetalleDespachos(BCVariablesNames.ProcesosDespacho.Guia, BCVariablesNames.ProcesosDespacho.GuiaPorNotaCredito, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)
            vItemDetalleAfectaMonto = Me.IBCDetalleAfectaDocumentos.ItemDetalleAfectaDocumentos(txtTDO_ID.Text, txtDTD_ID.Text, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)
            vItemDetalleAfectaProducto = Me.IBCDetalleAfectaProductoDocumentos.ItemDetalleAfectaProductoDocumentos(txtTDO_ID.Text, txtDTD_ID.Text, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.VentaBoleta
                    vDocumentoPercepcion = BCVariablesNames.ProcesosFacturación.BoletaPercepcion
                Case BCVariablesNames.ProcesosFacturación.VentaFactura
                    vDocumentoPercepcion = BCVariablesNames.ProcesosFacturación.FacturaPercepcion
            End Select
            vItemKardexCtaCtePercepcion = Me.IBCKardexCtaCte.ItemKardexCtaCte(txtTDO_ID.Text, vDocumentoPercepcion, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)

            Using Scope As New System.Transactions.TransactionScope()
                'Compuesto.MarkAsDeleted()
                'If (ProcesarEliminarDetalle() > 0 And Me.IBC.Mantenimiento(Compuesto) > 0) Then
                If (ProcesarEliminarDetalle() > 0 And Me.IBC.spEliminarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.DOC_SERIE, Compuesto.DOC_NUMERO) > 0) Then
                    Scope.Complete()
                    EliminarRegistro = True
                    vMensajeMostrar = 0
                Else
                    Scope.Dispose()
                    EliminarRegistro = False
                    vMensajeMostrar = 2
                End If
            End Using
            Me.Cursor = Windows.Forms.Cursors.Default
            MensajeOperaciones(vMensajeMostrar, "eliminado")
            InicializarOrm()
            Return EliminarRegistro
        End Function

        ' PosicionGrid
        Private Sub NavegarFormulario(ByVal Metodo As String)
            Try
                If pnCuerpo.Enabled = True Then If RevisarDatos(False) Then Return
                Dim vCodigoId As String
                Dim resp As String = ""
                OrmBusquedaDatos("NavegarFormulario")
                Select Case Metodo
                    Case "PrimerRegistro"
                        resp = Me.IBCBusqueda.PrimerRegistro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar)", _
                                                             Compuesto.cTabla.NombreVista, Compuesto.CadenaFiltrado)
                    Case "RegistroAnterior"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroAnterior("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar)", _
                                                               Compuesto.CampoPrincipalValor, _
                                                               Compuesto.cTabla.NombreVista, Compuesto.CadenaFiltrado)
                    Case "RegistroSiguiente"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroSiguiente("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar)", _
                                                                Compuesto.CampoPrincipalValor, _
                                                                Compuesto.cTabla.NombreVista, Compuesto.CadenaFiltrado)
                    Case "UltimoRegistro"
                        resp = Me.IBCBusqueda.UltimoRegistro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar)", _
                                                             Compuesto.cTabla.NombreVista, Compuesto.CadenaFiltrado)
                End Select
                vCodigoId = resp
                If vCodigoId Is Nothing Or Trim(vCodigoId) = "" Then
                    MsgBox("¡No se encontro registros!", MsgBoxStyle.Information, Me.Text)
                    OrmBusquedaDatos("RegistroNoEncontrado")
                    Return
                Else
                    If vCodigoId = CodigoId Then Return
                End If
                LimpiarDatos()
                DatoBusquedaConsulta = vCodigoId
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                frm.TipoEdicion = 2
                If pComportamiento = -1 Then
                    frm.TipoEdicion = 1
                    frm.DatoBusqueda = DatoBusquedaConsulta
                End If
                frm.DatoBusqueda = DatoBusquedaConsulta
                frm.oOrm = Compuesto
                frm.Comportamiento = pComportamiento
                frm.NombreFormulario = Me
                frm.OrdenBusqueda = pOrdenBusqueda
                frm.ShowDialog()
                frm.Dispose()
                BotonesEdicion("Seleccionar registro")
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - NavegarFormulario")
            End Try
        End Sub
        Private Sub NavegarGrid(ByVal Metodo As String)
            cMisProcedimientos.PosicionGrid(Metodo, ActiveControl, Me.Text)
        End Sub

        ' Formulario Simple
        '' Load
        Private Sub ConfigurarTabIndex(ByRef vObjeto As Object, ByRef vTabIndex As Int16, Optional ByVal vFlag As Boolean = False)
            vObjeto.TabIndex = ColocarTabIndex(vTabIndex)
            If vFlag Then ConfigurarReadOnly(vObjeto)
        End Sub
        Private Function ColocarTabIndex(ByRef vtabIndex As Int16) As Int16
            vtabIndex += 1
            Return vtabIndex
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
        '' ojito
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
            VerificarDatosSession()
        End Sub
        Private Sub VerificarDatosSession()
            EdtpDOC_FECHA_EMI.pEnabled = SessionService.ModificarFechaProcesoEnDocumento
        End Sub
        Public Sub ComportamientoFormulario()
            If pComportamiento <> -1 Then
                NombresFormulariosControles()
                FiltrarOrm()
            End If
            pLoaded = False
        End Sub
        Private Sub BuscarFormatos(ByRef vObjeto As cbo, _
                          ByVal oCompuesto As Object, _
                          ByRef oComboBox As ComboBox, _
                          ByVal vOrdenBusqueda As Int16)
            oCompuesto.CampoId = vObjeto.pNombreCampo
            cMisProcedimientos.AdicionarElementoCombosEdicion(oComboBox, oCompuesto.BuscarFormatos(), vOrdenBusqueda)
        End Sub

        '' ProcessCmdKey
        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            TeclasAccesoRapido(keyData)

            If (Not dgvDetalle.Focused) Then
                Return (MyBase.ProcessCmdKey(msg, keyData))
            End If
            If keyData <> Keys.Enter Then
                Return (MyBase.ProcessCmdKey(msg, keyData))
            End If
            SendKeys.Send(Chr(Keys.Tab))
            Return True
        End Function
        Private Sub TeclasAccesoRapido(ByVal vkeyData As System.Windows.Forms.Keys)
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.N Then
                If tsbNuevo.Enabled = True Then LlamarMetodo("NuevoRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.E Then
                If tsbEditar.Enabled = True Then LlamarMetodo("EditarRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.C Then
                If tsbCancelarEditar.Enabled = True Then LlamarMetodo("CancelarEdicion")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.G Then
                If tsbGrabar.Enabled = True Then LlamarMetodo("PrepararGuardar")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.W Then
                If TsbGrabarNuevo.Enabled = True Then LlamarMetodo("PrepararGuardarNuevo")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.X Then
                If tsbEliminar.Enabled = True Then LlamarMetodo("PrepararEliminar")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.Z Then
                If tsbDeshacer.Enabled = True Then LlamarMetodo("DeshacerCambios")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.Add Then
                If tsbAgregar.Enabled = True Then LlamarMetodo("AgregarFilaGrid")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.Subtract Then
                If tsbQuitar.Enabled = True Then LlamarMetodo("QuitarFilaGrid")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.B Then
                If tsbBuscar.Enabled = True Then LlamarMetodo("BuscarUnRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Shift + System.Windows.Forms.Keys.Q Then
                If tsbInicio.Enabled = True Then LlamarMetodo("PrimerRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Shift + System.Windows.Forms.Keys.A Then
                If tsbAnterior.Enabled = True Then LlamarMetodo("RegistroAnterior")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Shift + System.Windows.Forms.Keys.S Then
                If tsbSiguiente.Enabled = True Then LlamarMetodo("RegistroSiguiente")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Shift + System.Windows.Forms.Keys.W Then
                If tsbFinal.Enabled = True Then LlamarMetodo("UltimoRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.R Then
                If tsbReportes.Enabled = True Then LlamarMetodo("Reportes")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.S Then
                If tsbSalir.Enabled = True Then LlamarMetodo("Salir")
            End If
        End Sub

        '' FormClosing
        Private Sub frm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

            If pnCuerpo.Enabled = True Then
                If RevisarDatos(False) Then
                    e.Cancel = True
                    MyBase.OnClosing(e)
                Else
                    MyBase.OnClosing(e)
                End If
            End If
        End Sub

        '' Activated
        Private Sub frm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
            If pComportamiento <> -1 Then
                Activado()
                If pDocumentoProcesandose = 1000 Or pDocumentoProcesandose = 2000 Or pDocumentoProcesandose = 3000 Then
                    tsbNuevo.Enabled = False
                    tsbEditar.Enabled = True
                End If
                'If pDocumentoProcesandose = 2000 Then
                '    tsbNuevo.Enabled = False
                '    tsbEditar.Enabled = False
                'End If
            End If
        End Sub
        Private Sub Activado()
            ActivarBarra()
            FormatearBotonesEdicion()
        End Sub
        Private Sub ActivarBarra()
            If tsBarra.Enabled = False Then
                tsBarra.Enabled = True
            End If
        End Sub

        '' FormCLosed
        Private Sub frm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

            If pComportamiento <> -1 Then
                Cerrado()
            End If
        End Sub
        Private Sub Cerrado()
        End Sub
#End Region
#Region "Primaria 2"
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

#Region "Declaraciones - Secundaria"
        <Dependency()> _
        Public Property IBC As Ladisac.BL.IBCDocumentos

        <Dependency()> _
        Public Property IBCDetalle As Ladisac.BL.IBCDetalleDocumentos

        <Dependency()> _
        Public Property IBCDetalleAfectaDocumentos As Ladisac.BL.IBCDetalleAfectaDocumentos

        <Dependency()> _
        Public Property IBCDetalleAfectaProductoDocumentos As Ladisac.BL.IBCDetalleAfectaProductoDocumentos

        <Dependency()> _
        Public Property IBCCorrelativoTipoDocumento As Ladisac.BL.IBCCorrelativoTipoDocumento

        <Dependency()> _
        Public Property IBCPersona As Ladisac.BL.IBCPersona

        <Dependency()> _
        Public Property IBCProforma As Ladisac.BL.IBCDocumentos

        <Dependency()> _
        Public Property IBCDetalleProforma As Ladisac.BL.IBCDetalleDocumentos

        <Dependency()> _
        Public Property IBCKardexCtaCte As Ladisac.BL.IBCKardexCtaCte

        <Dependency()> _
        Public Property IBCDespachos As Ladisac.BL.IBCDespachos

        <Dependency()> _
        Public Property IBCDetalleDespachos As Ladisac.BL.IBCDetalleDespachos

        <Dependency()> _
        Public Property IBCRolOpeCtaCte As Ladisac.BL.IBCRolOpeCtaCte

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        Public Property pBusquedaDevolvioDatos As Boolean = False
        Public Property pPER_FORMA_VENTA As String = ""
        Public Property pPER_TELEFONOS As String = ""
        Public Property pFechaDocumento As String = ""
        Public Property pEmailVendedor As String = ""
        Public Property pTelefonoVendedor As String = ""
        Public Property pTelefonoCliente As String = ""
        Public Property pMaterialPuesto As String = ""
        Public Property pDireccionPuntoVenta As String = ""
        Public Property pTDO_ID As String
        Public Property pDTD_ID As String
        Public Property pPVE_ID As String
        Public Property pMON_ID As String
        Public Property pTIV_ID As String
        Public Property pTDP_ID_CLI As String
        Public Property pTDP_ID_REC As String
        Public Property pDomicilio As Int16
        Public Property pEntrega As Int16
        Public Property pCobranza As Int16
        Public Property pFiscal As Int16
        Public Property pTPE_ID_VEN As String
        Public Property pTPE_ID_COB As String
        Public Property pFLE_TIPO As String
        Public Property pCCT_ID As String
        Public Property pProcesandoProforma As Boolean = False
        Public Property TipoCambioCompraMoneda As Double
        Public Property TipoCambioVentaMoneda As Double
        Public Property pLPR_ID_PrecioEspecialCliente As String = ""
        Public Property pPrecioEspecialCliente As Boolean = False
        Public Property pProcesarDescuentoIncremento As Boolean = True

        Public Property pDLP_PRECIO_MINIMO As Double = 0
        Public Property pDLP_PRECIO_UNITARIO As Double = 0
        Public Property pDLP_RECARGO_ENVIO As Double = 0

        Public Property pDocumentoProcesandose As Int16

        Private vFlagDgvDetalle_CellValidated As Boolean = True
        Private vTextChangedDOC_TIPO_LISTA As Boolean = False

        Private vEsPersonaAgenteCliente As String = "NINGUNO"
        Private vEsPersonaAgenteProveedor As String = "NINGUNO"
        Private vClienteSoloContado As Boolean = False
        Private vClienteLineaCreditoEstado As Boolean = False

        Private vPedidoDocumento As String = ""

        Public Property vPVE_TIPO As String = ""
        Public Property vDOC_TIPO_LISTA As String = ""

        Private vFlagAnticipo As Boolean = False
        Private vColCantidad As String = "cDDO_CANTIDAD" '5
        Private vColPrecio As String = "cDDO_PRE_UNI" '7
        Private vColDescInc As String = "cDDO_DES_INC_PRE" ' 8
        Private vColMontoIGV As String = "cDDO_MONTO_IGV" '9
        Private vColPrecioTotal As String = "cDDO_PRE_TOTAL" '  10
        Private vColIncluyeIGV As String = "cDDO_INC_IGV"

        Public Property pMontoAnticipo As Double = 0
        Public Property pTDO_ID_ANT As String = ""
        Public Property pDTD_ID_ANT As String = ""
        Public Property pCCT_ID_ANT As String = ""
        Public Property pDDO_SERIE_ANT As String = ""
        Public Property pDDO_NUMERO_ANT As String = ""

        ' Controlar la clave de la tabla - Documentos
        Public vCodigoDTD_ID As String = ""
        Public vCodigoDOC_SERIE As String = ""
        Public vCodigoDOC_NUMERO As String = ""

        ' Controlar la clave de la tabla - Proforma
        Public vCodigoProformaTDO_ID As String = ""
        Public vCodigoProformaDTD_ID As String = ""
        Public vCodigoProformaCCT_ID As String = ""
        Public vCodigoProformaDOC_SERIE As String = ""
        Public vCodigoProformaDOC_NUMERO As String = ""

        ' DateTimePicker
        Private EdtpDOC_FECHA_EMI As New dtp

        ' CheckBox
        Private EchkDOC_ASIENTO As New chk
        Private EchkDOC_REQUIERE_GUIA As New chk
        Private EchkDOC_ENTREGADO As New chk

        ' ComboBox
        Private EcboDOC_TIPO_ORDEN_COMPRA As New cbo
        Private EcboDOC_TIPO_LISTA As New cbo
        Private EcboDOC_CIERRE As New cbo
        Private EcboDOC_MOT_EMI As New cbo
        Private EcboDOC_ESTADO As New cbo

        ' DataGridView
        Private EdgvDetalle As New dgv

        ' TextBox
        '' PK
        Private EtxtPVE_ID As New txt
        Private EtxtDTD_ID As New txt
        Private EtxtMON_ID As New txt
        Private EtxtTIV_ID As New txt
        Private EtxtPER_ID_CLI As New txt
        Private EtxtTDP_ID_CLI As New txt
        Private EtxtDIR_ID_FIS As New txt
        Private EtxtDIR_ID_DOM As New txt
        Private EtxtDIR_ID_COB As New txt
        Private EtxtDIR_ID_ENT As New txt
        Private EtxtPER_ID_REC As New txt
        Private EtxtTDP_ID_REC As New txt
        Private EtxtDIR_ID_ENT_REC As New txt
        Private EtxtPER_ID_VEN As New txt
        Private EtxtPER_ID_COB As New txt
        Private EtxtPER_ID_GRU As New txt
        Private EtxtPER_ID_CON As New txt
        Private EtxtPER_ID_PRO As New txt
        Private EtxtPVE_ID_DES As New txt
        Private EtxtLPR_ID As New txt
        Private EtxtFLE_ID As New txt
        Private EtxtCCT_ID As New txt
        Private EtxtCAF_IX_NUMERO_PRO As New txt
        Private EtxtCAF_IX_ORDEN_COM As New txt

        Private EtxtDTD_ID_AFE As New txt
        'Private EtxtCCT_ID_AFE As New txt

        '' Texto
        Private EtxtDOC_SERIE As New txt
        Private EtxtDOC_NUMERO As New txt
        Private EtxtDOC_ORDEN_COMPRA As New txt

        Private EtxtDOC_OBSERVACIONES As New txt

        Private EtxtDOC_SERIE_AFE As New txt
        Private EtxtDOC_NUMERO_AFE As New txt
        Private EtxtDOC_NOMBRE_RECEP As New txt
        Private EtxtDOC_DNI_RECEP As New txt


        '' Número
        Private EtxtDOC_MONTO_TOTAL As New txt
        Private EtxtDOC_CONTRAVALOR As New txt
        Private EtxtDOC_IGV_POR As New txt

        ' Celdas para datos tabla detalle 
        '' PK
        Private EtxtART_ID_IMP As New txt
        Private EtxtART_ID_ANT As New txt
        'Private EtxtCCT_ID_ANT As New txt
        'Private EtxtDDO_ITEM As New txt
        'Private EtxtDDO_NUMERO As New txt
        'Private EtxtDDO_SERIE As New txt
        Private EtxtDTD_ID_ANT As New txt

        Private EtxtDTD_ID_DEV As New txt


        '' Número
        Private EtxtDDO_CANTIDAD As New txt
        Private EtxtDDO_PRE_UNI As New txt
        Private EtxtDDO_DES_INC_PRE As New txt

        Private EtxtTDO_ID_PRO As New txt

        Public Property CuadroTexto As New TextBox
        Public Property BuscarCuadroTexto As Boolean = False

        Private pDevolverDatosUnicoRegistro As Boolean = False

        Private Compuesto As New Ladisac.BE.Documentos
        Private Compuesto1 As New Ladisac.BE.DetalleDocumentos
        Private Compuesto2 As New Ladisac.BE.CorrelativoTipoDocumento
        Private Compuesto3 As New Ladisac.BE.Documentos
        Private Compuesto4 As New Ladisac.BE.DetalleDocumentos
        Private Compuesto6 As New Ladisac.BE.KardexCtaCte
        Private Compuesto7 As New Ladisac.BE.DetalleAfectaDocumentos
        Private Compuesto8 As New Ladisac.BE.DetalleAfectaProductoDocumentos
        Private Compuesto9 As New Ladisac.BE.Despachos
        Private Compuesto10 As New Ladisac.BE.DetalleDespachos

        Private Compuesto00 As New Ladisac.BE.Documentos
        Private Compuesto01 As New Ladisac.BE.DetalleDocumentos

        Private ErrorData As New Ladisac.BE.Documentos.ErrorData
        Private cMisProcedimientos As New Ladisac.MisProcedimientos
        Private Structure ElementosEliminar
            Public cTDO_ID As String
            Public cDTD_ID As String
            Public cDDO_SERIE As String
            Public cDDO_NUMERO As String
            Public cDDO_ITEM As String
        End Structure

        Private Structure dgv
            Public Property pMetodoColumnas As Boolean
            Public Property pAnchoColumna As Int16
            Public Property pColorColumna As Drawing.Color
            Public Property pBloquearPk As Boolean
            Public Property pCampoEstadoRegistro As String
            Public Property pArrayCamposPkDetalle As Object
            Public Columnas() As Int16
            Public Elementos As Int16
        End Structure
#End Region
#Region "Secundaria"
        Private Sub LimpiarDatos()
            vFlagVentaContadoBalanzaServicioEstibaje = False
            vBuscarDetalle = False
            pProcesandoProforma = False
            pLPR_ID_PrecioEspecialCliente = ""
            pPrecioEspecialCliente = False
            pProcesarDescuentoIncremento = True
            pEmailVendedor = ""
            pTelefonoVendedor = ""
            pTelefonoCliente = ""
            pMaterialPuesto = ""
            pDireccionPuntoVenta = ""


            vCodigoProformaTDO_ID = ""
            vCodigoProformaDTD_ID = ""
            vCodigoProformaCCT_ID = ""
            vCodigoProformaDOC_SERIE = ""
            vCodigoProformaDOC_NUMERO = ""

            InicializarValores(txtPVE_ID, ErrorProvider1)
            InicializarValores(txtTDO_ID, ErrorProvider1)
            InicializarValores(txtDTD_ID, ErrorProvider1)

            InicializarValores(cboSerieCorrelativo, ErrorProvider1)
            InicializarValores(txtDOC_SERIE, ErrorProvider1)
            InicializarValores(txtDOC_NUMERO, ErrorProvider1)

            InicializarValores(dtpDOC_FECHA_EMI, ErrorProvider1)
            InicializarValores(dtpDOC_FECHA_ENT, ErrorProvider1)

            InicializarValores(txtMON_ID, ErrorProvider1)
            InicializarValores(txtMON_SIMBOLO, ErrorProvider1)
            InicializarValores(txtMON_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtTIV_ID, ErrorProvider1)
            InicializarValores(txtTIV_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtTIV_DIAS, ErrorProvider1)
            InicializarValores(txtPER_DIAS_CREDITO, ErrorProvider1)
            txtDOC_IGV_POR.Text = SessionService.IGV

            InicializarValores(txtPER_ID_CLI, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_CLI, ErrorProvider1)
            InicializarValores(txtTDP_ID_CLI, ErrorProvider1)
            InicializarValores(txtTDP_DESCRIPCION_CLI, ErrorProvider1)
            InicializarValores(txtDOP_NUMERO_CLI, ErrorProvider1)

            InicializarValores(txtDIR_ID_FIS, ErrorProvider1)
            InicializarValores(txtDIR_DESCRIPCION_FIS, ErrorProvider1)
            InicializarValores(txtDIR_REFERENCIA_FIS, ErrorProvider1)
            InicializarValores(txtDIS_ID_FIS, ErrorProvider1)
            InicializarValores(txtDIS_DESCRIPCION_FIS, ErrorProvider1)
            InicializarValores(txtPRO_ID_FIS, ErrorProvider1)
            InicializarValores(txtPRO_DESCRIPCION_FIS, ErrorProvider1)
            InicializarValores(txtDEP_ID_FIS, ErrorProvider1)
            InicializarValores(txtDEP_DESCRIPCION_FIS, ErrorProvider1)
            InicializarValores(txtPAI_ID_FIS, ErrorProvider1)
            InicializarValores(txtPAI_DESCRIPCION_FIS, ErrorProvider1)

            InicializarValores(txtDIR_ID_DOM, ErrorProvider1)
            InicializarValores(txtDIR_DESCRIPCION_DOM, ErrorProvider1)
            InicializarValores(txtDIR_REFERENCIA_DOM, ErrorProvider1)
            InicializarValores(txtDIS_ID_DOM, ErrorProvider1)
            InicializarValores(txtDIS_DESCRIPCION_DOM, ErrorProvider1)
            InicializarValores(txtPRO_ID_DOM, ErrorProvider1)
            InicializarValores(txtPRO_DESCRIPCION_DOM, ErrorProvider1)
            InicializarValores(txtDEP_ID_DOM, ErrorProvider1)
            InicializarValores(txtDEP_DESCRIPCION_DOM, ErrorProvider1)
            InicializarValores(txtPAI_ID_DOM, ErrorProvider1)
            InicializarValores(txtPAI_DESCRIPCION_DOM, ErrorProvider1)

            InicializarValores(txtDIR_ID_COB, ErrorProvider1)
            InicializarValores(txtDIR_DESCRIPCION_COB, ErrorProvider1)
            InicializarValores(txtDIR_REFERENCIA_COB, ErrorProvider1)
            InicializarValores(txtDIS_ID_COB, ErrorProvider1)
            InicializarValores(txtDIS_DESCRIPCION_COB, ErrorProvider1)
            InicializarValores(txtPRO_ID_COB, ErrorProvider1)
            InicializarValores(txtPRO_DESCRIPCION_COB, ErrorProvider1)
            InicializarValores(txtDEP_ID_COB, ErrorProvider1)
            InicializarValores(txtDEP_DESCRIPCION_COB, ErrorProvider1)
            InicializarValores(txtPAI_ID_COB, ErrorProvider1)
            InicializarValores(txtPAI_DESCRIPCION_COB, ErrorProvider1)

            InicializarValores(txtDIR_ID_ENT, ErrorProvider1)
            InicializarValores(txtDIR_DESCRIPCION_ENT, ErrorProvider1)
            InicializarValores(txtDIR_REFERENCIA_ENT, ErrorProvider1)
            InicializarValores(txtDIS_ID_ENT, ErrorProvider1)
            InicializarValores(txtDIS_DESCRIPCION_ENT, ErrorProvider1)
            InicializarValores(txtPRO_ID_ENT, ErrorProvider1)
            InicializarValores(txtPRO_DESCRIPCION_ENT, ErrorProvider1)
            InicializarValores(txtDEP_ID_ENT, ErrorProvider1)
            InicializarValores(txtDEP_DESCRIPCION_ENT, ErrorProvider1)
            InicializarValores(txtPAI_ID_ENT, ErrorProvider1)
            InicializarValores(txtPAI_DESCRIPCION_ENT, ErrorProvider1)

            InicializarValores(txtPER_ID_REC, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_REC, ErrorProvider1)
            InicializarValores(txtTDP_ID_REC, ErrorProvider1)
            InicializarValores(txtTDP_DESCRIPCION_REC, ErrorProvider1)
            InicializarValores(txtDOP_NUMERO_REC, ErrorProvider1)

            InicializarValores(txtDIR_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtDIR_DESCRIPCION_ENT_REC, ErrorProvider1)
            InicializarValores(txtDIR_REFERENCIA_ENT_REC, ErrorProvider1)
            InicializarValores(txtDIS_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtDIS_DESCRIPCION_ENT_REC, ErrorProvider1)
            InicializarValores(txtPRO_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtPRO_DESCRIPCION_ENT_REC, ErrorProvider1)
            InicializarValores(txtDEP_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtDEP_DESCRIPCION_ENT_REC, ErrorProvider1)
            InicializarValores(txtPAI_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtPAI_DESCRIPCION_ENT_REC, ErrorProvider1)

            EtxtDIR_ID_FIS.pOOrm.CadenaFiltrado = " "
            EtxtDIR_ID_DOM.pOOrm.CadenaFiltrado = " "
            EtxtDIR_ID_COB.pOOrm.CadenaFiltrado = " "
            EtxtDIR_ID_ENT.pOOrm.CadenaFiltrado = " "
            EtxtDIR_ID_ENT_REC.pOOrm.CadenaFiltrado = " "

            InicializarValores(txtDOC_ORDEN_COMPRA, ErrorProvider1)
            InicializarValores(cboDOC_TIPO_ORDEN_COMPRA, ErrorProvider1)
            InicializarValores(dtpDOC_FECHA_EXP, ErrorProvider1)

            InicializarValores(txtLineaContado, ErrorProvider1, True)
            InicializarValores(txtDeudaContado, ErrorProvider1, True)
            InicializarValores(txtDisponibleContado, ErrorProvider1, True)

            InicializarValores(txtLineaContraentregaCredito123, ErrorProvider1, True)
            InicializarValores(txtDeudaContraentregaCredito123, ErrorProvider1, True)
            InicializarValores(txtDisponibleContraentregaCredito123, ErrorProvider1, True)

            InicializarValores(txtPER_LINEA_CREDITO, ErrorProvider1, True)
            InicializarValores(txtDeuda, ErrorProvider1, True)
            InicializarValores(txtDisponible, ErrorProvider1, True)

            InicializarValores(txtPER_ID_VEN, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_VEN, ErrorProvider1)
            InicializarValores(txtPER_ID_COB, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_COB, ErrorProvider1)
            InicializarValores(txtPER_ID_GRU, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_GRU, ErrorProvider1)
            InicializarValores(txtPER_ID_CON, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_CON, ErrorProvider1)
            InicializarValores(txtPER_ID_PRO, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_PRO, ErrorProvider1)

            InicializarValores(txtDOC_OBSERVACIONES, ErrorProvider1)

            InicializarValores(cboDOC_TIPO_LISTA, ErrorProvider1)
            InicializarValores(txtPVE_ID_DES, ErrorProvider1)
            InicializarValores(txtPVE_DESCRIPCION_DES, ErrorProvider1)
            InicializarValores(txtLPR_ID, ErrorProvider1)
            InicializarValores(txtLPR_DESCRIPCION, ErrorProvider1)

            InicializarValores(txtFLE_ID, ErrorProvider1)
            InicializarValores(txtFLE_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtDOC_MONTO_FLE, ErrorProvider1)

            InicializarValores(txtCCT_ID, ErrorProvider1)
            InicializarValores(txtCCT_DESCRIPCION, ErrorProvider1)

            InicializarValores(txtCAF_IX_NUMERO_PRO, ErrorProvider1)
            InicializarValores(txtCAF_IX_ORDEN_COM, ErrorProvider1)

            InicializarValores(chkDOC_ENTREGADO, ErrorProvider1, False, False, EchkDOC_ENTREGADO.pValorDefault)
            ColocarValoresDefault(chkDOC_ENTREGADO)

            InicializarValores(chkDOC_ASIENTO, ErrorProvider1, False, False, EchkDOC_ASIENTO.pValorDefault)
            ColocarValoresDefault(chkDOC_ASIENTO)

            InicializarValores(chkDOC_REQUIERE_GUIA, ErrorProvider1, False, False, EchkDOC_REQUIERE_GUIA.pValorDefault)
            ColocarValoresDefault(chkDOC_REQUIERE_GUIA)

            InicializarValores(txtTDO_ID_AFE, ErrorProvider1)
            InicializarValores(txtDTD_ID_AFE, ErrorProvider1)
            InicializarValores(txtDTD_DESCRIPCION_AFE, ErrorProvider1)
            InicializarValores(txtCCT_ID_AFE, ErrorProvider1)
            InicializarValores(txtCCT_DESCRIPCION_AFE, ErrorProvider1)
            InicializarValores(txtDOC_SERIE_AFE, ErrorProvider1)
            InicializarValores(txtDOC_NUMERO_AFE, ErrorProvider1)

            InicializarValores(txtMON_ID_AFE, ErrorProvider1)
            InicializarValores(txtMONTO_AFE, ErrorProvider1)

            InicializarValores(cboDOC_MOT_EMI, ErrorProvider1)
            InicializarValores(txtDOC_NOMBRE_RECEP, ErrorProvider1)
            InicializarValores(txtDOC_DNI_RECEP, ErrorProvider1)
            InicializarValores(dtpDOC_FEC_RECEP, ErrorProvider1)

            dtpDOC_FECHA_ENT.Value = New DateTime(1900, 1, 1)
            InicializarValores(dtpDOC_HORA_INICIO, ErrorProvider1)
            InicializarValores(dtpDOC_HORA_FIN, ErrorProvider1)
            ColocarHoraFinal()

            InicializarValores(dgvDetalle, ErrorProvider1)
            InicializarValores(dgvDetalleAfectaMonto, ErrorProvider1)
            InicializarValores(dgvDetalleAfectaProducto, ErrorProvider1)

            InicializarValores(tcoDatos, ErrorProvider1)

            DeshabilitarProcesarDescuentos(True, False)

            InicializarValores(txtTotalBruto, ErrorProvider1, True)
            InicializarValores(txtTotDescInc, ErrorProvider1, True)
            InicializarValores(txtExonerado, ErrorProvider1, True)
            InicializarValores(txtBaseImponible, ErrorProvider1, True)
            InicializarValores(txtTotalIGV, ErrorProvider1, True)
            InicializarValores(txtDOC_MONTO_TOTAL, ErrorProvider1, EtxtDOC_MONTO_TOTAL.pSoloNumeros, EtxtDOC_MONTO_TOTAL.pSoloNumerosDecimales)
            InicializarValores(txtDOC_MONTO_PERCEPCION, ErrorProvider1, True)
            FiltrarSeleccionarValidarElementos(2, True)

            chkTransferenciaGratuita.CheckState = CheckState.Unchecked
            chkCanastaNavideña.CheckState = CheckState.Unchecked

            ReDim eRegistrosEliminar(1)
            vBuscarDetalle = True
        End Sub
        Private Sub HabilitarNuevo()
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)
            ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, False)
            ControlVisible(cboSerieCorrelativo, True)
            ConfigurarReadOnlyNoBusqueda(txtDOC_NUMERO, EtxtDOC_NUMERO, False)
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkDOC_ASIENTO)
            ColocarValoresDefault(chkDOC_REQUIERE_GUIA)
            ColocarValoresDefault(chkDOC_ENTREGADO)
            ProcesarGridVacio(1)
        End Sub

        Private Sub CrearCodigoId()
            ProcesarFechaServidor()

            txtPVE_ID.Text = pPVE_ID
            EtxtPVE_ID.pOOrm.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
            MetodoBusquedaDato(txtPVE_ID.Text, True, EtxtPVE_ID)

            txtTDO_ID.Text = pTDO_ID
            txtDTD_ID.Text = pDTD_ID
            MetodoBusquedaDato(txtDTD_ID.Text, True, EtxtDTD_ID)

            txtMON_ID.Text = pMON_ID
            MetodoBusquedaDato(txtMON_ID.Text, True, EtxtMON_ID)

            MetodoBusquedaDato(txtPVE_ID_DES.Text, True, EtxtPVE_ID_DES)

            txtCCT_ID.Text = pCCT_ID
            MetodoBusquedaDato(txtCCT_ID.Text, True, EtxtCCT_ID)

            BuscarSeries()
            FiltroDTD_ID_ANT()

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.VentaBoleta,
                     BCVariablesNames.ProcesosFacturación.PedidoBoleta
                    tcoDirecciones.SelectedTab = tpaDomicilio
                Case BCVariablesNames.ProcesosFacturación.VentaFactura,
                     BCVariablesNames.ProcesosFacturación.PedidoFactura
                    tcoDirecciones.SelectedTab = tpaFiscal
                Case BCVariablesNames.ProcesosFacturación.NotaCredito
                    tcoDatos.SelectedTab = tpaNotas
                Case BCVariablesNames.ProcesosFacturación.NotaDebito
                    tcoDatos.SelectedTab = tpaNotas
            End Select
            txtPER_ID_CLI.Focus()
        End Sub
        Private Sub HabilitarEscrituraNuevo()
            ControlReadOnly(txtDTD_ID, False)
            ControlReadOnly(txtDOC_NUMERO, False)

        End Sub

        Private Sub AdicionarFilasGrid(Optional ByVal vCodigoArticulo As String = "", _
                                       Optional ByVal vDescripcionArticulo As String = "", _
                                       Optional ByVal vDescripcionUnidadMedida As String = "", _
                                       Optional ByVal vCantidad As Double = 0, _
                                       Optional ByVal vFactor As Double = 0, _
                                       Optional ByVal vPrecio As Double = 0, _
                                       Optional ByVal vDescuento As Double = 0, _
                                       Optional ByVal vIncluidoIGV As String = "")
            If Not ValidarAdicionarFilasGrid() Then Exit Sub
            dgvDetalle.Rows.Add(EdgvDetalle.Elementos + 1, _
                                vCodigoArticulo, vCodigoArticulo, vDescripcionArticulo, vDescripcionUnidadMedida, _
                                vCantidad, vFactor, vPrecio, vDescuento, 0, 0, "", _
                                "", "", "", "", "", "ACTIVO", vIncluidoIGV, SessionService.IGV, "NO PERCEPCION", 0)
            ProcesarGridVacio()
            EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
            dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells(1)
            dgvDetalle.Focus()
            dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.RowCount - 1).Cells("cART_ID_IMP") 'mover a la fila 10
        End Sub
        Private Sub EliminarFilasGrid()
            If dgvDetalleAfectaMonto.Focused Then
                If Not dgvDetalleAfectaMonto.Enabled Then Return
                SubEliminarFilasGridAfectaMonto()
                Exit Sub
            End If
            If dgvDetalleAfectaProducto.Focused Then
                If Not dgvDetalleAfectaProducto.Enabled Then Return
                SubEliminarFilasGridAfectaProducto()
                Exit Sub
            End If
            'If dgvDetalle.Focused Then
            If Not dgvDetalle.Enabled Then Return
            SubEliminarFilasGrid()
            'End If
        End Sub
        Private Sub SubEliminarFilasGrid(Optional ByVal vRow As Int16 = 0)
            If dgvDetalleAfectaProducto.Rows.Count > 0 Then
                MsgBox("No se puede eliminar registro." & Chr(13) & "Existen registros en ''Afecta producto''", MsgBoxStyle.Information, Me.Text & "- QuitarFilaGrid")
                Exit Sub
            End If
            Dim vFlagCalcularMontos As Boolean = False
            If dgvDetalle.Rows.Count = 0 Then Return

            If vRow = 0 Then
                vRow = dgvDetalle.CurrentRow.Index
                vFlagCalcularMontos = True
            End If

            Dim vfila As DataGridViewRow

            vfila = dgvDetalle.Rows(vRow)
            If dgvDetalle.Rows.Count > 0 Then
                Try
                    With dgvDetalle.Rows(vRow)
                        If .Cells("cEstadoRegistro").Value Then
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cTDO_ID = txtTDO_ID.Text
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTD_ID = txtDTD_ID.Text
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDDO_SERIE = txtDOC_SERIE.Text
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDDO_NUMERO = txtDOC_NUMERO.Text
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDDO_ITEM = .Cells("cITEM").Value.ToString()
                            ReDim Preserve eRegistrosEliminar(eRegistrosEliminar.Count)
                        End If
                    End With
                    dgvDetalle.Rows.Remove(vfila)
                    ProcesarGridVacio()
                    If vFlagCalcularMontos Then CalcularMontoDocumento(1)
                Catch ex As Exception
                    MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- QuitarFilaGrid")
                End Try
            End If
        End Sub
        Private Sub SubEliminarFilasGridAfectaMonto(Optional ByVal vRow As Int16 = 0)
            If dgvDetalleAfectaMonto.Rows.Count = 0 Then Return

            If vRow = 0 Then
                vRow = dgvDetalleAfectaMonto.CurrentRow.Index
            End If

            Dim vfila As DataGridViewRow

            vfila = dgvDetalleAfectaMonto.Rows(vRow)
            If dgvDetalleAfectaMonto.Rows.Count > 0 Then
                Try
                    dgvDetalleAfectaMonto.Rows.Remove(vfila)
                Catch ex As Exception
                    MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- QuitarFilaGrid")
                End Try
            End If
        End Sub
        Private Sub SubEliminarFilasGridAfectaProducto(Optional ByVal vRow As Int16 = 0)
            If dgvDetalleAfectaProducto.Rows.Count = 0 Then Return

            If vRow = 0 Then
                vRow = dgvDetalleAfectaProducto.CurrentRow.Index
            End If

            Dim vfila As DataGridViewRow

            vfila = dgvDetalleAfectaProducto.Rows(vRow)
            If dgvDetalleAfectaProducto.Rows.Count > 0 Then
                Try
                    dgvDetalleAfectaProducto.Rows.Remove(vfila)
                Catch ex As Exception
                    MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- QuitarFilaGrid")
                End Try
            End If
        End Sub

        Public Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "CancelarEdicion"
                    CodigoId = CodigoId & vCodigoDTD_ID & vCodigoDOC_SERIE & vCodigoDOC_NUMERO
                    If Trim(CodigoId) = "" Then CodigoId = "%"
                Case "PrepararEliminar"
                    Compuesto.Vista = "RegistroAnterior"
                    Compuesto.TDO_ID = CodigoId
                    Compuesto.DTD_ID = vCodigoDTD_ID
                    Compuesto.DOC_SERIE = vCodigoDOC_SERIE
                    Compuesto.DOC_NUMERO = vCodigoDOC_NUMERO
                Case "Load"
                    Compuesto.Vista = "PrimerAnterior"
                    Compuesto.TDO_ID = CodigoId
                    Compuesto.DTD_ID = vCodigoDTD_ID
                    Compuesto.DOC_SERIE = vCodigoDOC_SERIE
                    Compuesto.DOC_NUMERO = vCodigoDOC_NUMERO
                Case "RegistroNoEncontrado"
                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    Compuesto.DOC_SERIE = txtDOC_SERIE.Text.Trim
                    Compuesto.DOC_NUMERO = txtDOC_NUMERO.Text.Trim

                    CodigoId = Compuesto.TDO_ID
                    vCodigoDTD_ID = Compuesto.DTD_ID
                    vCodigoDOC_SERIE = Compuesto.DOC_SERIE
                    vCodigoDOC_NUMERO = Compuesto.DOC_NUMERO
                Case "NavegarFormulario"
                    CodigoId = CodigoId & vCodigoDTD_ID & vCodigoDOC_SERIE & vCodigoDOC_NUMERO
                Case "EliminarRegistro"
                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim
                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim
                    Compuesto.DOC_SERIE = txtDOC_SERIE.Text.Trim
                    vCodigoDOC_SERIE = txtDOC_SERIE.Text.Trim
                    Compuesto.DOC_NUMERO = txtDOC_NUMERO.Text.Trim
                    vCodigoDOC_NUMERO = txtDOC_NUMERO.Text.Trim
                Case "InicializarDatos"
                    InicializarValores(dgvDetalle, ErrorProvider1)
                    InicializarValores(dgvDetalleAfectaMonto, ErrorProvider1)
                    InicializarValores(dgvDetalleAfectaProducto, ErrorProvider1)

                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim
                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim
                    Compuesto.DOC_SERIE = txtDOC_SERIE.Text.Trim
                    vCodigoDOC_SERIE = txtDOC_SERIE.Text.Trim
                    Compuesto.DOC_NUMERO = txtDOC_NUMERO.Text.Trim
                    vCodigoDOC_NUMERO = txtDOC_NUMERO.Text.Trim

                    Compuesto1.TDO_ID = txtTDO_ID.Text.Trim
                    Compuesto1.DTD_ID = txtDTD_ID.Text.Trim
                    Compuesto1.DDO_SERIE = txtDOC_SERIE.Text.Trim
                    Compuesto1.DDO_NUMERO = txtDOC_NUMERO.Text.Trim

                    If vBuscarDetalle Then
                        BuscarDetalle(CodigoId, vCodigoDTD_ID, vCodigoDOC_SERIE, vCodigoDOC_NUMERO, txtCCT_ID.Text.Trim)

                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosFacturación.NotaCredito
                                BuscarDetalleNotaCredito(CodigoId, vCodigoDTD_ID, vCodigoDOC_SERIE, vCodigoDOC_NUMERO)
                            Case Else
                        End Select
                    End If
            End Select
        End Sub
        Public Sub BuscarDetalle(ByVal CodigoTDO_ID As String, _
                                 ByVal CodigoDTD_ID As String, _
                                 ByVal CodigoDOC_SERIE As String, _
                                 ByVal CodigoDOC_NUMERO As String, _
                                 ByVal CodigoCCT_ID As String, _
                                 Optional ByVal vProcesarProforma As Boolean = False)
            Compuesto1.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                CodigoTDO_ID, _
                                                                CodigoDTD_ID, _
                                                                CodigoDOC_SERIE, _
                                                                CodigoDOC_NUMERO, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                dgvDetalle.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
                        dgvDetalle.Rows.Add()
                        With ds.Tables(0).Rows(x)
                            While y < ds.Tables(0).Columns.Count
                                Select Case ds.Tables(0).Columns(y).ColumnName
                                    Case "Cantidad", "Precio_unitario", "Precio_Total"
                                        If IsNumeric(.Item(y).ToString()) Then
                                            vCadenaGeType = Val(.Item(y).ToString).GetType.ToString '"System.Double"
                                        ElseIf IsDate(.Item(y).ToString()) Then
                                            vCadenaGeType = CDate(.Item(y).ToString).GetType.ToString '"System.DateTime"
                                        Else
                                            vCadenaGeType = .Item(y).GetType.ToString
                                        End If
                                    Case Else
                                        vCadenaGeType = .Item(y).GetType.ToString
                                End Select
                                dgvDetalle.Item(y, dgvDetalle.Rows.Count - 1).Value = Formatos(vCadenaGeType, .Item(y).ToString())
                                y = y + 1
                            End While
                            y = 0
                        End With
                        x += 1
                        EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information, Me.Text)
                End If
                CalcularMontoDocumento(0)
                If vProcesarProforma Then
                    vCodigoProformaTDO_ID = CodigoTDO_ID
                    vCodigoProformaDTD_ID = CodigoDTD_ID
                    vCodigoProformaCCT_ID = CodigoCCT_ID
                    vCodigoProformaDOC_SERIE = CodigoDOC_SERIE
                    vCodigoProformaDOC_NUMERO = CodigoDOC_NUMERO
                    ProcesarJalarProforma()
                Else
                    vCodigoProformaTDO_ID = ""
                    vCodigoProformaDTD_ID = ""
                    vCodigoProformaCCT_ID = ""
                    vCodigoProformaDOC_SERIE = ""
                    vCodigoProformaDOC_NUMERO = ""
                End If
            Else
                dgvDetalle.DataSource = Nothing
            End If
        End Sub

        Public Sub BuscarDetalleNotaCredito(ByVal CodigoTDO_ID As String, _
                                            ByVal CodigoDTD_ID As String, _
                                            ByVal CodigoDOC_SERIE As String, _
                                            ByVal CodigoDOC_NUMERO As String)

            Compuesto7.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Compuesto7.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                CodigoTDO_ID, _
                                                                CodigoDTD_ID, _
                                                                CodigoDOC_SERIE, _
                                                                CodigoDOC_NUMERO, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                dgvDetalleAfectaMonto.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
                        dgvDetalleAfectaMonto.Rows.Add()
                        With ds.Tables(0).Rows(x)
                            While y < ds.Tables(0).Columns.Count
                                Select Case ds.Tables(0).Columns(y).ColumnName
                                    Case "Total"
                                        If IsNumeric(.Item(y).ToString()) Then
                                            vCadenaGeType = Val(.Item(y).ToString).GetType.ToString '"System.Double"
                                        ElseIf IsDate(.Item(y).ToString()) Then
                                            vCadenaGeType = CDate(.Item(y).ToString).GetType.ToString '"System.DateTime"
                                        Else
                                            vCadenaGeType = .Item(y).GetType.ToString
                                        End If
                                    Case Else
                                        vCadenaGeType = .Item(y).GetType.ToString
                                End Select
                                dgvDetalleAfectaMonto.Item(y, dgvDetalleAfectaMonto.Rows.Count - 1).Value = Formatos(vCadenaGeType, .Item(y).ToString())
                                y = y + 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information, Me.Text)
                End If
            Else
                dgvDetalleAfectaMonto.DataSource = Nothing
            End If


            Compuesto8.Vista = "ListarRegistros"
            NombreProcedimiento = Compuesto8.SentenciaSqlBusqueda()
            Dim ds1 As New DataSet
            Dim sr1 = New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                           CodigoTDO_ID, _
                                                           CodigoDTD_ID, _
                                                           CodigoDOC_SERIE, _
                                                           CodigoDOC_NUMERO, Nothing))
            vcontrol = sr1.Peek
            If vcontrol <> -1 Then
                ds1.ReadXml(sr1)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                dgvDetalleAfectaProducto.Rows.Clear()
                If (ds1.Tables(0).Rows.Count > 0) Then
                    While (x < ds1.Tables(0).Rows.Count)
                        dgvDetalleAfectaProducto.Rows.Add()
                        With ds1.Tables(0).Rows(x)
                            While y < ds1.Tables(0).Columns.Count
                                Select Case ds1.Tables(0).Columns(y).ColumnName
                                    Case "Cantidad"
                                        If IsNumeric(.Item(y).ToString()) Then
                                            vCadenaGeType = Val(.Item(y).ToString).GetType.ToString '"System.Double"
                                        ElseIf IsDate(.Item(y).ToString()) Then
                                            vCadenaGeType = CDate(.Item(y).ToString).GetType.ToString '"System.DateTime"
                                        Else
                                            vCadenaGeType = .Item(y).GetType.ToString
                                        End If
                                    Case Else
                                        vCadenaGeType = .Item(y).GetType.ToString
                                End Select
                                dgvDetalleAfectaProducto.Item(y, dgvDetalleAfectaProducto.Rows.Count - 1).Value = Formatos(vCadenaGeType, .Item(y).ToString())
                                y = y + 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information, Me.Text)
                End If
            Else
                dgvDetalleAfectaProducto.DataSource = Nothing
            End If

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
        Private Sub ProcesarKardexCtaCte()
            Dim vFilGrid As Integer = 0
            Dim vItem As Integer = 1

            Dim CargoAbono As String = ""
            Dim SignoCargoAbono As String = ""
            Dim CargoAbonoAnt As String = ""
            Dim SignoCargoAbonoAnt As String = ""
            Dim vCargoPercepcion As Double = 0
            Dim vAbonoPercepcion As Double = 0
            Dim vContraValorPercepcion As Double = 0
            Dim vCargo As Double = 0
            Dim vAbono As Double = 0
            Dim vContraValor As Double = 0

            Dim vCUC_ID As String
            Dim vCCO_ID As String
            Dim vCCC_ID As String
            Dim vMON_ID As String

            Dim vCCT_ID As String
            Dim vTDO_ID As String
            Dim vDTD_ID As String
            Dim vDOC_SERIE As String
            Dim vDOC_NUMERO As String

            Dim vCCT_ID_AFE As String
            Dim vTDO_ID_AFE As String
            Dim vDTD_ID_AFE As String
            Dim vDOC_SERIE_AFE As String
            Dim vDOC_NUMERO_AFE As String

            Dim vCCT_ID_ANT As String
            Dim vTDO_ID_ANT As String
            Dim vDTD_ID_ANT As String
            Dim vDDO_SERIE_ANT As String
            Dim vDDO_NUMERO_ANT As String

            Dim vPER_ID_CLI As String
            Dim vMPT_MEDIO_PAGO As Int16
            Dim vPER_ID_BAN As String

            dgvKardexCtaCte.Rows.Clear()

            If dgvDetalle.Rows.Count() = 0 Then
                Exit Sub
            End If

            If cboDOC_ESTADO.Text <> "ACTIVO" Then
                Exit Sub
            End If

            Dim vTIV_FORMA_VENTA As String
            vTIV_FORMA_VENTA = Me.IBCBusqueda.FormaVentaTipoVenta(txtTIV_ID.Text)

            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    If cboDOC_ESTADO.Text = "ACTIVO" Then
                        vCUC_ID = Nothing
                        vCCO_ID = Nothing
                        vCCC_ID = Nothing
                        vCCT_ID = txtCCT_ID.Text
                        vTDO_ID = txtTDO_ID.Text
                        vDTD_ID = txtDTD_ID.Text
                        vDOC_SERIE = txtDOC_SERIE.Text
                        vDOC_NUMERO = txtDOC_NUMERO.Text
                        vMON_ID = txtMON_ID.Text
                        vPER_ID_CLI = txtPER_ID_CLI.Text
                        vPER_ID_BAN = Nothing
                        vMPT_MEDIO_PAGO = Nothing

                        vCCT_ID_AFE = txtCCT_ID_AFE.Text
                        vTDO_ID_AFE = txtTDO_ID_AFE.Text
                        vDTD_ID_AFE = txtDTD_ID_AFE.Text
                        vDOC_SERIE_AFE = txtDOC_SERIE_AFE.Text
                        vDOC_NUMERO_AFE = txtDOC_NUMERO_AFE.Text

                        vCCT_ID_ANT = .Cells("cCCT_ID_ANT").Value
                        vTDO_ID_ANT = .Cells("cTDO_ID_ANT").Value
                        If .Cells("cDTD_ID_ANT").Value Is Nothing Then
                            vDTD_ID_ANT = ""
                        Else
                            vDTD_ID_ANT = .Cells("cDTD_ID_ANT").Value
                        End If

                        vDDO_SERIE_ANT = .Cells("cDDO_SERIE_ANT").Value
                        vDDO_NUMERO_ANT = .Cells("cDDO_NUMERO_ANT").Value

                        CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                    vCCT_ID, _
                                                    vTDO_ID, _
                                                    vDTD_ID)
                        SignoCargoAbono = Me.IBCRolOpeCtaCte.SignoCargoAbonoRolOpeCtaCte(
                                                    vCCT_ID, _
                                                    vTDO_ID, _
                                                    vDTD_ID)

                        If vFilGrid = 0 Then
                            '/* Documentos - ventas, 1er nivel */
                            '/* lado izquierdo - cabecera */                
                            If CargoAbono <> "NINGUNO" And _
                               cboDOC_ESTADO.Text = "ACTIVO" Then
                                If CargoAbono = "CARGO" Then
                                    If SignoCargoAbono = "+" Then
                                        vCargo = CDbl(txtDOC_MONTO_TOTAL.Text)
                                        vCargoPercepcion = CDbl(txtDOC_MONTO_PERCEPCION.Text)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vCargo = CDbl(txtDOC_MONTO_TOTAL.Text) * -1
                                        vCargoPercepcion = CDbl(txtDOC_MONTO_PERCEPCION.Text) * -1
                                    Else
                                        vCargo = 0
                                        vCargoPercepcion = 0
                                    End If
                                Else
                                    vCargo = 0
                                    vCargoPercepcion = 0
                                End If

                                If CargoAbono = "ABONO" Then
                                    If SignoCargoAbono = "+" Then
                                        vAbono = CDbl(txtDOC_MONTO_TOTAL.Text)
                                        vAbonoPercepcion = CDbl(txtDOC_MONTO_PERCEPCION.Text)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vAbono = CDbl(txtDOC_MONTO_TOTAL.Text) * -1
                                        vAbonoPercepcion = CDbl(txtDOC_MONTO_PERCEPCION.Text) * -1
                                    Else
                                        vAbono = 0
                                        vAbonoPercepcion = 0
                                    End If
                                Else
                                    vAbono = 0
                                    vAbonoPercepcion = 0
                                End If

                                vContraValor = 0
                                vContraValorPercepcion = 0

                                dgvKardexCtaCte.Rows.Add(
                                                dtpDOC_FECHA_EMI.Value,
                                                dtpDOC_FECHA_EMI.Value,
                                                vCUC_ID,
                                                vCCO_ID,
                                                vCCC_ID,
                                                vCCT_ID,
                                                vTDO_ID,
                                                vDTD_ID,
                                                vDOC_SERIE,
                                                vDOC_NUMERO,
                                                vItem,
                                                vMON_ID,
                                                vCCC_ID,
                                                vCCT_ID,
                                                vTDO_ID,
                                                vDTD_ID,
                                                vDOC_SERIE,
                                                vDOC_NUMERO,
                                                vItem,
                                                vMON_ID,
                                                vPER_ID_CLI,
                                                vCargo,
                                                vAbono,
                                                vContraValor,
                                                vMPT_MEDIO_PAGO,
                                                "",
                                                vPER_ID_BAN,
                                                vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_NUMERO
                                                        )
                                Select Case pDTD_ID
                                    Case BCVariablesNames.ProcesosFacturación.PBBoleta, _
                                        BCVariablesNames.ProcesosFacturación.PFFactura
                                    Case Else

                                        If BCVariablesNames.TipoVentaDescripcion.Contado = vTIV_FORMA_VENTA Or _
                                           BCVariablesNames.TipoVentaDescripcion.ContraentregaEnPlanta = vTIV_FORMA_VENTA Or _
                                           BCVariablesNames.TipoVentaDescripcion.Contraentrega = vTIV_FORMA_VENTA Then
                                            If Val(txtDOC_MONTO_PERCEPCION.Text) > 0 Then
                                                Dim vDocumentoPercepcion As String = ""
                                                Select Case pTDO_ID
                                                    Case BCVariablesNames.ProcesosFacturación.VentaBoleta
                                                        vDocumentoPercepcion = BCVariablesNames.ProcesosFacturación.BoletaPercepcion
                                                    Case BCVariablesNames.ProcesosFacturación.VentaFactura
                                                        vDocumentoPercepcion = BCVariablesNames.ProcesosFacturación.FacturaPercepcion
                                                End Select
                                                dgvKardexCtaCte.Rows.Add(
                                                                        dtpDOC_FECHA_EMI.Value,
                                                                         dtpDOC_FECHA_EMI.Value,
                                                                         vCUC_ID,
                                                                         vCCO_ID,
                                                                         vCCC_ID,
                                                                         vCCT_ID,
                                                                         vTDO_ID,
                                                                         vDocumentoPercepcion,
                                                                         vDOC_SERIE,
                                                                         vDOC_NUMERO,
                                                                         vItem,
                                                                         vMON_ID,
                                                                         vCCC_ID,
                                                                         vCCT_ID,
                                                                         vTDO_ID,
                                                                         vDocumentoPercepcion,
                                                                         vDOC_SERIE,
                                                                         vDOC_NUMERO,
                                                                         vItem,
                                                                         vMON_ID,
                                                                         vPER_ID_CLI,
                                                                         vCargoPercepcion,
                                                                         vAbonoPercepcion,
                                                                         vContraValorPercepcion,
                                                                         vMPT_MEDIO_PAGO,
                                                                         "",
                                                                         vPER_ID_BAN,
                                                                         vTDO_ID & vDocumentoPercepcion & vDOC_SERIE & vDOC_NUMERO
                                                                         )
                                            End If
                                        End If
                                End Select
                                vItem = vItem + 1
                            End If

                            SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                            vCCT_ID, _
                            vTDO_ID, _
                            vDTD_ID)

                            '/* Referencias de documentos - nota de crédito, débito */
                            '/* cuando el afectado actua como referencia */
                            '/* DTD_SIGNO_D lado derecho en 1er nivel */
                            '/* Se refleja en el kardex para el documento afectado */
                            If CargoAbono <> "NINGUNO" And _
                               cboDOC_ESTADO.Text = "ACTIVO" And _
                               vTDO_ID_AFE <> "" Then
                                If CargoAbono = "CARGO" Then
                                    If SignoCargoAbono = "+" Then
                                        vCargo = CDbl(txtDOC_MONTO_TOTAL.Text)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vCargo = CDbl(txtDOC_MONTO_TOTAL.Text) * -1
                                    Else
                                        vCargo = 0
                                    End If
                                Else
                                    vCargo = 0
                                End If

                                If CargoAbono = "ABONO" Then
                                    If SignoCargoAbono = "+" Then
                                        vAbono = CDbl(txtDOC_MONTO_TOTAL.Text)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vAbono = CDbl(txtDOC_MONTO_TOTAL.Text) * -1
                                    Else
                                        vAbono = 0
                                    End If
                                Else
                                    vAbono = 0
                                End If

                                vContraValor = 0

                                dgvKardexCtaCte.Rows.Add(
                                                dtpDOC_FECHA_EMI.Value,
                                                dtpDOC_FECHA_EMI.Value,
                                                vCUC_ID,
                                                vCCO_ID,
                                                vCCC_ID,
                                                vCCT_ID_AFE,
                                                vTDO_ID_AFE,
                                                vDTD_ID_AFE,
                                                vDOC_SERIE_AFE,
                                                vDOC_NUMERO_AFE,
                                                vItem,
                                                vMON_ID,
                                                vCCC_ID,
                                                vCCT_ID,
                                                vTDO_ID,
                                                vDTD_ID,
                                                vDOC_SERIE,
                                                vDOC_NUMERO,
                                                vItem,
                                                vMON_ID,
                                                vPER_ID_CLI,
                                                vCargo,
                                                vAbono,
                                                vContraValor,
                                                vMPT_MEDIO_PAGO,
                                                "",
                                                vPER_ID_BAN,
                                                vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_NUMERO
                                                        )
                                vItem = vItem + 1
                            End If

                            '/* Referencias de documentos - nota de crédito, débito */
                            '/* Cuando el principal actua como referencia */
                            '/* DTD_SIGNO_D lado derecho en 1er nivel */
                            '/* Se refleja en el kardex para el documento principal */
                            If CargoAbono <> "NINGUNO" And _
                               cboDOC_ESTADO.Text = "ACTIVO" And _
                               vTDO_ID_AFE <> "" Then
                                If CargoAbono = "CARGO" Then
                                    If SignoCargoAbono = "+" Then
                                        vCargo = CDbl(txtDOC_MONTO_TOTAL.Text)
                                    ElseIf SignoCargoAbono = "-" Then
                                        If vCCT_ID & vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_SERIE = vCCT_ID_AFE & vTDO_ID_AFE & vDTD_ID_AFE & vDOC_SERIE_AFE & vDOC_SERIE_AFE Then
                                            vCargo = CDbl(txtDOC_MONTO_TOTAL.Text)
                                        Else
                                            vCargo = CDbl(txtDOC_MONTO_TOTAL.Text) * -1
                                        End If
                                    Else
                                        vCargo = 0
                                    End If
                                Else
                                    vCargo = 0
                                End If

                                If CargoAbono = "ABONO" Then
                                    If SignoCargoAbono = "+" Then
                                        vAbono = CDbl(txtDOC_MONTO_TOTAL.Text)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vAbono = CDbl(txtDOC_MONTO_TOTAL.Text) * -1
                                    Else
                                        vAbono = 0
                                    End If
                                Else
                                    vAbono = 0
                                End If

                                vContraValor = 0

                                dgvKardexCtaCte.Rows.Add(
                                                dtpDOC_FECHA_EMI.Value,
                                                dtpDOC_FECHA_EMI.Value,
                                                vCUC_ID,
                                                vCCO_ID,
                                                vCCC_ID,
                                                vCCT_ID,
                                                vTDO_ID,
                                                vDTD_ID,
                                                vDOC_SERIE,
                                                vDOC_NUMERO,
                                                vItem,
                                                vMON_ID,
                                                vCCC_ID,
                                                vCCT_ID_AFE,
                                                vTDO_ID_AFE,
                                                vDTD_ID_AFE,
                                                vDOC_SERIE_AFE,
                                                vDOC_NUMERO_AFE,
                                                vItem,
                                                vMON_ID,
                                                vPER_ID_CLI,
                                                vCargo,
                                                vAbono,
                                                vContraValor,
                                                vMPT_MEDIO_PAGO,
                                                "",
                                                vPER_ID_BAN,
                                                vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_NUMERO
                                                        )
                                vItem = vItem + 1
                            End If
                        End If

                        CargoAbonoAnt = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                            vCCT_ID_ANT, _
                                            vTDO_ID_ANT, _
                                            vDTD_ID_ANT)

                        SignoCargoAbonoAnt = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                            vCCT_ID_ANT, _
                                            vTDO_ID_ANT, _
                                            vDTD_ID_ANT)

                        '/* Referencias de documentos (detalle)- Anticipos */
                        '/* DTD_SIGNO_D_ANT equivalente a DTD_SIGNO_D, lado derecho en 1er nivel */
                        '/* Descuenta los pagos hechos a cuenta del anticipo */
                        If CargoAbono <> "NINGUNO" And _
                           cboDOC_ESTADO.Text = "ACTIVO" And _
                           vTDO_ID_ANT <> "" Then
                            If CargoAbonoAnt = "CARGO" Then
                                If SignoCargoAbonoAnt = "+" Then
                                    vCargo = Math.Abs(CDbl(.Cells("cDDO_DES_INC_PRE").Value))
                                ElseIf SignoCargoAbonoAnt = "-" Then
                                    vCargo = Math.Abs(CDbl(.Cells("cDDO_DES_INC_PRE").Value) * -1)
                                Else
                                    vCargo = 0
                                End If
                            Else
                                vCargo = 0
                            End If

                            If CargoAbonoAnt = "ABONO" Then
                                If SignoCargoAbonoAnt = "+" Then
                                    vAbono = CDbl(.Cells("cDDO_DES_INC_PRE").Value)
                                ElseIf SignoCargoAbono = "-" Then
                                    vAbono = CDbl(.Cells("cDDO_DES_INC_PRE").Value) * -1
                                Else
                                    vAbono = 0
                                End If
                            Else
                                vAbono = 0
                            End If

                            vContraValor = 0

                            dgvKardexCtaCte.Rows.Add(
                                            dtpDOC_FECHA_EMI.Value,
                                            dtpDOC_FECHA_EMI.Value,
                                            vCUC_ID,
                                            vCCO_ID,
                                            vCCC_ID,
                                            vCCT_ID_ANT,
                                            vTDO_ID_ANT,
                                            vDTD_ID_ANT,
                                            vDDO_SERIE_ANT,
                                            vDDO_NUMERO_ANT,
                                            vItem,
                                            vMON_ID,
                                            vCCC_ID,
                                            vCCT_ID,
                                            vTDO_ID,
                                            vDTD_ID,
                                            vDOC_SERIE,
                                            vDOC_NUMERO,
                                            vItem,
                                            vMON_ID,
                                            vPER_ID_CLI,
                                            vCargo,
                                            vAbono,
                                            vContraValor,
                                            vMPT_MEDIO_PAGO,
                                            "",
                                            vPER_ID_BAN,
                                            vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_NUMERO
                                                    )
                            vItem = vItem + 1
                        End If
                    End If
                End With
                vFilGrid += 1
            End While
        End Sub

        Private Sub ProcesarKardexCtaCteNotaCredito()
            Dim vFilGrid As Integer = 0
            Dim vItem As Integer = 1

            Dim CargoAbono As String = ""
            Dim SignoCargoAbono As String = ""
            Dim vCargoPercepcion As Double = 0
            Dim vAbonoPercepcion As Double = 0
            Dim vContraValorPercepcion As Double = 0
            Dim vCargo As Double = 0
            Dim vAbono As Double = 0
            Dim vContraValor As Double = 0

            Dim vCUC_ID As String
            Dim vCCO_ID As String
            Dim vCCC_ID As String
            Dim vMON_ID As String

            Dim vCCT_ID As String
            Dim vTDO_ID As String
            Dim vDTD_ID As String
            Dim vDOC_SERIE As String
            Dim vDOC_NUMERO As String

            Dim vCCT_ID_AFE As String
            Dim vTDO_ID_AFE As String
            Dim vDTD_ID_AFE As String
            Dim vDOC_SERIE_AFE As String
            Dim vDOC_NUMERO_AFE As String

            Dim vPER_ID_CLI As String
            Dim vMPT_MEDIO_PAGO As Int16
            Dim vPER_ID_BAN As String

            Dim vTotalMontoAfecta As Double = 0

            dgvKardexCtaCte.Rows.Clear()

            If dgvDetalle.Rows.Count() = 0 Then
                Exit Sub
            End If

            If cboDOC_ESTADO.Text <> "ACTIVO" Then
                Exit Sub
            End If

            Dim vTIV_FORMA_VENTA As String
            vTIV_FORMA_VENTA = Me.IBCBusqueda.FormaVentaTipoVenta(txtTIV_ID.Text)

            If dgvDetalleAfectaMonto.Rows.Count > 0 Then
                While (dgvDetalleAfectaMonto.Rows.Count() > vFilGrid)
                    With dgvDetalleAfectaMonto.Rows(vFilGrid)
                        If cboDOC_ESTADO.Text = "ACTIVO" Then
                            vCUC_ID = Nothing
                            vCCO_ID = Nothing
                            vCCC_ID = Nothing
                            vCCT_ID = txtCCT_ID.Text
                            vTDO_ID = txtTDO_ID.Text
                            vDTD_ID = txtDTD_ID.Text
                            vDOC_SERIE = txtDOC_SERIE.Text
                            vDOC_NUMERO = txtDOC_NUMERO.Text
                            vMON_ID = txtMON_ID.Text
                            vPER_ID_CLI = txtPER_ID_CLI.Text
                            vPER_ID_BAN = Nothing
                            vMPT_MEDIO_PAGO = Nothing

                            vCCT_ID_AFE = .Cells("cCCT_ID_AFE").Value
                            vTDO_ID_AFE = .Cells("cTDO_ID_AFE").Value
                            vDTD_ID_AFE = .Cells("cDTD_ID_AFE").Value
                            vDOC_SERIE_AFE = .Cells("cDOC_SERIE_AFE").Value
                            vDOC_NUMERO_AFE = .Cells("cDOC_NUMERO_AFE").Value

                            vTotalMontoAfecta = vTotalMontoAfecta + CDbl(.Cells("cDDA_PRE_TOTAL").Value)

                            CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                        vCCT_ID, _
                                                        vTDO_ID, _
                                                        vDTD_ID)
                            SignoCargoAbono = Me.IBCRolOpeCtaCte.SignoCargoAbonoRolOpeCtaCte(
                                                        vCCT_ID, _
                                                        vTDO_ID, _
                                                        vDTD_ID)

                            '/* Documentos - ventas, 1er nivel */
                            '/* lado izquierdo - cabecera */                
                            If CargoAbono <> "NINGUNO" And _
                               cboDOC_ESTADO.Text = "ACTIVO" Then
                                If CargoAbono = "CARGO" Then
                                    If SignoCargoAbono = "+" Then
                                        vCargo = CDbl(.Cells("cDDA_PRE_TOTAL").Value)
                                        vCargoPercepcion = CDbl(0)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vCargo = CDbl(.Cells("cDDA_PRE_TOTAL").Value) * -1
                                        vCargoPercepcion = CDbl(0) * -1
                                    Else
                                        vCargo = 0
                                        vCargoPercepcion = 0
                                    End If
                                Else
                                    vCargo = 0
                                    vCargoPercepcion = 0
                                End If

                                If CargoAbono = "ABONO" Then
                                    If SignoCargoAbono = "+" Then
                                        vAbono = CDbl(.Cells("cDDA_PRE_TOTAL").Value)
                                        vAbonoPercepcion = CDbl(0)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vAbono = CDbl(.Cells("cDDA_PRE_TOTAL").Value) * -1
                                        vAbonoPercepcion = CDbl(0) * -1
                                    Else
                                        vAbono = 0
                                        vAbonoPercepcion = 0
                                    End If
                                Else
                                    vAbono = 0
                                    vAbonoPercepcion = 0
                                End If

                                vContraValor = 0
                                vContraValorPercepcion = 0

                                dgvKardexCtaCte.Rows.Add(
                                                dtpDOC_FECHA_EMI.Value,
                                                dtpDOC_FECHA_EMI.Value,
                                                vCUC_ID,
                                                vCCO_ID,
                                                vCCC_ID,
                                                vCCT_ID,
                                                vTDO_ID,
                                                vDTD_ID,
                                                vDOC_SERIE,
                                                vDOC_NUMERO,
                                                vItem,
                                                vMON_ID,
                                                vCCC_ID,
                                                vCCT_ID,
                                                vTDO_ID,
                                                vDTD_ID,
                                                vDOC_SERIE,
                                                vDOC_NUMERO,
                                                vItem,
                                                vMON_ID,
                                                vPER_ID_CLI,
                                                vCargo,
                                                vAbono,
                                                vContraValor,
                                                vMPT_MEDIO_PAGO,
                                                "",
                                                vPER_ID_BAN,
                                                vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_NUMERO
                                                        )
                                vItem = vItem + 1
                            End If

                            SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                            vCCT_ID, _
                            vTDO_ID, _
                            vDTD_ID)

                            '/* Referencias de documentos - nota de crédito, débito */
                            '/* cuando el afectado actua como referencia */
                            '/* DTD_SIGNO_D lado derecho en 1er nivel */
                            '/* Se refleja en el kardex para el documento afectado */
                            If CargoAbono <> "NINGUNO" And _
                               cboDOC_ESTADO.Text = "ACTIVO" And _
                               vTDO_ID_AFE <> "" Then
                                If CargoAbono = "CARGO" Then
                                    If SignoCargoAbono = "+" Then
                                        vCargo = CDbl(.Cells("cDDA_PRE_TOTAL").Value)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vCargo = CDbl(.Cells("cDDA_PRE_TOTAL").Value) * -1
                                    Else
                                        vCargo = 0
                                    End If
                                Else
                                    vCargo = 0
                                End If

                                If CargoAbono = "ABONO" Then
                                    If SignoCargoAbono = "+" Then
                                        vAbono = CDbl(.Cells("cDDA_PRE_TOTAL").Value)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vAbono = CDbl(.Cells("cDDA_PRE_TOTAL").Value) * -1
                                    Else
                                        vAbono = 0
                                    End If
                                Else
                                    vAbono = 0
                                End If

                                vContraValor = 0

                                If vDTD_ID_AFE = "002" Or _
                                   vDTD_ID_AFE = "005" Then
                                    'vAbono = vCargo * -1
                                End If

                                dgvKardexCtaCte.Rows.Add(
                                                dtpDOC_FECHA_EMI.Value,
                                                dtpDOC_FECHA_EMI.Value,
                                                vCUC_ID,
                                                vCCO_ID,
                                                vCCC_ID,
                                                vCCT_ID_AFE,
                                                vTDO_ID_AFE,
                                                vDTD_ID_AFE,
                                                vDOC_SERIE_AFE,
                                                vDOC_NUMERO_AFE,
                                                vItem,
                                                vMON_ID,
                                                vCCC_ID,
                                                vCCT_ID,
                                                vTDO_ID,
                                                vDTD_ID,
                                                vDOC_SERIE,
                                                vDOC_NUMERO,
                                                vItem,
                                                vMON_ID,
                                                vPER_ID_CLI,
                                                vCargo,
                                                vAbono,
                                                vContraValor,
                                                vMPT_MEDIO_PAGO,
                                                "",
                                                vPER_ID_BAN,
                                                vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_NUMERO
                                                        )
                                vItem = vItem + 1
                            End If

                            '/* Referencias de documentos - nota de crédito, débito */
                            '/* Cuando el principal actua como referencia */
                            '/* DTD_SIGNO_D lado derecho en 1er nivel */
                            '/* Se refleja en el kardex para el documento principal */
                            If CargoAbono <> "NINGUNO" And _
                               cboDOC_ESTADO.Text = "ACTIVO" And _
                               vTDO_ID_AFE <> "" Then
                                If CargoAbono = "CARGO" Then
                                    If SignoCargoAbono = "+" Then
                                        vCargo = CDbl(.Cells("cDDA_PRE_TOTAL").Value)
                                    ElseIf SignoCargoAbono = "-" Then
                                        If vCCT_ID & vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_SERIE = vCCT_ID_AFE & vTDO_ID_AFE & vDTD_ID_AFE & vDOC_SERIE_AFE & vDOC_SERIE_AFE Then
                                            vCargo = CDbl(.Cells("cDDA_PRE_TOTAL").Value)
                                        Else
                                            vCargo = CDbl(.Cells("cDDA_PRE_TOTAL").Value) * -1
                                        End If
                                    Else
                                        vCargo = 0
                                    End If
                                Else
                                    vCargo = 0
                                End If

                                If CargoAbono = "ABONO" Then
                                    If SignoCargoAbono = "+" Then
                                        vAbono = CDbl(.Cells("cDDA_PRE_TOTAL").Value)
                                    ElseIf SignoCargoAbono = "-" Then
                                        vAbono = CDbl(.Cells("cDDA_PRE_TOTAL").Value) * -1
                                    Else
                                        vAbono = 0
                                    End If
                                Else
                                    vAbono = 0
                                End If

                                vContraValor = 0

                                dgvKardexCtaCte.Rows.Add(
                                                dtpDOC_FECHA_EMI.Value,
                                                dtpDOC_FECHA_EMI.Value,
                                                vCUC_ID,
                                                vCCO_ID,
                                                vCCC_ID,
                                                vCCT_ID,
                                                vTDO_ID,
                                                vDTD_ID,
                                                vDOC_SERIE,
                                                vDOC_NUMERO,
                                                vItem,
                                                vMON_ID,
                                                vCCC_ID,
                                                vCCT_ID_AFE,
                                                vTDO_ID_AFE,
                                                vDTD_ID_AFE,
                                                vDOC_SERIE_AFE,
                                                vDOC_NUMERO_AFE,
                                                vItem,
                                                vMON_ID,
                                                vPER_ID_CLI,
                                                vCargo,
                                                vAbono,
                                                vContraValor,
                                                vMPT_MEDIO_PAGO,
                                                "",
                                                vPER_ID_BAN,
                                                vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_NUMERO
                                                        )
                                vItem = vItem + 1
                            End If
                        End If
                    End With
                    vFilGrid += 1
                End While
            End If

            If CDbl(txtDOC_MONTO_TOTAL.Text) > vTotalMontoAfecta Then
                vCUC_ID = Nothing
                vCCO_ID = Nothing
                vCCC_ID = Nothing
                vCCT_ID = txtCCT_ID.Text
                vTDO_ID = txtTDO_ID.Text
                vDTD_ID = txtDTD_ID.Text
                vDOC_SERIE = txtDOC_SERIE.Text
                vDOC_NUMERO = txtDOC_NUMERO.Text
                vMON_ID = txtMON_ID.Text
                vPER_ID_CLI = txtPER_ID_CLI.Text
                vPER_ID_BAN = Nothing
                vMPT_MEDIO_PAGO = Nothing

                vCCT_ID_AFE = txtCCT_ID_AFE.Text
                vTDO_ID_AFE = txtTDO_ID_AFE.Text
                vDTD_ID_AFE = txtDTD_ID_AFE.Text
                vDOC_SERIE_AFE = txtDOC_SERIE_AFE.Text
                vDOC_NUMERO_AFE = txtDOC_NUMERO_AFE.Text

                CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                            vCCT_ID, _
                            vTDO_ID, _
                            vDTD_ID)

                SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                            vCCT_ID, _
                            vTDO_ID, _
                            vDTD_ID)

                '/* Referencias de documentos - nota de crédito, débito */
                '/* Cuando el principal actua como referencia */
                '/* DTD_SIGNO_D lado derecho en 1er nivel */
                '/* Se refleja en el kardex para el documento principal */
                If CargoAbono <> "NINGUNO" And _
                   cboDOC_ESTADO.Text = "ACTIVO" And _
                   vTDO_ID_AFE <> "" Then
                    If CargoAbono = "CARGO" Then
                        If SignoCargoAbono = "+" Then
                            'vCargo = CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta
                            vAbono = (CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta) * -1
                        ElseIf SignoCargoAbono = "-" Then
                            If vCCT_ID & vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_NUMERO = vCCT_ID_AFE & vTDO_ID_AFE & vDTD_ID_AFE & vDOC_SERIE_AFE & vDOC_NUMERO_AFE Then
                                ''vCargo = CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta
                                vAbono = (CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta) * -1
                            Else
                                ''vCargo = (CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta) * -1
                                vAbono = (CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta)
                            End If
                        Else
                            ''vCargo = 0
                            vAbono = 0
                        End If
                    Else
                        ''vCargo = 0
                        vAbono = 0
                    End If

                    If CargoAbono = "ABONO" Then
                        If SignoCargoAbono = "+" Then
                            ''vAbono = CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta
                            vCargo = (CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta) * -1
                        ElseIf SignoCargoAbono = "-" Then
                            ''vAbono = (CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta) * -1
                            vCargo = CDbl(txtDOC_MONTO_TOTAL.Text) - vTotalMontoAfecta
                        Else
                            ''vAbono = 0
                            vCargo = 0
                        End If
                    Else
                        ''vAbono = 0
                        vCargo = 0
                    End If

                    vContraValor = 0

                    dgvKardexCtaCte.Rows.Add(
                                    dtpDOC_FECHA_EMI.Value,
                                    dtpDOC_FECHA_EMI.Value,
                                    vCUC_ID,
                                    vCCO_ID,
                                    vCCC_ID,
                                    vCCT_ID,
                                    vTDO_ID,
                                    vDTD_ID,
                                    vDOC_SERIE,
                                    vDOC_NUMERO,
                                    vItem,
                                    vMON_ID,
                                    vCCC_ID,
                                    vCCT_ID_AFE,
                                    vTDO_ID_AFE,
                                    vDTD_ID_AFE,
                                    vDOC_SERIE_AFE,
                                    vDOC_NUMERO_AFE,
                                    vItem,
                                    vMON_ID,
                                    vPER_ID_CLI,
                                    vCargo,
                                    vAbono,
                                    vContraValor,
                                    vMPT_MEDIO_PAGO,
                                    "",
                                    vPER_ID_BAN,
                                    vTDO_ID & vDTD_ID & vDOC_SERIE & vDOC_NUMERO
                                            )
                End If
            End If
        End Sub

        Private Sub ProcesarCtaCteEnDespacho()
            Dim vFilGrid As Integer = 0
            Dim vItem As Integer = 1

            Dim vTDO_ID As String = ""
            Dim vDTD_ID As String = ""
            Dim vCCT_ID As String = ""
            Dim vDDE_SERIE As String = ""
            Dim vDDE_NUMERO As String = ""
            Dim vDDE_ITEM As Int16 = 1
            Dim vTDO_ID_DOC As String = ""
            Dim vDTD_ID_DOC As String = ""
            Dim vDOC_SERIE_DOC As String = ""
            Dim vDOC_NUMERO_DOC As String = ""
            Dim vART_ID_IMP As String = ""
            Dim vART_ID_KAR As String = ""
            Dim vDDE_CANTIDAD As Double = 0

            dgvDetalleDespachos.Rows.Clear()
            If dgvDetalle.Rows.Count() = 0 Then
                Exit Sub
            End If

            If cboDOC_ESTADO.Text <> "ACTIVO" Then
                Exit Sub
            End If

            If dgvDetalleAfectaProducto.Rows.Count > 0 Then
                While (dgvDetalleAfectaProducto.Rows.Count() > vFilGrid)
                    With dgvDetalleAfectaProducto.Rows(vFilGrid)
                        vTDO_ID = BCVariablesNames.ProcesosDespacho.Guia
                        vDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaPorNotaCredito
                        vCCT_ID = Strings.Trim(txtCCT_ID.Text)
                        vDDE_SERIE = txtDOC_SERIE.Text
                        vDDE_NUMERO = txtDOC_NUMERO.Text
                        vDDE_ITEM = vDDE_ITEM + 1
                        vTDO_ID_DOC = .Cells("cTDO_ID_AFP").Value
                        vDTD_ID_DOC = .Cells("cDTD_ID_AFP").Value
                        vDOC_SERIE_DOC = .Cells("cDOC_SERIE_AFP").Value
                        vDOC_NUMERO_DOC = .Cells("cDOC_NUMERO_AFP").Value
                        vART_ID_IMP = .Cells("cART_IDp").Value
                        vART_ID_KAR = .Cells("cART_IDp").Value
                        vDDE_CANTIDAD = .Cells("cDAP_CANTIDAD").Value

                        dgvDetalleDespachos.Rows.Add(
                                            vTDO_ID,
                                            vDTD_ID,
                                            vCCT_ID,
                                            vDDE_SERIE,
                                            vDDE_NUMERO,
                                            vDDE_ITEM,
                                            vTDO_ID_DOC,
                                            vDTD_ID_DOC,
                                            vDOC_SERIE_DOC,
                                            vDOC_NUMERO_DOC,
                                            vART_ID_IMP,
                                            vART_ID_KAR,
                                            vDDE_CANTIDAD
                                                    )
                    End With
                    vFilGrid += 1
                End While
            End If
        End Sub

        Private Function ProcesarDatosDetalle() As Int16
            Dim vFilGrid As Integer = 0
            ProcesarDatosDetalle = 0

            If dgvDetalle.Rows.Count() = 0 Then
                InicializarOrmDetalle()
                MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                Return ProcesarDatosDetalle
            End If

            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    vMensajeErrorOrm = ""
                    InicializarOrmDetalle()

                    ' DetalleDocumento
                    Compuesto1.TDO_ID = txtTDO_ID.Text
                    Compuesto1.DTD_ID = txtDTD_ID.Text
                    Compuesto1.DDO_SERIE = txtDOC_SERIE.Text
                    Compuesto1.DDO_NUMERO = txtDOC_NUMERO.Text
                    Compuesto1.DDO_ITEM = CDbl(.Cells("cITEM").Value)
                    Compuesto1.ART_ID_IMP = .Cells("cART_ID_IMP").Value
                    Compuesto1.ART_ID_KAR = .Cells("cART_ID_KAR").Value
                    Compuesto1.DDO_ART_FACTOR = .Cells("cDDO_ART_FACTOR").Value
                    Compuesto1.DDO_CANTIDAD = CDbl(.Cells("cDDO_CANTIDAD").Value)
                    If .Cells("cDDO_INC_IGV").Value.ToString = "" Then
                        vMensajeErrorOrm = "Comportamiento del IGV no determinado. "
                        ErrorProvider1.SetError(dgvDetalle, vMensajeErrorOrm & "En fila: " & vFilGrid + 1)
                        ProcesarDatosDetalle = -1
                        Exit Function
                    Else
                        Compuesto1.DDO_INC_IGV = DevolverTiposCampos("DDO_INC_IGV", .Cells("cDDO_INC_IGV").Value.ToString, Compuesto1)
                    End If
                    Compuesto1.DDO_DES_INC_PRE = CDbl(.Cells("cDDO_DES_INC_PRE").Value)
                    Compuesto1.DDO_PRE_UNI = CDbl(.Cells("cDDO_PRE_UNI").Value)
                    Compuesto1.DDO_IGV_POR = CDbl(.Cells("cDDO_IGV_POR").Value)
                    Compuesto1.DDO_MONTO_IGV = CDbl(.Cells("cDDO_MONTO_IGV").Value)
                    Compuesto1.DDO_PRE_TOTAL = CDbl(.Cells("cDDO_PRE_TOTAL").Value)
                    Compuesto1.DDO_OBS_DSC_ART = .Cells("cDDO_OBS_DSC_ART").Value
                    If .Cells("cTDO_ID_ANT").Value = "" Then
                        Compuesto1.TDO_ID_ANT = Nothing
                    Else
                        Compuesto1.TDO_ID_ANT = .Cells("cTDO_ID_ANT").Value
                    End If
                    If .Cells("cDTD_ID_ANT").Value = "" Then
                        Compuesto1.DTD_ID_ANT = Nothing
                    Else
                        Compuesto1.DTD_ID_ANT = .Cells("cDTD_ID_ANT").Value
                    End If
                    If .Cells("cCCT_ID_ANT").Value = "" Then
                        Compuesto1.CCT_ID_ANT = Nothing
                    Else
                        Compuesto1.CCT_ID_ANT = .Cells("cCCT_ID_ANT").Value
                    End If
                    If .Cells("cDDO_SERIE_ANT").Value = "" Then
                        Compuesto1.DDO_SERIE_ANT = Nothing
                    Else
                        Compuesto1.DDO_SERIE_ANT = .Cells("cDDO_SERIE_ANT").Value
                    End If
                    Compuesto1.DDO_NUMERO_ANT = .Cells("cDDO_NUMERO_ANT").Value

                    Compuesto1.ART_AFE_PER = DevolverTiposCampos("ART_AFE_PER", .Cells("cART_AFE_PER").Value.ToString, Compuesto1)

                    Compuesto1.USU_ID = SessionService.UserId
                    Compuesto1.DDO_FEC_GRAB = Now
                    Compuesto1.DDO_ESTADO = Compuesto.DOC_ESTADO

                    If vMensajeErrorOrm <> "" Then
                        ErrorProvider1.SetError(dgvDetalle, vMensajeErrorOrm & " En fila: " & vFilGrid + 1)
                        ProcesarDatosDetalle = -1
                        Exit Function
                    End If
                    If Not Validar("Detalle", vFilGrid + 1) Then
                        Compuesto1.vMensajeError += " En fila: " & vFilGrid + 1
                        ProcesarDatosDetalle = -1
                        Exit Function
                    End If
                    If (.Cells("cEstadoRegistro").Value = 1 Or .Cells("cEstadoRegistro").Value = True) Then
                        ProcesarDatosDetalle = IBCDetalle.spActualizarRegistro(Compuesto1.TDO_ID, Compuesto1.DTD_ID, Compuesto1.DDO_SERIE, Compuesto1.DDO_NUMERO, Compuesto1.DDO_ITEM, Compuesto1.ART_ID_IMP, Compuesto1.ART_ID_KAR, Compuesto1.DDO_ART_FACTOR, Compuesto1.DDO_CANTIDAD, Compuesto1.DDO_INC_IGV, Compuesto1.DDO_DES_INC_PRE, Compuesto1.DDO_PRE_UNI, Compuesto1.DDO_IGV_POR, Compuesto1.DDO_MONTO_IGV, Compuesto1.DDO_PRE_TOTAL, Compuesto1.DDO_OBS_DSC_ART, Compuesto1.TDO_ID_ANT, Compuesto1.DTD_ID_ANT, Compuesto1.CCT_ID_ANT, Compuesto1.DDO_SERIE_ANT, Compuesto1.DDO_NUMERO_ANT, Compuesto1.ART_AFE_PER, Compuesto1.USU_ID, Compuesto1.DDO_FEC_GRAB, Compuesto1.DDO_ESTADO)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto1.vMensajeError & " En fila: " & vFilGrid + 1
                            Exit Function
                        End If
                    Else
                        ProcesarDatosDetalle = IBCDetalle.spInsertarRegistro(Compuesto1.TDO_ID, Compuesto1.DTD_ID, Compuesto1.DDO_SERIE, Compuesto1.DDO_NUMERO, Compuesto1.DDO_ITEM, Compuesto1.ART_ID_IMP, Compuesto1.ART_ID_KAR, Compuesto1.DDO_ART_FACTOR, Compuesto1.DDO_CANTIDAD, Compuesto1.DDO_INC_IGV, Compuesto1.DDO_DES_INC_PRE, Compuesto1.DDO_PRE_UNI, Compuesto1.DDO_IGV_POR, Compuesto1.DDO_MONTO_IGV, Compuesto1.DDO_PRE_TOTAL, Compuesto1.DDO_OBS_DSC_ART, Compuesto1.TDO_ID_ANT, Compuesto1.DTD_ID_ANT, Compuesto1.CCT_ID_ANT, Compuesto1.DDO_SERIE_ANT, Compuesto1.DDO_NUMERO_ANT, Compuesto1.ART_AFE_PER, Compuesto1.USU_ID, Compuesto1.DDO_FEC_GRAB, Compuesto1.DDO_ESTADO)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto1.vMensajeError & " En fila: " & vFilGrid + 1
                            Exit Function
                        End If
                    End If
                End With
                vFilGrid += 1
            End While

            vFilGrid = 0
            If dgvKardexCtaCte.Rows.Count() = 0 Then
                InicializarOrmKardexCtaCte()
                ProcesarDatosDetalle = 1
            Else
                While (dgvKardexCtaCte.Rows.Count() > vFilGrid)
                    With dgvKardexCtaCte.Rows(vFilGrid)
                        vMensajeErrorOrm = ""
                        InicializarOrmKardexCtaCte()

                        ' Inicio KardexCtaCte
                        Compuesto6.DOC_FECHA_EMI_REF = .Cells("cDOC_FECHA_EMI_REF3").Value
                        Compuesto6.DOC_FECHA_VEN_REF = .Cells("cDOC_FECHA_VEN_REF3").Value
                        Compuesto6.CUC_ID_REF = .Cells("cCUC_ID_REF3").Value
                        Compuesto6.CCO_ID_REF = .Cells("cCCO_ID_REF3").Value
                        Compuesto6.CCC_ID_REF = .Cells("cCCC_ID_REF3").Value
                        Compuesto6.CCT_ID_REF = .Cells("cCCT_ID_REF3").Value
                        Compuesto6.TDO_ID_REF = .Cells("cTDO_ID_REF3").Value
                        Compuesto6.DTD_ID_REF = .Cells("cDTD_ID_REF3").Value
                        Compuesto6.DOC_SERIE_REF = .Cells("cDOC_SERIE_REF3").Value
                        Compuesto6.DOC_NUMERO_REF = .Cells("cDOC_NUMERO_REF3").Value
                        Compuesto6.ITEM_REF = .Cells("cITEM_REF3").Value
                        Compuesto6.MON_ID_CCC = .Cells("cMON_ID_CCC3").Value
                        Compuesto6.CCC_ID = .Cells("cCCC_ID3").Value
                        Compuesto6.CCT_ID = .Cells("cCCT_ID3").Value
                        Compuesto6.TDO_ID = .Cells("cTDO_ID3").Value
                        Compuesto6.DTD_ID = .Cells("cDTD_ID3").Value
                        Compuesto6.DOC_SERIE = .Cells("cDOC_SERIE3").Value
                        Compuesto6.DOC_NUMERO = .Cells("cDOC_NUMERO3").Value
                        Compuesto6.ITEM = CInt(.Cells("cITEM3").Value)
                        Compuesto6.MON_ID = .Cells("cMON_ID3").Value
                        Compuesto6.PER_ID_CLI = .Cells("cPER_ID_CLI3").Value
                        Compuesto6.CARGO = CDbl(.Cells("cCARGO3").Value)
                        Compuesto6.ABONO = CDbl(.Cells("cABONO3").Value)
                        Compuesto6.DTE_CONTRAVALOR_DOC = CDbl(.Cells("cDTE_CONTRAVALOR_DOC3").Value)
                        Compuesto6.MPT_MEDIO_PAGO = CInt(.Cells("cMPT_MEDIO_PAGO3").Value)
                        Compuesto6.MPT_NUMERO_MEDIO = .Cells("cMPT_NUMERO_MEDIO3").Value
                        Compuesto6.PER_ID_BAN = .Cells("cPER_ID_BAN3").Value
                        Compuesto6.DOCUMENTO = .Cells("cDOCUMENTO3").Value

                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgvDetalle, vMensajeErrorOrm)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        'If Not Validar("DetalleMovimientoCajBanco", vFilGrid + 1) Then
                        '    'Compuesto4.vMensajeError += " En fila: " & vFilGrid + 1
                        '    ProcesarDatosDetalle = -1
                        '    Exit Function
                        'End If

                        ProcesarDatosDetalle = IBCKardexCtaCte.spInsertarRegistro(Compuesto6.DOC_FECHA_EMI_REF, Compuesto6.DOC_FECHA_VEN_REF, Compuesto6.CUC_ID_REF, Compuesto6.CCO_ID_REF, Compuesto6.CCC_ID_REF, Compuesto6.CCT_ID_REF, Compuesto6.TDO_ID_REF, Compuesto6.DTD_ID_REF, Compuesto6.DOC_SERIE_REF, Compuesto6.DOC_NUMERO_REF, Compuesto6.ITEM_REF, Compuesto6.MON_ID_CCC, Compuesto6.CCC_ID, Compuesto6.CCT_ID, Compuesto6.TDO_ID, Compuesto6.DTD_ID, Compuesto6.DOC_SERIE, Compuesto6.DOC_NUMERO, Compuesto6.ITEM, Compuesto6.MON_ID, Compuesto6.PER_ID_CLI, Compuesto6.CARGO, Compuesto6.ABONO, Compuesto6.DTE_CONTRAVALOR_DOC, Compuesto6.MPT_MEDIO_PAGO, Compuesto6.MPT_NUMERO_MEDIO, Compuesto6.PER_ID_BAN, Compuesto6.DOCUMENTO)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto6.vMensajeError '& " En fila: " & vFilGrid + 1
                            Exit Function
                        End If

                        ' Fin KardexCtaCte
                    End With
                    vFilGrid += 1
                End While
            End If

            '''

            vFilGrid = 0
            If dgvDetalleDespachos.Rows.Count() = 0 Then
                ProcesarDatosDetalle = 1
            Else
                While (dgvDetalleDespachos.Rows.Count() > vFilGrid)
                    With dgvDetalleDespachos.Rows(vFilGrid)
                        vMensajeErrorOrm = ""
                        If vFilGrid = 0 Then
                            ' Inicio Despachos (Nota de crédito afecta a producto)
                            Compuesto9.TDO_ID = BCVariablesNames.ProcesosDespacho.Guia
                            Compuesto9.DTD_ID = BCVariablesNames.ProcesosDespacho.GuiaPorNotaCredito
                            Compuesto9.CCT_ID = Strings.Trim(txtCCT_ID.Text)
                            Compuesto9.DES_FEC_EMI = dtpDOC_FECHA_EMI.Value
                            Compuesto9.DES_FEC_TRA = dtpDOC_FECHA_EMI.Value
                            Compuesto9.PVE_ID = Strings.Trim(txtPVE_ID.Text)
                            Compuesto9.ALM_ID = BCVariablesNames.CodigoAlmacenPrincipal
                            Compuesto9.ALM_ID_LLEGADA = Nothing
                            Compuesto9.DES_SERIE = Strings.Trim(txtDOC_SERIE.Text)
                            Compuesto9.DES_NUMERO = Strings.Trim(txtDOC_NUMERO.Text)

                            Compuesto9.TDO_ID_DOC = Strings.Trim(.Cells("cTDO_ID_DOCx").Value)
                            Compuesto9.DTD_ID_DOC = Strings.Trim(.Cells("cDTD_ID_DOCx").Value)
                            Compuesto9.DES_SERIE_DOC = Strings.Trim(.Cells("cDOC_SERIE_DOCx").Value)
                            Compuesto9.DES_NUMERO_DOC = Strings.Trim(.Cells("cDOC_NUMERO_DOCx").Value)

                            Compuesto9.PER_ID_REC = Nothing
                            Compuesto9.TDP_ID_REC = Nothing
                            Compuesto9.DIR_ID_ENT_REC = Nothing
                            Compuesto9.DIR_ID_ENT = Nothing
                            Select Case Me.SessionService.NombreEmpresa
                                Case "Ladrillera El Diamante SAC"
                                    Compuesto9.PLA_ID = BCVariablesNames.PlacaElMismoLadrillera
                                Case "Comercializadora Diamante G.E. SAC"
                                    Compuesto9.PLA_ID = BCVariablesNames.PlacaElMismoComercializadora
                            End Select
                            Compuesto9.FLE_ID = Nothing
                            Compuesto9.MON_ID = Nothing
                            Compuesto9.DES_MONTO_FLETE = 0
                            Compuesto9.DES_CONTRAVALOR = 0
                            Compuesto9.DES_OBSERVACIONES = Nothing

                            Compuesto9.USU_ID = SessionService.UserId
                            Compuesto9.DES_FEC_GRAB = Now
                            Compuesto9.DES_TIPO_GUIA = DevolverTiposCampos("DES_TIPO_GUIA", "OTROS", Compuesto9)
                            Compuesto9.DES_ESTADO = DevolverTiposCampos("DES_ESTADO", cboDOC_ESTADO.Text, Compuesto9)

                            If vMensajeErrorOrm <> "" Then
                                ErrorProvider1.SetError(dgvDetalleDespachos, vMensajeErrorOrm)
                                ProcesarDatosDetalle = -1
                                Exit Function
                            End If

                            ProcesarDatosDetalle = IBCDespachos.spInsertarRegistro(Compuesto9)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Compuesto9.vMensajeError '& " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                            ' Fin Despachos
                        End If

                        ' Inicio DetalleDespachos (Nota de crédito afecta a producto)
                        Compuesto10.TDO_ID = Strings.Trim(.Cells("cTDO_IDx").Value)
                        Compuesto10.DTD_ID = Strings.Trim(.Cells("cDTD_IDx").Value)
                        Compuesto10.DDE_SERIE = Strings.Trim(.Cells("cDDE_SERIEx").Value)
                        Compuesto10.DDE_NUMERO = Strings.Trim(.Cells("cDDE_NUMEROx").Value)

                        Compuesto10.DDE_ITEM = Strings.Trim(.Cells("cDDE_ITEMx").Value)
                        Compuesto10.ART_ID_IMP = Strings.Trim(.Cells("cART_ID_IMPx").Value)
                        Compuesto10.ART_ID_KAR = Strings.Trim(.Cells("cART_ID_KARx").Value)
                        Compuesto10.DDE_CANTIDAD = .Cells("cDDE_CANTIDADx").Value
                        
                        Compuesto10.USU_ID = SessionService.UserId
                        Compuesto10.DDE_FEC_GRAB = Now
                        Compuesto10.DDE_ESTADO = DevolverTiposCampos("DDE_ESTADO", cboDOC_ESTADO.Text, Compuesto10)

                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgvDetalleDespachos, vMensajeErrorOrm)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If

                        ProcesarDatosDetalle = IBCDetalleDespachos.spinsertarRegistro(Compuesto10)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto10.vMensajeError '& " En fila: " & vFilGrid + 1
                            Exit Function
                        End If
                        ' Fin DetalleDespachos
                    End With
                    vFilGrid += 1
                End While
            End If

            '''


            vFilGrid = 0
            If dgvDetalleAfectaMonto.Rows.Count() = 0 Then
                ProcesarDatosDetalle = 1
            Else
                While (dgvDetalleAfectaMonto.Rows.Count() > vFilGrid)
                    With dgvDetalleAfectaMonto.Rows(vFilGrid)
                        vMensajeErrorOrm = ""

                        ' Inicio DetalleAfectaDocumentos
                        Compuesto7.TDO_ID = txtTDO_ID.Text
                        Compuesto7.DTD_ID = txtDTD_ID.Text
                        Compuesto7.DDA_SERIE = txtDOC_SERIE.Text
                        Compuesto7.DDA_NUMERO = txtDOC_NUMERO.Text
                        Compuesto7.DDA_ITEM = CDbl(.Cells("cITEMa").Value)
                        Compuesto7.TDO_ID_AFE = .Cells("cTDO_ID_AFE").Value
                        Compuesto7.DTD_ID_AFE = .Cells("cDTD_ID_AFE").Value
                        Compuesto7.CCT_ID_AFE = .Cells("cCCT_ID_AFE").Value
                        Compuesto7.DOC_SERIE_AFE = .Cells("cDOC_SERIE_AFE").Value
                        Compuesto7.DOC_NUMERO_AFE = .Cells("cDOC_NUMERO_AFE").Value
                        Compuesto7.DDA_PRE_TOTAL = CDbl(.Cells("cDDA_PRE_TOTAL").Value)
                        Compuesto7.DDA_OBS = .Cells("cDDA_OBS").Value
                        Compuesto7.USU_ID = SessionService.UserId
                        Compuesto7.DDA_FEC_GRAB = Now
                        Compuesto7.DDA_ESTADO = Compuesto.DOC_ESTADO


                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgvDetalleAfectaMonto, vMensajeErrorOrm)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        'If Not Validar("DetalleMovimientoCajBanco", vFilGrid + 1) Then
                        '    'Compuesto7.vMensajeError += " En fila: " & vFilGrid + 1
                        '    ProcesarDatosDetalle = -1
                        '    Exit Function
                        'End If

                        ProcesarDatosDetalle = IBCDetalleAfectaDocumentos.spInsertarRegistro(Compuesto7)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto7.vMensajeError '& " En fila: " & vFilGrid + 1
                            Exit Function
                        End If

                        ' Fin DetalleAfectaDocumentos
                    End With
                    vFilGrid += 1
                End While
            End If


            '''
            vFilGrid = 0
            If dgvDetalleAfectaProducto.Rows.Count() = 0 Then
                ProcesarDatosDetalle = 1
            Else
                While (dgvDetalleAfectaProducto.Rows.Count() > vFilGrid)
                    With dgvDetalleAfectaProducto.Rows(vFilGrid)
                        vMensajeErrorOrm = ""

                        ' Inicio DetalleAfectaProductoDocumentos
                        Compuesto8.TDO_ID = txtTDO_ID.Text
                        Compuesto8.DTD_ID = txtDTD_ID.Text
                        Compuesto8.DAP_SERIE = txtDOC_SERIE.Text
                        Compuesto8.DAP_NUMERO = txtDOC_NUMERO.Text
                        Compuesto8.DAP_ITEM = CDbl(.Cells("cITEMp").Value)
                        Compuesto8.TDO_ID_AFP = .Cells("cTDO_ID_AFP").Value
                        Compuesto8.DTD_ID_AFP = .Cells("cDTD_ID_AFP").Value
                        Compuesto8.CCT_ID_AFP = .Cells("cCCT_ID_AFP").Value
                        Compuesto8.DOC_SERIE_AFP = .Cells("cDOC_SERIE_AFP").Value
                        Compuesto8.DOC_NUMERO_AFP = .Cells("cDOC_NUMERO_AFP").Value
                        Compuesto8.ART_ID = .Cells("cART_IDp").Value
                        Compuesto8.DAP_CANTIDAD = CDbl(.Cells("cDAP_CANTIDAD").Value)
                        Compuesto8.DAP_OBS = .Cells("cDAP_OBS").Value

                        Compuesto8.TDO_ID_DEV = .Cells("cTDO_ID_DEV").Value
                        Compuesto8.DTD_ID_DEV = .Cells("cDTD_ID_DEV").Value
                        Compuesto8.CCT_ID_DEV = .Cells("cCCT_ID_DEV").Value
                        Compuesto8.DES_SERIE_DEV = .Cells("cDES_SERIE_DEV").Value
                        Compuesto8.DES_NUMERO_DEV = .Cells("cDES_NUMERO_DEV").Value
                        Compuesto8.ART_ID_DEV = .Cells("cART_ID_DEVp").Value
                        Compuesto8.DDE_CANTIDAD_DEV = CDbl(.Cells("cDDE_CANTIDAD_DEV").Value)

                        Compuesto8.USU_ID = SessionService.UserId
                        Compuesto8.DAP_FEC_GRAB = Now
                        Compuesto8.DAP_ESTADO = Compuesto.DOC_ESTADO

                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgvDetalleAfectaProducto, vMensajeErrorOrm)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If Not Validar("DetalleMovimientoCajBanco", vFilGrid + 1) Then
                            'Compuesto7.vMensajeError += " En fila: " & vFilGrid + 1
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If

                        ProcesarDatosDetalle = IBCDetalleAfectaProductoDocumentos.spInsertarRegistro(Compuesto8)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto8.vMensajeError '& " En fila: " & vFilGrid + 1
                            Exit Function
                        End If

                        ' Fin DetalleAfectaProductoDocumentos
                    End With
                    vFilGrid += 1
                End While
            End If
            '''

            Return ProcesarDatosDetalle
        End Function
        Private Function EliminarKardexCtaCte(ByVal vItem As Integer)
            EliminarKardexCtaCte = 0
            If vItem < 1 Then
                EliminarKardexCtaCte = 1
            Else
                For fila = 1 To vItem
                    vMensajeErrorOrm = ""
                    InicializarOrmKardexCtaCte()
                    'EliminarKardexCtaCte = Me.IBCKardexCtaCte.DeleteRegistro(Compuesto6, Compuesto.TDO_ID & Compuesto.DTD_ID & Compuesto.DOC_SERIE & Compuesto.DOC_NUMERO, fila)
                    EliminarKardexCtaCte = Me.IBCKardexCtaCte.spEliminarRegistro(fila, Compuesto.TDO_ID & Compuesto.DTD_ID & Compuesto.DOC_SERIE & Compuesto.DOC_NUMERO)
                    If EliminarKardexCtaCte = 0 Then
                        vMensajeErrorOrm = Compuesto6.vMensajeError
                        Exit For
                    End If

                    Dim vDTD_ID As String = ""
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosFacturación.VentaBoleta
                            vDTD_ID = BCVariablesNames.ProcesosFacturación.BoletaPercepcion
                        Case BCVariablesNames.ProcesosFacturación.VentaFactura
                            vDTD_ID = BCVariablesNames.ProcesosFacturación.FacturaPercepcion
                    End Select

                    EliminarKardexCtaCte = Me.IBCKardexCtaCte.spEliminarRegistro(fila, Compuesto.TDO_ID & vDTD_ID & Compuesto.DOC_SERIE & Compuesto.DOC_NUMERO)
                    If EliminarKardexCtaCte = 0 Then
                        vMensajeErrorOrm = Compuesto6.vMensajeError
                        Exit For
                    End If


                Next
            End If
            Return EliminarKardexCtaCte
        End Function
        Private Function EliminarKardexCtaCtePercepcion(ByVal vItem As Integer)
            Dim VDocumentoPercepcion As String
            EliminarKardexCtaCtePercepcion = 0
            If vItem < 1 Then
                EliminarKardexCtaCtePercepcion = 1
            Else
                For fila = 1 To vItem
                    vMensajeErrorOrm = ""
                    InicializarOrmKardexCtaCte()

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosFacturación.VentaBoleta
                            vDocumentoPercepcion = BCVariablesNames.ProcesosFacturación.BoletaPercepcion
                        Case BCVariablesNames.ProcesosFacturación.VentaFactura
                            vDocumentoPercepcion = BCVariablesNames.ProcesosFacturación.FacturaPercepcion
                    End Select

                    EliminarKardexCtaCtePercepcion = Me.IBCKardexCtaCte.spEliminarRegistro(fila, Compuesto.TDO_ID & VDocumentoPercepcion & Compuesto.DOC_SERIE & Compuesto.DOC_NUMERO)
                    If EliminarKardexCtaCtePercepcion = 0 Then
                        vMensajeErrorOrm = Compuesto6.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarKardexCtaCtePercepcion
        End Function
        Private Function EliminarDetalleDespachos(ByVal vItem As Integer)
            EliminarDetalleDespachos = 0
            If vItem < 1 Then
                EliminarDetalleDespachos = 1
            Else
                For fila = 1 To vItem
                    vMensajeErrorOrm = ""
                    Compuesto10.TDO_ID = BCVariablesNames.ProcesosDespacho.Guia
                    Compuesto10.DTD_ID = BCVariablesNames.ProcesosDespacho.GuiaPorNotaCredito
                    Compuesto10.DDE_SERIE = Compuesto.DOC_SERIE
                    Compuesto10.DDE_NUMERO = Compuesto.DOC_NUMERO
                    Compuesto10.DDE_ITEM = fila
                    EliminarDetalleDespachos = Me.IBCDetalleDespachos.spEliminarRegistro(Compuesto10)
                    If EliminarDetalleDespachos = 0 Then
                        vMensajeErrorOrm = Compuesto10.vMensajeError
                        Exit For
                    End If
                Next
            End If
            If EliminarDetalleDespachos = 1 Then
                vMensajeErrorOrm = ""
                Compuesto9.TDO_ID = BCVariablesNames.ProcesosDespacho.Guia
                Compuesto9.DTD_ID = BCVariablesNames.ProcesosDespacho.GuiaPorNotaCredito
                Compuesto9.DES_SERIE = Compuesto.DOC_SERIE
                Compuesto9.DES_NUMERO = Compuesto.DOC_NUMERO
                EliminarDetalleDespachos = Me.IBCDespachos.spEliminarRegistro(Compuesto9)
                If EliminarDetalleDespachos = 0 Then
                    vMensajeErrorOrm = Compuesto9.vMensajeError
                End If
            End If
            Return EliminarDetalleDespachos
        End Function
        Private Function EliminarDetalleAfectaMonto(ByVal vItem As Integer)
            EliminarDetalleAfectaMonto = 0
            If vItem < 1 Then
                EliminarDetalleAfectaMonto = 1
            Else
                For fila = 1 To vItem
                    vMensajeErrorOrm = ""
                    EliminarDetalleAfectaMonto = Me.IBCDetalleAfectaDocumentos.spEliminarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.DOC_SERIE, Compuesto.DOC_NUMERO, fila)
                    If EliminarDetalleAfectaMonto = 0 Then
                        vMensajeErrorOrm = Compuesto7.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarDetalleAfectaMonto
        End Function
        Private Function EliminarDetalleAfectaProducto(ByVal vItem As Integer)
            EliminarDetalleAfectaProducto = 0
            If vItem < 1 Then
                EliminarDetalleAfectaProducto = 1
            Else
                For fila = 1 To vItem
                    vMensajeErrorOrm = ""
                    EliminarDetalleAfectaProducto = Me.IBCDetalleAfectaProductoDocumentos.spEliminarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.DOC_SERIE, Compuesto.DOC_NUMERO, fila)
                    If EliminarDetalleAfectaProducto = 0 Then
                        vMensajeErrorOrm = Compuesto8.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarDetalleAfectaProducto
        End Function
        Private Function EliminarRegistroDetalle() As Int16
            EliminarRegistroDetalle = 0
            If eRegistrosEliminar.Count = 2 Then
                EliminarRegistroDetalle = 1
            Else
                If eRegistrosEliminar.Count - 2 < 1 Then
                    EliminarRegistroDetalle = 1
                    Exit Function
                End If
                For fila = 1 To eRegistrosEliminar.Count - 2
                    vMensajeErrorOrm = ""
                    InicializarOrmDetalle()

                    EliminarRegistroDetalle = Me.IBCDetalle.spEliminarRegistro(eRegistrosEliminar(fila).cTDO_ID, eRegistrosEliminar(fila).cDTD_ID, eRegistrosEliminar(fila).cDDO_SERIE, eRegistrosEliminar(fila).cDDO_NUMERO, eRegistrosEliminar(fila).cDDO_ITEM)
                    If EliminarRegistroDetalle = 0 Then
                        vMensajeErrorOrm = Compuesto1.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarRegistroDetalle
        End Function

        Private Sub DatosCabecera()
            If cboDOC_TIPO_ORDEN_COMPRA.Text = "NINGUNO" Then
                If IBCBusqueda.ObligadoOrdenCompra(txtPER_ID_CLI.Text) Then cboDOC_TIPO_ORDEN_COMPRA.Text = "DESPACHO CLIENTE"
            End If

            Compuesto.TDO_ID = Strings.Trim(txtTDO_ID.Text)
            Compuesto.DTD_ID = Strings.Trim(txtDTD_ID.Text)

            If Strings.Trim(txtCCT_ID.Text) = "" Then
                Compuesto.CCT_ID = Nothing
            Else
                Compuesto.CCT_ID = Strings.Trim(txtCCT_ID.Text)
            End If

            Compuesto.DOC_SERIE = Strings.Trim(txtDOC_SERIE.Text)
            Compuesto.DOC_NUMERO = Strings.Trim(txtDOC_NUMERO.Text)

            Compuesto.DOC_ORDEN_COMPRA = Strings.Trim(txtDOC_ORDEN_COMPRA.Text)
            Compuesto.DOC_TIPO_ORDEN_COMPRA = DevolverTiposCampos("DOC_TIPO_ORDEN_COMPRA", cboDOC_TIPO_ORDEN_COMPRA.Text, Compuesto)

            Compuesto.DOC_OBSERVACIONES = Strings.Trim(txtDOC_OBSERVACIONES.Text)

            Compuesto.DOC_ATENCION = Strings.Trim(txtDOC_ATENCION.Text)

            If Strings.Trim(txtPER_ID_REC.Text) = "" Then
                Compuesto.PER_ID_REC = Nothing
            Else
                Compuesto.PER_ID_REC = Strings.Trim(txtPER_ID_REC.Text)
            End If
            If Strings.Trim(txtTDP_ID_REC.Text) = "" Then
                Compuesto.TDP_ID_REC = Nothing
            Else
                Compuesto.TDP_ID_REC = Strings.Trim(txtTDP_ID_REC.Text)
            End If
            If Strings.Trim(txtDIR_ID_ENT_REC.Text) = "" Then
                Compuesto.DIR_ID_ENT_REC = Nothing
            Else
                Compuesto.DIR_ID_ENT_REC = Strings.Trim(txtDIR_ID_ENT_REC.Text)
            End If
            Compuesto.PVE_ID = Strings.Trim(txtPVE_ID.Text)
            If Strings.Trim(txtPVE_ID_DES.Text) = "" Then
                Compuesto.PVE_ID_DES = Nothing
            Else
                Compuesto.PVE_ID_DES = Strings.Trim(txtPVE_ID_DES.Text)
            End If
            Compuesto.MON_ID = Strings.Trim(txtMON_ID.Text)
            Compuesto.TIV_ID = Strings.Trim(txtTIV_ID.Text)
            Compuesto.PER_ID_CLI = Strings.Trim(txtPER_ID_CLI.Text)
            Compuesto.TDP_ID_CLI = Strings.Trim(txtTDP_ID_CLI.Text)
            If Strings.Trim(txtPER_ID_CON.Text) = "" Then
                Compuesto.PER_ID_CON = Nothing
            Else
                Compuesto.PER_ID_CON = Strings.Trim(txtPER_ID_CON.Text)
            End If
            VerificarAsignacionFechasDocumento()

            If Strings.Trim(txtDIR_ID_FIS.Text) = "" Then
                Compuesto.DIR_ID_FIS = Nothing
            Else
                Compuesto.DIR_ID_FIS = Strings.Trim(txtDIR_ID_FIS.Text)
            End If
            If Strings.Trim(txtDIR_ID_DOM.Text) = "" Then
                Compuesto.DIR_ID_DOM = Nothing
            Else
                Compuesto.DIR_ID_DOM = Strings.Trim(txtDIR_ID_DOM.Text)
            End If
            If Strings.Trim(txtDIR_ID_ENT.Text) = "" Then
                Compuesto.DIR_ID_ENT = Nothing
            Else
                Compuesto.DIR_ID_ENT = Strings.Trim(txtDIR_ID_ENT.Text)
            End If
            If Strings.Trim(txtDIR_ID_COB.Text) = "" Then
                Compuesto.DIR_ID_COB = Nothing
            Else
                Compuesto.DIR_ID_COB = Strings.Trim(txtDIR_ID_COB.Text)
            End If
            Compuesto.PER_ID_VEN = Strings.Trim(txtPER_ID_VEN.Text)
            If Strings.Trim(txtPER_ID_COB.Text) = "" Then
                Compuesto.PER_ID_COB = Nothing
            Else
                Compuesto.PER_ID_COB = Strings.Trim(txtPER_ID_COB.Text)
            End If
            If Strings.Trim(txtPER_ID_PRO.Text) = "" Then
                Compuesto.PER_ID_PRO = Nothing
            Else
                Compuesto.PER_ID_PRO = Strings.Trim(txtPER_ID_PRO.Text)
            End If
            If Strings.Trim(txtPER_ID_GRU.Text) = "" Then
                Compuesto.PER_ID_GRU = Nothing
            Else
                Compuesto.PER_ID_GRU = Strings.Trim(txtPER_ID_GRU.Text)
            End If
            Compuesto.DOC_TIPO_LISTA = DevolverTiposCampos("DOC_TIPO_LISTA", cboDOC_TIPO_LISTA.Text, Compuesto)
            Compuesto.DOC_MONTO_TOTAL = CDbl(txtDOC_MONTO_TOTAL.Text)
            Compuesto.DOC_CONTRAVALOR = CDbl(txtDOC_MONTO_TOTAL.Text) * TipoCambioCompraMoneda
            Compuesto.DOC_IGV_POR = CDbl(txtDOC_IGV_POR.Text)
            Compuesto.DOC_ASIENTO = DevolverTiposCampos(chkDOC_ASIENTO)
            Compuesto.DOC_CIERRE = DevolverTiposCampos("DOC_CIERRE", cboDOC_CIERRE.Text, Compuesto)
            If Strings.Trim(txtFLE_ID.Text) = "" Then
                Compuesto.FLE_ID = Nothing
            Else
                Compuesto.FLE_ID = Strings.Trim(txtFLE_ID.Text)
            End If
            If Not IsNumeric(txtDOC_MONTO_FLE.Text) Then
                Compuesto.DOC_MONTO_FLE = CDbl(0)
            Else
                Compuesto.DOC_MONTO_FLE = CDbl(txtDOC_MONTO_FLE.Text)
            End If

            Compuesto.DOC_REQUIERE_GUIA = DevolverTiposCampos(chkDOC_REQUIERE_GUIA)

            If Strings.Trim(txtTDO_ID_AFE.Text) = "" Then
                Compuesto.TDO_ID_AFE = Nothing
            Else
                Compuesto.TDO_ID_AFE = Strings.Trim(txtTDO_ID_AFE.Text)
            End If
            If Strings.Trim(txtDTD_ID_AFE.Text) = "" Then
                Compuesto.DTD_ID_AFE = Nothing
            Else
                Compuesto.DTD_ID_AFE = Strings.Trim(txtDTD_ID_AFE.Text)
            End If
            If Strings.Trim(txtCCT_ID_AFE.Text) = "" Then
                Compuesto.CCT_ID_AFE = Nothing
            Else
                Compuesto.CCT_ID_AFE = Strings.Trim(txtCCT_ID_AFE.Text)
            End If
            If Strings.Trim(txtDOC_SERIE_AFE.Text) = "" Then
                Compuesto.DOC_SERIE_AFE = Nothing
            Else
                Compuesto.DOC_SERIE_AFE = Strings.Trim(txtDOC_SERIE_AFE.Text)
            End If
            Compuesto.DOC_NUMERO_AFE = Strings.Trim(txtDOC_NUMERO_AFE.Text)
            Compuesto.DOC_MOT_EMI = DevolverTiposCampos("DOC_MOT_EMI", cboDOC_MOT_EMI.Text, Compuesto)
            Compuesto.DOC_NOMBRE_RECEP = Strings.Trim(txtDOC_NOMBRE_RECEP.Text)
            If Strings.Trim(txtDOC_DNI_RECEP.Text) = "" Then
                Compuesto.DOC_DNI_RECEP = Nothing
            Else
                Compuesto.DOC_DNI_RECEP = Strings.Trim(txtDOC_DNI_RECEP.Text)
            End If
            Compuesto.DOC_FEC_RECEP = dtpDOC_FEC_RECEP.Value
            Compuesto.DOC_ENTREGADO = DevolverTiposCampos(chkDOC_ENTREGADO)
            If txtCAF_IX_NUMERO_PRO.Text.Trim = "" Then
                Compuesto.CAF_IX_NUMERO_PRO = Nothing
            Else
                Compuesto.CAF_IX_NUMERO_PRO = Strings.Trim(txtCAF_IX_NUMERO_PRO.Text)
            End If

            If txtCAF_IX_ORDEN_COM.Text.Trim = "" Then
                Compuesto.CAF_IX_ORDEN_COM = Nothing
            Else
                Compuesto.CAF_IX_ORDEN_COM = Strings.Trim(txtCAF_IX_ORDEN_COM.Text)
            End If

            If Not IsNumeric(txtDOC_MONTO_PERCEPCION.Text) Then
                Compuesto.DOC_MONTO_PERCEPCION = CDbl(0)
            Else
                Compuesto.DOC_MONTO_PERCEPCION = CDbl(txtDOC_MONTO_PERCEPCION.Text)
            End If

            Compuesto.LPR_ID = Strings.Trim(txtLPR_ID.Text)
            Compuesto.USU_ID = SessionService.UserId
            Compuesto.DOC_FEC_GRAB = Now
            Compuesto.DOC_ESTADO = DevolverTiposCampos("DOC_ESTADO", cboDOC_ESTADO.Text, Compuesto)

            Compuesto.TDO_ID_GEN = Strings.Trim(txtTDO_ID_GEN.Text) '' vCodigoProformaTDO_ID
            Compuesto.DTD_ID_GEN = Strings.Trim(txtDTD_ID_GEN.Text) '' vCodigoProformaDTD_ID
            If Strings.Trim(txtCCT_ID_GEN.Text) = "" Then
                Compuesto.CCT_ID_GEN = Nothing
            Else
                Compuesto.CCT_ID_GEN = Strings.Trim(txtCCT_ID_GEN.Text)
            End If
            Compuesto.DOC_SERIE_GEN = Strings.Trim(txtDOC_SERIE_GEN.Text) '' vCodigoProformaDOC_SERIE
            Compuesto.DOC_NUMERO_GEN = Strings.Trim(txtDOC_NUMERO_GEN.Text) '' vCodigoProformaDOC_NUMERO

            dtpDOC_HORA_INICIO.Value = dtpDOC_FECHA_ENT.Value + dtpDOC_HORA_INICIO.Value.TimeOfDay
            dtpDOC_HORA_FIN.Value = dtpDOC_FECHA_ENT.Value + dtpDOC_HORA_FIN.Value.TimeOfDay

            Compuesto.DOC_HORA_INICIO = dtpDOC_HORA_INICIO.Value
            Compuesto.DOC_HORA_FIN = dtpDOC_HORA_FIN.Value

            DatosCabeceraPercepcion()

            Compuesto2.TDO_ID = txtTDO_ID.Text
            Compuesto2.PVE_ID = txtPVE_ID.Text
            Compuesto2.CTD_COR_SERIE = txtDOC_SERIE.Text
            Compuesto2.CTD_COR_NUMERO = Val(txtDOC_NUMERO.Text) + 1
            Compuesto2.USU_ID = SessionService.UserId
            Compuesto2.CTD_FEC_GRAB = Now
            Compuesto2.CTD_ESTADO = 1
        End Sub
        Private Sub DatosCabeceraPercepcion()
            Dim vDTD_ID_PERCEPCION As String = ""
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.VentaBoleta
                    vDTD_ID_PERCEPCION = BCVariablesNames.ProcesosFacturación.BoletaPercepcion
                Case BCVariablesNames.ProcesosFacturación.VentaFactura
                    vDTD_ID_PERCEPCION = BCVariablesNames.ProcesosFacturación.FacturaPercepcion
            End Select
            Compuesto00.TDO_ID = Strings.Trim(txtTDO_ID.Text)
            Compuesto00.DTD_ID = Strings.Trim(vDTD_ID_PERCEPCION)
            If Strings.Trim(txtCCT_ID.Text) = "" Then
                Compuesto00.CCT_ID = Nothing
            Else
                Compuesto00.CCT_ID = Strings.Trim(txtCCT_ID.Text)
            End If
            Compuesto00.DOC_SERIE = Strings.Trim(txtDOC_SERIE.Text)
            Compuesto00.DOC_NUMERO = Strings.Trim(txtDOC_NUMERO.Text)
            Compuesto00.DOC_ORDEN_COMPRA = Strings.Trim(txtDOC_ORDEN_COMPRA.Text)
            Compuesto00.DOC_TIPO_ORDEN_COMPRA = DevolverTiposCampos("DOC_TIPO_ORDEN_COMPRA", cboDOC_TIPO_ORDEN_COMPRA.Text, Compuesto00)
            If Strings.Trim(txtPER_ID_REC.Text) = "" Then
                Compuesto00.PER_ID_REC = Nothing
            Else
                Compuesto00.PER_ID_REC = Strings.Trim(txtPER_ID_REC.Text)
            End If
            If Strings.Trim(txtTDP_ID_REC.Text) = "" Then
                Compuesto00.TDP_ID_REC = Nothing
            Else
                Compuesto00.TDP_ID_REC = Strings.Trim(txtTDP_ID_REC.Text)
            End If
            If Strings.Trim(txtDIR_ID_ENT_REC.Text) = "" Then
                Compuesto00.DIR_ID_ENT_REC = Nothing
            Else
                Compuesto00.DIR_ID_ENT_REC = Strings.Trim(txtDIR_ID_ENT_REC.Text)
            End If
            Compuesto00.PVE_ID = Strings.Trim(txtPVE_ID.Text)
            If Strings.Trim(txtPVE_ID_DES.Text) = "" Then
                Compuesto00.PVE_ID_DES = Nothing
            Else
                Compuesto00.PVE_ID_DES = Strings.Trim(txtPVE_ID_DES.Text)
            End If
            Compuesto00.MON_ID = Strings.Trim(txtMON_ID.Text)
            Compuesto00.TIV_ID = Strings.Trim(txtTIV_ID.Text)
            Compuesto00.PER_ID_CLI = Strings.Trim(txtPER_ID_CLI.Text)
            Compuesto00.TDP_ID_CLI = Strings.Trim(txtTDP_ID_CLI.Text)
            If Strings.Trim(txtPER_ID_CON.Text) = "" Then
                Compuesto00.PER_ID_CON = Nothing
            Else
                Compuesto00.PER_ID_CON = Strings.Trim(txtPER_ID_CON.Text)
            End If
            VerificarAsignacionFechasDocumento()

            If Strings.Trim(txtDIR_ID_FIS.Text) = "" Then
                Compuesto00.DIR_ID_FIS = Nothing
            Else
                Compuesto00.DIR_ID_FIS = Strings.Trim(txtDIR_ID_FIS.Text)
            End If
            If Strings.Trim(txtDIR_ID_DOM.Text) = "" Then
                Compuesto00.DIR_ID_DOM = Nothing
            Else
                Compuesto00.DIR_ID_DOM = Strings.Trim(txtDIR_ID_DOM.Text)
            End If
            If Strings.Trim(txtDIR_ID_ENT.Text) = "" Then
                Compuesto00.DIR_ID_ENT = Nothing
            Else
                Compuesto00.DIR_ID_ENT = Strings.Trim(txtDIR_ID_ENT.Text)
            End If
            If Strings.Trim(txtDIR_ID_COB.Text) = "" Then
                Compuesto00.DIR_ID_COB = Nothing
            Else
                Compuesto00.DIR_ID_COB = Strings.Trim(txtDIR_ID_COB.Text)
            End If
            Compuesto00.PER_ID_VEN = Strings.Trim(txtPER_ID_VEN.Text)
            If Strings.Trim(txtPER_ID_COB.Text) = "" Then
                Compuesto00.PER_ID_COB = Nothing
            Else
                Compuesto00.PER_ID_COB = Strings.Trim(txtPER_ID_COB.Text)
            End If
            If Strings.Trim(txtPER_ID_PRO.Text) = "" Then
                Compuesto00.PER_ID_PRO = Nothing
            Else
                Compuesto00.PER_ID_PRO = Strings.Trim(txtPER_ID_PRO.Text)
            End If
            If Strings.Trim(txtPER_ID_GRU.Text) = "" Then
                Compuesto00.PER_ID_GRU = Nothing
            Else
                Compuesto00.PER_ID_GRU = Strings.Trim(txtPER_ID_GRU.Text)
            End If
            Compuesto00.DOC_TIPO_LISTA = DevolverTiposCampos("DOC_TIPO_LISTA", cboDOC_TIPO_LISTA.Text, Compuesto00)
            Compuesto00.DOC_MONTO_TOTAL = CDbl(txtDOC_MONTO_TOTAL.Text)
            Compuesto00.DOC_CONTRAVALOR = CDbl(txtDOC_MONTO_TOTAL.Text) * TipoCambioCompraMoneda
            Compuesto00.DOC_IGV_POR = CDbl(txtDOC_IGV_POR.Text)
            Compuesto00.DOC_ASIENTO = DevolverTiposCampos(chkDOC_ASIENTO)
            Compuesto00.DOC_CIERRE = DevolverTiposCampos("DOC_CIERRE", cboDOC_CIERRE.Text, Compuesto00)
            If Strings.Trim(txtFLE_ID.Text) = "" Then
                Compuesto00.FLE_ID = Nothing
            Else
                Compuesto00.FLE_ID = Strings.Trim(txtFLE_ID.Text)
            End If
            If Not IsNumeric(txtDOC_MONTO_FLE.Text) Then
                Compuesto00.DOC_MONTO_FLE = CDbl(0)
            Else
                Compuesto00.DOC_MONTO_FLE = CDbl(txtDOC_MONTO_FLE.Text)
            End If

            Compuesto00.DOC_REQUIERE_GUIA = DevolverTiposCampos(chkDOC_REQUIERE_GUIA)

            If Strings.Trim(txtTDO_ID_AFE.Text) = "" Then
                Compuesto00.TDO_ID_AFE = Nothing
            Else
                Compuesto00.TDO_ID_AFE = Strings.Trim(txtTDO_ID_AFE.Text)
            End If
            If Strings.Trim(txtDTD_ID_AFE.Text) = "" Then
                Compuesto00.DTD_ID_AFE = Nothing
            Else
                Compuesto00.DTD_ID_AFE = Strings.Trim(txtDTD_ID_AFE.Text)
            End If
            If Strings.Trim(txtCCT_ID_AFE.Text) = "" Then
                Compuesto00.CCT_ID_AFE = Nothing
            Else
                Compuesto00.CCT_ID_AFE = Strings.Trim(txtCCT_ID_AFE.Text)
            End If
            If Strings.Trim(txtDOC_SERIE_AFE.Text) = "" Then
                Compuesto00.DOC_SERIE_AFE = Nothing
            Else
                Compuesto00.DOC_SERIE_AFE = Strings.Trim(txtDOC_SERIE_AFE.Text)
            End If
            Compuesto00.DOC_NUMERO_AFE = Strings.Trim(txtDOC_NUMERO_AFE.Text)
            Compuesto00.DOC_MOT_EMI = DevolverTiposCampos("DOC_MOT_EMI", cboDOC_MOT_EMI.Text, Compuesto00)
            Compuesto00.DOC_NOMBRE_RECEP = Strings.Trim(txtDOC_NOMBRE_RECEP.Text)
            If Strings.Trim(txtDOC_DNI_RECEP.Text) = "" Then
                Compuesto00.DOC_DNI_RECEP = Nothing
            Else
                Compuesto00.DOC_DNI_RECEP = Strings.Trim(txtDOC_DNI_RECEP.Text)
            End If
            Compuesto00.DOC_FEC_RECEP = dtpDOC_FEC_RECEP.Value
            Compuesto00.DOC_ENTREGADO = DevolverTiposCampos(chkDOC_ENTREGADO)
            If txtCAF_IX_NUMERO_PRO.Text.Trim = "" Then
                Compuesto00.CAF_IX_NUMERO_PRO = Nothing
            Else
                Compuesto00.CAF_IX_NUMERO_PRO = Strings.Trim(txtCAF_IX_NUMERO_PRO.Text)
            End If

            If txtCAF_IX_ORDEN_COM.Text.Trim = "" Then
                Compuesto00.CAF_IX_ORDEN_COM = Nothing
            Else
                Compuesto00.CAF_IX_ORDEN_COM = Strings.Trim(txtCAF_IX_ORDEN_COM.Text)
            End If

            Compuesto00.LPR_ID = Strings.Trim(txtLPR_ID.Text)
            Compuesto00.USU_ID = SessionService.UserId
            Compuesto00.DOC_FEC_GRAB = Now
            Compuesto00.DOC_ESTADO = DevolverTiposCampos("DOC_ESTADO", cboDOC_ESTADO.Text, Compuesto00)
        End Sub

        Private Function Validar(ByVal vModelos As String, Optional ByVal vFila As Integer = 0) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            vFlagVentaContadoBalanzaServicioEstibaje = False
            Select Case vModelos
                Case "Cabecera"
                    If txtPER_ID_CLI.Text.Trim <> "" Then
                        DatosPersona()
                        If cboDOC_ESTADO.Text <> "NO ACTIVO" Then VerificarSaldoCliente()
                    End If
                    resp.rM = Compuesto.ColocarErrores(txtTDO_ID, Compuesto.VerificarDatos("TDO_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTD_ID, Compuesto.VerificarDatos("DTD_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtCCT_ID, Compuesto.VerificarDatos("CCT_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_SERIE, Compuesto.VerificarDatos("DOC_SERIE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_NUMERO, Compuesto.VerificarDatos("DOC_NUMERO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_ORDEN_COMPRA, Compuesto.VerificarDatos("DOC_ORDEN_COMPRA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboDOC_TIPO_ORDEN_COMPRA, Compuesto.VerificarDatos("DOC_TIPO_ORDEN_COMPRA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_OBSERVACIONES, Compuesto.VerificarDatos("DOC_OBSERVACIONES"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID_REC, Compuesto.VerificarDatos("PER_ID_REC"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTDP_ID_REC, Compuesto.VerificarDatos("TDP_ID_REC"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDIR_ID_ENT_REC, Compuesto.VerificarDatos("DIR_ID_ENT_REC"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPVE_ID, Compuesto.VerificarDatos("PVE_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPVE_ID_DES, Compuesto.VerificarDatos("PVE_ID_DES"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtMON_ID, Compuesto.VerificarDatos("MON_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTIV_ID, Compuesto.VerificarDatos("TIV_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID_CLI, Compuesto.VerificarDatos("PER_ID_CLI"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTDP_ID_CLI, Compuesto.VerificarDatos("TDP_ID_CLI"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID_CON, Compuesto.VerificarDatos("PER_ID_CON"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpDOC_FECHA_EMI, Compuesto.VerificarDatos("DOC_FECHA_EMI"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpDOC_FECHA_ENT, Compuesto.VerificarDatos("DOC_FECHA_ENT"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpDOC_FECHA_EXP, Compuesto.VerificarDatos("DOC_FECHA_EXP"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDIR_ID_FIS, Compuesto.VerificarDatos("DIR_ID_FIS"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDIR_ID_DOM, Compuesto.VerificarDatos("DIR_ID_DOM"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDIR_ID_ENT, Compuesto.VerificarDatos("DIR_ID_ENT"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDIR_ID_COB, Compuesto.VerificarDatos("DIR_ID_COB"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID_VEN, Compuesto.VerificarDatos("PER_ID_VEN"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(tcoGestores, Compuesto.VerificarDatos("PER_ID_VEN"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID_COB, Compuesto.VerificarDatos("PER_ID_COB"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID_PRO, Compuesto.VerificarDatos("PER_ID_PRO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID_GRU, Compuesto.VerificarDatos("PER_ID_GRU"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboDOC_TIPO_LISTA, Compuesto.VerificarDatos("DOC_TIPO_LISTA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_MONTO_TOTAL, Compuesto.VerificarDatos("DOC_MONTO_TOTAL"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_IGV_POR, Compuesto.VerificarDatos("DOC_IGV_POR"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkDOC_ASIENTO, Compuesto.VerificarDatos("DOC_ASIENTO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboDOC_CIERRE, Compuesto.VerificarDatos("DOC_CIERRE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtFLE_ID, Compuesto.VerificarDatos("FLE_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkDOC_REQUIERE_GUIA, Compuesto.VerificarDatos("DOC_REQUIERE_GUIA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTDO_ID_AFE, Compuesto.VerificarDatos("TDO_ID_AFE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTD_ID_AFE, Compuesto.VerificarDatos("DTD_ID_AFE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtCCT_ID_AFE, Compuesto.VerificarDatos("CCT_ID_AFE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_SERIE_AFE, Compuesto.VerificarDatos("DOC_SERIE_AFE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_NUMERO_AFE, Compuesto.VerificarDatos("DOC_NUMERO_AFE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboDOC_MOT_EMI, Compuesto.VerificarDatos("DOC_MOT_EMI"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_NOMBRE_RECEP, Compuesto.VerificarDatos("DOC_NOMBRE_RECEP"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDOC_DNI_RECEP, Compuesto.VerificarDatos("DOC_DNI_RECEP"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpDOC_FEC_RECEP, Compuesto.VerificarDatos("DOC_FEC_RECEP"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkDOC_ENTREGADO, Compuesto.VerificarDatos("DOC_ENTREGADO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtCAF_IX_NUMERO_PRO, Compuesto.VerificarDatos("CAF_IX_NUMERO_PRO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtCAF_IX_ORDEN_COM, Compuesto.VerificarDatos("CAF_IX_ORDEN_COM"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(pnCuerpo, Compuesto.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(btnImagen, Compuesto.VerificarDatos("DOC_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboDOC_ESTADO, Compuesto.VerificarDatos("DOC_ESTADO"), ErrorProvider1)
                    If cboDOC_ESTADO.Text <> "NO ACTIVO" Then resp.rM = ValidarItemBalanzaServicioEstibaje(resp.rM)
                    If cboDOC_ESTADO.Text <> "NO ACTIVO" Then resp.rM = ValidarVentaBalanzaServicioEstibaje(resp.rM)

                    If Not vFlagVentaContadoBalanzaServicioEstibaje Then If cboDOC_ESTADO.Text <> "NO ACTIVO" Then resp.rM = ValidarLineaCredito(resp.rM)

                    'If Not vFlagVentaContadoBalanzaServicioEstibaje Then If cboDOC_ESTADO.Text <> "NO ACTIVO" Then If pDocumentoProcesandose <> 600 Then resp.rM = ValidarLineaCredito(resp.rM)
                    If txtTIV_DESCRIPCION.Text = BCVariablesNames.TipoVentaDescripcion.ContraentregaEnPlanta Then
                        If cboDOC_TIPO_LISTA.Text <> "PLANTA" Then
                            ErrorProvider1.SetError(cboDOC_TIPO_LISTA, "Error no se puede utilizar este tipo de lista, con el tipo de venta contraentrega en planta.")
                            resp.rM = False
                        End If
                    End If
                    If cboDOC_ESTADO.Text <> "NO ACTIVO" Then
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosFacturación.Boleta, _
                                 BCVariablesNames.ProcesosFacturación.Factura, _
                                 BCVariablesNames.ProcesosFacturación.PedidoBoleta, _
                                 BCVariablesNames.ProcesosFacturación.PedidoFactura
                                If dtpDOC_FECHA_ENT.Value < dtpDOC_FECHA_EMI.Value Then
                                    ErrorProvider1.SetError(dtpDOC_FECHA_ENT, "Error en la fecha.")
                                    resp.rM = False
                                End If
                                If dtpDOC_HORA_INICIO.Value.TimeOfDay.Hours = 0 Then
                                    ErrorProvider1.SetError(dtpDOC_HORA_INICIO, "Error en la hora.")
                                    resp.rM = False
                                End If
                                If dtpDOC_HORA_INICIO.Value.TimeOfDay >= dtpDOC_HORA_FIN.Value.TimeOfDay Then
                                    ErrorProvider1.SetError(dtpDOC_HORA_INICIO, "Error en la hora, la hora de inicio no puede ser igual o mayor a la hora de fin.")
                                    resp.rM = False
                                End If
                            Case Else
                        End Select
                    End If



                    resp.rM = ValidarDocumentoNota(resp.rM)
                    resp.rM = FiltrarSeleccionarValidarElementos(3, resp.rM)
                    resp.rM = ValidarDireccionesCliente(resp.rM)
                    resp.rM = ValidarFechasDocumento(resp.rM)

                    If cboDOC_ESTADO.Text <> "NO ACTIVO" Then resp.rM = ValidarUsuarioCredito1Dia(resp.rM)
                    If cboDOC_ESTADO.Text <> "NO ACTIVO" Then resp.rM = ValidarVendedorCredito1Dia(resp.rM)
                    'If cboDOC_ESTADO.Text <> "NO ACTIVO" Then If pDocumentoProcesandose <> 600 Then resp.rM = ValidarUsuarioCredito1Dia(resp.rM)
                    'If cboDOC_ESTADO.Text <> "NO ACTIVO" Then If pDocumentoProcesandose <> 600 Then resp.rM = ValidarVendedorCredito1Dia(resp.rM)

                    If Not vFlagVentaContadoBalanzaServicioEstibaje Then
                        If cboDOC_ESTADO.Text <> "NO ACTIVO" Then
                            'If pDocumentoProcesandose <> 600 Then
                            resp.rM = ValidarMontoContraEntrega(resp.rM)
                            resp.rM = ValidarTipoVenta(resp.rM)
                            resp.rM = ValidarDiasCredito(resp.rM)
                            'End If
                        End If
                    End If

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosFacturación.NotaCredito
                            Select Case cboDOC_MOT_EMI.Text
                                Case "ANULACION"
                                    resp.rM = VerificarCantidadMontoAfectaDocumentos(resp.rM)
                                    resp.rM = VerificarCantidadProductoAfectaDocumentos(resp.rM)
                                    resp.rM = VerificarCantidadProductoAfectaDocumentosNoGuiaDevolucion(resp.rM)
                                Case "DESCUENTO"
                                    resp.rM = VerificarCantidadMontoAfectaDocumentos(resp.rM)
                                    resp.rM = VerificarNoCantidadProductoAfectaDocumentos(resp.rM)
                                Case "DEVOLUCIONES"
                                    resp.rM = VerificarCantidadMontoAfectaDocumentos(resp.rM)
                                    resp.rM = VerificarCantidadProductoAfectaDocumentos(resp.rM)
                                    resp.rM = VerificarCantidadProductoAfectaDocumentosGuiaDevolucion(resp.rM)
                            End Select
                            Select Case cboDOC_MOT_EMI.Text
                                Case "DESC. ESPEC."
                                    resp.rM = VerificarTotalMontoNotaCreditoCero(resp.rM)
                                Case Else
                                    resp.rM = VerificarTotalMontoAfectaDocumentos(resp.rM)
                                    resp.rM = VerificarTotalMontoNotaCredito(resp.rM)
                            End Select
                        Case Else
                    End Select

                    For vFilas = 0 To dgvDetalleAfectaProducto.RowCount - 1
                        If Trim(dgvDetalleAfectaProducto.Item("cTDO_ID_DEV", vFilas).Value) <> "" And _
                           Trim(dgvDetalleAfectaProducto.Item("cDTD_ID_DEV", vFilas).Value) <> "" Then
                            If dgvDetalleAfectaProducto.Item("cART_IDp", vFilas).Value = dgvDetalleAfectaProducto.Item("cART_ID_DEVp", vFilas).Value Then
                                If dgvDetalleAfectaProducto.Item("cDAP_CANTIDAD", vFilas).Value > dgvDetalleAfectaProducto.Item("cDDE_CANTIDAD_DEV", vFilas).Value Then
                                    ErrorProvider1.SetError(dgvDetalleAfectaProducto, "Error en la cantidad ingresada no concuerda con la guía de devolución")
                                    resp.rM = False
                                    Exit For
                                End If
                            Else
                                ErrorProvider1.SetError(dgvDetalleAfectaProducto, "Error en la cantidad ingresada no concuerda con la guía de devolución")
                                resp.rM = False
                                Exit For
                            End If
                        End If
                    Next

                Case "Detalle"
                    resp.rM = Compuesto1.ColocarErrores(dgvDetalle, _
                    Compuesto1.VerificarDatos("TDO_ID",
                    "DTD_ID",
                    "DDO_SERIE",
                    "DDO_NUMERO",
                    "DDO_ITEM",
                    "ART_ID_IMP",
                    "ART_ID_KAR",
                    "DDO_CANTIDAD",
                    "DDO_INC_IGV",
                    "DDO_DES_INC_PRE",
                    "DDO_PRE_UNI",
                    "DDO_IGV_POR",
                    "DDO_MONTO_IGV",
                    "DDO_PRE_TOTAL",
                    "DDO_OBS_DSC_ART",
                    "TDO_ID_ANT",
                    "DTD_ID_ANT",
                    "CCT_ID_ANT",
                    "DDO_SERIE_ANT",
                    "DDO_NUMERO_ANT",
                    "USU_ID",
                    "DDO_FEC_GRAB",
                    "DDO_ESTADO"), _
                    ErrorProvider1, vFila)
            End Select
            Return vrO
        End Function
        Private Sub InicializarOrm()
            InicializarOrmDetalle()
            InicializarOrmCorrelativo()

            'Compuesto00 = Nothing
            'Compuesto00 = New Ladisac.BE.Documentos

            'Compuesto = Nothing
            'Compuesto = New Ladisac.BE.Documentos
            FiltrarTabla()
        End Sub
        Private Sub InicializarOrmCorrelativo()
            'Compuesto2 = Nothing
            'Compuesto2 = New Ladisac.BE.CorrelativoTipoDocumento
        End Sub
        Private Sub InicializarOrmDetalle()
            'Compuesto01 = Nothing
            'Compuesto01 = New Ladisac.BE.DetalleDocumentos

            'Compuesto1 = Nothing
            'Compuesto1 = New Ladisac.BE.DetalleDocumentos
        End Sub
        Private Sub InicializarOrmKardexCtaCte()
            'Compuesto6 = Nothing
            'Compuesto6 = New Ladisac.BE.KardexCtaCte
        End Sub
        Private Sub FiltrarTabla()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.PedidoBoleta,
                     BCVariablesNames.ProcesosFacturación.PedidoFactura
                    If pDocumentoProcesandose = 2000 Then
                        Compuesto.CadenaFiltrado = " And TDO_ID IN ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & "','" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "')" & _
                           " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
                    Else
                        If pDocumentoProcesandose = 600 Then
                            Compuesto.CadenaFiltrado = " And TDO_ID IN ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & "','" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "')" & _
                                " And DOC_ESTADO='" & BCVariablesNames.EstadoRegistro.NoActivo & "'" & _
                                " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
                        Else
                            Compuesto.CadenaFiltrado = " And TDO_ID IN ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & "','" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "')" & _
                                " And DOC_ESTADO='" & BCVariablesNames.EstadoRegistro.PorProcesar & "'" & _
                                " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
                        End If
                    End If
                Case Else
                    If pDocumentoProcesandose = 1000 Then
                        Compuesto.CadenaFiltrado = " And DOC_ESTADO In ('ACTIVO','POR PROCESAR')"
                    ElseIf pDocumentoProcesandose = 3000 Then
                        Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & "'" 
                    Else
                        Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & "'" & _
                                                   " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
                    End If
            End Select
        End Sub

        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            Dim vCadenaFiltrado As String = ""
            FiltrarTabla()
            Select Case vComportamiento
                Case 0, 30 ' Documentos
                    If txtPVE_ID.Text.Trim <> "" Then
                        Dim vcontrol As Int16 = 0
                        Dim ds As New DataSet
                        Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spListarPuntoVentaPVE_IDXML, txtPVE_ID.Text))
                        vcontrol = sr.Peek

                        If vcontrol <> -1 Then
                            ds.ReadXml(sr)
                            vPVE_TIPO = ds.Tables(0).Rows(0).Item("PVE_TIPO")
                        Else
                            vPVE_TIPO = ""
                        End If
                        FiltrarSeleccionarValidarElementosDOC_TIPO_LISTA(1, False)
                    End If

                    If txtPER_ID_CLI.Text.Trim <> "" Then
                        DatosPersona()
                        pPER_FORMA_VENTA = Me.IBCBusqueda.FormaVentaPersona(txtPER_ID_CLI.Text)
                        pPER_TELEFONOS = Me.IBCBusqueda.TelefonoPersona(txtPER_ID_CLI.Text)
                        pProcesarDescuentoIncremento = VerificarPER_PROMOCIONES()
                    End If
                    If txtDTD_ID_AFE.Text.Trim <> "" Then
                        VerificarTotalDocumentoAfectado()
                    End If
                    VerificarDatosCliente()
                    FiltroART_ID()
                    FiltroDgvDetalle()
                    FiltroDTD_ID_ANT()
                    FiltrocboDOC_TIPO_LISTA()
                    MostrarAutorizadoDescuento()
                Case 2 ' PuntoVenta
                    If txtPVE_ID.Text.Trim <> "" Then FiltrarSeleccionarValidarElementosDOC_TIPO_LISTA(1, True)

                    'cboDOC_TIPO_LISTA.Text = "PLANTA"

                    FiltroPVE_ID()
                    FiltroMON_ID()
                Case 3 ' DetalleTipoDocumentos
                    FiltroART_ID()
                    FiltroDgvDetalle()
                    FiltroDTD_ID_ANT()
                    FiltrarSeleccionarValidarElementosDOC_TIPO_LISTA(2, True)
                    FiltrocboDOC_TIPO_LISTA()
                    'FiltrarSeleccionarValidarElementosDOC_TIPO_LISTA(2, True)

                    Select Case pDTD_ID
                        Case "001"
                            txtPER_ID_CLI.Text = ""
                            txtPER_ID_CLI.Enabled = False
                            txtPER_ID_CLI.ReadOnly = True
                            EtxtPER_ID_CLI.pBusqueda = False

                            txtTDP_ID_CLI.Enabled = False
                            txtTDP_ID_CLI.ReadOnly = True
                            EtxtTDP_ID_CLI.pBusqueda = False
                        Case "004"
                            txtPER_ID_CLI.Text = ""
                            txtPER_ID_CLI.Enabled = False
                            txtPER_ID_CLI.ReadOnly = True
                            EtxtPER_ID_CLI.pBusqueda = False

                            txtTDP_ID_CLI.Enabled = False
                            txtTDP_ID_CLI.ReadOnly = True
                            EtxtTDP_ID_CLI.pBusqueda = False
                            'Case Else
                            '    txtPER_ID_CLI.Enabled = True
                            '    txtPER_ID_CLI.ReadOnly = False
                            '    EtxtPER_ID_CLI.pBusqueda = True

                            '    txtTDP_ID_CLI.Enabled = True
                            '    txtTDP_ID_CLI.ReadOnly = False
                            '    EtxtTDP_ID_CLI.pBusqueda = True
                    End Select
                Case 4 ' Moneda
                    FiltroMON_ID()
                Case 4 ' Tipo de venta
                    DiasRetraso()
                Case 6 ' Personas - Cliente
                    DatosPersona()
                    VerificarDatosCliente()
                    FiltroART_ID()
                    MostrarAutorizadoDescuento()
                    FiltroDTD_ID_ANT()
                Case 7 ' DocPersona - Cliente
                    FiltroPER_ID_CLI()
                    FiltroDTD_ID_ANT()
                Case 12 ' Personas - Recepciona
                    vCadenaFiltrado = " And PER_ID='" & txtPER_ID_REC.Text & "'"
                    EtxtDIR_ID_ENT_REC.pOOrm.CadenaFiltrado = vCadenaFiltrado
                    If txtPER_ID_REC.Text.Trim = "" Then
                        vCadenaFiltrado = ""
                    End If
                    EtxtTDP_ID_REC.pOOrm.CadenaFiltrado = vCadenaFiltrado
                Case 20 ' PuntoVenta - Despacho
                    FiltroPVE_ID(False)
                    FiltroMON_ID()
                Case 21 ' ListaPrecios - Articulos
                    FiltroART_ID()
                Case 25 ' DetalleListaPrecios - Articulos
                    ProcesarTotalArticulo(dgvDetalle.CurrentRow.Index, 0)
                Case 26 ' Documentos - Nota Crédito/Débito
                    SaldosDocumentoCliente()
                    'Case 30 ' Documentos - Proforma
                    'If txtPVE_ID.Text.Trim <> "" Then FiltrarSeleccionarValidarElementosDOC_TIPO_LISTA(1, False)
                    'If txtPER_ID_CLI.Text.Trim <> "" Then
                    'txtPER_LINEA_CREDITO.Text = Me.IBCBusqueda.LineaCreditoPersona(txtPER_ID_CLI.Text)
                    'pPER_FORMA_VENTA = Me.IBCBusqueda.FormaVentaPersona(txtPER_ID_CLI.Text)
                    'pProcesarDescuentoIncremento = VerificarPER_PROMOCIONES()
                    'End If
            End Select

            PresentacionNumeros(vComportamiento)
        End Sub
        Private Sub DiasRetraso()
            txtDiasGeneral.Text = IBCBusqueda.DiasRetrasoGeneral(txtPER_ID_CLI.Text)
            txtDiasContado.Text = IBCBusqueda.DiasRetraso(txtPER_ID_CLI.Text, "'001','025'")
            txtDiasContraentragaCredito123.Text = IBCBusqueda.DiasRetraso(txtPER_ID_CLI.Text, "'002','008','026'")
            ''txtDiasContado.Text = IBCBusqueda.DiasRetraso(txtPER_ID_CLI.Text, "'001'")
            ''txtDiasContraentragaCredito123.Text = IBCBusqueda.DiasRetraso(txtPER_ID_CLI.Text, "'002','008','025','026'")

        End Sub
        Private Sub DatosPersona()
            vEsPersonaAgenteProveedor = Me.IBCBusqueda.EsPersonaAgentePercepcion(txtPER_ID_CLI.Text)
            vEsPersonaAgenteCliente = Me.IBCBusqueda.EsPersonaAgenteRetencion(txtPER_ID_CLI.Text)

            DiasRetraso()
            ''txtDiasContado.Text = IBCBusqueda.DiasRetraso(txtPER_ID_CLI.Text, "'001'")
            ''txtDiasContraentragaCredito123.Text = IBCBusqueda.DiasRetraso(txtPER_ID_CLI.Text, "'002','008','025','026'")

            txtLineaContado.Text = 999999999
            txtLineaContraentregaCredito123.Text = IBCBusqueda.LimiteContraEntrega("LIMITECONTRAENTREGA")
            txtPER_LINEA_CREDITO.Text = Me.IBCBusqueda.LineaCreditoPersona(txtPER_ID_CLI.Text)
            txtPER_DIAS_CREDITO.Text = Me.IBCBusqueda.DiasCreditoPersona(txtPER_ID_CLI.Text)

            vClienteSoloContado = Me.IBCBusqueda.ClienteSoloVentaContado(txtPER_ID_CLI.Text)
            vClienteLineaCreditoEstado = Me.IBCBusqueda.LineaCreditoPersonaEstado(txtPER_ID_CLI.Text)

            vPedidoDocumento = Me.IBCBusqueda.PedidoDocumento(txtTDO_ID.Text, txtDTD_ID.Text, txtDOC_SERIE.Text, txtDOC_NUMERO.Text)

            lblPedidoDocumento.Text = "Pedido : " & vPedidoDocumento

            If vEsPersonaAgenteProveedor = BCVariablesNames.AgenteProveedor.AgentePercepcion0 Then
                tslEsAgenteProveedor.Text = "NO ES AGENTE DE PERCEPCION"
            Else
                tslEsAgenteProveedor.Text = vEsPersonaAgenteProveedor
            End If

            If vEsPersonaAgenteCliente = BCVariablesNames.AgenteCliente.AgenteRetencion0 Then
                tslEsAgenteCliente.Text = "NO ES AGENTE DE RETENCION"
            Else
                tslEsAgenteCliente.Text = vEsPersonaAgenteCliente
            End If
        End Sub
        Private Sub PresentacionNumeros(ByVal vComportamiento As Integer)
            If IsNumeric(txtLineaContado.Text) Then txtLineaContado.Text = Format(CDbl(txtLineaContado.Text), "##,###.#0")
            If IsNumeric(txtDeudaContado.Text) Then txtDeudaContado.Text = Format(CDbl(txtDeudaContado.Text), "##,###.#0")
            If IsNumeric(txtDisponibleContado.Text) Then txtDisponibleContado.Text = Format(CDbl(txtDisponibleContado.Text), "##,###.#0")

            If IsNumeric(txtLineaContraentregaCredito123.Text) Then txtLineaContraentregaCredito123.Text = Format(CDbl(txtLineaContraentregaCredito123.Text), "##,###.#0")
            If IsNumeric(txtDeudaContraentregaCredito123.Text) Then txtDeudaContraentregaCredito123.Text = Format(CDbl(txtDeudaContraentregaCredito123.Text), "##,###.#0")
            If IsNumeric(txtDisponibleContraentregaCredito123.Text) Then txtDisponibleContraentregaCredito123.Text = Format(CDbl(txtDisponibleContraentregaCredito123.Text), "##,###.#0")

            If IsNumeric(txtPER_LINEA_CREDITO.Text) Then txtPER_LINEA_CREDITO.Text = Format(CDbl(txtPER_LINEA_CREDITO.Text), "##,###.#0")
            If IsNumeric(txtDeuda.Text) Then txtDeuda.Text = Format(CDbl(txtDeuda.Text), "##,###.#0")
            If IsNumeric(txtDisponible.Text) Then txtDisponible.Text = Format(CDbl(txtDisponible.Text), "##,###.#0")

            If IsNumeric(txtDOC_MONTO_FLE.Text) Then txtDOC_MONTO_FLE.Text = Format(CDbl(txtDOC_MONTO_FLE.Text), "##,###.#0")

            If IsNumeric(txtTotalBruto.Text) Then txtTotalBruto.Text = Format(CDbl(txtTotalBruto.Text), "##,###.#0")
            If IsNumeric(txtTotDescInc.Text) Then txtTotDescInc.Text = Format(CDbl(txtTotDescInc.Text), "##,###.#0")
            If IsNumeric(txtExonerado.Text) Then txtExonerado.Text = Format(CDbl(txtExonerado.Text), "##,###.#0")
            If IsNumeric(txtBaseImponible.Text) Then txtBaseImponible.Text = Format(CDbl(txtBaseImponible.Text), "##,###.#0")
            If IsNumeric(txtTotalIGV.Text) Then txtTotalIGV.Text = Format(CDbl(txtTotalIGV.Text), "##,###.#0")
            If IsNumeric(txtDOC_MONTO_TOTAL.Text) Then txtDOC_MONTO_TOTAL.Text = Format(CDbl(txtDOC_MONTO_TOTAL.Text), "##,###.#0")
            If IsNumeric(txtDOC_MONTO_PERCEPCION.Text) Then txtDOC_MONTO_PERCEPCION.Text = Format(CDbl(txtDOC_MONTO_PERCEPCION.Text), "##,###.#0")
        End Sub
        Private Sub SaldosDocumentoCliente()
            'Try
            Dim ds As New DataSet
            If txtPER_ID_CLI.Text.Trim <> "" Then
                If txtDTD_ID_AFE.Text.Trim <> "" Then
                    Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spSaldoskardexDocumentosXML, _
                                                                            DBNull.Value, _
                                                                            DBNull.Value, _
                                                                            txtPER_ID_CLI.Text.Trim, _
                                                                            txtCCT_ID_AFE.Text.Trim, _
                                                                            txtTDO_ID_AFE.Text.Trim, _
                                                                            txtDTD_ID_AFE.Text.Trim, _
                                                                            txtDOC_SERIE_AFE.Text.Trim, _
                                                                            txtDOC_NUMERO_AFE.Text.Trim, _
                                                                            txtTDO_ID.Text.Trim & txtDTD_ID.Text.Trim & txtDOC_SERIE.Text.Trim & txtDOC_NUMERO.Text.Trim, _
                                                                            0
                                                                            )
                                                    )
                    Dim vcontrol As Int16 = sr.Peek
                    If vcontrol <> -1 Then
                        ds.ReadXml(sr)
                        dgvSaldos.DataSource = ds.Tables(0)
                        TotalizarSaldosCliente()
                    Else
                        dgvSaldos.DataSource = Nothing
                    End If
                Else
                    dgvSaldos.DataSource = Nothing
                End If
            Else
                dgvSaldos.DataSource = Nothing
            End If
            'Catch ex As Exception
            'MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - PrepararEliminar - Compuesto")
            'End Try

        End Sub


        Private Sub SaldosClienteContado()
            Try
                Dim ds As New DataSet
                dgvSaldosContado.DataSource = Nothing
                If txtPER_ID_CLI.Text.Trim <> "" Then
                    Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spSaldosContadoClienteXML, _
                                                                        DBNull.Value, _
                                                                        DBNull.Value, _
                                                                        txtPER_ID_CLI.Text.Trim, _
                                                                        txtTDO_ID.Text.Trim & txtDTD_ID.Text.Trim & txtDOC_SERIE.Text.Trim & txtDOC_NUMERO.Text.Trim))
                    Dim vcontrol As Int16 = sr.Peek
                    If vcontrol <> -1 Then
                        ds.ReadXml(sr)
                        dgvSaldosContado.DataSource = ds.Tables(0)
                        TotalizarSaldosClienteContado()
                    Else
                        dgvSaldosContado.DataSource = Nothing
                        VisualizarTotalizarSaldosClienteContado(0)
                    End If
                Else
                    dgvSaldosContado.DataSource = Nothing
                End If
            Catch ex As Exception
                MsgBox(ex.Message & Err.Number)
            End Try
        End Sub
        Private Sub SaldosClienteContraentregaCredito123()
            Try
                Dim ds As New DataSet
                dgvSaldosContraentregaCredito123.DataSource = Nothing
                If txtPER_ID_CLI.Text.Trim <> "" Then
                    Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spSaldosContraentregaCredito123ClienteXML, _
                                                                        DBNull.Value, _
                                                                        DBNull.Value, _
                                                                        txtPER_ID_CLI.Text.Trim, _
                                                                        txtTDO_ID.Text.Trim & txtDTD_ID.Text.Trim & txtDOC_SERIE.Text.Trim & txtDOC_NUMERO.Text.Trim))
                    Dim vcontrol As Int16 = sr.Peek
                    If vcontrol <> -1 Then
                        ds.ReadXml(sr)
                        dgvSaldosContraentregaCredito123.DataSource = ds.Tables(0)
                        TotalizarSaldosClienteContraentregaCredito123()
                    Else
                        dgvSaldosContraentregaCredito123.DataSource = Nothing
                        VisualizarTotalizarSaldosClienteContraentregaCredito123(0)
                    End If
                Else
                    dgvSaldosContraentregaCredito123.DataSource = Nothing
                End If
            Catch ex As Exception
                MsgBox(ex.Message & Err.Number)
            End Try
        End Sub
        Private Sub SaldosCliente()
            Try
                Dim ds As New DataSet
                dgvSaldos.DataSource = Nothing
                If txtPER_ID_CLI.Text.Trim <> "" Then
                    Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spSaldosClienteXML, _
                                                                        DBNull.Value, _
                                                                        DBNull.Value, _
                                                                        txtPER_ID_CLI.Text.Trim, _
                                                                        txtTDO_ID.Text.Trim & txtDTD_ID.Text.Trim & txtDOC_SERIE.Text.Trim & txtDOC_NUMERO.Text.Trim))
                    Dim vcontrol As Int16 = sr.Peek
                    If vcontrol <> -1 Then
                        ds.ReadXml(sr)
                        dgvSaldos.DataSource = ds.Tables(0)
                        TotalizarSaldosCliente()
                    Else
                        dgvSaldos.DataSource = Nothing
                        VisualizarTotalizarSaldosCliente(0)
                    End If
                Else
                    dgvSaldos.DataSource = Nothing
                End If
            Catch ex As Exception
                MsgBox(ex.Message & Err.Number)
            End Try
        End Sub

        Private Sub TotalizarSaldosClienteContado()
            Dim vCodigoMonedaProcesar As String = Nothing
            Dim vCodigoMonedaProcesarTemporal As String = Nothing
            Dim vMontoTipoCambioMoneda As Decimal = 0
            Dim vMontoTipoCambioMonedaTemporal As Decimal = 0
            Dim vTotalDeuda As Decimal = 0
            Dim vTotalDeudaTemporal As Decimal = 0
            Dim vSaldo As Decimal = 0
            Dim vSaldoTemporal As Decimal = 0
            Dim vFlag As Boolean = False
            For vfila = 0 To dgvSaldosContado.RowCount - 1
                vFlag = False
                vCodigoMonedaProcesar = cMisProcedimientos.EstablecerCodigoMoneda(BCVariablesNames.MonedaSistema, _
                                                                                  dgvSaldosContado.Item("MON_ID", vfila).Value, _
                                                                                  txtMON_ID.Text)
                vSaldo = CDbl(dgvSaldosContado.Item("Saldo", vfila).Value)
                If vCodigoMonedaProcesar = BCVariablesNames.MonedaSistema Then
                    vMontoTipoCambioMoneda = 1
                Else
                    ''
                    If dgvSaldosContado.Item("MON_ID", vfila).Value <> BCVariablesNames.MonedaSistema And
                       txtMON_ID.Text <> BCVariablesNames.MonedaSistema Then
                        If txtMON_ID.Text = dgvSaldosContado.Item("MON_ID", vfila).Value Then
                            vFlag = True
                            vMontoTipoCambioMoneda = 1
                        Else
                            vCodigoMonedaProcesar = txtMON_ID.Text
                            vCodigoMonedaProcesarTemporal = dgvSaldosContado.Item("MON_ID", vfila).Value
                            vMontoTipoCambioMonedaTemporal = cMisProcedimientos.SolicitarMontoTipoCambioMoneda(BCVariablesNames.MonedaSistema,
                                                                                                               vCodigoMonedaProcesarTemporal, _
                                                                                                               dtpDOC_FECHA_EMI.Value, _
                                                                                                               IBCMaestro)
                            If vMontoTipoCambioMonedaTemporal <> 0 Then
                                vSaldoTemporal = cMisProcedimientos.MontoSegunTipoCambio(vMontoTipoCambioMonedaTemporal, _
                                                                                         vCodigoMonedaProcesarTemporal, _
                                                                                         BCVariablesNames.MonedaSistema, _
                                                                                         vSaldo)
                                ErrorProvider1.SetError(txtDeudaContado, Nothing)
                                vSaldo = vSaldoTemporal
                            Else
                                vTotalDeuda = 999999999.99
                                ErrorProvider1.SetError(txtMON_ID, "No existe tipo de cambio para el saldo de un documento")
                                Exit For
                            End If
                        End If
                    End If
                    ''
                    If Not vFlag Then vMontoTipoCambioMoneda = cMisProcedimientos.SolicitarMontoTipoCambioMoneda(BCVariablesNames.MonedaSistema, _
                                                                                                                 vCodigoMonedaProcesar, _
                                                                                                                 dtpDOC_FECHA_EMI.Value, _
                                                                                                                 IBCMaestro)
                End If
                If vMontoTipoCambioMoneda <> 0 Then
                    vTotalDeuda += cMisProcedimientos.MontoSegunTipoCambio(vMontoTipoCambioMoneda, _
                                                                           txtMON_ID.Text.Trim, _
                                                                           BCVariablesNames.MonedaSistema, _
                                                                           vSaldo)
                    ErrorProvider1.SetError(txtDeudaContado, Nothing)
                Else
                    vTotalDeuda = 999999999.99
                    ErrorProvider1.SetError(txtMON_ID, "No existe tipo de cambio para el saldo de un documento")
                    Exit For
                End If
            Next
            VisualizarTotalizarSaldosClienteContado(vTotalDeuda)
        End Sub
        Private Sub TotalizarSaldosClienteContraentregaCredito123()
            Dim vCodigoMonedaProcesar As String = Nothing
            Dim vCodigoMonedaProcesarTemporal As String = Nothing
            Dim vMontoTipoCambioMoneda As Decimal = 0
            Dim vMontoTipoCambioMonedaTemporal As Decimal = 0
            Dim vTotalDeuda As Decimal = 0
            Dim vTotalDeudaTemporal As Decimal = 0
            Dim vSaldo As Decimal = 0
            Dim vSaldoTemporal As Decimal = 0
            Dim vFlag As Boolean = False
            For vfila = 0 To dgvSaldosContraentregaCredito123.RowCount - 1
                vFlag = False
                vCodigoMonedaProcesar = cMisProcedimientos.EstablecerCodigoMoneda(BCVariablesNames.MonedaSistema, _
                                                                                  dgvSaldosContraentregaCredito123.Item("MON_ID", vfila).Value, _
                                                                                  txtMON_ID.Text)
                vSaldo = CDbl(dgvSaldosContraentregaCredito123.Item("Saldo", vfila).Value)
                If vCodigoMonedaProcesar = BCVariablesNames.MonedaSistema Then
                    vMontoTipoCambioMoneda = 1
                Else
                    ''
                    If dgvSaldosContraentregaCredito123.Item("MON_ID", vfila).Value <> BCVariablesNames.MonedaSistema And
                       txtMON_ID.Text <> BCVariablesNames.MonedaSistema Then
                        If txtMON_ID.Text = dgvSaldosContraentregaCredito123.Item("MON_ID", vfila).Value Then
                            vFlag = True
                            vMontoTipoCambioMoneda = 1
                        Else
                            vCodigoMonedaProcesar = txtMON_ID.Text
                            vCodigoMonedaProcesarTemporal = dgvSaldosContraentregaCredito123.Item("MON_ID", vfila).Value
                            vMontoTipoCambioMonedaTemporal = cMisProcedimientos.SolicitarMontoTipoCambioMoneda(BCVariablesNames.MonedaSistema,
                                                                                                               vCodigoMonedaProcesarTemporal, _
                                                                                                               dtpDOC_FECHA_EMI.Value, _
                                                                                                               IBCMaestro)
                            If vMontoTipoCambioMonedaTemporal <> 0 Then
                                vSaldoTemporal = cMisProcedimientos.MontoSegunTipoCambio(vMontoTipoCambioMonedaTemporal, _
                                                                                         vCodigoMonedaProcesarTemporal, _
                                                                                         BCVariablesNames.MonedaSistema, _
                                                                                         vSaldo)
                                ErrorProvider1.SetError(txtDeudaContraentregaCredito123, Nothing)
                                vSaldo = vSaldoTemporal
                            Else
                                vTotalDeuda = 999999999.99
                                ErrorProvider1.SetError(txtMON_ID, "No existe tipo de cambio para el saldo de un documento")
                                Exit For
                            End If
                        End If
                    End If
                    ''
                    If Not vFlag Then vMontoTipoCambioMoneda = cMisProcedimientos.SolicitarMontoTipoCambioMoneda(BCVariablesNames.MonedaSistema, _
                                                                                                                 vCodigoMonedaProcesar, _
                                                                                                                 dtpDOC_FECHA_EMI.Value, _
                                                                                                                 IBCMaestro)
                End If
                If vMontoTipoCambioMoneda <> 0 Then
                    vTotalDeuda += cMisProcedimientos.MontoSegunTipoCambio(vMontoTipoCambioMoneda, _
                                                                           txtMON_ID.Text.Trim, _
                                                                           BCVariablesNames.MonedaSistema, _
                                                                           vSaldo)
                    ErrorProvider1.SetError(txtDeudaContraentregaCredito123, Nothing)
                Else
                    vTotalDeuda = 999999999.99
                    ErrorProvider1.SetError(txtMON_ID, "No existe tipo de cambio para el saldo de un documento")
                    Exit For
                End If
            Next
            VisualizarTotalizarSaldosClienteContraentregaCredito123(vTotalDeuda)
        End Sub
        Private Sub TotalizarSaldosCliente()
            Dim vCodigoMonedaProcesar As String = Nothing
            Dim vCodigoMonedaProcesarTemporal As String = Nothing
            Dim vMontoTipoCambioMoneda As Decimal = 0
            Dim vMontoTipoCambioMonedaTemporal As Decimal = 0
            Dim vTotalDeuda As Decimal = 0
            Dim vTotalDeudaTemporal As Decimal = 0
            Dim vSaldo As Decimal = 0
            Dim vSaldoTemporal As Decimal = 0
            Dim vFlag As Boolean = False
            For vfila = 0 To dgvSaldos.RowCount - 1
                vFlag = False
                vCodigoMonedaProcesar = cMisProcedimientos.EstablecerCodigoMoneda(BCVariablesNames.MonedaSistema, _
                                                                                  dgvSaldos.Item("MON_ID", vfila).Value, _
                                                                                  txtMON_ID.Text)
                vSaldo = CDbl(dgvSaldos.Item("Saldo", vfila).Value)
                If vCodigoMonedaProcesar = BCVariablesNames.MonedaSistema Then
                    vMontoTipoCambioMoneda = 1
                Else
                    ''
                    If dgvSaldos.Item("MON_ID", vfila).Value <> BCVariablesNames.MonedaSistema And
                       txtMON_ID.Text <> BCVariablesNames.MonedaSistema Then
                        If txtMON_ID.Text = dgvSaldos.Item("MON_ID", vfila).Value Then
                            vFlag = True
                            vMontoTipoCambioMoneda = 1
                        Else
                            vCodigoMonedaProcesar = txtMON_ID.Text
                            vCodigoMonedaProcesarTemporal = dgvSaldos.Item("MON_ID", vfila).Value
                            vMontoTipoCambioMonedaTemporal = cMisProcedimientos.SolicitarMontoTipoCambioMoneda(BCVariablesNames.MonedaSistema,
                                                                                                               vCodigoMonedaProcesarTemporal, _
                                                                                                               dtpDOC_FECHA_EMI.Value, _
                                                                                                               IBCMaestro)
                            If vMontoTipoCambioMonedaTemporal <> 0 Then
                                vSaldoTemporal = cMisProcedimientos.MontoSegunTipoCambio(vMontoTipoCambioMonedaTemporal, _
                                                                                         vCodigoMonedaProcesarTemporal, _
                                                                                         BCVariablesNames.MonedaSistema, _
                                                                                         vSaldo)
                                ErrorProvider1.SetError(txtDeuda, Nothing)
                                vSaldo = vSaldoTemporal
                            Else
                                vTotalDeuda = 999999999.99
                                ErrorProvider1.SetError(txtMON_ID, "No existe tipo de cambio para el saldo de un documento")
                                Exit For
                            End If
                        End If
                    End If
                    ''
                    If Not vFlag Then vMontoTipoCambioMoneda = cMisProcedimientos.SolicitarMontoTipoCambioMoneda(BCVariablesNames.MonedaSistema, _
                                                                                                                 vCodigoMonedaProcesar, _
                                                                                                                 dtpDOC_FECHA_EMI.Value, _
                                                                                                                 IBCMaestro)
                End If
                If vMontoTipoCambioMoneda <> 0 Then
                    vTotalDeuda += cMisProcedimientos.MontoSegunTipoCambio(vMontoTipoCambioMoneda, _
                                                                           txtMON_ID.Text.Trim, _
                                                                           BCVariablesNames.MonedaSistema, _
                                                                           vSaldo)
                    ErrorProvider1.SetError(txtDeuda, Nothing)
                Else
                    vTotalDeuda = 999999999.99
                    ErrorProvider1.SetError(txtMON_ID, "No existe tipo de cambio para el saldo de un documento")
                    Exit For
                End If
            Next
            VisualizarTotalizarSaldosCliente(vTotalDeuda)
        End Sub


        Private Sub VisualizarTotalizarSaldosClienteContado(ByVal vTotalDeuda)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito
                    'txtDisponibleContado.Text = vTotalDeuda
                Case BCVariablesNames.ProcesosFacturación.NotaDebito
                Case Else
                    txtDeudaContado.Text = vTotalDeuda
                    txtDisponibleContado.Text = CDbl(txtLineaContado.Text) - vTotalDeuda
            End Select
        End Sub
        Private Sub VisualizarTotalizarSaldosClienteContraentregaCredito123(ByVal vTotalDeuda)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito
                    'txtDisponibleContraentregaCredito123.Text = vTotalDeuda
                Case BCVariablesNames.ProcesosFacturación.NotaDebito
                Case Else
                    txtDeudaContraentregaCredito123.Text = vTotalDeuda
                    txtDisponibleContraentregaCredito123.Text = CDbl(txtLineaContraentregaCredito123.Text) - vTotalDeuda
            End Select
        End Sub
        Private Sub VisualizarTotalizarSaldosCliente(ByVal vTotalDeuda)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito
                    txtDisponible.Text = vTotalDeuda
                Case BCVariablesNames.ProcesosFacturación.NotaDebito
                Case Else
                    txtDeuda.Text = vTotalDeuda
                    txtDisponible.Text = CDbl(txtPER_LINEA_CREDITO.Text) - vTotalDeuda
            End Select
        End Sub

        Public Function CambiarMonedaSaldo(ByVal CodigoMoneda) As Decimal
            CambiarMonedaSaldo = 0
            Dim vCodigoMoneda As String
            Dim vcontrol As Int16
            Dim ds As New DataSet
            If BCVariablesNames.MonedaSistema = CodigoMoneda Then
                vCodigoMoneda = txtMON_ID.Text
            Else
                vCodigoMoneda = CodigoMoneda
            End If

            Dim sr As New StringReader(IBCMaestro.EjecutarVista("spCambioDiaXML", BCVariablesNames.MonedaSistema, vCodigoMoneda, cMisProcedimientos.FormatoFechaGenerico(dtpDOC_FECHA_EMI.Text)))
            vcontrol = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                CambiarMonedaSaldo = ds.Tables(0).Rows(0).Item("TCA_VENTA")
            Else
                CambiarMonedaSaldo = 0
            End If
            Return CambiarMonedaSaldo
        End Function
        Private Sub FiltroAnticipo(ByVal vBoolean As Boolean)
            If pProcesandoProforma Then
                btnAnticipos.Enabled = False
                btnDescuentos.Enabled = False
                btnImpresion.Enabled = False
            Else
                btnAnticipos.Enabled = vBoolean
                btnDescuentos.Enabled = vBoolean
                btnImpresion.Enabled = vBoolean
            End If
        End Sub
        Private Sub FiltroPVE_ID(Optional ByVal vFlag As Boolean = True)
            Dim vLPR_PRINCIPAL As String = ""
            Dim vPVE_ID_DES As String = ""

            If txtPVE_ID_DES.Text.Trim = "" Then
                If vPVE_TIPO = cboDOC_TIPO_LISTA.Text Or _
                   vPVE_TIPO & " - OBRA" = cboDOC_TIPO_LISTA.Text Then
                    If vFlag Then
                        txtPVE_ID_DES.Text = txtPVE_ID.Text
                        vPVE_ID_DES = txtPVE_ID.Text
                    Else
                        vPVE_ID_DES = ""
                    End If
                End If
            Else
                vPVE_ID_DES = txtPVE_ID_DES.Text
            End If
            If cboDOC_TIPO_LISTA.Text = "PLANTA" Or _
               cboDOC_TIPO_LISTA.Text = "PLANTA - OBRA" Then
                vLPR_PRINCIPAL = "'PLANTA','PLANTA - OBRA'"
            Else
                vLPR_PRINCIPAL = "'PUNTO DE VENTA','PUNTO DE VENTA - OBRA'"
            End If
            EtxtLPR_ID.pOOrm.CadenaFiltrado = " And LPR_ID  In (Select LPR_ID From vwPuntoVenta " & _
                                                               "Where PVE_ID='" & vPVE_ID_DES & "') And LPR_PRINCIPAL In (" & vLPR_PRINCIPAL & ") " & _
                                              " And MON_ID='" & BCVariablesNames.MonedaSistema & "'"
            EtxtPVE_ID_DES.pOOrm.CadenaFiltrado = " And PVE_TIPO  In (" & vLPR_PRINCIPAL & ")"
        End Sub
        Private Sub FiltroMON_ID()
            EtxtFLE_ID.pOOrm.CadenaFiltrado = " And PVE_ID='" & txtPVE_ID_DES.Text & "' And FLE_TIPO='" & pFLE_TIPO & "' And MON_ID='" & BCVariablesNames.MonedaSistema & "'"
        End Sub
        Private Sub FiltroPER_ID_CLI()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito
                    EtxtDTD_ID_AFE.pOOrm.CadenaFiltrado = " AND (TDO_ID='" & BCVariablesNames.ProcesosFacturación.VentaBoleta & "' OR TDO_ID='" & BCVariablesNames.ProcesosFacturación.VentaFactura & "' OR TDO_ID='" & BCVariablesNames.ProcesosFacturación.NotaDebito & "' OR TDO_ID='" & BCVariablesNames.ProcesosFacturación.TICKETMAQUINAREGISTRADORA & "')" & _
                          " AND PER_ID_CLI='" & txtPER_ID_CLI.Text & "'"
                Case Else
                    EtxtDTD_ID_AFE.pOOrm.CadenaFiltrado = " AND (TDO_ID='" & BCVariablesNames.ProcesosFacturación.VentaBoleta & "' OR TDO_ID='" & BCVariablesNames.ProcesosFacturación.VentaFactura & "' OR TDO_ID='" & BCVariablesNames.ProcesosFacturación.TICKETMAQUINAREGISTRADORA & "')" & _
                          " AND PER_ID_CLI='" & txtPER_ID_CLI.Text & "'"
            End Select
        End Sub
        Private Sub FiltroART_ID()
            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosFacturación.BoletaAnticipo,
                     BCVariablesNames.ProcesosFacturación.FacturaAnticipo
                    EtxtART_ID_IMP.pOOrm.vLPR_ID1 = pLPR_ID_PrecioEspecialCliente
                    EtxtART_ID_IMP.pOOrm.vLPR_ID2 = txtLPR_ID.Text
                    EtxtART_ID_IMP.pOOrm.vTIP_ID = BCVariablesNames.TipoArticulos.TipoAnticipo
                    EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND MON_ID='" & txtMON_ID.Text & "' "

                    EtxtDDO_PRE_UNI.pOOrm.vLPR_ID1 = pLPR_ID_PrecioEspecialCliente
                    EtxtDDO_PRE_UNI.pOOrm.vLPR_ID2 = txtLPR_ID.Text
                    EtxtDDO_PRE_UNI.pOOrm.vTIP_ID = BCVariablesNames.TipoArticulos.TipoAnticipo
                    EtxtDDO_PRE_UNI.pOOrm.CadenaFiltrado = " AND MON_ID='" & txtMON_ID.Text & "' "

                    'EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND LPR_ID='" & txtLPR_ID.Text & _
                    '                                     "' AND MON_ID='" & BCVariablesNames.MonedaSistema & "' " & _
                    '                                      " AND ART_ID In (SELECT ART_ID FROM vwRolArticulosTipoArticulos WHERE TIP_ID='" & BCVariablesNames.TipoArticulos.TipoAnticipo & "')"
                    FiltroAnticipo(False)
                Case BCVariablesNames.ProcesosFacturación.NCredito,
                     BCVariablesNames.ProcesosFacturación.NDebito

                    EtxtART_ID_IMP.pOOrm.vLPR_ID1 = pLPR_ID_PrecioEspecialCliente
                    EtxtART_ID_IMP.pOOrm.vLPR_ID2 = txtLPR_ID.Text
                    EtxtART_ID_IMP.pOOrm.vTIP_ID = BCVariablesNames.TipoArticulos.TipoProductoTerminado
                    EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND MON_ID='" & txtMON_ID.Text & "' "

                    EtxtDDO_PRE_UNI.pOOrm.vLPR_ID1 = pLPR_ID_PrecioEspecialCliente
                    EtxtDDO_PRE_UNI.pOOrm.vLPR_ID2 = txtLPR_ID.Text
                    EtxtDDO_PRE_UNI.pOOrm.vTIP_ID = BCVariablesNames.TipoArticulos.TipoProductoTerminado
                    EtxtDDO_PRE_UNI.pOOrm.CadenaFiltrado = " AND MON_ID='" & txtMON_ID.Text & "' "

                    'EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND LPR_ID='" & txtLPR_ID.Text & _
                    '                                     "' AND MON_ID='" & BCVariablesNames.MonedaSistema & "' "
                    FiltroAnticipo(False)
                Case BCVariablesNames.ProcesosFacturación.PBBoleta,
                     BCVariablesNames.ProcesosFacturación.PFFactura
                    EtxtART_ID_IMP.pOOrm.vLPR_ID1 = pLPR_ID_PrecioEspecialCliente
                    EtxtART_ID_IMP.pOOrm.vLPR_ID2 = txtLPR_ID.Text
                    EtxtART_ID_IMP.pOOrm.vTIP_ID = BCVariablesNames.TipoArticulos.TipoProductoTerminado
                    EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND MON_ID='" & txtMON_ID.Text & "' "

                    EtxtDDO_PRE_UNI.pOOrm.vLPR_ID1 = pLPR_ID_PrecioEspecialCliente
                    EtxtDDO_PRE_UNI.pOOrm.vLPR_ID2 = txtLPR_ID.Text
                    EtxtDDO_PRE_UNI.pOOrm.vTIP_ID = BCVariablesNames.TipoArticulos.TipoProductoTerminado
                    EtxtDDO_PRE_UNI.pOOrm.CadenaFiltrado = " AND MON_ID='" & txtMON_ID.Text & "' "

                    'If pPrecioEspecialCliente Then
                    '    EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND LPR_ID='" & pLPR_ID_PrecioEspecialCliente & _
                    '                                         "' AND MON_ID='" & BCVariablesNames.MonedaSistema & "' " & _
                    '                                          " AND ART_ID In (SELECT ART_ID FROM vwRolArticulosTipoArticulos WHERE TIP_ID='" & BCVariablesNames.TipoArticulos.TipoProductoTerminado & "')"
                    'Else
                    '    EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND LPR_ID='" & txtLPR_ID.Text & _
                    '                                         "' AND MON_ID='" & BCVariablesNames.MonedaSistema & "' " & _
                    '                                          " AND ART_ID In (SELECT ART_ID FROM vwRolArticulosTipoArticulos WHERE TIP_ID='" & BCVariablesNames.TipoArticulos.TipoProductoTerminado & "')"
                    'End If
                    FiltroAnticipo(False)
                Case Else
                    EtxtART_ID_IMP.pOOrm.vLPR_ID1 = pLPR_ID_PrecioEspecialCliente
                    EtxtART_ID_IMP.pOOrm.vLPR_ID2 = txtLPR_ID.Text
                    EtxtART_ID_IMP.pOOrm.vTIP_ID = BCVariablesNames.TipoArticulos.TipoProductoTerminado
                    EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND MON_ID='" & txtMON_ID.Text & "' "

                    EtxtDDO_PRE_UNI.pOOrm.vLPR_ID1 = pLPR_ID_PrecioEspecialCliente
                    EtxtDDO_PRE_UNI.pOOrm.vLPR_ID2 = txtLPR_ID.Text
                    EtxtDDO_PRE_UNI.pOOrm.vTIP_ID = BCVariablesNames.TipoArticulos.TipoProductoTerminado
                    EtxtDDO_PRE_UNI.pOOrm.CadenaFiltrado = " AND MON_ID='" & txtMON_ID.Text & "' "

                    If pPrecioEspecialCliente Then
                        'EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND LPR_ID='" & pLPR_ID_PrecioEspecialCliente & _
                        '                                     "' AND MON_ID='" & BCVariablesNames.MonedaSistema & "' " & _
                        '                                      " AND ART_ID In (SELECT ART_ID FROM vwRolArticulosTipoArticulos WHERE TIP_ID='" & BCVariablesNames.TipoArticulos.TipoProductoTerminado & "')"
                    Else
                        'EtxtART_ID_IMP.pOOrm.CadenaFiltrado = " AND LPR_ID='" & txtLPR_ID.Text & _
                        '                                     "' AND MON_ID='" & BCVariablesNames.MonedaSistema & "' " & _
                        '                                      " AND ART_ID In (SELECT ART_ID FROM vwRolArticulosTipoArticulos WHERE TIP_ID='" & BCVariablesNames.TipoArticulos.TipoProductoTerminado & "')"
                    End If
                    FiltroAnticipo(True)
            End Select
        End Sub
        Private Sub FiltroDgvDetalle()
            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosFacturación.BoletaAnticipo,
                     BCVariablesNames.ProcesosFacturación.FacturaAnticipo
                    'cDTD_ID_ANT.Visible = False
                    cDDO_SERIE_ANT.Visible = False
                    cDDO_NUMERO_ANT.Visible = False
                Case BCVariablesNames.ProcesosFacturación.NCredito,
                     BCVariablesNames.ProcesosFacturación.NDebito
                    'cDTD_ID_ANT.Visible = False
                    cDDO_SERIE_ANT.Visible = False
                    cDDO_NUMERO_ANT.Visible = False
                Case Else
                    'cDTD_ID_ANT.Visible = True
                    cDDO_SERIE_ANT.Visible = True
                    cDDO_NUMERO_ANT.Visible = True
            End Select
        End Sub
        Private Sub FiltrocboDOC_TIPO_LISTA(Optional ByVal vProcesar As Boolean = True)
            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosFacturación.BoletaAnticipo,
                     BCVariablesNames.ProcesosFacturación.FacturaAnticipo
                    ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, EcboDOC_TIPO_LISTA, True) ' Bloquea
                Case Else
                    If vProcesar Then ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, EcboDOC_TIPO_LISTA, False) ' Desbloquea
            End Select
        End Sub
        Private Sub FiltroDTD_ID_ANT()
            EtxtDTD_ID_ANT.pOOrm.CadenaFiltrado = " AND DTD_ID_REF IN ('" & BCVariablesNames.ProcesosFacturación.FacturaAnticipo & "','" & BCVariablesNames.ProcesosFacturación.BoletaAnticipo & "') " & _
                                                  " AND TDO_ID+DTD_ID+DOC_SERIE+DOC_NUMERO<>'" & txtTDO_ID.Text & txtDTD_ID.Text & txtDOC_SERIE.Text & txtDOC_NUMERO.Text & "' " & _
                                                  " AND PER_ID_CLI='" & txtPER_ID_CLI.Text & "' "
        End Sub
        ' Deshabilitar controles cuando se va a modificar el registro
        Public Sub DeshabilitarModificar()
            If pComportamiento = -1 Then
                cboSerieCorrelativo.Enabled = False
                cboSerieCorrelativo.Visible = False
                cboSerieCorrelativo.Width = 5
                Exit Sub
            End If

            ProcesarGridVacio() ' Deshabilita/Habilita de acuerdo a si el grid esta vacio o no
            DesBloquearBloquearControlesXModificar(True) ' Aca confirmamos los controles inhabilitados siempre que se modifica
        End Sub

        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTIV_ID" Then EtxtTIV_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI" Then EtxtPER_ID_CLI.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDP_ID_CLI" Then EtxtTDP_ID_CLI.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_FIS" Then EtxtDIR_ID_FIS.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_DOM" Then EtxtDIR_ID_DOM.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_COB" Then EtxtDIR_ID_COB.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_ENT" Then EtxtDIR_ID_ENT.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_REC" Then EtxtPER_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDP_ID_REC" Then EtxtTDP_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_ENT_REC" Then EtxtDIR_ID_ENT_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_VEN" Then EtxtPER_ID_VEN.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_COB" Then EtxtPER_ID_COB.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_GRU" Then EtxtPER_ID_GRU.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CON" Then EtxtPER_ID_CON.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_PRO" Then EtxtPER_ID_PRO.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID_DES" Then EtxtPVE_ID_DES.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtLPR_ID" Then EtxtLPR_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtFLE_ID" Then EtxtFLE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCAF_IX_NUMERO_PRO" Then EtxtCAF_IX_NUMERO_PRO.pTexto2 = Me.ActiveControl.Text
                'If Me.ActiveControl.Name.ToString = "txtCAF_IX_ORDEN_COM" Then EtxtCAF_IX_ORDEN_COM.pTexto2 = Me.ActiveControl.Text

                'If Me.ActiveControl.Name.ToString = "txtTDO_ID_AFE" Then EtxtTDO_ID_AFE.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID_AFE" Then EtxtDTD_ID_AFE.pTexto2 = Me.ActiveControl.Text
                'If Me.ActiveControl.Name.ToString = "txtCCT_ID_AFE" Then EtxtCCT_ID_AFE.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTIV_ID" Then EtxtTIV_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI" Then EtxtPER_ID_CLI.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDP_ID_CLI" Then EtxtTDP_ID_CLI.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_FIS" Then EtxtDIR_ID_FIS.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_DOM" Then EtxtDIR_ID_DOM.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_COB" Then EtxtDIR_ID_COB.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_ENT" Then EtxtDIR_ID_ENT.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_REC" Then EtxtPER_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDP_ID_REC" Then EtxtTDP_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_ENT_REC" Then EtxtDIR_ID_ENT_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_VEN" Then EtxtPER_ID_VEN.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_COB" Then EtxtPER_ID_COB.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_GRU" Then EtxtPER_ID_GRU.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CON" Then EtxtPER_ID_CON.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_PRO" Then EtxtPER_ID_PRO.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID_DES" Then EtxtPVE_ID_DES.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtLPR_ID" Then EtxtLPR_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtFLE_ID" Then EtxtFLE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCAF_IX_NUMERO_PRO" Then EtxtCAF_IX_NUMERO_PRO.pTexto2 = Me.ActiveControl.Text

                'If Me.ActiveControl.Name.ToString = "txtCAF_IX_ORDEN_COM" Then EtxtCAF_IX_ORDEN_COM.pTexto2 = Me.ActiveControl.Text

                'If Me.ActiveControl.Name.ToString = "txtTDO_ID_AFE" Then EtxtTDO_ID_AFE.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID_AFE" Then EtxtDTD_ID_AFE.pTexto2 = Me.ActiveControl.Text
                'If Me.ActiveControl.Name.ToString = "txtCCT_ID_AFE" Then EtxtCCT_ID_AFE.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function
        Private Function ProcesarEliminarDetalle() As Int16
            Return EliminarDetalle(Compuesto1)
        End Function
        Private Function EliminarDetalle(ByVal oOrm As DetalleDocumentos) As Int16
            EliminarDetalle = 0

            EliminarDetalle = EliminarKardexCtaCte(vItemKardexCtaCte)
            If EliminarDetalle = 0 Then Return EliminarDetalle

            EliminarDetalle = EliminarKardexCtaCtePercepcion(vItemKardexCtaCtePercepcion)
            If EliminarDetalle = 0 Then Return EliminarDetalle

            EliminarDetalle = EliminarDetalleDespachos(vItemDetalleDespachos)
            If EliminarDetalle = 0 Then Exit Function

            EliminarDetalle = EliminarDetalleAfectaMonto(vItemDetalleAfectaMonto)
            If EliminarDetalle = 0 Then Exit Function

            EliminarDetalle = EliminarDetalleAfectaProducto(vItemDetalleAfectaProducto)
            If EliminarDetalle = 0 Then Exit Function

            Return EliminarDetalle
        End Function
        Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                ConfigurarIndexLectura()
                pPER_FORMA_VENTA = BCVariablesNames.FormaVenta.Ninguno
                pPER_TELEFONOS = ""
                LongitudId = 0
                CaracterId = "0"
                ConfigurarCheck()
                ConfigurarComboBox()
                ConfigurarDataGridView()
                ConfigurarText()
                AdicionarElementoCombosEdicion()
                ComportamientoFormulario()
                ConfigurarGrid("Load")
                If Comportamiento = -1 Then BusquedaDatos("Load")
                FormatearCampos()

                DireccionesAMostrar()
                GestoresAMostrar()

                ConfigurarFormulario(1)

                If pComportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If
                VerificarDatosSession()
                If pDocumentoProcesandose = 1000 Then
                    pnCuerpo.Controls.Remove(txtTIV_DESCRIPCION)
                    pnCuerpo.Controls.Remove(txtDeudaContraentregaCredito123)
                    pnCuerpo.Controls.Remove(txtDeuda)
                    pnCuerpo.Controls.Remove(btnImpresion)

                    Me.Controls.Add(txtTIV_DESCRIPCION)
                    Me.Controls.Add(txtDeudaContraentregaCredito123)
                    Me.Controls.Add(txtDeuda)
                    Me.Controls.Add(btnImpresion)

                    txtTIV_DESCRIPCION.BringToFront()
                    txtTIV_DESCRIPCION.ReadOnly = True
                    txtTIV_DESCRIPCION.Enabled = True
                    txtTIV_DESCRIPCION.Location = New System.Drawing.Point(436, 61)

                    txtDeudaContraentregaCredito123.BringToFront()
                    txtDeudaContraentregaCredito123.ReadOnly = False
                    txtDeudaContraentregaCredito123.Enabled = True
                    txtDeudaContraentregaCredito123.Location = New System.Drawing.Point(205, 225) ' 230 220

                    txtDeuda.BringToFront()
                    txtDeuda.ReadOnly = False
                    txtDeuda.Enabled = True
                    txtDeuda.Location = New System.Drawing.Point(230, 225) ' 230 220

                    btnImpresion.BringToFront()
                    btnImpresion.Enabled = True
                    btnImpresion.Location = New System.Drawing.Point(160, 494) ' 129-494
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load ")
            End Try
        End Sub
        Private Sub GestoresAMostrar()
            RemoverTabs(tcoGestores, tpaCobrador)
            'RemoverTabs(tcoGestores, tpaGrupo)
            RemoverTabs(tcoGestores, tpaContacto)
            tcoGestores.SelectedIndex = 0
            ConfigurarGestores("tpaVendedor")
        End Sub
        Private Sub DireccionesAMostrar()
            RemoverTabs(tcoDirecciones, tpaCobranza)
            RemoverTabs(tcoDirecciones, tpaRecepciona)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.VentaBoleta
                    tcoDirecciones.SelectedIndex = 1
                    RemoverTabs(tcoDirecciones, tpaFiscal)
                    ConfigurarDirecciones("tpaDomicilio")
                Case BCVariablesNames.ProcesosFacturación.VentaFactura
                    tcoDirecciones.SelectedIndex = 0
                    RemoverTabs(tcoDirecciones, tpaDomicilio)
                    ConfigurarDirecciones("tpaFiscal")
            End Select

        End Sub
        Private Sub ConfigurarIndexLectura()
            Dim vTabIndex As Int16 = 0

            ConfigurarTabIndex(txtPVE_ID, vTabIndex)
            ConfigurarTabIndex(txtTDO_ID, vTabIndex)
            ConfigurarTabIndex(txtDTD_ID, vTabIndex)

            ConfigurarTabIndex(cboSerieCorrelativo, vTabIndex)
            ConfigurarTabIndex(txtDOC_SERIE, vTabIndex)
            ConfigurarTabIndex(txtDOC_NUMERO, vTabIndex)

            ConfigurarTabIndex(dtpDOC_FECHA_EMI, vTabIndex)
            ConfigurarTabIndex(dtpDOC_FECHA_ENT, vTabIndex)

            ConfigurarTabIndex(txtMON_ID, vTabIndex)
            ConfigurarTabIndex(txtMON_SIMBOLO, vTabIndex, True)
            ConfigurarTabIndex(txtMON_DESCRIPCION, vTabIndex, True)
            ConfigurarTabIndex(txtTIV_ID, vTabIndex)
            ConfigurarTabIndex(txtTIV_DESCRIPCION, vTabIndex, True)
            ConfigurarTabIndex(txtDOC_IGV_POR, vTabIndex, True)

            ConfigurarTabIndex(txtPER_ID_CLI, vTabIndex)
            ConfigurarTabIndex(txtPER_DESCRIPCION_CLI, vTabIndex, True)
            ConfigurarTabIndex(txtTDP_ID_CLI, vTabIndex)
            ConfigurarTabIndex(txtTDP_DESCRIPCION_CLI, vTabIndex, True)
            ConfigurarTabIndex(txtDOP_NUMERO_CLI, vTabIndex, True)

            ConfigurarTabIndex(txtDIR_ID_FIS, vTabIndex)
            ConfigurarTabIndex(txtDIR_DESCRIPCION_FIS, vTabIndex, True)
            ConfigurarTabIndex(txtDIR_REFERENCIA_FIS, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_ID_FIS, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_DESCRIPCION_FIS, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_ID_FIS, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_DESCRIPCION_FIS, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_ID_FIS, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_DESCRIPCION_FIS, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_ID_FIS, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_DESCRIPCION_FIS, vTabIndex, True)

            ConfigurarTabIndex(txtDIR_ID_DOM, vTabIndex)
            ConfigurarTabIndex(txtDIR_DESCRIPCION_DOM, vTabIndex, True)
            ConfigurarTabIndex(txtDIR_REFERENCIA_DOM, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_ID_DOM, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_DESCRIPCION_DOM, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_ID_DOM, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_DESCRIPCION_DOM, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_ID_DOM, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_DESCRIPCION_DOM, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_ID_DOM, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_DESCRIPCION_DOM, vTabIndex, True)

            ConfigurarTabIndex(txtDIR_ID_COB, vTabIndex)
            ConfigurarTabIndex(txtDIR_DESCRIPCION_COB, vTabIndex, True)
            ConfigurarTabIndex(txtDIR_REFERENCIA_COB, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_ID_COB, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_DESCRIPCION_COB, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_ID_COB, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_DESCRIPCION_COB, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_ID_COB, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_DESCRIPCION_COB, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_ID_COB, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_DESCRIPCION_COB, vTabIndex, True)

            ConfigurarTabIndex(txtDIR_ID_ENT, vTabIndex)
            ConfigurarTabIndex(txtDIR_DESCRIPCION_ENT, vTabIndex, True)
            ConfigurarTabIndex(txtDIR_REFERENCIA_ENT, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_ID_ENT, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_DESCRIPCION_ENT, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_ID_ENT, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_DESCRIPCION_ENT, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_ID_ENT, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_DESCRIPCION_ENT, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_ID_ENT, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_DESCRIPCION_ENT, vTabIndex, True)

            ConfigurarTabIndex(txtPER_ID_REC, vTabIndex)
            ConfigurarTabIndex(txtPER_DESCRIPCION_REC, vTabIndex, True)
            ConfigurarTabIndex(txtTDP_ID_REC, vTabIndex)
            ConfigurarTabIndex(txtTDP_DESCRIPCION_REC, vTabIndex, True)
            ConfigurarTabIndex(txtDOP_NUMERO_REC, vTabIndex, True)

            ConfigurarTabIndex(txtDIR_ID_ENT_REC, vTabIndex)
            ConfigurarTabIndex(txtDIR_DESCRIPCION_ENT_REC, vTabIndex, True)
            ConfigurarTabIndex(txtDIR_REFERENCIA_ENT_REC, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_ID_ENT_REC, vTabIndex, True)
            ConfigurarTabIndex(txtDIS_DESCRIPCION_ENT_REC, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_ID_ENT_REC, vTabIndex, True)
            ConfigurarTabIndex(txtPRO_DESCRIPCION_ENT_REC, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_ID_ENT_REC, vTabIndex, True)
            ConfigurarTabIndex(txtDEP_DESCRIPCION_ENT_REC, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_ID_ENT_REC, vTabIndex, True)
            ConfigurarTabIndex(txtPAI_DESCRIPCION_ENT_REC, vTabIndex, True)

            ConfigurarTabIndex(txtDOC_ORDEN_COMPRA, vTabIndex)
            ConfigurarTabIndex(cboDOC_TIPO_ORDEN_COMPRA, vTabIndex)
            ConfigurarTabIndex(dtpDOC_FECHA_EXP, vTabIndex)

            ConfigurarTabIndex(txtLineaContado, vTabIndex)
            ConfigurarTabIndex(txtDeudaContado, vTabIndex)
            ConfigurarTabIndex(txtDisponibleContado, vTabIndex)

            ConfigurarTabIndex(txtLineaContraentregaCredito123, vTabIndex)
            ConfigurarTabIndex(txtDeudaContraentregaCredito123, vTabIndex)
            ConfigurarTabIndex(txtDisponibleContraentregaCredito123, vTabIndex)

            ConfigurarTabIndex(txtPER_LINEA_CREDITO, vTabIndex)
            ConfigurarTabIndex(txtDeuda, vTabIndex)
            ConfigurarTabIndex(txtDisponible, vTabIndex)

            ConfigurarTabIndex(txtPER_ID_VEN, vTabIndex)
            ConfigurarTabIndex(txtPER_DESCRIPCION_VEN, vTabIndex, True)
            ConfigurarTabIndex(txtPER_ID_COB, vTabIndex)
            ConfigurarTabIndex(txtPER_DESCRIPCION_COB, vTabIndex, True)
            ConfigurarTabIndex(txtPER_ID_GRU, vTabIndex)
            ConfigurarTabIndex(txtPER_DESCRIPCION_GRU, vTabIndex, True)
            ConfigurarTabIndex(txtPER_ID_CON, vTabIndex)
            ConfigurarTabIndex(txtPER_DESCRIPCION_CON, vTabIndex, True)
            ConfigurarTabIndex(txtPER_ID_PRO, vTabIndex)
            ConfigurarTabIndex(txtPER_DESCRIPCION_PRO, vTabIndex, True)

            ConfigurarTabIndex(txtDOC_OBSERVACIONES, vTabIndex)

            ConfigurarTabIndex(cboDOC_TIPO_LISTA, vTabIndex)
            ConfigurarTabIndex(txtPVE_ID_DES, vTabIndex)
            ConfigurarTabIndex(txtPVE_DESCRIPCION_DES, vTabIndex, True)
            ConfigurarTabIndex(txtLPR_ID, vTabIndex)
            ConfigurarTabIndex(txtLPR_DESCRIPCION, vTabIndex, True)

            ConfigurarTabIndex(txtFLE_ID, vTabIndex)
            ConfigurarTabIndex(txtFLE_DESCRIPCION, vTabIndex, True)
            ConfigurarTabIndex(txtDOC_MONTO_FLE, vTabIndex, True)

            ConfigurarTabIndex(txtCCT_ID, vTabIndex, True)
            ConfigurarTabIndex(txtCCT_DESCRIPCION, vTabIndex, True)

            ConfigurarTabIndex(cboDOC_ESTADO, vTabIndex)

            ConfigurarTabIndex(txtCAF_IX_NUMERO_PRO, vTabIndex)
            ConfigurarTabIndex(txtCAF_IX_ORDEN_COM, vTabIndex, True)

            ConfigurarTabIndex(chkDOC_ENTREGADO, vTabIndex)

            ConfigurarTabIndex(chkDOC_ASIENTO, vTabIndex)

            ConfigurarTabIndex(cboDOC_CIERRE, vTabIndex)

            ConfigurarTabIndex(chkDOC_REQUIERE_GUIA, vTabIndex)

            ConfigurarTabIndex(txtTDO_ID_AFE, vTabIndex, True)
            ConfigurarTabIndex(txtDTD_ID_AFE, vTabIndex)
            ConfigurarTabIndex(txtDTD_DESCRIPCION_AFE, vTabIndex)
            ConfigurarTabIndex(txtCCT_ID_AFE, vTabIndex, True)
            ConfigurarTabIndex(txtCCT_DESCRIPCION_AFE, vTabIndex, True)
            ConfigurarTabIndex(txtDOC_SERIE_AFE, vTabIndex, True)
            ConfigurarTabIndex(txtDOC_NUMERO_AFE, vTabIndex, True)

            ConfigurarTabIndex(txtMON_ID_AFE, vTabIndex, True)
            ConfigurarTabIndex(txtMONTO_AFE, vTabIndex, True)

            ConfigurarTabIndex(cboDOC_MOT_EMI, vTabIndex)
            ConfigurarTabIndex(txtDOC_NOMBRE_RECEP, vTabIndex)
            ConfigurarTabIndex(txtDOC_DNI_RECEP, vTabIndex)
            ConfigurarTabIndex(dtpDOC_FEC_RECEP, vTabIndex)

            ConfigurarTabIndex(dgvDetalle, vTabIndex)

            ConfigurarTabIndex(btnAnticipos, vTabIndex)
            ConfigurarTabIndex(txtTotalBruto, vTabIndex, True)
            ConfigurarTabIndex(txtTotDescInc, vTabIndex, True)
            ConfigurarTabIndex(txtExonerado, vTabIndex, True)
            ConfigurarTabIndex(txtBaseImponible, vTabIndex, True)
            ConfigurarTabIndex(txtTotalIGV, vTabIndex, True)
            ConfigurarTabIndex(txtDOC_MONTO_TOTAL, vTabIndex, True)
        End Sub
        Private Sub AdicionarElementoCombosEdicion()
            BuscarFormatos(EcboDOC_TIPO_ORDEN_COMPRA, Compuesto, cboDOC_TIPO_ORDEN_COMPRA, 0)
            BuscarFormatos(EcboDOC_TIPO_LISTA, Compuesto, cboDOC_TIPO_LISTA, 0)
            BuscarFormatos(EcboDOC_CIERRE, Compuesto, cboDOC_CIERRE, 0)
            BuscarFormatos(EcboDOC_ESTADO, Compuesto, cboDOC_ESTADO, 0)
            BuscarFormatos(EcboDOC_MOT_EMI, Compuesto, cboDOC_MOT_EMI, 0)
            FiltrarSeleccionarValidarElementos(1, True)
        End Sub
        Private Function FiltrarSeleccionarValidarElementos(ByVal vProceso As Int16, ByVal vEstado As Boolean) As Boolean
            FiltrarSeleccionarValidarElementos = vEstado
            Select Case vProceso
                Case 1 ' Filtrado 
                    Select Case pTDO_ID
                        'Case BCVariablesNames.ProcesosFacturación.OrdenCompraBoleta, _
                        'BCVariablesNames.ProcesosFacturación.OrdenCompraFactura
                        'cboDOC_ESTADO.Items.Remove("ACTIVO")
                        'cboDOC_ESTADO.Items.Remove("PROCESADO")
                        'cboDOC_TIPO_ORDEN_COMPRA.Items.Remove("NINGUNO")
                        Case BCVariablesNames.ProcesosFacturación.PedidoBoleta, _
                             BCVariablesNames.ProcesosFacturación.PedidoFactura
                            cboDOC_ESTADO.Items.Remove("ACTIVO")
                            cboDOC_ESTADO.Items.Remove("PROCESADO")
                            If pDocumentoProcesandose = 600 Then cboDOC_ESTADO.Items.Remove("POR PROCESAR")
                            Select Case pDTD_ID
                                Case BCVariablesNames.ProcesosFacturación.OrdCompraBoleta, _
                                    BCVariablesNames.ProcesosFacturación.OrdCompraFactura
                                    cboDOC_TIPO_ORDEN_COMPRA.Items.Remove("NINGUNO")
                            End Select
                        Case Else
                            cboDOC_ESTADO.Items.Remove("POR PROCESAR")
                            cboDOC_ESTADO.Items.Remove("PROCESADO")
                    End Select
                Case 2 ' Seleccionar Elemento Default
                    Select Case pTDO_ID
                        'Case BCVariablesNames.ProcesosFacturación.OrdenCompraBoleta, _
                        'BCVariablesNames.ProcesosFacturación.OrdenCompraFactura
                        'cboDOC_TIPO_ORDEN_COMPRA.Text = "REPOSICION"
                        'cboDOC_ESTADO.Text = "POR PROCESAR"
                        Case BCVariablesNames.ProcesosFacturación.PedidoBoleta, _
                             BCVariablesNames.ProcesosFacturación.PedidoFactura
                            Select Case pDTD_ID
                                Case BCVariablesNames.ProcesosFacturación.OrdCompraBoleta, _
                                     BCVariablesNames.ProcesosFacturación.OrdCompraFactura
                                    cboDOC_TIPO_ORDEN_COMPRA.Text = "REPOSICION"
                                    cboDOC_ESTADO.Text = "POR PROCESAR"
                                Case Else
                                    cboDOC_TIPO_ORDEN_COMPRA.Text = "NINGUNO"
                                    cboDOC_ESTADO.Text = "POR PROCESAR"
                            End Select
                        Case Else
                            cboDOC_TIPO_ORDEN_COMPRA.Text = "NINGUNO"
                            cboDOC_ESTADO.Text = "ACTIVO"
                    End Select
                    cboDOC_CIERRE.Text = "ABIERTO"
                Case 3 ' Validar dato seleccionado
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosFacturación.VentaFactura ',
                            'BCVariablesNames.ProcesosFacturación.OrdenCompraFactura
                            FiltrarSeleccionarValidarElementos = ValidarDIR_ID_FIS(FiltrarSeleccionarValidarElementos)
                            FiltrarSeleccionarValidarElementos = ValidarTDO_ID_CLI_FACTURA(FiltrarSeleccionarValidarElementos)
                            FiltrarSeleccionarValidarElementos = ValidarDOC_ORDEN_COMPRA(FiltrarSeleccionarValidarElementos)
                        Case BCVariablesNames.ProcesosFacturación.PedidoFactura
                            FiltrarSeleccionarValidarElementos = ValidarDIR_ID_FIS(FiltrarSeleccionarValidarElementos)
                            FiltrarSeleccionarValidarElementos = ValidarTDO_ID_CLI_FACTURA(FiltrarSeleccionarValidarElementos)
                            Select Case pDTD_ID
                                Case BCVariablesNames.ProcesosFacturación.OrdCompraFactura
                                    FiltrarSeleccionarValidarElementos = ValidarDOC_ORDEN_COMPRA(FiltrarSeleccionarValidarElementos)
                            End Select
                        Case BCVariablesNames.ProcesosFacturación.VentaBoleta ',
                            'BCVariablesNames.ProcesosFacturación.OrdenCompraBoleta
                            FiltrarSeleccionarValidarElementos = ValidarDIR_ID_DOM(FiltrarSeleccionarValidarElementos)
                            FiltrarSeleccionarValidarElementos = ValidarDOC_ORDEN_COMPRA(FiltrarSeleccionarValidarElementos)
                        Case BCVariablesNames.ProcesosFacturación.PedidoBoleta
                            FiltrarSeleccionarValidarElementos = ValidarDIR_ID_DOM(FiltrarSeleccionarValidarElementos)
                            Select Case pDTD_ID
                                Case BCVariablesNames.ProcesosFacturación.OrdCompraBoleta
                                    FiltrarSeleccionarValidarElementos = ValidarDOC_ORDEN_COMPRA(FiltrarSeleccionarValidarElementos)
                            End Select
                        Case Else
                            ErrorProvider1.SetError(txtTDP_ID_CLI, Nothing)
                            ErrorProvider1.SetError(txtDOC_ORDEN_COMPRA, Nothing)
                            FiltrarSeleccionarValidarElementos = vEstado
                    End Select
            End Select
            Return FiltrarSeleccionarValidarElementos
        End Function
        Public Function FiltrarSeleccionarValidarElementosDOC_TIPO_LISTA(ByVal vProceso As Int16, ByVal vEstado As Boolean) As Boolean
            FiltrarSeleccionarValidarElementosDOC_TIPO_LISTA = vEstado

            Dim vcontrol As Int16 = 0
            Dim ds As New DataSet

            Select Case vProceso
                Case 1 ' Filtrado 
                    Dim vPDU_TIPO_LISTA As String = ""
                    Dim vPDU_ENTREGA_PLANTA As String = ""
                    Dim vPDU_ENTREGA_PUNTO_VENTA As String = ""

                    BuscarFormatos(EcboDOC_TIPO_LISTA, Compuesto, cboDOC_TIPO_LISTA, 0)

                    Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spListarPuntoVentaDatosUsuariosUSU_IDXML, SessionService.UserId, txtPVE_ID.Text, Nothing))
                    vcontrol = sr.Peek

                    If vcontrol <> -1 Then
                        ds.ReadXml(sr)
                        vPDU_TIPO_LISTA = ds.Tables(0).Rows(0).Item("PDU_TIPO_LISTA")
                        vPDU_ENTREGA_PLANTA = ds.Tables(0).Rows(0).Item("PDU_ENTREGA_PLANTA")
                        vPDU_ENTREGA_PUNTO_VENTA = ds.Tables(0).Rows(0).Item("PDU_ENTREGA_PUNTO_VENTA")
                    Else
                        vPDU_TIPO_LISTA = ""
                        vPDU_ENTREGA_PLANTA = ""
                        vPDU_ENTREGA_PUNTO_VENTA = ""
                    End If

                    Select Case vPDU_TIPO_LISTA
                        Case BCVariablesNames.PuntoVentaDatosUsuarios.TipoLista.Segun
                            Select Case vPVE_TIPO
                                Case BCVariablesNames.TipoPuntoVenta.Planta
                                    cboDOC_TIPO_LISTA.Items.Remove("PUNTO DE VENTA")
                                    cboDOC_TIPO_LISTA.Items.Remove("PUNTO DE VENTA - OBRA")
                                    Select Case vPDU_ENTREGA_PLANTA
                                        Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Local
                                            cboDOC_TIPO_LISTA.Items.Remove("PLANTA - OBRA")
                                            cboDOC_TIPO_LISTA.Text = "PLANTA"
                                        Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Obra
                                            cboDOC_TIPO_LISTA.Items.Remove("PLANTA")
                                            cboDOC_TIPO_LISTA.Text = "PLANTA - OBRA"
                                        Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Ambos
                                            cboDOC_TIPO_LISTA.Text = "PLANTA"
                                    End Select
                                Case BCVariablesNames.TipoPuntoVenta.Punto
                                    cboDOC_TIPO_LISTA.Items.Remove("PLANTA")
                                    cboDOC_TIPO_LISTA.Items.Remove("PLANTA - OBRA")
                                    Select Case vPDU_ENTREGA_PUNTO_VENTA
                                        Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Local
                                            cboDOC_TIPO_LISTA.Items.Remove("PUNTO DE VENTA - OBRA")
                                            cboDOC_TIPO_LISTA.Text = "PUNTO DE VENTA"
                                        Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Obra
                                            cboDOC_TIPO_LISTA.Items.Remove("PUNTO DE VENTA")
                                            cboDOC_TIPO_LISTA.Text = "PUNTO DE VENTA - OBRA"
                                        Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Ambos
                                            cboDOC_TIPO_LISTA.Text = "PUNTO DE VENTA"
                                    End Select
                            End Select
                        Case BCVariablesNames.PuntoVentaDatosUsuarios.TipoLista.Ambos
                            Select Case vPDU_ENTREGA_PLANTA
                                Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Local
                                    cboDOC_TIPO_LISTA.Items.Remove("PLANTA - OBRA")
                                    cboDOC_TIPO_LISTA.Text = "PLANTA"
                                Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Obra
                                    cboDOC_TIPO_LISTA.Items.Remove("PLANTA")
                                    cboDOC_TIPO_LISTA.Text = "PLANTA - OBRA"
                                Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Ambos
                                    cboDOC_TIPO_LISTA.Text = vDOC_TIPO_LISTA '"PLANTA"
                            End Select
                            Select Case vPDU_ENTREGA_PUNTO_VENTA
                                Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Local
                                    cboDOC_TIPO_LISTA.Items.Remove("PUNTO DE VENTA - OBRA")
                                    cboDOC_TIPO_LISTA.Text = "PUNTO DE VENTA"
                                Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Obra
                                    cboDOC_TIPO_LISTA.Items.Remove("PUNTO DE VENTA")
                                    cboDOC_TIPO_LISTA.Text = "PUNTO DE VENTA - OBRA"
                                Case BCVariablesNames.PuntoVentaDatosUsuarios.Entrega.Ambos
                                    cboDOC_TIPO_LISTA.Text = vDOC_TIPO_LISTA ' "PUNTO DE VENTA"
                            End Select
                    End Select

                    If Not vEstado Then
                        If cboDOC_TIPO_LISTA.FindStringExact(Trim(vDOC_TIPO_LISTA)) > -1 Then
                            cboDOC_TIPO_LISTA.Text = Trim(vDOC_TIPO_LISTA)
                        Else
                            cboDOC_TIPO_LISTA.Items.Add(Trim(vDOC_TIPO_LISTA))
                            cboDOC_TIPO_LISTA.Text = Trim(vDOC_TIPO_LISTA)
                        End If
                    End If
                Case 2 ' Anticipos
                    If txtDTD_ID.Text = BCVariablesNames.ProcesosFacturación.BoletaAnticipo Or _
                       txtDTD_ID.Text = BCVariablesNames.ProcesosFacturación.FacturaAnticipo Then
                        If cboDOC_TIPO_LISTA.FindStringExact(Trim(vPVE_TIPO)) > -1 Then
                            cboDOC_TIPO_LISTA.Text = Trim(vPVE_TIPO)
                        Else
                            cboDOC_TIPO_LISTA.Items.Add(Trim(vPVE_TIPO))
                            cboDOC_TIPO_LISTA.Text = Trim(vPVE_TIPO)
                        End If
                    End If
            End Select
            Return FiltrarSeleccionarValidarElementosDOC_TIPO_LISTA
        End Function
        Private Function ValidarTDO_ID_CLI_FACTURA(ByVal Validado As Boolean) As Boolean
            If txtTDP_ID_CLI.Text <> BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC Then
                ErrorProvider1.SetError(txtTDP_ID_CLI, "El documento de la persona tiene que ser RUC")
                ValidarTDO_ID_CLI_FACTURA = False
            Else
                ErrorProvider1.SetError(txtTDP_ID_CLI, Nothing)
                If Validado Then
                    ValidarTDO_ID_CLI_FACTURA = True
                Else
                    ValidarTDO_ID_CLI_FACTURA = Validado
                End If
            End If
            Return ValidarTDO_ID_CLI_FACTURA
        End Function
        Private Function ValidarDOC_ORDEN_COMPRA(ByVal Validado As Boolean) As Boolean
            If BCVariablesNames.TipoOrdenCompra.Ninguno = cboDOC_TIPO_ORDEN_COMPRA.Text Then
                ErrorProvider1.SetError(txtDOC_ORDEN_COMPRA, Nothing)
                ValidarDOC_ORDEN_COMPRA = Validado
            Else
                If txtDOC_ORDEN_COMPRA.Text.Trim = "" Then
                    ErrorProvider1.SetError(txtDOC_ORDEN_COMPRA, "Debe ingresar la orden de compra del cliente")
                    ValidarDOC_ORDEN_COMPRA = False
                Else
                    ErrorProvider1.SetError(txtDOC_ORDEN_COMPRA, Nothing)
                    'If Validado Then
                    'ValidarDOC_ORDEN_COMPRA = True
                    'Else
                    ValidarDOC_ORDEN_COMPRA = Validado
                    'End If
                End If
            End If
            Return ValidarDOC_ORDEN_COMPRA
        End Function
        Private Function ValidarDIR_ID_FIS(ByVal Validado As Boolean) As Boolean
            If txtDIR_ID_FIS.Text = "" Then
                ErrorProvider1.SetError(txtDIR_ID_FIS, "No ingreso la dirección fiscal")
                ErrorProvider1.SetError(tcoDirecciones, "No ingreso la dirección fiscal")
                ValidarDIR_ID_FIS = False
            Else
                ErrorProvider1.SetError(txtDIR_ID_FIS, Nothing)
                ErrorProvider1.SetError(tcoDirecciones, Nothing)
                If Validado Then
                    ValidarDIR_ID_FIS = True
                Else
                    ValidarDIR_ID_FIS = Validado
                End If
            End If
            Return ValidarDIR_ID_FIS
        End Function
        Private Function ValidarDIR_ID_DOM(ByVal Validado As Boolean) As Boolean
            If txtDIR_ID_DOM.Text = "" Then
                ErrorProvider1.SetError(txtDIR_ID_DOM, "No ingreso la dirección del domicilio")
                ErrorProvider1.SetError(tcoDirecciones, "No ingreso la dirección del domicilio")
                ValidarDIR_ID_DOM = False
            Else
                ErrorProvider1.SetError(txtDIR_ID_DOM, Nothing)
                ErrorProvider1.SetError(tcoDirecciones, Nothing)
                If Validado Then
                    ValidarDIR_ID_DOM = True
                Else
                    ValidarDIR_ID_DOM = Validado
                End If
            End If
            Return ValidarDIR_ID_DOM
        End Function
        Private Sub NombresFormulariosControles()
            FiltrarTabla()

            EtxtPVE_ID.pOOrm = New Ladisac.BE.PuntoVenta
            EtxtPVE_ID.pComportamiento = 2
            EtxtPVE_ID.pOrdenBusqueda = 0
            EtxtPVE_ID.pOOrm.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.PedidoBoleta, _
                    BCVariablesNames.ProcesosFacturación.PedidoFactura
                    EtxtDTD_ID.pOOrm = New Ladisac.BE.DetalleTipoDocumentos
                    EtxtDTD_ID.pComportamiento = 3
                    EtxtDTD_ID.pOrdenBusqueda = 3
                    EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_TABLA='DOCUMENTOS' " & _
                                                      " And TDO_ID In ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & _
                                                                     "','" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "') " & _
                                                      " And DTD_ID In ('" & BCVariablesNames.ProcesosFacturación.PBBoleta & _
                                                                     "','" & BCVariablesNames.ProcesosFacturación.PFFactura & "')"
                Case Else
                    EtxtDTD_ID.pOOrm = New Ladisac.BE.DetalleTipoDocumentos
                    EtxtDTD_ID.pComportamiento = 3
                    EtxtDTD_ID.pOrdenBusqueda = 3
                    EtxtDTD_ID.pOOrm.CadenaFiltrado = " and TDO_TABLA='DOCUMENTOS' and TDO_ID='" & pTDO_ID & "'"
            End Select
            EtxtDTD_ID.pMostrarDatosGrid = True

            EtxtMON_ID.pOOrm = New Ladisac.BE.Moneda
            EtxtMON_ID.pComportamiento = 4
            EtxtMON_ID.pOrdenBusqueda = 0

            EtxtTIV_ID.pOOrm = New Ladisac.BE.TipoVenta
            EtxtTIV_ID.pComportamiento = 5
            EtxtTIV_ID.pOrdenBusqueda = 0
            'EtxtTIV_ID.pOOrm.CadenaFiltrado = " AND (TIV_COMPORTAMIENTO='VENTAS' OR TIV_COMPORTAMIENTO='COMPRAS Y VENTAS') " & _
            '                                  " AND (TIV_FORMA_VENTA='" & pPER_FORMA_VENTA & _
            '                                       "' OR (TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Credito & "'" & _
            '                                             " AND TIV_DESCRIPCION IN ('" & BCVariablesNames.TipoVentaDescripcion.Cobrador & "')" & _
            '                                             ")" & _
            '                                       "  OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Contraentrega & _
            '                                       "' OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Contado & "'" & _
            '                                       ") "
            EtxtTIV_ID.pOOrm.CadenaFiltrado = " AND (TIV_COMPORTAMIENTO='VENTAS' OR TIV_COMPORTAMIENTO='COMPRAS Y VENTAS') " & _
                                              " AND (TIV_FORMA_VENTA='" & pPER_FORMA_VENTA & _
                                                   "' OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Contraentrega & _
                                                   "' OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.ContraentregaEnPlanta & _
                                                   "' OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Contado & "'" & _
                                                   ") "
            EtxtTIV_ID.pMostrarDatosGrid = True

            EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_CLI.pComportamiento = 6
            EtxtPER_ID_CLI.pOrdenBusqueda = 4
            EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " AND PER_CLIENTE='SI'"

            EtxtTDP_ID_CLI.pOOrm = New Ladisac.BE.DocPersonas
            EtxtTDP_ID_CLI.pComportamiento = 7
            EtxtTDP_ID_CLI.pOrdenBusqueda = 4

            EtxtDIR_ID_FIS.pOOrm = New Ladisac.BE.DireccionesPersonas
            EtxtDIR_ID_FIS.pComportamiento = 8
            EtxtDIR_ID_FIS.pOrdenBusqueda = 4
            EtxtDIR_ID_FIS.pOOrm.CadenaFiltrado = " and PER_ID='" & txtPER_ID_CLI.Text & "' AND DIR_TIPO='FISCAL' "
            EtxtDIR_ID_FIS.pMostrarDatosGrid = True

            EtxtDIR_ID_DOM.pOOrm = New Ladisac.BE.DireccionesPersonas
            EtxtDIR_ID_DOM.pComportamiento = 9
            EtxtDIR_ID_DOM.pOrdenBusqueda = 4
            EtxtDIR_ID_DOM.pOOrm.CadenaFiltrado = " and PER_ID='" & txtPER_ID_CLI.Text & "'"
            EtxtDIR_ID_DOM.pMostrarDatosGrid = True

            EtxtDIR_ID_COB.pOOrm = New Ladisac.BE.DireccionesPersonas
            EtxtDIR_ID_COB.pComportamiento = 10
            EtxtDIR_ID_COB.pOrdenBusqueda = 4
            EtxtDIR_ID_COB.pOOrm.CadenaFiltrado = " and PER_ID='" & txtPER_ID_CLI.Text & "'"
            EtxtDIR_ID_COB.pMostrarDatosGrid = True

            EtxtDIR_ID_ENT.pOOrm = New Ladisac.BE.DireccionesPersonas
            EtxtDIR_ID_ENT.pComportamiento = 11
            EtxtDIR_ID_ENT.pOrdenBusqueda = 4
            EtxtDIR_ID_ENT.pOOrm.CadenaFiltrado = " and PER_ID='" & txtPER_ID_CLI.Text & "'"
            EtxtDIR_ID_ENT.pMostrarDatosGrid = True

            EtxtPER_ID_REC.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_REC.pComportamiento = 12
            EtxtPER_ID_REC.pOrdenBusqueda = 0

            EtxtTDP_ID_REC.pOOrm = New Ladisac.BE.DocPersonas
            EtxtTDP_ID_REC.pComportamiento = 13
            EtxtTDP_ID_REC.pOrdenBusqueda = 0

            EtxtDIR_ID_ENT_REC.pOOrm = New Ladisac.BE.DireccionesPersonas
            EtxtDIR_ID_ENT_REC.pComportamiento = 14
            EtxtDIR_ID_ENT_REC.pOrdenBusqueda = 4
            EtxtDIR_ID_ENT_REC.pOOrm.CadenaFiltrado = " and PER_ID='" & txtPER_ID_REC.Text & "'"
            EtxtDIR_ID_ENT_REC.pMostrarDatosGrid = True

            EtxtPER_ID_VEN.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_VEN.pComportamiento = 15
            EtxtPER_ID_VEN.pOrdenBusqueda = 4
            EtxtPER_ID_VEN.pOOrm.CadenaFiltrado = " and PER_ID in (SELECT PER_ID FROM vwRolPersonaTipoPersona WHERE PER_TRABAJADOR='SI' AND TPE_ID='" & pTPE_ID_VEN & "' AND RTP_ESTADO='ACTIVO')"
            EtxtPER_ID_VEN.pMostrarDatosGrid = True

            EtxtPER_ID_COB.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_COB.pComportamiento = 16
            EtxtPER_ID_COB.pOrdenBusqueda = 4
            EtxtPER_ID_COB.pOOrm.CadenaFiltrado = " and PER_ID in (SELECT PER_ID FROM vwRolPersonaTipoPersona WHERE PER_TRABAJADOR='SI' AND TPE_ID='" & pTPE_ID_COB & "' AND RTP_ESTADO='ACTIVO')"
            EtxtPER_ID_COB.pMostrarDatosGrid = True

            EtxtPER_ID_GRU.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_GRU.pComportamiento = 17
            EtxtPER_ID_GRU.pOrdenBusqueda = 4
            EtxtPER_ID_GRU.pOOrm.CadenaFiltrado = " and PER_ID in (SELECT PER_ID FROM vwRolPersonaTipoPersona WHERE PER_GRUPO='SI')"
            EtxtPER_ID_GRU.pMostrarDatosGrid = True

            EtxtPER_ID_CON.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_CON.pComportamiento = 18
            EtxtPER_ID_CON.pOrdenBusqueda = 0

            EtxtPER_ID_PRO.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_PRO.pComportamiento = 19
            EtxtPER_ID_PRO.pOrdenBusqueda = 4
            EtxtPER_ID_PRO.pOOrm.CadenaFiltrado = " and PER_CONTACTO='SI' "

            EtxtPVE_ID_DES.pOOrm = New Ladisac.BE.PuntoVenta
            EtxtPVE_ID_DES.pComportamiento = 20
            EtxtPVE_ID_DES.pOrdenBusqueda = 0

            EtxtLPR_ID.pOOrm = New Ladisac.BE.ListaPreciosArticulos
            EtxtLPR_ID.pComportamiento = 21
            EtxtLPR_ID.pOrdenBusqueda = 0

            EtxtFLE_ID.pOOrm = New Ladisac.BE.DetalleFletesTransporte
            EtxtFLE_ID.pComportamiento = 22
            EtxtFLE_ID.pOrdenBusqueda = 2
            EtxtFLE_ID.pOOrm.CadenaFiltrado = " and FLE_TIPO='" & pFLE_TIPO & "' and MON_ID='" & BCVariablesNames.MonedaSistema & "'"
            EtxtFLE_ID.pMostrarDatosGrid = True

            EtxtCCT_ID.pOOrm = New Ladisac.BE.CtaCte
            EtxtCCT_ID.pComportamiento = 23
            EtxtCCT_ID.pOrdenBusqueda = 0

            EtxtCAF_IX_NUMERO_PRO.pOOrm = New Ladisac.BE.CartaFianza
            EtxtCAF_IX_NUMERO_PRO.pComportamiento = 24
            EtxtCAF_IX_NUMERO_PRO.pOrdenBusqueda = 0

            EtxtART_ID_IMP.pOOrm = New Ladisac.BE.DetalleListaPrecios
            EtxtART_ID_IMP.pComportamiento = 25
            EtxtART_ID_IMP.pOrdenBusqueda = 0
            EtxtART_ID_IMP.pOOrm.pBuscarRegistros = False
            EtxtART_ID_IMP.pOOrm.Vista = "ListaPreciosEspecialPuntoVentaPlanta"
            'EtxtART_ID_IMP.pMostrarDatosGrid = True

            EtxtDTD_ID_AFE.pOOrm = New Ladisac.BE.Documentos
            EtxtDTD_ID_AFE.pComportamiento = 26
            EtxtDTD_ID_AFE.pOrdenBusqueda = 10
            EtxtDTD_ID_AFE.pOOrm.pBuscarRegistros = False
            EtxtDTD_ID_AFE.pOOrm.Vista = "BuscarRegistrosNuevo"
            FiltroPER_ID_CLI()

            EtxtDDO_PRE_UNI.pOOrm = New Ladisac.BE.DetalleListaPrecios
            EtxtDDO_PRE_UNI.pComportamiento = 28
            EtxtDDO_PRE_UNI.pOrdenBusqueda = 0
            EtxtDDO_PRE_UNI.pOOrm.pBuscarRegistros = False
            EtxtDDO_PRE_UNI.pOOrm.Vista = "ListaPreciosEspecialPuntoVentaPlanta"

            'Separado para btnAnticipos
            EtxtDTD_ID_ANT.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
            EtxtDTD_ID_ANT.pComportamiento = 29
            EtxtDTD_ID_ANT.pOrdenBusqueda = 0
            EtxtDTD_ID_ANT.pOOrm.pBuscarRegistros = False
            ''EtxtDTD_ID_ANT.pOOrm.Vista = "VistaSaldoDTD"
            EtxtDTD_ID_ANT.pOOrm.Vista = "VistaSaldoDTDNuevo"
            FiltroDTD_ID_ANT()

            EtxtTDO_ID_PRO.pOOrm = New Ladisac.BE.Documentos
            EtxtTDO_ID_PRO.pComportamiento = 30
            EtxtTDO_ID_PRO.pOrdenBusqueda = 10

            EtxtDTD_ID_DEV.pOOrm = New Ladisac.BE.DetalleDespachos
            EtxtDTD_ID_DEV.pComportamiento = 31
            EtxtDTD_ID_DEV.pOrdenBusqueda = 3
            'EtxtDTD_ID_DEV.pOOrm.CadenaFiltrado = " and TDO_TABLA='DOCUMENTOS' and TDO_ID='" & pTDO_ID & "'"
        End Sub
#Region "CheckBox"
        Private Sub ConfigurarCheck()
            Dim EchkTemporal As New chk

            EchkTemporal.pFormatearTexto = True
            EchkTemporal.vEstado0 = ""
            EchkTemporal.vEstado1 = ""
            EchkTemporal.vEstadoX = ""
            EchkTemporal.pSimple = Compuesto
            EchkTemporal.pValorDefault = CheckState.Indeterminate

            EchkDOC_ENTREGADO = EchkTemporal
            EchkDOC_ENTREGADO.pNombreCampo = "DOC_ENTREGADO"
            EchkDOC_ENTREGADO.pValorDefault = CheckState.Unchecked
            ConfigurarCheck_Refrescar(EchkDOC_ENTREGADO)

            EchkDOC_ASIENTO = EchkTemporal
            EchkDOC_ASIENTO.pNombreCampo = "DOC_ASIENTO"
            EchkDOC_ASIENTO.pValorDefault = CheckState.Unchecked
            ConfigurarCheck_Refrescar(EchkDOC_ASIENTO)

            EchkDOC_REQUIERE_GUIA = EchkTemporal
            EchkDOC_REQUIERE_GUIA.pNombreCampo = "DOC_REQUIERE_GUIA"
            EchkDOC_REQUIERE_GUIA.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkDOC_REQUIERE_GUIA)
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkDOC_ENTREGADO"
                    Compuesto.CampoId = EchkDOC_ENTREGADO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkDOC_ASIENTO"
                    Compuesto.CampoId = EchkDOC_ASIENTO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkDOC_REQUIERE_GUIA"
                    Compuesto.CampoId = EchkDOC_REQUIERE_GUIA.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Compuesto.DevolverTiposCampos()
        End Function
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkDOC_ENTREGADO"
                    vObjetoChk.pValorDefault = EchkDOC_ENTREGADO.pValorDefault
                Case "chkDOC_ASIENTO"
                    vObjetoChk.pValorDefault = EchkDOC_ASIENTO.pValorDefault
                Case "chkDOC_REQUIERE_GUIA"
                    vObjetoChk.pValorDefault = EchkDOC_REQUIERE_GUIA.pValorDefault
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
        Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles chkDOC_ENTREGADO.CheckedChanged, _
                chkDOC_ASIENTO.CheckedChanged, _
                chkDOC_REQUIERE_GUIA.CheckedChanged
            Select Case sender.name.ToString
                Case "chkDOC_ENTREGADO"
                    If EchkDOC_ENTREGADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkDOC_ENTREGADO)
                    End If
                Case "chkDOC_ASIENTO"
                    If EchkDOC_ASIENTO.pFormatearTexto Then
                        InicializarTextoCheck(EchkDOC_ASIENTO)
                    End If
                Case "chkDOC_REQUIERE_GUIA"
                    If EchkDOC_REQUIERE_GUIA.pFormatearTexto Then
                        InicializarTextoCheck(EchkDOC_REQUIERE_GUIA)
                    End If
            End Select
        End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "DOC_ENTREGADO"
                    With chkDOC_ENTREGADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "DOC_ASIENTO"
                    With chkDOC_ASIENTO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "DOC_REQUIERE_GUIA"
                    With chkDOC_REQUIERE_GUIA
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTextoCheck(EchkDOC_ENTREGADO)
            InicializarTextoCheck(EchkDOC_ASIENTO)
            InicializarTextoCheck(EchkDOC_REQUIERE_GUIA)
        End Sub
#End Region

#Region "DataGridView"

        Private Sub dgvDetalleAfectaProducto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles dgvDetalleAfectaProducto.KeyDown
            If dgvDetalleAfectaProducto.RowCount = 0 Then Exit Sub
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                Case "cDTD_ID_DEV"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtDTD_ID_DEV.pBusqueda Then
                                EtxtDTD_ID_DEV.pMostrarDatosGrid = True
                                EtxtDTD_ID_DEV.pOOrm.CadenaFiltrado = " and DTD_ID='014' " & _
                                                                      " and TDO_ID_DOC='" & dgvDetalleAfectaProducto.Item("cTDO_ID_AFP", dgvDetalleAfectaProducto.CurrentRow.Index).Value & "'" & _
                                                                      " and DTD_ID_DOC='" & dgvDetalleAfectaProducto.Item("cDTD_ID_AFP", dgvDetalleAfectaProducto.CurrentRow.Index).Value & "'" & _
                                                                      " and DES_SERIE_DOC='" & dgvDetalleAfectaProducto.Item("cDOC_SERIE_AFP", dgvDetalleAfectaProducto.CurrentRow.Index).Value & "'" & _
                                                                      " and DES_NUMERO_DOC='" & dgvDetalleAfectaProducto.Item("cDOC_NUMERO_AFP", dgvDetalleAfectaProducto.CurrentRow.Index).Value & "'" & _
                                                                      " and ART_ID_KAR='" & dgvDetalleAfectaProducto.Item("cART_IDp", dgvDetalleAfectaProducto.CurrentRow.Index).Value & "'"

                                EtxtDTD_ID_DEV.pTexto2 = dgvDetalleAfectaProducto.Item(dgvDetalleAfectaProducto.CurrentCell.ColumnIndex, dgvDetalleAfectaProducto.CurrentRow.Index).Value
                                MetodoBusquedaDato("", False, EtxtDTD_ID_DEV)
                                EtxtDTD_ID_DEV.pTexto1 = dgvDetalleAfectaProducto.Item(dgvDetalleAfectaProducto.CurrentCell.ColumnIndex, dgvDetalleAfectaProducto.CurrentRow.Index).Value
                                EtxtDTD_ID_DEV.pTexto2 = dgvDetalleAfectaProducto.Item(dgvDetalleAfectaProducto.CurrentCell.ColumnIndex, dgvDetalleAfectaProducto.CurrentRow.Index).Value
                            End If
                    End Select
            End Select
        End Sub


        Private Sub ConfigurarDataGridView()
            EdgvDetalle.pAnchoColumna = 20
            EdgvDetalle.pBloquearPk = True
            EdgvDetalle.pColorColumna = Drawing.Color.Black
            EdgvDetalle.pCampoEstadoRegistro = "cEstadoRegistro"
            EdgvDetalle.pMetodoColumnas = True
            EdgvDetalle.Elementos = 1
            ReDim EdgvDetalle.pArrayCamposPkDetalle(1)
            EdgvDetalle.pArrayCamposPkDetalle(1) = "cART_ID_IMP"

            dgvDetalle.AllowUserToAddRows = False
            dgvDetalle.AllowUserToDeleteRows = False
            dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
                                Or System.Windows.Forms.AnchorStyles.Bottom) _
                                Or System.Windows.Forms.AnchorStyles.Left) _
                                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            dgvDsctoXArticulo.AllowUserToAddRows = False
            dgvDsctoXArticulo.AllowUserToDeleteRows = False
            dgvDsctoXArticulo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
                                Or System.Windows.Forms.AnchorStyles.Bottom) _
                                Or System.Windows.Forms.AnchorStyles.Left) _
                                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDsctoXArticulo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDsctoXArticulo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDsctoXArticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        End Sub
        Private Sub ConfigurarGrid(ByVal vProceso As String)
            Select Case vProceso
                Case "Load"
                    eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
                    eConfigurarDataGridObjeto.Orm = Nothing
                    eConfigurarDataGridObjeto.Array = {0, 1}
                    ConfigurarGrid(dgvDetalle, eConfigurarDataGridObjeto)
                Case "ElementoItem"
                    eConfigurarDataGridObjeto.Metodo = "ElementoItem"
                    eConfigurarDataGridObjeto.Columna = "cItem"
                    ConfigurarGrid(dgvDetalle, eConfigurarDataGridObjeto)
            End Select
        End Sub

        Private Sub dgvDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles dgvDetalle.KeyDown
            If dgvDetalle.RowCount = 0 Then Exit Sub
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID_IMP"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtART_ID_IMP.pBusqueda Then
                                EtxtART_ID_IMP.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                                MetodoBusquedaDato("", False, EtxtART_ID_IMP)
                                EtxtART_ID_IMP.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                                EtxtART_ID_IMP.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                            End If
                    End Select
            End Select
        End Sub
        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDetalle.CellDoubleClick
            If dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name = "cART_ID_IMP" Then
                If EtxtART_ID_IMP.pFormularioConsulta Then
                    'Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmArticulos)()
                    'frmConsulta.DatoBusquedaConsulta = dgvDetalle.CurrentCell.Value
                    'frmConsulta.MaximizeBox = False
                    'frmConsulta.Comportamiento = -1
                    'frmConsulta.ShowDialog()
                End If
            Else
                If EdgvDetalle.pMetodoColumnas Then
                    For Each Elementos In EdgvDetalle.Columnas
                        If dgvDetalle.CurrentCell.ColumnIndex = Elementos Then
                            If dgvDetalle.Columns.Item(dgvDetalle.CurrentCell.ColumnIndex).Width = EdgvDetalle.pAnchoColumna Then
                                dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).DefaultCellStyle.BackColor = Drawing.Color.White
                            Else
                                dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                dgvDetalle.Columns.Item(dgvDetalle.CurrentCell.ColumnIndex).Width = EdgvDetalle.pAnchoColumna
                                dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).DefaultCellStyle.BackColor = EdgvDetalle.pColorColumna
                            End If
                        End If
                    Next
                End If
            End If
        End Sub
        Private Sub dgvDetalle_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDetalle.RowEnter
            If Trim(dgvDetalle.Rows(e.RowIndex).Cells("cDTD_ID_ANT").Value) <> "" Then
                ControlReadOnly(dgvDetalle.Columns("cART_ID_IMP"), True)
                'ControlReadOnly(dgvDetalle.Columns("cDDO_CANTIDAD"), True)
                'ControlReadOnly(dgvDetalle.Columns("cDDO_PRE_UNI"), True)
                'ControlReadOnly(dgvDetalle.Columns("cDDO_DES_INC_PRE"), True)
            Else
                ControlReadOnly(dgvDetalle.Columns("cART_ID_IMP"), False)
                'ControlReadOnly(dgvDetalle.Columns("cDDO_CANTIDAD"), False)
                'ControlReadOnly(dgvDetalle.Columns("cDDO_PRE_UNI"), False)
                'ControlReadOnly(dgvDetalle.Columns("cDDO_DES_INC_PRE"), False)
            End If
            If EdgvDetalle.pBloquearPk Then
                Dim vCampoPk As String = ""
                For elemento As Integer = 1 To EdgvDetalle.pArrayCamposPkDetalle.GetUpperBound(0)
                    vCampoPk = EdgvDetalle.pArrayCamposPkDetalle(elemento).ToString
                    If dgvDetalle.Rows(e.RowIndex).Cells(EdgvDetalle.pCampoEstadoRegistro).Value Is Nothing Then
                    Else
                        If dgvDetalle.Rows(e.RowIndex).Cells(EdgvDetalle.pCampoEstadoRegistro).Value.ToString <> "1" Then
                            ControlReadOnly(dgvDetalle.Columns(vCampoPk), False)
                            EtxtART_ID_IMP.pBusqueda = True
                        Else
                            ControlReadOnly(dgvDetalle.Columns(vCampoPk), True)
                            EtxtART_ID_IMP.pBusqueda = False
                        End If
                    End If
                Next elemento
            End If
            If Trim(dgvDetalle.Rows(e.RowIndex).Cells("cDTD_ID_ANT").Value) <> "" Then
                'ControlReadOnly(dgvDetalle.Columns("cART_ID_IMP"), True)
                ControlReadOnly(dgvDetalle.Columns("cDDO_CANTIDAD"), True)
                ControlReadOnly(dgvDetalle.Columns("cDDO_PRE_UNI"), True)
                'ControlReadOnly(dgvDetalle.Columns("cDDO_DES_INC_PRE"), True)
            Else
                'ControlReadOnly(dgvDetalle.Columns("cART_ID_IMP"), False)
                ControlReadOnly(dgvDetalle.Columns("cDDO_CANTIDAD"), False)
                ControlReadOnly(dgvDetalle.Columns("cDDO_PRE_UNI"), False)
                'ControlReadOnly(dgvDetalle.Columns("cDDO_DES_INC_PRE"), False)
            End If
        End Sub
        Private Sub dgvDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvDetalle.CellEnter
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID_IMP"
                    EtxtART_ID_IMP.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                Case "cDDO_CANTIDAD"
                    EtxtDDO_CANTIDAD.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                Case "cDDO_PRE_UNI"
                    EtxtDDO_PRE_UNI.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                Case "cDDO_DES_INC_PRE"
                    EtxtDDO_DES_INC_PRE.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
            End Select
        End Sub

        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvDetalle.CellValidated
            If Not vFlagDgvDetalle_CellValidated Then Exit Sub
            Dim vtxtLPR_ID As String = txtLPR_ID.Text
            If pPrecioEspecialCliente Then vtxtLPR_ID = pLPR_ID_PrecioEspecialCliente
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID_IMP"
                    EtxtART_ID_IMP.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    ValidarDatos(EtxtART_ID_IMP, "%" & dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value, True, sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtART_ID_IMP.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    EtxtART_ID_IMP.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                Case "cDDO_CANTIDAD"
                    EtxtDDO_CANTIDAD.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    ValidarDatos(EtxtDDO_CANTIDAD, dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value, True, sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtDDO_CANTIDAD.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    EtxtDDO_CANTIDAD.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                Case "cDDO_PRE_UNI"
                    EtxtDDO_PRE_UNI.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    'ValidarDatos(EtxtDDO_PRE_UNI, vtxtLPR_ID & dgvDetalle.Item("cART_ID_IMP", dgvDetalle.CurrentRow.Index).Value, True, sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString)
                    ValidarDatos(EtxtDDO_PRE_UNI, "%" & dgvDetalle.Item("cART_ID_IMP", dgvDetalle.CurrentRow.Index).Value, True, sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtDDO_PRE_UNI.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    EtxtDDO_PRE_UNI.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                Case "cDDO_DES_INC_PRE"
                    EtxtDDO_DES_INC_PRE.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    ValidarDatos(EtxtDDO_DES_INC_PRE, dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value, True, sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtDDO_DES_INC_PRE.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    EtxtDDO_DES_INC_PRE.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
            End Select
        End Sub
        Private Sub ValidarDatos(ByRef otxt As txt, _
                                 ByVal texto As String, _
                                 ByVal BusquedaDirecta As Boolean, _
                                 Optional ByVal NameCampo As String = "")
            If otxt.pTexto1 <> otxt.pTexto2 Then
                If otxt.pBusqueda Then
                    Select Case NameCampo
                        Case "cDDO_PRE_UNI"
                            ConfirmarNumero(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index)
                    End Select

                    MetodoBusquedaDato(texto, BusquedaDirecta, otxt)
                    Select Case NameCampo
                        Case "cART_ID_IMP"
                            ProcesarTotalArticulo(dgvDetalle.CurrentRow.Index, 0)
                        Case "cDDO_PRE_UNI"
                            dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value = ValidarPrecio(dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value)
                            ProcesarTotalArticulo(dgvDetalle.CurrentRow.Index, 0, dgvDetalle.CurrentCell.ColumnIndex)
                    End Select
                End If
                Select Case NameCampo
                    Case "cART_ID_IMP"
                        KeysTab(2)
                    Case "cDDO_CANTIDAD", "cDDO_DES_INC_PRE"
                        ProcesarTotalArticulo(dgvDetalle.CurrentRow.Index, 0, dgvDetalle.CurrentCell.ColumnIndex)
                End Select
            End If
        End Sub

        Private Function ValidarPrecio(ByVal vPrecio As Double) As Double
            'If pDocumentoProcesandose = 600 Then
            '    pDLP_PRECIO_MINIMO = 0
            '    pDLP_RECARGO_ENVIO = 0
            'End If
            If txtFLE_ID.Text.Trim = "" Then
                If vPrecio < pDLP_PRECIO_MINIMO Then
                    Return pDLP_PRECIO_MINIMO
                Else
                    Return vPrecio
                End If
            Else
                If vPrecio < (pDLP_PRECIO_MINIMO + pDLP_RECARGO_ENVIO) Then
                    Return (pDLP_PRECIO_MINIMO + pDLP_RECARGO_ENVIO)
                Else
                    Return vPrecio
                End If
            End If
        End Function
        Private Sub ProcesarTotalArticulo(ByVal vFila As Int16, ByVal vFlagCalcularMonto As Int16, Optional ByVal vCampo As Object = Nothing)
            If Not IsNothing(vCampo) Then ConfirmarNumero(vCampo, vFila)

            If Not IsNothing(vCampo) Then
                Dim vCampoNameTabla As String = ""
                Select Case vCampo
                    Case "5"
                        vCampoNameTabla = "DDO_CANTIDAD"
                    Case "7"
                        vCampoNameTabla = "DDO_DES_INC_PRE"
                    Case "8"
                        vCampoNameTabla = "DDO_PRE_UNI"
                End Select
                dgvDetalle.Item(vCampo, vFila).Value = _
                                FormatearNumeros(dgvDetalle.Item(vCampo, vFila).Value.ToString, vCampoNameTabla, Compuesto1, True)
            End If
            CalcularPrecioTotal(vColPrecioTotal, vFila, _
                           CDbl(dgvDetalle.Item(vColCantidad, vFila).Value), _
                           CDbl(dgvDetalle.Item(vColDescInc, vFila).Value), _
                           CDbl(dgvDetalle.Item(vColPrecio, vFila).Value), _
                           vFlagCalcularMonto)
        End Sub
        Private Sub ConfirmarNumero(ByVal vCampo As Object, ByVal vFila As Int16)
            If IsNothing(dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, vFila).Value) Then
                dgvDetalle.Item(vCampo, vFila).Value = 0
            Else
                If Not IsNumeric(dgvDetalle.Item(vCampo, vFila).Value.ToString) Then
                    dgvDetalle.Item(vCampo, vFila).Value = 0
                End If
            End If
        End Sub
        Private Sub CalcularPrecioTotal(ByVal vColPrecioTotal, _
                                        ByVal vFila, _
                                        ByVal vCantidad, _
                                        ByVal vDescInc, _
                                        ByVal vPrecio, _
                                        ByVal vFlagCalcularMonto)
            Dim vPrecioTemporal As Double = 0
            If vCantidad = 0 Then
                'dgvDetalle.CurrentRow.Index
                dgvDetalle.Item(vColMontoIGV, vFila).Value = 0
                dgvDetalle.Item(vColPrecioTotal, vFila).Value = 0
                'Exit Sub
            Else
                Select Case dgvDetalle.Item(vColIncluyeIGV, vFila).Value
                    Case "NO INCLUYE IGV"
                        vPrecioTemporal = ((vPrecio * vCantidad) + vDescInc) + (((vPrecio * vCantidad) + vDescInc) * SessionService.IGV) / (100)
                        dgvDetalle.Item(vColMontoIGV, vFila).Value = _
                         FormatearNumeros((((vPrecio * vCantidad) + vDescInc) * SessionService.IGV) / (100), "DDO_MONTO_IGV", Compuesto1, True)
                        vDescInc = 0
                    Case "SI INCLUYE IGV"
                        vPrecioTemporal = (vPrecio * vCantidad) + vDescInc
                        CalcularIGV(vFila, (vPrecio * vCantidad) + vDescInc)
                    Case "NO GRABADO CON IGV"
                        vPrecioTemporal = (vPrecio * vCantidad) + vDescInc
                        CalcularIGV(vFila, (vPrecio * vCantidad) + vDescInc)
                End Select
                dgvDetalle.Item(vColPrecioTotal, vFila).Value = _
                    FormatearNumeros(vPrecioTemporal, "DDO_PRE_TOTAL", Compuesto1, True)
            End If
            If vFlagCalcularMonto = 0 Then CalcularMontoDocumento(1)
            '*
        End Sub
        Private Sub CalcularIGV(ByVal vFila, ByVal vPrecio)
            'dgvDetalle.CurrentRow.Index
            Select Case dgvDetalle.Item(vColIncluyeIGV, vFila).Value
                Case "SI INCLUYE IGV"
                    dgvDetalle.Item(vColMontoIGV, vFila).Value = _
                        FormatearNumeros(((vPrecio * SessionService.IGV) / (100 + SessionService.IGV)), "DDO_MONTO_IGV", Compuesto1, True)
                Case "NO GRABADO CON IGV"
                    dgvDetalle.Item(vColMontoIGV, vFila).Value = 0
            End Select
        End Sub
        Private Sub CalcularMontoDocumento(ByVal vControlVerificar As Int16)
            Dim vFilasGrid As Int16 = 0
            Dim vTotalBruto As Double = 0
            Dim vTotDescInc As Double = 0
            Dim vExonerado As Double = 0
            Dim vBaseImponible As Double = 0
            Dim vTotalIGV As Double = 0
            Dim vDoc_Monto_Total As Double = 0
            Dim vDoc_Monto_Percepcion As Double = 0

            vFilasGrid = dgvDetalle.RowCount
            For vFilas = 0 To vFilasGrid - 1
                vTotalBruto += CDbl(dgvDetalle.Item(vColPrecio, vFilas).Value * dgvDetalle.Item(vColCantidad, vFilas).Value)
                vTotDescInc += CDbl(dgvDetalle.Item(vColDescInc, vFilas).Value)
                vTotalIGV += CDbl(dgvDetalle.Item(vColMontoIGV, vFilas).Value)
                'vDoc_Monto_Total += Math.Round(CDbl(dgvDetalle.Item(vColPrecioTotal, vFilas).Value), 2)
                vDoc_Monto_Total += Format(dgvDetalle.Item(vColPrecioTotal, vFilas).Value, "###0.00")


                If dgvDetalle.Item("cART_AFE_PER", vFilas).Value = "SI PERCEPCION" Then
                    'vDoc_Monto_Percepcion += Math.Round(CDbl(dgvDetalle.Item(vColPrecioTotal, vFilas).Value), 2)
                    vDoc_Monto_Percepcion += Format(dgvDetalle.Item(vColPrecioTotal, vFilas).Value, "###0.00")
                End If

                If vControlVerificar = 0 Then VerificarDescuentosBloquearGrid(CDbl(dgvDetalle.Item(vColDescInc, vFilas).Value), dgvDetalle.Item("cTDO_ID_ANT", vFilas).Value)

                If dgvDetalle.Item(vColIncluyeIGV, vFilas).Value.ToString = "NO GRABADO CON IGV" Then
                    vExonerado += (CDbl(dgvDetalle.Item(vColPrecioTotal, vFilas).Value) - CDbl(dgvDetalle.Item(vColMontoIGV, vFilas).Value))
                Else
                    vBaseImponible += (CDbl(dgvDetalle.Item(vColPrecioTotal, vFilas).Value) - CDbl(dgvDetalle.Item(vColMontoIGV, vFilas).Value))
                End If
            Next

            If vEsPersonaAgenteCliente = BCVariablesNames.AgenteCliente.AgenteRetencion1 Then
                txtDOC_MONTO_PERCEPCION.Text = 0
            Else
                If IsNumeric(txtDOC_MONTO_TOTAL.Text) Then txtDOC_MONTO_TOTAL.Text = Format(CDbl(txtDOC_MONTO_TOTAL.Text), "##,###.#0")
                If vDoc_Monto_Total = 0 Or _
                    Val(txtDOC_MONTO_TOTAL.Text) = 0 Then
                    txtDOC_MONTO_PERCEPCION.Text = 0
                Else
                    If SessionService.EmpresaEsAgenteRetenedorPercepcion Then
                        Select Case pDTD_ID
                            Case BCVariablesNames.ProcesosFacturación.Factura, _
                                BCVariablesNames.ProcesosFacturación.FacturaAnticipo, _
                                BCVariablesNames.ProcesosFacturación.PFFactura
                                If vEsPersonaAgenteProveedor = BCVariablesNames.AgenteProveedor.AgentePercepcion1 Then
                                    txtDOC_MONTO_PERCEPCION.Text = (vDoc_Monto_Percepcion * SessionService.PorcentajePercepcionAgentePercepcion) / 100
                                Else
                                    txtDOC_MONTO_PERCEPCION.Text = (vDoc_Monto_Percepcion * SessionService.PorcentajePercepcionGeneral) / 100
                                End If
                            Case BCVariablesNames.ProcesosFacturación.Boleta, _
                                BCVariablesNames.ProcesosFacturación.BoletaAnticipo, _
                                BCVariablesNames.ProcesosFacturación.PBBoleta
                                If vDoc_Monto_Percepcion > SessionService.MontoEnDocumentoVentaParaPercepcion Then
                                    If vEsPersonaAgenteProveedor = BCVariablesNames.AgenteProveedor.AgentePercepcion1 Then
                                        txtDOC_MONTO_PERCEPCION.Text = (vDoc_Monto_Percepcion * SessionService.PorcentajePercepcionAgentePercepcion) / 100
                                    Else
                                        txtDOC_MONTO_PERCEPCION.Text = (vDoc_Monto_Percepcion * SessionService.PorcentajePercepcionGeneral) / 100
                                    End If
                                Else
                                    txtDOC_MONTO_PERCEPCION.Text = 0
                                End If
                            Case Else
                                txtDOC_MONTO_PERCEPCION.Text = 0
                        End Select
                    Else
                        txtDOC_MONTO_PERCEPCION.Text = 0
                    End If
                End If
            End If

            txtTotalBruto.Text = vTotalBruto
            txtTotDescInc.Text = vTotDescInc
            txtExonerado.Text = vExonerado
            txtBaseImponible.Text = vBaseImponible
            txtTotalIGV.Text = vTotalIGV
            txtDOC_MONTO_TOTAL.Text = vDoc_Monto_Total
            txtDOC_VENTA_PERCEPCION.Text = vDoc_Monto_Percepcion
            PresentacionNumeros(999)
        End Sub
        'Public Sub VerificarMontoPercepcion()
        'Dim vFilasGrid As Int16 = 0
        'Dim vDoc_Monto_Total As Double = 0

        'vFilasGrid = dgvDetalle.RowCount
        'For vFilas = 0 To vFilasGrid - 1
        '    vDoc_Monto_Total += CDbl(dgvDetalle.Item(vColPrecioTotal, vFilas).Value)
        'Next

        'If vDoc_Monto_Total >= SessionService.MontoEnDocumentoVentaParaPercepcion Then
        '    txtDOC_MONTO_PERCEPCION.Text = (vDoc_Monto_Total * SessionService.PorcentajePercepcionGeneral) / 100
        'Else
        '    txtDOC_MONTO_PERCEPCION.Text = 0
        'End If
        'End Sub
        Private Sub VerificarDescuentosBloquearGrid(ByVal vMontoDescuento As Double, ByVal vTDO_ID_ANT As String)
            If vMontoDescuento <> 0 Then 'And
                'Trim(vTDO_ID_ANT) = "" Then
                DeshabilitarProcesarDescuentos(False, True)
            End If
        End Sub
#End Region

#Region "DateTimePicker"
        Private Sub ConfigurarDateTimePicker()
            Dim EdtpTemporal As New dtp
            EdtpTemporal.pNombreCampo = "DOC_FECHA_EMI"
            EdtpTemporal.pEnabled = False
            EdtpTemporal.pBusqueda = False
            EdtpTemporal.pFormat = DateTimePickerFormat.Short
            EdtpDOC_FECHA_EMI = EdtpTemporal
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
            EtxtTemporal.pEnabled = True
            EtxtTemporal.pCadenaFiltrado = ""
            EtxtTemporal.pOOrm = Nothing
            EtxtTemporal.pFormularioConsulta = False
            EtxtTemporal.pComportamiento = Nothing
            EtxtTemporal.pOrdenBusqueda = 0
            EtxtTemporal.pMostrarDatosGrid = False

            EtxtPVE_ID = EtxtTemporal
            EtxtDTD_ID = EtxtTemporal
            EtxtDOC_SERIE = EtxtTemporal
            EtxtDOC_NUMERO = EtxtTemporal
            EtxtMON_ID = EtxtTemporal
            EtxtTIV_ID = EtxtTemporal
            EtxtPER_ID_CLI = EtxtTemporal
            EtxtTDP_ID_CLI = EtxtTemporal
            EtxtDIR_ID_FIS = EtxtTemporal
            EtxtDIR_ID_DOM = EtxtTemporal
            EtxtDIR_ID_COB = EtxtTemporal
            EtxtDIR_ID_ENT = EtxtTemporal
            EtxtPER_ID_REC = EtxtTemporal
            EtxtTDP_ID_REC = EtxtTemporal
            EtxtDIR_ID_ENT_REC = EtxtTemporal
            EtxtDOC_ORDEN_COMPRA = EtxtTemporal
            EtxtPER_ID_VEN = EtxtTemporal
            EtxtPER_ID_COB = EtxtTemporal
            EtxtPER_ID_GRU = EtxtTemporal
            EtxtPER_ID_CON = EtxtTemporal
            EtxtPER_ID_PRO = EtxtTemporal
            EtxtPVE_ID_DES = EtxtTemporal
            EtxtDOC_OBSERVACIONES = EtxtTemporal
            EtxtLPR_ID = EtxtTemporal
            EtxtFLE_ID = EtxtTemporal
            EtxtCCT_ID = EtxtTemporal
            EtxtCAF_IX_NUMERO_PRO = EtxtTemporal
            EtxtDOC_MONTO_TOTAL = EtxtTemporal
            EtxtDOC_CONTRAVALOR = EtxtTemporal
            EtxtDOC_IGV_POR = EtxtTemporal

            EtxtDTD_ID_AFE = EtxtTemporal

            EtxtART_ID_IMP = EtxtTemporal
            EtxtART_ID_ANT = EtxtTemporal
            EtxtDDO_CANTIDAD = EtxtTemporal
            EtxtDDO_PRE_UNI = EtxtTemporal
            EtxtDDO_DES_INC_PRE = EtxtTemporal
            EtxtDTD_ID_ANT = EtxtTemporal

            EtxtTDO_ID_PRO = EtxtTemporal

            EtxtDTD_ID_DEV = EtxtTemporal

            EstablecerBuscadores(EtxtPVE_ID)
            EstablecerBuscadores(EtxtDTD_ID)
            EstablecerBuscadores(EtxtMON_ID)
            EstablecerBuscadores(EtxtTIV_ID)
            EstablecerBuscadores(EtxtPER_ID_CLI)
            EstablecerBuscadores(EtxtTDP_ID_CLI)
            EstablecerBuscadores(EtxtDIR_ID_FIS)
            EstablecerBuscadores(EtxtDIR_ID_DOM)
            EstablecerBuscadores(EtxtDIR_ID_COB)
            EstablecerBuscadores(EtxtDIR_ID_ENT)
            EstablecerBuscadores(EtxtPER_ID_REC)
            EstablecerBuscadores(EtxtTDP_ID_REC)
            EstablecerBuscadores(EtxtDIR_ID_ENT_REC)
            EstablecerBuscadores(EtxtPER_ID_VEN)
            EstablecerBuscadores(EtxtPER_ID_COB)
            EstablecerBuscadores(EtxtPER_ID_GRU)
            EstablecerBuscadores(EtxtPER_ID_CON)
            EstablecerBuscadores(EtxtPER_ID_PRO)
            EstablecerBuscadores(EtxtPVE_ID_DES)
            EstablecerBuscadores(EtxtLPR_ID)
            EstablecerBuscadores(EtxtFLE_ID)
            EstablecerBuscadores(EtxtCCT_ID)
            EstablecerBuscadores(EtxtCAF_IX_NUMERO_PRO)
            EstablecerBuscadores(EtxtDTD_ID_AFE)

            EstablecerBuscadores(EtxtART_ID_IMP)
            EstablecerBuscadores(EtxtDDO_PRE_UNI)
            EstablecerBuscadores(EtxtDTD_ID_ANT)
            EstablecerBuscadores(EtxtART_ID_ANT, True, False)

            EstablecerBuscadores(EtxtTDO_ID_PRO, True, False)

            EstablecerBuscadores(EtxtDTD_ID_DEV, True, False)
        End Sub
        Private Sub EstablecerBuscadores(ByRef Etxt As txt, _
                                         Optional ByVal Busqueda As Boolean = True, _
                                         Optional ByVal FormularioConsulta As Boolean = True)
            Etxt.pBusqueda = Busqueda
            Etxt.pFormularioConsulta = FormularioConsulta
        End Sub
        Private Sub MascaraCamposText(ByRef oTexto As TextBox)
            Select Case oTexto.Name
                Case "txtDOC_NUMERO"
                    If Not IsNumeric(oTexto.Text) Then
                        oTexto.Text = ""
                    Else
                        If Strings.InStr(txtDOC_NUMERO.Text, ".") = 0 Then
                            oTexto.Text = Strings.StrDup(10 - Len(oTexto.Text.Trim), "0") & oTexto.Text.Trim
                        Else
                            oTexto.Text = ""
                        End If

                    End If
            End Select
        End Sub
        Private Sub TeclaF1SubLlamadas(ByVal vNametxt As String)
            Select Case vNametxt
                Case "txtPVE_ID"
                    BuscarSeries()
                    LlamadasPVE_ID()
                Case "txtDTD_ID"
                    BuscarSeries()
                Case "txtMON_ID"
                    MetodoBusquedaDato(txtFLE_ID.Text.Trim, True, EtxtFLE_ID)
                Case "txtPER_ID_CLI"
                    If pBusquedaDevolvioDatos Then
                        MetodoBusquedaDato(txtPER_ID_CLI.Text.Trim & pTDP_ID_CLI, True, EtxtTDP_ID_CLI)
                        LlamadasPER_ID_CLI()
                    End If
                Case "txtTDP_ID_CLI"
                    If txtPER_DESCRIPCION_CLI.Text.Trim = "" Then
                        If pBusquedaDevolvioDatos Then
                            MetodoBusquedaDato(txtPER_ID_CLI.Text.Trim, True, EtxtPER_ID_CLI)
                            LlamadasPER_ID_CLI()
                        End If
                    End If
                Case "txtPER_ID_REC"
                    If pBusquedaDevolvioDatos Then
                        MetodoBusquedaDato(txtPER_ID_REC.Text.Trim & pTDP_ID_REC, True, EtxtTDP_ID_REC)
                        LlamadasPER_ID_REC()
                    End If
                Case "txtTDP_ID_REC"
                    If txtPER_DESCRIPCION_REC.Text.Trim = "" Then
                        MetodoBusquedaDato(txtPER_ID_REC.Text.Trim, True, EtxtPER_ID_REC)
                        LlamadasPER_ID_REC()
                    End If
                Case "txtPVE_ID_DES"
                    MetodoBusquedaDato(txtLPR_ID.Text.Trim, True, EtxtLPR_ID)
                    MetodoBusquedaDato(txtFLE_ID.Text.Trim, True, EtxtFLE_ID)
            End Select
        End Sub
        Private Sub LlamadasPVE_ID()
            Select Case txtPVE_ID.Text
                Case BCVariablesNames.PuntosVentaArequipa.Apacheta, _
                    BCVariablesNames.PuntosVentaArequipa.CerroColorado, _
                    BCVariablesNames.PuntosVentaArequipa.ConoNorte, _
                    BCVariablesNames.PuntosVentaArequipa.MariscalCastilla
                    Select Case cboDOC_TIPO_LISTA.Text
                        Case "PLANTA", "PLANTA - OBRA"
                            txtPVE_ID_DES.Text = BCVariablesNames.PuntosVentaPlanta.Principal
                        Case "PUNTO DE VENTA", "PUNTO DE VENTA - OBRA"
                            txtPVE_ID_DES.Text = txtPVE_ID.Text
                    End Select
                Case Else
            End Select
            MetodoBusquedaDato(txtPVE_ID_DES.Text.Trim, True, EtxtPVE_ID_DES)
            MetodoBusquedaDato(txtLPR_ID.Text.Trim, True, EtxtLPR_ID)
            MetodoBusquedaDato(txtFLE_ID.Text.Trim, True, EtxtFLE_ID)
        End Sub
        Private Sub LlamadasPER_ID_CLI()
            VerificarTipoVenta()
            VerificarDireccionesCliente()
            VerificarGestores()
        End Sub
        Private Sub LlamadasPER_ID_REC()
            MetodoBusquedaDato(Me.IBCBusqueda.CodigoDireccionPersona(txtPER_ID_REC.Text, pEntrega), True, EtxtDIR_ID_ENT_REC)
        End Sub
#End Region

#End Region

#Region "Secundaria 2"
        Private Sub FormatearCampos()
            FormatearCampos(txtPVE_ID, "PVE_ID", EtxtPVE_ID)
            FormatearCampos(txtDTD_ID, "DTD_ID", EtxtDTD_ID)
            FormatearCampos(txtDOC_SERIE, "DOC_SERIE", EtxtDOC_SERIE)
            FormatearCampos(txtDOC_NUMERO, "DOC_NUMERO", EtxtDOC_NUMERO, False)
            FormatearCampos(txtMON_ID, "MON_ID", EtxtMON_ID)
            FormatearCampos(txtTIV_ID, "TIV_ID", EtxtTIV_ID)
            FormatearCampos(txtPER_ID_CLI, "PER_ID_CLI", EtxtPER_ID_CLI)
            FormatearCampos(txtTDP_ID_CLI, "TDP_ID_CLI", EtxtTDP_ID_CLI)
            FormatearCampos(txtDIR_ID_FIS, "DIR_ID_FIS", EtxtDIR_ID_FIS, False)
            FormatearCampos(txtDIR_ID_DOM, "DIR_ID_DOM", EtxtDIR_ID_DOM, False)
            FormatearCampos(txtDIR_ID_COB, "DIR_ID_COB", EtxtDIR_ID_COB, False)
            FormatearCampos(txtDIR_ID_ENT, "DIR_ID_ENT", EtxtDIR_ID_ENT, False)
            FormatearCampos(txtPER_ID_REC, "PER_ID_REC", EtxtPER_ID_REC)
            FormatearCampos(txtTDP_ID_REC, "TDP_ID_REC", EtxtTDP_ID_REC)
            FormatearCampos(txtDIR_ID_ENT_REC, "DIR_ID_ENT_REC", EtxtDIR_ID_ENT_REC, False)
            FormatearCampos(txtDOC_ORDEN_COMPRA, "DOC_ORDEN_COMPRA", EtxtDOC_ORDEN_COMPRA)
            FormatearCampos(cboDOC_TIPO_ORDEN_COMPRA, "DOC_TIPO_ORDEN_COMPRA", Nothing)
            FormatearCampos(txtDOC_OBSERVACIONES, "DOC_OBSERVACIONES", EtxtDOC_OBSERVACIONES)
            FormatearCampos(txtPER_ID_VEN, "PER_ID_VEN", EtxtPER_ID_VEN)
            FormatearCampos(txtPER_ID_COB, "PER_ID_COB", EtxtPER_ID_COB)
            FormatearCampos(txtPER_ID_GRU, "PER_ID_GRU", EtxtPER_ID_GRU)
            FormatearCampos(txtPER_ID_CON, "PER_ID_CON", EtxtPER_ID_CON)
            FormatearCampos(txtPER_ID_PRO, "PER_ID_PRO", EtxtPER_ID_PRO)
            FormatearCampos(cboDOC_TIPO_LISTA, "DOC_TIPO_LISTA", Nothing)
            FormatearCampos(txtFLE_ID, "PVE_ID_DES", EtxtPVE_ID_DES)
            FormatearCampos(txtFLE_ID, "LPR_ID", EtxtLPR_ID)
            FormatearCampos(txtFLE_ID, "FLE_ID", EtxtFLE_ID)
            FormatearCampos(txtCCT_ID, "CCT_ID", EtxtCCT_ID)
            FormatearCampos(cboDOC_ESTADO, "DOC_ESTADO", Nothing)
            FormatearCampos(cboDOC_CIERRE, "DOC_CIERRE", Nothing)
            FormatearCampos(txtDOC_MONTO_TOTAL, "DOC_MONTO_TOTAL", EtxtDOC_MONTO_TOTAL, False)

            'FormatearCampos(txtDOC_IGV_POR, "DOC_IGV_POR", EtxtDOC_IGV_POR)
            'FormatearCampos(txtTDO_ID_AFE, "TDO_ID_AFE", EtxtTDO_ID_AFE)
            FormatearCampos(txtDTD_ID_AFE, "DTD_ID_AFE", EtxtDTD_ID_AFE)
            'FormatearCampos(txtCCT_ID_AFE, "CCT_ID_AFE", EtxtCCT_ID_AFE)
            FormatearCampos(txtDOC_SERIE_AFE, "DOC_SERIE_AFE", EtxtDOC_SERIE_AFE)
            FormatearCampos(txtDOC_NUMERO_AFE, "DOC_NUMERO_AFE", EtxtDOC_NUMERO_AFE, False)
            FormatearCampos(cboDOC_MOT_EMI, "DOC_MOT_EMI", Nothing)
            FormatearCampos(txtDOC_NOMBRE_RECEP, "DOC_NOMBRE_RECEP", EtxtDOC_NOMBRE_RECEP, False)
            FormatearCampos(txtDOC_DNI_RECEP, "DNI_RECEP", EtxtDOC_DNI_RECEP, False)
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object,
                                   ByVal NombreCampo As String,
                                   ByRef sender As txt,
                                   Optional ByVal e As System.Boolean = True)
            FormatearCampos(oObjeto, NombreCampo, Compuesto.vArrayDatosComboBox, Compuesto.vElementosDatosComboBox - 1, sender, e)
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

        Private Function BloquearBusquedaCampos(ByVal vtxt As txt, Optional ByVal vMensaje As Boolean = True) As Boolean
            BloquearBusquedaCampos = False
            If vtxt.pOOrm.cTabla.NombreCorto = "Moneda" Then
                If dgvDetalle.RowCount > 0 Then
                    BloquearBusquedaCampos = True
                    If vMensaje Then MsgBox("No se puede cambiar la moneda" & Chr(13) & "si la grilla posee registros", MsgBoxStyle.Information, Me.Text)
                End If
            ElseIf vtxt.pOOrm.cTabla.NombreCorto = "DireccionesPersonas" Then
                Select Case vtxt.pComportamiento
                    Case 14
                        If Trim(txtPER_ID_REC.Text) = "" Then
                            BloquearBusquedaCampos = True
                            'ErrorProvider1.SetError(txtPER_ID_REC, "Debe ingresar el código del cliente que recepciona, para poder seleccionar una dirección.")
                            'ErrorProvider1.SetError(tcoDirecciones, "Error en tab ''Persona que recepciona''.")
                        Else
                            BloquearBusquedaCampos = False
                            'ErrorProvider1.SetError(txtPER_ID_REC, Nothing)
                            'ErrorProvider1.SetError(tcoDirecciones, Nothing)
                        End If

                    Case Else
                        If Trim(txtPER_ID_CLI.Text) = "" Then
                            BloquearBusquedaCampos = True
                            ErrorProvider1.SetError(txtPER_ID_CLI, "Debe ingresar el código del cliente, para poder seleccionar/crear/modificar una dirección.")
                        Else
                            BloquearBusquedaCampos = False
                            ErrorProvider1.SetError(txtPER_ID_CLI, Nothing)
                        End If
                End Select
            End If
            Return BloquearBusquedaCampos
        End Function

        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 3 'DetalleTipoDocumentos
                    OrdenBusquedaDirecta = 2
                Case 6 ' Personas - Clientes
                    OrdenBusquedaDirecta = 0
                Case 8, 9, 10, 11, 14 ' DireccionesPersonas
                    OrdenBusquedaDirecta = 0
                Case 15, 16, 17, 19 ' Vendedor, Cobrador, Grupo, Contacto (Promotor)
                    OrdenBusquedaDirecta = 0
                Case 22 ' DetalleFleteTransporte
                    OrdenBusquedaDirecta = 1
                Case 25 ' Articulo impresión
                    OrdenBusquedaDirecta = 0
                Case 27 ' SaldosKardexDocumentos 
                    OrdenBusquedaDirecta = 8
                Case 30 ' Documentos - Pedidos
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function

#Region "ComboBox"
        Private Sub ConfigurarComboBox()
            Dim Ecbo As New cbo
            Ecbo.pEnabled = True
            Ecbo.pStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboDOC_TIPO_ORDEN_COMPRA = Ecbo
            EcboDOC_TIPO_LISTA = Ecbo
            EcboDOC_ESTADO = Ecbo
            EcboDOC_CIERRE = Ecbo
            EcboDOC_MOT_EMI = Ecbo

            EcboDOC_TIPO_ORDEN_COMPRA.pNombreCampo = "DOC_TIPO_ORDEN_COMPRA"
            cboDOC_TIPO_ORDEN_COMPRA.DropDownStyle = Ecbo.pStyle

            EcboDOC_TIPO_LISTA.pNombreCampo = "DOC_TIPO_LISTA"
            cboDOC_TIPO_LISTA.DropDownStyle = Ecbo.pStyle

            EcboDOC_ESTADO.pNombreCampo = "DOC_ESTADO"
            cboDOC_ESTADO.DropDownStyle = Ecbo.pStyle

            EcboDOC_CIERRE.pNombreCampo = "DOC_CIERRE"
            cboDOC_CIERRE.DropDownStyle = Ecbo.pStyle

            EcboDOC_MOT_EMI.pNombreCampo = "DOC_MOT_EMI"
            cboDOC_MOT_EMI.DropDownStyle = Ecbo.pStyle
        End Sub
#End Region

#Region "TextBox"
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtDTD_ID.GotFocus, _
            txtPVE_ID.GotFocus, _
            txtMON_ID.GotFocus, _
            txtTIV_ID.GotFocus, _
            txtPER_ID_CLI.GotFocus, _
            txtTDP_ID_CLI.GotFocus, _
            txtDIR_ID_FIS.GotFocus, _
            txtDIR_ID_DOM.GotFocus, _
            txtDIR_ID_COB.GotFocus, _
            txtDIR_ID_ENT.GotFocus, _
            txtPER_ID_REC.GotFocus, _
            txtTDP_ID_REC.GotFocus, _
            txtDIR_ID_ENT_REC.GotFocus, _
            txtPER_ID_VEN.GotFocus, _
            txtPER_ID_COB.GotFocus, _
            txtPER_ID_GRU.GotFocus, _
            txtPER_ID_CON.GotFocus, _
            txtPER_ID_PRO.GotFocus, _
            txtPVE_ID_DES.GotFocus, _
            txtLPR_ID.GotFocus, _
            txtFLE_ID.GotFocus, _
            txtCCT_ID.GotFocus, _
            txtCAF_IX_NUMERO_PRO.GotFocus, _
            txtDTD_ID_AFE.GotFocus ', _
            'dtpDOC_FECHA_EMI.GotFocus, _
            'cboDOC_TIPO_LISTA.GotFocus

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto1 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto1 = sender.text
                Case "txtMON_ID"
                    'If BloquearBusquedaCampos(EtxtMON_ID, False) Then
                    'ControlReadOnly(txtMON_ID, True)
                    'Else
                    'ControlReadOnly(txtMON_ID, False)
                    'End If
                    EtxtMON_ID.pTexto1 = sender.text
                Case "txtTIV_ID"
                    EtxtTIV_ID.pTexto1 = sender.text
                Case "txtPER_ID_CLI"
                    EtxtPER_ID_CLI.pTexto1 = sender.text
                Case "txtTDP_ID_CLI"
                    EtxtTDP_ID_CLI.pTexto1 = sender.text
                Case "txtDIR_ID_FIS"
                    EtxtDIR_ID_FIS.pTexto1 = sender.text
                Case "txtDIR_ID_DOM"
                    EtxtDIR_ID_DOM.pTexto1 = sender.text
                Case "txtDIR_ID_COB"
                    EtxtDIR_ID_COB.pTexto1 = sender.text
                Case "txtDIR_ID_ENT"
                    EtxtDIR_ID_ENT.pTexto1 = sender.text
                Case "txtPER_ID_REC"
                    EtxtPER_ID_REC.pTexto1 = sender.text
                Case "txtTDP_ID_REC"
                    EtxtTDP_ID_REC.pTexto1 = sender.text
                Case "txtDIR_ID_ENT_REC"
                    EtxtDIR_ID_ENT_REC.pTexto1 = sender.text
                Case "txtPER_ID_VEN"
                    EtxtPER_ID_VEN.pTexto1 = sender.text
                Case "txtPER_ID_COB"
                    EtxtPER_ID_COB.pTexto1 = sender.text
                Case "txtPER_ID_GRU"
                    EtxtPER_ID_GRU.pTexto1 = sender.text
                Case "txtPER_ID_CON"
                    EtxtPER_ID_CON.pTexto1 = sender.text
                Case "txtPER_ID_PRO"
                    EtxtPER_ID_PRO.pTexto1 = sender.text
                Case "txtPVE_ID_DES"
                    EtxtPVE_ID_DES.pTexto1 = sender.text
                Case "txtLPR_ID"
                    EtxtLPR_ID.pTexto1 = sender.text
                Case "txtFLE_ID"
                    EtxtFLE_ID.pTexto1 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto1 = sender.text
                Case "txtCAF_IX_NUMERO_PRO"
                    EtxtCAF_IX_NUMERO_PRO.pTexto1 = sender.text
                Case "txtDTD_ID_AFE"
                    EtxtDTD_ID_AFE.pTexto1 = sender.text

                    'Case "dtpDOC_FECHA_EMI"
                    'If BloquearBusquedaCampos(EtxtMON_ID, False) Then
                    ''ControlEnabled(dtpDOC_FECHA_EMI, False)
                    '    ConfigurarReadOnlyNoBusqueda(dtpDOC_FECHA_EMI, Nothing, True)
                    'Else
                    ''ControlEnabled(dtpDOC_FECHA_EMI, True)
                    '    ConfigurarReadOnlyNoBusqueda(dtpDOC_FECHA_EMI, Nothing, False)
                    'End If
                    'Case "cboDOC_TIPO_LISTA"
                    'If BloquearBusquedaCampos(EtxtMON_ID, False) Then
                    'ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, Nothing, True)
                    'Else
                    'ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, Nothing, False)
                    'End If
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.LostFocus, _
            txtDTD_ID.LostFocus, _
            txtMON_ID.LostFocus, _
            txtTIV_ID.LostFocus, _
            txtPER_ID_CLI.LostFocus, _
            txtTDP_ID_CLI.LostFocus, _
            txtDIR_ID_FIS.LostFocus, _
            txtDIR_ID_DOM.LostFocus, _
            txtDIR_ID_COB.LostFocus, _
            txtDIR_ID_ENT.LostFocus, _
            txtPER_ID_REC.LostFocus, _
            txtTDP_ID_REC.LostFocus, _
            txtDIR_ID_ENT_REC.LostFocus, _
            txtPER_ID_VEN.LostFocus, _
            txtPER_ID_COB.LostFocus, _
            txtPER_ID_GRU.LostFocus, _
            txtPER_ID_CON.LostFocus, _
            txtPER_ID_PRO.LostFocus, _
            txtPVE_ID_DES.LostFocus, _
            txtLPR_ID.LostFocus, _
            txtFLE_ID.LostFocus, _
            txtCCT_ID.LostFocus, _
            txtCAF_IX_NUMERO_PRO.LostFocus, _
            txtDTD_ID_AFE.LostFocus

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto2 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto2 = sender.text
                Case "txtMON_ID"
                    EtxtMON_ID.pTexto2 = sender.text
                Case "txtTIV_ID"
                    EtxtTIV_ID.pTexto2 = sender.text
                Case "txtPER_ID_CLI"
                    EtxtPER_ID_CLI.pTexto2 = sender.text
                Case "txtTDP_ID_CLI"
                    EtxtTDP_ID_CLI.pTexto2 = sender.text
                Case "txtDIR_ID_FIS"
                    EtxtDIR_ID_FIS.pTexto2 = sender.text
                Case "txtDIR_ID_DOM"
                    EtxtDIR_ID_DOM.pTexto2 = sender.text
                Case "txtDIR_ID_COB"
                    EtxtDIR_ID_COB.pTexto2 = sender.text
                Case "txtDIR_ID_ENT"
                    EtxtDIR_ID_ENT.pTexto2 = sender.text
                Case "txtPER_ID_REC"
                    EtxtPER_ID_REC.pTexto2 = sender.text
                Case "txtTDP_ID_REC"
                    EtxtTDP_ID_REC.pTexto2 = sender.text
                Case "txtDIR_ID_ENT_REC"
                    EtxtDIR_ID_ENT_REC.pTexto2 = sender.text
                Case "txtPER_ID_VEN"
                    EtxtPER_ID_VEN.pTexto2 = sender.text
                Case "txtPER_ID_COB"
                    EtxtPER_ID_COB.pTexto2 = sender.text
                Case "txtPER_ID_GRU"
                    EtxtPER_ID_GRU.pTexto2 = sender.text
                Case "txtPER_ID_CON"
                    EtxtPER_ID_CON.pTexto2 = sender.text
                Case "txtPER_ID_PRO"
                    EtxtPER_ID_PRO.pTexto2 = sender.text
                Case "txtPVE_ID_DES"
                    EtxtPVE_ID_DES.pTexto2 = sender.text
                Case "txtLPR_ID"
                    EtxtLPR_ID.pTexto2 = sender.text
                Case "txtFLE_ID"
                    EtxtFLE_ID.pTexto2 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto2 = sender.text
                Case "txtCAF_IX_NUMERO_PRO"
                    EtxtCAF_IX_NUMERO_PRO.pTexto2 = sender.text
                    'Case "txtTDO_ID_AFE"
                    'EtxtTDO_ID_AFE.pTexto2 = sender.text
                Case "txtDTD_ID_AFE"
                    EtxtDTD_ID_AFE.pTexto2 = sender.text
                    'Case "txtCCT_ID_AFE"
                    'EtxtCCT_ID_AFE.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles _
            txtPVE_ID.Validated, _
            txtDTD_ID.Validated, _
            txtDOC_NUMERO.Validated, _
            txtMON_ID.Validated, _
            txtTIV_ID.Validated, _
            txtDOC_IGV_POR.Validated, _
            txtPER_ID_CLI.Validated, _
            txtTDP_ID_CLI.Validated, _
            txtDIR_ID_FIS.Validated, _
            txtDIR_ID_DOM.Validated, _
            txtDIR_ID_COB.Validated, _
            txtDIR_ID_ENT.Validated, _
            txtPER_ID_REC.Validated, _
            txtTDP_ID_REC.Validated, _
            txtDIR_ID_ENT_REC.Validated, _
            txtDOC_ORDEN_COMPRA.Validated, _
            txtPER_ID_VEN.Validated, _
            txtPER_ID_COB.Validated, _
            txtPER_ID_GRU.Validated, _
            txtPER_ID_CON.Validated, _
            txtPER_ID_PRO.Validated, _
            txtDOC_OBSERVACIONES.Validated, _
            txtPVE_ID_DES.Validated, _
            txtLPR_ID.Validated, _
            txtFLE_ID.Validated, _
            txtCCT_ID.Validated, _
            txtCAF_IX_NUMERO_PRO.Validated, _
            txtDTD_ID_AFE.Validated
            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    ValidarDatos(EtxtPVE_ID, txtPVE_ID)

                Case "txtDTD_ID"
                    ValidarDatos(EtxtDTD_ID, txtDTD_ID)

                Case "txtDOC_NUMERO"
                    ValidarDatos(EtxtDOC_NUMERO, txtDOC_NUMERO)
                    MascaraCamposText(txtDOC_NUMERO)

                Case "txtMON_ID"
                    ValidarDatos(EtxtMON_ID, txtMON_ID)

                Case "txtTIV_ID"
                    ValidarDatos(EtxtTIV_ID, txtTIV_ID)

                Case "txtDOC_IGV_POR"
                    ValidarDatos(EtxtDOC_IGV_POR, txtDOC_IGV_POR)

                Case "txtPER_ID_CLI"
                    txtPER_ID_CLI.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_CLI.Text, txtPER_ID_CLI.MaxLength)
                    ValidarDatos(EtxtPER_ID_CLI, txtPER_ID_CLI)

                Case "txtTDP_ID_CLI"
                    ValidarDatos(EtxtTDP_ID_CLI, txtTDP_ID_CLI, txtPER_ID_CLI.Text & txtTDP_ID_CLI.Text)

                Case "txtDIR_ID_FIS"
                    txtDIR_ID_FIS.Text = cMisProcedimientos.VerificarLongitud(txtDIR_ID_FIS.Text, txtDIR_ID_FIS.MaxLength)
                    ValidarDatos(EtxtDIR_ID_FIS, txtDIR_ID_FIS)

                Case "txtDIR_ID_DOM"
                    txtDIR_ID_DOM.Text = cMisProcedimientos.VerificarLongitud(txtDIR_ID_DOM.Text, txtDIR_ID_DOM.MaxLength)
                    ValidarDatos(EtxtDIR_ID_DOM, txtDIR_ID_DOM)

                Case "txtDIR_ID_COB"
                    txtDIR_ID_COB.Text = cMisProcedimientos.VerificarLongitud(txtDIR_ID_COB.Text, txtDIR_ID_COB.MaxLength)
                    ValidarDatos(EtxtDIR_ID_COB, txtDIR_ID_COB)

                Case "txtDIR_ID_ENT"
                    txtDIR_ID_ENT.Text = cMisProcedimientos.VerificarLongitud(txtDIR_ID_ENT.Text, txtDIR_ID_ENT.MaxLength)
                    ValidarDatos(EtxtDIR_ID_ENT, txtDIR_ID_ENT)

                Case "txtPER_ID_REC"
                    txtPER_ID_REC.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_REC.Text, txtPER_ID_REC.MaxLength)
                    ValidarDatos(EtxtPER_ID_REC, txtPER_ID_REC)

                Case "txtTDP_ID_REC"
                    ValidarDatos(EtxtTDP_ID_REC, txtTDP_ID_REC, txtPER_ID_REC.Text & txtTDP_ID_REC.Text)

                Case "txtDIR_ID_ENT_REC"
                    txtDIR_ID_ENT_REC.Text = cMisProcedimientos.VerificarLongitud(txtDIR_ID_ENT_REC.Text, txtDIR_ID_ENT_REC.MaxLength)
                    ValidarDatos(EtxtDIR_ID_ENT_REC, txtDIR_ID_ENT_REC)

                Case "txtDOC_ORDEN_COMPRA"
                    ValidarDatos(EtxtDOC_ORDEN_COMPRA, txtDOC_ORDEN_COMPRA)

                Case "txtPER_ID_VEN"
                    txtPER_ID_VEN.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_VEN.Text, txtPER_ID_VEN.MaxLength)
                    ValidarDatos(EtxtPER_ID_VEN, txtPER_ID_VEN)

                Case "txtPER_ID_COB"
                    txtPER_ID_COB.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_COB.Text, 6)
                    ValidarDatos(EtxtPER_ID_COB, txtPER_ID_COB)

                Case "txtPER_ID_GRU"
                    txtPER_ID_GRU.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_GRU.Text, 6)
                    ValidarDatos(EtxtPER_ID_GRU, txtPER_ID_GRU)

                Case "txtPER_ID_CON"
                    txtPER_ID_CON.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_CON.Text, 6)
                    ValidarDatos(EtxtPER_ID_CON, txtPER_ID_CON)

                Case "txtPER_ID_PRO"
                    txtPER_ID_PRO.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_PRO.Text, 6)
                    ValidarDatos(EtxtPER_ID_PRO, txtPER_ID_PRO)

                Case "txtDOC_OBSERVACIONES"
                    ValidarDatos(EtxtDOC_OBSERVACIONES, txtDOC_OBSERVACIONES)

                Case "txtPVE_ID_DES"
                    ValidarDatos(EtxtPVE_ID_DES, txtPVE_ID_DES)

                Case "txtLPR_ID"
                    ValidarDatos(EtxtLPR_ID, txtLPR_ID)

                Case "txtFLE_ID"
                    ValidarDatos(EtxtFLE_ID, txtFLE_ID)

                Case "txtCCT_ID"
                    ValidarDatos(EtxtCCT_ID, txtCCT_ID)

                Case "txtCAF_IX_NUMERO_PRO"
                    ValidarDatos(EtxtCAF_IX_NUMERO_PRO, txtCAF_IX_NUMERO_PRO)

                Case "txtDTD_ID_AFE"
                    ValidarDatos(EtxtDTD_ID_AFE, txtDTD_ID_AFE)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtPVE_ID.KeyPress, _
                txtDTD_ID.KeyPress, _
                txtDOC_SERIE.KeyPress, _
                txtDOC_NUMERO.KeyPress, _
                txtMON_ID.KeyPress, _
                txtTIV_ID.KeyPress, _
                txtDOC_IGV_POR.KeyPress, _
                txtPER_ID_CLI.KeyPress, _
                txtTDP_ID_CLI.KeyPress, _
                txtDIR_ID_FIS.KeyPress, _
                txtDIR_ID_DOM.KeyPress, _
                txtDIR_ID_COB.KeyPress, _
                txtDIR_ID_ENT.KeyPress, _
                txtPER_ID_REC.KeyPress, _
                txtTDP_ID_REC.KeyPress, _
                txtDIR_ID_ENT_REC.KeyPress, _
                txtDOC_ORDEN_COMPRA.KeyPress, _
                txtPER_ID_VEN.KeyPress, _
                txtPER_ID_COB.KeyPress, _
                txtPER_ID_GRU.KeyPress, _
                txtPER_ID_CON.KeyPress, _
                txtPER_ID_PRO.KeyPress, _
                txtDOC_OBSERVACIONES.KeyPress, _
                txtPVE_ID_DES.KeyPress, _
                txtLPR_ID.KeyPress, _
                txtFLE_ID.KeyPress, _
                txtCCT_ID.KeyPress, _
                txtCAF_IX_NUMERO_PRO.KeyPress, _
                txtDTD_ID_AFE.KeyPress
            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    oKeyPress(EtxtPVE_ID, e)
                Case "txtDTD_ID"
                    oKeyPress(EtxtDTD_ID, e)
                Case "txtDOC_SERIE"
                    oKeyPress(EtxtDOC_SERIE, e)
                Case "txtDOC_NUMERO"
                    oKeyPress(EtxtDOC_NUMERO, e)
                Case "txtMON_ID"
                    oKeyPress(EtxtMON_ID, e)
                Case "txtTIV_ID"
                    oKeyPress(EtxtTIV_ID, e)
                Case "txtDOC_IGV_POR"
                    oKeyPress(EtxtDOC_IGV_POR, e)
                Case "txtPER_ID_CLI"
                    oKeyPress(EtxtPER_ID_CLI, e)
                Case "txtTDP_ID_CLI"
                    oKeyPress(EtxtTDP_ID_CLI, e)
                Case "txtDIR_ID_FIS"
                    oKeyPress(EtxtDIR_ID_FIS, e)
                Case "txtDIR_ID_DOM"
                    oKeyPress(EtxtDIR_ID_DOM, e)
                Case "txtDIR_ID_COB"
                    oKeyPress(EtxtDIR_ID_COB, e)
                Case "txtDIR_ID_ENT"
                    oKeyPress(EtxtDIR_ID_ENT, e)
                Case "txtPER_ID_REC"
                    oKeyPress(EtxtPER_ID_REC, e)
                Case "txtTDP_ID_REC"
                    oKeyPress(EtxtTDP_ID_REC, e)
                Case "txtDIR_ID_ENT_REC"
                    oKeyPress(EtxtDIR_ID_ENT_REC, e)
                Case "txtDOC_ORDEN_COMPRA"
                    oKeyPress(EtxtDOC_ORDEN_COMPRA, e)
                Case "txtPER_ID_VEN"
                    oKeyPress(EtxtPER_ID_VEN, e)
                Case "txtPER_ID_COB"
                    oKeyPress(EtxtPER_ID_COB, e)
                Case "txtPER_ID_GRU"
                    oKeyPress(EtxtPER_ID_GRU, e)
                Case "txtPER_ID_CON"
                    oKeyPress(EtxtPER_ID_CON, e)
                Case "txtPER_ID_PRO"
                    oKeyPress(EtxtPER_ID_PRO, e)
                Case "txtDOC_OBSERVACIONES"
                    oKeyPress(EtxtDOC_OBSERVACIONES, e)
                Case "txtPVE_ID_DES"
                    oKeyPress(EtxtPVE_ID_DES, e)
                Case "txtLPR_ID"
                    oKeyPress(EtxtLPR_ID, e)
                Case "txtFLE_ID"
                    oKeyPress(EtxtFLE_ID, e)
                Case "txtCCT_ID"
                    oKeyPress(EtxtCCT_ID, e)
                Case "txtCAF_IX_NUMERO_PRO"
                    oKeyPress(EtxtCAF_IX_NUMERO_PRO, e)
                    'Case "txtDOC_MONTO_TOTAL"
                    'e.KeyChar = e.KeyChar=KeyEventArgs
                    'e.KeyChar = ChrW(Asc("0"))
                    'Dim KeyAscii As Long = Asc(e.KeyChar)
                    'If Not (KeyAscii >= 48 And KeyAscii <= 57) Or KeyAscii = 8 Then
                    'Else
                    'MsgBox("Only Characters are allowed", vbInformation,
                    'KeyAscii = 0 ')
                    'End If


                    'KeyAscii = 0

                    'oKeyPress(EtxtDOC_MONTO_TOTAL, e)

                    'Case "txtTDO_ID_AFE"
                    'oKeyPress(EtxtTDO_ID_AFE, e)
                Case "txtDTD_ID_AFE"
                    oKeyPress(EtxtDTD_ID_AFE, e)
                    'Case "txtCCT_ID_AFE"
                    'oKeyPress(EtxtCCT_ID_AFE, e)
                    'Case "txtDOC_SERIE_AFE"
                    'oKeyPress(EtxtDOC_SERIE_AFE, e)
                    'Case "txtDOC_NUMERO_AFE"
                    'oKeyPress(EtxtDOC_NUMERO_AFE, e)
                    'Case "txtDOC_NOMBRE_RECEP"
                    'oKeyPress(EtxtDOC_NOMBRE_RECEP, e)
                    'Case "txtDOC_DNI_RECEP"
                    'oKeyPress(EtxtDOC_DNI_RECEP, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.DoubleClick, _
                txtDTD_ID.DoubleClick, _
                txtMON_ID.DoubleClick, _
                txtTIV_ID.DoubleClick, _
                txtPER_ID_CLI.DoubleClick, _
                txtTDP_ID_CLI.DoubleClick, _
                txtDIR_ID_FIS.DoubleClick, _
                txtDIR_ID_DOM.DoubleClick, _
                txtDIR_ID_COB.DoubleClick, _
                txtDIR_ID_ENT.DoubleClick, _
                txtPER_ID_REC.DoubleClick, _
                txtTDP_ID_REC.DoubleClick, _
                txtDIR_ID_ENT_REC.DoubleClick, _
                txtPER_ID_VEN.DoubleClick, _
                txtPER_ID_COB.DoubleClick, _
                txtPER_ID_GRU.DoubleClick, _
                txtPER_ID_CON.DoubleClick, _
                txtPER_ID_PRO.DoubleClick, _
                txtPVE_ID_DES.DoubleClick, _
                txtLPR_ID.DoubleClick, _
                txtFLE_ID.DoubleClick, _
                txtCCT_ID.DoubleClick, _
                txtCAF_IX_NUMERO_PRO.DoubleClick, _
                txtDTD_ID_AFE.DoubleClick
            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    oDoubleClick(EtxtPVE_ID, txtPVE_ID, "frmPuntoVenta")
                Case "txtDTD_ID"
                    oDoubleClick(EtxtDTD_ID, txtDTD_ID, "frmTipoDocumento")
                Case "txtMON_ID"
                    oDoubleClick(EtxtMON_ID, txtMON_ID, "frmMoneda")
                Case "txtTIV_ID"
                    oDoubleClick(EtxtTIV_ID, txtTIV_ID, "frmTipoVenta")
                Case "txtPER_ID_CLI"
                    oDoubleClick(EtxtPER_ID_CLI, txtPER_ID_CLI, "frmPersonas")
                Case "txtTDP_ID_CLI"
                    oDoubleClick(EtxtTDP_ID_CLI, txtTDP_ID_CLI, "frmDocPersonas_CLI")
                Case "txtDIR_ID_FIS"
                    oDoubleClick(EtxtDIR_ID_FIS, txtDIR_ID_FIS, "frmDireccionesPersonas")
                Case "txtDIR_ID_DOM"
                    oDoubleClick(EtxtDIR_ID_DOM, txtDIR_ID_DOM, "frmDireccionesPersonas")
                Case "txtDIR_ID_COB"
                    oDoubleClick(EtxtDIR_ID_COB, txtDIR_ID_COB, "frmDireccionesPersonas")
                Case "txtDIR_ID_ENT"
                    oDoubleClick(EtxtDIR_ID_ENT, txtDIR_ID_ENT, "frmDireccionesPersonas")
                Case "txtPER_ID_REC"
                    oDoubleClick(EtxtPER_ID_REC, txtPER_ID_REC, "frmPersonas")
                Case "txtTDP_ID_REC"
                    oDoubleClick(EtxtTDP_ID_REC, txtTDP_ID_REC, "frmDocPersonas_REC")
                Case "txtDIR_ID_ENT_REC"
                    oDoubleClick(EtxtDIR_ID_ENT_REC, txtDIR_ID_ENT_REC, "frmDireccionesPersonas")
                Case "txtPER_ID_VEN"
                    oDoubleClick(EtxtPER_ID_VEN, txtPER_ID_VEN, "frmPersonas")
                Case "txtPER_ID_COB"
                    oDoubleClick(EtxtPER_ID_COB, txtPER_ID_COB, "frmPersonas")
                Case "txtPER_ID_GRU"
                    oDoubleClick(EtxtPER_ID_GRU, txtPER_ID_GRU, "frmPersonas")
                Case "txtPER_ID_CON"
                    oDoubleClick(EtxtPER_ID_CON, txtPER_ID_CON, "frmPersonas")
                Case "txtPER_ID_PRO"
                    oDoubleClick(EtxtPER_ID_PRO, txtPER_ID_PRO, "frmPersonas")
                Case "txtPVE_ID_DES"
                    oDoubleClick(EtxtPVE_ID_DES, txtPVE_ID_DES, "frmPuntoVenta")
                Case "txtLPR_ID"
                    oDoubleClick(EtxtLPR_ID, txtLPR_ID, "frmListaPreciosArticulos")
                Case "txtFLE_ID"
                    oDoubleClick(EtxtFLE_ID, txtFLE_ID, "frmFletesTransportes")
                Case "txtCCT_ID"
                    oDoubleClick(EtxtCCT_ID, txtCCT_ID, "")
                Case "txtCAF_IX_NUMERO_PRO"
                    oDoubleClick(EtxtCAF_IX_NUMERO_PRO, txtCAF_IX_NUMERO_PRO, "frmCartaFianza")
                Case "txtDTD_ID_AFE"
                    oDoubleClick(EtxtDTD_ID_AFE, txtDTD_ID, "frmDocumentos")
            End Select
        End Sub
        Private Sub oDoubleClick(ByVal EtxtTemporal As txt, ByRef txt As TextBox, ByVal e As System.String)
            EtxtTemporal.pTexto2 = txt.Text
            ValidarDatos(EtxtTemporal, txt)
            Dim Texto As String = ""
            If Trim(txt.Text) = "" Then
                Exit Sub
            End If
            Dim frmconsulta As Object = Nothing
            Texto = txt.Text
            If EtxtTemporal.pFormularioConsulta Then
                Select Case e
                    Case "frmPuntoVenta"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPuntoVenta)()
                    Case "frmTipoDocumento"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmTipoDocumentos)()
                        Texto = txtTDO_ID.Text
                    Case "frmMoneda"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                    Case "frmTipoVenta"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.CuentasCorrientes.Views.frmTipoVenta)()
                    Case "frmPersonas"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                    Case "frmDocPersonas_CLI"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmDocPersonas)()
                        Texto = txtPER_ID_CLI.Text & txtTDP_ID_CLI.Text
                    Case "frmDocPersonas_REC"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmDocPersonas)()
                        Texto = txtPER_ID_REC.Text & txtTDP_ID_REC.Text
                    Case "frmDireccionesPersonas"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmDireccionesPersonas)()
                    Case "frmListaPreciosArticulos"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.CuentasCorrientes.Views.frmListaPreciosArticulos)()
                    Case "frmFletesTransportes"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Facturacion.Views.frmFletesTransportes)()
                    Case "frmDocumentos"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Facturacion.Views.frmDocumentos)("frmDocumentos1")
                    Case Else
                        Exit Sub
                End Select
                frmconsulta.DatoBusquedaConsulta = Texto
                frmconsulta.MaximizeBox = False
                frmconsulta.MinimizeBox = False
                frmconsulta.Comportamiento = -1
                frmconsulta.ShowDialog()
            End If
        End Sub
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles _
            txtPVE_ID.KeyDown, _
            txtDTD_ID.KeyDown, _
            txtMON_ID.KeyDown, _
            txtTIV_ID.KeyDown, _
            txtPER_ID_CLI.KeyDown, _
            txtTDP_ID_CLI.KeyDown, _
            txtDIR_ID_FIS.KeyDown, _
            txtDIR_ID_DOM.KeyDown, _
            txtDIR_ID_COB.KeyDown, _
            txtDIR_ID_ENT.KeyDown, _
            txtPER_ID_REC.KeyDown, _
            txtTDP_ID_REC.KeyDown, _
            txtDIR_ID_ENT_REC.KeyDown, _
            txtPER_ID_VEN.KeyDown, _
            txtPER_ID_COB.KeyDown, _
            txtPER_ID_GRU.KeyDown, _
            txtPER_ID_CON.KeyDown, _
            txtPER_ID_PRO.KeyDown, _
            txtPVE_ID_DES.KeyDown, _
            txtLPR_ID.KeyDown, _
            txtFLE_ID.KeyDown, _
            txtCCT_ID.KeyDown, _
            txtCAF_IX_NUMERO_PRO.KeyDown, _
            txtDTD_ID_AFE.KeyDown
            Select Case e.KeyCode
                Case Keys.F2
                    Select Case sender.name.ToString
                        Case "txtDIR_ID_FIS"
                            CuadroTexto = txtDIR_ID_FIS
                            If txtDIR_ID_FIS.Text <> "" And txtDIR_DESCRIPCION_FIS.Text <> "" Then
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion3, False, EtxtDIR_ID_FIS, txtDIR_ID_FIS.Text)
                            Else
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion3, True, EtxtDIR_ID_FIS)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtDIR_ID_FIS.Text, True, EtxtDIR_ID_FIS)
                        Case "txtDIR_ID_DOM"
                            CuadroTexto = txtDIR_ID_DOM
                            If txtDIR_ID_DOM.Text <> "" And txtDIR_DESCRIPCION_DOM.Text <> "" Then
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion0, False, EtxtDIR_ID_DOM, txtDIR_ID_DOM.Text)
                            Else
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion0, True, EtxtDIR_ID_DOM, )
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtDIR_ID_DOM.Text, True, EtxtDIR_ID_DOM)
                        Case "txtDIR_ID_COB"
                            CuadroTexto = txtDIR_ID_COB
                            If txtDIR_ID_COB.Text <> "" And txtDIR_DESCRIPCION_COB.Text <> "" Then
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion2, False, EtxtDIR_ID_COB, txtDIR_ID_COB.Text)
                            Else
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion2, True, EtxtDIR_ID_COB)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtDIR_ID_COB.Text, True, EtxtDIR_ID_COB)
                        Case "txtDIR_ID_ENT"
                            CuadroTexto = txtDIR_ID_ENT
                            If txtDIR_ID_ENT.Text <> "" And txtDIR_DESCRIPCION_ENT.Text <> "" Then
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion1, False, EtxtDIR_ID_ENT, txtDIR_ID_ENT.Text)
                            Else
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion1, True, EtxtDIR_ID_ENT)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtDIR_ID_ENT.Text, True, EtxtDIR_ID_ENT)
                        Case "txtDIR_ID_ENT_REC"
                            CuadroTexto = txtDIR_ID_ENT_REC
                            If txtDIR_ID_ENT_REC.Text <> "" And txtDIR_DESCRIPCION_ENT_REC.Text <> "" Then
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion1, False, EtxtDIR_ID_ENT_REC, txtDIR_ID_ENT_REC.Text)
                            Else
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion1, True, EtxtDIR_ID_ENT_REC)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtDIR_ID_ENT_REC.Text, True, EtxtDIR_ID_ENT_REC)
                        Case "txtPER_ID_REC"
                            CuadroTexto = txtPER_ID_REC
                            If txtPER_ID_REC.Text <> "" And txtPER_DESCRIPCION_REC.Text <> "" Then
                                PersonasCrearModificar(False, EtxtPER_ID_REC, sender.name.ToString, txtPER_ID_REC.Text)
                            Else
                                PersonasCrearModificar(True, EtxtPER_ID_REC, sender.name.ToString)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtPER_ID_REC.Text, True, EtxtPER_ID_REC)
                        Case "txtPER_ID_PRO"
                            CuadroTexto = txtPER_ID_PRO
                            If txtPER_ID_PRO.Text <> "" And txtPER_DESCRIPCION_PRO.Text <> "" Then
                                PersonasCrearModificar(False, EtxtPER_ID_PRO, sender.name.ToString, txtPER_ID_PRO.Text)
                            Else
                                PersonasCrearModificar(True, EtxtPER_ID_PRO, sender.name.ToString)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtPER_ID_PRO.Text, True, EtxtPER_ID_PRO)
                    End Select
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtPVE_ID"
                            TeclaF1(EtxtPVE_ID, txtPVE_ID)
                        Case "txtDTD_ID"
                            TeclaF1(EtxtDTD_ID, txtDTD_ID)
                        Case "txtMON_ID"
                            TeclaF1(EtxtMON_ID, txtMON_ID)
                        Case "txtTIV_ID"
                            TeclaF1(EtxtTIV_ID, txtTIV_ID)
                        Case "txtPER_ID_CLI"
                            pBusquedaDevolvioDatos = False
                            TeclaF1(EtxtPER_ID_CLI, txtPER_ID_CLI)
                        Case "txtTDP_ID_CLI"
                            If txtPER_ID_CLI.Text.Trim = "" Then
                                EtxtTDP_ID_CLI.pOOrm.CadenaFiltrado = " AND PER_ID IN (SELECT PER_ID FROM vwRolPersonaTipoPersona WHERE PER_CLIENTE='SI')"
                            End If
                            pBusquedaDevolvioDatos = False
                            TeclaF1(EtxtTDP_ID_CLI, txtTDP_ID_CLI)
                        Case "txtDIR_ID_FIS"
                            TeclaF1(EtxtDIR_ID_FIS, txtDIR_ID_FIS)
                        Case "txtDIR_ID_DOM"
                            TeclaF1(EtxtDIR_ID_DOM, txtDIR_ID_DOM)
                        Case "txtDIR_ID_COB"
                            TeclaF1(EtxtDIR_ID_COB, txtDIR_ID_COB)
                        Case "txtDIR_ID_ENT"
                            TeclaF1(EtxtDIR_ID_ENT, txtDIR_ID_ENT)
                        Case "txtPER_ID_REC"
                            pBusquedaDevolvioDatos = False
                            TeclaF1(EtxtPER_ID_REC, txtPER_ID_REC)
                        Case "txtTDP_ID_REC"
                            TeclaF1(EtxtTDP_ID_REC, txtTDP_ID_REC)
                        Case "txtDIR_ID_ENT_REC"
                            TeclaF1(EtxtDIR_ID_ENT_REC, txtDIR_ID_ENT_REC)
                        Case "txtPER_ID_VEN"
                            TeclaF1(EtxtPER_ID_VEN, txtPER_ID_VEN)
                        Case "txtPER_ID_COB"
                            TeclaF1(EtxtPER_ID_COB, txtPER_ID_COB)
                        Case "txtPER_ID_GRU"
                            TeclaF1(EtxtPER_ID_GRU, txtPER_ID_GRU)
                        Case "txtPER_ID_CON"
                            TeclaF1(EtxtPER_ID_CON, txtPER_ID_CON)
                        Case "txtPER_ID_PRO"
                            TeclaF1(EtxtPER_ID_PRO, txtPER_ID_PRO)
                        Case "txtPVE_ID_DES"
                            TeclaF1(EtxtPVE_ID_DES, txtPVE_ID_DES)
                        Case "txtLPR_ID"
                            TeclaF1(EtxtLPR_ID, txtLPR_ID)
                        Case "txtFLE_ID"
                            TeclaF1(EtxtFLE_ID, txtFLE_ID)
                        Case "txtCCT_ID"
                            TeclaF1(EtxtCCT_ID, txtCCT_ID)
                        Case "txtCAF_IX_NUMERO_PRO"
                            TeclaF1(EtxtCAF_IX_NUMERO_PRO, txtCAF_IX_NUMERO_PRO)
                            'Case "txtCAF_IX_ORDEN_COM"
                            'TeclaF1(EtxtCAF_IX_ORDEN_COM, txtCAF_IX_ORDEN_COM)
                            'Case "txtTDO_ID_AFE"
                            'TeclaF1(EtxtTDO_ID_AFE, txtTDO_ID_AFE)
                        Case "txtDTD_ID_AFE"
                            TeclaF1(EtxtDTD_ID_AFE, txtDTD_ID_AFE)
                            'Case "txtCCT_ID_AFE"
                            'TeclaF1(EtxtCCT_ID_AFE, txtCCT_ID_AFE)
                    End Select
            End Select
        End Sub
#End Region

#End Region

        Private Sub VerificarAsignacionFechasDocumento()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito, _
                     BCVariablesNames.ProcesosFacturación.NotaDebito
                    dtpDOC_FECHA_ENT.Value = dtpDOC_FECHA_EMI.Value
                Case Else
            End Select
            Compuesto.DOC_FECHA_EMI = dtpDOC_FECHA_EMI.Value
            Compuesto.DOC_FECHA_ENT = dtpDOC_FECHA_ENT.Value
            Compuesto.DOC_FECHA_EXP = dtpDOC_FECHA_EXP.Value
        End Sub
        ''' <summary>
        ''' Resumen
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub VerificarTotalDocumentoAfectado()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spVistaTotalDocumentoXML, _
                                                                txtTDO_ID_AFE.Text.Trim, _
                                                                txtDTD_ID_AFE.Text.Trim, _
                                                                txtDOC_SERIE_AFE.Text.Trim, _
                                                                txtDOC_NUMERO_AFE.Text.Trim
                                                               )
                                      )
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                lblMON_SIMBOLO_AFE.Text = ds.Tables(0).Rows(0)("MON_SIMBOLO").ToString
                txtMON_ID_AFE.Text = ds.Tables(0).Rows(0)("MON_ID").ToString
                txtMONTO_AFE.Text = ds.Tables(0).Rows(0)("DOC_MONTO_TOTAL").ToString
            End If
        End Sub
        Private Sub VerificarDatosCliente()
            Dim vCadenaFiltrado As String = ""
            FiltroPER_ID_CLI()
            vCadenaFiltrado = " AND PER_ID='" & txtPER_ID_CLI.Text & "'"
            EtxtDIR_ID_FIS.pOOrm.CadenaFiltrado = vCadenaFiltrado & " AND DIR_TIPO='FISCAL' "
            EtxtDIR_ID_DOM.pOOrm.CadenaFiltrado = vCadenaFiltrado
            EtxtDIR_ID_COB.pOOrm.CadenaFiltrado = vCadenaFiltrado
            EtxtDIR_ID_ENT.pOOrm.CadenaFiltrado = vCadenaFiltrado
            EtxtCAF_IX_NUMERO_PRO.pOOrm.CadenaFiltrado = vCadenaFiltrado
            If txtPER_ID_CLI.Text.Trim = "" Then
                vCadenaFiltrado = ""
            End If
            EtxtTDP_ID_CLI.pOOrm.CadenaFiltrado = vCadenaFiltrado
            If pPER_FORMA_VENTA = BCVariablesNames.FormaVenta.Todas Then
                EtxtTIV_ID.pOOrm.CadenaFiltrado = " AND (TIV_COMPORTAMIENTO='VENTAS' OR TIV_COMPORTAMIENTO='COMPRAS Y VENTAS')"
            Else
                If pDocumentoProcesandose = 600 Then
                    EtxtTIV_ID.pOOrm.CadenaFiltrado = " AND (TIV_COMPORTAMIENTO='VENTAS' OR TIV_COMPORTAMIENTO='COMPRAS Y VENTAS')"
                Else
                    'EtxtTIV_ID.pOOrm.CadenaFiltrado = " AND (TIV_COMPORTAMIENTO='VENTAS' OR TIV_COMPORTAMIENTO='COMPRAS Y VENTAS') " & _
                    '              " AND (TIV_FORMA_VENTA='" & pPER_FORMA_VENTA & _
                    '                   "' OR (TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Credito & "'" & _
                    '                         " AND TIV_DESCRIPCION IN ('" & BCVariablesNames.TipoVentaDescripcion.Cobrador & "')" & _
                    '                         ")" & _
                    '                   "  OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Contraentrega & _
                    '                   "' OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Contado & "'" & _
                    '                   ") "
                    EtxtTIV_ID.pOOrm.CadenaFiltrado = " AND (TIV_COMPORTAMIENTO='VENTAS' OR TIV_COMPORTAMIENTO='COMPRAS Y VENTAS') " & _
                                  " AND (TIV_FORMA_VENTA='" & pPER_FORMA_VENTA & _
                                       "' OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Contraentrega & _
                                       "' OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.ContraentregaEnPlanta & _
                                       "' OR TIV_FORMA_VENTA='" & BCVariablesNames.TipoVentaDescripcion.Contado & "'" & _
                                       ") "
                End If
            End If
            '***
            VerificarSaldoCliente()
            pPrecioEspecialCliente = VerificarPrecioEspecialPersona()
        End Sub
        Private Sub VerificarTipoVenta()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito, _
                     BCVariablesNames.ProcesosFacturación.NotaDebito
                    txtTIV_ID.Text = IBCMaestro.EjecutarVista("spCodigoVentaContado", BCVariablesNames.TipoVenta.Contado)
                    EtxtTIV_ID.pOOrm.CadenaFiltrado = " AND (TIV_COMPORTAMIENTO='VENTAS' OR TIV_COMPORTAMIENTO='COMPRAS Y VENTAS')"
                Case Else
                    Select Case pPER_FORMA_VENTA
                        Case BCVariablesNames.TipoVentaDescripcion.Contado
                            txtTIV_ID.Text = BCVariablesNames.TipoVentaContado
                        Case BCVariablesNames.TipoVentaDescripcion.Contraentrega
                            txtTIV_ID.Text = BCVariablesNames.TipoVentaContraEntrega
                        Case BCVariablesNames.TipoVentaDescripcion.Credito
                        Case BCVariablesNames.TipoVentaDescripcion.Ninguno
                            txtTIV_ID.Text = ""
                        Case BCVariablesNames.TipoVentaDescripcion.Todas
                            If txtTIV_ID.Text.Trim = "" Then txtTIV_ID.Text = BCVariablesNames.TipoVentaContado
                    End Select

                    'If txtTIV_ID.Text.Trim = "" Then txtTIV_ID.Text = pTIV_ID
            End Select

            MetodoBusquedaDato(txtTIV_ID.Text, True, EtxtTIV_ID)
        End Sub
        Private Sub VerificarSaldoCliente()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito
                    SaldosDocumentoCliente()
                Case BCVariablesNames.ProcesosFacturación.NotaDebito
                Case Else
                    SaldosClienteContado()
                    SaldosClienteContraentregaCredito123()
                    SaldosCliente()
            End Select
        End Sub

        Private Function ValidarFechasDocumento(ByVal vEstado As Boolean)
            ValidarFechasDocumento = vEstado
            Select Case pTDO_ID
                'Case BCVariablesNames.ProcesosFacturación.NotaCredito, BCVariablesNames.ProcesosFacturación.NotaDebito
                Case BCVariablesNames.ProcesosFacturación.PedidoBoleta, _
                    BCVariablesNames.ProcesosFacturación.PedidoFactura
                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosFacturación.OrdCompraBoleta, _
                            BCVariablesNames.ProcesosFacturación.OrdCompraFactura
                            If Compuesto.DOC_FECHA_EMI > Compuesto.DOC_FECHA_EXP Then
                                ErrorProvider1.SetError(dtpDOC_FECHA_EXP, "La fecha de expiración no puede ser menor que la fecha de emisión")
                                ValidarFechasDocumento = False
                            Else
                                ErrorProvider1.SetError(dtpDOC_FECHA_EXP, Nothing)
                            End If
                    End Select
                Case Else
                    If Compuesto.DOC_FECHA_EMI > Compuesto.DOC_FECHA_ENT Then
                        ErrorProvider1.SetError(dtpDOC_FECHA_ENT, "La fecha de entrega no puede ser menor que la fecha de emisión")
                        ValidarFechasDocumento = False
                    Else
                        ErrorProvider1.SetError(dtpDOC_FECHA_EMI, Nothing)
                    End If
            End Select
            Return ValidarFechasDocumento
        End Function
        Private Function ValidarUsuarioCredito1Dia(ByVal vEstado As Boolean)
            ValidarUsuarioCredito1Dia = vEstado
            Return ValidarUsuarioCredito1Dia
            Select Case SessionService.UserId
                Case "ADMIN", "ANAGUZMAN", "GLADYS", "ROSAG", "MSUAREZ", "LAPAZA", "CTERESA", "ELIANA", "JCARIR", "DORAZ", "CARLOS", "HUGOL", "ECACERES", "ALOPEZ", "YMENDOZA"
                Case Else
                    Select Case txtTIV_DESCRIPCION.Text
                        Case BCVariablesNames.TipoVentaDescripcion.Credito1Dias
                            ErrorProvider1.SetError(lblDOC_IGV_POR, "Usuario no autorizado a ventas crédito 1 día")
                            ValidarUsuarioCredito1Dia = False
                    End Select
            End Select
            Return ValidarUsuarioCredito1Dia
        End Function
        Private Function ValidarVendedorCredito1Dia(ByVal vEstado As Boolean)
            ValidarVendedorCredito1Dia = vEstado
            Select Case txtPER_ID_VEN.Text
                Case "000982", "001160", "001609", "001723", "008382", "047236", "001839", "048021", "001632", "035027", "051886", "001612", "009581"
                Case Else
                    Select Case txtTIV_DESCRIPCION.Text
                        Case BCVariablesNames.TipoVentaDescripcion.Credito1Dias
                            ErrorProvider1.SetError(txtPER_ID_VEN, "Vendedor no autorizado a ventas crédito 1 día")
                            ValidarVendedorCredito1Dia = False
                    End Select
            End Select
            Return ValidarVendedorCredito1Dia
        End Function


        Private Function ValidarMontoContraEntrega(ByVal vEstado As Boolean)
            ValidarMontoContraEntrega = vEstado
            Select Case txtTIV_DESCRIPCION.Text
                Case BCVariablesNames.TipoVentaDescripcion.Contraentrega, _
                     BCVariablesNames.TipoVentaDescripcion.Cobrador, _
                     BCVariablesNames.TipoVentaDescripcion.ContraentregaEnPlanta
                    'BCVariablesNames.TipoVentaDescripcion.ContadoConDeposito, _
                    'BCVariablesNames.TipoVentaDescripcion.Credito1Dias
                    'BCVariablesNames.TipoVentaDescripcion.Credito2Dias, _
                    'BCVariablesNames.TipoVentaDescripcion.Credito3Dias
                    If CDbl(txtDOC_MONTO_TOTAL.Text) + CDbl(txtDeudaContraentregaCredito123.Text) > IBCBusqueda.LimiteContraEntrega("LIMITECONTRAENTREGA") Then
                        If cboDOC_ESTADO.Text = "NO ACTIVO" Then
                            ErrorProvider1.SetError(txtDOC_MONTO_TOTAL, Nothing)
                        Else
                            If txtTIV_DESCRIPCION.Text = BCVariablesNames.TipoVentaDescripcion.ContraentregaEnPlanta Then
                                ErrorProvider1.SetError(txtDOC_MONTO_TOTAL, Nothing)
                            Else
                                ErrorProvider1.SetError(txtDOC_MONTO_TOTAL, "El monto supera el permitido a venta tipo: Contraentrega")
                                ValidarMontoContraEntrega = False
                            End If
                        End If
                    Else
                        If IBCBusqueda.ContraEntregaDocumento(txtPER_ID_VEN.Text) Then
                            ErrorProvider1.SetError(txtDOC_MONTO_TOTAL, Nothing)
                        Else
                            ErrorProvider1.SetError(txtDOC_MONTO_TOTAL, "Vendedor no esta autorizado a vender como: Contraentrega")
                            ValidarMontoContraEntrega = False
                        End If
                    End If
                Case Else
                    ErrorProvider1.SetError(txtDOC_MONTO_TOTAL, Nothing)
            End Select
            Return ValidarMontoContraEntrega
        End Function
        Private Function ValidarTipoVenta(ByVal vEstado As Boolean)
            ValidarTipoVenta = vEstado
            If vClienteSoloContado Then
                If txtTIV_DESCRIPCION.Text <> BCVariablesNames.TipoVentaDescripcion.Contado Then
                    ErrorProvider1.SetError(txtTIV_DESCRIPCION, "Cliente solo puede comprar al contado")
                    ValidarTipoVenta = False
                Else
                    ErrorProvider1.SetError(txtTIV_DESCRIPCION, Nothing)
                End If
            End If
            Return ValidarTipoVenta
        End Function
        Private Function ValidarDiasCredito(ByVal vEstado As Boolean)
            ValidarDiasCredito = vEstado
            Dim vPer_Dias_Credito As Double
            Dim vTiv_Dias As Double

            If Not IsNumeric(txtPER_DIAS_CREDITO.Text) Then
                vPer_Dias_Credito = 0
            Else
                vPer_Dias_Credito = CDbl(txtPER_DIAS_CREDITO.Text)
            End If

            If Not IsNumeric(txtTIV_DIAS.Text) Then
                vTiv_Dias = 0
            Else
                vTiv_Dias = CDbl(txtTIV_DIAS.Text)
            End If

            Select Case txtTIV_DESCRIPCION.Text
                Case BCVariablesNames.TipoVentaDescripcion.Contado, _
                     BCVariablesNames.TipoVentaDescripcion.ContadoConDeposito, _
                     BCVariablesNames.TipoVentaDescripcion.Contraentrega, _
                     BCVariablesNames.TipoVentaDescripcion.ContraentregaEnPlanta, _
                     BCVariablesNames.TipoVentaDescripcion.Cobrador
                    'BCVariablesNames.TipoVentaDescripcion.Credito1Dias
                    'BCVariablesNames.TipoVentaDescripcion.Credito2Dias, _
                    'BCVariablesNames.TipoVentaDescripcion.Credito3Dias
                    ErrorProvider1.SetError(txtTIV_DIAS, Nothing)
                Case Else
                    If vTiv_Dias > vPer_Dias_Credito Then
                        ErrorProvider1.SetError(txtTIV_DIAS, "Error, cliente no autorizado para los días de crédito seleccionado")
                        ValidarDiasCredito = False
                    Else
                        ErrorProvider1.SetError(txtTIV_DIAS, Nothing)
                    End If
            End Select
            Return ValidarDiasCredito
        End Function


        Private Function ValidarItemBalanzaServicioEstibaje(ByVal vEstado As Boolean)
            ValidarItemBalanzaServicioEstibaje = vEstado
            Dim vFlagArticuloBalanzaServicioEstibajeEncontrado As Boolean = False
            Dim vFlagArticuloBalanzaServicioEstibaje As Boolean = True

            For vFilas = 0 To dgvDetalle.RowCount - 1
                If Trim(dgvDetalle.Item("cART_ID_KAR", vFilas).Value) = "020190" Or _
                   Trim(dgvDetalle.Item("cART_ID_KAR", vFilas).Value) = "022830" Or _
                   Trim(dgvDetalle.Item("cART_ID_KAR", vFilas).Value) = "020067" Then
                    vFlagArticuloBalanzaServicioEstibajeEncontrado = True
                    Exit For
                End If
            Next

            For vFilas = 0 To dgvDetalle.RowCount - 1
                If Trim(dgvDetalle.Item("cART_ID_KAR", vFilas).Value) = "020190" Or _
                   Trim(dgvDetalle.Item("cART_ID_KAR", vFilas).Value) = "022830" Or _
                   Trim(dgvDetalle.Item("cART_ID_KAR", vFilas).Value) = "020067" Then
                Else
                    If vFlagArticuloBalanzaServicioEstibajeEncontrado Then vFlagArticuloBalanzaServicioEstibaje = False
                End If
            Next


            If vFlagArticuloBalanzaServicioEstibaje Then
                ErrorProvider1.SetError(lblTIV_ID, Nothing)
            Else
                ErrorProvider1.SetError(lblTIV_ID, "la venta con el artículo Balanza ó Servicio de estibaje, deben estar separados de otros artículos.")
                ValidarItemBalanzaServicioEstibaje = False
            End If
            Return ValidarItemBalanzaServicioEstibaje
        End Function

        Private Function ValidarVentaBalanzaServicioEstibaje(ByVal vEstado As Boolean)
            ValidarVentaBalanzaServicioEstibaje = vEstado
            Dim vFlagArticuloBalanzaServicioEstibaje As Boolean = True
            For vFilas = 0 To dgvDetalle.RowCount - 1
                If Trim(dgvDetalle.Item("cART_ID_KAR", vFilas).Value) = "020190" Or _
                   Trim(dgvDetalle.Item("cART_ID_KAR", vFilas).Value) = "022830" Or _
                   Trim(dgvDetalle.Item("cART_ID_KAR", vFilas).Value) = "020067" Then
                Else
                    vFlagArticuloBalanzaServicioEstibaje = False
                End If
            Next
            If vFlagArticuloBalanzaServicioEstibaje Then
                Select Case txtTIV_DESCRIPCION.Text
                    Case BCVariablesNames.TipoVentaDescripcion.Contado
                        vFlagVentaContadoBalanzaServicioEstibaje = True
                        ErrorProvider1.SetError(txtTIV_DESCRIPCION, Nothing)
                    Case Else
                        vFlagVentaContadoBalanzaServicioEstibaje = False
                        ErrorProvider1.SetError(txtTIV_DESCRIPCION, "El documento de venta con el item Balanza ó Servicio de estibaje; Debe ser tipo de venta al contado.")
                        ValidarVentaBalanzaServicioEstibaje = False
                End Select
            Else
                vFlagVentaContadoBalanzaServicioEstibaje = False
            End If
            Return ValidarVentaBalanzaServicioEstibaje
        End Function
        Private Function ValidarLineaCredito(ByVal vEstado As Boolean)
            ValidarLineaCredito = vEstado
            If CDbl(txtDOC_MONTO_TOTAL.Text) = 0 Then
                Return ValidarLineaCredito
                Exit Function
            End If
            Dim vcontrol As Int16 = 0
            Dim ds As New DataSet
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito, _
                     BCVariablesNames.ProcesosFacturación.NotaDebito
                Case Else
                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosFacturación.BoletaAnticipo, _
                             BCVariablesNames.ProcesosFacturación.FacturaAnticipo, _
                             BCVariablesNames.ProcesosFacturación.PBBoleta, _
                             BCVariablesNames.ProcesosFacturación.PFFactura
                        Case Else
                            Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spListarTipoVentaTIV_FORMA_VENTAXML, txtTIV_ID.Text, "'" & BCVariablesNames.TipoVenta.Contado & "','" & BCVariablesNames.TipoVenta.Contraentrega & "'"))
                            vcontrol = sr.Peek
                            If vcontrol <> -1 Then
                                Select Case txtTIV_DESCRIPCION.Text
                                    Case BCVariablesNames.TipoVentaDescripcion.Contraentrega, _
                                         BCVariablesNames.TipoVentaDescripcion.ContraentregaEnPlanta, _
                                         BCVariablesNames.TipoVentaDescripcion.Cobrador
                                        'BCVariablesNames.TipoVentaDescripcion.Credito1Dias
                                        'BCVariablesNames.TipoVentaDescripcion.ContadoConDeposito, _
                                        'BCVariablesNames.TipoVentaDescripcion.Credito2Dias, _
                                        'BCVariablesNames.TipoVentaDescripcion.Credito3Dias
                                        If CDbl(txtDisponible.Text) + CDbl(txtDeudaContraentregaCredito123.Text) >= 0 Then
                                            If CDbl(txtDisponibleContraentregaCredito123.Text) < 0 Then
                                                If txtTIV_DESCRIPCION.Text = BCVariablesNames.TipoVentaDescripcion.ContraentregaEnPlanta Then
                                                    ErrorProvider1.SetError(txtDeuda, Nothing)
                                                Else
                                                    ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                                    ValidarLineaCredito = False
                                                End If
                                            Else
                                                ErrorProvider1.SetError(txtDeuda, Nothing)
                                            End If
                                        Else
                                            ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                            ValidarLineaCredito = False
                                        End If
                                    Case BCVariablesNames.TipoVentaDescripcion.Contado
                                        If CDbl(txtDisponible.Text) + CDbl(txtDeudaContado.Text) >= 0 Then
                                            If CDbl(txtDisponibleContado.Text) < 0 Then
                                                ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                                ValidarLineaCredito = False
                                            Else
                                                ErrorProvider1.SetError(txtDeuda, Nothing)
                                            End If
                                        Else
                                            ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                            ValidarLineaCredito = False
                                        End If
                                    Case Else
                                        If CDbl(txtDisponible.Text) + CDbl(txtDeudaContraentregaCredito123.Text) < 0 Then
                                            ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                            ValidarLineaCredito = False
                                        Else
                                            ErrorProvider1.SetError(txtDeuda, Nothing)
                                        End If
                                End Select
                                If ValidarLineaCredito Then
                                    If CDbl(txtDiasContado.Text) = 0 Then
                                        If CDbl(txtDiasContraentragaCredito123.Text) <= 3 Then
                                            ErrorProvider1.SetError(txtDeuda, Nothing)
                                        Else
                                            ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                            ValidarLineaCredito = False
                                        End If
                                    Else
                                        ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                        ValidarLineaCredito = False
                                    End If
                                    If ValidarLineaCredito Then
                                        If CDbl(txtDiasGeneral.Text) <= 0 Then
                                            ErrorProvider1.SetError(txtDeuda, Nothing)
                                        Else
                                            ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                            ValidarLineaCredito = False
                                        End If
                                    End If
                                End If
                            Else
                                If CDbl(txtDOC_MONTO_TOTAL.Text) > CDbl(txtDisponible.Text) + CDbl(txtDeudaContraentregaCredito123.Text) Then
                                    ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                    ValidarLineaCredito = False
                                Else
                                    ErrorProvider1.SetError(txtDeuda, Nothing)
                                End If
                                If ValidarLineaCredito Then
                                    If CDbl(txtDiasGeneral.Text) <= 0 Then
                                        ErrorProvider1.SetError(txtDeuda, Nothing)
                                    Else
                                        ErrorProvider1.SetError(txtDeuda, "Excedio su línea de crédito")
                                        ValidarLineaCredito = False
                                    End If
                                End If
                            End If
                    End Select
            End Select
            Return ValidarLineaCredito
        End Function
        Private Function ValidarDocumentoNota(ByVal vEstado As Boolean)
            ValidarDocumentoNota = vEstado
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito, _
                     BCVariablesNames.ProcesosFacturación.NotaDebito
                    If txtDTD_ID_AFE.Text.Trim = "" Then
                        ErrorProvider1.SetError(txtDTD_ID_AFE, "Debe seleccionar el documento al cual afectara la Nota de Crédito/Débito")
                        ValidarDocumentoNota = False
                    End If
                Case Else
            End Select
            Return ValidarDocumentoNota
        End Function

        Private Function VerificarCantidadMontoAfectaDocumentos(ByVal vEstado As Boolean)
            VerificarCantidadMontoAfectaDocumentos = vEstado
            If dgvDetalleAfectaMonto.RowCount = 0 Then
                ErrorProvider1.SetError(dgvDetalleAfectaMonto, "Debe ingresar un documento(s) que afecte a monto")
                ErrorProvider1.SetError(tcoDatos, "Debe ingresar un documento(s) que afecte a monto")
                VerificarCantidadMontoAfectaDocumentos = False
            End If
            Return VerificarCantidadMontoAfectaDocumentos
        End Function
        Private Function VerificarCantidadProductoAfectaDocumentos(ByVal vEstado As Boolean)
            VerificarCantidadProductoAfectaDocumentos = vEstado
            If dgvDetalleAfectaProducto.RowCount = 0 Then
                ErrorProvider1.SetError(dgvDetalleAfectaProducto, "Debe ingresar un documento(s) que afecte a producto")
                ErrorProvider1.SetError(tcoDatos, "Debe ingresar un documento(s) que afecte a producto")
                VerificarCantidadProductoAfectaDocumentos = False
            End If
            Return VerificarCantidadProductoAfectaDocumentos
        End Function
        Private Function VerificarNoCantidadProductoAfectaDocumentos(ByVal vEstado As Boolean)
            VerificarNoCantidadProductoAfectaDocumentos = vEstado
            If dgvDetalleAfectaProducto.RowCount <> 0 Then
                ErrorProvider1.SetError(dgvDetalleAfectaProducto, "No debe ingresar un documento(s) que afecte a producto")
                ErrorProvider1.SetError(tcoDatos, "No debe ingresar un documento(s) que afecte a producto")
                VerificarNoCantidadProductoAfectaDocumentos = False
            End If
            Return VerificarNoCantidadProductoAfectaDocumentos
        End Function
        Private Function VerificarCantidadProductoAfectaDocumentosGuiaDevolucion(ByVal vEstado As Boolean)
            VerificarCantidadProductoAfectaDocumentosGuiaDevolucion = vEstado
            For vFilas = 0 To dgvDetalleAfectaProducto.RowCount - 1
                If Trim(dgvDetalleAfectaProducto.Item("cTDO_ID_DEV", vFilas).Value) = "" Or _
                   Trim(dgvDetalleAfectaProducto.Item("cDTD_ID_DEV", vFilas).Value) = "" Then
                    ErrorProvider1.SetError(dgvDetalleAfectaProducto, "Error no ingreso la guía de devolución")
                    VerificarCantidadProductoAfectaDocumentosGuiaDevolucion = False
                    Exit For
                End If
            Next
            Return VerificarCantidadProductoAfectaDocumentosGuiaDevolucion
        End Function
        Private Function VerificarCantidadProductoAfectaDocumentosNoGuiaDevolucion(ByVal vEstado As Boolean)
            VerificarCantidadProductoAfectaDocumentosNoGuiaDevolucion = vEstado
            For vFilas = 0 To dgvDetalleAfectaProducto.RowCount - 1
                If Trim(dgvDetalleAfectaProducto.Item("cTDO_ID_DEV", vFilas).Value) <> "" Or _
                   Trim(dgvDetalleAfectaProducto.Item("cDTD_ID_DEV", vFilas).Value) <> "" Then
                    ErrorProvider1.SetError(dgvDetalleAfectaProducto, "Error ingreso guía de devolución")
                    VerificarCantidadProductoAfectaDocumentosNoGuiaDevolucion = False
                    Exit For
                End If
            Next
            Return VerificarCantidadProductoAfectaDocumentosNoGuiaDevolucion
        End Function
        Private Function VerificarTotalMontoAfectaDocumentos(ByVal vEstado As Boolean)
            VerificarTotalMontoAfectaDocumentos = vEstado
            Dim vFilasGrid As Int16 = 0
            Dim vTotalMontoAfecta As Double = 0
            Dim vTotalNotaCredito As Double = 0
            If dgvDetalleAfectaMonto.RowCount = 0 Then
                Return VerificarTotalMontoAfectaDocumentos
                Exit Function
            End If
            vFilasGrid = dgvDetalleAfectaMonto.RowCount
            For vFilas = 0 To vFilasGrid - 1
                vTotalMontoAfecta += Math.Round(CDbl(dgvDetalleAfectaMonto.Item("cDDA_PRE_TOTAL", vFilas).Value), 2)
            Next
            vTotalNotaCredito = txtDOC_MONTO_TOTAL.Text
            'If vTotalMontoAfecta <> vTotalNotaCredito Then
            If Math.Round(vTotalMontoAfecta, 2) > Math.Round(vTotalNotaCredito, 2) Then
                ErrorProvider1.SetError(dgvDetalleAfectaMonto, "Monto de los documentos afectados no concuerda con el total del documento")
                ErrorProvider1.SetError(tcoDatos, "Monto de los documentos afectados no concuerda con el total del documento")
                VerificarTotalMontoAfectaDocumentos = False
            End If
            Return VerificarTotalMontoAfectaDocumentos
        End Function
        Private Function VerificarTotalMontoNotaCredito(ByVal vEstado As Boolean)
            VerificarTotalMontoNotaCredito = vEstado
            Dim vTotalMontoAfecta As Double = 0
            Dim vTotalNotaCredito As Double = 0
            vTotalMontoAfecta = txtMONTO_AFE.Text
            vTotalNotaCredito = txtDOC_MONTO_TOTAL.Text
            If vTotalNotaCredito > vTotalMontoAfecta Then
                'If vTotalNotaCredito < vTotalMontoAfecta Then
                ErrorProvider1.SetError(txtMONTO_AFE, "Monto del documento (Boleta/factura) no concuerda con el total de la nota de crédito")
                VerificarTotalMontoNotaCredito = False
            End If
            Return VerificarTotalMontoNotaCredito
        End Function

        Private Function VerificarTotalMontoNotaCreditoCero(ByVal vEstado As Boolean)
            VerificarTotalMontoNotaCreditoCero = vEstado
            Dim vTotalMontoAfecta As Double = 0
            'Dim vTotalNotaCredito As Double = 0
            vTotalMontoAfecta = txtMONTO_AFE.Text
            'vTotalNotaCredito = txtDOC_MONTO_TOTAL.Text
            If vTotalMontoAfecta <> 0 Then
                ErrorProvider1.SetError(txtMONTO_AFE, "Monto del documento (Boleta/factura) debe ser cero (0.00)")
                VerificarTotalMontoNotaCreditoCero = False
            End If
            Return VerificarTotalMontoNotaCreditoCero
        End Function

        Private Sub VerificarDireccionesCliente()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito, _
                     BCVariablesNames.ProcesosFacturación.NotaDebito
                    DireccionesNotas()
                Case Else
                    DireccionesNotas()
                    DireccionesVentas()
            End Select
        End Sub
        Private Sub DireccionesNotas()
            MetodoBusquedaDato(Me.IBCBusqueda.CodigoDireccionPersona(txtPER_ID_CLI.Text, pFiscal), True, EtxtDIR_ID_FIS)
            MetodoBusquedaDato(Me.IBCBusqueda.CodigoDireccionPersona(txtPER_ID_CLI.Text, pDomicilio), True, EtxtDIR_ID_DOM)
        End Sub
        Private Sub DireccionesVentas()
            MetodoBusquedaDato(Me.IBCBusqueda.CodigoDireccionPersona(txtPER_ID_CLI.Text, pCobranza), True, EtxtDIR_ID_COB)
            MetodoBusquedaDato(Me.IBCBusqueda.CodigoDireccionPersona(txtPER_ID_CLI.Text, pEntrega), True, EtxtDIR_ID_ENT)
        End Sub
        Private Function ValidarDireccionesCliente(ByVal vEstado As Boolean) As Boolean
            ValidarDireccionesCliente = vEstado
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito,
                     BCVariablesNames.ProcesosFacturación.NotaDebito
                    If txtDIR_ID_FIS.Text.Trim = "" And txtDIR_ID_DOM.Text.Trim = "" Then
                        ErrorProvider1.SetError(txtDIR_ID_FIS, "Ingrese un código de dirección")
                        ErrorProvider1.SetError(txtDIR_ID_DOM, "Ingrese un código de dirección")
                        ValidarDireccionesCliente = False
                    Else
                        ErrorProvider1.SetError(txtDIR_ID_FIS, Nothing)
                        ErrorProvider1.SetError(txtDIR_ID_DOM, Nothing)
                    End If
                Case Else
            End Select
        End Function
        Private Sub VerificarGestores()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito,
                     BCVariablesNames.ProcesosFacturación.NotaDebito
                    GestoresNotas()
                Case Else
                    GestoresNotas()
                    GestoresVentas()
            End Select
        End Sub
        Private Sub GestoresNotas()
            If txtPER_ID_VEN.Text.Trim = "" Then
                MetodoBusquedaDato(BCVariablesNames.VendedorDefault, True, EtxtPER_ID_VEN)
            Else
                MetodoBusquedaDato(txtPER_ID_VEN.Text, True, EtxtPER_ID_VEN)
            End If
            If txtPER_ID_COB.Text.Trim = "" Then
                MetodoBusquedaDato(BCVariablesNames.CobradorDefault, True, EtxtPER_ID_COB)
            Else
                MetodoBusquedaDato(txtPER_ID_COB.Text, True, EtxtPER_ID_COB)
            End If
        End Sub
        Private Sub GestoresVentas()
            MetodoBusquedaDato(txtPER_ID_GRU.Text, True, EtxtPER_ID_GRU)
        End Sub
        '' ojito
        Private Sub ConfigurarFormulario(ByVal vControl As Integer)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.NotaCredito,
                     BCVariablesNames.ProcesosFacturación.NotaDebito
                    Notas(vControl)
                Case Else
                    Ventas(vControl)
            End Select
        End Sub


        Private Sub Notas(ByVal vControl As Integer)
            If vControl = 1 Then
                tcoDatos.SelectedIndex = 2
                ConfigurarDatos("tpaNotas")
                If Not DesignMode Then
                    RemoverTabs(tcoDatos, tpaVentas)
                    RemoverTabs(tcoDatos, tpaFinanzas)
                    RemoverTabs(tcoDirecciones, tpaCobranza)
                    RemoverTabs(tcoDirecciones, tpaEntrega)
                    RemoverTabs(tcoDirecciones, tpaRecepciona)
                    RemoverTabs(tcoGestores, tpaGrupo)
                    RemoverTabs(tcoGestores, tpaContacto)
                    RemoverTabs(tcoGestores, tpaPromotor)
                End If
            End If
            NuevoVentas(vControl) ' Habilita los controles
            NuevoNotas() ' Deshabilita los controles no necesarios para notas
            txtPER_ID_CLI.Focus()
        End Sub
        Private Sub NuevoNotas()
            ConfigurarReadOnlyNoBusqueda(txtTIV_ID, EtxtTIV_ID, True)

            dtpDOC_FECHA_ENT.Enabled = False
            'ConfigurarReadOnlyNoBusqueda(dtpDOC_FECHA_ENT, Nothing, True)

            txtDOC_ORDEN_COMPRA.Enabled = False
            'ConfigurarReadOnlyNoBusqueda(txtDOC_ORDEN_COMPRA, EtxtDOC_ORDEN_COMPRA, True)

            cboDOC_TIPO_ORDEN_COMPRA.Enabled = False
            'ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_ORDEN_COMPRA, EcboDOC_TIPO_ORDEN_COMPRA, True)

            dtpDOC_FECHA_EXP.Enabled = False
            'ConfigurarReadOnlyNoBusqueda(dtpDOC_FECHA_EXP, Nothing, True)

            ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, EcboDOC_TIPO_LISTA, True)
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID_DES, EtxtPVE_ID_DES, True)
            ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, True)

            ConfigurarReadOnly(txtDTD_ID_AFE, EtxtDTD_ID_AFE)
            EtxtDTD_ID_AFE.pBusqueda = True
        End Sub

        Private Sub RemoverTabs(ByRef vTabControl As TabControl, ByRef vTapPage As TabPage)
            vTabControl.TabPages.Remove(vTapPage)
        End Sub

        Private Sub Ventas(ByVal vControl As Integer)
            If vControl = 1 Then
                tcoDatos.SelectedIndex = 0
                ConfigurarDatos("tpaVentas")
                RemoverTabs(tcoDatos, tpaFinanzas)
                RemoverTabs(tcoDatos, tpaNotas)
                RemoverTabs(tcoDatos, tpaNotaAfectaMonto)
                RemoverTabs(tcoDatos, tpaNotaAfectaProducto)
            End If
            NuevoVentas(vControl) 'Habilita los controles
            PermisoCodigoVendedor()
        End Sub
        Private Sub PermisoCodigoVendedor()
            If SessionService.UserId <> "ADMIN" Then
                EtxtPER_ID_VEN.pBusqueda = False
                txtPER_ID_VEN.Enabled = False
            End If
            EtxtPER_ID_VEN.pBusqueda = True
            txtPER_ID_VEN.Enabled = True
        End Sub

        Private Sub NuevoVentas(Optional ByVal vControl As Integer = 0)
            DesBloquearBloquearControlesXModificar(False)
        End Sub


        Private Sub DesBloquearBloquearControlesXModificar(ByVal vFlagBloquear As Boolean, Optional ByVal vControl As Int16 = 1)
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, vFlagBloquear) ' BLoquea
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, vFlagBloquear) ' BLoquea

            ConfigurarReadOnlyNoBusqueda(txtDOC_SERIE, EtxtDOC_SERIE, True) ' BLoquea
            ConfigurarReadOnlyNoBusqueda(txtDOC_NUMERO, EtxtDOC_NUMERO, True) ' BLoquea


            ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, vFlagBloquear) ' BLoquea
            ControlVisible(cboSerieCorrelativo, Not vFlagBloquear) ' Oculta
            ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, EcboDOC_TIPO_LISTA, vFlagBloquear) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID_DES, EtxtPVE_ID_DES, vFlagBloquear) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, vFlagBloquear) ' Bloquea
            'ProcesarCboDOC_TIPO_LISTA() ' Proceso de validación de CboDOC_TIPO_LISTA
            Select Case vControl
                Case 1
                Case Else
                    ProcesarCboDOC_TIPO_LISTA() ' Proceso de validación de CboDOC_TIPO_LISTA
            End Select
            vTextChangedDOC_TIPO_LISTA = False

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosFacturación.PedidoBoleta,
                     BCVariablesNames.ProcesosFacturación.PedidoFactura
                    btnImpresion.Enabled = True
                Case Else
                    btnImpresion.Enabled = True
            End Select

        End Sub

        Private Sub DesbloquearBloquearControlesXNuevo()
            NuevoVentas()
        End Sub

        '' ojito - Inhabilita/Habilita los campos que no se deben modificar cuando el grid no esta vacio
        Private Sub ProcesarGridVacio(Optional ByVal vControl As Integer = 0)
            If dgvDetalle.RowCount = 0 Then ' Habilita
                ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, False)
                ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)

                ConfigurarReadOnlyNoBusqueda(dtpDOC_FECHA_EMI, EdtpDOC_FECHA_EMI, False)

                ConfigurarReadOnlyNoBusqueda(txtTIV_ID, EtxtTIV_ID, False)
                ConfigurarReadOnlyNoBusqueda(txtMON_ID, EtxtMON_ID, False)

                If pRegistroNuevo Then
                    ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True)
                    ConfigurarReadOnlyNoBusqueda(txtTDP_ID_CLI, EtxtTDP_ID_CLI, True)
                Else
                    ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, False)
                    ConfigurarReadOnlyNoBusqueda(txtTDP_ID_CLI, EtxtTDP_ID_CLI, False)
                End If

                ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, EcboDOC_TIPO_LISTA, False)
                ConfigurarReadOnlyNoBusqueda(txtPVE_ID_DES, EtxtPVE_ID_DES, False)
                ConfigurarReadOnlyNoBusqueda(txtLPR_ID, EtxtLPR_ID, False)
                ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, False)

                ConfigurarReadOnly(txtDTD_ID_AFE, EtxtDTD_ID_AFE)
                EtxtDTD_ID_AFE.pBusqueda = True

                Select Case vControl
                    Case 1
                    Case Else
                        ProcesarCboDOC_TIPO_LISTA() ' Proceso de validación de CboDOC_TIPO_LISTA
                End Select

            End If
            If dgvDetalle.RowCount >= 1 Then ' Inhabilita
                ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, True)
                ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, True)

                ConfigurarReadOnlyNoBusqueda(dtpDOC_FECHA_EMI, EdtpDOC_FECHA_EMI, True)

                ConfigurarReadOnlyNoBusqueda(txtTIV_ID, EtxtTIV_ID, True)
                ConfigurarReadOnlyNoBusqueda(txtMON_ID, EtxtMON_ID, True)
                ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True)
                ConfigurarReadOnlyNoBusqueda(txtTDP_ID_CLI, EtxtTDP_ID_CLI, True)

                ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, EcboDOC_TIPO_LISTA, True)
                ConfigurarReadOnlyNoBusqueda(txtPVE_ID_DES, EtxtPVE_ID_DES, True)
                ConfigurarReadOnlyNoBusqueda(txtLPR_ID, EtxtLPR_ID, True)
                ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, True)

                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosFacturación.NotaCredito
                    Case Else
                        ConfigurarReadOnlyNoBusqueda(txtDTD_ID_AFE, EtxtDTD_ID_AFE, True)
                End Select
            End If
            FiltrocboDOC_TIPO_LISTA(False)
        End Sub

        Public Sub ProcesarFechaServidor()
            dtpDOC_FECHA_EMI.Text = IBCMaestro.EjecutarVista("spFechaServidor")
            tslFechaServidor.Text = "Fecha de trabajo: " & dtpDOC_FECHA_EMI.Text
        End Sub
        Public Sub ProcesarTipoCambioMoneda()
            If txtMON_ID.Text = "" Then
                tslTipoCambioCompraMoneda.Text = ""
                tslTipoCambioVentaMoneda.Text = ""
                TipoCambioCompraMoneda = 0
                TipoCambioVentaMoneda = 0
                lblMON_SIMBOLO_1.Text = ""
                lblMON_SIMBOLO_2.Text = ""
                Exit Sub
            End If
            If BCVariablesNames.MonedaSistema <> txtMON_ID.Text Then
                Dim ds As New DataSet
                Dim sr As New StringReader(IBCMaestro.EjecutarVista("spCambioDiaXML", BCVariablesNames.MonedaSistema, txtMON_ID.Text, cMisProcedimientos.FormatoFechaGenerico(dtpDOC_FECHA_EMI.Text)))
                Dim vcontrol As Int16 = sr.Peek
                If vcontrol <> -1 Then
                    ds.ReadXml(sr)
                    tslTipoCambioCompraMoneda.Text = "Cambio del día: " & ds.Tables(0).Rows(0).Item("MON_SIMBOLO_0").ToString & " 1.0000  -  " & _
                                               "Compra: " & ds.Tables(0).Rows(0).Item("MON_SIMBOLO_1").ToString & _
                                                                                      ds.Tables(0).Rows(0).Item("TCA_COMPRA").ToString
                    tslTipoCambioVentaMoneda.Text = "Venta: " & ds.Tables(0).Rows(0).Item("MON_SIMBOLO_1").ToString & _
                                              ds.Tables(0).Rows(0).Item("TCA_VENTA").ToString
                    TipoCambioCompraMoneda = ds.Tables(0).Rows(0).Item("TCA_COMPRA")
                    TipoCambioVentaMoneda = ds.Tables(0).Rows(0).Item("TCA_VENTA")
                    ErrorProvider1.SetError(txtMON_ID, Nothing)
                Else
                    tslTipoCambioCompraMoneda.Text = "Cambio del día: " & txtMON_SIMBOLO.Text & " 1.0000  -  Compra: 0.0000"
                    tslTipoCambioVentaMoneda.Text = "Venta: 0.0000"
                    TipoCambioCompraMoneda = 0
                    TipoCambioVentaMoneda = 0
                    ErrorProvider1.SetError(txtMON_ID, "No se encuentra el tipo de cambio para la fecha de emisión")
                End If
            Else
                tslTipoCambioCompraMoneda.Text = "Cambio del día: ? 1.0000  -  Compra: 0.0000"
                tslTipoCambioVentaMoneda.Text = "Venta: 0.0000"
                TipoCambioCompraMoneda = 1
                TipoCambioVentaMoneda = 1
                ErrorProvider1.SetError(txtMON_ID, Nothing)
            End If

            lblMON_SIMBOLO_1.Text = txtMON_SIMBOLO.Text
            lblMON_SIMBOLO_2.Text = txtMON_SIMBOLO.Text
        End Sub

        Private Sub ConfigurarDirecciones(ByVal vNombreTabPage As String)
            Select Case vNombreTabPage
                Case "tpaFiscal"
                    HabilitarDirecciones("Fiscal", True)
                    HabilitarDirecciones("Domicilio", False)
                    HabilitarDirecciones("Cobranza", False)
                    HabilitarDirecciones("Entrega", False)
                    HabilitarDirecciones("Persona que recepciona", False)
                Case "tpaDomicilio"
                    HabilitarDirecciones("Fiscal", False)
                    HabilitarDirecciones("Domicilio", True)
                    HabilitarDirecciones("Cobranza", False)
                    HabilitarDirecciones("Entrega", False)
                    HabilitarDirecciones("Persona que recepciona", False)
                Case "tpaCobranza"
                    HabilitarDirecciones("Fiscal", False)
                    HabilitarDirecciones("Domicilio", False)
                    HabilitarDirecciones("Cobranza", True)
                    HabilitarDirecciones("Entrega", False)
                    HabilitarDirecciones("Persona que recepciona", False)
                Case "tpaEntrega"
                    HabilitarDirecciones("Fiscal", False)
                    HabilitarDirecciones("Domicilio", False)
                    HabilitarDirecciones("Cobranza", False)
                    HabilitarDirecciones("Entrega", True)
                    HabilitarDirecciones("Persona que recepciona", False)
                Case "tpaRecepciona"
                    HabilitarDirecciones("Fiscal", False)
                    HabilitarDirecciones("Domicilio", False)
                    HabilitarDirecciones("Cobranza", False)
                    HabilitarDirecciones("Entrega", False)
                    HabilitarDirecciones("Persona que recepciona", True)
            End Select
        End Sub
        Private Sub HabilitarDirecciones(ByVal vTipoDir As String, ByVal vBoolean As Boolean)
            Select Case vTipoDir
                Case "Fiscal"
                    ControlEnabled(txtDIR_ID_FIS, vBoolean)
                    ControlVisible(txtDIR_ID_FIS, vBoolean)
                    ControlVisible(txtDIR_DESCRIPCION_FIS, vBoolean)
                    ControlVisible(txtDIR_REFERENCIA_FIS, vBoolean)
                    ControlVisible(txtDIS_ID_FIS, vBoolean)
                    ControlVisible(txtDIS_DESCRIPCION_FIS, vBoolean)
                    ControlVisible(txtPRO_ID_FIS, vBoolean)
                    ControlVisible(txtPRO_DESCRIPCION_FIS, vBoolean)
                    ControlVisible(txtDEP_ID_FIS, vBoolean)
                    ControlVisible(txtDEP_DESCRIPCION_FIS, vBoolean)
                    ControlVisible(txtPAI_ID_FIS, vBoolean)
                    ControlVisible(txtPAI_DESCRIPCION_FIS, vBoolean)
                Case "Domicilio"
                    ControlEnabled(txtDIR_ID_DOM, vBoolean)
                    ControlVisible(txtDIR_ID_DOM, vBoolean)
                    ControlVisible(txtDIR_DESCRIPCION_DOM, vBoolean)
                    ControlVisible(txtDIR_REFERENCIA_DOM, vBoolean)
                    ControlVisible(txtDIS_ID_DOM, vBoolean)
                    ControlVisible(txtDIS_DESCRIPCION_DOM, vBoolean)
                    ControlVisible(txtPRO_ID_DOM, vBoolean)
                    ControlVisible(txtPRO_DESCRIPCION_DOM, vBoolean)
                    ControlVisible(txtDEP_ID_DOM, vBoolean)
                    ControlVisible(txtDEP_DESCRIPCION_DOM, vBoolean)
                    ControlVisible(txtPAI_ID_DOM, vBoolean)
                    ControlVisible(txtPAI_DESCRIPCION_DOM, vBoolean)
                Case "Cobranza"
                    ControlEnabled(txtDIR_ID_COB, vBoolean)
                    ControlVisible(txtDIR_ID_COB, vBoolean)
                    ControlVisible(txtDIR_DESCRIPCION_COB, vBoolean)
                    ControlVisible(txtDIR_REFERENCIA_COB, vBoolean)
                    ControlVisible(txtDIS_ID_COB, vBoolean)
                    ControlVisible(txtDIS_DESCRIPCION_COB, vBoolean)
                    ControlVisible(txtPRO_ID_COB, vBoolean)
                    ControlVisible(txtPRO_DESCRIPCION_COB, vBoolean)
                    ControlVisible(txtDEP_ID_COB, vBoolean)
                    ControlVisible(txtDEP_DESCRIPCION_COB, vBoolean)
                    ControlVisible(txtPAI_ID_COB, vBoolean)
                    ControlVisible(txtPAI_DESCRIPCION_COB, vBoolean)
                Case "Entrega"
                    ControlEnabled(txtDIR_ID_ENT, vBoolean)
                    ControlVisible(txtDIR_ID_ENT, vBoolean)
                    ControlVisible(txtDIR_DESCRIPCION_ENT, vBoolean)
                    ControlVisible(txtDIR_REFERENCIA_ENT, vBoolean)
                    ControlVisible(txtDIS_ID_ENT, vBoolean)
                    ControlVisible(txtDIS_DESCRIPCION_ENT, vBoolean)
                    ControlVisible(txtPRO_ID_ENT, vBoolean)
                    ControlVisible(txtPRO_DESCRIPCION_ENT, vBoolean)
                    ControlVisible(txtDEP_ID_ENT, vBoolean)
                    ControlVisible(txtDEP_DESCRIPCION_ENT, vBoolean)
                    ControlVisible(txtPAI_ID_ENT, vBoolean)
                    ControlVisible(txtPAI_DESCRIPCION_ENT, vBoolean)
                Case "Persona que recepciona"
                    ControlVisible(lblPER_ID_REC, vBoolean)
                    ControlEnabled(txtPER_ID_REC, vBoolean)
                    ControlVisible(txtPER_ID_REC, vBoolean)
                    ControlVisible(txtPER_DESCRIPCION_REC, vBoolean)

                    ControlVisible(lblTDP_ID_REC, vBoolean)
                    ControlEnabled(txtTDP_ID_REC, vBoolean)
                    ControlVisible(txtTDP_ID_REC, vBoolean)
                    ControlVisible(txtTDP_DESCRIPCION_REC, vBoolean)
                    ControlVisible(txtDOP_NUMERO_REC, vBoolean)

                    ControlEnabled(txtDIR_ID_ENT_REC, vBoolean)
                    ControlVisible(txtDIR_ID_ENT_REC, vBoolean)
                    ControlVisible(txtDIR_DESCRIPCION_ENT_REC, vBoolean)
                    ControlVisible(txtDIR_REFERENCIA_ENT_REC, vBoolean)
            End Select
        End Sub
        Private Sub tcoDirecciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcoDirecciones.SelectedIndexChanged
            ConfigurarDirecciones(tcoDirecciones.SelectedTab.Name)
        End Sub

        Private Sub ConfigurarGestores(ByVal vNombreTabPage As String)
            Select Case vNombreTabPage
                Case "tpaVendedor"
                    HabilitarGestores("Vendedor", True)
                    HabilitarGestores("Cobrador", False)
                    HabilitarGestores("Grupo", False)
                    HabilitarGestores("Contacto", False)
                    HabilitarGestores("Promotor", False)
                Case "tpaCobrador"
                    HabilitarGestores("Vendedor", False)
                    HabilitarGestores("Cobrador", True)
                    HabilitarGestores("Grupo", False)
                    HabilitarGestores("Contacto", False)
                    HabilitarGestores("Promotor", False)
                Case "tpaGrupo"
                    HabilitarGestores("Vendedor", False)
                    HabilitarGestores("Cobrador", False)
                    HabilitarGestores("Grupo", True)
                    HabilitarGestores("Contacto", False)
                    HabilitarGestores("Promotor", False)
                Case "tpaContacto"
                    HabilitarGestores("Vendedor", False)
                    HabilitarGestores("Cobrador", False)
                    HabilitarGestores("Grupo", False)
                    HabilitarGestores("Contacto", True)
                    HabilitarGestores("Promotor", False)
                Case "tpaPromotor"
                    HabilitarGestores("Vendedor", False)
                    HabilitarGestores("Cobrador", False)
                    HabilitarGestores("Grupo", False)
                    HabilitarGestores("Contacto", False)
                    HabilitarGestores("Promotor", True)
            End Select
        End Sub
        Private Sub HabilitarGestores(ByVal vTipoGestor As String, ByVal vBoolean As Boolean)
            Select Case vTipoGestor
                Case "Vendedor"
                    ControlEnabled(txtPER_ID_VEN, vBoolean)
                    ControlVisible(txtPER_ID_VEN, vBoolean)
                    ControlVisible(txtPER_DESCRIPCION_VEN, vBoolean)
                    PermisoCodigoVendedor()
                Case "Cobrador"
                    ControlEnabled(txtPER_ID_COB, vBoolean)
                    ControlVisible(txtPER_ID_COB, vBoolean)
                    ControlVisible(txtPER_DESCRIPCION_COB, vBoolean)
                Case "Grupo"
                    ControlEnabled(txtPER_ID_GRU, vBoolean)
                    ControlVisible(txtPER_ID_GRU, vBoolean)
                    ControlVisible(txtPER_DESCRIPCION_GRU, vBoolean)
                Case "Contacto"
                    ControlEnabled(txtPER_ID_CON, vBoolean)
                    ControlVisible(txtPER_ID_CON, vBoolean)
                    ControlVisible(txtPER_DESCRIPCION_CON, vBoolean)
                Case "Promotor"
                    ControlEnabled(txtPER_ID_PRO, vBoolean)
                    ControlVisible(txtPER_ID_PRO, vBoolean)
                    ControlVisible(txtPER_DESCRIPCION_PRO, vBoolean)
            End Select
        End Sub
        Private Sub tcoGestores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcoGestores.SelectedIndexChanged
            ConfigurarGestores(tcoGestores.SelectedTab.Name)
        End Sub

        Private Sub ConfigurarDatos(ByVal vNombreTabPage As String)
            Select Case vNombreTabPage
                Case "tpaVentas"
                    HabilitarDatos("Finanzas", False)
                    HabilitarDatos("Notas", False)
                    HabilitarDatos("NotaAfectaMonto", False)
                    HabilitarDatos("NotaAfectaProducto", False)
                    HabilitarDatos("Ventas", True)
                Case "tpaFinanzas"
                    HabilitarDatos("Ventas", False)
                    HabilitarDatos("Notas", False)
                    HabilitarDatos("NotaAfectaMonto", False)
                    HabilitarDatos("NotaAfectaProducto", False)
                    HabilitarDatos("Finanzas", True)
                Case "tpaNotas"
                    HabilitarDatos("Ventas", False)
                    HabilitarDatos("Finanzas", False)
                    HabilitarDatos("NotaAfectaMonto", False)
                    HabilitarDatos("NotaAfectaProducto", False)
                    HabilitarDatos("Notas", True)
                Case "tpaNotaAfectaMonto"
                    HabilitarDatos("Ventas", False)
                    HabilitarDatos("Finanzas", False)
                    HabilitarDatos("Notas", False)
                    HabilitarDatos("NotaAfectaProducto", False)
                    HabilitarDatos("NotaAfectaMonto", True)
                Case "tpaNotaAfectaProducto"
                    HabilitarDatos("Ventas", False)
                    HabilitarDatos("Finanzas", False)
                    HabilitarDatos("Notas", False)
                    HabilitarDatos("NotaAfectaMonto", False)
                    HabilitarDatos("NotaAfectaProducto", True)
            End Select
        End Sub
        Private Sub HabilitarDatos(ByVal vTipoGestor As String, ByVal vBoolean As Boolean)
            Select Case vTipoGestor
                Case "Ventas"
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosFacturación.PedidoBoleta, BCVariablesNames.ProcesosFacturación.PedidoFactura
                            lblDOC_ATENCION.Visible = True
                            txtDOC_ATENCION.Enabled = True
                            txtDOC_ATENCION.Visible = True
                        Case Else
                            lblDOC_ATENCION.Visible = False
                            txtDOC_ATENCION.Enabled = False
                            txtDOC_ATENCION.Visible = False
                    End Select
                    lblDOC_TIPO_LISTA.Visible = vBoolean
                    cboDOC_TIPO_LISTA.Visible = vBoolean

                    lblPVE_ID_DES.Visible = vBoolean
                    txtPVE_ID_DES.Visible = vBoolean
                    txtPVE_DESCRIPCION_DES.Visible = vBoolean

                    lblLPR_ID.Visible = vBoolean
                    txtLPR_ID.Visible = vBoolean
                    txtLPR_DESCRIPCION.Visible = vBoolean

                    lblFLE_ID.Visible = vBoolean
                    txtFLE_ID.Visible = vBoolean
                    txtFLE_DESCRIPCION.Visible = vBoolean

                    lblDOC_MONTO_FLE.Visible = False ' vBoolean
                    txtDOC_MONTO_FLE.Visible = False ' vBoolean

                    lblCCT_ID.Visible = vBoolean
                    txtCCT_ID.Visible = vBoolean
                    txtCCT_DESCRIPCION.Visible = vBoolean

                    lblDOC_ESTADO.Visible = vBoolean
                    cboDOC_ESTADO.Visible = vBoolean

                    lblDOC_OBSERVACIONES.Visible = vBoolean
                    txtDOC_OBSERVACIONES.Visible = vBoolean

                    lblCAF_IX_NUMERO_PRO.Visible = vBoolean
                    txtCAF_IX_NUMERO_PRO.Visible = vBoolean

                    lblCAF_IX_ORDEN_COM.Visible = vBoolean
                    txtCAF_IX_ORDEN_COM.Visible = vBoolean
                Case "Finanzas"
                    lblDOC_ENTREGADO.Visible = vBoolean
                    chkDOC_ENTREGADO.Visible = vBoolean

                    lblDOC_ASIENTO.Visible = vBoolean
                    chkDOC_ASIENTO.Visible = vBoolean

                    lblDOC_CIERRE.Visible = vBoolean
                    cboDOC_CIERRE.Visible = vBoolean

                    lblDOC_REQUIERE_GUIA.Visible = vBoolean
                    chkDOC_REQUIERE_GUIA.Visible = vBoolean
                Case "Notas"
                    lblDTD_ID_AFE.Visible = vBoolean
                    txtDTD_ID_AFE.Visible = vBoolean
                    txtDTD_DESCRIPCION_AFE.Visible = vBoolean

                    lblCCT_ID_AFE.Visible = vBoolean
                    txtCCT_ID_AFE.Visible = vBoolean
                    txtCCT_DESCRIPCION_AFE.Visible = vBoolean

                    lblDOC_SERIE_AFE.Visible = vBoolean
                    txtDOC_SERIE_AFE.Visible = vBoolean
                    lblSeparador1.Visible = vBoolean
                    txtDOC_NUMERO_AFE.Visible = vBoolean

                    lblMONTO_AFE.Visible = vBoolean
                    lblMON_SIMBOLO_AFE.Visible = vBoolean
                    txtMONTO_AFE.Visible = vBoolean

                    lblDOC_MOT_EMI.Visible = vBoolean
                    cboDOC_MOT_EMI.Visible = vBoolean

                    lblDOC_NOMBRE_RECEP.Visible = vBoolean
                    txtDOC_NOMBRE_RECEP.Visible = vBoolean

                    lblDOC_DNI_RECEP.Visible = vBoolean
                    txtDOC_DNI_RECEP.Visible = vBoolean

                    lblDOC_FEC_RECEP.Visible = vBoolean
                    dtpDOC_FEC_RECEP.Visible = vBoolean

                    lblDOC_ESTADO.Visible = vBoolean
                    cboDOC_ESTADO.Visible = vBoolean

                    lblDOC_OBSERVACIONES.Visible = vBoolean
                    txtDOC_OBSERVACIONES.Visible = vBoolean

                    btnPasarAfectaMonto.Visible = vBoolean
                    btnPasarAfectaProducto.Visible = vBoolean
                Case "NotaAfectaMonto"
                    dgvDetalleAfectaMonto.Visible = vBoolean
                Case "NotaAfectaProducto"
                    dgvDetalleAfectaProducto.Visible = vBoolean
            End Select
        End Sub
        Private Sub tcoDatos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcoDatos.SelectedIndexChanged
            ConfigurarDatos(tcoDatos.SelectedTab.Name)
        End Sub

        Private Sub cboSerieCorrelativo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerieCorrelativo.TextChanged
            ProcesarSerie()
        End Sub
        Private Sub cboSerieCorrelativo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerieCorrelativo.Validated
            ProcesarSerie()
        End Sub

        Private Sub ProcesarSerie()
            If cboSerieCorrelativo.DataSource Is Nothing Then Exit Sub
            ConfigurarReadOnlyNoBusqueda(txtDOC_SERIE, EtxtDOC_SERIE, True) ' BLoquea

            txtDOC_SERIE.Text = cboSerieCorrelativo.Text
            txtDOC_NUMERO.Text = cboSerieCorrelativo.SelectedValue.ToString
            If txtDOC_NUMERO.Text = "0" Then
                Compuesto2.CTD_USAR_COR = 0
                ConfigurarReadOnlyNoBusqueda(txtDOC_NUMERO, EtxtDOC_NUMERO, False)
            Else
                Compuesto2.CTD_USAR_COR = 1
                ConfigurarReadOnlyNoBusqueda(txtDOC_NUMERO, EtxtDOC_NUMERO, True)
            End If
        End Sub
        Private Sub BuscarSeries()
            Compuesto1.Vista = "BuscarCorrelativos"
            Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()

            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                txtPVE_ID.Text, _
                                                                txtTDO_ID.Text, _
                                                                txtDTD_ID.Text, _
                                                                Nothing, _
                                                                " And PVE_ID+CTD_COR_SERIE  In (select PVE_ID+CTD_COR_SERIE from vwSeriesDatosUsuarios " & _
                                                                                               "where USU_ID='" & SessionService.UserId & "' and TDO_ID='" & txtTDO_ID.Text & "' and SDU_ESTADO='ACTIVO')"
                                                               )
                                      )

            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                cboSerieCorrelativo.DataSource = ds.Tables(0)
                cboSerieCorrelativo.DisplayMember = "CTD_COR_SERIE"
                cboSerieCorrelativo.ValueMember = "CTD_COR_NUMERO"
                ProcesarSerie()
            Else
                cboSerieCorrelativo.DataSource = Nothing
                txtDOC_NUMERO.Text = ""
            End If
        End Sub
        Private Sub ActualizarCorrelativo()
            Compuesto1.Vista = "BuscarCorrelativos"
            Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()

            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                txtPVE_ID.Text, _
                                                                txtTDO_ID.Text, _
                                                                txtDTD_ID.Text, _
                                                                txtDOC_SERIE.Text, _
                                                                " And PVE_ID+CTD_COR_SERIE  In (select PVE_ID+CTD_COR_SERIE from vwSeriesDatosUsuarios " & _
                                                                                               "where USU_ID='" & SessionService.UserId & "' and TDO_ID='" & txtTDO_ID.Text & "' and SDU_ESTADO='ACTIVO')"
                                                               )
                                      )

            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                cboSerieCorrelativo.DataSource = ds.Tables(0)
                cboSerieCorrelativo.DisplayMember = "CTD_COR_SERIE"
                cboSerieCorrelativo.ValueMember = "CTD_COR_NUMERO"
                txtDOC_SERIE.Text = cboSerieCorrelativo.Text
                txtDOC_NUMERO.Text = cboSerieCorrelativo.SelectedValue.ToString
            Else
                cboSerieCorrelativo.DataSource = Nothing
                txtDOC_SERIE.Text = ""
                txtDOC_NUMERO.Text = ""
            End If
        End Sub

        Private Sub cboDOC_TIPO_LISTA_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDOC_TIPO_LISTA.Validated
            ValidarCboDOC_TIPO_LISTA()
        End Sub
        Private Sub ValidarCboDOC_TIPO_LISTA()
            If vTextChangedDOC_TIPO_LISTA Then
                ProcesarCboDOC_TIPO_LISTA()
            End If
            vTextChangedDOC_TIPO_LISTA = False
        End Sub
        Private Sub cboDOC_TIPO_LISTA_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles cboDOC_TIPO_LISTA.SelectedValueChanged
            vTextChangedDOC_TIPO_LISTA = True
        End Sub

        Private Sub ProcesarCboDOC_TIPO_LISTA()
            pPrecioEspecialCliente = VerificarPrecioEspecialPersona()
            FiltroPVE_ID()
            LlamadasPVE_ID()
            If cboDOC_TIPO_LISTA.Text = "PLANTA" Or _
               cboDOC_TIPO_LISTA.Text = "PUNTO DE VENTA" Then
                txtFLE_ID.Text = ""
                ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, True)
            Else
                ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, False)
            End If
        End Sub

        Private Sub dtpDOC_FECHA_EMI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDOC_FECHA_EMI.ValueChanged
            ProcesarTipoCambioMoneda()
        End Sub

        Private Sub txt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtDOC_SERIE.Enter, _
                    txtMON_SIMBOLO.Enter, _
                    txtMON_DESCRIPCION.Enter, _
                    txtTIV_DESCRIPCION.Enter, _
                    txtDOC_IGV_POR.Enter, _
                    txtPER_DESCRIPCION_CLI.Enter, _
                    txtTDP_DESCRIPCION_CLI.Enter, _
                    txtDOP_NUMERO_CLI.Enter, _
                    txtDIR_DESCRIPCION_FIS.Enter, _
                    txtDIR_REFERENCIA_FIS.Enter, _
                    txtDIS_ID_FIS.Enter, _
                    txtDIS_DESCRIPCION_FIS.Enter, _
                    txtPRO_ID_FIS.Enter, _
                    txtPRO_DESCRIPCION_FIS.Enter, _
                    txtDEP_ID_FIS.Enter, _
                    txtDEP_DESCRIPCION_FIS.Enter, _
                    txtPAI_ID_FIS.Enter, _
                    txtPAI_DESCRIPCION_FIS.Enter, _
                    txtDIR_DESCRIPCION_DOM.Enter, _
                    txtDIR_REFERENCIA_DOM.Enter, _
                    txtDIS_ID_DOM.Enter, _
                    txtDIS_DESCRIPCION_DOM.Enter, _
                    txtPRO_ID_DOM.Enter, _
                    txtPRO_DESCRIPCION_DOM.Enter, _
                    txtDEP_ID_DOM.Enter, _
                    txtDEP_DESCRIPCION_DOM.Enter, _
                    txtPAI_ID_DOM.Enter, _
                    txtPAI_DESCRIPCION_DOM.Enter, _
                    txtDIR_DESCRIPCION_COB.Enter, _
                    txtDIR_REFERENCIA_COB.Enter, _
                    txtDIS_ID_COB.Enter, _
                    txtDIS_DESCRIPCION_COB.Enter, _
                    txtPRO_ID_COB.Enter, _
                    txtPRO_DESCRIPCION_COB.Enter, _
                    txtDEP_ID_COB.Enter, _
                    txtDEP_DESCRIPCION_COB.Enter, _
                    txtPAI_ID_COB.Enter, _
                    txtPAI_DESCRIPCION_COB.Enter, _
                    txtDIR_DESCRIPCION_ENT.Enter, _
                    txtDIR_REFERENCIA_ENT.Enter, _
                    txtDIS_ID_ENT.Enter, _
                    txtDIS_DESCRIPCION_ENT.Enter, _
                    txtPRO_ID_ENT.Enter, _
                    txtPRO_DESCRIPCION_ENT.Enter, _
                    txtDEP_ID_ENT.Enter, _
                    txtDEP_DESCRIPCION_ENT.Enter, _
                    txtPAI_ID_ENT.Enter, _
                    txtPAI_DESCRIPCION_ENT.Enter, _
                    txtPER_DESCRIPCION_REC.Enter, _
                    txtTDP_DESCRIPCION_REC.Enter, _
                    txtDOP_NUMERO_REC.Enter, _
                    txtDIR_DESCRIPCION_ENT_REC.Enter, _
                    txtDIR_REFERENCIA_ENT_REC.Enter, _
                    txtDIS_ID_ENT_REC.Enter, _
                    txtDIS_DESCRIPCION_ENT_REC.Enter, _
                    txtPRO_ID_ENT_REC.Enter, _
                    txtPRO_DESCRIPCION_ENT_REC.Enter, _
                    txtDEP_ID_ENT_REC.Enter, _
                    txtDEP_DESCRIPCION_ENT_REC.Enter, _
                    txtPAI_ID_ENT_REC.Enter, _
                    txtPAI_DESCRIPCION_ENT_REC.Enter, _
                    txtPER_DESCRIPCION_VEN.Enter, _
                    txtPER_DESCRIPCION_COB.Enter, _
                    txtPER_DESCRIPCION_GRU.Enter, _
                    txtPER_DESCRIPCION_CON.Enter, _
                    txtPER_DESCRIPCION_PRO.Enter, _
                    txtPVE_DESCRIPCION_DES.Enter, _
                    txtLPR_DESCRIPCION.Enter, _
                    txtFLE_DESCRIPCION.Enter, _
                    txtDOC_MONTO_FLE.Enter, _
                    txtCCT_DESCRIPCION.Enter, _
                    txtCAF_IX_ORDEN_COM.Enter, _
                    txtTotalBruto.Enter, _
                    txtTotDescInc.Enter, _
                    txtExonerado.Enter, _
                    txtBaseImponible.Enter, _
                    txtTotalIGV.Enter, _
                    txtDOC_MONTO_TOTAL.Enter, _
                    cboDOC_TIPO_LISTA.Enter, _
                    dtpDOC_FECHA_EMI.Enter, _
                    txtCCT_ID.Enter

            If sender.GetType <> GetType(ComboBox) And _
                sender.GetType <> GetType(DateTimePicker) Then
                If sender.ReadOnly Then SendKeys.Send(Chr(Keys.Tab))
            Else
                If EnabledObjeto(sender.name) Then SendKeys.Send(Chr(Keys.Tab))
            End If
        End Sub
        Private Function EnabledObjeto(ByVal vName As String) As Boolean
            EnabledObjeto = True
            Select Case vName
                Case "cboDOC_TIPO_LISTA"
                    EnabledObjeto = Not EcboDOC_TIPO_LISTA.pEnabled
                Case "dtpDOC_FECHA_EMI"
                    EnabledObjeto = Not EdtpDOC_FECHA_EMI.pEnabled
            End Select
        End Function
        Public Sub ProcesarPrecios()
            If txtFLE_ID.Text.Trim <> "" Then
                dgvDetalle.Item("cDDO_PRE_UNI", dgvDetalle.CurrentRow.Index).Value = pDLP_PRECIO_UNITARIO + pDLP_RECARGO_ENVIO
            Else
                dgvDetalle.Item("cDDO_PRE_UNI", dgvDetalle.CurrentRow.Index).Value = pDLP_PRECIO_UNITARIO
            End If
        End Sub
        Public Sub ProcesarAnticipos()
            If Not ArticuloAnticipo(pMontoAnticipo) Then
                MsgBox("No se pudo anexar artículo anticipo", MsgBoxStyle.Information, Me.Text)
            End If

            '' OJITO NO  BORRAR ''

            'Dim vFilGrid As Int16 = 0
            'Dim vMontoDescontar As Double = 0
            'While (dgvDetalle.Rows.Count() > vFilGrid)
            '    With dgvDetalle.Rows(vFilGrid)
            '        If pMontoAnticipo = 0 Then Exit While
            '        If CDbl(.Cells("cDDO_DES_INC_PRE").Value) = 0 And _
            '           Trim(.Cells("cART_ID_IMP").Value) <> "" And _
            '           CDbl(.Cells("cDDO_CANTIDAD").Value) <> 0 And _
            '           CDbl(.Cells("cDDO_PRE_UNI").Value) <> 0 Then
            '            Select Case .Cells("cDDO_INC_IGV").Value
            '                Case BCVariablesNames.IncluyeIgv.NoIncluyeIGV
            '                    vMontoDescontar = CDbl(.Cells("cDDO_CANTIDAD").Value) * CDbl(.Cells("cDDO_PRE_UNI").Value)
            '                Case Else
            '                    vMontoDescontar = CDbl(.Cells("cDDO_PRE_TOTAL").Value)
            '            End Select
            '            If pMontoAnticipo > vMontoDescontar Then
            '                pMontoAnticipo = pMontoAnticipo - vMontoDescontar
            '                .Cells("cDDO_DES_INC_PRE").Value = vMontoDescontar * -1
            '            Else
            '                .Cells("cDDO_DES_INC_PRE").Value = pMontoAnticipo * -1
            '                pMontoAnticipo = pMontoAnticipo - pMontoAnticipo
            '            End If
            '            .Cells("cTDO_ID_ANT").Value = pTDO_ID_ANT
            '            .Cells("cDTD_ID_ANT").Value = pDTD_ID_ANT
            '            .Cells("cCCT_ID_ANT").Value = pCCT_ID_ANT
            '            .Cells("cDDO_SERIE_ANT").Value = pDDO_SERIE_ANT
            '            .Cells("cDDO_NUMERO_ANT").Value = pDDO_NUMERO_ANT
            '        End If
            '    End With
            '    ProcesarTotalArticulo(vFilGrid)
            '    vFilGrid += 1
            'End While
        End Sub
        Private Function ArticuloAnticipo(ByVal pMontoAnticipo As Double, _
                                          Optional ByVal vProcesarMontoAnticipo As Boolean = False) As Object
            ArticuloAnticipo = False
            Dim vMontoAnticipo As Double = pMontoAnticipo
            Dim vFilGrid As Int16 = 0
            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    If .Cells("cTDO_ID_ANT").Value = pTDO_ID_ANT And
                       .Cells("cDTD_ID_ANT").Value = pDTD_ID_ANT And
                       .Cells("cCCT_ID_ANT").Value = pCCT_ID_ANT And
                       .Cells("cDDO_SERIE_ANT").Value = pDDO_SERIE_ANT And
                       .Cells("cDDO_NUMERO_ANT").Value = pDDO_NUMERO_ANT Then

                        If pMontoAnticipo > (CDbl(txtDOC_MONTO_TOTAL.Text) + (.Cells("cDDO_DES_INC_PRE").Value * -1)) Then
                            pMontoAnticipo = (CDbl(txtDOC_MONTO_TOTAL.Text) + (.Cells("cDDO_DES_INC_PRE").Value * -1))
                        End If

                        If vProcesarMontoAnticipo Then

                            If (pMontoAnticipo * -1) > (CDbl(txtDOC_MONTO_TOTAL.Text) + (.Cells("cDDO_DES_INC_PRE").Value * -1)) Then
                                pMontoAnticipo = (CDbl(txtDOC_MONTO_TOTAL.Text) + (.Cells("cDDO_DES_INC_PRE").Value * -1))
                            ElseIf (pMontoAnticipo * -1) < (CDbl(txtDOC_MONTO_TOTAL.Text) + (.Cells("cDDO_DES_INC_PRE").Value * -1)) Then
                                vMontoAnticipo = 0
                                pMontoAnticipo = 0.1
                            End If

                            'If (pMontoAnticipo * -1) > (CDbl(txtDOC_MONTO_TOTAL.Text) + (.Cells("cDDO_DES_INC_PRE").Value * -1)) Then
                            'pMontoAnticipo = CDbl(.Cells("cDDO_DES_INC_PRE").Value)
                            'End If

                            '.Cells("cDDO_DES_INC_PRE").Value = pMontoAnticipo

                            If vMontoAnticipo = pMontoAnticipo Then
                                ArticuloAnticipo = 1 ' No procesar
                            Else
                                ArticuloAnticipo = 2 ' Procesar
                            End If
                            If CDbl(txtDOC_MONTO_TOTAL.Text) < 0 Then
                                ArticuloAnticipo = 3 ' Procesar pero con monto negativo en total documento
                            End If
                        Else

                            .Cells("cDDO_DES_INC_PRE").Value = (pMontoAnticipo * -1)
                            DeshabilitarProcesarDescuentos(False, False, False)
                            ProcesarTotalArticulo(vFilGrid, 0)
                            ArticuloAnticipo = True
                        End If
                        Exit Function
                    End If
                End With
                vFilGrid += 1
            End While

            If pMontoAnticipo > CDbl(txtDOC_MONTO_TOTAL.Text) Then
                pMontoAnticipo = CDbl(txtDOC_MONTO_TOTAL.Text)
                If pMontoAnticipo = 0 Then Exit Function
            End If
            Dim vCantidad As Int16 = 1
            Dim vCadenaFiltro As String
            vCadenaFiltro = " WHERE ART_ID LIKE '%' " & _
                            " AND LPR_ID='" & txtLPR_ID.Text & "' " & _
                            " AND MON_ID='" & BCVariablesNames.MonedaSistema & "' " & _
                            " AND ART_ID In " & _
                            " (SELECT ART_ID FROM vwRolArticulosTipoArticulos WHERE TIP_ID='" & BCVariablesNames.TipoArticulo.ProductoAnticipo & "' " & _
                                                                            " AND ART_ESTADO='ACTIVO' " & _
                                                                            " AND TIP_ESTADO='ACTIVO' " & _
                                                                            " AND RAR_ESTADO='ACTIVO')"
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spArticuloAnticipo, _
                                                                vCantidad, _
                                                                vCadenaFiltro
                                                               )
                                      )
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)

                dgvDetalle.Enabled = True
                AdicionarFilasGrid(ds.Tables(0).Rows(0)("ART_ID").ToString, _
                                   ds.Tables(0).Rows(0)("ART_DESCRIPCION").ToString, _
                                   ds.Tables(0).Rows(0)("UM_DESCRIPCION").ToString, _
                                   1, _
                                   ds.Tables(0).Rows(0)("ART_FACTOR").ToString, _
                                   0, _
                                   (pMontoAnticipo * -1), _
                                   ds.Tables(0).Rows(0)("ART_INC_IGV").ToString
                                  )
                dgvDetalle.Rows(dgvDetalle.CurrentRow.Index).Cells("cTDO_ID_ANT").Value = pTDO_ID_ANT
                dgvDetalle.Rows(dgvDetalle.CurrentRow.Index).Cells("cDTD_ID_ANT").Value = pDTD_ID_ANT
                dgvDetalle.Rows(dgvDetalle.CurrentRow.Index).Cells("cCCT_ID_ANT").Value = pCCT_ID_ANT
                dgvDetalle.Rows(dgvDetalle.CurrentRow.Index).Cells("cDDO_SERIE_ANT").Value = pDDO_SERIE_ANT
                dgvDetalle.Rows(dgvDetalle.CurrentRow.Index).Cells("cDDO_NUMERO_ANT").Value = pDDO_NUMERO_ANT

                DeshabilitarProcesarDescuentos(False, True)

                ProcesarTotalArticulo(dgvDetalle.CurrentRow.Index, 0)
                ArticuloAnticipo = True
            Else
                ArticuloAnticipo = False
            End If
            Return ArticuloAnticipo
        End Function
        Private Function ValidarAdicionarFilasGrid() As Boolean
            ValidarAdicionarFilasGrid = True
            ErrorProvider1.SetError(txtFLE_ID, Nothing)
            If cboDOC_TIPO_LISTA.Text = "PLANTA - OBRA" Or _
               cboDOC_TIPO_LISTA.Text = "PUNTO DE VENTA - OBRA" Then
                If txtFLE_ID.Text.Trim = "" Then
                    ErrorProvider1.SetError(txtFLE_ID, "Ingrese el código del flete de la zona")
                    ValidarAdicionarFilasGrid = False
                End If
            End If
            If Not dgvDetalle.Enabled Then ValidarAdicionarFilasGrid = False
            Return ValidarAdicionarFilasGrid
        End Function

        Private Sub ControlEnabled(ByRef vObjeto As Object, ByVal vboolean As Boolean)
            vObjeto.Enabled = vboolean
        End Sub
        Private Sub ControlVisible(ByRef vObjeto As Object, ByVal vboolean As Boolean)
            vObjeto.Visible = vboolean
        End Sub
        Private Sub ControlReadOnly(ByRef vObjeto As Object, ByVal vboolean As Boolean)
            vObjeto.ReadOnly = vboolean
        End Sub

        '' ojito
        Private Function MensajeOperaciones(ByVal vRespuesta As Int16, _
                                            ByVal vOperacion As String) As Int16
            MensajeOperaciones = vRespuesta
            Select Case vRespuesta
                Case 0
                    'MsgBox("Registro " & vOperacion, MsgBoxStyle.Information, Me.Text)
                Case 1
                Case 2
                    MsgBox("Registro no fue " & vOperacion & " verifique sus datos" & _
                           Chr(13) & Chr(13) & Compuesto.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto1.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto6.vMensajeError, _
                           MsgBoxStyle.Information, Me.Text)
            End Select
            Return MensajeOperaciones
        End Function

        Private Sub btnAnticipos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnticipos.Click
            'Select Case txtDTD_ID.Text
            '    Case BCVariablesNames.ProcesosFacturación.ProBoleta, BCVariablesNames.ProcesosFacturación.ProFactura
            '        MsgBox("No se procesan anticipos en proformas", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Exit Sub
            'End Select

            EtxtDTD_ID_ANT.pOOrm.CadenaFiltrado = " AND DTD_ID_REF IN ('" & BCVariablesNames.ProcesosFacturación.FacturaAnticipo & "','" & BCVariablesNames.ProcesosFacturación.BoletaAnticipo & "') " & _
                                      " AND PER_ID_CLI='" & txtPER_ID_CLI.Text & "' "
            ''                                      " AND TDO_ID+DTD_ID+DOC_SERIE+DOC_NUMERO<>'" & txtTDO_ID.Text & txtDTD_ID.Text & txtDOC_SERIE.Text & txtDOC_NUMERO.Text & "' " & _



            EtxtDTD_ID_ANT.pOOrm.vPER_ID_CLI = txtPER_ID_CLI.Text
            MetodoBusquedaDato("", False, EtxtDTD_ID_ANT)
        End Sub

        Private Sub btnDescuentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescuentos.Click
            'Select Case txtDTD_ID.Text
            '    Case BCVariablesNames.ProcesosFacturación.ProBoleta, BCVariablesNames.ProcesosFacturación.ProFactura
            '        MsgBox("No se procesan descuentos en proformas", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
            '        Exit Sub
            'End Select

            If dgvDetalle.RowCount = 0 Then Exit Sub
            If Not dgvDetalle.Enabled Then
                GridNoEnabled()
            Else
                If pProcesarDescuentoIncremento = False Then Exit Sub
                Dim vCadenaFecha As String = ""
                Dim vDOC_MONTO_TOTAL As Double = 0

                vCadenaFecha = cMisProcedimientos.FormatoFechaGenerico(dtpDOC_FECHA_EMI.Value)
                vDOC_MONTO_TOTAL = CDbl(txtDOC_MONTO_TOTAL.Text)

                GridEnabled(vCadenaFecha, vDOC_MONTO_TOTAL)
            End If
        End Sub
        Private Sub GridNoEnabled()
            EliminarDescuentosIncrementos()
            EliminarAnticipos()
        End Sub
        Private Sub EliminarDescuentosIncrementos(Optional ByVal vProcesarTotalArticulo As Boolean = True)
            Dim vFilGrid1 As Int16 = 0
            Dim vFlag As Boolean = False

            vFilGrid1 = 0
            While (dgvDetalle.Rows.Count() > vFilGrid1)
                If CDbl(dgvDetalle.Rows(vFilGrid1).Cells("cDDO_DES_INC_PRE").Value) <> 0 And
                    Trim(dgvDetalle.Rows(vFilGrid1).Cells("cTDO_ID_ANT").Value) = "" Then
                    dgvDetalle.Rows(vFilGrid1).Cells("cDDO_DES_INC_PRE").Value = 0
                    dgvDetalle.Rows(vFilGrid1).Cells("cDDO_OBS_DSC_ART").Value = ""
                    DeshabilitarProcesarDescuentos(True, False)
                    vFlag = True
                    If vProcesarTotalArticulo Then ProcesarTotalArticulo(vFilGrid1, 1)
                End If
                vFilGrid1 += 1
            End While
            If vFlag Then CalcularMontoDocumento(1)
            If Not vFlag Then
                DeshabilitarProcesarDescuentos(True, False)
            End If
        End Sub
        Private Sub EliminarAnticipos()
            Dim vFlag As Boolean = True
            Dim vFlagCalcularMonto As Boolean = False
            While vFlag
                Dim vFilGrid1 As Int16 = 0
                While (dgvDetalle.Rows.Count() > vFilGrid1)
                    If CDbl(dgvDetalle.Rows(vFilGrid1).Cells("cDDO_DES_INC_PRE").Value) <> 0 And
                        Trim(dgvDetalle.Rows(vFilGrid1).Cells("cTDO_ID_ANT").Value) <> "" Then
                        vFlagDgvDetalle_CellValidated = False
                        SubEliminarFilasGrid(vFilGrid1)
                        vFlagDgvDetalle_CellValidated = True
                        vFlagCalcularMonto = True
                        vFlag = True
                        Exit While
                    End If
                    vFlag = False
                    vFilGrid1 += 1
                End While
            End While
            If vFlagCalcularMonto Then CalcularMontoDocumento(1)
        End Sub
        Private Function GridEnabled(ByVal vCadenaFecha As String, _
                                ByVal vDOC_MONTO_TOTAL As Double, _
                                Optional ByVal vProcesarProforma As Boolean = False, _
                                Optional ByVal vDeshabilitarProcesarDescuentos As Boolean = True) As Double
            GridEnabled = 0
            Dim vFilGrid1 As Int16 = 0
            Dim vCadenaArticulo As String = ""

            Dim vART_ID As String = ""
            Dim vDTP_MONTO_TIV As Double = 0
            Dim vDTP_DESCRIPCION As String = ""
            Dim vEntero As Double = 0
            'ojito Dim vEntero As Int16 = 0
            Dim vFilGrid As Int16 = 0
            Dim vFlagCalcularMonto As Boolean = False
            Dim ds As New DataSet
            Dim NombreProcedimiento As String = Ladisac.DA.SPNames.spDescuentoIncrementoMONTO_TIV

            vFilGrid1 = 0
            While (dgvDetalle.Rows.Count() > vFilGrid1)
                If vFilGrid1 > 0 Then
                    vCadenaArticulo = vCadenaArticulo + ","
                End If
                vCadenaArticulo += "'" & dgvDetalle.Rows(vFilGrid1).Cells("cART_ID_IMP").Value & "'"
                vFilGrid1 += 1
            End While

            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vCadenaFecha, vDOC_MONTO_TOTAL, txtLPR_ID.Text, txtTIV_ID.Text, vCadenaArticulo, ""))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                dgvDsctoXArticulo.DataSource = ds.Tables(0)
            Else
                dgvDsctoXArticulo.DataSource = Nothing
            End If

            While (dgvDsctoXArticulo.Rows.Count() > vFilGrid)
                With dgvDsctoXArticulo.Rows(vFilGrid)
                    vART_ID = .Cells("ART_ID").Value
                    vDTP_MONTO_TIV = .Cells("DTP_MONTO_TIV").Value
                    vDTP_DESCRIPCION = .Cells("DTP_DESCRIPCION").Value
                    vFilGrid1 = 0
                    While (dgvDetalle.Rows.Count() > vFilGrid1)
                        If vProcesarProforma Then
                            If CDbl(dgvDetalle.Rows(vFilGrid1).Cells("cDDO_DES_INC_PRE").Value) <> 0 And
                               Trim(dgvDetalle.Rows(vFilGrid1).Cells("cTDO_ID_ANT").Value) = "" Then
                                ' ojito vEntero = Int(dgvDetalle.Rows(vFilGrid1).Cells("cDDO_CANTIDAD").Value)
                                vEntero = CDbl(dgvDetalle.Rows(vFilGrid1).Cells("cDDO_CANTIDAD").Value)
                                If vEntero > 0 Then
                                    If dgvDetalle.Rows(vFilGrid1).Cells("cART_ID_IMP").Value = vART_ID Then
                                        GridEnabled += (vEntero * vDTP_MONTO_TIV)
                                    End If
                                End If
                            End If
                        Else
                            If CDbl(dgvDetalle.Rows(vFilGrid1).Cells("cDDO_DES_INC_PRE").Value) = 0 And
                               Trim(dgvDetalle.Rows(vFilGrid1).Cells("cTDO_ID_ANT").Value) = "" Then
                                'ojito vEntero = Int(dgvDetalle.Rows(vFilGrid1).Cells("cDDO_CANTIDAD").Value)
                                vEntero = CDbl(dgvDetalle.Rows(vFilGrid1).Cells("cDDO_CANTIDAD").Value)
                                If vEntero > 0 Then
                                    If dgvDetalle.Rows(vFilGrid1).Cells("cART_ID_IMP").Value = vART_ID Then
                                        dgvDetalle.Rows(vFilGrid1).Cells("cDDO_DES_INC_PRE").Value = vEntero * vDTP_MONTO_TIV
                                        dgvDetalle.Rows(vFilGrid1).Cells("cDDO_OBS_DSC_ART").Value = vDTP_DESCRIPCION
                                        If vDeshabilitarProcesarDescuentos Then DeshabilitarProcesarDescuentos(False, True)
                                        ProcesarTotalArticulo(vFilGrid1, 1)
                                        vFlagCalcularMonto = True
                                    End If
                                End If
                            End If
                        End If
                        vFilGrid1 += 1
                    End While
                End With
                vFilGrid += 1
            End While
            If vFlagCalcularMonto Then CalcularMontoDocumento(1)
            Return GridEnabled
        End Function
        Private Sub VerificarDescuentosProforma()
            Dim vCadenaFecha As String = ""
            Dim vDOC_MONTO_TOTAL As Double = 0
            Dim vTotalDescuentos As Double = 0
            Dim vTotalDescuentosProforma As Double = 0
            Dim vTotalAnticipos As Double = 0

            vCadenaFecha = cMisProcedimientos.FormatoFechaGenerico(dtpDOC_FECHA_EMI.Value)
            vTotalAnticipos = TotalizarAnticipos()
            vTotalDescuentosProforma = TotalizarDescuentos()

            vDOC_MONTO_TOTAL = CDbl(txtDOC_MONTO_TOTAL.Text) + vTotalDescuentosProforma + vTotalAnticipos
            vTotalDescuentos = GridEnabled(vCadenaFecha, vDOC_MONTO_TOTAL, True)

            Dim oMsgBoxResult As New MsgBoxResult()
            If CDbl(txtTotDescInc.Text) + vTotalAnticipos > 0 Then
                If (CDbl(txtTotDescInc.Text) + vTotalAnticipos) = vTotalDescuentos Then
                ElseIf (CDbl(txtTotDescInc.Text) + vTotalAnticipos) > vTotalDescuentos Then
                    oMsgBoxResult = MsgBox("¡El Inc. de la proforma es superior!." & Chr(13) & _
                                           "Si. El Inc. se  mantendra." & Chr(13) & _
                                           "No. El Inc. disminuira." & Chr(13) _
                                           , MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text)
                Else
                    oMsgBoxResult = MsgBox("¡El Inc. de la proforma es inferior!." & Chr(13) & _
                                           "El Inc. aumentara." & Chr(13) _
                                           , MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                    oMsgBoxResult = MsgBoxResult.No
                End If
            Else
                If (CDbl(txtTotDescInc.Text) + vTotalAnticipos) = vTotalDescuentos Then
                ElseIf (CDbl(txtTotDescInc.Text) + vTotalAnticipos) > vTotalDescuentos Then
                    oMsgBoxResult = MsgBox("¡El Desc. de la proforma es inferior!." & Chr(13) & _
                                           "Si. El Desc. se mantendra." & Chr(13) & _
                                           "No. El Desc. aumentara." & Chr(13) & _
                                           "Cancelar. El Desc. se eliminara.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel, Me.Text)
                Else
                    oMsgBoxResult = MsgBox("¡El Desc. de la proforma es superior!." & Chr(13) & _
                                           "Ok. El Desc. disminuira." & Chr(13) & _
                                           "Cancelar. El Desc. se eliminara.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, Me.Text)
                    If oMsgBoxResult = MsgBoxResult.Ok Then oMsgBoxResult = MsgBoxResult.No
                End If
            End If


            If oMsgBoxResult = MsgBoxResult.No Then
                EliminarDescuentosIncrementos()
                GridEnabled(vCadenaFecha, vDOC_MONTO_TOTAL, False, False)
            ElseIf oMsgBoxResult = MsgBoxResult.Cancel Then
                EliminarDescuentosIncrementos()
            End If
        End Sub
        Private Function VerificarAnticipo()
            VerificarAnticipo = False

            Dim vFiltro As String = ""
            Dim oMsgBoxResult As New MsgBoxResult()
            Dim vcDDO_DES_INC_PRE As Double = 0
            Dim vArrayFilas(dgvDetalle.Rows.Count(), 1) As Int16
            Dim vcDDO_DES_INC_PRE0 As Double = 0
            Dim vFlagArticuloAnticipo As Int16 = 1
            Dim vFilGrid As Int16 = 0

            While (dgvDetalle.Rows.Count() > vFilGrid)
                pTDO_ID_ANT = ""
                pDTD_ID_ANT = ""
                pCCT_ID_ANT = ""
                pDDO_SERIE_ANT = ""
                pDDO_NUMERO_ANT = ""
                vFlagArticuloAnticipo = 1
                With dgvDetalle.Rows(vFilGrid)
                    ' Ojo para que inserte y no actualiza el documento Es proforma a Documento
                    .Cells("cEstadoRegistro").Value = 0

                    If .Cells("cTDO_ID_ANT").Value <> "" And
                       .Cells("cDTD_ID_ANT").Value <> "" And
                       .Cells("cCCT_ID_ANT").Value <> "" And
                       .Cells("cDDO_SERIE_ANT").Value <> "" And
                       .Cells("cDDO_NUMERO_ANT").Value <> "" Then

                        pTDO_ID_ANT = .Cells("cTDO_ID_ANT").Value
                        pDTD_ID_ANT = .Cells("cDTD_ID_ANT").Value
                        pCCT_ID_ANT = .Cells("cCCT_ID_ANT").Value
                        pDDO_SERIE_ANT = .Cells("cDDO_SERIE_ANT").Value
                        pDDO_NUMERO_ANT = .Cells("cDDO_NUMERO_ANT").Value

                        vFiltro = " AND DTD_ID_REF IN ('" & BCVariablesNames.ProcesosFacturación.FacturaAnticipo & "','" & _
                                                               BCVariablesNames.ProcesosFacturación.BoletaAnticipo & "')  AND " & _
                                        " TDO_ID+DTD_ID+DOC_SERIE+DOC_NUMERO<>'" & txtTDO_ID.Text & _
                                                                                     txtDTD_ID.Text & _
                                                                                     txtDOC_SERIE.Text & _
                                                                                     txtDOC_NUMERO.Text & "' AND" & _
                                        " TDO_ID_REF+DTD_ID_REF+CCT_ID_REF+DOC_SERIE_REF+DOC_NUMERO_REF='" & pTDO_ID_ANT & _
                                                                                                             pDTD_ID_ANT & _
                                                                                                             pCCT_ID_ANT & _
                                                                                                             pDDO_SERIE_ANT & _
                                                                                                             pDDO_NUMERO_ANT & "'"
                        vcDDO_DES_INC_PRE = Me.IBCBusqueda.SaldoFnKardex(txtPER_ID_CLI.Text, vFiltro) '* -1
                        vcDDO_DES_INC_PRE0 = CDbl(.Cells("cDDO_DES_INC_PRE").Value)

                        If vcDDO_DES_INC_PRE0 < 0 Then
                        Else
                            vcDDO_DES_INC_PRE = vcDDO_DES_INC_PRE * -1
                        End If

                        If vcDDO_DES_INC_PRE = 0 Then
                            oMsgBoxResult = MsgBox("¡El anticipo de la proforma fue procesado o anulada!." & Chr(13) & _
                                                   "El anticipo se eliminara." & Chr(13) _
                                                   , MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text)
                            oMsgBoxResult = MsgBoxResult.Cancel
                        Else
                            vFlagArticuloAnticipo = ArticuloAnticipo(vcDDO_DES_INC_PRE, True)
                            If vcDDO_DES_INC_PRE0 = vcDDO_DES_INC_PRE Then
                                oMsgBoxResult = MsgBoxResult.Yes
                            ElseIf vcDDO_DES_INC_PRE0 > vcDDO_DES_INC_PRE Then
                                If vFlagArticuloAnticipo = 1 Then
                                    oMsgBoxResult = MsgBoxResult.Yes
                                Else
                                    If vFlagArticuloAnticipo = 2 Then
                                        oMsgBoxResult = MsgBox("¡El monto a descontar por anticipo en la proforma es inferior!." & Chr(13) & _
                                                               "Si. El monto se mantendra." & Chr(13) & _
                                                               "No. El monto aumentara." & Chr(13) & _
                                                               "Cancelar. El anticipo se eliminara.", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel, Me.Text)
                                    ElseIf vFlagArticuloAnticipo = 3 Then
                                        oMsgBoxResult = MsgBox("¡El monto a descontar por anticipo en la proforma es erronea!." & Chr(13) & _
                                                               "Ok. El monto se corregira." & Chr(13) & _
                                                               "Cancelar. El anticipo se eliminara.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, Me.Text)
                                        If oMsgBoxResult = MsgBoxResult.Ok Then oMsgBoxResult = MsgBoxResult.No
                                    End If
                                End If
                            Else
                                If vFlagArticuloAnticipo = 1 Then
                                    oMsgBoxResult = MsgBoxResult.Yes
                                Else
                                    If vFlagArticuloAnticipo = 2 Then
                                        oMsgBoxResult = MsgBox("¡El monto a descontar por anticipo en la proforma es superior!." & Chr(13) & _
                                                               "Ok. El monto disminuira." & Chr(13) & _
                                                               "Cancelar. El anticipo se eliminara.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, Me.Text)
                                    ElseIf vFlagArticuloAnticipo = 3 Then
                                        oMsgBoxResult = MsgBox("¡El monto a descontar por anticipo en la proforma es erronea!." & Chr(13) & _
                                                               "Ok. El monto se corregira." & Chr(13) & _
                                                               "Cancelar. El anticipo se eliminara.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, Me.Text)
                                    End If
                                    If oMsgBoxResult = MsgBoxResult.Ok Then oMsgBoxResult = MsgBoxResult.No
                                End If
                            End If
                        End If

                        If oMsgBoxResult = MsgBoxResult.No Then
                            '.Cells("cDDO_DES_INC_PRE").Value = 0
                            ProcesarTotalArticulo(vFilGrid, 0)
                            vArrayFilas(vFilGrid, 0) = vFilGrid
                            vArrayFilas(vFilGrid, 1) = 1 ' Procesa
                        ElseIf oMsgBoxResult = MsgBoxResult.Cancel Then
                            .Cells("cDDO_DES_INC_PRE").Value = 0
                            ProcesarTotalArticulo(vFilGrid, 0)
                            vArrayFilas(vFilGrid, 0) = vFilGrid
                            vArrayFilas(vFilGrid, 1) = 2 ' Elimina
                        End If
                    Else
                        vArrayFilas(vFilGrid, 0) = vFilGrid
                        vArrayFilas(vFilGrid, 1) = 0 ' No procesa
                    End If
                End With
                vFilGrid += 1
            End While

            vFilGrid = 0
            While (dgvDetalle.Rows.Count() > vFilGrid)

                pTDO_ID_ANT = dgvDetalle.Rows(vFilGrid).Cells("cTDO_ID_ANT").Value
                pDTD_ID_ANT = dgvDetalle.Rows(vFilGrid).Cells("cDTD_ID_ANT").Value
                pCCT_ID_ANT = dgvDetalle.Rows(vFilGrid).Cells("cCCT_ID_ANT").Value
                pDDO_SERIE_ANT = dgvDetalle.Rows(vFilGrid).Cells("cDDO_SERIE_ANT").Value
                pDDO_NUMERO_ANT = dgvDetalle.Rows(vFilGrid).Cells("cDDO_NUMERO_ANT").Value

                vFiltro = " AND DTD_ID_REF IN ('" & BCVariablesNames.ProcesosFacturación.FacturaAnticipo & "','" & _
                                       BCVariablesNames.ProcesosFacturación.BoletaAnticipo & "')  AND " & _
                " TDO_ID+DTD_ID+DOC_SERIE+DOC_NUMERO<>'" & txtTDO_ID.Text & _
                                                             txtDTD_ID.Text & _
                                                             txtDOC_SERIE.Text & _
                                                             txtDOC_NUMERO.Text & "' AND" & _
                " TDO_ID_REF+DTD_ID_REF+CCT_ID_REF+DOC_SERIE_REF+DOC_NUMERO_REF='" & pTDO_ID_ANT & _
                                                                                     pDTD_ID_ANT & _
                                                                                     pCCT_ID_ANT & _
                                                                                     pDDO_SERIE_ANT & _
                                                                                     pDDO_NUMERO_ANT & "'"
                vcDDO_DES_INC_PRE = Me.IBCBusqueda.SaldoFnKardex(txtPER_ID_CLI.Text, vFiltro) '* -1

                '                vcDDO_DES_INC_PRE = CDbl(dgvDetalle.Rows(vFilGrid).Cells("cDDO_DES_INC_PRE").Value)

                'If vArrayFilas(vFilGrid, 1) = 2 Then
                '    SubEliminarFilasGrid(vArrayFilas(vFilGrid, 0))
                '    CalcularMontoDocumento(1)
                If vArrayFilas(vFilGrid, 1) = 1 Then
                    If vcDDO_DES_INC_PRE < 0 Then vcDDO_DES_INC_PRE = vcDDO_DES_INC_PRE * -1
                    ArticuloAnticipo(vcDDO_DES_INC_PRE)
                    CalcularMontoDocumento(1)
                End If
                vFilGrid += 1
            End While


            For vFilGrid = dgvDetalle.Rows.Count() - 1 To 0 Step -1
                If vArrayFilas(vFilGrid, 1) = 2 Then
                    SubEliminarFilasGrid(vArrayFilas(vFilGrid, 0))
                    CalcularMontoDocumento(1)
                    'ElseIf vArrayFilas(vFilGrid, 1) = 1 Then
                    '    ArticuloAnticipo(vcDDO_DES_INC_PRE * -1)
                    '    CalcularMontoDocumento(1)
                End If
            Next

            'CalcularMontoDocumento(1)
            ''
        End Function

        Private Function TotalizarAnticipos() As Double
            TotalizarAnticipos = 0
            Dim vFilGrid As Int16 = 0
            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    If .Cells("cTDO_ID_ANT").Value <> "" And
                       .Cells("cDTD_ID_ANT").Value <> "" And
                       .Cells("cCCT_ID_ANT").Value <> "" And
                       .Cells("cDDO_SERIE_ANT").Value <> "" And
                       .Cells("cDDO_NUMERO_ANT").Value <> "" And
                       .Cells("cDDO_DES_INC_PRE").Value <> 0 Then
                        TotalizarAnticipos += (.Cells("cDDO_DES_INC_PRE").Value * -1)
                    End If
                End With
                vFilGrid += 1
            End While
            Return TotalizarAnticipos
        End Function
        Private Function TotalizarDescuentos() As Double
            TotalizarDescuentos = 0
            Dim vFilGrid As Int16 = 0
            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    If .Cells("cTDO_ID_ANT").Value = "" And
                       .Cells("cDTD_ID_ANT").Value = "" And
                       .Cells("cCCT_ID_ANT").Value = "" And
                       .Cells("cDDO_SERIE_ANT").Value = "" And
                       .Cells("cDDO_NUMERO_ANT").Value = "" And
                       .Cells("cDDO_DES_INC_PRE").Value <> 0 Then
                        TotalizarDescuentos += (.Cells("cDDO_DES_INC_PRE").Value * -1)
                    End If
                End With
                vFilGrid += 1
            End While
            Return TotalizarDescuentos
        End Function
        Private Sub DeshabilitarProcesarDescuentos(ByVal vBoolGrid As Boolean, _
                                                   ByVal vBoolTIV_ID As Boolean, _
                                                   Optional ByVal vFlag As Boolean = True)
            dgvDetalle.Enabled = vBoolGrid
            If vFlag Then
                If Not vBoolGrid Then
                    btnDescuentos.Text = "habilitar descuentos"
                Else
                    btnDescuentos.Text = "Procesar descuentos"
                End If
            End If
            ConfigurarReadOnlyNoBusqueda(txtTIV_ID, EtxtTIV_ID, vBoolTIV_ID)
        End Sub

        Private Sub btnProcesarProformas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarProformas.Click
            If Not pRegistroNuevo Then Exit Sub
            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosFacturación.Boleta
                    EtxtTDO_ID_PRO.pOOrm.CadenaFiltrado = " And TDO_ID In ('" & BCVariablesNames.ProcesosFacturación.PedidoBoleta & "')" & _
                                                          " And PVE_ID_DES IN (SELECT PVE_ID_ANE FROM MAE.PuntoVentaAnexo WHERE PVE_ID='" & txtPVE_ID.Text & "')" & _
                                                          " And DOC_ESTADO='" & BCVariablesNames.EstadoRegistro.PorProcesar & "'"
                    MetodoBusquedaDato("", False, EtxtTDO_ID_PRO)
                    MetodoBusquedaDato(BCVariablesNames.CCT_ID.CxCComerciales, True, EtxtCCT_ID)
                    btnAnticipos.Enabled = True
                    btnDescuentos.Enabled = True
                    btnImpresion.Enabled = True
                Case BCVariablesNames.ProcesosFacturación.Factura
                    EtxtTDO_ID_PRO.pOOrm.CadenaFiltrado = " And TDO_ID In ('" & BCVariablesNames.ProcesosFacturación.PedidoFactura & "')" & _
                                                          " And PVE_ID_DES IN (SELECT PVE_ID_ANE FROM MAE.PuntoVentaAnexo WHERE PVE_ID='" & txtPVE_ID.Text & "')" & _
                                                          " And DOC_ESTADO='" & BCVariablesNames.EstadoRegistro.PorProcesar & "'"
                    MetodoBusquedaDato("", False, EtxtTDO_ID_PRO)
                    MetodoBusquedaDato(BCVariablesNames.CCT_ID.CxCComerciales, True, EtxtCCT_ID)
                    btnAnticipos.Enabled = True
                    btnDescuentos.Enabled = True
                    btnImpresion.Enabled = True
            End Select
        End Sub
        Private Sub ProcesarJalarProforma()
            SaldosClienteContado()
            SaldosClienteContraentregaCredito123()
            SaldosCliente()
            ProcesarGridVacio()
            btnDescuentos.Enabled = False
            btnAnticipos.Enabled = False
            btnImpresion.Enabled = False
            VerificarDescuentosProforma()
            VerificarAnticipo()
            'pRegistroNuevo = True
        End Sub
        Private Sub DataTimePicker_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles dtpDOC_FECHA_EMI.DropDown
            Select Case sender.name
                Case "dtpDOC_FECHA_EMI"
                    If Not EdtpDOC_FECHA_EMI.pEnabled Then
                        dtpDOC_FECHA_EMI.MaxDate = dtpDOC_FECHA_EMI.Value
                        dtpDOC_FECHA_EMI.MinDate = dtpDOC_FECHA_EMI.Value
                    Else
                    End If
            End Select
        End Sub
        'Private Sub ProcesarFechasDateTimePicker(ByRef vObjeto As Object, ByVal vboolean As Boolean)
        '    Select Case vObjeto.name
        '        Case "dtpDOC_FECHA_EMI"
        '            If Not vboolean Then
        '            Else
        '                Dim vDtp As New DateTimePicker
        '                vObjeto.MaxDate = vDtp.MaxDate
        '                vObjeto.MinDate = vDtp.MinDate
        '            End If
        '    End Select
        'End Sub

        Private Function VerificarPrecioEspecialPersona() As Boolean
            VerificarPrecioEspecialPersona = False
            Dim vTipoPuntoVenta As String = ""

            Select Case cboDOC_TIPO_LISTA.Text
                Case BCVariablesNames.TipoPuntoVenta.Planta,
                     BCVariablesNames.TipoPuntoVenta.PlantaObra
                    vTipoPuntoVenta = "PLANTA"
                Case BCVariablesNames.TipoPuntoVenta.Punto,
                     BCVariablesNames.TipoPuntoVenta.PuntoObra
                    vTipoPuntoVenta = "PUNTO DE VENTA"
            End Select

            '******
            Dim vtxtPER_ID_CLI As String
            Dim sr1 As New StringReader(IBCMaestro.EjecutarVista("spCodigoEnlazadoXML", txtPER_ID_CLI.Text))
            Dim ds1 As New DataSet
            Dim vcontrol1 As Int16 = sr1.Peek

            If vcontrol1 <> -1 Then
                ds1.ReadXml(sr1)
                vtxtPER_ID_CLI = ds1.Tables(0).Rows(0).Item("PER_ID")
                txtPER_ID_GRU.Text = vtxtPER_ID_CLI
                MetodoBusquedaDato(txtPER_ID_GRU.Text, True, EtxtPER_ID_GRU)
                EtxtPER_ID_GRU.pBusqueda = False
                EtxtPER_ID_GRU.pEnabled = False
                txtPER_ID_GRU.Enabled = False
            Else
                vtxtPER_ID_CLI = txtPER_ID_CLI.Text
                EtxtPER_ID_GRU.pBusqueda = True
                EtxtPER_ID_GRU.pEnabled = True
                txtPER_ID_GRU.Enabled = True
            End If
            '******

            'Dim sr As New StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spListaPreciosArticulosPER_IDXML, txtPER_ID_CLI.Text, " AND LPR_PRINCIPAL='" & vTipoPuntoVenta & "'"))
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(Ladisac.DA.SPNames.spListaPreciosArticulosPER_IDXML, vtxtPER_ID_CLI, " AND LPR_PRINCIPAL='" & vTipoPuntoVenta & "'"))
            Dim ds As New DataSet
            Dim vCantidad As Double = 0
            Dim vcontrol As Int16 = sr.Peek

            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                vCantidad = ds.Tables(0).Rows(0).Item("Cantidad")
                If vCantidad > 0 Then
                    pLPR_ID_PrecioEspecialCliente = ds.Tables(0).Rows(0).Item("LPR_ID")
                    VerificarPrecioEspecialPersona = True
                Else
                    pLPR_ID_PrecioEspecialCliente = ""
                    VerificarPrecioEspecialPersona = False
                End If
            End If
            Return VerificarPrecioEspecialPersona
        End Function
        Private Function VerificarPER_PROMOCIONES() As Boolean
            VerificarPER_PROMOCIONES = False
            If Me.IBCBusqueda.PromocionPersona(txtPER_ID_CLI.Text) = BCVariablesNames.ProcesarDescuento Then
                VerificarPER_PROMOCIONES = True
            Else
                VerificarPER_PROMOCIONES = False
            End If
        End Function

        Private Sub MostrarAutorizadoDescuento()
            If pProcesarDescuentoIncremento Then
                tslAutorizadoDescuento.Text = BCVariablesNames.ProcesarDescuento
            Else
                tslAutorizadoDescuento.Text = BCVariablesNames.NoProcesarDescuento
            End If
        End Sub

        Private Sub btnImpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresion.Click
            Dim vCadenaReferencial As String
            Dim vCadenaMonto As String
            Dim vCodigoTrabajador As String
            Dim vDOC_SERIE As String
            Dim vFechaVencimiento As Date
            vFechaVencimiento = DateAdd(DateInterval.Day, CDbl(txtTIV_DIAS.Text), dtpDOC_FECHA_EMI.Value)

            vDOC_SERIE = txtDOC_SERIE.Text
            If SessionService.userFactura Then
                If Len(Trim(vDOC_SERIE)) = 3 Then
                    If Strings.Left(vDOC_SERIE, 1) = "B" Or Strings.Left(vDOC_SERIE, 1) = "F" Then
                        vDOC_SERIE = Strings.Left(vDOC_SERIE, 1) + "0" + Strings.Right(vDOC_SERIE, 2)
                    End If
                End If
            End If

            If RevisarDatos(False, True) <> False Then Exit Sub

            If pRegistroNuevo Then
                MsgBox("Debe grabar el documento para poder imprimirlo", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If
            pFechaDocumento = Me.IBCBusqueda.FechaDocumento(txtTDO_ID_AFE.Text, txtDTD_ID_AFE.Text, txtDOC_SERIE_AFE.Text, txtDOC_NUMERO_AFE.Text)
            pPER_TELEFONOS = Me.IBCBusqueda.TelefonoPersona(txtPER_ID_CLI.Text)

            Dim NombreDocumentoImprimir As String = ""
            Select Case Me.SessionService.NombreEmpresa
                Case "Ladrillera El Diamante SAC"
                    NombreDocumentoImprimir = "D" & txtDOC_SERIE.Text & ".rpt"
                Case "Comercializadora Diamante G.E. SAC"
                    NombreDocumentoImprimir = "C" & txtDOC_SERIE.Text & ".rpt"
            End Select

            'Me.Cursor = Cursors.WaitCursor

            Dim vDescripcionTipoDocumento As String = ""
            Dim vDescripcionArticulo As String = ""
            Dim vDireccion As String = ""
            Dim vTipoEntregaProducto As String = ""
            Dim vDOP_NUMERO_CLI As String = ""


            Dim ReporteDocumento As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            ReporteDocumento = New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosFacturación.PFFactura, _
                     BCVariablesNames.ProcesosFacturación.PBBoleta
                    If txtDTD_ID.Text = BCVariablesNames.ProcesosFacturación.PFFactura Then
                        vDireccion = txtDIR_DESCRIPCION_FIS.Text & " " & txtDIS_DESCRIPCION_FIS.Text
                        If txtTDP_ID_CLI.Text = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC Then vDOP_NUMERO_CLI = txtDOP_NUMERO_CLI.Text
                    Else
                        vDireccion = txtDIR_DESCRIPCION_DOM.Text & " " & txtDIS_DESCRIPCION_DOM.Text
                        If txtTDP_ID_CLI.Text = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI Then vDOP_NUMERO_CLI = txtDOP_NUMERO_CLI.Text
                    End If
                    pEmailVendedor = Me.IBCBusqueda.EMailPersona(txtPER_ID_VEN.Text)
                    pTelefonoVendedor = Me.IBCBusqueda.TelefonoPersona(txtPER_ID_VEN.Text)
                    pTelefonoCliente = Me.IBCBusqueda.TelefonoPersona(txtPER_ID_CLI.Text)
                    Select Case txtPVE_ID_DES.Text
                        Case "002", "030"
                            pMaterialPuesto = "PLANTA"
                        Case "009", "010", "024", "025", "027", "033"
                            pMaterialPuesto = "AGENCIA"
                        Case Else
                            pMaterialPuesto = "SUCURSAL"
                    End Select
                    pDireccionPuntoVenta = Me.IBCBusqueda.DireccionPuntoVenta(txtPVE_ID.Text)
                    If pDocumentoProcesandose = 600 Then
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\Cotizacion.rpt")
                    Else
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\Pedido.rpt")
                    End If

                Case BCVariablesNames.ProcesosFacturación.Boleta, _
                     BCVariablesNames.ProcesosFacturación.BoletaAnticipo, _
                     BCVariablesNames.ProcesosFacturación.PBBoleta
                    vDireccion = txtDIR_DESCRIPCION_DOM.Text & " " & txtDIS_DESCRIPCION_DOM.Text
                    If txtTDP_ID_CLI.Text = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI Then vDOP_NUMERO_CLI = txtDOP_NUMERO_CLI.Text
                    Try
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\Boleta" & NombreDocumentoImprimir)
                    Catch ex As Exception
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\Boleta.rpt")
                    End Try
                    If SessionService.userFactura Then
                        Try
                            If vDOC_SERIE = "022" Or vDOC_SERIE = "007" Or vDOC_SERIE = "888" Then

                            Else
                                ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\BoletaE.rpt")
                            End If
                        Catch ex As Exception
                            MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - Impresión")
                            Exit Sub
                        End Try
                    End If
                Case BCVariablesNames.ProcesosFacturación.Factura, _
                     BCVariablesNames.ProcesosFacturación.FacturaAnticipo, _
                     BCVariablesNames.ProcesosFacturación.PFFactura
                    vDireccion = txtDIR_DESCRIPCION_FIS.Text & " " & txtDIS_DESCRIPCION_FIS.Text
                    If txtTDP_ID_CLI.Text = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC Then vDOP_NUMERO_CLI = txtDOP_NUMERO_CLI.Text
                    Try
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\Factura" & NombreDocumentoImprimir)
                    Catch ex As Exception
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\Factura.rpt")
                    End Try
                    If SessionService.userFactura Then
                        Try
                            If vDOC_SERIE = "022" Or vDOC_SERIE = "007" Then

                            Else
                                ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\FacturaE.rpt")
                            End If
                        Catch ex As Exception
                            MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - Impresión")
                            Exit Sub
                        End Try
                    End If
                Case BCVariablesNames.ProcesosFacturación.NCredito
                    If Trim(txtDIR_DESCRIPCION_FIS.Text) = "" Then
                        vDireccion = txtDIR_DESCRIPCION_DOM.Text & " " & txtDIS_DESCRIPCION_DOM.Text
                    Else
                        vDireccion = txtDIR_DESCRIPCION_FIS.Text & " " & txtDIS_DESCRIPCION_FIS.Text
                    End If

                    vDOP_NUMERO_CLI = txtDOP_NUMERO_CLI.Text
                    Try
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\NotaCredito" & NombreDocumentoImprimir)
                    Catch ex As Exception
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\NotaCredito.rpt")
                    End Try
                    If SessionService.userFactura Then
                        Try
                            If vDOC_SERIE = "001" Then

                            Else
                                ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\NotaCreditoE.rpt")
                            End If
                        Catch ex As Exception
                            MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - Impresión")
                            Exit Sub
                        End Try
                    End If
                Case BCVariablesNames.ProcesosFacturación.NDebito
                    If Trim(txtDIR_DESCRIPCION_FIS.Text) = "" Then
                        vDireccion = txtDIR_DESCRIPCION_DOM.Text & " " & txtDIS_DESCRIPCION_DOM.Text
                    Else
                        vDireccion = txtDIR_DESCRIPCION_FIS.Text & " " & txtDIS_DESCRIPCION_FIS.Text
                    End If
                    vDOP_NUMERO_CLI = txtDOP_NUMERO_CLI.Text
                    Try
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\NotaDebito" & NombreDocumentoImprimir)
                    Catch ex As Exception
                        ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\NotaDebito.rpt")
                    End Try
                    If SessionService.userFactura Then
                        Try
                            ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\NotaDebitoE.rpt")
                        Catch ex As Exception
                            MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - Impresión")
                            Exit Sub
                        End Try
                    End If
            End Select

            Select Case cboDOC_TIPO_LISTA.Text
                Case BCVariablesNames.TipoPuntoVenta.Planta
                    vTipoEntregaProducto = "Entrega en planta"
                Case BCVariablesNames.TipoPuntoVenta.PlantaObra
                    vTipoEntregaProducto = "Entrega a domicilio desde planta"
                Case BCVariablesNames.TipoPuntoVenta.Punto
                    vTipoEntregaProducto = "Entrega en punto de venta"
                Case BCVariablesNames.TipoPuntoVenta.PuntoObra
                    vTipoEntregaProducto = "Entrega a domicilio desde punto de venta"
            End Select

            Dim tableImprimir As New DataTable("Imprimir")
            tableImprimir.Columns.Add("TDO_ID")
            tableImprimir.Columns.Add("DTD_ID")
            tableImprimir.Columns.Add("CCT_ID")
            tableImprimir.Columns.Add("DOC_SERIE")
            tableImprimir.Columns.Add("DOC_NUMERO")
            tableImprimir.Columns.Add("DOC_FECHA_EMI")
            tableImprimir.Columns.Add("PER_DESCRIPCION_CLI")
            tableImprimir.Columns.Add("DIR_DESCRIPCION_FIS")
            tableImprimir.Columns.Add("DOC_TIPO_LISTA")
            tableImprimir.Columns.Add("DOP_NUMERO_CLI")
            tableImprimir.Columns.Add("DOC_ORDEN_COMPRA")
            tableImprimir.Columns.Add("TIV_DESCRIPCION")
            tableImprimir.Columns.Add("DOC_FECHA_EXP")
            tableImprimir.Columns.Add("PER_DESCRIPCION_VEN")
            tableImprimir.Columns.Add("DDO_CANTIDAD")
            tableImprimir.Columns.Add("UM_DESCRIPCION_IMP")
            tableImprimir.Columns.Add("ART_ID_IMP")
            tableImprimir.Columns.Add("ART_DESCRIPCION_IMP")
            tableImprimir.Columns.Add("MON_SIMBOLO")
            tableImprimir.Columns.Add("DDO_PRE_UNI")
            tableImprimir.Columns.Add("DDO_PRE_TOTAL")
            tableImprimir.Columns.Add("TotalIGV")

            Dim vPrecioUnitario As Double = 0
            Dim vPrecioTotal As Double = 0
            Dim vMontoAnticipo As Double = 0
            Dim VMontoDescuento As Double = 0

            For filas = 0 To dgvDetalle.Rows.Count - 1
                vDescripcionTipoDocumento = Trim(Me.IBCBusqueda.DescripcionCortaTipoDocumento(dgvDetalle.Rows(filas).Cells("cTDO_ID_ANT").Value))
                If Trim(dgvDetalle.Rows(filas).Cells("cDDO_SERIE_ANT").Value) <> "" Then
                    vDescripcionArticulo = dgvDetalle.Rows(filas).Cells("cART_DESCRIPCION_IMP").Value & " - " & vDescripcionTipoDocumento & dgvDetalle.Rows(filas).Cells("cDDO_SERIE_ANT").Value & "-" & dgvDetalle.Rows(filas).Cells("cDDO_NUMERO_ANT").Value
                    vPrecioUnitario = CDbl(dgvDetalle.Rows(filas).Cells("cDDO_DES_INC_PRE").Value)
                    vPrecioTotal = CDbl(dgvDetalle.Rows(filas).Cells("cDDO_PRE_TOTAL").Value)
                    vMontoAnticipo = vMontoAnticipo + CDbl(dgvDetalle.Rows(filas).Cells("cDDO_DES_INC_PRE").Value)
                Else
                    vDescripcionArticulo = dgvDetalle.Rows(filas).Cells("cART_DESCRIPCION_IMP").Value
                    vPrecioUnitario = CDbl(dgvDetalle.Rows(filas).Cells("cDDO_PRE_UNI").Value)
                    vPrecioTotal = CDbl(dgvDetalle.Rows(filas).Cells("cDDO_PRE_TOTAL").Value) + (CDbl(dgvDetalle.Rows(filas).Cells("cDDO_DES_INC_PRE").Value) * -1)
                End If
                If chkTransferenciaGratuita.CheckState Or _
                   chkCanastaNavideña.CheckState Then
                    ''txtDOC_SERIE.Text, _
                    ''dtpDOC_FECHA_EXP.Value 
                    tableImprimir.Rows.Add(
                            txtTDO_ID.Text, _
                            txtDTD_ID.Text, _
                            txtCCT_ID.Text, _
                            vDOC_SERIE, _
                            txtDOC_NUMERO.Text, _
                            dtpDOC_FECHA_EMI.Value, _
                            txtPER_DESCRIPCION_CLI.Text, _
                            vDireccion, _
                            vTipoEntregaProducto, _
                            vDOP_NUMERO_CLI, _
                            txtDOC_ORDEN_COMPRA.Text, _
                            txtTIV_DESCRIPCION.Text, _
                            vFechaVencimiento, _
                            txtPER_DESCRIPCION_VEN.Text, _
                            CDbl(dgvDetalle.Rows(filas).Cells("cDDO_CANTIDAD").Value), _
                            dgvDetalle.Rows(filas).Cells("cUM_DESCRIPCION_IMP").Value, _
                            dgvDetalle.Rows(filas).Cells("cART_ID_IMP").Value, _
                            vDescripcionArticulo, _
                            txtMON_SIMBOLO.Text, _
                            0, _
                            0, _
                            0
                            )
                Else
                    ''txtDOC_SERIE.Text, _
                    ''dtpDOC_FECHA_EXP.Value, _
                    tableImprimir.Rows.Add(
                            txtTDO_ID.Text, _
                            txtDTD_ID.Text, _
                            txtCCT_ID.Text, _
                            vDOC_SERIE, _
                            txtDOC_NUMERO.Text, _
                            dtpDOC_FECHA_EMI.Value, _
                            txtPER_DESCRIPCION_CLI.Text, _
                            vDireccion, _
                            vTipoEntregaProducto, _
                            vDOP_NUMERO_CLI, _
                            txtDOC_ORDEN_COMPRA.Text, _
                            txtTIV_DESCRIPCION.Text, _
                            vFechaVencimiento, _
                            txtPER_DESCRIPCION_VEN.Text, _
                            CDbl(dgvDetalle.Rows(filas).Cells("cDDO_CANTIDAD").Value), _
                            dgvDetalle.Rows(filas).Cells("cUM_DESCRIPCION_IMP").Value, _
                            dgvDetalle.Rows(filas).Cells("cART_ID_IMP").Value, _
                            vDescripcionArticulo, _
                            txtMON_SIMBOLO.Text, _
                            vPrecioUnitario, _
                            vPrecioTotal, _
                            CDbl(txtTotalIGV.Text)
                            )
                End If
            Next
            Dim vtxtTotDescInc As Double = 0
            Dim vtxtDOC_MONTO_TOTAL As Double = 0

            If chkTransferenciaGratuita.CheckState Or _
               chkCanastaNavideña.CheckState Then
                vtxtTotDescInc = 0
                vtxtDOC_MONTO_TOTAL = 0
            Else
                vtxtTotDescInc = txtTotDescInc.Text
                vtxtDOC_MONTO_TOTAL = txtDOC_MONTO_TOTAL.Text
            End If

            If vtxtTotDescInc <> 0 And _
                vtxtDOC_MONTO_TOTAL <> 0 Then
                If vMontoAnticipo - vtxtTotDescInc <> 0 Then
                    VMontoDescuento = Math.Abs(vMontoAnticipo) - Math.Abs(vtxtTotDescInc)
                    Dim vDsctoInc As String = ""
                    If vtxtTotDescInc < 0 Then
                        vDsctoInc = "DESCUENTO "
                    Else
                        vDsctoInc = "INCREMENTO "
                    End If
                    ''txtDOC_SERIE.Text, _
                    ''dtpDOC_FECHA_EXP.Value, _
                    tableImprimir.Rows.Add(
                                   txtTDO_ID.Text, _
                                   txtDTD_ID.Text, _
                                   txtCCT_ID.Text, _
                                   vDOC_SERIE, _
                                   txtDOC_NUMERO.Text, _
                                   dtpDOC_FECHA_EMI.Value, _
                                   txtPER_DESCRIPCION_CLI.Text, _
                                   vDireccion, _
                                   vTipoEntregaProducto, _
                                   vDOP_NUMERO_CLI, _
                                   txtDOC_ORDEN_COMPRA.Text, _
                                   txtTIV_DESCRIPCION.Text, _
                                   vFechaVencimiento, _
                                   txtPER_DESCRIPCION_VEN.Text, _
                                   1, _
                                   " ", _
                                   " ", _
                                   vDsctoInc & " POR TEMPORADA", _
                                   txtMON_SIMBOLO.Text, _
                                   0, _
                                   VMontoDescuento, _
                                   0
                                        )
                End If
            End If
            Me.Cursor = Cursors.Default

            If chkTransferenciaGratuita.CheckState Or _
               chkCanastaNavideña.CheckState Then
                If chkTransferenciaGratuita.CheckState Then
                    vCadenaReferencial = "TRANSFERENCIA GRATUITA VALOR REFERENCIAL "
                    'vCodigoTrabajador = ""
                    ReporteDocumento.DataDefinition.FormulaFields("CodigoCliente").Text = "''"
                    vCadenaMonto = cMisProcedimientos.NumeroATexto(txtDOC_MONTO_TOTAL.Text, txtMON_DESCRIPCION.Text)
                Else
                    vCadenaReferencial = "ENTREGA GRATUITA VALOR REFERENCIAL S/. "
                    'vCodigoTrabajador = ReporteDocumento.DataDefinition.FormulaFields("CodigoCliente").Text = "'" & Me.IBCBusqueda.CodigoPersonaEnPlanilla(txtPER_ID_CLI.Text)
                    ReporteDocumento.DataDefinition.FormulaFields("CodigoCliente").Text = "'" & Me.IBCBusqueda.CodigoPersonaEnPlanilla(txtPER_ID_CLI.Text) & "'"
                    vCadenaMonto = txtDOC_MONTO_TOTAL.Text
                End If
                ''txtDOC_SERIE.Text, _
                ''dtpDOC_FECHA_EXP.Value, _
                tableImprimir.Rows.Add(
                                   txtTDO_ID.Text, _
                                   txtDTD_ID.Text, _
                                   txtCCT_ID.Text, _
                                   vDOC_SERIE, _
                                   txtDOC_NUMERO.Text, _
                                   dtpDOC_FECHA_EMI.Value, _
                                   txtPER_DESCRIPCION_CLI.Text, _
                                   vDireccion, _
                                   vTipoEntregaProducto, _
                                   vDOP_NUMERO_CLI, _
                                   txtDOC_ORDEN_COMPRA.Text, _
                                   txtTIV_DESCRIPCION.Text, _
                                   vFechaVencimiento, _
                                   txtPER_DESCRIPCION_VEN.Text, _
                                   0, _
                                   " ", _
                                   " ", _
                                   vCadenaReferencial, _
                                   txtMON_SIMBOLO.Text, _
                                   0, _
                                   0, _
                                   0
                                        )
                '' "TRANSFERENCIA GRATUITA VALOR REFERENCIAL ", _
                '' "ENTREGA GRATUITA VALOR REFERENCIAL S/.", _
                ''txtDOC_SERIE.Text, _
                ''dtpDOC_FECHA_EXP.Value, _
                tableImprimir.Rows.Add(
                                    txtTDO_ID.Text, _
                                    txtDTD_ID.Text, _
                                    txtCCT_ID.Text, _
                                    vDOC_SERIE, _
                                    txtDOC_NUMERO.Text, _
                                    dtpDOC_FECHA_EMI.Value, _
                                    txtPER_DESCRIPCION_CLI.Text, _
                                    vDireccion, _
                                    vTipoEntregaProducto, _
                                    vDOP_NUMERO_CLI, _
                                    txtDOC_ORDEN_COMPRA.Text, _
                                    txtTIV_DESCRIPCION.Text, _
                                    vFechaVencimiento, _
                                    txtPER_DESCRIPCION_VEN.Text, _
                                    0, _
                                    "", _
                                    "", _
                                    vCadenaMonto, _
                                    txtMON_SIMBOLO.Text, _
                                    0, _
                                    0, _
                                    0
                     )

                ''
                '' cMisProcedimientos.NumeroATexto(txtDOC_MONTO_TOTAL.Text, txtMON_DESCRIPCION.Text)

                '' ReporteDocumento.DataDefinition.FormulaFields("CodigoCliente").Text = "'" & Me.IBCBusqueda.CodigoPersonaEnPlanilla(txtPER_ID_CLI.Text) & "'"
                '' txtDOC_MONTO_TOTAL.Text, _
            End If

            ReporteDocumento.SetDataSource(tableImprimir)

            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosFacturación.PFFactura, _
                     BCVariablesNames.ProcesosFacturación.PBBoleta
                    ReporteDocumento.DataDefinition.FormulaFields("Cabecera1").Text = "'" & Me.SessionService.NombreEmpresa.ToUpper & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("Cabecera2").Text = "'" & Me.SessionService.DireccionEmpresa.ToUpper & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("Cabecera3").Text = "'" & Me.SessionService.RUCEmpresa.ToUpper & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("Pie1").Text = "'" & txtDIR_DESCRIPCION_ENT.Text & " - " & txtDIS_DESCRIPCION_ENT.Text & " '"
                    ReporteDocumento.DataDefinition.FormulaFields("Pie2").Text = "'TELEFONO: " & pPER_TELEFONOS & "'"
                    If Trim(txtDOC_ATENCION.Text) = "" Then
                        ReporteDocumento.DataDefinition.FormulaFields("Atencion").Text = "''"
                    Else
                        ReporteDocumento.DataDefinition.FormulaFields("Atencion").Text = "'ATENCIÓN: " & txtDOC_ATENCION.Text & "'"
                    End If


                    ReporteDocumento.DataDefinition.FormulaFields("BaseImponible").Text = "'" & txtBaseImponible.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("TotalIGV").Text = "'" & txtTotalIGV.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("TotalVenta").Text = "'" & txtDOC_MONTO_TOTAL.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("CadenaTotalVenta").Text = "'" & txtDOC_OBSERVACIONES.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("EmailVendedor").Text = "'" & pEmailVendedor & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("TelefonoVendedor").Text = "'" & pTelefonoVendedor & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("TelefonoCliente").Text = "'" & pTelefonoCliente & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("MaterialPuesto").Text = "'" & pMaterialPuesto & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("DireccionPuntoVenta").Text = "'" & pDireccionPuntoVenta & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("Referencia").Text = "'" & txtDIR_REFERENCIA_ENT.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("Observaciones").Text = "'" & txtDOC_OBSERVACIONES.Text & "'"
                    If CDate(dtpDOC_FECHA_EMI.Value) = CDate(dtpDOC_FECHA_ENT.Value) Then
                        ReporteDocumento.DataDefinition.FormulaFields("PlazoEntrega").Text = "'Inmediato'"
                    Else
                        ReporteDocumento.DataDefinition.FormulaFields("PlazoEntrega").Text = "'" & DateDiff(DateInterval.Day, dtpDOC_FECHA_EMI.Value, dtpDOC_FECHA_ENT.Value) & " días'"
                    End If
                Case BCVariablesNames.ProcesosFacturación.NCredito,
                    BCVariablesNames.ProcesosFacturación.NDebito
                    ReporteDocumento.DataDefinition.FormulaFields("Cabecera1").Text = "''"
                    ReporteDocumento.DataDefinition.FormulaFields("Cabecera2").Text = "''"
                    ReporteDocumento.DataDefinition.FormulaFields("Pie1").Text = "''"
                    ReporteDocumento.DataDefinition.FormulaFields("Pie2").Text = "''"

                    ReporteDocumento.DataDefinition.FormulaFields("Cadena1").Text = "''"
                    ReporteDocumento.DataDefinition.FormulaFields("Cadena2").Text = "''"
                    ReporteDocumento.DataDefinition.FormulaFields("Cadena3").Text = "''"
                    ReporteDocumento.DataDefinition.FormulaFields("Cadena4").Text = "''"

                    Select Case cboDOC_MOT_EMI.Text
                        Case "ANULACION"
                            ReporteDocumento.DataDefinition.FormulaFields("Cadena1").Text = "'X'"
                        Case "BONIFICACION"
                            ReporteDocumento.DataDefinition.FormulaFields("Cadena2").Text = "'X'"
                        Case "DESCUENTO"
                            ReporteDocumento.DataDefinition.FormulaFields("Cadena3").Text = "'X'"
                        Case "DEVOLUCIONES"
                            ReporteDocumento.DataDefinition.FormulaFields("Cadena4").Text = "'X'"
                        Case "OTROS"
                            ReporteDocumento.DataDefinition.FormulaFields("Cadena5").Text = "'X'"
                        Case "DESC. ESPEC."
                            ReporteDocumento.DataDefinition.FormulaFields("Cadena3").Text = "'X'"
                    End Select

                    ReporteDocumento.DataDefinition.FormulaFields("Pie1").Text = "'" & txtDTD_DESCRIPCION_AFE.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("Pie2").Text = "'" & txtDOC_SERIE_AFE.Text & "-" & txtDOC_NUMERO_AFE.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("FechaVencimiento").Text = "'" & pFechaDocumento & "'"


                    ReporteDocumento.DataDefinition.FormulaFields("Referencia").Text = "'" & txtDTD_DESCRIPCION_AFE.Text & " " & txtDOC_SERIE_AFE.Text & "-" & txtDOC_NUMERO_AFE.Text & "'"

                    ReporteDocumento.DataDefinition.FormulaFields("BaseImponible").Text = "'" & txtBaseImponible.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("TotalIGV").Text = "'" & txtTotalIGV.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("TotalVenta").Text = "'" & txtDOC_MONTO_TOTAL.Text & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("CadenaTotalVenta").Text = "'" & cMisProcedimientos.NumeroATexto(txtDOC_MONTO_TOTAL.Text, txtMON_DESCRIPCION.Text) & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("Observaciones").Text = "'" & txtDOC_OBSERVACIONES.Text & "'"
                Case Else
                    If txtDOC_SERIE.Text = "001" Or _
                       txtDOC_SERIE.Text = "008" Or _
                       txtDOC_SERIE.Text = "014" Or _
                       txtDOC_SERIE.Text = "018" Or _
                       txtDOC_SERIE.Text = "027" Or _
                       txtDOC_SERIE.Text = "033" Or _
                       txtDOC_SERIE.Text = "034" Or _
                       txtDOC_SERIE.Text = "036" Or _
                       txtDOC_SERIE.Text = "042" Then
                    Else
                        ReporteDocumento.DataDefinition.FormulaFields("Cabecera1").Text = "'" & Me.SessionService.GlosaNuevaDireccion & "'"
                    End If

                    ReporteDocumento.DataDefinition.FormulaFields("Cabecera2").Text = "'" & Me.SessionService.GlosaNoDevoluciones & "'"
                    ReporteDocumento.DataDefinition.FormulaFields("Pie1").Text = "'" & Me.SessionService.GlosaNoAfectoRetenciones & "'"

                    Dim vTelefonoEntrega As String
                    Dim vFechaEntregaI As DateTime
                    Dim vFechaEntregaF As DateTime

                    vFechaEntregaI = dtpDOC_FECHA_ENT.Value + dtpDOC_HORA_INICIO.Value.TimeOfDay
                    vFechaEntregaF = dtpDOC_FECHA_ENT.Value + dtpDOC_HORA_FIN.Value.TimeOfDay
                    vTelefonoEntrega = pPER_TELEFONOS & " - " & vFechaEntregaI.ToString & " / " & Strings.Mid(vFechaEntregaF.ToString, 11, Len(vFechaEntregaF.ToString) - 10)

                    ReporteDocumento.DataDefinition.FormulaFields("Pie2").Text = "'" & vTelefonoEntrega & "' "

                    If chkTransferenciaGratuita.CheckState Or _
                       chkCanastaNavideña.CheckState Then
                        ReporteDocumento.DataDefinition.FormulaFields("BaseImponible").Text = "'0.00'"
                        ReporteDocumento.DataDefinition.FormulaFields("TotalIGV").Text = "'0.00'"
                        ReporteDocumento.DataDefinition.FormulaFields("TotalVenta").Text = "'0.00'"
                        ReporteDocumento.DataDefinition.FormulaFields("CadenaTotalVenta").Text = "'CERO CON 00/100 " & txtMON_DESCRIPCION.Text & "'"
                    Else
                        ReporteDocumento.DataDefinition.FormulaFields("BaseImponible").Text = "'" & txtBaseImponible.Text & "'"
                        ReporteDocumento.DataDefinition.FormulaFields("TotalIGV").Text = "'" & txtTotalIGV.Text & "'"
                        ReporteDocumento.DataDefinition.FormulaFields("TotalVenta").Text = "'" & txtDOC_MONTO_TOTAL.Text & "'"
                        ReporteDocumento.DataDefinition.FormulaFields("CadenaTotalVenta").Text = "'" & cMisProcedimientos.NumeroATexto(txtDOC_MONTO_TOTAL.Text, txtMON_DESCRIPCION.Text) & "'"
                    End If
            End Select

            Dim vDocMontoPercepcion As Double
            Dim vDocVentaPercepcion As Double
            Dim vDocMontoTotal As Double
            vDocMontoPercepcion = txtDOC_MONTO_PERCEPCION.Text
            vDocVentaPercepcion = txtDOC_VENTA_PERCEPCION.Text
            vDocMontoTotal = txtDOC_MONTO_TOTAL.Text

            If vDocMontoPercepcion > 0 Then
                If vEsPersonaAgenteProveedor = BCVariablesNames.AgenteProveedor.AgentePercepcion1 Then
                    ReporteDocumento.DataDefinition.FormulaFields("Pie3").Text = _
                        "'Operación sujeta a percepción del : " _
                        & Format(SessionService.PorcentajePercepcionAgentePercepcion, "##,##0.#0") & _
                        " % , Total venta afecta : " & Format(vDocVentaPercepcion, "##,###.#0") & _
                        " , Total percepción : " & Format(vDocMontoPercepcion, "##,###.#0") & _
                        " , Total a pagar : " & Format(vDocMontoPercepcion + vDocMontoTotal, "##,###.#0") & "'"
                Else
                    ReporteDocumento.DataDefinition.FormulaFields("Pie3").Text = _
                        "'Operación sujeta a percepción del : " _
                        & Format(SessionService.PorcentajePercepcionGeneral, "##,##0.#0") & _
                        " % , Total venta afecta : " & Format(vDocVentaPercepcion, "##,###.#0") & _
                        " , Total percepción : " & Format(vDocMontoPercepcion, "##,###.#0") & _
                        " , Total a pagar : " & Format(vDocMontoPercepcion + vDocMontoTotal, "##,###.#0") & "'"
                End If
            Else
                ReporteDocumento.DataDefinition.FormulaFields("Pie3").Text = "' '"
            End If

            If SessionService.PrevisualizarImpresionEnDocumento Then
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Reporteador)()
                frm.Reporte(ReporteDocumento)
                frm.Show()
                frm.BringToFront()
            Else
                Dim ImprimirDocumento As New CrystalDecisions.Windows.Forms.CrystalReportViewer
                ImprimirDocumento.ReportSource = ReporteDocumento
                ImprimirDocumento.PrintReport()
            End If
        End Sub

        Private Sub DireccionesCrearModificar(ByVal vTipoDireccion As String, ByVal vFlagCrear As Boolean, ByVal vtxt As txt, Optional ByVal vBusqueda As String = "")
            If BloquearBusquedaCampos(vtxt) Then Exit Sub

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmDireccionesPersonas)()
            frm.NombreFormulario = Me

            frm.LlamadaDesdeFormularioCrear = vFlagCrear
            frm.LlamadaDesdeFormularioModificar = Not vFlagCrear

            If vFlagCrear Then
                frm.LLamadaDesdeFormularioDatos.pPer_Id = txtPER_ID_CLI.Text
                frm.LLamadaDesdeFormularioDatos.pDir_Tipo = vTipoDireccion
                frm.LLamadaDesdeFormularioDatos.pProcesoBotonesEdicion = "LlamadaDesdeFormularioNuevoRegistro"
            Else
                frm.DatoBusquedaConsulta = vBusqueda
                frm.MaximizeBox = False
                frm.MinimizeBox = False
                frm.Comportamiento = -1
                frm.LLamadaDesdeFormularioDatos.pProcesoBotonesEdicion = "LlamadaDesdeFormularioModificarRegistro"
            End If
            frm.ShowDialog()
            frm.Dispose()
        End Sub

        Private Sub PersonasCrearModificar(ByVal vFlagCrear As Boolean, _
                                           ByVal vtxt As txt, _
                                           ByVal vNombreCampo As String, _
                                           Optional ByVal vBusqueda As String = "")
            If BloquearBusquedaCampos(vtxt) Then Exit Sub


            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
            frm.NombreFormulario = Me

            frm.LlamadaDesdeFormularioCrear = vFlagCrear
            frm.LlamadaDesdeFormularioModificar = Not vFlagCrear

            frm.LLamadaDesdeFormularioDatos.pTipoPersonaCrear = BCVariablesNames.TipoPersonas.PersonaQueRecepciona

            Select Case vNombreCampo
                Case "txtPER_ID_REC"
                    frm.LLamadaDesdeFormularioDatos.pNombreMostrarTipoPersonaCrear = "Persona que recepcion"
                Case "txtPER_ID_PRO"
                    frm.LLamadaDesdeFormularioDatos.pNombreMostrarTipoPersonaCrear = "Promotor"
            End Select

            If vFlagCrear Then
                If Me.SessionService.NombreEmpresa = "Ladrillera El Diamante SAC" Then
                    frm.LLamadaDesdeFormularioDatos.pTipoVentaDescripcion = BCVariablesNames.TipoVentaDescripcion.Ninguno
                    frm.LLamadaDesdeFormularioDatos.pProcesoBotonesEdicion = "LlamadaDesdeFormularioNuevoRegistro"
                Else
                    Exit Sub
                End If
            Else
                If Me.SessionService.NombreEmpresa = "Ladrillera El Diamante SAC" Then
                    frm.DatoBusquedaConsulta = vBusqueda
                    frm.MaximizeBox = False
                    frm.MinimizeBox = False
                    frm.Comportamiento = -1
                    frm.LLamadaDesdeFormularioDatos.pProcesoBotonesEdicion = "LlamadaDesdeFormularioModificarRegistro"
                Else
                    Exit Sub
                End If
            End If
            frm.ShowDialog()
            frm.Dispose()
            Select Case vNombreCampo
                Case "txtPER_ID_REC"
                    TeclaF1SubLlamadas(txtPER_ID_REC.Name)
                Case "txtPER_ID_PRO"
                    TeclaF1SubLlamadas(txtPER_ID_PRO.Name)
            End Select

        End Sub

        Private Sub btnPasarAfectaMonto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasarAfectaMonto.Click
            Dim vFila As Integer = 0
            If dgvDetalleAfectaMonto.RowCount > 0 Then
                vFila = dgvDetalleAfectaMonto.RowCount
            End If
            dgvDetalleAfectaMonto.Rows.Add(vFila + 1, _
                    txtTDO_ID_AFE.Text, "", _
                    txtDTD_ID_AFE.Text, txtDTD_DESCRIPCION_AFE.Text, _
                    txtCCT_ID_AFE.Text, _
                    txtDOC_SERIE_AFE.Text, txtDOC_NUMERO_AFE.Text, 0, "", _
                    "ACTIVO", 0)
        End Sub

        Private Sub btnPasarAfectaProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasarAfectaProducto.Click
            Dim vFila As Integer = 0
            'If dgvDetalleAfectaMonto.RowCount > 0 Then
            'MsgBox("¡Ingreso monto no puede procesar producto!", MsgBoxStyle.Critical, Me.Text)
            'Else
            If dgvDetalle.RowCount > 0 Then
                If dgvDetalleAfectaProducto.RowCount > 0 Then
                    vFila = dgvDetalleAfectaProducto.RowCount
                End If
                dgvDetalleAfectaProducto.Rows.Add(vFila + 1, _
                        txtTDO_ID_AFE.Text, "", _
                        txtDTD_ID_AFE.Text, txtDTD_DESCRIPCION_AFE.Text, _
                        txtCCT_ID_AFE.Text, _
                        txtDOC_SERIE_AFE.Text, txtDOC_NUMERO_AFE.Text, _
                        dgvDetalle.CurrentRow.Cells("cART_ID_IMP").Value, _
                        dgvDetalle.CurrentRow.Cells("cART_DESCRIPCION_IMP").Value, _
                        dgvDetalle.CurrentRow.Cells("cDDO_CANTIDAD").Value, _
                        "", "", "", "", "", "", "", "", "", 0, "ACTIVO", 0)
            Else
                MsgBox("¡Ingrese un artículo para poder procesar!", MsgBoxStyle.Critical, Me.Text)
            End If
            'End If
        End Sub

        Private Sub chkCanastaNavideña_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCanastaNavideña.CheckedChanged
            If chkCanastaNavideña.Checked = CheckState.Checked Then
                chkTransferenciaGratuita.Checked = CheckState.Unchecked
            Else
                chkTransferenciaGratuita.Checked = CheckState.Unchecked
            End If
        End Sub
        Private Sub chkTransferenciaGratuita_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTransferenciaGratuita.CheckedChanged
            If chkTransferenciaGratuita.Checked = CheckState.Checked Then
                chkCanastaNavideña.Checked = CheckState.Unchecked
            Else
                chkCanastaNavideña.Checked = CheckState.Unchecked
            End If
        End Sub


        Private Sub dtpDOC_HORA_INICIO_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDOC_HORA_INICIO.ValueChanged
            ColocarHoraFinal()
        End Sub
        Private Sub ColocarHoraFinal()
            If vControlarFechaHoraEntrega Then
                dtpDOC_HORA_FIN.Value = dtpDOC_HORA_INICIO.Value.AddHours(8)
                If dtpDOC_HORA_INICIO.Value.TimeOfDay >= dtpDOC_HORA_FIN.Value.TimeOfDay Then
                    dtpDOC_HORA_FIN.Value = New DateTime(dtpDOC_HORA_INICIO.Value.Year, dtpDOC_HORA_INICIO.Value.Month, dtpDOC_HORA_INICIO.Value.Day, 23, 59, 59)
                End If
            End If
            vControlarFechaHoraEntrega = True
        End Sub

        Private Sub btnImprimirReverso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirReverso.Click
            If RevisarDatos(False, True) <> False Then Exit Sub

            If pRegistroNuevo Then
                MsgBox("Debe grabar el documento para poder imprimirlo", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            Dim fecha As Date = dtpDOC_FECHA_EMI.Value


            oReporte.DataDefinition.FormulaFields("NombreVendedor").Text = "'" & txtPER_DESCRIPCION_VEN.Text & "'"
            oReporte.DataDefinition.FormulaFields("Monto").Text = "'" & lblMON_SIMBOLO_1.Text & " " & txtDOC_MONTO_TOTAL.Text & "'"
            oReporte.DataDefinition.FormulaFields("Fecha").Text = "'" & DateAdd(DateInterval.Day, 1, fecha) & "'"

            Dim ImprimirDocumento As New CrystalDecisions.Windows.Forms.CrystalReportViewer
            ImprimirDocumento.ReportSource = oReporte
            ImprimirDocumento.PrintReport()

        End Sub
    End Class
End Namespace
