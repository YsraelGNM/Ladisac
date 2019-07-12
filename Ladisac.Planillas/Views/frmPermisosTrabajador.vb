
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmPermisosTrabajador

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCDatosTrabajadorJudicial As Ladisac.BL.IBCDatosTrabajadorJudicial

        <Dependency()> _
        Public Property BCPermisosTrabajador As Ladisac.BL.IBCPermisosTrabajador


        Protected oPermisosTrabajador As New BE.PermisosTrabajador

        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtTrabajador.Text.Trim = "") Then
                ErrorProvider1.SetError(txtTrabajador, "Trabajador")
                result = False
            Else
                ErrorProvider1.SetError(txtTrabajador, Nothing)
            End If

            If (txtAutoriza.Text.Trim = "") Then
                ErrorProvider1.SetError(txtAutoriza, "Autoriza")
                result = False
            Else
                ErrorProvider1.SetError(txtAutoriza, Nothing)
            End If

            If (txtMotivo.Text.Trim = "") Then
                ErrorProvider1.SetError(txtMotivo, "Motivo")
                result = False
            Else
                ErrorProvider1.SetError(txtMotivo, Nothing)
            End If

            If (dgvDetalle.Rows.Count <= 0) Then
                ErrorProvider1.SetError(dgvDetalle, "Horas")
                result = False
            Else
                ErrorProvider1.SetError(dgvDetalle, Nothing)
            End If

            If (txtObservaciones.Text.Trim = "") Then
                ErrorProvider1.SetError(txtMotivo, "Observaciones")
                result = False
            Else
                ErrorProvider1.SetError(txtObservaciones, Nothing)
            End If

            If (Not validarCeldas()) Then
                result = False
            End If


            Return result
        End Function
        Private Sub limpiar()
            txtAutoriza.Text = ""
            txtAutoriza.Tag = ""
            txtTrabajador.Text = ""
            txtTrabajador.Tag = ""
            txtMotivo.Text = ""

            txtObservaciones.Text = ""
            txtNumero.Text = ""

            dgvDetalle.Rows.Clear()

        End Sub
        Sub cargar(ByVal numero As String)
            limpiar()
            oPermisosTrabajador = BCPermisosTrabajador.PermisosTrabajadorSeek(numero)
            oPermisosTrabajador.MarkAsModified()

            txtNumero.Text = oPermisosTrabajador.prm_Numero
            dateFecha.Value = oPermisosTrabajador.prm_Fecha

            txtTrabajador.Tag = oPermisosTrabajador.per_IdTrabajador

            txtTrabajador.Text = IIf(IsNothing(oPermisosTrabajador.Personas.PER_APE_PAT), "", oPermisosTrabajador.Personas.PER_APE_PAT) & " " & _
                IIf(IsNothing(oPermisosTrabajador.Personas.PER_APE_MAT), "", oPermisosTrabajador.Personas.PER_APE_MAT) & " " & _
                IIf(IsNothing(oPermisosTrabajador.Personas.PER_NOMBRES), "", oPermisosTrabajador.Personas.PER_NOMBRES)


            txtAutoriza.Tag = oPermisosTrabajador.per_IdAutoriza

            txtAutoriza.Text = IIf(IsNothing(oPermisosTrabajador.Personas1.PER_APE_PAT), "", oPermisosTrabajador.Personas1.PER_APE_PAT) & " " & _
                IIf(IsNothing(oPermisosTrabajador.Personas1.PER_APE_MAT), "", oPermisosTrabajador.Personas1.PER_APE_MAT) & " " & _
                IIf(IsNothing(oPermisosTrabajador.Personas1.PER_NOMBRES), "", oPermisosTrabajador.Personas1.PER_NOMBRES)

            txtObservaciones.Text = oPermisosTrabajador.prm_Observaciones
            txtMotivo.Text = oPermisosTrabajador.prm_Motivo

            chkEsRenumeracion.Checked = oPermisosTrabajador.prm_EsRenumerado


            For Each mItem In oPermisosTrabajador.DetallePermisosTrabajador

                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Tag = mItem

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = mItem.dper_Item
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Horas").Value = mItem.dper_Hora
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("FechaInicio").Value = mItem.dper_FechaInicio
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("FechaFin").Value = mItem.dper_FechaFin
                'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dtj_idTiposConceptos").Value = mItem.dtj_idTiposConceptos
                'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("con_Conceptos_Id").Value = mItem.con_Conceptos_Id
                'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Conceptos").Value = mItem.Conceptos.con_Concepto
                'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = mItem.dtj_Importe
                'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("EsPorcentaje").Value = mItem.dtj_EsPorcenteje

            Next


        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()

            Dim iRow As Integer = 0
            dgvDetalle.Rows.Add()
        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()
            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    If Not mDetalle.Cells("Item").Value Is Nothing Then
                        With CType(mDetalle.Cells("Item").Tag, BE.DetallePermisosTrabajador)
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

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.PermisosTrabajador)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False
        End Sub

        Public Overrides Sub OnManGuardar()
            If (validar()) Then
                Try
                    dgvDetalle.EndEdit()

                    If oPermisosTrabajador IsNot Nothing Then
                        dgvDetalle.EndEdit()

                        oPermisosTrabajador.prm_Fecha = CDate(dateFecha.Value)

                        oPermisosTrabajador.prm_Numero = txtNumero.Text

                        oPermisosTrabajador.Usu_Id = SessionServer.UserId
                        oPermisosTrabajador.prm_FECGRAB = Now

                        oPermisosTrabajador.prm_Motivo = txtMotivo.Text
                        oPermisosTrabajador.prm_Observaciones = txtObservaciones.Text

                        oPermisosTrabajador.per_IdAutoriza = txtAutoriza.Tag
                        oPermisosTrabajador.per_IdTrabajador = txtTrabajador.Tag

                        oPermisosTrabajador.prm_EsRenumerado = chkEsRenumeracion.Checked

                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("Item").Tag, BE.DetallePermisosTrabajador)

                                    .dper_Item = mDetalle.Cells("Item").Value
                                    .dper_Hora = mDetalle.Cells("Horas").Value
                                    .dper_FechaInicio = CDate(mDetalle.Cells("FechaInicio").Value)
                                    .dper_FechaFin = CDate(mDetalle.Cells("FechaFin").Value)

                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetallePermisosTrabajador
                                With nOSD

                                    .dper_Item = mDetalle.Cells("Item").Value
                                    .dper_Hora = mDetalle.Cells("Horas").Value
                                    .dper_FechaInicio = CDate(mDetalle.Cells("FechaInicio").Value)
                                    .dper_FechaFin = CDate(mDetalle.Cells("FechaFin").Value)

                                    .MarkAsAdded()

                                End With
                                oPermisosTrabajador.DetallePermisosTrabajador.Add(nOSD)
                            End If
                        Next

                        BCPermisosTrabajador.Maintenance(oPermisosTrabajador)
                        MsgBox("Datos Guardados")
                        menuInicio()
                        Panel1.Enabled = False
                        limpiar()
                        DeshabilitarElementoGrid()
                    End If
                Catch ex As Exception
                    Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                    If (rethrow) Then
                        Throw
                    End If
                End Try

            End If

        End Sub

        Public Overrides Sub OnManNuevo()
            limpiar()
            menuNuevo()
            oPermisosTrabajador = New BE.PermisosTrabajador
            oPermisosTrabajador.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()

            If (MsgBox("Esta Seguro de  Eliminar  ", vbYesNo) = vbYes) Then


                If (validar()) Then
                    Try
                        If oPermisosTrabajador IsNot Nothing Then
                            dgvDetalle.EndEdit()

                            oPermisosTrabajador.prm_Fecha = CDate(dateFecha.Value)

                            oPermisosTrabajador.prm_Numero = txtNumero.Text

                            oPermisosTrabajador.Usu_Id = SessionServer.UserId
                            oPermisosTrabajador.prm_FECGRAB = Now

                            oPermisosTrabajador.prm_Motivo = txtMotivo.Text
                            oPermisosTrabajador.prm_Observaciones = txtObservaciones.Text

                            oPermisosTrabajador.per_IdAutoriza = txtAutoriza.Tag
                            oPermisosTrabajador.per_IdTrabajador = txtTrabajador.Tag

                            oPermisosTrabajador.prm_EsRenumerado = chkEsRenumeracion.Checked

                            For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                                If Not mDetalle.Cells("Item").Value Is Nothing Then
                                    With CType(mDetalle.Cells("Item").Tag, BE.DetallePermisosTrabajador)

                                        .dper_Item = mDetalle.Cells("Item").Value
                                        .dper_Hora = mDetalle.Cells("Horas").Value
                                        .dper_FechaInicio = CDate(mDetalle.Cells("FechaInicio").Value)
                                        .dper_FechaFin = CDate(mDetalle.Cells("FechaFin").Value)

                                        .MarkAsModified()

                                    End With
                                Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                    Dim nOSD As New DetallePermisosTrabajador
                                    With nOSD

                                        .dper_Item = mDetalle.Cells("Item").Value
                                        .dper_Hora = mDetalle.Cells("Horas").Value
                                        .dper_FechaInicio = mDetalle.Cells("FechaInicio").Value
                                        .dper_FechaFin = mDetalle.Cells("FechaFin").Value

                                        .MarkAsAdded()

                                    End With
                                    oPermisosTrabajador.DetallePermisosTrabajador.Add(nOSD)
                                End If
                            Next
                            oPermisosTrabajador.MarkAsDeleted()

                            BCPermisosTrabajador.Maintenance(oPermisosTrabajador)
                            MsgBox("Datos Guardados")
                            menuInicio()
                            Panel1.Enabled = False
                            limpiar()
                            DeshabilitarElementoGrid()
                        End If
                    Catch ex As Exception
                        Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.Presentation)
                        If (rethrow) Then
                            Throw
                        End If
                    End Try

                End If
            End If
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

        Private Sub frmPermisosTrabajador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
        End Sub

        Function validarCeldas() As Boolean
            Dim result As Boolean = True
            Dim iRow As Integer = 0

            Try
                While (dgvDetalle.Rows.Count > iRow)
                    With dgvDetalle.Rows(iRow)

                        If (Not (IsNumeric(dgvDetalle.Rows(iRow).Cells("Horas").Value)) OrElse Val(dgvDetalle.Rows(iRow).Cells("Horas").Value) <= 0) Then
                            result = False
                            ErrorProvider1.SetError(dgvDetalle, "Horas")
                            Return result
                        Else
                            ErrorProvider1.SetError(dgvDetalle, Nothing)
                        End If

                        If Not IsDate(dgvDetalle.Rows(iRow).Cells("FechaInicio").Value) Then
                            result = False
                            ErrorProvider1.SetError(dgvDetalle, "Fecha Inicio")
                            Return result
                        Else
                            ErrorProvider1.SetError(dgvDetalle, Nothing)
                        End If

                        If Not IsDate(dgvDetalle.Rows(iRow).Cells("FechaFin").Value) Then
                            result = False
                            ErrorProvider1.SetError(dgvDetalle, "Fecha Fin")
                            Return result
                        Else
                            ErrorProvider1.SetError(dgvDetalle, Nothing)
                        End If

                    End With
                    iRow += 1
                End While
            Catch ex As Exception
                result = False
            End Try

            Return result








            Return result
        End Function

        Private Function diferenciaHorasHH(ByVal desde As Double, ByVal hasta As Double) As Double
            Dim diferencia, entre As Double
            diferencia = 0
            entre = 0
            If (hasta > desde) Then
                diferencia = hasta - desde
            Else
                entre = 24 - desde
                diferencia = entre + hasta
            End If

            Return diferencia
        End Function
        Private Sub dgvDetalle_CellStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles dgvDetalle.CellStateChanged

            If (Not e.Cell.Value Is Nothing) Then
                Select Case dgvDetalle.Columns(e.Cell.ColumnIndex).Name

                    Case "Codigo"

                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                        frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                        frm.llenarCombo()

                        frm.cboBuscar.SelectedIndex = 1
                        frm.txtBuscar.Text = e.Cell.Value
                        frm.cargarDatos()

                        If (frm.dgbRegistro.RowCount > 0) Then
                            With frm.dgbRegistro.Rows(0)
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Value = .Cells(1).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Persona").Value = .Cells(2).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("per_Id").Tag = .Cells(0).Value
                            End With
                        Else
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Tag = Nothing
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Codigo").Value = Nothing
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Persona").Value = Nothing
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("per_Id").Tag = Nothing

                        End If

                    Case "Produccion"

                        Dim frm = Me.ContainerService.Resolve(Of frmBuscarFecha)()
                        frm.inicio(Constants.BuscadoresNames.GrupoTrabajoProduccion)
                        frm.llenarCombo()

                        frm.cboBuscar.SelectedIndex = 1
                        frm.txtBuscar.Text = e.Cell.Value
                        frm.cargarDatos()

                        If (frm.dgbRegistro.RowCount > 0) Then
                            With frm.dgbRegistro.Rows(0)
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Value = .Cells(1).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("pro_Id").Tag = .Cells(0).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("pla_id").Value = .Cells(4).Value
                                dgvDetalle.Rows(e.Cell.RowIndex).Cells("Descripcion").Value = .Cells(3).Value
                            End With
                        Else
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Tag = Nothing
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Produccion").Value = Nothing
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("pro_Id").Tag = Nothing
                            dgvDetalle.Rows(e.Cell.RowIndex).Cells("Descripcion").Value = Nothing
                        End If

                End Select

            End If

        End Sub


        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellValidated

        End Sub

        Private Sub btnTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrabajador.Click

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtTrabajador.Tag = .Cells(0).Value()
                    txtTrabajador.Text = .Cells(2).Value
                    ' menuBuscar()
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnAutoriza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoriza.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtAutoriza.Tag = .Cells(0).Value()
                    txtAutoriza.Text = .Cells(2).Value
                    ' menuBuscar()
                End With
            End If
            frm.Dispose()
        End Sub
    End Class
End Namespace
