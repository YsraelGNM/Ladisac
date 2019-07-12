Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptListatnQuemadas
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    
    Private Sub frmRptListatnQuemadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            Dim ds As New DataSet
            Dim query = BCProduccion.Listatnquemadas(dtpFecIni.Value, dtpFecFin.Value)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            Dim ds1 As New DataSet
            Dim query1 = BCProduccion.ListaTnProducidas(dtpFecIni.Value, dtpFecFin.Value)
            Dim rea1 As New StringReader(query1)
            ds1.ReadXml(rea1)

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaTnQuemadas", ds.Tables(0)))
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaTnProducidas", ds1.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            Dim mDet As String = IIf(chkDetallado.Checked, "1", "0")
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Detallado", mDet)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
