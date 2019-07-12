Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Data

Public Class frmReporteGuiaSaleTarde
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDespacho As Ladisac.BL.IBCDespachos


    Private Sub frmReporteGuiaSaleTarde_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim ds As New DataSet
        Dim Filtro As Integer = 0
        Dim Numero As String = Nothing

        If chkTraza.Checked Then
            If rbtPedido.Checked Then
                Filtro = 1
            ElseIf rbtDocumento.Checked Then
                Filtro = 2
            ElseIf rbtGuia.Checked Then
                Filtro = 3
            End If

            Numero = txtSerie.Text.Trim.PadLeft(3, "0") & txtNumero.Text.Trim.PadLeft(10, "0")

        Else
            Filtro = 0
            Numero = Nothing
        End If

        Dim query = BCDespacho.ListaGuiaSaleTarde(dtpFechaIni.Value.Date, dtpFechaFin.Value.Date, Filtro, Numero)
        If query <> "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaGuiaSaleTarde", ds.Tables(0)))
            Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Fecfin", dtpFechaFin.Value.Date)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Traza", chkTraza.Checked)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaGuiaSaleTarde", New DataTable))
            Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("Fecfin", dtpFechaFin.Value.Date)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Traza", chkTraza.Checked)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End If
    End Sub

    Private Sub chkTraza_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkTraza.CheckedChanged
        If chkTraza.Checked Then
            GroupBox1.Enabled = True
        Else
            GroupBox1.Enabled = False
        End If
        rbtPedido.Checked = False
        rbtDocumento.Checked = False
        rbtGuia.Checked = False
        txtSerie.Text = ""
        txtNumero.Text = ""
    End Sub

    Private Sub dsListaGuiaSaleTardeBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dsListaGuiaSaleTardeBindingSource.CurrentChanged

    End Sub
End Class
