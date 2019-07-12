Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptFichaInspeccion
    <Dependency()> _
    Public Property BCFichaInspeccion As Ladisac.BL.IBCFichaInspeccion


    Private Sub frmRptFichaInspeccion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnVisualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnVisualizar.Click
        Try
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim ds As New DataSet
            Dim query = BCFichaInspeccion.ReporteFichaInspeccion
            ds.Merge(query)
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFichaInspeccion", ds.Tables(0)))
            'Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFecIni.Value.Date)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFecFin.Value.Date)
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteFichaInspeccion", New DataTable))
            'Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFecIni.Value.Date)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFecFin.Value.Date)
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End Try

    End Sub
End Class
