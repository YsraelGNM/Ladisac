Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO

Public Class frmAlmacen
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCAlmacen As Ladisac.BL.IBCAlmacen
    <Dependency()> _
    Public Property BCDistrito As Ladisac.BL.IBCDistrito
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mAlmacen As Almacen

    'ingresar codigo
    Private Sub frmAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarDistrito()
        LimpiarControles()


        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.---------    1->tipo textbox     2->combo
        Me.txtDescripcion.TabIndex = 0
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 0
        txtDescripcion.TabIndex = 1
        txtDireccion.TabIndex = 2
        cboDistrito.TabIndex = 3
        txtTelefono.TabIndex = 4
        txtResponsable.TabIndex = 5


    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mAlmacen.ALM_ID
        txtDescripcion.Text = mAlmacen.ALM_DESCRIPCION
        cboDistrito.SelectedValue = mAlmacen.DIS_ID
        txtDireccion.Text = mAlmacen.ALM_DIRECCION
        txtTelefono.Text = mAlmacen.ALM_TELEFONOS
        If mAlmacen.Personas IsNot Nothing Then txtResponsable.Text = mAlmacen.Personas.PER_APE_PAT & " " & mAlmacen.Personas.PER_APE_MAT
        If mAlmacen.Personas IsNot Nothing Then txtResponsable.Tag = mAlmacen.PER_ID_RESPONSABLE
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Almacen"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarAlmacen(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Private Sub txtResponsable_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResponsable.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtResponsable.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtResponsable.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub
    Private Sub txtResponsable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtResponsable.KeyDown
        If e.KeyCode = Keys.Enter Then txtResponsable_DoubleClick(Nothing, Nothing)
    End Sub
    Sub CargarAlmacen(ByVal TPA_Id As Integer)
        mAlmacen = BCAlmacen.AlmacenGetById(TPA_Id)
        mAlmacen.MarkAsModified()
    End Sub

    Sub CargarDistrito()
        Dim ds As New DataSet
        Dim query = BCDistrito.ListaDistrito()
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboDistrito
            .DisplayMember = "DIS_Descripcion"
            .ValueMember = "DIS_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------

        If mAlmacen IsNot Nothing Then
            mAlmacen.ALM_DESCRIPCION = txtDescripcion.Text
            mAlmacen.ALM_DIRECCION = txtDireccion.Text
            mAlmacen.DIS_ID = cboDistrito.SelectedValue
            mAlmacen.ALM_TELEFONOS = txtTelefono.Text
            mAlmacen.PER_ID_RESPONSABLE = txtResponsable.Tag
            mAlmacen.ALM_ESTADO = True
            mAlmacen.ALM_FEC_GRAB = Now
            mAlmacen.USU_ID = SessionServer.UserId
            BCAlmacen.MantenimientoAlmacen(mAlmacen)
            MessageBox.Show(mAlmacen.ALM_ID)
            LimpiarControles()

        End If


        '-------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mAlmacen = New Almacen
        mAlmacen.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtDescripcion.Focus()
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mAlmacen = Nothing
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        txtDireccion.Text = String.Empty
        cboDistrito.SelectedIndex = -1
        txtTelefono.Text = String.Empty
        txtResponsable.Text = String.Empty
        txtResponsable.Tag = Nothing


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
        If Len(txtDireccion.Text.Trim) = 0 Then Error_validacion.SetError(txtDireccion, "Ingrese la Dirección") : txtDireccion.Focus() : flag = False
        If Len(cboDistrito.Text.Trim) = 0 Then Error_validacion.SetError(cboDistrito, "Ingrese el Distrito") : cboDistrito.Focus() : flag = False
        If Len(txtTelefono.Text.Trim) = 0 Then Error_validacion.SetError(txtTelefono, "Ingrese el Numero de Telefono") : txtTelefono.Focus() : flag = False
        If Len(txtResponsable.Text.Trim) = 0 Then Error_validacion.SetError(txtResponsable, "Ingrese el Responsable del Almacen") : txtResponsable.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.txtDescripcion.MaxLength = 160
        Me.txtDireccion.MaxLength = 160
        Me.cboDistrito.DropDownStyle = ComboBoxStyle.DropDownList
        Me.txtTelefono.MaxLength = 30
    End Sub

    'validamos el campo telefono para q acepte solo numeros
    Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        If Not Char.IsNumber(e.KeyChar) Then : e.Handled = True : End If
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
        If mAlmacen IsNot Nothing Then
            mAlmacen.ALM_ESTADO = False
            mAlmacen.ALM_FEC_GRAB = Now
            mAlmacen.USU_ID = SessionServer.UserId
            BCAlmacen.MantenimientoAlmacen(mAlmacen)
        End If

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
