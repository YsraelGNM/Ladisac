Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptListaReciclajeVentaLadrillo
    <Dependency()> _
    Public Property BCControlDescargaRuma As Ladisac.BL.IBCControlDescargaRuma

    Private Sub frmRptListaReciclajeVentaLadrillo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            Dim ds As New DataSet
            Dim query = BCControlDescargaRuma.ListaReciclajeVentaLadrillo(dtpFecha.Value)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaReciclajeVentaLadrillo", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecha.Value.Date.ToString)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub
End Class
