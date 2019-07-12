Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmRptListasGuiasFacturadas
   
    <Dependency()> _
    Public Property BCDocuMovimiento As Ladisac.BL.IBCDocuMovimiento

    Private Sub frmRptListasGuiasFacturadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.ReportViewer1.RefreshReport()
        'txtAlmacen.Tag = Nothing

        txtAlmacen.TabIndex = 0
        dtpFecIni.TabIndex = 1
        dtpFecFin.TabIndex = 2
        btnVisualizar.TabIndex = 3
        txtAlmacen.Focus()

    End Sub

    Private Sub txtAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlmacen.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Logistica.Views.frmBuscar)()
        frm.Tabla = "Almacen"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtAlmacen.Tag = frm.dgvLista.CurrentRow.Cells(0).Value 'Alm_Id
            txtAlmacen.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAlmacen.KeyDown
        If e.KeyCode = Keys.Enter Then txtAlmacen_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim query = BCDocuMovimiento.ListaGuiasFacturadas(txtAlmacen.Tag, dtpFecIni.Value.Date, dtpFecFin.Value.Date)
        If query <> "" Then
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaGuiasFacturadas", ds.Tables(0)))
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFecIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFecFin.Value.Date)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Else
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaGuiasFacturadas", New DataTable))
            Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FechaIni", dtpFecIni.Value.Date)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FechaFin", dtpFecFin.Value.Date)
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        End If
    End Sub

End Class