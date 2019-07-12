Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmReporteTardanzas
    <Dependency()> _
    Public Property BCMarcacion As Ladisac.BL.IBCMarcacion

    Private Sub frmReporteTardanzas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Try
            Dim query = BCMarcacion.ReporteTardanzaXMes(dtpFecIni.Value, dtpFecFin.Value)
            ds.Merge(query)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteTardanzaXMes", ds.Tables(0)))
            ''ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            ''parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteTardanzaXMes", New DataTable()))
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End Try
    End Sub
End Class
