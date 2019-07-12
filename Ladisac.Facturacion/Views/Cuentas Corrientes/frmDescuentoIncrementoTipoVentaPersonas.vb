Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Namespace Ladisac.CuentasCorrientes.Views
    Public Class frmDescuentoIncrementoTipoVentaPersonas
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
#Region "ComboBox"
        Public Structure cbo
            Public Property pNombreCampo As String
            Public Property pEnabled As Boolean
            Public Property pBusqueda As Boolean
            Public Property pStyle As System.Windows.Forms.ComboBoxStyle
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
                        'TeclaF1SubLlamadas(txt.Name)
                    End If
                End If
                SubValidarDatos(otxt, txt)
            End With
        End Sub
        Private Sub MetodoBusquedaDato(ByVal vDatoBusqueda As String, _
                                       ByVal vBusquedaDirecta As Boolean, _
                                       ByVal vtxt As txt)

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
        End Sub
        Private Sub TeclaF1(ByRef otxt As txt, ByRef txt As TextBox)
            If otxt.pBusqueda Then
                otxt.pTexto2 = txt.Text
                ValidarDatos(otxt, txt)
                MetodoBusquedaDato("", False, otxt)
                otxt.pTexto1 = txt.Text
                otxt.pTexto2 = txt.Text
                'TeclaF1SubLlamadas(txt.Name)
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
            'ConfigurarFormulario(2)
        End Sub
        Public Sub EditarRegistro()
            If Not pFlagNuevo Then If Trim(pCodigoId) = "" Then Return
            BotonesEdicion("Editar registro")
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
                End If
            Else
                BotonesEdicion("Seleccionar registro")
            End If
        End Sub
        Public Sub PrepararGuardar(ByVal vNuevo As Boolean)
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
                    Dim resp = Me.IBCBusqueda.CrearCodigoSimple("DTP_ID", _
                                                                Compuesto.cTabla.NombreLargo)
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
        Private Function RevisarDatos(ByVal vBoolean As Boolean) As Boolean
            Return RevisarDatos(pColeccionDatos, vBoolean)
        End Function
        Private Function RevisarDatos(ByVal vColeccionDatos As Collection, _
                              ByVal vRespuestaGrabar As Boolean) As Boolean
            If RevisarDatosForm(vColeccionDatos, True) Then
                If vRespuestaGrabar Then
                    RevisarDatos = True
                Else
                    Dim oMsgBoxResult As New MsgBoxResult()
                    oMsgBoxResult = MsgBox("Registro modificado... ¡Sin Grabar!." & Chr(13) & Chr(13) & "¿Desea continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, Me.Text & " - Se perderan los datos.")
                    If (oMsgBoxResult = MsgBoxResult.Cancel) Then
                        RevisarDatos = True
                    Else
                        RevisarDatos = False
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
                                                                   "ltrim(rtrim(cast( isnull(" & Compuesto.CampoPrincipalSecundario & ",'') as varchar))) + " & _
                                                                   "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                   "ltrim(rtrim(cast( isnull(" & Compuesto.CampoPrincipalCuarto & ",'') as varchar)))", _
                                                                   Compuesto.CampoPrincipalValor, _
                                                                   Compuesto.cTabla.NombreLargo)
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
                            'Dim resp = Me.IBCBusqueda.PrimerRegistro(Compuesto.CampoPrincipal, _
                            'Compuesto.cTabla.NombreLargo)
                            Dim resp = Me.IBCBusqueda.PrimerRegistro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                     "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalSecundario & ",'') as varchar))) + " & _
                                     "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                     "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalCuarto & ",'') as varchar)))", _
                                     Compuesto.cTabla.NombreLargo)

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
            Dim vRespuestaScope As Int16 = 0
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            pRespuestaExtraerDetalle = 0
            Ingresar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                Using Scope As New System.Transactions.TransactionScope()
                    If (InsertarDatos()) Then
                        Scope.Complete()
                        Ingresar = True
                        ConfigurarDatosGrabados()
                        Me.Cursor = Windows.Forms.Cursors.Default
                        vRespuestaScope = 1
                    Else
                        If pRespuestaExtraerDetalle = -1 Then
                            Scope.Dispose()
                            Me.Cursor = Windows.Forms.Cursors.Default
                            Return Ingresar
                        End If
                        Scope.Dispose()
                        Me.Cursor = Windows.Forms.Cursors.Default
                        vRespuestaScope = 2
                    End If
                End Using
            End If
            MensajeOperaciones(vRespuestaScope, "ingresado")
            InicializarOrm()
            Me.Cursor = Windows.Forms.Cursors.Default
            Return Ingresar
        End Function
        Private Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            Compuesto.MarkAsAdded()
            vRespuestaLocal = Me.IBC.Mantenimiento(Compuesto)
            If vRespuestaLocal = 0 Then
                InsertarDatos = False
                Return InsertarDatos
            End If
            pRespuestaExtraerDetalle = ExtraerDetalle()
            InsertarDatos = (vRespuestaLocal > 0 And pRespuestaExtraerDetalle = 1)
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
            Dim vRespuestaScope As Int16 = 0
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            pRespuestaExtraerDetalle = 0
            Modificar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                Using Scope As New System.Transactions.TransactionScope()
                    If (ActualizarDatos()) Then
                        Scope.Complete()
                        Modificar = True
                        ConfigurarDatosGrabados()
                        Me.Cursor = Windows.Forms.Cursors.Default
                        vRespuestaScope = 1
                    Else
                        If pRespuestaExtraerDetalle = -1 Then
                            Scope.Dispose()
                            Me.Cursor = Windows.Forms.Cursors.Default
                            Return Modificar
                        End If
                        Scope.Dispose()
                        Me.Cursor = Windows.Forms.Cursors.Default
                        vRespuestaScope = 2
                    End If
                End Using
            End If
            MensajeOperaciones(vRespuestaScope, "modificado")
            InicializarOrm()
            Me.Cursor = Windows.Forms.Cursors.Default
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean
            pRespuestaExtraerDetalle = ExtraerDetalle()
            Compuesto.MarkAsModified()
            ActualizarDatos = (Me.IBC.Mantenimiento(Compuesto) > 0 And pRespuestaExtraerDetalle = 1)
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
            Dim vRespuestaScope As Int16 = 0
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            Using Scope As New System.Transactions.TransactionScope()
                Compuesto.MarkAsDeleted()
                If (ProcesarEliminarDetalle() > 0 And Me.IBC.Mantenimiento(Compuesto) > 0) Then
                    Scope.Complete()
                    EliminarRegistro = True
                    Me.Cursor = Windows.Forms.Cursors.Default
                    vRespuestaScope = 1
                Else
                    Scope.Dispose()
                    EliminarRegistro = False
                    Me.Cursor = Windows.Forms.Cursors.Default
                    vRespuestaScope = 2
                End If
            End Using
            MensajeOperaciones(vRespuestaScope, "eliminado")
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
                                                             "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalSecundario & ",'') as varchar))) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                             "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalCuarto & ",'') as varchar)))", _
                                                             Compuesto.cTabla.NombreLargo)
                    Case "RegistroAnterior"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroAnterior("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                               "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalSecundario & ",'') as varchar))) + " & _
                                                               "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                               "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalCuarto & ",'') as varchar)))", _
                                                               Compuesto.CampoPrincipalValor, _
                                                               Compuesto.cTabla.NombreLargo)
                    Case "RegistroSiguiente"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroSiguiente("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                                "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalSecundario & ",'') as varchar))) + " & _
                                                                "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                                "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalCuarto & ",'') as varchar)))", _
                                                                Compuesto.CampoPrincipalValor, _
                                                                Compuesto.cTabla.NombreLargo)
                    Case "UltimoRegistro"
                        resp = Me.IBCBusqueda.UltimoRegistro("cast(" & Compuesto.CampoPrincipal & " as varchar) + " & _
                                                             "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalSecundario & ",'') as varchar))) + " & _
                                                             "cast(" & Compuesto.CampoPrincipalTercero & " as varchar) + " & _
                                                             "rtrim(ltrim(cast( isnull(" & Compuesto.CampoPrincipalCuarto & ",'') as varchar)))", _
                                                             Compuesto.cTabla.NombreLargo)
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

        '' Activated
        Private Sub frm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles MyBase.Activated
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
        Private Sub frm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) _
            Handles MyBase.FormClosed
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
        Public Property IBC As Ladisac.BL.IBCDescuentoIncrementoTipoVentaPersonas

        <Dependency()> _
        Public Property IBCDetalle As Ladisac.BL.IBCDetalleDescuentoIncrementoTipoVentaPersonas

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        ' Controlar la clave de la tabla
        Public vCodigoART_ID As String = ""
        Public vCodigoTIV_ID As String = ""
        Public vCodigoPER_ID As String = ""

        ' CheckBox
        Private EchkDTP_CRITERIO As New chk
        Private EchkDTP_SUB_CRITERIO As New chk
        Private EchkDTP_ESTADO As New chk
        Private EchkART_ESTADO As New chk
        Private EchkTIV_ESTADO As New chk

        Private EcboDTP_TIPO_DESC_INC As New cbo

        ' DataGridView
        Private EdgvDetalle As New dgv

        ' TextBox
        '' PK
        Private EtxtLPR_ID As New txt
        Private EtxtART_ID As New txt
        Private EtxtTIV_ID As New txt
        Private EtxtPER_ID As New txt
        Private EtxtUSU_ID As New txt

        Private EtxtDTP_DESCRIPCION As New txt

        Private EtxtDTP_MONTO_TIV As New txt
        Private EtxtDTP_MONTO_PER As New txt
        Private EtxtDTP_MONTO_MINIMO As New txt
        Private EtxtDTP_MONTO_MAXIMO As New txt
        Private EtxtDTP_CANT_MINIMA As New txt
        Private EtxtDTP_CANT_MAXIMA As New txt
        Private EtxtART_FACTOR As New txt
        Private EtxtDLP_PRECIO_MINIMO As New txt
        Private EtxtDLP_PRECIO_UNITARIO As New txt
        Private EtxtDLP_RECARGO_ENVIO As New txt
        Private EtxtTIV_DIAS As New txt

        Private EtxtART_IDD As New txt

        Private pART_ID As String = ""
        Private pART_DESCRIPCION As String = ""

        Private Compuesto As New Ladisac.BE.DescuentoIncrementoTipoVentaPersonas
        Private Compuesto1 As New Ladisac.BE.DetalleDescuentoIncrementoTipoVentaPersonas

        Private ErrorData As New Ladisac.BE.DescuentoIncrementoTipoVentaPersonas.ErrorData
        Private cMisProcedimientos As New Ladisac.MisProcedimientos

        Private Structure ElementosEliminar
            Public cDTP_ID As String
            Public cART_ID As String
            Public cDDT_ITEM As String
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

            InicializarValores(txtDTP_DESCRIPCION, ErrorProvider1)
            'InicializarValores(txtDTP_ID, ErrorProvider1)

            InicializarValores(txtLPR_ID, ErrorProvider1)
            InicializarValores(txtLPR_DESCRIPCION, ErrorProvider1)

            InicializarValores(txtART_ID, ErrorProvider1)
            InicializarValores(txtART_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtUM_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtART_FACTOR, ErrorProvider1, EtxtART_FACTOR.pSoloNumeros, EtxtART_FACTOR.pSoloNumerosDecimales)
            InicializarValores(chkART_ESTADO, ErrorProvider1, False, False, EchkART_ESTADO.pValorDefault)
            ColocarValoresDefault(chkART_ESTADO)
            InicializarValores(txtDLP_PRECIO_MINIMO, ErrorProvider1, EtxtDLP_PRECIO_MINIMO.pSoloNumeros, EtxtDLP_PRECIO_MINIMO.pSoloNumerosDecimales)
            InicializarValores(txtDLP_PRECIO_UNITARIO, ErrorProvider1, EtxtDLP_PRECIO_UNITARIO.pSoloNumeros, EtxtDLP_PRECIO_UNITARIO.pSoloNumerosDecimales)
            InicializarValores(txtDLP_RECARGO_ENVIO, ErrorProvider1, EtxtDLP_RECARGO_ENVIO.pSoloNumeros, EtxtDLP_RECARGO_ENVIO.pSoloNumerosDecimales)

            InicializarValores(txtTIV_ID, ErrorProvider1)
            InicializarValores(txtTIV_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtTIV_DIAS, ErrorProvider1, EtxtTIV_DIAS.pSoloNumeros, EtxtTIV_DIAS.pSoloNumerosDecimales)
            InicializarValores(chkTIV_ESTADO, ErrorProvider1, False, False, EchkTIV_ESTADO.pValorDefault)
            ColocarValoresDefault(chkTIV_ESTADO)

            InicializarValores(txtDTP_MONTO_TIV, ErrorProvider1, EtxtDTP_MONTO_TIV.pSoloNumeros, EtxtDTP_MONTO_TIV.pSoloNumerosDecimales)

            InicializarValores(txtPER_ID, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtDTP_MONTO_PER, ErrorProvider1, EtxtDTP_MONTO_PER.pSoloNumeros, EtxtDTP_MONTO_PER.pSoloNumerosDecimales)

            InicializarValores(cboDTP_TIPO_DESC_INC, ErrorProvider1)

            InicializarValores(chkDTP_CRITERIO, ErrorProvider1, False, False, EchkDTP_CRITERIO.pValorDefault)
            ColocarValoresDefault(chkDTP_CRITERIO)
            chkDTP_SUB_CRITERIO.Enabled = False

            InicializarValores(chkDTP_SUB_CRITERIO, ErrorProvider1, False, False, EchkDTP_CRITERIO.pValorDefault)
            ColocarValoresDefault(chkDTP_SUB_CRITERIO)
            chkDTP_SUB_CRITERIO.Visible = False
            lblDTP_SUB_CRITERIO.Visible = False

            InicializarValores(txtDTP_MONTO_MINIMO, ErrorProvider1, EtxtDTP_MONTO_MINIMO.pSoloNumeros, EtxtDTP_MONTO_MINIMO.pSoloNumerosDecimales)
            InicializarValores(txtDTP_MONTO_MAXIMO, ErrorProvider1, EtxtDTP_MONTO_MAXIMO.pSoloNumeros, EtxtDTP_MONTO_MAXIMO.pSoloNumerosDecimales)
            InicializarValores(txtDTP_CANT_MINIMA, ErrorProvider1, EtxtDTP_CANT_MINIMA.pSoloNumeros, EtxtDTP_CANT_MINIMA.pSoloNumerosDecimales)
            InicializarValores(txtDTP_CANT_MAXIMA, ErrorProvider1, EtxtDTP_CANT_MAXIMA.pSoloNumeros, EtxtDTP_CANT_MAXIMA.pSoloNumerosDecimales)

            InicializarValores(dtpDTP_FEC_INI, ErrorProvider1)
            InicializarValores(dtpDTP_FEC_FIN, ErrorProvider1)

            InicializarValores(chkDTP_ESTADO, ErrorProvider1, False, False, EchkDTP_ESTADO.pValorDefault)
            ColocarValoresDefault(chkDTP_ESTADO)

            InicializarValores(dgvDetalle, ErrorProvider1)

            ReDim eRegistrosEliminar(1)
            vBuscarDetalle = True
        End Sub
        Private Sub HabilitarNuevo()
            txtLPR_ID.Enabled = True
            txtART_ID.Enabled = True
            txtTIV_ID.Enabled = True
            txtPER_ID.Enabled = True
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkDTP_CRITERIO)
            ColocarValoresDefault(chkDTP_SUB_CRITERIO)
            ColocarValoresDefault(chkDTP_ESTADO)
            ColocarValoresDefault(chkART_ESTADO)
            ColocarValoresDefault(chkTIV_ESTADO)
        End Sub

        Private Sub CrearCodigoId()
            ProcesoCrearCodigoId("CrearCodigoSimple", txtDTP_ID)
        End Sub

        Private Sub HabilitarEscrituraNuevo()
            txtLPR_ID.ReadOnly = False
            txtART_ID.ReadOnly = False
            txtTIV_ID.ReadOnly = False
            txtPER_ID.ReadOnly = False
        End Sub
        Private Sub AdicionarFilasGrid()
            If Not ValidarAdicionarFilasGrid() Then Exit Sub
            InicializarDatosGrid(True)
            dgvDetalle.Rows.Add(EdgvDetalle.Elementos + 1, _
                                "", "", 0, 0, 0, "ACTIVO", 0)
            'ProcesarGridVacio()
            EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
            InicializarDatosGrid(False)
            'dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells(1)
            'dgvDetalle.Focus()
            'dgvDetalle.CurrentCell = dgvDetalle.Rows(dgvDetalle.RowCount - 1).Cells("cART_ID_IMP") 'mover a la fila 10
        End Sub
        Private Sub InicializarDatosGrid(ByVal vControl As Boolean)
            If vControl Then
                If dgvDetalle.RowCount > 0 Then
                    pART_ID = dgvDetalle.CurrentRow.Cells("cART_ID").Value
                    pART_DESCRIPCION = dgvDetalle.CurrentRow.Cells("cART_DESCRIPCION").Value
                Else
                    pART_ID = ""
                    pART_DESCRIPCION = ""
                End If
            Else
                dgvDetalle.Rows(dgvDetalle.RowCount - 1).Cells("cART_ID").Value = pART_ID
                dgvDetalle.Rows(dgvDetalle.RowCount - 1).Cells("cART_DESCRIPCION").Value = pART_DESCRIPCION
            End If
        End Sub
        Private Sub EliminarFilasGrid()
            If dgvDetalle.Rows.Count = 0 Then Return
            Dim vfila As DataGridViewRow
            vfila = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index)
            If dgvDetalle.Rows.Count > 0 Then
                Try
                    With dgvDetalle.Rows(dgvDetalle.CurrentRow.Index)
                        If .Cells("cEstadoRegistro").Value Then
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDTP_ID = txtDTP_ID.Text
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cART_ID = .Cells("cART_ID").Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDDT_ITEM = .Cells("cITEM").Value.ToString()
                            ReDim Preserve eRegistrosEliminar(eRegistrosEliminar.Count)
                        End If
                    End With
                    dgvDetalle.Rows.Remove(vfila)
                    'ProcesarGridVacio()
                    'CalcularMontoDocumento()
                Catch ex As Exception
                    MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- QuitarFilaGrid")
                End Try
            End If
        End Sub
        Private Sub OrmBusquedaDatos(ByVal vProceso As String)
            Dim vCodigoART__ID As String = ""
            Dim vCodigoPER__ID As String = ""
            Select Case vProceso
                Case "CancelarEdicion"
                    If vCodigoART_ID.Trim = "" Then
                        'vCodigoART__ID = Space(6)
                    Else
                        vCodigoART__ID = vCodigoART_ID
                    End If
                    If vCodigoPER_ID.Trim = "" Then
                        'vCodigoPER__ID = Space(6)
                    Else
                        vCodigoPER__ID = vCodigoPER_ID
                    End If

                    CodigoId = CodigoId & vCodigoART__ID & vCodigoTIV_ID & vCodigoPER__ID
                    If Trim(CodigoId) = "" Then CodigoId = "%"
                Case "PrepararEliminar"
                    Compuesto.Vista = "RegistroAnterior"
                    Compuesto.LPR_ID = CodigoId
                    Compuesto.ART_ID = vCodigoART_ID
                    Compuesto.TIV_ID = vCodigoTIV_ID
                    Compuesto.PER_ID = vCodigoPER_ID

                    CodigoId = CodigoId & vCodigoART_ID & vCodigoTIV_ID & vCodigoPER_ID
                Case "Load"
                    Compuesto.Vista = "PrimerAnterior"
                    Compuesto.LPR_ID = CodigoId
                    Compuesto.ART_ID = vCodigoART_ID
                    Compuesto.TIV_ID = vCodigoTIV_ID
                    Compuesto.PER_ID = vCodigoPER_ID
                    CodigoId = CodigoId & vCodigoART_ID & vCodigoTIV_ID & vCodigoPER_ID
                Case "NavegarFormulario"
                    CodigoId = CodigoId & vCodigoART_ID & vCodigoTIV_ID & vCodigoPER_ID
                Case "EliminarRegistro"
                    Compuesto.DTP_ID = txtDTP_ID.Text.Trim
                    Compuesto.LPR_ID = txtLPR_ID.Text.Trim
                    CodigoId = txtLPR_ID.Text.Trim

                    Compuesto.ART_ID = txtART_ID.Text.Trim
                    vCodigoART_ID = txtART_ID.Text.Trim

                    Compuesto.TIV_ID = txtTIV_ID.Text.Trim
                    vCodigoTIV_ID = txtTIV_ID.Text.Trim

                    Compuesto.PER_ID = txtPER_ID.Text.Trim
                    vCodigoPER_ID = txtPER_ID.Text.Trim
                Case "InicializarDatos"
                    Compuesto.LPR_ID = txtLPR_ID.Text.Trim
                    CodigoId = txtLPR_ID.Text.Trim

                    Compuesto.ART_ID = txtART_ID.Text.Trim
                    vCodigoART_ID = txtART_ID.Text.Trim

                    Compuesto.TIV_ID = txtTIV_ID.Text.Trim
                    vCodigoTIV_ID = txtTIV_ID.Text.Trim

                    Compuesto.PER_ID = txtPER_ID.Text.Trim
                    vCodigoPER_ID = txtPER_ID.Text.Trim

                    Compuesto1.DTP_ID = txtDTP_ID.Text.Trim
                    Compuesto1.ART_ID = txtART_ID.Text.Trim

                    If vBuscarDetalle Then
                        BuscarDetalle()
                    End If
            End Select
        End Sub
        Public Sub BuscarDetalle()
            Compuesto1.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, txtDTP_ID.Text, Nothing))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                dgvDetalle.Rows.Clear()
                If (ds.Tables(0).Rows.Count > 0) Then
                    While (x < ds.Tables(0).Rows.Count)
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
            Else
                dgvDetalle.DataSource = Nothing
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
            If dgvDetalle.Rows.Count() = 0 And _
               Trim(txtART_ID.Text = "") Then
                MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                Return ProcesarDatosDetalle
            End If
            If dgvDetalle.Rows.Count() = 0 And _
               Trim(txtART_ID.Text <> "") Then
                ProcesarDatosDetalle = 1
            End If
            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    vMensajeErrorOrm = ""
                    InicializarOrmDetalle()
                    Compuesto1.DTP_ID = txtDTP_ID.Text
                    Compuesto1.ART_ID = .Cells("cART_ID").Value
                    Compuesto1.DDT_ITEM = CDbl(.Cells("cITEM").Value)
                    Compuesto1.DDT_MONTO_MINIMO = CDbl(.Cells("cDDT_MONTO_MINIMO").Value)
                    Compuesto1.DDT_MONTO_MAXIMO = CDbl(.Cells("cDDT_MONTO_MAXIMO").Value)
                    Compuesto1.DDT_MONTO_TIV = CDbl(.Cells("cDDT_MONTO_TIV").Value)
                    Compuesto1.USU_ID = SessionService.UserId
                    Compuesto1.DDT_FEC_GRAB = Now
                    Compuesto1.DDT_ESTADO = DevolverTiposCampos("DDT_ESTADO", .Cells("cDDT_ESTADO").Value.ToString, Compuesto1)

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
                        Compuesto1.MarkAsModified()
                        ProcesarDatosDetalle = Me.IBCDetalle.Mantenimiento(Compuesto1)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = Compuesto1.vMensajeError
                            Exit Function
                        End If
                    Else
                        Compuesto1.MarkAsAdded()
                        ProcesarDatosDetalle = Me.IBCDetalle.Mantenimiento(Compuesto1)
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
                    EliminarRegistroDetalle = Me.IBCDetalle.DeleteRegistro(Compuesto1, eRegistrosEliminar(fila).cDTP_ID, eRegistrosEliminar(fila).cART_ID, eRegistrosEliminar(fila).cDDT_ITEM)
                    If EliminarRegistroDetalle = 0 Then
                        vMensajeErrorOrm = Compuesto1.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarRegistroDetalle
        End Function
        Private Sub DatosCabecera()
            Compuesto.DTP_ID = Strings.Trim(txtDTP_ID.Text)
            Compuesto.DTP_DESCRIPCION = Strings.Trim(txtDTP_DESCRIPCION.Text)
            Compuesto.LPR_ID = Strings.Trim(txtLPR_ID.Text)

            If Strings.Trim(txtART_ID.Text) = "" Then
                Compuesto.ART_ID = Nothing
            Else
                Compuesto.ART_ID = Strings.Trim(txtART_ID.Text)
            End If

            Compuesto.TIV_ID = Strings.Trim(txtTIV_ID.Text)
            Compuesto.DTP_MONTO_TIV = CDbl(txtDTP_MONTO_TIV.Text)

            If Strings.Trim(txtPER_ID.Text) = "" Then
                Compuesto.PER_ID = Nothing
            Else
                Compuesto.PER_ID = Strings.Trim(txtPER_ID.Text)
            End If

            If Not IsNumeric(txtDTP_MONTO_PER.Text) Then
                Compuesto.DTP_MONTO_PER = CDbl(0)
            Else
                Compuesto.DTP_MONTO_PER = CDbl(txtDTP_MONTO_PER.Text)
            End If

            Compuesto.DTP_TIPO_DESC_INC = DevolverTiposCampos("DTP_TIPO_DESC_INC", cboDTP_TIPO_DESC_INC.Text, Compuesto)
            Compuesto.DTP_CRITERIO = DevolverTiposCampos(chkDTP_CRITERIO)
            Compuesto.DTP_SUB_CRITERIO = DevolverTiposCampos(chkDTP_SUB_CRITERIO)
            Compuesto.DTP_MONTO_MINIMO = CDbl(txtDTP_MONTO_MINIMO.Text)
            Compuesto.DTP_MONTO_MAXIMO = CDbl(txtDTP_MONTO_MAXIMO.Text)
            Compuesto.DTP_CANT_MINIMA = CDbl(txtDTP_CANT_MINIMA.Text)
            Compuesto.DTP_CANT_MAXIMA = CDbl(txtDTP_CANT_MAXIMA.Text)
            Compuesto.DTP_FEC_INI = dtpDTP_FEC_INI.Value
            Compuesto.DTP_FEC_FIN = dtpDTP_FEC_FIN.Value
            Compuesto.USU_ID = SessionService.UserId
            Compuesto.DTP_FEC_GRAB = Now
            Compuesto.DTP_ESTADO = DevolverTiposCampos(chkDTP_ESTADO)
        End Sub
        Private Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Compuesto.ColocarErrores(txtDTP_DESCRIPCION, Compuesto.VerificarDatos("DTP_DESCRIPCION"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtLPR_ID, Compuesto.VerificarDatos("LPR_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtART_ID, Compuesto.VerificarDatos("ART_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtTIV_ID, Compuesto.VerificarDatos("TIV_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTP_MONTO_TIV, Compuesto.VerificarDatos("DTP_MONTO_TIV"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID, Compuesto.VerificarDatos("PER_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTP_MONTO_PER, Compuesto.VerificarDatos("DTP_MONTO_PER"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboDTP_TIPO_DESC_INC, Compuesto.VerificarDatos("DTP_TIPO_DESC_INC"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkDTP_CRITERIO, Compuesto.VerificarDatos("DTP_CRITERIO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkDTP_SUB_CRITERIO, Compuesto.VerificarDatos("DTP_SUB_CRITERIO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTP_MONTO_MINIMO, Compuesto.VerificarDatos("DTP_MONTO_MINIMO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTP_MONTO_MAXIMO, Compuesto.VerificarDatos("DTP_MONTO_MAXIMO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTP_CANT_MINIMA, Compuesto.VerificarDatos("DTP_CANT_MINIMA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtDTP_CANT_MAXIMA, Compuesto.VerificarDatos("DTP_CANT_MAXIMA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpDTP_FEC_INI, Compuesto.VerificarDatos("DTP_FEC_INI"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(dtpDTP_FEC_FIN, Compuesto.VerificarDatos("DTP_FEC_FIN"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(pnCuerpo, Compuesto.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(btnImagen, Compuesto.VerificarDatos("DTP_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkDTP_ESTADO, Compuesto.VerificarDatos("DTP_ESTADO"), ErrorProvider1)
                Case "Detalle"
                    resp.rM = Compuesto1.ColocarErrores(dgvDetalle, _
                    Compuesto1.VerificarDatos("DTP_ID",
                    "ART_ID",
                    "DDT_ITEM",
                    "USU_ID",
                    "DDT_FEC_GRAB",
                    "DDT_ESTADO"), _
                    ErrorProvider1)
            End Select
            Return vrO
        End Function
        Private Sub InicializarOrm()
            InicializarOrmDetalle()
            Compuesto = Nothing
            Compuesto = New Ladisac.BE.DescuentoIncrementoTipoVentaPersonas
        End Sub
        Private Sub InicializarOrmDetalle()
            Compuesto1 = Nothing
            Compuesto1 = New Ladisac.BE.DetalleDescuentoIncrementoTipoVentaPersonas
        End Sub
        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            EtxtART_ID.pOOrm.CadenaFiltrado = " AND LPR_ID='" & txtLPR_ID.Text & "'"
            EtxtART_IDD.pOOrm.CadenaFiltrado = " AND LPR_ID='" & txtLPR_ID.Text & "'"
        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtTIV_ID" Then EtxtTIV_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtART_ID" Then EtxtART_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtLPR_ID" Then EtxtLPR_ID.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtTIV_ID" Then EtxtTIV_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtART_ID" Then EtxtART_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtLPR_ID" Then EtxtLPR_ID.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function
        Private Function ProcesarEliminarDetalle() As Int16
            Return EliminarDetalle(Compuesto1)
        End Function
        Private Function EliminarDetalle(ByVal oOrm As DetalleDescuentoIncrementoTipoVentaPersonas) As Int16
            Return 1
        End Function
        Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles Me.Load
            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                LongitudId = 10
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
            BuscarFormatos(EcboDTP_TIPO_DESC_INC, Compuesto, cboDTP_TIPO_DESC_INC, 0)
        End Sub
        Private Sub NombresFormulariosControles()
            'Simple1.vFLagBuscarRegistros = False
            EtxtART_ID.pOOrm = New Ladisac.BE.DetalleListaPrecios
            EtxtART_ID.pOOrm.vFLagBuscarRegistros = False
            EtxtART_ID.pComportamiento = 1
            EtxtART_ID.pOrdenBusqueda = 0

            EtxtTIV_ID.pOOrm = New Ladisac.BE.TipoVenta
            EtxtTIV_ID.pComportamiento = 2
            EtxtTIV_ID.pOrdenBusqueda = 0

            'Simple3.CadenaFiltrado = " AND PER_ID IN (SELECT per_id FROM vwrolpersonatipopersona " & _
            '"WHERE PER_CLIENTE='SI' and TPE_CLIENTE='SI' and " & _
            '"TPE_ESTADO='ACTIVO' and RTP_ESTADO='ACTIVO' and PER_ESTADO='ACTIVO' " & _
            '"GROUP BY per_id)"
            EtxtPER_ID.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID.pOOrm.CadenaFiltrado = " AND PER_ID IN (SELECT per_id FROM vwrolpersonatipopersona " & _
                                                     "WHERE PER_CLIENTE='SI' and TPE_CLIENTE='SI' and " & _
                                                     "TPE_ESTADO='ACTIVO' and RTP_ESTADO='ACTIVO' and PER_ESTADO='ACTIVO' " & _
                                                     "GROUP BY per_id)"
            EtxtPER_ID.pComportamiento = 3
            EtxtPER_ID.pOrdenBusqueda = 0

            EtxtLPR_ID.pOOrm = New Ladisac.BE.ListaPreciosArticulos
            EtxtLPR_ID.pComportamiento = 4
            EtxtLPR_ID.pOrdenBusqueda = 0

            EtxtART_IDD.pOOrm = New Ladisac.BE.DetalleListaPrecios
            EtxtART_IDD.pOOrm.vFLagBuscarRegistros = False
            EtxtART_IDD.pComportamiento = 5
            EtxtART_IDD.pOrdenBusqueda = 10
            EtxtART_IDD.pMostrarDatosGrid = True
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

            EchkDTP_CRITERIO = EchkTemporal
            EchkDTP_CRITERIO.pNombreCampo = "DTP_CRITERIO"
            EchkDTP_CRITERIO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkDTP_CRITERIO)

            EchkDTP_SUB_CRITERIO = EchkTemporal
            EchkDTP_SUB_CRITERIO.pNombreCampo = "DTP_SUB_CRITERIO"
            EchkDTP_SUB_CRITERIO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkDTP_SUB_CRITERIO)

            EchkDTP_ESTADO = EchkTemporal
            EchkDTP_ESTADO.pNombreCampo = "DTP_ESTADO"
            EchkDTP_ESTADO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkDTP_ESTADO)

            EchkART_ESTADO = EchkTemporal
            EchkART_ESTADO.pNombreCampo = "ART_ESTADO"
            ConfigurarCheck_Refrescar(EchkART_ESTADO)

            EchkTIV_ESTADO = EchkTemporal
            EchkTIV_ESTADO.pNombreCampo = "TIV_ESTADO"
            ConfigurarCheck_Refrescar(EchkTIV_ESTADO)
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkDTP_CRITERIO"
                    Compuesto.CampoId = EchkDTP_CRITERIO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkDTP_SUB_CRITERIO"
                    Compuesto.CampoId = EchkDTP_SUB_CRITERIO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkDTP_ESTADO"
                    Compuesto.CampoId = EchkDTP_ESTADO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkART_ESTADO"
                    Compuesto.CampoId = EchkART_ESTADO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
                Case "chkTIV_ESTADO"
                    Compuesto.CampoId = EchkTIV_ESTADO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Compuesto.DevolverTiposCampos()
        End Function
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkDTP_CRITERIO"
                    vObjetoChk.pValorDefault = EchkDTP_CRITERIO.pValorDefault
                Case "chkDTP_SUB_CRITERIO"
                    vObjetoChk.pValorDefault = EchkDTP_SUB_CRITERIO.pValorDefault
                Case "chkDTP_ESTADO"
                    vObjetoChk.pValorDefault = EchkDTP_ESTADO.pValorDefault
                Case "chkART_ESTADO"
                    vObjetoChk.pValorDefault = EchkART_ESTADO.pValorDefault
                Case "chkTIV_ESTADO"
                    vObjetoChk.pValorDefault = EchkTIV_ESTADO.pValorDefault
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
            Handles chkDTP_ESTADO.CheckedChanged, chkDTP_CRITERIO.CheckedChanged, chkDTP_SUB_CRITERIO.CheckedChanged, chkART_ESTADO.CheckedChanged, chkTIV_ESTADO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkDTP_CRITERIO"
                    If EchkDTP_CRITERIO.pFormatearTexto Then
                        InicializarTextoCheck(EchkDTP_CRITERIO)
                    End If
                Case "chkDTP_SUB_CRITERIO"
                    If EchkDTP_CRITERIO.pFormatearTexto Then
                        InicializarTextoCheck(EchkDTP_SUB_CRITERIO)
                    End If
                Case "chkART_ESTADO"
                    If EchkART_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkART_ESTADO)
                    End If
                Case "chkTIV_ESTADO"
                    If EchkTIV_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkTIV_ESTADO)
                    End If
                Case "chkDTP_ESTADO"
                    If EchkDTP_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkDTP_ESTADO)
                    End If
            End Select
        End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "DTP_CRITERIO"
                    With chkDTP_CRITERIO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "DTP_SUB_CRITERIO"
                    With chkDTP_SUB_CRITERIO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "DTP_ESTADO"
                    With chkDTP_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "ART_ESTADO"
                    With chkART_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "TIV_ESTADO"
                    With chkTIV_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTextoCheck(EchkDTP_CRITERIO)
            InicializarTextoCheck(EchkDTP_SUB_CRITERIO)
            InicializarTextoCheck(EchkDTP_ESTADO)
            InicializarTextoCheck(EchkART_ESTADO)
            InicializarTextoCheck(EchkTIV_ESTADO)
        End Sub
#End Region

#Region "DataGridView"
        Private Sub ConfigurarDataGridView()
            EdgvDetalle.pAnchoColumna = 20
            EdgvDetalle.pBloquearPk = True
            EdgvDetalle.pColorColumna = Drawing.Color.Black
            EdgvDetalle.pCampoEstadoRegistro = "cEstadoRegistro"
            EdgvDetalle.pMetodoColumnas = True
            EdgvDetalle.Elementos = 1
            ReDim EdgvDetalle.pArrayCamposPkDetalle(1)
            EdgvDetalle.pArrayCamposPkDetalle(1) = "cART_ID"
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
                    eConfigurarDataGridObjeto.Array = {0, 1}
                    ConfigurarGrid(dgvDetalle, eConfigurarDataGridObjeto)
                Case "ElementoItem"
                    eConfigurarDataGridObjeto.Metodo = "ElementoItem"
                    eConfigurarDataGridObjeto.Columna = "cItem"
                    ConfigurarGrid(dgvDetalle, eConfigurarDataGridObjeto)
            End Select
        End Sub

        Private Sub dgvDetalle_AllowUserToAddRowsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle.AllowUserToAddRowsChanged

        End Sub

        Private Sub dgvDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles dgvDetalle.KeyDown
            If dgvDetalle.RowCount = 0 Then Exit Sub
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtART_IDD.pBusqueda Then
                                EtxtART_IDD.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                                MetodoBusquedaDato("", False, EtxtART_IDD)
                                EtxtART_IDD.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                                EtxtART_IDD.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                            End If
                    End Select
            End Select
        End Sub
        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDetalle.CellDoubleClick
            If dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name = "cART_ID" Then
                If EtxtART_IDD.pFormularioConsulta Then
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
                            'ControlReadOnly(dgvDetalle.Columns(vCampoPk), False)
                            dgvDetalle.Columns(vCampoPk).ReadOnly = False
                            EtxtART_IDD.pBusqueda = True
                        Else
                            dgvDetalle.Columns(vCampoPk).ReadOnly = True
                            'ControlReadOnly(dgvDetalle.Columns(vCampoPk), True)
                            EtxtART_IDD.pBusqueda = False
                        End If
                    End If
                Next elemento
            End If
        End Sub
        Private Sub dgvDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvDetalle.CellEnter
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID"
                    EtxtART_IDD.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
            End Select
        End Sub

        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
             Handles dgvDetalle.CellValidated
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID"
                    EtxtART_IDD.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value '.ToString
                    'ValidarDatos(EtxtART_IDD, txtLPR_ID.Text & dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value.ToString, True, sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString)
                    ValidarDatos(EtxtART_IDD, txtLPR_ID.Text & dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value, True, sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name)
                    EtxtART_IDD.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value '.ToString
                    EtxtART_IDD.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value '.ToString
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
                    Case "cART_ID"
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

            EtxtLPR_ID = EtxtTemporal
            EtxtART_ID = EtxtTemporal
            EtxtART_FACTOR = EtxtTemporal
            EtxtDLP_PRECIO_MINIMO = EtxtTemporal
            EtxtDLP_PRECIO_UNITARIO = EtxtTemporal
            EtxtDLP_RECARGO_ENVIO = EtxtTemporal
            EtxtDTP_DESCRIPCION = EtxtTemporal
            EtxtTIV_ID = EtxtTemporal
            EtxtTIV_DIAS = EtxtTemporal

            EtxtDTP_MONTO_TIV = EtxtTemporal
            EtxtDTP_MONTO_TIV.pNegativos = True

            EtxtPER_ID = EtxtTemporal

            EtxtDTP_MONTO_PER = EtxtTemporal
            EtxtDTP_MONTO_PER.pNegativos = True

            EtxtDTP_MONTO_MINIMO = EtxtTemporal
            EtxtDTP_MONTO_MAXIMO = EtxtTemporal

            EtxtDTP_CANT_MINIMA = EtxtTemporal
            EtxtDTP_CANT_MAXIMA = EtxtTemporal

            EtxtART_IDD = EtxtTemporal

            EtxtTIV_ID.pBusqueda = True
            EtxtTIV_ID.pFormularioConsulta = True

            EtxtPER_ID.pBusqueda = True
            EtxtPER_ID.pFormularioConsulta = True

            EtxtART_ID.pBusqueda = True
            'EtxtART_ID.pFormularioConsulta = True

            EtxtLPR_ID.pBusqueda = True
            EtxtLPR_ID.pFormularioConsulta = True

            EtxtART_IDD.pBusqueda = True
            'EtxtART_IDD.pFormularioConsulta = True

        End Sub
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles txtTIV_ID.KeyDown, _
                    txtPER_ID.KeyDown, _
                    txtART_ID.KeyDown, _
                    txtLPR_ID.KeyDown
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtTIV_ID"
                            TeclaF1(EtxtTIV_ID, txtTIV_ID)
                        Case "txtPER_ID"
                            TeclaF1(EtxtPER_ID, txtPER_ID)
                        Case "txtART_ID"
                            TeclaF1(EtxtART_ID, txtART_ID)
                        Case "txtLPR_ID"
                            TeclaF1(EtxtLPR_ID, txtLPR_ID)
                    End Select
            End Select
        End Sub
#End Region

#End Region
#Region "Secundaria 2"
        Private Sub FormatearCampos()
            FormatearCampos(txtLPR_ID, "LPR_ID", EtxtLPR_ID)
            FormatearCampos(txtART_ID, "ART_ID", EtxtART_ID)
            FormatearCampos(txtART_FACTOR, "ART_FACTOR", EtxtART_FACTOR, False)
            FormatearCampos(txtDLP_PRECIO_MINIMO, "DLP_PRECIO_MINIMO", EtxtDLP_PRECIO_MINIMO, False)
            FormatearCampos(txtDLP_PRECIO_UNITARIO, "DLP_PRECIO_UNITARIO", EtxtDLP_PRECIO_UNITARIO, False)
            FormatearCampos(txtDLP_RECARGO_ENVIO, "DLP_RECARGO_ENVIO", EtxtDLP_RECARGO_ENVIO, False)
            FormatearCampos(txtDTP_DESCRIPCION, "DTP_DESCRIPCION", EtxtDTP_DESCRIPCION)
            FormatearCampos(txtTIV_ID, "TIV_ID", EtxtTIV_ID)
            FormatearCampos(txtTIV_DIAS, "TIV_DIAS", EtxtTIV_DIAS)
            FormatearCampos(cboDTP_TIPO_DESC_INC, "DTP_TIPO_DESC_INC", Nothing)
            FormatearCampos(txtDTP_MONTO_TIV, "DTP_MONTO_TIV", EtxtDTP_MONTO_TIV, False)
            FormatearCampos(txtPER_ID, "PER_ID", EtxtPER_ID)
            FormatearCampos(txtDTP_MONTO_PER, "DTP_MONTO_PER", EtxtDTP_MONTO_PER, False)
            FormatearCampos(txtDTP_MONTO_MINIMO, "DTP_MONTO_MINIMO", EtxtDTP_MONTO_MINIMO, False)
            FormatearCampos(txtDTP_MONTO_MAXIMO, "DTP_MONTO_MAXIMO", EtxtDTP_MONTO_MAXIMO, False)
            FormatearCampos(txtDTP_CANT_MINIMA, "DTP_CANT_MINIMA", EtxtDTP_CANT_MINIMA, False)
            FormatearCampos(txtDTP_CANT_MAXIMA, "DTP_CANT_MAXIMA", EtxtDTP_CANT_MAXIMA, False)
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
            EtxtTIV_ID.pOOrm.CadenaFiltrado = ""
            EtxtPER_ID.pOOrm.CadenaFiltrado = " AND PER_ID IN (SELECT per_id FROM vwrolpersonatipopersona " & _
                                                              "WHERE  PER_CLIENTE='SI' and TPE_CLIENTE='SI' and " & _
                                                                     "TPE_ESTADO='ACTIVO' and RTP_ESTADO='ACTIVO' and PER_ESTADO='ACTIVO' " & _
                                                              "GROUP  BY per_id)"


            'EtxtLPR_ID.pOOrm.CadenaFiltrado = ""
        End Sub
#Region "ComboBox"
        Private Sub ConfigurarComboBox()
            EcboDTP_TIPO_DESC_INC.pNombreCampo = "DTP_TIPO_DESC_INC"
            cboDTP_TIPO_DESC_INC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        End Sub
#End Region

#Region "TextBox"
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtTIV_ID.GotFocus, _
                    txtPER_ID.GotFocus, _
                    txtART_ID.GotFocus, _
                    txtLPR_ID.GotFocus
            Select Case sender.name.ToString
                Case "txtTIV_ID"
                    EtxtTIV_ID.pTexto1 = sender.text
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto1 = sender.text
                Case "txtART_ID"
                    EtxtART_ID.pTexto1 = sender.text
                Case "txtLPR_ID"
                    EtxtLPR_ID.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtTIV_ID.LostFocus, _
                    txtPER_ID.LostFocus, _
                    txtART_ID.LostFocus, _
                    txtLPR_ID.LostFocus
            Select Case sender.name.ToString
                Case "txtTIV_ID"
                    EtxtTIV_ID.pTexto2 = sender.text
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto2 = sender.text
                Case "txtART_ID"
                    EtxtART_ID.pTexto2 = sender.text
                Case "txtLPR_ID"
                    EtxtLPR_ID.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtLPR_ID.Validated, _
                    txtART_ID.Validated, _
                    txtTIV_ID.Validated, _
                    txtPER_ID.Validated, _
                    txtDTP_MONTO_TIV.Validated, _
                    txtDTP_MONTO_PER.Validated, _
                    txtDTP_MONTO_MINIMO.Validated, _
                    txtDTP_MONTO_MAXIMO.Validated, _
                    txtDTP_CANT_MINIMA.Validated, _
                    txtDTP_CANT_MAXIMA.Validated

            Select Case sender.name.ToString
                Case "txtLPR_ID"
                    ValidarDatos(EtxtLPR_ID, txtLPR_ID)
                Case "txtART_ID"
                    ValidarDatos(EtxtART_ID, txtART_ID)
                Case "txtTIV_ID"
                    ValidarDatos(EtxtTIV_ID, txtTIV_ID)
                Case "txtPER_ID"
                    ValidarDatos(EtxtPER_ID, txtPER_ID)
                Case "txtDTP_MONTO_TIV"
                    ValidarDatos(EtxtDTP_MONTO_TIV, txtDTP_MONTO_TIV)
                    PorMontoTiv()
                Case "txtDTP_MONTO_PER"
                    ValidarDatos(EtxtDTP_MONTO_PER, txtDTP_MONTO_PER)
                    PorMontoPer()
                Case "txtDTP_MONTO_MINIMO"
                    ValidarDatos(EtxtDTP_MONTO_MINIMO, txtDTP_MONTO_MINIMO)
                Case "txtDTP_MONTO_MAXIMO"
                    ValidarDatos(EtxtDTP_MONTO_MAXIMO, txtDTP_MONTO_MAXIMO)
                Case "txtDTP_CANT_MINIMA"
                    ValidarDatos(EtxtDTP_CANT_MINIMA, txtDTP_CANT_MINIMA)
                Case "txtDTP_CANT_MAXIMA"
                    ValidarDatos(EtxtDTP_CANT_MAXIMA, txtDTP_CANT_MAXIMA)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles txtLPR_ID.KeyPress, _
                    txtART_ID.KeyPress, _
                    txtTIV_ID.KeyPress, _
                    txtPER_ID.KeyPress, _
                    txtDTP_DESCRIPCION.KeyPress, _
                    txtDTP_MONTO_TIV.KeyPress, _
                    txtDTP_MONTO_PER.KeyPress, _
                    txtDTP_MONTO_MINIMO.KeyPress, _
                    txtDTP_MONTO_MAXIMO.KeyPress, _
                    txtDTP_CANT_MINIMA.KeyPress, _
                    txtDTP_CANT_MAXIMA.KeyPress
            Select Case sender.name.ToString
                Case "txtLPR_ID"
                    oKeyPress(EtxtLPR_ID, e)
                Case "txtART_ID"
                    oKeyPress(EtxtART_ID, e)
                Case "txtTIV_ID"
                    oKeyPress(EtxtTIV_ID, e)
                Case "txtPER_ID"
                    oKeyPress(EtxtPER_ID, e)
                Case "txtDTP_DESCRIPCION"
                    oKeyPress(EtxtDTP_DESCRIPCION, e)
                Case "txtDTP_MONTO_TIV"
                    oKeyPress(EtxtDTP_MONTO_TIV, e)
                Case "txtDTP_MONTO_PER"
                    oKeyPress(EtxtDTP_MONTO_PER, e)
                Case "txtDTP_MONTO_MINIMO"
                    oKeyPress(EtxtDTP_MONTO_MINIMO, e)
                Case "txtDTP_MONTO_MAXIMO"
                    oKeyPress(EtxtDTP_MONTO_MAXIMO, e)
                Case "txtDTP_CANT_MINIMA"
                    oKeyPress(EtxtDTP_CANT_MINIMA, e)
                Case "txtDTP_CANT_MAXIMA"
                    oKeyPress(EtxtDTP_CANT_MAXIMA, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtTIV_ID.DoubleClick, _
                    txtPER_ID.DoubleClick, _
                    txtART_ID.DoubleClick, _
                    txtLPR_ID.DoubleClick
            Select Case sender.name.ToString
                Case "txtTIV_ID"
                    oDoubleClick(EtxtTIV_ID, txtTIV_ID, "frmTipoVenta")
                Case "txtPER_ID"
                    oDoubleClick(EtxtPER_ID, txtPER_ID, "frmPersonas")
                Case "txtART_ID"
                    'oDoubleClick(EtxtART_ID, txtART_ID, "frmArticulos")
                Case "txtLPR_ID"
                    oDoubleClick(EtxtLPR_ID, txtLPR_ID, "frmListaPreciosArticulos")
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
                    Case "frmTipoVenta"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.CuentasCorrientes.Views.frmTipoVenta)()
                    Case "frmPersonas"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                    Case "frmListaPreciosArticulos"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.CuentasCorrientes.Views.frmListaPreciosArticulos)()
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
        Public Sub PorArticulo()
            If txtART_ID.Text.Trim = "" Then
                txtDTP_MONTO_MINIMO.Text = "0"
                txtDTP_MONTO_MAXIMO.Text = "0"
                txtDTP_MONTO_MINIMO.Enabled = True
                txtDTP_MONTO_MAXIMO.Enabled = True
                txtDTP_MONTO_MINIMO.ReadOnly = False
                txtDTP_MONTO_MAXIMO.ReadOnly = False

                txtDTP_CANT_MINIMA.Text = "0"
                txtDTP_CANT_MAXIMA.Text = "0"
                txtDTP_CANT_MINIMA.Enabled = False
                txtDTP_CANT_MAXIMA.Enabled = False
                txtDTP_CANT_MINIMA.ReadOnly = True
                txtDTP_CANT_MAXIMA.ReadOnly = True

                dgvDetalle.Enabled = True
            Else
                txtDTP_MONTO_MINIMO.Text = "0"
                txtDTP_MONTO_MAXIMO.Text = "0"
                txtDTP_MONTO_MINIMO.Enabled = False
                txtDTP_MONTO_MAXIMO.Enabled = False
                txtDTP_MONTO_MINIMO.ReadOnly = True
                txtDTP_MONTO_MAXIMO.ReadOnly = True

                txtDTP_CANT_MINIMA.Text = "0"
                txtDTP_CANT_MAXIMA.Text = "0"
                txtDTP_CANT_MINIMA.Enabled = True
                txtDTP_CANT_MAXIMA.Enabled = True
                txtDTP_CANT_MINIMA.ReadOnly = False
                txtDTP_CANT_MAXIMA.ReadOnly = False

                dgvDetalle.Enabled = False
            End If
        End Sub
        Public Sub PorPersona()
            If txtPER_ID.Text.Trim = "" Then
                chkDTP_CRITERIO.Checked = CheckState.Checked
                chkDTP_SUB_CRITERIO.Enabled = False
                chkDTP_SUB_CRITERIO.Visible = False
                lblDTP_SUB_CRITERIO.Visible = False
                txtDTP_MONTO_PER.Text = "0"
            Else
                txtDTP_MONTO_TIV.Text = "0"
                chkDTP_CRITERIO.Checked = CheckState.Unchecked
                chkDTP_SUB_CRITERIO.Enabled = True
                chkDTP_SUB_CRITERIO.Visible = True
                lblDTP_SUB_CRITERIO.Visible = True
            End If
        End Sub
        Private Sub PorMontoTiv()
            If CDbl(txtDTP_MONTO_TIV.Text) <> 0 Then
                txtPER_ID.Text = ""
                txtPER_DESCRIPCION.Text = ""
                PorPersona()
            End If
        End Sub
        Private Sub PorMontoPer()
            PorPersona()
        End Sub
        Private Sub MensajeOperaciones(ByVal vRespuesta As Int16, ByVal vOperacion As String)
            Select Case vRespuesta
                Case 1
                    MsgBox("Registro " & vOperacion, MsgBoxStyle.Information, Me.Text)
                Case 2
                    MsgBox("Registro no fue " & vOperacion & " verifique sus datos" & _
                           Chr(13) & Chr(13) & Compuesto.vMensajeError & _
                           Chr(13) & Chr(13) & Compuesto1.vMensajeError, _
                           MsgBoxStyle.Information, Me.Text)
            End Select
        End Sub

        Private Function ValidarAdicionarFilasGrid() As Boolean
            ValidarAdicionarFilasGrid = True
            'ErrorProvider1.SetError(txtFLE_ID, Nothing)
            If Not dgvDetalle.Enabled Then
                'If txtFLE_ID.Text.Trim = "" Then
                'ErrorProvider1.SetError(txtFLE_ID, "Ingrese el código del flete de la zona")
                ValidarAdicionarFilasGrid = False
                'End If
            End If
            Return ValidarAdicionarFilasGrid
        End Function

        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 5 ' DetalleListaPrecios
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function
    End Class
End Namespace