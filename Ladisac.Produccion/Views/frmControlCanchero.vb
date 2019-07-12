Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmControlCanchero
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCControlCanchero As Ladisac.BL.IBCControlCanchero
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    <Dependency()> _
    Public Property BCControlParada As Ladisac.BL.IBCControlParada

    Protected mCCA As ControlCanchero
    Dim mProduccion As Produccion
    Dim mListCPA As New List(Of ControlParada)

    'ingreso de codigo
    Private Sub frmControlCanchero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()

        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.---------    1->tipo textbox     2->combo
       
        Me.txtProduccion.Focus()
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtProduccion.TabIndex = 1
        txtOperador.TabIndex = 2
        numCantTabla.TabIndex = 3
        numTotalLadrillos.TabIndex = 4
        dtpFecha.TabIndex = 5
        dgvDetalle.TabIndex = 6

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mCCA = Nothing
        mProduccion = Nothing
        txtProduccion.Text = String.Empty
        txtProduccion.Tag = Nothing
        txtOperador.Text = String.Empty
        txtOperador.Tag = Nothing
        dtpFecha.Value = Today
        numTotalLadrillos.Value = 0
        numCantTabla.Value = 0
        dgvDetalle.Rows.Clear()

        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtProduccion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduccion.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "Produccion"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtProduccion.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_Id
            txtProduccion.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells("ART_DESCRIPCION").Value 'Nombres
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value 'PRO_ID
            CargarProduccion(key)
            CargarListaControlParada(key)
            txtOperador.Tag = mListCPA(0).PER_ID_OPERADOR
            txtOperador.Text = mListCPA(0).Personas.PER_NOMBRES & " " & mListCPA(0).Personas.PER_APE_PAT
            numCantTabla.Value = mProduccion.PRO_CANT_TABLA
            dtpFecha.Value = mProduccion.PRO_FECHA
        End If
        frm.Dispose()
    End Sub

    Sub CargarProduccion(ByVal PRO_Id As Integer)
        mProduccion = BCProduccion.ProduccionGetById(PRO_Id)
    End Sub

    Sub CargarListaControlParada(ByVal PRO_Id As Integer)
        mListCPA = BCControlParada.GetByPro_Id(PRO_Id)
    End Sub

    Private Sub dgvDetalle_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellDoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        Select Case e.ColumnIndex
            Case 1
                frm.Tabla = "Cancha"
                If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'CAN_Descripcion
                    dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'CAN_Id
                End If
        End Select
        frm.Dispose()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------



        If mCCA IsNot Nothing Then
            dgvDetalle.EndEdit()
            mCCA.CCA_FECHA = dtpFecha.Value
            mCCA.PRO_ID = CInt(txtProduccion.Tag)
            mCCA.PER_ID_OPERADOR = txtOperador.Tag
            mCCA.CCA_CANTIDAD_TABLA = numCantTabla.Value
            mCCA.CCA_TOTAL = numTotalLadrillos.Value
            mCCA.CCA_ESTADO = True
            mCCA.CCA_FEC_GRAB = Now
            mCCA.USU_ID = SessionServer.UserId
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("DCA_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("DCA_ID").Tag, ControlCancheroDetalle)
                        .CAN_ID = CInt(mDetalle.Cells("CAN_ID").Tag)
                        .DCA_GOLPEADAS = CDbl(mDetalle.Cells("DCA_GOLPEADAS").Value)
                        .DCA_RAJADAS = CDbl(mDetalle.Cells("DCA_RAJADAS").Value)
                        .DCA_AGUADAS = CDbl(mDetalle.Cells("DCA_AGUADAS").Value)
                        .DCA_CORTE_MAL = CDbl(mDetalle.Cells("DCA_CORTE_MAL").Value)
                        .DCA_GOLPE_VEHICULO = CDbl(mDetalle.Cells("DCA_GOLPE_VEHICULO").Value)
                        .DCA_OBSERVACION = mDetalle.Cells("DCA_OBSERVACION").Value
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("CAN_ID").Value Is Nothing Then
                    Dim nDCC As New ControlCancheroDetalle
                    With nDCC
                        .CAN_ID = CInt(mDetalle.Cells("CAN_ID").Tag)
                        .DCA_GOLPEADAS = CDbl(mDetalle.Cells("DCA_GOLPEADAS").Value)
                        .DCA_RAJADAS = CDbl(mDetalle.Cells("DCA_RAJADAS").Value)
                        .DCA_AGUADAS = CDbl(mDetalle.Cells("DCA_AGUADAS").Value)
                        .DCA_CORTE_MAL = CDbl(mDetalle.Cells("DCA_CORTE_MAL").Value)
                        .DCA_GOLPE_VEHICULO = CDbl(mDetalle.Cells("DCA_GOLPE_VEHICULO").Value)
                        .DCA_OBSERVACION = mDetalle.Cells("DCA_OBSERVACION").Value
                        .MarkAsAdded()
                    End With
                    mCCA.ControlCancheroDetalle.Add(nDCC)
                End If
            Next

            BCControlCanchero.MantenimientoControlCanchero(mCCA)
            If mProduccion IsNot Nothing Then
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmControlConteo)()
                frm.mProduccion = mProduccion
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
        mCCA = New ControlCanchero
        mCCA.MarkAsAdded()


        '---------------------------------------

        Call validacion_desactivacion(True, 2)
        txtProduccion.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ControlCanchero"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarControlCanchero(key)
            LlenarControles()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarControlCanchero(ByVal CCA_Id As Integer)
        mCCA = BCControlCanchero.ControlCancheroGetById(CCA_Id)
        mCCA.MarkAsModified()
    End Sub

    Sub LlenarControles()
        dtpFecha.Value = mCCA.CCA_FECHA
        txtProduccion.Text = mCCA.Produccion.PRO_ID & " " & mCCA.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
        txtProduccion.Tag = mCCA.Produccion.PRO_ID
        txtOperador.Text = mCCA.Personas.PER_NOMBRES & " " & mCCA.Personas.PER_APE_PAT
        txtOperador.Tag = mCCA.PER_ID_OPERADOR
        numCantTabla.Value = mCCA.CCA_CANTIDAD_TABLA
        numTotalLadrillos.Value = mCCA.CCA_TOTAL

        For Each mItem In mCCA.ControlCancheroDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCA_ID").Value = mItem.DCA_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCA_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAN_ID").Value = mItem.Cancha.CAN_DESCRIPCION
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("CAN_ID").Tag = mItem.CAN_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCA_GOLPEADAS").Value = mItem.DCA_GOLPEADAS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCA_RAJADAS").Value = mItem.DCA_RAJADAS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCA_AGUADAS").Value = mItem.DCA_AGUADAS
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCA_CORTE_MAL").Value = mItem.DCA_CORTE_MAL
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCA_GOLPE_VEHICULO").Value = mItem.DCA_GOLPE_VEHICULO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DCA_OBSERVACION").Value = mItem.DCA_OBSERVACION
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
        If Len(txtProduccion.Text.Trim) = 0 Then Error_validacion.SetError(txtProduccion, "Ingrese la Producción") : txtProduccion.Focus() : flag = False
        If Len(numCantTabla.Text.Trim) = 0 Then Error_validacion.SetError(numCantTabla, "Ingrese la Cantidad X Tabla") : numCantTabla.Focus() : flag = False
        If Len(numTotalLadrillos.Text.Trim) = 0 Then Error_validacion.SetError(numTotalLadrillos, "Ingrese el Numero Total de Ladrillos") : numTotalLadrillos.Focus() : flag = False

        
        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        Me.txtProduccion.MaxLength = 160
        Me.numCantTabla.Maximum = 9999 : Me.numCantTabla.DecimalPlaces = 0
        Me.numTotalLadrillos.Maximum = 9999 : Me.numTotalLadrillos.DecimalPlaces = 0
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
        If mCCA IsNot Nothing Then
            For Each mItem In mCCA.ControlCancheroDetalle
                mItem.MarkAsDeleted()
            Next
            mCCA.MarkAsDeleted()
            BCControlCanchero.MantenimientoControlCanchero(mCCA)
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

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Dim mResult = (From mRow As DataGridViewRow In dgvDetalle.Rows Select mRow).Sum(Function(mrow) CInt(mrow.Cells("DCA_GOLPEADAS").Value) + CInt(mrow.Cells("DCA_RAJADAS").Value) + CInt(mrow.Cells("DCA_AGUADAS").Value) + CInt(mrow.Cells("DCA_CORTE_MAL").Value) + +CInt(mrow.Cells("DCA_GOLPE_VEHICULO").Value))
        numTotalLadrillos.Value = mResult * numCantTabla.Value
    End Sub

    Private Sub txtProduccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduccion.KeyDown
        If e.KeyCode = Keys.Enter Then txtProduccion_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub txtOperador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOperador.KeyDown
        If e.KeyCode = Keys.Enter Then txtOperador_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub dgvDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalle.KeyDown
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        If dgvDetalle.CurrentCell.ColumnIndex = 1 And e.KeyCode = Keys.Enter Then
            frm.Tabla = "Cancha"
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                dgvDetalle.CurrentCell.Value = frm.dgvLista.CurrentRow.Cells(1).Value  'CAN_Descripcion
                dgvDetalle.CurrentCell.Tag = frm.dgvLista.CurrentRow.Cells(0).Value  'CAN_Id
            End If
        End If
        frm.Dispose()
    End Sub

    Private Sub numCantTabla_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCantTabla.Enter, numTotalLadrillos.Enter
        sender.Select(0, sender.Text.ToString.Length)
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("DCA_ID").Value Is Nothing Then
            CType(e.Row.Cells("DCA_ID").Tag, ControlCancheroDetalle).MarkAsDeleted()
        End If
    End Sub
End Class

