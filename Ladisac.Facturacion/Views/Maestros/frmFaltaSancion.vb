Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmFaltaSancion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCFaltaSancion As Ladisac.BL.IBCFaltaSancion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mFSA As FaltaSancion

    Private Sub frmFaltaSancion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        Call validacion_desactivacion(False, 1)
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mFSA = Nothing
        txtCodigo.Text = String.Empty
        txtCategoria.Text = String.Empty
        txtDescripcion.Text = String.Empty
        txtPer_Id.Text = String.Empty
        txtPer_Id.Tag = Nothing
        '--------------------------
        Error_validacion.Clear()
    End Sub


    Private Sub txtPer_Id_Proveedor_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPer_Id.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPer_Id.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtPer_Id.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub


    Private Sub txtPer_Id_Proveedor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPer_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPer_Id_Proveedor_DoubleClick(Nothing, Nothing)
        End If
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If mFSA IsNot Nothing Then
            mFSA.FSA_CATEGORIA = txtCategoria.Text
            mFSA.FSA_DESCRIPCION = txtDescripcion.Text
            mFSA.PER_ID_AUTORIZADO = txtPer_Id.Tag
            mFSA.FSA_ESTADO = True
            mFSA.FSA_FEC_GRAB = Now
            mFSA.USU_ID = SessionServer.UserId
            BCFaltaSancion.MantenimientoFaltaSancion(mFSA)
            MessageBox.Show(mFSA.FSA_ID)
            LimpiarControles()
        End If

        '-------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mFSA = New FaltaSancion
        mFSA.MarkAsAdded()

        '---------------------------------------
        Call validacion_desactivacion(True, 2)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "FaltaSancion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarFaltaSancion(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarFaltaSancion(ByVal FSA_Id As Integer)
        mFSA = BCFaltaSancion.FaltaSancionGetById(FSA_Id)
        mFSA.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mFSA.FSA_ID
        txtCategoria.Text = mFSA.FSA_CATEGORIA
        txtDescripcion.Text = mFSA.FSA_DESCRIPCION
        txtPer_Id.Text = mFSA.Personas.PER_APE_PAT
        txtPer_Id.Tag = mFSA.PER_ID_AUTORIZADO

        '' '''''Para saber quien lo hizo
        ''Dim Hecho As Usuarios
        ''Hecho = BCPermisoUsuario.UsuarioGetById(mSOC.USU_ID)
        ''lblHecho.Text = "Hecho por: " & Hecho.USU_DESCRIPCION
    End Sub


    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.
    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtCategoria.Text.Trim) = 0 Then Error_validacion.SetError(txtCategoria, "Ingrese la Categoria de la Falta.") : txtCategoria.Focus() : flag = False
        If Len(txtDescripcion.Text.Trim) = 0 Then Error_validacion.SetError(txtDescripcion, "Ingrese la Descripcion de la Falta.") : txtDescripcion.Focus() : flag = False
        If Len(txtPer_Id.Text.Trim) = 0 Then Error_validacion.SetError(txtPer_Id, "Ingrese la persona que Autoriza la Falta.") : txtPer_Id.Focus() : flag = False
        'If Len(cboTipoVenta.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoVenta, "Ingrese el Tipo de Venta") : cboTipoVenta.Focus() : flag = False
        'If Len(txtObservaciones.Text.Trim) = 0 Then Error_validacion.SetError(txtObservaciones, "Ingrese las Observaciones") : txtObservaciones.Focus() : flag = False
        'If Len(cboMoneda.Text.Trim) = 0 Then Error_validacion.SetError(cboMoneda, "Ingrese el Tipo de Moneda") : cboMoneda.Focus() : flag = False
        'If Len(txtIGV.Text.Trim) = 0 Then Error_validacion.SetError(txtIGV, "Ingrese el IGV") : txtIGV.Focus() : flag = False
        'If Len(txtTipoCambio.Text.Trim) = 0 Then Error_validacion.SetError(txtTipoCambio, "Ingrese el Tipo de Cambio") : txtTipoCambio.Focus() : flag = False


        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function


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
        If mFSA IsNot Nothing Then
            If MessageBox.Show("Seguro de Eliminar la Falta de la Sancion?", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = vbOK Then
                mFSA.MarkAsDeleted()
                BCFaltaSancion.MantenimientoFaltaSancion(mFSA)
                LimpiarControles()
            End If
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

