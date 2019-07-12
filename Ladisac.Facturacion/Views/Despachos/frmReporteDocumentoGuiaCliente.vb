Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO
Imports System.Data

Public Class frmReporteDocumentoGuiaCliente
    <Dependency()> _
    Public Property SessionServer As Ladisac.Foundation.Services.ISessionService
    <Dependency()> _
    Public Property BCDespacho As Ladisac.BL.IBCDespachos

    Private Sub frmReporteDocumentoGuiaCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub txtCliente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Cliente"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCliente.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtCliente.Text = frm.dgvLista.CurrentRow.Cells("Nombre").Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim ds As New DataSet
        Dim query = BCDespacho.ListaDocumentoGuiaCliente(txtCliente.Tag, dtpFechaIni.Value.Date, dtpFechaFin.Value.Date, rbtFFD.Checked)
        If query <> "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaDocumentoGuiaCliente", ds.Tables(0)))
            Dim parametro(3) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFechaFin.Value.Date)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Detallado", chkDetallado.Checked)
            parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Transporte", chkTransporte.Checked)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaDocumentoGuiaCliente", New DataTable))
            Dim parametro(3) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFechaFin.Value.Date)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Detallado", chkDetallado.Checked)
            parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Transporte", chkTransporte.Checked)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End If
    End Sub

    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCliente_DoubleClick(sender, Nothing)
        End If
    End Sub
End Class
