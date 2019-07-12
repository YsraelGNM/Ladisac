Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms

Public Class frmEntidad
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mEntidad As Entidad
    Protected mEntidadPadre As Entidad

    Private Sub frmEntidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 8
        txtTipoEntidad.TabIndex = 1
        txtCodPadre.TabIndex = 2
        txtDescripcion.TabIndex = 3
        txtHora.TabIndex = 4
        txtKilometros.TabIndex = 5
        txtTN.TabIndex = 6
        txtDia.TabIndex = 7
        txtUso.TabIndex = 8

    End Sub

    Sub LlenarControles()
        'Para el Padre
        mEntidadPadre = BCEntidad.EntidadGetById(mEntidad.ENO_ID_PADRE)

        txtCodigo.Text = mEntidad.ENO_ID
        txtTipoEntidad.Tag = mEntidad.TEN_ID
        txtTipoEntidad.Text = mEntidad.TipoEntidad.TEN_DESCRIPCION
        txtDescripcion.Text = mEntidad.ENO_DESCRIPCION
        txtCodPadre.Tag = mEntidad.ENO_ID_PADRE
        txtCodPadre.Text = mEntidadPadre.ENO_DESCRIPCION
        txtHora.Text = mEntidad.ENO_HORAS
        txtKilometros.Text = mEntidad.ENO_KILOMETROS
        txtTN.Text = mEntidad.ENO_TN
        txtDia.Text = mEntidad.ENO_DIA
        txtUso.Text = mEntidad.ENO_USO
        txtPlaca.Tag = mEntidad.UNT_ID
        txtPlaca.Text = mEntidad.UNT_ID
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
        mEntidad = BCEntidad.EntidadGetById(ENO_Id)
        mEntidad.MarkAsModified()
    End Sub

    Public Overrides Sub OnManEliminar()
        If mEntidad IsNot Nothing Then
            mEntidad.MarkAsDeleted()
            BCEntidad.MantenimientoEntidad(mEntidad)
            Call LimpiarControles()
            Call validacion_desactivacion(False, 3)
        End If
    End Sub

    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub

        If mEntidad IsNot Nothing Then
            mEntidad.TEN_ID = CInt(txtTipoEntidad.Tag)
            mEntidad.ENO_DESCRIPCION = txtDescripcion.Text
            mEntidad.ENO_ID_PADRE = CInt(txtCodPadre.Tag)
            mEntidad.ENO_HORAS = CDec(txtHora.Text)
            mEntidad.ENO_KILOMETROS = CDec(txtKilometros.Text)
            mEntidad.ENO_TN = CDec(txtTN.Text)
            mEntidad.ENO_DIA = CDec(txtDia.Text)
            mEntidad.ENO_USO = CDec(txtUso.Text)
            mEntidad.UNT_ID = txtPlaca.Tag
            mEntidad.CentroCosto = txtCentroCosto.Text
            mEntidad.ENO_ESTADO = True
            mEntidad.ENO_FEC_GRAB = Now
            mEntidad.USU_ID = SessionServer.UserId
            BCEntidad.MantenimientoEntidad(mEntidad)
            MessageBox.Show(mEntidad.ENO_ID)
            LimpiarControles()
        End If
        Call validacion_desactivacion(False, 3)
    End Sub

    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mEntidad = New Entidad
        mEntidad.MarkAsAdded()
        Call validacion_desactivacion(True, 2)
        txtTipoEntidad.Focus()
    End Sub

    Sub LimpiarControles()
        mEntidad = Nothing
        txtCodigo.Text = String.Empty
        txtTipoEntidad.Tag = Nothing
        txtTipoEntidad.Text = String.Empty
        txtCodPadre.Tag = Nothing
        txtCodPadre.Text = String.Empty
        txtDescripcion.Text = String.Empty
        txtHora.Text = "0.00"
        txtKilometros.Text = "0.00"
        txtTN.Text = "0.00"
        txtDia.Text = "0.00"
        txtUso.Text = "0.00"
        txtPlaca.Text = String.Empty
        txtPlaca.Tag = Nothing
        txtCentroCosto.Text = String.Empty
        txtCentroCosto.Tag = Nothing
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If txtCodPadre.Tag Is Nothing Then Error_validacion.SetError(txtCodPadre, "Ingrese un Padre a la Entidad") : txtCodPadre.Focus() : flag = False
        If txtCentroCosto.Text = "" Then Error_validacion.SetError(txtCentroCosto, "Ingrese el Centro de Costo de Spring") : txtCentroCosto.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    Private Sub txtTipoEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTipoEntidad.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "TipoEntidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtTipoEntidad.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'TEN_Id
            txtTipoEntidad.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'TEN_Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtCodPadre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodPadre.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCodPadre.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ENO_Id
            txtCodPadre.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'ENO_Descripcion
        End If
        frm.Dispose()
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

    Private Sub txtTipoEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTipoEntidad.KeyDown
        If e.KeyCode = Keys.Enter Then txtTipoEntidad_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtCodPadre_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodPadre.KeyDown
        If e.KeyCode = Keys.Enter Then txtCodPadre_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtPlaca_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlaca.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Placa"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPlaca.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'UNT_Id
            txtPlaca.Text = frm.dgvLista.CurrentRow.Cells(0).Value 'UNT_Id
        End If
        frm.Dispose()
    End Sub
End Class
