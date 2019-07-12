Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Namespace Ladisac.Maestros.Views
    Public Class frmPuntoVentaDatosUsuarios
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
                        TeclaF1SubLlamadas(txt.Name)
                    End If
                End If
                SubValidarDatos(otxt, txt)
            End With
        End Sub
        Private Sub MetodoBusquedaDato(ByVal vDatoBusqueda As String, _
                                       ByVal vBusquedaDirecta As Boolean, _
                                       ByVal vtxt As txt)
            Try
                If BloquearBusquedaCampos(vtxt) Then Exit Sub
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
        Private Sub TeclaF1(ByRef otxt As txt, ByRef txt As TextBox)
            If otxt.pBusqueda Then
                otxt.pTexto2 = txt.Text
                ValidarDatos(otxt, txt)
                MetodoBusquedaDato("", False, otxt)
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
            ConfigurarFormulario(2)
        End Sub
        Public Sub EditarRegistro()
            If Not pFlagNuevo Then If Trim(pCodigoId) = "" Then Return
            BotonesEdicion("Editar registro")
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
                        Dim resp = Me.IBCBusqueda.RegistroAnterior("cast(" & Compuesto.CampoPrincipal & " as varchar)", _
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
                            Dim resp = Me.IBCBusqueda.PrimerRegistro("cast(" & Compuesto.CampoPrincipal & " as varchar) ", _
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
                        resp = Me.IBCBusqueda.PrimerRegistro("cast(" & Compuesto.CampoPrincipal & " as varchar)  + " & _
                                                             "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar)", _
                                                             Compuesto.cTabla.NombreLargo, Compuesto.CadenaFiltrado)
                    Case "RegistroAnterior"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroAnterior("cast(" & Compuesto.CampoPrincipal & " as varchar)  + " & _
                                                               "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar)", _
                                                               Compuesto.CampoPrincipalValor, _
                                                               Compuesto.cTabla.NombreLargo, Compuesto.CadenaFiltrado)
                    Case "RegistroSiguiente"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroSiguiente("cast(" & Compuesto.CampoPrincipal & " as varchar)  + " & _
                                                                "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar)", _
                                                                Compuesto.CampoPrincipalValor, _
                                                                Compuesto.cTabla.NombreLargo, Compuesto.CadenaFiltrado)
                    Case "UltimoRegistro"
                        resp = Me.IBCBusqueda.UltimoRegistro("cast(" & Compuesto.CampoPrincipal & " as varchar)  + " & _
                                                             "cast(" & Compuesto.CampoPrincipalSecundario & " as varchar)", _
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
        Private Sub ConfigurarReadOnly(ByRef vObjeto As Object, Optional ByRef vStructure As Object = Nothing)
            If vObjeto.GetType <> GetType(ComboBox) And _
                vObjeto.GetType <> GetType(DateTimePicker) Then
                vObjeto.ReadOnly = True
            Else
                If Not IsNothing(vStructure) Then vStructure.pEnabled = False
            End If
            vObjeto.Enabled = True
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
            vObjeto.Enabled = True
            If Not IsNothing(vStructure) Then vStructure.pBusqueda = Not vBoolean ' False
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
        Public Property IBC As Ladisac.BL.IBCPuntoVentaDatosUsuarios

        <Dependency()> _
        Public Property IBCDetalle As Ladisac.BL.IBCSeriesDatosUsuarios

        ' Controlar la clave de la tabla
        Public vCodigoPVE_ID As String = ""

        ' CheckBox
        Private EchkPVE_ESTADO As New chk
        Private EchkPDU_ESTADO As New chk

        ' ComboBox
        Private EcboPDU_TIPO_LISTA As New cbo
        Private EcboPDU_ENTREGA_PLANTA As New cbo
        Private EcboPDU_ENTREGA_PUNTO_VENTA As New cbo

        ' DataGridView
        Private EdgvDetalle As New dgv

        ' TextBox
        '' PK
        Private EtxtDAU_ID As New txt

        '' Texto

        '' Número

        ' Celdas para datos tabla detalle 
        '' PK
        Private EtxtTDO_ID As New txt

        Private Compuesto As New Ladisac.BE.PuntoVentaDatosUsuarios
        Private Compuesto1 As New Ladisac.BE.SeriesDatosUsuarios
        Private ErrorData As New Ladisac.BE.PuntoVentaDatosUsuarios.ErrorData
        Private cMisProcedimientos As New Ladisac.MisProcedimientos
        Private Structure ElementosEliminar
            Public cDAU_ID As String
            Public cPVE_ID As String
            Public cTDO_ID As String
            Public cCTD_COR_SERIE As String
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
            InicializarValores(txtDAU_ID, ErrorProvider1)
            InicializarValores(txtPVE_ID, ErrorProvider1)
            InicializarValores(cboPDU_TIPO_LISTA, ErrorProvider1)
            InicializarValores(cboPDU_ENTREGA_PLANTA, ErrorProvider1)
            InicializarValores(cboPDU_ENTREGA_PUNTO_VENTA, ErrorProvider1)
            InicializarValores(chkPDU_ESTADO, ErrorProvider1, False, False, EchkPDU_ESTADO.pValorDefault)
            ColocarValoresDefault(chkPDU_ESTADO)
            InicializarValores(dgvDetalle, ErrorProvider1)
            ReDim eRegistrosEliminar(1)
            vBuscarDetalle = True
        End Sub
        Private Sub HabilitarNuevo()
            txtDAU_ID.Enabled = True
            txtPVE_ID.Enabled = True
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkPDU_ESTADO)
        End Sub
        Private Sub ProcesarGridVacio()
            If dgvDetalle.RowCount = 0 Then ' Habilita
                'ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, False)
                'ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, False)
                'ConfigurarReadOnlyNoBusqueda(dtpDOC_FECHA_EMI, Nothing, False)
                'ConfigurarReadOnlyNoBusqueda(txtMON_ID, EtxtMON_ID, False)
                'ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, False)
                'ConfigurarReadOnlyNoBusqueda(txtTDP_ID_CLI, EtxtTDP_ID_CLI, False)
                'ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, EcboDOC_TIPO_LISTA, False)
                'ConfigurarReadOnlyNoBusqueda(txtPVE_ID_DES, EtxtPVE_ID_DES, False)
                'ConfigurarReadOnlyNoBusqueda(txtLPR_ID, EtxtLPR_ID, False)
                'ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, False)

                ''ConfigurarReadOnlyNoBusqueda(txtDTD_ID_AFE, EtxtDTD_ID_AFE, False)
                'ConfigurarReadOnly(txtDTD_ID_AFE, EtxtDTD_ID_AFE)
                'EtxtDTD_ID_AFE.pBusqueda = True

                'ProcesarCboDOC_TIPO_LISTA() ' Proceso de validación de CboDOC_TIPO_LISTA
            End If
            If dgvDetalle.RowCount >= 1 Then ' Inhabilita
                'ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, True)
                'ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, True)
                'ConfigurarReadOnlyNoBusqueda(dtpDOC_FECHA_EMI, Nothing, True)
                'ConfigurarReadOnlyNoBusqueda(txtMON_ID, EtxtMON_ID, True)
                'ConfigurarReadOnlyNoBusqueda(txtPER_ID_CLI, EtxtPER_ID_CLI, True)
                'ConfigurarReadOnlyNoBusqueda(txtTDP_ID_CLI, EtxtTDP_ID_CLI, True)
                'ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, EcboDOC_TIPO_LISTA, True)
                'ConfigurarReadOnlyNoBusqueda(txtPVE_ID_DES, EtxtPVE_ID_DES, True)
                'ConfigurarReadOnlyNoBusqueda(txtLPR_ID, EtxtLPR_ID, True)
                'ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, True)

                'ConfigurarReadOnlyNoBusqueda(txtDTD_ID_AFE, EtxtDTD_ID_AFE, True)
            End If
        End Sub
        Private Sub CrearCodigoId()
            EtxtDAU_ID.pComportamiento = 1
            MetodoBusquedaDato("", False, EtxtDAU_ID)
            EtxtDAU_ID.pComportamiento = 0
            EtxtTDO_ID.pOOrm.CadenaFiltrado = " And PVE_ID ='" & txtPVE_ID.Text & "'"
        End Sub
        Private Sub HabilitarEscrituraNuevo()
            txtDAU_ID.ReadOnly = False
            txtPVE_ID.ReadOnly = False
        End Sub
        Private Sub ConfigurarFormulario(ByVal vControl As Integer)
            'Select Case pTDO_ID
            '    Case BCVariablesNames.ProcesosFacturación.NotaCredito
            '        Notas(vControl)
            '    Case BCVariablesNames.ProcesosFacturación.NotaDebito
            '        Notas(vControl)
            '    Case Else
            '        Ventas(vControl)
            'End Select
        End Sub
        Public Sub DeshabilitarModificar()
            ProcesarGridVacio() ' Deshabilita/Habilita de acuerdo a si el grid esta vacio o no
            DesBloquearBloquearControlesXModificar() ' Aca confirmamos los controles inhabilitados siempre que se modifica
        End Sub
        Private Sub DesBloquearBloquearControlesXModificar()
            'ConfigurarReadOnlyNoBusqueda(txtPVE_ID, EtxtPVE_ID, True) ' BLoquea
            'ConfigurarReadOnlyNoBusqueda(txtDTD_ID, EtxtDTD_ID, True) ' BLoquea
            'ConfigurarReadOnlyNoBusqueda(txtDOC_SERIE, EtxtDOC_SERIE, True) ' BLoquea
            'ConfigurarReadOnlyNoBusqueda(txtDOC_NUMERO, EtxtDOC_NUMERO, True) ' BLoquea
            'ConfigurarReadOnlyNoBusqueda(cboSerieCorrelativo, Nothing, True) ' BLoquea
            'ControlVisible(cboSerieCorrelativo, False) ' Oculta
            'ConfigurarReadOnlyNoBusqueda(cboDOC_TIPO_LISTA, EcboDOC_TIPO_LISTA, True) 'Desbloquea
            'ConfigurarReadOnlyNoBusqueda(txtPVE_ID_DES, EtxtPVE_ID_DES, True) 'Desbloquea
            'ConfigurarReadOnlyNoBusqueda(txtFLE_ID, EtxtFLE_ID, True) 'Desbloquea
            ''ProcesarCboDOC_TIPO_LISTA() ' Proceso de validación de CboDOC_TIPO_LISTA
            'vTextChangedDOC_TIPO_LISTA = False
        End Sub
        Private Sub AdicionarFilasGrid()
            dgvDetalle.Rows.Add("", "", "", "", "ACTIVO", 0)
            EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
        End Sub
        Private Sub EliminarFilasGrid()
            If dgvDetalle.Rows.Count = 0 Then Return
            Dim vfila As DataGridViewRow
            vfila = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index)
            If dgvDetalle.Rows.Count > 0 Then
                Try
                    With dgvDetalle.Rows(dgvDetalle.CurrentRow.Index)
                        If .Cells("cEstadoRegistro").Value Then
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cDAU_ID = txtDAU_ID.Text
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cPVE_ID = txtPVE_ID.Text
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cTDO_ID = .Cells("cTDO_ID").Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cCTD_COR_SERIE = .Cells("cCTD_COR_SERIE").Value.ToString()
                            ReDim Preserve eRegistrosEliminar(eRegistrosEliminar.Count)
                        End If
                    End With
                    dgvDetalle.Rows.Remove(vfila)
                Catch ex As Exception
                    MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & "- QuitarFilaGrid")
                End Try
            End If
        End Sub
        Public Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "CancelarEdicion"
                    CodigoId = CodigoId & vCodigoPVE_ID
                    If Trim(CodigoId) = "" Then CodigoId = "%"
                Case "PrepararEliminar"
                    Compuesto.Vista = "RegistroAnterior"
                    Compuesto.DAU_ID = CodigoId
                    Compuesto.PVE_ID = vCodigoPVE_ID
                Case "Load"
                    Compuesto.Vista = "PrimerAnterior"
                    Compuesto.DAU_ID = CodigoId
                    Compuesto.PVE_ID = vCodigoPVE_ID
                Case "RegistroNoEncontrado"
                    Compuesto.DAU_ID = txtDAU_ID.Text.Trim
                    Compuesto.PVE_ID = txtPVE_ID.Text.Trim
                Case "NavegarFormulario"
                    CodigoId = CodigoId & vCodigoPVE_ID
                Case "EliminarRegistro"
                    Compuesto.DAU_ID = txtDAU_ID.Text.Trim
                    CodigoId = txtDAU_ID.Text.Trim
                    Compuesto.PVE_ID = txtPVE_ID.Text.Trim
                    vCodigoPVE_ID = txtPVE_ID.Text.Trim
                Case "InicializarDatos"
                    Compuesto.DAU_ID = txtDAU_ID.Text.Trim
                    CodigoId = txtDAU_ID.Text.Trim
                    Compuesto.PVE_ID = txtPVE_ID.Text.Trim
                    vCodigoPVE_ID = txtPVE_ID.Text.Trim
                    Compuesto1.DAU_ID = txtDAU_ID.Text.Trim
                    If vBuscarDetalle Then
                        Compuesto1.Vista = "ListarRegistros"
                        Dim NombreProcedimiento As String = Compuesto1.SentenciaSqlBusqueda()
                        Dim ds As New DataSet
                        Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, CodigoId, vCodigoPVE_ID, ""))
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
                    End If
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
                    Compuesto1.DAU_ID = txtDAU_ID.Text
                    Compuesto1.PVE_ID = txtPVE_ID.Text
                    Compuesto1.TDO_ID = .Cells("cTDO_ID").value
                    Compuesto1.CTD_COR_SERIE = .Cells("cCTD_COR_SERIE").value
                    Compuesto1.USU_ID = SessionService.UserId
                    Compuesto1.SDU_FEC_GRAB = Now
                    Compuesto1.SDU_ESTADO = DevolverTiposCampos("SDU_ESTADO", .Cells("cSDU_ESTADO").value.tostring, Compuesto1)
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
                    EliminarRegistroDetalle = Me.IBCDetalle.DeleteRegistro(Compuesto1, eRegistrosEliminar(fila).cDAU_ID, eRegistrosEliminar(fila).cPVE_ID, eRegistrosEliminar(fila).cTDO_ID, eRegistrosEliminar(fila).cCTD_COR_SERIE)
                    If EliminarRegistroDetalle = 0 Then
                        vMensajeErrorOrm = Compuesto1.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarRegistroDetalle
        End Function
        Private Sub DatosCabecera()
            Compuesto.DAU_ID = Strings.Trim(txtDAU_ID.Text)
            Compuesto.PVE_ID = Strings.Trim(txtPVE_ID.Text)
            Compuesto.PDU_TIPO_LISTA = DevolverTiposCampos("PDU_TIPO_LISTA", cboPDU_TIPO_LISTA.Text, Compuesto)
            Compuesto.PDU_ENTREGA_PLANTA = DevolverTiposCampos("PDU_ENTREGA_PLANTA", cboPDU_ENTREGA_PLANTA.Text, Compuesto)
            Compuesto.PDU_ENTREGA_PUNTO_VENTA = DevolverTiposCampos("PDU_ENTREGA_PUNTO_VENTA", cboPDU_ENTREGA_PUNTO_VENTA.Text, Compuesto)
            Compuesto.USU_ID = SessionService.UserId
            Compuesto.PDU_FEC_GRAB = Now
            Compuesto.PDU_ESTADO = DevolverTiposCampos(chkPDU_ESTADO)
        End Sub
        Private Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Compuesto.ColocarErrores(txtDAU_ID, Compuesto.VerificarDatos("DAU_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPVE_ID, Compuesto.VerificarDatos("PVE_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboPDU_TIPO_LISTA, Compuesto.VerificarDatos("PDU_TIPO_LISTA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboPDU_ENTREGA_PLANTA, Compuesto.VerificarDatos("PDU_ENTREGA_PLANTA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboPDU_ENTREGA_PUNTO_VENTA, Compuesto.VerificarDatos("PDU_ENTREGA_PUNTO_VENTA"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(pnCuerpo, Compuesto.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(btnImagen, Compuesto.VerificarDatos("PDU_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkPDU_ESTADO, Compuesto.VerificarDatos("PDU_ESTADO"), ErrorProvider1)
                Case "Detalle"
                    resp.rM = Compuesto1.ColocarErrores(dgvDetalle, _
                    Compuesto1.VerificarDatos("DAU_ID",
                    "PVE_ID",
                    "TDO_ID",
                    "CTD_COR_SERIE",
                    "USU_ID",
                    "SDU_FEC_GRAB",
                    "SDU_ESTADO"), _
                    ErrorProvider1)
            End Select
            Return vrO
        End Function
        Private Sub InicializarOrm()
            InicializarOrmDetalle()
            Compuesto = Nothing
            Compuesto = New Ladisac.BE.PuntoVentaDatosUsuarios
        End Sub
        Private Sub InicializarOrmDetalle()
            Compuesto1 = Nothing
            Compuesto1 = New Ladisac.BE.SeriesDatosUsuarios
        End Sub
        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            EtxtTDO_ID.pOOrm.CadenaFiltrado = " And PVE_ID ='" & txtPVE_ID.Text & "'"
        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                'If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDAU_ID" Then EtxtDAU_ID.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                'If Me.ActiveControl.Name.ToString = "txtPVE_ID" Then EtxtPVE_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtDAU_ID" Then EtxtDAU_ID.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function
        Private Function ProcesarEliminarDetalle() As Int16
            Return EliminarDetalle(Compuesto1)
        End Function
        Private Function EliminarDetalle(ByVal oOrm As SeriesDatosUsuarios) As Int16
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
                LongitudId = 6
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
            BuscarFormatos(EcboPDU_TIPO_LISTA, Compuesto, cboPDU_TIPO_LISTA, 0)
            BuscarFormatos(EcboPDU_ENTREGA_PLANTA, Compuesto, cboPDU_ENTREGA_PLANTA, 0)
            BuscarFormatos(EcboPDU_ENTREGA_PUNTO_VENTA, Compuesto, cboPDU_ENTREGA_PUNTO_VENTA, 0)
        End Sub
        Private Sub NombresFormulariosControles()
            EtxtDAU_ID.pOOrm = New Ladisac.BE.PuntoVentaDatosUsuarios
            EtxtDAU_ID.pComportamiento = 1
            EtxtDAU_ID.pOrdenBusqueda = 0

            EtxtTDO_ID.pOOrm = New Ladisac.BE.CorrelativoTipoDocumento
            EtxtTDO_ID.pComportamiento = 2
            EtxtTDO_ID.pOrdenBusqueda = 0
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

            EchkPVE_ESTADO = EchkTemporal
            EchkPVE_ESTADO.pNombreCampo = "PVE_ESTADO"
            ConfigurarCheck_Refrescar(EchkPVE_ESTADO)


            EchkPDU_ESTADO = EchkTemporal
            EchkPDU_ESTADO.pNombreCampo = "PDU_ESTADO"
            EchkPDU_ESTADO.pValorDefault = CheckState.Checked
            ConfigurarCheck_Refrescar(EchkPDU_ESTADO)
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkPDU_ESTADO"
                    Compuesto.CampoId = EchkPDU_ESTADO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Compuesto.DevolverTiposCampos()
        End Function
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkPVE_ESTADO"
                    vObjetoChk.pValorDefault = EchkPVE_ESTADO.pValorDefault
                Case "chkPDU_ESTADO"
                    vObjetoChk.pValorDefault = EchkPDU_ESTADO.pValorDefault
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
        Handles chkPDU_ESTADO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkPDU_ESTADO"
                    If EchkPDU_ESTADO.pFormatearTexto Then
                        InicializarTextoCheck(EchkPDU_ESTADO)
                    End If
            End Select
        End Sub
        Private Sub InicializarTextoCheck(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "PVE_ESTADO"
                    With chkPVE_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "PDU_ESTADO"
                    With chkPDU_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTextoCheck(EchkPVE_ESTADO)
            InicializarTextoCheck(EchkPDU_ESTADO)
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
            EdgvDetalle.pArrayCamposPkDetalle(1) = "cTDO_ID"
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
            End Select
        End Sub
        Private Sub dgvDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles dgvDetalle.KeyDown
            If e.KeyData = Keys.Return Then
                SendKeys.Send(Chr(Keys.Tab))
            End If
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cTDO_ID"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtTDO_ID.pBusqueda Then
                                EtxtTDO_ID.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                                MetodoBusquedaDato("", False, EtxtTDO_ID)
                                EtxtTDO_ID.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                                EtxtTDO_ID.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                            End If
                    End Select
            End Select
        End Sub
        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvDetalle.CellDoubleClick
            If dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name = "cTDO_ID" Then
                If EtxtTDO_ID.pFormularioConsulta Then
                    Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmCorrelativoTipoDocumento)()
                    frmConsulta.DatoBusquedaConsulta = dgvDetalle.CurrentCell.Value
                    frmConsulta.MaximizeBox = False
                    frmConsulta.Comportamiento = -1
                    frmConsulta.ShowDialog()
                    Exit Sub
                End If
            End If
            If EdgvDetalle.pMetodoColumnas Then
                For Each EdgvDetalle.Elementos In EdgvDetalle.Columnas
                    If dgvDetalle.CurrentCell.ColumnIndex = EdgvDetalle.Elementos Then
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
                            dgvDetalle.Columns(vCampoPk).ReadOnly = False
                            EtxtTDO_ID.pBusqueda = True
                        Else
                            EtxtTDO_ID.pBusqueda = False
                            dgvDetalle.Columns(vCampoPk).ReadOnly = True
                        End If
                    End If
                Next elemento
            End If
        End Sub
        Private Sub dgvDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvDetalle.CellEnter
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cTDO_ID"
                    EtxtTDO_ID.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
            End Select
        End Sub
        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles dgvDetalle.CellValidated
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cTDO_ID"
                    dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    EtxtTDO_ID.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value
                    ValidarDatos(EtxtTDO_ID, dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value, True)
            End Select
        End Sub
        Private Sub ValidarDatos(ByRef otxt As txt, ByVal texto As String, ByVal BusquedaDirecta As Boolean)
            If otxt.pTexto1 <> otxt.pTexto2 Then
                If otxt.pBusqueda Then
                    MetodoBusquedaDato(texto, BusquedaDirecta, otxt)
                End If
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

            EtxtTDO_ID = EtxtTemporal
            EtxtTDO_ID.pBusqueda = True
            EtxtTDO_ID.pFormularioConsulta = True

            EtxtDAU_ID = EtxtTemporal
            EtxtDAU_ID.pBusqueda = True
            EtxtDAU_ID.pFormularioConsulta = True
        End Sub
        Private Sub TeclaF1SubLlamadas(ByVal vNametxt As String)
            Select Case vNametxt
            End Select
        End Sub
#End Region

#End Region

#Region "Secundaria 2"
        Private Sub FormatearCampos()
            FormatearCampos(txtDAU_ID, "DAU_ID", EtxtDAU_ID)
            FormatearCampos(txtPVE_ID, "PVE_ID", EtxtDAU_ID)
            FormatearCampos(cboPDU_TIPO_LISTA, "PDU_TIPO_LISTA", EtxtDAU_ID)
            FormatearCampos(cboPDU_ENTREGA_PLANTA, "PDU_ENTREGA_PLANTA", EtxtDAU_ID)
            FormatearCampos(cboPDU_ENTREGA_PUNTO_VENTA, "PDU_ENTREGA_PUNTO_VENTA", EtxtDAU_ID)
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String, ByRef sender As txt, Optional ByVal e As System.Boolean = True)
            FormatearCampos(oObjeto, NombreCampo, sender.pOOrm.vArrayDatosComboBox, sender.pOOrm.vElementosDatosComboBox - 1, sender, e)
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
            'EtxtPVE_ID.pOOrm.CadenaFiltrado = ""
            EtxtDAU_ID.pOOrm.CadenaFiltrado = ""
        End Sub
        Private Function BloquearBusquedaCampos(ByVal vtxt As txt, Optional ByVal vMensaje As Boolean = True) As Boolean
            BloquearBusquedaCampos = False
            'If vtxt.pOOrm.cTabla.NombreCorto = "Moneda" Then
            '    If dgvDetalle.RowCount > 0 Then
            '        BloquearBusquedaCampos = True
            '        If vMensaje Then MsgBox("No se puede cambiar ?" & Chr(13) & "si la grilla posee registros", MsgBoxStyle.Information, Me.Text)
            '    End If
            'End If
            Return BloquearBusquedaCampos
        End Function
        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                'Case 6 ' Personas - Clientes
                'Return 0
            End Select
        End Function
#Region "ComboBox"
        Private Sub ConfigurarComboBox()
            EcboPDU_TIPO_LISTA.pNombreCampo = "PDU_TIPO_LISTA"
            cboPDU_TIPO_LISTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            EcboPDU_ENTREGA_PLANTA.pNombreCampo = "PDU_ENTREGA_PLANTA"
            cboPDU_ENTREGA_PLANTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            EcboPDU_ENTREGA_PUNTO_VENTA.pNombreCampo = "PDU_ENTREGA_PUNTO_VENTA"
            cboPDU_ENTREGA_PUNTO_VENTA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        End Sub
#End Region

#Region "TextBox"
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtDAU_ID.GotFocus
            Select Case sender.name.ToString
                Case "txtDAU_ID"
                    EtxtDAU_ID.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtDAU_ID.LostFocus
            Select Case sender.name.ToString
                Case "txtDAU_ID"
                    EtxtDAU_ID.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtDAU_ID.Validated
            Select Case sender.name.ToString
                Case "txtDAU_ID"
                    ValidarDatos(EtxtDAU_ID, txtDAU_ID)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtDAU_ID.KeyPress
            Select Case sender.name.ToString
                Case "txtDAU_ID"
                    oKeyPress(EtxtDAU_ID, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtDAU_ID.DoubleClick
            Select Case sender.name.ToString
                Case "txtDAU_ID"
                    oDoubleClick(EtxtDAU_ID, txtDAU_ID, "")
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
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtDAU_ID.KeyDown
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtDAU_ID"
                            TeclaF1(EtxtDAU_ID, txtDAU_ID)
                    End Select
            End Select
        End Sub
#End Region

#End Region

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

    End Class
End Namespace