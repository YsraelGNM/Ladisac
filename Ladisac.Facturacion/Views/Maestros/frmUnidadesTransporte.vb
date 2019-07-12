Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Maestros.Views
    Public Class frmUnidadesTransporte
#Region "Primaria 1"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        Private pLoaded As Boolean = True
        Private pRegistroNuevo As Boolean = False
        Private pColeccionDatos As Collection = Nothing
        Private pComportamiento As Int32 = 0
        Private pOrdenBusqueda As Int32 = 0
        Private pDatoBusquedaConsulta As String = ""
        Private pFlagNuevo As Boolean = False

        Protected Shared vrO As Boolean = True
        Protected Shared vrM As Boolean = True
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

        Public Structure chk
            Public Property pFormatearTexto As Boolean
            Public Property pNombreCampo As String
            Public Property vEstado0 As String
            Public Property vEstado1 As String
            Public Property vEstadoX As String
            Public Property pSimple As Object
            Public Property pValorDefault As System.Windows.Forms.CheckState
        End Structure
        Public Structure cbo
            Public Property pNombreCampo As String
        End Structure
        Public Structure txt
            Public Property pTexto1 As String
            Public Property pTexto2 As String
            Public Property pSoloNumerosDecimales As Boolean
            Public Property pSoloNumeros As Boolean
            Public Property pParteEntera As Int16
            Public Property pParteDecimal As Int16
            Public Property pMinusculaMayuscula As Boolean
            Public Property pBusqueda As Boolean
            Public Property pCadenaFiltrado As String

            Public Property pOOrm As Object
            Public Property pFormularioConsulta As Boolean

            Public Property pComportamiento As Int16
            Public Property pOrdenBusqueda As Int16
            Public Property pMostrarDatosGrid As Boolean
        End Structure

        Protected Structure RespuestaValidar
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
                txtPER_ID.Text = LLamadaDesdeFormularioDatos.pPer_Id
                cboUNT_TIPO.Text = LLamadaDesdeFormularioDatos.pUnt_Tipo
                txtUNT_ANIO_FABRICACION.Text = LLamadaDesdeFormularioDatos.pUnt_Anio_Fabricacion

                MetodoBusquedaDato(txtPER_ID.Text & BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC, True, EtxtPER_ID)
            End If
        End Sub
        Public Sub EditarRegistro()
            If Not pFlagNuevo Then If Trim(pCodigoId) = "" Then Return
            BotonesEdicion("Editar registro")

            If pLLamadaDesdeFormularioModificar Then
                BotonesEdicion(LLamadaDesdeFormularioDatos.pProcesoBotonesEdicion)
            End If
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
                    End If
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
                If pLLamadaDesdeFormularioCrear Or _
                   pLLamadaDesdeFormularioModificar Then
                    NombreFormulario.BuscarCuadroTexto = True
                    NombreFormulario.CuadroTexto.Text = txtUNT_ID.Text
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
                If vControl.GetType.BaseType = GetType(System.Windows.Forms.PictureBox) Then
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
                If vControl.GetType.BaseType = GetType(System.Windows.Forms.DataGridView) Then
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
                        DatoBusquedaConsulta = ""
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = ""
                        frm.oOrm = Simple
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

        ' PrepararGuardar
        Private Function Ingresar() As Boolean
            Ingresar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                If (InsertarDatos()) Then
                    Ingresar = True
                    If Not LlamadaDesdeFormularioCrear Then MsgBox("Registro ingresado", MsgBoxStyle.Information, Me.Text)
                Else
                    MsgBox("No se pudo ingresar verifique sus datos" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
                End If
            End If
            InicializarOrm()
            Return Ingresar
        End Function
        Private Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            'Simple.MarkAsAdded()
            'vRespuestaLocal = Me.IBC.Mantenimiento(Simple)
            vRespuestaLocal = IBC.spInsertarRegistro(Simple.UNT_ID, Simple.UNT_COMPORTAMIENTO, Simple.UNT_TIPO, Simple.TUN_ID, Simple.MAR_ID, Simple.MOD_ID, Simple.UNT_TARA, Simple.UNT_NRO_INS, Simple.PER_ID, Simple.UNT_KILOMETRAJE, Simple.UNT_HOROMETRO, Simple.UNT_NRO_SERIE, Simple.UNT_NRO_MOTOR, Simple.UNT_ANIO_FABRICACION, Simple.UNT_FECHA_ADQUISICION, Simple.USU_ID, Simple.UNT_FEC_GRAB, Simple.UNT_ESTADO)
            InsertarDatos = (vRespuestaLocal > 0)
        End Function
        Private Function Modificar() As Boolean
            Modificar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                If (ActualizarDatos()) Then
                    Modificar = True
                    If Not LlamadaDesdeFormularioModificar Then MsgBox("Registro modificado", MsgBoxStyle.Information, Me.Text)
                Else
                    MsgBox("No se pudo modificar verifique sus datos :" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
                End If
            End If
            InicializarOrm()
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean
            'Simple.MarkAsModified()
            'ActualizarDatos = (Me.IBC.Mantenimiento(Simple) > 0)
            ActualizarDatos = (IBC.spActualizarRegistro(Simple.UNT_ID, Simple.UNT_COMPORTAMIENTO, Simple.UNT_TIPO, Simple.TUN_ID, Simple.MAR_ID, Simple.MOD_ID, Simple.UNT_TARA, Simple.UNT_NRO_INS, Simple.PER_ID, Simple.UNT_KILOMETRAJE, Simple.UNT_HOROMETRO, Simple.UNT_NRO_SERIE, Simple.UNT_NRO_MOTOR, Simple.UNT_ANIO_FABRICACION, Simple.UNT_FECHA_ADQUISICION, Simple.USU_ID, Simple.UNT_FEC_GRAB, Simple.UNT_ESTADO) > 0)
        End Function
        Public Sub InicializarDatos()
            OrmBusquedaDatos("InicializarDatos")
            pRegistroNuevo = False
            pColeccionDatos = RevisarDatosForm(Nothing, False)
        End Sub
        Private Function DevolverTiposCampos(ByVal oNombreCampo As String, ByVal oTexto As String, ByVal oOrm As Object) As String
            oOrm.CampoId = oNombreCampo
            oOrm.Dato = oTexto
            DevolverTiposCampos = oOrm.DevolverTiposCampos()
        End Function

        ' PrepararEliminar
        Private Function EliminarRegistro() As Boolean
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            'Simple.MarkAsDeleted()

            'If (Me.IBC.Mantenimiento(Simple) > 0) Then
            If (IBC.spEliminarRegistro(Simple.UNT_ID) > 0) Then
                EliminarRegistro = True
                MsgBox("Registro eliminado", MsgBoxStyle.Information, Me.Text)
            Else
                EliminarRegistro = False
                MsgBox("No se pudo eliminar verifique sus datos" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
            End If
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
        Private Sub NavegarGrid(ByVal Metodo As String)
            cMisProcedimientos.PosicionGrid(Metodo, ActiveControl, Me.Text)
        End Sub

        ' Formulario Simple
        '' Load
        Public Sub ComportamientoFormulario()
            If pComportamiento <> -1 Or pLLamadaDesdeFormularioModificar Then
                NombresFormulariosControles()
            End If
            pLoaded = False
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String, ByRef sender As txt, Optional ByVal e As System.Boolean = True)
            FormatearCampos(oObjeto, NombreCampo, Simple.vArrayDatosComboBox, Simple.vElementosDatosComboBox - 1, sender, e)
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
        Private Sub BuscarFormatos(ByRef vObjeto As cbo, _
                          ByVal oSimple As Object, _
                          ByRef oComboBox As ComboBox, _
                          ByVal vOrdenBusqueda As Int16)
            oSimple.CampoId = vObjeto.pNombreCampo
            cMisProcedimientos.AdicionarElementoCombosEdicion(oComboBox, oSimple.BuscarFormatos(), vOrdenBusqueda)
        End Sub

        '' ProcessCmdKey
        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            TeclasAccesoRapido(keyData)
            Return MyBase.ProcessCmdKey(msg, keyData)
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
                If pLLamadaDesdeFormularioCrear Then
                    If Trim(txtPER_ID.Text) = "" Then
                        txtPER_ID.Enabled = True
                    Else
                        txtPER_ID.Enabled = False
                    End If

                    cboUNT_COMPORTAMIENTO.Enabled = False
                    If LLamadaDesdeFormularioDatos.pCargando Then
                        'txtDIR_DESCRIPCION.Focus()
                        'LLamadaDesdeFormularioDatos.pCargando = False
                    End If
                ElseIf pLLamadaDesdeFormularioModificar Then
                    txtPER_ID.Enabled = False
                    cboUNT_COMPORTAMIENTO.Enabled = False
                    'txtDIR_DESCRIPCION.Enabled = False
                    If LLamadaDesdeFormularioDatos.pCargando Then
                        'txtDIR_REFERENCIA.Focus()
                        'LLamadaDesdeFormularioDatos.pCargando = False
                    End If
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
        Private Sub frm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) _
            Handles MyBase.FormClosed
            If pComportamiento <> -1 Then
                Cerrado()
            End If
        End Sub
        Private Sub Cerrado()
        End Sub
#End Region

#Region "Secundaria 1"
        <Dependency()> _
        Public Property IBC As Ladisac.BL.IBCUnidadesTransporte

        ' CheckBox
        Private EchkTUN_ESTADO As New chk
        Private EchkMAR_ESTADO As New chk
        Private EchkMOD_ESTADO As New chk
        Private EchkPER_ESTADO As New chk
        Private EchkDOP_ESTADO As New chk
        Private EchkUNT_ESTADO As New chk

        ' ComboBox
        Private EcboUNT_COMPORTAMIENTO As New cbo
        Private EcboUNT_TIPO As New cbo

        ' TextBox
        '' Texto
        Private EtxtUNT_ID As New txt
        Private EtxtTUN_DESCRIPCION As New txt
        Private EtxtMAR_DESCRIPCION As New txt
        Private EtxtMOD_DESCRIPCION As New txt
        Private EtxtUNT_NRO_INS As New txt
        Private EtxtPER_DESCRIPCION As New txt
        Private EtxtTDP_ID As New txt
        Private EtxtTDP_DESCRIPCION As New txt
        Private EtxtDOP_NUMERO As New txt
        Private EtxtUNT_NRO_SERIE As New txt
        Private EtxtUNT_NRO_MOTOR As New txt

        '' Numeros
        Private EtxtUNT_TARA As New txt
        Private EtxtUNT_KILOMETRAJE As New txt
        Private EtxtUNT_HOROMETRO As New txt
        Private EtxtUNT_ANIO_FABRICACION As New txt

        '' PK
        Private EtxtTUN_ID As New txt
        Private EtxtMAR_ID As New txt
        Private EtxtMOD_ID As New txt
        Private EtxtPER_ID As New txt


        Public Property CuadroTexto As New TextBox
        Public Property BuscarCuadroTexto As Boolean = False

        Private Simple As New Ladisac.BE.UnidadesTransporte
        Private ErrorData As New Ladisac.BE.UnidadesTransporte.ErrorData

        Private cMisProcedimientos As New Ladisac.MisProcedimientos

        Private pNombreFormulario As New Ladisac.Foundation.Views.ViewManMaster
        Private pLLamadaDesdeFormularioCrear As Boolean
        Private pLLamadaDesdeFormularioModificar As Boolean

        Public Structure LLamadaDesdeFormularioDatos
            Public Shared Property pUnt_Id As String
            Public Shared Property pUnt_Tipo As String
            Public Shared Property pPer_Id As String
            Public Shared Property pUnt_Anio_Fabricacion As Integer
            Public Shared Property pCargando As Boolean = True
            Public Shared Property pProcesoBotonesEdicion As String
        End Structure

        Public Property NombreFormulario() As Object
            Set(ByVal value As Object)
                pNombreFormulario = value
            End Set
            Get
                Return pNombreFormulario
            End Get
        End Property

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


#End Region
#Region "Secundaria 2"
        ' NuevoRegistro
        Private Sub LimpiarDatos()
            InicializarValores(txtUNT_ID, ErrorProvider1)

            InicializarValores(cboUNT_COMPORTAMIENTO, ErrorProvider1)
            InicializarValores(cboUNT_TIPO, ErrorProvider1)

            InicializarValores(txtTUN_ID, ErrorProvider1)
            InicializarValores(txtTUN_DESCRIPCION, ErrorProvider1)
            InicializarValores(chkTUN_ESTADO, ErrorProvider1, False, False, EchkTUN_ESTADO.pValorDefault)

            InicializarValores(txtMAR_ID, ErrorProvider1)
            InicializarValores(txtMAR_DESCRIPCION, ErrorProvider1)
            InicializarValores(chkMAR_ESTADO, ErrorProvider1, False, False, EchkMAR_ESTADO.pValorDefault)

            InicializarValores(txtMOD_ID, ErrorProvider1)
            InicializarValores(txtMOD_DESCRIPCION, ErrorProvider1)
            InicializarValores(chkMOD_ESTADO, ErrorProvider1, False, False, EchkMOD_ESTADO.pValorDefault)

            InicializarValores(txtUNT_TARA, ErrorProvider1, EtxtUNT_TARA.pSoloNumeros, EtxtUNT_TARA.pSoloNumerosDecimales)
            InicializarValores(txtUNT_NRO_INS, ErrorProvider1)

            InicializarValores(txtPER_ID, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION, ErrorProvider1)
            InicializarValores(chkPER_ESTADO, ErrorProvider1, False, False, EchkPER_ESTADO.pValorDefault)

            InicializarValores(txtTDP_ID, ErrorProvider1)
            InicializarValores(txtTDP_DESCRIPCION, ErrorProvider1)
            InicializarValores(txtDOP_NUMERO, ErrorProvider1)
            InicializarValores(chkDOP_ESTADO, ErrorProvider1, False, False, EchkDOP_ESTADO.pValorDefault)

            InicializarValores(txtUNT_KILOMETRAJE, ErrorProvider1, EtxtUNT_KILOMETRAJE.pSoloNumeros, EtxtUNT_KILOMETRAJE.pSoloNumerosDecimales)
            InicializarValores(txtUNT_HOROMETRO, ErrorProvider1, EtxtUNT_HOROMETRO.pSoloNumeros, EtxtUNT_HOROMETRO.pSoloNumerosDecimales)

            InicializarValores(txtUNT_NRO_SERIE, ErrorProvider1)
            InicializarValores(txtUNT_NRO_MOTOR, ErrorProvider1)

            InicializarValores(txtUNT_ANIO_FABRICACION, ErrorProvider1, EtxtUNT_ANIO_FABRICACION.pSoloNumeros, EtxtUNT_ANIO_FABRICACION.pSoloNumerosDecimales)

            InicializarValores(chkUNT_ESTADO, ErrorProvider1, False, False, EchkUNT_ESTADO.pValorDefault)
        End Sub
        Private Sub HabilitarNuevo()
            txtUNT_ID.Enabled = True
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefaultCheckBox(chkTUN_ESTADO)
            ColocarValoresDefaultCheckBox(chkMAR_ESTADO)
            ColocarValoresDefaultCheckBox(chkMOD_ESTADO)
            ColocarValoresDefaultCheckBox(chkPER_ESTADO)
            ColocarValoresDefaultCheckBox(chkDOP_ESTADO)
            ColocarValoresDefaultCheckBox(chkUNT_ESTADO)
        End Sub
        Private Sub CrearCodigoId()
            'ProcesoCrearCodigoId("CrearCodigoSimple", txtUNT_ID)
        End Sub
        Private Sub HabilitarEscrituraNuevo()
            txtUNT_ID.ReadOnly = False
        End Sub

        ' AgregarFilaGrid
        Private Sub AdicionarFilasGrid()
        End Sub

        ' QuitarFilaGrid
        Private Sub EliminarFilasGrid()
        End Sub

        ' CancelarEdicion
        Public Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "PrepararEliminar"
                    Simple.Vista = "RegistroAnterior"
                    Simple.UNT_ID = CodigoId
                Case "Load"
                    Simple.Vista = "PrimerRegistro"
                    Simple.UNT_ID = CodigoId
                Case "NavegarFormulario"
                    Simple.UNT_ID = CodigoId
                Case "EliminarRegistro"
                    Simple.UNT_ID = txtUNT_ID.Text.Trim
                    CodigoId = txtUNT_ID.Text.Trim
                Case "InicializarDatos"
                    Simple.UNT_ID = txtUNT_ID.Text.Trim
                    CodigoId = txtUNT_ID.Text.Trim
            End Select
        End Sub

        ' PrepararGuardar
        Private Sub DatosCabecera()
            Simple.UNT_ID = Strings.Trim(txtUNT_ID.Text)

            Simple.UNT_COMPORTAMIENTO = DevolverTiposCampos("UNT_COMPORTAMIENTO", cboUNT_COMPORTAMIENTO.Text, Simple)
            Simple.UNT_TIPO = DevolverTiposCampos("UNT_TIPO", cboUNT_TIPO.Text, Simple)

            If Strings.Trim(txtTUN_ID.Text) = "" Then
                Simple.TUN_ID = Nothing
            Else
                Simple.TUN_ID = Strings.Trim(txtTUN_ID.Text)
            End If

            If Strings.Trim(txtMAR_ID.Text) = "" Then
                Simple.MAR_ID = Nothing
            Else
                Simple.MAR_ID = Strings.Trim(txtMAR_ID.Text)
            End If

            If Strings.Trim(txtMOD_ID.Text) = "" Then
                Simple.MOD_ID = Nothing
            Else
                Simple.MOD_ID = Strings.Trim(txtMOD_ID.Text)
            End If

            Simple.UNT_TARA = CDbl(txtUNT_TARA.Text)
            Simple.UNT_NRO_INS = Strings.Trim(txtUNT_NRO_INS.Text)

            If Strings.Trim(txtPER_ID.Text) = "" Then
                Simple.PER_ID = Nothing
            Else
                Simple.PER_ID = Strings.Trim(txtPER_ID.Text)
            End If

            Simple.UNT_KILOMETRAJE = CDbl(txtUNT_KILOMETRAJE.Text)
            Simple.UNT_HOROMETRO = CDbl(txtUNT_HOROMETRO.Text)

            Simple.UNT_NRO_SERIE = Strings.Trim(txtUNT_NRO_SERIE.Text)
            Simple.UNT_NRO_MOTOR = Strings.Trim(txtUNT_NRO_MOTOR.Text)

            Simple.UNT_ANIO_FABRICACION = CInt(txtUNT_ANIO_FABRICACION.Text)
            Simple.UNT_FECHA_ADQUISICION = dtpUNT_FECHA_ADQUISICION.Value

            Simple.USU_ID = SessionService.UserId
            Simple.UNT_FEC_GRAB = Now
            Simple.UNT_ESTADO = DevolverTiposCampos(chkUNT_ESTADO)
        End Sub
        Private Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Simple.ColocarErrores(txtUNT_ID, Simple.VerificarDatos("UNT_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboUNT_COMPORTAMIENTO, Simple.VerificarDatos("UNT_COMPORTAMIENTO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboUNT_TIPO, Simple.VerificarDatos("UNT_TIPO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtTUN_ID, Simple.VerificarDatos("TUN_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtMAR_ID, Simple.VerificarDatos("MAR_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtMOD_ID, Simple.VerificarDatos("MOD_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtUNT_TARA, Simple.VerificarDatos("UNT_TARA"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtUNT_NRO_INS, Simple.VerificarDatos("UNT_NRO_INS"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_ID, Simple.VerificarDatos("PER_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtUNT_KILOMETRAJE, Simple.VerificarDatos("UNT_KILOMETRAJE"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtUNT_HOROMETRO, Simple.VerificarDatos("UNT_HOROMETRO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtUNT_NRO_SERIE, Simple.VerificarDatos("UNT_NRO_SERIE"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtUNT_NRO_MOTOR, Simple.VerificarDatos("UNT_NRO_MOTOR"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtUNT_ANIO_FABRICACION, Simple.VerificarDatos("UNT_ANIO_FABRICACION"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(pnCuerpo, Simple.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(btnImagen, Simple.VerificarDatos("UNT_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkUNT_ESTADO, Simple.VerificarDatos("UNT_ESTADO"), ErrorProvider1)
            End Select
            Return vrO
        End Function
        Private Sub InicializarOrm()
            Simple = Nothing
            Simple = New Ladisac.BE.UnidadesTransporte
        End Sub

        ' Formulario Busqueda
        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
        End Sub

        ' Formulario Simple
        '' ProcessDialogKey - PK
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtTUN_ID" Then EtxtTUN_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMAR_ID" Then EtxtMAR_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMOD_ID" Then EtxtMOD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtTUN_ID" Then EtxtTUN_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMAR_ID" Then EtxtMAR_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMOD_ID" Then EtxtMOD_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function

        '' Load
        Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                LongitudId = 3
                CaracterId = "0"
                ConfigurarCheck()
                ConfigurarComboBox()
                ConfigurarText()
                AdicionarElementoCombosEdicion()
                ComportamientoFormulario()

                If Comportamiento = -1 Then BusquedaDatos("Load")
                If LlamadaDesdeFormularioModificar Then Comportamiento = 0

                FormatearCampos(txtUNT_ID, "UNT_ID", EtxtUNT_ID)
                FormatearCampos(cboUNT_COMPORTAMIENTO, "UNT_COMPORTAMIENTO", Nothing)
                FormatearCampos(cboUNT_TIPO, "UNT_TIPO", Nothing)
                FormatearCampos(txtTUN_ID, "TUN_ID", EtxtTUN_ID)
                FormatearCampos(txtTUN_DESCRIPCION, "TUN_DESCRIPCION", EtxtTUN_DESCRIPCION, False)
                FormatearCampos(txtMAR_ID, "MAR_ID", EtxtMAR_ID)
                FormatearCampos(txtMAR_DESCRIPCION, "MAR_DESCRIPCION", EtxtMAR_DESCRIPCION, False)
                FormatearCampos(txtMOD_ID, "MOD_ID", EtxtMOD_ID)
                FormatearCampos(txtMOD_DESCRIPCION, "MOD_DESCRIPCION", EtxtMOD_DESCRIPCION, False)
                FormatearCampos(txtUNT_TARA, "UNT_TARA", EtxtUNT_TARA)
                FormatearCampos(txtUNT_NRO_INS, "UNT_NRO_INS", EtxtUNT_NRO_INS)
                FormatearCampos(txtPER_ID, "PER_ID", EtxtPER_ID)
                FormatearCampos(txtPER_DESCRIPCION, "PER_DESCRIPCION", EtxtPER_DESCRIPCION, False)
                FormatearCampos(txtTDP_ID, "TDP_ID", EtxtTDP_ID)
                FormatearCampos(txtTDP_DESCRIPCION, "TDP_DESCRIPCION", EtxtTDP_DESCRIPCION, False)
                FormatearCampos(txtDOP_NUMERO, "DOP_NUMERO", EtxtDOP_NUMERO, False)
                FormatearCampos(txtUNT_KILOMETRAJE, "UNT_KILOMETRAJE", EtxtUNT_KILOMETRAJE, False)
                FormatearCampos(txtUNT_HOROMETRO, "UNT_HOROMETRO", EtxtUNT_HOROMETRO, False)
                FormatearCampos(txtUNT_NRO_SERIE, "UNT_NRO_SERIE", EtxtUNT_NRO_SERIE, False)
                FormatearCampos(txtUNT_NRO_MOTOR, "UNT_NRO_MOTOR", EtxtUNT_NRO_MOTOR, False)
                FormatearCampos(txtUNT_ANIO_FABRICACION, "UNT_ANIO_FABRICACION", EtxtUNT_ANIO_FABRICACION)

                If pComportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If

                If pLLamadaDesdeFormularioCrear Then
                    NuevoRegistro()
                End If

                If pLLamadaDesdeFormularioModificar Then
                    tsBarra.Enabled = True
                    EditarRegistro()
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load")
            End Try
        End Sub
        Private Sub AdicionarElementoCombosEdicion()
            BuscarFormatos(EcboUNT_COMPORTAMIENTO, Simple, cboUNT_COMPORTAMIENTO, 0)
            BuscarFormatos(EcboUNT_TIPO, Simple, cboUNT_TIPO, 0)
        End Sub
        Private Sub NombresFormulariosControles()
        End Sub
#End Region

#Region "Primaria CheckBox"
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
#Region "Secundaria CheckBox"
        Private Sub ConfigurarCheck()
            Dim EchkTemporal As New chk

            EchkTemporal.pFormatearTexto = True
            EchkTemporal.vEstado0 = ""
            EchkTemporal.vEstado1 = ""
            EchkTemporal.vEstadoX = ""
            EchkTemporal.pSimple = Simple
            EchkTemporal.pValorDefault = CheckState.Indeterminate

            EchkTUN_ESTADO = EchkTemporal
            EchkTUN_ESTADO.pNombreCampo = "TUN_ESTADO"
            ConfigurarCheck_Refrescar(EchkTUN_ESTADO)

            EchkMAR_ESTADO = EchkTemporal
            EchkMAR_ESTADO.pNombreCampo = "MAR_ESTADO"
            ConfigurarCheck_Refrescar(EchkMAR_ESTADO)

            EchkMOD_ESTADO = EchkTemporal
            EchkMOD_ESTADO.pNombreCampo = "MOD_ESTADO"
            ConfigurarCheck_Refrescar(EchkMOD_ESTADO)

            EchkPER_ESTADO = EchkTemporal
            EchkPER_ESTADO.pNombreCampo = "PER_ESTADO"
            ConfigurarCheck_Refrescar(EchkPER_ESTADO)

            EchkDOP_ESTADO = EchkTemporal
            EchkDOP_ESTADO.pNombreCampo = "DOP_ESTADO"
            ConfigurarCheck_Refrescar(EchkDOP_ESTADO)


            EchkUNT_ESTADO = EchkTemporal
            EchkUNT_ESTADO.pNombreCampo = "UNT_ESTADO"
            EchkUNT_ESTADO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkUNT_ESTADO)
        End Sub

        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkTUN_ESTADO"
                    Simple.CampoId = EchkTUN_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkMAR_ESTADO"
                    Simple.CampoId = EchkMAR_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkMOD_ESTADO"
                    Simple.CampoId = EchkMOD_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_ESTADO"
                    Simple.CampoId = EchkPER_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkDOP_ESTADO"
                    Simple.CampoId = EchkDOP_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkUNT_ESTADO"
                    Simple.CampoId = EchkUNT_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Simple.DevolverTiposCampos()
        End Function

        Public Sub ColocarValoresDefaultCheckBox(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkTUN_ESTADO"
                    vObjetoChk.pValorDefault = EchkTUN_ESTADO.pValorDefault
                Case "chkMAR_ESTADO"
                    vObjetoChk.pValorDefault = EchkMAR_ESTADO.pValorDefault
                Case "chkMOD_ESTADO"
                    vObjetoChk.pValorDefault = EchkMOD_ESTADO.pValorDefault
                Case "chkPER_ESTADO"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO.pValorDefault
                Case "chkDOP_ESTADO"
                    vObjetoChk.pValorDefault = EchkDOP_ESTADO.pValorDefault
                Case "chkUNT_ESTADO"
                    vObjetoChk.pValorDefault = EchkUNT_ESTADO.pValorDefault
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
           Handles chkTUN_ESTADO.CheckedChanged, _
                   chkMAR_ESTADO.CheckedChanged, _
                   chkMOD_ESTADO.CheckedChanged, _
                   chkPER_ESTADO.CheckedChanged, _
                   chkDOP_ESTADO.CheckedChanged, _
                   chkUNT_ESTADO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkTUN_ESTADO"
                    If EchkTUN_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkTUN_ESTADO)
                    End If
                Case "chkMAR_ESTADO"
                    If EchkMAR_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkMAR_ESTADO)
                    End If
                Case "chkMOD_ESTADO"
                    If EchkMOD_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkMOD_ESTADO)
                    End If
                Case "chkPER_ESTADO"
                    If EchkPER_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkPER_ESTADO)
                    End If
                Case "chkDOP_ESTADO"
                    If EchkDOP_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkDOP_ESTADO)
                    End If
                Case "chkUNT_ESTADO"
                    If EchkUNT_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkUNT_ESTADO)
                    End If
            End Select
        End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "TUN_ESTADO"
                    With chkTUN_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "MAR_ESTADO"
                    With chkMAR_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "MOD_ESTADO"
                    With chkMOD_ESTADO
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
                Case "DOP_ESTADO"
                    With chkDOP_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "UNT_ESTADO"
                    With chkUNT_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub

        ' Formulario Búsqueda
        Public Sub Check_Refrescar()
            InicializarTextoCheck(EchkTUN_ESTADO)
            InicializarTextoCheck(EchkMAR_ESTADO)
            InicializarTextoCheck(EchkMOD_ESTADO)
            InicializarTextoCheck(EchkPER_ESTADO)
            InicializarTextoCheck(EchkDOP_ESTADO)
            InicializarTextoCheck(EchkUNT_ESTADO)
        End Sub
#End Region

#Region "Secundaria ComboBox"
        Private Sub ConfigurarComboBox()
            EcboUNT_COMPORTAMIENTO.pNombreCampo = "UNT_COMPORTAMIENTO"
            cboUNT_COMPORTAMIENTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList

            EcboUNT_TIPO.pNombreCampo = "UNT_TIPO"
            cboUNT_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        End Sub
#End Region

#Region "Primaria Text"
        Private Sub ValidarDatos(ByRef otxt As txt, ByRef texto As TextBox)
            With otxt
                If .pTexto1 <> .pTexto2 Then
                    .pTexto2 = texto.Text
                    If .pBusqueda Then
                        MetodoBusquedaDato(texto.Text, True, otxt)
                    End If
                End If
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

        Private Sub TeclaF1(ByRef EtxtTemporal As txt, ByRef txt As TextBox)
            If EtxtTemporal.pBusqueda Then
                EtxtTemporal.pTexto2 = Me.Text
                ValidarDatos(EtxtTemporal, txt)
                MetodoBusquedaDato("", False, EtxtTemporal)
                EtxtTemporal.pTexto1 = Me.Text
                EtxtTemporal.pTexto2 = Me.Text
            End If
        End Sub

        Private Sub oKeyPress(ByVal EtxtTemporal As txt, ByRef e As System.Windows.Forms.KeyPressEventArgs)
            If EtxtTemporal.pMinusculaMayuscula Then
                e.KeyChar = UCase(e.KeyChar)
            End If
            If EtxtTemporal.pSoloNumerosDecimales Then
                If Not IsNumeric(e.KeyChar) Then
                    If Asc(e.KeyChar) <> 46 Then
                        If Asc(e.KeyChar) <> 8 Then
                            e.KeyChar = ""
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
                        e.KeyChar = ""
                    End If
                End If
            End If
        End Sub
#End Region
#Region "Secundaria Text"
        'Campos TextBox edicion y listado
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

            ' Texto
            EtxtUNT_ID = EtxtTemporal
            EtxtTUN_DESCRIPCION = EtxtTemporal
            EtxtMAR_DESCRIPCION = EtxtTemporal
            EtxtMOD_DESCRIPCION = EtxtTemporal
            EtxtUNT_NRO_INS = EtxtTemporal
            EtxtPER_DESCRIPCION = EtxtTemporal
            EtxtTDP_ID = EtxtTemporal
            EtxtTDP_DESCRIPCION = EtxtTemporal
            EtxtDOP_NUMERO = EtxtTemporal
            EtxtUNT_NRO_SERIE = EtxtTemporal
            EtxtUNT_NRO_MOTOR = EtxtTemporal

            ' Numeros
            EtxtUNT_TARA = EtxtTemporal
            EtxtUNT_KILOMETRAJE = EtxtTemporal
            EtxtUNT_HOROMETRO = EtxtTemporal
            EtxtUNT_ANIO_FABRICACION = EtxtTemporal

            EtxtTemporal.pBusqueda = True
            EtxtTemporal.pFormularioConsulta = True

            ' PK
            EtxtTUN_ID = EtxtTemporal
            EtxtMAR_ID = EtxtTemporal
            EtxtMOD_ID = EtxtTemporal
            EtxtPER_ID = EtxtTemporal

            EtxtMAR_ID.pOOrm = New Ladisac.BE.MarcaArticulos
            EtxtMAR_ID.pComportamiento = 1
            EtxtMAR_ID.pOrdenBusqueda = 1
            EtxtMAR_ID.pMostrarDatosGrid = True

            EtxtMOD_ID.pOOrm = New Ladisac.BE.ModeloArticulos
            EtxtMOD_ID.pComportamiento = 2
            EtxtMOD_ID.pOrdenBusqueda = 1
            EtxtMOD_ID.pMostrarDatosGrid = True

            EtxtPER_ID.pOOrm = New Ladisac.BE.DocPersonas
            EtxtPER_ID.pComportamiento = 3
            EtxtPER_ID.pOrdenBusqueda = 1
            EtxtPER_ID.pMostrarDatosGrid = True

            EtxtTUN_ID.pOOrm = New Ladisac.BE.TipoUnidad
            EtxtTUN_ID.pComportamiento = 4
            EtxtTUN_ID.pOrdenBusqueda = 1
            EtxtTUN_ID.pMostrarDatosGrid = True
        End Sub
        ' Campos PK
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtTUN_ID.GotFocus, txtMAR_ID.GotFocus, txtMOD_ID.GotFocus
            Select Case sender.name.ToString
                Case "txtTUN_ID"
                    EtxtTUN_ID.pTexto1 = sender.text
                Case "txtMAR_ID"
                    EtxtMAR_ID.pTexto1 = sender.text
                Case "txtMOD_ID"
                    EtxtMOD_ID.pTexto1 = sender.text
            End Select
        End Sub
        ' Campos PK
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtTUN_ID.LostFocus, txtMAR_ID.LostFocus, txtMOD_ID.LostFocus
            Select Case sender.name.ToString
                Case "txtTUN_ID"
                    EtxtTUN_ID.pTexto2 = sender.text
                Case "txtMAR_ID"
                    EtxtMAR_ID.pTexto2 = sender.text
                Case "txtMOD_ID"
                    EtxtMOD_ID.pTexto2 = sender.text
            End Select
        End Sub
        ' Campos PK y Numeros
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtTUN_ID.Validated, _
                    txtMAR_ID.Validated, txtMOD_ID.Validated, _
                    txtUNT_TARA.Validated, txtUNT_KILOMETRAJE.Validated, _
                    txtUNT_HOROMETRO.Validated, txtUNT_ANIO_FABRICACION.Validated
            Select Case sender.name.ToString
                Case "txtTUN_ID"
                    ValidarDatos(EtxtTUN_ID, txtTUN_ID)
                Case "txtMAR_ID"
                    ValidarDatos(EtxtMAR_ID, txtMAR_ID)
                Case "txtMOD_ID"
                    ValidarDatos(EtxtMOD_ID, txtMOD_ID)
                Case "txtUNT_TARA"
                    ValidarDatos(EtxtUNT_TARA, txtUNT_TARA)
                Case "txtUNT_KILOMETRAJE"
                    ValidarDatos(EtxtUNT_KILOMETRAJE, txtUNT_KILOMETRAJE)
                Case "txtUNT_HOROMETRO"
                    ValidarDatos(EtxtUNT_HOROMETRO, txtUNT_HOROMETRO)
                Case "txtUNT_ANIO_FABRICACION"
                    ValidarDatos(EtxtUNT_ANIO_FABRICACION, txtUNT_ANIO_FABRICACION)
            End Select
        End Sub
        ' Campos PK
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles txtTUN_ID.KeyDown, txtMAR_ID.KeyDown, txtMOD_ID.KeyDown, txtPER_ID.KeyDown
            Select Case e.KeyCode
                Case Keys.F2
                    Select Case sender.name.ToString
                        Case "txtPER_ID"
                            CuadroTexto = txtPER_ID
                            If txtPER_ID.Text <> "" And txtPER_DESCRIPCION.Text <> "" Then
                                PersonasCrearModificar(False, EtxtPER_ID, txtPER_ID.Text)
                            Else
                                PersonasCrearModificar(True, EtxtPER_ID)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtPER_ID.Text, True, EtxtPER_ID)
                    End Select
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtTUN_ID"
                            TeclaF1(EtxtTUN_ID, txtTUN_ID)
                        Case "txtMAR_ID"
                            TeclaF1(EtxtMAR_ID, txtMAR_ID)
                        Case "txtMOD_ID"
                            TeclaF1(EtxtMOD_ID, txtMOD_ID)
                        Case "txtPER_ID"
                            TeclaF1(EtxtPER_ID, txtPER_ID)
                    End Select
            End Select
        End Sub
        ' Campos TextBox Edicion
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles txtUNT_ID.KeyPress, txtTUN_ID.KeyPress, _
                    txtMAR_ID.KeyPress, txtMOD_ID.KeyPress, _
                    txtUNT_NRO_INS.KeyPress, txtDOP_NUMERO.KeyPress, txtUNT_NRO_SERIE.KeyPress, _
                    txtUNT_NRO_MOTOR.KeyPress, txtUNT_TARA.KeyPress, txtUNT_KILOMETRAJE.KeyPress, _
                    txtUNT_HOROMETRO.KeyPress, txtUNT_ANIO_FABRICACION.KeyPress
            Select Case sender.name.ToString
                Case "txtUNT_ID"
                    oKeyPress(EtxtUNT_ID, e)
                Case "txtTUN_ID"
                    oKeyPress(EtxtTUN_ID, e)
                Case "txtMAR_ID"
                    oKeyPress(EtxtMAR_ID, e)
                Case "txtMOD_ID"
                    oKeyPress(EtxtMOD_ID, e)
                Case "txtPER_ID"
                    oKeyPress(EtxtPER_ID, e)
                Case "txtUNT_NRO_INS"
                    oKeyPress(EtxtUNT_NRO_INS, e)
                Case "txtDOP_NUMERO"
                    oKeyPress(EtxtDOP_NUMERO, e)
                Case "txtUNT_NRO_SERIE"
                    oKeyPress(EtxtUNT_NRO_SERIE, e)
                Case "txtUNT_NRO_MOTOR"
                    oKeyPress(EtxtUNT_NRO_MOTOR, e)
                Case "txtUNT_TARA"
                    oKeyPress(EtxtUNT_TARA, e)
                Case "txtUNT_KILOMETRAJE"
                    oKeyPress(EtxtUNT_KILOMETRAJE, e)
                Case "txtUNT_HOROMETRO"
                    oKeyPress(EtxtUNT_HOROMETRO, e)
                Case "txtUNT_ANIO_FABRICACION"
                    oKeyPress(EtxtUNT_ANIO_FABRICACION, e)
            End Select
        End Sub
        ' Campos con consulta
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
          Handles txtTUN_ID.DoubleClick, txtMAR_ID.DoubleClick, txtMOD_ID.DoubleClick, txtPER_ID.DoubleClick
            Select Case sender.name.ToString
                Case "txtTUN_ID"
                    oDoubleClick(EtxtTUN_ID, txtTUN_ID, "frmTipoUnidad")
                Case "txtMAR_ID"
                    'oDoubleClick(EtxtMAR_ID, txtMAR_ID, "frmMarcaArticulos")
                Case "txtMOD_ID"
                    'oDoubleClick(EtxtMOD_ID, txtMOD_ID, "frmModeloArticulos")
                Case "txtPER_ID"
                    oDoubleClick(EtxtPER_ID, txtPER_ID, "frmPersonas")
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
                    Case "frmTipoUnidad"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmTipoUnidad)()
                    Case "frmMarcaArticulos"
                        'frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Facturacion.Views.frmMarcaArticulos)()
                    Case "frmModeloArticulos"
                        'frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Facturacion.Views.frmModeloArticulos)()
                    Case "frmDocPersonas"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmDocPersonas)()
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

        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 1 ' Marca artículos
                    OrdenBusquedaDirecta = 0
                Case 2 ' Modelo artículos
                    OrdenBusquedaDirecta = 0
                Case 3 ' Documento de la persona
                    OrdenBusquedaDirecta = 0
                Case 4 ' Tipo de unidad
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function


        Private Sub PersonasCrearModificar(ByVal vFlagCrear As Boolean, _
                                           ByVal vtxt As txt, _
                                           Optional ByVal vBusqueda As String = "")


            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
            frm.NombreFormulario = Me

            frm.LlamadaDesdeFormularioCrear = vFlagCrear
            frm.LlamadaDesdeFormularioModificar = Not vFlagCrear

            frm.LLamadaDesdeFormularioDatos.pTipoPersonaCrear = BCVariablesNames.TipoPersonas.Transportista
            frm.LLamadaDesdeFormularioDatos.pEsChofer = False
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

            'TeclaF1SubLlamadas(txtPER_ID_REC.Name)
        End Sub


    End Class
End Namespace