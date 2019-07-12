Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Public Class frmReporteTransferenciaLadrillo
    <Dependency()>
    Public Property SessionService As Ladisac.Foundation.Services.ISessionService
    <Dependency()>
    Public Property BCDespacho As Ladisac.BL.BCDespachos

    Private Sub frmReporteTransferenciaLadrillo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlmacen.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Despacho.Views.frmBuscar)()
        frm.Tabla = "AlmacenXPuntoventa"
        frm.Tipo = SessionService.UserId
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtAlmacen.Tag = frm.dgvLista.CurrentRow.Cells("ALM_ID").Value
            txtAlmacen.Text = frm.dgvLista.CurrentRow.Cells("ALM_DESCRIPCION").Value
        Else
            txtAlmacen.Tag = Nothing
            txtAlmacen.Text = String.Empty
        End If
        frm.Dispose()
    End Sub

    Private Sub txtAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAlmacen_DoubleClick(sender, Nothing)
        End If
    End Sub

    Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        Dim ds As New DataSet
        Dim query = BCDespacho.ListaTransferenciaLadrillo(dtpFechaIni.Value.Date, dtpFechaFin.Value.Date, txtAlmacen.Tag)
        If query <> "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaTransferenciaLadrillo", ds.Tables(0)))
            Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFechaFin.Value.Date)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            'parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Transporte", chkTransporte.Checked)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaTransferenciaLadrillo", New DataTable))
            Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFechaIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFechaFin.Value.Date)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            'parametro(3) = New Microsoft.Reporting.WinForms.ReportParameter("Transporte", chkTransporte.Checked)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End If
    End Sub
End Class
