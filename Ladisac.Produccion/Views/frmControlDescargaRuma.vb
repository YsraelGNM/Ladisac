Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmControlDescargaRuma
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCControlDescargaRuma As Ladisac.BL.IBCControlDescargaRuma
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCControlDescarga As Ladisac.BL.IBCControlDescarga

    Protected mDRU As ControlDescargaRuma
    Protected mDES As ControlDescarga

    'ingreso de codigo
    Private Sub frmControlDescargaRuma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.

        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtCodigo.TabIndex = 0
        dtpFecha.TabIndex = 1
        txtControlDescarga.TabIndex = 2
        numHoroInicial.TabIndex = 3
        numHoroFinal.TabIndex = 4

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mDRU = Nothing
        txtCodigo.Text = String.Empty
        txtControlDescarga.Text = String.Empty
        txtControlDescarga.Tag = Nothing
        txtSerie.Text = String.Empty
        txtNumero.Text = String.Empty
        dtpFecha.Value = Today
        numHoroInicial.Value = 0
        numHoroFinal.Value = 0
        dgvDetalle.Rows.Clear()
        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtControlDescarga_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtControlDescarga.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ListaDesHorProcesar"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtControlDescarga.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'DES_Id
            txtControlDescarga.Text = frm.dgvLista.CurrentRow.Cells(0).Value 'DES_Id
            numHoroInicial.Value = frm.dgvLista.CurrentRow.Cells(4).Value 'hi
            numHoroFinal.Value = frm.dgvLista.CurrentRow.Cells(5).Value 'hf
            CargarControlDescarga(txtControlDescarga.Tag)
            dtpFecha.Value = mDES.DES_FECHA
            LlenarGrid()
        End If
        frm.Dispose()
    End Sub

    Sub CargarControlDescarga(ByVal DES_Id As Integer)
        mDES = BCControlDescarga.ControlDescargaGetById(DES_Id)
    End Sub

    Sub LlenarGrid()
        dgvDetalle.Rows.Clear()
        For Each mItem In mDES.CaCoDe_Detalle
            If Not mItem.CCD_TIPO = "Recocido  " Then
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CAR_ID").Value = mItem.CAR_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CAR_ID").Tag = mItem.ControlCarga
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("LMA_ID").Value = mItem.LMA_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRO_ID").Value = mItem.ControlCarga.PRO_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("LADRILLO").Value = mItem.ControlCarga.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_TIPO").Value = mItem.CCD_TIPO
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CARGADO").Value = mItem.CCD_CANTIDAD
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_CANT_NETA").Value = mItem.CCD_CANTIDAD
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_MALOS").Value = 0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_ROTOS").Value = 0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_RAJADOS").Value = 0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_RECOCHADOS").Value = 0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_DOBLADOS").Value = 0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_BLANCOS").Value = 0
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_OBSERVACIONES").Value = ""
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PUERTA").Value = mItem.CCD_PUERTA
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("MALECON").Value = mItem.CCD_NRO_MALE
            End If
        Next
    End Sub

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        dgvDetalle.Rows(e.RowIndex).Cells("DRD_MALOS").Value = Integer.Parse(dgvDetalle.Rows(e.RowIndex).Cells("DRD_ROTOS").Value) + _
                                                                Integer.Parse(dgvDetalle.Rows(e.RowIndex).Cells("DRD_RAJADOS").Value) + _
                                                                Integer.Parse(dgvDetalle.Rows(e.RowIndex).Cells("DRD_RECOCHADOS").Value) + _
                                                                Integer.Parse(dgvDetalle.Rows(e.RowIndex).Cells("DRD_DOBLADOS").Value) + _
                                                                Integer.Parse(dgvDetalle.Rows(e.RowIndex).Cells("DRD_BLANCOS").Value)
        dgvDetalle.Rows(e.RowIndex).Cells("DRD_CANT_NETA").Value = Integer.Parse(dgvDetalle.Rows(e.RowIndex).Cells("CARGADO").Value) - _
                                                                Integer.Parse(dgvDetalle.Rows(e.RowIndex).Cells("DRD_MALOS").Value)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------

        If mDRU IsNot Nothing Then
            dgvDetalle.EndEdit()
            mDRU.DES_ID = CInt(txtControlDescarga.Tag)
            mDRU.DRU_FECHA = dtpFecha.Value
            mDRU.DRU_HI = numHoroInicial.Value
            mDRU.DRU_HF = numHoroFinal.Value
            mDRU.DRU_SERIE = txtSerie.Text.Trim.PadLeft(4, "0")
            mDRU.DRU_NRO = txtNumero.Text.Trim.PadLeft(10, "0")
            mDRU.DRU_ESTADO = True
            mDRU.DRU_FEC_GRAB = Now
            mDRU.USU_ID = SessionServer.UserId
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("DRD_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("DRD_ID").Tag, ControlDescargaRumaDetalle)
                        .CAR_ID = Int(mDetalle.Cells("CAR_ID").Value)
                        '.LMA_ID = Int(mDetalle.Cells("LMA_ID").Value)
                        .DRD_TIPO = mDetalle.Cells("DRD_TIPO").Value
                        .DRD_CANT_NETA = Int(mDetalle.Cells("DRD_CANT_NETA").Value)
                        .DRD_MALOS = CInt(mDetalle.Cells("DRD_MALOS").Value)
                        .DRD_ROTOS = CInt(mDetalle.Cells("DRD_ROTOS").Value)
                        .DRD_RAJADOS = CInt(mDetalle.Cells("DRD_RAJADOS").Value)
                        .DRD_RECOCHADOS = CInt(mDetalle.Cells("DRD_RECOCHADOS").Value)
                        .DRD_DOBLADOS = CInt(mDetalle.Cells("DRD_DOBLADOS").Value)
                        .DRD_BLANCOS = CInt(mDetalle.Cells("DRD_BLANCOS").Value)
                        .DRD_OBSERVACIONES = mDetalle.Cells("DRD_OBSERVACIONES").Value
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("CARGADO").Value Is Nothing Then
                    Dim nDRD As New ControlDescargaRumaDetalle
                    With nDRD
                        .CAR_ID = Int(mDetalle.Cells("CAR_ID").Value)
                        .ControlCarga = mDetalle.Cells("CAR_ID").Tag
                        .LMA_ID = Int(mDetalle.Cells("LMA_ID").Value)
                        .DRD_TIPO = mDetalle.Cells("DRD_TIPO").Value
                        .DRD_CANT_NETA = Int(mDetalle.Cells("DRD_CANT_NETA").Value)
                        .DRD_MALOS = CInt(mDetalle.Cells("DRD_MALOS").Value)
                        .DRD_ROTOS = CInt(mDetalle.Cells("DRD_ROTOS").Value)
                        .DRD_RAJADOS = CInt(mDetalle.Cells("DRD_RAJADOS").Value)
                        .DRD_RECOCHADOS = CInt(mDetalle.Cells("DRD_RECOCHADOS").Value)
                        .DRD_DOBLADOS = CInt(mDetalle.Cells("DRD_DOBLADOS").Value)
                        .DRD_BLANCOS = CInt(mDetalle.Cells("DRD_BLANCOS").Value)
                        .DRD_OBSERVACIONES = mDetalle.Cells("DRD_OBSERVACIONES").Value
                        .MarkAsAdded()
                    End With
                    mDRU.ControlDescargaRumaDetalle.Add(nDRD)
                End If
            Next

            BCControlDescargaRuma.MantenimientoControlDescargaRuma(mDRU)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)

    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mDRU = New ControlDescargaRuma
        mDRU.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtControlDescarga.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ControlDescargaRuma"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarControlDescargaRuma(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarControlDescargaRuma(ByVal DRU_Id As Integer)
        mDRU = BCControlDescargaRuma.ControlDescargaRumaGetById(DRU_Id)
        mDRU.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtCodigo.Text = mDRU.DRU_ID
        dtpFecha.Value = mDRU.DRU_FECHA
        txtControlDescarga.Text = mDRU.DES_ID
        txtControlDescarga.Tag = mDRU.DES_ID
        numHoroInicial.Value = mDRU.DRU_HI
        numHoroFinal.Value = mDRU.DRU_HF
        txtSerie.Text = mDRU.DRU_SERIE
        txtNumero.Text = mDRU.DRU_NRO

        For Each mItem In mDRU.ControlDescargaRumaDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_ID").Value = mItem.DRD_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CAR_ID").Value = mItem.CAR_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("LMA_ID").Value = mItem.LMA_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("PRO_ID").Value = mItem.ControlCarga.PRO_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("LADRILLO").Value = mItem.ControlCarga.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_TIPO").Value = mItem.DRD_TIPO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("CARGADO").Value = mItem.DRD_CANT_NETA + mItem.DRD_MALOS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_CANT_NETA").Value = mItem.DRD_CANT_NETA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_MALOS").Value = mItem.DRD_MALOS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_ROTOS").Value = mItem.DRD_ROTOS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_RAJADOS").Value = mItem.DRD_RAJADOS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_RECOCHADOS").Value = mItem.DRD_RECOCHADOS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_DOBLADOS").Value = mItem.DRD_DOBLADOS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_BLANCOS").Value = mItem.DRD_BLANCOS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("DRD_OBSERVACIONES").Value = mItem.DRD_OBSERVACIONES
        Next
    End Sub

    '===================================================================================================================
    '----procedimiento de validaciones
    'tecla enter de paso rapido entre cajas de texto.

    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()

        If Len(dtpFecha.Text.Trim) = 0 Then Error_validacion.SetError(dtpFecha, "Ingrese la Fecha") : dtpFecha.Focus() : flag = False
        If Len(txtControlDescarga.Text.Trim) = 0 Then Error_validacion.SetError(txtControlDescarga, "Ingrese el Control Descarga") : txtControlDescarga.Focus() : flag = False
        If Len(numHoroInicial.Text.Trim) = 0 Then Error_validacion.SetError(numHoroInicial, "Ingrese el Horo Inicial") : numHoroInicial.Focus() : flag = False
        If Len(numHoroFinal.Text.Trim) = 0 Then Error_validacion.SetError(numHoroFinal, "Ingrese el Horo Final") : numHoroFinal.Focus() : flag = False
        If Len(txtSerie.Text.Trim) = 0 Then Error_validacion.SetError(txtSerie, "Ingrese la serie de Control Descarga") : txtSerie.Focus() : flag = False
        If Len(txtNumero.Text.Trim) = 0 Then Error_validacion.SetError(txtNumero, "Ingrese el numero de Control Descarga") : txtNumero.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        ' Me.txtControlDescarga.MaxLength = 160 'es entero
        Me.numHoroInicial.Maximum = 99 : Me.numHoroInicial.DecimalPlaces = 2
        Me.numHoroFinal.Maximum = 99 : Me.numHoroFinal.DecimalPlaces = 2
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
    Private Sub txtControlDescarga_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtControlDescarga.KeyDown
        If e.KeyCode = Keys.Enter Then txtControlDescarga_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub numHoroFinal_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles numHoroFinal.Enter, numHoroInicial.Enter
        sender.Select(0, sender.Text.ToString.Length)
    End Sub
End Class
