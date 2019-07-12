Imports Microsoft.Practices.Unity

Public Class frmRptContabilidad
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmRptContabilidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim ds1 As New DataSet
            Dim query1 = BCProduccion.ListaReciclajeVentaLadrilloXAnioSeparado(cboAnio.Text)
            ds1.Merge(query1)
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaReciclajeVentaLadrilloXAnioSeparado", ds1.Tables(0)))

            Dim ds2 As New DataSet
            Dim query2 = BCProduccion.ListaCantidadQuemadaXAnio(cboAnio.Text)
            ds2.Merge(query2)
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaCantidadQuemadaXAnio", ds2.Tables(0)))

            Dim ds3 As New DataSet
            Dim query3 = BCProduccion.ListaTNQuemadaXAnio(cboAnio.Text)
            ds3.Merge(query3)
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaTNQuemadaXAnio", ds3.Tables(0)))

            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Anio", cboAnio.Text)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaReciclajeVentaLadrilloXAnioSeparado", New DataTable()))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaCantidadQuemadaXAnio", New DataTable()))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaTNQuemadaXAnio", New DataTable()))
            ReportViewer1.RefreshReport()
        End Try
    End Sub
End Class
