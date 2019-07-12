Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.IO
Imports System.Windows.Forms

Public Class frmProduccion
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    <Dependency()> _
    Public Property BCTipoProduccion As Ladisac.BL.IBCTipoProduccion
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mProduccion As Produccion

    'ingreso de codigo
    Private Sub frmProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        'Dim mDt As DataTable = BCProduccion.ProduccionxFecha()
        'For Each mRow As DataRow In mDt.Rows
        '    mProduccion = BCProduccion.ProduccionGetById(mRow("PRO_ID"))
        '    mProduccion.MarkAsModified()
        '    Try
        '        BCProduccion.MantenimientoProduccion(mProduccion)
        '    Catch ex As Exception
        '        MsgBox(mProduccion.PRO_ID)
        '    End Try
        'Next




        CargarTipoProduccion()
        LimpiarControles()

        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.---------    1->tipo textbox     2->combo

        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 18
        txtLadrillo.TabIndex = 0
        txtPlanta.TabIndex = 1
        txtExtrusora.TabIndex = 2
        txtCortadora.TabIndex = 3
        txtIng1.TabIndex = 4
        cboTipoProduccion.TabIndex = 5
        txtObservacion.TabIndex = 6
        numCorte.TabIndex = 7
        numTabla.TabIndex = 8
        numVagon.TabIndex = 9
        numHoraInicio.TabIndex = 10
        numHoraFinal.TabIndex = 11
        numReciclaje.TabIndex = 12
        chkFinalizada.TabIndex = 13
        txtConteo.TabIndex = 14
        txtCarga.TabIndex = 15
        txtDiferencia.TabIndex = 16
        txtPorcentaje.TabIndex = 17

    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mProduccion.PRO_ID
        dtpFecha.Value = mProduccion.PRO_FECHA
        txtLadrillo.Text = mProduccion.Ladrillo.Articulos.ART_DESCRIPCION
        txtLadrillo.Tag = mProduccion.LAD_ID
        txtPlanta.Text = mProduccion.Planta.PLA_DESCRIPCION
        txtPlanta.Tag = mProduccion.PLA_ID
        txtExtrusora.Text = mProduccion.Extrusora.EXT_DESCRIPCION
        txtExtrusora.Tag = mProduccion.EXT_ID
        txtCortadora.Text = mProduccion.Cortadora.COR_DESCRIPCION
        txtCortadora.Tag = mProduccion.COR_ID
        cboTipoProduccion.SelectedValue = mProduccion.TPR_ID
        txtObservacion.Text = mProduccion.PRO_OBSERVACION
        numCorte.Value = mProduccion.PRO_CANT_CORTE
        numTabla.Value = mProduccion.PRO_CANT_TABLA
        numVagon.Value = mProduccion.PRO_CANT_VAGON
        numReciclaje.Value = mProduccion.PRO_ESTIMADO_RECICLAJE
        If (mProduccion.PER_ID_ING & "").ToString.Length > 0 Then
            txtIng1.Text = mProduccion.Personas.PER_ALIAS & " " & mProduccion.Personas.PER_APE_PAT
            txtIng1.Tag = mProduccion.PER_ID_ING
        End If
        If (mProduccion.PER_ID_ING2 & "").ToString.Length > 0 Then
            txtIng2.Text = mProduccion.Personas1.PER_ALIAS & " " & mProduccion.Personas1.PER_APE_PAT
            txtIng2.Tag = mProduccion.PER_ID_ING2
        End If
        If (mProduccion.PER_ID_OPE & "").ToString.Length > 0 Then
            txtOpe1.Text = mProduccion.Personas2.PER_ALIAS & " " & mProduccion.Personas2.PER_APE_PAT
            txtOpe1.Tag = mProduccion.PER_ID_OPE
        End If
        If (mProduccion.PER_ID_OPE2 & "").ToString.Length > 0 Then
            txtOpe2.Text = mProduccion.Personas3.PER_ALIAS & " " & mProduccion.Personas3.PER_APE_PAT
            txtOpe2.Tag = mProduccion.PER_ID_OPE2
        End If
        numHoraInicio.Value = mProduccion.PRO_HI
        numHoraFinal.Value = mProduccion.PRO_HF
        chkFinalizada.Checked = mProduccion.PRO_FINALIZADA
        If mProduccion.PRO_FINALIZADA Then
            dtpFechaFinalizada.Value = mProduccion.PRO_FECHA_FINALIZADA
            txtConteo.Text = mProduccion.PRO_CONTEO_FINALIZADA
            txtCarga.Text = mProduccion.PRO_CARGA_FINALIZADA
            txtDiferencia.Text = mProduccion.PRO_CONTEO_FINALIZADA - mProduccion.PRO_CARGA_FINALIZADA
            txtPorcentaje.Text = ((mProduccion.PRO_CONTEO_FINALIZADA - mProduccion.PRO_CARGA_FINALIZADA) * 100) / mProduccion.PRO_CONTEO_FINALIZADA
        End If
    End Sub

    Sub CargarTipoProduccion()
        Dim ds As New DataSet
        Dim query = BCTipoProduccion.ListaTipoProduccion
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboTipoProduccion
            .DisplayMember = "TPR_Descripcion"
            .ValueMember = "TPR_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarProduccion(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarProduccion(ByVal PRO_Id As Integer)
        mProduccion = BCProduccion.ProduccionGetById(PRO_Id)
        mProduccion.MarkAsModified()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------
        If mProduccion IsNot Nothing Then
            mProduccion.PRO_FECHA = dtpFecha.Value
            mProduccion.LAD_ID = txtLadrillo.Tag
            mProduccion.PLA_ID = CInt(txtPlanta.Tag)
            mProduccion.EXT_ID = CInt(txtExtrusora.Tag)
            mProduccion.COR_ID = CInt(txtCortadora.Tag)
            mProduccion.TPR_ID = CInt(cboTipoProduccion.SelectedValue)
            mProduccion.PRO_OBSERVACION = txtObservacion.Text
            mProduccion.PRO_CANT_CORTE = numCorte.Value
            mProduccion.PRO_CANT_TABLA = numTabla.Value
            mProduccion.PRO_CANT_VAGON = numVagon.Value
            mProduccion.PRO_ESTIMADO_RECICLAJE = numReciclaje.Value
            mProduccion.PER_ID_ING = txtIng1.Tag
            mProduccion.PER_ID_ING2 = txtIng2.Tag
            mProduccion.PER_ID_OPE = txtOpe1.Tag
            mProduccion.PER_ID_OPE2 = txtOpe2.Tag
            mProduccion.PRO_HI = numHoraInicio.Value
            mProduccion.PRO_HF = numHoraFinal.Value
            If chkFinalizada.Checked And mProduccion.ChangeTracker.State = ObjectState.Modified Then
                mProduccion.PRO_FINALIZADA = True
                mProduccion.PRO_CONTEO_FINALIZADA = IIf(Len(txtConteo.Text) = 0, Nothing, CInt(txtConteo.Text))
                mProduccion.PRO_CARGA_FINALIZADA = IIf(Len(txtCarga.Text) = 0, Nothing, CInt(txtCarga.Text))
                mProduccion.PRO_FECHA_FINALIZADA = dtpFechaFinalizada.Value
            Else
                mProduccion.PRO_FINALIZADA = False
                mProduccion.PRO_CONTEO_FINALIZADA = Nothing
                mProduccion.PRO_CARGA_FINALIZADA = Nothing
                mProduccion.PRO_FECHA_FINALIZADA = Nothing
            End If
            mProduccion.PRO_ESTADO = True
            mProduccion.PRO_FEC_GRAB = Now
            mProduccion.USU_ID = SessionServer.UserId
            Dim EsNuevo As New Ladisac.BE.ObjectState
            EsNuevo = mProduccion.ChangeTracker.State
            BCProduccion.MantenimientoProduccion(mProduccion)
            MessageBox.Show(mProduccion.PRO_ID)
            If EsNuevo = ObjectState.Added Then
                mProduccion = BCProduccion.ProduccionGetById(mProduccion.PRO_ID)
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmControlParada)()
                frm.mProd = mProduccion
                frm.Show()
            End If
            LimpiarControles()
        End If

        '------------------------------------------
        Call validacion_desactivacion(False, 3)

    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mProduccion = New Produccion
        mProduccion.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtLadrillo.Focus()

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mProduccion = Nothing
        dtpFecha.Value = Today
        txtCodigo.Text = String.Empty
        txtLadrillo.Text = String.Empty
        txtLadrillo.Tag = Nothing
        txtPlanta.Text = String.Empty
        txtPlanta.Tag = Nothing
        txtExtrusora.Text = String.Empty
        txtExtrusora.Tag = Nothing
        txtCortadora.Text = String.Empty
        txtCortadora.Tag = Nothing
        cboTipoProduccion.SelectedIndex = -1
        txtObservacion.Text = String.Empty
        numCorte.Value = 0
        numTabla.Value = 0
        numVagon.Value = 0
        numReciclaje.Value = 3
        txtIng1.Text = String.Empty
        txtIng1.Tag = Nothing
        txtIng2.Text = String.Empty
        txtIng2.Tag = Nothing
        txtOpe1.Text = String.Empty
        txtOpe1.Tag = Nothing
        txtOpe2.Text = String.Empty
        txtOpe2.Tag = Nothing
        numHoraInicio.Value = 0
        numHoraFinal.Value = 0
        chkFinalizada.Checked = False
        txtConteo.Text = String.Empty
        txtCarga.Text = String.Empty
        txtDiferencia.Text = String.Empty
        txtPorcentaje.Text = String.Empty
        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtLadrillo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLadrillo.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Ladrillo"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtLadrillo.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtLadrillo.Text = frm.dgvLista.CurrentRow.Cells(1).Value
            numCorte.Value = frm.dgvLista.CurrentRow.Cells("LAD_CANT_CORTE").Value
            numTabla.Value = frm.dgvLista.CurrentRow.Cells("LAD_CANT_TABLA").Value
            numVagon.Value = frm.dgvLista.CurrentRow.Cells("LAD_CANT_VAGON").Value

            If txtLadrillo.Text.Contains("(S)") Or txtLadrillo.Text.Contains("HUECO") Then
                txtPlanta.Text = " Planta Nº 1"
                txtPlanta.Tag = 17
                txtExtrusora.Text = "Bonfantti 400"
                txtExtrusora.Tag = 149
            Else
                txtPlanta.Text = " Planta Nº 2"
                txtPlanta.Tag = 18
                txtExtrusora.Text = "Bonfantti 500"
                txtExtrusora.Tag = 223
            End If

        End If
        frm.Dispose()
    End Sub

    Private Sub txtPlanta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlanta.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Planta"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtPlanta.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtPlanta.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtExtrusora_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExtrusora.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Extrusora"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtExtrusora.Tag = frm.dgvLista.CurrentRow.Cells(0).Value
            txtExtrusora.Text = frm.dgvLista.CurrentRow.Cells(1).Value
        End If
        frm.Dispose()
    End Sub

    Private Sub txtCortadora_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCortadora.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Cortadora"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCortadora.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'COR_Id
            txtCortadora.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtIng1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIng1.DoubleClick, txtIng2.DoubleClick, txtOpe1.DoubleClick, txtOpe2.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            sender.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            sender.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
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
        If Len(txtLadrillo.Text.Trim) = 0 Then Error_validacion.SetError(txtLadrillo, "Ingrese el Nombre del Ladrillo ") : txtLadrillo.Focus() : flag = False
        If Len(txtPlanta.Text.Trim) = 0 Then Error_validacion.SetError(txtPlanta, "Ingrese el Nombre de la Planta") : txtPlanta.Focus() : flag = False
        If Len(txtExtrusora.Text.Trim) = 0 Then Error_validacion.SetError(txtExtrusora, "Ingrese la Extrusora") : txtExtrusora.Focus() : flag = False
        If Len(txtCortadora.Text.Trim) = 0 Then Error_validacion.SetError(txtCortadora, "Ingrese la Cortadora") : txtCortadora.Focus() : flag = False
        If Len(txtIng1.Text.Trim) = 0 Then Error_validacion.SetError(txtIng1, "Ingrese el Nombre del Ingeniero") : txtIng1.Focus() : flag = False
        If Len(cboTipoProduccion.Text.Trim) = 0 Then Error_validacion.SetError(cboTipoProduccion, "Ingrese el Tipo de Produccion") : cboTipoProduccion.Focus() : flag = False
        If Len(txtObservacion.Text.Trim) = 0 Then Error_validacion.SetError(txtObservacion, "Ingrese las Observaciones") : txtObservacion.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos
    Private Sub validar_longitud()
        Me.txtLadrillo.MaxLength = 160
        Me.txtPlanta.MaxLength = 45
        Me.txtExtrusora.MaxLength = 45
        Me.txtCortadora.MaxLength = 45
        Me.txtIng1.MaxLength = 160
        Me.cboTipoProduccion.DropDownStyle = ComboBoxStyle.DropDownList
        Me.txtObservacion.MaxLength = 255
        'Me.numCorte.Maximum = 99 : Me.numCorte.DecimalPlaces = 0
        'Me.numTabla.Maximum = 99 : Me.numTabla.DecimalPlaces = 0
        Me.numReciclaje.Maximum = 999999999999999 : Me.numReciclaje.DecimalPlaces = 3
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
        If mProduccion IsNot Nothing Then
            mProduccion.MarkAsDeleted()
            BCProduccion.MantenimientoProduccion(mProduccion)
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


    Private Sub chkFinalizada_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFinalizada.CheckedChanged
        If mProduccion IsNot Nothing Then
            If chkFinalizada.Checked Then
                'And mProduccion.ChangeTracker.State = ObjectState.Modified And (mProduccion.PRO_FECHA_FINALIZADA Is Nothing Or mProduccion.PRO_FECHA_FINALIZADA = "01/01/1900") Then
                Try
                    Dim ds As New DataSet
                    Dim query = BCProduccion.ConteoYCargaXProduccion(mProduccion.PRO_ID)
                    Dim rea As New StringReader(query)
                    ds.ReadXml(rea)
                    txtConteo.Text = CInt(ds.Tables(0).Rows(0).Item(0))
                    txtCarga.Text = CInt(ds.Tables(0).Rows(0).Item(1))
                    txtDiferencia.Text = CInt(ds.Tables(0).Rows(0).Item(0)) - CInt(ds.Tables(0).Rows(0).Item(1))
                    txtPorcentaje.Text = ((CInt(ds.Tables(0).Rows(0).Item(0)) - CInt(ds.Tables(0).Rows(0).Item(1))) * 100) / CInt(ds.Tables(0).Rows(0).Item(0))
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                txtConteo.Text = String.Empty
                txtCarga.Text = String.Empty
                txtDiferencia.Text = String.Empty
                txtPorcentaje.Text = String.Empty
            End If
        End If
    End Sub

    Private Sub txtLadrillo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLadrillo.KeyDown
        If e.KeyCode = Keys.Enter Then txtLadrillo_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtPlanta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlanta.KeyDown
        If e.KeyCode = Keys.Enter Then txtPlanta_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtExtrusora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtExtrusora.KeyDown
        If e.KeyCode = Keys.Enter Then txtExtrusora_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtCortadora_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCortadora.KeyDown
        If e.KeyCode = Keys.Enter Then txtCortadora_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtIng1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIng1.KeyDown, txtIng2.KeyDown, txtOpe1.KeyDown, txtOpe2.KeyDown
        If e.KeyCode = Keys.Enter Then txtIng1_DoubleClick(sender, Nothing)
    End Sub

    Private Sub numCorte_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCorte.Enter, numHoraFinal.Enter, numHoraInicio.Enter, numReciclaje.Enter, numTabla.Enter, numVagon.Enter
        sender.Select(0, sender.Text.ToString.Length)
    End Sub

    Private Sub numHoraInicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles numHoraInicio.LostFocus, numHoraFinal.LostFocus
        Try
            If sender.value > 0 Then
                If Not IsDate(Replace(sender.Value, ".", ":")) Then
                    MessageBox.Show("La hora es incorrecta.")
                    sender.Value = 0
                    sender.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
