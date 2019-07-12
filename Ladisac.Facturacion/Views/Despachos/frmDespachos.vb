Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Namespace Ladisac.Despachos.Views
    Public Class frmDespachos
        Public thLlamadaSaldosArticuloDocumento As Threading.Thread
        Public thLlamadaSaldosMontoDocumento As Threading.Thread
        Public thLlamadaProcesarFechaServidor As Threading.Thread
        Public thLlamadaPuntoVenta As Threading.Thread
        Public thLlamadaDetalleTipoDocumento As Threading.Thread
        Public thLlamadaCtaCte As Threading.Thread

        <Dependency()> _
        Public Property BCParametro As Ladisac.BL.IBCParametro
        <Dependency()> _
        Public Property BCDOC As Ladisac.BL.IBCDocumentos

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

        Public vBuscarDetalle As Boolean = True
        Private vMensajeErrorOrm As String = ""
        Private vDatosCambiaronSeDesecharan As Boolean = False
        Private vPreguntarCuandoDatosCambiaron As Boolean = False

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

                Select Case pDTD_ID
                    Case BCVariablesNames.ProcesosDespacho.GuiaDespacho
                        If vtxt.pOOrm.GetType.ToString.Contains("RolArticulosTipoArticulos") Then
                            vDatoBusqueda = vDatoBusqueda & "001"
                        End If

                    Case Else

                End Select
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
            If dgvDetalle.RowCount = 0 Then otxt.pBusqueda = True

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
            If Not pFlagNuevo Then If Trim(pCodigoId) = "" Then Return

            If Me.IBCBusqueda.PermisoCronograma(SessionService.UserId) > 0 Then
            Else
                If cboDES_ESTADO.Text = BCVariablesNames.EstadoRegistro.Procesado Then
                    Exit Sub
                End If
            End If

            BotonesEdicion("Editar registro")
            DeshabilitarModificar()
        End Sub
        Public Sub CancelarEdicion(ByVal vDeshacerCambios As Boolean)
            Dim vRegistroNuevo As Boolean = False
            vRegistroNuevo = pRegistroNuevo
            vPreguntarCuandoDatosCambiaron = vDeshacerCambios
            'If Not vDeshacerCambios Then
            If Not vRegistroNuevo Then
                If RevisarDatos(False) Then Return
            End If
            'End If
            If vDatosCambiaronSeDesecharan Or vRegistroNuevo Then
                'Me.Cursor = Cursors.WaitCursor
                LimpiarDatos()
                If Not vRegistroNuevo Then
                    BusquedaDatos("CancelarEdicion")
                Else
                    BusquedaDatos("Load")
                End If

                Me.Cursor = Cursors.Default
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
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaDespacho, _
                    BCVariablesNames.ProcesosDespacho.GuiaSalida, _
                    BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                    If txtDOC_TIPO_LISTA.Text = "PLANTA" Then
                        If txtPLA_ID.Text <> BCVariablesNames.PlacaElMismoLadrillera Then
                            Dim oMsgBoxResult As New MsgBoxResult()
                            oMsgBoxResult = MsgBox("¡Cliente recoge de planta!, No es posible colocarle placa de transportista" & Chr(13) & "¿Desea proceder a grabar la guía de remisión?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Me.Text)
                            If (oMsgBoxResult = MsgBoxResult.Yes) Then
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                Case Else
            End Select
            Dim vFildgvDetalle = 0
            Dim vFlagEncontroArticuloADespachar As Boolean = False
            Dim vART_ID_KAR As String
            If cboDES_ESTADO.Text <> "NO ACTIVO" Then
                While (dgvDetalle.Rows.Count() > vFildgvDetalle)
                    Dim vFildgvArticuloDocumento = 0
                    vART_ID_KAR = dgvDetalle.Rows(vFildgvDetalle).Cells("cART_ID_KAR").Value
                    While (dgvArticulosDocumento.Rows.Count() > vFildgvArticuloDocumento)
                        If vART_ID_KAR = dgvArticulosDocumento.Rows(vFildgvArticuloDocumento).Cells("cART_ID_KAR1").Value Then
                            If dgvArticulosDocumento.Rows(vFildgvArticuloDocumento).Cells("cDDO_CANTIDAD_SALDO1").Value <= 0 Then
                                MsgBox("¡Error en saldos!" & Chr(13) & "Verifique la cantidad a despachar", MsgBoxStyle.Exclamation, Me.Text)
                                Exit Sub
                            End If
                        End If
                        vFildgvArticuloDocumento += 1
                    End While
                    vFildgvDetalle += 1
                End While
            End If

            Dim vProcederImpresion As Boolean = False
            btnImagen.Focus()
            Dim bRes As Boolean = False
            If Not pRegistroNuevo Then
                If Not RevisarDatos(True) Then
                    If vNuevo Then
                        NuevoRegistro()
                    End If
                    Return
                End If
            End If

            If pRegistroNuevo Then
                txtDES_NUMERO.Text = Me.IBCBusqueda.CorrelativoSerie(cboSerieCorrelativo.Text, txtTDO_ID.Text)
                bRes = Ingresar()
                vProcederImpresion = True
            Else
                bRes = Modificar()
            End If

            If bRes Then
                vBuscarDetalle = False
                InicializarDatos()
            End If

            If (bRes) Then
                BotonesEdicion("Seleccionar registro")
                If vNuevo Then
                    NuevoRegistro()
                End If
                Dim vSystemObject As New System.Object
                Dim vEventArgs As New System.EventArgs

                Select Case txtDTD_ID.Text
                    Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    Case Else
                        If vProcederImpresion Then Call btnImpresion_Click(vSystemObject, vEventArgs)
                End Select
            End If
        End Sub

        Public Sub PrepararEliminar()
            ''para no eliminar
            'Select Case txtDTD_ID.Text
            '    Case BCVariablesNames.ProcesosDespacho.Guia _
            '        , BCVariablesNames.ProcesosDespacho.GuiaDespacho _
            '        , BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora _
            '        , BCVariablesNames.ProcesosDespacho.GuiaIngreso _
            '        , BCVariablesNames.ProcesosDespacho.GuiaPorNotaCredito _
            '        , BCVariablesNames.ProcesosDespacho.GuiaSalida _
            '        , BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora _
            '        , BCVariablesNames.ProcesosDespacho.GuiaTransferencia

            '        Exit Sub 'No debe de eliminar estas guias
            '    Case Else

            'End Select


            Dim bRes As Boolean = False
            Dim oMsgBoxResult As New MsgBoxResult()
            Try
                oMsgBoxResult = MsgBox("Esta seguro de eliminar el registro", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text)
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
            AdicionarFilasGrid()
        End Sub
        Public Sub QuitarFilaGrid()
            EliminarFilasGrid()
        End Sub
        Public Sub BuscarUnRegistro()
            vModificandoGuia = True
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
            'vRevisarDatosForm = RevisarDatosForm(vColeccionDatos, True)
            vDatosCambiaronSeDesecharan = False
            If RevisarDatosForm(vColeccionDatos, True) Then
                If vRespuestaGrabar Then
                    RevisarDatos = True
                Else
                    Dim oMsgBoxResult As New MsgBoxResult()
                    If vDesdeImpresion Then
                        oMsgBoxResult = MsgBox("Registro modificado... ¡Sin Grabar!." & Chr(13) & Chr(13), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, Me.Text & " - Grabe para poder imprimir.")
                        RevisarDatos = True
                    Else
                        If vPreguntarCuandoDatosCambiaron Then
                            vDatosCambiaronSeDesecharan = True
                            RevisarDatos = False
                        Else
                            oMsgBoxResult = MsgBox("Registro modificado... ¡Sin Grabar!." & Chr(13) & Chr(13) & "¿Desea continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, Me.Text & " - Se perderan los datos.")
                            If (oMsgBoxResult = MsgBoxResult.Cancel) Then
                                RevisarDatos = True
                            Else
                                vDatosCambiaronSeDesecharan = True
                                RevisarDatos = False
                            End If
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
                        If CodigoId <> "%" Then
                            Compuesto.CadenaFiltrado = " And PVE_ID='" & pPVE_ID & "'"
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
                            FiltradoTablaPrincipal()
                            'Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & _
                            '                           "' And PVE_ID='" & pPVE_ID & _
                            '                           "' And DTD_ID='" & pDTD_ID & "'"
                        End If
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
                        frm.OrdenBusqueda = 60
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

            'Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 1
            pRespuestaExtraerDetalle = 0
            Ingresar = False
            DatosCabecera()

            If (Validar("Cabecera")) Then
                Dim ts1 As New TimeSpan(0, 3, 0)
                Try
                    Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)
                        If (InsertarDatos()) Then
                            If Compuesto.ALM_ID <> 2 And Compuesto.ALM_ID <> 156 Then ' Agencias
                                If IBC.spActualizarDocuMovimiento(Compuesto) = 0 Then
                                    Scope.Dispose()
                                    MessageBox.Show("Error al ingresar al Kardex. No se guardo correctamente.")
                                    Exit Function
                                Else
                                    IBC.spEnviarCorreoDespacho(Compuesto)
                                End If
                            End If
                            Scope.Complete()
                            'vFlagActualizarDocuMovimiento = True
                            Ingresar = True
                            ConfigurarDatosGrabados()
                            vMensajeMostrar = 0
                        Else
                            If pRespuestaExtraerDetalle = -1 Then
                                Scope.Dispose()
                                vMensajeMostrar = 1
                                Exit Function
                            Else
                                Scope.Dispose()
                                vMensajeMostrar = 2
                                Exit Function
                            End If
                        End If





                        If vCodigoCronogramaTDO_ID <> "" And
                                      vCodigoCronogramaDTD_ID <> "" And
                                      vCodigoCronogramaDES_SERIE <> "" And
                                      vCodigoCronogramaDES_NUMERO <> "" And
                                      vMensajeMostrar <> 1 Then
                            Select Case pDTD_ID
                                Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                                    Me.IBCCronogramaDespacho.spActualizarDespachosDES_ESTADOEnDistribuidora(vCodigoCronogramaTDO_ID, vCodigoCronogramaDTD_ID, vCodigoCronogramaDES_SERIE, vCodigoCronogramaDES_NUMERO, DevolverTiposCampos("DES_ESTADO", BCVariablesNames.EstadoRegistro.NoActivo, Compuesto))
                                    Me.IBCCronogramaDespacho.spInsertarProgramacion(vCodigoCronogramaTDO_ID, vCodigoCronogramaDTD_ID, vCodigoCronogramaDES_SERIE, vCodigoCronogramaDES_NUMERO, Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.DES_SERIE, Compuesto.DES_NUMERO, Compuesto.USU_ID, DevolverTiposCampos("DES_ESTADO", BCVariablesNames.EstadoRegistro.Activo, Compuesto))
                                Case Else
                                    Me.IBCCronogramaDespacho.spActualizarDespachosDES_ESTADO(vCodigoCronogramaTDO_ID, vCodigoCronogramaDTD_ID, vCodigoCronogramaDES_SERIE, vCodigoCronogramaDES_NUMERO, DevolverTiposCampos("DES_ESTADO", BCVariablesNames.EstadoRegistro.NoActivo, Compuesto))
                                    Me.IBCCronogramaDespacho.spInsertarProgramacion(vCodigoCronogramaTDO_ID, vCodigoCronogramaDTD_ID, vCodigoCronogramaDES_SERIE, vCodigoCronogramaDES_NUMERO, Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.DES_SERIE, Compuesto.DES_NUMERO, Compuesto.USU_ID, DevolverTiposCampos("DES_ESTADO", BCVariablesNames.EstadoRegistro.Activo, Compuesto))
                            End Select
                        End If

                        Me.Cursor = Windows.Forms.Cursors.Default
                        If MensajeOperaciones(vMensajeMostrar, "ingresado") = 1 Then Return Ingresar 'MensajeOperaciones(vRespuestaScope, "ingresado")
                        InicializarOrm()
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Ingresar = False
                End Try

            End If

            'If vFlagActualizarDocuMovimiento = True Then
            'IBC.spActualizarDocuMovimiento(Compuesto)
            'End If


            Return Ingresar
        End Function

        Private Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            Dim vRespuestaLocal1 As Short = 0

            If IsNothing(Compuesto.ALM_ID_LLEGADA) Then
                vRespuestaLocal = IBC.spInsertarRegistroNullALM_ID_LLEGADA(Compuesto)
            Else
                vRespuestaLocal = IBC.spInsertarRegistro(Compuesto)
            End If

            If vRespuestaLocal = 0 Then
                InsertarDatos = False
                Return InsertarDatos
            End If

            vRespuestaLocal1 = IBCCorrelativoTipoDocumento.spActualizarRegistroDespacho(Compuesto2)

            If vRespuestaLocal1 = 0 Then
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
            'Dim vFlagActualizarDocuMovimiento As Boolean = False
            'Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 0
            pRespuestaExtraerDetalle = 0
            Modificar = False
            DatosCabecera()

            If (Validar("Cabecera")) Then
                Dim ts1 As New TimeSpan(0, 3, 0)
                Try
                    Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)
                        If (ActualizarDatos()) Then
                            If Compuesto.ALM_ID <> 2 And Compuesto.ALM_ID <> 156 Then ' Agencias
                                If IBC.spActualizarDocuMovimiento(Compuesto) = 0 Then
                                    Scope.Dispose()
                                    MessageBox.Show("Error al ingresar al Kardex. No se guardo correctamente.")
                                    Exit Function
                                End If
                            Else
                                If Compuesto.DES_FEC_SAL_PLA IsNot Nothing Then
                                    If Compuesto.DES_FEC_TRA.Date <> Today Then
                                        If IBC.spActualizarDocuMovimiento(Compuesto) = 0 Then
                                            Scope.Dispose()
                                            MessageBox.Show("Error al ingresar al Kardex. No se guardo correctamente.")
                                            Exit Function
                                        End If
                                    End If
                                End If
                            End If
                            '''ASI ES
                            Scope.Complete()
                            'vFlagActualizarDocuMovimiento = True
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



                        If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar 'MensajeOperaciones(vRespuestaScope, "modificado")
                        InicializarOrm()
                        Me.Cursor = Windows.Forms.Cursors.Default
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Modificar = False
                End Try
            Else
                vMensajeMostrar = 1
            End If

            'If vFlagActualizarDocuMovimiento = True Then
            '    IBC.spActualizarDocuMovimiento(Compuesto)
            'End If
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean
            pRespuestaExtraerDetalle = ExtraerDetalle()
            If pRespuestaExtraerDetalle = 0 Then
            Else
                If IsNothing(Compuesto.ALM_ID_LLEGADA) Then
                    ActualizarDatos = (Me.IBC.spActualizarRegistroNullALM_ID_LLEGADA(Compuesto) > 0 And pRespuestaExtraerDetalle = 1)
                Else
                    ActualizarDatos = (Me.IBC.spActualizarRegistro(Compuesto) > 0 And pRespuestaExtraerDetalle = 1)
                End If
            End If
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
            Dim vFlagActualizarDocuMovimiento As Boolean = False
            'Me.Cursor = Windows.Forms.Cursors.WaitCursor
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            Dim vMensajeMostrar As Int16 = 0
            Dim ts1 As New TimeSpan(0, 3, 0)
            Using Scope As New System.Transactions.TransactionScope(System.Transactions.TransactionScopeOption.RequiresNew, ts1)
                'Using Scope As New System.Transactions.TransactionScope()
                If (ProcesarEliminarDetalle() > 0 And Me.IBC.spEliminarRegistro(Compuesto) > 0) Then
                    IBC.spActualizarDocuMovimiento(Compuesto)
                    Scope.Complete()
                    vFlagActualizarDocuMovimiento = True
                    EliminarRegistro = True
                    vMensajeMostrar = 0
                Else
                    Scope.Dispose()
                    EliminarRegistro = False
                    vMensajeMostrar = 2
                End If
            End Using


            'If vFlagActualizarDocuMovimiento = True Then
            'IBC.spActualizarDocuMovimiento(Compuesto)
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

        Private ProcesarJalarPrimerArticuloDespachar As Boolean = True

        Private iGuiaDespacho As New Object
        Private oImpresion As Object

        Public vDOC_ORDEN_COMPRA As String = ""
        Public Property pDocumentoProcesandose As Int16 = 0
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
        Private EcboDES_TIPO_GUIA As New cbo

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

            'Select Case pDTD_ID
            'Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
            'Case Else
            InicializarValores(txtPER_ID_VEN1, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_VEN1, ErrorProvider1)
            'End Select

            InicializarValores(txtPER_ID_CLI, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_CLI, ErrorProvider1)
            InicializarValores(txtTDP_ID_CLI, ErrorProvider1)
            InicializarValores(txtTDP_DESCRIPCION_CLI, ErrorProvider1)
            InicializarValores(txtDOP_NUMERO_CLI, ErrorProvider1)

            InicializarValores(txtTDO_ID_DOC, ErrorProvider1)
            InicializarValores(txtDTD_ID_DOC, ErrorProvider1)
            InicializarValores(txtDTD_DESCRIPCION_DOC, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_VEN, ErrorProvider1)
            InicializarValores(txtDES_SERIE_DOC, ErrorProvider1)
            InicializarValores(txtDES_NUMERO_DOC, ErrorProvider1)
            InicializarValores(txtDOC_TIPO_LISTA, ErrorProvider1)

            InicializarValores(txtTIV_ID_DOC, ErrorProvider1)
            InicializarValores(txtTIV_DESCRIPCION_DOC, ErrorProvider1)

            InicializarValores(txtFLE_ID, ErrorProvider1)
            InicializarValores(txtFLE_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtDES_MONTO_FLETE, ErrorProvider1, True, True)

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

            InicializarValores(txtPER_ID_REC, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_REC, ErrorProvider1)
            InicializarValores(txtTDP_ID_REC, ErrorProvider1)
            InicializarValores(txtTDP_DESCRIPCION_REC, ErrorProvider1)
            InicializarValores(txtDOP_NUMERO_REC, ErrorProvider1)

            InicializarValores(txtDIR_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtDIR_DESCRIPCION_ENT_REC, ErrorProvider1)
            InicializarValores(txtDIS_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtDIS_DESCRIPCION_ENT_REC, ErrorProvider1)
            InicializarValores(txtPRO_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtPRO_DESCRIPCION_ENT_REC, ErrorProvider1)
            InicializarValores(txtDEP_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtDEP_DESCRIPCION_ENT_REC, ErrorProvider1)
            InicializarValores(txtPAI_ID_ENT_REC, ErrorProvider1)
            InicializarValores(txtPAI_DESCRIPCION_ENT_REC, ErrorProvider1)

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
            InicializarValores(dgvArticulosDocumento, ErrorProvider1)
            InicializarValores(dgvSaldosMontoDocumento, ErrorProvider1)

            FiltrarSeleccionarValidarElementos(2, True)
            FiltrarSeleccionarValidarElementosDES_TIPO_GUIA(2, True)


            '''chkVentaTercero.CheckState = CheckState.Unchecked

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

            ConfigurarReadOnlyNoBusqueda(txtPER_ID_VEN1, EtxtPER_ID_VEN1, True) ' Bloquea
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

                        lblDES_FECHA_TRA.Visible = False
                        dtpDES_FEC_TRA.Visible = False
                        dtpDES_FEC_TRA.Enabled = False

                        lblTipoGuia.Visible = False
                        ''chkVentaTercero.Enabled = False
                        ''chkVentaTercero.Visible = False
                    End If
                    GuiaDespacho(vControl)
                Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion, _
                     BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                    If pDTD_ID = BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora Then
                        Compuesto.Vista = "BuscarRegistrosDocumentoDesdeDistribuidora"
                        Compuesto.pBuscarRegistros = False
                    End If
                    lblTipoGuia.Visible = False
                    ''chkVentaTercero.Enabled = False
                    ''chkVentaTercero.Visible = False
                    GuiaDevolucion(vControl)
                Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                    lblTipoGuia.Visible = False
                    ''chkVentaTercero.Enabled = False
                    ''chkVentaTercero.Visible = False
                    GuiaTransferencia(vControl)
                Case BCVariablesNames.ProcesosDespacho.GuiaSalida
                    GuiaSalida(vControl)
                Case Else
            End Select
        End Sub
        Private Sub GuiaDespacho(ByVal vControl As Integer)
            If vControl = 1 Then
                tcoDirecciones.SelectedIndex = 0
                ConfigurarDatos("tpaDocumento")
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
                    RemoverTabs(tcoDirecciones, tpaRecepciona)
                    RemoverTabs(tcoDirecciones, tpaSaldo)
                    cDDO_CANTIDAD_VENDIDA1.HeaderText = "Cantidad despachada"
                    cDDO_CANTIDAD_MOVIDA1.HeaderText = "Cantidad devuelta"
                    cDDO_CANTIDAD_SALDO1.HeaderText = "Saldo"
                    cMover1.HeaderText = "Cantidad a devolver"
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
                    RemoverTabs(tcoDirecciones, tpaRecepciona)
                    RemoverTabs(tcoDirecciones, tpaSaldo)
                    RemoverTabs(tcoDirecciones, tpaDocumento)
                    cDDO_CANTIDAD_VENDIDA1.HeaderText = "Cantidad despachada"
                    cDDO_CANTIDAD_MOVIDA1.HeaderText = "Cantidad devuelta"
                    cDDO_CANTIDAD_SALDO1.HeaderText = "Saldo"
                    cMover1.HeaderText = "Cantidad a transferir"
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
            If vControl = 1 Then
                tcoDirecciones.SelectedIndex = 0
                ConfigurarDatos("tpaDocumento")
                If Not DesignMode Then
                    lblALM_ID.Text = "Alm.Sal."
                    tpaEntrega.Text = "Dir. Entrega"
                    VisualizarDatosClienteDocumento(False)
                    VisualizarDatosALmacenLLegada(False)
                    cDDE_CANTIDAD.ReadOnly = False
                    cART_ID_KAR.ReadOnly = False
                    cboDes_Tipo_Guia.SelectedIndex = 3 'Pre determinado consignacion
                End If
            End If
            NuevoGuiaSalida() 'Habilita los controles
        End Sub
        Private Sub NuevoGuiaSalida()
            MostrarVendedor()
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
            lblTDP_ID_CLI.Visible = vVisible
            txtTDP_ID_CLI.Visible = vVisible
            txtTDP_DESCRIPCION_CLI.Visible = vVisible
            txtDOP_NUMERO_CLI.Visible = vVisible
            lblDOC_SERIE_DOC.Visible = vVisible
            lblDOC_SERIE_DOC.Visible = vVisible
            lblSeparador1.Visible = vVisible
            txtDES_SERIE_DOC.Visible = vVisible
            txtDES_NUMERO_DOC.Visible = vVisible
            txtDOC_TIPO_LISTA.Visible = vVisible
            lblTIV_ID.Visible = vVisible
            txtTIV_ID_DOC.Visible = vVisible
            txtTIV_DESCRIPCION_DOC.Visible = vVisible
            lblFLE_ID.Visible = vVisible
            txtFLE_ID.Visible = vVisible
            txtFLE_DESCRIPCION.Visible = vVisible
            txtDES_MONTO_FLETE.Visible = vVisible
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
                        'cboDES_ESTADO.Enabled = True ' Desbloquea
                    Else
                        ConfigurarReadOnly(dtpDES_FEC_EMI) ' Bloquea
                        'cboDES_ESTADO.Enabled = False ' Bloquea
                    End If
            End Select

            ConfigurarReadOnlyNoBusqueda(txtALM_ID, EtxtALM_ID, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtALM_ID_LLEGADA, EtxtALM_ID_LLEGADA, True) ' Bloquea

            ConfigurarReadOnlyNoBusqueda(txtPER_ID_VEN1, EtxtPER_ID_VEN1, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID_DOC, EtxtDTD_ID_DOC, True) ' Bloquea
        End Sub
        Private Sub AdicionarFilasGrid()
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia, BCVariablesNames.ProcesosDespacho.GuiaSalida
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
                    EliminarFilasDetalleFactura()
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
                    If vBuscarDetalle Then
                        InicializarValores(dgvDetalle, ErrorProvider1)
                        InicializarValores(dgvArticulosDocumento, ErrorProvider1)
                        InicializarValores(dgvSaldosMontoDocumento, ErrorProvider1)
                    End If

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

                        ProcesarJalarPrimerArticuloDespachar = False
                        LlamadaSaldosArticuloDocumento()
                        ProcesarJalarPrimerArticuloDespachar = True
                        'SaldosArticuloDocumento()

                        LlamadaSaldosMontoDocumento()
                        'SaldosMontoDocumento()
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
                        'CodigoDES_SERIE = "9" & Strings.Mid(CodigoDES_SERIE, 2, 2)
                    End If
                Case Else
                    If vProcesarProforma Then
                        Compuesto1.Vista = "ListarRegistrosCronograma"
                    Else
                        Compuesto1.Vista = "ListarRegistros"
                    End If

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

            'LlamadaSaldosArticuloDocumento()
            SaldosArticuloDocumento()
            'JalarPrimerArticuloDespachar()

            LlamadaSaldosMontoDocumento()
            'SaldosMontoDocumento()

            ProcesarLugarLLegada()
            btnImpresion.Enabled = False
            VerificarCantidadDespacho()
            'ProcesarGridVacio()
            'VerificarDescuentosProforma()
        End Sub
        Private Sub VerificarCantidadDespacho()
            Dim vFildgvDetalle As Int16 = 0
            Dim vSubFildgvDetalle As Int16 = 0
            Dim vFildgvArticuloDocumento As Int16 = 0
            Dim vART_ID As String = ""
            Dim vDDE_CANTIDAD As Double = 0

            While (dgvDetalle.Rows.Count() > vFildgvDetalle)
                dgvDetalle.Rows(vFildgvDetalle).Cells("cEstadoRegistro").Value = 0
                vART_ID = dgvDetalle.Rows(vFildgvDetalle).Cells("cART_ID_KAR").Value
                vDDE_CANTIDAD = 0

                vSubFildgvDetalle = 0
                While (dgvDetalle.Rows.Count() > vSubFildgvDetalle)
                    If dgvDetalle.Rows(vSubFildgvDetalle).Cells("cART_ID_KAR").Value = vART_ID And _
                       dgvDetalle.Rows(vSubFildgvDetalle).Cells("cDDE_ESTADO").Value = "ACTIVO" Then
                        vDDE_CANTIDAD += dgvDetalle.Rows(vFildgvDetalle).Cells("cDDE_CANTIDAD").Value
                    End If
                    vSubFildgvDetalle += 1
                End While

                vFildgvArticuloDocumento = 0
                While (dgvArticulosDocumento.Rows.Count() > vFildgvArticuloDocumento)
                    If dgvArticulosDocumento.Rows(vFildgvArticuloDocumento).Cells("cART_ID_KAR1").Value = vART_ID Then
                        If vDDE_CANTIDAD > dgvArticulosDocumento.Rows(vFildgvArticuloDocumento).Cells("cDDO_CANTIDAD_SALDO1").Value Then
                            dgvDetalle.Rows(vFildgvDetalle).Cells("cDDE_CANTIDAD").Value = dgvArticulosDocumento.Rows(vFildgvArticuloDocumento).Cells("cDDO_CANTIDAD_SALDO1").Value
                        End If
                    End If
                    vFildgvArticuloDocumento += 1
                End While

                vFildgvDetalle += 1
            End While
        End Sub

        Private Sub Pausa(ByVal segundos As Integer)
            Dim esperaTmp As Long = My.Computer.Clock.TickCount + (segundos * 1000)
            While esperaTmp > My.Computer.Clock.TickCount
                System.Windows.Forms.Application.DoEvents()
            End While
        End Sub

        Private Sub SaldosArticuloDocumentoADgv()
            Dim x As Int32 = 0
            Dim y As Int32 = 0

            Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()

            Dim vCodigoId As String
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    vCodigoId = BCVariablesNames.ProcesosDespacho.Guia
                Case Else
                    vCodigoId = CodigoId
            End Select

            Dim vf As String = vCodigoId & vCodigoDTD_ID & vCodigoDES_SERIE & vCodigoDES_NUMERO
            Dim ds1 As New DataSet
            Dim sr1 As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                 vCodigoId, _
                                                                 txtTDO_ID_DOC.Text, _
                                                                 txtDTD_ID_DOC.Text, _
                                                                 txtDES_SERIE_DOC.Text, _
                                                                 txtDES_NUMERO_DOC.Text, _
                                                                 pTIP_ID, _
                                                                 vf, _
                                                                 Nothing))
            Dim vcontrol As Int16 = sr1.Peek
            If vcontrol <> -1 Then
                ds1.ReadXml(sr1)
                x = 0
                y = 0
                dgvArticulosDocumento.Rows.Clear()
                If (ds1.Tables(0).Rows.Count > 0) Then
                    While (x < ds1.Tables(0).Rows.Count)
                        dgvArticulosDocumento.Rows.Add()
                        With ds1.Tables(0).Rows(x)
                            While y < ds1.Tables(0).Columns.Count
                                dgvArticulosDocumento.Item(y, dgvArticulosDocumento.Rows.Count - 1).Value = _
                                    Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                y += 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                    'dgvArticulosDocumento.Item("cMover1", 0).Value = dgvArticulosDocumento.Item("cDDO_CANTIDAD_SALDO1", 0).Value
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information)
                End If
            Else
                dgvArticulosDocumento.DataSource = Nothing
            End If
        End Sub

        Private Sub LlamadaSaldosArticuloDocumento()
            thLlamadaSaldosArticuloDocumento = New Threading.Thread(AddressOf SaldosArticuloDocumento)
            If thLlamadaSaldosArticuloDocumento.ThreadState <> Threading.ThreadState.Running Then
                thLlamadaSaldosArticuloDocumento.Start()
            End If
        End Sub
        Private Sub LlamadaSaldosMontoDocumento()
            thLlamadaSaldosMontoDocumento = New Threading.Thread(AddressOf SaldosMontoDocumento)
            If thLlamadaSaldosMontoDocumento.ThreadState <> Threading.ThreadState.Running Then
                thLlamadaSaldosMontoDocumento.Start()
            End If
        End Sub

        Private Sub SaldosArticuloDocumento()
            'Me.Cursor = Cursors.WaitCursor
            If txtDTD_ID_DOC.Text.Trim = "" Then
                dgvArticulosDocumento.DataSource = Nothing
                Me.Cursor = Cursors.Default
                If thLlamadaSaldosArticuloDocumento.ThreadState = Threading.ThreadState.Running Then thLlamadaSaldosArticuloDocumento.Abort()
                Exit Sub
            End If

            Dim x As Int32 = 0
            Dim y As Int32 = 0

            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaDespacho, _
                     BCVariablesNames.ProcesosDespacho.GuiaSalida
                    Compuesto1.Vista = "SaldosArticuloDocumento"
                    SaldosArticuloDocumentoADgv()
                Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                    Compuesto1.Vista = "SaldosArticuloDocumentoDesdeDistribuidora"
                    SaldosArticuloDocumentoADgv()
                Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    Compuesto1.Vista = "SaldosArticuloDocumento"
                    'Compuesto1.Vista = "SaldosArticuloDocumentoConCronogramaDespacho"
                    SaldosArticuloDocumentoADgv()
                Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion
                    Compuesto1.Vista = "DocumentoDespachadoDespacho"
                    Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()
                    Dim DocumentoDespacho As String = txtTDO_ID.Text.Trim & txtDTD_ID.Text.Trim & txtDES_SERIE.Text.Trim & txtDES_NUMERO.Text.Trim
                    Dim DocumentoVenta As String = txtTDO_ID_DOC.Text.Trim & txtDTD_ID_DOC.Text.Trim & txtDES_SERIE_DOC.Text.Trim & txtDES_NUMERO_DOC.Text.Trim
                    Dim ds1 As New DataSet
                    Dim sr1 As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                         txtPER_ID_CLI.Text, _
                                                                         DocumentoVenta, _
                                                                         DocumentoDespacho
                                                                         ))
                    Dim vcontrol As Int16 = sr1.Peek
                    If vcontrol <> -1 Then
                        ds1.ReadXml(sr1)
                        x = 0
                        y = 0
                        dgvArticulosDocumento.Rows.Clear()
                        If (ds1.Tables(0).Rows.Count > 0) Then
                            Try
                                While (x < ds1.Tables(0).Rows.Count)
                                    dgvArticulosDocumento.Rows.Add()
                                    With ds1.Tables(0).Rows(x)
                                        While y < ds1.Tables(0).Columns.Count
                                            dgvArticulosDocumento.Item(y, dgvArticulosDocumento.Rows.Count - 1).Value = _
                                                Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                            y += 1
                                        End While
                                        y = 0
                                    End With
                                    x += 1
                                End While
                            Catch ex As Exception
                            End Try
                        Else
                            MsgBox("No se encontro registros", MsgBoxStyle.Information)
                        End If
                    Else
                        dgvArticulosDocumento.DataSource = Nothing
                    End If
                Case BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                    Compuesto1.Vista = "DocumentoDespachadoDespachoDesdeDistribuidora"
                    Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()
                    Dim DocumentoDespacho As String = txtTDO_ID.Text.Trim & txtDTD_ID.Text.Trim & txtDES_SERIE.Text.Trim & txtDES_NUMERO.Text.Trim
                    Dim DocumentoVenta As String = txtTDO_ID_DOC.Text.Trim & txtDTD_ID_DOC.Text.Trim & txtDES_SERIE_DOC.Text.Trim & txtDES_NUMERO_DOC.Text.Trim
                    Dim ds1 As New DataSet
                    Dim sr1 As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                         txtPER_ID_CLI.Text, _
                                                                         DocumentoVenta, _
                                                                         DocumentoDespacho
                                                                         ))
                    Dim vcontrol As Int16 = sr1.Peek
                    If vcontrol <> -1 Then
                        ds1.ReadXml(sr1)
                        x = 0
                        y = 0
                        dgvArticulosDocumento.Rows.Clear()
                        If (ds1.Tables(0).Rows.Count > 0) Then
                            Try
                                While (x < ds1.Tables(0).Rows.Count)
                                    dgvArticulosDocumento.Rows.Add()
                                    With ds1.Tables(0).Rows(x)
                                        While y < ds1.Tables(0).Columns.Count
                                            dgvArticulosDocumento.Item(y, dgvArticulosDocumento.Rows.Count - 1).Value = _
                                                Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                            y += 1
                                        End While
                                        y = 0
                                    End With
                                    x += 1
                                End While
                            Catch ex As Exception
                            End Try
                        Else
                            MsgBox("No se encontro registros", MsgBoxStyle.Information)
                        End If
                    Else
                        dgvArticulosDocumento.DataSource = Nothing
                    End If
                Case Else
            End Select
            ActualizarEstadoRegistro()
            'If ProcesarJalarPrimerArticuloDespachar Then JalarPrimerArticuloDespachar()
            Me.Cursor = Cursors.Default
            'thLlamadaSaldosArticuloDocumento.Abort()
        End Sub
        Private Sub ActualizarEstadoRegistro()
            If dgvDetalle.RowCount = 0 Then Exit Sub
            If dgvArticulosDocumento.RowCount > 0 Then
                For vFilaA = 0 To dgvArticulosDocumento.RowCount - 1
                    For vFilaD = 0 To dgvDetalle.RowCount - 1
                        If dgvArticulosDocumento.Item("cART_ID_KAR1", vFilaA).Value = _
                            dgvDetalle.Item("cART_ID_KAR", vFilaD).Value Then
                            dgvArticulosDocumento.Item("cEstadoRegistro1", vFilaA).Value = 0
                        End If
                    Next
                Next
            End If
        End Sub

        Private Sub SaldosMontoDocumento()
            'Me.Cursor = Cursors.WaitCursor
            If txtDTD_ID_DOC.Text.Trim = "" Then
                dgvSaldosMontoDocumento.DataSource = Nothing
                Me.Cursor = Cursors.Default
                thLlamadaSaldosMontoDocumento.Abort()
                Exit Sub
            End If
            Dim x As Int32 = 0
            Dim y As Int32 = 0
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                    Compuesto12.Vista = "SaldoXDocumentoDesdeDistribuidora"
                Case Else
                    Compuesto12.Vista = "SaldoXDocumento"
            End Select

            Dim NombreProcedimiento As String = Compuesto12.SentenciaSqlBusqueda()
            Dim ds1 As New DataSet
            Dim sr1 As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                     txtPER_ID_CLI.Text, _
                                                     txtTDO_ID_DOC.Text +
                                                     txtDTD_ID_DOC.Text +
                                                     txtDES_SERIE_DOC.Text +
                                                     txtDES_NUMERO_DOC.Text))


            Dim vcontrol As Int16 = sr1.Peek
            If vcontrol <> -1 Then
                ds1.ReadXml(sr1)
                x = 0
                y = 0
                dgvSaldosMontoDocumento.Rows.Clear()
                If (ds1.Tables(0).Rows.Count > 0) Then
                    While (x < ds1.Tables(0).Rows.Count)
                        dgvSaldosMontoDocumento.Rows.Add()
                        With ds1.Tables(0).Rows(x)
                            While y < ds1.Tables(0).Columns.Count
                                dgvSaldosMontoDocumento.Item(y, dgvSaldosMontoDocumento.Rows.Count - 1).Value = _
                                    Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                y += 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information)
                End If
            Else
                dgvSaldosMontoDocumento.DataSource = Nothing
            End If
            Me.Cursor = Cursors.Default
            thLlamadaSaldosMontoDocumento.Abort()
        End Sub
        Private Sub ProcesarLugarLLegada()
            Select Case txtDOC_TIPO_LISTA.Text
                Case BCVariablesNames.TipoPuntoVenta.Planta, _
                     BCVariablesNames.TipoPuntoVenta.Punto
                    If pRegistroNuevo Then
                        'MetodoBusquedaDato(Me.SessionService.PlacaElMismo, True, EtxtPLA_ID)
                        'EtxtPLA_ID.pOOrm.unt_id_1 = txtUNT_ID_1.Text
                        MetodoBusquedaDato(IIf(txtUNT_ID_1.Text = "", Me.SessionService.PlacaElMismo, txtPLA_ID.Text), True, EtxtPLA_ID)
                        ''If pDTD_ID = "021" Then
                        ''    MetodoBusquedaDato(Me.SessionService.PlacaElMismo, True, EtxtPLA_ID)
                        ''Else
                        ''    MetodoBusquedaDato(txtUNT_ID_1.Text, True, EtxtPLA_ID)
                        ''End If


                        If txtDIR_ID_ENT.Text = "" Or IsNothing(txtDIR_ID_ENT.Text) Then
                            MetodoBusquedaDato("X", True, EtxtDIR_ID_ENT)
                            txtDIR_ID_ENT.Text = Nothing

                            txtDIR_DESCRIPCION_ENT.Text = txtALM_DIRECCION.Text
                            txtDIS_DESCRIPCION_ENT.Text = txtDIS_DESCRIPCION_ALM.Text
                            txtPRO_DESCRIPCION_ENT.Text = txtPRO_DESCRIPCION_ALM.Text
                            txtDEP_DESCRIPCION_ENT.Text = txtDEP_DESCRIPCION_ALM.Text
                            txtPAI_DESCRIPCION_ENT.Text = txtPAI_DESCRIPCION_ALM.Text
                        End If
                    Else
                        If Trim(txtDIR_ID_ENT.Text) = "" Or IsNothing(txtDIR_ID_ENT.Text) Then
                            txtDIR_ID_ENT.Text = Nothing

                            txtDIR_DESCRIPCION_ENT.Text = txtALM_DIRECCION.Text
                            txtDIS_DESCRIPCION_ENT.Text = txtDIS_DESCRIPCION_ALM.Text
                            txtPRO_DESCRIPCION_ENT.Text = txtPRO_DESCRIPCION_ALM.Text
                            txtDEP_DESCRIPCION_ENT.Text = txtDEP_DESCRIPCION_ALM.Text
                            txtPAI_DESCRIPCION_ENT.Text = txtPAI_DESCRIPCION_ALM.Text
                        End If
                    End If
                    'txtPLA_ID.Enabled = False
                    'txtDIR_ID_ENT.Enabled = False
                    txtPLA_ID.Enabled = True
                    txtDIR_ID_ENT.Enabled = True
                    RemoverTabs(tcoDirecciones, tpaRecepciona)
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
        Private Sub JalarPrimerArticuloDespachar()
            If Not vProcesandoCronogramaDespacho Then
                If dgvArticulosDocumento.Item("cDDO_CANTIDAD_SALDO1", 0).Value > 0 Then
                    ProcesarArticulosDespacho(0)
                    vProcesandoJalarPrimerArticuloDespachar = True
                Else
                    vProcesandoJalarPrimerArticuloDespachar = False
                End If
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

                    Compuesto1.DDE_ESTADO = Compuesto.DES_ESTADO
                    'If Compuesto.DES_ESTADO = 0 Then
                    'Compuesto1.DDE_ESTADO = 0
                    'Else
                    'Compuesto1.DDE_ESTADO = DevolverTiposCampos("DDE_ESTADO", .Cells("cDDE_ESTADO").Value.ToString, Compuesto1)
                    'End If


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
            Compuesto.TDO_ID = Strings.Trim(txtTDO_ID.Text)
            Compuesto.DTD_ID = Strings.Trim(txtDTD_ID.Text)
            Compuesto.CCT_ID = Strings.Trim(txtCCT_ID.Text)
            Compuesto.DES_FEC_EMI = dtpDES_FEC_EMI.Value
            Compuesto.DES_FEC_TRA = dtpDES_FEC_TRA.Value
            If Not pRegistroNuevo Then
                If dtpDES_FEC_SAL_PLA.Value.ToString.Substring(0, 10) = "01/01/1900" Then
                    Compuesto.DES_FEC_SAL_PLA = Nothing
                Else
                    Compuesto.DES_FEC_SAL_PLA = dtpDES_FEC_SAL_PLA.Value
                End If
            Else
                Compuesto.DES_FEC_SAL_PLA = Nothing
            End If
            Compuesto.PVE_ID = Strings.Trim(txtPVE_ID.Text)
            If IsNumeric(txtALM_ID.Text) Then
                Compuesto.ALM_ID = CInt(txtALM_ID.Text)
            Else
                Compuesto.ALM_ID = Nothing
            End If
            If IsNumeric(txtALM_ID_LLEGADA.Text) Then
                Compuesto.ALM_ID_LLEGADA = CInt(txtALM_ID_LLEGADA.Text)
            Else
                Compuesto.ALM_ID_LLEGADA = Nothing
            End If

            Compuesto.DES_SERIE = Strings.Trim(txtDES_SERIE.Text)
            Compuesto.DES_NUMERO = Strings.Trim(txtDES_NUMERO.Text)
            Compuesto.PLA_ID = Strings.Trim(txtPLA_ID.Text)

            If Strings.Trim(txtFLE_ID.Text) = "" Then
                Compuesto.FLE_ID = Nothing
            Else
                Compuesto.FLE_ID = Strings.Trim(txtFLE_ID.Text)
            End If

            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia, _
                    BCVariablesNames.ProcesosDespacho.GuiaSalida
                    DatosGuiaSinDocumento()
                    Compuesto.DIR_ID_ENT = Nothing
                    'Compuesto.DIR_ID_ENT = Strings.Trim(txtDIR_ID_ENT.Text)
                    Compuesto.MON_ID = Nothing
                Case Else
                    Compuesto.TDO_ID_DOC = Strings.Trim(txtTDO_ID_DOC.Text)
                    Compuesto.DTD_ID_DOC = Strings.Trim(txtDTD_ID_DOC.Text)
                    Compuesto.DES_SERIE_DOC = Strings.Trim(txtDES_SERIE_DOC.Text)
                    Compuesto.DES_NUMERO_DOC = Strings.Trim(txtDES_NUMERO_DOC.Text)
                    Select Case txtDOC_TIPO_LISTA.Text
                        Case BCVariablesNames.TipoPuntoVenta.Planta, _
                             BCVariablesNames.TipoPuntoVenta.Punto
                            If Strings.Trim(txtDIR_ID_ENT.Text) = "" Then
                                Compuesto.DIR_ID_ENT = Nothing
                            Else
                                Compuesto.DIR_ID_ENT = Strings.Trim(txtDIR_ID_ENT.Text)
                            End If
                        Case Else
                            Compuesto.DIR_ID_ENT = Strings.Trim(txtDIR_ID_ENT.Text)
                    End Select
                    Compuesto.MON_ID = Strings.Trim(txtMON_ID.Text)
            End Select
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

            Compuesto.DES_MONTO_FLETE = CDbl(txtDES_MONTO_FLETE.Text)
            Compuesto.USU_ID = SessionService.UserId
            Compuesto.DES_FEC_GRAB = Now
            'Compuesto.DES_ESTADO = DevolverTiposCampos(chkDES_ESTADO)
            Compuesto.DES_TIPO_GUIA = DevolverTiposCampos("DES_TIPO_GUIA", cboDes_Tipo_Guia.Text, Compuesto)
            Compuesto.DES_ESTADO = DevolverTiposCampos("DES_ESTADO", cboDES_ESTADO.Text, Compuesto)

            ' Correlativo de serie
            Compuesto2.TDO_ID = txtTDO_ID.Text
            Compuesto2.PVE_ID = txtPVE_ID.Text
            Compuesto2.CTD_COR_SERIE = txtDES_SERIE.Text
            Compuesto2.CTD_COR_NUMERO = Val(txtDES_NUMERO.Text) + 1
            Compuesto2.USU_ID = SessionService.UserId
            Compuesto2.CTD_FEC_GRAB = Now
            Compuesto2.CTD_ESTADO = 1
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
                    ''''''''''''''''''''''
                    Try
                        'Mensaje de Ricky, solo para maestro y sodimac cuando la direccion de entrega es diferente
                        Dim Doc As Documentos
                        Doc = BCDOC.GetById(Compuesto.TDO_ID_DOC, Compuesto.DTD_ID_DOC, Compuesto.DES_SERIE_DOC, Compuesto.DES_NUMERO_DOC)
                        If Doc IsNot Nothing Then
                            If Doc.PER_ID_CLI = "003226" Or Doc.PER_ID_CLI = "000340" Then
                                Dim flag As Boolean = False
                                For Each mDir In Doc.Personas3.DireccionesPersonas
                                    If Compuesto.DIR_ID_ENT <> mDir.DIR_ID Then
                                        flag = True
                                    End If
                                Next
                                If flag = True Then
                                    MessageBox.Show("Deben de traerse todos los documentos de la Guia.")
                                End If

                            End If
                        End If
                    Catch ex As Exception

                    End Try
                    ''''''''''''''''''''''''''
                    resp.rM = Compuesto.ColocarErrores(txtTDO_ID, Compuesto.VerificarDatos("TDO_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTD_ID, Compuesto.VerificarDatos("DTD_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtCCT_ID, Compuesto.VerificarDatos("CCT_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpDES_FEC_EMI, Compuesto.VerificarDatos("DES_FEC_EMI"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpDES_FEC_TRA, Compuesto.VerificarDatos("DES_FEC_TRA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPVE_ID, Compuesto.VerificarDatos("PVE_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtALM_ID, Compuesto.VerificarDatos("ALM_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDES_SERIE, Compuesto.VerificarDatos("DES_SERIE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDES_NUMERO, Compuesto.VerificarDatos("DES_NUMERO"), ErrorProvider1)

                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaSalida, _
                             BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                            resp.rM = Compuesto.ColocarErrores(txtFLE_ID, Compuesto.VerificarDatos("FLE_ID"), ErrorProvider1)
                        Case BCVariablesNames.ProcesosDespacho.GuiaDespacho, _
                             BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                            'If Compuesto.DES_TIPO_GUIA <> 2 Then
                            '    MessageBox.Show("Hola")
                            'End If
                            resp.rM = Compuesto.ColocarErrores(txtTDO_ID_DOC, Compuesto.VerificarDatos("TDO_ID_DOC"), ErrorProvider1)
                            resp.rM = Compuesto.ColocarErrores(txtDTD_ID_DOC, Compuesto.VerificarDatos("DTD_ID_DOC"), ErrorProvider1)
                            resp.rM = Compuesto.ColocarErrores(txtDES_SERIE_DOC, Compuesto.VerificarDatos("DES_SERIE_DOC"), ErrorProvider1)
                            resp.rM = Compuesto.ColocarErrores(txtDES_NUMERO_DOC, Compuesto.VerificarDatos("DES_NUMERO_DOC"), ErrorProvider1)

                            Select Case txtDOC_TIPO_LISTA.Text
                                Case BCVariablesNames.TipoPuntoVenta.Planta, _
                                     BCVariablesNames.TipoPuntoVenta.Punto
                                    resp.rM = Compuesto.ColocarErrores(txtFLE_ID, Compuesto.VerificarDatos("FLE_ID"), ErrorProvider1)
                                Case Else
                                    resp.rM = Compuesto.ColocarErrores(txtDIR_ID_ENT, Compuesto.VerificarDatos("DIR_ID_ENT"), ErrorProvider1)
                                    resp.rM = ValidarZonaFlete(resp.rM)
                                    resp.rM = ValidarDIR_ID_ENT(resp.rM)
                            End Select
                            resp.rM = Compuesto.ColocarErrores(txtMON_ID, Compuesto.VerificarDatos("MON_ID"), ErrorProvider1)
                        Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion, _
                             BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                            resp.rM = ValidarDIR_ID_ENT(resp.rM)
                            'resp.rM = Compuesto.ColocarErrores(txtDIR_ID_ENT, Compuesto.VerificarDatos("DIR_ID_ENT"), ErrorProvider1)
                            resp.rM = Compuesto.ColocarErrores(txtMON_ID, Compuesto.VerificarDatos("MON_ID"), ErrorProvider1)
                            resp.rM = Compuesto.ColocarErrores(txtFLE_ID, Compuesto.VerificarDatos("FLE_ID"), ErrorProvider1)
                    End Select

                    resp.rM = Compuesto.ColocarErrores(txtPLA_ID, Compuesto.VerificarDatos("PLA_ID"), ErrorProvider1)
                    If ErrorProvider1.GetError(tcoDirecciones) = "" Then
                        resp.rM = Compuesto.ColocarErrores(tcoDirecciones, Compuesto.VerificarDatos("PLA_ID"), ErrorProvider1)
                    End If

                    resp.rM = Compuesto.ColocarErrores(txtDES_MONTO_FLETE, Compuesto.VerificarDatos("DES_MONTO_FLETE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(pnCuerpo, Compuesto.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(btnImagen, Compuesto.VerificarDatos("DES_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboDES_ESTADO, Compuesto.VerificarDatos("DES_ESTADO"), ErrorProvider1)

                    resp.rM = FiltrarSeleccionarValidarElementos(3, resp.rM)
                    resp.rM = FiltrarSeleccionarValidarElementosDES_TIPO_GUIA(3, resp.rM)

                    resp.rM = ValidarHoraFechaEmision(resp.rM)
                    resp.rM = ValidarFechaEmisionFechaTraslado(resp.rM)
                Case "Detalle"
                    resp.rM = Compuesto1.ColocarErrores(dgvDetalle, _
                    Compuesto1.VerificarDatos("TDO_ID",
                    "DTD_ID",
                    "DDE_SERIE",
                    "DDE_NUMERO",
                    "DDE_ITEM",
                    "ART_ID_IMP",
                    "ART_ID_KAR",
                    "DDE_CANTIDAD",
                    "USU_ID",
                    "DDE_FEC_GRAB",
                    "DDE_ESTADO"), _
                    ErrorProvider1)
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

            If Trim(txtFLE_ID.Text) = "" Then
                ErrorProvider1.SetError(txtFLE_ID, "Ingrese el código de zona.")
                ValidarZonaFlete = False
            End If
            Return ValidarZonaFlete
        End Function
        Private Function ValidarFechaEmisionFechaTraslado(ByVal vEstado As Boolean)
            ValidarFechaEmisionFechaTraslado = vEstado
            Dim vFechaEmision As Date
            Dim vFechaTraslado As Date
            Dim vFechaEmisionCadena As String
            Dim vFechaTrasladoCadena As String
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    dtpDES_FEC_TRA.Value = dtpDES_FEC_EMI.Value
                Case Else
            End Select

            vFechaEmisionCadena = Strings.Left(dtpDES_FEC_EMI.Text, 10)
            vFechaTrasladoCadena = Strings.Left(dtpDES_FEC_TRA.Text, 10)

            vFechaEmision = CDate(vFechaEmisionCadena)
            vFechaTraslado = CDate(vFechaTrasladoCadena)
            If vFechaEmision > vFechaTraslado Then
                ErrorProvider1.SetError(dtpDES_FEC_TRA, "La fecha de traslado debe ser igual o  mayor a la fecha de emisión")
                ValidarFechaEmisionFechaTraslado = False
            End If
            Return ValidarFechaEmisionFechaTraslado
        End Function

        Private Function ValidarHoraFechaEmision(ByVal vEstado As Boolean)
            ValidarHoraFechaEmision = vEstado
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosDespacho.CronogramaDespacho
                    Dim vFechaServidor As DateTime
                    vFechaServidor = IBCMaestro.EjecutarVista("spFechaHoraServidor")
                    If dtpDES_FEC_EMI.Value < vFechaServidor Then
                        ErrorProvider1.SetError(dtpDES_FEC_EMI, "Ingrese una hora correcta para el cronograma de despacho")
                        ValidarHoraFechaEmision = False
                    End If
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
            FiltradoTablaPrincipal()
            'Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & _
            '                          "' And PVE_ID='" & pPVE_ID & _
            '                          "' And DTD_ID='" & pDTD_ID & "'"
        End Sub
        Private Sub InicializarOrmDetalle()
            'Compuesto1 = Nothing
            'Compuesto1 = New Ladisac.BE.DetalleDespachos
        End Sub

        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            txtDOC_TIPO_LISTA.BackColor = Drawing.Color.Aqua
            txtDIR_DESCRIPCION_ENT.BackColor = Drawing.Color.White
            txtDIR_REFERENCIA_ENT.BackColor = Drawing.Color.White
            txtDIR_DESCRIPCION_ENT.ForeColor = System.Drawing.Color.Red
            txtDIR_REFERENCIA_ENT.ForeColor = System.Drawing.Color.Red

            Dim vCadenaFiltrado As String = ""
            FiltradoTablaPrincipal()
            'Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & _
            '                          "' And PVE_ID='" & pPVE_ID & _
            '                          "' And DTD_ID='" & pDTD_ID & "'"
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


                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaSalida
                            EtxtART_ID_KAR.pOOrm.CadenaFiltrado = " And TIP_ID in (select TIP_ID " & _
                                                                        " from vwRolAlmacenTipoArticulos " & _
                                                                        " where ALM_ID in ('" & txtALM_ID.Text & "') and " & _
                                                                              " TIP_ID in (select TIP_ID from vwRolAlmacenTipoArticulos where ALM_ID in ('" & txtALM_ID.Text & "')))"


                        Case BCVariablesNames.ProcesosDespacho.GuiaDespacho
                            EtxtART_ID_KAR.pOOrm.CadenaFiltrado = " And TIP_ID in (select TIP_ID " & _
                                                                         " from vwRolAlmacenTipoArticulos " & _
                                                                         " where ALM_ID in ('" & txtALM_ID.Text & "') and " & _
                                                                               " TIP_ID in (select TIP_ID from vwRolAlmacenTipoArticulos where ALM_ID in ('" & txtALM_ID.Text & "')))"

                        Case Else

                    End Select

                Case 5 ' CtaCte
                    vProcesandoJalarPrimerArticuloDespachar = False
                Case 6 ' Personas - Cliente
                    VerificarDatosCliente()
                    LLamarDocumentoCliente()
                Case 7 ' Documentos - Ventas boletas, Ventas facturas
                    FiltrarDireccionDelCliente()
                    FiltroDTD_ID_DOC()
                    LlamadaSaldosArticuloDocumento()
                    'SaldosArticuloDocumento()
                    'JalarPrimerArticuloDespachar()

                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion, _
                            BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                        Case Else
                            LlamadaSaldosMontoDocumento()
                            'SaldosMontoDocumento()
                    End Select

                    ProcesarLugarLLegada()
                Case 10 ' Personas - Recepciona
                    vCadenaFiltrado = " And PER_ID='" & txtPER_ID_REC.Text & "'"
                    EtxtDIR_ID_ENT_REC.pOOrm.CadenaFiltrado = vCadenaFiltrado
                    If txtPER_ID_REC.Text.Trim = "" Then
                        vCadenaFiltrado = ""
                    End If
                    EtxtTDP_ID_REC.pOOrm.CadenaFiltrado = vCadenaFiltrado
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
            'txtDTD_ID_DOC.BackColor = System.Drawing.Color.White
            'Dim ctl As Control
            'Dim ctlTXT As TextBox

            'ctlTXT = CType(ctl, TextBox)
            'ctlTXT = txtDTD_ID_DOC
            'ctlTXT.BackColor = System.Drawing.Color.White
            'ctlTXT.ForeColor = System.Drawing.Color.Red
            'ctlTXT.Enabled = False
            'ctlTXT.ReadOnly = True

            'txtDTD_ID_DOC = ctlTXT
            'txtDTD_ID_DOC.Enabled = False
            'txtDTD_ID_DOC.ReadOnly = True

            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False


            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    dtpDES_FEC_EMI.Enabled = True
                Case Else
                    dtpDES_FEC_EMI.Enabled = False
            End Select


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
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load ")
            End Try
        End Sub
        Private Sub AdicionarElementoCombosEdicion()
            BuscarFormatos(EcboDES_ESTADO, Compuesto, cboDES_ESTADO, 0)
            FiltrarSeleccionarValidarElementos(1, True)

            BuscarFormatos(EcboDES_TIPO_GUIA, Compuesto, cboDes_Tipo_Guia, 0)
            FiltrarSeleccionarValidarElementosDES_TIPO_GUIA(1, True)
        End Sub
        Private Sub FiltradoTablaPrincipal()
            Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & "'" & _
                                       " And PVE_ID In (select PVE_ID from Mae.PuntoVentaDatosUsuarios where DAU_ID = (SELECT DAU_ID FROM vwDatosUsuarios WHERE USU_ID='" & SessionService.UserId & "')) " & _
                                       " And DTD_ID='" & pDTD_ID & "'"
        End Sub
        Private Sub NombresFormulariosControles()
            FiltradoTablaPrincipal()
            'Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & _
            '                          "' And PVE_ID='" & pPVE_ID & _
            '                          "' And DTD_ID='" & pDTD_ID & "'"

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
            EtxtALM_ID.pOOrm.CadenaFiltrado = " And PVE_ID='" & pPVE_ID & "' AND RPA_ESTADO='ACTIVO'"
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
                        Case BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                            EtxtDTD_ID_DOC.pOOrm = New Ladisac.BE.Documentos
                            EtxtDTD_ID_DOC.pComportamiento = 7
                            EtxtDTD_ID_DOC.pOrdenBusqueda = 10
                            EtxtDTD_ID_DOC.pOOrm.Vista = ""
                            EtxtDTD_ID_DOC.pOOrm.pBuscarRegistros = False
                            EtxtDTD_ID_DOC.pOOrm.Vista = "BuscarRegistrosParaDespachosDevolucionesDesdeDistribuidora"
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
            EtxtALM_ID_LLEGADA.pOrdenBusqueda = 18
            EtxtALM_ID_LLEGADA.pOOrm.CadenaFiltrado = " And PVE_ID<>'" & pPVE_ID & "' AND RPA_ESTADO='ACTIVO'"
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
        End Sub
        Private Sub CadenaFiltradoDTD_ID_DOC()
            EtxtDTD_ID_DOC.pOOrm.vPER_ID_CLI = txtPER_ID_CLI.Text
            EtxtDTD_ID_DOC.pOOrm.vPER_ID_VEN = txtPER_ID_VEN1.Text
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
                Case BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
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

            dgvArticulosDocumento.AllowUserToAddRows = False
            dgvArticulosDocumento.AllowUserToDeleteRows = False
            dgvArticulosDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvArticulosDocumento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvArticulosDocumento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvArticulosDocumento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            dgvSaldosMontoDocumento.AllowUserToAddRows = False
            dgvSaldosMontoDocumento.AllowUserToDeleteRows = False
            dgvSaldosMontoDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvSaldosMontoDocumento.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvSaldosMontoDocumento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvSaldosMontoDocumento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
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
                Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia, BCVariablesNames.ProcesosDespacho.GuiaSalida
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
                    Select Case pDTD_ID 'hay que ver si realmente es aqui donde debe de estar este "Select Case"
                        Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                            FiltrarCampos(4)
                    End Select
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
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaDespacho
                    If otxt.pBusqueda Then
                        MetodoBusquedaDato(texto, BusquedaDirecta, otxt)
                    End If
                    Select Case NameCampo
                        Case ""
                            KeysTab(1)
                    End Select
                Case Else
                    If otxt.pTexto1 <> otxt.pTexto2 Then
                        If otxt.pBusqueda Then
                            MetodoBusquedaDato(texto, BusquedaDirecta, otxt)
                        End If
                        Select Case NameCampo
                            Case ""
                                KeysTab(1)
                        End Select
                    End If
            End Select
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
                Case "txtDTD_ID_DOC"
                    If txtFLE_ID.Text.Trim <> "" Then MetodoBusquedaDato(txtFLE_ID.Text.Trim, True, EtxtFLE_ID, 1)
                Case "txtPER_ID_REC"
                    If pBusquedaDevolvioDatos Then
                        MetodoBusquedaDato(txtPER_ID_REC.Text.Trim & "%", True, EtxtTDP_ID_REC, 1)
                    End If
                Case "txtTDP_ID_REC"
                    If txtPER_DESCRIPCION_REC.Text.Trim = "" Then
                        If pBusquedaDevolvioDatos Then
                            MetodoBusquedaDato(txtPER_ID_REC.Text.Trim, True, EtxtPER_ID_REC)
                        End If
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
                        'If txtPER_ID_VEN1.Text = "" Then
                        'LLamarVendedor()
                        'End If
                        'If Trim(txtPER_ID_VEN1.Text) = "" Then
                        'pBuscarSeleccionaDatosDevolver = False
                        'Else
                        'pBuscarSeleccionaDatosDevolver = True
                        'If txtALM_ID.Text <> "" Then LLamarDocumentoCliente()
                        'End If
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

            FormatearCampos(txtPER_ID_VEN1, "PER_ID_VEN", EtxtPER_ID_VEN1, False)
            FormatearCampos(txtPER_ID_CLI, "PER_ID_CLI", EtxtPER_ID_CLI, False)
            FormatearCampos(txtDTD_ID_DOC, "DTD_ID_DOC", EtxtDTD_ID_DOC)

            FormatearCampos(txtFLE_ID, "FLE_ID", EtxtFLE_ID, False)

            FormatearCampos(txtDIR_ID_ENT, "DIR_ID_ENT", EtxtDIR_ID_ENT, False)

            FormatearCampos(txtPER_ID_REC, "PER_ID_REC", EtxtPER_ID_REC)
            FormatearCampos(txtTDP_ID_REC, "TDP_ID_REC", EtxtTDP_ID_REC, False)
            FormatearCampos(txtDIR_ID_ENT_REC, "DIR_ID_ENT_REC", EtxtDIR_ID_ENT_REC, False)

            FormatearCampos(txtPLA_ID, "PLA_ID", EtxtPLA_ID, False)

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
                    'Select Case pDTD_ID
                    'Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    'Case Else
                    MsgBox("Registro " & vOperacion, MsgBoxStyle.Information, Me.Text)
                    'End Select
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
            EcboDES_TIPO_GUIA = Ecbo

            EcboDES_ESTADO.pNombreCampo = "DES_ESTADO"
            cboDES_ESTADO.DropDownStyle = Ecbo.pStyle

            EcboDES_TIPO_GUIA.pNombreCampo = "DES_TIPO_GUIA"
            cboDes_Tipo_Guia.DropDownStyle = Ecbo.pStyle

        End Sub
#End Region

#Region "TextBox"

        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.GotFocus, _
            txtDTD_ID.GotFocus, _
            txtALM_ID.GotFocus, _
            txtALM_ID_LLEGADA.GotFocus, _
            txtCCT_ID.GotFocus, _
            txtPER_ID_VEN1.GotFocus, _
            txtPER_ID_CLI.GotFocus, _
            txtDTD_ID_DOC.GotFocus, _
            txtFLE_ID.GotFocus, _
            txtDIR_ID_ENT.GotFocus, _
            txtPER_ID_REC.GotFocus, _
            txtTDP_ID_REC.GotFocus, _
            txtDIR_ID_ENT_REC.GotFocus, _
            txtPLA_ID.GotFocus

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
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.LostFocus, _
                txtDTD_ID.LostFocus, _
                txtALM_ID.LostFocus, _
                txtALM_ID_LLEGADA.LostFocus, _
                txtCCT_ID.LostFocus, _
                txtPER_ID_VEN1.LostFocus, _
                txtPER_ID_CLI.LostFocus, _
                txtDTD_ID_DOC.LostFocus, _
                txtFLE_ID.LostFocus, _
                txtDIR_ID_ENT.LostFocus, _
                txtPER_ID_REC.LostFocus, _
                txtTDP_ID_REC.LostFocus, _
                txtDIR_ID_ENT_REC.LostFocus, _
                txtPLA_ID.LostFocus

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
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.Validated, _
                txtDTD_ID.Validated, _
                txtDES_NUMERO.Validated, _
                txtALM_ID.Validated, _
                txtALM_ID_LLEGADA.Validated, _
                txtCCT_ID.Validated, _
                txtPER_ID_VEN1.Validated, _
                txtPER_ID_CLI.Validated, _
                txtDTD_ID_DOC.Validated, _
                txtFLE_ID.Validated, _
                txtDIR_ID_ENT.Validated, _
                txtPER_ID_REC.Validated, _
                txtTDP_ID_REC.Validated, _
                txtDIR_ID_ENT_REC.Validated, _
                txtPLA_ID.Validated

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
                Case "txtPER_ID_VEN1"
                    txtPER_ID_VEN1.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_VEN1.Text, txtPER_ID_VEN1.MaxLength)
                    ValidarDatos(EtxtPER_ID_VEN1, txtPER_ID_VEN1)
                Case "txtPER_ID_CLI"
                    txtPER_ID_CLI.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_CLI.Text, txtPER_ID_CLI.MaxLength)
                    ValidarDatos(EtxtPER_ID_CLI, txtPER_ID_CLI)
                Case "txtDTD_ID_DOC"
                    ValidarDatos(EtxtDTD_ID_DOC, txtDTD_ID_DOC)
                Case "txtFLE_ID"
                    ValidarDatos(EtxtFLE_ID, txtFLE_ID)
                Case "txtDIR_ID_ENT"
                    ValidarDatos(EtxtDIR_ID_ENT, txtDIR_ID_ENT)
                Case "txtPER_ID_REC"
                    ValidarDatos(EtxtPER_ID_REC, txtPER_ID_REC)
                Case "txtTDP_ID_REC"
                    ValidarDatos(EtxtTDP_ID_REC, txtTDP_ID_REC, txtPER_ID_REC.Text & txtTDP_ID_REC.Text)
                Case "txtDIR_ID_ENT_REC"
                    ValidarDatos(EtxtDIR_ID_ENT_REC, txtDIR_ID_ENT_REC)
                Case "txtPLA_ID"
                    ValidarDatos(EtxtPLA_ID, txtPLA_ID)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtPVE_ID.KeyPress, _
                txtDTD_ID.KeyPress, _
                txtDES_NUMERO.KeyPress, _
                txtALM_ID.KeyPress, _
                txtALM_ID_LLEGADA.KeyPress, _
                txtCCT_ID.KeyPress, _
                txtPER_ID_VEN1.KeyPress, _
                txtPER_ID_CLI.KeyPress, _
                txtDTD_ID_DOC.KeyPress, _
                txtFLE_ID.KeyPress, _
                txtDIR_ID_ENT.KeyPress, _
                txtPER_ID_REC.KeyPress, _
                txtTDP_ID_REC.KeyPress, _
                txtDIR_ID_ENT_REC.KeyPress, _
                txtPLA_ID.KeyPress

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
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.DoubleClick, _
                txtDTD_ID.DoubleClick, _
                txtALM_ID.DoubleClick, _
                txtCCT_ID.DoubleClick, _
                txtPER_ID_VEN1.DoubleClick, _
                txtPER_ID_CLI.DoubleClick, _
                txtDTD_ID_DOC.DoubleClick, _
                txtFLE_ID.DoubleClick, _
                txtDIR_ID_ENT.DoubleClick, _
                txtPER_ID_REC.DoubleClick, _
                txtTDP_ID_REC.DoubleClick, _
                txtDIR_ID_ENT_REC.DoubleClick, _
                txtPLA_ID.DoubleClick

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    oDoubleClick(EtxtPVE_ID, txtPVE_ID, "frmPuntoVenta")
                Case "txtDTD_ID"
                    oDoubleClick(EtxtDTD_ID, txtDTD_ID, "frmTipoDocumento")
                Case "txtPER_ID_VEN1"
                    oDoubleClick(EtxtPER_ID_VEN1, txtPER_ID_VEN1, "frmPersonas_VEN")
                Case "txtPER_ID_CLI"
                    oDoubleClick(EtxtPER_ID_CLI, txtPER_ID_CLI, "frmPersonas_CLI")
                Case "txtDTD_ID_DOC"
                    oDoubleClick(EtxtDTD_ID_DOC, txtDTD_ID_DOC, "frmTipoDocumento_DOC")
                Case "txtFLE_ID"
                    oDoubleClick(EtxtFLE_ID, txtFLE_ID, "frmFletesTransportes")
                Case "txtDIR_ID_ENT"
                    oDoubleClick(EtxtDIR_ID_ENT, txtDIR_ID_ENT, "frmDireccionesPersonas")
                Case "txtPER_ID_REC"
                    oDoubleClick(EtxtPER_ID_REC, txtPER_ID_REC, "frmPersonas_REC")
                Case "txtTDP_ID_REC"
                    oDoubleClick(EtxtTDP_ID_REC, txtTDP_ID_REC, "frmDocPersonas_REC")
                Case "txtDIR_ID_ENT_REC"
                    oDoubleClick(EtxtDIR_ID_ENT, txtDIR_ID_ENT_REC, "frmDireccionesPersonas_REC")
                Case "txtPLA_ID"
                    oDoubleClick(EtxtPLA_ID, txtFLE_ID, "frmPlacas")
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
                txtPER_ID_VEN1.KeyDown, _
                txtPER_ID_CLI.KeyDown, _
                txtDTD_ID_DOC.KeyDown, _
                txtFLE_ID.KeyDown, _
                txtDIR_ID_ENT.KeyDown, _
                txtPER_ID_REC.KeyDown, _
                txtTDP_ID_REC.KeyDown, _
                txtDIR_ID_ENT_REC.KeyDown, _
                txtPLA_ID.KeyDown

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
                        Case "txtPER_ID_VEN1"
                            pBusquedaDevolvioDatos = False
                            TeclaF1(EtxtPER_ID_VEN1, txtPER_ID_VEN1)
                        Case "txtPER_ID_CLI"
                            pBusquedaDevolvioDatos = False
                            TeclaF1(EtxtPER_ID_CLI, txtPER_ID_CLI)
                        Case "txtDTD_ID_DOC"
                            TeclaF1(EtxtDTD_ID_DOC, txtDTD_ID_DOC, 999999)
                        Case "txtFLE_ID"
                            TeclaF1(EtxtFLE_ID, txtFLE_ID)
                        Case "txtDIR_ID_ENT"
                            TeclaF1(EtxtDIR_ID_ENT, txtDIR_ID_ENT)
                        Case "txtPER_ID_REC"
                            pBusquedaDevolvioDatos = False
                            TeclaF1(EtxtPER_ID_REC, txtPER_ID_REC)
                        Case "txtTDP_ID_REC"
                            If txtPER_ID_REC.Text.Trim = "" Then
                                EtxtTDP_ID_REC.pOOrm.CadenaFiltrado = " AND PER_ID IN (SELECT PER_ID FROM vwRolPersonaTipoPersona WHERE PER_CLIENTE='SI')"
                            End If
                            pBusquedaDevolvioDatos = False
                            TeclaF1(EtxtTDP_ID_REC, txtTDP_ID_REC)
                        Case "txtDIR_ID_ENT_REC"
                            TeclaF1(EtxtDIR_ID_ENT_REC, txtDIR_ID_ENT_REC)
                        Case "txtPLA_ID"
                            TeclaF1(EtxtPLA_ID, txtPLA_ID)
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
        Private Sub VerificarDatosPersonaRecepciona()
            Dim vCadenaFiltrado As String = ""
            vCadenaFiltrado = " AND PER_ID='" & txtPER_ID_REC.Text & "'"
            EtxtDIR_ID_ENT_REC.pOOrm.CadenaFiltrado = vCadenaFiltrado
            If txtPER_ID_CLI.Text.Trim = "" Then
                vCadenaFiltrado = ""
            End If
            EtxtTDP_ID_REC.pOOrm.CadenaFiltrado = vCadenaFiltrado
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
            cboSerieCorrelativo.DataSource = Nothing
            txtDES_NUMERO.Text = ""

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
                    lblPER_ID_REC.Visible = vBoolean
                    txtPER_ID_REC.Visible = vBoolean
                    txtPER_DESCRIPCION_REC.Visible = vBoolean

                    lblTDP_ID_REC.Visible = vBoolean
                    txtTDP_ID_REC.Visible = vBoolean
                    txtTDP_DESCRIPCION_REC.Visible = vBoolean
                    txtDOP_NUMERO_REC.Visible = vBoolean

                    lblDIR_ID_ENT_REC.Visible = vBoolean
                    txtDIR_ID_ENT_REC.Visible = vBoolean
                    txtDIR_DESCRIPCION_ENT_REC.Visible = vBoolean
                    txtDIR_REFERENCIA_ENT_REC.Visible = vBoolean
                    txtDIS_ID_ENT_REC.Visible = vBoolean
                    txtDIS_DESCRIPCION_ENT_REC.Visible = vBoolean
                    txtPRO_ID_ENT_REC.Visible = vBoolean
                    txtPRO_DESCRIPCION_ENT_REC.Visible = vBoolean
                    txtDEP_ID_ENT_REC.Visible = vBoolean
                    txtDEP_DESCRIPCION_ENT_REC.Visible = vBoolean
                    txtPAI_ID_ENT_REC.Visible = vBoolean
                    txtPAI_DESCRIPCION_ENT_REC.Visible = vBoolean
                Case "Documento"
                    dgvArticulosDocumento.Visible = vBoolean
                Case "Saldo"
                    dgvSaldosMontoDocumento.Visible = vBoolean
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

        Private Sub dgvArticulosDocumento_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvArticulosDocumento.CellValidated
            Select Case sender.Columns(dgvArticulosDocumento.CurrentCell.ColumnIndex).Name.ToString
                Case "cMover1"
                    cMoverTexto2 = dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, dgvArticulosDocumento.CurrentRow.Index).Value
                    ConfirmarNumero()
                    dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, _
                    dgvArticulosDocumento.CurrentRow.Index).Value = _
                    FormatearNumeros(dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, dgvArticulosDocumento.CurrentRow.Index).Value.ToString, "DDE_CANTIDAD", Compuesto1, True)

                    If CDbl(dgvArticulosDocumento.Item("cMover1", dgvArticulosDocumento.CurrentRow.Index).Value) >
                       CDbl(dgvArticulosDocumento.Item("cDDO_CANTIDAD_SALDO1", dgvArticulosDocumento.CurrentRow.Index).Value) Or _
                       CDbl(dgvArticulosDocumento.Item("cMover1", dgvArticulosDocumento.CurrentRow.Index).Value) < 0 Then
                        dgvArticulosDocumento.Item("cMover1", dgvArticulosDocumento.CurrentRow.Index).Value = 0
                    End If
                    If cMoverTexto1 <> cMoverTexto2 Then ProcesarArticulosDespacho(dgvArticulosDocumento.CurrentRow.Index)
                    cMoverTexto1 = dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, dgvArticulosDocumento.CurrentRow.Index).Value
                    cMoverTexto2 = dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, dgvArticulosDocumento.CurrentRow.Index).Value
            End Select
        End Sub
        Private Sub dgvArticulosDocumento_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvArticulosDocumento.CellEnter
            Select Case sender.Columns(dgvArticulosDocumento.CurrentCell.ColumnIndex).Name.ToString
                Case "cMover1"
                    cMoverTexto1 = dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, dgvArticulosDocumento.CurrentRow.Index).Value
            End Select
        End Sub

        Private Sub ConfirmarNumero()
            If IsNothing(dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, dgvArticulosDocumento.CurrentRow.Index).Value) Then
                dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, dgvArticulosDocumento.CurrentRow.Index).Value = 0
            Else
                If Not IsNumeric(dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, dgvArticulosDocumento.CurrentRow.Index).Value.ToString) Then
                    dgvArticulosDocumento.Item(dgvArticulosDocumento.CurrentCell.ColumnIndex, dgvArticulosDocumento.CurrentRow.Index).Value = 0
                End If
            End If
        End Sub
        Private Sub dgvArticulosDocumento_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
            Handles dgvArticulosDocumento.RowHeaderMouseDoubleClick
            ProcesarArticulosDespacho(-1)
        End Sub
        Private Sub ProcesarArticulosDespacho(ByVal vFila As Int16)
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion, _
                    BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                    AdicionarFilaDetalleGuia(vFila)
                Case Else
                    If pTIV_FORMA_VENTA = BCVariablesNames.FormaVenta.Contado Then
                        If dgvSaldosMontoDocumento.RowCount > 0 Then
                            If dgvSaldosMontoDocumento.Rows(0).Cells("cSaldo").Value > 0 Then
                                MsgBox("El documento seleccionado presenta deuda," & Chr(13) & "no se procesara la guía", MsgBoxStyle.Information, Me.Text)
                            Else
                                AdicionarFilaDetalleGuia(vFila)
                            End If
                        End If
                    Else
                        AdicionarFilaDetalleGuia(vFila)
                    End If
            End Select
        End Sub

        Private Sub AdicionarFilaDetalleGuia(ByVal vFila As Int16)
            If dgvArticulosDocumento.Rows.Count = 0 Then Exit Sub
            Dim vTDO_ID_GUI As String = Nothing
            Dim vDTD_ID_GUI As String = Nothing
            Dim vDFA_SERIE_GUI As String = Nothing
            Dim vDFA_NUMERO_GUI As String = Nothing
            If vFila = -1 Then
                If dgvArticulosDocumento.SelectedRows(0).Cells("cEstadoRegistro1").Value = 1 Then
                    If dgvArticulosDocumento.SelectedRows(0).Cells("cMover1").Value > 0 Then
                        dgvDetalle.Rows.Add(EdgvDetalle.Elementos + 1, _
                        dgvArticulosDocumento.SelectedRows(0).Cells("cART_ID_KAR1").Value.ToString(), _
                        dgvArticulosDocumento.SelectedRows(0).Cells("cART_DESCRIPCION_KAR1").Value.ToString(), _
                        0, _
                        "ACTIVO", _
                        dgvArticulosDocumento.SelectedRows(0).Cells("cART_ID_KAR1").Value.ToString(), _
                        dgvArticulosDocumento.SelectedRows(0).Cells("cART_DESCRIPCION_KAR1").Value.ToString(), _
                        0, _
                        "ACTIVO", _
                        dgvArticulosDocumento.SelectedRows(0).Cells("cMover1").Value.ToString(), _
                        "ACTIVO", _
                        False)
                        dgvArticulosDocumento.SelectedRows(0).Cells("cEstadoRegistro1").Value = 0
                        EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
                    Else
                        MsgBox("El registro seleccionado tiene valor: 0", MsgBoxStyle.Information, "Error de datos")
                    End If
                Else
                    MsgBox("El registro ya fue seleccionado...", MsgBoxStyle.Information, "Error de datos")
                End If
            Else
                If dgvArticulosDocumento.Item("cEstadoRegistro1", vFila).Value = 1 Then
                    If dgvArticulosDocumento.Item("cMover1", vFila).Value > 0 Then
                        dgvDetalle.Rows.Add(EdgvDetalle.Elementos + 1, _
                        dgvArticulosDocumento.Item("cART_ID_KAR1", vFila).Value.ToString(), _
                        dgvArticulosDocumento.Item("cART_DESCRIPCION_KAR1", vFila).Value.ToString(), _
                        0, _
                        "ACTIVO", _
                        dgvArticulosDocumento.Item("cART_ID_KAR1", vFila).Value.ToString(), _
                        dgvArticulosDocumento.Item("cART_DESCRIPCION_KAR1", vFila).Value.ToString(), _
                        0, _
                        "ACTIVO", _
                        dgvArticulosDocumento.Item("cMover1", vFila).Value.ToString(), _
                        "ACTIVO", _
                        False)
                        dgvArticulosDocumento.Item("cEstadoRegistro1", vFila).Value = 0
                        EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
                    Else
                        MsgBox("El registro seleccionado tiene valor: 0", MsgBoxStyle.Information, "Error de datos")
                    End If
                Else
                    If dgvArticulosDocumento.Item("cMover1", vFila).Value > 0 Then
                        For fila As Integer = 0 To dgvDetalle.RowCount - 1
                            If dgvDetalle.Item("cART_ID_KAR", fila).Value = dgvArticulosDocumento.Item("cART_ID_KAR1", vFila).Value Then
                                dgvDetalle.Item("cDDE_CANTIDAD", fila).Value = dgvArticulosDocumento.Item("cMover1", vFila).Value
                                'Else
                            End If
                        Next
                    End If
                    ' MsgBox("El registro ya fue seleccionado...........", MsgBoxStyle.Information, "Error de datos")
                End If
            End If
        End Sub
        Private Sub dgvDetalle_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDetalle.RowHeaderMouseDoubleClick
            EliminarFilasGrid()
        End Sub
        Private Sub EliminarFilasDetalleFactura()
            Dim vFilas As Int16 = 0
            Dim vPosActual As Integer = dgvDetalle.CurrentRow().Index
            If IsNothing(dgvDetalle.Rows(dgvDetalle.CurrentRow().Index).Cells("cART_ID_KAR").Value) Then Exit Sub
            While vFilas < dgvArticulosDocumento.RowCount
                If dgvArticulosDocumento.Rows(vFilas).Cells("cART_ID_KAR1").Value.ToString = _
                    dgvDetalle.Rows(dgvDetalle.CurrentRow().Index).Cells("cART_ID_KAR").Value.ToString Then
                    dgvArticulosDocumento.Rows(vFilas).Cells("cEstadoRegistro1").Value = 1
                End If
                vFilas += 1
            End While
        End Sub

        Private Sub FiltroDTD_ID_DOC()
            pTIV_FORMA_VENTA = Me.IBCBusqueda.FormaVentaTipoVenta(txtTIV_ID_DOC.Text)
            Select Case txtDOC_TIPO_LISTA.Text
                Case BCVariablesNames.TipoPuntoVenta.Planta, BCVariablesNames.TipoPuntoVenta.Punto
                    'ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, True)
                    ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, False)
                Case Else
                    ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, False)
            End Select
        End Sub
        Private Sub FiltroPVE_ID()
            EtxtALM_ID.pOOrm.CadenaFiltrado = " And PVE_ID='" & pPVE_ID & "' AND RPA_ESTADO='ACTIVO'"
            EtxtALM_ID_LLEGADA.pOOrm.CadenaFiltrado = " And PVE_ID<>'" & pPVE_ID & "' AND RPA_ESTADO='ACTIVO'"
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

        Private Sub btnImpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresion.Click
            If RevisarDatos(False, True) <> False Then Exit Sub
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                    Exit Sub
            End Select

            If pRegistroNuevo Then
                MsgBox("Debe grabar el documento para poder imprimirlo", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            Dim NombreDocumentoImprimir As String = ""
            Select Case Me.SessionService.NombreEmpresa
                Case "Ladrillera El Diamante SAC"
                    NombreDocumentoImprimir = "D" & txtDES_SERIE.Text & ".rpt"
                Case "Comercializadora Diamante G.E. SAC"
                    NombreDocumentoImprimir = "C" & txtDES_SERIE.Text & ".rpt"
            End Select

            'Me.Cursor = Cursors.WaitCursor

            Dim vPesoArticulo As Double = 0
            Dim vUnidadMedidaArticulo As String = ""
            Dim vTelefono As String = ""
            Dim vDocumento As String = ""
            Dim vMes As String = ""
            Dim vFormaVenta As String = ""

            Dim vDireccionPartida As String
            Dim vDistritoPartida As String
            Dim vProvinciaPartida As String
            Dim vDepartamentoPartida As String


            Dim vCliente As String
            Dim vDireccionEntrega As String
            Dim vDistritoEntrega As String
            Dim vProvinciaEntrega As String
            Dim vDepartamentoEntrega As String
            Dim vDocumentoIdentidad As String
            Dim vTipoEntregaProducto As String
            Dim vDatosClienteCompra As String


            Dim ReporteDocumento As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            ReporteDocumento = New CrystalDecisions.CrystalReports.Engine.ReportDocument

            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosDespacho.GuiaDespacho, _
                    BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora, _
                    BCVariablesNames.ProcesosDespacho.GuiaSalida, _
                    BCVariablesNames.ProcesosDespacho.GuiaTransferencia, _
                    BCVariablesNames.ProcesosDespacho.GuiaDevolucion, _
                    BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                    If txtDTD_ID.Text = BCVariablesNames.ProcesosDespacho.GuiaTransferencia Then
                        vDireccionPartida = txtALM_DIRECCION.Text
                        vDepartamentoPartida = txtDEP_DESCRIPCION_ALM.Text
                        vProvinciaPartida = txtPRO_DESCRIPCION_ALM.Text
                        vDistritoPartida = txtDIS_DESCRIPCION_ALM.Text

                        vCliente = Me.SessionService.NombreEmpresa
                        vDireccionEntrega = txtALM_DIRECCION_LLEGADA.Text
                        vDepartamentoEntrega = txtDEP_DESCRIPCION_ALM_LLEGADA.Text
                        vProvinciaEntrega = txtPRO_DESCRIPCION_ALM_LLEGADA.Text
                        vDistritoEntrega = txtDIS_DESCRIPCION_ALM_LLEGADA.Text
                        vDocumentoIdentidad = Me.SessionService.RUCEmpresa

                    ElseIf txtDTD_ID.Text = BCVariablesNames.ProcesosDespacho.GuiaSalida Then
                        vDireccionPartida = txtALM_DIRECCION.Text
                        vDepartamentoPartida = txtDEP_DESCRIPCION_ALM.Text
                        vProvinciaPartida = txtPRO_DESCRIPCION_ALM.Text
                        vDistritoPartida = txtDIS_DESCRIPCION_ALM.Text

                        vCliente = Me.SessionService.NombreEmpresa
                        vDireccionEntrega = txtALM_DIRECCION_LLEGADA.Text
                        vDepartamentoEntrega = txtDEP_DESCRIPCION_ALM_LLEGADA.Text
                        vProvinciaEntrega = txtPRO_DESCRIPCION_ALM_LLEGADA.Text
                        vDistritoEntrega = txtDIS_DESCRIPCION_ALM_LLEGADA.Text
                        vDocumentoIdentidad = Me.SessionService.RUCEmpresa

                        If cboDes_Tipo_Guia.Text.Contains("CONSIGNACION") Then
                            vCliente = txtPER_DESCRIPCION_REC.Text
                            vDocumentoIdentidad = txtDOP_NUMERO_REC.Text
                            vDireccionEntrega = txtDIR_DESCRIPCION_ENT_REC.Text
                            vDepartamentoEntrega = txtDEP_DESCRIPCION_ENT_REC.Text
                            vProvinciaEntrega = txtPRO_DESCRIPCION_ENT_REC.Text
                            vDistritoEntrega = txtDIS_DESCRIPCION_ENT_REC.Text
                        End If

                    ElseIf txtDTD_ID.Text = BCVariablesNames.ProcesosDespacho.GuiaDevolucion Or _
                        txtDTD_ID.Text = BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora Then

                        If txtDTD_ID.Text = BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora Then
                            vDatosClienteCompra = "Cliente: " & "Comercializadora Diamante G.E. SAC" & ", RUC: " & "20558363291"
                        Else
                            vDatosClienteCompra = ""
                        End If

                        vDireccionPartida = txtDIR_DESCRIPCION_ENT.Text
                        vDepartamentoPartida = txtDEP_DESCRIPCION_ENT.Text
                        vProvinciaPartida = txtPRO_DESCRIPCION_ENT.Text
                        vDistritoPartida = txtDIS_DESCRIPCION_ENT.Text

                        vCliente = Me.SessionService.NombreEmpresa
                        vDireccionEntrega = txtALM_DIRECCION.Text
                        vDepartamentoEntrega = txtDEP_DESCRIPCION_ALM.Text
                        vProvinciaEntrega = txtPRO_DESCRIPCION_ALM.Text
                        vDistritoEntrega = txtDIS_DESCRIPCION_ALM.Text
                        vDocumentoIdentidad = Me.SessionService.RUCEmpresa
                    Else

                        If txtDTD_ID.Text = BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora Then
                            vDatosClienteCompra = "Cliente: " & "Comercializadora Diamante G.E. SAC" & ", RUC: " & "20558363291"
                        Else
                            vDatosClienteCompra = ""
                        End If

                        vDireccionPartida = txtALM_DIRECCION.Text
                        vDepartamentoPartida = txtDEP_DESCRIPCION_ALM.Text
                        vProvinciaPartida = txtPRO_DESCRIPCION_ALM.Text
                        vDistritoPartida = txtDIS_DESCRIPCION_ALM.Text

                        vCliente = txtPER_DESCRIPCION_CLI.Text
                        vDireccionEntrega = txtDIR_DESCRIPCION_ENT.Text
                        vDepartamentoEntrega = txtDEP_DESCRIPCION_ENT.Text
                        vProvinciaEntrega = txtPRO_DESCRIPCION_ENT.Text
                        vDistritoEntrega = txtDIS_DESCRIPCION_ENT.Text
                        vDocumentoIdentidad = txtDOP_NUMERO_CLI.Text
                    End If

                    Try


                        Select Case txtDTD_ID.Text
                            Case BCVariablesNames.ProcesosDespacho.GuiaSalida
                                ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\GuiaSalida" & NombreDocumentoImprimir)
                            Case Else
                                ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\GuiaDespacho" & NombreDocumentoImprimir)
                        End Select

                    Catch ex As Exception

                        Select Case txtDTD_ID.Text
                            Case BCVariablesNames.ProcesosDespacho.GuiaSalida
                                ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\GuiaSalida.rpt")
                            Case Else
                                ReporteDocumento.Load(Application.StartupPath & Me.SessionService.RutaDocumentoImpresion & "\GuiaDespacho.rpt")
                        End Select
                    End Try
            End Select

            Select Case txtDOC_TIPO_LISTA.Text
                Case BCVariablesNames.TipoPuntoVenta.Planta
                    vTipoEntregaProducto = "Ent. en planta" & ", " & txtDIR_REFERENCIA_ENT.Text
                Case BCVariablesNames.TipoPuntoVenta.PlantaObra
                    vTipoEntregaProducto = "Ent. a dom. desde planta" & ", " & txtDIR_REFERENCIA_ENT.Text
                Case BCVariablesNames.TipoPuntoVenta.Punto
                    vTipoEntregaProducto = "Ent. en punto venta" & ", " & txtDIR_REFERENCIA_ENT.Text
                Case BCVariablesNames.TipoPuntoVenta.PuntoObra
                    vTipoEntregaProducto = "Ent. a dom. desde punto venta" & ", " & txtDIR_REFERENCIA_ENT.Text
            End Select

            Dim tableImprimir As New DataTable("Imprimir")
            tableImprimir.Columns.Add("DES_FEC_EMI")
            tableImprimir.Columns.Add("DES_FEC_TRA")
            tableImprimir.Columns.Add("ALM_DIRECCION")
            tableImprimir.Columns.Add("DEP_DESCRIPCION_ALM")
            tableImprimir.Columns.Add("PRO_DESCRIPCION_ALM")
            tableImprimir.Columns.Add("DIS_DESCRIPCION_ALM")
            tableImprimir.Columns.Add("PER_DESCRIPCION_CLI")
            tableImprimir.Columns.Add("DOP_NUMERO_CLI")
            tableImprimir.Columns.Add("DIR_DESCRIPCION_ENT")
            tableImprimir.Columns.Add("DEP_DESCRIPCION_ENT")
            tableImprimir.Columns.Add("PRO_DESCRIPCION_ENT")
            tableImprimir.Columns.Add("DIS_DESCRIPCION_ENT")
            tableImprimir.Columns.Add("UNT_ID_1")
            tableImprimir.Columns.Add("UNT_ID_2")
            tableImprimir.Columns.Add("PER_DESCRIPCION_VEN")
            tableImprimir.Columns.Add("ART_ID_IMP")
            tableImprimir.Columns.Add("ART_DESCRIPCION_IMP")
            tableImprimir.Columns.Add("UM_DESCRIPCION_IMP")
            tableImprimir.Columns.Add("DDE_CANTIDAD")
            tableImprimir.Columns.Add("Peso")
            tableImprimir.Columns.Add("PER_DESCRIPCION_TRA1")
            tableImprimir.Columns.Add("DOCUMENTO")
            tableImprimir.Columns.Add("TIPOLISTA")
            tableImprimir.Columns.Add("DES_SERIE")
            tableImprimir.Columns.Add("DES_NUMERO")

            For filas = 0 To dgvDetalle.Rows.Count - 1
                Select Case Month(dtpDES_FEC_TRA.Value)
                    Case 1
                        vMes = "ENERO"
                    Case 2
                        vMes = "FEBRERO"
                    Case 3
                        vMes = "MARZO"
                    Case 4
                        vMes = "ABRIL"
                    Case 5
                        vMes = "MAYO"
                    Case 6
                        vMes = "JUNIO"
                    Case 7
                        vMes = "JULIO"
                    Case 8
                        vMes = "AGOSTO"
                    Case 9
                        vMes = "SEPTIEMBRE"
                    Case 10
                        vMes = "OCTUBRE"
                    Case 11
                        vMes = "NOVIEMBRE"
                    Case 12
                        vMes = "DICIEMBRE"
                End Select

                vPesoArticulo = Me.IBCBusqueda.PesoArticulo(dgvDetalle.Rows(filas).Cells("cART_ID_IMP").Value, Year(dtpDES_FEC_TRA.Value), vMes)
                vPesoArticulo = vPesoArticulo / 1000
                vUnidadMedidaArticulo = Me.IBCBusqueda.UnidadMedidaArticulo(dgvDetalle.Rows(filas).Cells("cART_ID_IMP").Value)
                vTelefono = Me.IBCBusqueda.TelefonoPersona(txtPER_ID_CLI.Text)
                'vTelefono = Me.IBCBusqueda.OrdenCompra(txtPER_ID_CLI.Text)
                vDocumento = txtDTD_DESCRIPCION_DOC.Text & ": " & txtDES_SERIE_DOC.Text & "-" & txtDES_NUMERO_DOC.Text & "          " & "Teléfono: " & vTelefono

                vFormaVenta = Me.IBCBusqueda.FormaVentaGuiaLadrillo(txtDTD_ID.Text, txtDES_SERIE.Text, txtDES_NUMERO.Text)

                If Trim(vDOC_ORDEN_COMPRA) <> "" Then
                    vCliente &= " - O/C: " & vDOC_ORDEN_COMPRA
                End If

                tableImprimir.Rows.Add(
                               dtpDES_FEC_EMI.Text, _
                               dtpDES_FEC_TRA.Text, _
                               vDireccionPartida, _
                               vDepartamentoPartida, _
                               vProvinciaPartida, _
                               vDistritoPartida, _
                               vCliente, _
                               vDocumentoIdentidad, _
                               vDireccionEntrega, _
                               vDepartamentoEntrega, _
                               vProvinciaEntrega, _
                               vDistritoEntrega, _
                               txtUNT_ID_1.Text, _
                               txtUNT_ID_2.Text, _
                               txtPER_DESCRIPCION_VEN.Text, _
                               dgvDetalle.Rows(filas).Cells("cART_ID_IMP").Value, _
                               dgvDetalle.Rows(filas).Cells("cART_DESCRIPCION_IMP").Value, _
                               vUnidadMedidaArticulo, _
                               CDbl(dgvDetalle.Rows(filas).Cells("cDDE_CANTIDAD").Value), _
                               (vPesoArticulo) * CDbl(dgvDetalle.Rows(filas).Cells("cDDE_CANTIDAD").Value), _
                               txtPER_DESCRIPCION_TRA1.Text & " - " & txtRUC_TRA1.Text, _
                               vDocumento, _
                               vTipoEntregaProducto, _
                               txtDES_SERIE.Text, _
                               txtDES_NUMERO.Text
                                                    )
            Next

            Me.Cursor = Cursors.Default

            ReporteDocumento.SetDataSource(tableImprimir)

            'Select Case txtDTD_ID.Text
            '    Case BCVariablesNames.ProcesosDespacho.GuiaDespacho
            ReporteDocumento.DataDefinition.FormulaFields("T1").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T2").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T3").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T4").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T5").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T6").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T7").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T8").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T9").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T10").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T11").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T12").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("T13").Text = "' '"
            ReporteDocumento.DataDefinition.FormulaFields("DescripcionOtros").Text = "' '"


            If cboDes_Tipo_Guia.Text = "VENTA" Then ReporteDocumento.DataDefinition.FormulaFields("T1").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "VENTA SUJETA A CONFIRMACION DEL COMPRADOR" Then ReporteDocumento.DataDefinition.FormulaFields("T2").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "COMPRA" Then ReporteDocumento.DataDefinition.FormulaFields("T3").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "CONSIGNACION" Then ReporteDocumento.DataDefinition.FormulaFields("T4").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "DEVOLUCION" Then ReporteDocumento.DataDefinition.FormulaFields("T5").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA" Then ReporteDocumento.DataDefinition.FormulaFields("T6").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "TRASLADO DE BIENES PARA TRANSFORMACION" Then ReporteDocumento.DataDefinition.FormulaFields("T7").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "RECOJO DE BIENES TRANSFORMADOS" Then ReporteDocumento.DataDefinition.FormulaFields("T8").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "TRASLADO POR EMISOR ITINERANTE DE COMPROBANTE DE PAGO" Then ReporteDocumento.DataDefinition.FormulaFields("T9").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "TRASLADO ZONA PRIMARIA" Then ReporteDocumento.DataDefinition.FormulaFields("T10").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "IMPORTACION" Then ReporteDocumento.DataDefinition.FormulaFields("T11").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "EXPORTACION" Then ReporteDocumento.DataDefinition.FormulaFields("T12").Text = "'X'"
            If cboDes_Tipo_Guia.Text = "OTROS" Then
                ReporteDocumento.DataDefinition.FormulaFields("T13").Text = "'X'"
                ReporteDocumento.DataDefinition.FormulaFields("DescripcionOtros").Text = "'Venta a terceros'"
            End If

            'ReporteDocumento.DataDefinition.FormulaFields("FechaEmision").Text = "'" & dtpDES_FEC_EMI.Value & "'"
            'ReporteDocumento.DataDefinition.FormulaFields("FechaTraslado").Text = "'" & dtpDES_FEC_TRA.Value & "'"
            ReporteDocumento.DataDefinition.FormulaFields("Certificado").Text = "'" & txtCertificado.Text & "'"
            ReporteDocumento.DataDefinition.FormulaFields("Brevete").Text = "'" & txtPER_BREVETE_CHO.Text & "'"
            ReporteDocumento.DataDefinition.FormulaFields("DatosClienteCompra").Text = "'" & vDatosClienteCompra & "'"
            ReporteDocumento.DataDefinition.FormulaFields("Cabecera1").Text = "'" & vFormaVenta & "'"
            'ReporteDocumento.DataDefinition.FormulaFields("Placas").Text = "'" & txtPLA_ID.Text & "'"

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

            ' Forma 2
            'Dim ImprimirDocumento As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            'ImprimirDocumento = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            'ImprimirDocumento.Load("C:\Ladisac\Ladisac.Facturacion\Views\Facturación\Reportes\Boleta001.rpt")
            'ImprimirDocumento.SetDataSource(tableImprimir)
            'ImprimirDocumento.PrintToPrinter(1, False, 1, 1)
        End Sub

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
            lblPER_ID_VEN1.Enabled = vflag
            txtPER_ID_VEN1.Enabled = vflag
            txtPER_DESCRIPCION_VEN1.Enabled = vflag

            lblPER_ID_VEN1.Visible = vflag
            txtPER_ID_VEN1.Visible = vflag
            txtPER_DESCRIPCION_VEN1.Visible = vflag

            txtDEP_ID_ALM.Visible = Not vflag
            txtDEP_DESCRIPCION_ALM.Visible = Not vflag
            txtPAI_ID_ALM.Visible = Not vflag
            txtPAI_DESCRIPCION_ALM.Visible = Not vflag

            'txtPER_ID_CLI.Enabled = Not vflag
            'txtPER_ID_CLI.ReadOnly = vflag
        End Sub

        Private Sub btnProcesarCronogramaDespacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesarCronogramaDespacho.Click
            If Not pRegistroNuevo Then Exit Sub
            vProcesandoCronogramaDespacho = True
            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosDespacho.GuiaDespacho
                    EtxtTDO_ID_CRO.pOOrm.pBuscarRegistros = True
                    EtxtTDO_ID_CRO.pOOrm.CadenaFiltrado = " And TDO_ID In ('" & BCVariablesNames.ProcesosDespacho.CronogramaDespacho & "')" & _
                                                          " And PVE_ID in (select pve_id_ane from vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                                          " And cast(DES_FEC_EMI as Date) = cast('" & cMisProcedimientos.FormatoFechaGenerico(dtpDES_FEC_TRA.Value) & "' as Date) " & _
                                                          " And DES_ESTADO in ('" & BCVariablesNames.EstadoRegistro.Procesado & "','" & BCVariablesNames.EstadoRegistro.NoActivo & "')"
                    EtxtTDO_ID_CRO.pOOrm.Vista = "BuscarCronograma"
                    EtxtTDO_ID_CRO.pOOrm.pBuscarRegistros = False
                    EtxtTDO_ID_CRO.pMostrarDatosGrid = True
                    EtxtTDO_ID_CRO.pDatosBuscados = "Cronograma de despacho desde la principal"
                    MetodoBusquedaDato("", False, EtxtTDO_ID_CRO)
                Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                    EtxtTDO_ID_CRO.pOOrm.CadenaFiltrado = " And TDO_ID In ('" & BCVariablesNames.ProcesosDespacho.CronogramaDespacho & "')" & _
                                                          " And PVE_ID in (select pve_id_ane from [Distribuidora].[dbo].vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                                          " And cast(DES_FEC_EMI as Date) = cast('" & cMisProcedimientos.FormatoFechaGenerico(dtpDES_FEC_TRA.Value) & "' as Date) " & _
                                                          " And DES_ESTADO in('" & BCVariablesNames.EstadoRegistro.Procesado & "','" & BCVariablesNames.EstadoRegistro.NoActivo & "')"
                    EtxtTDO_ID_CRO.pOOrm.Vista = "BuscarCronogramaDistribuidora"
                    EtxtTDO_ID_CRO.pOOrm.pBuscarRegistros = False
                    EtxtTDO_ID_CRO.pMostrarDatosGrid = True
                    EtxtTDO_ID_CRO.pDatosBuscados = "Cronograma de despacho desde la distribuidora"
                    MetodoBusquedaDato("", False, EtxtTDO_ID_CRO)
                Case Else
                    vProcesandoCronogramaDespacho = True
                    Exit Sub
            End Select
            MetodoBusquedaDato(BCVariablesNames.CCT_ID.CxCComerciales, True, EtxtCCT_ID)
            btnImpresion.Enabled = True
        End Sub

        Private Sub btnOrdenDespacho_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrdenDespacho.Click
            If Not pRegistroNuevo Then Exit Sub
            vProcesandoCronogramaDespacho = True
            Select Case txtDTD_ID.Text
                Case BCVariablesNames.ProcesosDespacho.GuiaDespacho
                    EtxtTDO_ID_CRO.pOOrm.pBuscarRegistros = True
                    EtxtTDO_ID_CRO.pOOrm.CadenaFiltrado = " And TDO_ID In ('" & BCVariablesNames.ProcesosDespacho.CronogramaDespacho & "')" & _
                                                          " And PVE_ID in (select pve_id_ane from vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                                          " And cast(DES_FEC_EMI as Date) = cast('" & cMisProcedimientos.FormatoFechaGenerico(dtpDES_FEC_TRA.Value) & "' as Date) " & _
                                                          " And DES_ESTADO in ('" & BCVariablesNames.EstadoRegistro.Procesado & "','" & BCVariablesNames.EstadoRegistro.NoActivo & "')"
                    EtxtTDO_ID_CRO.pOOrm.Vista = "BuscarOrdenDespacho"
                    EtxtTDO_ID_CRO.pOOrm.pBuscarRegistros = False
                    EtxtTDO_ID_CRO.pMostrarDatosGrid = True
                    MetodoBusquedaDato("", False, EtxtTDO_ID_CRO)
                Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                    EtxtTDO_ID_CRO.pOOrm.CadenaFiltrado = " And TDO_ID In ('" & BCVariablesNames.ProcesosDespacho.CronogramaDespacho & "')" & _
                                                          " And PVE_ID in (select pve_id_ane from [Distribuidora].[dbo].vwpuntoventaanexo where pve_id='" & txtPVE_ID.Text & "')" & _
                                                          " And cast(DES_FEC_EMI as Date) = cast('" & cMisProcedimientos.FormatoFechaGenerico(dtpDES_FEC_TRA.Value) & "' as Date) " & _
                                                          " And DES_ESTADO in('" & BCVariablesNames.EstadoRegistro.Procesado & "','" & BCVariablesNames.EstadoRegistro.NoActivo & "')"
                    EtxtTDO_ID_CRO.pOOrm.Vista = "BuscarOrdenDespachoDistribuidora"
                    EtxtTDO_ID_CRO.pOOrm.pBuscarRegistros = False
                    EtxtTDO_ID_CRO.pMostrarDatosGrid = True
                    MetodoBusquedaDato("", False, EtxtTDO_ID_CRO)
                Case Else
                    vProcesandoCronogramaDespacho = True
                    Exit Sub
            End Select
            MetodoBusquedaDato(BCVariablesNames.CCT_ID.CxCComerciales, True, EtxtCCT_ID)
            btnImpresion.Enabled = True
        End Sub

        Private Function FiltrarSeleccionarValidarElementosDES_TIPO_GUIA(ByVal vProceso As Int16, _
                                                                        ByVal vEstado As Boolean) As Boolean
            FiltrarSeleccionarValidarElementosDES_TIPO_GUIA = vEstado
            Select Case vProceso
                Case 1 ' Filtrado 
                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion, _
                            BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                            cboDes_Tipo_Guia.Items.Remove("VENTA")
                            cboDes_Tipo_Guia.Items.Remove("VENTA SUJETA A CONFIRMACION DEL COMPRADOR")
                            cboDes_Tipo_Guia.Items.Remove("COMPRA")
                            cboDes_Tipo_Guia.Items.Remove("CONSIGNACION")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO DE BIENES PARA TRANSFORMACION")
                            cboDes_Tipo_Guia.Items.Remove("RECOJO DE BIENES TRANSFORMADOS")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO POR EMISOR ITINERANTE DE COMPROBANTE DE PAGO")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO ZONA PRIMARIA")
                            cboDes_Tipo_Guia.Items.Remove("IMPORTACION")
                            cboDes_Tipo_Guia.Items.Remove("EXPORTACION")
                            cboDes_Tipo_Guia.Items.Remove("OTROS")
                        Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho, _
                             BCVariablesNames.ProcesosDespacho.GuiaDespacho
                            cboDes_Tipo_Guia.Items.Remove("DEVOLUCION")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO DE BIENES PARA TRANSFORMACION")
                            cboDes_Tipo_Guia.Items.Remove("RECOJO DE BIENES TRANSFORMADOS")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO POR EMISOR ITINERANTE DE COMPROBANTE DE PAGO")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO ZONA PRIMARIA")
                        Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                            cboDes_Tipo_Guia.Items.Remove("VENTA")
                            cboDes_Tipo_Guia.Items.Remove("VENTA SUJETA A CONFIRMACION DEL COMPRADOR")
                            cboDes_Tipo_Guia.Items.Remove("COMPRA")
                            cboDes_Tipo_Guia.Items.Remove("CONSIGNACION")
                            cboDes_Tipo_Guia.Items.Remove("DEVOLUCION")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO DE BIENES PARA TRANSFORMACION")
                            cboDes_Tipo_Guia.Items.Remove("RECOJO DE BIENES TRANSFORMADOS")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO POR EMISOR ITINERANTE DE COMPROBANTE DE PAGO")
                            cboDes_Tipo_Guia.Items.Remove("TRASLADO ZONA PRIMARIA")
                            cboDes_Tipo_Guia.Items.Remove("IMPORTACION")
                            cboDes_Tipo_Guia.Items.Remove("EXPORTACION")
                        Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                            cboDes_Tipo_Guia.Items.Remove("VENTA")
                            cboDes_Tipo_Guia.Items.Remove("VENTA SUJETA A CONFIRMACION DEL COMPRADOR")
                            cboDes_Tipo_Guia.Items.Remove("COMPRA")
                            'cboDes_Tipo_Guia.Items.Remove("CONSIGNACION")
                            cboDes_Tipo_Guia.Items.Remove("DEVOLUCION")
                            cboDes_Tipo_Guia.Items.Remove("IMPORTACION")
                            cboDes_Tipo_Guia.Items.Remove("EXPORTACION")
                            cboDes_Tipo_Guia.Items.Remove("OTROS")
                        Case Else
                    End Select
                Case 2 ' Seleccionar Elemento Default
                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion, _
                             BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                            cboDes_Tipo_Guia.Text = "DEVOLUCION"
                        Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho, _
                             BCVariablesNames.ProcesosDespacho.GuiaDespacho
                            cboDes_Tipo_Guia.Text = "VENTA"
                        Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                            cboDes_Tipo_Guia.Text = "OTROS"
                        Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                            cboDes_Tipo_Guia.Text = "TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA"
                        Case Else
                    End Select
                Case 3 ' Validar dato seleccionado
                    Select Case pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaDevolucion, _
                            BCVariablesNames.ProcesosDespacho.GuiaDevolucionDesdeDistribuidora
                            If cboDes_Tipo_Guia.Text <> "DEVOLUCION" Then FiltrarSeleccionarValidarElementosDES_TIPO_GUIA = False
                        Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho, _
                             BCVariablesNames.ProcesosDespacho.GuiaDespacho
                            If cboDes_Tipo_Guia.Text = "DEVOLUCION" Or _
                               cboDes_Tipo_Guia.Text = "TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA" Or _
                               cboDes_Tipo_Guia.Text = "TRASLADO DE BIENES PARA TRANSFORMACION" Or _
                               cboDes_Tipo_Guia.Text = "RECOJO DE BIENES TRANSFORMADOS" Or _
                               cboDes_Tipo_Guia.Text = "TRASLADO POR EMISOR ITINERANTE DE COMPROBANTE DE PAGO" Or _
                               cboDes_Tipo_Guia.Text = "TRASLADO ZONA PRIMARIA" Then FiltrarSeleccionarValidarElementosDES_TIPO_GUIA = False
                        Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                            If cboDes_Tipo_Guia.Text <> "OTROS" Then FiltrarSeleccionarValidarElementosDES_TIPO_GUIA = False
                        Case BCVariablesNames.ProcesosDespacho.GuiaTransferencia
                            If cboDes_Tipo_Guia.Text = "VENTA" Or _
                            cboDes_Tipo_Guia.Text = "VENTA SUJETA A CONFIRMACION DEL COMPRADOR" Or _
                            cboDes_Tipo_Guia.Text = "COMPRA" Or _
                            cboDes_Tipo_Guia.Text = "DEVOLUCION" Or _
                            cboDes_Tipo_Guia.Text = "IMPORTACION" Or _
                            cboDes_Tipo_Guia.Text = "EXPORTACION" Or _
                            cboDes_Tipo_Guia.Text = "OTROS" Then FiltrarSeleccionarValidarElementosDES_TIPO_GUIA = False
                        Case Else
                    End Select
            End Select
            Return FiltrarSeleccionarValidarElementosDES_TIPO_GUIA
            'cboDes_Tipo_Guia.Text = "CONSIGNACION" Or _
        End Function

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

        'Private Sub chkVentaTercero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    If chkVentaTercero.CheckState = CheckState.Checked Then
        '        chkVentaTercero.Text = "Venta a terceros"
        '    Else
        '        chkVentaTercero.Text = "..."
        '    End If
        'End Sub

        Private Sub dtpDES_FEC_TRA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDES_FEC_TRA.ValueChanged
            If dtpDES_FEC_TRA.Value.Date > Now.Date Then
                If MessageBox.Show("La fecha es mayor a hoy, desea proceder?", "Atencion", MessageBoxButtons.YesNo) = DialogResult.No Then
                    dtpDES_FEC_TRA.Value = Now
                End If
            End If
        End Sub

        Private Sub cboDES_ESTADO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDES_ESTADO.Click, cboDES_ESTADO.MouseMove
            If Not BCParametro.ParametroGetById("PermGR").PAR_VALOR3.Contains("/" & SessionService.UserId & "/") Then
                If dtpDES_FEC_EMI.Value.Date <> Today And dtpDES_FEC_TRA.Value.Date <> Today Then
                    cboDES_ESTADO.DroppedDown = False
                Else
                    cboDES_ESTADO.DroppedDown = True
                End If
            Else
                cboDES_ESTADO.DroppedDown = True
            End If
        End Sub

        Private Sub cboDES_ESTADO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDES_ESTADO.KeyDown
            If Not BCParametro.ParametroGetById("PermGR").PAR_VALOR3.Contains("/" & SessionService.UserId & "/") Then
                If dtpDES_FEC_EMI.Value.Date <> Today Or dtpDES_FEC_TRA.Value.Date <> Today Then
                    e.SuppressKeyPress = True
                    e.Handled = True
                Else
                    e.SuppressKeyPress = False
                    e.Handled = False
                End If
            Else
                e.SuppressKeyPress = False
                e.Handled = False
            End If
        End Sub

     
    End Class
End Namespace