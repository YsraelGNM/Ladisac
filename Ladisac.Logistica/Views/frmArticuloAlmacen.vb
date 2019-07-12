Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO

Public Class frmArticuloAlmacen
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCArticuloAlmacen As Ladisac.BL.IBCArticuloAlmacen
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mArticuloAlmacen As ArticuloAlmacen

    'ingreso de codigo
    Private Sub frmArticuloAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()


        '-------------------------------------------------------------
        'se llama al procedimiento de paso rapido entre cajas de texto.
       
        Me.txtArticulo.TabIndex = 0
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)
        txtArticulo.TabIndex = 3
        txtAlmacen.TabIndex = 1
        txtUbicacion.TabIndex = 2
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mArticuloAlmacen = Nothing
        txtArticulo.Text = String.Empty
        txtArticulo.Tag = Nothing
        txtAlmacen.Text = String.Empty
        txtAlmacen.Tag = Nothing
        txtUbicacion.Text = String.Empty
        txtUbicacion.Tag = Nothing
        numStockMinimo.Text = 0

        '------------------------
        Error_validacion.Clear()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "ArticuloAlmacen"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarArticuloAlmacen(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarArticuloAlmacen(ByVal ARA_Id As Integer)
        mArticuloAlmacen = BCArticuloAlmacen.ArticuloAlmacenGetById(ARA_Id)
        mArticuloAlmacen.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtArticulo.Text = mArticuloAlmacen.Articulos.ART_DESCRIPCION
        txtArticulo.Tag = mArticuloAlmacen.ART_ID
        txtAlmacen.Text = mArticuloAlmacen.Almacen.ALM_DESCRIPCION
        txtAlmacen.Tag = mArticuloAlmacen.ALM_ID
        txtUbicacion.Text = mArticuloAlmacen.UbicacionAlmacen.UBI_DESCRIPCION
        txtUbicacion.Tag = mArticuloAlmacen.UBI_ID
        numStockMinimo.Text = mArticuloAlmacen.ARA_STOCK_MINIMO
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------


        If mArticuloAlmacen IsNot Nothing Then
            mArticuloAlmacen.ART_ID = txtArticulo.Tag
            mArticuloAlmacen.ALM_ID = CInt(txtAlmacen.Tag)
            If mArticuloAlmacen.ChangeTracker.State = ObjectState.Added Then
                mArticuloAlmacen.ARA_STOCK = 0
                mArticuloAlmacen.ARA_COSTO_PROMEDIO = 0
                mArticuloAlmacen.ARA_STOCK_MINIMO = 0
            End If
            mArticuloAlmacen.ARA_STOCK_MINIMO = numStockMinimo.Text
            mArticuloAlmacen.UBI_ID = CInt(txtUbicacion.Tag)
            mArticuloAlmacen.ARA_ESTADO = True
            mArticuloAlmacen.ARA_FEC_GRAB = Now
            mArticuloAlmacen.USU_ID = SessionServer.UserId
            BCArticuloAlmacen.MantenimientoArticuloAlmacen(mArticuloAlmacen)
            MessageBox.Show(mArticuloAlmacen.ARA_ID)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)

    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mArticuloAlmacen = New ArticuloAlmacen
        mArticuloAlmacen.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtArticulo.Focus()
    End Sub

    Private Sub txtAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlmacen.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Almacen"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtAlmacen.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Alm_Id
            txtAlmacen.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtArticulo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArticulo.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Articulo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArticulo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Art_Id
            txtArticulo.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtUbicacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUbicacion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "UbicacionAlmacen"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtUbicacion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ubi_Id
            txtUbicacion.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
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
        If Len(txtAlmacen.Text.Trim) = 0 Then Error_validacion.SetError(txtAlmacen, "Ingrese el Almacen") : txtAlmacen.Focus() : flag = False
        If Len(txtArticulo.Text.Trim) = 0 Then Error_validacion.SetError(txtArticulo, "Ingrese el Articulo") : txtArticulo.Focus() : flag = False
        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.txtArticulo.MaxLength = 160
        Me.txtAlmacen.MaxLength = 160
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
        If mArticuloAlmacen IsNot Nothing Then
            mArticuloAlmacen.MarkAsDeleted()
            BCArticuloAlmacen.MantenimientoArticuloAlmacen(mArticuloAlmacen)
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
    Private Sub txtAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.Enter Then txtAlmacen_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then txtArticulo_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtUbicacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUbicacion.KeyDown
        If e.KeyCode = Keys.Enter Then txtUbicacion_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub numStockMinimo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numStockMinimo.KeyDown
        If Not IsNumeric(numStockMinimo.Text) Then
            e.Handled = True
        End If
    End Sub
End Class
