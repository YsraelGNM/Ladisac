Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Data

Public Class frmReporteGuiasPorSalir
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDespacho As Ladisac.BL.IBCDespachos

    Private Sub frmReporteGuiasPorSalir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim ds As New DataSet
        Dim query = BCDespacho.ListaGuiasPorSalir(dtpFechaIni.Value.Date)
        If query <> "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaGuiasPorSalir", ds.Tables(0)))
            'Dim parametro(3) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFechaIni.Value.Date)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFechaFin.Value.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Detallado", chkDetallado.Checked)
            'parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Transporte", chkTransporte.Checked)
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaGuiasPorSalir", New DataTable))
            'Dim parametro(3) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFechaIni.Value.Date)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFechaFin.Value.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Detallado", chkDetallado.Checked)
            'parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Transporte", chkTransporte.Checked)
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End If
    End Sub
End Class
