Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Namespace Ladisac.Tesoreria.Views
    Public Class frmTesoreriaCobranzaLegal
        <Dependency()> _
        Public Property IBCMovimientoCajaBanco As Ladisac.BL.IBCMovimientoCajaBanco

        <Dependency()> _
        Public Property BCVariablesNames As BL.BCVariablesNames

        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCTesoreriaCobranzaLegal As Ladisac.BL.IBCTesoreriaCobranzaLegal

        <Dependency()> _
        Public Property IBCKardexCtaCte As Ladisac.BL.IBCKardexCtaCte

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Public Property pTDO_ID As String = "XXX"
        Public Property vBCVariablesNamesProcesosCtaCteLiquidacionDocumento As String = "YYY"
        Public Property pCCT_ID As String = BCVariablesNames.CCT_ID.CxCComerciales

        Private pLoaded As Boolean = True
        Private pRegistroNuevo As Boolean = False
        Private pColeccionDatos As Collection = Nothing
        Private pComportamiento As Int32 = 0
        Private pOrdenBusqueda As Int32 = 0
        Private pDatoBusquedaConsulta As String = ""
        Private pFlagNuevo As Boolean = False

        ''Private vItemMovimientoCajaBanco As Integer
        Private vItemKardexCtaCteLegal As Integer

        Private EchkTCL_ESTADO As New chk

        Private EtxtPER_ID_CLIx As New txt
        Private EtxtDTD_IDx As New txt

        ' DateTimePicker
        Private EdtpTCL_FECHA_EMI As New dtp

        Private Simple As New Ladisac.BE.TesoreriaCobranzaLegal
        Private Simple1 As New Ladisac.BE.KardexCtaCte

        Private ErrorData As New Ladisac.BE.TesoreriaCobranzaLegal.ErrorData
        Private Shared vrO As Boolean = True
        Private Shared vrM As Boolean = True
        Private pLongitudId As Integer = 0
        Private pCaracterId As String = Nothing
        Private pCodigoId As String = ""

        ' Controlar la clave de la tabla
        Public vCodigoDTD_ID As String = ""
        Public vCodigoTCL_SERIE As String = ""
        Public vCodigoTCL_NUMERO As String = ""

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
        Private pOkbusqueda As Boolean = True
        Private pInicio As Boolean = True
        Private pAnterior As Boolean = True
        Private pSiguiente As Boolean = True
        Private pFinal As Boolean = True
        Private pReportes As Boolean = True
        Private pSalida As Boolean = True

        Private cMisProcedimientos As New Ladisac.MisProcedimientos

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
            Public Property pNombreFormulario As System.Type
            Public Property pFormularioConsulta As Object

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
        Public Property OkBusqueda() As Boolean
            Set(ByVal value As Boolean)
                pOkbusqueda = value
            End Set
            Get
                Return pOkbusqueda
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

            txtPER_ID_CLIx.Enabled = False
            EtxtPER_ID_CLIx.pBusqueda = False

            txtDTD_IDx.Enabled = False
            EtxtDTD_IDx.pBusqueda = False
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

            Dim vFechaServidor, vFechaDocumento As Date
            vFechaServidor = IBCMaestro.EjecutarVista("spFechaServidor")
            vFechaDocumento = dtpTCL_FECHA_EMI.Value

            If vFechaDocumento > vFechaServidor Then
                MsgBox("¡Fecha de proceso erronea!", MsgBoxStyle.Exclamation, Me.Text)
                Exit Sub
            End If

            Dim bRes As Boolean = False
            If Not pRegistroNuevo Then
                If Not RevisarDatos(True) Then
                    If vNuevo Then
                        NuevoRegistro()
                    End If
                    Return
                End If
            End If

            vItemKardexCtaCteLegal = Me.IBCKardexCtaCte.ItemKardexCtaCteLegal(txtTDO_ID.Text, txtDTD_ID.Text, txtTCL_SERIE.Text, txtTCL_NUMERO.Text, txtPER_ID_CLI.Text)

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
            Select Case SessionService.UserId
                Case "ADMIN"
                Case Else
                    MsgBox("¡No se puede eliminar!" + Chr(13) + Chr(13) + "Anule el documento", MsgBoxStyle.Exclamation, Me.Text)
                    Exit Sub
            End Select
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



        Private Sub LimpiarDatos()
            dtpTCL_FECHA_EMI.Value = Today
            ErrorProvider1.SetError(dtpTCL_FECHA_EMI, Nothing)

            chkTCL_ESTADO.Checked = Nothing
            chkTCL_ESTADO.CheckState = EchkTCL_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkTCL_ESTADO, Nothing)

            txtTDO_ID.Text = ""

            txtDTD_ID.Text = ""
            ErrorProvider1.SetError(txtDTD_ID, Nothing)

            txtDTD_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtDTD_DESCRIPCION, Nothing)

            txtCCT_ID.Text = ""
            ErrorProvider1.SetError(txtCCT_ID, Nothing)

            txtCCT_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtCCT_DESCRIPCION, Nothing)

            txtTCL_SERIE.Text = ""
            ErrorProvider1.SetError(txtTCL_SERIE, Nothing)

            txtTCL_NUMERO.Text = ""
            ErrorProvider1.SetError(txtTCL_NUMERO, Nothing)

            txtMON_ID.Text = ""
            ErrorProvider1.SetError(txtMON_ID, Nothing)

            txtMON_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtMON_DESCRIPCION, Nothing)

            txtMON_SIMBOLO.Text = ""
            ErrorProvider1.SetError(txtMON_SIMBOLO, Nothing)

            txtTCL_MONTO.Text = "0.00"
            ErrorProvider1.SetError(txtTCL_MONTO, Nothing)

            txtPER_ID_CLI.Text = ""
            ErrorProvider1.SetError(txtPER_ID_CLI, Nothing)

            txtPER_DESCRIPCION_CLI.Text = ""
            ErrorProvider1.SetError(txtPER_DESCRIPCION_CLI, Nothing)

            txtPER_ID_CLIx.Text = ""
            ErrorProvider1.SetError(txtPER_ID_CLIx, Nothing)

            txtPER_DESCRIPCION_CLIx.Text = ""
            ErrorProvider1.SetError(txtPER_DESCRIPCION_CLIx, Nothing)

            txtDTD_IDx.Text = ""
            ErrorProvider1.SetError(txtCCT_ID, Nothing)

        End Sub
        Private Sub HabilitarNuevo()
            lblPER_ID_CLIx.Visible = True
            txtPER_ID_CLIx.Visible = True
            txtPER_DESCRIPCION_CLIx.Visible = True

            txtPER_ID_CLIx.Enabled = True
            EtxtPER_ID_CLIx.pBusqueda = True

            lblDTD_IDx.Visible = True
            txtDTD_IDx.Visible = True

            txtDTD_IDx.Enabled = True
            EtxtDTD_IDx.pBusqueda = True
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkTCL_ESTADO)
        End Sub
        Public Sub ColocarValoresDefault(ByVal vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkTCL_ESTADO"
                    vObjetoChk.pValorDefault = EchkTCL_ESTADO.pValorDefault
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
        End Sub

        Private Sub HabilitarEscrituraNuevo()

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

        Private Sub BusquedaDatos(ByVal vProceso As String)
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
                            frm.oOrm = Simple
                            frm.Comportamiento = pComportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = pOrdenBusqueda
                            frm.ShowDialog()
                            frm.Dispose()
                        End If
                    Case "PrepararEliminar"
                        Simple.CampoPrincipalValor = CodigoId & vCodigoDTD_ID & vCodigoTCL_SERIE & vCodigoTCL_NUMERO
                        Dim resp = Me.IBCBusqueda.RegistroAnteriorFiltro("cast(" & Simple.CampoPrincipal & " as varchar) + " & _
                                                                         "cast(" & Simple.CampoPrincipalSecundario & " as varchar) + " & _
                                                                         "cast(" & Simple.CampoPrincipalTercero & " as varchar) + " & _
                                                                         "cast(" & Simple.CampoPrincipalCuarto & " as varchar)  ", _
                                                                         Simple.CampoPrincipalValor, _
                                                                         Simple.cTabla.NombreVista, Simple.CadenaFiltrado)

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
                            Dim resp = Me.IBCBusqueda.PrimerRegistroFiltro("cast(" & Simple.CampoPrincipal & " as varchar) + " & _
                                                                           "cast(" & Simple.CampoPrincipalSecundario & " as varchar) + " & _
                                                                           "cast(" & Simple.CampoPrincipalTercero & " as varchar) + " & _
                                                                           "cast(" & Simple.CampoPrincipalCuarto & " as varchar) + ", _
                                                                           Simple.cTabla.NombreVista, Simple.CadenaFiltrado)
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
        Public Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "CancelarEdicion"
                    CodigoId = CodigoId & vCodigoDTD_ID & vCodigoTCL_SERIE & vCodigoTCL_NUMERO
                    If Trim(CodigoId) = "" Then CodigoId = "%"
                Case "PrepararEliminar"
                    Simple.Vista = "RegistroAnterior"
                    Simple.TDO_ID = CodigoId
                    Simple.DTD_ID = vCodigoDTD_ID
                    Simple.TCL_SERIE = vCodigoTCL_SERIE
                    Simple.TCL_NUMERO = vCodigoTCL_NUMERO
                    Simple.PER_ID_CLI = txtPER_ID_CLI.Text.Trim
                Case "Load"
                    Simple.Vista = "PrimerAnterior"
                    Simple.TDO_ID = CodigoId
                    Simple.DTD_ID = vCodigoDTD_ID
                    Simple.TCL_SERIE = vCodigoTCL_SERIE
                    Simple.TCL_NUMERO = vCodigoTCL_NUMERO
                    Simple.PER_ID_CLI = txtPER_ID_CLI.Text.Trim
                Case "RegistroNoEncontrado" ' ojito
                    Simple.TDO_ID = txtTDO_ID.Text.Trim
                    Simple.DTD_ID = txtDTD_ID.Text.Trim
                    Simple.TCL_SERIE = txtTCL_SERIE.Text.Trim
                    Simple.TCL_NUMERO = txtTCL_NUMERO.Text.Trim
                    Simple.PER_ID_CLI = txtPER_ID_CLI.Text.Trim

                    CodigoId = Simple.TDO_ID
                    vCodigoDTD_ID = Simple.DTD_ID
                    vCodigoTCL_SERIE = Simple.TCL_SERIE
                    vCodigoTCL_NUMERO = Simple.TCL_NUMERO
                Case "NavegarFormulario"
                    CodigoId = CodigoId & vCodigoDTD_ID & vCodigoTCL_SERIE & vCodigoTCL_NUMERO
                Case "EliminarRegistro"
                    Simple.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim

                    Simple.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim

                    Simple.TCL_SERIE = txtTCL_SERIE.Text.Trim
                    vCodigoTCL_SERIE = txtTCL_SERIE.Text.Trim

                    Simple.TCL_NUMERO = txtTCL_NUMERO.Text.Trim
                    vCodigoTCL_NUMERO = txtTCL_NUMERO.Text.Trim

                    Simple.PER_ID_CLI = txtPER_ID_CLI.Text.Trim

                    Simple.TCL_FECHA_EMI = dtpTCL_FECHA_EMI.Value
                    Simple.USU_ID = SessionService.UserId
                Case "InicializarDatos"
                    Simple.TDO_ID = txtTDO_ID.Text.Trim
                    CodigoId = txtTDO_ID.Text.Trim

                    Simple.DTD_ID = txtDTD_ID.Text.Trim
                    vCodigoDTD_ID = txtDTD_ID.Text.Trim

                    Simple.TCL_SERIE = txtTCL_SERIE.Text.Trim
                    vCodigoTCL_SERIE = txtTCL_SERIE.Text.Trim

                    Simple.TCL_NUMERO = txtTCL_NUMERO.Text.Trim
                    vCodigoTCL_NUMERO = txtTCL_NUMERO.Text.Trim

                    Simple.PER_ID_CLI = txtPER_ID_CLI.Text.Trim
            End Select
        End Sub

        Private Function Ingresar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Ingresar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                Using Scope As New System.Transactions.TransactionScope()
                    If (InsertarDatos()) Then
                        Scope.Complete()
                        Ingresar = True
                        MsgBox("Registro ingresado", MsgBoxStyle.Information, Me.Text)
                    Else
                        Scope.Dispose()
                        MsgBox("No se pudo ingresar verifique sus datos" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
                    End If
                End Using
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
            Return Ingresar
        End Function
        Private Sub DatosCabecera()
            Simple.TDO_ID = Strings.Trim(txtTDO_ID.Text)
            Simple.DTD_ID = Strings.Trim(txtDTD_ID.Text)
            Simple.CCT_ID = Strings.Trim(txtCCT_ID.Text)
            Simple.TCL_SERIE = Strings.Trim(txtTCL_SERIE.Text)
            Simple.TCL_NUMERO = Strings.Trim(txtTCL_NUMERO.Text)
            Simple.TCL_FECHA_EMI = dtpTCL_FECHA_EMI.Value
            Simple.PER_ID_CLI = Strings.Trim(txtPER_ID_CLI.Text)
            Simple.MON_ID = Strings.Trim(txtMON_ID.Text)
            Simple.TCL_MONTO = CDbl(txtTCL_MONTO.Text)
            Simple.USU_ID = SessionService.UserId
            Simple.TCL_FEC_GRAB = Now
            Simple.TCL_ESTADO = DevolverTiposCampos(chkTCL_ESTADO)
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkTCL_ESTADO"
                    Simple.CampoId = EchkTCL_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Simple.DevolverTiposCampos()
        End Function
        Private Function DevolverTiposCampos(ByVal oNombreCampo As String, ByVal oTexto As String, ByVal oOrm As Object) As String
            oOrm.CampoId = oNombreCampo
            oOrm.Dato = oTexto
            DevolverTiposCampos = oOrm.DevolverTiposCampos(oOrm)
        End Function
        Private Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Simple.ColocarErrores(txtTDO_ID, Simple.VerificarDatos("TDO_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtDTD_ID, Simple.VerificarDatos("DTD_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtCCT_ID, Simple.VerificarDatos("CCT_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtTCL_SERIE, Simple.VerificarDatos("TCL_SERIE"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtTCL_NUMERO, Simple.VerificarDatos("TCL_NUMERO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(dtpTCL_FECHA_EMI, Simple.VerificarDatos("TCL_FECHA_EMI"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtPER_ID_CLI, Simple.VerificarDatos("PER_ID_CLI"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtMON_ID, Simple.VerificarDatos("MON_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtTCL_MONTO, Simple.VerificarDatos("TCL_MONTO"), ErrorProvider1)

                    resp.rM = Simple.ColocarErrores(pnCuerpo, Simple.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(btnImagen, Simple.VerificarDatos("TCL_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkTCL_ESTADO, Simple.VerificarDatos("TCL_ESTADO"), ErrorProvider1)
            End Select
            Return vrO
        End Function
        Private Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0

            vRespuestaLocal = IBCTesoreriaCobranzaLegal.spInsertarRegistro(Simple.TDO_ID, Simple.DTD_ID, Simple.CCT_ID, Simple.TCL_SERIE, Simple.TCL_NUMERO, Simple.TCL_FECHA_EMI, Simple.PER_ID_CLI, Simple.MON_ID, Simple.TCL_MONTO, Simple.USU_ID, Simple.TCL_FEC_GRAB, Simple.TCL_ESTADO)

            If vRespuestaLocal = 0 Then
                InsertarDatos = False
                Return InsertarDatos
            End If

            InsertarDatos = (vRespuestaLocal > 0)
        End Function
        Private Function Modificar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Modificar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                Using Scope As New System.Transactions.TransactionScope()
                    If (ActualizarDatos()) Then
                        Scope.Complete()
                        Modificar = True
                        MsgBox("Registro modificado", MsgBoxStyle.Information, Me.Text)
                    Else
                        Scope.Dispose()
                        MsgBox("No se pudo modificar verifique sus datos :" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
                    End If
                End Using
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean
            Dim vEliminarRegistroKardexCtaCte As Integer
            vEliminarRegistroKardexCtaCte = EliminarKardexCtaCteLegal(vItemKardexCtaCteLegal)
            ActualizarDatos = (Me.IBCTesoreriaCobranzaLegal.spActualizarRegistro(Simple.TDO_ID, Simple.DTD_ID, Simple.CCT_ID, Simple.TCL_SERIE, Simple.TCL_NUMERO, Simple.TCL_FECHA_EMI, Simple.PER_ID_CLI, Simple.MON_ID, Simple.TCL_MONTO, Simple.USU_ID, Simple.TCL_FEC_GRAB, Simple.TCL_ESTADO) > 0 And vEliminarRegistroKardexCtaCte = 1)
        End Function

        Private Function EliminarKardexCtaCteLegal(ByVal vItem As Integer)
            EliminarKardexCtaCteLegal = 0
            If vItem < 1 Then
                EliminarKardexCtaCteLegal = 1
            Else
                For fila = 1 To vItem
                    EliminarKardexCtaCteLegal = Me.IBCKardexCtaCte.spEliminarRegistroLegal(fila, Simple.TDO_ID & Simple.DTD_ID & Simple.TCL_SERIE & Simple.TCL_NUMERO, Simple.PER_ID_CLI)
                    If EliminarKardexCtaCteLegal = 0 Then
                        Exit For
                    End If
                Next
            End If
            Return EliminarKardexCtaCteLegal
        End Function

        Public Sub InicializarDatos()
            OrmBusquedaDatos("InicializarDatos")
            pRegistroNuevo = False
            pColeccionDatos = RevisarDatosForm(Nothing, False)

            lblPER_ID_CLIx.Visible = False
            txtPER_ID_CLIx.Visible = False
            txtPER_DESCRIPCION_CLIx.Visible = False

            lblDTD_IDx.Visible = False
            txtDTD_IDx.Visible = False
        End Sub

        Private Function EliminarRegistro() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            Dim vMensajeMostrar As Int16 = 0

            vItemKardexCtaCteLegal = Me.IBCKardexCtaCte.ItemKardexCtaCteLegal(txtTDO_ID.Text, txtDTD_ID.Text, txtTCL_SERIE.Text, txtTCL_NUMERO.Text, txtPER_ID_CLI.Text)

            Using Scope As New System.Transactions.TransactionScope()
                Dim vEliminarRegistroKardexCtaCte As Integer

                vEliminarRegistroKardexCtaCte = EliminarKardexCtaCteLegal(vItemKardexCtaCteLegal)

                If (Me.IBCTesoreriaCobranzaLegal.spEliminarRegistro(Simple.TDO_ID, Simple.DTD_ID, Simple.TCL_SERIE, Simple.TCL_NUMERO, Simple.PER_ID_CLI) > 0 And vEliminarRegistroKardexCtaCte = 1) Then
                    Scope.Complete()
                    EliminarRegistro = True
                    vMensajeMostrar = 0
                    MsgBox("Registro eliminado", MsgBoxStyle.Information, Me.Text)
                Else
                    Scope.Dispose()
                    EliminarRegistro = False
                    vMensajeMostrar = 2
                    MsgBox("No se pudo eliminar verifique sus datos", MsgBoxStyle.Information, Me.Text)
                End If
            End Using
            Me.Cursor = Windows.Forms.Cursors.Default
            Return EliminarRegistro
        End Function

        Private Sub AdicionarFilasGrid()
        End Sub

        Private Sub EliminarFilasGrid()
        End Sub

        Private Sub NavegarFormulario(ByVal Metodo As String)
            Try
                If pnCuerpo.Enabled = True Then If RevisarDatos(False) Then Return
                Dim vCodigoId As String
                Dim resp As String = ""
                OrmBusquedaDatos("NavegarFormulario")
                Select Case Metodo
                    Case "PrimerRegistro"
                        resp = Me.IBCBusqueda.PrimerRegistroFiltro("cast(" & Simple.CampoPrincipal & " as varchar) + " & _
                                                                   "cast(" & Simple.CampoPrincipalSecundario & " as varchar) + " & _
                                                                   "cast(" & Simple.CampoPrincipalTercero & " as varchar)", _
                                                                   Simple.cTabla.NombreVista, Simple.CadenaFiltrado)
                    Case "RegistroAnterior"
                        Simple.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroAnteriorFiltro("cast(" & Simple.CampoPrincipal & " as varchar) + " & _
                                                                     "cast(" & Simple.CampoPrincipalSecundario & " as varchar) + " & _
                                                                     "cast(" & Simple.CampoPrincipalTercero & " as varchar)", _
                                                                     Simple.CampoPrincipalValor, _
                                                                     Simple.cTabla.NombreVista, Simple.CadenaFiltrado)
                    Case "RegistroSiguiente"
                        Simple.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroSiguienteFiltro("cast(" & Simple.CampoPrincipal & " as varchar) + " & _
                                                                      "cast(" & Simple.CampoPrincipalSecundario & " as varchar) + " & _
                                                                      "cast(" & Simple.CampoPrincipalTercero & " as varchar)", _
                                                                      Simple.CampoPrincipalValor, _
                                                                      Simple.cTabla.NombreVista, Simple.CadenaFiltrado)
                    Case "UltimoRegistro"
                        resp = Me.IBCBusqueda.UltimoRegistroFiltro("cast(" & Simple.CampoPrincipal & " as varchar) + " & _
                                                                   "cast(" & Simple.CampoPrincipalSecundario & " as varchar) + " & _
                                                                   "cast(" & Simple.CampoPrincipalTercero & " as varchar)", _
                                                                   Simple.cTabla.NombreVista, Simple.CadenaFiltrado)
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
                    OkBusqueda = False
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
                    OkBusqueda = False
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
                    OkBusqueda = False
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
                    OkBusqueda = True
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
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtDTD_IDx" Then EtxtDTD_IDx.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLIx" Then EtxtPER_ID_CLIx.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtDTD_IDx" Then EtxtDTD_IDx.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtPER_ID_CLIx" Then EtxtPER_ID_CLIx.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
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
                AdicionarElementoCombosEdicion()
                ComportamientoFormulario()

                If Comportamiento = -1 Then BusquedaDatos("Load")

                FormatearCampos(txtDTD_ID, "DTD_ID")
                FormatearCampos(txtCCT_ID, "CCT_ID")
                FormatearCampos(txtDTD_IDx, "DTD_IDx")

                If pComportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load")
            End Try
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

        Private Sub ConfigurarCheck()
            EchkTCL_ESTADO.pFormatearTexto = True
            EchkTCL_ESTADO.pNombreCampo = "TCL_ESTADO"
            EchkTCL_ESTADO.pSimple = Simple
            EchkTCL_ESTADO.pValorDefault = CheckState.Checked
            EchkTCL_ESTADO.vEstado0 = ""
            EchkTCL_ESTADO.vEstado1 = ""
            EchkTCL_ESTADO.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkTCL_ESTADO)
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
                Case "TCL_ESTADO"
                    With chkTCL_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTexto(EchkTCL_ESTADO)
        End Sub
        Private Sub ConfigurarText()
            EtxtPER_ID_CLIx.pTexto1 = ""
            EtxtPER_ID_CLIx.pTexto2 = ""
            EtxtPER_ID_CLIx.pSoloNumerosDecimales = False
            EtxtPER_ID_CLIx.pSoloNumeros = False
            EtxtPER_ID_CLIx.pNegativos = False
            EtxtPER_ID_CLIx.pParteEntera = 0
            EtxtPER_ID_CLIx.pParteDecimal = 0
            EtxtPER_ID_CLIx.pMinusculaMayuscula = True
            EtxtPER_ID_CLIx.pBusqueda = True
            EtxtPER_ID_CLIx.pCadenaFiltrado = ""

            EtxtPER_ID_CLIx.pOOrm = Nothing
            EtxtPER_ID_CLIx.pFormularioConsulta = Nothing

            EtxtPER_ID_CLIx.pComportamiento = Nothing
            EtxtPER_ID_CLIx.pOrdenBusqueda = 0

            EtxtDTD_IDx.pTexto1 = ""
            EtxtDTD_IDx.pTexto2 = ""
            EtxtDTD_IDx.pSoloNumerosDecimales = False
            EtxtDTD_IDx.pSoloNumeros = False
            EtxtDTD_IDx.pNegativos = False
            EtxtDTD_IDx.pParteEntera = 0
            EtxtDTD_IDx.pParteDecimal = 0
            EtxtDTD_IDx.pMinusculaMayuscula = True
            EtxtDTD_IDx.pBusqueda = True
            EtxtDTD_IDx.pCadenaFiltrado = ""

            EtxtDTD_IDx.pOOrm = Nothing
            EtxtDTD_IDx.pFormularioConsulta = Nothing

            EtxtDTD_IDx.pComportamiento = Nothing
            EtxtDTD_IDx.pOrdenBusqueda = 0

        End Sub
        Private Sub AdicionarElementoCombosEdicion()
        End Sub
        Private Sub ComportamientoFormulario()
            If pComportamiento <> -1 Then
                NombresFormulariosControles()
            End If
            pLoaded = False
        End Sub
        Private Sub NombresFormulariosControles()
            EtxtPER_ID_CLIx.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID_CLIx.pComportamiento = 2
            EtxtPER_ID_CLIx.pOrdenBusqueda = 4
            EtxtPER_ID_CLIx.pOOrm.CadenaFiltrado = " And per_cliente='SI' "

            EtxtDTD_IDx.pOOrm = New Ladisac.BE.SaldosKardexDocumentos
            EtxtDTD_IDx.pComportamiento = 3
            EtxtDTD_IDx.pOrdenBusqueda = 11
            EtxtDTD_IDx.pOOrm.pBuscarRegistros = False
            EtxtDTD_IDx.pOOrm.Vista = "spSaldoDocumentoMontoNoCero"
            EtxtDTD_IDx.pMostrarDatosGrid = True
        End Sub
        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            Dim vTCL_Monto As Decimal
            Select Case vComportamiento
                Case 2 ' Cliente
                    EtxtDTD_IDx.pOOrm.CadenaFiltrado = " And PER_ID_CLI Like '" & txtPER_ID_CLIx.Text & "' And CCT_ID_REF Like '" & BCVariablesNames.CCT_ID.CxCComerciales & "'"
            End Select
            vTCL_Monto = CDbl(txtTCL_MONTO.Text)
            txtTCL_MONTO.Text = Format(vTCL_Monto, "##,###.#0")
        End Sub
        Private Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String)
            FormatearCampos(oObjeto, NombreCampo, Simple.vArrayDatosComboBox, Simple.vElementosDatosComboBox - 1)
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

        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
           Handles txtPER_ID_CLIx.KeyDown, _
                   txtDTD_IDx.KeyDown, _
                   txtCCT_ID.KeyDown
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtPER_ID_CLIx"
                            TeclaF1(EtxtPER_ID_CLIx, txtPER_ID_CLIx)
                        Case "txtDTD_IDx"
                            If Trim(txtPER_ID_CLIx.Text) = "" Then Exit Sub
                            TeclaF1(EtxtDTD_IDx, txtDTD_IDx)
                    End Select
            End Select
        End Sub
        Private Sub TeclaF1(ByRef EtxtTemporal As txt, ByRef txt As TextBox)
            If EtxtTemporal.pBusqueda Then
                EtxtTemporal.pTexto2 = txt.Text
                ValidarDatos(EtxtTemporal, txt)
                MetodoBusquedaDato("", False, EtxtTemporal)
                EtxtTemporal.pTexto1 = txt.Text
                EtxtTemporal.pTexto2 = txt.Text
            End If
        End Sub
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

#Region "TextBox"
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID_CLIx.GotFocus, _
                txtDTD_IDx.GotFocus, _
                txtCCT_ID.GotFocus
            Select Case sender.name.ToString
                Case "txtPER_ID_CLIx"
                    EtxtPER_ID_CLIx.pTexto1 = sender.text
                Case "txtDTD_IDx"
                    EtxtDTD_IDx.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID_CLIx.LostFocus, _
                txtDTD_IDx.LostFocus, _
                txtCCT_ID.LostFocus
            Select Case sender.name.ToString
                Case "txtPER_ID_CLIx"
                    EtxtPER_ID_CLIx.pTexto2 = sender.text
                Case "txtDTD_IDx"
                    EtxtDTD_IDx.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID_CLIx.Validated, _
                txtDTD_IDx.Validated, _
                txtCCT_ID.Validated
            Select Case sender.name.ToString
                Case "txtPER_ID_CLIx"
                    txtPER_ID_CLIx.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID_CLIx.Text, txtPER_ID_CLIx.MaxLength)
                    ValidarDatos(EtxtPER_ID_CLIx, txtPER_ID_CLIx)
                Case "txtDTD_IDx"
                    ValidarDatos(EtxtDTD_IDx, txtDTD_ID)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtPER_ID_CLIx.KeyPress, _
                txtDTD_IDx.KeyPress, _
                txtCCT_ID.KeyPress
            Select Case sender.name.ToString
                Case "txtPER_ID_CLIx"
                    oKeyPress(EtxtPER_ID_CLIx, e)
                Case "txtDTD_IDx"
                    oKeyPress(EtxtDTD_IDx, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID_CLIx.DoubleClick, _
                txtDTD_IDx.DoubleClick, _
                txtCCT_ID.DoubleClick
            Select Case sender.name.ToString
                Case "txtPER_ID_CLIx"
                    oDoubleClick(EtxtPER_ID_CLIx, txtPER_ID_CLIx, "frmPersonas")
                Case "txtDTD_IDx"
                    ''oDoubleClick(EtxtDTD_IDx, txtDTD_ID, "frmPuntoVenta")
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
                    ''Case "frmCajaCtaCte"
                    ''    frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Tesoreria.Views.frmCajaCtaCte)()
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

        Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles chkTCL_ESTADO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkTCL_ESTADO"
                    If EchkTCL_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkTCL_ESTADO)
                    End If
            End Select
        End Sub

        Private Sub DataTimePcker_DropDown(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles dtpTCL_FECHA_EMI.DropDown
            VerificarDatosSession()
            Select Case sender.name
                Case "dtpTCL_FECHA_EMI"
                    If Not EdtpTCL_FECHA_EMI.pEnabled Then
                        dtpTCL_FECHA_EMI.MaxDate = dtpTCL_FECHA_EMI.Value
                        dtpTCL_FECHA_EMI.MinDate = dtpTCL_FECHA_EMI.Value
                    Else
                    End If
            End Select
        End Sub
        Private Sub VerificarDatosSession()
            EdtpTCL_FECHA_EMI.pEnabled = SessionService.ModificarFechaProcesoEnTesoreria
        End Sub

        Private Sub ConfigurarDateTimePicker()
            Dim EdtpTemporal As New dtp
            EdtpTemporal.pNombreCampo = "TCL_FECHA_EMI"
            EdtpTemporal.pEnabled = False
            EdtpTemporal.pBusqueda = False
            EdtpTemporal.pFormat = DateTimePickerFormat.Short
            EdtpTCL_FECHA_EMI = EdtpTemporal
        End Sub

        Public Structure dtp
            Public Property pNombreCampo As String
            Public Property pEnabled As Boolean
            Public Property pBusqueda As Boolean
            Public Property pFormat As System.Windows.Forms.DateTimePickerFormat
        End Structure
    End Class
End Namespace