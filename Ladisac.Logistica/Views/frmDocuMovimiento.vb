Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmDocuMovimiento

    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
    <Dependency()> _
    Public Property BCMoneda As Ladisac.BL.IBCMoneda
    <Dependency()> _
    Public Property BCOrdenRequerimiento As Ladisac.BL.IBCOrdenRequerimiento
    <Dependency()> _
    Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen
    <Dependency()> _
    Public Property BCOrdenCompra As Ladisac.BL.IBCOrdenCompra
    <Dependency()> _
    Public Property BCTransformacion As Ladisac.BL.IBCTransformacion
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property BCOrdenTrabajo As Ladisac.BL.IBCOrdenTrabajo
    <Dependency()> _
    Public Property BCProcesoCompra As Ladisac.BL.IBCProcesoCompra
    <Dependency()> _
    Public Property BCParametro As Ladisac.BL.IBCParametro
    <Dependency()>
    Public Property BCPermisoUsuario As Ladisac.BL.BCPermisoUsuario
    <Dependency()>
    Public Property BCAlmacen As Ladisac.BL.IBCAlmacen

    Public mDocu As DocuMovimiento
    Protected mOR As OrdenRequerimiento
    Protected mArticuloAlmacen As ArticuloAlmacen
    Protected mOC As OrdenCompra
    Protected mTF As Transformacion

    'Para impresion
    Dim mNuevaPag As Integer
    Dim mIndexItem As Integer
    Dim mCantLinea As Integer
    Dim mPrintAlma As Integer

    'para permiso de modificacion
    Dim FlagPermisoModificacion As Boolean = False
    Dim frmInputBox As New frmInputBox

    Private Sub frmDocuMovimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarTipoDocumento()
        CargarMoneda()
        LimpiarControles()
        'txtIGV.Text = SessionServer.IGV
        'txtTipoCambio.Text = SessionServer.TC

        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.---------    1->tipo textbox     2->combo

        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 18
        cboTipoDocumento.TabIndex = 1
        txtSerie.TabIndex = 2
        txtNumero.TabIndex = 3
        dtpFechaDoc.TabIndex = 4
        txtNroServ.TabIndex = 5
        txtOR.TabIndex = 6
        'txtAlmacenDestino.TabIndex = 7
        txtOC.TabIndex = 8
        txtSC.TabIndex = 9
        dtpFecha.TabIndex = 10
        txtProveedor.TabIndex = 11
        cboMoneda.TabIndex = 12
        chkAfectaKardex.TabIndex = 13
        txtTFO.TabIndex = 14
        txtIGV.TabIndex = 15
        numTipoCambio.TabIndex = 16
        dgvDetalle.TabIndex = 17

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mDocu = Nothing
        mOC = Nothing
        mOR = Nothing
        mTF = Nothing
        txtCodigo.Text = String.Empty
        cboTipoDocumento.SelectedIndex = -1
        cboTipoDocumento.Tag = Nothing
        txtSerie.Text = String.Empty
        txtNumero.Text = String.Empty
        cboTipoDocumentoREF.SelectedIndex = -1
        cboTipoDocumentoREF.Tag = Nothing
        txtSerieREF.Text = String.Empty
        txtNumeroREF.Text = String.Empty
        txtNroServ.Text = String.Empty
        dtpFechaDoc.Value = Today
        txtOR.Text = String.Empty
        txtOC.Text = String.Empty
        txtSC.Text = String.Empty
        dtpFecha.Value = Today
        txtProveedor.Text = String.Empty
        txtProveedor.Tag = Nothing
        cboMoneda.SelectedIndex = -1
        chkAfectaKardex.Checked = True
        txtIGV.Text = SessionServer.IGV
        txtTFO.Text = String.Empty
        numTipoCambio.Value = 0
        dgvDetalle.Rows.Clear()

        '--------------------------
        Error_validacion.Clear()
    End Sub

    Sub CargarTipoDocumento()
        Dim ds As New DataSet
        Dim query = BCTipoDocumento.ListaDetalleTipoDocumento
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        cboTipoDocumento.DisplayMember = "DTD_DESCRIPCION"
        cboTipoDocumento.ValueMember = "Codigo"
        cboTipoDocumento.SelectedIndex = -1
        cboTipoDocumento.DataSource = ds.Tables("DetalleTipoDocumento")

        Dim dt As DataTable = ds.Tables("DetalleTipoDocumento").Clone
        For Each mItem As DataRow In ds.Tables("DetalleTipoDocumento").Rows
            dt.ImportRow(mItem)
        Next
        cboTipoDocumentoREF.DisplayMember = "DTD_DESCRIPCION"
        cboTipoDocumentoREF.ValueMember = "Codigo"
        cboTipoDocumentoREF.SelectedIndex = -1
        cboTipoDocumentoREF.DataSource = dt
    End Sub

    Sub CargarMoneda()
        Dim ds As New DataSet
        Dim query = BCMoneda.ListaMoneda
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboMoneda
            .DisplayMember = "MON_Simbolo"
            .ValueMember = "MON_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Sub CargarArticuloAlmacen(ByVal ARA_Id As Integer)
        mArticuloAlmacen = BCArticuloAlmacen.ArticuloAlmacenGetById(ARA_Id)
    End Sub

    Private Sub txtProveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProveedor.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtProveedor.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
        If dgvDetalle.CurrentCell.ColumnIndex > -1 Then
            If dgvDetalle.CurrentRow.Cells(dgvDetalle.CurrentCell.ColumnIndex).OwningColumn.Name = "Comprar" Then
                If dgvDetalle.CurrentRow.Cells("ORD_ID").Tag.ToString <> "" Then
                    If MessageBox.Show("Desea agregar el articulo al Proceso de Compra?", "Atencion", MessageBoxButtons.YesNoCancel) = DialogResult.Yes Then
                        'En la UM esta ORD
                        If CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA Is Nothing Then
                            Dim Motivo As String
                            Dim Cantidad As String
                            Motivo = InputBox("Agrege motivo de la Compra", "Comentario")
                            Cantidad = InputBox("Agrege la cantidad de la Compra", "Comentario")
                            If Motivo.Length = 0 Then MessageBox.Show("No ingreso un motivo de compra. Se cancelara el proceso.", "Atencion") : Exit Sub
                            If Not IsNumeric(Cantidad) Then MessageBox.Show("No ingreso una cantidad valida de compra. Se cancelara el proceso.", "Atencion") : Exit Sub
                            CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA = "PC"
                            CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_OBS_COMPRA = Motivo
                            CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_CANTIDAD_COMPRA = Cantidad
                            CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).MarkAsModified()
                            'BCOrdenRequerimiento.MantenimientoOrdenRequerimientoDetalle(CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle))
                            BCOrdenRequerimiento.MantenimientoOrdenRequerimiento(mOR)
                            For Each mOrd In mOR.OrdenRequerimientoDetalle
                                For Each mFila In dgvDetalle.Rows
                                    If mOrd.ORD_ID = CType(mFila.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_ID Then
                                        mFila.Cells("UM").Tag = mOrd
                                    End If
                                Next
                            Next
                        Else
                            MessageBox.Show("El articulo ya esta en el Proceso de Compra", "Atencion")
                        End If
                    End If
                End If
            End If
        End If
        Totales()
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case CType(sender, DataGridView).Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "ART_Id"
                frm.Tabla = "Articulo"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value 'Codigo + ART_Descripcion
                    dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnidadMedida
                End If
            Case "ALM_ID"
                frm.Tabla = "ArticuloAlmacenPermitido"
                frm.Art_Id = dgvDetalle.CurrentRow.Cells("ART_ID").Tag
                frm.Alm_Id = Nothing
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    CargarArticuloAlmacen(frm.dgvLista.CurrentRow.Cells(0).Value)
                    If mArticuloAlmacen.ALM_ID = dgvDetalle.CurrentRow.Cells("ALM_ID_DESTINO").Tag Then
                        dgvDetalle.CurrentCell.Tag = Nothing
                        dgvDetalle.CurrentCell.Value = String.Empty
                        dgvDetalle.CurrentRow.Cells("Stock").Value = 0
                        Exit Sub
                    End If
                    dgvDetalle.CurrentCell.Tag = mArticuloAlmacen.ALM_ID  'ALM_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion
                    dgvDetalle.CurrentRow.Cells("Stock").Value = frm.dgvLista.CurrentRow.Cells(5).Value  'Stock
                    If CType(cboTipoDocumento.Tag, DetalleTipoDocumentos).DTD_E_S_ALMA = 2 Or CType(cboTipoDocumento.Tag, DetalleTipoDocumentos).DTD_ID = "057" Then 'Cuando es OR, Devolucion
                        dgvDetalle.CurrentRow.Cells("PU").Value = frm.dgvLista.CurrentRow.Cells(6).Value  'Precio Unitario
                        dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells("PU")
                        dgvDetalle_CellEndEdit(dgvDetalle, e)

                        If Not dgvDetalle.CurrentRow.Cells("UM").Tag Is Nothing Then 'Es un requerimiento
                            If dgvDetalle.CurrentRow.Cells("ALM_ID").Tag = BCParametro.ParametroGetById("AlmSum").PAR_VALOR1 Or dgvDetalle.CurrentRow.Cells("ALM_ID").Tag = BCParametro.ParametroGetById("AlmAct").PAR_VALOR1 Then 'Reemplzar con parametro
                                If CDbl(dgvDetalle.CurrentRow.Cells("Stock").Value) - CDbl(dgvDetalle.CurrentRow.Cells("Cantidad").Value) <= 0 Then
                                    If MessageBox.Show("Desea agregar el articulo al Proceso de Compra?", "Atencion", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                                        If CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA Is Nothing Then
                                            'En la UM esta ORD
                                            Dim Motivo As String
                                            Dim Cantidad As String
                                            Motivo = InputBox("Agrege motivo de la Compra", "Comentario")
                                            Cantidad = InputBox("Agrege la cantidad de la Compra", "Comentario")
                                            If Motivo.Length = 0 Then MessageBox.Show("No ingreso un motivo de compra. Se cancelara el proceso.", "Atencion") : Exit Sub
                                            If Not IsNumeric(Cantidad) Then MessageBox.Show("No ingreso una cantidad valida de compra. Se cancelara el proceso.", "Atencion") : Exit Sub
                                            CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA = "PC"
                                            CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_OBS_COMPRA = Motivo
                                            CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_CANTIDAD_COMPRA = Cantidad
                                            CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).MarkAsModified()
                                            'BCOrdenRequerimiento.MantenimientoOrdenRequerimientoDetalle(CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle))
                                            BCOrdenRequerimiento.MantenimientoOrdenRequerimiento(mOR)
                                            For Each mOrd In mOR.OrdenRequerimientoDetalle
                                                For Each mFila In dgvDetalle.Rows
                                                    If mOrd.ORD_ID = CType(mFila.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_ID Then
                                                        mFila.Cells("UM").Tag = mOrd
                                                    End If
                                                Next
                                            Next
                                        Else
                                            MessageBox.Show("El articulo ya esta en el Proceso de Compra", "Atencion")
                                        End If
                                    End If
                                    dgvDetalle.CurrentRow.Cells("Cantidad").Value = dgvDetalle.CurrentRow.Cells("Stock").Value 'Poner despues, lo quito por el imbechile del claudio
                                    If dgvDetalle.CurrentRow.Cells("Cantidad").Value <= 0 Then
                                        dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow)
                                        If dgvDetalle.Rows.Count > 0 Then dgvDetalle.CurrentCell = dgvDetalle.Rows(0).Cells("Stock")
                                    End If
                                End If
                            Else
                                If Not dgvDetalle.CurrentRow.Cells("ALM_ID").Tag = BCParametro.ParametroGetById("AlmSer").PAR_VALOR1 Then
                                    If CDbl(dgvDetalle.CurrentRow.Cells("Stock").Value) - CDbl(dgvDetalle.CurrentRow.Cells("Cantidad").Value) <= 0 Then
                                        dgvDetalle.CurrentRow.Cells("Cantidad").Value = dgvDetalle.CurrentRow.Cells("Stock").Value 'lo pongo por la imbechile de la tefi
                                        If dgvDetalle.CurrentRow.Cells("Cantidad").Value <= 0 Then
                                            dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow)
                                            If dgvDetalle.Rows.Count > 0 Then dgvDetalle.CurrentCell = dgvDetalle.Rows(0).Cells("Stock")
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf frm.dgvLista.Rows.Count = 0 Then
                    frm.Tabla = "AlmacenRendicion"
                    frm.Art_Id = dgvDetalle.CurrentRow.Cells("ART_ID").Tag
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Alm_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
                    End If
                End If
            Case "DMD_ID_REF"
                If cboTipoDocumento.SelectedValue.ToString.Trim = BCParametro.ParametroGetById("Orden Devolucion").PAR_VALOR1 Or cboTipoDocumento.SelectedValue.ToString.Trim = BCParametro.ParametroGetById("Nota Credito Compras").PAR_VALOR1 Then 'Orden Devolucion 'Nota Credito Compras
                    If cboTipoDocumento.SelectedValue.ToString.Trim = BCParametro.ParametroGetById("Orden Devolucion").PAR_VALOR1 Then
                        frm.Tabla = "ListaSalidaXReqXDocu"
                    ElseIf cboTipoDocumento.SelectedValue.ToString.Trim = BCParametro.ParametroGetById("Nota Credito Compras").PAR_VALOR1 Then
                        frm.Tabla = "ListaIngresoXFacXDocu"
                    End If

                    frm.Tipo = dgvDetalle.CurrentCell.Value
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value 'DMD_Id_Ref
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value 'DMD_Id_Ref
                        Dim mDTD As String = frm.dgvLista.CurrentRow.Cells("DTD_ID").Value 'DTD_Id
                        'numTipoCambio.Value = 1

                        Dim key As Integer = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value
                        Dim mDocuDetalleRef As DocuMovimientoDetalle
                        mDocuDetalleRef = BCDocuMovimiento.DocuMovimientoDetalleGetById(key)
                        dgvDetalle.CurrentRow.Cells("Art_Id").Value = mDocuDetalleRef.Articulos.ART_Codigo & " - " & mDocuDetalleRef.Articulos.ART_DESCRIPCION
                        dgvDetalle.CurrentRow.Cells("Art_Id").Tag = mDocuDetalleRef.ART_ID
                        dgvDetalle.CurrentRow.Cells("ORD_ID").Tag = mDocuDetalleRef.ORD_ID
                        dgvDetalle.CurrentRow.Cells("Cantidad").Value = mDocuDetalleRef.DMD_CANTIDAD
                        dgvDetalle.CurrentRow.Cells("UM").Value = mDocuDetalleRef.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
                        dgvDetalle.CurrentRow.Cells("PU").Value = mDocuDetalleRef.DMD_PRECIO_UNITARIO
                        'dgvDetalle.CurrentRow.Cells("SubTotal").Value = CDbl(dgvDetalle.CurrentRow.Cells("PU").Value) * CDbl(dgvDetalle.CurrentRow.Cells("Cantidad").Value)
                        'dgvDetalle.CurrentRow.Cells("Total").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value

                        dgvDetalle.CurrentRow.Cells("SubTotal").Value = dgvDetalle.CurrentRow.Cells("PU").Value * dgvDetalle.CurrentRow.Cells("Cantidad").Value - _
                                                                    dgvDetalle.CurrentRow.Cells("PU").Value * dgvDetalle.CurrentRow.Cells("Cantidad").Value * (dgvDetalle.CurrentRow.Cells("Descuento").Value / 100)
                        dgvDetalle.CurrentRow.Cells("IGV").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value * (txtIGV.Text / 100)
                        dgvDetalle.CurrentRow.Cells("Total").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value + dgvDetalle.CurrentRow.Cells("IGV").Value




                        dgvDetalle.CurrentRow.Cells("Glosa").Value = mDocuDetalleRef.DMD_GLOSA
                        dgvDetalle.CurrentRow.Cells("ALM_Id").Value = mDocuDetalleRef.Almacen.ALM_DESCRIPCION
                        dgvDetalle.CurrentRow.Cells("ALM_Id").Tag = mDocuDetalleRef.ALM_ID

                        If mDTD = "061" Then
                            Dim mDocuDet As DocuMovimientoDetalle
                            mDocuDet = BCDocuMovimiento.DocuMovimientoDetalleGetById(mDocuDetalleRef.DMD_ID_REF)
                            dgvDetalle.CurrentRow.Cells("ALM_ID_DESTINO").Value = mDocuDet.Almacen.ALM_DESCRIPCION
                            dgvDetalle.CurrentRow.Cells("ALM_ID_DESTINO").Tag = mDocuDet.ALM_ID
                            txtOR.Text = "_"
                            dgvDetalle.CurrentRow.Cells("EsDevolucion").Value = True
                        End If

                    End If

                ElseIf cboTipoDocumento.SelectedValue.ToString.Trim = BCParametro.ParametroGetById("GuiaCompra").PAR_VALOR1 Then 'Guia Compra
                    frm.Tabla = "ListaSalidaXReqXDocu"
                    frm.Tipo = dgvDetalle.CurrentCell.Value
                    frm.Tipo2 = dgvDetalle.CurrentRow.Cells("Art_Id").Tag
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value 'DMD_Id_Ref
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value 'DMD_Id_Ref
                        numTipoCambio.Value = 1

                        Dim key As Integer = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value
                        Dim mDocuDetalleRef As DocuMovimientoDetalle
                        mDocuDetalleRef = BCDocuMovimiento.DocuMovimientoDetalleGetById(key)
                        'dgvDetalle.CurrentRow.Cells("Art_Id").Value = mDocuDetalleRef.Articulos.ART_Codigo & " - " & mDocuDetalleRef.Articulos.ART_DESCRIPCION
                        'dgvDetalle.CurrentRow.Cells("Art_Id").Tag = mDocuDetalleRef.ART_ID
                        'dgvDetalle.CurrentRow.Cells("ORD_ID").Tag = mDocuDetalleRef.ORD_ID
                        'dgvDetalle.CurrentRow.Cells("Cantidad").Value = mDocuDetalleRef.DMD_CANTIDAD
                        'dgvDetalle.CurrentRow.Cells("UM").Value = mDocuDetalleRef.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
                        dgvDetalle.CurrentRow.Cells("PU").Value = mDocuDetalleRef.DMD_CONTRAVALOR / mDocuDetalleRef.DMD_CANTIDAD
                        dgvDetalle.CurrentRow.Cells("SubTotal").Value = CDbl(dgvDetalle.CurrentRow.Cells("PU").Value) * CDbl(dgvDetalle.CurrentRow.Cells("Cantidad").Value)
                        dgvDetalle.CurrentRow.Cells("Total").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value
                        'dgvDetalle.CurrentRow.Cells("Glosa").Value = mDocuDetalleRef.DMD_GLOSA
                        'dgvDetalle.CurrentRow.Cells("ALM_Id").Value = mDocuDetalleRef.Almacen.ALM_DESCRIPCION
                        'dgvDetalle.CurrentRow.Cells("ALM_Id").Tag = mDocuDetalleRef.ALM_ID
                    End If

                End If
        End Select
        frm.Dispose()
        Totales()
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        If cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "060" And CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value = 0 Then

            Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                Case "Cantidad", "PU"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = CType(sender, DataGridView).CurrentRow.Cells("PU").Value * 1 - _
                     CType(sender, DataGridView).CurrentRow.Cells("PU").Value * 1 * (CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value * (txtIGV.Text / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value + CType(sender, DataGridView).CurrentRow.Cells("IGV").Value
                Case "Descuento"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = CType(sender, DataGridView).CurrentRow.Cells("PU").Value * 1 - _
                     CType(sender, DataGridView).CurrentRow.Cells("PU").Value * 1 * (CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value * (txtIGV.Text / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value + CType(sender, DataGridView).CurrentRow.Cells("IGV").Value
                Case "SubTotal"
                    CType(sender, DataGridView).CurrentRow.Cells("PU").Value = (CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value / (1 - (CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value / 100))) / 1
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value * (txtIGV.Text / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value + CType(sender, DataGridView).CurrentRow.Cells("IGV").Value
                Case "Total"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = CType(sender, DataGridView).CurrentRow.Cells("Total").Value / (((txtIGV.Text / 100)) + 1)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value * (txtIGV.Text / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("PU").Value = (CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value / (1 - (CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value / 100))) / 1
            End Select


        Else


            Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                Case "Cantidad", "PU"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = CType(sender, DataGridView).CurrentRow.Cells("PU").Value * CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value - _
                     CType(sender, DataGridView).CurrentRow.Cells("PU").Value * CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value * (CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value * (txtIGV.Text / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value + CType(sender, DataGridView).CurrentRow.Cells("IGV").Value
                Case "Descuento"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = CType(sender, DataGridView).CurrentRow.Cells("PU").Value * CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value - _
                     CType(sender, DataGridView).CurrentRow.Cells("PU").Value * CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value * (CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value * (txtIGV.Text / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value + CType(sender, DataGridView).CurrentRow.Cells("IGV").Value
                Case "SubTotal"
                    CType(sender, DataGridView).CurrentRow.Cells("PU").Value = (CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value / (1 - (CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value / 100))) / CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value * (txtIGV.Text / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value + CType(sender, DataGridView).CurrentRow.Cells("IGV").Value
                Case "Total"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = CType(sender, DataGridView).CurrentRow.Cells("Total").Value / (((txtIGV.Text / 100)) + 1)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value * (txtIGV.Text / 100)
                    CType(sender, DataGridView).CurrentRow.Cells("PU").Value = (CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value / (1 - (CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value / 100))) / CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value
            End Select

        End If
        Totales()
    End Sub

    'ingreso de codigo de validacion
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------

        Dim Flag As Boolean = True
        Dim mGridCant As Integer
        If (mDocu.ChangeTracker.State = ObjectState.Modified) Or (mDocu.ChangeTracker.State = ObjectState.Deleted) Then Flag = False

        If txtOR.Text.Length > 0 Then 'Se trata de una salida, puede ser transferencia o consumo
            Dim mAlma_Destino = (From mGrid As DataGridViewRow In dgvDetalle.Rows Select mGrid.Cells("ALM_ID_DESTINO").Tag).Distinct
            For Each mAlmaDestino In mAlma_Destino.ToList
                mGridCant = (From mGrid As DataGridViewRow In dgvDetalle.Rows Where mGrid.Cells("ALM_ID_DESTINO").Tag = mAlmaDestino Select mGrid).Count

                If Flag Then
                    mDocu = New DocuMovimiento
                    mDocu.MarkAsAdded()
                End If
                

                If mDocu IsNot Nothing Then
                    dgvDetalle.EndEdit()
                    mDocu.DMO_FECHA = dtpFecha.Value
                    'Para saber que tipo de documento voy hacer cuando sea nuevo
                    If Flag Then
                        For Each mDoc In cboTipoDocumento.Items
                            If mDoc(0).ToString.Substring(0, 3) = IIf(mAlmaDestino = 0, "056", "062") Then '056 Orden Requerimiento: 062 Transferencia
                                cboTipoDocumento.SelectedItem = mDoc
                                Exit For
                            End If
                        Next
                    End If

                    mDocu.DTD_ID = cboTipoDocumento.SelectedValue.ToString.Substring(0, 3)
                    mDocu.TDO_ID = cboTipoDocumento.SelectedValue.ToString.Substring(3, 3)
                    If cboTipoDocumento.SelectedValue.ToString.Length = 9 Then mDocu.CCT_ID = cboTipoDocumento.SelectedValue.ToString.Substring(6, 3) Else mDocu.CCT_ID = ""
                    mDocu.DetalleTipoDocumentos = cboTipoDocumento.Tag
                    mDocu.DMO_SERIE = txtSerie.Text.Trim.PadLeft(4, "0")
                    mDocu.DMO_NRO = txtNumero.Text.Trim.PadLeft(10, "0")
                    mDocu.DMO_NRO_SERVICIO = txtNroServ.Text
                    mDocu.DMO_FECHA_DOCUMENTO = dtpFechaDoc.Value

                    If cboTipoDocumentoREF.Text.Length > 0 Then
                        mDocu.DTD_ID_REF = cboTipoDocumentoREF.SelectedValue.ToString.Substring(0, 3)
                        mDocu.TDO_ID_REF = cboTipoDocumentoREF.SelectedValue.ToString.Substring(3, 3)
                        If cboTipoDocumentoREF.SelectedValue.ToString.Length = 9 Then mDocu.CCT_ID_REF = cboTipoDocumentoREF.SelectedValue.ToString.Substring(6, 3) Else mDocu.CCT_ID_REF = ""
                    End If
                    mDocu.DMO_SERIE_REF = txtSerieREF.Text.Trim.PadLeft(4, "0")
                    mDocu.DMO_NRO_REF = txtNumeroREF.Text.Trim.PadLeft(10, "0")

                    If Not (txtOR.Text = "" Or txtOR.Text = "_") Then mDocu.ORR_ID = CInt(txtOR.Text)
                    If Not txtOC.Text = "" Then mDocu.OCO_ID = CInt(txtOC.Text)
                    If Not txtSC.Text = "" Then mDocu.SCO_ID = CInt(txtSC.Text)
                    If Not txtTFO.Text = "" Then mDocu.TFO_ID = CInt(txtTFO.Text)
                    'If Not txtAlmacenDestino.Text = "" Then mDocu.ALM_ID_REF = CInt(txtAlmacenDestino.Tag)
                    mDocu.PER_ID_PROVEEDOR = txtProveedor.Tag
                    mDocu.MON_ID = cboMoneda.SelectedValue
                    mDocu.DOCU_AFECTA_KARDEX = chkAfectaKardex.Checked
                    mDocu.DMO_ESTADO = True
                    mDocu.DMO_FEC_GRAB = Now
                    mDocu.USU_ID = SessionServer.UserId

                    For cont As Integer = mDocu.DocuMovimientoDetalle.Count - 1 To 0 Step -1
                        If mDocu.DocuMovimientoDetalle(cont).ChangeTracker.State = ObjectState.Added Then
                            mDocu.DocuMovimientoDetalle.RemoveAt(cont)
                        End If
                    Next

                    For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                        If mDetalle.Cells("ALM_ID_DESTINO").Tag = mAlmaDestino Then
                            If Not mDetalle.Cells("DMD_ID").Value Is Nothing Then
                                With CType(mDetalle.Cells("DMD_ID").Tag, DocuMovimientoDetalle)
                                    .ALM_ID = mDetalle.Cells("ALM_ID").Tag
                                    .ART_ID = mDetalle.Cells("ART_ID").Tag
                                    .DMD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                                    .DMD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                                    .DMD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                                    .DMD_IGV = txtIGV.Text
                                    .DMD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PU").Value)) * numTipoCambio.Value
                                    If .DMD_DESCUENTO > 0 Then
                                        .DMD_CONTRAVALOR = .DMD_CONTRAVALOR - (.DMD_CONTRAVALOR * (.DMD_DESCUENTO / 100))
                                    End If
                                    .DMD_GLOSA = mDetalle.Cells("Glosa").Value
                                    .ORD_ID = mDetalle.Cells("ORD_ID").Tag
                                    .OCD_ID = mDetalle.Cells("OCD_ID").Tag
                                    .TRD_ID = mDetalle.Cells("TRD_ID").Tag
                                    If Not mDetalle.Cells("DMD_ID_REF").Tag Is Nothing Then .DMD_ID_REF = CInt(mDetalle.Cells("DMD_ID_REF").Tag) Else .DMD_ID_REF = Nothing
                                    If Not mDetalle.Cells("ALM_ID_DESTINO").Tag Is Nothing Then .ALM_ID_TRANSFERENCIA = CInt(mDetalle.Cells("ALM_ID_DESTINO").Tag) Else .ALM_ID_TRANSFERENCIA = Nothing
                                    If Not mDetalle.Cells("EsDevolucion").Value Is Nothing Then .EsDevolucion = True Else .EsDevolucion = Nothing
                                    .MarkAsModified()
                                End With
                            ElseIf mDetalle.Cells("Total").Value IsNot Nothing And CDec(mDetalle.Cells("Total").Value) > 0 Then
                                Dim nDMD As New DocuMovimientoDetalle
                                With nDMD
                                    .DMD_ID = IIf(mDetalle.Cells("DMD_Id").Tag Is Nothing, Nothing, CInt(mDetalle.Cells("DMD_Id").Tag))
                                    .ALM_ID = CInt(mDetalle.Cells("ALM_ID").Tag)
                                    .ART_ID = mDetalle.Cells("ART_Id").Tag
                                    .DMD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                                    .DMD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                                    .DMD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                                    .DMD_IGV = txtIGV.Text
                                    .DMD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PU").Value)) * numTipoCambio.Value
                                    If .DMD_DESCUENTO > 0 Then
                                        .DMD_CONTRAVALOR = .DMD_CONTRAVALOR - (.DMD_CONTRAVALOR * (.DMD_DESCUENTO / 100))
                                    End If
                                    .DMD_GLOSA = mDetalle.Cells("Glosa").Value
                                    .ORD_ID = mDetalle.Cells("ORD_ID").Tag
                                    .OCD_ID = mDetalle.Cells("OCD_ID").Tag
                                    .TRD_ID = mDetalle.Cells("TRD_ID").Tag
                                    If Not mDetalle.Cells("DMD_ID_REF").Tag Is Nothing Then .DMD_ID_REF = CInt(mDetalle.Cells("DMD_ID_REF").Tag) Else .DMD_ID_REF = Nothing
                                    If Not mDetalle.Cells("ALM_ID_DESTINO").Tag Is Nothing Then .ALM_ID_TRANSFERENCIA = CInt(mDetalle.Cells("ALM_ID_DESTINO").Tag) Else .ALM_ID_TRANSFERENCIA = Nothing
                                    If Not mDetalle.Cells("EsDevolucion").Value Is Nothing Then .EsDevolucion = True Else .EsDevolucion = Nothing
                                    .MarkAsAdded()
                                End With
                                mDocu.DocuMovimientoDetalle.Add(nDMD)
                            End If
                        End If
                    Next

                    If Not validar_detalle(mGridCant) Then Exit Sub

                    If BCDocuMovimiento.MantenimientoDocuMovimiento(mDocu) = 1 Then
                        MessageBox.Show(mDocu.DMO_ID)
                        mDocu = BCDocuMovimiento.DocuMovimientoGetById(mDocu.DMO_ID)
                        OnReportes()
                    Else
                        MessageBox.Show("Error al insertar.")
                        LimpiarControles()
                        Exit Sub
                    End If
                End If
            Next
            LimpiarControles()


        Else 'Aqui es para los demas documentos

            If mDocu IsNot Nothing Then
                dgvDetalle.EndEdit()
                mDocu.DMO_FECHA = dtpFecha.Value
                mDocu.DTD_ID = cboTipoDocumento.SelectedValue.ToString.Substring(0, 3)
                mDocu.TDO_ID = cboTipoDocumento.SelectedValue.ToString.Substring(3, 3)
                If cboTipoDocumento.SelectedValue.ToString.Length = 9 Then mDocu.CCT_ID = cboTipoDocumento.SelectedValue.ToString.Substring(6, 3) Else mDocu.CCT_ID = ""
                mDocu.DetalleTipoDocumentos = cboTipoDocumento.Tag
                mDocu.DMO_SERIE = txtSerie.Text.Trim.PadLeft(4, "0")
                mDocu.DMO_NRO = txtNumero.Text.Trim.PadLeft(10, "0")
                mDocu.DMO_NRO_SERVICIO = txtNroServ.Text
                mDocu.DMO_FECHA_DOCUMENTO = dtpFechaDoc.Value

                If cboTipoDocumentoREF.Text.Length > 0 Then
                    mDocu.DTD_ID_REF = cboTipoDocumentoREF.SelectedValue.ToString.Substring(0, 3)
                    mDocu.TDO_ID_REF = cboTipoDocumentoREF.SelectedValue.ToString.Substring(3, 3)
                    If cboTipoDocumentoREF.SelectedValue.ToString.Length = 9 Then mDocu.CCT_ID_REF = cboTipoDocumentoREF.SelectedValue.ToString.Substring(6, 3) Else mDocu.CCT_ID_REF = ""
                End If
                mDocu.DMO_SERIE_REF = txtSerieREF.Text.Trim.PadLeft(4, "0")
                mDocu.DMO_NRO_REF = txtNumeroREF.Text.Trim.PadLeft(10, "0")

                If Not txtOR.Text = "" Then mDocu.ORR_ID = CInt(txtOR.Text)
                If Not txtOC.Text = "" Then mDocu.OCO_ID = CInt(txtOC.Text)
                If Not txtSC.Text = "" Then mDocu.SCO_ID = CInt(txtSC.Text)
                If Not txtTFO.Text = "" Then mDocu.TFO_ID = CInt(txtTFO.Text)
                'If Not txtAlmacenDestino.Text = "" Then mDocu.ALM_ID_REF = CInt(txtAlmacenDestino.Tag)
                mDocu.PER_ID_PROVEEDOR = txtProveedor.Tag
                mDocu.MON_ID = cboMoneda.SelectedValue
                mDocu.DOCU_AFECTA_KARDEX = chkAfectaKardex.Checked
                mDocu.DMO_ESTADO = True
                mDocu.DMO_FEC_GRAB = Now
                mDocu.USU_ID = SessionServer.UserId

                For cont As Integer = mDocu.DocuMovimientoDetalle.Count - 1 To 0 Step -1
                    If mDocu.DocuMovimientoDetalle(cont).ChangeTracker.State = ObjectState.Added Then
                        mDocu.DocuMovimientoDetalle.RemoveAt(cont)
                    End If
                Next

                mGridCant = dgvDetalle.Rows.Count

                For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                    If Not mDetalle.Cells("DMD_ID").Value Is Nothing Then
                        With CType(mDetalle.Cells("DMD_ID").Tag, DocuMovimientoDetalle)
                            .ALM_ID = mDetalle.Cells("ALM_ID").Tag
                            .ART_ID = mDetalle.Cells("ART_ID").Tag
                            .DMD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                            .DMD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                            .DMD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                            .DMD_IGV = txtIGV.Text
                            .DMD_CONTRAVALOR = (IIf(mDocu.DTD_ID = "060" And .DMD_CANTIDAD = 0, 1, CDec(mDetalle.Cells("Cantidad").Value)) * CDec(mDetalle.Cells("PU").Value)) * numTipoCambio.Value
                            If .DMD_DESCUENTO > 0 Then
                                .DMD_CONTRAVALOR = .DMD_CONTRAVALOR - (.DMD_CONTRAVALOR * (.DMD_DESCUENTO / 100))
                            End If
                            .DMD_GLOSA = mDetalle.Cells("Glosa").Value
                            .ORD_ID = mDetalle.Cells("ORD_ID").Tag
                            .OCD_ID = mDetalle.Cells("OCD_ID").Tag
                            .TRD_ID = mDetalle.Cells("TRD_ID").Tag
                            If Not mDetalle.Cells("DMD_ID_REF").Tag Is Nothing Then .DMD_ID_REF = CInt(mDetalle.Cells("DMD_ID_REF").Tag) Else .DMD_ID_REF = Nothing
                            If Not mDetalle.Cells("ALM_ID_DESTINO").Tag Is Nothing Then .ALM_ID_TRANSFERENCIA = CInt(mDetalle.Cells("ALM_ID_DESTINO").Tag) Else .ALM_ID_TRANSFERENCIA = Nothing
                            .MarkAsModified()
                        End With
                    ElseIf mDetalle.Cells("Total").Value IsNot Nothing And CDec(mDetalle.Cells("Total").Value) > 0 Then
                        Dim nDMD As New DocuMovimientoDetalle
                        With nDMD
                            .DMD_ID = IIf(mDetalle.Cells("DMD_Id").Tag Is Nothing, Nothing, CInt(mDetalle.Cells("DMD_Id").Tag))
                            .ALM_ID = CInt(mDetalle.Cells("ALM_ID").Tag)
                            .ART_ID = mDetalle.Cells("ART_Id").Tag
                            .DMD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                            .DMD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                            .DMD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                            .DMD_IGV = txtIGV.Text
                            .DMD_CONTRAVALOR = (IIf(mDocu.DTD_ID = "060" And .DMD_CANTIDAD = 0, 1, CDec(mDetalle.Cells("Cantidad").Value)) * CDec(mDetalle.Cells("PU").Value)) * numTipoCambio.Value
                            If .DMD_DESCUENTO > 0 Then
                                .DMD_CONTRAVALOR = .DMD_CONTRAVALOR - (.DMD_CONTRAVALOR * (.DMD_DESCUENTO / 100))
                            End If
                            .DMD_GLOSA = mDetalle.Cells("Glosa").Value
                            .ORD_ID = mDetalle.Cells("ORD_ID").Tag
                            .OCD_ID = mDetalle.Cells("OCD_ID").Tag
                            .TRD_ID = mDetalle.Cells("TRD_ID").Tag
                            If Not mDetalle.Cells("DMD_ID_REF").Tag Is Nothing Then .DMD_ID_REF = CInt(mDetalle.Cells("DMD_ID_REF").Tag) Else .DMD_ID_REF = Nothing
                            If Not mDetalle.Cells("ALM_ID_DESTINO").Tag Is Nothing Then .ALM_ID_TRANSFERENCIA = CInt(mDetalle.Cells("ALM_ID_DESTINO").Tag) Else .ALM_ID_TRANSFERENCIA = Nothing
                            .MarkAsAdded()
                        End With
                        mDocu.DocuMovimientoDetalle.Add(nDMD)
                    End If
                Next

                If Not validar_detalle(mGridCant) Then Exit Sub

                If BCDocuMovimiento.MantenimientoDocuMovimiento(mDocu) = 1 Then
                    MessageBox.Show(mDocu.DMO_ID)
                    mDocu = BCDocuMovimiento.DocuMovimientoGetById(mDocu.DMO_ID)
                    OnReportes()

                    ''''''''''''''''''''''Pasar a Spring
                    If mDocu.DTD_ID = "015" And mDocu.DMO_SERIE.Contains("H") And Flag Then
                        If BCDocuMovimiento.Interfase_IngresoAlmacenProductoTerminado(mDocu.DMO_ID) = "0" Then
                            Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                        End If
                        If BCDocuMovimiento.Interfase_PasarSpring(mDocu.DMO_FECHA, "NI", mDocu.DocuMovimientoDetalle(0).Articulos.Item) = "0" Then
                            Err.Raise(&HFFFFFF01, "Error Provocado", "Error al pasar a Spring.")
                        End If
                    End If
                    ''''''''''''''''''''''''''''''''''''
                    LimpiarControles()
                Else
                    MessageBox.Show("Error al insertar.")
                    LimpiarControles()
                    Exit Sub
                End If
            End If
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mDocu = New DocuMovimiento
        mDocu.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)

        cboTipoDocumento.Focus()
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "DocuMovimiento"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarDocuMovimiento(key)
            LlenarControles()
            Totales()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManEliminar()
        MyBase.OnManEliminar()
        If mDocu IsNot Nothing Then
            If MessageBox.Show("Seguro de Eliminar el Documento?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
                For Each mItem In mDocu.DocuMovimientoDetalle
                    mItem.Alm_Ori = mItem.ALM_ID
                    mItem.Art_Ori = mItem.ART_ID
                    mItem.Kardex(0).MarkAsDeleted()
                    mItem.MarkAsDeleted()
                Next
                mDocu.MarkAsDeleted()
                If BCDocuMovimiento.MantenimientoDocuMovimiento(mDocu) = 1 Then
                    LimpiarControles()
                Else
                    MessageBox.Show("Error al eliminar.")
                    Exit Sub
                End If
            End If
        End If

        '--------------------------------------------------
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

    Sub CargarDocuMovimiento(ByVal DMO_Id As Integer)
        mDocu = BCDocuMovimiento.DocuMovimientoGetById(DMO_Id)
        For Each mFila In mDocu.DocuMovimientoDetalle
            mFila.MarkAsModified()
        Next
        mDocu.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mDocu.DMO_ID
        dtpFecha.Value = mDocu.DMO_FECHA
        mDocu.FecOri = mDocu.DMO_FECHA
        cboTipoDocumento.SelectedValue = mDocu.DTD_ID & mDocu.TDO_ID & mDocu.CCT_ID
        txtSerie.Text = mDocu.DMO_SERIE
        txtNumero.Text = mDocu.DMO_NRO
        txtNroServ.Text = mDocu.DMO_NRO_SERVICIO
        dtpFechaDoc.Value = mDocu.DMO_FECHA_DOCUMENTO

        cboTipoDocumentoREF.SelectedValue = mDocu.DTD_ID_REF & mDocu.TDO_ID_REF & mDocu.CCT_ID_REF
        txtSerieREF.Text = mDocu.DMO_SERIE_REF
        txtNumeroREF.Text = mDocu.DMO_NRO_REF

        txtOR.Text = mDocu.ORR_ID.ToString
        txtOC.Text = mDocu.OCO_ID.ToString
        txtSC.Text = mDocu.SCO_ID.ToString
        txtTFO.Text = mDocu.TFO_ID.ToString
        If Not mDocu.Personas Is Nothing Then txtProveedor.Text = mDocu.Personas.PER_APE_PAT & " " & mDocu.Personas.PER_APE_MAT
        If Not mDocu.Personas Is Nothing Then txtProveedor.Tag = mDocu.PER_ID_PROVEEDOR
        cboMoneda.SelectedValue = mDocu.MON_ID
        cboMoneda_SelectedValueChanged(Nothing, Nothing)
        chkAfectaKardex.Checked = mDocu.DOCU_AFECTA_KARDEX

        For Each mItem In mDocu.DocuMovimientoDetalle
            mItem.Alm_Ori = mItem.ALM_ID
            mItem.Art_Ori = mItem.ART_ID
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DMD_ID").Value = mItem.DMD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DMD_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Tag = mItem.ART_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem.DMD_CANTIDAD
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PU").Value = mItem.DMD_PRECIO_UNITARIO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descuento").Value = mItem.DMD_DESCUENTO

            txtIGV.Text = mItem.DMD_IGV

            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value - _
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value * (dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descuento").Value / 100)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value * (txtIGV.Text / 100)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value


            'If mItem.DMD_DESCUENTO > 0 Then
            '    'mItem.DMD_CONTRAVALOR = mItem.DMD_CONTRAVALOR - (mItem.DMD_CONTRAVALOR * (mItem.DMD_DESCUENTO / 100))
            '    If (mItem.DMD_PRECIO_UNITARIO * mItem.DMD_CANTIDAD) > 0 Then numTipoCambio.Value = (mItem.DMD_CONTRAVALOR + ((mItem.DMD_CANTIDAD * mItem.DMD_PRECIO_UNITARIO) * (mItem.DMD_DESCUENTO / 100))) / (mItem.DMD_PRECIO_UNITARIO * mItem.DMD_CANTIDAD) Else numTipoCambio.Value = 1
            'Else
            '    If (mItem.DMD_PRECIO_UNITARIO * mItem.DMD_CANTIDAD) > 0 Then numTipoCambio.Value = mItem.DMD_CONTRAVALOR / (mItem.DMD_PRECIO_UNITARIO * mItem.DMD_CANTIDAD) Else numTipoCambio.Value = 1
            'End If

            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Glosa").Value = mItem.DMD_GLOSA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_Id").Value = mItem.Almacen.ALM_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_Id").Tag = mItem.ALM_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ORD_ID").Tag = mItem.ORD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OCD_ID").Tag = mItem.OCD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TRD_ID").Tag = mItem.TRD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DMD_ID_REF").Tag = mItem.DMD_ID_REF
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DMD_ID_REF").Value = mItem.DMD_ID_REF
            'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("RCD_ID").Tag = mItem.OCD_ID 'No me acuerdo si debe cargarse esto para luego guardarlo
        Next
        '''''Para saber quien lo hizo
        Dim Hecho As Usuarios
        Hecho = BCPermisoUsuario.UsuarioGetById(mDocu.USU_ID)
        lblHecho.Text = "Hecho por: " & Hecho.USU_DESCRIPCION
    End Sub

    Private Sub txtOR_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOR.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "OrdenRequerimientoDocumentacion"
        If txtOR.Text <> "" Then frm.Tipo = txtOR.Text
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            OnManNuevo()

            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name = "tsbAgregar" Or oOpcionMenu.Name = "tsbQuitar" Then
                    oOpcionMenu.Enabled = False
                End If
            Next

            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarOrdenRequerimiento(key)

            txtSerie.Text = "010"
            txtNumero.Text = mOR.ORR_ID
            dtpFechaDoc.Value = mOR.ORR_FECHA
            txtOR.Text = mOR.ORR_ID
            cboMoneda.SelectedIndex = 0

            For Each mDoc In cboTipoDocumento.Items
                If mDoc(0).ToString.Substring(0, 3) = BCParametro.ParametroGetById("DTD_OR").PAR_VALOR1 Then 'Orden Requerimiento
                    cboTipoDocumento.SelectedItem = mDoc
                    Exit For
                End If
            Next

            chkAfectaKardex.Checked = True

            For Each mItem In mOR.OrdenRequerimientoDetalle
                If (mItem.ORD_CANTIDAD - mItem.ORD_CANTIDAD_ATENDIDA) > 0 Then
                    ' ''''''''''''''''Experimental aprobacion virtual
                    'Dim Her = ContainerService.Resolve(Of Herramientas)()
                    'If Her.PermisoEntidadNumero(mItem.ENO_ID, 1011) = 1011 Or Her.PermisoEntidadNumero(mItem.ENO_ID, 15030) = 15030 Then 'Solo sirve para Entidad ventas
                    '    If mOR.PER_ID_AUTORIZADO Is Nothing Then
                    '        MessageBox.Show("La O.R. no está autorizada para ser Atendida.")
                    '        OnManNuevo()
                    '        Exit Sub
                    '    End If
                    'End If
                    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''Experimental 2
                    If mItem.USU_ID_AUT Is Nothing Then Continue For
                    '''''''''''''''''''''''''''''''''''''''''''

                    If mItem.OrdenTrabajo.OTR_FASE = "En Proceso" Then
                        Dim nRow As New DataGridViewRow
                        dgvDetalle.Rows.Add(nRow)
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMD_ID").Value = mItem.DMD_ID
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMD_ID").Tag = mItem
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Tag = mItem.ART_ID
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem.ORD_CANTIDAD - mItem.ORD_CANTIDAD_ATENDIDA
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_SIMBOLO
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM").Tag = mItem 'Objeto del detalle requerimiento
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ORD_ID").Tag = mItem.ORD_ID
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value = mItem.DMD_PRECIO_UNITARIO
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value = mItem.DMD_DESCUENTO

                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value - _
                        '    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value * (dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value / 100)
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value * (txtIGV.Text / 100)
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Total").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Glosa").Value = mItem.ORD_OBSERVACION
                        If mItem.ALM_ID IsNot Nothing OrElse mItem.ALM_ID > 0 Then
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID_DESTINO").Tag = mItem.ALM_ID
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("ALM_ID_DESTINO").Value = BCAlmacen.AlmacenGetById(mItem.ALM_ID).ALM_DESCRIPCION
                        End If
                        

                        '' '' '' ''If Not mItem.ALM_ID = 0 Then
                        '' '' '' ''    For Each mDoc In cboTipoDocumento.Items
                        '' '' '' ''        If mDoc(0).ToString.Substring(0, 3) = "062" Then 'Orden Requerimiento
                        '' '' '' ''            cboTipoDocumento.SelectedItem = mDoc
                        '' '' '' ''            Exit For
                        '' '' '' ''        End If
                        '' '' '' ''    Next
                        '' '' '' ''End If
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ALM_Id").Tag = mItem.ALM_ID
                    End If
                End If
            Next
        Else
            OnManNuevo()
        End If

        dgvDetalle.Columns("Art_Id").ReadOnly = True
        'dgvDetalle.Columns("Cantidad").ReadOnly = True
        cboTipoDocumento.Enabled = False

        frm.Dispose()
    End Sub

    Sub CargarOrdenRequerimiento(ByVal ORR_Id As Integer)
        mOR = BCOrdenRequerimiento.OrdenRequerimientoGetById(ORR_Id)
        mOR.MarkAsModified()
    End Sub

    Sub CargarOrdenCompra(ByVal OCO_Id As Integer)
        mOC = BCOrdenCompra.OrdenCompraGetById(OCO_Id)
        mOC.MarkAsModified()
    End Sub

    Sub CargarTransformacion(ByVal TFO_Id As Integer)
        mTF = BCTransformacion.TransformacionGetById(TFO_Id)
        mTF.MarkAsModified()
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
        Totales()

        'Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        'If e.KeyCode = Keys.Enter Then
        '    Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
        '        Case "ART_Id"
        '            frm.Tabla = "Articulo"
        '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
        '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value 'Codigo + ART_Descripcion
        '                dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnidadMedida
        '            End If
        '        Case "ALM_ID"
        '            frm.Tabla = "ArticuloAlmacenPermitido"
        '            frm.Art_Id = dgvDetalle.CurrentRow.Cells("ART_ID").Tag
        '            frm.Alm_Id = Nothing
        '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                CargarArticuloAlmacen(frm.dgvLista.CurrentRow.Cells(0).Value)
        '                If mArticuloAlmacen.ALM_ID = dgvDetalle.CurrentRow.Cells("ALM_ID_DESTINO").Tag Then
        '                    dgvDetalle.CurrentCell.Tag = Nothing
        '                    dgvDetalle.CurrentCell.Value = String.Empty
        '                    dgvDetalle.CurrentRow.Cells("Stock").Value = 0
        '                    Exit Sub
        '                End If
        '                dgvDetalle.CurrentCell.Tag = mArticuloAlmacen.ALM_ID  'ALM_Id
        '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(3).Value 'ALM_Descripcion
        '                dgvDetalle.CurrentRow.Cells("Stock").Value = frm.dgvLista.CurrentRow.Cells(5).Value  'Stock
        '                If CType(cboTipoDocumento.Tag, DetalleTipoDocumentos).DTD_E_S_ALMA = 2 Or CType(cboTipoDocumento.Tag, DetalleTipoDocumentos).DTD_ID = "057" Then 'Cuando es OR, Devolucion
        '                    dgvDetalle.CurrentRow.Cells("PU").Value = frm.dgvLista.CurrentRow.Cells(6).Value  'Precio Unitario
        '                    dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells("PU")
        '                    dgvDetalle_CellEndEdit(dgvDetalle, Nothing)

        '                    If Not dgvDetalle.CurrentRow.Cells("UM").Tag Is Nothing Then 'Es un requerimiento
        '                        If dgvDetalle.CurrentRow.Cells("ALM_ID").Tag = BCParametro.ParametroGetById("AlmSum").PAR_VALOR1 Or dgvDetalle.CurrentRow.Cells("ALM_ID").Tag = BCParametro.ParametroGetById("AlmAct").PAR_VALOR1 Then 'Reemplzar con parametro
        '                            If CDbl(dgvDetalle.CurrentRow.Cells("Stock").Value) - CDbl(dgvDetalle.CurrentRow.Cells("Cantidad").Value) <= 0 Then
        '                                If MessageBox.Show("Desea agregar el articulo al Proceso de Compra?", "Atencion", MessageBoxButtons.YesNo) = DialogResult.Yes Then
        '                                    If CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA Is Nothing Then
        '                                        'En la UM esta ORD
        '                                        Dim Motivo As String
        '                                        Dim Cantidad As String
        '                                        Motivo = InputBox("Agrege motivo de la Compra", "Comentario")
        '                                        Cantidad = InputBox("Agrege la cantidad de la Compra", "Comentario")
        '                                        If Motivo.Length = 0 Then MessageBox.Show("No ingreso un motivo de compra. Se cancelara el proceso.", "Atencion") : Exit Sub
        '                                        If Not IsNumeric(Cantidad) Then MessageBox.Show("No ingreso una cantidad valida de compra. Se cancelara el proceso.", "Atencion") : Exit Sub
        '                                        CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_ESTADO_COMPRA = "PC"
        '                                        CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_OBS_COMPRA = Motivo
        '                                        CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_CANTIDAD_COMPRA = Cantidad
        '                                        CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle).MarkAsModified()
        '                                        'BCOrdenRequerimiento.MantenimientoOrdenRequerimientoDetalle(CType(dgvDetalle.CurrentRow.Cells("UM").Tag, OrdenRequerimientoDetalle))
        '                                        BCOrdenRequerimiento.MantenimientoOrdenRequerimiento(mOR)
        '                                        For Each mOrd In mOR.OrdenRequerimientoDetalle
        '                                            For Each mFila In dgvDetalle.Rows
        '                                                If mOrd.ORD_ID = CType(mFila.Cells("UM").Tag, OrdenRequerimientoDetalle).ORD_ID Then
        '                                                    mFila.Cells("UM").Tag = mOrd
        '                                                End If
        '                                            Next
        '                                        Next
        '                                    Else
        '                                        MessageBox.Show("El articulo ya esta en el Proceso de Compra", "Atencion")
        '                                    End If
        '                                End If
        '                                dgvDetalle.CurrentRow.Cells("Cantidad").Value = dgvDetalle.CurrentRow.Cells("Stock").Value 'Poner despues, lo quito por el imbechile del claudio
        '                                If dgvDetalle.CurrentRow.Cells("Cantidad").Value <= 0 Then
        '                                    dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow)
        '                                    If dgvDetalle.Rows.Count > 0 Then dgvDetalle.CurrentCell = dgvDetalle.Rows(0).Cells("Stock")
        '                                End If
        '                            End If
        '                        End If
        '                    End If

        '                End If
        '            ElseIf frm.dgvLista.Rows.Count = 0 Then
        '                frm.Tabla = "AlmacenRendicion"
        '                frm.Art_Id = dgvDetalle.CurrentRow.Cells("ART_ID").Tag
        '                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Alm_Id
        '                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        '                End If
        '            End If
        '        Case "DMD_ID_REF"
        '            If cboTipoDocumento.SelectedValue.ToString.Trim = BCParametro.ParametroGetById("Orden Devolucion").PAR_VALOR1 Then 'Orden Devolucion
        '                frm.Tabla = "ListaSalidaXReqXDocu"
        '                frm.Tipo = dgvDetalle.CurrentCell.Value
        '                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value 'DMD_Id_Ref
        '                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value 'DMD_Id_Ref
        '                    numTipoCambio.Value = 1

        '                    Dim key As Integer = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value
        '                    Dim mDocuDetalleRef As DocuMovimientoDetalle
        '                    mDocuDetalleRef = BCDocuMovimiento.DocuMovimientoDetalleGetById(key)
        '                    dgvDetalle.CurrentRow.Cells("Art_Id").Value = mDocuDetalleRef.Articulos.ART_Codigo & " - " & mDocuDetalleRef.Articulos.ART_DESCRIPCION
        '                    dgvDetalle.CurrentRow.Cells("Art_Id").Tag = mDocuDetalleRef.ART_ID
        '                    dgvDetalle.CurrentRow.Cells("ORD_ID").Tag = mDocuDetalleRef.ORD_ID
        '                    dgvDetalle.CurrentRow.Cells("Cantidad").Value = mDocuDetalleRef.DMD_CANTIDAD
        '                    dgvDetalle.CurrentRow.Cells("UM").Value = mDocuDetalleRef.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
        '                    dgvDetalle.CurrentRow.Cells("PU").Value = mDocuDetalleRef.DMD_CONTRAVALOR / mDocuDetalleRef.DMD_CANTIDAD
        '                    dgvDetalle.CurrentRow.Cells("SubTotal").Value = CDbl(dgvDetalle.CurrentRow.Cells("PU").Value) * CDbl(dgvDetalle.CurrentRow.Cells("Cantidad").Value)
        '                    dgvDetalle.CurrentRow.Cells("Total").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value
        '                    dgvDetalle.CurrentRow.Cells("Glosa").Value = mDocuDetalleRef.DMD_GLOSA
        '                    dgvDetalle.CurrentRow.Cells("ALM_Id").Value = mDocuDetalleRef.Almacen.ALM_DESCRIPCION
        '                    dgvDetalle.CurrentRow.Cells("ALM_Id").Tag = mDocuDetalleRef.ALM_ID
        '                End If

        '            ElseIf cboTipoDocumento.SelectedValue.ToString.Trim = BCParametro.ParametroGetById("GuiaCompra").PAR_VALOR1 Then 'Guia Compra
        '                frm.Tabla = "ListaSalidaXReqXDocu"
        '                frm.Tipo = dgvDetalle.CurrentCell.Value
        '                frm.Tipo2 = dgvDetalle.CurrentRow.Cells("Art_Id").Tag
        '                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value 'DMD_Id_Ref
        '                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value 'DMD_Id_Ref
        '                    numTipoCambio.Value = 1

        '                    Dim key As Integer = frm.dgvLista.CurrentRow.Cells("DMD_ID").Value
        '                    Dim mDocuDetalleRef As DocuMovimientoDetalle
        '                    mDocuDetalleRef = BCDocuMovimiento.DocuMovimientoDetalleGetById(key)
        '                    'dgvDetalle.CurrentRow.Cells("Art_Id").Value = mDocuDetalleRef.Articulos.ART_Codigo & " - " & mDocuDetalleRef.Articulos.ART_DESCRIPCION
        '                    'dgvDetalle.CurrentRow.Cells("Art_Id").Tag = mDocuDetalleRef.ART_ID
        '                    'dgvDetalle.CurrentRow.Cells("ORD_ID").Tag = mDocuDetalleRef.ORD_ID
        '                    'dgvDetalle.CurrentRow.Cells("Cantidad").Value = mDocuDetalleRef.DMD_CANTIDAD
        '                    'dgvDetalle.CurrentRow.Cells("UM").Value = mDocuDetalleRef.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
        '                    dgvDetalle.CurrentRow.Cells("PU").Value = mDocuDetalleRef.DMD_CONTRAVALOR / mDocuDetalleRef.DMD_CANTIDAD
        '                    dgvDetalle.CurrentRow.Cells("SubTotal").Value = CDbl(dgvDetalle.CurrentRow.Cells("PU").Value) * CDbl(dgvDetalle.CurrentRow.Cells("Cantidad").Value)
        '                    dgvDetalle.CurrentRow.Cells("Total").Value = dgvDetalle.CurrentRow.Cells("SubTotal").Value
        '                    'dgvDetalle.CurrentRow.Cells("Glosa").Value = mDocuDetalleRef.DMD_GLOSA
        '                    'dgvDetalle.CurrentRow.Cells("ALM_Id").Value = mDocuDetalleRef.Almacen.ALM_DESCRIPCION
        '                    'dgvDetalle.CurrentRow.Cells("ALM_Id").Tag = mDocuDetalleRef.ALM_ID
        '                End If

        '            End If
        '    End Select
        'End If
        'frm.Dispose()
        'Totales()
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("DMD_ID").Tag Is Nothing Then
            CType(e.Row.Cells("DMD_ID").Tag, DocuMovimientoDetalle).Alm_Ori = CType(e.Row.Cells("DMD_ID").Tag, DocuMovimientoDetalle).ALM_ID
            CType(e.Row.Cells("DMD_ID").Tag, DocuMovimientoDetalle).Art_Ori = CType(e.Row.Cells("DMD_ID").Tag, DocuMovimientoDetalle).ART_ID

            CType(e.Row.Cells("DMD_ID").Tag, DocuMovimientoDetalle).Kardex(0).MarkAsDeleted()
            CType(e.Row.Cells("DMD_ID").Tag, DocuMovimientoDetalle).MarkAsDeleted()
        End If
        Totales()
    End Sub

    Private Sub txtOC_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOC.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "OrdenCompraID"
        If txtOC.Text <> "" Then frm.Tipo = txtOC.Text
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            OnManNuevo()

            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name = "tsbAgregar" Or oOpcionMenu.Name = "tsbQuitar" Then
                    oOpcionMenu.Enabled = False
                End If
            Next

            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarOrdenCompra(key)

            Dim mListaOrdenCompraDetalle As New List(Of OrdenCompraDetalle)
            For Each mObj In mOC.OrdenCompraDetalle
                Dim mOrdenCompraDetalle As New OrdenCompraDetalle
                mOrdenCompraDetalle = mObj.Clone
                mListaOrdenCompraDetalle.Add(mOrdenCompraDetalle)
            Next

            For cont As Integer = mListaOrdenCompraDetalle.Count - 1 To 0 Step -1
                If mListaOrdenCompraDetalle(cont).USU_ID_AUT_2 Is Nothing Then
                    mListaOrdenCompraDetalle.RemoveAt(cont)
                End If
            Next

            Dim Lista1 = From mItem In mListaOrdenCompraDetalle Group mItem By UsuId = mItem.USU_ID_AUT_2 Into Gpr = Group _
            Select UsuId, SubTotal = Gpr.Sum(Function(mItem) CDec(mItem.OCD_CONTRAVALOR))

            For Each mItem In Lista1.ToList
                If mItem.SubTotal > BCParametro.ParametroGetById(mItem.UsuId).PAR_VALOR1 Then
                    For cont As Integer = mListaOrdenCompraDetalle.Count - 1 To 0 Step -1
                        If mListaOrdenCompraDetalle(cont).USU_ID_AUT_2 = mItem.UsuId And mListaOrdenCompraDetalle(cont).USU_ID_AUT_3 Is Nothing Then
                            If Not (mListaOrdenCompraDetalle(cont).ART_ID = BCParametro.ParametroGetById("Diesel").PAR_VALOR1 Or mListaOrdenCompraDetalle(cont).ART_ID = BCParametro.ParametroGetById("R500").PAR_VALOR1) Then
                                mListaOrdenCompraDetalle.RemoveAt(cont)
                            End If
                        End If
                    Next
                End If
            Next

            Dim mTt = (From mItem In mListaOrdenCompraDetalle Select mItem.OCD_CONTRAVALOR).Sum
            If mTt > BCParametro.ParametroGetById("JMARSAL").PAR_VALOR1 Then
                For cont As Integer = mListaOrdenCompraDetalle.Count - 1 To 0 Step -1
                    If mListaOrdenCompraDetalle(cont).USU_ID_AUT_4 Is Nothing Then
                        If Not (mListaOrdenCompraDetalle(cont).ART_ID = BCParametro.ParametroGetById("Diesel").PAR_VALOR1 Or mListaOrdenCompraDetalle(cont).ART_ID = BCParametro.ParametroGetById("R500").PAR_VALOR1) Then
                            mListaOrdenCompraDetalle.RemoveAt(cont)
                        End If
                    End If
                Next
            End If



            dtpFechaDoc.Value = mOC.OCO_FECHA
            txtOC.Text = mOC.OCO_ID
            cboMoneda.SelectedValue = mOC.MON_ID

            For Each mDoc In cboTipoDocumento.Items
                If mDoc(0).ToString.Substring(0, 3) = "038" Then 'Factura
                    cboTipoDocumento.SelectedItem = mDoc
                    Exit For
                End If
            Next

            txtProveedor.Text = mOC.Personas.PER_NOMBRES & " " & mOC.Personas.PER_APE_PAT
            txtProveedor.Tag = mOC.PER_ID_PROVEEDOR
            chkAfectaKardex.Checked = True

            'Dim mPCD As ProcesoCompraDetalle
            For Each mItem In mOC.OrdenCompraDetalle
                Dim flag As Boolean = False
                For Each mCol In mListaOrdenCompraDetalle
                    If mItem.OCD_ID = mCol.OCD_ID Then
                        flag = True
                    End If
                Next

                If flag = False Then Continue For

                'mPCD = Nothing
                'mPCD = BCProcesoCompra.ProcesoCompraDetalleGetById2(mItem.OCD_ID)

                If (mItem.OCD_CANTIDAD - mItem.OCD_CANTIDAD_INGRESADA) > 0 Then
                    Dim nRow As New DataGridViewRow
                    dgvDetalle.Rows.Add(nRow)
                    txtIGV.Text = mItem.OCD_IGV
                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMD_ID").Value = mItem.DMD_ID
                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMD_ID").Tag = mItem
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Tag = mItem.ART_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem.OCD_CANTIDAD - mItem.OCD_CANTIDAD_INGRESADA
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OCD_ID").Tag = mItem.OCD_ID

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PU").Value = mItem.OCD_PRECIO_UNITARIO + IIf(CDbl(mItem.OCD_OTROS1) > 0, (mItem.OCD_OTROS1 / mItem.OCD_CANTIDAD), 0)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descuento").Value = mItem.OCD_DESCUENTO

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value - _
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value * (dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descuento").Value / 100) + _
                         IIf(CDbl(mItem.OCD_OTROS1) > 0, (mItem.OCD_OTROS1 / mItem.OCD_CANTIDAD), 0)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value * (txtIGV.Text / 100)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value + IIf(CDbl(mItem.OCD_OTROS1) > 0, (mItem.OCD_OTROS1 / mItem.OCD_CANTIDAD), 0)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Glosa").Value = mItem.OCD_OBSERVACIONES
                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ALM_Id").Value = mItem.Almacen.ALM_DESCRIPCION
                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ALM_Id").Tag = mItem.ALM_ID

                    dgvDetalle.CurrentCell = dgvDetalle.CurrentRow.Cells("PU")

                    dgvDetalle_CellEndEdit(dgvDetalle, Nothing)
                End If
            Next
        Else
            OnManNuevo()
        End If
        frm.Dispose()
    End Sub

    Private Sub cboTipoDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
        If mDocu IsNot Nothing Then
            If cboTipoDocumento.SelectedIndex > -1 Then cboTipoDocumento.Tag = BCTipoDocumento.TipoDocumentoGetById(cboTipoDocumento.SelectedValue.ToString.Substring(0, 3)) : If cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "038" Or cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "082" Or cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "144" Or cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "216" Or cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "060" Then txtIGV.Text = SessionServer.IGV Else txtIGV.Text = "0"
            If RTrim(cboTipoDocumento.SelectedValue) = "057038" Then
                cboMoneda.SelectedIndex = 0
            End If
        End If
    End Sub

    'Private Sub txtAlmacenDestino_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
    '    frm.Tabla = "Almacen"
    '    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        txtAlmacenDestino.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Alm_Id
    '        txtAlmacenDestino.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
    '    End If
    '    frm.Dispose()
    'End Sub

    Private Sub cboMoneda_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMoneda.SelectedValueChanged
        numTipoCambio.Value = BCDocuMovimiento.TCCompraDia(cboMoneda.SelectedValue, dtpFechaDoc.Value)
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.

    'validamos los campos a llenar
    Function validar_detalle(ByVal mGridCant As Integer)
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True
        Dim cont As Integer = 0
        Try
            Error_validacion.Clear()
            For Each mItem In mDocu.DocuMovimientoDetalle
                If mItem.ChangeTracker.State <> ObjectState.Deleted Then
                    cont += 1
                End If
            Next

            If Not mGridCant = cont Then
                flag = False
                For idx As Integer = mDocu.DocuMovimientoDetalle.Count - 1 To 0 Step -1
                    If mDocu.DocuMovimientoDetalle(idx).ChangeTracker.State = ObjectState.Added Then
                        mDocu.DocuMovimientoDetalle.RemoveAt(idx)
                    End If
                Next
            End If

            If flag = False Then
                MessageBox.Show("Error en el detalle del documento.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            flag = False
            MessageBox.Show("Error.Verifique sus datos.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return flag

    End Function

    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Try
            Error_validacion.Clear()

        If Len(cboTipoDocumento.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoDocumento, "Ingrese el Tipo de Documento") : cboTipoDocumento.Focus() : flag = False
        If Len(txtSerie.Text.Trim) = 0 Then Error_validacion.SetError(txtSerie, "Ingrese la Serie") : txtSerie.Focus() : flag = False
        If Len(txtNumero.Text.Trim) = 0 Then Error_validacion.SetError(txtNumero, "Ingrese el Numero") : txtNumero.Focus() : flag = False
        'If Len(dtpFechaDoc.Text.Trim) = 0 Then Error_validacion.SetError(dtpFechaDoc, "Ingrese las Unidades de Medida") : dtpFechaDoc.Focus() : flag = False
        '''''If Len(txtOR.Text.Trim) = 0 Then Error_validacion.SetError(txtOR, "Ingrese la Orden de Requerimiento") : txtOR.Focus() : flag = False
        '''''If Len(txtAlmacenDestino.Text.Trim) = 0 Then Error_validacion.SetError(txtAlmacenDestino, "Ingrese el Almacen de Destino") : txtAlmacenDestino.Focus() : flag = False
        '''''If Len(txtOC.Text.Trim) = 0 Then Error_validacion.SetError(txtOC, "Ingrese el Orden de Compra") : txtOC.Focus() : flag = False
        '''''If Len(txtSC.Text.Trim) = 0 Then Error_validacion.SetError(txtSC, "Ingrese la Salida de Combustible") : txtSC.Focus() : flag = False
        'If Len(dtpFecha.Text.Trim) = 0 Then Error_validacion.SetError(dtpFecha, "Ingrese la Ficha Tecnica") : dtpFecha.Focus() : flag = False
        '''''
        If Len(cboMoneda.Text.Trim) = 0 Then Error_validacion.SetError(cboMoneda, "Ingrese el Tipo de Moneda") : cboMoneda.Focus() : flag = False
        If Len(txtIGV.Text.Trim) = 0 Then Error_validacion.SetError(txtIGV, "Ingrese el IGV") : txtIGV.Focus() : flag = False
        If numTipoCambio.Value <= 0 Then Error_validacion.SetError(numTipoCambio, "Ingrese el Tipo de Cambio") : numTipoCambio.Focus() : flag = False

            'se trata de una operacion permitida
            Dim Pn As Boolean = False
            If mOC IsNot Nothing Or mTF IsNot Nothing Or mOR IsNot Nothing Or FlagPermisoModificacion = True Then
                Pn = True
            End If

            If Not Pn Then 'Si Pn es true es proceso normal
                'POR CABECERA
                If CType(cboTipoDocumento.Tag, DetalleTipoDocumentos).DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    If mDocu.ChangeTracker.State = ObjectState.Modified Or mDocu.ChangeTracker.State = ObjectState.Added Then
                        If Not BCParametro.ParametroGetById("DocIngresoLibre").PAR_VALOR2.Contains("/" & cboTipoDocumento.SelectedValue.ToString.Trim & "/") Then
                            If SessionServer.UserId <> "ADMIN" Then
                                '    If Not InputBox("Ingrese la clave", "Autorizacion de Ingreso") = BCParametro.ParametroGetById(SessionServer.UserId & "DOCU1").PAR_VALOR1 Then 'Esto sirve para documentos con ingreso libre
                                '        MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                                '        flag = False
                                '    End If
                                'Else
                                If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                                    If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById("/" & cboTipoDocumento.SelectedValue.ToString.Trim & "/" & SessionServer.UserId & "DOCU1").PAR_VALOR1 Then 'Esto sirve para documentos no libres y usuario por documento
                                        MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                                        flag = False
                                    End If
                                Else
                                    MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                                    flag = False
                                End If
                            End If
                        End If
                        If Len(txtProveedor.Text.Trim) = 0 Or (txtProveedor.Tag & "").ToString.Length = 0 Then Error_validacion.SetError(txtProveedor, "Ingrese al Proveedor") : txtProveedor.Focus() : flag = False
                        If Len(cboTipoDocumentoREF.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoDocumentoREF, "Ingrese el Tipo de Documento") : cboTipoDocumentoREF.Focus() : flag = False
                        If Len(txtSerieREF.Text.Trim) = 0 Then Error_validacion.SetError(txtSerieREF, "Ingrese la Serie") : txtSerieREF.Focus() : flag = False
                        If Len(txtNumeroREF.Text.Trim) = 0 Then Error_validacion.SetError(txtNumeroREF, "Ingrese el Numero") : txtNumeroREF.Focus() : flag = False

                    End If
                Else 'Cuando es salida
                    If mDocu.ChangeTracker.State = ObjectState.Modified Then
                        If SessionServer.UserId <> "ADMIN" Then
                            If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                                If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById(SessionServer.UserId & "DOCU2").PAR_VALOR1 Then
                                    MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                                    flag = False
                                End If
                            Else
                                MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                                flag = False
                            End If
                        End If
                    End If
                End If
            Else 'Validaciones del proceso normal
                'POR CABECERA
                If CType(cboTipoDocumento.Tag, DetalleTipoDocumentos).DTD_E_S_ALMA = 1 Then '1 = + ; 2 = -
                    If Len(txtProveedor.Text.Trim) = 0 Or (txtProveedor.Tag & "").ToString.Length = 0 Then Error_validacion.SetError(txtProveedor, "Ingrese al Proveedor") : txtProveedor.Focus() : flag = False
                    If Len(cboTipoDocumentoREF.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoDocumentoREF, "Ingrese el Tipo de Documento") : cboTipoDocumentoREF.Focus() : flag = False
                    If Len(txtSerieREF.Text.Trim) = 0 Then Error_validacion.SetError(txtSerieREF, "Ingrese la Serie") : txtSerieREF.Focus() : flag = False
                    If Len(txtNumeroREF.Text.Trim) = 0 Then Error_validacion.SetError(txtNumeroREF, "Ingrese el Numero") : txtNumeroREF.Focus() : flag = False
                End If
            End If


            'POR DETALLE
            For Each mFila As DataGridViewRow In dgvDetalle.Rows
                If mFila.Cells("ALM_ID").Tag Is Nothing OrElse mFila.Cells("ALM_ID").Tag = 0 Then
                    flag = False
                    MessageBox.Show("Falta seleccionar el almacen en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit For
                End If
                If CDbl(mFila.Cells("Cantidad").Value) <= 0 And cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) <> "060" Then
                    flag = False
                    MessageBox.Show("La cantidad debe ser mayor a cero.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit For
                End If
                If CDbl(mFila.Cells("PU").Value) <= 0 Then
                    flag = False
                    MessageBox.Show("El P.U. debe ser mayor a cero.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit For
                End If

                If CType(cboTipoDocumento.Tag, DetalleTipoDocumentos).DTD_E_S_ALMA = 2 Then '1 = + ; 2 = -
                    If mDocu.ChangeTracker.State = ObjectState.Added Then
                        If CDbl(mFila.Cells("Stock").Value) < CDbl(mFila.Cells("Cantidad").Value) And Not BCParametro.ParametroGetById("AlmSer").PAR_VALOR1 = mFila.Cells("ALM_ID").Tag Then
                            flag = False
                            MessageBox.Show("El stock es menor a la cantidad en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit For
                        End If
                    End If
                    If BCParametro.ParametroGetById("NoSalidaAlm").PAR_VALOR2.Contains("/" & mFila.Cells("ALM_ID").Tag & "/") Then
                        flag = False
                        MessageBox.Show("No se puede dar Salida a este Almacen.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                Else
                    If BCParametro.ParametroGetById("NoIngresoAlm").PAR_VALOR2.Contains("/" & mFila.Cells("ALM_ID").Tag & "/") Then
                        flag = False
                        MessageBox.Show("No se puede dar Ingreso a este Almacen.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If

                End If
            Next


            If flag = False Then
                MessageBox.Show("Debe de ingresar datos en los campos seleccionados", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            flag = False
            MessageBox.Show("Error.Verifique sus datos.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Return flag

    End Function

    Private Sub txtOR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOR.KeyDown
        If e.KeyCode = Keys.Enter Then txtOR_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtOC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOC.KeyDown
        If e.KeyCode = Keys.Enter Then txtOC_DoubleClick(Nothing, Nothing)
    End Sub

    'validamos los botones especiales
    Private Sub txtSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtSerie.KeyPress,
        txtNumero.KeyPress,
        txtOR.KeyPress,
        txtOC.KeyPress
        'If e.KeyChar = CChar(ChrW(Keys.Back)) Then
        '    MsgBox("tecla(presionada)")
        'End If

        'If Not IsNumeric(e.KeyChar) Then
        '    If Not e.KeyChar = CChar(ChrW(Keys.Back)) Then
        '        e.Handled = True
        '    End If
        'End If
    End Sub

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.cboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList : Me.cboTipoDocumento.MaxLength = 45
        Me.txtSerie.MaxLength = 4
        Me.txtNumero.MaxLength = 25
        'Me.txtOR.MaxLength = 10
        'Me.txtOC.MaxLength = 10
        'Me.txtAlmacenDestino.MaxLength = 160
        'Me.txtSC.MaxLength = 10
        Me.txtProveedor.MaxLength = 160
        Me.cboMoneda.DropDownStyle = ComboBoxStyle.DropDownList : Me.cboMoneda.DropDownStyle = ComboBoxStyle.DropDownList
        Me.txtIGV.MaxLength = 6
    End Sub

    'codigos agregados===================================================
    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)

    End Sub

    Public Overrides Sub OnManEditar()
        Call validacion_desactivacion(True, 6)
    End Sub

    Public Overrides Sub OnManCancelarEdicion()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 7)
    End Sub

    Public Overrides Sub OnManSalir()
        Me.Dispose()
    End Sub


    'valida controles desactivacion
    Sub validacion_desactivacion(ByVal op As Boolean, ByVal flag As Integer)
        'datos a tener en cuenta
        '1=load
        '2=nuevo
        '3=guardar
        '4=DeshacerCambios
        '5=buscar
        '6=editar
        '7=deshacer,eliminar

        If flag = 1 Or flag = 3 Or flag = 4 Or flag = 7 Then

            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbBuscar.Enabled = Not op
            Me.tsbSalir.Enabled = Not op
            Me.tscPosicion.Enabled = Not op

            dgvDetalle.Enabled = True

            dgvDetalle.Columns("Art_Id").ReadOnly = False
            dgvDetalle.Columns("Cantidad").ReadOnly = False

        ElseIf flag = 2 Or flag = 6 Then 'evento nuevo registro
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = Not op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbGrabar.Enabled = op
            Me.TsbGrabarNuevo.Enabled = op
            Me.tsbDeshacer.Enabled = op
            Me.tsbAgregar.Enabled = op
            Me.tsbQuitar.Enabled = op

            ' ''Por mientrasssss
            ''Me.chkAfectaKardex.Enabled = False

        ElseIf flag = 5 Then 'evento buscar/editar
            'desactiva controles
            For Each ctrl As Control In Me.Controls
                ctrl.Enabled = op
            Next
            'desactiva controles anidados del toolstrip
            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name.Substring(0, 8) <> "ToolStripSeparator" Then
                    oOpcionMenu.Enabled = op
                End If
            Next
            'activamos barra
            Me.tsBarra.Enabled = True
            Me.tsbSalir.Enabled = True
            '----
            Me.tsbNuevo.Enabled = Not op
            Me.tsbEditar.Enabled = Not op
            Me.tsbCancelarEditar.Enabled = Not op
            'dgvDetalle.Enabled = False
            dtpFecha.Enabled = Not op
            dgvDetalle.Columns("Cantidad").ReadOnly = True
        End If
    End Sub

    Public Overrides Sub OnReportes()
        If mDocu IsNot Nothing Then
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    mNuevaPag = 0
                    mIndexItem = 0
                    mCantLinea = 20
                    PrintDocument1.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 1, 5, 5)
                    Dim mAlma_Destino = (From mGrid In mDocu.DocuMovimientoDetalle Select mGrid.ALM_ID).Distinct
                    For Each mAlmaDestino In mAlma_Destino.ToList
                        mPrintAlma = mAlmaDestino
                        PrintDocument1.Print()
                    Next
                Catch ex As Exception
                    MessageBox.Show("No hay impresora activa", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                End Try
            End If
        End If
    End Sub

    Sub Totales()
        txtSubTotal.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("SubTotal").Value)), 2)
        txtTotalIgv.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("IGV").Value)), 2)
        txtTotal.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("Total").Value)), 2)
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim ft As New System.Drawing.Font("Courier New", 10, FontStyle.Regular)
        Dim ftN As New System.Drawing.Font("Courier New", 10, FontStyle.Bold)
        Dim ft8 As New System.Drawing.Font("Courier New", 8, FontStyle.Regular)
        e.Graphics.DrawString(SessionServer.NombreEmpresa, ftN, Brushes.Black, 50, 30)
        e.Graphics.DrawString("NOTA DE " & IIf(mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1, "INGRESO", "SALIDA") & " : " & mDocu.DMO_ID, ftN, Brushes.Black, 50, 50)
        e.Graphics.DrawString("Fec.Impr.", ftN, Brushes.Black, 450, 50)
        e.Graphics.DrawString(" : " & Date.Now, ftN, Brushes.Black, 520, 50)

        'e.Graphics.DrawString("Almacen", ftN, Brushes.Black, 50, 70)
        'If Documentacion.ListLOGI_DocumentacionDetalle.Count > 0 Then e.Graphics.DrawString(": " & CargarAlmacen(Entorno.EMPR_Id, Documentacion.ListLOGI_DocumentacionDetalle(0).ALMA_Id).ALMA_Descripcion, ft, Brushes.Black, 200, 70)

        e.Graphics.DrawString("Fecha Documento", ftN, Brushes.Black, 50, 70)
        e.Graphics.DrawString(": " & mDocu.DMO_FECHA_DOCUMENTO, ft, Brushes.Black, 200, 70)

        'e.Graphics.DrawString("O.T.", ftN, Brushes.Black, 450, 90)
        'If mdocu.OTR_id IsNot Nothing Then e.Graphics.DrawString(": " & Documentacion.ORTR_id, ft, Brushes.Black, 520, 90)

        e.Graphics.DrawString("Proveedor", ftN, Brushes.Black, 50, 90)
        If mDocu.PER_ID_PROVEEDOR IsNot Nothing Then e.Graphics.DrawString(": " & mDocu.Personas.DocPersonas(0).DOP_NUMERO & " / " & mDocu.Personas.PER_APE_PAT, ft, Brushes.Black, 200, 90)

        e.Graphics.DrawString("Almacen", ftN, Brushes.Black, 50, 110)
        e.Graphics.DrawString(": " & BCAlmacen.AlmacenGetById(mPrintAlma).ALM_DESCRIPCION, ft, Brushes.Black, 200, 110)

        e.Graphics.DrawString("Moneda", ftN, Brushes.Black, 450, 110)
        e.Graphics.DrawString(" : " & mDocu.Moneda.MON_DESCRIPCION, ft, Brushes.Black, 520, 110)

        e.Graphics.DrawString("Documento", ftN, Brushes.Black, 50, 130)
        e.Graphics.DrawString(": " & mDocu.DetalleTipoDocumentos.TipoDocumentos.TDO_DESCRIPCION_CORTA & " / " & mDocu.DMO_SERIE & "-" & mDocu.DMO_NRO, ft, Brushes.Black, 200, 130)

        e.Graphics.DrawString("T.Cambio", ftN, Brushes.Black, 450, 130)
        e.Graphics.DrawString(" : " & Math.Round(mDocu.DocuMovimientoDetalle(0).DMD_CONTRAVALOR / IIf((mDocu.DocuMovimientoDetalle(0).DMD_PRECIO_UNITARIO * mDocu.DocuMovimientoDetalle(0).DMD_CANTIDAD) = 0, 1, (mDocu.DocuMovimientoDetalle(0).DMD_PRECIO_UNITARIO * mDocu.DocuMovimientoDetalle(0).DMD_CANTIDAD)), 3), ft, Brushes.Black, 520, 130)

        'e.Graphics.DrawString("Centro de Costo", ftN, Brushes.Black, 50, 170)
        'If Documentacion.ENOP_Id IsNot Nothing Then e.Graphics.DrawString(": " & CargarEntidadOperativa(Entorno.EMPR_Id, Documentacion.ENOP_Id).ENOP_Descripcion, ft, Brushes.Black, 200, 170)

        'e.Graphics.DrawString("Comentario", ftN, Brushes.Black, 50, 190)
        'e.Graphics.DrawString(": " & mDocu.dmo_Documentacion.DOCU_Glosa, ft, Brushes.Black, 200, 190)

        e.Graphics.DrawLine(Pens.Black, 50, 150, 800, 150)

        e.Graphics.DrawString("Codigo", ftN, Brushes.Black, 50, 155)
        e.Graphics.DrawString("Descripcion", ftN, Brushes.Black, 150, 155)
        e.Graphics.DrawString("Unid.", ftN, Brushes.Black, 490, 155)
        e.Graphics.DrawString("Cant.", ftN, Brushes.Black, 550, 155)
        e.Graphics.DrawString(IIf(mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1, "Prec.Unit.", ""), ftN, Brushes.Black, 600, 155)
        e.Graphics.DrawString(IIf(mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1, "Total", "Stock"), ftN, Brushes.Black, 700, 155)
        e.Graphics.DrawString("Ubi.", ftN, Brushes.Black, 765, 155)

        e.Graphics.DrawLine(Pens.Black, 50, 170, 800, 170)

        Dim altu As Integer = -90
        Dim mItem As Object
        Dim mOt As Integer = 0
        Dim mORD As OrdenRequerimientoDetalle
        If mNuevaPag = 50 Then mNuevaPag = 0
        For mFila = mIndexItem To mDocu.DocuMovimientoDetalle.Count - 1
            mItem = mDocu.DocuMovimientoDetalle(mFila)
            If mItem.ALM_ID = mPrintAlma Then 'Para que imprima cuando solo de un almacen
                If Not mItem.ORD_ID Is Nothing Then mORD = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mItem.ORD_ID)

                mNuevaPag += 1
                altu += 16

                If Not mORD Is Nothing Then
                    If Not mOt = mORD.OTR_ID Then

                        altu += 8

                        e.Graphics.DrawString("O.T.", ftN, Brushes.Black, 50, 250 + altu)
                        e.Graphics.DrawString(mORD.OTR_ID, ft, Brushes.Black, 100, 250 + altu)
                        e.Graphics.DrawString("Horom.", ftN, Brushes.Black, 150, 250 + altu)
                        e.Graphics.DrawString(mORD.OrdenTrabajo.OTR_HORO_FINAL, ft, Brushes.Black, 210, 250 + altu)
                        e.Graphics.DrawString("Destino", ftN, Brushes.Black, 300, 250 + altu)

                        e.Graphics.DrawString(mORD.Entidad.ENO_RUTA.Substring(0, IIf(mORD.Entidad.ENO_RUTA.Length > 60, 60, mORD.Entidad.ENO_RUTA.Length)), ft8, Brushes.Black, 380, 250 + altu)
                        altu += 16

                        If mORD.Entidad.ENO_RUTA.Length > 60 Then
                            e.Graphics.DrawString(mORD.Entidad.ENO_RUTA.Substring(60, IIf(mORD.Entidad.ENO_RUTA.Length > 170, 110, mORD.Entidad.ENO_RUTA.Length - 60)), ft8, Brushes.Black, 50, 250 + altu)
                            altu += 16
                        End If

                        If mORD.Entidad.ENO_RUTA.Length > 170 Then
                            e.Graphics.DrawString(mORD.Entidad.ENO_RUTA.Substring(170, IIf(mORD.Entidad.ENO_RUTA.Length > 280, 110, mORD.Entidad.ENO_RUTA.Length - 170)), ft8, Brushes.Black, 50, 250 + altu)
                            altu += 16
                        End If

                        If mORD.Entidad.ENO_RUTA.Length > 280 Then
                            e.Graphics.DrawString(mORD.Entidad.ENO_RUTA.Substring(280, IIf(mORD.Entidad.ENO_RUTA.Length > 390, 110, mORD.Entidad.ENO_RUTA.Length - 280)), ft8, Brushes.Black, 220, 250 + altu)
                            altu += 16
                        End If

                        mOt = mORD.OTR_ID
                        altu += 8
                    End If
                End If
                altu += 8
                altu = altu - 20
                'e.Graphics.DrawString("Alm.: " & mItem.Almacen.ALM_Descripcion, ft, Brushes.Black, 50, 250 + altu)
                'e.Graphics.DrawString("Codigo", ftN, Brushes.Black, 50, 205)
                e.Graphics.DrawString(mItem.Articulos.ART_Codigo, ft, Brushes.Black, 50, 270 + altu)
                'e.Graphics.DrawString("Descripcion", ftN, Brushes.Black, 50, 225)
                e.Graphics.DrawString(mItem.Articulos.ART_Descripcion.Substring(0, IIf(mItem.Articulos.ART_Descripcion.Length > 38, 38, mItem.Articulos.ART_Descripcion.Length)), ft, Brushes.Black, 150, 270 + altu)
                'e.Graphics.DrawString("Unid.", ftN, Brushes.Black, 50, 245)
                e.Graphics.DrawString(mItem.Articulos.UnidadMedidaArticulos.UM_SIMBOLO, ft, Brushes.Black, 490, 270 + altu)
                'e.Graphics.DrawString("Cant.", ftN, Brushes.Black, 50, 265)
                e.Graphics.DrawString(Math.Round(CType(mItem.DMD_Cantidad, Double), 2), ft, Brushes.Black, 550, 270 + altu)
                'e.Graphics.DrawString("Prec.Unit.", ftN, Brushes.Black, 50, 265)
                e.Graphics.DrawString(Math.Round(IIf(CType(mItem.DMD_DESCUENTO, Double) > 0, CType(mItem.DMD_Precio_Unitario, Double) - (CType(mItem.DMD_Precio_Unitario, Double) * (CType(mItem.DMD_DESCUENTO, Double) / 100)), CType(mItem.DMD_Precio_Unitario, Double)), 6) * IIf(mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1, 1, 0), ft, Brushes.Black, 600, 270 + altu)
                Try
                    Dim mAA As ArticuloAlmacen
                    mAA = BCArticuloAlmacen.ArticuloAlmacenGetById(mItem.Art_id, mItem.Alm_Id)
                    If mAA.UbicacionAlmacen IsNot Nothing Then
                        'e.Graphics.DrawString("Total", ftN, Brushes.Black, 50, 285)
                        e.Graphics.DrawString(IIf(mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1, Math.Round(CType(mItem.DMD_Cantidad, Double) * IIf(CType(mItem.DMD_DESCUENTO, Double) > 0, CType(mItem.DMD_Precio_Unitario, Double) - (CType(mItem.DMD_Precio_Unitario, Double) * (CType(mItem.DMD_DESCUENTO, Double) / 100)), CType(mItem.DMD_Precio_Unitario, Double)), 2), Math.Round(CDec(mAA.ARA_STOCK), 3)), ft, Brushes.Black, 700, 270 + altu)
                        'e.Graphics.DrawString("Ubi.", ftN, Brushes.Black, 765, 155)
                        e.Graphics.DrawString(mAA.UbicacionAlmacen.UBI_DESCRIPCION, ft, Brushes.Black, 765, 270 + altu)
                    Else
                        'e.Graphics.DrawString("Total", ftN, Brushes.Black, 50, 285)
                        e.Graphics.DrawString(IIf(mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1, Math.Round(CType(mItem.DMD_Cantidad, Double) * IIf(CType(mItem.DMD_DESCUENTO, Double) > 0, CType(mItem.DMD_Precio_Unitario, Double) - (CType(mItem.DMD_Precio_Unitario, Double) * (CType(mItem.DMD_DESCUENTO, Double) / 100)), CType(mItem.DMD_Precio_Unitario, Double)), 2), 0), ft, Brushes.Black, 700, 270 + altu)
                        'e.Graphics.DrawString("Ubi.", ftN, Brushes.Black, 765, 155)
                        e.Graphics.DrawString("NN", ft, Brushes.Black, 765, 270 + altu)
                    End If
                    ''e.Graphics.DrawString("Total", ftN, Brushes.Black, 50, 285)
                    'e.Graphics.DrawString(IIf(mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1, Math.Round(CType(mItem.DMD_Cantidad, Double) * IIf(CType(mItem.DMD_DESCUENTO, Double) > 0, CType(mItem.DMD_Precio_Unitario, Double) - (CType(mItem.DMD_Precio_Unitario, Double) * (CType(mItem.DMD_DESCUENTO, Double) / 100)), CType(mItem.DMD_Precio_Unitario, Double)), 2), "SALIDA"), ft, Brushes.Black, 700, 270 + altu)
                    ''e.Graphics.DrawString("Ubi.", ftN, Brushes.Black, 765, 155)
                    'If BCArticuloAlmacen.ArticuloAlmacenGetById(mItem.Art_id, mItem.Alm_Id).UbicacionAlmacen IsNot Nothing Then e.Graphics.DrawString(BCArticuloAlmacen.ArticuloAlmacenGetById(mItem.Art_id, mItem.Alm_Id).UbicacionAlmacen.UBI_DESCRIPCION, ft, Brushes.Black, 765, 270 + altu) Else e.Graphics.DrawString("NN", ft, Brushes.Black, 765, 270 + altu)
                    ''e.Graphics.DrawString(mAU.UbicacionAlmacen.UBI_DESCRIPCION, ft, Brushes.Black, 765, 250 + altu)
                Catch ex As Exception
                End Try


                If mItem.DMD_GLOSA IsNot Nothing Then
                    If mItem.DMD_GLOSA.Length > 0 Then
                        If mItem.DMD_GLOSA.Length >= 81 Then
                            altu += 16
                            e.Graphics.DrawString("Obs.: " & mItem.DMD_GLOSA.Substring(0, 81), ft, Brushes.Black, 50, 270 + altu)
                            Dim cade As String = ""
                            Dim Num As Integer = 168 'Es la cant. de caracteres que voy a imprimir en una linea de la columna observaciones
                            For ie As Integer = 81 To mItem.DMD_GLOSA.Length - 1
                                If ie < Num Then
                                    cade += mItem.DMD_GLOSA.Chars(ie)
                                ElseIf ie = Num Then
                                    altu += 16
                                    e.Graphics.DrawString(cade, ft, Brushes.Black, 50, 270 + altu)
                                    cade = ""
                                    Num += 87
                                    ie -= 1
                                End If
                            Next
                            If cade.Length > 0 Then
                                altu += 16
                                e.Graphics.DrawString(cade, ft, Brushes.Black, 50, 270 + altu)
                                cade = ""
                            End If
                        Else
                            altu += 16
                            e.Graphics.DrawString("Obs.: " & mItem.DMD_GLOSA, ft, Brushes.Black, 50, 270 + altu)
                        End If

                        altu += 16
                    Else
                        altu += 16
                    End If
                Else
                    altu += 16
                End If

                If mNuevaPag = 50 Then
                    e.HasMorePages = True
                    mIndexItem = mFila + 1
                    Exit For
                Else
                    e.HasMorePages = False
                End If

            End If

        Next

        Dim Total As Nullable(Of Decimal) = (From mI In mDocu.DocuMovimientoDetalle Group mI By mI.DMO_ID Into g = Group Select g.Sum(Function(mI) CType(mI.DMD_CANTIDAD, Decimal?) * CType(IIf(CType(mI.DMD_DESCUENTO, Decimal?).ToString.Length > 0, CType(mI.DMD_PRECIO_UNITARIO, Decimal?) - (CType(mI.DMD_PRECIO_UNITARIO, Decimal?) * (CType(mI.DMD_DESCUENTO, Decimal?) / CType(100, Decimal?))), CType(mI.DMD_PRECIO_UNITARIO, Decimal?)), Decimal?))).FirstOrDefault

        e.Graphics.DrawString("Total:", ftN, Brushes.Black, 450, 300 + altu)
        e.Graphics.DrawString(IIf(mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1, Math.Round(CType(Total, Decimal), 2), ""), ftN, Brushes.Black, 700, 300 + altu)

        If mDocu.DetalleTipoDocumentos.DTD_E_S_ALMA = 1 Then ' es ingreso
            e.Graphics.DrawString("Elaborado por", ftN, Brushes.Black, 150, 300 + altu + 90)
        Else
            e.Graphics.DrawString("Despachado", ftN, Brushes.Black, 150, 300 + altu + 90)
            e.Graphics.DrawString("Recibi Conforme", ftN, Brushes.Black, 400, 300 + altu + 90)
        End If

    End Sub

    Private Sub txtTFO_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTFO.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "TransformacionID"

        If txtTFO.Text <> "" Then frm.Tipo = txtTFO.Text

        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            OnManNuevo()

            For Each oOpcionMenu As ToolStripItem In tsBarra.Items
                If oOpcionMenu.Name = "tsbAgregar" Or oOpcionMenu.Name = "tsbQuitar" Then
                    oOpcionMenu.Enabled = False
                End If
            Next

            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarTransformacion(key)

            txtSerie.Text = "013"
            txtNumero.Text = mTF.TFO_ID
            dtpFechaDoc.Value = mTF.TFO_FECHA
            txtTFO.Text = mTF.TFO_ID
            cboMoneda.SelectedIndex = 0
            chkAfectaKardex.Checked = True

            Dim EsSalida As Boolean = False
            If MessageBox.Show("La transformacion es una Salida?", "Atencion", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                For Each mDoc In cboTipoDocumento.Items
                    If mDoc(0).ToString.Substring(0, 3) = "196" Then 'Guia Salida DTD_ID
                        cboTipoDocumento.SelectedItem = mDoc
                        EsSalida = True
                        Exit For
                    End If
                Next
            Else
                For Each mDoc In cboTipoDocumento.Items
                    If mDoc(0).ToString.Substring(0, 3) = "195" Then 'Guia Ingreso DTD_ID
                        cboTipoDocumento.SelectedItem = mDoc
                        Exit For
                    End If
                Next
            End If

            'txtProveedor.Text = mOC.Personas.PER_NOMBRES
            'txtProveedor.Tag = mOC.PER_ID_PROVEEDOR

            For Each mItem In mTF.TransformacionDetalle
                If (mItem.TRD_CANTIDAD - mItem.TRD_CANTIDAD_ATENDIDA) > 0 Then
                    If mItem.TRD_ES_SALIDA = EsSalida Then
                        Dim nRow As New DataGridViewRow
                        dgvDetalle.Rows.Add(nRow)
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMD_ID").Value = mItem.DMD_ID
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DMD_ID").Tag = mItem
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Art_Id").Tag = mItem.ART_ID
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value = mItem.TRD_CANTIDAD - mItem.TRD_CANTIDAD_ATENDIDA
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TRD_ID").Tag = mItem.TRD_ID
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value = mItem.OCD_PRECIO_UNITARIO
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value = mItem.OCD_DESCUENTO

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value - _
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Cantidad").Value * (dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descuento").Value / 100)
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value * (txtIGV.Text / 100)
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Total").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("SubTotal").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("IGV").Value

                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Glosa").Value = mTF.TFO_OBSERVACION
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ALM_Id").Value = mItem.Almacen.ALM_DESCRIPCION
                        'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ALM_Id").Tag = mItem.ALM_ID

                        dgvDetalle_CellEndEdit(dgvDetalle, Nothing)
                    End If
                End If
            Next
        Else
            OnManNuevo()
        End If
        frm.Dispose()
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then txtProveedor_DoubleClick(Nothing, Nothing)
    End Sub

    'Private Sub txtAlmacenDestino_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then txtAlmacenDestino_DoubleClick(Nothing, Nothing)
    'End Sub

    Private Sub txtTFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTFO.KeyDown
        If e.KeyCode = Keys.Enter Then txtTFO_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Label6_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.DoubleClick
        Try
            If SessionServer.UserId <> "ADMIN" Then
                If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById(SessionServer.UserId & "DOCU1").PAR_VALOR1 Then
                        MessageBox.Show("No ha ingresado una clave valida. Se cancelara el cambio.")
                        dtpFecha.Enabled = False
                        dgvDetalle.Columns("Cantidad").ReadOnly = True
                        FlagPermisoModificacion = False
                    Else
                        dtpFecha.Enabled = True
                        dgvDetalle.Columns("Cantidad").ReadOnly = False
                        FlagPermisoModificacion = True
                    End If
                Else
                    MessageBox.Show("No ha ingresado una clave valida. Se cancelara el cambio.")
                    dtpFecha.Enabled = False
                    dgvDetalle.Columns("Cantidad").ReadOnly = True
                    FlagPermisoModificacion = False
                End If
            Else
                dtpFecha.Enabled = True
                dgvDetalle.Columns("Cantidad").ReadOnly = False
                FlagPermisoModificacion = True
            End If

        Catch ex As Exception
            FlagPermisoModificacion = False
            MessageBox.Show("No tiene permiso para ejecutar esta accion.")
        End Try

    End Sub

    Private Sub chkAfectaKardex_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAfectaKardex.CheckedChanged
        If mDocu IsNot Nothing Then
            If Not chkAfectaKardex.Checked Then
                MessageBox.Show("Al deshabilitar, no se grabara información en el Kardex")
            End If
        End If
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub
End Class
