
Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Namespace Ladisac.Planillas.Views

    Public Class frmPlanillaMantenimiento

        <Dependency()> _
        Public Property BCPlanilla As BL.IBCPlanilla

        <Dependency()> _
        Public Property BCDetallePlanilla As BL.IBCDetallePlanilla

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil


        Private Sub btnPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPeriodo.Click

            Dim frm = Me.ContainerService.Resolve(Of Ladisac.Contabilidad.Views.frmBuscarSimple)()
            frm.inicio(Ladisac.Contabilidad.Constants.BuscadoresNames.Periodo)
            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                txtPeriodo.Text = frm.dgbRegistro.CurrentRow.Cells(0).Value
            End If

            frm.Dispose()

            If (txtPeriodo.Text <> "") Then
                cargarBoletas()
            End If

        End Sub

        Private Sub btnBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoleta.Click

            Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentos)()
            frm.inicio(Constants.BuscadoresNames.BuscarPlanilla)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                With frm.dgbRegistro.CurrentRow

                    txtSerie.Text = .Cells("Serie").Value()
                    txtNumero.Text = .Cells("numero").Value
                    txtDescripcion.Text = .Cells("Descripcion").Value
                    ' menuBuscar()
                End With

            End If
            frm.Dispose()
            If (txtSerie.Text <> "") Then
                cargarPersonas()
            End If

        End Sub
        Private Sub cargarPersonas()
            Dim query As String = Nothing

            dgvPersonas.DataSource = Nothing

            query = Me.BCPlanilla.spPlanillaPersonaSelectXML(txtSerie.Text, txtNumero.Text)

            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgvPersonas.DataSource = ds.Tables(0)

                Else
                    dgvPersonas.DataSource = Nothing
                End If
            End If
        End Sub
        Private Sub cargarConceptosPlanillas()
            Dim query As String = Nothing

            dgvConceptosTrabajador.DataSource = Nothing

            query = Me.BCPlanilla.spPlanillaPersonaDetalleSelectXML(txtSeriePLL.Text, txtNumeroPLL.Text, txtTrabajador.Tag)

            If (query <> Nothing) Then
                Dim ds As New DataSet
                Dim rea As New StringReader(query)
                If (query <> "") Then
                    ds.ReadXml(rea)
                    dgvConceptosTrabajador.DataSource = ds.Tables(0)

                Else
                    dgvConceptosTrabajador.DataSource = Nothing
                End If
            End If
        End Sub
        Private Sub cargarBoletas()
            Dim query As String = Nothing

            dgvBoletas.DataSource = Nothing

            dgvBoletas.DataSource = Me.BCPlanilla.spPlanillaBuscarSelectXML(txtPeriodo.Text, txtPeriodo.Text, Nothing, Nothing, Nothing)

            'If (query <> Nothing) Then
            '    Dim ds As New DataSet
            '    Dim rea As New StringReader(query)
            '    If (query <> "") Then
            '        ds.ReadXml(rea)
            '        dgvBoletas.DataSource = ds.Tables(0)

            '    Else
            '        dgvBoletas.DataSource = Nothing
            '    End If
            'End If
        End Sub

        Private Sub btnBuscarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDatos.Click
            If (txtTrabajador.Tag <> "") Then
                cargarConceptosPlanillas()
            End If

        End Sub


        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarDocumentos)()
            frm.inicio(Constants.BuscadoresNames.BuscarPlanilla)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                With frm.dgbRegistro.CurrentRow

                    txtSeriePLL.Text = .Cells("Serie").Value()
                    txtNumeroPLL.Text = .Cells("Numero").Value
                    txtDescripcionPLL.Text = .Cells("Descripcion").Value
                    ' menuBuscar()
                End With

            End If
            frm.Dispose()
            dgvConceptosTrabajador.DataSource = Nothing

        End Sub

        Private Sub btnTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrabajador.Click
            Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
            frm.inicio(Constants.BuscadoresNames.DatosLaborales)

            If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                With frm.dgbRegistro.CurrentRow

                    txtTrabajador.Tag = .Cells(0).Value
                    txtTrabajador.Text = .Cells(2).Value
                    ' menuBuscar()
                End With

            End If
            frm.Dispose()
            dgvConceptosTrabajador.DataSource = Nothing
        End Sub

        Private Sub btnEliminarBoleta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarBoleta.Click
            If (dgvBoletas.SelectedRows.Count > 0) Then

                With dgvBoletas.SelectedRows(0)

                    If ((MsgBox("Esta Seguro Eliminar toda la planillas N°- " & .Cells("Numero").Value, vbYesNo) = MsgBoxResult.Yes)) Then
                        If (BCPlanilla.SPPlanillaDelete(.Cells("Serie").Value, .Cells("Numero").Value, Nothing)) Then
                            MsgBox("Cambios Realizados")
                            dgvBoletas.DataSource = Nothing
                        Else
                            MsgBox("No se pudo realizar los cambios ", vbExclamation)
                        End If
                    End If

                End With

            Else
                MsgBox("Seleccione un registro ")
            End If
        End Sub

        Private Sub btnEliminarTrabajador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminarTrabajador.Click
            If (dgvPersonas.SelectedRows.Count > 0) Then

                With dgvPersonas.SelectedRows(0)
                    If ((MsgBox("Esta Seguro de eliminar la Boleta del Trabajador ", vbYesNo) = MsgBoxResult.Yes)) Then

                        If (BCPlanilla.SPPlanillaDelete(.Cells(0).Value, .Cells(1).Value, .Cells(2).Value)) Then
                            MsgBox("Cambios Realizados")
                            dgvPersonas.DataSource = Nothing
                        Else
                            MsgBox("No se pudo realizar los cambios ", vbExclamation)
                        End If

                    End If
                End With

            Else
                MsgBox("Seleccione un registro ")
            End If
        End Sub

        Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click

            If (dgvConceptosTrabajador.RowCount > 0) Then

                If ((MsgBox("Esta Seguro de Relizar los cambio en la Boleta del trabajador ", vbYesNo) = MsgBoxResult.Yes)) Then
                    If (BCDetallePlanilla.SPDetallePlanillasUpdate(BCUtil.getXml(dgvConceptosTrabajador, 0, 1, 2, 3, 6, 7, 9))) Then
                        MsgBox("Cambios Realizados")
                        dgvConceptosTrabajador.DataSource = Nothing
                    Else
                        MsgBox("No se pudo realizar los cambios ", vbExclamation)
                    End If

                End If

            Else
                MsgBox("Seleccione una Planilla y Trabajador ")

            End If
        End Sub

        Private Sub txtCodigoBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoBuscar.TextChanged
            Dim x As Integer = 0
            x = 0
            If (txtCodigoBuscar.Text.Length >= 4) Then
                While (dgvPersonas.Rows.Count > x)

                    Try
                        If (dgvPersonas.Rows(x).Cells("Codigo").Value = txtCodigoBuscar.Text) Then
                            dgvPersonas.CurrentCell = dgvPersonas.Rows(x).Cells("Codigo")
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try

                    x += 1
                End While

            End If
        End Sub
    End Class

End Namespace
