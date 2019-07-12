Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Tesoreria.Views
    Public Class frmTesoreria
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>

        Public Structure ProcesarImporte
            Public Importe As Double
            Public ProcesarEnviarDatos As Boolean
        End Structure
        Public Structure ProcesarMon_Id
            Public Mon_Id As String
            Public CambiarMonedaSaldo As Double
            Public VerificarMon_Id As Boolean
        End Structure
        Public Structure ProcesarImporte_1
            Public Importe As Double
            Public ContraValor As Double
            Public ProcesarEnviarDatos As Boolean
            Public Tdo_Id As String
            Public Dtd_Id As String
            Public Serie As String
            Public Numero As String
            Public PagoMasivo As Double

        End Structure

#Region "Primaria"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property IBCBusquedaDetalle As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Private eConfigurarDataGridObjeto As New MisProcedimientos.ConfigurarDataGrid
        'Private eConfigurarDataGridObjetoEntregas As New MisProcedimientos.ConfigurarDataGrid
        'Private eConfigurarDataGridObjetoOtros As New MisProcedimientos.ConfigurarDataGrid
        Private eRegistrosEliminar(1) As ElementosEliminar
        Private eRegistrosEliminarDocumento(1) As ElementosEliminarDocumento
        Private eRegistrosEliminarDocumento_1(1) As ElementosEliminarDocumento
        Private vBuscarDetalle As Boolean = True
        Private vMensajeErrorOrm As String = ""

        Private vAumentarLetraGrilla As Boolean = False

        Private pLoaded As Boolean = True
        Private pRegistroNuevo As Boolean = False
        Private pRespuestaExtraerDetalle As Int16 = 0
        Private pColeccionDatos As Collection = Nothing
        Private pComportamiento As Int32 = 0
        Private pOrdenBusqueda As Int32 = 0
        Private pDatoBusquedaConsulta As String = ""
        Private pFlagNuevo As Boolean = False

        Private pFlagGrabando As Boolean = False
        Private pFlagEliminando As Boolean = False
        Private pFlagCrearCodigo As Boolean = False
        Private pFlagDeshacer As Boolean = False
        Private pFlagVerificarRolCtaCte As Boolean = False
        Private pFlagVerificarCajaCtaCte As Boolean = True

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
        Private vItemMovimientoCajaBanco As Integer
        Private vItemKardexCtaCte As Integer
        Private vItemMovimientoCajaBancopep As Integer
        Private vItemKardexCtaCtepep As Integer

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
        Public Sub ConfigurarGrid(ByVal vMiDataGridView As DataGridView, _
                                  ByVal ConfigurarDataGrid As MisProcedimientos.ConfigurarDataGrid, _
                                  Optional ByVal vProcesarTodosDgv As Boolean = False)
            Dim vIdentificadorDgv As String

            Select Case ConfigurarDataGrid.Metodo
                Case "SoloAlgunasColumnas"
                    '*
                    ConfigurarAnchoColumnaGrid(vMiDataGridView, ConfigurarDataGrid.Array)
                Case "ElementoItem"
                    Dim vFilGrid As Int16 = 0
                    Dim vContadorDgv As Integer = 1
                    If vProcesarTodosDgv Then
                        While vContadorDgv <= 4
                            Select Case vContadorDgv
                                Case 1
                                    vMiDataGridView = dgvDetalle
                                Case 2
                                    vMiDataGridView = dgvDetalleEntregas
                                Case 3
                                    vMiDataGridView = dgvDetalleOtros
                                Case 4
                                    vMiDataGridView = dgvDetalleTransferencias
                            End Select
                            vIdentificadorDgv = ProcesarIdentificadorGrid(vMiDataGridView)
                            vFilGrid = 0
                            While (vMiDataGridView.Rows.Count() > vFilGrid)
                                With vMiDataGridView.Rows(vFilGrid)
                                    If .Cells(ConfigurarDataGrid.Columna & vIdentificadorDgv).Value > EdgvDetalle.Elementos Then
                                        EdgvDetalle.Elementos = .Cells(ConfigurarDataGrid.Columna & vIdentificadorDgv).Value  ' Búscamos el item mayor para el correlativo
                                    End If
                                End With
                                vFilGrid += 1
                            End While
                            vContadorDgv += 1
                        End While
                    Else
                        vIdentificadorDgv = ProcesarIdentificadorGrid(vMiDataGridView)
                        vFilGrid = 0
                        EdgvDetalle.Elementos = 0
                        While (vMiDataGridView.Rows.Count() > vFilGrid)
                            With vMiDataGridView.Rows(vFilGrid)
                                If .Cells(ConfigurarDataGrid.Columna & vIdentificadorDgv).Value > EdgvDetalle.Elementos Then
                                    EdgvDetalle.Elementos = .Cells(ConfigurarDataGrid.Columna & vIdentificadorDgv).Value  ' Búscamos el item mayor para el correlativo
                                End If
                            End With
                            vFilGrid += 1
                        End While
                    End If
            End Select
        End Sub
        Public Sub ConfigurarAnchoColumnaGrid(ByRef vMiDataGridView As DataGridView, ByVal vArray() As Integer)
            If vMiDataGridView.Name.ToString = "dgvDetalle" Or _
                vMiDataGridView.Name.ToString = "dgvDetalleEntregas" Or _
                vMiDataGridView.Name.ToString = "dgvDetalleOtros" Or _
                vMiDataGridView.Name.ToString = "dgvDetalleTransferencias" Then
                ReDim EdgvDetalle.Columnas(vArray.Length - 1)
                For elemento As Integer = 0 To vArray.Length - 1
                    EdgvDetalle.Columnas(elemento) = vArray(elemento).ToString
                Next elemento
            End If
        End Sub


#End Region
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
            Public Property pSeleccionarTodosEnMarcados As Boolean
            Public Property pTotalizarCampo As Boolean
            Public Property pNombreCampoTotalizar As String

            Public Property pOOrm As Object
            Public Property pFormularioConsulta As Boolean

            Public Property pComportamiento As Int16
            Public Property pOrdenBusqueda As Int16
        End Structure

        '' dgvDetalle colocado para completar MetodoBusquedaDato
        Private Sub ValidarDatos(ByRef otxt As txt, _
                                 ByRef txt As TextBox, _
                                 Optional ByVal Texto As String = "")
            With otxt
                If .pTexto1 <> .pTexto2 Then
                    .pTexto2 = txt.Text
                    If .pBusqueda Then
                        If Texto <> "" Then
                            MetodoBusquedaDato(dgvDetalle, "", Texto, True, otxt)
                        Else
                            MetodoBusquedaDato(dgvDetalle, "", txt.Text, True, otxt)
                        End If
                        TeclaF1SubLlamadas(txt.Name)
                    End If
                End If
                SubValidarDatos(otxt, txt)
            End With
        End Sub
        '' ojito
        Private Sub MetodoBusquedaDato(ByRef dgv As DataGridView, _
                                       ByVal vIdentificadorDgv As String, _
                                       ByVal vDatoBusqueda As String, _
                                       ByVal vBusquedaDirecta As Boolean, _
                                       ByVal vtxt As txt, _
                                       Optional ByVal vDgvConMarcado As Boolean = False)

            If BloquearBusquedaCampos(vtxt, dgv, vIdentificadorDgv) Then Exit Sub
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

            dgvFormulario = dgv
            pIdentificadorDgv = vIdentificadorDgv

            Me.pNombreFormularioBusqueda = frm
            If vAumentarLetraGrilla Then frm.pAumentarLetraGrilla = True
            frm.pDgvConMarcado = vDgvConMarcado
            frm.pVerificarMontoSoloNuevosRegistro = pVerificarMontoSoloNuevosRegistro
            frm.pDevolverDatosUnicoRegistro = pDevolverDatosUnicoRegistro
            frm.oOrm = vtxt.pOOrm
            frm.Comportamiento = vtxt.pComportamiento
            frm.NombreFormulario = Me
            frm.OrdenBusqueda = vOrdenBusqueda
            frm.MostrarDatosGrid = vtxt.pMostrarDatosGrid
            frm.SeleccionarTodosEnMarcados = vtxt.pSeleccionarTodosEnMarcados
            frm.TotalizarCampo = vtxt.pTotalizarCampo
            frm.NombreCampoTotalizar = vtxt.pNombreCampoTotalizar

            frm.ShowDialog()
            frm.Dispose()
            pDevolverDatosUnicoRegistro = False
        End Sub

        Private Sub MetodoBusquedaDato2(ByRef dgv As DataGridView, _
                       ByVal vIdentificadorDgv As String, _
                       ByVal vDatoBusqueda As String, _
                       ByVal vBusquedaDirecta As Boolean, _
                       ByVal vtxt As txt, _
                       Optional ByVal vDgvConMarcado As Boolean = False)

            If BloquearBusquedaCampos(vtxt, dgv, vIdentificadorDgv) Then Exit Sub
            Dim vOrdenBusqueda As Int16
            vOrdenBusqueda = vtxt.pOrdenBusqueda
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusquedaDetracciones)()
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

            dgvFormulario = dgv
            pIdentificadorDgv = vIdentificadorDgv
            Dim pNombreFormularioBusqueda2 As New frmBusquedaDetracciones
            pNombreFormularioBusqueda2 = frm
            If vAumentarLetraGrilla Then frm.pAumentarLetraGrilla = True
            frm.pDgvConMarcado = vDgvConMarcado
            frm.pVerificarMontoSoloNuevosRegistro = pVerificarMontoSoloNuevosRegistro
            frm.pDevolverDatosUnicoRegistro = pDevolverDatosUnicoRegistro
            frm.oOrm = vtxt.pOOrm
            frm.Comportamiento = vtxt.pComportamiento
            frm.NombreFormulario = Me
            frm.OrdenBusqueda = vOrdenBusqueda
            frm.MostrarDatosGrid = vtxt.pMostrarDatosGrid
            frm.ShowDialog()
            frm.Dispose()
            pDevolverDatosUnicoRegistro = False
        End Sub


        '' DgvDetalle colocado para completar MetodoBusquedaDato
        Private Sub TeclaF1(ByRef otxt As txt, ByRef txt As TextBox, ByVal Name As String)
            If otxt.pBusqueda Then
                otxt.pTexto2 = txt.Text
                ValidarDatos(otxt, txt)
                MetodoBusquedaDato(dgvDetalle, "", "", False, otxt)
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
            KeysTab(1) ' SendKeys.Send(Chr(Keys.Tab))
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
            If pDocumentoProcesandose = 1000 Then Exit Sub
            MostrarDataGridView()
            pRegistroNuevo = True
            LimpiarDatos()
            HabilitarNuevo()
            ValoresDefaultNuevo()
            BotonesEdicion("Crear registro")
            If Not FlagNuevo Then
                pFlagCrearCodigo = True
                CrearCodigoId()
                pFlagCrearCodigo = False
            Else
                HabilitarEscrituraNuevo()
            End If
            cboSerieCorrelativo.Focus()
            If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                MetodoBusquedaDato(dgvDetalle, "", txtCCC_ID.Text, True, EtxtCCC_ID)
            Else
                MetodoBusquedaDato(dgvDetalle, "", txtCCC_ID.Text, False, EtxtCCC_ID)
            End If

            BuscarCorrelativoDgv()

            ConfigurarFormulario(dgvDetalle, "", 2)
            cboSerieCorrelativo.Focus()
            txtCCC_ID.Focus()

            If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                'AgregarFilaGrid()
                Select Case tcoTipoRecibo.SelectedTab.Name
                    Case "tpaPagos"
                        'dgvDetalle.Focus()
                        'dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.RowCount - 1).Cells("cItem")
                        'SendKeys.Send("{F1}")
                End Select
            End If
        End Sub
        Public Sub EditarRegistro()
            If pDocumentoProcesandose = 1000 Then
                If Not pFlagNuevo Then
                    If Trim(pCodigoId) = "" Then
                        btnImagen.Focus()
                        Exit Sub
                    End If
                End If
                MostrarControlesConsulta()
                tsbGrabar.Enabled = False
                btnImagen.Focus()
                Exit Sub
            End If
            If Not pFlagNuevo Then If Trim(pCodigoId) = "" Then Return
            BotonesEdicion("Editar registro")
            pCCC_IDpep = txtCCC_ID.Text
            pTDO_IDpep = txtTDO_ID.Text
            pDTD_IDpep = txtDTD_ID.Text
            pTES_SERIEpep = txtTES_SERIE.Text
            pTES_NUMEROpep = txtTES_NUMERO.Text

            DeshabilitarModificar()
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
            BusquedaDatos("CancelarEdicion")
            If vDeshacerCambios Then
                If vRegistroNuevo Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    BotonesEdicion("Editar registro")
                    pCCC_IDpep = txtCCC_ID.Text
                    pTDO_IDpep = txtTDO_ID.Text
                    pDTD_IDpep = txtDTD_ID.Text
                    pTES_SERIEpep = txtTES_SERIE.Text
                    pTES_NUMEROpep = txtTES_NUMERO.Text
                End If
            Else
                BotonesEdicion("Seleccionar registro")
            End If
        End Sub
        Public Sub PrepararGuardar(ByVal vNuevo As Boolean)
            Dim vFechaServidor, vFechaDocumento As Date
            vFechaServidor = IBCMaestro.EjecutarVista("spFechaServidor")
            vFechaDocumento = dtpTES_FECHA_EMI.Value

            If vFechaDocumento > vFechaServidor Then
                MsgBox("¡Fecha de proceso erronea!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.DepositoTercero
                    Select Case SessionService.UserId
                        Case "RUVEPR", "ADMIN", "ANGEL", "IRMAG", "JGONZALES", "EYLENR", "MARZAM"

                        Case Else
                            If DateDiff(DateInterval.Day, vFechaDocumento, vFechaServidor) > 5 Then
                                MsgBox("¡Fecha de proceso no autorizado!", MsgBoxStyle.Exclamation, Me.Text)
                                Exit Sub
                            End If
                    End Select
                Case Else
            End Select

            If pDocumentoProcesandose = 1000 Then Exit Sub
            Dim vProcederImpresion As Boolean = False
            Dim vMes As String
            Select Case Month(dtpTES_FECHA_EMI.Value)
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
            If Me.IBCBusqueda.ComportamientoCierre(txtPVE_ID.Text, txtDTD_ID.Text, vMes, Year(dtpTES_FECHA_EMI.Value)) = BCVariablesNames.ComportamientoCierre.Cerrado Then
                MsgBox("ll")
                Exit Sub
            End If

            btnImagen.Focus()
            Dim bRes As Boolean = False

            If pRegistroNuevo Then
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    Case Else
                        txtTES_NUMERO.Text = Me.IBCBusqueda.CorrelativoSerie(cboSerieCorrelativo.Text, txtTDO_ID.Text)
                        ActualizarCorrelativoEnDetalle()
                End Select
            End If

            If Not pRegistroNuevo Then
                If Not RevisarDatos(True) Then
                    If vNuevo Then
                        NuevoRegistro()
                    End If
                    Return
                End If
            End If

            If Not pRegistroNuevo Then
                If pCCC_IDpep <> txtCCC_ID.Text Or _
                   pTES_SERIEpep <> txtTES_SERIE.Text Then
                    pPasandoEntregasAPagos = True
                    If pTES_SERIEpep <> txtTES_SERIE.Text Then
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.VoucherCheque
                            Case Else
                                txtTES_NUMERO.Text = Me.IBCBusqueda.CorrelativoSerie(cboSerieCorrelativo.Text, txtTDO_ID.Text)
                                ActualizarCorrelativoEnDetalle()
                        End Select
                        pActualizarCorrelativoEnModificar = True
                    Else
                        pActualizarCorrelativoEnModificar = False
                    End If
                End If
            End If

            vItemMovimientoCajaBanco = Me.IBCMovimientoCajaBanco.ItemMovimientoCajaBanco(txtCCC_ID.Text, txtTDO_ID.Text, txtDTD_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)
            vItemKardexCtaCte = Me.IBCKardexCtaCte.ItemKardexCtaCte(txtTDO_ID.Text, txtDTD_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)

            If pPasandoEntregasAPagos Then
                vItemMovimientoCajaBancopep = Me.IBCMovimientoCajaBanco.ItemMovimientoCajaBanco(pCCC_IDpep, pTDO_IDpep, pDTD_IDpep, pTES_SERIEpep, pTES_NUMEROpep)
                vItemKardexCtaCtepep = Me.IBCKardexCtaCte.ItemKardexCtaCte(pTDO_IDpep, pDTD_IDpep, pTES_SERIEpep, pTES_NUMEROpep)
            End If

            If Len(txtPRE_SERIE.Text) = 3 And Len(txtPRE_NUMERO.Text) = 10 Then
                Dim RM As Boolean = True
                If dgvDetalleEntregas.Name = "dgvDetalleEntregas" Then
                    RM = VerificarCCTEntregas(RM)
                    If RM = True Then
                        RM = VerificarTotalPrestamoPersonal(RM)
                    End If

                    If RM = True Then
                        RM = VerificarTotalPrestamoPersonalCliente(RM)
                    End If

                End If
                If RM = False Then
                    Exit Sub
                End If
            End If

            If pRegistroNuevo Then
                bRes = Ingresar()
                vProcederImpresion = True
            Else
                If pPasandoEntregasAPagos = True Then
                    bRes = Ingresar()
                Else
                    bRes = Modificar()
                End If

            End If

            pFlagGrabando = True
            If bRes Then InicializarDatos()
            pFlagGrabando = False
            If (bRes) Then
                BotonesEdicion("Seleccionar registro")
                If vNuevo Then
                    NuevoRegistro()
                End If
                Dim vSystemObject As New System.Object
                Dim vEventArgs As New System.EventArgs
                If vProcederImpresion Then Call btnImpresion_Click(vSystemObject, vEventArgs)
            End If
        End Sub
        Public Sub PrepararEliminar()
            Select Case SessionService.UserId
                Case "ADMIN"
                Case Else
                    MsgBox("¡No se puede eliminar!" + Chr(13) + Chr(13) + "Anule el documento", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
            End Select
            If pDocumentoProcesandose = 1000 Then Exit Sub
            If pCCC_IDpep <> txtCCC_ID.Text Or _
               pTES_SERIEpep <> txtTES_SERIE.Text Then
                MsgBox("¡De deshacer los cambios para poder eliminar el documento!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If
            Dim bRes As Boolean = False
            Dim oMsgBoxResult As New MsgBoxResult()
            Try
                oMsgBoxResult = MsgBox("Esta seguro de eliminar el registro", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text)
                If (oMsgBoxResult = MsgBoxResult.Yes) Then
                    bRes = EliminarRegistro()
                End If
                If (bRes) Then
                    LimpiarDatos()
                    pFlagEliminando = True
                    BusquedaDatos("PrepararEliminar")
                    pFlagEliminando = False
                    BotonesEdicion("Seleccionar registro")
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - PrepararEliminar")
            End Try
        End Sub
        '' ojito
        Public Sub Deshacercambios()
            pFlagDeshacer = True
            pFlagVerificarRolCtaCte = True
            CancelarEdicion(True)
            pFlagDeshacer = False
            pFlagVerificarRolCtaCte = False
        End Sub
        Public Sub AgregarFilaGrid()
            If pDocumentoProcesandose = 1000 Then Exit Sub
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                    Exit Sub
            End Select
            AdicionarFilasGrid()
        End Sub
        Public Sub QuitarFilaGrid()
            If pDocumentoProcesandose = 1000 Then Exit Sub
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
                        Dim vObjeto As Object
                        vObjeto = vControl
                        If vProceso Then
                            If vObjeto.checked.ToString <> vColeccion(vControl.Name.ToString).ToString Then
                                Return True
                            End If
                        Else
                            vDatosControl.Add(vObjeto.checked.ToString, vControl.Name)
                        End If
                    Else
                        If vProceso Then
                            If IsNumeric(vControl.Text) Then
                                If vControl.Name = "txtPER_ID_CLI_REC" Or _
                                   vControl.Name = "txtCCT_ID_REC" Or _
                                   vControl.Name = "txtTipoCambio" Then
                                Else
                                    Try
                                        If CDec(vControl.Text) <> CDec(vColeccion(vControl.Name.ToString).ToString) Then
                                            Return True
                                        End If
                                    Catch ex As Exception
                                        Return True
                                    End Try
                                End If
                            Else
                                If vControl.Text <> vColeccion(vControl.Name.ToString).ToString Then
                                    Return True
                                End If
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
                    If vControl.Name <> "dgvMovimientoCajaBanco" _
                       And vControl.Name <> "dgvKardexCtaCte" Then
                        'And vControl.Name <> "dgvDetalleEntregas" _
                        'And vControl.Name <> "dgvDetalleOtros" _
                        'And vControl.Name <> "dgvDetalleTransferencias" Then
                        If vProceso Then
                            Dim vObjetoOriginal As Object
                            Dim vObjetoCopia As Object
                            vObjetoOriginal = vControl
                            vObjetoCopia = vColeccion(vControl.Name.ToString)
                            If vObjetoOriginal.RowCount = 0 And vObjetoCopia.name = "" Then

                            Else
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
                            End If

                        Else
                            Dim vDataGridCopia As New System.Windows.Forms.DataGridView
                            Dim vDataGridOriginal As New System.Windows.Forms.DataGridView
                            vDataGridOriginal = vControl
                            vDataGridCopia.ColumnCount = vDataGridOriginal.ColumnCount

                            If vDataGridOriginal.RowCount > 0 Then
                                vDataGridCopia.RowCount = vDataGridOriginal.RowCount
                                With vDataGridOriginal
                                    For fila As Integer = 0 To .RowCount - 1
                                        For col As Integer = 0 To .Columns.Count - 1
                                            vDataGridCopia.Item(col, fila).Value = vDataGridOriginal.Item(col, fila).Value
                                        Next
                                    Next
                                End With
                            End If


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
        '' ojito
        Public Sub BusquedaDatos(ByVal vProceso As String)
            Try
                OrmBusquedaDatos(vProceso)
                Select Case vProceso
                    Case "CancelarEdicion"
                        If CodigoId <> "%" Then
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
                        End If
                    Case "PrepararEliminar"
                        Compuesto.CampoPrincipalValor = CodigoId & vCodigoCCC_ID & vCodigoTES_SERIE & vCodigoTES_NUMERO & vCodigoDTD_ID
                        Dim resp = Me.IBCBusqueda.RegistroAnteriorFiltro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                                         "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                                         "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                         "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar) + " & _
                                                                         "cast(" & Compuesto.CampoPrincipalQuinto & " as varchar)", _
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
                            Dim resp = Me.IBCBusqueda.PrimerRegistroFiltro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                                           "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                                           "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                           "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar) + " & _
                                                                           "cast(" & Compuesto.CampoPrincipalQuinto & " as varchar)", _
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
        Private Function Ingresar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim pProcesoEliminarpep As Boolean = True
            Dim vMensajeMostrar As Int16 = 0
            pRespuestaExtraerDetalle = 0
            Ingresar = False
            DatosCabecera()
            'ProcesarMovimientoCajaBanco() 
            If Not ProcesarMovimientoCajaBanco() Then
                Me.Cursor = Windows.Forms.Cursors.Default
                vMensajeMostrar = 1
                If MensajeOperaciones(vMensajeMostrar, "ingresado") = 1 Then Return Ingresar
                InicializarOrm()
                Return Ingresar
            End If
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    'ProcesarKardexCtaCtePlanillaRendicionCuentas()
                    If Not ProcesarKardexCtaCtePlanillaRendicionCuentas() Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        vMensajeMostrar = 1
                        If MensajeOperaciones(vMensajeMostrar, "ingresado") = 1 Then Return Ingresar
                        InicializarOrm()
                        Return Ingresar
                    End If
                Case Else
                    ProcesarKardexCtaCte()
            End Select


            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    If dgvDetalle.Rows.Count() = 0 And dgvDetalleEntregas.Rows.Count() = 0 Then
                        If dgvDetalleTransferencias.Rows.Count() = 0 Then
                            InicializarOrmDetalle()
                            If chkTES_ESTADO.Text = "ACTIVO" Then
                            Else
                                AdicionarFilas(dgvDetalleTransferencias, 1)
                                'ProcesarMovimientoCajaBanco(True)
                                If Not ProcesarMovimientoCajaBanco(True) Then
                                    Me.Cursor = Windows.Forms.Cursors.Default
                                    vMensajeMostrar = 1
                                    If MensajeOperaciones(vMensajeMostrar, "ingresado") = 1 Then Return Ingresar
                                    InicializarOrm()
                                    Return Ingresar
                                End If
                            End If
                        End If
                    End If
            End Select

            If (Validar(dgvDetalle, "Cabecera")) Then
                vMensajeMostrar = 1
                Dim a As String
                Using Scope As New System.Transactions.TransactionScope()
                    If pPasandoEntregasAPagos = True Then
                        If Not EliminarRegistropep() Then
                            Scope.Dispose()
                            pProcesoEliminarpep = False
                            vMensajeMostrar = 1
                        Else
                            pProcesoEliminarpep = True
                        End If
                    End If
                    If pProcesoEliminarpep = True Then
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
                    End If
                End Using
            Else
                vMensajeMostrar = 1
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

            vRespuestaLocal = IBC.spInsertarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.CCC_ID, Compuesto.TES_SERIE, Compuesto.TES_NUMERO, Compuesto.TES_FECHA_EMI, Compuesto.PVE_ID, Compuesto.PER_ID_CAJ, Compuesto.TES_MONTO_TOTAL, Compuesto.TES_ASIENTO, Compuesto.TES_CIERRE, Compuesto.USU_ID, Compuesto.TES_FEC_GRAB, Compuesto.TES_ESTADO)

            If vRespuestaLocal = 0 Then
                InsertarDatos = False
                Return InsertarDatos
            End If

            If Not pPasandoEntregasAPagos Then
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.VoucherCheque
                        vRespuestaLocal1 = IBCCheques.spActualizarCorrelativo(Compuesto8)
                    Case Else
                        vRespuestaLocal1 = IBCCorrelativo.spActualizarRegistro(Compuesto3)
                End Select
            Else
                If pActualizarCorrelativoEnModificar Then
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.VoucherCheque
                            vRespuestaLocal1 = IBCCheques.spActualizarCorrelativo(Compuesto8)
                        Case Else
                            vRespuestaLocal1 = IBCCorrelativo.spActualizarRegistro(Compuesto3)
                    End Select
                Else
                    vRespuestaLocal1 = 1
                End If
            End If

            If Len(txtPRE_SERIE.Text) = 3 And Len(txtPRE_NUMERO.Text) = 10 Then
                vRespuestaLocal2 = IBCPrestamo.spActualizarEnlace(txtPRE_SERIE.Text, txtPRE_NUMERO.Text, vgCCT_IDe, Compuesto)
            Else
                vRespuestaLocal2 = 1
            End If

            If vRespuestaLocal = 0 Or vRespuestaLocal1 = 0 Or vRespuestaLocal2 = 0 Then
                InsertarDatos = False
                Return InsertarDatos
            End If
            pRespuestaExtraerDetalle = ExtraerDetalle()
            InsertarDatos = (vRespuestaLocal > 0 And vRespuestaLocal1 > 0 And pRespuestaExtraerDetalle = 1)
        End Function
        Private Sub ConfigurarDatosGrabados()
            ReDim eRegistrosEliminar(1)
            ReDim eRegistrosEliminarDocumento(1)
            ReDim eRegistrosEliminarDocumento_1(1)

            Dim vFilGrid As Int16 = 0
            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    .Cells("cEstadoRegistro").Value = True
                End With
                vFilGrid += 1
            End While

            vFilGrid = 1
            While (dgvDetalleEntregas.Rows.Count() > vFilGrid)
                With dgvDetalleEntregas.Rows(vFilGrid)
                    .Cells("cEstadoRegistroe").Value = True
                End With
                vFilGrid += 1
            End While

            vFilGrid = 1
            While (dgvDetalleOtros.Rows.Count() > vFilGrid)
                With dgvDetalleOtros.Rows(vFilGrid)
                    .Cells("cEstadoRegistroo").Value = True
                End With
                vFilGrid += 1
            End While

            vFilGrid = 1
            While (dgvDetalleTransferencias.Rows.Count() > vFilGrid)
                With dgvDetalleTransferencias.Rows(vFilGrid)
                    .Cells("cEstadoRegistrot").Value = True
                End With
                vFilGrid += 1
            End While

        End Sub
        Private Function ExtraerDetalle() As Int16
            ExtraerDetalle = EliminarRegistroDetalle()
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = EliminarMovimientoCajaBanco(vItemMovimientoCajaBanco)
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = EliminarKardexCtaCte(vItemKardexCtaCte)
            If ExtraerDetalle = 0 Then Exit Function

            If Len(txtPRE_SERIE.Text) = 3 And Len(txtPRE_NUMERO.Text) = 10 Then
                ExtraerDetalle = IBCPrestamo.spActualizarEnlace(txtPRE_SERIE.Text, txtPRE_NUMERO.Text, vgCCT_IDe, Compuesto)
                If ExtraerDetalle = 0 Then Exit Function
            End If
            'If Compuesto.TES_ESTADO = 0 Then
            '    ExtraerDetalle = IBCPrestamo.spEliminarEnlace(txtPRE_SERIE.Text, txtPRE_NUMERO.Text, vgCCT_IDe, Compuesto)
            '    If ExtraerDetalle = 0 Then Exit Function
            'End If


            'ExtraerDetalle = EliminarMovimientoCajaBanco(vItemMovimientoCajaBancopep)
            'If ExtraerDetalle = 0 Then Exit Function

            'ExtraerDetalle = EliminarKardexCtaCte(vItemKardexCtaCtepep)
            'If ExtraerDetalle = 0 Then Exit Function

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
            Dim vMensajeMostrar As Int16 = 0
            pRespuestaExtraerDetalle = 0
            Modificar = False
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                    Select Case SessionService.UserId
                        Case "ADMIN", "RUVEPR"
                        Case Else
                            If chkTES_ESTADO.Text = "NO ACTIVO" Then
                                MsgBox("¡No se puede anular el documento!" + Chr(13) + Chr(13) + "Comuníquese con el área de contabilidad, para que procedan a anular el documento.", MsgBoxStyle.Exclamation, Me.Text)
                                Return Modificar
                                Exit Function
                            End If
                    End Select
                Case Else
                    Select Case SessionService.UserId
                        Case "ADMIN", "ANGEL", "GLOPEZ", "IRMAG", "RUVEPR", "NYAHUA", "EYLENR", "MARZAM"
                        Case Else
                            If chkTES_ESTADO.Text = "NO ACTIVO" Then
                                MsgBox("¡No se puede anular el documento!" + Chr(13) + Chr(13) + "Comuníquese con el área de finanzas, para que procedan a anular el documento.", MsgBoxStyle.Exclamation, Me.Text)
                                Return Modificar
                                Exit Function
                            End If
                    End Select
            End Select

            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            'Dim pProcesoEliminarpep As Boolean = True
            DatosCabecera()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    InicializarOrmDetalle()
                    If chkTES_ESTADO.Text = "ACTIVO" Then
                        'ProcesarMovimientoCajaBanco()
                        If Not ProcesarMovimientoCajaBanco() Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            vMensajeMostrar = 1
                            If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar
                            InicializarOrm()
                            Return Modificar
                        End If
                    Else
                        'ProcesarMovimientoCajaBanco(True)
                        If Not ProcesarMovimientoCajaBanco(True) Then
                            Me.Cursor = Windows.Forms.Cursors.Default
                            vMensajeMostrar = 1
                            If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar
                            InicializarOrm()
                            Return Modificar
                        End If
                    End If
                Case Else
                    'ProcesarMovimientoCajaBanco()
                    If Not ProcesarMovimientoCajaBanco() Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        vMensajeMostrar = 1
                        If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar
                        InicializarOrm()
                        Return Modificar
                    End If
            End Select

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    'ProcesarKardexCtaCtePlanillaRendicionCuentas()
                    If Not ProcesarKardexCtaCtePlanillaRendicionCuentas() Then
                        Me.Cursor = Windows.Forms.Cursors.Default
                        vMensajeMostrar = 1
                        If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar
                        InicializarOrm()
                        Return Modificar
                    End If
                Case Else
                    ProcesarKardexCtaCte()
            End Select

            If (Validar(dgvDetalle, "Cabecera")) Then
                Using Scope As New System.Transactions.TransactionScope()
                    'If pPasandoEntregasAPagos = True Then
                    '    If Not EliminarRegistropep() Then
                    '        Scope.Dispose()
                    '        pProcesoEliminarpep = False
                    '        vMensajeMostrar = 1
                    '    Else
                    '        pProcesoEliminarpep = True
                    '    End If
                    'End If
                    'If pProcesoEliminarpep = True Then
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
                    'End If
                End Using
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
            If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar
            InicializarOrm()
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean

            pRespuestaExtraerDetalle = ExtraerDetalle()
            ActualizarDatos = (Me.IBC.spActualizarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.CCC_ID, Compuesto.TES_SERIE, Compuesto.TES_NUMERO, Compuesto.TES_FECHA_EMI, Compuesto.PVE_ID, Compuesto.PER_ID_CAJ, Compuesto.TES_MONTO_TOTAL, Compuesto.TES_ASIENTO, Compuesto.TES_CIERRE, Compuesto.USU_ID, Compuesto.TES_FEC_GRAB, Compuesto.TES_ESTADO) > 0 And pRespuestaExtraerDetalle = 1)
        End Function
        Public Sub InicializarDatos()
            OrmBusquedaDatos("InicializarDatos")
            pRegistroNuevo = False
            pColeccionDatos = RevisarDatosForm(Nothing, False)
            BuscarCorrelativoDgv()
        End Sub
        Private Sub BuscarCorrelativoDgv()
            Dim vItem As Integer = 0
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    ConfigurarGrid(dgvDetalleTransferencias, "t", "ElementoItem")
                    vItem = EdgvDetalle.Elementos

                    ConfigurarGrid(dgvDetalleOtros, "o", "ElementoItem")
                    If EdgvDetalle.Elementos < vItem Then
                        EdgvDetalle.Elementos = vItem
                    Else
                        vItem = EdgvDetalle.Elementos
                    End If

                    ConfigurarGrid(dgvDetalleEntregas, "e", "ElementoItem")
                    If EdgvDetalle.Elementos < vItem Then
                        EdgvDetalle.Elementos = vItem
                    Else
                        vItem = EdgvDetalle.Elementos
                    End If

                    ConfigurarGrid(dgvDetalle, "", "ElementoItem")
                    If EdgvDetalle.Elementos < vItem Then
                        EdgvDetalle.Elementos = vItem
                    Else
                        vItem = EdgvDetalle.Elementos
                    End If
                Case Else
                    ConfigurarGrid(dgvDetalle, "", "ElementoItem", True)
            End Select
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

            vItemMovimientoCajaBanco = Me.IBCMovimientoCajaBanco.ItemMovimientoCajaBanco(txtCCC_ID.Text, txtTDO_ID.Text, txtDTD_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)
            vItemKardexCtaCte = Me.IBCKardexCtaCte.ItemKardexCtaCte(txtTDO_ID.Text, txtDTD_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)

            Using Scope As New System.Transactions.TransactionScope()
                If (ProcesarEliminarDetalle() > 0 And Me.IBC.spEliminarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.CCC_ID, Compuesto.TES_SERIE, Compuesto.TES_NUMERO) > 0) Then
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

        ' PrepararEliminar PasarEntregaAPago
        Private Function EliminarRegistropep() As Boolean
            'Me.Cursor = Windows.Forms.Cursors.WaitCursor
            'OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            Dim vMensajeMostrar As Int16 = 0

            'vItemMovimientoCajaBanco = Me.IBCMovimientoCajaBanco.ItemMovimientoCajaBanco(txtCCC_ID.Text, txtTDO_ID.Text, txtDTD_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)
            'vItemKardexCtaCte = Me.IBCKardexCtaCte.ItemKardexCtaCte(txtTDO_ID.Text, txtDTD_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)

            'vItemMovimientoCajaBancopep = Me.IBCMovimientoCajaBanco.ItemMovimientoCajaBanco(pCCC_IDpep, pTDO_IDpep, pDTD_IDpep, pTES_SERIEpep, pTES_NUMEROpep)
            'vItemKardexCtaCtepep = Me.IBCKardexCtaCte.ItemKardexCtaCte(pTDO_IDpep, pDTD_IDpep, pTES_SERIEpep, pTES_NUMEROpep)

            'Using Scope As New System.Transactions.TransactionScope()
            If (ProcesarEliminarDetallepep() > 0 And Me.IBC.spEliminarRegistro(pTDO_IDpep, pDTD_IDpep, pCCC_IDpep, pTES_SERIEpep, pTES_NUMEROpep) > 0) Then
                'Scope.Complete()
                EliminarRegistropep = True
                vMensajeMostrar = 0
            Else
                'Scope.Dispose()
                EliminarRegistropep = False
                vMensajeMostrar = 2
            End If
            'End Using
            'Me.Cursor = Windows.Forms.Cursors.Default
            'MensajeOperaciones(vMensajeMostrar, "eliminado")
            'InicializarOrm()
            Return EliminarRegistropep
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
                        resp = Me.IBCBusqueda.PrimerRegistroFiltro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalQuinto & " as varchar)", _
                                                                   Compuesto.cTabla.NombreVista, Compuesto.CadenaFiltrado)
                    Case "RegistroAnterior"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroAnteriorFiltro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                                     "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                                     "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                     "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar) + " & _
                                                                     "cast(" & Compuesto.CampoPrincipalQuinto & " as varchar)", _
                                                                     Compuesto.CampoPrincipalValor, _
                                                                     Compuesto.cTabla.NombreVista, Compuesto.CadenaFiltrado)
                    Case "RegistroSiguiente"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroSiguienteFiltro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                                      "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                                      "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                      "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar) + " & _
                                                                      "cast(" & Compuesto.CampoPrincipalQuinto & " as varchar)", _
                                                                      Compuesto.CampoPrincipalValor, _
                                                                      Compuesto.cTabla.NombreVista, Compuesto.CadenaFiltrado)
                    Case "UltimoRegistro"
                        resp = Me.IBCBusqueda.UltimoRegistroFiltro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalCuarto & " as varchar) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalQuinto & " as varchar)", _
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
        '' ojito
        Private Function ColocarTabIndex(ByRef vtabIndex As Int16) As Int16
            vtabIndex += 1
            Return vtabIndex
        End Function
        '' ojito
        Private Sub ConfigurarReadOnly(ByRef vObjeto As Object)
            If vObjeto.GetType = GetType(Windows.Forms.TextBox) Then
                vObjeto.ReadOnly = True
            End If
            vObjeto.Enabled = True
            If vObjeto.GetType = GetType(Windows.Forms.DateTimePicker) Or
                vObjeto.GetType = GetType(Windows.Forms.ComboBox) Or
                vObjeto.GetType = GetType(Windows.Forms.Button) Then
                vObjeto.Enabled = False
            End If
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
            If (Not dgvDetalleEntregas.Focused) Or _
               (Not dgvDetalleOtros.Focused) Or _
               (Not dgvDetalleTransferencias.Focused) Or _
               (Not dgvDetalle.Focused) Then
                Return (MyBase.ProcessCmdKey(msg, keyData))
            End If
            If keyData <> Keys.Enter Then
                Return (MyBase.ProcessCmdKey(msg, keyData))
            End If
            KeysTab(1) ' SendKeys.Send(Chr(Keys.Tab))
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
                If pDocumentoProcesandose = 1000 Then
                    tsbNuevo.Enabled = False
                    tsbEditar.Enabled = False
                End If
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
#Region "DataGridView"
        '' ojito
        Private Function ProcesarIdentificadorGrid(ByRef dgv As DataGridView) As String
            ProcesarIdentificadorGrid = ""
            Select Case dgv.Name.ToString
                Case "dgvDetalle"
                    ProcesarIdentificadorGrid = ""
                Case "dgvDetalleEntregas"
                    ProcesarIdentificadorGrid = "e"
                Case "dgvDetalleOtros"
                    ProcesarIdentificadorGrid = "o"
                Case "dgvDetalleTransferencias"
                    ProcesarIdentificadorGrid = "t"
                Case "dgvEntregas"
                    ProcesarIdentificadorGrid = "et"
                Case "dgvDetallePagos"
                    ProcesarIdentificadorGrid = "p"
            End Select
            Return ProcesarIdentificadorGrid
        End Function
        Private Sub dgvDetalle_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvDetalle.RowEnter, dgvDetalleEntregas.RowEnter, dgvDetalleOtros.RowEnter, dgvDetalleTransferencias.RowEnter
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(sender)

            If sender.NAME = "dgvDetalleEntregas" Then
                EtxtCCT_IDe.pBusqueda = True
                EtxtCCO_ID.pBusqueda = True
            Else
                If cboTipoRecibo.Text = "PAGOS" Then
                    EtxtCCT_IDe.pBusqueda = False
                    EtxtCCO_ID.pBusqueda = False
                End If
            End If

            If EdgvDetalle.pBloquearPk Then
                Dim vCampoPk As String = ""
                For elemento As Integer = 1 To EdgvDetalle.pArrayCamposPkDetalle.GetUpperBound(0)
                    vCampoPk = EdgvDetalle.pArrayCamposPkDetalle(elemento).ToString & vIdentificadorDgv
                    If sender.Rows(e.RowIndex).Cells(EdgvDetalle.pCampoEstadoRegistro & vIdentificadorDgv).Value Is Nothing Then
                    Else
                        If sender.Rows(e.RowIndex).Cells(EdgvDetalle.pCampoEstadoRegistro & vIdentificadorDgv).Value.ToString <> "1" Then
                            sender.Columns(vCampoPk).ReadOnly = False
                            BusquedaOnlyColumnaGrid(sender, vIdentificadorDgv, True)
                        Else
                            BusquedaOnlyColumnaGrid(sender, vIdentificadorDgv, False)
                            sender.Columns(vCampoPk).ReadOnly = True
                        End If
                    End If
                Next elemento
            End If
            VerificarBloqueoCampoCliente(sender, vIdentificadorDgv, e.RowIndex)
            FiltroDTE_IMPORTE_DOC(sender, vIdentificadorDgv)
        End Sub
#End Region
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
        Public Property IBC As Ladisac.BL.IBCTesoreria

        <Dependency()> _
        Public Property IBCDetalle As Ladisac.BL.IBCDetalleTesoreria

        <Dependency()> _
        Public Property IBCMedioPago As Ladisac.BL.IBCMedioPagoTesoreria

        <Dependency()> _
        Public Property IBCMovimientoCajaBanco As Ladisac.BL.IBCMovimientoCajaBanco

        <Dependency()> _
        Public Property IBCKardexCtaCte As Ladisac.BL.IBCKardexCtaCte

        <Dependency()> _
        Public Property IBCKardexCtaCteDetracciones As Ladisac.BL.IBCKardexCtaCteDetracciones

        <Dependency()> _
        Public Property IBCCorrelativo As Ladisac.BL.IBCCorrelativoTipoDocumento

        <Dependency()> _
        Public Property IBCCheques As Ladisac.BL.IBCCheques

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        <Dependency()> _
        Public Property IBCRolOpeCtaCte As Ladisac.BL.IBCRolOpeCtaCte

        <Dependency()> _
        Public Property IBCConsultasReportesContabilidad As Ladisac.BL.IBCConsultasReportesContabilidad

        <Dependency()> _
        Public Property IBCPrestamo As Ladisac.BL.IBCPrestamo

        Public Property dgvFormulario As New DataGridView
        Public Property pIdentificadorDgv As String = ""

        Public Property pTDO_ID As String
        Public Property pDTD_ID As String
        Public Property pPVE_ID As String
        Public Property pCCT_ID As String
        Public Property pCCC_ID As String
        Public Property pCCC_TIPO As String
        Public Property pPER_ID_CAJ As String
        Public Property pDTD_ID_DOC As String
        Public Property pPER_ID_CLI As String
        Private Property pPER_DESCRIPCION_CLI As String
        Public Property pDTD_ID_DOC_1 As String
        Public Property pPER_ID_CLI_1 As String
        Private Property pPER_DESCRIPCION_CLI_1 As String

        Public Property pCCT_IDe As String
        Public Property pCCT_DESCRIPCIONe As String
        Public Property pPER_ID_CLIe As String
        Private Property pPER_DESCRIPCION_CLIe As String

        Private Property pPasandoEntregasAPagos As Boolean = False
        Private Property pActualizarCorrelativoEnModificar As Boolean = False

        Private pCCC_IDpep As String = ""
        Private pTDO_IDpep As String = ""
        Private pDTD_IDpep As String = ""
        Private pTES_SERIEpep As String = ""
        Private pTES_NUMEROpep As String = ""

        Private pCampoBusquedaEntregasCCT_ID As String = ""
        Private pCampoBusquedaEntregasPER_ID_CLI As String = ""
        Private pCampoBusquedaEntregasCCO_ID As String = ""

        Private vDTE_CAPITAL_DOC As Double = 0
        Private vDTE_INTERES_DOC As Double = 0
        Private vDTE_GASTOS_DOC As Double = 0
        Private vDTE_IMPORTE_DOC As Double = 0

        'Public Property MonedaSistema As String
        'Public Property MonedaCambiar As String
        Public Property TipoCambioCompraMoneda As Double
        Public Property TipoCambioVentaMoneda As Double

        Public Property Movimiento As String
        Public Property Destino As String
        Public Property CodigoBanco As String
        Public Property MedioPago As String
        Public Property CodigoCheque As String
        Public Property SerieCheque As String
        Public Property NumeroCheque As String
        Public Property Diferido As String
        Public Property Recepcion As String
        Public Property Ubicacion As String
        Public Property OperacionContable As String

        Public Property pDocumentoProcesandose As Int16

        Private vColImporteDoc As String = "cDTE_IMPORTE_DOC"
        Private vColMedioPago As String = "cMPT_MEDIO_PAGO"

        ' Controlar comportamiento formulario
        Public vProcesarBusquedaDirectaDocumento As Boolean = True
        Private vBusquedaDesdePagosCobros As Boolean = False
        Public vBCVariablesNamesProcesosCtaCteLiquidacionDocumento As String = ""
        ' Controlar la clave de la tabla
        Public vCodigoCCC_ID As String = ""
        Public vCodigoTES_SERIE As String = ""
        Public vCodigoTES_NUMERO As String = ""
        Public vCodigoDTD_ID As String = ""

        ' DateTimePicker
        Private EdtpTES_FECHA_EMI As New dtp

        ' CheckBox
        Private EchkTES_ASIENTO As New chk
        Private EchkTES_ESTADO As New chk

        ' ComboBox
        Private EcboTipoRecibo As New cbo
        Private EcboCCC_TIPO As New cbo
        Private EcboTES_CIERRE As New cbo


        ' DataGridView
        Private EdgvDetalle As New dgv

        ' TextBox
        '' PK
        Private EtxtTDO_ID As New txt
        Private EtxtDTD_ID As New txt
        Private EtxtCCC_ID As New txt
        Private EtxtTES_SERIE As New txt
        Private EtxtTES_NUMERO As New txt
        Private EtxtPVE_ID As New txt
        Private EtxtPER_ID_CAJ As New txt
        Private EtxtPER_ID_CLI_REC As New txt
        Private EtxtCCT_ID_REC As New txt
        Private EtxtCCC_ID_DES As New txt
        Private EtxtMPT_NUMERO_MEDIO As New txt

        '' ojito
        Private EtxtMON_ID_CCC As New txt

        '' Texto
        '' Número
        Private EtxtTES_MONTO_TOTAL As New txt

        ' Celdas para datos tabla detalle 
        '' PK
        Private EtxtCCT_IDe As New txt
        Private EtxtCCC_ID_CLI As New txt
        Private EtxtCCO_ID As New txt
        Private EtxtCCT_ID As New txt
        Private EtxtCCT_ID_DOC As New txt
        Private EtxtCCT_ID_DOC_1 As New txt
        Private EtxtCUC_ID As New txt
        Private EtxtDTD_ID_DOC As New txt
        Private EtxtDTD_ID_ROC As New txt
        Private EtxtDTD_ID_DOC_CLI_REC As New txt
        Private EtxtDTD_ID_DOC_CLI_REC_1 As New txt

        Private EtxtDTE_IMPORTE_DOC As New txt

        ' Celdas para datos tabla detalle 
        '' PK
        Private EtxtDTD_ID_DOC_1 As New txt
        Private EtxtDTE_NUMERO As New txt
        Private EtxtDTE_SERIE As New txt
        Private EtxtMON_ID_DOC As New txt
        Private EtxtCHE_ID As New txt
        Private EtxtMON_ID_DOC_1 As New txt
        Private EtxtPER_ID_CLI As New txt
        Private EtxtPER_ID_CLI_1 As New txt
        Private EtxtTDO_ID_DOC As New txt
        Private EtxtTDO_ID_DOC_1 As New txt
        Private EtxtPER_ID_BAN As New txt



        Private pPosicionColumnaGridNombre As String
        Private pVerificarMonto As Boolean = False
        Private pVerificarMontoSoloNuevosRegistro As Boolean = True
        Private pNombreFormularioBusqueda As New Ladisac.frmBusqueda
        Private pDevolverDatosUnicoRegistro As Boolean = False

        Private vcCCT_ID As String = ""
        Private vcCCT_DESCRIPCION As String = ""
        Private vcPER_ID_CLI As String = ""
        Private vcPER_DESCRIPCION_CLI As String = ""
        Private vCCT_ID_DOC As String = ""
        Private vcTDO_ID_DOC As String = ""
        Private vcDTD_ID_DOC As String = ""
        Private vcDTE_SERIE_DOC As String = ""
        Private vcDTE_NUMERO_DOC As String = ""
        Private vMON_ID_DOC As String = ""
        Private vMON_DESCRIPCION_DOC As String = ""
        Private vDTE_FEC_VEN As Date = Nothing

        Private Compuesto As New Ladisac.BE.Tesoreria
        Private Compuesto1 As New Ladisac.BE.DetalleTesoreria
        Private Compuesto2 As New Ladisac.BE.MedioPagoTesoreria
        Private Compuesto3 As New Ladisac.BE.CorrelativoTipoDocumento
        Private Compuesto4 As New Ladisac.BE.MovimientoCajaBanco
        Private Compuesto5 As New Ladisac.BE.RolOpeCtaCte
        Private Compuesto6 As New Ladisac.BE.KardexCtaCte
        Private Compuesto7 As New Ladisac.BE.KardexCtaCteDetracciones
        Private Compuesto8 As New Ladisac.BE.Cheques
        Private Compuesto9 As New Ladisac.BE.Prestamo
        Private ErrorData As New Ladisac.BE.Tesoreria.ErrorData
        Private cMisProcedimientos As New Ladisac.MisProcedimientos

        Private vgCCT_IDe As String
        Private Structure ElementosEliminar
            Public cTDO_ID As String
            Public cDTD_ID As String
            Public cCCC_ID As String
            Public cDTE_SERIE As String
            Public cDTE_NUMERO As String
            Public cDTE_ITEM As String
            Public cPER_ID_BAN As String
            Public cMPT_SERIE_MEDIO As String
            Public cMPT_NUMERO_MEDIO As String
        End Structure
        Private Structure ElementosEliminarDocumento
            Public cTDO_ID As String
            Public cDTD_ID As String
            Public cDTE_SERIE As String
            Public cDTE_NUMERO As String
            Public cDTE_IMPORTE As Double
            Public cDTE_CONTRAVALOR As Double
            Public cMON_ID As String
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
            InicializarValores(txtPVE_ID, ErrorProvider1)
            InicializarValores(txtTDO_ID, ErrorProvider1)
            InicializarValores(txtDTD_ID, ErrorProvider1)
            InicializarValores(txtDTD_DESCRIPCION, ErrorProvider1, False)
            InicializarValores(txtCCT_ID, ErrorProvider1)
            InicializarValores(txtCCT_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtCCC_ID, ErrorProvider1)
            ' InicializarValores(cboCCC_TIPO, ErrorProvider1)
            InicializarValores(txtCCC_DESCRIPCION, ErrorProvider1)
            ' InicializarValores(cboSerieCorrelativo, ErrorProvider1)
            InicializarValores(txtTES_SERIE, ErrorProvider1)
            InicializarValores(txtTES_NUMERO, ErrorProvider1)

            InicializarValores(dtpTES_FECHA_EMI, ErrorProvider1)

            InicializarValores(txtMON_ID_CCC, ErrorProvider1)
            InicializarValores(txtMON_SIMBOLO_CCC, ErrorProvider1)
            InicializarValores(txtMON_DESCRIPCION_CCC, ErrorProvider1)

            InicializarValores(txtPER_ID_CAJ, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_CAJ, ErrorProvider1)

            InicializarValores(txtPER_ID_CLI_REC, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_CLI_REC, ErrorProvider1)

            InicializarValores(txtCCC_ID_DES, ErrorProvider1)
            InicializarValores(txtCCC_DESCRIPCION_DES, ErrorProvider1)
            InicializarValores(txtPER_ID_DES, ErrorProvider1)

            ColocarValoresDefault(chkTES_ASIENTO)
            ColocarValoresDefault(chkTES_ESTADO)

            InicializarValores(txtTES_MONTO_TOTAL, ErrorProvider1, EtxtTES_MONTO_TOTAL.pSoloNumeros, EtxtTES_MONTO_TOTAL.pSoloNumerosDecimales)

            InicializarValores(dgvDetalle, ErrorProvider1)
            InicializarValores(dgvDetalleEntregas, ErrorProvider1)
            InicializarValores(dgvDetalleOtros, ErrorProvider1)
            InicializarValores(dgvDetalleTransferencias, ErrorProvider1)
            ''InicializarValores(dgvKardexCtaCte, ErrorProvider1)
            ''InicializarValores(dgvMovimientoCajaBanco, ErrorProvider1)

            txtPRE_SERIE.Text = ""
            txtPRE_NUMERO.Text = ""

            pFlagVerificarRolCtaCte = True
            cboTipoRecibo.Text = "PAGOS"
            pFlagVerificarRolCtaCte = False
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxCComerciales
                    pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales

                    txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso
                    pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso

                Case BCVariablesNames.ProcesosCaja.CajaEgreso
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                    pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                    txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso
                    pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso

                Case BCVariablesNames.ProcesosCaja.DepositoTercero
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxCComerciales
                    pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales

                    txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.DepTerDepositoTercero
                    pDTD_ID = BCVariablesNames.ProcesosCaja.DepTerDepositoTercero

                Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxCComerciales
                    pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales

                    txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NABNotaAbonoCtaBanco
                    pDTD_ID = BCVariablesNames.ProcesosCaja.NABNotaAbonoCtaBanco

                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                    pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                    txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NCBDetraccionesNotaCargoCtaBanco
                    pDTD_ID = BCVariablesNames.ProcesosCaja.NCBDetraccionesNotaCargoCtaBanco

                Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                    pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                    txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NCBNotaCargoCtaBanco
                    pDTD_ID = BCVariablesNames.ProcesosCaja.NCBNotaCargoCtaBanco

                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                    pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                    txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.VCVoucherCheque
                    pDTD_ID = BCVariablesNames.ProcesosCaja.VCVoucherCheque

                Case BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                    pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                    txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.PlaEgrPlanillaEgreso
                    pDTD_ID = BCVariablesNames.ProcesosCaja.PlaEgrPlanillaEgreso

                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                    pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                            txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.TECBTransferenciaEntreCajas
                            pDTD_ID = BCVariablesNames.ProcesosCaja.TECBTransferenciaEntreCajas
                        Case  "frmDepositosBancarios"
                            txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.TECBDepositosBancarios
                            pDTD_ID = BCVariablesNames.ProcesosCaja.TECBDepositosBancarios
                            BloquearCajaCtaCteDestino(dgvDetalle)
                    End Select
            End Select
            pPasandoEntregasAPagos = False
            pCCC_IDpep = ""
            pTDO_IDpep = ""
            pDTD_IDpep = ""
            pTES_SERIEpep = ""
            pTES_NUMEROpep = ""

            'Movimiento = ""
            'Destino = ""
            CodigoBanco = ""
            'MedioPago = ""
            CodigoCheque = ""
            SerieCheque = ""
            NumeroCheque = ""
            'Diferido = ""
            'Recepcion = ""
            'Ubicacion = ""
            'OperacionContable = ""
            txtMontoOtros.Text = 0
            ReDim eRegistrosEliminar(1)
            ReDim eRegistrosEliminarDocumento(1)
            ReDim eRegistrosEliminarDocumento_1(1)
            vBuscarDetalle = True
            vgCCT_IDe = ""
        End Sub
        '' Siempre para nuevo registro
        Private Sub HabilitarNuevo()
            ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, False)
            ControlVisible(cboSerieCorrelativo, True)
            ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, False)
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkTES_ASIENTO)
            ColocarValoresDefault(chkTES_ESTADO)
            ProcesarGridVacio(dgvDetalle, 1)
        End Sub

        Private Sub CrearCodigoId()
            ProcesarFechaServidor()

            txtPVE_ID.Text = pPVE_ID
            EtxtPVE_ID.pOOrm.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "' and PDU_ESTADO='ACTIVO')"
            MetodoBusquedaDato(dgvDetalle, "", txtPVE_ID.Text, True, EtxtPVE_ID)

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte
            End Select

            txtTDO_ID.Text = pTDO_ID
            txtDTD_ID.Text = pDTD_ID

            MetodoBusquedaDato(dgvDetalle, "", pCCT_ID & txtTDO_ID.Text & txtDTD_ID.Text, True, EtxtDTD_ID)

            txtCCC_ID.Text = pCCC_ID
            MetodoBusquedaDato(dgvDetalle, "", txtCCC_ID.Text, True, EtxtCCC_ID)

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                    BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas, _
                    BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    txtPER_ID_CAJ.Text = pPER_ID_CAJ
                    MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CAJ.Text, True, EtxtPER_ID_CAJ)
                Case Else
            End Select

            BuscarSeries()
        End Sub

        '' Solo en el caso de que el PK de la tabla sea ingresado por el usuario manualmente
        Private Sub HabilitarEscrituraNuevo()
            ControlReadOnly(txtTES_NUMERO, False)
        End Sub
        Private Sub EditarColumnasProcesarAncho(ByRef dgv As DataGridView)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso, _
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.VoucherCheque

                    ''                      BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                    eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
                    ReDim eConfigurarDataGridObjeto.Array(0)

                    If cboTipoRecibo.Text = "PAGOS" Then
                        If pTDO_ID = BCVariablesNames.ProcesosCaja.VoucherCheque Then
                            eConfigurarDataGridObjeto.Array = {7, 11, 23, 29, 30, 31, 32, 41, 49, 50, 53, 55}
                        Else
                            eConfigurarDataGridObjeto.Array = {7, 11, 23, 29, 30, 31, 32, 33, 34, 36, 37, 41, 49, 50, 53, 55}
                        End If
                    ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                        eConfigurarDataGridObjeto.Array = {7, 11, 23, 29, 30, 31, 32, 33, 34, 36, 37, 41, 49, 50, 53, 55}
                    ElseIf cboTipoRecibo.Text = "OTROS" Then
                        eConfigurarDataGridObjeto.Array = {7, 11, 23, 29, 30, 31, 32, 33, 34, 36, 37, 41, 49, 50, 53, 55}
                    End If

                    ConfigurarGrid(dgv, eConfigurarDataGridObjeto)
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
                    ReDim eConfigurarDataGridObjeto.Array(0)
                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                            eConfigurarDataGridObjeto.Array = {7, 11, 23, 29, 30, 31, 32, 33, 34, 36, 37, 41, 49, 50, 53, 55}
                        Case "frmDepositosBancarios"
                            eConfigurarDataGridObjeto.Array = {7, 11, 29, 30, 41, 49, 50, 53, 55}
                    End Select
                    ConfigurarGrid(dgv, eConfigurarDataGridObjeto)
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
                    ReDim eConfigurarDataGridObjeto.Array(0)
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            eConfigurarDataGridObjeto.Array = {7, 29, 30, 31, 32, 33, 34, 37, 41, 49, 50, 53, 55}
                        Case "tpaEntregas"
                            eConfigurarDataGridObjeto.Array = {7, 11, 23, 24, 29, 30, 31, 32, 33, 34, 37, 53, 55}
                        Case "tpaOtros"
                            eConfigurarDataGridObjeto.Array = {7, 11, 29, 30, 31, 32, 33, 34, 37, 41, 49, 50}
                    End Select

                    ConfigurarGrid(dgv, eConfigurarDataGridObjeto)
                    '' modificado 2015-07-16
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
                    ReDim eConfigurarDataGridObjeto.Array(0)
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            eConfigurarDataGridObjeto.Array = {7, 11, 29, 30, 33, 34, 37, 49, 50, 53, 55}
                        Case "tpaEntregas"
                            If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then
                                eConfigurarDataGridObjeto.Array = {7, 11, 29, 30, 33, 34, 37, 49, 50, 55}
                            Else
                                eConfigurarDataGridObjeto.Array = {11, 29, 30, 33, 34, 37, 49, 50, 55}
                            End If

                        Case "tpaOtros"
                            eConfigurarDataGridObjeto.Array = {7, 11, 29, 30, 33, 34, 37, 49, 50}
                    End Select
                    ConfigurarGrid(dgv, eConfigurarDataGridObjeto)
                Case Else
                    eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
                    ReDim eConfigurarDataGridObjeto.Array(0)
                    eConfigurarDataGridObjeto.Array = {7, 11, 23, 24, 29, 30, 31, 32, 33, 34, 37, 41, 49, 50, 53, 55}
                    ConfigurarGrid(dgv, eConfigurarDataGridObjeto)
            End Select
        End Sub
        Private Sub MostrarAnchoColumnaGrid(ByRef dgv As DataGridView)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque
                    dgv.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                    dgv.Columns(11).DefaultCellStyle.BackColor = Drawing.Color.White

                    If cboTipoRecibo.Text = "PAGOS" Then
                    ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                        dgv.Columns(50).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        dgv.Columns(50).DefaultCellStyle.BackColor = Drawing.Color.White
                    ElseIf cboTipoRecibo.Text = "OTROS" Then
                        dgv.Columns(52).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        dgv.Columns(52).DefaultCellStyle.BackColor = Drawing.Color.White
                    End If
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    If cboTipoRecibo.Text = "PAGOS" Then
                        dgv.Columns(20).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        dgv.Columns(20).DefaultCellStyle.BackColor = Drawing.Color.White
                    ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                    ElseIf cboTipoRecibo.Text = "OTROS" Then
                    End If
                Case Else
            End Select
        End Sub

        Public Function AdicionarFilasGridDesDeBusqueda() As Boolean
            AdicionarFilasGridDesDeBusqueda = False
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        AdicionarFilas(dgvDetalle)
                        AdicionarFilasGridDesDeBusqueda = True
                    Else
                        AdicionarFilasGridDesDeBusqueda = False
                    End If
                Case BCVariablesNames.ProcesosCaja.DepositoTercero
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        AdicionarFilas(dgvDetalle)
                        AdicionarFilasGridDesDeBusqueda = True
                    Else
                        AdicionarFilasGridDesDeBusqueda = False
                    End If
                Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        AdicionarFilas(dgvDetalle)
                        AdicionarFilasGridDesDeBusqueda = True
                    Else
                        AdicionarFilasGridDesDeBusqueda = False
                    End If
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        AdicionarFilas(dgvDetalle)
                        AdicionarFilasGridDesDeBusqueda = True
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        AdicionarFilas(dgvDetalleEntregas)
                        AdicionarFilasGridDesDeBusqueda = True
                    Else
                        AdicionarFilasGridDesDeBusqueda = False
                    End If
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        AdicionarFilas(dgvDetalle)
                        AdicionarFilasGridDesDeBusqueda = True
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        AdicionarFilas(dgvDetalleEntregas)
                        AdicionarFilasGridDesDeBusqueda = True
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaTransferencias" Then
                        AdicionarFilasGridDesDeBusqueda = False
                    End If
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                            AdicionarFilasGridDesDeBusqueda = False
                        Case "frmDepositosBancarios"
                            AdicionarFilas(dgvDetalle)
                            AdicionarFilasGridDesDeBusqueda = True
                    End Select
                Case Else
                    AdicionarFilasGridDesDeBusqueda = True
                    AdicionarFilas(dgvDetalle)
            End Select
        End Function
        '' ojito
        Public Sub AdicionarFilasGrid()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        AdicionarFilas(dgvDetalle)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        AdicionarFilas(dgvDetalleEntregas)
                        MetodoBusquedaDato(dgvDetalleEntregas, ProcesarIdentificadorGrid(dgvDetalleEntregas), pCampoBusquedaEntregasCCT_ID, True, EtxtCCT_IDe)
                        MetodoBusquedaDato(dgvDetalleEntregas, ProcesarIdentificadorGrid(dgvDetalleEntregas), pCampoBusquedaEntregasPER_ID_CLI, True, EtxtPER_ID_CLI)
                        MetodoBusquedaDato(dgvDetalleEntregas, ProcesarIdentificadorGrid(dgvDetalleEntregas), pCampoBusquedaEntregasCCO_ID, True, EtxtCCO_ID)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                        AdicionarFilas(dgvDetalleOtros)
                    End If
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        Exit Sub
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        Exit Sub
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                        AdicionarFilas(dgvDetalleOtros)
                    End If
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        AdicionarFilas(dgvDetalle)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        AdicionarFilas(dgvDetalleEntregas)
                        MetodoBusquedaDato(dgvDetalleEntregas, ProcesarIdentificadorGrid(dgvDetalleEntregas), pCampoBusquedaEntregasCCT_ID, True, EtxtCCT_IDe)
                        MetodoBusquedaDato(dgvDetalleEntregas, ProcesarIdentificadorGrid(dgvDetalleEntregas), pCampoBusquedaEntregasPER_ID_CLI, True, EtxtPER_ID_CLI)
                        MetodoBusquedaDato(dgvDetalleEntregas, ProcesarIdentificadorGrid(dgvDetalleEntregas), pCampoBusquedaEntregasCCO_ID, True, EtxtCCO_ID)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                        AdicionarFilas(dgvDetalleOtros)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaTransferencias" Then
                        AdicionarFilas(dgvDetalleTransferencias)
                    End If
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                            If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                                AdicionarFilas(dgvDetalle)
                            ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                                AdicionarFilas(dgvDetalleOtros)
                            End If
                        Case "frmDepositosBancarios"
                            If Trim(txtCCC_ID_DES.Text) <> "" And _
                               Trim(txtPER_ID_DES.Text) <> "" Then
                                AdicionarFilas(dgvDetalle)
                            End If
                    End Select
                Case Else
                    AdicionarFilas(dgvDetalle)
            End Select
        End Sub

        Private Sub AdicionarFilas(ByRef dgv As DataGridView, Optional ByVal FlagAnulado As Integer = 0)
            Dim vIdentificadorDgv As String
            Dim vCCC_ID_CLI As String = ""
            Dim vCCC_DESCRIPCION_CLI As String = ""

            vDTE_CAPITAL_DOC = 0
            vDTE_INTERES_DOC = 0
            vDTE_GASTOS_DOC = 0
            vDTE_IMPORTE_DOC = 0

            Select Case FlagAnulado
                Case 0
                    vCCC_ID_CLI = ""
                    vDTE_IMPORTE_DOC = 0
                Case 1 ' Voucher - Transferencia 
                    vCCC_ID_CLI = BCVariablesNames.CCC_ID.CajaDefaul
                    vDTE_IMPORTE_DOC = 1
            End Select

            vIdentificadorDgv = ProcesarIdentificadorGrid(dgv)

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                        Case "tpaOtros"
                            ''''
                            If dgvDetalle.RowCount = 0 Then
                                MsgBox("No existen registros en el detalle de pagos", MsgBoxStyle.Information, "Error de datos")
                                Exit Sub
                            End If
                            ''''
                            ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                    End Select
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            If pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte Then
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales
                                txtCCT_ID.Text = pCCT_ID
                                MetodoBusquedaDato(dgv, "", txtCCT_ID.Text, True, EtxtCCT_ID)
                            End If
                        Case "tpaEntregas"
                            ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                        Case "tpaOtros"
                            ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                    End Select
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                        Case "tpaEntregas"
                            ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                        Case "tpaOtros"
                            ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                    End Select
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            If dgvDetalleTransferencias.RowCount > 0 Then
                                MsgBox("Existen registros en el detalle de transferencias", MsgBoxStyle.Information, "Error de datos")
                                Exit Sub
                            End If
                            If pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte Then
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales
                                txtCCT_ID.Text = pCCT_ID
                                MetodoBusquedaDato(dgv, vIdentificadorDgv, txtCCT_ID.Text, True, EtxtCCT_ID)
                            End If
                        Case "tpaEntregas"
                            If dgvDetalleTransferencias.RowCount > 0 Then
                                MsgBox("Existen registros en el detalle de transferencias", MsgBoxStyle.Information, "Error de datos")
                                Exit Sub
                            End If
                            ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                            If pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte Then
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales
                                txtCCT_ID.Text = pCCT_ID
                                MetodoBusquedaDato(dgv, vIdentificadorDgv, txtCCT_ID.Text, True, EtxtCCT_ID)
                            End If
                        Case "tpaOtros"
                            If dgvDetalleTransferencias.RowCount > 0 Then
                                MsgBox("Existen registros en el detalle de transferencias", MsgBoxStyle.Information, "Error de datos")
                                Exit Sub
                            End If
                            ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                            If pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte Then
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales
                                txtCCT_ID.Text = pCCT_ID
                                MetodoBusquedaDato(dgv, vIdentificadorDgv, txtCCT_ID.Text, True, EtxtCCT_ID)
                            End If

                        Case "tpaTransferencias"
                            If dgvDetalle.RowCount > 0 Then
                                MsgBox("Existen registros en el detalle de pagos", MsgBoxStyle.Information, "Error de datos")
                                Exit Sub
                            End If
                            If dgvDetalleEntregas.RowCount > 0 Then
                                MsgBox("Existen registros en el detalle de entregas", MsgBoxStyle.Information, "Error de datos")
                                Exit Sub
                            End If
                            If dgvDetalleOtros.RowCount > 0 Then
                                MsgBox("Existen registros en el detalle de otros", MsgBoxStyle.Information, "Error de datos")
                                Exit Sub
                            End If

                            pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte
                            txtCCT_ID.Text = pCCT_ID
                            MetodoBusquedaDato(dgv, vIdentificadorDgv, txtCCT_ID.Text, True, EtxtCCT_ID)

                            ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                    End Select
            End Select
            pPosicionColumnaGridNombre = "cPER_ID_CLI" & vIdentificadorDgv
            EditarColumnasProcesarAncho(dgv)
            If Not ValidarAdicionarFilasGrid() Then Exit Sub
            InicializarDatosGrid(dgv, vIdentificadorDgv, True)

            vcCCT_DESCRIPCION = ""
            vcPER_ID_CLI = ""
            vcPER_DESCRIPCION_CLI = ""
            vCCT_ID_DOC = ""
            vcTDO_ID_DOC = ""
            vcDTD_ID_DOC = ""
            vcDTE_SERIE_DOC = ""
            vcDTE_NUMERO_DOC = ""
            vMON_ID_DOC = ""
            vMON_DESCRIPCION_DOC = ""
            vDTE_FEC_VEN = Nothing


            ConfigurarAdicionFilasGridDetalle(dgv, vIdentificadorDgv)
            Dim vMovimiento As String

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                            ''''vMovimiento = Movimiento
                            ''''vcCCT_ID = pCCT_ID

                            Select Case dgv.Name
                                Case "dgvDetalleOtros"
                                    vcCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte
                                    vMON_ID_DOC = txtMON_ID_CCC.Text
                                    vCCC_ID_CLI = txtCCC_ID.Text
                                    vCCC_DESCRIPCION_CLI = txtCCC_DESCRIPCION.Text
                                Case "dgvDetalleEntregas"
                                Case Else
                                    vMovimiento = Movimiento
                                    vcCCT_ID = pCCT_ID
                            End Select

                        Case "frmDepositosBancarios"
                            vMovimiento = Movimiento
                            vcCCT_ID = pCCT_ID
                            vCCC_ID_CLI = txtCCC_ID_DES.Text
                            vCCC_DESCRIPCION_CLI = txtCCC_DESCRIPCION_DES.Text
                    End Select
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    vcCCT_ID = pCCT_ID
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaOtros"
                            vCCT_ID_DOC = txtCCT_ID.Text
                            vcTDO_ID_DOC = txtTDO_ID.Text
                            vcDTD_ID_DOC = BCVariablesNames.ProcesosCtaCte.SinDocumentoPlaRenCtas
                            vcDTE_SERIE_DOC = txtTES_SERIE.Text
                            vcDTE_NUMERO_DOC = txtTES_NUMERO.Text
                            vMON_ID_DOC = txtMON_ID_CCC.Text
                    End Select
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    vMovimiento = BCVariablesNames.Movimiento.Movimiento0
                    If cboTipoRecibo.Text = "OTROS" Then vMON_ID_DOC = txtMON_ID_CCC.Text
                    vcCCT_ID = pCCT_ID
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso
                    Select Case dgv.Name
                        Case "dgvDetalleOtros"
                            vcCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte
                            vMON_ID_DOC = txtMON_ID_CCC.Text
                        Case "dgvDetalleEntregas"
                            vMON_ID_DOC = txtMON_ID_CCC.Text
                        Case Else
                            vcCCT_ID = pCCT_ID
                    End Select
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    Select Case dgv.Name
                        Case "dgvDetalleEntregas"
                            vMON_ID_DOC = txtMON_ID_CCC.Text
                        Case "dgvDetalleOtros"
                            vMON_ID_DOC = txtMON_ID_CCC.Text
                    End Select
                    vMovimiento = Movimiento
                    vcCCT_ID = pCCT_ID
                Case Else
                    vMovimiento = Movimiento
                    vcCCT_ID = pCCT_ID
            End Select

            dgv.Rows.Add(EdgvDetalle.Elementos + 1, _
                                txtTDO_ID.Text, _
                                txtDTD_ID.Text, _
                                txtCCC_ID.Text, _
                                txtTES_SERIE.Text, _
                                txtTES_NUMERO.Text,
                                vcCCT_ID, vcCCT_DESCRIPCION, _
                                vCCC_ID_CLI, vCCC_DESCRIPCION_CLI, _
                                vcPER_ID_CLI, vcPER_DESCRIPCION_CLI, _
                                vDTE_FEC_VEN, _
                                vMovimiento, _
                                vCCT_ID_DOC, vcTDO_ID_DOC, vcDTD_ID_DOC, vcDTE_SERIE_DOC, vcDTE_NUMERO_DOC, _
                                vDTE_CAPITAL_DOC, vDTE_INTERES_DOC, vDTE_GASTOS_DOC, vDTE_IMPORTE_DOC, _
                                0, _
                                vMON_ID_DOC, vMON_DESCRIPCION_DOC, _
                                Destino,
                                CodigoCheque, MedioPago, 0, 0, _
                                SerieCheque, NumeroCheque, "", "", _
                                CodigoBanco, Diferido, Nothing, _
                                Recepcion, Ubicacion, _
                                "", "", Nothing, _
                                "", "", "", "", "", 0, 0, _
                                "", "", _
                                "", "", _
                                "", "", _
                                OperacionContable, _
                                "", _
                                Movimiento, "ACTIVO", "", 0)
            ProcesarGridVacio(dgv)
            EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
            InicializarDatosGrid(dgv, vIdentificadorDgv, False)
            ProcesarAnchoColumnasGrid(dgv, True)
            MostrarAnchoColumnaGrid(dgv)
            PosicionColumnaGrid(dgv, vIdentificadorDgv)

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                        Case "frmDepositosBancarios"
                            BloquearCajaCtaCteDestino(dgv)
                    End Select
                Case Else
            End Select
        End Sub

        Private Sub ConfigurarPagos()
            vcPER_ID_CLI = ""
            vcPER_DESCRIPCION_CLI = ""
            vCCT_ID_DOC = ""
            vcTDO_ID_DOC = ""
            vcDTD_ID_DOC = ""
            vcDTE_SERIE_DOC = ""
            vcDTE_NUMERO_DOC = ""
            vDTE_FEC_VEN = Now
            vMON_ID_DOC = ""
            vMON_DESCRIPCION_DOC = ""
        End Sub

        Private Sub ConfigurarEntregasOtros(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            vcPER_ID_CLI = ""
            vcPER_DESCRIPCION_CLI = ""
            vCCT_ID_DOC = txtCCT_ID.Text
            vcTDO_ID_DOC = txtTDO_ID.Text
            vcDTD_ID_DOC = txtDTD_ID.Text
            vcDTE_SERIE_DOC = txtTES_SERIE.Text
            vcDTE_NUMERO_DOC = txtTES_NUMERO.Text
            vDTE_FEC_VEN = Now
            vMON_ID_DOC = txtMON_ID_CCC.Text
            vMON_DESCRIPCION_DOC = txtMON_DESCRIPCION_CCC.Text

            Select Case pTDO_ID
                'Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    If tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        If dgv.RowCount = 0 Then
                            vcCCT_ID = ""
                            vcCCT_DESCRIPCION = ""

                            vcPER_ID_CLI = ""
                            vcPER_DESCRIPCION_CLI = ""

                            pPER_ID_CLI = ""
                            pPER_DESCRIPCION_CLI = ""
                            pCampoBusquedaEntregasCCT_ID = ""
                            pCampoBusquedaEntregasPER_ID_CLI = ""
                            pCampoBusquedaEntregasCCO_ID = ""

                            vDTE_CAPITAL_DOC = 0
                            vDTE_INTERES_DOC = 0
                            vDTE_GASTOS_DOC = 0
                            vDTE_IMPORTE_DOC = 0

                        Else
                            vcCCT_ID = dgv.Rows(dgv.Rows.Count() - 1).Cells("cCCT_ID" & vIdentificadorDgv).Value
                            vcCCT_DESCRIPCION = dgv.Rows(dgv.Rows.Count() - 1).Cells("cCCT_DESCRIPCION" & vIdentificadorDgv).Value

                            vcPER_ID_CLI = dgv.Rows(dgv.Rows.Count() - 1).Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                            vcPER_DESCRIPCION_CLI = dgv.Rows(dgv.Rows.Count() - 1).Cells("cPER_DESCRIPCION_CLI" & vIdentificadorDgv).Value

                            pPER_ID_CLI = dgv.Rows(dgv.Rows.Count() - 1).Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                            pPER_DESCRIPCION_CLI = dgv.Rows(dgv.Rows.Count() - 1).Cells("cPER_DESCRIPCION_CLI" & vIdentificadorDgv).Value

                            pCampoBusquedaEntregasCCT_ID = vcCCT_ID & dgv.Rows(dgv.Rows.Count() - 1).Cells("cTDO_ID" & vIdentificadorDgv).Value & dgv.Rows(dgv.Rows.Count() - 1).Cells("cDTD_IDr" & vIdentificadorDgv).Value
                            pCampoBusquedaEntregasPER_ID_CLI = dgv.Rows(dgv.Rows.Count() - 1).Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                            pCampoBusquedaEntregasCCO_ID = dgv.Rows(dgv.Rows.Count() - 1).Cells("cCCO_ID" & vIdentificadorDgv).Value

                            If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then
                                vDTE_FEC_VEN = DateAdd(DateInterval.Day, 30, dgv.Rows(dgv.Rows.Count() - 1).Cells("cDTE_FEC_VEN" & vIdentificadorDgv).Value)
                            Else
                                'vDTE_FEC_VEN = dgv.Rows(dgv.Rows.Count() - 1).Cells("cDTE_FEC_VEN" & vIdentificadorDgv).Value
                            End If

                            vDTE_CAPITAL_DOC = dgv.Rows(dgv.Rows.Count() - 1).Cells("cDTE_CAPITAL_DOC" & vIdentificadorDgv).Value
                            vDTE_INTERES_DOC = dgv.Rows(dgv.Rows.Count() - 1).Cells("cDTE_INTERES_DOC" & vIdentificadorDgv).Value
                            vDTE_GASTOS_DOC = dgv.Rows(dgv.Rows.Count() - 1).Cells("cDTE_GASTOS_DOC" & vIdentificadorDgv).Value
                            vDTE_IMPORTE_DOC = dgv.Rows(dgv.Rows.Count() - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value
                        End If
                    End If
                Case Else
                    If cboTipoRecibo.Text = "OTROS" Then
                        If dgv.RowCount = 0 Then
                            vcPER_ID_CLI = txtPER_ID_CAJ.Text
                            vcPER_DESCRIPCION_CLI = txtPER_DESCRIPCION_CAJ.Text
                            pPER_ID_CLI = txtPER_ID_CAJ.Text
                            pPER_DESCRIPCION_CLI = txtPER_DESCRIPCION_CAJ.Text
                        Else
                            vcPER_ID_CLI = dgv.CurrentRow.Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                            vcPER_DESCRIPCION_CLI = dgv.CurrentRow.Cells("cPER_DESCRIPCION_CLI" & vIdentificadorDgv).Value

                            pPER_ID_CLI = dgv.CurrentRow.Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                            pPER_DESCRIPCION_CLI = dgv.CurrentRow.Cells("cPER_DESCRIPCION_CLI" & vIdentificadorDgv).Value
                        End If
                    End If
            End Select
        End Sub
        Private Sub ConfigurarTransferencias(ByRef dgv As DataGridView)
            vcPER_ID_CLI = txtPER_ID_CAJ.Text
            vcPER_DESCRIPCION_CLI = txtPER_DESCRIPCION_CAJ.Text
            pPER_ID_CLI = txtPER_ID_CAJ.Text
            pPER_DESCRIPCION_CLI = txtPER_DESCRIPCION_CAJ.Text
            vCCT_ID_DOC = txtCCT_ID.Text
            vcTDO_ID_DOC = txtTDO_ID.Text
            vcDTD_ID_DOC = txtDTD_ID.Text
            vcDTE_SERIE_DOC = txtTES_SERIE.Text
            vcDTE_NUMERO_DOC = txtTES_NUMERO.Text
            vDTE_FEC_VEN = Now
            vMON_ID_DOC = txtMON_ID_CCC.Text
            vMON_DESCRIPCION_DOC = txtMON_DESCRIPCION_CCC.Text
            Me.Movimiento = BCVariablesNames.Movimiento.Movimiento4
            Me.Destino = BCVariablesNames.Destino.Destino3
            Select Case Me.Name
                Case "frmTransferenciaEntreCajas"
                    If dgv.Name = "dgvDetalleOtros" Then
                        vCCT_ID_DOC = "012" 'txtCCT_ID.Text
                        vcTDO_ID_DOC = "017" 'txtTDO_ID.Text
                        vcDTD_ID_DOC = "086" 'txtDTD_ID.Text
                        vcDTE_SERIE_DOC = txtTES_SERIE.Text
                        vcDTE_NUMERO_DOC = txtTES_NUMERO.Text
                    End If
                Case "frmDepositosBancarios"
                    MedioPago = BCVariablesNames.MedioPago.MedioPago1
            End Select
        End Sub
        Private Sub ConfigurarAdicionFilasGridDetalle(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas

                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso,
                     BCVariablesNames.ProcesosCaja.VoucherCheque

                    Me.Movimiento = BCVariablesNames.Movimiento.Movimiento0
                    Me.Destino = BCVariablesNames.Destino.Destino0

                    If pTDO_ID = BCVariablesNames.ProcesosCaja.VoucherCheque Then
                        MedioPago = BCVariablesNames.MedioPago.MedioPago1
                        CodigoCheque = cboSerieCorrelativo.Text
                        SerieCheque = cboSerieCorrelativo.Text
                        NumeroCheque = txtTES_NUMERO.Text
                    Else
                        CodigoCheque = ""
                        SerieCheque = ""
                        NumeroCheque = ""
                        CodigoBanco = ""
                    End If

                    If cboTipoRecibo.Text = "PAGOS" Then
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                                ConfigurarEntregasOtros(dgv, vIdentificadorDgv)
                            Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                                 BCVariablesNames.ProcesosCaja.CajaIngreso, _
                                 BCVariablesNames.ProcesosCaja.CajaEgreso
                                'ConfigurarEntregasOtros(dgv, vIdentificadorDgv)
                                ConfigurarPagos()
                                If Not IsNothing(dgv.CurrentRow) Then FiltroDTD_ID_DOC(dgv, vIdentificadorDgv)
                                vProcesarBusquedaDirectaDocumento = True
                            Case Else
                                ConfigurarPagos()
                        End Select

                        If pTDO_ID = BCVariablesNames.ProcesosCaja.VoucherCheque Then
                            Select Case dgv.Name
                                Case "dgvDetalleTransferencias"
                                    ConfigurarTransferencias(dgv)
                            End Select
                        End If
                    ElseIf cboTipoRecibo.Text = "ENTREGAS" Or _
                        cboTipoRecibo.Text = "OTROS" Then
                        ConfigurarEntregasOtros(dgv, vIdentificadorDgv)
                    End If
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    ConfigurarTransferencias(dgv)
            End Select
        End Sub

        Private Sub EliminarFilasGrid()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        EliminarFilas(dgvDetalle)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                        EliminarFilas(dgvDetalleOtros)
                    End If

                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                        Case "frmDepositosBancarios"
                            BloquearCajaCtaCteDestino(dgvDetalle)
                    End Select
                Case BCVariablesNames.ProcesosCaja.DepositoTercero
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        EliminarFilas(dgvDetalle)
                        BloquearPerIdCliRec(dgvDetalle)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        EliminarFilas(dgvDetalleEntregas)
                        'BloquearPerIdCliRec(dgvDetalleEntregas)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                        EliminarFilas(dgvDetalleOtros)
                        'BloquearPerIdCliRec(dgvDetalleOtros)
                    End If
                Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso, _
                     BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        EliminarFilas(dgvDetalle)
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                            Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                                 BCVariablesNames.ProcesosCaja.CajaIngreso, _
                                 BCVariablesNames.ProcesosCaja.CajaEgreso
                                BloquearPerIdCliRec(dgvDetalle)
                        End Select
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        EliminarFilas(dgvDetalleEntregas)
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                                BloquearPerIdCliRec(dgvDetalleEntregas)
                        End Select
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                        EliminarFilas(dgvDetalleOtros)
                    End If
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    If dgvDetalle.Focus Then
                        EliminarFilas(dgvDetalle)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        EliminarFilas(dgvDetalleEntregas)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                        EliminarFilas(dgvDetalleOtros)
                    ElseIf dgvDetalleTransferencias.Focus Then
                        EliminarFilas(dgvDetalleTransferencias)
                    End If
                Case Else
                    EliminarFilas(dgvDetalle)
            End Select
        End Sub
        Private Sub EliminarFilas(ByRef dgv As DataGridView)
            If dgv.Rows.Count = 0 Then Return

            Dim vfila As DataGridViewRow
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(dgv)

            vfila = dgv.Rows(dgv.CurrentRow.Index)
            If dgv.Rows.Count > 0 Then
                Try
                    With dgv.Rows(dgv.CurrentRow.Index)
                        If .Cells("cEstadoRegistro" & vIdentificadorDgv).Value = 1 Then
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cTDO_ID = .Cells("cTDO_ID" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTD_ID = .Cells("cDTD_ID" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cCCC_ID = .Cells("cCCC_ID" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTE_SERIE = .Cells("cDTE_SERIE" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTE_NUMERO = .Cells("cDTE_NUMERO" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTE_ITEM = .Cells("cITEM" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cPER_ID_BAN = .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cMPT_SERIE_MEDIO = .Cells("cMPT_SERIE_MEDIO" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cMPT_NUMERO_MEDIO = .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value.ToString()

                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cTDO_ID = .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTD_ID = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTE_SERIE = .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTE_NUMERO = .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTE_IMPORTE = .Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTE_CONTRAVALOR = .Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cMON_ID = .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value.ToString()

                            eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cTDO_ID = .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTD_ID = .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTE_SERIE = .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTE_NUMERO = .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTE_IMPORTE = .Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTE_CONTRAVALOR = .Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cMON_ID = .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value.ToString()

                            ReDim Preserve eRegistrosEliminar(eRegistrosEliminar.Count)
                            ReDim Preserve eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count)
                            ReDim Preserve eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count)
                        End If
                    End With
                    dgv.Rows.Remove(vfila)
                    ProcesarGridVacio(dgv)
                    CalcularMontoDocumento()
                Catch ex As Exception
                    MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- QuitarFilaGrid")
                End Try
            End If
        End Sub
        '' ojito
        Public Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "CancelarEdicion"
                    CodigoId = CodigoId & vCodigoCCC_ID & vCodigoTES_SERIE & vCodigoTES_NUMERO & vCodigoDTD_ID
                    If Trim(CodigoId) = "" Then CodigoId = "%"
                Case "PrepararEliminar"
                    Compuesto.Vista = "RegistroAnterior"
                    Compuesto.TDO_ID = CodigoId
                    Compuesto.CCC_ID = vCodigoCCC_ID
                    Compuesto.TES_SERIE = vCodigoTES_SERIE
                    Compuesto.TES_NUMERO = vCodigoTES_NUMERO
                    Compuesto.DTD_ID = vCodigoDTD_ID
                Case "Load"
                    Compuesto.Vista = "PrimerAnterior"
                    Compuesto.TDO_ID = CodigoId
                    Compuesto.CCC_ID = vCodigoCCC_ID
                    Compuesto.TES_SERIE = vCodigoTES_SERIE
                    Compuesto.TES_NUMERO = vCodigoTES_NUMERO
                    Compuesto.DTD_ID = vCodigoDTD_ID
                Case "RegistroNoEncontrado" ' ojito
                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    Compuesto.CCC_ID = txtCCC_ID.Text.Trim
                    Compuesto.TES_SERIE = txtTES_SERIE.Text.Trim
                    Compuesto.TES_NUMERO = txtTES_NUMERO.Text.Trim
                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim

                    CodigoId = Compuesto.TDO_ID
                    vCodigoCCC_ID = Compuesto.CCC_ID
                    vCodigoTES_SERIE = Compuesto.TES_SERIE
                    vCodigoTES_NUMERO = Compuesto.TES_NUMERO
                    vCodigoDTD_ID = Compuesto.DTD_ID
                Case "NavegarFormulario"
                    CodigoId = CodigoId & vCodigoCCC_ID & vCodigoTES_SERIE & vCodigoTES_NUMERO & vCodigoDTD_ID
                Case "EliminarRegistro"
                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim

                    Compuesto.CCC_ID = txtCCC_ID.Text.Trim
                    vCodigoCCC_ID = txtCCC_ID.Text.Trim

                    Compuesto.TES_SERIE = txtTES_SERIE.Text.Trim
                    vCodigoTES_SERIE = txtTES_SERIE.Text.Trim

                    Compuesto.TES_NUMERO = txtTES_NUMERO.Text.Trim
                    vCodigoTES_NUMERO = txtTES_NUMERO.Text.Trim

                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim

                    Compuesto.TES_FECHA_EMI = dtpTES_FECHA_EMI.Value
                    Compuesto.USU_ID = SessionService.UserId
                Case "InicializarDatos"
                    InicializarValores(dgvDetalle, ErrorProvider1)
                    InicializarValores(dgvDetalleEntregas, ErrorProvider1)
                    InicializarValores(dgvDetalleOtros, ErrorProvider1)
                    InicializarValores(dgvDetalleTransferencias, ErrorProvider1)
                    ''InicializarValores(dgvKardexCtaCte, ErrorProvider1)
                    ''InicializarValores(dgvMovimientoCajaBanco, ErrorProvider1)

                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim

                    Compuesto.CCC_ID = txtCCC_ID.Text.Trim
                    vCodigoCCC_ID = txtCCC_ID.Text.Trim

                    Compuesto.TES_SERIE = txtTES_SERIE.Text.Trim
                    vCodigoTES_SERIE = txtTES_SERIE.Text.Trim

                    Compuesto.TES_NUMERO = txtTES_NUMERO.Text.Trim
                    vCodigoTES_NUMERO = txtTES_NUMERO.Text.Trim

                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim

                    Compuesto1.TDO_ID = txtTDO_ID.Text.Trim

                    Dim vTipoRecibo As String
                    Dim vcontrol As Int16
                    Dim ds As New DataSet

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                             BCVariablesNames.ProcesosCaja.CajaEgreso,
                             BCVariablesNames.ProcesosCaja.DepositoTercero,
                             BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                             BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                            BCVariablesNames.ProcesosCaja.VoucherCheque
                            vTipoRecibo = BCVariablesNames.ModulosCaja.ReciboIngresoEgreso
                        Case BCVariablesNames.ProcesosCaja.PlanillaEgreso
                            vTipoRecibo = BCVariablesNames.ModulosCaja.PlanillaIngresoEgreso
                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            vTipoRecibo = BCVariablesNames.ModulosCaja.TransferenciaEntreCajaBanco
                    End Select

                    If vBuscarDetalle Then
                        BuscarDetalle()
                    End If

                    pLoaded = True
                    Dim sr As New StringReader(IBCMaestro.EjecutarVista("spRoc_TipoRolOpeCtaCteXML", vTipoRecibo, txtTDO_ID.Text.Trim, txtDTD_ID.Text.Trim, txtCCT_ID.Text.Trim))
                    vcontrol = sr.Peek
                    If vcontrol <> -1 Then
                        ds.ReadXml(sr)
                        pFlagVerificarCajaCtaCte = False
                        cboTipoRecibo.Text = ds.Tables(0).Rows(0).Item("ROC_TIPO")
                        pFlagVerificarCajaCtaCte = True

                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.VoucherCheque
                                If cboTipoRecibo.Text = "OTROS" Then
                                    cboTipoRecibo.Text = "PAGOS"
                                End If
                            Case Else
                        End Select
                    Else
                        If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                            If (Me.IBCBusqueda.ReciboCCO_IDCUC_ID(txtTDO_ID.Text, txtDTD_ID.Text, txtCCC_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)) > 0 Then
                                cboTipoRecibo.Text = "OTROS"
                            Else
                                cboTipoRecibo.Text = "PAGOS"
                            End If
                        Else
                            cboTipoRecibo.Text = ""
                        End If
                    End If
                    pLoaded = False
                    FormatearCamposAMostrarEnGrid()
            End Select
        End Sub
        '' ojito
        Public Sub BuscarDetalle()
            Compuesto1.Vista = "ListarRegistrosTipoRecibo"
            Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, CodigoId, vCodigoDTD_ID, vCodigoCCC_ID, vCodigoTES_SERIE, vCodigoTES_NUMERO, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                dgvDetalle.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
                        If x = 0 Then
                            txtCCT_ID.Text = ds.Tables(0).Rows(x).Item("Cta.Cte.").ToString()
                            txtCCT_DESCRIPCION.Text = ds.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
                            Me.Text += " - " & ds.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
                            pCCT_ID = txtCCT_ID.Text
                            FiltroCCT_ID()
                        End If
                        dgvDetalle.Rows.Add()
                        With ds.Tables(0).Rows(x)
                            While y < ds.Tables(0).Columns.Count
                                dgvDetalle.Item(y, dgvDetalle.Rows.Count - 1).Value = Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                y = y + 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information)
                End If
                CalcularMontoDocumento()
            Else
                dgvDetalle.DataSource = Nothing
            End If

            ''
            Compuesto1.Vista = "ListarRegistrosTipoReciboEntregas"
            NombreProcedimiento = Compuesto1.SentenciaSqlBusqueda()
            Dim ds2 As New DataSet
            Dim sr2 As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, CodigoId, vCodigoDTD_ID, vCodigoCCC_ID, vCodigoTES_SERIE, vCodigoTES_NUMERO, Nothing))
            Dim vcontrol2 As Int16 = sr2.Peek
            If vcontrol2 <> -1 Then
                ds2.ReadXml(sr2)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                dgvDetalleEntregas.Rows.Clear()
                If (ds2.Tables(0).Rows.Count > 0) Then
                    While (x < ds2.Tables(0).Rows.Count)
                        If x = 0 Then
                            'txtCCT_ID.Text = ds3.Tables(0).Rows(x).Item("Cta.Cte.").ToString()
                            'txtCCT_DESCRIPCION.Text = ds3.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
                            'Me.Text += " - " & ds3.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
                            'pCCT_ID = txtCCT_ID.Text
                            'FiltroCCT_ID()
                        End If
                        dgvDetalleEntregas.Rows.Add()
                        With ds2.Tables(0).Rows(x)
                            While y < ds2.Tables(0).Columns.Count
                                dgvDetalleEntregas.Item(y, dgvDetalleEntregas.Rows.Count - 1).Value = Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                y = y + 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information)
                End If
                CalcularMontoDocumento()
            Else
                dgvDetalleEntregas.DataSource = Nothing
            End If
            ''


            Compuesto1.Vista = "ListarRegistrosTipoReciboOtros"
            NombreProcedimiento = Compuesto1.SentenciaSqlBusqueda()
            Dim ds3 As New DataSet
            Dim sr3 As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, CodigoId, vCodigoDTD_ID, vCodigoCCC_ID, vCodigoTES_SERIE, vCodigoTES_NUMERO, Nothing))
            Dim vcontrol3 As Int16 = sr3.Peek
            If vcontrol3 <> -1 Then
                ds3.ReadXml(sr3)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                dgvDetalleOtros.Rows.Clear()
                If (ds3.Tables(0).Rows.Count > 0) Then
                    While (x < ds3.Tables(0).Rows.Count)
                        If x = 0 Then
                            'txtCCT_ID.Text = ds3.Tables(0).Rows(x).Item("Cta.Cte.").ToString()
                            'txtCCT_DESCRIPCION.Text = ds3.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
                            'Me.Text += " - " & ds3.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
                            'pCCT_ID = txtCCT_ID.Text
                            'FiltroCCT_ID()
                        End If
                        dgvDetalleOtros.Rows.Add()
                        With ds3.Tables(0).Rows(x)
                            While y < ds3.Tables(0).Columns.Count
                                dgvDetalleOtros.Item(y, dgvDetalleOtros.Rows.Count - 1).Value = Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                y = y + 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information)
                End If
                CalcularMontoDocumento()
            Else
                dgvDetalleOtros.DataSource = Nothing
            End If

            Compuesto1.Vista = "ListarRegistrosTipoReciboTransferencias"
            NombreProcedimiento = Compuesto1.SentenciaSqlBusqueda()
            Dim ds4 As New DataSet
            Dim sr4 As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, CodigoId, vCodigoDTD_ID, vCodigoCCC_ID, vCodigoTES_SERIE, vCodigoTES_NUMERO, Nothing))
            Dim vcontrol4 As Int16 = sr4.Peek
            If vcontrol4 <> -1 Then
                ds4.ReadXml(sr4)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                dgvDetalleTransferencias.Rows.Clear()
                If (ds4.Tables(0).Rows.Count > 0) Then
                    While (x < ds4.Tables(0).Rows.Count)
                        If x = 0 Then
                            txtCCT_ID.Text = ds4.Tables(0).Rows(x).Item("Cta.Cte.").ToString()
                            txtCCT_DESCRIPCION.Text = ds4.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
                            Me.Text += " - " & ds4.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
                            pCCT_ID = txtCCT_ID.Text
                            FiltroCCT_ID()
                        End If
                        dgvDetalleTransferencias.Rows.Add()
                        With ds4.Tables(0).Rows(x)
                            While y < ds4.Tables(0).Columns.Count
                                dgvDetalleTransferencias.Item(y, dgvDetalleTransferencias.Rows.Count - 1).Value = Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                y = y + 1
                            End While
                            y = 0
                        End With
                        x += 1
                    End While
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information)
                End If
                CalcularMontoDocumento()
            Else
                dgvDetalleTransferencias.DataSource = Nothing
            End If

            FormatearCamposAMostrarEnGrid()
        End Sub
        Private Sub FormatearCamposAMostrarEnGrid()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    'RemoverTabs(tcoTipoRecibo, tpaOtros) '2016-07-19

                    tcoTipoRecibo.SelectedTab = tpaTransferencias
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleTransferencias, "t")
                    tcoTipoRecibo.SelectedTab = tpaPagos
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalle, "")
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                    BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)

                    tcoTipoRecibo.SelectedTab = tpaOtros
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleOtros, "o")
                    tcoTipoRecibo.SelectedTab = tpaEntregas
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleEntregas, "e")
                    tcoTipoRecibo.SelectedTab = tpaPagos
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalle, "")
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    RemoverTabs(tcoTipoRecibo, tpaEntregas)
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)

                    tcoTipoRecibo.SelectedTab = tpaOtros
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleOtros, "o")
                    tcoTipoRecibo.SelectedTab = tpaPagos
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalle, "")
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)

                    tcoTipoRecibo.SelectedTab = tpaOtros
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleOtros, "o")
                    tcoTipoRecibo.SelectedTab = tpaEntregas
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleEntregas, "e")
                    tcoTipoRecibo.SelectedTab = tpaPagos
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalle, "")
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)
                    RemoverTabs(tcoTipoRecibo, tpaEntregas)
                    tcoTipoRecibo.SelectedTab = tpaOtros
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleOtros, "o")
                    tcoTipoRecibo.SelectedTab = tpaPagos
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalle, "")
                Case Else
                    tcoTipoRecibo.SelectedTab = tpaTransferencias
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleTransferencias, "t")
                    tcoTipoRecibo.SelectedTab = tpaOtros
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleOtros, "o")
                    tcoTipoRecibo.SelectedTab = tpaEntregas
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalleEntregas, "e")
                    tcoTipoRecibo.SelectedTab = tpaPagos
                    ConfigurarCampoVisualizarGridDetalle(dgvDetalle, "")
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

        Private Function ProcesarMovimientoCajaBanco(Optional ByVal vVoucherAnulado As Boolean = False) As Boolean
            ProcesarMovimientoCajaBanco = True
            Dim vContadorDgv As Integer = 4
            Dim vFlagProcesarContadorDgv As Boolean = False
            Dim vTipoPago As String = ""

            Dim vFilGrid As Integer = 0

            Dim CargoAbono As String = ""
            Dim vCargo As Double = 0
            Dim vAbono As Double = 0
            Dim vContraValor As Double = 0

            Dim vSignoCuentaContable As Integer = 1

            Dim vCCO_ID As String
            Dim vCUC_ID As String
            Dim vCCT_ID As String
            Dim vPER_ID_CLI As String
            Dim vCCC_ID_CLI As String
            Dim vTDO_ID_DOC As String
            Dim vDTD_ID_DOC As String
            Dim vCCT_ID_DOC As String
            Dim vDTE_SERIE_DOC As String
            Dim vDTE_NUMERO_DOC As String
            Dim vPER_ID_BAN As String
            Dim vPER_ID_CLI_1 As String
            Dim vCCT_ID_DOC_1 As String
            Dim vTDO_ID_DOC_1 As String
            Dim vDTD_ID_DOC_1 As String
            Dim vDTE_SERIE_DOC_1 As String
            Dim vDTE_NUMERO_DOC_1 As String

            Dim vDTE_OBSERVACIONES As String = ""
            Dim dgv As DataGridView
            Dim vIdentificadorDgv As String

            Dim vCCT_IDTemp As String = ""
            Dim vTDO_IDTemp As String = ""
            Dim vDTD_IDTemp As String = ""
            Dim vCargoAbonoTemp As String = ""

            Dim vCCT_IDTemp1 As String = ""
            Dim vTDO_IDTemp1 As String = ""
            Dim vDTD_IDTemp1 As String = ""
            Dim vCargoAbonoTemp1 As String = ""

            Dim vCCT_IDTemp2 As String = ""
            Dim vTDO_IDTemp2 As String = ""
            Dim vDTD_IDTemp2 As String = ""
            Dim vCargoAbonoTemp2 As String = ""

            Dim vFilGridEntregas As Int16 = 0
            Dim vFlagCrearRecibos As Double = False
            Dim vTES_MONTO_TOTAL As Double = 0

            dgvMovimientoCajaBanco.Rows.Clear()

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    ' Si vale
                    'If dgvDetalle.RowCount = 0 Then
                    '    If dgvDetalleTransferencias.RowCount > 0 Then
                    '        vTipoPago = "Pagos"
                    '        dgv = dgvDetalleTransferencias
                    '    Else
                    '        vTipoPago = "Pagos"
                    '        dgv = dgvDetalle
                    '    End If
                    'Else
                    '    vTipoPago = "Pagos"
                    '    dgv = dgvDetalle
                    'End If
                    'vFlagProcesarContadorDgv = False

                    ' Si vale Nuevo
                    If dgvDetalle.RowCount = 0 And dgvDetalleEntregas.RowCount = 0 Then
                        If dgvDetalleTransferencias.RowCount > 0 Then
                            vTipoPago = "Pagos"
                            dgv = dgvDetalleTransferencias
                            vFlagProcesarContadorDgv = False
                        Else
                            vContadorDgv = 1 ''
                            vTipoPago = "Pagos"
                            dgv = dgvDetalle
                            vFlagProcesarContadorDgv = True ''
                        End If
                    Else
                        vContadorDgv = 1 ''
                        vTipoPago = "Pagos"
                        dgv = dgvDetalle
                        vFlagProcesarContadorDgv = True ''
                    End If
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso
                    vContadorDgv = 1
                    vTipoPago = "Pagos"
                    dgv = dgvDetalle
                    vFlagProcesarContadorDgv = True
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    Exit Function
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    vContadorDgv = 1
                    vTipoPago = "Pagos"
                    dgv = dgvDetalle
                    vFlagProcesarContadorDgv = True
                Case Else
                    vTipoPago = "Pagos"
                    dgv = dgvDetalle
                    vFlagProcesarContadorDgv = False
            End Select

            If vVoucherAnulado Then
            Else
                If chkTES_ESTADO.CheckState <> CheckState.Checked Then
                    Exit Function
                End If
            End If

            While vContadorDgv <= 4
                vFilGrid = 0

                If vFlagProcesarContadorDgv Then
                    Select Case vContadorDgv
                        Case 1
                            dgv = dgvDetalle
                            vTipoPago = "Pagos"
                        Case 2
                            dgv = dgvDetalleEntregas
                            vTipoPago = "Entregas"
                        Case 3
                            dgv = dgvDetalleOtros
                            vTipoPago = "Otros"
                        Case 4
                            dgv = dgvDetalleTransferencias
                            vTipoPago = "Transferencias"
                    End Select
                End If
                vIdentificadorDgv = ProcesarIdentificadorGrid(dgv)

                If dgv.Rows.Count() > 0 Then
                    While (dgv.Rows.Count() > vFilGrid)
                        With dgv.Rows(vFilGrid)
                            If chkTES_ESTADO.CheckState = CheckState.Checked Then
                                If .Cells("cCCO_ID" & vIdentificadorDgv).Value = "" Then
                                    vCCO_ID = Nothing
                                Else
                                    vCCO_ID = .Cells("cCCO_ID" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cCUC_ID" & vIdentificadorDgv).Value = "" Then
                                    vCUC_ID = Nothing
                                Else
                                    vCUC_ID = .Cells("cCUC_ID" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cCCT_ID" & vIdentificadorDgv).Value = "" Then
                                    vCCT_ID = Nothing
                                Else
                                    vCCT_ID = .Cells("cCCT_ID" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value = "" Then
                                    vPER_ID_BAN = Nothing
                                Else
                                    vPER_ID_BAN = .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cPER_ID_CLI" & vIdentificadorDgv).Value = "" Then
                                    vPER_ID_CLI = Nothing
                                Else
                                    vPER_ID_CLI = .Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value = "" Then
                                    vCCC_ID_CLI = Nothing
                                Else
                                    vCCC_ID_CLI = .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                    vCCT_ID_DOC = Nothing
                                Else
                                    vCCT_ID_DOC = .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                    vTDO_ID_DOC = Nothing
                                Else
                                    vTDO_ID_DOC = .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                    vDTD_ID_DOC = Nothing
                                Else
                                    vDTD_ID_DOC = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value = "" Then
                                    vDTE_SERIE_DOC = Nothing
                                Else
                                    vDTE_SERIE_DOC = .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value
                                End If
                                If .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value = "" Then
                                    vDTE_NUMERO_DOC = Nothing
                                Else
                                    vDTE_NUMERO_DOC = .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value = "" Then
                                    vPER_ID_CLI_1 = Nothing
                                Else
                                    vPER_ID_CLI_1 = .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vCCT_ID_DOC_1 = Nothing
                                Else
                                    vCCT_ID_DOC_1 = .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vTDO_ID_DOC_1 = Nothing
                                Else
                                    vTDO_ID_DOC_1 = .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value
                                End If
                                If .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vDTD_ID_DOC_1 = Nothing
                                Else
                                    vDTD_ID_DOC_1 = .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value
                                End If
                                If .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vDTE_SERIE_DOC_1 = Nothing
                                Else
                                    vDTE_SERIE_DOC_1 = .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value
                                End If
                                If .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vDTE_NUMERO_DOC_1 = Nothing
                                Else
                                    vDTE_NUMERO_DOC_1 = .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value
                                End If

                                vDTE_OBSERVACIONES = Strings.Left(.Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value & " - " & .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value & " - " & .Cells("cCUC_DESCRIPCION" & vIdentificadorDgv).Value, 255)

                                ' Documentos - Cobros, pagos, transferencias origen 
                                If .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString <> BCVariablesNames.Movimiento.Movimiento2 And _
                                   .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString <> BCVariablesNames.Movimiento.Movimiento3 Then

                                    If vFilGrid = 0 Then
                                        vCCT_IDTemp = vCCT_ID
                                        vTDO_IDTemp = txtTDO_ID.Text
                                        vDTD_IDTemp = txtDTD_ID.Text
                                        vCargoAbonoTemp = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID, _
                                                                        txtTDO_ID.Text, _
                                                                        txtDTD_ID.Text)
                                    End If

                                    If vCCT_IDTemp <> vCCT_ID Or
                                       vTDO_IDTemp <> txtTDO_ID.Text Or
                                       vDTD_IDTemp <> txtDTD_ID.Text Then
                                        vCCT_IDTemp = vCCT_ID
                                        vTDO_IDTemp = txtTDO_ID.Text
                                        vDTD_IDTemp = txtDTD_ID.Text
                                        vCargoAbonoTemp = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID, _
                                                                        txtTDO_ID.Text, _
                                                                        txtDTD_ID.Text)
                                        CargoAbono = vCargoAbonoTemp
                                    Else
                                        CargoAbono = vCargoAbonoTemp
                                    End If

                                    vFilGridEntregas = 0
                                    vFlagCrearRecibos = False
                                    vTES_MONTO_TOTAL = 0
                                    If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then
                                        If dgv.Name = "dgvDetalleEntregas" Then
                                            vFilGridEntregas = 0
                                            While (dgv.Rows.Count() > vFilGridEntregas)
                                                With dgv.Rows(vFilGridEntregas)
                                                    vTES_MONTO_TOTAL += CDbl(.Cells("cDTE_CAPITAL_DOC" & vIdentificadorDgv).Value)
                                                    If .Cells("cDTE_CAPITAL_DOC" & vIdentificadorDgv).Value <> 0 Or _
                                                        .Cells("cDTE_INTERES_DOC" & vIdentificadorDgv).Value <> 0 Or _
                                                        .Cells("cDTE_GASTOS_DOC" & vIdentificadorDgv).Value <> 0 Then
                                                        vFlagCrearRecibos = True
                                                    End If
                                                End With
                                                vFilGridEntregas += 1
                                            End While
                                        End If
                                    End If

                                    Select Case CargoAbono
                                        Case "ABONO"
                                            If vFlagCrearRecibos Then
                                                vCargo = CDbl(.Cells("cDTE_CAPITAL_DOC" & vIdentificadorDgv).Value)
                                                vAbono = 0
                                                vContraValor = (CDbl(.Cells("cDTE_CAPITAL_DOC" & vIdentificadorDgv).Value) * CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) / CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value))
                                            Else
                                                vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                vAbono = 0
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                vTES_MONTO_TOTAL = CDbl(txtTES_MONTO_TOTAL.Text)
                                            End If
                                        Case "CARGO"
                                            If vFlagCrearRecibos Then
                                                vAbono = CDbl(.Cells("cDTE_CAPITAL_DOC" & vIdentificadorDgv).Value)
                                                vCargo = 0
                                                vContraValor = (CDbl(.Cells("cDTE_CAPITAL_DOC" & vIdentificadorDgv).Value) * CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) / CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value))
                                            Else
                                                vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                vCargo = 0
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                vTES_MONTO_TOTAL = CDbl(txtTES_MONTO_TOTAL.Text)
                                            End If
                                    End Select

                                    If dgv.Name = "dgvDetalleOtros" Then
                                        Try
                                            vSignoCuentaContable = Me.IBCBusqueda.SignoCuentaContable(CDbl(.Cells("cCUC_ID" & vIdentificadorDgv).Value))
                                            ErrorProvider1.SetError(tcoTipoRecibo, Nothing)
                                            ErrorProvider1.SetError(dgv, Nothing)
                                        Catch ex As Exception
                                            ErrorProvider1.SetError(tcoTipoRecibo, "Error")
                                            ErrorProvider1.SetError(dgv, "Error en cuenta contable")
                                            ProcesarMovimientoCajaBanco = False
                                            Return ProcesarMovimientoCajaBanco
                                            Exit Function
                                        End Try

                                        Select Case pTDO_ID
                                            Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                                                vSignoCuentaContable = vSignoCuentaContable * -1
                                            Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                                                vSignoCuentaContable = vSignoCuentaContable * -1
                                            Case BCVariablesNames.ProcesosCaja.CajaEgreso
                                                If Strings.Left(.Cells("cCUC_ID" & vIdentificadorDgv).Value, 1) = 9 Then
                                                    vSignoCuentaContable = vSignoCuentaContable * -1
                                                End If
                                            Case Else
                                        End Select
                                        '
                                        If dgvDetalle.Rows.Count = 0 And _
                                           dgvDetalleEntregas.Rows.Count = 0 Then
                                            vCargo = vCargo
                                            vAbono = vAbono
                                        Else
                                            vCargo = vCargo * vSignoCuentaContable
                                            vAbono = vAbono * vSignoCuentaContable
                                        End If
                                    Else
                                        vSignoCuentaContable = 1
                                    End If

                                    dgvMovimientoCajaBanco.Rows.Add(
                                                    dtpTES_FECHA_EMI.Value,
                                                    vCCO_ID,
                                                    vCUC_ID,
                                                    vTES_MONTO_TOTAL,
                                                    txtCCC_ID.Text,
                                                    vCCT_ID,
                                                    txtTDO_ID.Text,
                                                    txtDTD_ID.Text,
                                                    Strings.Trim(txtTES_SERIE.Text),
                                                    Strings.Trim(txtTES_NUMERO.Text),
                                                    vCargo,
                                                    vAbono,
                                                    vContraValor,
                                                    vPER_ID_BAN,
                                                    vPER_ID_CLI,
                                                    vCCC_ID_CLI,
                                                    vCCT_ID_DOC,
                                                    vTDO_ID_DOC,
                                                    vDTD_ID_DOC,
                                                    vDTE_SERIE_DOC,
                                                    vDTE_NUMERO_DOC,
                                                    vDTE_OBSERVACIONES,
                                                    txtCCC_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text & Strings.Trim(txtTES_SERIE.Text) & Strings.Trim(txtTES_NUMERO.Text),
                                                    vTipoPago)
                                    vCargo = 0
                                    vAbono = 0
                                    vContraValor = 0
                                End If

                                ' Transferencias destino - 2do nivel 
                                If vCCC_ID_CLI <> Nothing Then
                                    Dim vControlTransferencia As Boolean = False
                                    Select Case pTDO_ID
                                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                                            If dgv.Name = "dgvDetalleOtros" Then
                                                vControlTransferencia = True
                                            Else
                                                vControlTransferencia = False
                                            End If
                                    End Select
                                    If Not vControlTransferencia Then
                                        CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                        vCCT_ID_DOC, _
                                                        vTDO_ID_DOC, _
                                                        vDTD_ID_DOC)
                                        Select Case CargoAbono
                                            Case "CARGO"
                                                If .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value = txtMON_ID_CCC.Text Then
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    vAbono = 0
                                                    vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    vAbono = 0
                                                    vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Case "ABONO"
                                                If .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value = txtMON_ID_CCC.Text Then
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    vCargo = 0
                                                    vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    vCargo = 0
                                                    vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                        End Select

                                        dgvMovimientoCajaBanco.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vCCO_ID,
                                                        vCUC_ID,
                                                        CDbl(txtTES_MONTO_TOTAL.Text),
                                                        vCCC_ID_CLI,
                                                        vCCT_ID,
                                                        txtTDO_ID.Text,
                                                        txtDTD_ID.Text,
                                                        Strings.Trim(txtTES_SERIE.Text),
                                                        Strings.Trim(txtTES_NUMERO.Text),
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vPER_ID_BAN,
                                                        vPER_ID_CLI,
                                                        txtCCC_ID.Text,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOC,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vDTE_OBSERVACIONES,
                                                        txtCCC_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text & Strings.Trim(txtTES_SERIE.Text) & Strings.Trim(txtTES_NUMERO.Text),
                                                        vTipoPago)
                                        vCargo = 0
                                        vAbono = 0
                                        vContraValor = 0
                                    End If
                                End If

                                ' Planilla de rendición de cuentas, liquidación de documentos - 2do nivel
                                If .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString = BCVariablesNames.Movimiento.Movimiento2 Or _
                                   .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString = BCVariablesNames.Movimiento.Movimiento3 Then

                                    'vDTE_OBSERVACIONES = .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value '+ "Planilla rendición de cuentas, liquidación de documentos - 2do nivel"


                                    ''''''''
                                    If vFilGrid = 0 Then
                                        vCCT_IDTemp1 = vCCT_ID_DOC
                                        vTDO_IDTemp1 = vTDO_ID_DOC
                                        vDTD_IDTemp1 = vDTD_ID_DOC
                                        vCargoAbonoTemp1 = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC, _
                                                                        vTDO_ID_DOC, _
                                                                        vDTD_ID_DOC)
                                    End If

                                    If vCCT_IDTemp1 <> vCCT_ID_DOC Or
                                       vTDO_IDTemp1 <> vTDO_ID_DOC Or
                                       vDTD_IDTemp1 <> vDTD_ID_DOC Then
                                        vCCT_IDTemp1 = vCCT_ID_DOC
                                        vTDO_IDTemp1 = vTDO_ID_DOC
                                        vDTD_IDTemp1 = vDTD_ID_DOC
                                        vCargoAbonoTemp1 = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC, _
                                                                        vTDO_ID_DOC, _
                                                                        vDTD_ID_DOC)
                                        CargoAbono = vCargoAbonoTemp1
                                    Else
                                        CargoAbono = vCargoAbonoTemp1
                                    End If
                                    '''''''

                                    'CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                    '                    vCCT_ID_DOC, _
                                    '                    vTDO_ID_DOC, _
                                    '                    vDTD_ID_DOC)

                                    Select Case CargoAbono
                                        Case "ABONO"
                                            vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            vAbono = 0
                                            vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                        Case "CARGO"
                                            vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            vCargo = 0
                                            vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                    End Select

                                    If Trim(.Cells("cMPT_MEDIO_PAGO" & vIdentificadorDgv).Value) = BCVariablesNames.MedioPago.MedioPago4 Then
                                        If vCargo = 0 Then
                                            vDTE_OBSERVACIONES = "Se abono: " & txtMON_SIMBOLO_CCC.Text & " " & _
                                                                FormatNumber(vAbono, 4) & " : " & _
                                                                .Cells("cCUC_ID" & vIdentificadorDgv).Value & " " & _
                                                                .Cells("cCUC_DESCRIPCION" & vIdentificadorDgv).Value & " - " & _
                                                                .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value
                                        Else
                                            vDTE_OBSERVACIONES = "Se Cargo: " & txtMON_SIMBOLO_CCC.Text & " " & _
                                                                FormatNumber(vCargo, 4) & " : " & _
                                                                .Cells("cCUC_ID" & vIdentificadorDgv).Value & " " & _
                                                                .Cells("cCUC_DESCRIPCION" & vIdentificadorDgv).Value & " - " & _
                                                                .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value
                                        End If
                                        vAbono = 0
                                        vCargo = 0
                                        vContraValor = 0
                                    End If

                                    If .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString = BCVariablesNames.Movimiento.Movimiento3 And _
                                        vCUC_ID <> "" Then
                                        dgvMovimientoCajaBanco.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vCCO_ID,
                                                        vCUC_ID,
                                                        CDbl(txtTES_MONTO_TOTAL.Text),
                                                        txtCCC_ID.Text,
                                                        .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value,
                                                        .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value,
                                                        .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value,
                                                        .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value,
                                                        .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value,
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vPER_ID_BAN,
                                                        vPER_ID_CLI,
                                                        txtCCC_ID.Text,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOC,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vDTE_OBSERVACIONES,
                                                        txtCCC_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text & Strings.Trim(txtTES_SERIE.Text) & Strings.Trim(txtTES_NUMERO.Text),
                                                        vTipoPago)
                                    Else
                                        If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                                            If BCVariablesNames.Movimiento.Movimiento2 = .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                               chkTES_ESTADO.CheckState = CheckState.Checked And _
                                               vCCC_ID_CLI = "" And _
                                               vCCO_ID <> "" And _
                                               vCUC_ID <> "" And _
                                               .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value = "" And _
                                                .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value <> "" Then
                                            Else
                                                dgvMovimientoCajaBanco.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vCCO_ID,
                                                        vCUC_ID,
                                                        CDbl(txtTES_MONTO_TOTAL.Text),
                                                        txtCCC_ID.Text,
                                                        vCCT_ID,
                                                        txtTDO_ID.Text,
                                                        txtDTD_ID.Text,
                                                        Strings.Trim(txtTES_SERIE.Text),
                                                        Strings.Trim(txtTES_NUMERO.Text),
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vPER_ID_BAN,
                                                        vPER_ID_CLI,
                                                        vCCC_ID_CLI,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOC,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vDTE_OBSERVACIONES,
                                                        txtCCC_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text & Strings.Trim(txtTES_SERIE.Text) & Strings.Trim(txtTES_NUMERO.Text),
                                                        vTipoPago)
                                            End If
                                        Else
                                            dgvMovimientoCajaBanco.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vCCO_ID,
                                                        vCUC_ID,
                                                        CDbl(txtTES_MONTO_TOTAL.Text),
                                                        txtCCC_ID.Text,
                                                        vCCT_ID,
                                                        txtTDO_ID.Text,
                                                        txtDTD_ID.Text,
                                                        Strings.Trim(txtTES_SERIE.Text),
                                                        Strings.Trim(txtTES_NUMERO.Text),
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vPER_ID_BAN,
                                                        vPER_ID_CLI,
                                                        vCCC_ID_CLI,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOC,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vDTE_OBSERVACIONES,
                                                        txtCCC_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text & Strings.Trim(txtTES_SERIE.Text) & Strings.Trim(txtTES_NUMERO.Text),
                                                        vTipoPago)
                                        End If
                                    End If
                                    vCargo = 0
                                    vAbono = 0
                                    vContraValor = 0
                                End If

                                ' Rendición de cuentas, liquidación de documentos - 3er nivel
                                If .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString = BCVariablesNames.Movimiento.Movimiento2 Or _
                                   .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString = BCVariablesNames.Movimiento.Movimiento3 Then
                                    ''''' ojit *
                                    'vDTE_OBSERVACIONES = .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value '+ "Rendición de cuentas, liquidación de documentos - 3er nivel"


                                    ''''''''
                                    If vFilGrid = 0 Then
                                        vCCT_IDTemp2 = vCCT_ID_DOC_1
                                        vTDO_IDTemp2 = vTDO_ID_DOC_1
                                        vDTD_IDTemp2 = vDTD_ID_DOC_1
                                        vCargoAbonoTemp2 = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC_1, _
                                                                        vTDO_ID_DOC_1, _
                                                                        vDTD_ID_DOC_1)
                                    End If

                                    If vCCT_IDTemp2 <> vCCT_ID_DOC_1 Or
                                       vTDO_IDTemp2 <> vTDO_ID_DOC_1 Or
                                       vDTD_IDTemp2 <> vDTD_ID_DOC_1 Then
                                        vCCT_IDTemp2 = vCCT_ID_DOC_1
                                        vTDO_IDTemp2 = vTDO_ID_DOC_1
                                        vDTD_IDTemp2 = vDTD_ID_DOC_1
                                        vCargoAbonoTemp2 = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC_1, _
                                                                        vTDO_ID_DOC_1, _
                                                                        vDTD_ID_DOC_1)
                                        CargoAbono = vCargoAbonoTemp2
                                    Else
                                        CargoAbono = vCargoAbonoTemp2
                                    End If
                                    '''''''


                                    'CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                    '                    vCCT_ID_DOC_1, _
                                    '                    vTDO_ID_DOC_1, _
                                    '                    vDTD_ID_DOC_1)

                                    If CargoAbono <> "" Then
                                        Select Case CargoAbono
                                            Case "ABONO"
                                                vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                                                vAbono = 0
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            Case "CARGO"
                                                vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                                                vCargo = 0
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                        End Select

                                        If Trim(vCUC_ID) <> "" Then
                                            vCargo = 0
                                            vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            vPER_ID_CLI_1 = vPER_ID_CLI
                                            vCCT_ID_DOC_1 = vCCT_ID
                                            vTDO_ID_DOC_1 = txtTDO_ID.Text
                                            vDTD_ID_DOC_1 = txtDTD_ID.Text
                                            vDTE_SERIE_DOC_1 = Strings.Trim(txtTES_SERIE.Text)
                                            vDTE_NUMERO_DOC_1 = Strings.Trim(txtTES_NUMERO.Text)
                                        End If

                                        If Trim(.Cells("cMPT_MEDIO_PAGO" & vIdentificadorDgv).Value) = BCVariablesNames.MedioPago.MedioPago4 Then
                                            If vCargo = 0 Then
                                                vDTE_OBSERVACIONES = "Se abono: " & txtMON_SIMBOLO_CCC.Text & " " & _
                                                                    FormatNumber(vAbono, 4) & " : " & _
                                                                    .Cells("cCUC_ID" & vIdentificadorDgv).Value & " " & _
                                                                    .Cells("cCUC_DESCRIPCION" & vIdentificadorDgv).Value & " - " & _
                                                                    .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value
                                            Else
                                                vDTE_OBSERVACIONES = "Se Cargo: " & txtMON_SIMBOLO_CCC.Text & " " & _
                                                                    FormatNumber(vCargo, 4) & " : " & _
                                                                    .Cells("cCUC_ID" & vIdentificadorDgv).Value & " " & _
                                                                    .Cells("cCUC_DESCRIPCION" & vIdentificadorDgv).Value & " - " & _
                                                                    .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value
                                            End If
                                            vAbono = 0
                                            vCargo = 0
                                            vContraValor = 0
                                        End If
                                        If .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString = BCVariablesNames.Movimiento.Movimiento3 And _
                                            vCUC_ID <> "" Then
                                        Else
                                            dgvMovimientoCajaBanco.Rows.Add(
                                                dtpTES_FECHA_EMI.Value,
                                                vCCO_ID,
                                                vCUC_ID,
                                                CDbl(txtTES_MONTO_TOTAL.Text),
                                                txtCCC_ID.Text,
                                                vCCT_ID,
                                                txtTDO_ID.Text,
                                                txtDTD_ID.Text,
                                                Strings.Trim(txtTES_SERIE.Text),
                                                Strings.Trim(txtTES_NUMERO.Text),
                                                vCargo,
                                                vAbono,
                                                CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value),
                                                vPER_ID_BAN,
                                                vPER_ID_CLI_1,
                                                vCCC_ID_CLI,
                                                vCCT_ID_DOC_1,
                                                vTDO_ID_DOC_1,
                                                vDTD_ID_DOC_1,
                                                vDTE_SERIE_DOC_1,
                                                vDTE_NUMERO_DOC_1,
                                                vDTE_OBSERVACIONES,
                                                txtCCC_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text & Strings.Trim(txtTES_SERIE.Text) & Strings.Trim(txtTES_NUMERO.Text),
                                                vTipoPago)
                                        End If
                                    End If
                                    vCargo = 0
                                    vAbono = 0
                                    vContraValor = 0
                                End If
                            Else
                                If vVoucherAnulado Then
                                    ''
                                    If .Cells("cCCO_ID" & vIdentificadorDgv).Value = "" Then
                                        vCCO_ID = Nothing
                                    Else
                                        vCCO_ID = .Cells("cCCO_ID" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cCUC_ID" & vIdentificadorDgv).Value = "" Then
                                        vCUC_ID = Nothing
                                    Else
                                        vCUC_ID = .Cells("cCUC_ID" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cCCT_ID" & vIdentificadorDgv).Value = "" Then
                                        vCCT_ID = Nothing
                                    Else
                                        vCCT_ID = .Cells("cCCT_ID" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value = "" Then
                                        vPER_ID_BAN = Nothing
                                    Else
                                        vPER_ID_BAN = .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cPER_ID_CLI" & vIdentificadorDgv).Value = "" Then
                                        vPER_ID_CLI = Nothing
                                    Else
                                        vPER_ID_CLI = .Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value = "" Then
                                        vCCC_ID_CLI = Nothing
                                    Else
                                        vCCC_ID_CLI = .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                        vCCT_ID_DOC = Nothing
                                    Else
                                        vCCT_ID_DOC = .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                        vTDO_ID_DOC = Nothing
                                    Else
                                        vTDO_ID_DOC = .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                        vDTD_ID_DOC = Nothing
                                    Else
                                        vDTD_ID_DOC = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value = "" Then
                                        vDTE_SERIE_DOC = Nothing
                                    Else
                                        vDTE_SERIE_DOC = .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value
                                    End If
                                    If .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value = "" Then
                                        vDTE_NUMERO_DOC = Nothing
                                    Else
                                        vDTE_NUMERO_DOC = .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value = "" Then
                                        vPER_ID_CLI_1 = Nothing
                                    Else
                                        vPER_ID_CLI_1 = .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                        vCCT_ID_DOC_1 = Nothing
                                    Else
                                        vCCT_ID_DOC_1 = .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value
                                    End If

                                    If .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                        vTDO_ID_DOC_1 = Nothing
                                    Else
                                        vTDO_ID_DOC_1 = .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value
                                    End If
                                    If .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                        vDTD_ID_DOC_1 = Nothing
                                    Else
                                        vDTD_ID_DOC_1 = .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value
                                    End If
                                    If .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value = "" Then
                                        vDTE_SERIE_DOC_1 = Nothing
                                    Else
                                        vDTE_SERIE_DOC_1 = .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value
                                    End If
                                    If .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value = "" Then
                                        vDTE_NUMERO_DOC_1 = Nothing
                                    Else
                                        vDTE_NUMERO_DOC_1 = .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value
                                    End If

                                    vDTE_OBSERVACIONES = Strings.Left(.Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value & " - " & .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value & " - " & .Cells("cCUC_DESCRIPCION" & vIdentificadorDgv).Value, 255)

                                    ' Documentos - Cobros, pagos, transferencias origen 
                                    If .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString <> BCVariablesNames.Movimiento.Movimiento2 And _
                                       .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString <> BCVariablesNames.Movimiento.Movimiento3 Then

                                        'vDTE_OBSERVACIONES = .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value '+ "Documentos - Cobros, pagos, transferencias origen"
                                        CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                            vCCT_ID, _
                                                            txtTDO_ID.Text, _
                                                            txtDTD_ID.Text)
                                        Select Case CargoAbono
                                            Case "ABONO"
                                                vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                vAbono = 0
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            Case "CARGO"
                                                vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                vCargo = 0
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                        End Select

                                        If dgv.Name = "dgvDetalleOtros" Then
                                            Try
                                                vSignoCuentaContable = Me.IBCBusqueda.SignoCuentaContable(CDbl(.Cells("cCUC_ID" & vIdentificadorDgv).Value))
                                                ErrorProvider1.SetError(tcoTipoRecibo, Nothing)
                                                ErrorProvider1.SetError(dgv, Nothing)
                                            Catch ex As Exception
                                                ErrorProvider1.SetError(tcoTipoRecibo, "Error")
                                                ErrorProvider1.SetError(dgv, "Error en cuenta contable")
                                                ProcesarMovimientoCajaBanco = False
                                                Return ProcesarMovimientoCajaBanco
                                                Exit Function
                                            End Try

                                            Select Case pTDO_ID
                                                Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                                                    vSignoCuentaContable = vSignoCuentaContable * -1
                                                Case BCVariablesNames.ProcesosCaja.CajaEgreso
                                                    If Strings.Left(.Cells("cCUC_ID" & vIdentificadorDgv).Value, 1) = 9 Then
                                                        vSignoCuentaContable = vSignoCuentaContable * -1
                                                    End If
                                                Case Else
                                            End Select
                                            '
                                            If dgvDetalle.Rows.Count = 0 And _
                                               dgvDetalleEntregas.Rows.Count = 0 Then
                                                vCargo = vCargo
                                                vAbono = vAbono
                                            Else
                                                vCargo = vCargo * vSignoCuentaContable
                                                vAbono = vAbono * vSignoCuentaContable
                                            End If
                                            '
                                            'vCargo = vCargo * vSignoCuentaContable
                                            'vAbono = vAbono * vSignoCuentaContable
                                        Else
                                            vSignoCuentaContable = 1
                                        End If

                                        dgvMovimientoCajaBanco.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vCCO_ID,
                                                        vCUC_ID,
                                                        0,
                                                        txtCCC_ID.Text,
                                                        vCCT_ID,
                                                        txtTDO_ID.Text,
                                                        txtDTD_ID.Text,
                                                        Strings.Trim(txtTES_SERIE.Text),
                                                        Strings.Trim(txtTES_NUMERO.Text),
                                                        0,
                                                        0,
                                                        0,
                                                        vPER_ID_BAN,
                                                        vPER_ID_CLI,
                                                        vCCC_ID_CLI,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOC,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vDTE_OBSERVACIONES,
                                                        txtCCC_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text & Strings.Trim(txtTES_SERIE.Text) & Strings.Trim(txtTES_NUMERO.Text),
                                                        vTipoPago)
                                        vCargo = 0
                                        vAbono = 0
                                        vContraValor = 0
                                    End If

                                    ' Transferencias destino - 2do nivel 
                                    If vCCC_ID_CLI <> Nothing Then
                                        'vDTE_OBSERVACIONES = .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value '+ "Transferencias destino - 2do nivel "
                                        CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                            vCCT_ID_DOC, _
                                                            vTDO_ID_DOC, _
                                                            vDTD_ID_DOC)
                                        Select Case CargoAbono
                                            Case "CARGO"
                                                If .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value = txtMON_ID_CCC.Text Then
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    vAbono = 0
                                                    vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    vAbono = 0
                                                    vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Case "ABONO"
                                                If .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value = txtMON_ID_CCC.Text Then
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    vCargo = 0
                                                    vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    vCargo = 0
                                                    vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                        End Select

                                        dgvMovimientoCajaBanco.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vCCO_ID,
                                                        vCUC_ID,
                                                        0,
                                                        vCCC_ID_CLI,
                                                        vCCT_ID,
                                                        txtTDO_ID.Text,
                                                        txtDTD_ID.Text,
                                                        Strings.Trim(txtTES_SERIE.Text),
                                                        Strings.Trim(txtTES_NUMERO.Text),
                                                        0,
                                                        0,
                                                        0,
                                                        vPER_ID_BAN,
                                                        vPER_ID_CLI,
                                                        txtCCC_ID.Text,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOC,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vDTE_OBSERVACIONES,
                                                        txtCCC_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text & Strings.Trim(txtTES_SERIE.Text) & Strings.Trim(txtTES_NUMERO.Text),
                                                        vTipoPago)
                                        vCargo = 0
                                        vAbono = 0
                                        vContraValor = 0
                                    End If
                                    ''
                                End If
                            End If
                        End With
                        vFilGrid += 1
                    End While
                End If
                vContadorDgv += 1
            End While
            Return ProcesarMovimientoCajaBanco
        End Function
        Private Sub ProcesarKardexCtaCte()
            Dim vContadorDgv As Integer = 4
            Dim vFlagProcesarContadorDgv As Boolean = False
            Dim vTipoPago As String = ""

            Dim vFilGrid As Integer = 0
            Dim vItem As Integer = 1
            Dim vFlagCrearRecibos As Boolean = False
            Dim vCorrelativoRecibo As Int16 = 0

            Dim CargoAbono As String = ""
            Dim SignoCargoAbono As String = ""
            Dim MovimientoCargoAbono As String = ""
            Dim vCargo As Double = 0
            Dim vAbono As Double = 0
            Dim vContraValor As Double = 0

            Dim vDOC_FECHA_VEN_REF As Date
            Dim vCUC_ID As String
            Dim vCCO_ID As String

            Dim vCCC_ID_CLI As String
            Dim vCCT_ID_DOC As String
            Dim vTDO_ID_DOC As String
            Dim vDTD_ID_DOC As String
            Dim vDTE_SERIE_DOC As String
            Dim vDTE_NUMERO_DOC As String
            Dim vMON_ID_CCC As String

            Dim vCCC_ID As String
            Dim vCCT_ID As String
            Dim vTDO_ID As String
            Dim vDTD_ID As String

            Dim vDTD_IDx As String
            Dim vDTD_ID_DOCx As String

            Dim vTES_SERIE As String
            Dim vTES_NUMERO As String
            Dim vMON_ID_DOC As String

            Dim vPER_ID_CLI As String
            Dim vMPT_MEDIO_PAGO As Int16
            Dim vPER_ID_BAN As String

            Dim vDTE_IMPORTE_DOC_1 As Double = 0
            Dim vDTE_CONTRAVALOR_DOC_1 As Double = 0

            Dim vCCT_ID_DOC_1 As String
            Dim vTDO_ID_DOC_1 As String
            Dim vDTD_ID_DOC_1 As String
            Dim vTES_SERIE_DOC_1 As String
            Dim vTES_NUMERO_DOC_1 As String
            Dim vMON_ID_DOC_1 As String
            Dim vPER_ID_CLI_1 As String

            Dim vCCT_ID_AnteriorDetelle As String = ""
            Dim vDO_ID_AnteriorDetalle As String = ""
            Dim vDTD_ID_AnteriorDetalle As String = ""

            Dim vCCT_IDTemp As String = ""
            Dim vTDO_IDTemp As String = ""
            Dim vDTD_IDTemp As String = ""
            Dim vCargoAbonoTemp As String = ""
            Dim vSignoCargoAbonoTemp As String = ""

            Dim vCCT_IDTemp1 As String = ""
            Dim vTDO_IDTemp1 As String = ""
            Dim vDTD_IDTemp1 As String = ""
            Dim vCargoAbonoTemp1 As String = ""
            Dim vSignoCargoAbonoTemp1 As String = ""

            Dim vCCT_IDTemp2 As String = ""
            Dim vTDO_IDTemp2 As String = ""
            Dim vDTD_IDTemp2 As String = ""
            Dim vCargoAbonoTemp2 As String = ""
            Dim vSignoCargoAbonoTemp2 As String = ""

            Dim dgv As DataGridView
            Dim vIdentificadorDgv As String

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    'If dgvDetalle.RowCount = 0 Then
                    '    If dgvDetalleTransferencias.RowCount > 0 Then
                    '        dgv = dgvDetalleTransferencias
                    '        vTipoPago = "Transferencias"
                    '    Else
                    '        dgv = dgvDetalle
                    '        vTipoPago = "Pagos"
                    '    End If
                    'Else
                    '    dgv = dgvDetalle
                    '    vTipoPago = "Pagos"
                    'End If
                    'vFlagProcesarContadorDgv = False
                    ' Si vale Nuevo
                    If dgvDetalle.RowCount = 0 And dgvDetalleEntregas.RowCount = 0 Then
                        If dgvDetalleTransferencias.RowCount > 0 Then
                            vTipoPago = "Pagos"
                            dgv = dgvDetalleTransferencias
                            vFlagProcesarContadorDgv = False
                        Else
                            vContadorDgv = 1 ''
                            vTipoPago = "Pagos"
                            dgv = dgvDetalle
                            vFlagProcesarContadorDgv = True ''
                        End If
                    Else
                        vContadorDgv = 1 ''
                        vTipoPago = "Pagos"
                        dgv = dgvDetalle
                        vFlagProcesarContadorDgv = True ''
                    End If
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso
                    vContadorDgv = 1
                    dgv = dgvDetalle
                    vTipoPago = "Pagos"
                    vFlagProcesarContadorDgv = True
                Case Else
                    dgv = dgvDetalle
                    vTipoPago = "Pagos"
                    vFlagProcesarContadorDgv = False
            End Select

            dgvKardexCtaCte.Rows.Clear()
            If chkTES_ESTADO.CheckState <> CheckState.Checked Then
                Exit Sub
            End If

            While vContadorDgv <= 4
                vFilGrid = 0

                If vFlagProcesarContadorDgv Then
                    Select Case vContadorDgv
                        Case 1
                            dgv = dgvDetalle
                            vTipoPago = "Pagos"
                        Case 2
                            dgv = dgvDetalleEntregas
                            vTipoPago = "Entregas"
                        Case 3
                            dgv = dgvDetalleOtros
                            vTipoPago = "Otros"
                        Case 4
                            dgv = dgvDetalleTransferencias
                            vTipoPago = "Transferencias"
                    End Select
                End If
                vIdentificadorDgv = ProcesarIdentificadorGrid(dgv)
                If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then
                    If dgv.Name = "dgvDetalleEntregas" Then
                        'If tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        '                        If cboTipoRecibo.Text = "ENTREGAS" Then
                        vFilGrid = 0
                        While (dgv.Rows.Count() > vFilGrid)
                            With dgv.Rows(vFilGrid)
                                If .Cells("cDTE_CAPITAL_DOC" & vIdentificadorDgv).Value <> 0 Or _
                                    .Cells("cDTE_INTERES_DOC" & vIdentificadorDgv).Value <> 0 Or _
                                    .Cells("cDTE_GASTOS_DOC" & vIdentificadorDgv).Value <> 0 Then
                                    vFlagCrearRecibos = True
                                    Exit While
                                End If
                            End With
                            vFilGrid += 1
                        End While
                    End If
                End If

                vIdentificadorDgv = ProcesarIdentificadorGrid(dgv)
                vFilGrid = 0
                If dgv.Rows.Count() > 0 Then
                    While (dgv.Rows.Count() > vFilGrid)
                        With dgv.Rows(vFilGrid)
                            If chkTES_ESTADO.CheckState = CheckState.Checked Then
                                vCorrelativoRecibo = vCorrelativoRecibo + 1
                                If IsDate(.Cells("cDTE_FEC_VEN" & vIdentificadorDgv).Value) Then
                                    vDOC_FECHA_VEN_REF = CDate(.Cells("cDTE_FEC_VEN" & vIdentificadorDgv).Value)
                                Else
                                    vDOC_FECHA_VEN_REF = CDate(dtpTES_FECHA_EMI.Value)
                                End If
                                If Year(vDOC_FECHA_VEN_REF) = 1 Then vDOC_FECHA_VEN_REF = CDate(dtpTES_FECHA_EMI.Value)

                                If .Cells("cCUC_ID" & vIdentificadorDgv).Value = "" Then
                                    vCUC_ID = Nothing
                                Else
                                    vCUC_ID = .Cells("cCUC_ID" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cCCO_ID" & vIdentificadorDgv).Value = "" Then
                                    vCCO_ID = Nothing
                                Else
                                    vCCO_ID = .Cells("cCCO_ID" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value = "" Then
                                    vCCC_ID_CLI = Nothing
                                Else
                                    vCCC_ID_CLI = .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                    vCCT_ID_DOC = Nothing
                                Else
                                    vCCT_ID_DOC = .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                    vTDO_ID_DOC = Nothing
                                Else
                                    vTDO_ID_DOC = .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value
                                End If

                                If dgv.Name = "dgvDetalleEntregas" Then
                                    If .Cells("cDTD_IDr" & vIdentificadorDgv).Value = "" Then
                                        vDTD_ID_DOC = Nothing
                                        vDTD_ID_DOCx = Nothing
                                    Else
                                        vDTD_ID_DOC = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value
                                        vDTD_ID_DOCx = .Cells("cDTD_IDr" & vIdentificadorDgv).Value
                                    End If
                                Else
                                    If .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                        vDTD_ID_DOC = Nothing
                                        vDTD_ID_DOCx = Nothing
                                    Else
                                        vDTD_ID_DOC = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value
                                        vDTD_ID_DOCx = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value
                                    End If
                                End If

                                If .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value = "" Then
                                    vDTE_SERIE_DOC = Nothing
                                Else
                                    vDTE_SERIE_DOC = .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value
                                End If
                                If .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value = "" Then
                                    vDTE_NUMERO_DOC = Nothing
                                Else
                                    If vFlagCrearRecibos = True Then
                                        vDTE_NUMERO_DOC = CInt(.Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value) & _
                                                         Strings.StrDup(10 - (Len(CStr(vCorrelativoRecibo)) + Len(CStr(CInt(.Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value)))), "0") & vCorrelativoRecibo
                                    Else
                                        vDTE_NUMERO_DOC = .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value
                                    End If
                                End If

                                If txtMON_ID_CCC.Text = "" Then
                                    vMON_ID_CCC = Nothing
                                Else
                                    vMON_ID_CCC = txtMON_ID_CCC.Text
                                End If

                                If .Cells("cCCC_ID" & vIdentificadorDgv).Value = "" Then
                                    vCCC_ID = Nothing
                                Else
                                    vCCC_ID = .Cells("cCCC_ID" & vIdentificadorDgv).Value
                                End If

                                If dgv.Name = "dgvDetalleEntregas" Then
                                    If .Cells("cCCT_ID" & vIdentificadorDgv).Value = "" Then
                                        vCCT_ID = Nothing
                                    Else
                                        vCCT_ID = .Cells("cCCT_ID" & vIdentificadorDgv).Value
                                    End If
                                Else
                                    If txtCCT_ID.Text = "" Then
                                        vCCT_ID = Nothing
                                    Else
                                        vCCT_ID = txtCCT_ID.Text
                                    End If
                                End If

                                If .Cells("cTDO_ID" & vIdentificadorDgv).Value = "" Then
                                    vTDO_ID = Nothing
                                Else
                                    vTDO_ID = .Cells("cTDO_ID" & vIdentificadorDgv).Value
                                End If

                                If dgv.Name = "dgvDetalleEntregas" Then
                                    If .Cells("cDTD_IDr" & vIdentificadorDgv).Value = "" Then
                                        vDTD_ID = Nothing
                                        vDTD_IDx = Nothing
                                    Else
                                        vDTD_ID = .Cells("cDTD_ID" & vIdentificadorDgv).Value
                                        vDTD_IDx = .Cells("cDTD_IDr" & vIdentificadorDgv).Value
                                    End If
                                Else
                                    If .Cells("cDTD_ID" & vIdentificadorDgv).Value = "" Then
                                        vDTD_ID = Nothing
                                        vDTD_IDx = Nothing
                                    Else
                                        vDTD_ID = .Cells("cDTD_ID" & vIdentificadorDgv).Value
                                        vDTD_IDx = .Cells("cDTD_ID" & vIdentificadorDgv).Value
                                    End If
                                End If

                                If .Cells("cDTE_SERIE" & vIdentificadorDgv).Value = "" Then
                                    vTES_SERIE = Nothing
                                Else
                                    vTES_SERIE = .Cells("cDTE_SERIE" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cDTE_NUMERO" & vIdentificadorDgv).Value = "" Then
                                    vTES_NUMERO = Nothing
                                Else
                                    vTES_NUMERO = .Cells("cDTE_NUMERO" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                    vMON_ID_DOC = Nothing
                                Else
                                    vMON_ID_DOC = .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cPER_ID_CLI" & vIdentificadorDgv).Value = "" Then
                                    vPER_ID_CLI = Nothing
                                Else
                                    vPER_ID_CLI = .Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value = "" Then
                                    vPER_ID_BAN = Nothing
                                Else
                                    vPER_ID_BAN = .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value
                                End If

                                '-----
                                If .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vCCT_ID_DOC_1 = Nothing
                                Else
                                    vCCT_ID_DOC_1 = .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vTDO_ID_DOC_1 = Nothing
                                Else
                                    vTDO_ID_DOC_1 = .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vDTD_ID_DOC_1 = Nothing
                                Else
                                    vDTD_ID_DOC_1 = .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vTES_SERIE_DOC_1 = Nothing
                                Else
                                    vTES_SERIE_DOC_1 = .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vTES_NUMERO_DOC_1 = Nothing
                                Else
                                    vTES_NUMERO_DOC_1 = .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                    vMON_ID_DOC_1 = Nothing
                                Else
                                    vMON_ID_DOC_1 = .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value
                                End If

                                If .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value = "" Then
                                    vPER_ID_CLI_1 = Nothing
                                Else
                                    vPER_ID_CLI_1 = .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value
                                End If
                                '-----

                                vMPT_MEDIO_PAGO = DevolverTiposCampos("MPT_MEDIO_PAGO", .Cells("cMPT_MEDIO_PAGO" & vIdentificadorDgv).Value.ToString, Compuesto2)

                                If cboTipoRecibo.Text = "OTROS" Then
                                    If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                                        '/* Caja */
                                        '/* Liquidación de documentos nivel 2 Con cuenta contable y centro de costos */
                                        '/* Abono */
                                        If BCVariablesNames.Movimiento.Movimiento2 = .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                           chkTES_ESTADO.CheckState = CheckState.Checked And _
                                           vCCC_ID_CLI = "" And _
                                           vCCO_ID <> "" And _
                                           vCUC_ID <> "" And _
                                           .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value = "" And _
                                           .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value <> "" Then

                                            CargoAbono = "ABONO"
                                            SignoCargoAbono = "+"

                                            If CargoAbono = "CARGO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                Else
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                vCargo = 0
                                            End If

                                            If CargoAbono = "ABONO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC_1 Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                vAbono = 0
                                            End If

                                            If vMON_ID_CCC <> vMON_ID_DOC_1 Then
                                                vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                                            Else
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value)
                                            End If

                                            dgvKardexCtaCte.Rows.Add(
                                                            dtpTES_FECHA_EMI.Value,
                                                            vDOC_FECHA_VEN_REF,
                                                            vCUC_ID,
                                                            vCCO_ID,
                                                            vCCC_ID_CLI,
                                                            vCCT_ID_DOC_1,
                                                            vTDO_ID_DOC_1,
                                                            vDTD_ID_DOC_1,
                                                            vTES_SERIE_DOC_1,
                                                            vTES_NUMERO_DOC_1,
                                                            vItem,
                                                            vMON_ID_CCC,
                                                            vCCC_ID,
                                                            vCCT_ID,
                                                            vTDO_ID,
                                                            vDTD_ID,
                                                            vTES_SERIE,
                                                            vTES_NUMERO,
                                                            vItem,
                                                            vMON_ID_DOC_1,
                                                            vPER_ID_CLI_1,
                                                            vCargo,
                                                            vAbono,
                                                            vContraValor,
                                                            vMPT_MEDIO_PAGO,
                                                            .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                            vPER_ID_BAN,
                                                            vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                            vTipoPago)
                                            vItem = vItem + 1
                                        End If

                                        '/* Caja */
                                        '/* Liquidación de documentos nivel 2 Con cuenta contable y centro de costos */
                                        '/* Abono */
                                        If BCVariablesNames.Movimiento.Movimiento2 = .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                           chkTES_ESTADO.CheckState = CheckState.Checked And _
                                           vCCC_ID_CLI = "" And _
                                           vCCO_ID <> "" And _
                                           vCUC_ID <> "" And _
                                           .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value <> "" And _
                                           .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value = "" Then

                                            CargoAbono = "CARGO"
                                            SignoCargoAbono = "+"

                                            If CargoAbono = "CARGO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                Else
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                vCargo = 0
                                            End If

                                            If CargoAbono = "ABONO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                vAbono = 0
                                            End If

                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            Else
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            End If

                                            dgvKardexCtaCte.Rows.Add(
                                                            dtpTES_FECHA_EMI.Value,
                                                            vDOC_FECHA_VEN_REF,
                                                            vCUC_ID,
                                                            vCCO_ID,
                                                            vCCC_ID_CLI,
                                                            vCCT_ID_DOC,
                                                            vTDO_ID_DOC,
                                                            vDTD_ID_DOC,
                                                            vDTE_SERIE_DOC,
                                                            vDTE_NUMERO_DOC,
                                                            vItem,
                                                            vMON_ID_CCC,
                                                            vCCC_ID,
                                                            vCCT_ID,
                                                            vTDO_ID,
                                                            vDTD_ID,
                                                            vTES_SERIE,
                                                            vTES_NUMERO,
                                                            vItem,
                                                            vMON_ID_DOC,
                                                            vPER_ID_CLI,
                                                            vCargo,
                                                            vAbono,
                                                            vContraValor,
                                                            vMPT_MEDIO_PAGO,
                                                            .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                            vPER_ID_BAN,
                                                            vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                            vTipoPago)
                                            vItem = vItem + 1
                                        End If
                                    End If
                                    'End If
                                ElseIf cboTipoRecibo.Text = "ENTREGAS" Or _
                                    (dgv.Name = "dgvDetalleEntregas" And pTDO_ID <> BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco) Then

                                    'If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then
                                    'If tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then

                                    '/* Caja */
                                    '/* Entregas, nivel 2 Con centro de costos */
                                    If BCVariablesNames.Movimiento.Movimiento4 <> .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                       chkTES_ESTADO.CheckState = CheckState.Checked And _
                                       vCCC_ID_CLI = "" And _
                                       vCCO_ID <> "" And _
                                       vCUC_ID = "" Then
                                        'OJITO

                                        '''*** 2016-05-05

                                        If vFilGrid = 0 Then
                                            vCCT_IDTemp2 = vCCT_ID_DOC
                                            vTDO_IDTemp2 = vTDO_ID_DOC
                                            vDTD_IDTemp2 = vDTD_ID_DOC
                                            vCargoAbonoTemp2 = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                            vCCT_ID_DOC, _
                                                                            vTDO_ID_DOC, _
                                                                            vDTD_ID_DOC)
                                            vSignoCargoAbonoTemp2 = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                            vCCT_ID_DOC, _
                                                                            vTDO_ID_DOC, _
                                                                            vDTD_ID_DOC)
                                        End If

                                        If vCCT_IDTemp2 <> vCCT_ID_DOC Or
                                           vTDO_IDTemp2 <> vTDO_ID_DOC Or
                                           vDTD_IDTemp2 <> vDTD_ID_DOC Then
                                            vCCT_IDTemp2 = vCCT_ID_DOC
                                            vTDO_IDTemp2 = vTDO_ID_DOC
                                            vDTD_IDTemp2 = vDTD_ID_DOC

                                            vCargoAbonoTemp2 = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                            vCCT_ID_DOC, _
                                                                            vTDO_ID_DOC, _
                                                                            vDTD_ID_DOC)
                                            vSignoCargoAbonoTemp2 = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                            vCCT_ID_DOC, _
                                                                            vTDO_ID_DOC, _
                                                                            vDTD_ID_DOC)
                                            CargoAbono = vCargoAbonoTemp2
                                            SignoCargoAbono = vSignoCargoAbonoTemp2
                                        Else
                                            CargoAbono = vCargoAbonoTemp2
                                            SignoCargoAbono = vSignoCargoAbonoTemp2
                                        End If

                                        '''***

                                        'CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                        '                            vCCT_ID_DOC, _
                                        '                            vTDO_ID_DOC, _
                                        '                            vDTD_ID_DOC)
                                        'SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                        '                            vCCT_ID_DOC, _
                                        '                            vTDO_ID_DOC, _
                                        '                            vDTD_ID_DOC)

                                        '''***
                                        If CargoAbono = "CARGO" Then
                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                End If
                                            Else
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                End If
                                            End If
                                        Else
                                            vCargo = 0
                                        End If

                                        If CargoAbono = "ABONO" Then
                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            Else
                                                vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            End If
                                        Else
                                            vAbono = 0
                                        End If

                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                            vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                        Else
                                            vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                        End If

                                        dgvKardexCtaCte.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vDOC_FECHA_VEN_REF,
                                                        vCUC_ID,
                                                        vCCO_ID,
                                                        vCCC_ID_CLI,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOCx,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vItem,
                                                        vMON_ID_CCC,
                                                        vCCC_ID,
                                                        vCCT_ID,
                                                        vTDO_ID,
                                                        vDTD_IDx,
                                                        vTES_SERIE,
                                                        vTES_NUMERO,
                                                        vItem,
                                                        vMON_ID_DOC,
                                                        vPER_ID_CLI,
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vMPT_MEDIO_PAGO,
                                                        .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                        vPER_ID_BAN,
                                                        vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                        vTipoPago)
                                        vItem = vItem + 1
                                    End If
                                    ''**
                                ElseIf dgv.Name = "dgvDetalleEntregas" And
                                       pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then

                                    '/* Caja */
                                    '/* Nota de Abono en letras */
                                    If BCVariablesNames.Movimiento.Movimiento4 <> .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                       chkTES_ESTADO.CheckState = CheckState.Checked And _
                                       vCCC_ID_CLI = "" And _
                                       vCCO_ID <> "" And _
                                       vCUC_ID = "" Then
                                        CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                    vCCT_ID_DOC, _
                                                                    vTDO_ID_DOC, _
                                                                    vDTD_ID_DOC)
                                        SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                    vCCT_ID_DOC, _
                                                                    vTDO_ID_DOC, _
                                                                    vDTD_ID_DOC)

                                        If CargoAbono = "CARGO" Then
                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                End If
                                            Else
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                End If
                                            End If
                                        Else
                                            vCargo = 0
                                        End If

                                        If CargoAbono = "ABONO" Then
                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            Else
                                                vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            End If
                                        Else
                                            vAbono = 0
                                        End If

                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                            vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                        Else
                                            vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                        End If

                                        dgvKardexCtaCte.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vDOC_FECHA_VEN_REF,
                                                        vCUC_ID,
                                                        vCCO_ID,
                                                        vCCC_ID_CLI,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOCx,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vItem,
                                                        vMON_ID_CCC,
                                                        vCCC_ID,
                                                        vCCT_ID,
                                                        vTDO_ID,
                                                        vDTD_IDx,
                                                        vTES_SERIE,
                                                        vTES_NUMERO,
                                                        vItem,
                                                        vMON_ID_DOC,
                                                        vPER_ID_CLI,
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vMPT_MEDIO_PAGO,
                                                        .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                        vPER_ID_BAN,
                                                        vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                        vTipoPago)
                                        vItem = vItem + 1
                                    End If
                                    ''**
                                ElseIf cboTipoRecibo.Text = "PAGOS" Then
                                    Dim mfff As Integer
                                    '/* Caja - 1er nivel */
                                    '/* Cobros, pagos, no se considera transferencias ni depositos/retiros de bancos */
                                    '/* DTE_IMPORTE_DOC se considera monto del documento por la relacion 1 a varios de la tabla_tesoreria  */
                                    '/* lado izquierdo - cabecera */
                                    If BCVariablesNames.Movimiento.Movimiento4 <> .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                       chkTES_ESTADO.CheckState = CheckState.Checked And _
                                       vCCC_ID_CLI = "" And _
                                       vCCO_ID = "" And _
                                       vCUC_ID = "" And _
                                       .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value = "" Then

                                        ' Se considera DTD_CARGO_ABONO ya que el documento principal controla el comportamiento
                                        ' Se considera DTE_IMPORTE_DOC porque el detalle es a varios documentos

                                        If (vCCT_ID <> vCCT_ID_AnteriorDetelle AndAlso _
                                            txtTDO_ID.Text <> vDO_ID_AnteriorDetalle AndAlso _
                                            vDTD_ID_AnteriorDetalle <> txtDTD_ID.Text) Then

                                            vCCT_ID_AnteriorDetelle = vCCT_ID
                                            vDO_ID_AnteriorDetalle = txtTDO_ID.Text
                                            vDTD_ID_AnteriorDetalle = txtDTD_ID.Text

                                            CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(vCCT_ID, _
                                                                                                       txtTDO_ID.Text, _
                                                                                                       txtDTD_ID.Text)

                                            SignoCargoAbono = Me.IBCRolOpeCtaCte.SignoCargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID, _
                                                                        txtTDO_ID.Text, _
                                                                        txtDTD_ID.Text)

                                            MovimientoCargoAbono = Me.IBCRolOpeCtaCte.MovimientoCargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID, _
                                                                        txtTDO_ID.Text, _
                                                                        txtDTD_ID.Text)


                                        End If

                                        If .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString <> BCVariablesNames.Movimiento.Movimiento6 Then
                                            If CargoAbono = "CARGO" Then
                                                If SignoCargoAbono = "+" Then
                                                    If vMON_ID_CCC <> vMON_ID_DOC Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    End If
                                                Else
                                                    If vMON_ID_CCC <> vMON_ID_DOC Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                If .Cells("cDTD_MOVIMIENTO_DOC" & vIdentificadorDgv).Value = BCVariablesNames.Movimiento.Movimiento1 Then
                                                    If SignoCargoAbono = "+" Then
                                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                                            vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                        Else
                                                            vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                        End If
                                                    Else
                                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                                            vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                        Else
                                                            vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                        End If
                                                    End If
                                                Else
                                                    vCargo = 0
                                                End If
                                            End If
                                        Else
                                            vCargo = 0
                                        End If


                                        If .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString = BCVariablesNames.Movimiento.Movimiento6 Then
                                            If CargoAbono = "ABONO" Then
                                                If SignoCargoAbono = "+" Then
                                                    If vMON_ID_CCC <> vMON_ID_DOC Then
                                                        vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    End If
                                                Else
                                                    If vMON_ID_CCC <> vMON_ID_DOC Then
                                                        vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    Else
                                                        vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            ElseIf CargoAbono = "CARGO" Then
                                                If SignoCargoAbono = "+" Then
                                                    If vMON_ID_CCC <> vMON_ID_DOC Then
                                                        vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    End If
                                                Else
                                                    If vMON_ID_CCC <> vMON_ID_DOC Then
                                                        vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    Else
                                                        vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                If .Cells("cDTD_MOVIMIENTO_DOC" & vIdentificadorDgv).Value = BCVariablesNames.Movimiento.Movimiento1 Or _
                                                   .Cells("cDTD_MOVIMIENTO_DOC" & vIdentificadorDgv).Value = BCVariablesNames.Movimiento.Movimiento5 Then
                                                    If SignoCargoAbono = "+" Then
                                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                                            vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                        Else
                                                            vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                        End If
                                                    Else
                                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                                            vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                        Else
                                                            vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                        End If
                                                    End If
                                                Else
                                                    vAbono = 0
                                                End If
                                            End If
                                        Else
                                            If CargoAbono = "ABONO" Then
                                                If SignoCargoAbono = "+" Then
                                                    If vMON_ID_CCC <> vMON_ID_DOC Then
                                                        vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    End If
                                                Else
                                                    If vMON_ID_CCC <> vMON_ID_DOC Then
                                                        vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    Else
                                                        vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                If .Cells("cDTD_MOVIMIENTO_DOC" & vIdentificadorDgv).Value = BCVariablesNames.Movimiento.Movimiento1 Or _
                                                   .Cells("cDTD_MOVIMIENTO_DOC" & vIdentificadorDgv).Value = BCVariablesNames.Movimiento.Movimiento5 Then
                                                    If SignoCargoAbono = "+" Then
                                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                                            vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                        Else
                                                            vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                        End If
                                                    Else
                                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                                            vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                        Else
                                                            vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                        End If
                                                    End If
                                                Else
                                                    vAbono = 0
                                                End If
                                            End If
                                        End If

                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                            vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                        Else
                                            vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                        End If

                                        dgvKardexCtaCte.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vDOC_FECHA_VEN_REF,
                                                        vCUC_ID,
                                                        vCCO_ID,
                                                        vCCC_ID_CLI,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOC,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vItem,
                                                        vMON_ID_CCC,
                                                        vCCC_ID,
                                                        vCCT_ID,
                                                        vTDO_ID,
                                                        vDTD_ID,
                                                        vTES_SERIE,
                                                        vTES_NUMERO,
                                                        vItem,
                                                        vMON_ID_DOC,
                                                        vPER_ID_CLI,
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vMPT_MEDIO_PAGO,
                                                        .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                        vPER_ID_BAN,
                                                        vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                        vTipoPago)
                                        vItem = vItem + 1
                                    End If

                                    '/* Caja */
                                    '/* Liquidación de documentos - Planilla de Rendición de cuentas nivel 2 */
                                    If BCVariablesNames.Movimiento.Movimiento4 <> .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                       chkTES_ESTADO.CheckState = CheckState.Checked And _
                                       vCCC_ID_CLI = "" And _
                                       vCCO_ID = "" And _
                                       vCUC_ID = "" And _
                                       .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value <> "" Then


                                        ''''
                                        If vFilGrid = 0 Then
                                            vCCT_IDTemp = vCCT_ID_DOC
                                            vTDO_IDTemp = vTDO_ID_DOC
                                            vDTD_IDTemp = vDTD_ID_DOC
                                            vCargoAbonoTemp = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                            vCCT_ID_DOC, _
                                                                            vTDO_ID_DOC, _
                                                                            vDTD_ID_DOC)

                                            vSignoCargoAbonoTemp = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                            vCCT_ID_DOC, _
                                                                            vTDO_ID_DOC, _
                                                                            vDTD_ID_DOC)
                                        End If

                                        If vCCT_IDTemp <> vCCT_ID_DOC Or
                                           vTDO_IDTemp <> vTDO_ID_DOC Or
                                           vDTD_IDTemp <> vDTD_ID_DOC Then
                                            vCCT_IDTemp = vCCT_ID_DOC
                                            vTDO_IDTemp = vTDO_ID_DOC
                                            vDTD_IDTemp = vDTD_ID_DOC
                                            vCargoAbonoTemp = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                            vCCT_ID_DOC, _
                                                                            vTDO_ID_DOC, _
                                                                            vDTD_ID_DOC)
                                            vSignoCargoAbonoTemp = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                            vCCT_ID_DOC, _
                                                                            vTDO_ID_DOC, _
                                                                            vDTD_ID_DOC)

                                            CargoAbono = vCargoAbonoTemp
                                            SignoCargoAbono = vSignoCargoAbonoTemp
                                        Else
                                            CargoAbono = vCargoAbonoTemp
                                            SignoCargoAbono = vSignoCargoAbonoTemp
                                        End If

                                        ''''


                                        'CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                        '                            vCCT_ID_DOC, _
                                        '                            vTDO_ID_DOC, _
                                        '                            vDTD_ID_DOC)

                                        'SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                        '                            vCCT_ID_DOC, _
                                        '                            vTDO_ID_DOC, _
                                        '                            vDTD_ID_DOC)

                                        If CargoAbono = "ABONO" Then
                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                End If
                                            Else
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                End If
                                            End If
                                        Else
                                            vCargo = 0
                                        End If

                                        If CargoAbono = "CARGO" Then
                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            Else
                                                vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            End If
                                        Else
                                            vAbono = 0
                                        End If

                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                            vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                        Else
                                            vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                        End If

                                        If CargoAbono = "CARGO" And vTDO_ID_DOC = BCVariablesNames.ProcesosFacturación.NotaCredito Then
                                            vCargo = vAbono
                                            vAbono = 0
                                        End If

                                        dgvKardexCtaCte.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vDOC_FECHA_VEN_REF,
                                                        vCUC_ID,
                                                        vCCO_ID,
                                                        vCCC_ID_CLI,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOC,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vItem,
                                                        vMON_ID_CCC,
                                                        vCCC_ID,
                                                        vCCT_ID,
                                                        vTDO_ID,
                                                        vDTD_ID,
                                                        vTES_SERIE,
                                                        vTES_NUMERO,
                                                        vItem,
                                                        vMON_ID_DOC,
                                                        vPER_ID_CLI,
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vMPT_MEDIO_PAGO,
                                                        .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                        vPER_ID_BAN,
                                                        vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                        vTipoPago)
                                        vItem = vItem + 1
                                    End If


                                    If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                                        '/* Caja */
                                        '/* Liquidación de documentos nivel 2 Con cuenta contable y centro de costos */
                                        '/* Abono */
                                        If BCVariablesNames.Movimiento.Movimiento2 = .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                           chkTES_ESTADO.CheckState = CheckState.Checked And _
                                           vCCC_ID_CLI = "" And _
                                           vCCO_ID <> "" And _
                                           vCUC_ID <> "" And _
                                           .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value = "" And _
                                           .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value <> "" Then

                                            CargoAbono = "ABONO"
                                            SignoCargoAbono = "+"
                                            If CargoAbono = "CARGO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                Else
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                vCargo = 0
                                            End If

                                            If CargoAbono = "ABONO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC_1 Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                vAbono = 0
                                            End If

                                            If vMON_ID_CCC <> vMON_ID_DOC_1 Then
                                                vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                                            Else
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value)
                                            End If

                                            dgvKardexCtaCte.Rows.Add(
                                                            dtpTES_FECHA_EMI.Value,
                                                            vDOC_FECHA_VEN_REF,
                                                            vCUC_ID,
                                                            vCCO_ID,
                                                            vCCC_ID_CLI,
                                                            vCCT_ID_DOC_1,
                                                            vTDO_ID_DOC_1,
                                                            vDTD_ID_DOC_1,
                                                            vTES_SERIE_DOC_1,
                                                            vTES_NUMERO_DOC_1,
                                                            vItem,
                                                            vMON_ID_CCC,
                                                            vCCC_ID,
                                                            vCCT_ID,
                                                            vTDO_ID,
                                                            vDTD_ID,
                                                            vTES_SERIE,
                                                            vTES_NUMERO,
                                                            vItem,
                                                            vMON_ID_DOC_1,
                                                            vPER_ID_CLI_1,
                                                            vCargo,
                                                            vAbono,
                                                            vContraValor,
                                                            vMPT_MEDIO_PAGO,
                                                            .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                            vPER_ID_BAN,
                                                            vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                            vTipoPago)
                                            vItem = vItem + 1
                                        End If

                                        '/* Caja */
                                        '/* Liquidación de documentos nivel 2 Con cuenta contable y centro de costos */
                                        '/* Abono */
                                        If BCVariablesNames.Movimiento.Movimiento2 = .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                           chkTES_ESTADO.CheckState = CheckState.Checked And _
                                           vCCC_ID_CLI = "" And _
                                           vCCO_ID <> "" And _
                                           vCUC_ID <> "" And _
                                           .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value <> "" And _
                                           .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value = "" Then

                                            CargoAbono = "CARGO"
                                            SignoCargoAbono = "+"

                                            If CargoAbono = "CARGO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                Else
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                vCargo = 0
                                            End If

                                            If CargoAbono = "ABONO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                vAbono = 0
                                            End If

                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            Else
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            End If

                                            dgvKardexCtaCte.Rows.Add(
                                                            dtpTES_FECHA_EMI.Value,
                                                            vDOC_FECHA_VEN_REF,
                                                            vCUC_ID,
                                                            vCCO_ID,
                                                            vCCC_ID_CLI,
                                                            vCCT_ID_DOC,
                                                            vTDO_ID_DOC,
                                                            vDTD_ID_DOC,
                                                            vDTE_SERIE_DOC,
                                                            vDTE_NUMERO_DOC,
                                                            vItem,
                                                            vMON_ID_CCC,
                                                            vCCC_ID,
                                                            vCCT_ID,
                                                            vTDO_ID,
                                                            vDTD_ID,
                                                            vTES_SERIE,
                                                            vTES_NUMERO,
                                                            vItem,
                                                            vMON_ID_DOC,
                                                            vPER_ID_CLI,
                                                            vCargo,
                                                            vAbono,
                                                            vContraValor,
                                                            vMPT_MEDIO_PAGO,
                                                            .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                            vPER_ID_BAN,
                                                            vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                            vTipoPago)
                                            vItem = vItem + 1
                                        End If
                                    End If

                                    If pTDO_ID <> BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                                        ' OJITO ACA
                                        '/* Caja */
                                        '/* Liquidación de documentos nivel 2 Con cuenta contable y centro de costos */
                                        If BCVariablesNames.Movimiento.Movimiento2 = .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                           chkTES_ESTADO.CheckState = CheckState.Checked And _
                                           vCCC_ID_CLI = "" And _
                                           vCCO_ID <> "" And _
                                           vCUC_ID <> "" And _
                                           .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value = "" Then

                                            If .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value <> "" Then
                                                CargoAbono = "CARGO"
                                                SignoCargoAbono = "+"
                                            End If

                                            If CargoAbono = "CARGO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                Else
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                vCargo = 0
                                            End If

                                            If CargoAbono = "ABONO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                vAbono = 0
                                            End If

                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            Else
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            End If

                                            dgvKardexCtaCte.Rows.Add(
                                                            dtpTES_FECHA_EMI.Value,
                                                            vDOC_FECHA_VEN_REF,
                                                            vCUC_ID,
                                                            vCCO_ID,
                                                            vCCC_ID_CLI,
                                                            vCCT_ID_DOC,
                                                            vTDO_ID_DOC,
                                                            vDTD_ID_DOC,
                                                            vDTE_SERIE_DOC,
                                                            vDTE_NUMERO_DOC,
                                                            vItem,
                                                            vMON_ID_CCC,
                                                            vCCC_ID,
                                                            vCCT_ID,
                                                            vTDO_ID,
                                                            vDTD_ID,
                                                            vTES_SERIE,
                                                            vTES_NUMERO,
                                                            vItem,
                                                            vMON_ID_DOC,
                                                            vPER_ID_CLI,
                                                            vCargo,
                                                            vAbono,
                                                            vContraValor,
                                                            vMPT_MEDIO_PAGO,
                                                            .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                            vPER_ID_BAN,
                                                            vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                            vTipoPago)
                                            vItem = vItem + 1
                                        End If
                                    End If

                                    If pTDO_ID = BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas Then
                                        '/* Caja */
                                        '/* Planilla de Rendición de cuentas nivel 2 Con centro de costos */
                                        If BCVariablesNames.Movimiento.Movimiento4 <> .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                           chkTES_ESTADO.CheckState = CheckState.Checked And _
                                           vCCC_ID_CLI = "" And _
                                           vCCO_ID <> "" And _
                                           vCUC_ID = "" And _
                                           .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value <> "" Then

                                            CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC, _
                                                                        vTDO_ID_DOC, _
                                                                        vDTD_ID_DOC)
                                            SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC, _
                                                                        vTDO_ID_DOC, _
                                                                        vDTD_ID_DOC)

                                            If CargoAbono = "CARGO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                Else
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                vCargo = 0
                                            End If

                                            If CargoAbono = "ABONO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                vAbono = 0
                                            End If

                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            Else
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            End If

                                            dgvKardexCtaCte.Rows.Add(
                                                            dtpTES_FECHA_EMI.Value,
                                                            vDOC_FECHA_VEN_REF,
                                                            vCUC_ID,
                                                            vCCO_ID,
                                                            vCCC_ID_CLI,
                                                            vCCT_ID_DOC,
                                                            vTDO_ID_DOC,
                                                            vDTD_ID_DOC,
                                                            vDTE_SERIE_DOC,
                                                            vDTE_NUMERO_DOC,
                                                            vItem,
                                                            vMON_ID_CCC,
                                                            vCCC_ID,
                                                            vCCT_ID,
                                                            vTDO_ID,
                                                            vDTD_ID,
                                                            vTES_SERIE,
                                                            vTES_NUMERO,
                                                            vItem,
                                                            vMON_ID_DOC,
                                                            vPER_ID_CLI,
                                                            vCargo,
                                                            vAbono,
                                                            vContraValor,
                                                            vMPT_MEDIO_PAGO,
                                                            .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                            vPER_ID_BAN,
                                                            vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                            vTipoPago)
                                            vItem = vItem + 1
                                        End If

                                        '/* Caja */
                                        '/* Planilla de Rendición de cuentas nivel 3 Con cuenta contable*/
                                        If BCVariablesNames.Movimiento.Movimiento4 <> .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                           chkTES_ESTADO.CheckState = CheckState.Checked And _
                                           vCCC_ID_CLI = "" And _
                                           vCUC_ID <> "" And _
                                           .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value <> "" Then

                                            CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC, _
                                                                        vTDO_ID_DOC, _
                                                                        vDTD_ID_DOC)
                                            SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC, _
                                                                        vTDO_ID_DOC, _
                                                                        vDTD_ID_DOC)

                                            If CargoAbono = "ABONO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                Else
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                vCargo = 0
                                            End If

                                            If CargoAbono = "CARGO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                vAbono = 0
                                            End If

                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            Else
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            End If

                                            dgvKardexCtaCte.Rows.Add(
                                                            dtpTES_FECHA_EMI.Value,
                                                            vDOC_FECHA_VEN_REF,
                                                            vCUC_ID,
                                                            vCCO_ID,
                                                            vCCC_ID_CLI,
                                                            .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value,
                                                            .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value,
                                                            .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value,
                                                            .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value,
                                                            .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value,
                                                            vItem,
                                                            .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value,
                                                            vCCC_ID,
                                                            vCCT_ID_DOC,
                                                            vTDO_ID_DOC,
                                                            vDTD_ID_DOC,
                                                            vDTE_SERIE_DOC,
                                                            vDTE_NUMERO_DOC,
                                                            vItem,
                                                            vMON_ID_CCC,
                                                            .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value,
                                                            vCargo,
                                                            vAbono,
                                                            vContraValor,
                                                            vMPT_MEDIO_PAGO,
                                                            .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                            vPER_ID_BAN,
                                                            vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                            vTipoPago)
                                            vItem = vItem + 1
                                        End If

                                        '/* Caja */
                                        '/* Planilla de Rendición de cuentas nivel 3 Con centro de costos*/
                                        If BCVariablesNames.Movimiento.Movimiento4 <> .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                           chkTES_ESTADO.CheckState = CheckState.Checked And _
                                           vCCC_ID_CLI = "" And _
                                           vCCO_ID <> "" And _
                                           vCUC_ID = "" And _
                                           .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value <> "" Then

                                            CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC, _
                                                                        vTDO_ID_DOC, _
                                                                        vDTD_ID_DOC)
                                            SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                        vCCT_ID_DOC, _
                                                                        vTDO_ID_DOC, _
                                                                        vDTD_ID_DOC)

                                            If CargoAbono = "ABONO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                Else
                                                    If SignoCargoAbono = "+" Then
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                    Else
                                                        vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                    End If
                                                End If
                                            Else
                                                vCargo = 0
                                            End If

                                            If CargoAbono = "CARGO" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                vAbono = 0
                                            End If

                                            If vMON_ID_CCC <> vMON_ID_DOC Then
                                                vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                            Else
                                                vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                            End If

                                            dgvKardexCtaCte.Rows.Add(
                                                            dtpTES_FECHA_EMI.Value,
                                                            vDOC_FECHA_VEN_REF,
                                                            vCUC_ID,
                                                            vCCO_ID,
                                                            vCCC_ID_CLI,
                                                            .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value,
                                                            .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value,
                                                            .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value,
                                                            .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value,
                                                            .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value,
                                                            vItem,
                                                            .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value,
                                                            vCCC_ID,
                                                            vCCT_ID_DOC,
                                                            vTDO_ID_DOC,
                                                            vDTD_ID_DOC,
                                                            vDTE_SERIE_DOC,
                                                            vDTE_NUMERO_DOC,
                                                            vItem,
                                                            vMON_ID_CCC,
                                                            .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value,
                                                            vCargo,
                                                            vAbono,
                                                            vContraValor,
                                                            vMPT_MEDIO_PAGO,
                                                            .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                            vPER_ID_BAN,
                                                            vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                            vTipoPago)
                                            vItem = vItem + 1
                                        End If

                                    End If



                                    '/* Caja */
                                    '/* Liquidación de documentos - Planilla de Rendición de cuentas nivel 3 */
                                    If chkTES_ESTADO.CheckState = CheckState.Checked And _
                                       vCCO_ID = "" And _
                                       vCUC_ID = "" And _
                                       .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value <> "" And _
                                       .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value = "" Then

                                        vDTE_IMPORTE_DOC_1 = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                                        vDTE_CONTRAVALOR_DOC_1 = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value)

                                        ''''
                                        ''''
                                        If vFilGrid = 0 Then
                                            vCCT_IDTemp1 = .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value
                                            vTDO_IDTemp1 = .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value
                                            vDTD_IDTemp1 = .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value
                                            vCargoAbonoTemp1 = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                            .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value, _
                                                                            .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value, _
                                                                            .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value)

                                            vSignoCargoAbonoTemp1 = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                            .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value, _
                                                                            .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value, _
                                                                            .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value)
                                        End If

                                        If vCCT_IDTemp1 <> .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value Or
                                           vTDO_IDTemp1 <> .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value Or
                                           vDTD_IDTemp1 <> .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value Then
                                            vCCT_IDTemp1 = .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value
                                            vTDO_IDTemp1 = .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value
                                            vDTD_IDTemp1 = .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value
                                            vCargoAbonoTemp1 = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                            .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value, _
                                                                            .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value, _
                                                                            .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value)
                                            vSignoCargoAbonoTemp1 = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                            .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value, _
                                                                            .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value, _
                                                                            .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value)

                                            CargoAbono = vCargoAbonoTemp1
                                            SignoCargoAbono = vSignoCargoAbonoTemp1
                                        Else
                                            CargoAbono = vCargoAbonoTemp1
                                            SignoCargoAbono = vSignoCargoAbonoTemp1
                                        End If
                                        ''''
                                        ''''

                                        'CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                        '                            .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value, _
                                        '                            .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value, _
                                        '                            .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value)
                                        'SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_D_1CargoAbonoRolOpeCtaCte(
                                        '                            .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value, _
                                        '                            .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value, _
                                        '                            .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value)

                                        If CargoAbono = "ABONO" Then
                                            If vMON_ID_CCC <> .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value Then
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = vDTE_CONTRAVALOR_DOC_1
                                                ElseIf SignoCargoAbono = "-" Then
                                                    vCargo = vDTE_CONTRAVALOR_DOC_1 * -1
                                                Else
                                                    vCargo = 0
                                                End If
                                            Else
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = vDTE_IMPORTE_DOC_1
                                                ElseIf SignoCargoAbono = "-" Then
                                                    vCargo = vDTE_IMPORTE_DOC_1 * -1
                                                Else
                                                    vCargo = 0
                                                End If
                                            End If
                                        Else
                                            vCargo = 0
                                        End If

                                        If CargoAbono = "CARGO" Then
                                            If vMON_ID_CCC <> .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value Then
                                                If SignoCargoAbono = "+" Then
                                                    vAbono = vDTE_CONTRAVALOR_DOC_1
                                                ElseIf SignoCargoAbono = "-" Then
                                                    vAbono = vDTE_CONTRAVALOR_DOC_1 * -1
                                                Else
                                                    vAbono = 0
                                                End If
                                            Else
                                                If SignoCargoAbono = "+" Then
                                                    vAbono = vDTE_IMPORTE_DOC_1
                                                ElseIf SignoCargoAbono = "-" Then
                                                    vAbono = vDTE_IMPORTE_DOC_1 * -1
                                                Else
                                                    vAbono = 0
                                                End If
                                            End If
                                        Else
                                            vAbono = 0
                                        End If

                                        If vMON_ID_CCC <> .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value Then
                                            vContraValor = vDTE_IMPORTE_DOC_1
                                        Else
                                            vContraValor = vDTE_CONTRAVALOR_DOC_1
                                        End If

                                        dgvKardexCtaCte.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vDOC_FECHA_VEN_REF,
                                                        vCUC_ID,
                                                        vCCO_ID,
                                                        vCCC_ID_CLI,
                                                        .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value,
                                                        .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value,
                                                        .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value,
                                                        .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value,
                                                        .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value,
                                                        vItem,
                                                        vMON_ID_CCC,
                                                        vCCC_ID,
                                                        vCCT_ID,
                                                        vTDO_ID,
                                                        vDTD_ID,
                                                        vTES_SERIE,
                                                        vTES_NUMERO,
                                                        vItem,
                                                        .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value,
                                                        .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value,
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vMPT_MEDIO_PAGO,
                                                        .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                        vPER_ID_BAN,
                                                        vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                        vTipoPago)
                                        vItem = vItem + 1
                                    End If

                                    '/* Caja */
                                    '/* movimientos solo de salida e ingreso (depósitos bancarios, retiros de bancos etc.)  Nivel 2 */
                                    If BCVariablesNames.Movimiento.Movimiento4 = .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString And _
                                       chkTES_ESTADO.CheckState = CheckState.Checked And _
                                       vCCC_ID_CLI = "" And _
                                       vCCO_ID = "" And _
                                       vCUC_ID = "" Then

                                        CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                    vCCT_ID_DOC, _
                                                                    vTDO_ID_DOC, _
                                                                    vDTD_ID_DOC)
                                        SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                    vCCT_ID_DOC, _
                                                                    vTDO_ID_DOC, _
                                                                    vDTD_ID_DOC)

                                        If CargoAbono = "ABONO" Then
                                            If SignoCargoAbono = "+" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                End If
                                            End If
                                        Else
                                            vCargo = 0
                                        End If

                                        If CargoAbono = "CARGO" Then
                                            If SignoCargoAbono = "+" Then
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                                                End If
                                            Else
                                                If vMON_ID_CCC <> vMON_ID_DOC Then
                                                    vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                                Else
                                                    vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                                End If
                                            End If
                                        Else
                                            vAbono = 0
                                        End If

                                        If vMON_ID_CCC <> vMON_ID_DOC Then
                                            vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value) * -1
                                        Else
                                            vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value) * -1
                                        End If

                                        dgvKardexCtaCte.Rows.Add(
                                                        dtpTES_FECHA_EMI.Value,
                                                        vDOC_FECHA_VEN_REF,
                                                        vCUC_ID,
                                                        vCCO_ID,
                                                        vCCC_ID_CLI,
                                                        vCCT_ID_DOC,
                                                        vTDO_ID_DOC,
                                                        vDTD_ID_DOC,
                                                        vDTE_SERIE_DOC,
                                                        vDTE_NUMERO_DOC,
                                                        vItem,
                                                        vMON_ID_CCC,
                                                        vCCC_ID,
                                                        vCCT_ID,
                                                        vTDO_ID,
                                                        vDTD_ID,
                                                        vTES_SERIE,
                                                        vTES_NUMERO,
                                                        vItem,
                                                        vMON_ID_DOC,
                                                        vPER_ID_CLI,
                                                        vCargo,
                                                        vAbono,
                                                        vContraValor,
                                                        vMPT_MEDIO_PAGO,
                                                        .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value,
                                                        vPER_ID_BAN,
                                                        vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO,
                                                        vTipoPago)
                                        vItem = vItem + 1
                                    End If
                                End If
                            End If
                        End With
                        vFilGrid += 1
                    End While
                End If
                vContadorDgv += 1
            End While
        End Sub
        Private Function ProcesarKardexCtaCtePlanillaRendicionCuentas() As Boolean
            ProcesarKardexCtaCtePlanillaRendicionCuentas = True
            Dim vFlagProcesarContadorDgv As Boolean = False
            Dim vTipoPago As String = ""

            Dim vFilGrid As Integer = 0
            Dim vFilGridPagos As Integer = 0
            Dim vFilGridPagosTemporal As Integer = 0
            Dim vItem As Integer = 1

            Dim CargoAbono As String = ""
            Dim SignoCargoAbono As String = ""

            Dim MovimientoCargoAbono As String = ""
            Dim vImporteDocumento As Double = 0
            Dim vCargo As Double = 0
            Dim vAbono As Double = 0
            Dim vContraValor As Double = 0

            Dim vFlagImporteEntrega As Boolean = False
            Dim vFlagImportePago As Boolean = False
            Dim vCargoPago As Double = 0
            Dim vAbonoPago As Double = 0
            Dim vCargoPagoGeneral As Double = 0
            Dim vAbonoPagoGeneral As Double = 0
            Dim vCargoPagoGeneralTemporal As Double = 0

            Dim vDOC_FECHA_VEN_REF As Date
            Dim vCUC_ID As String
            Dim vCCO_ID As String

            Dim vCCC_ID_CLI As String
            Dim vCCT_ID_DOC As String
            Dim vTDO_ID_DOC As String
            Dim vDTD_ID_DOC As String
            Dim vDTE_SERIE_DOC As String
            Dim vDTE_NUMERO_DOC As String
            Dim vMON_ID_CCC As String

            Dim vCCT_ID_ As String
            Dim vTDO_ID_ As String
            Dim vDTD_ID_ As String
            Dim vTES_SERIE_ As String
            Dim vTES_NUMERO_ As String

            Dim vCCC_ID As String
            Dim vCCT_ID As String
            Dim vTDO_ID As String
            Dim vDTD_ID As String

            Dim vDTD_IDx As String
            Dim vDTD_ID_DOCx As String

            Dim vTES_SERIE As String
            Dim vTES_NUMERO As String
            Dim vMON_ID_DOC As String

            Dim vPER_ID_CLI As String
            Dim vMPT_MEDIO_PAGO As Int16
            Dim vPER_ID_BAN As String

            Dim vDTE_IMPORTE_DOC_1 As Double = 0
            Dim vDTE_CONTRAVALOR_DOC_1 As Double = 0

            Dim vCCT_ID_DOC_1 As String
            Dim vTDO_ID_DOC_1 As String
            Dim vDTD_ID_DOC_1 As String
            Dim vTES_SERIE_DOC_1 As String
            Dim vTES_NUMERO_DOC_1 As String
            Dim vMON_ID_DOC_1 As String
            Dim vPER_ID_CLI_1 As String

            Dim vCCT_ID_AnteriorDetelle As String = ""
            Dim vDO_ID_AnteriorDetalle As String = ""
            Dim vDTD_ID_AnteriorDetalle As String = ""

            Dim vSignoCuentaContable As Integer = 0

            Dim vIdentificadorDgv As String
            Dim vIdentificadorDgvPagos As String

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    vFilGrid = 0
                    dgvEntregas.Rows.Clear()
                    If dgvDetalleEntregas.Rows.Count() > 0 Then
                        While (dgvDetalleEntregas.Rows.Count() > vFilGrid)
                            With dgvDetalleEntregas.Rows(vFilGrid)
                                dgvEntregas.Rows.Add(
                                            .Cells("cITEMe").Value,
                                            .Cells("cTDO_IDe").Value,
                                            .Cells("cDTD_IDe").Value,
                                            .Cells("cCCC_IDe").Value,
                                            .Cells("cDTE_SERIEe").Value,
                                            .Cells("cDTE_NUMEROe").Value,
                                            .Cells("cCCT_IDe").Value,
                                            .Cells("cCCT_DESCRIPCIONe").Value,
                                            .Cells("cCCC_ID_CLIe").Value,
                                            .Cells("cCCC_DESCRIPCION_CLIe").Value,
                                            .Cells("cPER_ID_CLIe").Value,
                                            .Cells("cPER_DESCRIPCION_CLIe").Value,
                                            .Cells("cDTE_FEC_VENe").Value,
                                            .Cells("cDTD_MOVIMIENTO_DOCe").Value,
                                            .Cells("cCCT_ID_DOCe").Value,
                                            .Cells("cTDO_ID_DOCe").Value,
                                            .Cells("cDTD_ID_DOCe").Value,
                                            .Cells("cDTE_SERIE_DOCe").Value,
                                            .Cells("cDTE_NUMERO_DOCe").Value,
                                            .Cells("cDTE_CAPITAL_DOCe").Value,
                                            .Cells("cDTE_INTERES_DOCe").Value,
                                            .Cells("cDTE_GASTOS_DOCe").Value,
                                            .Cells("cDTE_IMPORTE_DOCe").Value,
                                            .Cells("cDTE_CONTRAVALOR_DOCe").Value,
                                            .Cells("cMON_ID_DOCe").Value,
                                            .Cells("cMON_DESCRIPCION_DOCe").Value,
                                            .Cells("cDTE_DESTINOe").Value,
                                            .Cells("cCHE_IDe").Value,
                                            .Cells("cMPT_MEDIO_PAGOe").Value,
                                            .Cells("cMPT_IMPORTE_AFECTOe").Value,
                                            .Cells("cMPT_PORCENTAJEe").Value,
                                            .Cells("cMPT_SERIE_MEDIOe").Value,
                                            .Cells("cMPT_NUMERO_MEDIOe").Value,
                                            .Cells("cMPT_GIRADO_Ae").Value,
                                            .Cells("cMPT_CONCEPTOe").Value,
                                            .Cells("cPER_ID_BANe").Value,
                                            .Cells("cMPT_DIFERIDOe").Value,
                                            .Cells("cMPT_FECHA_DIFERIDOe").Value,
                                            .Cells("cMPT_RECEPCIONe").Value,
                                            .Cells("cMPT_UBICACIONe").Value,
                                            .Cells("cPER_ID_CLI_1e").Value,
                                            .Cells("cPER_DESCRIPCION_CLI_1e").Value,
                                            .Cells("cDTE_FEC_VEN_1e").Value,
                                            .Cells("cCCT_ID_DOC_1e").Value,
                                            .Cells("cTDO_ID_DOC_1e").Value,
                                            .Cells("cDTD_ID_DOC_1e").Value,
                                            .Cells("cDTE_SERIE_DOC_1e").Value,
                                            .Cells("cDTE_NUMERO_DOC_1e").Value,
                                            .Cells("cDTE_IMPORTE_DOC_1e").Value,
                                            .Cells("cDTE_CONTRAVALOR_DOC_1e").Value,
                                            .Cells("cMON_ID_DOC_1e").Value,
                                            .Cells("cMON_DESCRIPCION_DOC_1e").Value,
                                            .Cells("cCCO_IDe").Value,
                                            .Cells("cCCO_DESCRIPCIONe").Value,
                                            .Cells("cCUC_IDe").Value,
                                            .Cells("cCUC_DESCRIPCIONe").Value,
                                            .Cells("cDTE_OPE_CONTABLEe").Value,
                                            .Cells("cDTE_OBSERVACIONESe").Value,
                                            .Cells("cDTE_MOVIMIENTOe").Value,
                                            .Cells("cDTE_ESTADOe").Value,
                                            .Cells("cDTD_IDre").Value,
                                            .Cells("cEstadoRegistroe").Value)
                            End With
                            vFilGrid += 1
                        End While
                    End If

                    vFilGrid = 0
                    dgvDetallePagos.Rows.Clear()
                    If dgvDetalle.Rows.Count() > 0 Then
                        While (dgvDetalle.Rows.Count() > vFilGrid)
                            With dgvDetalle.Rows(vFilGrid)
                                dgvDetallePagos.Rows.Add(
                                            .Cells("cITEM").Value,
                                            .Cells("cTDO_ID").Value,
                                            .Cells("cDTD_ID").Value,
                                            .Cells("cCCC_ID").Value,
                                            .Cells("cDTE_SERIE").Value,
                                            .Cells("cDTE_NUMERO").Value,
                                            .Cells("cCCT_ID").Value,
                                            .Cells("cCCT_DESCRIPCION").Value,
                                            .Cells("cCCC_ID_CLI").Value,
                                            .Cells("cCCC_DESCRIPCION_CLI").Value,
                                            .Cells("cPER_ID_CLI").Value,
                                            .Cells("cPER_DESCRIPCION_CLI").Value,
                                            .Cells("cDTE_FEC_VEN").Value,
                                            .Cells("cDTD_MOVIMIENTO_DOC").Value,
                                            .Cells("cCCT_ID_DOC").Value,
                                            .Cells("cTDO_ID_DOC").Value,
                                            .Cells("cDTD_ID_DOC").Value,
                                            .Cells("cDTE_SERIE_DOC").Value,
                                            .Cells("cDTE_NUMERO_DOC").Value,
                                            .Cells("cDTE_CAPITAL_DOC").Value,
                                            .Cells("cDTE_INTERES_DOC").Value,
                                            .Cells("cDTE_GASTOS_DOC").Value,
                                            .Cells("cDTE_IMPORTE_DOC").Value,
                                            .Cells("cDTE_CONTRAVALOR_DOC").Value,
                                            .Cells("cMON_ID_DOC").Value,
                                            .Cells("cMON_DESCRIPCION_DOC").Value,
                                            .Cells("cDTE_DESTINO").Value,
                                            .Cells("cCHE_ID").Value,
                                            .Cells("cMPT_MEDIO_PAGO").Value,
                                            .Cells("cMPT_IMPORTE_AFECTO").Value,
                                            .Cells("cMPT_PORCENTAJE").Value,
                                            .Cells("cMPT_SERIE_MEDIO").Value,
                                            .Cells("cMPT_NUMERO_MEDIO").Value,
                                            .Cells("cMPT_GIRADO_A").Value,
                                            .Cells("cMPT_CONCEPTO").Value,
                                            .Cells("cPER_ID_BAN").Value,
                                            .Cells("cMPT_DIFERIDO").Value,
                                            .Cells("cMPT_FECHA_DIFERIDO").Value,
                                            .Cells("cMPT_RECEPCION").Value,
                                            .Cells("cMPT_UBICACION").Value,
                                            .Cells("cPER_ID_CLI_1").Value,
                                            .Cells("cPER_DESCRIPCION_CLI_1").Value,
                                            .Cells("cDTE_FEC_VEN_1").Value,
                                            .Cells("cCCT_ID_DOC_1").Value,
                                            .Cells("cTDO_ID_DOC_1").Value,
                                            .Cells("cDTD_ID_DOC_1").Value,
                                            .Cells("cDTE_SERIE_DOC_1").Value,
                                            .Cells("cDTE_NUMERO_DOC_1").Value,
                                            .Cells("cDTE_IMPORTE_DOC_1").Value,
                                            .Cells("cDTE_CONTRAVALOR_DOC_1").Value,
                                            .Cells("cMON_ID_DOC_1").Value,
                                            .Cells("cMON_DESCRIPCION_DOC_1").Value,
                                            .Cells("cCCO_ID").Value,
                                            .Cells("cCCO_DESCRIPCION").Value,
                                            .Cells("cCUC_ID").Value,
                                            .Cells("cCUC_DESCRIPCION").Value,
                                            .Cells("cDTE_OPE_CONTABLE").Value,
                                            .Cells("cDTE_OBSERVACIONES").Value,
                                            .Cells("cDTE_MOVIMIENTO").Value,
                                            .Cells("cDTE_ESTADO").Value,
                                            .Cells("cDTD_IDr").Value,
                                            .Cells("cEstadoRegistro").Value)
                            End With
                            vFilGrid += 1
                        End While
                    End If

                    vTipoPago = "Entregas"
                    vFlagProcesarContadorDgv = False
            End Select

            vFilGrid = 0
            If dgvDetalleOtros.Rows.Count() > 0 Then
                While (dgvDetalleOtros.Rows.Count() > vFilGrid)
                    With dgvDetalleOtros.Rows(vFilGrid)
                        Try
                            vSignoCuentaContable = Me.IBCBusqueda.SignoCuentaContable(CDbl(.Cells("cCUC_IDo" & vIdentificadorDgv).Value))
                            ErrorProvider1.SetError(tcoTipoRecibo, Nothing)
                            ErrorProvider1.SetError(dgvDetalleOtros, Nothing)
                        Catch ex As Exception
                            ErrorProvider1.SetError(tcoTipoRecibo, "Error")
                            ErrorProvider1.SetError(dgvDetalleOtros, "Error en cuenta contable")
                            ProcesarKardexCtaCtePlanillaRendicionCuentas = False
                            Return ProcesarKardexCtaCtePlanillaRendicionCuentas
                            Exit Function
                        End Try

                        If vSignoCuentaContable = 0 Then
                        Else
                            If CDbl(.Cells("cDTE_IMPORTE_DOCo").Value) * vSignoCuentaContable < 0 Then
                                dgvDetallePagos.Rows.Add(
                                            .Cells("cITEMo").Value,
                                            .Cells("cTDO_IDo").Value,
                                            .Cells("cDTD_IDo").Value,
                                            .Cells("cCCC_IDo").Value,
                                            .Cells("cDTE_SERIEo").Value,
                                            .Cells("cDTE_NUMEROo").Value,
                                            .Cells("cCCT_IDo").Value,
                                            .Cells("cCCT_DESCRIPCIONo").Value,
                                            .Cells("cCCC_ID_CLIo").Value,
                                            .Cells("cCCC_DESCRIPCION_CLIo").Value,
                                            .Cells("cPER_ID_CLIo").Value,
                                            .Cells("cPER_DESCRIPCION_CLIo").Value,
                                            .Cells("cDTE_FEC_VENo").Value,
                                            "NINGUNO",
                                            .Cells("cCCT_ID_DOCo").Value,
                                            .Cells("cTDO_ID_DOCo").Value,
                                            .Cells("cDTD_ID_DOCo").Value,
                                            .Cells("cDTE_SERIE_DOCo").Value,
                                            .Cells("cDTE_NUMERO_DOCo").Value,
                                            .Cells("cDTE_CAPITAL_DOCo").Value,
                                            .Cells("cDTE_INTERES_DOCo").Value,
                                            .Cells("cDTE_GASTOS_DOCo").Value,
                                            .Cells("cDTE_IMPORTE_DOCo").Value,
                                            .Cells("cDTE_CONTRAVALOR_DOCo").Value,
                                            .Cells("cMON_ID_DOCo").Value,
                                            .Cells("cMON_DESCRIPCION_DOCo").Value,
                                            .Cells("cDTE_DESTINOo").Value,
                                            .Cells("cCHE_IDo").Value,
                                            .Cells("cMPT_MEDIO_PAGOo").Value,
                                            .Cells("cMPT_IMPORTE_AFECTOo").Value,
                                            .Cells("cMPT_PORCENTAJEo").Value,
                                            .Cells("cMPT_SERIE_MEDIOo").Value,
                                            .Cells("cMPT_NUMERO_MEDIOo").Value,
                                            .Cells("cMPT_GIRADO_Ao").Value,
                                            .Cells("cMPT_CONCEPTOo").Value,
                                            .Cells("cPER_ID_BANo").Value,
                                            .Cells("cMPT_DIFERIDOo").Value,
                                            .Cells("cMPT_FECHA_DIFERIDOo").Value,
                                            .Cells("cMPT_RECEPCIONo").Value,
                                            .Cells("cMPT_UBICACIONo").Value,
                                            .Cells("cPER_ID_CLI_1o").Value,
                                            .Cells("cPER_DESCRIPCION_CLI_1o").Value,
                                            .Cells("cDTE_FEC_VEN_1o").Value,
                                            .Cells("cCCT_ID_DOC_1o").Value,
                                            .Cells("cTDO_ID_DOC_1o").Value,
                                            .Cells("cDTD_ID_DOC_1o").Value,
                                            .Cells("cDTE_SERIE_DOC_1o").Value,
                                            .Cells("cDTE_NUMERO_DOC_1o").Value,
                                            .Cells("cDTE_IMPORTE_DOC_1o").Value,
                                            .Cells("cDTE_CONTRAVALOR_DOC_1o").Value,
                                            .Cells("cMON_ID_DOC_1o").Value,
                                            .Cells("cMON_DESCRIPCION_DOC_1o").Value,
                                            .Cells("cCCO_IDo").Value,
                                            .Cells("cCCO_DESCRIPCIONo").Value,
                                            .Cells("cCUC_IDo").Value,
                                            .Cells("cCUC_DESCRIPCIONo").Value,
                                            .Cells("cDTE_OPE_CONTABLEo").Value,
                                            .Cells("cDTE_OBSERVACIONESo").Value,
                                            .Cells("cDTE_MOVIMIENTOo").Value,
                                            .Cells("cDTE_ESTADOo").Value,
                                            .Cells("cDTD_IDro").Value,
                                            .Cells("cEstadoRegistroo").Value)
                            Else
                                dgvEntregas.Rows.Add(
                                            .Cells("cITEMo").Value,
                                            .Cells("cTDO_IDo").Value,
                                            .Cells("cDTD_IDo").Value,
                                            .Cells("cCCC_IDo").Value,
                                            .Cells("cDTE_SERIEo").Value,
                                            .Cells("cDTE_NUMEROo").Value,
                                            .Cells("cCCT_IDo").Value,
                                            .Cells("cCCT_DESCRIPCIONo").Value,
                                            .Cells("cCCC_ID_CLIo").Value,
                                            .Cells("cCCC_DESCRIPCION_CLIo").Value,
                                            "",
                                            .Cells("cPER_DESCRIPCION_CLIo").Value,
                                            .Cells("cDTE_FEC_VENo").Value,
                                            "NINGUNO",
                                            "",
                                            "",
                                            "",
                                            "",
                                            "",
                                            .Cells("cDTE_CAPITAL_DOCo").Value,
                                            .Cells("cDTE_INTERES_DOCo").Value,
                                            .Cells("cDTE_GASTOS_DOCo").Value,
                                            0,
                                            0,
                                            .Cells("cMON_ID_DOCo").Value,
                                            "",
                                            .Cells("cDTE_DESTINOo").Value,
                                            .Cells("cCHE_IDo").Value,
                                            .Cells("cMPT_MEDIO_PAGOo").Value,
                                            .Cells("cMPT_IMPORTE_AFECTOo").Value,
                                            .Cells("cMPT_PORCENTAJEo").Value,
                                            .Cells("cMPT_SERIE_MEDIOo").Value,
                                            .Cells("cMPT_NUMERO_MEDIOo").Value,
                                            .Cells("cMPT_GIRADO_Ao").Value,
                                            .Cells("cMPT_CONCEPTOo").Value,
                                            .Cells("cPER_ID_BANo").Value,
                                            .Cells("cMPT_DIFERIDOo").Value,
                                            .Cells("cMPT_FECHA_DIFERIDOo").Value,
                                            .Cells("cMPT_RECEPCIONo").Value,
                                            .Cells("cMPT_UBICACIONo").Value,
                                            .Cells("cPER_ID_CLIo").Value,
                                            "",
                                            .Cells("cDTE_FEC_VENo").Value,
                                            .Cells("cCCT_ID_DOCo").Value,
                                            .Cells("cTDO_ID_DOCo").Value,
                                            .Cells("cDTD_ID_DOCo").Value,
                                            .Cells("cDTE_SERIE_DOCo").Value,
                                            .Cells("cDTE_NUMERO_DOCo").Value,
                                            .Cells("cDTE_IMPORTE_DOCo").Value,
                                            .Cells("cDTE_CONTRAVALOR_DOCo").Value,
                                            .Cells("cMON_ID_DOCo").Value,
                                            .Cells("cMON_DESCRIPCION_DOCo").Value,
                                            .Cells("cCCO_IDo").Value,
                                            .Cells("cCCO_DESCRIPCIONo").Value,
                                            .Cells("cCUC_IDo").Value,
                                            .Cells("cCUC_DESCRIPCIONo").Value,
                                            .Cells("cDTE_OPE_CONTABLEo").Value,
                                            .Cells("cDTE_OBSERVACIONESo").Value,
                                            .Cells("cDTE_MOVIMIENTOo").Value,
                                            .Cells("cDTE_ESTADOo").Value,
                                            .Cells("cDTD_IDro").Value,
                                            .Cells("cEstadoRegistroo").Value)
                            End If
                        End If
                    End With
                    vFilGrid += 1
                End While
            End If

            ''''
            dgvKardexCtaCte.Rows.Clear()
            If chkTES_ESTADO.CheckState <> CheckState.Checked Then
                Exit Function
            End If

            Dim _vCCT_ID_DOC As String
            Dim _vTDO_ID_DOC As String
            Dim _vDTD_ID_DOC As String
            Dim _vDTD_ID_DOCx As String
            Dim _vMON_ID_CCC As String
            Dim _vMON_ID_DOC As String
            Dim _vDTE_SERIE_DOC As String
            Dim _vDTE_NUMERO_DOC As String
            Dim _vPER_ID_CLI As String

            vFilGrid = 0
            vIdentificadorDgv = ProcesarIdentificadorGrid(dgvEntregas)
            vFilGridPagos = 0
            If dgvEntregas.Rows.Count() > 0 Then
                While (dgvEntregas.Rows.Count() > vFilGrid)
                    With dgvEntregas.Rows(vFilGrid)
                        If chkTES_ESTADO.CheckState = CheckState.Checked Then
                            If IsDate(.Cells("cDTE_FEC_VEN" & vIdentificadorDgv).Value) Then
                                vDOC_FECHA_VEN_REF = CDate(.Cells("cDTE_FEC_VEN" & vIdentificadorDgv).Value)
                            Else
                                vDOC_FECHA_VEN_REF = CDate(dtpTES_FECHA_EMI.Value)
                            End If
                            If Year(vDOC_FECHA_VEN_REF) = 1 Then vDOC_FECHA_VEN_REF = CDate(dtpTES_FECHA_EMI.Value)

                            If .Cells("cCUC_ID" & vIdentificadorDgv).Value = "" Then
                                vCUC_ID = Nothing
                            Else
                                vCUC_ID = .Cells("cCUC_ID" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cCCO_ID" & vIdentificadorDgv).Value = "" Then
                                vCCO_ID = Nothing
                            Else
                                vCCO_ID = .Cells("cCCO_ID" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value = "" Then
                                vCCC_ID_CLI = Nothing
                            Else
                                vCCC_ID_CLI = .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                vCCT_ID_DOC = Nothing
                            Else
                                vCCT_ID_DOC = .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                vTDO_ID_DOC = Nothing
                            Else
                                vTDO_ID_DOC = .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value
                            End If

                            If dgvEntregas.Name = "dgvEntregas" Then
                                If .Cells("cDTD_IDr" & vIdentificadorDgv).Value = "" Then
                                    vDTD_ID_DOC = Nothing
                                    vDTD_ID_DOCx = Nothing
                                Else
                                    vDTD_ID_DOC = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value
                                    vDTD_ID_DOCx = .Cells("cDTD_IDr" & vIdentificadorDgv).Value
                                End If
                            Else
                                If .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                    vDTD_ID_DOC = Nothing
                                    vDTD_ID_DOCx = Nothing
                                Else
                                    vDTD_ID_DOC = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value
                                    vDTD_ID_DOCx = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value
                                End If
                            End If

                            If .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value = "" Then
                                vDTE_SERIE_DOC = Nothing
                            Else
                                vDTE_SERIE_DOC = .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value = "" Then
                                vDTE_NUMERO_DOC = Nothing
                            Else
                                vDTE_NUMERO_DOC = .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value
                            End If

                            If txtMON_ID_CCC.Text = "" Then
                                vMON_ID_CCC = Nothing
                            Else
                                vMON_ID_CCC = txtMON_ID_CCC.Text
                            End If

                            If .Cells("cCCC_ID" & vIdentificadorDgv).Value = "" Then
                                vCCC_ID = Nothing
                            Else
                                vCCC_ID = .Cells("cCCC_ID" & vIdentificadorDgv).Value
                            End If

                            If dgvEntregas.Name = "dgvEntregas" Then
                                If .Cells("cCCT_ID" & vIdentificadorDgv).Value = "" Then
                                    vCCT_ID = Nothing
                                Else
                                    vCCT_ID = .Cells("cCCT_ID" & vIdentificadorDgv).Value
                                End If
                            Else
                                If txtCCT_ID.Text = "" Then
                                    vCCT_ID = Nothing
                                Else
                                    vCCT_ID = txtCCT_ID.Text
                                End If
                            End If

                            If .Cells("cTDO_ID" & vIdentificadorDgv).Value = "" Then
                                vTDO_ID = Nothing
                            Else
                                vTDO_ID = .Cells("cTDO_ID" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cDTD_ID" & vIdentificadorDgv).Value = "" Then
                                vDTD_ID = Nothing
                                vDTD_IDx = Nothing
                            Else
                                vDTD_ID = .Cells("cDTD_ID" & vIdentificadorDgv).Value
                                vDTD_IDx = .Cells("cDTD_ID" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cDTE_SERIE" & vIdentificadorDgv).Value = "" Then
                                vTES_SERIE = Nothing
                            Else
                                vTES_SERIE = .Cells("cDTE_SERIE" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cDTE_NUMERO" & vIdentificadorDgv).Value = "" Then
                                vTES_NUMERO = Nothing
                            Else
                                vTES_NUMERO = .Cells("cDTE_NUMERO" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value = "" Then
                                vMON_ID_DOC = Nothing
                            Else
                                vMON_ID_DOC = .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value = "" Then
                                vPER_ID_CLI = Nothing
                            Else
                                vPER_ID_CLI = .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value = "" Then
                                vPER_ID_BAN = Nothing
                            Else
                                vPER_ID_BAN = .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value
                            End If

                            '-----
                            If .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                vCCT_ID_DOC_1 = Nothing
                            Else
                                vCCT_ID_DOC_1 = .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                vTDO_ID_DOC_1 = Nothing
                            Else
                                vTDO_ID_DOC_1 = .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                vDTD_ID_DOC_1 = Nothing
                            Else
                                vDTD_ID_DOC_1 = .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value = "" Then
                                vTES_SERIE_DOC_1 = Nothing
                            Else
                                vTES_SERIE_DOC_1 = .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value = "" Then
                                vTES_NUMERO_DOC_1 = Nothing
                            Else
                                vTES_NUMERO_DOC_1 = .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value = "" Then
                                vMON_ID_DOC_1 = Nothing
                            Else
                                vMON_ID_DOC_1 = .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value
                            End If

                            If .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value = "" Then
                                vPER_ID_CLI_1 = Nothing
                            Else
                                vPER_ID_CLI_1 = .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value
                            End If
                            '-----
                            vImporteDocumento = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)

                            vMPT_MEDIO_PAGO = DevolverTiposCampos("MPT_MEDIO_PAGO", .Cells("cMPT_MEDIO_PAGO" & vIdentificadorDgv).Value.ToString, Compuesto2)

                            CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                        vCCT_ID_DOC_1, _
                                                        vTDO_ID_DOC_1, _
                                                        vDTD_ID_DOC_1)
                            SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                        vCCT_ID_DOC_1, _
                                                        vTDO_ID_DOC_1, _
                                                        vDTD_ID_DOC_1)

                            vFilGridPagos = vFilGridPagosTemporal

                            _vCCT_ID_DOC = ""
                            _vTDO_ID_DOC = ""
                            _vDTD_ID_DOC = ""
                            _vDTD_ID_DOCx = ""
                            _vMON_ID_CCC = ""
                            _vMON_ID_DOC = ""
                            _vDTE_SERIE_DOC = ""
                            _vDTE_NUMERO_DOC = ""
                            _vPER_ID_CLI = ""

                            If dgvDetallePagos.Rows.Count() > 0 Then
                                While (dgvDetallePagos.Rows.Count() > vFilGridPagos)
                                    With dgvDetallePagos.Rows(vFilGridPagos)
                                        vIdentificadorDgvPagos = ProcesarIdentificadorGrid(dgvDetallePagos)
                                        If .Cells("cCCT_ID_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                            _vCCT_ID_DOC = Nothing
                                        Else
                                            _vCCT_ID_DOC = .Cells("cCCT_ID_DOC" & vIdentificadorDgvPagos).Value
                                        End If

                                        If .Cells("cTDO_ID_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                            _vTDO_ID_DOC = Nothing
                                        Else
                                            _vTDO_ID_DOC = .Cells("cTDO_ID_DOC" & vIdentificadorDgvPagos).Value
                                        End If

                                        If .Cells("cDTD_ID_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                            _vDTD_ID_DOC = Nothing
                                            _vDTD_ID_DOCx = Nothing
                                        Else
                                            _vDTD_ID_DOC = .Cells("cDTD_ID_DOC" & vIdentificadorDgvPagos).Value
                                            _vDTD_ID_DOCx = .Cells("cDTD_ID_DOC" & vIdentificadorDgvPagos).Value
                                        End If

                                        If .Cells("cDTE_SERIE_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                            _vDTE_SERIE_DOC = Nothing
                                        Else
                                            _vDTE_SERIE_DOC = .Cells("cDTE_SERIE_DOC" & vIdentificadorDgvPagos).Value
                                        End If
                                        If .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                            _vDTE_NUMERO_DOC = Nothing
                                        Else
                                            _vDTE_NUMERO_DOC = .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgvPagos).Value
                                        End If

                                        If txtMON_ID_CCC.Text = "" Then
                                            _vMON_ID_CCC = Nothing
                                        Else
                                            _vMON_ID_CCC = txtMON_ID_CCC.Text
                                        End If

                                        If .Cells("cMON_ID_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                            _vMON_ID_DOC = Nothing
                                        Else
                                            _vMON_ID_DOC = .Cells("cMON_ID_DOC" & vIdentificadorDgvPagos).Value
                                        End If

                                        If .Cells("cPER_ID_CLI" & vIdentificadorDgvPagos).Value = "" Then
                                            _vPER_ID_CLI = Nothing
                                        Else
                                            _vPER_ID_CLI = .Cells("cPER_ID_CLI" & vIdentificadorDgvPagos).Value
                                        End If

                                        CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                                    _vCCT_ID_DOC, _
                                                                    _vTDO_ID_DOC, _
                                                                    _vDTD_ID_DOC)
                                        SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                                    _vCCT_ID_DOC, _
                                                                    _vTDO_ID_DOC, _
                                                                    _vDTD_ID_DOC)
                                        '''
                                        If CargoAbono = "ABONO" Then
                                            If _vMON_ID_CCC <> _vMON_ID_DOC Then
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgvPagos).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgvPagos).Value) * -1
                                                End If
                                            Else
                                                If SignoCargoAbono = "+" Then
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgvPagos).Value)
                                                Else
                                                    vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgvPagos).Value) * -1
                                                End If
                                            End If
                                        Else
                                            vCargo = 0
                                        End If

                                        If CargoAbono = "CARGO" Then
                                            If _vMON_ID_CCC <> _vMON_ID_DOC Then
                                                vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgvPagos).Value)
                                            Else
                                                vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgvPagos).Value)
                                            End If
                                        Else
                                            vAbono = 0
                                        End If

                                        If _vMON_ID_CCC <> _vMON_ID_DOC Then
                                            vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgvPagos).Value)
                                        Else
                                            vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgvPagos).Value)
                                        End If
                                        vCargoPagoGeneralTemporal = vCargo
                                        vCargoPago = vCargo
                                        vAbonoPago = vAbono
                                        vCargoPagoGeneral = vCargoPagoGeneral + vImporteDocumento
                                        If vImporteDocumento <= vCargo Then
                                            vCargo = vImporteDocumento
                                            vCargoPago = vCargoPago - vCargo
                                            vImporteDocumento = vImporteDocumento - vCargo
                                            vFlagImportePago = False

                                            dgvKardexCtaCte.Rows.Add(dtpTES_FECHA_EMI.Value, vDOC_FECHA_VEN_REF, vCUC_ID, vCCO_ID, vCCC_ID_CLI, _vCCT_ID_DOC, _vTDO_ID_DOC, _vDTD_ID_DOC, _vDTE_SERIE_DOC, _vDTE_NUMERO_DOC, vItem, vMON_ID_CCC, vCCC_ID, vCCT_ID, vTDO_ID, vDTD_ID, vTES_SERIE, vTES_NUMERO, vItem, _vMON_ID_DOC, _vPER_ID_CLI, vCargo, vAbono, vContraValor, vMPT_MEDIO_PAGO, .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgvPagos).Value, vPER_ID_BAN, vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO, vTipoPago)
                                            vItem = vItem + 1

                                            dgvKardexCtaCte.Rows.Add(dtpTES_FECHA_EMI.Value, vDOC_FECHA_VEN_REF, vCUC_ID, vCCO_ID, vCCC_ID_CLI, vCCT_ID_DOC_1, vTDO_ID_DOC_1, vDTD_ID_DOC_1, vTES_SERIE_DOC_1, vTES_NUMERO_DOC_1, vItem, vMON_ID_CCC, vCCC_ID, vCCT_ID, vTDO_ID, vDTD_ID, vTES_SERIE, vTES_NUMERO, vItem, _vMON_ID_DOC, vPER_ID_CLI, vAbono, vCargo, vContraValor, vMPT_MEDIO_PAGO, .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgvPagos).Value, vPER_ID_BAN, vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO, vTipoPago)
                                            vItem = vItem + 1
                                        Else
                                            vCargoPago = vCargoPago - vCargo
                                            vImporteDocumento = vImporteDocumento - vCargo
                                            vFlagImportePago = True

                                            dgvKardexCtaCte.Rows.Add(dtpTES_FECHA_EMI.Value, vDOC_FECHA_VEN_REF, vCUC_ID, vCCO_ID, vCCC_ID_CLI, _vCCT_ID_DOC, _vTDO_ID_DOC, _vDTD_ID_DOC, _vDTE_SERIE_DOC, _vDTE_NUMERO_DOC, vItem, vMON_ID_CCC, vCCC_ID, vCCT_ID, vTDO_ID, vDTD_ID, vTES_SERIE, vTES_NUMERO, vItem, _vMON_ID_DOC, _vPER_ID_CLI, vCargo, vAbono, vContraValor, vMPT_MEDIO_PAGO, .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgvPagos).Value, vPER_ID_BAN, vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO, vTipoPago)
                                            vItem = vItem + 1

                                            dgvKardexCtaCte.Rows.Add(dtpTES_FECHA_EMI.Value, vDOC_FECHA_VEN_REF, vCUC_ID, vCCO_ID, vCCC_ID_CLI, vCCT_ID_DOC_1, vTDO_ID_DOC_1, vDTD_ID_DOC_1, vTES_SERIE_DOC_1, vTES_NUMERO_DOC_1, vItem, vMON_ID_CCC, vCCC_ID, vCCT_ID, vTDO_ID, vDTD_ID, vTES_SERIE, vTES_NUMERO, vItem, _vMON_ID_DOC, vPER_ID_CLI, vAbono, vCargo, vContraValor, vMPT_MEDIO_PAGO, .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgvPagos).Value, vPER_ID_BAN, vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO, vTipoPago)
                                            vItem = vItem + 1
                                        End If
                                    End With
                                    If vFlagImportePago Then
                                        vCargoPagoGeneral = 0
                                        vAbonoPagoGeneral = 0

                                        vFilGridPagos += 1
                                        vFilGridPagosTemporal = 0
                                    Else
                                        If vCargoPago > 0 Then
                                            vFilGridPagosTemporal = vFilGridPagos
                                            Exit While
                                        End If
                                    End If
                                End While
                            End If
                        End If
                    End With
                    vFilGrid += 1
                End While

                vCargoPagoGeneral = vCargoPagoGeneralTemporal - vCargoPagoGeneral
                Dim vFlagSaltarRegistro As Boolean = False
                If vCargoPagoGeneral > 0 Or _
                   dgvDetallePagos.Rows.Count() > vFilGridPagos Then
                    If vCargoPagoGeneral = 0 Then
                        vFilGridPagos += 1
                        vFlagSaltarRegistro = True
                        vImporteDocumento = 0
                    Else
                        vFlagSaltarRegistro = False
                        vImporteDocumento = vCargoPagoGeneral
                    End If

                    While (dgvDetallePagos.Rows.Count() > vFilGridPagos)
                        _vCCT_ID_DOC = ""
                        _vTDO_ID_DOC = ""
                        _vDTD_ID_DOC = ""
                        _vDTD_ID_DOCx = ""
                        _vMON_ID_CCC = ""
                        _vMON_ID_DOC = ""
                        _vDTE_SERIE_DOC = ""
                        _vDTE_NUMERO_DOC = ""
                        _vPER_ID_CLI = ""
                        With dgvDetallePagos.Rows(vFilGridPagos)
                            vIdentificadorDgvPagos = ProcesarIdentificadorGrid(dgvDetallePagos)
                            If .Cells("cCCT_ID_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                _vCCT_ID_DOC = Nothing
                            Else
                                _vCCT_ID_DOC = .Cells("cCCT_ID_DOC" & vIdentificadorDgvPagos).Value
                            End If

                            If .Cells("cTDO_ID_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                _vTDO_ID_DOC = Nothing
                            Else
                                _vTDO_ID_DOC = .Cells("cTDO_ID_DOC" & vIdentificadorDgvPagos).Value
                            End If

                            If .Cells("cDTD_ID_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                _vDTD_ID_DOC = Nothing
                                _vDTD_ID_DOCx = Nothing
                            Else
                                _vDTD_ID_DOC = .Cells("cDTD_ID_DOC" & vIdentificadorDgvPagos).Value
                                _vDTD_ID_DOCx = .Cells("cDTD_ID_DOC" & vIdentificadorDgvPagos).Value
                            End If

                            If .Cells("cDTE_SERIE_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                _vDTE_SERIE_DOC = Nothing
                            Else
                                _vDTE_SERIE_DOC = .Cells("cDTE_SERIE_DOC" & vIdentificadorDgvPagos).Value
                            End If
                            If .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                _vDTE_NUMERO_DOC = Nothing
                            Else
                                _vDTE_NUMERO_DOC = .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgvPagos).Value
                            End If

                            If txtMON_ID_CCC.Text = "" Then
                                _vMON_ID_CCC = Nothing
                            Else
                                _vMON_ID_CCC = txtMON_ID_CCC.Text
                            End If

                            If .Cells("cMON_ID_DOC" & vIdentificadorDgvPagos).Value = "" Then
                                _vMON_ID_DOC = Nothing
                            Else
                                _vMON_ID_DOC = .Cells("cMON_ID_DOC" & vIdentificadorDgvPagos).Value
                            End If

                            If .Cells("cPER_ID_CLI" & vIdentificadorDgvPagos).Value = "" Then
                                _vPER_ID_CLI = Nothing
                            Else
                                _vPER_ID_CLI = .Cells("cPER_ID_CLI" & vIdentificadorDgvPagos).Value
                            End If

                            CargoAbono = Me.IBCRolOpeCtaCte.CargoAbonoRolOpeCtaCte(
                                                        _vCCT_ID_DOC, _
                                                        _vTDO_ID_DOC, _
                                                        _vDTD_ID_DOC)
                            SignoCargoAbono = Me.IBCRolOpeCtaCte.Signo_DCargoAbonoRolOpeCtaCte(
                                                        _vCCT_ID_DOC, _
                                                        _vTDO_ID_DOC, _
                                                        _vDTD_ID_DOC)
                            If CargoAbono = "ABONO" Then
                                If _vMON_ID_CCC <> _vMON_ID_DOC Then
                                    If SignoCargoAbono = "+" Then
                                        If vFlagSaltarRegistro Then
                                            vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgvPagos).Value)
                                        Else
                                            vCargo = vImporteDocumento
                                        End If
                                    Else
                                        If vFlagSaltarRegistro Then
                                            vCargo = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgvPagos).Value) * -1
                                        Else
                                            vCargo = vImporteDocumento
                                        End If
                                    End If
                                Else
                                    If SignoCargoAbono = "+" Then
                                        If vFlagSaltarRegistro Then
                                            vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgvPagos).Value)
                                        Else
                                            vCargo = vImporteDocumento
                                        End If
                                    Else
                                        If vFlagSaltarRegistro Then
                                            vCargo = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgvPagos).Value) * -1
                                        Else
                                            vCargo = vImporteDocumento
                                        End If
                                    End If
                                End If
                            Else
                                vCargo = 0
                            End If

                            If CargoAbono = "CARGO" Then
                                If _vMON_ID_CCC <> _vMON_ID_DOC Then
                                    If vFlagSaltarRegistro Then
                                        vAbono = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgvPagos).Value)
                                    Else
                                        vAbono = vImporteDocumento
                                    End If
                                Else
                                    If vFlagSaltarRegistro Then
                                        vAbono = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgvPagos).Value)
                                    Else
                                        vAbono = vImporteDocumento
                                    End If

                                End If
                            Else
                                vAbono = 0
                            End If

                            If _vMON_ID_CCC <> _vMON_ID_DOC Then
                                If vFlagSaltarRegistro Then
                                    vContraValor = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgvPagos).Value)
                                Else
                                    vContraValor = vImporteDocumento
                                End If
                            Else
                                If vFlagSaltarRegistro Then
                                    vContraValor = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgvPagos).Value)
                                Else
                                    vContraValor = vImporteDocumento
                                End If
                            End If

                            dgvKardexCtaCte.Rows.Add(dtpTES_FECHA_EMI.Value, vDOC_FECHA_VEN_REF, vCUC_ID, vCCO_ID, vCCC_ID_CLI, _vCCT_ID_DOC, _vTDO_ID_DOC, _vDTD_ID_DOC, _vDTE_SERIE_DOC, _vDTE_NUMERO_DOC, vItem, vMON_ID_CCC, vCCC_ID, vCCT_ID, vTDO_ID, vDTD_ID, vTES_SERIE, vTES_NUMERO, vItem, _vMON_ID_DOC, _vPER_ID_CLI, vCargo, vAbono, vContraValor, vMPT_MEDIO_PAGO, .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgvPagos).Value, vPER_ID_BAN, vTDO_ID & vDTD_ID & vTES_SERIE & vTES_NUMERO, vTipoPago)
                            vItem = vItem + 1

                            dgvMovimientoCajaBanco.Rows.Add(
                                            dtpTES_FECHA_EMI.Value,
                                            vCCO_ID,
                                            vCUC_ID,
                                            CDbl(txtTES_MONTO_TOTAL.Text),
                                            BCVariablesNames.CCC_ID.CajaDefaul,
                                            vCCT_ID,
                                            txtTDO_ID.Text,
                                            txtDTD_ID.Text,
                                            Strings.Trim(txtTES_SERIE.Text),
                                            Strings.Trim(txtTES_NUMERO.Text),
                                            vAbono,
                                            vCargo,
                                            vContraValor,
                                            vPER_ID_BAN,
                                            vPER_ID_CLI,
                                            vCCC_ID_CLI,
                                            vCCT_ID_DOC,
                                            vTDO_ID_DOC,
                                            vDTD_ID_DOC,
                                            vDTE_SERIE_DOC,
                                            vDTE_NUMERO_DOC,
                                            "vDTE_OBSERVACIONES",
                                            txtCCC_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text & Strings.Trim(txtTES_SERIE.Text) & Strings.Trim(txtTES_NUMERO.Text),
                                            vTipoPago)
                        End With
                        vFlagSaltarRegistro = True
                        vFilGridPagos += 1
                    End While
                End If
            End If
            Return ProcesarKardexCtaCtePlanillaRendicionCuentas
        End Function

        '' ojito


        Private Sub ActualizarCorrelativoEnDetalle()
            Dim vContadorDgv As Integer = 4
            Dim vFlagProcesarContadorDgv As Boolean = False
            Dim vFilGrid As Integer = 0
            Dim dgv As New DataGridView
            Dim vIdentificadorDgv As String

            vContadorDgv = 1
            vFlagProcesarContadorDgv = True

            While vContadorDgv <= 4
                vFilGrid = 0
                If vFlagProcesarContadorDgv Then
                    Select Case vContadorDgv
                        Case 1
                            dgv = dgvDetalle
                        Case 2
                            dgv = dgvDetalleEntregas
                        Case 3
                            dgv = dgvDetalleOtros
                        Case 4
                            dgv = dgvDetalleTransferencias
                    End Select
                End If
                vIdentificadorDgv = ProcesarIdentificadorGrid(dgv)

                While (dgv.Rows.Count() > vFilGrid)
                    With dgv.Rows(vFilGrid)
                        .Cells("cDTE_NUMERO" & vIdentificadorDgv).Value = txtTES_NUMERO.Text
                    End With
                    vFilGrid += 1
                End While

                vContadorDgv += 1
            End While
        End Sub

        Private Function ProcesarDatosDetalle() As Int16
            Dim vContadorDgv As Integer = 4
            Dim vFlagProcesarContadorDgv As Boolean = False
            Dim vFilGrid As Integer = 0
            Dim dgv As New DataGridView
            Dim vIdentificadorDgv As String
            Dim vDTE_TIPO_RECIBO As Int16 = 0
            ProcesarDatosDetalle = 0

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    'If dgvDetalle.Rows.Count() = 0 Then
                    '    If dgvDetalleTransferencias.Rows.Count() = 0 Then
                    '        InicializarOrmDetalle()
                    '        If chkTES_ESTADO.Text = "ACTIVO" Then
                    '            MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                    '            Return ProcesarDatosDetalle
                    '        End If
                    '    Else
                    '        dgv = dgvDetalleTransferencias
                    '        vDTE_TIPO_RECIBO = 3
                    '    End If
                    'Else
                    '    dgv = dgvDetalle
                    '    vDTE_TIPO_RECIBO = 0
                    'End If
                    'vContadorDgv = 4
                    'vFlagProcesarContadorDgv = False

                    ' Si vale Nuevo
                    If dgvDetalle.Rows.Count() = 0 And dgvDetalleEntregas.RowCount = 0 Then
                        If dgvDetalleTransferencias.Rows.Count() = 0 Then
                            InicializarOrmDetalle()
                            If chkTES_ESTADO.Text = "ACTIVO" Then
                                MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                                Return ProcesarDatosDetalle
                            End If
                        Else
                            dgv = dgvDetalleTransferencias
                            vDTE_TIPO_RECIBO = 3
                            vContadorDgv = 4 ''
                            vFlagProcesarContadorDgv = False ''
                        End If
                    Else
                        dgv = dgvDetalle
                        vDTE_TIPO_RECIBO = 0
                        vContadorDgv = 1 ''
                        vFlagProcesarContadorDgv = True ''
                    End If
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso, _
                     BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas, _
                     BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    If dgvDetalle.Rows.Count = 0 And _
                       dgvDetalleEntregas.Rows.Count = 0 And _
                       dgvDetalleOtros.Rows.Count = 0 Then
                        InicializarOrmDetalle()
                        MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                        Return ProcesarDatosDetalle
                    End If
                    vContadorDgv = 1
                    vFlagProcesarContadorDgv = True
                Case Else
                    If dgvDetalle.Rows.Count() = 0 Then
                        InicializarOrmDetalle()
                        MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                        Return ProcesarDatosDetalle
                    End If
                    dgv = dgvDetalle
                    vDTE_TIPO_RECIBO = 0
                    vContadorDgv = 4
                    vFlagProcesarContadorDgv = False
            End Select

            While vContadorDgv <= 4
                '''
                vFilGrid = 0
                If vFlagProcesarContadorDgv Then
                    Select Case vContadorDgv
                        Case 1
                            dgv = dgvDetalle
                            vDTE_TIPO_RECIBO = 0
                        Case 2
                            dgv = dgvDetalleEntregas
                            vDTE_TIPO_RECIBO = 1
                        Case 3
                            dgv = dgvDetalleOtros
                            vDTE_TIPO_RECIBO = 2
                        Case 4
                            dgv = dgvDetalleTransferencias
                            vDTE_TIPO_RECIBO = 3
                    End Select
                End If
                vIdentificadorDgv = ProcesarIdentificadorGrid(dgv)

                While (dgv.Rows.Count() > vFilGrid)
                    With dgv.Rows(vFilGrid)
                        vMensajeErrorOrm = ""
                        InicializarOrmDetalle()

                        ' DetalleTesoreria
                        Compuesto1.TDO_ID = txtTDO_ID.Text
                        Compuesto1.DTD_ID = txtDTD_ID.Text
                        Compuesto1.CCC_ID = txtCCC_ID.Text
                        If Trim(.Cells("cCCT_ID" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.CCT_ID = Nothing
                        Else
                            Compuesto1.CCT_ID = .Cells("cCCT_ID" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cDTD_IDr" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DTD_IDe = Nothing
                        Else
                            Compuesto1.DTD_IDe = .Cells("cDTD_IDr" & vIdentificadorDgv).Value
                        End If
                        Compuesto1.DTE_SERIE = txtTES_SERIE.Text
                        Compuesto1.DTE_NUMERO = txtTES_NUMERO.Text
                        Compuesto1.DTE_ITEM = CDbl(.Cells("cITEM" & vIdentificadorDgv).Value)
                        If Trim(.Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.CCC_ID_CLI = Nothing
                        Else
                            Compuesto1.CCC_ID_CLI = .Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value
                        End If
                        Compuesto1.DTE_DESTINO = DevolverTiposCampos("DTE_DESTINO", .Cells("cDTE_DESTINO" & vIdentificadorDgv).Value.ToString, Compuesto1)

                        If Trim(.Cells("cCCO_ID" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.CCO_ID = Nothing
                        Else
                            Compuesto1.CCO_ID = .Cells("cCCO_ID" & vIdentificadorDgv).Value
                        End If

                        If Trim(.Cells("cCUC_ID" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.CUC_ID = Nothing
                        Else
                            Compuesto1.CUC_ID = .Cells("cCUC_ID" & vIdentificadorDgv).Value
                        End If

                        If Trim(.Cells("cPER_ID_CLI" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.PER_ID_CLI = Nothing
                        Else
                            Compuesto1.PER_ID_CLI = .Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.TDO_ID_DOC = Nothing
                        Else
                            Compuesto1.TDO_ID_DOC = .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DTD_ID_DOC = Nothing
                        Else
                            Compuesto1.DTD_ID_DOC = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.CCT_ID_DOC = Nothing
                        Else
                            Compuesto1.CCT_ID_DOC = .Cells("cCCT_ID_DOC" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DTE_SERIE_DOC = Nothing
                        Else
                            Compuesto1.DTE_SERIE_DOC = .Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DTE_NUMERO_DOC = Nothing
                        Else
                            Compuesto1.DTE_NUMERO_DOC = .Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value
                        End If

                        If Trim(.Cells("cDTE_FEC_VEN" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DTE_FEC_VEN = Now
                        Else
                            Compuesto1.DTE_FEC_VEN = Format(.Cells("cDTE_FEC_VEN" & vIdentificadorDgv).Value.ToString, "Short Date")
                        End If

                        Compuesto1.MON_ID_DOC = .Cells("cMON_ID_DOC" & vIdentificadorDgv).Value

                        Compuesto1.DTE_CAPITAL_DOC = CDbl(.Cells("cDTE_CAPITAL_DOC" & vIdentificadorDgv).Value)
                        Compuesto1.DTE_INTERES_DOC = CDbl(.Cells("cDTE_INTERES_DOC" & vIdentificadorDgv).Value)
                        Compuesto1.DTE_GASTOS_DOC = CDbl(.Cells("cDTE_GASTOS_DOC" & vIdentificadorDgv).Value)

                        Compuesto1.DTE_IMPORTE_DOC = CDbl(.Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv).Value)
                        Compuesto1.DTE_CONTRAVALOR_DOC = CDbl(.Cells("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv).Value)
                        If Trim(.Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.PER_ID_CLI_1 = Nothing
                        Else
                            Compuesto1.PER_ID_CLI_1 = .Cells("cPER_ID_CLI_1" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.TDO_ID_DOC_1 = Nothing
                        Else
                            Compuesto1.TDO_ID_DOC_1 = .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DTD_ID_DOC_1 = Nothing
                        Else
                            Compuesto1.DTD_ID_DOC_1 = .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.CCT_ID_DOC_1 = Nothing
                        Else
                            Compuesto1.CCT_ID_DOC_1 = .Cells("cCCT_ID_DOC_1" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DTE_SERIE_DOC_1 = Nothing
                        Else
                            Compuesto1.DTE_SERIE_DOC_1 = .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DTE_NUMERO_DOC_1 = Nothing
                        Else
                            Compuesto1.DTE_NUMERO_DOC_1 = .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cDTE_FEC_VEN_1" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DTE_FEC_VEN_1 = Now
                        Else
                            Compuesto1.DTE_FEC_VEN_1 = Format(.Cells("cDTE_FEC_VEN_1" & vIdentificadorDgv).Value.ToString, "Short Date")
                        End If

                        If Trim(.Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.MON_ID_DOC_1 = Nothing
                        Else
                            Compuesto1.MON_ID_DOC_1 = .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value
                        End If
                        Compuesto1.DTE_IMPORTE_DOC_1 = CDbl(.Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value)
                        Compuesto1.DTE_CONTRAVALOR_DOC_1 = CDbl(.Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value)
                        Compuesto1.DTE_OBSERVACIONES = .Cells("cDTE_OBSERVACIONES" & vIdentificadorDgv).Value
                        Compuesto1.DTE_OPE_CONTABLE = DevolverTiposCampos("DTE_OPE_CONTABLE", .Cells("cDTE_OPE_CONTABLE" & vIdentificadorDgv).Value.ToString, Compuesto1)
                        Compuesto1.DTE_MOVIMIENTO = DevolverTiposCampos("DTE_MOVIMIENTO", .Cells("cDTE_MOVIMIENTO" & vIdentificadorDgv).Value.ToString, Compuesto1)
                        Compuesto1.DTE_TIPO_RECIBO = vDTE_TIPO_RECIBO
                        Compuesto1.USU_ID = SessionService.UserId
                        Compuesto1.DTE_FEC_GRAB = Now
                        Compuesto1.DTE_ESTADO = DevolverTiposCampos(chkTES_ESTADO)

                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgv, vMensajeErrorOrm & " En fila: " & vFilGrid + 1)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If Not Validar(dgv, "Detalle", vFilGrid + 1) Then
                            Compuesto1.vMensajeError += " En fila: " & vFilGrid + 1
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If (.Cells("cEstadoRegistro" & vIdentificadorDgv).Value = 1 Or .Cells("cEstadoRegistro" & vIdentificadorDgv).Value = True) Then
                            ProcesarDatosDetalle = IBCDetalle.spActualizarRegistro(Compuesto1.TDO_ID, Compuesto1.DTD_ID, Compuesto1.CCC_ID, Compuesto1.CCT_ID, Compuesto1.DTE_SERIE, Compuesto1.DTE_NUMERO, Compuesto1.DTE_ITEM, Compuesto1.CCC_ID_CLI, Compuesto1.DTE_DESTINO, Compuesto1.CCO_ID, Compuesto1.CUC_ID, Compuesto1.PER_ID_CLI, Compuesto1.TDO_ID_DOC, Compuesto1.DTD_ID_DOC, Compuesto1.CCT_ID_DOC, Compuesto1.DTE_SERIE_DOC, Compuesto1.DTE_NUMERO_DOC, Compuesto1.DTE_FEC_VEN, Compuesto1.MON_ID_DOC, Compuesto1.DTE_IMPORTE_DOC, Compuesto1.DTE_CONTRAVALOR_DOC, Compuesto1.PER_ID_CLI_1, Compuesto1.TDO_ID_DOC_1, Compuesto1.DTD_ID_DOC_1, Compuesto1.CCT_ID_DOC_1, Compuesto1.DTE_SERIE_DOC_1, Compuesto1.DTE_NUMERO_DOC_1, Compuesto1.DTE_FEC_VEN_1, Compuesto1.MON_ID_DOC_1, Compuesto1.DTE_IMPORTE_DOC_1, Compuesto1.DTE_CONTRAVALOR_DOC_1, Compuesto1.DTE_OBSERVACIONES, Compuesto1.DTE_OPE_CONTABLE, Compuesto1.DTE_MOVIMIENTO, Compuesto1.DTE_TIPO_RECIBO, Compuesto1.DTE_CAPITAL_DOC, Compuesto1.DTE_INTERES_DOC, Compuesto1.DTE_GASTOS_DOC, Compuesto1.DTD_IDe, Compuesto1.USU_ID, Compuesto1.DTE_FEC_GRAB, Compuesto1.DTE_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Compuesto1.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        Else
                            ProcesarDatosDetalle = IBCDetalle.spInsertarRegistro(Compuesto1.TDO_ID, Compuesto1.DTD_ID, Compuesto1.CCC_ID, Compuesto1.CCT_ID, Compuesto1.DTE_SERIE, Compuesto1.DTE_NUMERO, Compuesto1.DTE_ITEM, Compuesto1.CCC_ID_CLI, Compuesto1.DTE_DESTINO, Compuesto1.CCO_ID, Compuesto1.CUC_ID, Compuesto1.PER_ID_CLI, Compuesto1.TDO_ID_DOC, Compuesto1.DTD_ID_DOC, Compuesto1.CCT_ID_DOC, Compuesto1.DTE_SERIE_DOC, Compuesto1.DTE_NUMERO_DOC, Compuesto1.DTE_FEC_VEN, Compuesto1.MON_ID_DOC, Compuesto1.DTE_IMPORTE_DOC, Compuesto1.DTE_CONTRAVALOR_DOC, Compuesto1.PER_ID_CLI_1, Compuesto1.TDO_ID_DOC_1, Compuesto1.DTD_ID_DOC_1, Compuesto1.CCT_ID_DOC_1, Compuesto1.DTE_SERIE_DOC_1, Compuesto1.DTE_NUMERO_DOC_1, Compuesto1.DTE_FEC_VEN_1, Compuesto1.MON_ID_DOC_1, Compuesto1.DTE_IMPORTE_DOC_1, Compuesto1.DTE_CONTRAVALOR_DOC_1, Compuesto1.DTE_OBSERVACIONES, Compuesto1.DTE_OPE_CONTABLE, Compuesto1.DTE_MOVIMIENTO, Compuesto1.DTE_TIPO_RECIBO, Compuesto1.DTE_CAPITAL_DOC, Compuesto1.DTE_INTERES_DOC, Compuesto1.DTE_GASTOS_DOC, Compuesto1.DTD_IDe, Compuesto1.USU_ID, Compuesto1.DTE_FEC_GRAB, Compuesto1.DTE_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Compuesto1.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        End If

                        ' Fin DetalleTesoreria

                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                                ProcesarDatosDetalle = Me.IBCKardexCtaCteDetracciones.spActualizarEstadoRegistroDetracciones(Compuesto1.CCT_ID_DOC, Compuesto1.TDO_ID_DOC, Compuesto1.DTD_ID_DOC, Compuesto1.DTE_SERIE_DOC, Compuesto1.DTE_NUMERO_DOC, False)
                                If ProcesarDatosDetalle = 0 Then
                                    vMensajeErrorOrm = Compuesto7.vMensajeError & " En fila: " & vFilGrid + 1
                                    Exit Function
                                End If
                        End Select

                        ' MedioPagoTesoreria
                        Compuesto2.TDO_ID = txtTDO_ID.Text
                        Compuesto2.DTD_ID = txtDTD_ID.Text
                        Compuesto2.CCC_ID = txtCCC_ID.Text
                        Compuesto2.MPT_SERIE = txtTES_SERIE.Text
                        Compuesto2.MPT_NUMERO = txtTES_NUMERO.Text
                        Compuesto2.MPT_ITEM = CDbl(.Cells("cITEM" & vIdentificadorDgv).Value)

                        Compuesto2.MPT_IMPORTE_AFECTO = CDbl(.Cells("cMPT_IMPORTE_AFECTO" & vIdentificadorDgv).Value)
                        Compuesto2.MPT_PORCENTAJE = CDbl(.Cells("cMPT_PORCENTAJE" & vIdentificadorDgv).Value)
                        If Trim(.Cells("cCHE_ID" & vIdentificadorDgv).Value) = "" Then
                            Compuesto2.CHE_ID = Nothing
                        Else
                            Compuesto2.CHE_ID = .Cells("cCHE_ID" & vIdentificadorDgv).Value
                        End If
                        Compuesto2.MPT_MEDIO_PAGO = DevolverTiposCampos("MPT_MEDIO_PAGO", .Cells("cMPT_MEDIO_PAGO" & vIdentificadorDgv).Value.ToString, Compuesto2)

                        If Trim(.Cells("cMPT_SERIE_MEDIO" & vIdentificadorDgv).Value) = "" Then
                            Compuesto2.MPT_SERIE_MEDIO = Nothing
                        Else
                            Compuesto2.MPT_SERIE_MEDIO = .Cells("cMPT_SERIE_MEDIO" & vIdentificadorDgv).Value
                        End If

                        If Trim(.Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value) = "" Then
                            Compuesto2.MPT_NUMERO_MEDIO = Nothing
                        Else
                            Compuesto2.MPT_NUMERO_MEDIO = .Cells("cMPT_NUMERO_MEDIO" & vIdentificadorDgv).Value
                        End If

                        If Trim(.Cells("cMPT_GIRADO_A" & vIdentificadorDgv).Value) = "" Then
                            Compuesto2.MPT_GIRADO_A = Nothing
                        Else
                            Compuesto2.MPT_GIRADO_A = .Cells("cMPT_GIRADO_A" & vIdentificadorDgv).Value
                        End If

                        If Trim(.Cells("cMPT_CONCEPTO" & vIdentificadorDgv).Value) = "" Then
                            Compuesto2.MPT_CONCEPTO = Nothing
                        Else
                            Compuesto2.MPT_CONCEPTO = .Cells("cMPT_CONCEPTO" & vIdentificadorDgv).Value
                        End If

                        Compuesto2.MPT_UBICACION = DevolverTiposCampos("MPT_UBICACION", .Cells("cMPT_UBICACION" & vIdentificadorDgv).Value.ToString, Compuesto2)

                        If Trim(.Cells("cPER_ID_BAN" & vIdentificadorDgv).Value) = "" Then
                            Compuesto2.PER_ID_BAN = Nothing
                        Else
                            Compuesto2.PER_ID_BAN = .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value
                        End If

                        Compuesto2.MPT_DIFERIDO = DevolverTiposCampos("MPT_DIFERIDO", .Cells("cMPT_DIFERIDO" & vIdentificadorDgv).Value.ToString, Compuesto2)

                        If Not IsDate(.Cells("cMPT_FECHA_DIFERIDO" & vIdentificadorDgv).Value) Then
                            Compuesto2.MPT_FECHA_DIFERIDO = Nothing
                        Else
                            Compuesto2.MPT_FECHA_DIFERIDO = Format(.Cells("cMPT_FECHA_DIFERIDO" & vIdentificadorDgv).Value, "Short Date")
                        End If

                        Compuesto2.MPT_RECEPCION = DevolverTiposCampos("MPT_RECEPCION", .Cells("cMPT_RECEPCION" & vIdentificadorDgv).Value.ToString, Compuesto2)

                        Compuesto2.USU_ID = SessionService.UserId
                        Compuesto2.MPT_FEC_GRAB = Now
                        Compuesto2.MPT_ESTADO = DevolverTiposCampos(chkTES_ESTADO)
                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgv, vMensajeErrorOrm & "En fila: " & vFilGrid + 1)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If Not Validar(dgv, "DetalleMedioPago", vFilGrid + 1) Then
                            Compuesto2.vMensajeError += " En fila: " & vFilGrid + 1
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If (.Cells("cEstadoRegistro" & vIdentificadorDgv).Value = 1 Or .Cells("cEstadoRegistro" & vIdentificadorDgv).Value = True) Then
                            ProcesarDatosDetalle = IBCMedioPago.spActualizarRegistro(Compuesto2.TDO_ID, Compuesto2.DTD_ID, Compuesto2.CCC_ID, Compuesto2.MPT_SERIE, Compuesto2.MPT_NUMERO, Compuesto2.MPT_ITEM, Compuesto2.MPT_IMPORTE_AFECTO, Compuesto2.MPT_PORCENTAJE, Compuesto2.CHE_ID, Compuesto2.MPT_MEDIO_PAGO, Compuesto2.MPT_SERIE_MEDIO, Compuesto2.MPT_NUMERO_MEDIO, Compuesto2.MPT_GIRADO_A, Compuesto2.MPT_CONCEPTO, Compuesto2.MPT_UBICACION, Compuesto2.PER_ID_BAN, Compuesto2.MPT_DIFERIDO, Compuesto2.MPT_FECHA_DIFERIDO, Compuesto2.MPT_RECEPCION, Compuesto2.USU_ID, Compuesto2.MPT_FEC_GRAB, Compuesto2.MPT_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Compuesto2.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        Else
                            ProcesarDatosDetalle = IBCMedioPago.spInsertarRegistro(Compuesto2.TDO_ID, Compuesto2.DTD_ID, Compuesto2.CCC_ID, Compuesto2.MPT_SERIE, Compuesto2.MPT_NUMERO, Compuesto2.MPT_ITEM, Compuesto2.MPT_IMPORTE_AFECTO, Compuesto2.MPT_PORCENTAJE, Compuesto2.CHE_ID, Compuesto2.MPT_MEDIO_PAGO, Compuesto2.MPT_SERIE_MEDIO, Compuesto2.MPT_NUMERO_MEDIO, Compuesto2.MPT_GIRADO_A, Compuesto2.MPT_CONCEPTO, Compuesto2.MPT_UBICACION, Compuesto2.PER_ID_BAN, Compuesto2.MPT_DIFERIDO, Compuesto2.MPT_FECHA_DIFERIDO, Compuesto2.MPT_RECEPCION, Compuesto2.USU_ID, Compuesto2.MPT_FEC_GRAB, Compuesto2.MPT_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Compuesto2.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        End If
                        '
                        Select Case Me.Name
                            Case "frmTransferenciaEntreCajas"
                            Case "frmDepositosBancarios"
                                If Compuesto2.MPT_ESTADO = True Then
                                    ProcesarDatosDetalle = Me.IBCMedioPago.spActualizarMPT_UBICACION(BCVariablesNames.ProcesosCaja.CajaIngreso, Compuesto2.CCC_ID, Compuesto2.PER_ID_BAN, Compuesto2.MPT_SERIE_MEDIO, Compuesto2.MPT_NUMERO_MEDIO, BCVariablesNames.UbicacionCodigo.Ubicacion2)
                                Else
                                    ProcesarDatosDetalle = Me.IBCMedioPago.spActualizarMPT_UBICACION(BCVariablesNames.ProcesosCaja.CajaIngreso, Compuesto2.CCC_ID, Compuesto2.PER_ID_BAN, Compuesto2.MPT_SERIE_MEDIO, Compuesto2.MPT_NUMERO_MEDIO, BCVariablesNames.UbicacionCodigo.Ubicacion1)
                                End If
                                If EliminarRegistroDetalle() = 0 Then
                                    vMensajeErrorOrm = Compuesto2.vMensajeError & " En fila: " & vFilGrid + 1
                                    Exit Function
                                End If
                        End Select

                        ' Fin MedioPagoTesoreria
                    End With
                    vFilGrid += 1
                End While
                    '''

                    vContadorDgv += 1
            End While

            vFilGrid = 0
            If dgvMovimientoCajaBanco.Rows.Count() = 0 Then
                InicializarOrmMovimientoCajaBanco()
                ProcesarDatosDetalle = 1
            Else
                While (dgvMovimientoCajaBanco.Rows.Count() > vFilGrid)
                    With dgvMovimientoCajaBanco.Rows(vFilGrid)
                        vMensajeErrorOrm = ""
                        InicializarOrmMovimientoCajaBanco()

                        ' Inicio MovimientoCajaBanco
                        Compuesto4.item = vFilGrid + 1
                        Compuesto4.Tes_Fecha_Emi = CDate(.Cells("cTES_FECHA_EMI2").Value)
                        Compuesto4.Cco_Id = .Cells("cCCO_ID2").Value
                        Compuesto4.Cuc_Id = .Cells("cCUC_ID2").Value
                        Compuesto4.Tes_Monto_total = CDbl(.Cells("cTES_MONTO_TOTAL2").Value)
                        Compuesto4.Ccc_Id = .Cells("cCCC_ID2").Value
                        Compuesto4.Cct_Id = .Cells("cCCT_ID2").Value
                        Compuesto4.Tdo_Id = .Cells("cTDO_ID2").Value
                        Compuesto4.Dtd_Id = .Cells("cDTD_ID2").Value
                        Compuesto4.Tes_Serie = .Cells("cTES_SERIE2").Value
                        Compuesto4.Tes_Numero = .Cells("cTES_NUMERO2").Value
                        Compuesto4.Cargo = CDbl(.Cells("cCargo2").Value)
                        Compuesto4.Abono = CDbl(.Cells("cAbono2").Value)
                        Compuesto4.Dte_ContraValor_Doc = CDbl(.Cells("cDTE_CONTRAVALOR_DOC2").Value)
                        Compuesto4.Per_Id_Ban = .Cells("cPER_ID_BAN2").Value
                        Compuesto4.Per_Id_Cli = .Cells("cPER_ID_CLI2").Value
                        Compuesto4.Ccc_Id_Cli = .Cells("cCCC_ID_CLI2").Value
                        'If cboTipoRecibo.Text = "PAGOS" Or UCase(.Cells("cTipoPago2").Value) = "PAGOS" Then
                        If UCase(.Cells("cTipoPago2").Value) = "PAGOS" Then
                            Compuesto4.Cct_Id_Doc = .Cells("cCCT_ID_DOC2").Value
                            Compuesto4.Tdo_Id_Doc = .Cells("cTDO_ID_DOC2").Value
                            Compuesto4.Dtd_Id_Doc = .Cells("cDTD_ID_DOC2").Value
                            Compuesto4.Dte_Serie_Doc = .Cells("cDTE_SERIE_DOC2").Value
                            Compuesto4.Dte_Numero_Doc = .Cells("cDTE_NUMERO_DOC2").Value
                            'ElseIf cboTipoRecibo.Text = "ENTREGAS" Or _
                            '      UCase(.Cells("cTipoPago2").Value) = "ENTREGAS" Or _
                            '     cboTipoRecibo.Text = "OTROS" Or _
                            '    UCase(.Cells("cTipoPago2").Value) = "OTROS" Then
                        ElseIf UCase(.Cells("cTipoPago2").Value) = "ENTREGAS" Or _
                               UCase(.Cells("cTipoPago2").Value) = "OTROS" Then
                            Compuesto4.Cct_Id_Doc = .Cells("cCCT_ID2").Value
                            Compuesto4.Tdo_Id_Doc = .Cells("cTDO_ID2").Value
                            Compuesto4.Dtd_Id_Doc = .Cells("cDTD_ID2").Value
                            Compuesto4.Dte_Serie_Doc = .Cells("cTES_SERIE2").Value
                            Compuesto4.Dte_Numero_Doc = .Cells("cTES_NUMERO2").Value
                        End If

                        Compuesto4.Dte_Observaciones = .Cells("cDTE_OBSERVACIONES2").Value
                        Compuesto4.DOCUMENTO = .Cells("cDOCUMENTO2").Value

                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgv, vMensajeErrorOrm)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If Not Validar(dgv, "DetalleMovimientoCajaBanco", vFilGrid + 1) Then
                            'Compuesto4.vMensajeError += " En fila: " & vFilGrid + 1
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        ProcesarDatosDetalle = IBCMovimientoCajaBanco.spInsertarRegistro(Compuesto4.item, Compuesto4.Tes_Fecha_Emi, Compuesto4.Cco_Id, Compuesto4.Cuc_Id, Compuesto4.Tes_Monto_total, Compuesto4.Ccc_Id, Compuesto4.Cct_Id, Compuesto4.Tdo_Id, Compuesto4.Dtd_Id, Compuesto4.Tes_Serie, Compuesto4.Tes_Numero, Compuesto4.Cargo, Compuesto4.Abono, Compuesto4.Dte_ContraValor_Doc, Compuesto4.Per_Id_Ban, Compuesto4.Per_Id_Cli, Compuesto4.Ccc_Id_Cli, Compuesto4.Cct_Id_Doc, Compuesto4.Tdo_Id_Doc, Compuesto4.Dtd_Id_Doc, Compuesto4.Dte_Serie_Doc, Compuesto4.Dte_Numero_Doc, Compuesto4.Dte_Observaciones, Compuesto4.DOCUMENTO)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto4.vMensajeError '& " En fila: " & vFilGrid + 1
                            Exit Function
                        End If

                        ' Fin MovimientoCajaBanco
                    End With
                    vFilGrid += 1
                End While

            End If

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

                        'If cboTipoRecibo.Text = "PAGOS" Then
                        If UCase(.Cells("cTipoPago3").Value) = "PAGOS" Then
                            Compuesto6.CCT_ID_REF = .Cells("cCCT_ID_REF3").Value
                            Compuesto6.TDO_ID_REF = .Cells("cTDO_ID_REF3").Value
                            Compuesto6.DTD_ID_REF = .Cells("cDTD_ID_REF3").Value
                            Compuesto6.DOC_SERIE_REF = .Cells("cDOC_SERIE_REF3").Value
                            Compuesto6.DOC_NUMERO_REF = .Cells("cDOC_NUMERO_REF3").Value
                            'ElseIf cboTipoRecibo.Text = "ENTREGAS" Or _
                            '  cboTipoRecibo.Text = "OTROS" Then
                        ElseIf UCase(.Cells("cTipoPago3").Value) = "ENTREGAS" Or _
                               UCase(.Cells("cTipoPago3").Value) = "OTROS" Then
                            If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then
                                'If cboTipoRecibo.Text = "ENTREGAS" Then
                                If UCase(.Cells("cTipoPago3").Value) = "ENTREGAS" Then
                                    Compuesto6.CCT_ID_REF = .Cells("cCCT_ID_REF3").Value
                                    Compuesto6.TDO_ID_REF = .Cells("cTDO_ID_REF3").Value
                                    Compuesto6.DTD_ID_REF = .Cells("cDTD_ID_REF3").Value
                                    Compuesto6.DOC_SERIE_REF = .Cells("cDOC_SERIE_REF3").Value
                                    Compuesto6.DOC_NUMERO_REF = .Cells("cDOC_NUMERO_REF3").Value
                                Else
                                    Compuesto6.CCT_ID_REF = .Cells("cCCT_ID3").Value
                                    Compuesto6.TDO_ID_REF = .Cells("cTDO_ID3").Value
                                    Compuesto6.DTD_ID_REF = .Cells("cDTD_ID3").Value
                                    Compuesto6.DOC_SERIE_REF = .Cells("cDOC_SERIE3").Value
                                    Compuesto6.DOC_NUMERO_REF = .Cells("cDOC_NUMERO3").Value
                                End If
                            ElseIf pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                                Compuesto6.CCT_ID_REF = .Cells("cCCT_ID_REF3").Value
                                Compuesto6.TDO_ID_REF = .Cells("cTDO_ID_REF3").Value
                                Compuesto6.DTD_ID_REF = .Cells("cDTD_ID_REF3").Value
                                Compuesto6.DOC_SERIE_REF = .Cells("cDOC_SERIE_REF3").Value
                                Compuesto6.DOC_NUMERO_REF = .Cells("cDOC_NUMERO_REF3").Value
                            ElseIf pTDO_ID = BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas Then
                                Compuesto6.CCT_ID_REF = .Cells("cCCT_ID_REF3").Value
                                Compuesto6.TDO_ID_REF = .Cells("cTDO_ID_REF3").Value
                                Compuesto6.DTD_ID_REF = .Cells("cDTD_ID_REF3").Value
                                Compuesto6.DOC_SERIE_REF = .Cells("cDOC_SERIE_REF3").Value
                                Compuesto6.DOC_NUMERO_REF = .Cells("cDOC_NUMERO_REF3").Value
                            Else
                                Compuesto6.CCT_ID_REF = .Cells("cCCT_ID3").Value
                                Compuesto6.TDO_ID_REF = .Cells("cTDO_ID3").Value
                                Compuesto6.DTD_ID_REF = .Cells("cDTD_ID3").Value
                                Compuesto6.DOC_SERIE_REF = .Cells("cDOC_SERIE3").Value
                                Compuesto6.DOC_NUMERO_REF = .Cells("cDOC_NUMERO3").Value
                            End If
                        End If

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
                            ErrorProvider1.SetError(dgv, vMensajeErrorOrm)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If Not Validar(dgv, "DetalleMovimientoCajaBanco", vFilGrid + 1) Then
                            'Compuesto6.vMensajeError += " En fila: " & vFilGrid + 1
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If

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

            Return ProcesarDatosDetalle
        End Function
        Private Function EliminarMovimientoCajaBanco(ByVal vItem As Integer)
            EliminarMovimientoCajaBanco = 0
            If vItem < 1 Then
                EliminarMovimientoCajaBanco = 1
            Else
                For fila = 1 To vItem
                    vMensajeErrorOrm = ""
                    InicializarOrmMovimientoCajaBanco()
                    'EliminarMovimientoCajaBanco = Me.IBCMovimientoCajaBanco.DeleteRegistro(Compuesto4, Compuesto.CCC_ID & Compuesto.TDO_ID & Compuesto.DTD_ID & Compuesto.TES_SERIE & Compuesto.TES_NUMERO, fila)
                    'EliminarMovimientoCajaBanco = Me.IBCMovimientoCajaBanco.spEliminarMovimientoCajaBanco(Compuesto.CCC_ID & Compuesto.TDO_ID & Compuesto.DTD_ID & Compuesto.TES_SERIE & Compuesto.TES_NUMERO, fila)
                    EliminarMovimientoCajaBanco = Me.IBCMovimientoCajaBanco.spEliminarRegistro(fila, Compuesto.CCC_ID & Compuesto.TDO_ID & Compuesto.DTD_ID & Compuesto.TES_SERIE & Compuesto.TES_NUMERO)
                    If EliminarMovimientoCajaBanco = 0 Then
                        vMensajeErrorOrm = Compuesto4.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarMovimientoCajaBanco
        End Function
        Private Function EliminarMovimientoCajaBancopep(ByVal vItem As Integer)
            EliminarMovimientoCajaBancopep = 0
            If vItem < 1 Then
                EliminarMovimientoCajaBancopep = 1
            Else
                For fila = 1 To vItem
                    vMensajeErrorOrm = ""
                    EliminarMovimientoCajaBancopep = Me.IBCMovimientoCajaBanco.spEliminarRegistro(fila, pCCC_IDpep & pTDO_IDpep & pDTD_IDpep & pTES_SERIEpep & pTES_NUMEROpep)
                    If EliminarMovimientoCajaBancopep = 0 Then
                        vMensajeErrorOrm = Compuesto4.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarMovimientoCajaBancopep
        End Function
        Private Function EliminarKardexCtaCte(ByVal vItem As Integer)
            EliminarKardexCtaCte = 0
            If vItem < 1 Then
                EliminarKardexCtaCte = 1
            Else
                For fila = 1 To vItem
                    vMensajeErrorOrm = ""
                    InicializarOrmKardexCtaCte()
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.VoucherCheque
                            EliminarKardexCtaCte = Me.IBCKardexCtaCte.spEliminarRegistroVoucher(fila, Compuesto.CCC_ID, Compuesto.TDO_ID & Compuesto.DTD_ID & Compuesto.TES_SERIE & Compuesto.TES_NUMERO)
                        Case Else
                            EliminarKardexCtaCte = Me.IBCKardexCtaCte.spEliminarRegistro(fila, Compuesto.TDO_ID & Compuesto.DTD_ID & Compuesto.TES_SERIE & Compuesto.TES_NUMERO)
                    End Select
                    If EliminarKardexCtaCte = 0 Then
                        vMensajeErrorOrm = Compuesto6.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarKardexCtaCte
        End Function
        Private Function EliminarKardexCtaCtepep(ByVal vItem As Integer)
            EliminarKardexCtaCtepep = 0
            If vItem < 1 Then
                EliminarKardexCtaCtepep = 1
            Else
                For fila = 1 To vItem
                    vMensajeErrorOrm = ""
                    EliminarKardexCtaCtepep = Me.IBCKardexCtaCte.spEliminarRegistro(fila, pTDO_IDpep & pDTD_IDpep & pTES_SERIEpep & pTES_NUMEROpep)
                    If EliminarKardexCtaCtepep = 0 Then
                        vMensajeErrorOrm = Compuesto6.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarKardexCtaCtepep
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

                    EliminarRegistroDetalle = Me.IBCMedioPago.spEliminarRegistro(eRegistrosEliminar(fila).cTDO_ID, eRegistrosEliminar(fila).cDTD_ID, eRegistrosEliminar(fila).cCCC_ID, eRegistrosEliminar(fila).cDTE_SERIE, eRegistrosEliminar(fila).cDTE_NUMERO, eRegistrosEliminar(fila).cDTE_ITEM)
                    If EliminarRegistroDetalle = 0 Then
                        vMensajeErrorOrm = Compuesto2.vMensajeError
                        Exit For
                    End If

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                            EliminarRegistroDetalle = Me.IBCKardexCtaCteDetracciones.spActualizarEstadoRegistroDetracciones(txtCCT_ID.Text, eRegistrosEliminarDocumento(fila).cTDO_ID, eRegistrosEliminarDocumento(fila).cDTD_ID, eRegistrosEliminarDocumento(fila).cDTE_SERIE, eRegistrosEliminarDocumento(fila).cDTE_NUMERO, True)
                            If EliminarRegistroDetalle = 0 Then
                                vMensajeErrorOrm = Compuesto7.vMensajeError
                                Exit For
                            End If
                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            Select Case Me.Name
                                Case "frmTransferenciaEntreCajas"
                                Case "frmDepositosBancarios"
                                    EliminarRegistroDetalle = Me.IBCMedioPago.spActualizarMPT_UBICACION(BCVariablesNames.ProcesosCaja.CajaIngreso, eRegistrosEliminar(fila).cCCC_ID, eRegistrosEliminar(fila).cPER_ID_BAN, eRegistrosEliminar(fila).cMPT_SERIE_MEDIO, eRegistrosEliminar(fila).cMPT_NUMERO_MEDIO, BCVariablesNames.UbicacionCodigo.Ubicacion1)
                                    If EliminarRegistroDetalle = 0 Then
                                        vMensajeErrorOrm = Compuesto2.vMensajeError
                                        Exit For
                                    End If
                            End Select
                    End Select

                    EliminarRegistroDetalle = Me.IBCDetalle.spEliminarRegistro(eRegistrosEliminar(fila).cTDO_ID, eRegistrosEliminar(fila).cDTD_ID, eRegistrosEliminar(fila).cCCC_ID, eRegistrosEliminar(fila).cDTE_SERIE, eRegistrosEliminar(fila).cDTE_NUMERO, eRegistrosEliminar(fila).cDTE_ITEM)
                    If EliminarRegistroDetalle = 0 Then
                        vMensajeErrorOrm = Compuesto1.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarRegistroDetalle
        End Function
        Private Function ActualizarUbicacionCheques()
            ActualizarUbicacionCheques = 0
            Dim vFilGrid As Integer = 0
            Dim vPER_ID_BAN As String = ""
            Dim vMPT_SERIE_MEDIO As String = ""
            Dim vMPT_NUMERO_MEDIO As String = ""

            ActualizarUbicacionCheques = 1

            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    vPER_ID_BAN = ""
                    vMPT_SERIE_MEDIO = ""
                    vMPT_NUMERO_MEDIO = ""
                    Select Case Me.Name
                        Case "frmDepositosBancarios"
                            If Trim(.Cells("cPER_ID_BAN").Value) = "" Then
                                vPER_ID_BAN = Nothing
                            Else
                                vPER_ID_BAN = .Cells("cPER_ID_BAN").Value
                            End If

                            If Trim(.Cells("cMPT_SERIE_MEDIO").Value) = "" Then
                                vMPT_SERIE_MEDIO = Nothing
                            Else
                                vMPT_SERIE_MEDIO = .Cells("cMPT_SERIE_MEDIO").Value
                            End If

                            If Trim(.Cells("cMPT_NUMERO_MEDIO").Value) = "" Then
                                vMPT_NUMERO_MEDIO = Nothing
                            Else
                                vMPT_NUMERO_MEDIO = .Cells("cMPT_NUMERO_MEDIO").Value
                            End If

                            ActualizarUbicacionCheques = Me.IBCMedioPago.spActualizarMPT_UBICACION(BCVariablesNames.ProcesosCaja.CajaIngreso, _
                                                                                                   txtCCC_ID.Text, _
                                                                                                   vPER_ID_BAN, _
                                                                                                   vMPT_SERIE_MEDIO, _
                                                                                                   vMPT_NUMERO_MEDIO, _
                                                                                                   BCVariablesNames.UbicacionCodigo.Ubicacion1)
                            If ActualizarUbicacionCheques = 0 Then
                                vMensajeErrorOrm = Compuesto2.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        Case Else
                            ActualizarUbicacionCheques = 1
                    End Select
                End With
                vFilGrid += 1
            End While
            Return ActualizarUbicacionCheques
        End Function
        Private Sub DatosCabecera()
            Compuesto.TDO_ID = Strings.Trim(txtTDO_ID.Text)
            Compuesto.DTD_ID = Strings.Trim(txtDTD_ID.Text)
            Compuesto.CCC_ID = Strings.Trim(txtCCC_ID.Text)
            Compuesto.TES_SERIE = Strings.Trim(txtTES_SERIE.Text)
            Compuesto.TES_NUMERO = Strings.Trim(txtTES_NUMERO.Text)
            Compuesto.TES_FECHA_EMI = dtpTES_FECHA_EMI.Value
            Compuesto.PVE_ID = Strings.Trim(txtPVE_ID.Text)
            Compuesto.PER_ID_CAJ = Strings.Trim(txtPER_ID_CAJ.Text)
            Compuesto.TES_MONTO_TOTAL = CDbl(txtTES_MONTO_TOTAL.Text)
            Compuesto.TES_ASIENTO = DevolverTiposCampos(chkTES_ASIENTO)
            Compuesto.TES_CIERRE = DevolverTiposCampos("TES_CIERRE", cboTES_CIERRE.Text, Compuesto)
            Compuesto.USU_ID = SessionService.UserId
            Compuesto.TES_FEC_GRAB = Now
            Compuesto.TES_ESTADO = DevolverTiposCampos(chkTES_ESTADO)

            Select pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    Compuesto8.CHE_ID = txtTES_SERIE.Text
                    Compuesto8.CCC_ID = txtCCC_ID.Text
                    Compuesto8.CHE_CORRELATIVO = Val(txtTES_NUMERO.Text) + 1
                    Compuesto8.USU_ID = SessionService.UserId
                    Compuesto8.CHE_FEC_GRAB = Now
                    Compuesto8.CHE_ESTADO = 1
                Case Else
                    ' Correlativo de serie
                    Compuesto3.TDO_ID = txtTDO_ID.Text
                    Compuesto3.PVE_ID = txtPVE_ID.Text
                    Compuesto3.CTD_COR_SERIE = txtTES_SERIE.Text
                    Compuesto3.CTD_COR_NUMERO = Val(txtTES_NUMERO.Text) + 1
                    Compuesto3.USU_ID = SessionService.UserId
                    Compuesto3.CTD_FEC_GRAB = Now
                    Compuesto3.CTD_ESTADO = 1
            End Select
        End Sub
        Private Function Validar(ByVal dgv As DataGridView, ByVal vModelos As String, Optional ByVal vFila As Integer = 0) As Boolean
            Dim resp As New RespuestaValidar
            Dim vFlagImporteCero As Boolean = False
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(dgv)

            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Compuesto.ColocarErrores(txtTDO_ID, Compuesto.VerificarDatos("TDO_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTD_ID, Compuesto.VerificarDatos("DTD_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtCCC_ID, Compuesto.VerificarDatos("CCC_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTES_SERIE, Compuesto.VerificarDatos("TES_SERIE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTES_NUMERO, Compuesto.VerificarDatos("TES_NUMERO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpTES_FECHA_EMI, Compuesto.VerificarDatos("TES_FECHA_EMI"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPVE_ID, Compuesto.VerificarDatos("PVE_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID_CAJ, Compuesto.VerificarDatos("PER_ID_CAJ"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTES_MONTO_TOTAL, Compuesto.VerificarDatos("TES_MONTO_TOTAL"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkTES_ASIENTO, Compuesto.VerificarDatos("TES_ASIENTO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboTES_CIERRE, Compuesto.VerificarDatos("TES_CIERRE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(pnCuerpo, Compuesto.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(btnImagen, Compuesto.VerificarDatos("TES_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkTES_ESTADO, Compuesto.VerificarDatos("TES_ESTADO"), ErrorProvider1)
                Case "Detalle"
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                            If Compuesto1.DTD_ID_DOC = "" And _
                               Compuesto1.DTD_ID_DOC_1 <> "" And _
                               Compuesto1.CCO_ID <> "" And _
                               Compuesto1.CUC_ID <> "" Then
                                Compuesto1.MON_ID_DOC = Compuesto1.MON_ID_DOC_1
                                If Compuesto1.DTE_IMPORTE_DOC = 0 Then
                                    vFlagImporteCero = True
                                    Compuesto1.DTE_IMPORTE_DOC = Compuesto1.DTE_IMPORTE_DOC_1
                                    Compuesto1.DTE_FEC_VEN = Now
                                End If
                            End If
                    End Select



                    If dgv.Name = "dgvDetalleEntregas" And _
                       pTDO_ID = BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas Then
                        resp.rM = Compuesto1.ColocarErrores(dgv, _
                                              Compuesto1.VerificarDatos("TDO_ID",
                                                                        "DTD_ID",
                                                                        "CCC_ID",
                                                                        "CCT_ID",
                                                                        "DTE_SERIE",
                                                                        "DTE_NUMERO",
                                                                        "DTE_ITEM",
                                                                        "CCC_ID_CLI",
                                                                        "DTE_DESTINO",
                                                                        "CCO_ID",
                                                                        "CUC_ID",
                                                                        "PER_ID_CLI",
                                                                        "TDO_ID_DOC",
                                                                        "DTD_ID_DOC",
                                                                        "CCT_ID_DOC",
                                                                        "DTE_SERIE_DOC",
                                                                        "DTE_NUMERO_DOC",
                                                                        "DTE_FEC_VEN",
                                                                        "MON_ID_DOC",
                                                                        "DTE_CONTRAVALOR_DOC",
                                                                        "PER_ID_CLI_1",
                                                                        "TDO_ID_DOC_1",
                                                                        "DTD_ID_DOC_1",
                                                                        "CCT_ID_DOC_1",
                                                                        "DTE_SERIE_DOC_1",
                                                                        "DTE_NUMERO_DOC_1",
                                                                        "DTE_FEC_VEN_1",
                                                                        "MON_ID_DOC_1",
                                                                        "DTE_IMPORTE_DOC_1",
                                                                        "DTE_CONTRAVALOR_DOC_1",
                                                                        "DTE_OBSERVACIONES",
                                                                        "DTE_OPE_CONTABLE",
                                                                        "DTE_MOVIMIENTO",
                                                                        "USU_ID",
                                                                        "DTE_FEC_GRAB",
                                                                        "DTE_ESTADO"), _
                                              ErrorProvider1, vFila)
                    Else
                        resp.rM = Compuesto1.ColocarErrores(dgv, _
                                              Compuesto1.VerificarDatos("TDO_ID",
                                                                        "DTD_ID",
                                                                        "CCC_ID",
                                                                        "CCT_ID",
                                                                        "DTE_SERIE",
                                                                        "DTE_NUMERO",
                                                                        "DTE_ITEM",
                                                                        "CCC_ID_CLI",
                                                                        "DTE_DESTINO",
                                                                        "CCO_ID",
                                                                        "CUC_ID",
                                                                        "PER_ID_CLI",
                                                                        "TDO_ID_DOC",
                                                                        "DTD_ID_DOC",
                                                                        "CCT_ID_DOC",
                                                                        "DTE_SERIE_DOC",
                                                                        "DTE_NUMERO_DOC",
                                                                        "DTE_FEC_VEN",
                                                                        "MON_ID_DOC",
                                                                        "DTE_IMPORTE_DOC",
                                                                        "DTE_CONTRAVALOR_DOC",
                                                                        "PER_ID_CLI_1",
                                                                        "TDO_ID_DOC_1",
                                                                        "DTD_ID_DOC_1",
                                                                        "CCT_ID_DOC_1",
                                                                        "DTE_SERIE_DOC_1",
                                                                        "DTE_NUMERO_DOC_1",
                                                                        "DTE_FEC_VEN_1",
                                                                        "MON_ID_DOC_1",
                                                                        "DTE_IMPORTE_DOC_1",
                                                                        "DTE_CONTRAVALOR_DOC_1",
                                                                        "DTE_OBSERVACIONES",
                                                                        "DTE_OPE_CONTABLE",
                                                                        "DTE_MOVIMIENTO",
                                                                        "USU_ID",
                                                                        "DTE_FEC_GRAB",
                                                                        "DTE_ESTADO"), _
                                              ErrorProvider1, vFila)
                    End If
                    Dim vNombreDgv As String = ""
                    Select Case dgv.Name
                        Case "dgvDetalle"
                            vNombreDgv = "Pagos"
                        Case "dgvDetalleEntregas"
                            vNombreDgv = "Entregas"
                        Case "dgvDetalleOtros"
                            vNombreDgv = "Otros"
                        Case "dgvDetalleTransferencias"
                            vNombreDgv = "Transferencias"
                    End Select

                    If Not resp.rM Then
                        ErrorProvider1.SetError(tcoTipoRecibo, "Error en: " & vNombreDgv)
                    Else
                        ErrorProvider1.SetError(tcoTipoRecibo, Nothing)
                    End If

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                            If Compuesto1.DTD_ID_DOC = "" And _
                               Compuesto1.DTD_ID_DOC_1 <> "" And _
                               Compuesto1.CCO_ID <> "" And _
                               Compuesto1.CUC_ID <> "" Then
                                If vFlagImporteCero = True Then Compuesto1.DTE_IMPORTE_DOC = 0
                            End If
                    End Select

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                             BCVariablesNames.ProcesosCaja.CajaEgreso,
                             BCVariablesNames.ProcesosCaja.DepositoTercero,
                             BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                             BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.VoucherCheque,
                             BCVariablesNames.ProcesosCaja.PlanillaEgreso
                            If cboTipoRecibo.Text = "ENTREGAS" Or _
                                vNombreDgv = "Entregas" Then
                                If Trim(dgv.Item("cCCO_ID" & vIdentificadorDgv, vFila - 1).Value) = "" Then
                                    resp.rM = False
                                    If ErrorProvider1.GetError(dgv) = "" Then
                                        ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en el centro de costos, debe tener 3 carácteres, fila: " & vFila)
                                    Else
                                        ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en el centro de costos, debe tener 3 carácteres" & Chr(13) & ErrorProvider1.GetError(dgv))
                                    End If
                                End If
                                If Trim(dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, vFila - 1).Value) = "" Then
                                    resp.rM = False
                                    If ErrorProvider1.GetError(dgv) = "" Then
                                        ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en el código de cliente, debe tener 6 carácteres, fila: " & vFila)
                                    Else
                                        ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en el código de cliente, debe tener 6 carácteres" & Chr(13) & ErrorProvider1.GetError(dgv))
                                    End If
                                End If
                            ElseIf cboTipoRecibo.Text = "OTROS" Or _
                                vNombreDgv = "Otros" Then
                                If Trim(dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, vFila - 1).Value) = "" And _
                                    pTDO_ID = BCVariablesNames.ProcesosCaja.CajaEgreso Then
                                    resp.rM = False
                                    If ErrorProvider1.GetError(dgv) = "" Then
                                        ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en el código de cliente, debe tener 6 carácteres, fila: " & vFila)
                                    Else
                                        ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en el código de cliente, debe tener 6 carácteres" & Chr(13) & ErrorProvider1.GetError(dgv))
                                    End If
                                End If

                                If Trim(dgv.Item("cCUC_ID" & vIdentificadorDgv, vFila - 1).Value) = "" Then
                                    resp.rM = False
                                    If ErrorProvider1.GetError(dgv) = "" Then
                                        ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en la cuenta contable, debe tener 3 carácteres, fila: " & vFila)
                                    Else
                                        ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en la cuenta contable, debe tener 3 carácteres" & Chr(13) & ErrorProvider1.GetError(dgv))
                                    End If
                                End If
                            End If
                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            If dgv.Item("cCCC_ID_CLI" & vIdentificadorDgv, vFila - 1).Value = "" Then
                                resp.rM = False
                                If ErrorProvider1.GetError(dgv) = "" Then
                                    ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en la Caja Cta. Cte., debe tener 3 carácteres, fila: " & vFila)
                                Else
                                    ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en la Caja Cta. Cte., debe tener 3 carácteres" & Chr(13) & ErrorProvider1.GetError(dgv))
                                End If
                            End If
                        Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                            'If dgv.Name = "dgvDetalleEntregasx" Then
                            '    If dgvDetalle.Item("cPER_ID_CLI_1", vFila - 1).Value = "" And dgvDetalle.Item("cCUC_ID", vFila - 1).Value = "" Then
                            '        'resp.rM = False
                            '        'If ErrorProvider1.GetError(dgvDetalle) = "" Then
                            '        'ErrorProvider1.SetError(dgvDetalle, "Debe de ingresar DATOS del cliente ó de la cuenta contable que genera el abono, fila: " & vFila)
                            '        'Else
                            '        'ErrorProvider1.SetError(dgvDetalle, "Debe de ingresar DATOS del cliente ó de la cuenta contable que genera el abono" & Chr(13) & ErrorProvider1.GetError(dgvDetalle))
                            '        'End If
                            '    ElseIf dgvDetalle.Item("cMON_ID_DOC_1", vFila - 1).Value = "" Then
                            '        If pTDO_ID = BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas Then
                            '        Else
                            '            If Trim(dgvDetalle.Item("cCUC_ID", vFila - 1).Value) <> "" Then
                            '            Else
                            '                resp.rM = False
                            '                If ErrorProvider1.GetError(dgvDetalle) = "" Then
                            '                    ErrorProvider1.SetError(dgvDetalle, "No ingreso Datos del documento a abonar, fila: " & vFila)
                            '                Else
                            '                    ErrorProvider1.SetError(dgvDetalle, "No ingreso Datos del documento a abonar " & Chr(13) & ErrorProvider1.GetError(dgvDetalle))
                            '                End If
                            '            End If
                            '        End If
                            '    End If
                            'End If
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                            If dgv.Item("cPER_ID_CLI_1" & vIdentificadorDgv, vFila - 1).Value = "" And dgv.Item("cCUC_ID" & vIdentificadorDgv, vFila - 1).Value = "" Then
                                resp.rM = False
                                If ErrorProvider1.GetError(dgv) = "" Then
                                    ErrorProvider1.SetError(dgv, "Debe de ingresar DATOS del cliente ó de la cuenta contable que genera el abono, fila: " & vFila)
                                Else
                                    ErrorProvider1.SetError(dgv, "Debe de ingresar DATOS del cliente ó de la cuenta contable que genera el abono" & Chr(13) & ErrorProvider1.GetError(dgv))
                                End If
                            ElseIf dgv.Item("cMON_ID_DOC_1" & vIdentificadorDgv, vFila - 1).Value = "" Then
                                If pTDO_ID = BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas Then
                                Else
                                    If Trim(dgv.Item("cCUC_ID" & vIdentificadorDgv, vFila - 1).Value) <> "" Then
                                    Else
                                        resp.rM = False
                                        If ErrorProvider1.GetError(dgv) = "" Then
                                            ErrorProvider1.SetError(dgv, "No ingreso Datos del documento a abonar, fila: " & vFila)
                                        Else
                                            ErrorProvider1.SetError(dgv, "No ingreso Datos del documento a abonar " & Chr(13) & ErrorProvider1.GetError(dgv))
                                        End If
                                    End If
                                End If
                            End If
                    End Select
                    If Not resp.rM Then
                        ErrorProvider1.SetError(tcoTipoRecibo, "Error en: " & vNombreDgv)
                    Else
                        ErrorProvider1.SetError(tcoTipoRecibo, Nothing)
                    End If
                Case "DetalleMedioPago"
                    ' Modificado 2015-07-17
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                             BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                            If Len(Trim(Compuesto2.MPT_NUMERO_MEDIO)) < 3 Then
                                ErrorProvider1.SetError(btnGenerarOtros, "Ingreso un número de Operación Bancaria incorrecto.")
                                resp.rM = False
                            End If
                    End Select

                    resp.rM = Compuesto2.ColocarErrores(dgvDetalle, _
                    Compuesto2.VerificarDatos("TDO_ID",
                    "DTD_ID",
                    "CCC_ID",
                    "MPT_SERIE",
                    "MPT_NUMERO",
                    "MPT_ITEM",
                    "MPT_IMPORTE_AFECTO",
                    "MPT_PORCENTAJE",
                    "CHE_ID",
                    "MPT_MEDIO_PAGO",
                    "MPT_SERIE_MEDIO",
                    "MPT_NUMERO_MEDIO",
                    "MPT_GIRADO_A",
                    "MPT_CONCEPTO",
                    "MPT_UBICACION",
                    "PER_ID_BANCO",
                    "MPT_DIFERIDO",
                    "MPT_FECHA_DIFERIDO",
                    "MPT_RECEPCION",
                    "USU_ID",
                    "MPT_FEC_GRAB",
                    "MPT_ESTADO"), _
                    ErrorProvider1, vFila)
            End Select
            Return vrO
        End Function

        Private Function VerificarCCTEntregas(ByVal vEstado As Boolean)
            VerificarCCTEntregas = vEstado
            Dim vCCT_IDe As String

            For vFilas = 0 To dgvDetalleEntregas.RowCount - 1
                If vFilas = 0 Then
                    vCCT_IDe = dgvDetalleEntregas.Item("cCCT_IDe", vFilas).Value
                    vgCCT_IDe = vCCT_IDe
                End If
                If vCCT_IDe <> dgvDetalleEntregas.Item("cCCT_IDe", vFilas).Value Then
                    ErrorProvider1.SetError(txtPRE_NUMERO, "La Cta. Cte. debe ser igual en todos los registros en la grilla Entregas.")
                    vgCCT_IDe = ""
                    VerificarCCTEntregas = False
                    Exit Function
                Else
                    ErrorProvider1.SetError(txtPRE_NUMERO, Nothing)
                End If
            Next
            Return VerificarCCTEntregas
        End Function
        Private Function VerificarTotalPrestamoPersonal(ByVal vEstado As Boolean)
            VerificarTotalPrestamoPersonal = vEstado
            Dim vTotalPrestamo As Decimal
            Dim vTotalEntregas As Decimal

            For vFilas = 0 To dgvDetalleEntregas.RowCount - 1
                If dgvDetalleEntregas.Item("cCCT_IDe", vFilas).Value <> BCVariablesNames.CCT_ID.PrestamosPersonal Then
                    ErrorProvider1.SetError(txtPRE_NUMERO, "La Cta. Cte. de ''ENTREGAS'' debe ser un prestamo de personal.")
                    VerificarTotalPrestamoPersonal = False
                    Exit Function
                Else
                    ErrorProvider1.SetError(txtPRE_NUMERO, Nothing)
                End If
            Next

            For vFilas = 0 To dgvDetalleEntregas.RowCount - 1
                If vFilas = 0 Then
                    vTotalPrestamo = Me.IBCBusqueda.TotalPrestamoPersonal(dgvDetalleEntregas.Item("cCCT_IDe", vFilas).Value, txtPRE_SERIE.Text, txtPRE_NUMERO.Text)
                End If
                vTotalEntregas += dgvDetalleEntregas.Item("cDTE_IMPORTE_DOCe", vFilas).Value
            Next
            If vTotalEntregas <> vTotalPrestamo Then
                ErrorProvider1.SetError(txtPRE_NUMERO, "El monto del egreso no coincide con el monto del prestamo." & vTotalEntregas & "-" & vTotalPrestamo)
                VerificarTotalPrestamoPersonal = False
                Exit Function
            Else
                ErrorProvider1.SetError(txtPRE_NUMERO, Nothing)
            End If

            Return VerificarTotalPrestamoPersonal
        End Function
        Private Function VerificarTotalPrestamoPersonalCliente(ByVal vEstado As Boolean)
            VerificarTotalPrestamoPersonalCliente = vEstado
            Dim vTotalPrestamoCliente As Decimal
            For vFilas = 0 To dgvDetalleEntregas.RowCount - 1
                vTotalPrestamoCliente = Me.IBCBusqueda.TotalPrestamoPersonalCliente(dgvDetalleEntregas.Item("cCCT_IDe", vFilas).Value, dgvDetalleEntregas.Item("cPER_ID_CLIe", vFilas).Value, txtPRE_SERIE.Text, txtPRE_NUMERO.Text)
                If dgvDetalleEntregas.Item("cDTE_IMPORTE_DOCe", vFilas).Value <> vTotalPrestamoCliente Then
                    ErrorProvider1.SetError(txtPRE_NUMERO, "El monto del personal: " & dgvDetalleEntregas.Item("cPER_DESCRIPCION_CLIe", vFilas).Value & " no coincide con el monto del prestamo.")
                    VerificarTotalPrestamoPersonalCliente = False
                Else
                    ErrorProvider1.SetError(txtPRE_NUMERO, Nothing)
                End If
            Next
            Return VerificarTotalPrestamoPersonalCliente
        End Function
        Private Sub InicializarOrm()
            InicializarOrmDetalle()
            InicializarOrmMovimientoCajaBanco()
            InicializarOrmKardexCtaCte()
            'Compuesto = Nothing
            'Compuesto = New Ladisac.BE.Tesoreria
            FiltrarCompuesto()
        End Sub
        Private Sub InicializarOrmDetalle()
            'Compuesto1 = Nothing
            'Compuesto1 = New Ladisac.BE.DetalleTesoreria
            'Compuesto2 = Nothing
            'Compuesto2 = New Ladisac.BE.MedioPagoTesoreria
        End Sub
        Private Sub InicializarOrmMovimientoCajaBanco()
            'Compuesto4 = Nothing
            'Compuesto4 = New Ladisac.BE.MovimientoCajaBanco
        End Sub
        Private Sub InicializarOrmKardexCtaCte()
            'Compuesto6 = Nothing
            'Compuesto6 = New Ladisac.BE.KardexCtaCte
        End Sub
        Public Sub FiltrarCampos(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vComportamiento As Integer)
            Dim vCadenaFiltrado As String = ""
            Dim vPVE_ID As String = ""
            Dim vTDO_ID As String = ""

            If txtPVE_ID.Text.Trim = "" Then
                vPVE_ID = pPVE_ID
            Else
                vPVE_ID = txtPVE_ID.Text
            End If

            Select Case vComportamiento
                Case Is <= 0 ' Tesoreria
                    VerificarEsEntregaEdicion()
                Case 2 ' PuntoVenta
                    FiltrarCompuesto()
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "' " & _
                                                              " And CCC_ID in ('" & BCVariablesNames.CCC_ID.LiqDocumentoDefault & "','" & BCVariablesNames.CCC_ID.LiqDocumentoDefaultDolares & "') " & _
                                                              " And CCC_ESTADO='ACTIVO' "
                        Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "' " & _
                                                              " And CCC_ID='" & BCVariablesNames.CCC_ID.PlaRenCtasDefault & "' " & _
                                                              " And CCC_ESTADO='ACTIVO' "
                        Case BCVariablesNames.ProcesosCaja.DepositoTercero,
                             BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                             BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.VoucherCheque 
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "'" & _
                                                              " And CCC_ESTADO='ACTIVO' "
                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            Select Case Me.Name
                                Case "frmTransferenciaEntreCajas"
                                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And ((CCC_TIPO IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "')) " & _
                                                                      " Or  (CCC_TIPO NOT IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "','" & BCVariablesNames.TipoCajaCtaCte.LiquidacionDocumento & "') " & _
                                                                            " And 'True'='" & BCVariablesNames.CajeroManejaraCtaBanco & "') " & _
                                                                      " And CCC_ESTADO='ACTIVO') " & _
                                                                      " And CCC_ID IN (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ='" & pPER_ID_CAJ & "')"
                                Case "frmDepositosBancarios"
                                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And (CCC_TIPO IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "')) " & _
                                                                      " And CCC_ESTADO='ACTIVO' " & _
                                                                      " And CCC_ID IN (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ='" & pPER_ID_CAJ & "')"
                            End Select
                            EtxtPER_ID_CAJ.pOOrm.CadenaFiltrado = " And PER_ID='" & pPER_ID_CAJ & "'"
                        Case Else
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & _
                                                             "' And PER_ID_CAJ='" & pPER_ID_CAJ & _
                                                             "' And PVE_ID='" & pPVE_ID & "' " & _
                                                             " And CCC_ESTADO='ACTIVO' "
                    End Select
                    If Not pRegistroNuevo Then BuscarSeries()
                Case 3 ' RolOpeCtaCte
                    FiltrarCompuesto()
                    FiltroCCT_ID()
                Case 4 ' CajaCtaCte
                    If pTDO_ID = BCVariablesNames.ProcesosCaja.DepositoTercero Or
                       pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Or
                       pTDO_ID = BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco Or
                       pTDO_ID = BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco Or
                       pTDO_ID = BCVariablesNames.ProcesosCaja.VoucherCheque Then
                        txtPER_ID_CAJ.Text = pPER_ID_CAJ
                        MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CAJ.Text, True, EtxtPER_ID_CAJ)
                    ElseIf pTDO_ID = BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas Then
                        Select Case Me.Name
                            Case "frmTransferenciaEntreCajas"
                                EtxtCCC_ID_CLI.pOOrm.CadenaFiltrado = " And CCC_ID<>'" & txtCCC_ID.Text & "'" & _
                                                                      " And (CCC_TIPO IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "')) " & _
                                                                      " Or  (CCC_TIPO NOT IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "','" & BCVariablesNames.TipoCajaCtaCte.LiquidacionDocumento & "') " & _
                                                                                    " And 'True'='" & BCVariablesNames.CajeroManejaraCtaBanco & "') " & _
                                                                      " AND CCC_ESTADO='ACTIVO' "
                            Case "frmDepositosBancarios"
                                EtxtCCC_ID_CLI.pOOrm.CadenaFiltrado = " And CCC_ID<>'" & txtCCC_ID.Text & "'" & _
                                                                      " And  (CCC_TIPO NOT IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "','" & BCVariablesNames.TipoCajaCtaCte.LiquidacionDocumento & "') " & _
                                                                                    " And 'True'='" & BCVariablesNames.CajeroManejaraCtaBanco & "') " & _
                                                                      " AND CCC_ESTADO='ACTIVO' "
                        End Select
                    End If
                    If pRegistroNuevo Then BuscarSeries()
                Case 8  ' Cliente
                    FiltroDTD_ID_DOC(dgv, vIdentificadorDgv)
                    If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                        EtxtPER_ID_CLI_1.pOOrm = New Ladisac.BE.Personas
                        EtxtPER_ID_CLI_1.pComportamiento = 15
                        EtxtPER_ID_CLI_1.pOrdenBusqueda = 4
                        MetodoBusquedaDato(dgvDetalle, "", dgvDetalle.Item("cPER_ID_CLI" & "", dgvDetalle.CurrentRow.Index).Value, True, EtxtPER_ID_CLI_1)
                        EtxtPER_ID_CLI_1.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
                        EtxtPER_ID_CLI_1.pComportamiento = 28
                        EtxtPER_ID_CLI_1.pOrdenBusqueda = 1
                    End If
                Case 27  ' Cliente - Liquidación de documentos
                    FiltroDTD_ID_DOC(dgv, vIdentificadorDgv)
                Case 9 ' SaldosKardexDocumentos
                    FiltroDTE_IMPORTE_DOC(dgv, vIdentificadorDgv)
                Case 15  ' Cliente_1
                    FiltroDTD_ID_DOC_1(dgv, vIdentificadorDgv)
                Case 28  ' Cliente_1 - Liquidación de documentos
                    FiltroDTD_ID_DOC_1(dgv, vIdentificadorDgv)
                Case 16 ' SaldosKardexDocumentos
                    FiltroDTE_IMPORTE_DOC_1()
                Case 24 ' CtaCte - del cliente

            End Select
        End Sub
        Private Sub VerificarEsEntregaEdicion()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaEgreso
                    If Not pRegistroNuevo Then
                        If cboTipoRecibo.Text = "ENTREGAS" Then
                            btnEntregasPagos.Enabled = True
                            btnEntregasPagos.Visible = True
                        Else
                            btnEntregasPagos.Enabled = False
                            btnEntregasPagos.Visible = False
                        End If
                    Else
                        btnEntregasPagos.Enabled = False
                        btnEntregasPagos.Visible = False
                    End If
            End Select
        End Sub
        Private Sub FiltroDTD_ID_DOC(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    EtxtDTD_ID_DOC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "'"
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    EtxtDTD_ID_DOC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "' And CCT_ID_REF Like '" & BCVariablesNames.CCT_ID.CxPComerciales & "'"
                Case Else
                    EtxtDTD_ID_DOC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
            End Select
        End Sub
        Private Sub FiltroDTD_ID_DOC_1(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                'Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                '    EtxtDTD_ID_DOC_1.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & dgv.Item("cPER_ID_CLI_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "' And CCT_ID_REF Like '" & BCVariablesNames.CCT_ID.EaRendirCuentas & "'"
                Case Else
                    EtxtDTD_ID_DOC_1.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & dgv.Item("cPER_ID_CLI_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "'" ' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
            End Select
        End Sub

        Private Sub FiltroDTE_IMPORTE_DOC(ByRef dgv As DataGridView, ByVal vIdentificadoDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    Select Case dgv.Name
                        Case "dgvDetalle"
                            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadoDgv)
                        Case "dgvDetalleEntregas"
                            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", False, True, vIdentificadoDgv)
                    End Select
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    Select Case pDTD_ID_DOC
                        Case BCVariablesNames.ProcesosFacturación.BoletaAnticipo, _
                             BCVariablesNames.ProcesosFacturación.FacturaAnticipo
                            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", True, True, vIdentificadoDgv)
                        Case Else
                            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadoDgv)
                    End Select
                    '  ojitooo
                Case BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    Select Case pDTD_ID_DOC
                        Case BCVariablesNames.ProcesosCompras.PrePersonal
                            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", True, True, vIdentificadoDgv)
                        Case Else
                            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadoDgv)
                    End Select
            End Select
        End Sub
        Private Sub FiltroDTE_IMPORTE_DOC_1()
        End Sub

        Private Sub FiltroCCT_ID()
            FormatearCamposAMostrarEnGrid()
        End Sub
        '' ojito
        Public Sub DeshabilitarModificar()
            ProcesarGridVacio(dgvDetalle)
            DesBloquearBloquearControlesXModificar()
        End Sub

        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CAJ" Then EtxtPER_ID_CAJ.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI_REC" Then EtxtPER_ID_CLI_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID_REC" Then EtxtCCT_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDO_ID" Then EtxtTDO_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCC_ID" Then EtxtCCC_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCC_ID_DES" Then EtxtCCC_ID_DES.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
                KeysTab(1) ' SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CAJ" Then EtxtPER_ID_CAJ.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLI_REC" Then EtxtPER_ID_CLI_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCT_ID_REC" Then EtxtCCT_ID_REC.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTDO_ID" Then EtxtTDO_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCC_ID" Then EtxtCCC_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCC_ID_DES" Then EtxtCCC_ID_DES.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDTD_ID" Then EtxtDTD_ID.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function
        Private Function ProcesarEliminarDetalle() As Int16
            Return EliminarDetalle(Compuesto1)
        End Function
        Private Function ProcesarEliminarDetallepep() As Int16
            Return EliminarDetallepep(Compuesto1)
        End Function

        Private Function EliminarDetalle(ByVal oOrm As DetalleTesoreria) As Int16
            EliminarDetalle = 0

            EliminarDetalle = Me.IBCMedioPago.spEliminarRegistroGeneral(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.CCC_ID, Compuesto.TES_SERIE, Compuesto.TES_NUMERO)
            If EliminarDetalle = 0 Then Return EliminarDetalle

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                    EliminarDetalle = EliminarKardexCtaCteDetracciones()
                    If EliminarDetalle = 0 Then Return EliminarDetalle
            End Select

            EliminarDetalle = EliminarKardexCtaCte(vItemKardexCtaCte)
            If EliminarDetalle = 0 Then Return EliminarDetalle

            EliminarDetalle = EliminarMovimientoCajaBanco(vItemMovimientoCajaBanco)
            If EliminarDetalle = 0 Then Return EliminarDetalle

            EliminarDetalle = ActualizarUbicacionCheques()
            If EliminarDetalle = 0 Then Return EliminarDetalle

            Return EliminarDetalle
        End Function
        
        Private Function EliminarKardexCtaCteDetracciones()
            EliminarKardexCtaCteDetracciones = 0

            If eRegistrosEliminar.Count = 2 Then
                EliminarKardexCtaCteDetracciones = 1
            Else
                For fila = 1 To eRegistrosEliminar.Count - 2
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                            EliminarKardexCtaCteDetracciones = Me.IBCKardexCtaCteDetracciones.spActualizarEstadoRegistroDetracciones(txtCCT_ID.Text, eRegistrosEliminarDocumento(fila).cTDO_ID, eRegistrosEliminarDocumento(fila).cDTD_ID, eRegistrosEliminarDocumento(fila).cDTE_SERIE, eRegistrosEliminarDocumento(fila).cDTE_NUMERO, True)
                            If EliminarKardexCtaCteDetracciones = 0 Then
                                vMensajeErrorOrm = Compuesto7.vMensajeError
                                Exit For
                            End If
                    End Select
                Next
            End If

            If EliminarKardexCtaCteDetracciones = 0 Then
                Return EliminarKardexCtaCteDetracciones
            End If

            For fila = 0 To dgvDetalle.RowCount() - 1
                vMensajeErrorOrm = ""
                EliminarKardexCtaCteDetracciones = Me.IBCKardexCtaCteDetracciones.spActualizarEstadoRegistroDetracciones(dgvDetalle.Rows(fila).Cells("cCCT_ID_DOC").Value, dgvDetalle.Rows(fila).Cells("cTDO_ID_DOC").Value, dgvDetalle.Rows(fila).Cells("cDTD_ID_DOC").Value, dgvDetalle.Rows(fila).Cells("cDTE_SERIE_DOC").Value, dgvDetalle.Rows(fila).Cells("cDTE_NUMERO_DOC").Value, True)
                If EliminarKardexCtaCteDetracciones = 0 Then
                    vMensajeErrorOrm = Compuesto7.vMensajeError
                    Exit For
                End If
            Next
            Return EliminarKardexCtaCteDetracciones
        End Function

        Private Function EliminarDetallepep(ByVal oOrm As DetalleTesoreria) As Int16
            EliminarDetallepep = 0

            EliminarDetallepep = Me.IBCMedioPago.spEliminarRegistroGeneral(pTDO_IDpep, pDTD_IDpep, pCCC_IDpep, pTES_SERIEpep, pTES_NUMEROpep)
            If EliminarDetallepep = 0 Then Return EliminarDetallepep

            'Select Case pTDO_ID
            '    Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
            '        EliminarDetallepep = EliminarKardexCtaCteDetracciones()
            '        If EliminarDetallepep = 0 Then Return EliminarDetallepep
            'End Select

            EliminarDetallepep = EliminarKardexCtaCtepep(vItemKardexCtaCtepep)
            If EliminarDetallepep = 0 Then Return EliminarDetallepep

            EliminarDetallepep = EliminarMovimientoCajaBancopep(vItemMovimientoCajaBancopep)
            If EliminarDetallepep = 0 Then Return EliminarDetallepep

            Return EliminarDetallepep
        End Function

        '' ojito ConfigurarIndexLectura()
        Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                ConfigurarIndexLectura()
                LongitudId = 0
                CaracterId = "0"

                ConfigurarCheck()
                ConfigurarComboBox()
                ConfigurarDataGridView()
                ConfigurarDateTimePicker()
                ConfigurarText()

                AdicionarElementoCombosEdicion()
                ComportamientoFormulario() ' ploaded=false

                ConfigurarGrid(dgvDetalleEntregas, "e", "Load")
                ConfigurarGrid(dgvDetalleOtros, "o", "Load")
                ConfigurarGrid(dgvDetalleTransferencias, "t", "Load")
                ConfigurarGrid(dgvDetalle, "", "Load")

                If Comportamiento = -1 Then BusquedaDatos("Load")
                FormatearCampos()
                ConfigurarFormulario(dgvDetalle, "", 1)
                If pComportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If

                pLoaded = True
                cboTipoRecibo.Text = "PAGOS"
                pLoaded = False

                If pDocumentoProcesandose = 1000 Then
                    pnCuerpo.Controls.Remove(btnImpresion)
                    Me.Controls.Add(btnImpresion)
                    btnImpresion.BringToFront()
                    btnImpresion.Enabled = True
                    btnImpresion.Location = New System.Drawing.Point(817, 465) ' 129-494
                End If

                ''''
                MostrarDataGridView()
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load ")
            End Try
        End Sub

        Private Sub DeshabilitarHabilitar_REC()
            Dim vBoolean As Boolean = False
            Dim vBoolean1 As Boolean = False
            Dim vBoolean2 As Boolean = False
            Dim vBoolean3 As Boolean = False

            If pTDO_ID = BCVariablesNames.ProcesosCaja.DepositoTercero Then
                Select Case tcoTipoRecibo.SelectedTab.Name
                    Case "tpaPagos"
                        txtPER_ID_CLI_REC.Visible = True
                        txtPER_ID_CLI_REC.ReadOnly = False
                        BloquearPerIdCliRec(dgvDetalle)
                End Select
            End If

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    vBoolean = True
                    vBoolean1 = True
                    vBoolean3 = True
                    txtPER_ID_CLI_REC.ReadOnly = False
                    EtxtPER_ID_CLI_REC.pBusqueda = True
                    btnBuscarPagosCobros.Text = "Jalar Cargos"
                    btnPagosMasivos.Text = "Jalar Abonos"
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                    vBoolean = True
                    vBoolean1 = False
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            vBoolean = True
                            vBoolean1 = True
                            txtPER_ID_CLI_REC.ReadOnly = False
                            EtxtPER_ID_CLI_REC.pBusqueda = True
                        Case "tpaEntregas"
                            vBoolean = True
                            vBoolean1 = False
                            If dgvDetalleEntregas.RowCount > 0 Then
                                txtPER_ID_CLI_REC.ReadOnly = True
                                EtxtPER_ID_CLI_REC.pBusqueda = False
                                txtPER_ID_CLI_REC.Text = dgvDetalleEntregas.Rows(0).Cells("cPER_ID_CLI_1e").Value
                                txtPER_DESCRIPCION_CLI_REC.Text = dgvDetalleEntregas.Rows(0).Cells("cPER_DESCRIPCION_CLI_1e").Value
                            Else
                                txtPER_ID_CLI_REC.ReadOnly = False
                                EtxtPER_ID_CLI_REC.pBusqueda = True
                            End If
                        Case "tpaOtros"
                            vBoolean = False
                            vBoolean1 = False
                    End Select
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                            vBoolean = False
                            vBoolean1 = False
                        Case "frmDepositosBancarios"
                            vBoolean = False
                            vBoolean1 = False
                            vBoolean2 = True
                    End Select
                Case BCVariablesNames.ProcesosCaja.DepositoTercero
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            vBoolean = True
                            vBoolean1 = False
                        Case "tpaEntregas"
                            vBoolean = True
                            vBoolean1 = False
                        Case "tpaOtros"
                            vBoolean = True
                            vBoolean1 = False
                    End Select
                Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            vBoolean = True
                            vBoolean1 = False

                            If txtCCT_ID.Text = BCVariablesNames.CCT_ID.Remuneraciones Then
                                vBoolean3 = True
                            Else
                                vBoolean3 = False
                            End If

                        Case "tpaEntregas"
                            vBoolean = False
                            vBoolean1 = False
                            vBoolean3 = False
                        Case "tpaOtros"
                            vBoolean = False
                            vBoolean1 = False
                            vBoolean3 = False
                    End Select
                Case Else
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            vBoolean = True
                            vBoolean1 = False
                        Case "tpaEntregas"
                            vBoolean = False
                            vBoolean1 = False
                        Case "tpaOtros"
                            vBoolean = False
                            vBoolean1 = False
                    End Select
            End Select
            lblPER_ID_CLI_REC.Enabled = vBoolean
            lblPER_ID_CLI_REC.Visible = vBoolean
            txtPER_ID_CLI_REC.Enabled = vBoolean
            txtPER_ID_CLI_REC.Visible = vBoolean
            txtPER_DESCRIPCION_CLI_REC.Enabled = vBoolean
            txtPER_DESCRIPCION_CLI_REC.Visible = vBoolean

            lblCCT_ID_REC.Enabled = vBoolean1
            lblCCT_ID_REC.Visible = vBoolean1
            txtCCT_ID_REC.Enabled = vBoolean1
            txtCCT_ID_REC.Visible = vBoolean1
            txtCCT_DESCRIPCION_REC.Enabled = vBoolean1
            txtCCT_DESCRIPCION_REC.Visible = vBoolean1

            btnBuscarPagosCobros.Enabled = vBoolean
            btnBuscarPagosCobros.Visible = vBoolean

            If pTDO_ID = BCVariablesNames.ProcesosCaja.DepositoTercero Then
                Select Case tcoTipoRecibo.SelectedTab.Name
                    Case "tpaPagos"
                        'txtPER_ID_CLI_REC.Enabled = True
                    Case "tpaEntregas", "tpaOtros"
                        txtPER_ID_CLI_REC.Visible = False
                        btnBuscarPagosCobros.Enabled = False
                        btnBuscarPagosCobros.Visible = False
                End Select
            End If

            lblCCC_ID_DES.Enabled = vBoolean2
            lblCCC_ID_DES.Visible = vBoolean2
            txtCCC_ID_DES.Enabled = vBoolean2
            txtCCC_ID_DES.Visible = vBoolean2
            txtCCC_DESCRIPCION_DES.Enabled = vBoolean2
            txtCCC_DESCRIPCION_DES.Visible = vBoolean2
            txtPER_ID_DES.Enabled = vBoolean2
            txtPER_ID_DES.Visible = vBoolean2

            btnBuscarCheques.Enabled = vBoolean2
            btnBuscarCheques.Visible = vBoolean2

            txtObservaciones.Enabled = vBoolean3
            txtObservaciones.Visible = vBoolean3

            bntActualizarObservaciones.Enabled = vBoolean3
            bntActualizarObservaciones.Visible = vBoolean3

            btnPagosMasivos.Enabled = vBoolean3
            btnPagosMasivos.Visible = vBoolean3

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    txtObservaciones.Size = New System.Drawing.Size(300, 20)
                    bntActualizarObservaciones.Size = New System.Drawing.Size(104, 23)
                    txtObservaciones.Location = New System.Drawing.Point(355, 174)
                    bntActualizarObservaciones.Location = New System.Drawing.Point(683, 174)
                Case Else
            End Select
        End Sub
        Private Sub MostrarDataGridView()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    tcoTipoRecibo.Visible = True
                    'RemoverTabs(tcoTipoRecibo, tpaOtros) ' 2016-07-19

                    tcoTipoRecibo.SelectedIndex = 0
                    dgvDetalle.Visible = True
                    dgvDetalleEntregas.Visible = False
                    dgvDetalleOtros.Visible = False
                    dgvDetalleTransferencias.Visible = False

                    lblTipoCambio.Visible = True
                    txtTipoCambio.Visible = True
                    lblTipoCambio.Enabled = True
                    txtTipoCambio.Enabled = True
                    DatosGenerarOtros(False)
                Case BCVariablesNames.ProcesosCaja.CajaEgreso
                    tcoTipoRecibo.Visible = True
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)
                    tcoTipoRecibo.SelectedIndex = 0
                    dgvDetalle.Visible = True
                    dgvDetalleEntregas.Visible = True
                    dgvDetalleOtros.Visible = True
                    dgvDetalleTransferencias.Visible = False
                    ConfigurarDatos("tpaPagos")
                    lblTipoCambio.Visible = True
                    txtTipoCambio.Visible = True
                    lblTipoCambio.Enabled = True
                    txtTipoCambio.Enabled = True
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso, _
                     BCVariablesNames.ProcesosCaja.CajaEgreso
                    tcoTipoRecibo.Visible = True
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)
                    tcoTipoRecibo.SelectedIndex = 0
                    dgvDetalle.Visible = True
                    dgvDetalleEntregas.Visible = True
                    dgvDetalleOtros.Visible = True
                    dgvDetalleTransferencias.Visible = False
                    ConfigurarDatos("tpaPagos")
                    lblTipoCambio.Visible = True ' false
                    txtTipoCambio.Visible = True ' False
                    lblTipoCambio.Enabled = True ' False
                    txtTipoCambio.Enabled = True ' False
                    DatosGenerarOtros(True)
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    cboTipoRecibo.Items.Remove("ENTREGAS")
                    tcoTipoRecibo.Visible = False
                    RemoverTabs(tcoTipoRecibo, tpaEntregas)
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)
                    tcoTipoRecibo.SelectedIndex = 0
                    dgvDetalle.Visible = True
                    dgvDetalleEntregas.Visible = False
                    dgvDetalleOtros.Visible = False
                    dgvDetalleTransferencias.Visible = False

                    lblTipoCambio.Text = "Contravalor"
                    lblTipoCambio.Visible = True
                    txtTipoCambio.Visible = True
                    lblTipoCambio.Enabled = True
                    txtTipoCambio.Enabled = True
                    DatosGenerarOtros(False)
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    tcoTipoRecibo.Visible = True
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)
                    tcoTipoRecibo.SelectedIndex = 0
                    dgvDetalle.Visible = True
                    dgvDetalleEntregas.Visible = True
                    dgvDetalleOtros.Visible = True
                    dgvDetalleTransferencias.Visible = False
                    ConfigurarDatos("tpaPagos")
                    lblTipoCambio.Visible = False
                    txtTipoCambio.Visible = False
                    lblTipoCambio.Enabled = False
                    txtTipoCambio.Enabled = False

                    lblCCT_ID_REC.Enabled = True
                    lblCCT_ID_REC.Visible = True
                    txtCCT_ID_REC.Enabled = True
                    txtCCT_ID_REC.Visible = True
                    txtCCT_DESCRIPCION_REC.Enabled = True
                    txtCCT_DESCRIPCION_REC.Visible = True
                    DatosGenerarOtros(True)
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas ' Transferencia entre caja y bancos y Depositos bancarios
                    'tcoTipoRecibo.Visible = False
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)
                    RemoverTabs(tcoTipoRecibo, tpaEntregas)
                    tcoTipoRecibo.Visible = True
                    tcoTipoRecibo.SelectedIndex = 0
                    dgvDetalle.Visible = True
                    dgvDetalleEntregas.Visible = False
                    dgvDetalleOtros.Visible = True
                    dgvDetalleTransferencias.Visible = False

                    lblTipoCambio.Visible = True
                    txtTipoCambio.Visible = True
                    lblTipoCambio.Enabled = True
                    txtTipoCambio.Enabled = True
                    DatosGenerarOtros(False)
                Case Else ' Planilla de egresos - Detracciones - nota de cargo de cuenta de banco
                    tcoTipoRecibo.Visible = False
                    tcoTipoRecibo.SelectedIndex = 0
                    dgvDetalle.Visible = True
                    dgvDetalleEntregas.Visible = False
                    dgvDetalleOtros.Visible = False
                    dgvDetalleTransferencias.Visible = False

                    lblTipoCambio.Visible = False
                    txtTipoCambio.Visible = False
                    lblTipoCambio.Enabled = False
                    txtTipoCambio.Enabled = False
                    DatosGenerarOtros(False)
            End Select
            DeshabilitarHabilitar_REC()
        End Sub
        Private Sub DatosGenerarOtros(ByVal Habilitar As Boolean)
            btnGenerarOtros.Enabled = Habilitar
            btnGenerarOtros.Visible = Habilitar
            txtMontoOtros.Enabled = Habilitar
            txtMontoOtros.Visible = Habilitar
            pnGenerarOtros.Enabled = Habilitar
            pnGenerarOtros.Visible = Habilitar
        End Sub
        Private Sub RemoverTabs(ByRef vTabControl As TabControl, ByRef vTapPage As TabPage)
            vTabControl.TabPages.Remove(vTapPage)
        End Sub
        '' ojito
        Private Sub ConfigurarIndexLectura()
            Dim vTabIndex As Int16 = 0

            ConfigurarTabIndex(txtPVE_ID, vTabIndex)
            ConfigurarTabIndex(cboTipoRecibo, vTabIndex, True)
            ConfigurarTabIndex(txtTDO_ID, vTabIndex, True)
            ConfigurarTabIndex(txtDTD_ID, vTabIndex)
            ConfigurarTabIndex(txtDTD_DESCRIPCION, vTabIndex, True)

            ConfigurarTabIndex(txtCCT_ID, vTabIndex, True)
            ConfigurarTabIndex(txtCCT_DESCRIPCION, vTabIndex, True)

            ConfigurarTabIndex(txtCCC_ID, vTabIndex)
            ConfigurarTabIndex(cboCCC_TIPO, vTabIndex, True)
            ConfigurarTabIndex(txtCCC_DESCRIPCION, vTabIndex, True)

            ConfigurarTabIndex(cboSerieCorrelativo, vTabIndex)
            ConfigurarTabIndex(txtTES_SERIE, vTabIndex, True)
            ConfigurarTabIndex(txtTES_NUMERO, vTabIndex)

            ConfigurarTabIndex(dtpTES_FECHA_EMI, vTabIndex, True)

            ConfigurarTabIndex(txtMON_ID_CCC, vTabIndex, True)
            ConfigurarTabIndex(txtMON_SIMBOLO_CCC, vTabIndex, True)
            ConfigurarTabIndex(txtMON_DESCRIPCION_CCC, vTabIndex, True)

            ConfigurarTabIndex(txtPER_ID_CAJ, vTabIndex, True)
            ConfigurarTabIndex(txtPER_DESCRIPCION_CAJ, vTabIndex, True)

            ConfigurarTabIndex(chkTES_ASIENTO, vTabIndex)
            ConfigurarTabIndex(cboTES_CIERRE, vTabIndex)
            ConfigurarTabIndex(chkTES_ESTADO, vTabIndex)

            ConfigurarTabIndex(txtPER_ID_CLI_REC, vTabIndex)
            ConfigurarTabIndex(txtPER_DESCRIPCION_CLI_REC, vTabIndex)

            ConfigurarTabIndex(dgvDetalle, vTabIndex)

            ConfigurarTabIndex(txtTotalEfectivo, vTabIndex, True)
            ConfigurarTabIndex(txtTotalCheque, vTabIndex, True)
            ConfigurarTabIndex(txtTotalTarjetaCredito, vTabIndex, True)
            ConfigurarTabIndex(txtTotalDepositoBancario, vTabIndex, True)
            ConfigurarTabIndex(txtTotalTransferenciaBancaria, vTabIndex, True)
            ConfigurarTabIndex(txtTotalDocumento, vTabIndex, True)
            ConfigurarTabIndex(txtTotalRetencionIgv, vTabIndex, True)
            ConfigurarTabIndex(txtTES_MONTO_TOTAL, vTabIndex, True)
            'ConfigurarTabIndex(btnImagen, vTabIndex, True)
        End Sub

        Private Sub AdicionarElementoCombosEdicion()
            BuscarFormatos(EcboTES_CIERRE, Compuesto, cboTES_CIERRE, 0)
        End Sub

        '' ojito
        Private Sub NombresFormulariosControles()
            FiltrarCompuesto()

            EtxtPVE_ID.pOOrm = New Ladisac.BE.PuntoVenta
            EtxtPVE_ID.pComportamiento = 2
            EtxtPVE_ID.pOrdenBusqueda = 1
            EtxtPVE_ID.pMostrarDatosGrid = True
            EtxtPVE_ID.pOOrm.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"

            EtxtDTD_ID.pOOrm = New Ladisac.BE.RolOpeCtaCte
            EtxtDTD_ID.pComportamiento = 3
            EtxtDTD_ID.pOrdenBusqueda = 2
            EtxtDTD_ID.pMostrarDatosGrid = True
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque
                    EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And ROC_TIPO='" & cboTipoRecibo.Text & "' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.ReciboIngresoEgreso & "'"
                Case BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And ROC_TIPO='" & cboTipoRecibo.Text & "' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.PlanillaIngresoEgreso & "'"
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And DTD_ID Like '" & pDTD_ID & "' And ROC_TIPO='" & cboTipoRecibo.Text & "' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.TransferenciaEntreCajaBanco & "'"
            End Select

            EtxtCCC_ID.pOOrm = New Ladisac.BE.CajaCtaCte
            EtxtCCC_ID.pComportamiento = 4
            EtxtCCC_ID.pOrdenBusqueda = 5
            EtxtCCC_ID.pMostrarDatosGrid = True
            EtxtCCC_ID.pOOrm.pBuscarRegistros = False
            EtxtCCC_ID.pOOrm.Vista = "BuscarRegistrosCajero"
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    EtxtCCC_ID.pOOrm.Vista = "BuscarRegistrosCajeroResumen"
                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "' " & _
                                                      " And CCC_ID in ('" & BCVariablesNames.CCC_ID.LiqDocumentoDefault & "','" & BCVariablesNames.CCC_ID.LiqDocumentoDefaultDolares & "') " & _
                                                      " And CCC_ESTADO='ACTIVO' "
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    EtxtCCC_ID.pOOrm.Vista = "BuscarRegistrosCajeroResumen"
                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "' " & _
                                                      " And CCC_ID='" & BCVariablesNames.CCC_ID.PlaRenCtasDefault & "' " & _
                                                      " And CCC_ESTADO='ACTIVO' "
                Case BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque
                    EtxtCCC_ID.pOOrm.Vista = "BuscarRegistrosCajeroResumen"
                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "' " & _
                                                      " And CCC_ESTADO='ACTIVO' "
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    EtxtCCC_ID.pOOrm.Vista = "BuscarRegistrosCajeroResumen"
                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And ((CCC_TIPO IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "')) " & _
                                                              " Or  (CCC_TIPO NOT IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "','" & BCVariablesNames.TipoCajaCtaCte.LiquidacionDocumento & "') " & _
                                                                    " And 'True'='" & BCVariablesNames.CajeroManejaraCtaBanco & "') " & _
                                                              " And CCC_ESTADO='ACTIVO') " & _
                                                              " And CCC_ID IN (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ='" & pPER_ID_CAJ & "')"
                        Case "frmDepositosBancarios"
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And (CCC_TIPO IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "')) " & _
                                                              " And CCC_ESTADO='ACTIVO' " & _
                                                              " And CCC_ID IN (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ='" & pPER_ID_CAJ & "')"
                    End Select
                Case Else
                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & _
                                                     "' And PER_ID_CAJ='" & pPER_ID_CAJ & _
                                                     "' And PVE_ID='" & pPVE_ID & "' " & _
                                                     " And CCC_ESTADO='ACTIVO' "
            End Select

            EtxtPER_ID_CAJ.pOOrm = New Ladisac.BE.Personas ' Cajero
            EtxtPER_ID_CAJ.pComportamiento = 5
            EtxtPER_ID_CAJ.pOrdenBusqueda = 4
            EtxtPER_ID_CAJ.pMostrarDatosGrid = True

            ' Detalle - se modifica en la parte de la cabecera
            EtxtCCT_ID.pOOrm = New Ladisac.BE.CtaCte
            EtxtCCT_ID.pComportamiento = 6
            EtxtCCT_ID.pOrdenBusqueda = 0

            EtxtCCC_ID_CLI.pOOrm = New Ladisac.BE.CajaCtaCte
            EtxtCCC_ID_CLI.pComportamiento = 7
            EtxtCCC_ID_CLI.pOrdenBusqueda = 5
            EtxtCCC_ID_CLI.pMostrarDatosGrid = True

            EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.Personas ' Cliente
            EtxtPER_ID_CLI.pComportamiento = 8
            EtxtPER_ID_CLI.pOrdenBusqueda = 4

            EtxtDTD_ID_DOC.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
            EtxtDTD_ID_DOC.pComportamiento = 9
            EtxtDTD_ID_DOC.pOrdenBusqueda = 11
            EtxtDTD_ID_DOC.pOOrm.pBuscarRegistros = False
            EtxtDTD_ID_DOC.pOOrm.Vista = "spSaldoDocumentoMontoNoCero"
            EtxtDTD_ID_DOC.pMostrarDatosGrid = True

            EtxtMON_ID_DOC.pOOrm = New Ladisac.BE.Moneda
            EtxtMON_ID_DOC.pComportamiento = 10
            EtxtMON_ID_DOC.pOrdenBusqueda = 0

            EtxtCHE_ID.pOOrm = New Ladisac.BE.Cheques
            EtxtCHE_ID.pComportamiento = 11
            EtxtCHE_ID.pOrdenBusqueda = 0

            EtxtDTE_IMPORTE_DOC.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
            EtxtDTE_IMPORTE_DOC.pComportamiento = 12
            EtxtDTE_IMPORTE_DOC.pOrdenBusqueda = 0

            EtxtMON_ID_CCC.pOOrm = New Ladisac.BE.Moneda
            EtxtMON_ID_CCC.pComportamiento = 13
            EtxtMON_ID_CCC.pOrdenBusqueda = 0

            EtxtPER_ID_BAN.pOOrm = New Ladisac.BE.RolPersonaTipoPersona ' Bancos
            EtxtPER_ID_BAN.pComportamiento = 14
            EtxtPER_ID_BAN.pOrdenBusqueda = 1
            EtxtPER_ID_BAN.pMostrarDatosGrid = True
            EtxtPER_ID_BAN.pOOrm.CadenaFiltrado = " And PER_BANCO='SI' " & _
                                                  " And TPE_ID='" & BCVariablesNames.TipoPersonas.Banco & "'"

            EtxtPER_ID_CLI_1.pOOrm = New Ladisac.BE.Personas ' Cliente
            EtxtPER_ID_CLI_1.pComportamiento = 15
            EtxtPER_ID_CLI_1.pOrdenBusqueda = 4

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas, _
                     BCVariablesNames.ProcesosCaja.CajaIngreso
                    If cboTipoRecibo.Text = "PAGOS" Then
                        EtxtDTD_ID_DOC_1.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
                        EtxtDTD_ID_DOC_1.pComportamiento = 16
                        EtxtDTD_ID_DOC_1.pOrdenBusqueda = 0
                        EtxtDTD_ID_DOC_1.pOOrm.pBuscarRegistros = False
                        EtxtDTD_ID_DOC_1.pOOrm.Vista = "spSaldoDocumentoMontoNoCero"
                    Else
                        EtxtDTD_ID_DOC_1.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
                        EtxtDTD_ID_DOC_1.pComportamiento = 16
                        EtxtDTD_ID_DOC_1.pOrdenBusqueda = 0
                        EtxtDTD_ID_DOC_1.pOOrm.pBuscarRegistros = False
                        EtxtDTD_ID_DOC_1.pOOrm.Vista = "spSaldoDocumentoMontoNoCero"
                        EtxtDTD_ID_DOC_1.pOOrm.CadenaFiltrado = " And CCT_ID_REF ='" & txtCCT_ID.Text & "'"
                    End If
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    EtxtDTD_ID_DOC_1.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
                    EtxtDTD_ID_DOC_1.pComportamiento = 16
                    EtxtDTD_ID_DOC_1.pOrdenBusqueda = 11
                    EtxtDTD_ID_DOC_1.pOOrm.pBuscarRegistros = False
                    EtxtDTD_ID_DOC_1.pOOrm.Vista = "spSaldoDocumentoMontoNoCeroConCheck"
                Case Else
                    EtxtDTD_ID_DOC_1.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
                    EtxtDTD_ID_DOC_1.pComportamiento = 16
                    EtxtDTD_ID_DOC_1.pOrdenBusqueda = 0
                    EtxtDTD_ID_DOC_1.pOOrm.pBuscarRegistros = False
                    EtxtDTD_ID_DOC_1.pOOrm.Vista = "spSaldoDocumentoMontoNoCero"
            End Select

            EtxtCCO_ID.pOOrm = New Ladisac.BE.CentroCostos
            EtxtCCO_ID.pComportamiento = 17
            EtxtCCO_ID.pOrdenBusqueda = 1
            EtxtCCO_ID.pMostrarDatosGrid = True

            EtxtCUC_ID.pOOrm = New Ladisac.BE.CuentasContables
            EtxtCUC_ID.pComportamiento = 18
            EtxtCUC_ID.pOrdenBusqueda = 1
            EtxtCUC_ID.pMostrarDatosGrid = True

            EtxtDTD_ID_ROC.pOOrm = New Ladisac.BE.RolOpeCtaCte
            EtxtDTD_ID_ROC.pComportamiento = 19
            EtxtDTD_ID_ROC.pOrdenBusqueda = 2
            EtxtDTD_ID_ROC.pOOrm.CadenaFiltrado = " And TDO_ID = '" & pTDO_ID & "' AND DTD_ID not in ('" & BCVariablesNames.ProcesosCtaCte.SinDocumentoPlaRenCtas & "','" & BCVariablesNames.ProcesosCtaCte.ReembolsoPlaRenCtas & "')"

            EtxtPER_ID_CLI_REC.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad ' Cliente recibo
            EtxtPER_ID_CLI_REC.pComportamiento = 20
            EtxtPER_ID_CLI_REC.pOrdenBusqueda = 1
            EtxtPER_ID_CLI_REC.pMostrarDatosGrid = True

            EtxtDTD_ID_DOC_CLI_REC.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
            EtxtDTD_ID_DOC_CLI_REC.pComportamiento = 21
            EtxtDTD_ID_DOC_CLI_REC.pOrdenBusqueda = 11
            EtxtDTD_ID_DOC_CLI_REC.pOOrm.pBuscarRegistros = False
            EtxtDTD_ID_DOC_CLI_REC.pOOrm.Vista = "spSaldoDocumentoMontoNoCeroConCheck"
            EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = True

            EtxtCCT_IDe.pOOrm = New Ladisac.BE.RolOpeCtaCte
            EtxtCCT_IDe.pComportamiento = 22
            EtxtCCT_IDe.pOrdenBusqueda = 2
            EtxtCCT_IDe.pMostrarDatosGrid = True
            EtxtCCT_IDe.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And ROC_TIPO='ENTREGAS' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.ReciboIngresoEgreso & "'"

            EtxtDTD_ID_DOC_CLI_REC_1.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
            EtxtDTD_ID_DOC_CLI_REC_1.pComportamiento = 23
            EtxtDTD_ID_DOC_CLI_REC_1.pOrdenBusqueda = 11
            EtxtDTD_ID_DOC_CLI_REC_1.pOOrm.pBuscarRegistros = False
            EtxtDTD_ID_DOC_CLI_REC_1.pOOrm.Vista = "spSaldoDocumentoMontoNoCeroConCheck"
            EtxtDTD_ID_DOC_CLI_REC_1.pMostrarDatosGrid = True

            EtxtCCT_ID_REC.pOOrm = New Ladisac.BE.CtaCte
            EtxtCCT_ID_REC.pComportamiento = 24
            EtxtCCT_ID_REC.pOrdenBusqueda = 1
            EtxtCCT_ID_REC.pMostrarDatosGrid = True

            EtxtCCC_ID_DES.pOOrm = New Ladisac.BE.CajaCtaCte
            EtxtCCC_ID_DES.pComportamiento = 25
            EtxtCCC_ID_DES.pOrdenBusqueda = 5
            EtxtCCC_ID_DES.pMostrarDatosGrid = True
            EtxtCCC_ID_DES.pOOrm.pBuscarRegistros = False
            EtxtCCC_ID_DES.pOOrm.Vista = "BuscarRegistrosCajeroResumen"
            EtxtCCC_ID_DES.pOOrm.CadenaFiltrado = " And CCC_ID<>'" & txtCCC_ID.Text & "'" & _
                                                  " And  (CCC_TIPO NOT IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "','" & BCVariablesNames.TipoCajaCtaCte.LiquidacionDocumento & "') " & _
                                                         " And 'True'='" & BCVariablesNames.CajeroManejaraCtaBanco & "') " & _
                                                  " AND CCC_ESTADO='ACTIVO' "

            EtxtMPT_NUMERO_MEDIO.pOOrm = New Ladisac.BE.DetalleTesoreria
            EtxtMPT_NUMERO_MEDIO.pComportamiento = 26
            EtxtMPT_NUMERO_MEDIO.pOrdenBusqueda = 1
            EtxtMPT_NUMERO_MEDIO.pMostrarDatosGrid = True
            EtxtMPT_NUMERO_MEDIO.pOOrm.pBuscarRegistros = False
            EtxtMPT_NUMERO_MEDIO.pOOrm.Vista = "VistaDetalleTesoreriaNuevo"
            'EtxtMPT_NUMERO_MEDIO.pOOrm.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "')"

        End Sub
        Private Sub FiltrarCompuesto()
            If SessionService.NoCajeroEnTesoreria Then
                Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & _
                                          "' And PVE_ID In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "' and PDU_ESTADO='ACTIVO') " '& _
                '"  And CCC_ID in (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ=(select PER_ID from mae.Usuarios where USU_ID='" & SessionService.UserId & "' ))"
            Else
                Compuesto.CadenaFiltrado = " And TDO_ID='" & pTDO_ID & _
                                          "' And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "' and PDU_ESTADO='ACTIVO')" & _
                                          "  And PER_ID_CAJ='" & pPER_ID_CAJ & "'" '& _
                '"  And CCC_ID in (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ=(select PER_ID from mae.Usuarios where USU_ID='" & SessionService.UserId & "' ))"
            End If
            If pDocumentoProcesandose = 1000 Then
                Compuesto.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "' and PDU_ESTADO='ACTIVO')" 
            End If
        End Sub

#Region "CheckBox"
        Private Sub ConfigurarCheck()
            Dim EchkTemporal As New chk

            EchkTemporal.pFormatearTexto = True
            EchkTemporal.vEstado0 = ""
            EchkTemporal.vEstado1 = ""
            EchkTemporal.vEstadoX = ""
            EchkTemporal.pSimple = Compuesto
            EchkTemporal.pValorDefault = CheckState.Unchecked


            EchkTES_ASIENTO = EchkTemporal
            EchkTES_ASIENTO.pNombreCampo = "TES_ASIENTO"
            ConfigurarCheck_Refrescar(EchkTES_ASIENTO)

            EchkTES_ESTADO = EchkTemporal
            EchkTES_ESTADO.pNombreCampo = "TES_ESTADO"
            EchkTES_ESTADO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkTES_ESTADO)
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkTES_ASIENTO"
                    Compuesto.CampoId = EchkTES_ASIENTO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkTES_ESTADO"
                    Compuesto.CampoId = EchkTES_ESTADO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Compuesto.DevolverTiposCampos()
        End Function
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkTES_ASIENTO"
                    vObjetoChk.pValorDefault = EchkTES_ASIENTO.pValorDefault
                Case "chkTES_ESTADO"
                    vObjetoChk.pValorDefault = EchkTES_ESTADO.pValorDefault
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
        Handles chkTES_ASIENTO.CheckedChanged, _
        chkTES_ESTADO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkTES_ASIENTO"
                    If EchkTES_ASIENTO.pFormatearTexto Then
                        InicializarTextoCheck(EchkTES_ASIENTO)
                    End If
                Case "chkTES_ESTADO"
                    If EchkTES_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkTES_ESTADO)
                    End If
            End Select
        End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "TES_ASIENTO"
                    With chkTES_ASIENTO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "TES_ESTADO"
                    With chkTES_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTextoCheck(EchkTES_ASIENTO)
            InicializarTextoCheck(EchkTES_ESTADO)
        End Sub
#End Region

#Region "DataGridView"
        '' ojito
        Private Sub ConfigurarDataGridView()
            EdgvDetalle.pAnchoColumna = 20
            EdgvDetalle.pBloquearPk = True
            EdgvDetalle.pColorColumna = Drawing.Color.Black
            EdgvDetalle.pCampoEstadoRegistro = "cEstadoRegistro"
            EdgvDetalle.pMetodoColumnas = True
            ReDim EdgvDetalle.pArrayCamposPkDetalle(3)
            EdgvDetalle.pArrayCamposPkDetalle(1) = "cPER_ID_CLI"
            EdgvDetalle.pArrayCamposPkDetalle(2) = "cDTD_ID_DOC"
            EdgvDetalle.pArrayCamposPkDetalle(3) = "cDTE_IMPORTE_DOC"

            dgvDetalle.AllowUserToAddRows = False
            dgvDetalle.AllowUserToDeleteRows = False
            dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            dgvDetalleEntregas.AllowUserToAddRows = False
            dgvDetalleEntregas.AllowUserToDeleteRows = False
            dgvDetalleEntregas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDetalleEntregas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDetalleEntregas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDetalleEntregas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            dgvDetalleOtros.AllowUserToAddRows = False
            dgvDetalleOtros.AllowUserToDeleteRows = False
            dgvDetalleOtros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDetalleOtros.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDetalleOtros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDetalleOtros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            dgvDetalleTransferencias.AllowUserToAddRows = False
            dgvDetalleTransferencias.AllowUserToDeleteRows = False
            dgvDetalleTransferencias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
            Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDetalleTransferencias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDetalleTransferencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDetalleTransferencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        End Sub
        '' ojito
        Private Sub ConfigurarGrid(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vProceso As String, Optional ByVal vProcesarTodosDgv As Boolean = False)
            Select Case vProceso
                Case "Load"
                    eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
                    eConfigurarDataGridObjeto.Orm = Nothing
                    eConfigurarDataGridObjeto.Array = {7, 11, 23, 24, 29, 30, 31, 32, 33, 34, 37, 41, 49, 50, 53, 55}
                    ConfigurarGrid(dgv, eConfigurarDataGridObjeto)
                    ConfigurarCampoVisualizarGridDetalle(dgv, vIdentificadorDgv)
                Case "ElementoItem"
                    eConfigurarDataGridObjeto.Metodo = "ElementoItem"
                    eConfigurarDataGridObjeto.Columna = "cItem"
                    ConfigurarGrid(dgv, eConfigurarDataGridObjeto, vProcesarTodosDgv)
            End Select
        End Sub
        '' ojito
        Private Sub ConfigurarColumnasGrid(ByRef dgv As DataGridView, _
                                           ByVal vNameColumna As String, _
                                           ByVal vReadOnly As Boolean, _
                                           ByVal vVisible As Boolean, _
                                           ByVal vIdentificadorDgv As String)
            dgv.Columns(vNameColumna & vIdentificadorDgv).ReadOnly = vReadOnly
            dgv.Columns(vNameColumna & vIdentificadorDgv).Visible = vVisible
        End Sub
        '' ojito
        Private Sub dgvDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles dgvDetalle.KeyDown, dgvDetalleEntregas.KeyDown, dgvDetalleOtros.KeyDown, dgvDetalleTransferencias.KeyDown
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(sender)

            If e.KeyData = Keys.Return Then
                KeysTab(1)
            End If

            If sender.RowCount = 0 Then Exit Sub
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                Case "cCCC_ID_CLI" & vIdentificadorDgv
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtCCC_ID_CLI.pBusqueda Then
                                EtxtCCC_ID_CLI.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                                MetodoBusquedaDato(sender, vIdentificadorDgv, "", False, EtxtCCC_ID_CLI)
                                EtxtCCC_ID_CLI.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                                EtxtCCC_ID_CLI.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                                ValidarImporteTransferenciaEntreCajas(sender, vIdentificadorDgv, sender.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value)
                                If Trim(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) <> "" Then
                                    sender.CurrentCell = sender.Rows(sender.CurrentRow.Index).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                                End If
                            End If
                    End Select
                Case "cPER_ID_CLI" & vIdentificadorDgv
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtPER_ID_CLI.pBusqueda Then

                                If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                                    EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
                                    EtxtPER_ID_CLI.pComportamiento = 27
                                    EtxtPER_ID_CLI.pOrdenBusqueda = 1
                                Else
                                    EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.Personas
                                    EtxtPER_ID_CLI.pComportamiento = 8
                                    EtxtPER_ID_CLI.pOrdenBusqueda = 4
                                End If

                                EtxtPER_ID_CLI.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                                MetodoBusquedaDato(sender, vIdentificadorDgv, "", False, EtxtPER_ID_CLI)
                                EtxtPER_ID_CLI.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                                EtxtPER_ID_CLI.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value

                                If cboTipoRecibo.Text = "PAGOS" Then
                                    If sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString <> "cPER_ID_CLIe" And _
                                       sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString <> "cPER_ID_CLIo" Then
                                        If vProcesarBusquedaDirectaDocumento Then
                                            If Trim(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) <> "" Then
                                                sender.CurrentCell = sender.Rows(sender.CurrentRow.Index).Cells("cDTD_ID_DOC" & vIdentificadorDgv)
                                                pDevolverDatosUnicoRegistro = True
                                                If vProcesarBusquedaDirectaDocumento Then
                                                    MetodoBusquedaDato(sender, vIdentificadorDgv, "", False, EtxtDTD_ID_DOC)
                                                End If
                                                vProcesarBusquedaDirectaDocumento = True
                                                sender.CurrentCell = sender.Rows(sender.CurrentRow.Index).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                                            End If
                                        End If
                                        vProcesarBusquedaDirectaDocumento = True
                                    End If
                                ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                                ElseIf cboTipoRecibo.Text = "OTROS" Then
                                End If
                            End If
                    End Select
                Case "cDTD_ID_DOC" & vIdentificadorDgv
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtDTD_ID_DOC.pBusqueda Then
                                LLamarDTD_ID_DOC(sender, vIdentificadorDgv, True)
                            End If
                        Case Keys.F2
                            If EtxtDTD_ID_ROC.pBusqueda Then
                                LLamarDTD_ID_ROC(True)
                            End If
                    End Select
                Case "cPER_ID_BAN" & vIdentificadorDgv
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtPER_ID_BAN.pBusqueda Then
                                EtxtPER_ID_BAN.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                                MetodoBusquedaDato(sender, vIdentificadorDgv, "", False, EtxtPER_ID_BAN)
                                EtxtPER_ID_BAN.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                                EtxtPER_ID_BAN.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                                KeysTab(2)
                            End If
                    End Select
                Case "cPER_ID_CLI_1" & vIdentificadorDgv
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtPER_ID_CLI_1.pBusqueda Then

                                If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento Then
                                    EtxtPER_ID_CLI_1.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
                                    EtxtPER_ID_CLI_1.pComportamiento = 28
                                    EtxtPER_ID_CLI_1.pOrdenBusqueda = 1

                                Else
                                    EtxtPER_ID_CLI_1.pOOrm = New Ladisac.BE.Personas
                                    EtxtPER_ID_CLI_1.pComportamiento = 15
                                    EtxtPER_ID_CLI_1.pOrdenBusqueda = 4
                                End If

                                EtxtPER_ID_CLI_1.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                MetodoBusquedaDato(sender, vIdentificadorDgv, "", False, EtxtPER_ID_CLI_1)
                                EtxtPER_ID_CLI_1.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                EtxtPER_ID_CLI_1.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                KeysTab(2)
                            End If
                    End Select
                Case "cDTD_ID_DOC_1" & vIdentificadorDgv
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtDTD_ID_DOC_1.pBusqueda Then
                                EtxtDTD_ID_DOC_1.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                MetodoBusquedaDato(sender, vIdentificadorDgv, "", False, EtxtDTD_ID_DOC_1)
                                EtxtDTD_ID_DOC_1.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                EtxtDTD_ID_DOC_1.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                KeysTab(3)
                            End If
                    End Select
                Case "cCCT_ID" & vIdentificadorDgv
                    If sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString = "cCCT_IDe" Then
                        Select Case e.KeyCode
                            Case Keys.F1
                                If EtxtCCT_IDe.pBusqueda Then
                                    EtxtCCT_IDe.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                    MetodoBusquedaDato(sender, vIdentificadorDgv, "", False, EtxtCCT_IDe)
                                    EtxtCCT_IDe.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                    EtxtCCT_IDe.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                End If
                        End Select
                    End If
                Case "cCCO_ID" & vIdentificadorDgv
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtCCO_ID.pBusqueda Then
                                EtxtCCO_ID.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                MetodoBusquedaDato(sender, vIdentificadorDgv, "", False, EtxtCCO_ID)
                                EtxtCCO_ID.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                EtxtCCO_ID.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                KeysTab(3)
                            End If
                    End Select
                Case "cCUC_ID" & vIdentificadorDgv
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtCUC_ID.pBusqueda Then
                                EtxtCUC_ID.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                MetodoBusquedaDato(sender, vIdentificadorDgv, "", False, EtxtCUC_ID)
                                EtxtCUC_ID.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                EtxtCUC_ID.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                KeysTab(3)
                            End If
                    End Select
            End Select
        End Sub

        '' ojito
        Private Sub LLamarDTD_ID_DOC(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vDesdeKeyDown As Boolean)
            Dim vDatoBusqueda As String = ""
            Dim vBusquedaDirecta As Boolean = True
            If vDesdeKeyDown Then
                vBusquedaDirecta = False
                vDatoBusqueda = ""
            Else
                vBusquedaDirecta = True
                vDatoBusqueda = "%"
            End If
            EtxtDTD_ID_DOC.pTexto2 = dgv.Item(dgv.CurrentCell.ColumnIndex, dgv.CurrentRow.Index).Value.ToString
            If vProcesarBusquedaDirectaDocumento Then
                MetodoBusquedaDato(dgv, vIdentificadorDgv, vDatoBusqueda, vBusquedaDirecta, EtxtDTD_ID_DOC)
            End If
            vProcesarBusquedaDirectaDocumento = True

            EtxtDTD_ID_DOC.pTexto1 = dgv.Item(dgv.CurrentCell.ColumnIndex, dgv.CurrentRow.Index).Value.ToString
            EtxtDTD_ID_DOC.pTexto2 = dgv.Item(dgv.CurrentCell.ColumnIndex, dgv.CurrentRow.Index).Value.ToString
            If vDesdeKeyDown Then dgv.CurrentCell = dgv.Rows(dgv.CurrentRow.Index).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
        End Sub
        Private Sub LLamarDTD_ID_ROC(ByVal vDesdeKeyDown As Boolean)
            Dim vDatoBusqueda As String = ""
            Dim vBusquedaDirecta As Boolean = True
            If vDesdeKeyDown Then
                vBusquedaDirecta = False
                vDatoBusqueda = ""
            Else
                vBusquedaDirecta = True
                vDatoBusqueda = "%"
            End If
            MetodoBusquedaDato(dgvDetalle, "", vDatoBusqueda, vBusquedaDirecta, EtxtDTD_ID_ROC)
            If vDesdeKeyDown Then KeysTab(3)
        End Sub


        '' ojito
        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvDetalle.CellDoubleClick, dgvDetalleEntregas.CellDoubleClick, dgvDetalleOtros.CellDoubleClick, dgvDetalleTransferencias.CellDoubleClick
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(sender)

            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case "cCCC_ID_CLI" & vIdentificadorDgv
                    If EtxtCCC_ID_CLI.pFormularioConsulta And _
                        Trim(sender.CurrentCell.Value) <> "" Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Tesoreria.Views.frmCajaCtaCte)()
                        frmConsulta.DatoBusquedaConsulta = sender.CurrentCell.Value
                        frmConsulta.MaximizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case "cPER_ID_CLI" & vIdentificadorDgv
                    If EtxtPER_ID_CLI.pFormularioConsulta And _
                        Trim(sender.CurrentCell.Value) <> "" Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                        frmConsulta.DatoBusquedaConsulta = sender.CurrentCell.Value
                        frmConsulta.MaximizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case "cDTD_ID_DOC" & vIdentificadorDgv
                    If EtxtDTD_ID_DOC.pFormularioConsulta And _
                        Trim(sender.CurrentCell.Value) <> "" Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Facturacion.Views.frmDocumentos)()
                        frmConsulta.DatoBusquedaConsulta = sender.CurrentRow.Cells("cTDO_ID_DOC").Value.ToString & _
                                                           sender.CurrentCell.Value.ToString & _
                                                           sender.CurrentRow.Cells("cDTE_SERIE_DOC").Value.ToString & _
                                                           sender.CurrentRow.Cells("cDTE_NUMERO_DOC").Value.ToString
                        frmConsulta.MaximizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case "cMON_ID_DOC" & vIdentificadorDgv
                    If EtxtMON_ID_DOC.pFormularioConsulta And _
                        Trim(sender.CurrentCell.Value) <> "" Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                        frmConsulta.DatoBusquedaConsulta = sender.CurrentCell.Value
                        frmConsulta.MaximizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case "cCHE_ID" & vIdentificadorDgv
                    If EtxtCHE_ID.pFormularioConsulta And _
                        Trim(sender.CurrentCell.Value) <> "" Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Tesoreria.Views.frmCheques)()
                        frmConsulta.DatoBusquedaConsulta = sender.CurrentCell.Value
                        frmConsulta.MaximizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case "cPER_ID_BAN" & vIdentificadorDgv
                    If EtxtPER_ID_BAN.pFormularioConsulta And _
                        Trim(sender.CurrentCell.Value) <> "" Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                        frmConsulta.DatoBusquedaConsulta = sender.CurrentCell.Value
                        frmConsulta.MaximizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case "cPER_ID_CLI_1" & vIdentificadorDgv
                    If EtxtPER_ID_CLI_1.pFormularioConsulta And _
                        Trim(sender.CurrentCell.Value) <> "" Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                        frmConsulta.DatoBusquedaConsulta = sender.CurrentCell.Value
                        frmConsulta.MaximizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case "cMON_ID_DOC_1" & vIdentificadorDgv
                    If EtxtMON_ID_DOC_1.pFormularioConsulta And _
                        Trim(sender.CurrentCell.Value) <> "" Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                        frmConsulta.DatoBusquedaConsulta = sender.CurrentCell.Value
                        frmConsulta.MaximizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case Else
                    If EdgvDetalle.pMetodoColumnas Then
                        For Each vElementos In EdgvDetalle.Columnas
                            If sender.CurrentCell.ColumnIndex = vElementos Then
                                If sender.Columns.Item(sender.CurrentCell.ColumnIndex).Width = EdgvDetalle.pAnchoColumna Then
                                    sender.Columns(sender.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                    sender.Columns(sender.CurrentCell.ColumnIndex).DefaultCellStyle.BackColor = Drawing.Color.White
                                Else
                                    sender.Columns(sender.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                    sender.Columns.Item(sender.CurrentCell.ColumnIndex).Width = EdgvDetalle.pAnchoColumna
                                    sender.Columns(sender.CurrentCell.ColumnIndex).DefaultCellStyle.BackColor = EdgvDetalle.pColorColumna
                                End If
                            End If
                        Next
                    End If
            End Select
        End Sub
        Private Sub ProcesarAnchoColumnasGrid(ByRef dgv As DataGridView, ByVal vReducir As Boolean)
            If EdgvDetalle.pMetodoColumnas Then
                For Each vElementos In EdgvDetalle.Columnas
                    If vReducir Then
                        dgv.Columns(vElementos).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        dgv.Columns.Item(vElementos).Width = EdgvDetalle.pAnchoColumna
                        dgv.Columns(vElementos).DefaultCellStyle.BackColor = EdgvDetalle.pColorColumna
                    Else
                        dgv.Columns(vElementos).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        dgv.Columns(vElementos).DefaultCellStyle.BackColor = Drawing.Color.White
                    End If
                Next
            End If
        End Sub
        Private Sub BusquedaOnlyColumnaGrid(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vBusqueda As Boolean)
            EtxtPER_ID_CLI.pBusqueda = vBusqueda
            EtxtDTD_ID_DOC.pBusqueda = vBusqueda
            EtxtDTD_ID_ROC.pBusqueda = vBusqueda
            EtxtPER_ID_CLI_1.pBusqueda = vBusqueda
            EtxtDTD_ID_DOC_1.pBusqueda = vBusqueda
            EtxtCCO_ID.pBusqueda = vBusqueda
            EtxtCUC_ID.pBusqueda = vBusqueda
            EtxtCCT_IDe.pBusqueda = vBusqueda

            ' Extraordinario este campo es búsqueda compuesta por lo que es solo lectura ya que se seleccionara por F1
            dgv.Columns("cDTD_ID_DOC" & vIdentificadorDgv).ReadOnly = True
            dgv.Columns("cDTD_ID_DOC_1" & vIdentificadorDgv).ReadOnly = True

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        dgv.Columns("cCCO_ID" & vIdentificadorDgv).ReadOnly = False
                        EtxtCCO_ID.pBusqueda = True

                        EtxtCCT_IDe.pBusqueda = True
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                        dgv.Columns("cCUC_ID" & vIdentificadorDgv).ReadOnly = False
                        EtxtCUC_ID.pBusqueda = True
                    End If
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    If cboTipoRecibo.Text = "PAGOS" Then
                    ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                        dgv.Columns("cCCO_ID" & vIdentificadorDgv).ReadOnly = False
                        EtxtCCO_ID.pBusqueda = True
                    ElseIf cboTipoRecibo.Text = "OTROS" Then
                        dgv.Columns("cCUC_ID" & vIdentificadorDgv).ReadOnly = False
                        EtxtCUC_ID.pBusqueda = True
                    End If
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    If cboTipoRecibo.Text = "PAGOS" Then
                        EtxtCUC_ID.pBusqueda = False
                        EtxtCCO_ID.pBusqueda = False
                    ElseIf cboTipoRecibo.Text = "OTROS" Then
                        EtxtCUC_ID.pBusqueda = True
                        EtxtCCO_ID.pBusqueda = True
                    End If
            End Select
        End Sub
        Private Sub dgvDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvDetalle.CellEnter, dgvDetalleEntregas.CellEnter, dgvDetalleOtros.CellEnter, dgvDetalleTransferencias.CellEnter
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(sender)

            If sender.Item("cDTD_MOVIMIENTO_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = BCVariablesNames.Movimiento.Movimiento1 Then
                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)
            Else
                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
            End If

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso
                    If cboTipoRecibo.Text = "PAGOS" Then
                        If Not EtxtDTD_ID_DOC.pBusqueda Then
                            If sender.name = "dgvDetalleEntregas" Then
                                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                            ElseIf sender.name = "dgvDetalleOtros" Then
                                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                            Else
                                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)
                            End If
                        End If
                        If sender.name = "dgvDetalleTransferencias" Then
                            ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                        End If
                    End If
                    'If cboTipoRecibo.Text = "ENTREGAS" Then
                    '    If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then
                    '        If sender.Item("cDTE_CAPITAL_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value <> 0 Or _
                    '           sender.Item("cDTE_INTERES_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value <> 0 Or _
                    '           sender.Item("cDTE_GASTOS_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value <> 0 Then
                    '            ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)
                    '        Else
                    '            ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                    '        End If
                    '    End If
                    'End If
                    'If pTDO_ID = BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco Then
                    '    EtxtDTD_ID_DOC.pBusqueda = False
                    '    EtxtPER_ID_CLI.pBusqueda = False
                    '    ConfigurarColumnasGrid(sender, "cPER_ID_CLI", True, True, vIdentificadorDgv)
                    '    ConfigurarColumnasGrid(sender, "cTDO_ID_DOC", True, True, vIdentificadorDgv)
                    '    ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)
                    'End If
                Case BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque

                    If cboTipoRecibo.Text = "PAGOS" Then
                        If Not EtxtDTD_ID_DOC.pBusqueda Then
                            If sender.name = "dgvDetalleEntregas" Then
                                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                            ElseIf sender.name = "dgvDetalleOtros" Then
                                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                            Else
                                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)
                            End If
                        End If
                        If sender.name = "dgvDetalleTransferencias" Then
                            ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                        End If
                    End If
                    If cboTipoRecibo.Text = "ENTREGAS" Then
                        If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then
                            If sender.Item("cDTE_CAPITAL_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value <> 0 Or _
                               sender.Item("cDTE_INTERES_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value <> 0 Or _
                               sender.Item("cDTE_GASTOS_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value <> 0 Then
                                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)
                            Else
                                ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                            End If
                        End If
                    End If
                    If pTDO_ID = BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco Then
                        EtxtDTD_ID_DOC.pBusqueda = False
                        EtxtPER_ID_CLI.pBusqueda = False
                        ConfigurarColumnasGrid(sender, "cPER_ID_CLI", True, True, vIdentificadorDgv)
                        ConfigurarColumnasGrid(sender, "cTDO_ID_DOC", True, True, vIdentificadorDgv)
                        ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)
                    End If
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    ' OJITO LUNES
                    If Trim(sender.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value) <> "" Then
                        ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)
                        EtxtDTD_ID_DOC.pBusqueda = False
                    Else
                        ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                        EtxtDTD_ID_DOC.pBusqueda = True
                    End If

                    If Trim(sender.Item("cDTD_ID_DOC", sender.CurrentRow.Index).Value) = "" And _
                        Trim(sender.Item("cDTD_ID_DOC_1", sender.CurrentRow.Index).Value) <> "" And _
                        Trim(sender.Item("cCCO_ID", sender.CurrentRow.Index).Value) <> "" And _
                        Trim(sender.Item("cCUC_ID", sender.CurrentRow.Index).Value) <> "" Then
                        ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC_1", False, True, vIdentificadorDgv)
                    Else
                        ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC_1", True, True, vIdentificadorDgv)
                    End If

                    If sender.Item("cEstadoRegistro" & vIdentificadorDgv, sender.CurrentRow.Index).Value <> "1" Then
                        ConfigurarColumnasGrid(sender, "cPER_ID_CLI", False, True, vIdentificadorDgv)
                        EtxtPER_ID_CLI.pBusqueda = True
                    Else
                        ConfigurarColumnasGrid(sender, "cPER_ID_CLI_1", True, True, vIdentificadorDgv)
                        EtxtPER_ID_CLI_1.pBusqueda = False
                    End If
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If Trim(sender.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value) <> "" Then
                        ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)
                        ConfigurarColumnasGrid(sender, "cPER_ID_CLI", True, True, vIdentificadorDgv)
                        EtxtDTD_ID_DOC.pBusqueda = False
                        EtxtPER_ID_CLI.pBusqueda = False
                    Else
                        If Strings.Trim(sender.CurrentRow.Cells("cCUC_ID" & vIdentificadorDgv).Value) <> "" Then
                            EtxtDTD_ID_DOC.pBusqueda = False
                            EtxtPER_ID_CLI.pBusqueda = False
                            ConfigurarColumnasGrid(sender, "cPER_ID_CLI", True, True, vIdentificadorDgv)
                        Else
                            EtxtDTD_ID_DOC.pBusqueda = True
                            EtxtPER_ID_CLI.pBusqueda = True
                            ConfigurarColumnasGrid(sender, "cPER_ID_CLI", False, True, vIdentificadorDgv)
                        End If
                        ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                    End If
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                        Case "tpaEntregas"
                            ConfigurarColumnasGrid(sender, "cDTE_IMPORTE_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(sender, "cPER_ID_CLI", True, False, vIdentificadorDgv)
                            EtxtDTD_ID_DOC.pBusqueda = False
                            EtxtPER_ID_CLI.pBusqueda = False
                        Case "tpaOtros"
                            ConfigurarColumnasGrid(sender, "cPER_ID_CLI", True, False, vIdentificadorDgv)
                            '*
                    End Select
            End Select

            ValidarMedioPago(sender, vIdentificadorDgv)
            ValidarDiferido(sender, vIdentificadorDgv)
            ValidarUbicacion(sender, vIdentificadorDgv)
            ValidarFechaDiferido(sender, vIdentificadorDgv)

            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                Case "cCCC_ID_CLI" & vIdentificadorDgv
                    EtxtCCC_ID_CLI.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cPER_ID_CLI" & vIdentificadorDgv
                    EtxtPER_ID_CLI.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cDTE_IMPORTE_DOC" & vIdentificadorDgv
                    EtxtDTE_IMPORTE_DOC.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cCHE_ID" & vIdentificadorDgv
                    EtxtCHE_ID.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cPER_ID_BAN" & vIdentificadorDgv
                    EtxtPER_ID_BAN.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cPER_ID_CLI_1" & vIdentificadorDgv
                    EtxtPER_ID_CLI_1.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cCCO_ID" & vIdentificadorDgv
                    EtxtCCO_ID.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cCUC_ID" & vIdentificadorDgv
                    EtxtCUC_ID.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cCCT_ID" & vIdentificadorDgv
                    If "cCCT_ID" & vIdentificadorDgv = "cCCT_IDe" Then EtxtCCT_ID.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
            End Select
        End Sub
        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvDetalle.CellValidated, dgvDetalleEntregas.CellValidated, dgvDetalleOtros.CellValidated, dgvDetalleTransferencias.CellValidated
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(sender)

            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                Case "cCCC_ID_CLI" & vIdentificadorDgv
                    sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = _
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString.ToUpper
                    EtxtCCC_ID_CLI.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    ValidarDatos(sender, vIdentificadorDgv, EtxtCCC_ID_CLI, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString, True)

                Case "cPER_ID_CLI" & vIdentificadorDgv
                    sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = cMisProcedimientos.VerificarLongitud(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, 6)
                    EtxtPER_ID_CLI.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                    ValidarDatos(sender, vIdentificadorDgv, EtxtPER_ID_CLI, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, True, sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtPER_ID_CLI.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                    EtxtPER_ID_CLI.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value

                Case "cDTE_FEC_VEN" & vIdentificadorDgv
                    If Not IsDate(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = Now
                    End If

                Case "cDTE_CAPITAL_DOC" & vIdentificadorDgv
                    If Not IsNumeric(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                    End If
                    If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value < 0 Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value * -1
                    End If
                    sender.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = _
                        CDbl(sender.Item("cDTE_CAPITAL_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDTE_INTERES_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDTE_GASTOS_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value)

                Case "cDTE_INTERES_DOC" & vIdentificadorDgv
                    If Not IsNumeric(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                    End If
                    If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value < 0 Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value * -1
                    End If
                    sender.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = _
                        CDbl(sender.Item("cDTE_CAPITAL_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDTE_INTERES_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDTE_GASTOS_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value)

                Case "cDTE_GASTOS_DOC" & vIdentificadorDgv
                    If Not IsNumeric(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                    End If
                    If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value < 0 Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value * -1
                    End If
                    sender.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = _
                        CDbl(sender.Item("cDTE_CAPITAL_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDTE_INTERES_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDTE_GASTOS_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value)

                Case "cDTE_IMPORTE_DOC" & vIdentificadorDgv
                    Dim vProcesarValidarImporte As Boolean = True
                    If Not IsNumeric(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                    End If

                    ' ojo todos los ingresos/egresos son positivos
                    If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value < 0 Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value * -1
                    End If

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                            If Trim(sender.Item("cCUC_ID" & vIdentificadorDgv, sender.CurrentRow.Index).Value) <> "" Then
                                If Trim(sender.Item("cCCO_ID" & vIdentificadorDgv, sender.CurrentRow.Index).Value) <> "" Then
                                    vProcesarValidarImporte = False
                                Else
                                    vProcesarValidarImporte = True
                                End If
                            Else
                                vProcesarValidarImporte = True
                            End If
                        Case BCVariablesNames.ProcesosCaja.PlanillaEgreso, _
                             BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            If cboTipoRecibo.Text = "PAGOS" Then
                                vProcesarValidarImporte = True
                            ElseIf cboTipoRecibo.Text = "ENTREGAS" Or _
                                   cboTipoRecibo.Text = "OTROS" Then
                                vProcesarValidarImporte = False
                                EtxtDTE_IMPORTE_DOC.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                If EtxtDTE_IMPORTE_DOC.pTexto1 <> EtxtDTE_IMPORTE_DOC.pTexto2 Then
                                    ProcesarCambioTipoMonedaDoc(sender, vIdentificadorDgv, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, _
                                                                "", "", "", "", _
                                                                sender.Item("cMON_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value, _
                                                                CambiarMonedaSaldo(sender.Item("cMON_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value), _
                                                                False, False)
                                End If
                                EtxtDTE_IMPORTE_DOC.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                EtxtDTE_IMPORTE_DOC.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                            End If
                        Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                                BCVariablesNames.ProcesosCaja.CajaEgreso,
                                BCVariablesNames.ProcesosCaja.DepositoTercero,
                                BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                                BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                                BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                                BCVariablesNames.ProcesosCaja.VoucherCheque
                            If cboTipoRecibo.Text = "PAGOS" Then
                                If sender.name = "dgvDetalleTransferencias" Then
                                    vProcesarValidarImporte = False

                                    EtxtDTE_IMPORTE_DOC.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                    If EtxtDTE_IMPORTE_DOC.pTexto1 <> EtxtDTE_IMPORTE_DOC.pTexto2 Then
                                        ProcesarCambioTipoMonedaDoc(sender, vIdentificadorDgv, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, _
                                                                    "", "", "", "", _
                                                                    sender.Item("cMON_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value, _
                                                                    CambiarMonedaSaldo(sender.Item("cMON_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value), _
                                                                    False, False)
                                    End If
                                    EtxtDTE_IMPORTE_DOC.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                    EtxtDTE_IMPORTE_DOC.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                                ElseIf sender.name = "dgvDetalleOtros" Or sender.name = "dgvDetalleEntregas" Then
                                    vProcesarValidarImporte = False
                                Else
                                    vProcesarValidarImporte = True
                                End If
                            ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                                vProcesarValidarImporte = False
                            ElseIf cboTipoRecibo.Text = "OTROS" Then
                                vProcesarValidarImporte = False
                            End If
                        Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                            If Trim(sender.CurrentRow.Cells("cCUC_ID" & vIdentificadorDgv).Value.ToString) <> "" Then
                                vProcesarValidarImporte = False
                            Else
                                If sender.Item("cTDO_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = txtTDO_ID.Text And _
                                   sender.Item("cDTE_SERIE_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = txtTES_SERIE.Text And _
                                   sender.Item("cDTE_NUMERO_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = txtTES_NUMERO.Text Then
                                    vProcesarValidarImporte = False
                                Else
                                    vProcesarValidarImporte = True
                                End If
                            End If
                        Case Else
                            vProcesarValidarImporte = True
                    End Select
                    If vProcesarValidarImporte Then
                        EtxtDTE_IMPORTE_DOC.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                        ValidarImporte(sender, vIdentificadorDgv, EtxtDTE_IMPORTE_DOC, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString, True)
                        EtxtDTE_IMPORTE_DOC.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                        EtxtDTE_IMPORTE_DOC.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    Else
                        If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value <= 0 Then
                            sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                            sender.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = 0
                        End If
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                                If Trim(sender.CurrentRow.Cells("cCUC_ID" & vIdentificadorDgv).Value.ToString) <> "" Then
                                    sender.Item("cPER_ID_CLI" & vIdentificadorDgv, sender.CurrentRow.Index).Value = txtPER_ID_CAJ.Text
                                    FiltroDTD_ID_DOC_1(sender, vIdentificadorDgv)
                                    sender.Item("cCCT_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = txtCCT_ID.Text
                                    sender.Item("cTDO_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = txtTDO_ID.Text
                                    sender.Item("cDTD_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = BCVariablesNames.ProcesosCtaCte.SinDocumentoPlaRenCtas
                                    sender.Item("cDTE_SERIE_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = txtTES_SERIE.Text
                                    sender.Item("cDTE_NUMERO_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = txtTES_NUMERO.Text
                                    sender.Item("cMON_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value = txtMON_ID_CCC.Text
                                    sender.Item("cDTE_FEC_VEN" & vIdentificadorDgv, sender.CurrentRow.Index).Value = Today
                                    EtxtPER_ID_CLI.pBusqueda = False
                                    EtxtDTD_ID_DOC.pBusqueda = False
                                Else
                                    EtxtPER_ID_CLI.pBusqueda = True
                                    EtxtDTD_ID_DOC.pBusqueda = True
                                End If
                        End Select
                    End If
                    ValidarMedioPago(sender, vIdentificadorDgv)
                Case "cPER_ID_BAN" & vIdentificadorDgv
                    sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = cMisProcedimientos.VerificarLongitud(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, 6)
                    EtxtPER_ID_BAN.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    ValidarDatos(sender, vIdentificadorDgv, EtxtPER_ID_BAN, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString & BCVariablesNames.TipoPersonas.Banco, True, sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtPER_ID_BAN.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    EtxtPER_ID_BAN.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                Case "cPER_ID_CLI_1" & vIdentificadorDgv
                    sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = cMisProcedimientos.VerificarLongitud(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, 6)
                    'sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = Strings.UCase(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value)
                    EtxtPER_ID_CLI_1.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    ValidarDatos(sender, vIdentificadorDgv, EtxtPER_ID_CLI_1, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString, True, sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtPER_ID_CLI_1.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    EtxtPER_ID_CLI_1.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                Case "cCCO_ID" & vIdentificadorDgv
                    sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = cMisProcedimientos.VerificarLongitud(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, 6)
                    sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString.ToUpper
                    EtxtCCO_ID.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    ValidarDatos(sender, vIdentificadorDgv, EtxtCCO_ID, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString, True)
                    EtxtCCO_ID.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    EtxtCCO_ID.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                Case "cCCT_ID" & vIdentificadorDgv
                    If "cCCT_ID" & vIdentificadorDgv = "cCCT_IDe" Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = cMisProcedimientos.VerificarLongitud(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, 3)
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString.ToUpper
                        EtxtCCT_IDe.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                        ValidarDatos(sender, vIdentificadorDgv, EtxtCCT_IDe, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString, True)
                        EtxtCCT_IDe.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                        EtxtCCT_IDe.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    End If
                Case "cCUC_ID" & vIdentificadorDgv
                    sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = Strings.UCase(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value)
                    EtxtCUC_ID.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    ValidarDatos(sender, vIdentificadorDgv, EtxtCUC_ID, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString, True)
                    EtxtCUC_ID.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    EtxtCUC_ID.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    ValidarMedioPago(sender, vIdentificadorDgv)
                Case "cMPT_GIRADO_A" & vIdentificadorDgv, "cMPT_CONCEPTO" & vIdentificadorDgv, "cDTE_OBSERVACIONES" & vIdentificadorDgv
                    sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = Strings.UCase(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value)
                Case "cMPT_MEDIO_PAGO" & vIdentificadorDgv
                    ValidarMedioPago(sender, vIdentificadorDgv)
                Case "cMPT_DIFERIDO" & vIdentificadorDgv
                    ValidarDiferido(sender, vIdentificadorDgv)
                Case "cMPT_UBICACION" & vIdentificadorDgv
                    ValidarUbicacion(sender, vIdentificadorDgv)
                Case "cMPT_FECHA_DIFERIDO" & vIdentificadorDgv
                    ValidarFechaDiferido(sender, vIdentificadorDgv)
            End Select
        End Sub
        Private Sub dgvDetalle_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
            Handles dgvDetalle.RowHeaderMouseDoubleClick, dgvDetalleEntregas.RowHeaderMouseDoubleClick, dgvDetalleOtros.RowHeaderMouseDoubleClick, dgvDetalleTransferencias.RowHeaderMouseDoubleClick
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(sender)

            If Trim(sender.Item("cPER_ID_CLI_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value) <> "" Then
                If Trim(sender.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value) = "" Then
                    sender.Item("cCCT_ID_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = BCVariablesNames.CCT_ID.ReembolsoPlanillaRendicionCuentas
                    sender.Item("cTDO_ID_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cTDO_ID" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                    sender.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = BCVariablesNames.ProcesosCtaCte.ReembolsoPlaRenCtas
                    sender.Item("cDTE_SERIE_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cDTE_SERIE" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                    sender.Item("cDTE_NUMERO_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cDTE_NUMERO" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                    sender.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                    sender.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                    sender.Item("cMON_ID_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cMON_ID_DOC" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                End If
            End If
        End Sub
        '' ojito
        Private Sub ValidarDatos(ByRef dgv As DataGridView,
                                 ByVal vIdentificadorDgv As String,
                                 ByRef otxt As txt, _
                                 ByVal texto As String, _
                                 ByVal BusquedaDirecta As Boolean, _
                                 Optional ByVal NameCampo As String = "")
            If otxt.pTexto1 <> otxt.pTexto2 Then
                If otxt.pBusqueda Then
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco, _
                             BCVariablesNames.ProcesosCaja.PlanillaEgreso

                            Select Case NameCampo
                                Case "cPER_ID_CLI" & vIdentificadorDgv
                                Case Else
                                    MetodoBusquedaDato(dgv, vIdentificadorDgv, texto, BusquedaDirecta, otxt)
                            End Select
                        Case Else
                            MetodoBusquedaDato(dgv, vIdentificadorDgv, texto, BusquedaDirecta, otxt)
                    End Select
                End If
                Select Case NameCampo
                    Case "cPER_ID_CLI" & vIdentificadorDgv
                        If Trim(dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) <> "" Then
                            otxt.pTexto1 = dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                            otxt.pTexto2 = dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value

                            If cboTipoRecibo.Text = "PAGOS" Then
                                pDevolverDatosUnicoRegistro = True
                                If vProcesarBusquedaDirectaDocumento Then
                                    Select Case tcoTipoRecibo.SelectedTab.Name
                                        Case "tpaPagos"
                                            MetodoBusquedaDato(dgv, vIdentificadorDgv, "", False, EtxtDTD_ID_DOC)
                                        Case Else
                                    End Select
                                End If
                                vProcesarBusquedaDirectaDocumento = True
                            ElseIf cboTipoRecibo.Text = "ENTREGAS" Or _
                                   cboTipoRecibo.Text = "OTROS" Then
                            End If

                            Select Case pTDO_ID
                                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                                Case Else
                                    dgv.CurrentCell = dgv.Rows(dgv.CurrentRow.Index).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                            End Select
                        End If
                    Case "cPER_ID_CLI_1" & vIdentificadorDgv
                        KeysTab(2)
                End Select
            End If
        End Sub
        '' ojito
        Private Sub KeysTab(Optional ByVal Saltos As Integer = 1)
            For vSaltos = 1 To Saltos
                SendKeys.Send(Chr(Keys.Tab))
            Next
        End Sub
#End Region

#Region "DateTimePicker"
        Private Sub ConfigurarDateTimePicker()
            Dim EdtpTemporal As New dtp
            EdtpTemporal.pNombreCampo = "TES_FECHA_EMI"
            EdtpTemporal.pEnabled = False
            EdtpTemporal.pBusqueda = False
            EdtpTemporal.pFormat = DateTimePickerFormat.Short
            EdtpTES_FECHA_EMI = EdtpTemporal
        End Sub
#End Region

#Region "TextBox"
        '' ojito
        Private Sub ConfigurarText()
            ' Cabecera
            EstablecerBuscadores(EtxtDTD_ID)
            EstablecerBuscadores(EtxtCCC_ID)
            EstablecerBuscadores(EtxtPVE_ID)
            EstablecerBuscadores(EtxtPER_ID_CAJ)

            EstablecerBuscadores(EtxtPER_ID_CLI_REC)
            EstablecerBuscadores(EtxtCCT_ID_REC)
            EstablecerBuscadores(EtxtCCC_ID_DES)

            ' Detalle
            EstablecerBuscadores(EtxtCCT_ID, False, False)

            Select Case Me.Name
                Case "frmDepositosBancarios"
                    EstablecerBuscadores(EtxtCCC_ID_CLI, False, True)
                    EstablecerBuscadores(EtxtPER_ID_BAN, False, True)
                Case Else
                    EstablecerBuscadores(EtxtCCC_ID_CLI)
                    EstablecerBuscadores(EtxtPER_ID_BAN)
            End Select

            EstablecerBuscadores(EtxtPER_ID_CLI)
            EstablecerBuscadores(EtxtDTD_ID_DOC, True, True)
            EstablecerBuscadores(EtxtDTD_ID_ROC, True, True)
            EstablecerBuscadores(EtxtDTE_IMPORTE_DOC, True, False)
            EstablecerBuscadores(EtxtMON_ID_DOC, True, True)
            EstablecerBuscadores(EtxtCHE_ID, True, True)

            EstablecerBuscadores(EtxtPER_ID_CLI_1)
            EstablecerBuscadores(EtxtDTD_ID_DOC_1)
            EstablecerBuscadores(EtxtMON_ID_DOC_1, True, True)
            EstablecerBuscadores(EtxtDTD_ID_DOC_CLI_REC, True, True)
            EstablecerBuscadores(EtxtDTD_ID_DOC_CLI_REC_1, True, True)
        End Sub
        '' ojito
        Private Sub EstablecerBuscadores(ByRef Etxt As txt, _
                                         Optional ByVal Busqueda As Boolean = True, _
                                         Optional ByVal FormularioConsulta As Boolean = True)
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
            EtxtTemporal.pSeleccionarTodosEnMarcados = False
            EtxtTemporal.pTotalizarCampo = False
            EtxtTemporal.pNombreCampoTotalizar = ""

            Etxt = EtxtTemporal

            Etxt.pBusqueda = Busqueda
            Etxt.pFormularioConsulta = FormularioConsulta
        End Sub
        '' ojito
        Private Sub TeclaF1SubLlamadas(ByVal vNametxt As String)

        End Sub


#End Region

#End Region
#Region "Secundaria 2"
        Private Sub FormatearCampos()
            FormatearCampos(txtPVE_ID, "PVE_ID", EtxtPVE_ID)

            FormatearCampos(txtTDO_ID, "TDO_ID", EtxtTDO_ID)
            FormatearCampos(txtDTD_ID, "DTD_ID", EtxtDTD_ID)

            FormatearCampos(txtCCC_ID, "CCC_ID", EtxtCCC_ID)

            FormatearCampos(txtMON_ID_CCC, "MON_ID_CCC", EtxtMON_ID_CCC)

            FormatearCampos(txtTES_SERIE, "TES_SERIE", EtxtTES_SERIE)
            FormatearCampos(txtTES_NUMERO, "TES_NUMERO", EtxtTES_NUMERO)

            FormatearCampos(txtPER_ID_CAJ, "PER_ID_CAJ", EtxtPER_ID_CAJ)

            FormatearCampos(cboTES_CIERRE, "TES_CIERRE", Nothing)

            FormatearCampos(txtTES_MONTO_TOTAL, "TES_MONTO_TOTAL", EtxtTES_MONTO_TOTAL, False)

            FormatearCampos(txtPER_ID_CLI_REC, "PER_ID_CAJ", EtxtPER_ID_CLI_REC)
            FormatearCampos(txtCCT_ID_REC, "CCT_ID", EtxtCCT_ID_REC)
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String, ByRef sender As txt, Optional ByVal e As System.Boolean = True)
            FormatearCampos(oObjeto, NombreCampo, Compuesto.vArrayDatosComboBox, Compuesto.vElementosDatosComboBox - 1, sender, e)
        End Sub
        Private Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String, _
        ByVal vArrayDatosComboBox As Object, ByVal vElementos As Int16, _
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
            'EtxtPER_ID_CAJ.pOOrm.CadenaFiltrado = ""
            'EtxtTDO_ID.pOOrm.CadenaFiltrado = ""
            'EtxtCCC_ID.pOOrm.CadenaFiltrado = ""
            'EtxtPVE_ID.pOOrm.CadenaFiltrado = ""
            'EtxtDTD_ID.pOOrm.CadenaFiltrado = ""
        End Sub

        '' ojito
        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 0 ' Personas - Clientes - Detalle
                    Return 0
                Case 2 ' PuntoVenta
                    Return 0
                Case 4 ' CajaCtaCte
                    Return 0
                Case 5 ' Personas - Cajero
                    Return 0
                Case 7 ' CajaCtaCte - Detalle
                    Return 0
                Case 9 ' SaldoDocumentos
                    Return 0
                Case 8, 15, 27, 28 ' Personas - 
                    Return 0
                Case 14 ' RolPersonaTipoPersona
                    Return 0
                Case 17 ' CentroCostos
                    Return 0
                Case 18 ' CuentaContable
                    Return 0
                Case 20 ' PersonaDocumentoIdentidad
                    Return 0
                Case 24 ' CtaCte - Cliente
                    Return 0
                Case 25 ' CajaCtaCte - DES
                    Return 0
            End Select
        End Function

#Region "ComboBox"
        Private Sub ConfigurarComboBox()
            Dim Ecbo As New cbo
            Ecbo.pEnabled = True
            Ecbo.pStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboTipoRecibo = Ecbo
            EcboTES_CIERRE = Ecbo
            EcboCCC_TIPO = Ecbo

            EcboTipoRecibo.pNombreCampo = "TipoRecibo"

            EcboTES_CIERRE.pNombreCampo = "TES_CIERRE"

            EcboCCC_TIPO.pNombreCampo = "CCC_TIPO"
            cboCCC_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        End Sub
#End Region

#Region "TextBox"
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.GotFocus, _
                txtDTD_ID.GotFocus, _
                txtCCT_ID.GotFocus, _
                txtCCC_ID.GotFocus, _
                txtPER_ID_CAJ.GotFocus, _
                txtPER_ID_CLI_REC.GotFocus, _
                txtCCT_ID_REC.GotFocus, _
                txtCCC_ID_DES.GotFocus

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto1 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto1 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto1 = sender.text
                Case "txtCCC_ID"
                    EtxtCCC_ID.pTexto1 = sender.text
                Case "txtPER_ID_CAJ"
                    EtxtPER_ID_CAJ.pTexto1 = sender.text
                Case "txtPER_ID_CLI_REC"
                    EtxtPER_ID_CLI_REC.pTexto1 = sender.text
                Case "txtCCT_ID_REC"
                    EtxtCCT_ID_REC.pTexto1 = sender.text
                Case "txtCCC_ID_DES"
                    EtxtCCC_ID_DES.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.LostFocus, _
                txtDTD_ID.LostFocus, _
                txtCCT_ID.LostFocus, _
                txtCCC_ID.LostFocus, _
                txtPER_ID_CAJ.LostFocus, _
                txtPER_ID_CLI_REC.LostFocus, _
                txtCCT_ID_REC.LostFocus, _
                txtCCC_ID_DES.LostFocus

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    EtxtPVE_ID.pTexto2 = sender.text
                Case "txtDTD_ID"
                    EtxtDTD_ID.pTexto2 = sender.text
                Case "txtCCT_ID"
                    EtxtCCT_ID.pTexto2 = sender.text
                Case "txtCCC_ID"
                    EtxtCCC_ID.pTexto2 = sender.text
                Case "txtPER_ID_CAJ"
                    EtxtPER_ID_CAJ.pTexto2 = sender.text
                Case "txtPER_ID_CLI_REC"
                    EtxtPER_ID_CLI_REC.pTexto2 = sender.text
                Case "txtCCT_ID_REC"
                    EtxtCCT_ID_REC.pTexto2 = sender.text
                Case "txtCCC_ID_DES"
                    EtxtCCC_ID_DES.pTexto2 = sender.text
            End Select

        End Sub
        '' ojito duplica los handles
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.Validated, _
                txtTDO_ID.Validated, _
                txtDTD_ID.Validated, _
                txtCCT_ID.Validated, _
                txtCCC_ID.Validated, _
                txtTES_SERIE.Validated, _
                txtTES_NUMERO.Validated, _
                txtPER_ID_CAJ.Validated, _
                txtPER_ID_CLI_REC.Validated, _
                txtCCT_ID_REC.Validated, _
                txtTES_MONTO_TOTAL.Validated, _
                txtCCC_ID_DES.Validated, _
                txtPRE_SERIE.Validated, _
                txtPRE_NUMERO.Validated

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    ValidarDatos(EtxtPVE_ID, txtPVE_ID)
                Case "txtTDO_ID"
                    ValidarDatos(EtxtTDO_ID, txtTDO_ID)
                Case "txtDTD_ID"
                    ValidarDatos(EtxtDTD_ID, txtDTD_ID)
                Case "txtCCT_ID"
                    ValidarDatos(EtxtCCT_ID, txtCCT_ID)
                Case "txtCCC_ID"
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "' " & _
                                                              " And CCC_ID in ('" & BCVariablesNames.CCC_ID.LiqDocumentoDefault & "','" & BCVariablesNames.CCC_ID.LiqDocumentoDefaultDolares & "') " & _
                                                              " And CCC_ESTADO='ACTIVO' "
                        Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "' " & _
                                                              " And CCC_ID='" & BCVariablesNames.CCC_ID.PlaRenCtasDefault & "' " & _
                                                              " And CCC_ESTADO='ACTIVO' "
                        Case BCVariablesNames.ProcesosCaja.DepositoTercero,
                             BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                             BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.VoucherCheque
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "'" & _
                                                              " And CCC_ESTADO='ACTIVO' "
                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            Select Case Me.Name
                                Case "frmTransferenciaEntreCajas"
                                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And ((CCC_TIPO IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "') " & _
                                                                            " And CCC_ID LIKE '" & txtCCC_ID.Text & "') " & _
                                                                      " Or  (CCC_TIPO NOT IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "','" & BCVariablesNames.TipoCajaCtaCte.LiquidacionDocumento & "') " & _
                                                                            " And 'True'='" & BCVariablesNames.CajeroManejaraCtaBanco & "' " & _
                                                                            " And CCC_ID LIKE '" & txtCCC_ID.Text & "') " & _
                                                                      " And CCC_ESTADO='ACTIVO') " & _
                                                                      " And CCC_ID IN (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ='" & pPER_ID_CAJ & "')"
                                Case "frmDepositosBancarios"
                                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And (CCC_TIPO IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "') " & _
                                                                            " And CCC_ID LIKE '" & txtCCC_ID.Text & "') " & _
                                                                      " And CCC_ESTADO='ACTIVO' " & _
                                                                      " And CCC_ID IN (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ='" & pPER_ID_CAJ & "')"
                            End Select
                        Case Else
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & _
                                                             "' And PER_ID_CAJ='" & pPER_ID_CAJ & _
                                                             "' And PVE_ID='" & pPVE_ID & "' " & _
                                                             " And CCC_ESTADO='ACTIVO' "
                    End Select
                    ValidarDatos(EtxtCCC_ID, txtCCC_ID)
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "' " & _
                                                              " And CCC_ID in ('" & BCVariablesNames.CCC_ID.LiqDocumentoDefault & "','" & BCVariablesNames.CCC_ID.LiqDocumentoDefaultDolares & "') " & _
                                                              " And CCC_ESTADO='ACTIVO' "
                        Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "' " & _
                                                              " And CCC_ID='" & BCVariablesNames.CCC_ID.PlaRenCtasDefault & "' " & _
                                                              " And CCC_ESTADO='ACTIVO' "
                        Case BCVariablesNames.ProcesosCaja.DepositoTercero,
                             BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                             BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.VoucherCheque
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & "'" & _
                                                              " And CCC_ESTADO='ACTIVO' "
                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            Select Case Me.Name
                                Case "frmTransferenciaEntreCajas"
                                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And ((CCC_TIPO IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "')) " & _
                                                                      " Or  (CCC_TIPO NOT IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "','" & BCVariablesNames.TipoCajaCtaCte.LiquidacionDocumento & "') " & _
                                                                                    " And 'True'='" & BCVariablesNames.CajeroManejaraCtaBanco & "') " & _
                                                                      " And CCC_ESTADO='ACTIVO') " & _
                                                                      " And CCC_ID IN (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ='" & pPER_ID_CAJ & "')"
                                Case "frmDepositosBancarios"
                                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And (CCC_TIPO IN ('" & BCVariablesNames.TipoCajaCtaCte.Caja & "')) " & _
                                                                      " And CCC_ESTADO='ACTIVO' " & _
                                                                      " And CCC_ID IN (select CCC_ID from vwCajeroAnexo where PER_ID_CAJ='" & pPER_ID_CAJ & "')"
                            End Select
                        Case Else
                            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & _
                                                             "' And PER_ID_CAJ='" & pPER_ID_CAJ & _
                                                             "' And PVE_ID='" & pPVE_ID & "' " & _
                                                             " And CCC_ESTADO='ACTIVO' "
                    End Select
                Case "txtTES_SERIE"
                    ValidarDatos(EtxtTES_SERIE, txtTES_SERIE)
                Case "txtTES_NUMERO"
                    ValidarDatos(EtxtTES_NUMERO, txtTES_NUMERO)
                Case "txtPER_ID_CAJ"
                    ValidarDatos(EtxtPER_ID_CAJ, txtPER_ID_CAJ)
                Case "txtTES_MONTO_TOTAL"
                    ValidarDatos(EtxtTES_MONTO_TOTAL, txtTES_MONTO_TOTAL)
                Case "txtPER_ID_CLI_REC"
                    txtPER_ID_CLI_REC.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_CLI_REC.Text, txtPER_ID_CLI_REC.MaxLength)
                    ValidarDatos(EtxtPER_ID_CLI_REC, txtPER_ID_CLI_REC)
                Case "txtCCT_ID_REC"
                    txtCCT_ID_REC.Text = cMisProcedimientos.VerificarLongitud(txtCCT_ID_REC.Text, 3)
                    ValidarDatos(EtxtCCT_ID_REC, txtCCT_ID_REC)
                Case "txtCCC_ID_DES"
                    ValidarDatos(EtxtCCC_ID_DES, txtCCC_ID_DES)
                Case "txtPRE_SERIE"
                    txtPRE_SERIE.Text = cMisProcedimientos.VerificarLongitud(txtPRE_SERIE.Text, 3)
                Case "txtPRE_NUMERO"
                    txtPRE_NUMERO.Text = cMisProcedimientos.VerificarLongitud(txtPRE_NUMERO.Text, 10)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtPVE_ID.KeyPress, _
                txtTDO_ID.KeyPress, _
                txtDTD_ID.KeyPress, _
                txtCCT_ID.KeyPress, _
                txtCCC_ID.KeyPress, _
                txtTES_SERIE.KeyPress, _
                txtTES_NUMERO.KeyPress, _
                txtPER_ID_CAJ.KeyPress, _
                txtTES_MONTO_TOTAL.KeyPress, _
                txtPER_ID_CLI_REC.KeyPress, _
                txtCCT_ID_REC.KeyPress, _
                txtCCC_ID_DES.KeyPress

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    oKeyPress(EtxtPVE_ID, e)
                Case "txtTDO_ID"
                    oKeyPress(EtxtTDO_ID, e)
                Case "txtDTD_ID"
                    oKeyPress(EtxtDTD_ID, e)
                Case "txtCCT_ID"
                    oKeyPress(EtxtCCT_ID, e)
                Case "txtCCC_ID"
                    oKeyPress(EtxtCCC_ID, e)
                Case "txtTES_SERIE"
                    oKeyPress(EtxtTES_SERIE, e)
                Case "txtTES_NUMERO"
                    oKeyPress(EtxtTES_NUMERO, e)
                Case "txtPER_ID_CAJ"
                    oKeyPress(EtxtPER_ID_CAJ, e)
                Case "txtTES_MONTO_TOTAL"
                    oKeyPress(EtxtTES_MONTO_TOTAL, e)
                Case "txtPER_ID_CLI_REC"
                    oKeyPress(EtxtPER_ID_CLI_REC, e)
                Case "txtCCT_ID_REC"
                    oKeyPress(EtxtCCT_ID_REC, e)
                Case "txtCCC_ID_DES"
                    oKeyPress(EtxtCCC_ID_DES, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPVE_ID.DoubleClick, _
                txtDTD_ID.DoubleClick, _
                txtCCT_ID.DoubleClick, _
                txtCCC_ID.DoubleClick, _
                txtPER_ID_CAJ.DoubleClick, _
                txtPER_ID_CLI_REC.DoubleClick, _
                txtCCT_ID_REC.DoubleClick, _
                txtCCC_ID_DES.DoubleClick

            Select Case sender.name.ToString
                Case "txtPVE_ID"
                    oDoubleClick(EtxtPVE_ID, txtPVE_ID, "frmPuntoVenta")
                Case "txtDTD_ID"
                    Dim vtxtDTD_ID As New TextBox
                    vtxtDTD_ID.Text = txtCCT_ID.Text & txtTDO_ID.Text & txtDTD_ID.Text
                    oDoubleClick(EtxtDTD_ID, vtxtDTD_ID, "frmRolOpeCtaCte")
                Case "txtCCT_ID"
                    oDoubleClick(EtxtCCT_ID, txtCCT_ID, "")
                Case "txtCCC_ID"
                    oDoubleClick(EtxtCCC_ID, txtCCC_ID, "")
                Case "txtPER_ID_CAJ"
                    oDoubleClick(EtxtPER_ID_CAJ, txtPER_ID_CAJ, "frmPersonas")
                Case "txtPER_ID_CLI_REC"
                    oDoubleClick(EtxtPER_ID_CLI_REC, txtPER_ID_CLI_REC, "frmPersonas")
                Case "txtCCT_ID_REC"
                    oDoubleClick(EtxtCCT_ID_REC, txtCCT_ID_REC, "frmRolOpeCtaCte")
                Case "txtCCC_ID_DES"
                    oDoubleClick(EtxtCCC_ID_DES, txtCCC_ID_DES, "")
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
                    Case "frmPuntoVenta"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPuntoVenta)()
                    Case "frmRolOpeCtaCte"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmRolOpeCtaCte)()
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
        '' ojito
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtPVE_ID.KeyDown, _
                txtDTD_ID.KeyDown, _
                txtCCT_ID.KeyDown, _
                txtCCC_ID.KeyDown, _
                txtPER_ID_CAJ.KeyDown, _
                txtPER_ID_CLI_REC.KeyDown, _
                txtCCT_ID_REC.KeyDown, _
                txtCCC_ID_DES.KeyDown
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtPVE_ID"
                            TeclaF1(EtxtPVE_ID, txtPVE_ID, sender.name.ToString)
                        Case "txtDTD_ID"
                            TeclaF1(EtxtDTD_ID, txtDTD_ID, sender.name.ToString)
                        Case "txtCCT_ID"
                            TeclaF1(EtxtCCT_ID, txtCCT_ID, sender.name.ToString)
                        Case "txtCCC_ID"
                            TeclaF1(EtxtCCC_ID, txtCCC_ID, sender.name.ToString)
                        Case "txtPER_ID_CAJ"
                            TeclaF1(EtxtPER_ID_CAJ, txtPER_ID_CAJ, sender.name.ToString)
                        Case "txtPER_ID_CLI_REC"
                            TeclaF1(EtxtPER_ID_CLI_REC, txtPER_ID_CLI_REC, sender.name.ToString)
                        Case "txtCCT_ID_REC"
                            TeclaF1(EtxtCCT_ID_REC, txtCCT_ID_REC, sender.name.ToString)
                        Case "txtCCC_ID_DES"
                            TeclaF1(EtxtCCC_ID_DES, txtCCC_ID_DES, sender.name.ToString)
                    End Select
            End Select
        End Sub
#End Region

#End Region

        Private Sub CampoGridDetalleNoReadOnlySiVisibleTodo(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cItem", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cTDO_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCT_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", False, True, vIdentificadorDgv)
            '''
            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCO_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_OBSERVACIONES", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cEstadoRegistro", False, True, vIdentificadorDgv)
        End Sub
        Private Sub CampoGridDetalleDefault(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cItem", True, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cTDO_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCT_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, True, vIdentificadorDgv)


            ConfigurarColumnasGrid(dgv, "cDTE_CAPITAL_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_INTERES_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_GASTOS_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCO_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_OBSERVACIONES", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_IDr", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cEstadoRegistro", True, False, vIdentificadorDgv)
        End Sub

        Private Sub CampoGridDetalleTransferenciasDefault()
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cItemt", True, True, "")

            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cTDO_IDt", True, False, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTD_IDt", True, False, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCCC_IDt", True, False, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_SERIEt", True, False, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_NUMEROt", True, False, "")

            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCCT_IDt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCCT_DESCRIPCIONt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCCC_ID_CLIt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCCC_DESCRIPCION_CLIt", True, True, "")

            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cPER_ID_CLIt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cPER_DESCRIPCION_CLIt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_FEC_VENt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTD_MOVIMIENTO_DOCt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCCT_ID_DOCt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cTDO_ID_DOCt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTD_ID_DOCt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_SERIE_DOCt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_NUMERO_DOCt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_IMPORTE_DOCt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_CONTRAVALOR_DOCt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMON_ID_DOCt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMON_DESCRIPCION_DOCt", True, True, "")

            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_DESTINOt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCHE_IDt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_MEDIO_PAGOt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_IMPORTE_AFECTOt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_PORCENTAJEt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_SERIE_MEDIOt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_NUMERO_MEDIOt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_GIRADO_At", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_CONCEPTOt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cPER_ID_BANt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_DIFERIDOt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_FECHA_DIFERIDOt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_RECEPCIONt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMPT_UBICACIONt", False, True, "")

            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cPER_ID_CLI_1t", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cPER_DESCRIPCION_CLI_1t", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_FEC_VEN_1t", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCCT_ID_DOC_1t", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cTDO_ID_DOC_1t", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTD_ID_DOC_1t", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_SERIE_DOC_1t", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_NUMERO_DOC_1t", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_IMPORTE_DOC_1t", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_CONTRAVALOR_DOC_1t", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMON_ID_DOC_1t", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cMON_DESCRIPCION_DOC_1t", True, True, "")

            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCCO_IDt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCCO_DESCRIPCIONt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCUC_IDt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cCUC_DESCRIPCIONt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_OPE_CONTABLEt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_OBSERVACIONESt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_MOVIMIENTOt", False, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cDTE_ESTADOt", True, True, "")
            ConfigurarColumnasGrid(dgvDetalleTransferencias, "cEstadoRegistrot", True, False, "")
        End Sub

        Private Sub ConfigurarCampoVisualizarGridDetalle(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            CampoGridDetalleDefault(dgv, vIdentificadorDgv)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.DepositoTercero
                    CampoGridDetalleDepositoTercero(dgv, vIdentificadorDgv)
                Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    CampoGridDetalleNotaAbonoBanco(dgv, vIdentificadorDgv)
                Case BCVariablesNames.ProcesosCaja.CajaIngreso 
                    CampoGridDetalleReciboIngresos(dgv, vIdentificadorDgv)
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                    CampoGridDetalleDetraccionesNotaCargoCtaBanco(dgv, vIdentificadorDgv)
                Case BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque,
                    BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    If dgv.Name = "dgvDetalleTransferencias" Then
                        CampoGridDetalleTransferenciasEntreCajas(dgv, vIdentificadorDgv)
                    Else
                        CampoGridDetalleReciboEgresos(dgv, vIdentificadorDgv)
                    End If
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    If dgv.Name = "dgvDetalle" Then
                        CampoGridDetalleTransferenciasEntreCajas(dgv, vIdentificadorDgv)
                    ElseIf dgv.Name = "dgvDetalleOtros" Then
                        CampoGridDetalleTransferenciasEntreCajasDgvDetalleOtros(dgv, vIdentificadorDgv)
                    End If
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    CampoGridDetalleLiquidacionDocumento(dgv, vIdentificadorDgv)
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    CampoGridDetallePlanillaRendicionCuentas(dgv, vIdentificadorDgv)
            End Select
        End Sub

        Private Sub CampoGridDetalleDetraccionesNotaCargoCtaBanco(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", True, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            If cboTipoRecibo.Text = "PAGOS" Then
                ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
            ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
            ElseIf cboTipoRecibo.Text = "OTROS" Then
                ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
            End If

            ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, False, vIdentificadorDgv)
        End Sub

        Private Sub CampoGridDetalleReciboEgresos(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            If cboTipoRecibo.Text = "PAGOS" Then
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                         BCVariablesNames.ProcesosCaja.CajaEgreso, _
                         BCVariablesNames.ProcesosCaja.VoucherCheque
                        If dgv.Name = "dgvDetalleOtros" Then
                            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                            If pTDO_ID = BCVariablesNames.ProcesosCaja.VoucherCheque Then
                                ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, True, vIdentificadorDgv)
                            End If


                            ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                        ElseIf dgv.Name = "dgvDetalleEntregas" Then
                            ConfigurarColumnasGrid(dgv, "cCCT_ID", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, True, vIdentificadorDgv)

                            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                            ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                        Else
                            ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                        End If
                    Case Else
                        ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                End Select
            ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
            ElseIf cboTipoRecibo.Text = "OTROS" Then
                ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
            End If

            ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, False, vIdentificadorDgv)

            'CampoGridDetalleNoReadOnlySiVisibleTodo(dgv, vIdentificadorDgv)

        End Sub

        Private Sub CampoGridDetalleDepositoBancario(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case txtCCT_ID.Text
                Case BCVariablesNames.CCT_ID.TransferenciaEntreCajaCtaCteBanco
                    ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
                Case BCVariablesNames.CCT_ID.CxCComerciales, _
                    BCVariablesNames.CCT_ID.CxPComerciales
                    ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cCCO_ID", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_ID", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            End Select
        End Sub

        Private Sub CampoGridDetalleLiquidacionDocumento(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)

            '''
            If cboTipoRecibo.Text = "PAGOS" Then
                ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                '''EtxtCUC_ID.pBusqueda = False
                '''EtxtCCO_ID.pBusqueda = False
            ElseIf cboTipoRecibo.Text = "OTROS" Then
                ConfigurarColumnasGrid(dgv, "cCCO_ID", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCUC_ID", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", False, True, vIdentificadorDgv)
                '''EtxtCUC_ID.pBusqueda = True
                '''EtxtCCO_ID.pBusqueda = True
            End If

            cDTE_IMPORTE_DOC.HeaderText = "Cargo"
            cDTE_IMPORTE_DOC_1.HeaderText = "Abono"
        End Sub
        Private Sub CampoGridDetallePlanillaRendicionCuentas(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            'CampoGridDetalleNoReadOnlySiVisibleTodo(dgv, vIdentificadorDgv)
            'Exit Sub
            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)

            Select Case tcoTipoRecibo.SelectedTab.Name
                Case "tpaPagos"
                    ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

                    cPER_ID_CLI.HeaderText = "Cód.Cliente Pagos"
                    cPER_DESCRIPCION_CLI.HeaderText = "Desc.Cliente Pagos"
                    cDTD_ID_DOC.HeaderText = "Cód. Tip. Doc. Pagos"
                    cDTE_SERIE_DOC.HeaderText = "Serie Doc. Pagos"
                    cDTE_NUMERO_DOC.HeaderText = "Número Doc. Pagos"
                    cDTE_IMPORTE_DOC.HeaderText = "Importe"
                Case "tpaEntregas"
                    ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, True, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", False, True, vIdentificadorDgv)

                    cCCT_ID_DOC_1e.HeaderText = "Cta. Cte. Doc. E.R.C."
                    cPER_ID_CLI_1e.HeaderText = "Cód.Cliente E.R.C."
                    cPER_DESCRIPCION_CLI_1e.HeaderText = "Desc.Cliente E.R.C."
                    cDTD_ID_DOC_1e.HeaderText = "Cód. Tip. Doc. E.R.C."
                    cDTE_SERIE_DOC_1e.HeaderText = "Serie Doc. E.R.C."
                    cDTE_NUMERO_DOC_1e.HeaderText = "Número Doc. E.R.C."
                    cDTE_IMPORTE_DOC_1e.HeaderText = "Importe"
                    cDTE_CONTRAVALOR_DOC_1e.HeaderText = "Contravalor"
                    cMON_ID_DOC_1e.HeaderText = "Cod. Moneda"
                Case "tpaOtros"
                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cCCO_ID", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, True, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cCUC_ID", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, True, vIdentificadorDgv)
            End Select

            If dgv.Name = "dgvDetalle" Then
                'ConfigurarColumnasGrid(dgv, "cCCT_ID", False, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, True, vIdentificadorDgv)

                'ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", False, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)

                'ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)

                'ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

                'cPER_ID_CLI.HeaderText = "Cód.Cliente Pagos"
                'cPER_DESCRIPCION_CLI.HeaderText = "Desc.Cliente Pagos"
                'cDTD_ID_DOC.HeaderText = "Cód. Tip. Doc. Pagos"
                'cDTE_SERIE_DOC.HeaderText = "Serie Doc. Pagos"
                'cDTE_NUMERO_DOC.HeaderText = "Número Doc. Pagos"
                'cDTE_IMPORTE_DOC.HeaderText = "Importe"
            ElseIf dgv.Name = "dgvDetalleEntregas" Then
                'ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, True, vIdentificadorDgv)

                'ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", True, False, vIdentificadorDgv)

                'ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                'ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", False, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", False, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", False, True, vIdentificadorDgv)

                'cPER_ID_CLI_1e.HeaderText = "Cód.Cliente E.R.C."
                'cPER_DESCRIPCION_CLI_1e.HeaderText = "Desc.Cliente E.R.C."
                'cDTD_ID_DOC_1e.HeaderText = "Cód. Tip. Doc. E.R.C."
                'cDTE_SERIE_DOC_1e.HeaderText = "Serie Doc. E.R.C."
                'cDTE_NUMERO_DOC_1e.HeaderText = "Número Doc. E.R.C."
                'cDTE_IMPORTE_DOC_1e.HeaderText = "Importe"
            ElseIf dgv.Name = "dgvDetalleOtros" Then
                'ConfigurarColumnasGrid(dgv, "cCCO_ID", False, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, True, vIdentificadorDgv)

                'ConfigurarColumnasGrid(dgv, "cCUC_ID", False, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, True, vIdentificadorDgv)
            End If
        End Sub

        Private Sub CampoGridDetallePagos(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)


            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, True, vIdentificadorDgv)
        End Sub
        Private Sub CampoGridDetalleEntregas(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)


            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCO_ID", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, True, vIdentificadorDgv)
        End Sub
        Private Sub CampoGridDetalleReciboIngresos(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            If cboTipoRecibo.Text = "PAGOS" Then
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                         BCVariablesNames.ProcesosCaja.DepositoTercero, _
                         BCVariablesNames.ProcesosCaja.CajaIngreso
                        Select Case tcoTipoRecibo.SelectedTab.Name
                            Case "tpaPagos"
                                ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                            Case "tpaEntregas"
                                ConfigurarColumnasGrid(dgv, "cCCT_ID", False, True, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, True, vIdentificadorDgv)

                                ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                                ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)

                                Select Case pTDO_ID
                                    Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                                        ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", False, True, vIdentificadorDgv)
                                        ConfigurarColumnasGrid(dgv, "cDTE_CAPITAL_DOC", False, True, vIdentificadorDgv)
                                        ConfigurarColumnasGrid(dgv, "cDTE_INTERES_DOC", False, True, vIdentificadorDgv)
                                        ConfigurarColumnasGrid(dgv, "cDTE_GASTOS_DOC", False, True, vIdentificadorDgv)
                                    Case Else
                                        ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                                        ConfigurarColumnasGrid(dgv, "cDTE_CAPITAL_DOC", True, False, vIdentificadorDgv)
                                        ConfigurarColumnasGrid(dgv, "cDTE_INTERES_DOC", True, False, vIdentificadorDgv)
                                        ConfigurarColumnasGrid(dgv, "cDTE_GASTOS_DOC", True, False, vIdentificadorDgv)
                                End Select
                            Case "tpaOtros"
                                ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                                ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                        End Select

                        If dgv.Name = "dgvDetalleOtros" Then
                        ElseIf dgv.Name = "dgvDetalleEntregas" Then
                        Else
                        End If
                    Case Else
                        ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                End Select
            ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)

                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                        ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", False, True, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cDTE_CAPITAL_DOC", False, True, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cDTE_INTERES_DOC", False, True, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cDTE_GASTOS_DOC", False, True, vIdentificadorDgv)
                    Case Else
                        ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cDTE_CAPITAL_DOC", True, False, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cDTE_INTERES_DOC", True, False, vIdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cDTE_GASTOS_DOC", True, False, vIdentificadorDgv)
                End Select

            ElseIf cboTipoRecibo.Text = "OTROS" Then
                ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)

                ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)

                ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)

                ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
            End If

            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, False, vIdentificadorDgv)
        End Sub
        Private Sub CampoGridDetalleDepositoTercero(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CAPITAL_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_INTERES_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_GASTOS_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)

            ' Modificado 2015-07-16
            'ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)
            Select Case dgv.Name
                Case "dgvDetalle"
                    Me.cMPT_NUMERO_MEDIO.HeaderText = "Operación bancaria"
                Case "dgvDetalleEntregas"
                    Me.cMPT_NUMERO_MEDIOe.HeaderText = "Operación bancaria"
                Case "dgvDetalleOtros"
                    Me.cMPT_NUMERO_MEDIOo.HeaderText = "Operación bancaria"
            End Select

            Select Case tcoTipoRecibo.SelectedTab.Name
                Case "tpaPagos"
                    ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                Case "tpaEntregas"
                    ConfigurarColumnasGrid(dgv, "cCCT_ID", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, True, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                Case "tpaOtros"
                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
            End Select

            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, False, vIdentificadorDgv)
        End Sub
        Private Sub CampoGridDetalleNotaAbonoBanco(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)


            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            ' Modificado 2015-07-31
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)
            Select Case dgv.Name
                Case "dgvDetalle"
                    Me.cMPT_NUMERO_MEDIO.HeaderText = "Operación bancaria"
                Case "dgvDetalleEntregas"
                    Me.cMPT_NUMERO_MEDIOe.HeaderText = "Operación bancaria"
                Case "dgvDetalleOtros"
                    Me.cMPT_NUMERO_MEDIOo.HeaderText = "Operación bancaria"
            End Select

            'If cboTipoRecibo.Text = "PAGOS" Then
            'Select Case pTDO_ID
            '    Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
            '         BCVariablesNames.ProcesosCaja.DepositoTercero, _
            '         BCVariablesNames.ProcesosCaja.CajaIngreso
            Select Case tcoTipoRecibo.SelectedTab.Name
                Case "tpaPagos"
                    ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
                Case "tpaEntregas"
                    ConfigurarColumnasGrid(dgv, "cCCT_ID", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, True, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_CAPITAL_DOC", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_INTERES_DOC", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_GASTOS_DOC", False, True, vIdentificadorDgv)
                Case "tpaOtros"
                    ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
            End Select
            '    Case Else
            'ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
            'End Select


            'ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
            'ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
            'Select Case pTDO_ID
            '    Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
            '        ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", False, True, vIdentificadorDgv)
            '        ConfigurarColumnasGrid(dgv, "cDTE_CAPITAL_DOC", False, True, vIdentificadorDgv)
            '        ConfigurarColumnasGrid(dgv, "cDTE_INTERES_DOC", False, True, vIdentificadorDgv)
            '        ConfigurarColumnasGrid(dgv, "cDTE_GASTOS_DOC", False, True, vIdentificadorDgv)
            '    Case Else
            '        ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            '        ConfigurarColumnasGrid(dgv, "cDTE_CAPITAL_DOC", True, False, vIdentificadorDgv)
            '        ConfigurarColumnasGrid(dgv, "cDTE_INTERES_DOC", True, False, vIdentificadorDgv)
            '        ConfigurarColumnasGrid(dgv, "cDTE_GASTOS_DOC", True, False, vIdentificadorDgv)
            'End Select
            'ElseIf cboTipoRecibo.Text = "OTROS" Then
            'ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
            'End If

            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, False, vIdentificadorDgv)
        End Sub
        Private Sub CampoGridDetalleTransferenciasEntreCajas(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, True, vIdentificadorDgv)
            Select Case Me.Name
                Case "frmTransferenciaEntreCajas"
                Case "frmDepositosBancarios"
                    ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, True, vIdentificadorDgv)
            End Select
            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCUC_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cEstadoRegistro", True, False, vIdentificadorDgv)
        End Sub
        Private Sub CampoGridDetalleTransferenciasEntreCajasDgvDetalleOtros(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)

            'txtTDO_ID.Text, _
            'txtDTD_ID.Text, _
            'txtCCC_ID.Text, _
            'txtTES_SERIE.Text, _
            'txtTES_NUMERO.Text,


            'ConfigurarColumnasGrid(dgv, "cTDO_ID", True, True, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTD_ID", True, True, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_SERIE", True, True, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cDTE_NUMERO", True, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCT_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID_CLI", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_DESCRIPCION_CLI", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_DESTINO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCHE_ID", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_IMPORTE_AFECTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_PORCENTAJE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_RECEPCION", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_UBICACION", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID_DOC_1", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC_1", True, False, vIdentificadorDgv)

            If cboTipoRecibo.Text = "PAGOS" Then
                If dgv.Name = "dgvDetalleOtros" Then
                    ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_FEC_VEN", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_MOVIMIENTO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_SERIE_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_NUMERO_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_IMPORTE_DOC", False, True, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cDTE_CONTRAVALOR_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_ID_DOC", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMON_DESCRIPCION_DOC", True, False, vIdentificadorDgv)

                    ConfigurarColumnasGrid(dgv, "cCCO_ID", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cCCO_DESCRIPCION", True, False, vIdentificadorDgv)
                End If
            End If

            ConfigurarColumnasGrid(dgv, "cMPT_MEDIO_PAGO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_OPE_CONTABLE", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDTE_MOVIMIENTO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTE_ESTADO", True, False, vIdentificadorDgv)

            'CampoGridDetalleNoReadOnlySiVisibleTodo(dgv, vIdentificadorDgv)
        End Sub


        '' ojito - Inhabilita campos que no se deben modificar cuando el grid no esta vacio
        'Private Sub ProcesarGridVacio()
        '    If dgvDetalle.RowCount = 0 Then
        '        txtDTD_ID.Enabled = True
        '        txtCCC_ID.Enabled = True
        '        'dtpTES_FECHA_EMI.Enabled = True
        '    End If
        'End Sub

        Private Sub cboSerieCorrelativo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerieCorrelativo.TextChanged
            ProcesarSerie()
        End Sub
        Private Sub cboSerieCorrelativo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSerieCorrelativo.Validated
            ProcesarSerie()
        End Sub
        Private Sub ProcesarSerie()
            If cboSerieCorrelativo.DataSource Is Nothing Then Exit Sub
            ConfigurarReadOnlyNoBusqueda(txtTES_SERIE, EtxtTES_SERIE, True) ' BLoquea

            If Not pRegistroNuevo Then
                If IsNothing(cboSerieCorrelativo.DataSource) Then
                    txtTES_SERIE.Text = ""
                Else
                    txtTES_SERIE.Text = cboSerieCorrelativo.Text
                End If
                If pTES_SERIEpep <> txtTES_SERIE.Text Then
                    txtTES_NUMERO.Text = cboSerieCorrelativo.SelectedValue.ToString
                Else
                    txtTES_NUMERO.Text = pTES_NUMEROpep
                End If
            Else
                txtTES_SERIE.Text = cboSerieCorrelativo.Text
                txtTES_NUMERO.Text = cboSerieCorrelativo.SelectedValue.ToString
            End If

            If txtTES_NUMERO.Text = "0" Then
                Compuesto3.CTD_USAR_COR = 0
                ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, False)
            Else
                Compuesto3.CTD_USAR_COR = 1
                ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, True)
            End If
        End Sub
        Public Sub BuscarSeries()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    Compuesto1.Vista = "BuscarCorrelativosCheque"
                    Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()

                    Dim ds As New DataSet
                    Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                        txtCCC_ID.Text, _
                                                                        txtTDO_ID.Text, _
                                                                        txtDTD_ID.Text, _
                                                                        Nothing, _
                                                                        " "
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
                        txtTES_NUMERO.Text = ""
                    End If
                Case Else
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
                        txtTES_NUMERO.Text = ""
                    End If
            End Select
        End Sub

        'Private Sub ActualizarCorrelativo()
        '    Compuesto1.Vista = "BuscarCorrelativos"
        '    Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()

        '    Dim ds As New DataSet
        '    Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
        '                                                        txtPVE_ID.Text, _
        '                                                        txtTDO_ID.Text, _
        '                                                        txtDTD_ID.Text, _
        '                                                        txtTES_SERIE.Text, _
        '                                                        " And PVE_ID+CTD_COR_SERIE  In (select PVE_ID+CTD_COR_SERIE from vwSeriesDatosUsuarios " & _
        '                                                                                       "where USU_ID='" & SessionService.UserId & "' and TDO_ID='" & txtTDO_ID.Text & "' and SDU_ESTADO='ACTIVO')"
        '                                                       )
        '                              )

        '    Dim vcontrol As Int16 = sr.Peek
        '    If vcontrol <> -1 Then
        '        ds.ReadXml(sr)
        '        cboSerieCorrelativo.DataSource = ds.Tables(0)
        '        cboSerieCorrelativo.DisplayMember = "CTD_COR_SERIE"
        '        cboSerieCorrelativo.ValueMember = "CTD_COR_NUMERO"
        '        txtTES_SERIE.Text = cboSerieCorrelativo.Text
        '        txtTES_NUMERO.Text = cboSerieCorrelativo.SelectedValue.ToString
        '    Else
        '        cboSerieCorrelativo.DataSource = Nothing
        '        txtTES_SERIE.Text = ""
        '        txtTES_NUMERO.Text = ""
        '    End If
        'End Sub

        Public Sub ProcesarFechaServidor()
            dtpTES_FECHA_EMI.Text = IBCMaestro.EjecutarVista("spFechaServidor")
            tslFechaServidor.Text = "Fecha de trabajo: " & dtpTES_FECHA_EMI.Text
        End Sub

        Private Function ValidarAdicionarFilasGrid() As Boolean
            ValidarAdicionarFilasGrid = True
            Return ValidarAdicionarFilasGrid
        End Function
        '' ojito
        Private Sub InicializarDatosGrid(ByRef dgv As DataGridView, ByVal vIdentificadoDgv As String, ByVal vControl As Boolean)
            If vControl Then
                If dgv.RowCount > 0 Then
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.PlanillaEgreso
                            pPER_ID_CLI = ""
                            pPER_DESCRIPCION_CLI = ""
                            pPER_ID_CLI_1 = ""
                            pPER_DESCRIPCION_CLI_1 = ""
                        Case BCVariablesNames.ProcesosCaja.CajaIngreso, _
                             BCVariablesNames.ProcesosCaja.CajaEgreso, _
                             BCVariablesNames.ProcesosCaja.DepositoTercero
                            Try
                                pPER_ID_CLI = dgv.CurrentRow.Cells("cPER_ID_CLI" & vIdentificadoDgv).Value
                                pPER_DESCRIPCION_CLI = dgv.CurrentRow.Cells("cPER_DESCRIPCION_CLI" & vIdentificadoDgv).Value
                            Catch ex As Exception
                                pPER_ID_CLI = ""
                                pPER_DESCRIPCION_CLI = ""
                            End Try
                        Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                            Try
                                pPER_ID_CLIe = dgv.CurrentRow.Cells("cPER_ID_CLIe" & vIdentificadoDgv).Value
                                pPER_DESCRIPCION_CLIe = dgv.CurrentRow.Cells("cPER_DESCRIPCION_CLIe" & vIdentificadoDgv).Value
                                pCCT_IDe = dgv.CurrentRow.Cells("cCCT_IDe" & vIdentificadoDgv).Value
                                pCCT_DESCRIPCIONe = dgv.CurrentRow.Cells("cCCT_DESCRIPCIONe" & vIdentificadoDgv).Value
                            Catch ex As Exception
                                pPER_ID_CLIe = ""
                                pPER_DESCRIPCION_CLIe = ""
                                pCCT_IDe = ""
                                pCCT_DESCRIPCIONe = ""
                            End Try
                        Case Else
                            If dgv.Name = "dgvDetalle" Or dgv.Name = "dgvDetalleEntregas" Then
                            End If
                    End Select
                Else
                    If cboTipoRecibo.Text = "OTROS" Then
                    Else
                        If pTDO_ID = BCVariablesNames.ProcesosCaja.DepositoTercero Then
                            pPER_ID_CLI = txtPER_ID_CLI_REC.Text
                            pPER_DESCRIPCION_CLI = txtPER_DESCRIPCION_CLI_REC.Text
                        Else
                            pPER_ID_CLI = ""
                            pPER_DESCRIPCION_CLI = ""
                        End If
                        pPER_ID_CLI_1 = ""
                        pPER_DESCRIPCION_CLI_1 = ""
                    End If
                End If
            Else
                dgv.Rows(dgv.RowCount - 1).Cells("cPER_ID_CLI" & vIdentificadoDgv).Value = pPER_ID_CLI
                dgv.Rows(dgv.RowCount - 1).Cells("cPER_DESCRIPCION_CLI" & vIdentificadoDgv).Value = pPER_DESCRIPCION_CLI
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                        EtxtPER_ID_CLI.pTexto1 = pPER_ID_CLI
                        EtxtPER_ID_CLI.pTexto2 = pPER_ID_CLI
                        dgv.Rows(dgv.RowCount - 1).Cells("cPER_ID_CLI_1" & vIdentificadoDgv).Value = pPER_ID_CLI_1
                        dgv.Rows(dgv.RowCount - 1).Cells("cPER_DESCRIPCION_CLI_1" & vIdentificadoDgv).Value = pPER_DESCRIPCION_CLI_1
                        If dgv.RowCount <> 1 Then
                            EtxtDTD_ID_DOC.pOOrm.CadenaFiltrado = " And PER_ID_CLI = '" & dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, dgv.RowCount - 1).Value & _
                                                                 "' And CCT_ID_REF = '" & BCVariablesNames.CCT_ID.CxPComerciales & _
                                                                 "' And TDO_ID_REF = '" & dgv.Item("cTDO_ID_DOC" & vIdentificadoDgv, dgv.RowCount - 1).Value & _
                                                                 "' And DTD_ID_REF = '" & dgv.Item("cDTD_ID_DOC" & vIdentificadoDgv, dgv.RowCount - 1).Value & _
                                                                 "' And DOC_SERIE_REF = '" & dgv.Item("cDTE_SERIE_DOC" & vIdentificadoDgv, dgv.RowCount - 1).Value & _
                                                                 "' And DOC_NUMERO_REF = '" & dgv.Item("cDTE_NUMERO_DOC" & vIdentificadoDgv, dgv.RowCount - 1).Value & "'"
                            LLamarDTD_ID_DOC(dgv, vIdentificadoDgv, False)
                            If dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = 0 Then
                                dgv.Item("cCCT_ID_DOC" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cTDO_ID_DOC" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cDTD_ID_DOC" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = ""
                                pDTD_ID_DOC = ""
                                dgv.Item("cDTE_SERIE_DOC" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cDTE_NUMERO_DOC" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cDTE_FEC_VEN" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = ""

                                dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = 0
                                dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = 0
                                dgv.Item("cDTD_MOVIMIENTO_DOC" & vIdentificadoDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Movimiento.Movimiento3
                            End If
                            FiltroDTD_ID_DOC(dgv, vIdentificadoDgv)
                        End If
                    Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                         BCVariablesNames.ProcesosCaja.CajaEgreso,
                         BCVariablesNames.ProcesosCaja.DepositoTercero,
                         BCVariablesNames.ProcesosCaja.PlanillaEgreso
                        If cboTipoRecibo.Text = "PAGOS" Then
                            Select Case dgv.Name
                                Case "dgvDetalleOtros", "dgvDetalleEntregas"
                                    dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadoDgv)
                                Case Else
                                    dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTD_ID_DOC" & vIdentificadoDgv)
                                    If Trim(dgv.Rows(dgv.RowCount - 1).Cells("cPER_ID_CLI" & vIdentificadoDgv).Value) <> "" Then
                                        pDevolverDatosUnicoRegistro = True
                                        If vProcesarBusquedaDirectaDocumento Then
                                            If Not vBusquedaDesdePagosCobros Then MetodoBusquedaDato(dgv, vIdentificadoDgv, "", False, EtxtDTD_ID_DOC)
                                        End If
                                        vProcesarBusquedaDirectaDocumento = True
                                    End If
                            End Select
                        ElseIf cboTipoRecibo.Text = "ENTREGAS" Or _
                               cboTipoRecibo.Text = "OTROS" Then
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadoDgv)
                        End If
                        pPosicionColumnaGridNombre = "cDTE_IMPORTE_DOC" & vIdentificadoDgv
                    Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                        dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadoDgv)
                        Select Case Me.Name
                            Case "frmTransferenciaEntreCajas"
                                Select Case dgv.Name
                                    Case "dgvDetalle"
                                        MetodoBusquedaDato(dgv, vIdentificadoDgv, "", False, EtxtCCC_ID_CLI)
                                End Select
                            Case "frmDepositosBancarios"
                                dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadoDgv)
                        End Select
                End Select
                        VerificarBloqueoCampoCliente(dgv, vIdentificadoDgv, dgv.RowCount - 1)
                        FiltroDTD_ID_DOC(dgv, vIdentificadoDgv)
            End If
        End Sub

        Private Sub VerificarBloqueoCampoClienteTransferencias(ByVal vfila As Int16)
            VerificarBloqueoCampoCliente1Transferencias(vfila)
            If IsNothing(dgvDetalleTransferencias.CurrentRow) Then
                Exit Sub
            End If
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero
                    If dgvDetalleTransferencias.RowCount <> 1 Then
                        dgvDetalleTransferencias.Item("cPER_ID_CLIt", vfila).ReadOnly = True
                        EtxtPER_ID_CLI.pBusqueda = False
                    Else
                        txtPER_ID_CLI_REC.Text = dgvDetalle.Item("cPER_ID_CLIt", vfila).Value
                        dgvDetalleTransferencias.Item("cPER_ID_CLIt", vfila).ReadOnly = False
                        EtxtPER_ID_CLI.pBusqueda = True
                    End If
                Case Else
            End Select
        End Sub

        Private Sub VerificarBloqueoCampoCliente1Transferencias(ByVal vFila As Int16)
            If IsNothing(dgvDetalleTransferencias.CurrentRow) Then
                txtPER_ID_CLI_REC.ReadOnly = False
                EtxtPER_ID_CLI_REC.pBusqueda = True
                txtPER_ID_CLI_REC.Text = dgvDetalleTransferencias.Item("cPER_ID_CLIt", vFila).Value
            End If
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero
                    If dgvDetalleTransferencias.RowCount <> 1 Then
                        txtPER_ID_CLI_REC.ReadOnly = True
                        EtxtPER_ID_CLI_REC.pBusqueda = False
                    Else
                        txtPER_ID_CLI_REC.ReadOnly = False
                        EtxtPER_ID_CLI_REC.pBusqueda = True
                    End If
                Case Else
                    txtPER_ID_CLI_REC.ReadOnly = False
                    EtxtPER_ID_CLI_REC.pBusqueda = True
            End Select
        End Sub

        Private Sub VerificarBloqueoCampoCliente(ByRef dgv As DataGridView, ByVal vIdentificadoDgv As String, ByVal vfila As Int16)
            VerificarBloqueoCampoCliente1(dgv, vIdentificadoDgv, vfila)
            If IsNothing(dgv.CurrentRow) Then
                Exit Sub
            End If
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If dgv.RowCount <> 1 Then
                        If pTDO_ID = BCVariablesNames.ProcesosCaja.DepositoTercero  Then
                            If dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).Value = "" Then
                            Else
                                txtPER_ID_CLI_REC.Text = dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).Value
                                dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).ReadOnly = True
                                EtxtPER_ID_CLI.pBusqueda = False
                            End If
                        ElseIf pTDO_ID = BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas Then
                            If dgv.Name = "dgvDetalle" Then
                                If dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).Value = "" Then
                                Else
                                    txtPER_ID_CLI_REC.Text = dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).Value
                                End If
                                dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).ReadOnly = True
                                EtxtPER_ID_CLI.pBusqueda = False
                            ElseIf dgv.Name = "dgvDetalleEntregas" Then
                                If dgv.Item("cPER_ID_CLI_1" & vIdentificadoDgv, vfila).Value = "" Then
                                Else
                                    txtPER_ID_CLI_REC.Text = dgv.Item("cPER_ID_CLI_1" & vIdentificadoDgv, vfila).Value
                                End If
                                dgv.Item("cPER_ID_CLI_1" & vIdentificadoDgv, vfila).ReadOnly = True
                                EtxtPER_ID_CLI_1.pBusqueda = False
                            End If
                        Else
                            txtPER_ID_CLI_REC.Text = dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).Value

                            If SessionService.UserId = "ANGEL" Or SessionService.UserId = "ADMIN" Or SessionService.UserId = "MARZAM" Then
                                dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).ReadOnly = False
                                EtxtPER_ID_CLI.pBusqueda = True
                            Else
                                dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).ReadOnly = True
                                EtxtPER_ID_CLI.pBusqueda = False
                            End If
                        End If
                    Else
                        'txtPER_ID_CLI_REC.Text = dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).Value
                        dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).ReadOnly = False
                        EtxtPER_ID_CLI.pBusqueda = True
                    End If
                Case Else
            End Select
        End Sub

        Private Sub VerificarBloqueoCampoCliente1(ByRef dgv As DataGridView, ByVal vIdentificadoDgv As String, ByVal vFila As Int16)
            If IsNothing(dgv.CurrentRow) Then
                txtPER_ID_CLI_REC.ReadOnly = False
                EtxtPER_ID_CLI_REC.pBusqueda = True
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco, _
                         BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                         BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                        Select Case tcoTipoRecibo.SelectedTab.Name
                            Case "tpaPagos"
                                txtPER_ID_CLI_REC.Text = ""
                                txtPER_DESCRIPCION_CLI_REC.Text = ""
                            Case "tpaEntregas"
                            Case "tpaOtros"
                        End Select
                    Case BCVariablesNames.ProcesosCaja.CajaEgreso, _
                         BCVariablesNames.ProcesosCaja.CajaIngreso, _
                         BCVariablesNames.ProcesosCaja.DepositoTercero, _
                         BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas

                    Case Else
                        txtPER_ID_CLI_REC.Text = dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vFila).Value
                End Select
            End If
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If pTDO_ID = BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas Then
                        If dgv.Name = "dgvDetalleEntregas" Then
                            BloquearPerIdCliRec(dgv)
                            If dgv.RowCount <> 1 Then
                                dgv.Item("cPER_ID_CLI_1" & vIdentificadoDgv, vFila).ReadOnly = True
                                EtxtPER_ID_CLI_1.pBusqueda = False
                            Else
                                dgv.Item("cPER_ID_CLI_1" & vIdentificadoDgv, vFila).ReadOnly = False
                                EtxtPER_ID_CLI_1.pBusqueda = True
                            End If
                        End If
                    End If
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero
                    BloquearPerIdCliRec(dgv)
                Case Else
                    txtPER_ID_CLI_REC.ReadOnly = False
                    EtxtPER_ID_CLI_REC.pBusqueda = True
            End Select
        End Sub
        Private Sub BloquearPerIdCliRec(ByVal dgv As DataGridView)
            If IsNothing(dgv) Then
                txtPER_ID_CLI_REC.ReadOnly = False
                EtxtPER_ID_CLI_REC.pBusqueda = True
            ElseIf IsNothing(dgv.CurrentRow) Then
                txtPER_ID_CLI_REC.ReadOnly = False
                EtxtPER_ID_CLI_REC.pBusqueda = True
            Else
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.CajaIngreso
                        If SessionService.ReciboIngresoPlanilla Then
                            txtPER_ID_CLI_REC.ReadOnly = False
                            EtxtPER_ID_CLI_REC.pBusqueda = True
                        Else
                            txtPER_ID_CLI_REC.ReadOnly = True
                            EtxtPER_ID_CLI_REC.pBusqueda = False
                        End If
                    Case BCVariablesNames.ProcesosCaja.CajaEgreso
                        If SessionService.ReciboEgresoPlanilla Then
                            txtPER_ID_CLI_REC.ReadOnly = False
                            EtxtPER_ID_CLI_REC.pBusqueda = True
                        Else
                            txtPER_ID_CLI_REC.ReadOnly = True
                            EtxtPER_ID_CLI_REC.pBusqueda = False
                        End If
                    Case Else
                        txtPER_ID_CLI_REC.ReadOnly = True
                        EtxtPER_ID_CLI_REC.pBusqueda = False
                End Select
            End If
        End Sub
        Private Sub BloquearCajaCtaCteDestino(ByVal dgv As DataGridView)
            If IsNothing(dgv) Then
                txtCCC_ID_DES.ReadOnly = False
                EtxtCCC_ID_DES.pBusqueda = True
            ElseIf IsNothing(dgv.CurrentRow) Then
                txtCCC_ID_DES.ReadOnly = False
                EtxtCCC_ID_DES.pBusqueda = True
            Else
                txtCCC_ID_DES.ReadOnly = True
                EtxtCCC_ID_DES.pBusqueda = False
            End If
        End Sub
        Private Sub PosicionColumnaGrid(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            dgv.Focus()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso,
                     BCVariablesNames.ProcesosCaja.VoucherCheque
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco Or
                               pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Or
                               pTDO_ID = BCVariablesNames.ProcesosCaja.CajaEgreso Or
                               pTDO_ID = BCVariablesNames.ProcesosCaja.VoucherCheque Then
                                dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                            Else
                                dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells(pPosicionColumnaGridNombre)
                            End If
                        Case "tpaEntregas"
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells(pPosicionColumnaGridNombre)
                        Case "tpaOtros"
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                        Case "tpaTransferencias"
                            If Trim(dgv.CurrentRow.Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value) <> "" Then
                                dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                            Else
                                dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cCCC_ID_CLI" & vIdentificadorDgv)
                            End If
                    End Select
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    If Trim(dgv.CurrentRow.Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value) <> "" Then
                        dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                    Else
                        If dgv.Name = "dgvDetalleOtros" Then
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cPER_ID_CLI" & vIdentificadorDgv)
                        Else
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cCCC_ID_CLI" & vIdentificadorDgv)
                        End If
                    End If
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                        Case "tpaEntregas"
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv)
                        Case "tpaOtros"
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                    End Select
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & vIdentificadorDgv)
                    End Select
                Case Else
                    dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells(pPosicionColumnaGridNombre)
            End Select
        End Sub
        'Private Sub PosicionColumnaGridTransferencias()
        '    dgvDetalleTransferencias.Focus()
        '    Select Case pTDO_ID
        '        Case BCVariablesNames.ProcesosCaja.CajaIngreso,
        '             BCVariablesNames.ProcesosCaja.CajaEgreso,
        '             BCVariablesNames.ProcesosCaja.DepositoTercero,
        '             BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
        '             BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
        '             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
        '             BCVariablesNames.ProcesosCaja.PlanillaEgreso '',
        '            ''BCVariablesNames.ProcesosCaja.VoucherCheque

        '            If cboTipoRecibo.Text = "PAGOS" Then
        '                dgvDetalleTransferencias.CurrentCell = dgvDetalleTransferencias.Rows(dgvDetalleTransferencias.RowCount - 1).Cells(pPosicionColumnaGridNombre & "t")
        '            ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
        '                dgvDetalleTransferencias.CurrentCell = dgvDetalleTransferencias.Rows(dgvDetalleTransferencias.RowCount - 1).Cells(pPosicionColumnaGridNombre & "t")
        '            ElseIf cboTipoRecibo.Text = "OTROS" Then
        '                dgvDetalleTransferencias.CurrentCell = dgvDetalleTransferencias.Rows(dgvDetalleTransferencias.RowCount - 1).Cells("cDTE_IMPORTE_DOCt")
        '            End If
        '        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas,
        '            BCVariablesNames.ProcesosCaja.VoucherCheque
        '            If Trim(dgvDetalleTransferencias.CurrentRow.Cells("cCCC_ID_CLIt").Value) <> "" Then
        '                dgvDetalleTransferencias.CurrentCell = dgvDetalleTransferencias.Rows(dgvDetalleTransferencias.RowCount - 1).Cells("cDTE_IMPORTE_DOCt")
        '            Else
        '                dgvDetalleTransferencias.CurrentCell = dgvDetalleTransferencias.Rows(dgvDetalleTransferencias.RowCount - 1).Cells("cCCC_ID_CLIt")
        '            End If
        '        Case Else
        '            dgvDetalleTransferencias.CurrentCell = dgvDetalleTransferencias.Rows(dgvDetalleTransferencias.RowCount - 1).Cells(pPosicionColumnaGridNombre & "t")
        '    End Select
        'End Sub

        Public Function CambiarMonedaSaldo(ByVal CodigoMoneda) As Decimal
            CambiarMonedaSaldo = 0
            Dim vCodigoMoneda As String
            Dim vcontrol As Int16
            Dim ds As New DataSet

            If BCVariablesNames.MonedaSistema = CodigoMoneda Then
                vCodigoMoneda = txtMON_ID_CCC.Text
            Else
                vCodigoMoneda = CodigoMoneda
            End If

            If vCodigoMoneda = BCVariablesNames.MonedaSistema Then
                CambiarMonedaSaldo = 1
            Else
                Dim sr As New StringReader(IBCMaestro.EjecutarVista("spCambioDiaXML", BCVariablesNames.MonedaSistema, vCodigoMoneda, cMisProcedimientos.FormatoFechaGenerico(dtpTES_FECHA_EMI.Text)))
                vcontrol = sr.Peek
                If vcontrol <> -1 Then
                    ds.ReadXml(sr)
                    CambiarMonedaSaldo = ds.Tables(0).Rows(0).Item("TCA_VENTA")
                Else
                    CambiarMonedaSaldo = 0
                End If

                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.VoucherCheque, _
                         BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas, _
                         BCVariablesNames.ProcesosCaja.DepositoTercero, _
                         BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                         BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                         BCVariablesNames.ProcesosCaja.CajaIngreso, _
                         BCVariablesNames.ProcesosCaja.CajaEgreso '', _
                        ''BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                        If IsNumeric(txtTipoCambio.Text) Then
                            If CDbl(txtTipoCambio.Text) > 0 Then
                                CambiarMonedaSaldo = CDbl(txtTipoCambio.Text)
                            End If
                        End If
                End Select

            End If
            Return CambiarMonedaSaldo
        End Function

        Public Sub ProcesarTipoCambioMoneda()
            If BCVariablesNames.MonedaSistema <> txtMON_ID_CCC.Text Then
                Dim ds As New DataSet
                Dim sr As New StringReader(IBCMaestro.EjecutarVista("spCambioDiaXML", BCVariablesNames.MonedaSistema, txtMON_ID_CCC.Text, cMisProcedimientos.FormatoFechaGenerico(dtpTES_FECHA_EMI.Text)))
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
                    ErrorProvider1.SetError(txtMON_ID_CCC, Nothing)
                Else
                    tslTipoCambioCompraMoneda.Text = "Cambio del día: " & txtMON_SIMBOLO_CCC.Text & " 1.0000  -  Compra: 0.0000"
                    tslTipoCambioVentaMoneda.Text = "Venta: 0.0000"
                    TipoCambioCompraMoneda = 0
                    TipoCambioVentaMoneda = 0
                    ErrorProvider1.SetError(txtMON_ID_CCC, "No se encuentra el tipo de cambio para la fecha de emisión")
                End If

                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.VoucherCheque, _
                         BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas, _
                         BCVariablesNames.ProcesosCaja.DepositoTercero, _
                         BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                         BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                         BCVariablesNames.ProcesosCaja.CajaIngreso, _
                         BCVariablesNames.ProcesosCaja.CajaEgreso '', _
                        ''BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                        If IsNumeric(txtTipoCambio.Text) Then
                            If CDbl(txtTipoCambio.Text) > 0 Then
                                TipoCambioCompraMoneda = CDbl(txtTipoCambio.Text)
                                TipoCambioVentaMoneda = CDbl(txtTipoCambio.Text)
                            End If
                        End If
                End Select

            Else
                tslTipoCambioCompraMoneda.Text = "Cambio del día: ? 1.0000  -  Compra: 0.0000"
                tslTipoCambioVentaMoneda.Text = "Venta: 0.0000"
                TipoCambioCompraMoneda = 1
                TipoCambioVentaMoneda = 1
                ErrorProvider1.SetError(txtMON_ID_CCC, Nothing)
            End If

            lblMON_SIMBOLO_1.Text = txtMON_SIMBOLO_CCC.Text
            lblMON_SIMBOLO_2.Text = txtMON_SIMBOLO_CCC.Text

        End Sub

        Private Sub CalcularMontoDocumento()
            Dim vIdentificadorDgv As String
            Dim vFilasGrid As Int16

            Dim vSignoCuentaContable As Integer = 0

            Dim vTotalEfectivo As Double = 0
            Dim vTotalCheque As Double = 0
            Dim vTotalTarjetaCredito As Double = 0
            Dim vTotalDepositoBancario As Double = 0
            Dim vTotalTransferenciaBancaria As Double = 0
            Dim vTotalDocumento As Double = 0
            Dim vTotalRetencionIgv As Double = 0
            Dim vTes_Monto_Total As Double = 0

            vIdentificadorDgv = ProcesarIdentificadorGrid(dgvDetalle)
            vFilasGrid = dgvDetalle.RowCount
            For vFilas = 0 To vFilasGrid - 1
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                        vTotalEfectivo += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                    Case Else
                        Select Case dgvDetalle.Item(vColMedioPago & vIdentificadorDgv, vFilas).Value
                            Case "EFECTIVO"
                                vTotalEfectivo += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "CHEQUE"
                                vTotalCheque += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "TARJETA DE CREDITO"
                                vTotalTarjetaCredito += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "DEPOSITO BANCARIO"
                                vTotalDepositoBancario += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "TRANSFERENCIA BANCARIA"
                                vTotalTransferenciaBancaria += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "DOCUMENTO"
                                vTotalDocumento += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "RETENCION DE IGV"
                                vTotalRetencionIgv += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                        End Select
                End Select
                vTes_Monto_Total += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
            Next

            vIdentificadorDgv = ProcesarIdentificadorGrid(dgvDetalleEntregas)
            vFilasGrid = dgvDetalleEntregas.RowCount
            For vFilas = 0 To vFilasGrid - 1
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                        vTotalDocumento += CDbl(dgvDetalleEntregas.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, vFilas).Value)
                    Case Else
                        Select Case dgvDetalleEntregas.Item(vColMedioPago & vIdentificadorDgv, vFilas).Value
                            Case "EFECTIVO"
                                vTotalEfectivo += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "CHEQUE"
                                vTotalCheque += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "TARJETA DE CREDITO"
                                vTotalTarjetaCredito += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "DEPOSITO BANCARIO"
                                vTotalDepositoBancario += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "TRANSFERENCIA BANCARIA"
                                vTotalTransferenciaBancaria += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "DOCUMENTO"
                                vTotalDocumento += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "RETENCION DE IGV"
                                vTotalRetencionIgv += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                        End Select
                End Select
                vTes_Monto_Total += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
            Next

            vIdentificadorDgv = ProcesarIdentificadorGrid(dgvDetalleOtros)
            vFilasGrid = dgvDetalleOtros.RowCount
            For vFilas = 0 To vFilasGrid - 1
                If IsNumeric(dgvDetalleOtros.Item("cCUC_ID" & vIdentificadorDgv, vFilas).Value) Then
                    vSignoCuentaContable = Me.IBCBusqueda.SignoCuentaContable(CDbl(dgvDetalleOtros.Item("cCUC_ID" & vIdentificadorDgv, vFilas).Value))
                Else
                    vSignoCuentaContable = 0
                End If
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                        vSignoCuentaContable = vSignoCuentaContable * -1
                    Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                        vSignoCuentaContable = vSignoCuentaContable * -1
                    Case BCVariablesNames.ProcesosCaja.CajaEgreso
                        If IsNumeric(dgvDetalleOtros.Item("cCUC_ID" & vIdentificadorDgv, vFilas).Value) Then
                            If Strings.Left(dgvDetalleOtros.Item("cCUC_ID" & vIdentificadorDgv, vFilas).Value, 1) = 9 Then
                                vSignoCuentaContable = vSignoCuentaContable * -1
                            End If
                        Else
                            vSignoCuentaContable = 0
                        End If
                    Case Else
                End Select
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                        vTotalCheque += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                    Case Else
                        Select Case dgvDetalleOtros.Item(vColMedioPago & vIdentificadorDgv, vFilas).Value
                            Case "EFECTIVO"
                                vTotalEfectivo += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "CHEQUE"
                                vTotalCheque += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "TARJETA DE CREDITO"
                                vTotalTarjetaCredito += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "DEPOSITO BANCARIO"
                                vTotalDepositoBancario += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "TRANSFERENCIA BANCARIA"
                                vTotalTransferenciaBancaria += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "DOCUMENTO"
                                vTotalDocumento += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "RETENCION DE IGV"
                                vTotalRetencionIgv += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                        End Select
                End Select
                '
                If dgvDetalle.Rows.Count = 0 And _
                   dgvDetalleEntregas.Rows.Count = 0 Then
                    vTes_Monto_Total += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value) '* vSignoCuentaContable
                Else
                    vTes_Monto_Total += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value) * vSignoCuentaContable
                End If
                '
                'vTes_Monto_Total += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value) * vSignoCuentaContable
            Next

            vIdentificadorDgv = ProcesarIdentificadorGrid(dgvDetalleTransferencias)
            vFilasGrid = dgvDetalleTransferencias.RowCount
            For vFilas = 0 To vFilasGrid - 1
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                        vTotalTarjetaCredito += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                    Case Else
                        Select Case dgvDetalleTransferencias.Item(vColMedioPago & vIdentificadorDgv, vFilas).Value
                            Case "EFECTIVO"
                                vTotalEfectivo += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "CHEQUE"
                                vTotalCheque += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "TARJETA DE CREDITO"
                                vTotalTarjetaCredito += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "DEPOSITO BANCARIO"
                                vTotalDepositoBancario += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "TRANSFERENCIA BANCARIA"
                                vTotalTransferenciaBancaria += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "DOCUMENTO"
                                vTotalDocumento += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                            Case "RETENCION DE IGV"
                                vTotalRetencionIgv += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                        End Select
                End Select
                vTes_Monto_Total += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
            Next

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    lblTotalEfectivo.Text = "Pagos"
                    txtTotalEfectivo.Text = Format(vTotalEfectivo, "##,###.###0")

                    lblTotalDocumento.Text = "Entregas"
                    txtTotalDocumento.Text = Format(vTotalDocumento, "##,###.###0")

                    lblTotalCheque.Text = "Otros"
                    txtTotalCheque.Text = Format(vTotalCheque, "##,###.###0")

                    lblTotalTarjetaCredito.Text = "Transferencias"
                    txtTotalTarjetaCredito.Text = Format(vTotalTarjetaCredito, "##,###.###0")

                    lblTotalTarjetaCredito.Visible = False
                    txtTotalTarjetaCredito.Visible = False

                    lblTotalDepositoBancario.Visible = False
                    txtTotalDepositoBancario.Visible = False

                    lblTotalTransferenciaBancaria.Visible = False
                    txtTotalTransferenciaBancaria.Visible = False

                    lblTotalRetencionIgv.Visible = False
                    txtTotalRetencionIgv.Visible = False

                    lblTES_MONTO_TOTAL.Visible = False
                    txtTES_MONTO_TOTAL.Visible = False
                Case Else
                    txtTotalEfectivo.Text = Format(vTotalEfectivo, "##,###.###0")
                    txtTotalCheque.Text = Format(vTotalCheque, "##,###.###0")
                    txtTotalTarjetaCredito.Text = Format(vTotalTarjetaCredito, "##,###.###0")
                    txtTotalDepositoBancario.Text = Format(vTotalDepositoBancario, "##,###.###0")
                    txtTotalTransferenciaBancaria.Text = Format(vTotalTransferenciaBancaria, "##,###.###0")
                    txtTotalDocumento.Text = Format(vTotalDocumento, "##,###.###0")
                    txtTotalRetencionIgv.Text = Format(vTotalRetencionIgv, "##,###.###0")
                    txtTES_MONTO_TOTAL.Text = Format(vTes_Monto_Total, "##,###.###0")
            End Select
        End Sub

        Public Function VerificarMontoDocumento(ByRef dgv As DataGridView, _
                                                ByVal vIdentificadorDgv As String, _
                                                ByVal vTDO_ID As String, _
                                                ByVal vDTD_ID As String, _
                                                ByVal vTES_SERIE As String, _
                                                ByVal vTES_NUMERO As String, _
                                                ByVal vMon_Id As String, _
                                                ByVal vPER_ID_CLI As String, _
                                                Optional ByVal vVerificarMontoSoloNuevosRegistros As Boolean = True) As Decimal
            VerificarMontoDocumento = 0

            Dim vEstadoRegistro As Int16 = 0
            If Not vVerificarMontoSoloNuevosRegistros Then
                vEstadoRegistro = 1
            End If

            Dim vFilasGrid As Int16
            vFilasGrid = dgv.RowCount
            For vFilas = 0 To vFilasGrid - 1
                If dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, vFilas).Value = vPER_ID_CLI And _
                   dgv.Item("cTDO_ID_DOC" & vIdentificadorDgv, vFilas).Value = vTDO_ID And _
                   dgv.Item("cDTD_ID_DOC" & vIdentificadorDgv, vFilas).Value = vDTD_ID And _
                   dgv.Item("cDTE_SERIE_DOC" & vIdentificadorDgv, vFilas).Value = vTES_SERIE And _
                   dgv.Item("cDTE_NUMERO_DOC" & vIdentificadorDgv, vFilas).Value = vTES_NUMERO And _
                   (dgv.Item("cEstadoRegistro" & vIdentificadorDgv, vFilas).Value = 0 Or dgv.Item("cEstadoRegistro" & vIdentificadorDgv, vFilas).Value = vEstadoRegistro) Then

                    If vMon_Id = txtMON_ID_CCC.Text Then
                        VerificarMontoDocumento += CDbl(dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, vFilas).Value)
                    Else
                        VerificarMontoDocumento += CDbl(dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, vFilas).Value)
                    End If
                End If
            Next
            If vEstadoRegistro = 0 Then
                For vfilas = 1 To eRegistrosEliminarDocumento.Count - 2
                    If eRegistrosEliminarDocumento(vfilas).cTDO_ID = vTDO_ID And _
                       eRegistrosEliminarDocumento(vfilas).cDTD_ID = vDTD_ID And _
                       eRegistrosEliminarDocumento(vfilas).cDTE_SERIE = vTES_SERIE And _
                       eRegistrosEliminarDocumento(vfilas).cDTE_NUMERO = vTES_NUMERO Then
                        If eRegistrosEliminarDocumento(vfilas).cMON_ID = txtMON_ID_CCC.Text Then
                            VerificarMontoDocumento -= CDbl(eRegistrosEliminarDocumento(vfilas).cDTE_IMPORTE)
                        Else
                            VerificarMontoDocumento -= CDbl(eRegistrosEliminarDocumento(vfilas).cDTE_CONTRAVALOR)
                        End If
                    End If
                Next
            End If

            Return VerificarMontoDocumento
        End Function
        Public Function VerificarMontoDocumento_1(ByRef dgv As DataGridView, _
                                                ByVal vIdentificadorDgv As String, _
                                                ByVal vTDO_ID As String, _
                                                ByVal vDTD_ID As String, _
                                                ByVal vTES_SERIE As String, _
                                                ByVal vTES_NUMERO As String) As Decimal
            VerificarMontoDocumento_1 = 0
            Dim vFilasGrid As Int16
            vFilasGrid = dgv.RowCount
            For vFilas = 0 To vFilasGrid - 1
                If dgv.Item("cTDO_ID_DOC_1" & vIdentificadorDgv, vFilas).Value = vTDO_ID And _
                   dgv.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, vFilas).Value = vDTD_ID And _
                   dgv.Item("cDTE_SERIE_DOC_1" & vIdentificadorDgv, vFilas).Value = vTES_SERIE And _
                   dgv.Item("cDTE_NUMERO_DOC_1" & vIdentificadorDgv, vFilas).Value = vTES_NUMERO And _
                   dgv.Item("cEstadoRegistro" & vIdentificadorDgv, vFilas).Value = 0 Then
                    If dgv.Item("cMON_ID_DOC_1" & vIdentificadorDgv, vFilas).Value = txtMON_ID_CCC.Text Then
                        VerificarMontoDocumento_1 += CDbl(dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, vFilas).Value)
                    Else
                        VerificarMontoDocumento_1 += CDbl(dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, vFilas).Value)
                    End If
                End If
            Next
            For vfilas = 1 To eRegistrosEliminarDocumento_1.Count - 2
                If eRegistrosEliminarDocumento_1(vfilas).cTDO_ID = vTDO_ID And _
                   eRegistrosEliminarDocumento_1(vfilas).cDTD_ID = vDTD_ID And _
                   eRegistrosEliminarDocumento_1(vfilas).cDTE_SERIE = vTES_SERIE And _
                   eRegistrosEliminarDocumento_1(vfilas).cDTE_NUMERO = vTES_NUMERO Then

                    If eRegistrosEliminarDocumento_1(vfilas).cMON_ID = BCVariablesNames.MonedaSistema Then
                        VerificarMontoDocumento_1 -= CDbl(eRegistrosEliminarDocumento_1(vfilas).cDTE_IMPORTE)
                    Else
                        VerificarMontoDocumento_1 -= CDbl(eRegistrosEliminarDocumento_1(vfilas).cDTE_CONTRAVALOR)
                    End If
                End If
            Next

            Return VerificarMontoDocumento_1
        End Function

        Public Function VerificarMontoDocumentoDetalle(ByVal vTDO_ID As String, ByVal vDTD_ID As String, ByVal vTES_SERIE As String, ByVal vTES_NUMERO As String) As Decimal
            VerificarMontoDocumentoDetalle = 0
            Dim vFilasGrid As Int16
            vFilasGrid = dgvDetalle.RowCount
            For vFilas = 0 To vFilasGrid - 1
                If dgvDetalle.Item("cTDO_ID_DOC", vFilas).Value = vTDO_ID And _
                   dgvDetalle.Item("cDTD_ID_DOC", vFilas).Value = vDTD_ID And _
                   dgvDetalle.Item("cDTE_SERIE_DOC", vFilas).Value = vTES_SERIE And _
                   dgvDetalle.Item("cDTE_NUMERO_DOC", vFilas).Value = vTES_NUMERO And _
                   dgvDetalle.Item("cEstadoRegistro", vFilas).Value = 0 Then
                    VerificarMontoDocumentoDetalle += CDbl(dgvDetalle.Item("cDTE_IMPORTE_DOC", vFilas).Value)
                End If
            Next
            For vfilas = 1 To eRegistrosEliminarDocumento.Count - 2
                If eRegistrosEliminarDocumento(vfilas).cTDO_ID = vTDO_ID And _
                   eRegistrosEliminarDocumento(vfilas).cDTD_ID = vDTD_ID And _
                   eRegistrosEliminarDocumento(vfilas).cDTE_SERIE = vTES_SERIE And _
                   eRegistrosEliminarDocumento(vfilas).cDTE_NUMERO = vTES_NUMERO Then
                    VerificarMontoDocumentoDetalle -= CDbl(eRegistrosEliminarDocumento(vfilas).cDTE_IMPORTE)
                End If
            Next

            Return VerificarMontoDocumentoDetalle
        End Function
        Private Function ValidarImporte(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByRef otxt As txt, ByVal texto As String, ByVal BusquedaDirecta As Boolean)
            If otxt.pTexto1 <> otxt.pTexto2 Then
                If otxt.pBusqueda Then
                    EtxtDTE_IMPORTE_DOC.pOOrm.vPER_ID_CLI = dgv.CurrentRow.Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                            BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                            EtxtDTE_IMPORTE_DOC.pOOrm.vCCT_ID_REF = DBNull.Value
                        Case Else
                            EtxtDTE_IMPORTE_DOC.pOOrm.vCCT_ID_REF = txtCCT_ID.Text
                    End Select

                    EtxtDTE_IMPORTE_DOC.pOOrm.vTDO_ID = dgv.CurrentRow.Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value.ToString
                    EtxtDTE_IMPORTE_DOC.pOOrm.vDTD_ID = dgv.CurrentRow.Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value.ToString
                    EtxtDTE_IMPORTE_DOC.pOOrm.vDOC_SERIE = dgv.CurrentRow.Cells("cDTE_SERIE_DOC" & vIdentificadorDgv).Value.ToString
                    EtxtDTE_IMPORTE_DOC.pOOrm.vDOC_NUMERO = dgv.CurrentRow.Cells("cDTE_NUMERO_DOC" & vIdentificadorDgv).Value.ToString
                    EtxtDTE_IMPORTE_DOC.pOOrm.vDOCUMENTO = pTDO_ID & txtDTD_ID.Text & txtTES_SERIE.Text & txtTES_NUMERO.Text

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.CajaEgreso,
                             BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.VoucherCheque,
                             BCVariablesNames.ProcesosCaja.PlanillaEgreso
                            EtxtDTE_IMPORTE_DOC.pOOrm.vProcesarAnticipoPorCobrar = True
                        Case Else
                            Select Case EtxtDTE_IMPORTE_DOC.pOOrm.vDTD_ID
                                Case BCVariablesNames.ProcesosFacturación.FacturaAnticipo, _
                                     BCVariablesNames.ProcesosFacturación.BoletaAnticipo
                                    EtxtDTE_IMPORTE_DOC.pOOrm.vProcesarAnticipoPorCobrar = True
                                Case Else
                                    EtxtDTE_IMPORTE_DOC.pOOrm.vProcesarAnticipoPorCobrar = False
                            End Select
                    End Select

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                             BCVariablesNames.ProcesosCaja.CajaEgreso,
                             BCVariablesNames.ProcesosCaja.DepositoTercero,
                             BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                             BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                             BCVariablesNames.ProcesosCaja.VoucherCheque
                            If cboTipoRecibo.Text = "PAGOS" Then
                                If Trim(dgv.CurrentRow.Cells("cCCO_ID" & vIdentificadorDgv).Value) = "" Then
                                    If Not pRegistroNuevo Then
                                        pVerificarMontoSoloNuevosRegistro = False
                                    End If
                                    MetodoBusquedaDato(dgv, vIdentificadorDgv, texto, BusquedaDirecta, otxt)
                                End If
                            ElseIf cboTipoRecibo.Text = "ENTREGAS" Or _
                               cboTipoRecibo.Text = "OTROS" Then
                            End If

                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            ValidarImporteTransferenciaEntreCajas(dgv, vIdentificadorDgv, texto)
                        Case Else
                            MetodoBusquedaDato(dgv, vIdentificadorDgv, texto, BusquedaDirecta, otxt)
                    End Select

                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                            RecalcularMontoAbono(dgv, vIdentificadorDgv)
                    End Select
                End If
            End If
            Return 0
        End Function
        Private Function ValidarImporteTransferenciaEntreCajas(ByRef dgv As DataGridView, ByVal vIdentificadorGrid As String, ByVal texto As String)
            If dgv.Name = "dgvDetalleOtros" Then Exit Function
            If Trim(dgv.Item("cCCC_ID_CLI" & vIdentificadorGrid, dgv.CurrentRow.Index).Value) = "" Then
                MensajeError("Ingrese la cuenta de caja a donde se realizara la transferencia.")
                dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
                dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
                Exit Function
            End If
            Dim vMON_ID As String = ""
            Dim vImporte As Double = 0
            Dim vContravalor As Double = 0
            Dim vImporteTemporal As Double = 0
            Dim vContravalorTemporal As Double = 0
            Dim vTDO_ID As String = ""
            Dim vDTD_ID As String = ""
            Dim vDTE_SERIE As String = ""
            Dim vDTE_NUMERO As String = ""
            Dim vCambiarMonedaSaldo As Double = 0
            Dim vMontoTemporal As Double = 0
            Dim vDatoBusquedaTemporal As Double = 0
            Dim vSaldoDocumento As Double = 0
            Dim vSaldo As Integer = texto
            Dim vSaldoTemporal As Double = 0
            Dim pDatoBusqueda As String = texto

            vTDO_ID = dgv.CurrentRow.Cells("cTDO_ID_DOC" & vIdentificadorGrid).Value.ToString
            vDTD_ID = dgv.CurrentRow.Cells("cDTD_ID_DOC" & vIdentificadorGrid).Value.ToString
            vDTE_SERIE = dgv.CurrentRow.Cells("cDTE_SERIE_DOC" & vIdentificadorGrid).Value.ToString
            vDTE_NUMERO = dgv.CurrentRow.Cells("cDTE_NUMERO_DOC" & vIdentificadorGrid).Value.ToString

            vMON_ID = dgv.CurrentRow.Cells("cMON_ID_DOC" & vIdentificadorGrid).Value.ToString
            vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)

            dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
            dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0

            Select Case ProcesarCambioTipoMonedaDoc(dgv, vIdentificadorGrid, pDatoBusqueda, _
                                                    vTDO_ID, vDTD_ID, _
                                                    vDTE_SERIE, vDTE_NUMERO, _
                                                    vMON_ID, vCambiarMonedaSaldo, _
                                                    False, False)
                Case 1
                    MensajeError(dgv.Item("cMON_DESCRIPCION_DOC" & vIdentificadorGrid, dgv.CurrentRow.Index).Value & " - No existe tipo de cambio para el día : " & dtpTES_FECHA_EMI.Text)
                    dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
                    dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
                    Exit Function
                Case 2
                    Exit Function
                Case Else
            End Select
        End Function

        Private Sub dtpTES_FECHA_EMI_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTES_FECHA_EMI.ValueChanged
            ProcesarTipoCambioMoneda()
        End Sub

        '' ojito
        Private Function BloquearBusquedaCampos(ByVal vtxt As txt, _
                                                ByRef dgv As DataGridView, _
                                                ByVal vIdentificadorDgv As String, _
                                                Optional ByVal vMensaje As Boolean = True) As Boolean
            BloquearBusquedaCampos = False
            Select Case vtxt.pOOrm.cTabla.NombreCorto
                Case "PuntoVenta"
                    If Not vtxt.pBusqueda Then
                        BloquearBusquedaCampos = True
                        If vMensaje Then MsgBox("No se puede cambiar el punto de venta" & Chr(13) & "si la grilla posee registros", MsgBoxStyle.Information, Me.Text)
                    End If
                Case "RolOpeCtaCte"
                    If vtxt.pComportamiento <> 22 Then
                        If Not pRegistroNuevo Then
                            If dgv.Rows.Count() = 0 Then
                                If pPasandoEntregasAPagos Then
                                    BloquearBusquedaCampos = False
                                Else
                                    BloquearBusquedaCampos = True
                                End If
                            Else
                                BloquearBusquedaCampos = True
                            End If
                        End If
                        If Not vtxt.pBusqueda Then
                            BloquearBusquedaCampos = True
                            If Not pFlagVerificarRolCtaCte Then
                                If vMensaje Then
                                    If Not pPasandoEntregasAPagos Then
                                        MsgBox("No se puede cambiar la Cta. Cte. de la Transacción" & Chr(13) & "si la grilla posee registros", MsgBoxStyle.Information, Me.Text)
                                    Else
                                        BloquearBusquedaCampos = False
                                    End If
                                End If
                            End If
                        End If
                    End If
                Case "CajaCtaCte"
                    If vtxt.pComportamiento <> 7 Then
                        If Not vtxt.pBusqueda Then
                            BloquearBusquedaCampos = True
                            If vMensaje Then MsgBox("No se puede cambiar la cuenta corriente de la caja" & Chr(13) & "si la grilla posee registros", MsgBoxStyle.Information, Me.Text)
                        End If
                    End If
                Case "Moneda"
                    If Not vtxt.pBusqueda Then
                        BloquearBusquedaCampos = True
                        If vMensaje Then MsgBox("No se puede cambiar la fecha para el tipo de cambio de la moneda" & Chr(13) & "si la grilla posee registros", MsgBoxStyle.Information, Me.Text)
                    End If
            End Select
            Return BloquearBusquedaCampos
        End Function

        '' ojito
        Private Sub txt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles cboTipoRecibo.Enter, _
                            txtDTD_DESCRIPCION.Enter, _
                            txtCCT_ID.Enter, _
                            txtCCT_DESCRIPCION.Enter, _
                            cboCCC_TIPO.Enter, _
                            txtCCC_DESCRIPCION.Enter, _
                            txtTES_SERIE.Enter, _
                            txtTES_NUMERO.Enter, _
                            dtpTES_FECHA_EMI.Enter, _
                            txtMON_ID_CCC.Enter, _
                            txtMON_SIMBOLO_CCC.Enter, _
                            txtMON_DESCRIPCION_CCC.Enter, _
                            txtPER_ID_CAJ.Enter, _
                            txtPER_DESCRIPCION_CAJ.Enter, _
                            txtPER_ID_CLI_REC.Enter, _
                            txtTES_MONTO_TOTAL.Enter
            If sender.GetType <> GetType(ComboBox) And _
                sender.GetType <> GetType(DateTimePicker) Then
                If sender.ReadOnly Then KeysTab(1) 'SendKeys.Send(Chr(Keys.Tab))
            Else
                If EnabledObjeto(sender.name) Then KeysTab(1) ' SendKeys.Send(Chr(Keys.Tab))
            End If
        End Sub

        Private Sub ConfigurarFormulario(ByRef dgv As DataGridView, ByVal vIdentificadoDgv As String, ByVal vControl As Integer)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    CajaIngreso(dgv, vIdentificadoDgv, vControl)
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                    DetraccionesNotaCargoCtaBanco(dgv, vIdentificadoDgv, vControl)
                Case BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque

                    If dgv.Name = "dgvDetalleTransferencias" Then
                        TransferenciaEntreCajas(dgv, vIdentificadoDgv, vControl)
                    Else
                        BancoIngreso(dgv, vIdentificadoDgv, vControl)
                    End If

                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    TransferenciaEntreCajas(dgv, vIdentificadoDgv, vControl)
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    PlanillaRendicionCuentas(dgv, vIdentificadoDgv, vControl)
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    LiquidacionDocumento(dgv, vIdentificadoDgv, vControl)
                Case Else
            End Select
        End Sub

        Private Sub DetraccionesNotaCargoCtaBanco(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vControl As Integer)
            lblPER_ID_CLI_REC.Enabled = False
            txtPER_ID_CLI_REC.Enabled = False
            txtPER_DESCRIPCION_CLI_REC.Enabled = False

            If vControl = 1 Then
                ConfigurarReadOnlyNoBusqueda(txtMON_ID_CCC, EtxtMON_ID_CCC, True)
            End If
            NuevoDetraccionesNotaCargoCtaBanco(dgv, vIdentificadorDgv, vControl)
        End Sub
        Private Sub NuevoDetraccionesNotaCargoCtaBanco(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, Optional ByVal vControl As Integer = 0)
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, False) ' No solo lectura habilita el pEnable y pBúsqueda
            ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, True) ' false
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)
            ConfigurarReadOnlyNoBusqueda(txtCCC_ID, EtxtCCC_ID, False)
            ConfigurarReadOnlyNoBusqueda(cboCCC_TIPO, EcboCCC_TIPO, True)
            ConfigurarReadOnlyNoBusqueda(txtTES_SERIE, EtxtTES_SERIE, True) ' Solo lectura deshabilita el pEnable y pBúsqueda
            ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, True) ' false
            ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, False)

            If pRegistroNuevo Then
                ControlVisible(cboSerieCorrelativo, True) 'Muestra
            End If

            ConfigurarReadOnlyNoBusqueda(dtpTES_FECHA_EMI, EdtpTES_FECHA_EMI, True)
            ConfigurarCampoVisualizarGridDetalle(dgv, vIdentificadorDgv)
            Select Case vControl
                Case 1
                Case Else
            End Select
        End Sub

        Private Sub BancoIngreso(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vControl As Integer)
            If vControl = 1 Then
                ConfigurarReadOnlyNoBusqueda(txtMON_ID_CCC, EtxtMON_ID_CCC, True)
            End If
            NuevoBancoIngreso(dgv, vIdentificadorDgv, vControl)
        End Sub
        Private Sub NuevoBancoIngreso(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, Optional ByVal vControl As Integer = 0)
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, False) ' No solo lectura habilita el pEnable y pBúsqueda

            ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)
            ConfigurarReadOnlyNoBusqueda(txtCCC_ID, EtxtCCC_ID, False)
            ConfigurarReadOnlyNoBusqueda(cboCCC_TIPO, EcboCCC_TIPO, True)
            ConfigurarReadOnlyNoBusqueda(txtTES_SERIE, EtxtTES_SERIE, True) ' Solo lectura deshabilita el pEnable y pBúsqueda
            ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, True) 'false
            ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, False)

            If pRegistroNuevo Then
                ControlVisible(cboSerieCorrelativo, True) 'Muestra
            End If

            ConfigurarReadOnlyNoBusqueda(dtpTES_FECHA_EMI, EdtpTES_FECHA_EMI, True)
            ConfigurarCampoVisualizarGridDetalle(dgv, vIdentificadorDgv)
            Select Case vControl
                Case 1
                Case Else
            End Select
        End Sub

        Private Sub CajaIngreso(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vControl As Integer)
            If vControl = 1 Then
                ConfigurarReadOnlyNoBusqueda(txtMON_ID_CCC, EtxtMON_ID_CCC, True)
            End If
            NuevoCajaIngreso(dgv, vIdentificadorDgv, vControl)
        End Sub
        Private Sub NuevoCajaIngreso(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, Optional ByVal vControl As Integer = 0)
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, False) ' No solo lectura habilita el pEnable y pBúsqueda
            ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, True) ' false

            ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)
            ConfigurarReadOnlyNoBusqueda(txtCCC_ID, EtxtCCC_ID, False)
            ConfigurarReadOnlyNoBusqueda(cboCCC_TIPO, EcboCCC_TIPO, True)
            ConfigurarReadOnlyNoBusqueda(txtTES_SERIE, EtxtTES_SERIE, True) ' Solo lectura deshabilita el pEnable y pBúsqueda
            ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, True) ' false
            ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, False)

            If pRegistroNuevo Then
                ControlVisible(cboSerieCorrelativo, True) 'Muestra
            End If

            ConfigurarReadOnlyNoBusqueda(dtpTES_FECHA_EMI, EdtpTES_FECHA_EMI, True)
            ConfigurarCampoVisualizarGridDetalle(dgv, vIdentificadorDgv)
            Select Case vControl
                Case 1
                Case Else
            End Select
        End Sub

        Private Sub NotaCargoCuentaBanco(ByVal vControl As Integer)
            If vControl = 1 Then
                ConfigurarReadOnlyNoBusqueda(txtMON_ID_CCC, EtxtMON_ID_CCC, True)
            End If
            NuevoNotaCargoCuentaBanco(vControl)
        End Sub
        Private Sub NuevoNotaCargoCuentaBanco(Optional ByVal vControl As Integer = 0)
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, False) ' No solo lectura habilita el pEnable y pBúsqueda
            ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, True) ' false
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)
            ConfigurarReadOnlyNoBusqueda(txtCCC_ID, EtxtCCC_ID, False)
            ConfigurarReadOnlyNoBusqueda(cboCCC_TIPO, EcboCCC_TIPO, True)
            ConfigurarReadOnlyNoBusqueda(txtTES_SERIE, EtxtTES_SERIE, True) ' Solo lectura deshabilita el pEnable y pBúsqueda
            ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, True) ' false
            ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, False)

            If pRegistroNuevo Then
                ControlVisible(cboSerieCorrelativo, True) 'Muestra
            End If

            ConfigurarReadOnlyNoBusqueda(dtpTES_FECHA_EMI, EdtpTES_FECHA_EMI, False)
            Select Case vControl
                Case 1
                Case Else
            End Select
        End Sub

        Private Sub LiquidacionDocumento(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vControl As Integer)
            If vControl = 1 Then
                'ConfigurarReadOnlyNoBusqueda(txtMON_ID_CCC, EtxtMON_ID_CCC, True)
            End If
            NuevoLiquidacionDocumento(dgv, vIdentificadorDgv, vControl)
        End Sub
        Private Sub NuevoLiquidacionDocumento(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, Optional ByVal vControl As Integer = 0)
            ConfigurarCampoVisualizarGridDetalle(dgv, vIdentificadorDgv)
            Select Case vControl
                Case 1
                Case Else
            End Select
        End Sub

        Private Sub PlanillaRendicionCuentas(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vControl As Integer)
            If vControl = 1 Then
                ConfigurarReadOnlyNoBusqueda(txtMON_ID_CCC, EtxtMON_ID_CCC, True)
            End If
            NuevoPlanillaRendicionCuentas(dgv, vIdentificadorDgv, vControl)
        End Sub
        Private Sub NuevoPlanillaRendicionCuentas(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, Optional ByVal vControl As Integer = 0)
            ConfigurarCampoVisualizarGridDetalle(dgv, vIdentificadorDgv)
            Select Case vControl
                Case 1
                Case Else
            End Select
        End Sub

        Private Sub TransferenciaEntreCajas(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vControl As Integer)
            If vControl = 1 Then
                ConfigurarReadOnlyNoBusqueda(txtMON_ID_CCC, EtxtMON_ID_CCC, True)
            End If
            NuevoCajaIngreso(dgv, vIdentificadorDgv, vControl)
            NuevoTransferenciaEntreCajas(dgv, vIdentificadorDgv, vControl)
            cboTipoRecibo.Text = "PAGOS"
        End Sub
        Private Sub NuevoTransferenciaEntreCajas(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, Optional ByVal vControl As Integer = 0)
            ConfigurarReadOnlyNoBusqueda(txtPER_ID_CAJ, EtxtPER_ID_CAJ, False)
            ConfigurarCampoVisualizarGridDetalle(dgv, vIdentificadorDgv)
            Select Case vControl
                Case 1
                Case Else
            End Select
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
            If vObjeto.GetType <> GetType(DataGridViewTextBoxCell) Then vObjeto.Enabled = True
            If Not IsNothing(vStructure) Then vStructure.pBusqueda = Not vBoolean ' False
            If vObjeto.name = "cboTipoRecibo" Then cboTipoRecibo.Enabled = Not vBoolean
            VerificarDatosSession()
        End Sub
        Private Sub VerificarDatosSession()
            EdtpTES_FECHA_EMI.pEnabled = SessionService.ModificarFechaProcesoEnTesoreria
        End Sub
        Private Sub ControlVisible(ByRef vObjeto As Object, ByVal vboolean As Boolean)
            vObjeto.Visible = vboolean
        End Sub
        Private Sub ControlReadOnly(ByRef vObjeto As Object, ByVal vboolean As Boolean)
            vObjeto.ReadOnly = vboolean
        End Sub
        Private Sub ProcesarGridVacio(ByRef dgv As DataGridView, Optional ByVal vControl As Integer = 0)
            If dgv.RowCount = 0 Then ' Habilita
                If dgvDetalle.RowCount = 0 And _
                   dgvDetalleEntregas.RowCount = 0 And _
                   dgvDetalleOtros.RowCount = 0 And _
                   dgvDetalleEntregas.RowCount = 0 And _
                   dgvDetalleTransferencias.RowCount = 0 Then

                    ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, False)
                    If pRegistroNuevo Then
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                                'BCVariablesNames.ProcesosCaja.VoucherCheque, _
                                ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, False)
                            Case Else
                                ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, True) ' FALSE
                        End Select
                        ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)
                    Else
                        Select Case pTDO_ID
                            Case Else
                                ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, True)
                        End Select
                        ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)
                    End If

                    Dim vSerie As String = ""
                    Dim vNumero As String = ""
                    vSerie = txtTES_SERIE.Text
                    vNumero = txtTES_NUMERO.Text
                    'If pTES_SERIEpep <> txtTES_SERIE.Text Then
                    BuscarSeries()
                    If cboSerieCorrelativo.Text <> vSerie Then
                        cboSerieCorrelativo.DataSource = Nothing
                        cboSerieCorrelativo.Items.AddRange(New Object() {vSerie})
                        txtTES_SERIE.Text = vSerie
                        txtTES_NUMERO.Text = vNumero
                    End If
                    'End If
                    ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, False)
                    ControlVisible(cboSerieCorrelativo, True)
                    ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, True)
                    cboSerieCorrelativo.Text = vSerie

                    ConfigurarReadOnlyNoBusqueda(txtCCC_ID, EtxtCCC_ID, False)
                    ConfigurarReadOnlyNoBusqueda(dtpTES_FECHA_EMI, EdtpTES_FECHA_EMI, False)
                Else
                    ' LO MISMO  <- ACA
                    ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, True)
                    Select Case pTDO_ID
                        Case Else
                            ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, True)
                    End Select
                    ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, True)
                    ConfigurarReadOnlyNoBusqueda(txtCCC_ID, EtxtCCC_ID, True)
                    ConfigurarReadOnlyNoBusqueda(dtpTES_FECHA_EMI, EdtpTES_FECHA_EMI, True)
                End If
            End If
            If dgv.RowCount >= 1 Then ' Inhabilita
                ' LO MISMO  ACA ->
                ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, True)
                Select Case pTDO_ID
                    Case Else
                        ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, True)
                End Select
                ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, True)
                ConfigurarReadOnlyNoBusqueda(txtCCC_ID, EtxtCCC_ID, True)
                ConfigurarReadOnlyNoBusqueda(dtpTES_FECHA_EMI, EdtpTES_FECHA_EMI, True)
            End If
        End Sub

        Private Sub DesBloquearBloquearControlesXModificar()
            ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, True)
            ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtCCC_ID, EtxtCCC_ID, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtTES_SERIE, EtxtTES_SERIE, True) ' Bloquea
            ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, True) ' Bloquea
            ControlVisible(cboSerieCorrelativo, False) ' Oculta
        End Sub

        Private Function EnabledObjeto(ByVal vName As String) As Boolean
            EnabledObjeto = False
            Select Case vName
                Case "cboTipoRecibo"
                    EnabledObjeto = Not EcboTipoRecibo.pEnabled
                Case "cboCCC_TIPO"
                    EnabledObjeto = Not EcboCCC_TIPO.pEnabled
                Case "dtpTES_FECHA_EMI"
                    EnabledObjeto = Not EdtpTES_FECHA_EMI.pEnabled
            End Select
        End Function

        Private Sub DataTimePcker_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles dtpTES_FECHA_EMI.DropDown
            VerificarDatosSession()
            Select Case sender.name
                Case "dtpTES_FECHA_EMI"
                    If Not EdtpTES_FECHA_EMI.pEnabled Then
                        dtpTES_FECHA_EMI.MaxDate = dtpTES_FECHA_EMI.Value
                        dtpTES_FECHA_EMI.MinDate = dtpTES_FECHA_EMI.Value
                    Else
                    End If
            End Select
        End Sub

        Public Function ProcesarTipoDocumento(ByVal vImporte As Double, ByVal FlagImporte As Boolean, Optional ByVal vNombreDgv As String = "dgvDetalle") As ProcesarImporte
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    If vImporte < 0 Then
                        vImporte = 0
                        ProcesarTipoDocumento.Importe = vImporte
                        ProcesarTipoDocumento.ProcesarEnviarDatos = False
                    Else
                        ProcesarTipoDocumento.Importe = vImporte
                        ProcesarTipoDocumento.ProcesarEnviarDatos = True
                    End If
                Case BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    If Not FlagImporte Then
                        If vImporte > 0 Then
                            vImporte = 0
                            ProcesarTipoDocumento.Importe = vImporte
                            ProcesarTipoDocumento.ProcesarEnviarDatos = False
                        Else
                            vImporte = vImporte * -1
                            ProcesarTipoDocumento.Importe = vImporte
                            ProcesarTipoDocumento.ProcesarEnviarDatos = True
                        End If
                    Else
                        If vImporte < 0 Then
                            vImporte = 0
                            ProcesarTipoDocumento.Importe = vImporte
                            ProcesarTipoDocumento.ProcesarEnviarDatos = False
                        Else
                            ProcesarTipoDocumento.Importe = vImporte
                            ProcesarTipoDocumento.ProcesarEnviarDatos = True
                        End If
                    End If
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    Select Case vNombreDgv
                        Case "dgvDetalleEntregas"
                            ProcesarTipoDocumento.Importe = vImporte
                            ProcesarTipoDocumento.ProcesarEnviarDatos = True
                        Case "dgvDetalle"
                            If vImporte > 0 Then
                                vImporte = 0
                                ProcesarTipoDocumento.Importe = vImporte
                                ProcesarTipoDocumento.ProcesarEnviarDatos = False
                            Else
                                ProcesarTipoDocumento.Importe = vImporte * -1
                                ProcesarTipoDocumento.ProcesarEnviarDatos = True
                            End If
                        Case Else
                            'If Not FlagImporte Then
                            'If vImporte > 0 Then
                            '    vImporte = 0
                            '    ProcesarTipoDocumento.Importe = vImporte
                            '    ProcesarTipoDocumento.ProcesarEnviarDatos = False
                            'Else
                            '    vImporte = vImporte * -1
                            '    ProcesarTipoDocumento.Importe = vImporte
                            '    ProcesarTipoDocumento.ProcesarEnviarDatos = True
                            'End If
                            'Else
                            If vImporte < 0 Then
                                vImporte = 0
                                ProcesarTipoDocumento.Importe = vImporte
                                ProcesarTipoDocumento.ProcesarEnviarDatos = False
                            Else
                                ProcesarTipoDocumento.Importe = vImporte
                                ProcesarTipoDocumento.ProcesarEnviarDatos = True
                            End If
                            'End If
                    End Select
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    If Not FlagImporte Then
                        If Trim(dgvDetalle.Item("cCUC_ID", dgvDetalle.CurrentRow.Index).Value.ToString <> "") Then
                            vImporte = 0
                            ProcesarTipoDocumento.ProcesarEnviarDatos = True
                        Else
                            If vImporte > 0 Then
                                vImporte = 0
                                ProcesarTipoDocumento.Importe = vImporte
                                ProcesarTipoDocumento.ProcesarEnviarDatos = False
                            Else
                                vImporte = vImporte * -1
                                ProcesarTipoDocumento.Importe = vImporte
                                ProcesarTipoDocumento.ProcesarEnviarDatos = True
                            End If
                        End If
                    Else

                        If Trim(dgvDetalle.Item("cCUC_ID", dgvDetalle.CurrentRow.Index).Value.ToString <> "") Then
                            vImporte = 0
                            ProcesarTipoDocumento.ProcesarEnviarDatos = True
                        Else
                            If vImporte < 0 Then
                                vImporte = 0
                                ProcesarTipoDocumento.Importe = vImporte
                                ProcesarTipoDocumento.ProcesarEnviarDatos = False
                            Else
                                ProcesarTipoDocumento.Importe = vImporte
                                ProcesarTipoDocumento.ProcesarEnviarDatos = True
                            End If
                        End If
                    End If
                Case Else
                    ProcesarTipoDocumento.Importe = vImporte
                    ProcesarTipoDocumento.ProcesarEnviarDatos = True
            End Select
            Return ProcesarTipoDocumento
        End Function
        Public Function ProcesarCambioTipoMonedaDoc(ByRef dgv As DataGridView, _
                                                    ByVal vIdentificadorDgv As String, _
                                                    ByVal vDTE_IMPORTE As Double, _
                                                    ByVal vTDO_ID As String, _
                                                    ByVal vDTD_ID As String, _
                                                    ByVal vDTE_SERIE As String, _
                                                    ByVal vDTE_NUMERO As String, _
                                                    ByVal vMON_ID As String, _
                                                    ByVal vCambiarMonedaSaldo As Double, _
                                                    ByVal vVerificarMonto As Boolean, _
                                                    ByVal vImporteDesdeDocumento As Boolean, _
                                                    Optional ByVal vPER_ID_CLI As String = "") As Int16

            If vCambiarMonedaSaldo = 0 Then
                ProcesarCambioTipoMonedaDoc = 1
                Exit Function
            End If

            ProcesarCambioTipoMonedaDoc = 0
            Dim vProcesarTipoDocumento As ProcesarImporte
            Dim vFlagImporteContravalor As Int16 = 0

            If vImporteDesdeDocumento Then
                ' 0 importe = vDTE_IMPORTE, contravalor = 0
                ' 1 importe = vDTE_IMPORTE * vCambiarMonedaSaldo, contravalor = vDTE_IMPORTE
                ' 2 importe = vDTE_IMPORTE / vCambiarMonedaSaldo, contravalor = vDTE_IMPORTE
                ' 3 importe = vDTE_IMPORTE *  vCambiarMonedaSaldo y 

                If txtMON_ID_CCC.Text = BCVariablesNames.MonedaSistema Then
                    If vMON_ID = txtMON_ID_CCC.Text Then
                        vFlagImporteContravalor = 0
                    Else
                        vFlagImporteContravalor = 1
                    End If
                Else
                    If vMON_ID = txtMON_ID_CCC.Text Then
                        vFlagImporteContravalor = 0
                    Else
                        If vMON_ID = BCVariablesNames.MonedaSistema Then
                            vFlagImporteContravalor = 2
                        Else
                            vFlagImporteContravalor = 3
                        End If
                    End If
                End If
            Else
                ' 0 importe = vDTE_IMPORTE, contravalor = 0
                ' 4 importe = vDTE_IMPORTE, contravalor = vDTE_IMPORTE / vCambiarMonedaSaldo
                ' 5 importe = vDTE_IMPORTE, contravalor = vDTE_IMPORTE * vCambiarMonedaSaldo
                ' 6 importe = vDTE_IMPORTE *  vCambiarMonedaSaldo y 

                If txtMON_ID_CCC.Text = BCVariablesNames.MonedaSistema Then
                    If vMON_ID = txtMON_ID_CCC.Text Then
                        vFlagImporteContravalor = 0
                    Else
                        vFlagImporteContravalor = 4
                    End If
                Else
                    If vMON_ID = txtMON_ID_CCC.Text Then
                        vFlagImporteContravalor = 0
                    Else
                        If vMON_ID = BCVariablesNames.MonedaSistema Then
                            vFlagImporteContravalor = 5
                        Else
                            vFlagImporteContravalor = 6
                        End If
                    End If
                End If
            End If
            If vVerificarMonto Then vDTE_IMPORTE = vDTE_IMPORTE - VerificarMontoDocumento(dgv, vIdentificadorDgv, vTDO_ID, vDTD_ID, vDTE_SERIE, vDTE_NUMERO, vMON_ID, vPER_ID_CLI)

            If vFlagImporteContravalor = 0 Then
                dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = vDTE_IMPORTE
                dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = 0
            ElseIf vFlagImporteContravalor = 1 Then
                dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE * vCambiarMonedaSaldo
                dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
            ElseIf vFlagImporteContravalor = 2 Then
                dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE / vCambiarMonedaSaldo
                dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
            ElseIf vFlagImporteContravalor = 3 Then
                Dim vImporteTemporal As Double = 0
                vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo
                vMON_ID = txtMON_ID_CCC.Text
                vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                If vCambiarMonedaSaldo = 0 Then
                    ProcesarCambioTipoMonedaDoc = 1
                    Exit Function
                End If
                dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vImporteTemporal / vCambiarMonedaSaldo
                dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
            ElseIf vFlagImporteContravalor = 4 Then
                dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
                dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE / vCambiarMonedaSaldo
            ElseIf vFlagImporteContravalor = 5 Then
                dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
                dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE * vCambiarMonedaSaldo
            ElseIf vFlagImporteContravalor = 6 Then
                Dim vImporteTemporal As Double = 0
                Dim vMON_IDTemporal As String = vMON_ID

                vMON_ID = txtMON_ID_CCC.Text
                vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo

                vMON_ID = vMON_IDTemporal
                vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)

                If vCambiarMonedaSaldo = 0 Then
                    ProcesarCambioTipoMonedaDoc = 1
                    Exit Function
                End If
                dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
                dgv.Item("cDTE_CONTRAVALOR_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vImporteTemporal / vCambiarMonedaSaldo
            End If
            ProcesarCambioTipoMonedaDoc = 0
        End Function
        Public Function ProcesarCambioTipoMonedaDoc_1(ByRef dgv As DataGridView, _
                                                    ByVal vIdentificadorDgv As String, _
                                                    ByVal vDTE_IMPORTE As Double, _
                                                    ByVal vTDO_ID As String, _
                                                    ByVal vDTD_ID As String, _
                                                    ByVal vDTE_SERIE As String, _
                                                    ByVal vDTE_NUMERO As String, _
                                                    ByVal vMON_ID As String, _
                                                    ByVal vCambiarMonedaSaldo As Double, _
                                                    ByVal vVerificarMonto As Boolean, _
                                                    ByVal vImporteDesdeDocumento As Boolean, _
                                                    Optional ByVal vPER_ID_CLI As String = "") As Int16

            If vCambiarMonedaSaldo = 0 Then
                ProcesarCambioTipoMonedaDoc_1 = 1
                Exit Function
            End If

            ProcesarCambioTipoMonedaDoc_1 = 0
            Dim vProcesarTipoDocumento As ProcesarImporte
            Dim vFlagImporteContravalor As Int16 = 0

            If vImporteDesdeDocumento Then
                ' 0 importe = vDTE_IMPORTE, contravalor = 0
                ' 1 importe = vDTE_IMPORTE * vCambiarMonedaSaldo, contravalor = vDTE_IMPORTE
                ' 2 importe = vDTE_IMPORTE / vCambiarMonedaSaldo, contravalor = vDTE_IMPORTE
                ' 3 importe = vDTE_IMPORTE *  vCambiarMonedaSaldo y 

                If txtMON_ID_CCC.Text = BCVariablesNames.MonedaSistema Then
                    If vMON_ID = txtMON_ID_CCC.Text Then
                        vFlagImporteContravalor = 0
                    Else
                        vFlagImporteContravalor = 1
                    End If
                Else
                    If vMON_ID = txtMON_ID_CCC.Text Then
                        vFlagImporteContravalor = 0
                    Else
                        If vMON_ID = BCVariablesNames.MonedaSistema Then
                            vFlagImporteContravalor = 2
                        Else
                            vFlagImporteContravalor = 3
                        End If
                    End If
                End If
            Else
                ' 0 importe = vDTE_IMPORTE, contravalor = 0
                ' 4 importe = vDTE_IMPORTE, contravalor = vDTE_IMPORTE / vCambiarMonedaSaldo
                ' 5 importe = vDTE_IMPORTE, contravalor = vDTE_IMPORTE * vCambiarMonedaSaldo
                ' 6 importe = vDTE_IMPORTE *  vCambiarMonedaSaldo y 

                If txtMON_ID_CCC.Text = BCVariablesNames.MonedaSistema Then
                    If vMON_ID = txtMON_ID_CCC.Text Then
                        vFlagImporteContravalor = 0
                    Else
                        vFlagImporteContravalor = 4
                    End If
                Else
                    If vMON_ID = txtMON_ID_CCC.Text Then
                        vFlagImporteContravalor = 0
                    Else
                        If vMON_ID = BCVariablesNames.MonedaSistema Then
                            vFlagImporteContravalor = 5
                        Else
                            vFlagImporteContravalor = 6
                        End If
                    End If
                End If
            End If

            If vVerificarMonto Then vDTE_IMPORTE = vDTE_IMPORTE - VerificarMontoDocumento_1(dgv, vIdentificadorDgv, vTDO_ID, vDTD_ID, vDTE_SERIE, vDTE_NUMERO)

            If vFlagImporteContravalor = 0 Then
                dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = vDTE_IMPORTE
                dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = 0
            ElseIf vFlagImporteContravalor = 1 Then
                dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE * vCambiarMonedaSaldo
                dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
            ElseIf vFlagImporteContravalor = 2 Then
                dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE / vCambiarMonedaSaldo
                dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
            ElseIf vFlagImporteContravalor = 3 Then
                Dim vImporteTemporal As Double = 0
                vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo
                vMON_ID = txtMON_ID_CCC.Text
                vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                If vCambiarMonedaSaldo = 0 Then
                    ProcesarCambioTipoMonedaDoc_1 = 1
                    Exit Function
                End If
                dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vImporteTemporal / vCambiarMonedaSaldo
                dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
            ElseIf vFlagImporteContravalor = 4 Then
                dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
                dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE / vCambiarMonedaSaldo
            ElseIf vFlagImporteContravalor = 5 Then
                dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
                dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE * vCambiarMonedaSaldo
            ElseIf vFlagImporteContravalor = 6 Then
                Dim vImporteTemporal As Double = 0
                Dim vMON_IDTemporal As String = vMON_ID

                vMON_ID = txtMON_ID_CCC.Text
                vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo

                vMON_ID = vMON_IDTemporal
                vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)

                If vCambiarMonedaSaldo = 0 Then
                    ProcesarCambioTipoMonedaDoc_1 = 1
                    Exit Function
                End If
                dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
                dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vImporteTemporal / vCambiarMonedaSaldo
            End If
            ProcesarCambioTipoMonedaDoc_1 = 0
        End Function
        Public Function DevolverMontoCambioTipoMoneda(ByVal vDTE_IMPORTE As Double, _
                                                      ByVal vMON_ID As String, ByVal vCambiarMonedaSaldo As Double) As Double
            DevolverMontoCambioTipoMoneda = 0
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    If vDTE_IMPORTE < 0 Then
                        DevolverMontoCambioTipoMoneda = 2
                        Exit Function
                    End If
            End Select

            If txtMON_ID_CCC.Text = vMON_ID Then
                DevolverMontoCambioTipoMoneda = vDTE_IMPORTE
            Else
                If txtMON_ID_CCC.Text = BCVariablesNames.MonedaSistema Then
                    DevolverMontoCambioTipoMoneda = vDTE_IMPORTE * vCambiarMonedaSaldo
                Else
                    Dim vImporteTemporal As Double = 0
                    If vMON_ID <> BCVariablesNames.MonedaSistema Then
                        vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo
                        vMON_ID = txtMON_ID_CCC.Text
                        vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                        If vCambiarMonedaSaldo = 0 Then
                            DevolverMontoCambioTipoMoneda = 1
                            Exit Function
                        End If
                        DevolverMontoCambioTipoMoneda = vImporteTemporal / vCambiarMonedaSaldo
                    Else
                        vImporteTemporal = vDTE_IMPORTE / vCambiarMonedaSaldo
                        vMON_ID = txtMON_ID_CCC.Text
                        vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                        If vCambiarMonedaSaldo = 0 Then
                            DevolverMontoCambioTipoMoneda = 1
                            Exit Function
                        End If
                        DevolverMontoCambioTipoMoneda = vImporteTemporal
                    End If
                End If
            End If
        End Function
        Public Function DevolverImporteCambioTipoMoneda(ByVal vDTE_IMPORTE As Double, _
                                                        ByVal vMON_ID As String, ByVal vCambiarMonedaSaldo As Double) As Double
            DevolverImporteCambioTipoMoneda = 0

            If txtMON_ID_CCC.Text = vMON_ID Then
                DevolverImporteCambioTipoMoneda = vDTE_IMPORTE
            Else
                If txtMON_ID_CCC.Text = BCVariablesNames.MonedaSistema Then
                    DevolverImporteCambioTipoMoneda = vDTE_IMPORTE * vCambiarMonedaSaldo
                Else
                    Dim vImporteTemporal As Double = 0
                    If vMON_ID <> BCVariablesNames.MonedaSistema Then
                        vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo
                        vMON_ID = txtMON_ID_CCC.Text
                        vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                        If vCambiarMonedaSaldo = 0 Then
                            DevolverImporteCambioTipoMoneda = 1
                            Exit Function
                        End If
                        DevolverImporteCambioTipoMoneda = vImporteTemporal / vCambiarMonedaSaldo
                    Else
                        vImporteTemporal = vDTE_IMPORTE / vCambiarMonedaSaldo
                        vMON_ID = txtMON_ID_CCC.Text
                        vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                        If vCambiarMonedaSaldo = 0 Then
                            DevolverImporteCambioTipoMoneda = 1
                            Exit Function
                        End If
                        DevolverImporteCambioTipoMoneda = vImporteTemporal
                    End If
                End If
            End If
        End Function
        Public Function DevolverContraValorCambioTipoMoneda(ByVal vDTE_IMPORTE As Double, _
                                                            ByVal vMON_ID As String, ByVal vCambiarMonedaSaldo As Double) As Double
            DevolverContraValorCambioTipoMoneda = 0

            If txtMON_ID_CCC.Text = vMON_ID Then
                DevolverContraValorCambioTipoMoneda = 0
            Else
                If txtMON_ID_CCC.Text = BCVariablesNames.MonedaSistema Then
                    DevolverContraValorCambioTipoMoneda = vDTE_IMPORTE
                Else
                    Dim vImporteTemporal As Double = 0
                    If vMON_ID <> BCVariablesNames.MonedaSistema Then
                        vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo
                        vMON_ID = txtMON_ID_CCC.Text
                        vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                        If vCambiarMonedaSaldo = 0 Then
                            DevolverContraValorCambioTipoMoneda = 1
                            Exit Function
                        End If
                        DevolverContraValorCambioTipoMoneda = vDTE_IMPORTE
                    Else
                        vImporteTemporal = vDTE_IMPORTE / vCambiarMonedaSaldo
                        vMON_ID = txtMON_ID_CCC.Text
                        vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                        If vCambiarMonedaSaldo = 0 Then
                            DevolverContraValorCambioTipoMoneda = 1
                            Exit Function
                        End If
                        DevolverContraValorCambioTipoMoneda = vDTE_IMPORTE
                    End If
                End If
            End If
        End Function



        Public Function VerificarCuc_Id(ByVal dgv As DataGridView, ByVal vIdentificadorDgv As String, ByVal vCuc_Id As String, Optional ByVal vVerificarDesdeClienteEntrega As Boolean = False) As Boolean
            VerificarCuc_Id = True
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque
                    VerificarCuc_Id = False
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If dgv.Item("cTDO_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = txtTDO_ID.Text And _
                           dgv.Item("cDTE_SERIE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = txtTES_SERIE.Text And _
                           dgv.Item("cDTE_NUMERO_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = txtTES_NUMERO.Text Then
                        If vVerificarDesdeClienteEntrega Then
                            VerificarCuc_Id = True
                        Else
                            VerificarCuc_Id = False
                        End If
                    Else
                        VerificarCuc_Id = True
                    End If
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    If cboTipoRecibo.Text = "PAGOS" Then
                        If Trim(dgv.Item("cDTD_ID_DOC", dgv.CurrentRow.Index).Value) <> "" And _
                           Trim(dgv.Item("cDTD_ID_DOC_1", dgv.CurrentRow.Index).Value) = "" And _
                           Trim(dgv.Item("cCCO_ID", dgv.CurrentRow.Index).Value) <> "" And _
                           Trim(vCuc_Id) <> "" Then
                            VerificarCuc_Id = True
                        ElseIf Trim(dgv.Item("cDTD_ID_DOC", dgv.CurrentRow.Index).Value) = "" And _
                            Trim(dgv.Item("cDTD_ID_DOC_1", dgv.CurrentRow.Index).Value) <> "" And _
                            Trim(dgv.Item("cCCO_ID", dgv.CurrentRow.Index).Value) <> "" And _
                            Trim(vCuc_Id) <> "" Then
                            VerificarCuc_Id = True
                        ElseIf Trim(dgv.Item("cDTD_ID_DOC", dgv.CurrentRow.Index).Value) = "" And _
                            Trim(dgv.Item("cDTD_ID_DOC_1", dgv.CurrentRow.Index).Value) = "" And _
                            Trim(dgv.Item("cCCO_ID", dgv.CurrentRow.Index).Value) <> "" And _
                            Trim(vCuc_Id) <> "" Then
                            VerificarCuc_Id = True
                        Else
                            If Trim(vCuc_Id) <> "" Then
                                VerificarCuc_Id = False
                            End If
                        End If
                    ElseIf cboTipoRecibo.Text = "OTROS" Then
                        If Trim(dgv.Item("cDTD_ID_DOC", dgv.CurrentRow.Index).Value) = "" And _
                           Trim(dgv.Item("cDTD_ID_DOC_1", dgv.CurrentRow.Index).Value) = "" And _
                           Trim(dgv.Item("cCCO_ID", dgv.CurrentRow.Index).Value) <> "" And _
                           Trim(vCuc_Id) <> "" Then
                            VerificarCuc_Id = True
                        ElseIf Trim(dgv.Item("cDTD_ID_DOC", dgv.CurrentRow.Index).Value) = "" And _
                           Trim(dgv.Item("cDTD_ID_DOC_1", dgv.CurrentRow.Index).Value) <> "" And _
                           Trim(dgv.Item("cCCO_ID", dgv.CurrentRow.Index).Value) <> "" And _
                           Trim(vCuc_Id) <> "" Then
                            VerificarCuc_Id = True
                        ElseIf Trim(vCuc_Id) <> "" Then
                            VerificarCuc_Id = False
                        End If
                    End If
            End Select
            Return VerificarCuc_Id
        End Function

        Public Function DocumentoPorCtaContable(ByVal vCuc_Id As String) As Boolean
            DocumentoPorCtaContable = True
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If Trim(vCuc_Id) <> "" Then
                        If Trim(dgvDetalle.Item("cDTD_ID_DOC", dgvDetalle.CurrentRow.Index).Value) <> "" Then
                            DocumentoPorCtaContable = True
                        Else
                            DocumentoPorCtaContable = False
                        End If
                    End If
            End Select
            Return DocumentoPorCtaContable
        End Function

        Public Function DocumentoNoContable(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String) As Boolean
            DocumentoNoContable = True
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    If dgv.Name = "dgvDetalleOtros" Then
                        DocumentoNoContable = False
                    Else
                        DocumentoNoContable = True
                    End If
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    If Trim(dgv.Item("cDTD_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) <> "" And _
                        Trim(dgv.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) <> "" Then
                        DocumentoNoContable = True
                    Else
                        DocumentoNoContable = False
                    End If
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    DocumentoNoContable = False
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    If cboTipoRecibo.Text = "OTROS" Then
                        DocumentoNoContable = False
                    Else
                        If dgv.Name = "dgvDetalleOtros" Then
                            DocumentoNoContable = False
                        Else
                            DocumentoNoContable = True
                        End If
                    End If
            End Select
            Return DocumentoNoContable
        End Function

        Public Function VerificarCco_Id(ByVal vCco_Id As String) As Boolean
            VerificarCco_Id = True
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    If Trim(vCco_Id) <> "" Then
                        VerificarCco_Id = False
                    End If
                Case Else
                    VerificarCco_Id = True
            End Select
            Return VerificarCco_Id
        End Function

        Public Function VerificarMon_Id(ByVal vMon_Id As String) As ProcesarMon_Id
            VerificarMon_Id.VerificarMon_Id = True
            VerificarMon_Id.Mon_Id = vMon_Id
            VerificarMon_Id.CambiarMonedaSaldo = CambiarMonedaSaldo(vMon_Id)
            If vMon_Id <> BCVariablesNames.MonedaSistema Then
                If VerificarMon_Id.CambiarMonedaSaldo = 0 Then
                    VerificarMon_Id.VerificarMon_Id = False
                    Return VerificarMon_Id
                    Exit Function
                End If
            End If
            Return VerificarMon_Id
        End Function

        Public Function VerificarImporte(ByVal vVerificarMon_Id As ProcesarMon_Id, _
                                        ByVal vTdo_Id As String, _
                                        ByVal vDtd_Id As String, _
                                        ByVal vDte_Serie As String, _
                                        ByVal vDte_Numero As String, _
                                        ByVal vDte_Importe As Double, _
                                        ByVal vSaldo As Double, _
                                        ByVal vDescontarMontoDetalleDocumento As Boolean, _
                                        Optional ByVal vPagoMasivo As Boolean = False) As ProcesarImporte_1

            Dim vProcesarTipoDocumento As ProcesarImporte
            vProcesarTipoDocumento = ProcesarTipoDocumento(vSaldo, True)
            VerificarImporte.Importe = vProcesarTipoDocumento.Importe
            VerificarImporte.ProcesarEnviarDatos = vProcesarTipoDocumento.ProcesarEnviarDatos
            If Not VerificarImporte.ProcesarEnviarDatos Then
                Return VerificarImporte
                Exit Function
            End If

            VerificarImporte.Tdo_Id = vTdo_Id
            VerificarImporte.Dtd_Id = vDtd_Id
            VerificarImporte.Serie = vDte_Serie
            VerificarImporte.Numero = vDte_Numero

            If vDescontarMontoDetalleDocumento Then
                VerificarImporte.Importe = VerificarImporte.Importe - VerificarMontoDocumento_1(dgvDetalle, _
                                                                                                "", _
                                                                                                VerificarImporte.Tdo_Id, _
                                                                                                VerificarImporte.Dtd_Id, _
                                                                                                VerificarImporte.Serie, _
                                                                                                VerificarImporte.Numero)
            End If

            vSaldo = DevolverImporteCambioTipoMoneda(VerificarImporte.Importe, _
                                                     vVerificarMon_Id.Mon_Id, _
                                                     vVerificarMon_Id.CambiarMonedaSaldo)
            VerificarImporte.ContraValor = DevolverContraValorCambioTipoMoneda(VerificarImporte.Importe, _
                                                                               vVerificarMon_Id.Mon_Id, _
                                                                               vVerificarMon_Id.CambiarMonedaSaldo)

            VerificarImporte.Importe = vSaldo
            VerificarImporte.PagoMasivo = vPagoMasivo
            'MsgBox(vSaldo)
            If vPagoMasivo Then
                If vSaldo <= 0 Then
                    Return VerificarImporte
                End If
            End If
            If vSaldo <= vDte_Importe Then
                dgvDetalle.Item("cDTE_IMPORTE_DOC", dgvDetalle.CurrentRow.Index).Value = VerificarImporte.Importe
                dgvDetalle.Item("cDTE_CONTRAVALOR_DOC", dgvDetalle.CurrentRow.Index).Value = VerificarImporte.ContraValor
            Else
                VerificarImporte.Importe = dgvDetalle.Item("cDTE_IMPORTE_DOC", dgvDetalle.CurrentRow.Index).Value
                ''' MIker
                '''
                If dgvDetalle.Item("cMON_ID_DOC", dgvDetalle.CurrentRow.Index).Value <> dgvDetalle.Item("cMON_ID_DOC_1", dgvDetalle.CurrentRow.Index).Value Then
                    If dgvDetalle.Item("cDTE_CONTRAVALOR_DOC", dgvDetalle.CurrentRow.Index).Value = 0 Then
                        VerificarImporte.ContraValor = DevolverContraValorCambioTipoMonedaMON_ID_DOC(VerificarImporte.Importe, _
                                                                       vVerificarMon_Id.Mon_Id, _
                                                                       vVerificarMon_Id.CambiarMonedaSaldo)
                    Else
                        VerificarImporte.ContraValor = dgvDetalle.Item("cDTE_CONTRAVALOR_DOC", dgvDetalle.CurrentRow.Index).Value
                    End If

                Else
                    VerificarImporte.ContraValor = dgvDetalle.Item("cDTE_CONTRAVALOR_DOC", dgvDetalle.CurrentRow.Index).Value
                End If
                ''
                ''''VerificarImporte.ContraValor = dgvDetalle.Item("cDTE_CONTRAVALOR_DOC", dgvDetalle.CurrentRow.Index).Value
            End If

            Return VerificarImporte
        End Function

        Public Function DevolverContraValorCambioTipoMonedaMON_ID_DOC(ByVal vDTE_IMPORTE As Double, _
                                                                      ByVal vMON_ID As String, ByVal vCambiarMonedaSaldo As Double) As Double
            DevolverContraValorCambioTipoMonedaMON_ID_DOC = 0
            Dim vImporteTemporal As Double = 0
            If dgvDetalle.Item("cMON_ID_DOC", dgvDetalle.CurrentRow.Index).Value <> BCVariablesNames.MonedaSistema Then
                vCambiarMonedaSaldo = CambiarMonedaSaldo(dgvDetalle.Item("cMON_ID_DOC", dgvDetalle.CurrentRow.Index).Value)
                vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo
                DevolverContraValorCambioTipoMonedaMON_ID_DOC = vImporteTemporal
            Else
                vCambiarMonedaSaldo = CambiarMonedaSaldo(dgvDetalle.Item("cMON_ID_DOC", dgvDetalle.CurrentRow.Index).Value)
                vImporteTemporal = vDTE_IMPORTE / vCambiarMonedaSaldo
                DevolverContraValorCambioTipoMonedaMON_ID_DOC = vImporteTemporal
            End If
        End Function


        Public Function VerificarImporteEntregas(ByVal vVerificarMon_Id As ProcesarMon_Id, _
                                                 ByVal vTdo_Id As String, _
                                                 ByVal vDtd_Id As String, _
                                                 ByVal vDte_Serie As String, _
                                                 ByVal vDte_Numero As String, _
                                                 ByVal vDte_Importe As Double, _
                                                 ByVal vSaldo As Double, _
                                                 ByVal vDescontarMontoDetalleDocumento As Boolean) As ProcesarImporte_1

            Dim vProcesarTipoDocumento As ProcesarImporte
            vProcesarTipoDocumento = ProcesarTipoDocumento(vSaldo, True)
            VerificarImporteEntregas.Importe = vProcesarTipoDocumento.Importe
            VerificarImporteEntregas.ProcesarEnviarDatos = vProcesarTipoDocumento.ProcesarEnviarDatos
            If Not VerificarImporteEntregas.ProcesarEnviarDatos Then
                Return VerificarImporteEntregas
                Exit Function
            End If

            VerificarImporteEntregas.Tdo_Id = vTdo_Id
            VerificarImporteEntregas.Dtd_Id = vDtd_Id
            VerificarImporteEntregas.Serie = vDte_Serie
            VerificarImporteEntregas.Numero = vDte_Numero

            If vDescontarMontoDetalleDocumento Then
                VerificarImporteEntregas.Importe = VerificarImporteEntregas.Importe - VerificarMontoDocumento_1(dgvDetalleEntregas, _
                                                                                                "", _
                                                                                                VerificarImporteEntregas.Tdo_Id, _
                                                                                                VerificarImporteEntregas.Dtd_Id, _
                                                                                                VerificarImporteEntregas.Serie, _
                                                                                                VerificarImporteEntregas.Numero)
            End If

            vSaldo = DevolverImporteCambioTipoMoneda(VerificarImporteEntregas.Importe, _
                                                     vVerificarMon_Id.Mon_Id, _
                                                     vVerificarMon_Id.CambiarMonedaSaldo)
            VerificarImporteEntregas.ContraValor = DevolverContraValorCambioTipoMoneda(VerificarImporteEntregas.Importe, _
                                                                               vVerificarMon_Id.Mon_Id, _
                                                                               vVerificarMon_Id.CambiarMonedaSaldo)

            VerificarImporteEntregas.Importe = vSaldo
            If vSaldo <= vDte_Importe Then
                dgvDetalle.Item("cDTE_IMPORTE_DOC_1", dgvDetalle.CurrentRow.Index).Value = VerificarImporteEntregas.Importe
                dgvDetalle.Item("cDTE_CONTRAVALOR_DOC_1", dgvDetalle.CurrentRow.Index).Value = VerificarImporteEntregas.ContraValor
            Else
                VerificarImporteEntregas.Importe = dgvDetalle.Item("cDTE_IMPORTE_DOC_1", dgvDetalle.CurrentRow.Index).Value
                VerificarImporteEntregas.ContraValor = dgvDetalle.Item("cDTE_CONTRAVALOR_DOC_1", dgvDetalle.CurrentRow.Index).Value
            End If

            Return VerificarImporteEntregas
        End Function
        Private Sub MensajeError(ByVal vMensaje As String)
            MsgBox(vMensaje, MsgBoxStyle.Exclamation, Me.Text)
        End Sub

        Public Sub ImporteMonedaDoc_1Cuc_Id()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                Case Else
                    dgvDetalle.Item("cDTE_IMPORTE_DOC_1", dgvDetalle.CurrentRow.Index).Value = dgvDetalle.Item("cDTE_IMPORTE_DOC", dgvDetalle.CurrentRow.Index).Value
                    dgvDetalle.Item("cDTE_CONTRAVALOR_DOC_1", dgvDetalle.CurrentRow.Index).Value = dgvDetalle.Item("cDTE_CONTRAVALOR_DOC", dgvDetalle.CurrentRow.Index).Value
                    dgvDetalle.Item("cMON_ID_DOC_1", dgvDetalle.CurrentRow.Index).Value = dgvDetalle.Item("cMON_ID_DOC", dgvDetalle.CurrentRow.Index).Value
                    dgvDetalle.Item("cMON_DESCRIPCION_DOC_1", dgvDetalle.CurrentRow.Index).Value = dgvDetalle.Item("cMON_DESCRIPCION_DOC", dgvDetalle.CurrentRow.Index).Value
            End Select
        End Sub

        Public Sub LimpiarCentroCosto()
            Select Case pDTD_ID
                Case BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso
                    dgvDetalle.Item("cCCO_ID", dgvDetalle.CurrentRow.Index).Value = ""
                    dgvDetalle.Item("cCCO_DESCRIPCION", dgvDetalle.CurrentRow.Index).Value = ""
                    dgvDetalle.Item("cDTE_MOVIMIENTO", dgvDetalle.CurrentRow.Index).Value = BCVariablesNames.Movimiento.Movimiento0
            End Select
        End Sub
        Public Sub RecalcularMontoAbono(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                     BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If Not VerificarCuc_Id(dgv, vIdentificadorDgv, dgv.Item("cCUC_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) Then
                        ImporteMonedaDoc_1Cuc_Id()
                        Exit Sub
                    End If

                    If Trim(dgv.Item("cPER_ID_CLI_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) <> "" Or _
                       Trim(dgv.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) <> "" Then

                        Dim vMON_ID As String = ""
                        Dim vCambiarMonedaSaldo As Double = 0
                        Dim vVerificarMon_Id As Object

                        vVerificarMon_Id = VerificarMon_Id(dgv.Item("cMON_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value)
                        vMON_ID = vVerificarMon_Id.Mon_Id
                        vCambiarMonedaSaldo = vVerificarMon_Id.CambiarMonedaSaldo
                        If Not vVerificarMon_Id.VerificarMon_Id Then
                            Exit Sub
                        End If

                        Dim vSaldo As Double
                        vSaldo = DevolverSaldoDocumento(
                                    "And PER_ID_CLI Like '" & Trim(dgv.Item("cPER_ID_CLI_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) & "' " & _
                                    "And TDO_ID_REF='" & dgv.Item("cTDO_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "' " & _
                                    "And DTD_ID_REF='" & dgv.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "' " & _
                                    "And DOC_SERIE_REF='" & dgv.Item("cDTE_SERIE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "' " & _
                                    "And DOC_NUMERO_REF='" & dgv.Item("cDTE_NUMERO_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "'"
                                                        )

                        Dim vVerificarImporte As Object
                        vVerificarImporte = VerificarImporte(vVerificarMon_Id, _
                                                             dgv.Item("cTDO_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value, _
                                                             dgv.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value, _
                                                             dgv.Item("cDTE_SERIE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value, _
                                                             dgv.Item("cDTE_NUMERO_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value, _
                                                             dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value, _
                                                             vSaldo, _
                                                             False
                                                            )

                        If vVerificarImporte.ProcesarEnviarDatos Then
                            dgv.Item("cTDO_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = vVerificarImporte.TDO_ID
                            dgv.Item("cDTD_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = vVerificarImporte.DTD_ID
                            pDTD_ID_DOC_1 = vVerificarImporte.DTD_ID
                            dgv.Item("cDTE_SERIE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = vVerificarImporte.Serie
                            dgv.Item("cDTE_NUMERO_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = vVerificarImporte.Numero

                            dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = vVerificarImporte.Importe
                            dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = vVerificarImporte.Contravalor
                        End If
                    End If
                Case Else
            End Select
        End Sub

        Private Function DevolverSaldoDocumento(ByVal vFiltro As String) As Decimal
            DevolverSaldoDocumento = 0
            DevolverSaldoDocumento = Me.IBCKardexCtaCte.SaldoDocumentoXML(vFiltro)
        End Function

        Public Sub VerificarImporteCentroCosto(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    dgv.Item("cDTE_IMPORTE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = 0
            End Select
        End Sub
        Public Sub VerificarImporteCuentaContable(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                    BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    dgv.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = 0
                    dgv.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = 0
                    dgv.Item("cMON_ID_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                    dgv.Item("cMON_DESCRIPCION_DOC_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
            End Select
        End Sub
        Public Function VerificarClienteDocumento(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String) As Boolean
            Dim vDatoSerie As String
            If Trim(cboSerieCorrelativo.Text) = "" Then
                vDatoSerie = txtTES_SERIE.Text
            Else
                vDatoSerie = cboSerieCorrelativo.Text
            End If
            If pFlagEliminando Or _
               pFlagCrearCodigo Or _
               pFlagDeshacer Then
                VerificarClienteDocumento = False
                Return VerificarClienteDocumento
            End If

            VerificarClienteDocumento = False
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    If dgv.RowCount = 0 Then
                        VerificarClienteDocumento = False
                    Else
                        If dgv.Name = "dgvDetalleEntregas" Then
                            VerificarClienteDocumento = False
                        Else
                            If Trim(dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) <> "" And _
                               dgv.Item("cDTD_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value <> "" Then
                                If dgv.Item("cCCT_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cTDO_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cDTD_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cDTE_SERIE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cDTE_NUMERO_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cMON_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                                   txtCCT_ID.Text & pTDO_ID & txtDTD_ID.Text & vDatoSerie & txtTES_NUMERO.Text & txtMON_ID_CCC.Text Then
                                    VerificarClienteDocumento = False
                                Else
                                    VerificarClienteDocumento = True
                                End If
                            Else
                                If Trim(dgv.Item("cCCT_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cTDO_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cDTD_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cDTE_SERIE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cDTE_NUMERO_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & _
                                   dgv.Item("cMON_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) = "" Then
                                    VerificarClienteDocumento = False
                                Else
                                    VerificarClienteDocumento = True
                                End If
                            End If
                        End If
                    End If
                Case Else
                    VerificarClienteDocumento = False
            End Select
            Return VerificarClienteDocumento
        End Function

        Public Function VerificarClienteDocumento1() As Boolean
            VerificarClienteDocumento1 = False
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    If Trim(dgvDetalle.Item("cPER_ID_CLI_1", dgvDetalle.CurrentRow.Index).Value) <> "" Or _
                       Trim(dgvDetalle.Item("cDTD_ID_DOC_1", dgvDetalle.CurrentRow.Index).Value) <> "" Then
                        VerificarClienteDocumento1 = True
                    End If
                Case Else
                    VerificarClienteDocumento1 = False
            End Select
            Return VerificarClienteDocumento1
        End Function

        Public Function VerificarBorrarDatosAdicionalesCuentaContable() As Boolean
            VerificarBorrarDatosAdicionalesCuentaContable = False
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                    BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    VerificarBorrarDatosAdicionalesCuentaContable = True
            End Select
            Return VerificarBorrarDatosAdicionalesCuentaContable
        End Function
        Public Sub ColocarDatosAdicionalesCentroCosto(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    dgv.Item("cCCT_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cCCT_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                    dgv.Item("cTDO_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cTDO_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                    dgv.Item("cDTD_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cDTD_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                    dgv.Item("cDTE_SERIE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cDTE_SERIE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                    dgv.Item("cDTE_NUMERO_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cDTE_NUMERO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                    ColocarMonedaCentroCostoCuentaContable(dgv, vIdentificadorDgv)
                    If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Then
                        If cboTipoRecibo.Text = "ENTREGAS" Then
                        Else
                            If tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                            Else
                                dgv.Item("cDTE_FEC_VEN" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = Now
                            End If
                        End If
                    Else
                        dgv.Item("cDTE_FEC_VEN" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = Now
                    End If

                    dgv.Item("cDTE_MOVIMIENTO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Movimiento.Movimiento1

                    dgv.Item("cCUC_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                    dgv.Item("cCUC_DESCRIPCION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
            End Select
        End Sub

        Public Sub ColocarDatosAdicionalesCuentaContable(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    If cboTipoRecibo.Text = "OTROS" Then
                        If Trim(dgv.Item("cDTD_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value.ToString) = "" Then
                            dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = txtPER_ID_CAJ.Text
                            dgv.Item("cPER_DESCRIPCION_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = txtPER_DESCRIPCION_CAJ.Text

                            dgv.Item("cCCT_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cCCT_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                            dgv.Item("cTDO_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cTDO_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                            dgv.Item("cDTD_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cDTD_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                            dgv.Item("cDTE_SERIE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cDTE_SERIE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                            dgv.Item("cDTE_NUMERO_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dgv.Item("cDTE_NUMERO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                            ColocarMonedaCentroCostoCuentaContable(dgv, vIdentificadorDgv)
                            dgv.Item("cDTE_FEC_VEN" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = Now
                            dgv.Item("cDTE_MOVIMIENTO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Movimiento.Movimiento0
                        End If
                    End If
            End Select
        End Sub

        Private Sub ColocarMonedaCentroCostoCuentaContable(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            dgv.Item("cMON_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = txtMON_ID_CCC.Text
        End Sub

        Private Sub ValidarMedioPago(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            If pFlagGrabando Then Return
            If dgv Is Nothing Then Return

            If VerificarMedioPagoDebeSerDocumento(dgv, vIdentificadorDgv) Then
                dgv.Item("cMPT_MEDIO_PAGO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    BCVariablesNames.MedioPago.MedioPago4
            Else
                If dgv.Item("cMPT_MEDIO_PAGO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    BCVariablesNames.MedioPago.MedioPago4 Then dgv.Item("cMPT_MEDIO_PAGO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.MedioPago.MedioPago0
            End If

            Select Case dgv.Item("cMPT_MEDIO_PAGO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                Case BCVariablesNames.MedioPago.MedioPago2, _
                     BCVariablesNames.MedioPago.MedioPago3, _
                     BCVariablesNames.MedioPago.MedioPago5
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                             BCVariablesNames.ProcesosCaja.CajaEgreso,
                             BCVariablesNames.ProcesosCaja.PlanillaEgreso
                            dgv.Item("cMPT_MEDIO_PAGO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                                BCVariablesNames.MedioPago.MedioPago0
                    End Select
                Case BCVariablesNames.MedioPago.MedioPago6
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            dgv.Item("cMPT_MEDIO_PAGO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                                BCVariablesNames.MedioPago.MedioPago0
                    End Select
            End Select
            ValidarUbicacion(dgv, vIdentificadorDgv, True)
            CalcularMontoDocumento()
        End Sub

        Private Sub ValidarDiferido(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            If dgv.Item("cMPT_MEDIO_PAGO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value <> BCVariablesNames.MedioPago.MedioPago1 Then
                dgv.Item("cMPT_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = "NO"
            End If
            If dgv.Item("cMPT_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = "SI" Then
                ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", False, True, vIdentificadorDgv)
            ElseIf dgv.Item("cMPT_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = "NO" Then
                If pTDO_ID = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento _
                    Or pTDO_ID = BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas Then
                    ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)
                Else
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.CajaEgreso, _
                             BCVariablesNames.ProcesosCaja.PlanillaEgreso, _
                             BCVariablesNames.ProcesosCaja.DepositoTercero, _
                             BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                        Case BCVariablesNames.ProcesosCaja.VoucherCheque
                            If dgv.Name = "dgvDetalleOtros" Then
                            Else
                                ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, True, vIdentificadorDgv)
                            End If
                        Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                            If dgv.Name = "dgvDetalleOtros" Then
                            Else
                                ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, True, vIdentificadorDgv)
                            End If
                        Case Else
                            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, True, vIdentificadorDgv)
                    End Select
                End If
            End If
        End Sub
        Private Sub ValidarUbicacion(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, Optional ByVal vBloquearInicializarColumnasGrid As Boolean = False)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    Select Case dgv.Item("cMPT_MEDIO_PAGO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                        Case BCVariablesNames.MedioPago.MedioPago3
                            dgv.Item("cMPT_UBICACION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Ubicacion.Ubicacion0
                            If vBloquearInicializarColumnasGrid Then
                                dgv.Item("cMPT_SERIE_MEDIO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""

                                dgv.Item("cMPT_GIRADO_A" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cMPT_CONCEPTO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cPER_ID_BAN" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cMPT_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = "NO"
                                EtxtPER_ID_BAN.pBusqueda = False
                                ConfigurarVisualizarDatosMedioPago(dgv, vIdentificadorDgv, True)
                            End If
                    End Select
                Case Else
                    Select Case dgv.Item("cMPT_MEDIO_PAGO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value
                        Case BCVariablesNames.MedioPago.MedioPago0
                            dgv.Item("cMPT_UBICACION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Ubicacion.Ubicacion0
                            If vBloquearInicializarColumnasGrid Then
                                dgv.Item("cMPT_SERIE_MEDIO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""

                                '' 2015-07-31
                                Select Case pTDO_ID
                                    Case BCVariablesNames.ProcesosCaja.DepositoTercero
                                    Case Else
                                        dgv.Item("cMPT_NUMERO_MEDIO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                End Select


                                dgv.Item("cMPT_GIRADO_A" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cMPT_CONCEPTO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cPER_ID_BAN" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cMPT_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = "NO"
                                EtxtPER_ID_BAN.pBusqueda = False
                                Select Case pTDO_ID
                                    Case BCVariablesNames.ProcesosCaja.CajaEgreso, _
                                         BCVariablesNames.ProcesosCaja.PlanillaEgreso, _
                                         BCVariablesNames.ProcesosCaja.DepositoTercero
                                        ' MODIFICADO 2015-07-16
                                    Case Else
                                        ConfigurarVisualizarDatosMedioPago(dgv, vIdentificadorDgv, True)
                                End Select
                            End If
                        Case BCVariablesNames.MedioPago.MedioPago1
                            Select Case pTDO_ID
                                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                                    Select Case Me.Name
                                        Case "frmTransferenciaEntreCajas"
                                            dgv.Item("cMPT_UBICACION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Ubicacion.Ubicacion1
                                        Case "frmDepositosBancarios"
                                            dgv.Item("cMPT_UBICACION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Ubicacion.Ubicacion2
                                    End Select

                                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                                     BCVariablesNames.ProcesosCaja.PlanillaEgreso
                                    dgv.Item("cMPT_UBICACION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Ubicacion.Ubicacion1
                                Case BCVariablesNames.ProcesosCaja.DepositoTercero,
                                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                                     BCVariablesNames.ProcesosCaja.VoucherCheque
                                    dgv.Item("cMPT_UBICACION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Ubicacion.Ubicacion2
                                Case Else
                                    dgv.Item("cMPT_UBICACION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Ubicacion.Ubicacion0
                            End Select
                            If vBloquearInicializarColumnasGrid Then
                                EtxtPER_ID_BAN.pBusqueda = True
                                Select Case pTDO_ID
                                    Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                                        Select Case Me.Name
                                            Case "frmTransferenciaEntreCajas"
                                            Case "frmDepositosBancarios"
                                                EtxtPER_ID_BAN.pBusqueda = False
                                        End Select
                                    Case BCVariablesNames.ProcesosCaja.CajaEgreso, _
                                         BCVariablesNames.ProcesosCaja.PlanillaEgreso, _
                                         BCVariablesNames.ProcesosCaja.DepositoTercero
                                        ' MODIFICADO 2015-07-16
                                    Case Else
                                        ConfigurarVisualizarDatosMedioPago(dgv, vIdentificadorDgv, False)
                                End Select
                            End If
                        Case BCVariablesNames.MedioPago.MedioPago2, _
                             BCVariablesNames.MedioPago.MedioPago3, _
                             BCVariablesNames.MedioPago.MedioPago5
                            dgv.Item("cMPT_UBICACION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Ubicacion.Ubicacion0
                            If vBloquearInicializarColumnasGrid Then
                                dgv.Item("cMPT_GIRADO_A" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cMPT_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = "NO"
                                EtxtPER_ID_BAN.pBusqueda = True
                                If pTDO_ID = BCVariablesNames.ProcesosCaja.DepositoTercero Then
                                    ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, vIdentificadorDgv)
                                    ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, False, vIdentificadorDgv)
                                    ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
                                    ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, vIdentificadorDgv)
                                Else
                                    ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", False, True, vIdentificadorDgv)
                                    ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", False, True, vIdentificadorDgv)
                                    ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, True, vIdentificadorDgv)
                                    ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", False, True, vIdentificadorDgv)
                                End If
                                ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", False, True, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, True, vIdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, True, vIdentificadorDgv)
                            End If
                        Case BCVariablesNames.MedioPago.MedioPago4, BCVariablesNames.MedioPago.MedioPago6
                            dgv.Item("cMPT_UBICACION" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = BCVariablesNames.Ubicacion.Ubicacion0
                            If vBloquearInicializarColumnasGrid Then
                                dgv.Item("cMPT_GIRADO_A" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cPER_ID_BAN" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = ""
                                dgv.Item("cMPT_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = "NO"
                                EtxtPER_ID_BAN.pBusqueda = False
                                ConfigurarVisualizarDatosMedioPagoDocumentoRetencionIGV(dgv, vIdentificadorDgv)
                            End If
                    End Select
            End Select

        End Sub

        Private Sub ConfigurarVisualizarDatosMedioPago(ByRef dgv As DataGridView, ByVal IdentificadorDgv As String, ByVal vSoloLectura As Boolean)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, IdentificadorDgv)

                    ' modificado 2015-07-16
                    ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", False, True, IdentificadorDgv)
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                    BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", vSoloLectura, True, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", vSoloLectura, True, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", vSoloLectura, False, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", vSoloLectura, True, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", vSoloLectura, False, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", vSoloLectura, False, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", vSoloLectura, False, IdentificadorDgv)
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    If dgv.Name = "dgvDetalleOtros" Then
                    Else
                        ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", Not vSoloLectura, True, IdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", Not vSoloLectura, True, IdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", vSoloLectura, True, IdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", vSoloLectura, True, IdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", Not vSoloLectura, True, IdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", vSoloLectura, True, IdentificadorDgv)
                        ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", vSoloLectura, True, IdentificadorDgv)
                    End If
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                            If dgv.Name = "dgvDetalleOtros" Then
                            Else
                                ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", vSoloLectura, True, IdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", vSoloLectura, True, IdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", vSoloLectura, True, IdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", vSoloLectura, True, IdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", vSoloLectura, True, IdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", vSoloLectura, True, IdentificadorDgv)
                                ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", vSoloLectura, True, IdentificadorDgv)
                            End If
                        Case "frmDepositosBancarios"
                            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, True, IdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, True, IdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", vSoloLectura, True, IdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", vSoloLectura, True, IdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, True, IdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, True, IdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, True, IdentificadorDgv)
                    End Select
                Case Else
                    ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", vSoloLectura, True, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", vSoloLectura, True, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", vSoloLectura, True, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", vSoloLectura, True, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", vSoloLectura, True, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", vSoloLectura, True, IdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", vSoloLectura, True, IdentificadorDgv)
            End Select
        End Sub

        Private Sub ConfigurarVisualizarDatosMedioPagoDocumentoRetencionIGV(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                        Case Else
                            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)
                    End Select
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, False, vIdentificadorDgv)
                    ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, False, vIdentificadorDgv)
                Case Else
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                        Case BCVariablesNames.ProcesosCaja.DepositoTercero
                            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, False, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", True, False, vIdentificadorDgv)
                        Case Else
                            ConfigurarColumnasGrid(dgv, "cMPT_SERIE_MEDIO", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_NUMERO_MEDIO", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_GIRADO_A", True, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_CONCEPTO", False, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cPER_ID_BAN", True, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_DIFERIDO", True, True, vIdentificadorDgv)
                            ConfigurarColumnasGrid(dgv, "cMPT_FECHA_DIFERIDO", True, True, vIdentificadorDgv)
                    End Select
            End Select
        End Sub

        Private Sub ValidarFechaDiferido(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            If Not IsDate(dgv.Item("cMPT_FECHA_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) Then dgv.Item("cMPT_FECHA_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = Now
            Select Case Me.Name
                Case "frmDepositosBancarios"
                Case Else
                    If dgv.Item("cMPT_FECHA_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value < dtpTES_FECHA_EMI.Value Then dgv.Item("cMPT_FECHA_DIFERIDO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = dtpTES_FECHA_EMI.Value
            End Select
        End Sub

        Private Function VerificarMedioPagoDebeSerDocumento(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String) As Boolean
            Try
                VerificarMedioPagoDebeSerDocumento = False
                If Trim(dgv.Item("cCUC_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) <> "" And _
                   Trim(dgv.Item("cCCT_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) & _
                   Trim(dgv.Item("cTDO_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) & _
                   Trim(dgv.Item("cDTD_ID_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) & _
                   Trim(dgv.Item("cDTE_SERIE_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) & _
                   Trim(dgv.Item("cDTE_NUMERO_DOC" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) <>
                   Trim(dgv.Item("cCCT_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) & _
                   Trim(dgv.Item("cTDO_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) & _
                   Trim(dgv.Item("cDTD_ID" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) & _
                   Trim(dgv.Item("cDTE_SERIE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) & _
                   Trim(dgv.Item("cDTE_NUMERO" & vIdentificadorDgv, dgv.CurrentRow.Index).Value) Then
                    VerificarMedioPagoDebeSerDocumento = True
                End If
                Select Case pTDO_ID
                    Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                        BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                        VerificarMedioPagoDebeSerDocumento = True
                End Select
                Return VerificarMedioPagoDebeSerDocumento
            Catch ex As Exception
                MsgBox(ex.Message & " -  " & Err.Number)
            End Try
        End Function

        Public Function EsLiquidacionDocumento() As Boolean
            EsLiquidacionDocumento = False
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                    BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    EsLiquidacionDocumento = True
                Case Else
                    EsLiquidacionDocumento = False
            End Select
            Return EsLiquidacionDocumento
        End Function

        Private Function MensajeOperaciones(ByVal vRespuesta As Int16, ByVal vOperacion As String) As Int16
            MensajeOperaciones = vRespuesta
            Select Case vRespuesta
                Case 0
                    MsgBox("Registro " & vOperacion, MsgBoxStyle.Information, Me.Text)
                Case 1
                Case 2
                    MsgBox("Registro no fue " & vOperacion & " verifique sus datos" & _
                           Chr(13) & Chr(13) & Compuesto.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto1.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto2.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto3.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto4.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto6.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto8.vMensajeError, _
                           MsgBoxStyle.Information, Me.Text)
            End Select
            Return MensajeOperaciones
        End Function

        Public Function ProcesarTipoMovimientoDeDocumento(ByVal vCCT_ID As String, ByVal vTDO_ID As String, ByVal vDTD_ID As String) As String
            ProcesarTipoMovimientoDeDocumento = Me.IBCRolOpeCtaCte.MovimientoCargoAbonoRolOpeCtaCte(
                            vCCT_ID, _
                            vTDO_ID, _
                            vDTD_ID)
            Return ProcesarTipoMovimientoDeDocumento
        End Function

        Private Sub cboTipoRecibo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoRecibo.SelectedIndexChanged
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.CajaEgreso,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque
                    EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And ROC_TIPO='" & cboTipoRecibo.Text & "' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.ReciboIngresoEgreso & "'"
                Case BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And ROC_TIPO='" & cboTipoRecibo.Text & "' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.PlanillaIngresoEgreso & "'"
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And DTD_ID Like '" & pDTD_ID & "' And ROC_TIPO='" & cboTipoRecibo.Text & "' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.TransferenciaEntreCajaBanco & "'"
                    'EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And ROC_TIPO='" & cboTipoRecibo.Text & "' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.TransferenciaEntreCajaBanco & "'"
            End Select

            If pFlagVerificarCajaCtaCte Then
                Select Case cboTipoRecibo.Text
                    Case "PAGOS"
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.CajaIngreso
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxCComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso
                                pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso

                            Case BCVariablesNames.ProcesosCaja.CajaEgreso
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso
                                pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso

                            Case BCVariablesNames.ProcesosCaja.DepositoTercero
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxCComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.DepTerDepositoTercero
                                pDTD_ID = BCVariablesNames.ProcesosCaja.DepTerDepositoTercero

                            Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxCComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NABNotaAbonoCtaBanco
                                pDTD_ID = BCVariablesNames.ProcesosCaja.NABNotaAbonoCtaBanco

                            Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NCBDetraccionesNotaCargoCtaBanco
                                pDTD_ID = BCVariablesNames.ProcesosCaja.NCBDetraccionesNotaCargoCtaBanco

                            Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NCBNotaCargoCtaBanco
                                pDTD_ID = BCVariablesNames.ProcesosCaja.NCBNotaCargoCtaBanco

                            Case BCVariablesNames.ProcesosCaja.VoucherCheque
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.VCVoucherCheque
                                pDTD_ID = BCVariablesNames.ProcesosCaja.VCVoucherCheque
                                tcoTipoRecibo.Visible = True
                                tcoTipoRecibo.SelectedIndex = 0

                            Case BCVariablesNames.ProcesosCaja.PlanillaEgreso
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.PlaEgrPlanillaEgreso
                                pDTD_ID = BCVariablesNames.ProcesosCaja.PlaEgrPlanillaEgreso
                        End Select
                    Case "ENTREGAS"
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.CajaIngreso
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxCComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.AnticipoRecibidoCajaIngreso
                                pDTD_ID = BCVariablesNames.ProcesosCaja.AnticipoRecibidoCajaIngreso

                            Case BCVariablesNames.ProcesosCaja.CajaEgreso
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.EaRendirCuentas
                                pCCT_ID = BCVariablesNames.CCT_ID.EaRendirCuentas

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.EntregaRendirCuentaReciboEgreso
                                pDTD_ID = BCVariablesNames.ProcesosCaja.EntregaRendirCuentaReciboEgreso

                            Case BCVariablesNames.ProcesosCaja.DepositoTercero
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxCComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.AnticipoRecibidoDepositoTercero
                                pDTD_ID = BCVariablesNames.ProcesosCaja.AnticipoRecibidoDepositoTercero

                            Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxCComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.AnticipoRecibidoNotaAbonoCtaBanco
                                pDTD_ID = BCVariablesNames.ProcesosCaja.AnticipoRecibidoNotaAbonoCtaBanco

                            Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NCBDetraccionesNotaCargoCtaBanco
                                pDTD_ID = BCVariablesNames.ProcesosCaja.NCBDetraccionesNotaCargoCtaBanco

                            Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.AnticipoOtorgadoNotaCargoCtaBanco
                                pDTD_ID = BCVariablesNames.ProcesosCaja.AnticipoOtorgadoNotaCargoCtaBanco

                            Case BCVariablesNames.ProcesosCaja.VoucherCheque
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                                pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.AnticipoOtorgadoVoucherCheque
                                pDTD_ID = BCVariablesNames.ProcesosCaja.AnticipoOtorgadoVoucherCheque
                                tcoTipoRecibo.Visible = False
                                tcoTipoRecibo.SelectedIndex = 0

                            Case BCVariablesNames.ProcesosCaja.PlanillaEgreso
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.EaRendirCuentas
                                pCCT_ID = BCVariablesNames.CCT_ID.EaRendirCuentas

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.EntregaRendirCuentaPlanillaEgreso
                                pDTD_ID = BCVariablesNames.ProcesosCaja.EntregaRendirCuentaPlanillaEgreso

                        End Select
                    Case "OTROS"
                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.CajaIngreso
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                                pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso
                                pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboIngresoCajaIngreso

                            Case BCVariablesNames.ProcesosCaja.CajaEgreso
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                                pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso
                                pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso

                            Case BCVariablesNames.ProcesosCaja.DepositoTercero
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                                pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.DepTerDepositoTercero
                                pDTD_ID = BCVariablesNames.ProcesosCaja.DepTerDepositoTercero

                            Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                                pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NABNotaAbonoCtaBanco
                                pDTD_ID = BCVariablesNames.ProcesosCaja.NABNotaAbonoCtaBanco

                            Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                                pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NCBDetraccionesNotaCargoCtaBanco
                                pDTD_ID = BCVariablesNames.ProcesosCaja.NCBDetraccionesNotaCargoCtaBanco

                            Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                                pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.NCBNotaCargoCtaBanco
                                pDTD_ID = BCVariablesNames.ProcesosCaja.NCBNotaCargoCtaBanco

                            Case BCVariablesNames.ProcesosCaja.VoucherCheque
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                                pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.VCVoucherCheque
                                pDTD_ID = BCVariablesNames.ProcesosCaja.VCVoucherCheque
                                tcoTipoRecibo.Visible = False
                                tcoTipoRecibo.SelectedIndex = 0


                            Case BCVariablesNames.ProcesosCaja.PlanillaEgreso
                                txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                                pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                                txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.PlaEgrPlanillaEgreso
                                pDTD_ID = BCVariablesNames.ProcesosCaja.PlaEgrPlanillaEgreso
                        End Select
                End Select
            End If
            FormatearCamposAMostrarEnGrid()
            VerificarEsEntregaEdicion()
            If pLoaded Then Return
            MetodoBusquedaDato(dgvDetalle, "", pCCT_ID & txtTDO_ID.Text & txtDTD_ID.Text, True, EtxtDTD_ID)
        End Sub
        Public Function VerificarMonedaDelImporte(ByVal vSaldoDocumento As Double, ByVal vMON_ID As String, ByVal vCambiarMonedaSaldo As Double) As Double
            Dim vSaldo As Double = 0
            If txtMON_ID_CCC.Text = vMON_ID Then
                vSaldo = vSaldoDocumento
            Else
                If txtMON_ID_CCC.Text = BCVariablesNames.MonedaSistema Then
                    vSaldo = vSaldoDocumento * vCambiarMonedaSaldo
                Else
                    Dim vImporteTemporal1 As Double = 0
                    If vMON_ID <> BCVariablesNames.MonedaSistema Then
                        vImporteTemporal1 = vSaldoDocumento * vCambiarMonedaSaldo
                        vMON_ID = txtMON_ID_CCC.Text
                        vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                        If vCambiarMonedaSaldo = 0 Then
                            'ProcesarCambioTipoMonedaDoc = 1
                            'Exit Sub
                        End If
                        'vSaldo = vSaldoDocumento / vCambiarMonedaSaldo
                        vSaldo = vImporteTemporal1 / vCambiarMonedaSaldo
                    Else
                        vMON_ID = txtMON_ID_CCC.Text
                        vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                        If vCambiarMonedaSaldo = 0 Then
                            'ProcesarCambioTipoMonedaDoc = 1
                            'Exit Function
                        End If

                        Select Case pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                                vSaldo = vSaldoDocumento
                            Case Else
                                vSaldo = vSaldoDocumento / vCambiarMonedaSaldo
                        End Select
                    End If
                End If
            End If
            Return vSaldo
        End Function

        Private Sub btnBuscarPagosCobros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPagosCobros.Click
            vBCVariablesNamesProcesosCtaCteLiquidacionDocumento = ""
            vBusquedaDesdePagosCobros = True
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                    vAumentarLetraGrilla = True
                    'EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = False
                    'EtxtDTD_ID_DOC_CLI_REC.pSeleccionarTodosEnMarcados = True
                    EtxtDTD_ID_DOC_CLI_REC.pTotalizarCampo = True
                    EtxtDTD_ID_DOC_CLI_REC.pNombreCampoTotalizar = "SALDO"

                    EtxtDTD_ID_DOC_CLI_REC.pOOrm.Vista = "spSaldoDocumentoMontoNoCeroDetraccionesConCheck"
                    EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And CCT_ID_REF Like '" & txtCCT_ID.Text & "' AND (SUM(CARGO)-SUM(ABONO)<0) "
                    MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)

                    EtxtDTD_ID_DOC_CLI_REC.pTotalizarCampo = False
                    EtxtDTD_ID_DOC_CLI_REC.pNombreCampoTotalizar = ""

                    'vAumentarLetraGrilla = True
                    'EtxtDTD_ID_DOC_CLI_REC.pOOrm.Vista = "spSaldoDocumentoMontoNoCeroDetraccionesCopiaXML"
                    'EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And CCT_ID_REF Like '" & txtCCT_ID.Text & "' AND (SUM(CARGO)-SUM(ABONO)<0) "
                    'MetodoBusquedaDato2(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC)


                Case BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And CCT_ID_REF Like '" & txtCCT_ID.Text & "' AND (SUM(CARGO)-SUM(ABONO)<0) "
                    MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC)
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                        EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID_REC.Text & "'"
                        MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                            EtxtDTD_ID_DOC_CLI_REC_1.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                            MetodoBusquedaDato(dgvDetalleEntregas, "e", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC_1, True)
                        End If
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                    End If
                Case BCVariablesNames.ProcesosCaja.DepositoTercero
                    If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                        EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                        MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                    End If
                Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                    If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                        EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                        MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                    End If
                Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    Select Case tcoTipoRecibo.SelectedTab.Name
                        Case "tpaPagos"
                            If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                                EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                                MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                            End If
                        Case "tpaEntregas"
                        Case "tpaOtros"
                    End Select
                Case BCVariablesNames.ProcesosCaja.CajaIngreso
                    If SessionService.ReciboIngresoPlanilla Then
                        If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                            EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                            MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                        Else
                            EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = False
                            EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '%' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                            MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                            EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = True
                        End If
                    Else
                        If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                            EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                            MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                        End If
                    End If
                Case BCVariablesNames.ProcesosCaja.CajaEgreso
                    If SessionService.ReciboEgresoPlanilla Then
                        If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                            EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                            MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                        Else
                            EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = False
                            EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '%' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                            MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                            EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = True
                        End If
                    Else
                        If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                            EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                            MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                        End If
                    End If
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
                    If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                        EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                        MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                    End If
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    vBCVariablesNamesProcesosCtaCteLiquidacionDocumento = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    'If Trim(txtPER_ID_CLI_REC.Text) = "" Then
                    EtxtDTD_ID_DOC_CLI_REC.pTotalizarCampo = True
                    EtxtDTD_ID_DOC_CLI_REC.pNombreCampoTotalizar = "SALDO"
                    EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = False
                    EtxtDTD_ID_DOC_CLI_REC.pSeleccionarTodosEnMarcados = True
                    EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '%" & txtPER_ID_CLI_REC.Text & "%' And CCT_ID_REF Like '" & txtCCT_ID_REC.Text & "'"
                    MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC, True)
                    EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = True
                    EtxtDTD_ID_DOC_CLI_REC.pSeleccionarTodosEnMarcados = False
                    'End If
                Case Else
                    If Trim(txtPER_ID_CLI_REC.Text) <> "" Then
                        EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                        MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_CLI_REC.Text, False, EtxtDTD_ID_DOC_CLI_REC)
                    End If
            End Select
            vBusquedaDesdePagosCobros = False
        End Sub

        Private Sub btnImpresion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpresion.Click
            If RevisarDatos(False, True) <> False Then Exit Sub
            Dim oReporte As Object
            Dim oReporte1 As New Ladisac.Tesoreria.Reportes.ReciboTesoreriaNuevo
            Dim oReporte2 As New Ladisac.Tesoreria.Reportes.ReciboTesoreriaPRC
            Dim oReporte3 As New Ladisac.Tesoreria.Reportes.ReciboTesoreriaLiquidacion
            Dim oReporte4 As New Ladisac.Tesoreria.Reportes.ReciboTesoreriaNotaAbono

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    oReporte = oReporte2
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    oReporte = oReporte3
                Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    oReporte = oReporte4
                Case Else
                    oReporte = oReporte1
            End Select

            oReporte.DataDefinition.FormulaFields("NombreEmpresa").Text = "'" & SessionService.NombreEmpresa & "'"
            oReporte.DataDefinition.FormulaFields("RucEmpresa").Text = "'" & SessionService.RUCEmpresa & "'"
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso
                    oReporte.DataDefinition.FormulaFields("Ocultar").Text = "False"
                Case BCVariablesNames.ProcesosCaja.CajaEgreso, _
                     BCVariablesNames.ProcesosCaja.DepositoTercero, _
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                     BCVariablesNames.ProcesosCaja.VoucherCheque, _
                     BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas, _
                     BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    oReporte.DataDefinition.FormulaFields("Ocultar").Text = "True"
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco
                    IBCConsultasReportesContabilidad.SPExportarDetracciones(txtCCC_ID.Text, txtTDO_ID.Text, txtDTD_ID.Text, txtTES_NUMERO.Text, txtTES_SERIE.Text)
                    Exit Sub
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    oReporte.DataDefinition.FormulaFields("Ocultar").Text = "True"
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    oReporte.DataDefinition.FormulaFields("Ocultar").Text = "False"
                Case Else
                    Exit Sub
            End Select

            If pRegistroNuevo Then
                MsgBox("Debe grabar el documento para poder imprimirlo", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            Dim CadenaVista As String = ""
            Dim ds As New DataSet
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                    CadenaVista = IBCMaestro.EjecutarVista("dbo.spImpresionReciboTesoreriaNuevo2Xml", txtTDO_ID.Text, txtDTD_ID.Text, txtCCC_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    CadenaVista = IBCMaestro.EjecutarVista("dbo.spImpresionReciboTesoreriaLiquidacionXML", txtTDO_ID.Text, txtDTD_ID.Text, txtCCC_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)
                Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco
                    CadenaVista = IBCMaestro.EjecutarVista("dbo.spImpresionReciboTesoreriaNotaAbonoXML", txtTDO_ID.Text, txtDTD_ID.Text, txtCCC_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)
                Case Else
                    CadenaVista = IBCMaestro.EjecutarVista("dbo.spImpresionReciboTesoreriaNuevo1Xml", txtTDO_ID.Text, txtDTD_ID.Text, txtCCC_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)
            End Select
            Dim sr As New StringReader(CadenaVista)
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                oReporte.SetDataSource(ds.Tables(0))
                Dim ImprimirDocumento As New CrystalDecisions.Windows.Forms.CrystalReportViewer
                ImprimirDocumento.ReportSource = oReporte
                ImprimirDocumento.PrintReport()
            End If
        End Sub

        Private Sub tcoTipoRecibo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcoTipoRecibo.SelectedIndexChanged
            ConfigurarDatos(tcoTipoRecibo.SelectedTab.Name)
            DeshabilitarHabilitar_REC()
        End Sub
        Private Sub ConfigurarDatos(ByVal vNombreTabPage As String)
            txtPRE_SERIE.Visible = False
            txtPRE_NUMERO.Visible = False
            Select Case vNombreTabPage
                Case "tpaPagos"
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                             BCVariablesNames.ProcesosCaja.VoucherCheque
                            cboTipoRecibo.Visible = True
                            lblDTD_ID.Visible = True
                            txtDTD_ID.Visible = True
                            txtDTD_DESCRIPCION.Visible = True
                            lblCCT_ID.Visible = True
                            txtCCT_ID.Visible = True
                            txtCCT_DESCRIPCION.Visible = True
                    End Select

                    HabilitarDatos("Pagos", True)
                    HabilitarDatos("Entregas", False)
                    HabilitarDatos("Otros", False)
                    HabilitarDatos("Transferencias", False)
                Case "tpaEntregas"
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                             BCVariablesNames.ProcesosCaja.VoucherCheque
                            cboTipoRecibo.Visible = False
                            lblDTD_ID.Visible = False
                            txtDTD_ID.Visible = False
                            txtDTD_DESCRIPCION.Visible = False
                            lblCCT_ID.Visible = False
                            txtCCT_ID.Visible = False
                            txtCCT_DESCRIPCION.Visible = False
                    End Select

                    HabilitarDatos("Pagos", False)
                    HabilitarDatos("Entregas", True)
                    HabilitarDatos("Otros", False)
                    HabilitarDatos("Transferencias", False)
                    txtPRE_SERIE.Visible = True
                    txtPRE_NUMERO.Visible = True
                Case "tpaOtros"
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                             BCVariablesNames.ProcesosCaja.VoucherCheque
                            cboTipoRecibo.Visible = False
                            lblDTD_ID.Visible = False
                            txtDTD_ID.Visible = False
                            txtDTD_DESCRIPCION.Visible = False
                            lblCCT_ID.Visible = False
                            txtCCT_ID.Visible = False
                            txtCCT_DESCRIPCION.Visible = False
                    End Select

                    HabilitarDatos("Pagos", False)
                    HabilitarDatos("Entregas", False)
                    HabilitarDatos("Otros", True)
                    HabilitarDatos("Transferencias", False)
                Case "tpaTransferencias"
                    Select Case pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco, _
                             BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco, _
                             BCVariablesNames.ProcesosCaja.VoucherCheque
                            cboTipoRecibo.Visible = False
                            lblDTD_ID.Visible = False
                            txtDTD_ID.Visible = False
                            txtDTD_DESCRIPCION.Visible = False
                            lblCCT_ID.Visible = False
                            txtCCT_ID.Visible = False
                            txtCCT_DESCRIPCION.Visible = False
                    End Select

                    HabilitarDatos("Pagos", False)
                    HabilitarDatos("Entregas", False)
                    HabilitarDatos("Otros", False)
                    HabilitarDatos("Transferencias", True)
            End Select
        End Sub
        Private Sub HabilitarDatos(ByVal vTipoRecibo As String, ByVal vBoolean As Boolean)
            Select Case vTipoRecibo
                Case "Pagos"
                    dgvDetalle.Visible = vBoolean
                Case "Entregas"
                    dgvDetalleEntregas.Visible = vBoolean
                Case "Otros"
                    dgvDetalleOtros.Visible = vBoolean
                Case "Transferencias"
                    dgvDetalleTransferencias.Visible = vBoolean
            End Select
        End Sub
        Private Sub btnEntregasPagos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntregasPagos.Click
            'Exit Sub
            pPasandoEntregasAPagos = True
            pCCC_IDpep = txtCCC_ID.Text
            pTDO_IDpep = txtTDO_ID.Text
            pDTD_IDpep = txtDTD_ID.Text
            pTES_SERIEpep = txtTES_SERIE.Text
            pTES_NUMEROpep = txtTES_NUMERO.Text
            pEliminar = False
            tsbEliminar.Enabled = Eliminar

            ''ActualizarCorrelativo()

            ReDim eRegistrosEliminar(1)
            ReDim eRegistrosEliminarDocumento(1)
            ReDim eRegistrosEliminarDocumento_1(1)
            InicializarValores(dgvDetalle, ErrorProvider1)

            cboTipoRecibo.Text = "PAGOS"
            txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
            pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

            txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso
            pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso

            'MetodoBusquedaDato(dgvdetalle, "",pCCT_ID & txtTDO_ID.Text & txtDTD_ID.Text, False, EtxtDTD_ID)
        End Sub

        Public Sub MostrarControlesConsulta()
            'txtTIV_ID.Text = BCVariablesNames.TipoVentaContraEntrega
            'txtTIV_DESCRIPCION.Text = "CONTRA ENTREGA"

            'pnCuerpo.Controls.Remove(txtTIV_ID)
            'pnCuerpo.Controls.Remove(txtDOC_OBSERVACIONES)

            'Me.Controls.Add(txtTIV_ID)
            'Me.Controls.Add(txtDOC_OBSERVACIONES)

            'EtxtTIV_ID.pOOrm.CadenaFiltrado = " AND (TIV_COMPORTAMIENTO='VENTAS' OR TIV_COMPORTAMIENTO='COMPRAS Y VENTAS')"

            'txtTIV_ID.BringToFront()
            'txtTIV_ID.ReadOnly = False
            'txtTIV_ID.Enabled = True
            'txtTIV_ID.Location = New System.Drawing.Point(396, 61)

            'txtDOC_OBSERVACIONES.BringToFront()
            'txtDOC_OBSERVACIONES.ReadOnly = False
            'txtDOC_OBSERVACIONES.Enabled = True
            'txtDOC_OBSERVACIONES.Location = New System.Drawing.Point(305, 340) ' 315 - 340

            btnImpresion.Enabled = False
            btnImpresion.Focus()
        End Sub

        Private Sub btnBuscarCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCheques.Click
            vBusquedaDesdePagosCobros = True
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                    Select Case Me.Name
                        Case "frmTransferenciaEntreCajas"
                        Case "frmDepositosBancarios"
                            If Trim(txtPER_ID_DES.Text) <> "" Then
                                EtxtMPT_NUMERO_MEDIO.pOOrm.CadenaFiltrado = " And MPT_MEDIO_PAGO='CHEQUE' And MPT_UBICACION='EN CAJA' And TDO_ID='" & BCVariablesNames.ProcesosCaja.CajaIngreso & "' And MPT_ESTADO='ACTIVO' And PER_ID_BAN='" & txtPER_ID_DES.Text & "' And CCC_ID='" & txtCCC_ID.Text & "' "
                                MetodoBusquedaDato(dgvDetalle, "", txtPER_ID_DES.Text, False, EtxtMPT_NUMERO_MEDIO, True)
                                If dgvDetalle.RowCount > 0 Then
                                    dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.RowCount - 1).Cells("cDTE_CONTRAVALOR_DOC")
                                End If
                            End If
                    End Select
            End Select
            vBusquedaDesdePagosCobros = False
        End Sub

        Private Sub btnPagosMasivos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPagosMasivos.Click
            vBusquedaDesdePagosCobros = True
            vBCVariablesNamesProcesosCtaCteLiquidacionDocumento = ""
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    If Trim(txtCCT_ID_REC.Text) = "" Then
                        vBCVariablesNamesProcesosCtaCteLiquidacionDocumento = "%%%"
                    Else
                        vBCVariablesNamesProcesosCtaCteLiquidacionDocumento = BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    End If

                    EtxtDTD_ID_DOC_1.pComportamiento = 29
                    EtxtDTD_ID_DOC_1.pMostrarDatosGrid = False
                    EtxtDTD_ID_DOC_1.pSeleccionarTodosEnMarcados = False
                    EtxtDTD_ID_DOC_1.pTotalizarCampo = True
                    EtxtDTD_ID_DOC_1.pNombreCampoTotalizar = "SALDO"

                    EtxtDTD_ID_DOC_1.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLI_REC.Text & "'" ' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
                    MetodoBusquedaDato(dgvDetalle, "", "", False, EtxtDTD_ID_DOC_1, True)
                    EtxtDTD_ID_DOC_1.pComportamiento = 16

                Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                    EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = False
                    EtxtDTD_ID_DOC_CLI_REC.pSeleccionarTodosEnMarcados = True
                    EtxtDTD_ID_DOC_CLI_REC.pTotalizarCampo = True
                    EtxtDTD_ID_DOC_CLI_REC.pNombreCampoTotalizar = "SALDO"

                    If txtCCT_ID.Text = BCVariablesNames.CCT_ID.Remuneraciones Then
                        EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And CCT_ID_REF Like '" & txtCCT_ID.Text & "' "
                    Else
                        EtxtDTD_ID_DOC_CLI_REC.pOOrm.CadenaFiltrado = " And CCT_ID_REF Like '" & txtCCT_ID.Text & "' "
                    End If

                    MetodoBusquedaDato(dgvDetalle, "", "", False, EtxtDTD_ID_DOC_CLI_REC, True)
                    EtxtDTD_ID_DOC_CLI_REC.pMostrarDatosGrid = True
                    EtxtDTD_ID_DOC_CLI_REC.pSeleccionarTodosEnMarcados = False
                    EtxtDTD_ID_DOC_CLI_REC.pTotalizarCampo = False
                    EtxtDTD_ID_DOC_CLI_REC.pNombreCampoTotalizar = ""
                Case Else
            End Select
            vBusquedaDesdePagosCobros = False
        End Sub

        Private Sub bntActualizarObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntActualizarObservaciones.Click
            Dim vFilGrid As Integer = 0
            If dgvDetalle.Rows.Count() > 0 Then
                While (dgvDetalle.Rows.Count() > vFilGrid)
                    With dgvDetalle.Rows(vFilGrid)
                        .Cells("cDTE_OBSERVACIONES").Value = UCase(txtObservaciones.Text)
                    End With
                    vFilGrid += 1
                End While
            End If
        End Sub

        Private Sub btnGenerarOtros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerarOtros.Click
            tcoTipoRecibo.SelectedIndex = 2
            tpaOtros.Focus()
            AgregarFilaGrid()
            dgvDetalleOtros.CurrentCell = dgvDetalleOtros.Rows(dgvDetalleOtros.RowCount - 1).Cells("cMPT_MEDIO_PAGO" & ProcesarIdentificadorGrid(dgvDetalleOtros))
            KeysTab(1)
            dgvDetalleOtros.Rows(dgvDetalleOtros.RowCount - 1).Cells("cDTE_IMPORTE_DOC" & ProcesarIdentificadorGrid(dgvDetalleOtros)).Value = CDbl(txtMontoOtros.Text)
            If rbtPerdida.Checked Then
                MetodoBusquedaDato(dgvDetalleOtros, ProcesarIdentificadorGrid(dgvDetalleOtros), "97994", True, EtxtCUC_ID)
            Else
                MetodoBusquedaDato(dgvDetalleOtros, ProcesarIdentificadorGrid(dgvDetalleOtros), "7793", True, EtxtCUC_ID)
            End If
            tcoTipoRecibo.SelectedIndex = 0
            tpaPagos.Focus()
        End Sub

        Private Sub txtMontoOtros_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMontoOtros.Validated
            If Not IsNumeric(sender.text) Then sender.text = 0
        End Sub


        Private Sub txtTipoCambio_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipoCambio.DoubleClick
            If Not IsNumeric(txtTipoCambio.Text) Then
                Exit Sub
            End If
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    If cboTipoRecibo.Text = "PAGOS" Then
                        If dgvDetalle.Columns.Item(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString = "cDTE_CONTRAVALOR_DOC" Then
                            If dgvDetalle.Item("cMON_ID_DOC", dgvDetalle.CurrentRow.Index).Value <> txtMON_ID_CCC.Text Then
                                dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value = txtTipoCambio.Text
                            End If
                        ElseIf dgvDetalle.Columns.Item(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString = "cDTE_CONTRAVALOR_DOC_1" Then
                            If dgvDetalle.Item("cMON_ID_DOC", dgvDetalle.CurrentRow.Index).Value <> dgvDetalle.Item("cMON_ID_DOC_1", dgvDetalle.CurrentRow.Index).Value Then
                                dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value = txtTipoCambio.Text
                            End If
                        End If
                    End If
            End Select
        End Sub

        Private Sub txtTipoCambio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTipoCambio.TextChanged

        End Sub
    End Class
End Namespace