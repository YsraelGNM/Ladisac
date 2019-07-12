Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO
Imports System.Windows.Forms

Public Class frmMaleconPuerta
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCMaleconPuerta As Ladisac.BL.IBCMaleconPuerta
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mMaleconPuerta As MaleconPuerta

    'ingreso de codigo
    Private Sub frmMaleconPuerta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.---------    1->tipo textbox     2->combo

        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 0
        txtPuertaHorno.TabIndex = 1
        txtDescripcion.TabIndex = 2
        txtDesCorta.TabIndex = 3

    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mMaleconPuerta.MAL_ID
        mMaleconPuerta.PuertaHorno = BCMaleconPuerta.PuertaHornoGetById(mMaleconPuerta.PUE_ID)
        txtPuertaHorno.Text = mMaleconPuerta.PuertaHorno.PUE_DESCRIPCION
        txtPuertaHorno.Tag = mMaleconPuerta.PUE_ID
        txtDescripcion.Text = mMaleconPuerta.MAL_DESCRIPCION
        txtDesCorta.Text = mMaleconPuerta.MAL_DES_CORTA
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "MaleconPuerta"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarMaleconPuerta(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarMaleconPuerta(ByVal MAL_Id As Integer)
        mMaleconPuerta = BCMaleconPuerta.MaleconPuertaGetById(MAL_Id)
        mMaleconPuerta.MarkAsModified()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------


        If mMaleconPuerta IsNot Nothing Then
            mMaleconPuerta.PUE_ID = CInt(txtPuertaHorno.Tag)
            mMaleconPuerta.MAL_DESCRIPCION = txtDescripcion.Text
            mMaleconPuerta.MAL_DES_CORTA = txtDesCorta.Text
            mMaleconPuerta.MAL_ESTADO = True
            mMaleconPuerta.MAL_FEC_GRAB = Now
            mMaleconPuerta.USU_ID = SessionServer.UserId
            BCMaleconPuerta.MantenimientoMaleconPuerta(mMaleconPuerta)
            LimpiarControles()
        End If



        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mMaleconPuerta = New MaleconPuerta
        mMaleconPuerta.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtPuertaHorno.Focus()
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mMaleconPuerta = Nothing
        txtCodigo.Text = String.Empty
        txtPuertaHorno.Text = String.Empty
        txtPuertaHorno.Tag = Nothing
        txtDescripcion.Text = String.Empty
        txtDesCorta.Text = String.Empty


        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtHorno_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPuertaHorno.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "PuertaHorno"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPuertaHorno.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PUE_Id
            txtPuertaHorno.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones


    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtPuertaHorno.Text.Trim) = 0 Then Error_validacion.SetError(txtPuertaHorno, "Ingrese el dato Puerta Horno") : txtPuertaHorno.Focus() : flag = False
        If Len(txtDescripcion.Text.Trim) = 0 Then Error_validacion.SetError(txtDescripcion, "Ingrese la Descripcion") : txtDescripcion.Focus() : flag = False
        If Len(txtDesCorta.Text.Trim) = 0 Then Error_validacion.SetError(txtDesCorta, "Ingrese la Descripcion Corta") : txtDesCorta.Focus() : flag = False
        

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos
    Private Sub validar_longitud()
        'Me.txtPuertaHorno.MaxLength = 100
        Me.txtDescripcion.MaxLength = 255
        Me.txtDesCorta.MaxLength = 255
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



    Private Sub txtPuertaHorno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPuertaHorno.KeyDown

        If e.KeyCode = Keys.Enter Then txtHorno_DoubleClick(Nothing, Nothing)
    End Sub
End Class
