Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmSancion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCSancion As Ladisac.BL.IBCSancion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mSAN As Sancion

    Private Sub frmSancion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mSAN = Nothing
        txtCodigo.Text = String.Empty
        dtpFecha.Value = Today
        txtNombresFalta.Text = String.Empty
        txtNombresFalta.Tag = Nothing
        txtDNI.Text = String.Empty
        txtUNT_Id.Text = String.Empty
        txtUNT_Id.Tag = Nothing
        txtPer_Id_Proveedor.Text = String.Empty
        txtPer_Id_Proveedor.Tag = Nothing
        txtObservacion.Text = String.Empty

        dgvDetalle.Rows.Clear()


        '--------------------------
        Error_Validacion.Clear()
    End Sub

    Private Sub txtNombresFalta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNombresFalta.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtNombresFalta.Tag = frm.dgvLista.CurrentRow.Cells("Per_Id").Value 'Per_Id
            txtNombresFalta.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub


    Private Sub txtNombresFalta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNombresFalta.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNombresFalta_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtUNT_Id_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUNT_Id.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Placas"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtUNT_Id.Tag = frm.dgvLista.CurrentRow.Cells(1).Value 'UNT_Id
            txtUNT_Id.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Placa_Id
        End If
        frm.Dispose()
    End Sub


    Private Sub txtUNT_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUNT_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtUNT_Id_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtPer_Id_Proveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPer_Id_Proveedor.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPer_Id_Proveedor.Tag = frm.dgvLista.CurrentRow.Cells("Per_Id").Value 'Per_Id
            txtPer_Id_Proveedor.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub


    Private Sub txtPer_Id_Proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPer_Id_Proveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPer_Id_Proveedor_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        Select Case dgvDetalle.CurrentCell.ColumnIndex
            Case 1
                frm.Tabla = "FaltaSancion"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'fsa_descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'fsa_id
                End If
        End Select
        frm.Dispose()
    End Sub


    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If mSAN IsNot Nothing Then
            dgvDetalle.EndEdit()
            mSAN.SAN_FECHA = dtpFecha.Value
            mSAN.PER_ID_TRABAJADOR_FALTA = txtNombresFalta.Tag
            mSAN.SAN_DNI_FALTA = txtDNI.Text
            mSAN.SAN_NOMBRE_FALTA = txtNombresFalta.Text
            mSAN.PER_ID_PROVEEDOR = txtPer_Id_Proveedor.Tag
            mSAN.UNT_ID = txtUNT_Id.Tag
            mSAN.SAN_OBSERVACION = txtObservacion.Text
            mSAN.SAN_ESTADO = True
            mSAN.SAN_FEC_GRAB = Now
            mSAN.USU_ID = SessionServer.UserId
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("SAD_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("SAD_ID").Tag, SancionDetalle)
                        .FSA_ID = CInt(mDetalle.Cells("FSA_ID").Tag)
                        .SAD_OBSERVACION = mDetalle.Cells("SAD_OBSERVACION").Value
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("FSA_ID").Value Is Nothing Then
                    Dim nSAD As New SancionDetalle
                    With nSAD
                        .FSA_ID = CInt(mDetalle.Cells("FSA_ID").Tag)
                        .SAD_OBSERVACION = mDetalle.Cells("SAD_OBSERVACION").Value
                        .MarkAsAdded()
                    End With
                    mSAN.SancionDetalle.Add(nSAD)
                End If
            Next
            BCSancion.MantenimientoSancion(mSAN)
            MessageBox.Show(mSAN.SAN_ID)
            LimpiarControles()

            '-------------------------------
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mSAN = New Sancion
        mSAN.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Sancion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarSancion(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarSancion(ByVal SAN_Id As Integer)
        mSAN = BCSancion.SancionGetById(SAN_Id)
        mSAN.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mSAN.SAN_ID
        dtpFecha.Value = mSAN.SAN_FECHA
        txtNombresFalta.Text = mSAN.SAN_NOMBRE_FALTA
        txtNombresFalta.Tag = mSAN.PER_ID_TRABAJADOR_FALTA
        txtDNI.Text = mSAN.SAN_DNI_FALTA
        txtUNT_Id.Text = mSAN.UNT_ID
        txtUNT_Id.Tag = mSAN.UNT_ID
        txtPer_Id_Proveedor.Text = mSAN.Personas2.PER_APE_PAT
        txtPer_Id_Proveedor.Tag = mSAN.PER_ID_PROVEEDOR
        txtObservacion.Text = mSAN.SAN_OBSERVACION

        For Each mItem In mSAN.SancionDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SAD_ID").Value = mItem.SAD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SAD_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("FSA_ID").Value = mItem.FaltaSancion.FSA_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("FSA_ID").Tag = mItem.FSA_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("SAD_Observacion").Value = mItem.SAD_OBSERVACION
        Next
        '' '''''Para saber quien lo hizo
        ''Dim Hecho As Usuarios
        ''Hecho = BCPermisoUsuario.UsuarioGetById(mSOC.USU_ID)
        ''lblHecho.Text = "Hecho por: " & Hecho.USU_DESCRIPCION
    End Sub


    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.
    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_Validacion.Clear()
        'If Len(txtNroCotizacion.Text.Trim) = 0 Then Error_validacion.SetError(txtNroCotizacion, "Ingrese el Numero de Cotización") : txtNroCotizacion.Focus() : flag = False
        'If Len(txtPer_Id_Proveedor.Text.Trim) = 0 Then Error_Validacion.SetError(txtProveedor, "Ingrese el Nombre del Proveedor") : txtPer_Id_Proveedor.Focus() : flag = False
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
        If mSAN IsNot Nothing Then
            If MessageBox.Show("Seguro de Eliminar la Sancion?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
                mSAN.MarkAsDeleted()
                BCSancion.MantenimientoSancion(mSAN)
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


    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
    End Sub

End Class
