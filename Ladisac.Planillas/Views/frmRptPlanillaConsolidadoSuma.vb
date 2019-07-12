Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptPlanillaConsolidadoSuma
    Public dt As DataTable

    Private Sub frmRptPlanillaConsolidadoSuma_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReportePlanillaConsolidadoSuma", ds.Tables(0)))

            'Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", tipo)

            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        
    End Sub
End Class
