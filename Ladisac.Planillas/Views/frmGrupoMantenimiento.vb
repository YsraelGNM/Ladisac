
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling


Namespace Ladisac.Planillas.Views
    Public Class frmGrupoMantenimiento

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCGrupoMantenimiento As BL.IBCGrupoMantenimiento

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil

        Protected oGrupoMantenimiento As New BE.GrupoMantenimiento

        Function validar() As Boolean
            Dim result As Boolean = True
            If (txtPeriodo.Text = "") Then
                ErrorProvider1.SetError(txtPeriodo, "Periodo")
                result = False
            Else
                ErrorProvider1.SetError(txtPeriodo, Nothing)
            End If
            If (txtResponsable.Text = "") Then
                ErrorProvider1.SetError(txtResponsable, "Responsable")
                result = False
            Else
                ErrorProvider1.SetError(txtResponsable, Nothing)
            End If
            If (txtObservaciones.Text.Trim = "") Then
                ErrorProvider1.SetError(txtObservaciones, "Observaciones")
                result = False
            Else
                ErrorProvider1.SetError(txtObservaciones, Nothing)
            End If

            Return result
        End Function
        Private Sub limpiar()
            txtPeriodo.Text = ""
            txtObservaciones.Text = ""
            txtNumero.Text = ""
            txtResponsable.Text = ""
            txtResponsable.Tag = ""
            dgvDetalle.Rows.Clear()

        End Sub

        Private Sub cargar(ByVal periodo As String, ByVal numero As String)

            limpiar()
            oGrupoMantenimiento = BCGrupoMantenimiento.GrupoMantenimientoSeek(numero, periodo)
            oGrupoMantenimiento.MarkAsModified()
            txtPeriodo.Text = oGrupoMantenimiento.prd_Periodo_id
            txtNumero.Text = oGrupoMantenimiento.grm_Numero
            dateFecha.Value = oGrupoMantenimiento.grm_Fecha

            txtResponsable.Tag = oGrupoMantenimiento.per_IDResponsable
            txtObservaciones.Text = oGrupoMantenimiento.grm_observaciones

            txtResponsable.Text = IIf(IsNothing(oGrupoMantenimiento.Personas.PER_APE_PAT), "", oGrupoMantenimiento.Personas.PER_APE_PAT) & " " & _
                IIf(IsNothing(oGrupoMantenimiento.Personas.PER_APE_MAT), "", oGrupoMantenimiento.Personas.PER_APE_MAT) & " " & _
                IIf(IsNothing(oGrupoMantenimiento.Personas.PER_NOMBRES), "", oGrupoMantenimiento.Personas.PER_NOMBRES)

            For Each mItem In oGrupoMantenimiento.DetalleGrupoMantenimiento

                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("grm_Item").Value = mItem.grm_Item
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("grm_Item").Tag = mItem
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OTR_ID").Value = mItem.OTR_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("OTR_ID").Tag = mItem.OTR_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Orden").Value = mItem.OTR_ID
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_id").Value = mItem.per_id
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_id").Tag = mItem.per_id

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Nombre").Value = IIf(IsNothing(mItem.Personas.PER_APE_PAT), "", mItem.Personas.PER_APE_PAT) & " " & _
                IIf(IsNothing(mItem.Personas.PER_APE_MAT), "", mItem.Personas.PER_APE_MAT) & " " & _
                IIf(IsNothing(mItem.Personas.PER_NOMBRES), "", mItem.Personas.PER_NOMBRES)


                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("grm_HoraDesde").Value = mItem.grm_HoraDesde
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("grm_HoraHasta").Value = mItem.grm_HoraHasta
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("grm_HoraTotal").Value = mItem.grm_HoraTotal
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("grm_observaciones").Value = mItem.grm_observaciones

                If Not (mItem.OrdenTrabajo Is Nothing OrElse IsDBNull(mItem.OrdenTrabajo)) Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Entidad").Value = mItem.OrdenTrabajo.Entidad.ENO_DESCRIPCION

                End If
                If Not (mItem.OrdenTrabajo Is Nothing OrElse IsDBNull(mItem.OrdenTrabajo)) Then
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Descripcion").Value = mItem.OrdenTrabajo.OTR_OBSERVACION

                End If

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("grm_observaciones").Value = mItem.grm_observaciones

               
            Next
        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()

            Dim iRow As Integer = 0
            dgvDetalle.Rows.Add()
        End Sub

        Public Overrides Sub OnManQuitarFilaGrid()
            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    If Not mDetalle.Cells("grm_Item").Value Is Nothing Then
                        With CType(mDetalle.Cells("grm_Item").Tag, BE.DetalleGrupoMantenimiento)
                            .MarkAsDeleted()
                        End With
                    End If
                    dgvDetalle.Rows.Remove(mDetalle)
                Next

            Else
                MsgBox("Seleccione un registro")
            End If
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.GrupoMantenimiento)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            If (validar()) Then
                Try
                    If oGrupoMantenimiento IsNot Nothing Then

                        dgvDetalle.EndEdit()

                        oGrupoMantenimiento.grm_Fecha = CDate(dateFecha.Text)
                        oGrupoMantenimiento.prd_Periodo_id = txtPeriodo.Text
                        oGrupoMantenimiento.grm_Numero = txtNumero.Text

                        oGrupoMantenimiento.Usu_Id = SessionServer.UserId
                        oGrupoMantenimiento.grm_FECGRAB = Now


                        oGrupoMantenimiento.grm_observaciones = txtObservaciones.Text
                        oGrupoMantenimiento.per_IDResponsable = txtResponsable.Tag


                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("grm_Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("grm_Item").Tag, BE.DetalleGrupoMantenimiento)

                                    .prd_Periodo_id = txtPeriodo.Text
                                    .grm_Numero = txtNumero.Text
                                    .grm_Item = mDetalle.Cells("grm_Item").Value

                                    If Not (IsDBNull(mDetalle.Cells("OTR_ID").Value) OrElse Val(mDetalle.Cells("OTR_ID").Value) <= 0) Then
                                        .OTR_ID = CInt(mDetalle.Cells("OTR_ID").Value)
                                    Else
                                        .OTR_ID = Nothing
                                    End If

                                    .per_id = mDetalle.Cells("per_id").Tag

                                    .grm_HoraDesde = CDec(mDetalle.Cells("grm_HoraDesde").Value)
                                    .grm_HoraHasta = CDec(mDetalle.Cells("grm_HoraHasta").Value)
                                    .grm_HoraTotal = CDec(mDetalle.Cells("grm_HoraTotal").Value)
                                    .grm_observaciones = mDetalle.Cells("grm_observaciones").Value

                                    .grt_FECGRAB = Now
                                    .Usu_Id = SessionServer.UserId


                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetalleGrupoMantenimiento
                                With nOSD

                                    .prd_Periodo_id = txtPeriodo.Text
                                    .grm_Numero = txtNumero.Text
                                    If Not (IsDBNull(mDetalle.Cells("OTR_ID").Value) OrElse Val(mDetalle.Cells("OTR_ID").Value) <= 0) Then
                                        .OTR_ID = CInt(mDetalle.Cells("OTR_ID").Value)
                                    Else
                                        .OTR_ID = Nothing
                                    End If

                                    .per_id = mDetalle.Cells("per_id").Tag

                                    .grm_HoraDesde = CDec(mDetalle.Cells("grm_HoraDesde").Value)
                                    .grm_HoraHasta = CDec(mDetalle.Cells("grm_HoraHasta").Value)
                                    .grm_HoraTotal = CDec(mDetalle.Cells("grm_HoraTotal").Value)
                                    .grm_observaciones = mDetalle.Cells("grm_observaciones").Value

                                    .grt_FECGRAB = Now
                                    .Usu_Id = SessionServer.UserId

                                    .MarkAsAdded()

                                End With
                                oGrupoMantenimiento.DetalleGrupoMantenimiento.Add(nOSD)
                            End If
                        Next

                        BCGrupoMantenimiento.Maintenance(oGrupoMantenimiento)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                Catch ex As Exception

                    MsgBox(ex.Message)

                    'Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    'If (rethrow) Then
                    '    Throw
                    'End If

                End Try

            End If

        End Sub


        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oGrupoMantenimiento = New BE.GrupoMantenimiento
            oGrupoMantenimiento.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub


        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()
            Try
                If (MsgBox("Esta Seguro de Eliminar ", vbYesNo) = vbYes) Then
                    If oGrupoMantenimiento IsNot Nothing Then
                        oGrupoMantenimiento.MarkAsDeleted()

                        'Detalle de co.
                        oGrupoMantenimiento.grm_Numero = txtNumero.Text
                        oGrupoMantenimiento.prd_Periodo_id = txtPeriodo.Text

                        BCGrupoMantenimiento.SPGrupoMantenimientoDelete(oGrupoMantenimiento)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                End If

            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                If (rethrow) Then
                    Throw
                End If
            End Try
        End Sub
        Public Overrides Sub OnManCancelarEdicion()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub
        Public Overrides Sub OnManEditar()
            menuEditar()
            Panel1.Enabled = True
            HabilitarElementoGrid()
        End Sub
        Public Overrides Sub OnManDeshacerCambios()
            menuInicio()
            Panel1.Enabled = False
            limpiar()
        End Sub
        Function validarCeldas() As Boolean
            Dim result As Boolean = True
            Dim iRow As Integer = 0

            Try
                While (dgvDetalle.Rows.Count > iRow)
                    With dgvDetalle.Rows(iRow)

                        If (Not (IsNumeric(dgvDetalle.Rows(iRow).Cells("grm_HoraTotal").Value)) OrElse Val(dgvDetalle.Rows(iRow).Cells("grm_HoraTotal").Value) <= 0) Then
                            result = False
                            ErrorProvider1.SetError(txtObservaciones, "Total Horas")
                            Return result
                        Else
                            ErrorProvider1.SetError(txtObservaciones, Nothing)
                        End If

                        If (dgvDetalle.Rows(iRow).Cells("per_id").Tag = "") Then
                            result = False
                            ErrorProvider1.SetError(txtObservaciones, "Verifique las Personas Ingresadas")
                            Return result
                        Else
                            ErrorProvider1.SetError(txtObservaciones, Nothing)
                        End If


                    End With
                    iRow += 1
                End While
            Catch ex As Exception
                result = False
            End Try

            Return result

        End Function

        Private Sub btnResponsable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResponsable.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.BuscarPersona)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtResponsable.Tag = .Cells(0).Value()
                    txtResponsable.Text = .Cells(1).Value
                    ' menuBuscar()
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnSerie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerie.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
            End If

            frm.Dispose()
        End Sub



        Private Sub frmGrupoMantenimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub

        Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
            Select Case dgvDetalle.Columns(e.ColumnIndex).Name

                Case "per_id"

                    'Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    'frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                    'If (frm.ShowDialog = DialogResult.OK) Then
                    '    With frm.dgbRegistro.CurrentRow
                    '        ' dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Tag = .Cells(0).Value
                    '        ' dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Value = .Cells(1).Value
                    '        dgvDetalle.Rows(e.RowIndex).Cells("Nombre").Value = .Cells(2).Value
                    '        dgvDetalle.Rows(e.RowIndex).Cells("per_id").Tag = .Cells(0).Value
                    '    End With
                    'End If

                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    frm.inicio(Constants.BuscadoresNames.BuscarPersona)

                    If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                        With frm.dgbRegistro.CurrentRow
                            dgvDetalle.Rows(e.RowIndex).Cells("per_id").Tag = .Cells(0).Value()
                            dgvDetalle.Rows(e.RowIndex).Cells("Nombre").Value = .Cells(1).Value
                            ' menuBuscar()
                        End With
                    End If
                    frm.Dispose()


                Case "OTR_ID"
                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarFecha)()
                    frm.inicio(Constants.BuscadoresNames.OrdenTrabajo)
                    frm.dateDesde.Value = Today.AddYears(-1)
                    If (frm.ShowDialog = DialogResult.OK) Then
                        With frm.dgbRegistro.CurrentRow
                            dgvDetalle.Rows(e.RowIndex).Cells("OTR_ID").Value = .Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("OTR_ID").Tag = .Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("orden").Value = .Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("Entidad").Value = .Cells(1).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("Descripcion").Value = .Cells(2).Value
                        End With
                    End If




            End Select
        End Sub

        Private Sub dgvDetalle_CellStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles dgvDetalle.CellStateChanged




            If (Not e.Cell.Value Is Nothing) Then
                Select dgvDetalle.Columns(e.Cell.ColumnIndex).Name

                    Case "Orden"
                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarFecha)()
                        frm.inicio(Constants.BuscadoresNames.OrdenTrabajo)
                        frm.dateDesde.Value = Today.AddMonths(-3)
                        frm.dateHasta.Value = Today.AddMonths(2)
                        frm.llenarCombo()
                        frm.txtBuscar.Text = e.Cell.Value
                        frm.cargarDatos()
                        If (frm.ShowDialog = DialogResult.OK) Then

                            With frm.dgbRegistro.CurrentRow
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("OTR_ID").Value = .Cells(0).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("OTR_ID").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("orden").Value = .Cells(0).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Entidad").Value = .Cells(1).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Descripcion").Value = .Cells(2).Value
                            End With


                        End If

                End Select

            end if
            If (e.Cell.RowIndex >= 0) Then
                dgvDetalle.Rows(e.Cell.RowIndex).Cells("grm_HoraTotal").Value = BCUtil.diferenciaHorasHH(dgvDetalle.Rows(e.Cell.RowIndex).Cells("grm_HoraDesde").Value, dgvDetalle.Rows(e.Cell.RowIndex).Cells("grm_HoraHasta").Value)

            End If

        End Sub

        Private Sub ClonarFilaSeleccionadaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClonarFilaSeleccionadaToolStripMenuItem.Click
            Dim x As Integer = 0
            Dim y As Integer = 0
            While dgvDetalle.SelectedRows.Count > x
                dgvDetalle.Rows.Add()
                y = 1
                While (dgvDetalle.Columns.Count > y)

                    Try
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Value = dgvDetalle.SelectedRows(x).Cells(y).Value
                    Catch ex As Exception
                    End Try

                    Try
                        dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Tag = dgvDetalle.SelectedRows(x).Cells(y).Tag
                    Catch ex As Exception
                    End Try

                    y += 1
                End While

                x += 1
            End While
        End Sub

        Private Sub ToolStripTextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ToolStripTextBox1.KeyPress
            If (e.KeyChar = Chr(Keys.Enter)) Then
                Dim x As Integer = 0
                Dim y As Integer = 0

                If (dgvDetalle.SelectedRows.Count > 0) Then
                    While Val(ToolStripTextBox1.Text) > x
                        dgvDetalle.Rows.Add()
                        y = 1
                        While (dgvDetalle.Columns.Count > y)
                            Try
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Value = dgvDetalle.SelectedRows(0).Cells(y).Value
                            Catch ex As Exception
                            End Try
                            Try
                                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells(y).Tag = dgvDetalle.SelectedRows(0).Cells(y).Tag
                            Catch ex As Exception
                            End Try
                            y += 1
                        End While

                        x += 1
                    End While
                Else
                    MsgBox("Seleccione una fila para duplicar")
                End If

            End If
        End Sub



    End Class
End Namespace
