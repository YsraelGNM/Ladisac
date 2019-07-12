Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms

Public Class frmEntidadInspeccion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCEntidadInspeccion As Ladisac.BL.IBCEntidadInspeccion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mEIN As EntidadInspeccion

    Private Sub frmEntidadInspeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
       
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 3
        txtEntidad.TabIndex = 1
        txtInspeccion.TabIndex = 2

    End Sub


    Sub LimpiarControles()
        mEIN = Nothing
        txtCodigo.Text = String.Empty
        txtEntidad.Text = String.Empty
        txtEntidad.Tag = Nothing
        txtInspeccion.Text = String.Empty
        txtInspeccion.Tag = Nothing
        lblRuta.Text = String.Empty
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

    Private Sub txtInspeccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInspeccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Inspeccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtInspeccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'INS_Id
            txtInspeccion.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Public Overrides Sub OnManEliminar()
        If mEIN IsNot Nothing Then
            mEIN.MarkAsDeleted()
            BCEntidadInspeccion.MantenimientoEntidadInspeccion(mEIN)
            Call LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        If mEIN IsNot Nothing Then
            mEIN.ENO_ID = CInt(txtEntidad.Tag)
            mEIN.INS_ID = CInt(txtInspeccion.Tag)
            mEIN.EIN_ESTADO = True
            mEIN.EIN_FEC_GRAB = Now
            mEIN.USU_ID = SessionServer.UserId
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
        txtEntidad.Focus()
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

    Sub CargarEntidadInspeccion(ByVal EIN_Id As Integer)
        mEIN = BCEntidadInspeccion.EntidadInspeccionGetById(EIN_Id)
        mEIN.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mEIN.EIN_ID
        txtEntidad.Text = mEIN.Entidad.ENO_DESCRIPCION
        txtEntidad.Tag = mEIN.ENO_ID
        txtInspeccion.Text = mEIN.Inspeccion.INS_DESCRIPCION
        txtInspeccion.Tag = mEIN.INS_ID
        lblRuta.Text = mEIN.Entidad.ENO_RUTA
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
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

    Private Sub txtInspeccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInspeccion.KeyDown
        If e.KeyCode = Keys.Enter Then txtInspeccion_DoubleClick(Nothing, Nothing)
    End Sub
End Class
