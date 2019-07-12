Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptReciclajeDespachoLadrillo
    <Dependency()> _
    Public Property BCControlDescargaRuma As Ladisac.BL.IBCControlDescargaRuma

    Private Sub frmRptReciclajeDespachoLadrillo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            Dim ds As New DataSet
            Dim query = BCControlDescargaRuma.ListaReciclajeDespachoLadrillo(dtpFecIni.Value.Date, dtpFecFin.Value.Date, CInt(txtAlmacen.Tag))
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaReciclajeDespachoLadrillo", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(2) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date.ToString)
            parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date.ToString)
            parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAlmacen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAlmacen.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Produccion.Views.frmBuscar)()
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

End Class
