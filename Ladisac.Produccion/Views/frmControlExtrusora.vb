Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmControlExtrusora
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCControlExtrusora As Ladisac.BL.IBCControlExtrusora
    <Dependency()> _
    Public Property BCHerramientas As Ladisac.BL.IBCHerramientas

    Protected mCEX As ControlExtrusora

    'ingreso de codigo
    Private Sub frmControlExtrusora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LimpiarControles()
        '==========================================================================
        'se llama al procedimiento de paso rapido entre cajas de texto.
        'se declara los objetos.---------    1->tipo textbox     2->combo
        
        Me.txtControlParada.Focus()
        Call validar_longitud()
        Call validacion_desactivacion(False, 1)

        txtControlParada.TabIndex = 0
        txtHoraInicio.TabIndex = 1
        txtHoraFinal.TabIndex = 2
        numHoroInicial.TabIndex = 3
        numHoroFinal.TabIndex = 4
        numHoroDigital.TabIndex = 5
        numMedidaCorte.TabIndex = 6

    End Sub

    'ingreso de codigo
    Sub LimpiarControles()
        mCEX = Nothing
        txtControlParada.Text = String.Empty
        txtControlParada.Tag = Nothing
        numHoroInicial.Value = 0
        numHoroFinal.Value = 0
        numHoroDigital.Value = 0
        numMedidaCorte.Value = 0
        txtHoraInicio.Text = String.Empty
        txtHoraFinal.Text = String.Empty
        dgvDetalle.Rows.Clear()


        '--------------------------
        Error_validacion.Clear()
    End Sub

    Private Sub txtControlParada_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtControlParada.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ControlParada"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtControlParada.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'CPA_Id
            txtControlParada.Text = frm.dgvLista.CurrentRow.Cells(0).Value & " " & frm.dgvLista.CurrentRow.Cells(1).Value & " " & frm.dgvLista.CurrentRow.Cells(3).Value 'Nombres
            txtHoraInicio.Text = frm.dgvLista.CurrentRow.Cells("CPA_HORA_INICIO").Value 'HI
            txtHoraFinal.Text = frm.dgvLista.CurrentRow.Cells("CPA_HORA_FINAL").Value 'HF
        End If
        frm.Dispose()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManGuardar()
        'cod ingresado q llama ala funcion para validar
        If Not validar_controles() Then Exit Sub
        '----------------------------------------------------




        If mCEX IsNot Nothing Then
            dgvDetalle.EndEdit()
            mCEX.CPA_ID = CInt(txtControlParada.Tag)
            mCEX.CEX_HOROMETRO_INICIAL = numHoroInicial.Value
            mCEX.CEX_HOROMETRO_FINAL = numHoroFinal.Value
            mCEX.CEX_HOROMETRO_DIGITAL = numHoroDigital.Value
            mCEX.CEX_MEDIDA_CORTE = numMedidaCorte.Value
            mCEX.CEX_ESTADO = True
            mCEX.CEX_FEC_GRAB = Now
            mCEX.USU_ID = SessionServer.UserId
            Dim mAnt As Double = 0
            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                If Not mDetalle.Cells("DEX_ID").Value Is Nothing Then
                    With CType(mDetalle.Cells("DEX_ID").Tag, ControlExtrusoraDetalle)
                        .DEX_HORA = CDbl(mDetalle.Cells("DEX_HORA").Value)
                        .DEX_VACIO = CDbl(mDetalle.Cells("DEX_VACIO").Value)
                        .DEX_AMPERAJE = CDbl(mDetalle.Cells("DEX_AMPERAJE").Value)
                        .DEX_CORTES_MINUTO = CDbl(mDetalle.Cells("DEX_CORTES_MINUTO").Value)
                        .DEX_CANTIDAD_CORTE_MAQUINA = CDbl(mDetalle.Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value)
                        .DEX_TOTAL_CORTES_HORA = CDbl(mDetalle.Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value) - mAnt
                        mAnt = .DEX_CANTIDAD_CORTE_MAQUINA
                        .MarkAsModified()
                    End With
                ElseIf Not mDetalle.Cells("DEX_HORA").Value Is Nothing Then
                    Dim nDEX As New ControlExtrusoraDetalle
                    With nDEX
                        .DEX_HORA = CDbl(mDetalle.Cells("DEX_HORA").Value)
                        .DEX_VACIO = CDbl(mDetalle.Cells("DEX_VACIO").Value)
                        .DEX_AMPERAJE = CDbl(mDetalle.Cells("DEX_AMPERAJE").Value)
                        .DEX_CORTES_MINUTO = CDbl(mDetalle.Cells("DEX_CORTES_MINUTO").Value)
                        .DEX_CANTIDAD_CORTE_MAQUINA = CDbl(mDetalle.Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value)
                        .DEX_TOTAL_CORTES_HORA = CDbl(mDetalle.Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value) - mAnt
                        mAnt = .DEX_CANTIDAD_CORTE_MAQUINA
                        .MarkAsAdded()
                    End With
                    mCEX.ControlExtrusoraDetalle.Add(nDEX)
                End If
            Next

            BCControlExtrusora.MantenimientoControlExtrusora(mCEX)
            LimpiarControles()
        End If


        '------------------------------------------
        Call validacion_desactivacion(False, 3)
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManNuevo()
        LimpiarControles()
        mCEX = New ControlExtrusora
        mCEX.MarkAsAdded()


        '---------------------------------------
        Call validacion_desactivacion(True, 2)
        txtControlParada.Focus()
    End Sub

    'ingreso de codigo
    Public Overrides Sub OnManBuscar()
        LimpiarControles()
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
        frm.Tabla = "ControlExtrusora"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim key As Integer = frm.dgvLista.CurrentRow.Cells(0).Value
            CargarControlExtrusora(key)
            LlenarControles()
            Recalcular()
            '---------------------------------
            Call validacion_desactivacion(True, 5)
        End If
        frm.Dispose()
    End Sub

    Sub CargarControlExtrusora(ByVal CEX_Id As Integer)
        mCEX = BCControlExtrusora.ControlExtrusoraGetById(CEX_Id)
        mCEX.MarkAsModified()
    End Sub

    Sub LlenarControles()
        txtControlParada.Text = mCEX.ControlParada.CPA_ID & " " & mCEX.ControlParada.Produccion.Ladrillo.Articulos.ART_DESCRIPCION
        txtControlParada.Tag = mCEX.CPA_ID
        numHoroInicial.Value = mCEX.CEX_HOROMETRO_INICIAL
        numHoroFinal.Value = mCEX.CEX_HOROMETRO_FINAL
        numHoroDigital.Value = mCEX.CEX_HOROMETRO_DIGITAL
        numMedidaCorte.Value = mCEX.CEX_MEDIDA_CORTE
        txtHoraInicio.Text = mCEX.ControlParada.CPA_HORA_INICIO
        txtHoraFinal.Text = mCEX.ControlParada.CPA_HORA_FINAL

        For Each mItem In mCEX.ControlExtrusoraDetalle
            Dim nRow As New DataGridViewRow
            dgvDetalle.Rows.Add(nRow)
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DEX_ID").Value = mItem.DEX_ID
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DEX_ID").Tag = mItem
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DEX_HORA").Value = mItem.DEX_HORA
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DEX_VACIO").Value = mItem.DEX_VACIO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DEX_AMPERAJE").Value = mItem.DEX_AMPERAJE
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DEX_CORTES_MINUTO").Value = mItem.DEX_CORTES_MINUTO
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 2).Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value = mItem.DEX_CANTIDAD_CORTE_MAQUINA
        Next
    End Sub
    '===================================================================================================================
    '----procedimiento de validaciones
    'validamos los campos a llenar
    Function validar_controles()
        'aqui se ingresara los objetos del formulario a validar
        Dim flag As Boolean = True

        Error_validacion.Clear()
        If Len(txtControlParada.Text.Trim) = 0 Then Error_validacion.SetError(txtControlParada, "Ingrese el Control Parada") : txtControlParada.Focus() : flag = False
        If Len(txtHoraInicio.Text.Trim) = 0 Then Error_validacion.SetError(txtHoraInicio, "Ingrese la Hora de Inicio") : txtHoraInicio.Focus() : flag = False
        If Len(txtHoraFinal.Text.Trim) = 0 Then Error_validacion.SetError(txtHoraFinal, "Ingrese la Hora Final") : txtHoraFinal.Focus() : flag = False
        If Len(numHoroInicial.Text.Trim) = 0 Then Error_validacion.SetError(numHoroInicial, "Ingrese el Horo Inicial") : numHoroInicial.Focus() : flag = False
        If Len(numHoroFinal.Text.Trim) = 0 Then Error_validacion.SetError(numHoroFinal, "Ingrese el Horo Final") : numHoroFinal.Focus() : flag = False
        If Len(numHoroDigital.Text.Trim) = 0 Then Error_validacion.SetError(numHoroDigital, "Ingrese el Horo Digital") : numHoroDigital.Focus() : flag = False
        If Len(numMedidaCorte.Text.Trim) = 0 Then Error_validacion.SetError(numMedidaCorte, "Ingrese la Media de Corte") : numMedidaCorte.Focus() : flag = False

        If flag = False Then
            MessageBox.Show("Los Campos Seleccionados son OBLIGATORIOS.", "Sistema Ladisac", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return flag

    End Function

    'validamos la longitud de los campos.
    Private Sub validar_longitud()
        'Me.txtControlParada.MaxLength = 100
        Me.txtHoraInicio.MaxLength = 5
        Me.txtHoraFinal.MaxLength = 5
        Me.numHoroInicial.Maximum = 9999999999999999 : Me.numHoroInicial.DecimalPlaces = 2
        Me.numHoroFinal.Maximum = 9999999999999999 : Me.numHoroFinal.DecimalPlaces = 2
        Me.numHoroDigital.Maximum = 99999 : Me.numHoroDigital.DecimalPlaces = 1
        Me.numMedidaCorte.Maximum = 9999999999999999 : Me.numMedidaCorte.DecimalPlaces = 2

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
        If mCEX IsNot Nothing Then
            For Each mItem In mCEX.ControlExtrusoraDetalle
                mItem.MarkAsDeleted()
            Next
            mCEX.MarkAsDeleted()
            BCControlExtrusora.MantenimientoControlExtrusora(mCEX)
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

    Private Sub dgvDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEndEdit
        Select Case dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name
            Case "DEX_HORA"
                Try
                    If Not IsDate(Replace(dgvDetalle.CurrentCell.Value, ".", ":")) Then
                        dgvDetalle.CurrentCell.Value = 0
                    End If
                Catch ex As Exception
                    Exit Sub
                End Try
                If CType(sender, DataGridView).CurrentRow.Index > 0 Then
                    CType(sender, DataGridView).CurrentRow.Cells("DEX_VACIO").Value = CType(sender, DataGridView).Rows(e.RowIndex - 1).Cells("DEX_VACIO").Value
                    CType(sender, DataGridView).CurrentRow.Cells("DEX_AMPERAJE").Value = CType(sender, DataGridView).Rows(e.RowIndex - 1).Cells("DEX_AMPERAJE").Value
                    CType(sender, DataGridView).CurrentRow.Cells("DEX_CORTES_MINUTO").Value = CType(sender, DataGridView).Rows(e.RowIndex - 1).Cells("DEX_CORTES_MINUTO").Value
                End If
                'Case "DEX_CANTIDAD_CORTE_MAQUINA"
                '    If CType(sender, DataGridView).CurrentRow.Index > 0 Then
                '        CType(sender, DataGridView).Rows(e.RowIndex - 1).Cells("DEX_TOTAL_CORTES_HORA").Value = CType(sender, DataGridView).Rows(e.RowIndex).Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value - CType(sender, DataGridView).Rows(e.RowIndex - 1).Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value
                '        CType(sender, DataGridView).Rows(e.RowIndex - 1).Cells("CorteMinuto").Value = CType(sender, DataGridView).Rows(e.RowIndex - 1).Cells("DEX_TOTAL_CORTES_HORA").Value / 60
                '    End If

        End Select
        Recalcular()
    End Sub

    Sub Recalcular()
        For Each mF As DataGridViewRow In dgvDetalle.Rows
            mF.Cells("DEX_TOTAL_CORTES_HORA").Value = Nothing
            mF.Cells("CorteMinuto").Value = Nothing
        Next

        For Each mF As DataGridViewRow In dgvDetalle.Rows
            If mF.Index > 0 Then
                If mF.Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value > 0 Then
                    dgvDetalle.Rows(mF.Index - 1).Cells("DEX_TOTAL_CORTES_HORA").Value = mF.Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value - dgvDetalle.Rows(mF.Index - 1).Cells("DEX_CANTIDAD_CORTE_MAQUINA").Value
                    dgvDetalle.Rows(mF.Index - 1).Cells("CorteMinuto").Value = dgvDetalle.Rows(mF.Index - 1).Cells("DEX_TOTAL_CORTES_HORA").Value / 60
                Else
                    dgvDetalle.Rows(mF.Index - 1).Cells("DEX_TOTAL_CORTES_HORA").Value = Nothing
                    dgvDetalle.Rows(mF.Index - 1).Cells("CorteMinuto").Value = Nothing
                End If
            End If
        Next
    End Sub

    Private Sub txtControlParada_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtControlParada.KeyDown
        If e.KeyCode = Keys.Enter Then txtControlParada_DoubleClick(Nothing, Nothing)
    End Sub

    Public Overrides Sub OnManAgregarFilaGrid()
        Dim nRow As New DataGridViewRow
        dgvDetalle.Rows.Add(nRow)
    End Sub

    Private Sub numHoroDigital_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles numHoroDigital.Enter, numHoroFinal.Enter, numHoroInicial.Enter, numMedidaCorte.Enter
        sender.Select(0, sender.Text.ToString.Length)
    End Sub

    Function ValidarHorometro(ByVal CPA_ID As Integer, ByVal HoroDigital As Decimal) As Boolean
        Dim cadena As String = BCControlExtrusora.ValidarHoroDigital(CPA_ID, HoroDigital)
        If cadena.ToString.Length = 0 Then
            Return True
        Else
            MessageBox.Show(cadena)
            Return False
        End If
    End Function

    Private Sub numHoroDigital_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles numHoroDigital.LostFocus
        If txtControlParada.Tag IsNot Nothing Then
            If Not ValidarHorometro(txtControlParada.Tag, numHoroDigital.Value) Then
                numHoroDigital.Value = 0
                numHoroDigital.Focus()
            End If
        End If
    End Sub

    Private Sub dgvDetalle_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDetalle.UserDeletingRow
        If Not e.Row.Cells("DEX_ID").Tag Is Nothing Then
            CType(e.Row.Cells("DEX_ID").Tag, ControlExtrusoraDetalle).MarkAsDeleted()
        End If
    End Sub
End Class

