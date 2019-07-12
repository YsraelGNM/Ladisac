Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRptReporteOrdenSalida
    <Dependency()> _
    Public Property BCOrdenSalida As Ladisac.BL.IBCOrdenSalida

    Private Sub frmRptReporteOrdenSalida_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnActualizar_Click(Nothing, Nothing)
    End Sub

    Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click
        Try
            Dim ds As New DataSet
            Dim dt As DataTable = BCOrdenSalida.ReporteOrdenSalida(dtpFecIni.Value, dtpFecFin.Value)
            ds.Tables.Add(New DataTable)
            ds.Tables(0).Merge(dt)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteOrdenSalida", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecIni.Value.Date)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text.ToString)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            ' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteOrdenSalida", New DataTable()))
            ReportViewer1.RefreshReport()
        End Try
    End Sub
End Class
