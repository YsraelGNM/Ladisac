Imports Microsoft.Practices.Unity
Imports Ladisac.BE
Imports System.Windows.Forms
Imports System.IO

Public Class frmVisionLink
    <Dependency()> _
    Public Property BCEntidad As Ladisac.BL.IBCEntidad

    Private Sub frmVisionLink_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    Private Sub txtEntidad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntidad.DoubleClick
        Dim frm = Me.ContainerService.Resolve(Of Ladisac.Mantto.Views.frmBuscar)()
        frm.Tabla = "Entidad"
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtEntidad.Tag = CInt(frm.dgvLista.CurrentRow.Cells(0).Value) 'ENO_Id
            txtEntidad.Text = frm.dgvLista.CurrentRow.Cells(1).Value 'Descripcion
        End If
        frm.Dispose()
    End Sub

    Private Sub txtEntidad_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEntidad.KeyDown
        If e.KeyCode = Keys.Enter Then txtEntidad_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub btnIngrsarDatos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngrsarDatos.Click
        BCEntidad.CargarDataVisionLink(txtEntidad.Tag)
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Dim ds As New DataSet
        Dim query = BCEntidad.VLConsumoCombustible(txtEntidad.Tag, dtpFecIni.Value, dtpFecFin.Value)
        Dim rea As New StringReader(query)
        Try
            ds.ReadXml(rea)
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsVLConsumoCombustible", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Almacen", txtAlmacen.Text)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub
End Class
