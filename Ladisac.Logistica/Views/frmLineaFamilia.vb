Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO

Public Class frmLineaFamilia

    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCLineaFamilia As Ladisac.BL.IBCLineaFamilia
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mLineaFamilia As LineasFamilia

    'ingreso de codigo
    Private Sub frmLineaFamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        'se llama al procedimiento de paso rapido entre cajas de texto.
     

        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 0
        txtDescripcion.TabIndex = 1
        txtFamilia.TabIndex = 2

    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mLineaFamilia.LIN_ID
        txtDescripcion.Text = mLineaFamilia.LIN_DESCRIPCION
        txtFamilia.Text = mLineaFamilia.FamiliaArticulos.FAM_DESCRIPCION
        txtFamilia.Tag = mLineaFamilia.FamiliaArticulos.FAM_ID
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "LineaFamilia"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarLineaFamilia(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarLineaFamilia(ByVal LIN_Id As String)
        mLineaFamilia = BCLineaFamilia.LineaFamiliaGetById(LIN_Id)
        mLineaFamilia.MarkAsModified()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------


        If mLineaFamilia IsNot Nothing Then
            mLineaFamilia.LIN_DESCRIPCION = txtDescripcion.Text
            mLineaFamilia.FAM_ID = txtFamilia.Tag
            mLineaFamilia.LIN_ESTADO = True
            mLineaFamilia.LIN_FEC_GRAB = Now
            mLineaFamilia.USU_ID = SessionServer.UserId
            BCLineaFamilia.MantenimientoLineaFamilia(mLineaFamilia)
            MessageBox.Show(mLineaFamilia.LIN_ID)
            LimpiarControles()
        End If

        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mLineaFamilia = New LineasFamilia
        mLineaFamilia.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtDescripcion.Focus()
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mLineaFamilia = Nothing
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        txtFamilia.Text = String.Empty
        txtFamilia.Tag = Nothing


        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtFamilia_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFamilia.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "FamiliaArticulo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFamilia.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'FAM_Id
            txtFamilia.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.
   

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtDescripcion.Text.Trim) = 0 Then Error_validacion.SetError(txtDescripcion, "Ingrese la Descripción") : txtDescripcion.Focus() : flag = False
        If Len(txtFamilia.Text.Trim) = 0 Then Error_validacion.SetError(txtFamilia, "Ingrese la Dirección") : txtFamilia.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.txtDescripcion.MaxLength = 45
        Me.txtFamilia.MaxLength = 45
    End Sub

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

    Private Sub txtFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then txtFamilia_DoubleClick(Nothing, Nothing)
    End Sub
End Class
