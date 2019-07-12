Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Net.Mail

Namespace Ladisac.Logistica.Views


    Public Class frmOrdenCompra

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCOrdenCompra As Ladisac.BL.IBCOrdenCompra
        <Dependency()> _
        Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
        <Dependency()> _
        Public Property BCTipoVenta As Ladisac.BL.IBCTipoVenta
        <Dependency()> _
        Public Property BCMoneda As Ladisac.BL.IBCMoneda
        <Dependency()> _
        Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento
        <Dependency()> _
        Public Property BCParametro As Ladisac.BL.IBCParametro
        <Dependency()>
        Public Property BCPermisoUsuario As Ladisac.BL.BCPermisoUsuario
        <Dependency()> _
        Public Property BCOrdenRequerimiento As Ladisac.BL.IBCOrdenRequerimiento

        Public mOC As OrdenCompra
        Public mPCDE As New List(Of ProcesoCompraDetalle)
        Public mModiFromPC As Boolean
        Dim frmInputBox As New frmInputBox
        Public mCuCo As New List(Of CuadroComparativo)
        Public mProveeText As String
        Public mProveeTag As String
        Protected mOR As OrdenRequerimiento
        Public Consulta As Boolean

        Public Structure CuadroComparativo
            Public ART_ID As String
            Public Cantidad As Decimal
            Public PU As Decimal
        End Structure

        'ingreso de codigo
        Private Sub frmOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            CargarTipoVenta()
            CargarMoneda()

            Call validar_longitud()
            Call validacion_desactivacion(False, 1)

            If mPCDE.Count > 0 Then
                OnManNuevo()
                txtProveedor.Text = mProveeText
                txtProveedor.Tag = mProveeTag
                For Each mItem In mPCDE
                    Dim nRow As New DataGridViewRow
                    dgvDetalle.Rows.Add(nRow)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Tag = mItem.ART_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Tag = mItem
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PCD_ID").Value = mItem.PCD_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value = mItem.PCD_CANT
                Next

                For Each mRow As DataGridViewRow In dgvDetalle.Rows
                    For Each mItem In mCuCo
                        If mRow.Cells("ART_ID").Tag = mItem.ART_ID Then
                            mRow.Cells("Cantidad").Value = mItem.Cantidad
                            mRow.Cells("Total").Value = mItem.Cantidad * mItem.PU
                            dgvDetalle.CurrentCell = mRow.Cells("Total")
                            dgvDetalle_CellEndEdit(dgvDetalle, Nothing)
                        End If
                    Next
                Next
            End If

            If mOC IsNot Nothing Then
                If mOC.OCO_ID > 0 Then LlenarControles()
                Totales()
                '---------------------------------
                Call validacion_desactivacion(True, 5)
            End If

            txtNroCotizacion.TabIndex = 0
            txtCodigo.TabIndex = 11
            txtProveedor.TabIndex = 1
            dtpFechaEntrega.TabIndex = 2
            txtEntregarEn.TabIndex = 3
            cboTipoVenta.TabIndex = 4
            txtObservaciones.TabIndex = 5
            dtpFecha.TabIndex = 6
            cboMoneda.TabIndex = 7
            txtIGV.TabIndex = 8
            txtTipoCambio.TabIndex = 9
            dgvDetalle.TabIndex = 10

        End Sub

        'ingreso de codigo
        Sub LimpiarControles()
            mOC = Nothing
            txtCodigo.Text = String.Empty
            txtNroCotizacion.Text = String.Empty
            txtProveedor.Text = String.Empty
            txtProveedor.Tag = Nothing
            cboTipoVenta.SelectedIndex = -1
            dtpFecha.Value = Now
            dtpFechaEntrega.Value = Now
            txtIGV.Text = SessionServer.IGV
            txtTipoCambio.Text = 0
            txtEntregarEn.Text = "Variante de Uchumayo Km.4 Cerro Colorado, Arequipa-Perú"
            txtObservaciones.Text = String.Empty
            cboMoneda.SelectedIndex = -1
            dgvDetalle.Rows.Clear()
            TabControl1.SelectedIndex = 0
            picPre.Image = picPre.ErrorImage

            txtSubTotal.Text = 0
            txtTotalIgv.Text = 0
            txtTotal.Text = 0

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionOrdenCompra", New DataTable()))
            ReportViewer1.RefreshReport()

            TabControl1.SelectedIndex = 0

            '--------------------------
            Error_validacion.Clear()
        End Sub

        Sub CargarTipoVenta()
            Dim ds As New DataSet
            Dim query = BCTipoVenta.ListaTipoVenta
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            With cboTipoVenta
                .DisplayMember = "TIV_Descripcion"
                .ValueMember = "TIV_ID"
                .DataSource = ds.Tables(0)
            End With
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

        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            Select Case dgvDetalle.CurrentCell.ColumnIndex
                Case 2
                    frm.Tabla = "OrdenRequerimiento"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                        CargarOrdenRequerimiento(key)
                        For Each mItem In mOR.OrdenRequerimientoDetalle
                            If mItem.USU_ID_AUT Is Nothing Then Continue For
                            If mItem.ORD_CANTIDAD - mItem.ORD_CANTIDAD_ATENDIDA <= 0 Then Continue For
                            Dim nRow As New DataGridViewRow
                            dgvDetalle.Rows.Add(nRow)
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_Id").Value = mItem.ORR_ID
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_Id").Tag = mItem.ORD_ID
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ART_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION 'ART_Codigo
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ART_Id").Tag = mItem.ART_ID   'ART_Id
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_SIMBOLO  'UM
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value = mItem.ORD_CANTIDAD - mItem.ORD_CANTIDAD_ATENDIDA  'Cantidad
                        Next
                    End If

                Case 3
                    frm.Tabla = "Articulo"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
                        dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnidadMedida
                    End If
            End Select
            frm.Dispose()
        End Sub

        Sub CargarOrdenRequerimiento(ByVal ORR_Id As Integer)
            mOR = BCOrdenRequerimiento.OrdenRequerimientoGetById(ORR_Id)
            mOR.MarkAsModified()
        End Sub

        Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
            If Not e.Row.Cells("OCD_ID").Tag Is Nothing Then
                CType(e.Row.Cells("OCD_ID").Tag, OrdenCompraDetalle).MarkAsDeleted()
            End If
            Totales()
        End Sub

        Sub Totales()
            txtSubTotal.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("SubTotal").Value)), 2)
            txtTotalIgv.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("IGV").Value)), 2)
            txtTotal.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("Total").Value)), 2)
        End Sub

        Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
            Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                Case "Cantidad", "PU"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("PU").Value) * CDbl(CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value) - _
                     CDbl(CType(sender, DataGridView).CurrentRow.Cells("PU").Value) * CDbl(CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value) * (CDbl(CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value) / 100), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) * (CDbl(txtIGV.Text) / 100), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) + CDbl(CType(sender, DataGridView).CurrentRow.Cells("IGV").Value), 6)
                Case "Descuento"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("PU").Value) * CDbl(CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value) - _
                     CDbl(CType(sender, DataGridView).CurrentRow.Cells("PU").Value) * CDbl(CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value) * (CDbl(CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value) / 100), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) * (CDbl(txtIGV.Text) / 100), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) + CDbl(CType(sender, DataGridView).CurrentRow.Cells("IGV").Value), 6)
                Case "SubTotal"
                    CType(sender, DataGridView).CurrentRow.Cells("PU").Value = Math.Round((CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) / (1 - (CDbl(CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value) / 100))) / CDbl(CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) * (CDbl(txtIGV.Text) / 100), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) + CDbl(CType(sender, DataGridView).CurrentRow.Cells("IGV").Value), 6)
                Case "Total"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("Total").Value) / (((CDbl(txtIGV.Text) / 100)) + 1), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) * (CDbl(txtIGV.Text) / 100), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("PU").Value = Math.Round((CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) / (1 - (CDbl(CType(sender, DataGridView).CurrentRow.Cells("Descuento").Value) / 100))) / CDbl(CType(sender, DataGridView).CurrentRow.Cells("Cantidad").Value), 6)
                Case "OCD_OTROS1"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) + CDbl(CType(sender, DataGridView).CurrentRow.Cells("OCD_OTROS1").Value), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("Total").Value) + CDbl(CType(sender, DataGridView).CurrentRow.Cells("OCD_OTROS1").Value), 6)
            End Select

            Totales()
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManGuardar()
            If Consulta Then Exit Sub
            'cod ingresado q llama ala funcion para validar
            If Not validar_controles() Then Exit Sub
            '----------------------------------------------------

            If mOC IsNot Nothing Then
                dgvDetalle.EndEdit()

                If mOC.ChangeTracker.State = ObjectState.Modified Then
                    mOC.OCO_OBSERVACIONES = txtObservaciones.Text
                    If chkCerrada.Checked Then mOC.OCO_CERRADA = 1 Else mOC.OCO_CERRADA = 0
                Else
                    mOC.OCO_FECHA = dtpFecha.Value
                    mOC.OCO_NRO_COTIZACION = txtNroCotizacion.Text
                    mOC.PER_ID_PROVEEDOR = txtProveedor.Tag
                    mOC.TIV_ID_PAGO = cboTipoVenta.SelectedValue
                    mOC.MON_ID = cboMoneda.SelectedValue
                    mOC.OCO_FECHAENTREGA = dtpFechaEntrega.Value
                    mOC.OCO_ENTREGA = txtEntregarEn.Text
                    mOC.OCO_OBSERVACIONES = txtObservaciones.Text
                    mOC.OCO_ANTICIPO = numAnticipo.Value
                    mOC.OCO_IMPORTANCIA = cboImportancia.SelectedIndex
                    mOC.DTD_ID = "038"
                    mOC.TDO_ID = "013"
                    mOC.CCT_ID = "012"
                    If chkCerrada.Checked Then mOC.OCO_CERRADA = 1 Else mOC.OCO_CERRADA = 0
                End If

                mOC.OCO_ESTADO = True
                mOC.OCO_FEC_GRAB = Now
                mOC.USU_ID = SessionServer.UserId


                For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                    If Not mDetalle.Cells("OCD_ID").Value Is Nothing Then
                        With CType(mDetalle.Cells("OCD_ID").Tag, OrdenCompraDetalle)
                            '.ORD_ID = mDetalle.Cells("ORD_ID").Tag
                            '.ART_ID = mDetalle.Cells("ART_ID").Tag
                            '.OCD_DESCRIPCION = mDetalle.Cells("ART_ID").Value & " " & mDetalle.Cells("OCD_DESCRIPCION").Value
                            '.OCD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                            '.OCD_CANTIDAD_INGRESADA = CDec(mDetalle.Cells("CantIngresada").Value)
                            '.OCD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                            '.OCD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                            '.OCD_OTROS1 = CDec(mDetalle.Cells("OCD_OTROS1").Value)
                            '.OCD_OTROS2 = 0
                            '.OCD_OTROS3 = 0
                            '.OCD_IGV = txtIGV.Text
                            '.OCD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PU").Value)) * CDec(txtTipoCambio.Text) + CDec(mDetalle.Cells("OCD_OTROS1").Value)
                            .OCD_OBSERVACIONES = mDetalle.Cells("Observacion").Value
                            'If mDetalle.Cells("UM").Tag IsNot Nothing Then
                            '    .PCD_ID = CInt(mDetalle.Cells("PCD_ID").Value)
                            '    .ProcesoCompraDetalle = mDetalle.Cells("UM").Tag
                            'End If
                            .MarkAsModified()
                        End With
                    ElseIf Not mDetalle.Cells("Cantidad").Value Is Nothing Then
                        Dim nOCD As New OrdenCompraDetalle
                        With nOCD
                            .ORD_ID = IIf(mDetalle.Cells("ORD_Id").Tag Is Nothing, Nothing, CInt(mDetalle.Cells("ORD_Id").Tag))
                            .ART_ID = mDetalle.Cells("ART_Id").Tag
                            .OCD_DESCRIPCION = mDetalle.Cells("ART_ID").Value & " " & mDetalle.Cells("OCD_DESCRIPCION").Value
                            .OCD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                            .OCD_CANTIDAD_INGRESADA = CDec(mDetalle.Cells("CantIngresada").Value)
                            .OCD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                            .OCD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                            .OCD_OTROS1 = CDec(mDetalle.Cells("OCD_OTROS1").Value)
                            .OCD_OTROS2 = 0
                            .OCD_OTROS3 = 0
                            .OCD_IGV = txtIGV.Text
                            .OCD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PU").Value)) * CDec(txtTipoCambio.Text) + CDec(mDetalle.Cells("OCD_OTROS1").Value)
                            .OCD_OBSERVACIONES = mDetalle.Cells("Observacion").Value
                            If mDetalle.Cells("UM").Tag IsNot Nothing Then
                                .PCD_ID = CInt(mDetalle.Cells("PCD_ID").Value)
                                .ProcesoCompraDetalle = mDetalle.Cells("UM").Tag
                            End If
                            .MarkAsAdded()
                        End With
                        mOC.OrdenCompraDetalle.Add(nOCD)
                    End If
                Next

                For Each mDetalle As DataGridViewRow In dgvCuota.Rows
                    If Not mDetalle.Cells("OCC_ID").Value Is Nothing Then
                        With CType(mDetalle.Cells("OCC_ID").Tag, OrdenCompraCuotas)
                            .OCC_NUMERO = mDetalle.Cells("OCC_NUMERO").Value
                            .OCC_DESCRIPCION = mDetalle.Cells("OCC_DESCRIPCION").Value
                            .OCC_FECHA_VENCIMIENTO = mDetalle.Cells("OCC_FECHA_VENCIMIENTO").Value
                            .OCC_MONTO = CDec(mDetalle.Cells("OCC_MONTO").Value)
                            .MarkAsModified()
                        End With
                    ElseIf Not mDetalle.Cells("OCC_MONTO").Value Is Nothing Then
                        Dim nOCC As New OrdenCompraCuotas
                        With nOCC
                            .OCC_NUMERO = mDetalle.Cells("OCC_NUMERO").Value
                            .OCC_DESCRIPCION = mDetalle.Cells("OCC_DESCRIPCION").Value
                            .OCC_FECHA_VENCIMIENTO = mDetalle.Cells("OCC_FECHA_VENCIMIENTO").Value
                            .OCC_MONTO = CDec(mDetalle.Cells("OCC_MONTO").Value)
                            .MarkAsAdded()
                        End With
                        mOC.OrdenCompraCuotas.Add(nOCC)
                    End If
                Next

                If BCOrdenCompra.MantenimientoOrdenCompra(mOC) = 1 Then
                    MessageBox.Show(mOC.OCO_ID)
                    mOC = BCOrdenCompra.OrdenCompraGetById(mOC.OCO_ID)

                    If MessageBox.Show("Desea Imprimir la Orden de Compra?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                        TabControl1.SelectedIndex = 1
                    Else
                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        If mPCDE.Count > 0 Then
                            Me.Dispose()
                            Exit Sub
                        End If
                        LimpiarControles()
                        Call validacion_desactivacion(False, 3)
                    End If
                Else
                    MessageBox.Show("Error al insertar.")
                    LimpiarControles()
                    Exit Sub
                End If
            End If
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManNuevo()
            LimpiarControles()
            mOC = New OrdenCompra
            mOC.MarkAsAdded()
            '---------------------------------------
            Call validacion_desactivacion(True, 2)
            txtNroCotizacion.Focus()
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManBuscar()
            LimpiarControles()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            frm.Tabla = "OrdenCompra"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                CargarOrdenCompra(key)
                LlenarControles()
                Totales()
                '---------------------------------
                Call validacion_desactivacion(True, 5)
            End If
            frm.Dispose()
        End Sub

        Sub CargarOrdenCompra(ByVal OCO_Id As Integer)
            mOC = BCOrdenCompra.OrdenCompraGetById(OCO_Id)
            mOC.MarkAsModified()
        End Sub

        Sub LlenarControles()
            txtCodigo.Text = mOC.OCO_ID
            dtpFecha.Value = mOC.OCO_FECHA
            txtNroCotizacion.Text = mOC.OCO_NRO_COTIZACION
            txtProveedor.Text = mOC.Personas.PER_NOMBRES & " " & mOC.Personas.PER_APE_PAT
            txtProveedor.Tag = mOC.PER_ID_PROVEEDOR
            cboTipoVenta.SelectedValue = mOC.TIV_ID_PAGO
            cboMoneda.SelectedValue = mOC.MON_ID
            dtpFechaEntrega.Value = mOC.OCO_FECHAENTREGA
            txtEntregarEn.Text = mOC.OCO_ENTREGA
            txtObservaciones.Text = mOC.OCO_OBSERVACIONES
            numAnticipo.Value = mOC.OCO_ANTICIPO
            cboImportancia.SelectedIndex = mOC.OCO_IMPORTANCIA
            If mOC.OCO_CERRADA = 1 Then chkCerrada.Checked = True Else chkCerrada.Checked = False

            If Not mOC.OCO_ADJUNTO Is Nothing Then
                picPre.Image = picPre.InitialImage
            Else
                picPre.Image = picPre.ErrorImage
            End If

            For Each mItem In mOC.OrdenCompraDetalle
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OCD_ID").Value = mItem.OCD_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OCD_ID").Tag = mItem
                If mItem.ORD_ID IsNot Nothing Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_ID").Value = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mItem.ORD_ID).ORR_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_ID").Tag = mItem.ORD_ID
                End If
                'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OCD_DESCRIPCION").Value = mItem.OCD_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Tag = mItem.ART_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION

                If mItem.ProcesoCompraDetalle IsNot Nothing Then dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Tag = mItem.ProcesoCompraDetalle
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PCD_ID").Value = mItem.PCD_ID

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value = mItem.OCD_CANTIDAD
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CantIngresada").Value = mItem.OCD_CANTIDAD_INGRESADA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value = mItem.OCD_PRECIO_UNITARIO
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value = mItem.OCD_DESCUENTO
                txtIGV.Text = mItem.OCD_IGV
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OCD_OTROS1").Value = mItem.OCD_OTROS1
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value - _
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value * (dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value / 100)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value * (txtIGV.Text / 100)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Total").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OCD_OTROS1").Value

                If (mItem.OCD_PRECIO_UNITARIO * mItem.OCD_CANTIDAD) > 0 Then txtTipoCambio.Text = mItem.OCD_CONTRAVALOR / (mItem.OCD_PRECIO_UNITARIO * mItem.OCD_CANTIDAD) Else txtTipoCambio.Text = 0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Observacion").Value = mItem.OCD_OBSERVACIONES
            Next

            For Each mItem In mOC.OrdenCompraCuotas
                Dim nRow As New DataGridViewRow
                dgvCuota.Rows.Add(nRow)
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OCC_ID").Value = mItem.OCC_ID
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OCC_ID").Tag = mItem
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OCC_NUMERO").Value = mItem.OCC_NUMERO
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OCC_DESCRIPCION").Value = mItem.OCC_DESCRIPCION
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OCC_FECHA_VENCIMIENTO").Value = mItem.OCC_FECHA_VENCIMIENTO
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OCC_MONTO").Value = mItem.OCC_MONTO
            Next

            '''''Para saber quien lo hizo
            Dim Hecho As Usuarios
            Hecho = BCPermisoUsuario.UsuarioGetById(mOC.USU_ID)
            lblHecho.Text = "Hecho por: " & Hecho.USU_DESCRIPCION
        End Sub

        Private Sub cboMoneda_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMoneda.SelectedValueChanged
            txtTipoCambio.Text = BCDocuMovimiento.TCCompraDia(cboMoneda.SelectedValue, dtpFecha.Value)
        End Sub

        '===================================================================================================================
        '----procedimiento de validaciones
        'tecla enter de paso rapido entre cajas de texto.
        'validamos los campos a llenar
        Function validar_controles()
            'aqui se ingresara los objetos del formulario a validar
            Dim flag As Boolean = True

            Error_validacion.Clear()
            'If Len(txtNroCotizacion.Text.Trim) = 0 Then Error_validacion.SetError(txtNroCotizacion, "Ingrese el Numero de Cotización") : txtNroCotizacion.Focus() : flag = False
            If Len(txtProveedor.Text.Trim) = 0 Or txtProveedor.Tag.ToString.Length = 0 Then Error_validacion.SetError(txtProveedor, "Ingrese el Nombre del Proveedor") : txtProveedor.Focus() : flag = False
            If Len(txtEntregarEn.Text.Trim) = 0 Then Error_validacion.SetError(txtEntregarEn, "Ingrese el Lugar de Entrega") : txtEntregarEn.Focus() : flag = False
            If Len(cboTipoVenta.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoVenta, "Ingrese el Tipo de Venta") : cboTipoVenta.Focus() : flag = False
            If Len(txtObservaciones.Text.Trim) = 0 Then Error_validacion.SetError(txtObservaciones, "Ingrese las Observaciones") : txtObservaciones.Focus() : flag = False
            If Len(cboMoneda.Text.Trim) = 0 Then Error_validacion.SetError(cboMoneda, "Ingrese el Tipo de Moneda") : cboMoneda.Focus() : flag = False
            If Len(txtIGV.Text.Trim) = 0 Then Error_validacion.SetError(txtIGV, "Ingrese el IGV") : txtIGV.Focus() : flag = False
            If Len(txtTipoCambio.Text.Trim) = 0 OrElse txtTipoCambio.Text = 0 Then Error_validacion.SetError(txtTipoCambio, "Ingrese el Tipo de Cambio") : txtTipoCambio.Focus() : flag = False


            'POR DETALLE
            For Each mFila As DataGridViewRow In dgvDetalle.Rows
                If mFila.IsNewRow = False Then
                    If mFila.Cells("ART_ID").Tag Is Nothing OrElse mFila.Cells("ART_ID").Tag = 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Tipo de Cambio")
                        flag = False
                        MessageBox.Show("Falta seleccionar el articulo en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If CDbl(mFila.Cells("Cantidad").Value) <= 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Tipo de Cambio")
                        flag = False
                        MessageBox.Show("La cantidad debe ser mayor a cero.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If CDbl(mFila.Cells("Total").Value) <= 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Tipo de Cambio")
                        flag = False
                        MessageBox.Show("El total debe ser mayor a cero.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                End If
            Next

            If flag = False Then
                MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            If (mOC.ChangeTracker.State = ObjectState.Modified Or mOC.ChangeTracker.State = ObjectState.Added) And mPCDE.Count = 0 And mModiFromPC = False Then
                If SessionServer.UserId <> "ADMIN" Then
                    If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
                        If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById(SessionServer.UserId & "OC").PAR_VALOR1 Then
                            MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                            flag = False
                        End If
                    Else
                         MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
                        flag = False
                    End If
                End If
            End If

            Return flag
        End Function

        'validamos la longitud de los campos.
        Private Sub validar_longitud()
            Me.txtNroCotizacion.MaxLength = 10
            Me.txtProveedor.MaxLength = 160
            Me.txtEntregarEn.MaxLength = 255
            Me.cboTipoVenta.DropDownStyle = ComboBoxStyle.DropDownList
            Me.txtObservaciones.MaxLength = 255
            Me.cboMoneda.DropDownStyle = ComboBoxStyle.DropDownList
            Me.txtIGV.MaxLength = 6
            Me.txtTipoCambio.MaxLength = 18

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

        Public Overrides Sub OnManEliminar()
            If mOC IsNot Nothing Then
                If MessageBox.Show("Seguro de Eliminar el Documento?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then

                    For Each mItem In mOC.OrdenCompraDetalle
                        If mItem.OCD_CANTIDAD_INGRESADA > 0 Then
                            MessageBox.Show("No se puede eliminar la O.C. por que hay Items ingresados.")
                            Exit Sub
                        End If
                    Next

                    'For Cont As Integer = mOC.OrdenCompraDetalle.Count - 1 To 0 Step -1
                    '    mOC.OrdenCompraDetalle(Cont).MarkAsDeleted()
                    'Next
                    'mOC.MarkAsDeleted()
                    mOC.OCO_ESTADO = False
                    mOC.OCO_CERRADA = 1

                    BCOrdenCompra.MantenimientoOrdenCompra(mOC)
                    Call LimpiarControles()
                    Call validacion_desactivacion(False, 7)
                End If
            End If
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
                'Me.tscPosicion.Enabled = Not op
                Me.tsbReportes.Enabled = Not op


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
                Me.tsbReportes.Enabled = Not op
                Me.tsbNuevo.Enabled = False
                'Me.TabControl1.TabPages(0).Enabled = False 'agregado

            End If
        End Sub

        Public Overrides Sub OnReportes()
            Me.TabControl1.SelectedTab = TabPage2
            Call validacion_desactivacion(True, 2)
        End Sub

        Sub Visualizar()
            Try
                If mOC IsNot Nothing Then
                    Dim Lista1 = From mItem In mOC.OrdenCompraDetalle Group mItem By UsuId = mItem.USU_ID_AUT_2 Into Gpr = Group _
                                        Select UsuId, Total = Gpr.Sum(Function(mItem) CDec(mItem.OCD_CONTRAVALOR) + (CDec(mItem.OCD_CONTRAVALOR) * CDec(mItem.OCD_IGV / 100)))

                    For Each mItem In Lista1.ToList
                        If mItem.Total > BCParametro.ParametroGetById(mItem.UsuId).PAR_VALOR1 Then
                            For cont As Integer = mOC.OrdenCompraDetalle.Count - 1 To 0 Step -1
                                If mOC.OrdenCompraDetalle(cont).USU_ID_AUT_2 = mItem.UsuId And mOC.OrdenCompraDetalle(cont).USU_ID_AUT_3 Is Nothing Then
                                    If Not (mOC.OrdenCompraDetalle(cont).ART_ID = BCParametro.ParametroGetById("Diesel").PAR_VALOR1 Or mOC.OrdenCompraDetalle(cont).ART_ID = BCParametro.ParametroGetById("R500").PAR_VALOR1) Then
                                        MsgBox("No está aprobada por Gerencia General.")
                                        Exit Sub
                                    End If
                                End If
                            Next
                        End If
                    Next

                    Dim mTt = (From mItem In mOC.OrdenCompraDetalle Select mItem.OCD_CONTRAVALOR).Sum
                    If mTt > BCParametro.ParametroGetById("RBERRIOS").PAR_VALOR1 Then
                        For cont As Integer = mOC.OrdenCompraDetalle.Count - 1 To 0 Step -1
                            If mOC.OrdenCompraDetalle(cont).USU_ID_AUT_4 Is Nothing Then
                                If Not (mOC.OrdenCompraDetalle(cont).ART_ID = BCParametro.ParametroGetById("Diesel").PAR_VALOR1 Or mOC.OrdenCompraDetalle(cont).ART_ID = BCParametro.ParametroGetById("R500").PAR_VALOR1) Then
                                    MsgBox("No está aprobada por Gerencia de Finanzas.")
                                    Exit Sub
                                End If
                            End If
                        Next
                    End If


                    'Impresion
                    Dim ds As New DataSet
                    Dim query = BCOrdenCompra.ImpresionOrdenCompra(mOC.OCO_ID)
                    Dim rea As New StringReader(query)
                    ds.ReadXml(rea)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionOrdenCompra", ds.Tables(0)))
                    'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                    Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
                    parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("USU_ID", mOC.USU_ID)
                    ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
                    Me.ReportViewer1.LocalReport.SetParameters(parametro)
                    ReportViewer1.RefreshReport()
                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
            If TabControl1.SelectedIndex = 1 Then
                Visualizar()
            End If
        End Sub

        Private Sub ReportViewer1_Print(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ReportViewer1.Print
            ''Me.DialogResult = Windows.Forms.DialogResult.OK
            'If mPCDE.Count > 0 Then
            '    Me.DialogResult = Windows.Forms.DialogResult.OK
            '    Me.Close()
            '    Exit Sub
            'End If
            'LimpiarControles()
            'Call validacion_desactivacion(False, 3)
        End Sub

        Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
            If e.KeyCode = Keys.Enter Then txtProveedor_DoubleClick(Nothing, Nothing)
        End Sub

        Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
            If e.KeyCode = Keys.Enter Then
                dgvDetalle_CellDoubleClick(sender, Nothing)
            End If
            'Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            'If e.KeyCode = Keys.Enter Then
            '    Select Case dgvDetalle.CurrentCell.ColumnIndex
            '        Case 1
            '            frm.Tabla = "OrdenRequerimiento"
            '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ORD_Id
            '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(1).Value  'ORD_Id
            '                dgvDetalle.CurrentRow.Cells("Art_id").Value = frm.dgvLista.CurrentRow.Cells(3).Value & " - " & frm.dgvLista.CurrentRow.Cells(4).Value 'ART_Codigo
            '                dgvDetalle.CurrentRow.Cells("Art_id").Tag = frm.dgvLista.CurrentRow.Cells(2).Value  'ART_Id
            '                dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(5).Value  'UM
            '                dgvDetalle.CurrentRow.Cells("Cantidad").Value = frm.dgvLista.CurrentRow.Cells(6).Value  'Cantidad
            '            End If
            '        Case 2
            '            frm.Tabla = "Articulo"
            '            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
            '                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
            '                dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnidadMedida
            '            End If
            '    End Select
            'End If
            'frm.Dispose()
        End Sub

        Private Sub EnviarEmail(ByVal mOC As OrdenCompra)
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            Dim eTo, eNuestroCorreo, eNuestraContraseña As String

            Try
                eNuestroCorreo = "sistemas@ladrilleraeldiamante.com"
                eNuestraContraseña = "Sistemas1"
                SmtpServer.Port = 25
                SmtpServer.Host = "mail.ladrilleraeldiamante.com"
                SmtpServer.EnableSsl = False
                SmtpServer.Credentials = New Net.NetworkCredential(eNuestroCorreo, eNuestraContraseña)
                mail = New MailMessage()
                mail.From = New MailAddress(eNuestroCorreo)
                mail.Subject = "Orden Compra Generada"
                mail.Body = "Orden Compra Nro.: " & mOC.OCO_ID & vbCrLf & _
                    "Proveedor: " & mOC.Personas.PER_APE_PAT & vbCrLf & _
                    "Monto: " & txtTotal.Text


                mail.IsBodyHtml = False

                'For Each mDestinatario In gridDestinatarios.Rows
                mail.To.Clear()
                'Destinatario del Mensaje
                'eTo = "ynunez@ladrilleraeldiamante.com"
                'Destinatarios del correo
                'mail.To.Add(eTo)
                mail.To.Add("ynunez@ladrilleraeldiamante.com")
                mail.To.Add("msaira@ladrilleraeldiamante.com")
                'Le decimos que envíe el correo
                SmtpServer.Send(mail)
                'Next

                'Msgbox dando el Ok del envío
                MsgBox("Correo enviado")
            Catch ex As Exception
                'Msgbox informandonos si existiera algún error
                MsgBox(ex.ToString)
            End Try
        End Sub

        Private Sub btnEnviarCorreo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnviarCorreo.Click
            EnviarEmail(mOC)
        End Sub

        Private Function ReadBinaryFile(ByVal fileName As String) As Byte()

            ' Si no existe el archivo, abandono la función.
            '
            If Not System.IO.File.Exists(fileName) Then Return Nothing

            Try
                ' Creamos un objeto Stream para poder leer el archivo especificado.
                '
                Dim fs As New FileStream(fileName, FileMode.Open, FileAccess.Read)

                ' Creamos un array de bytes, cuyo límite superior se corresponderá
                ' con la longitud en bytes de la secuencia.
                '
                Dim data() As Byte = New Byte(Convert.ToInt32(fs.Length - 1)) {}

                ' Al leer la secuencia, se rellenará la matriz.
                '
                fs.Read(data, 0, Convert.ToInt32(fs.Length))

                ' Cerramos la secuencia.
                '
                fs.Close()

                ' Devolvemos el array de bytes.
                '
                Return data

            Catch ex As Exception
                ' Cualquier excepción producida, hace que la
                ' función devuelva el valor Nothing.
                '
                Return Nothing

            End Try

        End Function

        Private Sub tooAdPreCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdPreCargar.Click
            If Me.ofdImagen.ShowDialog() = Windows.Forms.DialogResult.OK Then
                mOC.OCO_ADJUNTO = ReadBinaryFile(ofdImagen.FileName)
                mOC.OCO_ADJUNTO_DESCRI = ofdImagen.SafeFileName
                picPre.Image = picPre.InitialImage
            End If
        End Sub

        Private Sub tooAdPreDescargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdPreDescargar.Click
            If mOC.OCO_ADJUNTO IsNot Nothing Then
                Dim bits As Byte() = DirectCast(mOC.OCO_ADJUNTO, Byte())
                sfdImagen.FileName = mOC.OCO_ADJUNTO_DESCRI
                If sfdImagen.ShowDialog = DialogResult.OK Then
                    Dim fs As New FileStream(sfdImagen.FileName, FileMode.Create)
                    fs.Write(bits, 0, Convert.ToInt32(bits.Length))
                    fs.Close()
                    MessageBox.Show("El Archivo se guardo y se mostrara.")
                    Process.Start(sfdImagen.FileName)
                End If
            End If
        End Sub

        Private Sub tooAdPreEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdPreEliminar.Click
            If mOC.OCO_ADJUNTO IsNot Nothing Then
                mOC.OCO_ADJUNTO = Nothing
                mOC.OCO_ADJUNTO_DESCRI = String.Empty
                picPre.Image = picPre.ErrorImage
            End If
        End Sub

    End Class
End Namespace