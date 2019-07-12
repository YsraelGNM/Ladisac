Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling
Imports Infrastructure.ExceptionHandling
Imports Microsoft.Reporting.WinForms

Namespace Ladisac.Contabilidad.Views
    Public Class frmReportesDAOT

        <Dependency()> _
        Public Property BCConsultasReportesContabilidad As BL.IBCConsultasReportesContabilidad



        Dim oReporte As New rptDAOTComprasDetalle
        Dim oReporte2 As New rptDAOTComprasResumen
        Dim oReporte3 As New rptDAOTVentasDetalle
        Dim oReporte4 As New rptDAOTVentasResumen


        Private Sub btnPersona_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPersona.Click

            Try
                Dim frm = Me.ContainerService.Resolve(Of frmBuscarSimple)()
                frm.inicio(Constants.BuscadoresNames.BuscarPersona)
                If (frm.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    With frm.dgbRegistro.CurrentRow
                        txtPersona.Tag = .Cells(0).Value()
                        txtPersona.Text = .Cells(1).Value
                    End With
                End If
                frm.Dispose()
            Catch ex As Exception

            End Try

        End Sub

        Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Me.Dispose()

        End Sub

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Dim oTable As New DataTable

            Try

                If (rdbCompraAcumulado.Checked) Then

                    oTable = Me.BCConsultasReportesContabilidad.SPSelectReportDAOTComprasResumen(CInt(txtAño.Text))

                End If

                If (rdbComprasDetalle.Checked) Then

                    oTable = Me.BCConsultasReportesContabilidad.SPSelectReportDAOTComprasDetalle(CInt(txtAño.Text), txtPersona.Tag)

                End If


                If (rdbVentaAcumulado.Checked) Then

                    oTable = Me.BCConsultasReportesContabilidad.SPSelectReportDAOTVentasResumen(CInt(txtAño.Text))

                End If

                If (rdbVentaDetalle.Checked) Then

                    oTable = Me.BCConsultasReportesContabilidad.SPSelectReportDAOTVentasDetalle(CInt(txtAño.Text), txtPersona.Tag)

                End If




                Dim frm = Me.ContainerService.Resolve(Of frmVisorReportes)()

              If (rdbCompraAcumulado.Checked) Then
                    oReporte2.Database.Tables(0).SetDataSource(oTable)
                    'oReporte2.DataDefinition.FormulaFields("Reporte").Text = "'" & Ladisac.Contabilidad.Constants.MenuNames.Comprobantes & " '"
                    'oReporte2.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & " '"

                    frm.Reporte(oReporte2)
                End If

                If (rdbComprasDetalle.Checked) Then

                    oReporte.Database.Tables(0).SetDataSource(oTable)
                    'oRptComprobantes.DataDefinition.FormulaFields("Reporte").Text = "'" & Ladisac.Contabilidad.Constants.MenuNames.ComprobantesRenta4ta & " '"
                    'oRptComprobantes.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & " '"


                    frm.Reporte(oReporte)
                End If

                If (rdbVentaAcumulado.Checked) Then

                    oReporte4.Database.Tables(0).SetDataSource(oTable)
                    'oRptComprobantes.DataDefinition.FormulaFields("Reporte").Text = "'" & Ladisac.Contabilidad.Constants.MenuNames.ComprobantesPercepcionReportes & " '"
                    'oRptComprobantes.DataDefinition.FormulaFields("SubTitulo").Text = "'Desde " & dateDesde.Text & "  hasta " & dateHasta.Text & " '"

                    frm.Reporte(oReporte4)
                End If
                If (rdbVentaDetalle.Checked) Then
                    oReporte3.Database.Tables(0).SetDataSource(oTable)

                    frm.Reporte(oReporte3)
                End If

                frm.ShowDialog()
            Catch ex As Exception
                MsgBox("No se puede mostrar la informacion :" & ex.Message)
            End Try
        End Sub
    End Class
End Namespace
