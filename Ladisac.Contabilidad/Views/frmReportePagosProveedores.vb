Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms

Namespace Ladisac.Contabilidad.Views
    Public Class frmReportePagosProveedores

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad

        <Dependency()> _
        Public Property BCUtil As BL.IBCUtil
        Dim oreporte As New rptPagosProveedores


        <Dependency()> _
        Public Property BCKardexCtaCteDetracciones As BL.IBCKardexCtaCteDetracciones

        Dim oreporteCortado As New rptPagosProveedoresCortado

        Sub buscarPersona()
            Try

                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)
                frm.campo1 = "SI"

                If (frm.ShowDialog = DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow

                        txtPersona.Tag = .Cells(0).Value
                        txtPersona.Text = .Cells(1).Value

                    End With
                    cargar(txtPersona.Tag)
                End If

            Catch ex As Exception
                dgvDocumenos.DataSource = Nothing

                MsgBox("No se pudo cargar lo datos, Intente mas tarde")
            End Try

        End Sub
        Sub cargar(ByVal idpersona As String)
            'Me.Cursor = Cursors.WaitCursor
            Dim query As DataTable
            Try
                query = BCConsultasReportesContabilidad.spSaldosKardex(idpersona)

                dgvDocumenos.DataSource = query



            Catch ex As Exception
                Me.Cursor = Cursors.Default
                dgvDocumenos.DataSource = Nothing
                MsgBox("No se pudo cargar lo datos, Intente mas tarde")
            End Try

            Me.Cursor = Cursors.Default

        End Sub
        Sub cargarDetracciones()
            Dim query As DataTable
            Try
                query = BCKardexCtaCteDetracciones.spListaDetracciones()

                dgvDocumenos.DataSource = query



            Catch ex As Exception
                dgvDocumenos.DataSource = Nothing
                MsgBox("No se pudo cargar lo datos, Intente mas tarde")
            End Try



        End Sub

        Private Sub btnBuscarpersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarpersona.Click
            buscarPersona()

        End Sub

        Private Sub frmReportePagosProveedores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Function validar(ByVal filaOrigen As Integer) As Boolean

            Dim res As Boolean = True
            Dim filaDestino As Integer = 0

            While (dgvImprime.Rows.Count > filaDestino)
                If (dgvDocumenos.Rows(filaOrigen).Cells(0).Value = dgvImprime.Rows(filaDestino).Cells(0).Value AndAlso _
                             dgvDocumenos.Rows(filaOrigen).Cells(1).Value = dgvImprime.Rows(filaDestino).Cells(1).Value AndAlso _
                             dgvDocumenos.Rows(filaOrigen).Cells(2).Value = dgvImprime.Rows(filaDestino).Cells(2).Value AndAlso _
                             dgvDocumenos.Rows(filaOrigen).Cells(3).Value = dgvImprime.Rows(filaDestino).Cells(3).Value AndAlso _
                             dgvDocumenos.Rows(filaOrigen).Cells(4).Value = dgvImprime.Rows(filaDestino).Cells(4).Value AndAlso _
                             dgvDocumenos.Rows(filaOrigen).Cells(5).Value = dgvImprime.Rows(filaDestino).Cells(5).Value AndAlso _
                             dgvDocumenos.Rows(filaOrigen).Cells(6).Value = dgvImprime.Rows(filaDestino).Cells(6).Value AndAlso _
                             dgvDocumenos.Rows(filaOrigen).Cells(7).Value = dgvImprime.Rows(filaDestino).Cells(7).Value AndAlso _
                              dgvDocumenos.Rows(filaOrigen).Cells(8).Value = dgvImprime.Rows(filaDestino).Cells(8).Value AndAlso _
                              dgvDocumenos.Rows(filaOrigen).Cells(9).Value = dgvImprime.Rows(filaDestino).Cells(9).Value AndAlso _
                              dgvDocumenos.Rows(filaOrigen).Cells(10).Value = dgvImprime.Rows(filaDestino).Cells(10).Value AndAlso _
                              dgvDocumenos.Rows(filaOrigen).Cells(11).Value = dgvImprime.Rows(filaDestino).Cells(11).Value AndAlso _
                              dgvDocumenos.Rows(filaOrigen).Cells(12).Value = dgvImprime.Rows(filaDestino).Cells(12).Value AndAlso _
                              dgvDocumenos.Rows(filaOrigen).Cells(13).Value = dgvImprime.Rows(filaDestino).Cells(13).Value) Then


                    res = False

                End If
                filaDestino = filaDestino + 1

            End While
            If (Not res) Then
                MsgBox("El Documento ya Exsiste")
            End If


            Return res

        End Function
        Private Sub btnPasar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasar.Click
            Dim X As Integer = 0

            If (dgvImprime.Columns.Count <= 0) Then


                While (dgvDocumenos.Columns.Count > X)
                    dgvImprime.Columns.Add(dgvDocumenos.Columns(X).HeaderText, dgvDocumenos.Columns(X).HeaderText)
                    X += 1
                End While


            End If

            X = 0

            Dim y As Integer = 0

            While (dgvDocumenos.SelectedRows.Count > y)

                If (validar(dgvDocumenos.SelectedRows(y).Index)) Then
                    dgvImprime.Rows.Add()
                    X = 0
                    While (dgvDocumenos.Columns.Count > X)

                        dgvImprime.Rows(dgvImprime.Rows.Count - 1).Cells(X).Value = dgvDocumenos.SelectedRows(y).Cells(X).Value

                        X += 1

                    End While

                End If

                y += 1
            End While
            PRECALCULO()
        End Sub

        Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
            If (dgvImprime.SelectedRows.Count > 0) Then
                dgvImprime.Rows.RemoveAt(dgvImprime.SelectedRows(0).Index)
            End If
            PRECALCULO()
        End Sub

        Private Sub PRECALCULO()
            Dim cargo, abono As Double
            Dim x As Integer = 0
            cargo = 0
            abono = 0
            Try

                While (dgvImprime.Rows.Count > x)

                    cargo += dgvImprime.Rows(x).Cells("cargo").Value
                    abono += dgvImprime.Rows(x).Cells("abono").Value
                    x += 1
                End While
                txtCargo.Text = cargo
                txtAbono.Text = abono
            Catch ex As Exception
                txtCargo.Text = cargo
                txtAbono.Text = abono
            End Try


        End Sub
        Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click

            Dim cargo, abono As Double
            cargo = 0
            abono = 0

            Dim x As Integer = 0

            While (dgvImprime.Rows.Count > x)

                cargo += dgvImprime.Rows(x).Cells("cargo").Value
                abono += dgvImprime.Rows(x).Cells("abono").Value
                x += 1
            End While
            txtCargo.Text = cargo
            txtAbono.Text = abono

            Dim otable As New DataTable
            otable = BCUtil.getTable(dgvImprime, "spImprimir")

            Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

            If (chkEncabezados.Checked) Then
                'oreporteCortado

                oreporteCortado.Database.Tables(0).SetDataSource(otable)
                ' oreporte.DataDefinition.FormulaFields("Sumacargo").Text = "'" & txtCargo.Text & " '"

                ' oreporte.DataDefinition.FormulaFields("SumaAbono").Text = "'" & txtAbono.Text & " '"
                oreporteCortado.DataDefinition.FormulaFields("SumaSaldo").Text = "'" & (abono - cargo) & " '"
                frm.Reporte(oreporteCortado)

            Else
                oreporte.Database.Tables(0).SetDataSource(otable)
                ' oreporte.DataDefinition.FormulaFields("Sumacargo").Text = "'" & txtCargo.Text & " '"

                ' oreporte.DataDefinition.FormulaFields("SumaAbono").Text = "'" & txtAbono.Text & " '"
                oreporte.DataDefinition.FormulaFields("SumaSaldo").Text = "'" & (abono - cargo) & " '"
                frm.Reporte(oreporte)

            End If

            frm.ShowDialog()


        End Sub

        Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged


            Dim x As Integer = 0
            x = 0
            If (txtNumero.Text.Length >= 2) Then
                While (dgvDocumenos.Rows.Count > x)
                    Try
                        If (CInt(dgvDocumenos.Rows(x).Cells("DOC_NUMERO").Value) = CInt(txtNumero.Text)) Then
                            dgvDocumenos.CurrentCell = dgvDocumenos.Rows(x).Cells("DOC_NUMERO")
                            Exit Sub
                        End If
                    Catch ex As Exception

                    End Try
                    x += 1
                End While

            End If
        End Sub

        Private Sub rdbPagos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPagos.CheckedChanged
            Panel3.Enabled = True
            btnObtenerDetracciones.Enabled = False
            btnImprimir.Enabled = True
        End Sub

        Private Sub rdbDetracciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDetracciones.CheckedChanged
            Panel3.Enabled = False
            btnObtenerDetracciones.Enabled = True
            btnImprimir.Enabled = False
        End Sub

        Private Sub btnObtenerDetracciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObtenerDetracciones.Click
            cargarDetracciones()
        End Sub
    End Class
End Namespace
