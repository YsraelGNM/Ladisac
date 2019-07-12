Imports Microsoft.Practices.Unity
Imports System.IO

Public Class frmRptListaProgramacionPagoProveedor
    <Dependency()> _
    Public Property BCOrdenCompra As Ladisac.BL.IBCOrdenCompra

    Private Sub frmRptListaProgramacionPagoProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub txtEmpresa_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpresa.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Proveedor"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEmpresa.Tag = frm.dgvLista.CurrentRow.Cells("PER_ID").Value 'Per_Id
            txtEmpresa.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub txtEmpresa_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmpresa.KeyDown
        If e.KeyCode = Keys.Enter Then txtEmpresa_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Try
            Dim query = BCOrdenCompra.ListaProgramacionPagoProveedor(dtpFecIni.Value, dtpFecFin.Value, txtEmpresa.Tag)
            If query.ToString.Length > 0 Then
                Dim rea As New StringReader(query)
                ds.ReadXml(rea)
            End If

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaProgramacionPagoProveedor", ds.Tables(0)))

            'Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Tipo", tipo)

            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaProgramacionPagoProveedor", New DataTable()))
            ReportViewer1.RefreshReport()
        End Try

    End Sub

End Class
