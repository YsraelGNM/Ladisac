Imports Microsoft.Practices.Unity
Imports System.IO

Namespace Ladisac.Logistica.Views
    Public Class frmBuscar

        <Dependency()> _
        Public Property BCAlmacen As Ladisac.BL.IBCAlmacen
        <Dependency()> _
        Public Property BCArticulo As Ladisac.BL.IBCArticulo
        <Dependency()> _
        Public Property BCPersona As Ladisac.BL.IBCPersona
        <Dependency()> _
        Public Property BCOrdenTrabajo As Ladisac.BL.IBCOrdenTrabajo
        <Dependency()> _
        Public Property BCOrdenRequerimiento As Ladisac.BL.IBCOrdenRequerimiento
        <Dependency()> _
        Public Property BCOrdenCompra As Ladisac.BL.IBCOrdenCompra
        <Dependency()> _
        Public Property BCSalidaCombustible As Ladisac.BL.IBCSalidaCombustible
        <Dependency()> _
        Public Property BCUnidadesTransporte As Ladisac.BL.IBCUnidadesTransporte
        <Dependency()> _
        Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen
        <Dependency()> _
        Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento
        <Dependency()> _
        Public Property BCMarcaArticulo As Ladisac.BL.IBCMarcaArticulo
        <Dependency()> _
        Public Property BCModeloArticulo As Ladisac.BL.IBCModeloArticulo
        <Dependency()> _
        Public Property BCUnidadMedida As Ladisac.BL.IBCUnidadMedida
        <Dependency()> _
        Public Property BCTipoArticulo As Ladisac.BL.IBCTipoArticulo
        <Dependency()> _
        Public Property BCFamiliaArticulo As Ladisac.BL.IBCFamiliaArticulo
        <Dependency()> _
        Public Property BCLineaFamilia As Ladisac.BL.IBCLineaFamilia
        <Dependency()> _
        Public Property BCGrupoLineas As Ladisac.BL.IBCGrupoLineas
        <Dependency()> _
        Public Property BCEntidad As Ladisac.BL.IBCEntidad
        <Dependency()> _
        Public Property BCOrdenSalida As Ladisac.BL.IBCOrdenSalida
        <Dependency()> _
        Public Property BCDotacion As Ladisac.BL.IBCDotacion
        <Dependency()> _
        Public Property BCUbicacionAlmacen As Ladisac.BL.IBCUbicacionAlmacen
        <Dependency()> _
        Public Property BCGuiaRemision As Ladisac.BL.IBCGuiaRemision
        <Dependency()> _
        Public Property BCPlacas As Ladisac.BL.IBCPlacas
        <Dependency()> _
        Public Property BCSolicitudCompra As Ladisac.BL.IBCSolicitudCompra
        <Dependency()> _
        Public Property BCTransformacion As Ladisac.BL.IBCTransformacion
        <Dependency()> _
        Public Property BCRendicionCuenta As Ladisac.BL.IBCRendicionCuenta
        <Dependency()> _
        Public Property BCInventario As Ladisac.BL.IBCInventario
        <Dependency()> _
        Public Property BCDespachoSalida As Ladisac.BL.IBCDespachoSalida
        <Dependency()> _
        Public Property BCDespachos As Ladisac.BL.IBCDespachos
        <Dependency()> _
        Public Property BCCuadroComparativo As Ladisac.BL.IBCCuadroComparativo
        <Dependency()> _
        Public Property BCTiposBienesServicios As Ladisac.BL.IBCTiposBienesServicios
        <Dependency()> _
        Public Property BCProcesoCompra As Ladisac.BL.IBCProcesoCompra
        <Dependency()> _
        Public Property BCCuentasContables As Ladisac.BL.IBCCuentasContables
        <Dependency()> _
        Public Property BCOrdenServicio As Ladisac.BL.IBCOrdenServicio
        <Dependency()> _
        Public Property BCSolicitudSoporte As Ladisac.BL.IBCSolicitudSoporte
        <Dependency()> _
        Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
        <Dependency()> _
        Public Property BCRecepcionDocumento As Ladisac.BL.IBCRecepcionDocumento
        <Dependency()> _
        Public Property BCRendicionGastos As Ladisac.BL.IBCRendicionGastos
        <Dependency()> _
        Public Property BCCuentaRendir As Ladisac.BL.IBCCuentaRendir

        Public Property Tabla() As String
            Get
                Return mTabla
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mTabla = Nothing
                Else
                    mTabla = value
                End If
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return mTipo
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mTipo = Nothing
                Else
                    mTipo = value
                End If
            End Set
        End Property

        Public Property Tipo2() As String
            Get
                Return mTipo2
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mTipo2 = Nothing
                Else
                    mTipo2 = value
                End If
            End Set
        End Property

        Public Property Art_Id() As String
            Get
                Return mArt_Id
            End Get
            Set(ByVal value As String)
                If value Is Nothing Then
                    mArt_Id = Nothing
                Else
                    mArt_id = value
                End If
            End Set
        End Property

        Public Property Alm_Id() As Nullable(Of Integer)
            Get
                Return mAlm_Id
            End Get
            Set(ByVal value As Nullable(Of Integer))
                If value Is Nothing Then
                    mAlm_Id = Nothing
                Else
                    mAlm_Id = value
                End If
            End Set
        End Property

        Dim Filtro As String = ""
        Dim mTabla As String
        Dim mArt_Id As String
        Dim mAlm_Id As Nullable(Of Integer)
        Dim mTipo As String
        Dim mTipo2 As String
        Dim query As String = ""

        Dim ds As New DataSet
        Dim col As Integer = 0

        '<Microsoft.Practices.Unity.InjectionConstructor()> _ 'Para decirle a unity con que constructor empezar
        'Public Sub New(ByVal mTabla As String)
        '    ' This call is required by the designer.
        '    InitializeComponent()
        '    ' Add any initialization after the InitializeComponent() call.
        '    Tabla = mTabla
        'End Sub

        Private Sub frmBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown, dgvLista.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Dispose()
            End If
        End Sub

        Private Sub frmBuscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Select Case Tabla
                Case "CuadroComparativo"
                    Me.lblTitle.Text = "Busqueda CuadroComparativo"
                    query = Me.BCCuadroComparativo.ListaCuadroComparativo
                Case "Almacen"
                    Me.lblTitle.Text = "Busqueda Almacen"
                    query = Me.BCAlmacen.ListaAlmacen()
                Case "AlmacenRendicion"
                    Me.lblTitle.Text = "Busqueda Almacen"
                    query = Me.BCAlmacen.ListaAlmacenRendicion(mArt_Id)
                Case "UbicacionAlmacen"
                    Me.lblTitle.Text = "Busqueda Ubicaciones"
                    query = Me.BCUbicacionAlmacen.ListaUbicacionAlmacen
                Case "ArticuloOT"
                    Me.lblTitle.Text = "Busqueda Articulo en O.T."
                    query = Me.BCArticulo.ListaArticuloOrdenTrabajo(Tipo, Tipo2)
                    If query = "" Then query = Me.BCArticulo.ListaArticulo
                Case "Articulo"
                    Me.lblTitle.Text = "Busqueda Articulo"
                    query = Me.BCArticulo.ListaArticulo
                Case "ArticuloServicio"
                    Me.lblTitle.Text = "Busqueda Articulo Servicio"
                    query = Me.BCArticulo.ListaArticuloServicio(Tipo)
                Case "ArticuloSucursal"
                    Me.lblTitle.Text = "Busqueda Articulo"
                    query = Me.BCArticulo.ListaArticuloSucursal(Tipo)
                Case "ArticuloMateriaPrima"
                    Me.lblTitle.Text = "Busqueda Articulo"
                    query = Me.BCArticulo.ListaArticuloMateriaPrima
                Case "ArticuloSumins"
                    Me.lblTitle.Text = "Busqueda Articulo"
                    ds = Me.BCArticulo.ListaArticuloSumins(mArt_Id)
                Case "ArticuloOTSumins"
                    Me.lblTitle.Text = "Busqueda Articulo"
                    ds = Me.BCArticulo.ListaArticuloOrdenTrabajoSumins(Tipo, Tipo2, mArt_Id)
                    If ds.Tables(0).Rows.Count = 0 Then ds = Me.BCArticulo.ListaArticuloSumins(mArt_Id)
                Case "Persona"
                    Me.lblTitle.Text = "Busqueda"
                    query = Me.BCPersona.ListaPersona(Tipo)
                Case "OrdenTrabajo"
                    Me.lblTitle.Text = "Busqueda Orden de Trabajo"
                    If Tipo = "OR" Then
                        query = Me.BCOrdenTrabajo.ListaOrdenTrabajoParaOR
                    Else
                        query = Me.BCOrdenTrabajo.ListaOrdenTrabajo
                    End If
                Case "OrdenTrabajoOR"
                    Me.lblTitle.Text = "Busqueda Orden de Trabajo"
                    ds = Me.BCOrdenTrabajo.ListaOrdenTrabajoOR(Tipo)
                Case "OrdenRequerimiento"
                    Me.lblTitle.Text = "Busqueda Orden de Requerimiento"
                    ds = Me.BCOrdenRequerimiento.ListaOrdenRequerimiento(Filtro)
                Case "OrdenRequerimientoServicio"
                    Me.lblTitle.Text = "Busqueda Orden de Requerimiento Servicio"
                    ds = Me.BCOrdenRequerimiento.ListaOrdenRequerimientoServicio(Tipo)
                Case "OrdenRequerimientoDocumentacion"
                    Me.lblTitle.Text = "Busqueda Orden de Requerimiento"
                    ds = Me.BCOrdenRequerimiento.ListaORDocumentacion(Tipo)
                Case "OrdenRequerimientoSalidaCombustible"
                    Me.lblTitle.Text = "Busqueda Orden de Requerimiento"
                    ds = Me.BCOrdenRequerimiento.ListaORSalidaCombustible(Tipo)
                Case "OrdenCompra"
                    Me.lblTitle.Text = "Busqueda Orden de Compra"
                    query = Me.BCOrdenCompra.ListaOrdenCompra
                Case "OrdenCompraID"
                    Me.lblTitle.Text = "Busqueda Orden de Compra"
                    ds = Me.BCOrdenCompra.ListaOrdenCompraID(Tipo)
                Case "OrdenServicio"
                    Me.lblTitle.Text = "Busqueda Orden de Servicio"
                    query = Me.BCOrdenServicio.ListaOrdenServicio
                Case "OrdenServicioID"
                    Me.lblTitle.Text = "Busqueda Orden de Servicio"
                    ds = Me.BCOrdenServicio.ListaOrdenServicioID(Tipo)
                Case "UnidadesTransporte"
                    Me.lblTitle.Text = "Busqueda de Unidades de Transporte"
                    query = Me.BCUnidadesTransporte.ListaUnidadesTransporte
                Case "UnidadesTransporteSalidaCombustible"
                    Me.lblTitle.Text = "Busqueda de Unidades de Transporte"
                    query = Me.BCUnidadesTransporte.ListaUnidadesTransporteSalidaCombustible(Tipo)
                Case "SalidaCombustible"
                    Me.lblTitle.Text = "Busqueda de Salida de Combustible"
                    query = Me.BCSalidaCombustible.ListaSalidaCombustible
                Case "ArticuloAlmacen"
                    Me.lblTitle.Text = "Busqueda Articulo por Almacen"
                    query = Me.BCArticuloAlmacen.ListaArticuloAlmacen(Art_Id, Alm_Id)
                Case "ArticuloAlmacenPermitido"
                    Me.lblTitle.Text = "Busqueda Articulo por Almacen Permitido"
                    query = Me.BCArticuloAlmacen.ListaArticuloAlmacenPermitido(Art_Id, Alm_Id)
                Case "DocuMovimiento"
                    Me.lblTitle.Text = "Busqueda de Documento"
                    ds = Me.BCDocuMovimiento.ListaDocuMovimiento(Filtro)
                Case "MarcaArticulo"
                    Me.lblTitle.Text = "Busqueda de Marcas"
                    query = Me.BCMarcaArticulo.ListaMarcaArticulo
                Case "ModeloArticulo"
                    Me.lblTitle.Text = "Busqueda de Modelos"
                    query = Me.BCModeloArticulo.ListaModeloArticulo
                Case "UnidadMedida"
                    Me.lblTitle.Text = "Busqueda de Unidades de Medida"
                    query = Me.BCUnidadMedida.ListaUnidadMedida
                Case "TipoArticulo"
                    Me.lblTitle.Text = "Busqueda de Tipo de Articulos"
                    query = Me.BCTipoArticulo.ListaTipoArticulo
                Case "FamiliaArticulo"
                    Me.lblTitle.Text = "Busqueda de Familia de Articulos"
                    query = Me.BCFamiliaArticulo.ListaFamiliaArticulo
                Case "LineaFamilia"
                    Me.lblTitle.Text = "Busqueda de Linea de Familia"
                    query = Me.BCLineaFamilia.ListaLineaFamilia
                Case "GrupoLineas"
                    Me.lblTitle.Text = "Busqueda de Grupo Linea"
                    query = Me.BCGrupoLineas.ListaGrupoLineas
                Case "Entidad"
                    Me.lblTitle.Text = "Busqueda de Entidades"
                    query = Me.BCEntidad.ListaEntidad
                Case "EntidadID"
                    Me.lblTitle.Text = "Busqueda de Entidades"
                    ds = Me.BCEntidad.ListaEntidadID(Tipo)
                Case "EntidadOT"
                    Me.lblTitle.Text = "Busqueda de Entidades en O.T."
                    query = Me.BCEntidad.ListaEntidadOrdenTrabajo(Tipo)
                Case "OrdenSalida"
                    Me.lblTitle.Text = "Busqueda de Orden de Salida"
                    query = Me.BCOrdenSalida.ListaOrdenSalida
                Case "Dotacion"
                    Me.lblTitle.Text = "Busqueda Dotacion"
                    query = Me.BCDotacion.ListaDotacion
                Case "ListaSalidaXReq"
                    Me.lblTitle.Text = "Busqueda de Documento Salida por Requerimiento"
                    query = Me.BCDocuMovimiento.ListaSalidaXReq
                Case "ListaSalidaXReqXDocu"
                    Me.lblTitle.Text = "Busqueda de Documento Salida por Requerimiento"
                    ds = Me.BCDocuMovimiento.ListaSalidaXReqXDocu(Tipo)
                Case "ListaIngresoXFacXDocu"
                    Me.lblTitle.Text = "Busqueda de Documento Ingreso por Factura"
                    ds = Me.BCDocuMovimiento.ListaIngresoXFacXDocu(Tipo, Tipo2)
                Case "GuiaRemision"
                    Me.lblTitle.Text = "Busqueda GuiaRemision"
                    query = Me.BCGuiaRemision.ListaGuiaRemision
                Case "Placas"
                    Me.lblTitle.Text = "Busqueda Placas"
                    query = Me.BCPlacas.ListaPlacas(Tipo)
                Case "SolicitudCompra"
                    Me.lblTitle.Text = "Busqueda Solicitud de Compra"
                    query = Me.BCSolicitudCompra.ListaSolicitudCompra
                Case "Transformacion"
                    Me.lblTitle.Text = "Busqueda Transformacion"
                    query = Me.BCTransformacion.ListaTransformacion
                Case "TransformacionID"
                    Me.lblTitle.Text = "Busqueda Transformacion"
                    ds = Me.BCTransformacion.ListaTransformacionID(Tipo)
                Case "RendicionCuenta"
                    Me.lblTitle.Text = "Busqueda Rendicion Cuenta"
                    query = Me.BCRendicionCuenta.ListaRendicionCuenta
                Case "UnidadesTransporteEmpresa"
                    Me.lblTitle.Text = "Busqueda de Unidades de Transporte"
                    query = Me.BCUnidadesTransporte.ListaUnidadesTransporteEmpresa(Tipo)
                Case "Inventario"
                    Me.lblTitle.Text = "Busqueda Inventario"
                    query = Me.BCInventario.ListaInventario
                Case "DespachoSalida"
                    Me.lblTitle.Text = "Busqueda Guia Remision Despacho"
                    query = Me.BCDespachoSalida.ListaDespacho(Tipo)
                Case "AlmacenXPuntoventa"
                    Me.lblTitle.Text = "Busqueda Almacen por Punto de Venta"
                    query = Me.BCDespachos.ListaAlmacenXPuntoventa(Tipo)
                Case "TiposBienesServicios"
                    Me.lblTitle.Text = "Busqueda"
                    query = Me.BCTiposBienesServicios.TiposBienesServiciosQuery(Nothing, Nothing)
                Case "ProcesoCompra"
                    Me.lblTitle.Text = "Busqueda Proceso Compra"
                    query = Me.BCProcesoCompra.ListaProcesoCompraCotizacion(Tipo)
                Case "CuentasContables"
                    Me.lblTitle.Text = "Busqueda Cuentas Contables"
                    query = Me.BCCuentasContables.CuentasContablesDetalleQuery(Tipo, Nothing)
                Case "SolicitudSoporte"
                    Me.lblTitle.Text = "Busqueda Solicitud de Soporte"
                    query = Me.BCSolicitudSoporte.ListaSolicitudSoporte
                Case "TipoDocumento"
                    Me.lblTitle.Text = "Busqueda Tipo Documento"
                    query = Me.BCTipoDocumento.ListaDetalleTipoDocumento
                Case "RecepcionDocumento"
                    Me.lblTitle.Text = "Busqueda Recepcion Documento"
                    query = Me.BCRecepcionDocumento.ListaRecepcionDocumento
                Case "TipoDocumentoRecepcion"
                    Me.lblTitle.Text = "Busqueda Tipo Documento Recepcion"
                    query = Me.BCTipoDocumento.ListaDetalleTipoDocumentoRecepcion
                Case "RendicionGastos"
                    Me.lblTitle.Text = "Busqueda Planilla Movilidad"
                    query = Me.BCRendicionGastos.ListaRendicionGastos
                Case "CuentaRendir"
                    Me.lblTitle.Text = "Busqueda Cuentas a Rendir"
                    query = Me.BCCuentaRendir.ListaCuentaRendir
                Case "CuentaRendirTesoreria"
                    Me.lblTitle.Text = "Busqueda Cuentas a Rendir de Tesoreria"
                    query = Me.BCCuentaRendir.CuentaRendirTesoreria
            End Select

            Try
                If query.Length > 0 Then
                    Dim rea As New StringReader(query)
                    ds.ReadXml(rea)
                    dgvLista.DataSource = ds.Tables(0)
                    Select Case Tabla
                        Case "Persona"
                            If Tipo = "Trabajador" Or Tipo = "Compras" Then
                                dgvLista.Columns(0).Visible = False
                                col = 1
                            End If
                        Case "Articulo", "ArticuloOT", "ArticuloAlmacen", "ArticuloOTSumins"
                            dgvLista.Columns(0).Visible = False
                            col = 1
                    End Select
                Else
                    Select Case Tabla
                        Case "DocuMovimiento"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "OrdenRequerimiento"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "OrdenRequerimientoServicio"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "OrdenRequerimientoDocumentacion"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "OrdenTrabajoOR"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "ArticuloOTSumins"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "ListaSalidaXReqXDocu"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "ListaIngresoXFacXDocu"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "ArticuloSumins"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "EntidadID"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "TransformacionID"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "OrdenCompraID"
                            dgvLista.DataSource = ds.Tables(0)
                        Case "OrdenRequerimientoSalidaCombustible"
                            dgvLista.DataSource = ds.Tables(0)
                        Case Else
                            dgvLista.DataSource = Nothing
                    End Select

                    Select Case Tabla
                        Case "Persona"
                            If Tipo = "Trabajador" Or Tipo = "Compras" Then
                                dgvLista.Columns(0).Visible = False
                                col = 1
                            End If
                        Case "Articulo", "ArticuloOT", "ArticuloAlmacen", "ArticuloOTSumins"
                            dgvLista.Columns(0).Visible = False
                            col = 1
                    End Select

                End If

                dgvLista.CurrentCell = dgvLista.Rows(0).Cells(col)


                Dim dsBuscar As DataSet
                dsBuscar = ds.Clone
                dgvBuscar.DataSource = dsBuscar.Tables(0)
                Dim mR As DataRow
                mR = dsBuscar.Tables(0).NewRow
                ColumnSize()
                dsBuscar.Tables(0).Rows.Add(mR)
                dgvBuscar.Focus()
            Catch ex As Exception
                dgvLista.DataSource = Nothing
            End Try
        End Sub

        Private Sub dgvLista_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellClick
            col = e.ColumnIndex
        End Sub

        Private Sub dgvLista_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLista.CellDoubleClick
            If dgvLista.RowCount > 0 Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End Sub

        Function ColumVisible(ByVal col As Integer, ByVal signo As Integer) As Integer
            Dim mCol As Integer
            If col = -1 Or col > dgvLista.Columns.Count - 1 Then
                mCol = 700
            Else
                If Not dgvLista.Columns(col).Visible Then
                    If signo = -1 Then
                        mCol = ColumVisible(col - 1, -1)
                    Else
                        mCol = ColumVisible(col + 1, 1)
                    End If
                Else
                    mCol = col
                End If
            End If
            Return mCol
        End Function


        Public Function SelectDataTable(ByVal dt As DataTable, ByVal filter As String) As DataTable
            Dim dtNew As DataTable
            Try
                dtNew = dt.Clone()
                dtNew = dt.Select(filter).CopyToDataTable
            Catch ex As Exception

            End Try
            Return dtNew
        End Function

        Private Sub dgvLista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvLista.KeyDown
            If e.KeyCode = Keys.Enter Then
                dgvLista_CellDoubleClick(Nothing, Nothing)
                e.SuppressKeyPress = True
            End If
        End Sub

        Private Sub dgvLista_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvLista.CurrentCellChanged
            Try
                If dgvLista.CurrentRow.Cells("Ruta").Value.ToString.Length > 0 Then
                    lblView.Text = dgvLista.CurrentRow.Cells("Ruta").Value
                End If
            Catch ex As Exception
            End Try
        End Sub




        'PARA BUSCAR EN GRILLA
        Sub ColumnSize()
            If Not dgvLista.Rows.Count > 0 Then Exit Sub
            For Each mCol As DataGridViewColumn In dgvLista.Columns
                dgvBuscar.Columns(mCol.Index).Width = mCol.Width
                dgvBuscar.Columns(mCol.Index).Visible = mCol.Visible
            Next
        End Sub

        Private Sub dgvBuscar_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBuscar.CellEndEdit

        End Sub

        Private Sub dgvBuscar_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBuscar.CellEnter
            If dgvBuscar.Columns(e.ColumnIndex).Visible = False Then Exit Sub
            col = e.ColumnIndex
            If dgvLista.Rows.Count > 0 Then dgvLista.CurrentCell = dgvLista.CurrentRow.Cells(col)
        End Sub

        Private Sub dgvBuscar_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvBuscar.EditingControlShowing
            RemoveHandler e.Control.TextChanged, AddressOf CellTextChanged
            RemoveHandler e.Control.KeyDown, AddressOf CellKeyDown
            AddHandler e.Control.TextChanged, AddressOf CellTextChanged
            AddHandler e.Control.KeyDown, AddressOf CellKeyDown
        End Sub

        Private Sub CellTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim txt As DataGridViewTextBoxEditingControl
            txt = DirectCast(sender, DataGridViewTextBoxEditingControl)

            Dim txtActivo() As String = txt.Text.Split("%")


            If txt.Focused Then
                If col = -1 Then col = 0
                Filtro = ""
                For Cont As Integer = 0 To dgvBuscar.Columns.Count - 1
                    For Idx As Integer = 0 To txtActivo.Count - 1
                        Filtro = Filtro & "((ISNULL(" & dgvLista.Columns(Cont).Name & ",'') like '%" & IIf(Cont = col, txtActivo(Idx).ToString, dgvBuscar.CurrentRow.Cells(Cont).Value & "") & "%'))"
                        If Cont < (dgvBuscar.Columns.Count - 1) Or Idx < (txtActivo.Count - 1) Then Filtro = Filtro & " AND "
                    Next
                Next

                dgvLista.DataSource = SelectDataTable(CType(dgvLista.DataSource, DataTable), Filtro)

                Dim VerifContenido As String = ""
                For Cont As Integer = 0 To dgvBuscar.Columns.Count - 1
                    VerifContenido = VerifContenido & dgvBuscar.Rows(0).Cells(Cont).Value
                Next
                If (VerifContenido & txt.Text) = "" Then dgvLista.DataSource = ds.Tables(0)

                If dgvLista.Rows.Count > 0 Then dgvLista.CurrentCell = dgvLista.Rows(0).Cells(col)
                ColumnSize()
            End If
        End Sub

        Private Sub CellKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.KeyCode = Keys.Back Then
                dgvLista.DataSource = ds.Tables(0)
            End If
        End Sub

        Private Sub dgvBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvBuscar.KeyDown
            If col = -1 Then col = 0
            If e.KeyCode = Keys.Down Then
                If dgvLista.Rows.Count > 0 Then If dgvLista.CurrentRow.Index < dgvLista.Rows.Count - 1 Then If dgvLista.Columns(col).Visible Then dgvLista.CurrentCell = dgvLista.Rows(dgvLista.CurrentRow.Index + 1).Cells(col)
            ElseIf e.KeyCode = Keys.Up Then
                If dgvLista.Rows.Count > 0 Then If dgvLista.CurrentRow.Index > 0 Then If dgvLista.Columns(col).Visible Then dgvLista.CurrentCell = dgvLista.Rows(dgvLista.CurrentRow.Index - 1).Cells(col)
            ElseIf e.KeyCode = Keys.Enter Then
                If dgvLista.Rows.Count > 0 Then
                    dgvLista_CellDoubleClick(Nothing, Nothing)
                Else
                    btnBuscar_Click(Nothing, Nothing)
                End If
            ElseIf e.KeyCode = Keys.Left Then
                If ColumVisible(col - 1, -1) <> 700 Then
                    col = ColumVisible(col - 1, -1)
                    If dgvLista.Rows.Count > 0 Then dgvLista.CurrentCell = dgvLista.CurrentRow.Cells(col)
                End If
            ElseIf e.KeyCode = Keys.Right Then
                If ColumVisible(col + 1, 1) <> 700 Then
                    col = ColumVisible(col + 1, 1)
                    If dgvLista.Rows.Count > 0 Then dgvLista.CurrentCell = dgvLista.CurrentRow.Cells(col)
                End If
            ElseIf e.KeyCode = Keys.Back Then
                dgvBuscar.BeginEdit(True)
            End If
        End Sub

        Private Sub dgvBuscar_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvBuscar.Sorted
            dgvLista.Sort(dgvLista.Columns(dgvBuscar.CurrentCell.ColumnIndex), dgvBuscar.SortOrder - 1)
            'dgvLista.Sort(New CDataGridViewComparer(dgvBuscar.CurrentCell.ColumnIndex, dgvBuscar.SortOrder - 1))
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
            frmBuscar_Load(Nothing, Nothing)
        End Sub

        Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
            Dim Her As New Herramientas
            Her.excelExportar(Her.ToTable(dgvLista, "lista"))
        End Sub
    End Class
End Namespace
