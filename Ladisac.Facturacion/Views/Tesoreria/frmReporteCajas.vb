Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Namespace Ladisac.Tesoreria.Views

    Public Class frmReporteCajas
        Dim oReporte As New Object
        Dim oReporteR As New ReporteMovimientoCajaPorOrigen
        Dim oReporteD As New ReporteMovimientoCajaPorOrigenDetalle
        Dim oReporteD1 As New VentaDiariaFinanzas

        <Dependency()> _
        Public Property BCKardexCtaCte As BL.IBCKardexCtaCte

        Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim otable As DataTable
            Dim frm = ContainerService.Resolve(Of Ladisac.Reporteador)()

            If rbResumen.Checked Then
                oReporte = oReporteR
                otable = BCKardexCtaCte.SpMovimientoCajaPorOrigen(CDate(dateHasta.Text), CDate(dateHasta.Text))
            ElseIf rbDetalle.Checked Then
                oReporte = oReporteD
                otable = BCKardexCtaCte.SpMovimientoCajaPorOrigenDetalle(CDate(dateHasta.Text), CDate(dateHasta.Text))
            ElseIf rbDetalle1.Checked Then
                oReporte = oReporteD1
                otable = BCKardexCtaCte.spVentaDiariaFinanzas(CDate(dateHasta.Text), CDate(dateHasta.Text))
            End If

            oReporte.Database.Tables(0).SetDataSource(otable)
            oReporte.DataDefinition.FormulaFields("SubTitulo").Text = "' Desde" & dateDesde.Text & "  hasta " & dateHasta.Text & " '"
            frm.Reporte(oReporte)

            frm.Show()

            Me.Cursor = Windows.Forms.Cursors.Default
        End Sub

        Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub
    End Class
End Namespace
