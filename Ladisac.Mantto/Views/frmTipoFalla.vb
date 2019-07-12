Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms

Public Class frmTipoFalla
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCTipoFalla As Ladisac.BL.IBCTipoFalla
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mTipoFalla As TipoFalla

    Private Sub frmTipoFalla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
        txtCodigo.TabIndex = 2
        txtDescripcion.TabIndex = 1

    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mTipoFalla.TFA_ID
        txtDescripcion.Text = mTipoFalla.TFA_DESCRIPCION
    End Sub

    Public Overrides Sub OnManDeshacerCambios()
        Call LimpiarControles()
        Call validacion_desactivacion(False, 4)
    End Sub

    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "TipoFalla"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarTipoFalla(key)
            LlenarControles()
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarTipoFalla(ByVal TFA_Id As Integer)
        mTipoFalla = BCTipoFalla.TipoFallaGetById(TFA_Id)
        mTipoFalla.MarkAsModified()
    End Sub

    Public Overrides Sub OnManGuardar()
        If mTipoFalla IsNot Nothing Then
            mTipoFalla.TFA_DESCRIPCION = txtDescripcion.Text
            mTipoFalla.TFA_ESTADO = True
            mTipoFalla.TFA_FEC_GRAB = Now
            mTipoFalla.USU_ID = SessionServer.UserId
            BCTipoFalla.MantenimientoTipoFalla(mTipoFalla)
            MessageBox.Show(mTipoFalla.TFA_ID)
            LimpiarControles()
        End If
        Call validacion_desactivacion(False, 3)

    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mTipoFalla = New TipoFalla
        mTipoFalla.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
        txtDescripcion.Focus()
    End Sub

    Sub LimpiarControles()
        mTipoFalla = Nothing
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
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
End Class

