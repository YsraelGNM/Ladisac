Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Namespace Ladisac.Despachos.Views
    Public Class frmMarcarSalidaGuia
        Public thLlamadaSaldosArticuloDocumento As Threading.Thread
        Public thLlamadaSaldosMontoDocumento As Threading.Thread
        Public thLlamadaProcesarFechaServidor As Threading.Thread
        Public thLlamadaPuntoVenta As Threading.Thread
        Public thLlamadaDetalleTipoDocumento As Threading.Thread
        Public thLlamadaCtaCte As Threading.Thread
#Region "Primaria"
#Region "Declaraciones"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService


        '<Dependency()> _
        'Public Property IBCDespachos As Ladisac.BL.IBCDespachos

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property IBCBusquedaDetalle As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

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
        Private pFechaHora As DateTime

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
            Public Property pDevolverDatosUnicoRegistro As Boolean
            Public Property pDatosBuscados As String

            Public Property pOOrm As Object
            Public Property pFormularioConsulta As Boolean

            Public Property pComportamiento As Int16
            Public Property pOrdenBusqueda As Int16
        End Structure

        Private Sub ValidarDatos(ByRef otxt As txt, _
                                 ByRef txt As TextBox, _
                                 Optional ByVal Texto As String = "")
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
                                       ByVal vtxt As txt, _
                                       Optional ByVal vCantidadRegistros As Int32 = 0)
            pBuscarSeleccionaDatosDevolver = True
            If vProcesandoJalarPrimerArticuloDespachar = True Then
                If BloquearBusquedaCampos(vtxt, False) Then Exit Sub
            Else
                If vProcesandoCronogramaDespacho Then
                    If vtxt.pOOrm.cTabla.NombreCorto = "CtaCte" Then
                        If BloquearBusquedaCampos(vtxt, False) Then Exit Sub
                    Else
                        If BloquearBusquedaCampos(vtxt) Then Exit Sub
                    End If
                Else
                    If BloquearBusquedaCampos(vtxt) Then Exit Sub
                End If
                'Select Case pDTD_ID
                '    Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                '        If vtxt.pOOrm.cTabla.NombreCorto = "CtaCte" Then
                '            If BloquearBusquedaCampos(vtxt, False) Then Exit Sub
                '        End If
                '    Case Else
                '        If BloquearBusquedaCampos(vtxt) Then Exit Sub
                'End Select

            End If
            'vProcesandoJalarPrimerArticuloDespachar = False

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

            If vCantidadRegistros > 0 Then frm.pCantidadRegistros = vCantidadRegistros

            frm.pDevolverDatosUnicoRegistro = vtxt.pDevolverDatosUnicoRegistro
            frm.pDatosBuscados = vtxt.pDatosBuscados
            frm.oOrm = vtxt.pOOrm
            frm.Comportamiento = vtxt.pComportamiento
            frm.NombreFormulario = Me
            frm.OrdenBusqueda = vOrdenBusqueda
            frm.MostrarDatosGrid = vtxt.pMostrarDatosGrid
            frm.ShowDialog()
            frm.Dispose()
            'pDevolverDatosUnicoRegistro = False
        End Sub
        Private Sub TeclaF1(ByRef otxt As txt, ByRef txt As TextBox, Optional ByVal vCantidadRegistros As Int32 = 0)
            If otxt.pBusqueda Then
                otxt.pTexto2 = txt.Text
                ValidarDatos(otxt, txt)
                MetodoBusquedaDato("", False, otxt, vCantidadRegistros)
                otxt.pTexto1 = txt.Text
                otxt.pTexto2 = txt.Text
                If BloquearBusquedaCampos(otxt, False) Then Exit Sub
                TeclaF1SubLlamadas(txt.Name)
            End If
        End Sub

        Private Sub TeclaF1Serie(ByRef otxt As txt, ByRef txt As TextBox, Optional ByVal vCantidadRegistros As Int32 = 0)
            If otxt.pBusqueda Then
                otxt.pTexto2 = txt.Text
                ValidarDatos(otxt, txt)
                MetodoBusquedaDato("", False, otxt, vCantidadRegistros)
                otxt.pTexto1 = txt.Text
                otxt.pTexto2 = txt.Text
                If BloquearBusquedaCampos(otxt, False) Then Exit Sub

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
                    PosicionGrid(NombreMetodo)
                Case "RegistroAnterior"
                    PosicionGrid(NombreMetodo)
                Case "RegistroSiguiente"
                    PosicionGrid(NombreMetodo)
                Case "UltimoRegistro"
                    PosicionGrid(NombreMetodo)
                Case "Salir"
                    Salir()
            End Select
        End Sub

        Public Sub NuevoRegistro()
            'pRegistroNuevo = True
            'LimpiarDatos()
            'HabilitarNuevo()
            'ValoresDefaultNuevo()
            'BotonesEdicion("Crear registro")
            'If Not FlagNuevo Then
            '    CrearCodigoId()
            'Else
            '    HabilitarEscrituraNuevo()
            'End If
            'ConfigurarGrid("ElementoItem")
            'ConfigurarFormulario(2)
        End Sub
        Private Sub LLamarAlmacenPuntoVenta()
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    If Trim(txtPVE_ID.Text) <> "" Then
                        txtALM_ID.Focus()
                        If txtPVE_ID.Text = BCVariablesNames.PuntosVentaPlanta.Principal Then
                            If Trim(txtALM_ID.Text) = "" Then MetodoBusquedaDato(txtPVE_ID.Text & BCVariablesNames.CodigoAlmacenPrincipal, True, EtxtALM_ID)
                        Else
                            If Trim(txtALM_ID.Text) = "" Then MetodoBusquedaDato(txtPVE_ID.Text & "%", True, EtxtALM_ID)
                        End If
                    End If
                Case Else
                    If Trim(txtPVE_ID.Text) <> "" Then
                        txtALM_ID.Focus()
                        If Trim(txtALM_ID.Text) = "" Then MetodoBusquedaDato(txtALM_ID.Text, False, EtxtALM_ID)
                    End If
            End Select


        End Sub
        Private Sub LLamarVendedor()
            If Not pBuscarSeleccionaDatosDevolver Then
                pBuscarSeleccionaDatosDevolver = True
                Exit Sub
            End If
            LLamarDocumentoCliente()

            'txtPER_ID_VEN1.Focus()
            'If Not pBuscarSeleccionaDatosDevolver Then
            '    pBuscarSeleccionaDatosDevolver = True
            '    Exit Sub
            'End If
            'If Trim(txtPER_ID_VEN1.Text) = "" Then
            '    MetodoBusquedaDato(txtPER_ID_VEN1.Text, False, EtxtPER_ID_VEN1)
            'Else
            '    LLamarDocumentoCliente()
            'End If

        End Sub

        Private Sub LLamarCliente()
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                Case Else
                    If Trim(txtALM_ID.Text) <> "" Then
                        'txtPER_ID_CLI.Focus()
                        txtDTD_ID_DOC.Focus()
                        If Not pBuscarSeleccionaDatosDevolver Then
                            pBuscarSeleccionaDatosDevolver = True
                            Exit Sub
                        End If
                        'If Trim(txtPER_ID_CLI.Text) = "" Then
                        'MetodoBusquedaDato(txtPER_ID_CLI.Text, False, EtxtPER_ID_CLI)
                        'Else
                        'LLamarDocumentoCliente()
                        'End If
                        LLamarDocumentoCliente()
                    End If
            End Select
        End Sub

        Private Sub LLamarDocumentoCliente()
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    'If Trim(txtPER_ID_VEN1.Text) <> "" Then
                    txtDTD_ID_DOC.Focus()
                    If Trim(txtDTD_ID_DOC.Text) = "" Then MetodoBusquedaDato(txtDTD_ID_DOC.Text, False, EtxtDTD_ID_DOC)
                    'End If
                Case Else
                    If Trim(txtPER_ID_CLI.Text) <> "" Then
                        txtDTD_ID_DOC.Focus()
                        If Trim(txtDTD_ID_DOC.Text) = "" Then MetodoBusquedaDato(txtDTD_ID_DOC.Text, False, EtxtDTD_ID_DOC)
                    End If
            End Select
        End Sub


        Public Sub EditarRegistro()
            'If Not pFlagNuevo Then If Trim(pCodigoId) = "" Then Return

            'If Me.IBCBusqueda.PermisoCronograma(SessionService.UserId) > 0 Then
            'Else
            '    If cboDES_ESTADO.Text = BCVariablesNames.EstadoRegistro.Procesado Then
            '        Exit Sub
            '    End If
            'End If

            'BotonesEdicion("Editar registro")
            'DeshabilitarModificar()
        End Sub
        Public Sub CancelarEdicion(ByVal vDeshacerCambios As Boolean)
            'Dim vRegistroNuevo As Boolean = False
            'vRegistroNuevo = pRegistroNuevo
            'If Not vDeshacerCambios Then
            '    If Not vRegistroNuevo Then
            '        If RevisarDatos(False) Then Return
            '    End If
            'End If
            'LimpiarDatos()
            'BusquedaDatos("CancelarEdicion")
            'If vDeshacerCambios Then
            '    If vRegistroNuevo Then
            '        BotonesEdicion("Seleccionar registro")
            '    Else
            '        BotonesEdicion("Editar registro")
            '    End If
            'Else
            '    BotonesEdicion("Seleccionar registro")
            'End If
        End Sub
        Public Sub PrepararGuardar(ByVal vNuevo As Boolean)
            Dim bRes As Boolean = False
            bRes = Modificar()
            If (bRes) Then
                BotonesEdicion("Solo grabar")
            End If
        End Sub
        Public Sub PrepararEliminar()
            'Dim bRes As Boolean = False
            'Dim oMsgBoxResult As New MsgBoxResult()
            'Try
            '    oMsgBoxResult = MsgBox("Esta seguro de eliminar el registro", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text)
            '    If (oMsgBoxResult = MsgBoxResult.Yes) Then
            '        bRes = EliminarRegistro()
            '    End If
            '    If (bRes) Then
            '        LimpiarDatos()
            '        BusquedaDatos("PrepararEliminar")
            '        BotonesEdicion("Seleccionar registro")
            '    End If
            'Catch ex As Exception
            '    MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - PrepararEliminar")
            'End Try
        End Sub
        Public Sub Deshacercambios()
            'CancelarEdicion(True)
        End Sub
        Public Sub AgregarFilaGrid()
            'AdicionarFilasGrid()
        End Sub
        Public Sub QuitarFilaGrid()
            'EliminarFilasGrid()
        End Sub
        Public Sub BuscarUnRegistro()
            'vModificandoGuia = True
            'BusquedaDatos("BuscarUnRegistro")
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
                Case "Solo grabar"
                    Nuevo = False
                    Editar = False
                    CancelarEditar = False
                    Grabar = True
                    GrabarNuevo = False
                    Eliminar = False
                    Deshacer = False
                    Agregar = False
                    Quitar = False
                    Buscar = False
                    Inicio = False
                    Anterior = False
                    Siguiente = False
                    Final = False
                    Reportes = False
                    Salida = True
                    pnCuerpo.Enabled = False
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
            RevisarDatos = RevisarDatos(pColeccionDatos, vBoolean, vDesdeImpresion)
            Return RevisarDatos
        End Function
        Private Function RevisarDatos(ByVal vColeccionDatos As Collection, _
                                      ByVal vRespuestaGrabar As Boolean, _
                                      Optional ByVal vDesdeImpresion As Boolean = False) As Boolean
            Dim vRevisarDatosForm As Boolean = False
            vRevisarDatosForm = RevisarDatosForm(vColeccionDatos, True)
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
            'If vProceso Then RevisarDatosForm = False

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
                        If vControl.Name = "chkVentaTercero" Then
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
                    If vControl.Name = "dgvArticulosDocumento" Or _
                        vControl.Name = "dgvSaldosMontoDocumento" Then
                    Else
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
                                                                   Compuesto.cTabla.NombreLargo, Compuesto.CadenaFiltrado)
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
                        frm.OrdenBusqueda = pOrdenBusqueda
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
                                                                     Compuesto.cTabla.NombreLargo, Compuesto.CadenaFiltrado)
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
        Private Function Ingresar() As Boolean
            'Dim vFlagActualizarDocuMovimiento As Boolean = False

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 1
            pRespuestaExtraerDetalle = 0
            Ingresar = False
            DatosCabecera()

            If (Validar("Cabecera")) Then
                Dim ts1 As New TimeSpan(0, 3, 0)
                Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)
                    If (InsertarDatos()) Then
                        Scope.Complete()
                        'vFlagActualizarDocuMovimiento = True
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

            'If vFlagActualizarDocuMovimiento = True Then
            '    IBC.spActualizarDocuMovimiento(Compuesto)
            'End If

            If vCodigoCronogramaTDO_ID <> "" And
               vCodigoCronogramaDTD_ID <> "" And
               vCodigoCronogramaDES_SERIE <> "" And
               vCodigoCronogramaDES_NUMERO <> "" And
               vMensajeMostrar <> 1 Then
                Me.IBCCronogramaDespacho.spActualizarDespachosDES_ESTADO(vCodigoCronogramaTDO_ID, vCodigoCronogramaDTD_ID, vCodigoCronogramaDES_SERIE, vCodigoCronogramaDES_NUMERO, DevolverTiposCampos("DES_ESTADO", BCVariablesNames.EstadoRegistro.NoActivo, Compuesto))
            End If

            Me.Cursor = Windows.Forms.Cursors.Default
            If MensajeOperaciones(vMensajeMostrar, "ingresado") = 1 Then Return Ingresar 'MensajeOperaciones(vRespuestaScope, "ingresado")
            InicializarOrm()
            Return Ingresar
        End Function
        Private Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            Dim vRespuestaLocal1 As Short = 0

            'Compuesto.MarkAsAdded()
            'vRespuestaLocal = Me.IBC.Mantenimiento(Compuesto)

            If IsNothing(Compuesto.ALM_ID_LLEGADA) Then
                vRespuestaLocal = IBC.spInsertarRegistroNullALM_ID_LLEGADA(Compuesto)
            Else
                vRespuestaLocal = IBC.spInsertarRegistro(Compuesto)
            End If

            vRespuestaLocal1 = IBCCorrelativoTipoDocumento.spActualizarRegistro(Compuesto2)

            If vRespuestaLocal = 0 Or vRespuestaLocal1 = 0 Then
                InsertarDatos = False
                Return InsertarDatos
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

        Private Function Modificar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 0
            pRespuestaExtraerDetalle = 0
            Modificar = False
            pFechaHora = IBCMaestro.EjecutarVista("spFechaHoraServidor")
            Dim ts1 As New TimeSpan(0, 3, 0)
            Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)
                pRespuestaExtraerDetalle = ActualizarDatos()
                If pRespuestaExtraerDetalle = 1 Then

                    'Dim Cod As String = BCSalidaVigilancia.SalidaVigilanciaGetByDocumento(Compuesto.TDO_ID & Compuesto.DTD_ID & Compuesto.DES_SERIE & Compuesto.DES_NUMERO).SVI_ID

                    Scope.Complete()

                    'MessageBox.Show(Cod)

                    dgvDatos.Rows.Clear()
                    txtUNT_ID.Text = String.Empty

                    Modificar = True
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

            If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar
            InicializarOrm()
            Me.Cursor = Windows.Forms.Cursors.Default
            Return Modificar
        End Function

        Private Function ActualizarDatos() As Short
            ActualizarDatos = 0
            vMensajeErrorOrm = ""

            Dim vEstado As Short = 0
            Dim vFilGrid As Integer = 0
            If dgvDatos.Rows.Count() = 0 Then
                MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                Return ActualizarDatos
            End If

            While (dgvDatos.Rows.Count() > vFilGrid)
                With dgvDatos.Rows(vFilGrid)
                    If .Cells("cChecked").Value Or _
                       pComportamientoFormulario = 300 Then
                        InicializarOrm()

                        Compuesto.TDO_ID = .Cells("cTDO_ID").Value
                        Compuesto.DTD_ID = .Cells("cDTD_ID").Value
                        Compuesto.DES_SERIE = .Cells("cDES_SERIE").Value
                        Compuesto.DES_NUMERO = .Cells("cDES_NUMERO").Value
                        Compuesto.DES_FEC_SAL_PLA = pFechaHora
                        Compuesto.DES_FEC_CAR_DES = pFechaHora

                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgvDatos, vMensajeErrorOrm & "En fila: " & vFilGrid + 1)
                            ActualizarDatos = -1
                            Exit Function
                        End If

                        If Not Validar("Cabecera") Then
                            ActualizarDatos = -1
                            Exit Function
                        End If

                        Select Case pComportamientoFormulario
                            Case 100
                                ActualizarDatos = Me.IBC.spActualizarDespachosDES_FEC_SAL_PLA(Compuesto)
                                If ActualizarDatos = 1 Then Me.IBC.spEnviarCorreoDespacho(Compuesto)
                                If ActualizarDatos = 1 Then
                                    Dim Cod As String = BCSalidaVigilancia.SalidaVigilanciaGetByDocumento(Compuesto.TDO_ID & Compuesto.DTD_ID & Compuesto.DES_SERIE & Compuesto.DES_NUMERO).SVI_ID
                                    MessageBox.Show(Cod)
                                End If
                            Case 200
                                ActualizarDatos = Me.IBC.spActualizarDespachosDES_FEC_CAR_DES(Compuesto)
                            Case 300
                                If .Cells("cChecked").Value Then
                                    vEstado = 3
                                Else
                                    vEstado = 2
                                End If
                                ActualizarDatos = Me.IBC.spActualizarDespachosDES_ESTADO(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.DES_SERIE, Compuesto.DES_NUMERO, vEstado)
                        End Select

                        If ActualizarDatos = 0 Then
                            vMensajeErrorOrm = Compuesto.vMensajeError
                            Exit Function
                        End If
                    End If
                End With
                vFilGrid += 1
            End While
            Return ActualizarDatos
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
            'Dim vFlagActualizarDocuMovimiento As Boolean = False
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            Dim vMensajeMostrar As Int16 = 0

            Using Scope As New System.Transactions.TransactionScope()
                'Compuesto.MarkAsDeleted()
                'If (ProcesarEliminarDetalle() > 0 And Me.IBC.Mantenimiento(Compuesto) > 0) Then

                If (ProcesarEliminarDetalle() > 0 And Me.IBC.spEliminarRegistro(Compuesto) > 0) Then
                    Scope.Complete()
                    'vFlagActualizarDocuMovimiento = True
                    EliminarRegistro = True
                    vMensajeMostrar = 0
                Else
                    Scope.Dispose()
                    EliminarRegistro = False
                    vMensajeMostrar = 2
                End If
            End Using


            'If vFlagActualizarDocuMovimiento = True Then
            '    IBC.spActualizarDocuMovimiento(Compuesto)
            'End If

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
                                                             Compuesto.cTabla.NombreLargo, Compuesto.CadenaFiltrado)
                    Case "RegistroAnterior"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroAnterior("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar)", _
                                                               Compuesto.CampoPrincipalValor, _
                                                               Compuesto.cTabla.NombreLargo, Compuesto.CadenaFiltrado)
                    Case "RegistroSiguiente"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroSiguiente("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar)", _
                                                                Compuesto.CampoPrincipalValor, _
                                                                Compuesto.cTabla.NombreLargo, Compuesto.CadenaFiltrado)
                    Case "UltimoRegistro"
                        resp = Me.IBCBusqueda.UltimoRegistro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar)", _
                                                             Compuesto.cTabla.NombreLargo, Compuesto.CadenaFiltrado)
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
                                       Optional ByRef vControl As Boolean = True, _
                                       Optional ByRef vStructure As Object = Nothing)
            If vObjeto.GetType <> GetType(ComboBox) And _
                vObjeto.GetType <> GetType(DateTimePicker) Then
                vObjeto.ReadOnly = vControl ' True
            Else
                If Not IsNothing(vStructure) Then vStructure.pEnabled = Not vControl ' False
            End If
            If vObjeto.GetType <> GetType(ComboBox) And _
               vObjeto.GetType <> GetType(DateTimePicker) Then
                vObjeto.Enabled = vControl ' True
            Else
                vObjeto.Enabled = Not vControl ' False
            End If
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
            txtDTD_ID_DOC.ReadOnly = True
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
        Public Property IBC As Ladisac.BL.IBCDespachos

        <Dependency()> _
        Public Property IBCDetalle As Ladisac.BL.IBCDetalleDespachos

        <Dependency()> _
        Public Property IBCCronogramaDespacho As Ladisac.BL.IBCDespachos

        <Dependency()> _
        Public Property IBCCorrelativoTipoDocumento As Ladisac.BL.IBCCorrelativoTipoDocumento

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        <Dependency()> _
        Public Property BCSalidaVigilancia As Ladisac.BL.BCSalidaVigilancia

        Private ProcesarJalarPrimerArticuloDespachar As Boolean = True

        Private iGuiaDespacho As New Object
        Private oImpresion As Object

        Public Property pComportamientoFormulario As Int16 = 0
        Public Property pBusquedaDevolvioDatos As Boolean = False
        Public Property pTDO_ID As String
        Public Property pDTD_ID As String
        Public Property pPVE_ID As String
        Public Property pPVE_ID_CRO As String
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
        Public Property pTIV_FORMA_VENTA As String
        Public Property pTIP_ID As String
        Public Property TipoCambioCompraMoneda As Double
        Public Property TipoCambioVentaMoneda As Double

        Public Property pBuscarSeleccionaDatosDevolver As Boolean
        Public Property pProcesandoCronograma As Boolean = False

        ' Controlar la clave de la tabla
        Public vCodigoDTD_ID As String = ""
        Public vCodigoDES_SERIE As String = ""
        Public vCodigoDES_NUMERO As String = ""

        Public vModificandoGuia As Boolean = False ' Usado para diferenciar detalle diamante/distribuidora

        ' Controlar la clave de la tabla - Cronograma
        Public vCodigoCronogramaTDO_ID As String = ""
        Public vCodigoCronogramaDTD_ID As String = ""
        Public vCodigoCronogramaDES_SERIE As String = ""
        Public vCodigoCronogramaDES_NUMERO As String = ""

        Private vProcesandoCronogramaDespacho As Boolean = False
        Private vProcesandoJalarPrimerArticuloDespachar As Boolean = False

        ' CheckBox
        Private EchkALM_ESTADO As New chk
        Private EchkALM_ESTADO_LLEGADA As New chk
        Private EchkDES_ESTADO As New chk
        Private EchkPER_ESTADO_TRA1 As New chk
        Private EchkPER_ESTADO_CHO As New chk

        ' ComboBox
        Private EcboDES_ESTADO As New cbo

        ' DataGridView
        Private EdgvDetalle As New dgv

        ' TextBox
        '' PK
        Private EtxtPVE_ID As New txt
        Private EtxtDTD_ID As New txt
        Private EtxtCCT_ID As New txt
        Private EtxtPER_ID_VEN1 As New txt
        Private EtxtPER_ID_CLI As New txt
        Private EtxtDTD_ID_DOC As New txt

        'Private EtxtDTD_ID_DOC_PRO As New txt
        'Private EtxtTIV_ID_DOC As New txt
        Private EtxtFLE_ID As New txt
        Private EtxtDIR_ID_ENT As New txt
        Private EtxtPER_ID_REC As New txt
        Private EtxtTDP_ID_REC As New txt
        Private EtxtDIR_ID_ENT_REC As New txt
        Private EtxtPLA_ID As New txt
        Private EtxtUNT_ID As New txt

        '' Texto
        Private EtxtDES_SERIE As New txt
        Private EtxtDES_NUMERO As New txt

        '' Número
        '' PK
        Private EtxtALM_ID As New txt
        Private EtxtALM_ID_LLEGADA As New txt

        ' Celdas para datos tabla detalle 
        '' PK
        Private EtxtART_ID_KAR As New txt

        Private EtxtTDO_ID_CRO As New txt

        Private cMoverTexto1 As String = ""
        Private cMoverTexto2 As String = ""

        Public Property CuadroTexto As New TextBox
        Public Property BuscarCuadroTexto As Boolean = False

        'Private pDevolverDatosUnicoRegistro As Boolean = False

        Private Compuesto As New Ladisac.BE.Despachos
        Private Compuesto1 As New Ladisac.BE.DetalleDespachos
        Private Compuesto11 As New Ladisac.BE.DetalleDespachos ' Para que el hilo de BuscarSeries() no pierda la vista
        Private Compuesto12 As New Ladisac.BE.DetalleDespachos ' Para que el hilo de SaldosMontoDocumento no pierda la vista
        Private Compuesto2 As New Ladisac.BE.CorrelativoTipoDocumento
        Private ErrorData As New Ladisac.BE.Despachos.ErrorData
        Private cMisProcedimientos As New Ladisac.MisProcedimientos
        Private Structure ElementosEliminar
            Public cTDO_ID As String
            Public cDTD_ID As String
            Public cDDE_SERIE As String
            Public cDDE_NUMERO As String
            Public cDDE_ITEM As String
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
            vBuscarDetalle = False
            vProcesandoCronogramaDespacho = False
            vProcesandoJalarPrimerArticuloDespachar = False

            vCodigoCronogramaTDO_ID = ""
            vCodigoCronogramaDTD_ID = ""
            vCodigoCronogramaDES_SERIE = ""
            vCodigoCronogramaDES_NUMERO = ""

            InicializarValores(txtPVE_ID, ErrorProvider1)
            InicializarValores(txtTDO_ID, ErrorProvider1)
            InicializarValores(txtDTD_ID, ErrorProvider1)
            InicializarValores(txtDES_SERIE, ErrorProvider1)
            InicializarValores(txtDES_NUMERO, ErrorProvider1)

            InicializarValores(txtALM_ID, ErrorProvider1)
            InicializarValores(txtALM_DESCRIPCION, ErrorProvider1)
            ColocarValoresDefault(chkALM_ESTADO)

            InicializarValores(txtALM_ID_LLEGADA, ErrorProvider1)
            InicializarValores(txtALM_DESCRIPCION_LLEGADA, ErrorProvider1)
            ColocarValoresDefault(chkALM_ESTADO_LLEGADA)

            InicializarValores(txtCCT_ID, ErrorProvider1)
            InicializarValores(txtCCT_DESCRIPCION, ErrorProvider1)

            InicializarValores(txtALM_DIRECCION, ErrorProvider1)
            InicializarValores(txtDIS_ID_ALM, ErrorProvider1)
            InicializarValores(txtDIS_DESCRIPCION_ALM, ErrorProvider1)
            InicializarValores(txtPRO_ID_ALM, ErrorProvider1)
            InicializarValores(txtPRO_DESCRIPCION_ALM, ErrorProvider1)
            InicializarValores(txtDEP_ID_ALM, ErrorProvider1)
            InicializarValores(txtDEP_DESCRIPCION_ALM, ErrorProvider1)
            InicializarValores(txtPAI_ID_ALM, ErrorProvider1)
            InicializarValores(txtPAI_DESCRIPCION_ALM, ErrorProvider1)

            InicializarValores(txtPER_ID_CLI, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_CLI, ErrorProvider1)

            InicializarValores(txtTDO_ID_DOC, ErrorProvider1)
            InicializarValores(txtDTD_ID_DOC, ErrorProvider1)
            InicializarValores(txtDTD_DESCRIPCION_DOC, ErrorProvider1)
            InicializarValores(txtDES_SERIE_DOC, ErrorProvider1)
            InicializarValores(txtDES_NUMERO_DOC, ErrorProvider1)
            InicializarValores(txtDOC_TIPO_LISTA, ErrorProvider1)

            InicializarValores(txtDIR_ID_ENT, ErrorProvider1)
            InicializarValores(txtDIR_DESCRIPCION_ENT, ErrorProvider1)
            InicializarValores(txtDIS_ID_ENT, ErrorProvider1)
            InicializarValores(txtDIS_DESCRIPCION_ENT, ErrorProvider1)
            InicializarValores(txtPRO_ID_ENT, ErrorProvider1)
            InicializarValores(txtPRO_DESCRIPCION_ENT, ErrorProvider1)
            InicializarValores(txtDEP_ID_ENT, ErrorProvider1)
            InicializarValores(txtDEP_DESCRIPCION_ENT, ErrorProvider1)
            InicializarValores(txtPAI_ID_ENT, ErrorProvider1)
            InicializarValores(txtPAI_DESCRIPCION_ENT, ErrorProvider1)

            InicializarValores(txtPLA_ID, ErrorProvider1)
            InicializarValores(txtUNT_ID_1, ErrorProvider1)
            InicializarValores(txtUNT_ID_2, ErrorProvider1)
            InicializarValores(txtCertificado, ErrorProvider1)

            InicializarValores(txtPER_ID_TRA1, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_TRA1, ErrorProvider1)
            InicializarValores(txtRUC_TRA1, ErrorProvider1)
            ColocarValoresDefault(chkPER_ESTADO_TRA1)

            InicializarValores(txtPER_ID_CHO, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_CHO, ErrorProvider1)
            InicializarValores(txtPER_BREVETE_CHO, ErrorProvider1)
            ColocarValoresDefault(chkPER_ESTADO_CHO)

            InicializarValores(dgvDetalle, ErrorProvider1)

            FiltrarSeleccionarValidarElementos(2, True)

            ReDim eRegistrosEliminar(1)
            vBuscarDetalle = True
            vModificandoGuia = False
        End Sub
        Private Sub HabilitarNuevo()
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, False)
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)
            ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, False)
            ControlVisible(cboSerieCorrelativo, True)
            ConfigurarReadOnlyNoBusqueda(txtDES_NUMERO, EtxtDES_NUMERO, False)
            ConfigurarReadOnlyNoBusqueda(txtALM_ID, EtxtALM_ID, False)

            ConfigurarReadOnlyNoBusqueda(txtALM_ID_LLEGADA, EtxtALM_ID_LLEGADA, False)

            ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID_DOC, EtxtDTD_ID_DOC, False)

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    cboDES_ESTADO.Enabled = False
            End Select
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkALM_ESTADO)
            ColocarValoresDefault(chkPER_ESTADO_TRA1)
            ColocarValoresDefault(chkPER_ESTADO_CHO)
            ProcesarGridVacio()
        End Sub
        Private Sub ProcesarGridVacio()
            If dgvDetalle.RowCount = 0 Then
            End If
            If dgvDetalle.RowCount >= 1 Then
            End If
        End Sub

        Private Sub LlamadaPuntoVenta()
            thLlamadaPuntoVenta = New Threading.Thread(AddressOf PuntoVenta)
            If thLlamadaPuntoVenta.ThreadState <> Threading.ThreadState.Running Then
                thLlamadaPuntoVenta.Start()
            End If
        End Sub
        Private Sub PuntoVenta()
            txtPVE_ID.Text = pPVE_ID
            EtxtPVE_ID.pOOrm.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
            MetodoBusquedaDato(txtPVE_ID.Text, True, EtxtPVE_ID)
            pPVE_ID = txtPVE_ID.Text
            thLlamadaPuntoVenta.Abort()
        End Sub
        Private Sub LlamadaDetalleTipoDocumento()
            thLlamadaDetalleTipoDocumento = New Threading.Thread(AddressOf DetalleTipoDocumento)
            If thLlamadaDetalleTipoDocumento.ThreadState <> Threading.ThreadState.Running Then
                thLlamadaDetalleTipoDocumento.Start()
            End If
        End Sub
        Private Sub DetalleTipoDocumento()
            txtTDO_ID.Text = pTDO_ID
            txtDTD_ID.Text = pDTD_ID
            CodigoId = txtTDO_ID.Text.Trim
            MetodoBusquedaDato(txtDTD_ID.Text, True, EtxtDTD_ID)
            thLlamadaDetalleTipoDocumento.Abort()
        End Sub

        Private Sub LlamadaCtaCte()
            thLlamadaCtaCte = New Threading.Thread(AddressOf CtaCte)
            If thLlamadaCtaCte.ThreadState <> Threading.ThreadState.Running Then
                thLlamadaCtaCte.Start()
            End If
        End Sub
        Private Sub CtaCte()
            txtCCT_ID.Text = pCCT_ID
            MetodoBusquedaDato(txtCCT_ID.Text, True, EtxtCCT_ID)
            thLlamadaCtaCte.Abort()
        End Sub

        Private Sub CrearCodigoId()
            LlamadaProcesarFechaServidor()
            LlamadaPuntoVenta()
            LlamadaDetalleTipoDocumento()
            LlamadaCtaCte()

            'ProcesarFechaServidor()

            'txtPVE_ID.Text = pPVE_ID
            'EtxtPVE_ID.pOOrm.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
            'MetodoBusquedaDato(txtPVE_ID.Text, True, EtxtPVE_ID)

            'txtTDO_ID.Text = pTDO_ID
            'txtDTD_ID.Text = pDTD_ID
            'CodigoId = txtTDO_ID.Text.Trim
            'MetodoBusquedaDato(txtDTD_ID.Text, True, EtxtDTD_ID)

            'txtCCT_ID.Text = pCCT_ID
            'MetodoBusquedaDato(txtCCT_ID.Text, True, EtxtCCT_ID)

            BuscarSeries()
            CodigoId = txtTDO_ID.Text.Trim
            vCodigoDTD_ID = txtDTD_ID.Text.Trim
            vCodigoDES_SERIE = txtDES_SERIE.Text.Trim
            vCodigoDES_NUMERO = txtDES_NUMERO.Text.Trim
        End Sub
        Private Sub HabilitarEscrituraNuevo()
            txtTDO_ID.ReadOnly = False
            'txtDTD_ID.ReadOnly = False
            txtDES_SERIE.ReadOnly = False
            txtDES_NUMERO.ReadOnly = False
        End Sub
        Private Sub ConfigurarFormulario(ByVal vControl As Integer)
            txtDIR_DESCRIPCION_ENT.BackColor = System.Drawing.Color.White
            txtDIR_REFERENCIA_ENT.BackColor = System.Drawing.Color.White
            txtDIR_DESCRIPCION_ENT.ForeColor = System.Drawing.Color.Red
            txtDIR_REFERENCIA_ENT.ForeColor = System.Drawing.Color.Red
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaDespacho, _
                     BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho, _
                     BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                    If pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora Then
                        Compuesto.Vista = "BuscarRegistrosDocumentoDesdeDistribuidora"
                        Compuesto.pBuscarRegistros = False
                    End If
                    If pDTD_ID = BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho Then
                        dtpDES_FEC_EMI.CustomFormat = "dd/MM/yyyy HH:mm"
                        dtpDES_FEC_EMI.Format = DateTimePickerFormat.Custom
                    End If
                    GuiaDespacho(vControl)
                Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion
                    GuiaDevolucion(vControl)
                Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                    GuiaTransferencia(vControl)
                Case BCVariablesNames.ProcesosDespacho.GuiaSalida
                    GuiaSalida(vControl)
                Case Else
            End Select
        End Sub
        Private Sub GuiaDespacho(ByVal vControl As Integer)
            If vControl = 1 Then
                Select Case pComportamientoFormulario
                    Case 100 ' Control garita
                        lbltxt.Text = "Unidad de transportista:"
                        txtUNT_ID.Enabled = True
                        txtUNT_ID.Visible = True

                        txtDES_NUMERO_X.Enabled = False
                        txtDES_NUMERO_X.Visible = False

                        dtpFecha.Enabled = False
                        dtpFecha.Visible = False
                    Case 200 ' Control carga
                        lbltxt.Text = "Guía número:"
                        txtUNT_ID.Enabled = False
                        txtUNT_ID.Visible = False

                        txtDES_NUMERO_X.Enabled = True
                        txtDES_NUMERO_X.Visible = True

                        dtpFecha.Enabled = False
                        dtpFecha.Visible = False
                    Case 300 ' Habilitar cronograma
                        lbltxt.Text = "Fecha de la guía:"
                        txtUNT_ID.Enabled = False
                        txtUNT_ID.Visible = False

                        txtDES_NUMERO_X.Enabled = False
                        txtDES_NUMERO_X.Visible = False

                        dtpFecha.Enabled = True
                        dtpFecha.Visible = True
                    Case 400 ' Visualizar cronograma
                        lbltxt.Text = "Fecha de la guía:"
                        txtUNT_ID.Enabled = False
                        txtUNT_ID.Visible = False

                        txtDES_NUMERO_X.Enabled = False
                        txtDES_NUMERO_X.Visible = False

                        dtpFecha.Enabled = True
                        dtpFecha.Visible = True
                        cChecked.ReadOnly = True
                End Select


                tcoDirecciones.SelectedIndex = 0
                ConfigurarDatos("tpaEntrega")
                If Not DesignMode Then
                    lblALM_ID.Text = "Alm.Sal."
                    tpaEntrega.Text = "Dir. Entrega"
                    VisualizarDatosClienteDocumento(True)
                    VisualizarDatosALmacenLLegada(False)
                    cDDE_CANTIDAD.ReadOnly = True
                    cART_ID_KAR.ReadOnly = True
                End If
            End If
            NuevoGuiaDespacho() 'Habilita los controles
        End Sub
        Private Sub NuevoGuiaDespacho()
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    'MostrarVendedor(True)
                    MostrarVendedor()
                Case Else
                    MostrarVendedor()
            End Select
        End Sub
        Private Sub GuiaDevolucion(ByVal vControl As Integer)
            If vControl = 1 Then
                tcoDirecciones.SelectedIndex = 0
                ConfigurarDatos("tpaDocumento")
                If Not DesignMode Then
                    lblALM_ID.Text = "Alm.Ing."
                    tpaEntrega.Text = "Dir. Partida"
                    VisualizarDatosClienteDocumento(True)
                    VisualizarDatosALmacenLLegada(False)
                    cDDE_CANTIDAD.ReadOnly = True
                    cART_ID_KAR.ReadOnly = True
                End If
            End If
            NuevoGuiaDevolucion() 'Habilita los controles
        End Sub
        Private Sub NuevoGuiaDevolucion()
            MostrarVendedor()
        End Sub
        Private Sub GuiaTransferencia(ByVal vControl As Integer)
            If vControl = 1 Then
                tcoDirecciones.SelectedIndex = 0
                ConfigurarDatos("tpaEntrega")
                If Not DesignMode Then
                    lblALM_ID.Text = "Alm.Sal."
                    lblALM_ID_LLEGADA.Text = "Alm.Ing."
                    tpaEntrega.Text = "Dir. Partida"
                    VisualizarDatosClienteDocumento(False)
                    VisualizarDatosALmacenLLegada(True)
                    cDDE_CANTIDAD.ReadOnly = False
                    cART_ID_KAR.ReadOnly = False
                End If
            End If
            NuevoGuiaTransferencia() 'Habilita los controles
        End Sub
        Private Sub NuevoGuiaTransferencia()
            MostrarVendedor()
        End Sub
        Private Sub GuiaSalida(ByVal vControl As Integer)
            'If vControl = 1 Then
            '    tcoDirecciones.SelectedIndex = 0
            '    ConfigurarDatos("tpaDocumento")
            '    If Not DesignMode Then
            '        lblALM_ID.Text = "Alm.Sal."
            '        tpaEntrega.Text = "Dir. Entrega"
            '        VisualizarDatosClienteDocumento(True)
            '        VisualizarDatosALmacenLLegada(False)
            '        cDDE_CANTIDAD.ReadOnly = True
            '        cART_ID_KAR.ReadOnly = True
            '    End If
            'End If
            'NuevoGuiaSalida() 'Habilita los controles
        End Sub
        Private Sub NuevoGuiaSalida()
            'Select Case pDTD_ID
            '    Case BCVariablesNames.ProcesosDespacho.GuiaDespacho
            '        MostrarVendedor()
            '    Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
            '        MostrarVendedor(True)
            'End Select
        End Sub



        Private Sub VisualizarDatosClienteDocumento(ByVal vVisible As Boolean)
            lblPER_ID_CLI.Visible = vVisible
            txtPER_ID_CLI.Visible = vVisible
            txtPER_DESCRIPCION_CLI.Visible = vVisible
            lblDTD_ID_DOC.Visible = vVisible
            txtDTD_ID_DOC.Visible = vVisible
            txtDTD_DESCRIPCION_DOC.Visible = vVisible
            lblDOC_SERIE_DOC.Visible = vVisible
            lblDOC_SERIE_DOC.Visible = vVisible
            lblSeparador1.Visible = vVisible
            txtDES_SERIE_DOC.Visible = vVisible
            txtDES_NUMERO_DOC.Visible = vVisible
            txtDOC_TIPO_LISTA.Visible = vVisible
        End Sub
        Private Sub VisualizarDatosALmacenLLegada(ByVal vVisible As Boolean)
            lblALM_ID_LLEGADA.Visible = vVisible
            txtALM_ID_LLEGADA.Visible = vVisible
            txtALM_DESCRIPCION_LLEGADA.Visible = vVisible
            chkALM_ESTADO_LLEGADA.Visible = vVisible
            txtALM_DIRECCION_LLEGADA.Visible = vVisible
            txtDIS_ID_ALM_LLEGADA.Visible = vVisible
            txtDIS_DESCRIPCION_ALM_LLEGADA.Visible = vVisible
            txtPRO_ID_ALM_LLEGADA.Visible = vVisible
            txtPRO_DESCRIPCION_ALM_LLEGADA.Visible = vVisible
            txtDEP_ID_ALM_LLEGADA.Visible = vVisible
            txtDEP_DESCRIPCION_ALM_LLEGADA.Visible = vVisible
            txtPAI_ID_ALM_LLEGADA.Visible = vVisible
            txtPAI_DESCRIPCION_ALM_LLEGADA.Visible = vVisible
        End Sub

        Private Sub RemoverTabs(ByRef vTabControl As TabControl, ByRef vTapPage As TabPage)
            vTabControl.TabPages.Remove(vTapPage)
        End Sub

        Public Sub DeshabilitarModificar()
            ProcesarGridVacio()
            DesBloquearBloquearControlesXModificar()
        End Sub
        Private Sub DesBloquearBloquearControlesXModificar()
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtDES_SERIE, EtxtDES_SERIE, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtDES_NUMERO, EtxtDES_NUMERO, True) ' Bloquea
            ControlVisible(cboSerieCorrelativo, False) ' Oculta
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    ConfigurarReadOnly(dtpDES_FEC_EMI, False) ' Desbloquea
                    If Me.IBCBusqueda.PermisoCronograma(SessionService.UserId) > 0 Then
                        cboDES_ESTADO.Enabled = True
                    Else
                        cboDES_ESTADO.Enabled = False
                    End If
                Case Else
                    If Me.IBCBusqueda.EditarFechaEmisionDespachos(SessionService.UserId) Then
                        ConfigurarReadOnly(dtpDES_FEC_EMI, False) ' Desbloquea
                    Else
                        ConfigurarReadOnly(dtpDES_FEC_EMI) ' Bloquea
                    End If
            End Select

            ConfigurarReadOnlyNoBusqueda(txtALM_ID, EtxtALM_ID, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtALM_ID_LLEGADA, EtxtALM_ID_LLEGADA, True) ' Bloquea

            ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID_DOC, EtxtDTD_ID_DOC, True) ' Bloquea
        End Sub
        Private Sub AdicionarFilasGrid()
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                    dgvDetalle.Rows.Add(EdgvDetalle.Elementos + 1, "", "", 1, "", "", "", 1, "", 0, "ACTIVO", 0)
                    EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
                Case Else
            End Select
        End Sub
        Private Sub EliminarFilasGrid()
            If dgvDetalle.Rows.Count = 0 Then Return
            Dim vfila As DataGridViewRow
            vfila = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index)
            If dgvDetalle.Rows.Count > 0 Then
                Try
                    With dgvDetalle.Rows(dgvDetalle.CurrentRow.Index)
                        If .Cells("cEstadoRegistro").Value Then
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cTDO_ID = txtTDO_ID.Text.Trim
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTD_ID = txtDTD_ID.Text.Trim
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDDE_SERIE = txtDES_SERIE.Text.Trim
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDDE_NUMERO = txtDES_NUMERO.Text.Trim
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDDE_ITEM = .Cells("cITEM").Value.ToString()
                            ReDim Preserve eRegistrosEliminar(eRegistrosEliminar.Count)
                        End If
                    End With
                    dgvDetalle.Rows.Remove(vfila)
                    If dgvDetalle.Rows.Count = 0 Then vProcesandoJalarPrimerArticuloDespachar = False
                Catch ex As Exception
                    MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- QuitarFilaGrid")
                End Try
            End If
        End Sub
        Public Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "CancelarEdicion"
                    CodigoId = CodigoId & vCodigoDTD_ID & vCodigoDES_SERIE & vCodigoDES_NUMERO
                    If Trim(CodigoId) = "" Then CodigoId = "%"
                Case "PrepararEliminar"
                    Compuesto.Vista = "RegistroAnterior"
                    Compuesto.TDO_ID = CodigoId
                    Compuesto.DTD_ID = vCodigoDTD_ID
                    Compuesto.DES_SERIE = vCodigoDES_SERIE
                    Compuesto.DES_NUMERO = vCodigoDES_NUMERO
                Case "Load"
                    Compuesto.Vista = "PrimerAnterior"
                    Compuesto.TDO_ID = CodigoId
                    Compuesto.DTD_ID = vCodigoDTD_ID
                    Compuesto.DES_SERIE = vCodigoDES_SERIE
                    Compuesto.DES_NUMERO = vCodigoDES_NUMERO
                Case "RegistroNoEncontrado"
                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    Compuesto.DES_SERIE = txtDES_SERIE.Text.Trim
                    Compuesto.DES_NUMERO = txtDES_NUMERO.Text.Trim
                Case "NavegarFormulario"
                    CodigoId = CodigoId & vCodigoDTD_ID & vCodigoDES_SERIE & vCodigoDES_NUMERO
                Case "EliminarRegistro"
                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim
                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim
                    Compuesto.DES_SERIE = txtDES_SERIE.Text.Trim
                    vCodigoDES_SERIE = txtDES_SERIE.Text.Trim
                    Compuesto.DES_NUMERO = txtDES_NUMERO.Text.Trim
                    vCodigoDES_NUMERO = txtDES_NUMERO.Text.Trim
                Case "InicializarDatos"
                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim
                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim
                    Compuesto.DES_SERIE = txtDES_SERIE.Text.Trim
                    vCodigoDES_SERIE = txtDES_SERIE.Text.Trim
                    Compuesto.DES_NUMERO = txtDES_NUMERO.Text.Trim
                    vCodigoDES_NUMERO = txtDES_NUMERO.Text.Trim
                    Compuesto1.TDO_ID = txtTDO_ID.Text.Trim
                    If vBuscarDetalle Then
                        BuscarDetalle(CodigoId, vCodigoDTD_ID, vCodigoDES_SERIE, vCodigoDES_NUMERO)
                        ProcesarJalarPrimerArticuloDespachar = True
                    End If
            End Select
        End Sub
        Public Sub BuscarDetalle(ByVal CodigoTDO_ID As String, _
                                 ByVal CodigoDTD_ID As String, _
                                 ByVal CodigoDES_SERIE As String, _
                                 ByVal CodigoDES_NUMERO As String, _
                                 Optional ByVal vProcesarProforma As Boolean = False)
            Dim x As Int32 = 0
            Dim y As Int32 = 0

            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                    If vModificandoGuia Then
                        Compuesto1.Vista = "ListarRegistros"
                    Else
                        Compuesto1.Vista = "ListarRegistrosDesdeDistribuidora"
                        CodigoDES_SERIE = "9" & Strings.Mid(CodigoDES_SERIE, 2, 2)
                    End If
                Case Else
                    Compuesto1.Vista = "ListarRegistros"
            End Select

            Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                CodigoTDO_ID, _
                                                                CodigoDTD_ID, _
                                                                CodigoDES_SERIE, _
                                                                CodigoDES_NUMERO, _
                                                                Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                x = 0
                y = 0
                dgvDetalle.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
                        dgvDetalle.Rows.Add()
                        With ds.Tables(0).Rows(x)
                            While y < ds.Tables(0).Columns.Count
                                dgvDetalle.Item(y, dgvDetalle.Rows.Count - 1).Value = _
                                    Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                y = y + 1
                            End While
                            y = 0
                        End With
                        x += 1
                        EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information)
                End If
                If vProcesarProforma Then
                    vCodigoCronogramaTDO_ID = CodigoTDO_ID
                    vCodigoCronogramaDTD_ID = CodigoDTD_ID
                    vCodigoCronogramaDES_SERIE = CodigoDES_SERIE
                    vCodigoCronogramaDES_NUMERO = CodigoDES_NUMERO
                    ProcesarJalarCronograma()
                Else
                    vCodigoCronogramaTDO_ID = ""
                    vCodigoCronogramaDTD_ID = ""
                    vCodigoCronogramaDES_SERIE = ""
                    vCodigoCronogramaDES_NUMERO = ""
                End If
            Else
                dgvDetalle.DataSource = Nothing
            End If
        End Sub
        Private Sub ProcesarJalarCronograma()
            FiltroDTD_ID_DOC()

            'SaldosArticuloDocumento()
            'JalarPrimerArticuloDespachar()

            'SaldosMontoDocumento()

            ProcesarLugarLLegada()

            'ProcesarGridVacio()
            'VerificarDescuentosProforma()
        End Sub


        Private Sub Pausa(ByVal segundos As Integer)
            Dim esperaTmp As Long = My.Computer.Clock.TickCount + (segundos * 1000)
            While esperaTmp > My.Computer.Clock.TickCount
                System.Windows.Forms.Application.DoEvents()
            End While
        End Sub


        Private Sub ProcesarLugarLLegada()
            Select Case txtDOC_TIPO_LISTA.Text
                Case BCVariablesNames.TipoPuntoVenta.Planta, _
                     BCVariablesNames.TipoPuntoVenta.Punto
                    If pRegistroNuevo Then
                        MetodoBusquedaDato(Me.SessionService.PlacaElMismo, True, EtxtPLA_ID)
                        MetodoBusquedaDato("X", True, EtxtDIR_ID_ENT)
                        txtDIR_ID_ENT.Text = Nothing

                        txtDIR_DESCRIPCION_ENT.Text = txtALM_DIRECCION.Text
                        txtDIS_DESCRIPCION_ENT.Text = txtDIS_DESCRIPCION_ALM.Text
                        txtPRO_DESCRIPCION_ENT.Text = txtPRO_DESCRIPCION_ALM.Text
                        txtDEP_DESCRIPCION_ENT.Text = txtDEP_DESCRIPCION_ALM.Text
                        txtPAI_DESCRIPCION_ENT.Text = txtPAI_DESCRIPCION_ALM.Text
                    End If
                    'txtPLA_ID.Enabled = False
                    'txtDIR_ID_ENT.Enabled = False
                    txtPLA_ID.Enabled = True
                    txtDIR_ID_ENT.Enabled = True
                Case Else
                    txtPLA_ID.Enabled = True
                    txtDIR_ID_ENT.Enabled = True
                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                            MetodoBusquedaDato(Me.SessionService.PlacaElMismo, True, EtxtPLA_ID)
                        Case Else
                    End Select
            End Select
        End Sub

        Function Formatos(ByVal vCadena As String, ByVal vValor As Object)
            Select Case vCadena
                Case "System.String"
                    Return vValor.ToString
                Case "System.DateTime"
                    Return CDate(vValor)
                Case "System.Int32"
                    Return Val(vValor)
                Case Else
                    Return vValor
            End Select
        End Function
        Private Function ProcesarDatosDetalle() As Int16
            Dim vFilGrid As Integer = 0
            ProcesarDatosDetalle = 0
            If dgvDetalle.Rows.Count() = 0 Then
                MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                Return ProcesarDatosDetalle
            End If
            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    vMensajeErrorOrm = ""
                    InicializarOrmDetalle()
                    Compuesto1.TDO_ID = txtTDO_ID.Text
                    Compuesto1.DTD_ID = txtDTD_ID.Text
                    Compuesto1.DDE_SERIE = txtDES_SERIE.Text
                    Compuesto1.DDE_NUMERO = txtDES_NUMERO.Text
                    Compuesto1.DDE_ITEM = CDbl(.Cells("cITEM").Value)
                    Compuesto1.ART_ID_IMP = .Cells("cART_ID_IMP").Value
                    Compuesto1.ART_ID_KAR = .Cells("cART_ID_KAR").Value
                    Compuesto1.DDE_CANTIDAD = CDbl(.Cells("cDDE_CANTIDAD").Value)
                    Compuesto1.USU_ID = SessionService.UserId
                    Compuesto1.DDE_FEC_GRAB = Now
                    Compuesto1.DDE_ESTADO = DevolverTiposCampos("DDE_ESTADO", .Cells("cDDE_ESTADO").Value.ToString, Compuesto1)

                    If vMensajeErrorOrm <> "" Then
                        ErrorProvider1.SetError(dgvDetalle, vMensajeErrorOrm & "En fila: " & vFilGrid + 1)
                        ProcesarDatosDetalle = -1
                        Exit Function
                    End If

                    If Not Validar("Detalle") Then
                        ProcesarDatosDetalle = -1
                        Exit Function
                    End If

                    If (.Cells("cEstadoRegistro").Value = 1 Or .Cells("cEstadoRegistro").Value = True) Then
                        ProcesarDatosDetalle = IBCDetalle.spActualizarRegistro(Compuesto1)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto1.vMensajeError
                            Exit Function
                        End If
                    Else
                        ProcesarDatosDetalle = IBCDetalle.spinsertarRegistro(Compuesto1)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto1.vMensajeError
                            Exit Function
                        End If
                    End If
                End With
                vFilGrid += 1
            End While
            Return ProcesarDatosDetalle
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

                    Compuesto1.TDO_ID = eRegistrosEliminar(fila).cTDO_ID
                    Compuesto1.DTD_ID = eRegistrosEliminar(fila).cDTD_ID
                    Compuesto1.DDE_SERIE = eRegistrosEliminar(fila).cDDE_SERIE
                    Compuesto1.DDE_NUMERO = eRegistrosEliminar(fila).cDDE_NUMERO
                    Compuesto1.DDE_ITEM = eRegistrosEliminar(fila).cDDE_ITEM

                    EliminarRegistroDetalle = Me.IBCDetalle.spEliminarRegistro(Compuesto1)

                    If EliminarRegistroDetalle = 0 Then
                        vMensajeErrorOrm = Compuesto1.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarRegistroDetalle
        End Function
        Private Sub DatosCabecera()
            'Compuesto.TDO_ID = Strings.Trim(txtTDO_ID.Text)
            'Compuesto.DTD_ID = Strings.Trim(txtDTD_ID.Text)
            'Compuesto.DES_SERIE = Strings.Trim(txtDES_SERIE.Text)
            'Compuesto.DES_NUMERO = Strings.Trim(txtDES_NUMERO.Text)
            'Compuesto.DES_FEC_SAL_PLA = Now
        End Sub
        Private Sub DatosGuiaSinDocumento()
            Compuesto.TDO_ID_DOC = Nothing
            Compuesto.DTD_ID_DOC = Nothing
            Compuesto.DES_SERIE_DOC = Nothing
            Compuesto.DES_NUMERO_DOC = Nothing
        End Sub
        Private Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Compuesto.ColocarErrores(dgvDatos, Compuesto.VerificarDatos("DES_FEC_SAL_PLA"), ErrorProvider1)
            End Select
            Return vrO
        End Function
        Private Function ValidarDIR_ID_ENT(ByVal vEstado As Boolean)
            ValidarDIR_ID_ENT = vEstado

            If Trim(txtDIR_ID_ENT.Text) = "" Then
                ErrorProvider1.SetError(txtDIR_ID_ENT, "Ingrese el código de dirección.")
                ErrorProvider1.SetError(tcoDirecciones, "Ingrese el código de dirección.")
                ValidarDIR_ID_ENT = False
            End If
            Return ValidarDIR_ID_ENT
        End Function
        Private Function ValidarZonaFlete(ByVal vEstado As Boolean)
            ValidarZonaFlete = vEstado
            Return ValidarZonaFlete
        End Function
        Private Function ValidarHoraFechaEmision(ByVal vEstado As Boolean)
            ValidarHoraFechaEmision = vEstado
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    If Format(dtpDES_FEC_EMI.Value, "HH") = "00" Then
                        ErrorProvider1.SetError(dtpDES_FEC_EMI, "Ingrese una hora correcta para el cronograma de despacho")
                        ValidarHoraFechaEmision = False
                    End If
                Case Else
            End Select
            Return ValidarHoraFechaEmision
        End Function
        Private Sub InicializarOrm()
            InicializarOrmDetalle()
            'Compuesto = Nothing
            'Compuesto = New Ladisac.BE.Despachos
            Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & _
                                      "' And PVE_ID='" & pPVE_ID & _
                                      "' And DTD_ID='" & pDTD_ID & "'"
        End Sub
        Private Sub InicializarOrmDetalle()
            'Compuesto1 = Nothing
            'Compuesto1 = New Ladisac.BE.DetalleDespachos
        End Sub
        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            Dim vCadenaFiltrado As String = ""
            Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & _
                                      "' And PVE_ID='" & pPVE_ID & _
                                      "' And DTD_ID='" & pDTD_ID & "'"
            Select Case vComportamiento
                Case 0 ' Despachos
                    vCadenaFiltrado = " AND PER_ID='" & txtPER_ID_CLI.Text & "'"
                    EtxtDIR_ID_ENT.pOOrm.CadenaFiltrado = vCadenaFiltrado
                    CadenaFiltradoDTD_ID_DOC()
                    FiltroDTD_ID_DOC()
                    ProcesarLugarLLegada()
                Case 2 ' PuntoVenta
                    txtALM_ID.Text = ""
                    txtALM_DESCRIPCION.Text = ""
                    FiltroPVE_ID()
                    LLamarAlmacenPuntoVenta()
                    If cboSerieCorrelativo.Text = "" Then BuscarSeries()
                Case 4, 14 ' Almacén salida, Almacén de llegada
                    If vComportamiento = 4 Then
                        Select Case pDTD_ID
                            Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                                pBuscarSeleccionaDatosDevolver = True
                                If txtALM_ID.Text <> "" Then LLamarDocumentoCliente()
                                'LLamarVendedor()
                                'If Trim(txtPER_ID_VEN1.Text) = "" Then
                                'pBuscarSeleccionaDatosDevolver = False
                                'Else
                                'pBuscarSeleccionaDatosDevolver = True
                                'End If
                                'pBuscarSeleccionaDatosDevolver = True
                            Case Else
                                LLamarCliente()
                                If Trim(txtPER_ID_CLI.Text) = "" Then
                                    pBuscarSeleccionaDatosDevolver = False
                                Else
                                    pBuscarSeleccionaDatosDevolver = True
                                End If
                        End Select
                    End If

                    EtxtART_ID_KAR.pOOrm.CadenaFiltrado = " And TIP_ID in (select TIP_ID " & _
                                                                         " from vwRolAlmacenTipoArticulos " & _
                                                                         " where ALM_ID in ('" & txtALM_ID.Text & "') and " & _
                                                                               " TIP_ID in (select TIP_ID from vwRolAlmacenTipoArticulos where ALM_ID in ('" & txtALM_ID_LLEGADA.Text & "')))"
                Case 5 ' CtaCte
                    vProcesandoJalarPrimerArticuloDespachar = False
                Case 6 ' Personas - Cliente
                    VerificarDatosCliente()
                    LLamarDocumentoCliente()
                Case 7 ' Documentos - Ventas boletas, Ventas facturas
                    FiltrarDireccionDelCliente()
                    FiltroDTD_ID_DOC()

                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion
                        Case Else
                    End Select

                    ProcesarLugarLLegada()
                Case 10 ' Personas - Recepciona
                Case 16 ' Personas - Vendedor
                    FiltroPER_ID_CLI()
                    LLamarDocumentoCliente()
            End Select
        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtALM_ID" Then EtxtALM_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtALM_ID_LLEGADA" Then EtxtALM_ID_LLEGADA.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_VEN1" Then EtxtPER_ID_VEN1.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI" Then EtxtPER_ID_CLI.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID_DOC" Then EtxtDTD_ID_DOC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtFLE_ID" Then EtxtFLE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_ENT" Then EtxtDIR_ID_ENT.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_REC" Then EtxtPER_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDP_ID_REC" Then EtxtTDP_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_ENT_REC" Then EtxtDIR_ID_ENT_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPLA_ID" Then EtxtPLA_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtUNT_ID" Then EtxtUNT_ID.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtALM_ID" Then EtxtALM_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtALM_ID_LLEGADA" Then EtxtALM_ID_LLEGADA.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID" Then EtxtCCT_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_VEN1" Then EtxtPER_ID_VEN1.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI" Then EtxtPER_ID_CLI.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID_DOC" Then EtxtDTD_ID_DOC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtFLE_ID" Then EtxtFLE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_ENT" Then EtxtDIR_ID_ENT.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_REC" Then EtxtPER_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDP_ID_REC" Then EtxtTDP_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDIR_ID_ENT_REC" Then EtxtDIR_ID_ENT_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPLA_ID" Then EtxtPLA_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtUNT_ID" Then EtxtUNT_ID.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function
        Private Function ProcesarEliminarDetalle() As Int16
            Return EliminarDetalle(Compuesto1)
        End Function
        Private Function EliminarDetalle(ByVal oOrm As DetalleDespachos) As Int16
            Return 1
        End Function
        Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.CheckForIllegalCrossThreadCalls = False
            txtDTD_ID_DOC.BackColor = System.Drawing.Color.White

            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                pBuscarSeleccionaDatosDevolver = True
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

                tcoDirecciones.SelectedIndex = 0
                ConfigurarDatos(tcoDirecciones.SelectedTab.Name)

                ConfigurarFormulario(1)

                If pComportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If

                LlamadaPuntoVenta()
                BotonesEdicion("Solo grabar")

                txtBuscarSerie.Enabled = True

            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load ")
            End Try
        End Sub
        Private Sub AdicionarElementoCombosEdicion()
            BuscarFormatos(EcboDES_ESTADO, Compuesto, cboDES_ESTADO, 0)
            FiltrarSeleccionarValidarElementos(1, True)
        End Sub
        Private Sub NombresFormulariosControles()
            Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & _
                                      "' And PVE_ID='" & pPVE_ID & _
                                      "' And DTD_ID='" & pDTD_ID & "'"

            EtxtPVE_ID.pOOrm = New Ladisac.BE.PuntoVenta
            EtxtPVE_ID.pComportamiento = 2
            EtxtPVE_ID.pOrdenBusqueda = 0
            EtxtPVE_ID.pOOrm.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"
            EtxtPVE_ID.pMostrarDatosGrid = True
            EtxtPVE_ID.pDevolverDatosUnicoRegistro = True
            EtxtPVE_ID.pDatosBuscados = "Agencia"

            EtxtDTD_ID.pOOrm = New Ladisac.BE.DetalleTipoDocumentos
            EtxtDTD_ID.pComportamiento = 3
            EtxtDTD_ID.pOrdenBusqueda = 2
            EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_TABLA='MOVIMIENTOS' And TDO_ID='" & pTDO_ID & "' And DTD_ID='" & pDTD_ID & "'"
            EtxtDTD_ID.pDatosBuscados = "Tipo de documento"

            EtxtALM_ID.pOOrm = New Ladisac.BE.RolPuntoVentaAlmacen
            EtxtALM_ID.pComportamiento = 4
            EtxtALM_ID.pOrdenBusqueda = 18
            EtxtALM_ID.pOOrm.CadenaFiltrado = " And PVE_ID='" & pPVE_ID & "'"
            EtxtALM_ID.pMostrarDatosGrid = True
            EtxtALM_ID.pDevolverDatosUnicoRegistro = True
            EtxtALM_ID.pDatosBuscados = "Almacén de salida"

            EtxtCCT_ID.pOOrm = New Ladisac.BE.CtaCte
            EtxtCCT_ID.pComportamiento = 5
            EtxtCCT_ID.pOrdenBusqueda = 0
            EtxtCCT_ID.pDatosBuscados = "Cuenta corriente"

            EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_CLI.pComportamiento = 6
            EtxtPER_ID_CLI.pOrdenBusqueda = 4
            EtxtPER_ID_CLI.pOOrm.CadenaFiltrado = " And PER_CLIENTE='SI'"
            EtxtPER_ID_CLI.pMostrarDatosGrid = False
            EtxtPER_ID_CLI.pDatosBuscados = "Cliente"

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    EtxtDTD_ID_DOC.pOOrm = New Ladisac.BE.Documentos
                    EtxtDTD_ID_DOC.pComportamiento = 7
                    EtxtDTD_ID_DOC.pOrdenBusqueda = 10
                    EtxtDTD_ID_DOC.pOOrm.Vista = ""
                    EtxtDTD_ID_DOC.pOOrm.pBuscarRegistros = False
                    EtxtDTD_ID_DOC.pOOrm.Vista = "BuscarRegistrosParaDespachosProforma"
                    CadenaFiltradoDTD_ID_DOC()
                    EtxtDTD_ID_DOC.pMostrarDatosGrid = False
                    EtxtDTD_ID_DOC.pDatosBuscados = "Documento a despachar"
                Case Else
                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                            EtxtDTD_ID_DOC.pOOrm = New Ladisac.BE.Documentos
                            EtxtDTD_ID_DOC.pComportamiento = 7
                            EtxtDTD_ID_DOC.pOrdenBusqueda = 10
                            EtxtDTD_ID_DOC.pOOrm.Vista = ""
                            EtxtDTD_ID_DOC.pOOrm.pBuscarRegistros = False
                            EtxtDTD_ID_DOC.pOOrm.Vista = "BuscarRegistrosParaDespachosDesdeDistribuidora"
                            CadenaFiltradoDTD_ID_DOC()
                            EtxtDTD_ID_DOC.pMostrarDatosGrid = False
                            EtxtDTD_ID_DOC.pDatosBuscados = "Documento a despachar desde la distribuidora"
                        Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion
                            EtxtDTD_ID_DOC.pOOrm = New Ladisac.BE.Documentos
                            EtxtDTD_ID_DOC.pComportamiento = 7
                            EtxtDTD_ID_DOC.pOrdenBusqueda = 10
                            EtxtDTD_ID_DOC.pOOrm.Vista = ""
                            EtxtDTD_ID_DOC.pOOrm.pBuscarRegistros = False
                            EtxtDTD_ID_DOC.pOOrm.Vista = "BuscarRegistrosParaDespachosDevoluciones"
                            CadenaFiltradoDTD_ID_DOC()
                            EtxtDTD_ID_DOC.pMostrarDatosGrid = False
                            EtxtDTD_ID_DOC.pDatosBuscados = "Documento a hacer devolución"
                        Case Else
                            EtxtDTD_ID_DOC.pOOrm = New Ladisac.BE.Documentos
                            EtxtDTD_ID_DOC.pComportamiento = 7
                            EtxtDTD_ID_DOC.pOrdenBusqueda = 10
                            EtxtDTD_ID_DOC.pOOrm.Vista = ""
                            EtxtDTD_ID_DOC.pOOrm.pBuscarRegistros = False
                            EtxtDTD_ID_DOC.pOOrm.Vista = "BuscarRegistrosParaDespachos"
                            CadenaFiltradoDTD_ID_DOC()
                            EtxtDTD_ID_DOC.pMostrarDatosGrid = False
                            EtxtDTD_ID_DOC.pDatosBuscados = "Documento a despachar"
                    End Select
            End Select

            EtxtFLE_ID.pOOrm = New Ladisac.BE.DetalleFletesTransporte
            EtxtFLE_ID.pComportamiento = 8
            EtxtFLE_ID.pOrdenBusqueda = 2

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    EtxtFLE_ID.pOOrm.CadenaFiltrado = " And PVE_ID ='" & BCVariablesNames.PuntosVentaPlanta.Principal & "' And FLE_TIPO='" & pFLE_TIPO & "' And MON_ID='" & BCVariablesNames.MonedaSistema & "'"
                    EtxtFLE_ID.pDatosBuscados = "Zona de entrega"
                Case Else
                    EtxtFLE_ID.pOOrm.CadenaFiltrado = " And PVE_ID ='" & pPVE_ID & "' And FLE_TIPO='" & pFLE_TIPO & "' And MON_ID='" & BCVariablesNames.MonedaSistema & "'"
                    EtxtFLE_ID.pDatosBuscados = "Zona de entrega"
            End Select

            EtxtDIR_ID_ENT.pOOrm = New Ladisac.BE.DireccionesPersonas
            EtxtDIR_ID_ENT.pComportamiento = 9
            EtxtDIR_ID_ENT.pOrdenBusqueda = 0
            EtxtDIR_ID_ENT.pDatosBuscados = "Dirección de entrega"

            EtxtPER_ID_REC.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_REC.pComportamiento = 10
            EtxtPER_ID_REC.pOrdenBusqueda = 0
            EtxtPER_ID_REC.pDatosBuscados = "Persona que recepciona el producto"

            EtxtTDP_ID_REC.pOOrm = New Ladisac.BE.DocPersonas
            EtxtTDP_ID_REC.pComportamiento = 11
            EtxtTDP_ID_REC.pOrdenBusqueda = 0
            EtxtTDP_ID_REC.pDatosBuscados = "Documento de la persona que recepciona el producto"

            EtxtDIR_ID_ENT_REC.pOOrm = New Ladisac.BE.DireccionesPersonas
            EtxtDIR_ID_ENT_REC.pComportamiento = 12
            EtxtDIR_ID_ENT_REC.pOrdenBusqueda = 0
            EtxtDIR_ID_ENT.pDatosBuscados = "Dirección de la persona que recepciona el producto"

            EtxtPLA_ID.pOOrm = New Ladisac.BE.Placas
            EtxtPLA_ID.pComportamiento = 13
            EtxtPLA_ID.pOrdenBusqueda = 1
            EtxtPLA_ID.pMostrarDatosGrid = True
            EtxtPLA_ID.pDatosBuscados = "Placas"

            EtxtALM_ID_LLEGADA.pOOrm = New Ladisac.BE.RolPuntoVentaAlmacen
            EtxtALM_ID_LLEGADA.pComportamiento = 14
            EtxtALM_ID_LLEGADA.pOrdenBusqueda = 0
            EtxtALM_ID_LLEGADA.pOOrm.CadenaFiltrado = " And PVE_ID<>'" & pPVE_ID & "'"
            EtxtALM_ID_LLEGADA.pDatosBuscados = "Almacén de llegada"

            EtxtART_ID_KAR.pOOrm = New Ladisac.BE.RolArticulosTipoArticulos
            EtxtART_ID_KAR.pComportamiento = 15
            EtxtART_ID_KAR.pOrdenBusqueda = 0
            EtxtART_ID_KAR.pOOrm.CadenaFiltrado = " And TIP_ID in (select TIP_ID " & _
                                                                  "from vwRolAlmacenTipoArticulos " & _
                                                                  "where ALM_ID in ('" & txtALM_ID.Text & "') and " & _
                                                                        "TIP_ID in (select TIP_ID from vwRolAlmacenTipoArticulos where ALM_ID in ('" & txtALM_ID_LLEGADA.Text & "')))"
            EtxtART_ID_KAR.pDatosBuscados = "Artículos"

            EtxtPER_ID_VEN1.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_VEN1.pComportamiento = 16
            EtxtPER_ID_VEN1.pOrdenBusqueda = 4
            EtxtPER_ID_VEN1.pOOrm.CadenaFiltrado = " And PER_TRABAJADOR='SI'"
            EtxtPER_ID_VEN1.pMostrarDatosGrid = True
            EtxtPER_ID_VEN1.pDatosBuscados = "Vendedor"

            EtxtTDO_ID_CRO.pOOrm = New Ladisac.BE.Despachos
            EtxtTDO_ID_CRO.pComportamiento = 17
            EtxtTDO_ID_CRO.pOrdenBusqueda = 0

            EtxtUNT_ID.pOOrm = New Ladisac.BE.UnidadesTransporte
            EtxtUNT_ID.pComportamiento = 18
            EtxtUNT_ID.pOrdenBusqueda = 0
            EtxtUNT_ID.pMostrarDatosGrid = True
            EtxtUNT_ID.pDatosBuscados = "Unidad de transporte"

        End Sub
        Private Sub CadenaFiltradoDTD_ID_DOC()
            EtxtDTD_ID_DOC.pOOrm.vPER_ID_CLI = txtPER_ID_CLI.Text
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaDespacho, _
                     BCVariablesNames.ProcesosDespacho.GuiaSalida
                    EtxtDTD_ID_DOC.pOOrm.CadenaFiltrado = " And PVE_ID_DES in (select pve_id_ane from vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                      " And DTD_ID in (select DTD_ID from vwDetalleTipoDocumentos where DTD_MOVIMIENTO='VENTA POR DESPACHAR')"
                    '& _
                    '" And PER_ID_CLI='" & txtPER_ID_CLI.Text & "' "
                Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                    EtxtDTD_ID_DOC.pOOrm.CadenaFiltrado = " And PVE_ID_DES in (select pve_id_ane from [Distribuidora].[dbo].vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                     " And DTD_ID in (select DTD_ID from [Distribuidora].[dbo].vwDetalleTipoDocumentos where DTD_MOVIMIENTO='VENTA POR DESPACHAR')"
                    '& _
                    '" And PER_ID_CLI='" & txtPER_ID_CLI.Text & "' "
                Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    EtxtDTD_ID_DOC.pOOrm.CadenaFiltrado = " And PVE_ID_DES in (select pve_id_ane from vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                                          " And DTD_ID in (select DTD_ID from vwDetalleTipoDocumentos where DTD_MOVIMIENTO='VENTA POR DESPACHAR')"
                    '& _
                    '" And PER_ID_VEN='" & txtPER_ID_VEN1.Text & "' "
                Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion
                    EtxtDTD_ID_DOC.pOOrm.CadenaFiltrado = " And PVE_ID_DES in (select pve_id_ane from vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                                          " And (DTD_ID='" & BCVariablesNames.ProcesosFacturación.Boleta & "'" & _
                                                          " Or DTD_ID='" & BCVariablesNames.ProcesosFacturación.Factura & "')"
                    '& _
                    '" And PER_ID_CLI='" & txtPER_ID_CLI.Text & "' "
                Case Else
            End Select
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

            EchkALM_ESTADO = EchkTemporal
            EchkALM_ESTADO_LLEGADA = EchkTemporal
            EchkDES_ESTADO = EchkTemporal
            EchkPER_ESTADO_TRA1 = EchkTemporal
            EchkPER_ESTADO_CHO = EchkTemporal


            EchkALM_ESTADO.pNombreCampo = "ALM_ESTADO"
            EchkALM_ESTADO_LLEGADA.pNombreCampo = "ALM_ESTADO_LLEGADA"
            EchkDES_ESTADO.pNombreCampo = "DES_ESTADO"
            EchkPER_ESTADO_TRA1.pNombreCampo = "PER_ESTADO_TRA1"
            EchkPER_ESTADO_CHO.pNombreCampo = "PER_ESTADO_CHO"

            EchkDES_ESTADO.pValorDefault = CheckState.Checked

            ConfigurarCheck_Refrescar(EchkALM_ESTADO)
            ConfigurarCheck_Refrescar(EchkALM_ESTADO_LLEGADA)
            ConfigurarCheck_Refrescar(EchkDES_ESTADO)
            ConfigurarCheck_Refrescar(EchkPER_ESTADO_TRA1)
            ConfigurarCheck_Refrescar(EchkPER_ESTADO_CHO)
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkALM_ESTADO"
                    Compuesto.CampoId = EchkALM_ESTADO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkALM_ESTADO_LLEGADA"
                    Compuesto.CampoId = EchkALM_ESTADO_LLEGADA.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkDES_ESTADO"
                    Compuesto.CampoId = EchkDES_ESTADO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkPER_ESTADO_TRA1"
                    Compuesto.CampoId = EchkPER_ESTADO_TRA1.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkPER_ESTADO_CHO"
                    Compuesto.CampoId = EchkPER_ESTADO_CHO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Compuesto.DevolverTiposCampos()
        End Function
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkALM_ESTADO"
                    vObjetoChk.pValorDefault = EchkALM_ESTADO.pValorDefault
                Case "chkALM_ESTADO_LLEGADA"
                    vObjetoChk.pValorDefault = EchkALM_ESTADO_LLEGADA.pValorDefault
                Case "chkDES_ESTADO"
                    vObjetoChk.pValorDefault = EchkDES_ESTADO.pValorDefault
                Case "chkPER_ESTADO_TRA1"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO_TRA1.pValorDefault
                Case "chkPER_ESTADO_CHO"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO_CHO.pValorDefault
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
        Handles chkALM_ESTADO.CheckedChanged, _
                chkALM_ESTADO_LLEGADA.CheckedChanged, _
 _
                chkPER_ESTADO_TRA1.CheckedChanged, _
                chkPER_ESTADO_CHO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkALM_ESTADO"
                    If EchkALM_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkALM_ESTADO)
                    End If
                Case "chkALM_ESTADO_LLEGADA"
                    If EchkALM_ESTADO_LLEGADA.pFormatearTexto Then
                        InicializarTextoCheck(EchkALM_ESTADO_LLEGADA)
                    End If
                Case "chkDES_ESTADO"
                    If EchkDES_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkDES_ESTADO)
                    End If
                Case "chkPER_ESTADO_TRA1"
                    If EchkPER_ESTADO_TRA1.pFormatearTexto Then
                        InicializarTextoCheck(EchkPER_ESTADO_TRA1)
                    End If
                Case "chkPER_ESTADO_CHO"
                    If EchkPER_ESTADO_CHO.pFormatearTexto Then
                        InicializarTextoCheck(EchkPER_ESTADO_CHO)
                    End If
            End Select
        End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "ALM_ESTADO"
                    With chkALM_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "ALM_ESTADO_LLEGADA"
                    With chkALM_ESTADO_LLEGADA
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                    'Case "DES_ESTADO"
                    '    With chkDES_ESTADO
                    '        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                    '        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                    '        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    '    End With
                Case "PER_ESTADO_TRA1"
                    With chkPER_ESTADO_TRA1
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_ESTADO_CHO"
                    With chkPER_ESTADO_CHO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTextoCheck(EchkALM_ESTADO)
            InicializarTextoCheck(EchkALM_ESTADO_LLEGADA)
            InicializarTextoCheck(EchkDES_ESTADO)
            InicializarTextoCheck(EchkPER_ESTADO_TRA1)
            InicializarTextoCheck(EchkPER_ESTADO_CHO)
        End Sub
#End Region

#Region "DataGridView"
        'Private Sub dgvDatos_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        '    Handles dgvDatos.RowEnter
        '    'If EdgvDetalle.pBloquearPk Then
        'End Sub

        Private Sub ConfigurarDataGridView()
            EdgvDetalle.pAnchoColumna = 20
            EdgvDetalle.pBloquearPk = True
            EdgvDetalle.pColorColumna = Drawing.Color.Black
            EdgvDetalle.pCampoEstadoRegistro = "cEstadoRegistro"
            EdgvDetalle.pMetodoColumnas = False
            ReDim EdgvDetalle.pArrayCamposPkDetalle(1)
            EdgvDetalle.pArrayCamposPkDetalle(1) = "cART_ID_KAR"

            dgvDetalle.AllowUserToAddRows = False
            dgvDetalle.AllowUserToDeleteRows = False
            dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End Sub
        Private Sub ConfigurarGrid(ByVal vProceso As String)
            Select Case vProceso
                Case "Load"
                    eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
                    eConfigurarDataGridObjeto.Orm = Nothing
                    eConfigurarDataGridObjeto.Array = {1}
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
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                    Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                        Case "cART_ID_KAR"
                            Select Case e.KeyCode
                                Case Keys.F1
                                    If EtxtART_ID_KAR.pBusqueda Then
                                        EtxtART_ID_KAR.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                                        MetodoBusquedaDato("", False, EtxtART_ID_KAR)
                                        EtxtART_ID_KAR.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                                        EtxtART_ID_KAR.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                                    End If
                            End Select
                    End Select
                Case Else
            End Select
        End Sub
        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDetalle.CellDoubleClick
            If dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name = "cART_ID_KAR" Then
                If EtxtART_ID_KAR.pFormularioConsulta Then
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
            If EdgvDetalle.pBloquearPk Then
                Dim vCampoPk As String = ""
                For elemento As Integer = 1 To EdgvDetalle.pArrayCamposPkDetalle.GetUpperBound(0)
                    vCampoPk = EdgvDetalle.pArrayCamposPkDetalle(elemento).ToString
                    If dgvDetalle.Rows(e.RowIndex).Cells(EdgvDetalle.pCampoEstadoRegistro).Value Is Nothing Then
                    Else
                        If dgvDetalle.Rows(e.RowIndex).Cells(EdgvDetalle.pCampoEstadoRegistro).Value.ToString <> "1" Then
                            ControlReadOnly(dgvDetalle.Columns(vCampoPk), False)
                            EtxtART_ID_KAR.pBusqueda = True
                        Else
                            ControlReadOnly(dgvDetalle.Columns(vCampoPk), True)
                            EtxtART_ID_KAR.pBusqueda = False
                        End If
                    End If
                Next elemento
            End If
        End Sub
        Private Sub dgvDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvDetalle.CellEnter
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID_KAR"
                    EtxtART_ID_KAR.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
            End Select
        End Sub
        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvDetalle.CellValidated
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID_KAR"
                    EtxtART_ID_KAR.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    ValidarDatos(EtxtART_ID_KAR, dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value, True, sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtART_ID_KAR.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    EtxtART_ID_KAR.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
            End Select
        End Sub
        Private Sub ValidarDatos(ByRef otxt As txt, ByVal texto As String, ByVal BusquedaDirecta As Boolean, Optional ByVal NameCampo As String = "")
            If otxt.pTexto1 <> otxt.pTexto2 Then
                If otxt.pBusqueda Then
                    MetodoBusquedaDato(texto, BusquedaDirecta, otxt)
                End If
                Select Case NameCampo
                    Case ""
                        KeysTab(1)
                End Select
            End If
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
            EtxtTemporal.pMostrarDatosGrid = False
            EtxtTemporal.pDevolverDatosUnicoRegistro = False

            EtxtPVE_ID = EtxtTemporal
            EtxtDTD_ID = EtxtTemporal
            EtxtDES_SERIE = EtxtTemporal
            EtxtDES_NUMERO = EtxtTemporal

            EtxtALM_ID = EtxtTemporal
            EtxtALM_ID_LLEGADA = EtxtTemporal

            EtxtCCT_ID = EtxtTemporal

            EtxtPER_ID_VEN1 = EtxtTemporal
            EtxtPER_ID_CLI = EtxtTemporal
            EtxtDTD_ID_DOC = EtxtTemporal

            EtxtFLE_ID = EtxtTemporal

            EtxtDIR_ID_ENT = EtxtTemporal

            EtxtPER_ID_REC = EtxtTemporal
            EtxtTDP_ID_REC = EtxtTemporal
            EtxtDIR_ID_ENT_REC = EtxtTemporal

            EtxtPLA_ID = EtxtTemporal

            EtxtUNT_ID = EtxtTemporal

            EtxtTDO_ID_CRO = EtxtTemporal

            EtxtPVE_ID.pBusqueda = True
            EtxtPVE_ID.pFormularioConsulta = True

            EtxtDTD_ID.pBusqueda = True
            EtxtDTD_ID.pFormularioConsulta = True

            EtxtALM_ID.pBusqueda = True
            EtxtALM_ID.pFormularioConsulta = True

            EtxtALM_ID_LLEGADA.pBusqueda = True
            EtxtALM_ID_LLEGADA.pFormularioConsulta = True

            EtxtCCT_ID.pBusqueda = True
            EtxtCCT_ID.pFormularioConsulta = False

            EtxtPER_ID_VEN1.pBusqueda = True
            EtxtPER_ID_VEN1.pFormularioConsulta = True

            EtxtPER_ID_CLI.pBusqueda = True
            EtxtPER_ID_CLI.pFormularioConsulta = True

            EtxtDTD_ID_DOC.pBusqueda = True
            EtxtDTD_ID_DOC.pFormularioConsulta = True

            EtxtFLE_ID.pBusqueda = True
            EtxtFLE_ID.pFormularioConsulta = True

            EtxtDIR_ID_ENT.pBusqueda = True
            EtxtDIR_ID_ENT.pFormularioConsulta = True

            EtxtPER_ID_REC.pBusqueda = True
            EtxtPER_ID_REC.pFormularioConsulta = True

            EtxtTDP_ID_REC.pBusqueda = True
            EtxtTDP_ID_REC.pFormularioConsulta = True

            EtxtDIR_ID_ENT_REC.pBusqueda = True
            EtxtDIR_ID_ENT_REC.pFormularioConsulta = True

            EtxtPLA_ID.pBusqueda = True
            EtxtPLA_ID.pFormularioConsulta = True

            EtxtUNT_ID.pBusqueda = True
            EtxtUNT_ID.pFormularioConsulta = True

            EtxtART_ID_KAR.pBusqueda = True
            EtxtART_ID_KAR.pFormularioConsulta = False

            EtxtTDO_ID_CRO.pBusqueda = True
            EtxtTDO_ID_CRO.pFormularioConsulta = False
        End Sub
        Private Sub MascaraCamposText(ByRef oTexto As TextBox)
            Select Case oTexto.Name
                Case "txtDES_NUMERO"
                    If Not IsNumeric(oTexto.Text) Then
                        oTexto.Text = ""
                    Else
                        If Strings.InStr(txtDES_NUMERO.Text, ".") = 0 Then
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
                    LlamadasPVE_ID()
                    BuscarSeries()
                Case "txtPER_ID_CLI"
                    If pBusquedaDevolvioDatos Then
                        LlamadasPER_ID_CLI()
                    End If
            End Select
        End Sub
        Private Sub LlamadasPVE_ID()
            If Trim(txtPVE_ID.Text) <> "" Then
                txtTDO_ID.Text = pTDO_ID
                txtDTD_ID.Text = pDTD_ID

                If txtDTD_ID.Text = "" Then MetodoBusquedaDato(txtDTD_ID.Text, True, EtxtDTD_ID)
                If txtALM_ID.Text = "" Then MetodoBusquedaDato("%", True, EtxtALM_ID)

                Select Case pDTD_ID
                    Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                        pBuscarSeleccionaDatosDevolver = True
                        If txtALM_ID.Text <> "" Then LLamarDocumentoCliente()
                    Case Else
                        If txtPER_ID_CLI.Text = "" Then
                            LLamarCliente()
                        End If
                        If Trim(txtPER_ID_CLI.Text) = "" Then
                            pBuscarSeleccionaDatosDevolver = False
                        Else
                            pBuscarSeleccionaDatosDevolver = True
                            If txtALM_ID.Text <> "" Then LLamarDocumentoCliente()
                        End If
                End Select
            End If
        End Sub
#End Region

#End Region
#Region "Secundaria 2"
        Private Sub FormatearCampos()
            FormatearCampos(txtPVE_ID, "PVE_ID", EtxtPVE_ID)
            FormatearCampos(txtDTD_ID, "DTD_ID", EtxtDTD_ID)
            FormatearCampos(txtDES_SERIE, "DES_SERIE", EtxtDES_SERIE)
            FormatearCampos(txtDES_NUMERO, "DES_NUMERO", EtxtDES_NUMERO, False)
            FormatearCampos(txtALM_ID, "ALM_ID", EtxtALM_ID, False)
            FormatearCampos(txtALM_ID_LLEGADA, "ALM_ID", EtxtALM_ID_LLEGADA, False)
            FormatearCampos(txtCCT_ID, "CCT_ID", EtxtCCT_ID, False)

            FormatearCampos(txtPER_ID_CLI, "PER_ID_CLI", EtxtPER_ID_CLI, False)
            FormatearCampos(txtDTD_ID_DOC, "DTD_ID_DOC", EtxtDTD_ID_DOC)

            FormatearCampos(txtDIR_ID_ENT, "DIR_ID_ENT", EtxtDIR_ID_ENT, False)
            FormatearCampos(txtPLA_ID, "PLA_ID", EtxtPLA_ID, False)
            FormatearCampos(txtUNT_ID, "UNT_ID", EtxtUNT_ID, False)
            FormatearCampos(cboDES_ESTADO, "DES_ESTADO", Nothing)
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object, _
                                   ByVal NombreCampo As String, _
                                   ByRef sender As txt, _
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
            Exit Function
            BloquearBusquedaCampos = False
            Select Case vtxt.pOOrm.cTabla.NombreCorto
                Case "DetalleFletesTransporte", "DocPersonas", "Placas", "RolArticulosTipoArticulos"
                Case "PuntoVenta"
                    If txtDTD_ID_DOC.Text.Trim <> "" Then
                        BloquearBusquedaCampos = True
                        If vMensaje Then MsgBox("¡ No se puede cambiar !" & Chr(13) & "si ya escogio un documento a procesar", MsgBoxStyle.Information, Me.Text)
                    End If
                Case "Personas", "DireccionesPersonas"
                    If vtxt.pComportamiento <> 9 And
                       vtxt.pComportamiento <> 10 And
                       vtxt.pComportamiento <> 12 Then
                        If dgvDetalle.RowCount > 0 Then
                            BloquearBusquedaCampos = True
                            If vMensaje Then MsgBox("¡ No se puede cambiar !" & Chr(13) & "si la grilla posee registros", MsgBoxStyle.Information, Me.Text)
                            Exit Select
                        End If
                        If txtDTD_ID_DOC.Text.Trim <> "" Then
                            BloquearBusquedaCampos = True
                            If vMensaje Then MsgBox("¡ No se puede cambiar !" & Chr(13) & "si ya escogio un documento a procesar", MsgBoxStyle.Information, Me.Text)
                        End If
                    End If
                Case Else
                    If dgvDetalle.RowCount > 0 Then
                        BloquearBusquedaCampos = True
                        If vMensaje Then MsgBox("¡ No se puede cambiar !" & Chr(13) & "si la grilla posee registros", MsgBoxStyle.Information, Me.Text)
                    End If
            End Select
            Return BloquearBusquedaCampos
        End Function
        Private Function MensajeOperaciones(ByVal vRespuesta As Int16, _
                                            ByVal vOperacion As String) As Int16
            MensajeOperaciones = vRespuesta
            Select Case vRespuesta
                Case 0
                    MsgBox("Registro " & vOperacion, MsgBoxStyle.Information, Me.Text)
                Case 1
                    Me.Cursor = Cursors.Default
                Case 2
                    MsgBox("Registro no fue " & vOperacion & "verifique sus datos" & _
                           Chr(13) & Chr(13) & Compuesto.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto1.vMensajeError, _
                           MsgBoxStyle.Information, Me.Text)
            End Select
            Return MensajeOperaciones
        End Function
        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 4 ' RolPuntoVentaAlmacen
                    OrdenBusquedaDirecta = 0
                Case 6, 16 ' Personas
                    OrdenBusquedaDirecta = 0
                Case 7 ' DetalleTipoDocumento
                    OrdenBusquedaDirecta = 0
                Case 8 ' DetalleFleteTransporte
                    OrdenBusquedaDirecta = 1
                Case 13 ' Placas
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function
#Region "ComboBox"
        Private Sub ConfigurarComboBox()
            Dim Ecbo As New cbo
            Ecbo.pEnabled = True
            Ecbo.pStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboDES_ESTADO = Ecbo

            EcboDES_ESTADO.pNombreCampo = "DES_ESTADO"
            cboDES_ESTADO.DropDownStyle = Ecbo.pStyle
        End Sub
#End Region

#Region "TextBox"

        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.GotFocus, _
            txtDTD_ID.GotFocus, _
            txtALM_ID.GotFocus, _
            txtALM_ID_LLEGADA.GotFocus, _
            txtCCT_ID.GotFocus, _
            txtPER_ID_CLI.GotFocus, _
            txtDTD_ID_DOC.GotFocus, _
            txtDIR_ID_ENT.GotFocus, _
            txtPLA_ID.GotFocus, _
            txtUNT_ID.GotFocus

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto1 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto1 = sender.text
                Case "txtALM_ID"
                    EtxtALM_ID.pTexto1 = sender.text
                Case "txtALM_ID_LLEGADA"
                    EtxtALM_ID_LLEGADA.pTexto1 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto1 = sender.text
                Case "txtPER_ID_VEN1"
                    EtxtPER_ID_VEN1.pTexto1 = sender.text
                Case "txtPER_ID_CLI"
                    EtxtPER_ID_CLI.pTexto1 = sender.text
                Case "txtDTD_ID_DOC"
                    EtxtDTD_ID_DOC.pTexto1 = sender.text
                Case "txtFLE_ID"
                    EtxtFLE_ID.pTexto1 = sender.text
                Case "txtDIR_ID_ENT"
                    EtxtDIR_ID_ENT.pTexto1 = sender.text
                Case "txtPER_ID_REC"
                    EtxtPER_ID_REC.pTexto1 = sender.text
                Case "txtTDP_ID_REC"
                    EtxtTDP_ID_REC.pTexto1 = sender.text
                Case "txtDIR_ID_ENT_REC"
                    EtxtDIR_ID_ENT_REC.pTexto1 = sender.text
                Case "txtPLA_ID"
                    EtxtPLA_ID.pTexto1 = sender.text
                Case "txtUNT_ID"
                    EtxtUNT_ID.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.LostFocus, _
                txtDTD_ID.LostFocus, _
                txtALM_ID.LostFocus, _
                txtALM_ID_LLEGADA.LostFocus, _
                txtCCT_ID.LostFocus, _
                txtPER_ID_CLI.LostFocus, _
                txtDTD_ID_DOC.LostFocus, _
                txtDIR_ID_ENT.LostFocus, _
                txtPLA_ID.LostFocus, _
                txtUNT_ID.LostFocus
            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto2 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto2 = sender.text
                Case "txtALM_ID"
                    EtxtALM_ID.pTexto2 = sender.text
                Case "txtALM_ID_LLEGADA"
                    EtxtALM_ID_LLEGADA.pTexto2 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto2 = sender.text
                Case "txtPER_ID_VEN1"
                    EtxtPER_ID_VEN1.pTexto2 = sender.text
                Case "txtPER_ID_CLI"
                    EtxtPER_ID_CLI.pTexto2 = sender.text
                Case "txtDTD_ID_DOC"
                    EtxtDTD_ID_DOC.pTexto2 = sender.text
                Case "txtFLE_ID"
                    EtxtFLE_ID.pTexto2 = sender.text
                Case "txtDIR_ID_ENT"
                    EtxtDIR_ID_ENT.pTexto2 = sender.text
                Case "txtPER_ID_REC"
                    EtxtPER_ID_REC.pTexto2 = sender.text
                Case "txtTDP_ID_REC"
                    EtxtTDP_ID_REC.pTexto2 = sender.text
                Case "txtDIR_ID_ENT_REC"
                    EtxtDIR_ID_ENT_REC.pTexto2 = sender.text
                Case "txtPLA_ID"
                    EtxtPLA_ID.pTexto2 = sender.text
                Case "txtUNT_ID"
                    EtxtUNT_ID.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.Validated, _
                txtDTD_ID.Validated, _
                txtDES_NUMERO.Validated, _
                txtALM_ID.Validated, _
                txtALM_ID_LLEGADA.Validated, _
                txtCCT_ID.Validated, _
                txtPER_ID_CLI.Validated, _
                txtDTD_ID_DOC.Validated, _
                txtDIR_ID_ENT.Validated, _
                txtPLA_ID.Validated, _
                txtUNT_ID.Validated

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    ValidarDatos(EtxtPVE_ID, txtPVE_ID)
                Case "txtDTD_ID"
                    ValidarDatos(EtxtDTD_ID, txtDTD_ID)
                Case "txtDES_NUMERO"
                    ValidarDatos(EtxtDES_NUMERO, txtDES_NUMERO)
                    MascaraCamposText(txtDES_NUMERO)
                Case "txtALM_ID"
                    ValidarDatos(EtxtALM_ID, txtALM_ID, txtPVE_ID.Text & txtALM_ID.Text)
                Case "txtALM_ID_LLEGADA"
                    ValidarDatos(EtxtALM_ID_LLEGADA, txtALM_ID_LLEGADA, txtPVE_ID.Text & txtALM_ID_LLEGADA.Text)
                Case "txtCCT_ID"
                    ValidarDatos(EtxtCCT_ID, txtCCT_ID, txtCCT_ID.Text)
                Case "txtPER_ID_CLI"
                    txtPER_ID_CLI.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_CLI.Text, txtPER_ID_CLI.MaxLength)
                    ValidarDatos(EtxtPER_ID_CLI, txtPER_ID_CLI)
                Case "txtDTD_ID_DOC"
                    ValidarDatos(EtxtDTD_ID_DOC, txtDTD_ID_DOC)
                Case "txtDIR_ID_ENT"
                    ValidarDatos(EtxtDIR_ID_ENT, txtDIR_ID_ENT)
                Case "txtPLA_ID"
                    ValidarDatos(EtxtPLA_ID, txtPLA_ID)
                Case "txtUNT_ID"
                    ValidarDatos(EtxtUNT_ID, txtUNT_ID)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtPVE_ID.KeyPress, _
                txtDTD_ID.KeyPress, _
                txtDES_NUMERO.KeyPress, _
                txtALM_ID.KeyPress, _
                txtALM_ID_LLEGADA.KeyPress, _
                txtCCT_ID.KeyPress, _
                txtPER_ID_CLI.KeyPress, _
                txtDTD_ID_DOC.KeyPress, _
                txtDIR_ID_ENT.KeyPress, _
                txtPLA_ID.KeyPress, _
                txtUNT_ID.KeyPress

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    If BloquearBusquedaCampos(EtxtPVE_ID) Then
                        e.KeyChar = ""
                        Exit Sub
                    End If
                    oKeyPress(EtxtPVE_ID, e)
                Case "txtDTD_ID"
                    oKeyPress(EtxtDTD_ID, e)
                Case "txtDES_NUMERO"
                    oKeyPress(EtxtDES_NUMERO, e)
                Case "txtALM_ID"
                    oKeyPress(EtxtALM_ID, e)
                Case "txtALM_ID_LLEGADA"
                    oKeyPress(EtxtALM_ID_LLEGADA, e)
                Case "txtCCT_ID"
                    oKeyPress(EtxtCCT_ID, e)
                Case "txtPER_ID_VEN1"
                    oKeyPress(EtxtPER_ID_VEN1, e)
                Case "txtPER_ID_CLI"
                    oKeyPress(EtxtPER_ID_CLI, e)
                Case "txtDTD_ID_DOC"
                    oKeyPress(EtxtDTD_ID_DOC, e)
                Case "txtFLE_ID"
                    oKeyPress(EtxtFLE_ID, e)
                Case "txtDIR_ID_ENT"
                    oKeyPress(EtxtDIR_ID_ENT, e)
                Case "txtPER_ID_REC"
                    oKeyPress(EtxtPER_ID_REC, e)
                Case "txtTDP_ID_REC"
                    oKeyPress(EtxtTDP_ID_REC, e)
                Case "txtDIR_ID_ENT_REC"
                    oKeyPress(EtxtDIR_ID_ENT_REC, e)
                Case "txtPLA_ID"
                    oKeyPress(EtxtPLA_ID, e)
                Case "txtUNT_ID"
                    oKeyPress(EtxtUNT_ID, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.DoubleClick, _
                txtDTD_ID.DoubleClick, _
                txtALM_ID.DoubleClick, _
                txtCCT_ID.DoubleClick, _
                txtPER_ID_CLI.DoubleClick, _
                txtDTD_ID_DOC.DoubleClick, _
                txtDIR_ID_ENT.DoubleClick, _
                txtPLA_ID.DoubleClick, _
                txtUNT_ID.DoubleClick

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    oDoubleClick(EtxtPVE_ID, txtPVE_ID, "frmPuntoVenta")
                Case "txtDTD_ID"
                    oDoubleClick(EtxtDTD_ID, txtDTD_ID, "frmTipoDocumento")
                Case "txtPER_ID_CLI"
                    oDoubleClick(EtxtPER_ID_CLI, txtPER_ID_CLI, "frmPersonas_CLI")
                Case "txtDTD_ID_DOC"
                    oDoubleClick(EtxtDTD_ID_DOC, txtDTD_ID_DOC, "frmTipoDocumento_DOC")
                Case "txtDIR_ID_ENT"
                    oDoubleClick(EtxtDIR_ID_ENT, txtDIR_ID_ENT, "frmDireccionesPersonas")
                Case "txtPLA_ID"
                    oDoubleClick(EtxtPLA_ID, txtPLA_ID, "frmPlacas")
                Case "txtUNT_ID"
                    oDoubleClick(EtxtUNT_ID, txtUNT_ID, "frmUnidadesTransporte")
                    'ojitoojito
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
        Handles txtPVE_ID.KeyDown, _
                txtDTD_ID.KeyDown, _
                txtALM_ID.KeyDown, _
                txtALM_ID_LLEGADA.KeyDown, _
                txtCCT_ID.KeyDown, _
                txtPER_ID_CLI.KeyDown, _
                txtDTD_ID_DOC.KeyDown, _
                txtDIR_ID_ENT.KeyDown, _
                txtPLA_ID.KeyDown, _
                txtUNT_ID.KeyDown

            Select Case e.KeyCode
                Case Keys.F2
                    Select Case sender.name.ToString
                        Case "txtDIR_ID_ENT"
                            CuadroTexto = txtDIR_ID_ENT
                            If txtDIR_ID_ENT.Text <> "" And txtDIR_DESCRIPCION_ENT.Text <> "" Then
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion1, False, EtxtDIR_ID_ENT, txtDIR_ID_ENT.Text)
                            Else
                                DireccionesCrearModificar(BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion1, True, EtxtDIR_ID_ENT)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtDIR_ID_ENT.Text, True, EtxtDIR_ID_ENT)
                        Case "txtPLA_ID"
                            CuadroTexto = txtPLA_ID
                            If txtPLA_ID.Text <> "" Then
                                PlacaCrearModificar(False, EtxtPLA_ID, txtPLA_ID.Text)
                            Else
                                PlacaCrearModificar(True, EtxtPLA_ID)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtPLA_ID.Text, True, EtxtPLA_ID)
                    End Select
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtPVE_ID"
                            TeclaF1(EtxtPVE_ID, txtPVE_ID)
                        Case "txtDTD_ID"
                            TeclaF1(EtxtDTD_ID, txtDTD_ID)
                        Case "txtALM_ID"
                            TeclaF1(EtxtALM_ID, txtALM_ID)
                        Case "txtALM_ID_LLEGADA"
                            TeclaF1(EtxtALM_ID_LLEGADA, txtALM_ID_LLEGADA)
                        Case "txtPER_ID_CLI"
                            pBusquedaDevolvioDatos = False
                            TeclaF1(EtxtPER_ID_CLI, txtPER_ID_CLI)
                        Case "txtDTD_ID_DOC"
                            TeclaF1(EtxtDTD_ID_DOC, txtDTD_ID_DOC, 999999)
                        Case "txtDIR_ID_ENT"
                            TeclaF1(EtxtDIR_ID_ENT, txtDIR_ID_ENT)
                        Case "txtPLA_ID"
                            TeclaF1(EtxtPLA_ID, txtPLA_ID)
                        Case "txtUNT_ID"
                            TeclaF1(EtxtUNT_ID, txtUNT_ID)
                    End Select
            End Select
        End Sub

#End Region

#End Region

        Private Sub ControlReadOnly(ByRef vObjeto As Object, ByVal vboolean As Boolean)
            vObjeto.ReadOnly = vboolean
        End Sub

        Private Sub VerificarDatosCliente()
            FiltroPER_ID_CLI()
            FiltrarDireccionDelCliente()
        End Sub
        Private Sub FiltrarDireccionDelCliente()
            Dim vCadenaFiltrado As String = ""
            vCadenaFiltrado = " AND PER_ID='" & txtPER_ID_CLI.Text & "'"
            EtxtDIR_ID_ENT.pOOrm.CadenaFiltrado = vCadenaFiltrado
        End Sub

        Private Sub FiltroPER_ID_CLI()
            CadenaFiltradoDTD_ID_DOC()
        End Sub


        Private Sub LlamadaProcesarFechaServidor()
            thLlamadaProcesarFechaServidor = New Threading.Thread(AddressOf ProcesarFechaServidor)
            If thLlamadaProcesarFechaServidor.ThreadState <> Threading.ThreadState.Running Then
                thLlamadaProcesarFechaServidor.Start()
            End If
        End Sub
        Public Sub ProcesarFechaServidor()
            dtpDES_FEC_EMI.Text = IBCMaestro.EjecutarVista("spFechaServidor")
            tslFechaServidor.Text = "Fecha de trabajo: " & dtpDES_FEC_EMI.Text
            thLlamadaProcesarFechaServidor.Abort()
        End Sub

        Private Sub ProcesarSerie()
            If cboSerieCorrelativo.DataSource Is Nothing Then Exit Sub
            txtDES_SERIE.Text = cboSerieCorrelativo.Text
            txtDES_NUMERO.Text = cboSerieCorrelativo.SelectedValue.ToString
            If txtDES_NUMERO.Text = "0" Then
                Compuesto2.CTD_USAR_COR = 0
                ConfigurarReadOnlyNoBusqueda(txtDES_NUMERO, EtxtDES_NUMERO, False)
            Else
                Compuesto2.CTD_USAR_COR = 1
                ConfigurarReadOnlyNoBusqueda(txtDES_NUMERO, EtxtDES_NUMERO, True)
            End If
        End Sub
        Private Sub BuscarSeries()
            Compuesto11.Vista = "BuscarCorrelativos"
            Dim NombreProcedimiento As String = Compuesto11.SentenciaSqlBusqueda()

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
                txtDES_NUMERO.Text = ""
            End If
        End Sub

        Private Sub ConfigurarDatos(ByVal vNombreTabPage As String)
            Select Case vNombreTabPage
                Case "tpaEntrega"
                    HabilitarDatos("Entrega", True)
                    HabilitarDatos("Recepciona", False)
                    HabilitarDatos("Documento", False)
                    HabilitarDatos("Saldo", False)
                    SubHabilitarDatos(True)
                Case "tpaRecepciona"
                    HabilitarDatos("Entrega", False)
                    HabilitarDatos("Recepciona", True)
                    HabilitarDatos("Documento", False)
                    HabilitarDatos("Saldo", False)
                    SubHabilitarDatos(True)
                Case "tpaDocumento"
                    HabilitarDatos("Entrega", False)
                    HabilitarDatos("Recepciona", False)
                    HabilitarDatos("Documento", True)
                    HabilitarDatos("Saldo", False)
                    SubHabilitarDatos(False)
                Case "tpaSaldo"
                    HabilitarDatos("Entrega", False)
                    HabilitarDatos("Recepciona", False)
                    HabilitarDatos("Documento", False)
                    HabilitarDatos("Saldo", True)
                    SubHabilitarDatos(False)
            End Select
        End Sub
        Private Sub HabilitarDatos(ByVal vTipoGestor As String, ByVal vBoolean As Boolean)
            Select Case vTipoGestor
                Case "Entrega"
                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                            vBoolean = False
                        Case Else
                    End Select
                    txtDIR_ID_ENT.Visible = vBoolean
                    txtDIR_DESCRIPCION_ENT.Visible = vBoolean
                    txtDIR_REFERENCIA_ENT.Visible = vBoolean
                    txtDIS_ID_ENT.Visible = vBoolean
                    txtDIS_DESCRIPCION_ENT.Visible = vBoolean
                    txtPRO_ID_ENT.Visible = vBoolean
                    txtPRO_DESCRIPCION_ENT.Visible = vBoolean
                    txtDEP_ID_ENT.Visible = vBoolean
                    txtDEP_DESCRIPCION_ENT.Visible = vBoolean
                    txtPAI_ID_ENT.Visible = vBoolean
                    txtPAI_DESCRIPCION_ENT.Visible = vBoolean
                Case "Recepciona"
                Case "Documento"
                Case "Saldo"
            End Select
        End Sub
        Private Sub SubHabilitarDatos(ByVal vBoolean As Boolean)
            lblPLA_ID.Visible = vBoolean
            txtPLA_ID.Visible = vBoolean
            txtUNT_ID_1.Visible = vBoolean
            txtUNT_ID_2.Visible = vBoolean
            lblCERTIFICADO.Visible = vBoolean
            txtCertificado.Visible = vBoolean

            lblPER_ID_TRA1.Visible = vBoolean
            txtPER_ID_TRA1.Visible = vBoolean
            txtPER_DESCRIPCION_TRA1.Visible = vBoolean

            lblRUC_TRA1.Visible = vBoolean
            txtRUC_TRA1.Visible = vBoolean
            chkPER_ESTADO_TRA1.Visible = vBoolean

            lblPER_ID_CHO.Visible = vBoolean
            txtPER_ID_CHO.Visible = vBoolean
            txtPER_DESCRIPCION_CHO.Visible = vBoolean

            lblPER_BREVETE_CHO.Visible = vBoolean
            txtPER_BREVETE_CHO.Visible = vBoolean
            chkPER_ESTADO_CHO.Visible = vBoolean
        End Sub

        Private Sub tcoDirecciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcoDirecciones.SelectedIndexChanged
            ConfigurarDatos(tcoDirecciones.SelectedTab.Name)
        End Sub

        Private Sub cboSerieCorrelativo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerieCorrelativo.TextChanged
            ProcesarSerie()
        End Sub
        Private Sub cboSerieCorrelativo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerieCorrelativo.Validated
            ProcesarSerie()
        End Sub

        Private Sub ControlVisible(ByRef vObjeto As Object, ByVal vboolean As Boolean)
            vObjeto.Visible = vboolean
        End Sub

        Private Sub LlamadasPER_ID_CLI()
            'VerificarDireccionesCliente()
        End Sub
        Private Sub VerificarDireccionesCliente()
            MetodoBusquedaDato(Me.IBCBusqueda.CodigoDireccionPersona(txtPER_ID_CLI.Text, pEntrega), True, EtxtDIR_ID_ENT)
        End Sub

        Private Sub dgvDetalle_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDetalle.RowHeaderMouseDoubleClick
            EliminarFilasGrid()
        End Sub

        Private Sub FiltroDTD_ID_DOC()
        End Sub
        Private Sub FiltroPVE_ID()
            EtxtALM_ID.pOOrm.CadenaFiltrado = " And PVE_ID='" & pPVE_ID & "'"
            EtxtALM_ID_LLEGADA.pOOrm.CadenaFiltrado = " And PVE_ID<>'" & pPVE_ID & "'"
            CadenaFiltradoDTD_ID_DOC()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    EtxtFLE_ID.pOOrm.CadenaFiltrado = " And PVE_ID ='" & BCVariablesNames.PuntosVentaPlanta.Principal & "' And FLE_TIPO='" & pFLE_TIPO & "' And MON_ID='" & BCVariablesNames.MonedaSistema & "'"
                    EtxtFLE_ID.pDatosBuscados = "Zona de entrega"
                Case Else
                    EtxtFLE_ID.pOOrm.CadenaFiltrado = " And PVE_ID ='" & pPVE_ID & "' And FLE_TIPO='" & pFLE_TIPO & "' And MON_ID='" & BCVariablesNames.MonedaSistema & "'"
                    EtxtFLE_ID.pDatosBuscados = "Zona de entrega"
            End Select
        End Sub

        Private Sub txt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtPVE_ID.Enter
            If sender.Name.ToString = "txtPVE_ID" Then

            End If
            If sender.GetType <> GetType(ComboBox) And _
                sender.GetType <> GetType(DateTimePicker) Then
                If sender.ReadOnly Then SendKeys.Send(Chr(Keys.Tab))
            Else
                If EnabledComboBox(sender.name) Then SendKeys.Send(Chr(Keys.Tab))
            End If
        End Sub
        Private Function EnabledComboBox(ByVal vName As String) As Boolean
            EnabledComboBox = True
            Select Case vName
                Case "cboDOC_TIPO_LISTA"
                    'EnabledComboBox = Not EcboDOC_TIPO_LISTA.pEnabled
            End Select
        End Function

        Private Sub PlacaCrearModificar(ByVal vFlagCrear As Boolean, ByVal vtxt As txt, Optional ByVal vBusqueda As String = "")
            If BloquearBusquedaCampos(vtxt) Then Exit Sub

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPlacas)()
            frm.NombreFormulario = Me

            frm.LlamadaDesdeFormularioCrear = vFlagCrear
            frm.LlamadaDesdeFormularioModificar = Not vFlagCrear

            If vFlagCrear Then
                frm.LLamadaDesdeFormularioDatos.pPer_Id_Tra = txtPER_ID_TRA1.Text
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

        Private Sub MostrarVendedor(Optional ByVal vflag As Boolean = False)
            'Exit Sub
            txtDEP_ID_ALM.Visible = Not vflag
            txtDEP_DESCRIPCION_ALM.Visible = Not vflag
            txtPAI_ID_ALM.Visible = Not vflag
            txtPAI_DESCRIPCION_ALM.Visible = Not vflag

            txtPER_ID_CLI.Enabled = Not vflag
            txtPER_ID_CLI.ReadOnly = vflag
        End Sub

        Private Sub btnProcesarCronogramaDespacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarCronogramaDespacho.Click
            If Not pRegistroNuevo Then Exit Sub
            vProcesandoCronogramaDespacho = True
            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosDespacho.GuiaDespacho
                    EtxtTDO_ID_CRO.pOOrm.pBuscarRegistros = True
                    EtxtTDO_ID_CRO.pOOrm.CadenaFiltrado = " And TDO_ID In ('" & BCVariablesNames.ProcesosDespacho.CronogramaDespacho & "')" & _
                                                          " And PVE_ID in (select pve_id_ane from vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                                          " And cast(DES_FEC_EMI as Date) = cast('" & cMisProcedimientos.FormatoFechaGenerico(dtpDES_FEC_EMI.Value) & "' as Date) " & _
                                                          " And DES_ESTADO='" & BCVariablesNames.EstadoRegistro.Procesado & "'"
                    MetodoBusquedaDato("", False, EtxtTDO_ID_CRO)
                Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                    EtxtTDO_ID_CRO.pOOrm.CadenaFiltrado = " And TDO_ID In ('" & BCVariablesNames.ProcesosDespacho.CronogramaDespacho & "')" & _
                                                          " And PVE_ID in (select pve_id_ane from [Distribuidora].[dbo].vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                                          " And DES_ESTADO='" & BCVariablesNames.EstadoRegistro.PorProcesar & "'"
                    EtxtTDO_ID_CRO.pOOrm.Vista = "BuscarRegistrosDesdeDistribuidora"
                    EtxtTDO_ID_CRO.pOOrm.pBuscarRegistros = False
                    MetodoBusquedaDato("", False, EtxtTDO_ID_CRO)
                Case Else
                    vProcesandoCronogramaDespacho = True
                    Exit Sub
            End Select
            MetodoBusquedaDato(BCVariablesNames.CCT_ID.CxCComerciales, True, EtxtCCT_ID)
        End Sub

        Private Function FiltrarSeleccionarValidarElementos(ByVal vProceso As Int16, _
                                                            ByVal vEstado As Boolean) As Boolean
            FiltrarSeleccionarValidarElementos = vEstado
            Select Case vProceso
                Case 1 ' Filtrado 
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                            cboDES_ESTADO.Items.Remove("ACTIVO")
                            'cboDES_ESTADO.Items.Remove("PROCESADO")
                        Case Else
                            cboDES_ESTADO.Items.Remove("POR PROCESAR")
                            cboDES_ESTADO.Items.Remove("PROCESADO")
                    End Select
                Case 2 ' Seleccionar Elemento Default
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                            cboDES_ESTADO.Text = "POR PROCESAR"
                            'cboDES_ESTADO.Text = "NO ACTIVO"
                        Case Else
                            cboDES_ESTADO.Text = "ACTIVO"
                    End Select
                Case 3 ' Validar dato seleccionado
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosDespacho.Guia
                        Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                        Case Else
                            FiltrarSeleccionarValidarElementos = vEstado
                    End Select
            End Select
            Return FiltrarSeleccionarValidarElementos
        End Function

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


        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            Select Case pComportamientoFormulario
                Case 100
                    BuscarDatos()
                Case 200
                    BuscarDatos()
                Case 300
                    BuscarDatos()
                Case 400
                    BuscarDatos()
            End Select

        End Sub

        Private Sub BuscarDatos()
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vFechaTrabajo As Date

            Select Case pComportamientoFormulario
                Case 100
                    Compuesto.Vista = "BuscarRegistrosParaControl"
                    vFechaTrabajo = IBCMaestro.EjecutarVista("spFechaServidor")
                Case 200
                    Compuesto.Vista = "BuscarRegistrosParaCarguio"
                    vFechaTrabajo = IBCMaestro.EjecutarVista("spFechaServidor")
                Case 300
                    Compuesto.Vista = "BuscarRegistrosParaHabilitarCronograma"
                    vFechaTrabajo = dtpFecha.Value
                Case 400
                    Compuesto.Vista = "BuscarRegistrosParaVisualizarCronograma"
                    vFechaTrabajo = dtpFecha.Value
            End Select

            Dim NombreProcedimiento As String = Compuesto.SentenciaSqlBusqueda()

            Dim ds As New DataSet
            Dim CadenaVista As String = ""

            Select Case pComportamientoFormulario
                Case 100
                    CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vFechaTrabajo, pPVE_ID, txtUNT_ID.Text)
                Case 200
                    CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vFechaTrabajo, pPVE_ID, txtDES_NUMERO_X.Text)
                Case 300
                    CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vFechaTrabajo, DBNull.Value)
                Case 400
                    CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vFechaTrabajo, DBNull.Value, DBNull.Value)
            End Select

            Dim sr As New StringReader(CadenaVista)

            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)

                Dim x = 0
                Dim y = 0

                dgvDatos.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
                        dgvDatos.Rows.Add()
                        With ds.Tables(0).Rows(x)
                            While y < ds.Tables(0).Columns.Count
                                dgvDatos.Item(y, dgvDatos.Rows.Count - 1).Value = _
                                    Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                y = y + 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                    Select Case pComportamientoFormulario
                        Case 300, 400
                            LimpiarDatos()
                            MostrarDatosDocumento()
                        Case Else
                    End Select
                Else
                    dgvDatos.Rows.Clear()
                End If
            Else
                dgvDatos.Rows.Clear()
            End If
            DespachosO()
            Me.Cursor = Windows.Forms.Cursors.Default
        End Sub

        Private Sub DespachosO(Optional ByVal vFlagCbo As Boolean = True, _
                                Optional ByVal vFlagDgv As Boolean = True)
            'OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)

            'OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)

            ''OcultarNombresCampos("DOC_MONTO_FLE", vFlagCbo, vFlagDgv)
            ''OcultarNombresCampos("DOC_REQUIERE_GUIA", vFlagCbo, vFlagDgv)
            ''OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
            ''OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)


            OcultarNombresCampos("cTDO_ID", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cTDO_DESCRIPCION", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDTD_ID", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cCCT_ID", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cCCT_DESCRIPCION", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDTD_SIGNO", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDTD_SIGNO_D", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDES_FEC_EMI", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDES_FEC_TRA", vFlagCbo, vFlagDgv)
            Select Case pComportamientoFormulario
                Case 100
                    'OcultarNombresCampos("cDES_FEC_SAL_PLA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("cDES_FEC_CAR_DES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("cDES_FEC_PRO_CRO", vFlagCbo, vFlagDgv)
                Case 200
                    OcultarNombresCampos("cDES_FEC_SAL_PLA", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("cDES_FEC_CAR_DES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("cDES_FEC_PRO_CRO", vFlagCbo, vFlagDgv)
                Case 300
                    OcultarNombresCampos("cDES_FEC_SAL_PLA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("cDES_FEC_CAR_DES", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("cDES_FEC_PRO_CRO", vFlagCbo, vFlagDgv)
                Case 400
                    OcultarNombresCampos("cDTD_DESCRIPCION", vFlagCbo, vFlagDgv)

                    OcultarNombresCampos("cDES_FEC_SAL_PLA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("cDES_FEC_CAR_DES", vFlagCbo, vFlagDgv)

                    OcultarNombresCampos("cPER_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("cUNT_ID_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("cUNT_ID_2", vFlagCbo, vFlagDgv)
            End Select

            OcultarNombresCampos("cPVE_ID", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPVE_DIRECCION", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_ID_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_ESTADO_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_ID_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_ESTADO_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_ID_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_ESTADO_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_ID_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_ESTADO_PVE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cALM_ID", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cALM_DESCRIPCION", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cALM_DIRECCION", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_ID_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_ESTADO_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_ID_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_ESTADO_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_ID_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_ESTADO_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_ID_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_ESTADO_ALM", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cALM_ESTADO", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cALM_ID_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cALM_DESCRIPCION_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cALM_DIRECCION_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cALM_ESTADO_LLEGADA", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DES_SERIE", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DES_NUMERO", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_ID_CLI", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cTDP_ID_CLI", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cTDP_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDOP_NUMERO_CLI", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_ID_VEN", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cTDO_ID_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cTDO_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDTD_ID_DOC", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DTD_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cCCT_ID_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cCCT_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDOC_ORDEN_COMPRA", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cTIV_ID_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cTIV_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cMON_ID_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cMON_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDOC_TIPO_LISTA", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DES_SERIE_DOC", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DES_NUMERO_DOC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_ID_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cTDP_ID_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cTDP_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDOP_NUMERO_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIR_ID_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIR_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIR_TIPO_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIR_REFERENCIA_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_ID_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_ID_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_ID_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_ID_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIR_ESTADO_ENT_REC", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIR_ID_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIR_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_ID_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIS_ESTADO_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_ID_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPRO_ESTADO_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_ID_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDEP_ESTADO_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_ID_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAI_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPAIS_ESTADO_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDIR_REFERENCIA_ENT", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cFLE_ID", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cFLE_DESCRIPCION", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cFLE_TIPO", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cFLE_ESTADO", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cMON_ID", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cMON_DESCRIPCION", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDES_MONTO_FLETE", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cDES_CONTRAVALOR", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPLA_ID", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_ID_TRA1", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("PER_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cRUC_TRA1", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_ESTADO_TRA1", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("UNT_ID_1", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cMAR_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cMOD_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cUNT_NRO_INS_TRA1", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("UNT_ID_2", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cMAR_DESCRIPCION_TRA2", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cMOD_DESCRIPCION_TRA2", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cUNT_NRO_INS_TRA2", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_ID_CHO", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_DESCRIPCION_CHO", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_BREVETE_CHO", vFlagCbo, vFlagDgv)
            OcultarNombresCampos("cPER_ESTADO_CHO", vFlagCbo, vFlagDgv)
            'OcultarNombresCampos("DES_ESTADO", vFlagCbo, vFlagDgv)
        End Sub

        Public Overridable Sub OcultarNombresCampos(ByVal NombreCampo As String, _
                                            Optional ByVal vFlagCbo As Boolean = True, _
                                            Optional ByVal vFlagDgv As Boolean = False)
            'If Not dgvDatos.DataSource Is Nothing Then 
            If vFlagDgv Then MostrarCampoListado(NombreCampo, False)
        End Sub
        Public Overridable Sub MostrarCampoListado(ByVal vNombreCampo, ByVal vMostrar)
            dgvDatos.Columns(vNombreCampo).Visible = vMostrar
        End Sub

        Private Sub DgvDatos_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles dgvDatos.CurrentCellDirtyStateChanged
            If dgvDatos.IsCurrentCellDirty Then
                dgvDatos.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End Sub
        Private Sub dgvDatos_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDatos.CellValueChanged
            Try
                If dgvDatos.Rows(e.RowIndex).Cells("cChecked").Value Then
                    MostrarDatosDocumento()
                Else
                    Select Case pComportamientoFormulario
                        Case 300, 400
                            MostrarDatosDocumento()
                        Case Else
                            LimpiarDatos()
                    End Select
                End If
                pnCuerpo.Enabled = False
            Catch ex As Exception
            End Try
        End Sub
        Private Sub dgvDatos_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDatos.RowEnter
            Try
                dgvDetalle.Rows.Clear()
                If dgvDatos.Rows(e.RowIndex).Cells("cChecked").Value Then
                    MostrarDatosDocumento()
                Else
                    Select Case pComportamientoFormulario
                        Case 300, 400
                            MostrarDatosDocumento()
                        Case Else
                            LimpiarDatos()
                    End Select
                End If
                pnCuerpo.Enabled = True
                ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, True)
                ConfigurarReadOnly(txtDES_NUMERO, True)
                ConfigurarReadOnly(dtpDES_FEC_EMI, True)
                ConfigurarReadOnlyNoBusqueda(txtALM_ID, EtxtALM_ID, True)
                ConfigurarReadOnly(cboDES_ESTADO, True)
                ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True)
                ConfigurarReadOnlyNoBusqueda(txtDIR_ID_ENT, EtxtDIR_ID_ENT, True)
                ConfigurarReadOnlyNoBusqueda(txtPLA_ID, EtxtPLA_ID, True)
                ConfigurarReadOnly(txtDIR_DESCRIPCION_ENT, True)
                ConfigurarReadOnly(txtDIR_REFERENCIA_ENT, True)

                txtDIR_DESCRIPCION_ENT.BackColor = Drawing.Color.White
                txtDIR_DESCRIPCION_ENT.ForeColor = System.Drawing.Color.Red
                txtDIR_REFERENCIA_ENT.BackColor = Drawing.Color.White
                txtDIR_REFERENCIA_ENT.ForeColor = System.Drawing.Color.Red

            Catch ex As Exception
                LimpiarDatos()
            End Try
        End Sub

        Private Sub MostrarDatosDocumento()
            Dim vUNT_NRO_INS_TRA1 As String = ""
            Dim vUNT_NRO_INS_TRA2 As String = ""

            If dgvDatos.SelectedRows(0).Cells("cTDO_ID").Value = txtTDO_ID.Text Then
                If dgvDatos.SelectedRows(0).Cells("cDTD_ID").Value = txtDTD_ID.Text Then
                    If dgvDatos.SelectedRows(0).Cells("cDES_SERIE").Value = txtDES_SERIE.Text Then
                        If dgvDatos.SelectedRows(0).Cells("cDES_NUMERO").Value = txtDES_NUMERO.Text Then
                            Exit Sub
                        End If
                    End If
                End If
            End If

            cMisProcedimientos.ColocarDatosGrid(txtPVE_ID, dgvDatos, "cPVE_ID")
            cMisProcedimientos.ColocarDatosGrid(txtTDO_ID, dgvDatos, "cTDO_ID")
            cMisProcedimientos.ColocarDatosGrid(txtDTD_ID, dgvDatos, "cDTD_ID")

            cMisProcedimientos.ColocarDatosGrid(cboSerieCorrelativo, dgvDatos, "cDES_SERIE")
            cMisProcedimientos.ColocarDatosGrid(txtDES_SERIE, dgvDatos, "cDES_SERIE")
            cMisProcedimientos.ColocarDatosGrid(txtDES_NUMERO, dgvDatos, "cDES_NUMERO")

            cMisProcedimientos.ColocarDatosGrid(dtpDES_FEC_EMI, dgvDatos, "cDES_FEC_EMI")
            cMisProcedimientos.ColocarDatosGrid(dtpDES_FEC_TRA, dgvDatos, "cDES_FEC_TRA")
            Select Case pComportamientoFormulario
                Case 400
                    dtpDES_FEC_TRA.Enabled = False
                    dtpDES_FEC_TRA.Visible = False
                    lblDES_FECHA_TRA.Enabled = False
                    lblDES_FECHA_TRA.Visible = False
                Case Else
            End Select

            cMisProcedimientos.ColocarDatosGrid(txtALM_ID, dgvDatos, "cALM_ID")
            cMisProcedimientos.ColocarDatosGrid(txtALM_DESCRIPCION, dgvDatos, "cALM_DESCRIPCION")
            cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("cALM_ESTADO", _
                cMisProcedimientos.DevolverDatosGrid(dgvDatos, "cALM_ESTADO"), Compuesto), chkALM_ESTADO)

            cMisProcedimientos.ColocarDatosGrid(txtCCT_ID, dgvDatos, "cCCT_ID")
            cMisProcedimientos.ColocarDatosGrid(txtCCT_DESCRIPCION, dgvDatos, "cCCT_DESCRIPCION")

            cMisProcedimientos.ColocarDatosGrid(cboDES_ESTADO, dgvDatos, "cDES_ESTADO")

            cMisProcedimientos.ColocarDatosGrid(txtALM_DIRECCION, dgvDatos, "cALM_DIRECCION")
            cMisProcedimientos.ColocarDatosGrid(txtDIS_ID_ALM, dgvDatos, "cDIS_ID_ALM")
            cMisProcedimientos.ColocarDatosGrid(txtDIS_DESCRIPCION_ALM, dgvDatos, "cDIS_DESCRIPCION_ALM")
            cMisProcedimientos.ColocarDatosGrid(txtPRO_ID_ALM, dgvDatos, "cPRO_ID_ALM")
            cMisProcedimientos.ColocarDatosGrid(txtPRO_DESCRIPCION_ALM, dgvDatos, "cPRO_DESCRIPCION_ALM")
            cMisProcedimientos.ColocarDatosGrid(txtDEP_ID_ALM, dgvDatos, "cDEP_ID_ALM")
            cMisProcedimientos.ColocarDatosGrid(txtDEP_DESCRIPCION_ALM, dgvDatos, "cDEP_DESCRIPCION_ALM")
            cMisProcedimientos.ColocarDatosGrid(txtPAI_ID_ALM, dgvDatos, "cPAI_ID_ALM")
            cMisProcedimientos.ColocarDatosGrid(txtPAI_DESCRIPCION_ALM, dgvDatos, "cPAI_DESCRIPCION_ALM")

            cMisProcedimientos.ColocarDatosGrid(txtALM_ID_LLEGADA, dgvDatos, "cALM_ID_LLEGADA")
            cMisProcedimientos.ColocarDatosGrid(txtALM_DESCRIPCION_LLEGADA, dgvDatos, "cALM_DESCRIPCION_LLEGADA")
            cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("cALM_ESTADO_LLEGADA", _
                cMisProcedimientos.DevolverDatosGrid(dgvDatos, "cALM_ESTADO_LLEGADA"), Compuesto), chkALM_ESTADO_LLEGADA)
            cMisProcedimientos.ColocarDatosGrid(txtALM_DIRECCION_LLEGADA, dgvDatos, "cALM_DIRECCION_LLEGADA")
            cMisProcedimientos.ColocarDatosGrid(txtDIS_ID_ALM_LLEGADA, dgvDatos, "cDIS_ID_ALM_LLEGADA")
            cMisProcedimientos.ColocarDatosGrid(txtDIS_DESCRIPCION_ALM_LLEGADA, dgvDatos, "cDIS_DESCRIPCION_ALM_LLEGADA")
            cMisProcedimientos.ColocarDatosGrid(txtPRO_ID_ALM_LLEGADA, dgvDatos, "cPRO_ID_ALM_LLEGADA")
            cMisProcedimientos.ColocarDatosGrid(txtPRO_DESCRIPCION_ALM_LLEGADA, dgvDatos, "cPRO_DESCRIPCION_ALM_LLEGADA")
            cMisProcedimientos.ColocarDatosGrid(txtDEP_ID_ALM_LLEGADA, dgvDatos, "cDEP_ID_ALM_LLEGADA")
            cMisProcedimientos.ColocarDatosGrid(txtDEP_DESCRIPCION_ALM_LLEGADA, dgvDatos, "cDEP_DESCRIPCION_ALM_LLEGADA")
            cMisProcedimientos.ColocarDatosGrid(txtPAI_ID_ALM_LLEGADA, dgvDatos, "cPAI_ID_ALM_LLEGADA")
            cMisProcedimientos.ColocarDatosGrid(txtPAI_DESCRIPCION_ALM_LLEGADA, dgvDatos, "cPAI_DESCRIPCION_ALM_LLEGADA")

            cMisProcedimientos.ColocarDatosGrid(txtPER_ID_CLI, dgvDatos, "cPER_ID_CLI")
            cMisProcedimientos.ColocarDatosGrid(txtPER_DESCRIPCION_CLI, dgvDatos, "cPER_DESCRIPCION_CLI")

            cMisProcedimientos.ColocarDatosGrid(txtTDO_ID_DOC, dgvDatos, "cTDO_ID_DOC")
            cMisProcedimientos.ColocarDatosGrid(txtDTD_ID_DOC, dgvDatos, "cDTD_ID_DOC")
            cMisProcedimientos.ColocarDatosGrid(txtDTD_DESCRIPCION_DOC, dgvDatos, "cDTD_DESCRIPCION_DOC")
            cMisProcedimientos.ColocarDatosGrid(txtDES_SERIE_DOC, dgvDatos, "cDES_SERIE_DOC")
            cMisProcedimientos.ColocarDatosGrid(txtDES_NUMERO_DOC, dgvDatos, "cDES_NUMERO_DOC")
            cMisProcedimientos.ColocarDatosGrid(txtDOC_TIPO_LISTA, dgvDatos, "cDOC_TIPO_LISTA")

            cMisProcedimientos.ColocarDatosGrid(txtDIR_ID_ENT, dgvDatos, "cDIR_ID_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtDIR_DESCRIPCION_ENT, dgvDatos, "cDIR_DESCRIPCION_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtDIR_REFERENCIA_ENT, dgvDatos, "cDIR_REFERENCIA_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtDIS_ID_ENT, dgvDatos, "cDIS_ID_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtDIS_DESCRIPCION_ENT, dgvDatos, "cDIS_DESCRIPCION_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtPRO_ID_ENT, dgvDatos, "cPRO_ID_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtPRO_DESCRIPCION_ENT, dgvDatos, "cPRO_DESCRIPCION_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtDEP_ID_ENT, dgvDatos, "cDEP_ID_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtDEP_DESCRIPCION_ENT, dgvDatos, "cDEP_DESCRIPCION_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtPAI_ID_ENT, dgvDatos, "cPAI_ID_ENT")
            cMisProcedimientos.ColocarDatosGrid(txtPAI_DESCRIPCION_ENT, dgvDatos, "cPAI_DESCRIPCION_ENT")

            cMisProcedimientos.ColocarDatosGrid(txtPLA_ID, dgvDatos, "cPLA_ID")
            cMisProcedimientos.ColocarDatosGrid(txtUNT_ID_1, dgvDatos, "cUNT_ID_1")
            cMisProcedimientos.ColocarDatosGrid(txtUNT_ID_2, dgvDatos, "cUNT_ID_2")

            vUNT_NRO_INS_TRA1 = dgvDatos.SelectedRows(0).Cells("cUNT_NRO_INS_TRA1").Value.ToString()
            vUNT_NRO_INS_TRA2 = dgvDatos.SelectedRows(0).Cells("cUNT_NRO_INS_TRA2").Value.ToString()

            If Not IsNothing(vUNT_NRO_INS_TRA1) Then
                txtCertificado.Text = vUNT_NRO_INS_TRA1
            End If
            If Not IsNothing(vUNT_NRO_INS_TRA2) Then
                txtCertificado.Text = txtCertificado.Text & " - " & vUNT_NRO_INS_TRA2
            End If

            cMisProcedimientos.ColocarDatosGrid(txtPER_ID_TRA1, dgvDatos, "cPER_ID_TRA1")
            cMisProcedimientos.ColocarDatosGrid(txtPER_DESCRIPCION_TRA1, dgvDatos, "cPER_DESCRIPCION_TRA1")
            cMisProcedimientos.ColocarDatosGrid(txtRUC_TRA1, dgvDatos, "cPER_DESCRIPCION_TRA1")
            cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("cPER_ESTADO_TRA1", _
                cMisProcedimientos.DevolverDatosGrid(dgvDatos, "cPER_ESTADO_TRA1"), Compuesto), chkPER_ESTADO_TRA1)

            cMisProcedimientos.ColocarDatosGrid(txtPER_ID_CHO, dgvDatos, "cPER_ID_CHO")
            cMisProcedimientos.ColocarDatosGrid(txtPER_DESCRIPCION_CHO, dgvDatos, "cPER_DESCRIPCION_CHO")
            cMisProcedimientos.ColocarDatosGrid(txtPER_BREVETE_CHO, dgvDatos, "cPER_BREVETE_CHO")
            cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("cPER_ESTADO_CHO", _
                cMisProcedimientos.DevolverDatosGrid(dgvDatos, "cPER_ESTADO_CHO"), Compuesto), chkPER_ESTADO_CHO)

            CodigoId = txtTDO_ID.Text
            vCodigoDTD_ID = txtDTD_ID.Text
            vCodigoDES_SERIE = txtDES_SERIE.Text
            vCodigoDES_NUMERO = txtDES_NUMERO.Text
            InicializarDatos()
            Me.CheckForIllegalCrossThreadCalls = False
            'pnCuerpo.Enabled = True

            'txtDIR_DESCRIPCION_ENT.BackColor = Drawing.Color.White
            'txtDIR_DESCRIPCION_ENT.ForeColor = System.Drawing.Color.Red
        End Sub

        Private Sub txtBuscarSerie_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBuscarSerie.KeyDown
            If e.KeyCode = Keys.F1 Then
                EtxtPVE_ID.pBusqueda = True
                LimpiarDatos()
                dgvDatos.Rows.Clear()
                txtPVE_ID.Text = txtBuscarSerie.Text
                EtxtPVE_ID.pTexto1 = txtBuscarSerie.Text
                TeclaF1Serie(EtxtPVE_ID, txtPVE_ID)
                txtBuscarSerie.Text = txtPVE_ID.Text
            End If
            
        End Sub
    End Class

End Namespace