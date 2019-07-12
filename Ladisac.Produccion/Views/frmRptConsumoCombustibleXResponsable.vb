Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRptConsumoCombustibleXResponsable
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    <Dependency()> _
    Public Property BCHorno As Ladisac.BL.IBCHorno

    Private Sub frmRptConsumoCombustibleXResponsable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarHornos()
        cboHorno.SelectedIndex = -1
    End Sub

    Sub CargarHornos()
        Dim ds As New DataSet
        Dim query = BCHorno.ListaHorno
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboHorno
            .DisplayMember = "HOR_Descripcion"
            .ValueMember = "HOR_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim query = BCProduccion.ListaConsumoCombustibleXResponsable(dtpFecIni.Value.Date, dtpFecFin.Value.Date, CInt(cboHorno.SelectedValue))
        If query <> "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaConsumoCombustibleXResponsable", ds.Tables(0)))
            Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Horno", cboHorno.Text)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("fecini", dtpFecIni.Value.Date)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("fecfin", dtpFecFin.Value.Date)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaConsumoCombustibleXResponsable", New DataTable))
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Fecha", dtpFecIni.Value.Date)
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End If
    End Sub
End Class
