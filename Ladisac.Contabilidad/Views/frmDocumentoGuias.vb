Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmDocumentoGuias
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDocumentoGuias As Ladisac.BL.IBCDocumentoGuias
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mDGU As DocumentoGuias

    Private Sub frmDocumentoGuias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mDGU = Nothing
        txtCodigo.Text = String.Empty
        txtSerie.Text = String.Empty
        txtNumero.Text = String.Empty
        txtProveedor.Text = String.Empty
        txtProveedor.Tag = Nothing
        dtpFecha.Value = Today
        numMonto.Value = 0
        dgvPasar.Rows.Clear()
        dgvDetalle.Rows.Clear()

        '--------------------------
        Error_Validacion.Clear()
    End Sub

    Private Sub txtProveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProveedor.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
        frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.BuscarPersona)
        frm.campo1 = "SI"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProveedor.Tag = frm.dgbRegistro.CurrentRow.Cells("ID").Value 'Per_Id
            txtProveedor.Text = frm.dgbRegistro.CurrentRow.Cells(1).Value 'Nombres
            '''cargar Guias    
            CargarGuiasTransportista()
        End If
        frm.Dispose()
    End Sub

    Sub CargarGuiasTransportista()
        dgvPasar.Rows.Clear()
        Dim ds As New DataSet
        Dim query = BCDocumentoGuias.ListaGuiasTransportista(txtProveedor.Tag, dtpFecha.Value.Date, dtpFechaFin.Value.Date)
        If Not query = "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
        Else
            ds.Tables.Add(New DataTable)
        End If

        For Each mItem In ds.Tables(0).Rows
            Dim nRow As New DataGridViewRow
            dgvPasar.Rows.Add(nRow)
            dgvPasar.Rows(dgvPasar.Rows.Count - 1).Cells("TDO_ID_REF").Value = mItem("TDO_ID")
            dgvPasar.Rows(dgvPasar.Rows.Count - 1).Cells("DTD_ID_REF").Value = mItem("DTD_ID")
            dgvPasar.Rows(dgvPasar.Rows.Count - 1).Cells("GUI_ID_REF").Value = mItem("GUI_ID")
            dgvPasar.Rows(dgvPasar.Rows.Count - 1).Cells("DES_SERIE_REF").Value = mItem("DES_SERIE")
            dgvPasar.Rows(dgvPasar.Rows.Count - 1).Cells("DES_NUMERO_REF").Value = mItem("DES_NUMERO")
            dgvPasar.Rows(dgvPasar.Rows.Count - 1).Cells("PASAR").Value = False
        Next
    End Sub

    Private Sub txtProveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtProveedor_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If mDGU IsNot Nothing Then
            dgvDetalle.EndEdit()
            mDGU.PER_ID_PROVEEDOR = txtProveedor.Tag
            mDGU.TDO_ID = ""
            mDGU.DTD_ID = ""
            mDGU.DOC_SERIE = txtSerie.Text.Trim.PadLeft(3, "0")
            mDGU.DOC_NUMERO = txtNumero.Text.Trim.PadLeft(10, "0")
            mDGU.DGU_MONTO = numMonto.Value
            mDGU.DGU_ESTADO = True
            mDGU.DGU_FEC_GRAB = Now
            mDGU.USU_ID = SessionServer.UserId
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("DGD_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("DGD_ID").Tag, DocumentoGuiasDetalle)
                        .TDO_ID = mDetalle.Cells("TDO_ID").Value
                        .DTD_ID = mDetalle.Cells("DTD_ID").Value
                        If mDetalle.Cells("GUI_ID").Value > 0 Then
                            .GUI_ID = CInt(mDetalle.Cells("GUI_ID").Value)
                            .GUI_SERIE = mDetalle.Cells("DES_SERIE").Value
                            .GUI_NRO = mDetalle.Cells("DES_NUMERO").Value
                        Else
                            .DES_SERIE = mDetalle.Cells("DES_SERIE").Value
                            .DES_NUMERO = mDetalle.Cells("DES_NUMERO").Value
                        End If
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("DES_SERIE").Value Is Nothing Then
                    Dim nDGD As New DocumentoGuiasDetalle
                    With nDGD
                        .TDO_ID = mDetalle.Cells("TDO_ID").Value
                        .DTD_ID = mDetalle.Cells("DTD_ID").Value
                        If mDetalle.Cells("GUI_ID").Value > 0 Then
                            .GUI_ID = CInt(mDetalle.Cells("GUI_ID").Value)
                            .GUI_SERIE = mDetalle.Cells("DES_SERIE").Value
                            .GUI_NRO = mDetalle.Cells("DES_NUMERO").Value
                        Else
                            .DES_SERIE = mDetalle.Cells("DES_SERIE").Value
                            .DES_NUMERO = mDetalle.Cells("DES_NUMERO").Value
                        End If
                        .MarkAsAdded()
                    End With
                    mDGU.DocumentoGuiasDetalle.Add(nDGD)
                End If
            Next
            BCDocumentoGuias.MantenimientoDocumentoGuias(mDGU)
            MessageBox.Show(mDGU.DGU_ID)
            LimpiarControles()

            '-------------------------------
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mDGU = New DocumentoGuias
        mDGU.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
        frm.inicio("DocumentoGuias")
        'frm.campo1 = "SI"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgbRegistro.CurrentRow.Cells(0).Value
            CargarDocumentoGuias(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarDocumentoGuias(ByVal DGU_Id As Integer)
        mDGU = BCDocumentoGuias.DocumentoGuiasGetById(DGU_Id)
        mDGU.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mDGU.DGU_ID

        txtSerie.Text = mDGU.DOC_SERIE
        txtNumero.Text = mDGU.DOC_NUMERO
        txtProveedor.Text = mDGU.Personas.PER_APE_PAT
        txtProveedor.Tag = mDGU.PER_ID_PROVEEDOR
        numMonto.Value = mDGU.DGU_MONTO

        For Each mItem In mDGU.DocumentoGuiasDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DGD_ID").Value = mItem.DGD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DGD_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TDO_ID").Value = mItem.TDO_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DTD_ID").Value = mItem.DTD_ID
            If mItem.GUI_ID > 0 Then
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("GUI_ID").Value = mItem.GUI_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DES_SERIE").Value = mItem.GUI_SERIE
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DES_NUMERO").Value = mItem.GUI_NRO
            Else
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DES_SERIE").Value = mItem.DES_SERIE
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DES_NUMERO").Value = mItem.DES_NUMERO
            End If
        Next
    End Sub


    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.
    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_Validacion.Clear()
        If Len(txtSerie.Text.Trim) = 0 Then Error_Validacion.SetError(txtSerie, "Ingrese la Serie") : txtSerie.Focus() : flag = False
        If Len(txtNumero.Text.Trim) = 0 Then Error_Validacion.SetError(txtNumero, "Ingrese el Numero") : txtNumero.Focus() : flag = False
        If Len(txtProveedor.Text.Trim) = 0 Then Error_Validacion.SetError(txtProveedor, "Ingrese el Nombre del Proveedor") : txtProveedor.Focus() : flag = False
        If numMonto.Value = 0 Then Error_Validacion.SetError(numMonto, "Ingrese el Monto de la Factura") : numMonto.Focus() : flag = False
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
        MessageBox.Show("No se puede eliminar, hay una Orden de Servicio.")
        'If mDGU IsNot Nothing Then
        '    If MessageBox.Show("Seguro de Eliminar el Documento Guias?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
        '        mDGU.MarkAsDeleted()
        '        BCDocumentoGuias.MantenimientoDocumentoGuias(mDGU)
        '        LimpiarControles()
        '    End If
        'End If

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

    Private Sub dtpFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged, dtpFechaFin.ValueChanged
        CargarGuiasTransportista()
    End Sub

    Private Sub btnPasar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasar.Click
        For cont As Integer = dgvDetalle.Rows.Count - 1 To 0 Step -1
            If dgvDetalle.Rows(cont).Cells("DGD_ID").Value Is Nothing Then
                dgvDetalle.Rows.Remove(dgvDetalle.Rows(cont))
            End If
        Next

        For Each mItem As DataGridViewRow In dgvPasar.Rows
            If mItem.Cells("Pasar").Value Then
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TDO_ID").Value = mItem.Cells("TDO_ID_REF").Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DTD_ID").Value = mItem.Cells("DTD_ID_REF").Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("GUI_ID").Value = mItem.Cells("GUI_ID_REF").Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DES_SERIE").Value = mItem.Cells("DES_SERIE_REF").Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DES_NUMERO").Value = mItem.Cells("DES_NUMERO_REF").Value
            End If
        Next
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("DGD_ID").Tag Is Nothing Then
            CType(e.Row.Cells("DGD_ID").Tag, DocumentoGuiasDetalle).MarkAsDeleted()
        End If
    End Sub
End Class
