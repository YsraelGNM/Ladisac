Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Net.Mail

Namespace Ladisac.Logistica.Views


    Public Class frmOrdenServicio

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
        <Dependency()> _
        Public Property BCOrdenServicio As Ladisac.BL.IBCOrdenServicio
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
        <Dependency()> _
        Public Property BCOrdenTrabajo As Ladisac.BL.IBCOrdenTrabajo
        <Dependency()> _
        Public Property BCTipoDocumento As Ladisac.BL.IBCTipoDocumento
        <Dependency()> _
        Public Property BCEntidad As Ladisac.BL.IBCEntidad
        <Dependency()> _
        Public Property BCArticulo As Ladisac.BL.IBCArticulo

        Public mOS As OrdenServicio
        Public mOT As OrdenTrabajo
        Public mOR As OrdenRequerimiento
        Public mModiFromPC As Boolean
        Dim frmInputBox As New frmInputBox
        Public mCuCo As New List(Of CuadroComparativo)
        Public mProveeText As String
        Public mProveeTag As String
        Public Consulta As Boolean

        Public Structure CuadroComparativo
            Public ART_ID As String
            Public Cantidad As Decimal
            Public PU As Decimal
        End Structure

        'ingreso de codigo
        Private Sub frmOrdenServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            CargarTipoDocumento()
            CargarTipoVenta()
            CargarMoneda()

            Call validar_longitud()
            Call validacion_desactivacion(False, 1)


            If mOS IsNot Nothing Then
                If mOS.OSE_ID > 0 Then LlenarControles()
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

            CargarColumnCboTipoDocumento()
            CargarColumnCboTipoMoneda()

        End Sub

        Sub CargarTipoDocumento()
            Dim ds As New DataSet
            Dim query = BCTipoDocumento.ListaDetalleTipoDocumentoServicio
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            cboTipoDocumento.DisplayMember = "DTD_DESCRIPCION"
            cboTipoDocumento.ValueMember = "Codigo"
            cboTipoDocumento.SelectedIndex = -1
            cboTipoDocumento.DataSource = ds.Tables("DetalleTipoDocumentoServicio")
        End Sub

        'ingreso de codigo
        Sub LimpiarControles()
            mOS = Nothing
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
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionOrdenServicio", New DataTable()))
            ReportViewer1.RefreshReport()

            TabControl1.SelectedIndex = 0

            dgvDetalleGrupo.Rows.Clear()

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

        Sub CargarOrdenRequerimiento(ByVal ORR_Id As Integer)
            mOR = BCOrdenRequerimiento.OrdenRequerimientoGetById(ORR_Id)
            mOR.MarkAsModified()
        End Sub

        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            Dim Her = ContainerService.Resolve(Of Herramientas)()
            Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
                Case "ORD_Id"
                    frm.Tabla = "OrdenRequerimientoServicio"
                    If dgvDetalle.CurrentCell.Value > 0 Then
                        frm.Tipo = " Codigo = " & dgvDetalle.CurrentCell.Value
                    Else
                        frm.Tipo = " Codigo = Codigo"
                    End If

                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                        CargarOrdenRequerimiento(key)
                        If mOR IsNot Nothing Then If Not dgvDetalle.CurrentRow.IsNewRow Then dgvDetalle.Rows.Remove(dgvDetalle.CurrentRow)
                        For Each mItem In mOR.OrdenRequerimientoDetalle
                            If mItem.USU_ID_AUT Is Nothing Then Continue For
                            If mItem.ORD_CANTIDAD - mItem.ORD_CANTIDAD_ATENDIDA <= 0 Then Continue For
                            If Her.PermisoEntidad(mItem.ENO_ID) = False Then MsgBox("No le corresponde esta Area.") : Continue For
                            Dim nRow As New DataGridViewRow
                            dgvDetalle.Rows.Add(nRow)
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_Id").Value = mItem.ORR_ID
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_Id").Tag = mItem.ORD_ID
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ART_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION 'ART_Codigo
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ART_Id").Tag = mItem.ART_ID   'ART_Id
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_SIMBOLO  'UM
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value = mItem.ORD_CANTIDAD - mItem.ORD_CANTIDAD_ATENDIDA  'Cantidad
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OTR_ID").Value = mItem.OTR_ID 'OrdenTrabajo
                            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ENO_ID").Tag = mItem.ENO_ID 'Entidad
                        Next
                    End If
                Case "ART_Id"
                    frm.Tabla = "ArticuloServicio"
                    frm.Tipo = dgvDetalle.CurrentCell.Value
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("ART_ID").Value 'ART_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value & " - " & frm.dgvLista.CurrentRow.Cells(1).Value 'ART_Descripcion
                        dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(2).Value  'UnidadMedida
                    End If
                Case "ENO_ID"
                    frm.Tabla = "Entidad"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        If Her.PermisoEntidad(frm.dgvLista.CurrentRow.Cells(0).Value) = False Then
                            MessageBox.Show("No le corresponde esta Area.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        Else
                            dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " --//-- " & frm.dgvLista.CurrentRow.Cells(2).Value  'ENO_DESCRIPCION
                            dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_ID
                        End If
                    End If
                Case "OTR_ID"
                    frm.Tabla = "OrdenTrabajoOR"
                    frm.Tipo = dgvDetalle.CurrentCell.Value
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value  'OTR_Id
                        mOT = BCOrdenTrabajo.OrdenTrabajoGetById(key)
                        If Her.PermisoEntidad(mOT.ENO_ID) = False Then MsgBox("No le corresponde esta Area.") : frm.Dispose() : Exit Sub
                        dgvDetalle.CurrentCell.Value = mOT.OTR_ID
                        dgvDetalle.CurrentRow.Cells("ENO_ID").Value = mOT.Entidad.ENO_DESCRIPCION
                        dgvDetalle.CurrentRow.Cells("ENO_ID").Tag = mOT.ENO_ID
                    End If
            End Select
            frm.Dispose()
        End Sub

        Private Sub dgvDetalle_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetalle.CurrentCellChanged
            Try
                If dgvDetalle.CurrentRow.Cells("ENO_ID").Value.ToString.Length > 0 Then
                    lblRuta.Text = dgvDetalle.CurrentRow.Cells("ENO_ID").Value
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
            If Not e.Row.Cells("OSD_ID").Tag Is Nothing Then
                CType(e.Row.Cells("OSD_ID").Tag, OrdenServicioDetalle).MarkAsDeleted()
            End If
            Totales()
        End Sub

        Sub Totales()
            txtSubTotal.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("SubTotal").Value)), 2)
            txtTotalIgv.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("IGV").Value)), 2)
            txtTotal.Text = Math.Round(dgvDetalle.Rows.Cast(Of DataGridViewRow).AsEnumerable.Sum(Function(row) Convert.ToDouble(row.Cells("Total").Value)), 2)
        End Sub

        Private Sub cboTipoDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoDocumento.SelectedIndexChanged
            If mOS IsNot Nothing Then
                If cboTipoDocumento.SelectedIndex > -1 Then cboTipoDocumento.Tag = BCTipoDocumento.TipoDocumentoGetById(cboTipoDocumento.SelectedValue.ToString.Substring(0, 3)) : If cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "066" Or cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "038" Or cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "082" Or cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "144" Or cboTipoDocumento.SelectedValue.ToString.Substring(0, 3) = "216" Then txtIGV.Text = SessionServer.IGV Else txtIGV.Text = "0"
                If RTrim(cboTipoDocumento.SelectedValue) = "057038" Then
                    cboMoneda.SelectedIndex = 0
                End If
            End If
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
                Case "OSD_OTROS1"
                    CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SubTotal").Value) + CDbl(CType(sender, DataGridView).CurrentRow.Cells("OSD_OTROS1").Value), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("Total").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("Total").Value) + CDbl(CType(sender, DataGridView).CurrentRow.Cells("OSD_OTROS1").Value), 6)
            End Select

            Totales()
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManGuardar()
             Select TabControl1.SelectedIndex
                Case 0
                    If Consulta Then Exit Sub
                    'cod ingresado q llama ala funcion para validar
                    If Not validar_controles() Then Exit Sub
                    '----------------------------------------------------

                    If mOS IsNot Nothing Then
                        dgvDetalle.EndEdit()
                        mOS.OSE_FECHA = dtpFecha.Value
                        mOS.OSE_NRO_COTIZACION = txtNroCotizacion.Text
                        mOS.PER_ID_PROVEEDOR = txtProveedor.Tag
                        mOS.TIV_ID_PAGO = cboTipoVenta.SelectedValue
                        mOS.MON_ID = cboMoneda.SelectedValue
                        mOS.OSE_FECHAENTREGA = dtpFechaEntrega.Value
                        mOS.OSE_ENTREGA = txtEntregarEn.Text
                        mOS.OSE_OBSERVACIONES = txtObservaciones.Text
                        mOS.OSE_ANTICIPO = numAnticipo.Value
                        mOS.OSE_IMPORTANCIA = cboImportancia.SelectedIndex
                        If chkConformidad.Checked Then mOS.OSE_CONFORMIDAD = 1 Else mOS.OSE_CONFORMIDAD = 0
                        If chkCerrada.Checked Then mOS.OSE_CERRADA = 1 Else mOS.OSE_CERRADA = 0
                        mOS.OSE_ESTADO = True
                        mOS.OSE_FEC_GRAB = Now
                        mOS.USU_ID = SessionServer.UserId

                        mOS.DTD_ID = cboTipoDocumento.SelectedValue.ToString.Substring(0, 3)
                        mOS.TDO_ID = cboTipoDocumento.SelectedValue.ToString.Substring(3, 3)
                        If cboTipoDocumento.SelectedValue.ToString.Length = 9 Then mOS.CCT_ID = cboTipoDocumento.SelectedValue.ToString.Substring(6, 3) Else mOS.CCT_ID = ""


                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("OSD_ID").Value Is Nothing Then
                                With CType(mDetalle.Cells("OSD_ID").Tag, OrdenServicioDetalle)
                                    .ORD_ID = mDetalle.Cells("ORD_ID").Tag
                                    .ART_ID = mDetalle.Cells("ART_ID").Tag
                                    .OSD_DESCRIPCION = mDetalle.Cells("ART_ID").Value & " " & mDetalle.Cells("OSD_DESCRIPCION").Value
                                    .OSD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                                    .OSD_CANTIDAD_INGRESADA = CDec(mDetalle.Cells("CantIngresada").Value)
                                    .OSD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                                    .OSD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                                    .OSD_OTROS1 = CDec(mDetalle.Cells("OSD_OTROS1").Value)
                                    .OSD_OTROS2 = 0
                                    .OSD_OTROS3 = 0
                                    .OSD_IGV = txtIGV.Text
                                    .OSD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PU").Value)) * CDec(txtTipoCambio.Text) + CDec(mDetalle.Cells("OSD_OTROS1").Value)
                                    .OSD_OBSERVACIONES = mDetalle.Cells("Observacion").Value
                                    .ENO_ID = CInt(mDetalle.Cells("ENO_ID").Tag)
                                    .OTR_ID = mDetalle.Cells("OTR_ID").Value
                                    .MarkAsModified()
                                End With
                            ElseIf Not mDetalle.Cells("Cantidad").Value Is Nothing Then
                                Dim nOCD As New OrdenServicioDetalle
                                With nOCD
                                    .ORD_ID = IIf(mDetalle.Cells("ORD_Id").Tag Is Nothing, Nothing, CInt(mDetalle.Cells("ORD_Id").Tag))
                                    .ART_ID = mDetalle.Cells("ART_Id").Tag
                                    .OSD_DESCRIPCION = mDetalle.Cells("ART_ID").Value & " " & mDetalle.Cells("OSD_DESCRIPCION").Value
                                    .OSD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                                    .OSD_CANTIDAD_INGRESADA = CDec(mDetalle.Cells("CantIngresada").Value)
                                    .OSD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                                    .OSD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                                    .OSD_OTROS1 = CDec(mDetalle.Cells("OSD_OTROS1").Value)
                                    .OSD_OTROS2 = 0
                                    .OSD_OTROS3 = 0
                                    .OSD_IGV = txtIGV.Text
                                    .OSD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PU").Value)) * CDec(txtTipoCambio.Text) + CDec(mDetalle.Cells("OSD_OTROS1").Value)
                                    .OSD_OBSERVACIONES = mDetalle.Cells("Observacion").Value
                                    .ENO_ID = CInt(mDetalle.Cells("ENO_ID").Tag)
                                    .OTR_ID = mDetalle.Cells("OTR_ID").Value
                                    .MarkAsAdded()
                                End With
                                mOS.OrdenServicioDetalle.Add(nOCD)
                            End If
                        Next


                        For Each mDetalle As DataGridViewRow In dgvCuota.Rows
                            If Not mDetalle.Cells("OSC_ID").Value Is Nothing Then
                                With CType(mDetalle.Cells("OSC_ID").Tag, OrdenServicioCuotas)
                                    .OSC_NUMERO = mDetalle.Cells("OSC_NUMERO").Value
                                    .OSC_DESCRIPCION = mDetalle.Cells("OSC_DESCRIPCION").Value
                                    .OSC_FECHA_VENCIMIENTO = mDetalle.Cells("OSC_FECHA_VENCIMIENTO").Value
                                    .OSC_MONTO = CDec(mDetalle.Cells("OSC_MONTO").Value)
                                    .MarkAsModified()
                                End With
                            ElseIf Not mDetalle.Cells("OSC_MONTO").Value Is Nothing Then
                                Dim nOSC As New OrdenServicioCuotas
                                With nOSC
                                    .OSC_NUMERO = mDetalle.Cells("OSC_NUMERO").Value
                                    .OSC_DESCRIPCION = mDetalle.Cells("OSC_DESCRIPCION").Value
                                    .OSC_FECHA_VENCIMIENTO = mDetalle.Cells("OSC_FECHA_VENCIMIENTO").Value
                                    .OSC_MONTO = CDec(mDetalle.Cells("OSC_MONTO").Value)
                                    .MarkAsAdded()
                                End With
                                mOS.OrdenServicioCuotas.Add(nOSC)
                            End If
                        Next

                        ''Autoaprobacion menor a 301
                        'If (txtTotal.Text * txtTipoCambio.Text) <= BCParametro.ParametroGetById("MontoServicio").PAR_VALOR1 Then
                        '    For Each mItem In mOS.OrdenServicioDetalle
                        '        'Para cuentas contables de servicios
                        '        Select Case EntidadReversa(mItem.ENO_ID)
                        '            Case "1"
                        '                mItem.CUC_ID = BCArticulo.ArticuloGetById(mItem.ART_ID).CUC_ID_1
                        '            Case "2"
                        '                mItem.CUC_ID = BCArticulo.ArticuloGetById(mItem.ART_ID).CUC_ID_2
                        '            Case "3"
                        '                mItem.CUC_ID = BCArticulo.ArticuloGetById(mItem.ART_ID).CUC_ID_3
                        '            Case "4"
                        '                mItem.CUC_ID = BCArticulo.ArticuloGetById(mItem.ART_ID).CUC_ID_4
                        '            Case Else
                        '                mItem.CUC_ID = Nothing
                        '        End Select

                        '        mItem.USU_ID_AUT_2 = SessionServer.UserId
                        '        mItem.OSD_FEC_AUT_2 = Now
                        '    Next
                        'End If


                        If BCOrdenServicio.MantenimientoOrdenServicio(mOS) = 1 Then
                            MessageBox.Show(mOS.OSE_ID)
                            mOS = BCOrdenServicio.OrdenServicioGetById(mOS.OSE_ID)

                            If MessageBox.Show("Desea Imprimir la Orden de Servicio?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                                TabControl1.SelectedIndex = 1
                            Else
                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                LimpiarControles()
                                Call validacion_desactivacion(False, 3)
                            End If
                        Else
                            MessageBox.Show("Error al insertar.")
                            LimpiarControles()
                            Exit Sub
                        End If
                    End If

                Case 3

                    dgvDetalleGrupo.EndEdit()

                    If Not validar_controles2() Then Exit Sub
                    '----------------------------------------------------

                    If mOS IsNot Nothing Then

                        For Each mDetalle As DataGridViewRow In dgvDetalleGrupo.Rows

                            mOS.OSE_FECHA = mDetalle.Cells("OSE_FECHA2").Value
                            mOS.OSE_NRO_COTIZACION = ""
                            mOS.PER_ID_PROVEEDOR = mDetalle.Cells("PER_ID_PROVEEDOR2").Tag
                            mOS.TIV_ID_PAGO = "001" 'CONTADO
                            mOS.MON_ID = mDetalle.Cells("TipoMoneda").Value
                            mOS.OSE_FECHAENTREGA = mDetalle.Cells("OSE_FECHA2").Value
                            mOS.OSE_ENTREGA = ""
                            mOS.OSE_OBSERVACIONES = mDetalle.Cells("OSD_OBSERVACIONES2").Value
                            mOS.OSE_ANTICIPO = 0
                            mOS.OSE_IMPORTANCIA = 0
                            mOS.OSE_CONFORMIDAD = 1
                            mOS.OSE_CERRADA = 0
                            mOS.OSE_ESTADO = True
                            mOS.OSE_FEC_GRAB = Now
                            mOS.USU_ID = SessionServer.UserId

                            mOS.DTD_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(0, 3)
                            mOS.TDO_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(3, 3)
                            If mDetalle.Cells("TipoDocumento").Value.ToString.Trim.Length = 9 Then mOS.CCT_ID = mDetalle.Cells("TipoDocumento").Value.ToString.Substring(6, 3) Else mOS.CCT_ID = ""

                            Dim nOCD As New OrdenServicioDetalle
                            With nOCD
                                .ORD_ID = Nothing
                                .ART_ID = mDetalle.Cells("ART_ID2").Tag
                                .OSD_DESCRIPCION = mDetalle.Cells("ART_ID2").Value & " " & mDetalle.Cells("DESCRIPCION2").Value
                                .OSD_CANTIDAD = CDec(mDetalle.Cells("OSD_CANTIDAD2").Value)
                                .OSD_CANTIDAD_INGRESADA = 0
                                .OSD_DESCUENTO = 0
                                .OSD_PRECIO_UNITARIO = CDec(mDetalle.Cells("OSD_PRECIO_UNITARIO2").Value)
                                .OSD_OTROS1 = 0
                                .OSD_OTROS2 = 0
                                .OSD_OTROS3 = 0
                                .OSD_IGV = CDec(mDetalle.Cells("IGV2").Tag)
                                .OSD_CONTRAVALOR = (CDec(mDetalle.Cells("OSD_CANTIDAD2").Value) * CDec(mDetalle.Cells("OSD_PRECIO_UNITARIO2").Value)) * CDec(mDetalle.Cells("TipoCambio").Value)
                                .OSD_OBSERVACIONES = mDetalle.Cells("OSD_OBSERVACIONES2").Value
                                .ENO_ID = CInt(mDetalle.Cells("ENO_ID2").Tag)
                                .OTR_ID = mDetalle.Cells("OTR_ID2").Value
                                .MarkAsAdded()
                            End With
                            mOS.OrdenServicioDetalle.Add(nOCD)


                            If BCOrdenServicio.MantenimientoOrdenServicio(mOS) = 1 Then
                                MessageBox.Show(mOS.OSE_ID)
                                mOS = New OrdenServicio
                                mOS.MarkAsAdded()
                            Else
                                MessageBox.Show("Error al insertar.")
                            End If
                        Next

                        LimpiarControles()
                        Call validacion_desactivacion(False, 3)
                    End If
            End Select

        End Sub

        Public Function EntidadReversa(ByVal EnoId As Integer) As String
            If EnoId = -1 Then Return ""
            Dim Eno As Entidad
            Dim mFlag As Boolean = False
            Eno = BCEntidad.EntidadGetById(EnoId)
            For Each mItem In BCEntidad.ListaEntidadCuentaContable
                If Eno.ENO_ID = mItem.ENO_ID Then
                    Return BCParametro.ParametroGetById("EntidadCuentaContable" & Eno.ENO_ID.ToString).PAR_VALOR1
                End If
            Next
            If mFlag = False Then
                Return EntidadReversa(Eno.ENO_ID_PADRE)
            End If
        End Function

        'ingreso de codigo
        Public Overrides Sub OnManNuevo()
            LimpiarControles()
            mOS = New OrdenServicio
            mOS.MarkAsAdded()
            '---------------------------------------
            Call validacion_desactivacion(True, 2)
            txtNroCotizacion.Focus()
        End Sub

        'ingreso de codigo
        Public Overrides Sub OnManBuscar()
            LimpiarControles()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            frm.Tabla = "OrdenServicio"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
                CargarOrdenServicio(key)
                LlenarControles()
                Totales()
                '---------------------------------
                Call validacion_desactivacion(True, 5)
            End If
            frm.Dispose()
        End Sub

        Sub CargarOrdenServicio(ByVal OSE_Id As Integer)
            mOS = BCOrdenServicio.OrdenServicioGetById(OSE_Id)
            mOS.MarkAsModified()
        End Sub

        Sub LlenarControles()
            txtCodigo.Text = mOS.OSE_ID
            dtpFecha.Value = mOS.OSE_FECHA
            txtNroCotizacion.Text = mOS.OSE_NRO_COTIZACION
            txtProveedor.Text = mOS.Personas.PER_NOMBRES & " " & mOS.Personas.PER_APE_PAT
            txtProveedor.Tag = mOS.PER_ID_PROVEEDOR
            cboTipoVenta.SelectedValue = mOS.TIV_ID_PAGO
            cboMoneda.SelectedValue = mOS.MON_ID
            cboTipoDocumento.SelectedValue = mOS.DTD_ID & mOS.TDO_ID & mOS.CCT_ID
            dtpFechaEntrega.Value = mOS.OSE_FECHAENTREGA
            txtEntregarEn.Text = mOS.OSE_ENTREGA
            txtObservaciones.Text = mOS.OSE_OBSERVACIONES
            numAnticipo.Value = mOS.OSE_ANTICIPO
            cboImportancia.SelectedIndex = mOS.OSE_IMPORTANCIA
            If mOS.OSE_CONFORMIDAD IsNot Nothing Then
                If mOS.OSE_CONFORMIDAD = 1 Then chkConformidad.Checked = True Else chkConformidad.Checked = False
            End If
            If mOS.OSE_CERRADA = 1 Then chkCerrada.Checked = True Else chkCerrada.Checked = False

            If Not mOS.OSE_ADJUNTO Is Nothing Then
                picPre.Image = picPre.InitialImage
            Else
                picPre.Image = picPre.ErrorImage
            End If

            For Each mItem In mOS.OrdenServicioDetalle
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OSD_ID").Value = mItem.OSD_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OSD_ID").Tag = mItem
                If mItem.ORD_ID IsNot Nothing Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_ID").Value = BCOrdenRequerimiento.OrdenRequerimientoDetalleGetById(mItem.ORD_ID).ORR_ID
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_ID").Tag = mItem.ORD_ID
                End If

                If mItem.ENO_ID IsNot Nothing Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ENO_ID").Value = BCEntidad.EntidadGetById(mItem.ENO_ID).ENO_DESCRIPCION & " --//-- " & BCEntidad.EntidadGetById(mItem.ENO_ID).ENO_RUTA
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ENO_ID").Tag = mItem.ENO_ID
                End If

                If mItem.OTR_ID IsNot Nothing Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OTR_ID").Value = mItem.OTR_ID
                End If

                'dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OSD_DESCRIPCION").Value = mItem.OSD_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Tag = mItem.ART_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value = mItem.OSD_CANTIDAD
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CantIngresada").Value = mItem.OSD_CANTIDAD_INGRESADA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value = mItem.OSD_PRECIO_UNITARIO
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value = mItem.OSD_DESCUENTO
                txtIGV.Text = mItem.OSD_IGV
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OSD_OTROS1").Value = mItem.OSD_OTROS1
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value - _
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value * (dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value / 100)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value * (txtIGV.Text / 100)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Total").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("OSD_OTROS1").Value

                If (mItem.OSD_PRECIO_UNITARIO * mItem.OSD_CANTIDAD) > 0 Then txtTipoCambio.Text = mItem.OSD_CONTRAVALOR / (mItem.OSD_PRECIO_UNITARIO * mItem.OSD_CANTIDAD) Else txtTipoCambio.Text = 0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Observacion").Value = mItem.OSD_OBSERVACIONES
            Next

            For Each mItem In mOS.OrdenServicioCuotas
                Dim nRow As New DataGridViewRow
                dgvCuota.Rows.Add(nRow)
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OSC_ID").Value = mItem.OSC_ID
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OSC_ID").Tag = mItem
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OSC_NUMERO").Value = mItem.OSC_NUMERO
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OSC_DESCRIPCION").Value = mItem.OSC_DESCRIPCION
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OSC_FECHA_VENCIMIENTO").Value = mItem.OSC_FECHA_VENCIMIENTO
                dgvCuota.Rows(dgvCuota.Rows.Count - 2).Cells("OSC_MONTO").Value = mItem.OSC_MONTO
            Next

            '''''Para saber quien lo hizo
            Dim Hecho As Usuarios
            Hecho = BCPermisoUsuario.UsuarioGetById(mOS.USU_ID)
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

            'If mOS.ChangeTracker.State = ObjectState.Modified Then
            '    For Each mDet In mOS.OrdenServicioDetalle
            '        If mDet.USU_ID_AUT_2 IsNot Nothing Then
            '            If mDet.USU_ID_AUT_2.ToString.Length > 0 Then
            '                Error_validacion.SetError(txtCodigo, "No se puede guardar una O.S. ya Autorizada.") : txtCodigo.Focus() : flag = False
            '            End If
            '        End If
            '    Next
            'End If


            'POR DETALLE
            For Each mFila As DataGridViewRow In dgvDetalle.Rows
                If mFila.IsNewRow = False Then
                    If mFila.Cells("ART_ID").Tag Is Nothing OrElse mFila.Cells("ART_ID").Tag = 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Tipo de Cambio")
                        flag = False
                        MessageBox.Show("Falta seleccionar el articulo en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If mFila.Cells("OTR_ID").Value Is Nothing OrElse mFila.Cells("OTR_ID").Value = 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese la Orden de Trabajo")
                        flag = False
                        MessageBox.Show("Falta seleccionar la O.T. en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If mFila.Cells("ENO_ID").Tag Is Nothing OrElse mFila.Cells("ENO_ID").Tag = 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese la Entidad")
                        flag = False
                        MessageBox.Show("Falta seleccionar la Entidad en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

            'If (mOS.ChangeTracker.State = ObjectState.Modified Or mOS.ChangeTracker.State = ObjectState.Added) And mModiFromPC = False Then
            '    If SessionServer.UserId <> "ADMIN" Then
            '        If frmInputBox.ShowDialog = Windows.Forms.DialogResult.OK Then
            '            If Not frmInputBox.txtPassword.Text = BCParametro.ParametroGetById(SessionServer.UserId & "OC").PAR_VALOR1 Then
            '                MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
            '                flag = False
            '            End If
            '        Else
            '            MessageBox.Show("No ha ingresado una clave valida. Se cancelara el guardado.")
            '            flag = False
            '        End If
            '    End If
            'End If

            Return flag
        End Function

        Function validar_controles2()
            'aqui se ingresara los objetos del formulario a validar
            Dim flag As Boolean = True

            Error_validacion.Clear()
          

            'POR DETALLE
            For Each mFila As DataGridViewRow In dgvDetalleGrupo.Rows
                If mFila.IsNewRow = False Then
                    If mFila.Cells("PER_ID_PROVEEDOR2").Tag Is Nothing OrElse mFila.Cells("PER_ID_PROVEEDOR2").Tag = 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Proveedor")
                        flag = False
                        MessageBox.Show("Falta seleccionar el proveedor en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If mFila.Cells("OSE_FECHA2").Value Is Nothing Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese la fecha.")
                        flag = False
                        MessageBox.Show("Falta seleccionar la fecha en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If mFila.Cells("TipoDocumento").Value Is Nothing Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Tipo de Documento")
                        flag = False
                        MessageBox.Show("Falta seleccionar el Tipo Documento en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If mFila.Cells("TipoMoneda").Value Is Nothing Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Tipo de Moneda")
                        flag = False
                        MessageBox.Show("Falta seleccionar el Tipo Moneda en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If CDbl(mFila.Cells("TipoCambio").Value) <= 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Tipo Cambio.")
                        flag = False
                        MessageBox.Show("El Tipo Cambio debe ser mayor a cero.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If mFila.Cells("OTR_ID2").Tag Is Nothing OrElse mFila.Cells("OTR_ID2").Tag = 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese la Orden de Trabajo")
                        flag = False
                        MessageBox.Show("Falta seleccionar la Orden de Trabajo en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If mFila.Cells("ART_ID2").Tag Is Nothing Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Servicio")
                        flag = False
                        MessageBox.Show("Falta seleccionar el Servicio en el detalle.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If CDbl(mFila.Cells("OSD_CANTIDAD2").Value) <= 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese la Cantidad.")
                        flag = False
                        MessageBox.Show("La cantidad debe ser mayor a cero.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If CDbl(mFila.Cells("TOTAL2").Value) <= 0 Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese el Total.")
                        flag = False
                        MessageBox.Show("El total debe ser mayor a cero.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                    If mFila.Cells("OSD_OBSERVACIONES2").Value Is Nothing OrElse mFila.Cells("OSD_OBSERVACIONES2").Value = "" Then
                        Error_validacion.SetError(dgvDetalle, "Ingrese la Observacion.")
                        flag = False
                        MessageBox.Show("Falta ingresar la Observacion.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit For
                    End If
                End If
            Next

            If flag = False Then
                MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            'For Each mItem In mOS.OrdenServicioDetalle
            '    If mItem.OSD_CANTIDAD_INGRESADA > 0 Or (mItem.USU_ID_AUT_2 & "").ToString.Length > 0 Then
            '        MessageBox.Show("No se puede eliminar la O.S. por que esta autorizada.")
            '        Exit Sub
            '    End If
            'Next

            'For Cont As Integer = mOS.OrdenServicioDetalle.Count - 1 To 0 Step -1
            '    mOS.OrdenServicioDetalle(Cont).MarkAsDeleted()
            'Next
            'mOS.MarkAsDeleted()

            mOS.OSE_ESTADO = False
            mOS.OSE_CERRADA = 1

            BCOrdenServicio.MantenimientoOrdenServicio(mOS)
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
                If mOS IsNot Nothing Then
                    Dim Lista1 = From mItem In mOS.OrdenServicioDetalle Group mItem By UsuId = mItem.USU_ID_AUT_2 Into Gpr = Group _
                                        Select UsuId, SubTotal = Gpr.Sum(Function(mItem) CDec(mItem.OSD_CONTRAVALOR))

                    For Each mItem In Lista1.ToList
                        If mItem.SubTotal > BCParametro.ParametroGetById(mItem.UsuId).PAR_VALOR1 Then
                            For cont As Integer = mOS.OrdenServicioDetalle.Count - 1 To 0 Step -1
                                If mOS.OrdenServicioDetalle(cont).USU_ID_AUT_2 = mItem.UsuId And mOS.OrdenServicioDetalle(cont).USU_ID_AUT_3 Is Nothing Then
                                    MsgBox("No está aprobada completamente la Orden de Compra.")
                                    Exit Sub
                                End If
                            Next
                        End If
                    Next

                    Dim mTt = (From mItem In mOS.OrdenServicioDetalle Select mItem.OSD_CONTRAVALOR).Sum
                    If mTt > BCParametro.ParametroGetById("RBERRIOS").PAR_VALOR1 Then
                        For cont As Integer = mOS.OrdenServicioDetalle.Count - 1 To 0 Step -1
                            If mOS.OrdenServicioDetalle(cont).USU_ID_AUT_4 Is Nothing Then
                                MsgBox("No está aprobada completamente la Orden de Compra.")
                                Exit Sub
                            End If
                        Next
                    End If

                    'Impresion
                    Dim ds As New DataSet
                    Dim query = BCOrdenServicio.ImpresionOrdenServicio(mOS.OSE_ID)
                    Dim rea As New StringReader(query)
                    ds.ReadXml(rea)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionOrdenServicio", ds.Tables(0)))
                    'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
                    Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
                    parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("USU_ID", mOS.USU_ID)
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

        Private Sub EnviarEmail(ByVal mOS As OrdenServicio)
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
                mail.Body = "Orden Compra Nro.: " & mOS.OSE_ID & vbCrLf & _
                    "Proveedor: " & mOS.Personas.PER_APE_PAT & vbCrLf & _
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
            EnviarEmail(mOS)
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
                mOS.OSE_ADJUNTO = ReadBinaryFile(ofdImagen.FileName)
                mOS.OSE_ADJUNTO_DESCRI = ofdImagen.SafeFileName
                picPre.Image = picPre.InitialImage
            End If
        End Sub

        Private Sub tooAdPreDescargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tooAdPreDescargar.Click
            If mOS.OSE_ADJUNTO IsNot Nothing Then
                Dim bits As Byte() = DirectCast(mOS.OSE_ADJUNTO, Byte())
                sfdImagen.FileName = mOS.OSE_ADJUNTO_DESCRI
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
            If mOS.OSE_ADJUNTO IsNot Nothing Then
                mOS.OSE_ADJUNTO = Nothing
                mOS.OSE_ADJUNTO_DESCRI = String.Empty
                picPre.Image = picPre.ErrorImage
            End If
        End Sub

        Private Sub dgvDetalleGrupo_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleGrupo.CellDoubleClick
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
            Select Case dgvDetalleGrupo.Columns(dgvDetalleGrupo.CurrentCell.ColumnIndex).Name
                Case "PER_ID_PROVEEDOR2"
                    frm.Tabla = "Persona"
                    frm.Tipo = "Proveedor"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalleGrupo.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'codigo
                        dgvDetalleGrupo.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value   'descripcion
                    End If
                Case "OTR_ID2"
                    frm.Tabla = "OrdenTrabajoOR"
                    frm.Tipo = dgvDetalleGrupo.CurrentCell.Value
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value  'OTR_Id
                        mOT = BCOrdenTrabajo.OrdenTrabajoGetById(key)
                        dgvDetalleGrupo.CurrentCell.Value = mOT.OTR_ID
                        dgvDetalleGrupo.CurrentCell.Tag = mOT.OTR_ID
                        dgvDetalleGrupo.CurrentRow.Cells("ENO_ID2").Value = mOT.Entidad.ENO_DESCRIPCION
                        dgvDetalleGrupo.CurrentRow.Cells("ENO_ID2").Tag = mOT.ENO_ID
                    End If
                Case "ART_ID2"
                    frm.Tabla = "ArticuloServicio"
                    frm.Tipo = dgvDetalleGrupo.CurrentCell.Value
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalleGrupo.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells("ART_ID").Value 'ART_Id
                        dgvDetalleGrupo.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(0).Value & " - " & frm.dgvLista.CurrentRow.Cells(1).Value 'ART_Descripcion
                    End If
            End Select
            frm.Dispose()
        End Sub

        Public Overrides Sub OnManAgregarFilaGrid()
            Dim nRow As New DataGridViewRow
            Select Case TabControl1.SelectedIndex
                Case 3
                    dgvDetalleGrupo.Rows.Add(nRow)
            End Select

        End Sub

        Sub CargarColumnCboTipoMoneda()
            Dim ds As New DataSet
            Dim query = BCMoneda.ListaMoneda
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            Dim mCbo As New DataGridViewComboBoxColumn
            With mCbo
                .Name = "TipoMoneda"
                .HeaderText = "TipoMoneda"
                .DisplayMember = "MON_Simbolo"
                .ValueMember = "MON_ID"
                .DataSource = ds.Tables(0)
            End With
            AddHandler dgvDetalleGrupo.CellValueChanged, AddressOf LastColumnComboSelectionChanged
            dgvDetalleGrupo.Columns.Add(mCbo)
            dgvDetalleGrupo.Columns("TipoMoneda").DisplayIndex = 3
        End Sub

        Sub CargarColumnCboTipoDocumento()
            Dim ds As New DataSet
            Dim query = BCTipoDocumento.ListaDetalleTipoDocumentoServicio
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            Dim mCbo As New DataGridViewComboBoxColumn
            With mCbo
                .Name = "TipoDocumento"
                .HeaderText = "TipoDocumento"
                .DisplayMember = "DTD_Descripcion"
                .ValueMember = "Codigo"
                .DataSource = ds.Tables(0)
            End With
            AddHandler dgvDetalleGrupo.CellValueChanged, AddressOf LastColumnComboSelectionChanged
            dgvDetalleGrupo.Columns.Add(mCbo)
            dgvDetalleGrupo.Columns("TipoDocumento").DisplayIndex = 2
        End Sub

        Private Sub LastColumnComboSelectionChanged(ByVal sender As Object, ByVal e As EventArgs)

            If dgvDetalleGrupo.CurrentCell.OwningColumn.Name = "TipoMoneda" Then
                If dgvDetalleGrupo.CurrentRow.Cells("OSE_FECHA2").Value IsNot Nothing Then
                    dgvDetalleGrupo.CurrentRow.Cells("TipoCambio").Value = BCDocuMovimiento.TCCompraDia(dgvDetalleGrupo.CurrentCell.Value, dgvDetalleGrupo.CurrentRow.Cells("OSE_FECHA2").Value)
                Else
                    MessageBox.Show("Coloque la fecha de emision del documento.")
                End If
            End If
            If dgvDetalleGrupo.CurrentCell.OwningColumn.Name = "TipoDocumento" Then
                If dgvDetalleGrupo.CurrentCell.Value.ToString.Substring(0, 3) = "038" Or dgvDetalleGrupo.CurrentCell.Value.ToString.Substring(0, 3) = "082" Or dgvDetalleGrupo.CurrentCell.Value.ToString.Substring(0, 3) = "144" Or dgvDetalleGrupo.CurrentCell.Value.ToString.Substring(0, 3) = "216" Or dgvDetalleGrupo.CurrentCell.Value.ToString.Substring(0, 3) = "066" Then dgvDetalleGrupo.CurrentRow.Cells("IGV2").Tag = SessionServer.IGV Else dgvDetalleGrupo.CurrentRow.Cells("IGV2").Tag = "0"
                dgvDetalleGrupo.CurrentRow.Cells("TOTAL2").Value = 0
            End If

        End Sub

        Private Sub dgvDetalleGrupo_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalleGrupo.CellEndEdit
            Select Case dgvDetalleGrupo.Columns(dgvDetalleGrupo.CurrentCell.ColumnIndex).Name
                Case "OSD_CANTIDAD2", "TOTAL2"
                    CType(sender, DataGridView).CurrentRow.Cells("SUBTOTAL2").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("TOTAL2").Value) / (((CDbl(CType(sender, DataGridView).CurrentRow.Cells("IGV2").Tag) / 100)) + 1), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("IGV2").Value = Math.Round(CDbl(CType(sender, DataGridView).CurrentRow.Cells("SUBTOTAL2").Value) * (CDbl(CType(sender, DataGridView).CurrentRow.Cells("IGV2").Tag) / 100), 6)
                    CType(sender, DataGridView).CurrentRow.Cells("OSD_PRECIO_UNITARIO2").Value = Math.Round((CDbl(CType(sender, DataGridView).CurrentRow.Cells("SUBTOTAL2").Value)) / CDbl(CType(sender, DataGridView).CurrentRow.Cells("OSD_CANTIDAD2").Value), 6)
            End Select
        End Sub
    End Class
End Namespace