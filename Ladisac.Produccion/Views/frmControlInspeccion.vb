Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmControlInspeccion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCControlInspeccion As Ladisac.BL.IBCControlInspeccion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mCIN As ControlInspeccion

    'ingreso de codigo
    Private Sub frmControlInspeccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.

        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 3
        txtProduccion.TabIndex = 0
        txtOperador.TabIndex = 1
        txtObservacion.TabIndex = 2


    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mCIN = Nothing
        txtCodigo.Text = String.Empty
        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        txtOperador.Text = String.Empty
        txtOperador.Tag = Nothing
        dtpFecha.Value = Today
        txtObservacion.Text = String.Empty



        '------------------------------------------
        Error_validacion.Clear()

    End Sub

    Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
            txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtOperador_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOperador.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'CType(sender, TextBox).Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            'CType(sender, TextBox).Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
            txtOperador.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtOperador.Text = frm.dgvLista.CurrentRow.Cells(2).Value

        End If
        frm.Dispose()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '---------------------------------------------



        If mCIN IsNot Nothing Then
            mCIN.CIN_FECHA = dtpFecha.Value
            mCIN.PRO_ID = CInt(txtProduccion.Tag)
            mCIN.PER_ID_OPERADOR = txtOperador.Tag
            mCIN.CIN_OBSERVACION = txtObservacion.Text
            mCIN.CIN_ESTADO = True
            mCIN.CIN_FEC_GRAB = Now
            mCIN.USU_ID = SessionServer.UserId
            BCControlInspeccion.MantenimientoControlInspeccion(mCIN)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mCIN = New ControlInspeccion
        mCIN.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtProduccion.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ControlInspeccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarControlInspeccion(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarControlInspeccion(ByVal CIN_Id As Integer)
        mCIN = BCControlInspeccion.ControlInspeccionGetById(CIN_Id)
        mCIN.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mCIN.CIN_ID
        dtpFecha.Value = mCIN.CIN_FECHA
        txtProduccion.Text = mCIN.Produccion.PRO_ID
        txtProduccion.Tag = mCIN.Produccion.PRO_ID
        txtOperador.Text = mCIN.Personas.PER_APE_PAT & " " & mCIN.Personas.PER_NOMBRES
        txtOperador.Tag = mCIN.PER_ID_OPERADOR
        txtObservacion.Text = mCIN.CIN_OBSERVACION
    End Sub




    '===================================================================================================================
    '----procedimiento de validaciones


    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtProduccion.Text.Trim) = 0 Then Error_validacion.SetError(txtProduccion, "Ingrese la Produccion") : txtProduccion.Focus() : flag = False
        If Len(txtOperador.Text.Trim) = 0 Then Error_validacion.SetError(txtOperador, "Ingrese al Operador") : txtOperador.Focus() : flag = False
        If Len(txtObservacion.Text.Trim) = 0 Then Error_validacion.SetError(txtObservacion, "Ingrese las Observaciones") : txtObservacion.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        'Me.txtProduccion.MaxLength = 100
        Me.txtOperador.MaxLength = 160
        Me.txtObservacion.MaxLength = 5000
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
        If mCIN IsNot Nothing Then
            mCIN.MarkAsDeleted()
            BCControlInspeccion.MantenimientoControlInspeccion(mCIN)
            Call LimpiarControles()
            Call validacion_desactivacion(False, 7)
        End If
       
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


    Private Sub txtProduccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduccion.KeyDown
        If e.KeyCode = Keys.Enter Then txtProduccion_DoubleClick(Nothing, Nothing)

    End Sub

    Private Sub txtOperador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperador.KeyDown
        If e.KeyCode = Keys.Enter Then txtOperador_DoubleClick(Nothing, Nothing)
    End Sub
End Class

