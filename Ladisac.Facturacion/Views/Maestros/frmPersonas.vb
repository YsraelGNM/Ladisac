Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Maestros.Views
    Public Class frmPersonas

#Region "Primaria 1"
        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        Private eConfigurarDataGridObjeto As New MisProcedimientos.ConfigurarDataGrid
        Private eRegistrosEliminarDocIdentidad(1) As ElementosEliminar
        Private eRegistrosEliminarDireccionPersona(1) As ElementosEliminar
        Private eRegistrosEliminarContactoPersona(1) As ElementosEliminar
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

#Region "DatagridView"
        Private Sub KeysTab(Optional ByVal Saltos As Integer = 1)
            For vSaltos = 1 To Saltos
                SendKeys.Send(Chr(Keys.Tab))
            Next
        End Sub
#End Region
#End Region

#Region "Secundaria 1"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCPersonas As Ladisac.BL.IBCPersona

        <Dependency()> _
        Public Property IBCDireccionesPersonas As Ladisac.BL.IBCDireccionesPersonas

        <Dependency()> _
        Public Property IBCDocPersonas As Ladisac.BL.IBCDocPersonas

        <Dependency()> _
        Public Property IBCContactoPersona As Ladisac.BL.IBCContactoPersona

        <Dependency()> _
        Public Property IBCRolPersonaTipoPersona As Ladisac.BL.IBCRolPersonaTipoPersona

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        Private pNombreFormulario As New Ladisac.Foundation.Views.ViewManMaster
        Private pLLamadaDesdeFormularioCrear As Boolean
        Private pLLamadaDesdeFormularioModificar As Boolean

        ' DataGridView
        Private EdgvDocIdentidad As New dgv
        Private EdgvDireccionPersona As New dgv
        Private EdgvContactoPersona As New dgv

        Private EchkPER_CLIENTE As New chk
        Private EchkPER_PROVEEDOR As New chk
        Private EchkPER_TRANSPORTISTA As New chk
        Private EchkPER_TRABAJADOR As New chk
        Private EchkPER_BANCO As New chk
        Private EchkPER_GRUPO As New chk
        Private EchkPER_CONTACTO As New chk
        Private EchkPER_PROMOCIONES As New chk
        Private EchkPER_REP_LEGAL As New chk
        Private EchkPER_FIRMA_AUT As New chk
        Private EchkPER_LINEA_CREDITO_ESTADO As New chk
        Private EchkPER_ESTADO As New chk

        Private EcboPER_CLIENTE_OP_CON As New cbo
        Private EcboPER_PROVEEDOR_OP_CON As New cbo
        Private EcboPER_TRANSPORTISTA_OP_CON As New cbo
        Private EcboPER_TRABAJADOR_OP_CON As New cbo
        Private EcboPER_BANCO_OP_CON As New cbo
        Private EcboPER_GRUPO_OP_CON As New cbo
        Private EcboPER_CONTACTO_OP_CON As New cbo
        Private EcboPER_TRANSP_PROPIO As New cbo
        Private EcboPER_FORMA_VENTA As New cbo
        Private EcboPER_DIASEM_PAGO As New cbo
        Private EcboPER_COND_DIASEM As New cbo
        Private EcboPER_DOC_PAGO As New cbo
        Private EcboPER_CARTA_FIANZA As New cbo

        Private EtxtPER_ID As New txt
        Private EtxtPER_APE_PAT As New txt
        Private EtxtPER_APE_MAT As New txt
        Private EtxtPER_NOMBRES As New txt
        Private EtxtPER_BREVETE As New txt
        Private EtxtPER_TELEFONOS As New txt
        Private EtxtPER_EMAIL As New txt
        Private EtxtPER_PAGINA_WEB As New txt
        Private EtxtPER_LINEA_CREDITO As New txt
        Private EtxtPER_DIAS_CREDITO As New txt
        Private EtxtPER_DIAMES_PAGO As New txt
        Private EtxtPER_HORA_PAGO As New txt
        Private EtxtPER_OBSERVACIONES As New txt
        Private EtxtPER_CARGO As New txt

        Private EtxtPER_ID_VEN As New txt
        Private EtxtPER_ID_COB As New txt
        Private EtxtPER_ID_TRA As New txt
        Private EtxtPER_ID_BAN As New txt
        Private EtxtPER_ID_GRU As New txt
        Private EtxtCCC_ID_CLI As New txt

        Private EtxtDIS_ID As New txt

        Private vTipoCliente As String = ""
        Private vVerificarExisteRolPersonaTipoPersona As Integer = 0
        Private vBuscarDocIdentidadPersona As Boolean = True
        Private vBuscarDireccionPersona As Boolean = True
        Private vBuscarContactoPersona As Boolean = True
        Private vBuscarTipoCliente As Boolean = True

        Private Simple As New Ladisac.BE.Personas
        Private Simple1 As New Ladisac.BE.DireccionesPersonas
        Private Simple2 As New Ladisac.BE.DocPersonas
        Private Simple3 As New Ladisac.BE.RolPersonaTipoPersona
        Private Simple4 As New Ladisac.BE.TipoDocPersonas
        Private Simple5 As New Ladisac.BE.ContactoPersona
        Private Simple6 As New Ladisac.BE.PersonaDocumento

        Public vNuevo As Boolean = True

        Private ErrorData As New Ladisac.BE.Personas.ErrorData

        Private cMisProcedimientos As New Ladisac.MisProcedimientos

        Public Structure LLamadaDesdeFormularioDatos
            Public Shared Property pPer_Id As String
            Public Shared Property pPer_Id_Tra As String ' Transportista
            Public Shared Property pTipoPersonaCrear As String
            Public Shared Property pNombreMostrarTipoPersonaCrear As String
            Public Shared Property pEsChofer As Boolean
            Public Shared Property pCargando As Boolean = True
            Public Shared Property pTipoVentaDescripcion As String
            Public Shared Property pProcesoBotonesEdicion As String
        End Structure

        Public Property LlamadaDesdeFormularioCrear As Boolean
            Get
                Return pLLamadaDesdeFormularioCrear
            End Get
            Set(ByVal value As Boolean)
                pLLamadaDesdeFormularioCrear = value
            End Set
        End Property

        Public Property LlamadaDesdeFormularioModificar As Boolean
            Get
                Return pLLamadaDesdeFormularioModificar
            End Get
            Set(ByVal value As Boolean)
                pLLamadaDesdeFormularioModificar = value
            End Set
        End Property

        Public Property NombreFormulario() As Object
            Set(ByVal value As Object)
                pNombreFormulario = value
            End Set
            Get
                Return pNombreFormulario
            End Get
        End Property

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

#Region "DataGridView"
        Private Sub ConfigurarDataGridView()
            EdgvDocIdentidad.pAnchoColumna = 20
            EdgvDocIdentidad.pBloquearPk = True
            EdgvDocIdentidad.pColorColumna = Drawing.Color.Black
            EdgvDocIdentidad.pCampoEstadoRegistro = "cEstadoRegistro"
            EdgvDocIdentidad.pMetodoColumnas = True
            EdgvDocIdentidad.Elementos = 1
            ReDim EdgvDocIdentidad.pArrayCamposPkDetalle(1)
            EdgvDocIdentidad.pArrayCamposPkDetalle(1) = "cART_ID_IMP"

            dgvDocIdentidad.AllowUserToAddRows = False
            dgvDocIdentidad.AllowUserToDeleteRows = False
            dgvDocIdentidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
                                Or System.Windows.Forms.AnchorStyles.Bottom) _
                                Or System.Windows.Forms.AnchorStyles.Left) _
                                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDocIdentidad.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDocIdentidad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDocIdentidad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            EdgvDireccionPersona.pAnchoColumna = 20
            EdgvDireccionPersona.pBloquearPk = True
            EdgvDireccionPersona.pColorColumna = Drawing.Color.Black
            EdgvDireccionPersona.pCampoEstadoRegistro = "cEstadoRegistro1"
            EdgvDireccionPersona.pMetodoColumnas = True
            EdgvDireccionPersona.Elementos = 1
            ReDim EdgvDireccionPersona.pArrayCamposPkDetalle(1)
            EdgvDireccionPersona.pArrayCamposPkDetalle(1) = "cART_ID_IMP"

            dgvDireccionPersona.AllowUserToAddRows = False
            dgvDireccionPersona.AllowUserToDeleteRows = False
            dgvDireccionPersona.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
                                Or System.Windows.Forms.AnchorStyles.Bottom) _
                                Or System.Windows.Forms.AnchorStyles.Left) _
                                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDireccionPersona.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDireccionPersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDireccionPersona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            EdgvContactoPersona.pAnchoColumna = 20
            EdgvContactoPersona.pBloquearPk = True
            EdgvContactoPersona.pColorColumna = Drawing.Color.Black
            EdgvContactoPersona.pCampoEstadoRegistro = "cEstadoRegistro2"
            EdgvContactoPersona.pMetodoColumnas = True
            EdgvContactoPersona.Elementos = 1
            ReDim EdgvContactoPersona.pArrayCamposPkDetalle(1)
            EdgvContactoPersona.pArrayCamposPkDetalle(1) = "cART_ID_IMP"

            dgvContactoPersona.AllowUserToAddRows = False
            dgvContactoPersona.AllowUserToDeleteRows = False
            dgvContactoPersona.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
                                Or System.Windows.Forms.AnchorStyles.Bottom) _
                                Or System.Windows.Forms.AnchorStyles.Left) _
                                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvContactoPersona.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvContactoPersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvContactoPersona.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End Sub

        Private Sub dgvDocIdentidad_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvDocIdentidad.CellValidated
            Select Case sender.Columns(dgvDocIdentidad.CurrentCell.ColumnIndex).Name.ToString
                Case "cDOP_NUMERO"
                    If Len(Trim(dgvDocIdentidad.Item(dgvDocIdentidad.CurrentCell.ColumnIndex, dgvDocIdentidad.CurrentRow.Index).Value)) <> _
                        dgvDocIdentidad.Item("cTDP_LONGITUD", dgvDocIdentidad.CurrentRow.Index).Value Then
                        dgvDocIdentidad.Item(dgvDocIdentidad.CurrentCell.ColumnIndex, dgvDocIdentidad.CurrentRow.Index).Value = ""
                    End If
            End Select
        End Sub

        Private Sub dgvDireccionPersona_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles dgvDireccionPersona.KeyDown
            If dgvDireccionPersona.RowCount = 0 Then Exit Sub
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                Case "cDIS_ID1"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtDIS_ID.pBusqueda Then
                                EtxtDIS_ID.pTexto2 = dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value
                                MetodoBusquedaDato("", False, EtxtDIS_ID)
                                EtxtDIS_ID.pTexto1 = dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value
                                EtxtDIS_ID.pTexto2 = dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value
                            End If
                    End Select
            End Select
        End Sub
        Private Sub dgvDireccionPersona_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDireccionPersona.CellDoubleClick
            If dgvDireccionPersona.Columns(dgvDireccionPersona.CurrentCell.ColumnIndex).Name = "cDIS_ID1" Then
                If EtxtDIS_ID.pFormularioConsulta Then
                    Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmDistrito)()
                    frmConsulta.DatoBusquedaConsulta = dgvDireccionPersona.CurrentCell.Value
                    frmConsulta.MaximizeBox = False
                    frmConsulta.Comportamiento = -1
                    frmConsulta.ShowDialog()
                End If
            End If
        End Sub
        Private Sub dgvDireccionPersona_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvDireccionPersona.CellEnter
            Select Case sender.Columns(dgvDireccionPersona.CurrentCell.ColumnIndex).Name.ToString
                Case "cDIS_ID1"
                    EtxtDIS_ID.pTexto1 = dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value
            End Select
        End Sub
        Private Sub dgvDireccionPersona_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvDireccionPersona.CellValidated
            Select Case sender.Columns(dgvDireccionPersona.CurrentCell.ColumnIndex).Name.ToString
                Case "cDIR_DESCRIPCION1"
                    dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value = Strings.UCase(dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value)
                Case "cDIR_REFERENCIA1"
                    dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value = Strings.UCase(dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value)
                Case "cDIS_ID1"
                    EtxtDIS_ID.pTexto2 = dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value
                    ValidarDatos(EtxtDIS_ID, dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value, True, sender.Columns(dgvDireccionPersona.CurrentCell.ColumnIndex).Name.ToString)
                    EtxtDIS_ID.pTexto1 = dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value
                    EtxtDIS_ID.pTexto2 = dgvDireccionPersona.Item(dgvDireccionPersona.CurrentCell.ColumnIndex, dgvDireccionPersona.CurrentRow.Index).Value
            End Select
        End Sub
        Private Sub ValidarDatos(ByRef otxt As txt, _
                                 ByVal texto As String, _
                                 ByVal BusquedaDirecta As Boolean, _
                                 Optional ByVal NameCampo As String = "")
            If otxt.pTexto1 <> otxt.pTexto2 Then
                If otxt.pBusqueda Then
                    MetodoBusquedaDato(texto, BusquedaDirecta, otxt)
                End If
                Select Case NameCampo
                    Case "cDIS_ID1"
                        KeysTab(1)
                End Select
            End If
        End Sub

        Private Sub dgvContactoPersona_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvContactoPersona.CellValidated
            Select Case sender.Columns(dgvContactoPersona.CurrentCell.ColumnIndex).Name.ToString
                Case "cCOP_DESCRIPCION2", "cCOP_DIRECCION2", "cCOP_TELEFONO2"
                    dgvContactoPersona.Item(dgvContactoPersona.CurrentCell.ColumnIndex, dgvContactoPersona.CurrentRow.Index).Value = Strings.UCase(dgvContactoPersona.Item(dgvContactoPersona.CurrentCell.ColumnIndex, dgvContactoPersona.CurrentRow.Index).Value)
                Case "cCOP_EMAIL2"
                    dgvContactoPersona.Item(dgvContactoPersona.CurrentCell.ColumnIndex, dgvContactoPersona.CurrentRow.Index).Value = Strings.LCase(dgvContactoPersona.Item(dgvContactoPersona.CurrentCell.ColumnIndex, dgvContactoPersona.CurrentRow.Index).Value)
            End Select
        End Sub
#End Region
#End Region

#Region "Primaria 2"
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

        Private Structure chk
            Public Property pFormatearTexto As Boolean
            Public Property pNombreCampo As String
            Public Property vEstado0 As String
            Public Property vEstado1 As String
            Public Property vEstadoX As String
            Public Property pSimple As Object
            Public Property pValorDefault As System.Windows.Forms.CheckState
        End Structure
        Private Structure cbo
            Public Property pNombreCampo As String
        End Structure
        Private Structure txt
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
            If pNuevo = False Then
                If pLLamadaDesdeFormularioCrear Then
                    Me.Close()
                End If
                Exit Sub
            End If

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

            If pLLamadaDesdeFormularioCrear Then
                BotonesEdicion(LLamadaDesdeFormularioDatos.pProcesoBotonesEdicion)
                lblPER_CONTACTO.Text = LLamadaDesdeFormularioDatos.pNombreMostrarTipoPersonaCrear
            End If

            txtPER_APE_PAT.Focus()
        End Sub
        Public Sub EditarRegistro()
            If Not pFlagNuevo Then If Trim(pCodigoId) = "" Then Return
            BotonesEdicion("Editar registro")

            If pLLamadaDesdeFormularioModificar Then
                BotonesEdicion(LLamadaDesdeFormularioDatos.pProcesoBotonesEdicion)
                lblPER_CONTACTO.Text = LLamadaDesdeFormularioDatos.pNombreMostrarTipoPersonaCrear
            End If
            BloquearCamposEnEdicion(pFlagNuevo)
        End Sub
        Private Sub BloquearCamposEnEdicion(ByVal vNuevo)
            If vNuevo Then
                chkPER_ESTADO.Enabled = True
                txtPER_APE_PAT.ReadOnly = False
                txtPER_APE_MAT.ReadOnly = False
                txtPER_NOMBRES.ReadOnly = False
            Else
                If Not SessionService.ModificarEstadoEnPersona Then chkPER_ESTADO.Enabled = False
                If Not SessionService.ModificarNombreEnPersona Then
                    txtPER_APE_PAT.ReadOnly = True
                    txtPER_APE_MAT.ReadOnly = True
                    txtPER_NOMBRES.ReadOnly = True
                End If
            End If
            If Not SessionService.ModificarObservacionesEnPersona Then txtPER_OBSERVACIONES.Enabled = False
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
                    If pLLamadaDesdeFormularioModificar Then
                        BotonesEdicion(LLamadaDesdeFormularioDatos.pProcesoBotonesEdicion)
                        lblPER_CONTACTO.Text = LLamadaDesdeFormularioDatos.pNombreMostrarTipoPersonaCrear
                    End If
                End If
            Else
                BotonesEdicion("Seleccionar registro")
            End If
        End Sub
        Public Sub PrepararGuardar(ByVal vNuevo As Boolean)
            'MsgBox(Me.IBCBusqueda.NuevoCodigoDireccionPersona())
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
            vVerificarExisteRolPersonaTipoPersona = Me.IBCBusqueda.VerificarExisteRolPersonaTipoPersona(txtPER_ID.Text, vTipoCliente)
            If pRegistroNuevo Then
                bRes = Ingresar()
            Else
                bRes = Modificar()
            End If
            If bRes Then InicializarDatos()
            If (bRes) Then
                BotonesEdicion("Seleccionar registro")
                If vNuevo Then
                    NuevoRegistro()
                End If
                If pLLamadaDesdeFormularioCrear Or _
                   pLLamadaDesdeFormularioModificar Then
                    NombreFormulario.BuscarCuadroTexto = True
                    NombreFormulario.CuadroTexto.Text = txtPER_ID.Text
                    Salir()
                End If
            End If
        End Sub
        Public Sub PrepararEliminar()
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
            BusquedaDatos("BuscarUnRegistro")
        End Sub
        Public Sub PosicionGrid(ByVal Metodo As String)
            If pCodigoId Is Nothing Or Trim(pCodigoId) = "" Then
                MsgBox("No esta disponible el desplazamiento" & Chr(13) & Chr(13) & "Ubiquese en un registro", MsgBoxStyle.Information, Me.Text)
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
                    tsBarra.Dock = System.Windows.Forms.DockStyle.None
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

        Private Sub ProcesoCrearCodigoId(ByVal vVista As String, ByRef oTexto As TextBox)
            Select Case vVista
                Case "CrearCodigoSimple"
                    Dim resp = Me.IBCBusqueda.CrearCodigoSimple(Simple.CampoPrincipal, _
                                                                Simple.cTabla.NombreLargo)
                    oTexto.Text = resp
                    For a = 1 To (LongitudId - Len(oTexto.Text.Trim()))
                        oTexto.Text = CaracterId & oTexto.Text
                    Next
                    oTexto.ReadOnly = True
            End Select
        End Sub

        Private Function RevisarDatos(ByVal vBoolean As Boolean) As Boolean
            Return RevisarDatos(pColeccionDatos, vBoolean)
        End Function
        Private Function RevisarDatos(ByVal vColeccionDatos As Collection, _
                                      ByVal vRespuestaGrabar As Boolean) As Boolean
            If RevisarDatosForm(vColeccionDatos, True) Then
                If vRespuestaGrabar Then
                    RevisarDatos = True
                Else
                    If LlamadaDesdeFormularioCrear Then
                        RevisarDatos = False
                    Else
                        Dim oMsgBoxResult As New MsgBoxResult()
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

        Public Sub InicializarDatos()
            OrmBusquedaDatos("InicializarDatos")
            pRegistroNuevo = False
            pColeccionDatos = RevisarDatosForm(Nothing, False)
        End Sub

        Private Sub AdicionarFilasGrid()
        End Sub

        Private Sub EliminarFilasGrid()
        End Sub

        ' generico
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
                    Nuevo = vNuevo 'True
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
                Case ("LlamadaDesdeFormularioNuevoRegistro")
                    Nuevo = False
                    tsbNuevo.Enabled = False
                    Editar = False
                    CancelarEditar = False
                    Grabar = True
                    GrabarNuevo = False
                    Eliminar = False
                    Deshacer = False
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
                Case ("LlamadaDesdeFormularioModificarRegistro")
                    Nuevo = False
                    tsbNuevo.Enabled = False
                    Editar = False
                    CancelarEditar = False
                    Grabar = True
                    GrabarNuevo = False
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

        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            TeclasAccesoRapido(keyData)
            If keyData <> Keys.Enter Then
                Return (MyBase.ProcessCmdKey(msg, keyData))
            End If
            SendKeys.Send(Chr(Keys.Tab))
            Return True
        End Function
        Private Sub frm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
           Handles MyBase.FormClosing
            If pnCuerpo.Enabled = True Then
                If RevisarDatos(False) Then
                    e.Cancel = True
                    MyBase.OnClosing(e)
                Else
                    MyBase.OnClosing(e)
                End If
            End If
        End Sub
        Private Sub frm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles MyBase.Activated
            If pComportamiento <> -1 Then
                Activado()
                If pLLamadaDesdeFormularioCrear Then
                    txtPER_ID.Enabled = False
                    If LLamadaDesdeFormularioDatos.pCargando Then
                        txtPER_APE_PAT.Focus()
                        'LLamadaDesdeFormularioDatos.pCargando = False
                    End If
                ElseIf pLLamadaDesdeFormularioModificar Then
                    txtPER_ID.Enabled = False
                    If LLamadaDesdeFormularioDatos.pCargando Then
                        txtPER_APE_PAT.Focus()
                        'LLamadaDesdeFormularioDatos.pCargando = False
                    End If
                End If
            End If
        End Sub
        Private Sub frm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) _
            Handles MyBase.FormClosed
            If pComportamiento <> -1 Then
                Cerrado()
            End If
        End Sub

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

        Private Sub ConfigurarCheck()
            Dim EchkTemporal As New chk

            EchkTemporal.pFormatearTexto = True
            EchkTemporal.vEstado0 = ""
            EchkTemporal.vEstado1 = ""
            EchkTemporal.vEstadoX = ""
            EchkTemporal.pSimple = Simple
            EchkTemporal.pValorDefault = CheckState.Unchecked

            EchkPER_CLIENTE = EchkTemporal
            EchkPER_CLIENTE.pNombreCampo = "PER_CLIENTE"
            EchkPER_CLIENTE.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkPER_CLIENTE)

            EchkPER_PROVEEDOR = EchkTemporal
            EchkPER_PROVEEDOR.pNombreCampo = "PER_PROVEEDOR"
            ConfigurarCheck_Refrescar(EchkPER_PROVEEDOR)

            EchkPER_TRANSPORTISTA = EchkTemporal
            EchkPER_TRANSPORTISTA.pNombreCampo = "PER_TRANSPORTISTA"
            ConfigurarCheck_Refrescar(EchkPER_TRANSPORTISTA)

            EchkPER_TRABAJADOR = EchkTemporal
            EchkPER_TRABAJADOR.pNombreCampo = "PER_TRABAJADOR"
            ConfigurarCheck_Refrescar(EchkPER_TRABAJADOR)

            EchkPER_BANCO = EchkTemporal
            EchkPER_BANCO.pNombreCampo = "PER_BANCO"
            ConfigurarCheck_Refrescar(EchkPER_BANCO)

            EchkPER_GRUPO = EchkTemporal
            EchkPER_GRUPO.pNombreCampo = "PER_GRUPO"
            ConfigurarCheck_Refrescar(EchkPER_GRUPO)

            EchkPER_CONTACTO = EchkTemporal
            EchkPER_CONTACTO.pNombreCampo = "PER_CONTACTO"
            ConfigurarCheck_Refrescar(EchkPER_CONTACTO)

            EchkPER_PROMOCIONES = EchkTemporal
            EchkPER_PROMOCIONES.pNombreCampo = "PER_PROMOCIONES"
            ConfigurarCheck_Refrescar(EchkPER_PROMOCIONES)

            EchkPER_REP_LEGAL = EchkTemporal
            EchkPER_REP_LEGAL.pNombreCampo = "PER_REP_LEGAL"
            ConfigurarCheck_Refrescar(EchkPER_REP_LEGAL)

            EchkPER_FIRMA_AUT = EchkTemporal
            EchkPER_FIRMA_AUT.pNombreCampo = "PER_FIRMA_AUT"
            ConfigurarCheck_Refrescar(EchkPER_FIRMA_AUT)

            EchkPER_LINEA_CREDITO_ESTADO = EchkTemporal
            EchkPER_LINEA_CREDITO_ESTADO.pNombreCampo = "PER_LINEA_CREDITO_ESTADO"
            EchkPER_LINEA_CREDITO_ESTADO.pValorDefault = CheckState.Unchecked
            ConfigurarCheck_Refrescar(EchkPER_LINEA_CREDITO_ESTADO)

            EchkPER_ESTADO = EchkTemporal
            EchkPER_ESTADO.pNombreCampo = "PER_ESTADO"
            EchkPER_ESTADO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkPER_ESTADO)
        End Sub
        Private Sub ComportamientoFormulario()
            If pComportamiento <> -1 Or pLLamadaDesdeFormularioModificar Then
                NombresFormulariosControles()
            End If
            pLoaded = False
        End Sub
        Private Sub NombresFormulariosControles()
            EtxtPER_ID_VEN.pOOrm.CadenaFiltrado = " AND PER_TRABAJADOR='SI' AND TPE_TRABAJADOR='SI' AND TPE_ID='" & BCVariablesNames.TipoPersonas.Vendedor & "'"
            EtxtPER_ID_COB.pOOrm.CadenaFiltrado = " AND PER_TRABAJADOR='SI' AND TPE_TRABAJADOR='SI' AND TPE_ID='" & BCVariablesNames.TipoPersonas.Cobrador & "'"
            EtxtPER_ID_TRA.pOOrm.CadenaFiltrado = " AND PER_TRANSPORTISTA='SI' AND TPE_TRANSPORTISTA='SI' AND TPE_ID='" & BCVariablesNames.TipoPersonas.Transportista & "'"
            EtxtPER_ID_BAN.pOOrm.CadenaFiltrado = " AND PER_BANCO='SI' AND TPE_BANCO='SI' AND TPE_ID='" & BCVariablesNames.TipoPersonas.Banco & "'"
            EtxtPER_ID_GRU.pOOrm.CadenaFiltrado = " AND PER_GRUPO='SI' AND TPE_GRUPO='SI'"
        End Sub

        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            SaldosCliente()
        End Sub
        Private Sub FormatearCampos(ByRef oObjeto As Object, _
                                    ByVal NombreCampo As String, _
                                    ByRef sender As txt, _
                                    Optional ByVal e As System.Boolean = True)
            FormatearCampos(oObjeto, NombreCampo, Simple.vArrayDatosComboBox, Simple.vElementosDatosComboBox - 1, sender, e)
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

        Private Sub Activado()
            ActivarBarra()
            FormatearBotonesEdicion()
        End Sub
        Private Sub ActivarBarra()
            If tsBarra.Enabled = False Then
                tsBarra.Enabled = True
            End If
        End Sub

        Private Sub Cerrado()
        End Sub

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
        Private Sub TeclaF1SubLlamadas(ByVal vNametxt As String)

        End Sub
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

#Region "Secundaria 2"
        Private Sub LimpiarDatos()
            vBuscarDocIdentidadPersona = False
            vBuscarDireccionPersona = False
            vBuscarContactoPersona = False
            vBuscarTipoCliente = False

            InicializarValores(txtPER_ID, ErrorProvider1)
            InicializarValores(txtPER_APE_PAT, ErrorProvider1)
            InicializarValores(txtPER_APE_MAT, ErrorProvider1)
            InicializarValores(txtPER_NOMBRES, ErrorProvider1)

            InicializarValores(chkPER_CLIENTE, ErrorProvider1, False, False, EchkPER_CLIENTE.pValorDefault)
            InicializarValores(cboPER_CLIENTE_OP_CON, ErrorProvider1)

            InicializarValores(chkPER_PROVEEDOR, ErrorProvider1)
            InicializarValores(cboPER_PROVEEDOR_OP_CON, ErrorProvider1)

            InicializarValores(chkPER_TRABAJADOR, ErrorProvider1)
            InicializarValores(cboPER_TRABAJADOR_OP_CON, ErrorProvider1)

            InicializarValores(chkPER_BANCO, ErrorProvider1)
            InicializarValores(cboPER_BANCO_OP_CON, ErrorProvider1)

            InicializarValores(chkPER_GRUPO, ErrorProvider1)
            InicializarValores(cboPER_GRUPO_OP_CON, ErrorProvider1)

            InicializarValores(chkPER_CONTACTO, ErrorProvider1)
            InicializarValores(cboPER_CONTACTO_OP_CON, ErrorProvider1)

            InicializarValores(chkPER_TRANSPORTISTA, ErrorProvider1)
            InicializarValores(cboPER_TRANSPORTISTA_OP_CON, ErrorProvider1)
            InicializarValores(cboPER_TRANSP_PROPIO, ErrorProvider1)

            InicializarValores(txtPER_BREVETE, ErrorProvider1)
            InicializarValores(cboPER_FORMA_VENTA, ErrorProvider1)
            cboPER_FORMA_VENTA.Text = BCVariablesNames.FormaVenta.Contado

            InicializarValores(txtPER_TELEFONOS, ErrorProvider1)
            InicializarValores(txtPER_EMAIL, ErrorProvider1)
            InicializarValores(txtPER_PAGINA_WEB, ErrorProvider1)

            InicializarValores(txtPER_LINEA_CREDITO, ErrorProvider1, EtxtPER_LINEA_CREDITO.pSoloNumeros, EtxtPER_LINEA_CREDITO.pSoloNumerosDecimales)
            InicializarValores(txtPER_DIAS_CREDITO, ErrorProvider1, EtxtPER_DIAS_CREDITO.pSoloNumeros, EtxtPER_DIAS_CREDITO.pSoloNumerosDecimales)

            InicializarValores(txtPER_ID_VEN, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_VEN, ErrorProvider1)

            InicializarValores(txtPER_ID_COB, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_COB, ErrorProvider1)

            InicializarValores(txtPER_ID_TRA, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_TRA, ErrorProvider1)

            InicializarValores(txtPER_ID_BAN, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_BAN, ErrorProvider1)

            InicializarValores(txtPER_ID_GRU, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_GRU, ErrorProvider1)

            InicializarValores(cboPER_DIASEM_PAGO, ErrorProvider1)
            InicializarValores(cboPER_COND_DIASEM, ErrorProvider1)
            InicializarValores(txtPER_DIAMES_PAGO, ErrorProvider1, True)

            InicializarValores(cboPER_DOC_PAGO, ErrorProvider1)
            InicializarValores(txtPER_HORA_PAGO, ErrorProvider1)

            InicializarValores(txtPER_OBSERVACIONES, ErrorProvider1)

            InicializarValores(chkPER_PROMOCIONES, ErrorProvider1)
            InicializarValores(cboPER_CARTA_FIANZA, ErrorProvider1)
            InicializarValores(txtPER_CUOTA_MENSUAL, ErrorProvider1, False, True)
            InicializarValores(txtPER_CUOTA_OBJETIVO, ErrorProvider1, False, True)

            InicializarValores(txtPER_BONO, ErrorProvider1, False, True)

            InicializarValores(txtCCC_ID_CLI, ErrorProvider1)
            InicializarValores(txtCCC_DESCRIPCION_CLI, ErrorProvider1)

            InicializarValores(txtPER_CARGO, ErrorProvider1)
            InicializarValores(chkPER_REP_LEGAL, ErrorProvider1)
            InicializarValores(chkPER_FIRMA_AUT, ErrorProvider1)
            InicializarValores(chkPER_LINEA_CREDITO_ESTADO, ErrorProvider1, False, False, EchkPER_LINEA_CREDITO_ESTADO.pValorDefault)
            InicializarValores(chkPER_ESTADO, ErrorProvider1, False, False, EchkPER_ESTADO.pValorDefault)

            txtDeuda.Text = 0
            txtDisponible.Text = 0

            Check_Refrescar()

            dgvDocIdentidad.Rows.Clear()
            dgvDireccionPersona.Rows.Clear()
            dgvContactoPersona.Rows.Clear()

            BuscarDocIdentidadPersona("__")
            BuscarDireccionPersona("__")
            BuscarContactoPersona("__")
            BuscarTipoCliente("__")

            vBuscarDocIdentidadPersona = True
            vBuscarDireccionPersona = True
            vBuscarContactoPersona = True
            vBuscarTipoCliente = True
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

        Private Sub HabilitarNuevo()
            txtPER_ID.Enabled = True
            BloquearCamposEnEdicion(True)
        End Sub

        Private Sub ValoresDefaultNuevo()
            'EchkPER_CLIENTE.pValorDefault = CheckState.Checked
            ColocarValoresDefault(chkPER_CLIENTE)
            ColocarValoresDefault(chkPER_PROVEEDOR)
            ColocarValoresDefault(chkPER_TRANSPORTISTA)
            ColocarValoresDefault(chkPER_TRABAJADOR)
            ColocarValoresDefault(chkPER_BANCO)
            ColocarValoresDefault(chkPER_GRUPO)
            ColocarValoresDefault(chkPER_CONTACTO)
            ColocarValoresDefault(chkPER_PROMOCIONES)
            ColocarValoresDefault(chkPER_REP_LEGAL)
            ColocarValoresDefault(chkPER_FIRMA_AUT)
            ColocarValoresDefault(chkPER_LINEA_CREDITO_ESTADO)
            ColocarValoresDefault(chkPER_ESTADO)
            'EchkPER_CLIENTE.pValorDefault = CheckState.Unchecked
        End Sub
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkPER_CLIENTE"
                    vObjetoChk.pValorDefault = EchkPER_CLIENTE.pValorDefault
                Case "chkPER_PROVEEDOR"
                    vObjetoChk.pValorDefault = EchkPER_PROVEEDOR.pValorDefault
                Case "chkPER_TRANSPORTISTA"
                    vObjetoChk.pValorDefault = EchkPER_TRANSPORTISTA.pValorDefault
                Case "chkPER_TRABAJADOR"
                    vObjetoChk.pValorDefault = EchkPER_TRABAJADOR.pValorDefault
                Case "chkPER_BANCO"
                    vObjetoChk.pValorDefault = EchkPER_BANCO.pValorDefault
                Case "chkPER_GRUPO"
                    vObjetoChk.pValorDefault = EchkPER_GRUPO.pValorDefault
                Case "chkPER_CONTACTO"
                    vObjetoChk.pValorDefault = EchkPER_CONTACTO.pValorDefault
                Case "chkPER_PROMOCIONES"
                    vObjetoChk.pValorDefault = EchkPER_PROMOCIONES.pValorDefault
                Case "chkPER_REP_LEGAL"
                    vObjetoChk.pValorDefault = EchkPER_REP_LEGAL.pValorDefault
                Case "chkPER_FIRMA_AUT"
                    vObjetoChk.pValorDefault = EchkPER_FIRMA_AUT.pValorDefault
                Case "chkPER_LINEA_CREDITO_ESTADO"
                    vObjetoChk.pValorDefault = EchkPER_LINEA_CREDITO_ESTADO.pValorDefault
                Case "chkPER_ESTADO"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO.pValorDefault
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

        Private Sub CrearCodigoId()
            ProcesoCrearCodigoId("CrearCodigoSimple", txtPER_ID)
        End Sub

        Private Sub HabilitarEscrituraNuevo()
            txtPER_ID.ReadOnly = False
        End Sub

        Public Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "PrepararEliminar"
                    Simple.Vista = "RegistroAnterior"
                    Simple.PER_ID = CodigoId
                Case "Load"
                    Simple.Vista = "PrimerRegistro"
                    Simple.PER_ID = CodigoId
                Case "NavegarFormulario"
                    Simple.PER_ID = CodigoId
                Case "EliminarRegistro"
                    Simple.PER_ID = txtPER_ID.Text.Trim
                    CodigoId = txtPER_ID.Text.Trim
                Case "InicializarDatos"
                    Simple.PER_ID = txtPER_ID.Text.Trim
                    CodigoId = txtPER_ID.Text.Trim

                    If vBuscarDocIdentidadPersona Then
                        BuscarDocIdentidadPersona(CodigoId)
                    End If
                    If vBuscarDireccionPersona Then
                        BuscarDireccionPersona(CodigoId)
                    End If
                    If vBuscarContactoPersona Then
                        BuscarContactoPersona(CodigoId)
                    End If
                    If vBuscarTipoCliente Then
                        BuscarTipoCliente(CodigoId)
                    End If
            End Select
        End Sub

        Public Sub BuscarDocIdentidadPersona(ByVal CodigoPER_ID As String)
            Simple2.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Simple2.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                CodigoPER_ID, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                dgvDocIdentidad.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
                        dgvDocIdentidad.Rows.Add()
                        With ds.Tables(0).Rows(x)
                            While y < ds.Tables(0).Columns.Count
                                Select Case ds.Tables(0).Columns(y).ColumnName
                                    Case "xxxxNúmero"
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
                                dgvDocIdentidad.Item(y, dgvDocIdentidad.Rows.Count - 1).Value = Formatos(vCadenaGeType, .Item(y).ToString())
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
                dgvDocIdentidad.DataSource = Nothing
                'dgvDocIdentidad.Rows.Clear()
            End If
        End Sub
        Public Sub BuscarDireccionPersona(ByVal CodigoPER_ID As String)
            Simple1.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Simple1.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                CodigoPER_ID, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                dgvDireccionPersona.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
                        dgvDireccionPersona.Rows.Add()
                        With ds.Tables(0).Rows(x)
                            While y < ds.Tables(0).Columns.Count
                                Select Case ds.Tables(0).Columns(y).ColumnName
                                    Case "xxxxNúmero"
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
                                dgvDireccionPersona.Item(y, dgvDireccionPersona.Rows.Count - 1).Value = Formatos(vCadenaGeType, .Item(y).ToString())
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
                dgvDireccionPersona.DataSource = Nothing
                dgvDireccionPersona.Rows.Clear()
            End If
            AdicionarTipoDireccion()
        End Sub
        Public Sub BuscarContactoPersona(ByVal CodigoPER_ID As String)
            Simple5.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Simple5.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                CodigoPER_ID, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                dgvContactoPersona.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
                        dgvContactoPersona.Rows.Add()
                        With ds.Tables(0).Rows(x)
                            While y < ds.Tables(0).Columns.Count
                                Select Case ds.Tables(0).Columns(y).ColumnName
                                    Case "xxxxNúmero"
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
                                dgvContactoPersona.Item(y, dgvContactoPersona.Rows.Count - 1).Value = Formatos(vCadenaGeType, .Item(y).ToString())
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
                dgvContactoPersona.DataSource = Nothing
                dgvContactoPersona.Rows.Clear()
            End If
            AdicionarTipoContacto()
        End Sub

        Public Sub BuscarTipoCliente(ByVal CodigoPER_ID As String)
            Simple3.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Simple3.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, _
                                                                CodigoPER_ID, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                If (ds.Tables(0).Rows.Count > 0) Then
                    cboTipoCliente.DataSource = ds.Tables(0)
                    cboTipoCliente.DisplayMember = "Descripción"
                    cboTipoCliente.ValueMember = "Código"
                    vTipoCliente = cboTipoCliente.SelectedValue
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information, Me.Text)
                End If
            Else
                cboTipoCliente.DataSource = Nothing
                vTipoCliente = ""
            End If
        End Sub

        Private Sub AdicionarTipoDireccion()
            Dim flagFiscal As Boolean = False
            Dim flagDomicilio As Boolean = False
            Dim flagCobranza As Boolean = False
            Dim flagEntrega As Boolean = False

            EdgvDireccionPersona.Elementos = 0
            For fila = 0 To dgvDireccionPersona.RowCount - 1
                EdgvDireccionPersona.Elementos = fila + 1
                Select Case BCVariablesNames.TipoDireccion(Trim(dgvDireccionPersona.Item("cDIR_TIPO1", fila).Value))
                    Case 0
                        flagDomicilio = True
                    Case 1
                        flagEntrega = True
                    Case 2
                        flagCobranza = True
                    Case 3
                        flagFiscal = True
                End Select
            Next

            If Not flagDomicilio Then
                EdgvDireccionPersona.Elementos = EdgvDireccionPersona.Elementos + 1
                dgvDireccionPersona.Rows.Add(EdgvDireccionPersona.Elementos, _
                                                       "", BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion0, "", "", _
                                                       "", "", "NO ACTIVO", _
                                                       "ACTIVO", 0)
            End If
            If Not flagEntrega Then
                EdgvDireccionPersona.Elementos = EdgvDireccionPersona.Elementos + 1
                dgvDireccionPersona.Rows.Add(EdgvDireccionPersona.Elementos, _
                                                     "", BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion1, "", "", _
                                                     "", "", "NO ACTIVO", _
                                                     "ACTIVO", 0)
            End If
            If Not flagCobranza Then
                EdgvDireccionPersona.Elementos = EdgvDireccionPersona.Elementos + 1
                dgvDireccionPersona.Rows.Add(EdgvDireccionPersona.Elementos, _
                                                      "", BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion2, "", "", _
                                                      "", "", "NO ACTIVO", _
                                                      "ACTIVO", 0)
            End If
            If Not flagFiscal Then
                EdgvDireccionPersona.Elementos = EdgvDireccionPersona.Elementos + 1
                dgvDireccionPersona.Rows.Add(EdgvDireccionPersona.Elementos, _
                                                    "", BCVariablesNames.TipoDireccionDescripcion.TipoDireccionDescripcion3, "", "", _
                                                    "", "", "NO ACTIVO", _
                                                    "ACTIVO", 0)
            End If
        End Sub
        Private Sub AdicionarTipoContacto()
            Dim flagOTROS As Boolean = False
            Dim flagINGENIERO As Boolean = False
            Dim flagARQUITECTO As Boolean = False
            Dim flagMAESTRODEOBRA As Boolean = False
            Dim flagJEFEDECOMPRAS As Boolean = False

            EdgvContactoPersona.Elementos = 0
            For fila = 0 To dgvContactoPersona.RowCount - 1
                EdgvContactoPersona.Elementos = fila + 1
                Select Case Trim(dgvContactoPersona.Item("cCOP_TIPO2", fila).Value)
                    Case BCVariablesNames.TipoContacto.TipoContacto0
                        flagOTROS = True
                    Case BCVariablesNames.TipoContacto.TipoContacto1
                        flagINGENIERO = True
                    Case BCVariablesNames.TipoContacto.TipoContacto2
                        flagARQUITECTO = True
                    Case BCVariablesNames.TipoContacto.TipoContacto3
                        flagMAESTRODEOBRA = True
                    Case BCVariablesNames.TipoContacto.TipoContacto4
                        flagJEFEDECOMPRAS = True
                End Select
            Next

            If Not flagOTROS Then
                EdgvContactoPersona.Elementos = EdgvContactoPersona.Elementos + 1
                dgvContactoPersona.Rows.Add(EdgvContactoPersona.Elementos, _
                                                       "", BCVariablesNames.TipoContacto.TipoContacto0, "", "", _
                                                       "", "", _
                                                       "ACTIVO", 0)
            End If
            If Not flagINGENIERO Then
                EdgvContactoPersona.Elementos = EdgvContactoPersona.Elementos + 1
                dgvContactoPersona.Rows.Add(EdgvContactoPersona.Elementos, _
                                                       "", BCVariablesNames.TipoContacto.TipoContacto1, "", "", _
                                                       "", "", _
                                                       "ACTIVO", 0)
            End If
            If Not flagARQUITECTO Then
                EdgvContactoPersona.Elementos = EdgvContactoPersona.Elementos + 1
                dgvContactoPersona.Rows.Add(EdgvContactoPersona.Elementos, _
                                                       "", BCVariablesNames.TipoContacto.TipoContacto2, "", "", _
                                                       "", "", _
                                                       "ACTIVO", 0)
            End If
            If Not flagMAESTRODEOBRA Then
                EdgvContactoPersona.Elementos = EdgvContactoPersona.Elementos + 1
                dgvContactoPersona.Rows.Add(EdgvContactoPersona.Elementos, _
                                                       "", BCVariablesNames.TipoContacto.TipoContacto3, "", "", _
                                                       "", "", _
                                                       "ACTIVO", 0)
            End If
            If Not flagJEFEDECOMPRAS Then
                EdgvContactoPersona.Elementos = EdgvContactoPersona.Elementos + 1
                dgvContactoPersona.Rows.Add(EdgvContactoPersona.Elementos, _
                                                       "", BCVariablesNames.TipoContacto.TipoContacto4, "", "", _
                                                       "", "", _
                                                       "ACTIVO", 0)
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
        Public Function Ingresar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 1
            pRespuestaExtraerDetalle = 0
            Ingresar = False
            ProcesoCrearCodigoId("CrearCodigoSimple", txtPER_ID)
            DatosCabecera()
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
            Me.Cursor = Windows.Forms.Cursors.Default
            If MensajeOperaciones(vMensajeMostrar, "ingresado") = 1 Then Return Ingresar
            InicializarOrm()
            Return Ingresar
        End Function
        Private Sub DatosCabecera()
            Simple.PER_ID = Strings.Trim(txtPER_ID.Text)
            Simple.PER_APE_PAT = Strings.Trim(txtPER_APE_PAT.Text)
            Simple.PER_APE_MAT = Strings.Trim(txtPER_APE_MAT.Text)
            Simple.PER_NOMBRES = Strings.Trim(txtPER_NOMBRES.Text)

            Simple.PER_CLIENTE = DevolverTiposCampos(chkPER_CLIENTE)
            Simple.PER_CLIENTE_OP_CON = DevolverTiposCampos("PER_CLIENTE_OP_CON", cboPER_CLIENTE_OP_CON.Text, Simple)

            Simple.PER_PROVEEDOR = DevolverTiposCampos(chkPER_PROVEEDOR)
            Simple.PER_PROVEEDOR_OP_CON = DevolverTiposCampos("PER_PROVEEDOR_OP_CON", cboPER_PROVEEDOR_OP_CON.Text, Simple)

            Simple.PER_TRABAJADOR = DevolverTiposCampos(chkPER_TRABAJADOR)
            Simple.PER_TRABAJADOR_OP_CON = DevolverTiposCampos("PER_TRABAJADOR_OP_CON", cboPER_TRABAJADOR_OP_CON.Text, Simple)

            Simple.PER_BANCO = DevolverTiposCampos(chkPER_BANCO)
            Simple.PER_BANCO_OP_CON = DevolverTiposCampos("PER_BANCO_OP_CON", cboPER_BANCO_OP_CON.Text, Simple)

            Simple.PER_GRUPO = DevolverTiposCampos(chkPER_GRUPO)
            Simple.PER_GRUPO_OP_CON = DevolverTiposCampos("PER_GRUPO_OP_CON", cboPER_GRUPO_OP_CON.Text, Simple)

            Simple.PER_CONTACTO = DevolverTiposCampos(chkPER_CONTACTO)
            'Simple.PER_CONTACTO_OP_CON = DevolverTiposCampos("PER_CONTACTO_OP_CON", cboPER_CONTACTO_OP_CON.Text, Simple)

            Simple.PER_TRANSPORTISTA = DevolverTiposCampos(chkPER_TRANSPORTISTA)
            Simple.PER_TRANSPORTISTA_OP_CON = DevolverTiposCampos("PER_TRANSPORTISTA_OP_CON", cboPER_TRANSPORTISTA_OP_CON.Text, Simple)
            Simple.PER_TRANSP_PROPIO = DevolverTiposCampos("PER_TRANSP_PROPIO", cboPER_TRANSP_PROPIO.Text, Simple)

            Simple.PER_BREVETE = Strings.Trim(txtPER_BREVETE.Text)
            Simple.PER_FORMA_VENTA = DevolverTiposCampos("PER_FORMA_VENTA", cboPER_FORMA_VENTA.Text, Simple)

            Simple.DIR_ID = Nothing

            Simple.PER_TELEFONOS = Strings.Trim(txtPER_TELEFONOS.Text)
            Simple.PER_EMAIL = Strings.Trim(txtPER_EMAIL.Text)
            Simple.PER_PAGINA_WEB = Strings.Trim(txtPER_PAGINA_WEB.Text)

            Simple.PER_LINEA_CREDITO = CDbl(txtPER_LINEA_CREDITO.Text)
            Simple.PER_DIAS_CREDITO = CInt(txtPER_DIAS_CREDITO.Text)

            If txtPER_ID_VEN.Text.Trim = "" Then
                Simple.PER_ID_VEN = Nothing
            Else
                Simple.PER_ID_VEN = Strings.Trim(txtPER_ID_VEN.Text)
            End If

            If txtPER_ID_COB.Text.Trim = "" Then
                Simple.PER_ID_COB = Nothing
            Else
                Simple.PER_ID_COB = Strings.Trim(txtPER_ID_COB.Text)
            End If

            If txtPER_ID_TRA.Text.Trim = "" Then
                Simple.PER_ID_TRA = Nothing
            Else
                Simple.PER_ID_TRA = Strings.Trim(txtPER_ID_TRA.Text)
            End If

            If txtPER_ID_BAN.Text.Trim = "" Then
                Simple.PER_ID_BAN = Nothing
            Else
                Simple.PER_ID_BAN = Strings.Trim(txtPER_ID_BAN.Text)
            End If

            If txtPER_ID_GRU.Text.Trim = "" Then
                Simple.PER_ID_GRU = Nothing
            Else
                Simple.PER_ID_GRU = Strings.Trim(txtPER_ID_GRU.Text)
            End If

            Simple.PER_DIASEM_PAGO = DevolverTiposCampos("PER_DIASEM_PAGO", cboPER_DIASEM_PAGO.Text, Simple)
            Simple.PER_COND_DIASEM = DevolverTiposCampos("PER_COND_DIASEM", cboPER_COND_DIASEM.Text, Simple)
            Simple.PER_DIAMES_PAGO = Strings.Trim(txtPER_DIAMES_PAGO.Text)
            Simple.PER_DOC_PAGO = DevolverTiposCampos("PER_DOC_PAGO", cboPER_DOC_PAGO.Text, Simple)
            Simple.PER_HORA_PAGO = Strings.Trim(txtPER_HORA_PAGO.Text)
            Simple.PER_OBSERVACIONES = Strings.Trim(txtPER_OBSERVACIONES.Text)

            Simple.PER_PROMOCIONES = DevolverTiposCampos(chkPER_PROMOCIONES)
            Simple.PER_CARTA_FIANZA = DevolverTiposCampos("PER_CARTA_FIANZA", cboPER_CARTA_FIANZA.Text, Simple)

            Simple.PER_CUOTA_MENSUAL = CDbl(txtPER_CUOTA_MENSUAL.Text)
            Simple.PER_CUOTA_OBJETIVO = CDbl(txtPER_CUOTA_OBJETIVO.Text)
            Simple.PER_BONO = CDbl(txtPER_BONO.Text)

            If txtCCC_ID_CLI.Text.Trim = "" Then
                Simple.CCC_ID = Nothing
            Else
                Simple.CCC_ID = Strings.Trim(txtCCC_ID_CLI.Text)
            End If

            Simple.PER_CARGO = Strings.Trim(txtPER_CARGO.Text)
            Simple.PER_REP_LEGAL = DevolverTiposCampos(chkPER_REP_LEGAL)
            Simple.PER_FIRMA_AUT = DevolverTiposCampos(chkPER_FIRMA_AUT)

            Simple.PER_PROCESAR_DESCUENTO = True

            Simple.PER_LINEA_CREDITO_ESTADO = DevolverTiposCampos(chkPER_LINEA_CREDITO_ESTADO)

            Simple.USU_ID = SessionService.UserId
            Simple.PER_FEC_GRAB = Now
            Simple.PER_ESTADO = DevolverTiposCampos(chkPER_ESTADO)

            Simple.PER_FECHA_ALTA = dtpPER_FECHA_ALTA.Value
            Simple.PER_FECHA_VENC = dtpPER_FECHA_VENC.Value
            Simple.PER_GARANTIA = txtPER_GARANTIA.Text
            If IsNumeric(txtPER_EXCESO_LINEA.Text) Then
                Simple.PER_EXCESO_LINEA = txtPER_EXCESO_LINEA.Text
            Else
                Simple.PER_EXCESO_LINEA = 0
                txtPER_EXCESO_LINEA.Text = 0
            End If

            Try
                If Simple.PER_LINEA_CREDITO <> pColeccionDatos(txtPER_LINEA_CREDITO.Name).ToString Then
                    Simple.PER_FECHA_ALTA = Now
                    dtpPER_FECHA_ALTA.Value = Now
                End If

            Catch ex As Exception
                Simple.PER_FECHA_ALTA = Now
                dtpPER_FECHA_ALTA.Value = Now
            End Try

            'If pRegistroNuevo Then
            'Simple3.PER_ID = Strings.Trim(txtPER_ID.Text)
            'If chkPER_PROVEEDOR.CheckState = CheckState.Checked Then
            'Simple3.TPE_ID = BCVariablesNames.TipoPersonas.PersonaJuridica
            'Else
            'Simple3.TPE_ID = BCVariablesNames.TipoPersonas.PersonaNatural
            'End If
            'Simple3.USU_ID = SessionService.UserId
            'Simple3.RTP_FEC_GRAB = Now
            'Simple3.RTP_ESTADO = DevolverTiposCampos(chkPER_ESTADO)
            'End If
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkPER_CLIENTE"
                    Simple.CampoId = EchkPER_CLIENTE.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_PROVEEDOR"
                    Simple.CampoId = EchkPER_PROVEEDOR.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_TRANSPORTISTA"
                    Simple.CampoId = EchkPER_TRANSPORTISTA.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_TRABAJADOR"
                    Simple.CampoId = EchkPER_TRABAJADOR.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_BANCO"
                    Simple.CampoId = EchkPER_BANCO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_GRUPO"
                    Simple.CampoId = EchkPER_GRUPO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_CONTACTO"
                    Simple.CampoId = EchkPER_CONTACTO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_PROMOCIONES"
                    Simple.CampoId = EchkPER_PROMOCIONES.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_REP_LEGAL"
                    Simple.CampoId = EchkPER_REP_LEGAL.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_FIRMA_AUT"
                    Simple.CampoId = EchkPER_FIRMA_AUT.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_LINEA_CREDITO_ESTADO"
                    Simple.CampoId = EchkPER_LINEA_CREDITO_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_ESTADO"
                    Simple.CampoId = EchkPER_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Simple.DevolverTiposCampos()
        End Function

        Private Function DevolverTiposCampos(ByVal oNombreCampo As String, ByVal oTexto As String, ByVal oOrm As Object) As String
            oOrm.CampoId = oNombreCampo
            oOrm.Dato = oTexto
            DevolverTiposCampos = oOrm.DevolverTiposCampos()
        End Function

        Private Function Validar(ByVal vModelos As String, Optional ByVal vFila As Integer = 0) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Simple.ColocarErrores(txtPER_ID, Simple.VerificarDatos("PER_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_APE_PAT, Simple.VerificarDatos("PER_APE_PAT"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_CLIENTE, Simple.VerificarDatos("PER_CLIENTE"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_CLIENTE_OP_CON, Simple.VerificarDatos("PER_CLIENTE_OP_CON"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_PROVEEDOR, Simple.VerificarDatos("PER_PROVEEDOR"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_PROVEEDOR_OP_CON, Simple.VerificarDatos("PER_PROVEEDOR_OP_CON"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_TRABAJADOR, Simple.VerificarDatos("PER_TRABAJADOR"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_TRABAJADOR_OP_CON, Simple.VerificarDatos("PER_TRABAJADOR_OP_CON"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_BANCO, Simple.VerificarDatos("PER_BANCO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_BANCO_OP_CON, Simple.VerificarDatos("PER_BANCO_OP_CON"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_GRUPO, Simple.VerificarDatos("PER_GRUPO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_GRUPO_OP_CON, Simple.VerificarDatos("PER_GRUPO_OP_CON"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_CONTACTO, Simple.VerificarDatos("PER_CONTACTO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_CONTACTO_OP_CON, Simple.VerificarDatos("PER_CONTACTO_OP_CON"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_TRANSPORTISTA, Simple.VerificarDatos("PER_TRANSPORTISTA"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_TRANSPORTISTA_OP_CON, Simple.VerificarDatos("PER_TRANSPORTISTA_OP_CON"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_TRANSP_PROPIO, Simple.VerificarDatos("PER_TRANSP_PROPIO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_FORMA_VENTA, Simple.VerificarDatos("PER_FORMA_VENTA"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_LINEA_CREDITO, Simple.VerificarDatos("PER_LINEA_CREDITO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_DIAS_CREDITO, Simple.VerificarDatos("PER_DIAS_CREDITO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_DIASEM_PAGO, Simple.VerificarDatos("PER_DIASEM_PAGO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_COND_DIASEM, Simple.VerificarDatos("PER_COND_DIASEM"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_DIAMES_PAGO, Simple.VerificarDatos("PER_DIAMES_PAGO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(tcoDatos, Simple.VerificarDatos("PER_DIAMES_PAGO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_DOC_PAGO, Simple.VerificarDatos("PER_DOC_PAGO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_PROMOCIONES, Simple.VerificarDatos("PER_PROMOCIONES"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(tcoDatos1, Simple.VerificarDatos("PER_PROMOCIONES"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboPER_CARTA_FIANZA, Simple.VerificarDatos("PER_CARTA_FIANZA"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_CUOTA_MENSUAL, Simple.VerificarDatos("PER_CUOTA_MENSUAL"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(tcoDatos1, Simple.VerificarDatos("PER_CUOTA_MENSUAL"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_BONO, Simple.VerificarDatos("PER_BONO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(tcoDatos1, Simple.VerificarDatos("PER_BONO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_REP_LEGAL, Simple.VerificarDatos("PER_REP_LEGAL"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(tcoDatos1, Simple.VerificarDatos("PER_REP_LEGAL"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_FIRMA_AUT, Simple.VerificarDatos("PER_FIRMA_AUT"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(tcoDatos1, Simple.VerificarDatos("PER_FIRMA_AUT"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(lblTitle, Simple.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(lblTitle, Simple.VerificarDatos("PER_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_LINEA_CREDITO_ESTADO, Simple.VerificarDatos("PER_LINEA_CREDITO_ESTADO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPER_ESTADO, Simple.VerificarDatos("PER_ESTADO"), ErrorProvider1)


                    If IsNothing(txtPER_BREVETE.Text) Or _
                       Len(Trim(txtPER_BREVETE.Text)) = 0 Then
                        If LLamadaDesdeFormularioDatos.pTipoPersonaCrear = BCVariablesNames.TipoPersonas.Transportista And _
                           LLamadaDesdeFormularioDatos.pEsChofer Then
                            resp.rM = False
                            ErrorProvider1.SetError(txtPER_BREVETE, "Ingrese un brevete válido.")
                            ErrorProvider1.SetError(tcoDatos1, "Ingrese un brevete válido.")
                        Else
                            If chkPER_TRANSPORTISTA.Checked And _
                               (Not IsNothing(txtPER_ID_TRA.Text) And Trim(txtPER_ID_TRA.Text) <> "") Then
                                resp.rM = False
                                ErrorProvider1.SetError(txtPER_BREVETE, "Ingrese un brevete válido.")
                                ErrorProvider1.SetError(tcoDatos1, "Ingrese un brevete válido.")
                            Else
                                resp.rM = True
                                ErrorProvider1.SetError(txtPER_BREVETE, Nothing)
                                ErrorProvider1.SetError(tcoDatos1, Nothing)
                            End If
                        End If
                    Else
                        If Len(Trim(txtPER_BREVETE.Text)) = 9 Then
                            Dim vPosicion1 As Object
                            Dim vPosicion2_8 As Object

                            vPosicion1 = Strings.Left(Trim(txtPER_BREVETE.Text), 1)
                            vPosicion2_8 = Strings.Right(Trim(txtPER_BREVETE.Text), 8)
                            Try
                                If vPosicion1.GetType = GetType(String) And _
                                   CInt(vPosicion2_8).GetType = GetType(Integer) Then
                                    resp.rM = True
                                    ErrorProvider1.SetError(txtPER_BREVETE, Nothing)
                                    ErrorProvider1.SetError(tcoDatos1, Nothing)
                                Else
                                    resp.rM = False
                                    ErrorProvider1.SetError(txtPER_BREVETE, "Ingrese un brevete válido.")
                                    ErrorProvider1.SetError(tcoDatos1, "Ingrese un brevete válido.")
                                End If
                            Catch ex As Exception
                                resp.rM = False
                                ErrorProvider1.SetError(txtPER_BREVETE, "Ingrese un brevete válido.")
                                ErrorProvider1.SetError(tcoDatos1, "Ingrese un brevete válido.")
                            End Try
                        Else
                            resp.rM = False
                            ErrorProvider1.SetError(txtPER_BREVETE, "Ingrese un brevete válido.")
                            ErrorProvider1.SetError(tcoDatos1, "Ingrese un brevete válido.")
                        End If
                    End If
                Case "Detalle"
                    resp.rM = Simple2.ColocarErrores(dgvDocIdentidad, _
                    Simple2.VerificarDatos("PER_ID",
                    "TDP_ID",
                    "DOP_NUMERO",
                    "DDO_ITEM",
                    "ART_ID_IMP",
                    "USU_ID",
                    "DOP_FEC_GRAB",
                    "DOP_ESTADO"), _
                    ErrorProvider1, vFila)

                    resp.rM = Simple2.ColocarErrores(tcoDatos, _
                    Simple2.VerificarDatos("PER_ID",
                    "TDP_ID",
                    "DOP_NUMERO",
                    "DDO_ITEM",
                    "ART_ID_IMP",
                    "USU_ID",
                    "DOP_FEC_GRAB",
                    "DOP_ESTADO"), _
                    ErrorProvider1, vFila)
                Case "Detalle1"
                    resp.rM = Simple1.ColocarErrores(dgvDireccionPersona, _
                    Simple1.VerificarDatos("PER_ID",
                    "DIR_DESCRIPCION",
                    "DIR_TIPO",
                    "DIR_REFERENCIA",
                    "DIS_ID",
                    "USU_ID",
                    "DIR_FEC_GRAB",
                    "DIR_ESTADO"), _
                    ErrorProvider1, vFila)

                    resp.rM = Simple1.ColocarErrores(tcoDatos, _
                    Simple1.VerificarDatos("PER_ID",
                    "DIR_DESCRIPCION",
                    "DIR_TIPO",
                    "DIR_REFERENCIA",
                    "DIS_ID",
                    "USU_ID",
                    "DIR_FEC_GRAB",
                    "DIR_ESTADO"), _
                    ErrorProvider1, vFila)
                Case "Detalle2"
                    resp.rM = Simple5.ColocarErrores(dgvContactoPersona, _
                    Simple5.VerificarDatos("PER_ID",
                    "COP_TIPO",
                    "COP_DESCRIPCION",
                    "COP_DIRECCION",
                    "COP_TELEFONO",
                    "COP_EMAL",
                    "USU_ID",
                    "COP_FEC_GRAB",
                    "COP_ESTADO"), _
                    ErrorProvider1, vFila)

                    resp.rM = Simple5.ColocarErrores(tcoDatos, _
                    Simple5.VerificarDatos("PER_ID",
                    "COP_TIPO",
                    "COP_DESCRIPCION",
                    "COP_DIRECCION",
                    "COP_TELEFONO",
                    "COP_EMAL",
                    "USU_ID",
                    "COP_FEC_GRAB",
                    "COP_ESTADO"), _
                    ErrorProvider1, vFila)
            End Select
            Return vrO
        End Function
        Private Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            'Dim vRespuestaLocal3 As Short = 0

            'Simple.MarkAsAdded()
            'vRespuestaLocal = Me.IBCPersonas.MantenimientoPersonas(Simple)
            vRespuestaLocal = IBCPersonas.spInsertarRegistro(Simple.PER_ID, Simple.PER_CLIENTE, Simple.PER_CLIENTE_OP_CON, Simple.PER_PROVEEDOR, Simple.PER_PROVEEDOR_OP_CON, Simple.PER_TRANSPORTISTA, Simple.PER_TRANSPORTISTA_OP_CON, Simple.PER_TRABAJADOR, Simple.PER_TRABAJADOR_OP_CON, Simple.PER_BANCO, Simple.PER_BANCO_OP_CON, Simple.PER_GRUPO, Simple.PER_GRUPO_OP_CON, Simple.PER_CONTACTO, Simple.PER_CONTACTO_OP_CON, Simple.PER_TRANSP_PROPIO, Simple.PER_NOMBRES, Simple.PER_APE_PAT, Simple.PER_APE_MAT, Simple.PER_BREVETE, Simple.PER_FORMA_VENTA, Simple.DIR_ID, Simple.PER_TELEFONOS, Simple.PER_EMAIL, Simple.PER_PAGINA_WEB, Simple.PER_LINEA_CREDITO, Simple.PER_DIAS_CREDITO, Simple.PER_ID_VEN, Simple.PER_ID_COB, Simple.PER_ID_TRA, Simple.PER_ID_BAN, Simple.PER_ID_GRU, Simple.PER_DIASEM_PAGO, Simple.PER_COND_DIASEM, Simple.PER_DIAMES_PAGO, Simple.PER_DOC_PAGO, Simple.PER_HORA_PAGO, Simple.PER_OBSERVACIONES, Simple.PER_PROMOCIONES, Simple.PER_CARTA_FIANZA, Simple.PER_CUOTA_MENSUAL, Simple.PER_CUOTA_OBJETIVO, Simple.PER_BONO, Simple.CCC_ID, Simple.PER_CARGO, Simple.PER_REP_LEGAL, Simple.PER_FIRMA_AUT, Simple.PER_PROCESAR_DESCUENTO, Simple.PER_ALIAS, Simple.PER_LINEA_CREDITO_ESTADO, Simple.USU_ID, Simple.PER_FEC_GRAB, Simple.PER_ESTADO, Simple.PER_FECHA_ALTA, Simple.PER_FECHA_VENC, Simple.PER_GARANTIA, Simple.PER_EXCESO_LINEA)

            'Simple3.MarkAsAdded()
            'vRespuestaLocal3 = Me.IBCRolPersonaTipoPersona.MantenimientoRolPersonaTipoPersona(Simple3)

            If vRespuestaLocal = 0 Then
                InsertarDatos = False
                Return InsertarDatos
            End If
            pRespuestaExtraerDetalle = ExtraerDetalle()
            InsertarDatos = (vRespuestaLocal > 0 And pRespuestaExtraerDetalle = 1)
        End Function
        Public Function Modificar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 0
            pRespuestaExtraerDetalle = 0
            Modificar = False
            DatosCabecera()
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
            Else
                vMensajeMostrar = 1
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
            If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Modificar
            InicializarOrm()
            Return Modificar
        End Function
        Private Function MensajeOperaciones(ByVal vRespuesta As Int16, _
                                            ByVal vOperacion As String) As Int16
            MensajeOperaciones = vRespuesta
            Select Case vRespuesta
                Case 0
                    If Not LlamadaDesdeFormularioCrear Then
                        If Not pLLamadaDesdeFormularioModificar Then
                            MsgBox("Registro " & vOperacion, MsgBoxStyle.Information, Me.Text)
                        End If
                    End If
                Case 1

                Case 2
                    MsgBox("Registro no fue " & vOperacion & " verifique sus datos" & _
                           Chr(13) & Chr(13) & Simple.vMensajeError & _
                           Chr(13) & Chr(13) & Simple1.vMensajeError & _
                           Chr(13) & Chr(13) & Simple2.vMensajeError & _
                           Chr(13) & Chr(13) & Simple3.vMensajeError, _
                           MsgBoxStyle.Information, Me.Text)
            End Select
            Return MensajeOperaciones
        End Function
        Private Sub ConfigurarDatosGrabados()
            ' Documento de identidad
            ReDim eRegistrosEliminarDocIdentidad(1)
            Dim vFilGrid As Int16 = 0
            While (dgvDocIdentidad.Rows.Count() > vFilGrid)
                With dgvDocIdentidad.Rows(vFilGrid)
                    .Cells("cEstadoRegistro").Value = True
                End With
                vFilGrid += 1
            End While

            ' Dirección de persona
            ReDim eRegistrosEliminarDireccionPersona(1)
            vFilGrid = 0
            While (dgvDireccionPersona.Rows.Count() > vFilGrid)
                With dgvDireccionPersona.Rows(vFilGrid)
                    .Cells("cEstadoRegistro1").Value = True
                End With
                vFilGrid += 1
            End While

            ' Contacto persona
            ReDim eRegistrosEliminarContactoPersona(1)
            vFilGrid = 0
            While (dgvContactoPersona.Rows.Count() > vFilGrid)
                With dgvContactoPersona.Rows(vFilGrid)
                    .Cells("cEstadoRegistro2").Value = True
                End With
                vFilGrid += 1
            End While
        End Sub
        Private Sub InicializarOrm()
            'InicializarOrmDetalle()
            'Simple = Nothing
            'Simple = New Ladisac.BE.Personas
            'FiltrarTabla()
        End Sub
        Private Function ActualizarDatos() As Boolean
            pRespuestaExtraerDetalle = ExtraerDetalle()
            If pRespuestaExtraerDetalle = 0 Then
                ActualizarDatos = False
                Return ActualizarDatos
            End If
            'Simple.MarkAsModified()
            'ActualizarDatos = (Me.IBCPersonas.MantenimientoPersonas(Simple) > 0 And pRespuestaExtraerDetalle = 1)
            ActualizarDatos = (Me.IBCPersonas.spActualizarRegistro(Simple.PER_ID, Simple.PER_CLIENTE, Simple.PER_CLIENTE_OP_CON, Simple.PER_PROVEEDOR, Simple.PER_PROVEEDOR_OP_CON, Simple.PER_TRANSPORTISTA, Simple.PER_TRANSPORTISTA_OP_CON, Simple.PER_TRABAJADOR, Simple.PER_TRABAJADOR_OP_CON, Simple.PER_BANCO, Simple.PER_BANCO_OP_CON, Simple.PER_GRUPO, Simple.PER_GRUPO_OP_CON, Simple.PER_CONTACTO, Simple.PER_CONTACTO_OP_CON, Simple.PER_TRANSP_PROPIO, Simple.PER_NOMBRES, Simple.PER_APE_PAT, Simple.PER_APE_MAT, Simple.PER_BREVETE, Simple.PER_FORMA_VENTA, Simple.DIR_ID, Simple.PER_TELEFONOS, Simple.PER_EMAIL, Simple.PER_PAGINA_WEB, Simple.PER_LINEA_CREDITO, Simple.PER_DIAS_CREDITO, Simple.PER_ID_VEN, Simple.PER_ID_COB, Simple.PER_ID_TRA, Simple.PER_ID_BAN, Simple.PER_ID_GRU, Simple.PER_DIASEM_PAGO, Simple.PER_COND_DIASEM, Simple.PER_DIAMES_PAGO, Simple.PER_DOC_PAGO, Simple.PER_HORA_PAGO, Simple.PER_OBSERVACIONES, Simple.PER_PROMOCIONES, Simple.PER_CARTA_FIANZA, Simple.PER_CUOTA_MENSUAL, Simple.PER_CUOTA_OBJETIVO, Simple.PER_BONO, Simple.CCC_ID, Simple.PER_CARGO, Simple.PER_REP_LEGAL, Simple.PER_FIRMA_AUT, Simple.PER_PROCESAR_DESCUENTO, Simple.PER_ALIAS, Simple.PER_LINEA_CREDITO_ESTADO, Simple.USU_ID, Simple.PER_FEC_GRAB, Simple.PER_ESTADO, Simple.PER_FECHA_ALTA, Simple.PER_FECHA_VENC, Simple.PER_GARANTIA, Simple.PER_EXCESO_LINEA) > 0 And pRespuestaExtraerDetalle = 1)
        End Function
        Private Function ExtraerDetalle() As Int16
            ExtraerDetalle = EliminarRegistroDetalle(1) ' Documento de identidad
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = EliminarRegistroDetalle(2) ' Dirección de persona
            If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = EliminarRegistroDetalle(3) ' Contacto de persona
            If ExtraerDetalle = 0 Then Exit Function

            'ExtraerDetalle = EliminarRegistroDetalle(4) ' Tipo cliente
            'If ExtraerDetalle = 0 Then Exit Function

            ExtraerDetalle = ProcesarDatosDetalle()
            Return ExtraerDetalle
        End Function
        Private Function EliminarRegistroDetalle(ByVal vCaso As Integer) As Int16
            EliminarRegistroDetalle = 1
            Select Case vCaso
                Case 1 ' Documento de identidad
                    For fila = 0 To dgvDocIdentidad.RowCount - 1
                        If Len(Trim(dgvDocIdentidad.Item("cDOP_NUMERO", fila).Value)) = 0 And _
                            dgvDocIdentidad.Item("cEstadoRegistro", fila).Value = 1 Then
                            vMensajeErrorOrm = ""
                            InicializarOrmDetalle(1)
                            EliminarRegistroDetalle = Me.IBCDocPersonas.EliminarRegistro(txtPER_ID.Text, dgvDocIdentidad.Item("cTDP_ID", fila).Value)
                            If EliminarRegistroDetalle = 0 Then
                                vMensajeErrorOrm = vMensajeErrorOrm & Chr(13) & Simple2.vMensajeError
                                Exit For
                            End If
                        End If
                    Next
                Case 2 ' Dirección de persona
                    For fila = 0 To dgvDireccionPersona.RowCount - 1
                        If Len(Trim(dgvDireccionPersona.Item("cDIR_DESCRIPCION1", fila).Value)) = 0 And _
                            dgvDireccionPersona.Item("cEstadoRegistro1", fila).Value = 1 Then
                            vMensajeErrorOrm = ""
                            InicializarOrmDetalle(2)
                            EliminarRegistroDetalle = Me.IBCDireccionesPersonas.spEliminarRegistro(dgvDireccionPersona.Item("cDIR_ID1", fila).Value, txtPER_ID.Text)
                            If EliminarRegistroDetalle = 0 Then
                                vMensajeErrorOrm = vMensajeErrorOrm & Chr(13) & Simple1.vMensajeError
                                Exit For
                            End If
                        End If
                    Next
                Case 3 ' Contacto de persona
                    For fila = 0 To dgvContactoPersona.RowCount - 1
                        If Len(Trim(dgvContactoPersona.Item("cCOP_DESCRIPCION2", fila).Value)) = 0 And _
                            dgvContactoPersona.Item("cEstadoRegistro2", fila).Value = 1 Then
                            vMensajeErrorOrm = ""
                            InicializarOrmDetalle(3)
                            EliminarRegistroDetalle = Me.IBCContactoPersona.EliminarRegistro(txtPER_ID.Text, dgvContactoPersona.Item("cCOP_ID2", fila).Value)
                            If EliminarRegistroDetalle = 0 Then
                                vMensajeErrorOrm = vMensajeErrorOrm & Chr(13) & Simple5.vMensajeError
                                Exit For
                            End If
                        End If
                    Next
                Case 4 ' Tipo cliente
            End Select
            Return EliminarRegistroDetalle
        End Function
        Private Function ProcesarDatosDetalle() As Int16
            Dim vFilGrid As Integer = 0
            ProcesarDatosDetalle = 1

            While (dgvDocIdentidad.Rows.Count() > vFilGrid)
                With dgvDocIdentidad.Rows(vFilGrid)
                    vMensajeErrorOrm = ""
                    InicializarOrmDetalle(1)
                    If Len(Trim(.Cells("cDOP_NUMERO").Value)) = .Cells("cTDP_LONGITUD").Value Then
                        ' DocPersonas
                        Simple2.PER_ID = txtPER_ID.Text
                        Simple2.TDP_ID = .Cells("cTDP_ID").Value
                        Simple2.DOP_NUMERO = .Cells("cDOP_NUMERO").Value

                        Simple2.USU_ID = SessionService.UserId
                        Simple2.DOP_FEC_GRAB = Now

                        Simple2.DOP_ESTADO = DevolverTiposCampos("DOP_ESTADO", .Cells("cDOP_ESTADO").Value.ToString, Simple2)

                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgvDocIdentidad, vMensajeErrorOrm & " En fila: " & vFilGrid + 1)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If Not Validar("Detalle", vFilGrid + 1) Then
                            Simple2.vMensajeError += " En fila: " & vFilGrid + 1
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If (.Cells("cEstadoRegistro").Value = 1 Or .Cells("cEstadoRegistro").Value = True) Then
                            'Simple2.MarkAsModified()
                            'ProcesarDatosDetalle = Me.IBCDocPersonas.MantenimientoDocPersonas(Simple2)
                            ProcesarDatosDetalle = IBCDocPersonas.ActualizarRegistro(Simple2.PER_ID, Simple2.TDP_ID, Simple2.DOP_NUMERO, Simple2.USU_ID, Simple2.DOP_FEC_GRAB, Simple2.DOP_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Simple2.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        Else
                            'Simple2.MarkAsAdded()
                            'ProcesarDatosDetalle = Me.IBCDocPersonas.MantenimientoDocPersonas(Simple2)
                            ProcesarDatosDetalle = IBCDocPersonas.InsertarRegistro(Simple2.PER_ID, Simple2.TDP_ID, Simple2.DOP_NUMERO, Simple2.USU_ID, Simple2.DOP_FEC_GRAB, Simple2.DOP_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Simple2.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        End If
                    End If
                End With
                vFilGrid += 1
            End While

            vFilGrid = 0
            While (dgvDireccionPersona.Rows.Count() > vFilGrid)
                With dgvDireccionPersona.Rows(vFilGrid)
                    vMensajeErrorOrm = ""
                    InicializarOrmDetalle(2)
                    'MsgBox(Me.IBCBusqueda.NuevoCodigoDireccionPersona())

                    If Len(Trim(.Cells("cDIR_DESCRIPCION1").Value)) <> 0 Then
                        ' DireccionPersona
                        Simple1.DIR_ID = .Cells("cDIR_ID1").Value
                        Simple1.PER_ID = txtPER_ID.Text
                        Simple1.DIR_DESCRIPCION = .Cells("cDIR_DESCRIPCION1").Value
                        Simple1.DIR_TIPO = DevolverTiposCampos("DIR_TIPO", .Cells("cDIR_TIPO1").Value.ToString, Simple1)
                        Simple1.DIR_REFERENCIA = .Cells("cDIR_REFERENCIA1").Value
                        Simple1.DIS_ID = .Cells("cDIS_ID1").Value
                        Simple1.USU_ID = SessionService.UserId
                        Simple1.DIR_FEC_GRAB = Now
                        Simple1.DIR_ESTADO = DevolverTiposCampos("DIR_ESTADO", .Cells("cDIR_ESTADO1").Value.ToString, Simple1)

                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgvDireccionPersona, vMensajeErrorOrm & " En fila: " & vFilGrid + 1)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If Not Validar("Detalle1", vFilGrid + 1) Then
                            Simple1.vMensajeError += " En fila: " & vFilGrid + 1
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If (.Cells("cEstadoRegistro1").Value = 1 Or .Cells("cEstadoRegistro1").Value = True) Then
                            'Simple1.MarkAsModified()
                            'ProcesarDatosDetalle = Me.IBCDireccionesPersonas.MantenimientoDireccionesPersonas(Simple1)
                            ProcesarDatosDetalle = IBCDireccionesPersonas.spActualizarRegistro(Simple1.DIR_ID, Simple1.PER_ID, Simple1.DIR_DESCRIPCION, Simple1.DIR_TIPO, Simple1.DIR_REFERENCIA, Simple1.DIS_ID, Simple1.USU_ID, Simple1.DIR_FEC_GRAB, Simple1.DIR_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Simple1.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        Else
                            'Simple1.MarkAsAdded()
                            'ProcesarDatosDetalle = Me.IBCDireccionesPersonas.MantenimientoDireccionesPersonas(Simple1)
                            ProcesarDatosDetalle = IBCDireccionesPersonas.spInsertarRegistro(Simple1.DIR_ID, Simple1.PER_ID, Simple1.DIR_DESCRIPCION, Simple1.DIR_TIPO, Simple1.DIR_REFERENCIA, Simple1.DIS_ID, Simple1.USU_ID, Simple1.DIR_FEC_GRAB, Simple1.DIR_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Simple1.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        End If
                    End If
                End With
                vFilGrid += 1
            End While

            vFilGrid = 0
            While (dgvContactoPersona.Rows.Count() > vFilGrid)
                With dgvContactoPersona.Rows(vFilGrid)
                    vMensajeErrorOrm = ""
                    InicializarOrmDetalle(3)
                    If Len(Trim(.Cells("cCOP_DESCRIPCION2").Value)) <> 0 Then
                        ' ContactoPersona
                        Simple5.PER_ID = txtPER_ID.Text
                        Simple5.COP_ID = .Cells("cCOP_ID2").Value
                        Simple5.COP_TIPO = DevolverTiposCampos("COP_TIPO", .Cells("cCOP_TIPO2").Value.ToString, Simple5)
                        Simple5.COP_DESCRIPCION = .Cells("cCOP_DESCRIPCION2").Value
                        Simple5.COP_DIRECCION = .Cells("cCOP_DIRECCION2").Value
                        Simple5.COP_TELEFONO = .Cells("cCOP_TELEFONO2").Value
                        Simple5.COP_EMAIL = .Cells("cCOP_EMAIL2").Value

                        Simple5.USU_ID = SessionService.UserId
                        Simple5.COP_FEC_GRAB = Now
                        Simple5.COP_ESTADO = DevolverTiposCampos("COP_ESTADO", .Cells("cCOP_ESTADO2").Value.ToString, Simple5)

                        If vMensajeErrorOrm <> "" Then
                            ErrorProvider1.SetError(dgvContactoPersona, vMensajeErrorOrm & " En fila: " & vFilGrid + 1)
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If Not Validar("Detalle2", vFilGrid + 1) Then
                            Simple5.vMensajeError += " En fila: " & vFilGrid + 1
                            ProcesarDatosDetalle = -1
                            Exit Function
                        End If
                        If (.Cells("cEstadoRegistro2").Value = 1 Or .Cells("cEstadoRegistro2").Value = True) Then
                            'Simple5.MarkAsModified()
                            'ProcesarDatosDetalle = Me.IBCContactoPersona.Mantenimiento(Simple5)
                            ProcesarDatosDetalle = Me.IBCContactoPersona.ActualizarRegistro(Simple5.PER_ID, Simple5.COP_ID, Simple5.COP_TIPO, Simple5.COP_DESCRIPCION, Simple5.COP_DIRECCION, Simple5.COP_TELEFONO, Simple5.COP_EMAIL, Simple5.USU_ID, Simple5.COP_FEC_GRAB, Simple5.COP_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Simple5.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        Else
                            'Simple5.MarkAsAdded()
                            'ProcesarDatosDetalle = Me.IBCContactoPersona.Mantenimiento(Simple5)
                            ProcesarDatosDetalle = Me.IBCContactoPersona.InsertarRegistro(Simple5.PER_ID, Simple5.COP_ID, Simple5.COP_TIPO, Simple5.COP_DESCRIPCION, Simple5.COP_DIRECCION, Simple5.COP_TELEFONO, Simple5.COP_EMAIL, Simple5.USU_ID, Simple5.COP_FEC_GRAB, Simple5.COP_ESTADO)
                            If ProcesarDatosDetalle = 0 Then
                                vMensajeErrorOrm = Simple5.vMensajeError & " En fila: " & vFilGrid + 1
                                Exit Function
                            End If
                        End If
                    End If
                End With
                vFilGrid += 1
            End While

            vFilGrid = 0
            vMensajeErrorOrm = ""
            InicializarOrmDetalle(4)
            ' TipoCliente

            'If vTipoCliente <> cboTipoCliente.SelectedValue Then
            If vVerificarExisteRolPersonaTipoPersona > 0 Then
                'ProcesarDatosDetalle = Me.IBCRolPersonaTipoPersona.DeleteRegistro(Simple3, txtPER_ID.Text, vTipoCliente)
                ProcesarDatosDetalle = Me.IBCRolPersonaTipoPersona.spEliminarRegistro(txtPER_ID.Text, vTipoCliente)
                If ProcesarDatosDetalle = 0 Then
                    vMensajeErrorOrm = Simple3.vMensajeError
                    Exit Function
                End If
            End If

            Simple3.PER_ID = txtPER_ID.Text
            Simple3.TPE_ID = cboTipoCliente.SelectedValue

            Simple3.USU_ID = SessionService.UserId
            Simple3.RTP_FEC_GRAB = Now
            Simple3.RTP_ESTADO = DevolverTiposCampos("RTP_ESTADO", "ACTIVO", Simple3)

            If Not Validar("Detalle3") Then
                ProcesarDatosDetalle = -1
                Exit Function
            End If

            'Simple3.MarkAsAdded()
            'ProcesarDatosDetalle = Me.IBCRolPersonaTipoPersona.MantenimientoRolPersonaTipoPersona(Simple3)
            ProcesarDatosDetalle = Me.IBCRolPersonaTipoPersona.spInsertarRegistro(Simple3.PER_ID, Simple3.TPE_ID, Simple3.USU_ID, Simple3.RTP_FEC_GRAB, Simple3.RTP_ESTADO)
            If ProcesarDatosDetalle = 0 Then
                vMensajeErrorOrm = Simple3.vMensajeError
                Exit Function
            End If
            'Else

            'End If
            Return ProcesarDatosDetalle
        End Function
        Private Sub InicializarOrmDetalle(ByVal vCaso As Integer)
            Select Case vCaso
                Case 1
                    'Simple2 = Nothing
                    'Simple2 = New Ladisac.BE.DocPersonas
                Case 2
                    'Simple1 = Nothing
                    'Simple1 = New Ladisac.BE.DireccionesPersonas
                Case 3
                    'Simple5 = Nothing
                    'Simple5 = New Ladisac.BE.ContactoPersona
                Case 4
                    'Simple3 = Nothing
                    'Simple3 = New Ladisac.BE.RolPersonaTipoPersona
            End Select
        End Sub

        Private Function EliminarRegistro() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            Using Scope As New System.Transactions.TransactionScope()
                bRes = PrepararRegistroEliminar()
                If (IBCPersonas.spEliminarRegistro(txtPER_ID.Text) > 0 And bRes) Then
                    Scope.Complete()
                    EliminarRegistro = True
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, Me.Text)
                Else
                    Scope.Dispose()
                    EliminarRegistro = False

                    MsgBox("No se pudo eliminar verifique sus datos" & Chr(13) & Chr(13) & _
                           IBCPersonas.pMensajeError & Chr(13) & _
                           Simple.vMensajeError & Chr(13) & _
                           Simple1.vMensajeError & Chr(13) & _
                           Simple2.vMensajeError & Chr(13) & _
                           Simple3.vMensajeError & Chr(13) & _
                           Simple4.vMensajeError & Chr(13) & _
                           Simple5.vMensajeError, _
                           MsgBoxStyle.Information, Me.Text)
                End If
            End Using
            'Simple = Nothing
            'Simple = New Ladisac.BE.Personas

            'Simple1 = Nothing
            'Simple1 = New Ladisac.BE.DireccionesPersonas

            'Simple2 = Nothing
            'Simple2 = New Ladisac.BE.DocPersonas

            'Simple3 = Nothing
            'Simple3 = New Ladisac.BE.RolPersonaTipoPersona

            Me.Cursor = Windows.Forms.Cursors.Default
            Return EliminarRegistro
        End Function

        ' ojito
        Private Function PrepararRegistroEliminar() As Boolean
            PrepararRegistroEliminar = False

            If IBCPersonas.spActualizarPersonasDIR_ID(txtPER_ID.Text, Nothing) > 0 Then
                PrepararRegistroEliminar = True
            Else
                PrepararRegistroEliminar = False
                Return PrepararRegistroEliminar
            End If

            If IBCContactoPersona.spEliminarContactoPersonaPER_ID(txtPER_ID.Text) > 0 Then
                PrepararRegistroEliminar = True
            Else
                PrepararRegistroEliminar = False
                Return PrepararRegistroEliminar
            End If

            If IBCDireccionesPersonas.spEliminarDireccionesPersonasPER_ID(txtPER_ID.Text) > 0 Then
                PrepararRegistroEliminar = True
            Else
                PrepararRegistroEliminar = False
                Return PrepararRegistroEliminar
            End If

            If IBCDocPersonas.spEliminarDocPersonasPER_ID(txtPER_ID.Text) > 0 Then
                PrepararRegistroEliminar = True
            Else
                PrepararRegistroEliminar = False
                Return PrepararRegistroEliminar
            End If

            If IBCRolPersonaTipoPersona.spEliminarRolPersonaTipoPersonaPER_ID(txtPER_ID.Text) > 0 Then
                PrepararRegistroEliminar = True
            Else
                PrepararRegistroEliminar = False
                Return PrepararRegistroEliminar
            End If

            Return PrepararRegistroEliminar
        End Function
        Private Sub NavegarGrid(ByVal Metodo As String)
            cMisProcedimientos.PosicionGrid(Metodo, ActiveControl, Me.Text)
        End Sub

        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID_VEN" Then EtxtPER_ID_VEN.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_COB" Then EtxtPER_ID_COB.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_TRA" Then EtxtPER_ID_TRA.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_BAN" Then EtxtPER_ID_BAN.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_GRU" Then EtxtPER_ID_GRU.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCC_ID_CLI" Then EtxtCCC_ID_CLI.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID_VEN" Then EtxtPER_ID_VEN.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_COB" Then EtxtPER_ID_COB.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_TRA" Then EtxtPER_ID_TRA.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_BAN" Then EtxtPER_ID_BAN.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_GRU" Then EtxtPER_ID_GRU.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtCCC_ID_CLI" Then EtxtCCC_ID_CLI.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function

        Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles MyBase.Load
            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                LongitudId = 6
                CaracterId = "0"
                ConfigurarCheck()
                ConfigurarComboBox()
                ConfigurarText()
                AdicionarElementoCombosEdicion()
                ConfigurarDataGridView()
                ComportamientoFormulario()

                If Comportamiento = -1 Then BusquedaDatos("Load")
                If LlamadaDesdeFormularioModificar Then Comportamiento = 0

                FormatearCampos(txtPER_ID, "PER_ID", EtxtPER_ID)
                FormatearCampos(txtPER_APE_PAT, "PER_APE_PAT", EtxtPER_APE_PAT)
                FormatearCampos(txtPER_APE_MAT, "PER_APE_MAT", EtxtPER_APE_MAT)
                FormatearCampos(txtPER_NOMBRES, "PER_NOMBRES", EtxtPER_NOMBRES)
                FormatearCampos(cboPER_CLIENTE_OP_CON, "PER_CLIENTE_OP_CON", Nothing)
                FormatearCampos(cboPER_PROVEEDOR_OP_CON, "PER_PROVEEDOR_OP_CON", Nothing)
                FormatearCampos(cboPER_TRANSPORTISTA_OP_CON, "PER_TRANSPORTISTA_OP_CON", Nothing)
                FormatearCampos(cboPER_TRABAJADOR_OP_CON, "PER_TRABAJADOR_OP_CON", Nothing)
                FormatearCampos(cboPER_BANCO_OP_CON, "PER_BANCO_OP_CON", Nothing)
                FormatearCampos(cboPER_GRUPO_OP_CON, "PER_GRUPO_OP_CON", Nothing)
                FormatearCampos(cboPER_CONTACTO_OP_CON, "PER_CONTACTO_OP_CON", Nothing)
                FormatearCampos(cboPER_TRANSP_PROPIO, "PER_TRANSP_PROPIO", Nothing)
                FormatearCampos(txtPER_BREVETE, "PER_BREVETE", EtxtPER_BREVETE)
                FormatearCampos(txtPER_ID_VEN, "PER_ID_VEN", EtxtPER_ID_VEN)
                FormatearCampos(txtPER_TELEFONOS, "PER_TELEFONOS", EtxtPER_TELEFONOS, False)
                FormatearCampos(txtPER_EMAIL, "PER_EMAIL", EtxtPER_EMAIL, False)
                FormatearCampos(txtPER_PAGINA_WEB, "PER_PAGINA_WEB", EtxtPER_PAGINA_WEB, False)
                FormatearCampos(txtPER_LINEA_CREDITO, "PER_LINEA_CREDITO", EtxtPER_LINEA_CREDITO, False)
                FormatearCampos(txtPER_DIAS_CREDITO, "PER_DIAS_CREDITO", EtxtPER_DIAS_CREDITO, False)
                FormatearCampos(txtPER_ID_VEN, "PER_ID_VEN", EtxtPER_ID_VEN)
                FormatearCampos(txtPER_ID_COB, "PER_ID_COB", EtxtPER_ID_COB)
                FormatearCampos(txtPER_ID_TRA, "PER_ID_TRA", EtxtPER_ID_TRA)
                FormatearCampos(txtPER_ID_BAN, "PER_ID_BAN", EtxtPER_ID_BAN)
                FormatearCampos(txtPER_ID_GRU, "PER_ID_GRU", EtxtPER_ID_GRU)
                FormatearCampos(cboPER_DIASEM_PAGO, "PER_DIASEM_PAGO", Nothing)
                FormatearCampos(cboPER_COND_DIASEM, "PER_COND_DIASEM", Nothing)
                FormatearCampos(txtPER_DIAMES_PAGO, "PER_DIAMES_PAGO", EtxtPER_DIAMES_PAGO)
                FormatearCampos(cboPER_DOC_PAGO, "PER_DOC_PAGO", Nothing)
                FormatearCampos(txtPER_HORA_PAGO, "PER_HORA_PAGO", EtxtPER_HORA_PAGO)
                FormatearCampos(txtPER_OBSERVACIONES, "PER_OBSERVACIONES", EtxtPER_OBSERVACIONES, False)
                FormatearCampos(cboPER_FORMA_VENTA, "PER_FORMA_VENTA", Nothing)
                FormatearCampos(txtCCC_ID_CLI, "CCC_ID_CLI", EtxtCCC_ID_CLI)
                FormatearCampos(txtPER_CARGO, "PER_CARGO", EtxtPER_CARGO, False)

                tcoDatos.SelectedIndex = 0
                lblPER_TELEFONOS.Visible = True
                lblPER_TELEFONOS.Enabled = True
                txtPER_TELEFONOS.Visible = True
                txtPER_TELEFONOS.Enabled = True

                lblPER_EMAIL.Visible = True
                lblPER_EMAIL.Enabled = True
                txtPER_EMAIL.Visible = True
                txtPER_EMAIL.Enabled = True

                lblPER_PAGINA_WEB.Visible = True
                lblPER_PAGINA_WEB.Enabled = True
                txtPER_PAGINA_WEB.Visible = True
                txtPER_PAGINA_WEB.Enabled = True

                MostrarMedioContacto(True)
                MostrarDocIdentidad(False)
                MostrarDirecciones(False)
                MostrarContactos(False)
                MostrarFormaVenta(False)

                MostrarEsCliente(True)
                MostrarEsVendedor(False)
                MostrarEsTransportista(False)
                MostrarEsBanco(False)
                MostrarFinanzas(False)

                If pComportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If

                If pLLamadaDesdeFormularioCrear Then
                    NuevoRegistro()
                    ConfigurarCamposLlamadaDesdeFormulario()
                End If

                If pLLamadaDesdeFormularioModificar Then
                    tsBarra.Enabled = True
                    EditarRegistro()
                    CamposMostrarLlamadaDesdeFormulario()
                End If


                If Not SessionService.ModificarFormaVentaEnPersona Then RemoverTabs(tcoDatos, tpaFormaVenta)
                If Not SessionService.ModificarEsBancoEnPersona Then RemoverTabs(tcoDatos1, tpaEsBanco)
                If Not SessionService.ModificarFinanzasEnPersona Then RemoverTabs(tcoDatos1, tpaFinanzas)
                If Not SessionService.ModificarObservacionesEnPersona Then txtPER_OBSERVACIONES.Enabled = False
                If Not SessionService.ModificarContactoEnPersona Then
                    lblPER_CONTACTO.Visible = False
                    chkPER_CONTACTO.Visible = False
                    chkPER_CONTACTO.Enabled = False
                Else
                    lblPER_CONTACTO.Visible = True
                    chkPER_CONTACTO.Visible = True
                    chkPER_CONTACTO.Enabled = True
                End If


            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load")
            End Try
        End Sub

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

                InicializarTexto(vObjeto)
            End If
        End Sub
        Private Sub InicializarTexto(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "PER_CLIENTE"
                    With chkPER_CLIENTE
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_PROVEEDOR"
                    With chkPER_PROVEEDOR
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_TRANSPORTISTA"
                    With chkPER_TRANSPORTISTA
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_TRABAJADOR"
                    With chkPER_TRABAJADOR
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_BANCO"
                    With chkPER_BANCO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_GRUPO"
                    With chkPER_GRUPO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_CONTACTO"
                    With chkPER_CONTACTO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_PROMOCIONES"
                    With chkPER_PROMOCIONES
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_REP_LEGAL"
                    With chkPER_REP_LEGAL
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_FIRMA_AUT"
                    With chkPER_FIRMA_AUT
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_LINEA_CREDITO_ESTADO"
                    With chkPER_LINEA_CREDITO_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_ESTADO"
                    With chkPER_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTexto(EchkPER_CLIENTE)
            InicializarTexto(EchkPER_PROVEEDOR)
            InicializarTexto(EchkPER_TRANSPORTISTA)
            InicializarTexto(EchkPER_TRABAJADOR)
            InicializarTexto(EchkPER_BANCO)
            InicializarTexto(EchkPER_GRUPO)
            InicializarTexto(EchkPER_CONTACTO)
            InicializarTexto(EchkPER_PROMOCIONES)
            InicializarTexto(EchkPER_REP_LEGAL)
            InicializarTexto(EchkPER_FIRMA_AUT)
            InicializarTexto(EchkPER_LINEA_CREDITO_ESTADO)
            InicializarTexto(EchkPER_ESTADO)
        End Sub
        Private Sub ConfigurarComboBox()
            EcboPER_CLIENTE_OP_CON.pNombreCampo = "PER_CLIENTE_OP_CON"
            cboPER_CLIENTE_OP_CON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_PROVEEDOR_OP_CON.pNombreCampo = "PER_PROVEEDOR_OP_CON"
            cboPER_PROVEEDOR_OP_CON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_TRANSPORTISTA_OP_CON.pNombreCampo = "PER_TRANSPORTISTA_OP_CON"
            cboPER_TRANSPORTISTA_OP_CON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_TRABAJADOR_OP_CON.pNombreCampo = "PER_TRABAJADOR_OP_CON"
            cboPER_TRABAJADOR_OP_CON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_BANCO_OP_CON.pNombreCampo = "PER_BANCO_OP_CON"
            cboPER_BANCO_OP_CON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_GRUPO_OP_CON.pNombreCampo = "PER_GRUPO_OP_CON"
            cboPER_GRUPO_OP_CON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_CONTACTO_OP_CON.pNombreCampo = "PER_CONTACTO_OP_CON"
            cboPER_CONTACTO_OP_CON.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_TRANSP_PROPIO.pNombreCampo = "PER_TRANSP_PROPIO"
            cboPER_TRANSP_PROPIO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_FORMA_VENTA.pNombreCampo = "PER_FORMA_VENTA"
            cboPER_FORMA_VENTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_DIASEM_PAGO.pNombreCampo = "PER_DIASEM_PAGO"
            cboPER_DIASEM_PAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_COND_DIASEM.pNombreCampo = "PER_COND_DIASEM"
            cboPER_COND_DIASEM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_DOC_PAGO.pNombreCampo = "PER_DOC_PAGO"
            cboPER_DOC_PAGO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboPER_CARTA_FIANZA.pNombreCampo = "PER_CARTA_FIANZA"
            cboPER_CARTA_FIANZA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        End Sub
        Private Sub ConfigurarText()
            Dim EtxtTemporal As New txt
            EtxtTemporal.pTexto1 = ""
            EtxtTemporal.pTexto2 = ""
            EtxtTemporal.pSoloNumerosDecimales = False
            EtxtTemporal.pSoloNumeros = False
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

            EtxtPER_ID = EtxtTemporal
            EtxtPER_APE_PAT = EtxtTemporal
            EtxtPER_APE_MAT = EtxtTemporal
            EtxtPER_NOMBRES = EtxtTemporal
            EtxtPER_BREVETE = EtxtTemporal
            EtxtPER_TELEFONOS = EtxtTemporal
            EtxtPER_EMAIL = EtxtTemporal
            EtxtPER_PAGINA_WEB = EtxtTemporal

            EtxtPER_LINEA_CREDITO = EtxtTemporal
            EtxtPER_LINEA_CREDITO.pSoloNumerosDecimales = True

            EtxtPER_DIAS_CREDITO = EtxtTemporal
            EtxtPER_DIAS_CREDITO.pSoloNumeros = True

            EtxtPER_DIAMES_PAGO = EtxtTemporal
            EtxtPER_DIAMES_PAGO.pSoloNumeros = True

            EtxtPER_HORA_PAGO = EtxtTemporal
            EtxtPER_OBSERVACIONES = EtxtTemporal
            EtxtPER_CARGO = EtxtTemporal

            EtxtTemporal.pBusqueda = True
            EtxtTemporal.pFormularioConsulta = True

            EtxtPER_ID_VEN = EtxtTemporal
            EtxtPER_ID_COB = EtxtTemporal
            EtxtPER_ID_TRA = EtxtTemporal
            EtxtPER_ID_BAN = EtxtTemporal
            EtxtPER_ID_GRU = EtxtTemporal
            EtxtCCC_ID_CLI = EtxtTemporal

            EtxtDIS_ID = EtxtTemporal

            EtxtPER_ID.pOrdenBusqueda = 4
            EtxtPER_ID.pComportamiento = 0

            EtxtPER_ID_VEN.pOOrm = New Ladisac.BE.RolPersonaTipoPersona
            EtxtPER_ID_VEN.pComportamiento = 2
            EtxtPER_ID_VEN.pOrdenBusqueda = 1
            EtxtPER_ID_VEN.pMostrarDatosGrid = True

            EtxtPER_ID_COB.pOOrm = New Ladisac.BE.RolPersonaTipoPersona
            EtxtPER_ID_COB.pComportamiento = 3
            EtxtPER_ID_COB.pOrdenBusqueda = 1
            EtxtPER_ID_COB.pMostrarDatosGrid = True

            EtxtPER_ID_TRA.pOOrm = New Ladisac.BE.RolPersonaTipoPersona
            EtxtPER_ID_TRA.pComportamiento = 4
            EtxtPER_ID_TRA.pOrdenBusqueda = 1
            EtxtPER_ID_TRA.pMostrarDatosGrid = True

            EtxtPER_ID_BAN.pOOrm = New Ladisac.BE.RolPersonaTipoPersona
            EtxtPER_ID_BAN.pComportamiento = 5
            EtxtPER_ID_BAN.pOrdenBusqueda = 1
            EtxtPER_ID_BAN.pMostrarDatosGrid = True

            EtxtPER_ID_GRU.pOOrm = New Ladisac.BE.RolPersonaTipoPersona
            EtxtPER_ID_GRU.pComportamiento = 6
            EtxtPER_ID_GRU.pOrdenBusqueda = 1
            EtxtPER_ID_GRU.pMostrarDatosGrid = True

            EtxtDIS_ID.pOOrm = New Ladisac.BE.Distrito
            EtxtDIS_ID.pComportamiento = 7
            EtxtDIS_ID.pOrdenBusqueda = 1
            EtxtDIS_ID.pMostrarDatosGrid = True

            EtxtCCC_ID_CLI.pOOrm = New Ladisac.BE.CajaCtaCte
            EtxtCCC_ID_CLI.pComportamiento = 8
            EtxtCCC_ID_CLI.pOrdenBusqueda = 5
            EtxtCCC_ID_CLI.pMostrarDatosGrid = True
        End Sub
        Private Sub AdicionarElementoCombosEdicion()
            BuscarFormatos(EcboPER_CLIENTE_OP_CON, Simple, cboPER_CLIENTE_OP_CON, 0)
            BuscarFormatos(EcboPER_PROVEEDOR_OP_CON, Simple, cboPER_PROVEEDOR_OP_CON, 0)
            BuscarFormatos(EcboPER_TRANSPORTISTA_OP_CON, Simple, cboPER_TRANSPORTISTA_OP_CON, 0)
            BuscarFormatos(EcboPER_TRABAJADOR_OP_CON, Simple, cboPER_TRABAJADOR_OP_CON, 0)
            BuscarFormatos(EcboPER_BANCO_OP_CON, Simple, cboPER_BANCO_OP_CON, 0)
            BuscarFormatos(EcboPER_GRUPO_OP_CON, Simple, cboPER_GRUPO_OP_CON, 0)
            BuscarFormatos(EcboPER_CONTACTO_OP_CON, Simple, cboPER_CONTACTO_OP_CON, 0)
            BuscarFormatos(EcboPER_TRANSP_PROPIO, Simple, cboPER_TRANSP_PROPIO, 0)
            BuscarFormatos(EcboPER_FORMA_VENTA, Simple, cboPER_FORMA_VENTA, 0)
            BuscarFormatos(EcboPER_FORMA_VENTA, Simple, cboPER_FORMA_VENTA, 0)
            BuscarFormatos(EcboPER_DIASEM_PAGO, Simple, cboPER_DIASEM_PAGO, 0)
            BuscarFormatos(EcboPER_COND_DIASEM, Simple, cboPER_COND_DIASEM, 0)
            BuscarFormatos(EcboPER_DOC_PAGO, Simple, cboPER_DOC_PAGO, 0)
            BuscarFormatos(EcboPER_CARTA_FIANZA, Simple, cboPER_CARTA_FIANZA, 0)
        End Sub
        Private Sub BuscarFormatos(ByRef vObjeto As cbo, _
                                   ByVal oSimple As Object, _
                                   ByRef oComboBox As ComboBox, _
                                   ByVal vOrdenBusqueda As Int16)
            oSimple.CampoId = vObjeto.pNombreCampo
            'Select Case vObjeto.pNombreCampo
            'Case "LPR_PRINCIPAL"
            cMisProcedimientos.AdicionarElementoCombosEdicion(oComboBox, oSimple.BuscarFormatos(), vOrdenBusqueda)
            'End Select
        End Sub

#End Region

#Region "Primaria 3"
        Private Sub BusquedaDatos(ByVal vProceso As String)
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
                        frm.oOrm = Simple
                        frm.Comportamiento = pComportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = pOrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "PrepararEliminar"
                        Simple.CampoPrincipalValor = pCodigoId
                        Dim resp = Me.IBCBusqueda.RegistroAnterior(Simple.CampoPrincipal, _
                                                                   Simple.CampoPrincipalValor, _
                                                                   Simple.cTabla.NombreLargo)
                        DatoBusquedaConsulta = resp

                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 2
                        If pComportamiento = -1 Then
                            frm.TipoEdicion = 1
                            frm.DatoBusqueda = DatoBusquedaConsulta
                        End If
                        frm.DatoBusqueda = DatoBusquedaConsulta
                        frm.oOrm = Simple
                        frm.Comportamiento = pComportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = pOrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "BuscarUnRegistro"
                        Simple6.Vista = "BuscarRegistroConDocumento"
                        EtxtPER_ID.pOrdenBusqueda = 72
                        Simple6.pBuscarRegistros = False

                        DatoBusquedaConsulta = ""
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = ""
                        frm.oOrm = Simple6
                        frm.Comportamiento = pComportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = EtxtPER_ID.pOrdenBusqueda 'pOrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()

                        EtxtPER_ID.pOrdenBusqueda = 4
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
                            frm.oOrm = Simple
                            frm.Comportamiento = pComportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = pOrdenBusqueda
                            frm.ShowDialog()
                            frm.Dispose()
                        Else
                            OrmBusquedaDatos(vProceso)
                            Dim resp = Me.IBCBusqueda.PrimerRegistro(Simple.CampoPrincipal, _
                                                                     Simple.cTabla.NombreLargo)
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
                            frm.oOrm = Simple
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

        Private Sub NavegarFormulario(ByVal Metodo As String)
            Try
                If pnCuerpo.Enabled = True Then If RevisarDatos(False) Then Return
                Dim vCodigoId As String
                Dim resp As String = ""
                OrmBusquedaDatos("NavegarFormulario")
                Select Case Metodo
                    Case "PrimerRegistro"
                        resp = Me.IBCBusqueda.PrimerRegistro(Simple.CampoPrincipal, _
                                                             Simple.cTabla.NombreLargo)
                    Case "RegistroAnterior"
                        Simple.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroAnterior(Simple.CampoPrincipal, _
                                                               Simple.CampoPrincipalValor, _
                                                               Simple.cTabla.NombreLargo)
                    Case "RegistroSiguiente"
                        Simple.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroSiguiente(Simple.CampoPrincipal, _
                                                                Simple.CampoPrincipalValor, _
                                                                Simple.cTabla.NombreLargo)
                    Case "UltimoRegistro"
                        resp = Me.IBCBusqueda.UltimoRegistro(Simple.CampoPrincipal, _
                                                             Simple.cTabla.NombreLargo)
                End Select
                vCodigoId = resp
                If vCodigoId Is Nothing Or Trim(vCodigoId) = "" Then
                    MsgBox("¡No se encontro registros!", MsgBoxStyle.Information, Me.Text)
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
                frm.oOrm = Simple
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

#End Region

        Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles chkPER_CLIENTE.CheckedChanged, _
                    chkPER_PROVEEDOR.CheckedChanged, _
                    chkPER_TRANSPORTISTA.CheckedChanged, _
                    chkPER_TRABAJADOR.CheckedChanged, _
                    chkPER_BANCO.CheckedChanged, _
                    chkPER_GRUPO.CheckedChanged, _
                    chkPER_CONTACTO.CheckedChanged, _
                    chkPER_PROMOCIONES.CheckedChanged, _
                    chkPER_REP_LEGAL.CheckedChanged, _
                    chkPER_FIRMA_AUT.CheckedChanged, _
                    chkPER_LINEA_CREDITO_ESTADO.CheckedChanged, _
                    chkPER_ESTADO.CheckedChanged

            Select Case sender.name.ToString
                Case "chkPER_CLIENTE"
                    If EchkPER_CLIENTE.pFormatearTexto Then
                        InicializarTexto(EchkPER_CLIENTE)
                        'If pRegistroNuevo And chkPER_CLIENTE.CheckState = CheckState.Checked Then
                        '    txtRUC.Enabled = False
                        '    txtRUC.ReadOnly = True
                        '    txtDNI.Enabled = True
                        '    txtDNI.ReadOnly = False
                        'End If
                        'If pRegistroNuevo And chkPER_CLIENTE.CheckState = CheckState.Unchecked Then
                        '    If chkPER_PROVEEDOR.CheckState = CheckState.Checked Then
                        '        txtDNI.Enabled = False
                        '        txtDNI.ReadOnly = True

                        '        txtRUC.Enabled = True
                        '        txtRUC.ReadOnly = False
                        '    End If
                        'End If
                    End If
                Case "chkPER_PROVEEDOR"
                    If EchkPER_PROVEEDOR.pFormatearTexto Then
                        InicializarTexto(EchkPER_PROVEEDOR)
                        'If pRegistroNuevo And chkPER_PROVEEDOR.CheckState = CheckState.Checked Then
                        '    txtRUC.Enabled = True
                        '    txtRUC.ReadOnly = False
                        '    txtDNI.Enabled = False
                        '    txtDNI.ReadOnly = True
                        'End If
                        'If pRegistroNuevo And chkPER_PROVEEDOR.CheckState = CheckState.Unchecked Then
                        '    txtRUC.Enabled = False
                        '    txtRUC.ReadOnly = True
                        '    txtDNI.Enabled = True
                        '    txtDNI.ReadOnly = False
                        'End If
                    End If
                Case "chkPER_TRANSPORTISTA"
                    If EchkPER_TRANSPORTISTA.pFormatearTexto Then
                        InicializarTexto(EchkPER_TRANSPORTISTA)
                    End If
                Case "chkPER_TRABAJADOR"
                    If EchkPER_TRABAJADOR.pFormatearTexto Then
                        InicializarTexto(EchkPER_TRABAJADOR)
                    End If
                Case "chkPER_BANCO"
                    If EchkPER_BANCO.pFormatearTexto Then
                        InicializarTexto(EchkPER_BANCO)
                    End If
                Case "chkPER_GRUPO"
                    If EchkPER_GRUPO.pFormatearTexto Then
                        InicializarTexto(EchkPER_GRUPO)
                    End If
                Case "chkPER_CONTACTO"
                    If EchkPER_CONTACTO.pFormatearTexto Then
                        InicializarTexto(EchkPER_CONTACTO)
                    End If
                Case "chkPER_PROMOCIONES"
                    If EchkPER_PROMOCIONES.pFormatearTexto Then
                        InicializarTexto(EchkPER_PROMOCIONES)
                    End If
                Case "chkPER_REP_LEGAL"
                    If EchkPER_REP_LEGAL.pFormatearTexto Then
                        InicializarTexto(EchkPER_REP_LEGAL)
                    End If
                Case "chkPER_FIRMA_AUT"
                    If EchkPER_FIRMA_AUT.pFormatearTexto Then
                        InicializarTexto(EchkPER_FIRMA_AUT)
                    End If
                Case "chkPER_LINEA_CREDITO_ESTADO"
                    If EchkPER_LINEA_CREDITO_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkPER_LINEA_CREDITO_ESTADO)
                    End If
                Case "chkPER_ESTADO"
                    If EchkPER_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkPER_ESTADO)
                    End If
            End Select
        End Sub

        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles txtPER_ID.KeyDown, txtPER_APE_PAT.KeyDown, txtPER_APE_MAT.KeyDown, _
                    txtPER_NOMBRES.KeyDown, txtPER_BREVETE.KeyDown, _
                    txtPER_TELEFONOS.KeyDown, txtPER_EMAIL.KeyDown, _
                    txtPER_PAGINA_WEB.KeyDown, txtPER_LINEA_CREDITO.KeyDown, txtPER_DIAS_CREDITO.KeyDown, _
                    txtPER_ID_VEN.KeyDown, txtPER_ID_COB.KeyDown, txtPER_ID_TRA.KeyDown, _
                    txtPER_ID_BAN.KeyDown, txtPER_ID_GRU.KeyDown, txtPER_DIAMES_PAGO.KeyDown, _
                    txtPER_HORA_PAGO.KeyDown, txtPER_OBSERVACIONES.KeyDown, txtCCC_ID_CLI.KeyDown, _
                    txtPER_CARGO.KeyDown
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtCCC_ID_CLI"
                            TeclaF1(EtxtCCC_ID_CLI, txtCCC_ID_CLI)
                        Case "txtPER_ID_VEN"
                            TeclaF1(EtxtPER_ID_VEN, txtPER_ID_VEN)
                        Case "txtPER_ID_COB"
                            TeclaF1(EtxtPER_ID_COB, txtPER_ID_COB)
                        Case "txtPER_ID_TRA"
                            TeclaF1(EtxtPER_ID_TRA, txtPER_ID_TRA)
                        Case "txtPER_ID_BAN"
                            TeclaF1(EtxtPER_ID_BAN, txtPER_ID_BAN)
                        Case "txtPER_ID_GRU"
                            TeclaF1(EtxtPER_ID_GRU, txtPER_ID_GRU)
                    End Select
            End Select
        End Sub
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID.GotFocus, _
            txtCCC_ID_CLI.GotFocus, _
            txtPER_ID_VEN.GotFocus, _
            txtPER_ID_COB.GotFocus, _
            txtPER_ID_TRA.GotFocus, _
            txtPER_ID_BAN.GotFocus, _
            txtPER_ID_GRU.GotFocus

            Select Case sender.name.ToString
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto1 = sender.text
                Case "txtCCC_ID_CLI"
                    EtxtCCC_ID_CLI.pTexto1 = sender.text
                Case "txtPER_ID_VEN"
                    EtxtPER_ID_VEN.pTexto1 = sender.text
                Case "txtPER_ID_COB"
                    EtxtPER_ID_COB.pTexto1 = sender.text
                Case "txtPER_ID_TRA"
                    EtxtPER_ID_TRA.pTexto1 = sender.text
                Case "txtPER_ID_BAN"
                    EtxtPER_ID_BAN.pTexto1 = sender.text
                Case "txtPER_ID_GRU"
                    EtxtPER_ID_GRU.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID.LostFocus, _
            txtCCC_ID_CLI.LostFocus, _
             txtPER_ID_VEN.LostFocus, _
            txtPER_ID_COB.LostFocus, _
            txtPER_ID_TRA.LostFocus, _
            txtPER_ID_BAN.LostFocus, _
            txtPER_ID_GRU.LostFocus

            Select Case sender.name.ToString
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto2 = sender.text
                Case "txtCCC_ID_CLI"
                    EtxtCCC_ID_CLI.pTexto2 = sender.text
                Case "txtPER_ID_VEN"
                    EtxtPER_ID_VEN.pTexto2 = sender.text
                Case "txtPER_ID_COB"
                    EtxtPER_ID_COB.pTexto2 = sender.text
                Case "txtPER_ID_TRA"
                    EtxtPER_ID_TRA.pTexto2 = sender.text
                Case "txtPER_ID_BAN"
                    EtxtPER_ID_BAN.pTexto2 = sender.text
                Case "txtPER_ID_GRU"
                    EtxtPER_ID_GRU.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID.Validated, _
            txtCCC_ID_CLI.Validated, _
            txtPER_ID_VEN.Validated, _
            txtPER_ID_COB.Validated, _
            txtPER_ID_TRA.Validated, _
            txtPER_ID_BAN.Validated, _
            txtPER_ID_GRU.Validated, _
            txtPER_LINEA_CREDITO.Validated

            Select Case sender.name.ToString
                Case "txtPER_ID"
                    ValidarDatos(EtxtPER_ID, txtPER_ID)
                Case "txtCCC_ID_CLI"
                    ValidarDatos(EtxtCCC_ID_CLI, txtCCC_ID_CLI)
                Case "txtPER_ID_VEN"
                    ValidarDatos(EtxtPER_ID_VEN, txtPER_ID_VEN, txtPER_ID_VEN.Text & BCVariablesNames.TipoPersonas.Vendedor)
                Case "txtPER_ID_COB"
                    ValidarDatos(EtxtPER_ID_COB, txtPER_ID_COB, txtPER_ID_COB.Text & BCVariablesNames.TipoPersonas.Cobrador)
                Case "txtPER_ID_TRA"
                    ValidarDatos(EtxtPER_ID_TRA, txtPER_ID_TRA, txtPER_ID_TRA.Text & BCVariablesNames.TipoPersonas.Transportista)
                Case "txtPER_ID_BAN"
                    ValidarDatos(EtxtPER_ID_BAN, txtPER_ID_BAN, txtPER_ID_BAN.Text & BCVariablesNames.TipoPersonas.Banco)
                Case "txtPER_ID_GRU"
                    ValidarDatos(EtxtPER_ID_GRU, txtPER_ID_GRU, txtPER_ID_GRU.Text & BCVariablesNames.TipoPersonas.Grupo)
                Case "txtPER_LINEA_CREDITO"
                    ValidarDatos(EtxtPER_LINEA_CREDITO, txtPER_LINEA_CREDITO)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtPER_ID.KeyPress, _
                txtPER_APE_PAT.KeyPress, _
                txtPER_APE_MAT.KeyPress, _
                txtPER_NOMBRES.KeyPress, _
                txtPER_BREVETE.KeyPress, _
                txtPER_TELEFONOS.KeyPress, _
                txtPER_EMAIL.KeyPress, _
                txtPER_PAGINA_WEB.KeyPress, _
                txtPER_LINEA_CREDITO.KeyPress, _
                txtPER_DIAS_CREDITO.KeyPress, _
                txtPER_ID_VEN.KeyPress, _
                txtPER_ID_COB.KeyPress, _
                txtPER_ID_TRA.KeyPress, _
                txtPER_ID_BAN.KeyPress, _
                txtPER_ID_GRU.KeyPress, _
                txtPER_DIAMES_PAGO.KeyPress, _
                txtPER_HORA_PAGO.KeyPress, _
                txtPER_OBSERVACIONES.KeyPress, _
                txtCCC_ID_CLI.KeyPress, _
                txtPER_CARGO.KeyPress

            Select Case sender.name.ToString
                Case "txtPER_ID"
                    oKeyPress(EtxtPER_ID, e)
                Case "txtPER_APE_PAT"
                    oKeyPress(EtxtPER_APE_PAT, e)
                Case "txtPER_APE_MAT"
                    oKeyPress(EtxtPER_APE_MAT, e)
                Case "txtPER_NOMBRES"
                    oKeyPress(EtxtPER_NOMBRES, e)
                Case "txtPER_BREVETE"
                    oKeyPress(EtxtPER_BREVETE, e)
                Case "txtPER_TELEFONOS"
                    oKeyPress(EtxtPER_TELEFONOS, e)
                Case "txtPER_EMAIL"
                    oKeyPress(EtxtPER_EMAIL, e)
                Case "txtPER_PAGINA_WEB"
                    oKeyPress(EtxtPER_PAGINA_WEB, e)
                Case "txtPER_LINEA_CREDITO"
                    oKeyPress(EtxtPER_LINEA_CREDITO, e)
                Case "txtPER_DIAS_CREDITO"
                    oKeyPress(EtxtPER_DIAS_CREDITO, e)
                Case "txtPER_ID_VEN"
                    oKeyPress(EtxtPER_ID_VEN, e)
                Case "txtPER_ID_COB"
                    oKeyPress(EtxtPER_ID_COB, e)
                Case "txtPER_ID_TRA"
                    oKeyPress(EtxtPER_ID_TRA, e)
                Case "txtPER_ID_BAN"
                    oKeyPress(EtxtPER_ID_BAN, e)
                Case "txtPER_ID_GRU"
                    oKeyPress(EtxtPER_ID_GRU, e)
                Case "txtPER_DIAMES_PAGO"
                    oKeyPress(EtxtPER_DIAMES_PAGO, e)
                Case "txtPER_ID_VEN"
                    oKeyPress(EtxtPER_ID_VEN, e)
                Case "txtPER_ID_COB"
                    oKeyPress(EtxtPER_ID_COB, e)
                Case "txtPER_ID_GRU"
                    oKeyPress(EtxtPER_ID_GRU, e)
                Case "txtPER_HORA_PAGO"
                    oKeyPress(EtxtPER_HORA_PAGO, e)
                Case "txtPER_OBSERVACIONES"
                    oKeyPress(EtxtPER_OBSERVACIONES, e)
                Case "txtCCC_ID_CLI"
                    oKeyPress(EtxtCCC_ID_CLI, e)
                Case "txtPER_CARGO"
                    oKeyPress(EtxtPER_CARGO, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID.DoubleClick, _
            txtCCC_ID_CLI.DoubleClick, _
            txtPER_ID_VEN.DoubleClick, _
            txtPER_ID_COB.DoubleClick, _
            txtPER_ID_TRA.DoubleClick, _
            txtPER_ID_BAN.DoubleClick, _
            txtPER_ID_GRU.DoubleClick
            Select Case sender.name.ToString
                Case "txtCCC_ID_CLI"
                    oDoubleClick(EtxtCCC_ID_CLI, txtCCC_ID_CLI, "frmCajaCtaCte")
                Case "txtPER_ID_VEN"
                    oDoubleClick(EtxtPER_ID_VEN, txtPER_ID_VEN, "frmPersonas")
                Case "txtPER_ID_COB"
                    oDoubleClick(EtxtPER_ID_COB, txtPER_ID_COB, "frmPersonas")
                Case "txtPER_ID_TRA"
                    oDoubleClick(EtxtPER_ID_TRA, txtPER_ID_TRA, "frmPersonas")
                Case "txtPER_ID_BAN"
                    oDoubleClick(EtxtPER_ID_BAN, txtPER_ID_BAN, "frmPersonas")
                Case "txtPER_ID_GRU"
                    oDoubleClick(EtxtPER_ID_GRU, txtPER_ID_GRU, "frmPersonas")
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
                    Case "frmCajaCtaCte"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Tesoreria.Views.frmCajaCtaCte)()
                    Case "frmDireccionesPersonas"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmDireccionesPersonas)()
                    Case "frmDistrito"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmDistrito)()
                    Case "frmPersonas"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
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
        Private Sub TeclaF1(ByRef EtxtTemporal As txt, ByRef txt As TextBox)
            If EtxtTemporal.pBusqueda Then
                EtxtTemporal.pTexto2 = Me.Text
                ValidarDatos(EtxtTemporal, txt)

                If txt.Name = "txtPER_ID" Then
                    EtxtPER_ID.pOOrm.pVista = "BuscarRegistroConDocumento"
                    EtxtPER_ID.pComportamiento = 0
                    EtxtPER_ID.pOrdenBusqueda = 9
                    EtxtPER_ID.pOOrm.pBuscarRegistros = False
                End If

                MetodoBusquedaDato("", False, EtxtTemporal)

                If txt.Name = "txtPER_ID" Then
                    EtxtPER_ID.pComportamiento = 0
                    EtxtPER_ID.pOrdenBusqueda = 4
                    EtxtPER_ID.pOOrm.pBuscarRegistros = True
                End If

                EtxtTemporal.pTexto1 = Me.Text
                EtxtTemporal.pTexto2 = Me.Text
            End If
        End Sub

        Private Sub tco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles tcoDatos.SelectedIndexChanged, tcoDatos1.SelectedIndexChanged
            If sender.SelectedTab.Name = "tpaMediosContacto" Then
                MostrarMedioContacto(True)
                MostrarDocIdentidad(False)
                MostrarDirecciones(False)
                MostrarContactos(False)
                MostrarFormaVenta(False)
            End If
            If sender.SelectedTab.Name = "tpaDocIdentidad" Then
                MostrarMedioContacto(False)
                MostrarDocIdentidad(True)
                MostrarDirecciones(False)
                MostrarContactos(False)
                MostrarFormaVenta(False)
            End If
            If sender.SelectedTab.Name = "tpaDirecciones" Then
                MostrarMedioContacto(False)
                MostrarDocIdentidad(False)
                MostrarDirecciones(True)
                MostrarContactos(False)
                MostrarFormaVenta(False)
            End If
            If sender.SelectedTab.Name = "tpaContactos" Then
                MostrarMedioContacto(False)
                MostrarDocIdentidad(False)
                MostrarDirecciones(False)
                MostrarContactos(True)
                MostrarFormaVenta(False)
            End If
            If sender.SelectedTab.Name = "tpaFormaVenta" Then
                MostrarMedioContacto(False)
                MostrarDocIdentidad(False)
                MostrarDirecciones(False)
                MostrarContactos(False)
                MostrarFormaVenta(True)
            End If

            If sender.SelectedTab.Name = "tpaEsCliente" Then
                MostrarEsCliente(True)
                MostrarEsVendedor(False)
                MostrarEsTransportista(False)
                MostrarEsBanco(False)
                MostrarFinanzas(False)
            End If
            If sender.SelectedTab.Name = "tpaEsVendedor" Then
                MostrarEsCliente(False)
                MostrarEsVendedor(True)
                MostrarEsTransportista(False)
                MostrarEsBanco(False)
                MostrarFinanzas(False)
            End If
            If sender.SelectedTab.Name = "tpaEsTransportista" Then
                MostrarEsCliente(False)
                MostrarEsVendedor(False)
                MostrarEsTransportista(True)
                MostrarEsBanco(False)
                MostrarFinanzas(False)
            End If
            If sender.SelectedTab.Name = "tpaEsBanco" Then
                MostrarEsCliente(False)
                MostrarEsVendedor(False)
                MostrarEsTransportista(False)
                MostrarEsBanco(True)
                MostrarFinanzas(False)
            End If
            If sender.SelectedTab.Name = "tpaFinanzas" Then
                MostrarEsCliente(False)
                MostrarEsVendedor(False)
                MostrarEsTransportista(False)
                MostrarEsBanco(False)
                MostrarFinanzas(True)
            End If

        End Sub

        Private Sub MostrarMedioContacto(ByVal vBoolean As Boolean)
            lblPER_TELEFONOS.Visible = vBoolean
            txtPER_TELEFONOS.Visible = vBoolean

            lblPER_EMAIL.Visible = vBoolean
            txtPER_EMAIL.Visible = vBoolean

            lblPER_PAGINA_WEB.Visible = vBoolean
            txtPER_PAGINA_WEB.Visible = vBoolean
        End Sub
        Private Sub MostrarDocIdentidad(ByVal vBoolean As Boolean)
            dgvDocIdentidad.Visible = vBoolean
        End Sub
        Private Sub MostrarDirecciones(ByVal vBoolean As Boolean)
            dgvDireccionPersona.Visible = vBoolean
        End Sub
        Private Sub MostrarContactos(ByVal vBoolean As Boolean)
            dgvContactoPersona.Visible = vBoolean
        End Sub
        Private Sub MostrarFormaVenta(ByVal vBoolean As Boolean)
            lblPER_FORMA_VENTA.Visible = vBoolean
            cboPER_FORMA_VENTA.Visible = vBoolean
            lblPER_LINEA_CREDITO.Visible = vBoolean
            txtPER_LINEA_CREDITO.Visible = vBoolean
            lblPER_DIAS_CREDITO.Visible = vBoolean
            txtPER_DIAS_CREDITO.Visible = vBoolean
            chkPER_LINEA_CREDITO_ESTADO.Visible = vBoolean

            lblPER_DIASEM_PAGO.Visible = vBoolean
            cboPER_DIASEM_PAGO.Visible = vBoolean
            lblPER_COND_DIASEM.Visible = vBoolean
            cboPER_COND_DIASEM.Visible = vBoolean
            lblPER_DIAMES_PAGO.Visible = vBoolean
            txtPER_DIAMES_PAGO.Visible = vBoolean
            lblPER_DOC_PAGO.Visible = vBoolean
            cboPER_DOC_PAGO.Visible = vBoolean

            lblPER_HORA_PAGO.Visible = vBoolean
            txtPER_HORA_PAGO.Visible = vBoolean
            lblPER_CARTA_FIANZA.Visible = vBoolean
            cboPER_CARTA_FIANZA.Visible = vBoolean

            lblDeuda.Visible = vBoolean
            txtDeuda.Visible = vBoolean
            lblDisponible.Visible = vBoolean
            txtDisponible.Visible = vBoolean

            lblPER_FECHA_ALTA.Visible = vBoolean
            dtpPER_FECHA_ALTA.Visible = vBoolean
            lblPER_FECHA_VENC.Visible = vBoolean
            dtpPER_FECHA_VENC.Visible = vBoolean
            lblPER_GARANTIA.Visible = vBoolean
            txtPER_GARANTIA.Visible = vBoolean
            lblPER_EXCESO_LINEA.Visible = vBoolean
            txtPER_EXCESO_LINEA.Visible = vBoolean


        End Sub

        Private Sub MostrarEsCliente(ByVal vBoolean As Boolean)
            lblPER_ID_VEN.Visible = vBoolean
            txtPER_ID_VEN.Visible = vBoolean
            txtPER_DESCRIPCION_VEN.Visible = vBoolean

            lblPER_ID_GRU.Visible = vBoolean
            txtPER_ID_GRU.Visible = vBoolean
            txtPER_DESCRIPCION_GRU.Visible = vBoolean

            lblTipoCliente.Visible = vBoolean
            cboTipoCliente.Visible = vBoolean
        End Sub
        Private Sub MostrarEsVendedor(ByVal vBoolean As Boolean)
            lblPER_CUOTA_MENSUAL.Visible = vBoolean
            txtPER_CUOTA_MENSUAL.Visible = vBoolean

            lblPER_CUOTA_OBJETIVO.Visible = vBoolean
            txtPER_CUOTA_OBJETIVO.Visible = vBoolean

            lblPER_BONO.Visible = vBoolean
            txtPER_BONO.Visible = vBoolean
        End Sub
        Private Sub MostrarEsTransportista(ByVal vBoolean As Boolean)
            lblPER_ID_TRA.Visible = vBoolean
            txtPER_ID_TRA.Visible = vBoolean
            txtPER_DESCRIPCION_TRA.Visible = vBoolean

            lblPER_BREVETE.Visible = vBoolean
            txtPER_BREVETE.Visible = vBoolean
        End Sub
        Private Sub MostrarEsBanco(ByVal vBoolean As Boolean)
            lblPER_ID_BAN.Visible = vBoolean
            txtPER_ID_BAN.Visible = vBoolean
            txtPER_DESCRIPCION_BAN.Visible = vBoolean
        End Sub
        Private Sub MostrarFinanzas(ByVal vBoolean As Boolean)
            lblPER_REP_LEGAL.Visible = vBoolean
            chkPER_REP_LEGAL.Visible = vBoolean

            lblPER_FIRMA_AUT.Visible = vBoolean
            chkPER_FIRMA_AUT.Visible = vBoolean

            lblPER_PROMOCIONES.Visible = vBoolean
            chkPER_PROMOCIONES.Visible = vBoolean

            lblCCC_ID.Visible = vBoolean
            txtCCC_ID_CLI.Visible = vBoolean
            txtCCC_DESCRIPCION_CLI.Visible = vBoolean

            lblPER_CARGO.Visible = vBoolean
            txtPER_CARGO.Visible = vBoolean

            lblPER_ID_COB.Visible = vBoolean
            txtPER_ID_COB.Visible = vBoolean
            txtPER_DESCRIPCION_COB.Visible = vBoolean
        End Sub

        Private Sub CamposMostrarLlamadaDesdeFormulario()
            If LLamadaDesdeFormularioDatos.pTipoPersonaCrear = BCVariablesNames.TipoPersonas.PersonaQueRecepciona Then
                chkPER_CLIENTE.Enabled = False
                chkPER_PROVEEDOR.Enabled = False
                chkPER_TRABAJADOR.Enabled = False
                chkPER_BANCO.Enabled = False
                chkPER_GRUPO.Enabled = False
                chkPER_TRANSPORTISTA.Enabled = False

                cboPER_CLIENTE_OP_CON.Enabled = False
                cboPER_PROVEEDOR_OP_CON.Enabled = False
                cboPER_TRABAJADOR_OP_CON.Enabled = False
                cboPER_BANCO_OP_CON.Enabled = False
                cboPER_GRUPO_OP_CON.Enabled = False
                cboPER_TRANSPORTISTA_OP_CON.Enabled = False

                cboPER_TRANSP_PROPIO.Enabled = False

                chkPER_CONTACTO.Enabled = False
                cboPER_CONTACTO_OP_CON.Enabled = False
                lblPER_CONTACTO.Enabled = True
                lblPER_CONTACTO.Visible = True
                chkPER_CONTACTO.Visible = True
                cboPER_CONTACTO_OP_CON.Visible = True

                MostrarEsCliente(False)
                'RemoverTabs(tcoDatos, tpaMediosContacto)
                RemoverTabs(tcoDatos, tpaContactos)
                RemoverTabs(tcoDatos, tpaFormaVenta)

                RemoverTabs(tcoDatos1, tpaEsVendedor)
                RemoverTabs(tcoDatos1, tpaEsTransportista)
                RemoverTabs(tcoDatos1, tpaEsBanco)
                RemoverTabs(tcoDatos1, tpaFinanzas)
            End If
            If LLamadaDesdeFormularioDatos.pTipoPersonaCrear = BCVariablesNames.TipoPersonas.Transportista Then
                If Not LLamadaDesdeFormularioDatos.pEsChofer Then
                    chkPER_CLIENTE.Enabled = False
                    chkPER_PROVEEDOR.Enabled = False
                    chkPER_TRABAJADOR.Enabled = False
                    chkPER_BANCO.Enabled = False
                    chkPER_GRUPO.Enabled = False
                    chkPER_CONTACTO.Enabled = False
                    chkPER_TRANSPORTISTA.Enabled = False

                    cboPER_CLIENTE_OP_CON.Enabled = False
                    cboPER_PROVEEDOR_OP_CON.Enabled = False
                    cboPER_TRABAJADOR_OP_CON.Enabled = False
                    cboPER_BANCO_OP_CON.Enabled = False
                    cboPER_GRUPO_OP_CON.Enabled = False
                    cboPER_CONTACTO_OP_CON.Enabled = False
                    cboPER_TRANSPORTISTA_OP_CON.Enabled = False

                    txtPER_ID_TRA.Enabled = False

                    tcoDatos.SelectedIndex = 0
                    cMisProcedimientos.RemoverTabs(tcoDatos, tpaDocIdentidad)
                    cMisProcedimientos.RemoverTabs(tcoDatos, tpaDirecciones)
                    cMisProcedimientos.RemoverTabs(tcoDatos, tpaContactos)
                    cMisProcedimientos.RemoverTabs(tcoDatos, tpaFormaVenta)

                    tcoDatos1.SelectedIndex = 2
                    cMisProcedimientos.RemoverTabs(tcoDatos1, tpaEsCliente)
                    cMisProcedimientos.RemoverTabs(tcoDatos1, tpaEsVendedor)
                    cMisProcedimientos.RemoverTabs(tcoDatos1, tpaEsBanco)
                    cMisProcedimientos.RemoverTabs(tcoDatos1, tpaFinanzas)
                End If
            End If
        End Sub

        Private Sub ConfigurarCamposLlamadaDesdeFormulario()
            If LLamadaDesdeFormularioDatos.pTipoPersonaCrear = BCVariablesNames.TipoPersonas.PersonaQueRecepciona Then
                cboPER_FORMA_VENTA.Text = LLamadaDesdeFormularioDatos.pTipoVentaDescripcion
                chkPER_CONTACTO.Checked = CheckState.Checked

                chkPER_CLIENTE.Checked = CheckState.Unchecked
                chkPER_PROVEEDOR.Checked = CheckState.Unchecked
                chkPER_TRABAJADOR.Checked = CheckState.Unchecked
                chkPER_BANCO.Checked = CheckState.Unchecked
                chkPER_GRUPO.Checked = CheckState.Unchecked
                chkPER_TRANSPORTISTA.Checked = CheckState.Unchecked
                CamposMostrarLlamadaDesdeFormulario()
            End If

            If LLamadaDesdeFormularioDatos.pTipoPersonaCrear = BCVariablesNames.TipoPersonas.Transportista Then
                If Not LLamadaDesdeFormularioDatos.pEsChofer Then
                    chkPER_CLIENTE.Checked = False
                    chkPER_TRANSPORTISTA.Checked = True

                    CamposMostrarLlamadaDesdeFormulario()
                End If
            End If

            If LLamadaDesdeFormularioDatos.pTipoPersonaCrear = BCVariablesNames.TipoPersonas.Transportista Then
                If LLamadaDesdeFormularioDatos.pEsChofer Then
                    chkPER_CLIENTE.Checked = False
                    chkPER_TRANSPORTISTA.Checked = True

                    chkPER_CLIENTE.Enabled = False
                    chkPER_PROVEEDOR.Enabled = False
                    chkPER_TRABAJADOR.Enabled = False
                    chkPER_BANCO.Enabled = False
                    chkPER_GRUPO.Enabled = False
                    chkPER_CONTACTO.Enabled = False
                    chkPER_TRANSPORTISTA.Enabled = False

                    cboPER_CLIENTE_OP_CON.Enabled = False
                    cboPER_PROVEEDOR_OP_CON.Enabled = False
                    cboPER_TRABAJADOR_OP_CON.Enabled = False
                    cboPER_BANCO_OP_CON.Enabled = False
                    cboPER_GRUPO_OP_CON.Enabled = False
                    cboPER_CONTACTO_OP_CON.Enabled = False
                    cboPER_TRANSPORTISTA_OP_CON.Enabled = False

                    tcoDatos.SelectedIndex = 0
                    cMisProcedimientos.RemoverTabs(tcoDatos, tpaDocIdentidad)
                    cMisProcedimientos.RemoverTabs(tcoDatos, tpaDirecciones)
                    cMisProcedimientos.RemoverTabs(tcoDatos, tpaContactos)
                    cMisProcedimientos.RemoverTabs(tcoDatos, tpaFormaVenta)

                    tcoDatos1.SelectedIndex = 2
                    cMisProcedimientos.RemoverTabs(tcoDatos1, tpaEsCliente)
                    cMisProcedimientos.RemoverTabs(tcoDatos1, tpaEsVendedor)
                    cMisProcedimientos.RemoverTabs(tcoDatos1, tpaEsBanco)
                    cMisProcedimientos.RemoverTabs(tcoDatos1, tpaFinanzas)

                    MetodoBusquedaDato(LLamadaDesdeFormularioDatos.pPer_Id_Tra & BCVariablesNames.TipoPersonas.Transportista, True, EtxtPER_ID_TRA)
                    txtPER_ID_TRA.Enabled = False
                End If
            End If
        End Sub

        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 0 ' Personas
                    OrdenBusquedaDirecta = 0
                Case 2, 3, 4, 5, 6, 8 ' Vendedor,Cobrador,Transportista,Banco,Grupo, CajaCtaCte
                    OrdenBusquedaDirecta = 0
                Case 7 ' Distrito
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function

        Private Sub RemoverTabs(ByRef vTabControl As TabControl, ByRef vTapPage As TabPage)
            vTabControl.TabPages.Remove(vTapPage)
        End Sub

        Private Sub SaldosCliente()
            Try
                Dim ds As New DataSet
                dgvSaldos.DataSource = Nothing
                If txtPER_ID.Text.Trim <> "" Then
                    Dim sr As New StringReader(IBCMaestro.EjecutarVista(DA.SPNames.spSaldosClienteXML, _
                                                                        DBNull.Value, _
                                                                        DBNull.Value, _
                                                                        txtPER_ID.Text.Trim, _
                                                                        " "))
                    Dim vcontrol As Int16 = sr.Peek
                    If vcontrol <> -1 Then
                        ds.ReadXml(sr)
                        dgvSaldos.DataSource = ds.Tables(0)
                        TotalizarSaldosCliente()
                    Else
                        dgvSaldos.DataSource = Nothing
                        txtDeuda.Text = 0
                        txtDisponible.Text = CDbl(txtPER_LINEA_CREDITO.Text) - 0
                    End If
                Else
                    dgvSaldos.DataSource = Nothing
                End If
            Catch ex As Exception
                MsgBox(ex.Message & Err.Number, Me.Text)
            End Try
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
                                                                                  BCVariablesNames.MonedaSistema)
                ''                                                                txtMON_ID.Text)
                vSaldo = CDbl(dgvSaldos.Item("Saldo", vfila).Value)
                If vCodigoMonedaProcesar = BCVariablesNames.MonedaSistema Then
                    vMontoTipoCambioMoneda = 1
                Else
                    ''
                    If dgvSaldos.Item("MON_ID", vfila).Value <> BCVariablesNames.MonedaSistema And
                        BCVariablesNames.MonedaSistema <> BCVariablesNames.MonedaSistema Then
                        ''txtMON_ID.Text <> BCVariablesNames.MonedaSistema Then
                        If BCVariablesNames.MonedaSistema = dgvSaldos.Item("MON_ID", vfila).Value Then
                            ''If txtMON_ID.Text = dgvSaldos.Item("MON_ID", vfila).Value Then
                            vFlag = True
                            vMontoTipoCambioMoneda = 1
                        Else
                            vCodigoMonedaProcesar = BCVariablesNames.MonedaSistema
                            ''vCodigoMonedaProcesar = txtMON_ID.Text
                            vCodigoMonedaProcesarTemporal = dgvSaldos.Item("MON_ID", vfila).Value
                            vMontoTipoCambioMonedaTemporal = cMisProcedimientos.SolicitarMontoTipoCambioMoneda(BCVariablesNames.MonedaSistema,
                                                                                                               vCodigoMonedaProcesarTemporal, _
                                                                                                               IBCMaestro.EjecutarVista("spFechaServidor"), _
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
                                ErrorProvider1.SetError(txtDeuda, "No existe tipo de cambio para el saldo de un documento")
                                ''ErrorProvider1.SetError(txtMON_ID, "No existe tipo de cambio para el saldo de un documento")
                                Exit For
                            End If
                        End If
                    End If
                    ''
                    If Not vFlag Then vMontoTipoCambioMoneda = cMisProcedimientos.SolicitarMontoTipoCambioMoneda(BCVariablesNames.MonedaSistema, _
                                                                                                                 vCodigoMonedaProcesar, _
                                                                                                                 IBCMaestro.EjecutarVista("spFechaServidor"), _
                                                                                                                 IBCMaestro)
                End If
                If vMontoTipoCambioMoneda <> 0 Then
                    vTotalDeuda += cMisProcedimientos.MontoSegunTipoCambio(vMontoTipoCambioMoneda, _
                                                                           BCVariablesNames.MonedaSistema, _
                                                                           BCVariablesNames.MonedaSistema, _
                                                                           vSaldo)
                    ''                                                     txtMON_ID.Text.Trim, _
                    ''                                                     BCVariablesNames.MonedaSistema, _
                    ''                                                      vSaldo)

                    ErrorProvider1.SetError(txtDeuda, Nothing)
                Else
                    vTotalDeuda = 999999999.99
                    ErrorProvider1.SetError(txtDeuda, "No existe tipo de cambio para el saldo de un documento")
                    ''ErrorProvider1.SetError(txtMON_ID, "No existe tipo de cambio para el saldo de un documento")
                    Exit For
                End If
            Next
            txtDeuda.Text = vTotalDeuda
            txtDisponible.Text = CDbl(txtPER_LINEA_CREDITO.Text) - vTotalDeuda
            If IsNumeric(txtDeuda.Text) Then txtDeuda.Text = Format(CDbl(txtDeuda.Text), "##,###.#0")
            If IsNumeric(txtDisponible.Text) Then txtDisponible.Text = Format(CDbl(txtDisponible.Text), "##,###.#0")
        End Sub
    End Class
End Namespace