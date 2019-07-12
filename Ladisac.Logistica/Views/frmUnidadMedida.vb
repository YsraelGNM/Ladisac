Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO

Public Class frmUnidadMedida

    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCUnidadMedida As Ladisac.BL.IBCUnidadMedida
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mUM As UnidadMedidaArticulos

    'ingreso de codigo
    Private Sub frmUnidadMedida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()


        'se llama al procedimiento de paso rapido entre cajas de texto.
       
        Me.txtDescripcion.TabIndex = 0
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 4
        cboTipo.TabIndex = 1
        numCantidad.TabIndex = 2
        txtSubDescri.TabIndex = 3

    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mUM.UM_ID
        txtDescripcion.Text = mUM.UM_DESCRIPCION
        cboTipo.SelectedIndex = mUM.UM_TIPO
        numCantidad.Value = mUM.UM_CANT_ELEM
        txtSubDescri.Text = mUM.UM_SUB_DESCRIP
        txtSimbolo.Text = mUM.UM_SIMBOLO
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "UnidadMedida"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarUnidadMedida(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarUnidadMedida(ByVal UM_Id As String)
        mUM = BCUnidadMedida.UnidadMedidaGetById(UM_Id)
        mUM.MarkAsModified()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------

        If mUM IsNot Nothing Then
            mUM.UM_DESCRIPCION = txtDescripcion.Text
            mUM.UM_TIPO = cboTipo.SelectedIndex
            mUM.UM_CANT_ELEM = numCantidad.Value
            mUM.UM_SUB_DESCRIP = txtSubDescri.Text
            mUM.UM_SIMBOLO = txtSimbolo.Text
            mUM.UM_ESTADO = True
            mUM.UM_FEC_GRAB = Now
            mUM.USU_ID = SessionServer.UserId
            BCUnidadMedida.MantenimientoUnidadMedida(mUM)
            MessageBox.Show(mUM.UM_ID)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mUM = New UnidadMedidaArticulos
        mUM.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        Me.txtDescripcion.Focus()

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mUM = Nothing
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        cboTipo.SelectedIndex = -1
        numCantidad.Value = 0
        txtSubDescri.Text = String.Empty
        txtSimbolo.Text = String.Empty

        '--------------------------
        Error_validacion.Clear()

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
        If Len(cboTipo.Text.Trim) = 0 Then Error_validacion.SetError(cboTipo, "Ingrese el Tipo") : cboTipo.Focus() : flag = False
        If Len(numCantidad.Text.Trim) = 0 Then Error_validacion.SetError(numCantidad, "Ingrese la Cantidad") : numCantidad.Focus() : flag = False
        If Len(txtSubDescri.Text.Trim) = 0 Then Error_validacion.SetError(txtSubDescri, "Ingrese una Subdescripcion") : txtSubDescri.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.txtDescripcion.MaxLength = 45
        Me.cboTipo.DropDownStyle = ComboBoxStyle.DropDownList
        Me.numCantidad.Maximum = 9999999999 : Me.numCantidad.DecimalPlaces = 0
        Me.txtSubDescri.MaxLength = 45
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

End Class
