Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Maestros.Views
    Public Class frmPlacas
#Region "Primaria 1"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames


        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Private vmBarra(220, 16) As Boolean

        Private pNombreFormulario As New Ladisac.Foundation.Views.ViewManMaster
        Private pLLamadaDesdeFormularioCrear As Boolean
        Private pLLamadaDesdeFormularioModificar As Boolean

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

        Public Structure LLamadaDesdeFormularioDatos
            Public Shared Property pPer_Id_Tra As String
            Public Shared Property pCargando As Boolean = True
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
                'txtPER_ID.Text = LLamadaDesdeFormularioDatos.pPer_Id
                'cboDIR_TIPO.Text = LLamadaDesdeFormularioDatos.pDir_Tipo
                'MetodoBusquedaDato(txtPER_ID.Text, True, EtxtPER_ID)
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
                    NombreFormulario.CuadroTexto.Text = txtPLA_ID.Text
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
                    'Dim resp = Me.IBCBusqueda.CrearCodigoSimple(Simple.CampoPrincipal, _
                    '                                            Simple.cTabla.NombreLargo)
                    'oTexto.Text = resp
                    'For a = 1 To (LongitudId - Len(oTexto.Text.Trim()))
                    'oTexto.Text = CaracterId & oTexto.Text
                    'Next
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
            vRespuestaLocal = IBC.spInsertarRegistro(Simple.PLA_ID, Simple.UNT_ID_1, Simple.UNT_ID_2, Simple.PER_ID, Simple.USU_ID, Simple.PLA_FEC_GRAB, Simple.PLA_ESTADO)
            InsertarDatos = (vRespuestaLocal > 0)
        End Function
        Private Function Modificar() As Boolean
            Modificar = False
            FlagModificar = True
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
            FlagModificar = False
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean
            'Simple.MarkAsModified()
            'ActualizarDatos = (Me.IBC.Mantenimiento(Simple) > 0)
            ActualizarDatos = (IBC.spActualizarRegistro(Simple.PLA_ID, Simple.UNT_ID_1, Simple.UNT_ID_2, Simple.PER_ID, Simple.USU_ID, Simple.PLA_FEC_GRAB, Simple.PLA_ESTADO) > 0)
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
            If (IBC.spEliminarRegistro(Simple.PLA_ID) > 0) Then
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
                    'txtPER_ID.Enabled = False
                    'cboDIR_TIPO.Enabled = False
                    If LLamadaDesdeFormularioDatos.pCargando Then
                        'txtDIR_DESCRIPCION.Focus()
                        'LLamadaDesdeFormularioDatos.pCargando = False
                    End If
                ElseIf pLLamadaDesdeFormularioModificar Then
                    'txtPER_ID.Enabled = False
                    'cboDIR_TIPO.Enabled = False
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
        Public Property IBC As Ladisac.BL.IBCPlacas

        Private FlagModificar As Boolean = False

        ' CheckBox
        Private EchkPER_ESTADO_TRA1 As New chk
        Private EchkPER_ESTADO_TRA2 As New chk
        Private EchkPER_ESTADO_CHO As New chk
        Private EchkPLA_ESTADO As New chk

        ' TextBox
        '' Texto
        Private EtxtPLA_ID As New txt

        Private EtxtMAR_DESCRIPCION_TRA1 As New txt
        Private EtxtMOD_DESCRIPCION_TRA1 As New txt
        Private EtxtPER_ID_TRA1 As New txt
        Private EtxtPER_DESCRIPCION_TRA1 As New txt
        Private EtxtRUC_TRA1 As New txt
        Private EtxtUNT_NRO_INS_TRA1 As New txt

        Private EtxtMAR_DESCRIPCION_TRA2 As New txt
        Private EtxtMOD_DESCRIPCION_TRA2 As New txt
        Private EtxtPER_ID_TRA2 As New txt
        Private EtxtPER_DESCRIPCION_TRA2 As New txt
        Private EtxtRUC_TRA2 As New txt
        Private EtxtUNT_NRO_INS_TRA2 As New txt

        Private EtxtPER_DESCRIPCION_CHO As New txt
        Private EtxtPER_BREVETE_CHO As New txt

        '' Numeros
        Private EtxtUNT_TARA_TRA1 As New txt
        Private EtxtUNT_TARA_TRA2 As New txt

        '' PK
        Private EtxtUNT_ID_1 As New txt
        Private EtxtUNT_ID_2 As New txt
        Private EtxtPER_ID_CHO As New txt

        Public Property CuadroTexto As New TextBox
        Public Property BuscarCuadroTexto As Boolean = False

        Private Simple As New Ladisac.BE.Placas
        Public Simple1 As New Ladisac.BE.UnidadesTransporte
        Public Simple2 As New Ladisac.BE.Personas
        Private ErrorData As New Ladisac.BE.Placas.ErrorData

        Private cMisProcedimientos As New Ladisac.MisProcedimientos
#End Region
#Region "Secundaria 2"
        ' NuevoRegistro
        Private Sub LimpiarDatos()
            InicializarValores(txtPLA_ID, ErrorProvider1)

            InicializarValores(txtUNT_ID_1, ErrorProvider1)
            InicializarValores(txtMAR_DESCRIPCION_TRA1, ErrorProvider1)
            InicializarValores(txtMOD_DESCRIPCION_TRA1, ErrorProvider1)
            InicializarValores(txtPER_ID_TRA1, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_TRA1, ErrorProvider1)
            InicializarValores(txtRUC_TRA1, ErrorProvider1)
            InicializarValores(chkPER_ESTADO_TRA1, ErrorProvider1, False, False, EchkPER_ESTADO_TRA1.pValorDefault)
            InicializarValores(txtUNT_TARA_TRA1, ErrorProvider1)
            InicializarValores(txtUNT_NRO_INS_TRA1, ErrorProvider1)

            InicializarValores(txtUNT_ID_2, ErrorProvider1)
            InicializarValores(txtMAR_DESCRIPCION_TRA2, ErrorProvider1)
            InicializarValores(txtMOD_DESCRIPCION_TRA2, ErrorProvider1)
            InicializarValores(txtPER_ID_TRA2, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_TRA2, ErrorProvider1)
            InicializarValores(txtRUC_TRA2, ErrorProvider1)
            InicializarValores(chkPER_ESTADO_TRA2, ErrorProvider1, False, False, EchkPER_ESTADO_TRA2.pValorDefault)
            InicializarValores(txtUNT_TARA_TRA2, ErrorProvider1)
            InicializarValores(txtUNT_NRO_INS_TRA2, ErrorProvider1)

            InicializarValores(txtPER_ID_CHO, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION_CHO, ErrorProvider1)
            InicializarValores(chkPER_ESTADO_CHO, ErrorProvider1, False, False, EchkPER_ESTADO_CHO.pValorDefault)


            InicializarValores(chkPLA_ESTADO, ErrorProvider1, False, False, EchkPLA_ESTADO.pValorDefault)
        End Sub
        Private Sub HabilitarNuevo()
            txtPLA_ID.Enabled = True
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkPER_ESTADO_TRA1)
            ColocarValoresDefault(chkPER_ESTADO_TRA2)
            ColocarValoresDefault(chkPER_ESTADO_CHO)
            ColocarValoresDefault(chkPLA_ESTADO)
        End Sub
        Private Sub CrearCodigoId()
            ProcesoCrearCodigoId("CrearCodigoSimple", txtPLA_ID)
        End Sub
        Private Sub HabilitarEscrituraNuevo()
            txtPLA_ID.ReadOnly = False
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
                    Simple.PLA_ID = CodigoId
                Case "Load"
                    Simple.Vista = "PrimerRegistro"
                    Simple.PLA_ID = CodigoId
                Case "NavegarFormulario"
                    Simple.PLA_ID = CodigoId
                Case "EliminarRegistro"
                    Simple.PLA_ID = txtPLA_ID.Text.Trim
                    CodigoId = txtPLA_ID.Text.Trim
                Case "InicializarDatos"
                    Simple.PLA_ID = txtPLA_ID.Text.Trim
                    CodigoId = txtPLA_ID.Text.Trim
            End Select
        End Sub

        ' PrepararGuardar
        Private Sub DatosCabecera()
            If FlagModificar Then
                Simple.PLA_ID = Strings.Trim(txtPLA_ID.Text)
            Else
                Simple.PLA_ID = Me.IBCBusqueda.NuevoPla_IdPlacas()
                txtPLA_ID.Text = Simple.PLA_ID
            End If

            Simple.UNT_ID_1 = Strings.Trim(txtUNT_ID_1.Text)

            If Strings.Trim(txtUNT_ID_2.Text) = "" Then
                Simple.UNT_ID_2 = Nothing
            Else
                Simple.UNT_ID_2 = Strings.Trim(txtUNT_ID_2.Text)
            End If

            Simple.PER_ID = Strings.Trim(txtPER_ID_CHO.Text)

            Simple.USU_ID = SessionService.UserId
            Simple.PLA_FEC_GRAB = Now
            Simple.PLA_ESTADO = DevolverTiposCampos(chkPLA_ESTADO)
        End Sub
        Private Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Simple.ColocarErrores(txtPLA_ID, Simple.VerificarDatos("PLA_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtUNT_ID_1, Simple.VerificarDatos("UNT_ID_1"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtUNT_ID_2, Simple.VerificarDatos("UNT_ID_2"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_ID_CHO, Simple.VerificarDatos("PER_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(pnCuerpo, Simple.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(btnImagen, Simple.VerificarDatos("PLA_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkPLA_ESTADO, Simple.VerificarDatos("PLA_ESTADO"), ErrorProvider1)
            End Select
            Return vrO
        End Function
        Private Sub InicializarOrm()
            Simple = Nothing
            Simple = New Ladisac.BE.Placas
        End Sub

        ' Formulario Busqueda
        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            Select Case vComportamiento
                Case 1 ' Unidad de transporte
                    If txtPER_ID_TRA1.Text = BCVariablesNames.CodigoPersonaElMismo Then
                        EtxtPER_ID_CHO.pOOrm.CadenaFiltrado = " "
                    Else
                        ''EtxtPER_ID_CHO.pOOrm.CadenaFiltrado = " and PER_ID_TRA='" & txtPER_ID_TRA1.Text & "'"
                        'EtxtPER_ID_CHO.pOOrm.CadenaFiltrado = " and (PER_TRANSPORTISTA='SI' or PER_ID='005835')"
                        EtxtPER_ID_CHO.pOOrm.CadenaFiltrado = " "
                    End If

            End Select
        End Sub

        ' Formulario Simple
        '' ProcessDialogKey - PK
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtUNT_ID_1" Then EtxtUNT_ID_1.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtUNT_ID_2" Then EtxtUNT_ID_2.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CHO" Then EtxtPER_ID_CHO.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtUNT_ID_1" Then EtxtUNT_ID_1.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtUNT_ID_2" Then EtxtUNT_ID_2.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CHO" Then EtxtPER_ID_CHO.pTexto2 = Me.ActiveControl.Text
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

                FormatearCampos()

                If Comportamiento <> -1 Then
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
        End Sub
        Private Sub NombresFormulariosControles()
            EtxtUNT_ID_1.pOOrm = Simple1 'New Ladisac.BE.UnidadesTransporte
            EtxtUNT_ID_1.pComportamiento = 1

            EtxtUNT_ID_2.pOOrm = Simple1 'New Ladisac.BE.UnidadesTransporte
            EtxtUNT_ID_2.pComportamiento = 2

            EtxtPER_ID_CHO.pOOrm = Simple2 'New Ladisac.BE.Personas
            EtxtPER_ID_CHO.pComportamiento = 3
            EtxtPER_ID_CHO.pOrdenBusqueda = 4
            ''EtxtPER_ID_CHO.pOOrm.CadenaFiltrado = " and (PER_ID='" & txtPER_ID_TRA1.Text & "' or PER_ID='005835')"
            'EtxtPER_ID_CHO.pOOrm.CadenaFiltrado = " and (PER_ID='" & txtPER_ID_TRA1.Text & "' or PER_ID='005835')"
            EtxtPER_ID_CHO.pOOrm.CadenaFiltrado = " "
        End Sub
#End Region
#Region "Secundaria 3"
        '' Formulario
        ' Load
        Private Sub FormatearCampos()
            'FormatearCampos(TextBox Etc.,Nombre del campo, txt, true opciones para el ancho)

            FormatearCampos(txtPLA_ID, "PLA_ID", EtxtPLA_ID)

            FormatearCampos(txtUNT_ID_1, "UNT_ID_1", EtxtUNT_ID_1)
            FormatearCampos(txtMAR_DESCRIPCION_TRA1, "MAR_DESCRIPCION_TRA1", EtxtMAR_DESCRIPCION_TRA1, False)
            FormatearCampos(txtMOD_DESCRIPCION_TRA1, "MOD_DESCRIPCION_TRA1", EtxtMOD_DESCRIPCION_TRA1, False)
            FormatearCampos(txtPER_ID_TRA1, "PER_ID_TRA1", EtxtPER_ID_TRA1)
            FormatearCampos(txtPER_DESCRIPCION_TRA1, "PER_DESCRIPCION_TRA1", EtxtPER_DESCRIPCION_TRA1, False)
            FormatearCampos(txtRUC_TRA1, "RUC_TRA1", EtxtRUC_TRA1, False)
            FormatearCampos(txtUNT_TARA_TRA1, "UNT_TARA_TRA1", EtxtUNT_TARA_TRA1, False)
            FormatearCampos(txtUNT_NRO_INS_TRA1, "UNT_NRO_INS_TRA1", EtxtUNT_NRO_INS_TRA1, False)

            FormatearCampos(txtUNT_ID_2, "UNT_ID_2", EtxtUNT_ID_2)
            FormatearCampos(txtMAR_DESCRIPCION_TRA2, "MAR_DESCRIPCION_TRA2", EtxtMAR_DESCRIPCION_TRA2, False)
            FormatearCampos(txtMOD_DESCRIPCION_TRA2, "MOD_DESCRIPCION_TRA2", EtxtMOD_DESCRIPCION_TRA2, False)
            FormatearCampos(txtPER_ID_TRA2, "PER_ID_TRA2", EtxtPER_ID_TRA2)
            FormatearCampos(txtPER_DESCRIPCION_TRA2, "PER_DESCRIPCION_TRA2", EtxtPER_DESCRIPCION_TRA2, False)
            FormatearCampos(txtRUC_TRA2, "RUC_TRA2", EtxtRUC_TRA2, False)
            FormatearCampos(txtUNT_TARA_TRA2, "UNT_TARA_TRA2", EtxtUNT_TARA_TRA2, False)
            FormatearCampos(txtUNT_NRO_INS_TRA2, "UNT_NRO_INS_TRA2", EtxtUNT_NRO_INS_TRA2, False)

            FormatearCampos(txtPER_ID_CHO, "PER_ID_CHO", EtxtPER_ID_TRA2)
            FormatearCampos(txtPER_DESCRIPCION_CHO, "PER_DESCRIPCION_CHO", EtxtPER_DESCRIPCION_TRA2, False)
            FormatearCampos(txtPER_BREVETE_CHO, "PER_BREVETE_CHO", EtxtRUC_TRA2, False)
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
        Private Sub FiltrarOrm()
            'EtxtPER_ID_CHO.pOOrm.CadenaFiltrado = " AND PER_BREVETE<>''"
        End Sub
#End Region

#Region "Primaria 1 - CheckBox"
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
#Region "Secundaria 1 - CheckBox"
        Private Sub ConfigurarCheck()
            Dim EchkTemporal As New chk

            EchkTemporal.pFormatearTexto = True
            EchkTemporal.vEstado0 = ""
            EchkTemporal.vEstado1 = ""
            EchkTemporal.vEstadoX = ""
            EchkTemporal.pSimple = Simple
            EchkTemporal.pValorDefault = CheckState.Indeterminate

            EchkPER_ESTADO_TRA1 = EchkTemporal
            EchkPER_ESTADO_TRA1.pNombreCampo = "PER_ESTADO_TRA1"
            ConfigurarCheck_Refrescar(EchkPER_ESTADO_TRA1)

            EchkPER_ESTADO_TRA2 = EchkTemporal
            EchkPER_ESTADO_TRA2.pNombreCampo = "PER_ESTADO_TRA2"
            ConfigurarCheck_Refrescar(EchkPER_ESTADO_TRA2)

            EchkPER_ESTADO_CHO = EchkTemporal
            EchkPER_ESTADO_CHO.pNombreCampo = "PER_ESTADO_CHO"
            ConfigurarCheck_Refrescar(EchkPER_ESTADO_CHO)

            EchkPLA_ESTADO = EchkTemporal
            EchkPLA_ESTADO.pNombreCampo = "PLA_ESTADO"
            EchkPLA_ESTADO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkPLA_ESTADO)
        End Sub

        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkPER_ESTADO_TRA1"
                    Simple.CampoId = EchkPER_ESTADO_TRA1.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_ESTADO_TRA2"
                    Simple.CampoId = EchkPER_ESTADO_TRA2.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_ESTADO_CHO"
                    Simple.CampoId = EchkPER_ESTADO_CHO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPLA_ESTADO"
                    Simple.CampoId = EchkPLA_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Simple.DevolverTiposCampos()
        End Function

        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkPER_ESTADO_TRA1"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO_TRA1.pValorDefault
                Case "chkPER_ESTADO_TRA2"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO_TRA2.pValorDefault
                Case "chkPER_ESTADO_CHO"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO_CHO.pValorDefault
                Case "chkPLA_ESTADO"
                    vObjetoChk.pValorDefault = EchkPLA_ESTADO.pValorDefault
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
           Handles chkPER_ESTADO_TRA1.CheckedChanged, _
                   chkPER_ESTADO_TRA2.CheckedChanged, _
                   chkPER_ESTADO_CHO.CheckedChanged, _
                   chkPLA_ESTADO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkPER_ESTADO_TRA1"
                    If EchkPER_ESTADO_TRA1.pFormatearTexto Then
                        InicializarTextoCheck(EchkPER_ESTADO_TRA1)
                    End If
                Case "chkPER_ESTADO_TRA2"
                    If EchkPER_ESTADO_TRA2.pFormatearTexto Then
                        InicializarTextoCheck(EchkPER_ESTADO_TRA2)
                    End If
                Case "chkPER_ESTADO_CHO"
                    If EchkPER_ESTADO_CHO.pFormatearTexto Then
                        InicializarTextoCheck(EchkPER_ESTADO_CHO)
                    End If
                Case "chkPLA_ESTADO"
                    If EchkPLA_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkPLA_ESTADO)
                    End If
            End Select
        End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "PER_ESTADO_TRA1"
                    With chkPER_ESTADO_TRA1
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_ESTADO_TRA2"
                    With chkPER_ESTADO_TRA2
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
                Case "PLA_ESTADO"
                    With chkPLA_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub

        ' Formulario Búsqueda
        Public Sub Check_Refrescar()
            InicializarTextoCheck(EchkPER_ESTADO_TRA1)
            InicializarTextoCheck(EchkPER_ESTADO_TRA2)
            InicializarTextoCheck(EchkPER_ESTADO_CHO)
            InicializarTextoCheck(EchkPLA_ESTADO)
        End Sub
#End Region

#Region "Primaria 1 - ComboBox"
        Public Structure cbo
            Public Property pNombreCampo As String
        End Structure
#End Region
#Region "Secundaria 1 - ComboBox"
        Private Sub ConfigurarComboBox()
        End Sub
#End Region

#Region "Primaria 1 - Text"
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
                EtxtTemporal.pTexto2 = Me.Text
                ValidarDatos(EtxtTemporal, txt)
                MetodoBusquedaDato("", False, EtxtTemporal)
                EtxtTemporal.pTexto1 = Me.Text
                EtxtTemporal.pTexto2 = Me.Text
            End If
        End Sub
#End Region
#Region "Primaria 2 - Text"
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

#Region "Secundaria 1 - Text"
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

            ' Texto
            EtxtPLA_ID = EtxtTemporal

            EtxtMAR_DESCRIPCION_TRA1 = EtxtTemporal
            EtxtMOD_DESCRIPCION_TRA1 = EtxtTemporal
            EtxtPER_ID_TRA1 = EtxtTemporal
            EtxtPER_DESCRIPCION_TRA1 = EtxtTemporal
            EtxtRUC_TRA1 = EtxtTemporal
            EtxtUNT_NRO_INS_TRA1 = EtxtTemporal

            EtxtMAR_DESCRIPCION_TRA2 = EtxtTemporal
            EtxtMOD_DESCRIPCION_TRA2 = EtxtTemporal
            EtxtPER_ID_TRA2 = EtxtTemporal
            EtxtPER_DESCRIPCION_TRA2 = EtxtTemporal
            EtxtRUC_TRA2 = EtxtTemporal
            EtxtUNT_NRO_INS_TRA2 = EtxtTemporal

            EtxtPER_DESCRIPCION_CHO = EtxtTemporal
            EtxtPER_BREVETE_CHO = EtxtTemporal

            ' Numeros
            EtxtUNT_TARA_TRA1 = EtxtTemporal
            EtxtUNT_TARA_TRA2 = EtxtTemporal

            EtxtTemporal.pBusqueda = True
            EtxtTemporal.pFormularioConsulta = True

            ' PK
            EtxtUNT_ID_1 = EtxtTemporal
            EtxtUNT_ID_2 = EtxtTemporal
            EtxtPER_ID_CHO = EtxtTemporal
        End Sub
        ' Campos PK
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles txtUNT_ID_1.KeyDown, txtUNT_ID_2.KeyDown, txtPER_ID_CHO.KeyDown
            Select Case e.KeyCode
                Case Keys.F2
                    Select Case sender.name.ToString
                        Case "txtUNT_ID_1"
                            CuadroTexto = txtUNT_ID_1
                            If txtUNT_ID_1.Text <> "" Then
                                UnidadTransporteCrearModificar(BCVariablesNames.TipoUnidadTransporte.TipoUnidadTransporte6, False, EtxtUNT_ID_1, txtUNT_ID_1.Text)
                            Else
                                UnidadTransporteCrearModificar(BCVariablesNames.TipoUnidadTransporte.TipoUnidadTransporte6, True, EtxtUNT_ID_1)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtUNT_ID_1.Text, True, EtxtUNT_ID_1)
                        Case "txtUNT_ID_2"
                            CuadroTexto = txtUNT_ID_2
                            If txtUNT_ID_2.Text <> "" Then
                                UnidadTransporteCrearModificar(BCVariablesNames.TipoUnidadTransporte.TipoUnidadTransporte10, False, EtxtUNT_ID_2, txtUNT_ID_2.Text)
                            Else
                                UnidadTransporteCrearModificar(BCVariablesNames.TipoUnidadTransporte.TipoUnidadTransporte10, True, EtxtUNT_ID_2)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtUNT_ID_2.Text, True, EtxtUNT_ID_2)
                        Case "txtPER_ID_CHO"
                            CuadroTexto = txtPER_ID_CHO
                            If txtPER_ID_CHO.Text <> "" Then
                                PersonasCrearModificar(BCVariablesNames.TipoUnidadTransporte.TipoUnidadTransporte10, False, EtxtPER_ID_CHO, txtPER_ID_CHO.Text)
                            Else
                                PersonasCrearModificar(BCVariablesNames.TipoUnidadTransporte.TipoUnidadTransporte10, True, EtxtPER_ID_CHO)
                            End If
                            If BuscarCuadroTexto Then MetodoBusquedaDato(txtPER_ID_CHO.Text, True, EtxtPER_ID_CHO)
                    End Select
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtUNT_ID_1"
                            TeclaF1(EtxtUNT_ID_1, txtUNT_ID_1)
                        Case "txtUNT_ID_2"
                            TeclaF1(EtxtUNT_ID_2, txtUNT_ID_2)
                        Case "txtPER_ID_CHO"
                            If Trim(txtUNT_ID_1.Text) = "" Then
                                ErrorProvider1.SetError(txtUNT_ID_1, "Debe ingresar una unidad de transporte.")
                            Else
                                TeclaF1(EtxtPER_ID_CHO, txtPER_ID_CHO)
                            End If
                    End Select
            End Select
        End Sub
#End Region
#Region "Secundaria 2 - Text"
        ' Campos PK
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtUNT_ID_1.GotFocus, txtUNT_ID_2.GotFocus, txtPER_ID_CHO.GotFocus
            Select Case sender.name.ToString
                Case "txtUNT_ID_1"
                    EtxtUNT_ID_1.pTexto1 = sender.text
                Case "txtUNT_ID_2"
                    EtxtUNT_ID_2.pTexto1 = sender.text
                Case "txtPER_ID_CHO"
                    EtxtPER_ID_CHO.pTexto1 = sender.text
            End Select
        End Sub
        ' Campos PK
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtUNT_ID_1.LostFocus, txtUNT_ID_2.LostFocus, txtPER_ID_CHO.LostFocus
            Select Case sender.name.ToString
                Case "txtUNT_ID_1"
                    EtxtUNT_ID_1.pTexto2 = sender.text
                Case "txtUNT_ID_2"
                    EtxtUNT_ID_2.pTexto2 = sender.text
                Case "txtPER_ID_CHO"
                    EtxtPER_ID_CHO.pTexto2 = sender.text
            End Select
        End Sub
        ' Campos PK y Numeros
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtUNT_ID_1.Validated, txtUNT_ID_2.Validated, txtPER_ID_CHO.Validated
            Select Case sender.name.ToString
                Case "txtUNT_ID_1"
                    ValidarDatos(EtxtUNT_ID_1, txtUNT_ID_1)
                Case "txtUNT_ID_2"
                    ValidarDatos(EtxtUNT_ID_2, txtUNT_ID_2)
                Case "txtPER_ID_CHO"
                    ValidarDatos(EtxtPER_ID_CHO, txtPER_ID_CHO)
            End Select
        End Sub
        ' Campos TextBox Edicion
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles txtUNT_ID_1.KeyPress, txtUNT_ID_2.KeyPress, txtPER_ID_CHO.KeyPress
            Select Case sender.name.ToString
                Case "txtUNT_ID_1"
                    oKeyPress(EtxtUNT_ID_1, e)
                Case "txtUNT_ID_2"
                    oKeyPress(EtxtUNT_ID_2, e)
                Case "txtPER_ID_CHO"
                    oKeyPress(EtxtPER_ID_CHO, e)
            End Select
        End Sub
        ' Campos con consulta
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
          Handles txtUNT_ID_1.DoubleClick, txtUNT_ID_2.DoubleClick, txtPER_ID_CHO.DoubleClick
            Select Case sender.name.ToString
                Case "txtUNT_ID_1"
                    oDoubleClick(EtxtUNT_ID_1, txtUNT_ID_1, "frmUnidadesTransporte")
                Case "txtUNT_ID_2"
                    oDoubleClick(EtxtUNT_ID_2, txtUNT_ID_2, "frmUnidadesTransporte")
                Case "txtPER_ID_CHO"
                    oDoubleClick(EtxtPER_ID_CHO, txtPER_ID_CHO, "frmPersonas")
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
                    Case "frmMarcaArticulos"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmUnidadesTransporte)()
                    Case "frmModeloArticulos"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmUnidadesTransporte)()
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
#End Region

        Private Sub UnidadTransporteCrearModificar(ByVal vTipoUnidadTransporte As String, _
                                                   ByVal vFlagCrear As Boolean, _
                                                   ByVal vtxt As txt, _
                                                   Optional ByVal vBusqueda As String = "")
            If BloquearBusquedaCampos(vtxt) Then Exit Sub

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmUnidadesTransporte)()
            frm.NombreFormulario = Me

            frm.LlamadaDesdeFormularioCrear = vFlagCrear
            frm.LlamadaDesdeFormularioModificar = Not vFlagCrear

            If vFlagCrear Then
                frm.LLamadaDesdeFormularioDatos.pUnt_Id = txtUNT_ID_1.Text
                frm.LLamadaDesdeFormularioDatos.pUnt_Tipo = vTipoUnidadTransporte
                frm.LLamadaDesdeFormularioDatos.pPer_Id = BCVariablesNames.CodigoPersonaElMismo
                frm.LLamadaDesdeFormularioDatos.pUnt_Anio_Fabricacion = Year(Now)
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
        Private Sub PersonasCrearModificar(ByVal vTipoUnidadTransporte As String, _
                                           ByVal vFlagCrear As Boolean, _
                                           ByVal vtxt As txt, _
                                           Optional ByVal vBusqueda As String = "")
            If BloquearBusquedaCampos(vtxt) Then Exit Sub

            ConfigurarPermisos()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
            frm.NombreFormulario = Me

            frm.LlamadaDesdeFormularioCrear = vFlagCrear
            frm.LlamadaDesdeFormularioModificar = Not vFlagCrear
            frm.Nuevo = vmBarra(19, 1)
            frm.vNuevo = vmBarra(19, 1)
            If vFlagCrear Then
                If Me.SessionService.NombreEmpresa = "Ladrillera El Diamante SAC" Then
                    frm.LLamadaDesdeFormularioDatos.pPer_Id_Tra = txtPER_ID_TRA1.Text
                    frm.LLamadaDesdeFormularioDatos.pTipoPersonaCrear = BCVariablesNames.TipoPersonas.Transportista
                    frm.LLamadaDesdeFormularioDatos.pEsChofer = True
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
        End Sub

        Private Sub ConfigurarPermisos()
            Dim CadenaVista As String = ""
            Dim ds As New DataSet

            Dim CadenaPEU_ID As String = ""
            CadenaPEU_ID = Me.IBCBusqueda.ListarIdPermisoUsuario(Me.SessionService.UserId)

            CadenaVista = IBCMaestro.EjecutarVista("spListarDetallePermisoUsuarioXML", CadenaPEU_ID)
            Dim sr As New StringReader(CadenaVista)
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                ConfigurarDatosPermisos(ds.Tables(0))
            Else
                BloquearPermisos()
            End If
        End Sub
        Private Sub BloquearPermisos()
            For vFil = 1 To 220
                For vCol = 1 To 16
                    vmBarra(vFil, vCol) = False
                Next
            Next
        End Sub
        Private Sub ConfigurarDatosPermisos(ByVal dtPermisos As DataTable)
            Dim vFilaGrid As Int16 = 0
            Dim vControl As Boolean = False
            Dim vFilaArray As Int16 = 19
            Dim vBooleanArray As Boolean = False
            If dtPermisos.Rows.Count = 0 Then vControl = True
            While dtPermisos.Rows.Count > vFilaGrid
                With dtPermisos.Rows(vFilaGrid)
                    If .Item("Nuevo") = "SI NUEVO" Then
                        vBooleanArray = True
                    ElseIf .Item("Nuevo") = "NO NUEVO" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 1, vBooleanArray)

                    If .Item("Editar") = "SI EDITAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Editar") = "NO EDITAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 2, vBooleanArray)

                    If .Item("CancelarEditar") = "SI CANCELAREDITAR" Then
                        vBooleanArray = True
                    ElseIf .Item("CancelarEditar") = "NO CANCELAREDITAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 3, vBooleanArray)

                    If .Item("Grabar") = "SI GRABAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Grabar") = "NO GRABAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 4, vBooleanArray)

                    If .Item("GrabarNuevo") = "SI GRABARNUEVO" Then
                        vBooleanArray = True
                    ElseIf .Item("GrabarNuevo") = "NO GRABARNUEVO" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 5, vBooleanArray)

                    If .Item("Eliminar") = "SI ELIMINAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Eliminar") = "NO ELIMINAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 6, vBooleanArray)

                    If .Item("Deshacer") = "SI DESHACER" Then
                        vBooleanArray = True
                    ElseIf .Item("Deshacer") = "NO DESHACER" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 7, vBooleanArray)

                    If .Item("Agregar") = "SI AGREGAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Agregar") = "NO AGREGAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 8, vBooleanArray)

                    If .Item("Quitar") = "SI QUITAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Quitar") = "NO QUITAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 9, vBooleanArray)

                    If .Item("Buscar") = "SI BUSCAR" Then
                        vBooleanArray = True
                    ElseIf .Item("Buscar") = "NO BUSCAR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 10, vBooleanArray)

                    If .Item("OkBusqueda") = "SI OKBUSQUEDA" Then
                        vBooleanArray = True
                    ElseIf .Item("OkBusqueda") = "NO OKBUSQUEDA" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 11, vBooleanArray)

                    If .Item("Inicio") = "SI INICIO" Then
                        vBooleanArray = True
                    ElseIf .Item("Inicio") = "NO INICIO" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 12, vBooleanArray)

                    If .Item("Anterior") = "SI ANTERIOR" Then
                        vBooleanArray = True
                    ElseIf .Item("Anterior") = "NO ANTERIOR" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 13, vBooleanArray)

                    If .Item("Siguiente") = "SI SIGUIENTE" Then
                        vBooleanArray = True
                    ElseIf .Item("Siguiente") = "NO SIGUIENTE" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 14, vBooleanArray)

                    If .Item("Final") = "SI FINAL" Then
                        vBooleanArray = True
                    ElseIf .Item("Final") = "NO FINAL" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 15, vBooleanArray)

                    If .Item("Reportes") = "SI REPORTES" Then
                        vBooleanArray = True
                    ElseIf .Item("Reportes") = "NO REPORTES" Then
                        vBooleanArray = False
                    Else
                        vControl = True
                        Exit While
                    End If
                    PermisosForms(vFilaArray, 16, vBooleanArray)
                End With
                vFilaGrid += 1
            End While
            If vControl Then
                BloquearPermisos()
                Exit Sub
            End If
        End Sub
        Private Sub PermisosForms(ByVal vFila As Int16, ByVal vColumna As Int16, ByVal vBoolean As Boolean)
            vmBarra(vFila, vColumna) = vBoolean
        End Sub


        Private Function BloquearBusquedaCampos(ByVal vtxt As txt, Optional ByVal vMensaje As Boolean = True) As Boolean
            BloquearBusquedaCampos = False
            Return BloquearBusquedaCampos
        End Function
        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 3 ' Personas - Chofer
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function
    End Class
End Namespace