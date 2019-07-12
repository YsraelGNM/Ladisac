Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Tesoreria.Views
    Public Class frmPrestamo
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
            MetodoBusquedaDato(dgvDetalle, "", txtCCC_ID.Text, False, EtxtCCC_ID)

            BuscarCorrelativoDgv()

            ConfigurarFormulario(dgvDetalle, "", 2)
            cboSerieCorrelativo.Focus()
            txtCCC_ID.Focus()

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


            If pDocumentoProcesandose = 1000 Then Exit Sub
            Dim vProcederImpresion As Boolean = False

            btnImagen.Focus()
            Dim bRes As Boolean = False

            If pRegistroNuevo Then
                txtTES_NUMERO.Text = Me.IBCBusqueda.CorrelativoSerie(cboSerieCorrelativo.Text, txtTDO_ID.Text)
                ActualizarCorrelativoEnDetalle()
            End If

            If Not pRegistroNuevo Then
                If Not RevisarDatos(True) Then
                    If vNuevo Then
                        NuevoRegistro()
                    End If
                    Return
                End If
            End If

            'vItemKardexCtaCte = Me.IBCKardexCtaCte.ItemKardexCtaCte(txtTDO_ID.Text, txtDTD_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)

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
            ProcesarKardexCtaCte()



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

            vRespuestaLocal = IBC.spInsertarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.CCC_ID, Compuesto.PRE_SERIE, Compuesto.PRE_NUMERO, Compuesto.PRE_FECHA_EMI, Compuesto.PVE_ID, Compuesto.PER_ID_CAJ, Compuesto.PRE_MONTO_TOTAL, Compuesto.PRE_TIPO, Compuesto.USU_ID, Compuesto.PRE_FEC_GRAB, Compuesto.PRE_ESTADO)

            If vRespuestaLocal = 0 Then
                InsertarDatos = False
                Return InsertarDatos
            End If

            vRespuestaLocal1 = IBCCorrelativo.spActualizarRegistro(Compuesto3)
            If vRespuestaLocal = 0 Or vRespuestaLocal1 = 0 Then
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

            DatosCabecera()

            ProcesarKardexCtaCte()

            If (Validar(dgvDetalle, "Cabecera")) Then
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
            Me.Cursor = Windows.Forms.Cursors.Default
            If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar
            InicializarOrm()
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean
            pRespuestaExtraerDetalle = ExtraerDetalle()
            ActualizarDatos = (Me.IBC.spActualizarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.CCC_ID, Compuesto.PRE_SERIE, Compuesto.PRE_NUMERO, Compuesto.PRE_FECHA_EMI, Compuesto.PVE_ID, Compuesto.PER_ID_CAJ, Compuesto.PRE_MONTO_TOTAL, Compuesto.PRE_TIPO, Compuesto.USU_ID, Compuesto.PRE_FEC_GRAB, Compuesto.PRE_ESTADO) > 0 And pRespuestaExtraerDetalle = 1)
        End Function
        Public Sub InicializarDatos()
            OrmBusquedaDatos("InicializarDatos")
            pRegistroNuevo = False
            pColeccionDatos = RevisarDatosForm(Nothing, False)
            BuscarCorrelativoDgv()
        End Sub
        Private Sub BuscarCorrelativoDgv()
            Dim vItem As Integer = 0
            ConfigurarGrid(dgvDetalle, "", "ElementoItem", True)
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

            Using Scope As New System.Transactions.TransactionScope()
                If (ProcesarEliminarDetalle() > 0 And Me.IBC.spEliminarRegistro(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.CCC_ID, Compuesto.PRE_SERIE, Compuesto.PRE_NUMERO) > 0) Then
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
            Dim bRes As Boolean = False
            Dim vMensajeMostrar As Int16 = 0
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
        Public Property IBC As Ladisac.BL.IBCPrestamo

        <Dependency()> _
        Public Property IBCDetalle As Ladisac.BL.IBCDetallePrestamo

        <Dependency()> _
        Public Property IBCCorrelativo As Ladisac.BL.IBCCorrelativoTipoDocumento

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        <Dependency()> _
        Public Property IBCRolOpeCtaCte As Ladisac.BL.IBCRolOpeCtaCte

        <Dependency()> _
        Public Property IBCConsultasReportesContabilidad As Ladisac.BL.IBCConsultasReportesContabilidad

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

        Private vColImporteDoc As String = "cDPR_IMPORTE"

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
        Private EchkPRE_TIPO As New chk
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

        Private Compuesto As New Ladisac.BE.Prestamo
        Private Compuesto1 As New Ladisac.BE.DetallePrestamo
        Private Compuesto3 As New Ladisac.BE.CorrelativoTipoDocumento
        Private Compuesto5 As New Ladisac.BE.RolOpeCtaCte
        Private ErrorData As New Ladisac.BE.Prestamo.ErrorData
        Private cMisProcedimientos As New Ladisac.MisProcedimientos
        Private Structure ElementosEliminar
            Public cTDO_ID As String
            Public cDTD_ID As String
            Public cCCC_ID As String
            Public cDTE_SERIE As String
            Public cDTE_NUMERO As String
            Public cDTE_ITEM As String
            Public cPER_ID_BAN As String
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

            'ColocarValoresDefault(chkTES_ASIENTO)
            ColocarValoresDefault(chkTES_ESTADO)

            InicializarValores(txtTES_MONTO_TOTAL, ErrorProvider1, EtxtTES_MONTO_TOTAL.pSoloNumeros, EtxtTES_MONTO_TOTAL.pSoloNumerosDecimales)

            InicializarValores(dgvDetalle, ErrorProvider1)
            InicializarValores(dgvDetalleEntregas, ErrorProvider1)
            InicializarValores(dgvDetalleOtros, ErrorProvider1)
            InicializarValores(dgvDetalleTransferencias, ErrorProvider1)
            ''InicializarValores(dgvKardexCtaCte, ErrorProvider1)
            ''InicializarValores(dgvMovimientoCajaBanco, ErrorProvider1)

            pFlagVerificarRolCtaCte = True
            cboTipoRecibo.Text = "ENTREGAS"
            pFlagVerificarRolCtaCte = False
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
                    txtCCT_ID.Text = BCVariablesNames.CCT_ID.PrestamosPersonal
                    pCCT_ID = BCVariablesNames.CCT_ID.PrestamosPersonal

                    txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.PrestamoPersonalEntregaRendir
                    pDTD_ID = BCVariablesNames.ProcesosCaja.PrestamoPersonalEntregaRendir
            End Select
            pPasandoEntregasAPagos = False
            pCCC_IDpep = ""
            pTDO_IDpep = ""
            pDTD_IDpep = ""
            pTES_SERIEpep = ""
            pTES_NUMEROpep = ""

            CodigoBanco = ""
            CodigoCheque = ""
            SerieCheque = ""
            NumeroCheque = ""
            txtEnlace.Text = ""
            ReDim eRegistrosEliminar(1)
            ReDim eRegistrosEliminarDocumento(1)
            ReDim eRegistrosEliminarDocumento_1(1)
            vBuscarDetalle = True
        End Sub
        '' Siempre para nuevo registro
        Private Sub HabilitarNuevo()
            ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, False)
            ControlVisible(cboSerieCorrelativo, True)
            ConfigurarReadOnlyNoBusqueda(txtTES_NUMERO, EtxtTES_NUMERO, False)
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkTES_ESTADO)
            ProcesarGridVacio(dgvDetalle, 1)
        End Sub

        Private Sub CrearCodigoId()
            ProcesarFechaServidor()

            txtPVE_ID.Text = pPVE_ID
            EtxtPVE_ID.pOOrm.CadenaFiltrado = " And PVE_ID  In (select PVE_ID from vwPuntoVentaDatosUsuarios where USU_ID='" & SessionService.UserId & "' and PDU_ESTADO='ACTIVO')"
            MetodoBusquedaDato(dgvDetalle, "", txtPVE_ID.Text, True, EtxtPVE_ID)


            txtTDO_ID.Text = pTDO_ID
            txtDTD_ID.Text = pDTD_ID

            MetodoBusquedaDato(dgvDetalle, "", pCCT_ID & txtTDO_ID.Text & txtDTD_ID.Text, True, EtxtDTD_ID)

            txtCCC_ID.Text = pCCC_ID
            MetodoBusquedaDato(dgvDetalle, "", txtCCC_ID.Text, True, EtxtCCC_ID)

            BuscarSeries()
        End Sub

        '' Solo en el caso de que el PK de la tabla sea ingresado por el usuario manualmente
        Private Sub HabilitarEscrituraNuevo()
            ControlReadOnly(txtTES_NUMERO, False)
        End Sub
        Private Sub EditarColumnasProcesarAncho(ByRef dgv As DataGridView)
            eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
            ReDim eConfigurarDataGridObjeto.Array(0)

            If cboTipoRecibo.Text = "PAGOS" Then
                If pTDO_ID = BCVariablesNames.ProcesosCaja.VoucherCheque Then
                    eConfigurarDataGridObjeto.Array = {1} ' {7, 11, 23, 29, 30, 31, 32, 41, 49, 50, 53, 55}
                Else
                    eConfigurarDataGridObjeto.Array = {1} '{7, 11, 23, 29, 30, 31, 32, 33, 34, 36, 37, 41, 49, 50, 53, 55}
                End If
            ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                eConfigurarDataGridObjeto.Array = {1} '{7, 11, 23, 29, 30, 31, 32, 33, 34, 36, 37, 41, 49, 50, 53, 55}
            ElseIf cboTipoRecibo.Text = "OTROS" Then
                eConfigurarDataGridObjeto.Array = {1} '{7, 11, 23, 29, 30, 31, 32, 33, 34, 36, 37, 41, 49, 50, 53, 55}
            End If

            ConfigurarGrid(dgv, eConfigurarDataGridObjeto)
        End Sub
        Private Sub MostrarAnchoColumnaGrid(ByRef dgv As DataGridView)
            dgv.Columns(11).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns(11).DefaultCellStyle.BackColor = Drawing.Color.White

            If cboTipoRecibo.Text = "PAGOS" Then
            ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
            ElseIf cboTipoRecibo.Text = "OTROS" Then
                dgv.Columns(52).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                dgv.Columns(52).DefaultCellStyle.BackColor = Drawing.Color.White
            End If
        End Sub

        Public Function AdicionarFilasGridDesDeBusqueda() As Boolean
            AdicionarFilasGridDesDeBusqueda = False
            AdicionarFilasGridDesDeBusqueda = True
            AdicionarFilas(dgvDetalle)
        End Function
        '' ojito
        Public Sub AdicionarFilasGrid()
            If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                AdicionarFilas(dgvDetalle)
            ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                AdicionarFilas(dgvDetalleEntregas)
                MetodoBusquedaDato(dgvDetalleEntregas, ProcesarIdentificadorGrid(dgvDetalleEntregas), pCampoBusquedaEntregasCCT_ID, True, EtxtCCT_IDe)
                MetodoBusquedaDato(dgvDetalleEntregas, ProcesarIdentificadorGrid(dgvDetalleEntregas), pCampoBusquedaEntregasPER_ID_CLI, True, EtxtPER_ID_CLI)
                'MetodoBusquedaDato(dgvDetalleEntregas, ProcesarIdentificadorGrid(dgvDetalleEntregas), pCampoBusquedaEntregasCCO_ID, True, EtxtCCO_ID)
            ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                AdicionarFilas(dgvDetalleOtros)
            End If
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

            Select Case tcoTipoRecibo.SelectedTab.Name
                Case "tpaPagos"
                    If pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte Then
                        pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales
                        txtCCT_ID.Text = pCCT_ID
                        MetodoBusquedaDato(dgv, "", txtCCT_ID.Text, True, EtxtCCT_ID)
                    End If

                Case "tpaEntregas"
                    If pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte Then
                        pCCT_ID = BCVariablesNames.CCT_ID.CxCComerciales
                        txtCCT_ID.Text = pCCT_ID
                        MetodoBusquedaDato(dgv, "", txtCCT_ID.Text, True, EtxtCCT_ID)
                    End If
                    ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
                Case "tpaOtros"
                    ConfigurarFormulario(dgv, vIdentificadorDgv, 2)
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

            Select Case dgv.Name
                Case "dgvDetalleOtros"
                    vcCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte
                    vMON_ID_DOC = txtMON_ID_CCC.Text
                Case "dgvDetalleEntregas"
                    vMON_ID_DOC = txtMON_ID_CCC.Text
                Case Else
                    vcCCT_ID = pCCT_ID
            End Select

            dgv.Rows.Add(EdgvDetalle.Elementos + 1, _
                                txtTDO_ID.Text, _
                                txtDTD_ID.Text, _
                                txtCCC_ID.Text, _
                                txtTES_SERIE.Text, _
                                txtTES_NUMERO.Text,
                                vcCCT_ID, vcCCT_DESCRIPCION, _
                                vMON_ID_DOC, _
                                vcPER_ID_CLI, vcPER_DESCRIPCION_CLI, _
                                vDTE_FEC_VEN, _
                                vDTE_CAPITAL_DOC, vDTE_INTERES_DOC, vDTE_GASTOS_DOC, vDTE_IMPORTE_DOC, 0, _
                                vcTDO_ID_DOC, vcDTD_ID_DOC, vCCT_ID_DOC, vcDTE_SERIE_DOC, vcDTE_NUMERO_DOC, "", _
                                "", "ACTIVO", 0)
            ProcesarGridVacio(dgv)
            EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
            InicializarDatosGrid(dgv, vIdentificadorDgv, False)
            ProcesarAnchoColumnasGrid(dgv, True)
            MostrarAnchoColumnaGrid(dgv)
            PosicionColumnaGrid(dgv, vIdentificadorDgv)

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
            'vcTDO_ID_DOC = txtTDO_ID.Text
            'vcDTD_ID_DOC = txtDTD_ID.Text
            'vCCT_ID_DOC = txtCCT_ID.Text
            'vcDTE_SERIE_DOC = txtTES_SERIE.Text
            'vcDTE_NUMERO_DOC = txtTES_NUMERO.Text
            'vDTE_FEC_VEN = Now
            vMON_ID_DOC = txtMON_ID_CCC.Text
            vMON_DESCRIPCION_DOC = txtMON_DESCRIPCION_CCC.Text

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
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

                            pCampoBusquedaEntregasCCT_ID = vcCCT_ID & dgv.Rows(dgv.Rows.Count() - 1).Cells("cTDO_ID" & vIdentificadorDgv).Value & dgv.Rows(dgv.Rows.Count() - 1).Cells("cDTD_ID" & vIdentificadorDgv).Value
                            pCampoBusquedaEntregasPER_ID_CLI = dgv.Rows(dgv.Rows.Count() - 1).Cells("cPER_ID_CLI" & vIdentificadorDgv).Value

                            vDTE_FEC_VEN = DateAdd(DateInterval.Day, 30, dgv.Rows(dgv.Rows.Count() - 1).Cells("cDPR_FEC_VEN" & vIdentificadorDgv).Value)

                            vDTE_CAPITAL_DOC = dgv.Rows(dgv.Rows.Count() - 1).Cells("cDPR_CAPITAL" & vIdentificadorDgv).Value
                            vDTE_INTERES_DOC = dgv.Rows(dgv.Rows.Count() - 1).Cells("cDPR_INTERES" & vIdentificadorDgv).Value
                            vDTE_GASTOS_DOC = dgv.Rows(dgv.Rows.Count() - 1).Cells("cDPR_GASTOS" & vIdentificadorDgv).Value
                            vDTE_IMPORTE_DOC = dgv.Rows(dgv.Rows.Count() - 1).Cells("cDPR_IMPORTE" & vIdentificadorDgv).Value
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

        Private Sub ConfigurarAdicionFilasGridDetalle(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
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
                        ConfigurarEntregasOtros(dgv, vIdentificadorDgv) '2017-02-02
                        ConfigurarPagos()
                        If Not IsNothing(dgv.CurrentRow) Then FiltroDTD_ID_DOC(dgv, vIdentificadorDgv)
                        vProcesarBusquedaDirectaDocumento = True
                    ElseIf cboTipoRecibo.Text = "ENTREGAS" Or _
                        cboTipoRecibo.Text = "OTROS" Then
                        ConfigurarEntregasOtros(dgv, vIdentificadorDgv)
                    End If
            End Select
        End Sub

        Private Sub EliminarFilasGrid()
            If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                EliminarFilas(dgvDetalle)
                BloquearPerIdCliRec(dgvDetalle)
            ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                EliminarFilas(dgvDetalleEntregas)
            ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                EliminarFilas(dgvDetalleOtros)
            End If
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
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTE_SERIE = .Cells("cDPR_SERIE" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTE_NUMERO = .Cells("cDPR_NUMERO" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTE_ITEM = .Cells("cITEM" & vIdentificadorDgv).Value.ToString()
                            'eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cPER_ID_BAN = .Cells("cPER_ID_BAN" & vIdentificadorDgv).Value.ToString()

                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cTDO_ID = .Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTD_ID = .Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTE_SERIE = .Cells("cDPR_SERIE_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTE_NUMERO = .Cells("cDPR_NUMERO_DOC" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTE_IMPORTE = .Cells("cDPR_IMPORTE" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cDTE_CONTRAVALOR = .Cells("cDPR_CONTRAVALOR" & vIdentificadorDgv).Value.ToString()
                            eRegistrosEliminarDocumento(eRegistrosEliminarDocumento.Count() - 1).cMON_ID = .Cells("cMON_ID" & vIdentificadorDgv).Value.ToString()

                            'eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cTDO_ID = .Cells("cTDO_ID_DOC_1" & vIdentificadorDgv).Value.ToString()
                            'eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTD_ID = .Cells("cDTD_ID_DOC_1" & vIdentificadorDgv).Value.ToString()
                            'eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTE_SERIE = .Cells("cDTE_SERIE_DOC_1" & vIdentificadorDgv).Value.ToString()
                            'eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTE_NUMERO = .Cells("cDTE_NUMERO_DOC_1" & vIdentificadorDgv).Value.ToString()
                            'eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTE_IMPORTE = .Cells("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv).Value.ToString()
                            'eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cDTE_CONTRAVALOR = .Cells("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv).Value.ToString()
                            'eRegistrosEliminarDocumento_1(eRegistrosEliminarDocumento_1.Count() - 1).cMON_ID = .Cells("cMON_ID_DOC_1" & vIdentificadorDgv).Value.ToString()

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
                    Compuesto.PRE_SERIE = vCodigoTES_SERIE
                    Compuesto.PRE_NUMERO = vCodigoTES_NUMERO
                    Compuesto.DTD_ID = vCodigoDTD_ID
                Case "Load"
                    Compuesto.Vista = "PrimerAnterior"
                    Compuesto.TDO_ID = CodigoId
                    Compuesto.CCC_ID = vCodigoCCC_ID
                    Compuesto.PRE_SERIE = vCodigoTES_SERIE
                    Compuesto.PRE_NUMERO = vCodigoTES_NUMERO
                    Compuesto.DTD_ID = vCodigoDTD_ID
                Case "RegistroNoEncontrado" ' ojito
                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    Compuesto.CCC_ID = txtCCC_ID.Text.Trim
                    Compuesto.PRE_SERIE = txtTES_SERIE.Text.Trim
                    Compuesto.PRE_NUMERO = txtTES_NUMERO.Text.Trim
                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim

                    CodigoId = Compuesto.TDO_ID
                    vCodigoCCC_ID = Compuesto.CCC_ID
                    vCodigoTES_SERIE = Compuesto.PRE_SERIE
                    vCodigoTES_NUMERO = Compuesto.PRE_NUMERO
                    vCodigoDTD_ID = Compuesto.DTD_ID
                Case "NavegarFormulario"
                    CodigoId = CodigoId & vCodigoCCC_ID & vCodigoTES_SERIE & vCodigoTES_NUMERO & vCodigoDTD_ID
                Case "EliminarRegistro"
                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim

                    Compuesto.CCC_ID = txtCCC_ID.Text.Trim
                    vCodigoCCC_ID = txtCCC_ID.Text.Trim

                    Compuesto.PRE_SERIE = txtTES_SERIE.Text.Trim
                    vCodigoTES_SERIE = txtTES_SERIE.Text.Trim

                    Compuesto.PRE_NUMERO = txtTES_NUMERO.Text.Trim
                    vCodigoTES_NUMERO = txtTES_NUMERO.Text.Trim

                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim

                    Compuesto.PRE_FECHA_EMI = dtpTES_FECHA_EMI.Value
                    Compuesto.USU_ID = SessionService.UserId
                Case "InicializarDatos"
                    InicializarValores(dgvDetalle, ErrorProvider1)
                    InicializarValores(dgvDetalleEntregas, ErrorProvider1)
                    InicializarValores(dgvDetalleOtros, ErrorProvider1)
                    InicializarValores(dgvDetalleTransferencias, ErrorProvider1)

                    Compuesto.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim

                    Compuesto.CCC_ID = txtCCC_ID.Text.Trim
                    vCodigoCCC_ID = txtCCC_ID.Text.Trim

                    Compuesto.PRE_SERIE = txtTES_SERIE.Text.Trim
                    vCodigoTES_SERIE = txtTES_SERIE.Text.Trim

                    Compuesto.PRE_NUMERO = txtTES_NUMERO.Text.Trim
                    vCodigoTES_NUMERO = txtTES_NUMERO.Text.Trim

                    Compuesto.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim

                    Compuesto1.TDO_ID = txtTDO_ID.Text.Trim

                    Dim vTipoRecibo As String
                    Dim vcontrol As Int16
                    Dim ds As New DataSet

                    vTipoRecibo = BCVariablesNames.ModulosCaja.ReciboIngresoEgreso

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

                    Else
                        cboTipoRecibo.Text = ""
                    End If
                    pLoaded = False
                    FormatearCamposAMostrarEnGrid()
            End Select
        End Sub
        '' ojito
        Public Sub BuscarDetalle()
            Compuesto1.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()

            'Dim ds As New DataSet
            'Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, CodigoId, vCodigoDTD_ID, vCodigoCCC_ID, vCodigoTES_SERIE, vCodigoTES_NUMERO, Nothing))
            'Dim vcontrol As Int16 = sr.Peek

            'If vcontrol <> -1 Then
            '    ds.ReadXml(sr)
            '    Dim x As Int32 = 0
            '    Dim y As Int32 = 0
            '    dgvDetalle.Rows.Clear()
            '    If (ds.Tables(0).Rows.Count > 0) Then
            '        While (x < ds.Tables(0).Rows.Count)
            '            If x = 0 Then
            '                txtCCT_ID.Text = ds.Tables(0).Rows(x).Item("Cta.Cte.").ToString()
            '                txtCCT_DESCRIPCION.Text = ds.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
            '                Me.Text += " - " & ds.Tables(0).Rows(x).Item("Desc.Cta.Cte.").ToString()
            '                pCCT_ID = txtCCT_ID.Text
            '                FiltroCCT_ID()
            '            End If
            '            dgvDetalle.Rows.Add()
            '            With ds.Tables(0).Rows(x)
            '                While y < ds.Tables(0).Columns.Count
            '                    dgvDetalle.Item(y, dgvDetalle.Rows.Count - 1).Value = Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
            '                    y = y + 1
            '                End While
            '                y = 0
            '            End With
            '            x += 1
            '        End While
            '    Else
            '        MsgBox("No se encontro registros", MsgBoxStyle.Information)
            '    End If
            '    CalcularMontoDocumento()
            'Else
            '    dgvDetalle.DataSource = Nothing
            'End If

            ''
            Compuesto1.Vista = "ListarRegistros"
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
            FormatearCamposAMostrarEnGrid()
        End Sub
        Private Sub FormatearCamposAMostrarEnGrid()
            RemoverTabs(tcoTipoRecibo, tpaTransferencias)
            tcoTipoRecibo.SelectedTab = tpaEntregas
            ConfigurarCampoVisualizarGridDetalle(dgvDetalleEntregas, "e")
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
            Return ProcesarMovimientoCajaBanco
        End Function
        Private Sub ProcesarKardexCtaCte()
        End Sub
        Private Function ProcesarKardexCtaCtePlanillaRendicionCuentas() As Boolean
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
                        .Cells("cDPR_NUMERO" & vIdentificadorDgv).Value = txtTES_NUMERO.Text
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

            If dgvDetalle.Rows.Count = 0 And _
                       dgvDetalleEntregas.Rows.Count = 0 And _
                       dgvDetalleOtros.Rows.Count = 0 Then
                InicializarOrmDetalle()
                MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                Return ProcesarDatosDetalle
            End If
            vContadorDgv = 1
            vFlagProcesarContadorDgv = True

            While vContadorDgv <= 4
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
                        Compuesto1.DPR_SERIE = txtTES_SERIE.Text
                        Compuesto1.DPR_NUMERO = txtTES_NUMERO.Text

                        If Trim(.Cells("cCCT_ID" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.CCT_ID = Nothing
                        Else
                            Compuesto1.CCT_ID = .Cells("cCCT_ID" & vIdentificadorDgv).Value
                        End If

                        Compuesto1.MON_ID = .Cells("cMON_ID" & vIdentificadorDgv).Value
                        Compuesto1.DPR_ITEM = CDbl(.Cells("cITEM" & vIdentificadorDgv).Value)

                        If Trim(.Cells("cPER_ID_CLI" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.PER_ID_CLI = Nothing
                        Else
                            Compuesto1.PER_ID_CLI = .Cells("cPER_ID_CLI" & vIdentificadorDgv).Value
                        End If

                        If Trim(.Cells("cDPR_FEC_VEN" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DPR_FEC_VEN = Now
                        Else
                            Compuesto1.DPR_FEC_VEN = Format(.Cells("cDPR_FEC_VEN" & vIdentificadorDgv).Value.ToString, "Short Date")
                        End If


                        Compuesto1.DPR_CAPITAL = CDbl(.Cells("cDPR_CAPITAL" & vIdentificadorDgv).Value)
                        Compuesto1.DPR_INTERES = CDbl(.Cells("cDPR_INTERES" & vIdentificadorDgv).Value)
                        Compuesto1.DPR_GASTOS = CDbl(.Cells("cDPR_GASTOS" & vIdentificadorDgv).Value)

                        Compuesto1.DPR_IMPORTE = CDbl(.Cells("cDPR_IMPORTE" & vIdentificadorDgv).Value)
                        Compuesto1.DPR_CONTRAVALOR = CDbl(.Cells("cDPR_CONTRAVALOR" & vIdentificadorDgv).Value)

                        Compuesto1.DPR_OBSERVACIONES = .Cells("cDPR_OBSERVACIONES" & vIdentificadorDgv).Value

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
                        If Trim(.Cells("cDPR_SERIE_DOC" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DPR_SERIE_DOC = Nothing
                        Else
                            Compuesto1.DPR_SERIE_DOC = .Cells("cDPR_SERIE_DOC" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cDPR_NUMERO_DOC" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.DPR_NUMERO_DOC = Nothing
                        Else
                            Compuesto1.DPR_NUMERO_DOC = .Cells("cDPR_NUMERO_DOC" & vIdentificadorDgv).Value
                        End If
                        If Trim(.Cells("cPER_ID_CLI_DOC" & vIdentificadorDgv).Value) = "" Then
                            Compuesto1.PER_ID_CLI_DOC = Nothing
                        Else
                            Compuesto1.PER_ID_CLI_DOC = .Cells("cPER_ID_CLI_DOC" & vIdentificadorDgv).Value
                        End If

                        Compuesto1.USU_ID = SessionService.UserId
                        Compuesto1.DPR_FEC_GRAB = Now
                        Compuesto1.DPR_ESTADO = DevolverTiposCampos(chkTES_ESTADO)

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
                        'If (.Cells("cEstadoRegistro" & vIdentificadorDgv).Value = 1 Or .Cells("cEstadoRegistro" & vIdentificadorDgv).Value = True) Then
                        '    ProcesarDatosDetalle = IBCDetalle.spActualizarRegistro(Compuesto1.TDO_ID, Compuesto1.DTD_ID, Compuesto1.CCC_ID, Compuesto1.DPR_SERIE, Compuesto1.DPR_NUMERO, Compuesto1.CCT_ID, Compuesto1.MON_ID, Compuesto1.DPR_ITEM, Compuesto1.PER_ID_CLI, Compuesto1.DPR_FEC_VEN, Compuesto1.DPR_CAPITAL, Compuesto1.DPR_INTERES, Compuesto1.DPR_GASTOS, Compuesto1.DPR_IMPORTE, Compuesto1.DPR_CONTRAVALOR, Compuesto1.DPR_OBSERVACIONES, Compuesto1.TDO_ID_DOC, Compuesto1.DTD_ID_DOC, Compuesto1.CCT_ID_DOC, Compuesto1.DPR_SERIE_DOC, Compuesto1.DPR_NUMERO_DOC, Compuesto1.PER_ID_CLI_DOC, Compuesto1.USU_ID, Compuesto1.DPR_FEC_GRAB, Compuesto1.DPR_ESTADO)
                        '    If ProcesarDatosDetalle = 0 Then
                        '        vMensajeErrorOrm = Compuesto1.vMensajeError & " En fila: " & vFilGrid + 1
                        '        Exit Function
                        '    End If
                        'Else
                        ProcesarDatosDetalle = IBCDetalle.spInsertarRegistro(Compuesto1.TDO_ID, Compuesto1.DTD_ID, Compuesto1.CCC_ID, Compuesto1.DPR_SERIE, Compuesto1.DPR_NUMERO, Compuesto1.CCT_ID, Compuesto1.MON_ID, Compuesto1.DPR_ITEM, Compuesto1.PER_ID_CLI, Compuesto1.DPR_FEC_VEN, Compuesto1.DPR_CAPITAL, Compuesto1.DPR_INTERES, Compuesto1.DPR_GASTOS, Compuesto1.DPR_IMPORTE, Compuesto1.DPR_CONTRAVALOR, Compuesto1.DPR_OBSERVACIONES, Compuesto1.TDO_ID_DOC, Compuesto1.DTD_ID_DOC, Compuesto1.CCT_ID_DOC, Compuesto1.DPR_SERIE_DOC, Compuesto1.DPR_NUMERO_DOC, Compuesto1.PER_ID_CLI_DOC, Compuesto1.USU_ID, Compuesto1.DPR_FEC_GRAB, Compuesto1.DPR_ESTADO)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto1.vMensajeError & " En fila: " & vFilGrid + 1
                            Exit Function
                        End If
                        'End If

                        ' Fin DetalleTesoreria

                    End With
                    vFilGrid += 1
                End While
                '''

                vContadorDgv += 1
            End While

            Return ProcesarDatosDetalle
        End Function
        Private Function EliminarMovimientoCajaBanco(ByVal vItem As Integer)
            EliminarMovimientoCajaBanco = 0
            EliminarMovimientoCajaBanco = 1
            Return EliminarMovimientoCajaBanco
        End Function
        Private Function EliminarMovimientoCajaBancopep(ByVal vItem As Integer)
            EliminarMovimientoCajaBancopep = 0
            EliminarMovimientoCajaBancopep = 1
            Return EliminarMovimientoCajaBancopep
        End Function
        Private Function EliminarKardexCtaCte(ByVal vItem As Integer)
            EliminarKardexCtaCte = 0
            EliminarKardexCtaCte = 1
            Return EliminarKardexCtaCte
        End Function
        Private Function EliminarKardexCtaCtepep(ByVal vItem As Integer)
            EliminarKardexCtaCtepep = 0
            EliminarKardexCtaCtepep = 1
            Return EliminarKardexCtaCtepep
        End Function
        Private Function EliminarRegistroDetalle() As Int16
            EliminarRegistroDetalle = 0
            vMensajeErrorOrm = ""
            InicializarOrmDetalle()

            EliminarRegistroDetalle = Me.IBCDetalle.spEliminarRegistroGeneral(txtTDO_ID.Text, txtDTD_ID.Text, txtCCC_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)
            If EliminarRegistroDetalle = 0 Then
                vMensajeErrorOrm = Compuesto1.vMensajeError
            Else
                EliminarRegistroDetalle = 1
            End If
            Return EliminarRegistroDetalle

            'EliminarRegistroDetalle = 0
            'If eRegistrosEliminar.Count = 2 Then
            '    EliminarRegistroDetalle = 1
            'Else
            '    If eRegistrosEliminar.Count - 2 < 1 Then
            '        EliminarRegistroDetalle = 1
            '        Exit Function
            '    End If
            '    For fila = 1 To eRegistrosEliminar.Count - 2
            '        vMensajeErrorOrm = ""
            '        InicializarOrmDetalle()

            '        EliminarRegistroDetalle = 1 'Me.IBCMedioPago.spEliminarRegistro(eRegistrosEliminar(fila).cTDO_ID, eRegistrosEliminar(fila).cDTD_ID, eRegistrosEliminar(fila).cCCC_ID, eRegistrosEliminar(fila).cDTE_SERIE, eRegistrosEliminar(fila).cDTE_NUMERO, eRegistrosEliminar(fila).cDTE_ITEM)
            '        If EliminarRegistroDetalle = 0 Then
            '            'vMensajeErrorOrm = Compuesto2.vMensajeError
            '            Exit For
            '        End If

            '        EliminarRegistroDetalle = Me.IBCDetalle.spEliminarRegistro(eRegistrosEliminar(fila).cTDO_ID, eRegistrosEliminar(fila).cDTD_ID, eRegistrosEliminar(fila).cCCC_ID, eRegistrosEliminar(fila).cDTE_SERIE, eRegistrosEliminar(fila).cDTE_NUMERO, eRegistrosEliminar(fila).cDTE_ITEM)
            '        If EliminarRegistroDetalle = 0 Then
            '            vMensajeErrorOrm = Compuesto1.vMensajeError
            '            Exit For
            '        End If
            '    Next
            'End If
            'Return EliminarRegistroDetalle
        End Function
        Private Function ActualizarUbicacionCheques()
            ActualizarUbicacionCheques = 1
            Return ActualizarUbicacionCheques
        End Function
        Private Sub DatosCabecera()
            Compuesto.TDO_ID = Strings.Trim(txtTDO_ID.Text)
            Compuesto.DTD_ID = Strings.Trim(txtDTD_ID.Text)
            Compuesto.CCC_ID = Strings.Trim(txtCCC_ID.Text)
            Compuesto.PRE_SERIE = Strings.Trim(txtTES_SERIE.Text)
            Compuesto.PRE_NUMERO = Strings.Trim(txtTES_NUMERO.Text)
            Compuesto.PRE_FECHA_EMI = dtpTES_FECHA_EMI.Value
            Compuesto.PVE_ID = Strings.Trim(txtPVE_ID.Text)
            Compuesto.PER_ID_CAJ = Strings.Trim(txtPER_ID_CAJ.Text)
            Compuesto.PRE_MONTO_TOTAL = CDbl(txtTES_MONTO_TOTAL.Text)
            Compuesto.PRE_TIPO = DevolverTiposCampos(chkPRE_TIPO)
            Compuesto.USU_ID = SessionService.UserId
            Compuesto.PRE_FEC_GRAB = Now
            Compuesto.PRE_ESTADO = DevolverTiposCampos(chkTES_ESTADO)

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.VoucherCheque
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
                    resp.rM = Compuesto.ColocarErrores(txtTES_SERIE, Compuesto.VerificarDatos("PRE_SERIE"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTES_NUMERO, Compuesto.VerificarDatos("PRE_NUMERO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpTES_FECHA_EMI, Compuesto.VerificarDatos("PRE_FECHA_EMI"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPVE_ID, Compuesto.VerificarDatos("PVE_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID_CAJ, Compuesto.VerificarDatos("PER_ID_CAJ"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTES_MONTO_TOTAL, Compuesto.VerificarDatos("PRE_MONTO_TOTAL"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkPRE_TIPO, Compuesto.VerificarDatos("PRE_TIPO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(pnCuerpo, Compuesto.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(btnImagen, Compuesto.VerificarDatos("PRE_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkTES_ESTADO, Compuesto.VerificarDatos("PRE_ESTADO"), ErrorProvider1)
                Case "Detalle"
                    resp.rM = Compuesto1.ColocarErrores(dgv, _
                                              Compuesto1.VerificarDatos("TDO_ID",
                                                                        "DTD_ID",
                                                                        "CCC_ID",
                                                                        "DPR_SERIE",
                                                                        "DPR_NUMERO",
                                                                        "CCT_ID",
                                                                        "MON_ID",
                                                                        "DPR_ITEM",
                                                                        "PER_ID_CLI",
                                                                        "DPR_FEC_VEN",
                                                                        "DPR_CAPITAL",
                                                                        "DPR_INTERES",
                                                                        "DPR_GASTOS",
                                                                        "DPR_IMPORTE",
                                                                        "DPR_CONTRAVALOR",
                                                                        "DPR_OBSERVACIONES",
                                                                        "TDO_ID_DOC",
                                                                        "DTD_ID_DOC",
                                                                        "CCT_ID_DOC",
                                                                        "DPR_SERIE_DOC",
                                                                        "DPR_NUMERO_DOC",
                                                                        "PER_ID_CLI_DOC",
                                                                        "USU_ID",
                                                                        "DPR_FEC_GRAB",
                                                                        "DPR_ESTADO"), _
                                              ErrorProvider1, vFila)
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


                    If cboTipoRecibo.Text = "ENTREGAS" Or _
                                vNombreDgv = "Entregas" Then
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
                            pTDO_ID = BCVariablesNames.ProcesosCaja.PrestamoPersonal Then
                            resp.rM = False
                            If ErrorProvider1.GetError(dgv) = "" Then
                                ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en el código de cliente, debe tener 6 carácteres, fila: " & vFila)
                            Else
                                ErrorProvider1.SetError(dgv, "Debe de ingresar un CÓDIGO en el código de cliente, debe tener 6 carácteres" & Chr(13) & ErrorProvider1.GetError(dgv))
                            End If
                        End If
                    End If

                    If Not resp.rM Then
                        ErrorProvider1.SetError(tcoTipoRecibo, "Error en: " & vNombreDgv)
                    Else
                        ErrorProvider1.SetError(tcoTipoRecibo, Nothing)
                    End If
            End Select
            Return vrO
        End Function
        Private Sub InicializarOrm()
            InicializarOrmDetalle()
            InicializarOrmMovimientoCajaBanco()
            InicializarOrmKardexCtaCte()
            FiltrarCompuesto()
        End Sub
        Private Sub InicializarOrmDetalle()
        End Sub
        Private Sub InicializarOrmMovimientoCajaBanco()
        End Sub
        Private Sub InicializarOrmKardexCtaCte()
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
                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & _
                                                             "' And PER_ID_CAJ='" & pPER_ID_CAJ & _
                                                             "' And PVE_ID='" & pPVE_ID & "' " & _
                                                             " And CCC_ESTADO='ACTIVO' "
                    If Not pRegistroNuevo Then BuscarSeries()
                Case 3 ' RolOpeCtaCte
                    FiltrarCompuesto()
                    FiltroCCT_ID()
                Case 4 ' CajaCtaCte
                    If pRegistroNuevo Then BuscarSeries()
                Case 8  ' Cliente
                    FiltroDTD_ID_DOC(dgv, vIdentificadorDgv)
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
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
                    If Not pRegistroNuevo Then
                        If cboTipoRecibo.Text = "ENTREGAS" Then
    
                        Else

                        End If
                    Else

                    End If
            End Select
        End Sub
        Private Sub FiltroDTD_ID_DOC(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            EtxtDTD_ID_DOC.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & dgv.Item("cPER_ID_CLI" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
        End Sub
        Private Sub FiltroDTD_ID_DOC_1(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            EtxtDTD_ID_DOC_1.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & dgv.Item("cPER_ID_CLI_1" & vIdentificadorDgv, dgv.CurrentRow.Index).Value & "'" ' And CCT_ID_REF Like '" & txtCCT_ID.Text & "'"
        End Sub

        Private Sub FiltroDTE_IMPORTE_DOC(ByRef dgv As DataGridView, ByVal vIdentificadoDgv As String)
            Select Case pDTD_ID_DOC
                Case BCVariablesNames.ProcesosCompras.PrePersonal
                    ConfigurarColumnasGrid(dgv, "cDPR_IMPORTE", True, True, vIdentificadoDgv)
                Case Else
                    ConfigurarColumnasGrid(dgv, "cDPR_IMPORTE", False, True, vIdentificadoDgv)
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

        Private Function EliminarDetalle(ByVal oOrm As DetallePrestamo) As Int16
            EliminarDetalle = 0

            EliminarDetalle = 1 'Me.IBCMedioPago.spEliminarRegistroGeneral(Compuesto.TDO_ID, Compuesto.DTD_ID, Compuesto.CCC_ID, Compuesto.PRE_SERIE, Compuesto.PRE_NUMERO)
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
            EliminarKardexCtaCteDetracciones = 1
            Return EliminarKardexCtaCteDetracciones
        End Function

        Private Function EliminarDetallepep(ByVal oOrm As DetallePrestamo) As Int16
            EliminarDetallepep = 0

            EliminarDetallepep = 1 'Me.IBCMedioPago.spEliminarRegistroGeneral(pTDO_IDpep, pDTD_IDpep, pCCC_IDpep, pTES_SERIEpep, pTES_NUMEROpep)
            If EliminarDetallepep = 0 Then Return EliminarDetallepep

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
                'ConfigurarGrid(dgvDetalle, "", "Load")

                If Comportamiento = -1 Then BusquedaDatos("Load")
                FormatearCampos()
                ConfigurarFormulario(dgvDetalleEntregas, "e", 1)
                If pComportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If

                pLoaded = True
                cboTipoRecibo.Text = "ENTREGAS"
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

            lblCCC_ID_DES.Enabled = vBoolean2
            lblCCC_ID_DES.Visible = vBoolean2
            txtCCC_ID_DES.Enabled = vBoolean2
            txtCCC_ID_DES.Visible = vBoolean2
            txtCCC_DESCRIPCION_DES.Enabled = vBoolean2
            txtCCC_DESCRIPCION_DES.Visible = vBoolean2
            txtPER_ID_DES.Enabled = vBoolean2
            txtPER_ID_DES.Visible = vBoolean2



            txtObservaciones.Enabled = vBoolean3
            txtObservaciones.Visible = vBoolean3

            bntActualizarObservaciones.Enabled = vBoolean3
            bntActualizarObservaciones.Visible = vBoolean3


        End Sub
        Private Sub MostrarDataGridView()
            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
                    tcoTipoRecibo.Visible = True
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)
                    RemoverTabs(tcoTipoRecibo, tpaOtros)
                    RemoverTabs(tcoTipoRecibo, tpaPagos)
                    tcoTipoRecibo.SelectedIndex = 0
                    dgvDetalle.Visible = True
                    dgvDetalleEntregas.Visible = True
                    dgvDetalleOtros.Visible = True
                    dgvDetalleTransferencias.Visible = False
                    ConfigurarDatos("tpaEntregas")

                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
                    tcoTipoRecibo.Visible = True
                    RemoverTabs(tcoTipoRecibo, tpaTransferencias)
                    RemoverTabs(tcoTipoRecibo, tpaOtros)
                    RemoverTabs(tcoTipoRecibo, tpaPagos)
                    tcoTipoRecibo.SelectedIndex = 0
                    dgvDetalle.Visible = True
                    dgvDetalleEntregas.Visible = True
                    dgvDetalleOtros.Visible = True
                    dgvDetalleTransferencias.Visible = False
                    ConfigurarDatos("tpaEntregas")
                    DatosGenerarOtros(True)
            End Select
            DeshabilitarHabilitar_REC()
        End Sub
        Private Sub DatosGenerarOtros(ByVal Habilitar As Boolean)

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
        End Sub

        Private Sub AdicionarElementoCombosEdicion()
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
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
                    EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And ROC_TIPO='" & cboTipoRecibo.Text & "' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.ReciboIngresoEgreso & "'"
            End Select

            EtxtCCC_ID.pOOrm = New Ladisac.BE.CajaCtaCte
            EtxtCCC_ID.pComportamiento = 4
            EtxtCCC_ID.pOrdenBusqueda = 5
            EtxtCCC_ID.pMostrarDatosGrid = True
            EtxtCCC_ID.pOOrm.pBuscarRegistros = False
            EtxtCCC_ID.pOOrm.Vista = "BuscarRegistrosCajero"
            EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & _
                                                     "' And PER_ID_CAJ='" & pPER_ID_CAJ & _
                                                     "' And PVE_ID='" & pPVE_ID & "' " & _
                                                     " And CCC_ESTADO='ACTIVO' "

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
            EtxtPER_ID_CLI.pOOrm.pBuscarRegistros = False
            EtxtPER_ID_CLI.pOOrm.Vista = "BuscarRegistrosPersonal"


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

            EtxtDTD_ID_DOC_1.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
            EtxtDTD_ID_DOC_1.pComportamiento = 16
            EtxtDTD_ID_DOC_1.pOrdenBusqueda = 0
            EtxtDTD_ID_DOC_1.pOOrm.pBuscarRegistros = False
            EtxtDTD_ID_DOC_1.pOOrm.Vista = "spSaldoDocumentoMontoNoCero"

            EtxtDTD_ID_ROC.pOOrm = New Ladisac.BE.RolOpeCtaCte
            EtxtDTD_ID_ROC.pComportamiento = 19
            EtxtDTD_ID_ROC.pOrdenBusqueda = 2
            EtxtDTD_ID_ROC.pOOrm.CadenaFiltrado = " And TDO_ID = '" & pTDO_ID & "' AND DTD_ID not in ('" & BCVariablesNames.ProcesosCtaCte.SinDocumentoPlaRenCtas & "','" & BCVariablesNames.ProcesosCtaCte.ReembolsoPlaRenCtas & "')"

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


            EchkPRE_TIPO = EchkTemporal
            EchkPRE_TIPO.pNombreCampo = "PRE_TIPO"
            EchkPRE_TIPO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkPRE_TIPO)

            EchkTES_ESTADO = EchkTemporal
            EchkTES_ESTADO.pNombreCampo = "PRE_ESTADO"
            EchkTES_ESTADO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkTES_ESTADO)
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkPRE_TIPO"
                    Compuesto.CampoId = EchkPRE_TIPO.pNombreCampo
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
                Case "chkPRE_TIPO"
                    vObjetoChk.pValorDefault = EchkPRE_TIPO.pValorDefault
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
        Handles _
        chkTES_ESTADO.CheckedChanged, chkPRE_TIPO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkPRE_TIPO"
                    If EchkPRE_TIPO.pFormatearTexto Then
                        InicializarTextoCheck(EchkPRE_TIPO)
                    End If
                Case "chkTES_ESTADO"
                    If EchkTES_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkTES_ESTADO)
                    End If
            End Select
        End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "PRE_TIPO"
                    With chkPRE_TIPO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PRE_ESTADO"
                    With chkTES_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTextoCheck(EchkPRE_TIPO)
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
            EdgvDetalle.pArrayCamposPkDetalle(3) = "cDPR_IMPORTE"

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
                    eConfigurarDataGridObjeto.Array = {1} '{7, 11, 23, 24, 29, 30, 31, 32, 33, 34, 37, 41, 49, 50, 53, 55}
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
                                ValidarImporteTransferenciaEntreCajas(sender, vIdentificadorDgv, sender.Item("cDPR_IMPORTE" & vIdentificadorDgv, sender.CurrentRow.Index).Value)
                                If Trim(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) <> "" Then
                                    sender.CurrentCell = sender.Rows(sender.CurrentRow.Index).Cells("cDPR_IMPORTE" & vIdentificadorDgv)
                                End If
                            End If
                    End Select
                Case "cPER_ID_CLI" & vIdentificadorDgv
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtPER_ID_CLI.pBusqueda Then

                                EtxtPER_ID_CLI.pOOrm = New Ladisac.BE.Personas
                                EtxtPER_ID_CLI.pComportamiento = 8
                                EtxtPER_ID_CLI.pOrdenBusqueda = 4
                                EtxtPER_ID_CLI.pOOrm.pBuscarRegistros = False
                                EtxtPER_ID_CLI.pOOrm.Vista = "BuscarRegistrosPersonal"

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
                                                sender.CurrentCell = sender.Rows(sender.CurrentRow.Index).Cells("cDPR_IMPORTE" & vIdentificadorDgv)
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

                                EtxtPER_ID_CLI_1.pOOrm = New Ladisac.BE.Personas
                                EtxtPER_ID_CLI_1.pComportamiento = 15
                                EtxtPER_ID_CLI_1.pOrdenBusqueda = 4

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
            If vDesdeKeyDown Then dgv.CurrentCell = dgv.Rows(dgv.CurrentRow.Index).Cells("cDPR_IMPORTE" & vIdentificadorDgv)
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
                                                           sender.CurrentRow.Cells("cDPR_SERIE_DOC").Value.ToString & _
                                                           sender.CurrentRow.Cells("cDPR_NUMERO_DOC").Value.ToString
                        frmConsulta.MaximizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case "cMON_ID" & vIdentificadorDgv
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

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                     BCVariablesNames.ProcesosCaja.PrestamoPersonal,
                     BCVariablesNames.ProcesosCaja.DepositoTercero,
                     BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                     BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                    If tcoTipoRecibo.SelectedTab.Name = "tpaPagos" Then
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaEntregas" Then
                        EtxtCCT_IDe.pBusqueda = True
                    ElseIf tcoTipoRecibo.SelectedTab.Name = "tpaOtros" Then
                    End If
                Case BCVariablesNames.ProcesosCaja.DetraccionesNotaCargoCtaBanco,
                     BCVariablesNames.ProcesosCaja.VoucherCheque,
                     BCVariablesNames.ProcesosCaja.PlanillaEgreso
                    If cboTipoRecibo.Text = "PAGOS" Then
                    ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                    ElseIf cboTipoRecibo.Text = "OTROS" Then
                    End If
                Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                    If cboTipoRecibo.Text = "PAGOS" Then
                    ElseIf cboTipoRecibo.Text = "OTROS" Then
                    End If
            End Select
        End Sub
        Private Sub dgvDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvDetalle.CellEnter, dgvDetalleEntregas.CellEnter, dgvDetalleOtros.CellEnter, dgvDetalleTransferencias.CellEnter
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(sender)
            ConfigurarColumnasGrid(sender, "cDPR_IMPORTE", False, True, vIdentificadorDgv)

            Select Case pTDO_ID
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
                    If cboTipoRecibo.Text = "PAGOS" Then
                        If Not EtxtDTD_ID_DOC.pBusqueda Then
                            If sender.name = "dgvDetalleEntregas" Then
                                ConfigurarColumnasGrid(sender, "cDPR_IMPORTE", False, True, vIdentificadorDgv)
                            ElseIf sender.name = "dgvDetalleOtros" Then
                                ConfigurarColumnasGrid(sender, "cDPR_IMPORTE", False, True, vIdentificadorDgv)
                            Else
                                ConfigurarColumnasGrid(sender, "cDPR_IMPORTE", True, True, vIdentificadorDgv)
                            End If
                        End If
                    End If
                    If cboTipoRecibo.Text = "ENTREGAS" Then
                    End If
            End Select

            'ValidarMedioPago(sender, vIdentificadorDgv)
            'ValidarDiferido(sender, vIdentificadorDgv)
            'ValidarUbicacion(sender, vIdentificadorDgv)
            'ValidarFechaDiferido(sender, vIdentificadorDgv)

            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                Case "cPER_ID_CLI" & vIdentificadorDgv
                    EtxtPER_ID_CLI.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cDPR_IMPORTE" & vIdentificadorDgv
                    EtxtDTE_IMPORTE_DOC.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cCCT_ID" & vIdentificadorDgv
                    If "cCCT_ID" & vIdentificadorDgv = "cCCT_IDe" Then EtxtCCT_ID.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
            End Select
        End Sub
        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvDetalle.CellValidated, dgvDetalleEntregas.CellValidated, dgvDetalleOtros.CellValidated, dgvDetalleTransferencias.CellValidated
            Dim vIdentificadorDgv As String
            vIdentificadorDgv = ProcesarIdentificadorGrid(sender)

            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                Case "cPER_ID_CLI" & vIdentificadorDgv
                    sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = cMisProcedimientos.VerificarLongitud(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, 6)
                    EtxtPER_ID_CLI.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                    ValidarDatos(sender, vIdentificadorDgv, EtxtPER_ID_CLI, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, True, sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtPER_ID_CLI.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                    EtxtPER_ID_CLI.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value
                Case "cDPR_FEC_VEN" & vIdentificadorDgv
                    If Not IsDate(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = Now
                    End If
                Case "cDPR_CAPITAL" & vIdentificadorDgv
                    If Not IsNumeric(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                    End If
                    If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value < 0 Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value * -1
                    End If
                    sender.Item("cDPR_IMPORTE" & vIdentificadorDgv, sender.CurrentRow.Index).Value = _
                        CDbl(sender.Item("cDPR_CAPITAL" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDPR_INTERES" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDPR_GASTOS" & vIdentificadorDgv, sender.CurrentRow.Index).Value)
                Case "cDPR_INTERES" & vIdentificadorDgv
                    If Not IsNumeric(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                    End If
                    If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value < 0 Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value * -1
                    End If
                    sender.Item("cDPR_IMPORTE" & vIdentificadorDgv, sender.CurrentRow.Index).Value = _
                        CDbl(sender.Item("cDPR_CAPITAL" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDPR_INTERES" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDPR_GASTOS" & vIdentificadorDgv, sender.CurrentRow.Index).Value)
                Case "cDPR_GASTOS" & vIdentificadorDgv
                    If Not IsNumeric(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                    End If
                    If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value < 0 Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value * -1
                    End If
                    sender.Item("cDPR_IMPORTE" & vIdentificadorDgv, sender.CurrentRow.Index).Value = _
                        CDbl(sender.Item("cDPR_CAPITAL" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDPR_INTERES" & vIdentificadorDgv, sender.CurrentRow.Index).Value) + _
                        CDbl(sender.Item("cDPR_GASTOS" & vIdentificadorDgv, sender.CurrentRow.Index).Value)
                Case "cDPR_IMPORTE" & vIdentificadorDgv
                    Dim vProcesarValidarImporte As Boolean = True
                    If Not IsNumeric(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value) Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                    End If
                    ' ojo todos los ingresos/egresos son positivos
                    If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value < 0 Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value * -1
                    End If
                    If cboTipoRecibo.Text = "PAGOS" Then
                        If sender.name = "dgvDetalleTransferencias" Then
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
                    If vProcesarValidarImporte Then
                        EtxtDTE_IMPORTE_DOC.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                        ValidarImporte(sender, vIdentificadorDgv, EtxtDTE_IMPORTE_DOC, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString, True)
                        EtxtDTE_IMPORTE_DOC.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                        EtxtDTE_IMPORTE_DOC.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    Else
                        If sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value <= 0 Then
                            sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = 0
                            sender.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, sender.CurrentRow.Index).Value = 0
                        End If
                        Select Case pTDO_ID
                        End Select
                    End If
                    ValidarMedioPago(sender, vIdentificadorDgv)
                Case "cCCT_ID" & vIdentificadorDgv
                    If "cCCT_ID" & vIdentificadorDgv = "cCCT_IDe" Then
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = cMisProcedimientos.VerificarLongitud(sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value, 3)
                        sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString.ToUpper
                        EtxtCCT_IDe.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                        ValidarDatos(sender, vIdentificadorDgv, EtxtCCT_IDe, sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString, True)
                        EtxtCCT_IDe.pTexto1 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                        EtxtCCT_IDe.pTexto2 = sender.Item(sender.CurrentCell.ColumnIndex, sender.CurrentRow.Index).Value.ToString
                    End If
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
                    sender.Item("cDTE_SERIE_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cDPR_SERIE" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                    sender.Item("cDTE_NUMERO_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cDPR_NUMERO" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                    sender.Item("cDTE_IMPORTE_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cDPR_IMPORTE" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                    sender.Item("cDTE_CONTRAVALOR_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, sender.CurrentRow.Index).Value
                    sender.Item("cMON_ID_DOC_1" & vIdentificadorDgv, sender.CurrentRow.Index).Value = sender.Item("cMON_ID" & vIdentificadorDgv, sender.CurrentRow.Index).Value
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
                    MetodoBusquedaDato(dgv, vIdentificadorDgv, texto, BusquedaDirecta, otxt)
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

                            dgv.CurrentCell = dgv.Rows(dgv.CurrentRow.Index).Cells("cDPR_IMPORTE" & vIdentificadorDgv)
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
            EdtpTemporal.pNombreCampo = "PRE_FECHA_EMI"
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

            FormatearCampos(txtTES_SERIE, "PRE_SERIE", EtxtTES_SERIE)
            FormatearCampos(txtTES_NUMERO, "PRE_NUMERO", EtxtTES_NUMERO)

            FormatearCampos(txtPER_ID_CAJ, "PER_ID_CAJ", EtxtPER_ID_CAJ)

            FormatearCampos(txtTES_MONTO_TOTAL, "PRE_MONTO_TOTAL", EtxtTES_MONTO_TOTAL, False)

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
                txtCCC_ID_DES.Validated

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
                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & _
                                                             "' And PER_ID_CAJ='" & pPER_ID_CAJ & _
                                                             "' And PVE_ID='" & pPVE_ID & "' " & _
                                                             " And CCC_ESTADO='ACTIVO' "
                    ValidarDatos(EtxtCCC_ID, txtCCC_ID)
                    EtxtCCC_ID.pOOrm.CadenaFiltrado = " And CCC_TIPO='" & pCCC_TIPO & _
                                                             "' And PER_ID_CAJ='" & pPER_ID_CAJ & _
                                                             "' And PVE_ID='" & pPVE_ID & "' " & _
                                                             " And CCC_ESTADO='ACTIVO' "
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
            ConfigurarColumnasGrid(dgv, "cDPR_SERIE", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_NUMERO", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCT_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDPR_FEC_VEN", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_IMPORTE", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_CONTRAVALOR", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_SERIE_DOC", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_NUMERO_DOC", False, True, vIdentificadorDgv)



            ConfigurarColumnasGrid(dgv, "cDPR_OBSERVACIONES", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_ESTADO", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cEstadoRegistro", False, True, vIdentificadorDgv)
        End Sub
        Private Sub CampoGridDetalleDefault(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ConfigurarColumnasGrid(dgv, "cItem", True, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cTDO_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCC_ID", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_SERIE", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_NUMERO", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cCCT_ID", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cMON_ID", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_DESCRIPCION_CLI", True, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_FEC_VEN", False, True, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDPR_CAPITAL", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_INTERES", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_GASTOS", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDPR_IMPORTE", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_CONTRAVALOR", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_SERIE_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_NUMERO_DOC", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cPER_ID_CLI_DOC", True, False, vIdentificadorDgv)

            ConfigurarColumnasGrid(dgv, "cDPR_OBSERVACIONES", False, True, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cDPR_ESTADO", True, False, vIdentificadorDgv)
            ConfigurarColumnasGrid(dgv, "cEstadoRegistro", True, False, vIdentificadorDgv)
        End Sub



        Private Sub ConfigurarCampoVisualizarGridDetalle(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            CampoGridDetalleDefault(dgv, vIdentificadorDgv)
            CampoGridDetalleReciboEgresos(dgv, vIdentificadorDgv)
        End Sub



        Private Sub CampoGridDetalleReciboEgresos(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            ''***
            ''CampoGridDetalleDefault(dgv, vIdentificadorDgv)
            ''Exit Sub

            'ConfigurarColumnasGrid(dgv, "cCCT_ID", True, True, vIdentificadorDgv)
            'ConfigurarColumnasGrid(dgv, "cCCT_DESCRIPCION", True, True, vIdentificadorDgv)

            'ConfigurarColumnasGrid(dgv, "cDPR_FEC_VEN", False, True, vIdentificadorDgv)

            'ConfigurarColumnasGrid(dgv, "cTDO_ID_DOC", True, False, vIdentificadorDgv)

            'ConfigurarColumnasGrid(dgv, "cCCT_ID_DOC", True, False, vIdentificadorDgv)


            If cboTipoRecibo.Text = "PAGOS" Then
            ElseIf cboTipoRecibo.Text = "ENTREGAS" Then
                'ConfigurarColumnasGrid(dgv, "cDPR_IMPORTE", False, True, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDPR_CONTRAVALOR", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cMON_ID", True, False, vIdentificadorDgv)

                'ConfigurarColumnasGrid(dgv, "cDTD_ID_DOC", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDPR_SERIE_DOC", True, False, vIdentificadorDgv)
                'ConfigurarColumnasGrid(dgv, "cDPR_NUMERO_DOC", True, False, vIdentificadorDgv)
            ElseIf cboTipoRecibo.Text = "OTROS" Then
            End If

            'ConfigurarColumnasGrid(dgv, "cDPR_ESTADO", True, False, vIdentificadorDgv)
        End Sub

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
                    Try
                        pPER_ID_CLI = dgv.CurrentRow.Cells("cPER_ID_CLI" & vIdentificadoDgv).Value
                        pPER_DESCRIPCION_CLI = dgv.CurrentRow.Cells("cPER_DESCRIPCION_CLI" & vIdentificadoDgv).Value
                    Catch ex As Exception
                        pPER_ID_CLI = ""
                        pPER_DESCRIPCION_CLI = ""
                    End Try
                Else
                    If cboTipoRecibo.Text = "OTROS" Then
                    Else
                        pPER_ID_CLI = ""
                        pPER_DESCRIPCION_CLI = ""
                        pPER_ID_CLI_1 = ""
                        pPER_DESCRIPCION_CLI_1 = ""
                    End If
                End If
            Else
            dgv.Rows(dgv.RowCount - 1).Cells("cPER_ID_CLI" & vIdentificadoDgv).Value = pPER_ID_CLI
            dgv.Rows(dgv.RowCount - 1).Cells("cPER_DESCRIPCION_CLI" & vIdentificadoDgv).Value = pPER_DESCRIPCION_CLI
                If cboTipoRecibo.Text = "PAGOS" Then
                    Select Case dgv.Name
                        Case "dgvDetalleOtros", "dgvDetalleEntregas"
                            dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDPR_IMPORTE" & vIdentificadoDgv)
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
                    dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDPR_IMPORTE" & vIdentificadoDgv)
                End If
                pPosicionColumnaGridNombre = "cDPR_IMPORTE" & vIdentificadoDgv

                VerificarBloqueoCampoCliente(dgv, vIdentificadoDgv, dgv.RowCount - 1)
                FiltroDTD_ID_DOC(dgv, vIdentificadoDgv)
            End If
        End Sub

        Private Sub VerificarBloqueoCampoClienteTransferencias(ByVal vfila As Int16)
            VerificarBloqueoCampoCliente1Transferencias(vfila)
            If IsNothing(dgvDetalleTransferencias.CurrentRow) Then
                Exit Sub
            End If
            If dgvDetalleTransferencias.RowCount <> 1 Then
                dgvDetalleTransferencias.Item("cPER_ID_CLIt", vfila).ReadOnly = True
                EtxtPER_ID_CLI.pBusqueda = False
            Else
                txtPER_ID_CLI_REC.Text = dgvDetalle.Item("cPER_ID_CLIt", vfila).Value
                dgvDetalleTransferencias.Item("cPER_ID_CLIt", vfila).ReadOnly = False
                EtxtPER_ID_CLI.pBusqueda = True
            End If
        End Sub

        Private Sub VerificarBloqueoCampoCliente1Transferencias(ByVal vFila As Int16)
            If IsNothing(dgvDetalleTransferencias.CurrentRow) Then
                txtPER_ID_CLI_REC.ReadOnly = False
                EtxtPER_ID_CLI_REC.pBusqueda = True
                txtPER_ID_CLI_REC.Text = dgvDetalleTransferencias.Item("cPER_ID_CLIt", vFila).Value
            End If
            If dgvDetalleTransferencias.RowCount <> 1 Then
                txtPER_ID_CLI_REC.ReadOnly = True
                EtxtPER_ID_CLI_REC.pBusqueda = False
            Else
                txtPER_ID_CLI_REC.ReadOnly = False
                EtxtPER_ID_CLI_REC.pBusqueda = True
            End If
        End Sub

        Private Sub VerificarBloqueoCampoCliente(ByRef dgv As DataGridView, ByVal vIdentificadoDgv As String, ByVal vfila As Int16)
            VerificarBloqueoCampoCliente1(dgv, vIdentificadoDgv, vfila)
            If IsNothing(dgv.CurrentRow) Then
                Exit Sub
            End If
            If dgv.RowCount <> 1 Then
                If pTDO_ID = BCVariablesNames.ProcesosCaja.DepositoTercero Then
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
                dgv.Item("cPER_ID_CLI" & vIdentificadoDgv, vfila).ReadOnly = False
                EtxtPER_ID_CLI.pBusqueda = True
            End If
        End Sub

        Private Sub VerificarBloqueoCampoCliente1(ByRef dgv As DataGridView, ByVal vIdentificadoDgv As String, ByVal vFila As Int16)
            If IsNothing(dgv.CurrentRow) Then
                txtPER_ID_CLI_REC.ReadOnly = False
                EtxtPER_ID_CLI_REC.pBusqueda = True
            End If
            BloquearPerIdCliRec(dgv)
        End Sub
        Private Sub BloquearPerIdCliRec(ByVal dgv As DataGridView)
            If IsNothing(dgv) Then
                txtPER_ID_CLI_REC.ReadOnly = False
                EtxtPER_ID_CLI_REC.pBusqueda = True
            ElseIf IsNothing(dgv.CurrentRow) Then
                txtPER_ID_CLI_REC.ReadOnly = False
                EtxtPER_ID_CLI_REC.pBusqueda = True
            Else
                If SessionService.ReciboEgresoPlanilla Then
                    txtPER_ID_CLI_REC.ReadOnly = False
                    EtxtPER_ID_CLI_REC.pBusqueda = True
                Else
                    txtPER_ID_CLI_REC.ReadOnly = True
                    EtxtPER_ID_CLI_REC.pBusqueda = False
                End If
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
            Select Case tcoTipoRecibo.SelectedTab.Name
                Case "tpaPagos"
                    If pTDO_ID = BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco Or
                       pTDO_ID = BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco Or
                       pTDO_ID = BCVariablesNames.ProcesosCaja.PrestamoPersonal Or
                       pTDO_ID = BCVariablesNames.ProcesosCaja.VoucherCheque Then
                        dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDPR_IMPORTE" & vIdentificadorDgv)
                    Else
                        dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells(pPosicionColumnaGridNombre)
                    End If
                Case "tpaEntregas"
                    dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells(pPosicionColumnaGridNombre)
                Case "tpaOtros"
                    dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDPR_IMPORTE" & vIdentificadorDgv)
                Case "tpaTransferencias"
                    If Trim(dgv.CurrentRow.Cells("cCCC_ID_CLI" & vIdentificadorDgv).Value) <> "" Then
                        dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cDPR_IMPORTE" & vIdentificadorDgv)
                    Else
                        dgv.CurrentCell = dgv.Rows(dgv.RowCount - 1).Cells("cCCC_ID_CLI" & vIdentificadorDgv)
                    End If
            End Select
        End Sub

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
                vTotalEfectivo += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                vTes_Monto_Total += CDbl(dgvDetalle.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
            Next

            vIdentificadorDgv = ProcesarIdentificadorGrid(dgvDetalleEntregas)
            vFilasGrid = dgvDetalleEntregas.RowCount
            For vFilas = 0 To vFilasGrid - 1
                vTotalEfectivo += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                vTes_Monto_Total += CDbl(dgvDetalleEntregas.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
            Next

            vIdentificadorDgv = ProcesarIdentificadorGrid(dgvDetalleOtros)
            vFilasGrid = dgvDetalleOtros.RowCount
            For vFilas = 0 To vFilasGrid - 1
                vSignoCuentaContable = 0
                vSignoCuentaContable = 0
                vTotalEfectivo += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
                If dgvDetalle.Rows.Count = 0 And _
                   dgvDetalleEntregas.Rows.Count = 0 Then
                    vTes_Monto_Total += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value) '* vSignoCuentaContable
                Else
                    vTes_Monto_Total += CDbl(dgvDetalleOtros.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value) * vSignoCuentaContable
                End If
            Next

            vIdentificadorDgv = ProcesarIdentificadorGrid(dgvDetalleTransferencias)
            vFilasGrid = dgvDetalleTransferencias.RowCount
            For vFilas = 0 To vFilasGrid - 1
                vTotalEfectivo += CDbl(dgvDetalleTransferencias.Item(vColImporteDoc & vIdentificadorDgv, vFilas).Value)
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
                   dgv.Item("cDPR_SERIE_DOC" & vIdentificadorDgv, vFilas).Value = vTES_SERIE And _
                   dgv.Item("cDPR_NUMERO_DOC" & vIdentificadorDgv, vFilas).Value = vTES_NUMERO And _
                   (dgv.Item("cEstadoRegistro" & vIdentificadorDgv, vFilas).Value = 0 Or dgv.Item("cEstadoRegistro" & vIdentificadorDgv, vFilas).Value = vEstadoRegistro) Then

                    If vMon_Id = txtMON_ID_CCC.Text Then
                        VerificarMontoDocumento += CDbl(dgv.Item("cDPR_IMPORTE" & vIdentificadorDgv, vFilas).Value)
                    Else
                        VerificarMontoDocumento += CDbl(dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, vFilas).Value)
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
                   dgvDetalle.Item("cDPR_SERIE_DOC", vFilas).Value = vTES_SERIE And _
                   dgvDetalle.Item("cDPR_NUMERO_DOC", vFilas).Value = vTES_NUMERO And _
                   dgvDetalle.Item("cEstadoRegistro", vFilas).Value = 0 Then
                    VerificarMontoDocumentoDetalle += CDbl(dgvDetalle.Item("cDPR_IMPORTE", vFilas).Value)
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
                    EtxtDTE_IMPORTE_DOC.pOOrm.vCCT_ID_REF = txtCCT_ID.Text

                    EtxtDTE_IMPORTE_DOC.pOOrm.vTDO_ID = dgv.CurrentRow.Cells("cTDO_ID_DOC" & vIdentificadorDgv).Value.ToString
                    EtxtDTE_IMPORTE_DOC.pOOrm.vDTD_ID = dgv.CurrentRow.Cells("cDTD_ID_DOC" & vIdentificadorDgv).Value.ToString
                    EtxtDTE_IMPORTE_DOC.pOOrm.vDOC_SERIE = dgv.CurrentRow.Cells("cDPR_SERIE_DOC" & vIdentificadorDgv).Value.ToString
                    EtxtDTE_IMPORTE_DOC.pOOrm.vDOC_NUMERO = dgv.CurrentRow.Cells("cDPR_NUMERO_DOC" & vIdentificadorDgv).Value.ToString
                    EtxtDTE_IMPORTE_DOC.pOOrm.vDOCUMENTO = pTDO_ID & txtDTD_ID.Text & txtTES_SERIE.Text & txtTES_NUMERO.Text

                    EtxtDTE_IMPORTE_DOC.pOOrm.vProcesarAnticipoPorCobrar = True

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

                End If
            End If
            Return 0
        End Function
        Private Function ValidarImporteTransferenciaEntreCajas(ByRef dgv As DataGridView, ByVal vIdentificadorGrid As String, ByVal texto As String)
            If dgv.Name = "dgvDetalleOtros" Then Exit Function
            If Trim(dgv.Item("cCCC_ID_CLI" & vIdentificadorGrid, dgv.CurrentRow.Index).Value) = "" Then
                MensajeError("Ingrese la cuenta de caja a donde se realizara la transferencia.")
                dgv.Item("cDPR_IMPORTE" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
                dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
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
            vDTE_SERIE = dgv.CurrentRow.Cells("cDPR_SERIE_DOC" & vIdentificadorGrid).Value.ToString
            vDTE_NUMERO = dgv.CurrentRow.Cells("cDPR_NUMERO_DOC" & vIdentificadorGrid).Value.ToString

            vMON_ID = dgv.CurrentRow.Cells("cMON_ID" & vIdentificadorGrid).Value.ToString
            vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)

            dgv.Item("cDPR_IMPORTE" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
            dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0

            Select Case ProcesarCambioTipoMonedaDoc(dgv, vIdentificadorGrid, pDatoBusqueda, _
                                                    vTDO_ID, vDTD_ID, _
                                                    vDTE_SERIE, vDTE_NUMERO, _
                                                    vMON_ID, vCambiarMonedaSaldo, _
                                                    False, False)
                Case 1
                    MensajeError(dgv.Item("cMON_DESCRIPCION_DOC" & vIdentificadorGrid, dgv.CurrentRow.Index).Value & " - No existe tipo de cambio para el día : " & dtpTES_FECHA_EMI.Text)
                    dgv.Item("cDPR_IMPORTE" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
                    dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorGrid, dgv.CurrentRow.Index).Value = 0
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
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
                    CajaIngreso(dgv, vIdentificadoDgv, vControl)
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
                        ConfigurarReadOnlyNoBusqueda(cboTipoRecibo, EcboTipoRecibo, True) ' FALSE
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
                    BuscarSeries()
                    If cboSerieCorrelativo.Text <> vSerie Then
                        cboSerieCorrelativo.DataSource = Nothing
                        cboSerieCorrelativo.Items.AddRange(New Object() {vSerie})
                        txtTES_SERIE.Text = vSerie
                        txtTES_NUMERO.Text = vNumero
                    End If
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
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
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
                dgv.Item("cDPR_IMPORTE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = vDTE_IMPORTE
                dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = 0
            ElseIf vFlagImporteContravalor = 1 Then
                dgv.Item("cDPR_IMPORTE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE * vCambiarMonedaSaldo
                dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
            ElseIf vFlagImporteContravalor = 2 Then
                dgv.Item("cDPR_IMPORTE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE / vCambiarMonedaSaldo
                dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
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
                dgv.Item("cDPR_IMPORTE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vImporteTemporal / vCambiarMonedaSaldo
                dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
            ElseIf vFlagImporteContravalor = 4 Then
                dgv.Item("cDPR_IMPORTE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
                dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE / vCambiarMonedaSaldo
            ElseIf vFlagImporteContravalor = 5 Then
                dgv.Item("cDPR_IMPORTE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
                dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
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
                dgv.Item("cDPR_IMPORTE" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
                    vDTE_IMPORTE
                dgv.Item("cDPR_CONTRAVALOR" & vIdentificadorDgv, dgv.CurrentRow.Index).Value = _
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
            ElseIf vFlagImporteContravalor = 1 Then
            ElseIf vFlagImporteContravalor = 2 Then
            ElseIf vFlagImporteContravalor = 3 Then
                Dim vImporteTemporal As Double = 0
                vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo
                vMON_ID = txtMON_ID_CCC.Text
                vCambiarMonedaSaldo = CambiarMonedaSaldo(vMON_ID)
                If vCambiarMonedaSaldo = 0 Then
                    ProcesarCambioTipoMonedaDoc_1 = 1
                    Exit Function
                End If
            ElseIf vFlagImporteContravalor = 4 Then
            ElseIf vFlagImporteContravalor = 5 Then
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
            End If
            ProcesarCambioTipoMonedaDoc_1 = 0
        End Function
        Public Function DevolverMontoCambioTipoMoneda(ByVal vDTE_IMPORTE As Double, _
                                                      ByVal vMON_ID As String, ByVal vCambiarMonedaSaldo As Double) As Double
            DevolverMontoCambioTipoMoneda = 0
            If vDTE_IMPORTE < 0 Then
                DevolverMontoCambioTipoMoneda = 2
                Exit Function
            End If

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
                dgvDetalle.Item("cDPR_IMPORTE", dgvDetalle.CurrentRow.Index).Value = VerificarImporte.Importe
                dgvDetalle.Item("cDPR_CONTRAVALOR", dgvDetalle.CurrentRow.Index).Value = VerificarImporte.ContraValor
            Else
                VerificarImporte.Importe = dgvDetalle.Item("cDPR_IMPORTE", dgvDetalle.CurrentRow.Index).Value
                ''' MIker
                '''
                If dgvDetalle.Item("cMON_ID", dgvDetalle.CurrentRow.Index).Value <> dgvDetalle.Item("cMON_ID_DOC_1", dgvDetalle.CurrentRow.Index).Value Then
                    If dgvDetalle.Item("cDPR_CONTRAVALOR", dgvDetalle.CurrentRow.Index).Value = 0 Then
                        VerificarImporte.ContraValor = DevolverContraValorCambioTipoMonedaMON_ID_DOC(VerificarImporte.Importe, _
                                                                       vVerificarMon_Id.Mon_Id, _
                                                                       vVerificarMon_Id.CambiarMonedaSaldo)
                    Else
                        VerificarImporte.ContraValor = dgvDetalle.Item("cDPR_CONTRAVALOR", dgvDetalle.CurrentRow.Index).Value
                    End If

                Else
                    VerificarImporte.ContraValor = dgvDetalle.Item("cDPR_CONTRAVALOR", dgvDetalle.CurrentRow.Index).Value
                End If
                ''
                ''''VerificarImporte.ContraValor = dgvDetalle.Item("cDPR_CONTRAVALOR", dgvDetalle.CurrentRow.Index).Value
            End If

            Return VerificarImporte
        End Function

        Public Function DevolverContraValorCambioTipoMonedaMON_ID_DOC(ByVal vDTE_IMPORTE As Double, _
                                                                      ByVal vMON_ID As String, ByVal vCambiarMonedaSaldo As Double) As Double
            DevolverContraValorCambioTipoMonedaMON_ID_DOC = 0
            Dim vImporteTemporal As Double = 0
            If dgvDetalle.Item("cMON_ID", dgvDetalle.CurrentRow.Index).Value <> BCVariablesNames.MonedaSistema Then
                vCambiarMonedaSaldo = CambiarMonedaSaldo(dgvDetalle.Item("cMON_ID", dgvDetalle.CurrentRow.Index).Value)
                vImporteTemporal = vDTE_IMPORTE * vCambiarMonedaSaldo
                DevolverContraValorCambioTipoMonedaMON_ID_DOC = vImporteTemporal
            Else
                vCambiarMonedaSaldo = CambiarMonedaSaldo(dgvDetalle.Item("cMON_ID", dgvDetalle.CurrentRow.Index).Value)
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
            Else
            End If

            Return VerificarImporteEntregas
        End Function
        Private Sub MensajeError(ByVal vMensaje As String)
            MsgBox(vMensaje, MsgBoxStyle.Exclamation, Me.Text)
        End Sub

        Private Sub ValidarMedioPago(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
            If pFlagGrabando Then Return
            If dgv Is Nothing Then Return

            If VerificarMedioPagoDebeSerDocumento(dgv, vIdentificadorDgv) Then
            Else
            End If

            ValidarUbicacion(dgv, vIdentificadorDgv, True)
            CalcularMontoDocumento()
        End Sub

        Private Sub ValidarDiferido(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
        End Sub
        Private Sub ValidarUbicacion(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String, Optional ByVal vBloquearInicializarColumnasGrid As Boolean = False)
        End Sub

        Private Sub ConfigurarVisualizarDatosMedioPago(ByRef dgv As DataGridView, ByVal IdentificadorDgv As String, ByVal vSoloLectura As Boolean)
        End Sub

        Private Sub ConfigurarVisualizarDatosMedioPagoDocumentoRetencionIGV(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
        End Sub

        Private Sub ValidarFechaDiferido(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String)
        End Sub

        Private Function VerificarMedioPagoDebeSerDocumento(ByRef dgv As DataGridView, ByVal vIdentificadorDgv As String) As Boolean
            Try
                VerificarMedioPagoDebeSerDocumento = False
                Return VerificarMedioPagoDebeSerDocumento
            Catch ex As Exception
                MsgBox(ex.Message & " -  " & Err.Number)
            End Try
        End Function

        Public Function EsLiquidacionDocumento() As Boolean
            EsLiquidacionDocumento = False
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
                           Chr(13) & Chr(13) & Compuesto3.vMensajeError, _
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
            EtxtDTD_ID.pOOrm.CadenaFiltrado = " And TDO_ID Like '" & pTDO_ID & "' And ROC_TIPO='" & cboTipoRecibo.Text & "' And ROC_MODULO='" & BCVariablesNames.ModulosCaja.ReciboIngresoEgreso & "'"

            If pFlagVerificarCajaCtaCte Then
                Select Case cboTipoRecibo.Text
                    Case "PAGOS"
                        txtCCT_ID.Text = BCVariablesNames.CCT_ID.CxPComerciales
                        pCCT_ID = BCVariablesNames.CCT_ID.CxPComerciales

                        txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso
                        pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso
                    Case "ENTREGAS"
                        txtCCT_ID.Text = BCVariablesNames.CCT_ID.PrestamosPersonal
                        pCCT_ID = BCVariablesNames.CCT_ID.PrestamosPersonal

                        txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.PrestamoPersonalEntregaRendir
                        pDTD_ID = BCVariablesNames.ProcesosCaja.PrestamoPersonalEntregaRendir
                    Case "OTROS"
                        txtCCT_ID.Text = BCVariablesNames.CCT_ID.SinCtaCte
                        pCCT_ID = BCVariablesNames.CCT_ID.SinCtaCte

                        txtDTD_ID.Text = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso
                        pDTD_ID = BCVariablesNames.ProcesosCaja.ReciboEgresoCajaEgreso
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

                        vSaldo = vSaldoDocumento / vCambiarMonedaSaldo
                    End If
                End If
            End If
            Return vSaldo
        End Function

        Private Sub btnBuscarPagosCobros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPagosCobros.Click
            vBCVariablesNamesProcesosCtaCteLiquidacionDocumento = ""
            vBusquedaDesdePagosCobros = True
 
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
                Case BCVariablesNames.ProcesosCaja.PrestamoPersonal
                    oReporte.DataDefinition.FormulaFields("Ocultar").Text = "True"
                Case Else
                    Exit Sub
            End Select

            If pRegistroNuevo Then
                MsgBox("Debe grabar el documento para poder imprimirlo", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Me.Text)
                Exit Sub
            End If

            Dim CadenaVista As String = ""
            Dim ds As New DataSet
            CadenaVista = IBCMaestro.EjecutarVista("dbo.spImpresionReciboTesoreriaNuevo1Xml", txtTDO_ID.Text, txtDTD_ID.Text, txtCCC_ID.Text, txtTES_SERIE.Text, txtTES_NUMERO.Text)
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
            Select Case vNombreTabPage
                Case "tpaPagos"
                    HabilitarDatos("Pagos", True)
                    HabilitarDatos("Entregas", False)
                    HabilitarDatos("Otros", False)
                    HabilitarDatos("Transferencias", False)
                Case "tpaEntregas"
                    HabilitarDatos("Pagos", False)
                    HabilitarDatos("Entregas", True)
                    HabilitarDatos("Otros", False)
                    HabilitarDatos("Transferencias", False)
                Case "tpaOtros"
                    HabilitarDatos("Pagos", False)
                    HabilitarDatos("Entregas", False)
                    HabilitarDatos("Otros", True)
                    HabilitarDatos("Transferencias", False)
                Case "tpaTransferencias"
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
        

        Public Sub MostrarControlesConsulta()
            btnImpresion.Enabled = False
            btnImpresion.Focus()
        End Sub





        Private Sub bntActualizarObservaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntActualizarObservaciones.Click
            Dim vFilGrid As Integer = 0
            If dgvDetalle.Rows.Count() > 0 Then
                While (dgvDetalle.Rows.Count() > vFilGrid)
                    With dgvDetalle.Rows(vFilGrid)
                        .Cells("cDPR_OBSERVACIONES").Value = UCase(txtObservaciones.Text)
                    End With
                    vFilGrid += 1
                End While
            End If
        End Sub



        Private Sub txtMontoOtros_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Not IsNumeric(sender.text) Then sender.text = 0
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


    End Class
End Namespace