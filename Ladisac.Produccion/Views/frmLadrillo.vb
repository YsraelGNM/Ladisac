Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms

Public Class frmLadrillo
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCLadrillo As Ladisac.BL.IBCLadrillo
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mLadrillo As Ladrillo

    'ingreso de codigo
    Private Sub frmLadrillo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
      
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 7
        txtDescripcion.TabIndex = 0
        numCorte.TabIndex = 1
        numTabla.TabIndex = 2
        numTiempo.TabIndex = 3
        numTemperatura.TabIndex = 4
        numVagon.TabIndex = 5
        numParametroQuema.TabIndex = 6

    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mLadrillo.LAD_ID
        txtDescripcion.Text = mLadrillo.Articulos.ART_DESCRIPCION
        numCorte.Value = mLadrillo.LAD_CANT_CORTE
        numTabla.Value = mLadrillo.LAD_CANT_TABLA
        numTiempo.Value = mLadrillo.LAD_TIEMPO_COCCION
        numTemperatura.Value = mLadrillo.LAD_TEMP_COCCION
        numVagon.Value = mLadrillo.LAD_CANT_VAGON
        numParametroQuema.Value = mLadrillo.LAD_PARAM_QUEMA
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Ladrillo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As String = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarLadrillo(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarLadrillo(ByVal LAD_Id As String)
        mLadrillo = BCLadrillo.LadrilloGetById(LAD_Id)
        mLadrillo.MarkAsModified()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------


        If mLadrillo IsNot Nothing Then
            mLadrillo.LAD_CANT_CORTE = numCorte.Value
            mLadrillo.LAD_CANT_TABLA = numTabla.Value
            mLadrillo.LAD_TIEMPO_COCCION = numTiempo.Value
            mLadrillo.LAD_TEMP_COCCION = numTemperatura.Value
            mLadrillo.LAD_CANT_VAGON = numVagon.Value
            mLadrillo.LAD_PARAM_QUEMA = numParametroQuema.Value
            mLadrillo.LAD_ESTADO = True
            mLadrillo.LAD_FEC_GRAB = Now
            mLadrillo.USU_ID = SessionServer.UserId
            BCLadrillo.MantenimientoLadrillo(mLadrillo)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mLadrillo = New Ladrillo
        mLadrillo.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtDescripcion.Focus()
    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mLadrillo = Nothing
        txtCodigo.Text = String.Empty
        txtDescripcion.Text = String.Empty
        numCorte.Value = 0
        numTabla.Value = 0
        numTiempo.Value = 0
        numTemperatura.Value = 0
        numVagon.Value = 0
        numParametroQuema.Value = 0

        '--------------------------
        Error_validacion.Clear()
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtDescripcion.Text.Trim) = 0 Then Error_validacion.SetError(txtDescripcion, "Ingrese la Descripcion ") : txtDescripcion.Focus() : flag = False
        If Len(numCorte.Text.Trim) = 0 Then Error_validacion.SetError(numCorte, "Ingrese el Numero de Corte") : numCorte.Focus() : flag = False
        If Len(numTabla.Text.Trim) = 0 Then Error_validacion.SetError(numTabla, "Ingrese el Numeo de la Tabla") : numTabla.Focus() : flag = False
        If Len(numTiempo.Text.Trim) = 0 Then Error_validacion.SetError(numTiempo, "Ingrese el Nombre el Tiempo") : numTiempo.Focus() : flag = False
        If Len(numTemperatura.Text.Trim) = 0 Then Error_validacion.SetError(numTemperatura, "Ingrese La Temperatura") : numTemperatura.Focus() : flag = False
        If Len(numVagon.Text.Trim) = 0 Then Error_validacion.SetError(numVagon, "Ingrese Numero por Vagon") : numVagon.Focus() : flag = False
        If Len(numParametroQuema.Text.Trim) = 0 Then Error_validacion.SetError(numParametroQuema, "Ingrese Parametro de Quema") : numParametroQuema.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos
    Private Sub validar_longitud()
        txtDescripcion.MaxLength = 160
        'Me.numCorte.Maximum = 99 : Me.numCorte.DecimalPlaces = 0
        'Me.numTabla.Maximum = 99 : Me.numCorte.DecimalPlaces = 0
        Me.numTiempo.Maximum = 999999999999999 : Me.numCorte.DecimalPlaces = 3
        Me.numTemperatura.Maximum = 999999999999999 : Me.numCorte.DecimalPlaces = 3
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

    

    Private Sub numCorte_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCorte.Enter, numParametroQuema.Enter, numTabla.Enter, numTemperatura.Enter, numTiempo.Enter, numVagon.Enter
        sender.Select(0, sender.Text.ToString.Length)
    End Sub
End Class
