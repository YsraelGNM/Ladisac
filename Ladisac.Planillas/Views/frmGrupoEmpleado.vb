
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling


Namespace Ladisac.Planillas.Views
    Public Class frmGrupoEmpleado

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property BCGrupoEmpleado As BL.IBCGrupoEmpleado

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        <Dependency()> _
        Public Property BCMarcacion As BL.IBCMarcacion


        Protected oGrupoEmpleado As New BE.GrupoEmpleado


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
            oGrupoEmpleado = BCGrupoEmpleado.GrupoEmpleadoSeek(numero, periodo)
            oGrupoEmpleado.MarkAsModified()
            txtPeriodo.Text = oGrupoEmpleado.prd_Periodo_id
            txtNumero.Text = oGrupoEmpleado.gre_Numero
            dateFecha.Value = oGrupoEmpleado.gre_Fecha

            txtResponsable.Tag = oGrupoEmpleado.per_IDResponsable
            txtObservaciones.Text = oGrupoEmpleado.gre_observaciones

            txtResponsable.Text = IIf(IsNothing(oGrupoEmpleado.Personas.PER_APE_PAT), "", oGrupoEmpleado.Personas.PER_APE_PAT) & " " & _
                IIf(IsNothing(oGrupoEmpleado.Personas.PER_APE_MAT), "", oGrupoEmpleado.Personas.PER_APE_MAT) & " " & _
                IIf(IsNothing(oGrupoEmpleado.Personas.PER_NOMBRES), "", oGrupoEmpleado.Personas.PER_NOMBRES)

            Dim oTablita As New DataTable
            oTablita = BCGrupoEmpleado.spDetalleGrupoEmpleadoMaintenanceSelect(periodo, numero)
            Dim x As Integer = 0

            While (x < oTablita.Rows.Count)

                With oTablita.Rows(x)


                    Dim nRow As New DataGridViewRow
                    dgvDetalle.Rows.Add(nRow)

                    Dim oNewDetalleGrupoEmpleado As New BE.DetalleGrupoEmpleado

                    '-----------------------------------

                    oNewDetalleGrupoEmpleado.gre_Item = .Item("gre_Item")
                    oNewDetalleGrupoEmpleado.per_id = .Item("per_id")


                    oNewDetalleGrupoEmpleado.gre_HoraDesdePLL = .Item("gre_HoraDesdePLL")
                    oNewDetalleGrupoEmpleado.gre_HoraHastaPLL = .Item("gre_HoraHastaPLL")
                    oNewDetalleGrupoEmpleado.gre_HoraDesde = .Item("gre_HoraDesde")
                    oNewDetalleGrupoEmpleado.gre_HoraHasta = .Item("gre_HoraHasta")
                    oNewDetalleGrupoEmpleado.gre_HoraTotal = .Item("gre_HoraTotal")
                    oNewDetalleGrupoEmpleado.gre_observaciones = IIf(IsDBNull(.Item("gre_observaciones")), "", .Item("gre_observaciones"))

                    oNewDetalleGrupoEmpleado.gre_Refrigerio = .Item("gre_Refrigerio")

                    oNewDetalleGrupoEmpleado.gre_Esdoble = .Item("gre_Esdoble")
                    oNewDetalleGrupoEmpleado.gre_fecha = CDate(.Item("gre_fecha"))
                    oNewDetalleGrupoEmpleado.gre_HoraExtraSimple = (.Item("gre_HoraExtraSimple"))


                    '-----------------------------------

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_Item").Value = .Item("gre_Item")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_id").Value = .Item("per_id")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_id").Tag = .Item("per_id")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Nombre").Value = .Item("Nombre")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Item("Codigo")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraDesdePll").Value = .Item("gre_HoraDesdePLL")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraHastaPll").Value = .Item("gre_HoraHastaPLL")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraDesde").Value = .Item("gre_HoraDesde")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraHasta").Value = .Item("gre_HoraHasta")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraTotal").Value = .Item("gre_HoraTotal")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraExtraSimple").Value = .Item("gre_HoraExtraSimple")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_Refrigerio").Value = .Item("gre_Refrigerio")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_Esdoble").Value = .Item("gre_Esdoble")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_fecha").Value = CDate(.Item("gre_fecha"))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dia").Value = CDate(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_fecha").Value).ToString("dd") & " " & WeekdayName(Weekday(CDate(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_fecha").Value)), False, 1)
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_observaciones").Value = IIf(IsDBNull(.Item("gre_observaciones")), "", .Item("gre_observaciones"))


                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_Item").Tag = oNewDetalleGrupoEmpleado

                    oGrupoEmpleado.DetalleGrupoEmpleado.Add(oNewDetalleGrupoEmpleado)

                End With
                x += 1
            End While


        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()

            Dim iRow As Integer = 0
            dgvDetalle.Rows.Add()
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraDesde").Value = "0.00"
            dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraHasta").Value = "0.00"

        End Sub

        Public Overrides Sub OnManQuitarFilaGrid()
            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    If Not mDetalle.Cells("gre_Item").Value Is Nothing Then
                        With CType(mDetalle.Cells("gre_Item").Tag, BE.DetalleGrupoEmpleado)
                            .MarkAsDeleted()
                        End With
                    End If
                    dgvDetalle.Rows.Remove(mDetalle)
                Next

            Else
                MsgBox("Seleccione un registro")
            End If
        End Sub

        Sub sumaPersona(ByVal sCodigo As String)

            Dim x As Integer = 0
            Dim dSimple, dDoble As Double
            Dim sNOmbre As String = ""
            Dim CuentaXPersona As Int16 = 0

            dSimple = 0
            dDoble = 0
            Try
                While (dgvDetalle.Rows.Count > x)


                    If (dgvDetalle.Rows(x).Cells("Codigo").Value = sCodigo) Then
                        sNOmbre = dgvDetalle.Rows(x).Cells("Nombre").Value

                        If CBool(dgvDetalle.Rows(x).Cells("gre_Esdoble").Value) Then

                            dDoble += dgvDetalle.Rows(x).Cells("gre_HoraTotal").Value
                        Else
                            dSimple += dgvDetalle.Rows(x).Cells("gre_HoraTotal").Value

                        End If
                        CuentaXPersona += 1

                    End If

                    x += 1

                End While
            Catch ex As Exception

            End Try

            txtHoraSimple.Text = dSimple
            txtHoraDoble.Text = dDoble
            txtTrabajador.Text = sNOmbre
            txtDiasMarcados.Text = CuentaXPersona.ToString

        End Sub



        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarFecha)()
            frm.inicio(Constants.BuscadoresNames.GrupoEmpleado) 'GrupoMantenimiento

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub

        Public Overrides Sub OnManGuardar()
            If (validar()) Then

                If (txtNumero.Text = "") Then
                    oGrupoEmpleado = New BE.GrupoEmpleado
                    oGrupoEmpleado.MarkAsAdded()
                End If
                Try
                    If oGrupoEmpleado IsNot Nothing Then

                        dgvDetalle.EndEdit()

                        oGrupoEmpleado.gre_Fecha = CDate(dateFecha.Text)
                        oGrupoEmpleado.prd_Periodo_id = txtPeriodo.Text
                        oGrupoEmpleado.gre_Numero = txtNumero.Text

                        oGrupoEmpleado.Usu_Id = SessionServer.UserId
                        oGrupoEmpleado.gre_FECGRAB = Now


                        oGrupoEmpleado.gre_observaciones = txtObservaciones.Text
                        oGrupoEmpleado.per_IDResponsable = txtResponsable.Tag


                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("gre_Item").Value Is Nothing Then
                                With CType(mDetalle.Cells("gre_Item").Tag, BE.DetalleGrupoEmpleado)

                                    .prd_Periodo_id = txtPeriodo.Text
                                    .gre_Numero = txtNumero.Text
                                    .gre_Item = mDetalle.Cells("gre_Item").Value

                                    .per_id = mDetalle.Cells("per_id").Tag

                                    .gre_HoraDesde = CDec(mDetalle.Cells("gre_HoraDesde").Value)
                                    .gre_HoraHasta = CDec(mDetalle.Cells("gre_HoraHasta").Value)
                                    .gre_HoraDesdePLL = CDec(mDetalle.Cells("gre_HoraDesdePLL").Value)
                                    .gre_HoraHastaPLL = CDec(mDetalle.Cells("gre_HoraHastaPLL").Value)
                                    .gre_HoraTotal = CDec(mDetalle.Cells("gre_HoraTotal").Value)
                                    .gre_observaciones = mDetalle.Cells("gre_observaciones").Value
                                    .gre_fecha = CDate(mDetalle.Cells("gre_fecha").Value)
                                    .gre_Esdoble = mDetalle.Cells("gre_Esdoble").Value

                                    .gre_Refrigerio = CDec(mDetalle.Cells("gre_Refrigerio").Value)
                                    .gre_HoraExtraSimple = CDec(mDetalle.Cells("gre_HoraExtraSimple").Value)
                                    .gre_FECGRAB = Now
                                    .Usu_Id = SessionServer.UserId


                                    .MarkAsModified()

                                End With
                            Else 'If Not mDetalle.Cells("per_Id").Value Is Nothing Then
                                Dim nOSD As New DetalleGrupoEmpleado
                                With nOSD

                                    .prd_Periodo_id = txtPeriodo.Text
                                    .gre_Numero = txtNumero.Text


                                    .per_id = mDetalle.Cells("per_id").Tag

                                    .gre_HoraDesde = CDec(mDetalle.Cells("gre_HoraDesde").Value)
                                    .gre_HoraHasta = CDec(mDetalle.Cells("gre_HoraHasta").Value)
                                    .gre_HoraDesdePLL = CDec(mDetalle.Cells("gre_HoraDesdePLL").Value)
                                    .gre_HoraHastaPLL = CDec(mDetalle.Cells("gre_HoraHastaPLL").Value)
                                    .gre_HoraTotal = CDec(mDetalle.Cells("gre_HoraTotal").Value)
                                    .gre_observaciones = mDetalle.Cells("gre_observaciones").Value

                                    .gre_fecha = CDate(mDetalle.Cells("gre_fecha").Value)
                                    .gre_Esdoble = mDetalle.Cells("gre_Esdoble").Value

                                    .gre_Refrigerio = CDec(mDetalle.Cells("gre_Refrigerio").Value)
                                    .gre_HoraExtraSimple = CDec(mDetalle.Cells("gre_HoraExtraSimple").Value)

                                    .gre_FECGRAB = Now
                                    .Usu_Id = SessionServer.UserId

                                    .MarkAsAdded()

                                End With
                                oGrupoEmpleado.DetalleGrupoEmpleado.Add(nOSD)
                            End If
                        Next

                        BCGrupoEmpleado.Maintenance(oGrupoEmpleado)
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
            oGrupoEmpleado = New BE.GrupoEmpleado
            oGrupoEmpleado.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub


        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub

        Public Overrides Sub OnManEliminar()
            Try
                If (MsgBox("Esta Seguro de Eliminar ", vbYesNo) = vbYes) Then
                    If oGrupoEmpleado IsNot Nothing Then
                        oGrupoEmpleado.MarkAsDeleted()

                        'Detalle de co.
                        oGrupoEmpleado.gre_Numero = txtNumero.Text
                        oGrupoEmpleado.prd_Periodo_id = txtPeriodo.Text

                        BCGrupoEmpleado.SPGrupoEmpleadoDelete(oGrupoEmpleado)
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

                        If (Not (IsNumeric(dgvDetalle.Rows(iRow).Cells("gre_HoraTotal").Value)) OrElse Val(dgvDetalle.Rows(iRow).Cells("gre_HoraTotal").Value) <= 0) Then
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

            Dim x As Integer = 0

            While (dgvDetalle.Columns.Count > x)
                dgvDetalle.Columns(x).SortMode = DataGridViewColumnSortMode.NotSortable
                x += 1
            End While



        End Sub

        Private Sub dgvDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
            Select Case dgvDetalle.Columns(e.ColumnIndex).Name

                Case "per_id"

                    Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    frm.inicio(Constants.BuscadoresNames.DatosLaborales)
                    If (frm.ShowDialog = DialogResult.OK) Then
                        With frm.dgbRegistro.CurrentRow
                            dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Tag = .Cells(0).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Value = .Cells(1).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("Nombre").Value = .Cells(2).Value
                            dgvDetalle.Rows(e.RowIndex).Cells("per_id").Tag = .Cells(0).Value
                        End With
                    End If

                    'Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                    'frm.inicio(Constants.BuscadoresNames.BuscarPersona)

                    'If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    '    With frm.dgbRegistro.CurrentRow
                    '        dgvDetalle.Rows(e.RowIndex).Cells("per_id").Tag = .Cells(0).Value()
                    '        dgvDetalle.Rows(e.RowIndex).Cells("Nombre").Value = .Cells(1).Value
                    '        ' menuBuscar()
                    '    End With
                    'End If
                    'frm.Dispose()


            End Select
        End Sub

        Private Sub dgvDetalle_CellStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles dgvDetalle.CellStateChanged




            'If (Not e.Cell.Value Is Nothing) Then
            '    Select Case dgvDetalle.Columns(e.Cell.ColumnIndex).Name

            '        Case "Orden"
            '            Dim frm = Me.ContainerService.Resolve(Of frmBuscarFecha)()
            '            frm.inicio(Constants.BuscadoresNames.OrdenTrabajo)
            '            frm.dateDesde.Value = Today.AddMonths(-3)
            '            frm.dateHasta.Value = Today.AddMonths(2)
            '            frm.llenarCombo()
            '            frm.txtBuscar.Text = e.Cell.Value
            '            frm.cargarDatos()
            '            If (frm.ShowDialog = DialogResult.OK) Then

            '                With frm.dgbRegistro.CurrentRow
            '                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("OTR_ID").Value = .Cells(0).Value
            '                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("OTR_ID").Tag = .Cells(0).Value
            '                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("orden").Value = .Cells(0).Value
            '                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("Entidad").Value = .Cells(1).Value
            '                    dgvDetalle.Rows(e.Cell.RowIndex).Cells("Descripcion").Value = .Cells(2).Value
            '                End With


            '            End If

            '    End Select

            'End If
            If (e.Cell.RowIndex >= 0) Then
                dgvDetalle.Rows(e.Cell.RowIndex).Cells("gre_HoraTotal").Value = Math.Round(BCUtil.diferenciaHorasHH(dgvDetalle.Rows(e.Cell.RowIndex).Cells("gre_HoraDesdePLL").Value, dgvDetalle.Rows(e.Cell.RowIndex).Cells("gre_HoraHastaPLL").Value) - dgvDetalle.Rows(e.Cell.RowIndex).Cells("gre_Refrigerio").Value, 2)

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
        Function horaAEntero(ByVal shora As TimeSpan) As String
            Dim shoraRes As String
            shoraRes = shora.Hours.ToString & "." & shora.Minutes

            Return shoraRes
        End Function
        Private Sub btnObtenerDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerDatos.Click

            Dim oTable As DataTable
            Dim x As Integer = 0

            oTable = BCGrupoEmpleado.SPGrupoEmpleadoHorasSelect(CDate(dateDesde.Value), CDate(dateHasta.Value), Nothing)
            dgvDetalle.Rows.Clear()

            While (oTable.Rows.Count > x)
                With oTable.Rows(x)


                    dgvDetalle.Rows.Add()
                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_Item").Value = Nothing
                    'dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_Item").Tag = Nothing
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_id").Value = .Item("per_id")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("per_id").Tag = .Item("per_id")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Codigo").Value = .Item("Codigo")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Nombre").Value = .Item("Nombre")

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraDesdePll").Value = horaAEntero(.Item("IngresoH"))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraHastaPll").Value = horaAEntero(.Item("SalidaH"))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraDesde").Value = horaAEntero(.Item("IngresoH"))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraHasta").Value = horaAEntero(.Item("SalidaH"))

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_observaciones").Value = ""
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_Refrigerio").Value = .Item("Refrigerio")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_Esdoble").Value = .Item("doble")
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_fecha").Value = CDate(.Item("Dia"))
                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("dia").Value = CDate(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_fecha").Value).ToString("dd") & " " & WeekdayName(Weekday(CDate(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_fecha").Value)), False, 1)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraTotal").Value = Math.Round(BCUtil.diferenciaHorasHH(dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraDesdePLL").Value, dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraHastaPLL").Value) - dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_Refrigerio").Value, 2)

                    dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("gre_HoraExtraSimple").Value = "0"





                End With

                x += 1
            End While


        End Sub

        Private Sub txtCodigoBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoBusca.TextChanged
            Dim x As Integer = 0
            x = 0
            If (txtCodigoBusca.Text.Length >= 4) Then
                While (dgvDetalle.Rows.Count > x)
                    Try
                        If (dgvDetalle.Rows(x).Cells("Codigo").Value = txtCodigoBusca.Text) Then
                            dgvDetalle.CurrentCell = dgvDetalle.Rows(x).Cells("Codigo")
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If
        End Sub
        Sub LlenarMarcacion(ByVal Fecha As Date, ByVal idpersona As String)
            Try
                dgvMarcacion.DataSource = BCMarcacion.SPMarcacionColtronSelectXML(idpersona, Fecha)
                If (dgvMarcacion.Rows.Count <= 0) Then
                    lblPersona.Text = ""
                End If
            Catch ex As Exception

                dgvMarcacion.DataSource = Nothing
                lblPersona.Text = ""
            End Try
        End Sub
        Private Sub dgvDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellEnter

            Try
                sumaPersona(dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Value)
            Catch ex As Exception
            End Try


            Try
                dgvDetalle.Rows(e.RowIndex).Cells("dia").Value = CDate(dgvDetalle.Rows(e.RowIndex).Cells("gre_fecha").Value).ToString("dd") & " " & WeekdayName(Weekday(CDate(dgvDetalle.Rows(e.RowIndex).Cells("gre_fecha").Value)), False, 1)
            Catch ex As Exception
            End Try

            Try
                LlenarMarcacion(CDate(dgvDetalle.Rows(e.RowIndex).Cells("gre_fecha").Value), dgvDetalle.Rows(e.RowIndex).Cells("per_id").Value)
                lblPersona.Text = CDate(dgvDetalle.Rows(e.RowIndex).Cells("Codigo").Value) & "-" & (dgvDetalle.Rows(e.RowIndex).Cells("Nombre").Value)
            Catch ex As Exception
                lblPersona.Text = ""
            End Try


        End Sub

        Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
            Dim oTablita As New DataTable
            If (dgvDetalle.Rows.Count > 0) Then
                oTablita = BCUtil.getTable(dgvDetalle, "MiTablita")
                BCUtil.excelExportar(oTablita)

            End If
        End Sub

       
        Private Sub AgregarUnaFilaEnEsteLugarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgregarUnaFilaEnEsteLugarToolStripMenuItem.Click
            Dim filaActual As Integer
            Dim x, y As Integer

            filaActual = dgvDetalle.SelectedRows(0).Index
            x = dgvDetalle.Rows.Count
            dgvDetalle.Rows.Add()

            While (x > filaActual)
                y = 0
                While (dgvDetalle.Columns.Count > y)

                    Try
                        dgvDetalle.Rows(x).Cells(y).Value = dgvDetalle.Rows(x - 1).Cells(y).Value
                    Catch ex As Exception

                    End Try
                    Try
                        dgvDetalle.Rows(x).Cells(y).Tag = dgvDetalle.Rows(x - 1).Cells(y).Tag
                    Catch ex As Exception

                    End Try


                    y += 1
                End While

                x -= 1

            End While

            dgvDetalle.Rows(filaActual + 1).Cells("gre_Item").Tag = Nothing
            dgvDetalle.Rows(filaActual + 1).Cells("gre_Item").Value = ""




        End Sub

       
    End Class
End Namespace
