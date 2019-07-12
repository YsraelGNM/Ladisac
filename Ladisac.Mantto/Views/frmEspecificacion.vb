Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms

Public Class frmEspecificacion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mENO As Entidad

    Private Sub frmEspecificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        Call validacion_desactivacion(False, 1)
        txtEntidad.TabIndex = 1
        dgvDetalle.TabIndex = 2
    End Sub


    Sub LimpiarControles()
        mENO = Nothing
        txtEntidad.Text = String.Empty
        txtEntidad.Tag = Nothing
        dgvDetalle.Rows.Clear()
        lblRuta.Text = String.Empty
    End Sub

    Private Sub txtEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntidad.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEntidad.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
            txtEntidad.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
            lblRuta.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Ruta
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
            CargarEntidad(key)
            LlenarControles()
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "Caracteristica"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'CTT_Id
                    dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(2).Value ' UM
                End If
        End Select
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManEliminar()
        If mENO IsNot Nothing Then
            For Each mItem In mENO.Especificacion
                mItem.MarkAsDeleted()
            Next
            BCEntidad.MantenimientoEntidad(mENO)
            Call LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        If mENO IsNot Nothing Then
            dgvDetalle.EndEdit()
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("ESP_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("ESP_ID").Tag, Especificacion)
                        .CTT_ID = mDetalle.Cells("CTT_ID").Tag
                        .ESP_VALOR = CDec(mDetalle.Cells("ESP_VALOR").Value)
                        .ESP_ESTADO = True
                        .ESP_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("ESP_VALOR").Value Is Nothing Then
                    Dim nESP As New Especificacion
                    With nESP
                        .CTT_ID = CInt(mDetalle.Cells("CTT_ID").Tag)
                        .ESP_VALOR = CDec(mDetalle.Cells("ESP_VALOR").Value)
                        .ESP_ESTADO = True
                        .ESP_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsAdded()
                    End With
                    mENO.Especificacion.Add(nESP)
                End If
            Next

            BCEntidad.MantenimientoEntidad(mENO)
            MessageBox.Show(mENO.ENO_ID)
            LimpiarControles()
        End If
        Call validacion_desactivacion(False, 3)
    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mENO = New Entidad
        mENO.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarEntidad(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarEntidad(ByVal ENO_Id As Integer)
        mENO = BCEntidad.EntidadGetById(ENO_Id)
        mENO.MarkAsModified()
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Sub LlenarControles()
        txtEntidad.Text = mENO.ENO_DESCRIPCION
        txtEntidad.Tag = mENO.ENO_ID
        lblRuta.Text = mENO.ENO_RUTA
        For Each mItem In mENO.Especificacion
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ESP_ID").Value = mItem.ESP_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ESP_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CTT_Id").Value = mItem.Caracteristica.CTT_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CTT_Id").Tag = mItem.CTT_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("UM").Value = mItem.Caracteristica.CTT_UNIDAD
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("ESP_Valor").Value = mItem.ESP_VALOR
        Next
    End Sub


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

    Private Sub txtEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidad.KeyDown
        If e.KeyCode = Keys.Enter Then txtEntidad_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        If e.KeyCode = Keys.Enter And dgvDetalle.CurrentCell.ColumnIndex = 1 Then
            frm.Tabla = "Caracteristica"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'Descripcion
                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'CTT_Id
                dgvDetalle.CurrentRow.Cells("UM").Value = frm.dgvLista.CurrentRow.Cells(2).Value ' UM
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvDetalle_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvDetalle.UserDeletedRow
        If Not e.Row.Cells("ESP_ID").Tag Is Nothing Then
            CType(e.Row.Cells("ESP_ID").Tag, Especificacion).MarkAsDeleted()
        End If
    End Sub
End Class
