Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms

Public Class frmComponenteInspeccion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCComponenteInspeccion As Ladisac.BL.IBCComponenteInspeccion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mCOM As ComponenteInspeccion

    Private Sub frmComponenteInspeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
        txtCodigo.TabIndex = 4
        txtInspeccion.TabIndex = 1
        txtDescripcion.TabIndex = 2
        txtTitulo.TabIndex = 3

    End Sub

    Sub LimpiarControles()
        mCOM = Nothing
        txtCodigo.Text = String.Empty
        txtInspeccion.Text = String.Empty
        txtInspeccion.Tag = Nothing
        txtDescripcion.Text = String.Empty
        txtTitulo.Text = String.Empty
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
        If mCOM IsNot Nothing Then
            mCOM.MarkAsDeleted()
            BCComponenteInspeccion.MantenimientoComponenteInspeccion(mCOM)
            Call LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        If mCOM IsNot Nothing Then
            mCOM.INS_ID = CInt(txtInspeccion.Tag)
            mCOM.COM_DESCRIPCION = txtDescripcion.Text
            mCOM.COM_TITULO = txtTitulo.Text
            mCOM.COM_ESTADO = True
            mCOM.COM_FEC_GRAB = Now
            mCOM.USU_ID = SessionServer.UserId
            BCComponenteInspeccion.MantenimientoComponenteInspeccion(mCOM)
            MessageBox.Show(mCOM.COM_ID)
            LimpiarControles()
        End If
        Call validacion_desactivacion(False, 3)
    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mCOM = New ComponenteInspeccion
        mCOM.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
        txtInspeccion.Focus()
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "ComponenteInspeccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarComponenteInspeccion(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarComponenteInspeccion(ByVal COM_Id As Integer)
        mCOM = BCComponenteInspeccion.ComponenteInspeccionGetById(COM_Id)
        mCOM.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mCOM.COM_ID
        txtInspeccion.Text = mCOM.Inspeccion.INS_DESCRIPCION
        txtInspeccion.Tag = mCOM.INS_ID
        txtDescripcion.Text = mCOM.COM_DESCRIPCION
        txtTitulo.Text = mCOM.COM_TITULO
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

    Private Sub txtInspeccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInspeccion.KeyDown
        If e.KeyCode = Keys.Enter Then txtInspeccion_DoubleClick(Nothing, Nothing)
    End Sub
End Class

