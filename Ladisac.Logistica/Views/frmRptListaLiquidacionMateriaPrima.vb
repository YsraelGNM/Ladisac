Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRptListaLiquidacionMateriaPrima
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim ds As New DataSet
        Dim query = BCDocuMovimiento.ListaLiquidacionMateriaPrima(dtpFechaIni.Value.Date, dtpFechaFin.Value.Date)
        If query <> "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaLiquidacionMateriaPrima", ds.Tables(0)))
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFechaFin.Value.Date)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaLiquidacionMateriaPrima", New DataTable))
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFechaFin.Value.Date)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End If
    End Sub

    Private Sub frmRptListaLiquidacionMateriaPrima_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class