Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Tesoreria.Views
    Public Class frmCajaCtaCte
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

        Protected Shared vrO As Boolean = True
        Protected Shared vrM As Boolean = True
        Private pLongitudId As Integer = 0
        Private pCaracterId As String = Nothing

        Private pCodigoId As String = "" ' 

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
        Public Property IBCCajaCtaCte As Ladisac.BL.IBCCajaCtaCte

        Private EchkCCC_ESTADO As New chk
        Private EchkPER_ESTADO_BAN As New chk
        Private EchkPER_ESTADO_CAJ As New chk
        Private EchkPVE_ESTADO As New chk
        Private EchkMON_ESTADO As New chk
        Private EchkCUC_ESTADO As New chk

        Private EtxtCCC_ID As New txt
        Private EtxtPER_ID_BAN As New txt
        Private EtxtPER_ID_CAJ As New txt
        Private EtxtPVE_ID As New txt
        Private EtxtMON_ID As New txt
        Private EtxtCUC_ID As New txt

        Private EcboCCC_TIPO As New cbo

        Private Simple As New Ladisac.BE.CajaCtaCte
        Private ErrorData As New Ladisac.BE.CajaCtaCte.ErrorData

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

        Protected Structure chk
            Public Property pFormatearTexto As Boolean
            Public Property pNombreCampo As String
            Public Property vEstado0 As String
            Public Property vEstado1 As String
            Public Property vEstadoX As String
            Public Property pSimple As Object
            Public Property pValorDefault As System.Windows.Forms.CheckState
        End Structure
        Protected Structure txt
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
        Protected Structure cbo
            Public Property pNombreCampo As String
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
                'MsgBox("No esta disponible el desplazamiento" & Chr(13) & Chr(13) & "Ubiquese en un registro", MsgBoxStyle.Information, Me.Text)
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
                    If lblTitle.Visible Then tsBarra.Dock = System.Windows.Forms.DockStyle.None
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



        Private Sub ProcesoCrearCodigoId(ByVal vVista As String, _
                                                     ByRef oTexto As TextBox, _
                                                     ByVal oSimple As Object)
            Select Case vVista
                Case "CrearCodigoSimple"
                    Dim resp = Me.IBCBusqueda.CrearCodigoSimple(oSimple.CampoPrincipal, _
                                                                oSimple.cTabla.NombreLargo)
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



        Private Function DevolverTiposCampos(ByVal oNombreCampo As String, ByVal oTexto As String, ByVal oOrm As Object) As String
            oOrm.CampoId = oNombreCampo
            oOrm.Dato = oTexto
            DevolverTiposCampos = oOrm.DevolverTiposCampos()
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
        Private Sub ComportamientoFormulario()
            If pComportamiento <> -1 Then
                NombresFormulariosControles()
            End If
            pLoaded = False
        End Sub
        Private Sub NombresFormulariosControles()
        End Sub
        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
        End Sub
        Private Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String, ByVal vArrayDatosComboBox As Object, ByVal vElementos As Int16)
            For Fila = 0 To vElementos
                If vArrayDatosComboBox(Fila).NombreCampo.ToString = NombreCampo Then
                    If vArrayDatosComboBox(Fila).Tipo.ToString = "char" Or _
                        vArrayDatosComboBox(Fila).Tipo.ToString = "varchar" Then
                        If oObjeto.GetType.BaseType() = GetType(Windows.Forms.TextBox) Then
                            oObjeto.SoloNumerosDecimales = False
                            oObjeto.SoloNumeros = False
                            oObjeto.MinusculaMayuscula = True
                        End If
                        oObjeto.MaxLength = vArrayDatosComboBox(Fila).Longitud
                        oObjeto.Width = vArrayDatosComboBox(Fila).Ancho
                    End If
                    If vArrayDatosComboBox(Fila).Tipo.ToString = "int" Then
                        If oObjeto.GetType.BaseType() = GetType(Windows.Forms.TextBox) Then
                            oObjeto.SoloNumerosDecimales = False
                            oObjeto.SoloNumeros = True
                            oObjeto.MinusculaMayuscula = False
                        End If
                        oObjeto.MaxLength = vArrayDatosComboBox(Fila).Longitud
                        oObjeto.Width = vArrayDatosComboBox(Fila).Ancho
                    End If
                    If vArrayDatosComboBox(Fila).Tipo.ToString = "numeric" Then
                        If oObjeto.GetType.BaseType() = GetType(Windows.Forms.TextBox) Then
                            oObjeto.SoloNumerosDecimales = True
                            oObjeto.SoloNumeros = False
                            oObjeto.MinusculaMayuscula = False
                            oObjeto.ParteEntera = vArrayDatosComboBox(Fila).ParteEntera
                            oObjeto.ParteDecimal = vArrayDatosComboBox(Fila).ParteDecimal
                        End If
                        oObjeto.MaxLength = vArrayDatosComboBox(Fila).Longitud
                        oObjeto.Width = vArrayDatosComboBox(Fila).Ancho
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
                If Trim(.pTexto1) <> Trim(.pTexto2) Then
                    .pTexto2 = texto.Text
                    If .pBusqueda Then
                        otxt.pOOrm.CadenaFiltrado = otxt.pCadenaFiltrado
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
            txtCCC_ID.Text = ""
            ErrorProvider1.SetError(txtCCC_ID, Nothing)

            chkCCC_ESTADO.Checked = Nothing
            chkCCC_ESTADO.CheckState = EchkCCC_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkCCC_ESTADO, Nothing)

            txtPER_ID_BAN.Text = ""
            ErrorProvider1.SetError(txtPER_ID_BAN, Nothing)

            txtPER_DESCRIPCION_BAN.Text = ""
            ErrorProvider1.SetError(txtPER_DESCRIPCION_BAN, Nothing)

            chkPER_ESTADO_BAN.Checked = Nothing
            chkPER_ESTADO_BAN.CheckState = EchkPER_ESTADO_BAN.pValorDefault
            ErrorProvider1.SetError(chkPER_ESTADO_BAN, Nothing)

            txtCCC_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtCCC_DESCRIPCION, Nothing)

            txtCCC_CUENTA_BANCARIA.Text = ""
            ErrorProvider1.SetError(txtCCC_CUENTA_BANCARIA, Nothing)

            txtPER_ID_CAJ.Text = ""
            ErrorProvider1.SetError(txtPER_ID_CAJ, Nothing)

            txtPER_DESCRIPCION_CAJ.Text = ""
            ErrorProvider1.SetError(txtPER_DESCRIPCION_CAJ, Nothing)

            chkPER_ESTADO_CAJ.Checked = Nothing
            chkPER_ESTADO_CAJ.CheckState = EchkPER_ESTADO_CAJ.pValorDefault
            ErrorProvider1.SetError(chkPER_ESTADO_CAJ, Nothing)

            txtPVE_ID.Text = ""
            ErrorProvider1.SetError(txtPVE_ID, Nothing)

            txtPVE_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtPVE_DESCRIPCION, Nothing)

            chkPVE_ESTADO.Checked = Nothing
            chkPVE_ESTADO.CheckState = EchkPVE_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkPER_ESTADO_CAJ, Nothing)

            txtCCC_MONTO_SAL_INI.Text = "0.00"
            ErrorProvider1.SetError(txtCCC_MONTO_SAL_INI, Nothing)

            txtMON_ID.Text = ""
            ErrorProvider1.SetError(txtMON_ID, Nothing)

            txtMON_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtMON_DESCRIPCION, Nothing)

            chkMON_ESTADO.Checked = Nothing
            chkMON_ESTADO.CheckState = EchkMON_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkMON_ESTADO, Nothing)

            txtCUC_ID.Text = ""
            ErrorProvider1.SetError(txtCUC_ID, Nothing)

            txtCUC_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtCUC_DESCRIPCION, Nothing)

            chkCUC_ESTADO.Checked = Nothing
            chkCUC_ESTADO.CheckState = EchkCUC_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkCUC_ESTADO, Nothing)
        End Sub

        Private Sub HabilitarNuevo()
            txtCCC_ID.Enabled = True
        End Sub

        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkCCC_ESTADO)
            ColocarValoresDefault(chkPER_ESTADO_BAN)
            ColocarValoresDefault(chkPER_ESTADO_CAJ)
            ColocarValoresDefault(chkPVE_ESTADO)
            ColocarValoresDefault(chkMON_ESTADO)
            ColocarValoresDefault(chkCUC_ESTADO)
        End Sub
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkCCC_ESTADO"
                    vObjetoChk.pValorDefault = EchkCCC_ESTADO.pValorDefault
                Case "chkPER_ESTADO_BAN"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO_BAN.pValorDefault
                Case "chkPER_ESTADO_CAJ"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO_CAJ.pValorDefault
                Case "chkPVE_ESTADO"
                    vObjetoChk.pValorDefault = EchkPVE_ESTADO.pValorDefault
                Case "chkMON_ESTADO"
                    vObjetoChk.pValorDefault = EchkMON_ESTADO.pValorDefault
                Case "chkCUC_ESTADO"
                    vObjetoChk.pValorDefault = EchkCUC_ESTADO.pValorDefault
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
            ProcesoCrearCodigoId("CrearCodigoSimple", txtCCC_ID, Simple)
        End Sub

        Private Sub HabilitarEscrituraNuevo()
            txtCCC_ID.ReadOnly = False
        End Sub

        Private Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "CancelarEdicion"
                    CodigoId = CodigoId
                Case "PrepararEliminar"
                    Simple.Vista = "RegistroAnterior"
                    Simple.CCC_ID = CodigoId
                Case "Load"
                    Simple.Vista = "PrimerRegistro"
                    Simple.CCC_ID = CodigoId
                Case "NavegarFormulario"
                    Simple.CCC_ID = CodigoId
                Case "EliminarRegistro"
                    Simple.CCC_ID = txtCCC_ID.Text.Trim
                    CodigoId = txtCCC_ID.Text.Trim
                Case "InicializarDatos"
                    Simple.CCC_ID = txtCCC_ID.Text.Trim
                    CodigoId = txtCCC_ID.Text.Trim
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
            Simple = Nothing
            Simple = New Ladisac.BE.CajaCtaCte
            Return Ingresar
        End Function
        Private Sub DatosCabecera()
            Simple.CCC_ID = Strings.Trim(txtCCC_ID.Text)
            Simple.CCC_TIPO = DevolverTiposCampos("CCC_TIPO", cboCCC_TIPO.Text, Simple)

            If Len(Strings.Trim(txtPER_ID_BAN.Text)) = 0 Then
                Simple.PER_ID_BAN = Nothing
            Else
                Simple.PER_ID_BAN = Strings.Trim(txtPER_ID_BAN.Text)
            End If

            Simple.CCC_DESCRIPCION = Strings.Trim(txtCCC_DESCRIPCION.Text)
            Simple.CCC_CUENTA_BANCARIA = Strings.Trim(txtCCC_CUENTA_BANCARIA.Text)

            If Len(Strings.Trim(txtPER_ID_CAJ.Text)) = 0 Then
                Simple.PER_ID_CAJ = Nothing
            Else
                Simple.PER_ID_CAJ = Strings.Trim(txtPER_ID_CAJ.Text)
            End If

            If Len(Strings.Trim(txtPVE_ID.Text)) = 0 Then
                Simple.PVE_ID = Nothing
            Else
                Simple.PVE_ID = Strings.Trim(txtPVE_ID.Text)
            End If

            Simple.CCC_FECHA_SAL_INI = dtpCCC_FECHA_SAL_INI.Value
            If IsNumeric(txtCCC_MONTO_SAL_INI.Text) Then
                Simple.CCC_MONTO_SAL_INI = CDbl(txtCCC_MONTO_SAL_INI.Text.Trim)
            Else
                txtCCC_MONTO_SAL_INI.Text = "0.00"
                Simple.CCC_MONTO_SAL_INI = CDbl(txtCCC_MONTO_SAL_INI.Text.Trim)
            End If

            Simple.MON_ID = Strings.Trim(txtMON_ID.Text)


            If Len(Strings.Trim(txtCUC_ID.Text)) = 0 Then
                Simple.CUC_ID = Nothing
            Else
                Simple.CUC_ID = Strings.Trim(txtCUC_ID.Text)
            End If

            Simple.USU_ID = SessionService.UserId
            Simple.CCC_FEC_GRAB = Now
            Simple.CCC_ESTADO = DevolverTiposCampos(chkCCC_ESTADO)
        End Sub
        Protected Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkCCC_ESTADO"
                    Simple.CampoId = EchkCCC_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_ESTADO_BAN"
                    Simple.CampoId = EchkPER_ESTADO_BAN.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPER_ESTADO_CAJ"
                    Simple.CampoId = EchkPER_ESTADO_CAJ.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkPVE_ESTADO"
                    Simple.CampoId = EchkPVE_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkMON_ESTADO"
                    Simple.CampoId = EchkMON_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkCUC_ESTADO"
                    Simple.CampoId = EchkCUC_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Simple.DevolverTiposCampos()
        End Function

        Protected Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Simple.ColocarErrores(txtCCC_ID, Simple.VerificarDatos("CCC_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(cboCCC_TIPO, Simple.VerificarDatos("CCC_TIPO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_ID_BAN, Simple.VerificarDatos("PER_ID_BAN"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtCCC_DESCRIPCION, Simple.VerificarDatos("CCC_DESCRIPCION"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtCCC_CUENTA_BANCARIA, Simple.VerificarDatos("CCC_CUENTA_BANCARIA"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_ID_CAJ, Simple.VerificarDatos("PER_ID_CAJ"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPVE_ID, Simple.VerificarDatos("PVE_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(dtpCCC_FECHA_SAL_INI, Simple.VerificarDatos("CCC_FECHA_SAL_INI"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtCCC_MONTO_SAL_INI, Simple.VerificarDatos("CCC_MONTO_SAL_INI"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtMON_ID, Simple.VerificarDatos("MON_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(lblTitle, Simple.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(lblTitle, Simple.VerificarDatos("CCC_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkCCC_ESTADO, Simple.VerificarDatos("CCC_ESTADO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtCUC_ID, Simple.VerificarDatos("CUC_ID"), ErrorProvider1)
            End Select
            Return vrO
        End Function
        Protected Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            Simple.MarkAsAdded()
            vRespuestaLocal = Me.IBCCajaCtaCte.MantenimientoCajaCtaCte(Simple)
            InsertarDatos = (vRespuestaLocal > 0)
        End Function
        Protected Function Modificar() As Boolean
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
            Simple = Nothing
            Simple = New Ladisac.BE.CajaCtaCte
            Return Modificar
        End Function
        Protected Function ActualizarDatos() As Boolean
            Simple.MarkAsModified()
            ActualizarDatos = (Me.IBCCajaCtaCte.MantenimientoCajaCtaCte(Simple) > 0)
        End Function

        Protected Function EliminarRegistro() As Boolean
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            Simple.MarkAsDeleted()
            If (Me.IBCCajaCtaCte.MantenimientoCajaCtaCte(Simple) > 0) Then
                EliminarRegistro = True
                MsgBox("Registro eliminado", MsgBoxStyle.Information, Me.Text)
            Else
                EliminarRegistro = False
                MsgBox("No se pudo eliminar verifique sus datos" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
            End If
            Simple = Nothing
            Simple = New Ladisac.BE.CajaCtaCte
            Return EliminarRegistro
        End Function

        Protected Sub NavegarGrid(ByVal Metodo As String)
            cMisProcedimientos.PosicionGrid(Metodo, ActiveControl, Me.Text)
        End Sub

        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtCCC_ID" Then EtxtCCC_ID.pTexto2 = txtCCC_ID.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_BAN" Then EtxtPER_ID_BAN.pTexto2 = txtPER_ID_BAN.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CAJ" Then EtxtPER_ID_CAJ.pTexto2 = txtPER_ID_CAJ.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = txtPVE_ID.Text
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = txtMON_ID.Text
                If Me.ActiveControl.Name.ToString = "txtCUC_ID" Then EtxtCUC_ID.pTexto2 = txtCUC_ID.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtCCC_ID" Then EtxtCCC_ID.pTexto2 = txtCCC_ID.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_BAN" Then EtxtPER_ID_BAN.pTexto2 = txtPER_ID_BAN.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CAJ" Then EtxtPER_ID_CAJ.pTexto2 = txtPER_ID_CAJ.Text
                If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = txtPVE_ID.Text
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = txtMON_ID.Text
                If Me.ActiveControl.Name.ToString = "txtCUC_ID" Then EtxtCUC_ID.pTexto2 = txtCUC_ID.Text
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
                ConfigurarText()
                ConfigurarComboBox()
                AdicionarElementoCombosEdicion()
                ComportamientoFormulario()

                If Comportamiento = -1 Then BusquedaDatos("Load")

                FormatearCampos(txtCCC_ID, "CCC_ID")
                FormatearCampos(txtPER_ID_BAN, "PER_ID_BAN")
                FormatearCampos(txtCCC_DESCRIPCION, "CCC_DESCRIPCION")
                FormatearCampos(txtCCC_CUENTA_BANCARIA, "CCC_CUENTA_BANCARIA")
                FormatearCampos(txtPER_ID_CAJ, "PER_ID_CAJ")
                FormatearCampos(txtPVE_ID, "PVE_ID")
                FormatearCampos(txtMON_ID, "MON_ID")
                FormatearCampos(txtCUC_ID, "CUC_ID")

                If Comportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load")
            End Try
        End Sub

        Private Sub ConfigurarCheck()
            EchkCCC_ESTADO.pFormatearTexto = True
            EchkCCC_ESTADO.pNombreCampo = "CCC_ESTADO"
            EchkCCC_ESTADO.pSimple = Simple
            EchkCCC_ESTADO.pValorDefault = CheckState.Checked
            EchkCCC_ESTADO.vEstado0 = ""
            EchkCCC_ESTADO.vEstado1 = ""
            EchkCCC_ESTADO.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkCCC_ESTADO)

            EchkPER_ESTADO_BAN.pFormatearTexto = True
            EchkPER_ESTADO_BAN.pNombreCampo = "PER_ESTADO_BAN"
            EchkPER_ESTADO_BAN.pSimple = Simple
            EchkPER_ESTADO_BAN.pValorDefault = CheckState.Indeterminate
            EchkPER_ESTADO_BAN.vEstado0 = ""
            EchkPER_ESTADO_BAN.vEstado1 = ""
            EchkPER_ESTADO_BAN.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkPER_ESTADO_BAN)

            EchkPER_ESTADO_CAJ.pFormatearTexto = True
            EchkPER_ESTADO_CAJ.pNombreCampo = "PER_ESTADO_CAJ"
            EchkPER_ESTADO_CAJ.pSimple = Simple
            EchkPER_ESTADO_CAJ.pValorDefault = CheckState.Indeterminate
            EchkPER_ESTADO_CAJ.vEstado0 = ""
            EchkPER_ESTADO_CAJ.vEstado1 = ""
            EchkPER_ESTADO_CAJ.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkPER_ESTADO_CAJ)

            EchkPVE_ESTADO.pFormatearTexto = True
            EchkPVE_ESTADO.pNombreCampo = "PVE_ESTADO"
            EchkPVE_ESTADO.pSimple = Simple
            EchkPVE_ESTADO.pValorDefault = CheckState.Indeterminate
            EchkPVE_ESTADO.vEstado0 = ""
            EchkPVE_ESTADO.vEstado1 = ""
            EchkPVE_ESTADO.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkPVE_ESTADO)

            EchkMON_ESTADO.pFormatearTexto = True
            EchkMON_ESTADO.pNombreCampo = "MON_ESTADO"
            EchkMON_ESTADO.pSimple = Simple
            EchkMON_ESTADO.pValorDefault = CheckState.Indeterminate
            EchkMON_ESTADO.vEstado0 = ""
            EchkMON_ESTADO.vEstado1 = ""
            EchkMON_ESTADO.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkMON_ESTADO)

            EchkCUC_ESTADO.pFormatearTexto = True
            EchkCUC_ESTADO.pNombreCampo = "CUC_ESTADO"
            EchkCUC_ESTADO.pSimple = Simple
            EchkCUC_ESTADO.pValorDefault = CheckState.Indeterminate
            EchkCUC_ESTADO.vEstado0 = ""
            EchkCUC_ESTADO.vEstado1 = ""
            EchkCUC_ESTADO.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkCUC_ESTADO)
        End Sub
        Private Sub InicializarTexto(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "CCC_ESTADO"
                    With chkCCC_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_ESTADO_BAN"
                    With chkPER_ESTADO_BAN
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PER_ESTADO_CAJ"
                    With chkPER_ESTADO_CAJ
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PVE_ESTADO"
                    With chkPVE_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "MON_ESTADO"
                    With chkMON_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "CUC_ESTADO"
                    With chkCUC_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTexto(EchkCCC_ESTADO)
            InicializarTexto(EchkPER_ESTADO_BAN)
            InicializarTexto(EchkPER_ESTADO_CAJ)
            InicializarTexto(EchkPVE_ESTADO)
            InicializarTexto(EchkMON_ESTADO)
            InicializarTexto(EchkCUC_ESTADO)
        End Sub
        Private Sub ConfigurarText()
            EtxtCCC_ID.pTexto1 = ""
            EtxtCCC_ID.pTexto2 = ""
            EtxtCCC_ID.pSoloNumerosDecimales = False
            EtxtCCC_ID.pSoloNumeros = False
            EtxtCCC_ID.pParteEntera = 0
            EtxtCCC_ID.pParteDecimal = 0
            EtxtCCC_ID.pMinusculaMayuscula = True
            EtxtCCC_ID.pBusqueda = True
            EtxtCCC_ID.pCadenaFiltrado = ""

            EtxtCCC_ID.pOOrm = Nothing
            EtxtCCC_ID.pFormularioConsulta = False

            EtxtCCC_ID.pComportamiento = 0
            EtxtCCC_ID.pOrdenBusqueda = 0

            ''
            EtxtPER_ID_BAN.pTexto1 = ""
            EtxtPER_ID_BAN.pTexto2 = ""
            EtxtPER_ID_BAN.pSoloNumerosDecimales = False
            EtxtPER_ID_BAN.pSoloNumeros = False
            EtxtPER_ID_BAN.pParteEntera = 0
            EtxtPER_ID_BAN.pParteDecimal = 0
            EtxtPER_ID_BAN.pMinusculaMayuscula = True
            EtxtPER_ID_BAN.pBusqueda = True
            EtxtPER_ID_BAN.pCadenaFiltrado = " AND PER_BANCO='SI'"

            EtxtPER_ID_BAN.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_BAN.pFormularioConsulta = True

            EtxtPER_ID_BAN.pComportamiento = 1
            EtxtPER_ID_BAN.pOrdenBusqueda = 0

            ''
            EtxtPER_ID_CAJ.pTexto1 = ""
            EtxtPER_ID_CAJ.pTexto2 = ""
            EtxtPER_ID_CAJ.pSoloNumerosDecimales = False
            EtxtPER_ID_CAJ.pSoloNumeros = False
            EtxtPER_ID_CAJ.pParteEntera = 0
            EtxtPER_ID_CAJ.pParteDecimal = 0
            EtxtPER_ID_CAJ.pMinusculaMayuscula = True
            EtxtPER_ID_CAJ.pBusqueda = True
            EtxtPER_ID_CAJ.pCadenaFiltrado = "AND PER_TRABAJADOR='SI'"

            EtxtPER_ID_CAJ.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_CAJ.pFormularioConsulta = True

            EtxtPER_ID_CAJ.pComportamiento = 2
            EtxtPER_ID_CAJ.pOrdenBusqueda = 0

            ''
            EtxtPVE_ID.pTexto1 = ""
            EtxtPVE_ID.pTexto2 = ""
            EtxtPVE_ID.pSoloNumerosDecimales = False
            EtxtPVE_ID.pSoloNumeros = False
            EtxtPVE_ID.pParteEntera = 0
            EtxtPVE_ID.pParteDecimal = 0
            EtxtPVE_ID.pMinusculaMayuscula = True
            EtxtPVE_ID.pBusqueda = True
            EtxtPVE_ID.pCadenaFiltrado = ""

            EtxtPVE_ID.pOOrm = New Ladisac.BE.PuntoVenta
            EtxtPVE_ID.pFormularioConsulta = True

            EtxtPVE_ID.pComportamiento = 3
            EtxtPVE_ID.pOrdenBusqueda = 0

            ''
            EtxtMON_ID.pTexto1 = ""
            EtxtMON_ID.pTexto2 = ""
            EtxtMON_ID.pSoloNumerosDecimales = False
            EtxtMON_ID.pSoloNumeros = False
            EtxtMON_ID.pParteEntera = 0
            EtxtMON_ID.pParteDecimal = 0
            EtxtMON_ID.pMinusculaMayuscula = True
            EtxtMON_ID.pBusqueda = True
            EtxtMON_ID.pCadenaFiltrado = ""

            EtxtMON_ID.pOOrm = New Ladisac.BE.Moneda
            EtxtMON_ID.pFormularioConsulta = True

            EtxtMON_ID.pComportamiento = 4
            EtxtMON_ID.pOrdenBusqueda = 0

            ''
            EtxtCUC_ID.pTexto1 = ""
            EtxtCUC_ID.pTexto2 = ""
            EtxtCUC_ID.pSoloNumerosDecimales = False
            EtxtCUC_ID.pSoloNumeros = False
            EtxtCUC_ID.pParteEntera = 0
            EtxtCUC_ID.pParteDecimal = 0
            EtxtCUC_ID.pMinusculaMayuscula = True
            EtxtCUC_ID.pBusqueda = True
            EtxtCUC_ID.pCadenaFiltrado = ""

            EtxtCUC_ID.pOOrm = New Ladisac.BE.CuentasContables
            EtxtCUC_ID.pFormularioConsulta = True

            EtxtCUC_ID.pComportamiento = 5
            EtxtCUC_ID.pOrdenBusqueda = 0

        End Sub
        Private Sub ConfigurarComboBox()
            EcboCCC_TIPO.pNombreCampo = "CCC_TIPO"
            cboCCC_TIPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        End Sub
        Private Sub AdicionarElementoCombosEdicion()
            BuscarFormatos(EcboCCC_TIPO, Simple)
        End Sub
        Private Sub BuscarFormatos(ByRef oObjeto As cbo, ByVal oSimple As Object)
            oSimple.CampoId = oObjeto.pNombreCampo
            Select Case oObjeto.pNombreCampo
                Case "CCC_TIPO"
                    cMisProcedimientos.AdicionarElementoCombosEdicion(cboCCC_TIPO, oSimple.BuscarFormatos(), 0)
            End Select
        End Sub

        Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles chkCCC_ESTADO.CheckedChanged, chkPER_ESTADO_BAN.CheckedChanged, chkPER_ESTADO_CAJ.CheckedChanged, _
                    chkPVE_ESTADO.CheckedChanged, chkMON_ESTADO.CheckedChanged, chkCUC_ESTADO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkCCC_ESTADO"
                    If EchkCCC_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkCCC_ESTADO)
                    End If
                Case "chkPER_ESTADO_BAN"
                    If EchkPER_ESTADO_BAN.pFormatearTexto Then
                        InicializarTexto(EchkPER_ESTADO_BAN)
                    End If
                Case "chkPER_ESTADO_CAJ"
                    If EchkPER_ESTADO_CAJ.pFormatearTexto Then
                        InicializarTexto(EchkPER_ESTADO_CAJ)
                    End If
                Case "chkPVE_ESTADO"
                    If EchkPVE_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkPVE_ESTADO)
                    End If
                Case "chkMON_ESTADO"
                    If EchkMON_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkMON_ESTADO)
                    End If
                Case "chkCUC_ESTADO"
                    If EchkCUC_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkCUC_ESTADO)
                    End If
            End Select
        End Sub

        Private Sub txtCCC_ID_AcceptsTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCCC_ID.AcceptsTabChanged

        End Sub

        Private Sub Txt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtCCC_ID.GotFocus, txtPER_ID_BAN.GotFocus, txtPER_ID_CAJ.GotFocus, _
            txtPVE_ID.GotFocus, txtMON_ID.GotFocus, txtCUC_ID.GotFocus
            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    If Not txtCCC_ID.ReadOnly Then
                        EtxtCCC_ID.pTexto1 = sender.text
                    End If
                Case "txtPER_ID_BAN"
                    If Not txtPER_ID_BAN.ReadOnly Then
                        EtxtPER_ID_BAN.pTexto1 = sender.text
                    End If
                Case "txtPER_ID_CAJ"
                    If Not txtPER_ID_CAJ.ReadOnly Then
                        EtxtPER_ID_CAJ.pTexto1 = sender.text
                    End If
                Case "txtPVE_ID"
                    If Not txtPVE_ID.ReadOnly Then
                        EtxtPVE_ID.pTexto1 = sender.text
                    End If
                Case "txtMON_ID"
                    If Not txtMON_ID.ReadOnly Then
                        EtxtMON_ID.pTexto1 = sender.text
                    End If
                Case "txtCUC_ID"
                    If Not txtCUC_ID.ReadOnly Then
                        EtxtCUC_ID.pTexto1 = sender.text
                    End If
            End Select
        End Sub

        Private Sub Txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtCCC_ID.LostFocus, txtPER_ID_BAN.LostFocus, txtPER_ID_CAJ.LostFocus, _
            txtPVE_ID.LostFocus, txtMON_ID.LostFocus, txtCUC_ID.LostFocus
            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    If Not txtCCC_ID.ReadOnly Then
                        EtxtCCC_ID.pTexto2 = sender.text
                    End If
                Case "txtPER_ID_BAN"
                    Me.Text = EtxtPER_ID_BAN.pTexto1 & " - " & EtxtPER_ID_BAN.pTexto2
                    If Not txtPER_ID_BAN.ReadOnly Then
                        EtxtPER_ID_BAN.pTexto2 = sender.text
                    End If
                Case "txtPER_ID_CAJ"
                    If Not txtPER_ID_CAJ.ReadOnly Then
                        EtxtPER_ID_CAJ.pTexto2 = sender.text
                    End If
                Case "txtPVE_ID"
                    If Not txtPVE_ID.ReadOnly Then
                        EtxtPVE_ID.pTexto2 = sender.text
                    End If
                Case "txtMON_ID"
                    If Not txtMON_ID.ReadOnly Then
                        EtxtMON_ID.pTexto2 = sender.text
                    End If
                Case "txtCUC_ID"
                    If Not txtCUC_ID.ReadOnly Then
                        EtxtCUC_ID.pTexto2 = sender.text
                    End If
            End Select
        End Sub

        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtCCC_ID.Validated, txtPER_ID_BAN.Validated, txtPER_ID_CAJ.Validated, _
            txtPVE_ID.Validated, txtMON_ID.Validated, txtCUC_ID.Validated
            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    ValidarDatos(EtxtCCC_ID, txtCCC_ID)
                Case "txtPER_ID_BAN"
                    ValidarDatos(EtxtPER_ID_BAN, txtPER_ID_BAN)
                Case "txtPER_ID_CAJ"
                    ValidarDatos(EtxtPER_ID_CAJ, txtPER_ID_CAJ)
                Case "txtPVE_ID"
                    ValidarDatos(EtxtPVE_ID, txtPVE_ID)
                Case "txtMON_ID"
                    ValidarDatos(EtxtMON_ID, txtMON_ID)
                Case "txtCUC_ID"
                    ValidarDatos(EtxtCUC_ID, txtCUC_ID)
            End Select
        End Sub

        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles txtCCC_ID.KeyDown, txtPER_ID_BAN.KeyDown, txtPER_ID_CAJ.KeyDown, _
                txtPVE_ID.KeyDown, txtMON_ID.KeyDown, txtCUC_ID.KeyDown
            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If Not txtCCC_ID.ReadOnly Then
                                If EtxtCCC_ID.pBusqueda Then
                                    EtxtCCC_ID.pTexto2 = txtCCC_ID.Text
                                    ValidarDatos(EtxtCCC_ID, txtCCC_ID)
                                    EtxtCCC_ID.pOOrm.CadenaFiltrado = EtxtCCC_ID.pCadenaFiltrado
                                    MetodoBusquedaDato("", False, EtxtCCC_ID)
                                    EtxtCCC_ID.pTexto1 = txtCCC_ID.Text
                                    EtxtCCC_ID.pTexto2 = txtCCC_ID.Text
                                End If
                            End If
                    End Select
                Case "txtPER_ID_BAN"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If Not txtPER_ID_BAN.ReadOnly Then
                                If EtxtPER_ID_BAN.pBusqueda Then
                                    EtxtPER_ID_BAN.pTexto2 = txtPER_ID_BAN.Text
                                    ValidarDatos(EtxtPER_ID_BAN, txtPER_ID_BAN)
                                    EtxtPER_ID_BAN.pOOrm.CadenaFiltrado = EtxtPER_ID_BAN.pCadenaFiltrado
                                    MetodoBusquedaDato("", False, EtxtPER_ID_BAN)
                                    EtxtPER_ID_BAN.pTexto1 = txtPER_ID_BAN.Text
                                    EtxtPER_ID_BAN.pTexto2 = txtPER_ID_BAN.Text
                                End If
                            End If
                    End Select
                Case "txtPER_ID_CAJ"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If Not txtPER_ID_CAJ.ReadOnly Then
                                If EtxtPER_ID_CAJ.pBusqueda Then
                                    EtxtPER_ID_CAJ.pTexto2 = txtPER_ID_CAJ.Text
                                    ValidarDatos(EtxtPER_ID_CAJ, txtPER_ID_CAJ)
                                    EtxtPER_ID_CAJ.pOOrm.CadenaFiltrado = EtxtPER_ID_CAJ.pCadenaFiltrado
                                    MetodoBusquedaDato("", False, EtxtPER_ID_CAJ)
                                    EtxtPER_ID_CAJ.pTexto1 = txtPER_ID_CAJ.Text
                                    EtxtPER_ID_CAJ.pTexto2 = txtPER_ID_CAJ.Text
                                End If
                            End If
                    End Select
                Case "txtPVE_ID"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If Not txtPVE_ID.ReadOnly Then
                                If EtxtPVE_ID.pBusqueda Then
                                    EtxtPVE_ID.pTexto2 = txtPVE_ID.Text
                                    ValidarDatos(EtxtPVE_ID, txtPVE_ID)
                                    EtxtPVE_ID.pOOrm.CadenaFiltrado = EtxtPVE_ID.pCadenaFiltrado
                                    MetodoBusquedaDato("", False, EtxtPVE_ID)
                                    EtxtPVE_ID.pTexto1 = txtPVE_ID.Text
                                    EtxtPVE_ID.pTexto2 = txtPVE_ID.Text
                                End If
                            End If
                    End Select

                Case "txtMON_ID"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If Not txtMON_ID.ReadOnly Then
                                If EtxtMON_ID.pBusqueda Then
                                    EtxtMON_ID.pTexto2 = txtMON_ID.Text
                                    ValidarDatos(EtxtMON_ID, txtMON_ID)
                                    EtxtMON_ID.pOOrm.CadenaFiltrado = EtxtMON_ID.pCadenaFiltrado
                                    MetodoBusquedaDato("", False, EtxtMON_ID)
                                    EtxtMON_ID.pTexto1 = txtMON_ID.Text
                                    EtxtMON_ID.pTexto2 = txtMON_ID.Text
                                End If
                            End If
                    End Select

                Case "txtCUC_ID"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If Not txtCUC_ID.ReadOnly Then
                                If EtxtCUC_ID.pBusqueda Then
                                    EtxtCUC_ID.pTexto2 = txtCUC_ID.Text
                                    ValidarDatos(EtxtCUC_ID, txtCUC_ID)
                                    EtxtCUC_ID.pOOrm.CadenaFiltrado = EtxtCUC_ID.pCadenaFiltrado
                                    MetodoBusquedaDato("", False, EtxtCUC_ID)
                                    EtxtCUC_ID.pTexto1 = txtCUC_ID.Text
                                    EtxtCUC_ID.pTexto2 = txtCUC_ID.Text
                                End If
                            End If
                    End Select

            End Select
        End Sub

        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles txtCCC_ID.KeyPress, txtPER_ID_BAN.KeyPress, txtPER_ID_CAJ.KeyPress, _
                txtPVE_ID.KeyPress, txtMON_ID.KeyPress, txtCUC_ID.KeyPress
            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    If EtxtCCC_ID.pMinusculaMayuscula Then
                        e.KeyChar = UCase(e.KeyChar)
                    End If
                    If EtxtCCC_ID.pSoloNumerosDecimales Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 46 Then
                                If Asc(e.KeyChar) <> 8 Then
                                    e.KeyChar = ""
                                End If
                            Else
                                If EtxtCCC_ID.pParteDecimal = 0 Then
                                    e.KeyChar = ""
                                End If
                            End If
                        End If
                    End If
                    If EtxtCCC_ID.pSoloNumeros Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 8 Then
                                e.KeyChar = ""
                            End If
                        End If
                    End If

                Case "txtPER_ID_BAN"
                    If EtxtPER_ID_BAN.pMinusculaMayuscula Then
                        e.KeyChar = UCase(e.KeyChar)
                    End If
                    If EtxtPER_ID_BAN.pSoloNumerosDecimales Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 46 Then
                                If Asc(e.KeyChar) <> 8 Then
                                    e.KeyChar = ""
                                End If
                            Else
                                If EtxtPER_ID_BAN.pParteDecimal = 0 Then
                                    e.KeyChar = ""
                                End If
                            End If
                        End If
                    End If
                    If EtxtPER_ID_BAN.pSoloNumeros Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 8 Then
                                e.KeyChar = ""
                            End If
                        End If
                    End If

                Case "txtPER_ID_CAJ"
                    If EtxtPER_ID_CAJ.pMinusculaMayuscula Then
                        e.KeyChar = UCase(e.KeyChar)
                    End If
                    If EtxtPER_ID_CAJ.pSoloNumerosDecimales Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 46 Then
                                If Asc(e.KeyChar) <> 8 Then
                                    e.KeyChar = ""
                                End If
                            Else
                                If EtxtPER_ID_CAJ.pParteDecimal = 0 Then
                                    e.KeyChar = ""
                                End If
                            End If
                        End If
                    End If
                    If EtxtPER_ID_CAJ.pSoloNumeros Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 8 Then
                                e.KeyChar = ""
                            End If
                        End If
                    End If

                Case "txtPVE_ID"
                    If EtxtPVE_ID.pMinusculaMayuscula Then
                        e.KeyChar = UCase(e.KeyChar)
                    End If
                    If EtxtPVE_ID.pSoloNumerosDecimales Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 46 Then
                                If Asc(e.KeyChar) <> 8 Then
                                    e.KeyChar = ""
                                End If
                            Else
                                If EtxtPVE_ID.pParteDecimal = 0 Then
                                    e.KeyChar = ""
                                End If
                            End If
                        End If
                    End If
                    If EtxtPVE_ID.pSoloNumeros Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 8 Then
                                e.KeyChar = ""
                            End If
                        End If
                    End If

                Case "txtMON_ID"
                    If EtxtMON_ID.pMinusculaMayuscula Then
                        e.KeyChar = UCase(e.KeyChar)
                    End If
                    If EtxtMON_ID.pSoloNumerosDecimales Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 46 Then
                                If Asc(e.KeyChar) <> 8 Then
                                    e.KeyChar = ""
                                End If
                            Else
                                If EtxtMON_ID.pParteDecimal = 0 Then
                                    e.KeyChar = ""
                                End If
                            End If
                        End If
                    End If
                    If EtxtMON_ID.pSoloNumeros Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 8 Then
                                e.KeyChar = ""
                            End If
                        End If
                    End If

                Case "txtCUC_ID"
                    If EtxtCUC_ID.pMinusculaMayuscula Then
                        e.KeyChar = UCase(e.KeyChar)
                    End If
                    If EtxtCUC_ID.pSoloNumerosDecimales Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 46 Then
                                If Asc(e.KeyChar) <> 8 Then
                                    e.KeyChar = ""
                                End If
                            Else
                                If EtxtCUC_ID.pParteDecimal = 0 Then
                                    e.KeyChar = ""
                                End If
                            End If
                        End If
                    End If
                    If EtxtCUC_ID.pSoloNumeros Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 8 Then
                                e.KeyChar = ""
                            End If
                        End If
                    End If

            End Select
        End Sub

        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtCCC_ID.DoubleClick, txtPER_ID_BAN.DoubleClick, txtPER_ID_CAJ.DoubleClick, _
                txtPVE_ID.DoubleClick, txtMON_ID.DoubleClick, txtCUC_ID.DoubleClick
            Select Case sender.name.ToString
                Case "txtCCC_ID"
                    If Not txtCCC_ID.ReadOnly Then
                        EtxtCCC_ID.pTexto2 = txtCCC_ID.Text
                        ValidarDatos(EtxtCCC_ID, txtCCC_ID)
                        If Trim(txtCCC_ID.Text) = "" Then
                            Exit Sub
                        End If
                    End If
                    If EtxtCCC_ID.pFormularioConsulta Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                        frmConsulta.DatoBusquedaConsulta = txtCCC_ID.Text
                        frmConsulta.MaximizeBox = False
                        frmConsulta.MinimizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If

                Case "txtPER_ID_BAN"
                    If Not txtPER_ID_BAN.ReadOnly Then
                        EtxtPER_ID_BAN.pTexto2 = txtPER_ID_BAN.Text
                        ValidarDatos(EtxtPER_ID_BAN, txtPER_ID_BAN)
                        If Trim(txtPER_ID_BAN.Text) = "" Then
                            Exit Sub
                        End If
                    End If
                    If EtxtPER_ID_BAN.pFormularioConsulta Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmTipoDocPersonas)()
                        frmConsulta.DatoBusquedaConsulta = txtPER_ID_BAN.Text
                        frmConsulta.MaximizeBox = False
                        frmConsulta.MinimizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If

                Case "txtPER_ID_CAJ"
                    If Not txtPER_ID_CAJ.ReadOnly Then
                        EtxtPER_ID_CAJ.pTexto2 = txtPER_ID_CAJ.Text
                        ValidarDatos(EtxtPER_ID_CAJ, txtPER_ID_CAJ)
                        If Trim(txtPER_ID_CAJ.Text) = "" Then
                            Exit Sub
                        End If
                    End If
                    If EtxtPER_ID_CAJ.pFormularioConsulta Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmTipoDocPersonas)()
                        frmConsulta.DatoBusquedaConsulta = txtPER_ID_CAJ.Text
                        frmConsulta.MaximizeBox = False
                        frmConsulta.MinimizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If

                Case "txtPVE_ID"
                    If Not txtPVE_ID.ReadOnly Then
                        EtxtPVE_ID.pTexto2 = txtPVE_ID.Text
                        ValidarDatos(EtxtPVE_ID, txtPVE_ID)
                        If Trim(txtPVE_ID.Text) = "" Then
                            Exit Sub
                        End If
                    End If
                    If EtxtPVE_ID.pFormularioConsulta Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPuntoVenta)()
                        frmConsulta.DatoBusquedaConsulta = txtPVE_ID.Text
                        frmConsulta.MaximizeBox = False
                        frmConsulta.MinimizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If

                Case "txtMON_ID"
                    If Not txtMON_ID.ReadOnly Then
                        EtxtMON_ID.pTexto2 = txtMON_ID.Text
                        ValidarDatos(EtxtMON_ID, txtMON_ID)
                        If Trim(txtMON_ID.Text) = "" Then
                            Exit Sub
                        End If
                    End If
                    If EtxtMON_ID.pFormularioConsulta Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                        frmConsulta.DatoBusquedaConsulta = txtMON_ID.Text
                        frmConsulta.MaximizeBox = False
                        frmConsulta.MinimizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If

                    'Case "txtCUC_ID"
                    '    If Not txtCUC_ID.ReadOnly Then
                    '        EtxtCUC_ID.pTexto2 = txtCUC_ID.Text
                    '        ValidarDatos(EtxtCUC_ID, txtCUC_ID)
                    '        If Trim(txtCUC_ID.Text) = "" Then
                    '            Exit Sub
                    '        End If
                    '    End If
                    '    If EtxtCUC_ID.pFormularioConsulta Then
                    '        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Facturacion.Views.frmMoneda)()
                    '        frmConsulta.DatoBusquedaConsulta = txtCUC_ID.Text
                    '        frmConsulta.MaximizeBox = False
                    '        frmConsulta.MinimizeBox = False
                    '        frmConsulta.Comportamiento = -1
                    '        frmConsulta.ShowDialog()
                    '    End If

            End Select
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
                        If Comportamiento = -1 Then
                            frm.TipoEdicion = 1
                            frm.DatoBusqueda = DatoBusquedaConsulta
                        End If
                        frm.DatoBusqueda = DatoBusquedaConsulta
                        frm.oOrm = Simple
                        frm.Comportamiento = Comportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = OrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "PrepararEliminar"
                        DatoBusquedaConsulta = ProcesarNavegar("RegistroAnterior")
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 2
                        If Comportamiento = -1 Then
                            frm.TipoEdicion = 1
                            frm.DatoBusqueda = DatoBusquedaConsulta
                        End If
                        frm.DatoBusqueda = DatoBusquedaConsulta
                        frm.oOrm = Simple
                        frm.Comportamiento = Comportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = OrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "BuscarUnRegistro"
                        DatoBusquedaConsulta = ""
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = ""
                        frm.oOrm = Simple
                        frm.Comportamiento = Comportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = OrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "Load"
                        If Comportamiento = -1 Then
                            Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                            If True Then
                                frm.TipoEdicion = 2
                                If Comportamiento = -1 Then
                                    frm.TipoEdicion = 1
                                    frm.DatoBusqueda = DatoBusquedaConsulta
                                End If
                                frm.DatoBusqueda = DatoBusquedaConsulta
                            Else
                                frm.TipoEdicion = 1
                                frm.DatoBusqueda = ""
                            End If
                            frm.oOrm = Simple
                            frm.Comportamiento = Comportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = OrdenBusqueda
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
                                If Comportamiento = -1 Then
                                    frm.TipoEdicion = 1
                                    frm.DatoBusqueda = DatoBusquedaConsulta
                                End If
                                frm.DatoBusqueda = DatoBusquedaConsulta
                            Else
                                frm.TipoEdicion = 1
                                frm.DatoBusqueda = ""
                            End If
                            frm.oOrm = Simple
                            frm.Comportamiento = Comportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = OrdenBusqueda
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

                'Select Case Metodo
                '    Case "PrimerRegistro"
                '        resp = Me.IBCBusqueda.PrimerRegistro(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                '                                             Simple.cTabla.NombreLargo)
                '    Case "RegistroAnterior"
                '        Simple.CampoPrincipalValor = CodigoId & vCodigoTDP_ID
                '        resp = Me.IBCBusqueda.RegistroAnterior(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                '                                               Simple.CampoPrincipalValor, _
                '                                               Simple.cTabla.NombreLargo)
                '    Case "RegistroSiguiente"
                '        Simple.CampoPrincipalValor = CodigoId & vCodigoTDP_ID
                '        resp = Me.IBCBusqueda.RegistroSiguiente(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                '                                                Simple.CampoPrincipalValor, _
                '                                                Simple.cTabla.NombreLargo)
                '    Case "UltimoRegistro"
                '        resp = Me.IBCBusqueda.UltimoRegistro(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                '                                             Simple.cTabla.NombreLargo)
                'End Select

                vCodigoId = ProcesarNavegar(Metodo)
                'vCodigoId = resp

                If vCodigoId Is Nothing Or Trim(vCodigoId) = "" Then
                    MsgBox("¡No se encontro registros!", MsgBoxStyle.Information, Me.Text)
                    Return
                Else
                    If vCodigoId = CodigoId Then Return
                End If
                LimpiarDatos()
                DatoBusquedaConsulta = vCodigoId
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                frm.TipoEdicion = 2 ' B. directa
                If Comportamiento = -1 Then
                    frm.TipoEdicion = 1
                    frm.DatoBusqueda = DatoBusquedaConsulta
                End If
                frm.DatoBusqueda = DatoBusquedaConsulta
                frm.oOrm = Simple
                frm.Comportamiento = Comportamiento
                frm.NombreFormulario = Me
                frm.OrdenBusqueda = OrdenBusqueda
                frm.ShowDialog()
                frm.Dispose()
                BotonesEdicion("Seleccionar registro")
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - NavegarFormulario")
            End Try
        End Sub

        Private Function ProcesarNavegar(ByVal Metodo As String)
            ProcesarNavegar = ""
            Select Case Metodo
                Case "PrimerRegistro"
                    ProcesarNavegar = Me.IBCBusqueda.PrimerRegistro(Simple.CampoPrincipal, _
                                                         Simple.cTabla.NombreLargo)
                Case "RegistroAnterior"
                    Simple.CampoPrincipalValor = CodigoId
                    ProcesarNavegar = Me.IBCBusqueda.RegistroAnterior(Simple.CampoPrincipal, _
                                                           Simple.CampoPrincipalValor, _
                                                           Simple.cTabla.NombreLargo)
                Case "RegistroSiguiente"
                    Simple.CampoPrincipalValor = CodigoId
                    ProcesarNavegar = Me.IBCBusqueda.RegistroSiguiente(Simple.CampoPrincipal, _
                                                            Simple.CampoPrincipalValor, _
                                                            Simple.cTabla.NombreLargo)
                Case "UltimoRegistro"
                    ProcesarNavegar = Me.IBCBusqueda.UltimoRegistro(Simple.CampoPrincipal, _
                                                         Simple.cTabla.NombreLargo)
            End Select
            Return ProcesarNavegar
        End Function

        Private Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String)
            FormatearCampos(oObjeto, NombreCampo, Simple.vArrayDatosComboBox, Simple.vElementosDatosComboBox - 1)
        End Sub

        Private Sub MetodoBusquedaDato(ByVal vDatoBusqueda As String, _
                                      ByVal vBusquedaDirecta As Boolean, _
                                      ByVal vtxt As txt)
            'Try
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
            If vBusquedaDirecta Then
                frm.TipoEdicion = 2
                If Comportamiento = -1 Then
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
            'Catch ex As Exception
            'MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - MetodoBusquedaDato")
            'End Try
        End Sub

#End Region

        Private Sub cboCCC_TIPO_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCCC_TIPO.SelectedValueChanged
            Select Case cboCCC_TIPO.Text
                Case "CAJA", "LIQUIDACION DE DOCUMENTOS", _
                    "CUENTA DE BANCO DE DETRACCION", _
                    "RETENCIONES/PERCEPCIONES", _
                    "RENDICION DE CUENTAS"
                    txtPER_ID_BAN.Text = ""
                    txtCCC_CUENTA_BANCARIA.Text = ""

                    txtPER_ID_BAN.Enabled = False
                    txtCCC_CUENTA_BANCARIA.Enabled = False

                    txtPER_ID_BAN.ReadOnly = True
                    txtCCC_CUENTA_BANCARIA.ReadOnly = True
                Case ("CUENTA DE BANCO")
                    txtPER_ID_BAN.Enabled = True
                    txtCCC_CUENTA_BANCARIA.Enabled = True
                    txtPER_ID_BAN.ReadOnly = False
                    txtCCC_CUENTA_BANCARIA.ReadOnly = False
            End Select
        End Sub
    End Class
End Namespace