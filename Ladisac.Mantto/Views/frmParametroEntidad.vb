Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms

Public Class frmParametroEntidad
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCEntidadInspeccion As Ladisac.BL.IBCEntidadInspeccion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mEIN As EntidadInspeccion

    Private Sub frmParametroEntidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
       
        Call validacion_desactivacion(False, 1)
        txtCodigo.TabIndex = 3
        txtEntidadInspeccion.TabIndex = 1
        dgvDetalle.TabIndex = 2
    End Sub
    
    Sub LimpiarControles()
        mEIN = Nothing
        txtCodigo.Text = String.Empty
        txtEntidadInspeccion.Text = String.Empty
        txtEntidadInspeccion.Tag = Nothing
        dgvDetalle.Rows.Clear()
    End Sub

    Private Sub txtEntidadInspeccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntidadInspeccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "EntidadInspeccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value 'EIN_Id
            CargarEntidadInspeccion(key)
            LlenarComponentes(mEIN)
        End If
        frm.Dispose()
    End Sub

    Sub CargarEntidadInspeccion(ByVal EIN_Id As Integer)
        mEIN = BCEntidadInspeccion.EntidadInspeccionGetById(EIN_Id)
        mEIN.MarkAsModified()
    End Sub

    Sub LlenarComponentes(ByVal EIN As EntidadInspeccion)
        txtEntidadInspeccion.Text = mEIN.Entidad.ENO_DESCRIPCION & " - " & mEIN.Inspeccion.INS_DESCRIPCION
        txtEntidadInspeccion.Tag = mEIN.EIN_ID
        Dim mCompNuevos = From mCL In EIN.Inspeccion.ComponenteInspeccion Where mCL.COM_ESTADO = True Select mCL
        For Each mItem In mCompNuevos
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("COM_Id").Value = mItem.COM_TITULO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("COM_Id").Tag = mItem.COM_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PAE_DESCRIPCION").Value = mItem.COM_DESCRIPCION
        Next
    End Sub

    Sub LlenarControles()
        txtEntidadInspeccion.Text = mEIN.Entidad.ENO_DESCRIPCION & " - " & mEIN.Inspeccion.INS_DESCRIPCION
        txtEntidadInspeccion.Tag = mEIN.EIN_ID
        Dim mPar = From mParCom In mEIN.ParametroEntidad Where mParCom.PAE_ESTADO = True Select mParCom
        For Each mItem In mPar
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PAE_ID").Value = mItem.PAE_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PAE_ID").Tag = mItem

            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("COM_Id").Value = mItem.ComponenteInspeccion.COM_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("COM_Id").Tag = mItem.COM_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PAE_DESCRIPCION").Value = mItem.PAE_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PAE_AMAINFERIOR").Value = mItem.PAE_AMAINFERIOR
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PAE_VERDE1").Value = mItem.PAE_VERDE1
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PAE_VERDE2").Value = mItem.PAE_VERDE2
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("PAE_AMASUPERIOR").Value = mItem.PAE_AMASUPERIOR
        Next
    End Sub

    Public Overrides Sub OnManGuardar()
        If mEIN IsNot Nothing Then
            dgvDetalle.EndEdit()
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("PAE_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("PAE_ID").Tag, ParametroEntidad)
                        .EIN_ID = CInt(txtEntidadInspeccion.Tag)
                        .COM_ID = CInt(mDetalle.Cells("COM_ID").Tag)
                        .PAE_DESCRIPCION = mDetalle.Cells("PAE_DESCRIPCION").Value
                        .PAE_AMAINFERIOR = CDec(mDetalle.Cells("PAE_AMAINFERIOR").Value)
                        .PAE_VERDE1 = CDec(mDetalle.Cells("PAE_VERDE1").Value)
                        .PAE_VERDE2 = CDec(mDetalle.Cells("PAE_VERDE2").Value)
                        .PAE_AMASUPERIOR = CDec(mDetalle.Cells("PAE_AMASUPERIOR").Value)
                        .PAE_ESTADO = True
                        .PAE_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("COM_ID").Tag Is Nothing Then
                    Dim nPAE As New ParametroEntidad
                    With nPAE
                        .EIN_ID = CInt(txtEntidadInspeccion.Tag)
                        .COM_ID = CInt(mDetalle.Cells("COM_ID").Tag)
                        .PAE_DESCRIPCION = mDetalle.Cells("PAE_DESCRIPCION").Value
                        .PAE_AMAINFERIOR = CDec(mDetalle.Cells("PAE_AMAINFERIOR").Value)
                        .PAE_VERDE1 = CDec(mDetalle.Cells("PAE_VERDE1").Value)
                        .PAE_VERDE2 = CDec(mDetalle.Cells("PAE_VERDE2").Value)
                        .PAE_AMASUPERIOR = CDec(mDetalle.Cells("PAE_AMASUPERIOR").Value)
                        .PAE_ESTADO = True
                        .PAE_FEC_GRAB = Now
                        .USU_ID = SessionServer.UserId
                        .MarkAsAdded()
                    End With
                    mEIN.ParametroEntidad.Add(nPAE)
                End If
            Next

            BCEntidadInspeccion.MantenimientoEntidadInspeccion(mEIN)
            MessageBox.Show(mEIN.EIN_ID)
            LimpiarControles()
        End If

        Call validacion_desactivacion(False, 3)
    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mEIN = New EntidadInspeccion
        mEIN.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "EntidadInspeccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarEntidadInspeccion(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
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

    Private Sub txtEntidadInspeccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidadInspeccion.KeyDown
        If e.KeyCode = Keys.Enter Then txtEntidadInspeccion_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("PAE_ID").Tag Is Nothing Then
            CType(e.Row.Cells("PAE_ID").Tag, ParametroEntidad).MarkAsDeleted()
        End If
    End Sub
End Class

