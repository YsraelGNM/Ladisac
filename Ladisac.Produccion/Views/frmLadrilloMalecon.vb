Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO
Imports System.Windows.Forms

Public Class frmLadrilloMalecon
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCLadrilloMalecon As Ladisac.BL.IBCLadrilloMalecon
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCMaleconPuerta As Ladisac.BL.IBCMaleconPuerta
    <Dependency()> _
    Public Property BCHorno As Ladisac.BL.IBCHorno

    Protected mLadrilloMalecon As LadrilloMalecon

    'ingreso de codigo
    Private Sub frmLadrilloMalecon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.---------    1->tipo textbox     2->combo

        validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 0
        txtArt_Id_Ladrillo.TabIndex = 1
        txtMaleconPuerta.TabIndex = 2
        numCantidad.TabIndex = 3

    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mLadrilloMalecon.LMA_ID
        mLadrilloMalecon.Articulo = BCLadrilloMalecon.ArticuloGetById(mLadrilloMalecon.LAD_ID)
        txtArt_Id_Ladrillo.Text = mLadrilloMalecon.Articulo.ART_DESCRIPCION
        txtArt_Id_Ladrillo.Tag = mLadrilloMalecon.LAD_ID
        mLadrilloMalecon.MaleconPuerta = BCLadrilloMalecon.MaleconPuertaGetById(mLadrilloMalecon.MAL_ID)
        mLadrilloMalecon.MaleconPuerta.PuertaHorno = BCMaleconPuerta.PuertaHornoGetById(mLadrilloMalecon.MaleconPuerta.PUE_ID)
        mLadrilloMalecon.MaleconPuerta.PuertaHorno.Horno = BCHorno.HornoGetById(mLadrilloMalecon.MaleconPuerta.PuertaHorno.HOR_ID)
        txtMaleconPuerta.Text = mLadrilloMalecon.MaleconPuerta.MAL_DESCRIPCION & " -Puerta: " & mLadrilloMalecon.MaleconPuerta.PuertaHorno.PUE_DESCRIPCION & " -Horno: " & mLadrilloMalecon.MaleconPuerta.PuertaHorno.Horno.HOR_DESCRIPCION
        txtMaleconPuerta.Tag = mLadrilloMalecon.MAL_ID
        numCantidad.Value = mLadrilloMalecon.LMA_CANTIDAD
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "LadrilloMalecon"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarLadrilloMalecon(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarLadrilloMalecon(ByVal LMA_Id As Integer)
        mLadrilloMalecon = BCLadrilloMalecon.LadrilloMaleconGetById(LMA_Id)
        mLadrilloMalecon.MarkAsModified()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------



        If mLadrilloMalecon IsNot Nothing Then
            mLadrilloMalecon.LAD_ID = txtArt_Id_Ladrillo.Tag
            mLadrilloMalecon.MAL_ID = CInt(txtMaleconPuerta.Tag)
            mLadrilloMalecon.LMA_CANTIDAD = numCantidad.Value
            mLadrilloMalecon.LMA_ESTADO = True
            mLadrilloMalecon.LMA_FEC_GRAB = Now
            mLadrilloMalecon.USU_ID = SessionServer.UserId
            BCLadrilloMalecon.MantenimientoLadrilloMalecon(mLadrilloMalecon)
            LimpiarControles()
        End If



        '------------------------------------------
        Call validacion_desactivacion(False, 3)


    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mLadrilloMalecon = New LadrilloMalecon
        mLadrilloMalecon.MarkAsAdded()



        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtArt_Id_Ladrillo.Focus()
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mLadrilloMalecon = Nothing
        txtCodigo.Text = String.Empty
        txtArt_Id_Ladrillo.Text = String.Empty
        txtArt_Id_Ladrillo.Tag = Nothing
        txtMaleconPuerta.Text = String.Empty
        txtMaleconPuerta.Tag = Nothing
        numCantidad.Value = 0




        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtArt_Id_Ladrillo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtArt_Id_Ladrillo.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Articulo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtArt_Id_Ladrillo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'ART_Id
            txtArt_Id_Ladrillo.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtMaleconPuerta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaleconPuerta.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "MaleconPuerta"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtMaleconPuerta.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'MAL_Id
            txtMaleconPuerta.Text = frm.dgvLista.CurrentRow.Cells(1).Value & " -Puerta: " & frm.dgvLista.CurrentRow.Cells(2).Value & " -Horno: " & frm.dgvLista.CurrentRow.Cells(3).Value 'Nombres
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
        If Len(txtArt_Id_Ladrillo.Text.Trim) = 0 Then Error_validacion.SetError(txtArt_Id_Ladrillo, "Ingrese el Id del Ladrillo") : txtArt_Id_Ladrillo.Focus() : flag = False
        If Len(txtMaleconPuerta.Text.Trim) = 0 Then Error_validacion.SetError(txtMaleconPuerta, "Ingrese el Nombre del Malecon") : txtMaleconPuerta.Focus() : flag = False
        If Len(numCantidad.Text.Trim) = 0 Then Error_validacion.SetError(numCantidad, "Ingrese la Cantidad") : numCantidad.Focus() : flag = False



        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos
    Private Sub validar_longitud()
        ' Me.txtArt_Id_Ladrillo.MaxLength = 100
        'Me.txtMaleconPuerta.MaxLength = 100
        Me.numCantidad.Maximum = 9999999999999999 : Me.numCantidad.DecimalPlaces = 3
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

    Private Sub txtArt_Id_Ladrillo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArt_Id_Ladrillo.KeyDown
        If e.KeyCode = Keys.Enter Then txtArt_Id_Ladrillo_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtMaleconPuerta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMaleconPuerta.KeyDown
        If e.KeyCode = Keys.Enter Then txtMaleconPuerta_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub numCantidad_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCantidad.Enter
        sender.Select(0, sender.Text.ToString.Length)
    End Sub
End Class

