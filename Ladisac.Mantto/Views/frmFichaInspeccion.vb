Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmFichaInspeccion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCFichaInspeccion As Ladisac.BL.IBCFichaInspeccion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCEntidadInspeccion As Ladisac.BL.IBCEntidadInspeccion

    Protected mFIN As FichaInspeccion
    Protected mEIN As EntidadInspeccion

    Private Sub frmFichaInspeccion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    Sub LimpiarControles()
        mFIN = Nothing
        mEIN = Nothing
        txtCodigo.Text = String.Empty
        txtEntidadInspeccion.Text = String.Empty
        txtEntidadInspeccion.Tag = Nothing
        txtEntidad.Text = String.Empty
        txtInspeccion.Text = String.Empty
        txtInspector.Text = String.Empty
        txtInspector.Tag = Nothing
        dtpFecha.Value = Now
        dgvDetalle.Rows.Clear()
        lblRuta.Text = String.Empty
    End Sub

    Private Sub txtEntidadInspeccion_DoubleClick(sender As Object, e As System.EventArgs) Handles txtEntidadInspeccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "EntidadInspeccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarEntidadInspeccion(key)
            If mEIN IsNot Nothing Then
                txtEntidadInspeccion.Tag = key 'EIN_Id
                txtEntidadInspeccion.Text = key 'EIN_ID
                txtEntidad.Text = mEIN.Entidad.ENO_DESCRIPCION
                lblRuta.Text = mEIN.Entidad.ENO_RUTA
                txtInspeccion.Text = mEIN.Inspeccion.INS_DESCRIPCION
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub txtEntidadInspeccion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtEntidadInspeccion.KeyDown
        If e.KeyCode = Keys.Enter Then txtEntidadInspeccion_DoubleClick(Nothing, Nothing)
    End Sub

    Sub CargarEntidadInspeccion(ByVal EIN_Id As Integer)
        mEIN = BCEntidadInspeccion.EntidadInspeccionGetById(EIN_Id)

        For Each mItem In mEIN.ParametroEntidad
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAE_Id").Value = mItem.ComponenteInspeccion.COM_TITULO & " - " & mItem.ComponenteInspeccion.COM_DESCRIPCION & " - " & mItem.PAE_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAE_Id").Tag = mItem.PAE_ID
        Next
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

    Public Overrides Sub OnManGuardar()
        If mFIN IsNot Nothing Then
            dgvDetalle.EndEdit()

            mFIN.EIN_ID = CInt(txtEntidadInspeccion.Tag)
            mFIN.FIN_FECHA = dtpFecha.Value
            mFIN.PER_ID_INSPECTOR = txtInspector.Tag
            mFIN.USU_ID = SessionServer.UserId
            mFIN.FIN_FEC_GRAB = Now
            mFIN.FIN_ESTADO = True

            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("FID_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("FID_ID").Tag, FichaInspeccionDetalle)
                        .PAE_ID = CInt(mDetalle.Cells("PAE_ID").Tag)
                        .FID_VALOR = CDbl(mDetalle.Cells("FID_VALOR").Value)
                        .FID_ESTADO = IIf(mDetalle.Cells("FID_ESTADO").Value, 1, 0)
                        .MarkAsModified()
                    End With
                Else
                    Dim nFID As New FichaInspeccionDetalle
                    With nFID
                        .PAE_ID = CInt(mDetalle.Cells("PAE_ID").Tag)
                        .FID_VALOR = CDbl(mDetalle.Cells("FID_VALOR").Value)
                        .FID_ESTADO = IIf(mDetalle.Cells("FID_ESTADO").Value, 1, 0)
                        .MarkAsAdded()
                    End With
                    mFIN.FichaInspeccionDetalle.Add(nFID)
                End If
            Next

            BCFichaInspeccion.MantenimientoFichaInspeccion(mFIN)
            MessageBox.Show(mFIN.FIN_ID)
            LimpiarControles()
        End If

        Call validacion_desactivacion(False, 3)
    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mFIN = New FichaInspeccion
        mFIN.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "FichaInspeccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarFichaInspeccion(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarFichaInspeccion(ByVal FIN_Id As Integer)
        mFIN = BCFichaInspeccion.FichaInspeccionGetById(FIN_Id)
        mFIN.MarkAsModified()
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mFIN.FIN_ID
        txtEntidadInspeccion.Text = mFIN.EIN_ID
        txtEntidadInspeccion.Tag = mFIN.EIN_ID
        txtEntidad.Text = mFIN.EntidadInspeccion.Entidad.ENO_DESCRIPCION
        txtInspeccion.Text = mFIN.EntidadInspeccion.Inspeccion.INS_DESCRIPCION
        dtpFecha.Value = mFIN.FIN_FECHA
        txtInspector.Text = mFIN.Personas.PER_APE_PAT & " " & mFIN.Personas.PER_APE_MAT & " " & mFIN.Personas.PER_NOMBRES
        txtInspector.Tag = mFIN.PER_ID_INSPECTOR
        lblRuta.Text = mFIN.EntidadInspeccion.Entidad.ENO_RUTA

        For Each mItem In mFIN.FichaInspeccionDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("FID_ID").Value = mItem.FID_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("FID_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAE_ID").Value = mItem.ParametroEntidad.ComponenteInspeccion.COM_TITULO & " - " & mItem.ParametroEntidad.ComponenteInspeccion.COM_DESCRIPCION & " - " & mItem.ParametroEntidad.PAE_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PAE_ID").Tag = mItem.PAE_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("FID_VALOR").Value = mItem.FID_VALOR
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("FID_ESTADO").Value = mItem.FID_ESTADO
        Next
    End Sub

    Private Sub txtInspector_DoubleClick(sender As Object, e As System.EventArgs) Handles txtInspector.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtInspector.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PER_Id
            txtInspector.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtInspector_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtInspector.KeyDown
        If e.KeyCode = Keys.Enter Then txtInspector_DoubleClick(Nothing, Nothing)
    End Sub
End Class
