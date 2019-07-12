Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRptReciclajeVentaLadrillox12Mes
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmRptReciclajeVentaLadrillox12Mes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim query = BCProduccion.ListaReciclajeVentaLadrillox12Mes(numAnio.Value, numMes.Value)
        If query <> "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReciclajeVentaLadrillox12Mes", ds.Tables(0)))
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Mes", numMes.Value)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Anio", numAnio.Value)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReciclajeVentaLadrillox12Mes", New DataTable))
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecIni.Value.Date)
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End If
    End Sub
End Class
