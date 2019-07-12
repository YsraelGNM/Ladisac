Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptSalidaSecadero
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion
    <Dependency()> _
    Public Property BCSecadero As Ladisac.BL.IBCSecadero

    Private Sub frmRptSalidaSecadero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarSecaderos()
        cboSecadero.SelectedIndex = -1
        Me.ReportViewer3.RefreshReport()
    End Sub

    Sub CargarSecaderos()
        Dim ds As New DataSet
        Dim query = BCSecadero.ListaSecadero
        Dim rea As New StringReader(query)
        ds.ReadXml(rea)
        With cboSecadero
            .DisplayMember = "SEC_Descripcion"
            .ValueMember = "SEC_ID"
            .DataSource = ds.Tables(0)
        End With
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer2.LocalReport.DataSources.Clear()
            ReportViewer3.LocalReport.DataSources.Clear()

            Dim ds As New DataSet
            Dim query = BCProduccion.ReporteSalidaSecadero(dtpFecIni.Value.Date, dtpFecFin.Value.Date, cboSecadero.SelectedValue)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            dgvDetalle.DataSource = ds.Tables(0)

            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteSalidaSecadero", ds.Tables(0)))
            ReportViewer2.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteSalidaSecadero", ds.Tables(0)))
            ReportViewer3.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsReporteSalidaSecadero", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            Dim parametro(0) As Microsoft.Reporting.WinForms.ReportParameter
            parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("Secadero", cboSecadero.Text)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.DateTime.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            ''Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            Me.ReportViewer1.LocalReport.SetParameters(parametro)
            Me.ReportViewer2.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
            ReportViewer2.RefreshReport()
            ReportViewer3.RefreshReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
