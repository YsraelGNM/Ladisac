Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmPlanMantenimiento
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCMantto As Ladisac.BL.IBCMantto
    <Dependency()> _
    Public Property BCPlanMantto As Ladisac.BL.IBCPlanMantenimiento
    <Dependency()> _
    Public Property BCTipoMantto As Ladisac.BL.IBCTipoMantto
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mPlanMantto As PlanMantto
    Dim query As String
    Dim ds As DataSet

    Private Sub frmPlanMantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        llenarCbo()
        LimpiarControles()

        txtCodigo.TabIndex = 5
        txtEntidad.TabIndex = 1
        cboMantenimiento.TabIndex = 2
        cboTipoMantto.TabIndex = 3
        numHora.TabIndex = 4
        numHoraUtil.TabIndex = 5
        numKilometro.TabIndex = 6
        numKilometroUtil.TabIndex = 7
        numTn.TabIndex = 8
        numTnUtil.TabIndex = 9
        numDia.TabIndex = 10
        numDiaUtil.TabIndex = 11
        numUso.TabIndex = 12
        numUsoUtil.TabIndex = 13
        numHrEstim.TabIndex = 14
        cboTipResponsable.TabIndex = 15
        dgvSuministro.TabIndex = 16
        txtProcedimiento.TabIndex = 17

        Call validacion_desactivacion(False, 1)
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Sub LimpiarControles()
        mPlanMantto = Nothing
        txtCodigo.Text = String.Empty
        txtEntidad.Text = String.Empty
        txtEntidad.Tag = Nothing
        cboMantenimiento.SelectedIndex = -1
        cboTipoMantto.SelectedIndex = -1
        numHora.Value = 0
        numKilometro.Value = 0
        numTn.Value = 0
        numDia.Value = 0
        numUso.Value = 0
        numHoraUtil.Value = 0
        numKilometroUtil.Value = 0
        numTnUtil.Value = 0
        numDiaUtil.Value = 0
        numUsoUtil.Value = 0
        txtProcedimiento.Text = String.Empty
        cboTipResponsable.SelectedText = String.Empty
        numHrEstim.Value = 0
        dgvSuministro.Rows.Clear()
        dgvSuministro.DataSource = Nothing
        lblRuta.Text = String.Empty
    End Sub

    Sub llenarCbo()
        Try
            ds = New DataSet
            query = BCMantto.ListaMantto()
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            cboMantenimiento.DisplayMember = "MTO_DESCRIPCION"
            cboMantenimiento.ValueMember = "MTO_ID"
            cboMantenimiento.DataSource = ds.Tables(0)

            ds = New DataSet
            query = BCTipoMantto.ListaTipoMantto
            rea = New StringReader(query)
            ds.ReadXml(rea)
            cboTipoMantto.DisplayMember = "TMO_DESCRIPCION"
            cboTipoMantto.ValueMember = "TMO_ID"
            cboTipoMantto.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntidad.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEntidad.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
            txtEntidad.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
            lblRuta.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Ruta
        End If
        frm.Dispose()
    End Sub

    Private Sub dgvSuministro_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSuministro.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "Articulo"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvSuministro.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                    dgvSuministro.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'ART_Codigo
                    dgvSuministro.CurrentRow.Cells("ART_Descripcion").Value = frm.dgvLista.CurrentRow.Cells(2).Value & " - " & frm.dgvLista.CurrentRow.Cells(3).Value 'ART_Descripcion
                End If
        End Select
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManEliminar()
        If mPlanMantto IsNot Nothing Then
            For cont As Integer = mPlanMantto.SuministroPlanMantto.Count - 1 To 0 Step -1
                mPlanMantto.SuministroPlanMantto(cont).MarkAsDeleted()
            Next
            mPlanMantto.MarkAsDeleted()
            BCPlanMantto.MantenimientoPlanMantenimiento(mPlanMantto)
            Call LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        If mPlanMantto IsNot Nothing Then
            dgvSuministro.EndEdit()
            mPlanMantto.ENO_ID = CInt(txtEntidad.Tag)
            mPlanMantto.MTO_ID = CInt(cboMantenimiento.SelectedValue)
            mPlanMantto.TMO_ID = CInt(cboTipoMantto.SelectedValue)
            mPlanMantto.PMO_HORA = numHora.Value
            mPlanMantto.PMO_KILOMETRO = numKilometro.Value
            mPlanMantto.PMO_TN = numTn.Value
            mPlanMantto.PMO_DIA = numDia.Value
            mPlanMantto.PMO_USO = numUso.Value
            mPlanMantto.PMO_Procedimiento = txtProcedimiento.Text
            mPlanMantto.PMO_Hora_Estimada = numHrEstim.Value
            mPlanMantto.PMO_Tipo_Responsable = cboTipResponsable.SelectedText
            mPlanMantto.PMO_ESTADO = True
            mPlanMantto.PMO_FEC_GRAB = Now
            mPlanMantto.USU_ID = SessionServer.UserId
            For Each mDetalle As DataGridViewRow In dgvSuministro.Rows
                If Not mDetalle.Cells("SPM_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("SPM_ID").Tag, SuministroPlanMantto)
                        .ART_ID = mDetalle.Cells("ART_CODIGO").Tag
                        .SPM_CANTIDAD = CDec(mDetalle.Cells("SPM_CANTIDAD").Value)
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("ART_CODIGO").Value Is Nothing Then
                    Dim nSPM As New SuministroPlanMantto
                    With nSPM
                        .ART_ID = mDetalle.Cells("ART_CODIGO").Tag
                        .SPM_CANTIDAD = CDec(mDetalle.Cells("SPM_CANTIDAD").Value)
                        .MarkAsAdded()
                    End With
                    mPlanMantto.SuministroPlanMantto.Add(nSPM)
                End If
            Next

            BCPlanMantto.MantenimientoPlanMantenimiento(mPlanMantto)
            MessageBox.Show(mPlanMantto.PMO_ID)
            LimpiarControles()
        End If


        Call validacion_desactivacion(False, 3)
    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mPlanMantto = New PlanMantto
        mPlanMantto.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
        txtEntidad.Focus()
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "PlanMantto"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarPlanMantto(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarPlanMantto(ByVal PMO_Id As Integer)
        mPlanMantto = BCPlanMantto.PlanMantenimientoGetById(PMO_Id)
        mPlanMantto.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mPlanMantto.PMO_ID
        txtEntidad.Tag = mPlanMantto.ENO_ID
        txtEntidad.Text = mPlanMantto.Entidad.ENO_DESCRIPCION
        cboMantenimiento.SelectedValue = mPlanMantto.MTO_ID
        cboTipoMantto.SelectedValue = mPlanMantto.TMO_ID
        numHora.Value = mPlanMantto.PMO_HORA
        numKilometro.Value = mPlanMantto.PMO_KILOMETRO
        numTn.Value = mPlanMantto.PMO_TN
        numDia.Value = mPlanMantto.PMO_DIA
        numUso.Value = mPlanMantto.PMO_USO
        If Not mPlanMantto.PMO_HORA_UTIL Is Nothing Then numHoraUtil.Value = mPlanMantto.PMO_HORA_UTIL Else numHoraUtil.Value = 0
        If Not mPlanMantto.PMO_KILOMETRO_UTIL Is Nothing Then numKilometroUtil.Value = mPlanMantto.PMO_KILOMETRO_UTIL Else numKilometroUtil.Value = 0
        If Not mPlanMantto.PMO_TN_UTIL Is Nothing Then numTnUtil.Value = mPlanMantto.PMO_TN_UTIL Else numTnUtil.Value = 0
        If Not mPlanMantto.PMO_DIA_UTIL Is Nothing Then numDiaUtil.Value = mPlanMantto.PMO_DIA_UTIL Else numDiaUtil.Value = 0
        If Not mPlanMantto.PMO_USO_UTIL Is Nothing Then numUsoUtil.Value = mPlanMantto.PMO_USO_UTIL Else numUsoUtil.Value = 0
        txtProcedimiento.Text = mPlanMantto.PMO_Procedimiento
        numHrEstim.Value = mPlanMantto.PMO_Hora_Estimada
        cboTipResponsable.SelectedText = mPlanMantto.PMO_Tipo_Responsable

        For Each mItem In mPlanMantto.SuministroPlanMantto
            Dim nRow As New DataGridViewRow
            dgvSuministro.Rows.Add(nRow)
            dgvSuministro.Rows(dgvSuministro.Rows.Count - 2).Cells("SPM_ID").Value = mItem.SPM_ID
            dgvSuministro.Rows(dgvSuministro.Rows.Count - 2).Cells("SPM_ID").Tag = mItem
            dgvSuministro.Rows(dgvSuministro.Rows.Count - 2).Cells("ART_CODIGO").Value = mItem.Articulos.ART_Codigo
            dgvSuministro.Rows(dgvSuministro.Rows.Count - 2).Cells("ART_CODIGO").Tag = mItem.ART_ID
            dgvSuministro.Rows(dgvSuministro.Rows.Count - 2).Cells("ART_DESCRIPCION").Value = mItem.Articulos.ART_DESCRIPCION
            dgvSuministro.Rows(dgvSuministro.Rows.Count - 2).Cells("SPM_CANTIDAD").Value = mItem.SPM_CANTIDAD
        Next
        lblRuta.Text = mPlanMantto.Entidad.ENO_RUTA
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

    Private Sub txtEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidad.KeyDown
        If e.KeyCode = Keys.Enter Then txtEntidad_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvSuministro_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSuministro.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        If dgvSuministro.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
            frm.Tabla = "Articulo"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvSuministro.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
                dgvSuministro.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value 'ART_Codigo
                dgvSuministro.CurrentRow.Cells("ART_Descripcion").Value = frm.dgvLista.CurrentRow.Cells(2).Value & " - " & frm.dgvLista.CurrentRow.Cells(3).Value 'ART_Descripcion
            End If
        End If
        frm.Dispose()
    End Sub
End Class
