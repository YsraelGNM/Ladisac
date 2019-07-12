Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmControlPaqueteo
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCControlPaqueteo As Ladisac.BL.IBCControlPaqueteo
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Protected CPqt As ControlPaqueteo

    Private Sub frmControlPaqueteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    Public Overrides Sub OnManNuevo()
        MyBase.OnManNuevo()
        Call validacion_desactivacion(True, 2)
    End Sub

    Public Overrides Sub OnManBuscar()
        MyBase.OnManBuscar()
        Call validacion_desactivacion(True, 5)
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
        CPqt = New ControlPaqueteo
        CPqt.MarkAsAdded()
        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRO_ID").Tag = CPqt
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case CType(sender, DataGridView).Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "PRO_ID"
                frm.Tabla = "ProduccionVagones"
                If dgvDetalle.EditingControl IsNot Nothing Then
                    If IsNumeric(dgvDetalle.EditingControl.Text) Then frm.Tipo = dgvDetalle.EditingControl.Text
                Else
                    frm.Tipo = dgvDetalle.CurrentCell.Value
                End If
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'PRO_ID_Id
                    dgvDetalle.CurrentRow.Cells("FECHA").Value = frm.dgvLista.CurrentRow.Cells(0).Value  'PRO_FECHA
                    dgvDetalle.CurrentRow.Cells("DESCRIPCION").Value = frm.dgvLista.CurrentRow.Cells(2).Value  'ART_DESCRIPCION
                    dgvDetalle.CurrentRow.Cells("UND_BRUTAS").Value = frm.dgvLista.CurrentRow.Cells(3).Value  'UnBrXProd
                    dgvDetalle.CurrentRow.Cells("CONTEO").Value = frm.dgvLista.CurrentRow.Cells(4).Value  'Conteo
                    dgvDetalle.CurrentRow.Cells("OBSERVACION").Value = frm.dgvLista.CurrentRow.Cells(5).Value  'PRO_OBSERVACION
                End If
        End Select
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "CANT_MESA", "CANT_ALA"
                CType(sender, DataGridView).CurrentRow.Cells("CANT_MALE").Value = (CDbl(CType(sender, DataGridView).CurrentRow.Cells("CANT_MESA").Value) + _
                 CDbl(CType(sender, DataGridView).CurrentRow.Cells("CANT_ALA").Value)) * 2
            Case "CONTEO_MESA", "CONTEO_ALA"
                CType(sender, DataGridView).CurrentRow.Cells("TOTAL_LAD_PAQUETEADO").Value = (CDbl(CType(sender, DataGridView).CurrentRow.Cells("CONTEO_MESA").Value) * _
                 CDbl(CType(sender, DataGridView).CurrentRow.Cells("CANT_MESA").Value)) + _
             (CDbl(CType(sender, DataGridView).CurrentRow.Cells("CONTEO_ALA").Value) * _
                 CDbl(CType(sender, DataGridView).CurrentRow.Cells("CANT_ALA").Value))
        End Select

        CType(sender, DataGridView).CurrentRow.Cells("REC_CANCHA").Value = CDbl(CType(sender, DataGridView).CurrentRow.Cells("CONTEO").Value) - CDbl(CType(sender, DataGridView).CurrentRow.Cells("TOTAL_LAD_PAQUETEADO").Value)
        CType(sender, DataGridView).CurrentRow.Cells("PORC_REC_CANCHA").Value = Math.Round((CDbl(CType(sender, DataGridView).CurrentRow.Cells("REC_CANCHA").Value) * 100) / CDbl(CType(sender, DataGridView).CurrentRow.Cells("CONTEO").Value), 2)
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        If e.KeyCode = Keys.Enter Then
            dgvDetalle.EndEdit()
            dgvDetalle_CellDoubleClick(sender, Nothing)
        End If
    End Sub

    'validamos los campos a llenar
    Function validar_controles(ByVal mFila As DataGridViewRow)
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If CType(mFila.Cells("PRO_ID").Tag, ControlPaqueteo).ChangeTracker.State = ObjectState.Added Then
            Dim Existe = BCControlPaqueteo.ControlPaqueteoGetByPro_Id(mFila.Cells("PRO_ID").Value)
            If Existe IsNot Nothing Then Error_validacion.SetError(dgvDetalle, "La Produccion ya se encuentra registrada." & mFila.Cells("PRO_ID").Value) : dgvDetalle.Focus() : flag = False
        End If
        'If Len(txtLadrillo.Text.Trim) = 0 Then Error_validacion.SetError(txtLadrillo, "Ingrese el Nombre del Ladrillo ") : txtLadrillo.Focus() : flag = False
        'If Len(txtPlanta.Text.Trim) = 0 Then Error_validacion.SetError(txtPlanta, "Ingrese el Nombre de la Planta") : txtPlanta.Focus() : flag = False
        'If Len(txtExtrusora.Text.Trim) = 0 Then Error_validacion.SetError(txtExtrusora, "Ingrese la Extrusora") : txtExtrusora.Focus() : flag = False
        'If Len(txtCortadora.Text.Trim) = 0 Then Error_validacion.SetError(txtCortadora, "Ingrese la Cortadora") : txtCortadora.Focus() : flag = False
        'If Len(txtIng1.Text.Trim) = 0 Then Error_validacion.SetError(txtIng1, "Ingrese el Nombre del Ingeniero") : txtIng1.Focus() : flag = False
        'If Len(cboTipoProduccion.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoProduccion, "Ingrese el Tipo de Produccion") : cboTipoProduccion.Focus() : flag = False
        'If Len(txtObservacion.Text.Trim) = 0 Then Error_validacion.SetError(txtObservacion, "Ingrese las Observaciones") : txtObservacion.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        For Each mFila As DataGridViewRow In dgvDetalle.Rows
            If Not validar_controles(mFila) Then Exit Sub
            'If CType(mFila.Cells("PRO_ID").Tag, ControlPaqueteo).ChangeTracker.State = ObjectState.Added Then
            With CType(mFila.Cells("PRO_ID").Tag, ControlPaqueteo)
                .PRO_ID = mFila.Cells("PRO_ID").Value
                .PQT_CANT_MESA = CInt(mFila.Cells("CANT_MESA").Value)
                .PQT_CANT_ALA = CInt(mFila.Cells("CANT_ALA").Value)
                .PQT_MESA = CInt(mFila.Cells("CONTEO_MESA").Value)
                .PQT_ALA = CInt(mFila.Cells("CONTEO_ALA").Value)
                .PQT_RECICLAJE = CDbl(mFila.Cells("REC_CANCHA").Value)
                .PQT_OBSERVCION = mFila.Cells("OBSERVACION").Value
                .USU_ID = SessionServer.UserId
                .PQT_FEC_GRAB = Now
                .PQT_ESTADO = True
            End With

            BCControlPaqueteo.MantenimientoControlPaqueteo(CType(mFila.Cells("PRO_ID").Tag, ControlPaqueteo))
            'End If
        Next
        'MessageBox.Show("")
        LimpiarControles()
        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        dgvDetalle.Rows.Clear()
        '--------------------------
        Error_validacion.Clear()
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LimpiarControles()
        Dim ds As New DataSet
        Dim query = BCControlPaqueteo.ListaControlPaqueteo(dtpFecIni.Value.Date, dtpFecFin.Value.Date)
        If query.ToString.Length > 0 Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            Dim mDatoPro As vwReporteFinalProduccion2
            For Each mFila As DataRow In ds.Tables(0).Rows
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                Dim CPqt As ControlPaqueteo
                CPqt = BCControlPaqueteo.ControlPaqueteoGetById(mFila("PQT_ID"))
                CPqt.MarkAsModified()
                mDatoPro = BCProduccion.VwProduccionByPro_Id(CPqt.PRO_ID)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRO_ID").Tag = CPqt
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRO_ID").Value = CPqt.PRO_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("FECHA").Value = mDatoPro.PRO_FECHA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DESCRIPCION").Value = mDatoPro.ART_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("UND_BRUTAS").Value = mDatoPro.UnBrXProd
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CONTEO").Value = mDatoPro.Conteo
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_MESA").Value = CPqt.PQT_CANT_MESA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_ALA").Value = CPqt.PQT_CANT_ALA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CONTEO_MESA").Value = CPqt.PQT_MESA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CONTEO_ALA").Value = CPqt.PQT_ALA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("REC_CANCHA").Value = CPqt.PQT_RECICLAJE
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OBSERVACION").Value = CPqt.PQT_OBSERVCION

                
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_MALE").Value = (CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_MESA").Value) + _
                         CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_ALA").Value)) * 2

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TOTAL_LAD_PAQUETEADO").Value = (CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CONTEO_MESA").Value) * _
                         CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_MESA").Value)) + _
                     (CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CONTEO_ALA").Value) * _
                         CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CANT_ALA").Value))


                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("REC_CANCHA").Value = CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CONTEO").Value) - CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("TOTAL_LAD_PAQUETEADO").Value)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PORC_REC_CANCHA").Value = Math.Round((CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("REC_CANCHA").Value) * 100) / CDbl(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CONTEO").Value), 2)

            Next
        End If
    End Sub
End Class
