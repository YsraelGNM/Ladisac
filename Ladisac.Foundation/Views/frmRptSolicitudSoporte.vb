Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRptSolicitudSoporte
    <Dependency()> _
    Public Property BCSolicitudSoporte As Ladisac.BL.IBCSolicitudSoporte

    Private Sub frmRptSolicitudSoporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboArea.SelectedIndex = -1
    End Sub

    Private Sub txtSolicitado_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSolicitado.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Foundation.Views.frmBuscar)()
        frm.Tabla = "Persona"
        frm.Tipo = "Trabajador"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtSolicitado.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Per_Id
            txtSolicitado.Text = frm.dgvLista.CurrentRow.Cells(2).Value 'Nombres
        End If
        frm.Dispose()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Try
            Dim query = BCSolicitudSoporte.ReporteSoSo(dtpFecIni.Value, dtpFecFin.Value, cboArea.Text, txtSolicitado.Tag)
            ds.Merge(query)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteSoSo", ds.Tables(0)))
            ''ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            ''parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            ''parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            ' '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteSoSo", New DataTable()))
            ReportViewer1.RefreshReport()
        End Try
    End Sub
End Class
