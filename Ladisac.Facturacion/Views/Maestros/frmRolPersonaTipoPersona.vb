Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Maestros.Views
    Public Class frmRolPersonaTipoPersona
#Region "Primaria 1"
        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        Private pLoaded As Boolean = True
        Private pRegistroNuevo As Boolean = False
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

#Region "Secundaria 1"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCRolPersonaTipoPersona As Ladisac.BL.IBCRolPersonaTipoPersona

#Region "Controlar los datos de las tablas"
        Public vCodigoTPE_ID As String = ""
#End Region

        Private EchkPER_CLIENTE As New chk
        Private EchkPER_PROVEEDOR As New chk
        Private EchkPER_TRANSPORTISTA As New chk
        Private EchkPER_TRABAJADOR As New chk
        Private EchkPER_BANCO As New chk
        Private EchkPER_GRUPO As New chk
        Private EchkPER_CONTACTO As New chk

        Private EchkTPE_CLIENTE As New chk
        Private EchkTPE_PROVEEDOR As New chk
        Private EchkTPE_TRANSPORTISTA As New chk
        Private EchkTPE_TRABAJADOR As New chk
        Private EchkTPE_BANCO As New chk
        Private EchkTPE_GRUPO As New chk
        Private EchkTPE_CONTACTO As New chk

        Private EchkRTP_ESTADO As New chk


        Private EtxtPER_DESCRIPCION As New txt
        Private EtxtTPE_DESCRIPCION As New txt

        Private EtxtPER_ID As New txt
        Private EtxtTPE_ID As New txt

        Private Simple As New Ladisac.BE.RolPersonaTipoPersona
        Private ErrorData As New Ladisac.BE.RolPersonaTipoPersona.ErrorData

        Private cMisProcedimientos As New Ladisac.MisProcedimientos
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

        Public Sub InicializarValores(ByRef sender As System.Object, ByRef senderError As System.Windows.Forms.ErrorProvider, _
                                     Optional ByVal e As System.Boolean = False, Optional ByVal e1 As System.Boolean = False, _
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

        Private Function DevolverTiposCampos(ByVal oNombreCampo As String, ByVal oTexto As String, ByVal oOrm As Object) As String
            oOrm.CampoId = oNombreCampo
            oOrm.Dato = oTexto
            DevolverTiposCampos = oOrm.DevolverTiposCampos()
        End Function

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

        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            TeclasAccesoRapido(keyData)
            Return MyBase.ProcessCmdKey(msg, keyData)
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

        Private Sub ComportamientoFormulario()
            If pComportamiento <> -1 Then
                NombresFormulariosControles()
            End If
            pLoaded = False
        End Sub
        Private Sub NombresFormulariosControles()
        End Sub

        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            Dim vFlagCadena As Boolean = False
            Dim vCadenaFiltradoTipoPersona As String = " AND ("
            If chkPER_CLIENTE.Checked Then
                vFlagCadena = True
                vCadenaFiltradoTipoPersona += "TPE_CLIENTE='SI' "
            End If
            If chkPER_PROVEEDOR.Checked Then
                If vFlagCadena Then vCadenaFiltradoTipoPersona += " OR "
                vFlagCadena = True
                vCadenaFiltradoTipoPersona += "TPE_PROVEEDOR='SI' "
            End If
            If chkPER_TRABAJADOR.Checked Then
                If vFlagCadena Then vCadenaFiltradoTipoPersona += " OR "
                vFlagCadena = True
                vCadenaFiltradoTipoPersona += "TPE_TRABAJADOR='SI' "
            End If
            If chkPER_BANCO.Checked Then
                If vFlagCadena Then vCadenaFiltradoTipoPersona += " OR "
                vFlagCadena = True
                vCadenaFiltradoTipoPersona += "TPE_BANCO='SI'"
            End If
            If chkPER_GRUPO.Checked Then
                If vFlagCadena Then vCadenaFiltradoTipoPersona += " OR "
                vFlagCadena = True
                vCadenaFiltradoTipoPersona += "TPE_GRUPO='SI' "
            End If
            If chkPER_CONTACTO.Checked Then
                If vFlagCadena Then vCadenaFiltradoTipoPersona += " OR "
                vFlagCadena = True
                vCadenaFiltradoTipoPersona += "TPE_CONTACTO='SI' "
            End If
            If chkPER_TRANSPORTISTA.Checked Then
                If vFlagCadena Then vCadenaFiltradoTipoPersona += " OR "
                vFlagCadena = True
                vCadenaFiltradoTipoPersona += "TPE_TRANSPORTISTA='SI' "
            End If
            vCadenaFiltradoTipoPersona += ")"
            If vCadenaFiltradoTipoPersona <> " AND ()" Then EtxtTPE_ID.pOOrm.CadenaFiltrado = vCadenaFiltradoTipoPersona
        End Sub
        Private Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String, ByVal sender As txt, Optional ByVal e As System.Boolean = True)
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

        Private Sub ValidarDatos(ByRef otxt As txt, ByRef texto As TextBox)
            With otxt
                If .pTexto1 <> .pTexto2 Then
                    .pTexto2 = texto.Text
                    If .pBusqueda Then
                        MetodoBusquedaDato(texto.Text, True, otxt)
                    End If
                End If
                If .pSoloNumeros Then
                    If texto.Text = "" Then texto.Text = "0"
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
#End Region

#Region "Secundaria 2"
        Private Sub LimpiarDatos()
            InicializarValores(txtPER_ID, ErrorProvider1)
            InicializarValores(txtPER_DESCRIPCION, ErrorProvider1)

            InicializarValores(chkPER_CLIENTE, ErrorProvider1)
            InicializarValores(chkPER_PROVEEDOR, ErrorProvider1)
            InicializarValores(chkPER_TRABAJADOR, ErrorProvider1)
            InicializarValores(chkPER_BANCO, ErrorProvider1)
            InicializarValores(chkPER_GRUPO, ErrorProvider1)
            InicializarValores(chkPER_CONTACTO, ErrorProvider1)
            InicializarValores(chkPER_TRANSPORTISTA, ErrorProvider1)

            InicializarValores(txtTPE_ID, ErrorProvider1)
            InicializarValores(txtTPE_DESCRIPCION, ErrorProvider1)

            InicializarValores(chkTPE_CLIENTE, ErrorProvider1)
            InicializarValores(chkTPE_PROVEEDOR, ErrorProvider1)
            InicializarValores(chkTPE_TRABAJADOR, ErrorProvider1)
            InicializarValores(chkTPE_BANCO, ErrorProvider1)
            InicializarValores(chkTPE_GRUPO, ErrorProvider1)
            InicializarValores(chkTPE_CONTACTO, ErrorProvider1)
            InicializarValores(chkTPE_TRANSPORTISTA, ErrorProvider1)

            InicializarValores(chkRTP_ESTADO, ErrorProvider1, False, False, EchkRTP_ESTADO.pValorDefault)
        End Sub

        Private Sub HabilitarNuevo()
            txtPER_ID.Enabled = True
            txtTPE_ID.Enabled = True
        End Sub

        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkPER_CLIENTE)
            ColocarValoresDefault(chkPER_PROVEEDOR)
            ColocarValoresDefault(chkPER_TRANSPORTISTA)
            ColocarValoresDefault(chkPER_TRABAJADOR)
            ColocarValoresDefault(chkPER_BANCO)
            ColocarValoresDefault(chkPER_GRUPO)
            ColocarValoresDefault(chkPER_CONTACTO)

            ColocarValoresDefault(chkTPE_CLIENTE)
            ColocarValoresDefault(chkTPE_PROVEEDOR)
            ColocarValoresDefault(chkTPE_TRANSPORTISTA)
            ColocarValoresDefault(chkTPE_TRABAJADOR)
            ColocarValoresDefault(chkTPE_BANCO)
            ColocarValoresDefault(chkTPE_GRUPO)
            ColocarValoresDefault(chkTPE_CONTACTO)

            ColocarValoresDefault(chkRTP_ESTADO)
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

                Case "chkTPE_CLIENTE"
                    vObjetoChk.pValorDefault = EchkTPE_CLIENTE.pValorDefault
                Case "chkTPE_PROVEEDOR"
                    vObjetoChk.pValorDefault = EchkTPE_PROVEEDOR.pValorDefault
                Case "chkTPE_TRANSPORTISTA"
                    vObjetoChk.pValorDefault = EchkTPE_TRANSPORTISTA.pValorDefault
                Case "chkTPE_TRABAJADOR"
                    vObjetoChk.pValorDefault = EchkTPE_TRABAJADOR.pValorDefault
                Case "chkTPE_BANCO"
                    vObjetoChk.pValorDefault = EchkTPE_BANCO.pValorDefault
                Case "chkTPE_GRUPO"
                    vObjetoChk.pValorDefault = EchkTPE_GRUPO.pValorDefault
                Case "chkTPE_CONTACTO"
                    vObjetoChk.pValorDefault = EchkTPE_CONTACTO.pValorDefault

                Case "chkRTP_ESTADO"
                    vObjetoChk.pValorDefault = EchkRTP_ESTADO.pValorDefault
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
            'ProcesoCrearCodigoId("CrearCodigoSimple", txtPER_ID)
        End Sub

        Private Sub HabilitarEscrituraNuevo()
            txtPER_ID.ReadOnly = False
            txtTPE_ID.ReadOnly = False
        End Sub

        Private Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "CancelarEdicion"
                    CodigoId = CodigoId & vCodigoTPE_ID
                Case "PrepararEliminar"
                    Simple.Vista = "RegistroAnterior"
                    Simple.PER_ID = CodigoId
                    Simple.TPE_ID = vCodigoTPE_ID
                Case "Load"
                    Simple.Vista = "PrimerRegistro"
                    Simple.PER_ID = txtPER_ID.Text.Trim
                    Simple.TPE_ID = txtTPE_ID.Text.Trim
                Case "NavegarFormulario"
                    Simple.PER_ID = txtPER_ID.Text.Trim
                    Simple.TPE_ID = txtTPE_ID.Text.Trim
                Case "EliminarRegistro"
                    Simple.PER_ID = txtPER_ID.Text.Trim
                    Simple.TPE_ID = txtTPE_ID.Text.Trim
                    CodigoId = txtPER_ID.Text.Trim
                    vCodigoTPE_ID = txtTPE_ID.Text.Trim
                Case "InicializarDatos"
                    Simple.PER_ID = txtPER_ID.Text.Trim
                    Simple.TPE_ID = txtTPE_ID.Text.Trim
                    CodigoId = txtPER_ID.Text.Trim
                    vCodigoTPE_ID = txtTPE_ID.Text.Trim
            End Select
        End Sub

        Private Function Ingresar() As Boolean
            Ingresar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                If (InsertarDatos()) Then
                    Ingresar = True
                    MsgBox("Registro ingresado", MsgBoxStyle.Information, Me.Text)
                Else
                    MsgBox("No se pudo ingresar verifique sus datos" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
                End If
            End If
            'Simple = Nothing
            'Simple = New Ladisac.BE.RolPersonaTipoPersona
            Return Ingresar
        End Function
        Private Sub DatosCabecera()
            Simple.PER_ID = Strings.Trim(txtPER_ID.Text)
            Simple.TPE_ID = Strings.Trim(txtTPE_ID.Text)

            Simple.USU_ID = SessionService.UserId
            Simple.RTP_FEC_GRAB = Now
            Simple.RTP_ESTADO = DevolverTiposCampos(chkRTP_ESTADO)
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

                Case "chkTPE_CLIENTE"
                    Simple.CampoId = EchkTPE_CLIENTE.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkTPE_PROVEEDOR"
                    Simple.CampoId = EchkTPE_PROVEEDOR.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkTPE_TRANSPORTISTA"
                    Simple.CampoId = EchkTPE_TRANSPORTISTA.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkTPE_TRABAJADOR"
                    Simple.CampoId = EchkTPE_TRABAJADOR.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkTPE_BANCO"
                    Simple.CampoId = EchkTPE_BANCO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkTPE_GRUPO"
                    Simple.CampoId = EchkTPE_GRUPO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkTPE_CONTACTO"
                    Simple.CampoId = EchkTPE_CONTACTO.pNombreCampo
                    Simple.Dato = oObjeto.Text

                Case "chkRTP_ESTADO"
                    Simple.CampoId = EchkRTP_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Simple.DevolverTiposCampos()
        End Function

        Private Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Simple.ColocarErrores(txtPER_ID, Simple.VerificarDatos("PER_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtTPE_ID, Simple.VerificarDatos("TPE_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(lblTitle, Simple.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(btnImagen, Simple.VerificarDatos("RTP_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkRTP_ESTADO, Simple.VerificarDatos("RTP_ESTADO"), ErrorProvider1)
            End Select
            Return vrO
        End Function
        Private Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            'Simple.MarkAsAdded()
            'vRespuestaLocal = Me.IBCRolPersonaTipoPersona.MantenimientoRolPersonaTipoPersona(Simple)
            vRespuestaLocal = Me.IBCRolPersonaTipoPersona.spInsertarRegistro(Simple.PER_ID, Simple.TPE_ID, Simple.USU_ID, Simple.RTP_FEC_GRAB, Simple.RTP_ESTADO)
            InsertarDatos = (vRespuestaLocal > 0)
        End Function
        Private Function Modificar() As Boolean
            Modificar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                If (ActualizarDatos()) Then
                    Modificar = True
                    MsgBox("Registro modificado", MsgBoxStyle.Information, Me.Text)
                Else
                    MsgBox("No se pudo modificar verifique sus datos :" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
                End If
            End If
            'Simple = Nothing
            'Simple = New Ladisac.BE.RolPersonaTipoPersona
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean
            'Simple.MarkAsModified()
            'ActualizarDatos = (Me.IBCRolPersonaTipoPersona.MantenimientoRolPersonaTipoPersona(Simple) > 0)
            ActualizarDatos = Me.IBCRolPersonaTipoPersona.spActualizarRegistro(Simple.PER_ID, Simple.TPE_ID, Simple.USU_ID, Simple.RTP_FEC_GRAB, Simple.RTP_ESTADO)
        End Function

        Private Function EliminarRegistro() As Boolean
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            'Simple.MarkAsDeleted()
            'If (Me.IBCRolPersonaTipoPersona.MantenimientoRolPersonaTipoPersona(Simple) > 0) Then
            If (Me.IBCRolPersonaTipoPersona.spEliminarRegistro(Simple.PER_ID, Simple.TPE_ID) > 0) Then
                EliminarRegistro = True
                MsgBox("Registro eliminado", MsgBoxStyle.Information, Me.Text)
            Else
                EliminarRegistro = False
                MsgBox("No se pudo eliminar verifique sus datos" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
            End If
            'Simple = Nothing
            'Simple = New Ladisac.BE.RolPersonaTipoPersona
            Return EliminarRegistro
        End Function

        Private Sub NavegarGrid(ByVal Metodo As String)
            cMisProcedimientos.PosicionGrid(Metodo, ActiveControl, Me.Text)
        End Sub

        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTPE_ID" Then EtxtTPE_ID.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtTPE_ID" Then EtxtTPE_ID.pTexto2 = Me.ActiveControl.Text
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
                LongitudId = 3
                CaracterId = "0"
                ConfigurarCheck()
                ConfigurarComboBox()
                ConfigurarText()
                AdicionarElementoCombosEdicion()
                ComportamientoFormulario()

                If Comportamiento = -1 Then BusquedaDatos("Load")

                FormatearCampos(txtPER_ID, "PER_ID", EtxtPER_ID)
                FormatearCampos(txtPER_DESCRIPCION, "PER_DESCRIPCION", EtxtPER_DESCRIPCION, False)
                FormatearCampos(txtTPE_ID, "TPE_ID", EtxtTPE_ID)
                FormatearCampos(txtTPE_DESCRIPCION, "TPE_DESCRIPCION", EtxtTPE_DESCRIPCION, False)

                If pComportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load")
            End Try
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


            EchkTPE_CLIENTE = EchkTemporal
            EchkTPE_CLIENTE.pNombreCampo = "TPE_CLIENTE"
            ConfigurarCheck_Refrescar(EchkTPE_CLIENTE)

            EchkTPE_PROVEEDOR = EchkTemporal
            EchkTPE_PROVEEDOR.pNombreCampo = "TPE_PROVEEDOR"
            ConfigurarCheck_Refrescar(EchkTPE_PROVEEDOR)

            EchkTPE_TRANSPORTISTA = EchkTemporal
            EchkTPE_TRANSPORTISTA.pNombreCampo = "TPE_TRANSPORTISTA"
            ConfigurarCheck_Refrescar(EchkTPE_TRANSPORTISTA)

            EchkTPE_TRABAJADOR = EchkTemporal
            EchkTPE_TRABAJADOR.pNombreCampo = "TPE_TRABAJADOR"
            ConfigurarCheck_Refrescar(EchkTPE_TRABAJADOR)

            EchkTPE_BANCO = EchkTemporal
            EchkTPE_BANCO.pNombreCampo = "TPE_BANCO"
            ConfigurarCheck_Refrescar(EchkTPE_BANCO)

            EchkTPE_GRUPO = EchkTemporal
            EchkTPE_GRUPO.pNombreCampo = "TPE_GRUPO"
            ConfigurarCheck_Refrescar(EchkTPE_GRUPO)

            EchkTPE_CONTACTO = EchkTemporal
            EchkTPE_CONTACTO.pNombreCampo = "TPE_CONTACTO"
            ConfigurarCheck_Refrescar(EchkTPE_CONTACTO)


            EchkRTP_ESTADO = EchkTemporal
            EchkRTP_ESTADO.pNombreCampo = "RTP_ESTADO"
            EchkRTP_ESTADO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkRTP_ESTADO)
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


                Case "TPE_CLIENTE"
                    With chkTPE_CLIENTE
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "TPE_PROVEEDOR"
                    With chkTPE_PROVEEDOR
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "TPE_TRANSPORTISTA"
                    With chkTPE_TRANSPORTISTA
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "TPE_TRABAJADOR"
                    With chkTPE_TRABAJADOR
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "TPE_BANCO"
                    With chkTPE_BANCO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "TPE_GRUPO"
                    With chkTPE_GRUPO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "TPE_CONTACTO"
                    With chkTPE_CONTACTO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With


                Case "RTP_ESTADO"
                    With chkRTP_ESTADO
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

            InicializarTexto(EchkTPE_CLIENTE)
            InicializarTexto(EchkTPE_PROVEEDOR)
            InicializarTexto(EchkTPE_TRANSPORTISTA)
            InicializarTexto(EchkTPE_TRABAJADOR)
            InicializarTexto(EchkTPE_BANCO)
            InicializarTexto(EchkTPE_GRUPO)
            InicializarTexto(EchkTPE_CONTACTO)

            InicializarTexto(EchkRTP_ESTADO)
        End Sub
        Private Sub ConfigurarComboBox()
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

            EtxtPER_DESCRIPCION = EtxtTemporal
            EtxtTPE_DESCRIPCION = EtxtTemporal

            EtxtTemporal.pBusqueda = True
            EtxtTemporal.pFormularioConsulta = True

            EtxtPER_ID = EtxtTemporal
            EtxtTPE_ID = EtxtTemporal

            EtxtPER_ID.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID.pComportamiento = 1

            EtxtTPE_ID.pOOrm = New Ladisac.BE.TipoPersonas
            EtxtTPE_ID.pComportamiento = 2
        End Sub
        Private Sub AdicionarElementoCombosEdicion()
        End Sub
        Private Sub BuscarFormatos(ByRef vObjeto As cbo, _
                                   ByVal oSimple As Object, _
                                   ByRef oComboBox As ComboBox, _
                                   ByVal vOrdenBusqueda As Int16)
            oSimple.CampoId = vObjeto.pNombreCampo
            cMisProcedimientos.AdicionarElementoCombosEdicion(oComboBox, oSimple.BuscarFormatos(), vOrdenBusqueda)
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

        Private Sub NavegarFormulario(ByVal Metodo As String)
            Try
                If pnCuerpo.Enabled = True Then If RevisarDatos(False) Then Return
                Dim vCodigoId As String
                Dim resp As String = ""
                OrmBusquedaDatos("NavegarFormulario")
                Select Case Metodo
                    Case "PrimerRegistro"
                        resp = Me.IBCBusqueda.PrimerRegistroCompuesto(Simple.CampoPrincipal, _
                                                                      Simple.CampoPrincipalSecundario, _
                                                                      Simple.cTabla.NombreLargo)
                    Case "RegistroAnterior"
                        Simple.CampoPrincipalValor = CodigoId
                        Simple.CampoPrincipalSecundarioValor = vCodigoTPE_ID
                        resp = Me.IBCBusqueda.RegistroAnteriorCompuesto(Simple.CampoPrincipal, _
                                                                        Simple.CampoPrincipalValor, _
                                                                        Simple.CampoPrincipalSecundario, _
                                                                        Simple.CampoPrincipalSecundarioValor, _
                                                                        Simple.cTabla.NombreLargo)
                    Case "RegistroSiguiente"
                        Simple.CampoPrincipalValor = CodigoId
                        Simple.CampoPrincipalSecundarioValor = vCodigoTPE_ID
                        resp = Me.IBCBusqueda.RegistroSiguienteCompuesto(Simple.CampoPrincipal, _
                                                                        Simple.CampoPrincipalValor, _
                                                                        Simple.CampoPrincipalSecundario, _
                                                                        Simple.CampoPrincipalSecundarioValor, _
                                                                        Simple.cTabla.NombreLargo)
                    Case "UltimoRegistro"
                        resp = Me.IBCBusqueda.UltimoRegistroCompuesto(Simple.CampoPrincipal, _
                                                                      Simple.CampoPrincipalSecundario, _
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
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                If vBusquedaDirecta Then
                    frm.TipoEdicion = 2
                    If pComportamiento = -1 Then
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = vDatoBusqueda
                    End If
                    frm.DatoBusqueda = vDatoBusqueda
                Else
                    frm.TipoEdicion = 1
                    frm.DatoBusqueda = ""
                End If
                frm.oOrm = vtxt.pOOrm
                frm.Comportamiento = vtxt.pComportamiento
                frm.NombreFormulario = Me
                frm.OrdenBusqueda = vtxt.pOrdenBusqueda
                frm.ShowDialog()
                frm.Dispose()
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - MetodoBusquedaDato")
            End Try
        End Sub
#End Region

        Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles chkRTP_ESTADO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkRTP_ESTADO"
                    If EchkRTP_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkRTP_ESTADO)
                    End If
            End Select
        End Sub
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtPER_ID.KeyDown, txtTPE_ID.KeyDown

            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtPER_ID"
                            TeclaF1(EtxtPER_ID, txtPER_ID)
                        Case "txtTPE_ID"
                            TeclaF1(EtxtTPE_ID, txtTPE_ID)
                    End Select
            End Select
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

    End Class
End Namespace