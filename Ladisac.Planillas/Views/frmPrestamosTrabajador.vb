
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling

Namespace Ladisac.Planillas.Views
    Public Class frmPrestamosTrabajador
        <Dependency()> _
        Public Property BCPrestamosTrabajador As Ladisac.BL.IBCPrestamosTrabajador

        <Dependency()> _
        Public Property SessionServer As Ladisac.Foundation.Services.ISessionService

        Protected oPrestamosTrabajador As New PrestamosTrabajador

        Private Function validar() As Boolean
            Dim result As Boolean = True

            If (txtSerie.Text.Trim = "") Then
                ErrorProvider1.SetError(txtSerie, "Serie")
                result = False
            Else
                ErrorProvider1.SetError(txtSerie, Nothing)
            End If

            If (txtAutoriza.Tag.Trim = "") Then
                ErrorProvider1.SetError(txtAutoriza, "Autoriza")
                result = False
            Else
                ErrorProvider1.SetError(txtAutoriza, Nothing)
            End If

            If (txtTrabajador.Tag.Trim = "") Then
                ErrorProvider1.SetError(txtTrabajador, "Trabajador")
                result = False
            Else
                ErrorProvider1.SetError(txtTrabajador, Nothing)
            End If

            If (dgvDetalle.Rows.Count <= 0) Then
                ErrorProvider1.SetError(dgvDetalle, "Prestamo")
                result = False
            Else
                ErrorProvider1.SetError(dgvDetalle, Nothing)
            End If

            If (Not IsNumeric(txtImporte) AndAlso Val(txtImporte.Text) < 0) Then
                ErrorProvider1.SetError(txtImporte, "Importe")
                result = False
            Else
                ErrorProvider1.SetError(txtImporte, "")
            End If
            If (Not validarDetalle()) Then
                ErrorProvider1.SetError(dgvDetalle, "Detalle(Presionar Enter)")
                result = False
            Else
                ErrorProvider1.SetError(dgvDetalle, Nothing)
            End If

            If (txtMoneda.Tag = "") Then
                ErrorProvider1.SetError(txtMoneda, "Moneda")
                result = False
            Else
                ErrorProvider1.SetError(txtMoneda, Nothing)
            End If

            If (txtPuntoVenta.Tag = "") Then
                ErrorProvider1.SetError(txtPuntoVenta, "Dependencia")
                result = False
            Else
                ErrorProvider1.SetError(txtPuntoVenta, Nothing)
            End If


            Return result
        End Function
        Private Sub limpiar()

            txtSerie.Text = ""
            txtNumero.Text = ""
            txtAutoriza.Tag = ""
            txtAutoriza.Text = ""
            txtTrabajador.Tag = ""
            txtTrabajador.Text = ""
            txtObservaciones.Text = ""
            chkActivo.Checked = True
            txtImporte.Text = ""
            dgvDetalle.Rows.Clear()

            txtMoneda.Tag = Nothing
            txtMoneda.Text = Nothing

            txtPuntoVenta.Text = ""
            txtPuntoVenta.Tag = Nothing

        End Sub
        Private Sub sumar()
            Dim x As Integer = 0
            Dim result As Double = 0
            Try
                While (dgvDetalle.Rows.Count > x)
                    With dgvDetalle.Rows(x)

                        If (IsNumeric(.Cells("Importe").Value)) Then
                            result += CDbl(.Cells("Importe").Value)

                        End If
                    End With
                    x += 1
                End While

                txtImporte.Text = result.ToString

            Catch ex As Exception
                txtImporte.Text = "0"
            End Try


        End Sub
        Private Function validarDetalle()

            Dim result As Boolean = True
            Dim x As Integer = 0

            Try
                While (dgvDetalle.Rows.Count > x)
                    With dgvDetalle.Rows(x)
                        If (Not IsNumeric(.Cells("Importe").Value) OrElse Val(.Cells("Importe").Value) <= 0 OrElse Not IsDate(.Cells("Vencimiento").Value)) Then
                            result = False
                        End If
                    End With
                    x += 1
                End While
            Catch ex As Exception
                result = False
            End Try

            Return result

        End Function
        Sub cargar(ByVal serie As String, ByVal numero As String)
            limpiar()
            oPrestamosTrabajador = BCPrestamosTrabajador.PrestamosTrabajadroSeek(serie, numero)
            oPrestamosTrabajador.MarkAsModified()

            txtSerie.Text = oPrestamosTrabajador.prt_SeriePres
            txtNumero.Text = oPrestamosTrabajador.prt_NumeroPres
            '  dateFechaInicio.Value = oDatosTrabajadorJudicial.dtj_FechaInici
            dateFechaFin.Value = oPrestamosTrabajador.prt_Fecha
            txtTrabajador.Tag = oPrestamosTrabajador.per_IdTrab

            txtTrabajador.Text = IIf(IsNothing(oPrestamosTrabajador.Personas1.PER_APE_PAT), "", oPrestamosTrabajador.Personas1.PER_APE_PAT) & " " & _
                IIf(IsNothing(oPrestamosTrabajador.Personas1.PER_APE_MAT), "", oPrestamosTrabajador.Personas1.PER_APE_MAT) & " " & _
                IIf(IsNothing(oPrestamosTrabajador.Personas1.PER_NOMBRES), "", oPrestamosTrabajador.Personas1.PER_NOMBRES)

            txtAutoriza.Tag = oPrestamosTrabajador.per_IdAutoriza

            txtAutoriza.Text = IIf(IsNothing(oPrestamosTrabajador.Personas.PER_APE_PAT), "", oPrestamosTrabajador.Personas.PER_APE_PAT) & " " & _
                IIf(IsNothing(oPrestamosTrabajador.Personas.PER_APE_MAT), "", oPrestamosTrabajador.Personas.PER_APE_MAT) & " " & _
                IIf(IsNothing(oPrestamosTrabajador.Personas.PER_NOMBRES), "", oPrestamosTrabajador.Personas.PER_NOMBRES)
            txtObservaciones.Text = oPrestamosTrabajador.prt_Observaciones
            txtImporte.Text = oPrestamosTrabajador.prt_Importe

            Try
                txtMoneda.Tag = oPrestamosTrabajador.mon_id
                txtMoneda.Text = oPrestamosTrabajador.Moneda.MON_DESCRIPCION
            Catch ex As Exception
                txtMoneda.Tag = Nothing
                txtMoneda.Text = Nothing

            End Try

            Try
                txtPuntoVenta.Tag = oPrestamosTrabajador.pve_Id
                txtPuntoVenta.Text = oPrestamosTrabajador.PuntoVenta.PVE_DESCRIPCION
            Catch ex As Exception
                txtPuntoVenta.Tag = Nothing
                txtPuntoVenta.Text = Nothing
            End Try


            For Each mItem In oPrestamosTrabajador.DetallePrestamosTrabajador
                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                '[prt_SeriePres]()
                '[prt_NumeroPres]
                '[dpt_ItemPresta]
                '[con_Conceptos_Id]
                '[tic_TipoConcep_Id]
                '[dpt_Importe]
                '[dpt_Vencimiento]

                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = mItem.prt_NumeroPres
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Tag = mItem
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = mItem.dpt_ItemPresta
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tic_TipoConcep_Id").Value = mItem.tic_TipoConcep_Id
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("con_Conceptos_Id").Value = mItem.con_Conceptos_Id
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Conceptos").Value = mItem.Conceptos.con_Concepto
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = mItem.dpt_Importe
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Vencimiento").Value = mItem.dpt_Vencimiento

            Next

        End Sub
        Public Overrides Sub OnManAgregarFilaGrid()
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()

            frm.campo1 = Nothing
            frm.campo2 = Nothing
            frm.campo3 = 1

            frm.inicio(Constants.BuscadoresNames.DetalleConceptosPlanillasLista)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                Dim nRow As New DataGridViewRow
                dgvDetalle.Rows.Add(nRow)
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Value = Nothing
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Numero").Tag = Nothing
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Item").Value = frm.dgbRegistro.CurrentRow.Cells(0).Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("tic_TipoConcep_Id").Value = frm.dgbRegistro.CurrentRow.Cells(2).Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("con_Conceptos_Id").Value = frm.dgbRegistro.CurrentRow.Cells(4).Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Conceptos").Value = frm.dgbRegistro.CurrentRow.Cells(5).Value
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Importe").Value = "0.00"
                dgvDetalle.Rows(dgvDetalle.Rows.Count - 1).Cells("Vencimiento").Value = dateFechaFin.Text

            End If
            frm.Dispose()
            sumar()
        End Sub
        Public Overrides Sub OnManQuitarFilaGrid()




            If (dgvDetalle.SelectedRows.Count > 0) Then

                For Each mDetalle As DataGridViewRow In dgvDetalle.SelectedRows
                    If Not mDetalle.Cells("Numero").Value Is Nothing Then
                        With CType(mDetalle.Cells("Numero").Tag, BE.DetallePrestamosTrabajador)
                            .MarkAsDeleted()
                        End With
                    End If
                Next

                dgvDetalle.Rows.Remove(dgvDetalle.SelectedRows(0))
            Else
                MsgBox("Seleccione un registro")
            End If
            sumar()
        End Sub

        Public Overrides Sub OnManBuscar()

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Planillas.Views.frmBuscarSimple)()

            frm.inicio(Constants.BuscadoresNames.PrestamosTrabajador)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cargar(frm.dgbRegistro.CurrentRow.Cells(0).Value, frm.dgbRegistro.CurrentRow.Cells(1).Value)
                menuBuscar()
            End If
            frm.Dispose()
            Panel1.Enabled = False

        End Sub
        Private Function numeroItem() As Int16
            'mDetalle.Cells("Item").Value()
            Dim resul As Int16 = 0
            Dim x As Integer
            If (oPrestamosTrabajador.ChangeTracker.State = ObjectState.Added) Then
                resul = 0
            ElseIf (oPrestamosTrabajador.ChangeTracker.State = ObjectState.Modified) Then
                While (dgvDetalle.Rows.Count > x)
                    With dgvDetalle.Rows(x)
                        If (IsNumeric(.Cells("Item").Value)) Then
                            If (.Cells("Item").Value > resul) Then
                                resul = Val(.Cells("Item").Value)

                            End If
                        End If
                        x += 1
                    End With
                End While
            End If
            resul += 1
            Return resul
        End Function



        Public Overrides Sub OnManGuardar()
            Dim NumeroFila As Integer
            sumar()
            NumeroFila = numeroItem()
            If (validar()) Then

                Try
                    If oPrestamosTrabajador IsNot Nothing Then
                        dgvDetalle.EndEdit()

                        oPrestamosTrabajador.prt_SeriePres = txtSerie.Text
                        oPrestamosTrabajador.prt_Observaciones = txtObservaciones.Text
                        oPrestamosTrabajador.prt_Importe = txtImporte.Text
                        oPrestamosTrabajador.prt_Fecha = dateFechaFin.Text
                        oPrestamosTrabajador.per_IdTrab = txtTrabajador.Tag
                        oPrestamosTrabajador.per_IdAutoriza = txtAutoriza.Tag
                        oPrestamosTrabajador.Usu_Id = SessionServer.UserId
                        oPrestamosTrabajador.prt_FECGRAB = Now
                        oPrestamosTrabajador.prt_estado = chkActivo.Checked

                        oPrestamosTrabajador.mon_id = (txtMoneda.Tag)

                        oPrestamosTrabajador.pve_Id = txtPuntoVenta.Tag


                        For Each mDetalle As DataGridViewRow In dgvDetalle.Rows
                            If Not mDetalle.Cells("Numero").Value Is Nothing Then
                                With CType(mDetalle.Cells("Numero").Tag, BE.DetallePrestamosTrabajador)

                                    .prt_SeriePres = txtSerie.Text
                                    .dpt_ItemPresta = mDetalle.Cells("Item").Value()
                                    .con_Conceptos_Id = mDetalle.Cells("con_Conceptos_Id").Value
                                    .tic_TipoConcep_Id = mDetalle.Cells("tic_TipoConcep_Id").Value

                                    .dpt_Importe = mDetalle.Cells("Importe").Value
                                    .dpt_Vencimiento = mDetalle.Cells("Vencimiento").Value
                                    .Usu_Id = SessionServer.UserId
                                    .dpt_FECGRAB = Now
                                    .MarkAsModified()
                                End With
                            ElseIf Not mDetalle.Cells("Importe").Value Is Nothing Then
                                Dim nOSD As New BE.DetallePrestamosTrabajador
                                With nOSD

                                    .prt_SeriePres = txtSerie.Text
                                    .dpt_ItemPresta = Mid("000000" & CStr(NumeroFila), ("000000" & CStr(NumeroFila)).Length - 2, 4) ' mDetalle.Cells("Item").Value()
                                    .con_Conceptos_Id = mDetalle.Cells("con_Conceptos_Id").Value
                                    .tic_TipoConcep_Id = mDetalle.Cells("tic_TipoConcep_Id").Value

                                    .dpt_Importe = mDetalle.Cells("Importe").Value
                                    .dpt_Vencimiento = mDetalle.Cells("Vencimiento").Value
                                    .Usu_Id = SessionServer.UserId
                                    .dpt_FECGRAB = Now
                                    .MarkAsAdded()
                                End With
                                oPrestamosTrabajador.DetallePrestamosTrabajador.Add(nOSD)
                                NumeroFila += 1

                            End If
                        Next

                        BCPrestamosTrabajador.Maintenance(oPrestamosTrabajador)
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
            oPrestamosTrabajador = New BE.PrestamosTrabajador
            oPrestamosTrabajador.MarkAsAdded()
            HabilitarElementoGrid()
            Panel1.Enabled = True

        End Sub

        Public Overrides Sub OnManSalir()
            Me.Dispose()
        End Sub


        Public Overrides Sub OnManEliminar()
            MsgBox("Estos Datos No se Eliminan solo se Desactivan ")
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
        Private Sub frmPrestamosTrabajador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            menuInicio()

            Panel1.Enabled = False
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
            ' Panel1.Enabled = False

        End Sub

        Private Sub btnBeneficiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeneficiario.Click
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


        
        Private Sub txtAutoriza_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAutoriza.TextChanged

        End Sub

       
       
        Private Sub dgvDetalle_AllowUserToAddRowsChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetalle.AllowUserToAddRowsChanged
            sumar()
        End Sub

        Private Sub btnAgencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgencia.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.PuntoVenta)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow
                    txtPuntoVenta.Tag = .Cells(0).Value
                    txtPuntoVenta.Text = .Cells(1).Value
                End With
            End If
            frm.Dispose()
        End Sub

        Private Sub btnMoneda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoneda.Click
            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Moneda)
            If (frm.ShowDialog = DialogResult.OK) Then
                With frm.dgbRegistro.CurrentRow

                    txtMoneda.Tag = .Cells(0).Value
                    txtMoneda.Text = .Cells(1).Value

                End With
            End If
            frm.Dispose()
        End Sub
    End Class
End Namespace