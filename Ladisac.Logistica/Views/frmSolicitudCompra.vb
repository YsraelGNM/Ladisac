Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmSolicitudCompra

    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCSolicitudCompra As Ladisac.BL.IBCSolicitudCompra
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCTipoVenta As Ladisac.BL.IBCTipoVenta
    <Dependency()> _
    Public Property BCMoneda As Ladisac.BL.IBCMoneda
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento
    <Dependency()>
    Public Property BCPermisoUsuario As Ladisac.BL.BCPermisoUsuario

    Protected mSOC As SolicitudCompra

    'ingreso de codigo
    Private Sub frmOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CargarTipoVenta()
        CargarMoneda()
        LimpiarControles()

        'se llama al procedimiento de paso rapido entre cajas de texto.
        
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)
        txtCodigo.TabIndex = 0
        txtProveedor.TabIndex = 1
        dtpFecha.TabIndex = 2
        dgvDetalle.TabIndex = 3
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        TabControl1.SelectedIndex = 0
        mSOC = Nothing
        txtCodigo.Text = String.Empty
        txtNroCotizacion.Text = String.Empty
        txtProveedor.Text = String.Empty
        txtProveedor.Tag = Nothing
        cboTipoVenta.SelectedIndex = -1
        dtpFecha.Value = Today
        dtpFechaEntrega.Value = Today
        txtIGV.Text = SessionServer.IGV
        txtTipoCambio.Text = SessionServer.TC
        txtEntregarEn.Text = String.Empty
        txtObservaciones.Text = String.Empty
        cboMoneda.SelectedIndex = -1
        dgvDetalle.Rows.Clear()

        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionSolicitudDeCompra", New DataTable))
        ReportViewer1.RefreshReport()

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
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProveedor.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtProveedor.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "OrdenRequerimiento"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ORD_Id
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(1).Value  'ORD_Id
                    dgvDetalle.CurrentRow.Cells("Art_id").Value = frm.dgvLista.CurrentRow.Cells(3).Value & " - " & frm.dgvLista.CurrentRow.Cells(4).Value 'ART_Codigo
                    dgvDetalle.CurrentRow.Cells("Art_id").Tag = frm.dgvLista.CurrentRow.Cells(2).Value  'ART_Id
                    dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(5).Value  'UM
                    dgvDetalle.CurrentRow.Cells("Cantidad").Value = frm.dgvLista.CurrentRow.Cells(6).Value  'Cantidad
                End If
            Case 2
                frm.Tabla = "Articulo"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
                    dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnidadMedida
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
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
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If mSOC IsNot Nothing Then
            dgvDetalle.EndEdit()
            mSOC.SOC_FECHA = dtpFecha.Value
            mSOC.SOC_NRO_COTIZACION = txtNroCotizacion.Text
            mSOC.PER_ID_SOLICITADO = txtProveedor.Tag
            mSOC.TIV_ID_PAGO = cboTipoVenta.SelectedValue
            mSOC.MON_ID = cboMoneda.SelectedValue
            mSOC.SOC_FECHAENTREGA = dtpFechaEntrega.Value
            mSOC.SOC_ENTREGA = txtEntregarEn.Text
            mSOC.SOC_OBSERVACIONES = txtObservaciones.Text
            mSOC.SOC_ESTADO = True
            mSOC.SOC_FEC_GRAB = Now
            mSOC.USU_ID = SessionServer.UserId
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("SCD_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("SCD_ID").Tag, SolicitudCompraDetalle)
                        .ORD_ID = mDetalle.Cells("ORD_Id").Tag
                        .ART_ID = mDetalle.Cells("ART_Id").Tag
                        .SCD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                        .SCD_CANTIDAD_INGRESADA = CDec(mDetalle.Cells("CantIngresada").Value)
                        .SCD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                        .SCD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                        .SCD_IGV = txtIGV.Text
                        .SCD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PU").Value)) * txtTipoCambio.Text
                        .SCD_OBSERVACIONES = mDetalle.Cells("Observacion").Value

                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("Cantidad").Value Is Nothing Then
                    Dim nOCD As New SolicitudCompraDetalle
                    With nOCD
                        .ORD_ID = IIf(mDetalle.Cells("ORD_Id").Tag Is Nothing, Nothing, CInt(mDetalle.Cells("ORD_Id").Tag))
                        .ART_ID = mDetalle.Cells("ART_Id").Tag
                        .SCD_CANTIDAD = CDec(mDetalle.Cells("Cantidad").Value)
                        .SCD_CANTIDAD_INGRESADA = CDec(mDetalle.Cells("CantIngresada").Value)
                        .SCD_DESCUENTO = CDec(mDetalle.Cells("Descuento").Value)
                        .SCD_PRECIO_UNITARIO = CDec(mDetalle.Cells("PU").Value)
                        .SCD_IGV = txtIGV.Text
                        .SCD_CONTRAVALOR = (CDec(mDetalle.Cells("Cantidad").Value) * CDec(mDetalle.Cells("PU").Value)) * txtTipoCambio.Text
                        .SCD_OBSERVACIONES = mDetalle.Cells("Observacion").Value
                        .SCD_ESTADO_COMPRA = "PC"
                        .MarkAsAdded()
                    End With
                    mSOC.SolicitudCompraDetalle.Add(nOCD)
                End If
            Next
            BCSolicitudCompra.MantenimientoSolicitudCompra(mSOC)
            MessageBox.Show(mSOC.SOC_ID)
            mSOC = BCSolicitudCompra.SolicitudCompraGetById(mSOC.SOC_ID)
            If MessageBox.Show("Desea Imprimir la Solicitud De Compra?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                TabControl1.SelectedIndex = 1
            Else
                LimpiarControles()
                Call validacion_desactivacion(False, 3)
            End If
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mSOC = New SolicitudCompra
        mSOC.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtProveedor.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "SolicitudCompra"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarOrdenCompra(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarOrdenCompra(ByVal SOC_Id As Integer)
        mSOC = BCSolicitudCompra.SolicitudCompraGetById(SOC_Id)
        mSOC.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mSOC.SOC_ID
        dtpFecha.Value = mSOC.SOC_FECHA
        txtNroCotizacion.Text = mSOC.SOC_NRO_COTIZACION
        txtProveedor.Tag = mSOC.PER_ID_SOLICITADO
        'txtProveedor.Text = mSOC.Personas.PER_NOMBRES
        txtProveedor.Text = mSOC.Personas.PER_APE_PAT & mSOC.Personas.PER_APE_MAT
        'cboTipoVenta.SelectedValue = mSOC.TIV_ID_PAGO
        'cboMoneda.SelectedValue = mSOC.MON_ID
        'dtpFechaEntrega.Value = mSOC.SOC_FECHAENTREGA
        txtEntregarEn.Text = mSOC.SOC_ENTREGA
        txtObservaciones.Text = mSOC.SOC_OBSERVACIONES
        For Each mItem In mSOC.SolicitudCompraDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SCD_ID").Value = mItem.SCD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SCD_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_ID").Value = mItem.ORD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ORD_ID").Tag = mItem.ORD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Value = mItem.Articulos.ART_Codigo & " - " & mItem.Articulos.ART_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Art_Id").Tag = mItem.ART_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Value = mItem.Articulos.UnidadMedidaArticulos.UM_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value = mItem.SCD_CANTIDAD
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CantIngresada").Value = mItem.SCD_CANTIDAD_INGRESADA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value = mItem.SCD_PRECIO_UNITARIO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value = mItem.SCD_DESCUENTO
            txtIGV.Text = mItem.SCD_IGV

            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value - _
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PU").Value * dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Cantidad").Value * (dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Descuento").Value / 100)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value * (txtIGV.Text / 100)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Total").Value = dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SubTotal").Value + dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("IGV").Value

            'txtTipoCambio.Text = mItem.SCD_CONTRAVALOR / (mItem.SCD_PRECIO_UNITARIO * mItem.SCD_CANTIDAD)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("Observacion").Value = mItem.SCD_OBSERVACIONES
        Next
        '''''Para saber quien lo hizo
        Dim Hecho As Usuarios
        Hecho = BCPermisoUsuario.UsuarioGetById(mSOC.USU_ID)
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
        If Len(txtProveedor.Text.Trim) = 0 Then Error_validacion.SetError(txtProveedor, "Ingrese el Nombre del Proveedor") : txtProveedor.Focus() : flag = False
        'If Len(txtEntregarEn.Text.Trim) = 0 Then Error_validacion.SetError(txtEntregarEn, "Ingrese el Lugar de Entrega") : txtEntregarEn.Focus() : flag = False
        'If Len(cboTipoVenta.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoVenta, "Ingrese el Tipo de Venta") : cboTipoVenta.Focus() : flag = False
        'If Len(txtObservaciones.Text.Trim) = 0 Then Error_validacion.SetError(txtObservaciones, "Ingrese las Observaciones") : txtObservaciones.Focus() : flag = False
        'If Len(cboMoneda.Text.Trim) = 0 Then Error_validacion.SetError(cboMoneda, "Ingrese el Tipo de Moneda") : cboMoneda.Focus() : flag = False
        'If Len(txtIGV.Text.Trim) = 0 Then Error_validacion.SetError(txtIGV, "Ingrese el IGV") : txtIGV.Focus() : flag = False
        'If Len(txtTipoCambio.Text.Trim) = 0 Then Error_validacion.SetError(txtTipoCambio, "Ingrese el Tipo de Cambio") : txtTipoCambio.Focus() : flag = False


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
        If mSOC IsNot Nothing Then
            For Each mItem In mSOC.SolicitudCompraDetalle
                If mItem.SCD_ESTADO_COMPRA = "CS" Then
                    MessageBox.Show("La S.C. no se puede eliminar porque ya fue Consolidada.")
                    Exit Sub
                End If
            Next
            If MessageBox.Show("Seguro de Eliminar la Solicitud de Compra?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
                For Cont As Integer = 0 To mSOC.SolicitudCompraDetalle.Count - 1
                    mSOC.SolicitudCompraDetalle(Cont).MarkAsDeleted()
                Next
                'For Each mItem In mSOC.SolicitudCompraDetalle
                '    mItem.MarkAsDeleted()
                'Next
                mSOC.MarkAsDeleted()
                BCSolicitudCompra.MantenimientoSolicitudCompra(mSOC)
                LimpiarControles()
            End If
        End If

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

        End If
    End Sub

    Sub Visualizar()
        Try
            If mSOC IsNot Nothing Then
                Dim ds As New DataSet
                Dim query = BCSolicitudCompra.ImpresionSolicitudDeCompra(mSOC.SOC_ID)
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
                ReportViewer1.LocalReport.DataSources.Clear()
                ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionSolicitudDeCompra", ds.Tables(0)))
                ReportViewer1.RefreshReport()
            End If

        Catch ex As Exception

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsImpresionSolicitudDeCompra", New DataTable))
            ReportViewer1.RefreshReport()
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Visualizar()
    End Sub

    Private Sub ReportViewer1_Print(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ReportViewer1.Print
        Me.DialogResult = Windows.Forms.DialogResult.OK
        'LimpiarControles()
        Call validacion_desactivacion(False, 3)
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then txtProveedor_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        If e.KeyCode = Keys.Enter Then
            Select Case dgvDetalle.CurrentCell.ColumnIndex
                Case 1
                    frm.Tabla = "OrdenRequerimiento"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'ORD_Id
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(1).Value  'ORD_Id
                        dgvDetalle.CurrentRow.Cells("Art_id").Value = frm.dgvLista.CurrentRow.Cells(3).Value & " - " & frm.dgvLista.CurrentRow.Cells(4).Value 'ART_Codigo
                        dgvDetalle.CurrentRow.Cells("Art_id").Tag = frm.dgvLista.CurrentRow.Cells(2).Value  'ART_Id
                        dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(5).Value  'UM
                        dgvDetalle.CurrentRow.Cells("Cantidad").Value = frm.dgvLista.CurrentRow.Cells(6).Value  'Cantidad
                    End If
                Case 2
                    frm.Tabla = "Articulo"
                    If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                        dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value & " - " & frm.dgvLista.CurrentRow.Cells(2).Value 'ART_Descripcion
                        dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnidadMedida
                    End If
            End Select
        End If
        
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("SCD_ID").Tag Is Nothing Then
            CType(e.Row.Cells("SCD_ID").Tag, SolicitudCompraDetalle).MarkAsDeleted()
        End If
    End Sub

End Class
